global using static Vanara.PInvoke.DXGI;
global using ID3DBlob = Vanara.PInvoke.DXGI.ID3DBlob;

namespace Vanara.PInvoke;

/// <summary>Items from the D3DCompiler.dll</summary>
public static partial class D3DCompiler
{
	private const string Lib_D3dcompiler_47 = "d3dcompiler_47.dll";

	/// <summary>Values that identify parts of the content of an arbitrary length data buffer.</summary>
	/// <remarks>These values are passed to the D3DGetBlobPart or D3DSetBlobPart function.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/ne-d3dcompiler-d3d_blob_part typedef enum D3D_BLOB_PART {
	// D3D_BLOB_INPUT_SIGNATURE_BLOB, D3D_BLOB_OUTPUT_SIGNATURE_BLOB, D3D_BLOB_INPUT_AND_OUTPUT_SIGNATURE_BLOB,
	// D3D_BLOB_PATCH_CONSTANT_SIGNATURE_BLOB, D3D_BLOB_ALL_SIGNATURE_BLOB, D3D_BLOB_DEBUG_INFO, D3D_BLOB_LEGACY_SHADER,
	// D3D_BLOB_XNA_PREPASS_SHADER, D3D_BLOB_XNA_SHADER, D3D_BLOB_PDB, D3D_BLOB_PRIVATE_DATA, D3D_BLOB_ROOT_SIGNATURE, D3D_BLOB_DEBUG_NAME,
	// D3D_BLOB_TEST_ALTERNATE_SHADER = 0x8000, D3D_BLOB_TEST_COMPILE_DETAILS, D3D_BLOB_TEST_COMPILE_PERF, D3D_BLOB_TEST_COMPILE_REPORT } ;
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NE:d3dcompiler.D3D_BLOB_PART")]
	public enum D3D_BLOB_PART
	{
		/// <summary>The blob part is an input signature.</summary>
		D3D_BLOB_INPUT_SIGNATURE_BLOB,

		/// <summary>The blob part is an output signature.</summary>
		D3D_BLOB_OUTPUT_SIGNATURE_BLOB,

		/// <summary>The blob part is an input and output signature.</summary>
		D3D_BLOB_INPUT_AND_OUTPUT_SIGNATURE_BLOB,

		/// <summary>The blob part is a patch constant signature.</summary>
		D3D_BLOB_PATCH_CONSTANT_SIGNATURE_BLOB,

		/// <summary>The blob part is all signature.</summary>
		D3D_BLOB_ALL_SIGNATURE_BLOB,

		/// <summary>The blob part is debug information.</summary>
		D3D_BLOB_DEBUG_INFO,

		/// <summary>The blob part is a legacy shader.</summary>
		D3D_BLOB_LEGACY_SHADER,

		/// <summary>The blob part is an XNA prepass shader.</summary>
		D3D_BLOB_XNA_PREPASS_SHADER,

		/// <summary>The blob part is an XNA shader.</summary>
		D3D_BLOB_XNA_SHADER,

		/// <summary>
		/// <para>The blob part is program database (PDB) information.</para>
		/// <para><c>Note</c>  This value is supported by the D3dcompiler_44.dll or later version of the file.</para>
		/// <para></para>
		/// </summary>
		D3D_BLOB_PDB,

		/// <summary>
		/// <para>The blob part is private data.</para>
		/// <para><c>Note</c>  This value is supported by the D3dcompiler_44.dll or later version of the file.</para>
		/// <para></para>
		/// </summary>
		D3D_BLOB_PRIVATE_DATA,

		/// <summary>
		/// <para>The blob part is a root signature. Refer to</para>
		/// <para>Specifying Root Signatures in HLSL</para>
		/// <para>for more information on using Direct3D12 with HLSL.</para>
		/// <para><c>Note</c>  This value is supported by the D3dcompiler_47.dll or later version of the file.</para>
		/// <para></para>
		/// </summary>
		D3D_BLOB_ROOT_SIGNATURE,

		/// <summary>
		/// <para>
		/// The blob part is the debug name of the shader. If the application does not specify the debug name itself, an auto-generated name
		/// matching the PDB file of the shader is provided instead.
		/// </para>
		/// <para>
		/// <c>Note</c>  This value is supported by the D3dcompiler_47.dll as available on the Windows 10 Fall Creators Update and its SDK,
		/// or later version of the file.
		/// </para>
		/// <para></para>
		/// </summary>
		D3D_BLOB_DEBUG_NAME,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8000</para>
		/// <para>The blob part is a test alternate shader.</para>
		/// <para>
		/// <c>Note</c>  This value identifies a test part and is only produced by special compiler versions. Therefore, this part type is
		/// typically not present in shaders.
		/// </para>
		/// <para></para>
		/// </summary>
		D3D_BLOB_TEST_ALTERNATE_SHADER,

		/// <summary>
		/// <para>The blob part is test compilation details.</para>
		/// <para>
		/// <c>Note</c>  This value identifies a test part and is only produced by special compiler versions. Therefore, this part type is
		/// typically not present in shaders.
		/// </para>
		/// <para></para>
		/// </summary>
		D3D_BLOB_TEST_COMPILE_DETAILS,

		/// <summary>
		/// <para>The blob part is test compilation performance.</para>
		/// <para>
		/// <c>Note</c>  This value identifies a test part and is only produced by special compiler versions. Therefore, this part type is
		/// typically not present in shaders.
		/// </para>
		/// <para></para>
		/// </summary>
		D3D_BLOB_TEST_COMPILE_PERF,

		/// <summary>
		/// <para>The blob part is a test compilation report.</para>
		/// <para>
		/// <c>Note</c>  This value identifies a test part and is only produced by special compiler versions. Therefore, this part type is
		/// typically not present in shaders.
		/// </para>
		/// <para></para>
		/// <para><c>Note</c>  This value is supported by the D3dcompiler_44.dll or later version of the file.</para>
		/// <para></para>
		/// </summary>
		D3D_BLOB_TEST_COMPILE_REPORT,
	}

	/// <summary>Indicate how to compress the shaders.</summary>
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCompressShaders")]
	[Flags]
	public enum D3D_COMPRESS_SHADER : uint
	{
		/// <summary>Keep all parts.</summary>
		D3D_COMPRESS_SHADER_KEEP_ALL_PARTS = 0x1
	}

	/// <summary>Flags affecting the behavior of <c>D3DDisassemble</c>.</summary>
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DDisassemble")]
	[Flags]
	public enum D3D_DISASM : uint
	{
		/// <summary>Enable the output of color codes.</summary>
		D3D_DISASM_ENABLE_COLOR_CODE = 0x00000001,

		/// <summary>Enable the output of default values.</summary>
		D3D_DISASM_ENABLE_DEFAULT_VALUE_PRINTS = 0x00000002,

		/// <summary>Enable instruction numbering.</summary>
		D3D_DISASM_ENABLE_INSTRUCTION_NUMBERING = 0x00000004,

		/// <summary>No effect.</summary>
		D3D_DISASM_ENABLE_INSTRUCTION_CYCLE = 0x00000008,

		/// <summary>Disable debug information.</summary>
		D3D_DISASM_DISABLE_DEBUG_INFO = 0x00000010,

		/// <summary>Enable instruction offsets.</summary>
		D3D_DISASM_ENABLE_INSTRUCTION_OFFSET = 0x00000020,

		/// <summary>Disassemble instructions only.</summary>
		D3D_DISASM_INSTRUCTION_ONLY = 0x00000040,

		/// <summary>Use hex symbols in disassemblies.</summary>
		D3D_DISASM_PRINT_HEX_LITERALS = 0x00000080,
	}

	/// <summary>Specifies how <c>D3DGetTraceInstructionOffsets</c> retrieves the instruction offsets.</summary>
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DGetTraceInstructionOffsets")]
	[Flags]
	public enum D3D_GET_INST_OFFSETS : uint
	{
		/// <summary>Include non-executable code in the retrieved information.</summary>
		D3D_GET_INST_OFFSETS_INCLUDE_NON_EXECUTABLE = 0x1
	}

	/// <summary>
	/// <para>The D3DCOMPILE constants specify how the compiler compiles the HLSL code.</para>
	/// <note>The D3DCOMPILE_RESOURCES_MAY_ALIAS, D3DCOMPILE_ENABLE_UNBOUNDED_DESCRIPTOR_TABLES, and D3DCOMPILE_ALL_RESOURCES_BOUND and
	/// compiler constants are new starting with the D3dcompiler_47.dll that ships with the Windows 8.1 SDK or later.</note><note>The
	/// D3DCOMPILE_DEBUG_NAME_FOR_SOURCE and D3DCOMPILE_DEBUG_NAME_FOR_BINARY compiler constants are new starting with the
	/// D3dcompiler_47.dll that ships with the Windows 10 Fall Creator's Update SDK (version 16299) or later. See this blog
	/// post.</note><note>For DirectX 12, Shader Model 5.1, the D3DCompile API, and FXC are all deprecated. Use Shader Model 6 via DXIL
	/// instead. See GitHub.</note>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/direct3dhlsl/d3dcompile-constants
	[PInvokeData("D3DCompiler.h")]
	[Flags]
	public enum D3DCOMPILE : uint
	{
		/// <summary>
		/// Directs the compiler to insert debug file/line/type/symbol information into the output code.
		/// <para>See D3DXSHADER_DEBUG</para>
		/// </summary>
		D3DCOMPILE_DEBUG = 1 << 0,

		/// <summary>
		/// Directs the compiler not to validate the generated code against known capabilities and constraints. We recommend that you use
		/// this constant only with shaders that have been successfully compiled in the past. DirectX always validates shaders before it
		/// sets them to a device.
		/// <para>See D3DXSHADER_SKIPVALIDATION</para>
		/// </summary>
		D3DCOMPILE_SKIP_VALIDATION = 1 << 1,

		/// <summary>
		/// Directs the compiler to skip optimization steps during code generation. We recommend that you set this constant for debug
		/// purposes only.
		/// </summary>
		D3DCOMPILE_SKIP_OPTIMIZATION = 1 << 2,

		/// <summary>
		/// Directs the compiler to pack matrices in row-major order on input and output from the shader.
		/// <para>See D3DXSHADER_SKIPOPTIMIZATION</para>
		/// </summary>
		D3DCOMPILE_PACK_MATRIX_ROW_MAJOR = 1 << 3,

		/// <summary>
		/// Directs the compiler to pack matrices in column-major order on input and output from the shader. This type of packing is
		/// generally more efficient because a series of dot-products can then perform vector-matrix multiplication.
		/// <para>See D3DXSHADER_PACKMATRIX_ROWMAJOR</para>
		/// </summary>
		D3DCOMPILE_PACK_MATRIX_COLUMN_MAJOR = 1 << 4,

		/// <summary>
		/// Directs the compiler to perform all computations with partial precision. If you set this constant, the compiled code might run
		/// faster on some hardware.
		/// <para>See D3DXSHADER_PACKMATRIX_COLUMNMAJOR</para>
		/// </summary>
		D3DCOMPILE_PARTIAL_PRECISION = 1 << 5,

		/// <summary>
		/// Directs the compiler to compile a vertex shader for the next highest shader profile. This constant turns debugging on and
		/// optimizations off.
		/// <para>This flag was applicable only to Direct3D 9. See D3DXSHADER_FORCE_VS_SOFTWARE_NOOPT</para>
		/// </summary>
		D3DCOMPILE_FORCE_VS_SOFTWARE_NO_OPT = 1 << 6,

