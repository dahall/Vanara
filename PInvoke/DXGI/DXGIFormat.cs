#if !NET45
using CommunityToolkit.HighPerformance;
#endif

namespace Vanara.PInvoke;

public static partial class DXGI
{
	/// <summary>
	/// Resource data formats, including fully-typed and typeless formats. A list of modifiers at the bottom of the page more fully
	/// describes each format type.
	/// </summary>
	/// <remarks>
	/// <para>Byte Order (LSB/MSB)</para>
	/// <para>
	/// Most formats have byte-aligned components, and the components are in C-array order (the least address comes first). For those
	/// formats that don't have power-of-2-aligned components, the first named component is in the least-significant bits.
	/// </para>
	/// <para>Portable Coding for Endian-Independence</para>
	/// <para>
	/// Rather than adjusting for whether a system uses big-endian or little-endian byte ordering, you should write portable code, as follows.
	/// </para>
	/// <para>Restrictions and notes on formats</para>
	/// <para>A few formats have additional restrictions and implied behavior:</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// A resource declared with the DXGI_FORMAT_R32G32B32 family of formats cannot be used simultaneously for vertex and texture data. That
	/// is, you may not create a buffer resource with the DXGI_FORMAT_R32G32B32 family of formats that uses any of the following bind flags:
	/// D3D10_BIND_VERTEX_BUFFER, D3D10_BIND_INDEX_BUFFER, D3D10_BIND_CONSTANT_BUFFER, or D3D10_BIND_STREAM_OUTPUT (see D3D10_BIND_FLAG).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// DXGI_FORMAT_R1_UNORM is designed specifically for text filtering, and must be used with a format-specific, configurable 8x8 filter
	/// mode. When calling an HLSL sampling function using this format, the address offset parameter must be set to (0,0).
	/// </term>
	/// </item>
	/// <item>
	/// <term>A resource using a sub-sampled format (such as DXGI_FORMAT_R8G8_B8G8) must have a size that is a multiple of 2 in the x dimension.</term>
	/// </item>
	/// <item>
	/// <term>Format is not available in Direct3D 10 and Direct3D 10.1</term>
	/// </item>
	/// <item>
	/// <term>
	/// These float formats have an implied 1 added to their mantissa. If the exponent is not 0, 1.0 is added to the mantissa before
	/// applying the exponent.
	/// </term>
	/// </item>
	/// <item>
	/// <term>These float formats do not have an implied 1 added to their mantissa.</term>
	/// </item>
	/// <item>
	/// <term>Denorm support: the 9, 10, 11 and 16 bit float formats support denorms.</term>
	/// </item>
	/// <item>
	/// <term>No denorm support: the 32 and 64 bit float formats flush denorms to zero.</term>
	/// </item>
	/// </list>
	/// <para>The following topics provide lists of the formats that particular hardware feature levels support:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>DXGI Format Support for Direct3D Feature Level 12.1 Hardware</term>
	/// </item>
	/// <item>
	/// <term>DXGI Format Support for Direct3D Feature Level 12.0 Hardware</term>
	/// </item>
	/// <item>
	/// <term>DXGI Format Support for Direct3D Feature Level 11.1 Hardware</term>
	/// </item>
	/// <item>
	/// <term>DXGI Format Support for Direct3D Feature Level 11.0 Hardware</term>
	/// </item>
	/// <item>
	/// <term>Hardware Support for Direct3D 10Level9 Formats</term>
	/// </item>
	/// <item>
	/// <term>Hardware Support for Direct3D 10.1 Formats</term>
	/// </item>
	/// <item>
	/// <term>Hardware Support for Direct3D 10 Formats</term>
	/// </item>
	/// </list>
	/// <para>For a list of the <c>DirectXMath</c> types that map to <c>DXGI_FORMAT</c> values, see DirectXMath Library Internals.</para>
	/// <para>Format Modifiers</para>
	/// <para>Each enumeration value contains a format modifier which describes the data type.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Format Modifiers</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>_FLOAT</term>
	/// <term>
	/// A floating-point value; 32-bit floating-point formats use IEEE 754 single-precision (s23e8 format): sign bit, 8-bit biased (127)
	/// exponent, and 23-bit mantissa. 16-bit floating-point formats use half-precision (s10e5 format): sign bit, 5-bit biased (15)
	/// exponent, and 10-bit mantissa.
	/// </term>
	/// </item>
	/// <item>
	/// <term>_SINT</term>
	/// <term>Two's complement signed integer. For example, a 3-bit SINT represents the values -4, -3, -2, -1, 0, 1, 2, 3.</term>
	/// </item>
	/// <item>
	/// <term>_SNORM</term>
	/// <term>
	/// Signed normalized integer; which is interpreted in a resource as a signed integer, and is interpreted in a shader as a signed
	/// normalized floating-point value in the range [-1, 1]. For an 2's complement number, the maximum value is 1.0f (a 5-bit value 01111
	/// maps to 1.0f), and the minimum value is -1.0f (a 5-bit value 10000 maps to -1.0f). In addition, the second-minimum number maps to
	/// -1.0f (a 5-bit value 10001 maps to -1.0f). The resulting integer representations are evenly spaced floating-point values in the
	/// range (-1.0f...0.0f), and also a complementary set of representations for numbers in the range (0.0f...1.0f).
	/// </term>
	/// </item>
	/// <item>
	/// <term>_SRGB</term>
	/// <term>
	/// Standard RGB data, which roughly displays colors in a linear ramp of luminosity levels such that an average observer, under average
	/// viewing conditions, can view them on an average display. All 0's maps to 0.0f, and all 1's maps to 1.0f. The sequence of unsigned
	/// integer encodings between all 0's and all 1's represent a nonlinear progression in the floating-point interpretation of the numbers
	/// between 0.0f to 1.0f. For more detail, see the SRGB color standard, IEC 61996-2-1, at IEC (International Electrotechnical
	/// Commission).Conversion to or from sRGB space is automatically done by D3DX10 or D3DX9 texture-load functions. If a format with _SRGB
	/// has an A channel, the A channel is stored in Gamma 1.0f data; the R, G, and B channels in the format are stored in Gamma 2.2f data.
	/// </term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>_TYPELESS</term>
	/// <term>
	/// Typeless data, with a defined number of bits. Typeless formats are designed for creating typeless resources; that is, a resource
	/// whose size is known, but whose data type is not yet fully defined. When a typeless resource is bound to a shader, the application or
	/// shader must resolve the format type (which must match the number of bits per component in the typeless format). A typeless format
	/// contains one or more subformats; each subformat resolves the data type. For example, in the R32G32B32 group, which defines types for
	/// three-component 96-bit data, there is one typeless format and three fully typed subformats.
	/// </term>
	/// </item>
	/// <item>
	/// <term>_UINT</term>
	/// <term>Unsigned integer. For instance, a 3-bit UINT represents the values 0, 1, 2, 3, 4, 5, 6, 7.</term>
	/// </item>
	/// <item>
	/// <term>_UNORM</term>
	/// <term>
	/// Unsigned normalized integer; which is interpreted in a resource as an unsigned integer, and is interpreted in a shader as an
	/// unsigned normalized floating-point value in the range [0, 1]. All 0's maps to 0.0f, and all 1's maps to 1.0f. A sequence of evenly
	/// spaced floating-point values from 0.0f to 1.0f are represented. For instance, a 2-bit UNORM represents 0.0f, 1/3, 2/3, and 1.0f.
	/// </term>
	/// </item>
	/// <item>
	/// <term>_SHAREDEXP</term>
	/// <term>A shared exponent. All the floating point representations in the format share the one exponent.</term>
	/// </item>
	/// </list>
	/// <para>New Resource Formats</para>
	/// <para>
	/// Direct3D 10 offers new data compression formats for compressing high-dynamic range (HDR) lighting data, normal maps and heightfields
	/// to a fraction of their original size. These compression types include:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Shared-Exponent high-dynamic range (HDR) format (RGBE)</term>
	/// </item>
	/// <item>
	/// <term>New Block-Compressed 1-2 channel UNORM/SNORM formats</term>
	/// </item>
	/// </list>
	/// <para>
	/// The block compression formats can be used for any of the 2D or 3D texture types ( Texture2D, Texture2DArray, Texture3D, or
	/// TextureCube) including mipmap surfaces. The block compression techniques require texture dimensions to be a multiple of 4 (since the
	/// implementation compresses on blocks of 4x4 texels). In the texture sampler, compressed formats are always decompressed before
	/// texture filtering.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format typedef enum DXGI_FORMAT {
	// DXGI_FORMAT_UNKNOWN, DXGI_FORMAT_R32G32B32A32_TYPELESS, DXGI_FORMAT_R32G32B32A32_FLOAT, DXGI_FORMAT_R32G32B32A32_UINT,
	// DXGI_FORMAT_R32G32B32A32_SINT, DXGI_FORMAT_R32G32B32_TYPELESS, DXGI_FORMAT_R32G32B32_FLOAT, DXGI_FORMAT_R32G32B32_UINT,
	// DXGI_FORMAT_R32G32B32_SINT, DXGI_FORMAT_R16G16B16A16_TYPELESS, DXGI_FORMAT_R16G16B16A16_FLOAT, DXGI_FORMAT_R16G16B16A16_UNORM,
	// DXGI_FORMAT_R16G16B16A16_UINT, DXGI_FORMAT_R16G16B16A16_SNORM, DXGI_FORMAT_R16G16B16A16_SINT, DXGI_FORMAT_R32G32_TYPELESS,
	// DXGI_FORMAT_R32G32_FLOAT, DXGI_FORMAT_R32G32_UINT, DXGI_FORMAT_R32G32_SINT, DXGI_FORMAT_R32G8X24_TYPELESS,
	// DXGI_FORMAT_D32_FLOAT_S8X24_UINT, DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS, DXGI_FORMAT_X32_TYPELESS_G8X24_UINT,
	// DXGI_FORMAT_R10G10B10A2_TYPELESS, DXGI_FORMAT_R10G10B10A2_UNORM, DXGI_FORMAT_R10G10B10A2_UINT, DXGI_FORMAT_R11G11B10_FLOAT,
	// DXGI_FORMAT_R8G8B8A8_TYPELESS, DXGI_FORMAT_R8G8B8A8_UNORM, DXGI_FORMAT_R8G8B8A8_UNORM_SRGB, DXGI_FORMAT_R8G8B8A8_UINT,
	// DXGI_FORMAT_R8G8B8A8_SNORM, DXGI_FORMAT_R8G8B8A8_SINT, DXGI_FORMAT_R16G16_TYPELESS, DXGI_FORMAT_R16G16_FLOAT,
	// DXGI_FORMAT_R16G16_UNORM, DXGI_FORMAT_R16G16_UINT, DXGI_FORMAT_R16G16_SNORM, DXGI_FORMAT_R16G16_SINT, DXGI_FORMAT_R32_TYPELESS,
	// DXGI_FORMAT_D32_FLOAT, DXGI_FORMAT_R32_FLOAT, DXGI_FORMAT_R32_UINT, DXGI_FORMAT_R32_SINT, DXGI_FORMAT_R24G8_TYPELESS,
	// DXGI_FORMAT_D24_UNORM_S8_UINT, DXGI_FORMAT_R24_UNORM_X8_TYPELESS, DXGI_FORMAT_X24_TYPELESS_G8_UINT, DXGI_FORMAT_R8G8_TYPELESS,
	// DXGI_FORMAT_R8G8_UNORM, DXGI_FORMAT_R8G8_UINT, DXGI_FORMAT_R8G8_SNORM, DXGI_FORMAT_R8G8_SINT, DXGI_FORMAT_R16_TYPELESS,
	// DXGI_FORMAT_R16_FLOAT, DXGI_FORMAT_D16_UNORM, DXGI_FORMAT_R16_UNORM, DXGI_FORMAT_R16_UINT, DXGI_FORMAT_R16_SNORM,
	// DXGI_FORMAT_R16_SINT, DXGI_FORMAT_R8_TYPELESS, DXGI_FORMAT_R8_UNORM, DXGI_FORMAT_R8_UINT, DXGI_FORMAT_R8_SNORM, DXGI_FORMAT_R8_SINT,
	// DXGI_FORMAT_A8_UNORM, DXGI_FORMAT_R1_UNORM, DXGI_FORMAT_R9G9B9E5_SHAREDEXP, DXGI_FORMAT_R8G8_B8G8_UNORM, DXGI_FORMAT_G8R8_G8B8_UNORM,
	// DXGI_FORMAT_BC1_TYPELESS, DXGI_FORMAT_BC1_UNORM, DXGI_FORMAT_BC1_UNORM_SRGB, DXGI_FORMAT_BC2_TYPELESS, DXGI_FORMAT_BC2_UNORM,
	// DXGI_FORMAT_BC2_UNORM_SRGB, DXGI_FORMAT_BC3_TYPELESS, DXGI_FORMAT_BC3_UNORM, DXGI_FORMAT_BC3_UNORM_SRGB, DXGI_FORMAT_BC4_TYPELESS,
	// DXGI_FORMAT_BC4_UNORM, DXGI_FORMAT_BC4_SNORM, DXGI_FORMAT_BC5_TYPELESS, DXGI_FORMAT_BC5_UNORM, DXGI_FORMAT_BC5_SNORM,
	// DXGI_FORMAT_B5G6R5_UNORM, DXGI_FORMAT_B5G5R5A1_UNORM, DXGI_FORMAT_B8G8R8A8_UNORM, DXGI_FORMAT_B8G8R8X8_UNORM,
	// DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM, DXGI_FORMAT_B8G8R8A8_TYPELESS, DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,
	// DXGI_FORMAT_B8G8R8X8_TYPELESS, DXGI_FORMAT_B8G8R8X8_UNORM_SRGB, DXGI_FORMAT_BC6H_TYPELESS, DXGI_FORMAT_BC6H_UF16,
	// DXGI_FORMAT_BC6H_SF16, DXGI_FORMAT_BC7_TYPELESS, DXGI_FORMAT_BC7_UNORM, DXGI_FORMAT_BC7_UNORM_SRGB, DXGI_FORMAT_AYUV,
	// DXGI_FORMAT_Y410, DXGI_FORMAT_Y416, DXGI_FORMAT_NV12, DXGI_FORMAT_P010, DXGI_FORMAT_P016, DXGI_FORMAT_420_OPAQUE, DXGI_FORMAT_YUY2,
	// DXGI_FORMAT_Y210, DXGI_FORMAT_Y216, DXGI_FORMAT_NV11, DXGI_FORMAT_AI44, DXGI_FORMAT_IA44, DXGI_FORMAT_P8, DXGI_FORMAT_A8P8,
	// DXGI_FORMAT_B4G4R4A4_UNORM, DXGI_FORMAT_P208, DXGI_FORMAT_V208, DXGI_FORMAT_V408, DXGI_FORMAT_SAMPLER_FEEDBACK_MIN_MIP_OPAQUE,
	// DXGI_FORMAT_SAMPLER_FEEDBACK_MIP_REGION_USED_OPAQUE, DXGI_FORMAT_FORCE_UINT } ;
	[PInvokeData("dxgiformat.h")]
	public enum DXGI_FORMAT : uint
	{
		/// <summary>The format is not known.</summary>
		DXGI_FORMAT_UNKNOWN,

