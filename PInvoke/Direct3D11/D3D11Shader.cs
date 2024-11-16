using static Vanara.PInvoke.D3DCompiler;

namespace Vanara.PInvoke;

public static partial class D3D11
{
	/// <summary></summary>
	[PInvokeData("d3d11shader.h")]
	[Flags]
	public enum D3D_SHADER_REQUIRES_FLAGS : ulong
	{
		/// <summary>Shader requires that the graphics driver and hardware support double data type. For more info, see D3D11_FEATURE_DATA_DOUBLES.</summary>
		D3D_SHADER_REQUIRES_DOUBLES = 0x00000001,

		/// <summary>Shader requires an early depth stencil.</summary>
		D3D_SHADER_REQUIRES_EARLY_DEPTH_STENCIL = 0x00000002,

		/// <summary>Shader requires unordered access views (UAVs) at every pipeline stage.</summary>
		D3D_SHADER_REQUIRES_UAVS_AT_EVERY_STAGE = 0x00000004,

		/// <summary>Shader requires 64 UAVs.</summary>
		D3D_SHADER_REQUIRES_64_UAVS = 0x00000008,

		/// <summary>
		/// Shader requires the graphics driver and hardware to support minimum precision. For more info, see Using HLSL minimum precision.
		/// </summary>
		D3D_SHADER_REQUIRES_MINIMUM_PRECISION = 0x00000010,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support extended doubles instructions. For more info, see the
		/// ExtendedDoublesShaderInstructions member of D3D11_FEATURE_DATAD3D11_OPTIONS.
		/// </summary>
		D3D_SHADER_REQUIRES_11_1_DOUBLE_EXTENSIONS = 0x00000020,

		/// <summary>
		/// Shader requires that the graphics driver and hardware support the msad4 intrinsic function in shaders. For more info, see the
		/// SAD4ShaderInstructions member of D3D11_FEATURE_DATAD3D11_OPTIONS.
		/// </summary>
		D3D_SHADER_REQUIRES_11_1_SHADER_EXTENSIONS = 0x00000040,

		/// <summary>Shader requires that the graphics driver and hardware support Direct3D 9 shadow support. For more info, see D3D11_FEATURE_DATA_D3D9_SHADOW_SUPPORT.</summary>
		D3D_SHADER_REQUIRES_LEVEL_9_COMPARISON_FILTERING = 0x00000080,

		/// <summary>Shader requires that the graphics driver and hardware support tiled resources. For more info, see GetResourceTiling.</summary>
		D3D_SHADER_REQUIRES_TILED_RESOURCES = 0x00000100,
	}

