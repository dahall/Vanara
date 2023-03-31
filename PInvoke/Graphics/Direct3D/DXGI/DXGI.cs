using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

// TODO: Move once DXGI lib is done
/// <summary>Items from the DXGI.dll</summary>
public static partial class DXGI
{
	/// <summary>Identifies the type of DXGI adapter.</summary>
	/// <remarks>
	/// The <c>DXGI_ADAPTER_FLAG</c> enumerated type is used by the <c>Flags</c> member of the DXGI_ADAPTER_DESC1 or DXGI_ADAPTER_DESC2
	/// structure to identify the type of DXGI adapter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_adapter_flag typedef enum DXGI_ADAPTER_FLAG {
	// DXGI_ADAPTER_FLAG_NONE, DXGI_ADAPTER_FLAG_REMOTE, DXGI_ADAPTER_FLAG_SOFTWARE, DXGI_ADAPTER_FLAG_FORCE_DWORD } ;
	[PInvokeData("dxgi.h", MSDNShortId = "9c3c78cd-4f4e-4753-969a-54ea63583be1")]
	public enum DXGI_ADAPTER_FLAG : uint
	{
		/// <summary>Specifies no flags.</summary>
		DXGI_ADAPTER_FLAG_NONE = 0,

		/// <summary>Value always set to 0. This flag is reserved.</summary>
		DXGI_ADAPTER_FLAG_REMOTE = 1,

		/// <summary>
		/// Specifies a software adapter. For more info about this flag, see new info in Windows 8 about enumerating adapters.Direct3D
		/// 11: This enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_ADAPTER_FLAG_SOFTWARE = 2,

		/// <summary>
		/// Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this enumeration to
		/// compile to a size other than 32 bits. This value is not used.
		/// </summary>
		DXGI_ADAPTER_FLAG_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Flags for <see cref="CreateDXGIFactory2(DXGI_CREATE_FACTORY, in Guid, out object)"/></summary>
	[PInvokeData("dxgi1_3.h", MSDNShortId = "D3CF43B0-8F17-486E-8750-CF0B9052BE74")]
	[Flags]
	public enum DXGI_CREATE_FACTORY
	{
		/// <summary>The system creates an implicit factory during device creation.</summary>
		DXGI_CREATE_FACTORY_DEBUG = 1,
	}

	/// <summary>
	/// <para>Options for enumerating display modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DXGI_ENUM_MODES_INTERLACED 1UL</term>
	/// <term>Include interlaced modes.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_ENUM_MODES_SCALING 2UL</term>
	/// <term>Include stretched-scaling modes.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_ENUM_MODES_STEREO 4UL</term>
	/// <term>Include stereo modes. Direct3D 11: This enumeration value is supported starting with Windows 8.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_ENUM_MODES_DISABLED_STEREO 8UL</term>
	/// <term>
	/// Include stereo modes that are hidden because the user has disabled stereo. Control panel applications can use this option to
	/// show stereo capabilities that have been disabled as part of a user interface that enables and disables stereo. Direct3D 11: This
	/// enumeration value is supported starting with Windows 8.
	/// </term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>These flag options are used in <c>IDXGIOutput::GetDisplayModeList</c> to enumerate display modes.</para>
	/// <para>These flag options are also used in <c>IDXGIOutput1::GetDisplayModeList1</c> to enumerate display modes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-enum-modes
	[PInvokeData("dxgi.h", MSDNShortId = "7e0f5629-f8e2-478b-b8eb-00780a3dcf1f")]
	[Flags]
	public enum DXGI_ENUM_MODES : uint
	{
		/// <summary>Include interlaced modes.</summary>
		DXGI_ENUM_MODES_INTERLACED = 1,

		/// <summary>Include stretched-scaling modes.</summary>
		DXGI_ENUM_MODES_SCALING = 2,

		/// <summary>
		/// Include stereo modes.
		/// <para>Direct3D 11: This enumeration value is supported starting with Windows 8.</para>
		/// </summary>
		DXGI_ENUM_MODES_STEREO = 4,

		/// <summary>
		/// Include stereo modes that are hidden because the user has disabled stereo. Control panel applications can use this option to
		/// show stereo capabilities that have been disabled as part of a user interface that enables and disables stereo.
		/// <para>Direct3D 11: This enumeration value is supported starting with Windows 8.</para>
		/// </summary>
		DXGI_ENUM_MODES_DISABLED_STEREO = 8,
	}

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
	/// A resource declared with the DXGI_FORMAT_R32G32B32 family of formats cannot be used simultaneously for vertex and texture data.
	/// That is, you may not create a buffer resource with the DXGI_FORMAT_R32G32B32 family of formats that uses any of the following
	/// bind flags: D3D10_BIND_VERTEX_BUFFER, D3D10_BIND_INDEX_BUFFER, D3D10_BIND_CONSTANT_BUFFER, or D3D10_BIND_STREAM_OUTPUT (see D3D10_BIND_FLAG).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// DXGI_FORMAT_R1_UNORM is designed specifically for text filtering, and must be used with a format-specific, configurable 8x8
	/// filter mode. When calling an HLSL sampling function using this format, the address offset parameter must be set to (0,0).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// A resource using a sub-sampled format (such as DXGI_FORMAT_R8G8_B8G8) must have a size that is a multiple of 2 in the x dimension.
	/// </term>
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
	/// normalized floating-point value in the range [-1, 1]. For an 2's complement number, the maximum value is 1.0f (a 5-bit value
	/// 01111 maps to 1.0f), and the minimum value is -1.0f (a 5-bit value 10000 maps to -1.0f). In addition, the second-minimum number
	/// maps to -1.0f (a 5-bit value 10001 maps to -1.0f). The resulting integer representations are evenly spaced floating-point values
	/// in the range (-1.0f...0.0f), and also a complementary set of representations for numbers in the range (0.0f...1.0f).
	/// </term>
	/// </item>
	/// <item>
	/// <term>_SRGB</term>
	/// <term>
	/// Standard RGB data, which roughly displays colors in a linear ramp of luminosity levels such that an average observer, under
	/// average viewing conditions, can view them on an average display. All 0's maps to 0.0f, and all 1's maps to 1.0f. The sequence of
	/// unsigned integer encodings between all 0's and all 1's represent a nonlinear progression in the floating-point interpretation of
	/// the numbers between 0.0f to 1.0f. For more detail, see the SRGB color standard, IEC 61996-2-1, at IEC (International
	/// Electrotechnical Commission).Conversion to or from sRGB space is automatically done by D3DX10 or D3DX9 texture-load functions.
	/// If a format with _SRGB has an A channel, the A channel is stored in Gamma 1.0f data; the R, G, and B channels in the format are
	/// stored in Gamma 2.2f data.
	/// </term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>_TYPELESS</term>
	/// <term>
	/// Typeless data, with a defined number of bits. Typeless formats are designed for creating typeless resources; that is, a resource
	/// whose size is known, but whose data type is not yet fully defined. When a typeless resource is bound to a shader, the
	/// application or shader must resolve the format type (which must match the number of bits per component in the typeless format). A
	/// typeless format contains one or more subformats; each subformat resolves the data type. For example, in the R32G32B32 group,
	/// which defines types for three-component 96-bit data, there is one typeless format and three fully typed subformats.
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
	/// unsigned normalized floating-point value in the range [0, 1]. All 0's maps to 0.0f, and all 1's maps to 1.0f. A sequence of
	/// evenly spaced floating-point values from 0.0f to 1.0f are represented. For instance, a 2-bit UNORM represents 0.0f, 1/3, 2/3,
	/// and 1.0f.
	/// </term>
	/// </item>
	/// <item>
	/// <term>_SHAREDEXP</term>
	/// <term>A shared exponent. All the floating point representations in the format share the one exponent.</term>
	/// </item>
	/// </list>
	/// <para>New Resource Formats</para>
	/// <para>
	/// Direct3D 10 offers new data compression formats for compressing high-dynamic range (HDR) lighting data, normal maps and
	/// heightfields to a fraction of their original size. These compression types include:
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
	/// TextureCube) including mipmap surfaces. The block compression techniques require texture dimensions to be a multiple of 4 (since
	/// the implementation compresses on blocks of 4x4 texels). In the texture sampler, compressed formats are always decompressed
	/// before texture filtering.
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
	// DXGI_FORMAT_R16_SINT, DXGI_FORMAT_R8_TYPELESS, DXGI_FORMAT_R8_UNORM, DXGI_FORMAT_R8_UINT, DXGI_FORMAT_R8_SNORM,
	// DXGI_FORMAT_R8_SINT, DXGI_FORMAT_A8_UNORM, DXGI_FORMAT_R1_UNORM, DXGI_FORMAT_R9G9B9E5_SHAREDEXP, DXGI_FORMAT_R8G8_B8G8_UNORM,
	// DXGI_FORMAT_G8R8_G8B8_UNORM, DXGI_FORMAT_BC1_TYPELESS, DXGI_FORMAT_BC1_UNORM, DXGI_FORMAT_BC1_UNORM_SRGB,
	// DXGI_FORMAT_BC2_TYPELESS, DXGI_FORMAT_BC2_UNORM, DXGI_FORMAT_BC2_UNORM_SRGB, DXGI_FORMAT_BC3_TYPELESS, DXGI_FORMAT_BC3_UNORM,
	// DXGI_FORMAT_BC3_UNORM_SRGB, DXGI_FORMAT_BC4_TYPELESS, DXGI_FORMAT_BC4_UNORM, DXGI_FORMAT_BC4_SNORM, DXGI_FORMAT_BC5_TYPELESS,
	// DXGI_FORMAT_BC5_UNORM, DXGI_FORMAT_BC5_SNORM, DXGI_FORMAT_B5G6R5_UNORM, DXGI_FORMAT_B5G5R5A1_UNORM, DXGI_FORMAT_B8G8R8A8_UNORM,
	// DXGI_FORMAT_B8G8R8X8_UNORM, DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM, DXGI_FORMAT_B8G8R8A8_TYPELESS,
	// DXGI_FORMAT_B8G8R8A8_UNORM_SRGB, DXGI_FORMAT_B8G8R8X8_TYPELESS, DXGI_FORMAT_B8G8R8X8_UNORM_SRGB, DXGI_FORMAT_BC6H_TYPELESS,
	// DXGI_FORMAT_BC6H_UF16, DXGI_FORMAT_BC6H_SF16, DXGI_FORMAT_BC7_TYPELESS, DXGI_FORMAT_BC7_UNORM, DXGI_FORMAT_BC7_UNORM_SRGB,
	// DXGI_FORMAT_AYUV, DXGI_FORMAT_Y410, DXGI_FORMAT_Y416, DXGI_FORMAT_NV12, DXGI_FORMAT_P010, DXGI_FORMAT_P016,
	// DXGI_FORMAT_420_OPAQUE, DXGI_FORMAT_YUY2, DXGI_FORMAT_Y210, DXGI_FORMAT_Y216, DXGI_FORMAT_NV11, DXGI_FORMAT_AI44,
	// DXGI_FORMAT_IA44, DXGI_FORMAT_P8, DXGI_FORMAT_A8P8, DXGI_FORMAT_B4G4R4A4_UNORM, DXGI_FORMAT_P208, DXGI_FORMAT_V208,
	// DXGI_FORMAT_V408, DXGI_FORMAT_SAMPLER_FEEDBACK_MIN_MIP_OPAQUE, DXGI_FORMAT_SAMPLER_FEEDBACK_MIP_REGION_USED_OPAQUE,
	// DXGI_FORMAT_FORCE_UINT } ;
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

		/// <summary>
		/// A two-component, 64-bit typeless format that supports 32 bits for the red channel and 32 bits for the green channel.
		/// </summary>
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
		/// A two-component, 64-bit typeless format that supports 32 bits for the red channel, 8 bits for the green channel, and 24 bits
		/// are unused.
		/// </summary>
		DXGI_FORMAT_R32G8X24_TYPELESS,

		/// <summary>
		/// A 32-bit floating-point component, and two unsigned-integer components (with an additional 32 bits). This format supports
		/// 32-bit depth, 8-bit stencil, and 24 bits are unused.⁵
		/// </summary>
		DXGI_FORMAT_D32_FLOAT_S8X24_UINT,

		/// <summary>
		/// A 32-bit floating-point component, and two typeless components (with an additional 32 bits). This format supports 32-bit red
		/// channel, 8 bits are unused, and 24 bits are unused.⁵
		/// </summary>
		DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS,