		/// <summary>
		/// Directs the compiler to compile a pixel shader for the next highest shader profile. This constant also turns debugging on and
		/// optimizations off.
		/// <para>This flag was applicable only to Direct3D 9. See D3DXSHADER_FORCE_PS_SOFTWARE_NOOPT</para>
		/// </summary>
		D3DCOMPILE_FORCE_PS_SOFTWARE_NO_OPT = 1 << 7,

		/// <summary>
		/// Directs the compiler to disable Preshaders. If you set this constant, the compiler does not pull out static expression for evaluation.
		/// <para>This flag was only applicable to legacy Direct3D 9 and Direct3D 10 Effects (FX). See D3DXSHADER_NO_PRESHADER</para>
		/// </summary>
		D3DCOMPILE_NO_PRESHADER = 1 << 8,

		/// <summary>
		/// Directs the compiler to not use flow-control constructs where possible.
		/// <para>See D3DXSHADER_AVOID_FLOW_CONTROL</para>
		/// </summary>
		D3DCOMPILE_AVOID_FLOW_CONTROL = 1 << 9,

		/// <summary>Hint compiler to prefer flow-control constructs where possible.</summary>
		D3DCOMPILE_PREFER_FLOW_CONTROL = 1 << 10,

		/// <summary>
		/// Forces strict compile, which might not allow for legacy syntax. By default, the compiler disables strictness on deprecated syntax.
		/// </summary>
		D3DCOMPILE_ENABLE_STRICTNESS = 1 << 11,

		/// <summary>
		/// Directs the compiler to enable older shaders to compile to 5_0 targets.
		/// <para>See D3DXSHADER_ENABLE_BACKWARDS_COMPATIBILITY</para>
		/// </summary>
		D3DCOMPILE_ENABLE_BACKWARDS_COMPATIBILITY = 1 << 12,

		/// <summary>
		/// Forces the IEEE strict compile which avoids optimizations that may break IEEE rules.
		/// <para>See D3DXSHADER_IEEE_STRICTNESS</para>
		/// </summary>
		D3DCOMPILE_IEEE_STRICTNESS = 1 << 13,

		/// <summary>
		/// Directs the compiler to use the lowest optimization level. If you set this constant, the compiler might produce slower code but
		/// produces the code more quickly. Set this constant when you develop the shader iteratively.
		/// <para>See D3DXSHADER_OPTIMIZATION_LEVEL0</para>
		/// </summary>
		D3DCOMPILE_OPTIMIZATION_LEVEL0 = 1 << 14,

		/// <summary>
		/// Directs the compiler to use the second lowest optimization level.
		/// <para>See D3DXSHADER_OPTIMIZATION_LEVEL1</para>
		/// </summary>
		D3DCOMPILE_OPTIMIZATION_LEVEL1 = 0,

		/// <summary>
		/// Directs the compiler to use the second highest optimization level.
		/// <para>See D3DXSHADER_OPTIMIZATION_LEVEL2</para>
		/// </summary>
		D3DCOMPILE_OPTIMIZATION_LEVEL2 = (1 << 14) | (1 << 15),

		/// <summary>
		/// Directs the compiler to use the highest optimization level. If you set this constant, the compiler produces the best possible
		/// code but might take significantly longer to do so. Set this constant for final builds of an application when performance is the
		/// most important factor.
		/// <para>See D3DXSHADER_OPTIMIZATION_LEVEL3</para>
		/// </summary>
		D3DCOMPILE_OPTIMIZATION_LEVEL3 = 1 << 15,

		/// <summary>Reserved.</summary>
		D3DCOMPILE_RESERVED16 = 1 << 16,

		/// <summary>Reserved.</summary>
		D3DCOMPILE_RESERVED17 = 1 << 17,

		/// <summary>
		/// Directs the compiler to treat all warnings as errors when it compiles the shader code. We recommend that you use this constant
		/// for new shader code, so that you can resolve all warnings and lower the number of hard-to-find code defects.
		/// </summary>
		D3DCOMPILE_WARNINGS_ARE_ERRORS = 1 << 18,

		/// <summary>
		/// Directs the compiler to assume that unordered access views (UAVs) and shader resource views (SRVs) may alias for cs_5_0.
		/// <para>Only applies to DirectX 12 / Shader Model 5.1</para>
		/// </summary>
		D3DCOMPILE_RESOURCES_MAY_ALIAS = 1 << 19,

		/// <summary>
		/// Directs the compiler to enable unbounded descriptor tables.
		/// <para>Only applies to DirectX 12 / Shader Model 5.1</para>
		/// </summary>
		D3DCOMPILE_ENABLE_UNBOUNDED_DESCRIPTOR_TABLES = 1 << 20,

		/// <summary>
		/// Directs the compiler to ensure all resources are bound.
		/// <para>Only applies to DirectX 12 / Shader Model 5.1</para>
		/// </summary>
		D3DCOMPILE_ALL_RESOURCES_BOUND = 1 << 21,

		/// <summary>When generating debug PDBs this makes use of the source file and binary for the hash.</summary>
		D3DCOMPILE_DEBUG_NAME_FOR_SOURCE = 1 << 22,

		/// <summary>When generating debug PDBs this makes use of the binary file name only for the hash.</summary>
		D3DCOMPILE_DEBUG_NAME_FOR_BINARY = 1 << 23,
	}

	/// <summary>These constants direct how the compiler compiles an effect file or how the runtime processes the effect file.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/direct3dhlsl/d3dcompile-effect-constants
	[PInvokeData("D3DCompiler.h")]
	[Flags]
	public enum D3DCOMPILE_EFFECT : uint
	{
		/// <summary>
		/// Compile the effects (.fx) file to a child effect. Child effects have no initializers for any shared values because these child
		/// effects are initialized in the master effect (the effect pool). <note>Effect pools are supported by Effects 10 (FX10) but not by
		/// Effects 11 (FX11). For more info about differences between effect pools in Direct3D 10 and effect groups in Direct3D 11, see
		/// Effect Pools and Groups.</note>
		/// </summary>
		D3DCOMPILE_EFFECT_CHILD_EFFECT = 1 << 0,

		/// <summary>
		/// Disables performance mode and allows for mutable state objects.
		/// <para>
		/// By default, performance mode is enabled. Performance mode disallows mutable state objects by preventing non-literal expressions
		/// from appearing in state object definitions.
		/// </para>
		/// </summary>
		D3DCOMPILE_EFFECT_ALLOW_SLOW_OPS = 1 << 1,
	}

	/// <summary>Root signature flags.</summary>
	[PInvokeData("D3DCompiler.h")]
	[Flags]
	public enum D3DCOMPILE_FLAGS2 : uint
	{
		/// <summary/>
		D3DCOMPILE_FLAGS2_FORCE_ROOT_SIGNATURE_LATEST = 0,

		/// <summary/>
		D3DCOMPILE_FLAGS2_FORCE_ROOT_SIGNATURE_1_0 = 1 << 4,

		/// <summary/>
		D3DCOMPILE_FLAGS2_FORCE_ROOT_SIGNATURE_1_1 = 1 << 5,
	}

	/// <summary>Specifies how the compiler compiles the HLSL code.</summary>
	[PInvokeData("D3DCompiler.h")]
	[Flags]
	public enum D3DCOMPILE_SECDATA : uint
	{
		/// <summary>Merge unordered access view (UAV) slots in the secondary data that the pSecondaryData parameter points to.</summary>
		D3DCOMPILE_SECDATA_MERGE_UAV_SLOTS = 0x00000001,

		/// <summary>Preserve template slots in the secondary data that the pSecondaryData parameter points to.</summary>
		D3DCOMPILE_SECDATA_PRESERVE_TEMPLATE_SLOTS = 0x00000002,

		/// <summary>
		/// Require that templates in the secondary data that the pSecondaryData parameter points to match when the compiler compiles the
		/// HLSL code.
		/// </summary>
		D3DCOMPILE_SECDATA_REQUIRE_TEMPLATE_MATCH = 0x00000004,
	}