	/// <summary>Indicates shader type.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/ne-d3d11shader-d3d11_shader_version_type typedef enum
	// D3D11_SHADER_VERSION_TYPE { D3D11_SHVER_PIXEL_SHADER = 0, D3D11_SHVER_VERTEX_SHADER = 1, D3D11_SHVER_GEOMETRY_SHADER = 2,
	// D3D11_SHVER_HULL_SHADER = 3, D3D11_SHVER_DOMAIN_SHADER = 4, D3D11_SHVER_COMPUTE_SHADER = 5, D3D11_SHVER_RESERVED0 = 0xFFF0 } ;
	[PInvokeData("d3d11shader.h", MSDNShortId = "NE:d3d11shader.D3D11_SHADER_VERSION_TYPE")]
	public enum D3D11_SHADER_VERSION_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Pixel shader.</para>
		/// </summary>
		D3D11_SHVER_PIXEL_SHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Vertex shader.</para>
		/// </summary>
		D3D11_SHVER_VERTEX_SHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Geometry shader.</para>
		/// </summary>
		D3D11_SHVER_GEOMETRY_SHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Hull shader.</para>
		/// </summary>
		D3D11_SHVER_HULL_SHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Domain shader.</para>
		/// </summary>
		D3D11_SHVER_DOMAIN_SHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Compute shader.</para>
		/// </summary>
		D3D11_SHVER_COMPUTE_SHADER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xFFF0</para>
		/// <para>Indicates the end of the enumeration constants.</para>
		/// </summary>
		D3D11_SHVER_RESERVED0,
	}

	/// <summary>
	/// <para>
	/// A function-linking-graph interface is used for constructing shaders that consist of a sequence of precompiled function calls that
	/// pass values to each other.
	/// </para>
	/// <note>This interface is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.</note>
	/// </summary>
	/// <remarks>
	/// <para>To get a function-linking-graph interface, call D3DCreateFunctionLinkingGraph.</para>
	/// <para>
	/// You can use the function-linking-graph (FLG) interface methods to construct shaders that consist of a sequence of precompiled
	/// function calls that pass values to each other. You don't need to write HLSL and then call the HLSL compiler. Instead, the shader
	/// structure is specified programmatically via a C++ API. FLG nodes represent input and output signatures and invocations of
	/// precompiled library functions. The order of registering the function-call nodes defines the sequence of invocations. You must
	/// specify the input signature node first and the output signature node last. FLG edges define how values are passed from one node to
	/// another. The data types of passed values must be the same; there is no implicit type conversion. Shape and swizzling rules follow
	/// the HLSL behavior. Values can only be passed forward in this sequence.
	/// </para>
	/// <note>ID3D11FunctionLinkingGraph requires the D3dcompiler_47.dll or a later version of the DLL.</note>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11functionlinkinggraph
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11FunctionLinkingGraph")]
	[ComImport, Guid("54133220-1ce8-43d3-8236-9855c5ceecff"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11FunctionLinkingGraph
	{
		/// <summary>Initializes a shader module from the function-linking-graph object.</summary>
		/// <param name="ppModuleInstance">
		/// <para>Type: <c>ID3D11ModuleInstance**</c></para>
		/// <para>The address of a pointer to an ID3D11ModuleInstance interface for the shader module to initialize.</para>
		/// </param>
		/// <param name="ppErrorBuffer">
		/// <para>Type: <c>ID3DBlob**</c></para>
		/// <para>
		/// An optional pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error
		/// messages, or <c>NULL</c> if there are no errors.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionlinkinggraph-createmoduleinstance
		// HRESULT CreateModuleInstance( [out] ID3D11ModuleInstance **ppModuleInstance, [out, optional] ID3DBlob **ppErrorBuffer );
		[PreserveSig]
		HRESULT CreateModuleInstance(out ID3D11ModuleInstance ppModuleInstance, [Out, Optional] IntPtr ppErrorBuffer);

		/// <summary>Sets the input signature of the function-linking-graph.</summary>
		/// <param name="pInputParameters">
		/// <para>Type: <c>const D3D11_PARAMETER_DESC*</c></para>
		/// <para>An array of D3D11_PARAMETER_DESC structures for the parameters of the input signature.</para>
		/// </param>
		/// <param name="cInputParameters">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of input parameters in the <c>pInputParameters</c> array.</para>
		/// </param>
		/// <param name="ppInputNode">
		/// <para>Type: <c>ID3D11LinkingNode**</c></para>
		/// <para>
		/// A pointer to a variable that receives a pointer to the ID3D11LinkingNode interface that represents the input signature of the function-linking-graph.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionlinkinggraph-setinputsignature
		// HRESULT SetInputSignature( [in] const D3D11_PARAMETER_DESC *pInputParameters, [in] UINT cInputParameters, [out] ID3D11LinkingNode
		// **ppInputNode );
		[PreserveSig]
		HRESULT SetInputSignature([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_PARAMETER_DESC[] pInputParameters, int cInputParameters,
			out ID3D11LinkingNode ppInputNode);

		/// <summary>Sets the output signature of the function-linking-graph.</summary>
		/// <param name="pOutputParameters">
		/// <para>Type: <c>const D3D11_PARAMETER_DESC*</c></para>
		/// <para>An array of D3D11_PARAMETER_DESC structures for the parameters of the output signature.</para>
		/// </param>
		/// <param name="cOutputParameters">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of output parameters in the <c>pOutputParameters</c> array.</para>
		/// </param>
		/// <param name="ppOutputNode">
		/// <para>Type: <c>ID3D11LinkingNode**</c></para>
		/// <para>
		/// A pointer to a variable that receives a pointer to the ID3D11LinkingNode interface that represents the output signature of the function-linking-graph.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionlinkinggraph-setoutputsignature
		// HRESULT SetOutputSignature( [in] const D3D11_PARAMETER_DESC *pOutputParameters, [in] UINT cOutputParameters, [out]
		// ID3D11LinkingNode **ppOutputNode );
		[PreserveSig]
		HRESULT SetOutputSignature([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_PARAMETER_DESC[] pOutputParameters, int cOutputParameters,
			out ID3D11LinkingNode ppOutputNode);

		/// <summary>Creates a call-function linking node to use in the function-linking-graph.</summary>
		/// <param name="pModuleInstanceNamespace">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The optional namespace for the function, or <c>NULL</c> if no namespace is needed.</para>
		/// </param>
		/// <param name="pModuleWithFunctionPrototype">
		/// <para>Type: <c>ID3D11Module*</c></para>
		/// <para>A pointer to the ID3D11ModuleInstance interface for the library module that contains the function prototype.</para>
		/// </param>
		/// <param name="pFunctionName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the function.</para>
		/// </param>
		/// <param name="ppCallNode">
		/// <para>Type: <c>ID3D11LinkingNode**</c></para>
		/// <para>
		/// A pointer to a variable that receives a pointer to the ID3D11LinkingNode interface that represents the function in the function-linking-graph.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionlinkinggraph-callfunction HRESULT
		// CallFunction( [in, optional] LPCSTR pModuleInstanceNamespace, [in] ID3D11Module *pModuleWithFunctionPrototype, [in] LPCSTR
		// pFunctionName, [out] ID3D11LinkingNode **ppCallNode );
		[PreserveSig]
		HRESULT CallFunction([Optional, MarshalAs(UnmanagedType.LPStr)] string? pModuleInstanceNamespace, [In] ID3D11Module pModuleWithFunctionPrototype,
			[MarshalAs(UnmanagedType.LPStr)] string pFunctionName, out ID3D11LinkingNode ppCallNode);

		/// <summary>Passes a value from a source linking node to a destination linking node.</summary>
		/// <param name="pSrcNode">
		/// <para>Type: <c>ID3D11LinkingNode*</c></para>
		/// <para>A pointer to the ID3D11LinkingNode interface for the source linking node.</para>
		/// </param>
		/// <param name="SrcParameterIndex">
		/// <para>Type: <c>INT</c></para>
		/// <para>The zero-based index of the source parameter.</para>
		/// </param>
		/// <param name="pDstNode">
		/// <para>Type: <c>ID3D11LinkingNode*</c></para>
		/// <para>A pointer to the ID3D11LinkingNode interface for the destination linking node.</para>
		/// </param>
		/// <param name="DstParameterIndex">
		/// <para>Type: <c>INT</c></para>
		/// <para>The zero-based index of the destination parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionlinkinggraph-passvalue HRESULT
		// PassValue( [in] ID3D11LinkingNode *pSrcNode, [in] INT SrcParameterIndex, [in] ID3D11LinkingNode *pDstNode, [in] INT
		// DstParameterIndex );
		[PreserveSig]
		HRESULT PassValue([In] ID3D11LinkingNode pSrcNode, int SrcParameterIndex, [In] ID3D11LinkingNode pDstNode, int DstParameterIndex);

		/// <summary>Passes a value with swizzle from a source linking node to a destination linking node.</summary>
		/// <param name="pSrcNode">
		/// <para>Type: <c>ID3D11LinkingNode*</c></para>
		/// <para>A pointer to the ID3D11LinkingNode interface for the source linking node.</para>
		/// </param>
		/// <param name="SrcParameterIndex">
		/// <para>Type: <c>INT</c></para>
		/// <para>The zero-based index of the source parameter.</para>
		/// </param>
		/// <param name="pSrcSwizzle">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the source swizzle.</para>
		/// </param>
		/// <param name="pDstNode">
		/// <para>Type: <c>ID3D11LinkingNode*</c></para>
		/// <para>A pointer to the ID3D11LinkingNode interface for the destination linking node.</para>
		/// </param>
		/// <param name="DstParameterIndex">
		/// <para>Type: <c>INT</c></para>
		/// <para>The zero-based index of the destination parameter.</para>
		/// </param>
		/// <param name="pDstSwizzle">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the destination swizzle.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionlinkinggraph-passvaluewithswizzle
		// HRESULT PassValueWithSwizzle( [in] ID3D11LinkingNode *pSrcNode, [in] INT SrcParameterIndex, [in] LPCSTR pSrcSwizzle, [in]
		// ID3D11LinkingNode *pDstNode, [in] INT DstParameterIndex, [in] LPCSTR pDstSwizzle );
		[PreserveSig]
		HRESULT PassValueWithSwizzle([In] ID3D11LinkingNode pSrcNode, int SrcParameterIndex, [MarshalAs(UnmanagedType.LPStr)] string pSrcSwizzle,
			[In] ID3D11LinkingNode pDstNode, int DstParameterIndex, [MarshalAs(UnmanagedType.LPStr)] string pDstSwizzle);

		/// <summary>Gets the error from the last function call of the function-linking-graph.</summary>
		/// <param name="ppErrorBuffer">
		/// <para>Type: <c>ID3DBlob**</c></para>
		/// <para>An pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the error.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionlinkinggraph-getlasterror HRESULT
		// GetLastError( [out, optional] ID3DBlob **ppErrorBuffer );
		[PreserveSig]
		HRESULT GetLastError(out ID3D10Blob ppErrorBuffer);

		/// <summary>Generates Microsoft High Level Shader Language (HLSL) shader code that represents the function-linking-graph.</summary>
		/// <param name="uFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Reserved</para>
		/// </param>
		/// <param name="ppBuffer">
		/// <para>Type: <c>ID3DBlob**</c></para>
		/// <para>
		/// An pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the HLSL shader source
		/// code that represents the function-linking-graph. You can compile this HLSL code, but first you must add code or include
		/// statements for the functions called in the function-linking-graph.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionlinkinggraph-generatehlsl HRESULT
		// GenerateHlsl( [in] UINT uFlags, [out] ID3DBlob **ppBuffer );
		[PreserveSig]
		HRESULT GenerateHlsl([Optional] uint uFlags, out ID3D10Blob ppBuffer);
	}

	/// <summary>
	/// <para>A function-parameter-reflection interface accesses function-parameter info.</para>
	/// <para>
	/// <c>Note</c>  This interface is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.
	/// <para></para>
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To get a function-parameter-reflection interface, call ID3D11FunctionReflection::GetFunctionParameter. This isn't a COM interface,
	/// so you don't need to worry about reference counts or releasing the interface when you're done with it.
	/// </para>
	/// <para><c>Note</c>   <c>ID3D11FunctionParameterReflection</c> requires the D3dcompiler_47.dll or a later version of the DLL.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11functionparameterreflection
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11FunctionParameterReflection")]
	[ComImport, Guid("42757488-334f-47fe-982e-1a65d08cc462"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11FunctionParameterReflection
	{
		/// <summary>Fills the parameter descriptor structure for the function's parameter.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_PARAMETER_DESC*</c></para>
		/// <para>A pointer to a D3D11_PARAMETER_DESC structure that receives a description of the function's parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionparameterreflection-getdesc HRESULT
		// GetDesc( [out] D3D11_PARAMETER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D11_PARAMETER_DESC pDesc);
	}

	/// <summary>
	/// <para>A function-reflection interface accesses function info.</para>
	/// <note>This interface is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.</note>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To get a function-reflection interface, call ID3D11LibraryReflection::GetFunctionByIndex. This isn't a COM interface, so you don't
	/// need to worry about reference counts or releasing the interface when you're done with it.
	/// </para>
	/// <note><c>ID3D11FunctionReflection</c> requires the D3dcompiler_47.dll or a later version of the DLL.</note>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11functionreflection
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11FunctionReflection")]
	[ComImport, Guid("207bcecb-d683-4a06-a8a3-9b149b9f73a4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11FunctionReflection
	{
		/// <summary>Fills the function descriptor structure for the function.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_FUNCTION_DESC*</c></para>
		/// <para>A pointer to a D3D11_FUNCTION_DESC structure that receives a description of the function.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionreflection-getdesc HRESULT GetDesc(
		// [out] D3D11_FUNCTION_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D11_FUNCTION_DESC pDesc);

		/// <summary>Gets a constant buffer by index for a function.</summary>
		/// <param name="BufferIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionConstantBuffer*</c></para>
		/// <para>A pointer to a ID3D11ShaderReflectionConstantBuffer interface that represents the constant buffer.</para>
		/// </returns>
		/// <remarks>
		/// A constant buffer supplies either scalar constants or texture constants to a shader. A shader can use one or more constant
		/// buffers. For best performance, separate constants into buffers based on the frequency they are updated.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionreflection-getconstantbufferbyindex
		// ID3D11ShaderReflectionConstantBuffer * GetConstantBufferByIndex( [in] UINT BufferIndex );
		[PreserveSig]
		ID3D11ShaderReflectionConstantBuffer GetConstantBufferByIndex(uint BufferIndex);

		/// <summary>Gets a constant buffer by name for a function.</summary>
		/// <param name="Name">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The constant-buffer name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionConstantBuffer*</c></para>
		/// <para>A pointer to a ID3D11ShaderReflectionConstantBuffer interface that represents the constant buffer.</para>
		/// </returns>
		/// <remarks>
		/// A constant buffer supplies either scalar constants or texture constants to a shader. A shader can use one or more constant
		/// buffers. For best performance, separate constants into buffers based on the frequency they are updated.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionreflection-getconstantbufferbyname
		// ID3D11ShaderReflectionConstantBuffer * GetConstantBufferByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D11ShaderReflectionConstantBuffer GetConstantBufferByName([MarshalAs(UnmanagedType.LPStr)] string Name);

		/// <summary>Gets a description of how a resource is bound to a function.</summary>
		/// <param name="ResourceIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A zero-based resource index.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SHADER_INPUT_BIND_DESC*</c></para>
		/// <para>A pointer to a D3D11_SHADER_INPUT_BIND_DESC structure that describes input binding of the resource.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// A shader consists of executable code (the compiled HLSL functions) and a set of resources that supply the shader with input
		/// data. <c>GetResourceBindingDesc</c> gets info about how one resource in the set is bound as an input to the shader. The
		/// <c>ResourceIndex</c> parameter specifies the index for the resource.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionreflection-getresourcebindingdesc
		// HRESULT GetResourceBindingDesc( [in] UINT ResourceIndex, [out] D3D11_SHADER_INPUT_BIND_DESC *pDesc );
		[PreserveSig]
		HRESULT GetResourceBindingDesc(uint ResourceIndex, out D3D11_SHADER_INPUT_BIND_DESC pDesc);

		/// <summary>Gets a variable by name.</summary>
		/// <param name="Name">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>A pointer to a string containing the variable name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionVariable*</c></para>
		/// <para>Returns a ID3D11ShaderReflectionVariable Interface interface.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionreflection-getvariablebyname
		// ID3D11ShaderReflectionVariable * GetVariableByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D11ShaderReflectionVariable GetVariableByName([MarshalAs(UnmanagedType.LPStr)] string Name);

		/// <summary>Gets a description of how a resource is bound to a function.</summary>
		/// <param name="Name">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The constant-buffer name of the resource.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SHADER_INPUT_BIND_DESC*</c></para>
		/// <para>A pointer to a D3D11_SHADER_INPUT_BIND_DESC structure that describes input binding of the resource.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// A shader consists of executable code (the compiled HLSL functions) and a set of resources that supply the shader with input
		/// data. <c>GetResourceBindingDescByName</c> gets info about how one resource in the set is bound as an input to the shader. The
		/// <c>Name</c> parameter specifies the name of the resource.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionreflection-getresourcebindingdescbyname
		// HRESULT GetResourceBindingDescByName( [in] LPCSTR Name, [out] D3D11_SHADER_INPUT_BIND_DESC *pDesc );
		[PreserveSig]
		HRESULT GetResourceBindingDescByName([MarshalAs(UnmanagedType.LPStr)] string Name, out D3D11_SHADER_INPUT_BIND_DESC pDesc);

		/// <summary>Gets the function parameter reflector.</summary>
		/// <param name="ParameterIndex">
		/// <para>Type: <c>INT</c></para>
		/// <para>The zero-based index of the function parameter reflector to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11FunctionParameterReflection*</c></para>
		/// <para>A pointer to a ID3D11FunctionParameterReflection interface that represents the function parameter reflector.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionreflection-getfunctionparameter
		// ID3D11FunctionParameterReflection * GetFunctionParameter( [in] INT ParameterIndex );
		[PreserveSig]
		ID3D11FunctionParameterReflection GetFunctionParameter(int ParameterIndex);
	}

	/// <summary>
	/// <para>A library-reflection interface accesses library info.</para>
	/// <note>This interface is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.</note>
	/// </summary>
	/// <remarks>
	/// <para>To get a library-reflection interface, call D3DReflectLibrary.</para>
	/// <note><c>ID3D11LibraryReflection</c> requires the D3dcompiler_47.dll or a later version of the DLL.</note>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11libraryreflection
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11LibraryReflection")]
	[ComImport, Guid("54384f1b-5b3e-4bb7-ae01-60ba3097cbb6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11LibraryReflection
	{
		/// <summary>Fills the library descriptor structure for the library reflection.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_LIBRARY_DESC*</c></para>
		/// <para>A pointer to a D3D11_LIBRARY_DESC structure that receives a description of the library reflection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11libraryreflection-getdesc HRESULT GetDesc(
		// [out] D3D11_LIBRARY_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D11_LIBRARY_DESC pDesc);

		/// <summary>Gets the function reflector.</summary>
		/// <param name="FunctionIndex">
		/// <para>Type: <c>INT</c></para>
		/// <para>The zero-based index of the function reflector to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11FunctionReflection*</c></para>
		/// <para>A pointer to a ID3D11FunctionReflection interface that represents the function reflector.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11libraryreflection-getfunctionbyindex
		// ID3D11FunctionReflection * GetFunctionByIndex( [in] INT FunctionIndex );
		[PreserveSig]
		ID3D11FunctionReflection GetFunctionByIndex(int FunctionIndex);
	}

	/// <summary>
	/// <para>A linker interface is used to link a shader module.</para>
	/// <note>This interface is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.</note>
	/// </summary>
	/// <remarks>
	/// <para>To get a linker interface, call D3DCreateLinker.</para>
	/// <note><c>ID3D11Linker</c> requires the D3dcompiler_47.dll or a later version of the DLL.</note>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11linker
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11Linker")]
	[ComImport, Guid("59a6cd0e-e10d-4c1f-88c0-63aba1daf30e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Linker
	{
		/// <summary>Links the shader and produces a shader blob that the Direct3D runtime can use.</summary>
		/// <param name="pEntry">
		/// <para>Type: <c>ID3D11ModuleInstance*</c></para>
		/// <para>A pointer to the ID3D11ModuleInstance interface for the shader module instance to link from.</para>
		/// </param>
		/// <param name="pEntryName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the shader module instance to link from.</para>
		/// </param>
		/// <param name="pTargetName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name for the shader blob that is produced.</para>
		/// </param>
		/// <param name="uFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Reserved.</para>
		/// </param>
		/// <param name="ppShaderBlob">
		/// <para>Type: <c>ID3DBlob**</c></para>
		/// <para>
		/// A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the compiled shader code.
		/// </para>
		/// </param>
		/// <param name="ppErrorBuffer">
		/// <para>Type: <c>ID3DBlob**</c></para>
		/// <para>A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error messages.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11linker-link HRESULT Link( [in]
		// ID3D11ModuleInstance *pEntry, [in] LPCSTR pEntryName, [in] LPCSTR pTargetName, [in] UINT uFlags, [out] ID3DBlob **ppShaderBlob,
		// [out, optional] ID3DBlob **ppErrorBuffer );
		[PreserveSig]
		HRESULT Link([In] ID3D11ModuleInstance pEntry, [MarshalAs(UnmanagedType.LPStr)] string pEntryName, [MarshalAs(UnmanagedType.LPStr)] string pTargetName,
			[Optional] uint uFlags, out ID3D10Blob ppShaderBlob, [Out, Optional] IntPtr ppErrorBuffer);

		/// <summary>Adds an instance of a library module to be used for linking.</summary>
		/// <param name="pLibraryMI">
		/// <para>Type: <c>ID3D11ModuleInstance*</c></para>
		/// <para>A pointer to the ID3D11ModuleInstance interface for the library module instance.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11linker-uselibrary HRESULT UseLibrary( [in]
		// ID3D11ModuleInstance *pLibraryMI );
		[PreserveSig]
		HRESULT UseLibrary([In] ID3D11ModuleInstance pLibraryMI);

		/// <summary>Adds a clip plane with the plane coefficients taken from a cbuffer entry for 10Level9 shaders.</summary>
		/// <param name="uCBufferSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The cbuffer slot number.</para>
		/// </param>
		/// <param name="uCBufferEntry">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The cbuffer entry number.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11linker-addclipplanefromcbuffer HRESULT
		// AddClipPlaneFromCBuffer( [in] UINT uCBufferSlot, [in] UINT uCBufferEntry );
		[PreserveSig]
		HRESULT AddClipPlaneFromCBuffer(uint uCBufferSlot, uint uCBufferEntry);
	}

	/// <summary>
	/// <para>A linking-node interface is used for shader linking.</para>
	/// <note>This interface is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.</note>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To get a linking-node interface, call ID3D11FunctionLinkingGraph::SetInputSignature, ID3D11FunctionLinkingGraph::SetOutputSignature,
	/// or ID3D11FunctionLinkingGraph::CallFunction.
	/// </para>
	/// <note><c>ID3D11LinkingNode</c> requires the D3dcompiler_47.dll or a later version of the DLL.</note>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11linkingnode
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11LinkingNode")]
	[ComImport, Guid("d80dd70c-8d2f-4751-94a1-03c79b3556db"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11LinkingNode
	{
	}

	/// <summary>
	/// <para>A module interface creates an instance of a module that is used for resource rebinding.</para>
	/// <para>
	/// <c>Note</c>  This interface is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>To get a module interface, call D3DLoadModule.</para>
	/// <para><c>Note</c>   <c>ID3D11Module</c> requires the D3dcompiler_47.dll or a later version of the DLL.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11module
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11Module")]
	[ComImport, Guid("cac701ee-80fc-4122-8242-10b39c8cec34"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Module
	{
		/// <summary>Initializes an instance of a shader module that is used for resource rebinding.</summary>
		/// <param name="pNamespace">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of a shader module to initialize. This can be <c>NULL</c> if you don't want to specify a name for the module.</para>
		/// </param>
		/// <param name="ppModuleInstance">
		/// <para>Type: <c>ID3D11ModuleInstance**</c></para>
		/// <para>The address of a pointer to an ID3D11ModuleInstance interface to initialize.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11module-createinstance HRESULT
		// CreateInstance( [in, optional] LPCSTR pNamespace, [out] ID3D11ModuleInstance **ppModuleInstance );
		[PreserveSig]
		HRESULT CreateInstance([MarshalAs(UnmanagedType.LPStr)] string? pNamespace, out ID3D11ModuleInstance ppModuleInstance);
	}

	/// <summary>
	/// <para>A module-instance interface is used for resource rebinding.</para>
	/// <para>
	/// <c>Note</c>  This interface is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>To get a module-instance interface, call ID3D11Module::CreateInstance or ID3D11FunctionLinkingGraph::CreateModuleInstance.</para>
	/// <para><c>Note</c>   <c>ID3D11ModuleInstance</c> requires the D3dcompiler_47.dll or a later version of the DLL.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11moduleinstance
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11ModuleInstance")]
	[ComImport, Guid("469e07f7-045a-48d5-aa12-68a478cdf75d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ModuleInstance
	{
		/// <summary>Rebinds a constant buffer from a source slot to a destination slot.</summary>
		/// <param name="uSrcSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The source slot number for rebinding.</para>
		/// </param>
		/// <param name="uDstSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The destination slot number for rebinding.</para>
		/// </param>
		/// <param name="cbDstOffset">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The offset in bytes of the destination slot for rebinding. The offset must have 16-byte alignment.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> for a valid rebinding</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> for rebinding a nonexistent slot; that is, for which the shader reflection doesn’t have any data
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> for an invalid rebinding, for example, the rebinding is out-of-bounds</description>
		/// </item>
		/// <item>
		/// <description>Possibly one of the other Direct3D 11 Return Codes</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11moduleinstance-bindconstantbuffer HRESULT
		// BindConstantBuffer( [in] UINT uSrcSlot, [in] UINT uDstSlot, [in] UINT cbDstOffset );
		[PreserveSig]
		HRESULT BindConstantBuffer(uint uSrcSlot, uint uDstSlot, uint cbDstOffset);

		/// <summary>Rebinds a constant buffer by name to a destination slot.</summary>
		/// <param name="pName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the constant buffer for rebinding.</para>
		/// </param>
		/// <param name="uDstSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The destination slot number for rebinding.</para>
		/// </param>
		/// <param name="cbDstOffset">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The offset in bytes of the destination slot for rebinding. The offset must have 16-byte alignment.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> for a valid rebinding</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> for rebinding a nonexistent slot; that is, for which the shader reflection doesn’t have any data
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> for an invalid rebinding, for example, the rebinding is out-of-bounds</description>
		/// </item>
		/// <item>
		/// <description>Possibly one of the other Direct3D 11 Return Codes</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11moduleinstance-bindconstantbufferbyname
		// HRESULT BindConstantBufferByName( [in] LPCSTR pName, [in] UINT uDstSlot, [in] UINT cbDstOffset );
		[PreserveSig]
		HRESULT BindConstantBufferByName([MarshalAs(UnmanagedType.LPStr)] string pName, uint uDstSlot, uint cbDstOffset);

		/// <summary>Rebinds a texture or buffer from source slot to destination slot.</summary>
		/// <param name="uSrcSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first source slot number for rebinding.</para>
		/// </param>
		/// <param name="uDstSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first destination slot number for rebinding.</para>
		/// </param>
		/// <param name="uCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of slots for rebinding.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> for a valid rebinding</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> for rebinding a nonexistent slot; that is, for which the shader reflection doesn’t have any data
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> for an invalid rebinding, for example, the rebinding is out-of-bounds</description>
		/// </item>
		/// <item>
		/// <description>Possibly one of the other Direct3D 11 Return Codes</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11moduleinstance-bindresource HRESULT
		// BindResource( [in] UINT uSrcSlot, [in] UINT uDstSlot, [in] UINT uCount );
		[PreserveSig]
		HRESULT BindResource(uint uSrcSlot, uint uDstSlot, uint uCount);

		/// <summary>Rebinds a texture or buffer by name to destination slots.</summary>
		/// <param name="pName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the texture or buffer for rebinding.</para>
		/// </param>
		/// <param name="uDstSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first destination slot number for rebinding.</para>
		/// </param>
		/// <param name="uCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of slots for rebinding.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> for a valid rebinding</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> for rebinding a nonexistent slot; that is, for which the shader reflection doesn’t have any data
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> for an invalid rebinding, for example, the rebinding is out-of-bounds</description>
		/// </item>
		/// <item>
		/// <description>Possibly one of the other Direct3D 11 Return Codes</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11moduleinstance-bindresourcebyname HRESULT
		// BindResourceByName( [in] LPCSTR pName, [in] UINT uDstSlot, [in] UINT uCount );
		[PreserveSig]
		HRESULT BindResourceByName([MarshalAs(UnmanagedType.LPStr)] string pName, uint uDstSlot, uint uCount);

		/// <summary>Rebinds a sampler from source slot to destination slot.</summary>
		/// <param name="uSrcSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first source slot number for rebinding.</para>
		/// </param>
		/// <param name="uDstSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first destination slot number for rebinding.</para>
		/// </param>
		/// <param name="uCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of slots for rebinding.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> for a valid rebinding</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> for rebinding a nonexistent slot; that is, for which the shader reflection doesn’t have any data
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> for an invalid rebinding, for example, the rebinding is out-of-bounds</description>
		/// </item>
		/// <item>
		/// <description>Possibly one of the other Direct3D 11 Return Codes</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11moduleinstance-bindsampler HRESULT
		// BindSampler( [in] UINT uSrcSlot, [in] UINT uDstSlot, [in] UINT uCount );
		[PreserveSig]
		HRESULT BindSampler(uint uSrcSlot, uint uDstSlot, uint uCount);

		/// <summary>Rebinds a sampler by name to destination slots.</summary>
		/// <param name="pName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the sampler for rebinding.</para>
		/// </param>
		/// <param name="uDstSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first destination slot number for rebinding.</para>
		/// </param>
		/// <param name="uCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of slots for rebinding.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> for a valid rebinding</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> for rebinding a nonexistent slot; that is, for which the shader reflection doesn’t have any data
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> for an invalid rebinding, for example, the rebinding is out-of-bounds</description>
		/// </item>
		/// <item>
		/// <description>Possibly one of the other Direct3D 11 Return Codes</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11moduleinstance-bindsamplerbyname HRESULT
		// BindSamplerByName( [in] LPCSTR pName, [in] UINT uDstSlot, [in] UINT uCount );
		[PreserveSig]
		HRESULT BindSamplerByName([MarshalAs(UnmanagedType.LPStr)] string pName, uint uDstSlot, uint uCount);

		/// <summary>Rebinds an unordered access view (UAV) from source slot to destination slot.</summary>
		/// <param name="uSrcSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first source slot number for rebinding.</para>
		/// </param>
		/// <param name="uDstSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first destination slot number for rebinding.</para>
		/// </param>
		/// <param name="uCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of slots for rebinding.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> for a valid rebinding</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> for rebinding a nonexistent slot; that is, for which the shader reflection doesn’t have any data
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> for an invalid rebinding, for example, the rebinding is out-of-bounds</description>
		/// </item>
		/// <item>
		/// <description>Possibly one of the other Direct3D 11 Return Codes</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11moduleinstance-bindunorderedaccessview
		// HRESULT BindUnorderedAccessView( [in] UINT uSrcSlot, [in] UINT uDstSlot, [in] UINT uCount );
		[PreserveSig]
		HRESULT BindUnorderedAccessView(uint uSrcSlot, uint uDstSlot, uint uCount);

		/// <summary>Rebinds an unordered access view (UAV) by name to destination slots.</summary>
		/// <param name="pName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the UAV for rebinding.</para>
		/// </param>
		/// <param name="uDstSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first destination slot number for rebinding.</para>
		/// </param>
		/// <param name="uCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of slots for rebinding.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> for a valid rebinding</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> for rebinding a nonexistent slot; that is, for which the shader reflection doesn’t have any data
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> for an invalid rebinding, for example, the rebinding is out-of-bounds</description>
		/// </item>
		/// <item>
		/// <description>Possibly one of the other Direct3D 11 Return Codes</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11moduleinstance-bindunorderedaccessviewbyname
		// HRESULT BindUnorderedAccessViewByName( [in] LPCSTR pName, [in] UINT uDstSlot, [in] UINT uCount );
		[PreserveSig]
		HRESULT BindUnorderedAccessViewByName([MarshalAs(UnmanagedType.LPStr)] string pName, uint uDstSlot, uint uCount);

		/// <summary>Rebinds a resource as an unordered access view (UAV) from source slot to destination slot.</summary>
		/// <param name="uSrcSrvSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first source slot number for rebinding.</para>
		/// </param>
		/// <param name="uDstUavSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first destination slot number for rebinding.</para>
		/// </param>
		/// <param name="uCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of slots for rebinding.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> for a valid rebinding</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> for rebinding a nonexistent slot; that is, for which the shader reflection doesn’t have any data
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> for an invalid rebinding, for example, the rebinding is out-of-bounds</description>
		/// </item>
		/// <item>
		/// <description>Possibly one of the other Direct3D 11 Return Codes</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11moduleinstance-bindresourceasunorderedaccessview
		// HRESULT BindResourceAsUnorderedAccessView( [in] UINT uSrcSrvSlot, [in] UINT uDstUavSlot, [in] UINT uCount );
		[PreserveSig]
		HRESULT BindResourceAsUnorderedAccessView(uint uSrcSrvSlot, uint uDstUavSlot, uint uCount);

		/// <summary>Rebinds a resource by name as an unordered access view (UAV) to destination slots.</summary>
		/// <param name="pSrvName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the resource for rebinding.</para>
		/// </param>
		/// <param name="uDstUavSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first destination slot number for rebinding.</para>
		/// </param>
		/// <param name="uCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of slots for rebinding.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>S_OK</c> for a valid rebinding</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>S_FALSE</c> for rebinding a nonexistent slot; that is, for which the shader reflection doesn’t have any data
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c> for an invalid rebinding, for example, the rebinding is out-of-bounds</description>
		/// </item>
		/// <item>
		/// <description>Possibly one of the other Direct3D 11 Return Codes</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11moduleinstance-bindresourceasunorderedaccessviewbyname
		// HRESULT BindResourceAsUnorderedAccessViewByName( [in] LPCSTR pSrvName, [in] UINT uDstUavSlot, [in] UINT uCount );
		[PreserveSig]
		HRESULT BindResourceAsUnorderedAccessViewByName([MarshalAs(UnmanagedType.LPStr)] string pSrvName, uint uDstUavSlot, uint uCount);
	}

	/// <summary>A shader-reflection interface accesses shader information.</summary>
	/// <remarks>
	/// An <c>ID3D11ShaderReflection</c> interface can be retrieved for a shader by using D3DReflect. The following code illustrates
	/// retrieving a <c>ID3D11ShaderReflection</c> from a shader.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11shaderreflection
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11ShaderReflection")]
	[ComImport, Guid("8d536ca1-0cca-4956-a837-786963755584"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ShaderReflection
	{
		/// <summary>Get a shader description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SHADER_DESC*</c></para>
		/// <para>A pointer to a shader description. See D3D11_SHADER_DESC.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getdesc HRESULT GetDesc(
		// [out] D3D11_SHADER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D11_SHADER_DESC pDesc);

		/// <summary>Get a constant buffer by index.</summary>
		/// <param name="Index">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionConstantBuffer*</c></para>
		/// <para>A pointer to a constant buffer (see ID3D11ShaderReflectionConstantBuffer Interface).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A constant buffer supplies either scalar constants or texture constants to a shader. A shader can use one or more constant
		/// buffers. For best performance, separate constants into buffers based on the frequency they are updated.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getconstantbufferbyindex
		// ID3D11ShaderReflectionConstantBuffer * GetConstantBufferByIndex( [in] UINT Index );
		[PreserveSig]
		ID3D11ShaderReflectionConstantBuffer GetConstantBufferByIndex(uint Index);

		/// <summary>Get a constant buffer by name.</summary>
		/// <param name="Name">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The constant-buffer name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionConstantBuffer*</c></para>
		/// <para>A pointer to a constant buffer (see ID3D11ShaderReflectionConstantBuffer Interface).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A constant buffer supplies either scalar constants or texture constants to a shader. A shader can use one or more constant
		/// buffers. For best performance, separate constants into buffers based on the frequency they are updated.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getconstantbufferbyname
		// ID3D11ShaderReflectionConstantBuffer * GetConstantBufferByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D11ShaderReflectionConstantBuffer GetConstantBufferByName([MarshalAs(UnmanagedType.LPStr)] string Name);

		/// <summary>Get a description of how a resource is bound to a shader.</summary>
		/// <param name="ResourceIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A zero-based resource index.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SHADER_INPUT_BIND_DESC*</c></para>
		/// <para>A pointer to an input-binding description. See D3D11_SHADER_INPUT_BIND_DESC.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A shader consists of executable code (the compiled HLSL functions) and a set of resources that supply the shader with input
		/// data. <c>GetResourceBindingDesc</c> gets information about how one resource in the set is bound as an input to the shader. The
		/// <c>ResourceIndex</c> parameter specifies the index for the resource.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getresourcebindingdesc
		// HRESULT GetResourceBindingDesc( [in] UINT ResourceIndex, [out] D3D11_SHADER_INPUT_BIND_DESC *pDesc );
		[PreserveSig]
		HRESULT GetResourceBindingDesc(uint ResourceIndex, out D3D11_SHADER_INPUT_BIND_DESC pDesc);

		/// <summary>Get an input-parameter description for a shader.</summary>
		/// <param name="ParameterIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A zero-based parameter index.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SIGNATURE_PARAMETER_DESC*</c></para>
		/// <para>A pointer to a shader-input-signature description. See D3D11_SIGNATURE_PARAMETER_DESC.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An input-parameter description is also called a shader signature. The shader signature contains information about the input
		/// parameters such as the order or parameters, their data type, and a parameter semantic.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getinputparameterdesc
		// HRESULT GetInputParameterDesc( [in] UINT ParameterIndex, [out] D3D11_SIGNATURE_PARAMETER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetInputParameterDesc(uint ParameterIndex, out D3D11_SIGNATURE_PARAMETER_DESC pDesc);

		/// <summary>Get an output-parameter description for a shader.</summary>
		/// <param name="ParameterIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A zero-based parameter index.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SIGNATURE_PARAMETER_DESC*</c></para>
		/// <para>A pointer to a shader-output-parameter description. See D3D11_SIGNATURE_PARAMETER_DESC.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An output-parameter description is also called a shader signature. The shader signature contains information about the output
		/// parameters such as the order or parameters, their data type, and a parameter semantic.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getoutputparameterdesc
		// HRESULT GetOutputParameterDesc( [in] UINT ParameterIndex, [out] D3D11_SIGNATURE_PARAMETER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetOutputParameterDesc(uint ParameterIndex, out D3D11_SIGNATURE_PARAMETER_DESC pDesc);

		/// <summary>Get a patch-constant parameter description for a shader.</summary>
		/// <param name="ParameterIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A zero-based parameter index.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SIGNATURE_PARAMETER_DESC*</c></para>
		/// <para>A pointer to a shader-input-signature description. See D3D11_SIGNATURE_PARAMETER_DESC.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getpatchconstantparameterdesc
		// HRESULT GetPatchConstantParameterDesc( [in] UINT ParameterIndex, [out] D3D11_SIGNATURE_PARAMETER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetPatchConstantParameterDesc(uint ParameterIndex, out D3D11_SIGNATURE_PARAMETER_DESC pDesc);

		/// <summary>Gets a variable by name.</summary>
		/// <param name="Name">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>A pointer to a string containing the variable name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionVariable*</c></para>
		/// <para>Returns a ID3D11ShaderReflectionVariable Interface interface.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getvariablebyname
		// ID3D11ShaderReflectionVariable * GetVariableByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D11ShaderReflectionVariable GetVariableByName([MarshalAs(UnmanagedType.LPStr)] string Name);

		/// <summary>Get a description of how a resource is bound to a shader.</summary>
		/// <param name="Name">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The constant-buffer name of the resource.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SHADER_INPUT_BIND_DESC*</c></para>
		/// <para>A pointer to an input-binding description. See D3D11_SHADER_INPUT_BIND_DESC.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A shader consists of executable code (the compiled HLSL functions) and a set of resources that supply the shader with input
		/// data. <c>GetResourceBindingDescByName</c> gets information about how one resource in the set is bound as an input to the shader.
		/// The <c>Name</c> parameter specifies the name of the resource.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getresourcebindingdescbyname
		// HRESULT GetResourceBindingDescByName( [in] LPCSTR Name, [out] D3D11_SHADER_INPUT_BIND_DESC *pDesc );
		[PreserveSig]
		HRESULT GetResourceBindingDescByName([MarshalAs(UnmanagedType.LPStr)] string Name, out D3D11_SHADER_INPUT_BIND_DESC pDesc);

		/// <summary>Gets the number of Mov instructions.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Returns the number of Mov instructions.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getmovinstructioncount UINT GetMovInstructionCount();
		[PreserveSig]
		uint GetMovInstructionCount();

		/// <summary>Gets the number of Movc instructions.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Returns the number of Movc instructions.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getmovcinstructioncount
		// UINT GetMovcInstructionCount();
		[PreserveSig]
		uint GetMovcInstructionCount();

		/// <summary>Gets the number of conversion instructions.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Returns the number of conversion instructions.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getconversioninstructioncount
		// UINT GetConversionInstructionCount();
		[PreserveSig]
		uint GetConversionInstructionCount();

		/// <summary>Gets the number of bitwise instructions.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of bitwise instructions.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getbitwiseinstructioncount
		// UINT GetBitwiseInstructionCount();
		[PreserveSig]
		uint GetBitwiseInstructionCount();

		/// <summary>Gets the geometry-shader input-primitive description.</summary>
		/// <returns>
		/// <para>Type: <c>D3D_PRIMITIVE</c></para>
		/// <para>The input-primitive description. See D3D_PRIMITIVE_TOPOLOGY, D3D11_PRIMITIVE_TOPOLOGY, or D3D10_PRIMITIVE_TOPOLOGY.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getgsinputprimitive
		// D3D_PRIMITIVE GetGSInputPrimitive();
		[PreserveSig]
		D3D_PRIMITIVE GetGSInputPrimitive();

		/// <summary>Indicates whether a shader is a sample frequency shader.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns true if the shader is a sample frequency shader; otherwise returns false.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-issamplefrequencyshader
		// BOOL IsSampleFrequencyShader();
		[PreserveSig]
		bool IsSampleFrequencyShader();

		/// <summary>Gets the number of interface slots in a shader.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of interface slots in the shader.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getnuminterfaceslots UINT GetNumInterfaceSlots();
		[PreserveSig]
		uint GetNumInterfaceSlots();

		/// <summary>Gets the minimum feature level.</summary>
		/// <param name="pLevel">
		/// <para>Type: [out] <c>D3D_FEATURE_LEVEL*</c></para>
		/// <para>A pointer to one of the enumerated values in D3D_FEATURE_LEVEL, which represents the minimum feature level.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getminfeaturelevel HRESULT
		// GetMinFeatureLevel( D3D_FEATURE_LEVEL *pLevel );
		[PreserveSig]
		HRESULT GetMinFeatureLevel(out D3D_FEATURE_LEVEL pLevel);

		/// <summary>Retrieves the sizes, in units of threads, of the X, Y, and Z dimensions of the shader's thread-group grid.</summary>
		/// <param name="pSizeX">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to the size, in threads, of the x-dimension of the thread-group grid. The maximum size is 1024.</para>
		/// </param>
		/// <param name="pSizeY">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to the size, in threads, of the y-dimension of the thread-group grid. The maximum size is 1024.</para>
		/// </param>
		/// <param name="pSizeZ">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to the size, in threads, of the z-dimension of the thread-group grid. The maximum size is 64.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Returns the total size, in threads, of the thread-group grid by calculating the product of the size of each dimension.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// <para>
		/// When a compute shader is written it defines the actions of a single thread group only. If multiple thread groups are required,
		/// it is the role of the ID3D11DeviceContext::Dispatch call to issue multiple thread groups.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getthreadgroupsize UINT
		// GetThreadGroupSize( [out, optional] UINT *pSizeX, [out, optional] UINT *pSizeY, [out, optional] UINT *pSizeZ );
		[PreserveSig]
		uint GetThreadGroupSize(out uint pSizeX, out uint pSizeY, out uint pSizeZ);

		/// <summary>Gets a group of flags that indicates the requirements of a shader.</summary>
		/// <returns>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>
		/// A value that contains a combination of one or more shader requirements flags; each flag specifies a requirement of the shader. A
		/// default value of 0 means there are no requirements.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Shader requirement flag</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>D3D_SHADER_REQUIRES_DOUBLES</c></description>
		/// <description>Shader requires that the graphics driver and hardware support double data type. For more info, see D3D11_FEATURE_DATA_DOUBLES.</description>
		/// </item>
		/// <item>
		/// <description><c>D3D_SHADER_REQUIRES_EARLY_DEPTH_STENCIL</c></description>
		/// <description>Shader requires an early depth stencil.</description>
		/// </item>
		/// <item>
		/// <description><c>D3D_SHADER_REQUIRES_UAVS_AT_EVERY_STAGE</c></description>
		/// <description>Shader requires unordered access views (UAVs) at every pipeline stage.</description>
		/// </item>
		/// <item>
		/// <description><c>D3D_SHADER_REQUIRES_64_UAVS</c></description>
		/// <description>Shader requires 64 UAVs.</description>
		/// </item>
		/// <item>
		/// <description><c>D3D_SHADER_REQUIRES_MINIMUM_PRECISION</c></description>
		/// <description>
		/// Shader requires the graphics driver and hardware to support minimum precision. For more info, see Using HLSL minimum precision.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>D3D_SHADER_REQUIRES_11_1_DOUBLE_EXTENSIONS</c></description>
		/// <description>
		/// Shader requires that the graphics driver and hardware support extended doubles instructions. For more info, see the
		/// <c>ExtendedDoublesShaderInstructions</c> member of D3D11_FEATURE_DATAD3D11_OPTIONS.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>D3D_SHADER_REQUIRES_11_1_SHADER_EXTENSIONS</c></description>
		/// <description>
		/// Shader requires that the graphics driver and hardware support the msad4 intrinsic function in shaders. For more info, see the
		/// <c>SAD4ShaderInstructions</c> member of D3D11_FEATURE_DATAD3D11_OPTIONS.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>D3D_SHADER_REQUIRES_LEVEL_9_COMPARISON_FILTERING</c></description>
		/// <description>
		/// Shader requires that the graphics driver and hardware support Direct3D 9 shadow support. For more info, see D3D11_FEATURE_DATA_D3D9_SHADOW_SUPPORT.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>D3D_SHADER_REQUIRES_TILED_RESOURCES</c></description>
		/// <description>Shader requires that the graphics driver and hardware support tiled resources. For more info, see GetResourceTiling.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Here is how the D3D11Shader.h header defines the shader requirements flags:</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflection-getrequiresflags UINT64 GetRequiresFlags();
		[PreserveSig]
		D3D_SHADER_REQUIRES_FLAGS GetRequiresFlags();
	}

	/// <summary>This shader-reflection interface provides access to a constant buffer.</summary>
	/// <remarks>
	/// To create a constant-buffer interface, call ID3D11ShaderReflection::GetConstantBufferByIndex or
	/// ID3D11ShaderReflection::GetConstantBufferByName. This isn't a COM interface, so you don't need to worry about reference counts or
	/// releasing the interface when you're done with it.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11shaderreflectionconstantbuffer
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11ShaderReflectionConstantBuffer")]
	[ComImport, Guid("eb62d63d-93dd-4318-8ae8-c6f83ad371b8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ShaderReflectionConstantBuffer
	{
		/// <summary>Get a constant-buffer description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SHADER_BUFFER_DESC*</c></para>
		/// <para>A pointer to a D3D11_SHADER_BUFFER_DESC, which represents a shader-buffer description.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectionconstantbuffer-getdesc
		// HRESULT GetDesc( D3D11_SHADER_BUFFER_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D11_SHADER_BUFFER_DESC pDesc);

		/// <summary>Get a shader-reflection variable by index.</summary>
		/// <param name="Index">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionVariable*</c></para>
		/// <para>A pointer to a shader-reflection variable interface (see ID3D11ShaderReflectionVariable Interface).</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectionconstantbuffer-getvariablebyindex
		// ID3D11ShaderReflectionVariable * GetVariableByIndex( [in] UINT Index );
		[PreserveSig]
		ID3D11ShaderReflectionVariable GetVariableByIndex(uint Index);

		/// <summary>Get a shader-reflection variable by name.</summary>
		/// <param name="Name">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>Variable name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionVariable*</c></para>
		/// <para>
		/// Returns a sentinel object (end of list marker). To determine if GetVariableByName successfully completed, call
		/// ID3D11ShaderReflectionVariable::GetDesc and check the returned <c>HRESULT</c>; any return value other than success means that
		/// GetVariableByName failed.
		/// </para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectionconstantbuffer-getvariablebyname
		// ID3D11ShaderReflectionVariable * GetVariableByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D11ShaderReflectionVariable GetVariableByName([MarshalAs(UnmanagedType.LPStr)] string Name);
	}

	/// <summary>This shader-reflection interface provides access to variable type.</summary>
	/// <remarks>
	/// The get a shader-reflection-type interface, call ID3D11ShaderReflectionVariable::GetType. This isn't a COM interface, so you don't
	/// need to worry about reference counts or releasing the interface when you're done with it.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11shaderreflectiontype
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11ShaderReflectionType")]
	[ComImport, Guid("6e6ffa6a-9bae-4613-a51e-91652d508c21"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ShaderReflectionType
	{
		/// <summary>Get the description of a shader-reflection-variable type.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SHADER_TYPE_DESC*</c></para>
		/// <para>A pointer to a shader-type description (see D3D11_SHADER_TYPE_DESC).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-getdesc HRESULT
		// GetDesc( [out] D3D11_SHADER_TYPE_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D11_SHADER_TYPE_DESC pDesc);

		/// <summary>Get a shader-reflection-variable type by index.</summary>
		/// <param name="Index">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionType*</c></para>
		/// <para>A pointer to a ID3D11ShaderReflectionType Interface.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-getmembertypebyindex
		// ID3D11ShaderReflectionType * GetMemberTypeByIndex( [in] UINT Index );
		[PreserveSig]
		ID3D11ShaderReflectionType GetMemberTypeByIndex(uint Index);

		/// <summary>Get a shader-reflection-variable type by name.</summary>
		/// <param name="Name">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>Member name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionType*</c></para>
		/// <para>A pointer to a ID3D11ShaderReflectionType Interface.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-getmembertypebyname
		// ID3D11ShaderReflectionType * GetMemberTypeByName( [in] LPCSTR Name );
		[PreserveSig]
		ID3D11ShaderReflectionType GetMemberTypeByName([MarshalAs(UnmanagedType.LPStr)] string Name);

		/// <summary>Get a shader-reflection-variable type.</summary>
		/// <param name="Index">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The variable type.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-getmembertypename
		// LPCSTR GetMemberTypeName( [in] UINT Index );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string GetMemberTypeName(uint Index);

		/// <summary>Indicates whether two ID3D11ShaderReflectionType Interface pointers have the same underlying type.</summary>
		/// <param name="pType">
		/// <para>Type: <c>ID3D11ShaderReflectionType*</c></para>
		/// <para>A pointer to a ID3D11ShaderReflectionType Interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if the pointers have the same underlying type; otherwise returns S_FALSE.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// IsEqual indicates whether the sources of the ID3D11ShaderReflectionType Interface pointers have the same underlying type. For
		/// example, if two <c>ID3D11ShaderReflectionType Interface</c> pointers were retrieved from variables, IsEqual can be used to see
		/// if the variables have the same type.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-isequal HRESULT
		// IsEqual( [in] ID3D11ShaderReflectionType *pType );
		[PreserveSig]
		HRESULT IsEqual(ID3D11ShaderReflectionType pType);

		/// <summary>Gets the base class of a class.</summary>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionType*</c></para>
		/// <para>
		/// Returns a pointer to a ID3D11ShaderReflectionType Interface containing the base class type. Returns <c>NULL</c> if the class
		/// does not have a base class.
		/// </para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-getsubtype
		// ID3D11ShaderReflectionType * GetSubType();
		[PreserveSig]
		ID3D11ShaderReflectionType GetSubType();

		/// <summary>Gets an ID3D11ShaderReflectionType Interface interface containing the variable base class type.</summary>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionType*</c></para>
		/// <para>Returns A pointer to a ID3D11ShaderReflectionType Interface.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-getbaseclass
		// ID3D11ShaderReflectionType * GetBaseClass();
		[PreserveSig]
		ID3D11ShaderReflectionType GetBaseClass();

		/// <summary>Gets the number of interfaces.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Returns the number of interfaces.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-getnuminterfaces UINT GetNumInterfaces();
		[PreserveSig]
		uint GetNumInterfaces();

		/// <summary>Get an interface by index.</summary>
		/// <param name="uIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Zero-based index.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionType*</c></para>
		/// <para>A pointer to a ID3D11ShaderReflectionType Interface.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-getinterfacebyindex
		// ID3D11ShaderReflectionType * GetInterfaceByIndex( [in] UINT uIndex );
		[PreserveSig]
		ID3D11ShaderReflectionType GetInterfaceByIndex(uint uIndex);

		/// <summary>Indicates whether a variable is of the specified type.</summary>
		/// <param name="pType">
		/// <para>Type: <c>ID3D11ShaderReflectionType*</c></para>
		/// <para>A pointer to a ID3D11ShaderReflectionType Interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if object being queried is equal to or inherits from the type in the <c>pType</c> parameter; otherwise returns S_FALSE.
		/// </para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-isoftype HRESULT
		// IsOfType( [in] ID3D11ShaderReflectionType *pType );
		[PreserveSig]
		HRESULT IsOfType(ID3D11ShaderReflectionType pType);

		/// <summary>Indicates whether a class type implements an interface.</summary>
		/// <param name="pBase">
		/// <para>Type: <c>ID3D11ShaderReflectionType*</c></para>
		/// <para>A pointer to a ID3D11ShaderReflectionType Interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if the interface is implemented; otherwise return S_FALSE.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectiontype-implementsinterface
		// HRESULT ImplementsInterface( [in] ID3D11ShaderReflectionType *pBase );
		[PreserveSig]
		HRESULT ImplementsInterface(ID3D11ShaderReflectionType pBase);
	}

	/// <summary>This shader-reflection interface provides access to a variable.</summary>
	/// <remarks>
	/// To get a shader-reflection-variable interface, call a method like ID3D11ShaderReflection::GetVariableByName. This isn't a COM
	/// interface, so you don't need to worry about reference counts or releasing the interface when you're done with it.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nn-d3d11shader-id3d11shaderreflectionvariable
	[PInvokeData("d3d11shader.h", MSDNShortId = "NN:d3d11shader.ID3D11ShaderReflectionVariable")]
	[ComImport, Guid("51f23923-f3e5-4bd1-91cb-606177d8db4c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ShaderReflectionVariable
	{
		/// <summary>Get a shader-variable description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SHADER_VARIABLE_DESC*</c></para>
		/// <para>A pointer to a shader-variable description (see D3D11_SHADER_VARIABLE_DESC).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method can be used to determine if the ID3D11ShaderReflectionVariable Interface is valid, the method returns <c>E_FAIL</c>
		/// when the variable is not valid.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectionvariable-getdesc HRESULT
		// GetDesc( [out] D3D11_SHADER_VARIABLE_DESC *pDesc );
		[PreserveSig]
		HRESULT GetDesc(out D3D11_SHADER_VARIABLE_DESC pDesc);

		/// <summary>Get a shader-variable type.</summary>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionType*</c></para>
		/// <para>A pointer to a ID3D11ShaderReflectionType Interface.</para>
		/// </returns>
		/// <remarks>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectionvariable-gettype
		// ID3D11ShaderReflectionType * GetType();
		[PreserveSig]
		ID3D11ShaderReflectionType GetType();

		/// <summary>This method returns the buffer of the current ID3D11ShaderReflectionVariable.</summary>
		/// <returns>
		/// <para>Type: <c>ID3D11ShaderReflectionConstantBuffer*</c></para>
		/// <para>Returns a pointer to the ID3D11ShaderReflectionConstantBuffer of the present ID3D11ShaderReflectionVariable.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectionvariable-getbuffer
		// ID3D11ShaderReflectionConstantBuffer * GetBuffer();
		[PreserveSig]
		ID3D11ShaderReflectionConstantBuffer GetBuffer();

		/// <summary>Gets the corresponding interface slot for a variable that represents an interface pointer.</summary>
		/// <param name="uArrayIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Index of the array element to get the slot number for. For a non-array variable this value will be zero.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Returns the index of the interface in the interface array.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// GetInterfaceSlot gets the corresponding slot in a dynamic linkage array for an interface instance. The returned slot number is
		/// used to set an interface instance to a particular class instance. See the HLSL Interfaces and Classes overview for additional information.
		/// </para>
		/// <para>This method's interface is hosted in the out-of-box DLL D3DCompiler_xx.dll.</para>
		/// <para>Examples</para>
		/// <para>Retrieving and using an interface slot</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11shaderreflectionvariable-getinterfaceslot
		// UINT GetInterfaceSlot( [in] UINT uArrayIndex );
		[PreserveSig]
		uint GetInterfaceSlot(uint uArrayIndex);
	}

	/// <summary>Initializes a shader module from the function-linking-graph object.</summary>
	/// <param name="graph">The <see cref="ID3D11FunctionLinkingGraph"/> instance.</param>
	/// <param name="ppModuleInstance">
	/// <para>Type: <c>ID3D11ModuleInstance**</c></para>
	/// <para>The address of a pointer to an ID3D11ModuleInstance interface for the shader module to initialize.</para>
	/// </param>
	/// <param name="ppErrorBuffer">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>
	/// An optional pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error
	/// messages, or <c>NULL</c> if there are no errors.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/nf-d3d11shader-id3d11functionlinkinggraph-createmoduleinstance
	// HRESULT CreateModuleInstance( [out] ID3D11ModuleInstance **ppModuleInstance, [out, optional] ID3DBlob **ppErrorBuffer );
	public static HRESULT CreateModuleInstance(this ID3D11FunctionLinkingGraph graph, out ID3D11ModuleInstance ppModuleInstance, out ID3D10Blob? ppErrorBuffer)
	{
		unsafe
		{
			IntPtr pBlob = IntPtr.Zero;
			var hr = graph.CreateModuleInstance(out ppModuleInstance, new IntPtr(&pBlob));
			ppErrorBuffer = hr.Failed ? null : (ID3D10Blob)Marshal.GetObjectForIUnknown(pBlob);
			return hr;
		}
	}

	/// <summary>Links the shader and produces a shader blob that the Direct3D runtime can use.</summary>
	/// <param name="linker">The <see cref="ID3D11Linker"/> instance.</param>
	/// <param name="pEntry">
	/// <para>Type: <c>ID3D11ModuleInstance*</c></para>
	/// <para>A pointer to the ID3D11ModuleInstance interface for the shader module instance to link from.</para>
	/// </param>
	/// <param name="pEntryName">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>The name of the shader module instance to link from.</para>
	/// </param>
	/// <param name="pTargetName">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>The name for the shader blob that is produced.</para>
	/// </param>
	/// <param name="ppShaderBlob">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the compiled shader code.</para>
	/// </param>
	/// <param name="ppErrorBuffer">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error messages.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
	/// </returns>
	public static HRESULT Link(this ID3D11Linker linker, [In] ID3D11ModuleInstance pEntry, string pEntryName, string pTargetName,
		out ID3D10Blob ppShaderBlob, out ID3D10Blob? ppErrorBuffer)
	{
		unsafe
		{
			IntPtr pErr = IntPtr.Zero;
			var hr = linker.Link(pEntry, pEntryName, pTargetName, 0, out ppShaderBlob, new IntPtr(&pErr));
			ppErrorBuffer = hr.Failed ? null : (ID3D10Blob)Marshal.GetObjectForIUnknown(pErr);
			return hr;
		}
	}

	/// <summary>Describes a function.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/ns-d3d11shader-d3d11_function_desc typedef struct D3D11_FUNCTION_DESC
	// { UINT Version; LPCSTR Creator; UINT Flags; UINT ConstantBuffers; UINT BoundResources; UINT InstructionCount; UINT TempRegisterCount;
	// UINT TempArrayCount; UINT DefCount; UINT DclCount; UINT TextureNormalInstructions; UINT TextureLoadInstructions; UINT
	// TextureCompInstructions; UINT TextureBiasInstructions; UINT TextureGradientInstructions; UINT FloatInstructionCount; UINT
	// IntInstructionCount; UINT UintInstructionCount; UINT StaticFlowControlCount; UINT DynamicFlowControlCount; UINT
	// MacroInstructionCount; UINT ArrayInstructionCount; UINT MovInstructionCount; UINT MovcInstructionCount; UINT
	// ConversionInstructionCount; UINT BitwiseInstructionCount; D3D_FEATURE_LEVEL MinFeatureLevel; UINT64 RequiredFeatureFlags; LPCSTR
	// Name; INT FunctionParameterCount; BOOL HasReturn; BOOL Has10Level9VertexShader; BOOL Has10Level9PixelShader; } D3D11_FUNCTION_DESC;
	[PInvokeData("d3d11shader.h", MSDNShortId = "NS:d3d11shader.D3D11_FUNCTION_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FUNCTION_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The shader version.</para>
		/// </summary>
		public uint Version;

		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the originator of the function.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string Creator;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A combination of D3DCOMPILE Constants that are combined by using a bitwise OR operation. The resulting value specifies shader
		/// compilation and parsing.
		/// </para>
		/// </summary>
		public D3DCOMPILE Flags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of constant buffers for the function.</para>
		/// </summary>
		public uint ConstantBuffers;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of bound resources for the function.</para>
		/// </summary>
		public uint BoundResources;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of emitted instructions for the function.</para>
		/// </summary>
		public uint InstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of temporary registers used by the function.</para>
		/// </summary>
		public uint TempRegisterCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of temporary arrays used by the function.</para>
		/// </summary>
		public uint TempArrayCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of constant defines for the function.</para>
		/// </summary>
		public uint DefCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of declarations (input + output) for the function.</para>
		/// </summary>
		public uint DclCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of non-categorized texture instructions for the function.</para>
		/// </summary>
		public uint TextureNormalInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of texture load instructions for the function.</para>
		/// </summary>
		public uint TextureLoadInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of texture comparison instructions for the function.</para>
		/// </summary>
		public uint TextureCompInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of texture bias instructions for the function.</para>
		/// </summary>
		public uint TextureBiasInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of texture gradient instructions for the function.</para>
		/// </summary>
		public uint TextureGradientInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of floating point arithmetic instructions used by the function.</para>
		/// </summary>
		public uint FloatInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of signed integer arithmetic instructions used by the function.</para>
		/// </summary>
		public uint IntInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of unsigned integer arithmetic instructions used by the function.</para>
		/// </summary>
		public uint UintInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of static flow control instructions used by the function.</para>
		/// </summary>
		public uint StaticFlowControlCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of dynamic flow control instructions used by the function.</para>
		/// </summary>
		public uint DynamicFlowControlCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of macro instructions used by the function.</para>
		/// </summary>
		public uint MacroInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of array instructions used by the function.</para>
		/// </summary>
		public uint ArrayInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of mov instructions used by the function.</para>
		/// </summary>
		public uint MovInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of movc instructions used by the function.</para>
		/// </summary>
		public uint MovcInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of type conversion instructions used by the function.</para>
		/// </summary>
		public uint ConversionInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of bitwise arithmetic instructions used by the function.</para>
		/// </summary>
		public uint BitwiseInstructionCount;

		/// <summary>
		/// <para>Type: <c>D3D_FEATURE_LEVEL</c></para>
		/// <para>A D3D_FEATURE_LEVEL-typed value that specifies the minimum Direct3D feature level target of the function byte code.</para>
		/// </summary>
		public D3D_FEATURE_LEVEL MinFeatureLevel;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>
		/// A value that contains a combination of one or more shader requirements flags; each flag specifies a requirement of the shader. A
		/// default value of 0 means there are no requirements. For a list of values, see <see cref="ID3D11ShaderReflection.GetRequiresFlags"/>.
		/// </para>
		/// </summary>
		public D3D_SHADER_REQUIRES_FLAGS RequiredFeatureFlags;

		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the function.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string? Name;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>The number of logical parameters in the function signature, not including the return value.</para>
		/// </summary>
		public int FunctionParameterCount;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether the function returns a value. <c>TRUE</c> indicates it returns a value; otherwise, <c>FALSE</c> (it is a subroutine).
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool HasReturn;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether there is a Direct3D 10Level9 vertex shader blob. <c>TRUE</c> indicates there is a 10Level9 vertex shader blob;
		/// otherwise, <c>FALSE</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Has10Level9VertexShader;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether there is a Direct3D 10Level9 pixel shader blob. <c>TRUE</c> indicates there is a 10Level9 pixel shader blob;
		/// otherwise, <c>FALSE</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Has10Level9PixelShader;
	}

	/// <summary>Describes a library.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/ns-d3d11shader-d3d11_library_desc typedef struct D3D11_LIBRARY_DESC {
	// LPCSTR Creator; UINT Flags; UINT FunctionCount; } D3D11_LIBRARY_DESC;
	[PInvokeData("d3d11shader.h", MSDNShortId = "NS:d3d11shader.D3D11_LIBRARY_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_LIBRARY_DESC
	{
		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the originator of the library.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Creator;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A combination of D3DCOMPILE Constants that are combined by using a bitwise OR operation. The resulting value specifies how the
		/// compiler compiles.
		/// </para>
		/// </summary>
		public D3DCOMPILE Flags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of functions exported from the library.</para>
		/// </summary>
		public uint FunctionCount;
	}

	/// <summary>Describes a function parameter.</summary>
	/// <remarks>Get a function-parameter description by calling ID3D11FunctionParameterReflection::GetDesc.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/ns-d3d11shader-d3d11_parameter_desc typedef struct
	// D3D11_PARAMETER_DESC { LPCSTR Name; LPCSTR SemanticName; D3D_SHADER_VARIABLE_TYPE Type; D3D_SHADER_VARIABLE_CLASS Class; UINT Rows;
	// UINT Columns; D3D_INTERPOLATION_MODE InterpolationMode; D3D_PARAMETER_FLAGS Flags; UINT FirstInRegister; UINT FirstInComponent; UINT
	// FirstOutRegister; UINT FirstOutComponent; } D3D11_PARAMETER_DESC;
	[PInvokeData("d3d11shader.h", MSDNShortId = "NS:d3d11shader.D3D11_PARAMETER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_PARAMETER_DESC
	{
		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the function parameter.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;

		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The HLSL semantic that is associated with this function parameter. This name includes the index, for example, SV_Target[n].</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string SemanticName;

		/// <summary>
		/// <para>Type: <c>D3D_SHADER_VARIABLE_TYPE</c></para>
		/// <para>A D3D_SHADER_VARIABLE_TYPE-typed value that identifies the variable type for the parameter.</para>
		/// </summary>
		public D3D_SHADER_VARIABLE_TYPE Type;

		/// <summary>
		/// <para>Type: <c>D3D_SHADER_VARIABLE_CLASS</c></para>
		/// <para>
		/// A D3D_SHADER_VARIABLE_CLASS-typed value that identifies the variable class for the parameter as one of scalar, vector, matrix,
		/// object, and so on.
		/// </para>
		/// </summary>
		public D3D_SHADER_VARIABLE_CLASS Class;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of rows for a matrix parameter.</para>
		/// </summary>
		public uint Rows;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of columns for a matrix parameter.</para>
		/// </summary>
		public uint Columns;

		/// <summary>
		/// <para>Type: <c>D3D_INTERPOLATION_MODE</c></para>
		/// <para>A D3D_INTERPOLATION_MODE-typed value that identifies the interpolation mode for the parameter.</para>
		/// </summary>
		public D3D_INTERPOLATION_MODE InterpolationMode;

		/// <summary>
		/// <para>Type: <c>D3D_PARAMETER_FLAGS</c></para>
		/// <para>
		/// A combination of D3D_PARAMETER_FLAGS-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies semantic flags for the parameter.
		/// </para>
		/// </summary>
		public D3D_PARAMETER_FLAGS Flags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first input register for this parameter.</para>
		/// </summary>
		public uint FirstInRegister;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first input register component for this parameter.</para>
		/// </summary>
		public uint FirstInComponent;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first output register for this parameter.</para>
		/// </summary>
		public uint FirstOutRegister;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The first output register component for this parameter.</para>
		/// </summary>
		public uint FirstOutComponent;
	}

	/// <summary>Describes a shader constant-buffer.</summary>
	/// <remarks>
	/// Constants are supplied to shaders in a shader-constant buffer. Get the description of a shader-constant-buffer by calling ID3D11ShaderReflectionConstantBuffer::GetDesc.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/ns-d3d11shader-d3d11_shader_buffer_desc typedef struct
	// D3D11_SHADER_BUFFER_DESC { LPCSTR Name; D3D_CBUFFER_TYPE Type; UINT Variables; UINT Size; UINT uFlags; } D3D11_SHADER_BUFFER_DESC;
	[PInvokeData("d3d11shader.h", MSDNShortId = "NS:d3d11shader.D3D11_SHADER_BUFFER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_SHADER_BUFFER_DESC
	{
		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the buffer.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;

		/// <summary>
		/// <para>Type: <c>D3D_CBUFFER_TYPE</c></para>
		/// <para>A D3D_CBUFFER_TYPE-typed value that indicates the intended use of the constant data.</para>
		/// </summary>
		public D3D_CBUFFER_TYPE Type;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of unique variables.</para>
		/// </summary>
		public uint Variables;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Buffer size (in bytes).</para>
		/// </summary>
		public uint Size;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A combination of D3D_SHADER_CBUFFER_FLAGS-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies properties for the shader constant-buffer.
		/// </para>
		/// </summary>
		public D3D_SHADER_CBUFFER_FLAGS uFlags;
	}

	/// <summary>Describes a shader.</summary>
	/// <remarks>
	/// A shader is written in HLSL and compiled into an intermediate language by the HLSL compiler. The shader description returns
	/// information about the compiled shader. Get a shader description by calling ID3D11ShaderReflection::GetDesc.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/ns-d3d11shader-d3d11_shader_desc typedef struct D3D11_SHADER_DESC {
	// UINT Version; LPCSTR Creator; UINT Flags; UINT ConstantBuffers; UINT BoundResources; UINT InputParameters; UINT OutputParameters;
	// UINT InstructionCount; UINT TempRegisterCount; UINT TempArrayCount; UINT DefCount; UINT DclCount; UINT TextureNormalInstructions;
	// UINT TextureLoadInstructions; UINT TextureCompInstructions; UINT TextureBiasInstructions; UINT TextureGradientInstructions; UINT
	// FloatInstructionCount; UINT IntInstructionCount; UINT UintInstructionCount; UINT StaticFlowControlCount; UINT
	// DynamicFlowControlCount; UINT MacroInstructionCount; UINT ArrayInstructionCount; UINT CutInstructionCount; UINT EmitInstructionCount;
	// D3D_PRIMITIVE_TOPOLOGY GSOutputTopology; UINT GSMaxOutputVertexCount; D3D_PRIMITIVE InputPrimitive; UINT PatchConstantParameters;
	// UINT cGSInstanceCount; UINT cControlPoints; D3D_TESSELLATOR_OUTPUT_PRIMITIVE HSOutputPrimitive; D3D_TESSELLATOR_PARTITIONING
	// HSPartitioning; D3D_TESSELLATOR_DOMAIN TessellatorDomain; UINT cBarrierInstructions; UINT cInterlockedInstructions; UINT
	// cTextureStoreInstructions; } D3D11_SHADER_DESC;
	[PInvokeData("d3d11shader.h", MSDNShortId = "NS:d3d11shader.D3D11_SHADER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_SHADER_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Shader version.</para>
		/// </summary>
		public uint Version;

		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of the originator of the shader.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Creator;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Shader compilation/parse flags.</para>
		/// </summary>
		public uint Flags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of shader-constant buffers.</para>
		/// </summary>
		public uint ConstantBuffers;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of resource (textures and buffers) bound to a shader.</para>
		/// </summary>
		public uint BoundResources;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of parameters in the input signature.</para>
		/// </summary>
		public uint InputParameters;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of parameters in the output signature.</para>
		/// </summary>
		public uint OutputParameters;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of intermediate-language instructions in the compiled shader.</para>
		/// </summary>
		public uint InstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of temporary registers in the compiled shader.</para>
		/// </summary>
		public uint TempRegisterCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of temporary arrays used.</para>
		/// </summary>
		public uint TempArrayCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of constant defines.</para>
		/// </summary>
		public uint DefCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of declarations (input + output).</para>
		/// </summary>
		public uint DclCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of non-categorized texture instructions.</para>
		/// </summary>
		public uint TextureNormalInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of texture load instructions</para>
		/// </summary>
		public uint TextureLoadInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of texture comparison instructions</para>
		/// </summary>
		public uint TextureCompInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of texture bias instructions</para>
		/// </summary>
		public uint TextureBiasInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of texture gradient instructions.</para>
		/// </summary>
		public uint TextureGradientInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of floating point arithmetic instructions used.</para>
		/// </summary>
		public uint FloatInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of signed integer arithmetic instructions used.</para>
		/// </summary>
		public uint IntInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of unsigned integer arithmetic instructions used.</para>
		/// </summary>
		public uint UintInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of static flow control instructions used.</para>
		/// </summary>
		public uint StaticFlowControlCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of dynamic flow control instructions used.</para>
		/// </summary>
		public uint DynamicFlowControlCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of macro instructions used.</para>
		/// </summary>
		public uint MacroInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of array instructions used.</para>
		/// </summary>
		public uint ArrayInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of cut instructions used.</para>
		/// </summary>
		public uint CutInstructionCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of emit instructions used.</para>
		/// </summary>
		public uint EmitInstructionCount;

		/// <summary>
		/// <para>Type: <c>D3D_PRIMITIVE_TOPOLOGY</c></para>
		/// <para>The D3D_PRIMITIVE_TOPOLOGY-typed value that represents the geometry shader output topology.</para>
		/// </summary>
		public D3D_PRIMITIVE_TOPOLOGY GSOutputTopology;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Geometry shader maximum output vertex count.</para>
		/// </summary>
		public uint GSMaxOutputVertexCount;

		/// <summary>
		/// <para>Type: <c>D3D_PRIMITIVE</c></para>
		/// <para>The D3D_PRIMITIVE-typed value that represents the input primitive for a geometry shader or hull shader.</para>
		/// </summary>
		public D3D_PRIMITIVE InputPrimitive;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of parameters in the patch-constant signature.</para>
		/// </summary>
		public uint PatchConstantParameters;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of geometry shader instances.</para>
		/// </summary>
		public uint cGSInstanceCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of control points in the hull shader and domain shader.</para>
		/// </summary>
		public uint cControlPoints;

		/// <summary>
		/// <para>Type: <c>D3D_TESSELLATOR_OUTPUT_PRIMITIVE</c></para>
		/// <para>The D3D_TESSELLATOR_OUTPUT_PRIMITIVE-typed value that represents the tessellator output-primitive type.</para>
		/// </summary>
		public D3D_TESSELLATOR_OUTPUT_PRIMITIVE HSOutputPrimitive;

		/// <summary>
		/// <para>Type: <c>D3D_TESSELLATOR_PARTITIONING</c></para>
		/// <para>The D3D_TESSELLATOR_PARTITIONING-typed value that represents the tessellator partitioning mode.</para>
		/// </summary>
		public D3D_TESSELLATOR_PARTITIONING HSPartitioning;

		/// <summary>
		/// <para>Type: <c>D3D_TESSELLATOR_DOMAIN</c></para>
		/// <para>The D3D_TESSELLATOR_DOMAIN-typed value that represents the tessellator domain.</para>
		/// </summary>
		public D3D_TESSELLATOR_DOMAIN TessellatorDomain;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of barrier instructions in a compute shader.</para>
		/// </summary>
		public uint cBarrierInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of interlocked instructions in a compute shader.</para>
		/// </summary>
		public uint cInterlockedInstructions;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of texture writes in a compute shader.</para>
		/// </summary>
		public uint cTextureStoreInstructions;
	}

	/// <summary>Describes how a shader resource is bound to a shader input.</summary>
	/// <remarks>Get a shader-input-signature description by calling ID3D11ShaderReflection::GetResourceBindingDesc or ID3D11ShaderReflection::GetResourceBindingDescByName.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/ns-d3d11shader-d3d11_shader_input_bind_desc typedef struct
	// D3D11_SHADER_INPUT_BIND_DESC { LPCSTR Name; D3D_SHADER_INPUT_TYPE Type; UINT BindPoint; UINT BindCount; UINT uFlags;
	// D3D_RESOURCE_RETURN_TYPE ReturnType; D3D_SRV_DIMENSION Dimension; UINT NumSamples; } D3D11_SHADER_INPUT_BIND_DESC;
	[PInvokeData("d3d11shader.h", MSDNShortId = "NS:d3d11shader.D3D11_SHADER_INPUT_BIND_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_SHADER_INPUT_BIND_DESC
	{
		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>Name of the shader resource.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;

		/// <summary>
		/// <para>Type: <c>D3D_SHADER_INPUT_TYPE</c></para>
		/// <para>A D3D_SHADER_INPUT_TYPE-typed value that identifies the type of data in the resource.</para>
		/// </summary>
		public D3D_SHADER_INPUT_TYPE Type;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Starting bind point.</para>
		/// </summary>
		public uint BindPoint;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of contiguous bind points for arrays.</para>
		/// </summary>
		public uint BindCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>A combination of D3D_SHADER_INPUT_FLAGS-typed values for shader input-parameter options.</para>
		/// </summary>
		public D3D_SHADER_INPUT_FLAGS uFlags;

		/// <summary>
		/// <para>Type: <c>D3D_RESOURCE_RETURN_TYPE</c></para>
		/// <para>If the input is a texture, the D3D_RESOURCE_RETURN_TYPE-typed value that identifies the return type.</para>
		/// </summary>
		public D3D_RESOURCE_RETURN_TYPE ReturnType;

		/// <summary>
		/// <para>Type: <c>D3D_SRV_DIMENSION</c></para>
		/// <para>A D3D_SRV_DIMENSION-typed value that identifies the dimensions of the bound resource.</para>
		/// </summary>
		public D3D_SRV_DIMENSION Dimension;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of samples for a multisampled texture; when a texture isn't multisampled, the value is set to -1 (0xFFFFFFFF).</para>
		/// </summary>
		public uint NumSamples;
	}

	/// <summary>Describes a shader-variable type.</summary>
	/// <remarks>Get a shader-variable-type description by calling ID3D11ShaderReflectionType::GetDesc.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/ns-d3d11shader-d3d11_shader_type_desc typedef struct
	// D3D11_SHADER_TYPE_DESC { D3D_SHADER_VARIABLE_CLASS Class; D3D_SHADER_VARIABLE_TYPE Type; UINT Rows; UINT Columns; UINT Elements; UINT
	// Members; UINT Offset; LPCSTR Name; } D3D11_SHADER_TYPE_DESC;
	[PInvokeData("d3d11shader.h", MSDNShortId = "NS:d3d11shader.D3D11_SHADER_TYPE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_SHADER_TYPE_DESC
	{
		/// <summary>
		/// <para>Type: <c>D3D_SHADER_VARIABLE_CLASS</c></para>
		/// <para>
		/// A D3D_SHADER_VARIABLE_CLASS-typed value that identifies the variable class as one of scalar, vector, matrix, object, and so on.
		/// </para>
		/// </summary>
		public D3D_SHADER_VARIABLE_CLASS Class;

		/// <summary>
		/// <para>Type: <c>D3D_SHADER_VARIABLE_TYPE</c></para>
		/// <para>A D3D_SHADER_VARIABLE_TYPE-typed value that identifies the variable type.</para>
		/// </summary>
		public D3D_SHADER_VARIABLE_TYPE Type;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of rows in a matrix. Otherwise a numeric type returns 1, any other type returns 0.</para>
		/// </summary>
		public uint Rows;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of columns in a matrix. Otherwise a numeric type returns 1, any other type returns 0.</para>
		/// </summary>
		public uint Columns;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of elements in an array; otherwise 0.</para>
		/// </summary>
		public uint Elements;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of members in the structure; otherwise 0.</para>
		/// </summary>
		public uint Members;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Offset, in bytes, between the start of the parent structure and this variable. Can be 0 if not a structure member.</para>
		/// </summary>
		public uint Offset;

		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>
		/// Name of the shader-variable type. This member can be <c>NULL</c> if it isn't used. This member supports dynamic shader linkage
		/// interface types, which have names. For more info about dynamic shader linkage, see Dynamic Linking.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;
	}

	/// <summary>Describes a shader variable.</summary>
	/// <remarks>
	/// <para>Get a shader-variable description using reflection by calling ID3D11ShaderReflectionVariable::GetDesc.</para>
	/// <para>As of the June 2010 update, <c>DefaultValue</c> emits default values for reflection.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/ns-d3d11shader-d3d11_shader_variable_desc typedef struct
	// D3D11_SHADER_VARIABLE_DESC { LPCSTR Name; UINT StartOffset; UINT Size; UINT uFlags; LPVOID DefaultValue; UINT StartTexture; UINT
	// TextureSize; UINT StartSampler; UINT SamplerSize; } D3D11_SHADER_VARIABLE_DESC;
	[PInvokeData("d3d11shader.h", MSDNShortId = "NS:d3d11shader.D3D11_SHADER_VARIABLE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_SHADER_VARIABLE_DESC
	{
		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The variable name.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string Name;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Offset from the start of the parent structure to the beginning of the variable.</para>
		/// </summary>
		public uint StartOffset;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of the variable (in bytes).</para>
		/// </summary>
		public uint Size;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A combination of D3D_SHADER_VARIABLE_FLAGS-typed values that are combined by using a bitwise OR operation. The resulting value
		/// identifies shader-variable properties.
		/// </para>
		/// </summary>
		public D3D_SHADER_VARIABLE_FLAGS uFlags;

		/// <summary>
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>The default value for initializing the variable.</para>
		/// </summary>
		public IntPtr DefaultValue;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Offset from the start of the variable to the beginning of the texture.</para>
		/// </summary>
		public uint StartTexture;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the texture, in bytes.</para>
		/// </summary>
		public uint TextureSize;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Offset from the start of the variable to the beginning of the sampler.</para>
		/// </summary>
		public uint StartSampler;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the sampler, in bytes.</para>
		/// </summary>
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
	/// <para>Get a shader-signature from a shader or an effect by calling APIs such as ID3D11ShaderReflection::GetInputParameterDesc.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11shader/ns-d3d11shader-d3d11_signature_parameter_desc typedef struct
	// D3D11_SIGNATURE_PARAMETER_DESC { LPCSTR SemanticName; UINT SemanticIndex; UINT Register; D3D_NAME SystemValueType;
	// D3D_REGISTER_COMPONENT_TYPE ComponentType; BYTE Mask; BYTE ReadWriteMask; UINT Stream; D3D_MIN_PRECISION MinPrecision; } D3D11_SIGNATURE_PARAMETER_DESC;
	[PInvokeData("d3d11shader.h", MSDNShortId = "NS:d3d11shader.D3D11_SIGNATURE_PARAMETER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_SIGNATURE_PARAMETER_DESC
	{
		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>A per-parameter string that identifies how the data will be used. For more info, see Semantics.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string SemanticName;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Semantic index that modifies the semantic. Used to differentiate different parameters that use the same semantic.</para>
		/// </summary>
		public uint SemanticIndex;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The register that will contain this variable's data.</para>
		/// </summary>
		public uint Register;

		/// <summary>
		/// <para>Type: <c>D3D_NAME</c></para>
		/// <para>A D3D_NAME-typed value that identifies a predefined string that determines the functionality of certain pipeline stages.</para>
		/// </summary>
		public D3D_NAME SystemValueType;

		/// <summary>
		/// <para>Type: <c>D3D_REGISTER_COMPONENT_TYPE</c></para>
		/// <para>
		/// A D3D_REGISTER_COMPONENT_TYPE-typed value that identifies the per-component-data type that is stored in a register. Each
		/// register can store up to four-components of data.
		/// </para>
		/// </summary>
		public D3D_REGISTER_COMPONENT_TYPE ComponentType;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>Mask which indicates which components of a register are used.</para>
		/// </summary>
		public byte Mask;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>
		/// Mask which indicates whether a given component is never written (if the signature is an output signature) or always read (if the
		/// signature is an input signature).
		/// </para>
		/// </summary>
		public byte ReadWriteMask;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Indicates which stream the geometry shader is using for the signature parameter.</para>
		/// </summary>
		public uint Stream;

		/// <summary>
		/// <para>Type: <c>D3D_MIN_PRECISION</c></para>
		/// <para>
		/// A D3D_MIN_PRECISION-typed value that indicates the minimum desired interpolation precision. For more info, see Using HLSL
		/// minimum precision.
		/// </para>
		/// </summary>
		public D3D_MIN_PRECISION MinPrecision;
	}
}