		/// <summary>
		/// A 32-bit typeless component, and two unsigned-integer components (with an additional 32 bits). This format has 32 bits
		/// unused, 8 bits for green channel, and 24 bits are unused.
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
		/// Three partial-precision floating-point numbers encoded into a single 32-bit value (a variant of s10e5, which is sign bit,
		/// 10-bit mantissa, and 5-bit biased (15) exponent). There are no sign bits, and there is a 5-bit biased (15) exponent for each
		/// channel, 6-bit mantissa for R and G, and a 5-bit mantissa for B, as shown in the following illustration.
		/// </summary>
		DXGI_FORMAT_R11G11B10_FLOAT,

		/// <summary>A four-component, 32-bit typeless format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_TYPELESS,

		/// <summary>A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_UNORM,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized integer sRGB format that supports 8 bits per channel including alpha.
		/// </summary>
		DXGI_FORMAT_R8G8B8A8_UNORM_SRGB,

		/// <summary>A four-component, 32-bit unsigned-integer format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_UINT,

		/// <summary>A four-component, 32-bit signed-normalized-integer format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_SNORM,

		/// <summary>A four-component, 32-bit signed-integer format that supports 8 bits per channel including alpha.</summary>
		DXGI_FORMAT_R8G8B8A8_SINT,

		/// <summary>
		/// A two-component, 32-bit typeless format that supports 16 bits for the red channel and 16 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R16G16_TYPELESS,

		/// <summary>
		/// A two-component, 32-bit floating-point format that supports 16 bits for the red channel and 16 bits for the green channel.
		/// </summary>
		DXGI_FORMAT_R16G16_FLOAT,

		/// <summary>
		/// A two-component, 32-bit unsigned-normalized-integer format that supports 16 bits each for the green and red channels.
		/// </summary>
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
		/// A 32-bit format, that contains a 24 bit, single-component, unsigned-normalized integer, with an additional typeless 8 bits.
		/// This format has 24 bits red channel and 8 bits unused.
		/// </summary>
		DXGI_FORMAT_R24_UNORM_X8_TYPELESS,

		/// <summary>
		/// A 32-bit format, that contains a 24 bit, single-component, typeless format, with an additional 8 bit unsigned integer
		/// component. This format has 24 bits unused and 8 bits green channel.
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
		/// Three partial-precision floating-point numbers encoded into a single 32-bit value all sharing the same 5-bit exponent
		/// (variant of s10e5, which is sign bit, 10-bit mantissa, and 5-bit biased (15) exponent). There is no sign bit, and there is a
		/// shared 5-bit biased (15) exponent and a 9-bit mantissa for each channel, as shown in the following illustration. .
		/// </summary>
		DXGI_FORMAT_R9G9B9E5_SHAREDEXP,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized-integer format. This packed RGB format is analogous to the UYVY format. Each
		/// 32-bit block describes a pair of pixels: (R8, G8, B8) and (R8, G8, B8) where the R8/B8 values are repeated, and the G8
		/// values are unique to each pixel. ³Width must be even.
		/// </summary>
		DXGI_FORMAT_R8G8_B8G8_UNORM,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized-integer format. This packed RGB format is analogous to the YUY2 format. Each
		/// 32-bit block describes a pair of pixels: (R8, G8, B8) and (R8, G8, B8) where the R8/B8 values are repeated, and the G8
		/// values are unique to each pixel. ³Width must be even.
		/// </summary>
		DXGI_FORMAT_G8R8_G8B8_UNORM,

		/// <summary>
		/// Four-component typeless block-compression format. For information about block-compression formats, see Texture Block
		/// Compression in Direct3D 11.
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
		/// Four-component typeless block-compression format. For information about block-compression formats, see Texture Block
		/// Compression in Direct3D 11.
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
		/// Four-component typeless block-compression format. For information about block-compression formats, see Texture Block
		/// Compression in Direct3D 11.
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
		/// One-component typeless block-compression format. For information about block-compression formats, see Texture Block
		/// Compression in Direct3D 11.
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
		/// Two-component typeless block-compression format. For information about block-compression formats, see Texture Block
		/// Compression in Direct3D 11.
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
		/// red.Direct3D 10 through Direct3D 11: This value is defined for DXGI. However, Direct3D 10, 10.1, or 11 devices do not
		/// support this format.Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_B5G6R5_UNORM,

		/// <summary>
		/// A four-component, 16-bit unsigned-normalized-integer format that supports 5 bits for each color channel and 1-bit
		/// alpha.Direct3D 10 through Direct3D 11: This value is defined for DXGI. However, Direct3D 10, 10.1, or 11 devices do not
		/// support this format.Direct3D 11.1: This value is not supported until Windows 8.
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

		/// <summary>
		/// A four-component, 32-bit 2.8-biased fixed-point format that supports 10 bits for each color channel and 2-bit alpha.
		/// </summary>
		DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM,

		/// <summary>A four-component, 32-bit typeless format that supports 8 bits for each channel including alpha. ⁴</summary>
		DXGI_FORMAT_B8G8R8A8_TYPELESS,

		/// <summary>
		/// A four-component, 32-bit unsigned-normalized standard RGB format that supports 8 bits for each channel including alpha. ⁴
		/// </summary>
		DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,

		/// <summary>
		/// A four-component, 32-bit typeless format that supports 8 bits for each color channel, and 8 bits are unused. ⁴
		/// </summary>
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
		/// Most common YUV 4:4:4 video resource format. Valid view formats for this video resource format are
		/// DXGI_FORMAT_R8G8B8A8_UNORM and DXGI_FORMAT_R8G8B8A8_UINT. For UAVs, an additional valid view format is DXGI_FORMAT_R32_UINT.
		/// By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for DXGI_FORMAT_R8G8B8A8_UNORM
		/// and DXGI_FORMAT_R8G8B8A8_UINT. Supported view types are SRV, RTV, and UAV. One view provides a straightforward mapping of
		/// the entire surface. The mapping to the view channel is V-&gt;R8, U-&gt;G8, Y-&gt;B8, and A-&gt;A8.For more info about YUV
		/// formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Direct3D 11.1: This value is not
		/// supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_AYUV,

		/// <summary>
		/// 10-bit per channel packed YUV 4:4:4 video resource format. Valid view formats for this video resource format are
		/// DXGI_FORMAT_R10G10B10A2_UNORM and DXGI_FORMAT_R10G10B10A2_UINT. For UAVs, an additional valid view format is
		/// DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for
		/// DXGI_FORMAT_R10G10B10A2_UNORM and DXGI_FORMAT_R10G10B10A2_UINT. Supported view types are SRV and UAV. One view provides a
		/// straightforward mapping of the entire surface. The mapping to the view channel is U-&gt;R10,Y-&gt;G10,V-&gt;B10,and
		/// A-&gt;A2.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
		/// Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_Y410,

		/// <summary>
		/// 16-bit per channel packed YUV 4:4:4 video resource format. Valid view formats for this video resource format are
		/// DXGI_FORMAT_R16G16B16A16_UNORM and DXGI_FORMAT_R16G16B16A16_UINT. Supported view types are SRV and UAV. One view provides a
		/// straightforward mapping of the entire surface. The mapping to the view channel is U-&gt;R16,Y-&gt;G16,V-&gt;B16,and
		/// A-&gt;A16.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
		/// Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_Y416,

		/// <summary>
		/// Most common YUV 4:2:0 video resource format. Valid luminance data view formats for this video resource format are
		/// DXGI_FORMAT_R8_UNORM and DXGI_FORMAT_R8_UINT. Valid chrominance data view formats (width and height are each 1/2 of
		/// luminance view) for this video resource format are DXGI_FORMAT_R8G8_UNORM and DXGI_FORMAT_R8G8_UINT. Supported view types
		/// are SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is Y-&gt;R8. For chrominance data view, the
		/// mapping to the view channel is U-&gt;R8 andV-&gt;G8.For more info about YUV formats for video rendering, see Recommended
		/// 8-Bit YUV Formats for Video Rendering. Width and height must be even. Direct3D 11 staging resources and initData parameters
		/// for this format use (rowPitch * (height + (height / 2))) bytes. The first (SysMemPitch * height) bytes are the Y plane, the
		/// remaining (SysMemPitch * (height / 2)) bytes are the UV plane.An app using the YUY 4:2:0 formats must map the luma (Y) plane
		/// separately from the chroma (UV) planes. Developers do this by calling ID3D12Device::CreateShaderResourceView twice for the
		/// same texture and passing in 1-channel and 2-channel formats. Passing in a 1-channel format compatible with the Y plane maps
		/// only the Y plane. Passing in a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a
		/// single resource view.Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_NV12,

		/// <summary>
		/// 10-bit per channel planar YUV 4:2:0 video resource format. Valid luminance data view formats for this video resource format
		/// are DXGI_FORMAT_R16_UNORM and DXGI_FORMAT_R16_UINT. The runtime does not enforce whether the lowest 6 bits are 0 (given that
		/// this video resource format is a 10-bit format that uses 16 bits). If required, application shader code would have to enforce
		/// this manually. From the runtime's point of view, DXGI_FORMAT_P010 is no different than DXGI_FORMAT_P016. Valid chrominance
		/// data view formats (width and height are each 1/2 of luminance view) for this video resource format are
		/// DXGI_FORMAT_R16G16_UNORM and DXGI_FORMAT_R16G16_UINT. For UAVs, an additional valid chrominance data view format is
		/// DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for
		/// DXGI_FORMAT_R16G16_UNORM and DXGI_FORMAT_R16G16_UINT. Supported view types are SRV, RTV, and UAV. For luminance data view,
		/// the mapping to the view channel is Y-&gt;R16. For chrominance data view, the mapping to the view channel is U-&gt;R16
		/// andV-&gt;G16.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
		/// Width and height must be even. Direct3D 11 staging resources and initData parameters for this format use (rowPitch * (height
		/// + (height / 2))) bytes. The first (SysMemPitch * height) bytes are the Y plane, the remaining (SysMemPitch * (height / 2))
		/// bytes are the UV plane.An app using the YUY 4:2:0 formats must map the luma (Y) plane separately from the chroma (UV)
		/// planes. Developers do this by calling ID3D12Device::CreateShaderResourceView twice for the same texture and passing in
		/// 1-channel and 2-channel formats. Passing in a 1-channel format compatible with the Y plane maps only the Y plane. Passing in
		/// a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a single resource view.Direct3D
		/// 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_P010,

		/// <summary>
		/// 16-bit per channel planar YUV 4:2:0 video resource format. Valid luminance data view formats for this video resource format
		/// are DXGI_FORMAT_R16_UNORM and DXGI_FORMAT_R16_UINT. Valid chrominance data view formats (width and height are each 1/2 of
		/// luminance view) for this video resource format are DXGI_FORMAT_R16G16_UNORM and DXGI_FORMAT_R16G16_UINT. For UAVs, an
		/// additional valid chrominance data view format is DXGI_FORMAT_R32_UINT. By using DXGI_FORMAT_R32_UINT for UAVs, you can both
		/// read and write as opposed to just write for DXGI_FORMAT_R16G16_UNORM and DXGI_FORMAT_R16G16_UINT. Supported view types are
		/// SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is Y-&gt;R16. For chrominance data view, the
		/// mapping to the view channel is U-&gt;R16 andV-&gt;G16.For more info about YUV formats for video rendering, see Recommended
		/// 8-Bit YUV Formats for Video Rendering. Width and height must be even. Direct3D 11 staging resources and initData parameters
		/// for this format use (rowPitch * (height + (height / 2))) bytes. The first (SysMemPitch * height) bytes are the Y plane, the
		/// remaining (SysMemPitch * (height / 2)) bytes are the UV plane.An app using the YUY 4:2:0 formats must map the luma (Y) plane
		/// separately from the chroma (UV) planes. Developers do this by calling ID3D12Device::CreateShaderResourceView twice for the
		/// same texture and passing in 1-channel and 2-channel formats. Passing in a 1-channel format compatible with the Y plane maps
		/// only the Y plane. Passing in a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a
		/// single resource view.Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_P016,