	/// <summary>Strip flag options.</summary>
	/// <remarks>These flags are used by D3DStripShader.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/ne-d3dcompiler-d3dcompiler_strip_flags typedef enum
	// D3DCOMPILER_STRIP_FLAGS { D3DCOMPILER_STRIP_REFLECTION_DATA = 0x00000001, D3DCOMPILER_STRIP_DEBUG_INFO = 0x00000002,
	// D3DCOMPILER_STRIP_TEST_BLOBS = 0x00000004, D3DCOMPILER_STRIP_PRIVATE_DATA = 0x00000008, D3DCOMPILER_STRIP_ROOT_SIGNATURE =
	// 0x00000010, D3DCOMPILER_STRIP_FORCE_DWORD = 0x7fffffff } ;
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NE:d3dcompiler.D3DCOMPILER_STRIP_FLAGS")]
	[Flags]
	public enum D3DCOMPILER_STRIP_FLAGS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000001</para>
		/// <para>Remove reflection data.</para>
		/// </summary>
		D3DCOMPILER_STRIP_REFLECTION_DATA = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000002</para>
		/// <para>Remove debug information.</para>
		/// </summary>
		D3DCOMPILER_STRIP_DEBUG_INFO = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000004</para>
		/// <para>Remove test blob data.</para>
		/// </summary>
		D3DCOMPILER_STRIP_TEST_BLOBS = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000008</para>
		/// <para><c>Note</c>  This value is supported by the D3dcompiler_44.dll or later version of the file.</para>
		/// <para></para>
		/// <para>Remove private data.</para>
		/// </summary>
		D3DCOMPILER_STRIP_PRIVATE_DATA = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00000010</para>
		/// <para><c>Note</c>  This value is supported by the D3dcompiler_47.dll or later version of the file.</para>
		/// <para></para>
		/// <para>Remove the root signature. Refer to</para>
		/// <para>Specifying Root Signatures in HLSL</para>
		/// <para>for more information on using Direct3D12 with HLSL.</para>
		/// </summary>
		D3DCOMPILER_STRIP_ROOT_SIGNATURE = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x7fffffff</para>
		/// <para>
		/// Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this enumeration to
		/// compile to a size other than 32 bits. This value is not used.
		/// </para>
		/// </summary>
		D3DCOMPILER_STRIP_FORCE_DWORD = 0x7fffffff,
	}

	/// <summary>Compile HLSL code or an effect file into bytecode for a given target.</summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to uncompiled shader data; either ASCII HLSL code or a compiled effect.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// </param>
	/// <param name="pSourceName">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>You can use this parameter for strings that specify error messages. If not used, set to <c>NULL</c>.</para>
	/// </param>
	/// <param name="pDefines">
	/// <para>Type: <c>const D3D_SHADER_MACRO*</c></para>
	/// <para>
	/// An optional array of D3D_SHADER_MACRO structures that define shader macros. Each macro definition contains a name and a
	/// null-terminated definition. If not used, set to <c>NULL</c>. The last structure in the array serves as a terminator and must have
	/// all members set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pInclude">
	/// <para>Type: <c>ID3DInclude*</c></para>
	/// <para>
	/// Optional. A pointer to an ID3DInclude for handling include files. Setting this to <c>NULL</c> will cause a compile error if a shader
	/// contains a #include. You can pass the <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c> macro, which is a pointer to a default include
	/// handler. This default include handler includes files that are relative to the current directory and files that are relative to the
	/// directory of the initial source file. When you use <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c>, you must specify the source file name
	/// in the <c>pSourceName</c> parameter; the compiler will derive the initial relative directory from <c>pSourceName</c>.
	/// </para>
	/// </param>
	/// <param name="pEntrypoint">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>
	/// The name of the shader entry point function where shader execution begins. When you compile using a fx profile (for example, fx_4_0,
	/// fx_5_0, and so on), <c>D3DCompile</c> ignores <c>pEntrypoint</c>. In this case, we recommend that you set <c>pEntrypoint</c> to
	/// <c>NULL</c> because it is good programming practice to set a pointer parameter to <c>NULL</c> if the called function will not use
	/// it. For all other shader profiles, a valid <c>pEntrypoint</c> is required.
	/// </para>
	/// </param>
	/// <param name="pTarget">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>
	/// A string that specifies the shader target or set of shader features to compile against. The shader target can be shader model 2,
	/// shader model 3, shader model 4, or shader model 5. The target can also be an effect type (for example, fx_4_1). For info about the
	/// targets that various profiles support, see Specifying Compiler Targets.
	/// </para>
	/// </param>
	/// <param name="Flags1">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags defined by D3D compile constants.</para>
	/// </param>
	/// <param name="Flags2">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Flags defined by D3D compile effect constants. When you compile a shader and not an effect file, <c>D3DCompile</c> ignores
	/// <c>Flags2</c>; we recommend that you set <c>Flags2</c> to zero because it is good programming practice to set a nonpointer parameter
	/// to zero if the called function will not use it.
	/// </para>
	/// </param>
	/// <param name="ppCode">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the compiled code.</para>
	/// </param>
	/// <param name="ppErrorMsgs">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>
	/// A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error messages, or
	/// <c>NULL</c> if there are no errors.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>
	/// The difference between <c>D3DCompile</c> and D3DCompile2 is that the latter method takes some optional parameters that can be used
	/// to control some aspects of how bytecode is generated. If this extra flexibility is not required, there is no performance gain from
	/// using <c>D3DCompile2</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcompile HRESULT D3DCompile( [in] LPCVOID pSrcData,
	// [in] SIZE_T SrcDataSize, [in, optional] LPCSTR pSourceName, [in, optional] const D3D_SHADER_MACRO *pDefines, [in, optional]
	// ID3DInclude *pInclude, [in, optional] LPCSTR pEntrypoint, [in] LPCSTR pTarget, [in] UINT Flags1, [in] UINT Flags2, [out] ID3DBlob
	// **ppCode, [out, optional] ID3DBlob **ppErrorMsgs );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCompile")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DCompile([In] IntPtr pSrcData, [In] SizeT SrcDataSize,
		[In, Optional, MarshalAs(UnmanagedType.LPStr)] string? pSourceName, [In, Optional] IntPtr pDefines,
		[In, Optional] ID3DInclude? pInclude, [In, Optional, MarshalAs(UnmanagedType.LPStr)] string? pEntrypoint,
		[In, MarshalAs(UnmanagedType.LPStr)] string pTarget, D3DCOMPILE Flags1, [Optional] D3DCOMPILE_FLAGS2 Flags2, out ID3DBlob ppCode,
		[Out, Optional] IntPtr ppErrorMsgs);

	/// <summary>Compile HLSL code or an effect file into bytecode for a given target.</summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to uncompiled shader data; either ASCII HLSL code or a compiled effect.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// </param>
	/// <param name="pSourceName">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>You can use this parameter for strings that specify error messages. If not used, set to <c>NULL</c>.</para>
	/// </param>
	/// <param name="pDefines">
	/// <para>Type: <c>const D3D_SHADER_MACRO*</c></para>
	/// <para>
	/// An optional array of D3D_SHADER_MACRO structures that define shader macros. Each macro definition contains a name and a
	/// null-terminated definition. If not used, set to <c>NULL</c>. The last structure in the array serves as a terminator and must have
	/// all members set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pInclude">
	/// <para>Type: <c>ID3DInclude*</c></para>
	/// <para>
	/// Optional. A pointer to an ID3DInclude for handling include files. Setting this to <c>NULL</c> will cause a compile error if a shader
	/// contains a #include. You can pass the <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c> macro, which is a pointer to a default include
	/// handler. This default include handler includes files that are relative to the current directory and files that are relative to the
	/// directory of the initial source file. When you use <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c>, you must specify the source file name
	/// in the <c>pSourceName</c> parameter; the compiler will derive the initial relative directory from <c>pSourceName</c>.
	/// </para>
	/// </param>
	/// <param name="pEntrypoint">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>
	/// The name of the shader entry point function where shader execution begins. When you compile using a fx profile (for example, fx_4_0,
	/// fx_5_0, and so on), <c>D3DCompile</c> ignores <c>pEntrypoint</c>. In this case, we recommend that you set <c>pEntrypoint</c> to
	/// <c>NULL</c> because it is good programming practice to set a pointer parameter to <c>NULL</c> if the called function will not use
	/// it. For all other shader profiles, a valid <c>pEntrypoint</c> is required.
	/// </para>
	/// </param>
	/// <param name="pTarget">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>
	/// A string that specifies the shader target or set of shader features to compile against. The shader target can be shader model 2,
	/// shader model 3, shader model 4, or shader model 5. The target can also be an effect type (for example, fx_4_1). For info about the
	/// targets that various profiles support, see Specifying Compiler Targets.
	/// </para>
	/// </param>
	/// <param name="Flags1">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags defined by D3D compile constants.</para>
	/// </param>
	/// <param name="Flags2">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Flags defined by D3D compile effect constants. When you compile a shader and not an effect file, <c>D3DCompile</c> ignores
	/// <c>Flags2</c>; we recommend that you set <c>Flags2</c> to zero because it is good programming practice to set a nonpointer parameter
	/// to zero if the called function will not use it.
	/// </para>
	/// </param>
	/// <param name="ppCode">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the compiled code.</para>
	/// </param>
	/// <param name="ppErrorMsgs">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>
	/// A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error messages, or
	/// <c>NULL</c> if there are no errors.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>
	/// The difference between <c>D3DCompile</c> and D3DCompile2 is that the latter method takes some optional parameters that can be used
	/// to control some aspects of how bytecode is generated. If this extra flexibility is not required, there is no performance gain from
	/// using <c>D3DCompile2</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcompile HRESULT D3DCompile( [in] LPCVOID pSrcData,
	// [in] SIZE_T SrcDataSize, [in, optional] LPCSTR pSourceName, [in, optional] const D3D_SHADER_MACRO *pDefines, [in, optional]
	// ID3DInclude *pInclude, [in, optional] LPCSTR pEntrypoint, [in] LPCSTR pTarget, [in] UINT Flags1, [in] UINT Flags2, [out] ID3DBlob
	// **ppCode, [out, optional] ID3DBlob **ppErrorMsgs );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCompile")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DCompile([In] IntPtr pSrcData, [In] SizeT SrcDataSize,
		[In, Optional, MarshalAs(UnmanagedType.LPStr)] string? pSourceName, in D3D_SHADER_MACRO pDefines,
		[In, Optional] ID3DInclude? pInclude, [In, Optional, MarshalAs(UnmanagedType.LPStr)] string? pEntrypoint,
		[In, MarshalAs(UnmanagedType.LPStr)] string pTarget, D3DCOMPILE Flags1, [Optional] D3DCOMPILE_FLAGS2 Flags2, out ID3DBlob ppCode,
		out ID3DBlob ppErrorMsgs);

	/// <summary>Compiles Microsoft High Level Shader Language (HLSL) code into bytecode for a given target.</summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to uncompiled shader data (ASCII HLSL code).</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>The size, in bytes, of the block of memory that <c>pSrcData</c> points to.</para>
	/// </param>
	/// <param name="pSourceName">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>
	/// An optional pointer to a constant null-terminated string containing the name that identifies the source data to use in error
	/// messages. If not used, set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pDefines">
	/// <para>Type: <c>const D3D_SHADER_MACRO*</c></para>
	/// <para>
	/// An optional array of D3D_SHADER_MACRO structures that define shader macros. Each macro definition contains a name and a
	/// null-terminated definition. If not used, set to <c>NULL</c>. The last structure in the array serves as a terminator and must have
	/// all members set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pInclude">
	/// <para>Type: <c>ID3DInclude*</c></para>
	/// <para>
	/// A pointer to an ID3DInclude interface that the compiler uses to handle include files. If you set this parameter to <c>NULL</c> and
	/// the shader contains a #include, a compile error occurs. You can pass the <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c> macro, which is a
	/// pointer to a default include handler. This default include handler includes files that are relative to the current directory and
	/// files that are relative to the directory of the initial source file. When you use <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c>, you must
	/// specify the source file name in the <c>pSourceName</c> parameter; the compiler will derive the initial relative directory from <c>pSourceName</c>.
	/// </para>
	/// </param>
	/// <param name="pEntrypoint">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>
	/// A pointer to a constant null-terminated string that contains the name of the shader entry point function where shader execution
	/// begins. When you compile an effect, <c>D3DCompile2</c> ignores <c>pEntrypoint</c>; we recommend that you set <c>pEntrypoint</c> to
	/// <c>NULL</c> because it is good programming practice to set a pointer parameter to <c>NULL</c> if the called function will not use it.
	/// </para>
	/// </param>
	/// <param name="pTarget">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>
	/// A pointer to a constant null-terminated string that specifies the shader target or set of shader features to compile against. The
	/// shader target can be a shader model (for example, shader model 2, shader model 3, shader model 4, or shader model 5). The target can
	/// also be an effect type (for example, fx_4_1). For info about the targets that various profiles support, see Specifying Compiler Targets.
	/// </para>
	/// </param>
	/// <param name="Flags1">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// A combination of shader D3D compile constants that are combined by using a bitwise <c>OR</c> operation. The resulting value
	/// specifies how the compiler compiles the HLSL code.
	/// </para>
	/// </param>
	/// <param name="Flags2">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// A combination of effect D3D compile effect constants that are combined by using a bitwise <c>OR</c> operation. The resulting value
	/// specifies how the compiler compiles the effect. When you compile a shader and not an effect file, <c>D3DCompile2</c> ignores
	/// <c>Flags2</c>; we recommend that you set <c>Flags2</c> to zero because it is good programming practice to set a nonpointer parameter
	/// to zero if the called function will not use it.
	/// </para>
	/// </param>
	/// <param name="SecondaryDataFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// A combination of the following flags that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how the
	/// compiler compiles the HLSL code.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Flag</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>D3DCOMPILE_SECDATA_MERGE_UAV_SLOTS (0x01)</description>
	/// <description>
	/// Merge unordered access view (UAV) slots in the secondary data that the <c>pSecondaryData</c> parameter points to.
	/// </description>
	/// </item>
	/// <item>
	/// <description>D3DCOMPILE_SECDATA_PRESERVE_TEMPLATE_SLOTS (0x02)</description>
	/// <description>Preserve template slots in the secondary data that the <c>pSecondaryData</c> parameter points to.</description>
	/// </item>
	/// <item>
	/// <description>D3DCOMPILE_SECDATA_REQUIRE_TEMPLATE_MATCH (0x04)</description>
	/// <description>
	/// Require that templates in the secondary data that the <c>pSecondaryData</c> parameter points to match when the compiler compiles the
	/// HLSL code.
	/// </description>
	/// </item>
	/// </list>
	/// <para>If <c>pSecondaryData</c> is <c>NULL</c>, set to zero.</para>
	/// </param>
	/// <param name="pSecondaryData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>
	/// A pointer to secondary data. If you don't pass secondary data, set to <c>NULL</c>. Use this secondary data to align UAV slots in two
	/// shaders. Suppose shader A has UAVs and they are bound to some slots. To compile shader B such that UAVs with the same names are
	/// mapped in B to the same slots as in A, pass A’s byte code to <c>D3DCompile2</c> as the secondary data.
	/// </para>
	/// </param>
	/// <param name="SecondaryDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>
	/// The size, in bytes, of the block of memory that <c>pSecondaryData</c> points to. If <c>pSecondaryData</c> is <c>NULL</c>, set to zero.
	/// </para>
	/// </param>
	/// <param name="ppCode">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the compiled code.</para>
	/// </param>
	/// <param name="ppErrorMsgs">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>
	/// A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error messages, or
	/// <c>NULL</c> if there are no errors.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The difference between <c>D3DCompile2</c> and D3DCompile is that <c>D3DCompile2</c> takes some optional parameters (
	/// <c>SecondaryDataFlags</c>, <c>pSecondaryData</c> and <c>SecondaryDataSize</c>) that can be used to control some aspects of how
	/// bytecode is generated. Refer to the descriptions of these parameters for more details. There is no difference otherwise to the
	/// efficiency of the bytecode generated between <c>D3DCompile2</c> and <c>D3DCompile</c>.
	/// </para>
	/// <h2>Compiling shaders for UWP</h2>
	/// <para>
	/// To compile offline shaders the recommended approach is to use the Effect-compiler tool. If you can't compile all of your shaders
	/// ahead of time, then consider compiling the more expensive ones and the ones that your startup and most performance-sensitive paths
	/// require, and compiling the rest at runtime. You can use a process similar to the following to compile a loaded or generated shader
	/// in a UWP application without blocking your user interface thread.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>Using Visual Studio 2015+ to develop the UWP app, add the new item "shader.hlsl".</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>Now add these includes to your .cpp file:</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// Use the following code to call <c>D3DCompile2</c>. Note that there's no error checking or handling here, and also that this code
	/// demonstrates that you can do both I/O and compilation in the background, which leaves your UI more responsive.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcompile2 HRESULT D3DCompile2( [in] LPCVOID
	// pSrcData, [in] SIZE_T SrcDataSize, [in, optional] LPCSTR pSourceName, [in, optional] const D3D_SHADER_MACRO *pDefines, [in, optional]
	// ID3DInclude *pInclude, [in] LPCSTR pEntrypoint, [in] LPCSTR pTarget, [in] UINT Flags1, [in] UINT Flags2, [in] UINT
	// SecondaryDataFlags, [in, optional] LPCVOID pSecondaryData, [in] SIZE_T SecondaryDataSize, [out] ID3DBlob **ppCode, [out, optional]
	// ID3DBlob **ppErrorMsgs );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCompile2")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DCompile2([In] IntPtr pSrcData, [In] SizeT SrcDataSize,
		[Optional, MarshalAs(UnmanagedType.LPStr)] string? pSourceName, [In, Optional] IntPtr pDefines, [In, Optional] ID3DInclude? pInclude,
		[MarshalAs(UnmanagedType.LPStr)] string pEntrypoint, [MarshalAs(UnmanagedType.LPStr)] string pTarget, D3DCOMPILE Flags1,
		[Optional] D3DCOMPILE_FLAGS2 Flags2, D3DCOMPILE_SECDATA SecondaryDataFlags, [In, Optional] IntPtr pSecondaryData,
		[In] SizeT SecondaryDataSize, out ID3DBlob ppCode, [Out, Optional] IntPtr ppErrorMsgs);

	/// <summary>Compiles Microsoft High Level Shader Language (HLSL) code into bytecode for a given target.</summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to uncompiled shader data (ASCII HLSL code).</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>The size, in bytes, of the block of memory that <c>pSrcData</c> points to.</para>
	/// </param>
	/// <param name="pSourceName">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>
	/// An optional pointer to a constant null-terminated string containing the name that identifies the source data to use in error
	/// messages. If not used, set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pDefines">
	/// <para>Type: <c>const D3D_SHADER_MACRO*</c></para>
	/// <para>
	/// An optional array of D3D_SHADER_MACRO structures that define shader macros. Each macro definition contains a name and a
	/// null-terminated definition. If not used, set to <c>NULL</c>. The last structure in the array serves as a terminator and must have
	/// all members set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pInclude">
	/// <para>Type: <c>ID3DInclude*</c></para>
	/// <para>
	/// A pointer to an ID3DInclude interface that the compiler uses to handle include files. If you set this parameter to <c>NULL</c> and
	/// the shader contains a #include, a compile error occurs. You can pass the <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c> macro, which is a
	/// pointer to a default include handler. This default include handler includes files that are relative to the current directory and
	/// files that are relative to the directory of the initial source file. When you use <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c>, you must
	/// specify the source file name in the <c>pSourceName</c> parameter; the compiler will derive the initial relative directory from <c>pSourceName</c>.
	/// </para>
	/// </param>
	/// <param name="pEntrypoint">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>
	/// A pointer to a constant null-terminated string that contains the name of the shader entry point function where shader execution
	/// begins. When you compile an effect, <c>D3DCompile2</c> ignores <c>pEntrypoint</c>; we recommend that you set <c>pEntrypoint</c> to
	/// <c>NULL</c> because it is good programming practice to set a pointer parameter to <c>NULL</c> if the called function will not use it.
	/// </para>
	/// </param>
	/// <param name="pTarget">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>
	/// A pointer to a constant null-terminated string that specifies the shader target or set of shader features to compile against. The
	/// shader target can be a shader model (for example, shader model 2, shader model 3, shader model 4, or shader model 5). The target can
	/// also be an effect type (for example, fx_4_1). For info about the targets that various profiles support, see Specifying Compiler Targets.
	/// </para>
	/// </param>
	/// <param name="Flags1">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// A combination of shader D3D compile constants that are combined by using a bitwise <c>OR</c> operation. The resulting value
	/// specifies how the compiler compiles the HLSL code.
	/// </para>
	/// </param>
	/// <param name="Flags2">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// A combination of effect D3D compile effect constants that are combined by using a bitwise <c>OR</c> operation. The resulting value
	/// specifies how the compiler compiles the effect. When you compile a shader and not an effect file, <c>D3DCompile2</c> ignores
	/// <c>Flags2</c>; we recommend that you set <c>Flags2</c> to zero because it is good programming practice to set a nonpointer parameter
	/// to zero if the called function will not use it.
	/// </para>
	/// </param>
	/// <param name="SecondaryDataFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// A combination of the following flags that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how the
	/// compiler compiles the HLSL code.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Flag</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>D3DCOMPILE_SECDATA_MERGE_UAV_SLOTS (0x01)</description>
	/// <description>
	/// Merge unordered access view (UAV) slots in the secondary data that the <c>pSecondaryData</c> parameter points to.
	/// </description>
	/// </item>
	/// <item>
	/// <description>D3DCOMPILE_SECDATA_PRESERVE_TEMPLATE_SLOTS (0x02)</description>
	/// <description>Preserve template slots in the secondary data that the <c>pSecondaryData</c> parameter points to.</description>
	/// </item>
	/// <item>
	/// <description>D3DCOMPILE_SECDATA_REQUIRE_TEMPLATE_MATCH (0x04)</description>
	/// <description>
	/// Require that templates in the secondary data that the <c>pSecondaryData</c> parameter points to match when the compiler compiles the
	/// HLSL code.
	/// </description>
	/// </item>
	/// </list>
	/// <para>If <c>pSecondaryData</c> is <c>NULL</c>, set to zero.</para>
	/// </param>
	/// <param name="pSecondaryData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>
	/// A pointer to secondary data. If you don't pass secondary data, set to <c>NULL</c>. Use this secondary data to align UAV slots in two
	/// shaders. Suppose shader A has UAVs and they are bound to some slots. To compile shader B such that UAVs with the same names are
	/// mapped in B to the same slots as in A, pass A’s byte code to <c>D3DCompile2</c> as the secondary data.
	/// </para>
	/// </param>
	/// <param name="SecondaryDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>
	/// The size, in bytes, of the block of memory that <c>pSecondaryData</c> points to. If <c>pSecondaryData</c> is <c>NULL</c>, set to zero.
	/// </para>
	/// </param>
	/// <param name="ppCode">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the compiled code.</para>
	/// </param>
	/// <param name="ppErrorMsgs">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>
	/// A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error messages, or
	/// <c>NULL</c> if there are no errors.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The difference between <c>D3DCompile2</c> and D3DCompile is that <c>D3DCompile2</c> takes some optional parameters (
	/// <c>SecondaryDataFlags</c>, <c>pSecondaryData</c> and <c>SecondaryDataSize</c>) that can be used to control some aspects of how
	/// bytecode is generated. Refer to the descriptions of these parameters for more details. There is no difference otherwise to the
	/// efficiency of the bytecode generated between <c>D3DCompile2</c> and <c>D3DCompile</c>.
	/// </para>
	/// <h2>Compiling shaders for UWP</h2>
	/// <para>
	/// To compile offline shaders the recommended approach is to use the Effect-compiler tool. If you can't compile all of your shaders
	/// ahead of time, then consider compiling the more expensive ones and the ones that your startup and most performance-sensitive paths
	/// require, and compiling the rest at runtime. You can use a process similar to the following to compile a loaded or generated shader
	/// in a UWP application without blocking your user interface thread.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// <para>Using Visual Studio 2015+ to develop the UWP app, add the new item "shader.hlsl".</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>Now add these includes to your .cpp file:</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// Use the following code to call <c>D3DCompile2</c>. Note that there's no error checking or handling here, and also that this code
	/// demonstrates that you can do both I/O and compilation in the background, which leaves your UI more responsive.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcompile2 HRESULT D3DCompile2( [in] LPCVOID
	// pSrcData, [in] SIZE_T SrcDataSize, [in, optional] LPCSTR pSourceName, [in, optional] const D3D_SHADER_MACRO *pDefines, [in, optional]
	// ID3DInclude *pInclude, [in] LPCSTR pEntrypoint, [in] LPCSTR pTarget, [in] UINT Flags1, [in] UINT Flags2, [in] UINT
	// SecondaryDataFlags, [in, optional] LPCVOID pSecondaryData, [in] SIZE_T SecondaryDataSize, [out] ID3DBlob **ppCode, [out, optional]
	// ID3DBlob **ppErrorMsgs );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCompile2")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DCompile2([In] IntPtr pSrcData, [In] SizeT SrcDataSize,
		[Optional, MarshalAs(UnmanagedType.LPStr)] string? pSourceName, in D3D_SHADER_MACRO pDefines, [In, Optional] ID3DInclude? pInclude,
		[MarshalAs(UnmanagedType.LPStr)] string pEntrypoint, [MarshalAs(UnmanagedType.LPStr)] string pTarget, D3DCOMPILE Flags1,
		[Optional] D3DCOMPILE_FLAGS2 Flags2, D3DCOMPILE_SECDATA SecondaryDataFlags, [In, Optional] IntPtr pSecondaryData,
		[In] SizeT SecondaryDataSize, out ID3DBlob ppCode, out ID3DBlob ppErrorMsgs);

	/// <summary>
	/// <para>A pointer to a constant null-terminated string that contains the name of the file that contains the shader code.</para>
	/// <para>
	/// An optional array of D3D_SHADER_MACRO structures that define shader macros. Each macro definition contains a name and a
	/// null-terminated definition. If not used, set to <c>NULL</c>. The last structure in the array serves as a terminator and must have
	/// all members set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// An optional pointer to an ID3DInclude interface that the compiler uses to handle include files. If you set this parameter to
	/// <c>NULL</c> and the shader contains a #include, a compile error occurs. You can pass the <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c>
	/// macro, which is a pointer to a default include handler. This default include handler includes files that are relative to the current directory.
	/// </para>
	/// <para>
	/// A pointer to a constant null-terminated string that contains the name of the shader entry point function where shader execution
	/// begins. When you compile an effect, <c>D3DCompileFromFile</c> ignores <c>pEntrypoint</c>; we recommend that you set
	/// <c>pEntrypoint</c> to <c>NULL</c> because it is good programming practice to set a pointer parameter to <c>NULL</c> if the called
	/// function will not use it.
	/// </para>
	/// <para>
	/// A pointer to a constant null-terminated string that specifies the shader target or set of shader features to compile against. The
	/// shader target can be a shader model (for example, shader model 2, shader model 3, shader model 4, or shader model 5 and later). The
	/// target can also be an effect type (for example, fx_4_1). For info about the targets that various profiles support, see Specifying
	/// Compiler Targets.
	/// </para>
	/// <para>
	/// A combination of shader compile options that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how
	/// the compiler compiles the HLSL code.
	/// </para>
	/// <para>
	/// A combination of effect compile options that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how
	/// the compiler compiles the effect. When you compile a shader and not an effect file, <c>D3DCompileFromFile</c> ignores <c>Flags2</c>;
	/// we recommend that you set <c>Flags2</c> to zero because it is good programming practice to set a nonpointer parameter to zero if the
	/// called function will not use it.
	/// </para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the compiled code.</para>
	/// <para>
	/// An optional pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error
	/// messages, or <c>NULL</c> if there are no errors.
	/// </para>
	/// </summary>
	/// <param name="pFileName">
	/// A pointer to a constant null-terminated string that contains the name of the file that contains the shader code.
	/// </param>
	/// <param name="pDefines">
	/// An optional array of D3D_SHADER_MACRO structures that define shader macros. Each macro definition contains a name and a
	/// null-terminated definition. If not used, set to <c>NULL</c>. The last structure in the array serves as a terminator and must have
	/// all members set to <c>NULL</c>.
	/// </param>
	/// <param name="pInclude">
	/// An optional pointer to an ID3DInclude interface that the compiler uses to handle include files. If you set this parameter to
	/// <c>NULL</c> and the shader contains a #include, a compile error occurs. You can pass the <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c>
	/// macro, which is a pointer to a default include handler. This default include handler includes files that are relative to the current directory.
	/// </param>
	/// <param name="pEntrypoint">
	/// A pointer to a constant null-terminated string that contains the name of the shader entry point function where shader execution
	/// begins. When you compile an effect, <c>D3DCompileFromFile</c> ignores <c>pEntrypoint</c>; we recommend that you set
	/// <c>pEntrypoint</c> to <c>NULL</c> because it is good programming practice to set a pointer parameter to <c>NULL</c> if the called
	/// function will not use it.
	/// </param>
	/// <param name="pTarget">
	/// A pointer to a constant null-terminated string that specifies the shader target or set of shader features to compile against. The
	/// shader target can be a shader model (for example, shader model 2, shader model 3, shader model 4, or shader model 5 and later). The
	/// target can also be an effect type (for example, fx_4_1). For info about the targets that various profiles support, see Specifying
	/// Compiler Targets.
	/// </param>
	/// <param name="Flags1">
	/// A combination of shader compile options that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how
	/// the compiler compiles the HLSL code.
	/// </param>
	/// <param name="Flags2">
	/// A combination of effect compile options that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how
	/// the compiler compiles the effect. When you compile a shader and not an effect file, <c>D3DCompileFromFile</c> ignores <c>Flags2</c>;
	/// we recommend that you set <c>Flags2</c> to zero because it is good programming practice to set a nonpointer parameter to zero if the
	/// called function will not use it.
	/// </param>
	/// <param name="ppCode">
	/// A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the compiled code.
	/// </param>
	/// <param name="ppErrorMsgs">
	/// An optional pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error
	/// messages, or <c>NULL</c> if there are no errors.
	/// </param>
	/// <returns>Returns one of the Direct3D 11 return codes.</returns>
	/// <remarks>
	/// <para><c>Note</c>  The D3dcompiler_44.dll or later version of the file contains the <c>D3DCompileFromFile</c> compiler function.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcompilefromfile HRESULT D3DCompileFromFile( [in]
	// LPCWSTR pFileName, [in, optional] const D3D_SHADER_MACRO *pDefines, [in, optional] ID3DInclude *pInclude, [in] LPCSTR pEntrypoint,
	// [in] LPCSTR pTarget, [in] UINT Flags1, [in] UINT Flags2, [out] ID3DBlob **ppCode, [out, optional] ID3DBlob **ppErrorMsgs );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCompileFromFile")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DCompileFromFile([MarshalAs(UnmanagedType.LPWStr)] string pFileName, [In, Optional] IntPtr pDefines,
		[In, Optional] ID3DInclude? pInclude, [MarshalAs(UnmanagedType.LPStr)] string pEntrypoint, [MarshalAs(UnmanagedType.LPStr)] string pTarget,
		D3DCOMPILE Flags1, [Optional] D3DCOMPILE_FLAGS2 Flags2, out ID3DBlob ppCode, [Out, Optional] IntPtr ppErrorMsgs);

	/// <summary>
	/// <para>A pointer to a constant null-terminated string that contains the name of the file that contains the shader code.</para>
	/// <para>
	/// An optional array of D3D_SHADER_MACRO structures that define shader macros. Each macro definition contains a name and a
	/// null-terminated definition. If not used, set to <c>NULL</c>. The last structure in the array serves as a terminator and must have
	/// all members set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// An optional pointer to an ID3DInclude interface that the compiler uses to handle include files. If you set this parameter to
	/// <c>NULL</c> and the shader contains a #include, a compile error occurs. You can pass the <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c>
	/// macro, which is a pointer to a default include handler. This default include handler includes files that are relative to the current directory.
	/// </para>
	/// <para>
	/// A pointer to a constant null-terminated string that contains the name of the shader entry point function where shader execution
	/// begins. When you compile an effect, <c>D3DCompileFromFile</c> ignores <c>pEntrypoint</c>; we recommend that you set
	/// <c>pEntrypoint</c> to <c>NULL</c> because it is good programming practice to set a pointer parameter to <c>NULL</c> if the called
	/// function will not use it.
	/// </para>
	/// <para>
	/// A pointer to a constant null-terminated string that specifies the shader target or set of shader features to compile against. The
	/// shader target can be a shader model (for example, shader model 2, shader model 3, shader model 4, or shader model 5 and later). The
	/// target can also be an effect type (for example, fx_4_1). For info about the targets that various profiles support, see Specifying
	/// Compiler Targets.
	/// </para>
	/// <para>
	/// A combination of shader compile options that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how
	/// the compiler compiles the HLSL code.
	/// </para>
	/// <para>
	/// A combination of effect compile options that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how
	/// the compiler compiles the effect. When you compile a shader and not an effect file, <c>D3DCompileFromFile</c> ignores <c>Flags2</c>;
	/// we recommend that you set <c>Flags2</c> to zero because it is good programming practice to set a nonpointer parameter to zero if the
	/// called function will not use it.
	/// </para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the compiled code.</para>
	/// <para>
	/// An optional pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error
	/// messages, or <c>NULL</c> if there are no errors.
	/// </para>
	/// </summary>
	/// <param name="pFileName">
	/// A pointer to a constant null-terminated string that contains the name of the file that contains the shader code.
	/// </param>
	/// <param name="pDefines">
	/// An optional array of D3D_SHADER_MACRO structures that define shader macros. Each macro definition contains a name and a
	/// null-terminated definition. If not used, set to <c>NULL</c>. The last structure in the array serves as a terminator and must have
	/// all members set to <c>NULL</c>.
	/// </param>
	/// <param name="pInclude">
	/// An optional pointer to an ID3DInclude interface that the compiler uses to handle include files. If you set this parameter to
	/// <c>NULL</c> and the shader contains a #include, a compile error occurs. You can pass the <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c>
	/// macro, which is a pointer to a default include handler. This default include handler includes files that are relative to the current directory.
	/// </param>
	/// <param name="pEntrypoint">
	/// A pointer to a constant null-terminated string that contains the name of the shader entry point function where shader execution
	/// begins. When you compile an effect, <c>D3DCompileFromFile</c> ignores <c>pEntrypoint</c>; we recommend that you set
	/// <c>pEntrypoint</c> to <c>NULL</c> because it is good programming practice to set a pointer parameter to <c>NULL</c> if the called
	/// function will not use it.
	/// </param>
	/// <param name="pTarget">
	/// A pointer to a constant null-terminated string that specifies the shader target or set of shader features to compile against. The
	/// shader target can be a shader model (for example, shader model 2, shader model 3, shader model 4, or shader model 5 and later). The
	/// target can also be an effect type (for example, fx_4_1). For info about the targets that various profiles support, see Specifying
	/// Compiler Targets.
	/// </param>
	/// <param name="Flags1">
	/// A combination of shader compile options that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how
	/// the compiler compiles the HLSL code.
	/// </param>
	/// <param name="Flags2">
	/// A combination of effect compile options that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how
	/// the compiler compiles the effect. When you compile a shader and not an effect file, <c>D3DCompileFromFile</c> ignores <c>Flags2</c>;
	/// we recommend that you set <c>Flags2</c> to zero because it is good programming practice to set a nonpointer parameter to zero if the
	/// called function will not use it.
	/// </param>
	/// <param name="ppCode">
	/// A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the compiled code.
	/// </param>
	/// <param name="ppErrorMsgs">
	/// An optional pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access compiler error
	/// messages, or <c>NULL</c> if there are no errors.
	/// </param>
	/// <returns>Returns one of the Direct3D 11 return codes.</returns>
	/// <remarks>
	/// <para><c>Note</c>  The D3dcompiler_44.dll or later version of the file contains the <c>D3DCompileFromFile</c> compiler function.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcompilefromfile HRESULT D3DCompileFromFile( [in]
	// LPCWSTR pFileName, [in, optional] const D3D_SHADER_MACRO *pDefines, [in, optional] ID3DInclude *pInclude, [in] LPCSTR pEntrypoint,
	// [in] LPCSTR pTarget, [in] UINT Flags1, [in] UINT Flags2, [out] ID3DBlob **ppCode, [out, optional] ID3DBlob **ppErrorMsgs );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCompileFromFile")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DCompileFromFile([MarshalAs(UnmanagedType.LPWStr)] string pFileName, in D3D_SHADER_MACRO pDefines,
		[In, Optional] ID3DInclude? pInclude, [MarshalAs(UnmanagedType.LPStr)] string pEntrypoint, [MarshalAs(UnmanagedType.LPStr)] string pTarget,
		D3DCOMPILE Flags1, [Optional] D3DCOMPILE_FLAGS2 Flags2, out ID3DBlob ppCode, out ID3DBlob ppErrorMsgs);

	/// <summary>
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of shaders to compress.</para>
	/// <para>Type: D3D_SHADER_DATA*</para>
	/// <para>An array of D3D_SHADER_DATA structures that describe the set of shaders to compress.</para>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Flags that indicate how to compress the shaders. Currently, only the D3D_COMPRESS_SHADER_KEEP_ALL_PARTS (0x00000001) flag is defined.
	/// </para>
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>The address of a pointer to the ID3DBlob interface that is used to retrieve the compressed shader data.</para>
	/// </summary>
	/// <param name="uNumShaders">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of shaders to compress.</para>
	/// </param>
	/// <param name="pShaderData">
	/// <para>Type: D3D_SHADER_DATA*</para>
	/// <para>An array of D3D_SHADER_DATA structures that describe the set of shaders to compress.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Flags that indicate how to compress the shaders. Currently, only the D3D_COMPRESS_SHADER_KEEP_ALL_PARTS (0x00000001) flag is defined.
	/// </para>
	/// </param>
	/// <param name="ppCompressedData">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>The address of a pointer to the ID3DBlob interface that is used to retrieve the compressed shader data.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcompressshaders HRESULT D3DCompressShaders( [in]
	// UINT uNumShaders, [in] D3D_SHADER_DATA *pShaderData, [in] UINT uFlags, [out] ID3DBlob **ppCompressedData );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCompressShaders")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DCompressShaders(uint uNumShaders, in D3D_SHADER_DATA pShaderData, D3D_COMPRESS_SHADER uFlags,
		out ID3DBlob[] ppCompressedData);

	/// <summary>Creates a buffer.</summary>
	/// <param name="Size">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Number of bytes in the blob.</para>
	/// </param>
	/// <param name="ppBlob">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>The address of a pointer to the ID3DBlob interface that is used to retrieve the buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>
	/// The latest D3dcompiler_nn.dll contains the <c>D3DCreateBlob</c> compiler function. Therefore, you are no longer required to create
	/// and use an arbitrary length data buffer by using the D3D10CreateBlob function that is contained in D3d10.dll.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcreateblob HRESULT D3DCreateBlob( [in] SIZE_T Size,
	// [out] ID3DBlob **ppBlob );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCreateBlob")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DCreateBlob([In] SizeT Size, out ID3DBlob ppBlob);

	/// <summary>
	/// <para>Creates a function-linking-graph interface.</para>
	/// <para>
	/// <c>Note</c>  This function is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.
	/// <para></para>
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Reserved</para>
	/// </param>
	/// <param name="ppFunctionLinkingGraph">
	/// <para>Type: <c>ID3D11FunctionLinkingGraph**</c></para>
	/// <para>
	/// A pointer to a variable that receives a pointer to the ID3D11FunctionLinkingGraph interface that is used for constructing shaders
	/// that consist of a sequence of precompiled function calls.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para><c>Note</c>  The D3dcompiler_47.dll or later version of the DLL contains the <c>D3DCreateFunctionLinkingGraph</c> function.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcreatefunctionlinkinggraph HRESULT
	// D3DCreateFunctionLinkingGraph( [in] UINT uFlags, [out] ID3D11FunctionLinkingGraph **ppFunctionLinkingGraph );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCreateFunctionLinkingGraph")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DCreateFunctionLinkingGraph([Optional] uint uFlags, out ID3D11FunctionLinkingGraph ppFunctionLinkingGraph);

	/// <summary>
	/// <para>Creates a linker interface.</para>
	/// <para>
	/// <c>Note</c>  This function is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.
	/// <para></para>
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="ppLinker">
	/// <para>Type: <c>ID3D11Linker**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3D11Linker interface that is used to link a shader module.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para><c>Note</c>  The D3dcompiler_47.dll or later version of the DLL contains the <c>D3DCreateLinker</c> function.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcreatelinker HRESULT D3DCreateLinker( [out]
	// ID3D11Linker **ppLinker );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DCreateLinker")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DCreateLinker(out ID3D11Linker ppLinker);

	/// <summary>
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to uncompiled shader data; either ASCII HLSL code or a compiled effect.</para>
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of uncompiled shader data that <c>pSrcData</c> points to.</para>
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of shaders to decompress.</para>
	/// <para>Type: <c>UINT</c></para>
	/// <para>The index of the first shader to decompress.</para>
	/// <para>Type: <c>UINT*</c></para>
	/// <para>An array of indexes that represent the shaders to decompress.</para>
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that indicate how to decompress. Currently, no flags are defined.</para>
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>The address of a pointer to the ID3DBlob interface that is used to retrieve the decompressed shader data.</para>
	/// <para>Type: <c>UINT*</c></para>
	/// <para>A pointer to a variable that receives the total number of shaders that <c>D3DDecompressShaders</c> decompressed.</para>
	/// </summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to uncompiled shader data; either ASCII HLSL code or a compiled effect.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of uncompiled shader data that <c>pSrcData</c> points to.</para>
	/// </param>
	/// <param name="uNumShaders">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of shaders to decompress.</para>
	/// </param>
	/// <param name="uStartIndex">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The index of the first shader to decompress.</para>
	/// </param>
	/// <param name="pIndices">
	/// <para>Type: <c>UINT*</c></para>
	/// <para>An array of indexes that represent the shaders to decompress.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that indicate how to decompress. Currently, no flags are defined.</para>
	/// </param>
	/// <param name="ppShaders">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>The address of a pointer to the ID3DBlob interface that is used to retrieve the decompressed shader data.</para>
	/// </param>
	/// <param name="pTotalShaders">
	/// <para>Type: <c>UINT*</c></para>
	/// <para>A pointer to a variable that receives the total number of shaders that <c>D3DDecompressShaders</c> decompressed.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3ddecompressshaders HRESULT D3DDecompressShaders(
	// [in] LPCVOID pSrcData, [in] SIZE_T SrcDataSize, [in] UINT uNumShaders, [in] UINT uStartIndex, [in, optional] UINT *pIndices, [in]
	// UINT uFlags, [out] ID3DBlob **ppShaders, [out, optional] UINT *pTotalShaders );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DDecompressShaders")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DDecompressShaders([In] IntPtr pSrcData, [In] SizeT SrcDataSize, uint uNumShaders, uint uStartIndex,
		[In, Optional, MarshalAs(UnmanagedType.LPArray)] uint[]? pIndices, [Optional] uint uFlags, out ID3DBlob ppShaders, out uint pTotalShaders);

	/// <summary>Disassembles compiled HLSL code.</summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data as compiled HLSL code.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// Flags affecting the behavior of <c>D3DDisassemble</c>. <c>Flags</c> can be a combination of zero or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Flag</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>D3D_DISASM_ENABLE_COLOR_CODE</c></description>
	/// <description>Enable the output of color codes.</description>
	/// </item>
	/// <item>
	/// <description><c>D3D_DISASM_ENABLE_DEFAULT_VALUE_PRINTS</c></description>
	/// <description>Enable the output of default values.</description>
	/// </item>
	/// <item>
	/// <description><c>D3D_DISASM_ENABLE_INSTRUCTION_NUMBERING</c></description>
	/// <description>Enable instruction numbering.</description>
	/// </item>
	/// <item>
	/// <description><c>D3D_DISASM_ENABLE_INSTRUCTION_CYCLE</c></description>
	/// <description>No effect.</description>
	/// </item>
	/// <item>
	/// <description><c>D3D_DISASM_DISABLE_DEBUG_INFO</c></description>
	/// <description>Disable debug information.</description>
	/// </item>
	/// <item>
	/// <description><c>D3D_DISASM_ENABLE_INSTRUCTION_OFFSET</c></description>
	/// <description>Enable instruction offsets.</description>
	/// </item>
	/// <item>
	/// <description><c>D3D_DISASM_INSTRUCTION_ONLY</c></description>
	/// <description>Disassemble instructions only.</description>
	/// </item>
	/// <item>
	/// <description><c>D3D_DISASM_PRINT_HEX_LITERALS</c></description>
	/// <description>Use hex symbols in disassemblies.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szComments">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>The comment string at the top of the shader that identifies the shader constants and variables.</para>
	/// </param>
	/// <param name="ppDisassembly">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that accesses assembly text.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3ddisassemble HRESULT D3DDisassemble( [in] LPCVOID
	// pSrcData, [in] SIZE_T SrcDataSize, [in] UINT Flags, [in, optional] LPCSTR szComments, [out] ID3DBlob **ppDisassembly );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DDisassemble")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DDisassemble([In] IntPtr pSrcData, [In] SizeT SrcDataSize, D3D_DISASM Flags,
		[Optional, MarshalAs(UnmanagedType.LPStr)] string? szComments, out ID3DBlob ppDisassembly);

	/// <summary>Disassembles compiled HLSL code from a Direct3D10 effect.</summary>
	/// <param name="pEffect">
	/// <para>Type: <c>ID3D10Effect*</c></para>
	/// <para>A pointer to source data as compiled HLSL code.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Shader compile options.</para>
	/// </param>
	/// <param name="ppDisassembly">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that contains disassembly text.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3ddisassemble10effect HRESULT D3DDisassemble10Effect(
	// [in] ID3D10Effect *pEffect, [in] UINT Flags, [out] ID3DBlob **ppDisassembly );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DDisassemble10Effect")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DDisassemble10Effect([In, MarshalAs(UnmanagedType.Interface)] object pEffect, uint Flags, out ID3DBlob ppDisassembly);

	/// <summary>Disassembles a specific region of compiled Microsoft High Level Shader Language (HLSL) code.</summary>
	/// <param name="pSrcData">A pointer to compiled shader data.</param>
	/// <param name="SrcDataSize">The size, in bytes, of the block of memory that <c>pSrcData</c> points to.</param>
	/// <param name="Flags">
	/// <para>
	/// A combination of zero or more of the following flags that are combined by using a bitwise <c>OR</c> operation. The resulting value
	/// specifies how <c>D3DDisassembleRegion</c> disassembles the compiled shader data.
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
	/// This flag has no effect in <c>D3DDisassembleRegion</c>. Cycle information comes from the trace; therefore, cycle information is
	/// available only in D3DDisassemble11Trace's trace disassembly.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szComments">
	/// A pointer to a constant null-terminated string at the top of the shader that identifies the shader constants and variables.
	/// </param>
	/// <param name="StartByteOffset">
	/// The number of bytes offset into the compiled shader data where <c>D3DDisassembleRegion</c> starts the disassembly.
	/// </param>
	/// <param name="NumInsts">The number of instructions to disassemble.</param>
	/// <param name="pFinishByteOffset">
	/// A pointer to a variable that receives the number of bytes offset into the compiled shader data where <c>D3DDisassembleRegion</c>
	/// finishes the disassembly.
	/// </param>
	/// <param name="ppDisassembly">A pointer to a buffer that receives the ID3DBlob interface that accesses the disassembled HLSL code.</param>
	/// <returns>Returns one of the Direct3D 11 return codes.</returns>
	/// <remarks>
	/// <para><c>Note</c>  The D3dcompiler_44.dll or later version of the file contains the <c>D3DDisassembleRegion</c> compiler function.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3ddisassembleregion HRESULT D3DDisassembleRegion(
	// [in] LPCVOID pSrcData, [in] SIZE_T SrcDataSize, [in] UINT Flags, [in, optional] LPCSTR szComments, [in] SIZE_T StartByteOffset, [in]
	// SIZE_T NumInsts, [out, optional] SIZE_T *pFinishByteOffset, [out] ID3DBlob **ppDisassembly );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DDisassembleRegion")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DDisassembleRegion([In] IntPtr pSrcData, [In] SizeT SrcDataSize, D3D_DISASM Flags,
		[Optional, MarshalAs(UnmanagedType.LPStr)] string? szComments, [In] SizeT StartByteOffset, [In] SizeT NumInsts,
		out SizeT pFinishByteOffset, out ID3DBlob ppDisassembly);

	/// <summary>Disassembles a specific region of compiled Microsoft High Level Shader Language (HLSL) code.</summary>
	/// <param name="pSrcData">A pointer to compiled shader data.</param>
	/// <param name="SrcDataSize">The size, in bytes, of the block of memory that <c>pSrcData</c> points to.</param>
	/// <param name="Flags">
	/// <para>
	/// A combination of zero or more of the following flags that are combined by using a bitwise <c>OR</c> operation. The resulting value
	/// specifies how <c>D3DDisassembleRegion</c> disassembles the compiled shader data.
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
	/// This flag has no effect in <c>D3DDisassembleRegion</c>. Cycle information comes from the trace; therefore, cycle information is
	/// available only in D3DDisassemble11Trace's trace disassembly.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szComments">
	/// A pointer to a constant null-terminated string at the top of the shader that identifies the shader constants and variables.
	/// </param>
	/// <param name="StartByteOffset">
	/// The number of bytes offset into the compiled shader data where <c>D3DDisassembleRegion</c> starts the disassembly.
	/// </param>
	/// <param name="NumInsts">The number of instructions to disassemble.</param>
	/// <param name="pFinishByteOffset">
	/// A pointer to a variable that receives the number of bytes offset into the compiled shader data where <c>D3DDisassembleRegion</c>
	/// finishes the disassembly.
	/// </param>
	/// <param name="ppDisassembly">A pointer to a buffer that receives the ID3DBlob interface that accesses the disassembled HLSL code.</param>
	/// <returns>Returns one of the Direct3D 11 return codes.</returns>
	/// <remarks>
	/// <para><c>Note</c>  The D3dcompiler_44.dll or later version of the file contains the <c>D3DDisassembleRegion</c> compiler function.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3ddisassembleregion HRESULT D3DDisassembleRegion(
	// [in] LPCVOID pSrcData, [in] SIZE_T SrcDataSize, [in] UINT Flags, [in, optional] LPCSTR szComments, [in] SIZE_T StartByteOffset, [in]
	// SIZE_T NumInsts, [out, optional] SIZE_T *pFinishByteOffset, [out] ID3DBlob **ppDisassembly );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DDisassembleRegion")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DDisassembleRegion([In] IntPtr pSrcData, [In] SizeT SrcDataSize, D3D_DISASM Flags,
		[Optional, MarshalAs(UnmanagedType.LPStr)] string? szComments, [In] SizeT StartByteOffset, [In] SizeT NumInsts,
		[Out, Optional] IntPtr pFinishByteOffset, out ID3DBlob ppDisassembly);

	/// <summary>Retrieves a specific part from a compilation result.</summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to uncompiled shader data; either ASCII HLSL code or a compiled effect.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of uncompiled shader data that <c>pSrcData</c> points to.</para>
	/// </param>
	/// <param name="Part">
	/// <para>Type: <c>D3D_BLOB_PART</c></para>
	/// <para>A D3D_BLOB_PART-typed value that specifies the part of the buffer to retrieve.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that indicate how to retrieve the blob part. Currently, no flags are defined.</para>
	/// </param>
	/// <param name="ppPart">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>The address of a pointer to the ID3DBlob interface that is used to retrieve the specified part of the buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>
	/// <c>D3DGetBlobPart</c> retrieves the part of a blob (arbitrary length data buffer) that contains the type of data that the
	/// <c>Part</c> parameter specifies.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dgetblobpart HRESULT D3DGetBlobPart( [in] LPCVOID
	// pSrcData, [in] SIZE_T SrcDataSize, [in] D3D_BLOB_PART Part, [in] UINT Flags, [out] ID3DBlob **ppPart );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DGetBlobPart")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DGetBlobPart([In] IntPtr pSrcData, [In] SizeT SrcDataSize, [In] D3D_BLOB_PART Part,
		[Optional] uint Flags, out ID3DBlob ppPart);

	/// <summary>
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data; either uncompiled or compiled HLSL code.</para>
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that contains debug information.</para>
	/// </summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data; either uncompiled or compiled HLSL code.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// </param>
	/// <param name="ppDebugInfo">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that contains debug information.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>Debug information is embedded in the body of the shader after calling D3DCompile.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dgetdebuginfo HRESULT D3DGetDebugInfo( [in] LPCVOID
	// pSrcData, [in] SIZE_T SrcDataSize, [out] ID3DBlob **ppDebugInfo );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DGetDebugInfo")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DGetDebugInfo([In] IntPtr pSrcData, [In] SizeT SrcDataSize, out ID3DBlob ppDebugInfo);

	/// <summary>
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data as compiled HLSL code.</para>
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that contains a compiled shader.</para>
	/// </summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data as compiled HLSL code.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// </param>
	/// <param name="ppSignatureBlob">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that contains a compiled shader.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dgetinputandoutputsignatureblob HRESULT
	// D3DGetInputAndOutputSignatureBlob( [in] LPCVOID pSrcData, [in] SIZE_T SrcDataSize, [out] ID3DBlob **ppSignatureBlob );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DGetInputAndOutputSignatureBlob")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DGetInputAndOutputSignatureBlob([In] IntPtr pSrcData, [In] SizeT SrcDataSize, out ID3DBlob ppSignatureBlob);

	/// <summary>
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data as compiled HLSL code.</para>
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that contains a compiled shader.</para>
	/// </summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data as compiled HLSL code.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// </param>
	/// <param name="ppSignatureBlob">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that contains a compiled shader.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dgetinputsignatureblob HRESULT
	// D3DGetInputSignatureBlob( [in] LPCVOID pSrcData, [in] SIZE_T SrcDataSize, [out] ID3DBlob **ppSignatureBlob );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DGetInputSignatureBlob")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DGetInputSignatureBlob([In] IntPtr pSrcData, [In] SizeT SrcDataSize, out ID3DBlob ppSignatureBlob);

	/// <summary>
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data as compiled HLSL code.</para>
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that contains a compiled shader.</para>
	/// </summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data as compiled HLSL code.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// </param>
	/// <param name="ppSignatureBlob">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface that contains a compiled shader.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dgetoutputsignatureblob HRESULT
	// D3DGetOutputSignatureBlob( [in] LPCVOID pSrcData, [in] SIZE_T SrcDataSize, [out] ID3DBlob **ppSignatureBlob );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DGetOutputSignatureBlob")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DGetOutputSignatureBlob([In] IntPtr pSrcData, [In] SizeT SrcDataSize, out ID3DBlob ppSignatureBlob);

	/// <summary>Retrieves the byte offsets for instructions within a section of shader code.</summary>
	/// <param name="pSrcData">A pointer to the compiled shader data.</param>
	/// <param name="SrcDataSize">The size, in bytes, of the block of memory that <c>pSrcData</c> points to.</param>
	/// <param name="Flags">
	/// <para>
	/// A combination of the following flags that are combined by using a bitwise <c>OR</c> operation. The resulting value specifies how
	/// <c>D3DGetTraceInstructionOffsets</c> retrieves the instruction offsets.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Flag</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>D3D_GET_INST_OFFSETS_INCLUDE_NON_EXECUTABLE (0x01)</description>
	/// <description>Include non-executable code in the retrieved information.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="StartInstIndex">
	/// The index of the instruction in the compiled shader data for which <c>D3DGetTraceInstructionOffsets</c> starts to retrieve the byte offsets.
	/// </param>
	/// <param name="NumInsts">The number of instructions for which <c>D3DGetTraceInstructionOffsets</c> retrieves the byte offsets.</param>
	/// <param name="pOffsets">A pointer to a variable that receives the actual number of offsets.</param>
	/// <param name="pTotalInsts">A pointer to a variable that receives the total number of instructions in the section of shader code.</param>
	/// <returns>Returns one of the Direct3D 11 return codes.</returns>
	/// <remarks>
	/// <para>
	/// A new kind of Microsoft High Level Shader Language (HLSL) debugging information from a program database (PDB) file uses
	/// instruction-byte offsets within a shader blob (arbitrary-length data buffer). You use <c>D3DGetTraceInstructionOffsets</c> to
	/// translate to and from instruction indexes.
	/// </para>
	/// <para>
	/// <c>Note</c>  The D3dcompiler_44.dll or later version of the file contains the <c>D3DGetTraceInstructionOffsets</c> compiler function.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dgettraceinstructionoffsets HRESULT
	// D3DGetTraceInstructionOffsets( [in] LPCVOID pSrcData, [in] SIZE_T SrcDataSize, [in] UINT Flags, [in] SIZE_T StartInstIndex, [in]
	// SIZE_T NumInsts, [out, optional] SIZE_T *pOffsets, [out, optional] SIZE_T *pTotalInsts );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DGetTraceInstructionOffsets")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DGetTraceInstructionOffsets([In] IntPtr pSrcData, [In] SizeT SrcDataSize, D3D_GET_INST_OFFSETS Flags,
		[In] SizeT StartInstIndex, [In] SizeT NumInsts, out SizeT pOffsets, out SizeT pTotalInsts);

	/// <summary>
	/// <para>Creates a shader module interface from source data for the shader module.</para>
	/// <para>
	/// <c>Note</c>  This function is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.
	/// <para></para>
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to the source data for the shader module.</para>
	/// </param>
	/// <param name="cbSrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>The size, in bytes, of the block of memory that <c>pSrcData</c> points to.</para>
	/// </param>
	/// <param name="ppModule">
	/// <para>Type: <c>ID3D11Module**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3D11Module interface that is used for shader resource re-binding.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para><c>Note</c>  The D3dcompiler_47.dll or later version of the DLL contains the <c>D3DLoadModule</c> function.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dloadmodule HRESULT D3DLoadModule( [in] LPCVOID
	// pSrcData, [in] SIZE_T cbSrcDataSize, [out] ID3D11Module **ppModule );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DLoadModule")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DLoadModule([In] IntPtr pSrcData, [In] SizeT cbSrcDataSize, out ID3D11Module ppModule);

	/// <summary>Preprocesses uncompiled HLSL code.</summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to uncompiled shader data; either ASCII HLSL code or a compiled effect.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// </param>
	/// <param name="pSourceName">
	/// <para>Type: <c>LPCSTR</c></para>
	/// <para>The name of the file that contains the uncompiled HLSL code.</para>
	/// </param>
	/// <param name="pDefines">
	/// <para>Type: <c>const D3D_SHADER_MACRO*</c></para>
	/// <para>An array of NULL-terminated macro definitions (see D3D_SHADER_MACRO).</para>
	/// </param>
	/// <param name="pInclude">
	/// <para>Type: <c>ID3DInclude*</c></para>
	/// <para>
	/// A pointer to an ID3DInclude for handling include files. Setting this to <c>NULL</c> will cause a compile error if a shader contains
	/// a #include. You can pass the <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c> macro, which is a pointer to a default include handler. This
	/// default include handler includes files that are relative to the current directory and files that are relative to the directory of
	/// the initial source file. When you use <c>D3D_COMPILE_STANDARD_FILE_INCLUDE</c>, you must specify the source file name in the
	/// <c>pSourceName</c> parameter; the compiler will derive the initial relative directory from <c>pSourceName</c>.
	/// </para>
	/// </param>
	/// <param name="ppCodeText">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>The address of a ID3DBlob that contains the compiled code.</para>
	/// </param>
	/// <param name="ppErrorMsgs">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to an ID3DBlob that contains compiler error messages, or <c>NULL</c> if there were no errors.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>
	/// <c>D3DPreprocess</c> outputs #line directives and preserves line numbering of source input so that output line numbering can be
	/// properly related to the input source.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dpreprocess HRESULT D3DPreprocess( [in] LPCVOID
	// pSrcData, [in] SIZE_T SrcDataSize, [in, optional] LPCSTR pSourceName, [in, optional] const D3D_SHADER_MACRO *pDefines, [in, optional]
	// ID3DInclude *pInclude, [out] ID3DBlob **ppCodeText, [out, optional] ID3DBlob **ppErrorMsgs );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DPreprocess")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DPreprocess([In] IntPtr pSrcData, [In] SizeT SrcDataSize,
		[Optional, MarshalAs(UnmanagedType.LPStr)] string? pSourceName, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D_SHADER_MACRO[]? pDefines,
		[In, Optional] ID3DInclude? pInclude, out ID3DBlob ppCodeText, out ID3DBlob? ppErrorMsgs);

	/// <summary>
	/// <para>A pointer to a constant null-terminated string that contains the name of the file to read into memory.</para>
	/// <para>
	/// A pointer to a variable that receives a pointer to the ID3DBlob interface that contains information that <c>D3DReadFileToBlob</c>
	/// read from the <c>pFileName</c> file. You can use this <c>ID3DBlob</c> interface to access the file information and pass it to other
	/// compiler functions.
	/// </para>
	/// </summary>
	/// <param name="pFileName">A pointer to a constant null-terminated string that contains the name of the file to read into memory.</param>
	/// <param name="ppContents">
	/// A pointer to a variable that receives a pointer to the ID3DBlob interface that contains information that <c>D3DReadFileToBlob</c>
	/// read from the <c>pFileName</c> file. You can use this <c>ID3DBlob</c> interface to access the file information and pass it to other
	/// compiler functions.
	/// </param>
	/// <returns>Returns one of the Direct3D 11 return codes.</returns>
	/// <remarks>
	/// <para><c>Note</c>  The D3dcompiler_44.dll or later version of the file contains the <c>D3DReadFileToBlob</c> compiler function.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dreadfiletoblob HRESULT D3DReadFileToBlob( [in]
	// LPCWSTR pFileName, [out] ID3DBlob **ppContents );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DReadFileToBlob")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DReadFileToBlob([MarshalAs(UnmanagedType.LPWStr)] string pFileName, out ID3DBlob ppContents);

	/// <summary>Gets a pointer to a reflection interface.</summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data as compiled HLSL code.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// </param>
	/// <param name="pInterface">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The reference GUID of the COM interface to use. For example, <c>IID_ID3D11ShaderReflection</c>.</para>
	/// </param>
	/// <param name="ppReflector">
	/// <para>Type: <c>void**</c></para>
	/// <para>A pointer to a reflection interface.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>Shader code contains metadata that can be inspected using the reflection APIs.</para>
	/// <para>The following code illustrates retrieving a ID3D11ShaderReflection Interface from a shader.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dreflect HRESULT D3DReflect( [in] LPCVOID pSrcData,
	// [in] SIZE_T SrcDataSize, [in] REFIID pInterface, [out] void **ppReflector );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DReflect")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DReflect([In] IntPtr pSrcData, [In] SizeT SrcDataSize, in Guid pInterface,
		[MarshalAs(UnmanagedType.Interface)] out object? ppReflector);

	/// <summary>
	/// <para>Creates a library-reflection interface from source data that contains an HLSL library of functions.</para>
	/// <para>
	/// <c>Note</c>  This function is part of the HLSL shader linking technology that you can use on all Direct3D 11 platforms to create
	/// precompiled HLSL functions, package them into libraries, and link them into full shaders at run time.
	/// <para></para>
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data as an HLSL library of functions.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>The size, in bytes, of the block of memory that <c>pSrcData</c> points to.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The reference GUID of the COM interface to use. For example, <c>IID_ID3D11LibraryReflection</c>.</para>
	/// </param>
	/// <param name="ppReflector">
	/// <para>Type: <c>LPVOID*</c></para>
	/// <para>A pointer to a variable that receives a pointer to a library-reflection interface, ID3D11LibraryReflection.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dreflectlibrary HRESULT D3DReflectLibrary( [in]
	// LPCVOID pSrcData, [in] SIZE_T SrcDataSize, [in] REFIID riid, [out] LPVOID *ppReflector );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DReflectLibrary")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DReflectLibrary([In] IntPtr pSrcData, [In] SizeT SrcDataSize, in Guid riid,
		[MarshalAs(UnmanagedType.Interface)] out object? ppReflector);

	/// <summary>Sets information in a compilation result.</summary>
	/// <param name="pSrcData">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to compiled shader data.</para>
	/// </param>
	/// <param name="SrcDataSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>The length of the compiled shader data that <c>pSrcData</c> points to.</para>
	/// </param>
	/// <param name="Part">
	/// <para>Type: <c>D3D_BLOB_PART</c></para>
	/// <para>
	/// A D3D_BLOB_PART-typed value that specifies the part to set. Currently, you can update only private data; that is,
	/// <c>D3DSetBlobPart</c> currently only supports the D3D_BLOB_PRIVATE_DATA value.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that indicate how to set the blob part. Currently, no flags are defined; therefore, set to zero.</para>
	/// </param>
	/// <param name="pPart">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to data to set in the compilation result.</para>
	/// </param>
	/// <param name="PartSize">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>The length of the data that <c>pPart</c> points to.</para>
	/// </param>
	/// <param name="ppNewShader">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>A pointer to a buffer that receives the ID3DBlob interface for the new shader in which the new part data is set.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>D3DSetBlobPart</c> modifies data in a compiled shader. Currently, <c>D3DSetBlobPart</c> can update only the private data in a
	/// compiled shader. You can use <c>D3DSetBlobPart</c> to attach arbitrary uninterpreted data to a compiled shader.
	/// </para>
	/// <para><c>Note</c>  The D3dcompiler_44.dll or later version of the file contains the <c>D3DSetBlobPart</c> compiler function.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dsetblobpart HRESULT D3DSetBlobPart( [in] LPCVOID
	// pSrcData, [in] SIZE_T SrcDataSize, [in] D3D_BLOB_PART Part, [in] UINT Flags, [in] LPCVOID pPart, [in] SIZE_T PartSize, [out] ID3DBlob
	// **ppNewShader );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DSetBlobPart")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DSetBlobPart([In] IntPtr pSrcData, [In] SizeT SrcDataSize, [In] D3D_BLOB_PART Part,
		[Optional] uint Flags, [In] IntPtr pPart, [In] SizeT PartSize, out ID3DBlob ppNewShader);

	/// <summary>Removes unwanted blobs from a compilation result.</summary>
	/// <param name="pShaderBytecode">
	/// <para>Type: <c>LPCVOID</c></para>
	/// <para>A pointer to source data as compiled HLSL code.</para>
	/// </param>
	/// <param name="BytecodeLength">
	/// <para>Type: <c>SIZE_T</c></para>
	/// <para>Length of <c>pSrcData</c>.</para>
	/// </param>
	/// <param name="uStripFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Strip flag options, represented by D3DCOMPILER_STRIP_FLAGS.</para>
	/// </param>
	/// <param name="ppStrippedBlob">
	/// <para>Type: <c>ID3DBlob**</c></para>
	/// <para>
	/// A pointer to a variable that receives a pointer to the ID3DBlob interface that you can use to access the unwanted stripped out
	/// shader code.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dstripshader HRESULT D3DStripShader( [in] LPCVOID
	// pShaderBytecode, [in] SIZE_T BytecodeLength, [in] UINT uStripFlags, [out] ID3DBlob **ppStrippedBlob );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DStripShader")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DStripShader([In] IntPtr pShaderBytecode, [In] SizeT BytecodeLength, D3DCOMPILER_STRIP_FLAGS uStripFlags,
		out ID3DBlob ppStrippedBlob);

	/// <summary>
	/// <para>Type: <c>ID3DBlob*</c></para>
	/// <para>A pointer to a ID3DBlob interface that contains the memory blob to write to the file that the <c>pFileName</c> parameter specifies.</para>
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>A pointer to a constant null-terminated string that contains the name of the file to which to write.</para>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// A Boolean value that specifies whether to overwrite information in the <c>pFileName</c> file. TRUE specifies to overwrite
	/// information and FALSE specifies not to overwrite information.
	/// </para>
	/// </summary>
	/// <param name="pBlob">
	/// <para>Type: <c>ID3DBlob*</c></para>
	/// <para>A pointer to a ID3DBlob interface that contains the memory blob to write to the file that the <c>pFileName</c> parameter specifies.</para>
	/// </param>
	/// <param name="pFileName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>A pointer to a constant null-terminated string that contains the name of the file to which to write.</para>
	/// </param>
	/// <param name="bOverwrite">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// A Boolean value that specifies whether to overwrite information in the <c>pFileName</c> file. TRUE specifies to overwrite
	/// information and FALSE specifies not to overwrite information.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the Direct3D 11 return codes.</para>
	/// </returns>
	/// <remarks>
	/// <para><c>Note</c>  The D3dcompiler_44.dll or later version of the file contains the <c>D3DWriteBlobToFile</c> compiler function.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dwriteblobtofile HRESULT D3DWriteBlobToFile( [in]
	// ID3DBlob *pBlob, [in] LPCWSTR pFileName, [in] BOOL bOverwrite );
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NF:d3dcompiler.D3DWriteBlobToFile")]
	[DllImport(Lib_D3dcompiler_47, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DWriteBlobToFile([In] ID3DBlob pBlob, [MarshalAs(UnmanagedType.LPWStr)] string pFileName,
		[MarshalAs(UnmanagedType.Bool)] bool bOverwrite);

	/// <summary>Describes shader data.</summary>
	/// <remarks>
	/// An array of <c>D3D_SHADER_DATA</c> structures is passed to D3DCompressShaders to compress the shader data into a more compact form.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/ns-d3dcompiler-d3d_shader_data typedef struct _D3D_SHADER_DATA {
	// LPCVOID pBytecode; SIZE_T BytecodeLength; } D3D_SHADER_DATA;
	[PInvokeData("d3dcompiler.h", MSDNShortId = "NS:d3dcompiler._D3D_SHADER_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D_SHADER_DATA
	{
		/// <summary>A pointer to shader data.</summary>
		public IntPtr pBytecode;

		/// <summary>Length of shader data that <c>pBytecode</c> points to.</summary>
		public SizeT BytecodeLength;
	}
}