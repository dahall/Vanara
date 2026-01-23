using System.Drawing;

namespace Vanara.PInvoke;

public static partial class DXGI
{
	/// <summary>Feature level 9_1 anisotropic filtering maxanisotropy default</summary>
	public const int D3D_FL9_1_DEFAULT_MAX_ANISOTROPY = 2;

	/// <summary>Feature level 9_1 maximum input assembler primitives</summary>
	public const int D3D_FL9_1_IA_PRIMITIVE_MAX_COUNT = 65535;

	/// <summary>Feature level 9_1 maximum texture repeat</summary>
	public const int D3D_FL9_1_MAX_TEXTURE_REPEAT = 128;

	/// <summary>Feature level 9_1 texture1D U dimension</summary>
	public const int D3D_FL9_1_REQ_TEXTURE1D_U_DIMENSION = 2048;

	/// <summary>Feature level 9_1 texture2D U/V dimension</summary>
	public const int D3D_FL9_1_REQ_TEXTURE2D_U_OR_V_DIMENSION = 2048;

	/// <summary>Feature level 9_1 texture3D U/V/W dimension</summary>
	public const int D3D_FL9_1_REQ_TEXTURE3D_U_V_OR_W_DIMENSION = 256;

	/// <summary>Feature level 9_1 textureCube dimension</summary>
	public const int D3D_FL9_1_REQ_TEXTURECUBE_DIMENSION = 512;

	/// <summary>Feature level 9_1 simultaneous render targets</summary>
	public const int D3D_FL9_1_SIMULTANEOUS_RENDER_TARGET_COUNT = 1;

	/// <summary>Feature level 9_2 maximum input assembler primitives</summary>
	public const int D3D_FL9_2_IA_PRIMITIVE_MAX_COUNT = 1048575;

	/// <summary>Feature level 9_2 maximum texture repeat</summary>
	public const int D3D_FL9_2_MAX_TEXTURE_REPEAT = 2048;

	/// <summary>Feature level 9_3 maximum texture repeat</summary>
	public const int D3D_FL9_3_MAX_TEXTURE_REPEAT = 8192;

	/// <summary>Feature level 9_3 texture1D U dimension</summary>
	public const int D3D_FL9_3_REQ_TEXTURE1D_U_DIMENSION = 4096;

	/// <summary>Feature level 9_3 texture2D U/V dimension</summary>
	public const int D3D_FL9_3_REQ_TEXTURE2D_U_OR_V_DIMENSION = 4096;

	/// <summary>Feature level 9_3 textureCube dimension</summary>
	public const int D3D_FL9_3_REQ_TEXTURECUBE_DIMENSION = 4096;

	/// <summary>Feature level 9_3 simultaneous render targets</summary>
	public const int D3D_FL9_3_SIMULTANEOUS_RENDER_TARGET_COUNT = 4;

	/// <summary/>
	public static readonly Guid D3D_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE = new(0x4c0f29e3, 0x3f5f, 0x4d35, 0x84, 0xc9, 0xbc, 0x09, 0x83, 0xb6, 0x2c, 0x28);

	/// <summary/>
	public static readonly Guid D3D_TEXTURE_LAYOUT_ROW_MAJOR = new(0xb5dc234f, 0x72bb, 0x4bec, 0x97, 0x05, 0x8c, 0xf2, 0x58, 0xdf, 0x6b, 0x6c);

	/// <summary/>
	public static readonly Guid WKPDID_CommentStringW = new(0xd0149dc0, 0x90e8, 0x4ec8, 0x81, 0x44, 0xe9, 0x00, 0xad, 0x26, 0x6b, 0xb2);

	/// <summary/>
	public static readonly Guid WKPDID_D3D12UniqueObjectId = new(0x1b39de15, 0xec04, 0x4bae, 0xba, 0x4d, 0x8c, 0xef, 0x79, 0xfc, 0x04, 0xc1);

	/// <summary/>
	public static readonly Guid WKPDID_D3DDebugObjectName = new(0x429b8c22, 0x9188, 0x4b0c, 0x87, 0x42, 0xac, 0xb0, 0xbf, 0x85, 0xc2, 0x00);

	/// <summary/>
	public static readonly Guid WKPDID_D3DDebugObjectNameW = new(0x4cca5fd8, 0x921f, 0x42c8, 0x85, 0x66, 0x70, 0xca, 0xf2, 0xa9, 0xb7, 0x41);

	/// <summary>A user-defined callback to be invoked when the object is destroyed.</summary>
	/// <param name="pData">The data passed to callbackFn when invoked.</param>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void PFN_DESTRUCTION_CALLBACK(IntPtr pData);

	/// <summary>Specifies how the alpha value of a bitmap or render target should be treated.</summary>
	/// <remarks>
	/// <para>
	/// The <c>D2D1_ALPHA_MODE</c> enumeration is used with the D2D1_PIXEL_FORMAT enumeration to specify the alpha mode of a render
	/// target or bitmap. Different render targets and bitmaps support different alpha modes. For a list, see Supported Pixel Formats
	/// and Alpha Modes.
	/// </para>
	/// <para>The Differences Between Straight and Premultiplied Alpha</para>
	/// <para>
	/// When describing an RGBA color using straight alpha, the alpha value of the color is stored in the alpha channel. For example, to
	/// describe a red color that is 60% opaque, you'd use the following values: (255, 0, 0, 255 * 0.6) = (255, 0, 0, 153). The 255
	/// value indicates full red, and 153 (which is 60 percent of 255) indicates that the color should have an opacity of 60 percent.
	/// </para>
	/// <para>
	/// When describing an RGBA color using premultiplied alpha, each color is multiplied by the alpha value: (255 * 0.6, 0 * 0.6, 0 *
	/// 0.6, 255 * 0.6) = (153, 0, 0, 153).
	/// </para>
	/// <para>
	/// Regardless of the alpha mode of the render target, D2D1_COLOR_F values are always interpreted as straight alpha. For example,
	/// when specifying the color of an ID2D1SolidColorBrush for use with a bitmap that uses the premultiplied alpha mode, you'd specify
	/// the color just as you would if the bitmap used straight alpha. When you paint with the brush, Direct2D translates the color to
	/// the destination format for you.
	/// </para>
	/// <para>Alpha Mode for Render Targets</para>
	/// <para>
	/// Regardless of the alpha mode setting, a render target's contents support transparency. For example, if you draw a partially
	/// transparent red rectangle with a render target with an alpha mode of <c>D2D1_ALPHA_MODE_IGNORE</c>, the rectangle will appear
	/// pink (if the background is white), as you might expect.
	/// </para>
	/// <para>
	/// If you draw a partially transparent red rectangle when the alpha mode is CreateCompatibleRenderTarget method) to create a bitmap
	/// that supports transparency.
	/// </para>
	/// <para>ClearType and Alpha Modes</para>
	/// <para>
	/// If you specify an alpha mode other than <c>D2D1_ALPHA_MODE_IGNORE</c> for a render target, the text antialiasing mode
	/// automatically changes from D2D1_TEXT_ANTIALIAS_MODE CLEARTYPE to <c>D2D1_TEXT_ANTIALIAS_MODE GRAYSCALE</c>. (When you specify an
	/// alpha mode of <c>D2D1_ALPHA_MODE_UNKNOWN</c>, Direct2D sets the alpha for you depending on the type of render target. For a list
	/// of what the <c>D2D1_ALPHA_MODE_UNKNOWN</c> setting resolves to for each render target, see the Supported Pixel Formats and Alpha
	/// Modes overview.)
	/// </para>
	/// <para>
	/// You can use the SetTextAntialiasMode method to change the text antialias mode back to D2D1_TEXT_ANTIALIAS_MODE CLEARTYPE, but
	/// rendering ClearType text to a transparent surface can create unpredictable results. If you want to render ClearType text to an
	/// transparent render target, we recommend that you use one of the following two techniques.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Use the PushAxisAlignedClip method to clip the render target to the area where the text will be rendered, then call the Clear
	/// method and specify an opaque color, then render your text.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Use DrawRectangle to draw an opaque rectangle behind the area where the text will be rendered.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ne-dcommon-d2d1_alpha_mode typedef enum D2D1_ALPHA_MODE {
	// D2D1_ALPHA_MODE_UNKNOWN, D2D1_ALPHA_MODE_PREMULTIPLIED, D2D1_ALPHA_MODE_STRAIGHT, D2D1_ALPHA_MODE_IGNORE,
	// D2D1_ALPHA_MODE_FORCE_DWORD } ;
	[PInvokeData("dcommon.h", MSDNShortId = "f1b1e735-2e89-4dc1-9fee-dfb4626ef453")]
	public enum D2D1_ALPHA_MODE : uint
	{
		/// <summary>The alpha value might not be meaningful.</summary>
		D2D1_ALPHA_MODE_UNKNOWN,

		/// <summary>
		/// The alpha value has been premultiplied. Each color is first scaled by the alpha value. The alpha value itself is the same in
		/// both straight and premultiplied alpha. Typically, no color channel value is greater than the alpha channel value. If a color
		/// channel value in a premultiplied format is greater than the alpha channel, the standard source-over blending math results in
		/// an additive blend.
		/// </summary>
		D2D1_ALPHA_MODE_PREMULTIPLIED,

		/// <summary>The alpha value has not been premultiplied. The alpha channel indicates the transparency of the color.</summary>
		D2D1_ALPHA_MODE_STRAIGHT,

		/// <summary>The alpha value is ignored.</summary>
		D2D1_ALPHA_MODE_IGNORE,

		/// <summary/>
		D2D1_ALPHA_MODE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>
	/// <para>Values that identify the intended use of constant-buffer data.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_cbuffer_type typedef enum D3D_CBUFFER_TYPE {
	// D3D_CT_CBUFFER = 0, D3D_CT_TBUFFER, D3D_CT_INTERFACE_POINTERS, D3D_CT_RESOURCE_BIND_INFO, D3D10_CT_CBUFFER, D3D10_CT_TBUFFER,
	// D3D11_CT_CBUFFER, D3D11_CT_TBUFFER, D3D11_CT_INTERFACE_POINTERS, D3D11_CT_RESOURCE_BIND_INFO } D3D_CBUFFER_TYPE;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_CBUFFER_TYPE")]
	public enum D3D_CBUFFER_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A buffer containing scalar constants.</para>
		/// </summary>
		D3D_CT_CBUFFER = 0,

		/// <summary>A buffer containing texture data.</summary>
		D3D_CT_TBUFFER,

		/// <summary>A buffer containing interface pointers.</summary>
		D3D_CT_INTERFACE_POINTERS,

		/// <summary>A buffer containing binding information.</summary>
		D3D_CT_RESOURCE_BIND_INFO,

		/// <summary>A buffer containing scalar constants.</summary>
		D3D10_CT_CBUFFER,

		/// <summary>A buffer containing texture data.</summary>
		D3D10_CT_TBUFFER,

		/// <summary>A buffer containing scalar constants.</summary>
		D3D11_CT_CBUFFER,

		/// <summary>A buffer containing texture data.</summary>
		D3D11_CT_TBUFFER,

		/// <summary>A buffer containing interface pointers.</summary>
		D3D11_CT_INTERFACE_POINTERS,

		/// <summary>A buffer containing binding information.</summary>
		D3D11_CT_RESOURCE_BIND_INFO,
	}

	/// <summary/>
	[PInvokeData("d3dcommon.h"), Flags]
	public enum D3D_COMPONENT_MASK
	{
		/// <summary/>
		D3D_COMPONENT_MASK_X = 1,

		/// <summary/>
		D3D_COMPONENT_MASK_Y = 2,

		/// <summary/>
		D3D_COMPONENT_MASK_Z = 4,

		/// <summary/>
		D3D_COMPONENT_MASK_W = 8,
	}

	/// <summary>
	/// <para>Driver type options.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	/// <remarks>The driver type is required when calling D3D11CreateDevice or D3D11CreateDeviceAndSwapChain.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_driver_type typedef enum D3D_DRIVER_TYPE {
	// D3D_DRIVER_TYPE_UNKNOWN = 0, D3D_DRIVER_TYPE_HARDWARE, D3D_DRIVER_TYPE_REFERENCE, D3D_DRIVER_TYPE_NULL, D3D_DRIVER_TYPE_SOFTWARE,
	// D3D_DRIVER_TYPE_WARP } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_DRIVER_TYPE")]
	public enum D3D_DRIVER_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The driver type is unknown.</para>
		/// </summary>
		D3D_DRIVER_TYPE_UNKNOWN = 0,

		/// <summary>
		/// A hardware driver, which implements Direct3D features in hardware. This is the primary driver that you should use in your
		/// Direct3D applications because it provides the best performance. A hardware driver uses hardware acceleration (on supported
		/// hardware) but can also use software for parts of the pipeline that are not supported in hardware. This driver type is often
		/// referred to as a hardware abstraction layer or HAL.
		/// </summary>
		D3D_DRIVER_TYPE_HARDWARE,

		/// <summary>
		/// <para>
		/// A reference driver, which is a software implementation that supports every Direct3D feature. A reference driver is designed for
		/// accuracy rather than speed and as a result is slow but accurate. The rasterizer portion of the driver does make use of special
		/// CPU instructions whenever it can, but it is not intended for retail applications; use it only for feature testing, demonstration
		/// of functionality, debugging, or verifying bugs in other drivers. The reference device for this driver is installed by the
		/// Windows SDK 8.0 or later and is intended only as a debug aid for development purposes. This driver may be referred to as a REF
		/// driver, a reference driver, or a reference rasterizer.
		/// </para>
		/// <para>
		/// <c>Note</c>  When you use the REF driver in Windows Store apps, the REF driver renders correctly but doesn't display any output
		/// on the screen. To verify bugs in hardware drivers for Windows Store apps, use D3D_DRIVER_TYPE_WARP for the WARP driver instead.
		/// </para>
		/// <para></para>
		/// </summary>
		D3D_DRIVER_TYPE_REFERENCE,

		/// <summary>
		/// A NULL driver, which is a reference driver without render capability. This driver is commonly used for debugging non-rendering
		/// API calls, it is not appropriate for retail applications. This driver is installed by the DirectX SDK.
		/// </summary>
		D3D_DRIVER_TYPE_NULL,

		/// <summary>
		/// A software driver, which is a driver implemented completely in software. The software implementation is not intended for a
		/// high-performance application due to its very slow performance.
		/// </summary>
		D3D_DRIVER_TYPE_SOFTWARE,