		/// <summary>
		/// 8-bit per channel planar YUV 4:2:0 video resource format. This format is subsampled where each pixel has its own Y value,
		/// but each 2x2 pixel block shares a single U and V value. The runtime requires that the width and height of all resources that
		/// are created with this format are multiples of 2. The runtime also requires that the left, right, top, and bottom members of
		/// any RECT that are used for this format are multiples of 2. This format differs from DXGI_FORMAT_NV12 in that the layout of
		/// the data within the resource is completely opaque to applications. Applications cannot use the CPU to map the resource and
		/// then access the data within the resource. You cannot use shaders with this format. Because of this behavior, legacy hardware
		/// that supports a non-NV12 4:2:0 layout (for example, YV12, and so on) can be used. Also, new hardware that has a 4:2:0
		/// implementation better than NV12 can be used when the application does not need the data to be in a standard layout. For more
		/// info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Width and height must be
		/// even. Direct3D 11 staging resources and initData parameters for this format use (rowPitch * (height + (height / 2))) bytes.
		/// An app using the YUY 4:2:0 formats must map the luma (Y) plane separately from the chroma (UV) planes. Developers do this by
		/// calling ID3D12Device::CreateShaderResourceView twice for the same texture and passing in 1-channel and 2-channel formats.
		/// Passing in a 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel format compatible
		/// with the UV planes (together) maps only the U and V planes as a single resource view.Direct3D 11.1: This value is not
		/// supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_420_OPAQUE,

		/// <summary>
		/// Most common YUV 4:2:2 video resource format. Valid view formats for this video resource format are
		/// DXGI_FORMAT_R8G8B8A8_UNORM and DXGI_FORMAT_R8G8B8A8_UINT. For UAVs, an additional valid view format is DXGI_FORMAT_R32_UINT.
		/// By using DXGI_FORMAT_R32_UINT for UAVs, you can both read and write as opposed to just write for DXGI_FORMAT_R8G8B8A8_UNORM
		/// and DXGI_FORMAT_R8G8B8A8_UINT. Supported view types are SRV and UAV. One view provides a straightforward mapping of the
		/// entire surface. The mapping to the view channel is Y0-&gt;R8, U0-&gt;G8, Y1-&gt;B8, and V0-&gt;A8.A unique valid view format
		/// for this video resource format is DXGI_FORMAT_R8G8_B8G8_UNORM. With this view format, the width of the view appears to be
		/// twice what the DXGI_FORMAT_R8G8B8A8_UNORM or DXGI_FORMAT_R8G8B8A8_UINT view would be when hardware reconstructs RGBA
		/// automatically on read and before filtering. This Direct3D hardware behavior is legacy and is likely not useful any more.
		/// With this view format, the mapping to the view channel is Y0-&gt;R8, U0-&gt;G8[0], Y1-&gt;B8, and V0-&gt;G8[1].For more info
		/// about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Width must be even.Direct3D
		/// 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_YUY2,

		/// <summary>
		/// 10-bit per channel packed YUV 4:2:2 video resource format. Valid view formats for this video resource format are
		/// DXGI_FORMAT_R16G16B16A16_UNORM and DXGI_FORMAT_R16G16B16A16_UINT. The runtime does not enforce whether the lowest 6 bits are
		/// 0 (given that this video resource format is a 10-bit format that uses 16 bits). If required, application shader code would
		/// have to enforce this manually. From the runtime's point of view, DXGI_FORMAT_Y210 is no different than DXGI_FORMAT_Y216.
		/// Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface. The mapping to the
		/// view channel is Y0-&gt;R16,U-&gt;G16,Y1-&gt;B16,and V-&gt;A16.For more info about YUV formats for video rendering, see
		/// Recommended 8-Bit YUV Formats for Video Rendering. Width must be even.Direct3D 11.1: This value is not supported until
		/// Windows 8.
		/// </summary>
		DXGI_FORMAT_Y210,

		/// <summary>
		/// 16-bit per channel packed YUV 4:2:2 video resource format. Valid view formats for this video resource format are
		/// DXGI_FORMAT_R16G16B16A16_UNORM and DXGI_FORMAT_R16G16B16A16_UINT. Supported view types are SRV and UAV. One view provides a
		/// straightforward mapping of the entire surface. The mapping to the view channel is Y0-&gt;R16,U-&gt;G16,Y1-&gt;B16,and
		/// V-&gt;A16.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Width
		/// must be even.Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_Y216,

		/// <summary>
		/// Most common planar YUV 4:1:1 video resource format. Valid luminance data view formats for this video resource format are
		/// DXGI_FORMAT_R8_UNORM and DXGI_FORMAT_R8_UINT. Valid chrominance data view formats (width and height are each 1/4 of
		/// luminance view) for this video resource format are DXGI_FORMAT_R8G8_UNORM and DXGI_FORMAT_R8G8_UINT. Supported view types
		/// are SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is Y-&gt;R8. For chrominance data view, the
		/// mapping to the view channel is U-&gt;R8 andV-&gt;G8.For more info about YUV formats for video rendering, see Recommended
		/// 8-Bit YUV Formats for Video Rendering. Width must be a multiple of 4. Direct3D11 staging resources and initData parameters
		/// for this format use (rowPitch * height * 2) bytes. The first (SysMemPitch * height) bytes are the Y plane, the next
		/// ((SysMemPitch / 2) * height) bytes are the UV plane, and the remainder is padding. Direct3D 11.1: This value is not
		/// supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_NV11,

		/// <summary>
		/// 4-bit palletized YUV format that is commonly used for DVD subpicture.For more info about YUV formats for video rendering,
		/// see Recommended 8-Bit YUV Formats for Video Rendering. Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_AI44,

		/// <summary>
		/// 4-bit palletized YUV format that is commonly used for DVD subpicture.For more info about YUV formats for video rendering,
		/// see Recommended 8-Bit YUV Formats for Video Rendering. Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_IA44,

		/// <summary>
		/// 8-bit palletized format that is used for palletized RGB data when the processor processes ISDB-T data and for palletized YUV
		/// data when the processor processes BluRay data.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV
		/// Formats for Video Rendering. Direct3D 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_P8,

		/// <summary>
		/// 8-bit palletized format with 8 bits of alpha that is used for palletized YUV data when the processor processes BluRay
		/// data.For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering. Direct3D
		/// 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_A8P8,

		/// <summary>
		/// A four-component, 16-bit unsigned-normalized integer format that supports 4 bits for each channel including alpha.Direct3D
		/// 11.1: This value is not supported until Windows 8.
		/// </summary>
		DXGI_FORMAT_B4G4R4A4_UNORM,

		/// <summary>A video format; an 8-bit version of a hybrid planar 4:2:2 format.</summary>
		DXGI_FORMAT_P208 = 130,

		/// <summary>An 8 bit YCbCrA 4:4 rendering format.</summary>
		DXGI_FORMAT_V208,

		/// <summary>An 8 bit YCbCrA 4:4:4:4 rendering format.</summary>
		DXGI_FORMAT_V408,

		/// <summary>
		/// Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this enumeration to
		/// compile to a size other than 32 bits. This value is not used.
		/// </summary>
		DXGI_FORMAT_FORCE_UINT = 0xffffffff,
	}

	/// <summary>CPU read-write flags.</summary>
	[PInvokeData("dxgi.h")]
	[Flags]
	public enum DXGI_MAP : uint
	{
		/// <summary>Allow CPU read access.</summary>
		DXGI_MAP_READ = 0x1,

		/// <summary>Allow CPU write access.</summary>
		DXGI_MAP_WRITE = 0x2,

		/// <summary>Discard the previous contents of a resource when it is mapped.</summary>
		DXGI_MAP_DISCARD = 0x4
	}

	/// <summary>Flags that indicate how the back buffers should be rotated to fit the physical rotation of a monitor.</summary>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173065(v=vs.85) typedef enum DXGI_MODE_ROTATION {
	// DXGI_MODE_ROTATION_UNSPECIFIED = 0, DXGI_MODE_ROTATION_IDENTITY = 1, DXGI_MODE_ROTATION_ROTATE90 = 2,
	// DXGI_MODE_ROTATION_ROTATE180 = 3, DXGI_MODE_ROTATION_ROTATE270 = 4 } DXGI_MODE_ROTATION;
	[PInvokeData("DXGI.h")]
	public enum DXGI_MODE_ROTATION
	{
		/// <summary>Unspecified rotation.</summary>
		DXGI_MODE_ROTATION_UNSPECIFIED = 0,

		/// <summary>Specifies no rotation.</summary>
		DXGI_MODE_ROTATION_IDENTITY,

		/// <summary>Specifies 90 degrees of rotation.</summary>
		DXGI_MODE_ROTATION_ROTATE90,

		/// <summary>Specifies 180 degrees of rotation.</summary>
		DXGI_MODE_ROTATION_ROTATE180,

		/// <summary>Specifies 270 degrees of rotation.</summary>
		DXGI_MODE_ROTATION_ROTATE270,
	}

	/// <summary>Flags indicating how an image is stretched to fit a given monitor's resolution.</summary>
	/// <remarks>
	/// <para>
	/// Selecting the CENTERED or STRETCHED modes can result in a mode change even if you specify the native resolution of the display
	/// in the DXGI_MODE_DESC. If you know the native resolution of the display and want to make sure that you do not initiate a mode
	/// change when transitioning a swap chain to full screen (either via ALT+ENTER or <c>IDXGISwapChain::SetFullscreenState</c>), you
	/// should use UNSPECIFIED.
	/// </para>
	/// <para>This enum is used by the <c>DXGI_MODE_DESC1</c> and <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structures.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173066(v=vs.85) typedef enum DXGI_MODE_SCALING {
	// DXGI_MODE_SCALING_UNSPECIFIED = 0, DXGI_MODE_SCALING_CENTERED = 1, DXGI_MODE_SCALING_STRETCHED = 2 } DXGI_MODE_SCALING;
	[PInvokeData("DXGI.h")]
	public enum DXGI_MODE_SCALING
	{
		/// <summary>Unspecified scaling.</summary>
		DXGI_MODE_SCALING_UNSPECIFIED = 0,

		/// <summary>
		/// Specifies no scaling. The image is centered on the display. This flag is typically used for a fixed-dot-pitch display (such
		/// as an LED display).
		/// </summary>
		DXGI_MODE_SCALING_CENTERED,

		/// <summary>Specifies stretched scaling.</summary>
		DXGI_MODE_SCALING_STRETCHED,
	}

	/// <summary>Flags indicating the method the raster uses to create an image on a surface.</summary>
	/// <remarks>This enum is used by the <c>DXGI_MODE_DESC1</c> and <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structures.</remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173067(v=vs.85) typedef enum DXGI_MODE_SCANLINE_ORDER
	// { DXGI_MODE_SCANLINE_ORDER_UNSPECIFIED = 0, DXGI_MODE_SCANLINE_ORDER_PROGRESSIVE = 1, DXGI_MODE_SCANLINE_ORDER_UPPER_FIELD_FIRST
	// = 2, DXGI_MODE_SCANLINE_ORDER_LOWER_FIELD_FIRST = 3 } DXGI_MODE_SCANLINE_ORDER;
	[PInvokeData("DXGI.h")]
	public enum DXGI_MODE_SCANLINE_ORDER
	{
		/// <summary>Scanline order is unspecified.</summary>
		DXGI_MODE_SCANLINE_ORDER_UNSPECIFIED = 0,

		/// <summary>The image is created from the first scanline to the last without skipping any.</summary>
		DXGI_MODE_SCANLINE_ORDER_PROGRESSIVE,

		/// <summary>The image is created beginning with the upper field.</summary>
		DXGI_MODE_SCANLINE_ORDER_UPPER_FIELD_FIRST,

		/// <summary>The image is created beginning with the lower field.</summary>
		DXGI_MODE_SCANLINE_ORDER_LOWER_FIELD_FIRST,
	}

	/// <summary>Flags for <see cref="IDXGIFactory.MakeWindowAssociation(HWND, DXGI_MWA)"/></summary>
	[PInvokeData("dxgi.h")]
	[Flags]
	public enum DXGI_MWA
	{
		/// <summary>Prevent DXGI from monitoring an applications message queue; this makes DXGI unable to respond to mode changes.</summary>
		DXGI_MWA_NO_WINDOW_CHANGES = (1 << 0),

		/// <summary>Prevent DXGI from responding to an alt-enter sequence.</summary>
		DXGI_MWA_NO_ALT_ENTER = (1 << 1),

		/// <summary>Prevent DXGI from responding to a print-screen key.</summary>
		DXGI_MWA_NO_PRINT_SCREEN = (1 << 2),
	}

