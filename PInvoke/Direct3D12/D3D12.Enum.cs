namespace Vanara.PInvoke;

/// <summary>Items from the Direct3D12.dll.</summary>
public static partial class D3D12
{
	/// <summary>Specifies the version of root signature layout.</summary>
	/// <remarks>
	/// <para>This enum is used by the following structures and methods.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D12_VERSIONED_ROOT_SIGNATURE_DESC</description>
	/// </item>
	/// <item>
	/// <description>D3D12_FEATURE_DATA_ROOT_SIGNATURE</description>
	/// </item>
	/// <item>
	/// <description>GetRootSignatureDescAtVersion</description>
	/// </item>
	/// <item>
	/// <description>D3D12SerializeRootSignature</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d_root_signature_version typedef enum D3D_ROOT_SIGNATURE_VERSION
	// { D3D_ROOT_SIGNATURE_VERSION_1 = 0x1, D3D_ROOT_SIGNATURE_VERSION_1_0 = 0x1, D3D_ROOT_SIGNATURE_VERSION_1_1 = 0x2,
	// D3D_ROOT_SIGNATURE_VERSION_1_2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D_ROOT_SIGNATURE_VERSION")]
	public enum D3D_ROOT_SIGNATURE_VERSION
	{
		/// <summary>Value: 0x1 Version one of root signature layout.</summary>
		D3D_ROOT_SIGNATURE_VERSION_1 = 1,

		/// <summary>Value: 0x1 Version one of root signature layout.</summary>
		D3D_ROOT_SIGNATURE_VERSION_1_0 = 1,

		/// <summary>Value: 0x2 Version 1.1 of root signature layout. Refer to Root Signature Version 1.1.</summary>
		D3D_ROOT_SIGNATURE_VERSION_1_1 = 2,

		/// <summary>Value: 0x3 Version 1.2 of root signature layout. Refer to Root Signature Version 1.2.</summary>
		D3D_ROOT_SIGNATURE_VERSION_1_2 = 0x3
	}

	/// <summary>Undocumented</summary>
	[Flags]
	public enum D3D12_SAMPLER_FLAGS
	{
		/// <summary/>
		D3D12_SAMPLER_FLAG_NONE = 0,

		/// <summary/>
		D3D12_SAMPLER_FLAG_UINT_BORDER_COLOR = 0x1,

		/// <summary/>
		D3D12_SAMPLER_FLAG_NON_NORMALIZED_COORDINATES = 0x2
	}

	/// <summary>Specifies a shader model.</summary>
	/// <remarks>This enum is used by the D3D12_FEATURE_DATA_SHADER_MODEL structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d_shader_model typedef enum D3D_SHADER_MODEL {
	// D3D_SHADER_MODEL_NONE, D3D_SHADER_MODEL_5_1 = 0x51, D3D_SHADER_MODEL_6_0 = 0x60, D3D_SHADER_MODEL_6_1 = 0x61, D3D_SHADER_MODEL_6_2 =
	// 0x62, D3D_SHADER_MODEL_6_3 = 0x63, D3D_SHADER_MODEL_6_4 = 0x64, D3D_SHADER_MODEL_6_5 = 0x65, D3D_SHADER_MODEL_6_6 = 0x66,
	// D3D_SHADER_MODEL_6_7 = 0x67, D3D_SHADER_MODEL_6_8, D3D_SHADER_MODEL_6_9, D3D_HIGHEST_SHADER_MODEL } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D_SHADER_MODEL")]
	public enum D3D_SHADER_MODEL
	{
		/// <summary>
		/// <para>Value: 0x51 Indicates shader model 5.1.</para>
		/// </summary>
		D3D_SHADER_MODEL_5_1 = 0x51,

		/// <summary>
		/// <para>Value: 0x60 Indicates shader model 6.0. Compiling a shader model 6.0 shader requires using the DXC compiler (see</para>
		/// <para>DirectX Shader Compiler</para>
		/// <para>), and is not supported by legacy FXC.</para>
		/// </summary>
		D3D_SHADER_MODEL_6_0 = 0x60,

		/// <summary>
		/// <para>Value: 0x61 Indicates shader model 6.1.</para>
		/// </summary>
		D3D_SHADER_MODEL_6_1 = 0x61,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x62</para>
		/// </summary>
		D3D_SHADER_MODEL_6_2 = 0x62,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x63</para>
		/// </summary>
		D3D_SHADER_MODEL_6_3 = 0x63,

		/// <summary>
		/// <para>Value: 0x64 Shader model 6.4 support was added in Windows 10, Version 1903, and is required for DirectX Raytracing (DXR).</para>
		/// </summary>
		D3D_SHADER_MODEL_6_4 = 0x64,

		/// <summary>
		/// <para>Value: 0x65 Shader model 6.5 support was added in Windows 10, Version 2004, and is required for Direct Machine Learning.</para>
		/// </summary>
		D3D_SHADER_MODEL_6_5 = 0x65,

		/// <summary>
		/// <para>Value: 0x66 Shader model 6.6 support was added in Windows 11 and the DirectX 12 Agility SDK.</para>
		/// </summary>
		D3D_SHADER_MODEL_6_6 = 0x66,

		/// <summary>
		/// <para>Value: 0x67 
		/// Shader model 6.7 support was added in the DirectX 12 Agility SDK v1.6. See Agility SDK 1.606.3: Shader Model 6.7 is now publicly
		/// available on the DirectX developer blog.
		/// </para>
		/// </summary>
		D3D_SHADER_MODEL_6_7 = 0x67,

		/// <summary>
		/// <para>Value: 0x68 
		/// </para>
		/// </summary>
		D3D_SHADER_MODEL_6_8 = 0x68,

		/// <summary>
		/// <para>Value: 0x69 
		/// </para>
		/// </summary>
		D3D_SHADER_MODEL_6_9 = 0x69,
	}

	/// <summary>Defines constants that specify render/compute GPU operations.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_auto_breadcrumb_op typedef enum D3D12_AUTO_BREADCRUMB_OP {
	// D3D12_AUTO_BREADCRUMB_OP_SETMARKER, D3D12_AUTO_BREADCRUMB_OP_BEGINEVENT, D3D12_AUTO_BREADCRUMB_OP_ENDEVENT,
	// D3D12_AUTO_BREADCRUMB_OP_DRAWINSTANCED, D3D12_AUTO_BREADCRUMB_OP_DRAWINDEXEDINSTANCED, D3D12_AUTO_BREADCRUMB_OP_EXECUTEINDIRECT,
	// D3D12_AUTO_BREADCRUMB_OP_DISPATCH, D3D12_AUTO_BREADCRUMB_OP_COPYBUFFERREGION, D3D12_AUTO_BREADCRUMB_OP_COPYTEXTUREREGION,
	// D3D12_AUTO_BREADCRUMB_OP_COPYRESOURCE, D3D12_AUTO_BREADCRUMB_OP_COPYTILES, D3D12_AUTO_BREADCRUMB_OP_RESOLVESUBRESOURCE,
	// D3D12_AUTO_BREADCRUMB_OP_CLEARRENDERTARGETVIEW, D3D12_AUTO_BREADCRUMB_OP_CLEARUNORDEREDACCESSVIEW,
	// D3D12_AUTO_BREADCRUMB_OP_CLEARDEPTHSTENCILVIEW, D3D12_AUTO_BREADCRUMB_OP_RESOURCEBARRIER, D3D12_AUTO_BREADCRUMB_OP_EXECUTEBUNDLE,
	// D3D12_AUTO_BREADCRUMB_OP_PRESENT, D3D12_AUTO_BREADCRUMB_OP_RESOLVEQUERYDATA, D3D12_AUTO_BREADCRUMB_OP_BEGINSUBMISSION,
	// D3D12_AUTO_BREADCRUMB_OP_ENDSUBMISSION, D3D12_AUTO_BREADCRUMB_OP_DECODEFRAME, D3D12_AUTO_BREADCRUMB_OP_PROCESSFRAMES,
	// D3D12_AUTO_BREADCRUMB_OP_ATOMICCOPYBUFFERUINT, D3D12_AUTO_BREADCRUMB_OP_ATOMICCOPYBUFFERUINT64,
	// D3D12_AUTO_BREADCRUMB_OP_RESOLVESUBRESOURCEREGION, D3D12_AUTO_BREADCRUMB_OP_WRITEBUFFERIMMEDIATE,
	// D3D12_AUTO_BREADCRUMB_OP_DECODEFRAME1, D3D12_AUTO_BREADCRUMB_OP_SETPROTECTEDRESOURCESESSION, D3D12_AUTO_BREADCRUMB_OP_DECODEFRAME2,
	// D3D12_AUTO_BREADCRUMB_OP_PROCESSFRAMES1, D3D12_AUTO_BREADCRUMB_OP_BUILDRAYTRACINGACCELERATIONSTRUCTURE,
	// D3D12_AUTO_BREADCRUMB_OP_EMITRAYTRACINGACCELERATIONSTRUCTUREPOSTBUILDINFO,
	// D3D12_AUTO_BREADCRUMB_OP_COPYRAYTRACINGACCELERATIONSTRUCTURE, D3D12_AUTO_BREADCRUMB_OP_DISPATCHRAYS,
	// D3D12_AUTO_BREADCRUMB_OP_INITIALIZEMETACOMMAND, D3D12_AUTO_BREADCRUMB_OP_EXECUTEMETACOMMAND, D3D12_AUTO_BREADCRUMB_OP_ESTIMATEMOTION,
	// D3D12_AUTO_BREADCRUMB_OP_RESOLVEMOTIONVECTORHEAP, D3D12_AUTO_BREADCRUMB_OP_SETPIPELINESTATE1,
	// D3D12_AUTO_BREADCRUMB_OP_INITIALIZEEXTENSIONCOMMAND, D3D12_AUTO_BREADCRUMB_OP_EXECUTEEXTENSIONCOMMAND,
	// D3D12_AUTO_BREADCRUMB_OP_DISPATCHMESH, D3D12_AUTO_BREADCRUMB_OP_ENCODEFRAME, D3D12_AUTO_BREADCRUMB_OP_RESOLVEENCODEROUTPUTMETADATA,
	// D3D12_AUTO_BREADCRUMB_OP_BARRIER, D3D12_AUTO_BREADCRUMB_OP_BEGIN_COMMAND_LIST, D3D12_AUTO_BREADCRUMB_OP_DISPATCHGRAPH,
	// D3D12_AUTO_BREADCRUMB_OP_SETPROGRAM } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_AUTO_BREADCRUMB_OP")]
	public enum D3D12_AUTO_BREADCRUMB_OP
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>(0)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_SETMARKER = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(1)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_BEGINEVENT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(2)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_ENDEVENT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(3)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_DRAWINSTANCED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(4)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_DRAWINDEXEDINSTANCED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(5)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_EXECUTEINDIRECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(6)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_DISPATCH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(7)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_COPYBUFFERREGION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(8)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_COPYTEXTUREREGION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(9)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_COPYRESOURCE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(10)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_COPYTILES,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(11)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_RESOLVESUBRESOURCE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(12)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_CLEARRENDERTARGETVIEW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(13)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_CLEARUNORDEREDACCESSVIEW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(14)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_CLEARDEPTHSTENCILVIEW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(15)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_RESOURCEBARRIER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(16)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_EXECUTEBUNDLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(17)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_PRESENT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(18)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_RESOLVEQUERYDATA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(19)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_BEGINSUBMISSION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(20)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_ENDSUBMISSION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(21)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_DECODEFRAME,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(22)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_PROCESSFRAMES,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(23)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_ATOMICCOPYBUFFERUINT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(24)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_ATOMICCOPYBUFFERUINT64,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(25)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_RESOLVESUBRESOURCEREGION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(26)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_WRITEBUFFERIMMEDIATE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(27)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_DECODEFRAME1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(28)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_SETPROTECTEDRESOURCESESSION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(29)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_DECODEFRAME2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(30)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_PROCESSFRAMES1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(31)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_BUILDRAYTRACINGACCELERATIONSTRUCTURE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(32)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_EMITRAYTRACINGACCELERATIONSTRUCTUREPOSTBUILDINFO,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(33)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_COPYRAYTRACINGACCELERATIONSTRUCTURE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(34)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_DISPATCHRAYS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(35)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_INITIALIZEMETACOMMAND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(36)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_EXECUTEMETACOMMAND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(37)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_ESTIMATEMOTION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(38)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_RESOLVEMOTIONVECTORHEAP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(39)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_SETPIPELINESTATE1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(40)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_INITIALIZEEXTENSIONCOMMAND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(41)</para>
		/// </summary>
		D3D12_AUTO_BREADCRUMB_OP_EXECUTEEXTENSIONCOMMAND,
	}

	/// <summary>
	/// Defines constants that specify the shading rate (for variable-rate shading, or VRS) along a horizontal or vertical axis. For more
	/// info, see Variable-rate shading (VRS).
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_axis_shading_rate typedef enum D3D12_AXIS_SHADING_RATE {
	// D3D12_AXIS_SHADING_RATE_1X = 0, D3D12_AXIS_SHADING_RATE_2X = 0x1, D3D12_AXIS_SHADING_RATE_4X = 0x2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_AXIS_SHADING_RATE")]
	public enum D3D12_AXIS_SHADING_RATE
	{
		/// <summary>
		/// <para>Value: 0 Specifies a 1x shading rate for the axis.</para>
		/// </summary>
		D3D12_AXIS_SHADING_RATE_1X = 0,

		/// <summary>
		/// <para>Value: 0x1 Specifies a 2x shading rate for the axis.</para>
		/// </summary>
		D3D12_AXIS_SHADING_RATE_2X,

		/// <summary>
		/// <para>Value: 0x2 Specifies a 4x shading rate for the axis.</para>
		/// </summary>
		D3D12_AXIS_SHADING_RATE_4X,
	}

	/// <summary>Defines constants that specify a level of dynamic optimization to apply to GPU work that's subsequently submitted.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_background_processing_mode typedef enum
	// D3D12_BACKGROUND_PROCESSING_MODE { D3D12_BACKGROUND_PROCESSING_MODE_ALLOWED = 0,
	// D3D12_BACKGROUND_PROCESSING_MODE_ALLOW_INTRUSIVE_MEASUREMENTS, D3D12_BACKGROUND_PROCESSING_MODE_DISABLE_BACKGROUND_WORK,
	// D3D12_BACKGROUND_PROCESSING_MODE_DISABLE_PROFILING_BY_SYSTEM } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_BACKGROUND_PROCESSING_MODE")]
	public enum D3D12_BACKGROUND_PROCESSING_MODE
	{
		/// <summary>
		/// <para>Value: 0 
		/// The default setting. Specifies that the driver may instrument workloads, and dynamically recompile shaders, in a low overhead,
		/// non-intrusive manner that avoids glitching the foreground workload.
		/// </para>
		/// </summary>
		D3D12_BACKGROUND_PROCESSING_MODE_ALLOWED = 0,

		/// <summary>
		/// Specifies that the driver may instrument as aggressively as possible. The understanding is that causing glitches is fine while
		/// in this mode, because the current work is being submitted specifically to train the system.
		/// </summary>
		D3D12_BACKGROUND_PROCESSING_MODE_ALLOW_INTRUSIVE_MEASUREMENTS,

		/// <summary>
		/// Specifies that background work should stop. This ensures that background shader recompilation won't consume CPU cycles.
		/// Available only in Developer mode.
		/// </summary>
		D3D12_BACKGROUND_PROCESSING_MODE_DISABLE_BACKGROUND_WORK,

		/// <summary>
		/// Specifies that all dynamic optimization should be disabled. For example, if you're doing an A/B performance comparison, then
		/// using this constant ensures that the driver doesn't change anything that might interfere with your results. Available only in
		/// Developer mode.
		/// </summary>
		D3D12_BACKGROUND_PROCESSING_MODE_DISABLE_PROFILING_BY_SYSTEM,
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_barrier_access typedef enum D3D12_BARRIER_ACCESS {
	// D3D12_BARRIER_ACCESS_COMMON, D3D12_BARRIER_ACCESS_VERTEX_BUFFER, D3D12_BARRIER_ACCESS_CONSTANT_BUFFER,
	// D3D12_BARRIER_ACCESS_INDEX_BUFFER, D3D12_BARRIER_ACCESS_RENDER_TARGET, D3D12_BARRIER_ACCESS_UNORDERED_ACCESS,
	// D3D12_BARRIER_ACCESS_DEPTH_STENCIL_WRITE, D3D12_BARRIER_ACCESS_DEPTH_STENCIL_READ, D3D12_BARRIER_ACCESS_SHADER_RESOURCE,
	// D3D12_BARRIER_ACCESS_STREAM_OUTPUT, D3D12_BARRIER_ACCESS_INDIRECT_ARGUMENT, D3D12_BARRIER_ACCESS_PREDICATION,
	// D3D12_BARRIER_ACCESS_COPY_DEST, D3D12_BARRIER_ACCESS_COPY_SOURCE, D3D12_BARRIER_ACCESS_RESOLVE_DEST,
	// D3D12_BARRIER_ACCESS_RESOLVE_SOURCE, D3D12_BARRIER_ACCESS_RAYTRACING_ACCELERATION_STRUCTURE_READ,
	// D3D12_BARRIER_ACCESS_RAYTRACING_ACCELERATION_STRUCTURE_WRITE, D3D12_BARRIER_ACCESS_SHADING_RATE_SOURCE,
	// D3D12_BARRIER_ACCESS_VIDEO_DECODE_READ, D3D12_BARRIER_ACCESS_VIDEO_DECODE_WRITE, D3D12_BARRIER_ACCESS_VIDEO_PROCESS_READ,
	// D3D12_BARRIER_ACCESS_VIDEO_PROCESS_WRITE, D3D12_BARRIER_ACCESS_VIDEO_ENCODE_READ, D3D12_BARRIER_ACCESS_VIDEO_ENCODE_WRITE,
	// D3D12_BARRIER_ACCESS_NO_ACCESS } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_BARRIER_ACCESS")]
	[Flags]
	public enum D3D12_BARRIER_ACCESS : uint
	{
		/// <summary/>
		D3D12_BARRIER_ACCESS_COMMON = 0,

		/// <summary/>
		D3D12_BARRIER_ACCESS_VERTEX_BUFFER = 0x1,

		/// <summary/>
		D3D12_BARRIER_ACCESS_CONSTANT_BUFFER = 0x2,

		/// <summary/>
		D3D12_BARRIER_ACCESS_INDEX_BUFFER = 0x4,

		/// <summary/>
		D3D12_BARRIER_ACCESS_RENDER_TARGET = 0x8,

		/// <summary/>
		D3D12_BARRIER_ACCESS_UNORDERED_ACCESS = 0x10,

		/// <summary/>
		D3D12_BARRIER_ACCESS_DEPTH_STENCIL_WRITE = 0x20,

		/// <summary/>
		D3D12_BARRIER_ACCESS_DEPTH_STENCIL_READ = 0x40,

		/// <summary/>
		D3D12_BARRIER_ACCESS_SHADER_RESOURCE = 0x80,

		/// <summary/>
		D3D12_BARRIER_ACCESS_STREAM_OUTPUT = 0x100,

		/// <summary/>
		D3D12_BARRIER_ACCESS_INDIRECT_ARGUMENT = 0x200,

		/// <summary/>
		D3D12_BARRIER_ACCESS_PREDICATION = 0x200,

		/// <summary/>
		D3D12_BARRIER_ACCESS_COPY_DEST = 0x400,

		/// <summary/>
		D3D12_BARRIER_ACCESS_COPY_SOURCE = 0x800,

		/// <summary/>
		D3D12_BARRIER_ACCESS_RESOLVE_DEST = 0x1000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_RESOLVE_SOURCE = 0x2000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_RAYTRACING_ACCELERATION_STRUCTURE_READ = 0x4000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_RAYTRACING_ACCELERATION_STRUCTURE_WRITE = 0x8000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_SHADING_RATE_SOURCE = 0x10000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_VIDEO_DECODE_READ = 0x20000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_VIDEO_DECODE_WRITE = 0x40000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_VIDEO_PROCESS_READ = 0x80000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_VIDEO_PROCESS_WRITE = 0x100000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_VIDEO_ENCODE_READ = 0x200000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_VIDEO_ENCODE_WRITE = 0x400000,

		/// <summary/>
		D3D12_BARRIER_ACCESS_NO_ACCESS = 0x80000000
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_barrier_layout typedef enum D3D12_BARRIER_LAYOUT {
	// D3D12_BARRIER_LAYOUT_UNDEFINED, D3D12_BARRIER_LAYOUT_COMMON, D3D12_BARRIER_LAYOUT_PRESENT, D3D12_BARRIER_LAYOUT_GENERIC_READ,
	// D3D12_BARRIER_LAYOUT_RENDER_TARGET, D3D12_BARRIER_LAYOUT_UNORDERED_ACCESS, D3D12_BARRIER_LAYOUT_DEPTH_STENCIL_WRITE,
	// D3D12_BARRIER_LAYOUT_DEPTH_STENCIL_READ, D3D12_BARRIER_LAYOUT_SHADER_RESOURCE, D3D12_BARRIER_LAYOUT_COPY_SOURCE,
	// D3D12_BARRIER_LAYOUT_COPY_DEST, D3D12_BARRIER_LAYOUT_RESOLVE_SOURCE, D3D12_BARRIER_LAYOUT_RESOLVE_DEST,
	// D3D12_BARRIER_LAYOUT_SHADING_RATE_SOURCE, D3D12_BARRIER_LAYOUT_VIDEO_DECODE_READ, D3D12_BARRIER_LAYOUT_VIDEO_DECODE_WRITE,
	// D3D12_BARRIER_LAYOUT_VIDEO_PROCESS_READ, D3D12_BARRIER_LAYOUT_VIDEO_PROCESS_WRITE, D3D12_BARRIER_LAYOUT_VIDEO_ENCODE_READ,
	// D3D12_BARRIER_LAYOUT_VIDEO_ENCODE_WRITE, D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_COMMON, D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_GENERIC_READ,
	// D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_UNORDERED_ACCESS, D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_SHADER_RESOURCE,
	// D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_COPY_SOURCE, D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_COPY_DEST,
	// D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_COMMON, D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_GENERIC_READ,
	// D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_UNORDERED_ACCESS, D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_SHADER_RESOURCE,
	// D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_COPY_SOURCE, D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_COPY_DEST, D3D12_BARRIER_LAYOUT_VIDEO_QUEUE_COMMON
	// } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_BARRIER_LAYOUT")]
	public enum D3D12_BARRIER_LAYOUT : uint
	{
		/// <summary/>
		D3D12_BARRIER_LAYOUT_UNDEFINED = 0xffffffff,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_COMMON = 0,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_PRESENT = 0,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_GENERIC_READ,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_RENDER_TARGET,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_UNORDERED_ACCESS,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_DEPTH_STENCIL_WRITE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_DEPTH_STENCIL_READ,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_SHADER_RESOURCE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_COPY_SOURCE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_COPY_DEST,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_RESOLVE_SOURCE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_RESOLVE_DEST,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_SHADING_RATE_SOURCE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_VIDEO_DECODE_READ,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_VIDEO_DECODE_WRITE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_VIDEO_PROCESS_READ,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_VIDEO_PROCESS_WRITE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_VIDEO_ENCODE_READ,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_VIDEO_ENCODE_WRITE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_COMMON,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_GENERIC_READ,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_UNORDERED_ACCESS,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_SHADER_RESOURCE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_COPY_SOURCE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_DIRECT_QUEUE_COPY_DEST,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_COMMON,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_GENERIC_READ,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_UNORDERED_ACCESS,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_SHADER_RESOURCE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_COPY_SOURCE,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_COMPUTE_QUEUE_COPY_DEST,

		/// <summary/>
		D3D12_BARRIER_LAYOUT_VIDEO_QUEUE_COMMON,
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_barrier_sync typedef enum D3D12_BARRIER_SYNC {
	// D3D12_BARRIER_SYNC_NONE, D3D12_BARRIER_SYNC_ALL, D3D12_BARRIER_SYNC_DRAW, D3D12_BARRIER_SYNC_INDEX_INPUT,
	// D3D12_BARRIER_SYNC_VERTEX_SHADING, D3D12_BARRIER_SYNC_PIXEL_SHADING, D3D12_BARRIER_SYNC_DEPTH_STENCIL,
	// D3D12_BARRIER_SYNC_RENDER_TARGET, D3D12_BARRIER_SYNC_COMPUTE_SHADING, D3D12_BARRIER_SYNC_RAYTRACING, D3D12_BARRIER_SYNC_COPY,
	// D3D12_BARRIER_SYNC_RESOLVE, D3D12_BARRIER_SYNC_EXECUTE_INDIRECT, D3D12_BARRIER_SYNC_PREDICATION, D3D12_BARRIER_SYNC_ALL_SHADING,
	// D3D12_BARRIER_SYNC_NON_PIXEL_SHADING, D3D12_BARRIER_SYNC_EMIT_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO,
	// D3D12_BARRIER_SYNC_CLEAR_UNORDERED_ACCESS_VIEW, D3D12_BARRIER_SYNC_VIDEO_DECODE, D3D12_BARRIER_SYNC_VIDEO_PROCESS,
	// D3D12_BARRIER_SYNC_VIDEO_ENCODE, D3D12_BARRIER_SYNC_BUILD_RAYTRACING_ACCELERATION_STRUCTURE,
	// D3D12_BARRIER_SYNC_COPY_RAYTRACING_ACCELERATION_STRUCTURE, D3D12_BARRIER_SYNC_SPLIT } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_BARRIER_SYNC")]
	[Flags]
	public enum D3D12_BARRIER_SYNC : uint
	{
		/// <summary/>
		D3D12_BARRIER_SYNC_NONE = 0,

		/// <summary/>
		D3D12_BARRIER_SYNC_ALL = 0x1,

		/// <summary/>
		D3D12_BARRIER_SYNC_DRAW = 0x2,

		/// <summary/>
		D3D12_BARRIER_SYNC_INDEX_INPUT = 0x4,

		/// <summary/>
		D3D12_BARRIER_SYNC_VERTEX_SHADING = 0x8,

		/// <summary/>
		D3D12_BARRIER_SYNC_PIXEL_SHADING = 0x10,

		/// <summary/>
		D3D12_BARRIER_SYNC_DEPTH_STENCIL = 0x20,

		/// <summary/>
		D3D12_BARRIER_SYNC_RENDER_TARGET = 0x40,

		/// <summary/>
		D3D12_BARRIER_SYNC_COMPUTE_SHADING = 0x80,

		/// <summary/>
		D3D12_BARRIER_SYNC_RAYTRACING = 0x100,

		/// <summary/>
		D3D12_BARRIER_SYNC_COPY = 0x200,

		/// <summary/>
		D3D12_BARRIER_SYNC_RESOLVE = 0x400,

		/// <summary/>
		D3D12_BARRIER_SYNC_EXECUTE_INDIRECT = 0x800,

		/// <summary/>
		D3D12_BARRIER_SYNC_PREDICATION = 0x800,

		/// <summary/>
		D3D12_BARRIER_SYNC_ALL_SHADING = 0x1000,

		/// <summary/>
		D3D12_BARRIER_SYNC_NON_PIXEL_SHADING = 0x2000,

		/// <summary/>
		D3D12_BARRIER_SYNC_EMIT_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO = 0x4000,

		/// <summary/>
		D3D12_BARRIER_SYNC_CLEAR_UNORDERED_ACCESS_VIEW = 0x8000,

		/// <summary/>
		D3D12_BARRIER_SYNC_VIDEO_DECODE = 0x100000,

		/// <summary/>
		D3D12_BARRIER_SYNC_VIDEO_PROCESS = 0x200000,

		/// <summary/>
		D3D12_BARRIER_SYNC_VIDEO_ENCODE = 0x400000,

		/// <summary/>
		D3D12_BARRIER_SYNC_BUILD_RAYTRACING_ACCELERATION_STRUCTURE = 0x800000,

		/// <summary/>
		D3D12_BARRIER_SYNC_COPY_RAYTRACING_ACCELERATION_STRUCTURE = 0x1000000,

		/// <summary/>
		D3D12_BARRIER_SYNC_SPLIT = 0x80000000
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_barrier_type typedef enum D3D12_BARRIER_TYPE {
	// D3D12_BARRIER_TYPE_GLOBAL, D3D12_BARRIER_TYPE_TEXTURE, D3D12_BARRIER_TYPE_BUFFER } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_BARRIER_TYPE")]
	public enum D3D12_BARRIER_TYPE
	{
		/// <summary/>
		D3D12_BARRIER_TYPE_GLOBAL = 0,

		/// <summary/>
		D3D12_BARRIER_TYPE_TEXTURE,

		/// <summary/>
		D3D12_BARRIER_TYPE_BUFFER,
	}

	/// <summary>Specifies blend factors, which modulate values for the pixel shader and render target.</summary>
	/// <remarks>Source and destination blend operations are specified in a D3D12_RENDER_TARGET_BLEND_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_blend typedef enum D3D12_BLEND { D3D12_BLEND_ZERO = 1,
	// D3D12_BLEND_ONE = 2, D3D12_BLEND_SRC_COLOR = 3, D3D12_BLEND_INV_SRC_COLOR = 4, D3D12_BLEND_SRC_ALPHA = 5, D3D12_BLEND_INV_SRC_ALPHA =
	// 6, D3D12_BLEND_DEST_ALPHA = 7, D3D12_BLEND_INV_DEST_ALPHA = 8, D3D12_BLEND_DEST_COLOR = 9, D3D12_BLEND_INV_DEST_COLOR = 10,
	// D3D12_BLEND_SRC_ALPHA_SAT = 11, D3D12_BLEND_BLEND_FACTOR = 14, D3D12_BLEND_INV_BLEND_FACTOR = 15, D3D12_BLEND_SRC1_COLOR = 16,
	// D3D12_BLEND_INV_SRC1_COLOR = 17, D3D12_BLEND_SRC1_ALPHA = 18, D3D12_BLEND_INV_SRC1_ALPHA = 19, D3D12_BLEND_ALPHA_FACTOR = 20,
	// D3D12_BLEND_INV_ALPHA_FACTOR = 21 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_BLEND")]
	public enum D3D12_BLEND
	{
		/// <summary>
		/// <para>Value: 1 The blend factor is (0, 0, 0, 0). No pre-blend operation.</para>
		/// </summary>
		D3D12_BLEND_ZERO = 1,

		/// <summary>
		/// <para>Value: 2 The blend factor is (1, 1, 1, 1). No pre-blend operation.</para>
		/// </summary>
		D3D12_BLEND_ONE,

		/// <summary>
		/// <para>Value: 3 The blend factor is (Rₛ, Gₛ, Bₛ, Aₛ), that is color data (RGB) from a pixel shader. No pre-blend operation.</para>
		/// </summary>
		D3D12_BLEND_SRC_COLOR,

		/// <summary>
		/// <para>Value: 4 
		/// The blend factor is (1 - Rₛ, 1 - Gₛ, 1 - Bₛ, 1 - Aₛ), that is color data (RGB) from a pixel shader. The pre-blend operation
		/// inverts the data, generating 1 - RGB.
		/// </para>
		/// </summary>
		D3D12_BLEND_INV_SRC_COLOR,

		/// <summary>
		/// <para>Value: 5 The blend factor is (Aₛ, Aₛ, Aₛ, Aₛ), that is alpha data (A) from a pixel shader. No pre-blend operation.</para>
		/// </summary>
		D3D12_BLEND_SRC_ALPHA,

		/// <summary>
		/// <para>Value: 6 
		/// The blend factor is ( 1 - Aₛ, 1 - Aₛ, 1 - Aₛ, 1 - Aₛ), that is alpha data (A) from a pixel shader. The pre-blend operation
		/// inverts the data, generating 1 - A.
		/// </para>
		/// </summary>
		D3D12_BLEND_INV_SRC_ALPHA,

		/// <summary>
		/// <para>Value: 7 
		/// The blend factor is (A <sub>d</sub> A <sub>d</sub> A <sub>d</sub> A <sub>d</sub>), that is alpha data from a render target. No
		/// pre-blend operation.
		/// </para>
		/// </summary>
		D3D12_BLEND_DEST_ALPHA,

		/// <summary>
		/// <para>Value: 8 
		/// The blend factor is (1 - A <sub>d</sub> 1 - A <sub>d</sub> 1 - A <sub>d</sub> 1 - A <sub>d</sub>), that is alpha data from a
		/// render target. The pre-blend operation inverts the data, generating 1 - A.
		/// </para>
		/// </summary>
		D3D12_BLEND_INV_DEST_ALPHA,

		/// <summary>
		/// <para>Value: 9 
		/// The blend factor is (R <sub>d</sub>, G <sub>d</sub>, B <sub>d</sub>, A <sub>d</sub>), that is color data from a render target.
		/// No pre-blend operation.
		/// </para>
		/// </summary>
		D3D12_BLEND_DEST_COLOR,

		/// <summary>
		/// <para>Value: 10 
		/// The blend factor is (1 - R <sub>d</sub>, 1 - G <sub>d</sub>, 1 - B <sub>d</sub>, 1 - A <sub>d</sub>), that is color data from a
		/// render target. The pre-blend operation inverts the data, generating 1 - RGB.
		/// </para>
		/// </summary>
		D3D12_BLEND_INV_DEST_COLOR,

		/// <summary>
		/// <para>Value: 11 
		/// The blend factor is (f, f, f, 1); where f = min(Aₛ, 1 - A <sub>d</sub>). The pre-blend operation clamps the data to 1 or less.
		/// </para>
		/// </summary>
		D3D12_BLEND_SRC_ALPHA_SAT,

		/// <summary>
		/// <para>Value: 14 The blend factor is the blend factor set with ID3D12GraphicsCommandList::OMSetBlendFactor. No pre-blend operation.</para>
		/// </summary>
		D3D12_BLEND_BLEND_FACTOR = 14,

		/// <summary>
		/// <para>Value: 15 
		/// The blend factor is the blend factor set with ID3D12GraphicsCommandList::OMSetBlendFactor. The pre-blend operation inverts the
		/// blend factor, generating 1 - blend_factor.
		/// </para>
		/// </summary>
		D3D12_BLEND_INV_BLEND_FACTOR,

		/// <summary>
		/// <para>Value: 16 
		/// The blend factor is data sources both as color data output by a pixel shader. There is no pre-blend operation. This blend factor
		/// supports dual-source color blending.
		/// </para>
		/// </summary>
		D3D12_BLEND_SRC1_COLOR,

		/// <summary>
		/// <para>Value: 17 
		/// The blend factor is data sources both as color data output by a pixel shader. The pre-blend operation inverts the data,
		/// generating 1 - RGB. This blend factor supports dual-source color blending.
		/// </para>
		/// </summary>
		D3D12_BLEND_INV_SRC1_COLOR,

		/// <summary>
		/// <para>Value: 18 
		/// The blend factor is data sources as alpha data output by a pixel shader. There is no pre-blend operation. This blend factor
		/// supports dual-source color blending.
		/// </para>
		/// </summary>
		D3D12_BLEND_SRC1_ALPHA,

		/// <summary>
		/// <para>Value: 19 
		/// The blend factor is data sources as alpha data output by a pixel shader. The pre-blend operation inverts the data, generating 1
		/// - A. This blend factor supports dual-source color blending.
		/// </para>
		/// </summary>
		D3D12_BLEND_INV_SRC1_ALPHA,

		/// <summary>
		/// <para>Value: 20 The blend factor is (A, A, A, A), where the constant, A, is taken from the blend factor set with OMSetBlendFactor.</para>
		/// <para>
		/// To successfully use this constant on a target machine, the D3D12_FEATURE_DATA_D3D12_OPTIONS13 returned from capability querying
		/// must have its AlphaBlendFactorSupported set to TRUE.
		/// </para>
		/// </summary>
		D3D12_BLEND_ALPHA_FACTOR,

		/// <summary>
		/// <para>Value: 21 The blend factor is (1 – A, 1 – A, 1 – A, 1 – A), where the constant, A, is taken from the blend factor set with OMSetBlendFactor.</para>
		/// <para>
		/// To successfully use this constant on a target machine, the D3D12_FEATURE_DATA_D3D12_OPTIONS13 returned from capability querying
		/// must have its AlphaBlendFactorSupported set to TRUE.
		/// </para>
		/// </summary>
		D3D12_BLEND_INV_ALPHA_FACTOR,
	}

	/// <summary>Specifies RGB or alpha blending operations.</summary>
	/// <remarks>
	/// <para>
	/// The runtime implements RGB blending and alpha blending separately. Therefore, blend state requires separate blend operations for RGB
	/// data and alpha data. These blend operations are specified in a D3D12_RENDER_TARGET_BLEND_DESC structure. The two sources —source 1
	/// and source 2— are shown in the blending block diagram.
	/// </para>
	/// <para>
	/// Blend state is used by the output-merger stage to determine how to blend together two RGB pixel values and two alpha values. The two
	/// RGB pixel values and two alpha values are the RGB pixel value and alpha value that the pixel shader outputs and the RGB pixel value
	/// and alpha value already in the output render target. The D3D12_BLEND value controls the data source that the blending stage uses to
	/// modulate values for the pixel shader, render target, or both. The <c>D3D12_BLEND_OP</c> value controls how the blending stage
	/// mathematically combines these modulated values.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_blend_op typedef enum D3D12_BLEND_OP { D3D12_BLEND_OP_ADD =
	// 1, D3D12_BLEND_OP_SUBTRACT = 2, D3D12_BLEND_OP_REV_SUBTRACT = 3, D3D12_BLEND_OP_MIN = 4, D3D12_BLEND_OP_MAX = 5 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_BLEND_OP")]
	public enum D3D12_BLEND_OP
	{
		/// <summary>
		/// <para>Value: 1 Add source 1 and source 2.</para>
		/// </summary>
		D3D12_BLEND_OP_ADD = 1,

		/// <summary>
		/// <para>Value: 2 Subtract source 1 from source 2.</para>
		/// </summary>
		D3D12_BLEND_OP_SUBTRACT,

		/// <summary>
		/// <para>Value: 3 Subtract source 2 from source 1.</para>
		/// </summary>
		D3D12_BLEND_OP_REV_SUBTRACT,

		/// <summary>
		/// <para>Value: 4 Find the minimum of source 1 and source 2.</para>
		/// </summary>
		D3D12_BLEND_OP_MIN,

		/// <summary>
		/// <para>Value: 5 Find the maximum of source 1 and source 2.</para>
		/// </summary>
		D3D12_BLEND_OP_MAX,
	}

	/// <summary>Identifies how to view a buffer resource.</summary>
	/// <remarks>This enumeration is used by D3D12_BUFFER_SRV.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_buffer_srv_flags typedef enum D3D12_BUFFER_SRV_FLAGS {
	// D3D12_BUFFER_SRV_FLAG_NONE = 0, D3D12_BUFFER_SRV_FLAG_RAW = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_BUFFER_SRV_FLAGS")]
	[Flags]
	public enum D3D12_BUFFER_SRV_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Indicates a default view.</para>
		/// </summary>
		D3D12_BUFFER_SRV_FLAG_NONE = 0,

		/// <summary>
		/// <para>Value: 0x1 View the buffer as raw. For more info about raw viewing of buffers, see Raw Views of Buffers.</para>
		/// </summary>
		D3D12_BUFFER_SRV_FLAG_RAW = 0x1,
	}

	/// <summary>Identifies unordered-access view options for a buffer resource.</summary>
	/// <remarks>This enum is used in the D3D12_BUFFER_UAV structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_buffer_uav_flags typedef enum D3D12_BUFFER_UAV_FLAGS {
	// D3D12_BUFFER_UAV_FLAG_NONE = 0, D3D12_BUFFER_UAV_FLAG_RAW = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_BUFFER_UAV_FLAGS")]
	[Flags]
	public enum D3D12_BUFFER_UAV_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Indicates a default view.</para>
		/// </summary>
		D3D12_BUFFER_UAV_FLAG_NONE = 0,

		/// <summary>
		/// <para>Value: 0x1 Resource contains raw, unstructured data. Requires the UAV format to be DXGI_FORMAT_R32_TYPELESS.</para>
		/// <para>For more info about raw viewing of buffers, see Raw Views of Buffers.</para>
		/// </summary>
		D3D12_BUFFER_UAV_FLAG_RAW = 0x1,
	}

	/// <summary>Specifies what to clear from the depth stencil view.</summary>
	/// <remarks>This enum is used by ID3D12GraphicsCommandList::ClearDepthStencilView. The flags can be combined to clear all.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_clear_flags typedef enum D3D12_CLEAR_FLAGS {
	// D3D12_CLEAR_FLAG_DEPTH = 0x1, D3D12_CLEAR_FLAG_STENCIL = 0x2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_CLEAR_FLAGS")]
	[Flags]
	public enum D3D12_CLEAR_FLAGS
	{
		/// <summary>
		/// <para>Value: 0x1 Indicates the depth buffer should be cleared.</para>
		/// </summary>
		D3D12_CLEAR_FLAG_DEPTH = 0x1,

		/// <summary>
		/// <para>Value: 0x2 Indicates the stencil buffer should be cleared.</para>
		/// </summary>
		D3D12_CLEAR_FLAG_STENCIL = 0x2,
	}

	/// <summary>Identifies which components of each pixel of a render target are writable during blending.</summary>
	/// <remarks>This enum is used by the D3D12_RENDER_TARGET_BLEND_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_color_write_enable typedef enum D3D12_COLOR_WRITE_ENABLE {
	// D3D12_COLOR_WRITE_ENABLE_RED = 1, D3D12_COLOR_WRITE_ENABLE_GREEN = 2, D3D12_COLOR_WRITE_ENABLE_BLUE = 4,
	// D3D12_COLOR_WRITE_ENABLE_ALPHA = 8, D3D12_COLOR_WRITE_ENABLE_ALL } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_COLOR_WRITE_ENABLE")]
	[Flags]
	public enum D3D12_COLOR_WRITE_ENABLE : byte
	{
		/// <summary>
		/// <para>Value: 1 Allow data to be stored in the red component.</para>
		/// </summary>
		D3D12_COLOR_WRITE_ENABLE_RED = 1,

		/// <summary>
		/// <para>Value: 2 Allow data to be stored in the green component.</para>
		/// </summary>
		D3D12_COLOR_WRITE_ENABLE_GREEN = 2,

		/// <summary>
		/// <para>Value: 4 Allow data to be stored in the blue component.</para>
		/// </summary>
		D3D12_COLOR_WRITE_ENABLE_BLUE = 4,

		/// <summary>
		/// <para>Value: 8 Allow data to be stored in the alpha component.</para>
		/// </summary>
		D3D12_COLOR_WRITE_ENABLE_ALPHA = 8,

		/// <summary>Allow data to be stored in all components.</summary>
		D3D12_COLOR_WRITE_ENABLE_ALL = 0xF,
	}

	/// <summary>Specifies flags to be used when creating a command list.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_list_flags typedef enum D3D12_COMMAND_LIST_FLAGS {
	// D3D12_COMMAND_LIST_FLAG_NONE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_COMMAND_LIST_FLAGS")]
	[Flags]
	public enum D3D12_COMMAND_LIST_FLAGS
	{
		/// <summary>No flags specified.</summary>
		D3D12_COMMAND_LIST_FLAG_NONE,
	}

	/// <summary>
	/// Used to determine which kinds of command lists are capable of supporting various operations. For example, whether a command list
	/// supports immediate writes.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_list_support_flags typedef enum
	// D3D12_COMMAND_LIST_SUPPORT_FLAGS { D3D12_COMMAND_LIST_SUPPORT_FLAG_NONE = 0, D3D12_COMMAND_LIST_SUPPORT_FLAG_DIRECT,
	// D3D12_COMMAND_LIST_SUPPORT_FLAG_BUNDLE, D3D12_COMMAND_LIST_SUPPORT_FLAG_COMPUTE, D3D12_COMMAND_LIST_SUPPORT_FLAG_COPY,
	// D3D12_COMMAND_LIST_SUPPORT_FLAG_VIDEO_DECODE, D3D12_COMMAND_LIST_SUPPORT_FLAG_VIDEO_PROCESS,
	// D3D12_COMMAND_LIST_SUPPORT_FLAG_VIDEO_ENCODE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_COMMAND_LIST_SUPPORT_FLAGS")]
	[Flags]
	public enum D3D12_COMMAND_LIST_SUPPORT_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Specifies that no command list supports the operation in question.</para>
		/// </summary>
		D3D12_COMMAND_LIST_SUPPORT_FLAG_NONE = 0,

		/// <summary>Specifies that direct command lists can support the operation in question.</summary>
		D3D12_COMMAND_LIST_SUPPORT_FLAG_DIRECT = 1 << D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_DIRECT,

		/// <summary>Specifies that command list bundles can support the operation in question.</summary>
		D3D12_COMMAND_LIST_SUPPORT_FLAG_BUNDLE = 1 << D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_BUNDLE,

		/// <summary>Specifies that compute command lists can support the operation in question.</summary>
		D3D12_COMMAND_LIST_SUPPORT_FLAG_COMPUTE = 1 << D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_COMPUTE,

		/// <summary>Specifies that copy command lists can support the operation in question.</summary>
		D3D12_COMMAND_LIST_SUPPORT_FLAG_COPY = 1 << D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_COPY,

		/// <summary>Specifies that video-decode command lists can support the operation in question.</summary>
		D3D12_COMMAND_LIST_SUPPORT_FLAG_VIDEO_DECODE = 1 << D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_VIDEO_DECODE,

		/// <summary>Specifies that video-processing command lists can support the operation is question.</summary>
		D3D12_COMMAND_LIST_SUPPORT_FLAG_VIDEO_PROCESS = 1 << D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_VIDEO_PROCESS,
	}

	/// <summary>Specifies the type of a command list.</summary>
	/// <remarks>
	/// <para>This enum is used by the following methods:</para>
	/// <list type="bullet">
	///   <item>
	///     <description>CreateCommandAllocator</description>
	///   </item>
	///   <item>
	///     <description>CreateCommandQueue</description>
	///   </item>
	///   <item>
	///     <description>CreateCommandList</description>
	///   </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_list_type typedef enum D3D12_COMMAND_LIST_TYPE {
	// D3D12_COMMAND_LIST_TYPE_DIRECT = 0, D3D12_COMMAND_LIST_TYPE_BUNDLE = 1, D3D12_COMMAND_LIST_TYPE_COMPUTE = 2,
	// D3D12_COMMAND_LIST_TYPE_COPY = 3, D3D12_COMMAND_LIST_TYPE_VIDEO_DECODE = 4, D3D12_COMMAND_LIST_TYPE_VIDEO_PROCESS = 5,
	// D3D12_COMMAND_LIST_TYPE_VIDEO_ENCODE, D3D12_COMMAND_LIST_TYPE_NONE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_COMMAND_LIST_TYPE")]
	public enum D3D12_COMMAND_LIST_TYPE
	{
		/// <summary>Value: 0 Specifies a command buffer that the GPU can execute. A direct command list doesn't inherit any GPU state.</summary>
		D3D12_COMMAND_LIST_TYPE_DIRECT = 0,

		/// <summary>
		/// Value: 1
		/// Specifies a command buffer that can be executed only directly via a direct command list. A bundle command list inherits all GPU
		/// state (except for the currently set pipeline state object and primitive topology).
		/// </summary>
		D3D12_COMMAND_LIST_TYPE_BUNDLE,

		/// <summary>Value: 2 Specifies a command buffer for computing.</summary>
		D3D12_COMMAND_LIST_TYPE_COMPUTE,

		/// <summary>Value: 3 Specifies a command buffer for copying.</summary>
		D3D12_COMMAND_LIST_TYPE_COPY,

		/// <summary>Value: 4 Specifies a command buffer for video decoding.</summary>
		D3D12_COMMAND_LIST_TYPE_VIDEO_DECODE,

		/// <summary>Value: 5 Specifies a command buffer for video processing.</summary>
		D3D12_COMMAND_LIST_TYPE_VIDEO_PROCESS,
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_pool_flags typedef enum D3D12_COMMAND_POOL_FLAGS {
	// D3D12_COMMAND_POOL_FLAG_NONE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_COMMAND_POOL_FLAGS")]
	public enum D3D12_COMMAND_POOL_FLAGS
	{
		/// <summary/>
		D3D12_COMMAND_POOL_FLAG_NONE,
	}

	/// <summary>Specifies flags to be used when creating a command queue.</summary>
	/// <remarks>This enum is used by the D3D12_COMMAND_QUEUE_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_queue_flags typedef enum D3D12_COMMAND_QUEUE_FLAGS {
	// D3D12_COMMAND_QUEUE_FLAG_NONE = 0, D3D12_COMMAND_QUEUE_FLAG_DISABLE_GPU_TIMEOUT = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_COMMAND_QUEUE_FLAGS")]
	[Flags]
	public enum D3D12_COMMAND_QUEUE_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Indicates a default command queue.</para>
		/// </summary>
		D3D12_COMMAND_QUEUE_FLAG_NONE,

		/// <summary>
		/// <para>Value: 0x1 Indicates that the GPU timeout should be disabled for this command queue.</para>
		/// </summary>
		D3D12_COMMAND_QUEUE_FLAG_DISABLE_GPU_TIMEOUT,
	}

	/// <summary>Defines priority levels for a command queue.</summary>
	/// <remarks>
	/// <para>This enumeration is used by the <c>Priority</c> member of the D3D12_COMMAND_QUEUE_DESC structure.</para>
	/// <para>
	/// An application must be sufficiently privileged in order to create a command queue that has global realtime priority. If the
	/// application is not sufficiently privileged or if neither the adapter or driver can provide the necessary preemption, then requests
	/// to create a global realtime priority queue fail; such a failure could be due to a lack of hardware support or due to conflicts with
	/// other command queue parameters. Requests to create a global realtime command queue won't silently downgrade the priority when it
	/// can't be supported; the request succeeds or fails as-is to indicate to the application whether or not the command queue is
	/// guaranteed to execute before any other queue.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_queue_priority typedef enum
	// D3D12_COMMAND_QUEUE_PRIORITY { D3D12_COMMAND_QUEUE_PRIORITY_NORMAL = 0, D3D12_COMMAND_QUEUE_PRIORITY_HIGH = 100,
	// D3D12_COMMAND_QUEUE_PRIORITY_GLOBAL_REALTIME = 10000 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_COMMAND_QUEUE_PRIORITY")]
	public enum D3D12_COMMAND_QUEUE_PRIORITY : int
	{
		/// <summary>
		/// <para>Value: 0 Normal priority.</para>
		/// </summary>
		D3D12_COMMAND_QUEUE_PRIORITY_NORMAL = 0,

		/// <summary>
		/// <para>Value: 100 High priority.</para>
		/// </summary>
		D3D12_COMMAND_QUEUE_PRIORITY_HIGH = 100,

		/// <summary>
		/// <para>Value: 10000 Global realtime priority.</para>
		/// </summary>
		D3D12_COMMAND_QUEUE_PRIORITY_GLOBAL_REALTIME = 10000,
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_command_recorder_flags typedef enum
	// D3D12_COMMAND_RECORDER_FLAGS { D3D12_COMMAND_RECORDER_FLAG_NONE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_COMMAND_RECORDER_FLAGS")]
	[Flags]
	public enum D3D12_COMMAND_RECORDER_FLAGS
	{
		/// <summary/>
		D3D12_COMMAND_RECORDER_FLAG_NONE,
	}

	/// <summary>Specifies comparison options.</summary>
	/// <remarks>
	/// <para>
	/// A comparison option determines how the runtime compares source (new) data against destination (existing) data before storing the new
	/// data. The comparison option is declared in a description before an object is created. The API allows you to set a comparison option for
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>a depth-stencil buffer (D3D12_DEPTH_STENCIL_DESC)</description>
	/// </item>
	/// <item>
	/// <description>depth-stencil operations (D3D12_DEPTH_STENCILOP_DESC)</description>
	/// </item>
	/// <item>
	/// <description>sampler state (D3D12_SAMPLER_DESC)</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_comparison_func typedef enum D3D12_COMPARISON_FUNC {
	// D3D12_COMPARISON_FUNC_NONE, D3D12_COMPARISON_FUNC_NEVER = 1, D3D12_COMPARISON_FUNC_LESS = 2, D3D12_COMPARISON_FUNC_EQUAL = 3,
	// D3D12_COMPARISON_FUNC_LESS_EQUAL = 4, D3D12_COMPARISON_FUNC_GREATER = 5, D3D12_COMPARISON_FUNC_NOT_EQUAL = 6,
	// D3D12_COMPARISON_FUNC_GREATER_EQUAL = 7, D3D12_COMPARISON_FUNC_ALWAYS = 8 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_COMPARISON_FUNC")]
	public enum D3D12_COMPARISON_FUNC
	{
		/// <summary>
		/// <para>Value: 1 Never pass the comparison.</para>
		/// </summary>
		D3D12_COMPARISON_FUNC_NEVER,

		/// <summary>
		/// <para>Value: 2 If the source data is less than the destination data, the comparison passes.</para>
		/// </summary>
		D3D12_COMPARISON_FUNC_LESS,

		/// <summary>
		/// <para>Value: 3 If the source data is equal to the destination data, the comparison passes.</para>
		/// </summary>
		D3D12_COMPARISON_FUNC_EQUAL,

		/// <summary>
		/// <para>Value: 4 If the source data is less than or equal to the destination data, the comparison passes.</para>
		/// </summary>
		D3D12_COMPARISON_FUNC_LESS_EQUAL,

		/// <summary>
		/// <para>Value: 5 If the source data is greater than the destination data, the comparison passes.</para>
		/// </summary>
		D3D12_COMPARISON_FUNC_GREATER,

		/// <summary>
		/// <para>Value: 6 If the source data is not equal to the destination data, the comparison passes.</para>
		/// </summary>
		D3D12_COMPARISON_FUNC_NOT_EQUAL,

		/// <summary>
		/// <para>Value: 7 If the source data is greater than or equal to the destination data, the comparison passes.</para>
		/// </summary>
		D3D12_COMPARISON_FUNC_GREATER_EQUAL,

		/// <summary>
		/// <para>Value: 8 Always pass the comparison.</para>
		/// </summary>
		D3D12_COMPARISON_FUNC_ALWAYS,
	}

	/// <summary>Identifies whether conservative rasterization is on or off.</summary>
	/// <remarks>This enum is used by the D3D12_RASTERIZER_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_conservative_rasterization_mode typedef enum
	// D3D12_CONSERVATIVE_RASTERIZATION_MODE { D3D12_CONSERVATIVE_RASTERIZATION_MODE_OFF = 0, D3D12_CONSERVATIVE_RASTERIZATION_MODE_ON = 1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_CONSERVATIVE_RASTERIZATION_MODE")]
	public enum D3D12_CONSERVATIVE_RASTERIZATION_MODE
	{
		/// <summary>
		/// <para>Value: 0 Conservative rasterization is off.</para>
		/// </summary>
		D3D12_CONSERVATIVE_RASTERIZATION_MODE_OFF,

		/// <summary>
		/// <para>Value: 1 Conservative rasterization is on.</para>
		/// </summary>
		D3D12_CONSERVATIVE_RASTERIZATION_MODE_ON,
	}

	/// <summary>Identifies the tier level of conservative rasterization.</summary>
	/// <remarks>This enum is used by the D3D12_FEATURE_DATA_D3D12_OPTIONS structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_conservative_rasterization_tier typedef enum
	// D3D12_CONSERVATIVE_RASTERIZATION_TIER { D3D12_CONSERVATIVE_RASTERIZATION_TIER_NOT_SUPPORTED = 0,
	// D3D12_CONSERVATIVE_RASTERIZATION_TIER_1 = 1, D3D12_CONSERVATIVE_RASTERIZATION_TIER_2 = 2, D3D12_CONSERVATIVE_RASTERIZATION_TIER_3 = 3
	// } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_CONSERVATIVE_RASTERIZATION_TIER")]
	public enum D3D12_CONSERVATIVE_RASTERIZATION_TIER
	{
		/// <summary>
		/// <para>Value: 0 Conservative rasterization is not supported.</para>
		/// </summary>
		D3D12_CONSERVATIVE_RASTERIZATION_TIER_NOT_SUPPORTED,

		/// <summary>
		/// <para>Value: 1 
		/// Tier 1 enforces a maximum 1/2 pixel uncertainty region and does not support post-snap degenerates. This is good for tiled
		/// rendering, a texture atlas, light map generation and sub-pixel shadow maps.
		/// </para>
		/// </summary>
		D3D12_CONSERVATIVE_RASTERIZATION_TIER_1,

		/// <summary>
		/// <para>Value: 2 
		/// Tier 2 reduces the maximum uncertainty region to 1/256 and requires post-snap degenerates not be culled. This tier is helpful
		/// for CPU-based algorithm acceleration (such as voxelization).
		/// </para>
		/// </summary>
		D3D12_CONSERVATIVE_RASTERIZATION_TIER_2,

		/// <summary>
		/// <para>Value: 3 
		/// Tier 3 maintains a maximum 1/256 uncertainty region and adds support for inner input coverage. Inner input coverage adds the new
		/// value SV_InnerCoverage to High Level Shading Language (HLSL). This is a 32-bit scalar integer that can be specified on input to
		/// a pixel shader, and represents the underestimated conservative rasterization information (that is, whether a pixel is
		/// guaranteed-to-be-fully covered). This tier is helpful for occlusion culling.
		/// </para>
		/// </summary>
		D3D12_CONSERVATIVE_RASTERIZATION_TIER_3,
	}

	/// <summary>Specifies the CPU-page properties for the heap.</summary>
	/// <remarks>This enum is used by the D3D12_HEAP_PROPERTIES structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_cpu_page_property typedef enum D3D12_CPU_PAGE_PROPERTY {
	// D3D12_CPU_PAGE_PROPERTY_UNKNOWN = 0, D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE = 1, D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE = 2,
	// D3D12_CPU_PAGE_PROPERTY_WRITE_BACK = 3 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_CPU_PAGE_PROPERTY")]
	public enum D3D12_CPU_PAGE_PROPERTY
	{
		/// <summary>
		/// <para>Value: 0 The CPU-page property is unknown.</para>
		/// </summary>
		D3D12_CPU_PAGE_PROPERTY_UNKNOWN,

		/// <summary>
		/// <para>Value: 1 The CPU cannot access the heap, therefore no page properties are available.</para>
		/// </summary>
		D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE,

		/// <summary>
		/// <para>Value: 2 The CPU-page property is write-combined.</para>
		/// </summary>
		D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE,

		/// <summary>
		/// <para>Value: 3 The CPU-page property is write-back.</para>
		/// </summary>
		D3D12_CPU_PAGE_PROPERTY_WRITE_BACK,
	}

	/// <summary>Specifies the level of sharing across nodes of an adapter, such as Tier 1 Emulated, Tier 1, or Tier 2.</summary>
	/// <remarks>This enum is used by the <c>CrossNodeSharingTier</c> member of the D3D12_FEATURE_DATA_D3D12_OPTIONS structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_cross_node_sharing_tier typedef enum
	// D3D12_CROSS_NODE_SHARING_TIER { D3D12_CROSS_NODE_SHARING_TIER_NOT_SUPPORTED = 0, D3D12_CROSS_NODE_SHARING_TIER_1_EMULATED = 1,
	// D3D12_CROSS_NODE_SHARING_TIER_1 = 2, D3D12_CROSS_NODE_SHARING_TIER_2 = 3, D3D12_CROSS_NODE_SHARING_TIER_3 = 4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_CROSS_NODE_SHARING_TIER")]
	public enum D3D12_CROSS_NODE_SHARING_TIER
	{
		/// <summary>
		/// <para>Value: 0 
		/// If an adapter has only 1 node, then cross-node sharing doesn't apply, so the CrossNodeSharingTier member of the
		/// D3D12_FEATURE_DATA_D3D12_OPTIONS structure is set to D3D12_CROSS_NODE_SHARING_NOT_SUPPORTED.
		/// </para>
		/// </summary>
		D3D12_CROSS_NODE_SHARING_TIER_NOT_SUPPORTED,

		/// <summary>
		/// <para>Value: 1 
		/// Tier 1 Emulated. Devices that set the CrossNodeSharingTier member of the D3D12_FEATURE_DATA_D3D12_OPTIONS structure to
		/// D3D12_CROSS_NODE_SHARING_TIER_1_EMULATED have Tier 1 support.
		/// </para>
		/// <para>
		/// However, drivers stage these copy operations through a driver-internal system memory allocation. This will cause these copy
		/// operations to consume time on the destination GPU as well as the source.
		/// </para>
		/// </summary>
		D3D12_CROSS_NODE_SHARING_TIER_1_EMULATED,

		/// <summary>
		/// <para>Value: 2 
		/// Tier 1. Devices that set the CrossNodeSharingTier member of the D3D12_FEATURE_DATA_D3D12_OPTIONS structure to
		/// D3D12_CROSS_NODE_SHARING_TIER_1 only support the following cross-node copy operations:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>ID3D12CommandList::CopyBufferRegion</description>
		/// </item>
		/// <item>
		/// <description>ID3D12CommandList::CopyTextureRegion</description>
		/// </item>
		/// <item>
		/// <description>ID3D12CommandList::CopyResource</description>
		/// </item>
		/// </list>
		/// <para>Additionally, the cross-node resource must be the destination of the copy operation.</para>
		/// </summary>
		D3D12_CROSS_NODE_SHARING_TIER_1,

		/// <summary>
		/// <para>Value: 3 
		/// Tier 2. Devices that set the CrossNodeSharingTier member of the D3D12_FEATURE_DATA_D3D12_OPTIONS structure to
		/// D3D12_CROSS_NODE_SHARING_TIER_2 support all operations across nodes, except for the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Render target views.</description>
		/// </item>
		/// <item>
		/// <description>Depth stencil views.</description>
		/// </item>
		/// <item>
		/// <description>
		/// UAV atomic operations. Similar to CPU/GPU interop, shaders may perform UAV atomic operations; however, no atomicity across
		/// adapters is guaranteed.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Applications can retrieve the node where a resource/heap exists from the D3D12_HEAP_DESC structure. These values are retrievable
		/// for opened resources. The runtime performs the appropriate re-mapping in case the 2 devices are using different UMD-specified
		/// node re-mappings.
		/// </para>
		/// </summary>
		D3D12_CROSS_NODE_SHARING_TIER_2,

		/// <summary>
		/// <para>Value: 4 Indicates support for</para>
		/// <para><c>D3D12_HEAP_FLAG_ALLOW_SHADER_ATOMICS</c></para>
		/// <para>on heaps that are visible to multiple nodes.</para>
		/// </summary>
		D3D12_CROSS_NODE_SHARING_TIER_3,
	}

	/// <summary>Specifies triangles facing a particular direction are not drawn.</summary>
	/// <remarks>Cull mode is specified in a D3D12_RASTERIZER_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_cull_mode typedef enum D3D12_CULL_MODE {
	// D3D12_CULL_MODE_NONE = 1, D3D12_CULL_MODE_FRONT = 2, D3D12_CULL_MODE_BACK = 3 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_CULL_MODE")]
	public enum D3D12_CULL_MODE
	{
		/// <summary>
		/// <para>Value: 1 Always draw all triangles.</para>
		/// </summary>
		D3D12_CULL_MODE_NONE = 1,

		/// <summary>
		/// <para>Value: 2 Do not draw triangles that are front-facing.</para>
		/// </summary>
		D3D12_CULL_MODE_FRONT,

		/// <summary>
		/// <para>Value: 3 Do not draw triangles that are back-facing.</para>
		/// </summary>
		D3D12_CULL_MODE_BACK,
	}

	/// <summary>Identifies the portion of a depth-stencil buffer for writing depth data.</summary>
	/// <remarks>This enum is used by the D3D12_DEPTH_STENCIL_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_depth_write_mask typedef enum D3D12_DEPTH_WRITE_MASK {
	// D3D12_DEPTH_WRITE_MASK_ZERO = 0, D3D12_DEPTH_WRITE_MASK_ALL = 1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DEPTH_WRITE_MASK")]
	public enum D3D12_DEPTH_WRITE_MASK
	{
		/// <summary>
		/// <para>Value: 0 Turn off writes to the depth-stencil buffer.</para>
		/// </summary>
		D3D12_DEPTH_WRITE_MASK_ZERO,

		/// <summary>
		/// <para>Value: 1 Turn on writes to the depth-stencil buffer.</para>
		/// </summary>
		D3D12_DEPTH_WRITE_MASK_ALL,
	}

	/// <summary>Specifies options for a heap.</summary>
	/// <remarks>This enum is used by the D3D12_DESCRIPTOR_HEAP_DESC structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_descriptor_heap_flags typedef enum
	// D3D12_DESCRIPTOR_HEAP_FLAGS { D3D12_DESCRIPTOR_HEAP_FLAG_NONE = 0, D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DESCRIPTOR_HEAP_FLAGS")]
	[Flags]
	public enum D3D12_DESCRIPTOR_HEAP_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Indicates default usage of a heap.</para>
		/// </summary>
		D3D12_DESCRIPTOR_HEAP_FLAG_NONE,

		/// <summary>
		/// <para>Value: 0x1 
		/// The flag D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE can optionally be set on a descriptor heap to indicate it is be bound on a
		/// command list for reference by shaders. Descriptor heaps created without this flag allow applications the option to stage
		/// descriptors in CPU memory before copying them to a shader visible descriptor heap, as a convenience. But it is also fine for
		/// applications to directly create descriptors into shader visible descriptor heaps with no requirement to stage anything on the CPU.
		/// </para>
		/// <para>Descriptor heaps bound via</para>
		/// <para>ID3D12GraphicsCommandList::SetDescriptorHeaps</para>
		/// <para>must have the D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE flag set, else the debug layer will produce an error.</para>
		/// <para>Descriptor heaps with the D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE flag can't be used as the source heaps in calls to</para>
		/// <para>ID3D12Device::CopyDescriptors or ID3D12Device::CopyDescriptorsSimple</para>
		/// <para>, because they could be resident in WRITE_COMBINE memory or GPU-local memory, which is very inefficient to read from.</para>
		/// <para>
		/// This flag only applies to CBV/SRV/UAV descriptor heaps, and sampler descriptor heaps. It does not apply to other descriptor heap
		/// types since shaders do not directly reference the other types. Attempting to create an RTV/DSV heap with
		/// D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE results in a debug layer error.
		/// </para>
		/// </summary>
		D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE,
	}

	/// <summary>Specifies a type of descriptor heap.</summary>
	/// <remarks>
	/// <para>This enum is used by the D3D12_DESCRIPTOR_HEAP_DESC structure, and the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>CopyDescriptors</description>
	/// </item>
	/// <item>
	/// <description>CopyDescriptorsSimple</description>
	/// </item>
	/// <item>
	/// <description>GetDescriptorHandleIncrementSize</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_descriptor_heap_type typedef enum D3D12_DESCRIPTOR_HEAP_TYPE
	// { D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV = 0, D3D12_DESCRIPTOR_HEAP_TYPE_SAMPLER, D3D12_DESCRIPTOR_HEAP_TYPE_RTV,
	// D3D12_DESCRIPTOR_HEAP_TYPE_DSV, D3D12_DESCRIPTOR_HEAP_TYPE_NUM_TYPES } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DESCRIPTOR_HEAP_TYPE")]
	public enum D3D12_DESCRIPTOR_HEAP_TYPE
	{
		/// <summary>
		/// <para>Value: 0 The descriptor heap for the combination of constant-buffer, shader-resource, and unordered-access views.</para>
		/// </summary>
		D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV = 0,

		/// <summary>The descriptor heap for the sampler.</summary>
		D3D12_DESCRIPTOR_HEAP_TYPE_SAMPLER,

		/// <summary>The descriptor heap for the render-target view.</summary>
		D3D12_DESCRIPTOR_HEAP_TYPE_RTV,

		/// <summary>The descriptor heap for the depth-stencil view.</summary>
		D3D12_DESCRIPTOR_HEAP_TYPE_DSV,

		/// <summary>The number of types of descriptor heaps.</summary>
		D3D12_DESCRIPTOR_HEAP_TYPE_NUM_TYPES,
	}

	/// <summary>
	/// Specifies the volatility of both descriptors and the data they reference in a Root Signature 1.1 description, which can enable some
	/// driver optimizations.
	/// </summary>
	/// <remarks>
	/// <para>This enum is used by the D3D12_DESCRIPTOR_RANGE1 structure.</para>
	/// <para>To specify the volatility of just the data referenced by descriptors, refer to D3D12_ROOT_DESCRIPTOR_FLAGS.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_descriptor_range_flags typedef enum
	// D3D12_DESCRIPTOR_RANGE_FLAGS { D3D12_DESCRIPTOR_RANGE_FLAG_NONE = 0, D3D12_DESCRIPTOR_RANGE_FLAG_DESCRIPTORS_VOLATILE = 0x1,
	// D3D12_DESCRIPTOR_RANGE_FLAG_DATA_VOLATILE = 0x2, D3D12_DESCRIPTOR_RANGE_FLAG_DATA_STATIC_WHILE_SET_AT_EXECUTE = 0x4,
	// D3D12_DESCRIPTOR_RANGE_FLAG_DATA_STATIC = 0x8, D3D12_DESCRIPTOR_RANGE_FLAG_DESCRIPTORS_STATIC_KEEPING_BUFFER_BOUNDS_CHECKS = 0x10000
	// } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DESCRIPTOR_RANGE_FLAGS")]
	[Flags]
	public enum D3D12_DESCRIPTOR_RANGE_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 
		/// Default behavior. Descriptors are static, and default assumptions are made for data (for SRV/CBV:
		/// DATA_STATIC_WHILE_SET_AT_EXECUTE, and for UAV: DATA_VOLATILE).
		/// </para>
		/// </summary>
		D3D12_DESCRIPTOR_RANGE_FLAG_NONE,

		/// <summary>
		/// <para>Value: 0x1 
		/// If this is the only flag set, then descriptors are volatile and default assumptions are made about data (for SRV/CBV:
		/// DATA_STATIC_WHILE_SET_AT_EXECUTE, and for UAV: DATA_VOLATILE).
		/// </para>
		/// <para>
		/// If this flag is combined with DATA_VOLATILE, then both descriptors and data are volatile, which is equivalent to Root Signature
		/// Version 1.0.
		/// </para>
		/// <para>
		/// If this flag is combined with DATA_STATIC_WHILE_SET_AT_EXECUTE, then descriptors are volatile. This still doesn’t allow them to
		/// change during command list execution so it is valid to combine the additional declaration that data is static while set via root
		/// descriptor table during execution – the underlying descriptors are effectively static for longer than the data is being promised
		/// to be static.
		/// </para>
		/// </summary>
		D3D12_DESCRIPTOR_RANGE_FLAG_DESCRIPTORS_VOLATILE,

		/// <summary>
		/// <para>Value: 0x2 Descriptors are static and the data is volatile.</para>
		/// </summary>
		D3D12_DESCRIPTOR_RANGE_FLAG_DATA_VOLATILE,

		/// <summary>
		/// <para>Value: 0x4 Descriptors are static and data is static while set at execute.</para>
		/// </summary>
		D3D12_DESCRIPTOR_RANGE_FLAG_DATA_STATIC_WHILE_SET_AT_EXECUTE = 4,

		/// <summary>
		/// <para>Value: 0x8 Both descriptors and data are static. This maximizes the potential for driver optimization.</para>
		/// </summary>
		D3D12_DESCRIPTOR_RANGE_FLAG_DATA_STATIC = 8,

		/// <summary>
		/// <para>Value: 0x10000 
		/// Provides the same benefits as static descriptors (see D3D12_DESCRIPTOR_RANGE_FLAG_NONE ), except that the driver is not allowed
		/// to promote buffers to root descriptors as an optimization, because they must maintain bounds checks and root descriptors do not
		/// have those.
		/// </para>
		/// </summary>
		D3D12_DESCRIPTOR_RANGE_FLAG_DESCRIPTORS_STATIC_KEEPING_BUFFER_BOUNDS_CHECKS = 0x10000,
	}

	/// <summary>
	/// Specifies a range so that, for example, if part of a descriptor table has 100 shader-resource views (SRVs) that range can be
	/// declared in one entry rather than 100.
	/// </summary>
	/// <remarks>This enum is used by the D3D12_DESCRIPTOR_RANGE structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_descriptor_range_type typedef enum
	// D3D12_DESCRIPTOR_RANGE_TYPE { D3D12_DESCRIPTOR_RANGE_TYPE_SRV = 0, D3D12_DESCRIPTOR_RANGE_TYPE_UAV, D3D12_DESCRIPTOR_RANGE_TYPE_CBV,
	// D3D12_DESCRIPTOR_RANGE_TYPE_SAMPLER } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DESCRIPTOR_RANGE_TYPE")]
	public enum D3D12_DESCRIPTOR_RANGE_TYPE
	{
		/// <summary>
		/// <para>Value: 0 Specifies a range of SRVs.</para>
		/// </summary>
		D3D12_DESCRIPTOR_RANGE_TYPE_SRV = 0,

		/// <summary>Specifies a range of unordered-access views (UAVs).</summary>
		D3D12_DESCRIPTOR_RANGE_TYPE_UAV,

		/// <summary>Specifies a range of constant-buffer views (CBVs).</summary>
		D3D12_DESCRIPTOR_RANGE_TYPE_CBV,

		/// <summary>Specifies a range of samplers.</summary>
		D3D12_DESCRIPTOR_RANGE_TYPE_SAMPLER,
	}

	/// <summary>Congruent with, and numerically equivalent to, 3D12DDI_HANDLETYPE enumeration values.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_dred_allocation_type typedef enum D3D12_DRED_ALLOCATION_TYPE
	// { D3D12_DRED_ALLOCATION_TYPE_COMMAND_QUEUE, D3D12_DRED_ALLOCATION_TYPE_COMMAND_ALLOCATOR, D3D12_DRED_ALLOCATION_TYPE_PIPELINE_STATE,
	// D3D12_DRED_ALLOCATION_TYPE_COMMAND_LIST, D3D12_DRED_ALLOCATION_TYPE_FENCE, D3D12_DRED_ALLOCATION_TYPE_DESCRIPTOR_HEAP,
	// D3D12_DRED_ALLOCATION_TYPE_HEAP, D3D12_DRED_ALLOCATION_TYPE_QUERY_HEAP, D3D12_DRED_ALLOCATION_TYPE_COMMAND_SIGNATURE,
	// D3D12_DRED_ALLOCATION_TYPE_PIPELINE_LIBRARY, D3D12_DRED_ALLOCATION_TYPE_VIDEO_DECODER, D3D12_DRED_ALLOCATION_TYPE_VIDEO_PROCESSOR,
	// D3D12_DRED_ALLOCATION_TYPE_RESOURCE, D3D12_DRED_ALLOCATION_TYPE_PASS, D3D12_DRED_ALLOCATION_TYPE_CRYPTOSESSION,
	// D3D12_DRED_ALLOCATION_TYPE_CRYPTOSESSIONPOLICY, D3D12_DRED_ALLOCATION_TYPE_PROTECTEDRESOURCESESSION,
	// D3D12_DRED_ALLOCATION_TYPE_VIDEO_DECODER_HEAP, D3D12_DRED_ALLOCATION_TYPE_COMMAND_POOL, D3D12_DRED_ALLOCATION_TYPE_COMMAND_RECORDER,
	// D3D12_DRED_ALLOCATION_TYPE_STATE_OBJECT, D3D12_DRED_ALLOCATION_TYPE_METACOMMAND, D3D12_DRED_ALLOCATION_TYPE_SCHEDULINGGROUP,
	// D3D12_DRED_ALLOCATION_TYPE_VIDEO_MOTION_ESTIMATOR, D3D12_DRED_ALLOCATION_TYPE_VIDEO_MOTION_VECTOR_HEAP,
	// D3D12_DRED_ALLOCATION_TYPE_VIDEO_EXTENSION_COMMAND, D3D12_DRED_ALLOCATION_TYPE_VIDEO_ENCODER,
	// D3D12_DRED_ALLOCATION_TYPE_VIDEO_ENCODER_HEAP, D3D12_DRED_ALLOCATION_TYPE_INVALID } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DRED_ALLOCATION_TYPE")]
	public enum D3D12_DRED_ALLOCATION_TYPE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>(19)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_COMMAND_QUEUE = 19,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(20)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_COMMAND_ALLOCATOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(21)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_PIPELINE_STATE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(22)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_COMMAND_LIST,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(23)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_FENCE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(24)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_DESCRIPTOR_HEAP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(25)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_HEAP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(27)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_QUERY_HEAP = 27,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(28)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_COMMAND_SIGNATURE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(29)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_PIPELINE_LIBRARY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(30)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_VIDEO_DECODER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(32)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_VIDEO_PROCESSOR = 31,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(34)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_RESOURCE = 34,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(35)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_PASS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(36)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_CRYPTOSESSION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(37)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_CRYPTOSESSIONPOLICY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(38)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_PROTECTEDRESOURCESESSION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(39)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_VIDEO_DECODER_HEAP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(40)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_COMMAND_POOL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(41)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_COMMAND_RECORDER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(42)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_STATE_OBJECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(43)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_METACOMMAND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(44)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_SCHEDULINGGROUP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(45)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_VIDEO_MOTION_ESTIMATOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(46)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_VIDEO_MOTION_VECTOR_HEAP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(47)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_VIDEO_EXTENSION_COMMAND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0xffffffff)</para>
		/// </summary>
		D3D12_DRED_ALLOCATION_TYPE_INVALID = 0xffffffff,
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_dred_device_state typedef enum D3D12_DRED_DEVICE_STATE {
	// D3D12_DRED_DEVICE_STATE_UNKNOWN, D3D12_DRED_DEVICE_STATE_HUNG, D3D12_DRED_DEVICE_STATE_FAULT, D3D12_DRED_DEVICE_STATE_PAGEFAULT } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DRED_DEVICE_STATE")]
	public enum D3D12_DRED_DEVICE_STATE
	{
		/// <summary/>
		D3D12_DRED_DEVICE_STATE_UNKNOWN = 0,

		/// <summary/>
		D3D12_DRED_DEVICE_STATE_HUNG = 3,

		/// <summary/>
		D3D12_DRED_DEVICE_STATE_FAULT = 6,

		/// <summary/>
		D3D12_DRED_DEVICE_STATE_PAGEFAULT = 7,
	}

	/// <summary>
	/// Defines constants (used by the ID3D12DeviceRemovedExtendedDataSettings interface) that specify how individual Device Removed
	/// Extended Data (DRED) features are enabled. As of DRED version 1.1, the default value for all settings is <c>D3D12_DRED_ENABLEMENT_SYSTEM_CONTROLLED</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_dred_enablement typedef enum D3D12_DRED_ENABLEMENT {
	// D3D12_DRED_ENABLEMENT_SYSTEM_CONTROLLED, D3D12_DRED_ENABLEMENT_FORCED_OFF, D3D12_DRED_ENABLEMENT_FORCED_ON } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DRED_ENABLEMENT")]
	public enum D3D12_DRED_ENABLEMENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>(0)</para>
		/// <para>
		/// Specifies that a DRED feature is enabled only when DRED is turned on by the system automatically (for example, when a user is
		/// reproducing a problem via FeedbackHub).
		/// </para>
		/// </summary>
		D3D12_DRED_ENABLEMENT_SYSTEM_CONTROLLED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(1)</para>
		/// <para>Specifies that a DRED feature should be force-disabled, regardless of the system state.</para>
		/// </summary>
		D3D12_DRED_ENABLEMENT_FORCED_OFF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(2)</para>
		/// <para>Specifies that a DRED feature should be force-enabled, regardless of the system state.</para>
		/// </summary>
		D3D12_DRED_ENABLEMENT_FORCED_ON,
	}

	/// <summary>
	/// <para>Note</para>
	/// <para>As of Windows 10, version 1903, <c>D3D12_DRED_FLAGS</c> is deprecated, and it may not be available in future versions of Windows.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_dred_flags typedef enum D3D12_DRED_FLAGS {
	// D3D12_DRED_FLAG_NONE, D3D12_DRED_FLAG_FORCE_ENABLE, D3D12_DRED_FLAG_DISABLE_AUTOBREADCRUMBS } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DRED_FLAGS")]
	[Flags]
	public enum D3D12_DRED_FLAGS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x0)</para>
		/// <para>
		/// Typically specifies that Device Removed Extended Data (DRED) is disabled, except for when user-initiated feedback is used to
		/// produce a repro, or when otherwise enabled by Windows via automatic detection of process-instability issues. This is the default value.
		/// </para>
		/// </summary>
		D3D12_DRED_FLAG_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x1)</para>
		/// <para>Forces DRED to be enabled, regardless of the system state.</para>
		/// </summary>
		D3D12_DRED_FLAG_FORCE_ENABLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x2)</para>
		/// <para>Disables DRED auto breadcrumbs.</para>
		/// </summary>
		D3D12_DRED_FLAG_DISABLE_AUTOBREADCRUMBS,
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_dred_page_fault_flags typedef enum
	// D3D12_DRED_PAGE_FAULT_FLAGS { D3D12_DRED_PAGE_FAULT_FLAGS_NONE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DRED_PAGE_FAULT_FLAGS")]
	[Flags]
	public enum D3D12_DRED_PAGE_FAULT_FLAGS
	{
		/// <summary/>
		D3D12_DRED_PAGE_FAULT_FLAGS_NONE,
	}

	/// <summary>
	/// Defines constants that specify a version of Device Removed Extended Data (DRED), as used by the
	/// D3D12_VERSIONED_DEVICE_REMOVED_EXTENDED_DATA structure.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_dred_version typedef enum D3D12_DRED_VERSION {
	// D3D12_DRED_VERSION_1_0, D3D12_DRED_VERSION_1_1, D3D12_DRED_VERSION_1_2, D3D12_DRED_VERSION_1_3 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DRED_VERSION")]
	public enum D3D12_DRED_VERSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x1)</para>
		/// <para>Specifies DRED version 1.0.</para>
		/// </summary>
		D3D12_DRED_VERSION_1_0 = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x2)</para>
		/// <para>Specifies DRED version 1.1.</para>
		/// </summary>
		D3D12_DRED_VERSION_1_1 = 2,
	}

	/// <summary>
	/// Specifies the result of a call to ID3D12Device5::CheckDriverMatchingIdentifier which queries whether serialized data is compatible
	/// with the current device and driver version.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_driver_matching_identifier_status typedef enum
	// D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS { D3D12_DRIVER_MATCHING_IDENTIFIER_COMPATIBLE_WITH_DEVICE = 0,
	// D3D12_DRIVER_MATCHING_IDENTIFIER_UNSUPPORTED_TYPE = 0x1, D3D12_DRIVER_MATCHING_IDENTIFIER_UNRECOGNIZED = 0x2,
	// D3D12_DRIVER_MATCHING_IDENTIFIER_INCOMPATIBLE_VERSION = 0x3, D3D12_DRIVER_MATCHING_IDENTIFIER_INCOMPATIBLE_TYPE = 0x4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS")]
	public enum D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS
	{
		/// <summary>
		/// <para>Value: 0 Serialized data is compatible with the current device/driver.</para>
		/// </summary>
		D3D12_DRIVER_MATCHING_IDENTIFIER_COMPATIBLE_WITH_DEVICE,

		/// <summary>
		/// <para>Value: 0x1 The specified D3D12_SERIALIZED_DATA_TYPE specified is unknown or unsupported.</para>
		/// </summary>
		D3D12_DRIVER_MATCHING_IDENTIFIER_UNSUPPORTED_TYPE,

		/// <summary>
		/// <para>Value: 0x2 
		/// Format of the data in D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER is unrecognized. This could indicate either corrupt data
		/// or the identifier was produced by a different hardware vendor.
		/// </para>
		/// </summary>
		D3D12_DRIVER_MATCHING_IDENTIFIER_UNRECOGNIZED,

		/// <summary>
		/// <para>Value: 0x3 
		/// Serialized data is recognized, but its version is not compatible with the current driver. This result may indicate that the
		/// device is from the same hardware vendor but is an incompatible version.
		/// </para>
		/// </summary>
		D3D12_DRIVER_MATCHING_IDENTIFIER_INCOMPATIBLE_VERSION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>
		/// 0x4 D3D12_SERIALIZED_DATA_TYPE specifies a data type that is not compatible with the type of serialized data. As long as there
		/// is only a single defined serialized data type this error cannot not be produced.
		/// </para>
		/// </summary>
		D3D12_DRIVER_MATCHING_IDENTIFIER_INCOMPATIBLE_TYPE,
	}

	/// <summary>Specifies how to access a resource used in a depth-stencil view.</summary>
	/// <remarks>
	/// Specify one of the values in this enumeration in the <c>ViewDimension</c> member of a D3D12_DEPTH_STENCIL_VIEW_DESC structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_dsv_dimension typedef enum D3D12_DSV_DIMENSION {
	// D3D12_DSV_DIMENSION_UNKNOWN = 0, D3D12_DSV_DIMENSION_TEXTURE1D = 1, D3D12_DSV_DIMENSION_TEXTURE1DARRAY = 2,
	// D3D12_DSV_DIMENSION_TEXTURE2D = 3, D3D12_DSV_DIMENSION_TEXTURE2DARRAY = 4, D3D12_DSV_DIMENSION_TEXTURE2DMS = 5,
	// D3D12_DSV_DIMENSION_TEXTURE2DMSARRAY = 6 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DSV_DIMENSION")]
	public enum D3D12_DSV_DIMENSION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0 D3D12_DSV_DIMENSION_UNKNOWN is not a valid value for D3D12_DEPTH_STENCIL_VIEW_DESC and is not used.</para>
		/// </summary>
		D3D12_DSV_DIMENSION_UNKNOWN,

		/// <summary>
		/// <para>Value: 1 The resource will be accessed as a 1D texture.</para>
		/// </summary>
		D3D12_DSV_DIMENSION_TEXTURE1D,

		/// <summary>
		/// <para>Value: 2 The resource will be accessed as an array of 1D textures.</para>
		/// </summary>
		D3D12_DSV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>
		/// <para>Value: 3 The resource will be accessed as a 2D texture.</para>
		/// </summary>
		D3D12_DSV_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value: 4 The resource will be accessed as an array of 2D textures.</para>
		/// </summary>
		D3D12_DSV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>
		/// <para>Value: 5 The resource will be accessed as a 2D texture with multi sampling.</para>
		/// </summary>
		D3D12_DSV_DIMENSION_TEXTURE2DMS,

		/// <summary>
		/// <para>Value: 6 The resource will be accessed as an array of 2D textures with multi sampling.</para>
		/// </summary>
		D3D12_DSV_DIMENSION_TEXTURE2DMSARRAY,
	}

	/// <summary>Specifies depth-stencil view options.</summary>
	/// <remarks>
	/// <para>
	/// Specify a combination of the values in this enumeration in the <c>Flags</c> member of a D3D12_DEPTH_STENCIL_VIEW_DESC structure. The
	/// values are combined by using a bitwise OR operation.
	/// </para>
	/// <para>
	/// Limiting a depth-stencil buffer to read-only access allows more than one depth-stencil view to be bound to the pipeline
	/// simultaneously, since it is not possible to have read/write conflicts between separate views.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_dsv_flags typedef enum D3D12_DSV_FLAGS { D3D12_DSV_FLAG_NONE
	// = 0, D3D12_DSV_FLAG_READ_ONLY_DEPTH = 0x1, D3D12_DSV_FLAG_READ_ONLY_STENCIL = 0x2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_DSV_FLAGS")]
	public enum D3D12_DSV_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Indicates a default view.</para>
		/// </summary>
		D3D12_DSV_FLAG_NONE,

		/// <summary>
		/// <para>Value: 0x1 Indicates that depth values are read only.</para>
		/// </summary>
		D3D12_DSV_FLAG_READ_ONLY_DEPTH,

		/// <summary>
		/// <para>Value: 0x2 Indicates that stencil values are read only.</para>
		/// </summary>
		D3D12_DSV_FLAG_READ_ONLY_STENCIL,
	}

	/// <summary>Describes how the locations of elements are identified.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_elements_layout typedef enum D3D12_ELEMENTS_LAYOUT {
	// D3D12_ELEMENTS_LAYOUT_ARRAY = 0, D3D12_ELEMENTS_LAYOUT_ARRAY_OF_POINTERS = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_ELEMENTS_LAYOUT")]
	public enum D3D12_ELEMENTS_LAYOUT
	{
		/// <summary>
		/// <para>Value: 0 For a data set of <i>n</i> elements, the pointer parameter points to the start of <i>n</i> elements in memory.</para>
		/// </summary>
		D3D12_ELEMENTS_LAYOUT_ARRAY,

		/// <summary>
		/// <para>Value: 0x1 
		/// For a data set of <i>n</i> elements, the pointer parameter points to an array of <i>n</i> pointers in memory, each pointing to
		/// an individual element of the set.
		/// </para>
		/// </summary>
		D3D12_ELEMENTS_LAYOUT_ARRAY_OF_POINTERS,
	}

	/// <summary>The flags to apply when exporting symbols from a state subobject.</summary>
	/// <remarks>No export flags are defined in the current release.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_export_flags typedef enum D3D12_EXPORT_FLAGS {
	// D3D12_EXPORT_FLAG_NONE = 0 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_EXPORT_FLAGS")]
	public enum D3D12_EXPORT_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No export flags.</para>
		/// </summary>
		D3D12_EXPORT_FLAG_NONE,
	}

	/// <summary>
	/// Defines constants that specify a Direct3D 12 feature or feature set to query about. When you want to query for the level to which an
	/// adapter supports a feature, pass one of these values to <c>ID3D12Device::CheckFeatureSupport</c>.
	/// </summary>
	/// <remarks>
	/// Use a constant from this enumeration in a call to <c>ID3D12Device::CheckFeatureSupport</c> to query a driver about support for
	/// various Direct3D 12 features. Each value in this enumeration has a corresponding data structure that you must pass (by pointer
	/// reference) in the pFeatureSupportData parameter of <b>ID3D12Device::CheckFeatureSupport</b>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_feature typedef enum D3D12_FEATURE {
	// D3D12_FEATURE_D3D12_OPTIONS = 0, D3D12_FEATURE_ARCHITECTURE = 1, D3D12_FEATURE_FEATURE_LEVELS = 2, D3D12_FEATURE_FORMAT_SUPPORT = 3,
	// D3D12_FEATURE_MULTISAMPLE_QUALITY_LEVELS = 4, D3D12_FEATURE_FORMAT_INFO = 5, D3D12_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT = 6,
	// D3D12_FEATURE_SHADER_MODEL = 7, D3D12_FEATURE_D3D12_OPTIONS1 = 8, D3D12_FEATURE_PROTECTED_RESOURCE_SESSION_SUPPORT = 10,
	// D3D12_FEATURE_ROOT_SIGNATURE = 12, D3D12_FEATURE_ARCHITECTURE1 = 16, D3D12_FEATURE_D3D12_OPTIONS2 = 18, D3D12_FEATURE_SHADER_CACHE =
	// 19, D3D12_FEATURE_COMMAND_QUEUE_PRIORITY = 20, D3D12_FEATURE_D3D12_OPTIONS3 = 21, D3D12_FEATURE_EXISTING_HEAPS = 22,
	// D3D12_FEATURE_D3D12_OPTIONS4 = 23, D3D12_FEATURE_SERIALIZATION = 24, D3D12_FEATURE_CROSS_NODE = 25, D3D12_FEATURE_D3D12_OPTIONS5 =
	// 27, D3D12_FEATURE_DISPLAYABLE, D3D12_FEATURE_D3D12_OPTIONS6 = 30, D3D12_FEATURE_QUERY_META_COMMAND = 31, D3D12_FEATURE_D3D12_OPTIONS7
	// = 32, D3D12_FEATURE_PROTECTED_RESOURCE_SESSION_TYPE_COUNT = 33, D3D12_FEATURE_PROTECTED_RESOURCE_SESSION_TYPES = 34,
	// D3D12_FEATURE_D3D12_OPTIONS8 = 36, D3D12_FEATURE_D3D12_OPTIONS9 = 37, D3D12_FEATURE_D3D12_OPTIONS10, D3D12_FEATURE_D3D12_OPTIONS11,
	// D3D12_FEATURE_D3D12_OPTIONS12, D3D12_FEATURE_D3D12_OPTIONS13, D3D12_FEATURE_D3D12_OPTIONS14, D3D12_FEATURE_D3D12_OPTIONS15,
	// D3D12_FEATURE_D3D12_OPTIONS16, D3D12_FEATURE_D3D12_OPTIONS17, D3D12_FEATURE_D3D12_OPTIONS18, D3D12_FEATURE_D3D12_OPTIONS19,
	// D3D12_FEATURE_D3D12_OPTIONS20, D3D12_FEATURE_PREDICATION, D3D12_FEATURE_PLACED_RESOURCE_SUPPORT_INFO, D3D12_FEATURE_HARDWARE_COPY,
	// D3D12_FEATURE_D3D12_OPTIONS21 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_FEATURE")]
	public enum D3D12_FEATURE
	{
		/// <summary>
		/// <para>Value: 0 
		/// Indicates a query for the level of support for basic Direct3D 12 feature options. The corresponding data structure for this
		/// value is D3D12_FEATURE_DATA_D3D12_OPTIONS.
		/// </para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS,

		/// <summary>
		/// <para>Value: 1 
		/// Indicates a query for the adapter's architectural details, so that your application can better optimize for certain adapter
		/// properties. The corresponding data structure for this value is D3D12_FEATURE_DATA_ARCHITECTURE.
		/// </para>
		/// <note>This value has been superseded by the <b>D3D_FEATURE_DATA_ARCHITECTURE1</b> value. If your application targets Windows 10,
		/// version 1703 (Creators' Update) or higher, then use the <b>D3D_FEATURE_DATA_ARCHITECTURE1</b> value instead.</note>
		/// </summary>
		D3D12_FEATURE_ARCHITECTURE,

		/// <summary>
		/// <para>Value: 2 Indicates a query for info about the feature levels supported. The corresponding data structure for this value is D3D12_FEATURE_DATA_FEATURE_LEVELS.</para>
		/// </summary>
		D3D12_FEATURE_FEATURE_LEVELS,

		/// <summary>
		/// <para>Value: 3 
		/// Indicates a query for the resources supported by the current graphics driver for a given format. The corresponding data
		/// structure for this value is D3D12_FEATURE_DATA_FORMAT_SUPPORT.
		/// </para>
		/// </summary>
		D3D12_FEATURE_FORMAT_SUPPORT,

		/// <summary>
		/// <para>Value: 4 
		/// Indicates a query for the image quality levels for a given format and sample count. The corresponding data structure for this
		/// value is D3D12_FEATURE_DATA_MULTISAMPLE_QUALITY_LEVELS.
		/// </para>
		/// </summary>
		D3D12_FEATURE_MULTISAMPLE_QUALITY_LEVELS,

		/// <summary>
		/// <para>Value: 5 Indicates a query for the DXGI data format. The corresponding data structure for this value is D3D12_FEATURE_DATA_FORMAT_INFO.</para>
		/// </summary>
		D3D12_FEATURE_FORMAT_INFO,

		/// <summary>
		/// <para>Value: 6 
		/// Indicates a query for the GPU's virtual address space limitations. The corresponding data structure for this value is D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT.
		/// </para>
		/// </summary>
		D3D12_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT,

		/// <summary>
		/// <para>Value: 7 Indicates a query for the supported shader model. The corresponding data structure for this value is D3D12_FEATURE_DATA_SHADER_MODEL.</para>
		/// </summary>
		D3D12_FEATURE_SHADER_MODEL,

		/// <summary>
		/// <para>Value: 8 
		/// Indicates a query for the level of support for HLSL 6.0 wave operations. The corresponding data structure for this value is D3D12_FEATURE_DATA_D3D12_OPTIONS1.
		/// </para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS1,

		/// <summary>
		/// <para>Value: 10 
		/// Indicates a query for the level of support for protected resource sessions. The corresponding data structure for this value is D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_SUPPORT.
		/// </para>
		/// </summary>
		D3D12_FEATURE_PROTECTED_RESOURCE_SESSION_SUPPORT,

		/// <summary>
		/// <para>Value: 12 Indicates a query for root signature version support. The corresponding data structure for this value is D3D12_FEATURE_DATA_ROOT_SIGNATURE.</para>
		/// </summary>
		D3D12_FEATURE_ROOT_SIGNATURE,

		/// <summary>
		/// <para>Value: 16 
		/// Indicates a query for each adapter's architectural details, so that your application can better optimize for certain adapter
		/// properties. The corresponding data structure for this value is D3D12_FEATURE_DATA_ARCHITECTURE1.
		/// </para>
		/// <note>This value supersedes the <b>D3D_FEATURE_DATA_ARCHITECTURE</b> value. If your application targets Windows 10, version 1703
		/// (Creators' Update) or higher, then use <b>D3D_FEATURE_DATA_ARCHITECTURE1</b>.</note>
		/// </summary>
		D3D12_FEATURE_ARCHITECTURE1,

		/// <summary>
		/// <para>Value: 18 
		/// Indicates a query for the level of support for depth-bounds tests and programmable sample positions. The corresponding data
		/// structure for this value is D3D12_FEATURE_DATA_D3D12_OPTIONS2.
		/// </para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS2,

		/// <summary>
		/// <para>Value: 19 Indicates a query for the level of support for shader caching. The corresponding data structure for this value is D3D12_FEATURE_DATA_SHADER_CACHE.</para>
		/// </summary>
		D3D12_FEATURE_SHADER_CACHE,

		/// <summary>
		/// <para>Value: 20 
		/// Indicates a query for the adapter's support for prioritization of different command queue types. The corresponding data
		/// structure for this value is D3D12_FEATURE_DATA_COMMAND_QUEUE_PRIORITY.
		/// </para>
		/// </summary>
		D3D12_FEATURE_COMMAND_QUEUE_PRIORITY,

		/// <summary>
		/// <para>Value: 21 
		/// Indicates a query for the level of support for timestamp queries, format-casting, immediate write, view instancing, and
		/// barycentrics. The corresponding data structure for this value is D3D12_FEATURE_DATA_D3D12_OPTIONS3.
		/// </para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS3,

		/// <summary>
		/// <para>Value: 22 
		/// Indicates a query for whether or not the adapter supports creating heaps from existing system memory. The corresponding data
		/// structure for this value is D3D12_FEATURE_DATA_EXISTING_HEAPS.
		/// </para>
		/// </summary>
		D3D12_FEATURE_EXISTING_HEAPS,

		/// <summary>
		/// <para>Value: 23 
		/// Indicates a query for the level of support for 64KB-aligned MSAA textures, cross-API sharing, and native 16-bit shader
		/// operations. The corresponding data structure for this value is D3D12_FEATURE_DATA_D3D12_OPTIONS4.
		/// </para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS4,

		/// <summary>
		/// <para>Value: 24 
		/// Indicates a query for the level of support for heap serialization. The corresponding data structure for this value is D3D12_FEATURE_DATA_SERIALIZATION.
		/// </para>
		/// </summary>
		D3D12_FEATURE_SERIALIZATION,

		/// <summary>
		/// <para>Value: 25 
		/// Indicates a query for the level of support for the sharing of resources between different adapters—for example, multiple GPUs.
		/// The corresponding data structure for this value is D3D12_FEATURE_DATA_CROSS_NODE.
		/// </para>
		/// </summary>
		D3D12_FEATURE_CROSS_NODE,

		/// <summary>
		/// <para>Value: 27 
		/// Starting with Windows 10, version 1809 (10.0; Build 17763), indicates a query for the level of support for render passes, ray
		/// tracing, and shader-resource view tier 3 tiled resources. The corresponding data structure for this value is D3D12_FEATURE_DATA_D3D12_OPTIONS5.
		/// </para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS5,

		/// <summary>
		/// <para>Starting with Windows 11 (Build 10.0.22000.194). The corresponding data structure for this value is D3D12_FEATURE_DATA_DISPLAYABLE.</para>
		/// </summary>
		D3D12_FEATURE_DISPLAYABLE,

		/// <summary>
		/// <para>Value: 30 
		/// Starting with Windows 10, version 1903 (10.0; Build 18362), indicates a query for the level of support for variable-rate shading
		/// (VRS), and indicates whether or not background processing is supported. The corresponding data structure for this value is D3D12_FEATURE_DATA_D3D12_OPTIONS6.
		/// </para>
		/// <para>For more info, see Variable-rate shading (VRS), and the Direct3D 12 background processing spec.</para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS6,

		/// <summary>
		/// <para>Value: 31 Indicates a query for the level of support for metacommands. The corresponding data structure for this value is D3D12_FEATURE_DATA_QUERY_META_COMMAND.</para>
		/// </summary>
		D3D12_FEATURE_QUERY_META_COMMAND,

		/// <summary>
		/// <para>Value: 32 
		/// Starting with Windows 10, version 2004 (10.0; Build 19041), indicates a query for the level of support for mesh and
		/// amplification shaders, and for sampler feedback. The corresponding data structure for this value is D3D12_FEATURE_DATA_D3D12_OPTIONS7.
		/// </para>
		/// <para>For more info, see the Mesh shader and Sampler feedback specs.</para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS7,

		/// <summary>
		/// <para>Value: 33 
		/// Starting with Windows 10, version 2004 (10.0; Build 19041), indicates a query to retrieve the count of protected resource
		/// session types. The corresponding data structure for this value is D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPE_COUNT.
		/// </para>
		/// </summary>
		D3D12_FEATURE_PROTECTED_RESOURCE_SESSION_TYPE_COUNT,

		/// <summary>
		/// <para>Value: 34 
		/// Starting with Windows 10, version 2004 (10.0; Build 19041), indicates a query to retrieve the list of protected resource session
		/// types. The corresponding data structure for this value is D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPES.
		/// </para>
		/// </summary>
		D3D12_FEATURE_PROTECTED_RESOURCE_SESSION_TYPES,

		/// <summary>
		/// <para>Value: 36 
		/// Starting with Windows 11 (Build 10.0.22000.194), indicates whether or not unaligned block-compressed textures are supported. The
		/// corresponding data structure for this value is D3D12_FEATURE_DATA_D3D12_OPTIONS8.
		/// </para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS8,

		/// <summary>
		/// <para>Value: 37 
		/// Starting with Windows 11 (Build 10.0.22000.194), indicates whether or not support exists for mesh shaders, values of
		/// SV_RenderTargetArrayIndex that are 8 or greater, typed resource 64-bit integer atomics, derivative and derivative-dependent
		/// texture sample operations, and the level of support for WaveMMA (wave_matrix) operations. The corresponding data structure for
		/// this value is D3D12_FEATURE_DATA_D3D12_OPTIONS9.
		/// </para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS9,

		/// <summary>
		/// <para>
		/// Starting with Windows 11 (Build 10.0.22000.194), indicates whether or not the SUM combiner can be used, and whether or not
		/// SV_ShadingRate can be set from a mesh shader. The corresponding data structure for this value is D3D12_FEATURE_DATA_D3D12_OPTIONS10.
		/// </para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS10,

		/// <summary>
		/// <para>
		/// Starting with Windows 11 (Build 10.0.22000.194), indicates whether or not 64-bit integer atomics on resources in descriptor
		/// heaps are supported. The corresponding data structure for this value is D3D12_FEATURE_DATA_D3D12_OPTIONS11.
		/// </para>
		/// </summary>
		D3D12_FEATURE_D3D12_OPTIONS11,
	}

	/// <summary>Specifies fence options.</summary>
	/// <remarks>This enum is used by the <c>ID3D12Device::CreateFence</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_fence_flags typedef enum D3D12_FENCE_FLAGS {
	// D3D12_FENCE_FLAG_NONE = 0, D3D12_FENCE_FLAG_SHARED = 0x1, D3D12_FENCE_FLAG_SHARED_CROSS_ADAPTER = 0x2, D3D12_FENCE_FLAG_NON_MONITORED
	// = 0x4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_FENCE_FLAGS")]
	[Flags]
	public enum D3D12_FENCE_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No options are specified.</para>
		/// </summary>
		D3D12_FENCE_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 The fence is shared.</para>
		/// </summary>
		D3D12_FENCE_FLAG_SHARED = 0x1,

		/// <summary>
		/// <para>Value: 0x2 The fence is shared with another GPU adapter.</para>
		/// </summary>
		D3D12_FENCE_FLAG_SHARED_CROSS_ADAPTER = 0x2,

		/// <summary>
		/// <para>Value: 0x4 
		/// The fence is of the non-monitored type. Non-monitored fences should only be used when the adapter doesn't support monitored
		/// fences, or when a fence is shared with an adapter that doesn't support monitored fences.
		/// </para>
		/// </summary>
		D3D12_FENCE_FLAG_NON_MONITORED = 0x4,
	}

	/// <summary>Specifies the fill mode to use when rendering triangles.</summary>
	/// <remarks>Fill mode is specified in a <c>D3D12_RASTERIZER_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_fill_mode typedef enum D3D12_FILL_MODE {
	// D3D12_FILL_MODE_WIREFRAME = 2, D3D12_FILL_MODE_SOLID = 3 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_FILL_MODE")]
	public enum D3D12_FILL_MODE
	{
		/// <summary>
		/// <para>Value: 2 Draw lines connecting the vertices. Adjacent vertices are not drawn.</para>
		/// </summary>
		D3D12_FILL_MODE_WIREFRAME = 2,

		/// <summary>
		/// <para>Value: 3 Fill the triangles formed by the vertices. Adjacent vertices are not drawn.</para>
		/// </summary>
		D3D12_FILL_MODE_SOLID,
	}

	/// <summary>Specifies filtering options during texture sampling.</summary>
	/// <remarks>
	/// <para>This enum is used by the <c>D3D12_SAMPLER_DESC</c> structure.</para>
	/// <para>
	/// <b>Note</b>  If you use different filter types for min versus mag filter, undefined behavior occurs in certain cases where the
	/// choice between whether magnification or minification happens is ambiguous. To prevent this undefined behavior, use filter modes that
	/// use similar filter operations for both min and mag (or use anisotropic filtering, which avoids the issue as well).
	/// </para>
	/// <para></para>
	/// <para>
	/// During texture sampling, one or more texels are read and combined (this is calling filtering) to produce a single value. Point
	/// sampling reads a single texel while linear sampling reads two texels (endpoints) and linearly interpolates a third value between the endpoints.
	/// </para>
	/// <para>
	/// Microsoft High Level Shader Language (HLSL) texture-sampling functions also support comparison filtering during texture sampling.
	/// Comparison filtering compares each sampled texel against a comparison value. The boolean result is blended the same way that normal
	/// texture filtering is blended.
	/// </para>
	/// <para>
	/// You can use HLSL intrinsic texture-sampling functions that implement texture filtering only or companion functions that use texture
	/// filtering with comparison filtering.
	/// </para>
	/// <para>Also note the following defines:</para>
	/// <para>
	/// <c>#define D3D12_FILTER_REDUCTION_TYPE_MASK ( 0x3 ) #define D3D12_FILTER_REDUCTION_TYPE_SHIFT ( 7 ) #define D3D12_FILTER_TYPE_MASK (
	/// 0x3 ) #define D3D12_MIN_FILTER_SHIFT ( 4 ) #define D3D12_MAG_FILTER_SHIFT ( 2 ) #define D3D12_MIP_FILTER_SHIFT ( 0 ) #define
	/// D3D12_ANISOTROPIC_FILTERING_BIT ( 0x40 ) #define D3D12_ENCODE_BASIC_FILTER( min, mag, mip, reduction ) \ ( ( D3D12_FILTER ) ( \ ( (
	/// ( min ) &amp; D3D12_FILTER_TYPE_MASK ) &lt;&lt; D3D12_MIN_FILTER_SHIFT ) | \ ( ( ( mag ) &amp; D3D12_FILTER_TYPE_MASK ) &lt;&lt;
	/// D3D12_MAG_FILTER_SHIFT ) | \ ( ( ( mip ) &amp; D3D12_FILTER_TYPE_MASK ) &lt;&lt; D3D12_MIP_FILTER_SHIFT ) | \ ( ( ( reduction )
	/// &amp; D3D12_FILTER_REDUCTION_TYPE_MASK ) &lt;&lt; D3D12_FILTER_REDUCTION_TYPE_SHIFT ) ) ) #define D3D12_ENCODE_ANISOTROPIC_FILTER(
	/// reduction ) \ ( ( D3D12_FILTER ) ( \ D3D12_ANISOTROPIC_FILTERING_BIT | \ D3D12_ENCODE_BASIC_FILTER( D3D12_FILTER_TYPE_LINEAR, \
	/// D3D12_FILTER_TYPE_LINEAR, \ D3D12_FILTER_TYPE_LINEAR, \ reduction ) ) ) #define D3D12_DECODE_MIN_FILTER( D3D12Filter ) \ ( (
	/// D3D12_FILTER_TYPE ) \ ( ( ( D3D12Filter ) &gt;&gt; D3D12_MIN_FILTER_SHIFT ) &amp; D3D12_FILTER_TYPE_MASK ) ) #define
	/// D3D12_DECODE_MAG_FILTER( D3D12Filter ) \ ( ( D3D12_FILTER_TYPE ) \ ( ( ( D3D12Filter ) &gt;&gt; D3D12_MAG_FILTER_SHIFT ) &amp;
	/// D3D12_FILTER_TYPE_MASK ) ) #define D3D12_DECODE_MIP_FILTER( D3D12Filter ) \ ( ( D3D12_FILTER_TYPE ) \ ( ( ( D3D12Filter ) &gt;&gt;
	/// D3D12_MIP_FILTER_SHIFT ) &amp; D3D12_FILTER_TYPE_MASK ) ) #define D3D12_DECODE_FILTER_REDUCTION( D3D12Filter ) \ ( (
	/// D3D12_FILTER_REDUCTION_TYPE ) \ ( ( ( D3D12Filter ) &gt;&gt; D3D12_FILTER_REDUCTION_TYPE_SHIFT ) &amp;
	/// D3D12_FILTER_REDUCTION_TYPE_MASK ) ) #define D3D12_DECODE_IS_COMPARISON_FILTER( D3D12Filter ) \ ( D3D12_DECODE_FILTER_REDUCTION(
	/// D3D12Filter ) == D3D12_FILTER_REDUCTION_TYPE_COMPARISON ) #define D3D12_DECODE_IS_ANISOTROPIC_FILTER( D3D12Filter ) \ ( ( (
	/// D3D12Filter ) &amp; D3D12_ANISOTROPIC_FILTERING_BIT ) &amp;&amp; \ ( D3D12_FILTER_TYPE_LINEAR == D3D12_DECODE_MIN_FILTER(
	/// D3D12Filter ) ) &amp;&amp; \ ( D3D12_FILTER_TYPE_LINEAR == D3D12_DECODE_MAG_FILTER( D3D12Filter ) ) &amp;&amp; \ (
	/// D3D12_FILTER_TYPE_LINEAR == D3D12_DECODE_MIP_FILTER( D3D12Filter ) ) )</c>
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Texture Sampling Function</description>
	/// <description>Texture Sampling Function with Comparison Filtering</description>
	/// </listheader>
	/// <item>
	/// <description><c>Sample</c></description>
	/// <description><c>SampleCmp</c> or <c>SampleCmpLevelZero</c></description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>
	/// Comparison filters only work with textures that have the following formats: <c>DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS</c>,
	/// <c>DXGI_FORMAT_R32_FLOAT</c>, <c>DXGI_FORMAT_R24_UNORM_X8_TYPELESS</c>, <c>DXGI_FORMAT_R16_UNORM</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_filter typedef enum D3D12_FILTER {
	// D3D12_FILTER_MIN_MAG_MIP_POINT = 0, D3D12_FILTER_MIN_MAG_POINT_MIP_LINEAR = 0x1, D3D12_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x4,
	// D3D12_FILTER_MIN_POINT_MAG_MIP_LINEAR = 0x5, D3D12_FILTER_MIN_LINEAR_MAG_MIP_POINT = 0x10,
	// D3D12_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x11, D3D12_FILTER_MIN_MAG_LINEAR_MIP_POINT = 0x14, D3D12_FILTER_MIN_MAG_MIP_LINEAR =
	// 0x15, D3D12_FILTER_MIN_MAG_ANISOTROPIC_MIP_POINT, D3D12_FILTER_ANISOTROPIC = 0x55, D3D12_FILTER_COMPARISON_MIN_MAG_MIP_POINT = 0x80,
	// D3D12_FILTER_COMPARISON_MIN_MAG_POINT_MIP_LINEAR = 0x81, D3D12_FILTER_COMPARISON_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x84,
	// D3D12_FILTER_COMPARISON_MIN_POINT_MAG_MIP_LINEAR = 0x85, D3D12_FILTER_COMPARISON_MIN_LINEAR_MAG_MIP_POINT = 0x90,
	// D3D12_FILTER_COMPARISON_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x91, D3D12_FILTER_COMPARISON_MIN_MAG_LINEAR_MIP_POINT = 0x94,
	// D3D12_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR = 0x95, D3D12_FILTER_COMPARISON_MIN_MAG_ANISOTROPIC_MIP_POINT,
	// D3D12_FILTER_COMPARISON_ANISOTROPIC = 0xd5, D3D12_FILTER_MINIMUM_MIN_MAG_MIP_POINT = 0x100,
	// D3D12_FILTER_MINIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x101, D3D12_FILTER_MINIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x104,
	// D3D12_FILTER_MINIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x105, D3D12_FILTER_MINIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x110,
	// D3D12_FILTER_MINIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x111, D3D12_FILTER_MINIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x114,
	// D3D12_FILTER_MINIMUM_MIN_MAG_MIP_LINEAR = 0x115, D3D12_FILTER_MINIMUM_MIN_MAG_ANISOTROPIC_MIP_POINT, D3D12_FILTER_MINIMUM_ANISOTROPIC
	// = 0x155, D3D12_FILTER_MAXIMUM_MIN_MAG_MIP_POINT = 0x180, D3D12_FILTER_MAXIMUM_MIN_MAG_POINT_MIP_LINEAR = 0x181,
	// D3D12_FILTER_MAXIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x184, D3D12_FILTER_MAXIMUM_MIN_POINT_MAG_MIP_LINEAR = 0x185,
	// D3D12_FILTER_MAXIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x190, D3D12_FILTER_MAXIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR = 0x191,
	// D3D12_FILTER_MAXIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x194, D3D12_FILTER_MAXIMUM_MIN_MAG_MIP_LINEAR = 0x195,
	// D3D12_FILTER_MAXIMUM_MIN_MAG_ANISOTROPIC_MIP_POINT, D3D12_FILTER_MAXIMUM_ANISOTROPIC = 0x1d5 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_FILTER")]
	public enum D3D12_FILTER
	{
		/// <summary>
		/// <para>Value: 0 Use point sampling for minification, magnification, and mip-level sampling.</para>
		/// </summary>
		D3D12_FILTER_MIN_MAG_MIP_POINT = 0,

		/// <summary>
		/// <para>Value: 0x1 Use point sampling for minification and magnification; use linear interpolation for mip-level sampling.</para>
		/// </summary>
		D3D12_FILTER_MIN_MAG_POINT_MIP_LINEAR = 1,

		/// <summary>
		/// <para>Value: 0x4 Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling.</para>
		/// </summary>
		D3D12_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT = 4,

		/// <summary>
		/// <para>Value: 0x5 Use point sampling for minification; use linear interpolation for magnification and mip-level sampling.</para>
		/// </summary>
		D3D12_FILTER_MIN_POINT_MAG_MIP_LINEAR = 5,

		/// <summary>
		/// <para>Value: 0x10 Use linear interpolation for minification; use point sampling for magnification and mip-level sampling.</para>
		/// </summary>
		D3D12_FILTER_MIN_LINEAR_MAG_MIP_POINT = 0x10,

		/// <summary>
		/// <para>Value: 0x11 
		/// Use linear interpolation for minification; use point sampling for magnification; use linear interpolation for mip-level sampling.
		/// </para>
		/// </summary>
		D3D12_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x14 Use linear interpolation for minification and magnification; use point sampling for mip-level sampling.</para>
		/// </summary>
		D3D12_FILTER_MIN_MAG_LINEAR_MIP_POINT = 0x14,

		/// <summary>
		/// <para>Value: 0x15 Use linear interpolation for minification, magnification, and mip-level sampling.</para>
		/// </summary>
		D3D12_FILTER_MIN_MAG_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x55 Use anisotropic interpolation for minification, magnification, and mip-level sampling.</para>
		/// </summary>
		D3D12_FILTER_ANISOTROPIC = 0x55,

		/// <summary>
		/// <para>Value: 0x80 Use point sampling for minification, magnification, and mip-level sampling. Compare the result to the comparison value.</para>
		/// </summary>
		D3D12_FILTER_COMPARISON_MIN_MAG_MIP_POINT = 0x80,

		/// <summary>
		/// <para>Value: 0x81 
		/// Use point sampling for minification and magnification; use linear interpolation for mip-level sampling. Compare the result to
		/// the comparison value.
		/// </para>
		/// </summary>
		D3D12_FILTER_COMPARISON_MIN_MAG_POINT_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x84 
		/// Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling.
		/// Compare the result to the comparison value.
		/// </para>
		/// </summary>
		D3D12_FILTER_COMPARISON_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x84,

		/// <summary>
		/// <para>Value: 0x85 
		/// Use point sampling for minification; use linear interpolation for magnification and mip-level sampling. Compare the result to
		/// the comparison value.
		/// </para>
		/// </summary>
		D3D12_FILTER_COMPARISON_MIN_POINT_MAG_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x90 
		/// Use linear interpolation for minification; use point sampling for magnification and mip-level sampling. Compare the result to
		/// the comparison value.
		/// </para>
		/// </summary>
		D3D12_FILTER_COMPARISON_MIN_LINEAR_MAG_MIP_POINT = 0x90,

		/// <summary>
		/// <para>Value: 0x91 
		/// Use linear interpolation for minification; use point sampling for magnification; use linear interpolation for mip-level
		/// sampling. Compare the result to the comparison value.
		/// </para>
		/// </summary>
		D3D12_FILTER_COMPARISON_MIN_LINEAR_MAG_POINT_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x94 
		/// Use linear interpolation for minification and magnification; use point sampling for mip-level sampling. Compare the result to
		/// the comparison value.
		/// </para>
		/// </summary>
		D3D12_FILTER_COMPARISON_MIN_MAG_LINEAR_MIP_POINT = 0x94,

		/// <summary>
		/// <para>Value: 0x95 
		/// Use linear interpolation for minification, magnification, and mip-level sampling. Compare the result to the comparison value.
		/// </para>
		/// </summary>
		D3D12_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0xd5 
		/// Use anisotropic interpolation for minification, magnification, and mip-level sampling. Compare the result to the comparison value.
		/// </para>
		/// </summary>
		D3D12_FILTER_COMPARISON_ANISOTROPIC = 0xd5,

		/// <summary>
		/// <para>Value: 0x100 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_MAG_MIP_POINT and instead of filtering them return the minimum of the texels.
		/// Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter type from
		/// the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MINIMUM_MIN_MAG_MIP_POINT = 0x100,

		/// <summary>
		/// <para>Value: 0x101 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_MAG_POINT_MIP_LINEAR and instead of filtering them return the minimum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MINIMUM_MIN_MAG_POINT_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x104 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT and instead of filtering them return the minimum of
		/// the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this
		/// filter type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MINIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x104,

		/// <summary>
		/// <para>Value: 0x105 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_POINT_MAG_MIP_LINEAR and instead of filtering them return the minimum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MINIMUM_MIN_POINT_MAG_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x110 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_LINEAR_MAG_MIP_POINT and instead of filtering them return the minimum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MINIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x110,

		/// <summary>
		/// <para>Value: 0x111 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR and instead of filtering them return the minimum of
		/// the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this
		/// filter type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MINIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x114 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_MAG_LINEAR_MIP_POINT and instead of filtering them return the minimum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MINIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x114,

		/// <summary>
		/// <para>Value: 0x115 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_MAG_MIP_LINEAR and instead of filtering them return the minimum of the texels.
		/// Texels that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter type from
		/// the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MINIMUM_MIN_MAG_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x155 
		/// Fetch the same set of texels as D3D12_FILTER_ANISOTROPIC and instead of filtering them return the minimum of the texels. Texels
		/// that are weighted 0 during filtering aren't counted towards the minimum. You can query support for this filter type from the
		/// MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MINIMUM_ANISOTROPIC = 0x155,

		/// <summary>
		/// <para>Value: 0x180 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_MAG_MIP_POINT and instead of filtering them return the maximum of the texels.
		/// Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter type from
		/// the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MAXIMUM_MIN_MAG_MIP_POINT = 0x180,

		/// <summary>
		/// <para>Value: 0x181 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_MAG_POINT_MIP_LINEAR and instead of filtering them return the maximum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MAXIMUM_MIN_MAG_POINT_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x184 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT and instead of filtering them return the maximum of
		/// the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this
		/// filter type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MAXIMUM_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x184,

		/// <summary>
		/// <para>Value: 0x185 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_POINT_MAG_MIP_LINEAR and instead of filtering them return the maximum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MAXIMUM_MIN_POINT_MAG_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x190 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_LINEAR_MAG_MIP_POINT and instead of filtering them return the maximum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MAXIMUM_MIN_LINEAR_MAG_MIP_POINT = 0x190,

		/// <summary>
		/// <para>Value: 0x191 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR and instead of filtering them return the maximum of
		/// the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this
		/// filter type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MAXIMUM_MIN_LINEAR_MAG_POINT_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x194 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_MAG_LINEAR_MIP_POINT and instead of filtering them return the maximum of the
		/// texels. Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter
		/// type from the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MAXIMUM_MIN_MAG_LINEAR_MIP_POINT = 0x194,

		/// <summary>
		/// <para>Value: 0x195 
		/// Fetch the same set of texels as D3D12_FILTER_MIN_MAG_MIP_LINEAR and instead of filtering them return the maximum of the texels.
		/// Texels that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter type from
		/// the MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MAXIMUM_MIN_MAG_MIP_LINEAR,

		/// <summary>
		/// <para>Value: 0x1d5 
		/// Fetch the same set of texels as D3D12_FILTER_ANISOTROPIC and instead of filtering them return the maximum of the texels. Texels
		/// that are weighted 0 during filtering aren't counted towards the maximum. You can query support for this filter type from the
		/// MinMaxFiltering member in the D3D11_FEATURE_DATA_D3D11_OPTIONS1 structure.
		/// </para>
		/// </summary>
		D3D12_FILTER_MAXIMUM_ANISOTROPIC = 0x1d5,
	}

	/// <summary>Specifies the type of filter reduction.</summary>
	/// <remarks>This enum is used by the <c>D3D12_SAMPLER_DESC</c> structure. Also, refer to the remarks for <c>D3D12_FILTER</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_filter_reduction_type typedef enum
	// D3D12_FILTER_REDUCTION_TYPE { D3D12_FILTER_REDUCTION_TYPE_STANDARD = 0, D3D12_FILTER_REDUCTION_TYPE_COMPARISON = 1,
	// D3D12_FILTER_REDUCTION_TYPE_MINIMUM = 2, D3D12_FILTER_REDUCTION_TYPE_MAXIMUM = 3 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_FILTER_REDUCTION_TYPE")]
	public enum D3D12_FILTER_REDUCTION_TYPE
	{
		/// <summary>
		/// <para>Value: 0 The filter type is standard.</para>
		/// </summary>
		D3D12_FILTER_REDUCTION_TYPE_STANDARD,

		/// <summary>
		/// <para>Value: 1 The filter type is comparison.</para>
		/// </summary>
		D3D12_FILTER_REDUCTION_TYPE_COMPARISON,

		/// <summary>
		/// <para>Value: 2 The filter type is minimum.</para>
		/// </summary>
		D3D12_FILTER_REDUCTION_TYPE_MINIMUM,

		/// <summary>
		/// <para>Value: 3 The filter type is maximum.</para>
		/// </summary>
		D3D12_FILTER_REDUCTION_TYPE_MAXIMUM,
	}

	/// <summary>Specifies the type of magnification or minification sampler filters.</summary>
	/// <remarks>This enum is used by the <c>D3D12_SAMPLER_DESC</c> structure. Also, refer to the remarks for <c>D3D12_FILTER</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_filter_type typedef enum D3D12_FILTER_TYPE {
	// D3D12_FILTER_TYPE_POINT = 0, D3D12_FILTER_TYPE_LINEAR = 1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_FILTER_TYPE")]
	public enum D3D12_FILTER_TYPE
	{
		/// <summary>
		/// <para>Value: 0 
		/// Point filtering is used as a texture magnification or minification filter. The texel with coordinates nearest to the desired
		/// pixel value is used. The texture filter to be used between mipmap levels is nearest-point mipmap filtering. The rasterizer uses
		/// the color from the texel of the nearest mipmap texture.
		/// </para>
		/// </summary>
		D3D12_FILTER_TYPE_POINT,

		/// <summary>
		/// <para>Value: 1 
		/// Bilinear interpolation filtering is used as a texture magnification or minification filter. A weighted average of a 2 x 2 area
		/// of texels surrounding the desired pixel is used. The texture filter to use between mipmap levels is trilinear mipmap
		/// interpolation. The rasterizer linearly interpolates pixel color, using the texels of the two nearest mipmap textures.
		/// </para>
		/// </summary>
		D3D12_FILTER_TYPE_LINEAR,
	}

	/// <summary>Specifies resources that are supported for a provided format.</summary>
	/// <remarks>This enum is used by the <c>D3D12_FEATURE_DATA_FORMAT_SUPPORT</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_format_support1 typedef enum D3D12_FORMAT_SUPPORT1 {
	// D3D12_FORMAT_SUPPORT1_NONE = 0, D3D12_FORMAT_SUPPORT1_BUFFER = 0x1, D3D12_FORMAT_SUPPORT1_IA_VERTEX_BUFFER = 0x2,
	// D3D12_FORMAT_SUPPORT1_IA_INDEX_BUFFER = 0x4, D3D12_FORMAT_SUPPORT1_SO_BUFFER = 0x8, D3D12_FORMAT_SUPPORT1_TEXTURE1D = 0x10,
	// D3D12_FORMAT_SUPPORT1_TEXTURE2D = 0x20, D3D12_FORMAT_SUPPORT1_TEXTURE3D = 0x40, D3D12_FORMAT_SUPPORT1_TEXTURECUBE = 0x80,
	// D3D12_FORMAT_SUPPORT1_SHADER_LOAD = 0x100, D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE = 0x200,
	// D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE_COMPARISON = 0x400, D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE_MONO_TEXT = 0x800,
	// D3D12_FORMAT_SUPPORT1_MIP = 0x1000, D3D12_FORMAT_SUPPORT1_RENDER_TARGET = 0x4000, D3D12_FORMAT_SUPPORT1_BLENDABLE = 0x8000,
	// D3D12_FORMAT_SUPPORT1_DEPTH_STENCIL = 0x10000, D3D12_FORMAT_SUPPORT1_MULTISAMPLE_RESOLVE = 0x40000, D3D12_FORMAT_SUPPORT1_DISPLAY =
	// 0x80000, D3D12_FORMAT_SUPPORT1_CAST_WITHIN_BIT_LAYOUT = 0x100000, D3D12_FORMAT_SUPPORT1_MULTISAMPLE_RENDERTARGET = 0x200000,
	// D3D12_FORMAT_SUPPORT1_MULTISAMPLE_LOAD = 0x400000, D3D12_FORMAT_SUPPORT1_SHADER_GATHER = 0x800000,
	// D3D12_FORMAT_SUPPORT1_BACK_BUFFER_CAST = 0x1000000, D3D12_FORMAT_SUPPORT1_TYPED_UNORDERED_ACCESS_VIEW = 0x2000000,
	// D3D12_FORMAT_SUPPORT1_SHADER_GATHER_COMPARISON = 0x4000000, D3D12_FORMAT_SUPPORT1_DECODER_OUTPUT = 0x8000000,
	// D3D12_FORMAT_SUPPORT1_VIDEO_PROCESSOR_OUTPUT = 0x10000000, D3D12_FORMAT_SUPPORT1_VIDEO_PROCESSOR_INPUT = 0x20000000,
	// D3D12_FORMAT_SUPPORT1_VIDEO_ENCODER = 0x40000000 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_FORMAT_SUPPORT1")]
	[Flags]
	public enum D3D12_FORMAT_SUPPORT1 : uint
	{
		/// <summary>
		/// <para>Value: 0 No resources are supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 Buffer resources supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_BUFFER = 0x1,

		/// <summary>
		/// <para>Value: 0x2 Vertex buffers supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_IA_VERTEX_BUFFER = 0x2,

		/// <summary>
		/// <para>Value: 0x4 Index buffers supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_IA_INDEX_BUFFER = 0x4,

		/// <summary>
		/// <para>Value: 0x8 Streaming output buffers supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_SO_BUFFER = 0x8,

		/// <summary>
		/// <para>Value: 0x10 1D texture resources supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_TEXTURE1D = 0x10,

		/// <summary>
		/// <para>Value: 0x20 2D texture resources supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_TEXTURE2D = 0x20,

		/// <summary>
		/// <para>Value: 0x40 3D texture resources supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_TEXTURE3D = 0x40,

		/// <summary>
		/// <para>Value: 0x80 Cube texture resources supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_TEXTURECUBE = 0x80,

		/// <summary>
		/// <para>Value: 0x100 The HLSL Load function for texture objects is supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_SHADER_LOAD = 0x100,

		/// <summary>
		/// <para>Value: 0x200 The HLSL Sample function for texture objects is supported.</para>
		/// <para>
		/// <b>Note</b>  If the device supports the format as a resource (1D, 2D, 3D, or cube map) but doesn't support this option, the
		/// resource can still use the <c>Sample</c> method but must use only the point filtering sampler state to perform the sample.
		/// </para>
		/// <para></para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE = 0x200,

		/// <summary>
		/// <para>Value: 0x400 The HLSL SampleCmp and SampleCmpLevelZero functions for texture objects are supported.</para>
		/// <para>
		/// <b>Note</b>  Windows 8 and later might provide limited support for these functions on Direct3D <c>feature levels</c> 9_1, 9_2,
		/// and 9_3. For more info, see <c>Implementing shadow buffers for Direct3D feature level 9</c>.
		/// </para>
		/// <para></para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE_COMPARISON = 0x400,

		/// <summary>
		/// <para>Value: 0x800 Reserved.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_SHADER_SAMPLE_MONO_TEXT = 0x800,

		/// <summary>
		/// <para>Value: 0x1000 Mipmaps are supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_MIP = 0x1000,

		/// <summary>
		/// <para>Value: 0x4000 Render targets are supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_RENDER_TARGET = 0x4000,

		/// <summary>
		/// <para>Value: 0x8000 Blend operations supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_BLENDABLE = 0x8000,

		/// <summary>
		/// <para>Value: 0x10000 Depth stencils supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_DEPTH_STENCIL = 0x10000,

		/// <summary>
		/// <para>Value: 0x40000 Multisample antialiasing (MSAA) resolve operations are supported. For more info, see</para>
		/// <para>ID3D12GraphicsCommandList::ResolveSubresource</para>
		/// <para>.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_MULTISAMPLE_RESOLVE = 0x40000,

		/// <summary>
		/// <para>Value: 0x80000 Format can be displayed on screen.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_DISPLAY = 0x80000,

		/// <summary>
		/// <para>Value: 0x100000 Format can't be cast to another format.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_CAST_WITHIN_BIT_LAYOUT = 0x100000,

		/// <summary>
		/// <para>Value: 0x200000 Format can be used as a multi-sampled render target.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_MULTISAMPLE_RENDERTARGET = 0x200000,

		/// <summary>
		/// <para>Value: 0x400000 Format can be used as a multi-sampled texture and read into a shader with the HLSL Load function.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_MULTISAMPLE_LOAD = 0x400000,

		/// <summary>
		/// <para>Value: 0x800000 Format can be used with the HLSL gather function. This value is available in DirectX 10.1 or higher.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_SHADER_GATHER = 0x800000,

		/// <summary>
		/// <para>Value: 0x1000000 Format supports casting when the resource is a back buffer.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_BACK_BUFFER_CAST = 0x1000000,

		/// <summary>
		/// <para>Value: 0x2000000 Format can be used for an unordered access view.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_TYPED_UNORDERED_ACCESS_VIEW = 0x2000000,

		/// <summary>
		/// <para>Value: 0x4000000 Format can be used with the HLSL gather with comparison function.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_SHADER_GATHER_COMPARISON = 0x4000000,

		/// <summary>
		/// <para>Value: 0x8000000 Format can be used with the decoder output.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_DECODER_OUTPUT = 0x8000000,

		/// <summary>
		/// <para>Value: 0x10000000 Format can be used with the video processor output.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_VIDEO_PROCESSOR_OUTPUT = 0x10000000,

		/// <summary>
		/// <para>Value: 0x20000000 Format can be used with the video processor input.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_VIDEO_PROCESSOR_INPUT = 0x20000000,

		/// <summary>
		/// <para>Value: 0x40000000 Format can be used with the video encoder.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT1_VIDEO_ENCODER = 0x40000000,
	}

	/// <summary>Specifies which unordered resource options are supported for a provided format.</summary>
	/// <remarks>This enum is used by the <c>D3D12_FEATURE_DATA_FORMAT_SUPPORT</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_format_support2 typedef enum D3D12_FORMAT_SUPPORT2 {
	// D3D12_FORMAT_SUPPORT2_NONE = 0, D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_ADD = 0x1, D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_BITWISE_OPS = 0x2,
	// D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_COMPARE_STORE_OR_COMPARE_EXCHANGE = 0x4, D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_EXCHANGE = 0x8,
	// D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_SIGNED_MIN_OR_MAX = 0x10, D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_UNSIGNED_MIN_OR_MAX = 0x20,
	// D3D12_FORMAT_SUPPORT2_UAV_TYPED_LOAD = 0x40, D3D12_FORMAT_SUPPORT2_UAV_TYPED_STORE = 0x80,
	// D3D12_FORMAT_SUPPORT2_OUTPUT_MERGER_LOGIC_OP = 0x100, D3D12_FORMAT_SUPPORT2_TILED = 0x200, D3D12_FORMAT_SUPPORT2_MULTIPLANE_OVERLAY =
	// 0x4000, D3D12_FORMAT_SUPPORT2_SAMPLER_FEEDBACK } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_FORMAT_SUPPORT2")]
	[Flags]
	public enum D3D12_FORMAT_SUPPORT2
	{
		/// <summary>
		/// <para>Value: 0 No unordered resource options are supported.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 Format supports atomic add.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_ADD = 0x1,

		/// <summary>
		/// <para>Value: 0x2 Format supports atomic bitwise operations.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_BITWISE_OPS = 0x2,

		/// <summary>
		/// <para>Value: 0x4 Format supports atomic compare with store or exchange.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_COMPARE_STORE_OR_COMPARE_EXCHANGE = 0x4,

		/// <summary>
		/// <para>Value: 0x8 Format supports atomic exchange.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_EXCHANGE = 0x8,

		/// <summary>
		/// <para>Value: 0x10 Format supports atomic min and max.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_SIGNED_MIN_OR_MAX = 0x10,

		/// <summary>
		/// <para>Value: 0x20 Format supports atomic unsigned min and max.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_UNSIGNED_MIN_OR_MAX = 0x20,

		/// <summary>
		/// <para>Value: 0x40 Format supports a typed load.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_UAV_TYPED_LOAD = 0x40,

		/// <summary>
		/// <para>Value: 0x80 Format supports a typed store.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_UAV_TYPED_STORE = 0x80,

		/// <summary>
		/// <para>Value: 0x100 Format supports logic operations in blend state.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_OUTPUT_MERGER_LOGIC_OP = 0x100,

		/// <summary>
		/// <para>Value: 0x200 Format supports tiled resources. Refer to</para>
		/// <para>Volume Tiled Resources</para>
		/// <para>.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_TILED = 0x200,

		/// <summary>
		/// <para>Value: 0x4000 Format supports multi-plane overlays.</para>
		/// </summary>
		D3D12_FORMAT_SUPPORT2_MULTIPLANE_OVERLAY = 0x4000,
	}

	/// <summary>Defines flags that specify states related to a graphics command list. Values can be bitwise OR'd together.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_graphics_states typedef enum D3D12_GRAPHICS_STATES {
	// D3D12_GRAPHICS_STATE_NONE = 0, D3D12_GRAPHICS_STATE_IA_VERTEX_BUFFERS, D3D12_GRAPHICS_STATE_IA_INDEX_BUFFER,
	// D3D12_GRAPHICS_STATE_IA_PRIMITIVE_TOPOLOGY, D3D12_GRAPHICS_STATE_DESCRIPTOR_HEAP, D3D12_GRAPHICS_STATE_GRAPHICS_ROOT_SIGNATURE,
	// D3D12_GRAPHICS_STATE_COMPUTE_ROOT_SIGNATURE, D3D12_GRAPHICS_STATE_RS_VIEWPORTS, D3D12_GRAPHICS_STATE_RS_SCISSOR_RECTS,
	// D3D12_GRAPHICS_STATE_PREDICATION, D3D12_GRAPHICS_STATE_OM_RENDER_TARGETS, D3D12_GRAPHICS_STATE_OM_STENCIL_REF,
	// D3D12_GRAPHICS_STATE_OM_BLEND_FACTOR, D3D12_GRAPHICS_STATE_PIPELINE_STATE, D3D12_GRAPHICS_STATE_SO_TARGETS,
	// D3D12_GRAPHICS_STATE_OM_DEPTH_BOUNDS, D3D12_GRAPHICS_STATE_SAMPLE_POSITIONS, D3D12_GRAPHICS_STATE_VIEW_INSTANCE_MASK } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_GRAPHICS_STATES")]
	[Flags]
	public enum D3D12_GRAPHICS_STATES
	{
		/// <summary>
		/// <para>Value: 0 Specifies no state.</para>
		/// </summary>
		D3D12_GRAPHICS_STATE_NONE = 0,

		/// <summary>Specifies the state of the vertex buffer bindings on the input assembler stage.</summary>
		D3D12_GRAPHICS_STATE_IA_VERTEX_BUFFERS = 0x1,

		/// <summary>Specifies the state of the index buffer binding on the input assembler stage.</summary>
		D3D12_GRAPHICS_STATE_IA_INDEX_BUFFER = 0x2,

		/// <summary>Specifies the state of the primitive topology value set on the input assembler stage.</summary>
		D3D12_GRAPHICS_STATE_IA_PRIMITIVE_TOPOLOGY = 0x4,

		/// <summary>Specifies the state of the currently bound descriptor heaps.</summary>
		D3D12_GRAPHICS_STATE_DESCRIPTOR_HEAP = 0x8,

		/// <summary>Specifies the state of the currently set graphics root signature.</summary>
		D3D12_GRAPHICS_STATE_GRAPHICS_ROOT_SIGNATURE = 0x10,

		/// <summary>Specifies the state of the currently set compute root signature.</summary>
		D3D12_GRAPHICS_STATE_COMPUTE_ROOT_SIGNATURE = 0x20,

		/// <summary>Specifies the state of the viewports bound to the rasterizer stage.</summary>
		D3D12_GRAPHICS_STATE_RS_VIEWPORTS = 0x40,

		/// <summary>Specifies the state of the scissor rectangles bound to the rasterizer stage.</summary>
		D3D12_GRAPHICS_STATE_RS_SCISSOR_RECTS = 0x80,

		/// <summary>Specifies the predicate state.</summary>
		D3D12_GRAPHICS_STATE_PREDICATION = 0x100,

		/// <summary>Specifies the state of the render targets bound to the output merger stage.</summary>
		D3D12_GRAPHICS_STATE_OM_RENDER_TARGETS = 0x200,

		/// <summary>Specifies the state of the reference value for depth stencil tests set on the output merger stage.</summary>
		D3D12_GRAPHICS_STATE_OM_STENCIL_REF = 0x400,

		/// <summary>Specifies the state of the blend factor set on the output merger stage.</summary>
		D3D12_GRAPHICS_STATE_OM_BLEND_FACTOR = 0x800,

		/// <summary>Specifies the state of the pipeline state object.</summary>
		D3D12_GRAPHICS_STATE_PIPELINE_STATE = 0x1000,

		/// <summary>Specifies the state of the buffer views bound to the stream output stage.</summary>
		D3D12_GRAPHICS_STATE_SO_TARGETS = 0x2000,

		/// <summary>Specifies the state of the depth bounds set on the output merger stage.</summary>
		D3D12_GRAPHICS_STATE_OM_DEPTH_BOUNDS = 0x4000,

		/// <summary>Specifies the state of the sample positions.</summary>
		D3D12_GRAPHICS_STATE_SAMPLE_POSITIONS = 0x8000,

		/// <summary>Specifies the state of the view instances mask.</summary>
		D3D12_GRAPHICS_STATE_VIEW_INSTANCE_MASK = 0x10000,
	}

	/// <summary>Specifies heap options, such as whether the heap can contain textures, and whether resources are shared across adapters.</summary>
	/// <remarks>
	/// <para>This enum is used by the following API items:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>ID3D12Device::CreateHeap</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateCommittedResource</c></description>
	/// </item>
	/// <item>
	/// <description><c>D3D12_HEAP_DESC</c> structure</description>
	/// </item>
	/// </list>
	/// <para>
	/// The following heap flags must be used with <c>ID3D12Device::CreateHeap</c>, but will be set automatically for implicit heaps created
	/// by <c>ID3D12Device::CreateCommittedResource</c>. Adapters that only support <c>heap tier 1</c> must set two out of the three
	/// following flags.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_DENY_BUFFERS</description>
	/// <description>
	/// The heap isn't allowed to contain resources with D3D12_RESOURCE_DIMENSION_BUFFER (which is a <c>D3D12_RESOURCE_DIMENSION</c>
	/// enumeration constant).
	/// </description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES</description>
	/// <description>
	/// The heap isn't allowed to contain resources with D3D12_RESOURCE_DIMENSION_TEXTURE1D, D3D12_RESOURCE_DIMENSION_TEXTURE2D, or
	/// D3D12_RESOURCE_DIMENSION_TEXTURE3D together with either D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET or
	/// D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL. (The latter two items are <c>D3D12_RESOURCE_FLAGS</c> enumeration constants.)
	/// </description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_DENY_NON_RT_DS_TEXTURES</description>
	/// <description>
	/// The heap isn't allowed to contain resources with D3D12_RESOURCE_DIMENSION_TEXTURE1D, D3D12_RESOURCE_DIMENSION_TEXTURE2D, or
	/// D3D12_RESOURCE_DIMENSION_TEXTURE3D unless D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET and D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL are absent.
	/// </description>
	/// </item>
	/// </list>
	/// <para><c></c><c></c><c></c> Aliases</para>
	/// <para>
	/// Adapters that support <c>heap tier 2</c> or greater are additionally allowed to set none of the above flags. Aliases for these flags
	/// are available for applications that prefer thinking only of which resources are supported.
	/// </para>
	/// <para>The following aliases exist, so be careful when doing bit-manipulations:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D12_HEAP_FLAG_ALLOW_ALL_BUFFERS_AND_TEXTURES = 0 and is only supported on <c>heap tier 2</c> and greater.</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_ALLOW_ONLY_BUFFERS = D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES | D3D12_HEAP_FLAG_DENY_NON_RT_DS_TEXTURES</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_ALLOW_ONLY_NON_RT_DS_TEXTURES = D3D12_HEAP_FLAG_DENY_BUFFERS | D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_ALLOW_ONLY_RT_DS_TEXTURES = D3D12_HEAP_FLAG_DENY_BUFFERS | D3D12_HEAP_FLAG_DENY_NON_RT_DS_TEXTURES</description>
	/// </item>
	/// </list>
	/// <para><c></c><c></c><c></c> Displayable heaps</para>
	/// <para>Displayable heaps are most commonly created by the swapchain for presentation, to enable scanning out to a monitor.</para>
	/// <para>Displayable heaps are specified with the D3D12_HEAP_FLAG_ALLOW_DISPLAY member of the <b>D3D12_HEAP_FLAGS</b> enum.</para>
	/// <para>
	/// Applications may create displayable heaps outside of a swapchain; but cannot actually present with them. This flag is not supported
	/// by <c>CreateHeap</c> and can only be used with <c>CreateCommittedResource</c> with D3D12_HEAP_TYPE_DEFAULT.
	/// </para>
	/// <para>Additional restrictions to the <c>D3D12_RESOURCE_DESC</c> apply to the resource created with displayable heaps.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// The format must not only be supported by the device, but must be supported for scan-out. Refer to the use of the
	/// D3D12_FORMAT_SUPPORT1_DISPLAY member of <c>D3D12_FORMAT_SUPPORT1</c>.
	/// </description>
	/// </item>
	/// <item>
	/// <description><i>Dimension</i> must be D3D12_RESOURCE_DIMENSION_TEXTURE2D.</description>
	/// </item>
	/// <item>
	/// <description><i>Alignment</i> must be 0.</description>
	/// </item>
	/// <item>
	/// <description><i>ArraySize</i> may be either 1 or 2.</description>
	/// </item>
	/// <item>
	/// <description><i>MipLevels</i> must be 1.</description>
	/// </item>
	/// <item>
	/// <description><i>SampleDesc</i> must have <i>Count</i> set to 1 and <i>Quality</i> set to 0.</description>
	/// </item>
	/// <item>
	/// <description><i>Layout</i> must be D3D12_TEXTURE_LAYOUT_UNKNOWN.</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL and D3D12_RESOURCE_FLAG_ALLOW_CROSS_ADAPTER are invalid flags.</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_heap_flags typedef enum D3D12_HEAP_FLAGS {
	// D3D12_HEAP_FLAG_NONE = 0, D3D12_HEAP_FLAG_SHARED = 0x1, D3D12_HEAP_FLAG_DENY_BUFFERS = 0x4, D3D12_HEAP_FLAG_ALLOW_DISPLAY = 0x8,
	// D3D12_HEAP_FLAG_SHARED_CROSS_ADAPTER = 0x20, D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES = 0x40, D3D12_HEAP_FLAG_DENY_NON_RT_DS_TEXTURES =
	// 0x80, D3D12_HEAP_FLAG_HARDWARE_PROTECTED = 0x100, D3D12_HEAP_FLAG_ALLOW_WRITE_WATCH = 0x200, D3D12_HEAP_FLAG_ALLOW_SHADER_ATOMICS =
	// 0x400, D3D12_HEAP_FLAG_CREATE_NOT_RESIDENT = 0x800, D3D12_HEAP_FLAG_CREATE_NOT_ZEROED = 0x1000,
	// D3D12_HEAP_FLAG_TOOLS_USE_MANUAL_WRITE_TRACKING, D3D12_HEAP_FLAG_ALLOW_ALL_BUFFERS_AND_TEXTURES = 0,
	// D3D12_HEAP_FLAG_ALLOW_ONLY_BUFFERS = 0xc0, D3D12_HEAP_FLAG_ALLOW_ONLY_NON_RT_DS_TEXTURES = 0x44,
	// D3D12_HEAP_FLAG_ALLOW_ONLY_RT_DS_TEXTURES = 0x84 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_HEAP_FLAGS")]
	[Flags]
	public enum D3D12_HEAP_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No options are specified.</para>
		/// </summary>
		D3D12_HEAP_FLAG_NONE = 0,

		/// <summary>
		/// <para>Value: 0x1 The heap is shared. Refer to Shared Heaps.</para>
		/// </summary>
		D3D12_HEAP_FLAG_SHARED = 0x1,

		/// <summary>
		/// <para>Value: 0x4 The heap isn't allowed to contain buffers.</para>
		/// </summary>
		D3D12_HEAP_FLAG_DENY_BUFFERS = 0x4,

		/// <summary>
		/// <para>Value: 0x8 The heap is allowed to contain swap-chain surfaces.</para>
		/// </summary>
		D3D12_HEAP_FLAG_ALLOW_DISPLAY = 0x8,

		/// <summary>
		/// <para>Value: 0x20 
		/// The heap is allowed to share resources across adapters. Refer to Shared Heaps. A protected session cannot be mixed with
		/// resources that are shared across adapters.
		/// </para>
		/// </summary>
		D3D12_HEAP_FLAG_SHARED_CROSS_ADAPTER = 0x20,

		/// <summary>
		/// <para>Value: 0x40 The heap is not allowed to store Render Target (RT) and/or Depth-Stencil (DS) textures.</para>
		/// </summary>
		D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES = 0x40,

		/// <summary>
		/// <para>Value: 0x80 
		/// The heap is not allowed to contain resources with D3D12_RESOURCE_DIMENSION_TEXTURE1D, D3D12_RESOURCE_DIMENSION_TEXTURE2D, or
		/// D3D12_RESOURCE_DIMENSION_TEXTURE3D unless either D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET or
		/// D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL are present. Refer to D3D12_RESOURCE_DIMENSION and D3D12_RESOURCE_FLAGS.
		/// </para>
		/// </summary>
		D3D12_HEAP_FLAG_DENY_NON_RT_DS_TEXTURES = 0x80,

		/// <summary>
		/// <para>Value: 0x100 Unsupported. Do not use.</para>
		/// </summary>
		D3D12_HEAP_FLAG_HARDWARE_PROTECTED = 0x100,

		/// <summary>
		/// <para>Value: 0x200 
		/// The heap supports MEM_WRITE_WATCH functionality, which causes the system to track the pages that are written to in the committed
		/// memory region. This flag can't be combined with the D3D12_HEAP_TYPE_DEFAULT or D3D12_CPU_PAGE_PROPERTY_UNKNOWN flags.
		/// Applications are discouraged from using this flag themselves because it prevents tools from using this functionality.
		/// </para>
		/// </summary>
		D3D12_HEAP_FLAG_ALLOW_WRITE_WATCH = 0x200,

		/// <summary>
		/// <para>Value: 0x400 Ensures that atomic operations will be atomic on this heap's memory, according to components able to see the memory.</para>
		/// <para>Creating a heap with this flag will fail under either of these conditions.</para>
		/// <para>
		/// - The heap type is D3D12_HEAP_TYPE_DEFAULT, and the heap can be visible on multiple nodes, but the device does not support <b>D3D12_CROSS_NODE_SHARING_TIER_3.</b>
		/// </para>
		/// <para>- The heap is CPU-visible, but the heap type is not D3D12_HEAP_TYPE_CUSTOM.</para>
		/// <para>Note that heaps with this flag might be a limited resource on some systems.</para>
		/// </summary>
		D3D12_HEAP_FLAG_ALLOW_SHADER_ATOMICS = 0x400,

		/// <summary>
		/// <para>Value: 0x800 The heap is created in a non-resident state and must be made resident using ID3D12Device::MakeResident or ID3D12Device3::EnqueueMakeResident.</para>
		/// <para>
		/// By default, the final step of heap creation is to make the heap resident, so this flag skips this step and allows the
		/// application to decide when to do so.
		/// </para>
		/// </summary>
		D3D12_HEAP_FLAG_CREATE_NOT_RESIDENT = 0x800,

		/// <summary>
		/// <para>Value: 0x1000 
		/// Allows the OS to not zero the heap created. By default, committed resources and heaps are almost always zeroed upon creation.
		/// This flag allows this to be elided in some scenarios. However, it doesn't guarantee it. For example, memory coming from other
		/// processes still needs to be zeroed for data protection and process isolation. This can lower the overhead of creating the heap.
		/// </para>
		/// </summary>
		D3D12_HEAP_FLAG_CREATE_NOT_ZEROED = 0x1000,

		/// <summary>
		/// <para>Value: 0 
		/// The heap is allowed to store all types of buffers and/or textures. This is an alias; for more details, see "Aliases" in the
		/// Remarks section.
		/// </para>
		/// </summary>
		D3D12_HEAP_FLAG_ALLOW_ALL_BUFFERS_AND_TEXTURES = 0x0,

		/// <summary>
		/// <para>Value: 0xc0 The heap is only allowed to store buffers. This is an alias; for more details, see "Aliases" in the Remarks section.</para>
		/// </summary>
		D3D12_HEAP_FLAG_ALLOW_ONLY_BUFFERS = 0xc0,

		/// <summary>
		/// <para>Value: 0x44 
		/// The heap is only allowed to store non-RT, non-DS textures. This is an alias; for more details, see "Aliases" in the Remarks section.
		/// </para>
		/// </summary>
		D3D12_HEAP_FLAG_ALLOW_ONLY_NON_RT_DS_TEXTURES = 0x44,

		/// <summary>
		/// <para>Value: 0x84 
		/// The heap is only allowed to store RT and/or DS textures. This is an alias; for more details, see "Aliases" in the Remarks section.
		/// </para>
		/// </summary>
		D3D12_HEAP_FLAG_ALLOW_ONLY_RT_DS_TEXTURES = 0x84,
	}

	/// <summary>Defines constants that specify heap serialization support.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_heap_serialization_tier typedef enum
	// D3D12_HEAP_SERIALIZATION_TIER { D3D12_HEAP_SERIALIZATION_TIER_0, D3D12_HEAP_SERIALIZATION_TIER_10 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_HEAP_SERIALIZATION_TIER")]
	public enum D3D12_HEAP_SERIALIZATION_TIER
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>(0)</para>
		/// <para>Indicates that heap serialization is not supported.</para>
		/// </summary>
		D3D12_HEAP_SERIALIZATION_TIER_0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(10)</para>
		/// <para>
		/// Indicates that heap serialization is supported. Your application can serialize resource data in heaps through copying APIs such
		/// as CopyResource , without necessarily requiring an explicit
		/// </para>
		/// <para>state transition</para>
		/// <para>of resources on those heaps.</para>
		/// </summary>
		D3D12_HEAP_SERIALIZATION_TIER_10 = 10,
	}

	/// <summary>
	/// Specifies the type of heap. When resident, heaps reside in a particular physical memory pool with certain CPU cache properties.
	/// </summary>
	/// <remarks>
	/// <para>This enum is used by the following API items:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>D3D12_HEAP_DESC</c></description>
	/// </item>
	/// <item>
	/// <description><c>D3D12_HEAP_PROPERTIES</c></description>
	/// </item>
	/// <item>
	/// <description><c>GetCustomHeapProperties</c></description>
	/// </item>
	/// </list>
	/// <para>The heap types fall into two categories: abstracted heap types, and custom heap types.</para>
	/// <para>The following are abstracted heap types:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D12_HEAP_TYPE_DEFAULT</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_TYPE_UPLOAD</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_TYPE_READBACK</description>
	/// </item>
	/// </list>
	/// <para>The following is a custom heap type:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D12_HEAP_TYPE_CUSTOM</description>
	/// </item>
	/// </list>
	/// <para>
	/// The abstracted heap types (_DEFAULT, _UPLOAD, and _READBACK) are useful to simplify writing adapter-neutral applications, because
	/// such applications don't need to be aware of the adapter memory architecture. To use an abstracted heap type to simplify writing
	/// adapter-neutral applications, the application essentially treats the adapter as if it were a discrete or NUMA adapter. But, using
	/// the heap types enables efficient translation for UMA adapters. Adapter architecture neutral applications should assume there are two
	/// memory pools available, where the pool with the most GPU bandwidth cannot provide CPU access. The pool with the least GPU bandwidth
	/// can have CPU access; but must be either optimized for upload to GPU or readback from GPU.
	/// </para>
	/// <para>Note that textures (unlike buffers) can't be heap type UPLOAD or READBACK.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_heap_type typedef enum D3D12_HEAP_TYPE {
	// D3D12_HEAP_TYPE_DEFAULT = 1, D3D12_HEAP_TYPE_UPLOAD = 2, D3D12_HEAP_TYPE_READBACK = 3, D3D12_HEAP_TYPE_CUSTOM = 4,
	// D3D12_HEAP_TYPE_GPU_UPLOAD } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_HEAP_TYPE")]
	public enum D3D12_HEAP_TYPE
	{
		/// <summary>
		/// <para>Value: 1 
		/// Specifies the default heap. This heap type experiences the most bandwidth for the GPU, but cannot provide CPU access. The GPU
		/// can read and write to the memory from this pool, and resource transition barriers may be changed. The majority of heaps and
		/// resources are expected to be located here, and are typically populated through resources in upload heaps.
		/// </para>
		/// </summary>
		D3D12_HEAP_TYPE_DEFAULT = 1,

		/// <summary>
		/// <para>Value: 2 
		/// Specifies a heap used for uploading. This heap type has CPU access optimized for uploading to the GPU, but does not experience
		/// the maximum amount of bandwidth for the GPU. This heap type is best for CPU-write-once, GPU-read-once data; but GPU-read-once is
		/// stricter than necessary. GPU-read-once-or-from-cache is an acceptable use-case for the data; but such usages are hard to judge
		/// due to differing GPU cache designs and sizes. If in doubt, stick to the GPU-read-once definition or profile the difference on
		/// many GPUs between copying the data to a _DEFAULT heap vs. reading the data from an _UPLOAD heap.
		/// </para>
		/// <para>
		/// Resources in this heap must be created with D3D12_RESOURCE_STATE _GENERIC_READ and cannot be changed away from this. The CPU
		/// address for such heaps is commonly not efficient for CPU reads.
		/// </para>
		/// <para>The following are typical usages for _UPLOAD heaps:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Initializing resources in a _DEFAULT heap with data from the CPU.</description>
		/// </item>
		/// <item>
		/// <description>Uploading dynamic data in a constant buffer that is read, repeatedly, by each vertex or pixel.</description>
		/// </item>
		/// </list>
		/// <para>The following are likely not good usages for _UPLOAD heaps:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Re-initializing the contents of a resource every frame.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Uploading constant data which is only used every other Draw call, where each Draw uses a non-trivial amount of other data.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		D3D12_HEAP_TYPE_UPLOAD,

		/// <summary>
		/// <para>Value: 3 
		/// Specifies a heap used for reading back. This heap type has CPU access optimized for reading data back from the GPU, but does not
		/// experience the maximum amount of bandwidth for the GPU. This heap type is best for GPU-write-once, CPU-readable data. The CPU
		/// cache behavior is write-back, which is conducive for multiple sub-cache-line CPU reads.
		/// </para>
		/// <para>Resources in this heap must be created with D3D12_RESOURCE_STATE _COPY_DEST, and cannot be changed away from this.</para>
		/// </summary>
		D3D12_HEAP_TYPE_READBACK,

		/// <summary>
		/// <para>Value: 4 
		/// Specifies a custom heap. The application may specify the memory pool and CPU cache properties directly, which can be useful for
		/// UMA optimizations, multi-engine, multi-adapter, or other special cases. To do so, the application is expected to understand the
		/// adapter architecture to make the right choice. For more details, see D3D12_FEATURE _ARCHITECTURE,
		/// D3D12_FEATURE_DATA_ARCHITECTURE , and GetCustomHeapProperties .
		/// </para>
		/// </summary>
		D3D12_HEAP_TYPE_CUSTOM,

		/// <summary/>
		D3D12_HEAP_TYPE_GPU_UPLOAD
	}

	/// <summary>
	/// Specifies the type of a raytracing hit group state subobject. Use a value from this enumeration with the <c>D3D12_HIT_GROUP_DESC</c> structure.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_hit_group_type typedef enum D3D12_HIT_GROUP_TYPE {
	// D3D12_HIT_GROUP_TYPE_TRIANGLES = 0, D3D12_HIT_GROUP_TYPE_PROCEDURAL_PRIMITIVE = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_HIT_GROUP_TYPE")]
	public enum D3D12_HIT_GROUP_TYPE
	{
		/// <summary>
		/// <para>Value: 0 
		/// The hit group uses a list of triangles to calculate ray hits. Hit groups that use triangles can’t contain an intersection shader.
		/// </para>
		/// </summary>
		D3D12_HIT_GROUP_TYPE_TRIANGLES,

		/// <summary>
		/// <para>Value: 0x1 
		/// The hit group uses a procedural primitive within a bounding box to calculate ray hits. Hit groups that use procedural primitives
		/// must contain an intersection shader.
		/// </para>
		/// </summary>
		D3D12_HIT_GROUP_TYPE_PROCEDURAL_PRIMITIVE,
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_hit_kind typedef enum D3D12_HIT_KIND {
	// D3D12_HIT_KIND_TRIANGLE_FRONT_FACE, D3D12_HIT_KIND_TRIANGLE_BACK_FACE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_HIT_KIND")]
	public enum D3D12_HIT_KIND
	{
		/// <summary/>
		D3D12_HIT_KIND_TRIANGLE_FRONT_FACE,

		/// <summary/>
		D3D12_HIT_KIND_TRIANGLE_BACK_FACE,
	}

	/// <summary>
	/// When using triangle strip primitive topology, vertex positions are interpreted as vertices of a continuous triangle “strip”. There
	/// is a special index value that represents the desire to have a discontinuity in the strip, the cut index value. This enum lists the
	/// supported cut values.
	/// </summary>
	/// <remarks>This enum is used by the <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_index_buffer_strip_cut_value typedef enum
	// D3D12_INDEX_BUFFER_STRIP_CUT_VALUE { D3D12_INDEX_BUFFER_STRIP_CUT_VALUE_DISABLED = 0, D3D12_INDEX_BUFFER_STRIP_CUT_VALUE_0xFFFF = 1,
	// D3D12_INDEX_BUFFER_STRIP_CUT_VALUE_0xFFFFFFFF = 2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_INDEX_BUFFER_STRIP_CUT_VALUE")]
	public enum D3D12_INDEX_BUFFER_STRIP_CUT_VALUE
	{
		/// <summary>
		/// <para>Value: 0 Indicates that there is no cut value.</para>
		/// </summary>
		D3D12_INDEX_BUFFER_STRIP_CUT_VALUE_DISABLED,

		/// <summary>
		/// <para>Value: 1 Indicates that 0xFFFF should be used as the cut value.</para>
		/// </summary>
		D3D12_INDEX_BUFFER_STRIP_CUT_VALUE_0xFFFF,

		/// <summary>
		/// <para>Value: 2 Indicates that 0xFFFFFFFF should be used as the cut value.</para>
		/// </summary>
		D3D12_INDEX_BUFFER_STRIP_CUT_VALUE_0xFFFFFFFF,
	}

	/// <summary>Specifies the type of the indirect parameter.</summary>
	/// <remarks>This enum is used by the <c>D3D12_INDIRECT_ARGUMENT_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_indirect_argument_type typedef enum
	// D3D12_INDIRECT_ARGUMENT_TYPE { D3D12_INDIRECT_ARGUMENT_TYPE_DRAW = 0, D3D12_INDIRECT_ARGUMENT_TYPE_DRAW_INDEXED,
	// D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH, D3D12_INDIRECT_ARGUMENT_TYPE_VERTEX_BUFFER_VIEW,
	// D3D12_INDIRECT_ARGUMENT_TYPE_INDEX_BUFFER_VIEW, D3D12_INDIRECT_ARGUMENT_TYPE_CONSTANT,
	// D3D12_INDIRECT_ARGUMENT_TYPE_CONSTANT_BUFFER_VIEW, D3D12_INDIRECT_ARGUMENT_TYPE_SHADER_RESOURCE_VIEW,
	// D3D12_INDIRECT_ARGUMENT_TYPE_UNORDERED_ACCESS_VIEW, D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH_RAYS,
	// D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH_MESH, D3D12_INDIRECT_ARGUMENT_TYPE_INCREMENTING_CONSTANT } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_INDIRECT_ARGUMENT_TYPE")]
	public enum D3D12_INDIRECT_ARGUMENT_TYPE
	{
		/// <summary>
		/// <para>Value: 0 Indicates the type is a Draw call.</para>
		/// </summary>
		D3D12_INDIRECT_ARGUMENT_TYPE_DRAW = 0,

		/// <summary>Indicates the type is a DrawIndexed call.</summary>
		D3D12_INDIRECT_ARGUMENT_TYPE_DRAW_INDEXED,

		/// <summary>Indicates the type is a Dispatch call.</summary>
		D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH,

		/// <summary>Indicates the type is a vertex buffer view.</summary>
		D3D12_INDIRECT_ARGUMENT_TYPE_VERTEX_BUFFER_VIEW,

		/// <summary>Indicates the type is an index buffer view.</summary>
		D3D12_INDIRECT_ARGUMENT_TYPE_INDEX_BUFFER_VIEW,

		/// <summary>Indicates the type is a constant.</summary>
		D3D12_INDIRECT_ARGUMENT_TYPE_CONSTANT,

		/// <summary>Indicates the type is a constant buffer view (CBV).</summary>
		D3D12_INDIRECT_ARGUMENT_TYPE_CONSTANT_BUFFER_VIEW,

		/// <summary>Indicates the type is a shader resource view (SRV).</summary>
		D3D12_INDIRECT_ARGUMENT_TYPE_SHADER_RESOURCE_VIEW,

		/// <summary>Indicates the type is an unordered access view (UAV).</summary>
		D3D12_INDIRECT_ARGUMENT_TYPE_UNORDERED_ACCESS_VIEW,

		/// <summary/>
		D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH_RAYS,

		/// <summary/>
		D3D12_INDIRECT_ARGUMENT_TYPE_DISPATCH_MESH,

		/// <summary/>
		D3D12_INDIRECT_ARGUMENT_TYPE_INCREMENTING_CONSTANT
	}

	/// <summary>Identifies the type of data contained in an input slot.</summary>
	/// <remarks>
	/// Specify one of these values in the member of a <c>D3D12_INPUT_ELEMENT_DESC</c> structure to specify the type of data for the input
	/// element of a pipeline state object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_input_classification typedef enum D3D12_INPUT_CLASSIFICATION
	// { D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA = 0, D3D12_INPUT_CLASSIFICATION_PER_INSTANCE_DATA = 1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_INPUT_CLASSIFICATION")]
	public enum D3D12_INPUT_CLASSIFICATION
	{
		/// <summary>
		/// <para>Value: 0 Input data is per-vertex data.</para>
		/// </summary>
		D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA,

		/// <summary>
		/// <para>Value: 1 Input data is per-instance data.</para>
		/// </summary>
		D3D12_INPUT_CLASSIFICATION_PER_INSTANCE_DATA,
	}

	/// <summary>Defines constants that specify the lifetime state of a lifetime-tracked object.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_lifetime_state typedef enum D3D12_LIFETIME_STATE {
	// D3D12_LIFETIME_STATE_IN_USE = 0, D3D12_LIFETIME_STATE_NOT_IN_USE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_LIFETIME_STATE")]
	public enum D3D12_LIFETIME_STATE
	{
		/// <summary>
		/// <para>Value: 0 Specifies that the lifetime-tracked object is in use.</para>
		/// </summary>
		D3D12_LIFETIME_STATE_IN_USE,

		/// <summary>Specifies that the lifetime-tracked object is not in use.</summary>
		D3D12_LIFETIME_STATE_NOT_IN_USE,
	}

	/// <summary>Defines constants that specify logical operations to configure for a render target.</summary>
	/// <remarks>This enum is used by the <c>D3D12_RENDER_TARGET_BLEND_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_logic_op typedef enum D3D12_LOGIC_OP { D3D12_LOGIC_OP_CLEAR
	// = 0, D3D12_LOGIC_OP_SET, D3D12_LOGIC_OP_COPY, D3D12_LOGIC_OP_COPY_INVERTED, D3D12_LOGIC_OP_NOOP, D3D12_LOGIC_OP_INVERT,
	// D3D12_LOGIC_OP_AND, D3D12_LOGIC_OP_NAND, D3D12_LOGIC_OP_OR, D3D12_LOGIC_OP_NOR, D3D12_LOGIC_OP_XOR, D3D12_LOGIC_OP_EQUIV,
	// D3D12_LOGIC_OP_AND_REVERSE, D3D12_LOGIC_OP_AND_INVERTED, D3D12_LOGIC_OP_OR_REVERSE, D3D12_LOGIC_OP_OR_INVERTED } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_LOGIC_OP")]
	public enum D3D12_LOGIC_OP
	{
		/// <summary>
		/// <para>Value: 0 Clears the render target (0).</para>
		/// </summary>
		D3D12_LOGIC_OP_CLEAR = 0,

		/// <summary>
		/// <para>Sets the render target (1).</para>
		/// </summary>
		D3D12_LOGIC_OP_SET,

		/// <summary>
		/// <para>Copys the render target (s source from Pixel Shader output).</para>
		/// </summary>
		D3D12_LOGIC_OP_COPY,

		/// <summary>
		/// <para>Performs an inverted-copy of the render target (~s).</para>
		/// </summary>
		D3D12_LOGIC_OP_COPY_INVERTED,

		/// <summary>
		/// <para>No operation is performed on the render target (d destination in the Render Target View).</para>
		/// </summary>
		D3D12_LOGIC_OP_NOOP,

		/// <summary>
		/// <para>Inverts the render target (~d).</para>
		/// </summary>
		D3D12_LOGIC_OP_INVERT,

		/// <summary>
		/// <para>Performs a logical AND operation on the render target (s &amp; d).</para>
		/// </summary>
		D3D12_LOGIC_OP_AND,

		/// <summary>
		/// <para>Performs a logical NAND operation on the render target (~(s &amp; d)).</para>
		/// </summary>
		D3D12_LOGIC_OP_NAND,

		/// <summary>
		/// <para>Performs a logical OR operation on the render target (s</para>
		/// </summary>
		D3D12_LOGIC_OP_OR,

		/// <summary>
		/// <para>Performs a logical NOR operation on the render target (~(s</para>
		/// </summary>
		D3D12_LOGIC_OP_NOR,

		/// <summary>
		/// <para>Performs a logical XOR operation on the render target (s ^ d).</para>
		/// </summary>
		D3D12_LOGIC_OP_XOR,

		/// <summary>
		/// <para>Performs a logical equal operation on the render target (~(s ^ d)).</para>
		/// </summary>
		D3D12_LOGIC_OP_EQUIV,

		/// <summary>
		/// <para>Performs a logical AND and reverse operation on the render target (s &amp; ~d).</para>
		/// </summary>
		D3D12_LOGIC_OP_AND_REVERSE,

		/// <summary>
		/// <para>Performs a logical AND and invert operation on the render target (~s &amp; d).</para>
		/// </summary>
		D3D12_LOGIC_OP_AND_INVERTED,

		/// <summary>
		/// <para>Performs a logical OR and reverse operation on the render target (s</para>
		/// </summary>
		D3D12_LOGIC_OP_OR_REVERSE,

		/// <summary>
		/// <para>Performs a logical OR and invert operation on the render target (~s</para>
		/// </summary>
		D3D12_LOGIC_OP_OR_INVERTED,
	}

	/// <summary>Defines constants that specify what should be done with the results of earlier workload instrumentation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_measurements_action typedef enum D3D12_MEASUREMENTS_ACTION {
	// D3D12_MEASUREMENTS_ACTION_KEEP_ALL = 0, D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS,
	// D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS_HIGH_PRIORITY, D3D12_MEASUREMENTS_ACTION_DISCARD_PREVIOUS } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_MEASUREMENTS_ACTION")]
	public enum D3D12_MEASUREMENTS_ACTION
	{
		/// <summary>
		/// <para>Value: 0 The default setting. Specifies that all results should be kept.</para>
		/// </summary>
		D3D12_MEASUREMENTS_ACTION_KEEP_ALL = 0,

		/// <summary>
		/// Specifies that the driver has seen all the data that it's ever going to, so it should stop waiting for more and go ahead
		/// compiling optimized shaders.
		/// </summary>
		D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS,

		/// <summary>
		/// <para>
		/// Like D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS , but also specifies that your application doesn't care about glitches, so the
		/// runtime should ignore the usual idle priority rules and go ahead using as many threads as possible to get shader recompiles done
		/// fast. Available only in
		/// </para>
		/// <para>Developer mode</para>
		/// <para>.</para>
		/// </summary>
		D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS_HIGH_PRIORITY,

		/// <summary>
		/// Specifies that the optimization state should be reset; hinting that whatever has previously been measured no longer applies.
		/// </summary>
		D3D12_MEASUREMENTS_ACTION_DISCARD_PREVIOUS,
	}

	/// <summary>Specifies the memory pool for the heap.</summary>
	/// <remarks>
	/// <para>This enum is used by the <c>D3D12_HEAP_PROPERTIES</c> structure.</para>
	/// <para>
	/// When the adapter is UMA, D3D12_MEMORY_POOL_L0 and DXGI_MEMORY_SEGMENT_GROUP_LOCAL refer to the same memory. When the adapter is not
	/// UMA: D3D12_MEMORY_POOL_L0 and DXGI_MEMORY_SEGMENT_GROUP_NON_LOCAL refer to the same memory. D3D12_MEMORY_POOL_L1 and
	/// DXGI_MEMORY_SEGMENT_GROUP_LOCAL refer to the same memory.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_memory_pool typedef enum D3D12_MEMORY_POOL {
	// D3D12_MEMORY_POOL_UNKNOWN = 0, D3D12_MEMORY_POOL_L0 = 1, D3D12_MEMORY_POOL_L1 = 2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_MEMORY_POOL")]
	public enum D3D12_MEMORY_POOL
	{
		/// <summary>
		/// <para>Value: 0 The memory pool is unknown.</para>
		/// </summary>
		D3D12_MEMORY_POOL_UNKNOWN,

		/// <summary>
		/// <para>Value: 1 The memory pool is L0.</para>
		/// <para>L0 is the physical system memory pool.</para>
		/// <para>When the adapter is discrete/NUMA, this pool has greater bandwidth for the CPU and less bandwidth for the GPU.</para>
		/// <para>When the adapter is UMA, this pool is the only one which is valid.</para>
		/// </summary>
		D3D12_MEMORY_POOL_L0,

		/// <summary>
		/// <para>Value: 2 The memory pool is L1.</para>
		/// <para>L1 is typically known as the physical video memory pool.</para>
		/// <para>
		/// L1 is only available when the adapter is discrete/NUMA, and has greater bandwidth for the GPU and cannot even be accessed by the CPU.
		/// </para>
		/// <para>When the adapter is UMA, this pool is not available.</para>
		/// </summary>
		D3D12_MEMORY_POOL_L1,
	}

	/// <summary>Defines constants that specify mesh and amplification shader support.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_mesh_shader_tier typedef enum D3D12_MESH_SHADER_TIER {
	// D3D12_MESH_SHADER_TIER_NOT_SUPPORTED = 0, D3D12_MESH_SHADER_TIER_1 = 10 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_MESH_SHADER_TIER")]
	public enum D3D12_MESH_SHADER_TIER
	{
		/// <summary>
		/// <para>Value: 0 Specifies that mesh and amplification shaders are not supported.</para>
		/// </summary>
		D3D12_MESH_SHADER_TIER_NOT_SUPPORTED,

		/// <summary>
		/// <para>Value: 10 Specifies that mesh and amplification shaders are supported.</para>
		/// </summary>
		D3D12_MESH_SHADER_TIER_1,
	}

	/// <summary>Defines constants that specify the flags for a parameter to a meta command. Values can be bitwise OR'd together.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_meta_command_parameter_flags typedef enum
	// D3D12_META_COMMAND_PARAMETER_FLAGS { D3D12_META_COMMAND_PARAMETER_FLAG_INPUT = 0x1, D3D12_META_COMMAND_PARAMETER_FLAG_OUTPUT = 0x2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_META_COMMAND_PARAMETER_FLAGS")]
	[Flags]
	public enum D3D12_META_COMMAND_PARAMETER_FLAGS
	{
		/// <summary>
		/// <para>Value: 0x1 Specifies that the parameter is an input resource.</para>
		/// </summary>
		D3D12_META_COMMAND_PARAMETER_FLAG_INPUT = 0x1,

		/// <summary>
		/// <para>Value: 0x2 Specifies that the parameter is an output resource.</para>
		/// </summary>
		D3D12_META_COMMAND_PARAMETER_FLAG_OUTPUT = 0x2,
	}

	/// <summary>Defines constants that specify the stage of a parameter to a meta command.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_meta_command_parameter_stage typedef enum
	// D3D12_META_COMMAND_PARAMETER_STAGE { D3D12_META_COMMAND_PARAMETER_STAGE_CREATION = 0,
	// D3D12_META_COMMAND_PARAMETER_STAGE_INITIALIZATION = 1, D3D12_META_COMMAND_PARAMETER_STAGE_EXECUTION = 2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_META_COMMAND_PARAMETER_STAGE")]
	public enum D3D12_META_COMMAND_PARAMETER_STAGE
	{
		/// <summary>
		/// <para>Value: 0 Specifies that the parameter is used at the meta command creation stage.</para>
		/// </summary>
		D3D12_META_COMMAND_PARAMETER_STAGE_CREATION,

		/// <summary>
		/// <para>Value: 1 Specifies that the parameter is used at the meta command initialization stage.</para>
		/// </summary>
		D3D12_META_COMMAND_PARAMETER_STAGE_INITIALIZATION,

		/// <summary>
		/// <para>Value: 2 Specifies that the parameter is used at the meta command execution stage.</para>
		/// </summary>
		D3D12_META_COMMAND_PARAMETER_STAGE_EXECUTION,
	}

	/// <summary>Defines constants that specify the data type of a parameter to a meta command.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_meta_command_parameter_type typedef enum
	// D3D12_META_COMMAND_PARAMETER_TYPE { D3D12_META_COMMAND_PARAMETER_TYPE_FLOAT = 0, D3D12_META_COMMAND_PARAMETER_TYPE_UINT64 = 1,
	// D3D12_META_COMMAND_PARAMETER_TYPE_GPU_VIRTUAL_ADDRESS = 2,
	// D3D12_META_COMMAND_PARAMETER_TYPE_CPU_DESCRIPTOR_HANDLE_HEAP_TYPE_CBV_SRV_UAV = 3,
	// D3D12_META_COMMAND_PARAMETER_TYPE_GPU_DESCRIPTOR_HANDLE_HEAP_TYPE_CBV_SRV_UAV = 4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_META_COMMAND_PARAMETER_TYPE")]
	public enum D3D12_META_COMMAND_PARAMETER_TYPE
	{
		/// <summary>
		/// <para>Value: 0 Specifies that the parameter is of type FLOAT .</para>
		/// </summary>
		D3D12_META_COMMAND_PARAMETER_TYPE_FLOAT,

		/// <summary>
		/// <para>Value: 1 Specifies that the parameter is of type UINT64 .</para>
		/// </summary>
		D3D12_META_COMMAND_PARAMETER_TYPE_UINT64,

		/// <summary>
		/// <para>Value: 2 Specifies that the parameter is a GPU virtual address.</para>
		/// </summary>
		D3D12_META_COMMAND_PARAMETER_TYPE_GPU_VIRTUAL_ADDRESS,

		/// <summary>
		/// <para>Value: 3 
		/// Specifies that the parameter is a CPU descriptor handle to a heap containing either constant buffer views, shader resource
		/// views, or unordered access views.
		/// </para>
		/// </summary>
		D3D12_META_COMMAND_PARAMETER_TYPE_CPU_DESCRIPTOR_HANDLE_HEAP_TYPE_CBV_SRV_UAV,

		/// <summary>
		/// <para>Value: 4 
		/// Specifies that the parameter is a GPU descriptor handle to a heap containing either constant buffer views, shader resource
		/// views, or unordered access views.
		/// </para>
		/// </summary>
		D3D12_META_COMMAND_PARAMETER_TYPE_GPU_DESCRIPTOR_HANDLE_HEAP_TYPE_CBV_SRV_UAV,
	}

	/// <summary>Specifies multiple wait flags for multiple fences.</summary>
	/// <remarks>This enum is used by the <c>SetEventOnMultipleFenceCompletion</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_multiple_fence_wait_flags typedef enum
	// D3D12_MULTIPLE_FENCE_WAIT_FLAGS { D3D12_MULTIPLE_FENCE_WAIT_FLAG_NONE = 0, D3D12_MULTIPLE_FENCE_WAIT_FLAG_ANY = 0x1,
	// D3D12_MULTIPLE_FENCE_WAIT_FLAG_ALL = 0 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_MULTIPLE_FENCE_WAIT_FLAGS")]
	[Flags]
	public enum D3D12_MULTIPLE_FENCE_WAIT_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 
		/// No flags are being passed. This means to use the default behavior, which is to wait for all fences before signaling the event.
		/// </para>
		/// </summary>
		D3D12_MULTIPLE_FENCE_WAIT_FLAG_NONE,

		/// <summary>
		/// <para>Value: 0x1 
		/// Modifies behavior to indicate that the event should be signaled after any one of the fence values has been reached by its
		/// corresponding fence.
		/// </para>
		/// </summary>
		D3D12_MULTIPLE_FENCE_WAIT_FLAG_ANY = 1,

		/// <summary>
		/// <para>Value: 0 An alias for D3D12_MULTIPLE_FENCE_WAIT_FLAG_NONE , meaning to use the default behavior and wait for all fences.</para>
		/// </summary>
		D3D12_MULTIPLE_FENCE_WAIT_FLAG_ALL = 0,
	}

	/// <summary>Specifies options for determining quality levels.</summary>
	/// <remarks>This enum is used by the <c>D3D12_FEATURE_DATA_MULTISAMPLE_QUALITY_LEVELS</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_multisample_quality_level_flags typedef enum
	// D3D12_MULTISAMPLE_QUALITY_LEVEL_FLAGS { D3D12_MULTISAMPLE_QUALITY_LEVELS_FLAG_NONE = 0,
	// D3D12_MULTISAMPLE_QUALITY_LEVELS_FLAG_TILED_RESOURCE = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_MULTISAMPLE_QUALITY_LEVEL_FLAGS")]
	[Flags]
	public enum D3D12_MULTISAMPLE_QUALITY_LEVEL_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No options are supported.</para>
		/// </summary>
		D3D12_MULTISAMPLE_QUALITY_LEVELS_FLAG_NONE,

		/// <summary>
		/// <para>Value: 0x1 The number of quality levels can be determined for tiled resources.</para>
		/// </summary>
		D3D12_MULTISAMPLE_QUALITY_LEVELS_FLAG_TILED_RESOURCE,
	}

	/// <summary>Flags to control pipeline state.</summary>
	/// <remarks>
	/// This enum is used by the <b>Flags</b> member of the <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> and
	/// <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c> structures.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_pipeline_state_flags typedef enum D3D12_PIPELINE_STATE_FLAGS
	// { D3D12_PIPELINE_STATE_FLAG_NONE = 0, D3D12_PIPELINE_STATE_FLAG_TOOL_DEBUG = 0x1, D3D12_PIPELINE_STATE_FLAG_DYNAMIC_DEPTH_BIAS,
	// D3D12_PIPELINE_STATE_FLAG_DYNAMIC_INDEX_BUFFER_STRIP_CUT } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_PIPELINE_STATE_FLAGS")]
	[Flags]
	public enum D3D12_PIPELINE_STATE_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Indicates no flags.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_FLAG_NONE = 0,

		/// <summary>
		/// <para>Value: 0x1 Indicates that the pipeline state should be compiled with additional information to assist debugging.</para>
		/// <para>This can only be set on WARP devices.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_FLAG_TOOL_DEBUG = 1,

		/// <summary>Indicates that the pipeline state can be dynamically changed after the pipeline is set by using RSSetDepthBias.</summary>
		D3D12_PIPELINE_STATE_FLAG_DYNAMIC_DEPTH_BIAS = 4,

		/// <summary>Indicates that the pipeline state can be dynamically changed after the pipeline is set by using IASetIndexBufferStripCutValue.</summary>
		D3D12_PIPELINE_STATE_FLAG_DYNAMIC_INDEX_BUFFER_STRIP_CUT = 8,
	}

	/// <summary>Specifies the type of a sub-object in a pipeline state stream description.</summary>
	/// <remarks>
	/// This enum is used in the creation of pipeline state objects using the ID3D12Device1::CreatePipelineState method. The
	/// CreatePipelineState method takes a D3D12_PIPELINE_STATE_STREAM_DESC as one of its parameters, this structure in turn describes a
	/// bytestream made up of alternating D3D12_PIPELINE_STATE_SUBOBJECT_TYPE enumeration values and their corresponding subobject
	/// description structs. This bytestream description can be made a concrete type by defining a structure that has the same alternating
	/// pattern of alternating D3D12_PIPELINE_STATE_SUBOBJECT_TYPE enumeration values and their corresponding subobject description structs
	/// as members.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_pipeline_state_subobject_type typedef enum
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE { D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_ROOT_SIGNATURE = 0, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_VS,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_PS, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DS, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_HS,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_GS, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_CS, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_STREAM_OUTPUT,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_BLEND, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_SAMPLE_MASK,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RASTERIZER, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_INPUT_LAYOUT, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_IB_STRIP_CUT_VALUE,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_PRIMITIVE_TOPOLOGY, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RENDER_TARGET_FORMATS,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL_FORMAT, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_SAMPLE_DESC,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_NODE_MASK, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_CACHED_PSO,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_FLAGS, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL1,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_VIEW_INSTANCING, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_AS = 24,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_MS = 25, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL2,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RASTERIZER1, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RASTERIZER2,
	// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_MAX_VALID } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE")]
	public enum D3D12_PIPELINE_STATE_SUBOBJECT_TYPE
	{
		/// <summary>
		/// <para>Value: 0 Indicates a root signature subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>ID3D12RootSignature</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_ROOT_SIGNATURE = 0,

		/// <summary>
		/// <para>Indicates a vertex shader subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_SHADER_BYTECODE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_VS,

		/// <summary>
		/// <para>Indicates a pixel shader subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_SHADER_BYTECODE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_PS,

		/// <summary>
		/// <para>Indicates a domain shader subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_SHADER_BYTECODE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DS,

		/// <summary>
		/// <para>Indicates a hull shader subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_SHADER_BYTECODE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_HS,

		/// <summary>
		/// <para>Indicates a geometry shader subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_SHADER_BYTECODE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_GS,

		/// <summary>
		/// <para>Indicates a compute shader subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_SHADER_BYTECODE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_CS,

		/// <summary>
		/// <para>Indicates a stream-output subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_STREAM_OUTPUT_DESC</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_STREAM_OUTPUT,

		/// <summary>
		/// <para>Indicates a blend subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_BLEND_DESC</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_BLEND,

		/// <summary>
		/// <para>Indicates a sample mask subobject type.</para>
		/// <para>The corresponding subobject type is UINT.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_SAMPLE_MASK,

		/// <summary>
		/// <para>Indicates indicates a rasterizer subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_RASTERIZER_DESC</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RASTERIZER,

		/// <summary>
		/// <para>Indicates a depth stencil subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_DEPTH_STENCIL_DESC</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL,

		/// <summary>
		/// <para>Indicates an input layout subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_INPUT_LAYOUT_DESC</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_INPUT_LAYOUT,

		/// <summary>
		/// <para>Indicates an index buffer strip cut value subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_INDEX_BUFFER_STRIP_CUT_VALUE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_IB_STRIP_CUT_VALUE,

		/// <summary>
		/// <para>Indicates a primitive topology subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_PRIMITIVE_TOPOLOGY_TYPE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_PRIMITIVE_TOPOLOGY,

		/// <summary>
		/// <para>Indicates a render target formats subobject type. The corresponding subobject type is</para>
		/// <para><c>D3D12_RT_FORMAT_ARRAY</c></para>
		/// <para>structure, which wraps an array of render target formats along with a count of the array elements.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RENDER_TARGET_FORMATS,

		/// <summary>
		/// <para>Indicates a depth stencil format subobject.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>DXGI_FORMAT</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL_FORMAT,

		/// <summary>
		/// <para>Indicates a sample description subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>DXGI_SAMPLE_DESC</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_SAMPLE_DESC,

		/// <summary>
		/// <para>Indicates a node mask subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_NODE_MASK</c></para>
		/// <para>or UINT.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_NODE_MASK,

		/// <summary>
		/// <para>Indicates a cached pipeline state object subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_CACHED_PIPELINE_STATE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_CACHED_PSO,

		/// <summary>
		/// <para>Indicates a flags subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_PIPELINE_STATE_FLAGS</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_FLAGS,

		/// <summary>
		/// <para>
		/// Indicates an expanded depth stencil subobject type. This expansion of the depth stencil subobject supports optional depth bounds checking.
		/// </para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_DEPTH_STENCIL_DESC1</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL1,

		/// <summary>
		/// <para>Indicates a view instancing subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_VIEW_INSTANCING_DESC</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_VIEW_INSTANCING,

		/// <summary>
		/// <para>Value: 24 Indicates an amplification shader subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_SHADER_BYTECODE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_AS,

		/// <summary>
		/// <para>Value: 25 Indicates a mesh shader subobject type.</para>
		/// <para>The corresponding subobject type is</para>
		/// <para><c>D3D12_SHADER_BYTECODE</c></para>
		/// <para>.</para>
		/// </summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_MS,

		/// <summary>A sentinel value that marks the exclusive upper-bound of valid values this enumeration represents.</summary>
		D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_MAX_VALID,
	}

	/// <summary>Specifies the predication operation to apply.</summary>
	/// <remarks>
	/// <para>This enum is used by <c>SetPredication</c>.</para>
	/// <para>Predication is decoupled from queries. Predication can be set based on the value of 64-bits within a buffer.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_predication_op typedef enum D3D12_PREDICATION_OP {
	// D3D12_PREDICATION_OP_EQUAL_ZERO = 0, D3D12_PREDICATION_OP_NOT_EQUAL_ZERO = 1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_PREDICATION_OP")]
	public enum D3D12_PREDICATION_OP
	{
		/// <summary>
		/// <para>Value: 0 Enables predication if all 64-bits are zero.</para>
		/// </summary>
		D3D12_PREDICATION_OP_EQUAL_ZERO,

		/// <summary>
		/// <para>Value: 1 Enables predication if at least one of the 64-bits are not zero.</para>
		/// </summary>
		D3D12_PREDICATION_OP_NOT_EQUAL_ZERO,
	}

	/// <summary>Specifies how the pipeline interprets geometry or hull shader input primitives.</summary>
	/// <remarks>This enum is used by the <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_primitive_topology_type typedef enum
	// D3D12_PRIMITIVE_TOPOLOGY_TYPE { D3D12_PRIMITIVE_TOPOLOGY_TYPE_UNDEFINED = 0, D3D12_PRIMITIVE_TOPOLOGY_TYPE_POINT = 1,
	// D3D12_PRIMITIVE_TOPOLOGY_TYPE_LINE = 2, D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE = 3, D3D12_PRIMITIVE_TOPOLOGY_TYPE_PATCH = 4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_PRIMITIVE_TOPOLOGY_TYPE")]
	public enum D3D12_PRIMITIVE_TOPOLOGY_TYPE
	{
		/// <summary>
		/// <para>Value: 0 The shader has not been initialized with an input primitive type.</para>
		/// </summary>
		D3D12_PRIMITIVE_TOPOLOGY_TYPE_UNDEFINED,

		/// <summary>
		/// <para>Value: 1 Interpret the input primitive as a point.</para>
		/// </summary>
		D3D12_PRIMITIVE_TOPOLOGY_TYPE_POINT,

		/// <summary>
		/// <para>Value: 2 Interpret the input primitive as a line.</para>
		/// </summary>
		D3D12_PRIMITIVE_TOPOLOGY_TYPE_LINE,

		/// <summary>
		/// <para>Value: 3 Interpret the input primitive as a triangle.</para>
		/// </summary>
		D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE,

		/// <summary>
		/// <para>Value: 4 Interpret the input primitive as a control point patch.</para>
		/// </summary>
		D3D12_PRIMITIVE_TOPOLOGY_TYPE_PATCH,
	}

	/// <summary>Specifies the level of support for programmable sample positions that's offered by the adapter.</summary>
	/// <remarks>
	/// This enum is used by the <c>D3D12_FEATURE_D3D12_DATA_OPTIONS2</c> structure to indicate the level of support offered for
	/// programmable sample positions.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_programmable_sample_positions_tier typedef enum
	// D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER { D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER_NOT_SUPPORTED = 0,
	// D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER_1 = 1, D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER_2 = 2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER")]
	public enum D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER
	{
		/// <summary>
		/// <para>Value: 0 Indicates that there's no support for programmable sample positions.</para>
		/// </summary>
		D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER_NOT_SUPPORTED,

		/// <summary>
		/// <para>Value: 1 
		/// Indicates that there's tier 1 support for programmable sample positions. In tier 1, a single sample pattern can be specified to
		/// repeat for every pixel ( SetSamplePositionparameter NumPixels= 1) and ResolveSubResource is supported.
		/// </para>
		/// </summary>
		D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER_1,

		/// <summary>
		/// <para>Value: 2 
		/// Indicates that there's tier 2 support for programmable sample positions. In tier 2, four separate sample patterns can be
		/// specified for each pixel in a 2x2 grid ( SetSamplePositionparameter NumPixels= 4) that repeats over the render-target or
		/// viewport, aligned on even coordinates .
		/// </para>
		/// </summary>
		D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER_2,
	}

	/// <summary>
	/// Defines constants that specify protected resource session flags. These flags can be bitwise OR'd together to specify multiple flags
	/// at once.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_protected_resource_session_flags typedef enum
	// D3D12_PROTECTED_RESOURCE_SESSION_FLAGS { D3D12_PROTECTED_RESOURCE_SESSION_FLAG_NONE = 0 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_PROTECTED_RESOURCE_SESSION_FLAGS")]
	[Flags]
	public enum D3D12_PROTECTED_RESOURCE_SESSION_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Specifies no flag.</para>
		/// </summary>
		D3D12_PROTECTED_RESOURCE_SESSION_FLAG_NONE,
	}

	/// <summary>Defines constants that specify protected resource session support.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_protected_resource_session_support_flags typedef enum
	// D3D12_PROTECTED_RESOURCE_SESSION_SUPPORT_FLAGS { D3D12_PROTECTED_RESOURCE_SESSION_SUPPORT_FLAG_NONE,
	// D3D12_PROTECTED_RESOURCE_SESSION_SUPPORT_FLAG_SUPPORTED } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_PROTECTED_RESOURCE_SESSION_SUPPORT_FLAGS")]
	[Flags]
	public enum D3D12_PROTECTED_RESOURCE_SESSION_SUPPORT_FLAGS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x0)</para>
		/// <para>Indicates that protected resource sessions are not supported.</para>
		/// </summary>
		D3D12_PROTECTED_RESOURCE_SESSION_SUPPORT_FLAG_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>(0x1)</para>
		/// <para>Indicates that protected resource sessions are supported.</para>
		/// </summary>
		D3D12_PROTECTED_RESOURCE_SESSION_SUPPORT_FLAG_SUPPORTED,
	}

	/// <summary>Defines constants that specify protected session status.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_protected_session_status typedef enum
	// D3D12_PROTECTED_SESSION_STATUS { D3D12_PROTECTED_SESSION_STATUS_OK = 0, D3D12_PROTECTED_SESSION_STATUS_INVALID = 1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_PROTECTED_SESSION_STATUS")]
	public enum D3D12_PROTECTED_SESSION_STATUS
	{
		/// <summary>
		/// <para>Value: 0 Indicates that the protected session is in a valid state.</para>
		/// </summary>
		D3D12_PROTECTED_SESSION_STATUS_OK,

		/// <summary>
		/// <para>Value: 1 Indicates that the protected session is not in a valid state.</para>
		/// </summary>
		D3D12_PROTECTED_SESSION_STATUS_INVALID,
	}

	/// <summary>Specifies the type of query heap to create.</summary>
	/// <remarks>This enum is used by the <c>D3D12_QUERY_HEAP_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_query_heap_type typedef enum D3D12_QUERY_HEAP_TYPE {
	// D3D12_QUERY_HEAP_TYPE_OCCLUSION = 0, D3D12_QUERY_HEAP_TYPE_TIMESTAMP = 1, D3D12_QUERY_HEAP_TYPE_PIPELINE_STATISTICS = 2,
	// D3D12_QUERY_HEAP_TYPE_SO_STATISTICS = 3, D3D12_QUERY_HEAP_TYPE_VIDEO_DECODE_STATISTICS = 4,
	// D3D12_QUERY_HEAP_TYPE_COPY_QUEUE_TIMESTAMP = 5, D3D12_QUERY_HEAP_TYPE_PIPELINE_STATISTICS1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_QUERY_HEAP_TYPE")]
	public enum D3D12_QUERY_HEAP_TYPE
	{
		/// <summary>
		/// <para>Value: 0 
		/// This returns a binary 0/1 result: 0 indicates that no samples passed depth and stencil testing, 1 indicates that at least one
		/// sample passed depth and stencil testing. This enables occlusion queries to not interfere with any GPU performance optimization
		/// associated with depth/stencil testing.
		/// </para>
		/// </summary>
		D3D12_QUERY_HEAP_TYPE_OCCLUSION,

		/// <summary>
		/// <para>Value: 1 Indicates that the heap is for high-performance timing data.</para>
		/// </summary>
		D3D12_QUERY_HEAP_TYPE_TIMESTAMP,

		/// <summary>
		/// <para>Value: 2 Indicates the heap is to contain pipeline data. Refer to D3D12_QUERY_DATA_PIPELINE_STATISTICS.</para>
		/// </summary>
		D3D12_QUERY_HEAP_TYPE_PIPELINE_STATISTICS,

		/// <summary>
		/// <para>Value: 3 Indicates the heap is to contain stream output data. Refer to D3D12_QUERY_DATA_SO_STATISTICS.</para>
		/// </summary>
		D3D12_QUERY_HEAP_TYPE_SO_STATISTICS,

		/// <summary>
		/// <para>Value: 4 Indicates the heap is to contain video decode statistics data. Refer to D3D12_QUERY_DATA_VIDEO_DECODE_STATISTICS.</para>
		/// <para>
		/// Video decode statistics can only be queried from video decode command lists ( D3D12_COMMAND_LIST_TYPE_VIDEO_DECODE). See
		/// D3D12_QUERY_TYPE_DECODE_STATISTICSfor more details.
		/// </para>
		/// </summary>
		D3D12_QUERY_HEAP_TYPE_VIDEO_DECODE_STATISTICS,

		/// <summary>
		/// <para>Value: 5 
		/// Indicates the heap is to contain timestamp queries emitted exclusively by copy command lists. Copy queue timestamps can only be
		/// queried from a copy command list, and a copy command list can not emit to a regular timestamp query Heap.
		/// </para>
		/// <para>
		/// Support for this query heap type is not universal. You must use CheckFeatureSupportwith D3D12_FEATURE_D3D12_OPTIONS3to determine
		/// whether the adapter supports copy queue timestamp queries.
		/// </para>
		/// </summary>
		D3D12_QUERY_HEAP_TYPE_COPY_QUEUE_TIMESTAMP,
	}

	/// <summary>Specifies the type of query.</summary>
	/// <remarks>This enum is used by <c>BeginQuery</c>, <c>EndQuery</c> and <c>ResolveQueryData.</c></remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_query_type typedef enum D3D12_QUERY_TYPE {
	// D3D12_QUERY_TYPE_OCCLUSION = 0, D3D12_QUERY_TYPE_BINARY_OCCLUSION = 1, D3D12_QUERY_TYPE_TIMESTAMP = 2,
	// D3D12_QUERY_TYPE_PIPELINE_STATISTICS = 3, D3D12_QUERY_TYPE_SO_STATISTICS_STREAM0 = 4, D3D12_QUERY_TYPE_SO_STATISTICS_STREAM1 = 5,
	// D3D12_QUERY_TYPE_SO_STATISTICS_STREAM2 = 6, D3D12_QUERY_TYPE_SO_STATISTICS_STREAM3 = 7, D3D12_QUERY_TYPE_VIDEO_DECODE_STATISTICS = 8,
	// D3D12_QUERY_TYPE_PIPELINE_STATISTICS1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_QUERY_TYPE")]
	public enum D3D12_QUERY_TYPE
	{
		/// <summary>
		/// <para>Value: 0 Indicates the query is for depth/stencil occlusion counts.</para>
		/// </summary>
		D3D12_QUERY_TYPE_OCCLUSION,

		/// <summary>
		/// <para>Value: 1 Indicates the query is for a binary depth/stencil occlusion statistics.</para>
		/// <para>
		/// This new query type acts like D3D12_QUERY_TYPE_OCCLUSION except that it returns simply a binary 0/1 result: 0 indicates that no
		/// samples passed depth and stencil testing, 1 indicates that at least one sample passed depth and stencil testing. This enables
		/// occlusion queries to not interfere with any GPU performance optimization associated with depth/stencil testing.
		/// </para>
		/// </summary>
		D3D12_QUERY_TYPE_BINARY_OCCLUSION,

		/// <summary>
		/// <para>Value: 2 Indicates the query is for high definition GPU and CPU timestamps.</para>
		/// </summary>
		D3D12_QUERY_TYPE_TIMESTAMP,

		/// <summary>
		/// <para>Value: 3 Indicates the query type is for graphics pipeline statistics, refer to D3D12_QUERY_DATA_PIPELINE_STATISTICS.</para>
		/// </summary>
		D3D12_QUERY_TYPE_PIPELINE_STATISTICS,

		/// <summary>
		/// <para>Value: 4 
		/// Stream 0 output statistics. In Direct3D 12 there is no single stream output (SO) overflow query for all the output streams. Apps
		/// need to issue multiple single-stream queries, and then correlate the results. Stream output is the ability of the GPU to write
		/// vertices to a buffer. The stream output counters monitor progress.
		/// </para>
		/// </summary>
		D3D12_QUERY_TYPE_SO_STATISTICS_STREAM0,

		/// <summary>
		/// <para>Value: 5 Stream 1 output statistics.</para>
		/// </summary>
		D3D12_QUERY_TYPE_SO_STATISTICS_STREAM1,

		/// <summary>
		/// <para>Value: 6 Stream 2 output statistics.</para>
		/// </summary>
		D3D12_QUERY_TYPE_SO_STATISTICS_STREAM2,

		/// <summary>
		/// <para>Value: 7 Stream 3 output statistics.</para>
		/// </summary>
		D3D12_QUERY_TYPE_SO_STATISTICS_STREAM3,

		/// <summary>
		/// <para>Value: 8 Video decode statistics. Refer to D3D12_QUERY_DATA_VIDEO_DECODE_STATISTICS.</para>
		/// <para>
		/// Use this query type to determine if a video was successfully decoded. If decoding fails due to insufficient BitRate or FrameRate
		/// parameters set during creation of the decode heap, then the status field of the query is set to
		/// D3D12_VIDEO_DECODE_STATUS_RATE_EXCEEDEDand the query also contains new BitRate and FrameRate values that would succeed.
		/// </para>
		/// <para>
		/// This query type can only be performed on video decode command lists (D3D12_COMMAND_LIST_TYPE_VIDEO_DECODE). This query type does
		/// not use ID3D12VideoDecodeCommandList::BeginQuery, only ID3D12VideoDecodeCommandList::EndQuery. Statistics are recorded only for
		/// the most recent ID3D12VideoDecodeCommandList::DecodeFrame call in the same command list.
		/// </para>
		/// <para>Decode status structures are defined by the codec specification.</para>
		/// </summary>
		D3D12_QUERY_TYPE_VIDEO_DECODE_STATISTICS,
	}

	/// <summary>Flags passed to the <c>TraceRay</c> function to override transparency, culling, and early-out behavior.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_ray_flags typedef enum D3D12_RAY_FLAGS { D3D12_RAY_FLAG_NONE
	// = 0, D3D12_RAY_FLAG_FORCE_OPAQUE = 0x1, D3D12_RAY_FLAG_FORCE_NON_OPAQUE = 0x2, D3D12_RAY_FLAG_ACCEPT_FIRST_HIT_AND_END_SEARCH = 0x4,
	// D3D12_RAY_FLAG_SKIP_CLOSEST_HIT_SHADER = 0x8, D3D12_RAY_FLAG_CULL_BACK_FACING_TRIANGLES = 0x10,
	// D3D12_RAY_FLAG_CULL_FRONT_FACING_TRIANGLES = 0x20, D3D12_RAY_FLAG_CULL_OPAQUE = 0x40, D3D12_RAY_FLAG_CULL_NON_OPAQUE = 0x80,
	// D3D12_RAY_FLAG_SKIP_TRIANGLES, D3D12_RAY_FLAG_SKIP_PROCEDURAL_PRIMITIVES } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RAY_FLAGS")]
	[Flags]
	public enum D3D12_RAY_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No options selected.</para>
		/// </summary>
		D3D12_RAY_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 
		/// All ray-primitive intersections encountered in a raytrace are treated as opaque. So no any hit shaders will be executed
		/// regardless of whether or not the hit geometry specifies D3D12_RAYTRACING_GEOMETRY_FLAG_OPAQUE, and regardless of the instance
		/// flags on the instance that was hit.
		/// </para>
		/// <para>This flag is mutually exclusive with RAY_FLAG_FORCE_NON_OPAQUE, RAY_FLAG_CULL_OPAQUE and RAY_FLAG_CULL_NON_OPAQUE.</para>
		/// </summary>
		D3D12_RAY_FLAG_FORCE_OPAQUE = 0x1,

		/// <summary>
		/// <para>Value: 0x2 
		/// All ray-primitive intersections encountered in a raytrace are treated as non-opaque. So any hit shaders, if present, will be
		/// executed regardless of whether or not the hit geometry specifies D3D12_RAYTRACING_GEOMETRY_FLAG_OPAQUE, and regardless of the
		/// instance flags on the instance that was hit. This flag is mutually exclusive with RAY_FLAG_FORCE_\OPAQUE, RAY_FLAG_CULL_OPAQUE
		/// and RAY_FLAG_CULL_NON_OPAQUE.
		/// </para>
		/// </summary>
		D3D12_RAY_FLAG_FORCE_NON_OPAQUE = 0x2,

		/// <summary>
		/// <para>Value: 0x4 
		/// The first ray-primitive intersection encountered in a raytrace automatically causes AcceptHitAndEndSearch to be called
		/// immediately after the any hit shader, including if there is no any hit shader.
		/// </para>
		/// <para>
		/// The only exception is when the preceding any hit shader calls IgnoreHit , in which case the ray continues unaffected such that
		/// the next hit becomes another candidate to be the first hit. For this exception to apply, the any hit shader has to actually be
		/// executed. So if the any hit shader is skipped because the hit is treated as opaque (e.g. due to RAY_FLAG_FORCE_OPAQUE or
		/// D3D12_RAYTRACING_GEOMETRY_FLAG_OPAQUE or D3D12_RAYTRACING_INSTANCE_FLAG_OPAQUE being set), then AcceptHitAndEndSearch is called.
		/// </para>
		/// <para>
		/// If a closest hit shader is present at the first hit, it gets invoked unless RAY_FLAG_SKIP_CLOSEST_HIT_SHADER is also present.
		/// The one hit that was found is considered “closest”, even though other potential hits that might be closer on the ray may not
		/// have been visited.
		/// </para>
		/// <para>A typical use for this flag is for shadows, where only a single hit needs to be found.</para>
		/// </summary>
		D3D12_RAY_FLAG_ACCEPT_FIRST_HIT_AND_END_SEARCH = 0x4,

		/// <summary>
		/// <para>Value: 0x8 
		/// Even if at least one hit has been committed, and the hit group for the closest hit contains a closest hit shader, skip execution
		/// of that shader.
		/// </para>
		/// </summary>
		D3D12_RAY_FLAG_SKIP_CLOSEST_HIT_SHADER = 0x8,

		/// <summary>
		/// <para>Value: 0x10 
		/// Enables culling of back facing triangles. See D3D12_RAYTRACING_INSTANCE_FLAGS for selecting which triangles are back facing, per-instance.
		/// </para>
		/// <para>On instances that specify D3D12_RAYTRACING_INSTANCE_FLAG_TRIANGLE_CULL_DISABLE, this flag has no effect.</para>
		/// <para>On geometry types other than D3D12_RAYTRACING_GEOMETRY_TYPE_TRIANGLES, this flag has no effect.</para>
		/// <para>This flag is mutually exclusive with RAY_FLAG_CULL_FRONT_FACING_TRIANGLES.</para>
		/// </summary>
		D3D12_RAY_FLAG_CULL_BACK_FACING_TRIANGLES = 0x10,

		/// <summary>
		/// <para>Value: 0x20 
		/// Enables culling of front facing triangles. See D3D12_RAYTRACING_INSTANCE_FLAGS for selecting which triangles are back facing, per-instance.
		/// </para>
		/// <para>On instances that specify D3D12_RAYTRACING_INSTANCE_FLAG_TRIANGLE_CULL_DISABLE, this flag has no effect.</para>
		/// <para>On geometry types other than D3D12_RAYTRACING_GEOMETRY_TYPE_TRIANGLES, this flag has no effect.</para>
		/// <para>This flag is mutually exclusive with RAY_FLAG_CULL_FRONT_FACING_TRIANGLES.</para>
		/// </summary>
		D3D12_RAY_FLAG_CULL_FRONT_FACING_TRIANGLES = 0x20,

		/// <summary>
		/// <para>Value: 0x40 Culls all primitives that are considered opaque based on their geometry and instance flags.</para>
		/// <para>This flag is mutually exclusive with RAY_FLAG_FORCE_OPAQUE, RAY_FLAG_FORCE_NON_OPAQUE, and RAY_FLAG_CULL_NON_OPAQUE.</para>
		/// </summary>
		D3D12_RAY_FLAG_CULL_OPAQUE = 0x40,

		/// <summary>
		/// <para>Value: 0x80 Culls all primitives that are considered non-opaque based on their geometry and instance flags.</para>
		/// <para>This flag is mutually exclusive with RAY_FLAG_FORCE_OPAQUE, RAY_FLAG_FORCE_NON_OPAQUE, and RAY_FLAG_CULL_OPAQUE.</para>
		/// </summary>
		D3D12_RAY_FLAG_CULL_NON_OPAQUE = 0x80,
	}

	/// <summary>
	/// Specifies flags for the build of a raytracing acceleration structure. Use a value from this enumeration with the
	/// <c>D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS</c> structure that provides input to the acceleration structure build operation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_raytracing_acceleration_structure_build_flags typedef enum
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAGS { D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_NONE = 0,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_UPDATE = 0x1,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_COMPACTION = 0x2,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PREFER_FAST_TRACE = 0x4,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PREFER_FAST_BUILD = 0x8,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_MINIMIZE_MEMORY = 0x10,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PERFORM_UPDATE = 0x20 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAGS")]
	[Flags]
	public enum D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No options specified for the acceleration structure build.</para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 
		/// Build the acceleration structure such that it supports future updates (via the flag
		/// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PERFORM_UPDATE) instead of the app having to entirely rebuild the structure.
		/// This option may result in increased memory consumption, build times, and lower raytracing performance. Future updates, however,
		/// should be faster than building the equivalent acceleration structure from scratch.
		/// </para>
		/// <para>
		/// This flag can only be set on an initial acceleration structure build, or on an update where the source acceleration structure
		/// specified D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_UPDATE . In other words, after an acceleration structure was
		/// been built without D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_UPDATE, no other acceleration structures can be
		/// created from it via updates.
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_UPDATE = 0x1,

		/// <summary>
		/// <para>Value: 0x2 
		/// Enables the option to compact the acceleration structure by calling CopyRaytracingAccelerationStructure using compact mode,
		/// specified with D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_COMPACT.
		/// </para>
		/// <para>
		/// This option may result in increased memory consumption and build times. After future compaction, however, the resulting
		/// acceleration structure should consume a smaller memory footprint than building the acceleration structure from scratch.
		/// </para>
		/// <para>
		/// This flag is compatible with all other flags. If specified as part of an acceleration structure update, the source acceleration
		/// structure must have also been built with this flag. In other words, after an acceleration structure was been built without
		/// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_COMPACTION, no other acceleration structures can be created from it via
		/// updates that specify D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_COMPACTION.
		/// </para>
		/// <para>Specifying ALLOW_COMPACTION may increase pre-compaction acceleration structure size versus not specifying ALLOW_COMPACTION.</para>
		/// <para>
		/// If multiple incremental builds are performed before finally compacting, there may be redundant compaction related work performed.
		/// </para>
		/// <para>
		/// The size required for the compacted acceleration structure can be queried before compaction via
		/// EmitRaytracingAccelerationStructurePostbuildInfo. See D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_COMPACTED_SIZE_DESC
		/// for more information on properties of compacted acceleration structure size.
		/// </para>
		/// <note> When <b>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_UPDATE</b> is specified, there is certain information
		/// that needs to be retained in the acceleration structure, and compaction will only help so much. However, if the pipeline knows
		/// that the acceleration structure will no longer be updated, it can make the structure more compact. Some apps may benefit from
		/// compacting twice - once after the initial build, and again after the acceleration structure has settled to a static state, if
		/// that occurs. </note>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_COMPACTION = 0x2,

		/// <summary>
		/// <para>Value: 0x4 
		/// Construct a high quality acceleration structure that maximizes raytracing performance at the expense of additional build time.
		/// Typically, the implementation will take 2-3 times the build time than the default setting in order to get better tracing performance.
		/// </para>
		/// <para>This flag is recommended for static geometry in particular. It is compatible with all other flags except for D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PREFER_FAST_BUILD.</para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PREFER_FAST_TRACE = 0x4,

		/// <summary>
		/// <para>Value: 0x8 
		/// Construct a lower quality acceleration structure, trading raytracing performance for build speed. Typically, the implementation
		/// will take 1/2 to 1/3 the build time than default setting, with a sacrifice in tracing performance.
		/// </para>
		/// <para>This flag is compatible with all other flags except for D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PREFER_FAST_BUILD.</para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PREFER_FAST_BUILD = 0x8,

		/// <summary>
		/// <para>Value: 0x10 
		/// Minimize the amount of scratch memory used during the acceleration structure build as well as the size of the result. This
		/// option may result in increased build times and/or raytracing times. This is orthogonal to the
		/// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_COMPACTION flag and the explicit acceleration structure compaction that
		/// it enables. Combining the flags can mean both the initial acceleration structure as well as the result of compacting it use less memory.
		/// </para>
		/// <para>
		/// The impact of using this flag for a build is reflected in the result of calling GetRaytracingAccelerationStructurePrebuildInfo
		/// before doing the build to retrieve memory requirements for the build.
		/// </para>
		/// <para>This flag is compatible with all other flags.</para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_MINIMIZE_MEMORY = 0x10,

		/// <summary>
		/// <para>Value: 0x20 
		/// Perform an acceleration structure update, as opposed to building from scratch. This is faster than a full build, but can
		/// negatively impact raytracing performance, especially if the positions of the underlying objects have changed significantly from
		/// the original build of the acceleration structure before updates.
		/// </para>
		/// <para>
		/// If the addresses of the source and destination acceleration structures are identical, the update is performed in-place. Any
		/// other overlapping of address ranges of the source and destination is invalid. For non-overlapping source and destinations, the
		/// source acceleration structure is unmodified. The memory requirement for the output acceleration structure is the same as in the
		/// input acceleration structure
		/// </para>
		/// <para>The source acceleration structure must have been built with D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_UPDATE.</para>
		/// <para>
		/// This flag is compatible with all other flags. The other flags selections, aside from
		/// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_UPDATE and
		/// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PERFORM_UPDATE, must match the flags in the source acceleration structure.
		/// </para>
		/// <para>
		/// Acceleration structure updates can be performed in unlimited succession, as long as the source acceleration structure was
		/// created with D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_UPDATE and the flags for the update build continue to
		/// specify D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_UPDATE.
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PERFORM_UPDATE = 0x20,
	}

	/// <summary>Specifies the type of copy operation performed when calling <c>CopyRaytracingAccelerationStructure</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_raytracing_acceleration_structure_copy_mode typedef enum
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE { D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_CLONE = 0,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_COMPACT = 0x1,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_VISUALIZATION_DECODE_FOR_TOOLS = 0x2,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_SERIALIZE = 0x3, D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_DESERIALIZE =
	// 0x4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE")]
	public enum D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE
	{
		/// <summary>
		/// <para>Value: 0 
		/// Copy an acceleration structure while fixing any self-referential pointers that may be present so that the destination is a
		/// self-contained copy of the source. Any external pointers to other acceleration structures remain unchanged from source to
		/// destination in the copy. The size of the destination is identical to the size of the source.
		/// </para>
		/// <para>
		/// <para>IMPORTANT</para>
		/// <para>
		/// The source memory must be in state <c><b>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</b></c>.The destination memory
		/// must be in state <c><b>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</b></c>.
		/// </para>
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_CLONE,

		/// <summary>
		/// <para>Value: 0x1 
		/// Produces a functionally equivalent acceleration structure to source in the destination, similar to the clone mode, but also fits
		/// the destination into a potentially smaller, and certainly not larger, memory footprint. The size required for the destination
		/// can be retrieved beforehand from EmitRaytracingAccelerationStructurePostbuildInfo.
		/// </para>
		/// <para>
		/// This mode is only valid if the source acceleration structure was originally built with the
		/// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_COMPACTION flag, otherwise results are undefined.
		/// </para>
		/// <para>
		/// Compacting geometry requires the entire acceleration structure to be constructed, which is why you must first build and then
		/// compact the structure.
		/// </para>
		/// <para>
		/// <para>IMPORTANT</para>
		/// <para>
		/// The source memory must be in state <c><b>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</b></c>.The destination memory
		/// must be in state <c><b>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</b></c>.
		/// </para>
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_COMPACT,

		/// <summary>
		/// <para>Value: 0x2 
		/// The destination is takes the layout described in D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_TOOLS_VISUALIZATION_HEADER. The
		/// size required for the destination can be retrieved beforehand from EmitRaytracingAccelerationStructurePostbuildInfo.
		/// </para>
		/// <para>
		/// This mode is only intended for tools such as PIX, though nothing stops any app from using it. The output is essentially the
		/// inverse of an acceleration structure build. This overall structure with is sufficient for tools/PIX to be able to give the
		/// application some visual sense of the acceleration structure the driver made out of the app’s input. Visualization can help
		/// reveal driver bugs in acceleration structures if what is shown grossly mismatches the data the application used to create the
		/// acceleration structure, beyond allowed tolerances.
		/// </para>
		/// <para>
		/// For top-level acceleration structures, the output includes a set of instance descriptions that are identical to the data used in
		/// the original build and in the same order. For bottom-level acceleration structures, the output includes a set of geometry
		/// descriptions roughly matching the data used in the original build. The output is only a rough match for the original in part
		/// because of the tolerances allowed in the specification for acceleration structures and in part due to the inherent complexity of
		/// reporting exactly the same structure as is conceptually encoded. For example. axis-aligned bounding boxes (AABBs) returned for
		/// procedural primitives could be more conservative (larger) in volume and even different in number than what is actually in the
		/// acceleration structure representation. Geometries, each with its own geometry description, appear in the same order as in the
		/// original acceleration, as shader table indexing calculations depend on this.
		/// </para>
		/// <para>
		/// <para>IMPORTANT</para>
		/// <para>
		/// The source memory must be in state <c><b>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</b></c>.The destination memory
		/// must be in state <c><b>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</b></c>.This mode is only permitted when developer mode is enabled
		/// in the OS.
		/// </para>
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_VISUALIZATION_DECODE_FOR_TOOLS,

		/// <summary>
		/// <para>Value: 0x3 
		/// Destination takes the layout and size described in the documentation for
		/// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_SERIALIZATION_DESC , itself a structure generated with a call to EmitRaytracingAccelerationStructurePostbuildInfo.
		/// </para>
		/// <para>
		/// This mode serializes an acceleration structure so that an app or tools can store it to a file for later reuse, typically on a
		/// different device instance, via deserialization.
		/// </para>
		/// <para>
		/// When serializing a top-level acceleration structure, the bottom-level acceleration structures it refers to do not have to still
		/// be present or intact in memory. Likewise, bottom-level acceleration structures can be serialized independent of whether any
		/// top-level acceleration structures are pointing to them. In other words, the order of serialization of acceleration structures
		/// doesn’t matter.
		/// </para>
		/// <para>
		/// <para>IMPORTANT</para>
		/// <para>
		/// The source memory must be in state <c><b>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</b></c>.The destination memory
		/// must be in state <c><b>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</b></c>.
		/// </para>
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_SERIALIZE,

		/// <summary>
		/// <para>Value: 0x4 
		/// The source must be a serialized acceleration structure, with any pointers, directly after the header, fixed to point to their
		/// new locations. For more information, see D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_SERIALIZATION_DESC.
		/// </para>
		/// <para>
		/// The destination gets an acceleration structure that is functionally equivalent to the acceleration structure that was originally
		/// serialized. It does not matter what order top-level and bottom-level acceleration structures are deserialized, as long as by the
		/// time a top-level acceleration structure is used for raytracing or acceleration structure updates the bottom-level acceleration
		/// structures it references are present.
		/// </para>
		/// <para>
		/// Deserialization can only be performed on the same device and driver version on which the data was serialized. Otherwise, the
		/// results are undefined.
		/// </para>
		/// <para>
		/// This mode is only intended for tools such as PIX, though nothing stops any app from using it, but this mode is only permitted
		/// when developer mode is enabled in the OS. This copy operation is not intended to be used for caching acceleration structures,
		/// because running a full acceleration structure build is likely to be faster than loading one from disk.
		/// </para>
		/// <para>
		/// <para>IMPORTANT</para>
		/// <para>
		/// The source memory must be in state <c><b>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</b></c>.The destination memory must be
		/// in state <c><b>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</b></c>.
		/// </para>
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_DESERIALIZE,
	}

	/// <summary>
	/// Specifies the type of acceleration structure post-build info that can be retrieved with calls to
	/// <c>EmitRaytracingAccelerationStructurePostbuildInfo</c> and <c>BuildRaytracingAccelerationStructure</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_raytracing_acceleration_structure_postbuild_info_type
	// typedef enum D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TYPE {
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_COMPACTED_SIZE = 0,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TOOLS_VISUALIZATION = 0x1,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_SERIALIZATION = 0x2,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_CURRENT_SIZE = 0x3 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TYPE")]
	public enum D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TYPE
	{
		/// <summary>
		/// <para>Value: 0 The post-build info is space requirements for an acceleration structure after compaction. For more information, see D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_COMPACTED_SIZE_DESC.</para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_COMPACTED_SIZE,

		/// <summary>
		/// <para>Value: 0x1 
		/// The post-build info is space requirements for generating tools visualization for an acceleration structure. For more
		/// information, see D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TOOLS_VISUALIZATION_DESC.
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TOOLS_VISUALIZATION,

		/// <summary>
		/// <para>Value: 0x2 The post-build info is space requirements for serializing an acceleration structure. For more information, see D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_SERIALIZATION_DESC.</para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_SERIALIZATION,

		/// <summary>
		/// <para>Value: 0x3 The post-build info is size of the current acceleration structure. For more information, see D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_CURRENT_SIZE_DESC.</para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_CURRENT_SIZE,
	}

	/// <summary>Specifies the type of a raytracing acceleration structure.</summary>
	/// <remarks>
	/// Bottom-level acceleration structures each consist of a set of geometries that are building blocks for a scene. A top-level
	/// acceleration structure represents a set of instances of bottom-level acceleration structures.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_raytracing_acceleration_structure_type typedef enum
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE { D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE_TOP_LEVEL = 0,
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE_BOTTOM_LEVEL = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE")]
	public enum D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE
	{
		/// <summary>
		/// <para>Value: 0 Top-level acceleration structure.</para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE_TOP_LEVEL,

		/// <summary>
		/// <para>Value: 0x1 Bottom-level acceleration structure.</para>
		/// </summary>
		D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE_BOTTOM_LEVEL,
	}

	/// <summary>Specifies flags for raytracing geometry in a <c>D3D12_RAYTRACING_GEOMETRY_DESC</c> structure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_raytracing_geometry_flags typedef enum
	// D3D12_RAYTRACING_GEOMETRY_FLAGS { D3D12_RAYTRACING_GEOMETRY_FLAG_NONE = 0, D3D12_RAYTRACING_GEOMETRY_FLAG_OPAQUE = 0x1,
	// D3D12_RAYTRACING_GEOMETRY_FLAG_NO_DUPLICATE_ANYHIT_INVOCATION = 0x2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RAYTRACING_GEOMETRY_FLAGS")]
	[Flags]
	public enum D3D12_RAYTRACING_GEOMETRY_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No options specified.</para>
		/// </summary>
		D3D12_RAYTRACING_GEOMETRY_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 
		/// When rays encounter this geometry, the geometry acts as if no any hit shader is present. It is recommended that apps use this
		/// flag liberally, as it can enable important ray-processing optimizations. Note that this behavior can be overridden on a
		/// per-instance basis with D3D12_RAYTRACING_INSTANCE_FLAGS and on a per-ray basis using ray flags in TraceRay.
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_GEOMETRY_FLAG_OPAQUE = 0x1,

		/// <summary>
		/// <para>Value: 0x2 
		/// By default, the system is free to trigger an any hit shader more than once for a given ray-primitive intersection. This
		/// flexibility helps improve the traversal efficiency of acceleration structures in certain cases. For instance, if the
		/// acceleration structure is implemented internally with bounding volumes, the implementation may find it beneficial to store
		/// relatively long triangles in multiple bounding boxes rather than a larger single box. However, some application use cases
		/// require that intersections be reported to the any hit shader at most once. This flag enables that guarantee for the given
		/// geometry, potentially with some performance impact.
		/// </para>
		/// <para>This flag applies to all geometry types.</para>
		/// </summary>
		D3D12_RAYTRACING_GEOMETRY_FLAG_NO_DUPLICATE_ANYHIT_INVOCATION = 0x2,
	}

	/// <summary>
	/// Specifies the type of geometry used for raytracing. Use a value from this enumeration to specify the geometry type in a <c>D3D12_RAYTRACING_GEOMETRY_DESC</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_raytracing_geometry_type typedef enum
	// D3D12_RAYTRACING_GEOMETRY_TYPE { D3D12_RAYTRACING_GEOMETRY_TYPE_TRIANGLES = 0,
	// D3D12_RAYTRACING_GEOMETRY_TYPE_PROCEDURAL_PRIMITIVE_AABBS } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RAYTRACING_GEOMETRY_TYPE")]
	public enum D3D12_RAYTRACING_GEOMETRY_TYPE
	{
		/// <summary>
		/// <para>Value: 0 The geometry consists of triangles.</para>
		/// </summary>
		D3D12_RAYTRACING_GEOMETRY_TYPE_TRIANGLES,

		/// <summary>
		/// The geometry procedurally is defined during raytracing by intersection shaders. For the purpose of acceleration structure
		/// builds, the geometry’s bounds are described with axis-aligned bounding boxes using the D3D12_RAYTRACING_GEOMETRY_AABBS_DESC structure.
		/// </summary>
		D3D12_RAYTRACING_GEOMETRY_TYPE_PROCEDURAL_PRIMITIVE_AABBS,
	}

	/// <summary>
	/// Flags for a raytracing acceleration structure instance. These flags can be used to override <c>D3D12_RAYTRACING_GEOMETRY_FLAGS</c>
	/// for individual instances.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_raytracing_instance_flags typedef enum
	// D3D12_RAYTRACING_INSTANCE_FLAGS { D3D12_RAYTRACING_INSTANCE_FLAG_NONE = 0, D3D12_RAYTRACING_INSTANCE_FLAG_TRIANGLE_CULL_DISABLE =
	// 0x1, D3D12_RAYTRACING_INSTANCE_FLAG_TRIANGLE_FRONT_COUNTERCLOCKWISE = 0x2, D3D12_RAYTRACING_INSTANCE_FLAG_FORCE_OPAQUE = 0x4,
	// D3D12_RAYTRACING_INSTANCE_FLAG_FORCE_NON_OPAQUE = 0x8 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RAYTRACING_INSTANCE_FLAGS")]
	[Flags]
	public enum D3D12_RAYTRACING_INSTANCE_FLAGS : byte
	{
		/// <summary>
		/// <para>Value: 0 No options specified.</para>
		/// </summary>
		D3D12_RAYTRACING_INSTANCE_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 
		/// Disables front/back face culling for this instance. The Ray flags RAY_FLAG_CULL_BACK_FACING_TRIANGLES and
		/// RAY_FLAG_CULL_FRONT_FACING_TRIANGLES will have no effect on this instance.
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_INSTANCE_FLAG_TRIANGLE_CULL_DISABLE = 0x1,

		/// <summary>
		/// <para>Value: 0x2 
		/// This flag reverses front and back facings, which is useful if the application’s natural winding order differs from the default.
		/// By default, a triangle is front facing if its vertices appear clockwise from the ray origin and back facing if its vertices
		/// appear counter-clockwise from the ray origin, in object space in a left-handed coordinate system.
		/// </para>
		/// <para>
		/// Since these winding direction rules are defined in object space, they are unaffected by instance transforms. For example, an
		/// instance transform matrix with negative determinant (e.g. mirroring some geometry) does not change the facing of the triangles
		/// within the instance. Per-geometry transforms defined in D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC , by contrast, get combined
		/// with the associated vertex data in object space, so a negative determinant matrix there does flip triangle winding.
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_INSTANCE_FLAG_TRIANGLE_FRONT_COUNTERCLOCKWISE = 0x2,

		/// <summary>
		/// <para>Value: 0x4 
		/// The instance will act as if D3D12_RAYTRACING_GEOMETRY_FLAG_OPAQUE had been specified for all the geometries in the bottom-level
		/// acceleration structure referenced by the instance. Note that this behavior can be overridden by the ray flag RAY_FLAG_FORCE_NON_OPAQUE.
		/// </para>
		/// <para>This flag is mutually exclusive to the D3D12_RAYTRACING_INSTANCE_FLAG_FORCE_NON_OPAQUE flag.</para>
		/// </summary>
		D3D12_RAYTRACING_INSTANCE_FLAG_FORCE_OPAQUE = 0x4,

		/// <summary>
		/// <para>Value: 0x8 
		/// The instance will act as if D3D12_RAYTRACING_GEOMETRY_FLAG_OPAQUE had not been specified for any of the geometries in the
		/// bottom-level acceleration structure referenced by the instance. Note that this behavior can be overridden by the ray flag RAY_FLAG_FORCE_OPAQUE.
		/// </para>
		/// <para>This flag is mutually exclusive to the D3D12_RAYTRACING_INSTANCE_FLAG_FORCE_OPAQUE flag.</para>
		/// </summary>
		D3D12_RAYTRACING_INSTANCE_FLAG_FORCE_NON_OPAQUE = 0x8,
	}

	/// <summary>Defines constants that specify configuration flags for a raytracing pipeline.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_raytracing_pipeline_flags typedef enum
	// D3D12_RAYTRACING_PIPELINE_FLAGS { D3D12_RAYTRACING_PIPELINE_FLAG_NONE = 0, D3D12_RAYTRACING_PIPELINE_FLAG_SKIP_TRIANGLES = 0x100,
	// D3D12_RAYTRACING_PIPELINE_FLAG_SKIP_PROCEDURAL_PRIMITIVES = 0x200 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RAYTRACING_PIPELINE_FLAGS")]
	[Flags]
	public enum D3D12_RAYTRACING_PIPELINE_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Specifies no option.</para>
		/// </summary>
		D3D12_RAYTRACING_PIPELINE_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x100 
		/// Specifies that for any TraceRay call within this raytracing pipeline, the RAY_FLAG_SKIP_TRIANGLES ray flag should be added in.
		/// The resulting combination of ray flags must be valid. The presence of this flag in a raytracing pipeline config doesn't show up
		/// in a RayFlags call from a shader. Implementations might be able to optimize pipelines knowing that a particular primitive type
		/// need not be considered.
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_PIPELINE_FLAG_SKIP_TRIANGLES = 0x1,

		/// <summary>
		/// <para>Value: 0x200 
		/// Specifies that for any TraceRay call within this raytracing pipeline, the RAY_FLAG_SKIP_PROCEDURAL_PRIMITIVES ray flag should be
		/// added in.
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_PIPELINE_FLAG_SKIP_PROCEDURAL_PRIMITIVES = 0x2,
	}

	/// <summary>Specifies the level of ray tracing support on the graphics device.</summary>
	/// <remarks>To determine the supported ray tracing tier for a graphics device, pass <c>D3D12_FEATURE_DATA_D3D12_OPTIONS5</c> struct.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_raytracing_tier typedef enum D3D12_RAYTRACING_TIER {
	// D3D12_RAYTRACING_TIER_NOT_SUPPORTED = 0, D3D12_RAYTRACING_TIER_1_0 = 10, D3D12_RAYTRACING_TIER_1_1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RAYTRACING_TIER")]
	public enum D3D12_RAYTRACING_TIER
	{
		/// <summary>
		/// <para>Value: 0 
		/// No support for ray tracing on the device. Attempts to create any ray tracing-related object will fail, and using ray
		/// tracing-related APIs on command lists results in undefined behavior.
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_TIER_NOT_SUPPORTED = 0,

		/// <summary>
		/// <para>Value: 10 
		/// The device supports tier 1 ray tracing functionality. In the current release, this tier represents all available ray tracing features.
		/// </para>
		/// </summary>
		D3D12_RAYTRACING_TIER_1_0 = 10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// </summary>
		D3D12_RAYTRACING_TIER_1_1 = 11
	}

	/// <summary>
	/// Specifies the type of access that an application is given to the specified resource(s) at the transition into a render pass.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_render_pass_beginning_access_type typedef enum
	// D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE { D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_DISCARD = 0,
	// D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_PRESERVE, D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_CLEAR,
	// D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_NO_ACCESS, D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_PRESERVE_LOCAL_RENDER,
	// D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_PRESERVE_LOCAL_SRV, D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_PRESERVE_LOCAL_UAV } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE")]
	public enum D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE
	{
		/// <summary>
		/// <para>Value: 0 
		/// Indicates that your application doesn't have any dependency on the prior contents of the resource(s). You also shouldn't have
		/// any expectations about those contents, because a display driver may return the previously-written contents, or it may return
		/// uninitialized data. You can be assured that reading from the resource(s) won't hang the GPU, even if you do get undefined data back.
		/// </para>
		/// <para>
		/// A read is defined as a traditional read from an unordered access view (UAV), a shader resource view (SRV), a constant buffer
		/// view (CBV), a vertex buffer view (VBV), an index buffer view (IBV), an IndirectArg binding/read, or a
		/// blend/depth-testing-induced read.
		/// </para>
		/// </summary>
		D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_DISCARD = 0,

		/// <summary>
		/// Indicates that your application has a dependency on the prior contents of the resource(s), so the contents must be loaded from
		/// main memory.
		/// </summary>
		D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_PRESERVE,

		/// <summary>
		/// Indicates that your application needs the resource(s) to be cleared to a specific value (a value that your application
		/// specifies). This clear occurs whether or not you interact with the resource(s) during the render pass. You specify the clear
		/// value at BeginRenderPass time, in the Clear member of your D3D12_RENDER_PASS_BEGINNING_ACCESS structure.
		/// </summary>
		D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_CLEAR,

		/// <summary>
		/// Indicates that your application will neither read from nor write to the resource(s) during the render pass. You would most
		/// likely use this value to indicate that you won't be accessing the depth/stencil plane for a depth/stencil view (DSV). You must
		/// pair this value with D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_NO_ACCESS in the corresponding D3D12_RENDER_PASS_ENDING_ACCESS structure.
		/// </summary>
		D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_NO_ACCESS,
	}

	/// <summary>
	/// Specifies the type of access that an application is given to the specified resource(s) at the transition out of a render pass.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_render_pass_ending_access_type typedef enum
	// D3D12_RENDER_PASS_ENDING_ACCESS_TYPE { D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_DISCARD = 0,
	// D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_PRESERVE, D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_RESOLVE,
	// D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_NO_ACCESS, D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_PRESERVE_LOCAL_RENDER,
	// D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_PRESERVE_LOCAL_SRV, D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_PRESERVE_LOCAL_UAV } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RENDER_PASS_ENDING_ACCESS_TYPE")]
	public enum D3D12_RENDER_PASS_ENDING_ACCESS_TYPE
	{
		/// <summary>
		/// <para>Value: 0 
		/// Indicates that your application won't have any future dependency on any data that you wrote to the resource(s) during this
		/// render pass. For example, a depth buffer that won't be textured from before it's written to again.
		/// </para>
		/// </summary>
		D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_DISCARD = 0,

		/// <summary>
		/// Indicates that your application will have a dependency on the written contents of the resource(s) in the future, and so they
		/// must be preserved.
		/// </summary>
		D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_PRESERVE,

		/// <summary>
		/// Indicates that the resource(s)—for example, a multi-sample anti-aliasing (MSAA) surface—should be directly resolved to a
		/// separate resource at the conclusion of the render pass. For a tile-based deferred renderer (TBDR), this should ideally happen
		/// while the MSAA contents are still in the tile cache. You should ensure that the resolve destination is in the
		/// D3D12_RESOURCE_STATE_RESOLVE_DEST resource state when the render pass ends. The resolve source is left in its initial resource
		/// state at the time the render pass ends. A resolve operation submitted by a render pass doesn't implicitly change the state of
		/// any resource.
		/// </summary>
		D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_RESOLVE,

		/// <summary>
		/// Indicates that your application will neither read from nor write to the resource(s) during the render pass. You would most
		/// likely use this value to indicate that you won't be accessing the depth/stencil plane for a depth/stencil view (DSV). You must
		/// pair this value with D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_NO_ACCESS in the corresponding D3D12_RENDER_PASS_BEGINNING_ACCESS structure.
		/// </summary>
		D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_NO_ACCESS,
	}

	/// <summary>Specifies the nature of the render pass; for example, whether it is a suspending or a resuming render pass.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_render_pass_flags typedef enum D3D12_RENDER_PASS_FLAGS {
	// D3D12_RENDER_PASS_FLAG_NONE = 0, D3D12_RENDER_PASS_FLAG_ALLOW_UAV_WRITES = 0x1, D3D12_RENDER_PASS_FLAG_SUSPENDING_PASS = 0x2,
	// D3D12_RENDER_PASS_FLAG_RESUMING_PASS = 0x4, D3D12_RENDER_PASS_FLAG_BIND_READ_ONLY_DEPTH,
	// D3D12_RENDER_PASS_FLAG_BIND_READ_ONLY_STENCIL } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RENDER_PASS_FLAGS")]
	[Flags]
	public enum D3D12_RENDER_PASS_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Indicates that the render pass has no special requirements.</para>
		/// </summary>
		D3D12_RENDER_PASS_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 Indicates that writes to unordered access view(s) should be allowed during the render pass.</para>
		/// </summary>
		D3D12_RENDER_PASS_FLAG_ALLOW_UAV_WRITES = 0x1,

		/// <summary>
		/// <para>Value: 0x2 Indicates that this is a suspending render pass.</para>
		/// </summary>
		D3D12_RENDER_PASS_FLAG_SUSPENDING_PASS = 0x2,

		/// <summary>
		/// <para>Value: 0x4 Indicates that this is a resuming render pass.</para>
		/// </summary>
		D3D12_RENDER_PASS_FLAG_RESUMING_PASS = 0x4,
	}

	/// <summary>Specifies the level of support for render passes on a graphics device.</summary>
	/// <remarks>
	/// To determine the level of support for render passes for a graphics device, pass <c>D3D12_FEATURE_DATA_D3D12_OPTIONS5</c> struct.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_render_pass_tier typedef enum D3D12_RENDER_PASS_TIER {
	// D3D12_RENDER_PASS_TIER_0 = 0, D3D12_RENDER_PASS_TIER_1 = 1, D3D12_RENDER_PASS_TIER_2 = 2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RENDER_PASS_TIER")]
	public enum D3D12_RENDER_PASS_TIER
	{
		/// <summary>
		/// <para>Value: 0 
		/// The user-mode display driver hasn't implemented render passes, and so the feature is provided only via software emulation.
		/// Render passes might not provide a performance advantage at this level of support.
		/// </para>
		/// </summary>
		D3D12_RENDER_PASS_TIER_0,

		/// <summary>
		/// <para>Value: 1 
		/// The render passes feature is implemented by the user-mode display driver, and render target/depth buffer writes may be
		/// accelerated. Unordered access view (UAV) writes are not efficiently supported within the render pass.
		/// </para>
		/// </summary>
		D3D12_RENDER_PASS_TIER_1,

		/// <summary>
		/// <para>Value: 2 
		/// The render passes feature is implemented by the user-mode display driver, render target/depth buffer writes may be accelerated,
		/// and unordered access view (UAV) writes (provided that writes in a render pass are not read until a subsequent render pass) are
		/// likely to be more efficient than issuing the same work without using a render pass.
		/// </para>
		/// </summary>
		D3D12_RENDER_PASS_TIER_2,
	}

	/// <summary>Used with the EnqueuMakeResident function to choose how residency operations proceed when the memory budget is exceeded.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_residency_flags typedef enum D3D12_RESIDENCY_FLAGS {
	// D3D12_RESIDENCY_FLAG_NONE = 0, D3D12_RESIDENCY_FLAG_DENY_OVERBUDGET = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESIDENCY_FLAGS")]
	[Flags]
	public enum D3D12_RESIDENCY_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 
		/// Specifies the default residency policy, which allows residency operations to succeed regardless of the application's current
		/// memory budget. EnqueueMakeResident returns E_OUTOFMEMORY only when there is no memory available.
		/// </para>
		/// </summary>
		D3D12_RESIDENCY_FLAG_NONE,

		/// <summary>
		/// <para>Value: 0x1 
		/// Specifies that the EnqueueMakeResident function should return E_OUTOFMEMORY when the residency operation would exceed the
		/// application's current memory budget.
		/// </para>
		/// </summary>
		D3D12_RESIDENCY_FLAG_DENY_OVERBUDGET,
	}

	/// <summary>
	/// <para>Specifies broad residency priority buckets useful for quickly establishing an application priority scheme.</para>
	/// <para>Applications can assign priority values other than the five values present in this enumeration.</para>
	/// </summary>
	/// <remarks>This enum is used by the <c>SetResidencyPriority</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_residency_priority typedef enum D3D12_RESIDENCY_PRIORITY {
	// D3D12_RESIDENCY_PRIORITY_MINIMUM = 0x28000000, D3D12_RESIDENCY_PRIORITY_LOW = 0x50000000, D3D12_RESIDENCY_PRIORITY_NORMAL =
	// 0x78000000, D3D12_RESIDENCY_PRIORITY_HIGH = 0xa0010000, D3D12_RESIDENCY_PRIORITY_MAXIMUM = 0xc8000000 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESIDENCY_PRIORITY")]
	public enum D3D12_RESIDENCY_PRIORITY : uint
	{
		/// <summary>
		/// <para>Value: 0x28000000 Indicates a minimum priority.</para>
		/// </summary>
		D3D12_RESIDENCY_PRIORITY_MINIMUM = 0x28000000,

		/// <summary>
		/// <para>Value: 0x50000000 Indicates a low priority.</para>
		/// </summary>
		D3D12_RESIDENCY_PRIORITY_LOW = 0x50000000,

		/// <summary>
		/// <para>Value: 0x78000000 Indicates a normal, medium, priority.</para>
		/// </summary>
		D3D12_RESIDENCY_PRIORITY_NORMAL = 0x78000000,

		/// <summary>
		/// <para>Value: 0xa0010000 
		/// Indicates a high priority. Applications are discouraged from using priories greater than this. For more information see ID3D12Device1::SetResidencyPriority.
		/// </para>
		/// </summary>
		D3D12_RESIDENCY_PRIORITY_HIGH = 0xa0010000,

		/// <summary>
		/// <para>Value: 0xc8000000 
		/// Indicates a maximum priority. Applications are discouraged from using priorities greater than this;
		/// D3D12_RESIDENCY_PRIORITY_MAXIMUM is not guaranteed to be available. For more information see ID3D12Device1::SetResidencyPriority
		/// </para>
		/// </summary>
		D3D12_RESIDENCY_PRIORITY_MAXIMUM = 0xc8000000,
	}

	/// <summary>Specifies a resolve operation.</summary>
	/// <remarks>This enum is used by the <c>ID3D12GraphicsCommandList1::ResolveSubresourceRegion</c> function.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resolve_mode typedef enum D3D12_RESOLVE_MODE {
	// D3D12_RESOLVE_MODE_DECOMPRESS = 0, D3D12_RESOLVE_MODE_MIN = 1, D3D12_RESOLVE_MODE_MAX = 2, D3D12_RESOLVE_MODE_AVERAGE = 3,
	// D3D12_RESOLVE_MODE_ENCODE_SAMPLER_FEEDBACK, D3D12_RESOLVE_MODE_DECODE_SAMPLER_FEEDBACK } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESOLVE_MODE")]
	public enum D3D12_RESOLVE_MODE
	{
		/// <summary>
		/// <para>Value: 0 
		/// Resolves compressed source samples to their uncompressed values. When using this operation, the source and destination resources
		/// must have the same sample count, unlike the min, max, and average operations that require the destination to have a sample count
		/// of 1.
		/// </para>
		/// </summary>
		D3D12_RESOLVE_MODE_DECOMPRESS,

		/// <summary>
		/// <para>Value: 1 Resolves the source samples to their minimum value. It can be used with any render target or depth stencil format.</para>
		/// </summary>
		D3D12_RESOLVE_MODE_MIN,

		/// <summary>
		/// <para>Value: 2 Resolves the source samples to their maximum value. It can be used with any render target or depth stencil format.</para>
		/// </summary>
		D3D12_RESOLVE_MODE_MAX,

		/// <summary>
		/// <para>Value: 3 
		/// Resolves the source samples to their average value. It can be used with any non-integer render target format, including the
		/// depth plane. It can't be used with integer render target formats, including the stencil plane.
		/// </para>
		/// </summary>
		D3D12_RESOLVE_MODE_AVERAGE,
	}

	/// <summary>Flags for setting split resource barriers.</summary>
	/// <remarks>
	/// <para>Split barriers allow a single transition to be split into begin and end halves (refer to <c>Multi-engine synchronization</c>).</para>
	/// <para>This enum is used by the <i>Flags</i> member of the <c>D3D12_RESOURCE_BARRIER</c> structure.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_barrier_flags typedef enum
	// D3D12_RESOURCE_BARRIER_FLAGS { D3D12_RESOURCE_BARRIER_FLAG_NONE = 0, D3D12_RESOURCE_BARRIER_FLAG_BEGIN_ONLY = 0x1,
	// D3D12_RESOURCE_BARRIER_FLAG_END_ONLY = 0x2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESOURCE_BARRIER_FLAGS")]
	[Flags]
	public enum D3D12_RESOURCE_BARRIER_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No flags.</para>
		/// </summary>
		D3D12_RESOURCE_BARRIER_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 This starts a barrier transition in a new state, putting a resource in a temporary no-access condition.</para>
		/// </summary>
		D3D12_RESOURCE_BARRIER_FLAG_BEGIN_ONLY = 0x1,

		/// <summary>
		/// <para>Value: 0x2 This barrier completes a transition, setting a new state and restoring active access to a resource.</para>
		/// </summary>
		D3D12_RESOURCE_BARRIER_FLAG_END_ONLY = 0x2,
	}

	/// <summary>Specifies a type of resource barrier (transition in resource use) description.</summary>
	/// <remarks>
	/// This enum is used in the <b>D3D12_RESOURCE_BARRIER_TYPE</b> structure. Use these values with the
	/// <c>ID3D12GraphicsCommandList::ResourceBarrier</c> method.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_barrier_type typedef enum
	// D3D12_RESOURCE_BARRIER_TYPE { D3D12_RESOURCE_BARRIER_TYPE_TRANSITION = 0, D3D12_RESOURCE_BARRIER_TYPE_ALIASING,
	// D3D12_RESOURCE_BARRIER_TYPE_UAV } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESOURCE_BARRIER_TYPE")]
	public enum D3D12_RESOURCE_BARRIER_TYPE
	{
		/// <summary>
		/// <para>Value: 0 
		/// A transition barrier that indicates a transition of a set of subresources between different usages. The caller must specify the
		/// before and after usages of the subresources.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_BARRIER_TYPE_TRANSITION,

		/// <summary>
		/// An aliasing barrier that indicates a transition between usages of 2 different resources that have mappings into the same tile
		/// pool. The caller can specify both the before and the after resource. Note that one or both resources can be NULL, which
		/// indicates that any tiled resource could cause aliasing.
		/// </summary>
		D3D12_RESOURCE_BARRIER_TYPE_ALIASING,

		/// <summary>
		/// An unordered access view (UAV) barrier that indicates all UAV accesses (reads or writes) to a particular resource must complete
		/// before any future UAV accesses (read or write) can begin.
		/// </summary>
		D3D12_RESOURCE_BARRIER_TYPE_UAV,
	}

	/// <summary>Identifies the tier of resource binding being used.</summary>
	/// <remarks>This enum is used by the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_binding_tier typedef enum
	// D3D12_RESOURCE_BINDING_TIER { D3D12_RESOURCE_BINDING_TIER_1 = 1, D3D12_RESOURCE_BINDING_TIER_2 = 2, D3D12_RESOURCE_BINDING_TIER_3 = 3
	// } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESOURCE_BINDING_TIER")]
	public enum D3D12_RESOURCE_BINDING_TIER
	{
		/// <summary>
		/// <para>Value: 1 Tier 1.</para>
		/// <para>See Hardware Tiers.</para>
		/// </summary>
		D3D12_RESOURCE_BINDING_TIER_1 = 1,

		/// <summary>
		/// <para>Value: 2 Tier 2.</para>
		/// <para>See Hardware Tiers.</para>
		/// </summary>
		D3D12_RESOURCE_BINDING_TIER_2,

		/// <summary>
		/// <para>Value: 3 Tier 3.</para>
		/// <para>See Hardware Tiers.</para>
		/// </summary>
		D3D12_RESOURCE_BINDING_TIER_3,
	}

	/// <summary>Identifies the type of resource being used.</summary>
	/// <remarks>This enum is used by the <c>D3D12_RESOURCE_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_dimension typedef enum D3D12_RESOURCE_DIMENSION {
	// D3D12_RESOURCE_DIMENSION_UNKNOWN = 0, D3D12_RESOURCE_DIMENSION_BUFFER = 1, D3D12_RESOURCE_DIMENSION_TEXTURE1D = 2,
	// D3D12_RESOURCE_DIMENSION_TEXTURE2D = 3, D3D12_RESOURCE_DIMENSION_TEXTURE3D = 4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESOURCE_DIMENSION")]
	public enum D3D12_RESOURCE_DIMENSION
	{
		/// <summary>
		/// <para>Value: 0 Resource is of unknown type.</para>
		/// </summary>
		D3D12_RESOURCE_DIMENSION_UNKNOWN,

		/// <summary>
		/// <para>Value: 1 Resource is a buffer.</para>
		/// </summary>
		D3D12_RESOURCE_DIMENSION_BUFFER,

		/// <summary>
		/// <para>Value: 2 Resource is a 1D texture.</para>
		/// </summary>
		D3D12_RESOURCE_DIMENSION_TEXTURE1D,

		/// <summary>
		/// <para>Value: 3 Resource is a 2D texture.</para>
		/// </summary>
		D3D12_RESOURCE_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value: 4 Resource is a 3D texture.</para>
		/// </summary>
		D3D12_RESOURCE_DIMENSION_TEXTURE3D,
	}

	/// <summary>Defines constants that specify options for working with resources.</summary>
	/// <remarks>This enum is used by the Flags member of the <c>D3D12_RESOURCE_DESC</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_flags typedef enum D3D12_RESOURCE_FLAGS {
	// D3D12_RESOURCE_FLAG_NONE = 0, D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET = 0x1, D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL = 0x2,
	// D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS = 0x4, D3D12_RESOURCE_FLAG_DENY_SHADER_RESOURCE = 0x8,
	// D3D12_RESOURCE_FLAG_ALLOW_CROSS_ADAPTER = 0x10, D3D12_RESOURCE_FLAG_ALLOW_SIMULTANEOUS_ACCESS = 0x20,
	// D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY = 0x40, D3D12_RESOURCE_FLAG_VIDEO_ENCODE_REFERENCE_ONLY = 0x80,
	// D3D12_RESOURCE_FLAG_RAYTRACING_ACCELERATION_STRUCTURE = 0x100 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESOURCE_FLAGS")]
	[Flags]
	public enum D3D12_RESOURCE_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No options are specified.</para>
		/// </summary>
		D3D12_RESOURCE_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 
		/// Allows a render target view to be created for the resource; and also enables the resource to transition into the state of
		/// D3D12_RESOURCE_STATE_RENDER_TARGET. Some adapter architectures allocate extra memory for textures with this flag to reduce the
		/// effective bandwidth during common rendering. This characteristic may not be beneficial for textures that are never rendered to,
		/// nor is it available for textures compressed with BC formats. Your application should avoid setting this flag when rendering will
		/// never occur.
		/// </para>
		/// <para>The following restrictions and interactions apply:</para>
		/// <list type="bullet">
		/// <item>
		/// Either the texture format must support render target capabilities at the current feature level. Or, when the format is a
		/// typeless format, a format within the same typeless group must support render target capabilities at the current feature level.
		/// </item>
		/// <item>
		/// Can't be set in conjunction with textures that have <c>D3D12_TEXTURE_LAYOUT_ROW_MAJOR</c> when
		/// <c>D3D12_FEATURE_DATA_D3D12_OPTIONS::CrossAdapterRowMajorTextureSupported</c> is <c>FALSE</c>, nor in conjunction with textures
		/// that have <c>D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE</c> when
		/// <c>D3D12_FEATURE_DATA_D3D12_OPTIONS::StandardSwizzle64KBSupported</c> is <c>FALSE</c>.
		/// </item>
		/// <item>
		/// Can't be used with 4KB alignment, <b>D3D12_RESOURCE_FLAGS::D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>, nor usage with heaps
		/// that have <c>D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES</c>.
		/// </item>
		/// </list>
		/// </summary>
		D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET = 0x1,

		/// <summary>
		/// <para>Value: 0x2 
		/// Allows a depth stencil view to be created for the resource, as well as enables the resource to transition into the state of
		/// D3D12_RESOURCE_STATE_DEPTH_WRITE and/or D3D12_RESOURCE_STATE_DEPTH_READ. Most adapter architectures allocate extra memory for
		/// textures with this flag to reduce the effective bandwidth, and maximize optimizations for early depth-test. Your application
		/// should avoid setting this flag when depth operations will never occur.
		/// </para>
		/// <para>The following restrictions and interactions apply:</para>
		/// <list type="bullet">
		/// <item>
		/// Either the texture format must support depth stencil capabilities at the current feature level. Or, when the format is a
		/// typeless format, a format within the same typeless group must support depth stencil capabilities at the current feature level.
		/// </item>
		/// <item>
		/// Can't be used with <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, 4KB alignment,
		/// <b>D3D12_RESOURCE_FLAGS::D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</b>,
		/// <b>D3D12_RESOURCE_FLAGS::D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS</b>,
		/// <b>D3D12_RESOURCE_FLAGS::D3D12_RESOURCE_FLAG_ALLOW_SIMULTANEOUS_ACCESS</b>, <c>D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE</c>,
		/// <b>D3D12_TEXTURE_LAYOUT_ROW_MAJOR</b>, nor used with heaps that have <c>D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES</c> or <b>D3D12_HEAP_FLAG_ALLOW_DISPLAY</b>.
		/// </item>
		/// <item>Precludes usage of <c>WriteToSubresource</c> and <c>ReadFromSubresource</c>.</item>
		/// <item>
		/// Precludes GPU copying of a subregion. <c>CopyTextureRegion</c> must copy a whole subresource to or from resources with this flag.
		/// </item>
		/// </list>
		/// </summary>
		D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL = 0x2,

		/// <summary>
		/// <para>Value: 0x4 
		/// Allows an unordered access view to be created for the resource, as well as enables the resource to transition into the state of
		/// D3D12_RESOURCE_STATE_UNORDERED_ACCESS. Some adapter architectures must resort to less efficient texture layouts in order to
		/// provide this functionality. If a texture is rarely used for unordered access, then it might be worth having two textures around
		/// and copying between them. One texture would have this flag, while the other wouldn't. Your application should avoid setting this
		/// flag when unordered access operations will never occur.
		/// </para>
		/// <para>The following restrictions and interactions apply:</para>
		/// <list type="bullet">
		/// <item>
		/// Either the texture format must support unordered access capabilities at the current feature level. Or, when the format is a
		/// typeless format, a format within the same typeless group must support unordered access capabilities at the current feature level.
		/// </item>
		/// <item>
		/// Can't be set in conjunction with textures that have <c>D3D12_TEXTURE_LAYOUT_ROW_MAJOR</c> when
		/// <c>D3D12_FEATURE_DATA_D3D12_OPTIONS::CrossAdapterRowMajorTextureSupported</c> is <c>FALSE</c>, nor in conjunction with textures
		/// that have <c>D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE</c> when
		/// <c>D3D12_FEATURE_DATA_D3D12_OPTIONS::StandardSwizzle64KBSupported</c> is <c>FALSE</c>, nor when the feature level is less than 11.0.
		/// </item>
		/// <item>Can't be used with MSAA textures.</item>
		/// </list>
		/// </summary>
		D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS = 0x4,

		/// <summary>
		/// <para>Value: 0x8 
		/// Disallows a shader resource view from being created for the resource, as well as disables the resource from transitioning into
		/// the state of D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE or D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE. Some adapter
		/// architectures gain bandwidth capacity for depth stencil textures when shader resource views are precluded. If a texture is
		/// rarely used for shader resources, then it might be worth having two textures around and copying between them. One texture would
		/// have this flag, while the other wouldn't. Your application should set this flag when depth stencil textures will never be used
		/// from shader resource views.
		/// </para>
		/// <para>The following restrictions and interactions apply:</para>
		/// <list type="bullet">
		/// <item>Must be used with <b>D3D12_RESOURCE_FLAGS::D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>.</item>
		/// </list>
		/// </summary>
		D3D12_RESOURCE_FLAG_DENY_SHADER_RESOURCE = 0x8,

		/// <summary>
		/// <para>Value: 0x10 
		/// Allows the resource to be used for cross-adapter data, as well as those features enabled by
		/// D3D12_RESOURCE_FLAGS::D3D12_RESOURCE_FLAG_ALLOW_SIMULTANEOUS_ACCESS. Cross-adapter resources commonly preclude techniques that
		/// reduce effective texture bandwidth during usage, and some adapter architectures might require different caching behavior. Your
		/// application should avoid setting this flag when the resource data will never be used with another adapter.
		/// </para>
		/// <para>The following restrictions and interactions apply:</para>
		/// <list type="bullet">
		/// <item>Must be used with heaps that have <c>D3D12_HEAP_FLAG_SHARED_CROSS_ADAPTER</c>.</item>
		/// <item>Can't be used with heaps that have <c>D3D12_HEAP_FLAG_ALLOW_DISPLAY</c>.</item>
		/// </list>
		/// </summary>
		D3D12_RESOURCE_FLAG_ALLOW_CROSS_ADAPTER = 0x10,

		/// <summary>
		/// <para>Value: 0x20 
		/// Allows a resource to be simultaneously accessed by multiple different queues, devices, or processes (for example, allows a
		/// resource to be used with ResourceBarrier transitions performed in more than one command list executing at the same time).
		/// </para>
		/// <para>
		/// Simultaneous access allows multiple readers and one writer, as long as the writer doesn't concurrently modify the texels that
		/// other readers are accessing. Some adapter architectures can't leverage techniques to reduce effective texture bandwidth during usage.
		/// </para>
		/// <para>
		/// However, your application should avoid setting this flag when multiple readers are not required during frequent, non-overlapping
		/// writes to textures. Use of this flag can compromise resource fences to perform waits, and prevent any compression being used
		/// with a resource.
		/// </para>
		/// <para>The following restrictions and interactions apply:</para>
		/// <list type="bullet">
		/// <item>
		/// Can't be used with <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>; but buffers always have the properties represented by this flag.
		/// </item>
		/// <item>Can't be used with MSAA textures.</item>
		/// <item>Can't be used with <b>D3D12_RESOURCE_FLAGS::D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>.</item>
		/// </list>
		/// </summary>
		D3D12_RESOURCE_FLAG_ALLOW_SIMULTANEOUS_ACCESS = 0x20,

		/// <summary>
		/// <para>Value: 0x40 
		/// Specfies that this resource may be used only as a decode reference frame. It may be written to or read only by the video decode operation.
		/// </para>
		/// <para>
		/// D3D12_VIDEO_DECODE_TIER_1 and D3D12_VIDEO_DECODE_TIER_2 may report
		/// D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED in the D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT
		/// structure configuration flag. If that happens, then your application must allocate reference frames with the
		/// D3D12_RESOURCE_FLAGS::D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY resource flag.
		/// </para>
		/// <para>
		/// D3D12_VIDEO_DECODE_TIER_3 must not set the [D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED]
		/// (../d3d12video/ne-d3d12video-d3d12_video_decode_configuration_flags) configuration flag, and must not require the use of this
		/// resource flag.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY = 0x40,

		/// <summary>
		/// <para>Value: 0x80 
		/// Specfies that this resource may be used only as an encode reference frame. It may be written to or read only by the video encode operation.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_FLAG_VIDEO_ENCODE_REFERENCE_ONLY = 0x80,

		/// <summary>
		/// <para>Value: 0x100 
		/// Requires the DirectX 12 Agility SDK 1.608.0 or later. Indicates that a buffer is to be used as a raytracing acceleration
		/// structure. When using D3D12 Enhanced Barriers, this flag serves as a replacement for
		/// D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE, since buffers no longer have layouts/states.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_FLAG_RAYTRACING_ACCELERATION_STRUCTURE = 0x100,
	}

	/// <summary>Specifies which resource heap tier the hardware and driver support.</summary>
	/// <remarks>
	/// <para>This enum is used by the <b>ResourceHeapTier</b> member of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS</c> structure.</para>
	/// <para>
	/// This enum specifies which resource heap tier the hardware and driver support. Lower tiers require more heap attribution than greater tiers.
	/// </para>
	/// <para>Resources can be categorized into the following types:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Buffers</description>
	/// </item>
	/// <item>
	/// <description>Non-render target &amp; non-depth stencil textures</description>
	/// </item>
	/// <item>
	/// <description>Render target or depth stencil textures</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_heap_tier typedef enum D3D12_RESOURCE_HEAP_TIER {
	// D3D12_RESOURCE_HEAP_TIER_1 = 1, D3D12_RESOURCE_HEAP_TIER_2 = 2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESOURCE_HEAP_TIER")]
	public enum D3D12_RESOURCE_HEAP_TIER
	{
		/// <summary>
		/// <para>Value: 1 Indicates that heaps can only support resources from a single resource category.</para>
		/// <para>For the list of resource categories, see Remarks.</para>
		/// <para>In tier 1, these resource categories are mutually exclusive and cannot be used with the same heap.</para>
		/// <para>The resource category must be declared when creating a heap, using the correct D3D12_HEAP_FLAGS enumeration constant.</para>
		/// <para>Applications cannot create heaps with flags that allow all three categories.</para>
		/// </summary>
		D3D12_RESOURCE_HEAP_TIER_1 = 1,

		/// <summary>
		/// <para>Value: 2 Indicates that heaps can support resources from all three categories.</para>
		/// <para>For the list of resource categories, see Remarks.</para>
		/// <para>In tier 2, these resource categories can be mixed within the same heap.</para>
		/// <para>Applications may create heaps with flags that allow all three categories; but are not required to do so.</para>
		/// <para>Applications may be written to support tier 1 and seamlessly run on tier 2.</para>
		/// </summary>
		D3D12_RESOURCE_HEAP_TIER_2,
	}

	/// <summary>Defines constants that specify the state of a resource regarding how the resource is being used.</summary>
	/// <remarks>
	/// <para>This enum is used by the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>CreateCommittedResource</description>
	/// </item>
	/// <item>
	/// <description>CreatePlacedResource</description>
	/// </item>
	/// <item>
	/// <description>CreateReservedResource</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_states typedef enum D3D12_RESOURCE_STATES {
	// D3D12_RESOURCE_STATE_COMMON = 0, D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER = 0x1, D3D12_RESOURCE_STATE_INDEX_BUFFER = 0x2,
	// D3D12_RESOURCE_STATE_RENDER_TARGET = 0x4, D3D12_RESOURCE_STATE_UNORDERED_ACCESS = 0x8, D3D12_RESOURCE_STATE_DEPTH_WRITE = 0x10,
	// D3D12_RESOURCE_STATE_DEPTH_READ = 0x20, D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE = 0x40,
	// D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE = 0x80, D3D12_RESOURCE_STATE_STREAM_OUT = 0x100, D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT =
	// 0x200, D3D12_RESOURCE_STATE_COPY_DEST = 0x400, D3D12_RESOURCE_STATE_COPY_SOURCE = 0x800, D3D12_RESOURCE_STATE_RESOLVE_DEST = 0x1000,
	// D3D12_RESOURCE_STATE_RESOLVE_SOURCE = 0x2000, D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE = 0x400000,
	// D3D12_RESOURCE_STATE_SHADING_RATE_SOURCE = 0x1000000, D3D12_RESOURCE_STATE_RESERVED_INTERNAL_8000,
	// D3D12_RESOURCE_STATE_RESERVED_INTERNAL_4000, D3D12_RESOURCE_STATE_RESERVED_INTERNAL_100000,
	// D3D12_RESOURCE_STATE_RESERVED_INTERNAL_40000000, D3D12_RESOURCE_STATE_RESERVED_INTERNAL_80000000, D3D12_RESOURCE_STATE_GENERIC_READ,
	// D3D12_RESOURCE_STATE_ALL_SHADER_RESOURCE, D3D12_RESOURCE_STATE_PRESENT = 0, D3D12_RESOURCE_STATE_PREDICATION = 0x200,
	// D3D12_RESOURCE_STATE_VIDEO_DECODE_READ = 0x10000, D3D12_RESOURCE_STATE_VIDEO_DECODE_WRITE = 0x20000,
	// D3D12_RESOURCE_STATE_VIDEO_PROCESS_READ = 0x40000, D3D12_RESOURCE_STATE_VIDEO_PROCESS_WRITE = 0x80000,
	// D3D12_RESOURCE_STATE_VIDEO_ENCODE_READ = 0x200000, D3D12_RESOURCE_STATE_VIDEO_ENCODE_WRITE = 0x800000 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESOURCE_STATES")]
	[Flags]
	public enum D3D12_RESOURCE_STATES : uint
	{
		/// <summary>
		/// <para>Value: 0 Your application should transition to this state only for accessing a resource across different graphics engine types.</para>
		/// <para>
		/// Specifically, a resource must be in the COMMON state before being used on a COPY queue (when previously used on DIRECT/COMPUTE),
		/// and before being used on DIRECT/COMPUTE (when previously used on COPY). This restriction doesn't exist when accessing data
		/// between DIRECT and COMPUTE queues.
		/// </para>
		/// <para>The COMMON state can be used for all usages on a Copy queue using the implicit state transitions. For more info, in</para>
		/// <para>Multi-engine synchronization</para>
		/// <para>, find "common".</para>
		/// <para>
		/// Additionally, textures must be in the COMMON state for CPU access to be legal, assuming the texture was created in a CPU-visible
		/// heap in the first place.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_COMMON = 0x0,

		/// <summary>
		/// <para>Value: 0x1 
		/// A subresource must be in this state when it is accessed by the GPU as a vertex buffer or constant buffer. This is a read-only state.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER = 0x1,

		/// <summary>
		/// <para>Value: 0x2 A subresource must be in this state when it is accessed by the 3D pipeline as an index buffer. This is a read-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_INDEX_BUFFER = 0x2,

		/// <summary>
		/// <para>Value: 0x4 
		/// The resource is used as a render target. A subresource must be in this state when it is rendered to, or when it is cleared with
		/// </para>
		/// <para>ID3D12GraphicsCommandList::ClearRenderTargetView</para>
		/// <para>.</para>
		/// <para>
		/// This is a write-only state. To read from a render target as a shader resource, the resource must be in either
		/// D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE or D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_RENDER_TARGET = 0x4,

		/// <summary>
		/// <para>Value: 0x8 
		/// The resource is used for unordered access. A subresource must be in this state when it is accessed by the GPU via an unordered
		/// access view. A subresource must also be in this state when it is cleared with
		/// </para>
		/// <para>ID3D12GraphicsCommandList::ClearUnorderedAccessViewInt or ID3D12GraphicsCommandList::ClearUnorderedAccessViewFloat</para>
		/// <para>. This is a read/write state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_UNORDERED_ACCESS = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10 D3D12_RESOURCE_STATE_DEPTH_WRITE is a state that is mutually exclusive with other states. You should use it for</para>
		/// <para>ID3D12GraphicsCommandList::ClearDepthStencilView</para>
		/// <para>
		/// when the flags (see D3D12_CLEAR_FLAGS ) indicate a given subresource should be cleared (otherwise the subresource state doesn't
		/// matter), or when using it in a writable depth stencil view (see D3D12_DSV_FLAGS ) when the PSO has depth write enabled (see
		/// D3D12_DEPTH_STENCIL_DESC ).
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_DEPTH_WRITE = 0x10,

		/// <summary>
		/// <para>Value: 0x20 
		/// DEPTH_READ is a state that can be combined with other states. It should be used when the subresource is in a read-only depth
		/// stencil view, or when depth write of D3D12_DEPTH_STENCIL_DESC is disabled. It can be combined with other read states (for
		/// example, D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE ), such that the resource can be used for the depth or stencil test, and
		/// accessed by a shader within the same draw call. Using it when depth will be written by a draw call or clear command is invalid.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_DEPTH_READ = 0x20,

		/// <summary>
		/// <para>Value: 0x40 
		/// The resource is used with a shader other than the pixel shader. A subresource must be in this state before being read by any
		/// stage (except for the pixel shader stage) via a shader resource view. You can still use the resource in a pixel shader with this
		/// flag as long as it also has the flag D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE set. This is a read-only state.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE = 0x40,

		/// <summary>
		/// <para>Value: 0x80 
		/// The resource is used with a pixel shader. A subresource must be in this state before being read by the pixel shader via a shader
		/// resource view. This is a read-only state.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE = 0x80,

		/// <summary>
		/// <para>Value: 0x100 
		/// The resource is used with stream output. A subresource must be in this state when it is accessed by the 3D pipeline as a
		/// stream-out target. This is a write-only state.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_STREAM_OUT = 0x100,

		/// <summary>
		/// <para>Value: 0x200 The resource is used as an indirect argument.</para>
		/// <para>Subresources must be in this state when they are used as the argument buffer passed to the indirect drawing method</para>
		/// <para>ID3D12GraphicsCommandList::ExecuteIndirect</para>
		/// <para>.</para>
		/// <para>This is a read-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT = 0x200,

		/// <summary>
		/// <para>Value: 0x400 The resource is used as the destination in a copy operation.</para>
		/// <para>Subresources must be in this state when they are used as the destination of copy operation, or a blt operation.</para>
		/// <para>This is a write-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_COPY_DEST = 0x400,

		/// <summary>
		/// <para>Value: 0x800 The resource is used as the source in a copy operation.</para>
		/// <para>Subresources must be in this state when they are used as the source of copy operation, or a blt operation.</para>
		/// <para>This is a read-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_COPY_SOURCE = 0x800,

		/// <summary>
		/// <para>Value: 0x1000 The resource is used as the destination in a resolve operation.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_RESOLVE_DEST = 0x1000,

		/// <summary>
		/// <para>Value: 0x2000 The resource is used as the source in a resolve operation.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_RESOLVE_SOURCE = 0x2000,

		/// <summary>
		/// <para>Value: 0x400000 
		/// When a buffer is created with this as its initial state, it indicates that the resource is a raytracing acceleration structure,
		/// for use in
		/// </para>
		/// <para>ID3D12GraphicsCommandList4::BuildRaytracingAccelerationStructure</para>
		/// <para>,</para>
		/// <para>ID3D12GraphicsCommandList4::CopyRaytracingAccelerationStructure</para>
		/// <para>, or</para>
		/// <para>ID3D12Device::CreateShaderResourceView</para>
		/// <para>for the D3D12_SRV_DIMENSION_RAYTRACING_ACCELERATION_STRUCTURE dimension.</para>
		/// <para>
		/// <para>NOTE</para>
		/// <para>
		/// A resource to be used for the <c>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</c> state must be created in that state,
		/// and then never transitioned out of it. Nor may a resource that was created not in that state be transitioned into it. For more
		/// info, see Acceleration structure memory restrictions in the DirectX raytracing (DXR) functional specification on GitHub.
		/// </para>
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE = 0x400000,

		/// <summary>
		/// <para>Value: 0x1000000 
		/// Starting with Windows 10, version 1903 (10.0; Build 18362), indicates that the resource is a screen-space shading-rate image for
		/// variable-rate shading (VRS). For more info, see
		/// </para>
		/// <para>Variable-rate shading (VRS)</para>
		/// <para>.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_SHADING_RATE_SOURCE = 0x1000000,

		/// <summary>
		/// D3D12_RESOURCE_STATE_GENERIC_READ is a logically OR'd combination of other read-state bits. This is the required starting state
		/// for an upload heap. Your application should generally avoid transitioning to D3D12_RESOURCE_STATE_GENERIC_READ when possible,
		/// since that can result in premature cache flushes, or resource layout changes (for example, compress/decompress), causing
		/// unnecessary pipeline stalls. You should instead transition resources only to the actually-used states.
		/// </summary>
		D3D12_RESOURCE_STATE_GENERIC_READ = 0x1 | 0x2 | 0x40 | 0x80 | 0x200 | 0x800,

		/// <summary>
		/// <para>Equivalent to</para>
		/// <para>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE | D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE</para>
		/// <para>.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_ALL_SHADER_RESOURCE = 0x40 | 0x80,

		/// <summary>
		/// <para>Value: 0 Synonymous with D3D12_RESOURCE_STATE_COMMON.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_PRESENT = D3D12_RESOURCE_STATE_COMMON,

		/// <summary>
		/// <para>Value: 0x200 The resource is used for Predication.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_PREDICATION = 0x200,

		/// <summary>
		/// <para>Value: 0x10000 
		/// The resource is used as a source in a decode operation. Examples include reading the compressed bitstream and reading from
		/// decode references,
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_DECODE_READ = 0x10000,

		/// <summary>
		/// <para>Value: 0x20000 The resource is used as a destination in the decode operation. This state is used for decode output and histograms.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_DECODE_WRITE = 0x20000,

		/// <summary>
		/// <para>Value: 0x40000 
		/// The resource is used to read video data during video processing; that is, the resource is used as the source in a processing
		/// operation such as video encoding (compression).
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_PROCESS_READ = 0x40000,

		/// <summary>
		/// <para>Value: 0x80000 
		/// The resource is used to write video data during video processing; that is, the resource is used as the destination in a
		/// processing operation such as video encoding (compression).
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_PROCESS_WRITE = 0x80000,

		/// <summary>
		/// <para>Value: 0x200000 The resource is used as the source in an encode operation. This state is used for the input and reference of motion estimation.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_ENCODE_READ = 0x200000,

		/// <summary>
		/// <para>Value: 0x800000 
		/// This resource is used as the destination in an encode operation. This state is used for the destination texture of a resolve
		/// motion vector heap operation.
		/// </para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_ENCODE_WRITE = 0x800000,
	}

	/// <summary>
	/// Specifies the volatility of the data referenced by descriptors in a Root Signature 1.1 description, which can enable some driver optimizations.
	/// </summary>
	/// <remarks>
	/// <para>This enum is used by the <c>D3D12_ROOT_DESCRIPTOR1</c> structure.</para>
	/// <para>To specify the volatility of both descriptors and data, refer to <c>D3D12_DESCRIPTOR_RANGE_FLAGS</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_root_descriptor_flags typedef enum
	// D3D12_ROOT_DESCRIPTOR_FLAGS { D3D12_ROOT_DESCRIPTOR_FLAG_NONE = 0, D3D12_ROOT_DESCRIPTOR_FLAG_DATA_VOLATILE = 0x2,
	// D3D12_ROOT_DESCRIPTOR_FLAG_DATA_STATIC_WHILE_SET_AT_EXECUTE = 0x4, D3D12_ROOT_DESCRIPTOR_FLAG_DATA_STATIC = 0x8 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_ROOT_DESCRIPTOR_FLAGS")]
	[Flags]
	public enum D3D12_ROOT_DESCRIPTOR_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Default assumptions are made for data (for SRV/CBV: DATA_STATIC_WHILE_SET_AT_EXECUTE, and for UAV: DATA_VOLATILE).</para>
		/// </summary>
		D3D12_ROOT_DESCRIPTOR_FLAG_NONE = 0,

		/// <summary>
		/// <para>Value: 0x2 Data is volatile. Equivalent to Root Signature Version 1.0.</para>
		/// </summary>
		D3D12_ROOT_DESCRIPTOR_FLAG_DATA_VOLATILE = 0x2,

		/// <summary>
		/// <para>Value: 0x4 Data is static while set at execute.</para>
		/// </summary>
		D3D12_ROOT_DESCRIPTOR_FLAG_DATA_STATIC_WHILE_SET_AT_EXECUTE = 0x4,

		/// <summary>
		/// <para>Value: 0x8 Data is static. The best potential for driver optimization.</para>
		/// </summary>
		D3D12_ROOT_DESCRIPTOR_FLAG_DATA_STATIC = 0x8,
	}

	/// <summary>Specifies the type of root signature slot.</summary>
	/// <remarks>This enum is used by the <c>D3D12_ROOT_PARAMETER</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_root_parameter_type typedef enum D3D12_ROOT_PARAMETER_TYPE {
	// D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE = 0, D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS, D3D12_ROOT_PARAMETER_TYPE_CBV,
	// D3D12_ROOT_PARAMETER_TYPE_SRV, D3D12_ROOT_PARAMETER_TYPE_UAV } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_ROOT_PARAMETER_TYPE")]
	public enum D3D12_ROOT_PARAMETER_TYPE
	{
		/// <summary>
		/// <para>Value: 0 The slot is for a descriptor table.</para>
		/// </summary>
		D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE = 0,

		/// <summary>The slot is for root constants.</summary>
		D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS,

		/// <summary>The slot is for a constant-buffer view (CBV).</summary>
		D3D12_ROOT_PARAMETER_TYPE_CBV,

		/// <summary>The slot is for a shader-resource view (SRV).</summary>
		D3D12_ROOT_PARAMETER_TYPE_SRV,

		/// <summary>The slot is for a unordered-access view (UAV).</summary>
		D3D12_ROOT_PARAMETER_TYPE_UAV,
	}

	/// <summary>Specifies options for root signature layout.</summary>
	/// <remarks>
	/// <para>This enum is used in the <c>D3D12_ROOT_SIGNATURE_DESC</c> structure.</para>
	/// <para>
	/// The value in denying access to shader stages is a minor optimization on some hardware. If, for example, the
	/// <c>D3D12_SHADER_VISIBILITY_ALL</c> flag has been set to broadcast the root signature to all shader stages, then denying access can
	/// overrule this and save the hardware some work. Alternatively if the shader is so simple that no root signature resources are needed,
	/// then denying access could be used here too.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_root_signature_flags typedef enum D3D12_ROOT_SIGNATURE_FLAGS
	// { D3D12_ROOT_SIGNATURE_FLAG_NONE = 0, D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT = 0x1,
	// D3D12_ROOT_SIGNATURE_FLAG_DENY_VERTEX_SHADER_ROOT_ACCESS = 0x2, D3D12_ROOT_SIGNATURE_FLAG_DENY_HULL_SHADER_ROOT_ACCESS = 0x4,
	// D3D12_ROOT_SIGNATURE_FLAG_DENY_DOMAIN_SHADER_ROOT_ACCESS = 0x8, D3D12_ROOT_SIGNATURE_FLAG_DENY_GEOMETRY_SHADER_ROOT_ACCESS = 0x10,
	// D3D12_ROOT_SIGNATURE_FLAG_DENY_PIXEL_SHADER_ROOT_ACCESS = 0x20, D3D12_ROOT_SIGNATURE_FLAG_ALLOW_STREAM_OUTPUT = 0x40,
	// D3D12_ROOT_SIGNATURE_FLAG_LOCAL_ROOT_SIGNATURE = 0x80, D3D12_ROOT_SIGNATURE_FLAG_DENY_AMPLIFICATION_SHADER_ROOT_ACCESS = 0x100,
	// D3D12_ROOT_SIGNATURE_FLAG_DENY_MESH_SHADER_ROOT_ACCESS = 0x200, D3D12_ROOT_SIGNATURE_FLAG_CBV_SRV_UAV_HEAP_DIRECTLY_INDEXED = 0x400,
	// D3D12_ROOT_SIGNATURE_FLAG_SAMPLER_HEAP_DIRECTLY_INDEXED = 0x800 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_ROOT_SIGNATURE_FLAGS")]
	[Flags]
	public enum D3D12_ROOT_SIGNATURE_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Indicates default behavior.</para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 
		/// The app is opting in to using the Input Assembler (requiring an input layout that defines a set of vertex buffer bindings).
		/// Omitting this flag can result in one root argument space being saved on some hardware. Omit this flag if the Input Assembler is
		/// not required, though the optimization is minor.
		/// </para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT = 0x1,

		/// <summary>
		/// <para>Value: 0x2 Denies the vertex shader access to the root signature.</para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_DENY_VERTEX_SHADER_ROOT_ACCESS = 0x2,

		/// <summary>
		/// <para>Value: 0x4 Denies the hull shader access to the root signature.</para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_DENY_HULL_SHADER_ROOT_ACCESS = 0x4,

		/// <summary>
		/// <para>Value: 0x8 Denies the domain shader access to the root signature.</para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_DENY_DOMAIN_SHADER_ROOT_ACCESS = 0x8,

		/// <summary>
		/// <para>Value: 0x10 Denies the geometry shader access to the root signature.</para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_DENY_GEOMETRY_SHADER_ROOT_ACCESS = 0x10,

		/// <summary>
		/// <para>Value: 0x20 Denies the pixel shader access to the root signature.</para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_DENY_PIXEL_SHADER_ROOT_ACCESS = 0x20,

		/// <summary>
		/// <para>Value: 0x40 
		/// The app is opting in to using Stream Output. Omitting this flag can result in one root argument space being saved on some
		/// hardware. Omit this flag if Stream Output is not required, though the optimization is minor.
		/// </para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_ALLOW_STREAM_OUTPUT = 0x40,

		/// <summary>
		/// <para>Value: 0x80 
		/// The root signature is to be used with raytracing shaders to define resource bindings sourced from shader records in shader
		/// tables. This flag cannot be combined with any other root signature flags, which are all related to the graphics pipeline. The
		/// absence of the flag means the root signature can be used with graphics or compute, where the compute version is also shared with
		/// raytracing’s global root signature.
		/// </para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_LOCAL_ROOT_SIGNATURE = 0x80,

		/// <summary>
		/// <para>Value: 0x100 Denies the amplification shader access to the root signature.</para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_DENY_AMPLIFICATION_SHADER_ROOT_ACCESS = 0x100,

		/// <summary>
		/// <para>Value: 0x200 Denies the mesh shader access to the root signature.</para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_DENY_MESH_SHADER_ROOT_ACCESS = 0x200,

		/// <summary>
		/// <para>Value: 0x400 The shaders are allowed to index the CBV/SRV/UAV descriptor heap directly, using the ResourceDescriptorHeap built-in variable.</para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_CBV_SRV_UAV_HEAP_DIRECTLY_INDEXED = 0x400,

		/// <summary>
		/// <para>Value: 0x800 The shaders are allowed to index the sampler descriptor heap directly, using the SamplerDescriptorHeap built-in variable.</para>
		/// </summary>
		D3D12_ROOT_SIGNATURE_FLAG_SAMPLER_HEAP_DIRECTLY_INDEXED = 0x800,
	}

	/// <summary>Identifies the type of resource to view as a render target.</summary>
	/// <remarks>
	/// Specify one of the values in this enumeration in the <b>ViewDimension</b> member of a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_rtv_dimension typedef enum D3D12_RTV_DIMENSION {
	// D3D12_RTV_DIMENSION_UNKNOWN = 0, D3D12_RTV_DIMENSION_BUFFER = 1, D3D12_RTV_DIMENSION_TEXTURE1D = 2,
	// D3D12_RTV_DIMENSION_TEXTURE1DARRAY = 3, D3D12_RTV_DIMENSION_TEXTURE2D = 4, D3D12_RTV_DIMENSION_TEXTURE2DARRAY = 5,
	// D3D12_RTV_DIMENSION_TEXTURE2DMS = 6, D3D12_RTV_DIMENSION_TEXTURE2DMSARRAY = 7, D3D12_RTV_DIMENSION_TEXTURE3D = 8 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RTV_DIMENSION")]
	public enum D3D12_RTV_DIMENSION
	{
		/// <summary>
		/// <para>Value: 0 Do not use this value, as it will cause</para>
		/// <para>ID3D12Device::CreateRenderTargetView</para>
		/// <para>to fail.</para>
		/// </summary>
		D3D12_RTV_DIMENSION_UNKNOWN,

		/// <summary>
		/// <para>Value: 1 The resource will be accessed as a buffer.</para>
		/// </summary>
		D3D12_RTV_DIMENSION_BUFFER,

		/// <summary>
		/// <para>Value: 2 The resource will be accessed as a 1D texture.</para>
		/// </summary>
		D3D12_RTV_DIMENSION_TEXTURE1D,

		/// <summary>
		/// <para>Value: 3 The resource will be accessed as an array of 1D textures.</para>
		/// </summary>
		D3D12_RTV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>
		/// <para>Value: 4 The resource will be accessed as a 2D texture.</para>
		/// </summary>
		D3D12_RTV_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value: 5 The resource will be accessed as an array of 2D textures.</para>
		/// </summary>
		D3D12_RTV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>
		/// <para>Value: 6 The resource will be accessed as a 2D texture with multisampling.</para>
		/// </summary>
		D3D12_RTV_DIMENSION_TEXTURE2DMS,

		/// <summary>
		/// <para>Value: 7 The resource will be accessed as an array of 2D textures with multisampling.</para>
		/// </summary>
		D3D12_RTV_DIMENSION_TEXTURE2DMSARRAY,

		/// <summary>
		/// <para>Value: 8 The resource will be accessed as a 3D texture.</para>
		/// </summary>
		D3D12_RTV_DIMENSION_TEXTURE3D,
	}

	/// <summary>Defines constants that specify sampler feedback support.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_sampler_feedback_tier typedef enum
	// D3D12_SAMPLER_FEEDBACK_TIER { D3D12_SAMPLER_FEEDBACK_TIER_NOT_SUPPORTED = 0, D3D12_SAMPLER_FEEDBACK_TIER_0_9 = 90,
	// D3D12_SAMPLER_FEEDBACK_TIER_1_0 = 100 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SAMPLER_FEEDBACK_TIER")]
	public enum D3D12_SAMPLER_FEEDBACK_TIER
	{
		/// <summary>
		/// <para>Value: 0 Specifies that sampler feedback is not supported. Attempts at calling sampler feedback APIs represent an error.</para>
		/// </summary>
		D3D12_SAMPLER_FEEDBACK_TIER_NOT_SUPPORTED = 0,

		/// <summary>
		/// <para>Value: 90 Specifies that sampler feedback is supported to tier 0.9. This indicates the following:</para>
		/// <para>Sampler feedback is supported for samplers with these texture addressing modes:</para>
		/// <para>* D3D12_TEXTURE_ADDRESS_MODE_WRAP</para>
		/// <para>* D3D12_TEXTURE_ADDRESS_MODE_CLAMP</para>
		/// <para>The Texture2D shader resource view passed in to feedback-writing HLSL methods has these restrictions:</para>
		/// <para>* The MostDetailedMip field must be 0.</para>
		/// <para>* The MipLevels count must span the full mip count of the resource.</para>
		/// <para>* The PlaneSlice field must be 0.</para>
		/// <para>* The ResourceMinLODClamp field must be 0.</para>
		/// <para>The Texture2DArray shader resource view passed in to feedback-writing HLSL methods has these restrictions:</para>
		/// <para>* All the limitations as in Texture2D above, and</para>
		/// <para>* The FirstArraySlice field must be 0.</para>
		/// <para>* The ArraySize field must span the full array element count of the resource.</para>
		/// </summary>
		D3D12_SAMPLER_FEEDBACK_TIER_0_9 = 90,

		/// <summary>
		/// <para>Value: 100 
		/// Specifies sample feedback is supported to tier 1.0. This indicates that sampler feedback is supported for all texture addressing
		/// modes, and feedback-writing methods are supported irrespective of the passed-in shader resource view.
		/// </para>
		/// </summary>
		D3D12_SAMPLER_FEEDBACK_TIER_1_0 = 100,
	}

	/// <summary>Specifies the type of serialized data. Use a value from this enumeration when calling <c>ID3D12Device5::CheckDriverMatchingIdentifier</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_serialized_data_type typedef enum D3D12_SERIALIZED_DATA_TYPE
	// { D3D12_SERIALIZED_DATA_RAYTRACING_ACCELERATION_STRUCTURE = 0 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SERIALIZED_DATA_TYPE")]
	public enum D3D12_SERIALIZED_DATA_TYPE
	{
		/// <summary>
		/// <para>Value: 0 The serialized data is a raytracing acceleration structure.</para>
		/// </summary>
		D3D12_SERIALIZED_DATA_RAYTRACING_ACCELERATION_STRUCTURE,
	}

	/// <summary>Defines constants that specify shader cache control options.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_cache_control_flags typedef enum
	// D3D12_SHADER_CACHE_CONTROL_FLAGS { D3D12_SHADER_CACHE_CONTROL_FLAG_DISABLE = 0x1, D3D12_SHADER_CACHE_CONTROL_FLAG_ENABLE = 0x2,
	// D3D12_SHADER_CACHE_CONTROL_FLAG_CLEAR = 0x4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHADER_CACHE_CONTROL_FLAGS")]
	[Flags]
	public enum D3D12_SHADER_CACHE_CONTROL_FLAGS
	{
		/// <summary>
		/// <para>Value: 0x1 
		/// Specifies that the cache shouldn't be used to look up data, and shouldn't have new data stored in it. Attempts to use/create a
		/// cache while it's disabled result in DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.
		/// </para>
		/// </summary>
		D3D12_SHADER_CACHE_CONTROL_FLAG_DISABLE = 0x1,

		/// <summary>
		/// <para>Value: 0x2 Specfies that use of the cache should be resumed.</para>
		/// </summary>
		D3D12_SHADER_CACHE_CONTROL_FLAG_ENABLE = 0x2,

		/// <summary>
		/// <para>Value: 0x4 Specfies that any existing contents of the cache should be deleted.</para>
		/// </summary>
		D3D12_SHADER_CACHE_CONTROL_FLAG_CLEAR = 0x4,
	}

	/// <summary>Defines constants that specify shader cache flags.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_cache_flags typedef enum D3D12_SHADER_CACHE_FLAGS {
	// D3D12_SHADER_CACHE_FLAG_NONE = 0, D3D12_SHADER_CACHE_FLAG_DRIVER_VERSIONED = 0x1, D3D12_SHADER_CACHE_FLAG_USE_WORKING_DIR = 0x2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHADER_CACHE_FLAGS")]
	[Flags]
	public enum D3D12_SHADER_CACHE_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Specifies no flag.</para>
		/// </summary>
		D3D12_SHADER_CACHE_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 
		/// Specifies that the cache is implicitly versioned by the driver being used. For multi-GPU systems, a cache created this way is
		/// stored side by side for each adapter on which the application runs. The Version field in the D3D12_SHADER_CACHE_SESSION_DESC
		/// struct (the cache description) is used as an additional constraint.
		/// </para>
		/// </summary>
		D3D12_SHADER_CACHE_FLAG_DRIVER_VERSIONED = 0x1,

		/// <summary>
		/// <para>Value: 0x2 
		/// By default, caches are stored in temporary storage, and can be cleared by disk cleanup. This constant (not valid for UWP apps)
		/// specifies that the cache is instead stored in the current working directory.
		/// </para>
		/// </summary>
		D3D12_SHADER_CACHE_FLAG_USE_WORKING_DIR = 0x2,
	}

	/// <summary>Defines constants that specify a kind of shader cache.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_cache_kind_flags typedef enum
	// D3D12_SHADER_CACHE_KIND_FLAGS { D3D12_SHADER_CACHE_KIND_FLAG_IMPLICIT_D3D_CACHE_FOR_DRIVER = 0x1,
	// D3D12_SHADER_CACHE_KIND_FLAG_IMPLICIT_D3D_CONVERSIONS = 0x2, D3D12_SHADER_CACHE_KIND_FLAG_IMPLICIT_DRIVER_MANAGED = 0x4,
	// D3D12_SHADER_CACHE_KIND_FLAG_APPLICATION_MANAGED = 0x8 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHADER_CACHE_KIND_FLAGS")]
	[Flags]
	public enum D3D12_SHADER_CACHE_KIND_FLAGS
	{
		/// <summary>
		/// <para>Value: 0x1 Specifies a cache that's managed by Direct3D 12 to store driver compilations of application shaders.</para>
		/// </summary>
		D3D12_SHADER_CACHE_KIND_FLAG_IMPLICIT_D3D_CACHE_FOR_DRIVER = 0x1,

		/// <summary>
		/// <para>Value: 0x2 
		/// Specifies a cache that's used to store Direct3D 12's conversions of one shader type to another (for example, DXBC shaders to
		/// DXIL shaders).
		/// </para>
		/// </summary>
		D3D12_SHADER_CACHE_KIND_FLAG_IMPLICIT_D3D_CONVERSIONS = 0x2,

		/// <summary>
		/// <para>Value: 0x4 Specifies a cache that's managed by the driver. Operations for this cache are hints.</para>
		/// </summary>
		D3D12_SHADER_CACHE_KIND_FLAG_IMPLICIT_DRIVER_MANAGED = 0x4,

		/// <summary>
		/// <para>Value: 0x8 
		/// Specifies all shader cache sessions created by the ID3D12Device9::CreateShaderCacheSession method. Requests to CLEAR with this
		/// flag apply to all currently active application cache sessions, as well as on-disk caches created without D3D12_SHADER_CACHE_FLAG_USE_WORKING_DIR
		/// </para>
		/// <para>.</para>
		/// </summary>
		D3D12_SHADER_CACHE_KIND_FLAG_APPLICATION_MANAGED = 0x8,
	}

	/// <summary>Defines constants that specify a shader cache's mode.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_cache_mode typedef enum D3D12_SHADER_CACHE_MODE {
	// D3D12_SHADER_CACHE_MODE_MEMORY = 0, D3D12_SHADER_CACHE_MODE_DISK } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHADER_CACHE_MODE")]
	public enum D3D12_SHADER_CACHE_MODE
	{
		/// <summary>
		/// <para>Value: 0 Specifies that there's no backing file for this cache. All stores are discarded when the session object is destroyed.</para>
		/// </summary>
		D3D12_SHADER_CACHE_MODE_MEMORY,

		/// <summary>
		/// Specifies that the session is backed by files on disk that persist from run to run unless cleared. For ways to clear a disk
		/// cache, see ID3D12ShaderCacheSession::SetDeleteOnDestroy.
		/// </summary>
		D3D12_SHADER_CACHE_MODE_DISK,
	}

	/// <summary>Describes the level of support for shader caching in the current graphics driver.</summary>
	/// <remarks>This enum is used by the <c>D3D_FEATURE_DATA_SHADER_CACHE</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_cache_support_flags typedef enum
	// D3D12_SHADER_CACHE_SUPPORT_FLAGS { D3D12_SHADER_CACHE_SUPPORT_NONE = 0, D3D12_SHADER_CACHE_SUPPORT_SINGLE_PSO = 0x1,
	// D3D12_SHADER_CACHE_SUPPORT_LIBRARY = 0x2, D3D12_SHADER_CACHE_SUPPORT_AUTOMATIC_INPROC_CACHE = 0x4,
	// D3D12_SHADER_CACHE_SUPPORT_AUTOMATIC_DISK_CACHE = 0x8, D3D12_SHADER_CACHE_SUPPORT_DRIVER_MANAGED_CACHE,
	// D3D12_SHADER_CACHE_SUPPORT_SHADER_CONTROL_CLEAR, D3D12_SHADER_CACHE_SUPPORT_SHADER_SESSION_DELETE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHADER_CACHE_SUPPORT_FLAGS")]
	[Flags]
	public enum D3D12_SHADER_CACHE_SUPPORT_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Indicates that the driver does not support shader caching.</para>
		/// </summary>
		D3D12_SHADER_CACHE_SUPPORT_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 
		/// Indicates that the driver supports the CachedPSO member of the D3D12_GRAPHICS_PIPELINE_STATE_DESC and
		/// D3D12_COMPUTE_PIPELINE_STATE_DESC structures. This is always supported.
		/// </para>
		/// </summary>
		D3D12_SHADER_CACHE_SUPPORT_SINGLE_PSO = 0x1,

		/// <summary>
		/// <para>Value: 0x2 
		/// Indicates that the driver supports the ID3D12PipelineLibrary interface, which provides application-controlled PSO grouping and
		/// caching. This is supported by drivers targetting the Windows 10 Anniversary Update.
		/// </para>
		/// </summary>
		D3D12_SHADER_CACHE_SUPPORT_LIBRARY = 0x2,

		/// <summary>
		/// <para>Value: 0x4 
		/// Indicates that the driver supports an OS-managed shader cache that stores compiled shaders in memory during the current run of
		/// the application.
		/// </para>
		/// </summary>
		D3D12_SHADER_CACHE_SUPPORT_AUTOMATIC_INPROC_CACHE = 0x4,

		/// <summary>
		/// <para>Value: 0x8 
		/// Indicates that the driver supports an OS-managed shader cache that stores compiled shaders on disk to accelerate future runs of
		/// the application.
		/// </para>
		/// </summary>
		D3D12_SHADER_CACHE_SUPPORT_AUTOMATIC_DISK_CACHE = 0x8,
	}

	/// <summary>Specifies how memory gets routed by a shader resource view (SRV).</summary>
	/// <remarks>
	/// <para>
	/// This enum allows the SRV to select how memory gets routed to the four return components in a shader after a memory fetch. The
	/// options for each shader component [0..3] (corresponding to RGBA) are: component 0..3 from the SRV fetch result or force 0 or force 1.
	/// </para>
	/// <para>
	/// The default 1:1 mapping can be indicated by specifying <b>D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING</b>, otherwise an arbitrary
	/// mapping can be specified using the macro <b>D3D12_ENCODE_SHADER_4_COMPONENT_MAPPING</b>.
	/// </para>
	/// <para>See below.</para>
	/// <para>Note the following defines.</para>
	/// <para>
	/// <c>#define D3D12_SHADER_COMPONENT_MAPPING_MASK 0x7 #define D3D12_SHADER_COMPONENT_MAPPING_SHIFT 3 #define
	/// D3D12_SHADER_COMPONENT_MAPPING_ALWAYS_SET_BIT_AVOIDING_ZEROMEM_MISTAKES \ (1&lt;&lt;(D3D12_SHADER_COMPONENT_MAPPING_SHIFT*4))
	/// #define D3D12_ENCODE_SHADER_4_COMPONENT_MAPPING(Src0,Src1,Src2,Src3) \ ((((Src0)&amp;D3D12_SHADER_COMPONENT_MAPPING_MASK)| \
	/// (((Src1)&amp;D3D12_SHADER_COMPONENT_MAPPING_MASK)&lt;&lt;D3D12_SHADER_COMPONENT_MAPPING_SHIFT)| \
	/// (((Src2)&amp;D3D12_SHADER_COMPONENT_MAPPING_MASK)&lt;&lt;(D3D12_SHADER_COMPONENT_MAPPING_SHIFT*2))| \
	/// (((Src3)&amp;D3D12_SHADER_COMPONENT_MAPPING_MASK)&lt;&lt;(D3D12_SHADER_COMPONENT_MAPPING_SHIFT*3))| \
	/// D3D12_SHADER_COMPONENT_MAPPING_ALWAYS_SET_BIT_AVOIDING_ZEROMEM_MISTAKES)) #define
	/// D3D12_DECODE_SHADER_4_COMPONENT_MAPPING(ComponentToExtract,Mapping) \ ((D3D12_SHADER_COMPONENT_MAPPING)(Mapping &gt;&gt;
	/// (D3D12_SHADER_COMPONENT_MAPPING_SHIFT*ComponentToExtract) &amp; D3D12_SHADER_COMPONENT_MAPPING_MASK)) #define
	/// D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING D3D12_ENCODE_SHADER_4_COMPONENT_MAPPING(0,1,2,3)</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_component_mapping typedef enum
	// D3D12_SHADER_COMPONENT_MAPPING { D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_0 = 0,
	// D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_1 = 1, D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_2 = 2,
	// D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_3 = 3, D3D12_SHADER_COMPONENT_MAPPING_FORCE_VALUE_0 = 4,
	// D3D12_SHADER_COMPONENT_MAPPING_FORCE_VALUE_1 = 5 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHADER_COMPONENT_MAPPING")]
	public enum D3D12_SHADER_COMPONENT_MAPPING
	{
		/// <summary>
		/// <para>Value: 0 Indicates return component 0 (red).</para>
		/// </summary>
		D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_0,

		/// <summary>
		/// <para>Value: 1 Indicates return component 1 (green).</para>
		/// </summary>
		D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_1,

		/// <summary>
		/// <para>Value: 2 Indicates return component 2 (blue).</para>
		/// </summary>
		D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_2,

		/// <summary>
		/// <para>Value: 3 Indicates return component 3 (alpha).</para>
		/// </summary>
		D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_3,

		/// <summary>
		/// <para>Value: 4 Indicates forcing the resulting value to 0.</para>
		/// </summary>
		D3D12_SHADER_COMPONENT_MAPPING_FORCE_VALUE_0,

		/// <summary>
		/// <para>Value: 5 
		/// Indicates forcing the resulting value 1. The value of forcing 1 is either 0x1 or 1.0f depending on the format type for that
		/// component in the source format.
		/// </para>
		/// </summary>
		D3D12_SHADER_COMPONENT_MAPPING_FORCE_VALUE_1,
	}

	/// <summary>Describes minimum precision support options for shaders in the current graphics driver.</summary>
	/// <remarks>
	/// <para>This enum is used by the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS</c> structure.</para>
	/// <para>
	/// The returned info just indicates that the graphics hardware can perform HLSL operations at a lower precision than the standard
	/// 32-bit float precision, but doesn’t guarantee that the graphics hardware will actually run at a lower precision.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_min_precision_support typedef enum
	// D3D12_SHADER_MIN_PRECISION_SUPPORT { D3D12_SHADER_MIN_PRECISION_SUPPORT_NONE = 0, D3D12_SHADER_MIN_PRECISION_SUPPORT_10_BIT = 0x1,
	// D3D12_SHADER_MIN_PRECISION_SUPPORT_16_BIT = 0x2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHADER_MIN_PRECISION_SUPPORT")]
	public enum D3D12_SHADER_MIN_PRECISION_SUPPORT
	{
		/// <summary>
		/// <para>Value: 0 The driver supports only full 32-bit precision for all shader stages.</para>
		/// </summary>
		D3D12_SHADER_MIN_PRECISION_SUPPORT_NONE,

		/// <summary>
		/// <para>Value: 0x1 The driver supports 10-bit precision.</para>
		/// </summary>
		D3D12_SHADER_MIN_PRECISION_SUPPORT_10_BIT,

		/// <summary>
		/// <para>Value: 0x2 The driver supports 16-bit precision.</para>
		/// </summary>
		D3D12_SHADER_MIN_PRECISION_SUPPORT_16_BIT,
	}

	/// <summary>Specifies the shaders that can access the contents of a given root signature slot.</summary>
	/// <remarks>
	/// <para>This enum is used by the <c>D3D12_ROOT_PARAMETER</c> structure.</para>
	/// <para>
	/// The compute queue always uses <b>D3D12_SHADER_VISIBILITY_ALL</b> because it has only one active stage. The 3D queue can choose
	/// values, but if it uses <b>D3D12_SHADER_VISIBILITY_ALL</b>, all shader stages can access whatever is bound at the root signature slot.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_visibility typedef enum D3D12_SHADER_VISIBILITY {
	// D3D12_SHADER_VISIBILITY_ALL = 0, D3D12_SHADER_VISIBILITY_VERTEX = 1, D3D12_SHADER_VISIBILITY_HULL = 2, D3D12_SHADER_VISIBILITY_DOMAIN
	// = 3, D3D12_SHADER_VISIBILITY_GEOMETRY = 4, D3D12_SHADER_VISIBILITY_PIXEL = 5, D3D12_SHADER_VISIBILITY_AMPLIFICATION = 6,
	// D3D12_SHADER_VISIBILITY_MESH = 7 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHADER_VISIBILITY")]
	public enum D3D12_SHADER_VISIBILITY
	{
		/// <summary>
		/// <para>Value: 0 Specifies that all shader stages can access whatever is bound at the root signature slot.</para>
		/// </summary>
		D3D12_SHADER_VISIBILITY_ALL,

		/// <summary>
		/// <para>Value: 1 Specifies that the vertex shader stage can access whatever is bound at the root signature slot.</para>
		/// </summary>
		D3D12_SHADER_VISIBILITY_VERTEX,

		/// <summary>
		/// <para>Value: 2 Specifies that the hull shader stage can access whatever is bound at the root signature slot.</para>
		/// </summary>
		D3D12_SHADER_VISIBILITY_HULL,

		/// <summary>
		/// <para>Value: 3 Specifies that the domain shader stage can access whatever is bound at the root signature slot.</para>
		/// </summary>
		D3D12_SHADER_VISIBILITY_DOMAIN,

		/// <summary>
		/// <para>Value: 4 Specifies that the geometry shader stage can access whatever is bound at the root signature slot.</para>
		/// </summary>
		D3D12_SHADER_VISIBILITY_GEOMETRY,

		/// <summary>
		/// <para>Value: 5 Specifies that the pixel shader stage can access whatever is bound at the root signature slot.</para>
		/// </summary>
		D3D12_SHADER_VISIBILITY_PIXEL,

		/// <summary>
		/// <para>Value: 6 Specifies that the amplification shader stage can access whatever is bound at the root signature slot.</para>
		/// </summary>
		D3D12_SHADER_VISIBILITY_AMPLIFICATION,

		/// <summary>
		/// <para>Value: 7 Specifies that the mesh shader stage can access whatever is bound at the root signature slot.</para>
		/// </summary>
		D3D12_SHADER_VISIBILITY_MESH,
	}

	/// <summary>
	/// Defines constants that specify the shading rate (for variable-rate shading, or VRS). For more info, see <c>Variable-rate shading (VRS)</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shading_rate typedef enum D3D12_SHADING_RATE {
	// D3D12_SHADING_RATE_1X1 = 0, D3D12_SHADING_RATE_1X2 = 0x1, D3D12_SHADING_RATE_2X1 = 0x4, D3D12_SHADING_RATE_2X2 = 0x5,
	// D3D12_SHADING_RATE_2X4 = 0x6, D3D12_SHADING_RATE_4X2 = 0x9, D3D12_SHADING_RATE_4X4 = 0xa } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHADING_RATE")]
	public enum D3D12_SHADING_RATE
	{
		/// <summary>
		/// <para>Value: 0 Specifies no change to the shading rate.</para>
		/// </summary>
		D3D12_SHADING_RATE_1X1 = 0,

		/// <summary>
		/// <para>Value: 0x1 Specifies that the shading rate should reduce vertical resolution 2x.</para>
		/// </summary>
		D3D12_SHADING_RATE_1X2 = 1,

		/// <summary>
		/// <para>Value: 0x4 Specifies that the shading rate should reduce horizontal resolution 2x.</para>
		/// </summary>
		D3D12_SHADING_RATE_2X1 = 4,

		/// <summary>
		/// <para>Value: 0x5 Specifies that the shading rate should reduce the resolution of both axes 2x.</para>
		/// </summary>
		D3D12_SHADING_RATE_2X2 = 5,

		/// <summary>
		/// <para>Value: 0x6 Specifies that the shading rate should reduce horizontal resolution 2x, and reduce vertical resolution 4x.</para>
		/// </summary>
		D3D12_SHADING_RATE_2X4 = 6,

		/// <summary>
		/// <para>Value: 0x9 Specifies that the shading rate should reduce horizontal resolution 4x, and reduce vertical resolution 2x.</para>
		/// </summary>
		D3D12_SHADING_RATE_4X2 = 9,

		/// <summary>
		/// <para>Value: 0xa Specifies that the shading rate should reduce the resolution of both axes 4x.</para>
		/// </summary>
		D3D12_SHADING_RATE_4X4 = 10,
	}

	/// <summary>
	/// Defines constants that specify a shading rate combiner (for variable-rate shading, or VRS). For more info, see <c>Variable-rate
	/// shading (VRS)</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shading_rate_combiner typedef enum
	// D3D12_SHADING_RATE_COMBINER { D3D12_SHADING_RATE_COMBINER_PASSTHROUGH = 0, D3D12_SHADING_RATE_COMBINER_OVERRIDE = 1,
	// D3D12_SHADING_RATE_COMBINER_MIN = 2, D3D12_SHADING_RATE_COMBINER_MAX = 3, D3D12_SHADING_RATE_COMBINER_SUM = 4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHADING_RATE_COMBINER")]
	public enum D3D12_SHADING_RATE_COMBINER
	{
		/// <summary>
		/// <para>Value: 0 Specifies the combiner</para>
		/// <para>C.xy = A.xy</para>
		/// <para>, for combiner (C) and inputs (A and B).</para>
		/// </summary>
		D3D12_SHADING_RATE_COMBINER_PASSTHROUGH,

		/// <summary>
		/// <para>Value: 1 Specifies the combiner</para>
		/// <para>C.xy = B.xy</para>
		/// <para>, for combiner (C) and inputs (A and B).</para>
		/// </summary>
		D3D12_SHADING_RATE_COMBINER_OVERRIDE,

		/// <summary>
		/// <para>Value: 2 Specifies the combiner</para>
		/// <para>C.xy = max(A.xy, B.xy)</para>
		/// <para>, for combiner (C) and inputs (A and B).</para>
		/// </summary>
		D3D12_SHADING_RATE_COMBINER_MIN,

		/// <summary>
		/// <para>Value: 3 Specifies the combiner</para>
		/// <para>C.xy = min(A.xy, B.xy)</para>
		/// <para>, for combiner (C) and inputs (A and B).</para>
		/// </summary>
		D3D12_SHADING_RATE_COMBINER_MAX,

		/// <summary>
		/// <para>Value: 4 Specifies the combiner C.xy = min(maxRate, A.xy + B.xy)`, for combiner (C) and inputs (A and B).</para>
		/// </summary>
		D3D12_SHADING_RATE_COMBINER_SUM,
	}

	/// <summary>
	/// <para>Defines constants that specify a cross-API sharing support tier.</para>
	/// <para>The resource data formats mentioned are members of the <c>DXGI_FORMAT enumeration</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shared_resource_compatibility_tier typedef enum
	// D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER { D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER_0 = 0,
	// D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER_1, D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER_2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER")]
	public enum D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER
	{
		/// <summary>
		/// <para>Value: 0 Related to D3D11_SHARED_RESOURCE_TIER::D3D11_SHARED_RESOURCE_TIER_1.</para>
		/// <para>Specifies that the most basic level of cross-API sharing is supported, including the following resource data formats.</para>
		/// <para>* DXGI_FORMAT_R8G8B8A8_UNORM</para>
		/// <para>* DXGI_FORMAT_R8G8B8A8_UNORM_SRGB</para>
		/// <para>* DXGI_FORMAT_B8G8R8A8_UNORM</para>
		/// <para>* DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</para>
		/// <para>* DXGI_FORMAT_B8G8R8X8_UNORM</para>
		/// <para>* DXGI_FORMAT_B8G8R8X8_UNORM_SRGB</para>
		/// <para>* DXGI_FORMAT_R10G10B10A2_UNORM</para>
		/// <para>* DXGI_FORMAT_R16G16B16A16_FLOAT</para>
		/// </summary>
		D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER_0,

		/// <summary>
		/// <para>Related to</para>
		/// <para>D3D11_SHARED_RESOURCE_TIER::D3D11_SHARED_RESOURCE_TIER_2</para>
		/// <para>.</para>
		/// <para>
		/// Specifies that cross-API sharing functionality of D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER_0 is supported, plus the following formats.
		/// </para>
		/// <para>* DXGI_FORMAT_R16G16B16A16_TYPELESS</para>
		/// <para>* DXGI_FORMAT_R10G10B10A2_TYPELESS</para>
		/// <para>* DXGI_FORMAT_R8G8B8A8_TYPELESS</para>
		/// <para>* DXGI_FORMAT_R8G8B8X8_TYPELESS</para>
		/// <para>* DXGI_FORMAT_R16G16_TYPELESS</para>
		/// <para>* DXGI_FORMAT_R8G8_TYPELESS</para>
		/// <para>* DXGI_FORMAT_R32_TYPELESS</para>
		/// <para>* DXGI_FORMAT_R16_TYPELESS</para>
		/// <para>* DXGI_FORMAT_R8_TYPELESS</para>
		/// <para>This level support is built into WDDM 2.4. Also see Extended support for shared Texture2D resources.</para>
		/// </summary>
		D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER_1,

		/// <summary>
		/// <para>Related to D3D11_SHARED_RESOURCE_TIER::D3D11_SHARED_RESOURCE_TIER_3.</para>
		/// <para>
		/// Specifies that cross-API sharing functionality of D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER_1 is supported, plus the following formats.
		/// </para>
		/// <para>* DXGI_FORMAT_NV12 (also see Extended NV12 texture support)</para>
		/// </summary>
		D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER_2,
	}

	/// <summary>Identifies the type of resource that will be viewed as a shader resource.</summary>
	/// <remarks>These values are used by a shader-resource-view description, <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_srv_dimension typedef enum D3D12_SRV_DIMENSION {
	// D3D12_SRV_DIMENSION_UNKNOWN = 0, D3D12_SRV_DIMENSION_BUFFER = 1, D3D12_SRV_DIMENSION_TEXTURE1D = 2,
	// D3D12_SRV_DIMENSION_TEXTURE1DARRAY = 3, D3D12_SRV_DIMENSION_TEXTURE2D = 4, D3D12_SRV_DIMENSION_TEXTURE2DARRAY = 5,
	// D3D12_SRV_DIMENSION_TEXTURE2DMS = 6, D3D12_SRV_DIMENSION_TEXTURE2DMSARRAY = 7, D3D12_SRV_DIMENSION_TEXTURE3D = 8,
	// D3D12_SRV_DIMENSION_TEXTURECUBE = 9, D3D12_SRV_DIMENSION_TEXTURECUBEARRAY = 10, D3D12_SRV_DIMENSION_RAYTRACING_ACCELERATION_STRUCTURE
	// = 11 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_SRV_DIMENSION")]
	public enum D3D12_SRV_DIMENSION
	{
		/// <summary>
		/// <para>Value: 0 The type is unknown.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_UNKNOWN,

		/// <summary>
		/// <para>Value: 1 The resource is a buffer.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_BUFFER,

		/// <summary>
		/// <para>Value: 2 The resource is a 1D texture.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_TEXTURE1D,

		/// <summary>
		/// <para>Value: 3 The resource is an array of 1D textures.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>
		/// <para>Value: 4 The resource is a 2D texture.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value: 5 The resource is an array of 2D textures.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>
		/// <para>Value: 6 The resource is a multisampling 2D texture.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_TEXTURE2DMS,

		/// <summary>
		/// <para>Value: 7 The resource is an array of multisampling 2D textures.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_TEXTURE2DMSARRAY,

		/// <summary>
		/// <para>Value: 8 The resource is a 3D texture.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_TEXTURE3D,

		/// <summary>
		/// <para>Value: 9 The resource is a cube texture.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_TEXTURECUBE,

		/// <summary>
		/// <para>Value: 10 The resource is an array of cube textures.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_TEXTURECUBEARRAY,

		/// <summary>
		/// <para>Value: 11 The resource is a raytracing acceleration structure.</para>
		/// </summary>
		D3D12_SRV_DIMENSION_RAYTRACING_ACCELERATION_STRUCTURE,
	}

	/// <summary>Specifies constraints for state objects. Use values from this enumeration in the <c>D3D12_STATE_OBJECT_CONFIG</c> structure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_state_object_flags typedef enum D3D12_STATE_OBJECT_FLAGS {
	// D3D12_STATE_OBJECT_FLAG_NONE = 0, D3D12_STATE_OBJECT_FLAG_ALLOW_LOCAL_DEPENDENCIES_ON_EXTERNAL_DEFINITIONS = 0x1,
	// D3D12_STATE_OBJECT_FLAG_ALLOW_EXTERNAL_DEPENDENCIES_ON_LOCAL_DEFINITIONS = 0x2, D3D12_STATE_OBJECT_FLAG_ALLOW_STATE_OBJECT_ADDITIONS
	// } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_STATE_OBJECT_FLAGS")]
	[Flags]
	public enum D3D12_STATE_OBJECT_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No state object constraints.</para>
		/// </summary>
		D3D12_STATE_OBJECT_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 This flag applies to state objects of type collection only. Otherwise this flag is ignored.</para>
		/// <para>
		/// The exports from this collection are allowed to have unresolved references (dependencies) that would have to be resolved
		/// (defined) when the collection is included in a containing state object, such as a raytracing pipeline state object (RTPSO). This
		/// includes depending on externally defined subobject associations to associate an external subobject (e.g. root signature) to a
		/// local export.
		/// </para>
		/// <para>
		/// In the absence of this flag, all exports in this collection must have their dependencies fully locally resolved, including any
		/// necessary subobject associations being defined locally. Advanced implementations/drivers will have enough information to compile
		/// the code in the collection and not need to keep around any uncompiled code (unless the
		/// D3D12_STATE_OBJECT_FLAG_ALLOW_EXTERNAL_DEPENDENCIES_ON_LOCAL_DEFINITIONS flag is set), so that when the collection is used in a
		/// containing state object (e.g. RTPSO), minimal work needs to be done by the driver, ideally a “cheap” link at most.
		/// </para>
		/// </summary>
		D3D12_STATE_OBJECT_FLAG_ALLOW_LOCAL_DEPENDENCIES_ON_EXTERNAL_DEFINITIONS = 0x1,

		/// <summary>
		/// <para>Value: 0x2 This flag applies to state objects of type collection only. Otherwise this flag is ignored.</para>
		/// <para>
		/// If this collection is included in another state object (e.g. RTPSO), shaders / functions in the rest of the containing state
		/// object are allowed to depend on (e.g. call) exports from this collection.
		/// </para>
		/// <para>
		/// In the absence of this flag (default), exports from this collection cannot be directly referenced by other parts of containing
		/// state objects (e.g. RTPSO). This can reduce memory footprint for the collection slightly since drivers don’t need to keep
		/// uncompiled code in the collection on the off chance that it may get called by some external function that would then compile all
		/// the code together. That said, if not all necessary subobject associations have been locally defined for code in this collection,
		/// the driver may not be able to compile shader code yet and may still need to keep uncompiled code around.
		/// </para>
		/// <para>
		/// A subobject association defined externally that associates an external subobject to a local export does not count as an external
		/// dependency on a local definition, so the presence or absence of this flag does not affect whether the association is allowed or
		/// not. On the other hand if the current collection defines a subobject association for a locally defined subobject to an external
		/// export (e.g. shader), that counts as an external dependency on a local definition and this flag must be set.
		/// </para>
		/// <para>
		/// Regardless of the presence or absence of this flag, shader entrypoints (such as hit groups or miss shaders) in the collection
		/// are visible as entrypoints to a containing state object (e.g. RTPSO) if exported by it. In the case of an RTPSO, the exported
		/// entrypoints can be used in shader tables for raytracing.
		/// </para>
		/// </summary>
		D3D12_STATE_OBJECT_FLAG_ALLOW_EXTERNAL_DEPENDENCIES_ON_LOCAL_DEFINITIONS = 0x2,

		/// <summary>
		/// The presence of this flag in an executable state object, e.g. raytracing pipeline, allows the state object to be passed into
		/// AddToStateObject() calls, either as the original state object, or the portion being added.
		/// <para>
		/// The presence of this flag in a collection state object means the collection can be imported by executable state objects (e.g.
		/// raytracing pipelines) regardless of whether they have also set this flag. The absence of this flag in a collection state object
		/// means the collection can only be imported by executable state objects that also do not set this flag.
		/// </para>
		/// </summary>
		D3D12_STATE_OBJECT_FLAG_ALLOW_STATE_OBJECT_ADDITIONS = 0x4,

		/// <summary>
		/// All nodes in work graphs in the state object get their global root signature bindings from graphics state as opposed to compute
		/// state. e.g. pCommandList-&gt;SetGraphicsRoot*() APIs as opposed to pCommandList-&gt;SetComputeRoot*() APIs. This flag must be
		/// specified for state objects that contain work graphs using graphics nodes. For work graphs that don’t use graphics nodes, this
		/// flag can be used optionally. It is only available when D3D12_WORK_GRAPHS_TIER_1_1 is supported.
		/// </summary>
		D3D12_STATE_OBJECT_FLAG_WORK_GRAPHS_USE_GRAPHICS_STATE_FOR_GLOBAL_ROOT_SIGNATURE = 0x40,
	}

	/// <summary>Specifies the type of a state object. Use with <c>D3D12_STATE_OBJECT_DESC</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_state_object_type typedef enum D3D12_STATE_OBJECT_TYPE {
	// D3D12_STATE_OBJECT_TYPE_COLLECTION = 0, D3D12_STATE_OBJECT_TYPE_RAYTRACING_PIPELINE = 3, D3D12_STATE_OBJECT_TYPE_EXECUTABLE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_STATE_OBJECT_TYPE")]
	public enum D3D12_STATE_OBJECT_TYPE
	{
		/// <summary>
		/// <para>Value: 0 Collection state object. This can hold individual shaders but not generic program or work graph definitions.</para>
		/// </summary>
		D3D12_STATE_OBJECT_TYPE_COLLECTION,

		/// <summary>
		/// <para>
		/// Value: 3 Raytracing pipeline state object. For now at least, raytracing pipelines can only be defined here, and not in
		///        EXECUTABLE state objects below.
		/// </para>
		/// </summary>
		D3D12_STATE_OBJECT_TYPE_RAYTRACING_PIPELINE = 3,

		/// <summary>
		/// State object that holds one or more programs. This could hold zero or more work graphs, as well as zero or more compute,
		/// graphics and mesh shading programs. A raytracing pipelines are not supported here (though using RayQuery in non-raytracing
		/// shader stages is fine).
		/// </summary>
		D3D12_STATE_OBJECT_TYPE_EXECUTABLE = 4
	}

	/// <summary>The type of a state subobject. Use with <c>D3D12_STATE_SUBOBJECT</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_state_subobject_type typedef enum D3D12_STATE_SUBOBJECT_TYPE
	// { D3D12_STATE_SUBOBJECT_TYPE_STATE_OBJECT_CONFIG = 0, D3D12_STATE_SUBOBJECT_TYPE_GLOBAL_ROOT_SIGNATURE = 1,
	// D3D12_STATE_SUBOBJECT_TYPE_LOCAL_ROOT_SIGNATURE = 2, D3D12_STATE_SUBOBJECT_TYPE_NODE_MASK = 3,
	// D3D12_STATE_SUBOBJECT_TYPE_DXIL_LIBRARY = 5, D3D12_STATE_SUBOBJECT_TYPE_EXISTING_COLLECTION = 6,
	// D3D12_STATE_SUBOBJECT_TYPE_SUBOBJECT_TO_EXPORTS_ASSOCIATION = 7, D3D12_STATE_SUBOBJECT_TYPE_DXIL_SUBOBJECT_TO_EXPORTS_ASSOCIATION =
	// 8, D3D12_STATE_SUBOBJECT_TYPE_RAYTRACING_SHADER_CONFIG = 9, D3D12_STATE_SUBOBJECT_TYPE_RAYTRACING_PIPELINE_CONFIG = 10,
	// D3D12_STATE_SUBOBJECT_TYPE_HIT_GROUP = 11, D3D12_STATE_SUBOBJECT_TYPE_RAYTRACING_PIPELINE_CONFIG1,
	// D3D12_STATE_SUBOBJECT_TYPE_WORK_GRAPH, D3D12_STATE_SUBOBJECT_TYPE_STREAM_OUTPUT, D3D12_STATE_SUBOBJECT_TYPE_BLEND,
	// D3D12_STATE_SUBOBJECT_TYPE_SAMPLE_MASK, D3D12_STATE_SUBOBJECT_TYPE_RASTERIZER, D3D12_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL,
	// D3D12_STATE_SUBOBJECT_TYPE_INPUT_LAYOUT, D3D12_STATE_SUBOBJECT_TYPE_IB_STRIP_CUT_VALUE,
	// D3D12_STATE_SUBOBJECT_TYPE_PRIMITIVE_TOPOLOGY, D3D12_STATE_SUBOBJECT_TYPE_RENDER_TARGET_FORMATS,
	// D3D12_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL_FORMAT, D3D12_STATE_SUBOBJECT_TYPE_SAMPLE_DESC, D3D12_STATE_SUBOBJECT_TYPE_FLAGS,
	// D3D12_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL1, D3D12_STATE_SUBOBJECT_TYPE_VIEW_INSTANCING, D3D12_STATE_SUBOBJECT_TYPE_GENERIC_PROGRAM,
	// D3D12_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL2, D3D12_STATE_SUBOBJECT_TYPE_MAX_VALID } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_STATE_SUBOBJECT_TYPE")]
	public enum D3D12_STATE_SUBOBJECT_TYPE
	{
		/// <summary>Value: 0 Subobject type is D3D12_STATE_OBJECT_CONFIG.</summary>
		[CorrespondingType(typeof(D3D12_STATE_OBJECT_CONFIG))]
		D3D12_STATE_SUBOBJECT_TYPE_STATE_OBJECT_CONFIG,

		/// <summary>Value: 1 Subobject type is D3D12_GLOBAL_ROOT_SIGNATURE.</summary>
		[CorrespondingType(typeof(D3D12_GLOBAL_ROOT_SIGNATURE))]
		D3D12_STATE_SUBOBJECT_TYPE_GLOBAL_ROOT_SIGNATURE,

		/// <summary>Value: 2 Subobject type is D3D12_LOCAL_ROOT_SIGNATURE.</summary>
		[CorrespondingType(typeof(D3D12_LOCAL_ROOT_SIGNATURE))]
		D3D12_STATE_SUBOBJECT_TYPE_LOCAL_ROOT_SIGNATURE,

		/// <summary>
		/// <para>Value: 3 Subobject type is D3D12_NODE_MASK.</para>
		/// <para>
		/// <para>IMPORTANT</para>
		/// <para>
		/// On some versions of the DirectX Runtime, specifying a node via <c><b>D3D12_NODE_MASK</b></c> in a
		/// <c><b>D3D12_STATE_SUBOBJECT</b></c> with type <b>D3D12_STATE_SUBOBJECT_TYPE_NODE_MASK</b>, the runtime will incorrectly handle a
		/// node mask value of <c>0</c>, which should use node #1, which will lead to errors when attempting to use the state object later.
		/// Specify an explicit node value of 1, or omit the <c><b>D3D12_NODE_MASK</b></c> subobject to avoid this issue.
		/// </para>
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(D3D12_NODE_MASK))]
		D3D12_STATE_SUBOBJECT_TYPE_NODE_MASK,

		/// <summary>Value: 5 Subobject type is D3D12_DXIL_LIBRARY_DESC.</summary>
		[CorrespondingType(typeof(D3D12_DXIL_LIBRARY_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_DXIL_LIBRARY,

		/// <summary>Value: 6 Subobject type is D3D12_EXISTING_COLLECTION_DESC.</summary>
		[CorrespondingType(typeof(D3D12_EXISTING_COLLECTION_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_EXISTING_COLLECTION,

		/// <summary>Value: 7 Subobject type is D3D12_SUBOBJECT_TO_EXPORTS_ASSOCIATION.</summary>
		[CorrespondingType(typeof(D3D12_SUBOBJECT_TO_EXPORTS_ASSOCIATION))]
		D3D12_STATE_SUBOBJECT_TYPE_SUBOBJECT_TO_EXPORTS_ASSOCIATION,

		/// <summary>Value: 8 Subobject type is D3D12_DXIL_SUBOBJECT_TO_EXPORTS_ASSOCIATION.</summary>
		[CorrespondingType(typeof(D3D12_DXIL_SUBOBJECT_TO_EXPORTS_ASSOCIATION))]
		D3D12_STATE_SUBOBJECT_TYPE_DXIL_SUBOBJECT_TO_EXPORTS_ASSOCIATION,

		/// <summary>Value: 9 Subobject type is D3D12_RAYTRACING_SHADER_CONFIG.</summary>
		[CorrespondingType(typeof(D3D12_RAYTRACING_SHADER_CONFIG))]
		D3D12_STATE_SUBOBJECT_TYPE_RAYTRACING_SHADER_CONFIG,

		/// <summary>Value: 10 Subobject type is D3D12_RAYTRACING_PIPELINE_CONFIG.</summary>
		[CorrespondingType(typeof(D3D12_RAYTRACING_PIPELINE_CONFIG))]
		D3D12_STATE_SUBOBJECT_TYPE_RAYTRACING_PIPELINE_CONFIG,

		/// <summary>Value: 11 Subobject type is D3D12_HIT_GROUP_DESC</summary>
		[CorrespondingType(typeof(D3D12_HIT_GROUP_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_HIT_GROUP,

		/// <summary>The d3 D12 state subobject type raytracing pipeline confi g1</summary>
		[CorrespondingType(typeof(D3D12_RAYTRACING_PIPELINE_CONFIG1))]
		D3D12_STATE_SUBOBJECT_TYPE_RAYTRACING_PIPELINE_CONFIG1 = 12,

		/// <summary>The d3 D12 state subobject type work graph</summary>
		[CorrespondingType(typeof(D3D12_SET_WORK_GRAPH_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_WORK_GRAPH = 13,

		/// <summary>
		/// Stream output definition subobject that can used by a generic program. The contents are the pre-existing API struct:
		/// D3D12_STREAM_OUTPUT_DESC. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_STREAM_OUTPUT_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_STREAM_OUTPUT = 14,

		/// <summary>
		/// Blend description subobject that can be used by a generic program. The contents are the pre-existing API struct:
		/// D3D12_BLEND_DESC. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_BLEND_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_BLEND = 15,

		/// <summary>Sample mask subobject that can be used by a generic program. The contents are a UINT. Defaults if missing.</summary>
		[CorrespondingType(typeof(uint))]
		D3D12_STATE_SUBOBJECT_TYPE_SAMPLE_MASK = 16,

		/// <summary>
		/// Rasterizer description subobject that can be used by a generic program. The contents are the pre-existing API struct:
		/// D3D12_RASTERIZER_DESC2. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_RASTERIZER_DESC2))]
		D3D12_STATE_SUBOBJECT_TYPE_RASTERIZER = 17,

		/// <summary>
		/// Depth Stencil description subobject that can be used by a generic program. The contents are the pre-existing API struct:
		/// D3D12_DEPTH_STENCIL_DESC. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_DEPTH_STENCIL_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL = 18,

		/// <summary>
		/// Input layout description subobject that can be used by a generic program. The contents are the pre-existing API struct:
		/// D3D12_INPUT_LAYOUT_DESC. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_INPUT_LAYOUT_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_INPUT_LAYOUT = 19,

		/// <summary>
		/// Index buffer strip cut value description subobject that can be used by a generic program. The contents are the pre-existing API
		/// struct: D3D12_INDEX_BUFFER_STRIP_CUT_VALUE. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_INDEX_BUFFER_STRIP_CUT_VALUE))]
		D3D12_STATE_SUBOBJECT_TYPE_IB_STRIP_CUT_VALUE = 20,

		/// <summary>
		/// Primitive topology description subobject that can be used by a generic program. The contents are the pre-existing API struct:
		/// D3D12_PRIMITIVE_TOPOLOGY_TYPE. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_PRIMITIVE_TOPOLOGY_TYPE))]
		D3D12_STATE_SUBOBJECT_TYPE_PRIMITIVE_TOPOLOGY = 21,

		/// <summary>
		/// RenderTarget formats description subobject that can be used by a generic program. The contents are the pre-existing API struct:
		/// D3D12_RT_FORMAT_ARRAY. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_RT_FORMAT_ARRAY))]
		D3D12_STATE_SUBOBJECT_TYPE_RENDER_TARGET_FORMATS = 22,

		/// <summary>
		/// Depth Stencil format description subobject that can be used by a generic program. The contents are a DXGI_FORMAT. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(DXGI_FORMAT))]
		D3D12_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL_FORMAT = 23,

		/// <summary>
		/// Sample description subobject that can be used by a generic program. The contents are the pre-existing API struct:
		/// D3D12_SAMPLE_DESC. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(DXGI_SAMPLE_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_SAMPLE_DESC = 24,

		/// <summary>
		/// Pipeline state flags subobject that can be used by a generic program. The contents are the pre-existing flags enum:
		/// D3D12_PIPELINE_STATE_FLAGS. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_PIPELINE_STATE_FLAGS))]
		D3D12_STATE_SUBOBJECT_TYPE_FLAGS = 26,

		/// <summary>
		/// Depth Stencil (iteration 1) description subobject that can be used by a generic program. The contents are the pre-existing API
		/// struct: D3D12_DEPTH_STENCIL_DESC1. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_DEPTH_STENCIL_DESC1))]
		D3D12_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL1 = 27,

		/// <summary>
		/// View Instancing description subobject that can be used by a generic program. The contents are the pre-existing API struct:
		/// D3D12_VIEW_INSTANCING_DESC. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_VIEW_INSTANCING_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_VIEW_INSTANCING = 28,

		/// <summary>
		/// Generic program definition subobject. See D3D12_GENERIC_PROGRAM_DESC. This is proposed as part of graphics nodes, which aren’t
		/// supported yet.
		/// </summary>
		[CorrespondingType(typeof(D3D12_GENERIC_PROGRAM_DESC))]
		D3D12_STATE_SUBOBJECT_TYPE_GENERIC_PROGRAM = 29,

		/// <summary>
		/// Depth Stencil (iteration 2) description subobject that can be used by a generic program. The contents are the pre-existing API
		/// struct: D3D12_DEPTH_STENCIL_DESC2. Defaults if missing.
		/// </summary>
		[CorrespondingType(typeof(D3D12_DEPTH_STENCIL_DESC2))]
		D3D12_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL2 = 30,
	}

	/// <summary>Specifies the border color for a static sampler.</summary>
	/// <remarks>This enum is used by the <c>D3D12_STATIC_SAMPLER_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_static_border_color typedef enum D3D12_STATIC_BORDER_COLOR {
	// D3D12_STATIC_BORDER_COLOR_TRANSPARENT_BLACK = 0, D3D12_STATIC_BORDER_COLOR_OPAQUE_BLACK, D3D12_STATIC_BORDER_COLOR_OPAQUE_WHITE,
	// D3D12_STATIC_BORDER_COLOR_OPAQUE_BLACK_UINT, D3D12_STATIC_BORDER_COLOR_OPAQUE_WHITE_UINT } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_STATIC_BORDER_COLOR")]
	public enum D3D12_STATIC_BORDER_COLOR
	{
		/// <summary>
		/// <para>Value: 0 Indicates black, with the alpha component as fully transparent.</para>
		/// </summary>
		D3D12_STATIC_BORDER_COLOR_TRANSPARENT_BLACK,

		/// <summary>Indicates black, with the alpha component as fully opaque.</summary>
		D3D12_STATIC_BORDER_COLOR_OPAQUE_BLACK,

		/// <summary>Indicates white, with the alpha component as fully opaque.</summary>
		D3D12_STATIC_BORDER_COLOR_OPAQUE_WHITE,
	}

	/// <summary>Identifies the stencil operations that can be performed during depth-stencil testing.</summary>
	/// <remarks>This enum is used by the <c>D3D12_DEPTH_STENCILOP_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_stencil_op typedef enum D3D12_STENCIL_OP {
	// D3D12_STENCIL_OP_KEEP = 1, D3D12_STENCIL_OP_ZERO = 2, D3D12_STENCIL_OP_REPLACE = 3, D3D12_STENCIL_OP_INCR_SAT = 4,
	// D3D12_STENCIL_OP_DECR_SAT = 5, D3D12_STENCIL_OP_INVERT = 6, D3D12_STENCIL_OP_INCR = 7, D3D12_STENCIL_OP_DECR = 8 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_STENCIL_OP")]
	public enum D3D12_STENCIL_OP
	{
		/// <summary>
		/// <para>Value: 1 Keep the existing stencil data.</para>
		/// </summary>
		D3D12_STENCIL_OP_KEEP = 1,

		/// <summary>
		/// <para>Value: 2 Set the stencil data to 0.</para>
		/// </summary>
		D3D12_STENCIL_OP_ZERO,

		/// <summary>
		/// <para>Value: 3 Set the stencil data to the reference value set by calling</para>
		/// <para>ID3D12GraphicsCommandList::OMSetStencilRef</para>
		/// <para>.</para>
		/// </summary>
		D3D12_STENCIL_OP_REPLACE,

		/// <summary>
		/// <para>Value: 4 Increment the stencil value by 1, and clamp the result.</para>
		/// </summary>
		D3D12_STENCIL_OP_INCR_SAT,

		/// <summary>
		/// <para>Value: 5 Decrement the stencil value by 1, and clamp the result.</para>
		/// </summary>
		D3D12_STENCIL_OP_DECR_SAT,

		/// <summary>
		/// <para>Value: 6 Invert the stencil data.</para>
		/// </summary>
		D3D12_STENCIL_OP_INVERT,

		/// <summary>
		/// <para>Value: 7 Increment the stencil value by 1, and wrap the result if necessary.</para>
		/// </summary>
		D3D12_STENCIL_OP_INCR,

		/// <summary>
		/// <para>Value: 8 Decrement the stencil value by 1, and wrap the result if necessary.</para>
		/// </summary>
		D3D12_STENCIL_OP_DECR,
	}

	/// <summary>Identifies a technique for resolving texture coordinates that are outside of the boundaries of a texture.</summary>
	/// <remarks>This enum is used by the <c>D3D12_SAMPLER_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_texture_address_mode typedef enum D3D12_TEXTURE_ADDRESS_MODE
	// { D3D12_TEXTURE_ADDRESS_MODE_WRAP = 1, D3D12_TEXTURE_ADDRESS_MODE_MIRROR = 2, D3D12_TEXTURE_ADDRESS_MODE_CLAMP = 3,
	// D3D12_TEXTURE_ADDRESS_MODE_BORDER = 4, D3D12_TEXTURE_ADDRESS_MODE_MIRROR_ONCE = 5 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_TEXTURE_ADDRESS_MODE")]
	public enum D3D12_TEXTURE_ADDRESS_MODE
	{
		/// <summary>
		/// <para>Value: 1 Tile the texture at every (u,v) integer junction.</para>
		/// <para>For example, for u values between 0 and 3, the texture is repeated three times.</para>
		/// </summary>
		D3D12_TEXTURE_ADDRESS_MODE_WRAP = 1,

		/// <summary>
		/// <para>Value: 2 Flip the texture at every (u,v) integer junction.</para>
		/// <para>
		/// For u values between 0 and 1, for example, the texture is addressed normally; between 1 and 2, the texture is flipped
		/// (mirrored); between 2 and 3, the texture is normal again; and so on.
		/// </para>
		/// </summary>
		D3D12_TEXTURE_ADDRESS_MODE_MIRROR,

		/// <summary>
		/// <para>Value: 3 Texture coordinates outside the range [0.0, 1.0] are set to the texture color at 0.0 or 1.0, respectively.</para>
		/// </summary>
		D3D12_TEXTURE_ADDRESS_MODE_CLAMP,

		/// <summary>
		/// <para>Value: 4 Texture coordinates outside the range [0.0, 1.0] are set to the border color specified in D3D12_SAMPLER_DESC or HLSL code.</para>
		/// </summary>
		D3D12_TEXTURE_ADDRESS_MODE_BORDER,

		/// <summary>
		/// <para>Value: 5 Similar to D3D12_TEXTURE_ADDRESS_MODE_MIRROR and D3D12_TEXTURE_ADDRESS_MODE_CLAMP.</para>
		/// <para>Takes the absolute value of the texture coordinate (thus, mirroring around 0), and then clamps to the maximum value.</para>
		/// </summary>
		D3D12_TEXTURE_ADDRESS_MODE_MIRROR_ONCE,
	}

	/// <summary/>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_texture_barrier_flags typedef enum
	// D3D12_TEXTURE_BARRIER_FLAGS { D3D12_TEXTURE_BARRIER_FLAG_NONE, D3D12_TEXTURE_BARRIER_FLAG_DISCARD } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_TEXTURE_BARRIER_FLAGS")]
	[Flags]
	public enum D3D12_TEXTURE_BARRIER_FLAGS
	{
		/// <summary/>
		D3D12_TEXTURE_BARRIER_FLAG_NONE = 0x0,

		/// <summary/>
		D3D12_TEXTURE_BARRIER_FLAG_DISCARD = 0x1,
	}

	/// <summary>Specifies what type of texture copy is to take place.</summary>
	/// <remarks>This enum is used by the <c>D3D12_TEXTURE_COPY_LOCATION</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_texture_copy_type typedef enum D3D12_TEXTURE_COPY_TYPE {
	// D3D12_TEXTURE_COPY_TYPE_SUBRESOURCE_INDEX = 0, D3D12_TEXTURE_COPY_TYPE_PLACED_FOOTPRINT = 1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_TEXTURE_COPY_TYPE")]
	public enum D3D12_TEXTURE_COPY_TYPE
	{
		/// <summary>
		/// <para>Value: 0 Indicates a subresource, identified by an index, is to be copied.</para>
		/// </summary>
		D3D12_TEXTURE_COPY_TYPE_SUBRESOURCE_INDEX,

		/// <summary>
		/// <para>Value: 1 Indicates a place footprint, identified by a D3D12_PLACED_SUBRESOURCE_FOOTPRINT structure, is to be copied.</para>
		/// </summary>
		D3D12_TEXTURE_COPY_TYPE_PLACED_FOOTPRINT,
	}

	/// <summary>Specifies texture layout options.</summary>
	/// <remarks>
	/// <para>This enum is used by the <c>D3D12_RESOURCE_DESC</c> structure.</para>
	/// <para>
	/// This enumeration controls the swizzle pattern of default textures and enable map support on default textures. Callers must query
	/// <c>D3D12_FEATURE_DATA_D3D12_OPTIONS</c> to ensure that each option is supported.
	/// </para>
	/// <para>
	/// The standard swizzle formats applies within each page-sized chunk, and pages are laid out in linear order with respect to one
	/// another. A 16-bit interleave pattern defines the conversion from pre-swizzled intra-page location to the post-swizzled location.
	/// </para>
	/// <para>
	/// To demonstrate, consider the 2D 32bpp swizzle format above. This is represented by the following interleave masks, where bits on the
	/// left are most-significant:
	/// </para>
	/// <para><c>UINT xBytesMask = 1010 1010 1000 1111 UINT yMask = 0101 0101 0111 0000</c></para>
	/// <para>To compute the swizzled address, the following code could be used (where the <b>_pdep_u32</b> intrinsic instruction is supported):</para>
	/// <para><c>UINT swizzledOffset = resourceBaseOffset + _pdep_u32(xOffset, xBytesMask) + _pdep_u32(yOffset, yBytesMask);</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_texture_layout typedef enum D3D12_TEXTURE_LAYOUT {
	// D3D12_TEXTURE_LAYOUT_UNKNOWN = 0, D3D12_TEXTURE_LAYOUT_ROW_MAJOR = 1, D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE = 2,
	// D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE = 3 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_TEXTURE_LAYOUT")]
	public enum D3D12_TEXTURE_LAYOUT
	{
		/// <summary>
		/// <para>Value: 0 Indicates that the layout is unknown, and is likely adapter-dependent.</para>
		/// <para>
		/// During creation, the driver chooses the most efficient layout based on other resource properties, especially resource size and flags.
		/// </para>
		/// <para>Prefer this choice unless certain functionality is required from another texture layout.</para>
		/// <para>Zero-copy texture upload optimizations exist for UMA architectures; see</para>
		/// <para>ID3D12Resource::WriteToSubresource</para>
		/// <para>.</para>
		/// </summary>
		D3D12_TEXTURE_LAYOUT_UNKNOWN,

		/// <summary>
		/// <para>Value: 1 Indicates that data for the texture is stored in row-major order (sometimes called "pitch-linear order").</para>
		/// <para>This texture layout locates consecutive texels of a row contiguously in memory, before the texels of the next row.</para>
		/// <para>
		/// Similarly, consecutive texels of a particular depth or array slice are contiguous in memory before the texels of the next depth
		/// or array slice.
		/// </para>
		/// <para>Padding may exist between rows and between depth or array slices to align collections of data.</para>
		/// <para>A stride is the distance in memory between rows, depth, or array slices; and it includes any padding.</para>
		/// <para>This texture layout enables sharing of the texture data between multiple adapters, when other layouts aren't available.</para>
		/// <para>Many restrictions apply, because this layout is generally not efficient for extensive usage:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The locality of nearby texels is not rotationally invariant.</description>
		/// </item>
		/// <item>
		/// <description>Only the following texture properties are supported:</description>
		/// </item>
		/// <item>
		/// <description>The texture must be created on a heap with <c>D3D12_HEAP_FLAG</c> _SHARED_CROSS_ADAPTER.</description>
		/// </item>
		/// </list>
		/// <para>
		/// Buffers are created with D3D12_TEXTURE_LAYOUT _ROW_MAJOR, because row-major texture data can be located in them without creating
		/// a texture object.
		/// </para>
		/// <para>This is commonly used for uploading or reading back texture data, especially for discrete/NUMA adapters.</para>
		/// <para>However, D3D12_TEXTURE_LAYOUT _ROW_MAJOR can also be used when marshaling texture data between GPUs or adapters.</para>
		/// <para>For examples of usage with</para>
		/// <para>ID3D12GraphicsCommandList::CopyTextureRegion</para>
		/// <para>, see some of the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>Default Texture Mapping and Standard Swizzle</c></description>
		/// </item>
		/// <item>
		/// <description><c>Predication</c></description>
		/// </item>
		/// <item>
		/// <description><c>Multi-engine synchronization</c></description>
		/// </item>
		/// <item>
		/// <description><c>Uploading Texture Data</c></description>
		/// </item>
		/// </list>
		/// </summary>
		D3D12_TEXTURE_LAYOUT_ROW_MAJOR,

		/// <summary>
		/// <para>Value: 2 Indicates that the layout within 64KB tiles and tail mip packing is up to the driver.</para>
		/// <para>No standard swizzle pattern.</para>
		/// <para>
		/// This texture layout is arranged into contiguous 64KB regions, also known as tiles, containing near equilateral amount of
		/// consecutive number of texels along each dimension.
		/// </para>
		/// <para>Tiles are arranged in row-major order.</para>
		/// <para>While there is no padding between tiles, there are typically unused texels within the last tile in each dimension.</para>
		/// <para>The layout of texels within the tile is undefined.</para>
		/// <para>
		/// Each subresource immediately follows where the previous subresource end, and the subresource order follows the same sequence as
		/// subresource ordinals.
		/// </para>
		/// <para>However, tail mip packing is adapter-specific.</para>
		/// <para>For more details, see tiled resource tier and</para>
		/// <para>ID3D12Device::GetResourceTiling</para>
		/// <para>.</para>
		/// <para>
		/// This texture layout enables partially resident or sparse texture scenarios when used together with virtual memory page mapping functionality.
		/// </para>
		/// <para>This texture layout must be used together with</para>
		/// <para>ID3D12Device::CreateReservedResource</para>
		/// <para>to enable the usage of</para>
		/// <para>ID3D12CommandQueue::UpdateTileMappings</para>
		/// <para>.</para>
		/// <para>Some restrictions apply to textures with this layout:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The adapter must support <c>D3D12_TILED_RESOURCES_TIER</c> 1 or greater.</description>
		/// </item>
		/// <item>
		/// <description>64KB alignment must be used.</description>
		/// </item>
		/// <item>
		/// <description><c>D3D12_RESOURCE_DIMENSION</c> _TEXTURE1D is not supported, nor are all formats.</description>
		/// </item>
		/// <item>
		/// <description>The tiled resource tier indicates whether textures with <c>D3D12_RESOURCE_DIMENSION</c> _TEXTURE3D is supported.</description>
		/// </item>
		/// </list>
		/// </summary>
		D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE,

		/// <summary>
		/// <para>Value: 3 Indicates that a default texture uses the standardized swizzle pattern.</para>
		/// <para>
		/// This texture layout is arranged the same way that D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE is, except that the layout of
		/// texels within the tile is defined. Tail mip packing is adapter-specific.
		/// </para>
		/// <para>This texture layout enables optimizations when marshaling data between multiple adapters or between the CPU and GPU.</para>
		/// <para>The amount of copying can be reduced when multiple components understand the texture memory layout.</para>
		/// <para>
		/// This layout is generally more efficient for extensive usage than row-major layout, due to the rotationally invariant locality of
		/// neighboring texels.
		/// </para>
		/// <para>
		/// This layout can typically only be used with adapters that support standard swizzle, but exceptions exist for cross-adapter
		/// shared heaps.
		/// </para>
		/// <para>The restrictions for this layout are that the following aren't supported:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>D3D12_RESOURCE_DIMENSION</c> _TEXTURE1D</description>
		/// </item>
		/// <item>
		/// <description>Multi-sample anti-aliasing (MSAA)</description>
		/// </item>
		/// <item>
		/// <description><c>D3D12_RESOURCE_FLAG</c> _ALLOW_DEPTH_STENCIL</description>
		/// </item>
		/// <item>
		/// <description>Formats within the <c>DXGI_FORMAT</c> _R32G32B32_TYPELESS group</description>
		/// </item>
		/// </list>
		/// </summary>
		D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE,
	}

	/// <summary>Specifies how to copy a tile.</summary>
	/// <remarks>This enum is used by the <c>CopyTiles</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_tile_copy_flags typedef enum D3D12_TILE_COPY_FLAGS {
	// D3D12_TILE_COPY_FLAG_NONE = 0, D3D12_TILE_COPY_FLAG_NO_HAZARD = 0x1, D3D12_TILE_COPY_FLAG_LINEAR_BUFFER_TO_SWIZZLED_TILED_RESOURCE =
	// 0x2, D3D12_TILE_COPY_FLAG_SWIZZLED_TILED_RESOURCE_TO_LINEAR_BUFFER = 0x4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_TILE_COPY_FLAGS")]
	[Flags]
	public enum D3D12_TILE_COPY_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No tile-copy flags are specified.</para>
		/// </summary>
		D3D12_TILE_COPY_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 0x1 Indicates that the GPU isn't currently referencing any of the</para>
		/// <para>portions of destination memory being written.</para>
		/// </summary>
		D3D12_TILE_COPY_FLAG_NO_HAZARD = 0x1,

		/// <summary>
		/// <para>Value: 0x2 Indicates that the</para>
		/// <para>ID3D12GraphicsCommandList::CopyTiles</para>
		/// <para>operation involves copying a linear buffer to a swizzled tiled resource. This means to copy tile data from the</para>
		/// <para>specified buffer location, reading tiles sequentially,</para>
		/// <para>to the specified tile region (in x,y,z order if the region is a box), swizzling to optimal hardware memory layout as needed.</para>
		/// <para>In this</para>
		/// <para>ID3D12GraphicsCommandList::CopyTiles</para>
		/// <para>call, you specify the source data with the pBuffer parameter and the destination with the pTiledResource parameter.</para>
		/// </summary>
		D3D12_TILE_COPY_FLAG_LINEAR_BUFFER_TO_SWIZZLED_TILED_RESOURCE = 0x2,

		/// <summary>
		/// <para>Value: 0x4 Indicates that the</para>
		/// <para>ID3D12GraphicsCommandList::CopyTiles</para>
		/// <para>
		/// operation involves copying a swizzled tiled resource to a linear buffer. This means to copy tile data from the tile region,
		/// reading tiles sequentially (in x,y,z order if the region is a box),
		/// </para>
		/// <para>to the specified buffer location, deswizzling to linear memory layout as needed.</para>
		/// <para>In this</para>
		/// <para>ID3D12GraphicsCommandList::CopyTiles</para>
		/// <para>call, you specify the source data with the pTiledResource parameter and the destination with the pBuffer parameter.</para>
		/// </summary>
		D3D12_TILE_COPY_FLAG_SWIZZLED_TILED_RESOURCE_TO_LINEAR_BUFFER = 0x4,
	}

	/// <summary>Specifies how to perform a tile-mapping operation.</summary>
	/// <remarks>
	/// <para>This enum is used by the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>CopyTileMappings</c></description>
	/// </item>
	/// <item>
	/// <description><c>UpdateTileMappings</c></description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_tile_mapping_flags typedef enum D3D12_TILE_MAPPING_FLAGS {
	// D3D12_TILE_MAPPING_FLAG_NONE = 0, D3D12_TILE_MAPPING_FLAG_NO_HAZARD = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_TILE_MAPPING_FLAGS")]
	[Flags]
	public enum D3D12_TILE_MAPPING_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No tile-mapping flags are specified.</para>
		/// </summary>
		D3D12_TILE_MAPPING_FLAG_NONE,

		/// <summary>
		/// <para>Value: 0x1 Unsupported, do not use.</para>
		/// </summary>
		D3D12_TILE_MAPPING_FLAG_NO_HAZARD,
	}

	/// <summary>Specifies a range of tile mappings.</summary>
	/// <remarks>Use these flags with <c>ID3D12CommandQueue::UpdateTileMappings</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_tile_range_flags typedef enum D3D12_TILE_RANGE_FLAGS {
	// D3D12_TILE_RANGE_FLAG_NONE = 0, D3D12_TILE_RANGE_FLAG_NULL = 1, D3D12_TILE_RANGE_FLAG_SKIP = 2,
	// D3D12_TILE_RANGE_FLAG_REUSE_SINGLE_TILE = 4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_TILE_RANGE_FLAGS")]
	[Flags]
	public enum D3D12_TILE_RANGE_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 No tile-mapping flags are specified.</para>
		/// </summary>
		D3D12_TILE_RANGE_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>Value: 1 The tile range is NULL.</para>
		/// </summary>
		D3D12_TILE_RANGE_FLAG_NULL = 0x1,

		/// <summary>
		/// <para>Value: 2 Skip the tile range.</para>
		/// </summary>
		D3D12_TILE_RANGE_FLAG_SKIP = 0x2,

		/// <summary>
		/// <para>Value: 4 Reuse a single tile in the tile range.</para>
		/// </summary>
		D3D12_TILE_RANGE_FLAG_REUSE_SINGLE_TILE = 0x4,
	}

	/// <summary>Identifies the tier level at which tiled resources are supported.</summary>
	/// <remarks>
	/// <para>This enum is used by the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS</c> structure.</para>
	/// <para>There are three discrete pieces of functionality bundled together for tiled resource functionality:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// A tile-based texture layout option where nearby texel addresses contain nearby data coordinates. A tile of texels contains nearly
	/// the same amount of texels in each cardinal dimension of the resource. This layout is represented in D3D12 by <c>D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE</c>.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Reserve a region of virtual address space for a resource, where each page is initially NULL-mapped. In D3D12, this is operation is
	/// encapsulated within <c>ID3D12Device::CreateReservedResource</c>, which only works with textures that have the
	/// D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE layout.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// The ability to change page mappings and manipulate texture data on tile granularities. In D3D12, these operations are
	/// <c>ID3D12CommandQueue::UpdateTileMappings</c>, <c>ID3D12CommandQueue::CopyTileMappings</c>, and <c>ID3D12GraphicsCommandList::CopyTiles</c>.
	/// </description>
	/// </item>
	/// </list>
	/// <para>Three significant changes over D3D11 are:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Tile pools are replaced by heaps. Heaps provide a superset of capabilities than D3D11 tile pools do.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Reserved resources may be mapped to pages from multiple heaps at the same time. The D3D11 restriction that all non-NULL mapped pages
	/// must come from the same heap does not exist.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Applications should be aware of GPU virtual address capabilities, which enable litmus tests for particular usage scenarios. See <c>D3D12_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT</c>.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_tiled_resources_tier typedef enum D3D12_TILED_RESOURCES_TIER
	// { D3D12_TILED_RESOURCES_TIER_NOT_SUPPORTED = 0, D3D12_TILED_RESOURCES_TIER_1 = 1, D3D12_TILED_RESOURCES_TIER_2 = 2,
	// D3D12_TILED_RESOURCES_TIER_3 = 3, D3D12_TILED_RESOURCES_TIER_4 = 4 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_TILED_RESOURCES_TIER")]
	public enum D3D12_TILED_RESOURCES_TIER
	{
		/// <summary>
		/// <para>Value: 0 Indicates that textures cannot be created with the D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE layout.</para>
		/// <para>ID3D12Device::CreateReservedResource</para>
		/// <para>cannot be used, not even for buffers.</para>
		/// </summary>
		D3D12_TILED_RESOURCES_TIER_NOT_SUPPORTED,

		/// <summary>
		/// <para>Value: 1 Indicates that 2D textures can be created with the D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE layout.</para>
		/// <para>Limitations exist for certain resource formats and properties.</para>
		/// <para>For more details, see D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE.</para>
		/// <para>ID3D12Device::CreateReservedResource</para>
		/// <para>can be used.</para>
		/// <para>GPU reads or writes to NULL mappings are undefined.</para>
		/// <para>
		/// Applications are encouraged to workaround this limitation by repeatedly mapping the same page to everywhere a NULL mapping
		/// would've been used.
		/// </para>
		/// <para>
		/// When the size of a texture mipmap level is an integer multiple of the standard tile shape for its format, it is guaranteed to be nonpacked.
		/// </para>
		/// </summary>
		D3D12_TILED_RESOURCES_TIER_1,

		/// <summary>
		/// <para>Value: 2 Indicates that a superset of Tier_1 functionality is supported, including this additional support:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// When the size of a texture mipmap level is at least one standard tile shape for its format, the mipmap level is guaranteed to be
		/// nonpacked. For more info, see <c>D3D12_PACKED_MIP_INFO</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Shader instructions are available for clamping level-of-detail (LOD) and for obtaining status about the shader operation. For
		/// info about one of these shader instructions, see Sample(S,float,int,float,uint). <c>Sample(S,float,int,float,uint)</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Reading from <b>NULL</b>-mapped tiles treat that sampled value as zero. Writes to <b>NULL</b>-mapped tiles are discarded.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Adapters that support feature level 12_0 all support TIER_2 or greater.</para>
		/// </summary>
		D3D12_TILED_RESOURCES_TIER_2,

		/// <summary>
		/// <para>Value: 3 Indicates that a superset of Tier 2 is supported, with the addition that 3D textures (</para>
		/// <para>Volume Tiled Resources</para>
		/// <para>) are supported.</para>
		/// </summary>
		D3D12_TILED_RESOURCES_TIER_3,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// </summary>
		D3D12_TILED_RESOURCES_TIER_4,
	}

	/// <summary>Defines constants that specify TBD</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_tri_state typedef enum D3D12_TRI_STATE {
	// D3D12_TRI_STATE_UNKNOWN, D3D12_TRI_STATE_FALSE, D3D12_TRI_STATE_TRUE } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_TRI_STATE")]
	public enum D3D12_TRI_STATE
	{
		/// <summary>Specifies TBD.</summary>
		D3D12_TRI_STATE_UNKNOWN = -1,

		/// <summary>Specifies TBD.</summary>
		D3D12_TRI_STATE_FALSE = 0,

		/// <summary>Specifies TBD.</summary>
		D3D12_TRI_STATE_TRUE = 1,
	}

	/// <summary>Identifies unordered-access view options.</summary>
	/// <remarks>
	/// Specify one of the values in this enumeration in the <b>ViewDimension</b> member of a <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c> structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_uav_dimension typedef enum D3D12_UAV_DIMENSION {
	// D3D12_UAV_DIMENSION_UNKNOWN = 0, D3D12_UAV_DIMENSION_BUFFER = 1, D3D12_UAV_DIMENSION_TEXTURE1D = 2,
	// D3D12_UAV_DIMENSION_TEXTURE1DARRAY = 3, D3D12_UAV_DIMENSION_TEXTURE2D = 4, D3D12_UAV_DIMENSION_TEXTURE2DARRAY = 5,
	// D3D12_UAV_DIMENSION_TEXTURE2DMS, D3D12_UAV_DIMENSION_TEXTURE2DMSARRAY, D3D12_UAV_DIMENSION_TEXTURE3D = 8 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_UAV_DIMENSION")]
	public enum D3D12_UAV_DIMENSION
	{
		/// <summary>
		/// <para>Value: 0 The view type is unknown.</para>
		/// </summary>
		D3D12_UAV_DIMENSION_UNKNOWN,

		/// <summary>
		/// <para>Value: 1 View the resource as a buffer.</para>
		/// </summary>
		D3D12_UAV_DIMENSION_BUFFER,

		/// <summary>
		/// <para>Value: 2 View the resource as a 1D texture.</para>
		/// </summary>
		D3D12_UAV_DIMENSION_TEXTURE1D,

		/// <summary>
		/// <para>Value: 3 View the resource as a 1D texture array.</para>
		/// </summary>
		D3D12_UAV_DIMENSION_TEXTURE1DARRAY,

		/// <summary>
		/// <para>Value: 4 View the resource as a 2D texture.</para>
		/// </summary>
		D3D12_UAV_DIMENSION_TEXTURE2D,

		/// <summary>
		/// <para>Value: 5 View the resource as a 2D texture array.</para>
		/// </summary>
		D3D12_UAV_DIMENSION_TEXTURE2DARRAY,

		/// <summary>
		/// <para>Value: 8 View the resource as a 3D texture array.</para>
		/// </summary>
		D3D12_UAV_DIMENSION_TEXTURE3D = 8,
	}

	/// <summary>
	/// Defines constants that specify a shading rate tier (for variable-rate shading, or VRS). For more info, see <c>Variable-rate shading (VRS)</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_variable_shading_rate_tier typedef enum
	// D3D12_VARIABLE_SHADING_RATE_TIER { D3D12_VARIABLE_SHADING_RATE_TIER_NOT_SUPPORTED = 0, D3D12_VARIABLE_SHADING_RATE_TIER_1 = 1,
	// D3D12_VARIABLE_SHADING_RATE_TIER_2 = 2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_VARIABLE_SHADING_RATE_TIER")]
	public enum D3D12_VARIABLE_SHADING_RATE_TIER
	{
		/// <summary>
		/// <para>Value: 0 Specifies that variable-rate shading is not supported.</para>
		/// </summary>
		D3D12_VARIABLE_SHADING_RATE_TIER_NOT_SUPPORTED,

		/// <summary>
		/// <para>Value: 1 Specifies that variable-rate shading tier 1 is supported.</para>
		/// </summary>
		D3D12_VARIABLE_SHADING_RATE_TIER_1,

		/// <summary>
		/// <para>Value: 2 Specifies that variable-rate shading tier 2 is supported.</para>
		/// </summary>
		D3D12_VARIABLE_SHADING_RATE_TIER_2,
	}

	/// <summary>Specifies options for view instancing.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_view_instancing_flags typedef enum
	// D3D12_VIEW_INSTANCING_FLAGS { D3D12_VIEW_INSTANCING_FLAG_NONE = 0, D3D12_VIEW_INSTANCING_FLAG_ENABLE_VIEW_INSTANCE_MASKING = 0x1 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_VIEW_INSTANCING_FLAGS")]
	[Flags]
	public enum D3D12_VIEW_INSTANCING_FLAGS
	{
		/// <summary>
		/// <para>Value: 0 Indicates a default view instancing configuration.</para>
		/// </summary>
		D3D12_VIEW_INSTANCING_FLAG_NONE,

		/// <summary>
		/// <para>Value: 0x1 Enables view instance masking.</para>
		/// </summary>
		D3D12_VIEW_INSTANCING_FLAG_ENABLE_VIEW_INSTANCE_MASKING,
	}

	/// <summary>Indicates the tier level at which view instancing is supported.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_view_instancing_tier typedef enum D3D12_VIEW_INSTANCING_TIER
	// { D3D12_VIEW_INSTANCING_TIER_NOT_SUPPORTED = 0, D3D12_VIEW_INSTANCING_TIER_1 = 1, D3D12_VIEW_INSTANCING_TIER_2 = 2,
	// D3D12_VIEW_INSTANCING_TIER_3 = 3 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_VIEW_INSTANCING_TIER")]
	public enum D3D12_VIEW_INSTANCING_TIER
	{
		/// <summary>
		/// <para>Value: 0 View instancing is not supported.</para>
		/// </summary>
		D3D12_VIEW_INSTANCING_TIER_NOT_SUPPORTED,

		/// <summary>
		/// <para>Value: 1 View instancing is supported by draw-call level looping only.</para>
		/// </summary>
		D3D12_VIEW_INSTANCING_TIER_1,

		/// <summary>
		/// <para>Value: 2 
		/// View instancing is supported by draw-call level looping at worst, but the GPU can perform view instancing more efficiently in
		/// certain circumstances which are architecture-dependent.
		/// </para>
		/// </summary>
		D3D12_VIEW_INSTANCING_TIER_2,

		/// <summary>
		/// <para>Value: 3 
		/// View instancing is supported and instancing begins with the first shader stage that references SV_ViewID or with rasterization
		/// if no shader stage references SV_ViewID. This means that redundant work is eliminated across view instances when it's not
		/// dependent on SV_ViewID. Before rasterization, work that doesn't directly depend on SV_ViewID is shared across all views; only
		/// work that depends on SV_ViewID is repeated for each view.
		/// </para>
		/// <para>
		/// <b>Note</b>  If a hull shader produces tessellation factors that are dependent on SV_ViewID, then tessellation and all
		/// subsequent work must be repeated per-view. Similarly, if the amount of geometry produced by the geometry shader depends on
		/// SV_ViewID, then the geometry shader must be repeated per-view before proceeding to rasterization.
		/// </para>
		/// <para></para>
		/// <para>
		/// View instance masking only effects whether work that directly depends on SV_ViewID is performed, not the entire loop iteration
		/// (per-view). If the view instance mask is non-0, some work that depends on SV_ViewID might still be performed on masked-off
		/// pixels but will have no externally-visible effect; for example, no UAV writes are performed and clipping/rasterization is not
		/// invoked. If the view instance mask is 0 no work is performed, including work that's not dependent on SV_ViewID.
		/// </para>
		/// </summary>
		D3D12_VIEW_INSTANCING_TIER_3,
	}

	/// <summary>Defines constants that specify a level of support for WaveMMA (wave_matrix) operations.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_wave_mma_tier typedef enum D3D12_WAVE_MMA_TIER {
	// D3D12_WAVE_MMA_TIER_NOT_SUPPORTED = 0, D3D12_WAVE_MMA_TIER_1_0 = 10 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_WAVE_MMA_TIER")]
	public enum D3D12_WAVE_MMA_TIER
	{
		/// <summary>
		/// <para>Value: 0 Specifies that WaveMMA (wave_matrix) operations are not supported.</para>
		/// </summary>
		D3D12_WAVE_MMA_TIER_NOT_SUPPORTED,

		/// <summary>
		/// <para>Value: 10 Specifies that WaveMMA (wave_matrix) operations are supported.</para>
		/// </summary>
		D3D12_WAVE_MMA_TIER_1_0 = 10,
	}

	/// <summary>Specifies the mode used by a <b>WriteBufferImmediate</b> operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_writebufferimmediate_mode typedef enum
	// D3D12_WRITEBUFFERIMMEDIATE_MODE { D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT = 0, D3D12_WRITEBUFFERIMMEDIATE_MODE_MARKER_IN = 0x1,
	// D3D12_WRITEBUFFERIMMEDIATE_MODE_MARKER_OUT = 0x2 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_WRITEBUFFERIMMEDIATE_MODE")]
	public enum D3D12_WRITEBUFFERIMMEDIATE_MODE
	{
		/// <summary>
		/// <para>Value: 0 The write operation behaves the same as normal copy-write operations.</para>
		/// </summary>
		D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT,

		/// <summary>
		/// <para>Value: 0x1 
		/// The write operation is guaranteed to occur after all preceding commands in the command stream have started, including previous
		/// WriteBufferImmediate operations.
		/// </para>
		/// </summary>
		D3D12_WRITEBUFFERIMMEDIATE_MODE_MARKER_IN,

		/// <summary>
		/// <para>Value: 0x2 
		/// The write operation is deferred until all previous commands in the command stream have completed through the GPU pipeline,
		/// including previous WriteBufferImmediate operations. Write operations that specify D3D12_WRITEBUFFERIMMEDIATE_MODE_MARKER_OUT
		/// don't block subsequent operations from starting. If there are no previous operations in the command stream, then the write
		/// operation behaves as if D3D12_WRITEBUFFERIMMEDIATE_MODE_MARKER_IN was specified.
		/// </para>
		/// </summary>
		D3D12_WRITEBUFFERIMMEDIATE_MODE_MARKER_OUT,
	}
}