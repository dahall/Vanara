using static Vanara.PInvoke.Ole32;
using IDxcBlob = Vanara.PInvoke.DXGI.ID3DBlob;

namespace Vanara.PInvoke;

/// <summary>Items from the dxilconv.dll</summary>
public static partial class DXC
{
	/// <summary/>
	public const string DXC_ARG_ALL_RESOURCES_BOUND = "-all_resources_bound";

	/// <summary/>
	public const string DXC_ARG_AVOID_FLOW_CONTROL = "-Gfa";

	/// <summary/>
	public const string DXC_ARG_DEBUG = "-Zi";

	/// <summary/>
	public const string DXC_ARG_DEBUG_NAME_FOR_BINARY = "-Zsb";

	/// <summary/>
	public const string DXC_ARG_DEBUG_NAME_FOR_SOURCE = "-Zss";

	/// <summary/>
	public const string DXC_ARG_ENABLE_BACKWARDS_COMPATIBILITY = "-Gec";

	/// <summary/>
	public const string DXC_ARG_ENABLE_STRICTNESS = "-Ges";

	/// <summary/>
	public const string DXC_ARG_IEEE_STRICTNESS = "-Gis";

	/// <summary/>
	public const string DXC_ARG_OPTIMIZATION_LEVEL0 = "-O0";

	/// <summary/>
	public const string DXC_ARG_OPTIMIZATION_LEVEL1 = "-O1";

	/// <summary/>
	public const string DXC_ARG_OPTIMIZATION_LEVEL2 = "-O2";

	/// <summary/>
	public const string DXC_ARG_OPTIMIZATION_LEVEL3 = "-O3";

	/// <summary/>
	public const string DXC_ARG_PACK_MATRIX_COLUMN_MAJOR = "-Zpc";

	/// <summary/>
	public const string DXC_ARG_PACK_MATRIX_ROW_MAJOR = "-Zpr";

	/// <summary/>
	public const string DXC_ARG_PREFER_FLOW_CONTROL = "-Gfp";

	/// <summary/>
	public const string DXC_ARG_RESOURCES_MAY_ALIAS = "-res_may_alias";

	/// <summary/>
	public const string DXC_ARG_SKIP_OPTIMIZATIONS = "-Od";

	/// <summary/>
	public const string DXC_ARG_SKIP_VALIDATION = "-Vd";

	/// <summary/>
	public const string DXC_ARG_WARNINGS_ARE_ERRORS = "-WX";

	/// <summary>CLSID_DxcAssembler</summary>
	public static readonly Guid CLSID_DxcAssembler = new("d728db68-f903-4f80-94cd-dccf76ec7151");

	/// <summary>CLSID_DxcCompiler</summary>
	public static readonly Guid CLSID_DxcCompiler = new("73e22d93-e6ce-47f3-b5bf-f0664f39c1b0");

	/// <summary>CLSID_DxcCompilerArgs</summary>
	public static readonly Guid CLSID_DxcCompilerArgs = new("3e56ae82-224d-470f-a1a1-fe3016ee9f9d");

	/// <summary>CLSID_DxcContainerBuilder</summary>
	public static readonly Guid CLSID_DxcContainerBuilder = new("94134294-411f-4574-b4d0-8741e25240d2");

	/// <summary>CLSID_DxcContainerReflection</summary>
	public static readonly Guid CLSID_DxcContainerReflection = new("b9f54489-55b8-400c-ba3a-1675e4728b91");

	/// <summary>CLSID_DxcDiaDataSource</summary>
	public static readonly Guid CLSID_DxcDiaDataSource = new("cd1f6b73-2ab0-484d-8edc-ebe7a43ca09f");

	/// <summary>CLSID_DxcLibrary</summary>
	public static readonly Guid CLSID_DxcLibrary = new("6245d6af-66e0-48fd-80b4-4d271796748c");

	/// <summary>CLSID_DxcLinker</summary>
	public static readonly Guid CLSID_DxcLinker = new("ef6a8087-b0ea-4d56-9e45-d07e1a8b786");

	/// <summary>CLSID_DxcOptimizer</summary>
	public static readonly Guid CLSID_DxcOptimizer = new("ae2cd79f-cc22-453f-9b6b-b124e7a5204c");

	/// <summary>CLSID_DxcPdbUtils</summary>
	public static readonly Guid CLSID_DxcPdbUtils = new("54621dfb-f2ce-457e-ae8c-ec355faeec7c");

	/// <summary>CLSID_DxcUtils</summary>
	public static readonly Guid CLSID_DxcUtils = CLSID_DxcLibrary;

	/// <summary>CLSID_DxcValidator</summary>
	public static readonly Guid CLSID_DxcValidator = new("8ca3e215-f728-4cf3-8cdd-88af917587a1");

	private const string Lib_Dxilconv = "dxilconv.dll";

	/// <summary>Code page values for text encoding.</summary>
	public enum DXC_CP : uint
	{
		/// <summary>For binary or ANSI code page.</summary>
		DXC_CP_ACP = 0,

		/// <summary>For UTF8 code page.</summary>
		DXC_CP_UTF8 = 65001,

		/// <summary>For UTF16 code page.</summary>
		DXC_CP_UTF16 = 1200,

		/// <summary>For UTF32 code page.</summary>
		DXC_CP_UTF32 = 12000,
	}

	/// <summary>Flag values for <see cref="DxcShaderHash"/>.</summary>
	[Flags]
	public enum DXC_HASHFLAG : uint
	{
		/// <summary>Indicates that the shader hash was computed taking into account source information (-Zss).</summary>
		DXC_HASHFLAG_INCLUDES_SOURCE = 1
	}

	/// <summary>
	/// <para>
	/// Defines constants that specify the kind of output to retrieve from an <c>IDxcResult</c>. For use with the dxcOutKind parameter of
	/// <c>IDxcResult::GetOutput</c> and <c>IDxcResult::HasOutput</c>.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>Text outputs returned from version 2 APIs are UTF-8 or UTF-16, depending on the <c>-encoding</c> option passed to the compiler.</para>
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ne-dxcapi-dxc_out_kind typedef enum DXC_OUT_KIND { DXC_OUT_NONE = 0,
	// DXC_OUT_OBJECT = 1, DXC_OUT_ERRORS = 2, DXC_OUT_PDB = 3, DXC_OUT_SHADER_HASH = 4, DXC_OUT_DISASSEMBLY = 5, DXC_OUT_HLSL = 6,
	// DXC_OUT_TEXT = 7, DXC_OUT_REFLECTION = 8, DXC_OUT_ROOT_SIGNATURE = 9, DXC_OUT_EXTRA_OUTPUTS = 10, DXC_OUT_REMARKS,
	// DXC_OUT_TIME_REPORT, DXC_OUT_TIME_TRACE, DXC_OUT_LAST, DXC_OUT_NUM_ENUMS, DXC_OUT_FORCE_DWORD = 0xFFFFFFFF } ;
	[PInvokeData("dxcapi.h", MSDNShortId = "NE:dxcapi.DXC_OUT_KIND")]
	public enum DXC_OUT_KIND : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies no output.</para>
		/// </summary>
		DXC_OUT_NONE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>For</para>
		/// <para>IDxcBlob</para>
		/// <para>, specifies a shader or library object.</para>
		/// </summary>
		DXC_OUT_OBJECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>For</para>
		/// <para>IDxcBlobUtf8</para>
		/// <para>or</para>
		/// <para>IDxcBlobUtf16</para>
		/// <para>, specifies errors.</para>
		/// </summary>
		DXC_OUT_ERRORS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>For</para>
		/// <para>IDxcBlob</para>
		/// <para>, specifies PDB.</para>
		/// </summary>
		DXC_OUT_PDB,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>For</para>
		/// <para>IDxcBlob</para>
		/// <para>, specifies the DxcShaderHash of a shader or a shader with source info (</para>
		/// <para>-Zsb/-Zss</para>
		/// <para>).</para>
		/// </summary>
		DXC_OUT_SHADER_HASH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>For</para>
		/// <para>IDxcBlobUtf8</para>
		/// <para>or</para>
		/// <para>IDxcBlobUtf16</para>
		/// <para>, specifies the output from disassembling.</para>
		/// </summary>
		DXC_OUT_DISASSEMBLY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>For</para>
		/// <para>IDxcBlobUtf8</para>
		/// <para>or</para>
		/// <para>IDxcBlobUtf16</para>
		/// <para>, specifies the output from the preprocessor or rewriter.</para>
		/// </summary>
		DXC_OUT_HLSL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>For</para>
		/// <para>IDxcBlobUtf8</para>
		/// <para>or</para>
		/// <para>IDxcBlobUtf16</para>
		/// <para>, specifies other text, such as</para>
		/// <para>-ast-dump</para>
		/// <para>or</para>
		/// <para>-Odump</para>
		/// <para>.</para>
		/// </summary>
		DXC_OUT_TEXT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>For</para>
		/// <para>IDxcBlob</para>
		/// <para>, specifies the RDAT part with reflection data.</para>
		/// </summary>
		DXC_OUT_REFLECTION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>For</para>
		/// <para>IDxcBlob</para>
		/// <para>, specifies serialized root signature output.</para>
		/// </summary>
		DXC_OUT_ROOT_SIGNATURE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>For</para>
		/// <para>IDxcExtraOutputs</para>
		/// <para>, specifies extra outputs.</para>
		/// </summary>
		DXC_OUT_EXTRA_OUTPUTS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xFFFFFFFF</para>
		/// </summary>
		DXC_OUT_FORCE_DWORD = 0xFFFFFFFF,
	}

	/// <summary>Validation flags.</summary>
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcValidator")]
	[Flags]
	public enum DxcValidatorFlags : uint
	{
		/// <summary/>
		DxcValidatorFlags_Default = 0,

		/// <summary/>
		DxcValidatorFlags_InPlaceEdit = 1,  // Validator is allowed to update shader blob in-place.

		/// <summary/>
		DxcValidatorFlags_RootSignatureOnly = 2,

		/// <summary/>
		DxcValidatorFlags_ModuleOnly = 4,

		/// <summary/>
		DxcValidatorFlags_ValidMask = 0x7,
	}

	/// <summary>Version flags</summary>
	[Flags]
	public enum DxcVersionInfoFlags : uint
	{
		/// <summary/>
		DxcVersionInfoFlags_None = 0,

		/// <summary/>
		DxcVersionInfoFlags_Debug = 1, // Matches VS_FF_DEBUG

		/// <summary/>
		DxcVersionInfoFlags_Internal = 2, // Internal Validator (non-signing)
	}