	/// <summary>
	/// <para>The <c>DXGI_PRESENT</c> constants specify options for presenting frames to the output.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Present a frame from each buffer (starting with the current buffer) to the output.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_DO_NOT_SEQUENCE 0x00000002UL</term>
	/// <term>
	/// Present a frame from the current buffer to the output. Use this flag so that the presentation can use vertical-blank
	/// synchronization instead of sequencing buffers in the chain in the usual manner.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_TEST 0x00000001UL</term>
	/// <term>
	/// Do not present the frame to the output. The status of the swap chain will be tested and appropriate errors returned.
	/// DXGI_PRESENT_TEST is intended for use only when switching from the idle state; do not use it to determine when to switch to the
	/// idle state because doing so can leave the swap chain unable to exit full-screen mode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_RESTART 0x00000004UL</term>
	/// <term>Specifies that the runtime will discard outstanding queued presents.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_DO_NOT_WAIT 0x00000008UL</term>
	/// <term>
	/// Specifies that the runtime will fail the presentation (that is, fail a call to IDXGISwapChain1::Present1) with the
	/// DXGI_ERROR_WAS_STILL_DRAWING error code if the calling thread is blocked; the runtime returns DXGI_ERROR_WAS_STILL_DRAWING
	/// instead of sleeping until the dependency is resolved. Direct3D 11: This enumeration value is supported starting with Windows 8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_RESTRICT_TO_OUTPUT 0x00000010UL</term>
	/// <term>
	/// Indicates that presentation content will be shown only on the particular output. The content will not be visible on other
	/// outputs. For example, if the user tries to relocate video content on another output, the video content will not be visible.
	/// Direct3D 11: This enumeration value is supported starting with Windows 8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_STEREO_PREFER_RIGHT 0x00000020UL</term>
	/// <term>
	/// Indicates that if the stereo present must be reduced to mono, right-eye viewing is used rather than left-eye viewing. Direct3D
	/// 11: This enumeration value is supported starting with Windows 8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_STEREO_TEMPORARY_MONO 0x00000040UL</term>
	/// <term>
	/// Indicates that the presentation should use the left buffer as a mono buffer. An application calls the
	/// IDXGISwapChain1::IsTemporaryMonoSupported method to determine whether a swap chain supports "temporary mono". Direct3D 11: This
	/// enumeration value is supported starting with Windows 8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_USE_DURATION 0x00000100UL</term>
	/// <term>This flag must be set by media apps that are currently using a custom present duration (custom refresh rate). See IDXGISwapChainMedia.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_ALLOW_TEARING 0x00000200UL</term>
	/// <term>
	/// Allowing tearing is a requirement of variable refresh rate displays. The conditions for using DXGI_PRESENT_ALLOW_TEARING during
	/// Present are as follows: Calling Present (or Present1) with this flag and not meeting the conditions above will result in a
	/// DXGI_ERROR_INVALID_CALL error being returned to the calling application.
	/// </term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Presentation options are supplied during the <c>IDXGISwapChain::Present</c> or <c>IDXGISwapChain1::Present1</c> call. The
	/// buffers are specified in the swap chain description (see <c>DXGI_SWAP_CHAIN_DESC</c> or <c>DXGI_SWAP_CHAIN_DESC1</c>).
	/// </para>
	/// <para>
	/// DXGI_PRESENT_RESTART is valid only for flip-model swap chains and full screen. Applications can use DXGI_PRESENT_RESTART to
	/// recover from glitches in playback, as well as to discard previously queued presentations. Discarding previously queued
	/// presentations is useful if those queued presentations are windowed scenarios. In particular, the previously queued presentation
	/// might have assumed that the window is an old size (that is, a resize operation occurred after submission).
	/// </para>
	/// <para>
	/// DXGI_PRESENT_RESTRICT_TO_OUTPUT is valid only for swap chains that specified a particular output to restrict content to when
	/// those swap chains were created ( <c>IDXGIFactory2::CreateSwapChainForHwnd</c>). If there is no output to restrict to, the flag
	/// is invalid.
	/// </para>
	/// <para>
	/// DXGI_PRESENT_STEREO_PREFER_RIGHT indicates that if the stereo present must be reduced to mono the right eye should be used
	/// rather than the left (default) eye. You can use this flag if one side is higher quality (for example, if the stereo pair is
	/// synthesized from a standard image.)
	/// </para>
	/// <para>
	/// DXGI_PRESENT_STEREO_TEMPORARY_MONO indicates that the present should use the left buffer as a mono buffer. You can use this flag
	/// to avoid updating the right buffer when an application temporarily has no stereo content. You should use this flag whenever
	/// possible because it enables significant optimization by the operating system and under some circumstances it can avoid visible
	/// mode change artifacts.
	/// </para>
	/// <para>
	/// You should use the DXGI_PRESENT_STEREO_TEMPORARY_MONO flag in preference to switching to a mono swap chain for most applications
	/// that you anticipate will use stereo again. You need to balance the use of this flag in applications that are extremely long
	/// running or that rarely display stereo against the disadvantage of unused memory.
	/// </para>
	/// <para>
	/// The DXGI_PRESENT_STEREO_PREFER_RIGHT and DXGI_PRESENT_STEREO_TEMPORARY_MONO flags apply only to stereo swap chains. If you use
	/// them when you present mono swap chains, an invalid operation occurs.
	/// </para>
	/// <para>
	/// If you use the DXGI_PRESENT_STEREO_TEMPORARY_MONO flag when you present a stereo swap chain that does not support temporary
	/// mono, an error occurs, the swap chain does not display, and the presentation returns DXGI_ERROR_INVALID_CALL.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-present
	[PInvokeData("dxgi.h", MSDNShortId = "1ddf8643-ea3e-4c9f-8439-c245942f7333")]
	[Flags]
	public enum DXGI_PRESENT
	{
		/// <summary>
		/// Do not present the frame to the output. The status of the swap chain will be tested and appropriate errors returned.
		/// DXGI_PRESENT_TEST is intended for use only when switching from the idle state; do not use it to determine when to switch to
		/// the idle state because doing so can leave the swap chain unable to exit full-screen mode.
		/// </summary>
		DXGI_PRESENT_TEST = 0x00000001,

		/// <summary>
		/// Present a frame from the current buffer to the output. Use this flag so that the presentation can use vertical-blank
		/// synchronization instead of sequencing buffers in the chain in the usual manner.
		/// </summary>
		DXGI_PRESENT_DO_NOT_SEQUENCE = 0x00000002,

		/// <summary>Specifies that the runtime will discard outstanding queued presents.</summary>
		DXGI_PRESENT_RESTART = 0x00000004,

		/// <summary>
		/// Specifies that the runtime will fail the presentation (that is, fail a call to IDXGISwapChain1::Present1) with the
		/// DXGI_ERROR_WAS_STILL_DRAWING error code if the calling thread is blocked; the runtime returns DXGI_ERROR_WAS_STILL_DRAWING
		/// instead of sleeping until the dependency is resolved. Direct3D 11: This enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_PRESENT_DO_NOT_WAIT = 0x00000008,

		/// <summary>
		/// Indicates that if the stereo present must be reduced to mono, right-eye viewing is used rather than left-eye viewing.
		/// Direct3D 11: This enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_PRESENT_STEREO_PREFER_RIGHT = 0x00000010,

		/// <summary>
		/// Indicates that the presentation should use the left buffer as a mono buffer. An application calls the
		/// IDXGISwapChain1::IsTemporaryMonoSupported method to determine whether a swap chain supports "temporary mono". Direct3D 11:
		/// This enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_PRESENT_STEREO_TEMPORARY_MONO = 0x00000020,

		/// <summary>
		/// Indicates that presentation content will be shown only on the particular output. The content will not be visible on other
		/// outputs. For example, if the user tries to relocate video content on another output, the video content will not be visible.
		/// Direct3D 11: This enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_PRESENT_RESTRICT_TO_OUTPUT = 0x00000040,

		/// <summary>
		/// This flag must be set by media apps that are currently using a custom present duration (custom refresh rate). See IDXGISwapChainMedia.
		/// </summary>
		DXGI_PRESENT_USE_DURATION = 0x00000100,

		/// <summary>
		/// Allowing tearing is a requirement of variable refresh rate displays. The conditions for using DXGI_PRESENT_ALLOW_TEARING
		/// during Present are as follows: Calling Present (or Present1) with this flag and not meeting the conditions above will result
		/// in a DXGI_ERROR_INVALID_CALL error being returned to the calling application.
		/// </summary>
		DXGI_PRESENT_ALLOW_TEARING = 0x00000200,
	}

	/// <summary>Flags indicating the memory location of a resource.</summary>
	/// <remarks>This enum is used by QueryResourceResidency.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_residency typedef enum DXGI_RESIDENCY {
	// DXGI_RESIDENCY_FULLY_RESIDENT, DXGI_RESIDENCY_RESIDENT_IN_SHARED_MEMORY, DXGI_RESIDENCY_EVICTED_TO_DISK } ;
	[PInvokeData("dxgi.h")]
	public enum DXGI_RESIDENCY
	{
		/// <summary>The resource is located in video memory.</summary>
		DXGI_RESIDENCY_FULLY_RESIDENT = 1,

		/// <summary>At least some of the resource is located in CPU memory.</summary>
		DXGI_RESIDENCY_RESIDENT_IN_SHARED_MEMORY,

		/// <summary>At least some of the resource has been paged out to the hard drive.</summary>
		DXGI_RESIDENCY_EVICTED_TO_DISK,
	}

	/// <summary>Options for swap-chain behavior.</summary>
	/// <remarks>
	/// <para>This enumeration is used by the DXGI_SWAP_CHAIN_DESC structure and the IDXGISwapChain::ResizeTarget method.</para>
	/// <para>This enumeration is also used by the DXGI_SWAP_CHAIN_DESC1 structure.</para>
	/// <para>
	/// You don't need to set <c>DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY</c> for swap chains that you create in full-screen mode with the
	/// IDXGIFactory::CreateSwapChain method because those swap chains already behave as if <c>DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY</c> is
	/// set. That is, presented content is not accessible by remote access or through the desktop duplication APIs.
	/// </para>
	/// <para>
	/// Swap chains that you create with the IDXGIFactory2::CreateSwapChainForHwnd, IDXGIFactory2::CreateSwapChainForCoreWindow, and
	/// IDXGIFactory2::CreateSwapChainForComposition methods are not protected if <c>DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY</c> is not set
	/// and are protected if <c>DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY</c> is set. When swap chains are protected, screen scraping is
	/// prevented and, in full-screen mode, presented content is not accessible through the desktop duplication APIs.
	/// </para>
	/// <para>
	/// When you call IDXGISwapChain::ResizeBuffers to change the swap chain's back buffer, you can reset or change all
	/// <c>DXGI_SWAP_CHAIN_FLAG</c> flags.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_swap_chain_flag typedef enum DXGI_SWAP_CHAIN_FLAG {
	// DXGI_SWAP_CHAIN_FLAG_NONPREROTATED, DXGI_SWAP_CHAIN_FLAG_ALLOW_MODE_SWITCH, DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE,
	// DXGI_SWAP_CHAIN_FLAG_RESTRICTED_CONTENT, DXGI_SWAP_CHAIN_FLAG_RESTRICT_SHARED_RESOURCE_DRIVER, DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY,
	// DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT, DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER, DXGI_SWAP_CHAIN_FLAG_FULLSCREEN_VIDEO,
	// DXGI_SWAP_CHAIN_FLAG_YUV_VIDEO, DXGI_SWAP_CHAIN_FLAG_HW_PROTECTED, DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING,
	// DXGI_SWAP_CHAIN_FLAG_RESTRICTED_TO_ALL_HOLOGRAPHIC_DISPLAYS } ;
	[PInvokeData("dxgi.h")]
	[Flags]
	public enum DXGI_SWAP_CHAIN_FLAG
	{
		/// <summary>
		/// Set this flag to turn off automatic image rotation; that is, do not perform a rotation when transferring the contents of the
		/// front buffer to the monitor. Use this flag to avoid a bandwidth penalty when an application expects to handle rotation. This
		/// option is valid only during full-screen mode.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_NONPREROTATED = 1,

		/// <summary>
		/// Set this flag to enable an application to switch modes by calling IDXGISwapChain::ResizeTarget. When switching from windowed
		/// to full-screen mode, the display mode (or monitor resolution) will be changed to match the dimensions of the application window.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_ALLOW_MODE_SWITCH = 2,

		/// <summary>
		/// Set this flag to enable an application to render using GDI on a swap chain or a surface. This will allow the application to
		/// call IDXGISurface1::GetDC on the 0th back buffer or a surface.This flag is not applicable for Direct3D 12.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE = 4,

