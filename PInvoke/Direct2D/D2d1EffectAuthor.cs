using System;

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
	public delegate HRESULT PD2D1_PROPERTY_GET_FUNCTION([In, MarshalAs(UnmanagedType.Interface)] object effect,
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
	public delegate HRESULT PD2D1_PROPERTY_SET_FUNCTION([In, MarshalAs(UnmanagedType.Interface)] object effect,
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

	/// <summary>Describes flags that influence how the renderer interacts with a custom vertex shader.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ne-d2d1effectauthor-d2d1_change_type typedef enum
	// D2D1_CHANGE_TYPE { D2D1_CHANGE_TYPE_NONE = 0, D2D1_CHANGE_TYPE_PROPERTIES = 1, D2D1_CHANGE_TYPE_CONTEXT = 2, D2D1_CHANGE_TYPE_GRAPH =
	// 3, D2D1_CHANGE_TYPE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NE:d2d1effectauthor.D2D1_CHANGE_TYPE")]
	public enum D2D1_CHANGE_TYPE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>There were no changes.</para>
		/// </summary>
		D2D1_CHANGE_TYPE_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The properties of the effect changed.</para>
		/// </summary>
		D2D1_CHANGE_TYPE_PROPERTIES,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The context state changed.</para>
		/// </summary>
		D2D1_CHANGE_TYPE_CONTEXT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The effect’s transform graph has changed. This happens only when an effect supports a variable input count.</para>
		/// </summary>
		D2D1_CHANGE_TYPE_GRAPH,
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

	/// <summary>Defines capabilities of the underlying Direct3D device which may be queried using <c>ID2D1EffectContext::CheckFeatureSupport</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ne-d2d1effectauthor-d2d1_feature typedef enum D2D1_FEATURE {
	// D2D1_FEATURE_DOUBLES = 0, D2D1_FEATURE_D3D10_X_HARDWARE_OPTIONS = 1, D2D1_FEATURE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NE:d2d1effectauthor.D2D1_FEATURE")]
	public enum D2D1_FEATURE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A D2D1_FEATURE_DATA_DOUBLES structure should be filled.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_FEATURE_DATA_DOUBLES))]
		D2D1_FEATURE_DOUBLES,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>A D2D1_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS structure should be filled.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS))]
		D2D1_FEATURE_D3D10_X_HARDWARE_OPTIONS,
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

	/// <summary>Supplies data to an analysis effect.</summary>
	/// <remarks>
	/// This interface can be implemented by an <c>ID2D1ComputeTransform</c>. The analysis transform must be the output node of an effect's
	/// transform graph, and the effect's registration XML must include the <c>type="Analysis"</c> attribute on the root
	/// <c>&lt;Effect&gt;</c> node.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1analysistransform
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1AnalysisTransform")]
	[ComImport, Guid("0359dc30-95e6-4568-9055-27720d130e93"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1AnalysisTransform
	{
		/// <summary>Supplies the analysis data to an analysis transform.</summary>
		/// <param name="analysisData">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>The data that the transform will analyze.</para>
		/// </param>
		/// <param name="analysisDataCount">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The size of the analysis data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If the method succeeds, it returns <b>S_OK</b>. If it fails, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The output of the transform will be copied to CPU-accessible memory by the imaging effects system before being passed to the implementation.
		/// </para>
		/// <para>If this call fails, the corresponding <c>ID2D1Effect</c> instance is placed into an error state and fails to draw.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1analysistransform-processanalysisresults
		// HRESULT ProcessAnalysisResults( [in] const BYTE *analysisData, UINT32 analysisDataCount );
		void ProcessAnalysisResults([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] analysisData, int analysisDataCount);
	}

	/// <summary>
	/// <para>Provides methods to allow a blend operation to be inserted into a transform graph.</para>
	/// <para>The image output of the blend transform is the same as rendering an image effect graph with these steps:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Copy the first input to the destination image.</description>
	/// </item>
	/// <item>
	/// <description>Render the next input on top using the blend description.</description>
	/// </item>
	/// <item>
	/// <description>Continue for each additional input.</description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1blendtransform
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1BlendTransform")]
	[ComImport, Guid("63ac0b32-ba44-450f-8806-7f4ca1ff2f1b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1BlendTransform : ID2D1ConcreteTransform, ID2D1TransformNode
	{
		/// <summary>Gets the number of inputs to the transform node.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>This method returns the number of inputs to this transform node.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformnode-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		new uint GetInputCount();

		/// <summary>Sets the properties of the output buffer of the specified transform node.</summary>
		/// <param name="bufferPrecision">
		/// <para>Type: <b><c>D2D1_BUFFER_PRECISION</c></b></para>
		/// <para>The number of bits and the type of the output buffer.</para>
		/// </param>
		/// <param name="channelDepth">
		/// <para>Type: <b><c>D2D1_CHANNEL_DEPTH</c></b></para>
		/// <para>The number of channels in the output buffer (1 or 4).</para>
		/// </param>
		/// <remarks>
		/// <para>You can use the <c>ID2D1EffectContext::IsBufferPrecisionSupported</c> method to see if buffer precision is supported.</para>
		/// <para>The available channel depth and precision depend on the capabilities of the underlying Microsoft Direct3D device.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1concretetransform-setoutputbuffer
		// HRESULT SetOutputBuffer( D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth );
		new void SetOutputBuffer(D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth);

		/// <summary>Sets whether the output of the specified transform is cached.</summary>
		/// <param name="isCached">
		/// <para>Type: <b>BOOL</b></para>
		/// <para><b>TRUE</b> if the output should be cached; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1concretetransform-setcached void
		// SetCached( BOOL isCached );
		[PreserveSig]
		new void SetCached(bool isCached);

		/// <summary>Changes the blend description of the corresponding blend transform object.</summary>
		/// <param name="description">
		/// <para>Type: <b>const <c>D2D1_BLEND_DESCRIPTION</c>*</b></para>
		/// <para>The new blend description specified for the blend transform.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1blendtransform-setdescription void
		// SetDescription( [in] const D2D1_BLEND_DESCRIPTION *description );
		[PreserveSig]
		void SetDescription(in D2D1_BLEND_DESCRIPTION description);

		/// <summary>Gets the blend description of the corresponding blend transform object.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_BLEND_DESCRIPTION</c>*</b></para>
		/// <para>When this method returns, contains the blend description specified for the blend transform.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1blendtransform-getdescription void
		// GetDescription( [out] D2D1_BLEND_DESCRIPTION *description );
		D2D1_BLEND_DESCRIPTION GetDescription();
	}

	/// <summary>Extends the input rectangle to infinity using the specified extend modes.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1bordertransform
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1BorderTransform")]
	[ComImport, Guid("4998735c-3a19-473c-9781-656847e3a347"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1BorderTransform : ID2D1ConcreteTransform, ID2D1TransformNode
	{
		/// <summary>Gets the number of inputs to the transform node.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>This method returns the number of inputs to this transform node.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformnode-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		new uint GetInputCount();

		/// <summary>Sets the properties of the output buffer of the specified transform node.</summary>
		/// <param name="bufferPrecision">
		/// <para>Type: <b><c>D2D1_BUFFER_PRECISION</c></b></para>
		/// <para>The number of bits and the type of the output buffer.</para>
		/// </param>
		/// <param name="channelDepth">
		/// <para>Type: <b><c>D2D1_CHANNEL_DEPTH</c></b></para>
		/// <para>The number of channels in the output buffer (1 or 4).</para>
		/// </param>
		/// <remarks>
		/// <para>You can use the <c>ID2D1EffectContext::IsBufferPrecisionSupported</c> method to see if buffer precision is supported.</para>
		/// <para>The available channel depth and precision depend on the capabilities of the underlying Microsoft Direct3D device.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1concretetransform-setoutputbuffer
		// HRESULT SetOutputBuffer( D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth );
		new void SetOutputBuffer(D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth);

		/// <summary>Sets whether the output of the specified transform is cached.</summary>
		/// <param name="isCached">
		/// <para>Type: <b>BOOL</b></para>
		/// <para><b>TRUE</b> if the output should be cached; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1concretetransform-setcached void
		// SetCached( BOOL isCached );
		[PreserveSig]
		new void SetCached(bool isCached);

		/// <summary>Sets the extend mode in the x direction.</summary>
		/// <param name="extendMode">
		/// <para>Type: <b><c>D2D1_EXTEND_MODE</c></b></para>
		/// <para>The extend mode in the x direction.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the extend mode enumeration is invalid, this operation is ignored.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1bordertransform-setextendmodex void
		// SetExtendModeX( D2D1_EXTEND_MODE extendMode );
		[PreserveSig]
		void SetExtendModeX(D2D1_EXTEND_MODE extendMode);

		/// <summary>Sets the extend mode in the y direction.</summary>
		/// <param name="extendMode">
		/// <para>Type: <b><c>D2D1_EXTEND_MODE</c></b></para>
		/// <para>The extend mode in the y direction.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the extend mode enumeration is invalid, this operation is ignored.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1bordertransform-setextendmodey void
		// SetExtendModeY( D2D1_EXTEND_MODE extendMode );
		[PreserveSig]
		void SetExtendModeY(D2D1_EXTEND_MODE extendMode);

		/// <summary>Gets the extend mode in the x direction.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_EXTEND_MODE</c></b></para>
		/// <para>This method returns the extend mode in the x direction.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1bordertransform-getextendmodex
		// D2D1_EXTEND_MODE GetExtendModeX();
		[PreserveSig]
		D2D1_EXTEND_MODE GetExtendModeX();

		/// <summary>Gets the extend mode in the y direction.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_EXTEND_MODE</c></b></para>
		/// <para>This method returns the extend mode in the y direction.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1bordertransform-getextendmodey
		// D2D1_EXTEND_MODE GetExtendModeY();
		[PreserveSig]
		D2D1_EXTEND_MODE GetExtendModeY();
	}

	/// <summary>A support transform for effects to modify the output rectangle of the previous effect or bitmap.</summary>
	/// <remarks>
	/// <para>The support transform can be used for two different reasons.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// To indicate that a region of its input image is already transparent black. The expanded area will be treated as transparent black.
	/// <para>This can increase efficiency for rendering bitmaps.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>To increase the size of the input image.</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1boundsadjustmenttransform
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1BoundsAdjustmentTransform")]
	[ComImport, Guid("90f732e2-5092-4606-a819-8651970baccd"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1BoundsAdjustmentTransform : ID2D1TransformNode
	{
		/// <summary>Gets the number of inputs to the transform node.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>This method returns the number of inputs to this transform node.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformnode-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		new uint GetInputCount();

		/// <summary>This sets the output bounds for the support transform.</summary>
		/// <param name="outputBounds">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output bounds.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1boundsadjustmenttransform-setoutputbounds
		// void SetOutputBounds( [in] const D2D1_RECT_L *outputBounds );
		[PreserveSig]
		void SetOutputBounds(in RECT outputBounds);

		/// <summary>Returns the output rectangle of the support transform.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output bounds.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1boundsadjustmenttransform-getoutputbounds
		// void GetOutputBounds( [out] D2D1_RECT_L *outputBounds );
		RECT GetOutputBounds();
	}

	/// <summary>Enables specification of information for a compute-shader rendering pass.</summary>
	/// <remarks>The transform changes the state on this render information to specify the compute shader and its dependent resources.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1computeinfo
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1ComputeInfo")]
	[ComImport, Guid("5598b14b-9fd7-48b7-9bdb-8f0964eb38bc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1ComputeInfo : ID2D1RenderInfo
	{
		/// <summary>Sets how a specific input to the transform should be handled by the renderer in terms of sampling.</summary>
		/// <param name="inputIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the input that will have the input description applied.</para>
		/// </param>
		/// <param name="inputDescription">
		/// <para>Type: <b><c>D2D1_INPUT_DESCRIPTION</c></b></para>
		/// <para>The description of the input to be applied to the transform.</para>
		/// </param>
		/// <remarks>The input description must be matched correctly by the effect shader code.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setinputdescription
		// HRESULT SetInputDescription( UINT32 inputIndex, D2D1_INPUT_DESCRIPTION inputDescription );
		new void SetInputDescription(uint inputIndex, D2D1_INPUT_DESCRIPTION inputDescription);

		/// <summary>
		/// Allows a caller to control the output precision and channel-depth of the transform in which the render information is encapsulated.
		/// </summary>
		/// <param name="bufferPrecision">
		/// <para>Type: <b><c>D2D1_BUFFER_PRECISION</c></b></para>
		/// <para>The type of buffer that should be used as an output from this transform.</para>
		/// </param>
		/// <param name="channelDepth">
		/// <para>Type: <b><c>D2D1_CHANNEL_DEPTH</c></b></para>
		/// <para>The number of channels that will be used on the output buffer.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If the output precision of the transform is not specified, then it will default to the precision specified on the Direct2D
		/// device context. The maximum of 16bpc <b>UNORM</b> and 16bpc <b>FLOAT</b> is 32bpc <b>FLOAT</b>.
		/// </para>
		/// <para>The output channel depth will match the maximum of the input channel depths if the channel depth is <b>D2D1_CHANNEL_DEPTH_DEFAULT</b>.</para>
		/// <para>There is no global output channel depth, this is always left to the control of the transforms.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setoutputbuffer HRESULT
		// SetOutputBuffer( D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth );
		new void SetOutputBuffer(D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth);

		/// <summary>Specifies that the output of the transform in which the render information is encapsulated is or is not cached.</summary>
		/// <param name="isCached">
		/// <para>Type: <b>BOOL</b></para>
		/// <para><b>TRUE</b> if the output of the transform is cached; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setcached void
		// SetCached( BOOL isCached );
		[PreserveSig]
		new void SetCached(bool isCached);

		/// <summary>Provides an estimated hint of shader execution cost to D2D.</summary>
		/// <param name="instructionCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>An approximate instruction count of the associated shader.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The instruction count may be set according to the number of instructions in the shader. This information is used as a hint when
		/// rendering extremely large images. Calling this API is optional, but it may improve performance if you provide an accurate number.
		/// </para>
		/// <para><b>Note</b>  Instructions that occur in a loop should be counted according to the number of loop iterations.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setinstructioncounthint
		// void SetInstructionCountHint( UINT32 instructionCount );
		[PreserveSig]
		new void SetInstructionCountHint(uint instructionCount);

		/// <summary>Establishes or changes the constant buffer data for this transform.</summary>
		/// <param name="buffer">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>The data applied to the constant buffer.</para>
		/// </param>
		/// <param name="bufferCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of bytes of data in the constant buffer.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1computeinfo-setcomputeshaderconstantbuffer
		// HRESULT SetComputeShaderConstantBuffer( [in] const BYTE *buffer, UINT32 bufferCount );
		void SetComputeShaderConstantBuffer([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer, int bufferCount);

		/// <summary>Sets the compute shader to the given shader resource. The resource must be loaded before this call is made.</summary>
		/// <param name="shaderId">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>The GUID of the shader.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1computeinfo-setcomputeshader
		// HRESULT SetComputeShader( [in] REFGUID shaderId );
		void SetComputeShader(in Guid shaderId);

		/// <summary>
		/// Sets the resource texture corresponding to the given shader texture index to the given texture resource. The texture resource
		/// must already have been loaded with <c>ID2D1EffectContext::CreateResourceTexture</c> method. This call will fail if the specified
		/// index overlaps with any input. The input indices always precede the texture LUT indices.
		/// </summary>
		/// <param name="textureIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index to set the resource texture on.</para>
		/// </param>
		/// <param name="resourceTexture">
		/// <para>Type: <b><c>ID2D1ResourceTexture</c>*</b></para>
		/// <para>The resource texture object to set on the shader texture index.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1computeinfo-setresourcetexture
		// HRESULT SetResourceTexture( UINT32 textureIndex, [in] ID2D1ResourceTexture *resourceTexture );
		void SetResourceTexture(uint textureIndex, [In] ID2D1ResourceTexture resourceTexture);
	}

	/// <summary>Defines a transform that uses a compute shader.</summary>
	/// <remarks>
	/// The transform implements the normal Shatzis methods by implementing <c>ID2D1Transform</c>. In addition, the caller is passed an
	/// <c>ID2D1ComputeInfo</c> to describe the compute pass that the transform should execute.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1computetransform
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1ComputeTransform")]
	[ComImport, Guid("0d85573c-01e3-4f7d-bfd9-0d60608bf3c3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1ComputeTransform : ID2D1Transform, ID2D1TransformNode
	{
		/// <summary>Gets the number of inputs to the transform node.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>This method returns the number of inputs to this transform node.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformnode-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		new uint GetInputCount();

		/// <summary>
		/// Allows a transform to state how it would map a rectangle requested on its output to a set of sample rectangles on its input.
		/// </summary>
		/// <param name="outputRect">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle from which the inputs must be mapped.</para>
		/// </param>
		/// <param name="inputRects">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The corresponding set of inputs. The inputs will directly correspond to the transform inputs.</para>
		/// </param>
		/// <param name="inputRectsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of inputs specified. <c>Direct2D</c> guarantees that this is equal to the number of inputs specified on the transform.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform implementation must ensure that any pixel shader or software callback implementation it provides honors this calculation.
		/// </para>
		/// <para>
		/// The transform implementation must regard this method as purely functional. It can base the mapped input and output rectangles on
		/// its current state as specified by the encapsulating effect properties. However, it must not change its own state in response to
		/// this method being invoked. The <c>Direct2D</c> renderer implementation reserves the right to call this method at any time and in
		/// any sequence.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapoutputrecttoinputrects
		// HRESULT MapOutputRectToInputRects( const D2D1_RECT_L *outputRect, [out] D2D1_RECT_L *inputRects, UINT32 inputRectsCount );
		new void MapOutputRectToInputRects(in RECT outputRect, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputRects,
			int inputRectsCount);

		/// <summary>Performs the inverse mapping to <c>MapOutputRectToInputRects</c>.</summary>
		/// <param name="inputRects">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>
		/// An array of input rectangles to be mapped to the output rectangle. The <i>inputRects</i> parameter is always equal to the input bounds.
		/// </para>
		/// </param>
		/// <param name="inputOpaqueSubRects">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>An array of input rectangles to be mapped to the opaque output rectangle.</para>
		/// </param>
		/// <param name="inputRectCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of inputs specified. The implementation guarantees that this is equal to the number of inputs specified on the transform.
		/// </para>
		/// </param>
		/// <param name="outputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle that maps to the corresponding input rectangle.</para>
		/// </param>
		/// <param name="outputOpaqueSubRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle that maps to the corresponding opaque input rectangle.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform implementation must ensure that any pixel shader or software callback implementation it provides honors this calculation.
		/// </para>
		/// <para>
		/// Unlike the <c>MapOutputRectToInputRects</c> and <c>MapInvalidRect</c> functions, this method is explicitly called by the
		/// renderer at a determined place in its rendering algorithm. The transform implementation may change its state based on the input
		/// rectangles and use this information to control its rendering information. This method is always called before the
		/// <b>MapInvalidRect</b> and <b>MapOutputRectToInputRects</b> methods of the transform.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapinputrectstooutputrect
		// HRESULT MapInputRectsToOutputRect( [in] const D2D1_RECT_L *inputRects, [in] const D2D1_RECT_L *inputOpaqueSubRects, UINT32
		// inputRectCount, D2D1_RECT_L *outputRect, D2D1_RECT_L *outputOpaqueSubRect );
		new void MapInputRectsToOutputRect([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputRects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputOpaqueSubRects, int inputRectCount,
			out RECT outputRect, out RECT outputOpaqueSubRect);

		/// <summary>Sets the input rectangles for this rendering pass into the transform.</summary>
		/// <param name="inputIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the input rectangle.</para>
		/// </param>
		/// <param name="invalidInputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c></b></para>
		/// <para>The invalid input rectangle.</para>
		/// </param>
		/// <param name="invalidOutputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle to which the input rectangle must be mapped.</para>
		/// </param>
		/// <remarks>
		/// The transform implementation must regard <b>MapInvalidRect</b> as purely functional. The transform implementation can base the
		/// mapped input rectangle on the transform implementation's current state as specified by the encapsulating effect properties. But
		/// the transform implementation can't change its own state in response to a call to <b>MapInvalidRect</b>. Direct2D can call this
		/// method at any time and in any sequence following a call to the <c>MapInputRectsToOutputRect</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapinvalidrect HRESULT
		// MapInvalidRect( UINT32 inputIndex, D2D1_RECT_L invalidInputRect, [out] D2D1_RECT_L *invalidOutputRect );
		new void MapInvalidRect(uint inputIndex, RECT invalidInputRect, out RECT invalidOutputRect);

		/// <summary>Sets the render information used to specify the compute shader pass.</summary>
		/// <param name="computeInfo">
		/// <para>Type: <b><c>ID2D1ComputeInfo</c>*</b></para>
		/// <para>The render information object to set.</para>
		/// </param>
		/// <remarks>If this method fails, <c>ID2D1TransformGraph::AddNode</c> fails.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1computetransform-setcomputeinfo
		// HRESULT SetComputeInfo( [in] ID2D1ComputeInfo *computeInfo );
		void SetComputeInfo([In] ID2D1ComputeInfo computeInfo);

		/// <summary>
		/// This method allows a compute-shader–based transform to select the number of thread groups to execute based on the number of
		/// output pixels it needs to fill.
		/// </summary>
		/// <param name="outputRect">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle that will be filled by the compute transform.</para>
		/// </param>
		/// <param name="dimensionX">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>The number of threads in the x dimension.</para>
		/// </param>
		/// <param name="dimensionY">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>The number of threads in the y dimension.</para>
		/// </param>
		/// <param name="dimensionZ">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>The number of threads in the z dimension.</para>
		/// </param>
		/// <remarks>If this call fails, the corresponding <c>ID2D1Effect</c> instance is placed into an error state and fails to draw.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1computetransform-calculatethreadgroups
		// HRESULT CalculateThreadgroups( [in] const D2D1_RECT_L *outputRect, [out] UINT32 *dimensionX, [out] UINT32 *dimensionY, [out]
		// UINT32 *dimensionZ );
		void CalculateThreadgroups(in RECT outputRect, out uint dimensionX, out uint dimensionY, out uint dimensionZ);
	}

	/// <summary>Represents the set of transforms implemented by the effect-rendering system, which provides fixed-functionality.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1concretetransform
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1ConcreteTransform")]
	[ComImport, Guid("1a799d8a-69f7-4e4c-9fed-437ccc6684cc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1ConcreteTransform : ID2D1TransformNode
	{
		/// <summary>Gets the number of inputs to the transform node.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>This method returns the number of inputs to this transform node.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformnode-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		new uint GetInputCount();

		/// <summary>Sets the properties of the output buffer of the specified transform node.</summary>
		/// <param name="bufferPrecision">
		/// <para>Type: <b><c>D2D1_BUFFER_PRECISION</c></b></para>
		/// <para>The number of bits and the type of the output buffer.</para>
		/// </param>
		/// <param name="channelDepth">
		/// <para>Type: <b><c>D2D1_CHANNEL_DEPTH</c></b></para>
		/// <para>The number of channels in the output buffer (1 or 4).</para>
		/// </param>
		/// <remarks>
		/// <para>You can use the <c>ID2D1EffectContext::IsBufferPrecisionSupported</c> method to see if buffer precision is supported.</para>
		/// <para>The available channel depth and precision depend on the capabilities of the underlying Microsoft Direct3D device.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1concretetransform-setoutputbuffer
		// HRESULT SetOutputBuffer( D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth );
		void SetOutputBuffer(D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth);

		/// <summary>Sets whether the output of the specified transform is cached.</summary>
		/// <param name="isCached">
		/// <para>Type: <b>BOOL</b></para>
		/// <para><b>TRUE</b> if the output should be cached; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1concretetransform-setcached void
		// SetCached( BOOL isCached );
		[PreserveSig]
		void SetCached(bool isCached);
	}

	/// <summary>This interface is used to describe a GPU rendering pass on a vertex or pixel shader. It is passed to <c>ID2D1DrawTransform</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1drawinfo
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1DrawInfo")]
	[ComImport, Guid("693ce632-7f2f-45de-93fe-18d88b37aa21"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1DrawInfo : ID2D1RenderInfo
	{
		/// <summary>Sets how a specific input to the transform should be handled by the renderer in terms of sampling.</summary>
		/// <param name="inputIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the input that will have the input description applied.</para>
		/// </param>
		/// <param name="inputDescription">
		/// <para>Type: <b><c>D2D1_INPUT_DESCRIPTION</c></b></para>
		/// <para>The description of the input to be applied to the transform.</para>
		/// </param>
		/// <remarks>The input description must be matched correctly by the effect shader code.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setinputdescription
		// HRESULT SetInputDescription( UINT32 inputIndex, D2D1_INPUT_DESCRIPTION inputDescription );
		new void SetInputDescription(uint inputIndex, D2D1_INPUT_DESCRIPTION inputDescription);

		/// <summary>
		/// Allows a caller to control the output precision and channel-depth of the transform in which the render information is encapsulated.
		/// </summary>
		/// <param name="bufferPrecision">
		/// <para>Type: <b><c>D2D1_BUFFER_PRECISION</c></b></para>
		/// <para>The type of buffer that should be used as an output from this transform.</para>
		/// </param>
		/// <param name="channelDepth">
		/// <para>Type: <b><c>D2D1_CHANNEL_DEPTH</c></b></para>
		/// <para>The number of channels that will be used on the output buffer.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If the output precision of the transform is not specified, then it will default to the precision specified on the Direct2D
		/// device context. The maximum of 16bpc <b>UNORM</b> and 16bpc <b>FLOAT</b> is 32bpc <b>FLOAT</b>.
		/// </para>
		/// <para>The output channel depth will match the maximum of the input channel depths if the channel depth is <b>D2D1_CHANNEL_DEPTH_DEFAULT</b>.</para>
		/// <para>There is no global output channel depth, this is always left to the control of the transforms.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setoutputbuffer HRESULT
		// SetOutputBuffer( D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth );
		new void SetOutputBuffer(D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth);

		/// <summary>Specifies that the output of the transform in which the render information is encapsulated is or is not cached.</summary>
		/// <param name="isCached">
		/// <para>Type: <b>BOOL</b></para>
		/// <para><b>TRUE</b> if the output of the transform is cached; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setcached void
		// SetCached( BOOL isCached );
		[PreserveSig]
		new void SetCached(bool isCached);

		/// <summary>Provides an estimated hint of shader execution cost to D2D.</summary>
		/// <param name="instructionCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>An approximate instruction count of the associated shader.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The instruction count may be set according to the number of instructions in the shader. This information is used as a hint when
		/// rendering extremely large images. Calling this API is optional, but it may improve performance if you provide an accurate number.
		/// </para>
		/// <para><b>Note</b>  Instructions that occur in a loop should be counted according to the number of loop iterations.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setinstructioncounthint
		// void SetInstructionCountHint( UINT32 instructionCount );
		[PreserveSig]
		new void SetInstructionCountHint(uint instructionCount);

		/// <summary>Sets the constant buffer for this transform's pixel shader.</summary>
		/// <param name="buffer">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>The data applied to the constant buffer.</para>
		/// </param>
		/// <param name="bufferCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of bytes of data in the constant buffer</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1drawinfo-setpixelshaderconstantbuffer
		// HRESULT SetPixelShaderConstantBuffer( [in] const BYTE *buffer, UINT32 bufferCount );
		void SetPixelShaderConstantBuffer([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer, int bufferCount);

		/// <summary>Sets the resource texture corresponding to the given shader texture index.</summary>
		/// <param name="textureIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the texture to be bound to the pixel shader.</para>
		/// </param>
		/// <param name="resourceTexture">
		/// <para>Type: <b><c>ID2D1ResourceTexture</c>*</b></para>
		/// <para>The created resource texture.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1drawinfo-setresourcetexture HRESULT
		// SetResourceTexture( UINT32 textureIndex, [in] ID2D1ResourceTexture *resourceTexture );
		void SetResourceTexture(uint textureIndex, [In] ID2D1ResourceTexture resourceTexture);

		/// <summary>Sets the constant buffer for this transform's vertex shader.</summary>
		/// <param name="buffer">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>The data applied to the constant buffer</para>
		/// </param>
		/// <param name="bufferCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of bytes of data in the constant buffer.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1drawinfo-setvertexshaderconstantbuffer
		// HRESULT SetVertexShaderConstantBuffer( [in] const BYTE *buffer, UINT32 bufferCount );
		void SetVertexShaderConstantBuffer([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer, int bufferCount);

		/// <summary>Set the shader instructions for this transform.</summary>
		/// <param name="shaderId">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>The resource id for the shader.</para>
		/// </param>
		/// <param name="pixelOptions">
		/// <para>Type: <b><c>D2D1_PIXEL_OPTIONS</c></b></para>
		/// <para>Additional information provided to the renderer to indicate the operations the pixel shader does.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If this call fails, the corresponding <c>ID2D1Effect</c> instance is placed into an error state and will fail to Draw, it will
		/// place the context into an error state which can be retrieved through the <c>ID2D1DeviceContext::EndDraw</c> call.
		/// </para>
		/// <para>
		/// Specifying <i>pixelOptions</i> other than D2D1_PIXEL_OPTIONS_NONE can enable the renderer to perform certain optimizations such
		/// as combining various parts of the effect graph together. If this information does not accurately describe the shader,
		/// indeterminate rendering artifacts can result.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1drawinfo-setpixelshader HRESULT
		// SetPixelShader( [in] REFGUID shaderId, D2D1_PIXEL_OPTIONS pixelOptions );
		void SetPixelShader(in Guid shaderId, D2D1_PIXEL_OPTIONS pixelOptions = 0);

		/// <summary>
		/// Sets a vertex buffer, a corresponding vertex shader, and options to control how the vertices are to be handled by the Direct2D context.
		/// </summary>
		/// <param name="vertexBuffer">
		/// <para>Type: <b><c>ID2D1VertexBuffer</c>*</b></para>
		/// <para>The vertex buffer, if this is cleared, the default vertex shader and mapping to the transform rectangles will be used.</para>
		/// </param>
		/// <param name="vertexOptions">
		/// <para>Type: <b><c>D2D1_VERTEX_OPTIONS</c></b></para>
		/// <para>Options that influence how the renderer will interact with the vertex shader.</para>
		/// </param>
		/// <param name="blendDescription">
		/// <para>Type: <b>const <c>D2D1_BLEND_DESCRIPTION</c>*</b></para>
		/// <para>How the vertices will be blended with the output texture.</para>
		/// </param>
		/// <param name="vertexRange">
		/// <para>Type: <b>const <c>D2D1_VERTEX_RANGE</c>*</b></para>
		/// <para>The set of vertices to use from the buffer.</para>
		/// </param>
		/// <param name="vertexShader">
		/// <para>Type: <b>GUID*</b></para>
		/// <para>The GUID of the vertex shader.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The vertex shaders associated with the vertex buffer through the vertex shader GUID must have been loaded through the
		/// <c>ID2D1EffectContext::LoadVertexShader</c> method before this call is made.
		/// </para>
		/// <para>
		/// If you pass the vertex option <c>D2D1_VERTEX_OPTIONS_DO_NOT_CLEAR</c>, then the method fails unless the blend description is
		/// exactly this:
		/// </para>
		/// <para>
		/// <c>D2D1_BLEND_DESCRIPTION blendDesc = { D2D1_BLEND_ONE, D2D1_BLEND_ZERO, D2D1_BLEND_OPERATION_ADD, D2D1_BLEND_ONE,
		/// D2D1_BLEND_ZERO, D2D1_BLEND_OPERATION_ADD, { 1.0f, 1.0f, 1.0f, 1.0f } };</c>
		/// </para>
		/// <para>If this call fails, the corresponding <c>ID2D1Effect</c> instance is placed into an error state and fails to draw.</para>
		/// <para>If blendDescription is NULL, a foreground-over blend mode is used.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1drawinfo-setvertexprocessing
		// HRESULT SetVertexProcessing( [in, optional] ID2D1VertexBuffer *vertexBuffer, D2D1_VERTEX_OPTIONS vertexOptions, [in, optional]
		// const D2D1_BLEND_DESCRIPTION *blendDescription, [in, optional] const D2D1_VERTEX_RANGE *vertexRange, const GUID *vertexShader );
		void SetVertexProcessing([In, Optional] ID2D1VertexBuffer? vertexBuffer, D2D1_VERTEX_OPTIONS vertexOptions,
			[In, Optional] StructPointer<D2D1_BLEND_DESCRIPTION> blendDescription, [In, Optional] StructPointer<D2D1_VERTEX_RANGE> vertexRange,
			[In, Optional] StructPointer<Guid> vertexShader);
	}

	/// <summary>
	/// <para>
	/// A specialized implementation of the Shantzis calculations to a transform implemented on the GPU. These calculations are described in
	/// the paper <c>A model for efficient and flexible image computing</c>.
	/// </para>
	/// <para>
	/// The information required to specify a “Pass” in the rendering algorithm on a Pixel Shader is passed to the implementation through
	/// the <c>SetDrawInfo</c> method.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1drawtransform
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1DrawTransform")]
	[ComImport, Guid("36bfdcb6-9739-435d-a30d-a653beff6a6f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1DrawTransform : ID2D1Transform, ID2D1TransformNode
	{
		/// <summary>Gets the number of inputs to the transform node.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>This method returns the number of inputs to this transform node.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformnode-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		new uint GetInputCount();

		/// <summary>
		/// Allows a transform to state how it would map a rectangle requested on its output to a set of sample rectangles on its input.
		/// </summary>
		/// <param name="outputRect">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle from which the inputs must be mapped.</para>
		/// </param>
		/// <param name="inputRects">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The corresponding set of inputs. The inputs will directly correspond to the transform inputs.</para>
		/// </param>
		/// <param name="inputRectsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of inputs specified. <c>Direct2D</c> guarantees that this is equal to the number of inputs specified on the transform.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform implementation must ensure that any pixel shader or software callback implementation it provides honors this calculation.
		/// </para>
		/// <para>
		/// The transform implementation must regard this method as purely functional. It can base the mapped input and output rectangles on
		/// its current state as specified by the encapsulating effect properties. However, it must not change its own state in response to
		/// this method being invoked. The <c>Direct2D</c> renderer implementation reserves the right to call this method at any time and in
		/// any sequence.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapoutputrecttoinputrects
		// HRESULT MapOutputRectToInputRects( const D2D1_RECT_L *outputRect, [out] D2D1_RECT_L *inputRects, UINT32 inputRectsCount );
		new void MapOutputRectToInputRects(in RECT outputRect, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputRects,
			int inputRectsCount);

		/// <summary>Performs the inverse mapping to <c>MapOutputRectToInputRects</c>.</summary>
		/// <param name="inputRects">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>
		/// An array of input rectangles to be mapped to the output rectangle. The <i>inputRects</i> parameter is always equal to the input bounds.
		/// </para>
		/// </param>
		/// <param name="inputOpaqueSubRects">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>An array of input rectangles to be mapped to the opaque output rectangle.</para>
		/// </param>
		/// <param name="inputRectCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of inputs specified. The implementation guarantees that this is equal to the number of inputs specified on the transform.
		/// </para>
		/// </param>
		/// <param name="outputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle that maps to the corresponding input rectangle.</para>
		/// </param>
		/// <param name="outputOpaqueSubRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle that maps to the corresponding opaque input rectangle.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform implementation must ensure that any pixel shader or software callback implementation it provides honors this calculation.
		/// </para>
		/// <para>
		/// Unlike the <c>MapOutputRectToInputRects</c> and <c>MapInvalidRect</c> functions, this method is explicitly called by the
		/// renderer at a determined place in its rendering algorithm. The transform implementation may change its state based on the input
		/// rectangles and use this information to control its rendering information. This method is always called before the
		/// <b>MapInvalidRect</b> and <b>MapOutputRectToInputRects</b> methods of the transform.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapinputrectstooutputrect
		// HRESULT MapInputRectsToOutputRect( [in] const D2D1_RECT_L *inputRects, [in] const D2D1_RECT_L *inputOpaqueSubRects, UINT32
		// inputRectCount, D2D1_RECT_L *outputRect, D2D1_RECT_L *outputOpaqueSubRect );
		new void MapInputRectsToOutputRect([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputRects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputOpaqueSubRects, int inputRectCount,
			out RECT outputRect, out RECT outputOpaqueSubRect);

		/// <summary>Sets the input rectangles for this rendering pass into the transform.</summary>
		/// <param name="inputIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the input rectangle.</para>
		/// </param>
		/// <param name="invalidInputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c></b></para>
		/// <para>The invalid input rectangle.</para>
		/// </param>
		/// <param name="invalidOutputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle to which the input rectangle must be mapped.</para>
		/// </param>
		/// <remarks>
		/// The transform implementation must regard <b>MapInvalidRect</b> as purely functional. The transform implementation can base the
		/// mapped input rectangle on the transform implementation's current state as specified by the encapsulating effect properties. But
		/// the transform implementation can't change its own state in response to a call to <b>MapInvalidRect</b>. Direct2D can call this
		/// method at any time and in any sequence following a call to the <c>MapInputRectsToOutputRect</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapinvalidrect HRESULT
		// MapInvalidRect( UINT32 inputIndex, D2D1_RECT_L invalidInputRect, [out] D2D1_RECT_L *invalidOutputRect );
		new void MapInvalidRect(uint inputIndex, RECT invalidInputRect, out RECT invalidOutputRect);

		/// <summary>Provides the GPU render info interface to the transform implementation.</summary>
		/// <param name="drawInfo">
		/// <para>Type: <b><c>ID2D1DrawInfo</c>*</b></para>
		/// <para>The interface supplied back to the calling method to allow it to specify the GPU based transform pass.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform can maintain a reference to this interface for its lifetime. If any properties change on the transform, it can
		/// apply these changes to the corresponding <i>drawInfo</i> interface.
		/// </para>
		/// <para>This is also used to determine that the corresponding nodes in the graph are dirty.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1drawtransform-setdrawinfo HRESULT
		// SetDrawInfo( [in] ID2D1DrawInfo *drawInfo );
		void SetDrawInfo([In] ID2D1DrawInfo drawInfo);
	}

	/// <summary>Provides factory methods and other state management for effect and transform authors.</summary>
	/// <remarks>
	/// <para>
	/// This interface is passed to an effect implementation through the <c>ID2D1EffectImpl::Initialize</c> method. In order to prevent
	/// applications casually gaining access to this interface, and to separate reference counts between the public and private interfaces,
	/// it is not possible to call <c>QueryInterface</c> between the <c>ID2D1DeviceContext</c> and the <b>ID2D1EffectContext</b>.
	/// </para>
	/// <para>
	/// Each call to <c>ID2D1Effect::Initialize</c> will be provided a different <b>ID2D1EffectContext</b> interface. This interface tracks
	/// resource allocations for the effect. When the effect is released, the corresponding allocations will also be released.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1effectcontext
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1EffectContext")]
	[ComImport, Guid("3d9f916b-27dc-4ad7-b4f1-64945340f563"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1EffectContext
	{
		/// <summary>Gets the unit mapping that an effect will use for properties that could be in either dots per inch (dpi) or pixels.</summary>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The dpi on the x-axis.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The dpi on the y-axis.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the <c>D2D1_UNIT_MODE</c> is <b>D2D1_UNIT_MODE_PIXELS</b>, both <i>dpiX</i> and <i>dpiY</i> will be set to 96.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-getdpi void GetDpi(
		// [out] FLOAT *dpiX, [out] FLOAT *dpiY );
		[PreserveSig]
		void GetDpi(out float dpiX, out float dpiY);

		/// <summary>
		/// Creates a Direct2D effect for the specified class ID. This is the same as <c>ID2D1DeviceContext::CreateEffect</c> so custom
		/// effects can create other effects and wrap them in a transform.
		/// </summary>
		/// <param name="effectId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The built-in or registered effect ID to create the effect. See <c>Built-in Effects</c> for a list of effect IDs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1Effect</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the effect.</para>
		/// </returns>
		/// <remarks>
		/// The created effect does not reference count the DLL from which the effect was created. If the caller unregisters an effect while
		/// this effect is loaded, the resulting behavior is unpredictable.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createeffect HRESULT
		// CreateEffect( REFCLSID effectId, [out] ID2D1Effect **effect );
		ID2D1Effect CreateEffect(in Guid effectId);

		/// <summary>
		/// This indicates the maximum feature level from the provided list which is supported by the device. If none of the provided levels
		/// are supported, then this API fails with D2DERR_INSUFFICIENT_DEVICE_CAPABILITIES.
		/// </summary>
		/// <param name="featureLevels">
		/// <para>Type: <b>const <c>D3D_FEATURE_LEVEL</c>*</b></para>
		/// <para>The feature levels provided by the application.</para>
		/// </param>
		/// <param name="featureLevelsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The count of feature levels provided by the application</para>
		/// </param>
		/// <param name="maximumSupportedFeatureLevel">
		/// <para>Type: <b><c>D3D_FEATURE_LEVEL</c>*</b></para>
		/// <para>The maximum feature level from the <i>featureLevels</i> list which is supported by the D2D device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>The method returns an <b>HRESULT</b>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>Direct2D could not allocate sufficient memory to complete the call.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed to the returning function.</description>
		/// </item>
		/// <item>
		/// <description>D2DERR_INSUFFICIENT_DEVICE_CAPABILITIES</description>
		/// <description>None of the provided levels are supported.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-getmaximumsupportedfeaturelevel
		// HRESULT GetMaximumSupportedFeatureLevel( [in] const D3D_FEATURE_LEVEL *featureLevels, UINT32 featureLevelsCount, [out]
		// D3D_FEATURE_LEVEL *maximumSupportedFeatureLevel );
		[PreserveSig]
		HRESULT GetMaximumSupportedFeatureLevel([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D_FEATURE_LEVEL[] featureLevels,
			int featureLevelsCount, out D3D_FEATURE_LEVEL maximumSupportedFeatureLevel);

		/// <summary>
		/// Wraps an effect graph into a single transform node and then inserted into a transform graph. This allows an effect to aggregate
		/// other effects. This will typically be done in order to allow the effect properties to be re-expressed with a different contract,
		/// or to allow different components to integrate each-other’s effects.
		/// </summary>
		/// <param name="effect">
		/// <para>Type: <b><c>ID2D1Effect</c>*</b></para>
		/// <para>The effect to be wrapped in a transform node.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1TransformNode</c>**</b></para>
		/// <para>The returned transform node that encapsulates the effect graph.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createtransformnodefromeffect
		// HRESULT CreateTransformNodeFromEffect( [in] ID2D1Effect *effect, [out] ID2D1TransformNode **transformNode );
		ID2D1TransformNode CreateTransformNodeFromEffect([In] ID2D1Effect effect);

		/// <summary>This creates a blend transform that can be inserted into a transform graph.</summary>
		/// <param name="numInputs">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of inputs to the blend transform.</para>
		/// </param>
		/// <param name="blendDescription">
		/// <para>Type: <b>const <c>D2D1_BLEND_DESCRIPTION</c>*</b></para>
		/// <para>Describes the blend transform that is to be created.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1BlendTransform</c>**</b></para>
		/// <para>The returned blend transform.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createblendtransform
		// HRESULT CreateBlendTransform( UINT32 numInputs, [in] const D2D1_BLEND_DESCRIPTION *blendDescription, [out] ID2D1BlendTransform
		// **transform );
		ID2D1BlendTransform CreateBlendTransform(uint numInputs, in D2D1_BLEND_DESCRIPTION blendDescription);

		/// <summary>Creates a transform that extends its input infinitely in every direction based on the passed in extend mode.</summary>
		/// <param name="extendModeX">
		/// <para>Type: <b><c>D2D1_EXTEND_MODE</c></b></para>
		/// <para>The extend mode in the X-axis direction.</para>
		/// </param>
		/// <param name="extendModeY">
		/// <para>Type: <b><c>D2D1_EXTEND_MODE</c></b></para>
		/// <para>The extend mode in the Y-axis direction.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1BorderTransform</c>**</b></para>
		/// <para>The returned transform.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createbordertransform
		// HRESULT CreateBorderTransform( D2D1_EXTEND_MODE extendModeX, D2D1_EXTEND_MODE extendModeY, [out] ID2D1BorderTransform **transform );
		ID2D1BorderTransform CreateBorderTransform(D2D1_EXTEND_MODE extendModeX, D2D1_EXTEND_MODE extendModeY);

		/// <summary>Creates and returns an offset transform.</summary>
		/// <param name="offset">
		/// <para>Type: <b><c>D2D1_POINT_2L</c></b></para>
		/// <para>The offset amount.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1OffsetTransform</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to an offset transform object.</para>
		/// </returns>
		/// <remarks>
		/// An offset transform is used to offset an input bitmap without having to insert a rendering pass. An offset transform is
		/// automatically inserted by an Affine transform if the transform evaluates to a pixel-aligned transform.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createoffsettransform
		// HRESULT CreateOffsetTransform( D2D1_POINT_2L offset, [out] ID2D1OffsetTransform **transform );
		ID2D1OffsetTransform CreateOffsetTransform(POINT offset);

		/// <summary>Creates and returns a bounds adjustment transform.</summary>
		/// <param name="outputRectangle">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>The initial output rectangle for the bounds adjustment transform.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1BoundsAdjustmentTransform</c>**</b></para>
		/// <para>The returned bounds adjustment transform.</para>
		/// </returns>
		/// <remarks>
		/// <para>A support transform can be used for two different reasons.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// To indicate that a region of its input image is already transparent black. This can increase efficiency for rendering bitmaps.
		/// </description>
		/// </item>
		/// <item>
		/// <description>To increase the size of the input image. The expanded area will be treated as transparent black</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createboundsadjustmenttransform
		// HRESULT CreateBoundsAdjustmentTransform( [in] const D2D1_RECT_L *outputRectangle, [out] ID2D1BoundsAdjustmentTransform
		// **transform );
		ID2D1BoundsAdjustmentTransform CreateBoundsAdjustmentTransform(in RECT outputRectangle);

		/// <summary>
		/// Loads the given shader by its unique ID. Loading the shader multiple times is ignored. When the shader is loaded it is also
		/// handed to the driver to JIT, if it hasn’t been already.
		/// </summary>
		/// <param name="shaderId">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>The unique id that identifies the shader.</para>
		/// </param>
		/// <param name="shaderBuffer">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>The buffer that contains the shader to register.</para>
		/// </param>
		/// <param name="shaderBufferCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the shader buffer in bytes.</para>
		/// </param>
		/// <remarks>The shader you specify must be compiled, not in raw HLSL code.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-loadpixelshader
		// HRESULT LoadPixelShader( [in] REFGUID shaderId, [in] const BYTE *shaderBuffer, UINT32 shaderBufferCount );
		void LoadPixelShader(in Guid shaderId, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] shaderBuffer, int shaderBufferCount);

		/// <summary>
		/// Loads the given shader by its unique ID. Loading the shader multiple times is ignored. When the shader is loaded it is also
		/// handed to the driver to JIT, if it hasn’t been already.
		/// </summary>
		/// <param name="resourceId">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>The unique id that identifies the shader.</para>
		/// </param>
		/// <param name="shaderBuffer">
		/// <para>Type: <b>BYTE*</b></para>
		/// <para>The buffer that contains the shader to register.</para>
		/// </param>
		/// <param name="shaderBufferCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the shader buffer in bytes.</para>
		/// </param>
		/// <remarks>The shader you specify must be compiled, not in raw HLSL code.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-loadvertexshader
		// HRESULT LoadVertexShader( REFGUID resourceId, const BYTE *shaderBuffer, UINT32 shaderBufferCount );
		void LoadVertexShader(in Guid resourceId, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] shaderBuffer, int shaderBufferCount);

		/// <summary>
		/// Loads the given shader by its unique ID. Loading the shader multiple times is ignored. When the shader is loaded it is also
		/// handed to the driver to JIT, if it hasn’t been already.
		/// </summary>
		/// <param name="resourceId">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>The unique id that identifies the shader.</para>
		/// </param>
		/// <param name="shaderBuffer">
		/// <para>Type: <b>BYTE*</b></para>
		/// <para>The buffer that contains the shader to register.</para>
		/// </param>
		/// <param name="shaderBufferCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the shader buffer in bytes.</para>
		/// </param>
		/// <remarks>The shader you specify must be compiled, not in raw HLSL code.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-loadcomputeshader
		// HRESULT LoadComputeShader( REFGUID resourceId, const BYTE *shaderBuffer, UINT32 shaderBufferCount );
		void LoadComputeShader(in Guid resourceId, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] shaderBuffer, int shaderBufferCount);

		/// <summary>This tests to see if the given shader is loaded.</summary>
		/// <param name="shaderId">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>The unique id that identifies the shader.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Whether the shader is loaded.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-isshaderloaded BOOL
		// IsShaderLoaded( REFGUID shaderId );
		[PreserveSig]
		bool IsShaderLoaded(in Guid shaderId);

		/// <summary>
		/// Creates or finds the given resource texture, depending on whether a resource id is specified. It also optionally initializes the
		/// texture with the specified data.
		/// </summary>
		/// <param name="resourceId">
		/// <para>Type: <b>const GUID*</b></para>
		/// <para>An optional pointer to the unique id that identifies the lookup table.</para>
		/// </param>
		/// <param name="resourceTextureProperties">
		/// <para>Type: <b>const <c>D2D1_RESOURCE_TEXTURE_PROPERTIES</c>*</b></para>
		/// <para>The properties used to create the resource texture.</para>
		/// </param>
		/// <param name="data">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>The optional data to be loaded into the resource texture.</para>
		/// </param>
		/// <param name="strides">
		/// <para>Type: <b>const UINT32*</b></para>
		/// <para>An optional pointer to the stride to advance through the resource texture, according to dimension.</para>
		/// </param>
		/// <param name="dataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size, in bytes, of the data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1ResourceTexture</c>**</b></para>
		/// <para>The returned texture that can be used as a resource in a Direct2D effect.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createresourcetexture
		// HRESULT CreateResourceTexture( [in, optional] const GUID *resourceId, [in] const D2D1_RESOURCE_TEXTURE_PROPERTIES
		// *resourceTextureProperties, [in, optional] const BYTE *data, [in, optional] const UINT32 *strides, UINT32 dataSize, [out]
		// ID2D1ResourceTexture **resourceTexture );
		ID2D1ResourceTexture CreateResourceTexture([In, Optional] GuidPtr resourceId, in D2D1_RESOURCE_TEXTURE_PROPERTIES resourceTextureProperties,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[]? data,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[]? strides, [Optional] int dataSize);

		/// <summary>
		/// Finds the given resource texture if it has already been created with <c>ID2D1EffectContext::CreateResourceTexture</c> with the
		/// same GUID.
		/// </summary>
		/// <param name="resourceId">
		/// <para>Type: <b>const GUID*</b></para>
		/// <para>The unique id that identifies the resource texture.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1ResourceTexture</c>**</b></para>
		/// <para>The returned texture that can be used as a resource in a Direct2D effect.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-findresourcetexture
		// HRESULT FindResourceTexture( [in] const GUID *resourceId, [out] ID2D1ResourceTexture **resourceTexture );
		ID2D1ResourceTexture FindResourceTexture(in Guid resourceId);

		/// <summary>
		/// Creates a vertex buffer or finds a standard vertex buffer and optionally initializes it with vertices. The returned buffer can
		/// be specified in the render info to specify both a vertex shader and or to pass custom vertices to the standard vertex shader
		/// used by <c>Direct2D</c>.
		/// </summary>
		/// <param name="vertexBufferProperties">
		/// <para>Type: <b>const <c>D2D1_VERTEX_BUFFER_PROPERTIES</c>*</b></para>
		/// <para>The properties used to describe the vertex buffer and vertex shader.</para>
		/// </param>
		/// <param name="resourceId">
		/// <para>Type: <b>const GUID*</b></para>
		/// <para>The unique id that identifies the vertex buffer.</para>
		/// </param>
		/// <param name="customVertexBufferProperties">
		/// <para>Type: <b>const <c>D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES</c>*</b></para>
		/// <para>
		/// The properties used to define a custom vertex buffer. If you use a built-in vertex shader, you don't have to specify this property.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1VertexBuffer</c>**</b></para>
		/// <para>The returned vertex buffer.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createvertexbuffer
		// HRESULT CreateVertexBuffer( [in] const D2D1_VERTEX_BUFFER_PROPERTIES *vertexBufferProperties, [in, optional] const GUID
		// *resourceId, [in, optional] const D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES *customVertexBufferProperties, [out] ID2D1VertexBuffer
		// **buffer );
		ID2D1VertexBuffer CreateVertexBuffer(in D2D1_VERTEX_BUFFER_PROPERTIES vertexBufferProperties, [In, Optional] GuidPtr resourceId,
			[In, Optional] StructPointer<D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES> customVertexBufferProperties);

		/// <summary>
		/// This finds the given vertex buffer if it has already been created with <c>ID2D1EffectContext::CreateVertexBuffer</c> with the
		/// same GUID.
		/// </summary>
		/// <param name="resourceId">
		/// <para>Type: <b>const GUID*</b></para>
		/// <para>The unique id that identifies the vertex buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1VertexBuffer</c>**</b></para>
		/// <para>The returned vertex buffer that can be used as a resource in a <c>Direct2D</c> effect.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-findvertexbuffer
		// HRESULT FindVertexBuffer( [in] const GUID *resourceId, [out] ID2D1VertexBuffer **buffer );
		ID2D1VertexBuffer FindVertexBuffer(in Guid resourceId);

		/// <summary>
		/// <para>Creates a color context from a color space.</para>
		/// <para>If the color space is Custom, the context is initialized from the <i>profile</i> and <i>profileSize</i> parameters.</para>
		/// <para>
		/// If the color space is not Custom, the context is initialized with the profile bytes associated with the color space. The
		/// <i>profile</i> and <i>profileSize</i> parameters are ignored.
		/// </para>
		/// </summary>
		/// <param name="space">
		/// <para>Type: <b><c>D2D1_COLOR_SPACE</c></b></para>
		/// <para>The space of color context to create.</para>
		/// </param>
		/// <param name="profile">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>
		/// A buffer containing the ICC profile bytes used to initialize the color context when <i>space</i> is
		/// <c>D2D1_COLOR_SPACE_CUSTOM</c>. For other types, the parameter is ignored and should be set to <b>NULL</b>.
		/// </para>
		/// </param>
		/// <param name="profileSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size in bytes of <i>Profile</i>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1ColorContext</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createcolorcontext
		// HRESULT CreateColorContext( D2D1_COLOR_SPACE space, [in, optional] const BYTE *profile, UINT32 profileSize, [out]
		// ID2D1ColorContext **colorContext );
		ID2D1ColorContext CreateColorContext(D2D1_COLOR_SPACE space, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[]? profile,
			[Optional] int profileSize);

		/// <summary>
		/// Creates a color context by loading it from the specified filename. The profile bytes are the contents of the file specified by <i>filename</i>.
		/// </summary>
		/// <param name="filename">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The path to the file containing the profile bytes to initialize the color context with.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1ColorContext</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createcolorcontextfromfilename
		// HRESULT CreateColorContextFromFilename( PCWSTR filename, [out] ID2D1ColorContext **colorContext );
		ID2D1ColorContext CreateColorContextFromFilename([MarshalAs(UnmanagedType.LPWStr)] string filename);

		/// <summary>
		/// Creates a color context from an <c>IWICColorContext</c>. The <c>D2D1ColorContext</c> space of the resulting context varies, see
		/// Remarks for more info.
		/// </summary>
		/// <param name="wicColorContext">
		/// <para>Type: <b><c>IWICColorContext</c>*</b></para>
		/// <para>The <c>IWICColorContext</c> used to initialize the color context.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1ColorContext</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context.</para>
		/// </returns>
		/// <remarks>
		/// The new color context can be used in <c>D2D1_BITMAP_PROPERTIES1</c> to initialize the color context of a created bitmap. The
		/// model field of the profile header is inspected to determine whether this profile is sRGB or scRGB and the color space is updated
		/// respectively. Otherwise the space is custom.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createcolorcontextfromwiccolorcontext
		// HRESULT CreateColorContextFromWicColorContext( [in] IWICColorContext *wicColorContext, [out] ID2D1ColorContext **colorContext );
		ID2D1ColorContext CreateColorContextFromWicColorContext([In] IWICColorContext wicColorContext);

		/// <summary>This indicates whether an optional capability is supported by the D3D device.</summary>
		/// <param name="feature">
		/// <para>Type: <b><c>D2D1_FEATURE</c></b></para>
		/// <para>The feature to query support for.</para>
		/// </param>
		/// <param name="featureSupportData">
		/// <para>Type: <b>void*</b></para>
		/// <para>A structure indicating information about how or if the feature is supported.</para>
		/// </param>
		/// <param name="featureSupportDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the <i>featureSupportData</i> parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>The method returns an <b>HRESULT</b>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>Direct2D could not allocate sufficient memory to complete the call.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed to the returning function.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-checkfeaturesupport
		// HRESULT CheckFeatureSupport( D2D1_FEATURE feature, [out] void *featureSupportData, [out] UINT32 featureSupportDataSize );
		[PreserveSig]
		HRESULT CheckFeatureSupport(D2D1_FEATURE feature, IntPtr featureSupportData, uint featureSupportDataSize);

		/// <summary>Indicates whether the buffer precision is supported by the underlying Direct2D <c>device.</c></summary>
		/// <param name="bufferPrecision">
		/// <para>Type: <b><c>D2D1_BUFFER_PRECISION</c></b></para>
		/// <para>The buffer precision to check.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns TRUE if the buffer precision is supported. Returns FALSE if the buffer precision is not supported.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-isbufferprecisionsupported
		// BOOL IsBufferPrecisionSupported( D2D1_BUFFER_PRECISION bufferPrecision );
		[PreserveSig]
		bool IsBufferPrecisionSupported(D2D1_BUFFER_PRECISION bufferPrecision);
	}

	/// <summary>Allows a custom effect's interface and behavior to be specified by the effect author.</summary>
	/// <remarks>
	/// This interface is created by the effect author from a static factory registered through the <c>ID2D1Factory::RegisterEffect</c> method.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1effectimpl
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1EffectImpl")]
	[ComImport, Guid("a248fd3f-3e6c-4e63-9f03-7f68ecc91db9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1EffectImpl
	{
		/// <summary>
		/// The effect can use this method to do one time initialization tasks. If this method is not needed, the method can just return <b>S_OK</b>.
		/// </summary>
		/// <param name="effectContext">
		/// <para>Type: <b><c>ID2D1EffectContext</c>*</b></para>
		/// <para>An internal context interface that creates and returns effect author–centric types.</para>
		/// </param>
		/// <param name="transformGraph">
		/// <para>Type: <b><c>ID2D1TransformGraph</c>*</b></para>
		/// <para>The effect can populate the transform graph with a topology and can update it later.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If the method succeeds, it returns <b>S_OK</b>. If it fails, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This moves resource creation cost to the <c>CreateEffect</c> call, rather than during rendering.</para>
		/// <para>If the implementation fails this call, the corresponding <c>ID2D1DeviceContext::CreateEffect</c> call also fails.</para>
		/// <para>The following example shows an effect implementing an initialize method.</para>
		/// <para>Examples</para>
		/// <para>The example here shows an effect implementing an initialize method.</para>
		/// <para>
		/// <c>class CEffectImplementation : public ID2D1EffectImpl { public: virtual ~CEffectImplementation() { if (_pContextInternal !=
		/// NULL) { _pContextInternal-&gt;Release(); } } IFACEMETHODIMP Initialize(__in ID2D1DeviceContextInternal *pContextInternal, __in
		/// ID2D1TransformGraph *pTransformGraph) { HRESULT hr = S_OK; _pContextInternal = pContextInternal; _pContextInternal-&gt;AddRef();
		/// _pTransformGraph = pTransformGraph; _pTransformGraph&gt;AddRef(); // Populate the transform graph. return S_OK; } private:
		/// ID2D1EffectContext *_pContextInternal; ID2D1TransformGraph *_pTransformGraph; };</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectimpl-initialize HRESULT
		// Initialize( [in] ID2D1EffectContext *effectContext, [in] ID2D1TransformGraph *transformGraph );
		[PreserveSig]
		HRESULT Initialize([In] ID2D1EffectContext effectContext, [In] ID2D1TransformGraph transformGraph);

		/// <summary>Prepares an effect for the rendering process.</summary>
		/// <param name="changeType">
		/// <para>Type: <b><c>D2D1_CHANGE_TYPE</c></b></para>
		/// <para>Indicates the type of change the effect should expect.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If the method succeeds, it returns <b>S_OK</b>. If it fails, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is called by the renderer when the effect is within an effect graph that is drawn.</para>
		/// <para>The method will be called:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>If the effect has been initialized but has not previously been drawn.</description>
		/// </item>
		/// <item>
		/// <description>If an effect property has been set since the last draw call.</description>
		/// </item>
		/// <item>
		/// <description>If the context state has changed since the effect was last drawn.</description>
		/// </item>
		/// </list>
		/// <para>
		/// The method will not otherwise be called. The transforms created by the effect will be called to handle their input and output
		/// rectangles for every draw call.
		/// </para>
		/// <para>
		/// Most effects defer creating any resources or specifying a topology until this call is made. They store their properties and map
		/// them to a concrete set of rendering techniques when first drawn.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// An effect normally waits until it is rendered before snapping its current state and applying it to any transforms it has encapsulated.
		/// </para>
		/// <para>
		/// <c>class CMyTransform : public ID2D1DrawTransform { public: // Transform methods omitted. HRESULT PrepareForRender(FLOAT
		/// radius); }; class CEffectImplementation : public ID2D1EffectImpl { public: void SetRadius(FLOAT radius) { _radius = radius; }
		/// IFACEMETHODIMP PrepareForRender(D2D1_CHANGE_TYPE /*type*/) { // Send the radius to the transform and ask it to render. return
		/// _pMyTransform-&gt;PrepareForRender(_radius); } private: CMyTransform *_pMyTransform; FLOAT _radius; };</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectimpl-prepareforrender HRESULT
		// PrepareForRender( D2D1_CHANGE_TYPE changeType );
		[PreserveSig]
		HRESULT PrepareForRender(D2D1_CHANGE_TYPE changeType);

		/// <summary>
		/// <para>
		/// The renderer calls this method to provide the effect implementation with a way to specify its transform graph and transform
		/// graph changes.
		/// </para>
		/// <para>The renderer calls this method when:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>When the effect is first initialized.</description>
		/// </item>
		/// <item>
		/// <description>If the number of inputs to the effect changes.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="transformGraph">
		/// <para>Type: <b><c>ID2D1TransformGraph</c>*</b></para>
		/// <para>The graph to which the effect describes its transform topology through the SetDescription call.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>
		/// An error that prevents the effect from being initialized if called as part of the CreateEffect call. If the effect fails a
		/// subsequent SetGraph call:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The error will be returned from the property method that caused the number of inputs to the effect to change.</description>
		/// </item>
		/// <item>
		/// <description>
		/// The effect object will be placed into an error state, if subsequently used to render, the context will be placed into a
		/// temporary error state, that particular effect will fail to render and the failure will be returned on the next EndDraw or Flush call.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectimpl-setgraph HRESULT
		// SetGraph( ID2D1TransformGraph *transformGraph );
		[PreserveSig]
		HRESULT SetGraph([In] ID2D1TransformGraph transformGraph);
	}

	/// <summary>Instructs the effect-rendering system to offset an input bitmap without inserting a rendering pass.</summary>
	/// <remarks>
	/// Because a rendering pass is not required, the interface derives from a transform node. This allows it to be inserted into a graph
	/// but does not allow an output buffer to be specified.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1offsettransform
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1OffsetTransform")]
	[ComImport, Guid("3fe6adea-7643-4f53-bd14-a0ce63f24042"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1OffsetTransform : ID2D1TransformNode
	{
		/// <summary>Gets the number of inputs to the transform node.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>This method returns the number of inputs to this transform node.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformnode-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		new uint GetInputCount();

		/// <summary>Sets the offset in the current offset transform.</summary>
		/// <param name="offset">
		/// <para>Type: <b><c>D2D1_POINT_2L</c></b></para>
		/// <para>The new offset to apply to the offset transform.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1offsettransform-setoffset void
		// SetOffset( D2D1_POINT_2L offset );
		[PreserveSig]
		void SetOffset(POINT offset);

		/// <summary>Gets the offset currently in the offset transform.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_POINT_2L</c></b></para>
		/// <para>The current transform offset.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1offsettransform-getoffset
		// D2D1_POINT_2L GetOffset();
		POINT GetOffset();
	}

	/// <summary>Describes the render information common to all of the various transform implementations.</summary>
	/// <remarks>
	/// This interface is used by a transform implementation to first describe and then indicate changes to the rendering pass that
	/// corresponds to the transform.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1renderinfo
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1RenderInfo")]
	[ComImport, Guid("519ae1bd-d19a-420d-b849-364f594776b7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1RenderInfo
	{
		/// <summary>Sets how a specific input to the transform should be handled by the renderer in terms of sampling.</summary>
		/// <param name="inputIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the input that will have the input description applied.</para>
		/// </param>
		/// <param name="inputDescription">
		/// <para>Type: <b><c>D2D1_INPUT_DESCRIPTION</c></b></para>
		/// <para>The description of the input to be applied to the transform.</para>
		/// </param>
		/// <remarks>The input description must be matched correctly by the effect shader code.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setinputdescription
		// HRESULT SetInputDescription( UINT32 inputIndex, D2D1_INPUT_DESCRIPTION inputDescription );
		void SetInputDescription(uint inputIndex, D2D1_INPUT_DESCRIPTION inputDescription);

		/// <summary>
		/// Allows a caller to control the output precision and channel-depth of the transform in which the render information is encapsulated.
		/// </summary>
		/// <param name="bufferPrecision">
		/// <para>Type: <b><c>D2D1_BUFFER_PRECISION</c></b></para>
		/// <para>The type of buffer that should be used as an output from this transform.</para>
		/// </param>
		/// <param name="channelDepth">
		/// <para>Type: <b><c>D2D1_CHANNEL_DEPTH</c></b></para>
		/// <para>The number of channels that will be used on the output buffer.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If the output precision of the transform is not specified, then it will default to the precision specified on the Direct2D
		/// device context. The maximum of 16bpc <b>UNORM</b> and 16bpc <b>FLOAT</b> is 32bpc <b>FLOAT</b>.
		/// </para>
		/// <para>The output channel depth will match the maximum of the input channel depths if the channel depth is <b>D2D1_CHANNEL_DEPTH_DEFAULT</b>.</para>
		/// <para>There is no global output channel depth, this is always left to the control of the transforms.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setoutputbuffer HRESULT
		// SetOutputBuffer( D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth );
		void SetOutputBuffer(D2D1_BUFFER_PRECISION bufferPrecision, D2D1_CHANNEL_DEPTH channelDepth);

		/// <summary>Specifies that the output of the transform in which the render information is encapsulated is or is not cached.</summary>
		/// <param name="isCached">
		/// <para>Type: <b>BOOL</b></para>
		/// <para><b>TRUE</b> if the output of the transform is cached; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setcached void
		// SetCached( BOOL isCached );
		[PreserveSig]
		void SetCached(bool isCached);

		/// <summary>Provides an estimated hint of shader execution cost to D2D.</summary>
		/// <param name="instructionCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>An approximate instruction count of the associated shader.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The instruction count may be set according to the number of instructions in the shader. This information is used as a hint when
		/// rendering extremely large images. Calling this API is optional, but it may improve performance if you provide an accurate number.
		/// </para>
		/// <para><b>Note</b>  Instructions that occur in a loop should be counted according to the number of loop iterations.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1renderinfo-setinstructioncounthint
		// void SetInstructionCountHint( UINT32 instructionCount );
		[PreserveSig]
		void SetInstructionCountHint(uint instructionCount);
	}

	/// <summary>Tracks a transform-created resource texture.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1resourcetexture
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1ResourceTexture")]
	[ComImport, Guid("688d15c3-02b0-438d-b13a-d1b44c32c39a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1ResourceTexture
	{
		/// <summary>Updates the specific resource texture inside the specific range or box using the supplied data.</summary>
		/// <param name="minimumExtents">
		/// <para>Type: <b>const UINT32*</b></para>
		/// <para>The "left" extent of the updates if specified; if <b>NULL</b>, the entire texture is updated.</para>
		/// </param>
		/// <param name="maximimumExtents">
		/// <para>Type: <b>const UINT32*</b></para>
		/// <para>The "right" extent of the updates if specified; if <b>NULL</b>, the entire texture is updated.</para>
		/// </param>
		/// <param name="strides">
		/// <para>Type: <b>const UINT32*</b></para>
		/// <para>The stride to advance through the input data, according to dimension.</para>
		/// </param>
		/// <param name="dimensions">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of dimensions in the resource texture. This must match the number used to load the texture.</para>
		/// </param>
		/// <param name="data">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>The data to be placed into the resource texture.</para>
		/// </param>
		/// <param name="dataCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the data buffer to be used to update the resource texture.</para>
		/// </param>
		/// <remarks>The number of dimensions in the update must match those of the created texture.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1resourcetexture-update HRESULT
		// Update( [in, optional] const UINT32 *minimumExtents, [in, optional] const UINT32 *maximimumExtents, [in] const UINT32 *strides,
		// UINT32 dimensions, [in] const BYTE *data, UINT32 dataCount );
		void Update([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] uint[]? minimumExtents,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] uint[]? maximimumExtents,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] uint[]? strides, int dimensions,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] data, int dataCount);
	}

	/// <summary>Represents a CPU-based rasterization stage in the transform pipeline graph.</summary>
	/// <remarks>
	/// <b>ID2D1SourceTransform</b> specializes an implementation of the Shantzis calculations to a transform implemented as the source of
	/// an effect graph with the data being provided from sytem memory.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1sourcetransform
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1SourceTransform")]
	[ComImport, Guid("db1800dd-0c34-4cf9-be90-31cc0a5653e1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SourceTransform : ID2D1Transform, ID2D1TransformNode
	{
		/// <summary>Gets the number of inputs to the transform node.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>This method returns the number of inputs to this transform node.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformnode-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		new uint GetInputCount();

		/// <summary>
		/// Allows a transform to state how it would map a rectangle requested on its output to a set of sample rectangles on its input.
		/// </summary>
		/// <param name="outputRect">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle from which the inputs must be mapped.</para>
		/// </param>
		/// <param name="inputRects">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The corresponding set of inputs. The inputs will directly correspond to the transform inputs.</para>
		/// </param>
		/// <param name="inputRectsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of inputs specified. <c>Direct2D</c> guarantees that this is equal to the number of inputs specified on the transform.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform implementation must ensure that any pixel shader or software callback implementation it provides honors this calculation.
		/// </para>
		/// <para>
		/// The transform implementation must regard this method as purely functional. It can base the mapped input and output rectangles on
		/// its current state as specified by the encapsulating effect properties. However, it must not change its own state in response to
		/// this method being invoked. The <c>Direct2D</c> renderer implementation reserves the right to call this method at any time and in
		/// any sequence.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapoutputrecttoinputrects
		// HRESULT MapOutputRectToInputRects( const D2D1_RECT_L *outputRect, [out] D2D1_RECT_L *inputRects, UINT32 inputRectsCount );
		new void MapOutputRectToInputRects(in RECT outputRect, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputRects,
			int inputRectsCount);

		/// <summary>Performs the inverse mapping to <c>MapOutputRectToInputRects</c>.</summary>
		/// <param name="inputRects">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>
		/// An array of input rectangles to be mapped to the output rectangle. The <i>inputRects</i> parameter is always equal to the input bounds.
		/// </para>
		/// </param>
		/// <param name="inputOpaqueSubRects">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>An array of input rectangles to be mapped to the opaque output rectangle.</para>
		/// </param>
		/// <param name="inputRectCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of inputs specified. The implementation guarantees that this is equal to the number of inputs specified on the transform.
		/// </para>
		/// </param>
		/// <param name="outputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle that maps to the corresponding input rectangle.</para>
		/// </param>
		/// <param name="outputOpaqueSubRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle that maps to the corresponding opaque input rectangle.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform implementation must ensure that any pixel shader or software callback implementation it provides honors this calculation.
		/// </para>
		/// <para>
		/// Unlike the <c>MapOutputRectToInputRects</c> and <c>MapInvalidRect</c> functions, this method is explicitly called by the
		/// renderer at a determined place in its rendering algorithm. The transform implementation may change its state based on the input
		/// rectangles and use this information to control its rendering information. This method is always called before the
		/// <b>MapInvalidRect</b> and <b>MapOutputRectToInputRects</b> methods of the transform.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapinputrectstooutputrect
		// HRESULT MapInputRectsToOutputRect( [in] const D2D1_RECT_L *inputRects, [in] const D2D1_RECT_L *inputOpaqueSubRects, UINT32
		// inputRectCount, D2D1_RECT_L *outputRect, D2D1_RECT_L *outputOpaqueSubRect );
		new void MapInputRectsToOutputRect([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputRects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputOpaqueSubRects, int inputRectCount,
			out RECT outputRect, out RECT outputOpaqueSubRect);

		/// <summary>Sets the input rectangles for this rendering pass into the transform.</summary>
		/// <param name="inputIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the input rectangle.</para>
		/// </param>
		/// <param name="invalidInputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c></b></para>
		/// <para>The invalid input rectangle.</para>
		/// </param>
		/// <param name="invalidOutputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle to which the input rectangle must be mapped.</para>
		/// </param>
		/// <remarks>
		/// The transform implementation must regard <b>MapInvalidRect</b> as purely functional. The transform implementation can base the
		/// mapped input rectangle on the transform implementation's current state as specified by the encapsulating effect properties. But
		/// the transform implementation can't change its own state in response to a call to <b>MapInvalidRect</b>. Direct2D can call this
		/// method at any time and in any sequence following a call to the <c>MapInputRectsToOutputRect</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapinvalidrect HRESULT
		// MapInvalidRect( UINT32 inputIndex, D2D1_RECT_L invalidInputRect, [out] D2D1_RECT_L *invalidOutputRect );
		new void MapInvalidRect(uint inputIndex, RECT invalidInputRect, out RECT invalidOutputRect);

		/// <summary>Sets the render information for the transform.</summary>
		/// <param name="renderInfo">
		/// <para>Type: <b><c>ID2D1RenderInfo</c>*</b></para>
		/// <para>The interface supplied to the transform to allow specifying the CPU based transform pass.</para>
		/// </param>
		/// <remarks>Provides a render information interface to the source transform to allow it to specify state to the rendering system.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1sourcetransform-setrenderinfo
		// HRESULT SetRenderInfo( [in] ID2D1RenderInfo *renderInfo );
		void SetRenderInfo(ID2D1RenderInfo renderInfo);

		/// <summary>Draws the transform to the graphics processing unit (GPU)–based Direct2D pipeline.</summary>
		/// <param name="target">
		/// <para>Type: <b><c>ID2D1Bitmap1</c>*</b></para>
		/// <para>The target to which the transform should be written.</para>
		/// </param>
		/// <param name="drawRect">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>The area within the source from which the image should be drawn.</para>
		/// </param>
		/// <param name="targetOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2U</c></b></para>
		/// <para>The origin within the target bitmap to which the source data should be drawn.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The implementation of the rasterizer guarantees that adding the <i>renderRect</i> to the <i>targetOrigin</i> does not exceed the
		/// bounds of the bitmap.
		/// </para>
		/// <para>When implementing this method you must update the bitmap in this way:</para>
		/// <list type="number">
		/// <item>
		/// <description>Call the <c>ID2D1Bitmap::Map</c> method with the D2D1_MAP_OPTIONS_DISCARD and D2D1_MAP_OPTIONS_WRITE flags.</description>
		/// </item>
		/// <item>
		/// <description>Update the buffer this method returns.</description>
		/// </item>
		/// <item>
		/// <description>Call the <c>ID2D1Bitmap::Unmap</c> method.</description>
		/// </item>
		/// </list>
		/// <para>
		/// If you set the buffer precision manually on the associated <c>ID2D1RenderInfo</c> object, it must handle different pixel formats
		/// in this method by calling <c>ID2D1Bitmap::GetPixelFormat</c>. If you set the buffer precision manually, then you can rely on
		/// that format always being the one you provided.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1sourcetransform-draw HRESULT Draw(
		// [in] ID2D1Bitmap1 *target, [in] const D2D1_RECT_L *drawRect, D2D1_POINT_2U targetOrigin );
		void Draw([In] ID2D1Bitmap1 target, in RECT drawRect, D2D_POINT_2U targetOrigin);
	}

	/// <summary>Represents the base interface for all of the transforms implemented by the transform author.</summary>
	/// <remarks>
	/// Transforms are aggregated by effect authors. This interface provides a common interface for implementing the Shantzis rectangle
	/// calculations which is the basis for all the transform processing in Direct2D imaging extensions. These calculations are described in
	/// the paper <c>A model for efficient and flexible image computing</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1transform
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1Transform")]
	[ComImport, Guid("ef1a287d-342a-4f76-8fdb-da0d6ea9f92b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Transform : ID2D1TransformNode
	{
		/// <summary>Gets the number of inputs to the transform node.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>This method returns the number of inputs to this transform node.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformnode-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		new uint GetInputCount();

		/// <summary>
		/// Allows a transform to state how it would map a rectangle requested on its output to a set of sample rectangles on its input.
		/// </summary>
		/// <param name="outputRect">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle from which the inputs must be mapped.</para>
		/// </param>
		/// <param name="inputRects">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The corresponding set of inputs. The inputs will directly correspond to the transform inputs.</para>
		/// </param>
		/// <param name="inputRectsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of inputs specified. <c>Direct2D</c> guarantees that this is equal to the number of inputs specified on the transform.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform implementation must ensure that any pixel shader or software callback implementation it provides honors this calculation.
		/// </para>
		/// <para>
		/// The transform implementation must regard this method as purely functional. It can base the mapped input and output rectangles on
		/// its current state as specified by the encapsulating effect properties. However, it must not change its own state in response to
		/// this method being invoked. The <c>Direct2D</c> renderer implementation reserves the right to call this method at any time and in
		/// any sequence.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapoutputrecttoinputrects
		// HRESULT MapOutputRectToInputRects( const D2D1_RECT_L *outputRect, [out] D2D1_RECT_L *inputRects, UINT32 inputRectsCount );
		void MapOutputRectToInputRects(in RECT outputRect, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputRects,
			int inputRectsCount);

		/// <summary>Performs the inverse mapping to <c>MapOutputRectToInputRects</c>.</summary>
		/// <param name="inputRects">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>
		/// An array of input rectangles to be mapped to the output rectangle. The <i>inputRects</i> parameter is always equal to the input bounds.
		/// </para>
		/// </param>
		/// <param name="inputOpaqueSubRects">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>An array of input rectangles to be mapped to the opaque output rectangle.</para>
		/// </param>
		/// <param name="inputRectCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of inputs specified. The implementation guarantees that this is equal to the number of inputs specified on the transform.
		/// </para>
		/// </param>
		/// <param name="outputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle that maps to the corresponding input rectangle.</para>
		/// </param>
		/// <param name="outputOpaqueSubRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle that maps to the corresponding opaque input rectangle.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform implementation must ensure that any pixel shader or software callback implementation it provides honors this calculation.
		/// </para>
		/// <para>
		/// Unlike the <c>MapOutputRectToInputRects</c> and <c>MapInvalidRect</c> functions, this method is explicitly called by the
		/// renderer at a determined place in its rendering algorithm. The transform implementation may change its state based on the input
		/// rectangles and use this information to control its rendering information. This method is always called before the
		/// <b>MapInvalidRect</b> and <b>MapOutputRectToInputRects</b> methods of the transform.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapinputrectstooutputrect
		// HRESULT MapInputRectsToOutputRect( [in] const D2D1_RECT_L *inputRects, [in] const D2D1_RECT_L *inputOpaqueSubRects, UINT32
		// inputRectCount, D2D1_RECT_L *outputRect, D2D1_RECT_L *outputOpaqueSubRect );
		void MapInputRectsToOutputRect([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputRects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] inputOpaqueSubRects, int inputRectCount,
			out RECT outputRect, out RECT outputOpaqueSubRect);

		/// <summary>Sets the input rectangles for this rendering pass into the transform.</summary>
		/// <param name="inputIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the input rectangle.</para>
		/// </param>
		/// <param name="invalidInputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c></b></para>
		/// <para>The invalid input rectangle.</para>
		/// </param>
		/// <param name="invalidOutputRect">
		/// <para>Type: <b><c>D2D1_RECT_L</c>*</b></para>
		/// <para>The output rectangle to which the input rectangle must be mapped.</para>
		/// </param>
		/// <remarks>
		/// The transform implementation must regard <b>MapInvalidRect</b> as purely functional. The transform implementation can base the
		/// mapped input rectangle on the transform implementation's current state as specified by the encapsulating effect properties. But
		/// the transform implementation can't change its own state in response to a call to <b>MapInvalidRect</b>. Direct2D can call this
		/// method at any time and in any sequence following a call to the <c>MapInputRectsToOutputRect</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transform-mapinvalidrect HRESULT
		// MapInvalidRect( UINT32 inputIndex, D2D1_RECT_L invalidInputRect, [out] D2D1_RECT_L *invalidOutputRect );
		void MapInvalidRect(uint inputIndex, RECT invalidInputRect, out RECT invalidOutputRect);
	}

	/// <summary>Represents a graph of transform nodes.</summary>
	/// <remarks>
	/// <para>
	/// This interface allows a graph of transform nodes to be specified. This interface is passed to <c>ID2D1EffectImpl::Initialize</c> to
	/// allow an effect implementation to specify a graph of transforms or a single transform.
	/// </para>
	/// <para>Examples</para>
	/// <para>This example shows how many of the methods on the <b>ID2D1TransformGraph</b> can be used.</para>
	/// <para>
	/// <c>class CMyEffect : public ID2D1EffectImpl { public: IFACEMETHODIMP SetGraph( __in ID2D1TransformGraph *pGraph ) { HRESULT hr =
	/// S_OK; hr = pGraph-&gt;Clear(); if (SUCEEDED(hr)) { hr = pGraph-&gt;AddNode(_pTransform1); } if (SUCCEEDED(hr)) { hr =
	/// pGraph-&gt;AddNode(_pTransform2); } if (SUCCEEDED(hr)) { hr = pGraph-&gt;SetOutputNode(_pTransform2); } if (SUCCEEDED(hr)) { hr =
	/// pGraph-&gt;ConnectNode(_pTransform1, _pTransform2, 0); } if (SUCCEEDED(hr)) { hr = pGraph-&gt;ConnectToEffectInput(0, _pTransform1,
	/// 0); } return hr; } private: class CMyTransform1 : public ID2D1DrawTransform { // &lt;Snip&gt; The transform implementation, one node
	/// input&lt;/Snip&gt; }; class CMyTransform2 : public ID2D1DrawTransform { // &lt;Snip&gt; A second transform implementation one node
	/// input&lt;/Snip&gt; }; CMyTransform1 *_pTransform1; CMyTransform2 *_pTransform2; };</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1transformgraph
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1TransformGraph")]
	[ComImport, Guid("13d29038-c3e6-4034-9081-13b53a417992"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1TransformGraph
	{
		/// <summary>Returns the number of inputs to the transform graph.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of inputs to this transform graph.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformgraph-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		uint GetInputCount();

		/// <summary>Sets a single transform node as being equivalent to the whole graph.</summary>
		/// <param name="node">
		/// <para>Type: <b><c>ID2D1TransformNode</c>*</b></para>
		/// <para>The node to be set.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This equivalent to calling <c>ID2D1TransformGraph::Clear</c>, adding a single node, connecting all of the node inputs to the
		/// effect inputs in order, and setting the transform not as the graph output.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// <c>class CMySimpleEffect : public ID2D1EffectImpl { public: IFACEMETHODIMP SetGraph( __in ID2D1TransformGraph *pGraph ) {
		/// HRESULT hr = S_OK; CMyTransform *pTransform = new CMyTransform(); hr = pTransform ? S_OK : E_OUTOFMEMORY; if (SUCCEEDED(hr)) {
		/// hr = graph-&gt;SetSingleTransformNode(pTransform); pTransform-&gt;Release(); } return hr; } private: class CMyTransform : public
		/// ID2D1DrawTransform { // &lt;Snip&gt; Implementation of transform &lt;/Snip&gt; }; };</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformgraph-setsingletransformnode
		// HRESULT SetSingleTransformNode( ID2D1TransformNode *node );
		void SetSingleTransformNode([In] ID2D1TransformNode node);

		/// <summary>Adds the provided node to the transform graph.</summary>
		/// <param name="node">
		/// <para>Type: <b><c>ID2D1TransformNode</c>*</b></para>
		/// <para>The node that will be added to the transform graph.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This adds a transform node to the transform graph. A node must be added to the transform graph before it can be interconnected
		/// in any way.
		/// </para>
		/// <para>
		/// A transform graph cannot be directly added to another transform graph. Only interfaces derived from <c>ID2D1TransformNode</c>
		/// can be added to the transform graph.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformgraph-addnode HRESULT
		// AddNode( [in] ID2D1TransformNode *node );
		void AddNode([In] ID2D1TransformNode node);

		/// <summary>Removes the provided node from the transform graph.</summary>
		/// <param name="node">
		/// <para>Type: <b><c>ID2D1TransformNode</c>*</b></para>
		/// <para>The node that will be removed from the transform graph.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>The method returns an <b>HRESULT</b>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred</description>
		/// </item>
		/// <item>
		/// <description>D2DERR_NOT_FOUND = (HRESULT_FROM_WIN32(ERROR_NOT_FOUND))</description>
		/// <description>Direct2D could not locate the specified node.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The node must already exist in the graph; otherwise, the call fails with <b>D2DERR_NOT_FOUND</b>.</para>
		/// <para>Any connections to this node will be removed when the node is removed.</para>
		/// <para>After the node is removed, it cannot be used by the interface until it has been added to the graph by <c>AddNode</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformgraph-removenode HRESULT
		// RemoveNode( [in] ID2D1TransformNode *node );
		[PreserveSig]
		HRESULT RemoveNode([In] ID2D1TransformNode node);

		/// <summary>Sets the output node for the transform graph.</summary>
		/// <param name="node">
		/// <para>Type: <b><c>ID2D1TransformNode</c>*</b></para>
		/// <para>The node that will be considered the output of the transform node.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>The method returns an <b>HRESULT</b>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred</description>
		/// </item>
		/// <item>
		/// <description>D2DERR_NOT_FOUND = (HRESULT_FROM_WIN32(ERROR_NOT_FOUND))</description>
		/// <description>Direct2D could not locate the specified node.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The node must already exist in the graph; otherwise, the call fails with <b>D2DERR_NOT_FOUND</b>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformgraph-setoutputnode
		// HRESULT SetOutputNode( [in] ID2D1TransformNode *node );
		[PreserveSig]
		HRESULT SetOutputNode([In] ID2D1TransformNode node);

		/// <summary>Connects two nodes inside the transform graph.</summary>
		/// <param name="fromNode">
		/// <para>Type: <b><c>ID2D1TransformNode</c>*</b></para>
		/// <para>The node from which the connection will be made.</para>
		/// </param>
		/// <param name="toNode">
		/// <para>Type: <b><c>ID2D1TransformNode</c>*</b></para>
		/// <para>The node to which the connection will be made.</para>
		/// </param>
		/// <param name="toNodeInputIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The node input that will be connected.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>The method returns an <b>HRESULT</b>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred</description>
		/// </item>
		/// <item>
		/// <description>D2DERR_NOT_FOUND = (HRESULT_FROM_WIN32(ERROR_NOT_FOUND))</description>
		/// <description>Direct2D could not locate the specified node.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Both nodes must already exist in the graph; otherwise, the call fails with <b>D2DERR_NOT_FOUND</b>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformgraph-connectnode HRESULT
		// ConnectNode( [in] ID2D1TransformNode *fromNode, [in] ID2D1TransformNode *toNode, UINT32 toNodeInputIndex );
		[PreserveSig]
		HRESULT ConnectNode([In] ID2D1TransformNode fromNode, [In] ID2D1TransformNode toNode, uint toNodeInputIndex);

		/// <summary>Connects a transform node inside the graph to the corresponding effect input of the encapsulating effect.</summary>
		/// <param name="toEffectInputIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The effect input to which the transform node will be bound.</para>
		/// </param>
		/// <param name="node">
		/// <para>Type: <b><c>ID2D1TransformNode</c>*</b></para>
		/// <para>The node to which the connection will be made.</para>
		/// </param>
		/// <param name="toNodeInputIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The node input that will be connected.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>The method returns an <b>HRESULT</b>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred</description>
		/// </item>
		/// <item>
		/// <description>D2DERR_NOT_FOUND = (HRESULT_FROM_WIN32(ERROR_NOT_FOUND))</description>
		/// <description>Direct2D could not locate the specified node.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformgraph-connecttoeffectinput
		// HRESULT ConnectToEffectInput( UINT32 toEffectInputIndex, [in] ID2D1TransformNode *node, UINT32 toNodeInputIndex );
		[PreserveSig]
		HRESULT ConnectToEffectInput(uint toEffectInputIndex, [In] ID2D1TransformNode node, uint toNodeInputIndex);

		/// <summary>Clears the transform nodes and all connections from the transform graph.</summary>
		/// <returns>None</returns>
		/// <remarks>Used when enough changes to transfoms would make editing of the transform graph inefficient.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformgraph-clear void Clear();
		[PreserveSig]
		void Clear();

		/// <summary>Uses the specified input as the effect output.</summary>
		/// <param name="effectInputIndex">The index of the input to the effect.</param>
		/// <returns>
		/// <para>The method returns an <b>HRESULT</b>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred</description>
		/// </item>
		/// <item>
		/// <description>D2DERR_NOT_FOUND = (HRESULT_FROM_WIN32(ERROR_NOT_FOUND))</description>
		/// <description>Direct2D could not locate the specified node.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformgraph-setpassthroughgraph
		// HRESULT SetPassthroughGraph( UINT32 effectInputIndex );
		[PreserveSig]
		HRESULT SetPassthroughGraph(uint effectInputIndex);
	}

	/// <summary>Describes a node in a transform topology.</summary>
	/// <remarks>
	/// Transform nodes are type-less and only define the notion of an object that accepts a number of inputs and is an output. This
	/// interface limits a topology to single output nodes.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1transformnode
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1TransformNode")]
	[ComImport, Guid("b2efe1e7-729f-4102-949f-505fa21bf666"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1TransformNode
	{
		/// <summary>Gets the number of inputs to the transform node.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>This method returns the number of inputs to this transform node.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1transformnode-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		uint GetInputCount();
	}

	/// <summary>Defines a mappable single-dimensional vertex buffer.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nn-d2d1effectauthor-id2d1vertexbuffer
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NN:d2d1effectauthor.ID2D1VertexBuffer")]
	[ComImport, Guid("9b8b1336-00a5-4668-92b7-ced5d8bf9b7b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1VertexBuffer
	{
		/// <summary>Maps the provided data into user memory.</summary>
		/// <param name="data">
		/// <para>Type: <b>const BYTE**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the available buffer.</para>
		/// </param>
		/// <param name="bufferSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The desired size of the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>The method returns an HRESULT. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed to the returning function.</description>
		/// </item>
		/// <item>
		/// <description>D3DERR_DEVICELOST</description>
		/// <description>The device has been lost but cannot be reset at this time.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>If <i>data</i> is larger than <i>bufferSize</i>, this method fails.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1vertexbuffer-map HRESULT Map( [out]
		// BYTE **data, UINT32 bufferSize );
		[PreserveSig]
		HRESULT Map(out IntPtr data, uint bufferSize);

		/// <summary>Unmaps the vertex buffer.</summary>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>The method returns an HRESULT. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred.</description>
		/// </item>
		/// <item>
		/// <description>D2DERR_WRONG_STATE</description>
		/// <description>The object was not in the correct state to process the method.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>After this method returns, the mapped memory from the vertex buffer is no longer accessible by the effect.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1vertexbuffer-unmap HRESULT Unmap();
		[PreserveSig]
		HRESULT Unmap();
	}

	/// <summary>This indicates whether an optional capability is supported by the D3D device.</summary>
	/// <typeparam name="T">The type of the data provided.</typeparam>
	/// <param name="ctx">The <see cref="ID2D1EffectContext"/> instance.</param>
	/// <param name="featureSupportData">
	/// <para>Type: <b>void*</b></para>
	/// <para>A structure indicating information about how or if the feature is supported.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>HRESULT</b></para>
	/// <para>The method returns an <b>HRESULT</b>. Possible values include, but are not limited to, those in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>HRESULT</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>S_OK</description>
	/// <description>No error occurred.</description>
	/// </item>
	/// <item>
	/// <description>E_OUTOFMEMORY</description>
	/// <description>Direct2D could not allocate sufficient memory to complete the call.</description>
	/// </item>
	/// <item>
	/// <description>E_INVALIDARG</description>
	/// <description>An invalid parameter was passed to the returning function.</description>
	/// </item>
	/// </list>
	/// </returns>
	public static HRESULT CheckFeatureSupport<T>(this ID2D1EffectContext ctx, in T featureSupportData) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet<T, D2D1_FEATURE>(out var f))
			return HRESULT.E_INVALIDARG;
		using SafeCoTaskMemStruct<T> mem = featureSupportData;
		return ctx.CheckFeatureSupport(f, mem, (uint)mem.Size);
	}

	/// <summary>
	/// Creates a vertex buffer or finds a standard vertex buffer and optionally initializes it with vertices. The returned buffer can be
	/// specified in the render info to specify both a vertex shader and or to pass custom vertices to the standard vertex shader used by <c>Direct2D</c>.
	/// </summary>
	/// <param name="ctx">The <see cref="ID2D1EffectContext"/> instance.</param>
	/// <param name="vertexBufferProperties">
	/// <para>Type: <b>const <c>D2D1_VERTEX_BUFFER_PROPERTIES</c>*</b></para>
	/// <para>The properties used to describe the vertex buffer and vertex shader.</para>
	/// </param>
	/// <param name="resourceId">
	/// <para>Type: <b>const GUID*</b></para>
	/// <para>The unique id that identifies the vertex buffer.</para>
	/// </param>
	/// <param name="customVertexBufferProperties">
	/// <para>Type: <b>const <c>D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES</c>*</b></para>
	/// <para>
	/// The properties used to define a custom vertex buffer. If you use a built-in vertex shader, you don't have to specify this property.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>ID2D1VertexBuffer</c>**</b></para>
	/// <para>The returned vertex buffer.</para>
	/// </returns>
	public static ID2D1VertexBuffer CreateVertexBuffer(this ID2D1EffectContext ctx, in D2D1_VERTEX_BUFFER_PROPERTIES vertexBufferProperties,
		[In, Optional] Guid? resourceId, [In, Optional] D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES? customVertexBufferProperties)
	{
		using SafeCoTaskMemStruct<Guid> rid = resourceId;
		return ctx.CreateVertexBuffer(vertexBufferProperties, rid, new(customVertexBufferProperties, out _));
	}

	/// <summary>
	/// Sets a vertex buffer, a corresponding vertex shader, and options to control how the vertices are to be handled by the Direct2D context.
	/// </summary>
	/// <param name="info">The <see cref="ID2D1DrawInfo"/> instance.</param>
	/// <param name="vertexOptions">Options that influence how the renderer will interact with the vertex shader.</param>
	/// <param name="vertexBuffer">
	/// The vertex buffer, if this is cleared, the default vertex shader and mapping to the transform rectangles will be used.
	/// </param>
	/// <param name="blendDescription">How the vertices will be blended with the output texture.</param>
	/// <param name="vertexRange">The set of vertices to use from the buffer.</param>
	/// <param name="vertexShader">The GUID of the vertex shader.</param>
	/// <remarks>
	/// <para>
	/// The vertex shaders associated with the vertex buffer through the vertex shader GUID must have been loaded through the
	/// <c>ID2D1EffectContext::LoadVertexShader</c> method before this call is made.
	/// </para>
	/// <para>
	/// If you pass the vertex option <c>D2D1_VERTEX_OPTIONS_DO_NOT_CLEAR</c>, the appropriate value for <paramref name="blendDescription"/>
	/// is supplied.
	/// </para>
	/// <para>If this call fails, the corresponding <c>ID2D1Effect</c> instance is placed into an error state and fails to draw.</para>
	/// <para>If blendDescription is NULL, a foreground-over blend mode is used.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1drawinfo-setvertexprocessing HRESULT
	// SetVertexProcessing( [in, optional] ID2D1VertexBuffer *vertexBuffer, D2D1_VERTEX_OPTIONS vertexOptions, [in, optional] const
	// D2D1_BLEND_DESCRIPTION *blendDescription, [in, optional] const D2D1_VERTEX_RANGE *vertexRange, const GUID *vertexShader );
	public static void SetVertexProcessing(this ID2D1DrawInfo info, D2D1_VERTEX_OPTIONS vertexOptions, [In, Optional] ID2D1VertexBuffer? vertexBuffer,
		[In, Optional] D2D1_BLEND_DESCRIPTION? blendDescription, [In, Optional] D2D1_VERTEX_RANGE? vertexRange,
		[In, Optional] Guid? vertexShader)
	{
		if (vertexOptions == D2D1_VERTEX_OPTIONS.D2D1_VERTEX_OPTIONS_DO_NOT_CLEAR)
			blendDescription = new()
			{
				sourceBlend = D2D1_BLEND.D2D1_BLEND_ONE,
				destinationBlend = D2D1_BLEND.D2D1_BLEND_ZERO,
				blendOperation = D2D1_BLEND_OPERATION.D2D1_BLEND_OPERATION_ADD,
				sourceBlendAlpha = D2D1_BLEND.D2D1_BLEND_ONE,
				destinationBlendAlpha = D2D1_BLEND.D2D1_BLEND_ZERO,
				blendFactor = [1f, 1f, 1f, 1f]
			};
		info.SetVertexProcessing(vertexBuffer, vertexOptions, new(blendDescription, out _),
			new(vertexRange, out _), new(vertexShader, out _));
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