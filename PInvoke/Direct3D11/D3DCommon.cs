namespace Vanara.PInvoke;

/// <summary>Provides methods and types for working with Direct3D 11.</summary>
public static partial class D3D11
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
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_cbuffer_type typedef enum _D3D_CBUFFER_TYPE {
	// D3D_CT_CBUFFER = 0, D3D_CT_TBUFFER, D3D_CT_INTERFACE_POINTERS, D3D_CT_RESOURCE_BIND_INFO, D3D10_CT_CBUFFER, D3D10_CT_TBUFFER,
	// D3D11_CT_CBUFFER, D3D11_CT_TBUFFER, D3D11_CT_INTERFACE_POINTERS, D3D11_CT_RESOURCE_BIND_INFO } D3D_CBUFFER_TYPE;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon._D3D_CBUFFER_TYPE")]
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
	[PInvokeData("d3dcommon.h")]
	[Flags]
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
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_include_type typedef enum _D3D_INCLUDE_TYPE {
	// D3D_INCLUDE_LOCAL = 0, D3D_INCLUDE_SYSTEM, D3D10_INCLUDE_LOCAL, D3D10_INCLUDE_SYSTEM, D3D_INCLUDE_FORCE_DWORD = 0x7fffffff } D3D_INCLUDE_TYPE;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon._D3D_INCLUDE_TYPE")]
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
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_parameter_flags typedef enum _D3D_PARAMETER_FLAGS {
	// D3D_PF_NONE = 0, D3D_PF_IN = 0x1, D3D_PF_OUT = 0x2, D3D_PF_FORCE_DWORD = 0x7fffffff } D3D_PARAMETER_FLAGS;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon._D3D_PARAMETER_FLAGS")]
	[Flags]
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
	// _D3D_SHADER_CBUFFER_FLAGS { D3D_CBF_USERPACKED = 1, D3D10_CBF_USERPACKED, D3D_CBF_FORCE_DWORD = 0x7fffffff } D3D_SHADER_CBUFFER_FLAGS;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon._D3D_SHADER_CBUFFER_FLAGS")]
	[Flags]
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
	// _D3D_SHADER_INPUT_FLAGS { D3D_SIF_USERPACKED = 0x1, D3D_SIF_COMPARISON_SAMPLER = 0x2, D3D_SIF_TEXTURE_COMPONENT_0 = 0x4,
	// D3D_SIF_TEXTURE_COMPONENT_1 = 0x8, D3D_SIF_TEXTURE_COMPONENTS = 0xc, D3D_SIF_UNUSED = 0x10, D3D10_SIF_USERPACKED,
	// D3D10_SIF_COMPARISON_SAMPLER, D3D10_SIF_TEXTURE_COMPONENT_0, D3D10_SIF_TEXTURE_COMPONENT_1, D3D10_SIF_TEXTURE_COMPONENTS,
	// D3D_SIF_FORCE_DWORD = 0x7fffffff } D3D_SHADER_INPUT_FLAGS;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon._D3D_SHADER_INPUT_FLAGS")]
	[Flags]
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
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_shader_input_type typedef enum _D3D_SHADER_INPUT_TYPE
	// { D3D_SIT_CBUFFER = 0, D3D_SIT_TBUFFER, D3D_SIT_TEXTURE, D3D_SIT_SAMPLER, D3D_SIT_UAV_RWTYPED, D3D_SIT_STRUCTURED,
	// D3D_SIT_UAV_RWSTRUCTURED, D3D_SIT_BYTEADDRESS, D3D_SIT_UAV_RWBYTEADDRESS, D3D_SIT_UAV_APPEND_STRUCTURED,
	// D3D_SIT_UAV_CONSUME_STRUCTURED, D3D_SIT_UAV_RWSTRUCTURED_WITH_COUNTER, D3D_SIT_RTACCELERATIONSTRUCTURE, D3D_SIT_UAV_FEEDBACKTEXTURE,
	// D3D10_SIT_CBUFFER, D3D10_SIT_TBUFFER, D3D10_SIT_TEXTURE, D3D10_SIT_SAMPLER, D3D11_SIT_UAV_RWTYPED, D3D11_SIT_STRUCTURED,
	// D3D11_SIT_UAV_RWSTRUCTURED, D3D11_SIT_BYTEADDRESS, D3D11_SIT_UAV_RWBYTEADDRESS, D3D11_SIT_UAV_APPEND_STRUCTURED,
	// D3D11_SIT_UAV_CONSUME_STRUCTURED, D3D11_SIT_UAV_RWSTRUCTURED_WITH_COUNTER } D3D_SHADER_INPUT_TYPE;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon._D3D_SHADER_INPUT_TYPE")]
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
	// _D3D_SHADER_VARIABLE_CLASS { D3D_SVC_SCALAR = 0, D3D_SVC_VECTOR, D3D_SVC_MATRIX_ROWS, D3D_SVC_MATRIX_COLUMNS, D3D_SVC_OBJECT,
	// D3D_SVC_STRUCT, D3D_SVC_INTERFACE_CLASS, D3D_SVC_INTERFACE_POINTER, D3D10_SVC_SCALAR, D3D10_SVC_VECTOR, D3D10_SVC_MATRIX_ROWS,
	// D3D10_SVC_MATRIX_COLUMNS, D3D10_SVC_OBJECT, D3D10_SVC_STRUCT, D3D11_SVC_INTERFACE_CLASS, D3D11_SVC_INTERFACE_POINTER,
	// D3D_SVC_FORCE_DWORD = 0x7fffffff } D3D_SHADER_VARIABLE_CLASS;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon._D3D_SHADER_VARIABLE_CLASS")]
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
	// _D3D_SHADER_VARIABLE_FLAGS { D3D_SVF_USERPACKED = 1, D3D_SVF_USED = 2, D3D_SVF_INTERFACE_POINTER = 4, D3D_SVF_INTERFACE_PARAMETER =
	// 8, D3D10_SVF_USERPACKED, D3D10_SVF_USED, D3D11_SVF_INTERFACE_POINTER, D3D11_SVF_INTERFACE_PARAMETER, D3D_SVF_FORCE_DWORD = 0x7fffffff
	// } D3D_SHADER_VARIABLE_FLAGS;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon._D3D_SHADER_VARIABLE_FLAGS")]
	[Flags]
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
	// _D3D_SHADER_VARIABLE_TYPE { D3D_SVT_VOID = 0, D3D_SVT_BOOL = 1, D3D_SVT_INT = 2, D3D_SVT_FLOAT = 3, D3D_SVT_STRING = 4,
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
	[PInvokeData("d3dcommon.h", MSDNShortId = "NE:d3dcommon._D3D_SHADER_VARIABLE_TYPE")]
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
	[PInvokeData("d3dcommon.h", MSDNShortId = "NN:d3dcommon.ID3D10Blob")]
	[ComImport, Guid("8BA5FB08-5195-40e2-AC58-0D989C3A0102"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D10Blob
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
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>The size of the data, in bytes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3d10blob-getbuffersize SIZE_T GetBufferSize();
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
	[PInvokeData("d3dcommon.h", MSDNShortId = "NN:d3dcommon.ID3DDestructionNotifier")]
	[ComImport, Guid("a06eb39a-50da-425b-8c31-4eecd6c270f3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
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
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ns-d3dcommon-d3d_shader_macro typedef struct _D3D_SHADER_MACRO { LPCSTR
	// Name; LPCSTR Definition; } D3D_SHADER_MACRO, *LPD3D_SHADER_MACRO;
	[PInvokeData("d3dcommon.h", MSDNShortId = "NS:d3dcommon._D3D_SHADER_MACRO")]
	[StructLayout(LayoutKind.Sequential)]
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