		/// <summary>
		/// Set this flag to indicate that the swap chain might contain protected content; therefore, the operating system supports the
		/// creation of the swap chain only when driver and hardware protection is used. If the driver and hardware do not support
		/// content protection, the call to create a resource for the swap chain fails.Direct3D 11: This enumeration value is supported
		/// starting with Windows 8.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_RESTRICTED_CONTENT = 8,

		/// <summary>
		/// Set this flag to indicate that shared resources that are created within the swap chain must be protected by using the
		/// driver’s mechanism for restricting access to shared surfaces.Direct3D 11: This enumeration value is supported starting with
		/// Windows 8.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_RESTRICT_SHARED_RESOURCE_DRIVER = 16,

		/// <summary>
		/// Set this flag to restrict presented content to the local displays. Therefore, the presented content is not accessible via
		/// remote accessing or through the desktop duplication APIs. This flag supports the window content protection features of
		/// Windows. Applications can use this flag to protect their own onscreen window content from being captured or copied through a
		/// specific set of public operating system features and APIs.If you use this flag with windowed (HWND or IWindow) swap chains
		/// where another process created the HWND, the owner of the HWND must use the SetWindowDisplayAffinity function appropriately
		/// in order to allow calls to IDXGISwapChain::Present or IDXGISwapChain1::Present1 to succeed.Direct3D 11: This enumeration
		/// value is supported starting with Windows 8.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY = 32,

		/// <summary>
		/// Set this flag to create a waitable object you can use to ensure rendering does not begin while a frame is still being
		/// presented. When this flag is used, the swapchain's latency must be set with the IDXGISwapChain2::SetMaximumFrameLatency API
		/// instead of IDXGIDevice1::SetMaximumFrameLatency.Note This enumeration value is supported starting with Windows 8.1.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT = 64,

		/// <summary>
		/// Set this flag to create a swap chain in the foreground layer for multi-plane rendering. This flag can only be used with
		/// CoreWindow swap chains, which are created with CreateSwapChainForCoreWindow. Apps should not create foreground swap chains
		/// if IDXGIOutput2::SupportsOverlays indicates that hardware support for overlays is not available.Note that
		/// IDXGISwapChain::ResizeBuffers cannot be used to add or remove this flag.Note This enumeration value is supported starting
		/// with Windows 8.1.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER = 128,

		/// <summary>
		/// Set this flag to create a swap chain for full-screen video. Note This enumeration value is supported starting with Windows 8.1.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_FULLSCREEN_VIDEO = 256,

		/// <summary>
		/// Set this flag to create a swap chain for YUV video.Note This enumeration value is supported starting with Windows 8.1.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_YUV_VIDEO = 512,

		/// <summary>
		/// Indicates that the swap chain should be created such that all underlying resources can be protected by the hardware.
		/// Resource creation will fail if hardware content protection is not supported.This flag has the following restrictions:Note
		/// This enumeration value is supported starting with Windows 10.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_HW_PROTECTED = 1024,

		/// <summary>
		/// Tearing support is a requirement to enable displays that support variable refresh rates to function properly when the
		/// application presents a swap chain tied to a full screen borderless window. Win32 apps can already achieve tearing in
		/// fullscreen exclusive mode by calling SetFullscreenState(TRUE), but the recommended approach for Win32 developers is to use
		/// this tearing flag instead. This flag requires the use of a DXGI_SWAP_EFFECT_FLIP_* swap effect.To check for hardware support
		/// of this feature, refer to IDXGIFactory5::CheckFeatureSupport. For usage information refer to IDXGISwapChain::Present and the
		/// DXGI_PRESENT flags.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING = 2048,

		/// <summary/>
		DXGI_SWAP_CHAIN_FLAG_RESTRICTED_TO_ALL_HOLOGRAPHIC_DISPLAYS = 4096,
	}

	/// <summary>Options for handling pixels in a display surface after calling IDXGISwapChain1::Present1.</summary>
	/// <remarks>
	/// <para>This enumeration is used by the DXGI_SWAP_CHAIN_DESC and DXGI_SWAP_CHAIN_DESC1structures.</para>
	/// <para>
	/// To use multisampling with <c>DXGI_SWAP_EFFECT_SEQUENTIAL</c> or <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c>, you must perform the
	/// multisampling in a separate render target. For example, create a multisampled texture by calling ID3D11Device::CreateTexture2D
	/// with a filled D3D11_TEXTURE2D_DESC structure ( <c>BindFlags</c> member set to D3D11_BIND_RENDER_TARGET and <c>SampleDesc</c>
	/// member with multisampling parameters). Next call ID3D11Device::CreateRenderTargetView to create a render-target view for the
	/// texture, and render your scene into the texture. Finally call ID3D11DeviceContext::ResolveSubresource to resolve the
	/// multisampled texture into your non-multisampled swap chain.
	/// </para>
	/// <para>
	/// The primary difference between presentation models is how back-buffer contents get to the Desktop Window Manager (DWM) for
	/// composition. In the bitblt model, which is used with the <c>DXGI_SWAP_EFFECT_DISCARD</c> and <c>DXGI_SWAP_EFFECT_SEQUENTIAL</c>
	/// values, contents of the back buffer get copied into the redirection surface on each call to IDXGISwapChain1::Present1. In the
	/// flip model, which is used with the <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c> value, all back buffers are shared with the DWM.
	/// Therefore, the DWM can compose straight from those back buffers without any additional copy operations. In general, the flip
	/// model is the more efficient model. The flip model also provides more features, such as enhanced present statistics.
	/// </para>
	/// <para>
	/// When you call IDXGISwapChain1::Present1 on a flip model swap chain ( <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c>) with 0 specified
	/// in the SyncInterval parameter, <c>IDXGISwapChain1::Present1</c>'s behavior is the same as the behavior of Direct3D 9Ex's
	/// IDirect3DDevice9Ex::PresentEx with D3DSWAPEFFECT_FLIPEX and D3DPRESENT_FORCEIMMEDIATE. That is, the runtime not only presents
	/// the next frame instead of any previously queued frames, it also terminates any remaining time left on the previously queued frames.
	/// </para>
	/// <para>
	/// Regardless of whether the flip model is more efficient, an application still might choose the bitblt model because the bitblt
	/// model is the only way to mix GDI and DirectX presentation. In the flip model, the application must create the swap chain with
	/// DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE, and then must use GetDC on the back buffer explicitly. After the first successful call to
	/// IDXGISwapChain1::Present1 on a flip-model swap chain, GDI no longer works with the HWND that is associated with that swap chain,
	/// even after the destruction of the swap chain. This restriction even extends to methods like ScrollWindowEx.
	/// </para>
	/// <para>
	/// For more info about the flip-model swap chain and optimizing presentation, see Enhancing presentation with the flip model, dirty
	/// rectangles, and scrolled areas.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// To create a swap chain in UWP, you just need to create a new instance of the DX11 template and look at the implementation of in
	/// the D3D12 samples.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_swap_effect typedef enum DXGI_SWAP_EFFECT {
	// DXGI_SWAP_EFFECT_DISCARD, DXGI_SWAP_EFFECT_SEQUENTIAL, DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL, DXGI_SWAP_EFFECT_FLIP_DISCARD } ;
	[PInvokeData("dxgi.h")]
	public enum DXGI_SWAP_EFFECT
	{
		/// <summary>
		/// Use this flag to specify the bit-block transfer (bitblt) model and to specify that DXGI discard the contents of the back
		/// buffer after you call IDXGISwapChain1::Present1. This flag is valid for a swap chain with more than one back buffer,
		/// although, applications only have read and write access to buffer 0. Use this flag to enable the display driver to select the
		/// most efficient presentation technique for the swap chain.
		/// </summary>
		DXGI_SWAP_EFFECT_DISCARD = 0,

		/// <summary>
		/// Use this flag to specify the bitblt model and to specify that DXGI persist the contents of the back buffer after you call
		/// IDXGISwapChain1::Present1. Use this option to present the contents of the swap chain in order, from the first buffer (buffer
		/// 0) to the last buffer. This flag cannot be used with multisampling.
		/// </summary>
		DXGI_SWAP_EFFECT_SEQUENTIAL = 1,

		/// <summary>
		/// Use this flag to specify the flip presentation model and to specify that DXGI persist the contents of the back buffer after
		/// you call IDXGISwapChain1::Present1. This flag cannot be used with multisampling. Direct3D 11: This enumeration value is
		/// supported starting with Windows 8.
		/// </summary>
		DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL = 3,

		/// <summary>
		/// Use this flag to specify the flip presentation model and to specify that DXGI discard the contents of the back buffer after
		/// you call IDXGISwapChain1::Present1. This flag cannot be used with multisampling and partial presentation. See DXGI 1.4
		/// Improvements. Direct3D 11: This enumeration value is supported starting with Windows 10.
		/// </summary>
		DXGI_SWAP_EFFECT_FLIP_DISCARD = 4,
	}

	/// <summary>
	/// <para>Flags for surface and resource creation options.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DXGI_USAGE_BACK_BUFFER 1L &lt;&lt; (2 + 4)</term>
	/// <term>
	/// The surface or resource is used as a back buffer. You don’t need to pass DXGI_USAGE_BACK_BUFFER when you create a swap chain.
	/// But you can determine whether a resource belongs to a swap chain when you call IDXGIResource::GetUsage and get DXGI_USAGE_BACK_BUFFER.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_DISCARD_ON_PRESENT 1L &lt;&lt; (5 + 4)</term>
	/// <term>This flag is for internal use only.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_READ_ONLY 1L &lt;&lt; (4 + 4)</term>
	/// <term>Use the surface or resource for reading only.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_RENDER_TARGET_OUTPUT 1L &lt;&lt; (1 + 4)</term>
	/// <term>Use the surface or resource as an output render target.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_SHADER_INPUT 1L &lt;&lt; (0 + 4)</term>
	/// <term>Use the surface or resource as an input to a shader.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_SHARED 1L &lt;&lt; (3 + 4)</term>
	/// <term>Share the surface or resource.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_UNORDERED_ACCESS 1L &lt;&lt; (6 + 4)</term>
	/// <term>Use the surface or resource for unordered access.</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>Each flag is defined as an unsigned integer.</para>
	/// <para>
	/// These flag options are used in a call to the <c>IDXGIFactory::CreateSwapChain</c>, <c>IDXGIFactory2::CreateSwapChainForHwnd</c>,
	/// <c>IDXGIFactory2::CreateSwapChainForCoreWindow</c>, or <c>IDXGIFactory2::CreateSwapChainForComposition</c> method to describe
	/// the surface usage and CPU access options for the back buffer of a swap chain. You can't use the <c>DXGI_USAGE_SHARED</c>,
	/// <c>DXGI_USAGE_DISCARD_ON_PRESENT</c>, and <c>DXGI_USAGE_READ_ONLY</c> values as input to create a swap chain. However, DXGI can
	/// set <c>DXGI_USAGE_DISCARD_ON_PRESENT</c> and <c>DXGI_USAGE_READ_ONLY</c> for some of the swap chain's back buffers on the
	/// application's behalf. You can call the <c>IDXGIResource::GetUsage</c> method to retrieve the usage of these back buffers. Swap
	/// chain's only support the <c>DXGI_CPU_ACCESS_NONE</c> value in the <c>DXGI_CPU_ACCESS_FIELD</c> part of <c>DXGI_USAGE</c>.
	/// </para>
	/// <para>These flag options are also used by the <c>IDXGIDevice::CreateSurface</c> method.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-usage
	[PInvokeData("", MSDNShortId = "b5026566-89b5-458e-b36d-a55e5f8c10c1")]
	[Flags]
	public enum DXGI_USAGE : uint
	{
		/// <summary/>
		DXGI_CPU_ACCESS_NONE = 0,

		/// <summary/>
		DXGI_CPU_ACCESS_DYNAMIC = 1,

		/// <summary/>
		DXGI_CPU_ACCESS_READ_WRITE = 2,

		/// <summary/>
		DXGI_CPU_ACCESS_SCRATCH = 3,

		/// <summary/>
		DXGI_CPU_ACCESS_FIELD = 15,

		/// <summary>Use the surface or resource as an input to a shader.</summary>
		DXGI_USAGE_SHADER_INPUT = 0x00000010,

		/// <summary>Use the surface or resource as an output render target.</summary>
		DXGI_USAGE_RENDER_TARGET_OUTPUT = 0x00000020,