		/// <summary>A four-component, 128-bit typeless format that supports 32 bits per channel including alpha. ¹</summary>
		DXGI_FORMAT_R32G32B32A32_TYPELESS,

		/// <summary>A four-component, 128-bit floating-point format that supports 32 bits per channel including alpha.</summary>
		DXGI_FORMAT_R32G32B32A32_FLOAT,

		/// <summary>A four-component, 128-bit unsigned-integer format that supports 32 bits per channel including alpha. ¹</summary>
		DXGI_FORMAT_R32G32B32A32_UINT,

		/// <summary>A four-component, 128-bit signed-integer format that supports 32 bits per channel including alpha. ¹</summary>
		DXGI_FORMAT_R32G32B32A32_SINT,

		/// <summary>A three-component, 96-bit typeless format that supports 32 bits per color channel.</summary>
		DXGI_FORMAT_R32G32B32_TYPELESS,

		/// <summary>A three-component, 96-bit floating-point format that supports 32 bits per color channel.</summary>
		DXGI_FORMAT_R32G32B32_FLOAT,

		/// <summary>A three-component, 96-bit unsigned-integer format that supports 32 bits per color channel.</summary>
		DXGI_FORMAT_R32G32B32_UINT,

		/// <summary>A three-component, 96-bit signed-integer format that supports 32 bits per color channel.</summary>
		DXGI_FORMAT_R32G32B32_SINT,

