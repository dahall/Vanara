namespace Vanara.PInvoke;

/// <summary>Provides methods and types for working with Direct3D 11.</summary>
public static partial class D3D11
{
	/// <summary>Optional flags that control the behavior of ID3D11DeviceContext::GetData.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_async_getdata_flag typedef enum D3D11_ASYNC_GETDATA_FLAG {
	// D3D11_ASYNC_GETDATA_DONOTFLUSH = 0x1 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_ASYNC_GETDATA_FLAG")]
	[Flags]
	public enum D3D11_ASYNC_GETDATA_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>
		/// Do not flush the command buffer. This can potentially cause an infinite loop if GetData is continually called until it returns
		/// S_OK as there may still be commands in the command buffer that need to be processed in order for GetData to return S_OK. Since
		/// the commands in the command buffer are not flushed they will not be processed and therefore GetData will never return S_OK.
		/// </para>
		/// </summary>
		D3D11_ASYNC_GETDATA_DONOTFLUSH = 1,
	}

	/// <summary>Specifies the type of Microsoft Direct3D authenticated channel.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_authenticated_channel_type typedef enum
	// D3D11_AUTHENTICATED_CHANNEL_TYPE { D3D11_AUTHENTICATED_CHANNEL_D3D11 = 1, D3D11_AUTHENTICATED_CHANNEL_DRIVER_SOFTWARE = 2,
	// D3D11_AUTHENTICATED_CHANNEL_DRIVER_HARDWARE = 3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_AUTHENTICATED_CHANNEL_TYPE")]
	public enum D3D11_AUTHENTICATED_CHANNEL_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Direct3D 11 channel. This channel provides communication with the Direct3D runtime.</para>
		/// </summary>
		D3D11_AUTHENTICATED_CHANNEL_D3D11 = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Software driver channel. This channel provides communication with a driver that implements content protection mechanisms in software.
		/// </para>
		/// </summary>
		D3D11_AUTHENTICATED_CHANNEL_DRIVER_SOFTWARE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>
		/// Hardware driver channel. This channel provides communication with a driver that implements content protection mechanisms in the
		/// GPU hardware.
		/// </para>
		/// </summary>
		D3D11_AUTHENTICATED_CHANNEL_DRIVER_HARDWARE,
	}

	/// <summary>Identifies how to bind a resource to the pipeline.</summary>
	/// <remarks>
	/// <para>
	/// In general, binding flags can be combined using a bitwise OR (except the constant-buffer flag); however, you should use a single
	/// flag to allow the device to optimize the resource usage.
	/// </para>
	/// <para>This enumeration is used by a:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Buffer description when creating a buffer.</description>
	/// </item>
	/// <item>
	/// <description>Texture description when creating a texture (see D3D11_TEXTURE1D_DESC or D3D11_TEXTURE2D_DESC or D3D11_TEXTURE3D_DESC).</description>
	/// </item>
	/// </list>
	/// <para>
	/// A shader-resource buffer is NOT a constant buffer; rather, it is a texture or buffer resource that is bound to a shader, that
	/// contains texture or buffer data (it is not limited to a single element type in the buffer). A shader-resource buffer is created with
	/// the D3D11_BIND_SHADER_RESOURCE flag and is bound to the pipeline using one of these APIs: ID3D11DeviceContext::GSSetShaderResources,
	/// ID3D11DeviceContext::PSSetShaderResources, or ID3D11DeviceContext::VSSetShaderResources. Furthermore, a shader-resource buffer
	/// cannot use the D3D11_MAP_WRITE_NO_OVERWRITE flag.
	/// </para>
	/// <para>
	/// <c>Note</c>  The Direct3D 11.1 runtime, which is available starting with Windows 8, enables mapping dynamic constant buffers and
	/// shader resource views (SRVs) of dynamic buffers with D3D11_MAP_WRITE_NO_OVERWRITE. The Direct3D 11 and earlier runtimes limited
	/// mapping to vertex or index buffers. To determine if a Direct3D device supports these features, call
	/// ID3D11Device::CheckFeatureSupport with D3D11_FEATURE_D3D11_OPTIONS. <c>CheckFeatureSupport</c> fills members of a
	/// D3D11_FEATURE_DATA_D3D11_OPTIONS structure with the device's features. The relevant members here are
	/// <c>MapNoOverwriteOnDynamicConstantBuffer</c> and <c>MapNoOverwriteOnDynamicBufferSRV</c>.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_bind_flag typedef enum D3D11_BIND_FLAG {
	// D3D11_BIND_VERTEX_BUFFER = 0x1L, D3D11_BIND_INDEX_BUFFER = 0x2L, D3D11_BIND_CONSTANT_BUFFER = 0x4L, D3D11_BIND_SHADER_RESOURCE =
	// 0x8L, D3D11_BIND_STREAM_OUTPUT = 0x10L, D3D11_BIND_RENDER_TARGET = 0x20L, D3D11_BIND_DEPTH_STENCIL = 0x40L,
	// D3D11_BIND_UNORDERED_ACCESS = 0x80L, D3D11_BIND_DECODER = 0x200L, D3D11_BIND_VIDEO_ENCODER = 0x400L } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_BIND_FLAG")]
	[Flags]
	public enum D3D11_BIND_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1L</para>
		/// <para>Bind a buffer as a vertex buffer to the input-assembler stage.</para>
		/// </summary>
		D3D11_BIND_VERTEX_BUFFER = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2L</para>
		/// <para>Bind a buffer as an index buffer to the input-assembler stage.</para>
		/// </summary>
		D3D11_BIND_INDEX_BUFFER = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4L</para>
		/// <para>Bind a buffer as a constant buffer to a shader stage; this flag may NOT be combined with any other bind flag.</para>
		/// </summary>
		D3D11_BIND_CONSTANT_BUFFER = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8L</para>
		/// <para>Bind a buffer or texture to a shader stage; this flag cannot be used with the</para>
		/// <para>D3D11_MAP_WRITE_NO_OVERWRITE</para>
		/// <para>flag.</para>
		/// <para>
		/// <c>Note</c>  The Direct3D 11.1 runtime, which is available starting with Windows 8, enables mapping dynamic constant buffers and
		/// shader resource views (SRVs) of dynamic buffers with D3D11_MAP_WRITE_NO_OVERWRITE. The Direct3D 11 and earlier runtimes limited
		/// mapping to vertex or index buffers. To determine if a Direct3D device supports these features, call
		/// ID3D11Device::CheckFeatureSupport with D3D11_FEATURE_D3D11_OPTIONS. <c>CheckFeatureSupport</c> fills members of a
		/// D3D11_FEATURE_DATA_D3D11_OPTIONS structure with the device's features. The relevant members here are
		/// <c>MapNoOverwriteOnDynamicConstantBuffer</c> and <c>MapNoOverwriteOnDynamicBufferSRV</c>.
		/// </para>
		/// <para></para>
		/// </summary>
		D3D11_BIND_SHADER_RESOURCE = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10L</para>
		/// <para>Bind an output buffer for the stream-output stage.</para>
		/// </summary>
		D3D11_BIND_STREAM_OUTPUT = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20L</para>
		/// <para>Bind a texture as a render target for the output-merger stage.</para>
		/// </summary>
		D3D11_BIND_RENDER_TARGET = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40L</para>
		/// <para>Bind a texture as a depth-stencil target for the output-merger stage.</para>
		/// </summary>
		D3D11_BIND_DEPTH_STENCIL = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80L</para>
		/// <para>Bind an</para>
		/// <para>unordered access</para>
		/// <para>resource.</para>
		/// </summary>
		D3D11_BIND_UNORDERED_ACCESS = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200L</para>
		/// <para>Set this flag to indicate that a</para>
		/// <para>2D texture</para>
		/// <para>
		/// is used to receive output from the decoder API. The common way to create resources for a decoder output is by calling the
		/// </para>
		/// <para>ID3D11Device::CreateTexture2D</para>
		/// <para>
		/// method to create an array of 2D textures. However, you cannot use texture arrays that are created with this flag in calls to
		/// </para>
		/// <para>ID3D11Device::CreateShaderResourceView</para>
		/// <para>.</para>
		/// <para>Direct3D 11:  </para>
		/// <para>This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_BIND_DECODER = 0x200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400L</para>
		/// <para>Set this flag to indicate that a</para>
		/// <para>2D texture</para>
		/// <para>
		/// is used to receive input from the video encoder API. The common way to create resources for a video encoder is by calling the
		/// </para>
		/// <para>ID3D11Device::CreateTexture2D</para>
		/// <para>
		/// method to create an array of 2D textures. However, you cannot use texture arrays that are created with this flag in calls to
		/// </para>
		/// <para>ID3D11Device::CreateShaderResourceView</para>
		/// <para>.</para>
		/// <para>Direct3D 11:  </para>
		/// <para>This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_BIND_VIDEO_ENCODER = 0x400,
	}

	/// <summary>Blend factors, which modulate values for the pixel shader and render target.</summary>
	/// <remarks>Blend operations are specified in a blend description.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_blend typedef enum D3D11_BLEND { D3D11_BLEND_ZERO = 1,
	// D3D11_BLEND_ONE = 2, D3D11_BLEND_SRC_COLOR = 3, D3D11_BLEND_INV_SRC_COLOR = 4, D3D11_BLEND_SRC_ALPHA = 5, D3D11_BLEND_INV_SRC_ALPHA =
	// 6, D3D11_BLEND_DEST_ALPHA = 7, D3D11_BLEND_INV_DEST_ALPHA = 8, D3D11_BLEND_DEST_COLOR = 9, D3D11_BLEND_INV_DEST_COLOR = 10,
	// D3D11_BLEND_SRC_ALPHA_SAT = 11, D3D11_BLEND_BLEND_FACTOR = 14, D3D11_BLEND_INV_BLEND_FACTOR = 15, D3D11_BLEND_SRC1_COLOR = 16,
	// D3D11_BLEND_INV_SRC1_COLOR = 17, D3D11_BLEND_SRC1_ALPHA = 18, D3D11_BLEND_INV_SRC1_ALPHA = 19 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_BLEND")]
	public enum D3D11_BLEND
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The blend factor is (0, 0, 0, 0). No pre-blend operation.</para>
		/// </summary>
		D3D11_BLEND_ZERO = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The blend factor is (1, 1, 1, 1). No pre-blend operation.</para>
		/// </summary>
		D3D11_BLEND_ONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The blend factor is (Rₛ, Gₛ, Bₛ, Aₛ), that is color data (RGB) from a pixel shader. No pre-blend operation.</para>
		/// </summary>
		D3D11_BLEND_SRC_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>
		/// The blend factor is (1 - Rₛ, 1 - Gₛ, 1 - Bₛ, 1 - Aₛ), that is color data (RGB) from a pixel shader. The pre-blend operation
		/// inverts the data, generating 1 - RGB.
		/// </para>
		/// </summary>
		D3D11_BLEND_INV_SRC_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The blend factor is (Aₛ, Aₛ, Aₛ, Aₛ), that is alpha data (A) from a pixel shader. No pre-blend operation.</para>
		/// </summary>
		D3D11_BLEND_SRC_ALPHA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>
		/// The blend factor is ( 1 - Aₛ, 1 - Aₛ, 1 - Aₛ, 1 - Aₛ), that is alpha data (A) from a pixel shader. The pre-blend operation
		/// inverts the data, generating 1 - A.
		/// </para>
		/// </summary>
		D3D11_BLEND_INV_SRC_ALPHA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The blend factor is (A</para>
		/// <para>d</para>
		/// <para>A</para>
		/// <para>d</para>
		/// <para>A</para>
		/// <para>d</para>
		/// <para>A</para>
		/// <para>d</para>
		/// <para>), that is alpha data from a render target. No pre-blend operation.</para>
		/// </summary>
		D3D11_BLEND_DEST_ALPHA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The blend factor is (1 - A</para>
		/// <para>d</para>
		/// <para>1 - A</para>
		/// <para>d</para>
		/// <para>1 - A</para>
		/// <para>d</para>
		/// <para>1 - A</para>
		/// <para>d</para>
		/// <para>), that is alpha data from a render target. The pre-blend operation inverts the data, generating 1 - A.</para>
		/// </summary>
		D3D11_BLEND_INV_DEST_ALPHA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>The blend factor is (R</para>
		/// <para>d</para>
		/// <para>, G</para>
		/// <para>d</para>
		/// <para>, B</para>
		/// <para>d</para>
		/// <para>, A</para>
		/// <para>d</para>
		/// <para>), that is color data from a render target. No pre-blend operation.</para>
		/// </summary>
		D3D11_BLEND_DEST_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>The blend factor is (1 - R</para>
		/// <para>d</para>
		/// <para>, 1 - G</para>
		/// <para>d</para>
		/// <para>, 1 - B</para>
		/// <para>d</para>
		/// <para>, 1 - A</para>
		/// <para>d</para>
		/// <para>), that is color data from a render target. The pre-blend operation inverts the data, generating 1 - RGB.</para>
		/// </summary>
		D3D11_BLEND_INV_DEST_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>The blend factor is (f, f, f, 1); where f = min(Aₛ, 1</para>
		/// <para>- A</para>
		/// <para>d</para>
		/// <para>). The pre-blend operation clamps the data to 1 or less.</para>
		/// </summary>
		D3D11_BLEND_SRC_ALPHA_SAT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <para>The blend factor is the blend factor set with</para>
		/// <para>ID3D11DeviceContext::OMSetBlendState</para>
		/// <para>. No pre-blend operation.</para>
		/// </summary>
		D3D11_BLEND_BLEND_FACTOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <para>The blend factor is the blend factor set with</para>
		/// <para>ID3D11DeviceContext::OMSetBlendState</para>
		/// <para>. The pre-blend operation inverts the blend factor, generating 1 - blend_factor.</para>
		/// </summary>
		D3D11_BLEND_INV_BLEND_FACTOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <para>
		/// The blend factor is data sources both as color data output by a pixel shader. There is no pre-blend operation. This blend factor
		/// supports dual-source color blending.
		/// </para>
		/// </summary>
		D3D11_BLEND_SRC1_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>17</para>
		/// <para>
		/// The blend factor is data sources both as color data output by a pixel shader. The pre-blend operation inverts the data,
		/// generating 1 - RGB. This blend factor supports dual-source color blending.
		/// </para>
		/// </summary>
		D3D11_BLEND_INV_SRC1_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>18</para>
		/// <para>
		/// The blend factor is data sources as alpha data output by a pixel shader. There is no pre-blend operation. This blend factor
		/// supports dual-source color blending.
		/// </para>
		/// </summary>
		D3D11_BLEND_SRC1_ALPHA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>19</para>
		/// <para>
		/// The blend factor is data sources as alpha data output by a pixel shader. The pre-blend operation inverts the data, generating 1
		/// - A. This blend factor supports dual-source color blending.
		/// </para>
		/// </summary>
		D3D11_BLEND_INV_SRC1_ALPHA,
	}

	/// <summary>RGB or alpha blending operation.</summary>
	/// <remarks>
	/// <para>
	/// The runtime implements RGB blending and alpha blending separately. Therefore, blend state requires separate blend operations for RGB
	/// data and alpha data. These blend operations are specified in a blend description. The two sources —source 1 and source 2— are shown
	/// in the blending block diagram.
	/// </para>
	/// <para>
	/// Blend state is used by the output-merger stage to determine how to blend together two RGB pixel values and two alpha values. The two
	/// RGB pixel values and two alpha values are the RGB pixel value and alpha value that the pixel shader outputs and the RGB pixel value
	/// and alpha value already in the output render target. The blend option controls the data source that the blending stage uses to
	/// modulate values for the pixel shader, render target, or both. The <c>blend operation</c> controls how the blending stage
	/// mathematically combines these modulated values.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_blend_op typedef enum D3D11_BLEND_OP { D3D11_BLEND_OP_ADD =
	// 1, D3D11_BLEND_OP_SUBTRACT = 2, D3D11_BLEND_OP_REV_SUBTRACT = 3, D3D11_BLEND_OP_MIN = 4, D3D11_BLEND_OP_MAX = 5 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_BLEND_OP")]
	public enum D3D11_BLEND_OP
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Add source 1 and source 2.</para>
		/// </summary>
		D3D11_BLEND_OP_ADD = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Subtract source 1 from source 2.</para>
		/// </summary>
		D3D11_BLEND_OP_SUBTRACT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Subtract source 2 from source 1.</para>
		/// </summary>
		D3D11_BLEND_OP_REV_SUBTRACT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Find the minimum of source 1 and source 2.</para>
		/// </summary>
		D3D11_BLEND_OP_MIN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Find the maximum of source 1 and source 2.</para>
		/// </summary>
		D3D11_BLEND_OP_MAX,
	}

	/// <summary>Identifies unordered-access view options for a buffer resource.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_buffer_uav_flag typedef enum D3D11_BUFFER_UAV_FLAG {
	// D3D11_BUFFER_UAV_FLAG_RAW = 0x1, D3D11_BUFFER_UAV_FLAG_APPEND = 0x2, D3D11_BUFFER_UAV_FLAG_COUNTER = 0x4 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_BUFFER_UAV_FLAG")]
	[Flags]
	public enum D3D11_BUFFER_UAV_FLAG : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>
		/// Resource contains raw, unstructured data. Requires the UAV format to be DXGI_FORMAT_R32_TYPELESS. For more info about raw
		/// viewing of buffers, see Raw Views of Buffers.
		/// </para>
		/// </summary>
		D3D11_BUFFER_UAV_FLAG_RAW = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>
		/// Allow data to be appended to the end of the buffer. D3D11_BUFFER_UAV_FLAG_APPEND flag must also be used for any view that will
		/// be used as a AppendStructuredBuffer or a ConsumeStructuredBuffer. Requires the UAV format to be DXGI_FORMAT_UNKNOWN.
		/// </para>
		/// </summary>
		D3D11_BUFFER_UAV_FLAG_APPEND = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>
		/// Adds a counter to the unordered-access-view buffer. D3D11_BUFFER_UAV_FLAG_COUNTER can only be used on a UAV that is a
		/// RWStructuredBuffer and it enables the functionality needed for the IncrementCounter and DecrementCounter methods in HLSL.
		/// Requires the UAV format to be DXGI_FORMAT_UNKNOWN.
		/// </para>
		/// </summary>
		D3D11_BUFFER_UAV_FLAG_COUNTER = 0x4,
	}

	/// <summary>Identifies how to view a buffer resource.</summary>
	/// <remarks>This enumeration is used by D3D11_BUFFEREX_SRV</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_bufferex_srv_flag typedef enum D3D11_BUFFEREX_SRV_FLAG {
	// D3D11_BUFFEREX_SRV_FLAG_RAW = 0x1 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_BUFFEREX_SRV_FLAG")]
	[Flags]
	public enum D3D11_BUFFEREX_SRV_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>View the buffer as raw. For more info about raw viewing of buffers, see</para>
		/// <para>Raw Views of Buffers</para>
		/// <para>.</para>
		/// </summary>
		D3D11_BUFFEREX_SRV_FLAG_RAW = 0x1,
	}

	/// <summary>Specifies the parts of the depth stencil to clear.</summary>
	/// <remarks>
	/// These flags are used when calling ID3D11DeviceContext::ClearDepthStencilView; the flags can be combined with a bitwise OR.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_clear_flag typedef enum D3D11_CLEAR_FLAG { D3D11_CLEAR_DEPTH
	// = 0x1L, D3D11_CLEAR_STENCIL = 0x2L } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_CLEAR_FLAG")]
	[Flags]
	public enum D3D11_CLEAR_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1L</para>
		/// <para>Clear the depth buffer, using fast clear if possible, then place the resource in a compressed state.</para>
		/// </summary>
		D3D11_CLEAR_DEPTH = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2L</para>
		/// <para>Clear the stencil buffer, using fast clear if possible, then place the resource in a compressed state.</para>
		/// </summary>
		D3D11_CLEAR_STENCIL = 2,
	}

	/// <summary>Identify which components of each pixel of a render target are writable during blending.</summary>
	/// <remarks>These flags can be combined with a bitwise OR.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_color_write_enable typedef enum D3D11_COLOR_WRITE_ENABLE {
	// D3D11_COLOR_WRITE_ENABLE_RED = 1, D3D11_COLOR_WRITE_ENABLE_GREEN = 2, D3D11_COLOR_WRITE_ENABLE_BLUE = 4,
	// D3D11_COLOR_WRITE_ENABLE_ALPHA = 8, D3D11_COLOR_WRITE_ENABLE_ALL } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_COLOR_WRITE_ENABLE")]
	[Flags]
	public enum D3D11_COLOR_WRITE_ENABLE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Allow data to be stored in the red component.</para>
		/// </summary>
		D3D11_COLOR_WRITE_ENABLE_RED = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Allow data to be stored in the green component.</para>
		/// </summary>
		D3D11_COLOR_WRITE_ENABLE_GREEN = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Allow data to be stored in the blue component.</para>
		/// </summary>
		D3D11_COLOR_WRITE_ENABLE_BLUE = 4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Allow data to be stored in the alpha component.</para>
		/// </summary>
		D3D11_COLOR_WRITE_ENABLE_ALPHA = 8,

		/// <summary>Allow data to be stored in all components.</summary>
		D3D11_COLOR_WRITE_ENABLE_ALL = 0xf,
	}

	/// <summary>Comparison options.</summary>
	/// <remarks>
	/// A comparison option determines whether how the runtime compares source (new) data against destination (existing) data before storing
	/// the new data. The comparison option is declared in a description before an object is created. The API allows you to set a comparison
	/// option for a depth-stencil buffer (see D3D11_DEPTH_STENCIL_DESC), depth-stencil operations (see D3D11_DEPTH_STENCILOP_DESC), or
	/// sampler state (see D3D11_SAMPLER_DESC).
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_comparison_func typedef enum D3D11_COMPARISON_FUNC {
	// D3D11_COMPARISON_NEVER = 1, D3D11_COMPARISON_LESS = 2, D3D11_COMPARISON_EQUAL = 3, D3D11_COMPARISON_LESS_EQUAL = 4,
	// D3D11_COMPARISON_GREATER = 5, D3D11_COMPARISON_NOT_EQUAL = 6, D3D11_COMPARISON_GREATER_EQUAL = 7, D3D11_COMPARISON_ALWAYS = 8 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_COMPARISON_FUNC")]
	public enum D3D11_COMPARISON_FUNC
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Never pass the comparison.</para>
		/// </summary>
		D3D11_COMPARISON_NEVER = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>If the source data is less than the destination data, the comparison passes.</para>
		/// </summary>
		D3D11_COMPARISON_LESS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>If the source data is equal to the destination data, the comparison passes.</para>
		/// </summary>
		D3D11_COMPARISON_EQUAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>If the source data is less than or equal to the destination data, the comparison passes.</para>
		/// </summary>
		D3D11_COMPARISON_LESS_EQUAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>If the source data is greater than the destination data, the comparison passes.</para>
		/// </summary>
		D3D11_COMPARISON_GREATER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>If the source data is not equal to the destination data, the comparison passes.</para>
		/// </summary>
		D3D11_COMPARISON_NOT_EQUAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>If the source data is greater than or equal to the destination data, the comparison passes.</para>
		/// </summary>
		D3D11_COMPARISON_GREATER_EQUAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Always pass the comparison.</para>
		/// </summary>
		D3D11_COMPARISON_ALWAYS,
	}

	/// <summary>Specifies if the hardware and driver support conservative rasterization and at what tier level.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_conservative_rasterization_tier typedef enum
	// D3D11_CONSERVATIVE_RASTERIZATION_TIER { D3D11_CONSERVATIVE_RASTERIZATION_NOT_SUPPORTED = 0, D3D11_CONSERVATIVE_RASTERIZATION_TIER_1 =
	// 1, D3D11_CONSERVATIVE_RASTERIZATION_TIER_2 = 2, D3D11_CONSERVATIVE_RASTERIZATION_TIER_3 = 3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_CONSERVATIVE_RASTERIZATION_TIER")]
	public enum D3D11_CONSERVATIVE_RASTERIZATION_TIER
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Conservative rasterization isn't supported.</para>
		/// </summary>
		D3D11_CONSERVATIVE_RASTERIZATION_NOT_SUPPORTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Tier_1 conservative rasterization is supported.</para>
		/// </summary>
		D3D11_CONSERVATIVE_RASTERIZATION_TIER_1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Tier_2 conservative rasterization is supported.</para>
		/// </summary>
		D3D11_CONSERVATIVE_RASTERIZATION_TIER_2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Tier_3 conservative rasterization is supported.</para>
		/// </summary>
		D3D11_CONSERVATIVE_RASTERIZATION_TIER_3,
	}

	/// <summary>Options for performance counters.</summary>
	/// <remarks>
	/// <para>
	/// Independent hardware vendors may define their own set of performance counters for their devices, by giving the enumeration value a
	/// number that is greater than the value for D3D11_COUNTER_DEVICE_DEPENDENT_0.
	/// </para>
	/// <para>This enumeration is used by D3D11_COUNTER_DESC and D3D11_COUNTER_INFO.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_counter typedef enum D3D11_COUNTER {
	// D3D11_COUNTER_DEVICE_DEPENDENT_0 = 0x40000000 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_COUNTER")]
	public enum D3D11_COUNTER
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40000000</para>
		/// <para>Define a performance counter that is dependent on the hardware device.</para>
		/// </summary>
		D3D11_COUNTER_DEVICE_DEPENDENT_0 = 0x40000000,
	}

	/// <summary>Data type of a performance counter.</summary>
	/// <remarks>These flags are an output parameter in ID3D11Device::CheckCounter.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_counter_type typedef enum D3D11_COUNTER_TYPE {
	// D3D11_COUNTER_TYPE_FLOAT32 = 0, D3D11_COUNTER_TYPE_UINT16, D3D11_COUNTER_TYPE_UINT32, D3D11_COUNTER_TYPE_UINT64 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_COUNTER_TYPE")]
	public enum D3D11_COUNTER_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>32-bit floating point.</para>
		/// </summary>
		[CorrespondingType(typeof(float))]
		D3D11_COUNTER_TYPE_FLOAT32,

		/// <summary>16-bit unsigned integer.</summary>
		[CorrespondingType(typeof(ushort))]
		D3D11_COUNTER_TYPE_UINT16,

		/// <summary>32-bit unsigned integer.</summary>
		[CorrespondingType(typeof(uint))]
		D3D11_COUNTER_TYPE_UINT32,

		/// <summary>64-bit unsigned integer.</summary>
		[CorrespondingType(typeof(ulong))]
		D3D11_COUNTER_TYPE_UINT64,
	}

	/// <summary>Specifies the types of CPU access allowed for a resource.</summary>
	/// <remarks>
	/// <para>This enumeration is used in D3D11_BUFFER_DESC, D3D11_TEXTURE1D_DESC, D3D11_TEXTURE2D_DESC, D3D11_TEXTURE3D_DESC.</para>
	/// <para>
	/// Applications may combine one or more of these flags with a bitwise OR. When possible, create resources with no CPU access flags, as
	/// this enables better resource optimization.
	/// </para>
	/// <para>The D3D11_RESOURCE_MISC_FLAG cannot be used when creating resources with <c>D3D11_CPU_ACCESS</c> flags.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_cpu_access_flag typedef enum D3D11_CPU_ACCESS_FLAG {
	// D3D11_CPU_ACCESS_WRITE = 0x10000L, D3D11_CPU_ACCESS_READ = 0x20000L } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_CPU_ACCESS_FLAG")]
	[Flags]
	public enum D3D11_CPU_ACCESS_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10000L</para>
		/// <para>
		/// The resource is to be mappable so that the CPU can change its contents. Resources created with this flag cannot be set as
		/// outputs of the pipeline and must be created with either dynamic or staging usage (see
		/// </para>
		/// <para>D3D11_USAGE</para>
		/// <para>).</para>
		/// </summary>
		D3D11_CPU_ACCESS_WRITE = 0x10000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000L</para>
		/// <para>
		/// The resource is to be mappable so that the CPU can read its contents. Resources created with this flag cannot be set as either
		/// inputs or outputs to the pipeline and must be created with staging usage (see
		/// </para>
		/// <para>D3D11_USAGE</para>
		/// <para>).</para>
		/// </summary>
		D3D11_CPU_ACCESS_READ = 0x20000,
	}

	/// <summary>Describes parameters that are used to create a device.</summary>
	/// <remarks>
	/// <para>Device creation flags are used by D3D11CreateDevice and D3D11CreateDeviceAndSwapChain.</para>
	/// <para>
	/// An application might dynamically create (and destroy) threads to improve performance especially on a machine with multiple CPU
	/// cores. There may be cases, however, when an application needs to prevent extra threads from being created. This can happen when you
	/// want to simplify debugging, profile code or develop a tool for instance. For these cases, use
	/// <c>D3D11_CREATE_DEVICE_PREVENT_INTERNAL_THREADING_OPTIMIZATIONS</c> to request that the runtime and video driver not create any
	/// additional threads that might interfere with the application.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_create_device_flag typedef enum D3D11_CREATE_DEVICE_FLAG {
	// D3D11_CREATE_DEVICE_SINGLETHREADED = 0x1, D3D11_CREATE_DEVICE_DEBUG = 0x2, D3D11_CREATE_DEVICE_SWITCH_TO_REF = 0x4,
	// D3D11_CREATE_DEVICE_PREVENT_INTERNAL_THREADING_OPTIMIZATIONS = 0x8, D3D11_CREATE_DEVICE_BGRA_SUPPORT = 0x20,
	// D3D11_CREATE_DEVICE_DEBUGGABLE = 0x40, D3D11_CREATE_DEVICE_PREVENT_ALTERING_LAYER_SETTINGS_FROM_REGISTRY = 0x80,
	// D3D11_CREATE_DEVICE_DISABLE_GPU_TIMEOUT = 0x100, D3D11_CREATE_DEVICE_VIDEO_SUPPORT = 0x800 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_CREATE_DEVICE_FLAG")]
	[Flags]
	public enum D3D11_CREATE_DEVICE_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>
		/// Use this flag if your application will only call methods of Direct3D 11 interfaces from a single thread. By default, the
		/// ID3D11Device object is thread-safe.
		/// </para>
		/// <para>
		/// By using this flag, you can increase performance. However, if you use this flag and your application calls methods of Direct3D
		/// 11 interfaces from multiple threads, undefined behavior might result.
		/// </para>
		/// </summary>
		D3D11_CREATE_DEVICE_SINGLETHREADED = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Creates a device that supports the debug layer.</para>
		/// <para>
		/// To use this flag, you must have D3D11*SDKLayers.dll installed; otherwise, device creation fails. To get D3D11_1SDKLayers.dll,
		/// install the SDK for Windows 8.
		/// </para>
		/// </summary>
		D3D11_CREATE_DEVICE_DEBUG = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para><c>Note</c>  This flag is not supported in Direct3D 11.</para>
		/// </summary>
		D3D11_CREATE_DEVICE_SWITCH_TO_REF = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>
		/// Prevents multiple threads from being created. When this flag is used with a Windows Advanced Rasterization Platform (WARP)
		/// device, no additional threads will be created by WARP and all rasterization will occur on the calling thread. This flag is not
		/// recommended for general use. See remarks.
		/// </para>
		/// </summary>
		D3D11_CREATE_DEVICE_PREVENT_INTERNAL_THREADING_OPTIMIZATIONS = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>
		/// Creates a device that supports BGRA formats (DXGI_FORMAT_B8G8R8A8_UNORM and DXGI_FORMAT_B8G8R8A8_UNORM_SRGB). All 10level9 and
		/// higher hardware with WDDM 1.1+ drivers support BGRA formats.
		/// </para>
		/// <para><c>Note</c>  Required for Direct2D interoperability with Direct3D resources.</para>
		/// </summary>
		D3D11_CREATE_DEVICE_BGRA_SUPPORT = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>
		/// Causes the device and driver to keep information that you can use for shader debugging. The exact impact from this flag will
		/// vary from driver to driver.
		/// </para>
		/// <para>
		/// To use this flag, you must have D3D11_1SDKLayers.dll installed; otherwise, device creation fails. The created device supports
		/// the debug layer. To get D3D11_1SDKLayers.dll, install the SDK for Windows 8.
		/// </para>
		/// <para>
		/// If you use this flag and the current driver does not support shader debugging, device creation fails. Shader debugging requires
		/// a driver that is implemented to the WDDM for Windows 8 (WDDM 1.2).
		/// </para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_CREATE_DEVICE_DEBUGGABLE = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>
		/// Causes the Direct3D runtime to ignore registry settings that turn on the debug layer. You can turn on the debug layer by using
		/// the DirectX Control Panel that was included as part of the DirectX SDK. We shipped the last version of the DirectX SDK in June
		/// 2010; you can download it from the Microsoft Download Center. You can set this flag in your app, typically in release builds
		/// only, to prevent end users from using the DirectX Control Panel to monitor how the app uses Direct3D.
		/// </para>
		/// <para>
		/// <c>Note</c> You can also set this flag in your app to prevent Direct3D debugging tools, such as Visual Studio Ultimate 2012,
		/// from hooking your app.
		/// </para>
		/// <para>
		/// Windows 8.1: This flag doesn't prevent Visual Studio 2013 and later running on Windows 8.1 and later from hooking your app;
		/// instead use ID3D11DeviceContext2::IsAnnotationEnabled. This flag still prevents Visual Studio 2013 and later running on Windows
		/// 8 and earlier from hooking your app.
		/// </para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_CREATE_DEVICE_PREVENT_ALTERING_LAYER_SETTINGS_FROM_REGISTRY = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>
		/// Use this flag if the device will produce GPU workloads that take more than two seconds to complete, and you want the operating
		/// system to allow them to successfully finish. If this flag is not set, the operating system performs timeout detection and
		/// recovery when it detects a GPU packet that took more than two seconds to execute. If this flag is set, the operating system
		/// allows such a long running packet to execute without resetting the GPU. We recommend not to set this flag if your device needs
		/// to be highly responsive so that the operating system can detect and recover from GPU timeouts. We recommend to set this flag if
		/// your device needs to perform time consuming background tasks such as compute, image recognition, and video encoding to allow
		/// such tasks to successfully finish.
		/// </para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_CREATE_DEVICE_DISABLE_GPU_TIMEOUT = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800</para>
		/// <para>
		/// Forces the creation of the Direct3D device to fail if the display driver is not implemented to the WDDM for Windows 8 (WDDM
		/// 1.2). When the display driver is not implemented to WDDM 1.2, only a Direct3D device that is created with feature level 9.1,
		/// 9.2, or 9.3 supports video; therefore, if this flag is set, the runtime creates the Direct3D device only for feature level 9.1,
		/// 9.2, or 9.3. We recommend not to specify this flag for applications that want to favor Direct3D capability over video. If
		/// feature level 10 and higher is available, the runtime will use that feature level regardless of video support.
		/// </para>
		/// <para>
		/// If this flag is set, device creation on the Basic Render Device (BRD) will succeed regardless of the BRD's missing support for
		/// video decode. This is because the Media Foundation video stack operates in software mode on BRD. In this situation, if you force
		/// the video stack to create the Direct3D device twice (create the device once with this flag, next discover BRD, then again create
		/// the device without the flag), you actually degrade performance.
		/// </para>
		/// <para>
		/// If you attempt to create a Direct3D device with driver type D3D_DRIVER_TYPE_NULL, D3D_DRIVER_TYPE_REFERENCE, or
		/// D3D_DRIVER_TYPE_SOFTWARE, device creation fails at any feature level because none of the associated drivers provide video
		/// capability. If you attempt to create a Direct3D device with driver type D3D_DRIVER_TYPE_WARP, device creation succeeds to allow
		/// software fallback for video.
		/// </para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_CREATE_DEVICE_VIDEO_SUPPORT = 0x800,
	}

	/// <summary>Indicates triangles facing a particular direction are not drawn.</summary>
	/// <remarks>This enumeration is part of a rasterizer-state object description (see D3D11_RASTERIZER_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_cull_mode typedef enum D3D11_CULL_MODE { D3D11_CULL_NONE =
	// 1, D3D11_CULL_FRONT = 2, D3D11_CULL_BACK = 3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_CULL_MODE")]
	public enum D3D11_CULL_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Always draw all triangles.</para>
		/// </summary>
		D3D11_CULL_NONE = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Do not draw triangles that are front-facing.</para>
		/// </summary>
		D3D11_CULL_FRONT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Do not draw triangles that are back-facing.</para>
		/// </summary>
		D3D11_CULL_BACK,
	}

	/// <summary>Identify the portion of a depth-stencil buffer for writing depth data.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_depth_write_mask typedef enum D3D11_DEPTH_WRITE_MASK {
	// D3D11_DEPTH_WRITE_MASK_ZERO = 0, D3D11_DEPTH_WRITE_MASK_ALL = 1 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_DEPTH_WRITE_MASK")]
	public enum D3D11_DEPTH_WRITE_MASK
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Turn off writes to the depth-stencil buffer.</para>
		/// </summary>
		D3D11_DEPTH_WRITE_MASK_ZERO,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Turn on writes to the depth-stencil buffer.</para>
		/// </summary>
		D3D11_DEPTH_WRITE_MASK_ALL,
	}

	/// <summary>Device context options.</summary>
	/// <remarks>This enumeration is used by ID3D11DeviceContext::GetType.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_device_context_type typedef enum D3D11_DEVICE_CONTEXT_TYPE {
	// D3D11_DEVICE_CONTEXT_IMMEDIATE = 0, D3D11_DEVICE_CONTEXT_DEFERRED } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_DEVICE_CONTEXT_TYPE")]
	public enum D3D11_DEVICE_CONTEXT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The device context is an immediate context.</para>
		/// </summary>
		D3D11_DEVICE_CONTEXT_IMMEDIATE,

		/// <summary>The device context is a deferred context.</summary>
		D3D11_DEVICE_CONTEXT_DEFERRED,
	}

	/// <summary>Specifies how to access a resource used in a depth-stencil view.</summary>
	/// <remarks>This enumeration is used in D3D11_DEPTH_STENCIL_VIEW_DESC to create a depth-stencil view.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_dsv_dimension typedef enum D3D11_DSV_DIMENSION {
	// D3D11_DSV_DIMENSION_UNKNOWN = 0, D3D11_DSV_DIMENSION_TEXTURE1D = 1, D3D11_DSV_DIMENSION_TEXTURE1DARRAY = 2,
	// D3D11_DSV_DIMENSION_TEXTURE2D = 3, D3D11_DSV_DIMENSION_TEXTURE2DARRAY = 4, D3D11_DSV_DIMENSION_TEXTURE2DMS = 5,
	// D3D11_DSV_DIMENSION_TEXTURE2DMSARRAY = 6 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_DSV_DIMENSION")]
	public enum D3D11_DSV_DIMENSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>D3D11_DSV_DIMENSION_UNKNOWN</para>
		/// <para>is not a valid value for</para>
		/// <para>D3D11_DEPTH_STENCIL_VIEW_DESC</para>
		/// <para>and is not used.</para>
		/// </summary>
		D3D11_DSV_DIMENSION_UNKNOWN = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The resource will be accessed as a 1D texture.</para>
		/// </summary>
		D3D11_DSV_DIMENSION_TEXTURE1D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The resource will be accessed as an array of 1D textures.</para>
		/// </summary>
		D3D11_DSV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The resource will be accessed as a 2D texture.</para>
		/// </summary>
		D3D11_DSV_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The resource will be accessed as an array of 2D textures.</para>
		/// </summary>
		D3D11_DSV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The resource will be accessed as a 2D texture with multisampling.</para>
		/// </summary>
		D3D11_DSV_DIMENSION_TEXTURE2DMS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The resource will be accessed as an array of 2D textures with multisampling.</para>
		/// </summary>
		D3D11_DSV_DIMENSION_TEXTURE2DMSARRAY,
	}

	/// <summary>Depth-stencil view options.</summary>
	/// <remarks>
	/// <para>This enumeration is used by D3D11_DEPTH_STENCIL_VIEW_DESC.</para>
	/// <para>
	/// Limiting a depth-stencil buffer to read-only access allows more than one depth-stencil view to be bound to the pipeline
	/// simultaneously, since it is not possible to have a read/write conflicts between separate views.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_dsv_flag typedef enum D3D11_DSV_FLAG {
	// D3D11_DSV_READ_ONLY_DEPTH = 0x1L, D3D11_DSV_READ_ONLY_STENCIL = 0x2L } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_DSV_FLAG")]
	[Flags]
	public enum D3D11_DSV_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1L</para>
		/// <para>Indicates that depth values are read only.</para>
		/// </summary>
		D3D11_DSV_READ_ONLY_DEPTH = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2L</para>
		/// <para>Indicates that stencil values are read only.</para>
		/// </summary>
		D3D11_DSV_READ_ONLY_STENCIL = 2,
	}

	/// <summary>Direct3D 11 feature options.</summary>
	/// <remarks>
	/// This enumeration is used when querying a driver about support for these features by calling ID3D11Device::CheckFeatureSupport. Each
	/// value in this enumeration has a corresponding data structure that is required to be passed to the <c>pFeatureSupportData</c>
	/// parameter of <c>ID3D11Device::CheckFeatureSupport</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_feature typedef enum D3D11_FEATURE { D3D11_FEATURE_THREADING
	// = 0, D3D11_FEATURE_DOUBLES, D3D11_FEATURE_FORMAT_SUPPORT, D3D11_FEATURE_FORMAT_SUPPORT2, D3D11_FEATURE_D3D10_X_HARDWARE_OPTIONS,
	// D3D11_FEATURE_D3D11_OPTIONS, D3D11_FEATURE_ARCHITECTURE_INFO, D3D11_FEATURE_D3D9_OPTIONS, D3D11_FEATURE_SHADER_MIN_PRECISION_SUPPORT,
	// D3D11_FEATURE_D3D9_SHADOW_SUPPORT, D3D11_FEATURE_D3D11_OPTIONS1, D3D11_FEATURE_D3D9_SIMPLE_INSTANCING_SUPPORT,
	// D3D11_FEATURE_MARKER_SUPPORT, D3D11_FEATURE_D3D9_OPTIONS1, D3D11_FEATURE_D3D11_OPTIONS2, D3D11_FEATURE_D3D11_OPTIONS3,
	// D3D11_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT, D3D11_FEATURE_D3D11_OPTIONS4, D3D11_FEATURE_SHADER_CACHE, D3D11_FEATURE_D3D11_OPTIONS5,
	// D3D11_FEATURE_DISPLAYABLE, D3D11_FEATURE_D3D11_OPTIONS6 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_FEATURE")]
	public enum D3D11_FEATURE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// The driver supports multithreading. To see an example of testing a driver for multithread support, see How To: Check for Driver
		/// Support. Refer to D3D11_FEATURE_DATA_THREADING.
		/// </para>
		/// </summary>
		D3D11_FEATURE_THREADING = 0,

		/// <summary>Supports the use of the double-precision shaders in HLSL. Refer to D3D11_FEATURE_DATA_DOUBLES.</summary>
		D3D11_FEATURE_DOUBLES,

		/// <summary>Supports the formats in D3D11_FORMAT_SUPPORT. Refer to D3D11_FEATURE_DATA_FORMAT_SUPPORT.</summary>
		D3D11_FEATURE_FORMAT_SUPPORT,

		/// <summary>Supports the formats in D3D11_FORMAT_SUPPORT2. Refer to D3D11_FEATURE_DATA_FORMAT_SUPPORT2.</summary>
		D3D11_FEATURE_FORMAT_SUPPORT2,

		/// <summary>Supports compute shaders and raw and structured buffers. Refer to D3D11_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS.</summary>
		D3D11_FEATURE_D3D10_X_HARDWARE_OPTIONS,

		/// <summary>
		/// <para>Supports Direct3D 11.1 feature options. Refer to D3D11_FEATURE_DATA_D3D11_OPTIONS.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_FEATURE_D3D11_OPTIONS,

		/// <summary>
		/// <para>Supports specific adapter architecture. Refer to D3D11_FEATURE_DATA_ARCHITECTURE_INFO.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_FEATURE_ARCHITECTURE_INFO,

		/// <summary>
		/// <para>Supports Direct3D 9 feature options. Refer to D3D11_FEATURE_DATA_D3D9_OPTIONS.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_FEATURE_D3D9_OPTIONS,

		/// <summary>
		/// <para>
		/// Supports minimum precision of shaders. For more info about HLSL minimum precision, see using HLSL minimum precision. Refer to D3D11_FEATURE_DATA_SHADER_MIN_PRECISION_SUPPORT.
		/// </para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_FEATURE_SHADER_MIN_PRECISION_SUPPORT,

		/// <summary>
		/// <para>Supports Direct3D 9 shadowing feature. Refer to D3D11_FEATURE_DATA_D3D9_SHADOW_SUPPORT.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_FEATURE_D3D9_SHADOW_SUPPORT,

		/// <summary>
		/// <para>Supports Direct3D 11.2 feature options. Refer to D3D11_FEATURE_DATA_D3D11_OPTIONS1.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.2.</para>
		/// </summary>
		D3D11_FEATURE_D3D11_OPTIONS1,

		/// <summary>
		/// <para>Supports Direct3D 11.2 instancing options. Refer to D3D11_FEATURE_DATA_D3D9_SIMPLE_INSTANCING_SUPPORT.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.2.</para>
		/// </summary>
		D3D11_FEATURE_D3D9_SIMPLE_INSTANCING_SUPPORT,

		/// <summary>
		/// <para>Supports Direct3D 11.2 marker options. Refer to D3D11_FEATURE_DATA_MARKER_SUPPORT.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.2.</para>
		/// </summary>
		D3D11_FEATURE_MARKER_SUPPORT,

		/// <summary>
		/// <para>
		/// Supports Direct3D 9 feature options, which includes the Direct3D 9 shadowing feature and instancing support. Refer to D3D11_FEATURE_DATA_D3D9_OPTIONS1.
		/// </para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.2.</para>
		/// </summary>
		D3D11_FEATURE_D3D9_OPTIONS1,

		/// <summary>
		/// <para>Supports Direct3D 11.3 conservative rasterization feature options. Refer to D3D11_FEATURE_DATA_D3D11_OPTIONS2.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.3.</para>
		/// </summary>
		D3D11_FEATURE_D3D11_OPTIONS2,

		/// <summary>
		/// <para>Supports Direct3D 11.4 conservative rasterization feature options. Refer to D3D11_FEATURE_DATA_D3D11_OPTIONS3.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.4.</para>
		/// </summary>
		D3D11_FEATURE_D3D11_OPTIONS3,

		/// <summary>Supports GPU virtual addresses. Refer to D3D11_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT.</summary>
		D3D11_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT,

		/// <summary>
		/// <para>Supports a single boolean for NV12 shared textures. Refer to D3D11_FEATURE_DATA_D3D11_OPTIONS4 .</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.4.</para>
		/// </summary>
		D3D11_FEATURE_D3D11_OPTIONS4,

		/// <summary>Supports shader cache, described in D3D11_FEATURE_DATA_SHADER_CACHE.</summary>
		D3D11_FEATURE_SHADER_CACHE,

		/// <summary>
		/// Supports a D3D11_SHARED_RESOURCE_TIER to indicate the level of support for shared resources in the current graphics driver.
		/// Refer to D3D11_FEATURE_DATA_D3D11_OPTIONS5.
		/// </summary>
		D3D11_FEATURE_D3D11_OPTIONS5,

		/// <summary>Supports displayable surfaces, described in D3D11_FEATURE_DATA_DISPLAYABLE.</summary>
		D3D11_FEATURE_DISPLAYABLE,
	}

	/// <summary>Determines the fill mode to use when rendering triangles.</summary>
	/// <remarks>This enumeration is part of a rasterizer-state object description (see D3D11_RASTERIZER_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_fill_mode typedef enum D3D11_FILL_MODE {
	// D3D11_FILL_WIREFRAME = 2, D3D11_FILL_SOLID = 3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_FILL_MODE")]
	public enum D3D11_FILL_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Draw lines connecting the vertices. Adjacent vertices are not drawn.</para>
		/// </summary>
		D3D11_FILL_WIREFRAME = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Fill the triangles formed by the vertices. Adjacent vertices are not drawn.</para>
		/// </summary>
		D3D11_FILL_SOLID,
	}

	/// <summary>Filtering options during texture sampling.</summary>
	/// <remarks>
	/// <para>
	/// <c>Note</c>  If you use different filter types for min versus mag filter, undefined behavior occurs in certain cases where the
	/// choice between whether magnification or minification happens is ambiguous. To prevent this undefined behavior, use filter modes that
	/// use similar filter operations for both min and mag (or use anisotropic filtering, which avoids the issue as well).
	/// </para>
	/// <para></para>
	/// <para>
	/// During texture sampling, one or more texels are read and combined (this is calling filtering) to produce a single value. Point
	/// sampling reads a single texel while linear sampling reads two texels (endpoints) and linearly interpolates a third value between the endpoints.
	/// </para>
	/// <para>
	/// HLSL texture-sampling functions also support comparison filtering during texture sampling. Comparison filtering compares each
	/// sampled texel against a comparison value. The boolean result is blended the same way that normal texture filtering is blended.
	/// </para>
	/// <para>
	/// You can use HLSL intrinsic texture-sampling functions that implement texture filtering only or companion functions that use texture
	/// filtering with comparison filtering.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Texture Sampling Function</description>
	/// <description>Texture Sampling Function with Comparison Filtering</description>
	/// </listheader>
	/// <item>
	/// <description>sample</description>
	/// <description>samplecmp or samplecmplevelzero</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>
	/// Comparison filters only work with textures that have the following DXGI formats: R32_FLOAT_X8X24_TYPELESS, R32_FLOAT,
	/// R24_UNORM_X8_TYPELESS, R16_UNORM.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_filter typedef enum D3D11_FILTER {
	// D3D11_FILTER_MIN_MAG_MIP_POINT = 0, D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR = 0x1, D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x4,
	// D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR = 0x5, D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT = 0x10,
	// D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x11, D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT = 0x14, D3D11_FILTER_MIN_MAG_MIP_LINEAR =
	// 0x15, D3D11_FILTER_ANISOTROPIC = 0x55, D3D11_FILTER_COMPARISON_MIN_MAG_MIP_POINT = 0x80,
	// D3D11_FILTER_COMPARISON_MIN_MAG_POINT_MIP_LINEAR = 0x81, D3D11_FILTER_COMPARISON_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x84,
	// D3D11_FILTER_COMPARISON_MIN_POINT_MAG_MIP_LINEAR = 0x85, D3D11_FILTER_COMPARISON_MIN_LINEAR_MAG_MIP_POINT = 0x90,
	// D3D11_FILTER_COMPARISON_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x91, D3D11_FILTER_COMPARISON_MIN_MAG_LINEAR_MIP_POINT = 0x94,
	// D3D11_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR = 0x95, D3D11_FILTER_COMPARISON_ANISOTROPIC = 0xd5, D3D11_FILTER_MINIMUM_MIN_MAG_MIP_POINT
	// = 0x100, D3D11_FILTER_MINIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x101, D3D11_FILTER_MINIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x104,
	// D3D11_FILTER_MINIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x105, D3D11_FILTER_MINIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x110,
	// D3D11_FILTER_MINIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x111, D3D11_FILTER_MINIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x114,
	// D3D11_FILTER_MINIMUM_MIN_MAG_MIP_LINEAR = 0x115, D3D11_FILTER_MINIMUM_ANISOTROPIC = 0x155, D3D11_FILTER_MAXIMUM_MIN_MAG_MIP_POINT =
	// 0x180, D3D11_FILTER_MAXIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x181, D3D11_FILTER_MAXIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x184,
	// D3D11_FILTER_MAXIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x185, D3D11_FILTER_MAXIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x190,
	// D3D11_FILTER_MAXIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x191, D3D11_FILTER_MAXIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x194,
	// D3D11_FILTER_MAXIMUM_MIN_MAG_MIP_LINEAR = 0x195, D3D11_FILTER_MAXIMUM_ANISOTROPIC = 0x1d5 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_FILTER")]
	[Flags]
	public enum D3D11_FILTER
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Use point sampling for minification, magnification, and mip-level sampling.</para>
		/// </summary>
		D3D11_FILTER_MIN_MAG_MIP_POINT = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Use point sampling for minification and magnification; use linear interpolation for mip-level sampling.</para>
		/// </summary>
		D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling.</para>
		/// </summary>
		D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT = 4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x5</para>
		/// <para>Use point sampling for minification; use linear interpolation for magnification and mip-level sampling.</para>
		/// </summary>
		D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR = 5,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Use linear interpolation for minification; use point sampling for magnification and mip-level sampling.</para>
		/// </summary>
		D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x11</para>
		/// <para>
		/// Use linear interpolation for minification; use point sampling for magnification; use linear interpolation for mip-level sampling.
		/// </para>
		/// </summary>
		D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x11,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x14</para>
		/// <para>Use linear interpolation for minification and magnification; use point sampling for mip-level sampling.</para>
		/// </summary>
		D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT = 0x14,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x15</para>
		/// <para>Use linear interpolation for minification, magnification, and mip-level sampling.</para>
		/// </summary>
		D3D11_FILTER_MIN_MAG_MIP_LINEAR = 0x15,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x55</para>
		/// <para>Use anisotropic interpolation for minification, magnification, and mip-level sampling.</para>
		/// </summary>
		D3D11_FILTER_ANISOTROPIC = 0x55,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>Use point sampling for minification, magnification, and mip-level sampling. Compare the result to the comparison value.</para>
		/// </summary>
		D3D11_FILTER_COMPARISON_MIN_MAG_MIP_POINT = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x81</para>
		/// <para>
		/// Use point sampling for minification and magnification; use linear interpolation for mip-level sampling. Compare the result to
		/// the comparison value.
		/// </para>
		/// </summary>
		D3D11_FILTER_COMPARISON_MIN_MAG_POINT_MIP_LINEAR = 0x81,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x84</para>
		/// <para>
		/// Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling.
		/// Compare the result to the comparison value.
		/// </para>
		/// </summary>
		D3D11_FILTER_COMPARISON_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x84,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x85</para>
		/// <para>
		/// Use point sampling for minification; use linear interpolation for magnification and mip-level sampling. Compare the result to
		/// the comparison value.
		/// </para>
		/// </summary>
		D3D11_FILTER_COMPARISON_MIN_POINT_MAG_MIP_LINEAR = 0x85,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x90</para>
		/// <para>
		/// Use linear interpolation for minification; use point sampling for magnification and mip-level sampling. Compare the result to
		/// the comparison value.
		/// </para>
		/// </summary>
		D3D11_FILTER_COMPARISON_MIN_LINEAR_MAG_MIP_POINT = 0x90,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x91</para>
		/// <para>
		/// Use linear interpolation for minification; use point sampling for magnification; use linear interpolation for mip-level
		/// sampling. Compare the result to the comparison value.
		/// </para>
		/// </summary>
		D3D11_FILTER_COMPARISON_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x91,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x94</para>
		/// <para>
		/// Use linear interpolation for minification and magnification; use point sampling for mip-level sampling. Compare the result to
		/// the comparison value.
		/// </para>
		/// </summary>
		D3D11_FILTER_COMPARISON_MIN_MAG_LINEAR_MIP_POINT = 0x94,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x95</para>
		/// <para>
		/// Use linear interpolation for minification, magnification, and mip-level sampling. Compare the result to the comparison value.
		/// </para>
		/// </summary>
		D3D11_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR = 0x95,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xd5</para>
		/// <para>
		/// Use anisotropic interpolation for minification, magnification, and mip-level sampling. Compare the result to the comparison value.
		/// </para>
		/// </summary>
		D3D11_FILTER_COMPARISON_ANISOTROPIC = 0xd5,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_MAG_MIP_POINT and instead of filtering them return the minimum of the texels.
		/// Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter type from
		/// the MinMaxFiltering member in the 3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MINIMUM_MIN_MAG_MIP_POINT = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x101</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR and instead of filtering them return the minimum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MINIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x101,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x104</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT and instead of filtering them return the minimum of
		/// the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this
		/// filter type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MINIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x104,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x105</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR and instead of filtering them return the minimum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MINIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x105,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x110</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT and instead of filtering them return the minimum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MINIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x110,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x111</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR and instead of filtering them return the minimum of
		/// the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this
		/// filter type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MINIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x111,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x114</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT and instead of filtering them return the minimum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MINIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x114,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x115</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_MAG_MIP_LINEAR and instead of filtering them return the minimum of the texels.
		/// Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter type from
		/// the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MINIMUM_MIN_MAG_MIP_LINEAR = 0x115,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x155</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_ANISOTROPIC and instead of filtering them return the minimum of the texels. Texels
		/// that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter type from the
		/// MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MINIMUM_ANISOTROPIC = 0x155,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x180</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_MAG_MIP_POINT and instead of filtering them return the maximum of the texels.
		/// Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter type from
		/// the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MAXIMUM_MIN_MAG_MIP_POINT = 0x180,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x181</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR and instead of filtering them return the maximum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MAXIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x181,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x184</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT and instead of filtering them return the maximum of
		/// the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this
		/// filter type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MAXIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x184,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x185</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR and instead of filtering them return the maximum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MAXIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x185,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x190</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT and instead of filtering them return the maximum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MAXIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x190,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x191</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR and instead of filtering them return the maximum of
		/// the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this
		/// filter type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MAXIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x191,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x194</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT and instead of filtering them return the maximum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MAXIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x194,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x195</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_MIN_MAG_MIP_LINEAR and instead of filtering them return the maximum of the texels.
		/// Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter type from
		/// the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MAXIMUM_MIN_MAG_MIP_LINEAR = 0x195,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1d5</para>
		/// <para>
		/// Fetch the same set of texels as D3D11_FILTER_ANISOTROPIC and instead of filtering them return the maximum of the texels. Texels
		/// that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter type from the
		/// MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D11_FILTER_MAXIMUM_ANISOTROPIC = 0x1d5,
	}

	/// <summary>Specifies the type of sampler filter reduction.</summary>
	/// <remarks>This enum is used by the D3D11_SAMPLER_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_filter_reduction_type typedef enum
	// D3D11_FILTER_REDUCTION_TYPE { D3D11_FILTER_REDUCTION_TYPE_STANDARD = 0, D3D11_FILTER_REDUCTION_TYPE_COMPARISON = 1,
	// D3D11_FILTER_REDUCTION_TYPE_MINIMUM = 2, D3D11_FILTER_REDUCTION_TYPE_MAXIMUM = 3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_FILTER_REDUCTION_TYPE")]
	public enum D3D11_FILTER_REDUCTION_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Indicates standard (default) filter reduction.</para>
		/// </summary>
		D3D11_FILTER_REDUCTION_TYPE_STANDARD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Indicates a comparison filter reduction.</para>
		/// </summary>
		D3D11_FILTER_REDUCTION_TYPE_COMPARISON,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Indicates minimum filter reduction.</para>
		/// </summary>
		D3D11_FILTER_REDUCTION_TYPE_MINIMUM,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Indicates maximum filter reduction.</para>
		/// </summary>
		D3D11_FILTER_REDUCTION_TYPE_MAXIMUM,
	}

	/// <summary>Types of magnification or minification sampler filters.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_filter_type typedef enum D3D11_FILTER_TYPE {
	// D3D11_FILTER_TYPE_POINT = 0, D3D11_FILTER_TYPE_LINEAR = 1 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_FILTER_TYPE")]
	public enum D3D11_FILTER_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Point filtering used as a texture magnification or minification filter. The texel with coordinates nearest to the desired pixel
		/// value is used. The texture filter to be used between mipmap levels is nearest-point mipmap filtering. The rasterizer uses the
		/// color from the texel of the nearest mipmap texture.
		/// </para>
		/// </summary>
		D3D11_FILTER_TYPE_POINT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Bilinear interpolation filtering used as a texture magnification or minification filter. A weighted average of a 2 x 2 area of
		/// texels surrounding the desired pixel is used. The texture filter to use between mipmap levels is trilinear mipmap interpolation.
		/// The rasterizer linearly interpolates pixel color, using the texels of the two nearest mipmap textures.
		/// </para>
		/// </summary>
		D3D11_FILTER_TYPE_LINEAR,
	}

	/// <summary>Which resources are supported for a given format and given device (see ID3D11Device::CheckFormatSupport and ID3D11Device::CheckFeatureSupport).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_format_support typedef enum D3D11_FORMAT_SUPPORT {
	// D3D11_FORMAT_SUPPORT_BUFFER = 0x1, D3D11_FORMAT_SUPPORT_IA_VERTEX_BUFFER = 0x2, D3D11_FORMAT_SUPPORT_IA_INDEX_BUFFER = 0x4,
	// D3D11_FORMAT_SUPPORT_SO_BUFFER = 0x8, D3D11_FORMAT_SUPPORT_TEXTURE1D = 0x10, D3D11_FORMAT_SUPPORT_TEXTURE2D = 0x20,
	// D3D11_FORMAT_SUPPORT_TEXTURE3D = 0x40, D3D11_FORMAT_SUPPORT_TEXTURECUBE = 0x80, D3D11_FORMAT_SUPPORT_SHADER_LOAD = 0x100,
	// D3D11_FORMAT_SUPPORT_SHADER_SAMPLE = 0x200, D3D11_FORMAT_SUPPORT_SHADER_SAMPLE_COMPARISON = 0x400,
	// D3D11_FORMAT_SUPPORT_SHADER_SAMPLE_MONO_TEXT = 0x800, D3D11_FORMAT_SUPPORT_MIP = 0x1000, D3D11_FORMAT_SUPPORT_MIP_AUTOGEN = 0x2000,
	// D3D11_FORMAT_SUPPORT_RENDER_TARGET = 0x4000, D3D11_FORMAT_SUPPORT_BLENDABLE = 0x8000, D3D11_FORMAT_SUPPORT_DEPTH_STENCIL = 0x10000,
	// D3D11_FORMAT_SUPPORT_CPU_LOCKABLE = 0x20000, D3D11_FORMAT_SUPPORT_MULTISAMPLE_RESOLVE = 0x40000, D3D11_FORMAT_SUPPORT_DISPLAY =
	// 0x80000, D3D11_FORMAT_SUPPORT_CAST_WITHIN_BIT_LAYOUT = 0x100000, D3D11_FORMAT_SUPPORT_MULTISAMPLE_RENDERTARGET = 0x200000,
	// D3D11_FORMAT_SUPPORT_MULTISAMPLE_LOAD = 0x400000, D3D11_FORMAT_SUPPORT_SHADER_GATHER = 0x800000,
	// D3D11_FORMAT_SUPPORT_BACK_BUFFER_CAST = 0x1000000, D3D11_FORMAT_SUPPORT_TYPED_UNORDERED_ACCESS_VIEW = 0x2000000,
	// D3D11_FORMAT_SUPPORT_SHADER_GATHER_COMPARISON = 0x4000000, D3D11_FORMAT_SUPPORT_DECODER_OUTPUT = 0x8000000,
	// D3D11_FORMAT_SUPPORT_VIDEO_PROCESSOR_OUTPUT = 0x10000000, D3D11_FORMAT_SUPPORT_VIDEO_PROCESSOR_INPUT = 0x20000000,
	// D3D11_FORMAT_SUPPORT_VIDEO_ENCODER = 0x40000000 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_FORMAT_SUPPORT")]
	[Flags]
	public enum D3D11_FORMAT_SUPPORT : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Buffer resources supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_BUFFER = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Vertex buffers supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_IA_VERTEX_BUFFER = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Index buffers supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_IA_INDEX_BUFFER = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>Streaming output buffers supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_SO_BUFFER = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>1D texture resources supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_TEXTURE1D = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>2D texture resources supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_TEXTURE2D = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>3D texture resources supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_TEXTURE3D = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>Cube texture resources supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_TEXTURECUBE = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>The HLSL Load function for texture objects is supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_SHADER_LOAD = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200</para>
		/// <para>The HLSL Sample function for texture objects is supported.</para>
		/// <para>
		/// <c>Note</c> If the device supports the format as a resource (1D, 2D, 3D, or cube map) but doesn't support this option, the
		/// resource can still use the Sample method but must use only the point filtering sampler state to perform the sample.
		/// </para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_SHADER_SAMPLE = 0x200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400</para>
		/// <para>The HLSL SampleCmp and SampleCmpLevelZero functions for texture objects are supported.</para>
		/// <para>
		/// <c>Note</c>  Windows 8 and later might provide limited support for these functions on Direct3D feature levels 9_1, 9_2, and 9_3.
		/// For more info, see Implementing shadow buffers for Direct3D feature level 9.
		/// </para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_SHADER_SAMPLE_COMPARISON = 0x400,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800</para>
		/// <para>Reserved.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_SHADER_SAMPLE_MONO_TEXT = 0x800,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1000</para>
		/// <para>Mipmaps are supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_MIP = 0x1000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2000</para>
		/// <para>Automatic generation of mipmaps is supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_MIP_AUTOGEN = 0x2000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4000</para>
		/// <para>Render targets are supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_RENDER_TARGET = 0x4000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8000</para>
		/// <para>Blend operations supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_BLENDABLE = 0x8000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10000</para>
		/// <para>Depth stencils supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_DEPTH_STENCIL = 0x10000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000</para>
		/// <para>CPU locking supported.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_CPU_LOCKABLE = 0x20000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40000</para>
		/// <para>Multisample antialiasing (MSAA) resolve operations are supported. For more info, see ID3D11DeviceContex::ResolveSubresource.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_MULTISAMPLE_RESOLVE = 0x40000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000</para>
		/// <para>Format can be displayed on screen.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_DISPLAY = 0x80000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100000</para>
		/// <para>Format cannot be cast to another format.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_CAST_WITHIN_BIT_LAYOUT = 0x100000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200000</para>
		/// <para>Format can be used as a multisampled rendertarget.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_MULTISAMPLE_RENDERTARGET = 0x200000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400000</para>
		/// <para>Format can be used as a multisampled texture and read into a shader with the HLSL load function.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_MULTISAMPLE_LOAD = 0x400000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800000</para>
		/// <para>Format can be used with the HLSL gather function. This value is available in DirectX 10.1 or higher.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_SHADER_GATHER = 0x800000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1000000</para>
		/// <para>Format supports casting when the resource is a back buffer.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_BACK_BUFFER_CAST = 0x1000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2000000</para>
		/// <para>Format can be used for an unordered access view.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_TYPED_UNORDERED_ACCESS_VIEW = 0x2000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4000000</para>
		/// <para>Format can be used with the HLSL gather with comparison function.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_SHADER_GATHER_COMPARISON = 0x4000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8000000</para>
		/// <para>Format can be used with the decoder output.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_DECODER_OUTPUT = 0x8000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10000000</para>
		/// <para>Format can be used with the video processor output.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_VIDEO_PROCESSOR_OUTPUT = 0x10000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000000</para>
		/// <para>Format can be used with the video processor input.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_VIDEO_PROCESSOR_INPUT = 0x20000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40000000</para>
		/// <para>Format can be used with the video encoder.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT_VIDEO_ENCODER = 0x40000000,
	}

	/// <summary>Unordered resource support options for a compute shader resource (see ID3D11Device::CheckFeatureSupport).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_format_support2 typedef enum D3D11_FORMAT_SUPPORT2 {
	// D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_ADD = 0x1, D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_BITWISE_OPS = 0x2,
	// D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_COMPARE_STORE_OR_COMPARE_EXCHANGE = 0x4, D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_EXCHANGE = 0x8,
	// D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_SIGNED_MIN_OR_MAX = 0x10, D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_UNSIGNED_MIN_OR_MAX = 0x20,
	// D3D11_FORMAT_SUPPORT2_UAV_TYPED_LOAD = 0x40, D3D11_FORMAT_SUPPORT2_UAV_TYPED_STORE = 0x80,
	// D3D11_FORMAT_SUPPORT2_OUTPUT_MERGER_LOGIC_OP = 0x100, D3D11_FORMAT_SUPPORT2_TILED = 0x200, D3D11_FORMAT_SUPPORT2_SHAREABLE = 0x400,
	// D3D11_FORMAT_SUPPORT2_MULTIPLANE_OVERLAY = 0x4000, D3D11_FORMAT_SUPPORT2_DISPLAYABLE } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_FORMAT_SUPPORT2")]
	public enum D3D11_FORMAT_SUPPORT2
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Format supports atomic add.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_ADD = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Format supports atomic bitwise operations.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_BITWISE_OPS = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Format supports atomic compare with store or exchange.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_COMPARE_STORE_OR_COMPARE_EXCHANGE = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>Format supports atomic exchange.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_EXCHANGE = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Format supports atomic min and max.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_SIGNED_MIN_OR_MAX = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>Format supports atomic unsigned min and max.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_UAV_ATOMIC_UNSIGNED_MIN_OR_MAX = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>Format supports a typed load.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_UAV_TYPED_LOAD = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>Format supports a typed store.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_UAV_TYPED_STORE = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>Format supports logic operations in blend state.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_OUTPUT_MERGER_LOGIC_OP = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200</para>
		/// <para>Format supports tiled resources.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.2.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_TILED = 0x200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400</para>
		/// <para>Format supports shareable resources.</para>
		/// <para>
		/// <c>Note</c>  DXGI_FORMAT_R8G8B8A8_UNORM and <c>DXGI_FORMAT_R8G8B8A8_UNORM_SRGB</c> are never shareable when using feature level
		/// 9, even if the device indicates optional feature support for <c>D3D11_FORMAT_SUPPORT_SHAREABLE</c>. Attempting to create shared
		/// resources with DXGI formats <c>DXGI_FORMAT_R8G8B8A8_UNORM</c> and <c>DXGI_FORMAT_R8G8B8A8_UNORM_SRGB</c> will always fail unless
		/// the feature level is 10_0 or higher.
		/// </para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.2.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_SHAREABLE = 0x400,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4000</para>
		/// <para>Format supports multi-plane overlays.</para>
		/// </summary>
		D3D11_FORMAT_SUPPORT2_MULTIPLANE_OVERLAY = 0x4000,
	}

	/// <summary>Type of data contained in an input slot.</summary>
	/// <remarks>
	/// Use these values to specify the type of data for a particular input element (see D3D11_INPUT_ELEMENT_DESC) of an input-layout object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_input_classification typedef enum D3D11_INPUT_CLASSIFICATION
	// { D3D11_INPUT_PER_VERTEX_DATA = 0, D3D11_INPUT_PER_INSTANCE_DATA = 1 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_INPUT_CLASSIFICATION")]
	public enum D3D11_INPUT_CLASSIFICATION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Input data is per-vertex data.</para>
		/// </summary>
		D3D11_INPUT_PER_VERTEX_DATA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Input data is per-instance data.</para>
		/// </summary>
		D3D11_INPUT_PER_INSTANCE_DATA,
	}

	/// <summary>
	/// Identifies a resource to be accessed for reading and writing by the CPU. Applications may combine one or more of these flags.
	/// </summary>
	/// <remarks>
	/// <para>This enumeration is used in ID3D11DeviceContext::Map.</para>
	/// <para>Meaning of D3D11_MAP_WRITE_NO_OVERWRITE</para>
	/// <para>
	/// <c>D3D11_MAP_WRITE_NO_OVERWRITE</c> signifies that the application promises not to write to data that the input assembler (IA) stage
	/// is using. In exchange, the GPU allows the application to write to other parts of the same buffer. The application must ensure that
	/// it does not write over any data in use by the IA stage.
	/// </para>
	/// <para>
	/// For example, consider the buffer illustrated in the following diagram. If a Draw call has been issued that uses vertices 4-6, then
	/// an application that calls Map on this buffer must ensure that it does not write to the vertices that the <c>Draw</c> call will
	/// access during rendering.
	/// </para>
	/// <para>
	/// However, ensuring this can be difficult, because the GPU is often many frames behind the CPU in terms of which frame it is currently
	/// processing. Keeping track of which sections of a resource are being used because of calls made 2 to 5 frames ago is difficult and
	/// error-prone. Because of this, it is recommended that applications only write to the uninitialized portions of a resource when using <c>D3D11_MAP_WRITE_NO_OVERWRITE</c>.
	/// </para>
	/// <para>Common Usage of D3D11_MAP_WRITE_DISCARD with D3D11_MAP_WRITE_NO_OVERWRITE</para>
	/// <para>
	/// <c>D3D11_MAP_WRITE_DISCARD</c> and <c>D3D11_MAP_WRITE_NO_OVERWRITE</c> are normally used in conjunction with dynamic index/vertex
	/// buffers. <c>D3D11_MAP_WRITE_DISCARD</c> can also be used with dynamic textures. However, <c>D3D11_MAP_WRITE_NO_OVERWRITE</c> cannot
	/// be used with dynamic textures.
	/// </para>
	/// <para>
	/// A common use of these two flags involves filling dynamic index/vertex buffers with geometry that can be seen from the camera's
	/// current position. The first time that data is entered into the buffer on a given frame, Map is called with
	/// <c>D3D11_MAP_WRITE_DISCARD</c>; doing so invalidates the previous contents of the buffer. The buffer is then filled with all
	/// available data.
	/// </para>
	/// <para>
	/// Subsequent writes to the buffer within the same frame should use <c>D3D11_MAP_WRITE_NO_OVERWRITE</c>. This will enable the CPU to
	/// access a resource that is potentially being used by the GPU as long as the restrictions described previously are respected.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_map typedef enum D3D11_MAP { D3D11_MAP_READ = 1,
	// D3D11_MAP_WRITE = 2, D3D11_MAP_READ_WRITE = 3, D3D11_MAP_WRITE_DISCARD = 4, D3D11_MAP_WRITE_NO_OVERWRITE = 5 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_MAP")]
	public enum D3D11_MAP
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Resource is mapped for reading. The resource must have been created with read access (see D3D11_CPU_ACCESS_READ).</para>
		/// </summary>
		D3D11_MAP_READ = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Resource is mapped for writing. The resource must have been created with write access (see D3D11_CPU_ACCESS_WRITE).</para>
		/// </summary>
		D3D11_MAP_WRITE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>
		/// Resource is mapped for reading and writing. The resource must have been created with read and write access (see
		/// D3D11_CPU_ACCESS_READ and D3D11_CPU_ACCESS_WRITE).
		/// </para>
		/// </summary>
		D3D11_MAP_READ_WRITE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>
		/// Resource is mapped for writing; the previous contents of the resource will be undefined. The resource must have been created
		/// with write access and dynamic usage (See D3D11_CPU_ACCESS_WRITE and D3D11_USAGE_DYNAMIC).
		/// </para>
		/// </summary>
		D3D11_MAP_WRITE_DISCARD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>
		/// Resource is mapped for writing; the existing contents of the resource cannot be overwritten (see Remarks). This flag is only
		/// valid on vertex and index buffers. The resource must have been created with write access (see D3D11_CPU_ACCESS_WRITE).
		/// </para>
		/// <para>Cannot be used on a resource created with the D3D11_BIND_CONSTANT_BUFFER flag.</para>
		/// <note>The Direct3D 11.1 runtime, which is available starting with Windows 8, enables mapping dynamic constant buffers and shader
		/// resource views (SRVs) of dynamic buffers with D3D11_MAP_WRITE_NO_OVERWRITE. The Direct3D 11 and earlier runtimes limited mapping
		/// to vertex or index buffers. To determine if a Direct3D device supports these features, call ID3D11Device::CheckFeatureSupport
		/// with D3D11_FEATURE_D3D11_OPTIONS. <c>CheckFeatureSupport</c> fills members of a D3D11_FEATURE_DATA_D3D11_OPTIONS structure with
		/// the device's features. The relevant members here are <c>MapNoOverwriteOnDynamicConstantBuffer</c> and <c>MapNoOverwriteOnDynamicBufferSRV</c>.</note>
		/// </summary>
		D3D11_MAP_WRITE_NO_OVERWRITE,
	}

	/// <summary>
	/// Specifies how the CPU should respond when an application calls the ID3D11DeviceContext::Map method on a resource that is being used
	/// by the GPU.
	/// </summary>
	/// <remarks>
	/// <para>This enumeration is used by ID3D11DeviceContext::Map.</para>
	/// <para>D3D11_MAP_FLAG_DO_NOT_WAIT cannot be used with D3D11_MAP_WRITE_DISCARD or D3D11_MAP_WRITE_NOOVERWRITE.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_map_flag typedef enum D3D11_MAP_FLAG {
	// D3D11_MAP_FLAG_DO_NOT_WAIT = 0x100000L } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_MAP_FLAG")]
	[Flags]
	public enum D3D11_MAP_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100000L</para>
		/// <para>Specifies that</para>
		/// <para>ID3D11DeviceContext::Map</para>
		/// <para>
		/// should return DXGI_ERROR_WAS_STILL_DRAWING when the GPU blocks the CPU from accessing a resource. For more information about
		/// this error code, see
		/// </para>
		/// <para>DXGI_ERROR</para>
		/// <para>.</para>
		/// </summary>
		D3D11_MAP_FLAG_DO_NOT_WAIT = 0x100000,
	}

	/// <summary>
	/// How the pipeline interprets vertex data that is bound to the input-assembler stage. These primitive topology values determine how
	/// the vertex data is rendered on screen.
	/// </summary>
	/// <remarks>
	/// The <c>D3D11_PRIMITIVE_TOPOLOGY</c> enumeration is type defined in the D3D11.h header file as a <c>D3D_PRIMITIVE_TOPOLOGY</c>
	/// enumeration, which is fully defined in the D3DCommon.h header file.
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ff476189(v=vs.85) typedef enum D3D11_PRIMITIVE_TOPOLOGY {
	// D3D11_PRIMITIVE_TOPOLOGY_UNDEFINED= 0, D3D11_PRIMITIVE_TOPOLOGY_POINTLIST= 1, D3D11_PRIMITIVE_TOPOLOGY_LINELIST= 2,
	// D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP= 3, D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST= 4, D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP= 5,
	// D3D11_PRIMITIVE_TOPOLOGY_LINELIST_ADJ= 10, D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ= 11, D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ= 12,
	// D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ= 13, D3D11_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST= 33,
	// D3D11_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST= 34, D3D11_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST= 35,
	// D3D11_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST= 36, D3D11_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST= 37,
	// D3D11_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST= 38, D3D11_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST= 39,
	// D3D11_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST= 40, D3D11_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST= 41,
	// D3D11_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST= 42, D3D11_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST= 43,
	// D3D11_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST= 44, D3D11_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST= 45,
	// D3D11_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST= 46, D3D11_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST= 47,
	// D3D11_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST= 48, D3D11_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST= 49,
	// D3D11_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST= 50, D3D11_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST= 51,
	// D3D11_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST= 52, D3D11_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST= 53,
	// D3D11_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST= 54, D3D11_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST= 55,
	// D3D11_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST= 56, D3D11_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST= 57,
	// D3D11_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST= 58, D3D11_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST= 59,
	// D3D11_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST= 60, D3D11_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST= 61,
	// D3D11_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST= 62, D3D11_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST= 63,
	// D3D11_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST= 64 } D3D11_PRIMITIVE_TOPOLOGY;
	[PInvokeData("D3D11.h")]
	public enum D3D11_PRIMITIVE_TOPOLOGY
	{
		/// <summary>
		/// The IA stage has not been initialized with a primitive topology. The IA stage will not function properly unless a primitive
		/// topology is defined.
		/// </summary>
		D3D11_PRIMITIVE_TOPOLOGY_UNDEFINED = 0,

		/// <summary>Interpret the vertex data as a list of points.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_POINTLIST,

		/// <summary>Interpret the vertex data as a list of lines.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_LINELIST,

		/// <summary>Interpret the vertex data as a line strip.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP,

		/// <summary>Interpret the vertex data as a list of triangles.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST,

		/// <summary>Interpret the vertex data as a triangle strip.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP,

		/// <summary>Interpret the vertex data as list of lines with adjacency data.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_LINELIST_ADJ = 10,

		/// <summary>Interpret the vertex data as line strip with adjacency data.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ,

		/// <summary>Interpret the vertex data as list of triangles with adjacency data.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ,

		/// <summary>Interpret the vertex data as triangle strip with adjacency data.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST = 33,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST,
	}

	/// <summary>Query types.</summary>
	/// <remarks>Create a query with ID3D11Device::CreateQuery.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_query typedef enum D3D11_QUERY { D3D11_QUERY_EVENT = 0,
	// D3D11_QUERY_OCCLUSION, D3D11_QUERY_TIMESTAMP, D3D11_QUERY_TIMESTAMP_DISJOINT, D3D11_QUERY_PIPELINE_STATISTICS,
	// D3D11_QUERY_OCCLUSION_PREDICATE, D3D11_QUERY_SO_STATISTICS, D3D11_QUERY_SO_OVERFLOW_PREDICATE, D3D11_QUERY_SO_STATISTICS_STREAM0,
	// D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM0, D3D11_QUERY_SO_STATISTICS_STREAM1, D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM1,
	// D3D11_QUERY_SO_STATISTICS_STREAM2, D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM2, D3D11_QUERY_SO_STATISTICS_STREAM3,
	// D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_QUERY")]
	public enum D3D11_QUERY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Determines whether or not the GPU is finished processing commands. When the GPU is finished processing commands
		/// ID3D11DeviceContext::GetData will return S_OK, and pData will point to a BOOL with a value of TRUE. When using this type of
		/// query, ID3D11DeviceContext::Begin is disabled.
		/// </para>
		/// </summary>
		D3D11_QUERY_EVENT = 0,

		/// <summary>
		/// Get the number of samples that passed the depth and stencil tests in between ID3D11DeviceContext::Begin and
		/// ID3D11DeviceContext::End. ID3D11DeviceContext::GetData returns a UINT64. If a depth or stencil test is disabled, then each of
		/// those tests will be counted as a pass.
		/// </summary>
		D3D11_QUERY_OCCLUSION,

		/// <summary>
		/// Get a timestamp value where ID3D11DeviceContext::GetData returns a UINT64. This kind of query is only useful if two timestamp
		/// queries are done in the middle of a D3D11_QUERY_TIMESTAMP_DISJOINT query. The difference of two timestamps can be used to
		/// determine how many ticks have elapsed, and the D3D11_QUERY_TIMESTAMP_DISJOINT query will determine if that difference is a
		/// reliable value and also has a value that shows how to convert the number of ticks into seconds. See
		/// D3D11_QUERY_DATA_TIMESTAMP_DISJOINT. When using this type of query, ID3D11DeviceContext::Begin is disabled.
		/// </summary>
		D3D11_QUERY_TIMESTAMP,

		/// <summary>
		/// <para>
		/// Determines whether or not a D3D11_QUERY_TIMESTAMP is returning reliable values, and also gives the frequency of the processor
		/// enabling you to convert the number of elapsed ticks into seconds.
		/// </para>
		/// <para>
		/// ID3D11DeviceContext::GetData will return a D3D11_QUERY_DATA_TIMESTAMP_DISJOINT. This type of query should only be invoked once
		/// per frame or less.
		/// </para>
		/// </summary>
		D3D11_QUERY_TIMESTAMP_DISJOINT,

		/// <summary>
		/// <para>Get pipeline statistics, such as the number of pixel shader invocations in between ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.</para>
		/// <para>ID3D11DeviceContext::GetData will return a D3D11_QUERY_DATA_PIPELINE_STATISTICS.</para>
		/// </summary>
		D3D11_QUERY_PIPELINE_STATISTICS,

		/// <summary>
		/// Similar to D3D11_QUERY_OCCLUSION, except ID3D11DeviceContext::GetData returns a BOOL indicating whether or not any samples
		/// passed the depth and stencil tests - TRUE meaning at least one passed, FALSE meaning none passed.
		/// </summary>
		D3D11_QUERY_OCCLUSION_PREDICATE,

		/// <summary>
		/// <para>
		/// Get streaming output statistics, such as the number of primitives streamed out in between ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.
		/// </para>
		/// <para>ID3D11DeviceContext::GetData will return a D3D11_QUERY_DATA_SO_STATISTICS structure.</para>
		/// </summary>
		D3D11_QUERY_SO_STATISTICS,

		/// <summary>
		/// <para>Determines whether or not any of the streaming output buffers overflowed in between ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.</para>
		/// <para>
		/// ID3D11DeviceContext::GetData returns a BOOL - TRUE meaning there was an overflow, FALSE meaning there was not an overflow. If
		/// streaming output writes to multiple buffers, and one of the buffers overflows, then it will stop writing to all the output
		/// buffers. When an overflow is detected by Direct3D it is prevented from happening - no memory is corrupted. This predication may
		/// be used in conjunction with an SO_STATISTICS query so that when an overflow occurs the SO_STATISTIC query will let the
		/// application know how much memory was needed to prevent an overflow.
		/// </para>
		/// </summary>
		D3D11_QUERY_SO_OVERFLOW_PREDICATE,

		/// <summary>
		/// <para>
		/// Get streaming output statistics for stream 0, such as the number of primitives streamed out in between
		/// ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.
		/// </para>
		/// <para>ID3D11DeviceContext::GetData will return a D3D11_QUERY_DATA_SO_STATISTICS structure.</para>
		/// </summary>
		D3D11_QUERY_SO_STATISTICS_STREAM0,

		/// <summary>
		/// <para>Determines whether or not the stream 0 output buffers overflowed in between ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.</para>
		/// <para>
		/// ID3D11DeviceContext::GetData returns a BOOL - TRUE meaning there was an overflow, FALSE meaning there was not an overflow. If
		/// streaming output writes to multiple buffers, and one of the buffers overflows, then it will stop writing to all the output
		/// buffers. When an overflow is detected by Direct3D it is prevented from happening - no memory is corrupted. This predication may
		/// be used in conjunction with an SO_STATISTICS query so that when an overflow occurs the SO_STATISTIC query will let the
		/// application know how much memory was needed to prevent an overflow.
		/// </para>
		/// </summary>
		D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM0,

		/// <summary>
		/// <para>
		/// Get streaming output statistics for stream 1, such as the number of primitives streamed out in between
		/// ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.
		/// </para>
		/// <para>ID3D11DeviceContext::GetData will return a D3D11_QUERY_DATA_SO_STATISTICS structure.</para>
		/// </summary>
		D3D11_QUERY_SO_STATISTICS_STREAM1,

		/// <summary>
		/// <para>Determines whether or not the stream 1 output buffers overflowed in between ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.</para>
		/// <para>
		/// ID3D11DeviceContext::GetData returns a BOOL - TRUE meaning there was an overflow, FALSE meaning there was not an overflow. If
		/// streaming output writes to multiple buffers, and one of the buffers overflows, then it will stop writing to all the output
		/// buffers. When an overflow is detected by Direct3D it is prevented from happening - no memory is corrupted. This predication may
		/// be used in conjunction with an SO_STATISTICS query so that when an overflow occurs the SO_STATISTIC query will let the
		/// application know how much memory was needed to prevent an overflow.
		/// </para>
		/// </summary>
		D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM1,

		/// <summary>
		/// <para>
		/// Get streaming output statistics for stream 2, such as the number of primitives streamed out in between
		/// ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.
		/// </para>
		/// <para>ID3D11DeviceContext::GetData will return a D3D11_QUERY_DATA_SO_STATISTICS structure.</para>
		/// </summary>
		D3D11_QUERY_SO_STATISTICS_STREAM2,

		/// <summary>
		/// <para>Determines whether or not the stream 2 output buffers overflowed in between ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.</para>
		/// <para>
		/// ID3D11DeviceContext::GetData returns a BOOL - TRUE meaning there was an overflow, FALSE meaning there was not an overflow. If
		/// streaming output writes to multiple buffers, and one of the buffers overflows, then it will stop writing to all the output
		/// buffers. When an overflow is detected by Direct3D it is prevented from happening - no memory is corrupted. This predication may
		/// be used in conjunction with an SO_STATISTICS query so that when an overflow occurs the SO_STATISTIC query will let the
		/// application know how much memory was needed to prevent an overflow.
		/// </para>
		/// </summary>
		D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM2,

		/// <summary>
		/// <para>
		/// Get streaming output statistics for stream 3, such as the number of primitives streamed out in between
		/// ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.
		/// </para>
		/// <para>ID3D11DeviceContext::GetData will return a D3D11_QUERY_DATA_SO_STATISTICS structure.</para>
		/// </summary>
		D3D11_QUERY_SO_STATISTICS_STREAM3,

		/// <summary>
		/// <para>Determines whether or not the stream 3 output buffers overflowed in between ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.</para>
		/// <para>
		/// ID3D11DeviceContext::GetData returns a BOOL - TRUE meaning there was an overflow, FALSE meaning there was not an overflow. If
		/// streaming output writes to multiple buffers, and one of the buffers overflows, then it will stop writing to all the output
		/// buffers. When an overflow is detected by Direct3D it is prevented from happening - no memory is corrupted. This predication may
		/// be used in conjunction with an SO_STATISTICS query so that when an overflow occurs the SO_STATISTIC query will let the
		/// application know how much memory was needed to prevent an overflow.
		/// </para>
		/// </summary>
		D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM3,
	}

	/// <summary>Flags that describe miscellaneous query behavior.</summary>
	/// <remarks>This flag is part of a query description (see D3D11_QUERY_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_query_misc_flag typedef enum D3D11_QUERY_MISC_FLAG {
	// D3D11_QUERY_MISC_PREDICATEHINT = 0x1 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_QUERY_MISC_FLAG")]
	[Flags]
	public enum D3D11_QUERY_MISC_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>
		/// Tell the hardware that if it is not yet sure if something is hidden or not to draw it anyway. This is only used with an
		/// occlusion predicate. Predication data cannot be returned to your application via
		/// </para>
		/// <para>ID3D11DeviceContext::GetData</para>
		/// <para>when using this flag.</para>
		/// </summary>
		D3D11_QUERY_MISC_PREDICATEHINT = 0x1,
	}

	/// <summary>Option(s) for raising an error to a non-continuable exception.</summary>
	/// <remarks>
	/// These flags are used by ID3D11Device::GetExceptionMode and ID3D11Device::SetExceptionMode. Use 0 to indicate no flags; multiple
	/// flags can be logically OR'ed together.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_raise_flag typedef enum D3D11_RAISE_FLAG {
	// D3D11_RAISE_FLAG_DRIVER_INTERNAL_ERROR = 0x1L } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_RAISE_FLAG")]
	[Flags]
	public enum D3D11_RAISE_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1L</para>
		/// <para>Raise an internal driver error to a non-continuable exception.</para>
		/// </summary>
		D3D11_RAISE_FLAG_DRIVER_INTERNAL_ERROR = 0x1,
	}

	/// <summary>Identifies the type of resource being used.</summary>
	/// <remarks>This enumeration is used in ID3D11Resource::GetType.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_resource_dimension typedef enum D3D11_RESOURCE_DIMENSION {
	// D3D11_RESOURCE_DIMENSION_UNKNOWN = 0, D3D11_RESOURCE_DIMENSION_BUFFER = 1, D3D11_RESOURCE_DIMENSION_TEXTURE1D = 2,
	// D3D11_RESOURCE_DIMENSION_TEXTURE2D = 3, D3D11_RESOURCE_DIMENSION_TEXTURE3D = 4 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_RESOURCE_DIMENSION")]
	public enum D3D11_RESOURCE_DIMENSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Resource is of unknown type.</para>
		/// </summary>
		D3D11_RESOURCE_DIMENSION_UNKNOWN = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Resource is a buffer.</para>
		/// </summary>
		D3D11_RESOURCE_DIMENSION_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Resource is a 1D texture.</para>
		/// </summary>
		D3D11_RESOURCE_DIMENSION_TEXTURE1D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Resource is a 2D texture.</para>
		/// </summary>
		D3D11_RESOURCE_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Resource is a 3D texture.</para>
		/// </summary>
		D3D11_RESOURCE_DIMENSION_TEXTURE3D,
	}

	/// <summary>Identifies options for resources.</summary>
	/// <remarks>
	/// <para>This enumeration is used in D3D11_BUFFER_DESC, D3D11_TEXTURE1D_DESC, D3D11_TEXTURE2D_DESC, D3D11_TEXTURE3D_DESC.</para>
	/// <para>These flags can be combined by bitwise OR.</para>
	/// <para>The <c>D3D11_RESOURCE_MISC_FLAG</c> cannot be used when creating resources with <c>D3D11_CPU_ACCESS</c> flags.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_resource_misc_flag typedef enum D3D11_RESOURCE_MISC_FLAG {
	// D3D11_RESOURCE_MISC_GENERATE_MIPS = 0x1L, D3D11_RESOURCE_MISC_SHARED = 0x2L, D3D11_RESOURCE_MISC_TEXTURECUBE = 0x4L,
	// D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS = 0x10L, D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS = 0x20L,
	// D3D11_RESOURCE_MISC_BUFFER_STRUCTURED = 0x40L, D3D11_RESOURCE_MISC_RESOURCE_CLAMP = 0x80L, D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX =
	// 0x100L, D3D11_RESOURCE_MISC_GDI_COMPATIBLE = 0x200L, D3D11_RESOURCE_MISC_SHARED_NTHANDLE = 0x800L,
	// D3D11_RESOURCE_MISC_RESTRICTED_CONTENT = 0x1000L, D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE = 0x2000L,
	// D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE_DRIVER = 0x4000L, D3D11_RESOURCE_MISC_GUARDED = 0x8000L, D3D11_RESOURCE_MISC_TILE_POOL =
	// 0x20000L, D3D11_RESOURCE_MISC_TILED = 0x40000L, D3D11_RESOURCE_MISC_HW_PROTECTED = 0x80000L, D3D11_RESOURCE_MISC_SHARED_DISPLAYABLE,
	// D3D11_RESOURCE_MISC_SHARED_EXCLUSIVE_WRITER, D3D11_RESOURCE_MISC_NO_SHADER_ACCESS } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_RESOURCE_MISC_FLAG")]
	[Flags]
	public enum D3D11_RESOURCE_MISC_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1L</para>
		/// <para>
		/// Enables MIP map generation by using ID3D11DeviceContext::GenerateMips on a texture resource. The resource must be created with
		/// the bind flags that specify that the resource is a render target and a shader resource.
		/// </para>
		/// </summary>
		D3D11_RESOURCE_MISC_GENERATE_MIPS = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2L</para>
		/// <para>
		/// Enables resource data sharing between two or more Direct3D devices. The only resources that can be shared are 2D non-mipmapped textures.
		/// </para>
		/// <para>D3D11_RESOURCE_MISC_SHARED and D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX are mutually exclusive.</para>
		/// <para>WARP and REF devices do not support shared resources.</para>
		/// <para>
		/// If you try to create a resource with this flag on either a WARP or REF device, the create method will return an E_OUTOFMEMORY
		/// error code.
		/// </para>
		/// <note>Starting with Windows 8, <c>WARP</c> devices fully support shared resources.</note><note>Starting with Windows 8, we
		/// recommend that you enable resource data sharing between two or more Direct3D devices by using a combination of the
		/// D3D11_RESOURCE_MISC_SHARED_NTHANDLE and D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX flags instead.</note>
		/// </summary>
		D3D11_RESOURCE_MISC_SHARED = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4L</para>
		/// <para>Sets a resource to be a cube texture created from a Texture2DArray that contains 6 textures.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_TEXTURECUBE = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10L</para>
		/// <para>Enables instancing of GPU-generated content.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20L</para>
		/// <para>Enables a resource as a byte address buffer.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40L</para>
		/// <para>Enables a resource as a structured buffer.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_BUFFER_STRUCTURED = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80L</para>
		/// <para>Enables a resource with MIP map clamping for use with ID3D11DeviceContext::SetResourceMinLOD.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_RESOURCE_CLAMP = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100L</para>
		/// <para>Enables the resource to be synchronized by using the IDXGIKeyedMutex::AcquireSync and IDXGIKeyedMutex::ReleaseSync APIs.</para>
		/// <para>
		/// The following Direct3D 11 resource creation APIs, that take D3D11_RESOURCE_MISC_FLAG parameters, have been extended to support
		/// the new flag.
		/// </para>
		/// <list type="bullet">
		/// <item>ID3D11Device::CreateTexture1D</item>
		/// <item>ID3D11Device::CreateTexture2D</item>
		/// <item>ID3D11Device::CreateTexture3D</item>
		/// <item>ID3D11Device::CreateBuffer</item>
		/// </list>
		/// <para>
		/// If you call any of these methods with the D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX flag set, the interface returned will support
		/// the IDXGIKeyedMutex interface. You can retrieve a pointer to the IDXGIKeyedMutex interface from the resource by using
		/// IUnknown::QueryInterface. The IDXGIKeyedMutex interface implements the IDXGIKeyedMutex::AcquireSync and
		/// IDXGIKeyedMutex::ReleaseSync APIs to synchronize access to the surface. The device that creates the surface, and any other
		/// device that opens the surface by using OpenSharedResource, must call IDXGIKeyedMutex::AcquireSync before they issue any
		/// rendering commands to the surface. When those devices finish rendering, they must call IDXGIKeyedMutex::ReleaseSync.
		/// </para>
		/// <para>D3D11_RESOURCE_MISC_SHARED and D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX are mutually exclusive.</para>
		/// <para>
		/// WARP and REF devices do not support shared resources. If you try to create a resource with this flag on either a WARP or REF
		/// device, the create method will return an E_OUTOFMEMORY error code.
		/// </para>
		/// <note>Starting with Windows 8, <c>WARP</c> devices fully support shared resources.</note>
		/// </summary>
		D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200L</para>
		/// <para>
		/// Enables a resource compatible with GDI. You must set the D3D11_RESOURCE_MISC_GDI_COMPATIBLE flag on surfaces that you use with
		/// GDI. Setting the D3D11_RESOURCE_MISC_GDI_COMPATIBLE flag allows GDI rendering on the surface via IDXGISurface1::GetDC.
		/// </para>
		/// <para>
		/// Consider the following programming tips for using D3D11_RESOURCE_MISC_GDI_COMPATIBLE when you create a texture or use that
		/// texture in a swap chain:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX and D3D11_RESOURCE_MISC_GDI_COMPATIBLE are mutually exclusive. Therefore, do not use them together.
		/// </item>
		/// <item>
		/// D3D11_RESOURCE_MISC_RESOURCE_CLAMP and D3D11_RESOURCE_MISC_GDI_COMPATIBLE are mutually exclusive. Therefore, do not use them together.
		/// </item>
		/// <item>
		/// You must bind the texture as a render target for the output-merger stage. For example, set the D3D11_BIND_RENDER_TARGET flag in
		/// the <c>BindFlags</c> member of the D3D11_TEXTURE2D_DESC structure.
		/// </item>
		/// <item>
		/// You must set the maximum number of MIP map levels to 1. For example, set the <c>MipLevels</c> member of the D3D11_TEXTURE2D_DESC
		/// structure to 1.
		/// </item>
		/// <item>
		/// You must specify that the texture requires read and write access by the GPU. For example, set the <c>Usage</c> member of the
		/// D3D11_TEXTURE2D_DESC structure to D3D11_USAGE_DEFAULT.
		/// </item>
		/// <item>
		/// You must set the texture format to one of the following types. For example, set the <c>Format</c> member of the
		/// D3D11_TEXTURE2D_DESC structure to one of these types.
		/// </item>
		/// <item>
		/// You cannot use D3D11_RESOURCE_MISC_GDI_COMPATIBLE with multisampling. Therefore, set the <c>Count</c> member of the
		/// DXGI_SAMPLE_DESC structure to 1. Then, set the <c>SampleDesc</c> member of the D3D11_TEXTURE2D_DESC structure to this
		/// <c>DXGI_SAMPLE_DESC</c> structure.
		/// </item>
		/// </list>
		/// </summary>
		D3D11_RESOURCE_MISC_GDI_COMPATIBLE = 0x200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800L</para>
		/// <para>
		/// Set this flag to enable the use of NT HANDLE values when you create a shared resource. By enabling this flag, you deprecate the
		/// use of existing HANDLE values.
		/// </para>
		/// <para>
		/// The value specifies a new shared resource type that directs the runtime to use NT HANDLE values for the shared resource. The
		/// runtime then must confirm that the shared resource works on all hardware at the specified feature level.
		/// </para>
		/// <para>
		/// Without this flag set, the runtime does not strictly validate shared resource parameters (that is, formats, flags, usage, and so
		/// on). When the runtime does not validate shared resource parameters, behavior of much of the Direct3D API might be undefined and
		/// might vary from driver to driver.
		/// </para>
		/// <para>Direct3D 11 and earlier: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_SHARED_NTHANDLE = 0x800,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1000L</para>
		/// <para>
		/// Set this flag to indicate that the resource might contain protected content; therefore, the operating system should use the
		/// resource only when the driver and hardware support content protection. If the driver and hardware do not support content
		/// protection and you try to create a resource with this flag, the resource creation fails.
		/// </para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_RESTRICTED_CONTENT = 0x1000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2000L</para>
		/// <para>
		/// Set this flag to indicate that the operating system restricts access to the shared surface. You can use this flag together with
		/// the D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE_DRIVER flag and only when you create a shared surface. The process that creates
		/// the shared resource can always open the shared resource.
		/// </para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE = 0x2000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4000L</para>
		/// <para>
		/// Set this flag to indicate that the driver restricts access to the shared surface. You can use this flag in conjunction with the
		/// D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE flag and only when you create a shared surface. The process that creates the shared
		/// resource can always open the shared resource.
		/// </para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE_DRIVER = 0x4000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8000L</para>
		/// <para>
		/// Set this flag to indicate that the resource is guarded. Such a resource is returned by the IDCompositionSurface::BeginDraw
		/// (DirectComposition) and ISurfaceImageSourceNative::BeginDraw (Windows Runtime) APIs. For these APIs, you provide a region of
		/// interest (ROI) on a surface to update. This surface isn't compatible with multiple render targets (MRT).
		/// </para>
		/// <para>
		/// A guarded resource automatically restricts all writes to the region that is related to one of the preceding APIs. Additionally,
		/// the resource enforces access to the ROI with these restrictions:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// Copy operations from the resource by using ID3D11DeviceContext::CopyResource or ID3D11DeviceContext::CopySubresourceRegion are
		/// restricted to only copy from the ROI.
		/// </item>
		/// <item>When a guarded resource is set as a render target, it must be the only target.</item>
		/// </list>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.1.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_GUARDED = 0x8000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000L</para>
		/// <para>Set this flag to indicate that the resource is a tile pool.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.2.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_TILE_POOL = 0x20000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40000L</para>
		/// <para>Set this flag to indicate that the resource is a tiled resource.</para>
		/// <para>Direct3D 11: This value is not supported until Direct3D 11.2.</para>
		/// </summary>
		D3D11_RESOURCE_MISC_TILED = 0x40000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000L</para>
		/// <para>
		/// Set this flag to indicate that the resource should be created such that it will be protected by the hardware. Resource creation
		/// will fail if hardware content protection is not supported.
		/// </para>
		/// <para>This flag has the following restrictions:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>This flag cannot be used with the following D3D11_USAGE values:</description>
		/// </item>
		/// <item>
		/// <description>This flag cannot be used with the following D3D11_BIND_FLAG values.</description>
		/// </item>
		/// <item>
		/// <description>No CPU access flags can be specified.</description>
		/// </item>
		/// </list>
		/// <note>Creating a texture using this flag does not automatically guarantee that hardware protection will be enabled for the
		/// underlying allocation. Some implementations require that the DRM components are first initialized prior to any guarantees of
		/// protection.</note><note>This enumeration value is supported starting with Windows 10.</note>
		/// </summary>
		D3D11_RESOURCE_MISC_HW_PROTECTED = 0x80000,

		/// <summary>
		/// Enables the resource to work with the displayable surfaces feature. You must use D3D11_RESOURCE_MISC_SHARED_DISPLAYABLE in
		/// combination with both D3D11_RESOURCE_MISC_SHARED and D3D11_RESOURCE_MISC_SHARED_NTHANDLE.
		/// </summary>
		D3D11_RESOURCE_MISC_SHARED_DISPLAYABLE = 0x100000,

		/// <summary/>
		D3D11_RESOURCE_MISC_SHARED_EXCLUSIVE_WRITER = 0x200000,

		/// <summary/>
		D3D11_RESOURCE_MISC_NO_SHADER_ACCESS = 0x400000
	}

	/// <summary>These flags identify the type of resource that will be viewed as a render target.</summary>
	/// <remarks>This enumeration is used in D3D11_RENDER_TARGET_VIEW_DESC to create a render-target view.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_rtv_dimension typedef enum D3D11_RTV_DIMENSION {
	// D3D11_RTV_DIMENSION_UNKNOWN = 0, D3D11_RTV_DIMENSION_BUFFER = 1, D3D11_RTV_DIMENSION_TEXTURE1D = 2,
	// D3D11_RTV_DIMENSION_TEXTURE1DARRAY = 3, D3D11_RTV_DIMENSION_TEXTURE2D = 4, D3D11_RTV_DIMENSION_TEXTURE2DARRAY = 5,
	// D3D11_RTV_DIMENSION_TEXTURE2DMS = 6, D3D11_RTV_DIMENSION_TEXTURE2DMSARRAY = 7, D3D11_RTV_DIMENSION_TEXTURE3D = 8 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_RTV_DIMENSION")]
	public enum D3D11_RTV_DIMENSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Do not use this value, as it will cause</para>
		/// <para>ID3D11Device::CreateRenderTargetView</para>
		/// <para>to fail.</para>
		/// </summary>
		D3D11_RTV_DIMENSION_UNKNOWN = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The resource will be accessed as a buffer.</para>
		/// </summary>
		D3D11_RTV_DIMENSION_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The resource will be accessed as a 1D texture.</para>
		/// </summary>
		D3D11_RTV_DIMENSION_TEXTURE1D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The resource will be accessed as an array of 1D textures.</para>
		/// </summary>
		D3D11_RTV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The resource will be accessed as a 2D texture.</para>
		/// </summary>
		D3D11_RTV_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The resource will be accessed as an array of 2D textures.</para>
		/// </summary>
		D3D11_RTV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The resource will be accessed as a 2D texture with multisampling.</para>
		/// </summary>
		D3D11_RTV_DIMENSION_TEXTURE2DMS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The resource will be accessed as an array of 2D textures with multisampling.</para>
		/// </summary>
		D3D11_RTV_DIMENSION_TEXTURE2DMSARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The resource will be accessed as a 3D texture.</para>
		/// </summary>
		D3D11_RTV_DIMENSION_TEXTURE3D,
	}

	/// <summary>Describes the level of support for shader caching in the current graphics driver.</summary>
	/// <remarks>This enum is used by the D3D11_FEATURE_DATA_SHADER_CACHE structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_shader_cache_support_flags typedef enum
	// D3D11_SHADER_CACHE_SUPPORT_FLAGS { D3D11_SHADER_CACHE_SUPPORT_NONE = 0, D3D11_SHADER_CACHE_SUPPORT_AUTOMATIC_INPROC_CACHE = 0x1,
	// D3D11_SHADER_CACHE_SUPPORT_AUTOMATIC_DISK_CACHE = 0x2 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_SHADER_CACHE_SUPPORT_FLAGS")]
	[Flags]
	public enum D3D11_SHADER_CACHE_SUPPORT_FLAGS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Indicates that the driver does not support shader caching.</para>
		/// </summary>
		D3D11_SHADER_CACHE_SUPPORT_NONE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>
		/// Indicates that the driver supports an OS-managed shader cache that stores compiled shaders in memory during the current run of
		/// the application.
		/// </para>
		/// </summary>
		D3D11_SHADER_CACHE_SUPPORT_AUTOMATIC_INPROC_CACHE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>
		/// Indicates that the driver supports an OS-managed shader cache that stores compiled shaders on disk to accelerate future runs of
		/// the application.
		/// </para>
		/// </summary>
		D3D11_SHADER_CACHE_SUPPORT_AUTOMATIC_DISK_CACHE = 0x2,
	}

	/// <summary>
	/// <para>Value:</para>
	/// <para>0x1</para>
	/// <para>Minimum precision level is 10-bit.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_shader_min_precision_support typedef enum
	// D3D11_SHADER_MIN_PRECISION_SUPPORT { D3D11_SHADER_MIN_PRECISION_10_BIT = 0x1, D3D11_SHADER_MIN_PRECISION_16_BIT = 0x2 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_SHADER_MIN_PRECISION_SUPPORT")]
	public enum D3D11_SHADER_MIN_PRECISION_SUPPORT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Minimum precision level is 10-bit.</para>
		/// </summary>
		D3D11_SHADER_MIN_PRECISION_10_BIT = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Minimum precision level is 16-bit.</para>
		/// </summary>
		D3D11_SHADER_MIN_PRECISION_16_BIT,
	}

	/// <summary>Defines constants that specify the level of support for shared resources in the current graphics driver.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_shared_resource_tier typedef enum D3D11_SHARED_RESOURCE_TIER
	// { D3D11_SHARED_RESOURCE_TIER_0 = 0, D3D11_SHARED_RESOURCE_TIER_1, D3D11_SHARED_RESOURCE_TIER_2, D3D11_SHARED_RESOURCE_TIER_3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_SHARED_RESOURCE_TIER")]
	public enum D3D11_SHARED_RESOURCE_TIER
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Specifies the support available when D3D11_FEATURE_DATA_D3D11_OPTIONS::ExtendedResourceSharing is FALSE (only very old drivers
		/// have this value set to FALSE).
		/// </para>
		/// <para>See Extended support for shared Texture2D resources.</para>
		/// </summary>
		D3D11_SHARED_RESOURCE_TIER_0 = 0,

		/// <summary>
		/// <para>
		/// Specifies the support available when D3D11_FEATURE_DATA_D3D11_OPTIONS::ExtendedResourceSharing and
		/// D3D11_FEATURE_DATA_D3D11_OPTIONS4::ExtendedNV12SharedTextureSupported are TRUE.
		/// </para>
		/// <para>You can share additional formats; see Extended support for shared Texture2D resources.</para>
		/// <para>
		/// Only formats that are still shareable when D3D11_FEATURE_DATA_D3D11_OPTIONS::ExtendedResourceSharing == FALSE can be shared
		/// across APIs between Direct3D 11 and Direct3D 12.
		/// </para>
		/// <para>Resource formats added by D3D11_FEATURE_DATA_D3D11_OPTIONS::ExtendedResourceSharing == TRUE can't be shared across APIs.</para>
		/// </summary>
		D3D11_SHARED_RESOURCE_TIER_1,

		/// <summary>
		/// <para>
		/// Specifies the support available when D3D11_FEATURE_DATA_D3D11_OPTIONS4::ExtendedNV12SharedTextureSupported is TRUE. Also see
		/// Extended NV12 texture support.
		/// </para>
		/// <para>See Extended support for shared Texture2D resources.</para>
		/// <para>
		/// Sharing across APIs between Direct3D 11 and Direct3D 12 is possible for the
		/// D3D11_FEATURE_DATA_D3D11_OPTIONS::ExtendedResourceSharing == TRUE format list.
		/// </para>
		/// </summary>
		D3D11_SHARED_RESOURCE_TIER_2,

		/// <summary>
		/// <para>Specifies that DXGI_FORMAT_R11G11B10_FLOAT supports NT handle sharing. Also see CreateSharedHandle.</para>
		/// <para>Sharing across APIs between Direct3D 11 and Direct3D 12 is possible for the DXGI_FORMAT_R11G11B10_FLOAT format.</para>
		/// </summary>
		D3D11_SHARED_RESOURCE_TIER_3,
	}

	/// <summary>These flags identify the type of resource that will be viewed as a shader resource.</summary>
	/// <remarks>
	/// <para>These flags are used by a shader-resource-view description (see <c>D3D11_SHADER_RESOURCE_VIEW_DESC</c>).</para>
	/// <para>
	/// The <c>D3D11_SRV_DIMENSION</c> enumeration is type defined in the D3D11.h header file as a <c>D3D_SRV_DIMENSION</c> enumeration,
	/// which is fully defined in the D3DCommon.h header file.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ff476217(v=vs.85) typedef enum D3D11_SRV_DIMENSION {
	// D3D11_SRV_DIMENSION_UNKNOWN&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;= 0,
	// D3D11_SRV_DIMENSION_BUFFER&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;= 1,
	// D3D11_SRV_DIMENSION_TEXTURE1D&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;= 2,
	// D3D11_SRV_DIMENSION_TEXTURE1DARRAY&#160;&#160;&#160;&#160;= 3,
	// D3D11_SRV_DIMENSION_TEXTURE2D&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;= 4,
	// D3D11_SRV_DIMENSION_TEXTURE2DARRAY&#160;&#160;&#160;&#160;= 5,
	// D3D11_SRV_DIMENSION_TEXTURE2DMS&#160;&#160;&#160;&#160;&#160;&#160;&#160;= 6, D3D11_SRV_DIMENSION_TEXTURE2DMSARRAY&#160;&#160;= 7,
	// D3D11_SRV_DIMENSION_TEXTURE3D&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;= 8,
	// D3D11_SRV_DIMENSION_TEXTURECUBE&#160;&#160;&#160;&#160;&#160;&#160;&#160;= 9, D3D11_SRV_DIMENSION_TEXTURECUBEARRAY&#160;&#160;= 10,
	// D3D11_SRV_DIMENSION_BUFFEREX&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;= 11 } D3D11_SRV_DIMENSION;
	[PInvokeData("D3D11.h")]
	public enum D3D11_SRV_DIMENSION
	{
		/// <summary>The type is unknown.</summary>
		D3D11_SRV_DIMENSION_UNKNOWN,

		/// <summary>The resource is a buffer.</summary>
		D3D11_SRV_DIMENSION_BUFFER,

		/// <summary>The resource is a 1D texture.</summary>
		D3D11_SRV_DIMENSION_TEXTURE1D,

		/// <summary>The resource is an array of 1D textures.</summary>
		D3D11_SRV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>The resource is a 2D texture.</summary>
		D3D11_SRV_DIMENSION_TEXTURE2D,

		/// <summary>The resource is an array of 2D textures.</summary>
		D3D11_SRV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>The resource is a multisampling 2D texture.</summary>
		D3D11_SRV_DIMENSION_TEXTURE2DMS,

		/// <summary>The resource is an array of multisampling 2D textures.</summary>
		D3D11_SRV_DIMENSION_TEXTURE2DMSARRAY,

		/// <summary>The resource is a 3D texture.</summary>
		D3D11_SRV_DIMENSION_TEXTURE3D,

		/// <summary>The resource is a cube texture.</summary>
		D3D11_SRV_DIMENSION_TEXTURECUBE,

		/// <summary>The resource is an array of cube textures.</summary>
		D3D11_SRV_DIMENSION_TEXTURECUBEARRAY,

		/// <summary>The resource is a raw buffer. For more info about raw viewing of buffers, see Raw Views of Buffers.</summary>
		D3D11_SRV_DIMENSION_BUFFEREX,
	}

	/// <summary>The stencil operations that can be performed during depth-stencil testing.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_stencil_op typedef enum D3D11_STENCIL_OP {
	// D3D11_STENCIL_OP_KEEP = 1, D3D11_STENCIL_OP_ZERO = 2, D3D11_STENCIL_OP_REPLACE = 3, D3D11_STENCIL_OP_INCR_SAT = 4,
	// D3D11_STENCIL_OP_DECR_SAT = 5, D3D11_STENCIL_OP_INVERT = 6, D3D11_STENCIL_OP_INCR = 7, D3D11_STENCIL_OP_DECR = 8 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_STENCIL_OP")]
	public enum D3D11_STENCIL_OP
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Keep the existing stencil data.</para>
		/// </summary>
		D3D11_STENCIL_OP_KEEP = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Set the stencil data to 0.</para>
		/// </summary>
		D3D11_STENCIL_OP_ZERO,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Set the stencil data to the reference value set by calling ID3D11DeviceContext::OMSetDepthStencilState.</para>
		/// </summary>
		D3D11_STENCIL_OP_REPLACE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Increment the stencil value by 1, and clamp the result.</para>
		/// </summary>
		D3D11_STENCIL_OP_INCR_SAT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Decrement the stencil value by 1, and clamp the result.</para>
		/// </summary>
		D3D11_STENCIL_OP_DECR_SAT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Invert the stencil data.</para>
		/// </summary>
		D3D11_STENCIL_OP_INVERT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Increment the stencil value by 1, and wrap the result if necessary.</para>
		/// </summary>
		D3D11_STENCIL_OP_INCR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Decrement the stencil value by 1, and wrap the result if necessary.</para>
		/// </summary>
		D3D11_STENCIL_OP_DECR,
	}

	/// <summary>Identify a technique for resolving texture coordinates that are outside of the boundaries of a texture.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_texture_address_mode typedef enum D3D11_TEXTURE_ADDRESS_MODE
	// { D3D11_TEXTURE_ADDRESS_WRAP = 1, D3D11_TEXTURE_ADDRESS_MIRROR = 2, D3D11_TEXTURE_ADDRESS_CLAMP = 3, D3D11_TEXTURE_ADDRESS_BORDER =
	// 4, D3D11_TEXTURE_ADDRESS_MIRROR_ONCE = 5 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_TEXTURE_ADDRESS_MODE")]
	public enum D3D11_TEXTURE_ADDRESS_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Tile the texture at every (u,v) integer junction. For example, for u values between 0 and 3, the texture is repeated three times.
		/// </para>
		/// </summary>
		D3D11_TEXTURE_ADDRESS_WRAP = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Flip the texture at every (u,v) integer junction. For u values between 0 and 1, for example, the texture is addressed normally;
		/// between 1 and 2, the texture is flipped (mirrored); between 2 and 3, the texture is normal again; and so on.
		/// </para>
		/// </summary>
		D3D11_TEXTURE_ADDRESS_MIRROR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Texture coordinates outside the range [0.0, 1.0] are set to the texture color at 0.0 or 1.0, respectively.</para>
		/// </summary>
		D3D11_TEXTURE_ADDRESS_CLAMP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Texture coordinates outside the range [0.0, 1.0] are set to the border color specified in D3D11_SAMPLER_DESC or HLSL code.</para>
		/// </summary>
		D3D11_TEXTURE_ADDRESS_BORDER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>
		/// Similar to D3D11_TEXTURE_ADDRESS_MIRROR and D3D11_TEXTURE_ADDRESS_CLAMP. Takes the absolute value of the texture coordinate
		/// (thus, mirroring around 0), and then clamps to the maximum value.
		/// </para>
		/// </summary>
		D3D11_TEXTURE_ADDRESS_MIRROR_ONCE,
	}

	/// <summary>The different faces of a cube texture.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_texturecube_face typedef enum D3D11_TEXTURECUBE_FACE {
	// D3D11_TEXTURECUBE_FACE_POSITIVE_X = 0, D3D11_TEXTURECUBE_FACE_NEGATIVE_X = 1, D3D11_TEXTURECUBE_FACE_POSITIVE_Y = 2,
	// D3D11_TEXTURECUBE_FACE_NEGATIVE_Y = 3, D3D11_TEXTURECUBE_FACE_POSITIVE_Z = 4, D3D11_TEXTURECUBE_FACE_NEGATIVE_Z = 5 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_TEXTURECUBE_FACE")]
	public enum D3D11_TEXTURECUBE_FACE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Positive X face.</para>
		/// </summary>
		D3D11_TEXTURECUBE_FACE_POSITIVE_X,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Negative X face.</para>
		/// </summary>
		D3D11_TEXTURECUBE_FACE_NEGATIVE_X,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Positive Y face.</para>
		/// </summary>
		D3D11_TEXTURECUBE_FACE_POSITIVE_Y,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Negative Y face.</para>
		/// </summary>
		D3D11_TEXTURECUBE_FACE_NEGATIVE_Y,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Positive Z face.</para>
		/// </summary>
		D3D11_TEXTURECUBE_FACE_POSITIVE_Z,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Negative Z face.</para>
		/// </summary>
		D3D11_TEXTURECUBE_FACE_NEGATIVE_Z,
	}

	/// <summary>Indicates the tier level at which tiled resources are supported.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_tiled_resources_tier typedef enum D3D11_TILED_RESOURCES_TIER
	// { D3D11_TILED_RESOURCES_NOT_SUPPORTED = 0, D3D11_TILED_RESOURCES_TIER_1 = 1, D3D11_TILED_RESOURCES_TIER_2 = 2,
	// D3D11_TILED_RESOURCES_TIER_3 = 3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_TILED_RESOURCES_TIER")]
	public enum D3D11_TILED_RESOURCES_TIER
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Tiled resources are not supported.</para>
		/// </summary>
		D3D11_TILED_RESOURCES_NOT_SUPPORTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Tier_1 tiled resources are supported. The device supports calls to CreateTexture2D and so on with the D3D11_RESOURCE_MISC_TILED flag.
		/// </para>
		/// <para>The device supports calls to CreateBuffer with the D3D11_RESOURCE_MISC_TILE_POOL flag.</para>
		/// <para>
		/// If you access tiles (read or write) that are NULL-mapped, you get undefined behavior, which includes device-removed. Apps can
		/// map all tiles to a single "default" tile to avoid this condition.
		/// </para>
		/// </summary>
		D3D11_TILED_RESOURCES_TIER_1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Tier_2 tiled resources are supported.</para>
		/// <para>Superset of Tier_1 functionality, which includes this additional support:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// On Tier_1, if the size of a texture mipmap level is an integer multiple of the standard tile shape for its format, it is
		/// guaranteed to be nonpacked. On Tier_2, this guarantee is expanded to include mipmap levels whose size is at least one standard
		/// tile shape. For more info, see D3D11_PACKED_MIP_DESC.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Shader instructions are available for clamping level-of-detail (LOD) and for obtaining status about the shader operation. For
		/// info about one of these shader instructions, see Sample(S,float,int,float,uint).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Reading from <c>NULL</c>-mapped tiles treat that sampled value as zero. Writes to <c>NULL</c>-mapped tiles are discarded.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		D3D11_TILED_RESOURCES_TIER_2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Tier_3 tiled resources are supported.</para>
		/// <para>
		/// Superset of Tier_2 functionality, Tier 3 is essentially Tier 2 but with the additional support of Texture3D for Tiled Resources.
		/// </para>
		/// </summary>
		D3D11_TILED_RESOURCES_TIER_3,
	}

	/// <summary>Unordered-access view options.</summary>
	/// <remarks>This enumeration is used by a unordered access-view description (see D3D11_UNORDERED_ACCESS_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_uav_dimension typedef enum D3D11_UAV_DIMENSION {
	// D3D11_UAV_DIMENSION_UNKNOWN = 0, D3D11_UAV_DIMENSION_BUFFER = 1, D3D11_UAV_DIMENSION_TEXTURE1D = 2,
	// D3D11_UAV_DIMENSION_TEXTURE1DARRAY = 3, D3D11_UAV_DIMENSION_TEXTURE2D = 4, D3D11_UAV_DIMENSION_TEXTURE2DARRAY = 5,
	// D3D11_UAV_DIMENSION_TEXTURE3D = 8 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_UAV_DIMENSION")]
	public enum D3D11_UAV_DIMENSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The view type is unknown.</para>
		/// </summary>
		D3D11_UAV_DIMENSION_UNKNOWN = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>View the resource as a buffer.</para>
		/// </summary>
		D3D11_UAV_DIMENSION_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>View the resource as a 1D texture.</para>
		/// </summary>
		D3D11_UAV_DIMENSION_TEXTURE1D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>View the resource as a 1D texture array.</para>
		/// </summary>
		D3D11_UAV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>View the resource as a 2D texture.</para>
		/// </summary>
		D3D11_UAV_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>View the resource as a 2D texture array.</para>
		/// </summary>
		D3D11_UAV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>View the resource as a 3D texture array.</para>
		/// </summary>
		D3D11_UAV_DIMENSION_TEXTURE3D,
	}

	/// <summary>
	/// Identifies expected resource use during rendering. The usage directly reflects whether a resource is accessible by the CPU and/or
	/// the graphics processing unit (GPU).
	/// </summary>
	/// <remarks>
	/// <para>
	/// An application identifies the way a resource is intended to be used (its usage) in a resource description. There are several
	/// structures for creating resources including: D3D11_TEXTURE1D_DESC, D3D11_TEXTURE2D_DESC, D3D11_TEXTURE3D_DESC, and D3D11_BUFFER_DESC.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>
	/// Differences between Direct3D 9 and Direct3D 10/11: In Direct3D 9, you specify the type of memory a resource should be created in at
	/// resource creation time (using D3DPOOL). It was an application's job to decide what memory pool would provide the best combination of
	/// functionality and performance. In Direct3D 10/11, an application no longer specifies what type of memory (the pool) to create a
	/// resource in. Instead, you specify the intended usage of the resource, and let the runtime (in concert with the driver and a memory
	/// manager) choose the type of memory that will achieve the best performance.
	/// </description>
	/// </listheader>
	/// </list>
	/// <para></para>
	/// <para>Resource Usage Restrictions</para>
	/// <para>
	/// Each usage dictates a tradeoff between accessibility for the CPU and accessibility for the GPU. In general, higher-performance
	/// access for one of these two processors means lower-performance access for the other. At either extreme are the
	/// <c>D3D11_USAGE_DEFAULT</c> and <c>D3D11_USAGE_STAGING</c> usages. <c>D3D11_USAGE_DEFAULT</c> restricts access almost entirely to the
	/// GPU. <c>D3D11_USAGE_STAGING</c> restricts access almost entirely to the CPU and allows only a data transfer (copy) of a resource
	/// between the GPU and the CPU. You can perform these copy operations via the ID3D11DeviceContext::CopySubresourceRegion and
	/// ID3D11DeviceContext::CopyResource methods. You can also use these copy methods to copy data between two resources of the same usage.
	/// You can also use the ID3D11DeviceContext::UpdateSubresource method to copy memory directly from a CPU-supplied pointer to any
	/// resource, most usefully a resource with <c>D3D11_USAGE_DEFAULT</c>.
	/// </para>
	/// <para>
	/// <c>D3D11_USAGE_DYNAMIC</c> usage is a special case that optimizes the flow of data from CPU to GPU when the CPU generates that data
	/// on-the-fly and sends that data with high frequency. <c>D3D11_USAGE_DYNAMIC</c> is typically used on resources with vertex data and
	/// on constant buffers. Use the ID3D11DeviceContext::Map and ID3D11DeviceContext::Unmap methods to write data to these resources. To
	/// achieve the highest performance for data consumed serially, like vertex data, use the <c>D3D11_MAP_WRITE_NO_OVERWRITE</c> and
	/// <c>D3D11_MAP_WRITE_DISCARD</c> sequence. For more info about this sequence, see Common Usage of D3D11_MAP_WRITE_DISCARD with D3D11_MAP_WRITE_NO_OVERWRITE.
	/// </para>
	/// <para>
	/// <c>D3D11_USAGE_IMMUTABLE</c> usage is another special case that causes the GPU to generate data just once when you create a
	/// resource. <c>D3D11_USAGE_IMMUTABLE</c> is well-suited to data such as textures because such data is typically read into memory from
	/// some file format. Therefore, when you create a texture with <c>D3D11_USAGE_IMMUTABLE</c>, the GPU directly reads that texture into memory.
	/// </para>
	/// <para>
	/// Use the following table to choose the usage that best describes how the resource will need to be accessed by the CPU and/or the GPU.
	/// Of course, there will be performance tradeoffs.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Resource Usage</description>
	/// <description>Default</description>
	/// <description>Dynamic</description>
	/// <description>Immutable</description>
	/// <description>Staging</description>
	/// </listheader>
	/// <item>
	/// <description>GPU-Read</description>
	/// <description>yes</description>
	/// <description>yes</description>
	/// <description>yes</description>
	/// <description>yes¹</description>
	/// </item>
	/// <item>
	/// <description>GPU-Write</description>
	/// <description>yes</description>
	/// <description/>
	/// <description/>
	/// <description>yes¹</description>
	/// </item>
	/// <item>
	/// <description>CPU-Read</description>
	/// <description/>
	/// <description/>
	/// <description/>
	/// <description>yes¹</description>
	/// </item>
	/// <item>
	/// <description>CPU-Write</description>
	/// <description/>
	/// <description>yes</description>
	/// <description/>
	/// <description>yes¹</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>
	/// 1 - GPU read or write of a resource with the <c>D3D11_USAGE_STAGING</c> usage is restricted to copy operations. You use
	/// ID3D11DeviceContext::CopySubresourceRegion and ID3D11DeviceContext::CopyResource for these copy operations. Also, because
	/// depth-stencil formats and multisample layouts are implementation details of a particular GPU design, the operating system can’t
	/// expose these formats and layouts to the CPU in general. Therefore, staging resources can't be a depth-stencil buffer or a
	/// multisampled render target.
	/// </para>
	/// <para>
	/// <c>Note</c>  You can technically use ID3D11DeviceContext::UpdateSubresource to copy to a resource with any usage except
	/// <c>D3D11_USAGE_IMMUTABLE</c>. However, we recommend to use ID3D11DeviceContext::UpdateSubresource to update only a resource with
	/// <c>D3D11_USAGE_DEFAULT</c>. We recommend to use ID3D11DeviceContext::Map and ID3D11DeviceContext::Unmap to update resources with
	/// <c>D3D11_USAGE_DYNAMIC</c> because that is the specific purpose of <c>D3D11_USAGE_DYNAMIC</c> resources, and is therefore the most
	/// optimized path.
	/// </para>
	/// <para></para>
	/// <para>
	/// <c>Note</c>   <c>D3D11_USAGE_DYNAMIC</c> resources consume specific hardware capabilities. Therefore, use them sparingly. The
	/// display driver typically allocates memory for <c>D3D11_USAGE_DYNAMIC</c> resources with a caching algorithm that favors CPU writes
	/// and hinders CPU reads. Furthermore, the memory behind <c>D3D11_USAGE_DYNAMIC</c> resources might not even be the same for successive
	/// calls to ID3D11DeviceContext::Map. Therefore, do not expect high performance or even consistent CPU reads from
	/// <c>D3D11_USAGE_DYNAMIC</c> resources.
	/// </para>
	/// <para></para>
	/// <para>
	/// <c>Note</c>  ID3D11DeviceContext::CopyStructureCount is a special case of GPU-to-CPU copy. Use
	/// <c>ID3D11DeviceContext::CopyStructureCount</c> only with unordered access views (UAVs) of buffers.
	/// </para>
	/// <para></para>
	/// <para>Resource Bind Options</para>
	/// <para>
	/// To maximize performance, not all resource usage options can be used as input or output resources to the pipeline. This table
	/// identifies these limitations.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Resource Can Be Bound As</description>
	/// <description>Default</description>
	/// <description>Dynamic</description>
	/// <description>Immutable</description>
	/// <description>Staging</description>
	/// </listheader>
	/// <item>
	/// <description>Input to a Stage</description>
	/// <description>yes²</description>
	/// <description>yes³</description>
	/// <description>yes</description>
	/// <description/>
	/// </item>
	/// <item>
	/// <description>Output from a Stage</description>
	/// <description>yes²</description>
	/// <description/>
	/// <description/>
	/// <description/>
	/// </item>
	/// </list>
	/// <para></para>
	/// <list type="bullet">
	/// <item>
	/// <description>2 - If bound as an input and an output using different views, each view must use different subresources.</description>
	/// </item>
	/// <item>
	/// <description>
	/// 3 - The resource can only be created with a single subresource. The resource cannot be a texture array. The resource cannot be a
	/// mipmap chain.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_usage typedef enum D3D11_USAGE { D3D11_USAGE_DEFAULT = 0,
	// D3D11_USAGE_IMMUTABLE = 1, D3D11_USAGE_DYNAMIC = 2, D3D11_USAGE_STAGING = 3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_USAGE")]
	public enum D3D11_USAGE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A resource that requires read and write access by the GPU. This is likely to be the most common usage choice.</para>
		/// </summary>
		D3D11_USAGE_DEFAULT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// A resource that can only be read by the GPU. It cannot be written by the GPU, and cannot be accessed at all by the CPU. This
		/// type of resource must be initialized when it is created, since it cannot be changed after creation.
		/// </para>
		/// </summary>
		D3D11_USAGE_IMMUTABLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// A resource that is accessible by both the GPU (read only) and the CPU (write only). A dynamic resource is a good choice for a
		/// resource that will be updated by the CPU at least once per frame. To update a dynamic resource, use a
		/// </para>
		/// <para>Map</para>
		/// <para>method.</para>
		/// <para>For info about how to use dynamic resources, see</para>
		/// <para>How to: Use dynamic resources</para>
		/// <para>.</para>
		/// </summary>
		D3D11_USAGE_DYNAMIC,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>A resource that supports data transfer (copy) from the GPU to the CPU.</para>
		/// </summary>
		D3D11_USAGE_STAGING,
	}

	/// <summary>Specifies how to access a resource that is used in a video decoding output view.</summary>
	/// <remarks>This enumeration is used with the D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_vdov_dimension typedef enum D3D11_VDOV_DIMENSION {
	// D3D11_VDOV_DIMENSION_UNKNOWN = 0, D3D11_VDOV_DIMENSION_TEXTURE2D = 1 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VDOV_DIMENSION")]
	public enum D3D11_VDOV_DIMENSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Not a valid value.</para>
		/// </summary>
		D3D11_VDOV_DIMENSION_UNKNOWN = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The resource will be accessed as a 2D texture.</para>
		/// </summary>
		D3D11_VDOV_DIMENSION_TEXTURE2D,
	}

	/// <summary>Specifies a type of compressed buffer for decoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_decoder_buffer_type typedef enum
	// D3D11_VIDEO_DECODER_BUFFER_TYPE { D3D11_VIDEO_DECODER_BUFFER_PICTURE_PARAMETERS = 0, D3D11_VIDEO_DECODER_BUFFER_MACROBLOCK_CONTROL =
	// 1, D3D11_VIDEO_DECODER_BUFFER_RESIDUAL_DIFFERENCE = 2, D3D11_VIDEO_DECODER_BUFFER_DEBLOCKING_CONTROL = 3,
	// D3D11_VIDEO_DECODER_BUFFER_INVERSE_QUANTIZATION_MATRIX = 4, D3D11_VIDEO_DECODER_BUFFER_SLICE_CONTROL = 5,
	// D3D11_VIDEO_DECODER_BUFFER_BITSTREAM = 6, D3D11_VIDEO_DECODER_BUFFER_MOTION_VECTOR = 7, D3D11_VIDEO_DECODER_BUFFER_FILM_GRAIN = 8,
	// D3D11_VIDEO_DECODER_BUFFER_HUFFMAN_TABLE } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_DECODER_BUFFER_TYPE")]
	public enum D3D11_VIDEO_DECODER_BUFFER_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Picture decoding parameter buffer.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_BUFFER_PICTURE_PARAMETERS = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Macroblock control command buffer.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_BUFFER_MACROBLOCK_CONTROL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Residual difference block data buffer.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_BUFFER_RESIDUAL_DIFFERENCE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Deblocking filter control command buffer.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_BUFFER_DEBLOCKING_CONTROL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Inverse quantization matrix buffer.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_BUFFER_INVERSE_QUANTIZATION_MATRIX,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Slice-control buffer.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_BUFFER_SLICE_CONTROL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Bitstream data buffer.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_BUFFER_BITSTREAM,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Motion vector buffer.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_BUFFER_MOTION_VECTOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Film grain synthesis data buffer.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_BUFFER_FILM_GRAIN,
	}

	/// <summary>Describes how a video stream is interlaced.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_frame_format typedef enum D3D11_VIDEO_FRAME_FORMAT {
	// D3D11_VIDEO_FRAME_FORMAT_PROGRESSIVE = 0, D3D11_VIDEO_FRAME_FORMAT_INTERLACED_TOP_FIELD_FIRST = 1,
	// D3D11_VIDEO_FRAME_FORMAT_INTERLACED_BOTTOM_FIELD_FIRST = 2 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_FRAME_FORMAT")]
	public enum D3D11_VIDEO_FRAME_FORMAT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Frames are progressive.</para>
		/// </summary>
		D3D11_VIDEO_FRAME_FORMAT_PROGRESSIVE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Frames are interlaced. The top field of each frame is displayed first.</para>
		/// </summary>
		D3D11_VIDEO_FRAME_FORMAT_INTERLACED_TOP_FIELD_FIRST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Frame are interlaced. The bottom field of each frame is displayed first.</para>
		/// </summary>
		D3D11_VIDEO_FRAME_FORMAT_INTERLACED_BOTTOM_FIELD_FIRST,
	}

	/// <summary>Specifies the alpha fill mode for video processing.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_alpha_fill_mode typedef enum
	// D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE { D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE = 0,
	// D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_BACKGROUND = 1, D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_DESTINATION = 2,
	// D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM = 3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE")]
	public enum D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Alpha values inside the target rectangle are set to opaque.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Alpha values inside the target rectangle are set to the alpha value specified in the background color. To set the background
		/// color, call the
		/// </para>
		/// <para>ID3D11VideoContext::VideoProcessorSetOutputBackgroundColor</para>
		/// <para>method.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_BACKGROUND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Existing alpha values remain unchanged in the output surface.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_DESTINATION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>
		/// Alpha values are taken from an input stream, scaled, and copied to the corresponding destination rectangle for that stream. The
		/// input stream is specified in the
		/// </para>
		/// <para>StreamIndex</para>
		/// <para>parameter of the</para>
		/// <para>ID3D11VideoContext::VideoProcessorSetOutputAlphaFillMode</para>
		/// <para>method.</para>
		/// <para>
		/// If the input stream does not have alpha data, the video processor sets the alpha values in the target rectangle to opaque. If
		/// the input stream is disabled or the source rectangle is empty, the alpha values in the target rectangle are not modified.
		/// </para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM,
	}

	/// <summary>Specifies the automatic image processing capabilities of the video processor.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_auto_stream_caps typedef enum
	// D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS { D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_DENOISE = 0x1,
	// D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_DERINGING = 0x2, D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_EDGE_ENHANCEMENT = 0x4,
	// D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_COLOR_CORRECTION = 0x8, D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_FLESH_TONE_MAPPING = 0x10,
	// D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_IMAGE_STABILIZATION = 0x20, D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_SUPER_RESOLUTION = 0x40,
	// D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_ANAMORPHIC_SCALING = 0x80 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS")]
	[Flags]
	public enum D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Denoise.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_DENOISE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Deringing.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_DERINGING = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Edge enhancement.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_EDGE_ENHANCEMENT = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>Color correction.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_COLOR_CORRECTION = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Flesh-tone mapping.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_FLESH_TONE_MAPPING = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>Image stabilization.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_IMAGE_STABILIZATION = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>Enhanced image resolution.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_SUPER_RESOLUTION = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>Anamorphic scaling.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS_ANAMORPHIC_SCALING = 0x80,
	}

	/// <summary>Defines video processing capabilities for a Microsoft Direct3D 11 video processor.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_device_caps typedef enum
	// D3D11_VIDEO_PROCESSOR_DEVICE_CAPS { D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_LINEAR_SPACE = 0x1, D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_xvYCC =
	// 0x2, D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_RGB_RANGE_CONVERSION = 0x4, D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_YCbCr_MATRIX_CONVERSION = 0x8,
	// D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_NOMINAL_RANGE = 0x10 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_DEVICE_CAPS")]
	[Flags]
	public enum D3D11_VIDEO_PROCESSOR_DEVICE_CAPS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>
		/// The video processor can blend video content in linear color space. Most video content is gamma corrected, resulting in nonlinear
		/// values. This capability flag means that the video processor converts colors to linear space before blending, which produces
		/// better results.
		/// </para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_LINEAR_SPACE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The video processor supports the xvYCC color space for YCbCr data.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_xvYCC = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>
		/// The video processor can perform range conversion when the input and output are both RGB but use different color ranges (0-255 or
		/// 16-235, for 8-bit RGB).
		/// </para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_RGB_RANGE_CONVERSION = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>
		/// The video processor can apply a matrix conversion to YCbCr values when the input and output are both YCbCr. For example, the
		/// driver can convert colors from BT.601 to BT.709.
		/// </para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_YCbCr_MATRIX_CONVERSION = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The video processor supports YUV nominal range .</para>
		/// <para>Supported in Windows 8.1 and later.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_NOMINAL_RANGE = 0x10,
	}

	/// <summary>Defines features that a Microsoft Direct3D 11 video processor can support.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_feature_caps typedef enum
	// D3D11_VIDEO_PROCESSOR_FEATURE_CAPS { D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_FILL = 0x1,
	// D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_CONSTRICTION = 0x2, D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LUMA_KEY = 0x4,
	// D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE = 0x8, D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LEGACY = 0x10,
	// D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_STEREO = 0x20, D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ROTATION = 0x40,
	// D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_STREAM = 0x80, D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_PIXEL_ASPECT_RATIO = 0x100,
	// D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_MIRROR = 0x200, D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_SHADER_USAGE = 0x400,
	// D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_METADATA_HDR10 = 0x800 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_FEATURE_CAPS")]
	[Flags]
	public enum D3D11_VIDEO_PROCESSOR_FEATURE_CAPS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The video processor can set alpha values on the output pixels. For more information, see</para>
		/// <para>ID3D11VideoContext::VideoProcessorSetOutputAlphaFillMode</para>
		/// <para>.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_FILL = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The video processor can downsample the video output. For more information, see</para>
		/// <para>ID3D11VideoContext::VideoProcessorSetOutputConstriction</para>
		/// <para>.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_CONSTRICTION = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The video processor can perform luma keying. For more information, see</para>
		/// <para>ID3D11VideoContext::VideoProcessorSetStreamLumaKey</para>
		/// <para>.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LUMA_KEY = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The video processor can apply alpha values from color palette entries.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>
		/// The driver does not support full video processing capabilities. If this capability flag is set, the video processor has the
		/// following limitations:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>A maximum of two streams are supported:</description>
		/// </item>
		/// <item>
		/// <description>Image adjustment (proc amp) controls are applied to the entire video processing blit, rather than per stream.</description>
		/// </item>
		/// <item>
		/// <description>Support for per-stream planar alpha is not reliable. (Per-pixel alpha is supported, however.)</description>
		/// </item>
		/// </list>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LEGACY = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>The video processor can support 3D stereo video. For more information, see</para>
		/// <para>ID3D11VideoContext::VideoProcessorSetStreamStereoFormat</para>
		/// <para>.</para>
		/// <para>All drivers setting this caps must support the following stereo formats:</para>
		/// <para>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_HORIZONTAL</para>
		/// <para>,</para>
		/// <para>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_VERTICAL</para>
		/// <para>, and</para>
		/// <para>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE</para>
		/// <para>.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_STEREO = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>The driver can rotate the input data either 90, 180, or 270 degrees clockwise as part of the video processing operation.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ROTATION = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>The driver supports the</para>
		/// <para>VideoProcessorSetStreamAlpha</para>
		/// <para>call.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_STREAM = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>The driver supports the</para>
		/// <para>VideoProcessorSetStreamPixelAspectRatio</para>
		/// <para>call.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_PIXEL_ASPECT_RATIO = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_MIRROR = 0x200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_SHADER_USAGE = 0x400,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_METADATA_HDR10 = 0x800,
	}

	/// <summary>Identifies a video processor filter.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_filter typedef enum
	// D3D11_VIDEO_PROCESSOR_FILTER { D3D11_VIDEO_PROCESSOR_FILTER_BRIGHTNESS = 0, D3D11_VIDEO_PROCESSOR_FILTER_CONTRAST = 1,
	// D3D11_VIDEO_PROCESSOR_FILTER_HUE = 2, D3D11_VIDEO_PROCESSOR_FILTER_SATURATION = 3, D3D11_VIDEO_PROCESSOR_FILTER_NOISE_REDUCTION = 4,
	// D3D11_VIDEO_PROCESSOR_FILTER_EDGE_ENHANCEMENT = 5, D3D11_VIDEO_PROCESSOR_FILTER_ANAMORPHIC_SCALING = 6,
	// D3D11_VIDEO_PROCESSOR_FILTER_STEREO_ADJUSTMENT = 7 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_FILTER")]
	public enum D3D11_VIDEO_PROCESSOR_FILTER
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Brightness filter.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_BRIGHTNESS = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Contrast filter.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_CONTRAST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Hue filter.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_HUE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Saturation filter.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_SATURATION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Noise reduction filter.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_NOISE_REDUCTION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Edge enhancement filter.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_EDGE_ENHANCEMENT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Anamorphic scaling filter.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_ANAMORPHIC_SCALING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>
		/// Stereo adjustment filter. When stereo 3D video is enabled, this filter adjusts the offset between the left and right views,
		/// allowing the user to reduce potential eye strain.
		/// </para>
		/// <para>
		/// The filter value indicates the amount by which the left and right views are adjusted. A positive value shifts the images away
		/// from each other: the left image toward the left, and the right image toward the right. A negative value shifts the images in the
		/// opposite directions, closer to each other.
		/// </para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_STEREO_ADJUSTMENT,
	}

	/// <summary>Defines image filter capabilities for a Microsoft Direct3D 11 video processor.</summary>
	/// <remarks>
	/// These capability flags indicate support for the image filters defined by the D3D11_VIDEO_PROCESSOR_FILTER enumeration. To apply a
	/// particular filter, call the ID3D11VideoContext::VideoProcessorSetStreamFilter method.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_filter_caps typedef enum
	// D3D11_VIDEO_PROCESSOR_FILTER_CAPS { D3D11_VIDEO_PROCESSOR_FILTER_CAPS_BRIGHTNESS = 0x1, D3D11_VIDEO_PROCESSOR_FILTER_CAPS_CONTRAST =
	// 0x2, D3D11_VIDEO_PROCESSOR_FILTER_CAPS_HUE = 0x4, D3D11_VIDEO_PROCESSOR_FILTER_CAPS_SATURATION = 0x8,
	// D3D11_VIDEO_PROCESSOR_FILTER_CAPS_NOISE_REDUCTION = 0x10, D3D11_VIDEO_PROCESSOR_FILTER_CAPS_EDGE_ENHANCEMENT = 0x20,
	// D3D11_VIDEO_PROCESSOR_FILTER_CAPS_ANAMORPHIC_SCALING = 0x40, D3D11_VIDEO_PROCESSOR_FILTER_CAPS_STEREO_ADJUSTMENT = 0x80 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_FILTER_CAPS")]
	[Flags]
	public enum D3D11_VIDEO_PROCESSOR_FILTER_CAPS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The video processor can adjust the brightness level.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_CAPS_BRIGHTNESS = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The video processor can adjust the contrast level.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_CAPS_CONTRAST = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The video processor can adjust hue.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_CAPS_HUE = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The video processor can adjust the saturation level.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_CAPS_SATURATION = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The video processor can perform noise reduction.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_CAPS_NOISE_REDUCTION = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>The video processor can perform edge enhancement.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_CAPS_EDGE_ENHANCEMENT = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>
		/// The video processor can perform anamorphic scaling. Anamorphic scaling can be used to stretch 4:3 content to a widescreen 16:9
		/// aspect ratio.
		/// </para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_CAPS_ANAMORPHIC_SCALING = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>
		/// For stereo 3D video, the video processor can adjust the offset between the left and right views, allowing the user to reduce
		/// potential eye strain.
		/// </para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FILTER_CAPS_STEREO_ADJUSTMENT = 0x80,
	}

	/// <summary>Defines capabilities related to input formats for a Microsoft Direct3D 11 video processor.</summary>
	/// <remarks>
	/// <para>
	/// These flags define video processing capabilities that usually are not needed, and that video devices are therefore not required to support.
	/// </para>
	/// <para>
	/// The first three flags relate to RGB support for functions that are normally applied to YCbCr video: deinterlacing, color adjustment,
	/// and luma keying. A device that supports these functions for YCbCr is not required to support them for RGB input. Supporting RGB
	/// input for these functions is an additional capability, reflected by these constants. Note that the driver might convert the input to
	/// another color space, perform the indicated function, and then convert the result back to RGB.
	/// </para>
	/// <para>
	/// Similarly, a device that supports deinterlacing is not required to support deinterlacing of palettized formats. This capability is
	/// indicated by the <c>D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_PALETTE_INTERLACED</c> flag.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_format_caps typedef enum
	// D3D11_VIDEO_PROCESSOR_FORMAT_CAPS { D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_INTERLACED = 0x1,
	// D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_PROCAMP = 0x2, D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_LUMA_KEY = 0x4,
	// D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_PALETTE_INTERLACED = 0x8 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_FORMAT_CAPS")]
	[Flags]
	public enum D3D11_VIDEO_PROCESSOR_FORMAT_CAPS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The video processor can deinterlace an input stream that contains interlaced RGB video.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_INTERLACED = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The video processor can perform color adjustment on RGB video.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_PROCAMP = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The video processor can perform luma keying on RGB video.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_LUMA_KEY = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The video processor can deinterlace input streams with palettized color formats.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_PALETTE_INTERLACED = 0x8,
	}

	/// <summary>Specifies how a video format can be used for video processing.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_format_support typedef enum
	// D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT { D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT_INPUT = 0x1, D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT_OUTPUT
	// = 0x2 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT")]
	[Flags]
	public enum D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The format can be used as the input to the video processor.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT_INPUT = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The format can be used as the output from the video processor.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT_OUTPUT = 0x2,
	}

	/// <summary>Specifies the rate at which the video processor produces output frames from an input stream.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_output_rate typedef enum
	// D3D11_VIDEO_PROCESSOR_OUTPUT_RATE { D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_NORMAL = 0, D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_HALF = 1,
	// D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM = 2 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_OUTPUT_RATE")]
	public enum D3D11_VIDEO_PROCESSOR_OUTPUT_RATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The output is the normal frame rate.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_NORMAL = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The output is half the frame rate.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_HALF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The output is a custom frame rate.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM,
	}

	/// <summary>Specifies the video rotation states.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_rotation typedef enum
	// D3D11_VIDEO_PROCESSOR_ROTATION { D3D11_VIDEO_PROCESSOR_ROTATION_IDENTITY = 0, D3D11_VIDEO_PROCESSOR_ROTATION_90 = 1,
	// D3D11_VIDEO_PROCESSOR_ROTATION_180 = 2, D3D11_VIDEO_PROCESSOR_ROTATION_270 = 3 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_ROTATION")]
	public enum D3D11_VIDEO_PROCESSOR_ROTATION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The video is not rotated.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_ROTATION_IDENTITY = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The video is rotated 90 degrees clockwise.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_ROTATION_90,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The video is rotated 180 degrees clockwise.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_ROTATION_180,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The video is rotated 270 degrees clockwise.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_ROTATION_270,
	}

	/// <summary>Defines stereo 3D capabilities for a Microsoft Direct3D 11 video processor.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_stereo_caps typedef enum
	// D3D11_VIDEO_PROCESSOR_STEREO_CAPS { D3D11_VIDEO_PROCESSOR_STEREO_CAPS_MONO_OFFSET = 0x1,
	// D3D11_VIDEO_PROCESSOR_STEREO_CAPS_ROW_INTERLEAVED = 0x2, D3D11_VIDEO_PROCESSOR_STEREO_CAPS_COLUMN_INTERLEAVED = 0x4,
	// D3D11_VIDEO_PROCESSOR_STEREO_CAPS_CHECKERBOARD = 0x8, D3D11_VIDEO_PROCESSOR_STEREO_CAPS_FLIP_MODE = 0x10 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_STEREO_CAPS")]
	[Flags]
	public enum D3D11_VIDEO_PROCESSOR_STEREO_CAPS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The video processor supports the</para>
		/// <para>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</para>
		/// <para>format.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_CAPS_MONO_OFFSET = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The video processor supports the</para>
		/// <para>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_ROW_INTERLEAVED</para>
		/// <para>format.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_CAPS_ROW_INTERLEAVED = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The video processor supports the</para>
		/// <para>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_COLUMN_INTERLEAVED</para>
		/// <para>format.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_CAPS_COLUMN_INTERLEAVED = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The video processor supports the</para>
		/// <para>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_CHECKERBOARD</para>
		/// <para>format.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_CAPS_CHECKERBOARD = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The video processor can flip one or both views. For more information, see</para>
		/// <para>D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE</para>
		/// <para>.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_CAPS_FLIP_MODE = 0x10,
	}

	/// <summary>For stereo 3D video, specifies whether the data in frame 0 or frame 1 is flipped, either horizontally or vertically.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_stereo_flip_mode typedef enum
	// D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE { D3D11_VIDEO_PROCESSOR_STEREO_FLIP_NONE = 0, D3D11_VIDEO_PROCESSOR_STEREO_FLIP_FRAME0 = 1,
	// D3D11_VIDEO_PROCESSOR_STEREO_FLIP_FRAME1 = 2 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE")]
	public enum D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Neither frame is flipped.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FLIP_NONE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The data in frame 0 is flipped.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FLIP_FRAME0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The data in frame 1 is flipped.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FLIP_FRAME1,
	}

	/// <summary>Specifies the layout in memory of a stereo 3D video frame.</summary>
	/// <remarks>
	/// <para>
	/// This enumeration designates the two stereo views as "frame 0" and "frame 1". The <c>LeftViewFrame0</c> parameter of the
	/// VideoProcessorSetStreamStereoFormat method specifies which view is the left view, and which is the right view.
	/// </para>
	/// <para>
	/// For packed formats, if the source rectangle clips part of the surface, the driver interprets the rectangle in logical coordinates
	/// relative to the stereo view, rather than absolute pixel coordinates. The result is that frame 0 and frame 1 are clipped proportionately.
	/// </para>
	/// <para>
	/// To query whether the device supports stereo 3D video, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check for the
	/// <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_STEREO</c> flag in the <c>FeatureCaps</c> member of the D3D11_VIDEO_PROCESSOR_CAPS structure.
	/// If this capability flag is present, it means that the driver supports all of the stereo formats that are not listed as optional. To
	/// find out which optional formats are supported, call <c>GetVideoProcessorCaps</c> and check the <c>StereoCaps</c> member of the structure.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_processor_stereo_format typedef enum
	// D3D11_VIDEO_PROCESSOR_STEREO_FORMAT { D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO = 0, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_HORIZONTAL =
	// 1, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_VERTICAL = 2, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE = 3,
	// D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET = 4, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_ROW_INTERLEAVED = 5,
	// D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_COLUMN_INTERLEAVED = 6, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_CHECKERBOARD = 7 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_PROCESSOR_STEREO_FORMAT")]
	public enum D3D11_VIDEO_PROCESSOR_STEREO_FORMAT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The sample does not contain stereo data. If the stereo format is not specified, this value is the default.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Frame 0 and frame 1 are packed side-by-side, as shown in the following diagram.</para>
		/// <para>All drivers that support stereo video must support this format.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_HORIZONTAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Frame 0 and frame 1 are packed top-to-bottom, as shown in the following diagram.</para>
		/// <para>All drivers that support stereo video must support this format.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_VERTICAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Frame 0 and frame 1 are placed in separate resources or in separate texture array elements within the same resource.</para>
		/// <para>All drivers that support stereo video must support this format.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>
		/// The sample contains non-stereo data. However, the driver should create a left/right output of this sample using a specified
		/// offset. The offset is specified in the
		/// </para>
		/// <para>MonoOffset</para>
		/// <para>parameter of the</para>
		/// <para>ID3D11VideoContext::VideoProcessorSetStreamStereoFormat</para>
		/// <para>method.</para>
		/// <para>
		/// This format is primarily intended for subtitles and other subpicture data, where the entire sample is presented on the same plane.
		/// </para>
		/// <para>Support for this stereo format is optional.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Frame 0 and frame 1 are packed into interleaved rows, as shown in the following diagram.</para>
		/// <para>Support for this stereo format is optional.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_ROW_INTERLEAVED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Frame 0 and frame 1 are packed into interleaved columns, as shown in the following diagram.</para>
		/// <para>Support for this stereo format is optional.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_COLUMN_INTERLEAVED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Frame 0 and frame 1 are packed in a checkerboard format, as shown in the following diagram.</para>
		/// <para>Support for this stereo format is optional.</para>
		/// </summary>
		D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_CHECKERBOARD,
	}

	/// <summary>Specifies the intended use for a video processor.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_video_usage typedef enum D3D11_VIDEO_USAGE {
	// D3D11_VIDEO_USAGE_PLAYBACK_NORMAL = 0, D3D11_VIDEO_USAGE_OPTIMAL_SPEED = 1, D3D11_VIDEO_USAGE_OPTIMAL_QUALITY = 2 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VIDEO_USAGE")]
	public enum D3D11_VIDEO_USAGE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Normal video playback. The graphics driver should expose a set of capabilities that are appropriate for real-time video playback.
		/// </para>
		/// </summary>
		D3D11_VIDEO_USAGE_PLAYBACK_NORMAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Optimal speed. The graphics driver should expose a minimal set of capabilities that are optimized for performance.</para>
		/// <para>
		/// Use this setting if you want better performance and can accept some reduction in video quality. For example, you might use this
		/// setting in power-saving mode or to play video thumbnails.
		/// </para>
		/// </summary>
		D3D11_VIDEO_USAGE_OPTIMAL_SPEED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Optimal quality. The graphics driver should expose its maximum set of capabilities.</para>
		/// <para>
		/// Specify this setting to get the best video quality possible. It is appropriate for tasks such as video editing, when quality is
		/// more important than speed. It is not appropriate for real-time playback.
		/// </para>
		/// </summary>
		D3D11_VIDEO_USAGE_OPTIMAL_QUALITY,
	}

	/// <summary>Specifies how to access a resource that is used in a video processor input view.</summary>
	/// <remarks>This enumeration is used with the D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_vpiv_dimension typedef enum D3D11_VPIV_DIMENSION {
	// D3D11_VPIV_DIMENSION_UNKNOWN = 0, D3D11_VPIV_DIMENSION_TEXTURE2D = 1 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VPIV_DIMENSION")]
	public enum D3D11_VPIV_DIMENSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Not a valid value.</para>
		/// </summary>
		D3D11_VPIV_DIMENSION_UNKNOWN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The resource will be accessed as a 2D texture.</para>
		/// </summary>
		D3D11_VPIV_DIMENSION_TEXTURE2D,
	}

	/// <summary>Specifies how to access a resource that is used in a video processor output view.</summary>
	/// <remarks>This enumeration is used with the D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_vpov_dimension typedef enum D3D11_VPOV_DIMENSION {
	// D3D11_VPOV_DIMENSION_UNKNOWN = 0, D3D11_VPOV_DIMENSION_TEXTURE2D = 1, D3D11_VPOV_DIMENSION_TEXTURE2DARRAY = 2 } ;
	[PInvokeData("d3d11.h", MSDNShortId = "NE:d3d11.D3D11_VPOV_DIMENSION")]
	public enum D3D11_VPOV_DIMENSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Not a valid value.</para>
		/// </summary>
		D3D11_VPOV_DIMENSION_UNKNOWN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The resource will be accessed as a 2D texture.</para>
		/// </summary>
		D3D11_VPOV_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The resource will be accessed as an array of 2D textures.</para>
		/// </summary>
		D3D11_VPOV_DIMENSION_TEXTURE2DARRAY,
	}
}