		/// <summary>
		/// The surface or resource is used as a back buffer. You don’t need to pass DXGI_USAGE_BACK_BUFFER when you create a swap
		/// chain. But you can determine whether a resource belongs to a swap chain when you call IDXGIResource::GetUsage and get DXGI_USAGE_BACK_BUFFER.
		/// </summary>
		DXGI_USAGE_BACK_BUFFER = 0x00000040,

		/// <summary>Share the surface or resource.</summary>
		DXGI_USAGE_SHARED = 0x00000080,

		/// <summary/>
		DXGI_USAGE_READ_ONLY = 0x00000100,

		/// <summary>This flag is for internal use only.</summary>
		DXGI_USAGE_DISCARD_ON_PRESENT = 0x00000200,

		/// <summary>Use the surface or resource for unordered access.</summary>
		DXGI_USAGE_UNORDERED_ACCESS = 0x00000400,
	}

	/// <summary>Creates a DXGI 1.0 factory that you can use to generate other DXGI objects.</summary>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The globally unique identifier (GUID) of the IDXGIFactory object referenced by the ppFactory parameter.</para>
	/// </param>
	/// <param name="ppFactory">
	/// <para>Type: <c>void**</c></para>
	/// <para>Address of a pointer to an IDXGIFactory object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns <c>S_OK</c> if successful; otherwise, returns one of the following DXGI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use a DXGI factory to generate objects that enumerate adapters, create swap chains, and associate a window with the alt+enter
	/// key sequence for toggling to and from the fullscreen display mode.
	/// </para>
	/// <para>
	/// If the <c>CreateDXGIFactory</c> function succeeds, the reference count on the IDXGIFactory interface is incremented. To avoid a
	/// memory leak, when you finish using the interface, call the IDXGIFactory::Release method to release the interface.
	/// </para>
	/// <para>
	/// <c>Note</c> Do not mix the use of DXGI 1.0 (IDXGIFactory) and DXGI 1.1 (IDXGIFactory1) in an application. Use
	/// <c>IDXGIFactory</c> or <c>IDXGIFactory1</c>, but not both in an application.
	/// </para>
	/// <para>
	/// <c>Note</c><c>CreateDXGIFactory</c> fails if your app's DllMain function calls it. For more info about how DXGI responds from
	/// <c>DllMain</c>, see DXGI Responses from DLLMain.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, all DXGI factories (regardless if they were created with <c>CreateDXGIFactory</c> or
	/// CreateDXGIFactory1) enumerate adapters identically. The enumeration order of adapters, which you retrieve with
	/// IDXGIFactory::EnumAdapters or IDXGIFactory1::EnumAdapters1, is as follows:
	/// </para>
	/// <para>
	/// The <c>CreateDXGIFactory</c> function does not exist for Windows Store apps. Instead, Windows Store apps use the
	/// CreateDXGIFactory1 function.
	/// </para>
	/// <para>Examples</para>
	/// <para>Creating a DXGI 1.0 Factory</para>
	/// <para>
	/// The following code example demonstrates how to create a DXGI 1.0 factory. This example uses the __uuidof() intrinsic to obtain
	/// the REFIID, or GUID, of the IDXGIFactory interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-createdxgifactory HRESULT CreateDXGIFactory( REFIID riid, void
	// **ppFactory );
	[DllImport(Lib.DXGI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dxgi.h")]
	public static extern HRESULT CreateDXGIFactory(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppFactory);

	/// <summary>Creates a DXGI 1.0 factory that you can use to generate other DXGI objects.</summary>
	/// <returns>An IDXGIFactory object.</returns>
	/// <remarks>
	/// <para>
	/// Use a DXGI factory to generate objects that enumerate adapters, create swap chains, and associate a window with the alt+enter
	/// key sequence for toggling to and from the fullscreen display mode.
	/// </para>
	/// <para>
	/// If the <c>CreateDXGIFactory</c> function succeeds, the reference count on the IDXGIFactory interface is incremented. To avoid a
	/// memory leak, when you finish using the interface, call the IDXGIFactory::Release method to release the interface.
	/// </para>
	/// <para>
	/// <c>Note</c> Do not mix the use of DXGI 1.0 (IDXGIFactory) and DXGI 1.1 (IDXGIFactory1) in an application. Use
	/// <c>IDXGIFactory</c> or <c>IDXGIFactory1</c>, but not both in an application.
	/// </para>
	/// <para>
	/// <c>Note</c><c>CreateDXGIFactory</c> fails if your app's DllMain function calls it. For more info about how DXGI responds from
	/// <c>DllMain</c>, see DXGI Responses from DLLMain.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, all DXGI factories (regardless if they were created with <c>CreateDXGIFactory</c> or
	/// CreateDXGIFactory1) enumerate adapters identically. The enumeration order of adapters, which you retrieve with
	/// IDXGIFactory::EnumAdapters or IDXGIFactory1::EnumAdapters1, is as follows:
	/// </para>
	/// <para>
	/// The <c>CreateDXGIFactory</c> function does not exist for Windows Store apps. Instead, Windows Store apps use the
	/// CreateDXGIFactory1 function.
	/// </para>
	/// </remarks>
	public static IDXGIFactory CreateDXGIFactory()
	{
		CreateDXGIFactory(typeof(IDXGIFactory).GUID, out var f).ThrowIfFailed();
		return (IDXGIFactory)f;
	}

	/// <summary>Creates a DXGI 1.1 factory that you can use to generate other DXGI objects.</summary>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The globally unique identifier (GUID) of the IDXGIFactory1 object referenced by the ppFactory parameter.</para>
	/// </param>
	/// <param name="ppFactory">
	/// <para>Type: <c>void**</c></para>
	/// <para>Address of a pointer to an IDXGIFactory1 object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful; an error code otherwise. For a list of error codes, see DXGI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use a DXGI 1.1 factory to generate objects that enumerate adapters, create swap chains, and associate a window with the
	/// alt+enter key sequence for toggling to and from the full-screen display mode.
	/// </para>
	/// <para>
	/// If the <c>CreateDXGIFactory1</c> function succeeds, the reference count on the IDXGIFactory1 interface is incremented. To avoid
	/// a memory leak, when you finish using the interface, call the IDXGIFactory1::Release method to release the interface.
	/// </para>
	/// <para>
	/// This entry point is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is
	/// required, which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2)
	/// (KB 971644) and Windows Server 2008 (KB 971512).
	/// </para>
	/// <para>
	/// <c>Note</c> Do not mix the use of DXGI 1.0 (IDXGIFactory) and DXGI 1.1 (IDXGIFactory1) in an application. Use
	/// <c>IDXGIFactory</c> or <c>IDXGIFactory1</c>, but not both in an application.
	/// </para>
	/// <para>
	/// <c>Note</c><c>CreateDXGIFactory1</c> fails if your app's DllMain function calls it. For more info about how DXGI responds from
	/// <c>DllMain</c>, see DXGI Responses from DLLMain.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, all DXGI factories (regardless if they were created with CreateDXGIFactory or
	/// <c>CreateDXGIFactory1</c>) enumerate adapters identically. The enumeration order of adapters, which you retrieve with
	/// IDXGIFactory::EnumAdapters or IDXGIFactory1::EnumAdapters1, is as follows:
	/// </para>
	/// <para>Examples</para>
	/// <para>Creating a DXGI 1.1 Factory</para>
	/// <para>
	/// The following code example demonstrates how to create a DXGI 1.1 factory. This example uses the __uuidof() intrinsic to obtain
	/// the REFIID, or GUID, of the IDXGIFactory1 interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-createdxgifactory1 HRESULT CreateDXGIFactory1( REFIID riid, void
	// **ppFactory );
	[DllImport(Lib.DXGI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dxgi.h", MSDNShortId = "6fb9d7a3-0b59-4b7a-8871-b99d59811d46")]
	public static extern HRESULT CreateDXGIFactory1(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppFactory);

	/// <summary>
	/// <para>Creates a DXGI 1.3 factory that you can use to generate other DXGI objects.</para>
	/// <para>
	/// In Windows 8, any DXGI factory created while DXGIDebug.dll was present on the system would load and use it. Starting in Windows
	/// 8.1, apps explicitly request that DXGIDebug.dll be loaded instead. Use <c>CreateDXGIFactory2</c> and specify the
	/// DXGI_CREATE_FACTORY_DEBUG flag to request DXGIDebug.dll; the DLL will be loaded if it is present on the system.
	/// </para>
	/// </summary>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Valid values include the <c>DXGI_CREATE_FACTORY_DEBUG (0x01)</c> flag, and zero.</para>
	/// <para><c>Note</c> This flag will be set by the D3D runtime if:</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The globally unique identifier (GUID) of the IDXGIFactory2 object referenced by the ppFactory parameter.</para>
	/// </param>
	/// <param name="ppFactory">
	/// <para>Type: <c>void**</c></para>
	/// <para>Address of a pointer to an IDXGIFactory2 object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful; an error code otherwise. For a list of error codes, see DXGI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// This function accepts a flag indicating whether DXGIDebug.dll is loaded. The function otherwise behaves identically to CreateDXGIFactory1.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-createdxgifactory2 HRESULT CreateDXGIFactory2( UINT Flags,
	// REFIID riid, void **ppFactory );
	[DllImport(Lib.DXGI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dxgi1_3.h", MSDNShortId = "D3CF43B0-8F17-486E-8750-CF0B9052BE74")]
	public static extern HRESULT CreateDXGIFactory2(DXGI_CREATE_FACTORY Flags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppFactory);

	/// <summary>Allows a process to indicate that it's resilient to any of its graphics devices being removed.</summary>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns <c>S_OK</c> if successful; an error code otherwise. If this function is called after device creation, it returns
	/// <c>DXGI_ERROR_INVALID_CALL</c>. If this is not the first time that this function is called, it returns
	/// <c>DXGI_ERROR_ALREADY_EXISTS</c>. For a full list of error codes, see DXGI_ERROR.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is graphics API-agonistic, meaning that apps running on other APIs, such as OpenGL and Vulkan, would also apply.
	/// </para>
	/// <para>This function should be called once per process and before any device creation.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi1_6/nf-dxgi1_6-dxgideclareadapterremovalsupport HRESULT DXGIDeclareAdapterRemovalSupport();
	[DllImport(Lib.DXGI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dxgi1_6.h", MSDNShortId = "602EA66C-6D3D-4604-822C-DBD66EB70C3C")]
	public static extern HRESULT DXGIDeclareAdapterRemovalSupport();

	/// <summary>Retrieves an interface that Windows Store apps use for debugging the Microsoft DirectX Graphics Infrastructure (DXGI).</summary>
	/// <param name="Flags">Not used.</param>
	/// <param name="riid">
	/// The globally unique identifier (GUID) of the requested interface type, which can be the identifier for the IDXGIDebug,
	/// IDXGIDebug1, or IDXGIInfoQueue interfaces.
	/// </param>
	/// <param name="pDebug">A pointer to a buffer that receives a pointer to the debugging interface.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// The <c>DXGIGetDebugInterface1</c> function returns <c>E_NOINTERFACE</c> on systems without the Windows Software Development Kit
	/// (SDK) installed, because it's a development-time aid.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi1_3/nf-dxgi1_3-dxgigetdebuginterface1 HRESULT DXGIGetDebugInterface1( UINT
	// Flags, REFIID riid, void **pDebug );
	[DllImport(Lib.DXGI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dxgi1_3.h", MSDNShortId = "0FE0EAF5-3ADC-426F-9DA9-FEDEC519EEF0")]
	public static extern HRESULT DXGIGetDebugInterface1(uint Flags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object pDebug);

	/// <summary>Describes an adapter (or video card) by using DXGI 1.0.</summary>
	/// <remarks>
	/// The <c>DXGI_ADAPTER_DESC</c> structure provides a description of an adapter. This structure is initialized by using the
	/// IDXGIAdapter::GetDesc method.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc typedef struct DXGI_ADAPTER_DESC { WCHAR
	// Description[128]; UINT VendorId; UINT DeviceId; UINT SubSysId; UINT Revision; SIZE_T DedicatedVideoMemory; SIZE_T
	// DedicatedSystemMemory; SIZE_T SharedSystemMemory; LUID AdapterLuid; } DXGI_ADAPTER_DESC;
	[PInvokeData("dxgi.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DXGI_ADAPTER_DESC
	{
		/// <summary>
		/// <para>Type: <c>WCHAR[128]</c></para>
		/// <para>
		/// A string that contains the adapter description. On feature level 9 graphics hardware, GetDesc returns “Software Adapter” for
		/// the description string.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string Description;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the hardware vendor. On feature level 9 graphics hardware, GetDesc returns zeros for the PCI ID of the
		/// hardware vendor.
		/// </para>
		/// </summary>
		public uint VendorId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the hardware device. On feature level 9 graphics hardware, GetDesc returns zeros for the PCI ID of the
		/// hardware device.
		/// </para>
		/// </summary>
		public uint DeviceId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the sub system. On feature level 9 graphics hardware, GetDesc returns zeros for the PCI ID of the sub system.
		/// </para>
		/// </summary>
		public uint SubSysId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the revision number of the adapter. On feature level 9 graphics hardware, GetDesc returns zeros for the PCI ID
		/// of the revision number of the adapter.
		/// </para>
		/// </summary>
		public uint Revision;

		/// <summary>
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>The number of bytes of dedicated video memory that are not shared with the CPU.</para>
		/// </summary>
		public SizeT DedicatedVideoMemory;

		/// <summary>
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>
		/// The number of bytes of dedicated system memory that are not shared with the CPU. This memory is allocated from available
		/// system memory at boot time.
		/// </para>
		/// </summary>
		public SizeT DedicatedSystemMemory;

		/// <summary>
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>
		/// The number of bytes of shared system memory. This is the maximum value of system memory that may be consumed by the adapter
		/// during operation. Any incidental memory consumed by the driver as it manages and uses video memory is additional.
		/// </para>
		/// </summary>
		public SizeT SharedSystemMemory;

		/// <summary>
		/// <para>Type: <c>LUID</c></para>
		/// <para>
		/// A unique value that identifies the adapter. See LUID for a definition of the structure. <c>LUID</c> is defined in dxgi.h.
		/// </para>
		/// </summary>
		public AdvApi32.LUID AdapterLuid;
	}

	/// <summary>Describes an adapter (or video card) using DXGI 1.1.</summary>
	/// <remarks>
	/// The <c>DXGI_ADAPTER_DESC1</c> structure provides a DXGI 1.1 description of an adapter. This structure is initialized by using
	/// the IDXGIAdapter1::GetDesc1 method.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1 typedef struct DXGI_ADAPTER_DESC1 { WCHAR
	// Description[128]; UINT VendorId; UINT DeviceId; UINT SubSysId; UINT Revision; SIZE_T DedicatedVideoMemory; SIZE_T
	// DedicatedSystemMemory; SIZE_T SharedSystemMemory; LUID AdapterLuid; UINT Flags; } DXGI_ADAPTER_DESC1;
	[PInvokeData("dxgi.h", MSDNShortId = "0ae3bdb1-b122-439a-8f62-c831a9dd87e2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DXGI_ADAPTER_DESC1
	{
		/// <summary>
		/// <para>Type: <c>WCHAR[128]</c></para>
		/// <para>
		/// A string that contains the adapter description. On feature level 9 graphics hardware, GetDesc1 returns “Software Adapter”
		/// for the description string.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string Description;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the hardware vendor. On feature level 9 graphics hardware, GetDesc1 returns zeros for the PCI ID of the
		/// hardware vendor.
		/// </para>
		/// </summary>
		public uint VendorId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the hardware device. On feature level 9 graphics hardware, GetDesc1 returns zeros for the PCI ID of the
		/// hardware device.
		/// </para>
		/// </summary>
		public uint DeviceId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the sub system. On feature level 9 graphics hardware, GetDesc1 returns zeros for the PCI ID of the sub system.
		/// </para>
		/// </summary>
		public uint SubSysId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the revision number of the adapter. On feature level 9 graphics hardware, GetDesc1 returns zeros for the PCI
		/// ID of the revision number of the adapter.
		/// </para>
		/// </summary>
		public uint Revision;

		/// <summary>
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>The number of bytes of dedicated video memory that are not shared with the CPU.</para>
		/// </summary>
		public SizeT DedicatedVideoMemory;

		/// <summary>
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>
		/// The number of bytes of dedicated system memory that are not shared with the CPU. This memory is allocated from available
		/// system memory at boot time.
		/// </para>
		/// </summary>
		public SizeT DedicatedSystemMemory;

		/// <summary>
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>
		/// The number of bytes of shared system memory. This is the maximum value of system memory that may be consumed by the adapter
		/// during operation. Any incidental memory consumed by the driver as it manages and uses video memory is additional.
		/// </para>
		/// </summary>
		public SizeT SharedSystemMemory;

		/// <summary>
		/// <para>Type: <c>LUID</c></para>
		/// <para>
		/// A unique value that identifies the adapter. See LUID for a definition of the structure. <c>LUID</c> is defined in dxgi.h.
		/// </para>
		/// </summary>
		public AdvApi32.LUID AdapterLuid;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value of the DXGI_ADAPTER_FLAG enumerated type that describes the adapter type. The <c>DXGI_ADAPTER_FLAG_REMOTE</c> flag
		/// is reserved.
		/// </para>
		/// </summary>
		public DXGI_ADAPTER_FLAG Flags;
	}

	/// <summary>Describes timing and presentation statistics for a frame.</summary>
	/// <remarks>
	/// <para>
	/// You initialize the <c>DXGI_FRAME_STATISTICS</c> structure with the IDXGIOutput::GetFrameStatistics or
	/// IDXGISwapChain::GetFrameStatistics method.
	/// </para>
	/// <para>
	/// You can only use IDXGISwapChain::GetFrameStatistics for swap chains that either use the flip presentation model or draw in
	/// full-screen mode. You set the DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL value in the <c>SwapEffect</c> member of the
	/// DXGI_SWAP_CHAIN_DESC1 structure to specify that the swap chain uses the flip presentation model.
	/// </para>
	/// <para>
	/// The values in the <c>PresentCount</c> and <c>PresentRefreshCount</c> members indicate information about when a frame was
	/// presented on the display screen. You can use these values to determine whether a glitch occurred. The values in the
	/// <c>SyncRefreshCount</c> and <c>SyncQPCTime</c> members indicate timing information that you can use for audio and video
	/// synchronization or very precise animation. If the swap chain draws in full-screen mode, these values are based on when the
	/// computer booted. If the swap chain draws in windowed mode, these values are based on when the swap chain is created.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_frame_statistics typedef struct DXGI_FRAME_STATISTICS { UINT
	// PresentCount; UINT PresentRefreshCount; UINT SyncRefreshCount; LARGE_INTEGER SyncQPCTime; LARGE_INTEGER SyncGPUTime; } DXGI_FRAME_STATISTICS;
	[PInvokeData("dxgi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_FRAME_STATISTICS
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value that represents the running total count of times that an image was presented to the monitor since the computer booted.
		/// </para>
		/// <para>
		/// <c>Note</c> The number of times that an image was presented to the monitor is not necessarily the same as the number of
		/// times that you called IDXGISwapChain::Present or IDXGISwapChain1::Present1.
		/// </para>
		/// </summary>
		public uint PresentCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value that represents the running total count of v-blanks at which the last image was presented to the monitor and that
		/// have happened since the computer booted (for windowed mode, since the swap chain was created).
		/// </para>
		/// </summary>
		public uint PresentRefreshCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value that represents the running total count of v-blanks when the scheduler last sampled the machine time by calling
		/// QueryPerformanceCounter and that have happened since the computer booted (for windowed mode, since the swap chain was created).
		/// </para>
		/// </summary>
		public uint SyncRefreshCount;

		/// <summary>
		/// <para>Type: <c>LARGE_INTEGER</c></para>
		/// <para>
		/// A value that represents the high-resolution performance counter timer. This value is the same as the value returned by the
		/// QueryPerformanceCounter function.
		/// </para>
		/// </summary>
		public int SyncQPCTime;

		/// <summary>
		/// <para>Type: <c>LARGE_INTEGER</c></para>
		/// <para>Reserved. Always returns 0.</para>
		/// </summary>
		public int SyncGPUTime;
	}

	/// <summary>Controls the settings of a gamma curve.</summary>
	/// <remarks>
	/// <para>The <c>DXGI_GAMMA_CONTROL</c> structure is used by the <c>IDXGIOutput::SetGammaControl</c> method.</para>
	/// <para>For info about using gamma correction, see Using gamma correction.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173061(v=vs.85) typedef struct DXGI_GAMMA_CONTROL {
	// DXGI_RGB Scale; DXGI_RGB Offset; DXGI_RGB GammaCurve[1025]; } DXGI_GAMMA_CONTROL;
	[PInvokeData("DXGI.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_GAMMA_CONTROL
	{
		/// <summary>
		/// A DXGI_RGB structure with scalar values that are applied to rgb values before being sent to the gamma look up table.
		/// </summary>
		public DXGI_RGB Scale;

		/// <summary>
		/// A DXGI_RGB structure with offset values that are applied to the rgb values before being sent to the gamma look up table.
		/// </summary>
		public DXGI_RGB Offset;

		/// <summary>An array of DXGI_RGB structures that control the points of a gamma curve.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)]
		public DXGI_RGB[] GammaCurve;
	}

	/// <summary>The DXGI_GAMMA_CONTROL_CAPABILIITES structure describes gamma capabilities.</summary>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/dxgitype/ns-dxgitype-dxgi_gamma_control_capabilities typedef struct
	// DXGI_GAMMA_CONTROL_CAPABILITIES { BOOL ScaleAndOffsetSupported; float MaxConvertedValue; float MinConvertedValue; UINT
	// NumGammaControlPoints; float ControlPointPositions[1025]; } DXGI_GAMMA_CONTROL_CAPABILITIES;
	[PInvokeData("dxgitype.h", MSDNShortId = "7a91311e-c8b9-4f28-b72e-9f93d459aac2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_GAMMA_CONTROL_CAPABILITIES
	{
		/// <summary>
		/// [out] A BOOL value that indicates whether the device supports scale and offset. <c>TRUE</c> indicates that the device
		/// supports scale and offset; <c>FALSE</c> indicates that the device does not support scale and offset.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool ScaleAndOffsetSupported;

		/// <summary>[out] A single-precision float vector for the maximum converted value for the gamma control.</summary>
		public float MaxConvertedValue;

		/// <summary>[out] A single-precision float vector for the minimum converted value for the gamma control.</summary>
		public float MinConvertedValue;

		/// <summary>[out] The number of elements in the array that the <c>ControlPointPositions</c> member specifies.</summary>
		public uint NumGammaControlPoints;

		/// <summary>[out] An array of single-precision float vectors that describe the gamma control point positions.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)]
		public float[] ControlPointPositions;
	}

	/// <summary>Describes a mapped rectangle that is used to access a surface.</summary>
	/// <remarks>The <c>DXGI_MAPPED_RECT</c> structure is initialized by the IDXGISurface::Map method.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_mapped_rect typedef struct DXGI_MAPPED_RECT { INT Pitch;
	// BYTE *pBits; } DXGI_MAPPED_RECT;
	[PInvokeData("dxgi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_MAPPED_RECT
	{
		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>A value that describes the width, in bytes, of the surface.</para>
		/// </summary>
		public int Pitch;

		/// <summary>
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the image buffer of the surface.</para>
		/// </summary>
		public IntPtr pBits;
	}

	/// <summary>Describes a display mode.</summary>
	/// <remarks>
	/// <para>This structure is used by the <c>GetDisplayModeList</c> and <c>FindClosestMatchingMode</c> methods.</para>
	/// <para>
	/// The following format values are valid for display modes and when you create a bit-block transfer (bitblt) model swap chain. The
	/// valid values depend on the feature level that you are working with.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>
	/// You can pass one of these format values to <c>ID3D11Device::CheckFormatSupport</c> to determine if it is a valid format for
	/// displaying on screen. If <c>ID3D11Device::CheckFormatSupport</c> returns <c>D3D11_FORMAT_SUPPORT_DISPLAY</c> in the bit field to
	/// which the pFormatSupport parameter points, the format is valid for displaying on screen.
	/// </para>
	/// <para>
	/// Starting with Windows 8 for a flip model swap chain (that is, a swap chain that has the <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c>
	/// value set in the <c>SwapEffect</c> member of <c>DXGI_SWAP_CHAIN_DESC</c>), you must set the <c>Format</c> member of
	/// <c>DXGI_MODE_DESC</c> to <c>DXGI_FORMAT_R16G16B16A16_FLOAT</c>, <c>DXGI_FORMAT_B8G8R8A8_UNORM</c>, or <c>DXGI_FORMAT_R8G8B8A8_UNORM</c>.
	/// </para>
	/// <para>
	/// Because of the relaxed render target creation rules that Direct3D 11 has for back buffers, applications can create a
	/// <c>DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</c> render target view from a <c>DXGI_FORMAT_B8G8R8A8_UNORM</c> swap chain so they can use
	/// automatic color space conversion when they render the swap chain.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173064(v=vs.85) typedef struct DXGI_MODE_DESC { UINT
	// Width; UINT Height; DXGI_RATIONAL RefreshRate; DXGI_FORMAT Format; DXGI_MODE_SCANLINE_ORDER ScanlineOrdering; DXGI_MODE_SCALING
	// Scaling; } DXGI_MODE_DESC;
	[PInvokeData("DXGI.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_MODE_DESC
	{
		/// <summary>
		/// A value that describes the resolution width. If you specify the width as zero when you call the
		/// IDXGIFactory::CreateSwapChain method to create a swap chain, the runtime obtains the width from the output window and
		/// assigns this width value to the swap-chain description. You can subsequently call the IDXGISwapChain::GetDesc method to
		/// retrieve the assigned width value.
		/// </summary>
		public uint Width;

		/// <summary>
		/// A value describing the resolution height. If you specify the height as zero when you call the IDXGIFactory::CreateSwapChain
		/// method to create a swap chain, the runtime obtains the height from the output window and assigns this height value to the
		/// swap-chain description. You can subsequently call the IDXGISwapChain::GetDesc method to retrieve the assigned height value.
		/// </summary>
		public uint Height;

		/// <summary>A DXGI_RATIONAL structure describing the refresh rate in hertz</summary>
		public DXGI_RATIONAL RefreshRate;

		/// <summary>A DXGI_FORMAT structure describing the display format.</summary>
		public DXGI_FORMAT Format;

		/// <summary>A member of the DXGI_MODE_SCANLINE_ORDER enumerated type describing the scanline drawing mode.</summary>
		public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;

		/// <summary>A member of the DXGI_MODE_SCALING enumerated type describing the scaling mode.</summary>
		public DXGI_MODE_SCALING Scaling;
	}

	/// <summary>Describes an output or physical connection between the adapter (video card) and a device.</summary>
	/// <remarks>The <c>DXGI_OUTPUT_DESC</c> structure is initialized by the IDXGIOutput::GetDesc method.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_output_desc typedef struct DXGI_OUTPUT_DESC { WCHAR
	// DeviceName[32]; RECT DesktopCoordinates; BOOL AttachedToDesktop; DXGI_MODE_ROTATION Rotation; HMONITOR Monitor; } DXGI_OUTPUT_DESC;
	[PInvokeData("dxgi.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DXGI_OUTPUT_DESC
	{
		/// <summary>
		/// <para>Type: <c>WCHAR[32]</c></para>
		/// <para>A string that contains the name of the output device.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string DeviceName;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>
		/// A RECT structure containing the bounds of the output in desktop coordinates. Desktop coordinates depend on the dots per inch
		/// (DPI) of the desktop. For info about writing DPI-aware Win32 apps, see High DPI.
		/// </para>
		/// </summary>
		public RECT DesktopCoordinates;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the output is attached to the desktop; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AttachedToDesktop;

		/// <summary>
		/// <para>Type: <c>DXGI_MODE_ROTATION</c></para>
		/// <para>A member of the DXGI_MODE_ROTATION enumerated type describing on how an image is rotated by the output.</para>
		/// </summary>
		public DXGI_MODE_ROTATION Rotation;

		/// <summary>
		/// <para>Type: <c>HMONITOR</c></para>
		/// <para>An HMONITOR handle that represents the display monitor. For more information, see HMONITOR and the Device Context.</para>
		/// </summary>
		public HMONITOR Monitor;
	}

	/// <summary>Represents a rational number.</summary>
	/// <remarks>
	/// <para>This structure is a member of the DXGI_MODE_DESC structure.</para>
	/// <para>The <c>DXGI_RATIONAL</c> structure operates under the following rules:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>0/0 is legal and will be interpreted as 0/1.</term>
	/// </item>
	/// <item>
	/// <term>0/anything is interpreted as zero.</term>
	/// </item>
	/// <item>
	/// <term>If you are representing a whole number, the denominator should be 1.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_rational typedef struct DXGI_RATIONAL { UINT
	// Numerator; UINT Denominator; } DXGI_RATIONAL;
	[PInvokeData("dxgicommon.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_RATIONAL
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>An unsigned integer value representing the top of the rational number.</para>
		/// </summary>
		public uint Numerator;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>An unsigned integer value representing the bottom of the rational number.</para>
		/// </summary>
		public uint Denominator;
	}

	/// <summary>Represents an RGB color.</summary>
	/// <remarks>This structure is a member of the <c>DXGI_GAMMA_CONTROL</c> structure.</remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173071(v=vs.85) typedef struct DXGI_RGB { float Red;
	// float Green; float Blue; } DXGI_RGB;
	[PInvokeData("DXGI.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_RGB
	{
		/// <summary>A value representing the color of the red component. The range of this value is between 0 and 1.</summary>
		public float Red;

		/// <summary>A value representing the color of the green component. The range of this value is between 0 and 1.</summary>
		public float Green;

		/// <summary>A value representing the color of the blue component. The range of this value is between 0 and 1.</summary>
		public float Blue;
	}

	/// <summary>Describes multi-sampling parameters for a resource.</summary>
	/// <remarks>
	/// <para>This structure is a member of the DXGI_SWAP_CHAIN_DESC1 structure.</para>
	/// <para>The default sampler mode, with no anti-aliasing, has a count of 1 and a quality level of 0.</para>
	/// <para>
	/// If multi-sample antialiasing is being used, all bound render targets and depth buffers must have the same sample counts and
	/// quality levels.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>
	/// Differences between Direct3D 10.0 and Direct3D 10.1 and between Direct3D 10.0 and Direct3D 11: Direct3D 10.1 has defined two
	/// standard quality levels: D3D10_STANDARD_MULTISAMPLE_PATTERN and D3D10_CENTER_MULTISAMPLE_PATTERN in the
	/// D3D10_STANDARD_MULTISAMPLE_QUALITY_LEVELS enumeration in D3D10_1.h. Direct3D 11 has defined two standard quality levels:
	/// D3D11_STANDARD_MULTISAMPLE_PATTERN and D3D11_CENTER_MULTISAMPLE_PATTERN in the D3D11_STANDARD_MULTISAMPLE_QUALITY_LEVELS
	/// enumeration in D3D11.h.
	/// </term>
	/// </listheader>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc typedef struct DXGI_SAMPLE_DESC {
	// UINT Count; UINT Quality; } DXGI_SAMPLE_DESC;
	[PInvokeData("dxgicommon.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_SAMPLE_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of multisamples per pixel.</para>
		/// </summary>
		public uint Count;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The image quality level. The higher the quality, the lower the performance. The valid range is between zero and one less
		/// than the level returned by ID3D10Device::CheckMultisampleQualityLevels for Direct3D 10 or
		/// ID3D11Device::CheckMultisampleQualityLevels for Direct3D 11.
		/// </para>
		/// <para>
		/// For Direct3D 10.1 and Direct3D 11, you can use two special quality level values. For more information about these quality
		/// level values, see Remarks.
		/// </para>
		/// </summary>
		public uint Quality;
	}

	/// <summary>Represents a handle to a shared resource.</summary>
	/// <remarks>To create a shared surface, pass a shared-resource handle into the IDXGIDevice::CreateSurface method.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_shared_resource typedef struct DXGI_SHARED_RESOURCE { HANDLE
	// Handle; } DXGI_SHARED_RESOURCE;
	[PInvokeData("dxgi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_SHARED_RESOURCE
	{
		/// <summary>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to a shared resource.</para>
		/// </summary>
		public HANDLE Handle;
	}

	/// <summary>Describes a surface.</summary>
	/// <remarks>This structure is used by the GetDesc and CreateSurface methods.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_surface_desc typedef struct DXGI_SURFACE_DESC { UINT Width;
	// UINT Height; DXGI_FORMAT Format; DXGI_SAMPLE_DESC SampleDesc; } DXGI_SURFACE_DESC;
	[PInvokeData("dxgi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_SURFACE_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>A value describing the surface width.</para>
		/// </summary>
		public uint Width;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>A value describing the surface height.</para>
		/// </summary>
		public uint Height;

		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>A member of the DXGI_FORMAT enumerated type that describes the surface format.</para>
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// <para>Type: <c>DXGI_SAMPLE_DESC</c></para>
		/// <para>A member of the DXGI_SAMPLE_DESC structure that describes multi-sampling parameters for the surface.</para>
		/// </summary>
		public DXGI_SAMPLE_DESC SampleDesc;
	}

	/// <summary>Describes a swap chain.</summary>
	/// <remarks>
	/// <para>This structure is used by the GetDesc and CreateSwapChain methods.</para>
	/// <para>In full-screen mode, there is a dedicated front buffer; in windowed mode, the desktop is the front buffer.</para>
	/// <para>
	/// If you create a swap chain with one buffer, specifying <c>DXGI_SWAP_EFFECT_SEQUENTIAL</c> does not cause the contents of the
	/// single buffer to be swapped with the front buffer.
	/// </para>
	/// <para>
	/// For performance information about flipping swap-chain buffers in full-screen application, see Full-Screen Application
	/// Performance Hints.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc typedef struct DXGI_SWAP_CHAIN_DESC {
	// DXGI_MODE_DESC BufferDesc; DXGI_SAMPLE_DESC SampleDesc; DXGI_USAGE BufferUsage; UINT BufferCount; HWND OutputWindow; BOOL
	// Windowed; DXGI_SWAP_EFFECT SwapEffect; UINT Flags; } DXGI_SWAP_CHAIN_DESC;
	[PInvokeData("dxgi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_SWAP_CHAIN_DESC
	{
		/// <summary>
		/// <para>Type: <c>DXGI_MODE_DESC</c></para>
		/// <para>A DXGI_MODE_DESC structure that describes the backbuffer display mode.</para>
		/// </summary>
		public DXGI_MODE_DESC BufferDesc;

		/// <summary>
		/// <para>Type: <c>DXGI_SAMPLE_DESC</c></para>
		/// <para>A DXGI_SAMPLE_DESC structure that describes multi-sampling parameters.</para>
		/// </summary>
		public DXGI_SAMPLE_DESC SampleDesc;

		/// <summary>
		/// <para>Type: <c>DXGI_USAGE</c></para>
		/// <para>
		/// A member of the DXGI_USAGE enumerated type that describes the surface usage and CPU access options for the back buffer. The
		/// back buffer can be used for shader input or render-target output.
		/// </para>
		/// </summary>
		public DXGI_USAGE BufferUsage;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value that describes the number of buffers in the swap chain. When you call IDXGIFactory::CreateSwapChain to create a
		/// full-screen swap chain, you typically include the front buffer in this value. For more information about swap-chain buffers,
		/// see Remarks.
		/// </para>
		/// </summary>
		public uint BufferCount;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>An HWND handle to the output window. This member must not be <c>NULL</c>.</para>
		/// </summary>
		public HWND OutputWindow;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean value that specifies whether the output is in windowed mode. <c>TRUE</c> if the output is in windowed mode;
		/// otherwise, <c>FALSE</c>.
		/// </para>
		/// <para>
		/// We recommend that you create a windowed swap chain and allow the end user to change the swap chain to full screen through
		/// IDXGISwapChain::SetFullscreenState; that is, do not set this member to FALSE to force the swap chain to be full screen.
		/// However, if you create the swap chain as full screen, also provide the end user with a list of supported display modes
		/// through the <c>BufferDesc</c> member because a swap chain that is created with an unsupported display mode might cause the
		/// display to go black and prevent the end user from seeing anything.
		/// </para>
		/// <para>For more information about choosing windowed verses full screen, see IDXGIFactory::CreateSwapChain.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Windowed;

		/// <summary>
		/// <para>Type: <c>DXGI_SWAP_EFFECT</c></para>
		/// <para>
		/// A member of the DXGI_SWAP_EFFECT enumerated type that describes options for handling the contents of the presentation buffer
		/// after presenting a surface.
		/// </para>
		/// </summary>
		public DXGI_SWAP_EFFECT SwapEffect;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>A member of the DXGI_SWAP_CHAIN_FLAG enumerated type that describes options for swap-chain behavior.</para>
		/// </summary>
		public DXGI_SWAP_CHAIN_FLAG Flags;
	}
}