		/// <summary>A four-component, 64-bit typeless format that supports 16 bits per channel including alpha.</summary>
		DXGI_FORMAT_R16G16B16A16_TYPELESS,

		/// <summary>A four-component, 64-bit floating-point format that supports 16 bits per channel including alpha.</summary>
		DXGI_FORMAT_R16G16B16A16_FLOAT,

		/// <summary>A four-component, 64-bit unsigned-normalized-integer format that supports 16 bits per channel including alpha.</summary>
		DXGI_FORMAT_R16G16B16A16_UNORM,

		/// <summary>A four-component, 64-bit unsigned-integer format that supports 16 bits per channel including alpha.</summary>
		DXGI_FORMAT_R16G16B16A16_UINT,

		/// <summary>A four-component, 64-bit signed-normalized-integer format that supports 16 bits per channel including alpha.</summary>
		DXGI_FORMAT_R16G16B16A16_SNORM,

		/// <summary>A four-component, 64-bit signed-integer format that supports 16 bits per channel including alpha.</summary>
		DXGI_FORMAT_R16G16B16A16_SINT,

		/// <summary>A two-component, 64-bit typeless format that supports 32 bits for the red channel and 32 bits for the green channel.</summary>
		DXGI_FORMAT_R32G32_TYPELESS,