	/// <summary>
	/// <para>Interface representing the DxcAssembler.</para>
	/// <para>To obtain an instance of this interface, call <c>DxcCreateInstance</c> with <b>CLSID_DxcAssembler</b>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcassembler struct IDxcAssembler : IUnknown { HRESULT
	// AssembleToContainer( IDxcBlob *pShader, IDxcOperationResult **ppResult ); };
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcAssembler")]
	[ComImport, Guid("091f7a26-1c1f-4948-904b-e6e3a8a771d5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcAssembler
	{
		/// <summary>Assemble DXIL in LL or LLVM bitcode to a DXIL container.</summary>
		/// <param name="pShader">The shader to assemble.</param>
		/// <param name="ppResult">Assembly output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcassembler-assembletocontainer HRESULT
		// AssembleToContainer( IDxcBlob *pShader, IDxcOperationResult **ppResult );
		[PreserveSig]
		HRESULT AssembleToContainer(IDxcBlob pShader, out IDxcOperationResult ppResult);
	}

	/// <summary>A blob that might have a known encoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcblobencoding struct IDxcBlobEncoding : IDxcBlob { HRESULT
	// GetEncoding( BOOL *pKnown, UINT32 *pCodePage ); };
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcBlobEncoding")]
	[ComImport, Guid("7241d424-2646-4191-97c0-98e96e42fc68"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcBlobEncoding : IDxcBlob
	{
		/// <summary>Gets a pointer to the data.</summary>
		/// <returns>
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>Returns a pointer.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3d10blob-getbufferpointer LPVOID GetBufferPointer();
		[PreserveSig]
		new IntPtr GetBufferPointer();

		/// <summary>Gets the size.</summary>
		/// <returns>
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>The size of the data, in bytes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3d10blob-getbuffersize SIZE_T GetBufferSize();
		[PreserveSig]
		new SizeT GetBufferSize();

		/// <summary>Retrieve the encoding for this blob.</summary>
		/// <param name="pKnown">Pointer to a variable that will be set to <c>TRUE</c> if the encoding is known.</param>
		/// <param name="pCodePage">
		/// Pointer to a variable that will be set to the encoding used for this blob. If the encoding isn't known then pCodePage will be
		/// set to <b>CP_ACP</b>.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcblobencoding-getencoding HRESULT GetEncoding( BOOL
		// *pKnown, UINT32 *pCodePage );
		void GetEncoding(out bool pKnown, out DXC_CP pCodePage);
	}

	/// <summary>
	/// A blob containing a null-terminated string, and using the UTF-8 character encoding. Depending on the <c>-encoding</c> option passed
	/// to the compiler, this interface is used to return string output blobs (such as errors/warnings, preprocessed HLSL, or other text).
	/// The methods of <b>IDxcBlobUtf8</b> guarantee null-terminated text, and UTF-8 character encoding. <c>IDxcBlobUtf16</c> is used to
	/// return output name strings in DXC.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcblobutf8 struct IDxcBlobUtf8 : IDxcBlobEncoding { LPCSTR
	// GetStringPointer(); SIZE_T GetStringLength(); };
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcBlobUtf8")]
	[ComImport, Guid("3da636c9-ba71-4024-a301-30cbf125305b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcBlobUtf8 : IDxcBlobEncoding, IDxcBlob
	{
		/// <summary>Gets a pointer to the data.</summary>
		/// <returns>
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>Returns a pointer.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3d10blob-getbufferpointer LPVOID GetBufferPointer();
		[PreserveSig]
		new IntPtr GetBufferPointer();

		/// <summary>Gets the size.</summary>
		/// <returns>
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>The size of the data, in bytes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3d10blob-getbuffersize SIZE_T GetBufferSize();
		[PreserveSig]
		new SizeT GetBufferSize();

		/// <summary>Retrieve the encoding for this blob.</summary>
		/// <param name="pKnown">Pointer to a variable that will be set to <c>TRUE</c> if the encoding is known.</param>
		/// <param name="pCodePage">
		/// Pointer to a variable that will be set to the encoding used for this blob. If the encoding isn't known then pCodePage will be
		/// set to <b>CP_ACP</b>.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcblobencoding-getencoding HRESULT GetEncoding( BOOL
		// *pKnown, UINT32 *pCodePage );
		new void GetEncoding(out bool pKnown, out DXC_CP pCodePage);

		/// <summary>Retrieves a pointer to the string stored in this blob.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcblobutf8-getstringpointer LPCSTR GetStringPointer();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string GetStringPointer();

		/// <summary>Retrieves the length of the string stored in this blob, in characters, excluding the null-terminator.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcblobutf8-getstringlength SIZE_T GetStringLength();
		[PreserveSig]
		SizeT GetStringLength();
	}

	/// <summary>
	/// A blob containing a null-terminated string, and using the Unicode character encoding. Depending on the <c>-encoding</c> option
	/// passed to the compiler, this interface is used to return string output blobs (such as errors/warnings, preprocessed HLSL, or other
	/// text). The methods of <b>IDxcBlobWide</b> guarantee null-terminated text, and Unicode character encoding. <c>IDxcBlobWide</c> is
	/// used to return output name strings in DXC.
	/// </summary>
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcBlobWide")]
	[ComImport, Guid("a3f84eab-0faa-497e-a39c-ee6ed60b2d84"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcBlobWide : IDxcBlobEncoding, IDxcBlob
	{
		/// <summary>Gets a pointer to the data.</summary>
		/// <returns>
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>Returns a pointer.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3d10blob-getbufferpointer LPVOID GetBufferPointer();
		[PreserveSig]
		new IntPtr GetBufferPointer();

		/// <summary>Gets the size.</summary>
		/// <returns>
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>The size of the data, in bytes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/nf-d3dcommon-id3d10blob-getbuffersize SIZE_T GetBufferSize();
		[PreserveSig]
		new SizeT GetBufferSize();

		/// <summary>Retrieve the encoding for this blob.</summary>
		/// <param name="pKnown">Pointer to a variable that will be set to <c>TRUE</c> if the encoding is known.</param>
		/// <param name="pCodePage">
		/// Pointer to a variable that will be set to the encoding used for this blob. If the encoding isn't known then pCodePage will be
		/// set to <b>CP_ACP</b>.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcblobencoding-getencoding HRESULT GetEncoding( BOOL
		// *pKnown, UINT32 *pCodePage );
		new void GetEncoding(out bool pKnown, out DXC_CP pCodePage);

		/// <summary>Retrieves a pointer to the string stored in this blob.</summary>
		// LPCWSTR GetStringPointer();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetStringPointer();

		/// <summary>Retrieves the length of the string stored in this blob, in characters, excluding the null-terminator.</summary>
		// SIZE_T GetStringLength();
		[PreserveSig]
		SizeT GetStringLength();
	}

	/// <summary><b>IDxcCompiler</b> is deprecated; use <c>IDxcCompiler3</c> instead.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxccompiler struct IDxcCompiler : IUnknown { HRESULT Compile(
	// IDxcBlob *pSource, LPCWSTR pSourceName, LPCWSTR pEntryPoint, LPCWSTR pTargetProfile, LPCWSTR *pArguments, UINT32 argCount, const
	// DxcDefine *pDefines, UINT32 defineCount, IDxcIncludeHandler *pIncludeHandler, IDxcOperationResult **ppResult ); HRESULT Preprocess(
	// IDxcBlob *pSource, LPCWSTR pSourceName, LPCWSTR *pArguments, UINT32 argCount, const DxcDefine *pDefines, UINT32 defineCount,
	// IDxcIncludeHandler *pIncludeHandler, IDxcOperationResult **ppResult ); HRESULT Disassemble( IDxcBlob *pSource, IDxcBlobEncoding
	// **ppDisassembly ); };
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcCompiler")]
	[ComImport, Guid("8c210bf3-011f-4422-8d70-6f9acb8db617"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Obsolete("IDxcCompiler is deprecated; use IDxcCompiler3 instead.")]
	public interface IDxcCompiler
	{
		/// <summary>
		/// Compile a single entry point to the target shader model. <b>IDxcCompiler::Compile</b> is deprecated; use
		/// <c>IDxcCompiler3::Compile</c> instead.
		/// </summary>
		/// <param name="pSource">The source text to compile.</param>
		/// <param name="pSourceName">An optional file name for pSource. Used in errors and include handlers.</param>
		/// <param name="pEntryPoint">Entry point name.</param>
		/// <param name="pTargetProfile">Shader profile to compile.</param>
		/// <param name="pArguments">An array of pointers to arguments.</param>
		/// <param name="argCount">The number of arguments.</param>
		/// <param name="pDefines">An array of defines.</param>
		/// <param name="defineCount">The number of defines.</param>
		/// <param name="pIncludeHandler">An optional user-provided interface to handle <c>#include</c> directives.</param>
		/// <param name="ppResult">The compiler output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompiler-compile HRESULT Compile( IDxcBlob *pSource,
		// LPCWSTR pSourceName, LPCWSTR pEntryPoint, LPCWSTR pTargetProfile, LPCWSTR *pArguments, UINT32 argCount, const DxcDefine
		// *pDefines, UINT32 defineCount, IDxcIncludeHandler *pIncludeHandler, IDxcOperationResult **ppResult );
		[PreserveSig]
		HRESULT Compile(IDxcBlob pSource, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pSourceName,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pEntryPoint, [MarshalAs(UnmanagedType.LPWStr)] string pTargetProfile,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 5)] string[]? pArguments,
			uint argCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] DxcDefine[]? pDefines, int defineCount,
			[In, Optional] IDxcIncludeHandler? pIncludeHandler, out IDxcOperationResult ppResult);

		/// <summary>
		/// Preprocess source text. <b>IDxcCompiler::Preprocess</b> is deprecated; use <c>IDxcCompiler3::Compile</c> with the <c>-P</c>
		/// argument instead.
		/// </summary>
		/// <param name="pSource">The source text to preprocess.</param>
		/// <param name="pSourceName">An optional file name for pSource. Used in errors and include handlers.</param>
		/// <param name="pArguments">An array of pointers to arguments.</param>
		/// <param name="argCount">The number of arguments.</param>
		/// <param name="pDefines">An array of defines.</param>
		/// <param name="defineCount">The number of defines.</param>
		/// <param name="pIncludeHandler">An optional user-provided interface to handle <c>#include</c> directives.</param>
		/// <param name="ppResult">The preprocessor output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompiler-preprocess HRESULT Preprocess( IDxcBlob
		// *pSource, LPCWSTR pSourceName, LPCWSTR *pArguments, UINT32 argCount, const DxcDefine *pDefines, UINT32 defineCount,
		// IDxcIncludeHandler *pIncludeHandler, IDxcOperationResult **ppResult );
		[PreserveSig]
		HRESULT Preprocess([In] IDxcBlob pSource, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pSourceName,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 3)] string[]? pArguments,
			uint argCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DxcDefine[] pDefines, int defineCount,
			[In, Optional] IDxcIncludeHandler? pIncludeHandler, out IDxcOperationResult ppResult);

		/// <summary>Disassemble a program. <b>IDxcCompiler::Disassemble</b> is deprecated; use <c>IDxcCompiler3::Disassemble</c> instead.</summary>
		/// <param name="pSource">The program to disassemble.</param>
		/// <param name="ppDisassembly">The disassembly text.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompiler-disassemble HRESULT Disassemble( IDxcBlob
		// *pSource, IDxcBlobEncoding **ppDisassembly );
		[PreserveSig]
		HRESULT Disassemble([In] IDxcBlob pSource, out IDxcBlobEncoding ppDisassembly);
	}

	/// <summary><b>IDxcCompiler2</b> is deprecated; use <c>IDxcCompiler3</c> instead.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxccompiler2 struct IDxcCompiler2 : IDxcCompiler { HRESULT
	// CompileWithDebug( IDxcBlob *pSource, LPCWSTR pSourceName, LPCWSTR pEntryPoint, LPCWSTR pTargetProfile, LPCWSTR *pArguments, UINT32
	// argCount, const DxcDefine *pDefines, UINT32 defineCount, IDxcIncludeHandler *pIncludeHandler, IDxcOperationResult **ppResult, LPWSTR
	// *ppDebugBlobName, IDxcBlob **ppDebugBlob ); };
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcCompiler2")]
	[ComImport, Guid("a005a9d9-b8bb-4594-b5c9-0e633bec4d37"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Obsolete("IDxcCompiler2 is deprecated; use IDxcCompiler3 instead.")]
	public interface IDxcCompiler2 : IDxcCompiler
	{
		/// <summary>
		/// Compile a single entry point to the target shader model. <b>IDxcCompiler::Compile</b> is deprecated; use
		/// <c>IDxcCompiler3::Compile</c> instead.
		/// </summary>
		/// <param name="pSource">The source text to compile.</param>
		/// <param name="pSourceName">An optional file name for pSource. Used in errors and include handlers.</param>
		/// <param name="pEntryPoint">Entry point name.</param>
		/// <param name="pTargetProfile">Shader profile to compile.</param>
		/// <param name="pArguments">An array of pointers to arguments.</param>
		/// <param name="argCount">The number of arguments.</param>
		/// <param name="pDefines">An array of defines.</param>
		/// <param name="defineCount">The number of defines.</param>
		/// <param name="pIncludeHandler">An optional user-provided interface to handle <c>#include</c> directives.</param>
		/// <param name="ppResult">The compiler output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompiler-compile HRESULT Compile( IDxcBlob *pSource,
		// LPCWSTR pSourceName, LPCWSTR pEntryPoint, LPCWSTR pTargetProfile, LPCWSTR *pArguments, UINT32 argCount, const DxcDefine
		// *pDefines, UINT32 defineCount, IDxcIncludeHandler *pIncludeHandler, IDxcOperationResult **ppResult );
		[PreserveSig]
		new HRESULT Compile(IDxcBlob pSource, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pSourceName,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pEntryPoint, [MarshalAs(UnmanagedType.LPWStr)] string pTargetProfile,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 5)] string[]? pArguments,
			uint argCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] DxcDefine[]? pDefines, int defineCount,
			[In, Optional] IDxcIncludeHandler? pIncludeHandler, out IDxcOperationResult ppResult);

		/// <summary>
		/// Preprocess source text. <b>IDxcCompiler::Preprocess</b> is deprecated; use <c>IDxcCompiler3::Compile</c> with the <c>-P</c>
		/// argument instead.
		/// </summary>
		/// <param name="pSource">The source text to preprocess.</param>
		/// <param name="pSourceName">An optional file name for pSource. Used in errors and include handlers.</param>
		/// <param name="pArguments">An array of pointers to arguments.</param>
		/// <param name="argCount">The number of arguments.</param>
		/// <param name="pDefines">An array of defines.</param>
		/// <param name="defineCount">The number of defines.</param>
		/// <param name="pIncludeHandler">An optional user-provided interface to handle <c>#include</c> directives.</param>
		/// <param name="ppResult">The preprocessor output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompiler-preprocess HRESULT Preprocess( IDxcBlob
		// *pSource, LPCWSTR pSourceName, LPCWSTR *pArguments, UINT32 argCount, const DxcDefine *pDefines, UINT32 defineCount,
		// IDxcIncludeHandler *pIncludeHandler, IDxcOperationResult **ppResult );
		[PreserveSig]
		new HRESULT Preprocess([In] IDxcBlob pSource, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pSourceName,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 3)] string[]? pArguments,
			uint argCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DxcDefine[] pDefines, int defineCount,
			[In, Optional] IDxcIncludeHandler? pIncludeHandler, out IDxcOperationResult ppResult);

		/// <summary>Disassemble a program. <b>IDxcCompiler::Disassemble</b> is deprecated; use <c>IDxcCompiler3::Disassemble</c> instead.</summary>
		/// <param name="pSource">The program to disassemble.</param>
		/// <param name="ppDisassembly">The disassembly text.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompiler-disassemble HRESULT Disassemble( IDxcBlob
		// *pSource, IDxcBlobEncoding **ppDisassembly );
		[PreserveSig]
		new HRESULT Disassemble([In] IDxcBlob pSource, out IDxcBlobEncoding ppDisassembly);

		/// <summary>
		/// Compile a single entry point to the target shader model with debug information. <b>IDxcCompiler::CompileWithDebug</b> is
		/// deprecated; use <c>IDxcCompiler3::Compile</c> instead.
		/// </summary>
		/// <param name="pSource">The source text to compile.</param>
		/// <param name="pSourceName">An optional file name for pSource. Used in errors and include handlers.</param>
		/// <param name="pEntryPoint">Entry point name.</param>
		/// <param name="pTargetProfile">Shader profile to compile.</param>
		/// <param name="pArguments">An array of pointers to arguments.</param>
		/// <param name="argCount">The number of arguments.</param>
		/// <param name="pDefines">An array of defines.</param>
		/// <param name="defineCount">The number of defines.</param>
		/// <param name="pIncludeHandler">An optional user-provided interface to handle <c>#include</c> directives.</param>
		/// <param name="ppResult">The compiler output status, buffer, and errors.</param>
		/// <param name="ppDebugBlobName">A suggested file name for the debug blob. You must free this memory by using <c>CoTaskMemFree</c>.</param>
		/// <param name="ppDebugBlob">The debug blob.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompiler2-compilewithdebug HRESULT CompileWithDebug(
		// IDxcBlob *pSource, LPCWSTR pSourceName, LPCWSTR pEntryPoint, LPCWSTR pTargetProfile, LPCWSTR *pArguments, UINT32 argCount, const
		// DxcDefine *pDefines, UINT32 defineCount, IDxcIncludeHandler *pIncludeHandler, IDxcOperationResult **ppResult, LPWSTR
		// *ppDebugBlobName, IDxcBlob **ppDebugBlob );
		[PreserveSig]
		HRESULT CompileWithDebug([In] IDxcBlob pSource, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pSourceName,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pEntryPoint, [MarshalAs(UnmanagedType.LPWStr)] string pTargetProfile,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 5)] string[]? pArguments,
			uint argCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] DxcDefine[] pDefines, int defineCount,
			[In, Optional] IDxcIncludeHandler? pIncludeHandler, out IDxcOperationResult ppResult,
			[MarshalAs(UnmanagedType.LPWStr)] out string? ppDebugBlobName, out IDxcBlob? ppDebugBlob);
	}

	/// <summary>
	/// <para>Interface that represents the DirectX Shader Compiler.</para>
	/// <para>To obtain an instance of this interface, call <c>DxcCreateInstance</c> with <b>CLSID_DxcCompiler</b>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxccompiler3 struct IDxcCompiler3 : IUnknown { HRESULT Compile(
	// const DxcBuffer *pSource, LPCWSTR *pArguments, UINT32 argCount, IDxcIncludeHandler *pIncludeHandler, REFIID riid, LPVOID *ppResult );
	// HRESULT Disassemble( const DxcBuffer *pObject, REFIID riid, LPVOID *ppResult ); };
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcCompiler3")]
	[ComImport, Guid("228b4687-5a6a-4730-900c-9702b2203f54"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcCompiler3
	{
		/// <summary>
		/// <para>Compile a shader. Depending on the arguments, you can use this method to:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Compile a single entry point to the target shader model</description>
		/// </item>
		/// <item>
		/// <description>Compile a library to a library target ( <c>-T lib_*</c>)</description>
		/// </item>
		/// <item>
		/// <description>Compile a root signature ( <c>-T rootsig_*</c>),</description>
		/// </item>
		/// <item>
		/// <description>Preprocess HLSL source ( <c>-P</c>)</description>
		/// </item>
		/// </list>
		/// <para>You can use <c>IDxcUtils::BuildArguments</c> to assist in building the pArguments and argCount arguments.</para>
		/// </summary>
		/// <param name="pSource">The source text to compile.</param>
		/// <param name="pArguments">An array of pointers to arguments.</param>
		/// <param name="argCount">The number of arguments.</param>
		/// <param name="pIncludeHandler">An optional user-provided interface to handle <c>#include</c> directives.</param>
		/// <param name="riid">The interface ID for the result.</param>
		/// <param name="ppResult">An <c>IDxcResult</c> representing the compiler output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompiler3-compile HRESULT Compile( const DxcBuffer
		// *pSource, LPCWSTR *pArguments, UINT32 argCount, IDxcIncludeHandler *pIncludeHandler, REFIID riid, LPVOID *ppResult );
		[PreserveSig]
		HRESULT Compile(in DxcBuffer pSource, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[]? pArguments,
			uint argCount, [In, Optional] IDxcIncludeHandler? pIncludeHandler, in Guid riid,
			[MarshalAs(UnmanagedType.Interface, IidParameterIndex = 4)] out object ppResult);

		/// <summary>Disassemble a program.</summary>
		/// <param name="pObject">The program to disassemble: dxil container or bitcode.</param>
		/// <param name="riid">The interface ID for the result.</param>
		/// <param name="ppResult">An <c>IDxcResult</c> representing the compiler output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompiler3-disassemble HRESULT Disassemble( const
		// DxcBuffer *pObject, REFIID riid, LPVOID *ppResult );
		[PreserveSig]
		HRESULT Disassemble(in DxcBuffer pObject, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object ppResult);
	}

	/// <summary>
	/// <para>An interface for managing arguments passed to DXC.</para>
	/// <para>To create an instance of this interface, call <c>IDxcUtils::BuildArguments</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxccompilerargs struct IDxcCompilerArgs : IUnknown { LPCWSTR *
	// GetArguments(); UINT32 GetCount(); HRESULT AddArguments( LPCWSTR *pArguments, UINT32 argCount ); HRESULT AddArgumentsUTF8( LPCSTR
	// *pArguments, UINT32 argCount ); HRESULT AddDefines( const DxcDefine *pDefines, UINT32 defineCount ); };
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcCompilerArgs")]
	[ComImport, Guid("73effe2a-70dc-45f8-9690-eff64c02429d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcCompilerArgs
	{
		/// <summary>
		/// <para>Retrieves the array of arguments.</para>
		/// <para>You can pass the value returned by <b>GetArguments</b> directly to the pArguments parameter of <c>IDxcCompiler3::Compile</c>.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompilerargs-getarguments LPCWSTR * GetArguments();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetArguments();

		/// <summary>
		/// <para>Retrieves the number of arguments.</para>
		/// <para>You can pass the value returned by <b>GetCount</b> directly to the argCount parameter of <c>IDxcCompiler3::Compile</c>.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompilerargs-getcount UINT32 GetCount();
		[PreserveSig]
		uint GetCount();

		/// <summary>Adds additional arguments to this list of compiler arguments.</summary>
		/// <param name="pArguments">An array of pointers to arguments to add.</param>
		/// <param name="argCount">The number of arguments to add.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompilerargs-addarguments HRESULT AddArguments( LPCWSTR
		// *pArguments, UINT32 argCount );
		[PreserveSig]
		HRESULT AddArguments([In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[]? pArguments, uint argCount);

		/// <summary>Adds additional UTF-8-encoded arguments to this list of compiler arguments.</summary>
		/// <param name="pArguments">An array of pointers to UTF-8 arguments to add.</param>
		/// <param name="argCount">The number of arguments to add.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompilerargs-addargumentsutf8
		// HRESULT AddArgumentsUTF8( LPCSTR *pArguments, UINT32 argCount );
		[PreserveSig]
#if NET45 || NETSTANDARD2_0
		HRESULT AddArgumentsUTF8([In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 1)] string[]? pArguments, uint argCount);
#else
		HRESULT AddArgumentsUTF8([In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str, SizeParamIndex = 1)] string[]? pArguments, uint argCount);
#endif

		/// <summary>Adds additional defines to this list of compiler arguments.</summary>
		/// <param name="pDefines">An array of defines to add.</param>
		/// <param name="defineCount">The number of defines to add.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccompilerargs-adddefines HRESULT AddDefines( const
		// DxcDefine *pDefines, UINT32 defineCount );
		[PreserveSig]
		HRESULT AddDefines([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DxcDefine[] pDefines, int defineCount);
	}

	/// <summary>
	/// <para>Interface representing the DXC container builder.</para>
	/// <para>To obtain an instance of this interface, call <c>DxcCreateInstance</c> with <b>CLSID_DxcContainerBuilder</b>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxccontainerbuilder struct IDxcContainerBuilder : IUnknown {
	// HRESULT Load( IDxcBlob *pDxilContainerHeader ); HRESULT AddPart( UINT32 fourCC, IDxcBlob *pSource ); HRESULT RemovePart( UINT32
	// fourCC ); HRESULT SerializeContainer( IDxcOperationResult **ppResult ); };
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcContainerBuilder")]
	[ComImport, Guid("334b1f50-2292-4b35-99a1-25588d8c17fe"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcContainerBuilder
	{
		/// <summary>Loads a DxilContainer to the builder.</summary>
		/// <param name="pDxilContainerHeader"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccontainerbuilder-load HRESULT Load( IDxcBlob
		// *pDxilContainerHeader );
		[PreserveSig]
		HRESULT Load([In] IDxcBlob pDxilContainerHeader);

		/// <summary>Adds a part to the container.</summary>
		/// <param name="fourCC"/>
		/// <param name="pSource"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccontainerbuilder-addpart HRESULT AddPart( UINT32 fourCC,
		// IDxcBlob *pSource );
		[PreserveSig]
		HRESULT AddPart(DXC_PART fourCC, [In] IDxcBlob pSource);

		/// <summary>Remove a part from the container.</summary>
		/// <param name="fourCC">The identifier of the part to remove; for example, <b>DXC_PART_PDB</b>.</param>
		/// <returns>
		/// <b>S_OK</b> on success, or <b>DXC_E_MISSING_PART</b> if the part wasn't found, or other standard <b>HRESULT</b> error code.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccontainerbuilder-removepart HRESULT RemovePart( UINT32
		// fourCC );
		[PreserveSig]
		HRESULT RemovePart(DXC_PART fourCC);

		/// <summary>Build the container.</summary>
		/// <param name="ppResult">A pointer to the variable in which to receive the result.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccontainerbuilder-serializecontainer HRESULT
		// SerializeContainer( IDxcOperationResult **ppResult );
		[PreserveSig]
		HRESULT SerializeContainer(out IDxcOperationResult ppResult);
	}

	/// <summary>
	/// <para>Interface representing DxcContainerReflection.</para>
	/// <para>To obtain an instance of this interface, call <c>DxcCreateInstance</c> with <b>CLSID_DxcContainerReflection</b>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxccontainerreflection
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcContainerReflection")]
	[ComImport, Guid("d2c21b26-8350-4bdc-976a-331ce6f4c54c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcContainerReflection
	{
		/// <summary>Chooses the container to perform reflection on.</summary>
		/// <param name="pContainer">The container to load. If you pass NULL, then this instance will release any held resources.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccontainerreflection-load HRESULT Load( IDxcBlob
		// *pContainer );
		[PreserveSig]
		HRESULT Load([In] IDxcBlob pContainer);

		/// <summary>Retrieves the number of parts in the container.</summary>
		/// <param name="pResult">A pointer to the variable in which to receive the result.</param>
		/// <returns>
		/// <b>S_OK</b> on success, or <b>E_NOT_VALID_STATE</b> if a container has not been loaded by using <c>Load</c>, or another standard
		/// <b>HRESULT</b> error code.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccontainerreflection-getpartcount HRESULT GetPartCount(
		// UINT32 *pResult );
		[PreserveSig]
		HRESULT GetPartCount(out uint pResult);

		/// <summary>Retrieves the kind of the specified part.</summary>
		/// <param name="idx">The index of the part to query about.</param>
		/// <param name="pResult">A pointer to the variable in which to receive the result.</param>
		/// <returns>
		/// <b>S_OK</b> on success, or <b>E_NOT_VALID_STATE</b> if a container has not been loaded by using <c>Load</c>, or <b>E_BOUND</b>
		/// if idx is out of bounds, or another standard <b>HRESULT</b> error code.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccontainerreflection-getpartkind HRESULT GetPartKind(
		// UINT32 idx, UINT32 *pResult );
		[PreserveSig]
		HRESULT GetPartKind(uint idx, out uint pResult);

		/// <summary>Retrieves the content of the specified part.</summary>
		/// <param name="idx">The index of the part to retrieve.</param>
		/// <param name="ppResult">A pointer to the variable in which to receive the result.</param>
		/// <returns>
		/// <b>S_OK</b> on success, or <b>E_NOT_VALID_STATE</b> if a container has not been loaded by using <c>Load</c>, or <b>E_BOUND</b>
		/// if idx is out of bounds, or another standard <b>HRESULT</b> error code.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccontainerreflection-getpartcontent HRESULT
		// GetPartContent( UINT32 idx, IDxcBlob **ppResult );
		[PreserveSig]
		HRESULT GetPartContent(uint idx, out IDxcBlob ppResult);

		/// <summary>Retrieves the index of the first part that has the specified kind.</summary>
		/// <param name="kind">The kind to search for.</param>
		/// <param name="pResult">A pointer to the variable in which to receive the index of the matching part.</param>
		/// <returns>
		/// <b>S_OK</b> on success, or <b>E_NOT_VALID_STATE</b> if a container has not been loaded by using <c>Load</c>, or
		/// <b>HRESULT_FROM_WIN32(ERROR_NOT_FOUND)</b> if there's no part with the specified kind, or another standard <b>HRESULT</b> error code.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccontainerreflection-findfirstpartkind HRESULT
		// FindFirstPartKind( UINT32 kind, UINT32 *pResult );
		[PreserveSig]
		HRESULT FindFirstPartKind(uint kind, out uint pResult);

		/// <summary>Retrieves the reflection interface for the specified part.</summary>
		/// <param name="idx">The index of the part to search for.</param>
		/// <param name="iid">The IID of the interface to retrieve. Use an interface such as <c>ID3D12ShaderReflection</c>.</param>
		/// <param name="ppvObject">A pointer to the variable in which to receive the index of the matching part.</param>
		/// <returns>
		/// <b>S_OK</b> on success, or <b>E_NOT_VALID_STATE</b> if a container has not been loaded by using <c>Load</c>, or <b>E_BOUND</b>
		/// if idx is out of bounds, or another standard <b>HRESULT</b> error code.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxccontainerreflection-getpartreflection HRESULT
		// GetPartReflection( UINT32 idx, REFIID iid, void **ppvObject );
		[PreserveSig]
		HRESULT GetPartReflection(uint idx, in Guid iid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object ppvObject);
	}

	/// <summary>
	/// <para>Represents additional outputs from a DXC operation.</para>
	/// <para>
	/// This can be used to obtain outputs that don't have an explicit <b>DXC_OUT_KIND</b>. Use <b>DXC_OUT_EXTRA_OUTPUTS</b> to obtain
	/// instances of this.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcextraoutputs
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcExtraOutputs")]
	[ComImport, Guid("319b37a2-a5c2-494a-a5de-4801b2faf989"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcExtraOutputs
	{
		/// <summary>Retrieves the number of outputs available.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcextraoutputs-getoutputcount UINT32 GetOutputCount();
		[PreserveSig]
		uint GetOutputCount();

		/// <summary>Retrieves the specified output.</summary>
		/// <param name="uIndex">The index of the output to retrieve</param>
		/// <param name="iid">The interface ID of the output interface.</param>
		/// <param name="ppvObject">The optiopnal address of the pointer that receives a pointer to the output, if there is one.</param>
		/// <param name="ppOutputType">The optional address of the pointer to receive the output type name blob, if there is one.</param>
		/// <param name="ppOutputName">The optional address of a pointer to receive the output name blob, if there is one.</param>
		/// <returns>The specified output.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcextraoutputs-getoutput HRESULT GetOutput( UINT32 uIndex,
		// REFIID iid, void **ppvObject, IDxcBlobWide **ppOutputType, IDxcBlobWide **ppOutputName );
		[PreserveSig]
		HRESULT GetOutput(uint uIndex, in Guid iid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object? ppvObject,
			out IDxcBlobWide? ppOutputType, out IDxcBlobWide? ppOutputName);
	}

	/// <summary>
	/// <para>
	/// Interface for handling include directives. To customize the handling of include directives, you can provide an implementation of
	/// this interface.
	/// </para>
	/// <para>To create a default implementation that reads include files from the filesystem, call <c>IDxcUtils::CreateDefaultIncludeHandler</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcincludehandler
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcIncludeHandler")]
	[ComImport, Guid("7f61fc7d-950d-467f-b3e3-3c02fb49187c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcIncludeHandler
	{
		/// <summary>Load a source file to be included by the compiler.</summary>
		/// <param name="pFilename">The candidate file name.</param>
		/// <param name="ppIncludeSource">The resultant source object for the included file; or <c>nullptr</c> if not found.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcincludehandler-loadsource HRESULT LoadSource( LPCWSTR
		// pFilename, IDxcBlob **ppIncludeSource );
		[PreserveSig]
		HRESULT LoadSource([MarshalAs(UnmanagedType.LPWStr)] string pFilename, out IDxcBlob? ppIncludeSource);
	}

	/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxclibrary
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcLibrary")]
	[ComImport, Guid("E5204DC7-D18C-4C3C-BDFB-851673980FE7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Obsolete("IDxcLibrary is deprecated; use IDxcUtils instead.")]
	public interface IDxcLibrary
	{
		/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
		/// <param name="pMalloc"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclibrary-setmalloc HRESULT SetMalloc( IMalloc *pMalloc );
		[PreserveSig]
		HRESULT SetMalloc(IMalloc pMalloc);

		/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
		/// <param name="pBlob"/>
		/// <param name="offset"/>
		/// <param name="length"/>
		/// <param name="ppResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclibrary-createblobfromblob HRESULT CreateBlobFromBlob(
		// IDxcBlob *pBlob, UINT32 offset, UINT32 length, IDxcBlob **ppResult );
		[PreserveSig]
		HRESULT CreateBlobFromBlob(IDxcBlob pBlob, uint offset, uint length, out IDxcBlob ppResult);

		/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
		/// <param name="pFileName"/>
		/// <param name="codePage"/>
		/// <param name="pBlobEncoding"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclibrary-createblobfromfile HRESULT CreateBlobFromFile(
		// LPCWSTR pFileName, UINT32 *codePage, IDxcBlobEncoding **pBlobEncoding );
		[PreserveSig]
		HRESULT CreateBlobFromFile([MarshalAs(UnmanagedType.LPWStr)] string pFileName, [Optional] StructPointer<DXC_CP> codePage, out IDxcBlobEncoding pBlobEncoding);

		/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
		/// <param name="pText"/>
		/// <param name="size"/>
		/// <param name="codePage"/>
		/// <param name="pBlobEncoding"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclibrary-createblobwithencodingfrompinned HRESULT
		// CreateBlobWithEncodingFromPinned( LPCVOID pText, UINT32 size, UINT32 codePage, IDxcBlobEncoding **pBlobEncoding );
		[PreserveSig]
		HRESULT CreateBlobWithEncodingFromPinned([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pText, uint size, DXC_CP codePage, out IDxcBlobEncoding pBlobEncoding);

		/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
		/// <param name="pText"/>
		/// <param name="size"/>
		/// <param name="codePage"/>
		/// <param name="pBlobEncoding"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclibrary-createblobwithencodingonheapcopy HRESULT
		// CreateBlobWithEncodingOnHeapCopy( LPCVOID pText, UINT32 size, UINT32 codePage, IDxcBlobEncoding **pBlobEncoding );
		[PreserveSig]
		HRESULT CreateBlobWithEncodingOnHeapCopy([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pText, uint size, DXC_CP codePage, out IDxcBlobEncoding pBlobEncoding);

		/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
		/// <param name="pText"/>
		/// <param name="pIMalloc"/>
		/// <param name="size"/>
		/// <param name="codePage"/>
		/// <param name="pBlobEncoding"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclibrary-createblobwithencodingonmalloc HRESULT
		// CreateBlobWithEncodingOnMalloc( LPCVOID pText, IMalloc *pIMalloc, UINT32 size, UINT32 codePage, IDxcBlobEncoding **pBlobEncoding );
		[PreserveSig]
		HRESULT CreateBlobWithEncodingOnMalloc([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pText, IMalloc pIMalloc, uint size, DXC_CP codePage, out IDxcBlobEncoding pBlobEncoding);

		/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
		/// <param name="ppResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclibrary-createincludehandler HRESULT
		// CreateIncludeHandler( IDxcIncludeHandler **ppResult );
		[PreserveSig]
		HRESULT CreateIncludeHandler(out IDxcIncludeHandler ppResult);

		/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
		/// <param name="pBlob"/>
		/// <param name="ppStream"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclibrary-createstreamfromblobreadonly HRESULT
		// CreateStreamFromBlobReadOnly( IDxcBlob *pBlob, IStream **ppStream );
		[PreserveSig]
		HRESULT CreateStreamFromBlobReadOnly(IDxcBlob pBlob, out System.Runtime.InteropServices.ComTypes.IStream ppStream);

		/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
		/// <param name="pBlob"/>
		/// <param name="pBlobEncoding"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclibrary-getblobasutf8 HRESULT GetBlobAsUtf8( IDxcBlob
		// *pBlob, IDxcBlobEncoding **pBlobEncoding );
		[PreserveSig]
		HRESULT GetBlobAsUtf8(IDxcBlob pBlob, out IDxcBlobEncoding pBlobEncoding);

		/// <summary><b>IDxcUtils</b> replaces <b>IDxcLibrary</b>; use <b>IDxcUtils</b> insted.</summary>
		/// <param name="pBlob"/>
		/// <param name="pBlobEncoding"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclibrary-getblobasutf16 HRESULT GetBlobAsUtf16( IDxcBlob
		// *pBlob, IDxcBlobEncoding **pBlobEncoding );
		[PreserveSig]
		HRESULT GetBlobAsUtf16(IDxcBlob pBlob, out IDxcBlobEncoding pBlobEncoding);
	}

	/// <summary>
	/// <para>The DXC linker interface.</para>
	/// <para>To obtain an instance of this interface, call <c>DxcCreateInstance</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxclinker
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcLinker")]
	[ComImport, Guid("f1b5be2a-62dd-4327-a1c2-42ac1e1e78e6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcLinker
	{
		/// <summary>Register a library with a name so that you can later reference it by that name.</summary>
		/// <param name="pLibName">The name of the library.</param>
		/// <param name="pLib">The library blob.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclinker-registerlibrary HRESULT RegisterLibrary( LPCWSTR
		// pLibName, IDxcBlob *pLib );
		[PreserveSig]
		HRESULT RegisterLibrary([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pLibName, [In] IDxcBlob pLib);

		/// <summary>Links the shader, and produces a shader blob that the Direct3D runtime can use.</summary>
		/// <param name="pEntryName">Entry point name.</param>
		/// <param name="pTargetProfile">Shader profile to link.</param>
		/// <param name="pLibNames">An array of library names to link.</param>
		/// <param name="libCount">The number of libraries to link.</param>
		/// <param name="pArguments">An array of pointers to arguments.</param>
		/// <param name="argCount">The number of arguments.</param>
		/// <param name="ppResult">The linker output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxclinker-link HRESULT Link( LPCWSTR pEntryName, LPCWSTR
		// pTargetProfile, const LPCWSTR *pLibNames, UINT32 libCount, const LPCWSTR *pArguments, UINT32 argCount, IDxcOperationResult
		// **ppResult );
		[PreserveSig]
		HRESULT Link([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pEntryName, [MarshalAs(UnmanagedType.LPWStr)] string pTargetProfile,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 3)] string[] pLibNames, uint libCount,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 5)] string[]? pArguments, uint argCount,
			out IDxcOperationResult ppResult);
	}

	/// <summary>
	/// <para>The results of a DXC operation.</para>
	/// <para>
	/// <para>Note</para>
	/// <para><c>IDxcResult</c> replaces <b>IDxcOperationResult</b>, and should be used wherever possible.</para>
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcoperationresult
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcOperationResult")]
	[ComImport, Guid("cedb484a-d4e9-445a-b991-ca21ca157dc2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcOperationResult
	{
		/// <summary>Retrieves the overall status of the operation.</summary>
		/// <param name="pStatus">The overall status of the operation.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoperationresult-getstatus HRESULT GetStatus( HRESULT
		// *pStatus );
		[PreserveSig]
		HRESULT GetStatus(out HRESULT pStatus);

		/// <summary>
		/// <para>Retrieves the primary output of the operation. This corresponds to:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>DXC_OUT_OBJECT</c>. <b>Compile</b> with shader or library target.</description>
		/// </item>
		/// <item>
		/// <description><b>DXC_OUT_DISASSEMBLY</b>. <b>Disassemble</b>.</description>
		/// </item>
		/// <item>
		/// <description><b>DXC_OUT_HLSL</b>. <b>Compile</b> with <c>-P</c>.</description>
		/// </item>
		/// <item>
		/// <description><b>DXC_OUT_ROOT_SIGNATURE</b>. <b>Compile</b> with with <c>rootsig_* target</c>.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="ppResult">The primary output of the operation.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoperationresult-getresult HRESULT GetResult( IDxcBlob
		// **ppResult );
		[PreserveSig]
		HRESULT GetResult(out IDxcBlob? ppResult);

		/// <summary>
		/// Retrieves the error buffer from the operation, if there is one. This corresponds to calling <c>IDxcResult::GetOutput</c> with <c>DXC_OUT_ERRORS</c>.
		/// </summary>
		/// <param name="ppErrors"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoperationresult-geterrorbuffer HRESULT GetErrorBuffer(
		// IDxcBlobEncoding **ppErrors );
		[PreserveSig]
		HRESULT GetErrorBuffer(out IDxcBlobEncoding? ppErrors);
	}

	/// <summary>
	/// <para>Interface representing DxcOptimizer.</para>
	/// <para>To obtain an instance of this interface, call <c>DxcCreateInstance</c> with <b>CLSID_DxcOptimizer</b>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcoptimizer
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcOptimizer")]
	[ComImport, Guid("25740e2e-9cba-401b-9119-4fb42f39f270"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcOptimizer
	{
		/// <summary><c>pCount</c></summary>
		/// <param name="pCount"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoptimizer-getavailablepasscount HRESULT
		// GetAvailablePassCount( UINT32 *pCount );
		[PreserveSig]
		HRESULT GetAvailablePassCount(out uint pCount);

		/// <summary>
		/// <para><c>index</c></para>
		/// <para><c>ppResult</c></para>
		/// </summary>
		/// <param name="index"/>
		/// <param name="ppResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoptimizer-getavailablepass HRESULT GetAvailablePass(
		// UINT32 index, IDxcOptimizerPass **ppResult );
		[PreserveSig]
		HRESULT GetAvailablePass(uint index, out IDxcOptimizerPass ppResult);

		/// <summary>
		/// <para><c>pBlob</c></para>
		/// <para><c>ppOptions</c></para>
		/// <para><c>optionCount</c></para>
		/// <para><c>pOutputModule</c></para>
		/// <para><c>ppOutputText</c></para>
		/// </summary>
		/// <param name="pBlob"/>
		/// <param name="ppOptions"/>
		/// <param name="optionCount"/>
		/// <param name="pOutputModule"/>
		/// <param name="ppOutputText"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoptimizer-runoptimizer HRESULT RunOptimizer( IDxcBlob
		// *pBlob, LPCWSTR *ppOptions, UINT32 optionCount, IDxcBlob **pOutputModule, IDxcBlobEncoding **ppOutputText );
		[PreserveSig]
		HRESULT RunOptimizer([In] IDxcBlob pBlob,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[] ppOptions, uint optionCount,
			out IDxcBlob pOutputModule, out IDxcBlobEncoding? ppOutputText);
	}

	/// <summary>
	/// <para>Interface representing an optimizer pass.</para>
	/// <para>To obtain an instance of this interface, call <c>IDxcOptimizer::GetAvailablePass</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcoptimizerpass
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcOptimizerPass")]
	[ComImport, Guid("ae2cd79f-cc22-453f-9b6b-b124e7a5204c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcOptimizerPass
	{
		/// <summary><c>ppResult</c></summary>
		/// <param name="ppResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoptimizerpass-getoptionname HRESULT GetOptionName(
		// LPWSTR *ppResult );
		[PreserveSig]
		HRESULT GetOptionName([MarshalAs(UnmanagedType.LPWStr)] out string ppResult);

		/// <summary><c>ppResult</c></summary>
		/// <param name="ppResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoptimizerpass-getdescription HRESULT GetDescription(
		// LPWSTR *ppResult );
		[PreserveSig]
		HRESULT GetDescription([MarshalAs(UnmanagedType.LPWStr)] out string ppResult);

		/// <summary><c>pCount</c></summary>
		/// <param name="pCount"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoptimizerpass-getoptionargcount HRESULT
		// GetOptionArgCount( UINT32 *pCount );
		[PreserveSig]
		HRESULT GetOptionArgCount(out uint pCount);

		/// <summary>
		/// <para><c>argIndex</c></para>
		/// <para><c>ppResult</c></para>
		/// </summary>
		/// <param name="argIndex"/>
		/// <param name="ppResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoptimizerpass-getoptionargname HRESULT GetOptionArgName(
		// UINT32 argIndex, LPWSTR *ppResult );
		[PreserveSig]
		HRESULT GetOptionArgName(uint argIndex, [MarshalAs(UnmanagedType.LPWStr)] out string ppResult);

		/// <summary>
		/// <para><c>argIndex</c></para>
		/// <para><c>ppResult</c></para>
		/// </summary>
		/// <param name="argIndex"/>
		/// <param name="ppResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoptimizerpass-getoptionargdescription HRESULT
		// GetOptionArgDescription( UINT32 argIndex, LPWSTR *ppResult );
		[PreserveSig]
		HRESULT GetOptionArgDescription(uint argIndex, [MarshalAs(UnmanagedType.LPWStr)] out string? ppResult);
	}

	/// <summary>
	/// <para>Represents PDB version information.</para>
	/// <para>To obtain an instance of this interface, call <c>DxcCreateInstance</c> with <b>CLSID_DxcPdbUtils</b>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcpdbutils
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcPdbUtils")]
	[ComImport, Guid("e6c9647e-9d6a-4c3b-b94c-524b5a6c343d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcPdbUtils
	{
		/// <summary><c>pPdbOrDxil</c></summary>
		/// <param name="pPdbOrDxil"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-load HRESULT Load( IDxcBlob *pPdbOrDxil );
		[PreserveSig]
		HRESULT Load([In] IDxcBlob pPdbOrDxil);

		/// <summary><c>pCount</c></summary>
		/// <param name="pCount"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getsourcecount HRESULT GetSourceCount( UINT32
		// *pCount );
		[PreserveSig]
		HRESULT GetSourceCount(out uint pCount);

		/// <summary>
		/// <para><c>uIndex</c></para>
		/// <para><c>ppResult</c></para>
		/// </summary>
		/// <param name="uIndex"/>
		/// <param name="ppResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getsource HRESULT GetSource( UINT32 uIndex,
		// IDxcBlobEncoding **ppResult );
		[PreserveSig]
		HRESULT GetSource(uint uIndex, out IDxcBlobEncoding ppResult);

		/// <summary>
		/// <para><c>uIndex</c></para>
		/// <para><c>pResult</c></para>
		/// </summary>
		/// <param name="uIndex"/>
		/// <param name="pResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getsourcename HRESULT GetSourceName( UINT32
		// uIndex, BSTR *pResult );
		[PreserveSig]
		HRESULT GetSourceName(uint uIndex, [MarshalAs(UnmanagedType.BStr)] out string pResult);

		/// <summary><c>pCount</c></summary>
		/// <param name="pCount"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getflagcount HRESULT GetFlagCount( UINT32
		// *pCount );
		[PreserveSig]
		HRESULT GetFlagCount(out uint pCount);

		/// <summary>
		/// <para><c>uIndex</c></para>
		/// <para><c>pResult</c></para>
		/// </summary>
		/// <param name="uIndex"/>
		/// <param name="pResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getflag HRESULT GetFlag( UINT32 uIndex, BSTR
		// *pResult );
		[PreserveSig]
		HRESULT GetFlag(uint uIndex, [MarshalAs(UnmanagedType.BStr)] out string pResult);

		/// <summary><c>pCount</c></summary>
		/// <param name="pCount"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getargcount HRESULT GetArgCount( UINT32 *pCount );
		[PreserveSig]
		HRESULT GetArgCount(out uint pCount);

		/// <summary>
		/// <para><c>uIndex</c></para>
		/// <para><c>pResult</c></para>
		/// </summary>
		/// <param name="uIndex"/>
		/// <param name="pResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getarg HRESULT GetArg( UINT32 uIndex, BSTR
		// *pResult );
		[PreserveSig]
		HRESULT GetArg(uint uIndex, [MarshalAs(UnmanagedType.BStr)] out string pResult);

		/// <summary><c>pCount</c></summary>
		/// <param name="pCount"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getargpaircount HRESULT GetArgPairCount( UINT32
		// *pCount );
		[PreserveSig]
		HRESULT GetArgPairCount(out uint pCount);

		/// <summary>
		/// <para><c>uIndex</c></para>
		/// <para><c>pName</c></para>
		/// <para><c>pValue</c></para>
		/// </summary>
		/// <param name="uIndex"/>
		/// <param name="pName"/>
		/// <param name="pValue"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getargpair HRESULT GetArgPair( UINT32 uIndex,
		// BSTR *pName, BSTR *pValue );
		[PreserveSig]
		HRESULT GetArgPair(uint uIndex, [MarshalAs(UnmanagedType.BStr)] out string pName, [MarshalAs(UnmanagedType.BStr)] out string pValue);

		/// <summary><c>pCount</c></summary>
		/// <param name="pCount"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getdefinecount HRESULT GetDefineCount( UINT32
		// *pCount );
		[PreserveSig]
		HRESULT GetDefineCount(out uint pCount);

		/// <summary>
		/// <para><c>uIndex</c></para>
		/// <para><c>pResult</c></para>
		/// </summary>
		/// <param name="uIndex"/>
		/// <param name="pResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getdefine HRESULT GetDefine( UINT32 uIndex,
		// BSTR *pResult );
		[PreserveSig]
		HRESULT GetDefine(uint uIndex, [MarshalAs(UnmanagedType.BStr)] out string pResult);

		/// <summary><c>pResult</c></summary>
		/// <param name="pResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-gettargetprofile HRESULT GetTargetProfile( BSTR
		// *pResult );
		[PreserveSig]
		HRESULT GetTargetProfile([MarshalAs(UnmanagedType.BStr)] out string pResult);

		/// <summary><c>pResult</c></summary>
		/// <param name="pResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getentrypoint HRESULT GetEntryPoint( BSTR
		// *pResult );
		[PreserveSig]
		HRESULT GetEntryPoint([MarshalAs(UnmanagedType.BStr)] out string pResult);

		/// <summary><c>pResult</c></summary>
		/// <param name="pResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getmainfilename HRESULT GetMainFileName( BSTR
		// *pResult );
		[PreserveSig]
		HRESULT GetMainFileName([MarshalAs(UnmanagedType.BStr)] out string pResult);

		/// <summary><c>ppResult</c></summary>
		/// <param name="ppResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-gethash HRESULT GetHash( IDxcBlob **ppResult );
		[PreserveSig]
		HRESULT GetHash(out IDxcBlob ppResult);

		/// <summary><c>pResult</c></summary>
		/// <param name="pResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getname HRESULT GetName( BSTR *pResult );
		[PreserveSig]
		HRESULT GetName([MarshalAs(UnmanagedType.BStr)] out string pResult);

		/// <summary/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-isfullpdb BOOL IsFullPDB();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsFullPDB();

		/// <summary><c>ppFullPDB</c></summary>
		/// <param name="ppFullPDB"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getfullpdb HRESULT GetFullPDB( IDxcBlob
		// **ppFullPDB );
		[PreserveSig]
		HRESULT GetFullPDB(out IDxcBlob ppFullPDB);

		/// <summary><c>ppVersionInfo</c></summary>
		/// <param name="ppVersionInfo"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-getversioninfo HRESULT GetVersionInfo(
		// IDxcVersionInfo **ppVersionInfo );
		[PreserveSig]
		HRESULT GetVersionInfo(out IDxcVersionInfo ppVersionInfo);

		/// <summary><c>pCompiler</c></summary>
		/// <param name="pCompiler"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-setcompiler HRESULT SetCompiler( IDxcCompiler3
		// *pCompiler );
		[PreserveSig]
		HRESULT SetCompiler([In] IDxcCompiler3 pCompiler);

		/// <summary><c>ppResult</c></summary>
		/// <param name="ppResult"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-compileforfullpdb HRESULT CompileForFullPDB(
		// IDxcResult **ppResult );
		[PreserveSig]
		HRESULT CompileForFullPDB(out IDxcResult ppResult);

		/// <summary>
		/// <para><c>pArgPairs</c></para>
		/// <para><c>uNumArgPairs</c></para>
		/// </summary>
		/// <param name="pArgPairs"/>
		/// <param name="uNumArgPairs"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-overrideargs HRESULT OverrideArgs( DxcArgPair
		// *pArgPairs, UINT32 uNumArgPairs );
		[PreserveSig]
		HRESULT OverrideArgs([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DxcArgPair[] pArgPairs, uint uNumArgPairs);

		/// <summary><c>pRootSignature</c></summary>
		/// <param name="pRootSignature"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcpdbutils-overriderootsignature HRESULT
		// OverrideRootSignature( const WCHAR *pRootSignature );
		[PreserveSig]
		HRESULT OverrideRootSignature([MarshalAs(UnmanagedType.LPWStr)] string pRootSignature);
	}

	/// <summary>Undocumented.</summary>
	[ComImport, Guid("4315d938-f369-4f93-95a2-252017cc3807"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcPdbUtils2
	{
		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT Load([In] IDxcBlob pPdbOrDxil);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetSourceCount(out uint pCount);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetSource(uint uIndex, out IDxcBlobEncoding ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetSourceName(uint uIndex, out IDxcBlobWide ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetLibraryPDBCount(out uint pCount);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetLibraryPDB(uint uIndex, out IDxcPdbUtils2 ppOutPdbUtils, out IDxcBlobWide ppLibraryName);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetFlagCount(out uint pCount);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetFlag(uint uIndex, out IDxcBlobWide ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetArgCount(out uint pCount);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetArg(uint uIndex, out IDxcBlobWide ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetArgPairCount(out uint pCount);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetArgPair(uint uIndex, out IDxcBlobWide ppName, out IDxcBlobWide ppValue);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetDefineCount(out uint pCount);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetDefine(uint uIndex, out IDxcBlobWide ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetTargetProfile(out IDxcBlobWide ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetEntryPoint(out IDxcBlobWide ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetMainFileName(out IDxcBlobWide ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetHash(out IDxcBlob ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetName(out IDxcBlobWide ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetVersionInfo(out IDxcVersionInfo ppVersionInfo);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetCustomToolchainID(out uint pID);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetCustomToolchainData(out IDxcBlob ppBlob);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		HRESULT GetWholeDxil(out IDxcBlob ppResult);

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsFullPDB();

		/// <summary>Undocumented.</summary>
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsPDBRef();
	}

	/// <summary>
	/// Represents the result of a DXC operation. A DXC operation might have multiple outputs, such as a shader object and errors. This
	/// interface provides access to the outputs.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcresult
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcResult")]
	[ComImport, Guid("58346cda-dde7-4497-9461-6f87af5e0659"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcResult : IDxcOperationResult
	{
		/// <summary>Retrieves the overall status of the operation.</summary>
		/// <param name="pStatus">The overall status of the operation.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoperationresult-getstatus HRESULT GetStatus( HRESULT
		// *pStatus );
		[PreserveSig]
		new HRESULT GetStatus(out HRESULT pStatus);

		/// <summary>
		/// <para>Retrieves the primary output of the operation. This corresponds to:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>DXC_OUT_OBJECT</c>. <b>Compile</b> with shader or library target.</description>
		/// </item>
		/// <item>
		/// <description><b>DXC_OUT_DISASSEMBLY</b>. <b>Disassemble</b>.</description>
		/// </item>
		/// <item>
		/// <description><b>DXC_OUT_HLSL</b>. <b>Compile</b> with <c>-P</c>.</description>
		/// </item>
		/// <item>
		/// <description><b>DXC_OUT_ROOT_SIGNATURE</b>. <b>Compile</b> with with <c>rootsig_* target</c>.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="ppResult">The primary output of the operation.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoperationresult-getresult HRESULT GetResult( IDxcBlob
		// **ppResult );
		[PreserveSig]
		new HRESULT GetResult(out IDxcBlob? ppResult);

		/// <summary>
		/// Retrieves the error buffer from the operation, if there is one. This corresponds to calling <c>IDxcResult::GetOutput</c> with <c>DXC_OUT_ERRORS</c>.
		/// </summary>
		/// <param name="ppErrors"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcoperationresult-geterrorbuffer HRESULT GetErrorBuffer(
		// IDxcBlobEncoding **ppErrors );
		[PreserveSig]
		new HRESULT GetErrorBuffer(out IDxcBlobEncoding? ppErrors);

		/// <summary>Determines whether or not this result has the specified output.</summary>
		/// <param name="dxcOutKind">The kind of output to check for.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcresult-hasoutput BOOL HasOutput( DXC_OUT_KIND dxcOutKind );
		[PreserveSig]
		bool HasOutput(DXC_OUT_KIND dxcOutKind);

		/// <summary>Retrieves the specified output.</summary>
		/// <param name="dxcOutKind">The kind of output to retrieve.</param>
		/// <param name="iid">The interface ID of the output interface.</param>
		/// <param name="ppvObject">The address of the pointer that receives a pointer to the output.</param>
		/// <param name="ppOutputName">The optional address of the pointer to receive the output name blob, if there is one.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcresult-getoutput HRESULT GetOutput( DXC_OUT_KIND
		// dxcOutKind, REFIID iid, void **ppvObject, IDxcBlobWide **ppOutputName );
		[PreserveSig]
		HRESULT GetOutput(DXC_OUT_KIND dxcOutKind, in Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppvObject, out IDxcBlobWide ppOutputName);

		/// <summary>Retrieves the number of outputs available in this result.</summary>
		/// <returns>The number of outputs available in this result.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcresult-getnumoutputs UINT32 GetNumOutputs();
		[PreserveSig]
		uint GetNumOutputs();

		/// <summary>Retrieves the output kind at the specified index.</summary>
		/// <param name="Index">The index of the output to query about.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcresult-getoutputbyindex DXC_OUT_KIND GetOutputByIndex(
		// UINT32 Index );
		[PreserveSig]
		DXC_OUT_KIND GetOutputByIndex(uint Index);

		/// <summary/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcresult-primaryoutput DXC_OUT_KIND PrimaryOutput();
		[PreserveSig]
		DXC_OUT_KIND PrimaryOutput();
	}

	/// <summary>
	/// <para>Various utility functions for DXC.</para>
	/// <para>To obtain an instance of this interface, call <c>DxcCreateInstance</c> with <b>CLSID_DxcUtils</b>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcutils
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcUtils")]
	[ComImport, Guid("4605c4cb-2019-492a-ada4-65f20bb7d67f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcUtils
	{
		/// <summary>Create a sub-blob that holds a reference to the outer blob, and points to its memory.</summary>
		/// <param name="pBlob">The outer blob.</param>
		/// <param name="offset">The offset inside the outer blob.</param>
		/// <param name="length">The size, in bytes, of the buffer to reference from the output blob.</param>
		/// <param name="ppResult">Address of the pointer that receives a pointer to the newly-created blob.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-createblobfromblob HRESULT CreateBlobFromBlob(
		// IDxcBlob *pBlob, UINT32 offset, UINT32 length, IDxcBlob **ppResult );
		[PreserveSig]
		HRESULT CreateBlobFromBlob([In] IDxcBlob pBlob, uint offset, uint length, out IDxcBlob ppResult);

		/// <summary>
		/// <para>Creates a blob referencing existing memory, with no copy. You must manage the memory lifetime separately.</para>
		/// <para>Use this method in preference to <c>IDxcLibrary::CreateBlobWithEncodingFromPinned</c>.</para>
		/// </summary>
		/// <param name="pData">Pointer to a buffer containing the contents of the new blob.</param>
		/// <param name="size">The size of the pData buffer, in bytes.</param>
		/// <param name="codePage">The code page to use if the blob contains text. For binary or ANSI code page, use <b>DXC_CP_ACP</b>.</param>
		/// <param name="ppBlobEncoding"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-createblobfrompinned HRESULT CreateBlobFromPinned(
		// LPCVOID pData, UINT32 size, UINT32 codePage, IDxcBlobEncoding **ppBlobEncoding );
		[PreserveSig]
		HRESULT CreateBlobFromPinned([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pData, int size, DXC_CP codePage, out IDxcBlobEncoding ppBlobEncoding);

		/// <summary>Moves data to a blob.</summary>
		/// <param name="pData">Pointer to a buffer containing the contents of the new blob.</param>
		/// <param name="pIMalloc"></param>
		/// <param name="size">The size of the pData buffer, in bytes.</param>
		/// <param name="codePage">The code page to use if the blob contains text. For binary or ANSI code page, use <b>DXC_CP_ACP</b>.</param>
		/// <param name="ppBlobEncoding"/>
		[PreserveSig]
		HRESULT MoveToBlob([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pData, IMalloc pIMalloc, int size, DXC_CP codePage, out IDxcBlobEncoding ppBlobEncoding);

		/// <summary>
		/// <para>Create a blob containing a copy of the existing data. The new blob and its contents are allocated with the current allocator.</para>
		/// <para>Use this method in preference to <c>IDxcLibrary::CreateBlobWithEncodingOnHeapCopy</c>.</para>
		/// </summary>
		/// <param name="pData">A pointer to a buffer containing the contents of the new blob.</param>
		/// <param name="size">The size of the pData buffer, in bytes.</param>
		/// <param name="codePage">The code page to use if the blob contains text. For binary or ANSI code page, use <b>DXC_CP_ACP</b>.</param>
		/// <param name="ppBlobEncoding"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-createblob HRESULT CreateBlob( LPCVOID pData,
		// UINT32 size, UINT32 codePage, IDxcBlobEncoding **ppBlobEncoding );
		[PreserveSig]
		HRESULT CreateBlob([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pData, int size, DXC_CP codePage, out IDxcBlobEncoding ppBlobEncoding);

		/// <summary>
		/// <para>Create a blob with data loaded from a file. The new blob and its contents are allocated with the current allocator.</para>
		/// <para>Use this method in preference to <c>IDxcLibrary::CreateBlobFromFile</c>.</para>
		/// </summary>
		/// <param name="pFileName">The name of the file to load from.</param>
		/// <param name="pCodePage">An optional code page to use if the blob contains text. For binary data, pass <b>NULL</b>.</param>
		/// <param name="ppBlobEncoding"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-loadfile HRESULT LoadFile( LPCWSTR pFileName,
		// UINT32 *pCodePage, IDxcBlobEncoding **ppBlobEncoding );
		[PreserveSig]
		HRESULT LoadFile([MarshalAs(UnmanagedType.LPWStr)] string pFileName, [In, Optional] StructPointer<DXC_CP> pCodePage, out IDxcBlobEncoding ppBlobEncoding);

		/// <summary>Create a stream that reads data from a blob.</summary>
		/// <param name="pBlob">The blob to read from.</param>
		/// <param name="ppStream">The address of the pointer that receives a pointer to the newly-created stream.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-createreadonlystreamfromblob HRESULT
		// CreateReadOnlyStreamFromBlob( IDxcBlob *pBlob, IStream **ppStream );
		[PreserveSig]
		HRESULT CreateReadOnlyStreamFromBlob([In] IDxcBlob pBlob, out System.Runtime.InteropServices.ComTypes.IStream ppStream);

		/// <summary>Create a default file-based <c>include</c> handler.</summary>
		/// <param name="ppResult">The address of the pointer that receives a pointer to the newly-created include handler.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-createdefaultincludehandler HRESULT
		// CreateDefaultIncludeHandler( IDxcIncludeHandler **ppResult );
		[PreserveSig]
		HRESULT CreateDefaultIncludeHandler(out IDxcIncludeHandler ppResult);

		/// <summary>Convert or return matching encoded text blob as UTF-8.</summary>
		/// <param name="pBlob">The blob to convert.</param>
		/// <param name="ppBlobEncoding"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-getblobasutf8 HRESULT GetBlobAsUtf8( IDxcBlob
		// *pBlob, IDxcBlobUtf8 **ppBlobEncoding );
		[PreserveSig]
		HRESULT GetBlobAsUtf8([In] IDxcBlob pBlob, out IDxcBlobUtf8 ppBlobEncoding);

		/// <summary>Convert or return matching encoded text blob as Unicode.</summary>
		/// <param name="pBlob">The blob to convert.</param>
		/// <param name="ppBlobEncoding"/>
		[PreserveSig]
		HRESULT GetBlobAsWide([In] IDxcBlob pBlob, out IDxcBlobWide ppBlobEncoding);

		/// <summary>Retrieve a single part from a DXIL container.</summary>
		/// <param name="pShader">The shader to retrieve the part from.</param>
		/// <param name="DxcPart">The part to retrieve; for example, <b>DXC_PART_ROOT_SIGNATURE</b>.</param>
		/// <param name="ppPartData">
		/// The address of the pointer that receives a pointer to the part. The returned pointer points inside the buffer passed in pShader.
		/// </param>
		/// <param name="pPartSizeInBytes">The address of the pointer that receives the size of the part.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-getdxilcontainerpart HRESULT GetDxilContainerPart(
		// const DxcBuffer *pShader, UINT32 DxcPart, void **ppPartData, UINT32 *pPartSizeInBytes );
		[PreserveSig]
		HRESULT GetDxilContainerPart(in DxcBuffer pShader, DXC_PART DxcPart, out IntPtr ppPartData, out uint pPartSizeInBytes);

		/// <summary>
		/// Create a reflection interface from a serialized DXIL container, or the <b>DXC_PART_REFLECTION_DATA</b> blob contents. Use the
		/// returned interface with interfaces such as <c>ID3D12ShaderReflection</c>.
		/// </summary>
		/// <param name="pData">The source data.</param>
		/// <param name="iid">The interface ID of the reflection interface to create.</param>
		/// <param name="ppvReflection">The address of the pointer that receives a pointer to the newly-created reflection interface.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-createreflection HRESULT CreateReflection( const
		// DxcBuffer *pData, REFIID iid, void **ppvReflection );
		[PreserveSig]
		HRESULT CreateReflection(in DxcBuffer pData, in Guid iid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object ppvReflection);

		/// <summary>Build arguments that can be passed to the <c>Compile</c> method.</summary>
		/// <param name="pSourceName">An optional file name. Used in errors and include handlers.</param>
		/// <param name="pEntryPoint">Entry point name ( <c>-E</c>).</param>
		/// <param name="pTargetProfile">Shader profile to compile ( <c>-T</c>).</param>
		/// <param name="pArguments">An array of pointers to arguments.</param>
		/// <param name="argCount">The number of arguments.</param>
		/// <param name="pDefines">An array of defines.</param>
		/// <param name="defineCount">The number of defines.</param>
		/// <param name="ppArgs">Arguments that you can use with the <c>IDxcCompiler3::Compile</c> method.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-buildarguments HRESULT BuildArguments( LPCWSTR
		// pSourceName, LPCWSTR pEntryPoint, LPCWSTR pTargetProfile, LPCWSTR *pArguments, UINT32 argCount, const DxcDefine *pDefines, UINT32
		// defineCount, IDxcCompilerArgs **ppArgs );
		[PreserveSig]
		HRESULT BuildArguments([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pSourceName,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pEntryPoint, [MarshalAs(UnmanagedType.LPWStr)] string pTargetProfile,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 4)] string[]? pArguments, uint argCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] DxcDefine[] pDefines, int defineCount, out IDxcCompilerArgs ppArgs);

		/// <summary>Retrieves the hash and contents of a shader PDB.</summary>
		/// <param name="pPDBBlob">The blob containing the PDB.</param>
		/// <param name="ppHash">The address of the pointer that receives a pointer to the hash blob.</param>
		/// <param name="ppContainer">The address of the pointer that receives a pointer to the block containing the contents of the PDB.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcutils-getpdbcontents HRESULT GetPDBContents( IDxcBlob
		// *pPDBBlob, IDxcBlob **ppHash, IDxcBlob **ppContainer );
		[PreserveSig]
		HRESULT GetPDBContents([In] IDxcBlob pPDBBlob, out IDxcBlob ppHash, out IDxcBlob ppContainer);
	}

	/// <summary>
	/// <para>Interface representing the DXC shader validator.</para>
	/// <para>To obtain an instance of this interface, call <c>DxcCreateInstance</c> with <b>CLSID_DxcValidator</b>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcvalidator
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcValidator")]
	[ComImport, Guid("a6e82bd2-1fd7-4826-9811-2857e797f49a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcValidator
	{
		/// <summary>Validate a shader.</summary>
		/// <param name="pShader">The shader to validate.</param>
		/// <param name="Flags">Validation flags.</param>
		/// <param name="ppResult">Validation output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcvalidator-validate HRESULT Validate( IDxcBlob *pShader,
		// UINT32 Flags, IDxcOperationResult **ppResult );
		[PreserveSig]
		HRESULT Validate([In] IDxcBlob pShader, DxcValidatorFlags Flags, out IDxcOperationResult ppResult);
	}

	/// <summary>
	/// <para>Interface representing the DXC shader validator.</para>
	/// <para>To obtain an instance of this interface, call <c>DxcCreateInstance</c> with <b>CLSID_DxcValidator</b>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcvalidator2
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcValidator2")]
	[ComImport, Guid("458e1fd1-b1b2-4750-a6e1-9c10f03bed92"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcValidator2 : IDxcValidator
	{
		/// <summary>Validate a shader.</summary>
		/// <param name="pShader">The shader to validate.</param>
		/// <param name="Flags">Validation flags.</param>
		/// <param name="ppResult">Validation output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcvalidator-validate HRESULT Validate( IDxcBlob *pShader,
		// UINT32 Flags, IDxcOperationResult **ppResult );
		[PreserveSig]
		new HRESULT Validate([In] IDxcBlob pShader, DxcValidatorFlags Flags, out IDxcOperationResult ppResult);

		/// <summary>Validate a shader, with optional debug bitcode.</summary>
		/// <param name="pShader">The shader to validate.</param>
		/// <param name="Flags">Validation flags.</param>
		/// <param name="pOptDebugBitcode">Optional debug module bitcode to provide line numbers.</param>
		/// <param name="ppResult">Validation output status, buffer, and errors.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcvalidator2-validatewithdebug HRESULT ValidateWithDebug(
		// IDxcBlob *pShader, UINT32 Flags, DxcBuffer *pOptDebugBitcode, IDxcOperationResult **ppResult );
		[PreserveSig]
		HRESULT ValidateWithDebug([In] IDxcBlob pShader, DxcValidatorFlags Flags, [In, Optional] StructPointer<DxcBuffer> pOptDebugBitcode,
			out IDxcOperationResult ppResult);
	}

	/// <summary>
	/// <para>Represents PDB version information.</para>
	/// <para>To obtain an instance of this interface, call <c>IDxcPdbUtils::GetVersionInfo</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcversioninfo
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcVersionInfo")]
	[ComImport, Guid("b04f5b50-2059-4f12-a8ff-a1e0cde1cc7e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcVersionInfo
	{
		/// <summary>
		/// <para><c>pMajor</c></para>
		/// <para><c>pMinor</c></para>
		/// </summary>
		/// <param name="pMajor"/>
		/// <param name="pMinor"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcversioninfo-getversion HRESULT GetVersion( UINT32
		// *pMajor, UINT32 *pMinor );
		[PreserveSig]
		HRESULT GetVersion(out uint pMajor, out uint pMinor);

		/// <summary><c>pFlags</c></summary>
		/// <param name="pFlags"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcversioninfo-getflags HRESULT GetFlags( UINT32 *pFlags );
		[PreserveSig]
		HRESULT GetFlags(out DxcVersionInfoFlags pFlags);
	}

	/// <summary>
	/// <para>Represents PDB version information.</para>
	/// <para>
	/// To obtain an instance of this interface, call <c>IDxcPdbUtils::GetVersionInfo</c> to obtain a <b>IDxcVersionInfo</b> interface, and
	/// then use <b>QueryInterface</b> to obtain an instance of this interface from it.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcversioninfo2
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcVersionInfo2")]
	[ComImport, Guid("fb6904c4-42f0-4b62-9c46-983af7da7c83"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcVersionInfo2 : IDxcVersionInfo
	{
		/// <summary>
		/// <para><c>pMajor</c></para>
		/// <para><c>pMinor</c></para>
		/// </summary>
		/// <param name="pMajor"/>
		/// <param name="pMinor"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcversioninfo-getversion HRESULT GetVersion( UINT32
		// *pMajor, UINT32 *pMinor );
		[PreserveSig]
		new HRESULT GetVersion(out uint pMajor, out uint pMinor);

		/// <summary><c>pFlags</c></summary>
		/// <param name="pFlags"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcversioninfo-getflags HRESULT GetFlags( UINT32 *pFlags );
		[PreserveSig]
		new HRESULT GetFlags(out DxcVersionInfoFlags pFlags);

		/// <summary>
		/// <para><c>pCommitCount</c></para>
		/// <para>The total number of commits.</para>
		/// <para><c>pCommitHash</c></para>
		/// <para>The SHA of the latest commit. You must free this memory by using <c>CoTaskMemFree</c>.</para>
		/// </summary>
		/// <param name="pCommitCount">The total number of commits.</param>
		/// <param name="pCommitHash">The SHA of the latest commit. You must free this memory by using <c>CoTaskMemFree</c>.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcversioninfo2-getcommitinfo HRESULT GetCommitInfo( UINT32
		// *pCommitCount, char **pCommitHash );
		[PreserveSig]
		HRESULT GetCommitInfo(out uint pCommitCount, out IntPtr pCommitHash);
	}

	/// <summary>
	/// <para>Represents PDB version information.</para>
	/// <para>
	/// To obtain an instance of this interface, call <c>IDxcPdbUtils::GetVersionInfo</c> to obtain a <b>IDxcVersionInfo</b> interface, and
	/// then use <b>QueryInterface</b> to obtain an instance of this interface from it.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-idxcversioninfo3
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.IDxcVersionInfo3")]
	[ComImport, Guid("5e13e843-9d25-473c-9ad2-03b2d0b44b1e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDxcVersionInfo3
	{
		/// <summary>
		/// <para><c>pVersionString</c></para>
		/// <para>A custom version string for the compiler. You must free this memory by using <c>CoTaskMemFree</c>.</para>
		/// </summary>
		/// <param name="pVersionString">A custom version string for the compiler. You must free this memory by using <c>CoTaskMemFree</c>.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-idxcversioninfo3-getcustomversionstring HRESULT
		// GetCustomVersionString( char **pVersionString );
		[PreserveSig]
		HRESULT GetCustomVersionString([MarshalAs(UnmanagedType.LPWStr)] out string pVersionString);
	}

	/// <summary>
	/// <para>Compile a shader. Depending on the arguments, you can use this method to:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Compile a single entry point to the target shader model</description>
	/// </item>
	/// <item>
	/// <description>Compile a library to a library target ( <c>-T lib_*</c>)</description>
	/// </item>
	/// <item>
	/// <description>Compile a root signature ( <c>-T rootsig_*</c>),</description>
	/// </item>
	/// <item>
	/// <description>Preprocess HLSL source ( <c>-P</c>)</description>
	/// </item>
	/// </list>
	/// <para>You can use <c>IDxcUtils::BuildArguments</c> to assist in building the pArguments and argCount arguments.</para>
	/// </summary>
	/// <param name="cmp">The IDxcCompiler3 instance.</param>
	/// <param name="pSource">The source text to compile.</param>
	/// <param name="pArguments">An array of pointers to arguments.</param>
	/// <param name="pIncludeHandler">An optional user-provided interface to handle <c>#include</c> directives.</param>
	/// <param name="ppResult">An <c>IDxcResult</c> representing the compiler output status, buffer, and errors.</param>
	/// <returns>An error code.</returns>
	public static HRESULT Compile(this IDxcCompiler3 cmp, in DxcBuffer pSource, [In, Optional] string[]? pArguments,
		[In, Optional] IDxcIncludeHandler? pIncludeHandler, out IDxcResult ppResult)
	{
		var hr = cmp.Compile(pSource, pArguments, (uint)(pArguments?.Length ?? 0), pIncludeHandler, typeof(IDxcResult).GUID, out var ppv);
		ppResult = (IDxcResult)ppv;
		return hr;
	}

	/// <summary>Disassemble a program.</summary>
	/// <param name="cmp">The IDxcCompiler3 instance.</param>
	/// <param name="pObject">The program to disassemble: dxil container or bitcode.</param>
	/// <param name="ppResult">An <c>IDxcResult</c> representing the compiler output status, buffer, and errors.</param>
	/// <returns>An error code.</returns>
	public static HRESULT Disassemble(this IDxcCompiler3 cmp, in DxcBuffer pObject, out IDxcResult ppResult)
	{
		var hr = cmp.Disassemble(pObject, typeof(IDxcResult).GUID, out var ppv);
		ppResult = (IDxcResult)ppv;
		return hr;
	}

	/// <summary>Makes a <see cref="uint"/> from four characters.</summary>
	/// <param name="ch0">The first character.</param>
	/// <param name="ch1">The second character.</param>
	/// <param name="ch2">The third character.</param>
	/// <param name="ch3">The fourth character.</param>
	/// <returns>A 32-bit value composed from the ANSI values of the characters.</returns>
	public static uint DXC_FOURCC(char ch0, char ch1, char ch2, char ch3) => ch0 | ((uint)ch1 << 8) | ((uint)ch2 << 16) | ((uint)ch3 << 24);

	/// <summary>Creates a single uninitialized object of the class associated with a specified CLSID. Also see <c>DxcCreateInstance2</c>.</summary>
	/// <param name="rclsid">The CLSID associated with the data and code that will be used to create the object.</param>
	/// <param name="riid">A reference to the identifier of the interface to be used to communicate with the object.</param>
	/// <param name="ppv">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, <c>*ppv</c> contains the
	/// requested interface pointer. Upon failure, <c>*ppv</c> contains NULL.
	/// </param>
	/// <returns>While this function is similar to <b>CoCreateInstance</b>, there's no COM involvement.</returns>
	/// <remarks>
	/// <para>
	/// To make it more convenient for you to use <b>GetProcAddress</b> to call <b>DxcCreateInstance</b>, the <b>DxcCreateInstanceProc</b>
	/// typedef is provided:
	/// </para>
	/// <para><c>typedef HRESULT (__stdcall *DxcCreateInstanceProc)( _In_ REFCLSID rclsid, _In_ REFIID riid, _Out_ LPVOID* ppv );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-dxccreateinstance DXC_API_IMPORT HRESULT DxcCreateInstance(
	// REFCLSID rclsid, REFIID riid, LPVOID *ppv );
	[PInvokeData("dxcapi.h", MSDNShortId = "NF:dxcapi.DxcCreateInstance")]
	[DllImport(Lib_Dxilconv, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT DxcCreateInstance(in Guid rclsid, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object? ppv);

	/// <summary>Creates a single uninitialized object of the class associated with a specified CLSID. Also see <c>DxcCreateInstance2</c>.</summary>
	/// <typeparam name="T">The type of the interface to be used to communicate with the object.</typeparam>
	/// <param name="rclsid">The CLSID associated with the data and code that will be used to create the object.</param>
	/// <param name="ppv">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, <c>*ppv</c> contains the
	/// requested interface pointer. Upon failure, <c>*ppv</c> contains NULL.
	/// </param>
	/// <returns>While this function is similar to <b>CoCreateInstance</b>, there's no COM involvement.</returns>
	/// <remarks>
	/// <para>
	/// To make it more convenient for you to use <b>GetProcAddress</b> to call <b>DxcCreateInstance</b>, the <b>DxcCreateInstanceProc</b>
	/// typedef is provided:
	/// </para>
	/// <para><c>typedef HRESULT (__stdcall *DxcCreateInstanceProc)( _In_ REFCLSID rclsid, _In_ REFIID riid, _Out_ LPVOID* ppv );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-dxccreateinstance DXC_API_IMPORT HRESULT DxcCreateInstance(
	// REFCLSID rclsid, REFIID riid, LPVOID *ppv );
	[PInvokeData("dxcapi.h", MSDNShortId = "NF:dxcapi.DxcCreateInstance")]
	public static HRESULT DxcCreateInstance<T>(in Guid rclsid, out T? ppv) where T : class
	{
		var hr = DxcCreateInstance(rclsid, typeof(T).GUID, out var pv);
		ppv = hr.Succeeded ? (T)pv! : null;
		return hr;
	}

	/// <summary>
	/// Creates a single uninitialized object of the class associated with a specified CLSID (can be used to create an instance of the
	/// compiler with a custom memory allocator). Also see <c>DxcCreateInstance</c>.
	/// </summary>
	/// <param name="pMalloc">An <b>IMalloc</b> interface pointer representing a custom memory allocator.</param>
	/// <param name="rclsid">The CLSID associated with the data and code that will be used to create the object.</param>
	/// <param name="riid">A reference to the identifier of the interface to be used to communicate with the object.</param>
	/// <param name="ppv">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, <c>*ppv</c> contains the
	/// requested interface pointer. Upon failure, <c>*ppv</c> contains NULL.
	/// </param>
	/// <returns>While this function is similar to <b>CoCreateInstance</b>, there's no COM involvement.</returns>
	/// <remarks>
	/// <para>
	/// To make it more convenient for you to use <b>GetProcAddress</b> to call <b>DxcCreateInstance2</b>, the <b>DxcCreateInstance2Proc</b>
	/// typedef is provided:
	/// </para>
	/// <para>
	/// <c>typedef HRESULT(__stdcall *DxcCreateInstance2Proc)( _In_ IMalloc *pMalloc, _In_ REFCLSID rclsid, _In_ REFIID riid, _Out_ LPVOID*
	/// ppv );</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-dxccreateinstance2 DXC_API_IMPORT HRESULT DxcCreateInstance2(
	// IMalloc *pMalloc, REFCLSID rclsid, REFIID riid, LPVOID *ppv );
	[PInvokeData("dxcapi.h", MSDNShortId = "NF:dxcapi.DxcCreateInstance2")]
	[DllImport(Lib_Dxilconv, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT DxcCreateInstance2(IMalloc pMalloc, in Guid rclsid, in Guid riid,
	   [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object? ppv);

	/// <summary>
	/// Creates a single uninitialized object of the class associated with a specified CLSID (can be used to create an instance of the
	/// compiler with a custom memory allocator). Also see <c>DxcCreateInstance</c>.
	/// </summary>
	/// <typeparam name="T">The type of the interface to be used to communicate with the object.</typeparam>
	/// <param name="pMalloc">An <b>IMalloc</b> interface pointer representing a custom memory allocator.</param>
	/// <param name="rclsid">The CLSID associated with the data and code that will be used to create the object.</param>
	/// <param name="ppv">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, <c>*ppv</c> contains the
	/// requested interface pointer. Upon failure, <c>*ppv</c> contains NULL.
	/// </param>
	/// <returns>While this function is similar to <b>CoCreateInstance</b>, there's no COM involvement.</returns>
	/// <remarks>
	/// <para>
	/// To make it more convenient for you to use <b>GetProcAddress</b> to call <b>DxcCreateInstance2</b>, the <b>DxcCreateInstance2Proc</b>
	/// typedef is provided:
	/// </para>
	/// <para>
	/// <c>typedef HRESULT(__stdcall *DxcCreateInstance2Proc)( _In_ IMalloc *pMalloc, _In_ REFCLSID rclsid, _In_ REFIID riid, _Out_ LPVOID*
	/// ppv );</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/nf-dxcapi-dxccreateinstance2 DXC_API_IMPORT HRESULT DxcCreateInstance2(
	// IMalloc *pMalloc, REFCLSID rclsid, REFIID riid, LPVOID *ppv );
	[PInvokeData("dxcapi.h", MSDNShortId = "NF:dxcapi.DxcCreateInstance2")]
	public static HRESULT DxcCreateInstance2<T>(IMalloc pMalloc, in Guid rclsid, out T? ppv) where T : class
	{
		var hr = DxcCreateInstance2(pMalloc, rclsid, typeof(T).GUID, out var pv);
		ppv = hr.Succeeded ? (T)pv! : null;
		return hr;
	}

	/// <summary>Gets the SHA of the latest commit.</summary>
	/// <param name="vi2">The <see cref="IDxcVersionInfo2"/> instance.</param>
	/// <param name="pCommitHash">The SHA of the latest commit.</param>
	/// <returns></returns>
	public static HRESULT GetCommitInfo(this IDxcVersionInfo2 vi2, out SafeCoTaskMemHandle pCommitHash)
	{
		var hr = vi2.GetCommitInfo(out var count, out var ptr);
		pCommitHash = new(ptr, count, true);
		return hr;
	}

	/// <summary>A FourCC value that represents a container part.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DXC_PART
	{
		private readonly uint Value;

		/// <summary>Initializes a new instance of the <see cref="DXC_PART"/> struct.</summary>
		/// <param name="value">The value.</param>
		public DXC_PART(uint value) => Value = value;

		/// <summary>Initializes a new instance of the <see cref="DXC_PART"/> struct.</summary>
		/// <param name="ch0">The first character.</param>
		/// <param name="ch1">The second character.</param>
		/// <param name="ch2">The third character.</param>
		/// <param name="ch3">The fourth character.</param>
		public DXC_PART(char ch0, char ch1, char ch2, char ch3) => Value = DXC_FOURCC(ch0, ch1, ch2, ch3);

		/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="DXC_PART"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator DXC_PART(uint value) => new(value);

		/// <summary>Performs an implicit conversion from <see cref="DXC_PART"/> to <see cref="System.UInt32"/>.</summary>
		/// <param name="part">The part.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator uint(DXC_PART part) => part.Value;

		/// <summary/>
		public static readonly uint DXC_PART_PDB = DXC_FOURCC('I', 'L', 'D', 'B');

		/// <summary/>
		public static readonly uint DXC_PART_PDB_NAME = DXC_FOURCC('I', 'L', 'D', 'N');

		/// <summary/>
		public static readonly uint DXC_PART_PRIVATE_DATA = DXC_FOURCC('P', 'R', 'I', 'V');

		/// <summary/>
		public static readonly uint DXC_PART_ROOT_SIGNATURE = DXC_FOURCC('R', 'T', 'S', '0');

		/// <summary/>
		public static readonly uint DXC_PART_DXIL = DXC_FOURCC('D', 'X', 'I', 'L');

		/// <summary/>
		public static readonly uint DXC_PART_REFLECTION_DATA = DXC_FOURCC('S', 'T', 'A', 'T');

		/// <summary/>
		public static readonly uint DXC_PART_SHADER_HASH = DXC_FOURCC('H', 'A', 'S', 'H');

		/// <summary/>
		public static readonly uint DXC_PART_INPUT_SIGNATURE = DXC_FOURCC('I', 'S', 'G', '1');

		/// <summary/>
		public static readonly uint DXC_PART_OUTPUT_SIGNATURE = DXC_FOURCC('O', 'S', 'G', '1');

		/// <summary/>
		public static readonly uint DXC_PART_PATCH_CONSTANT_SIGNATURE = DXC_FOURCC('P', 'S', 'G', '1');
	}

	/// <summary>
	/// <para><c>pName</c></para>
	/// <para><c>pValue</c></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-dxcargpair struct DxcArgPair { const WCHAR *pName; const WCHAR
	// *pValue; };
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.DxcArgPair")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DxcArgPair
	{
		/// <summary/>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pName;

		/// <summary/>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pValue;
	}

	/// <summary>Structure for supplying bytes or text input to Dxc APIs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-dxctext typedef struct DxcBuffer { LPCVOID Ptr; SIZE_T Size;
	// UINT Encoding; } DxcText;
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.DxcBuffer")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DxcBuffer
	{
		/// <summary>A pointer to the start of the buffer.</summary>
		public IntPtr Ptr;

		/// <summary>The size of the buffer, in bytes.</summary>
		public SizeT Size;

		/// <summary>The encoding of the buffer. Use Encoding == 0 for non-text bytes, ANSI text, or unknown with byte-order mark (BOM).</summary>
		public uint Encoding;
	}

	/// <summary>Structure for supplying defines to Dxc APIs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-dxcdefine struct DxcDefine { LPCWSTR Name; LPCWSTR Value; };
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.DxcDefine")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DxcDefine
	{
		/// <summary>The define name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;

		/// <summary>An optional value for the define.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Value;
	}

	/// <summary>Hash digest type for ShaderHash.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxcapi/ns-dxcapi-dxcshaderhash typedef struct DxcShaderHash { UINT32 Flags; BYTE
	// HashDigest[16]; } DxcShaderHash;
	[PInvokeData("dxcapi.h", MSDNShortId = "NS:dxcapi.DxcShaderHash")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DxcShaderHash
	{
		/// <summary>One of <b>DXC_HASHFLAG_Xxx</b>.</summary>
		public DXC_HASHFLAG Flags;

		/// <summary>The hash digest.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] HashDigest;
	}
}