		/// <summary>
		/// <para>A WARP driver, which is a high-performance software rasterizer. The rasterizer supports</para>
		/// <para>feature levels</para>
		/// <para>
		/// 9_1 through level 10_1 with a high performance software implementation. For information about limitations creating a WARP device
		/// on certain feature levels, see
		/// </para>
		/// <para>Limitations Creating WARP and Reference Devices</para>
		/// <para>. For more information about using a WARP driver, see</para>
		/// <para>Windows Advanced Rasterization Platform (WARP) In-Depth Guide</para>
		/// <para>.</para>
		/// <para><c>Note</c>  The WARP driver that Windows 8 includes supports feature levels 9_1 through level 11_1.</para>
		/// <para></para>
		/// <para>
		/// <c>Note</c>  The WARP driver that Windows 8.1 includes fully supports feature level 11_1, including tiled resources,
		/// IDXGIDevice3::Trim, shared BCn surfaces, minblend, and map default.
		/// </para>
		/// <para></para>
		/// </summary>
		D3D_DRIVER_TYPE_WARP,
	}

	/// <summary>Describes the set of features targeted by a Direct3D device.</summary>
	/// <remarks>
	/// <para>For an overview of the capabilities of each feature level, see Direct3D feature levels.</para>
	/// <para>
	/// For information about limitations creating non-hardware-type devices on certain feature levels, see Limitations creating WARP and
	/// reference devices.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_feature_level typedef enum D3D_FEATURE_LEVEL {
	// D3D_FEATURE_LEVEL_1_0_GENERIC, D3D_FEATURE_LEVEL_1_0_CORE, D3D_FEATURE_LEVEL_9_1, D3D_FEATURE_LEVEL_9_2, D3D_FEATURE_LEVEL_9_3,
	// D3D_FEATURE_LEVEL_10_0, D3D_FEATURE_LEVEL_10_1, D3D_FEATURE_LEVEL_11_0, D3D_FEATURE_LEVEL_11_1, D3D_FEATURE_LEVEL_12_0,
	// D3D_FEATURE_LEVEL_12_1, D3D_FEATURE_LEVEL_12_2 } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_FEATURE_LEVEL")]
	public enum D3D_FEATURE_LEVEL
	{
		/// <summary/>
		D3D_FEATURE_LEVEL_1_0_GENERIC = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x1000)</para>
		/// <para>
		/// Allows Microsoft Compute Driver Model (MCDM) devices to be used, or more feature-rich devices (such as traditional GPUs) that
		/// support a superset of the functionality. MCDM is the overall driver model for compute-only; it's a scaled-down peer of the
		/// larger scoped Windows Device Driver Model (WDDM).
		/// </para>
		/// </summary>
		D3D_FEATURE_LEVEL_1_0_CORE = 0x1000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x9100)</para>
		/// <para>Targets features supported by</para>
		/// <para>feature level</para>
		/// <para>9.1, including shader model 2.</para>
		/// </summary>
		D3D_FEATURE_LEVEL_9_1 = 0x9100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x9200)</para>
		/// <para>Targets features supported by</para>
		/// <para>feature level</para>
		/// <para>9.2, including shader model 2.</para>
		/// </summary>
		D3D_FEATURE_LEVEL_9_2 = 0x9200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x9300)</para>
		/// <para>Targets features supported by</para>
		/// <para>feature level</para>
		/// <para>9.3, including shader model 2.0b.</para>
		/// </summary>
		D3D_FEATURE_LEVEL_9_3 = 0x9300,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0xa000)</para>
		/// <para>Targets features supported by Direct3D 10.0, including shader model 4.</para>
		/// </summary>
		D3D_FEATURE_LEVEL_10_0 = 0xa000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0xa100)</para>
		/// <para>Targets features supported by Direct3D 10.1, including shader model 4.</para>
		/// </summary>
		D3D_FEATURE_LEVEL_10_1 = 0xa100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0xb000)</para>
		/// <para>Targets features supported by Direct3D 11.0, including shader model 5.</para>
		/// </summary>
		D3D_FEATURE_LEVEL_11_0 = 0xb000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0xb100)</para>
		/// <para>
		/// Targets features supported by Direct3D 11.1, including shader model 5 and logical blend operations. This feature level requires
		/// a display driver that is at least implemented to WDDM for Windows 8 (WDDM 1.2).
		/// </para>
		/// </summary>
		D3D_FEATURE_LEVEL_11_1 = 0xb100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0xc000)</para>
		/// <para>Targets features supported by Direct3D 12.0, including shader model 5.</para>
		/// </summary>
		D3D_FEATURE_LEVEL_12_0 = 0xc000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0xc100)</para>
		/// <para>Targets features supported by Direct3D 12.1, including shader model 5.</para>
		/// </summary>
		D3D_FEATURE_LEVEL_12_1 = 0xc100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0xc200)</para>
		/// <para>
		/// Targets features supported by Direct3D 12.2, including shader model 6.5. For more information about feature level 12_2, see its
		/// </para>
		/// <para>specification page</para>
		/// <para>. Feature level 12_2 is available in Windows SDK builds 20170 and later.</para>
		/// </summary>
		D3D_FEATURE_LEVEL_12_2 = 0xc200,
	}

	/// <summary/>
	[PInvokeData("d3dcommon.h")]
	public enum D3D_FORMAT_COMPONENT_INTERPRETATION
	{
		/// <summary/>
		D3DFCI_TYPELESS,

		/// <summary/>
		D3DFCI_FLOAT = -4,

		/// <summary/>
		D3DFCI_SNORM = -3,

		/// <summary/>
		D3DFCI_UNORM = -2,

		/// <summary/>
		D3DFCI_SINT = -1,

		/// <summary/>
		D3DFCI_UINT = 1,

		/// <summary/>
		D3DFCI_UNORM_SRGB = 2,

		/// <summary/>
		D3DFCI_BIASED_FIXED_2_8 = 3
	}

	/// <summary/>
	[PInvokeData("d3dcommon.h")]
	public enum D3D_FORMAT_COMPONENT_NAME
	{
		/// <summary/>
		D3DFCN_R = -4,

		/// <summary/>
		D3DFCN_G = -3,

		/// <summary/>
		D3DFCN_B = -2,

		/// <summary/>
		D3DFCN_A = -1,

		/// <summary/>
		D3DFCN_D,

		/// <summary/>
		D3DFCN_S = 1,

		/// <summary/>
		D3DFCN_X = 2
	}

	/// <summary/>
	[PInvokeData("d3dcommon.h")]
	public enum D3D_FORMAT_LAYOUT
	{
		/// <summary/>
		D3DFL_STANDARD,

		/// <summary/>
		D3DFL_CUSTOM = -1
	}

	/// <summary/>
	[PInvokeData("d3dcommon.h")]
	public enum D3D_FORMAT_TYPE_LEVEL
	{
		/// <summary/>
		D3DFTL_NO_TYPE,

		/// <summary/>
		D3DFTL_PARTIAL_TYPE = -2,

		/// <summary/>
		D3DFTL_FULL_TYPE = -1
	}

	/// <summary>
	/// <para>Values that indicate the location of a shader #include file.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	/// <remarks>
	/// You pass a <c>D3D_INCLUDE_TYPE</c>-typed value to the <c>IncludeType</c> parameter in a call to the ID3DInclude::Open method to
	/// indicate the location of the #include file.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_include_type typedef enum D3D_INCLUDE_TYPE {
	// D3D_INCLUDE_LOCAL = 0, D3D_INCLUDE_SYSTEM, D3D10_INCLUDE_LOCAL, D3D10_INCLUDE_SYSTEM, D3D_INCLUDE_FORCE_DWORD = 0x7fffffff } D3D_INCLUDE_TYPE;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_INCLUDE_TYPE")]
	public enum D3D_INCLUDE_TYPE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The local directory.</para>
		/// </summary>
		D3D_INCLUDE_LOCAL = 0,

		/// <summary>The system directory.</summary>
		D3D_INCLUDE_SYSTEM,

		/// <summary>The local directory.</summary>
		D3D10_INCLUDE_LOCAL,

		/// <summary>The system directory.</summary>
		D3D10_INCLUDE_SYSTEM,
	}

	/// <summary>Specifies interpolation mode, which affects how values are calculated during rasterization.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_interpolation_mode typedef enum D3D_INTERPOLATION_MODE
	// { D3D_INTERPOLATION_UNDEFINED = 0, D3D_INTERPOLATION_CONSTANT = 1, D3D_INTERPOLATION_LINEAR = 2, D3D_INTERPOLATION_LINEAR_CENTROID =
	// 3, D3D_INTERPOLATION_LINEAR_NOPERSPECTIVE = 4, D3D_INTERPOLATION_LINEAR_NOPERSPECTIVE_CENTROID = 5, D3D_INTERPOLATION_LINEAR_SAMPLE =
	// 6, D3D_INTERPOLATION_LINEAR_NOPERSPECTIVE_SAMPLE = 7 } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_INTERPOLATION_MODE")]
	public enum D3D_INTERPOLATION_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The interpolation mode is undefined.</para>
		/// </summary>
		D3D_INTERPOLATION_UNDEFINED = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Don't interpolate between register values.</para>
		/// </summary>
		D3D_INTERPOLATION_CONSTANT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Interpolate linearly between register values.</para>
		/// </summary>
		D3D_INTERPOLATION_LINEAR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Interpolate linearly between register values but centroid clamped when multisampling.</para>
		/// </summary>
		D3D_INTERPOLATION_LINEAR_CENTROID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Interpolate linearly between register values but with no perspective correction.</para>
		/// </summary>
		D3D_INTERPOLATION_LINEAR_NOPERSPECTIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Interpolate linearly between register values but with no perspective correction and centroid clamped when multisampling.</para>
		/// </summary>
		D3D_INTERPOLATION_LINEAR_NOPERSPECTIVE_CENTROID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Interpolate linearly between register values but sample clamped when multisampling.</para>
		/// </summary>
		D3D_INTERPOLATION_LINEAR_SAMPLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Interpolate linearly between register values but with no perspective correction and sample clamped when multisampling.</para>
		/// </summary>
		D3D_INTERPOLATION_LINEAR_NOPERSPECTIVE_SAMPLE,
	}

	/// <summary>Values that indicate the minimum desired interpolation precision.</summary>
	/// <remarks>For more info, see Scalar Types and Using HLSL minimum precision.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_min_precision typedef enum D3D_MIN_PRECISION {
	// D3D_MIN_PRECISION_DEFAULT = 0, D3D_MIN_PRECISION_FLOAT_16 = 1, D3D_MIN_PRECISION_FLOAT_2_8 = 2, D3D_MIN_PRECISION_RESERVED = 3,
	// D3D_MIN_PRECISION_SINT_16 = 4, D3D_MIN_PRECISION_UINT_16 = 5, D3D_MIN_PRECISION_ANY_16 = 0xf0, D3D_MIN_PRECISION_ANY_10 = 0xf1 } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_MIN_PRECISION")]
	public enum D3D_MIN_PRECISION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Default minimum precision, which is 32-bit precision.</para>
		/// </summary>
		D3D_MIN_PRECISION_DEFAULT = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Minimum precision is min16float, which is 16-bit floating point.</para>
		/// </summary>
		D3D_MIN_PRECISION_FLOAT_16,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Minimum precision is min10float, which is 10-bit floating point.</para>
		/// </summary>
		D3D_MIN_PRECISION_FLOAT_2_8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Reserved</para>
		/// </summary>
		D3D_MIN_PRECISION_RESERVED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Minimum precision is min16int, which is 16-bit signed integer.</para>
		/// </summary>
		D3D_MIN_PRECISION_SINT_16,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Minimum precision is min16uint, which is 16-bit unsigned integer.</para>
		/// </summary>
		D3D_MIN_PRECISION_UINT_16,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xf0</para>
		/// <para>Minimum precision is any 16-bit value.</para>
		/// </summary>
		D3D_MIN_PRECISION_ANY_16 = 0xf0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xf1</para>
		/// <para>Minimum precision is any 10-bit value.</para>
		/// </summary>
		D3D_MIN_PRECISION_ANY_10 = 0xf1,
	}

	/// <summary>
	/// <para>Values that identify shader parameters that use system-value semantics.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	/// <remarks>
	/// The <c>D3D_NAME</c> values identify shader parameters that have predefined system-value semantics. These values are used in a
	/// shader-signature description. For more information about shader-signature description, see D3D11_SIGNATURE_PARAMETER_DESC.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_name typedef enum D3D_NAME { D3D_NAME_UNDEFINED = 0,
	// D3D_NAME_POSITION = 1, D3D_NAME_CLIP_DISTANCE = 2, D3D_NAME_CULL_DISTANCE = 3, D3D_NAME_RENDER_TARGET_ARRAY_INDEX = 4,
	// D3D_NAME_VIEWPORT_ARRAY_INDEX = 5, D3D_NAME_VERTEX_ID = 6, D3D_NAME_PRIMITIVE_ID = 7, D3D_NAME_INSTANCE_ID = 8,
	// D3D_NAME_IS_FRONT_FACE = 9, D3D_NAME_SAMPLE_INDEX = 10, D3D_NAME_FINAL_QUAD_EDGE_TESSFACTOR = 11,
	// D3D_NAME_FINAL_QUAD_INSIDE_TESSFACTOR = 12, D3D_NAME_FINAL_TRI_EDGE_TESSFACTOR = 13, D3D_NAME_FINAL_TRI_INSIDE_TESSFACTOR = 14,
	// D3D_NAME_FINAL_LINE_DETAIL_TESSFACTOR = 15, D3D_NAME_FINAL_LINE_DENSITY_TESSFACTOR = 16, D3D_NAME_BARYCENTRICS = 23,
	// D3D_NAME_SHADINGRATE, D3D_NAME_CULLPRIMITIVE, D3D_NAME_TARGET = 64, D3D_NAME_DEPTH = 65, D3D_NAME_COVERAGE = 66,
	// D3D_NAME_DEPTH_GREATER_EQUAL = 67, D3D_NAME_DEPTH_LESS_EQUAL = 68, D3D_NAME_STENCIL_REF = 69, D3D_NAME_INNER_COVERAGE = 70,
	// D3D10_NAME_UNDEFINED, D3D10_NAME_POSITION, D3D10_NAME_CLIP_DISTANCE, D3D10_NAME_CULL_DISTANCE, D3D10_NAME_RENDER_TARGET_ARRAY_INDEX,
	// D3D10_NAME_VIEWPORT_ARRAY_INDEX, D3D10_NAME_VERTEX_ID, D3D10_NAME_PRIMITIVE_ID, D3D10_NAME_INSTANCE_ID, D3D10_NAME_IS_FRONT_FACE,
	// D3D10_NAME_SAMPLE_INDEX, D3D10_NAME_TARGET, D3D10_NAME_DEPTH, D3D10_NAME_COVERAGE, D3D11_NAME_FINAL_QUAD_EDGE_TESSFACTOR,
	// D3D11_NAME_FINAL_QUAD_INSIDE_TESSFACTOR, D3D11_NAME_FINAL_TRI_EDGE_TESSFACTOR, D3D11_NAME_FINAL_TRI_INSIDE_TESSFACTOR,
	// D3D11_NAME_FINAL_LINE_DETAIL_TESSFACTOR, D3D11_NAME_FINAL_LINE_DENSITY_TESSFACTOR, D3D11_NAME_DEPTH_GREATER_EQUAL,
	// D3D11_NAME_DEPTH_LESS_EQUAL, D3D11_NAME_STENCIL_REF, D3D11_NAME_INNER_COVERAGE, D3D12_NAME_BARYCENTRICS, D3D12_NAME_SHADINGRATE,
	// D3D12_NAME_CULLPRIMITIVE } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_NAME")]
	public enum D3D_NAME
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>This parameter does not use a predefined system-value semantic.</para>
		/// </summary>
		D3D_NAME_UNDEFINED = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>This parameter contains position data.</para>
		/// </summary>
		D3D_NAME_POSITION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>This parameter contains clip-distance data.</para>
		/// </summary>
		D3D_NAME_CLIP_DISTANCE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>This parameter contains cull-distance data.</para>
		/// </summary>
		D3D_NAME_CULL_DISTANCE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>This parameter contains a render-target-array index.</para>
		/// </summary>
		D3D_NAME_RENDER_TARGET_ARRAY_INDEX,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>This parameter contains a viewport-array index.</para>
		/// </summary>
		D3D_NAME_VIEWPORT_ARRAY_INDEX,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>This parameter contains a vertex ID.</para>
		/// </summary>
		D3D_NAME_VERTEX_ID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>This parameter contains a primitive ID.</para>
		/// </summary>
		D3D_NAME_PRIMITIVE_ID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>This parameter contains an instance ID.</para>
		/// </summary>
		D3D_NAME_INSTANCE_ID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>This parameter contains data that identifies whether or not the primitive faces the camera.</para>
		/// </summary>
		D3D_NAME_IS_FRONT_FACE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>This parameter contains a sampler-array index.</para>
		/// </summary>
		D3D_NAME_SAMPLE_INDEX,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>
		/// This parameter contains one of four tessellation factors that correspond to the amount of parts that a quad patch is broken into
		/// along the given edge. This flag is used to tessellate a quad patch.
		/// </para>
		/// </summary>
		D3D_NAME_FINAL_QUAD_EDGE_TESSFACTOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>
		/// This parameter contains one of two tessellation factors that correspond to the amount of parts that a quad patch is broken into
		/// vertically and horizontally within the patch. This flag is used to tessellate a quad patch.
		/// </para>
		/// </summary>
		D3D_NAME_FINAL_QUAD_INSIDE_TESSFACTOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>
		/// This parameter contains one of three tessellation factors that correspond to the amount of parts that a tri patch is broken into
		/// along the given edge. This flag is used to tessellate a tri patch.
		/// </para>
		/// </summary>
		D3D_NAME_FINAL_TRI_EDGE_TESSFACTOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <para>
		/// This parameter contains the tessellation factor that corresponds to the amount of parts that a tri patch is broken into within
		/// the patch. This flag is used to tessellate a tri patch.
		/// </para>
		/// </summary>
		D3D_NAME_FINAL_TRI_INSIDE_TESSFACTOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <para>
		/// This parameter contains the tessellation factor that corresponds to the number of lines broken into within the patch. This flag
		/// is used to tessellate an isolines patch.
		/// </para>
		/// </summary>
		D3D_NAME_FINAL_LINE_DETAIL_TESSFACTOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <para>
		/// This parameter contains the tessellation factor that corresponds to the number of lines that are created within the patch. This
		/// flag is used to tessellate an isolines patch.
		/// </para>
		/// </summary>
		D3D_NAME_FINAL_LINE_DENSITY_TESSFACTOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>23</para>
		/// <para>This parameter contains barycentric coordinate data.</para>
		/// </summary>
		D3D_NAME_BARYCENTRICS = 23,

		/// <summary>
		/// <para>Value:</para>
		/// <para>64</para>
		/// <para>This parameter contains render-target data.</para>
		/// </summary>
		D3D_NAME_SHADINGRATE = 24,

		/// <summary/>
		D3D_NAME_CULLPRIMITIVE = 25,

		/// <summary/>
		D3D_NAME_TARGET = 64,

		/// <summary>
		/// <para>Value:</para>
		/// <para>65</para>
		/// <para>This parameter contains depth data.</para>
		/// </summary>
		D3D_NAME_DEPTH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>66</para>
		/// <para>This parameter contains alpha-coverage data.</para>
		/// </summary>
		D3D_NAME_COVERAGE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>67</para>
		/// <para>
		/// This parameter signifies that the value is greater than or equal to a reference value. This flag is used to specify conservative
		/// depth for a pixel shader.
		/// </para>
		/// </summary>
		D3D_NAME_DEPTH_GREATER_EQUAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>68</para>
		/// <para>
		/// This parameter signifies that the value is less than or equal to a reference value. This flag is used to specify conservative
		/// depth for a pixel shader.
		/// </para>
		/// </summary>
		D3D_NAME_DEPTH_LESS_EQUAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>69</para>
		/// <para>This parameter contains a stencil reference.</para>
		/// <para>See Shader Specified Stencil Reference Value.</para>
		/// </summary>
		D3D_NAME_STENCIL_REF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>70</para>
		/// <para>This parameter contains inner input coverage data.</para>
		/// <para>See Conservative Rasterization.</para>
		/// </summary>
		D3D_NAME_INNER_COVERAGE,

		/// <summary>This parameter does not use a predefined system-value semantic.</summary>
		D3D10_NAME_UNDEFINED = D3D_NAME_UNDEFINED,

		/// <summary>This parameter contains position data.</summary>
		D3D10_NAME_POSITION = D3D_NAME_POSITION,

		/// <summary>This parameter contains clip-distance data.</summary>
		D3D10_NAME_CLIP_DISTANCE = D3D_NAME_CLIP_DISTANCE,

		/// <summary>This parameter contains cull-distance data.</summary>
		D3D10_NAME_CULL_DISTANCE = D3D_NAME_CULL_DISTANCE,

		/// <summary>This parameter contains a render-target-array index.</summary>
		D3D10_NAME_RENDER_TARGET_ARRAY_INDEX = D3D_NAME_RENDER_TARGET_ARRAY_INDEX,

		/// <summary>This parameter contains a viewport-array index.</summary>
		D3D10_NAME_VIEWPORT_ARRAY_INDEX = D3D_NAME_VIEWPORT_ARRAY_INDEX,

		/// <summary>This parameter contains a vertex ID.</summary>
		D3D10_NAME_VERTEX_ID = D3D_NAME_VERTEX_ID,

		/// <summary>This parameter contains a primitive ID.</summary>
		D3D10_NAME_PRIMITIVE_ID = D3D_NAME_PRIMITIVE_ID,

		/// <summary>This parameter contains a instance ID.</summary>
		D3D10_NAME_INSTANCE_ID = D3D_NAME_INSTANCE_ID,

		/// <summary>This parameter contains data that identifies whether or not the primitive faces the camera.</summary>
		D3D10_NAME_IS_FRONT_FACE = D3D_NAME_IS_FRONT_FACE,

		/// <summary>This parameter contains a sampler-array index.</summary>
		D3D10_NAME_SAMPLE_INDEX = D3D_NAME_SAMPLE_INDEX,

		/// <summary>This parameter contains render-target data.</summary>
		D3D10_NAME_TARGET = D3D_NAME_TARGET,

		/// <summary>This parameter contains depth data.</summary>
		D3D10_NAME_DEPTH = D3D_NAME_DEPTH,

		/// <summary>This parameter contains alpha-coverage data.</summary>
		D3D10_NAME_COVERAGE = D3D_NAME_COVERAGE,

		/// <summary>
		/// This parameter contains one of four tessellation factors that correspond to the amount of parts that a quad patch is broken into
		/// along the given edge. This flag is used to tessellate a quad patch.
		/// </summary>
		D3D11_NAME_FINAL_QUAD_EDGE_TESSFACTOR = D3D_NAME_FINAL_QUAD_EDGE_TESSFACTOR,

		/// <summary>
		/// This parameter contains one of two tessellation factors that correspond to the amount of parts that a quad patch is broken into
		/// vertically and horizontally within the patch. This flag is used to tessellate a quad patch.
		/// </summary>
		D3D11_NAME_FINAL_QUAD_INSIDE_TESSFACTOR = D3D_NAME_FINAL_QUAD_INSIDE_TESSFACTOR,

		/// <summary>
		/// This parameter contains one of three tessellation factors that correspond to the amount of parts that a tri patch is broken into
		/// along the given edge. This flag is used to tessellate a tri patch.
		/// </summary>
		D3D11_NAME_FINAL_TRI_EDGE_TESSFACTOR = D3D_NAME_FINAL_TRI_EDGE_TESSFACTOR,

		/// <summary>
		/// This parameter contains the tessellation factor that corresponds to the amount of parts that a tri patch is broken into within
		/// the patch. This flag is used to tessellate a tri patch.
		/// </summary>
		D3D11_NAME_FINAL_TRI_INSIDE_TESSFACTOR = D3D_NAME_FINAL_TRI_INSIDE_TESSFACTOR,

		/// <summary>
		/// This parameter contains the tessellation factor that corresponds to the amount of lines broken into within the patch. This flag
		/// is used to tessellate an isolines patch.
		/// </summary>
		D3D11_NAME_FINAL_LINE_DETAIL_TESSFACTOR = D3D_NAME_FINAL_LINE_DETAIL_TESSFACTOR,

		/// <summary>
		/// This parameter contains the tessellation factor that corresponds to the amount of lines that are created within the patch. This
		/// flag is used to tessellate an isolines patch.
		/// </summary>
		D3D11_NAME_FINAL_LINE_DENSITY_TESSFACTOR = D3D_NAME_FINAL_LINE_DENSITY_TESSFACTOR,

		/// <summary>
		/// This parameter signifies that the value is greater than or equal to a reference value. This flag is used to specify conservative
		/// depth for a pixel shader.
		/// </summary>
		D3D11_NAME_DEPTH_GREATER_EQUAL = D3D_NAME_DEPTH_GREATER_EQUAL,

		/// <summary>
		/// This parameter signifies that the value is less than or equal to a reference value. This flag is used to specify conservative
		/// depth for a pixel shader.
		/// </summary>
		D3D11_NAME_DEPTH_LESS_EQUAL = D3D_NAME_DEPTH_LESS_EQUAL,

		/// <summary>
		/// <para>This parameter contains a stencil reference.</para>
		/// <para>See Shader Specified Stencil Reference Value.</para>
		/// </summary>
		D3D11_NAME_STENCIL_REF = D3D_NAME_STENCIL_REF,

		/// <summary>
		/// <para>This parameter contains inner input coverage data.</para>
		/// <para>See Conservative Rasterization.</para>
		/// </summary>
		D3D11_NAME_INNER_COVERAGE = D3D_NAME_INNER_COVERAGE,

		/// <summary>This parameter contains barycentric coordinate data.</summary>
		D3D12_NAME_BARYCENTRICS = D3D_NAME_BARYCENTRICS,

		/// <summary/>
		D3D12_NAME_SHADINGRATE = D3D_NAME_SHADINGRATE,

		/// <summary/>
		D3D12_NAME_CULLPRIMITIVE = D3D_NAME_CULLPRIMITIVE,
	}

	/// <summary>Indicates semantic flags for function parameters.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_parameter_flags typedef enum D3D_PARAMETER_FLAGS {
	// D3D_PF_NONE = 0, D3D_PF_IN = 0x1, D3D_PF_OUT = 0x2, D3D_PF_FORCE_DWORD = 0x7fffffff } D3D_PARAMETER_FLAGS;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_PARAMETER_FLAGS"), Flags]
	public enum D3D_PARAMETER_FLAGS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The parameter has no semantic flags.</para>
		/// </summary>
		D3D_PF_NONE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Indicates an input parameter.</para>
		/// </summary>
		D3D_PF_IN = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Indicates an output parameter.</para>
		/// </summary>
		D3D_PF_OUT = 0x2,
	}

	/// <summary>
	/// <para>Indicates how the pipeline interprets geometry or hull shader input primitives.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>The ID3D11ShaderReflection::GetGSInputPrimitive method returns a <c>D3D11_PRIMITIVE</c>-typed value.</para>
	/// <para>
	/// The <c>D3D11_PRIMITIVE</c> enumeration is type defined in the D3D11.h header file as a D3D_PRIMITIVE enumeration, which is fully
	/// defined in the D3DCommon.h header file.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_primitive typedef enum D3D_PRIMITIVE {
	// D3D_PRIMITIVE_UNDEFINED = 0, D3D_PRIMITIVE_POINT = 1, D3D_PRIMITIVE_LINE = 2, D3D_PRIMITIVE_TRIANGLE = 3, D3D_PRIMITIVE_LINE_ADJ = 6,
	// D3D_PRIMITIVE_TRIANGLE_ADJ = 7, D3D_PRIMITIVE_1_CONTROL_POINT_PATCH = 8, D3D_PRIMITIVE_2_CONTROL_POINT_PATCH = 9,
	// D3D_PRIMITIVE_3_CONTROL_POINT_PATCH = 10, D3D_PRIMITIVE_4_CONTROL_POINT_PATCH = 11, D3D_PRIMITIVE_5_CONTROL_POINT_PATCH = 12,
	// D3D_PRIMITIVE_6_CONTROL_POINT_PATCH = 13, D3D_PRIMITIVE_7_CONTROL_POINT_PATCH = 14, D3D_PRIMITIVE_8_CONTROL_POINT_PATCH = 15,
	// D3D_PRIMITIVE_9_CONTROL_POINT_PATCH = 16, D3D_PRIMITIVE_10_CONTROL_POINT_PATCH = 17, D3D_PRIMITIVE_11_CONTROL_POINT_PATCH = 18,
	// D3D_PRIMITIVE_12_CONTROL_POINT_PATCH = 19, D3D_PRIMITIVE_13_CONTROL_POINT_PATCH = 20, D3D_PRIMITIVE_14_CONTROL_POINT_PATCH = 21,
	// D3D_PRIMITIVE_15_CONTROL_POINT_PATCH = 22, D3D_PRIMITIVE_16_CONTROL_POINT_PATCH = 23, D3D_PRIMITIVE_17_CONTROL_POINT_PATCH = 24,
	// D3D_PRIMITIVE_18_CONTROL_POINT_PATCH = 25, D3D_PRIMITIVE_19_CONTROL_POINT_PATCH = 26, D3D_PRIMITIVE_20_CONTROL_POINT_PATCH = 27,
	// D3D_PRIMITIVE_21_CONTROL_POINT_PATCH = 28, D3D_PRIMITIVE_22_CONTROL_POINT_PATCH = 29, D3D_PRIMITIVE_23_CONTROL_POINT_PATCH = 30,
	// D3D_PRIMITIVE_24_CONTROL_POINT_PATCH = 31, D3D_PRIMITIVE_25_CONTROL_POINT_PATCH = 32, D3D_PRIMITIVE_26_CONTROL_POINT_PATCH = 33,
	// D3D_PRIMITIVE_27_CONTROL_POINT_PATCH = 34, D3D_PRIMITIVE_28_CONTROL_POINT_PATCH = 35, D3D_PRIMITIVE_29_CONTROL_POINT_PATCH = 36,
	// D3D_PRIMITIVE_30_CONTROL_POINT_PATCH = 37, D3D_PRIMITIVE_31_CONTROL_POINT_PATCH = 38, D3D_PRIMITIVE_32_CONTROL_POINT_PATCH = 39,
	// D3D10_PRIMITIVE_UNDEFINED, D3D10_PRIMITIVE_POINT, D3D10_PRIMITIVE_LINE, D3D10_PRIMITIVE_TRIANGLE, D3D10_PRIMITIVE_LINE_ADJ,
	// D3D10_PRIMITIVE_TRIANGLE_ADJ, D3D11_PRIMITIVE_UNDEFINED, D3D11_PRIMITIVE_POINT, D3D11_PRIMITIVE_LINE, D3D11_PRIMITIVE_TRIANGLE,
	// D3D11_PRIMITIVE_LINE_ADJ, D3D11_PRIMITIVE_TRIANGLE_ADJ, D3D11_PRIMITIVE_1_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_2_CONTROL_POINT_PATCH,
	// D3D11_PRIMITIVE_3_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_4_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_5_CONTROL_POINT_PATCH,
	// D3D11_PRIMITIVE_6_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_7_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_8_CONTROL_POINT_PATCH,
	// D3D11_PRIMITIVE_9_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_10_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_11_CONTROL_POINT_PATCH,
	// D3D11_PRIMITIVE_12_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_13_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_14_CONTROL_POINT_PATCH,
	// D3D11_PRIMITIVE_15_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_16_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_17_CONTROL_POINT_PATCH,
	// D3D11_PRIMITIVE_18_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_19_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_20_CONTROL_POINT_PATCH,
	// D3D11_PRIMITIVE_21_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_22_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_23_CONTROL_POINT_PATCH,
	// D3D11_PRIMITIVE_24_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_25_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_26_CONTROL_POINT_PATCH,
	// D3D11_PRIMITIVE_27_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_28_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_29_CONTROL_POINT_PATCH,
	// D3D11_PRIMITIVE_30_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_31_CONTROL_POINT_PATCH, D3D11_PRIMITIVE_32_CONTROL_POINT_PATCH } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_PRIMITIVE")]
	public enum D3D_PRIMITIVE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// </summary>
		D3D_PRIMITIVE_UNDEFINED = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// </summary>
		D3D_PRIMITIVE_POINT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// </summary>
		D3D_PRIMITIVE_LINE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// </summary>
		D3D_PRIMITIVE_TRIANGLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// </summary>
		D3D_PRIMITIVE_LINE_ADJ = 6,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// </summary>
		D3D_PRIMITIVE_TRIANGLE_ADJ,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// </summary>
		D3D_PRIMITIVE_1_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// </summary>
		D3D_PRIMITIVE_2_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// </summary>
		D3D_PRIMITIVE_3_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// </summary>
		D3D_PRIMITIVE_4_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// </summary>
		D3D_PRIMITIVE_5_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// </summary>
		D3D_PRIMITIVE_6_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// </summary>
		D3D_PRIMITIVE_7_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// </summary>
		D3D_PRIMITIVE_8_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// </summary>
		D3D_PRIMITIVE_9_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>17</para>
		/// </summary>
		D3D_PRIMITIVE_10_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>18</para>
		/// </summary>
		D3D_PRIMITIVE_11_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>19</para>
		/// </summary>
		D3D_PRIMITIVE_12_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>20</para>
		/// </summary>
		D3D_PRIMITIVE_13_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>21</para>
		/// </summary>
		D3D_PRIMITIVE_14_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>22</para>
		/// </summary>
		D3D_PRIMITIVE_15_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>23</para>
		/// </summary>
		D3D_PRIMITIVE_16_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>24</para>
		/// </summary>
		D3D_PRIMITIVE_17_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>25</para>
		/// </summary>
		D3D_PRIMITIVE_18_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>26</para>
		/// </summary>
		D3D_PRIMITIVE_19_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>27</para>
		/// </summary>
		D3D_PRIMITIVE_20_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>28</para>
		/// </summary>
		D3D_PRIMITIVE_21_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>29</para>
		/// </summary>
		D3D_PRIMITIVE_22_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>30</para>
		/// </summary>
		D3D_PRIMITIVE_23_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>31</para>
		/// </summary>
		D3D_PRIMITIVE_24_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>32</para>
		/// </summary>
		D3D_PRIMITIVE_25_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>33</para>
		/// </summary>
		D3D_PRIMITIVE_26_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>34</para>
		/// </summary>
		D3D_PRIMITIVE_27_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>35</para>
		/// </summary>
		D3D_PRIMITIVE_28_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>36</para>
		/// </summary>
		D3D_PRIMITIVE_29_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>37</para>
		/// </summary>
		D3D_PRIMITIVE_30_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>38</para>
		/// </summary>
		D3D_PRIMITIVE_31_CONTROL_POINT_PATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>39</para>
		/// </summary>
		D3D_PRIMITIVE_32_CONTROL_POINT_PATCH,

		/// <summary/>
		D3D10_PRIMITIVE_UNDEFINED = D3D_PRIMITIVE_UNDEFINED,

		/// <summary/>
		D3D10_PRIMITIVE_POINT = D3D_PRIMITIVE_POINT,

		/// <summary/>
		D3D10_PRIMITIVE_LINE = D3D_PRIMITIVE_LINE,

		/// <summary/>
		D3D10_PRIMITIVE_TRIANGLE = D3D_PRIMITIVE_TRIANGLE,

		/// <summary/>
		D3D10_PRIMITIVE_LINE_ADJ = D3D_PRIMITIVE_LINE_ADJ,

		/// <summary/>
		D3D10_PRIMITIVE_TRIANGLE_ADJ = D3D_PRIMITIVE_TRIANGLE_ADJ,

		/// <summary>The shader has not been initialized with an input primitive type.</summary>
		D3D11_PRIMITIVE_UNDEFINED = D3D_PRIMITIVE_UNDEFINED,

		/// <summary>Interpret the input primitive as a point.</summary>
		D3D11_PRIMITIVE_POINT = D3D_PRIMITIVE_POINT,

		/// <summary>Interpret the input primitive as a line.</summary>
		D3D11_PRIMITIVE_LINE = D3D_PRIMITIVE_LINE,

		/// <summary>Interpret the input primitive as a triangle.</summary>
		D3D11_PRIMITIVE_TRIANGLE = D3D_PRIMITIVE_TRIANGLE,

		/// <summary>Interpret the input primitive as a line with adjacency data.</summary>
		D3D11_PRIMITIVE_LINE_ADJ = D3D_PRIMITIVE_LINE_ADJ,

		/// <summary>Interpret the input primitive as a triangle with adjacency data.</summary>
		D3D11_PRIMITIVE_TRIANGLE_ADJ = D3D_PRIMITIVE_TRIANGLE_ADJ,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_1_CONTROL_POINT_PATCH = D3D_PRIMITIVE_1_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_2_CONTROL_POINT_PATCH = D3D_PRIMITIVE_2_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_3_CONTROL_POINT_PATCH = D3D_PRIMITIVE_3_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_4_CONTROL_POINT_PATCH = D3D_PRIMITIVE_4_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_5_CONTROL_POINT_PATCH = D3D_PRIMITIVE_5_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_6_CONTROL_POINT_PATCH = D3D_PRIMITIVE_6_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_7_CONTROL_POINT_PATCH = D3D_PRIMITIVE_7_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_8_CONTROL_POINT_PATCH = D3D_PRIMITIVE_8_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_9_CONTROL_POINT_PATCH = D3D_PRIMITIVE_9_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_10_CONTROL_POINT_PATCH = D3D_PRIMITIVE_10_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_11_CONTROL_POINT_PATCH = D3D_PRIMITIVE_11_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_12_CONTROL_POINT_PATCH = D3D_PRIMITIVE_12_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_13_CONTROL_POINT_PATCH = D3D_PRIMITIVE_13_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_14_CONTROL_POINT_PATCH = D3D_PRIMITIVE_14_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_15_CONTROL_POINT_PATCH = D3D_PRIMITIVE_15_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_16_CONTROL_POINT_PATCH = D3D_PRIMITIVE_16_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_17_CONTROL_POINT_PATCH = D3D_PRIMITIVE_17_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_18_CONTROL_POINT_PATCH = D3D_PRIMITIVE_18_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_19_CONTROL_POINT_PATCH = D3D_PRIMITIVE_19_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_20_CONTROL_POINT_PATCH = D3D_PRIMITIVE_20_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_21_CONTROL_POINT_PATCH = D3D_PRIMITIVE_21_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_22_CONTROL_POINT_PATCH = D3D_PRIMITIVE_22_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_23_CONTROL_POINT_PATCH = D3D_PRIMITIVE_23_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_24_CONTROL_POINT_PATCH = D3D_PRIMITIVE_24_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_25_CONTROL_POINT_PATCH = D3D_PRIMITIVE_25_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_26_CONTROL_POINT_PATCH = D3D_PRIMITIVE_26_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_27_CONTROL_POINT_PATCH = D3D_PRIMITIVE_27_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_28_CONTROL_POINT_PATCH = D3D_PRIMITIVE_28_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_29_CONTROL_POINT_PATCH = D3D_PRIMITIVE_29_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_30_CONTROL_POINT_PATCH = D3D_PRIMITIVE_30_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_31_CONTROL_POINT_PATCH = D3D_PRIMITIVE_31_CONTROL_POINT_PATCH,

		/// <summary>Interpret the input primitive as a control point patch.</summary>
		D3D11_PRIMITIVE_32_CONTROL_POINT_PATCH = D3D_PRIMITIVE_32_CONTROL_POINT_PATCH,
	}

	/// <summary>
	/// <para>
	/// Values that indicate how the pipeline interprets vertex data that is bound to the input-assembler stage. These primitive topology
	/// values determine how the vertex data is rendered on screen.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Use the ID3D11DeviceContext::IASetPrimitiveTopology method and a value from <c>D3D_PRIMITIVE_TOPOLOGY</c> to bind a primitive
	/// topology to the input-assembler stage. Use the ID3D11DeviceContext::IAGetPrimitiveTopology method to retrieve the primitive topology
	/// for the input-assembler stage.
	/// </para>
	/// <para>The following diagram shows the various primitive types for a geometry shader object.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_primitive_topology typedef enum D3D_PRIMITIVE_TOPOLOGY
	// { D3D_PRIMITIVE_TOPOLOGY_UNDEFINED = 0, D3D_PRIMITIVE_TOPOLOGY_POINTLIST = 1, D3D_PRIMITIVE_TOPOLOGY_LINELIST = 2,
	// D3D_PRIMITIVE_TOPOLOGY_LINESTRIP = 3, D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST = 4, D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP = 5,
	// D3D_PRIMITIVE_TOPOLOGY_TRIANGLEFAN, D3D_PRIMITIVE_TOPOLOGY_LINELIST_ADJ = 10, D3D_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ = 11,
	// D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ = 12, D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ = 13,
	// D3D_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST = 33, D3D_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST = 34,
	// D3D_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST = 35, D3D_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST = 36,
	// D3D_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST = 37, D3D_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST = 38,
	// D3D_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST = 39, D3D_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST = 40,
	// D3D_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST = 41, D3D_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST = 42,
	// D3D_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST = 43, D3D_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST = 44,
	// D3D_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST = 45, D3D_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST = 46,
	// D3D_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST = 47, D3D_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST = 48,
	// D3D_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST = 49, D3D_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST = 50,
	// D3D_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST = 51, D3D_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST = 52,
	// D3D_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST = 53, D3D_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST = 54,
	// D3D_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST = 55, D3D_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST = 56,
	// D3D_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST = 57, D3D_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST = 58,
	// D3D_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST = 59, D3D_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST = 60,
	// D3D_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST = 61, D3D_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST = 62,
	// D3D_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST = 63, D3D_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST = 64,
	// D3D10_PRIMITIVE_TOPOLOGY_UNDEFINED, D3D10_PRIMITIVE_TOPOLOGY_POINTLIST, D3D10_PRIMITIVE_TOPOLOGY_LINELIST,
	// D3D10_PRIMITIVE_TOPOLOGY_LINESTRIP, D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST, D3D10_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP,
	// D3D10_PRIMITIVE_TOPOLOGY_LINELIST_ADJ, D3D10_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ, D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ,
	// D3D10_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ, D3D11_PRIMITIVE_TOPOLOGY_UNDEFINED, D3D11_PRIMITIVE_TOPOLOGY_POINTLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_LINELIST, D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP, D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST,
	// D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP, D3D11_PRIMITIVE_TOPOLOGY_LINELIST_ADJ, D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ,
	// D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ, D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ,
	// D3D11_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST,
	// D3D11_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST, D3D11_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_PRIMITIVE_TOPOLOGY")]
	public enum D3D_PRIMITIVE_TOPOLOGY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// The IA stage has not been initialized with a primitive topology. The IA stage will not function properly unless a primitive
		/// topology is defined.
		/// </para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_UNDEFINED = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Interpret the vertex data as a list of points.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_POINTLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Interpret the vertex data as a list of lines.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_LINELIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Interpret the vertex data as a line strip.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_LINESTRIP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Interpret the vertex data as a list of triangles.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Interpret the vertex data as a triangle strip.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Interpret the vertex data as a list of lines with adjacency data.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_LINELIST_ADJ = 10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Interpret the vertex data as a line strip with adjacency data.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>Interpret the vertex data as a list of triangles with adjacency data.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>Interpret the vertex data as a triangle strip with adjacency data.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ,

		/// <summary>
		/// <para>Value:</para>
		/// <para>33</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST = 33,

		/// <summary>
		/// <para>Value:</para>
		/// <para>34</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>35</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>36</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>37</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>38</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>39</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>40</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>41</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>42</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>43</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>44</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>45</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>46</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>47</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>48</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>49</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>50</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>51</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>52</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>53</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>54</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>55</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>56</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>57</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>58</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>59</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>60</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>61</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>62</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>63</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>64</para>
		/// <para>Interpret the vertex data as a patch list.</para>
		/// </summary>
		D3D_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST,

		/// <summary>
		/// The IA stage has not been initialized with a primitive topology. The IA stage will not function properly unless a primitive
		/// topology is defined.
		/// </summary>
		D3D10_PRIMITIVE_TOPOLOGY_UNDEFINED = D3D_PRIMITIVE_TOPOLOGY_UNDEFINED,

		/// <summary>Interpret the vertex data as a list of points.</summary>
		D3D10_PRIMITIVE_TOPOLOGY_POINTLIST = D3D_PRIMITIVE_TOPOLOGY_POINTLIST,

		/// <summary>Interpret the vertex data as a list of lines.</summary>
		D3D10_PRIMITIVE_TOPOLOGY_LINELIST = D3D_PRIMITIVE_TOPOLOGY_LINELIST,

		/// <summary>Interpret the vertex data as a line strip.</summary>
		D3D10_PRIMITIVE_TOPOLOGY_LINESTRIP = D3D_PRIMITIVE_TOPOLOGY_LINESTRIP,

		/// <summary>Interpret the vertex data as a list of triangles.</summary>
		D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST = D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST,

		/// <summary>Interpret the vertex data as a triangle strip.</summary>
		D3D10_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP = D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP,

		/// <summary>Interpret the vertex data as a list of lines with adjacency data.</summary>
		D3D10_PRIMITIVE_TOPOLOGY_LINELIST_ADJ = D3D_PRIMITIVE_TOPOLOGY_LINELIST_ADJ,

		/// <summary>Interpret the vertex data as a line strip with adjacency data.</summary>
		D3D10_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ = D3D_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ,

		/// <summary>Interpret the vertex data as a list of triangles with adjacency data.</summary>
		D3D10_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ = D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ,

		/// <summary>Interpret the vertex data as a triangle strip with adjacency data.</summary>
		D3D10_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ = D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ,

		/// <summary>
		/// The IA stage has not been initialized with a primitive topology. The IA stage will not function properly unless a primitive
		/// topology is defined.
		/// </summary>
		D3D11_PRIMITIVE_TOPOLOGY_UNDEFINED = D3D_PRIMITIVE_TOPOLOGY_UNDEFINED,

		/// <summary>Interpret the vertex data as a list of points.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_POINTLIST = D3D_PRIMITIVE_TOPOLOGY_POINTLIST,

		/// <summary>Interpret the vertex data as a list of lines.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_LINELIST = D3D_PRIMITIVE_TOPOLOGY_LINELIST,

		/// <summary>Interpret the vertex data as a line strip.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP = D3D_PRIMITIVE_TOPOLOGY_LINESTRIP,

		/// <summary>Interpret the vertex data as a list of triangles.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST = D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST,

		/// <summary>Interpret the vertex data as a triangle strip.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP = D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP,

		/// <summary>Interpret the vertex data as a list of lines with adjacency data.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_LINELIST_ADJ = D3D_PRIMITIVE_TOPOLOGY_LINELIST_ADJ,

		/// <summary>Interpret the vertex data as a line strip with adjacency data.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ = D3D_PRIMITIVE_TOPOLOGY_LINESTRIP_ADJ,

		/// <summary>Interpret the vertex data as a list of triangles with adjacency data.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ = D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST_ADJ,

		/// <summary>Interpret the vertex data as a triangle strip with adjacency data.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ = D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP_ADJ,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_1_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_2_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_3_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_4_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_5_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_6_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_7_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_8_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_9_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_10_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_11_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_12_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_13_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_14_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_15_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_16_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_17_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_18_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_19_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_20_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_21_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_22_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_23_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_24_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_25_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_26_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_27_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_28_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_29_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_30_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_31_CONTROL_POINT_PATCHLIST,

		/// <summary>Interpret the vertex data as a patch list.</summary>
		D3D11_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST = D3D_PRIMITIVE_TOPOLOGY_32_CONTROL_POINT_PATCHLIST,
	}

	/// <summary>
	/// <para>Values that identify the data types that can be stored in a register.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	/// <remarks>A register component type is specified in the <c>ComponentType</c> member of the D3D11_SIGNATURE_PARAMETER_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_register_component_type typedef enum
	// D3D_REGISTER_COMPONENT_TYPE { D3D_REGISTER_COMPONENT_UNKNOWN = 0, D3D_REGISTER_COMPONENT_UINT32 = 1, D3D_REGISTER_COMPONENT_SINT32 =
	// 2, D3D_REGISTER_COMPONENT_FLOAT32 = 3, D3D_REGISTER_COMPONENT_UINT16, D3D_REGISTER_COMPONENT_SINT16, D3D_REGISTER_COMPONENT_FLOAT16,
	// D3D_REGISTER_COMPONENT_UINT64, D3D_REGISTER_COMPONENT_SINT64, D3D_REGISTER_COMPONENT_FLOAT64, D3D10_REGISTER_COMPONENT_UNKNOWN,
	// D3D10_REGISTER_COMPONENT_UINT32, D3D10_REGISTER_COMPONENT_SINT32, D3D10_REGISTER_COMPONENT_FLOAT32, D3D10_REGISTER_COMPONENT_UINT16,
	// D3D10_REGISTER_COMPONENT_SINT16, D3D10_REGISTER_COMPONENT_FLOAT16, D3D10_REGISTER_COMPONENT_UINT64, D3D10_REGISTER_COMPONENT_SINT64,
	// D3D10_REGISTER_COMPONENT_FLOAT64 } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_REGISTER_COMPONENT_TYPE")]
	public enum D3D_REGISTER_COMPONENT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The data type is unknown.</para>
		/// </summary>
		D3D_REGISTER_COMPONENT_UNKNOWN = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>32-bit unsigned integer.</para>
		/// </summary>
		D3D_REGISTER_COMPONENT_UINT32,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>32-bit signed integer.</para>
		/// </summary>
		D3D_REGISTER_COMPONENT_SINT32,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>32-bit floating-point number.</para>
		/// </summary>
		D3D_REGISTER_COMPONENT_FLOAT32,

		/// <summary>The data type is unknown.</summary>
		D3D10_REGISTER_COMPONENT_UNKNOWN = D3D_REGISTER_COMPONENT_UNKNOWN,

		/// <summary>32-bit unsigned integer.</summary>
		D3D10_REGISTER_COMPONENT_UINT32 = D3D_REGISTER_COMPONENT_UINT32,

		/// <summary>32-bit signed integer.</summary>
		D3D10_REGISTER_COMPONENT_SINT32 = D3D_REGISTER_COMPONENT_SINT32,

		/// <summary>32-bit floating-point number.</summary>
		D3D10_REGISTER_COMPONENT_FLOAT32 = D3D_REGISTER_COMPONENT_FLOAT32,
	}

	/// <summary>
	/// <para>Indicates return value type.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	/// <remarks>
	/// The <c>D3D11_RESOURCE_RETURN_TYPE</c> enumeration is type defined in the D3D11shader.h header file as a D3D_RESOURCE_RETURN_TYPE
	/// enumeration, which is fully defined in the D3DCommon.h header file.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_resource_return_type typedef enum
	// D3D_RESOURCE_RETURN_TYPE { D3D_RETURN_TYPE_UNORM = 1, D3D_RETURN_TYPE_SNORM = 2, D3D_RETURN_TYPE_SINT = 3, D3D_RETURN_TYPE_UINT = 4,
	// D3D_RETURN_TYPE_FLOAT = 5, D3D_RETURN_TYPE_MIXED = 6, D3D_RETURN_TYPE_DOUBLE = 7, D3D_RETURN_TYPE_CONTINUED = 8,
	// D3D10_RETURN_TYPE_UNORM, D3D10_RETURN_TYPE_SNORM, D3D10_RETURN_TYPE_SINT, D3D10_RETURN_TYPE_UINT, D3D10_RETURN_TYPE_FLOAT,
	// D3D10_RETURN_TYPE_MIXED, D3D11_RETURN_TYPE_UNORM, D3D11_RETURN_TYPE_SNORM, D3D11_RETURN_TYPE_SINT, D3D11_RETURN_TYPE_UINT,
	// D3D11_RETURN_TYPE_FLOAT, D3D11_RETURN_TYPE_MIXED, D3D11_RETURN_TYPE_DOUBLE, D3D11_RETURN_TYPE_CONTINUED } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_RESOURCE_RETURN_TYPE")]
	public enum D3D_RESOURCE_RETURN_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// </summary>
		D3D_RETURN_TYPE_UNORM = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// </summary>
		D3D_RETURN_TYPE_SNORM,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// </summary>
		D3D_RETURN_TYPE_SINT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// </summary>
		D3D_RETURN_TYPE_UINT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// </summary>
		D3D_RETURN_TYPE_FLOAT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// </summary>
		D3D_RETURN_TYPE_MIXED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// </summary>
		D3D_RETURN_TYPE_DOUBLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// </summary>
		D3D_RETURN_TYPE_CONTINUED,

		/// <summary/>
		D3D10_RETURN_TYPE_UNORM = D3D_RETURN_TYPE_UNORM,

		/// <summary/>
		D3D10_RETURN_TYPE_SNORM = D3D_RETURN_TYPE_SNORM,

		/// <summary/>
		D3D10_RETURN_TYPE_SINT = D3D_RETURN_TYPE_SINT,

		/// <summary/>
		D3D10_RETURN_TYPE_UINT = D3D_RETURN_TYPE_UINT,

		/// <summary/>
		D3D10_RETURN_TYPE_FLOAT = D3D_RETURN_TYPE_FLOAT,

		/// <summary/>
		D3D10_RETURN_TYPE_MIXED = D3D_RETURN_TYPE_MIXED,

		/// <summary>Return type is UNORM.</summary>
		D3D11_RETURN_TYPE_UNORM = D3D_RETURN_TYPE_UNORM,

		/// <summary>Return type is SNORM.</summary>
		D3D11_RETURN_TYPE_SNORM = D3D_RETURN_TYPE_SNORM,

		/// <summary>Return type is SINT.</summary>
		D3D11_RETURN_TYPE_SINT = D3D_RETURN_TYPE_SINT,

		/// <summary>Return type is UINT.</summary>
		D3D11_RETURN_TYPE_UINT = D3D_RETURN_TYPE_UINT,

		/// <summary>Return type is FLOAT.</summary>
		D3D11_RETURN_TYPE_FLOAT = D3D_RETURN_TYPE_FLOAT,

		/// <summary>Return type is unknown.</summary>
		D3D11_RETURN_TYPE_MIXED = D3D_RETURN_TYPE_MIXED,

		/// <summary>Return type is DOUBLE.</summary>
		D3D11_RETURN_TYPE_DOUBLE = D3D_RETURN_TYPE_DOUBLE,

		/// <summary>
		/// Return type is a multiple-dword type, such as a double or uint64, and the component is continued from the previous component
		/// that was declared. The first component represents the lower bits.
		/// </summary>
		D3D11_RETURN_TYPE_CONTINUED = D3D_RETURN_TYPE_CONTINUED,
	}

	/// <summary>
	/// <para>Values that identify the intended use of a constant-data buffer.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	/// <remarks>
	/// <c>D3D_SHADER_CBUFFER_FLAGS</c>-typed values are specified in the <c>uFlags</c> member of the D3D11_SHADER_BUFFER_DESC structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_shader_cbuffer_flags typedef enum
	// D3D_SHADER_CBUFFER_FLAGS { D3D_CBF_USERPACKED = 1, D3D10_CBF_USERPACKED, D3D_CBF_FORCE_DWORD = 0x7fffffff } D3D_SHADER_CBUFFER_FLAGS;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_SHADER_CBUFFER_FLAGS"), Flags]
	public enum D3D_SHADER_CBUFFER_FLAGS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Bind the constant buffer to an input slot defined in HLSL code (instead of letting the compiler choose the input slot).</para>
		/// </summary>
		D3D_CBF_USERPACKED = 1,

		/// <summary>
		/// Bind the constant buffer to an input slot defined in HLSL code (instead of letting the compiler choose the input slot).
		/// </summary>
		D3D10_CBF_USERPACKED = D3D_CBF_USERPACKED,
	}

	/// <summary/>
	[PInvokeData("d3dcommon.h")]
	public enum D3D_SHADER_FEATURE : ulong
	{
		/// <summary/>
		D3D_SHADER_FEATURE_DOUBLES = 0x00001,

		/// <summary/>
		D3D_SHADER_FEATURE_COMPUTE_SHADERS_PLUS_RAW_AND_STRUCTURED_BUFFERS_VIA_SHADER_4_X = 0x00002,

		/// <summary/>
		D3D_SHADER_FEATURE_UAVS_AT_EVERY_STAGE = 0x00004,

		/// <summary/>
		D3D_SHADER_FEATURE_64_UAVS = 0x00008,

		/// <summary/>
		D3D_SHADER_FEATURE_MINIMUM_PRECISION = 0x00010,

		/// <summary/>
		D3D_SHADER_FEATURE_11_1_DOUBLE_EXTENSIONS = 0x00020,

		/// <summary/>
		D3D_SHADER_FEATURE_11_1_SHADER_EXTENSIONS = 0x00040,

		/// <summary/>
		D3D_SHADER_FEATURE_LEVEL_9_COMPARISON_FILTERING = 0x00080,

		/// <summary/>
		D3D_SHADER_FEATURE_TILED_RESOURCES = 0x00100,

		/// <summary/>
		D3D_SHADER_FEATURE_STENCIL_REF = 0x00200,

		/// <summary/>
		D3D_SHADER_FEATURE_INNER_COVERAGE = 0x00400,

		/// <summary/>
		D3D_SHADER_FEATURE_TYPED_UAV_LOAD_ADDITIONAL_FORMATS = 0x00800,

		/// <summary/>
		D3D_SHADER_FEATURE_ROVS = 0x01000,

		/// <summary/>
		D3D_SHADER_FEATURE_VIEWPORT_AND_RT_ARRAY_INDEX_FROM_ANY_SHADER_FEEDING_RASTERIZER = 0x02000,

		/// <summary/>
		D3D_SHADER_FEATURE_WAVE_OPS = 0x04000,

		/// <summary/>
		D3D_SHADER_FEATURE_INT64_OPS = 0x08000,

		/// <summary/>
		D3D_SHADER_FEATURE_VIEW_ID = 0x10000,

		/// <summary/>
		D3D_SHADER_FEATURE_BARYCENTRICS = 0x20000,

		/// <summary/>
		D3D_SHADER_FEATURE_NATIVE_16BIT_OPS = 0x40000,

		/// <summary/>
		D3D_SHADER_FEATURE_SHADING_RATE = 0x80000,

		/// <summary/>
		D3D_SHADER_FEATURE_RAYTRACING_TIER_1_1 = 0x100000,

		/// <summary/>
		D3D_SHADER_FEATURE_SAMPLER_FEEDBACK = 0x200000,

		/// <summary/>
		D3D_SHADER_FEATURE_ATOMIC_INT64_ON_TYPED_RESOURCE = 0x400000,

		/// <summary/>
		D3D_SHADER_FEATURE_ATOMIC_INT64_ON_GROUP_SHARED = 0x800000,

		/// <summary/>
		D3D_SHADER_FEATURE_DERIVATIVES_IN_MESH_AND_AMPLIFICATION_SHADERS = 0x1000000,

		/// <summary/>
		D3D_SHADER_FEATURE_RESOURCE_DESCRIPTOR_HEAP_INDEXING = 0x2000000,

		/// <summary/>
		D3D_SHADER_FEATURE_SAMPLER_DESCRIPTOR_HEAP_INDEXING = 0x4000000,

		/// <summary/>
		D3D_SHADER_FEATURE_WAVE_MMA = 0x8000000,

		/// <summary/>
		D3D_SHADER_FEATURE_ATOMIC_INT64_ON_DESCRIPTOR_HEAP_RESOURCE = 0x10000000,

		/// <summary/>
		D3D_SHADER_FEATURE_ADVANCED_TEXTURE_OPS = 0x20000000,

		/// <summary/>
		D3D_SHADER_FEATURE_WRITEABLE_MSAA_TEXTURES = 0x40000000,

		/// <summary/>
		D3D_SHADER_FEATURE_SAMPLE_CMP_GRADIENT_OR_BIAS = 0x80000000,

		/// <summary/>
		D3D_SHADER_FEATURE_EXTENDED_COMMAND_INFO = 0x100000000,
	}

	/// <summary>
	/// <para>Values that identify shader-input options.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	/// <remarks>
	/// <c>D3D_SHADER_INPUT_FLAGS</c>-typed values are specified in the <c>uFlags</c> member of the D3D11_SHADER_INPUT_BIND_DESC structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_shader_input_flags typedef enum
	// D3D_SHADER_INPUT_FLAGS { D3D_SIF_USERPACKED = 0x1, D3D_SIF_COMPARISON_SAMPLER = 0x2, D3D_SIF_TEXTURE_COMPONENT_0 = 0x4,
	// D3D_SIF_TEXTURE_COMPONENT_1 = 0x8, D3D_SIF_TEXTURE_COMPONENTS = 0xc, D3D_SIF_UNUSED = 0x10, D3D10_SIF_USERPACKED,
	// D3D10_SIF_COMPARISON_SAMPLER, D3D10_SIF_TEXTURE_COMPONENT_0, D3D10_SIF_TEXTURE_COMPONENT_1, D3D10_SIF_TEXTURE_COMPONENTS,
	// D3D_SIF_FORCE_DWORD = 0x7fffffff } D3D_SHADER_INPUT_FLAGS;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_SHADER_INPUT_FLAGS"), Flags]
	public enum D3D_SHADER_INPUT_FLAGS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>
		/// Assign a shader input to a register based on the register assignment in the HLSL code (instead of letting the compiler choose
		/// the register).
		/// </para>
		/// </summary>
		D3D_SIF_USERPACKED = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Use a comparison sampler, which uses the</para>
		/// <para>SampleCmp (DirectX HLSL Texture Object)</para>
		/// <para>and</para>
		/// <para>SampleCmpLevelZero (DirectX HLSL Texture Object)</para>
		/// <para>sampling functions.</para>
		/// </summary>
		D3D_SIF_COMPARISON_SAMPLER = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>A 2-bit value for encoding texture components.</para>
		/// </summary>
		D3D_SIF_TEXTURE_COMPONENT_0 = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>A 2-bit value for encoding texture components.</para>
		/// </summary>
		D3D_SIF_TEXTURE_COMPONENT_1 = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xc</para>
		/// <para>A 2-bit value for encoding texture components.</para>
		/// </summary>
		D3D_SIF_TEXTURE_COMPONENTS = 0xc,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>This value is reserved.</para>
		/// </summary>
		D3D_SIF_UNUSED = 0x10,

		/// <summary>
		/// Assign a shader input to a register based on the register assignment in the HLSL code (instead of letting the compiler choose
		/// the register).
		/// </summary>
		D3D10_SIF_USERPACKED = D3D_SIF_USERPACKED,

		/// <summary>
		/// Use a comparison sampler, which uses the SampleCmp (DirectX HLSL Texture Object) and SampleCmpLevelZero (DirectX HLSL Texture
		/// Object) sampling functions.
		/// </summary>
		D3D10_SIF_COMPARISON_SAMPLER = D3D_SIF_COMPARISON_SAMPLER,

		/// <summary>A 2-bit value for encoding texture components.</summary>
		D3D10_SIF_TEXTURE_COMPONENT_0 = D3D_SIF_TEXTURE_COMPONENT_0,

		/// <summary>A 2-bit value for encoding texture components.</summary>
		D3D10_SIF_TEXTURE_COMPONENT_1 = D3D_SIF_TEXTURE_COMPONENT_1,

		/// <summary>A 2-bit value for encoding texture components.</summary>
		D3D10_SIF_TEXTURE_COMPONENTS = D3D_SIF_TEXTURE_COMPONENTS,
	}

	/// <summary>
	/// <para>
	/// Values that identify resource types that can be bound to a shader and that are reflected as part of the resource description for the shader.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For programming with Direct3D 10, this API has a type alias that begins instead of . These Direct3D 10 type aliases are defined in ,
	/// , and .
	/// </para>
	/// </para>
	/// </summary>
	/// <remarks>
	/// <c>D3D_SHADER_INPUT_TYPE</c>-typed values are specified in the <c>Type</c> member of the D3D11_SHADER_INPUT_BIND_DESC structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_shader_input_type typedef enum D3D_SHADER_INPUT_TYPE
	// { D3D_SIT_CBUFFER = 0, D3D_SIT_TBUFFER, D3D_SIT_TEXTURE, D3D_SIT_SAMPLER, D3D_SIT_UAV_RWTYPED, D3D_SIT_STRUCTURED,
	// D3D_SIT_UAV_RWSTRUCTURED, D3D_SIT_BYTEADDRESS, D3D_SIT_UAV_RWBYTEADDRESS, D3D_SIT_UAV_APPEND_STRUCTURED,
	// D3D_SIT_UAV_CONSUME_STRUCTURED, D3D_SIT_UAV_RWSTRUCTURED_WITH_COUNTER, D3D_SIT_RTACCELERATIONSTRUCTURE, D3D_SIT_UAV_FEEDBACKTEXTURE,
	// D3D10_SIT_CBUFFER, D3D10_SIT_TBUFFER, D3D10_SIT_TEXTURE, D3D10_SIT_SAMPLER, D3D11_SIT_UAV_RWTYPED, D3D11_SIT_STRUCTURED,
	// D3D11_SIT_UAV_RWSTRUCTURED, D3D11_SIT_BYTEADDRESS, D3D11_SIT_UAV_RWBYTEADDRESS, D3D11_SIT_UAV_APPEND_STRUCTURED,
	// D3D11_SIT_UAV_CONSUME_STRUCTURED, D3D11_SIT_UAV_RWSTRUCTURED_WITH_COUNTER } D3D_SHADER_INPUT_TYPE;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_SHADER_INPUT_TYPE")]
	public enum D3D_SHADER_INPUT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The shader resource is a constant buffer.</para>
		/// </summary>
		D3D_SIT_CBUFFER = 0,

		/// <summary>The shader resource is a texture buffer.</summary>
		D3D_SIT_TBUFFER,

		/// <summary>The shader resource is a texture.</summary>
		D3D_SIT_TEXTURE,

		/// <summary>The shader resource is a sampler.</summary>
		D3D_SIT_SAMPLER,

		/// <summary>The shader resource is a read-and-write buffer.</summary>
		D3D_SIT_UAV_RWTYPED,

		/// <summary>
		/// <para>The shader resource is a structured buffer.</para>
		/// <para>For more information about structured buffer, see the</para>
		/// <para>Remarks</para>
		/// <para>section.</para>
		/// </summary>
		D3D_SIT_STRUCTURED,

		/// <summary>The shader resource is a read-and-write structured buffer.</summary>
		D3D_SIT_UAV_RWSTRUCTURED,

		/// <summary>The shader resource is a byte-address buffer.</summary>
		D3D_SIT_BYTEADDRESS,

		/// <summary>The shader resource is a read-and-write byte-address buffer.</summary>
		D3D_SIT_UAV_RWBYTEADDRESS,

		/// <summary>The shader resource is an append-structured buffer.</summary>
		D3D_SIT_UAV_APPEND_STRUCTURED,

		/// <summary>The shader resource is a consume-structured buffer.</summary>
		D3D_SIT_UAV_CONSUME_STRUCTURED,

		/// <summary>The shader resource is a read-and-write structured buffer that uses the built-in counter to append or consume.</summary>
		D3D_SIT_UAV_RWSTRUCTURED_WITH_COUNTER,

		/// <summary>The shader resource is a constant buffer.</summary>
		D3D10_SIT_CBUFFER = D3D_SIT_CBUFFER,

		/// <summary>The shader resource is a texture buffer.</summary>
		D3D10_SIT_TBUFFER = D3D_SIT_TBUFFER,

		/// <summary>The shader resource is a texture.</summary>
		D3D10_SIT_TEXTURE = D3D_SIT_TEXTURE,

		/// <summary>The shader resource is a sampler.</summary>
		D3D10_SIT_SAMPLER = D3D_SIT_SAMPLER,

		/// <summary>The shader resource is a read-and-write buffer.</summary>
		D3D11_SIT_UAV_RWTYPED = D3D_SIT_UAV_RWTYPED,

		/// <summary>
		/// <para>The shader resource is a structured buffer.</para>
		/// <para>For more information about structured buffer, see the Remarks section.</para>
		/// </summary>
		D3D11_SIT_STRUCTURED = D3D_SIT_STRUCTURED,

		/// <summary>The shader resource is a read-and-write structured buffer.</summary>
		D3D11_SIT_UAV_RWSTRUCTURED = D3D_SIT_UAV_RWSTRUCTURED,

		/// <summary>The shader resource is a byte-address buffer.</summary>
		D3D11_SIT_BYTEADDRESS = D3D_SIT_BYTEADDRESS,

		/// <summary>The shader resource is a read-and-write byte-address buffer.</summary>
		D3D11_SIT_UAV_RWBYTEADDRESS = D3D_SIT_UAV_RWBYTEADDRESS,

		/// <summary>The shader resource is an append-structured buffer.</summary>
		D3D11_SIT_UAV_APPEND_STRUCTURED = D3D_SIT_UAV_APPEND_STRUCTURED,

		/// <summary>The shader resource is a consume-structured buffer.</summary>
		D3D11_SIT_UAV_CONSUME_STRUCTURED = D3D_SIT_UAV_CONSUME_STRUCTURED,

		/// <summary>The shader resource is a read-and-write structured buffer that uses the built-in counter to append or consume.</summary>
		D3D11_SIT_UAV_RWSTRUCTURED_WITH_COUNTER = D3D_SIT_UAV_RWSTRUCTURED_WITH_COUNTER,
	}

	/// <summary>
	/// <para>Values that identify the class of a shader variable.</para>
	/// <note type="note">For programming with Direct3D 10, this API has a type alias that begins D3D10_ instead of D3D_. These Direct3D 10
	/// type aliases are defined in d3d10.h, d3d10misc.h, and d3d10shader.h.</note>
	/// </summary>
	/// <remarks>
	/// The class of a shader variable is not a programming class; the class identifies the variable class such as scalar, vector, object,
	/// and so on. <c>D3D_SHADER_VARIABLE_CLASS</c>-typed values are specified in the <c>Class</c> member of the D3D11_SHADER_TYPE_DESC structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_shader_variable_class typedef enum
	// D3D_SHADER_VARIABLE_CLASS { D3D_SVC_SCALAR = 0, D3D_SVC_VECTOR, D3D_SVC_MATRIX_ROWS, D3D_SVC_MATRIX_COLUMNS, D3D_SVC_OBJECT,
	// D3D_SVC_STRUCT, D3D_SVC_INTERFACE_CLASS, D3D_SVC_INTERFACE_POINTER, D3D10_SVC_SCALAR, D3D10_SVC_VECTOR, D3D10_SVC_MATRIX_ROWS,
	// D3D10_SVC_MATRIX_COLUMNS, D3D10_SVC_OBJECT, D3D10_SVC_STRUCT, D3D11_SVC_INTERFACE_CLASS, D3D11_SVC_INTERFACE_POINTER,
	// D3D_SVC_FORCE_DWORD = 0x7fffffff } D3D_SHADER_VARIABLE_CLASS;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_SHADER_VARIABLE_CLASS")]
	public enum D3D_SHADER_VARIABLE_CLASS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The shader variable is a scalar.</para>
		/// </summary>
		D3D_SVC_SCALAR = 0,

		/// <summary>The shader variable is a vector.</summary>
		D3D_SVC_VECTOR,

		/// <summary>The shader variable is a row-major matrix.</summary>
		D3D_SVC_MATRIX_ROWS,

		/// <summary>The shader variable is a column-major matrix.</summary>
		D3D_SVC_MATRIX_COLUMNS,

		/// <summary>The shader variable is an object.</summary>
		D3D_SVC_OBJECT,

		/// <summary>The shader variable is a structure.</summary>
		D3D_SVC_STRUCT,

		/// <summary>The shader variable is a class.</summary>
		D3D_SVC_INTERFACE_CLASS,

		/// <summary>The shader variable is an interface.</summary>
		D3D_SVC_INTERFACE_POINTER,

		/// <summary>The shader variable is a scalar.</summary>
		D3D10_SVC_SCALAR = D3D_SVC_SCALAR,

		/// <summary>The shader variable is a vector.</summary>
		D3D10_SVC_VECTOR = D3D_SVC_VECTOR,

		/// <summary>The shader variable is a row-major matrix.</summary>
		D3D10_SVC_MATRIX_ROWS = D3D_SVC_MATRIX_ROWS,

		/// <summary>The shader variable is a column-major matrix.</summary>
		D3D10_SVC_MATRIX_COLUMNS = D3D_SVC_MATRIX_COLUMNS,

		/// <summary>The shader variable is an object.</summary>
		D3D10_SVC_OBJECT = D3D_SVC_OBJECT,

		/// <summary>The shader variable is a structure.</summary>
		D3D10_SVC_STRUCT = D3D_SVC_STRUCT,

		/// <summary>The shader variable is a class.</summary>
		D3D11_SVC_INTERFACE_CLASS = D3D_SVC_INTERFACE_CLASS,

		/// <summary>The shader variable is an interface.</summary>
		D3D11_SVC_INTERFACE_POINTER = D3D_SVC_INTERFACE_POINTER,
	}

	/// <summary>
	/// <para>Values that identify information about a shader variable.</para>
	/// <note type="note">For programming with Direct3D 10, this API has a type alias that begins D3D10_ instead of D3D_. These Direct3D 10
	/// type aliases are defined in d3d10.h, d3d10misc.h, and d3d10shader.h.</note>
	/// </summary>
	/// <remarks>
	/// A call to the ID3D11ShaderReflectionVariable::GetDesc method returns <c>D3D_SHADER_VARIABLE_FLAGS</c> values in the <c>uFlags</c>
	/// member of a D3D11_SHADER_VARIABLE_DESC structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_shader_variable_flags typedef enum
	// D3D_SHADER_VARIABLE_FLAGS { D3D_SVF_USERPACKED = 1, D3D_SVF_USED = 2, D3D_SVF_INTERFACE_POINTER = 4, D3D_SVF_INTERFACE_PARAMETER =
	// 8, D3D10_SVF_USERPACKED, D3D10_SVF_USED, D3D11_SVF_INTERFACE_POINTER, D3D11_SVF_INTERFACE_PARAMETER, D3D_SVF_FORCE_DWORD = 0x7fffffff
	// } D3D_SHADER_VARIABLE_FLAGS;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_SHADER_VARIABLE_FLAGS"), Flags]
	public enum D3D_SHADER_VARIABLE_FLAGS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Indicates that the registers assigned to this shader variable were explicitly declared in shader code (instead of automatically
		/// assigned by the compiler).
		/// </para>
		/// </summary>
		D3D_SVF_USERPACKED = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Indicates that this variable is used by this shader. This value confirms that a particular shader variable (which can be common
		/// to many different shaders) is indeed used by a particular shader.
		/// </para>
		/// </summary>
		D3D_SVF_USED = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Indicates that this variable is an interface.</para>
		/// </summary>
		D3D_SVF_INTERFACE_POINTER = 4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Indicates that this variable is a parameter of an interface.</para>
		/// </summary>
		D3D_SVF_INTERFACE_PARAMETER = 8,

		/// <summary>
		/// Indicates that the registers assigned to this shader variable were explicitly declared in shader code (instead of automatically
		/// assigned by the compiler).
		/// </summary>
		D3D10_SVF_USERPACKED = D3D_SVF_USERPACKED,

		/// <summary>
		/// Indicates that this variable is used by this shader. This value confirms that a particular shader variable (which can be common
		/// to many different shaders) is indeed used by a particular shader.
		/// </summary>
		D3D10_SVF_USED = D3D_SVF_USED,

		/// <summary>Indicates that this variable is an interface.</summary>
		D3D11_SVF_INTERFACE_POINTER = D3D_SVF_INTERFACE_POINTER,

		/// <summary>Indicates that this variable is a parameter of an interface.</summary>
		D3D11_SVF_INTERFACE_PARAMETER = D3D_SVF_INTERFACE_PARAMETER,
	}

	/// <summary>
	/// <para>Values that identify various data, texture, and buffer types that can be assigned to a shader variable.</para>
	/// <note type="note">For programming with Direct3D 10, this API has a type alias that begins D3D10_ instead of D3D_. These Direct3D 10
	/// type aliases are defined in d3d10.h, d3d10misc.h, and d3d10shader.h.</note>
	/// </summary>
	/// <remarks>
	/// <para>
	/// A call to the ID3D11ShaderReflectionType::GetDesc method returns a <c>D3D_SHADER_VARIABLE_TYPE</c> value in the <c>Type</c> member
	/// of a D3D11_SHADER_TYPE_DESC structure.
	/// </para>
	/// <para>
	/// The types in a structured buffer describe the structure of the elements in the buffer. The layout of these types generally match
	/// their C++ struct counterparts. The following examples show structured buffers:
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_shader_variable_type typedef enum
	// D3D_SHADER_VARIABLE_TYPE { D3D_SVT_VOID = 0, D3D_SVT_BOOL = 1, D3D_SVT_INT = 2, D3D_SVT_FLOAT = 3, D3D_SVT_STRING = 4,
	// D3D_SVT_TEXTURE = 5, D3D_SVT_TEXTURE1D = 6, D3D_SVT_TEXTURE2D = 7, D3D_SVT_TEXTURE3D = 8, D3D_SVT_TEXTURECUBE = 9, D3D_SVT_SAMPLER =
	// 10, D3D_SVT_SAMPLER1D = 11, D3D_SVT_SAMPLER2D = 12, D3D_SVT_SAMPLER3D = 13, D3D_SVT_SAMPLERCUBE = 14, D3D_SVT_PIXELSHADER = 15,
	// D3D_SVT_VERTEXSHADER = 16, D3D_SVT_PIXELFRAGMENT = 17, D3D_SVT_VERTEXFRAGMENT = 18, D3D_SVT_UINT = 19, D3D_SVT_UINT8 = 20,
	// D3D_SVT_GEOMETRYSHADER = 21, D3D_SVT_RASTERIZER = 22, D3D_SVT_DEPTHSTENCIL = 23, D3D_SVT_BLEND = 24, D3D_SVT_BUFFER = 25,
	// D3D_SVT_CBUFFER = 26, D3D_SVT_TBUFFER = 27, D3D_SVT_TEXTURE1DARRAY = 28, D3D_SVT_TEXTURE2DARRAY = 29, D3D_SVT_RENDERTARGETVIEW = 30,
	// D3D_SVT_DEPTHSTENCILVIEW = 31, D3D_SVT_TEXTURE2DMS = 32, D3D_SVT_TEXTURE2DMSARRAY = 33, D3D_SVT_TEXTURECUBEARRAY = 34,
	// D3D_SVT_HULLSHADER = 35, D3D_SVT_DOMAINSHADER = 36, D3D_SVT_INTERFACE_POINTER = 37, D3D_SVT_COMPUTESHADER = 38, D3D_SVT_DOUBLE = 39,
	// D3D_SVT_RWTEXTURE1D = 40, D3D_SVT_RWTEXTURE1DARRAY = 41, D3D_SVT_RWTEXTURE2D = 42, D3D_SVT_RWTEXTURE2DARRAY = 43, D3D_SVT_RWTEXTURE3D
	// = 44, D3D_SVT_RWBUFFER = 45, D3D_SVT_BYTEADDRESS_BUFFER = 46, D3D_SVT_RWBYTEADDRESS_BUFFER = 47, D3D_SVT_STRUCTURED_BUFFER = 48,
	// D3D_SVT_RWSTRUCTURED_BUFFER = 49, D3D_SVT_APPEND_STRUCTURED_BUFFER = 50, D3D_SVT_CONSUME_STRUCTURED_BUFFER = 51, D3D_SVT_MIN8FLOAT =
	// 52, D3D_SVT_MIN10FLOAT = 53, D3D_SVT_MIN16FLOAT = 54, D3D_SVT_MIN12INT = 55, D3D_SVT_MIN16INT = 56, D3D_SVT_MIN16UINT = 57,
	// D3D_SVT_INT16, D3D_SVT_UINT16, D3D_SVT_FLOAT16, D3D_SVT_INT64, D3D_SVT_UINT64, D3D10_SVT_VOID, D3D10_SVT_BOOL, D3D10_SVT_INT,
	// D3D10_SVT_FLOAT, D3D10_SVT_STRING, D3D10_SVT_TEXTURE, D3D10_SVT_TEXTURE1D, D3D10_SVT_TEXTURE2D, D3D10_SVT_TEXTURE3D,
	// D3D10_SVT_TEXTURECUBE, D3D10_SVT_SAMPLER, D3D10_SVT_SAMPLER1D, D3D10_SVT_SAMPLER2D, D3D10_SVT_SAMPLER3D, D3D10_SVT_SAMPLERCUBE,
	// D3D10_SVT_PIXELSHADER, D3D10_SVT_VERTEXSHADER, D3D10_SVT_PIXELFRAGMENT, D3D10_SVT_VERTEXFRAGMENT, D3D10_SVT_UINT, D3D10_SVT_UINT8,
	// D3D10_SVT_GEOMETRYSHADER, D3D10_SVT_RASTERIZER, D3D10_SVT_DEPTHSTENCIL, D3D10_SVT_BLEND, D3D10_SVT_BUFFER, D3D10_SVT_CBUFFER,
	// D3D10_SVT_TBUFFER, D3D10_SVT_TEXTURE1DARRAY, D3D10_SVT_TEXTURE2DARRAY, D3D10_SVT_RENDERTARGETVIEW, D3D10_SVT_DEPTHSTENCILVIEW,
	// D3D10_SVT_TEXTURE2DMS, D3D10_SVT_TEXTURE2DMSARRAY, D3D10_SVT_TEXTURECUBEARRAY, D3D11_SVT_HULLSHADER, D3D11_SVT_DOMAINSHADER,
	// D3D11_SVT_INTERFACE_POINTER, D3D11_SVT_COMPUTESHADER, D3D11_SVT_DOUBLE, D3D11_SVT_RWTEXTURE1D, D3D11_SVT_RWTEXTURE1DARRAY,
	// D3D11_SVT_RWTEXTURE2D, D3D11_SVT_RWTEXTURE2DARRAY, D3D11_SVT_RWTEXTURE3D, D3D11_SVT_RWBUFFER, D3D11_SVT_BYTEADDRESS_BUFFER,
	// D3D11_SVT_RWBYTEADDRESS_BUFFER, D3D11_SVT_STRUCTURED_BUFFER, D3D11_SVT_RWSTRUCTURED_BUFFER, D3D11_SVT_APPEND_STRUCTURED_BUFFER,
	// D3D11_SVT_CONSUME_STRUCTURED_BUFFER, D3D_SVT_FORCE_DWORD = 0x7fffffff } D3D_SHADER_VARIABLE_TYPE;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_SHADER_VARIABLE_TYPE")]
	public enum D3D_SHADER_VARIABLE_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The variable is a void pointer.</para>
		/// </summary>
		[CorrespondingType(typeof(IntPtr))]
		D3D_SVT_VOID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The variable is a boolean.</para>
		/// </summary>
		[CorrespondingType(typeof(BOOL))]
		D3D_SVT_BOOL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The variable is an integer.</para>
		/// </summary>
		[CorrespondingType(typeof(int))]
		D3D_SVT_INT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The variable is a floating-point number.</para>
		/// </summary>
		[CorrespondingType(typeof(float))]
		D3D_SVT_FLOAT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The variable is a string.</para>
		/// </summary>
		[CorrespondingType(typeof(string))]
		D3D_SVT_STRING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The variable is a texture.</para>
		/// </summary>
		D3D_SVT_TEXTURE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The variable is a 1D texture.</para>
		/// </summary>
		D3D_SVT_TEXTURE1D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The variable is a 2D texture.</para>
		/// </summary>
		D3D_SVT_TEXTURE2D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The variable is a 3D texture.</para>
		/// </summary>
		D3D_SVT_TEXTURE3D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>The variable is a texture cube.</para>
		/// </summary>
		D3D_SVT_TEXTURECUBE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>The variable is a sampler.</para>
		/// </summary>
		D3D_SVT_SAMPLER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>The variable is a 1D sampler.</para>
		/// </summary>
		D3D_SVT_SAMPLER1D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>The variable is a 2D sampler.</para>
		/// </summary>
		D3D_SVT_SAMPLER2D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>The variable is a 3D sampler.</para>
		/// </summary>
		D3D_SVT_SAMPLER3D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <para>The variable is a cube sampler.</para>
		/// </summary>
		D3D_SVT_SAMPLERCUBE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <para>The variable is a pixel shader.</para>
		/// </summary>
		D3D_SVT_PIXELSHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <para>The variable is a vertex shader.</para>
		/// </summary>
		D3D_SVT_VERTEXSHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>17</para>
		/// <para>The variable is a pixel fragment.</para>
		/// </summary>
		D3D_SVT_PIXELFRAGMENT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>18</para>
		/// <para>The variable is a vertex fragment.</para>
		/// </summary>
		D3D_SVT_VERTEXFRAGMENT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>19</para>
		/// <para>The variable is an unsigned integer.</para>
		/// </summary>
		[CorrespondingType(typeof(uint))]
		D3D_SVT_UINT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>20</para>
		/// <para>The variable is an 8-bit unsigned integer.</para>
		/// </summary>
		[CorrespondingType(typeof(byte))]
		D3D_SVT_UINT8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>21</para>
		/// <para>The variable is a geometry shader.</para>
		/// </summary>
		D3D_SVT_GEOMETRYSHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>22</para>
		/// <para>The variable is a rasterizer-state object.</para>
		/// </summary>
		D3D_SVT_RASTERIZER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>23</para>
		/// <para>The variable is a depth-stencil-state object.</para>
		/// </summary>
		D3D_SVT_DEPTHSTENCIL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>24</para>
		/// <para>The variable is a blend-state object.</para>
		/// </summary>
		D3D_SVT_BLEND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>25</para>
		/// <para>The variable is a buffer.</para>
		/// </summary>
		D3D_SVT_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>26</para>
		/// <para>The variable is a constant buffer.</para>
		/// </summary>
		D3D_SVT_CBUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>27</para>
		/// <para>The variable is a texture buffer.</para>
		/// </summary>
		D3D_SVT_TBUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>28</para>
		/// <para>The variable is a 1D-texture array.</para>
		/// </summary>
		D3D_SVT_TEXTURE1DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>29</para>
		/// <para>The variable is a 2D-texture array.</para>
		/// </summary>
		D3D_SVT_TEXTURE2DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>30</para>
		/// <para>The variable is a render-target view.</para>
		/// </summary>
		D3D_SVT_RENDERTARGETVIEW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>31</para>
		/// <para>The variable is a depth-stencil view.</para>
		/// </summary>
		D3D_SVT_DEPTHSTENCILVIEW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>32</para>
		/// <para>The variable is a 2D-multisampled texture.</para>
		/// </summary>
		D3D_SVT_TEXTURE2DMS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>33</para>
		/// <para>The variable is a 2D-multisampled-texture array.</para>
		/// </summary>
		D3D_SVT_TEXTURE2DMSARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>34</para>
		/// <para>The variable is a texture-cube array.</para>
		/// </summary>
		D3D_SVT_TEXTURECUBEARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>35</para>
		/// <para>The variable holds a compiled hull-shader binary.</para>
		/// </summary>
		D3D_SVT_HULLSHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>36</para>
		/// <para>The variable holds a compiled domain-shader binary.</para>
		/// </summary>
		D3D_SVT_DOMAINSHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>37</para>
		/// <para>The variable is an interface.</para>
		/// </summary>
		D3D_SVT_INTERFACE_POINTER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>38</para>
		/// <para>The variable holds a compiled compute-shader binary.</para>
		/// </summary>
		D3D_SVT_COMPUTESHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>39</para>
		/// <para>The variable is a double precision (64-bit) floating-point number.</para>
		/// </summary>
		[CorrespondingType(typeof(double))]
		D3D_SVT_DOUBLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>40</para>
		/// <para>The variable is a 1D read-and-write texture.</para>
		/// </summary>
		D3D_SVT_RWTEXTURE1D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>41</para>
		/// <para>The variable is an array of 1D read-and-write textures.</para>
		/// </summary>
		D3D_SVT_RWTEXTURE1DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>42</para>
		/// <para>The variable is a 2D read-and-write texture.</para>
		/// </summary>
		D3D_SVT_RWTEXTURE2D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>43</para>
		/// <para>The variable is an array of 2D read-and-write textures.</para>
		/// </summary>
		D3D_SVT_RWTEXTURE2DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>44</para>
		/// <para>The variable is a 3D read-and-write texture.</para>
		/// </summary>
		D3D_SVT_RWTEXTURE3D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>45</para>
		/// <para>The variable is a read-and-write buffer.</para>
		/// </summary>
		D3D_SVT_RWBUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>46</para>
		/// <para>The variable is a byte-address buffer.</para>
		/// </summary>
		D3D_SVT_BYTEADDRESS_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>47</para>
		/// <para>The variable is a read-and-write byte-address buffer.</para>
		/// </summary>
		D3D_SVT_RWBYTEADDRESS_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>48</para>
		/// <para>The variable is a structured buffer.</para>
		/// <para>For more information about structured buffer, see the</para>
		/// <para>Remarks</para>
		/// <para>section.</para>
		/// </summary>
		D3D_SVT_STRUCTURED_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>49</para>
		/// <para>The variable is a read-and-write structured buffer.</para>
		/// </summary>
		D3D_SVT_RWSTRUCTURED_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>50</para>
		/// <para>The variable is an append structured buffer.</para>
		/// </summary>
		D3D_SVT_APPEND_STRUCTURED_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>51</para>
		/// <para>The variable is a consume structured buffer.</para>
		/// </summary>
		D3D_SVT_CONSUME_STRUCTURED_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>52</para>
		/// <para>The variable is an 8-byte FLOAT.</para>
		/// </summary>
		D3D_SVT_MIN8FLOAT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>53</para>
		/// <para>The variable is a 10-byte FLOAT.</para>
		/// </summary>
		D3D_SVT_MIN10FLOAT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>54</para>
		/// <para>The variable is a 16-byte FLOAT.</para>
		/// </summary>
		D3D_SVT_MIN16FLOAT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>55</para>
		/// <para>The variable is a 12-byte INT.</para>
		/// </summary>
		D3D_SVT_MIN12INT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>56</para>
		/// <para>The variable is a 16-byte INT.</para>
		/// </summary>
		[CorrespondingType(typeof(short))]
		D3D_SVT_MIN16INT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>57</para>
		/// <para>The variable is a 16-byte INT.</para>
		/// </summary>
		[CorrespondingType(typeof(ushort))]
		D3D_SVT_MIN16UINT,

		/// <summary>The variable is a void pointer.</summary>
		D3D10_SVT_VOID = D3D_SVT_VOID,

		/// <summary>The variable is a boolean.</summary>
		D3D10_SVT_BOOL = D3D_SVT_BOOL,

		/// <summary>The variable is an integer.</summary>
		D3D10_SVT_INT = D3D_SVT_INT,

		/// <summary>The variable is a floating-point number.</summary>
		D3D10_SVT_FLOAT = D3D_SVT_FLOAT,

		/// <summary>The variable is a string.</summary>
		D3D10_SVT_STRING = D3D_SVT_STRING,

		/// <summary>The variable is a texture.</summary>
		D3D10_SVT_TEXTURE = D3D_SVT_TEXTURE,

		/// <summary>The variable is a 1D texture.</summary>
		D3D10_SVT_TEXTURE1D = D3D_SVT_TEXTURE1D,

		/// <summary>The variable is a 2D texture.</summary>
		D3D10_SVT_TEXTURE2D = D3D_SVT_TEXTURE2D,

		/// <summary>The variable is a 3D texture.</summary>
		D3D10_SVT_TEXTURE3D = D3D_SVT_TEXTURE3D,

		/// <summary>The variable is a texture cube.</summary>
		D3D10_SVT_TEXTURECUBE = D3D_SVT_TEXTURECUBE,

		/// <summary>The variable is a sampler.</summary>
		D3D10_SVT_SAMPLER = D3D_SVT_SAMPLER,

		/// <summary>The variable is a 1D sampler.</summary>
		D3D10_SVT_SAMPLER1D = D3D_SVT_SAMPLER1D,

		/// <summary>The variable is a 2D sampler.</summary>
		D3D10_SVT_SAMPLER2D = D3D_SVT_SAMPLER2D,

		/// <summary>The variable is a 3D sampler.</summary>
		D3D10_SVT_SAMPLER3D = D3D_SVT_SAMPLER3D,

		/// <summary>The variable is a cube sampler.</summary>
		D3D10_SVT_SAMPLERCUBE = D3D_SVT_SAMPLERCUBE,

		/// <summary>The variable is a pixel shader.</summary>
		D3D10_SVT_PIXELSHADER = D3D_SVT_PIXELSHADER,

		/// <summary>The variable is a vertex shader.</summary>
		D3D10_SVT_VERTEXSHADER = D3D_SVT_VERTEXSHADER,

		/// <summary>The variable is a pixel fragment.</summary>
		D3D10_SVT_PIXELFRAGMENT = D3D_SVT_PIXELFRAGMENT,

		/// <summary>The variable is a vertex fragment.</summary>
		D3D10_SVT_VERTEXFRAGMENT = D3D_SVT_VERTEXFRAGMENT,

		/// <summary>The variable is an unsigned integer.</summary>
		D3D10_SVT_UINT = D3D_SVT_UINT,

		/// <summary>The variable is an 8-bit unsigned integer.</summary>
		D3D10_SVT_UINT8 = D3D_SVT_UINT8,

		/// <summary>The variable is a geometry shader.</summary>
		D3D10_SVT_GEOMETRYSHADER = D3D_SVT_GEOMETRYSHADER,

		/// <summary>The variable is a rasterizer-state object.</summary>
		D3D10_SVT_RASTERIZER = D3D_SVT_RASTERIZER,

		/// <summary>The variable is a depth-stencil-state object.</summary>
		D3D10_SVT_DEPTHSTENCIL = D3D_SVT_DEPTHSTENCIL,

		/// <summary>The variable is a blend-state object.</summary>
		D3D10_SVT_BLEND = D3D_SVT_BLEND,

		/// <summary>The variable is a buffer.</summary>
		D3D10_SVT_BUFFER = D3D_SVT_BUFFER,

		/// <summary>The variable is a constant buffer.</summary>
		D3D10_SVT_CBUFFER = D3D_SVT_CBUFFER,

		/// <summary>The variable is a texture buffer.</summary>
		D3D10_SVT_TBUFFER = D3D_SVT_TBUFFER,

		/// <summary>The variable is a 1D-texture array.</summary>
		D3D10_SVT_TEXTURE1DARRAY = D3D_SVT_TEXTURE1DARRAY,

		/// <summary>The variable is a 2D-texture array.</summary>
		D3D10_SVT_TEXTURE2DARRAY = D3D_SVT_TEXTURE2DARRAY,

		/// <summary>The variable is a render-target view.</summary>
		D3D10_SVT_RENDERTARGETVIEW = D3D_SVT_RENDERTARGETVIEW,

		/// <summary>The variable is a depth-stencil view.</summary>
		D3D10_SVT_DEPTHSTENCILVIEW = D3D_SVT_DEPTHSTENCILVIEW,

		/// <summary>The variable is a 2D-multisampled texture.</summary>
		D3D10_SVT_TEXTURE2DMS = D3D_SVT_TEXTURE2DMS,

		/// <summary>The variable is a 2D-multisampled-texture array.</summary>
		D3D10_SVT_TEXTURE2DMSARRAY = D3D_SVT_TEXTURE2DMSARRAY,

		/// <summary>The variable is a texture-cube array.</summary>
		D3D10_SVT_TEXTURECUBEARRAY = D3D_SVT_TEXTURECUBEARRAY,

		/// <summary>The variable holds a compiled hull-shader binary.</summary>
		D3D11_SVT_HULLSHADER = D3D_SVT_HULLSHADER,

		/// <summary>The variable holds a compiled domain-shader binary.</summary>
		D3D11_SVT_DOMAINSHADER = D3D_SVT_DOMAINSHADER,

		/// <summary>The variable is an interface.</summary>
		D3D11_SVT_INTERFACE_POINTER = D3D_SVT_INTERFACE_POINTER,

		/// <summary>The variable holds a compiled compute-shader binary.</summary>
		D3D11_SVT_COMPUTESHADER = D3D_SVT_COMPUTESHADER,

		/// <summary>The variable is a double precision (64-bit) floating-point number.</summary>
		D3D11_SVT_DOUBLE = D3D_SVT_DOUBLE,

		/// <summary>The variable is a 1D read-and-write texture.</summary>
		D3D11_SVT_RWTEXTURE1D = D3D_SVT_RWTEXTURE1D,

		/// <summary>The variable is an array of 1D read-and-write textures.</summary>
		D3D11_SVT_RWTEXTURE1DARRAY = D3D_SVT_RWTEXTURE1DARRAY,

		/// <summary>The variable is a 2D read-and-write texture.</summary>
		D3D11_SVT_RWTEXTURE2D = D3D_SVT_RWTEXTURE2D,

		/// <summary>The variable is an array of 2D read-and-write textures.</summary>
		D3D11_SVT_RWTEXTURE2DARRAY = D3D_SVT_RWTEXTURE2DARRAY,

		/// <summary>The variable is a 3D read-and-write texture.</summary>
		D3D11_SVT_RWTEXTURE3D = D3D_SVT_RWTEXTURE3D,

		/// <summary>The variable is a read-and-write buffer.</summary>
		D3D11_SVT_RWBUFFER = D3D_SVT_RWBUFFER,

		/// <summary>The variable is a byte-address buffer.</summary>
		D3D11_SVT_BYTEADDRESS_BUFFER = D3D_SVT_BYTEADDRESS_BUFFER,

		/// <summary>The variable is a read and write byte-address buffer.</summary>
		D3D11_SVT_RWBYTEADDRESS_BUFFER = D3D_SVT_RWBYTEADDRESS_BUFFER,

		/// <summary>The variable is a structured buffer.</summary>
		D3D11_SVT_STRUCTURED_BUFFER = D3D_SVT_STRUCTURED_BUFFER,

		/// <summary>The variable is a read-and-write structured buffer.</summary>
		D3D11_SVT_RWSTRUCTURED_BUFFER = D3D_SVT_RWSTRUCTURED_BUFFER,

		/// <summary>The variable is an append structured buffer.</summary>
		D3D11_SVT_APPEND_STRUCTURED_BUFFER = D3D_SVT_APPEND_STRUCTURED_BUFFER,

		/// <summary>The variable is a consume structured buffer.</summary>
		D3D11_SVT_CONSUME_STRUCTURED_BUFFER = D3D_SVT_CONSUME_STRUCTURED_BUFFER,
	}

	/// <summary>
	/// <para>Values that identify the type of resource to be viewed as a shader resource.</para>
	/// <note type="note">For programming with Direct3D 10, this API has a type alias that begins D3D10_ instead of D3D_. These Direct3D 10
	/// type aliases are defined in d3d10.h, d3d10misc.h, and d3d10shader.h.</note>
	/// </summary>
	/// <remarks>
	/// A <c>D3D_SRV_DIMENSION</c>-typed value is specified in the <c>ViewDimension</c> member of the D3D11_SHADER_RESOURCE_VIEW_DESC
	/// structure or the <c>Dimension</c> member of the D3D11_SHADER_INPUT_BIND_DESC structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_srv_dimension typedef enum D3D_SRV_DIMENSION {
	// D3D_SRV_DIMENSION_UNKNOWN = 0, D3D_SRV_DIMENSION_BUFFER = 1, D3D_SRV_DIMENSION_TEXTURE1D = 2, D3D_SRV_DIMENSION_TEXTURE1DARRAY = 3,
	// D3D_SRV_DIMENSION_TEXTURE2D = 4, D3D_SRV_DIMENSION_TEXTURE2DARRAY = 5, D3D_SRV_DIMENSION_TEXTURE2DMS = 6,
	// D3D_SRV_DIMENSION_TEXTURE2DMSARRAY = 7, D3D_SRV_DIMENSION_TEXTURE3D = 8, D3D_SRV_DIMENSION_TEXTURECUBE = 9,
	// D3D_SRV_DIMENSION_TEXTURECUBEARRAY = 10, D3D_SRV_DIMENSION_BUFFEREX = 11, D3D10_SRV_DIMENSION_UNKNOWN, D3D10_SRV_DIMENSION_BUFFER,
	// D3D10_SRV_DIMENSION_TEXTURE1D, D3D10_SRV_DIMENSION_TEXTURE1DARRAY, D3D10_SRV_DIMENSION_TEXTURE2D, D3D10_SRV_DIMENSION_TEXTURE2DARRAY,
	// D3D10_SRV_DIMENSION_TEXTURE2DMS, D3D10_SRV_DIMENSION_TEXTURE2DMSARRAY, D3D10_SRV_DIMENSION_TEXTURE3D,
	// D3D10_SRV_DIMENSION_TEXTURECUBE, D3D10_1_SRV_DIMENSION_UNKNOWN, D3D10_1_SRV_DIMENSION_BUFFER, D3D10_1_SRV_DIMENSION_TEXTURE1D,
	// D3D10_1_SRV_DIMENSION_TEXTURE1DARRAY, D3D10_1_SRV_DIMENSION_TEXTURE2D, D3D10_1_SRV_DIMENSION_TEXTURE2DARRAY,
	// D3D10_1_SRV_DIMENSION_TEXTURE2DMS, D3D10_1_SRV_DIMENSION_TEXTURE2DMSARRAY, D3D10_1_SRV_DIMENSION_TEXTURE3D,
	// D3D10_1_SRV_DIMENSION_TEXTURECUBE, D3D10_1_SRV_DIMENSION_TEXTURECUBEARRAY, D3D11_SRV_DIMENSION_UNKNOWN, D3D11_SRV_DIMENSION_BUFFER,
	// D3D11_SRV_DIMENSION_TEXTURE1D, D3D11_SRV_DIMENSION_TEXTURE1DARRAY, D3D11_SRV_DIMENSION_TEXTURE2D, D3D11_SRV_DIMENSION_TEXTURE2DARRAY,
	// D3D11_SRV_DIMENSION_TEXTURE2DMS, D3D11_SRV_DIMENSION_TEXTURE2DMSARRAY, D3D11_SRV_DIMENSION_TEXTURE3D,
	// D3D11_SRV_DIMENSION_TEXTURECUBE, D3D11_SRV_DIMENSION_TEXTURECUBEARRAY, D3D11_SRV_DIMENSION_BUFFEREX } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_SRV_DIMENSION")]
	public enum D3D_SRV_DIMENSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The type is unknown.</para>
		/// </summary>
		D3D_SRV_DIMENSION_UNKNOWN = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The resource is a buffer.</para>
		/// </summary>
		D3D_SRV_DIMENSION_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The resource is a 1D texture.</para>
		/// </summary>
		D3D_SRV_DIMENSION_TEXTURE1D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The resource is an array of 1D textures.</para>
		/// </summary>
		D3D_SRV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The resource is a 2D texture.</para>
		/// </summary>
		D3D_SRV_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The resource is an array of 2D textures.</para>
		/// </summary>
		D3D_SRV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The resource is a multisampling 2D texture.</para>
		/// </summary>
		D3D_SRV_DIMENSION_TEXTURE2DMS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The resource is an array of multisampling 2D textures.</para>
		/// </summary>
		D3D_SRV_DIMENSION_TEXTURE2DMSARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The resource is a 3D texture.</para>
		/// </summary>
		D3D_SRV_DIMENSION_TEXTURE3D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>The resource is a cube texture.</para>
		/// </summary>
		D3D_SRV_DIMENSION_TEXTURECUBE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>The resource is an array of cube textures.</para>
		/// </summary>
		D3D_SRV_DIMENSION_TEXTURECUBEARRAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>The resource is a raw buffer. For more info about raw viewing of buffers, see</para>
		/// <para>Raw Views of Buffers</para>
		/// <para>.</para>
		/// </summary>
		D3D_SRV_DIMENSION_BUFFEREX,

		/// <summary>The type is unknown.</summary>
		D3D10_SRV_DIMENSION_UNKNOWN = D3D_SRV_DIMENSION_UNKNOWN,

		/// <summary>The resource is a buffer.</summary>
		D3D10_SRV_DIMENSION_BUFFER = D3D_SRV_DIMENSION_BUFFER,

		/// <summary>The resource is a 1D texture.</summary>
		D3D10_SRV_DIMENSION_TEXTURE1D = D3D_SRV_DIMENSION_TEXTURE1D,

		/// <summary>The resource is an array of 1D textures.</summary>
		D3D10_SRV_DIMENSION_TEXTURE1DARRAY = D3D_SRV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>The resource is a 2D texture.</summary>
		D3D10_SRV_DIMENSION_TEXTURE2D = D3D_SRV_DIMENSION_TEXTURE2D,

		/// <summary>The resource is an array of 2D textures.</summary>
		D3D10_SRV_DIMENSION_TEXTURE2DARRAY = D3D_SRV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>The resource is a multisampling 2D texture.</summary>
		D3D10_SRV_DIMENSION_TEXTURE2DMS = D3D_SRV_DIMENSION_TEXTURE2DMS,

		/// <summary>The resource is an array of multisampling 2D textures.</summary>
		D3D10_SRV_DIMENSION_TEXTURE2DMSARRAY = D3D_SRV_DIMENSION_TEXTURE2DMSARRAY,

		/// <summary>The resource is a 3D texture.</summary>
		D3D10_SRV_DIMENSION_TEXTURE3D = D3D_SRV_DIMENSION_TEXTURE3D,

		/// <summary>The resource is a cube texture.</summary>
		D3D10_SRV_DIMENSION_TEXTURECUBE = D3D_SRV_DIMENSION_TEXTURECUBE,

		/// <summary>The type is unknown.</summary>
		D3D10_1_SRV_DIMENSION_UNKNOWN = D3D_SRV_DIMENSION_UNKNOWN,

		/// <summary>The resource is a buffer.</summary>
		D3D10_1_SRV_DIMENSION_BUFFER = D3D_SRV_DIMENSION_BUFFER,

		/// <summary>The resource is a 1D texture.</summary>
		D3D10_1_SRV_DIMENSION_TEXTURE1D = D3D_SRV_DIMENSION_TEXTURE1D,

		/// <summary>The resource is an array of 1D textures.</summary>
		D3D10_1_SRV_DIMENSION_TEXTURE1DARRAY = D3D_SRV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>The resource is a 2D texture.</summary>
		D3D10_1_SRV_DIMENSION_TEXTURE2D = D3D_SRV_DIMENSION_TEXTURE2D,

		/// <summary>The resource is an array of 2D textures.</summary>
		D3D10_1_SRV_DIMENSION_TEXTURE2DARRAY = D3D_SRV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>The resource is a multisampling 2D texture.</summary>
		D3D10_1_SRV_DIMENSION_TEXTURE2DMS = D3D_SRV_DIMENSION_TEXTURE2DMS,

		/// <summary>The resource is an array of multisampling 2D textures.</summary>
		D3D10_1_SRV_DIMENSION_TEXTURE2DMSARRAY = D3D_SRV_DIMENSION_TEXTURE2DMSARRAY,

		/// <summary>The resource is a 3D texture.</summary>
		D3D10_1_SRV_DIMENSION_TEXTURE3D = D3D_SRV_DIMENSION_TEXTURE3D,

		/// <summary>The resource is a cube texture.</summary>
		D3D10_1_SRV_DIMENSION_TEXTURECUBE = D3D_SRV_DIMENSION_TEXTURECUBE,

		/// <summary>The resource is an array of cube textures.</summary>
		D3D10_1_SRV_DIMENSION_TEXTURECUBEARRAY = D3D_SRV_DIMENSION_TEXTURECUBEARRAY,

		/// <summary>The type is unknown.</summary>
		D3D11_SRV_DIMENSION_UNKNOWN = D3D_SRV_DIMENSION_UNKNOWN,

		/// <summary>The resource is a buffer.</summary>
		D3D11_SRV_DIMENSION_BUFFER = D3D_SRV_DIMENSION_BUFFER,

		/// <summary>The resource is a 1D texture.</summary>
		D3D11_SRV_DIMENSION_TEXTURE1D = D3D_SRV_DIMENSION_TEXTURE1D,

		/// <summary>The resource is an array of 1D textures.</summary>
		D3D11_SRV_DIMENSION_TEXTURE1DARRAY = D3D_SRV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>The resource is a 2D texture.</summary>
		D3D11_SRV_DIMENSION_TEXTURE2D = D3D_SRV_DIMENSION_TEXTURE2D,

		/// <summary>The resource is an array of 2D textures.</summary>
		D3D11_SRV_DIMENSION_TEXTURE2DARRAY = D3D_SRV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>The resource is a multisampling 2D texture.</summary>
		D3D11_SRV_DIMENSION_TEXTURE2DMS = D3D_SRV_DIMENSION_TEXTURE2DMS,

		/// <summary>The resource is an array of multisampling 2D textures.</summary>
		D3D11_SRV_DIMENSION_TEXTURE2DMSARRAY = D3D_SRV_DIMENSION_TEXTURE2DMSARRAY,

		/// <summary>The resource is a 3D texture.</summary>
		D3D11_SRV_DIMENSION_TEXTURE3D = D3D_SRV_DIMENSION_TEXTURE3D,

		/// <summary>The resource is a cube texture.</summary>
		D3D11_SRV_DIMENSION_TEXTURECUBE = D3D_SRV_DIMENSION_TEXTURECUBE,

		/// <summary>The resource is an array of cube textures.</summary>
		D3D11_SRV_DIMENSION_TEXTURECUBEARRAY = D3D_SRV_DIMENSION_TEXTURECUBEARRAY,
	}

	/// <summary>Domain options for tessellator data.</summary>
	/// <remarks>
	/// <para>The data domain defines the type of data. This enumeration is used by D3D11_SHADER_DESC.</para>
	/// <para>
	/// The <c>D3D11_TESSELLATOR_DOMAIN</c> enumeration is type defined in the D3D11Shader.h header file as a D3D_TESSELLATOR_DOMAIN
	/// enumeration, which is fully defined in the D3DCommon.h header file.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_tessellator_domain typedef enum D3D_TESSELLATOR_DOMAIN
	// { D3D_TESSELLATOR_DOMAIN_UNDEFINED = 0, D3D_TESSELLATOR_DOMAIN_ISOLINE = 1, D3D_TESSELLATOR_DOMAIN_TRI = 2,
	// D3D_TESSELLATOR_DOMAIN_QUAD = 3, D3D11_TESSELLATOR_DOMAIN_UNDEFINED, D3D11_TESSELLATOR_DOMAIN_ISOLINE, D3D11_TESSELLATOR_DOMAIN_TRI,
	// D3D11_TESSELLATOR_DOMAIN_QUAD } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_TESSELLATOR_DOMAIN")]
	public enum D3D_TESSELLATOR_DOMAIN
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// </summary>
		D3D_TESSELLATOR_DOMAIN_UNDEFINED = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// </summary>
		D3D_TESSELLATOR_DOMAIN_ISOLINE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// </summary>
		D3D_TESSELLATOR_DOMAIN_TRI,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// </summary>
		D3D_TESSELLATOR_DOMAIN_QUAD,

		/// <summary>The data type is undefined.</summary>
		D3D11_TESSELLATOR_DOMAIN_UNDEFINED = D3D_TESSELLATOR_DOMAIN_UNDEFINED,

		/// <summary>Isoline data.</summary>
		D3D11_TESSELLATOR_DOMAIN_ISOLINE = D3D_TESSELLATOR_DOMAIN_ISOLINE,

		/// <summary>Triangle data.</summary>
		D3D11_TESSELLATOR_DOMAIN_TRI = D3D_TESSELLATOR_DOMAIN_TRI,

		/// <summary>Quad data.</summary>
		D3D11_TESSELLATOR_DOMAIN_QUAD = D3D_TESSELLATOR_DOMAIN_QUAD,
	}

	/// <summary>Output primitive types.</summary>
	/// <remarks>
	/// <para>The output primitive type determines how the tessellator output data is organized; this enumeration is used by D3D11_SHADER_DESC.</para>
	/// <para>
	/// The <c>D3D11_TESSELLATOR_OUTPUT_PRIMITIVE</c> enumeration is type defined in the D3D11Shader.h header file as a
	/// D3D_TESSELLATOR_OUTPUT_PRIMITIVE enumeration, which is fully defined in the D3DCommon.h header file.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_tessellator_output_primitive typedef enum
	// D3D_TESSELLATOR_OUTPUT_PRIMITIVE { D3D_TESSELLATOR_OUTPUT_UNDEFINED = 0, D3D_TESSELLATOR_OUTPUT_POINT = 1,
	// D3D_TESSELLATOR_OUTPUT_LINE = 2, D3D_TESSELLATOR_OUTPUT_TRIANGLE_CW = 3, D3D_TESSELLATOR_OUTPUT_TRIANGLE_CCW = 4,
	// D3D11_TESSELLATOR_OUTPUT_UNDEFINED, D3D11_TESSELLATOR_OUTPUT_POINT, D3D11_TESSELLATOR_OUTPUT_LINE,
	// D3D11_TESSELLATOR_OUTPUT_TRIANGLE_CW, D3D11_TESSELLATOR_OUTPUT_TRIANGLE_CCW } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_TESSELLATOR_OUTPUT_PRIMITIVE")]
	public enum D3D_TESSELLATOR_OUTPUT_PRIMITIVE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// </summary>
		D3D_TESSELLATOR_OUTPUT_UNDEFINED = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// </summary>
		D3D_TESSELLATOR_OUTPUT_POINT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// </summary>
		D3D_TESSELLATOR_OUTPUT_LINE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// </summary>
		D3D_TESSELLATOR_OUTPUT_TRIANGLE_CW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// </summary>
		D3D_TESSELLATOR_OUTPUT_TRIANGLE_CCW,

		/// <summary>The output primitive type is undefined.</summary>
		D3D11_TESSELLATOR_OUTPUT_UNDEFINED = D3D_TESSELLATOR_OUTPUT_UNDEFINED,

		/// <summary>The output primitive type is a point.</summary>
		D3D11_TESSELLATOR_OUTPUT_POINT = D3D_TESSELLATOR_OUTPUT_POINT,

		/// <summary>The output primitive type is a line.</summary>
		D3D11_TESSELLATOR_OUTPUT_LINE = D3D_TESSELLATOR_OUTPUT_LINE,

		/// <summary>The output primitive type is a clockwise triangle.</summary>
		D3D11_TESSELLATOR_OUTPUT_TRIANGLE_CW = D3D_TESSELLATOR_OUTPUT_TRIANGLE_CW,

		/// <summary>The output primitive type is a counter clockwise triangle.</summary>
		D3D11_TESSELLATOR_OUTPUT_TRIANGLE_CCW = D3D_TESSELLATOR_OUTPUT_TRIANGLE_CCW,
	}

	/// <summary>Partitioning options.</summary>
	/// <remarks>
	/// <para>
	/// During tessellation, the partition option helps to determine how the algorithm chooses the next partition value; this enumeration is
	/// used by D3D11_SHADER_DESC.
	/// </para>
	/// <para>
	/// The <c>D3D11_TESSELLATOR_PARTITIONING</c> enumeration is type defined in the D3D11Shader.h header file as a
	/// D3D_TESSELLATOR_PARTITIONING enumeration, which is fully defined in the D3DCommon.h header file.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_tessellator_partitioning typedef enum
	// D3D_TESSELLATOR_PARTITIONING { D3D_TESSELLATOR_PARTITIONING_UNDEFINED = 0, D3D_TESSELLATOR_PARTITIONING_INTEGER = 1,
	// D3D_TESSELLATOR_PARTITIONING_POW2 = 2, D3D_TESSELLATOR_PARTITIONING_FRACTIONAL_ODD = 3, D3D_TESSELLATOR_PARTITIONING_FRACTIONAL_EVEN
	// = 4, D3D11_TESSELLATOR_PARTITIONING_UNDEFINED, D3D11_TESSELLATOR_PARTITIONING_INTEGER, D3D11_TESSELLATOR_PARTITIONING_POW2,
	// D3D11_TESSELLATOR_PARTITIONING_FRACTIONAL_ODD, D3D11_TESSELLATOR_PARTITIONING_FRACTIONAL_EVEN } ;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon.D3D_TESSELLATOR_PARTITIONING")]
	public enum D3D_TESSELLATOR_PARTITIONING
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// </summary>
		D3D_TESSELLATOR_PARTITIONING_UNDEFINED = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// </summary>
		D3D_TESSELLATOR_PARTITIONING_INTEGER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// </summary>
		D3D_TESSELLATOR_PARTITIONING_POW2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// </summary>
		D3D_TESSELLATOR_PARTITIONING_FRACTIONAL_ODD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// </summary>
		D3D_TESSELLATOR_PARTITIONING_FRACTIONAL_EVEN,

		/// <summary>The partitioning type is undefined.</summary>
		D3D11_TESSELLATOR_PARTITIONING_UNDEFINED = D3D_TESSELLATOR_PARTITIONING_UNDEFINED,

		/// <summary>Partition with integers only.</summary>
		D3D11_TESSELLATOR_PARTITIONING_INTEGER = D3D_TESSELLATOR_PARTITIONING_INTEGER,

		/// <summary>Partition with a power-of-two number only.</summary>
		D3D11_TESSELLATOR_PARTITIONING_POW2 = D3D_TESSELLATOR_PARTITIONING_POW2,

		/// <summary>Partition with an odd, fractional number.</summary>
		D3D11_TESSELLATOR_PARTITIONING_FRACTIONAL_ODD = D3D_TESSELLATOR_PARTITIONING_FRACTIONAL_ODD,

		/// <summary>Partition with an even, fractional number.</summary>
		D3D11_TESSELLATOR_PARTITIONING_FRACTIONAL_EVEN = D3D_TESSELLATOR_PARTITIONING_FRACTIONAL_EVEN,
	}

	/// <summary>
	/// <note>Some information relates to pre-released product, which may be substantially modified before it's commercially released.
	/// Microsoft makes no warranties, express or implied, with respect to the information provided here.</note>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ne-dcommon-dwrite_glyph_image_formats typedef enum
	// DWRITE_GLYPH_IMAGE_FORMATS { DWRITE_GLYPH_IMAGE_FORMATS_NONE = 0x00000000, DWRITE_GLYPH_IMAGE_FORMATS_TRUETYPE = 0x00000001,
	// DWRITE_GLYPH_IMAGE_FORMATS_CFF = 0x00000002, DWRITE_GLYPH_IMAGE_FORMATS_COLR = 0x00000004, DWRITE_GLYPH_IMAGE_FORMATS_SVG =
	// 0x00000008, DWRITE_GLYPH_IMAGE_FORMATS_PNG = 0x00000010, DWRITE_GLYPH_IMAGE_FORMATS_JPEG = 0x00000020,
	// DWRITE_GLYPH_IMAGE_FORMATS_TIFF = 0x00000040, DWRITE_GLYPH_IMAGE_FORMATS_PREMULTIPLIED_B8G8R8A8 = 0x00000080,
	// DWRITE_GLYPH_IMAGE_FORMATS_COLR_PAINT_TREE = 0x00000100 } ;
	[PInvokeData("dcommon.h", MSDNShortId = "NE:dcommon.DWRITE_GLYPH_IMAGE_FORMATS")]
	[Flags]
	public enum DWRITE_GLYPH_IMAGE_FORMATS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000000</para>
		/// <para>Specifies that no data is available for this glyph.</para>
		/// </summary>
		DWRITE_GLYPH_IMAGE_FORMATS_NONE = 0x0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000001</para>
		/// <para>Specifies that the glyph has TrueType outlines.</para>
		/// </summary>
		DWRITE_GLYPH_IMAGE_FORMATS_TRUETYPE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000002</para>
		/// <para>Specifies that the glyph has CFF outlines.</para>
		/// </summary>
		DWRITE_GLYPH_IMAGE_FORMATS_CFF = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000004</para>
		/// <para>Specifies that the glyph has multilayered COLR data.</para>
		/// </summary>
		DWRITE_GLYPH_IMAGE_FORMATS_COLR = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000008</para>
		/// <para>
		/// Specifies that the glyph has SVG outlines as standard XML. Fonts may store the content gzip'd rather than plain text, indicated
		/// by the first two bytes as gzip header {0x1F 0x8B}.
		/// </para>
		/// </summary>
		DWRITE_GLYPH_IMAGE_FORMATS_SVG = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000010</para>
		/// <para>Specifies that the glyph has PNG image data, with standard PNG IHDR.</para>
		/// </summary>
		DWRITE_GLYPH_IMAGE_FORMATS_PNG = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000020</para>
		/// <para>Specifies that the glyph has JPEG image data, with standard JIFF SOI header.</para>
		/// </summary>
		DWRITE_GLYPH_IMAGE_FORMATS_JPEG = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000040</para>
		/// <para>Specifies that the glyph has TIFF image data.</para>
		/// </summary>
		DWRITE_GLYPH_IMAGE_FORMATS_TIFF = 0x40,
	
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000080</para>
		/// <para>Specifies that the glyph has raw 32-bit premultiplied BGRA data.</para>
		/// </summary>
		DWRITE_GLYPH_IMAGE_FORMATS_PREMULTIPLIED_B8G8R8A8 = 0x80,
	
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000100</para>
		/// <para>
		/// <para>IMPORTANT</para>
		/// <para>
		/// The <b>DWRITE_GLYPH_IMAGE_FORMATS_COLR_PAINT_TREE</b> constant is available in pre-release versions of the <c>Windows Insider
		/// Preview</c>.Specifies that the glyph is represented by a tree of paint elements in the font's COLR table.
		/// </para>
		/// </para>
		/// </summary>
		DWRITE_GLYPH_IMAGE_FORMATS_COLR_PAINT_TREE = 0x100,
	}

	/// <summary>Indicates the measuring method used for text layout.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ne-dcommon-dwrite_measuring_mode typedef enum DWRITE_MEASURING_MODE {
	// DWRITE_MEASURING_MODE_NATURAL, DWRITE_MEASURING_MODE_GDI_CLASSIC, DWRITE_MEASURING_MODE_GDI_NATURAL } ;
	[PInvokeData("dcommon.h", MSDNShortId = "NE:dcommon.DWRITE_MEASURING_MODE")]
	public enum DWRITE_MEASURING_MODE
	{
		/// <summary>Specifies that text is measured using glyph ideal metrics whose values are independent to the current display resolution.</summary>
		DWRITE_MEASURING_MODE_NATURAL,

		/// <summary>
		/// Specifies that text is measured using glyph display-compatible metrics whose values tuned for the current display resolution.
		/// </summary>
		DWRITE_MEASURING_MODE_GDI_CLASSIC,

		/// <summary>
		/// Specifies that text is measured using the same glyph display metrics as text measured by GDI using a font created with CLEARTYPE_NATURAL_QUALITY.
		/// </summary>
		DWRITE_MEASURING_MODE_GDI_NATURAL,
	}
	
	/// <summary>This interface is used to return arbitrary-length data.</summary>
	/// <remarks>
	/// <para>
	/// The ID3DBlob interface is type-defined in the D3DCommon.h header file as a <c>ID3D10Blob</c> interface, which is fully defined in
	/// the D3DCommon.h header file. <c>ID3DBlob</c> is version-neutral and can be used in code for any Direct3D version.
	/// </para>
	/// <para>
	/// Blobs can be used as a data buffer, storing vertex, adjacency, and material information during mesh optimization and loading
	/// operations. Also, these objects are used to return object code and error messages in APIs that compile vertex, geometry and pixel shaders.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nn-d3dcommon-id3d10blob
	[PInvokeData("d3dcommon.h", MSDNShortId = "NN:d3dcommon.ID3D10Blob"), ComImport, Guid("8BA5FB08-5195-40e2-AC58-0D989C3A0102"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3DBlob
	{
		/// <summary>Gets a pointer to the data.</summary>
		/// <returns>
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>Returns a pointer.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3d10blob-getbufferpointer LPVOID GetBufferPointer();
		[PreserveSig]
		IntPtr GetBufferPointer();

		/// <summary>Gets the size.</summary>
		/// <returns>
		/// <para>Type: <c>SizeT</c></para>
		/// <para>The size of the data, in bytes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3d10blob-getbuffersize SizeT GetBufferSize();
		[PreserveSig]
		SizeT GetBufferSize();
	}

	/// <summary>
	/// <para>
	/// <c>ID3DDestructionNotifier</c> is an interface that you can use to register for callbacks when a Direct3D nano-COM object is destroyed.
	/// </para>
	/// <para>To acquire an instance of this interface, call on a Direct3D object with the <c>IID</c> of <c>ID3DDestructionNotifier</c>.</para>
	/// <para>
	/// Using <c>ID3DDestructionNotifier</c> instead of <c>ID3D12Object::SetPrivateDataInterface</c> or Direct3D 11 equivalents provides
	/// stronger guarantees about the order of destruction. With <c>ID3DDestructionNotifier</c>, implicit relationships—such as an
	/// <c>ID3D11View</c> holding a reference to its underlying <c>ID3D11Resource</c>—are guaranteed to be valid and for the referenced
	/// object (here, the <c>ID3D11Object</c>) to still be alive when the destruction callback is invoked. With
	/// <c>ID3D12Object::SetPrivateDataInterface</c>, the implicit references can be released before the destruction callback is invoked.
	/// </para>
	/// <para>It isn't safe to access the object being destructed during the callback.</para>
	/// </summary>
	/// <remarks>
	/// The <c>ID3DDestructionNotifier</c> can be used to track resources which are being unexpectedly released early, or providing a log of
	/// object disposal.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nn-d3dcommon-id3ddestructionotifier
	[PInvokeData("d3dcommon.h", MSDNShortId = "NN:d3dcommon.ID3DDestructionNotifier"), ComImport, Guid("a06eb39a-50da-425b-8c31-4eecd6c270f3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3DDestructionNotifier
	{
		/// <summary>
		/// Registers a user-defined callback to be invoked on destruction of the object from which this ID3DDestructionNotifier was created.
		/// </summary>
		/// <param name="callbackFn">
		/// <para>Type: <c>PFN_DESTRUCTION_CALLBACK</c></para>
		/// <para>A user-defined callback to be invoked when the object is destroyed.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>The data to pass to callbackFn when invoked</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer to a <c>UINT</c> used to identify the callback, and to pass to to unregister the callback.</para>
		/// </returns>
		/// <remarks>An example of this interface being used to log the destruction of an <c>ID3D12Resource</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3ddestructionotifier-registerdestructioncallback
		// HRESULT RegisterDestructionCallback( PFN_DESTRUCTION_CALLBACK callbackFn, void *pData, UINT *pCallbackID );
		uint RegisterDestructionCallback([In] PFN_DESTRUCTION_CALLBACK callbackFn, [In, Optional] IntPtr pData);

		/// <summary>Unregisters a callback that was registered with RegisterDestructionCallback.</summary>
		/// <param name="callbackID">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The <c>UINT</c> that was created by the pCallbackID argument to <c>ID3DDestructionNotifier::RegisterDestructionCallback</c>.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3ddestructionotifier-unregisterdestructioncallback
		// HRESULT UnregisterDestructionCallback( UINT callbackID );
		void UnregisterDestructionCallback(uint callbackID);
	}

	/// <summary>
	/// <c>ID3DInclude</c> is an include interface that the user implements to allow an application to call user-overridable methods for
	/// opening and closing shader #include files.
	/// </summary>
	/// <remarks>
	/// To use this interface, create an interface that inherits from <c>ID3DInclude</c> and implement custom behavior for the methods.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nn-d3dcommon-id3dinclude
	[PInvokeData("d3dcommon.h", MSDNShortId = "NN:d3dcommon.ID3DInclude")]
	public interface ID3DInclude
	{
		/// <summary>A user-implemented method for closing a shader #include file.</summary>
		/// <param name="pData">
		/// <para>Type: <c>LPCVOID</c></para>
		/// <para>
		/// Pointer to the buffer that contains the include directives. This is the pointer that was returned by the corresponding
		/// ID3DInclude::Open call.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// The user-implemented <c>Close</c> method should return S_OK. If <c>Close</c> fails when it closes the #include file, the
		/// application programming interface (API) that caused <c>Close</c> to be called fails. This failure can occur in one of the
		/// following situations:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The high-level shader language (HLSL) shader fails one of the <c>D3D10CompileShader***</c> functions.</description>
		/// </item>
		/// <item>
		/// <description>The effect fails one of the <c>D3D10CreateEffect***</c> functions.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If ID3DInclude::Open was successful, <c>Close</c> is guaranteed to be called before the API using the ID3DInclude interface returns.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3dinclude-close HRESULT Close( LPCVOID pData );
		[PreserveSig]
		HRESULT Close(IntPtr pData);

		/// <summary>A user-implemented method for opening and reading the contents of a shader #include file.</summary>
		/// <param name="IncludeType">
		/// <para>Type: <c>D3D_INCLUDE_TYPE</c></para>
		/// <para>A D3D_INCLUDE_TYPE-typed value that indicates the location of the #include file.</para>
		/// </param>
		/// <param name="pFileName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>Name of the #include file.</para>
		/// </param>
		/// <param name="pParentData">
		/// <para>Type: <c>LPCVOID</c></para>
		/// <para>
		/// Pointer to the container that includes the #include file. The compiler might pass NULL in <c>pParentData</c>. For more
		/// information, see the "Searching for Include Files" section in Compile an Effect (Direct3D 11).
		/// </para>
		/// </param>
		/// <param name="ppData">
		/// <para>Type: <c>LPCVOID*</c></para>
		/// <para>Pointer to the buffer that contains the include directives. This pointer remains valid until you call ID3DInclude::Close.</para>
		/// </param>
		/// <param name="pBytes">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer to the number of bytes that <c>Open</c> returns in <c>ppData</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// The user-implemented method must return S_OK. If <c>Open</c> fails when it reads the #include file, the application programming
		/// interface (API) that caused <c>Open</c> to be called fails. This failure can occur in one of the following situations:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The high-level shader language (HLSL) shader fails one of the <c>D3D10CompileShader***</c> functions.</description>
		/// </item>
		/// <item>
		/// <description>The effect fails one of the <c>D3D10CreateEffect***</c> functions.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3dinclude-open HRESULT Open( D3D_INCLUDE_TYPE
		// IncludeType, LPCSTR pFileName, LPCVOID pParentData, LPCVOID *ppData, UINT *pBytes );
		[PreserveSig]
		HRESULT Open(D3D_INCLUDE_TYPE IncludeType, [MarshalAs(UnmanagedType.LPStr)] string pFileName, [Optional] IntPtr pParentData,
			out IntPtr ppData, out uint pBytes);
	}

	/// <summary>Represents a 3-by-2 matrix.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_matrix_3x2_f typedef struct D2D_MATRIX_3X2_F { union {
	// struct { FLOAT m11; FLOAT m12; FLOAT m21; FLOAT m22; FLOAT dx; FLOAT dy; }; struct { FLOAT m11; FLOAT _12; FLOAT _21; FLOAT _22;
	// FLOAT _31; FLOAT _32; }; FLOAT m[3, 2]; }; } D2D_MATRIX_3X2_F;
	[PInvokeData("dcommon.h", MSDNShortId = "c8a54bad-4376-479b-8529-1e407623e473"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_MATRIX_3X2_F(float m11 = 0f, float m12 = 0f, float m21 = 0f, float m22 = 0f, float m31 = 0f, float m32 = 0f) : IEquatable<DXGI_MATRIX_3X2_F>
	{
		/// <summary>The value in the first row and first column of the matrix.</summary>
		public float _11 = m11;

		/// <summary>The value in the first row and second column of the matrix.</summary>
		public float _12 = m12;

		/// <summary>The value in the second row and first column of the matrix.</summary>
		public float _21 = m21;

		/// <summary>The value in the second row and second column of the matrix.</summary>
		public float _22 = m22;

		/// <summary>The value in the third row and first column of the matrix.</summary>
		public float _31 = m31;

		/// <summary>The value in the third row and second column of the matrix.</summary>
		public float _32 = m32;

		/// <summary>Horizontal scaling / cosine of rotation</summary>
		public float m11 { get => _11; set => _11 = value; }

		/// <summary>Vertical shear / sine of rotation</summary>
		public float m12 { get => _12; set => _12 = value; }

		/// <summary>Horizontal shear / negative sine of rotation</summary>
		public float m21 { get => _21; set => _21 = value; }

		/// <summary>Vertical scaling / cosine of rotation</summary>
		public float m22 { get => _22; set => _22 = value; }

		/// <summary>Horizontal shift (always orthogonal regardless of rotation)</summary>
		public float dx { get => _31; set => _31 = value; }

		/// <summary>Vertical shift (always orthogonal regardless of rotation)</summary>
		public float dy { get => _32; set => _32 = value; }

		/// <summary>Gets or sets the values as a multidimensional (3x2) array.</summary>
		/// <value>The array value.</value>
		/// <exception cref="ArgumentOutOfRangeException">m - Value must a 3x2 array.</exception>
		public float[,] m
		{
			get => new[,] { { m11, m12 }, { m21, m22 }, { dx, dy } };
			set
			{
				if (value.GetLength(0) != 3 || value.GetLength(1) != 2)
					throw new ArgumentOutOfRangeException(nameof(m), "Value must a 3x2 array.");
				m11 = value[0, 0];
				m12 = value[0, 1];
				m21 = value[1, 0];
				m22 = value[1, 1];
				dx = value[2, 0];
				dy = value[2, 1];
			}
		}

		/// <summary>Calculates the determinant of the matrix.</summary>
		/// <value>The determinant of this matrix.</value>
		public float Determinant => _11 * _22 - _12 * _21;

		/// <summary>Indicates whether this matrix is the identity matrix.</summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para><b>true</b> if the matrix is an identity matrix; otherwise, <b>false</b>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-matrix3x2f-isidentity
		// bool IsIdentity();
		[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.Matrix3x2F.IsIdentity")]
		public bool IsIdentity => Equals(Identity());

		/// <summary>Indicates whether the matrix is invertible.</summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>true if the matrix is invertible; otherwise, false.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-matrix3x2f-isinvertible
		// bool IsInvertible();
		[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.Matrix3x2F.IsInvertible")]
		public bool IsInvertible => Determinant != 0f;

		/// <summary>Performs an implicit conversion from <see cref="float"/>[,] to <see cref="D2D_MATRIX_3X2_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_3X2_F(float[,] value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_3X2_F"/> to <see cref="float"/>[,].</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[,](D2D_MATRIX_3X2_F value) => value.m;

		/// <summary>Performs an implicit conversion from <see cref="Matrix"/> to <see cref="D2D_MATRIX_3X2_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_3X2_F(Matrix value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_3X2_F"/> to <see cref="Matrix"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Matrix(D2D_MATRIX_3X2_F value) => new(value.m);

		/// <summary>Multiplies two matrices together to compute the product.</summary>
		/// <param name="a">The first matrix.</param>
		/// <param name="b">The second matrix.</param>
		/// <returns>The product matrix.</returns>
		public static DXGI_MATRIX_3X2_F operator *(DXGI_MATRIX_3X2_F a, DXGI_MATRIX_3X2_F b) => new(
			a._11 * b._11 + a._12* b._21,
			a._11 * b._12 + a._12 * b._22,
			a._21 * b._11 + a._22 * b._21,
			a._21 * b._12 + a._22 * b._22,
			a._31 * b._11 + a._32 * b._21 + b._31,
			a._31 * b._12 + a._32 * b._22 + b._32);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left comparible.</param>
		/// <param name="right">The right comparible.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(DXGI_MATRIX_3X2_F left, DXGI_MATRIX_3X2_F right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left comparible.</param>
		/// <param name="right">The right comparible.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(DXGI_MATRIX_3X2_F left, DXGI_MATRIX_3X2_F right) => !(left == right);

		/// <summary>Creates an identity matrix.</summary>
		/// <returns>An identity matrix.</returns>
		/// <remarks>
		/// The identity matrix is the 3x2 matrix with ones on the main diagonal and zeros elsewhere. When an identity transform is applied
		/// to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number
		/// by 1 does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.
		/// </remarks>
		public static D2D_MATRIX_3X2_F Identity() => new() { _11 = 1, _22 = 1 };

		/// <summary>Creates a rotation transformation that has the specified angle and center point.</summary>
		/// <param name="angle">The rotation angle in degrees. A positive angle creates a clockwise rotation, and a negative angle creates a counterclockwise rotation.</param>
		/// <param name="center">The point about which the rotation is performed.</param>
		/// <returns>The new rotation transformation.</returns>
		public static D2D_MATRIX_3X2_F Rotation(float angle, D2D_POINT_2F center = default)
		{
			D2D1MakeRotateMatrix(angle, center, out var m);
			return m;

			[DllImport("d2d1.dll", SetLastError = false, ExactSpelling = true)]
			static extern void D2D1MakeRotateMatrix([In] float angle, [In] D2D_POINT_2F center, out D2D_MATRIX_3X2_F matrix);
		}

		/// <summary>Creates a scale transformation that has the specified scale factors and center point.</summary>
		/// <param name="width">The angle-axis scale factor of the scale transformation.</param>
		/// <param name="height">The y-axis scale factor of the scale transformation.</param>
		/// <param name="x">The angle-coordinate of the point about which the scale is performed.</param>
		/// <param name="y">The y-coordinate of the point about which the scale is performed.</param>
		/// <returns>The new scale transformation.</returns>
		/// <remarks>
		/// <para>
		/// This method creates a scale transformation for the specified centerPoint and the angle-axis and y-axis scale factors. If you prefer
		/// to create a D2D1_SIZE_F structure to store the scale factors, call the other Scale method.
		/// </para>
		/// <para>
		/// The following illustration shows the size of the square increased to 130% in both dimensions. The center point of the scaling is
		/// the upper-left corner of the square.
		/// </para>
		/// </remarks>
		public static D2D_MATRIX_3X2_F Scale(float width, float height, float x = 0f, float y = 0f) => new() { _11 = width, _22 = height, _31 = x - width * x, _32 = y - height * y };

		/// <summary>Creates a skew transformation that has the specified x-axis and y-axis values and center point.</summary>
		/// <param name="angleX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The x-axis skew angle, which is measured in degrees counterclockwise from the y-axis.</para>
		/// </param>
		/// <param name="angleY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The y-axis skew angle, which is measured in degrees clockwise from the x-axis.</para>
		/// </param>
		/// <param name="center">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The point about which the skew is performed.</para>
		/// </param>
		/// <returns>The new skew transformation.</returns>
		/// <remarks>
		/// The typical y-axis skew means skews the angle in degrees counterclockwise from the x-axis. However, because the y-axis in
		/// Direct2D is inverted, the y-axis skew angle in Direct2D means skew the angle in degrees clockwise from the x-axis.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-matrix3x2f-skew Matrix3x2F Skew( FLOAT angleX, FLOAT
		// angleY, D2D1_POINT_2F center );
		[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.Matrix3x2F.Skew")]
		public static D2D_MATRIX_3X2_F Skew(float angleX, float angleY, D2D_POINT_2F center = default)
		{
			D2D1MakeSkewMatrix(angleX, angleY, center, out var m);
			return m;

			[DllImport("d2d1.dll", SetLastError = false, ExactSpelling = true)]
			static extern void D2D1MakeSkewMatrix([In] float angleX, [In] float angleY, [In] D2D_POINT_2F center, out D2D_MATRIX_3X2_F matrix);
		}

		/// <summary>Creates a translation transformation that has the specified angle and y displacements.</summary>
		/// <param name="x">The distance to translate along the angle-axis.</param>
		/// <param name="y">The distance to translate along the y-axis.</param>
		/// <returns>A transformation matrix that translates an object the specified horizontal and vertical distance.</returns>
		public static D2D_MATRIX_3X2_F Translation(float x, float y) => new() { _11 = 1, _22 = 1, _31 = x, _32 = y };

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is DXGI_MATRIX_3X2_F f && Equals(f);

		/// <inheritdoc/>
		public bool Equals(DXGI_MATRIX_3X2_F other) => _11 == other._11 && _12 == other._12 && _21 == other._21 && _22 == other._22 && _31 == other._31 && _32 == other._32;

		/// <inheritdoc/>
		public override int GetHashCode() => m.GetHashCode();

		/// <summary>Tries to invert the matrix.</summary>
		/// <returns><see langword="true" /> if the matrix was inverted; otherwise, <see langword="false" />.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-d2d1invertmatrix
		[PInvokeData("d2d1.h", MSDNShortId = "NF:d2d1.D2D1InvertMatrix")]
		public bool Invert()
		{
			var det = Determinant;
			if (det == 0 || Math.Abs(det) < float.Epsilon)
				return false;

			float invDet = 1.0f / det;
			this = new D2D_MATRIX_3X2_F(_22 * invDet, -_12 * invDet, -_21 * invDet, _11 * invDet,
				(_21 * _32 - _31 * _22) * invDet, (_31 * _12 - _11 * _32) * invDet);
			return true;
		}

		/// <summary>Uses this matrix to transform the specified point and returns the result.</summary>
		/// <param name="point">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The point to transform.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The transformed point.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-matrix3x2f-transformpoint
		// D2D1_POINT_2F TransformPoint( D2D1_POINT_2F point );
		[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.Matrix3x2F.TransformPoint")]
		public D2D_POINT_2F TransformPoint(in D2D_POINT_2F point) => new() { x = point.x * _11 + point.y * _21 + _31, y = point.x * _12 + point.y * _22 + _32 };
	}

	/// <summary>Describes a 4-by-3 floating point matrix.</summary>
	/// <remarks>The <c>D2D1_MATRIX_4X3_F</c> structure is type defined from a <c>D2D_MATRIX_4X3_F</c> structure in D2d1_1.h.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_matrix_4x3_f
	// typedef struct D2D_MATRIX_4X3_F { union { struct { FLOAT m11; FLOAT _12; FLOAT _13; FLOAT _21; FLOAT _22; FLOAT _23; FLOAT _31; FLOAT _32; FLOAT _33; FLOAT _41; FLOAT _42; FLOAT _43; } DUMMYSTRUCTNAME; FLOAT m[4, 3]; } DUMMYUNIONNAME; } D2D_MATRIX_4X3_F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_MATRIX_4X3_F"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_MATRIX_4X3_F
	{
		/// <summary/>
		public float _11;

		/// <summary/>	;
		public float _12;

		/// <summary/>	;
		public float _13;

		/// <summary/>	;
		public float _21;

		/// <summary/>	;
		public float _22;

		/// <summary/>	;
		public float _23;

		/// <summary/>	;
		public float _31;

		/// <summary/>	;
		public float _32;

		/// <summary/>	;
		public float _33;

		/// <summary/>	;
		public float _41;

		/// <summary/>	;
		public float _42;

		/// <summary/>	;
		public float _43;

		/// <summary/>
		public float[,] m
		{
			get => new[,] { { _11, _12, _13 }, { _21, _22, _23 }, { _31, _32, _33 }, { _41, _42, _43 } };
			set
			{
				unsafe
				{
					if (value.GetLength(0) != 4 || value.GetLength(1) != 3)
						throw new ArgumentOutOfRangeException(nameof(m), "Value must a 4x3 array.");
					_11 = value[0, 0];
					_12 = value[0, 1];
					_13 = value[0, 2];
					_21 = value[1, 0];
					_22 = value[1, 1];
					_23 = value[1, 2];
					_31 = value[2, 0];
					_32 = value[2, 1];
					_33 = value[2, 2];
					_41 = value[3, 0];
					_42 = value[3, 1];
					_43 = value[3, 2];
				}
			}
		}

		/// <summary>Performs an implicit conversion from <see cref="float"/>[,] to <see cref="D2D_MATRIX_4X3_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_4X3_F(float[,] value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_4X3_F"/> to <see cref="float"/>[,].</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[,](D2D_MATRIX_4X3_F value) => value.m;

		/// <summary>Performs an implicit conversion from <see cref="Matrix"/> to <see cref="D2D_MATRIX_4X3_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_4X3_F(Matrix value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_4X3_F"/> to <see cref="Matrix"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Matrix(D2D_MATRIX_4X3_F value) => new(value.m);
	}

	/// <summary>Describes a 4-by-4 floating point matrix.</summary>
	/// <remarks>The <c>D2D1_MATRIX_4X4_F</c> structure is type defined from a <c>D2D_MATRIX_4X4_F</c> structure in D2d1_1.h.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_matrix_4x4_f
	// typedef struct D2D_MATRIX_4X4_F { union { struct { FLOAT _11; FLOAT _12; FLOAT _13; FLOAT _14; FLOAT _21; FLOAT _22; FLOAT _23; FLOAT _24; FLOAT _31; FLOAT _32; FLOAT _33; FLOAT _34; FLOAT _41; FLOAT _42; FLOAT _43; FLOAT _44; } DUMMYSTRUCTNAME; FLOAT m[4, 4]; } DUMMYUNIONNAME; } D2D_MATRIX_4X4_F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_MATRIX_4X4_F"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_MATRIX_4X4_F : IEquatable<D2D_MATRIX_4X4_F>
	{
		/// <summary/>
		public float _11;

		/// <summary/>	;
		public float _12;

		/// <summary/>	;
		public float _13;

		/// <summary/>	;
		public float _14;

		/// <summary/>	;
		public float _21;

		/// <summary/>	;
		public float _22;

		/// <summary/>	;
		public float _23;

		/// <summary/>	;
		public float _24;

		/// <summary/>	;
		public float _31;

		/// <summary/>	;
		public float _32;

		/// <summary/>	;
		public float _33;

		/// <summary/>	;
		public float _34;

		/// <summary/>	;
		public float _41;

		/// <summary/>	;
		public float _42;

		/// <summary/>	;
		public float _43;

		/// <summary/>	;
		public float _44;

		/// <summary>Calculates the determinant of the matrix.</summary>
		/// <returns>
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The determinant.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1helper/nf-d2d1_1helper-matrix4x4f-determinant
		// FLOAT Determinant();
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.Determinant")]
		public float Determinant => new Matrix(m).Determinant;

		/// <summary>Indicates whether this matrix is the identity matrix.</summary>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Indicates whether this matrix is the identity matrix.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1helper/nf-d2d1_1helper-matrix4x4f-isidentity
		// bool IsIdentity();
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.IsIdentity")]
		public bool IsIdentity => new Matrix(m).IsIdentity;

		/// <summary/>
		public float[,] m
		{
			get => new[,] { { _11, _12, _13, _14 }, { _21, _22, _23, _24 }, { _31, _32, _33, _34 }, { _41, _42, _43, _44 } };
			set
			{
				if (value.GetLength(0) != 4 || value.GetLength(1) != 4)
					throw new ArgumentOutOfRangeException(nameof(m), "Value must a 4x4 array.");
				_11 = value[0, 0];
				_12 = value[0, 1];
				_13 = value[0, 2];
				_14 = value[0, 3];
				_21 = value[1, 0];
				_22 = value[1, 1];
				_23 = value[1, 2];
				_24 = value[1, 3];
				_31 = value[2, 0];
				_32 = value[2, 1];
				_33 = value[2, 2];
				_34 = value[2, 3];
				_41 = value[3, 0];
				_42 = value[3, 1];
				_43 = value[3, 2];
				_44 = value[3, 3];
			}
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D2D_MATRIX_4X4_F f && Equals(f);

		/// <inheritdoc/>
		public bool Equals(D2D_MATRIX_4X4_F other) => _11 == other._11 && _12 == other._12 && _13 == other._13 && _14 == other._14 && _21 == other._21 && _22 == other._22 && _23 == other._23 && _24 == other._24 && _31 == other._31 && _32 == other._32 && _33 == other._33 && _34 == other._34 && _41 == other._41 && _42 == other._42 && _43 == other._43 && _44 == other._44;

		/// <inheritdoc/>
		public override int GetHashCode() => ((float[,])this).GetHashCode();

		/// <summary>Multiplies two matrices together to compute the product.</summary>
		/// <param name="left">The first matrix.</param>
		/// <param name="right">The second matrix.</param>
		/// <returns>The product matrix.</returns>
		public static D2D_MATRIX_4X4_F operator *(D2D_MATRIX_4X4_F left, D2D_MATRIX_4X4_F right) => new() { m = new Matrix(left.m) * new Matrix(right.m) };

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left comparible.</param>
		/// <param name="right">The right comparible.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D2D_MATRIX_4X4_F left, D2D_MATRIX_4X4_F right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left comparible.</param>
		/// <param name="right">The right comparible.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D2D_MATRIX_4X4_F left, D2D_MATRIX_4X4_F right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="float"/>[,] to <see cref="D2D_MATRIX_4X4_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_4X4_F(float[,] value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_4X4_F"/> to <see cref="float"/>[,].</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[,](D2D_MATRIX_4X4_F value) => value.m;

		/// <summary>Performs an implicit conversion from <see cref="Matrix"/> to <see cref="D2D_MATRIX_4X4_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_4X4_F(Matrix value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_4X4_F"/> to <see cref="Matrix"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Matrix(D2D_MATRIX_4X4_F value) => new(value.m);

		/// <summary>A perspective transformation given a depth value.</summary>
		/// <param name="depth">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The depth for the perspective transform.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>Matrix4x4F</c></b></para>
		/// <para>The result matrix.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1helper/nf-d2d1_1helper-matrix4x4f-perspectiveprojection
		// Matrix4x4F PerspectiveProjection( FLOAT depth );
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.PerspectiveProjection")]
		public static D2D_MATRIX_4X4_F PerspectiveProjection(float depth) => new() { _11 = 1, _22 = 1, _33 = 1, _34 = depth > 0 ? -1 / depth : 0f, _44 = 1 };

		/// <summary>Rotates the transform matrix around the X axis.</summary>
		/// <param name="degreeX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of rotation.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>Matrix4x4F</c></b></para>
		/// <para>The result matrix.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1helper/nf-d2d1_1helper-matrix4x4f-rotationx
		// Matrix4x4F RotationX( FLOAT degreeX );
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.RotationX")]
		public static D2D_MATRIX_4X4_F RotationX(float degreeX) { var angle = degreeX * Math.PI / 180; return new() { _11 = 1, _22 = (float)Math.Cos(angle), _23 = (float)Math.Sin(angle), _32 = (float)-Math.Sin(angle), _33 = (float)Math.Cos(angle), _44 = 1 }; }

		/// <summary>Rotates the transform matrix around the Y axis.</summary>
		/// <param name="degreeY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of rotation.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>Matrix4x4F</c></b></para>
		/// <para>The result matrix.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1helper/nf-d2d1_1helper-matrix4x4f-rotationy
		// Matrix4x4F RotationY( FLOAT degreeY );
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.RotationY")]
		public static D2D_MATRIX_4X4_F RotationY(float degreeY) { var angle = degreeY * Math.PI / 180; return new() { _11 = (float)Math.Cos(angle), _13 = (float)-Math.Sin(angle), _22 = 1, _31 = (float)Math.Sin(angle), _33 = (float)Math.Cos(angle), _44 = 1 }; }

		/// <summary>Rotates the transform matrix around the Z axis.</summary>
		/// <param name="degreeZ">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of rotation.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>Matrix4x4F</c></b></para>
		/// <para>The result matrix.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1helper/nf-d2d1_1helper-matrix4x4f-rotationz
		// Matrix4x4F RotationZ( FLOAT degreeZ );
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.RotationZ")]
		public static D2D_MATRIX_4X4_F RotationZ(float degreeZ) { var angle = degreeZ * Math.PI / 180; return new() { _11 = (float)Math.Cos(angle), _12 = (float)Math.Sin(angle), _21 = (float)-Math.Sin(angle), _22 = (float)Math.Cos(angle), _33 = 1, _44 = 1 }; }

		/// <summary>Determines the 3-D Rotation matrix for an arbitrary axis.</summary>
		/// <param name="x">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The X point of the axis.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The Y point of the axis.</para>
		/// </param>
		/// <param name="z">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The Z point of the axis.</para>
		/// </param>
		/// <param name="degree">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of rotation.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>Matrix4x4F</c></b></para>
		/// <para>The result matrix</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1helper/nf-d2d1_1helper-matrix4x4f-rotationarbitraryaxis
		// Matrix4x4F RotationArbitraryAxis( FLOAT angle, FLOAT y, FLOAT z, FLOAT degree );
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.RotationArbitraryAxis")]
		public static D2D_MATRIX_4X4_F RotationArbitraryAxis(float x, float y, float z, float degree)
		{
			var magnitude = (float)Math.Sqrt(x * x + y * y + z * z);
			x /= magnitude;
			y /= magnitude;
			z /= magnitude;

			var angle = degree * Math.PI / 180;
			var c = (float)Math.Cos(angle);
			var s = (float)Math.Sin(angle);
			var t = 1 - c;
			return new()
			{
				_11 = 1 + t * (x * x - 1),
				_12 = t * x * y + s * z,
				_13 = t * x * z - s * y,
				_21 = t * x * y - s * z,
				_22 = 1 + t * (y * y - 1),
				_23 = t * y * z + s * x,
				_31 = t * x * z + s * y,
				_32 = t * y * z - s * x,
				_33 = 1 + t * (z * z - 1),
				_44 = 1
			};
		}

		/// <summary>Scales the perspective plane of the matrix.</summary>
		/// <param name="x">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The scale in the X direction.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The scale in the Y direction.</para>
		/// </param>
		/// <param name="z">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The scale in the Z direction.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>Matrix4x4F</c></b></para>
		/// <para>The result matrix.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1helper/nf-d2d1_1helper-matrix4x4f-scale
		// Matrix4x4F Scale( FLOAT angle, FLOAT y, FLOAT z );
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.Scale")]
		public static D2D_MATRIX_4X4_F Scale(float x, float y, float z) => new() { _11 = x, _22 = y, _33 = z, _44 = 1 };

		/// <summary>Skews the matrix in the X direction.</summary>
		/// <param name="degreeX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The skew amount.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>Matrix4x4F</c></b></para>
		/// <para>The result matrix.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1helper/nf-d2d1_1helper-matrix4x4f-skewx
		// Matrix4x4F SkewX( FLOAT degreeX );
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.SkewX")]
		public static D2D_MATRIX_4X4_F SkewX(float degreeX) => new() { _11 = 1, _22 = 1, _23 = (float)Math.Tan(degreeX * Math.PI / 180), _33 = 1, _44 = 1 };

		/// <summary>Skews the matrix in the Y direction.</summary>
		/// <param name="degreeY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The skew amount.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>Matrix4x4F</c></b></para>
		/// <para>The result matrix.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1helper/nf-d2d1_1helper-matrix4x4f-skewy
		// Matrix4x4F SkewY( FLOAT degreeY );
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.SkewY")]
		public static D2D_MATRIX_4X4_F SkewY(float degreeY) => new() { _11 = 1, _12 = (float)Math.Tan(degreeY * Math.PI / 180), _22 = 1, _33 = 1, _44 = 1 };

		/// <summary>Creates a translation matrix from the specified X, Y, and Z components.</summary>
		/// <param name="x">The amount to translate on the X axis.</param>
		/// <param name="y">The amount to translate on the Y axis.</param>
		/// <param name="z">The amount to translate on the Z axis.</param>
		/// <returns>The translation matrix.</returns>
		[PInvokeData("d2d1_1helper.h", MSDNShortId = "NF:d2d1_1helper.Matrix4x4F.Translation")]
		public static D2D_MATRIX_4X4_F Translation(float x, float y, float z) => new() { _11 = 1, _22 = 1, _33 = 1, _41 = x, _42 = y, _43 = z, _44 = 1 };
	}

	/// <summary>Describes a 5-by-4 floating point matrix.</summary>
	/// <remarks>The <c>D2D1_MATRIX_5X4_F</c> structure is type defined from a <c>D2D_MATRIX_5X4_F</c> structure in D2d1_1.h.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_matrix_5x4_f typedef struct D2D_MATRIX_5X4_F { union {
	// struct { FLOAT _11; FLOAT _12; FLOAT _13; FLOAT _14; FLOAT _21; FLOAT _22; FLOAT _23; FLOAT _24; FLOAT _31; FLOAT _32; FLOAT _33;
	// FLOAT _34; FLOAT _41; FLOAT _42; FLOAT _43; FLOAT _44; FLOAT _51; FLOAT _52; FLOAT _53; FLOAT _54; } DUMMYSTRUCTNAME; FLOAT m[5, 4];
	// } DUMMYUNIONNAME; } D2D_MATRIX_5X4_F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_MATRIX_5X4_F"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_MATRIX_5X4_F
	{
		/// <summary/>
		public float _11;

		/// <summary/>	;
		public float _12;

		/// <summary/>	;
		public float _13;

		/// <summary/>	;
		public float _14;

		/// <summary/>	;
		public float _21;

		/// <summary/>	;
		public float _22;

		/// <summary/>	;
		public float _23;

		/// <summary/>	;
		public float _24;

		/// <summary/>	;
		public float _31;

		/// <summary/>	;
		public float _32;

		/// <summary/>	;
		public float _33;

		/// <summary/>	;
		public float _34;

		/// <summary/>	;
		public float _41;

		/// <summary/>	;
		public float _42;

		/// <summary/>	;
		public float _43;

		/// <summary/>	;
		public float _44;

		/// <summary/>	;
		public float _51;

		/// <summary/>	;
		public float _52;

		/// <summary/>	;
		public float _53;

		/// <summary/>	;
		public float _54;

		/// <summary/>
		public float[,] m
		{
			get => new[,] { { _11, _12, _13, _14 }, { _21, _22, _23, _24 }, { _31, _32, _33, _34 }, { _41, _42, _43, _44 }, { _51, _52, _53, _54 } };
			set
			{
				if (value.GetLength(0) != 5 || value.GetLength(1) != 4)
					throw new ArgumentOutOfRangeException(nameof(m), "Value must a 5x4 array.");
				_11 = value[0, 0];
				_12 = value[0, 1];
				_13 = value[0, 2];
				_14 = value[0, 3];
				_21 = value[1, 0];
				_22 = value[1, 1];
				_23 = value[1, 2];
				_24 = value[1, 3];
				_31 = value[2, 0];
				_32 = value[2, 1];
				_33 = value[2, 2];
				_34 = value[2, 3];
				_41 = value[3, 0];
				_42 = value[3, 1];
				_43 = value[3, 2];
				_44 = value[3, 3];
				_51 = value[4, 0];
				_52 = value[4, 1];
				_53 = value[4, 2];
				_54 = value[4, 3];
			}
		}

		/// <summary>Performs an implicit conversion from <see cref="float"/>[,] to <see cref="D2D_MATRIX_5X4_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_5X4_F(float[,] value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_5X4_F"/> to <see cref="float"/>[,].</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[,](D2D_MATRIX_5X4_F value) => value.m;

		/// <summary>Performs an implicit conversion from <see cref="Matrix"/> to <see cref="D2D_MATRIX_5X4_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_5X4_F(Matrix value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_5X4_F"/> to <see cref="Matrix"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Matrix(D2D_MATRIX_5X4_F value) => new(value.m);
	}

	/// <summary>Represents an x-coordinate and y-coordinate pair, expressed as floating-point values, in two-dimensional space.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_point_2f typedef struct D2D_POINT_2F { FLOAT angle; FLOAT
	// y; } D2D_POINT_2F;
	[PInvokeData("dcommon.h", MSDNShortId = "2ee55d63-594b-482d-9e31-2378369c6c30"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_POINT_2F(float x = 0f, float y = 0f) : IEquatable<D2D_POINT_2F>
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The angle-coordinate of the point.</para>
		/// </summary>
		public float x = x;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the point.</para>
		/// </summary>
		public float y = y;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D2D_POINT_2F f && Equals(f);

		/// <inheritdoc/>
		public bool Equals(D2D_POINT_2F other) => x == other.x && y == other.y;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y).GetHashCode();

		/// <summary>Implements the operator *.</summary>
		/// <param name="left">The left point.</param>
		/// <param name="right">The right matrix.</param>
		/// <returns>The result of the operator.</returns>
		public static D2D_POINT_2F operator *(D2D_POINT_2F left, DXGI_MATRIX_3X2_F right) => right.TransformPoint(left);

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D2D_POINT_2F left, D2D_POINT_2F right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D2D_POINT_2F left, D2D_POINT_2F right) => !(left == right);

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.Drawing.PointF"/> to <see cref="D2D_POINT_2F"/>.
		/// </summary>
		/// <param name="pointF">The point f.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_POINT_2F(PointF pointF) => new(pointF.X, pointF.Y);

		/// <summary>
		/// Performs an implicit conversion from <see cref="D2D_POINT_2F"/> to <see cref="System.Drawing.PointF"/>.
		/// </summary>
		/// <param name="pointF">The point f.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PointF(D2D_POINT_2F pointF) => new(pointF.x, pointF.y);
	}

	/// <summary>Represents an x-coordinate and y-coordinate pair, expressed as floating-point values, in two-dimensional space.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_point_2f typedef struct D2D_POINT_2F { FLOAT angle; FLOAT
	// y; } D2D_POINT_2F;
	[PInvokeData("dcommon.h", MSDNShortId = "2ee55d63-594b-482d-9e31-2378369c6c30"), StructLayout(LayoutKind.Sequential)]
	public class PD2D_POINT_2F(float x, float y)
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The angle-coordinate of the point.</para>
		/// </summary>
		public float x = x;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the point.</para>
		/// </summary>
		public float y = y;

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.Drawing.PointF"/> to <see cref="D2D_POINT_2F"/>.
		/// </summary>
		/// <param name="pointF">The point f.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PD2D_POINT_2F?(PointF? pointF) => pointF is null ? null : new(pointF.Value.X, pointF.Value.Y);

		/// <summary>
		/// Performs an implicit conversion from <see cref="D2D_POINT_2F"/> to <see cref="System.Drawing.PointF"/>.
		/// </summary>
		/// <param name="pointF">The point f.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PointF?(PD2D_POINT_2F? pointF) => pointF is null ? null : new(pointF.x, pointF.y);

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.Drawing.PointF"/> to <see cref="D2D_POINT_2F"/>.
		/// </summary>
		/// <param name="pointF">The point f.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PD2D_POINT_2F?(D2D_POINT_2F? pointF) => pointF is null ? null : new(pointF.Value.x, pointF.Value.y);

		/// <summary>
		/// Performs an implicit conversion from <see cref="D2D_POINT_2F"/> to <see cref="System.Drawing.PointF"/>.
		/// </summary>
		/// <param name="pointF">The point f.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_POINT_2F?(PD2D_POINT_2F? pointF) => pointF is null ? null : new(pointF.x, pointF.y);
	}

	/// <summary>
	/// Represents an x-coordinate and y-coordinate pair, expressed as an unsigned 32-bit integer value, in two-dimensional space.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_point_2u typedef struct D2D_POINT_2U { UINT32 angle; UINT32 y;
	// } D2D_POINT_2U;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_POINT_2U")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_POINT_2U(uint x, uint y)
	{
		/// <summary>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The angle-coordinate value of the point.</para>
		/// </summary>
		public uint x = x;

		/// <summary>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The y-coordinate value of the point.</para>
		/// </summary>
		public uint y = y;
	}

	/// <summary>
	/// Represents a rectangle defined by the coordinates of the upper-left corner (left, top) and the coordinates of the lower-right
	/// corner (right, bottom).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_rect_f typedef struct D2D_RECT_F { FLOAT left; FLOAT
	// top; FLOAT right; FLOAT bottom; } D2D_RECT_F;
	[PInvokeData("dcommon.h", MSDNShortId = "84bd7ab0-f273-46f8-b261-86cd1d7f3868"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_RECT_F(float left = 0f, float top = 0f, float right = 0f, float bottom = 0f) : IEquatable<D2D_RECT_F>
	{
		/// <summary>The angle-coordinate of the upper-left corner of the rectangle.</summary>
		public float left = left;

		/// <summary>The y-coordinate of the upper-left corner of the rectangle.</summary>
		public float top = top;

		/// <summary>The angle-coordinate of the lower-right corner of the rectangle.</summary>
		public float right = right;

		/// <summary>The y-coordinate of the lower-right corner of the rectangle.</summary>
		public float bottom = bottom;

		/// <summary>Gets a value indicating whether this instance is empty.</summary>
		/// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty => left == 0f && top == 0f && right == 0f && bottom == 0f;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D2D_RECT_F f && Equals(f);

		/// <inheritdoc/>
		public bool Equals(D2D_RECT_F other) => left == other.left && top == other.top && right == other.right && bottom == other.bottom;

		/// <inheritdoc/>
		public override int GetHashCode() => (left, top, right, bottom).GetHashCode();

		/// <summary>Tests whether two <see cref="D2D_RECT_F"/> structures have equal location and size.</summary>
		/// <param name="left">The <see cref="D2D_RECT_F"/> structure that is to the left of the equality operator.</param>
		/// <param name="right">The <see cref="D2D_RECT_F"/> structure that is to the right of the equality operator.</param>
		/// <returns>
		/// This operator returns <see langword="true"/> if the two <see cref="D2D_RECT_F"/> structures have equal left, top, right, and
		/// bottom properties.
		/// </returns>
		public static bool operator ==(D2D_RECT_F left, D2D_RECT_F right) => left.Equals(right);

		/// <summary>Tests whether two <see cref="D2D_RECT_F"/> structures differ in location and size.</summary>
		/// <param name="left">The <see cref="D2D_RECT_F"/> structure that is to the left of the inequality operator.</param>
		/// <param name="right">The <see cref="D2D_RECT_F"/> structure that is to the right of the inequality operator.</param>
		/// <returns>
		/// This operator returns <see langword="true"/> if any of the left, top, right, and bottom properties of the two <see
		/// cref="D2D_RECT_F"/> structures are unequal; otherwise <see langword="false"/>.
		/// </returns>
		public static bool operator !=(D2D_RECT_F left, D2D_RECT_F right) => !(left == right);

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.Drawing.RectangleF"/> to <see cref="D2D_RECT_F"/>.
		/// </summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_RECT_F(RectangleF r) => new(r.Left, r.Top, r.Right, r.Bottom);

		/// <summary>
		/// Performs an implicit conversion from <see cref="D2D_RECT_F"/> to <see cref="System.Drawing.RectangleF"/>.
		/// </summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator RectangleF(D2D_RECT_F r) => RectangleF.FromLTRB(r.left, r.top, r.right, r.bottom);

		/// <summary>
		/// Creates a rectangle that has its upper-left corner set to (negative infinity, negative infinity) and its lower-right corner set
		/// to (infinity, infinity).
		/// </summary>
		/// <returns>
		/// A rectangle that has its upper-left corner set to (negative infinity, negative infinity) and its lower-right corner set to
		/// (infinity, infinity).
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-infiniterect D2D1_RECT_F InfiniteRect();
		[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.InfiniteRect")]
		public static D2D_RECT_F Infinite => new(-float.MaxValue, -float.MaxValue, float.MaxValue, float.MaxValue);
	}

	/// <summary>Represents a rectangle defined by the upper-left corner pair of coordinates (left,top) and the lower-right corner pair of coordinates (right, bottom). These coordinates are expressed as a 32-bit integer values.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_rect_u
	// typedef struct D2D_RECT_U { UINT32 left; UINT32 top; UINT32 right; UINT32 bottom; } D2D_RECT_U;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_RECT_U")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_RECT_U(uint left = 0, uint top = 0, uint right = 0, uint bottom = 0) : IEquatable<D2D_RECT_U>
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The angle-coordinate of the upper-left corner of the rectangle.</para>
		/// </summary>
		public uint left = left;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the upper-left corner of the rectangle.</para>
		/// </summary>
		public uint top = top;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The angle-coordinate of the lower-right corner of the rectangle.</para>
		/// </summary>
		public uint right = right;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the lower-right corner of the rectangle.</para>
		/// </summary>
		public uint bottom = bottom;

		/// <summary>Gets a value indicating whether this instance is empty.</summary>
		/// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty => left == 0 && top == 0 && right == 0 && bottom == 0;

		/// <summary>Gets a value indicating whether this instance is infinite.</summary>
		/// <value><c>true</c> if this instance is infinite; otherwise, <c>false</c>.</value>
		public bool IsInfinite => left == 0 && top == 0 && right == uint.MaxValue && bottom == uint.MaxValue;

		/// <summary>
		/// Gets a value representing an infinite rectange that has its upper-left corner set to (0u, 0u) and its lower-right corner set to
		/// (UINT32_MAX, UINT32_MAX).
		/// </summary>
		public static D2D_RECT_U Infinite => new(0, 0, uint.MaxValue, uint.MaxValue);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D2D_RECT_U f && Equals(f);

		/// <inheritdoc/>
		public bool Equals(D2D_RECT_U other) => left == other.left && top == other.top && right == other.right && bottom == other.bottom;

		/// <inheritdoc/>
		public override int GetHashCode() => (left, top, right, bottom).GetHashCode();

		/// <summary>Tests whether two <see cref="D2D_RECT_U"/> structures have equal location and size.</summary>
		/// <param name="left">The <see cref="D2D_RECT_U"/> structure that is to the left of the equality operator.</param>
		/// <param name="right">The <see cref="D2D_RECT_U"/> structure that is to the right of the equality operator.</param>
		/// <returns>
		/// This operator returns <see langword="true"/> if the two <see cref="D2D_RECT_U"/> structures have equal left, top, right, and
		/// bottom properties.
		/// </returns>
		public static bool operator ==(D2D_RECT_U left, D2D_RECT_U right) => left.Equals(right);

		/// <summary>Tests whether two <see cref="D2D_RECT_U"/> structures differ in location and size.</summary>
		/// <param name="left">The <see cref="D2D_RECT_U"/> structure that is to the left of the inequality operator.</param>
		/// <param name="right">The <see cref="D2D_RECT_U"/> structure that is to the right of the inequality operator.</param>
		/// <returns>
		/// This operator returns <see langword="true"/> if any of the left, top, right, and bottom properties of the two <see
		/// cref="D2D_RECT_U"/> structures are unequal; otherwise <see langword="false"/>.
		/// </returns>
		public static bool operator !=(D2D_RECT_U left, D2D_RECT_U right) => !(left == right);
	}

	/// <summary>
	/// Represents a rectangle defined by the coordinates of the upper-left corner (left, top) and the coordinates of the lower-right
	/// corner (right, bottom).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_rect_f typedef struct D2D_RECT_F { FLOAT left; FLOAT
	// top; FLOAT right; FLOAT bottom; } D2D_RECT_F;
	[PInvokeData("dcommon.h", MSDNShortId = "84bd7ab0-f273-46f8-b261-86cd1d7f3868"), StructLayout(LayoutKind.Sequential)]
	public class PD2D_RECT_F(float left, float top, float right, float bottom)
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The angle-coordinate of the upper-left corner of the rectangle.</para>
		/// </summary>
		public float left = left;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the upper-left corner of the rectangle.</para>
		/// </summary>
		public float top = top;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The angle-coordinate of the lower-right corner of the rectangle.</para>
		/// </summary>
		public float right = right;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the lower-right corner of the rectangle.</para>
		/// </summary>
		public float bottom = bottom;

		private D2D_RECT_F rect => new(left, top, right, bottom);

		/// <summary>Performs an implicit conversion from <see cref="PD2D_RECT_F"/> to <see cref="D2D_RECT_F"/>.</summary>
		/// <param name="r">The <see cref="PD2D_RECT_F"/> to convert.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_RECT_F?(PD2D_RECT_F r) => r?.rect;

		/// <summary>Performs an implicit conversion from <see cref="PD2D_RECT_F"/> to <see cref="RectangleF"/>.</summary>
		/// <param name="r">The <see cref="PD2D_RECT_F"/> to convert.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator RectangleF?(PD2D_RECT_F r) => r?.rect;

		/// <summary>Performs an implicit conversion from <see cref="Nullable{RectangleF}"/> to <see cref="PD2D_RECT_F"/>.</summary>
		/// <param name="r">The <see cref="RectangleF"/> to convert.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PD2D_RECT_F?(RectangleF? r) => r.HasValue ? new(r.Value.Left, r.Value.Top, r.Value.Right, r.Value.Bottom) : null;

		/// <summary>Performs an implicit conversion from <see cref="D2D_RECT_F"/> to <see cref="PD2D_RECT_F"/>.</summary>
		/// <param name="r">The <see cref="D2D_RECT_F"/> to convert.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PD2D_RECT_F(D2D_RECT_F r) => new(r.left, r.top, r.right, r.bottom);

		/// <summary>Performs an implicit conversion from <see cref="Nullable{D2D_RECT_F}"/> to <see cref="PD2D_RECT_F"/>.</summary>
		/// <param name="r">The <see cref="D2D_RECT_F"/> to convert.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PD2D_RECT_F?(D2D_RECT_F? r) => r.HasValue ? new(r.Value.left, r.Value.top, r.Value.right, r.Value.bottom) : null;
	}

	/// <summary>Stores an ordered pair of floating-point values, typically the width and height of a rectangle.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_size_f typedef struct D2D_SIZE_F { FLOAT width; FLOAT
	// height; } D2D_SIZE_F;
	[PInvokeData("dcommon.h", MSDNShortId = "9d519bb9-3eb8-4d7e-ba00-b6cf5a428a04"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_SIZE_F(float width = 0f, float height = 0f) : IEquatable<D2D_SIZE_F>
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal component of this size.</para>
		/// </summary>
		public float width = width;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The vertical component of this size.</para>
		/// </summary>
		public float height = height;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D2D_SIZE_F f && Equals(f);

		/// <inheritdoc/>
		public bool Equals(D2D_SIZE_F other) => width == other.width && height == other.height;

		/// <inheritdoc/>
		public override int GetHashCode() => (width, height).GetHashCode();

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D2D_SIZE_F left, D2D_SIZE_F right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D2D_SIZE_F left, D2D_SIZE_F right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="System.Drawing.SizeF"/> to <see cref="D2D_SIZE_F"/>.</summary>
		/// <param name="sz">The sz.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_SIZE_F(SizeF sz) => new(sz.Width, sz.Height);

		/// <summary>Performs an implicit conversion from <see cref="D2D_SIZE_F"/> to <see cref="System.Drawing.SizeF"/>.</summary>
		/// <param name="sz">The sz.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeF(D2D_SIZE_F sz) => new(sz.width, sz.height);
	}

	/// <summary>Stores an ordered pair of integers, typically the width and height of a rectangle.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_size_u typedef struct D2D_SIZE_U { UINT32 width; UINT32
	// height; } D2D_SIZE_U;
	[PInvokeData("dcommon.h", MSDNShortId = "d9ea9df5-7c5f-4afa-9859-14d77b017904"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_SIZE_U(uint width = 0, uint height = 0) : IEquatable<D2D_SIZE_U>
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The horizontal component of this size.</para>
		/// </summary>
		public uint width = width;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The vertical component of this size.</para>
		/// </summary>
		public uint height = height;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D2D_SIZE_U u && Equals(u);

		/// <inheritdoc/>
		public bool Equals(D2D_SIZE_U other) => width == other.width && height == other.height;

		/// <inheritdoc/>
		public override int GetHashCode() => (width, height).GetHashCode();

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D2D_SIZE_U left, D2D_SIZE_U right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D2D_SIZE_U left, D2D_SIZE_U right) => !(left == right);

		/// <summary>Performs an explicit conversion from <see cref="System.Drawing.Size"/> to <see cref="D2D_SIZE_U"/>.</summary>
		/// <param name="sz">The size.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator D2D_SIZE_U(Size sz) => new((uint)sz.Width, (uint)sz.Height);

		/// <summary>Performs an explicit conversion from <see cref="SIZE"/> to <see cref="D2D_SIZE_U"/>.</summary>
		/// <param name="sz">The size.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_SIZE_U(SIZE sz) => new((uint)sz.Width, (uint)sz.Height);
	}

	/// <summary>A vector of 2 FLOAT values (x, y).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_vector_2f
	// typedef struct D2D_VECTOR_2F { FLOAT angle; FLOAT y; } D2D_VECTOR_2F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_VECTOR_2F"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_VECTOR_2F(float x = 0f, float y = 0f)
	{
		/// <summary>The angle value of the vector.</summary>
		public float x = x;

		/// <summary>The y value of the vector.</summary>
		public float y = y;

		/// <summary>Performs an implicit conversion from <see cref="float"/>[] to <see cref="Vanara.PInvoke.DXGI.D2D_VECTOR_2F"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_VECTOR_2F(float[] v) => v is not null && v.Length == 2 ? new(v[0], v[1]) : throw new ArgumentOutOfRangeException(nameof(v), "Value must be an array of 2 elements.");

		/// <summary>Performs an implicit conversion from <see cref="Vanara.PInvoke.DXGI.D2D_VECTOR_2F"/> to <see cref="float"/>[].</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[](D2D_VECTOR_2F v) => [v.x, v.y];
	}

	/// <summary>A vector of 3 FLOAT values (x, y, z).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_vector_3f
	// typedef struct D2D_VECTOR_3F { FLOAT angle; FLOAT y; FLOAT z; } D2D_VECTOR_3F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_VECTOR_3F"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_VECTOR_3F(float x = 0f, float y = 0f, float z = 0f)
	{
		/// <summary>The angle value of the vector.</summary>
		public float x = x;

		/// <summary>The y value of the vector.</summary>
		public float y = y;

		/// <summary>The z value of the vector.</summary>
		public float z = z;

		/// <summary>Returns the length of a 3 dimensional vector.</summary>
		/// <value>The length.</value>
		public readonly float Length => (float)Math.Sqrt(x * x + y * y + z * z);

		/// <summary>Performs an implicit conversion from <see cref="float"/>[] to <see cref="D2D_VECTOR_3F"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_VECTOR_3F(float[] v) => v is not null && v.Length == 3 ? new(v[0], v[1], v[2]) : throw new ArgumentOutOfRangeException(nameof(v), "Value must be an array of 3 elements.");

		/// <summary>Performs an implicit conversion from <see cref="D2D_VECTOR_3F"/> to <see cref="float"/>[].</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[](D2D_VECTOR_3F v) => [v.x, v.y, v.z];
	}

	/// <summary>A vector of 4 FLOAT values (x, y, z, w).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_vector_4f
	// typedef struct D2D_VECTOR_4F { FLOAT angle; FLOAT y; FLOAT z; FLOAT w; } D2D_VECTOR_4F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_VECTOR_4F"), StructLayout(LayoutKind.Sequential)]
	public struct D2D_VECTOR_4F(float x = 0f, float y = 0f, float z = 0f, float w = 0f)
	{
		/// <summary>The angle value of the vector.</summary>
		public float x = x;

		/// <summary>The y value of the vector.</summary>
		public float y = y;

		/// <summary>The z value of the vector.</summary>
		public float z = z;

		/// <summary>The w value of the vector.</summary>
		public float w = w;

		/// <summary>Performs an implicit conversion from <see cref="float"/>[] to <see cref="D2D_VECTOR_4F"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_VECTOR_4F(float[] v) => v is not null && v.Length == 4 ? new(v[0], v[1], v[2], v[3]) : throw new ArgumentOutOfRangeException(nameof(v), "Value must be an array of 4 elements.");

		/// <summary>Performs an implicit conversion from <see cref="D2D_VECTOR_4F"/> to <see cref="float"/>[].</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[](D2D_VECTOR_4F v) => [v.x, v.y, v.z, v.w];
	}

	/// <summary>Contains the data format and alpha mode for a bitmap or render target.</summary>
	/// <remarks>
	/// <para>
	/// For more information about the pixel formats and alpha modes supported by each render target, see Supported Pixel Formats and
	/// Alpha Modes.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example creates a <c>D2D1_PIXEL_FORMAT</c> structure and uses it to specify the pixel format and alpha mode of an ID2D1HwndRenderTarget.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d1_pixel_format typedef struct D2D1_PIXEL_FORMAT {
	// DXGI_FORMAT format; D2D1_ALPHA_MODE alphaMode; } D2D1_PIXEL_FORMAT;
	[PInvokeData("dcommon.h", MSDNShortId = "e95afd9c-5793-4cb7-bcb8-aae4d28b6532"), StructLayout(LayoutKind.Sequential)]
	public struct D2D1_PIXEL_FORMAT(DXGI_FORMAT format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN, D2D1_ALPHA_MODE alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_UNKNOWN)
	{
		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>A value that specifies the size and arrangement of channels in each pixel.</para>
		/// </summary>
		public DXGI_FORMAT format = format;

		/// <summary>
		/// <para>Type: <c>D2D1_ALPHA_MODE</c></para>
		/// <para>
		/// A value that specifies whether the alpha channel is using pre-multiplied alpha, straight alpha, whether it should be ignored
		/// and considered opaque, or whether it is unkown.
		/// </para>
		/// </summary>
		public D2D1_ALPHA_MODE alphaMode = alphaMode;
	}

	/// <summary>Defines a 3D box.</summary>
	/// <remarks>The following diagram shows a 3D box, where the origin is the left, front, top corner.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d10/ns-d3d10-d3d10_box typedef struct D3D10_BOX { UINT left; UINT top; UINT
	// front; UINT right; UINT bottom; UINT back; } D3D10_BOX;
	[PInvokeData("d3d10.h", MSDNShortId = "NS:d3d10.D3D10_BOX"), StructLayout(LayoutKind.Sequential)]
	public struct D3D10_BOX : IEquatable<D3D10_BOX>
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The angle position of the left hand side of the box.</para>
		/// </summary>
		public uint left;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The y position of the top of the box.</para>
		/// </summary>
		public uint top;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The z position of the front of the box.</para>
		/// </summary>
		public uint front;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The angle position of the right hand side of the box.</para>
		/// </summary>
		public uint right;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The y position of the bottom of the box.</para>
		/// </summary>
		public uint bottom;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The z position of the back of the box.</para>
		/// </summary>
		public uint back;

		/// <summary>Initializes a new instance of the <see cref="D3D10_BOX" /> struct.</summary>
		/// <param name="Left">The angle position of the left hand side of the box.</param>
		/// <param name="Right">The y position of the top of the box.</param>
		/// <param name="Top">The y position of the top of the box.</param>
		/// <param name="Bottom">The y position of the bottom of the box.</param>
		/// <param name="Front">The z position of the front of the box.</param>
		/// <param name="Back">The z position of the back of the box.</param>
		public D3D10_BOX(int Left, int Right, int Top = 0, int Bottom = 1, int Front = 0, int Back = 1)
		{
			left = unchecked((uint)Left);
			top = unchecked((uint)Top);
			front = unchecked((uint)Front);
			right = unchecked((uint)Right);
			bottom = unchecked((uint)Bottom);
			back = unchecked((uint)Back);
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D3D10_BOX bOX && Equals(bOX);

		/// <summary>Determines whether the specified object is equal to the current object.</summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public bool Equals(D3D10_BOX other) => left == other.left && top == other.top && front == other.front && right == other.right && bottom == other.bottom && back == other.back;

		/// <inheritdoc/>
		public override int GetHashCode()
		{
			int hashCode = 1435850453;
			hashCode = hashCode * -1521134295 + left.GetHashCode();
			hashCode = hashCode * -1521134295 + top.GetHashCode();
			hashCode = hashCode * -1521134295 + front.GetHashCode();
			hashCode = hashCode * -1521134295 + right.GetHashCode();
			hashCode = hashCode * -1521134295 + bottom.GetHashCode();
			hashCode = hashCode * -1521134295 + back.GetHashCode();
			return hashCode;
		}

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D3D10_BOX left, D3D10_BOX right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D3D10_BOX left, D3D10_BOX right) => !(left == right);
	}
	
	/// <summary>Defines a shader macro.</summary>
	/// <remarks>
	/// <para>
	/// You can use shader macros in your shaders. The <c>D3D_SHADER_MACRO</c> structure defines a single shader macro as shown in the
	/// following example:
	/// </para>
	/// <para>The following shader or effect creation functions take an array of shader macros as an input parameter:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D10CompileShader</description>
	/// </item>
	/// <item>
	/// <description>D3DX10CreateEffectFromFile</description>
	/// </item>
	/// <item>
	/// <description>D3DX10PreprocessShaderFromFile</description>
	/// </item>
	/// <item>
	/// <description>D3DX11CreateAsyncShaderPreprocessProcessor</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ns-d3dcommon-d3d_shader_macro typedef struct D3D_SHADER_MACRO { LPCSTR
	// Name; LPCSTR Definition; } D3D_SHADER_MACRO, *LPD3D_SHADER_MACRO;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NS:d3dcommon.D3D_SHADER_MACRO"), StructLayout(LayoutKind.Sequential)]
	public struct D3D_SHADER_MACRO
	{
		/// <summary>The macro name.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;

		/// <summary>The macro definition.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Definition;
	}

	//#define D3D_SET_OBJECT_NAME_N_A(pObject, Chars, pName) (pObject).SetPrivateData(WKPDID_D3DDebugObjectName, Chars, pName)
	//#define D3D_SET_OBJECT_NAME_A(pObject, pName) D3D_SET_OBJECT_NAME_N_A(pObject, lstrlenA(pName), pName)
	//#define D3D_SET_OBJECT_NAME_N_W(pObject, Chars, pName) (pObject).SetPrivateData(WKPDID_D3DDebugObjectNameW, ref Chars 2, pName)
	//#define D3D_SET_OBJECT_NAME_W(pObject, pName) D3D_SET_OBJECT_NAME_N_W(pObject, wcslen(pName), pName)
}