		/// <summary>
		/// A two-component, 64-bit floating-point format that supports 32 bits for the red channel and 32 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R32G32_FLOAT,

		/// <summary>
		/// A two-component, 64-bit unsigned-integer format that supports 32 bits for the red channel and 32 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R32G32_UINT,

		/// <summary>
		/// A two-component, 64-bit signed-integer format that supports 32 bits for the red channel and 32 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R32G32_SINT,

		/// <summary>
		/// A two-component, 64-bit typeless format that supports 32 bits for the red channel, 8 bits for the green channel, and 24 bits are unused.
		/// </summary>
		DXGI_FORMAT_R32G8X24_TYPELESS,

		/// <summary>
		/// A 32-bit floating-point component, and two unsigned-integer components (with an additional 32 bits). This format supports 32-bit
		/// depth, 8-bit stencil, and 24 bits are unused.⁵
		/// </summary>
		DXGI_FORMAT_D32_FLOAT_S8X24_UINT,

		/// <summary>
		/// A 32-bit floating-point component, and two typeless components (with an additional 32 bits). This format supports 32-bit red
		/// channel, 8 bits are unused, and 24 bits are unused.⁵
		/// </summary>
		DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS,

		/// <summary>
		/// A 32-bit typeless component, and two unsigned-integer components (with an additional 32 bits). This format has 32 bits unused, 8
		/// bits for green channel, and 24 bits are unused.
		/// </summary>
		DXGI_FORMAT_X32_TYPELESS_G8X24_UINT,

		/// <summary>A four-component, 32-bit typeless format that supports 10 bits for each color and 2 bits for alpha.</summary>
		DXGI_FORMAT_R10G10B10A2_TYPELESS,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized-integer format that supports 10 bits for each color and 2 bits for alpha.
		/// </summary>
		DXGI_FORMAT_R10G10B10A2_UNORM,

		/// <summary>A four-component, 32-bit unsigned-integer format that supports 10 bits for each color and 2 bits for alpha.</summary>
		DXGI_FORMAT_R10G10B10A2_UINT,

		/// <summary>
		/// Three partial-precision floating-point numbers encoded into a single 32-bit value (a variant of s10e5, which is sign bit, 10-bit
		/// mantissa, and 5-bit biased (15) exponent). There are no sign bits, and there is a 5-bit biased (15) exponent for each channel,
		/// 6-bit mantissa for R and G, and a 5-bit mantissa for B, as shown in the following illustration.
		/// </summary>
		DXGI_FORMAT_R11G11B10_FLOAT,

		/// <summary>A four-component, 32-bit typeless format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_TYPELESS,

		/// <summary>A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_UNORM,

		/// <summary>A four-component, 32-bit unsigned-normalized integer sRGB format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_UNORM_SRGB,

		/// <summary>A four-component, 32-bit unsigned-integer format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_UINT,

		/// <summary>A four-component, 32-bit signed-normalized-integer format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_SNORM,

		/// <summary>A four-component, 32-bit signed-integer format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_SINT,

		/// <summary>A two-component, 32-bit typeless format that supports 16 bits for the red channel and 16 bits for the green channel.</summary>
		DXGI_FORMAT_R16G16_TYPELESS,

		/// <summary>
		/// A two-component, 32-bit floating-point format that supports 16 bits for the red channel and 16 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R16G16_FLOAT,

		/// <summary>A two-component, 32-bit unsigned-normalized-integer format that supports 16 bits each for the green and red channels.</summary>
		DXGI_FORMAT_R16G16_UNORM,

		/// <summary>
		/// A two-component, 32-bit unsigned-integer format that supports 16 bits for the red channel and 16 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R16G16_UINT,

		/// <summary>
		/// A two-component, 32-bit signed-normalized-integer format that supports 16 bits for the red channel and 16 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R16G16_SNORM,

		/// <summary>
		/// A two-component, 32-bit signed-integer format that supports 16 bits for the red channel and 16 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R16G16_SINT,

		/// <summary>A single-component, 32-bit typeless format that supports 32 bits for the red channel.</summary>
		DXGI_FORMAT_R32_TYPELESS,

		/// <summary>A single-component, 32-bit floating-point format that supports 32 bits for depth.</summary>
		DXGI_FORMAT_D32_FLOAT,

		/// <summary>A single-component, 32-bit floating-point format that supports 32 bits for the red channel.</summary>
		DXGI_FORMAT_R32_FLOAT,

		/// <summary>A single-component, 32-bit unsigned-integer format that supports 32 bits for the red channel.</summary>
		DXGI_FORMAT_R32_UINT,

		/// <summary>A single-component, 32-bit signed-integer format that supports 32 bits for the red channel.</summary>
		DXGI_FORMAT_R32_SINT,

		/// <summary>A two-component, 32-bit typeless format that supports 24 bits for the red channel and 8 bits for the green channel.</summary>
		DXGI_FORMAT_R24G8_TYPELESS,

		/// <summary>A 32-bit z-buffer format that supports 24 bits for depth and 8 bits for stencil.</summary>
		DXGI_FORMAT_D24_UNORM_S8_UINT,

		/// <summary>
		/// A 32-bit format, that contains a 24 bit, single-component, unsigned-normalized integer, with an additional typeless 8 bits. This
		/// format has 24 bits red channel and 8 bits unused.
		/// </summary>
		DXGI_FORMAT_R24_UNORM_X8_TYPELESS,

