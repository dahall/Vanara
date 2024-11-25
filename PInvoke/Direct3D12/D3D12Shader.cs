namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary>Shader requirements Each flag specifies a requirement of the shader.</summary>
	[PInvokeData("d3d12shader.h", MSDNShortId = "nf-d3d12shader-id3d12shaderreflection-getrequiresflags")]
	[Flags]
	public enum D3D_SHADER_REQUIRES : ulong
	{
		/// <summary>Shader requires that the graphics driver and hardware support the double data type.</summary>
		D3D_SHADER_REQUIRES_DOUBLES = 0x1,

		/// <summary>Shader requires an early depth stencil.</summary>
		D3D_SHADER_REQUIRES_EARLY_DEPTH_STENCIL = 0x2,

		/// <summary>Shader requires unordered access views (UAVs) at every pipeline stage.</summary>
		D3D_SHADER_REQUIRES_UAVS_AT_EVERY_STAGE = 0x4,

		/// <summary>Shader requires 64 UAVs.</summary>
		D3D_SHADER_REQUIRES_64_UAVS = 0x8,

		/// <summary>
		/// Shader requires the graphics driver and hardware to support minimum precision. For more info, see <c>Using HLSL minimum precision</c>.
		/// </summary>
		D3D_SHADER_REQUIRES_MINIMUM_PRECISION = 0x10,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support extended doubles instructions. For more info, see the
		/// <b>ExtendedDoublesShaderInstructions</b> member of <c>D3D12_FEATURE_DATA_D3D12_OPTIONS</c>.
		/// </summary>
		D3D_SHADER_REQUIRES_11_1_DOUBLE_EXTENSIONS = 0x20,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support the <c>msad4</c> intrinsic function in shaders. For more info, see
		/// the <b>SAD4ShaderInstructions</b> member of <c>D3D12_FEATURE_DATA_D3D12_OPTIONS</c>.
		/// </summary>
		D3D_SHADER_REQUIRES_11_1_SHADER_EXTENSIONS = 0x40,

		/// <summary>Shader requires that the graphics driver and hardware support Direct3D 9 shadow support.</summary>
		D3D_SHADER_REQUIRES_LEVEL_9_COMPARISON_FILTERING = 0x80,

		/// <summary>Shader requires that the graphics driver and hardware support tiled resources.</summary>
		D3D_SHADER_REQUIRES_TILED_RESOURCES = 0x100,

		/// <summary>
		/// Shader requires a reference value for depth stencil tests. For more info, see the <b>PSSpecifiedStencilRefSupported</b> member
		/// of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS</c> structure, and <c>ID3D12GraphicsCommandList::OMSetStencilRef</c>.
		/// </summary>
		D3D_SHADER_REQUIRES_STENCIL_REF = 0x200,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support inner coverage. For more info, see the enumeration constants
		/// <b>D3D_NAME_INNER_COVERAGE</b> and <b>D3D11_NAME_INNER_COVERAGE</b> in <c>D3D_NAME</c>.
		/// </summary>
		D3D_SHADER_REQUIRES_INNER_COVERAGE = 0x400,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support the loading of additional formats for typed unordered-access views
		/// (UAVs). See the TypedUAVLoadAdditionalFormats member of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_TYPED_UAV_LOAD_ADDITIONAL_FORMATS = 0x800,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support rasterizer ordered views (ROVs). See <c>Rasterizer Ordered Views</c>.
		/// </summary>
		D3D_SHADER_REQUIRES_ROVS = 0x1000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support viewport and render target array index values from any
		/// shader-feeding rasterizer. For more info, see the member
		/// VPAndRTArrayIndexFromAnyShaderFeedingRasterizerSupportedWithoutGSEmulation of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_VIEWPORT_AND_RT_ARRAY_INDEX_FROM_ANY_SHADER_FEEDING_RASTERIZER = 0x2000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support wave ops. For more info, see the member <b>WaveOps</b> of the
		/// <c>D3D12_FEATURE_DATA_D3D12_OPTIONS1</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_WAVE_OPS = 0x4000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support 64-bit integer ops. For more info, see the member
		/// <b>Int64ShaderOps</b> of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS1</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_INT64_OPS = 0x8000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support view instancing using <b>SV_ViewID</b>. For more info, see the
		/// member <b>ViewInstancingTier</b> of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS3</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_VIEW_ID = 0x10000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support barycentrics using <b>SV_Barycentrics</b>. For more info, see the
		/// member <b>BarycentricsSupported</b> of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS3</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_BARYCENTRICS = 0x20000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support native 16-bit ops. For more info, see the member
		/// <b>Native16BitShaderOpsSupported</b> of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS4</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_NATIVE_16BIT_OPS = 0x40000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support the Variable Shading Rate (VRS) feature. For more info, see the
		/// member <b>VariableShadingRateTier</b> of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS6</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_SHADING_RATE = 0x80000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support DXR tier 1.1. For more info, see the member <b>RaytracingTier</b>
		/// of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS5</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_RAYTRACING_TIER_1_1 = 0x100000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support Sampler Feedback. For more info, see the member
		/// <b>SamplerFeedbackTier</b> of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS7</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_SAMPLER_FEEDBACK = 0x200000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support int64 atomics on typed resources. For more info, see the member
		/// <b>AtomicInt64OnTypedResourceSupported</b> of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS9</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_ATOMIC_INT64_ON_TYPED_RESOURCE = 0x400000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support int64 atomics on groupshared memory. For more info, see the member
		/// <b>AtomicInt64OnGroupSharedSupported</b> of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS9</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_ATOMIC_INT64_ON_GROUP_SHARED = 0x800000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support derivatives in mesh and amplification shaders. For more info, see
		/// the member <b>DerivativesInMeshAndAmplificationShadersSupported</b> of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS9</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_DERIVATIVES_IN_MESH_AND_AMPLIFICATION_SHADERS = 0x1000000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support Dynamic Resources (a requirement for Shader Model 6.6) and the
		/// <b>ResourceDescriptorHeap</b> in particular. For more info, see the <c>HLSL dynamic resources</c> spec on GitHub.
		/// </summary>
		D3D_SHADER_REQUIRES_RESOURCE_DESCRIPTOR_HEAP_INDEXING = 0x2000000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support Dynamic Resources (a requirement for Shader Model 6.6) and the
		/// <b>SamplerDescriptorHeap</b> in particular. For more info, see the <c>HLSL dynamic resources</c> spec on GitHub.
		/// </summary>
		D3D_SHADER_REQUIRES_SAMPLER_DESCRIPTOR_HEAP_INDEXING = 0x4000000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support Wave MMA. For more info, see the member <b>WaveMMATier</b> of the
		/// <c>D3D12_FEATURE_DATA_D3D12_OPTIONS9</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_WAVE_MMA = 0x8000000,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support int64 atomics on descriptor heap resources. For more info, see the
		/// member <b>AtomicInt64OnDescriptorHeapResourceSupported</b> of the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS11</c> structure.
		/// </summary>
		D3D_SHADER_REQUIRES_ATOMIC_INT64_ON_DESCRIPTOR_HEAP_RESOURCE = 0x10000000,

		/// <summary/>
		D3D_SHADER_REQUIRES_ADVANCED_TEXTURE_OPS = 0x20000000,

		/// <summary/>
		D3D_SHADER_REQUIRES_WRITEABLE_MSAA_TEXTURES = 0x40000000,

		/// <summary/>
		D3D_SHADER_REQUIRES_SAMPLE_CMP_GRADIENT_OR_BIAS = 0x80000000,

		/// <summary/>
		D3D_SHADER_REQUIRES_EXTENDED_COMMAND_INFO = 0x100000000,
	}

	/// <summary>
	/// Enumerates the types of shaders that Direct3D recognizes. Used to encode the <b>Version</b> member of the <c>D3D12_SHADER_DESC</c> structure.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/ne-d3d12shader-d3d12_shader_version_type typedef enum
	// D3D12_SHADER_VERSION_TYPE { D3D12_SHVER_PIXEL_SHADER = 0, D3D12_SHVER_VERTEX_SHADER = 1, D3D12_SHVER_GEOMETRY_SHADER = 2,
	// D3D12_SHVER_HULL_SHADER = 3, D3D12_SHVER_DOMAIN_SHADER = 4, D3D12_SHVER_COMPUTE_SHADER = 5, D3D12_SHVER_LIBRARY,
	// D3D12_SHVER_RAY_GENERATION_SHADER, D3D12_SHVER_INTERSECTION_SHADER, D3D12_SHVER_ANY_HIT_SHADER, D3D12_SHVER_CLOSEST_HIT_SHADER,
	// D3D12_SHVER_MISS_SHADER, D3D12_SHVER_CALLABLE_SHADER, D3D12_SHVER_MESH_SHADER, D3D12_SHVER_AMPLIFICATION_SHADER,
	// D3D12_SHVER_RESERVED0 = 0xFFF0 } ;
	[PInvokeData("d3d12shader.h", MSDNShortId = "NE:d3d12shader.D3D12_SHADER_VERSION_TYPE")]
	public enum D3D12_SHADER_VERSION_TYPE
	{
		/// <summary>
		/// <para>Value: 0 Pixel shader.</para>
		/// </summary>
		D3D12_SHVER_PIXEL_SHADER,

		/// <summary>
		/// <para>Value: 1 Vertex shader.</para>
		/// </summary>
		D3D12_SHVER_VERTEX_SHADER,

		/// <summary>
		/// <para>Value: 2 Geometry shader.</para>
		/// </summary>
		D3D12_SHVER_GEOMETRY_SHADER,

		/// <summary>
		/// <para>Value: 3 Hull shader.</para>
		/// </summary>
		D3D12_SHVER_HULL_SHADER,

		/// <summary>
		/// <para>Value: 4 Domain shader.</para>
		/// </summary>
		D3D12_SHVER_DOMAIN_SHADER,

		/// <summary>
		/// <para>Value: 5 Compute shader.</para>
		/// </summary>
		D3D12_SHVER_COMPUTE_SHADER,

		/// <summary>
		/// <para>Value: 0xFFF0 Indicates the end of the enumeration.</para>
		/// </summary>
		D3D12_SHVER_RESERVED0 = 0xFFF0,
	}

	/// <summary>
	/// <para>A function-parameter-reflection interface accesses function-parameter info.</para>
	/// <para>
	/// <b>Note</b>  This interface is part of the HLSL shader linking technology that you can use on all Direct3D 12 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To get a function-parameter-reflection interface, call <c>ID3D12FunctionReflection::GetFunctionParameter</c>. This isn't a COM
	/// interface, so you don't need to worry about reference counts or releasing the interface when you're done with it.
	/// </para>
	/// <para><b>Note</b>   <b>ID3D12FunctionParameterReflection</b> requires the D3dcompiler_47.dll or a later version of the DLL.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nn-d3d12shader-id3d12functionparameterreflection
	[PInvokeData("d3d12shader.h", MSDNShortId = "NN:d3d12shader.ID3D12FunctionParameterReflection")]
	[ComImport, Guid("ec25f42d-7006-4f2b-b33e-02cc3375733f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12FunctionParameterReflection
	{
		/// <summary>Fills the parameter descriptor structure for the function's parameter.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_PARAMETER_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_PARAMETER_DESC</c> structure that receives a description of the function's parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12functionparameterreflection-getdesc HRESULT
		// GetDesc( [out] D3D12_PARAMETER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D12_PARAMETER_DESC pDesc);
	}

	/// <summary>
	/// <para>A function-reflection interface accesses function info.</para>
	/// <para>
	/// <b>Note</b>  This interface is part of the HLSL shader linking technology that you can use on all Direct3D 12 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To get a function-reflection interface, call <c>ID3D12LibraryReflection::GetFunctionByIndex</c>. This isn't a COM interface, so you
	/// don't need to worry about reference counts or releasing the interface when you're done with it.
	/// </para>
	/// <para><b>Note</b>   <b>ID3D12FunctionReflection</b> requires the D3dcompiler_47.dll or a later version of the DLL.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nn-d3d12shader-id3d12functionreflection
	[PInvokeData("d3d12shader.h", MSDNShortId = "NN:d3d12shader.ID3D12FunctionReflection")]
	[ComImport, Guid("1108795c-2772-4ba9-b2a8-d464dc7e2799"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12FunctionReflection
	{
		/// <summary>Fills the function descriptor structure for the function.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_FUNCTION_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_FUNCTION_DESC</c> structure that receives a description of the function.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12functionreflection-getdesc HRESULT GetDesc(
		// [out] D3D12_FUNCTION_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D12_FUNCTION_DESC pDesc);

		/// <summary>Gets a constant buffer by index for a function.</summary>
		/// <param name="BufferIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionConstantBuffer</c>*</b></para>
		/// <para>A pointer to a <c>ID3D12ShaderReflectionConstantBuffer</c> interface that represents the constant buffer.</para>
		/// </returns>
		/// <remarks>
		/// A constant buffer supplies either scalar constants or texture constants to a shader. A shader can use one or more constant
		/// buffers. For best performance, separate constants into buffers based on the frequency they are updated.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12functionreflection-getconstantbufferbyindex
		// ID3D12ShaderReflectionConstantBuffer * GetConstantBufferByIndex( [in] UINT BufferIndex );
		[PreserveSig]
		ID3D12ShaderReflectionConstantBuffer GetConstantBufferByIndex(uint BufferIndex);

		/// <summary>Gets a constant buffer by name for a function.</summary>
		/// <param name="Name">
		/// <para>Type: <b><c>LPCSTR</c></b></para>
		/// <para>The constant-buffer name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionConstantBuffer</c>*</b></para>
		/// <para>A pointer to a <c>ID3D12ShaderReflectionConstantBuffer</c> interface that represents the constant buffer.</para>
		/// </returns>
		/// <remarks>
		/// A constant buffer supplies either scalar constants or texture constants to a shader. A shader can use one or more constant
		/// buffers. For best performance, separate constants into buffers based on the frequency they are updated.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12functionreflection-getconstantbufferbyname
		// ID3D12ShaderReflectionConstantBuffer * GetConstantBufferByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D12ShaderReflectionConstantBuffer GetConstantBufferByName([MarshalAs(UnmanagedType.LPStr)] string Name);

		/// <summary>Gets a description of how a resource is bound to a function.</summary>
		/// <param name="ResourceIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A zero-based resource index.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SHADER_INPUT_BIND_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_SHADER_INPUT_BIND_DESC</c> structure that describes input binding of the resource.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// A shader consists of executable code (the compiled HLSL functions) and a set of resources that supply the shader with input
		/// data. <b>GetResourceBindingDesc</b> gets info about how one resource in the set is bound as an input to the shader. The
		/// <i>ResourceIndex</i> parameter specifies the index for the resource.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12functionreflection-getresourcebindingdesc
		// HRESULT GetResourceBindingDesc( [in] UINT ResourceIndex, [out] D3D12_SHADER_INPUT_BIND_DESC *pDesc );
		[PreserveSig]
		HRESULT GetResourceBindingDesc(uint ResourceIndex, out D3D12_SHADER_INPUT_BIND_DESC pDesc);

		/// <summary>Gets a variable by name.</summary>
		/// <param name="Name">
		/// <para>Type: <b><c>LPCSTR</c></b></para>
		/// <para>A pointer to a string containing the variable name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionVariable</c>*</b></para>
		/// <para>Returns a <c>ID3D12ShaderReflectionVariable Interface</c> interface.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12functionreflection-getvariablebyname
		// ID3D12ShaderReflectionVariable * GetVariableByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D12ShaderReflectionVariable GetVariableByName([MarshalAs(UnmanagedType.LPStr)] string Name);

		/// <summary>Gets a description of how a resource is bound to a function.</summary>
		/// <param name="Name">
		/// <para>Type: <b><c>LPCSTR</c></b></para>
		/// <para>The constant-buffer name of the resource.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SHADER_INPUT_BIND_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_SHADER_INPUT_BIND_DESC</c> structure that describes input binding of the resource.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// A shader consists of executable code (the compiled HLSL functions) and a set of resources that supply the shader with input
		/// data. <b>GetResourceBindingDescByName</b> gets info about how one resource in the set is bound as an input to the shader. The
		/// <i>Name</i> parameter specifies the name of the resource.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12functionreflection-getresourcebindingdescbyname
		// HRESULT GetResourceBindingDescByName( [in] LPCSTR Name, [out] D3D12_SHADER_INPUT_BIND_DESC *pDesc );
		[PreserveSig]
		HRESULT GetResourceBindingDescByName([MarshalAs(UnmanagedType.LPStr)] string Name, out D3D12_SHADER_INPUT_BIND_DESC pDesc);

		/// <summary>Gets the function parameter reflector.</summary>
		/// <param name="ParameterIndex">
		/// <para>Type: <b>INT</b></para>
		/// <para>The zero-based index of the function parameter reflector to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12FunctionParameterReflection</c>*</b></para>
		/// <para>A pointer to a <c>ID3D12FunctionParameterReflection</c> interface that represents the function parameter reflector.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12functionreflection-getfunctionparameter
		// ID3D12FunctionParameterReflection * GetFunctionParameter( [in] INT ParameterIndex );
		[PreserveSig]
		ID3D12FunctionParameterReflection GetFunctionParameter(int ParameterIndex);
	}

	/// <summary>
	/// <para>A library-reflection interface accesses library info.</para>
	/// <para>
	/// <b>Note</b>  This interface is part of the HLSL shader linking technology that you can use on all Direct3D 12 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>To get a library-reflection interface, call <c>D3DReflectLibrary</c>.</para>
	/// <para><b>Note</b>   <b>ID3D12LibraryReflection</b> requires the D3dcompiler_47.dll or a later version of the DLL.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nn-d3d12shader-id3d12libraryreflection
	[PInvokeData("d3d12shader.h", MSDNShortId = "NN:d3d12shader.ID3D12LibraryReflection")]
	[ComImport, Guid("8e349d19-54db-4a56-9dc9-119d87bdb804"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12LibraryReflection
	{
		/// <summary>Fills the library descriptor structure for the library reflection.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_LIBRARY_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_LIBRARY_DESC</c> structure that receives a description of the library reflection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12libraryreflection-getdesc HRESULT GetDesc(
		// [out] D3D12_LIBRARY_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D12_LIBRARY_DESC pDesc);

		/// <summary>Gets the function reflector.</summary>
		/// <param name="FunctionIndex">
		/// <para>Type: <b>INT</b></para>
		/// <para>The zero-based index of the function reflector to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12FunctionReflection</c>*</b></para>
		/// <para>The function reflector, as a pointer to <c>ID3D12FunctionReflection</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12libraryreflection-getfunctionbyindex
		// ID3D12FunctionReflection * GetFunctionByIndex( [in] INT FunctionIndex );
		[PreserveSig]
		ID3D12FunctionReflection GetFunctionByIndex(int FunctionIndex);
	}

	/// <summary>A shader-reflection interface accesses shader information.</summary>
	/// <remarks>
	/// <para>An <b>ID3D12ShaderReflection</b> interface can be retrieved for a shader by using <c>D3DReflect</c>.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// This function from <c>d3dcompiler.dll</c> supports Shader Model 2 - 5.1. For Shader Model 6 shader reflection, see
	/// <c>dxcompiler.dll</c> and <c>Using dxc.exe and dxcompiler.dll</c>.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nn-d3d12shader-id3d12shaderreflection
	[PInvokeData("d3d12shader.h", MSDNShortId = "NN:d3d12shader.ID3D12ShaderReflection")]
	[ComImport, Guid("5a58797d-a72c-478d-8ba2-efc6b0efe88e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12ShaderReflection
	{
		/// <summary>Gets a shader description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SHADER_DESC</c>*</b></para>
		/// <para>A shader description, as a pointer to a <c>D3D12_SHADER_DESC</c> structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the following <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getdesc HRESULT GetDesc(
		// [out] D3D12_SHADER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D12_SHADER_DESC pDesc);

		/// <summary>Gets a constant buffer by index.</summary>
		/// <param name="Index">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionConstantBuffer</c>*</b></para>
		/// <para>A pointer to a constant buffer (see <c>ID3D12ShaderReflectionConstantBuffer Interface</c>).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A constant buffer supplies either scalar constants or texture constants to a shader. A shader can use one or more constant
		/// buffers. For best performance, separate constants into buffers based on the frequency they are updated.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getconstantbufferbyindex
		// ID3D12ShaderReflectionConstantBuffer * GetConstantBufferByIndex( [in] UINT Index );
		[PreserveSig]
		ID3D12ShaderReflectionConstantBuffer GetConstantBufferByIndex(uint Index);

		/// <summary>Gets a constant buffer by name.</summary>
		/// <param name="Name">
		/// <para>Type: <b><c>LPCSTR</c></b></para>
		/// <para>The constant-buffer name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionConstantBuffer</c>*</b></para>
		/// <para>A pointer to a constant buffer (see <c>ID3D12ShaderReflectionConstantBuffer Interface</c>).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A constant buffer supplies either scalar constants or texture constants to a shader. A shader can use one or more constant
		/// buffers. For best performance, separate constants into buffers based on the frequency they are updated.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getconstantbufferbyname
		// ID3D12ShaderReflectionConstantBuffer * GetConstantBufferByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D12ShaderReflectionConstantBuffer GetConstantBufferByName([MarshalAs(UnmanagedType.LPStr)] string Name);

		/// <summary>Gets a description of how a resource is bound to a shader.</summary>
		/// <param name="ResourceIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A zero-based resource index.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SHADER_INPUT_BIND_DESC</c>*</b></para>
		/// <para>A pointer to an input-binding description. See <c>D3D12_SHADER_INPUT_BIND_DESC</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A shader consists of executable code (the compiled HLSL functions) and a set of resources that supply the shader with input
		/// data. <b>GetResourceBindingDesc</b> gets information about how one resource in the set is bound as an input to the shader. The
		/// <i>ResourceIndex</i> parameter specifies the index for the resource.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getresourcebindingdesc
		// HRESULT GetResourceBindingDesc( [in] UINT ResourceIndex, [out] D3D12_SHADER_INPUT_BIND_DESC *pDesc );
		[PreserveSig]
		HRESULT GetResourceBindingDesc(uint ResourceIndex, out D3D12_SHADER_INPUT_BIND_DESC pDesc);

		/// <summary>Gets an input-parameter description for a shader.</summary>
		/// <param name="ParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A zero-based parameter index.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SIGNATURE_PARAMETER_DESC</c>*</b></para>
		/// <para>A pointer to a shader-input-signature description. See <c>D3D12_SIGNATURE_PARAMETER_DESC</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An input-parameter description is also called a shader signature. The shader signature contains information about the input
		/// parameters such as the order or parameters, their data type, and a parameter semantic.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getinputparameterdesc
		// HRESULT GetInputParameterDesc( [in] UINT ParameterIndex, [out] D3D12_SIGNATURE_PARAMETER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetInputParameterDesc(uint ParameterIndex, out D3D12_SIGNATURE_PARAMETER_DESC pDesc);

		/// <summary>Gets an output-parameter description for a shader.</summary>
		/// <param name="ParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A zero-based parameter index.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SIGNATURE_PARAMETER_DESC</c>*</b></para>
		/// <para>A shader-output-parameter description, as a pointer to a <c>D3D12_SIGNATURE_PARAMETER_DESC</c> structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An output-parameter description is also called a shader signature. The shader signature contains information about the output
		/// parameters such as the order or parameters, their data type, and a parameter semantic.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getoutputparameterdesc
		// HRESULT GetOutputParameterDesc( [in] UINT ParameterIndex, [out] D3D12_SIGNATURE_PARAMETER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetOutputParameterDesc(uint ParameterIndex, out D3D12_SIGNATURE_PARAMETER_DESC pDesc);

		/// <summary>Gets a patch-constant parameter description for a shader.</summary>
		/// <param name="ParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A zero-based parameter index.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SIGNATURE_PARAMETER_DESC</c>*</b></para>
		/// <para>A pointer to a shader-input-signature description. See <c>D3D12_SIGNATURE_PARAMETER_DESC</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getpatchconstantparameterdesc
		// HRESULT GetPatchConstantParameterDesc( [in] UINT ParameterIndex, [out] D3D12_SIGNATURE_PARAMETER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetPatchConstantParameterDesc(uint ParameterIndex, out D3D12_SIGNATURE_PARAMETER_DESC pDesc);

		/// <summary>Gets a variable by name.</summary>
		/// <param name="Name">
		/// <para>Type: <b><c>LPCSTR</c></b></para>
		/// <para>A pointer to a string containing the variable name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionVariable</c>*</b></para>
		/// <para>Returns a <c>ID3D12ShaderReflectionVariable Interface</c> interface.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getvariablebyname
		// ID3D12ShaderReflectionVariable * GetVariableByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D12ShaderReflectionVariable GetVariableByName([MarshalAs(UnmanagedType.LPStr)] string Name);

		/// <summary>Gets a description of how a resource is bound to a shader.</summary>
		/// <param name="Name">
		/// <para>Type: <b><c>LPCSTR</c></b></para>
		/// <para>The constant-buffer name of the resource.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SHADER_INPUT_BIND_DESC</c>*</b></para>
		/// <para>A pointer to an input-binding description. See <c>D3D12_SHADER_INPUT_BIND_DESC</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A shader consists of executable code (the compiled HLSL functions) and a set of resources that supply the shader with input
		/// data. <b>GetResourceBindingDescByName</b> gets information about how one resource in the set is bound as an input to the shader.
		/// The <i>Name</i> parameter specifies the name of the resource.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getresourcebindingdescbyname
		// HRESULT GetResourceBindingDescByName( [in] LPCSTR Name, [out] D3D12_SHADER_INPUT_BIND_DESC *pDesc );
		[PreserveSig]
		HRESULT GetResourceBindingDescByName([MarshalAs(UnmanagedType.LPStr)] string Name, out D3D12_SHADER_INPUT_BIND_DESC pDesc);

		/// <summary>Gets the number of Mov instructions.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Returns the number of Mov instructions.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getmovinstructioncount UINT GetMovInstructionCount();
		[PreserveSig]
		uint GetMovInstructionCount();

		/// <summary>Gets the number of Movc instructions.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Returns the number of Movc instructions.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getmovcinstructioncount
		// UINT GetMovcInstructionCount();
		[PreserveSig]
		uint GetMovcInstructionCount();

		/// <summary>Gets the number of conversion instructions.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Returns the number of conversion instructions.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getconversioninstructioncount
		// UINT GetConversionInstructionCount();
		[PreserveSig]
		uint GetConversionInstructionCount();

		/// <summary>Gets the number of bitwise instructions.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of bitwise instructions.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getbitwiseinstructioncount
		// UINT GetBitwiseInstructionCount();
		[PreserveSig]
		uint GetBitwiseInstructionCount();

		/// <summary>Gets the geometry-shader input-primitive description.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D_PRIMITIVE</c></b></para>
		/// <para>The input-primitive description. See <c>D3D_PRIMITIVE_TOPOLOGY</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getgsinputprimitive
		// D3D_PRIMITIVE GetGSInputPrimitive();
		[PreserveSig]
		D3D_PRIMITIVE GetGSInputPrimitive();

		/// <summary>Indicates whether a shader is a sample frequency shader.</summary>
		/// <returns>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para>Returns true if the shader is a sample frequency shader; otherwise returns false.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-issamplefrequencyshader
		// BOOL IsSampleFrequencyShader();
		[PreserveSig]
		bool IsSampleFrequencyShader();

		/// <summary>Gets the number of interface slots in a shader.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of interface slots in the shader.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getnuminterfaceslots UINT GetNumInterfaceSlots();
		[PreserveSig]
		uint GetNumInterfaceSlots();

		/// <summary>Gets the minimum feature level.</summary>
		/// <param name="pLevel">
		/// <para>Type: <b><c>D3D_FEATURE_LEVEL</c>*</b></para>
		/// <para>A pointer to one of the enumerated values in <c>D3D_FEATURE_LEVEL</c>, which represents the minimum feature level.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getminfeaturelevel HRESULT
		// GetMinFeatureLevel( [out] D3D_FEATURE_LEVEL *pLevel );
		[PreserveSig]
		HRESULT GetMinFeatureLevel(out D3D_FEATURE_LEVEL pLevel);

		/// <summary>Retrieves the sizes, in units of threads, of the X, Y, and Z dimensions of the shader's thread-group grid.</summary>
		/// <param name="pSizeX">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>A pointer to the size, in threads, of the x-dimension of the thread-group grid. The maximum size is 1024.</para>
		/// </param>
		/// <param name="pSizeY">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>A pointer to the size, in threads, of the y-dimension of the thread-group grid. The maximum size is 1024.</para>
		/// </param>
		/// <param name="pSizeZ">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>A pointer to the size, in threads, of the z-dimension of the thread-group grid. The maximum size is 64.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Returns the total size, in threads, of the thread-group grid by calculating the product of the size of each dimension.</para>
		/// <para><c>*pSizeX * *pSizeY * *pSizeZ;</c></para>
		/// </returns>
		/// <remarks>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// <para>
		/// When a compute shader is written it defines the actions of a single thread group only. If multiple thread groups are required,
		/// it is the role of the <c>ID3D12GraphicsCommandList::Dispatch</c> call to issue multiple thread groups.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getthreadgroupsize UINT
		// GetThreadGroupSize( [out, optional] UINT *pSizeX, [out, optional] UINT *pSizeY, [out, optional] UINT *pSizeZ );
		[PreserveSig]
		uint GetThreadGroupSize(out uint pSizeX, out uint pSizeY, out uint pSizeZ);

		/// <summary>Retrieves a group of flags that indicate the requirements of a shader.</summary>
		/// <returns>
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// A value that contains a combination of one or more shader requirements <c>#define</c> flags; each flag specifies a requirement
		/// of the shader. A default value of 0 means that there are no requirements.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflection-getrequiresflags UINT64 GetRequiresFlags();
		[PreserveSig]
		D3D_SHADER_REQUIRES GetRequiresFlags();
	}

	/// <summary>This shader-reflection interface provides access to a constant buffer.</summary>
	/// <remarks>
	/// To create a constant-buffer interface, call <c>ID3D12ShaderReflection::GetConstantBufferByIndex</c> or
	/// <c>ID3D12ShaderReflection::GetConstantBufferByName</c>. This isn't a COM interface, so you don't need to worry about reference
	/// counts or releasing the interface when you're done with it.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nn-d3d12shader-id3d12shaderreflectionconstantbuffer
	[PInvokeData("d3d12shader.h", MSDNShortId = "NN:d3d12shader.ID3D12ShaderReflectionConstantBuffer")]
	[ComImport, Guid("c59598b4-48b3-4869-b9b1-b1618b14a8b7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12ShaderReflectionConstantBuffer
	{
		/// <summary>Gets a constant-buffer description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SHADER_BUFFER_DESC</c>*</b></para>
		/// <para>A shader-buffer description, as a pointer to a <c>D3D12_SHADER_BUFFER_DESC</c> structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectionconstantbuffer-getdesc
		// HRESULT GetDesc( D3D12_SHADER_BUFFER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(ref D3D12_SHADER_BUFFER_DESC pDesc);

		/// <summary>Gets a shader-reflection variable by index.</summary>
		/// <param name="Index">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionVariable</c>*</b></para>
		/// <para>A pointer to a shader-reflection variable interface (see <c>ID3D12ShaderReflectionVariable Interface</c>).</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectionconstantbuffer-getvariablebyindex
		// ID3D12ShaderReflectionVariable * GetVariableByIndex( [in] UINT Index );
		[PreserveSig]
		ID3D12ShaderReflectionVariable GetVariableByIndex(uint Index);

		/// <summary>Gets a shader-reflection variable by name.</summary>
		/// <param name="Name">
		/// <para>Type: <b><c>LPCSTR</c></b></para>
		/// <para>Variable name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionVariable</c>*</b></para>
		/// <para>
		/// Returns a sentinel object (end of list marker). To determine if GetVariableByName successfully completed, call
		/// <c>ID3D12ShaderReflectionVariable::GetDesc</c> and check the returned <b>HRESULT</b>; any return value other than success means
		/// that GetVariableByName failed.
		/// </para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectionconstantbuffer-getvariablebyname
		// ID3D12ShaderReflectionVariable * GetVariableByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D12ShaderReflectionVariable GetVariableByName([MarshalAs(UnmanagedType.LPStr)] string Name);
	}

	/// <summary>This shader-reflection interface provides access to variable type.</summary>
	/// <remarks>
	/// The get a shader-reflection-type interface, call <c>ID3D12ShaderReflectionVariable::GetType</c>. This isn't a COM interface, so you
	/// don't need to worry about reference counts or releasing the interface when you're done with it.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nn-d3d12shader-id3d12shaderreflectiontype
	[PInvokeData("d3d12shader.h", MSDNShortId = "NN:d3d12shader.ID3D12ShaderReflectionType")]
	[ComImport, Guid("e913c351-783d-48ca-a1d1-4f306284ad56"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12ShaderReflectionType
	{
		/// <summary>Gets the description of a shader-reflection-variable type.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SHADER_TYPE_DESC</c>*</b></para>
		/// <para>A pointer to a shader-type description (see <c>D3D12_SHADER_TYPE_DESC</c>).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-getdesc HRESULT
		// GetDesc( [out] D3D12_SHADER_TYPE_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D12_SHADER_TYPE_DESC pDesc);

		/// <summary>Gets a shader-reflection-variable type by index.</summary>
		/// <param name="Index">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionType</c>*</b></para>
		/// <para>A pointer to a <c>ID3D12ShaderReflectionType Interface</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-getmembertypebyindex
		// ID3D12ShaderReflectionType * GetMemberTypeByIndex( [in] UINT Index );
		[PreserveSig]
		ID3D12ShaderReflectionType GetMemberTypeByIndex(uint Index);

		/// <summary>Gets a shader-reflection-variable type by name.</summary>
		/// <param name="Name">
		/// <para>Type: <b><c>LPCSTR</c></b></para>
		/// <para>Member name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionType</c>*</b></para>
		/// <para>A pointer to a <c>ID3D12ShaderReflectionType Interface</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-getmembertypebyname
		// ID3D12ShaderReflectionType * GetMemberTypeByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D12ShaderReflectionType GetMemberTypeByName([MarshalAs(UnmanagedType.LPStr)] string Name);

		/// <summary>Gets a shader-reflection-variable type.</summary>
		/// <param name="Index">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>LPCSTR</c></b></para>
		/// <para>The variable type.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-getmembertypename
		// LPCSTR GetMemberTypeName( [in] UINT Index );
		[PreserveSig]
		string GetMemberTypeName(uint Index);

		/// <summary>Indicates whether two <c>ID3D12ShaderReflectionType Interface</c> pointers have the same underlying type.</summary>
		/// <param name="pType">
		/// <para>Type: <b><c>ID3D12ShaderReflectionType</c>*</b></para>
		/// <para>A pointer to a <c>ID3D12ShaderReflectionType Interface</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns S_OK if the pointers have the same underlying type; otherwise returns S_FALSE.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// IsEqual indicates whether the sources of the <c>ID3D12ShaderReflectionType Interface</c> pointers have the same underlying type.
		/// For example, if two <b>ID3D12ShaderReflectionType Interface</b> pointers were retrieved from variables, IsEqual can be used to
		/// see if the variables have the same type.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-isequal HRESULT
		// IsEqual( [in] ID3D12ShaderReflectionType *pType );
		[PreserveSig]
		HRESULT IsEqual([In] ID3D12ShaderReflectionType pType);

		/// <summary>Gets the base class of a class.</summary>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionType</c>*</b></para>
		/// <para>
		/// Returns a pointer to an <c>ID3D12ShaderReflectionType</c> containing the base class type. Returns <b>NULL</b> if the class does
		/// not have a base class.
		/// </para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-getsubtype
		// ID3D12ShaderReflectionType * GetSubType();
		[PreserveSig]
		ID3D12ShaderReflectionType GetSubType();

		/// <summary>Gets an <c>ID3D12ShaderReflectionType Interface</c> interface containing the variable base class type.</summary>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionType</c>*</b></para>
		/// <para>Returns A pointer to a <c>ID3D12ShaderReflectionType Interface</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-getbaseclass
		// ID3D12ShaderReflectionType * GetBaseClass();
		[PreserveSig]
		ID3D12ShaderReflectionType GetBaseClass();

		/// <summary>Gets the number of interfaces.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Returns the number of interfaces.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-getnuminterfaces UINT GetNumInterfaces();
		[PreserveSig]
		uint GetNumInterfaces();

		/// <summary>Gets an interface by index.</summary>
		/// <param name="uIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionType</c>*</b></para>
		/// <para>A pointer to a <c>ID3D12ShaderReflectionType Interface</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-getinterfacebyindex
		// ID3D12ShaderReflectionType * GetInterfaceByIndex( [in] UINT uIndex );
		[PreserveSig]
		ID3D12ShaderReflectionType GetInterfaceByIndex(uint uIndex);

		/// <summary>Indicates whether a variable is of the specified type.</summary>
		/// <param name="pType">
		/// <para>Type: <b><c>ID3D12ShaderReflectionType</c>*</b></para>
		/// <para>A pointer to a <c>ID3D12ShaderReflectionType Interface</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns S_OK if object being queried is equal to or inherits from the type in the <i>pType</i> parameter; otherwise returns S_FALSE.
		/// </para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-isoftype HRESULT
		// IsOfType( [in] ID3D12ShaderReflectionType *pType );
		[PreserveSig]
		HRESULT IsOfType([In] ID3D12ShaderReflectionType pType);

		/// <summary>Indicates whether a class type implements an interface.</summary>
		/// <param name="pBase">
		/// <para>Type: <b><c>ID3D12ShaderReflectionType</c>*</b></para>
		/// <para>A pointer to a <c>ID3D12ShaderReflectionType Interface</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns S_OK if the interface is implemented; otherwise return S_FALSE.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectiontype-implementsinterface
		// HRESULT ImplementsInterface( [in] ID3D12ShaderReflectionType *pBase );
		[PreserveSig]
		HRESULT ImplementsInterface([In] ID3D12ShaderReflectionType pBase);
	}

	/// <summary>This shader-reflection interface provides access to a variable.</summary>
	/// <remarks>
	/// To get a shader-reflection-variable interface, call a method like <c>ID3D12ShaderReflection::GetVariableByName</c>. This isn't a COM
	/// interface, so you don't need to worry about reference counts or releasing the interface when you're done with it.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nn-d3d12shader-id3d12shaderreflectionvariable
	[PInvokeData("d3d12shader.h", MSDNShortId = "NN:d3d12shader.ID3D12ShaderReflectionVariable")]
	[ComImport, Guid("8337a8a6-a216-444a-b2f4-314733a73aea"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12ShaderReflectionVariable
	{
		/// <summary>Gets a shader-variable description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b><c>D3D12_SHADER_VARIABLE_DESC</c>*</b></para>
		/// <para>A pointer to a shader-variable description (see <c>D3D12_SHADER_VARIABLE_DESC</c>).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method can be used to determine if the <c>ID3D12ShaderReflectionVariable Interface</c> is valid, the method returns
		/// <b>E_FAIL</b> when the variable is not valid.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectionvariable-getdesc HRESULT
		// GetDesc( [out] D3D12_SHADER_VARIABLE_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D12_SHADER_VARIABLE_DESC pDesc);

		/// <summary>Gets a shader-variable type.</summary>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionType</c>*</b></para>
		/// <para>A pointer to a <c>ID3D12ShaderReflectionType Interface</c>.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectionvariable-gettype
		// ID3D12ShaderReflectionType * GetType();
		[PreserveSig]
		ID3D12ShaderReflectionType GetType();

		/// <summary>Returns the <c>ID3D12ShaderReflectionConstantBuffer</c> of the present <c>ID3D12ShaderReflectionVariable</c>.</summary>
		/// <returns>
		/// <para>Type: <b><c>ID3D12ShaderReflectionConstantBuffer</c>*</b></para>
		/// <para>Returns a pointer to the <c>ID3D12ShaderReflectionConstantBuffer</c> of the present <c>ID3D12ShaderReflectionVariable</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectionvariable-getbuffer
		// ID3D12ShaderReflectionConstantBuffer * GetBuffer();
		[PreserveSig]
		ID3D12ShaderReflectionConstantBuffer GetBuffer();

		/// <summary>Gets the corresponding interface slot for a variable that represents an interface pointer.</summary>
		/// <param name="uArrayIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The index of the array element to get the slot number for. For a non-array variable this value will be zero.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Returns the index of the interface in the interface array.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// GetInterfaceSlot gets the corresponding slot in a dynamic linkage array for an interface instance. The returned slot number is
		/// used to set an interface instance to a particular class instance. See the HLSL <c>Interfaces and Classes</c> overview for
		/// additional information.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/nf-d3d12shader-id3d12shaderreflectionvariable-getinterfaceslot
		// UINT GetInterfaceSlot( [in] UINT uArrayIndex );
		[PreserveSig]
		uint GetInterfaceSlot(uint uArrayIndex);
	}

	/// <summary>Describes a function.</summary>
	/// <remarks>This structure is returned by <c>ID3D12FunctionReflection::GetDesc</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/ns-d3d12shader-d3d12_function_desc typedef struct D3D12_FUNCTION_DESC
	// { UINT Version; LPCSTR Creator; UINT Flags; UINT ConstantBuffers; UINT BoundResources; UINT InstructionCount; UINT TempRegisterCount;
	// UINT TempArrayCount; UINT DefCount; UINT DclCount; UINT TextureNormalInstructions; UINT TextureLoadInstructions; UINT
	// TextureCompInstructions; UINT TextureBiasInstructions; UINT TextureGradientInstructions; UINT FloatInstructionCount; UINT
	// IntInstructionCount; UINT UintInstructionCount; UINT StaticFlowControlCount; UINT DynamicFlowControlCount; UINT
	// MacroInstructionCount; UINT ArrayInstructionCount; UINT MovInstructionCount; UINT MovcInstructionCount; UINT
	// ConversionInstructionCount; UINT BitwiseInstructionCount; D3D_FEATURE_LEVEL MinFeatureLevel; UINT64 RequiredFeatureFlags; LPCSTR
	// Name; INT FunctionParameterCount; BOOL HasReturn; BOOL Has10Level9VertexShader; BOOL Has10Level9PixelShader; } D3D12_FUNCTION_DESC;
	[PInvokeData("d3d12shader.h", MSDNShortId = "NS:d3d12shader.D3D12_FUNCTION_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FUNCTION_DESC
	{
		/// <summary>The shader version. See also <c>D3D12_SHADER_VERSION_TYPE</c>.</summary>
		public uint Version;

		/// <summary>The name of the originator of the function.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Creator;

		/// <summary>
		/// A combination of <c>D3DCOMPILE Constants</c> that are combined by using a bitwise OR operation. The resulting value specifies
		/// shader compilation and parsing.
		/// </summary>
		public D3DCOMPILE Flags;

		/// <summary>The number of constant buffers for the function.</summary>
		public uint ConstantBuffers;

		/// <summary>The number of bound resources for the function.</summary>
		public uint BoundResources;

		/// <summary>The number of emitted instructions for the function.</summary>
		public uint InstructionCount;

		/// <summary>The number of temporary registers used by the function.</summary>
		public uint TempRegisterCount;

		/// <summary>The number of temporary arrays used by the function.</summary>
		public uint TempArrayCount;

		/// <summary>The number of constant defines for the function.</summary>
		public uint DefCount;

		/// <summary>The number of declarations (input + output) for the function.</summary>
		public uint DclCount;

		/// <summary>The number of non-categorized texture instructions for the function.</summary>
		public uint TextureNormalInstructions;

		/// <summary>The number of texture load instructions for the function.</summary>
		public uint TextureLoadInstructions;

		/// <summary>The number of texture comparison instructions for the function.</summary>
		public uint TextureCompInstructions;

		/// <summary>The number of texture bias instructions for the function.</summary>
		public uint TextureBiasInstructions;

		/// <summary>The number of texture gradient instructions for the function.</summary>
		public uint TextureGradientInstructions;

		/// <summary>The number of floating point arithmetic instructions used by the function.</summary>
		public uint FloatInstructionCount;

		/// <summary>The number of signed integer arithmetic instructions used by the function.</summary>
		public uint IntInstructionCount;

		/// <summary>The number of unsigned integer arithmetic instructions used by the function.</summary>
		public uint UintInstructionCount;

		/// <summary>The number of static flow control instructions used by the function.</summary>
		public uint StaticFlowControlCount;

		/// <summary>The number of dynamic flow control instructions used by the function.</summary>
		public uint DynamicFlowControlCount;

		/// <summary>The number of macro instructions used by the function.</summary>
		public uint MacroInstructionCount;

		/// <summary>The number of array instructions used by the function.</summary>
		public uint ArrayInstructionCount;

		/// <summary>The number of mov instructions used by the function.</summary>
		public uint MovInstructionCount;

		/// <summary>The number of movc instructions used by the function.</summary>
		public uint MovcInstructionCount;

		/// <summary>The number of type conversion instructions used by the function.</summary>
		public uint ConversionInstructionCount;

		/// <summary>The number of bitwise arithmetic instructions used by the function.</summary>
		public uint BitwiseInstructionCount;

		/// <summary>
		/// A <c>D3D_FEATURE_LEVEL</c>-typed value that specifies the minimum Direct3D feature level target of the function byte code.
		/// </summary>
		public D3D_FEATURE_LEVEL MinFeatureLevel;

		/// <summary>
		/// A value that contains a combination of one or more shader requirements flags; each flag specifies a requirement of the shader. A
		/// default value of 0 means there are no requirements. For a list of values, see <c>ID3D12ShaderReflection::GetRequiresFlags</c>.
		/// </summary>
		public ulong RequiredFeatureFlags;

		/// <summary>The name of the function.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;

		/// <summary>The number of logical parameters in the function signature, not including the return value.</summary>
		public int FunctionParameterCount;

		/// <summary>
		/// Indicates whether the function returns a value. <b>TRUE</b> indicates it returns a value; otherwise, <b>FALSE</b> (it is a subroutine).
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool HasReturn;

		/// <summary>
		/// Indicates whether there is a Direct3D 10Level9 vertex shader blob. <b>TRUE</b> indicates there is a 10Level9 vertex shader blob;
		/// otherwise, <b>FALSE</b>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Has10Level9VertexShader;

		/// <summary>
		/// Indicates whether there is a Direct3D 10Level9 pixel shader blob. <b>TRUE</b> indicates there is a 10Level9 pixel shader blob;
		/// otherwise, <b>FALSE</b>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Has10Level9PixelShader;
	}

	/// <summary>Describes a library.</summary>
	/// <remarks>This structure is returned by <c>ID3D12LibraryReflection::GetDesc</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/ns-d3d12shader-d3d12_library_desc typedef struct D3D12_LIBRARY_DESC {
	// LPCSTR Creator; UINT Flags; UINT FunctionCount; } D3D12_LIBRARY_DESC;
	[PInvokeData("d3d12shader.h", MSDNShortId = "NS:d3d12shader.D3D12_LIBRARY_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_LIBRARY_DESC
	{
		/// <summary>The name of the originator of the library.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Creator;

		/// <summary>
		/// A combination of <c>D3DCOMPILE Constants</c> that are combined by using a bitwise OR operation. The resulting value specifies
		/// how the compiler compiles.
		/// </summary>
		public D3DCOMPILE Flags;

		/// <summary>The number of functions exported from the library.</summary>
		public uint FunctionCount;
	}

	/// <summary>Describes a function parameter.</summary>
	/// <remarks>Get a function-parameter description by calling <c>ID3D12FunctionParameterReflection::GetDesc</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/ns-d3d12shader-d3d12_parameter_desc typedef struct
	// D3D12_PARAMETER_DESC { LPCSTR Name; LPCSTR SemanticName; D3D_SHADER_VARIABLE_TYPE Type; D3D_SHADER_VARIABLE_CLASS Class; UINT Rows;
	// UINT Columns; D3D_INTERPOLATION_MODE InterpolationMode; D3D_PARAMETER_FLAGS Flags; UINT FirstInRegister; UINT FirstInComponent; UINT
	// FirstOutRegister; UINT FirstOutComponent; } D3D12_PARAMETER_DESC;
	[PInvokeData("d3d12shader.h", MSDNShortId = "NS:d3d12shader.D3D12_PARAMETER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_PARAMETER_DESC
	{
		/// <summary>The name of the function parameter.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;

		/// <summary>
		/// The HLSL <c>semantic</c> that is associated with this function parameter. This name includes the index, for example, SV_Target[n].
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string SemanticName;

		/// <summary>A <c>D3D_SHADER_VARIABLE_TYPE</c>-typed value that identifies the variable type for the parameter.</summary>
		public D3D_SHADER_VARIABLE_TYPE Type;

		/// <summary>
		/// A <c>D3D_SHADER_VARIABLE_CLASS</c>-typed value that identifies the variable class for the parameter as one of scalar, vector,
		/// matrix, object, and so on.
		/// </summary>
		public D3D_SHADER_VARIABLE_CLASS Class;

		/// <summary>The number of rows for a matrix parameter.</summary>
		public uint Rows;

		/// <summary>The number of columns for a matrix parameter.</summary>
		public uint Columns;

		/// <summary>A <c>D3D_INTERPOLATION_MODE</c>-typed value that identifies the interpolation mode for the parameter.</summary>
		public D3D_INTERPOLATION_MODE InterpolationMode;

		/// <summary>
		/// A combination of <c>D3D_PARAMETER_FLAGS</c>-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies semantic flags for the parameter.
		/// </summary>
		public D3D_PARAMETER_FLAGS Flags;

		/// <summary>The first input register for this parameter.</summary>
		public uint FirstInRegister;

		/// <summary>The first input register component for this parameter.</summary>
		public uint FirstInComponent;

		/// <summary>The first output register for this parameter.</summary>
		public uint FirstOutRegister;

		/// <summary>The first output register component for this parameter.</summary>
		public uint FirstOutComponent;
	}

	/// <summary>Describes a shader constant-buffer.</summary>
	/// <remarks>
	/// Constants are supplied to shaders in a shader-constant buffer. Get the description of a shader-constant-buffer by calling <c>ID3D12ShaderReflectionConstantBuffer::GetDesc</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/ns-d3d12shader-d3d12_shader_buffer_desc typedef struct
	// D3D12_SHADER_BUFFER_DESC { LPCSTR Name; D3D_CBUFFER_TYPE Type; UINT Variables; UINT Size; UINT uFlags; } D3D12_SHADER_BUFFER_DESC;
	[PInvokeData("d3d12shader.h", MSDNShortId = "NS:d3d12shader.D3D12_SHADER_BUFFER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SHADER_BUFFER_DESC
	{
		/// <summary>The name of the buffer.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;

		/// <summary>A <c>D3D_CBUFFER_TYPE</c>-typed value that indicates the intended use of the constant data.</summary>
		public D3D_CBUFFER_TYPE Type;

		/// <summary>The number of unique variables.</summary>
		public uint Variables;

		/// <summary>The size of the buffer, in bytes.</summary>
		public uint Size;

		/// <summary>
		/// A combination of <c>D3D_SHADER_CBUFFER_FLAGS</c>-typed values that are combined by using a bitwise OR operation. The resulting
		/// value specifies properties for the shader constant-buffer.
		/// </summary>
		public D3D_SHADER_CBUFFER_FLAGS uFlags;
	}

	/// <summary>Describes a shader.</summary>
	/// <remarks>
	/// A shader is written in HLSL and compiled into an intermediate language by the HLSL compiler. The shader description returns
	/// information about the compiled shader. To get a shader description, call <c>ID3D12ShaderReflection::GetDesc</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/ns-d3d12shader-d3d12_shader_desc typedef struct D3D12_SHADER_DESC {
	// UINT Version; LPCSTR Creator; UINT Flags; UINT ConstantBuffers; UINT BoundResources; UINT InputParameters; UINT OutputParameters;
	// UINT InstructionCount; UINT TempRegisterCount; UINT TempArrayCount; UINT DefCount; UINT DclCount; UINT TextureNormalInstructions;
	// UINT TextureLoadInstructions; UINT TextureCompInstructions; UINT TextureBiasInstructions; UINT TextureGradientInstructions; UINT
	// FloatInstructionCount; UINT IntInstructionCount; UINT UintInstructionCount; UINT StaticFlowControlCount; UINT
	// DynamicFlowControlCount; UINT MacroInstructionCount; UINT ArrayInstructionCount; UINT CutInstructionCount; UINT EmitInstructionCount;
	// D3D_PRIMITIVE_TOPOLOGY GSOutputTopology; UINT GSMaxOutputVertexCount; D3D_PRIMITIVE InputPrimitive; UINT PatchConstantParameters;
	// UINT cGSInstanceCount; UINT cControlPoints; D3D_TESSELLATOR_OUTPUT_PRIMITIVE HSOutputPrimitive; D3D_TESSELLATOR_PARTITIONING
	// HSPartitioning; D3D_TESSELLATOR_DOMAIN TessellatorDomain; UINT cBarrierInstructions; UINT cInterlockedInstructions; UINT
	// cTextureStoreInstructions; } D3D12_SHADER_DESC;
	[PInvokeData("d3d12shader.h", MSDNShortId = "NS:d3d12shader.D3D12_SHADER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SHADER_DESC
	{
		/// <summary>
		/// <para>
		/// The Shader version, as an encoded UINT that corresponds to a shader model, such as "ps_5_0". <b>Version</b> describes the
		/// program type, a major version number, and a minor version number. The program type is a <c>D3D12_SHADER_VERSION_TYPE</c>
		/// enumeration constant. <b>Version</b> is decoded in the following way:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Program type = (Version &amp; 0xFFFF0000) &gt;&gt; 16</description>
		/// </item>
		/// <item>
		/// <description>Major version = (Version &amp; 0x000000F0) &gt;&gt; 4</description>
		/// </item>
		/// <item>
		/// <description>Minor version = (Version &amp; 0x0000000F)</description>
		/// </item>
		/// </list>
		/// </summary>
		public uint Version;

		/// <summary>The name of the originator of the shader.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Creator;

		/// <summary>Shader compilation/parse flags.</summary>
		public uint Flags;

		/// <summary>The number of shader-constant buffers.</summary>
		public uint ConstantBuffers;

		/// <summary>The number of resource (textures and buffers) bound to a shader.</summary>
		public uint BoundResources;

		/// <summary>The number of parameters in the input signature.</summary>
		public uint InputParameters;

		/// <summary>The number of parameters in the output signature.</summary>
		public uint OutputParameters;

		/// <summary>The number of intermediate-language instructions in the compiled shader.</summary>
		public uint InstructionCount;

		/// <summary>The number of temporary registers in the compiled shader.</summary>
		public uint TempRegisterCount;

		/// <summary>Number of temporary arrays used.</summary>
		public uint TempArrayCount;

		/// <summary>Number of constant defines.</summary>
		public uint DefCount;

		/// <summary>Number of declarations (input + output).</summary>
		public uint DclCount;

		/// <summary>Number of non-categorized texture instructions.</summary>
		public uint TextureNormalInstructions;

		/// <summary>Number of texture load instructions</summary>
		public uint TextureLoadInstructions;

		/// <summary>Number of texture comparison instructions</summary>
		public uint TextureCompInstructions;

		/// <summary>Number of texture bias instructions</summary>
		public uint TextureBiasInstructions;

		/// <summary>Number of texture gradient instructions.</summary>
		public uint TextureGradientInstructions;

		/// <summary>Number of floating point arithmetic instructions used.</summary>
		public uint FloatInstructionCount;

		/// <summary>Number of signed integer arithmetic instructions used.</summary>
		public uint IntInstructionCount;

		/// <summary>Number of unsigned integer arithmetic instructions used.</summary>
		public uint UintInstructionCount;

		/// <summary>Number of static flow control instructions used.</summary>
		public uint StaticFlowControlCount;

		/// <summary>Number of dynamic flow control instructions used.</summary>
		public uint DynamicFlowControlCount;

		/// <summary>Number of macro instructions used.</summary>
		public uint MacroInstructionCount;

		/// <summary>Number of array instructions used.</summary>
		public uint ArrayInstructionCount;

		/// <summary>Number of cut instructions used.</summary>
		public uint CutInstructionCount;

		/// <summary>Number of emit instructions used.</summary>
		public uint EmitInstructionCount;

		/// <summary>The <c>D3D_PRIMITIVE_TOPOLOGY</c>-typed value that represents the geometry shader output topology.</summary>
		public D3D_PRIMITIVE_TOPOLOGY GSOutputTopology;

		/// <summary>Geometry shader maximum output vertex count.</summary>
		public uint GSMaxOutputVertexCount;

		/// <summary>The <c>D3D_PRIMITIVE</c>-typed value that represents the input primitive for a geometry shader or hull shader.</summary>
		public D3D_PRIMITIVE InputPrimitive;

		/// <summary>Number of parameters in the patch-constant signature.</summary>
		public uint PatchConstantParameters;

		/// <summary>Number of geometry shader instances.</summary>
		public uint cGSInstanceCount;

		/// <summary>Number of control points in the hull shader and domain shader.</summary>
		public uint cControlPoints;

		/// <summary>The <c>D3D_TESSELLATOR_OUTPUT_PRIMITIVE</c>-typed value that represents the tessellator output-primitive type.</summary>
		public D3D_TESSELLATOR_OUTPUT_PRIMITIVE HSOutputPrimitive;

		/// <summary>The <c>D3D_TESSELLATOR_PARTITIONING</c>-typed value that represents the tessellator partitioning mode.</summary>
		public D3D_TESSELLATOR_PARTITIONING HSPartitioning;

		/// <summary>The <c>D3D_TESSELLATOR_DOMAIN</c>-typed value that represents the tessellator domain.</summary>
		public D3D_TESSELLATOR_DOMAIN TessellatorDomain;

		/// <summary>Number of barrier instructions in a compute shader.</summary>
		public uint cBarrierInstructions;

		/// <summary>Number of interlocked instructions in a compute shader.</summary>
		public uint cInterlockedInstructions;

		/// <summary>Number of texture writes in a compute shader.</summary>
		public uint cTextureStoreInstructions;
	}

	/// <summary>Describes how a shader resource is bound to a shader input.</summary>
	/// <remarks>Get a shader-input-signature description by calling <c>ID3D12ShaderReflection::GetResourceBindingDesc</c> or <c>ID3D12ShaderReflection::GetResourceBindingDescByName</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/ns-d3d12shader-d3d12_shader_input_bind_desc typedef struct
	// D3D12_SHADER_INPUT_BIND_DESC { LPCSTR Name; D3D_SHADER_INPUT_TYPE Type; UINT BindPoint; UINT BindCount; UINT uFlags;
	// D3D_RESOURCE_RETURN_TYPE ReturnType; D3D_SRV_DIMENSION Dimension; UINT NumSamples; UINT Space; UINT uID; } D3D12_SHADER_INPUT_BIND_DESC;
	[PInvokeData("d3d12shader.h", MSDNShortId = "NS:d3d12shader.D3D12_SHADER_INPUT_BIND_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SHADER_INPUT_BIND_DESC
	{
		/// <summary>Name of the shader resource.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;

		/// <summary>A <c>D3D_SHADER_INPUT_TYPE</c>-typed value that identifies the type of data in the resource.</summary>
		public D3D_SHADER_INPUT_TYPE Type;

		/// <summary>Starting bind point.</summary>
		public uint BindPoint;

		/// <summary>Number of contiguous bind points for arrays.</summary>
		public uint BindCount;

		/// <summary>A combination of <c>D3D_SHADER_INPUT_FLAGS</c>-typed values for shader input-parameter options.</summary>
		public D3D_SHADER_INPUT_FLAGS uFlags;

		/// <summary>If the input is a texture, the <c>D3D_RESOURCE_RETURN_TYPE</c>-typed value that identifies the return type.</summary>
		public D3D_RESOURCE_RETURN_TYPE ReturnType;

		/// <summary>A <c>D3D_SRV_DIMENSION</c>-typed value that identifies the dimensions of the bound resource.</summary>
		public D3D_SRV_DIMENSION Dimension;

		/// <summary>
		/// The number of samples for a multisampled texture; when a texture isn't multisampled, the value is set to -1 (0xFFFFFFFF). This
		/// is zero if the shader resource is not a recognized texture. If the shader resource is a structured buffer, the field contains
		/// the stride of the type in bytes.
		/// </summary>
		public uint NumSamples;

		/// <summary>The register space.</summary>
		public uint Space;

		/// <summary>The range ID in the bytecode.</summary>
		public uint uID;
	}

	/// <summary>Describes a shader-variable type.</summary>
	/// <remarks>Get a shader-variable-type description by calling <c>ID3D12ShaderReflectionType::GetDesc</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/ns-d3d12shader-d3d12_shader_type_desc typedef struct
	// D3D12_SHADER_TYPE_DESC { D3D_SHADER_VARIABLE_CLASS Class; D3D_SHADER_VARIABLE_TYPE Type; UINT Rows; UINT Columns; UINT Elements; UINT
	// Members; UINT Offset; LPCSTR Name; } D3D12_SHADER_TYPE_DESC;
	[PInvokeData("d3d12shader.h", MSDNShortId = "NS:d3d12shader.D3D12_SHADER_TYPE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SHADER_TYPE_DESC
	{
		/// <summary>
		/// A <c>D3D_SHADER_VARIABLE_CLASS</c>-typed value that identifies the variable class as one of scalar, vector, matrix, object, and
		/// so on.
		/// </summary>
		public D3D_SHADER_VARIABLE_CLASS Class;

		/// <summary>A <c>D3D_SHADER_VARIABLE_TYPE</c>-typed value that identifies the variable type.</summary>
		public D3D_SHADER_VARIABLE_TYPE Type;

		/// <summary>Number of rows in a matrix. Otherwise a numeric type returns 1, any other type returns 0.</summary>
		public uint Rows;

		/// <summary>Number of columns in a matrix. Otherwise a numeric type returns 1, any other type returns 0.</summary>
		public uint Columns;

		/// <summary>Number of elements in an array; otherwise 0.</summary>
		public uint Elements;

		/// <summary>Number of members in the structure; otherwise 0.</summary>
		public uint Members;

		/// <summary>Offset, in bytes, between the start of the parent structure and this variable. Can be 0 if not a structure member.</summary>
		public uint Offset;

		/// <summary>
		/// Name of the shader-variable type. This member can be <b>NULL</b> if it isn't used. This member supports dynamic shader linkage
		/// interface types, which have names. For more info about dynamic shader linkage, see <c>Dynamic Linking</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;
	}

	/// <summary>Describes a shader variable.</summary>
	/// <remarks>Get a shader-variable description using reflection by calling <c>ID3D12ShaderReflectionVariable::GetDesc</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/ns-d3d12shader-d3d12_shader_variable_desc typedef struct
	// D3D12_SHADER_VARIABLE_DESC { LPCSTR Name; UINT StartOffset; UINT Size; UINT uFlags; LPVOID DefaultValue; UINT StartTexture; UINT
	// TextureSize; UINT StartSampler; UINT SamplerSize; } D3D12_SHADER_VARIABLE_DESC;
	[PInvokeData("d3d12shader.h", MSDNShortId = "NS:d3d12shader.D3D12_SHADER_VARIABLE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SHADER_VARIABLE_DESC
	{
		/// <summary>The variable name.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;

		/// <summary>Offset from the start of the parent structure to the beginning of the variable.</summary>
		public uint StartOffset;

		/// <summary>Size of the variable (in bytes).</summary>
		public uint Size;

		/// <summary>
		/// A combination of <c>D3D_SHADER_VARIABLE_FLAGS</c>-typed values that are combined by using a bitwise-OR operation. The resulting
		/// value identifies shader-variable properties.
		/// </summary>
		public D3D_SHADER_VARIABLE_FLAGS uFlags;

		/// <summary>The default value for initializing the variable. Emits default values for reflection.</summary>
		public IntPtr DefaultValue;

		/// <summary>Offset from the start of the variable to the beginning of the texture.</summary>
		public uint StartTexture;

		/// <summary>The size of the texture, in bytes.</summary>
		public uint TextureSize;

		/// <summary>Offset from the start of the variable to the beginning of the sampler.</summary>
		public uint StartSampler;

		/// <summary>The size of the sampler, in bytes.</summary>
		public uint SamplerSize;
	}

	/// <summary>Describes a shader signature.</summary>
	/// <remarks>
	/// <para>
	/// A shader can take n inputs and can produce m outputs. The order of the input (or output) parameters, their associated types, and any
	/// attached semantics make up the shader signature. Each shader has an input and an output signature.
	/// </para>
	/// <para>
	/// When compiling a shader or an effect, some API calls validate shader signatures That is, they compare the output signature of one
	/// shader (like a vertex shader) with the input signature of another shader (like a pixel shader). This ensures that a shader outputs
	/// data that is compatible with a downstream shader that is consuming that data. Compatible means that a shader signature is a
	/// exact-match subset of the preceding shader stage. Exact match means parameter types and semantics must exactly match. Subset means
	/// that a parameter that is not required by a downstream stage, does not need to include that parameter in its shader signature.
	/// </para>
	/// <para>Get a shader-signature from a shader or an effect by calling APIs such as <c>ID3D12ShaderReflection::GetInputParameterDesc</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12shader/ns-d3d12shader-d3d12_signature_parameter_desc typedef struct
	// D3D12_SIGNATURE_PARAMETER_DESC { LPCSTR SemanticName; UINT SemanticIndex; UINT Register; D3D_NAME SystemValueType;
	// D3D_REGISTER_COMPONENT_TYPE ComponentType; BYTE Mask; BYTE ReadWriteMask; UINT Stream; D3D_MIN_PRECISION MinPrecision; } D3D12_SIGNATURE_PARAMETER_DESC;
	[PInvokeData("d3d12shader.h", MSDNShortId = "NS:d3d12shader.D3D12_SIGNATURE_PARAMETER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SIGNATURE_PARAMETER_DESC
	{
		/// <summary>A per-parameter string that identifies how the data will be used. For more info, see <c>Semantics</c>.</summary>
		[MarshalAs(UnmanagedType.LPStr)] public string SemanticName;

		/// <summary>Semantic index that modifies the semantic. Used to differentiate different parameters that use the same semantic.</summary>
		public uint SemanticIndex;

		/// <summary>The register that will contain this variable's data.</summary>
		public uint Register;

		/// <summary>
		/// A <c>D3D_NAME</c>-typed value that identifies a predefined string that determines the functionality of certain pipeline stages.
		/// </summary>
		public D3D_NAME SystemValueType;

		/// <summary>
		/// A <c>D3D_REGISTER_COMPONENT_TYPE</c>-typed value that identifies the per-component-data type that is stored in a register. Each
		/// register can store up to four-components of data.
		/// </summary>
		public D3D_REGISTER_COMPONENT_TYPE ComponentType;

		/// <summary>Mask which indicates which components of a register are used.</summary>
		public byte Mask;

		/// <summary>
		/// Mask which indicates whether a given component is never written (if the signature is an output signature) or always read (if the
		/// signature is an input signature).
		/// </summary>
		public byte ReadWriteMask;

		/// <summary>Indicates which stream the geometry shader is using for the signature parameter.</summary>
		public uint Stream;

		/// <summary>
		/// A <c>D3D_MIN_PRECISION</c>-typed value that indicates the minimum desired interpolation precision. For more info, see <c>Using
		/// HLSL minimum precision</c>.
		/// </summary>
		public D3D_MIN_PRECISION MinPrecision;
	}
}