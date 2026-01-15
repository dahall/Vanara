namespace Vanara.PInvoke;

public static partial class D3D11
{
	private const string Lib_D3D11SDKLayers = "d3d11sdklayers.dll";

	/// <summary>Specifies how ID3D11ShaderTraceFactory::CreateShaderTrace creates the shader-trace object.</summary>
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_SHADER_TRACE_DESC")]
	[Flags]
	public enum D3D11_SHADER_TRACE_FLAG : uint
	{
		/// <summary>The shader trace object records register-writes.</summary>
		D3D11_SHADER_TRACE_FLAG_RECORD_REGISTER_WRITES = 0x1,

		/// <summary>The shader trace object records register-reads.</summary>
		D3D11_SHADER_TRACE_FLAG_RECORD_REGISTER_READS = 0x2
	}

	/// <summary>Identifies a shader type for tracing.</summary>
	/// <remarks>
	/// <para><c>D3D11_SHADER_TYPE</c> identifies the type of shader in a D3D11_SHADER_TRACE_DESC structure.</para>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ne-d3d11shadertracing-d3d11_shader_type typedef enum
	// D3D11_SHADER_TYPE { D3D11_VERTEX_SHADER = 1, D3D11_HULL_SHADER = 2, D3D11_DOMAIN_SHADER = 3, D3D11_GEOMETRY_SHADER = 4,
	// D3D11_PIXEL_SHADER = 5, D3D11_COMPUTE_SHADER = 6 } ;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NE:d3d11shadertracing.D3D11_SHADER_TYPE")]
	public enum D3D11_SHADER_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Identifies a vertex shader.</para>
		/// </summary>
		D3D11_VERTEX_SHADER = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Identifies a hull shader.</para>
		/// </summary>
		D3D11_HULL_SHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Identifies a domain shader.</para>
		/// </summary>
		D3D11_DOMAIN_SHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Identifies a geometry shader.</para>
		/// </summary>
		D3D11_GEOMETRY_SHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Identifies a pixel shader.</para>
		/// </summary>
		D3D11_PIXEL_SHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Identifies a compute shader.</para>
		/// </summary>
		D3D11_COMPUTE_SHADER,
	}

	/// <summary>The component trace mask for each input v# register.</summary>
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_TRACE_VALUE")]
	[Flags]
	public enum D3D11_TRACE_COMPONENT_MASK : byte
	{
		/// <summary>The x component of the trace mask.</summary>
		D3D11_TRACE_COMPONENT_X = 0x1,

		/// <summary>The y component of the trace mask.</summary>
		D3D11_TRACE_COMPONENT_Y = 0x2,

		/// <summary>The depth z component of the trace mask.</summary>
		D3D11_TRACE_COMPONENT_Z = 0x4,

		/// <summary>The depth w component of the trace mask.</summary>
		D3D11_TRACE_COMPONENT_W = 0x8,
	}

	/// <summary>Identifies the type of geometry shader input primitive.</summary>
	/// <remarks>
	/// <para><c>D3D11_TRACE_GS_INPUT_PRIMITIVE</c> identifies the type of geometry shader input primitive in a D3D11_TRACE_STATS structure.</para>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ne-d3d11shadertracing-d3d11_trace_gs_input_primitive typedef
	// enum D3D11_TRACE_GS_INPUT_PRIMITIVE { D3D11_TRACE_GS_INPUT_PRIMITIVE_UNDEFINED = 0, D3D11_TRACE_GS_INPUT_PRIMITIVE_POINT = 1,
	// D3D11_TRACE_GS_INPUT_PRIMITIVE_LINE = 2, D3D11_TRACE_GS_INPUT_PRIMITIVE_TRIANGLE = 3, D3D11_TRACE_GS_INPUT_PRIMITIVE_LINE_ADJ = 6,
	// D3D11_TRACE_GS_INPUT_PRIMITIVE_TRIANGLE_ADJ = 7 } ;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NE:d3d11shadertracing.D3D11_TRACE_GS_INPUT_PRIMITIVE")]
	public enum D3D11_TRACE_GS_INPUT_PRIMITIVE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Identifies the geometry shader input primitive as undefined.</para>
		/// </summary>
		D3D11_TRACE_GS_INPUT_PRIMITIVE_UNDEFINED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Identifies the geometry shader input primitive as a point.</para>
		/// </summary>
		D3D11_TRACE_GS_INPUT_PRIMITIVE_POINT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Identifies the geometry shader input primitive as a line.</para>
		/// </summary>
		D3D11_TRACE_GS_INPUT_PRIMITIVE_LINE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Identifies the geometry shader input primitive as a triangle.</para>
		/// </summary>
		D3D11_TRACE_GS_INPUT_PRIMITIVE_TRIANGLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Identifies the geometry shader input primitive as an adjacent line.</para>
		/// </summary>
		D3D11_TRACE_GS_INPUT_PRIMITIVE_LINE_ADJ,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Identifies the geometry shader input primitive as an adjacent triangle.</para>
		/// </summary>
		D3D11_TRACE_GS_INPUT_PRIMITIVE_TRIANGLE_ADJ,
	}

	/// <summary>The component trace mask for each input v# register.</summary>
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_TRACE_VALUE")]
	[Flags]
	public enum D3D11_TRACE_MISC_OPERATIONS_MASK : ushort
	{
		/// <summary>The operation was a geometry shader data emit.</summary>
		D3D11_TRACE_MISC_GS_EMIT = 0x1,

		/// <summary>The operation was a geometry shader strip cut.</summary>
		D3D11_TRACE_MISC_GS_CUT = 0x2,

		/// <summary>The operation was a pixel shader discard, which rejects the pixel.</summary>
		D3D11_TRACE_MISC_PS_DISCARD = 0x4,

		/// <summary>Same as D3D11_TRACE_MISC_GS_EMIT, except in shader model 5 where you can specify a particular stream to emit to.</summary>
		D3D11_TRACE_MISC_GS_EMIT_STREAM = 0x8,

		/// <summary>Same as D3D11_TRACE_MISC_GS_CUT, except in shader model 5 where you can specify a particular stream to strip out.</summary>
		D3D11_TRACE_MISC_GS_CUT_STREAM = 0x10,

		/// <summary>
		/// The operation was a shader halt instruction, which stops shader execution. The HLSL abort intrinsic function causes a halt.
		/// </summary>
		D3D11_TRACE_MISC_HALT = 0x20,

		/// <summary>
		/// The operation was a shader message output, which can be logged to the information queue. The HLSL printf and errorf intrinsic
		/// functions cause messages.
		/// </summary>
		D3D11_TRACE_MISC_MESSAGE = 0x40,
	}

	/// <summary>Specifies more about the trace register.</summary>
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_SHADER_TRACE_DESC")]
	[Flags]
	public enum D3D11_TRACE_REGISTER_FLAGS : byte
	{
		/// <summary>Access to the register is part of the relative indexing of a register.</summary>
		D3D11_TRACE_REGISTER_FLAGS_RELATIVE_INDEXING = 0x1,
	}

	/// <summary>Identifies a type of trace register.</summary>
	/// <remarks>
	/// <para><c>D3D11_TRACE_REGISTER_TYPE</c> identifies the type of trace register in a D3D11_TRACE_REGISTER structure.</para>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ne-d3d11shadertracing-d3d11_trace_register_type typedef enum
	// D3D11_TRACE_REGISTER_TYPE { D3D11_TRACE_OUTPUT_NULL_REGISTER = 0, D3D11_TRACE_INPUT_REGISTER,
	// D3D11_TRACE_INPUT_PRIMITIVE_ID_REGISTER, D3D11_TRACE_IMMEDIATE_CONSTANT_BUFFER, D3D11_TRACE_TEMP_REGISTER,
	// D3D11_TRACE_INDEXABLE_TEMP_REGISTER, D3D11_TRACE_OUTPUT_REGISTER, D3D11_TRACE_OUTPUT_DEPTH_REGISTER, D3D11_TRACE_CONSTANT_BUFFER,
	// D3D11_TRACE_IMMEDIATE32, D3D11_TRACE_SAMPLER, D3D11_TRACE_RESOURCE, D3D11_TRACE_RASTERIZER, D3D11_TRACE_OUTPUT_COVERAGE_MASK,
	// D3D11_TRACE_STREAM, D3D11_TRACE_THIS_POINTER, D3D11_TRACE_OUTPUT_CONTROL_POINT_ID_REGISTER,
	// D3D11_TRACE_INPUT_FORK_INSTANCE_ID_REGISTER, D3D11_TRACE_INPUT_JOIN_INSTANCE_ID_REGISTER, D3D11_TRACE_INPUT_CONTROL_POINT_REGISTER,
	// D3D11_TRACE_OUTPUT_CONTROL_POINT_REGISTER, D3D11_TRACE_INPUT_PATCH_CONSTANT_REGISTER, D3D11_TRACE_INPUT_DOMAIN_POINT_REGISTER,
	// D3D11_TRACE_UNORDERED_ACCESS_VIEW, D3D11_TRACE_THREAD_GROUP_SHARED_MEMORY, D3D11_TRACE_INPUT_THREAD_ID_REGISTER,
	// D3D11_TRACE_INPUT_THREAD_GROUP_ID_REGISTER, D3D11_TRACE_INPUT_THREAD_ID_IN_GROUP_REGISTER, D3D11_TRACE_INPUT_COVERAGE_MASK_REGISTER,
	// D3D11_TRACE_INPUT_THREAD_ID_IN_GROUP_FLATTENED_REGISTER, D3D11_TRACE_INPUT_GS_INSTANCE_ID_REGISTER,
	// D3D11_TRACE_OUTPUT_DEPTH_GREATER_EQUAL_REGISTER, D3D11_TRACE_OUTPUT_DEPTH_LESS_EQUAL_REGISTER, D3D11_TRACE_IMMEDIATE64,
	// D3D11_TRACE_INPUT_CYCLE_COUNTER_REGISTER, D3D11_TRACE_INTERFACE_POINTER } ;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NE:d3d11shadertracing.D3D11_TRACE_REGISTER_TYPE")]
	public enum D3D11_TRACE_REGISTER_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Output</para>
		/// <para>NULL</para>
		/// <para>register.</para>
		/// </summary>
		D3D11_TRACE_OUTPUT_NULL_REGISTER,

		/// <summary>Input register.</summary>
		D3D11_TRACE_INPUT_REGISTER,

		/// <summary>Input primitive ID register.</summary>
		D3D11_TRACE_INPUT_PRIMITIVE_ID_REGISTER,

		/// <summary>Immediate constant buffer.</summary>
		D3D11_TRACE_IMMEDIATE_CONSTANT_BUFFER,

		/// <summary>Temporary register.</summary>
		D3D11_TRACE_TEMP_REGISTER,

		/// <summary>Temporary register that can be indexed.</summary>
		D3D11_TRACE_INDEXABLE_TEMP_REGISTER,

		/// <summary>Output register.</summary>
		D3D11_TRACE_OUTPUT_REGISTER,

		/// <summary>Output oDepth register.</summary>
		D3D11_TRACE_OUTPUT_DEPTH_REGISTER,

		/// <summary>Constant buffer.</summary>
		D3D11_TRACE_CONSTANT_BUFFER,

		/// <summary>Immediate32 register.</summary>
		D3D11_TRACE_IMMEDIATE32,

		/// <summary>Sampler.</summary>
		D3D11_TRACE_SAMPLER,

		/// <summary>Resource.</summary>
		D3D11_TRACE_RESOURCE,

		/// <summary>Rasterizer.</summary>
		D3D11_TRACE_RASTERIZER,

		/// <summary>Output coverage mask.</summary>
		D3D11_TRACE_OUTPUT_COVERAGE_MASK,

		/// <summary>Stream.</summary>
		D3D11_TRACE_STREAM,

		/// <summary>This pointer.</summary>
		D3D11_TRACE_THIS_POINTER,

		/// <summary>Output control point ID register (this is actually an input; it defines the output that the thread controls).</summary>
		D3D11_TRACE_OUTPUT_CONTROL_POINT_ID_REGISTER,

		/// <summary>Input fork instance ID register.</summary>
		D3D11_TRACE_INPUT_FORK_INSTANCE_ID_REGISTER,

		/// <summary>Input join instance ID register.</summary>
		D3D11_TRACE_INPUT_JOIN_INSTANCE_ID_REGISTER,

		/// <summary>Input control point register.</summary>
		D3D11_TRACE_INPUT_CONTROL_POINT_REGISTER,

		/// <summary>Output control point register.</summary>
		D3D11_TRACE_OUTPUT_CONTROL_POINT_REGISTER,

		/// <summary>Input patch constant register.</summary>
		D3D11_TRACE_INPUT_PATCH_CONSTANT_REGISTER,

		/// <summary>Input domain point register.</summary>
		D3D11_TRACE_INPUT_DOMAIN_POINT_REGISTER,

		/// <summary>Unordered-access view.</summary>
		D3D11_TRACE_UNORDERED_ACCESS_VIEW,

		/// <summary>Thread group shared memory.</summary>
		D3D11_TRACE_THREAD_GROUP_SHARED_MEMORY,

		/// <summary>Input thread ID register.</summary>
		D3D11_TRACE_INPUT_THREAD_ID_REGISTER,

		/// <summary>Thread group ID register.</summary>
		D3D11_TRACE_INPUT_THREAD_GROUP_ID_REGISTER,

		/// <summary>Input thread ID in-group register.</summary>
		D3D11_TRACE_INPUT_THREAD_ID_IN_GROUP_REGISTER,

		/// <summary>Input coverage mask register.</summary>
		D3D11_TRACE_INPUT_COVERAGE_MASK_REGISTER,

		/// <summary>Input thread ID in-group flattened register.</summary>
		D3D11_TRACE_INPUT_THREAD_ID_IN_GROUP_FLATTENED_REGISTER,

		/// <summary>Input geometry shader (GS) instance ID register.</summary>
		D3D11_TRACE_INPUT_GS_INSTANCE_ID_REGISTER,

		/// <summary>Output oDepth greater than or equal register.</summary>
		D3D11_TRACE_OUTPUT_DEPTH_GREATER_EQUAL_REGISTER,

		/// <summary>Output oDepth less than or equal register.</summary>
		D3D11_TRACE_OUTPUT_DEPTH_LESS_EQUAL_REGISTER,

		/// <summary>Immediate64 register.</summary>
		D3D11_TRACE_IMMEDIATE64,

		/// <summary>Cycle counter register.</summary>
		D3D11_TRACE_INPUT_CYCLE_COUNTER_REGISTER,

		/// <summary>Interface pointer.</summary>
		D3D11_TRACE_INTERFACE_POINTER,
	}

	/// <summary>An <c>ID3D11ShaderTrace</c> interface implements methods for obtaining traces of shader executions.</summary>
	/// <remarks>
	/// <para>
	/// To retrieve an instance of <c>ID3D11ShaderTrace</c>, call the ID3D11ShaderTraceFactory::CreateShaderTrace method. To retrieve an
	/// instance of ID3D11ShaderTraceFactory, call IUnknown::QueryInterface on a ID3D11Device that you created with
	/// D3D11_CREATE_DEVICE_DEBUGGABLE. Although shader tracing operates without setting <c>D3D11_CREATE_DEVICE_DEBUGGABLE</c>, we recommend
	/// that you create a shader debugging device because some devices (for example, WARP devices) might make behind-the-scenes shader
	/// optimizations that will lead to slightly incorrect shader traces when <c>D3D11_CREATE_DEVICE_DEBUGGABLE</c> isn't set.
	/// </para>
	/// <para>All <c>ID3D11ShaderTrace</c> methods are thread safe.</para>
	/// <para>
	/// All <c>ID3D11ShaderTrace</c> methods immediately force the reference device to flush rendering commands. Therefore, the most current
	/// trace status is always available on the reference device. That is, if you expect a trace to be ready after a draw operation, it will
	/// be ready.
	/// </para>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nn-d3d11shadertracing-id3d11shadertrace
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NN:d3d11shadertracing.ID3D11ShaderTrace")]
	[ComImport, Guid("36b013e6-2811-4845-baa7-d623fe0df104"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ShaderTrace
	{
		/// <summary>Specifies that the shader trace recorded and is ready to use.</summary>
		/// <param name="pTestCount">
		/// An optional pointer to a variable that receives the number of times that a matching invocation for the trace occurred. If not
		/// used, set to NULL. For more information about this number, see Remarks.
		/// </param>
		/// <returns>
		/// <para><c>TraceReady</c> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> if the trace is ready.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c> if the trace is not ready.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>E_OUTOFMEMORY</c> if memory ran out while the trace was in the process of recording. You can try to record the trace again by
		/// calling ID3D11ShaderTrace::ResetTrace and then redrawing. If you decide not to record the trace again, release the
		/// ID3D11ShaderTrace interface.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in Direct3D 11 Return Codes.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a trace is meant to record invocation 3 but only two invocations have happened so far, <c>TraceReady</c> sets the variable to
		/// which <c>pTestCount</c> points to 2. You can use this value to understand why a trace is not ready yet. Conversely, the variable
		/// to which <c>pTestCount</c> points might be larger than the requested invocation count for a trace that is ready. You can use
		/// this value to determine the number of invocations that ran past the required trace invocation count. For example, you might not
		/// know the number of overdraws that occur on a pixel for a given shader in a draw call. If you can redraw the scene identically,
		/// you can set up the traces this next time based on the value that <c>TraceReady</c> returned at <c>pTestCount</c> on the first pass.
		/// </para>
		/// <para>
		/// If the shader trace recorded, you can successfully call the ID3D11ShaderTrace::GetTraceStats,
		/// ID3D11ShaderTrace::GetInitialRegisterContents, and ID3D11ShaderTrace::GetStep methods. You can call the
		/// ID3D11ShaderTrace::ResetTrace and ID3D11ShaderTrace::PSSelectStamp methods regardless of whether the shader trace recorded.
		/// </para>
		/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nf-d3d11shadertracing-id3d11shadertrace-traceready HRESULT
		// TraceReady( [out, optional] UINT64 *pTestCount );
		[PreserveSig]
		HRESULT TraceReady([Out, Optional] IntPtr pTestCount);

		/// <summary>Resets the shader-trace object.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// After you call <c>ResetTrace</c>, the ID3D11ShaderTrace object behaves as if it had just been created. Thereafter, shader
		/// invocations for the trace start from 0 again; calls to ID3D11ShaderTrace::TraceReady return <c>S_FALSE</c> until the selected
		/// shader invocation number is reached, and <c>TraceReady</c> records a new trace.
		/// </para>
		/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nf-d3d11shadertracing-id3d11shadertrace-resettrace void ResetTrace();
		[PreserveSig]
		void ResetTrace();

		/// <summary>Returns statistics about the trace.</summary>
		/// <param name="pTraceStats">
		/// A pointer to a D3D11_TRACE_STATS structure. <c>GetTraceStats</c> fills the members of this structure with statistics about the trace.
		/// </param>
		/// <returns>
		/// <para><c>GetTraceStats</c> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>S_OK if statistics about the trace are successfully obtained.</description>
		/// </item>
		/// <item>
		/// <description>
		/// E_FAIL if no trace statistics are available yet; ID3D11ShaderTrace::TraceReady must return S_OK before <c>GetTraceStats</c> can succeed.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG if <c>pTraceStats</c> is NULL.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in Direct3D 11 Return Codes.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nf-d3d11shadertracing-id3d11shadertrace-gettracestats
		// HRESULT GetTraceStats( [out] D3D11_TRACE_STATS *pTraceStats );
		[PreserveSig]
		HRESULT GetTraceStats(out D3D11_TRACE_STATS pTraceStats);

		/// <summary>Sets the specified pixel-shader stamp.</summary>
		/// <param name="stampIndex">The index of the stamp to select.</param>
		/// <returns>
		/// <para><c>PSSelectStamp</c> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <c>S_OK</c> if the method set the pixel-shader stamp, and if the primitive covers the pixel and sample for the stamp.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> if the method set the pixel-shader stamp, and if the invocation for the selected stamp falls off the primitive.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>E_FAIL</c> if you called the method for a vertex shader or geometry shader; <c>PSSelectStamp</c> is meaningful only for pixel shaders.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c> if <c>stampIndex</c> is out of range [0..3].</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in Direct3D 11 Return Codes.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// After you call <c>PSSelectStamp</c> to set the pixel-shader stamp, you can call the
		/// ID3D11ShaderTrace::GetInitialRegisterContents, ID3D11ShaderTrace::GetStep, ID3D11ShaderTrace::GetWrittenRegister, and
		/// ID3D11ShaderTrace::GetReadRegister methods to get trace data for that stamp.
		/// </para>
		/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nf-d3d11shadertracing-id3d11shadertrace-psselectstamp
		// HRESULT PSSelectStamp( [in] UINT stampIndex );
		[PreserveSig]
		HRESULT PSSelectStamp(uint stampIndex);

		/// <summary>Retrieves the initial contents of the specified input register.</summary>
		/// <param name="pRegister">
		/// <para>
		/// A pointer to a D3D11_TRACE_REGISTER structure that describes the input register to retrieve the initial contents from. You can
		/// retrieve valid initial data from only the following input register types. That is, to retrieve valid data, the <c>RegType</c>
		/// member of <c>D3D11_TRACE_REGISTER</c> must be one of the following values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D11_TRACE_INPUT_REGISTER</description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_INPUT_PRIMITIVE_ID_REGISTER</description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_IMMEDIATE_CONSTANT_BUFFER</description>
		/// </item>
		/// </list>
		/// <para>Valid data is indicated by the</para>
		/// <para>ValidMask</para>
		/// <para>member of the</para>
		/// <para>D3D11_TRACE_VALUE</para>
		/// <para>structure that</para>
		/// <para>pValue</para>
		/// <para>points to.</para>
		/// </param>
		/// <param name="pValue">
		/// A pointer to a D3D11_TRACE_VALUE structure. <c>GetInitialRegisterContents</c> fills the members of this structure with
		/// information about the initial contents.
		/// </param>
		/// <returns>
		/// <para><c>GetInitialRegisterContents</c> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> if the method retrieves the initial register contents.</description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> if a trace is not available.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c> if <c>pRegister</c> is invalid or NULL or if <c>pValue</c> is NULL.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in Direct3D 11 Return Codes.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You can call <c>GetInitialRegisterContents</c> for registers other than the input register types that are specified in the
		/// <c>pRegister</c> parameter description. However, <c>GetInitialRegisterContents</c> sets the <c>ValidMask</c> member of the
		/// D3D11_TRACE_VALUE structure to which <c>pValue</c> points to empty (all zeros, 0000), and the register values that the
		/// <c>Bits</c> member of <c>D3D11_TRACE_VALUE</c> specifies are meaningless. The data that <c>GetInitialRegisterContents</c>
		/// returns is not affected by stepping in a trace; however, the data that is returned is affected by changing the stamp index
		/// through a call to ID3D11ShaderTrace::PSSelectStamp.
		/// </para>
		/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nf-d3d11shadertracing-id3d11shadertrace-getinitialregistercontents
		// HRESULT GetInitialRegisterContents( [in] D3D11_TRACE_REGISTER *pRegister, [out] D3D11_TRACE_VALUE *pValue );
		[PreserveSig]
		HRESULT GetInitialRegisterContents(in D3D11_TRACE_REGISTER pRegister, out D3D11_TRACE_VALUE pValue);

		/// <summary>Retrieves information about the specified step in the trace.</summary>
		/// <param name="stepIndex">
		/// The index of the step within the trace. The range of the index is [0...NumTraceSteps-1], where <c>NumTraceSteps</c> is a member
		/// of the D3D11_TRACE_STATS structure. You can retrieve information about a step in any step order.
		/// </param>
		/// <param name="pTraceStep">
		/// A pointer to a D3D11_TRACE_STEP structure. <c>GetStep</c> fills the members of this structure with information about the trace
		/// step that is specified by the <c>stepIndex</c> parameter.
		/// </param>
		/// <returns>
		/// <para><c>GetStep</c> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> if the method retrieves the step information.</description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> if a trace is not available.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c> if <c>stepIndex</c> is out of range or if <c>pTraceStep</c> is NULL.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in Direct3D 11 Return Codes.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nf-d3d11shadertracing-id3d11shadertrace-getstep HRESULT
		// GetStep( [in] UINT stepIndex, [out] D3D11_TRACE_STEP *pTraceStep );
		[PreserveSig]
		HRESULT GetStep(uint stepIndex, out D3D11_TRACE_STEP pTraceStep);

		/// <summary>Retrieves information about a register that was written by a step in the trace.</summary>
		/// <param name="stepIndex">
		/// The index of the step within the trace. The range of the index is [0...NumTraceSteps-1], where <c>NumTraceSteps</c> is a member
		/// of the D3D11_TRACE_STATS structure. You can retrieve information in any step order.
		/// </param>
		/// <param name="writtenRegisterIndex">
		/// The index of the register within the trace step. The range of the index is [0...NumRegistersWritten-1], where
		/// <c>NumRegistersWritten</c> is a member of the D3D11_TRACE_STEP structure.
		/// </param>
		/// <param name="pRegister">
		/// A pointer to a D3D11_TRACE_REGISTER structure. <c>GetWrittenRegister</c> fills the members of this structure with information
		/// about the register that was written by the step in the trace.
		/// </param>
		/// <param name="pValue">
		/// A pointer to a D3D11_TRACE_VALUE structure. <c>GetWrittenRegister</c> fills the members of this structure with information about
		/// the value that was written to the register.
		/// </param>
		/// <returns>
		/// <para><c>GetWrittenRegister</c> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> if the method retrieves the register information.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>E_FAIL</c> if a trace is not available or if the trace was not created with the
		/// D3D11_SHADER_TRACE_FLAG_RECORD_REGISTER_WRITES flag.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>E_INVALIDARG</c> if <c>stepIndex</c> or <c>writtenRegisterIndex</c> is out of range or if <c>pRegister</c> or <c>pValue</c>
		/// is NULL.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in Direct3D 11 Return Codes.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nf-d3d11shadertracing-id3d11shadertrace-getwrittenregister
		// HRESULT GetWrittenRegister( [in] UINT stepIndex, [in] UINT writtenRegisterIndex, [out] D3D11_TRACE_REGISTER *pRegister, [out]
		// D3D11_TRACE_VALUE *pValue );
		[PreserveSig]
		HRESULT GetWrittenRegister(uint stepIndex, uint writtenRegisterIndex, out D3D11_TRACE_REGISTER pRegister, out D3D11_TRACE_VALUE pValue);

		/// <summary>Retrieves information about a register that was read by a step in the trace.</summary>
		/// <param name="stepIndex">
		/// The index of the step within the trace. The range of the index is [0...NumTraceSteps-1], where <c>NumTraceSteps</c> is a member
		/// of the D3D11_TRACE_STATS structure. You can retrieve information in any step order.
		/// </param>
		/// <param name="readRegisterIndex">
		/// The index of the register within the trace step. The range of the index is [0...NumRegistersRead-1], where
		/// <c>NumRegistersRead</c> is a member of the D3D11_TRACE_STEP structure.
		/// </param>
		/// <param name="pRegister">
		/// A pointer to a D3D11_TRACE_REGISTER structure. <c>GetReadRegister</c> fills the members of this structure with information about
		/// the register that was read by the step in the trace.
		/// </param>
		/// <param name="pValue">
		/// A pointer to a D3D11_TRACE_VALUE structure. <c>GetReadRegister</c> fills the members of this structure with information about
		/// the value that was read from the register.
		/// </param>
		/// <returns>
		/// <para><c>GetReadRegister</c> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> if the method retrieves the register information.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>E_FAIL</c> if a trace is not available or if the trace was not created with the D3D11_SHADER_TRACE_FLAG_RECORD_REGISTER_READS flag.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>E_INVALIDARG</c> if <c>stepIndex</c> or <c>readRegisterIndex</c> is out of range or if <c>pRegister</c> or <c>pValue</c> is NULL.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in Direct3D 11 Return Codes.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nf-d3d11shadertracing-id3d11shadertrace-getreadregister
		// HRESULT GetReadRegister( [in] UINT stepIndex, [in] UINT readRegisterIndex, [out] D3D11_TRACE_REGISTER *pRegister, [out]
		// D3D11_TRACE_VALUE *pValue );
		[PreserveSig]
		HRESULT GetReadRegister(uint stepIndex, uint readRegisterIndex, out D3D11_TRACE_REGISTER pRegister, out D3D11_TRACE_VALUE pValue);
	}

	/// <summary>An <c>ID3D11ShaderTraceFactory</c> interface implements a method for generating shader trace information objects.</summary>
	/// <remarks>
	/// <para>These APIs require the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para>
	/// To retrieve an instance of <c>ID3D11ShaderTraceFactory</c>, call IUnknown::QueryInterface on a ID3D11Device that you created with D3D11_CREATE_DEVICE_DEBUGGABLE.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nn-d3d11shadertracing-id3d11shadertracefactory
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NN:d3d11shadertracing.ID3D11ShaderTraceFactory")]
	[ComImport, Guid("1fbad429-66ab-41cc-9617-667ac10e4459"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ShaderTraceFactory
	{
		/// <summary>Creates a shader-trace interface for a shader-trace information object.</summary>
		/// <param name="pShader">
		/// A pointer to the interface of the shader to create the shader-trace interface for. For example, <c>pShader</c> can be an
		/// instance of ID3D11VertexShader, ID3D11PixelShader, and so on.
		/// </param>
		/// <param name="pTraceDesc">
		/// A pointer to a D3D11_SHADER_TRACE_DESC structure that describes the shader-trace object to create. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="ppShaderTrace">
		/// A pointer to a variable that receives a pointer to the ID3D11ShaderTrace interface for the shader-trace object that
		/// <c>CreateShaderTrace</c> creates.
		/// </param>
		/// <returns>
		/// <para><c>CreateShaderTrace</c> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> if the method created the shader-trace information object.</description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> if the reference device, which supports tracing, is not being used.</description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c> if memory is unavailable to complete the operation.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c> if any parameter is NULL or invalid.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in Direct3D 11 Return Codes.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nf-d3d11shadertracing-id3d11shadertracefactory-createshadertrace
		// HRESULT CreateShaderTrace( [in] IUnknown *pShader, [in] D3D11_SHADER_TRACE_DESC *pTraceDesc, [out] ID3D11ShaderTrace
		// **ppShaderTrace );
		[PreserveSig]
		HRESULT CreateShaderTrace([In, MarshalAs(UnmanagedType.Interface)] object pShader, in D3D11_SHADER_TRACE_DESC pTraceDesc, out ID3D11ShaderTrace ppShaderTrace);
	}

	/// <summary>
	/// Disassembles a section of compiled Microsoft High Level Shader Language (HLSL) code that is specified by shader trace steps.
	/// </summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to compiled shader data.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>The size, in bytes, of the block of memory that pSrcData points to.</para>
	/// </param>
	/// <param name="pTrace">
	/// <para>Type: <c>ID3D11ShaderTrace*</c></para>
	/// <para>A pointer to the ID3D11ShaderTrace interface for the shader trace information object.</para>
	/// </param>
	/// <param name="StartStep">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of the step in the trace from which D3DDisassemble11Trace starts the disassembly.</para>
	/// </param>
	/// <param name="NumSteps">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of trace steps to disassemble.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// A combination of zero or more of the following flags that are combined by using a bitwise OR operation. The resulting value
	/// specifies how D3DDisassemble11Trace disassembles the compiled shader data.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Flag</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>D3D_DISASM_ENABLE_COLOR_CODE (0x01)</description>
	/// <description>Enable the output of color codes.</description>
	/// </item>
	/// <item>
	/// <description>D3D_DISASM_ENABLE_DEFAULT_VALUE_PRINTS (0x02)</description>
	/// <description>Enable the output of default values.</description>
	/// </item>
	/// <item>
	/// <description>D3D_DISASM_ENABLE_INSTRUCTION_NUMBERING (0x04)</description>
	/// <description>Enable instruction numbering.</description>
	/// </item>
	/// <item>
	/// <description>D3D_DISASM_ENABLE_INSTRUCTION_CYCLE (0x08)</description>
	/// <description>No effect.</description>
	/// </item>
	/// <item>
	/// <description>D3D_DISASM_DISABLE_DEBUG_INFO (0x10)</description>
	/// <description>Disable the output of debug information.</description>
	/// </item>
	/// <item>
	/// <description>D3D_DISASM_ENABLE_INSTRUCTION_OFFSET (0x20)</description>
	/// <description>Enable the output of instruction offsets.</description>
	/// </item>
	/// <item>
	/// <description>D3D_DISASM_INSTRUCTION_ONLY (0x40)</description>
	/// <description>
	/// Enable the output of the instruction cycle per step in D3DDisassemble11Trace. This flag is similar to the
	/// D3D_DISASM_ENABLE_INSTRUCTION_NUMBERING and D3D_DISASM_ENABLE_INSTRUCTION_OFFSET flags. This flag has no effect in the
	/// D3DDisassembleRegion function. Cycle information comes from the trace; therefore, cycle information is available only in the trace disassembly.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppDisassembly">
	/// <para>Type: <c>ID3D10Blob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that accesses the disassembled HLSL code.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method returns an HRESULT error code.</para>
	/// </returns>
	/// <remarks>
	/// D3DDisassemble11Trace walks the steps of a shader trace and outputs appropriate disassembly for each step that is based on the
	/// step's instruction index. The disassembly is annotated with register-value information from the trace. The behavior of
	/// D3DDisassemble11Trace differs from D3DDisassemble in that instead of the static disassembly of a compiled shader that D3DDisassemble
	/// performs, D3DDisassemble11Trace provides an execution trace that is based on the shader trace information.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/nf-d3d11shadertracing-d3ddisassemble11trace HRESULT
	// D3DDisassemble11Trace( [in] LPCVOID pSrcData, [in] SIZE_T SrcDataSize, [in] ID3D11ShaderTrace *pTrace, [in] UINT StartStep, [in] UINT
	// NumSteps, [in] UINT Flags, [out] ID3D10Blob **ppDisassembly );
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NF:d3d11shadertracing.D3DDisassemble11Trace")]
	[DllImport("d3dcompiler_47.dll", SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DDisassemble11Trace([In] IntPtr pSrcData, [In] SIZE_T SrcDataSize,
		[In] ID3D11ShaderTrace pTrace, uint StartStep, uint NumSteps, uint Flags, out ID3DBlob ppDisassembly);

	/// <summary>Describes an instance of a compute shader to trace.</summary>
	/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_compute_shader_trace_desc typedef
	// struct D3D11_COMPUTE_SHADER_TRACE_DESC { UINT64 Invocation; UINT ThreadIDInGroup[3]; UINT ThreadGroupID[3]; } D3D11_COMPUTE_SHADER_TRACE_DESC;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_COMPUTE_SHADER_TRACE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_COMPUTE_SHADER_TRACE_DESC
	{
		/// <summary>The invocation number of the instance of the compute shader.</summary>
		public ulong Invocation;

		/// <summary>
		/// The SV_GroupThreadID to trace. This value identifies indexes of individual threads within a thread group that a compute shader
		/// executes in.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public uint[] ThreadIDInGroup;

		/// <summary>The SV_GroupID to trace. This value identifies indexes of a thread group that the compute shader executes in.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public uint[] ThreadGroupID;
	}

	/// <summary>Describes an instance of a domain shader to trace.</summary>
	/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_domain_shader_trace_desc typedef
	// struct D3D11_DOMAIN_SHADER_TRACE_DESC { UINT64 Invocation; } D3D11_DOMAIN_SHADER_TRACE_DESC;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_DOMAIN_SHADER_TRACE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_DOMAIN_SHADER_TRACE_DESC
	{
		/// <summary>The invocation number of the instance of the domain shader.</summary>
		public ulong Invocation;
	}

	/// <summary>Describes an instance of a geometry shader to trace.</summary>
	/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_geometry_shader_trace_desc typedef
	// struct D3D11_GEOMETRY_SHADER_TRACE_DESC { UINT64 Invocation; } D3D11_GEOMETRY_SHADER_TRACE_DESC;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_GEOMETRY_SHADER_TRACE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_GEOMETRY_SHADER_TRACE_DESC
	{
		/// <summary>The invocation number of the instance of the geometry shader.</summary>
		public ulong Invocation;
	}

	/// <summary>Describes an instance of a hull shader to trace.</summary>
	/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_hull_shader_trace_desc typedef
	// struct D3D11_HULL_SHADER_TRACE_DESC { UINT64 Invocation; } D3D11_HULL_SHADER_TRACE_DESC;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_HULL_SHADER_TRACE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_HULL_SHADER_TRACE_DESC
	{
		/// <summary>The invocation number of the instance of the hull shader.</summary>
		public ulong Invocation;
	}

	/// <summary>Describes an instance of a pixel shader to trace.</summary>
	/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_pixel_shader_trace_desc typedef
	// struct D3D11_PIXEL_SHADER_TRACE_DESC { UINT64 Invocation; INT X; INT Y; UINT64 SampleMask; } D3D11_PIXEL_SHADER_TRACE_DESC;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_PIXEL_SHADER_TRACE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_PIXEL_SHADER_TRACE_DESC
	{
		/// <summary>The invocation number of the instance of the pixel shader.</summary>
		public ulong Invocation;

		/// <summary>The x-coordinate of the pixel.</summary>
		public int X;

		/// <summary>The y-coordinate of the pixel.</summary>
		public int Y;

		/// <summary>
		/// A value that describes a mask of pixel samples to trace. If this value specifies any of the masked samples, the trace is
		/// activated. The least significant bit (LSB) is sample 0. The non-multisample antialiasing (MSAA) counts as a sample count of 1;
		/// therefore, the LSB of <c>SampleMask</c> should be set. If set to zero, the pixel is not traced. However, pixel traces can still
		/// be enabled on an invocation basis.
		/// </summary>
		public ulong SampleMask;
	}

	/// <summary>Describes a shader-trace object.</summary>
	/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_shader_trace_desc typedef struct
	// D3D11_SHADER_TRACE_DESC { D3D11_SHADER_TYPE Type; UINT Flags; union { D3D11_VERTEX_SHADER_TRACE_DESC VertexShaderTraceDesc;
	// D3D11_HULL_SHADER_TRACE_DESC HullShaderTraceDesc; D3D11_DOMAIN_SHADER_TRACE_DESC DomainShaderTraceDesc;
	// D3D11_GEOMETRY_SHADER_TRACE_DESC GeometryShaderTraceDesc; D3D11_PIXEL_SHADER_TRACE_DESC PixelShaderTraceDesc;
	// D3D11_COMPUTE_SHADER_TRACE_DESC ComputeShaderTraceDesc; }; } D3D11_SHADER_TRACE_DESC;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_SHADER_TRACE_DESC")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D11_SHADER_TRACE_DESC
	{
		/// <summary>
		/// A D3D11_SHADER_TYPE-typed value that identifies the type of shader that the shader-trace object describes. This member also
		/// determines which shader-trace type to use in the following union.
		/// </summary>
		[FieldOffset(0)]
		public D3D11_SHADER_TYPE Type;

		/// <summary>
		/// <para>
		/// A combination of the following flags that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how
		/// ID3D11ShaderTraceFactory::CreateShaderTrace creates the shader-trace object.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>D3D11_SHADER_TRACE_FLAG_RECORD_REGISTER_WRITES (0x1)</description>
		/// <description>The shader trace object records register-writes.</description>
		/// </item>
		/// <item>
		/// <description>D3D11_SHADER_TRACE_FLAG_RECORD_REGISTER_READS (0x2)</description>
		/// <description>The shader trace object records register-reads.</description>
		/// </item>
		/// </list>
		/// </summary>
		[FieldOffset(4)]
		public D3D11_SHADER_TRACE_FLAG Flags;

		/// <summary>A D3D11_VERTEX_SHADER_TRACE_DESC structure that describes an instance of a vertex shader to trace.</summary>
		[FieldOffset(8)]
		public D3D11_VERTEX_SHADER_TRACE_DESC VertexShaderTraceDesc;

		/// <summary>A D3D11_HULL_SHADER_TRACE_DESC structure that describes an instance of a hull shader to trace.</summary>
		[FieldOffset(8)]
		public D3D11_HULL_SHADER_TRACE_DESC HullShaderTraceDesc;

		/// <summary>A D3D11_DOMAIN_SHADER_TRACE_DESC structure that describes an instance of a domain shader to trace.</summary>
		[FieldOffset(8)]
		public D3D11_DOMAIN_SHADER_TRACE_DESC DomainShaderTraceDesc;

		/// <summary>A D3D11_GEOMETRY_SHADER_TRACE_DESC structure that describes an instance of a geometry shader to trace.</summary>
		[FieldOffset(8)]
		public D3D11_GEOMETRY_SHADER_TRACE_DESC GeometryShaderTraceDesc;

		/// <summary>A D3D11_PIXEL_SHADER_TRACE_DESC structure that describes an instance of a pixel shader to trace.</summary>
		[FieldOffset(8)]
		public D3D11_PIXEL_SHADER_TRACE_DESC PixelShaderTraceDesc;

		/// <summary>A D3D11_COMPUTE_SHADER_TRACE_DESC structure that describes an instance of a compute shader to trace.</summary>
		[FieldOffset(8)]
		public D3D11_COMPUTE_SHADER_TRACE_DESC ComputeShaderTraceDesc;
	}

	/// <summary>Describes a trace register.</summary>
	/// <remarks>
	/// <para>The following register types do not require an index:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>input PrimitiveID</description>
	/// </item>
	/// <item>
	/// <description>output oDepth</description>
	/// </item>
	/// <item>
	/// <description>immediate32</description>
	/// </item>
	/// <item>
	/// <description>NULL register</description>
	/// </item>
	/// <item>
	/// <description>output control point ID (this is actually an input; it defines the output that the thread controls)</description>
	/// </item>
	/// <item>
	/// <description>input fork instance ID</description>
	/// </item>
	/// <item>
	/// <description>input join instance ID</description>
	/// </item>
	/// <item>
	/// <description>input domain point register</description>
	/// </item>
	/// <item>
	/// <description>cycle counter</description>
	/// </item>
	/// </list>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_trace_register typedef struct
	// D3D11_TRACE_REGISTER { D3D11_TRACE_REGISTER_TYPE RegType; union { UINT16 Index1D; UINT16 Index2D[2]; }; UINT8 OperandIndex; UINT8
	// Flags; } D3D11_TRACE_REGISTER;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_TRACE_REGISTER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TRACE_REGISTER
	{
		/// <summary>A D3D11_TRACE_REGISTER_TYPE-typed value that identifies the type of register that the shader-trace object uses.</summary>
		public D3D11_TRACE_REGISTER_TYPE RegType;

		/// <summary>
		/// <para>An index for one-dimensional arrays. This index is used by the following register types:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>vertex shader or pixel shader input: v[Index1D]</description>
		/// </item>
		/// <item>
		/// <description>temp: r[Index1D]</description>
		/// </item>
		/// <item>
		/// <description>output: o[Index1D]</description>
		/// </item>
		/// <item>
		/// <description>immediate constant buffer: icb[Index1D]</description>
		/// </item>
		/// <item>
		/// <description>sampler s[Index1D]</description>
		/// </item>
		/// <item>
		/// <description>resource r[Index1D]</description>
		/// </item>
		/// <item>
		/// <description>input patch constant register: vpc[Index1D]</description>
		/// </item>
		/// <item>
		/// <description>unordered access view: u[Index1D]</description>
		/// </item>
		/// <item>
		/// <description>thread group shared memory: g[Index1D]</description>
		/// </item>
		/// </list>
		/// </summary>
		public ushort Index1D;

		private ushort _Index2D;

		/// <summary>
		/// <para>An array of indexes for two-dimensional arrays. These indexes are used by the following register types:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>GS input: v[Index2D[0]][Index2D[1]]</description>
		/// </item>
		/// <item>
		/// <description>indexable temp: x[Index2D[0]][Index2D[1]]</description>
		/// </item>
		/// <item>
		/// <description>constant buffer: cb#[#]</description>
		/// </item>
		/// <item>
		/// <description>input control point register: vcp[Index2D[0]][Index2D[1]]</description>
		/// </item>
		/// <item>
		/// <description>output control point register: vocp[Index2D[0]][Index2D[1]]</description>
		/// </item>
		/// </list>
		/// </summary>
		public ushort[] Index2D { get => [Index1D, _Index2D]; set { if (value?.Length != 2) throw new ArgumentException("Array must have 2 elements.", nameof(Index2D)); Index1D = value[0]; _Index2D = value[1]; } }

		/// <summary>The index of the operand, which starts from 0.</summary>
		public byte OperandIndex;

		/// <summary>
		/// <para>
		/// A combination of the following flags that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies
		/// more about the trace register.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>D3D11_TRACE_REGISTER_FLAGS_RELATIVE_INDEXING (0x1)</description>
		/// <description>Access to the register is part of the relative indexing of a register.</description>
		/// </item>
		/// </list>
		/// </summary>
		public D3D11_TRACE_REGISTER_FLAGS Flags;
	}

	/// <summary>Specifies statistics about a trace.</summary>
	/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_trace_stats typedef struct
	// D3D11_TRACE_STATS { D3D11_SHADER_TRACE_DESC TraceDesc; UINT8 NumInvocationsInStamp; UINT8 TargetStampIndex; UINT NumTraceSteps;
	// D3D11_TRACE_COMPONENT_MASK InputMask[32]; D3D11_TRACE_COMPONENT_MASK OutputMask[32]; UINT16 NumTemps; UINT16 MaxIndexableTempIndex;
	// UINT16 IndexableTempSize[4096]; UINT16 ImmediateConstantBufferSize; UINT PixelPosition[4][2]; UINT64 PixelCoverageMask[4]; UINT64
	// PixelDiscardedMask[4]; UINT64 PixelCoverageMaskAfterShader[4]; UINT64 PixelCoverageMaskAfterA2CSampleMask[4]; UINT64
	// PixelCoverageMaskAfterA2CSampleMaskDepth[4]; UINT64 PixelCoverageMaskAfterA2CSampleMaskDepthStencil[4]; BOOL PSOutputsDepth; BOOL
	// PSOutputsMask; D3D11_TRACE_GS_INPUT_PRIMITIVE GSInputPrimitive; BOOL GSInputsPrimitiveID; D3D11_TRACE_COMPONENT_MASK
	// HSOutputPatchConstantMask[32]; D3D11_TRACE_COMPONENT_MASK DSInputPatchConstantMask[32]; } D3D11_TRACE_STATS;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_TRACE_STATS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TRACE_STATS
	{
		/// <summary>A D3D11_SHADER_TRACE_DESC structure that describes the shader trace object for which this structure specifies statistics.</summary>
		public D3D11_SHADER_TRACE_DESC TraceDesc;

		/// <summary>
		/// The number of calls in the stamp for the trace. This value is always 1 for vertex shaders, hull shaders, domain shaders,
		/// geometry shaders, and compute shaders. This value is 4 for pixel shaders.
		/// </summary>
		public byte NumInvocationsInStamp;

		/// <summary>
		/// The index of the target stamp. This value is always 0 for vertex shaders, hull shaders, domain shaders, geometry shaders, and
		/// compute shaders. However, for pixel shaders this value indicates which of the four pixels in the stamp is the target for the
		/// trace. You can examine the traces for other pixels in the stamp to determine how derivative calculations occurred. You can make
		/// this determination by correlating the registers across traces.
		/// </summary>
		public byte TargetStampIndex;

		/// <summary>The total number of steps for the trace. This number is the same for all stamp calls.</summary>
		public uint NumTraceSteps;

		/// <summary>
		/// <para>The component trace mask for each input v# register. For information about D3D11_TRACE_COMPONENT_MASK, see D3D11_TRACE_VALUE.</para>
		/// <para>
		/// For vertex shaders, geometry shaders, pixel shaders, hull shaders, and domain shaders, the valid range is [0..31]. For compute
		/// shaders, this member is not applicable. Also, inputs for geometry shaders are 2D-indexed. For example, consider
		/// v[vertex][attribute]. In this example, the range of [attribute] is [0..31]. The [vertex] axis is the same size for all inputs,
		/// which are determined by the <c>GSInputPrimitive</c> member.
		/// </para>
		/// <para>
		/// Similarly, inputs for hull shader and domain shader are 2D-indexed. For example, consider v[vertex][attribute]. In this example,
		/// the range of [attribute] is [0..15]. The [vertex] axis is the same size for all inputs.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public D3D11_TRACE_COMPONENT_MASK[] InputMask;

		/// <summary>
		/// <para>The component trace mask for each output o# register. For information about D3D11_TRACE_COMPONENT_MASK, see D3D11_TRACE_VALUE.</para>
		/// <para>
		/// For vertex shaders and geometry shaders, the valid range is [0..31]. For pixel shaders, the valid range is [0..7]. For compute
		/// shaders, this member is not applicable. For output control points for hull shaders, the registers are 2D-indexed. For example,
		/// consider ocp[vertex][attribute]. In this example, the range of [attribute] is [0..31]. The [vertex] axis is the same size for
		/// all inputs.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public D3D11_TRACE_COMPONENT_MASK[] OutputMask;

		/// <summary>The number of temps, that is, 4x32 bit r# registers that are declared.</summary>
		public ushort NumTemps;

		/// <summary>
		/// The maximum index #+1 of all indexable temps x#[] that are declared. If they are declared sparsely (for example, x3[12] and
		/// x200[30] only), this value is 201 (200+1).
		/// </summary>
		public ushort MaxIndexableTempIndex;

		/// <summary>
		/// The number of temps for each indexable temp x#[numTemps]. You can only have temps up to the value in the
		/// <c>MaxIndexableTempIndex</c> member.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
		public ushort[] IndexableTempSize;

		/// <summary>The number of 4x32 bit values (if any) that are in the immediate constant buffer.</summary>
		public ushort ImmediateConstantBufferSize;

		private unsafe fixed ulong _PixelPosition[8];

		/// <summary/>
		public ulong[][] PixelPosition
		{
			get
			{
				unsafe
				{
					fixed (ulong* p = _PixelPosition)
						return [[p[0], p[1]], [p[2], p[3]], [p[4], p[5]], [p[6], p[7]]];
				}
			}
			set
			{
				if (value is null || value.Rank != 2 || value.GetLength(0) != 4 || value.GetLength(1) != 2)
					throw new ArgumentException("Array must be a 4x2 jagged array.", nameof(PixelPosition));
				unsafe { fixed (ulong* p = _PixelPosition) { p[0] = value[0][0]; p[1] = value[0][1]; p[2] = value[1][0]; p[3] = value[1][1]; p[4] = value[2][0]; p[5] = value[2][1]; p[6] = value[3][0]; p[7] = value[3][1]; } }
			}
		}

		/// <summary>
		/// <para><c>Note</c>  This member is for pixel shaders only, [stampIndex].</para>
		/// <para></para>
		/// <para>
		/// A mask that indicates which MSAA samples are covered for each stamp. This coverage occurs before alpha-to-coverage, depth, and
		/// stencil operations are performed on the pixel. For non-MSAA, examine the least significant bit (LSB). This mask can be 0 for
		/// pixels that are only executed to support derivatives for neighboring pixels.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public ulong[] PixelCoverageMask;

		/// <summary>
		/// <para><c>Note</c>  This member is for pixel shaders only, [stampIndex].</para>
		/// <para></para>
		/// <para>
		/// A mask that indicates discarded samples. If the pixel shader runs at pixel-frequency, "discard" turns off all the samples. If
		/// all the samples are off, the following four mask members are also 0.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public ulong[] PixelDiscardedMask;

		/// <summary>
		/// <para><c>Note</c>  This member is for pixel shaders only, [stampIndex].</para>
		/// <para></para>
		/// <para>A mask that indicates the MSAA samples that are covered. For non-MSAA, examine the LSB.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public ulong[] PixelCoverageMaskAfterShader;

		/// <summary>
		/// <para><c>Note</c>  This member is for pixel shaders only, [stampIndex].</para>
		/// <para></para>
		/// <para>
		/// A mask that indicates the MSAA samples that are covered after alpha-to-coverage+sampleMask, but before depth and stencil. For
		/// non-MSAA, examine the LSB.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public ulong[] PixelCoverageMaskAfterA2CSampleMask;

		/// <summary>
		/// <para><c>Note</c>  This member is for pixel shaders only, [stampIndex].</para>
		/// <para></para>
		/// <para>
		/// A mask that indicates the MSAA samples that are covered after alpha-to-coverage+sampleMask+depth, but before stencil. For
		/// non-MSAA, examine the LSB.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public ulong[] PixelCoverageMaskAfterA2CSampleMaskDepth;

		/// <summary>
		/// <para><c>Note</c>  This member is for pixel shaders only, [stampIndex].</para>
		/// <para></para>
		/// <para>
		/// A mask that indicates the MSAA samples that are covered after alpha-to-coverage+sampleMask+depth+stencil. For non-MSAA, examine
		/// the LSB.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public ulong[] PixelCoverageMaskAfterA2CSampleMaskDepthStencil;

		/// <summary>
		/// A value that specifies whether this trace is for a pixel shader that outputs the oDepth register. TRUE indicates that the pixel
		/// shader outputs the oDepth register; otherwise, FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool PSOutputsDepth;

		/// <summary>
		/// A value that specifies whether this trace is for a pixel shader that outputs the oMask register. TRUE indicates that the pixel
		/// shader outputs the oMask register; otherwise, FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool PSOutputsMask;

		/// <summary>
		/// A D3D11_TRACE_GS_INPUT_PRIMITIVE-typed value that identifies the type of geometry shader input primitive. That is, this value
		/// identifies: {point, line, triangle, line_adj, triangle_adj} or the number of vertices: 1, 2, 3, 4, or 6 respectively. For
		/// example, for a line, input v[][#] is actually v[2][#]. For vertex shaders and pixel shaders, set this member to D3D11_TRACE_GS_INPUT_PRIMITIVE_UNDEFINED.
		/// </summary>
		public D3D11_TRACE_GS_INPUT_PRIMITIVE GSInputPrimitive;

		/// <summary>
		/// A value that specifies whether this trace is for a geometry shader that inputs the PrimitiveID register. TRUE indicates that the
		/// geometry shader inputs the PrimitiveID register; otherwise, FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool GSInputsPrimitiveID;

		/// <summary>
		/// <para><c>Note</c>  This member is for hull shaders only.</para>
		/// <para></para>
		/// <para>The component trace mask for the hull-shader output. For information about D3D11_TRACE_COMPONENT_MASK, see</para>
		/// <para>D3D11_TRACE_VALUE</para>
		/// <para>.</para>
		/// <para>
		/// The D3D11_TRACE_INPUT_PRIMITIVE_ID_REGISTER value is available through a call to the
		/// ID3D11ShaderTrace::GetInitialRegisterContents method.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public D3D11_TRACE_COMPONENT_MASK[] HSOutputPatchConstantMask;

		/// <summary>
		/// <para><c>Note</c>  This member is for domain shaders only.</para>
		/// <para></para>
		/// <para>The component trace mask for the domain-shader input. For information about D3D11_TRACE_COMPONENT_MASK, see</para>
		/// <para>D3D11_TRACE_VALUE</para>
		/// <para>.</para>
		/// <para>The following values are available through a call to the ID3D11ShaderTrace::GetInitialRegisterContents method:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D11_TRACE_INPUT_PRIMITIVE_ID_REGISTER</description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_INPUT_DOMAIN_POINT_REGISTER</description>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public D3D11_TRACE_COMPONENT_MASK[] DSInputPatchConstantMask;
	}

	/// <summary>Describes a trace step, which is an instruction.</summary>
	/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_trace_step typedef struct
	// D3D11_TRACE_STEP { UINT ID; BOOL InstructionActive; UINT8 NumRegistersWritten; UINT8 NumRegistersRead;
	// D3D11_TRACE_MISC_OPERATIONS_MASK MiscOperations; UINT OpcodeType; UINT64 CurrentGlobalCycle; } D3D11_TRACE_STEP;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_TRACE_STEP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TRACE_STEP
	{
		/// <summary>
		/// <para>A number that identifies the instruction, as an offset into the executable instructions that are present in the shader.</para>
		/// <para>
		/// HLSL debugging information uses the same convention. Therefore, HLSL instructions are matched to a set of IDs. You can then map
		/// an ID to a disassembled string that can be displayed to the user.
		/// </para>
		/// </summary>
		public uint ID;

		/// <summary>
		/// A value that specifies whether the instruction is active. This value is TRUE if something happened; therefore, you should parse
		/// other data in this structure. Otherwise, nothing happened; for example, if an instruction is disabled due to flow control even
		/// though other pixels in the stamp execute it.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool InstructionActive;

		/// <summary>
		/// The number of registers for the instruction that are written to. The range of registers is [0...NumRegistersWritten-1]. You can
		/// pass a register number to the <c>writtenRegisterIndex</c> parameter of ID3D11ShaderTrace::GetWrittenRegister to retrieve
		/// individual write-register information.
		/// </summary>
		public byte NumRegistersWritten;

		/// <summary>
		/// The number of registers for the instruction that are read from. The range of registers is [0...NumRegistersRead-1]. You can pass
		/// a register number to the <c>readRegisterIndex</c> parameter of ID3D11ShaderTrace::GetReadRegister to retrieve individual
		/// read-register information.
		/// </summary>
		public byte NumRegistersRead;

		/// <summary>
		/// <para>
		/// A combination of the following values that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies
		/// the mask for the trace miscellaneous operations. These flags indicate the possible effect of a shader operation when it does not
		/// write any output registers. For example, the "add r0, r1 ,r2" operation writes to the r0 register; therefore, you can look at
		/// the trace-written register's information to determine what the operation changed. However, some shader instructions do not write
		/// any registers, but still effect those registers.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>D3D11_TRACE_MISC_GS_EMIT (0x1)</description>
		/// <description>The operation was a geometry shader data emit.</description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_MISC_GS_CUT (0x2)</description>
		/// <description>The operation was a geometry shader strip cut.</description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_MISC_PS_DISCARD (0x4)</description>
		/// <description>The operation was a pixel shader discard, which rejects the pixel.</description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_MISC_GS_EMIT_STREAM (0x8)</description>
		/// <description>
		/// Same as D3D11_TRACE_MISC_GS_EMIT, except in shader model 5 where you can specify a particular stream to emit to.
		/// </description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_MISC_GS_CUT_STREAM (0x10)</description>
		/// <description>
		/// Same as D3D11_TRACE_MISC_GS_CUT, except in shader model 5 where you can specify a particular stream to strip cut.
		/// </description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_MISC_HALT (0x20)</description>
		/// <description>
		/// The operation was a shader halt instruction, which stops shader execution. The HLSL abort intrinsic function causes a halt.
		/// </description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_MISC_MESSAGE (0x40)</description>
		/// <description>
		/// The operation was a shader message output, which can be logged to the information queue. The HLSL printf and errorf intrinsic
		/// functions cause messages.
		/// </description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>If the <c>NumRegistersWritten</c> member is 0, examine this member although this member still might be empty (0).</para>
		/// </summary>
		public D3D11_TRACE_MISC_OPERATIONS_MASK MiscOperations;

		/// <summary>
		/// A number that specifies the type of instruction (for example, add, mul, and so on). You can ignore this member if you do not
		/// know the number for the instruction type. This member offers a minor convenience at the cost of bloating the trace slightly. You
		/// can use the <c>ID</c> member and map back to the original shader code to retrieve the full information about the instruction.
		/// </summary>
		public uint OpcodeType;

		/// <summary>
		/// <para>
		/// The global cycle count for this step. You can use this member to correlate parallel thread execution via multiple simultaneous
		/// traces, for example, for the compute shader.
		/// </para>
		/// <para><c>Note</c>  Multiple threads at the same point in execution might log the same <c>CurrentGlobalCycle</c>.</para>
		/// <para></para>
		/// </summary>
		public ulong CurrentGlobalCycle;
	}

	/// <summary>Describes a trace value.</summary>
	/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_trace_value typedef struct
	// D3D11_TRACE_VALUE { UINT Bits[4]; D3D11_TRACE_COMPONENT_MASK ValidMask; } D3D11_TRACE_VALUE;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_TRACE_VALUE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TRACE_VALUE
	{
		/// <summary>
		/// <para>An array of bits that make up the trace value. The [0] element is X.</para>
		/// <para>
		/// <c>Note</c>  This member can hold <c>float</c>, <c>UINT</c>, or <c>INT</c> data. The elements are specified as <c>UINT</c>
		/// rather than using a union to minimize the risk of x86 SNaN-&gt;QNaN quashing during float assignment. If the bits are displayed,
		/// they can be interpreted as <c>float</c> at the last moment.
		/// </para>
		/// <para></para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] Bits;

		/// <summary>
		/// <para>
		/// A combination of the following component values that are combined by using a bitwise <c>OR</c> operation. The resulting value
		/// specifies the component trace mask.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>D3D11_TRACE_COMPONENT_X (0x1)</description>
		/// <description>The x component of the trace mask.</description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_COMPONENT_Y (0x2)</description>
		/// <description>The y component of the trace mask.</description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_COMPONENT_Z (0x4)</description>
		/// <description>The depth z component of the trace mask.</description>
		/// </item>
		/// <item>
		/// <description>D3D11_TRACE_COMPONENT_W (0x8)</description>
		/// <description>The depth w component of the trace mask.</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>Ignore unmasked values, particularly if deltas are accumulated.</para>
		/// </summary>
		public D3D11_TRACE_COMPONENT_MASK ValidMask;
	}

	/// <summary>Describes an instance of a vertex shader to trace.</summary>
	/// <remarks>This API requires the Windows Software Development Kit (SDK) for Windows 8.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shadertracing/ns-d3d11shadertracing-d3d11_vertex_shader_trace_desc typedef
	// struct D3D11_VERTEX_SHADER_TRACE_DESC { UINT64 Invocation; } D3D11_VERTEX_SHADER_TRACE_DESC;
	[PInvokeData("d3d11shadertracing.h", MSDNShortId = "NS:d3d11shadertracing.D3D11_VERTEX_SHADER_TRACE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VERTEX_SHADER_TRACE_DESC
	{
		/// <summary>The invocation number of the instance of the vertex shader.</summary>
		public ulong Invocation;
	}
}