		/// <summary>
		/// A 32-bit format, that contains a 24 bit, single-component, typeless format, with an additional 8 bit unsigned integer component.
		/// This format has 24 bits unused and 8 bits green channel.
		/// </summary>
		DXGI_FORMAT_X24_TYPELESS_G8_UINT,

		/// <summary>A two-component, 16-bit typeless format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
		DXGI_FORMAT_R8G8_TYPELESS,

		/// <summary>
		/// A two-component, 16-bit unsigned-normalized-integer format that supports 8 bits for the red channel and 8 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R8G8_UNORM,

		/// <summary>
		/// A two-component, 16-bit unsigned-integer format that supports 8 bits for the red channel and 8 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R8G8_UINT,

		/// <summary>
		/// A two-component, 16-bit signed-normalized-integer format that supports 8 bits for the red channel and 8 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R8G8_SNORM,

		/// <summary>
		/// A two-component, 16-bit signed-integer format that supports 8 bits for the red channel and 8 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R8G8_SINT,

		/// <summary>A single-component, 16-bit typeless format that supports 16 bits for the red channel.</summary>
		DXGI_FORMAT_R16_TYPELESS,

		/// <summary>A single-component, 16-bit floating-point format that supports 16 bits for the red channel.</summary>
		DXGI_FORMAT_R16_FLOAT,

		/// <summary>A single-component, 16-bit unsigned-normalized-integer format that supports 16 bits for depth.</summary>
		DXGI_FORMAT_D16_UNORM,

		/// <summary>A single-component, 16-bit unsigned-normalized-integer format that supports 16 bits for the red channel.</summary>
		DXGI_FORMAT_R16_UNORM,

		/// <summary>A single-component, 16-bit unsigned-integer format that supports 16 bits for the red channel.</summary>
		DXGI_FORMAT_R16_UINT,

		/// <summary>A single-component, 16-bit signed-normalized-integer format that supports 16 bits for the red channel.</summary>
		DXGI_FORMAT_R16_SNORM,

		/// <summary>A single-component, 16-bit signed-integer format that supports 16 bits for the red channel.</summary>
		DXGI_FORMAT_R16_SINT,

		/// <summary>A single-component, 8-bit typeless format that supports 8 bits for the red channel.</summary>
		DXGI_FORMAT_R8_TYPELESS,

		/// <summary>A single-component, 8-bit unsigned-normalized-integer format that supports 8 bits for the red channel.</summary>
		DXGI_FORMAT_R8_UNORM,

		/// <summary>A single-component, 8-bit unsigned-integer format that supports 8 bits for the red channel.</summary>
		DXGI_FORMAT_R8_UINT,

		/// <summary>A single-component, 8-bit signed-normalized-integer format that supports 8 bits for the red channel.</summary>
		DXGI_FORMAT_R8_SNORM,

		/// <summary>A single-component, 8-bit signed-integer format that supports 8 bits for the red channel.</summary>
		DXGI_FORMAT_R8_SINT,

		/// <summary>A single-component, 8-bit unsigned-normalized-integer format for alpha only.</summary>
		DXGI_FORMAT_A8_UNORM,

		/// <summary>A single-component, 1-bit unsigned-normalized integer format that supports 1 bit for the red channel. ².</summary>
		DXGI_FORMAT_R1_UNORM,

		/// <summary>
		/// Three partial-precision floating-point numbers encoded into a single 32-bit value all sharing the same 5-bit exponent (variant
		/// of s10e5, which is sign bit, 10-bit mantissa, and 5-bit biased (15) exponent). There is no sign bit, and there is a shared 5-bit
		/// biased (15) exponent and a 9-bit mantissa for each channel, as shown in the following illustration. .
		/// </summary>
		DXGI_FORMAT_R9G9B9E5_SHAREDEXP,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized-integer format. This packed RGB format is analogous to the UYVY format. Each 32-bit
		/// block describes a pair of pixels: (R8, G8, B8) and (R8, G8, B8) where the R8/B8 values are repeated, and the G8 values are
		/// unique to each pixel. ³Width must be even.
		/// </summary>
		DXGI_FORMAT_R8G8_B8G8_UNORM,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized-integer format. This packed RGB format is analogous to the YUY2 format. Each 32-bit
		/// block describes a pair of pixels: (R8, G8, B8) and (R8, G8, B8) where the R8/B8 values are repeated, and the G8 values are
		/// unique to each pixel. ³Width must be even.
		/// </summary>
		DXGI_FORMAT_G8R8_G8B8_UNORM,

		/// <summary>
		/// Four-component typeless block-compression format. For information about block-compression formats, see Texture Block Compression
		/// in Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC1_TYPELESS,

		/// <summary>
		/// Four-component block-compression format. For information about block-compression formats, see Texture Block Compression in
		/// Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC1_UNORM,

		/// <summary>
		/// Four-component block-compression format for sRGB data. For information about block-compression formats, see Texture Block
		/// Compression in Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC1_UNORM_SRGB,

		/// <summary>
		/// Four-component typeless block-compression format. For information about block-compression formats, see Texture Block Compression
		/// in Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC2_TYPELESS,

		/// <summary>
		/// Four-component block-compression format. For information about block-compression formats, see Texture Block Compression in
		/// Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC2_UNORM,

		/// <summary>
		/// Four-component block-compression format for sRGB data. For information about block-compression formats, see Texture Block
		/// Compression in Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC2_UNORM_SRGB,

		/// <summary>
		/// Four-component typeless block-compression format. For information about block-compression formats, see Texture Block Compression
		/// in Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC3_TYPELESS,

		/// <summary>
		/// Four-component block-compression format. For information about block-compression formats, see Texture Block Compression in
		/// Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC3_UNORM,

		/// <summary>
		/// Four-component block-compression format for sRGB data. For information about block-compression formats, see Texture Block
		/// Compression in Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC3_UNORM_SRGB,

		/// <summary>
		/// One-component typeless block-compression format. For information about block-compression formats, see Texture Block Compression
		/// in Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC4_TYPELESS,

		/// <summary>
		/// One-component block-compression format. For information about block-compression formats, see Texture Block Compression in
		/// Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC4_UNORM,

		/// <summary>
		/// One-component block-compression format. For information about block-compression formats, see Texture Block Compression in
		/// Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC4_SNORM,

		/// <summary>
		/// Two-component typeless block-compression format. For information about block-compression formats, see Texture Block Compression
		/// in Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC5_TYPELESS,

		/// <summary>
		/// Two-component block-compression format. For information about block-compression formats, see Texture Block Compression in
		/// Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC5_UNORM,

		/// <summary>
		/// Two-component block-compression format. For information about block-compression formats, see Texture Block Compression in
		/// Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC5_SNORM,

		/// <summary>
		/// A three-component, 16-bit unsigned-normalized-integer format that supports 5 bits for blue, 6 bits for green, and 5 bits for
		/// red.Direct3D 10 through Direct3D 11: This value is defined for DXGI. However, Direct3D 10, 10.1, or 11 devices do not support
		/// this format.Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_B5G6R5_UNORM,

		/// <summary>
		/// A four-component, 16-bit unsigned-normalized-integer format that supports 5 bits for each color channel and 1-bit alpha.Direct3D
		/// 10 through Direct3D 11: This value is defined for DXGI. However, Direct3D 10, 10.1, or 11 devices do not support this
		/// format.Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_B5G5R5A1_UNORM,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits for each color channel and 8-bit alpha.
		/// </summary>
		DXGI_FORMAT_B8G8R8A8_UNORM,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits for each color channel and 8 bits unused.
		/// </summary>
		DXGI_FORMAT_B8G8R8X8_UNORM,

		/// <summary>A four-component, 32-bit 2.8-biased fixed-point format that supports 10 bits for each color channel and 2-bit alpha.</summary>
		DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM,

		/// <summary>A four-component, 32-bit typeless format that supports 8 bits for each channel including alpha. ⁴</summary>
		DXGI_FORMAT_B8G8R8A8_TYPELESS,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized standard RGB format that supports 8 bits for each channel including alpha. ⁴
		/// </summary>
		DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,

		/// <summary>A four-component, 32-bit typeless format that supports 8 bits for each color channel, and 8 bits are unused. ⁴</summary>
		DXGI_FORMAT_B8G8R8X8_TYPELESS,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized standard RGB format that supports 8 bits for each color channel, and 8 bits are
		/// unused. ⁴
		/// </summary>
		DXGI_FORMAT_B8G8R8X8_UNORM_SRGB,

		/// <summary>
		/// A typeless block-compression format. ⁴ For information about block-compression formats, see Texture Block Compression in
		/// Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC6H_TYPELESS,

		/// <summary>
		/// A block-compression format. ⁴ For information about block-compression formats, see Texture Block Compression in Direct3D 11.⁵
		/// </summary>
		DXGI_FORMAT_BC6H_UF16,

		/// <summary>
		/// A block-compression format. ⁴ For information about block-compression formats, see Texture Block Compression in Direct3D 11.⁵
		/// </summary>
		DXGI_FORMAT_BC6H_SF16,

		/// <summary>
		/// A typeless block-compression format. ⁴ For information about block-compression formats, see Texture Block Compression in
		/// Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC7_TYPELESS,

		/// <summary>
		/// A block-compression format. ⁴ For information about block-compression formats, see Texture Block Compression in Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC7_UNORM,

		/// <summary>
		/// A block-compression format. ⁴ For information about block-compression formats, see Texture Block Compression in Direct3D 11.
		/// </summary>
		DXGI_FORMAT_BC7_UNORM_SRGB,

		/// <summary>
		/// Most common YUV 4:4:4 video resource format. Valid view formats for this video resource format are DXGI_FORMAT_R8G8B8A8_UNORM
		/// and DXGI_FORMAT_R8G8B8A8_UINT. For UAVs, an additional valid view format is DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT
		/// for UAVs, you can both read and write as opposed to just write for DXGI_FORMAT_R8G8B8A8_UNORM and DXGI_FORMAT_R8G8B8A8_UINT.
		/// Supported view types are SRV, RTV, and UAV. One view provides a straightforward mapping of the entire surface. The mapping to
		/// the view channel is V-&gt;R8, U-&gt;G8, Y-&gt;B8, and A-&gt;A8.For more info about YUV formats for video rendering, see
		/// Recommended 8-Bit YUV Formats for Video Rendering. Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_AYUV,

		/// <summary>
		/// 10-bit per channel packed YUV 4:4:4 video resource format. Valid view formats for this video resource format are
		/// DXGI_FORMAT_R10G10B10A2_UNORM and DXGI_FORMAT_R10G10B10A2_UINT. For UAVs, an additional valid view format is
		/// DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for
		/// DXGI_FORMAT_R10G10B10A2_UNORM and DXGI_FORMAT_R10G10B10A2_UINT. Supported view types are SRV and UAV. One view provides a
		/// straightforward mapping of the entire surface. The mapping to the view channel is U-&gt;R10,Y-&gt;G10,V-&gt;B10,and A-&gt;A2.For
		/// more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Direct3D 11.1: This
		/// value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_Y410,

		/// <summary>
		/// 16-bit per channel packed YUV 4:4:4 video resource format. Valid view formats for this video resource format are
		/// DXGI_FORMAT_R16G16B16A16_UNORM and DXGI_FORMAT_R16G16B16A16_UINT. Supported view types are SRV and UAV. One view provides a
		/// straightforward mapping of the entire surface. The mapping to the view channel is U-&gt;R16,Y-&gt;G16,V-&gt;B16,and
		/// A-&gt;A16.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Direct3D
		/// 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_Y416,

		/// <summary>
		/// Most common YUV 4:2:0 video resource format. Valid luminance data view formats for this video resource format are
		/// DXGI_FORMAT_R8_UNORM and DXGI_FORMAT_R8_UINT. Valid chrominance data view formats (width and height are each 1/2 of luminance
		/// view) for this video resource format are DXGI_FORMAT_R8G8_UNORM and DXGI_FORMAT_R8G8_UINT. Supported view types are SRV, RTV,
		/// and UAV. For luminance data view, the mapping to the view channel is Y-&gt;R8. For chrominance data view, the mapping to the
		/// view channel is U-&gt;R8 andV-&gt;G8.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for
		/// Video Rendering. Width and height must be even. Direct3D 11 staging resources and initData parameters for this format use
		/// (rowPitch * (height + (height / 2))) bytes. The first (SysMemPitch * height) bytes are the Y plane, the remaining (SysMemPitch *
		/// (height / 2)) bytes are the UV plane.An app using the YUY 4:2:0 formats must map the luma (Y) plane separately from the chroma
		/// (UV) planes. Developers do this by calling ID3D12Device::CreateShaderResourceView twice for the same texture and passing in
		/// 1-channel and 2-channel formats. Passing in a 1-channel format compatible with the Y plane maps only the Y plane. Passing in a
		/// 2-channel format compatible with the UV planes (together) maps only the U and V planes as a single resource view.Direct3D 11.1:
		/// This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_NV12,

		/// <summary>
		/// 10-bit per channel planar YUV 4:2:0 video resource format. Valid luminance data view formats for this video resource format are
		/// DXGI_FORMAT_R16_UNORM and DXGI_FORMAT_R16_UINT. The runtime does not enforce whether the lowest 6 bits are 0 (given that this
		/// video resource format is a 10-bit format that uses 16 bits). If required, application shader code would have to enforce this
		/// manually. From the runtime's point of view, DXGI_FORMAT_P010 is no different than DXGI_FORMAT_P016. Valid chrominance data view
		/// formats (width and height are each 1/2 of luminance view) for this video resource format are DXGI_FORMAT_R16G16_UNORM and
		/// DXGI_FORMAT_R16G16_UINT. For UAVs, an additional valid chrominance data view format is DXGI_FORMAT_R32_UINT. By using
		/// DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for DXGI_FORMAT_R16G16_UNORM and
		/// DXGI_FORMAT_R16G16_UINT. Supported view types are SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is
		/// Y-&gt;R16. For chrominance data view, the mapping to the view channel is U-&gt;R16 andV-&gt;G16.For more info about YUV formats
		/// for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Width and height must be even. Direct3D 11 staging
		/// resources and initData parameters for this format use (rowPitch * (height
		/// + (height / 2))) bytes. The first (SysMemPitch * height) bytes are the Y plane, the remaining (SysMemPitch * (height / 2)) bytes
		/// are the UV plane.An app using the YUY 4:2:0 formats must map the luma (Y) plane separately from the chroma (UV) planes.
		/// Developers do this by calling ID3D12Device::CreateShaderResourceView twice for the same texture and passing in 1-channel and
		/// 2-channel formats. Passing in a 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel
		/// format compatible with the UV planes (together) maps only the U and V planes as a single resource view.Direct3D 11.1: This value
		/// is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_P010,

		/// <summary>
		/// 16-bit per channel planar YUV 4:2:0 video resource format. Valid luminance data view formats for this video resource format are
		/// DXGI_FORMAT_R16_UNORM and DXGI_FORMAT_R16_UINT. Valid chrominance data view formats (width and height are each 1/2 of luminance
		/// view) for this video resource format are DXGI_FORMAT_R16G16_UNORM and DXGI_FORMAT_R16G16_UINT. For UAVs, an additional valid
		/// chrominance data view format is DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as
		/// opposed to just write for DXGI_FORMAT_R16G16_UNORM and DXGI_FORMAT_R16G16_UINT. Supported view types are SRV, RTV, and UAV. For
		/// luminance data view, the mapping to the view channel is Y-&gt;R16. For chrominance data view, the mapping to the view channel is
		/// U-&gt;R16 andV-&gt;G16.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video
		/// Rendering. Width and height must be even. Direct3D 11 staging resources and initData parameters for this format use (rowPitch *
		/// (height + (height / 2))) bytes. The first (SysMemPitch * height) bytes are the Y plane, the remaining (SysMemPitch * (height /
		/// 2)) bytes are the UV plane.An app using the YUY 4:2:0 formats must map the luma (Y) plane separately from the chroma (UV)
		/// planes. Developers do this by calling ID3D12Device::CreateShaderResourceView twice for the same texture and passing in 1-channel
		/// and 2-channel formats. Passing in a 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel
		/// format compatible with the UV planes (together) maps only the U and V planes as a single resource view.Direct3D 11.1: This value
		/// is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_P016,

		/// <summary>
		/// 8-bit per channel planar YUV 4:2:0 video resource format. This format is subsampled where each pixel has its own Y value, but
		/// each 2x2 pixel block shares a single U and V value. The runtime requires that the width and height of all resources that are
		/// created with this format are multiples of 2. The runtime also requires that the left, right, top, and bottom members of any RECT
		/// that are used for this format are multiples of 2. This format differs from DXGI_FORMAT_NV12 in that the layout of the data
		/// within the resource is completely opaque to applications. Applications cannot use the CPU to map the resource and then access
		/// the data within the resource. You cannot use shaders with this format. Because of this behavior, legacy hardware that supports a
		/// non-NV12 4:2:0 layout (for example, YV12, and so on) can be used. Also, new hardware that has a 4:2:0 implementation better than
		/// NV12 can be used when the application does not need the data to be in a standard layout. For more info about YUV formats for
		/// video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Width and height must be even. Direct3D 11 staging
		/// resources and initData parameters for this format use (rowPitch * (height + (height / 2))) bytes. An app using the YUY 4:2:0
		/// formats must map the luma (Y) plane separately from the chroma (UV) planes. Developers do this by calling
		/// ID3D12Device::CreateShaderResourceView twice for the same texture and passing in 1-channel and 2-channel formats. Passing in a
		/// 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel format compatible with the UV planes
		/// (together) maps only the U and V planes as a single resource view.Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_420_OPAQUE,

		/// <summary>
		/// Most common YUV 4:2:2 video resource format. Valid view formats for this video resource format are DXGI_FORMAT_R8G8B8A8_UNORM
		/// and DXGI_FORMAT_R8G8B8A8_UINT. For UAVs, an additional valid view format is DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT
		/// for UAVs, you can both read and write as opposed to just write for DXGI_FORMAT_R8G8B8A8_UNORM and DXGI_FORMAT_R8G8B8A8_UINT.
		/// Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface. The mapping to the view
		/// channel is Y0-&gt;R8, U0-&gt;G8, Y1-&gt;B8, and V0-&gt;A8.A unique valid view format for this video resource format is
		/// DXGI_FORMAT_R8G8_B8G8_UNORM. With this view format, the width of the view appears to be twice what the
		/// DXGI_FORMAT_R8G8B8A8_UNORM or DXGI_FORMAT_R8G8B8A8_UINT view would be when hardware reconstructs RGBA automatically on read and
		/// before filtering. This Direct3D hardware behavior is legacy and is likely not useful any more. With this view format, the
		/// mapping to the view channel is Y0-&gt;R8, U0-&gt;G8[0], Y1-&gt;B8, and V0-&gt;G8[1].For more info about YUV formats for video
		/// rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Width must be even.Direct3D 11.1: This value is not supported
		/// until Windows 8.
		/// </summary>
		DXGI_FORMAT_YUY2,

		/// <summary>
		/// 10-bit per channel packed YUV 4:2:2 video resource format. Valid view formats for this video resource format are
		/// DXGI_FORMAT_R16G16B16A16_UNORM and DXGI_FORMAT_R16G16B16A16_UINT. The runtime does not enforce whether the lowest 6 bits are 0
		/// (given that this video resource format is a 10-bit format that uses 16 bits). If required, application shader code would have to
		/// enforce this manually. From the runtime's point of view, DXGI_FORMAT_Y210 is no different than DXGI_FORMAT_Y216. Supported view
		/// types are SRV and UAV. One view provides a straightforward mapping of the entire surface. The mapping to the view channel is
		/// Y0-&gt;R16,U-&gt;G16,Y1-&gt;B16,and V-&gt;A16.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV
		/// Formats for Video Rendering. Width must be even.Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_Y210,

		/// <summary>
		/// 16-bit per channel packed YUV 4:2:2 video resource format. Valid view formats for this video resource format are
		/// DXGI_FORMAT_R16G16B16A16_UNORM and DXGI_FORMAT_R16G16B16A16_UINT. Supported view types are SRV and UAV. One view provides a
		/// straightforward mapping of the entire surface. The mapping to the view channel is Y0-&gt;R16,U-&gt;G16,Y1-&gt;B16,and
		/// V-&gt;A16.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Width must
		/// be even.Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_Y216,

		/// <summary>
		/// Most common planar YUV 4:1:1 video resource format. Valid luminance data view formats for this video resource format are
		/// DXGI_FORMAT_R8_UNORM and DXGI_FORMAT_R8_UINT. Valid chrominance data view formats (width and height are each 1/4 of luminance
		/// view) for this video resource format are DXGI_FORMAT_R8G8_UNORM and DXGI_FORMAT_R8G8_UINT. Supported view types are SRV, RTV,
		/// and UAV. For luminance data view, the mapping to the view channel is Y-&gt;R8. For chrominance data view, the mapping to the
		/// view channel is U-&gt;R8 andV-&gt;G8.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for
		/// Video Rendering. Width must be a multiple of 4. Direct3D11 staging resources and initData parameters for this format use
		/// (rowPitch * height * 2) bytes. The first (SysMemPitch * height) bytes are the Y plane, the next ((SysMemPitch / 2) * height)
		/// bytes are the UV plane, and the remainder is padding. Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_NV11,

		/// <summary>
		/// 4-bit palletized YUV format that is commonly used for DVD subpicture.For more info about YUV formats for video rendering, see
		/// Recommended 8-Bit YUV Formats for Video Rendering. Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_AI44,

		/// <summary>
		/// 4-bit palletized YUV format that is commonly used for DVD subpicture.For more info about YUV formats for video rendering, see
		/// Recommended 8-Bit YUV Formats for Video Rendering. Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_IA44,

		/// <summary>
		/// 8-bit palletized format that is used for palletized RGB data when the processor processes ISDB-T data and for palletized YUV
		/// data when the processor processes BluRay data.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV
		/// Formats for Video Rendering. Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_P8,

		/// <summary>
		/// 8-bit palletized format with 8 bits of alpha that is used for palletized YUV data when the processor processes BluRay data.For
		/// more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Direct3D 11.1: This
		/// value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_A8P8,

		/// <summary>
		/// A four-component, 16-bit unsigned-normalized integer format that supports 4 bits for each channel including alpha.Direct3D 11.1:
		/// This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_B4G4R4A4_UNORM,

		/// <summary>A video format; an 8-bit version of a hybrid planar 4:2:2 format.</summary>
		DXGI_FORMAT_P208 = 130,

		/// <summary>An 8 bit YCbCrA 4:4 rendering format.</summary>
		DXGI_FORMAT_V208,

		/// <summary>An 8 bit YCbCrA 4:4:4:4 rendering format.</summary>
		DXGI_FORMAT_V408,

		/// <summary/>
		DXGI_FORMAT_SAMPLER_FEEDBACK_MIN_MIP_OPAQUE = 189,

		/// <summary/>
		DXGI_FORMAT_SAMPLER_FEEDBACK_MIP_REGION_USED_OPAQUE,

		/// <summary/>
		DXGI_FORMAT_A4B4G4R4_UNORM,
	}
}