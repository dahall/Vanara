namespace Vanara.PInvoke;

public static partial class D3D11
{
	/// <summary>Identifies how to check multisample quality levels.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ne-d3d11_2-d3d11_check_multisample_quality_levels_flag typedef enum
	// D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG { D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_TILED_RESOURCE = 0x1 } ;
	[PInvokeData("d3d11_2.h", MSDNShortId = "NE:d3d11_2.D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG")]
	[Flags]
	public enum D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Indicates to check the multisample quality levels of a tiled resource.</para>
		/// </summary>
		D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_TILED_RESOURCE = 0x1,
	}

	/// <summary>Identifies how to copy a tile.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ne-d3d11_2-d3d11_tile_copy_flag typedef enum D3D11_TILE_COPY_FLAG {
	// D3D11_TILE_COPY_NO_OVERWRITE = 0x1, D3D11_TILE_COPY_LINEAR_BUFFER_TO_SWIZZLED_TILED_RESOURCE = 0x2,
	// D3D11_TILE_COPY_SWIZZLED_TILED_RESOURCE_TO_LINEAR_BUFFER = 0x4 } ;
	[PInvokeData("d3d11_2.h", MSDNShortId = "NE:d3d11_2.D3D11_TILE_COPY_FLAG")]
	[Flags]
	public enum D3D11_TILE_COPY_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Indicates that the GPU isn't currently referencing any of the portions of destination memory being written.</para>
		/// </summary>
		D3D11_TILE_COPY_NO_OVERWRITE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>
		/// Indicates that the ID3D11DeviceContext2::CopyTiles operation involves copying a linear buffer to a swizzled tiled resource. This
		/// means to copy tile data from the specified buffer location, reading tiles sequentially, to the specified tile region (in x,y,z
		/// order if the region is a box), swizzling to optimal hardware memory layout as needed.
		/// </para>
		/// <para>
		/// In this ID3D11DeviceContext2::CopyTiles call, you specify the source data with the pBuffer parameter and the destination with
		/// the pTiledResource parameter.
		/// </para>
		/// </summary>
		D3D11_TILE_COPY_LINEAR_BUFFER_TO_SWIZZLED_TILED_RESOURCE = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>
		/// Indicates that the ID3D11DeviceContext2::CopyTiles operation involves copying a swizzled tiled resource to a linear buffer. This
		/// means to copy tile data from the tile region, reading tiles sequentially (in x,y,z order if the region is a box), to the
		/// specified buffer location, deswizzling to linear memory layout as needed.
		/// </para>
		/// <para>
		/// In this ID3D11DeviceContext2::CopyTiles call, you specify the source data with the pTiledResource parameter and the destination
		/// with the pBuffer parameter.
		/// </para>
		/// </summary>
		D3D11_TILE_COPY_SWIZZLED_TILED_RESOURCE_TO_LINEAR_BUFFER = 0x4,
	}

	/// <summary>Identifies how to perform a tile-mapping operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ne-d3d11_2-d3d11_tile_mapping_flag typedef enum D3D11_TILE_MAPPING_FLAG {
	// D3D11_TILE_MAPPING_NO_OVERWRITE = 0x1 } ;
	[PInvokeData("d3d11_2.h", MSDNShortId = "NE:d3d11_2.D3D11_TILE_MAPPING_FLAG")]
	[Flags]
	public enum D3D11_TILE_MAPPING_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Indicates that no overwriting of tiles occurs in the tile-mapping operation.</para>
		/// </summary>
		D3D11_TILE_MAPPING_NO_OVERWRITE = 0x1,
	}

	/// <summary>Specifies a range of tile mappings to use with ID3D11DeviceContext2::UpdateTiles.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ne-d3d11_2-d3d11_tile_range_flag typedef enum D3D11_TILE_RANGE_FLAG {
	// D3D11_TILE_RANGE_NULL = 0x1, D3D11_TILE_RANGE_SKIP = 0x2, D3D11_TILE_RANGE_REUSE_SINGLE_TILE = 0x4 } ;
	[PInvokeData("d3d11_2.h", MSDNShortId = "NE:d3d11_2.D3D11_TILE_RANGE_FLAG")]
	[Flags]
	public enum D3D11_TILE_RANGE_FLAG
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x1</para>
		///   <para>The tile range is NULL.</para>
		/// </summary>
		D3D11_TILE_RANGE_NULL = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Skip the tile range.</para>
		/// </summary>
		D3D11_TILE_RANGE_SKIP = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Reuse a single tile in the tile range.</para>
		/// </summary>
		D3D11_TILE_RANGE_REUSE_SINGLE_TILE = 0x4,
	}

	/// <summary>
	/// The device interface represents a virtual adapter; it is used to create resources. <c>ID3D11Device2</c> adds new methods to those in ID3D11Device1.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nn-d3d11_2-id3d11device2
	[PInvokeData("d3d11_2.h", MSDNShortId = "NN:d3d11_2.ID3D11Device2")]
	[ComImport, Guid("9d06dffa-d1e5-4d07-83a8-1bb123f2f841"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Device2 : ID3D11Device1, ID3D11Device
	{
		/// <summary>Creates a buffer (vertex buffer, index buffer, or shader-constant buffer).</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_BUFFER_DESC*</c></para>
		/// <para>A pointer to a D3D11_BUFFER_DESC structure that describes the buffer.</para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to a D3D11_SUBRESOURCE_DATA structure that describes the initialization data; use <c>NULL</c> to allocate space only
		/// (with the exception that it cannot be <c>NULL</c> if the usage flag is <c>D3D11_USAGE_IMMUTABLE</c>).
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the buffer is undefined. In this case,
		/// you need to write the buffer content some other way before the resource is read.
		/// </para>
		/// </param>
		/// <param name="ppBuffer">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>
		/// Address of a pointer to the ID3D11Buffer interface for the buffer object created. Set this parameter to <c>NULL</c> to validate
		/// the other input parameters ( <c>S_FALSE</c> indicates a pass).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns <c>E_OUTOFMEMORY</c> if there is insufficient memory to create the buffer. See Direct3D 11 Return Codes for
		/// other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>For example code, see How to: Create a Vertex Buffer, How to: Create an Index Buffer or How to: Create a Constant Buffer.</para>
		/// <para>
		/// For a constant buffer ( <c>BindFlags</c> of D3D11_BUFFER_DESC set to D3D11_BIND_CONSTANT_BUFFER), you must set the
		/// <c>ByteWidth</c> value of <c>D3D11_BUFFER_DESC</c> in multiples of 16, and less than or equal to <c>D3D11_REQ_CONSTANT_BUFFER_ELEMENT_COUNT</c>.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems, provides the following new functionality
		/// for <c>CreateBuffer</c>:
		/// </para>
		/// <para>
		/// You can create a constant buffer that is larger than the maximum constant buffer size that a shader can access (4096
		/// 32-bit*4-component constants – 64KB). When you bind the constant buffer to the pipeline (for example, via PSSetConstantBuffers
		/// or PSSetConstantBuffers1), you can define a range of the buffer that the shader can access that fits within the 4096 constant limit.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime (available in Windows 8 and later operating systems) emulates this feature for feature level 9.1, 9.2,
		/// and 9.3; therefore, this feature is supported for feature level 9.1, 9.2, and 9.3.
		/// </para>
		/// <para>This feature is always available on new drivers for feature level 10 and higher.</para>
		/// <para>
		/// On runtimes older than Direct3D 11.1, a call to <c>CreateBuffer</c> to request a constant buffer that is larger than 4096 fails.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createbuffer HRESULT CreateBuffer( [in] const
		// D3D11_BUFFER_DESC *pDesc, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional] ID3D11Buffer **ppBuffer );
		[PreserveSig]
		new HRESULT CreateBuffer(in D3D11_BUFFER_DESC pDesc, [In, Optional] StructPointer<D3D11_SUBRESOURCE_DATA> pInitialData,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11Buffer? ppBuffer);

		/// <summary>Creates an array of 1D textures.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_TEXTURE1D_DESC*</c></para>
		/// <para>
		/// A pointer to a D3D11_TEXTURE1D_DESC structure that describes a 1D texture resource. To create a typeless resource that can be
		/// interpreted at runtime into different, compatible formats, specify a typeless format in the texture description. To generate
		/// mipmap levels automatically, set the number of mipmap levels to 0.
		/// </para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_SUBRESOURCE_DATA structures that describe subresources for the 1D texture resource. Applications
		/// can't specify <c>NULL</c> for <c>pInitialData</c> when creating IMMUTABLE resources (see D3D11_USAGE). If the resource is
		/// multisampled, <c>pInitialData</c> must be <c>NULL</c> because multisampled resources cannot be initialized with data when they
		/// are created.
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the resource is undefined. In this
		/// case, you need to write the resource content some other way before the resource is read.
		/// </para>
		/// <para>
		/// You can determine the size of this array from values in the <c>MipLevels</c> and <c>ArraySize</c> members of the
		/// D3D11_TEXTURE1D_DESC structure to which <c>pDesc</c> points by using the following calculation:
		/// </para>
		/// <para>MipLevels * ArraySize</para>
		/// <para>For more information about this array size, see Remarks.</para>
		/// </param>
		/// <param name="ppTexture1D">
		/// <para>Type: <c>ID3D11Texture1D**</c></para>
		/// <para>
		/// A pointer to a buffer that receives a pointer to a ID3D11Texture1D interface for the created texture. Set this parameter to
		/// <c>NULL</c> to validate the other input parameters (the method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is S_OK. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateTexture1D</c> creates a 1D texture resource, which can contain a number of 1D subresources. The number of textures is
		/// specified in the texture description. All textures in a resource must have the same format, size, and number of mipmap levels.
		/// </para>
		/// <para>
		/// All resources are made up of one or more subresources. To load data into the texture, applications can supply the data initially
		/// as an array of D3D11_SUBRESOURCE_DATA structures pointed to by <c>pInitialData</c>, or they can use one of the D3DX texture
		/// functions such as D3DX11CreateTextureFromFile.
		/// </para>
		/// <para>For a 32 width texture with a full mipmap chain, the <c>pInitialData</c> array has the following 6 elements:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>pInitialData[0] = 32x1</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[1] = 16x1</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[2] = 8x1</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[3] = 4x1</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[4] = 2x1</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[5] = 1x1</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createtexture1d HRESULT CreateTexture1D( [in]
		// const D3D11_TEXTURE1D_DESC *pDesc, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional] ID3D11Texture1D
		// **ppTexture1D );
		[PreserveSig]
		new HRESULT CreateTexture1D(in D3D11_TEXTURE1D_DESC pDesc, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11Texture1D? ppTexture1D);

		/// <summary>Create an array of 2D textures.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_TEXTURE2D_DESC*</c></para>
		/// <para>
		/// A pointer to a D3D11_TEXTURE2D_DESC structure that describes a 2D texture resource. To create a typeless resource that can be
		/// interpreted at runtime into different, compatible formats, specify a typeless format in the texture description. To generate
		/// mipmap levels automatically, set the number of mipmap levels to 0.
		/// </para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_SUBRESOURCE_DATA structures that describe subresources for the 2D texture resource. Applications
		/// can't specify <c>NULL</c> for <c>pInitialData</c> when creating IMMUTABLE resources (see D3D11_USAGE). If the resource is
		/// multisampled, <c>pInitialData</c> must be <c>NULL</c> because multisampled resources cannot be initialized with data when they
		/// are created.
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the resource is undefined. In this
		/// case, you need to write the resource content some other way before the resource is read.
		/// </para>
		/// <para>
		/// You can determine the size of this array from values in the <c>MipLevels</c> and <c>ArraySize</c> members of the
		/// D3D11_TEXTURE2D_DESC structure to which <c>pDesc</c> points by using the following calculation:
		/// </para>
		/// <para>MipLevels * ArraySize</para>
		/// <para>For more information about this array size, see Remarks.</para>
		/// </param>
		/// <param name="ppTexture2D">
		/// <para>Type: <c>ID3D11Texture2D**</c></para>
		/// <para>
		/// A pointer to a buffer that receives a pointer to a ID3D11Texture2D interface for the created texture. Set this parameter to
		/// <c>NULL</c> to validate the other input parameters (the method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is S_OK. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateTexture2D</c> creates a 2D texture resource, which can contain a number of 2D subresources. The number of textures is
		/// specified in the texture description. All textures in a resource must have the same format, size, and number of mipmap levels.
		/// </para>
		/// <para>
		/// All resources are made up of one or more subresources. To load data into the texture, applications can supply the data initially
		/// as an array of D3D11_SUBRESOURCE_DATA structures pointed to by <c>pInitialData</c>, or it may use one of the D3DX texture
		/// functions such as D3DX11CreateTextureFromFile.
		/// </para>
		/// <para>For a 32 x 32 texture with a full mipmap chain, the <c>pInitialData</c> array has the following 6 elements:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>pInitialData[0] = 32x32</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[1] = 16x16</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[2] = 8x8</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[3] = 4x4</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[4] = 2x2</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[5] = 1x1</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createtexture2d HRESULT CreateTexture2D( [in]
		// const D3D11_TEXTURE2D_DESC *pDesc, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional] ID3D11Texture2D
		// **ppTexture2D );
		[PreserveSig]
		new HRESULT CreateTexture2D(in D3D11_TEXTURE2D_DESC pDesc, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11Texture2D? ppTexture2D);

		/// <summary>Create a single 3D texture.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_TEXTURE3D_DESC*</c></para>
		/// <para>
		/// A pointer to a D3D11_TEXTURE3D_DESC structure that describes a 3D texture resource. To create a typeless resource that can be
		/// interpreted at runtime into different, compatible formats, specify a typeless format in the texture description. To generate
		/// mipmap levels automatically, set the number of mipmap levels to 0.
		/// </para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_SUBRESOURCE_DATA structures that describe subresources for the 3D texture resource. Applications
		/// cannot specify <c>NULL</c> for <c>pInitialData</c> when creating IMMUTABLE resources (see D3D11_USAGE). If the resource is
		/// multisampled, <c>pInitialData</c> must be <c>NULL</c> because multisampled resources cannot be initialized with data when they
		/// are created.
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the resource is undefined. In this
		/// case, you need to write the resource content some other way before the resource is read.
		/// </para>
		/// <para>
		/// You can determine the size of this array from the value in the <c>MipLevels</c> member of the D3D11_TEXTURE3D_DESC structure to
		/// which <c>pDesc</c> points. Arrays of 3D volume textures are not supported.
		/// </para>
		/// <para>For more information about this array size, see Remarks.</para>
		/// </param>
		/// <param name="ppTexture3D">
		/// <para>Type: <c>ID3D11Texture3D**</c></para>
		/// <para>
		/// A pointer to a buffer that receives a pointer to a ID3D11Texture3D interface for the created texture. Set this parameter to
		/// <c>NULL</c> to validate the other input parameters (the method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is S_OK. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateTexture3D</c> creates a 3D texture resource, which can contain a number of 3D subresources. The number of textures is
		/// specified in the texture description. All textures in a resource must have the same format, size, and number of mipmap levels.
		/// </para>
		/// <para>
		/// All resources are made up of one or more subresources. To load data into the texture, applications can supply the data initially
		/// as an array of D3D11_SUBRESOURCE_DATA structures pointed to by <c>pInitialData</c>, or they can use one of the D3DX texture
		/// functions such as D3DX11CreateTextureFromFile.
		/// </para>
		/// <para>
		/// Each element of <c>pInitialData</c> provides all of the slices that are defined for a given miplevel. For example, for a 32 x 32
		/// x 4 volume texture with a full mipmap chain, the array has the following 6 elements:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>pInitialData[0] = 32x32 with 4 slices</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[1] = 16x16 with 2 slices</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[2] = 8x8 with 1 slice</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[3] = 4x4 with 1 slice</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[4] = 2x2 with 1 slice</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[5] = 1x1 with 1 slice</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createtexture3d HRESULT CreateTexture3D( [in]
		// const D3D11_TEXTURE3D_DESC *pDesc, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional] ID3D11Texture3D
		// **ppTexture3D );
		[PreserveSig]
		new HRESULT CreateTexture3D(in D3D11_TEXTURE3D_DESC pDesc, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11Texture3D? ppTexture3D);

		/// <summary>Create a shader-resource view for accessing data in a resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// Pointer to the resource that will serve as input to a shader. This resource must have been created with the
		/// D3D11_BIND_SHADER_RESOURCE flag.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_SHADER_RESOURCE_VIEW_DESC*</c></para>
		/// <para>
		/// Pointer to a shader-resource view description (see D3D11_SHADER_RESOURCE_VIEW_DESC). Set this parameter to <c>NULL</c> to create
		/// a view that accesses the entire resource (using the format the resource was created with).
		/// </para>
		/// </param>
		/// <param name="ppSRView">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11ShaderResourceView. Set this parameter to <c>NULL</c> to validate the other input parameters
		/// (the method will return <c>S_FALSE</c> if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A resource is made up of one or more subresources; a view identifies which subresources to allow the pipeline to access. In
		/// addition, each resource is bound to the pipeline using a view. A shader-resource view is designed to bind any buffer or texture
		/// resource to the shader stages using the following API methods: ID3D11DeviceContext::VSSetShaderResources,
		/// ID3D11DeviceContext::GSSetShaderResources and ID3D11DeviceContext::PSSetShaderResources.
		/// </para>
		/// <para>Because a view is fully typed, this means that typeless resources become fully typed when bound to the pipeline.</para>
		/// <para>
		/// <c>Note</c>  To successfully create a shader-resource view from a typeless buffer (for example,
		/// DXGI_FORMAT_R32G32B32A32_TYPELESS), you must set the D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS flag when you create the buffer.
		/// </para>
		/// <para></para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, allows you to use <c>CreateShaderResourceView</c> for the
		/// following new purpose.
		/// </para>
		/// <para>
		/// You can create shader-resource views of video resources so that Direct3D shaders can process those shader-resource views. These
		/// video resources are either Texture2D or Texture2DArray. The value in the <c>ViewDimension</c> member of the
		/// D3D11_SHADER_RESOURCE_VIEW_DESC structure for a created shader-resource view must match the type of video resource,
		/// D3D11_SRV_DIMENSION_TEXTURE2D for Texture2D and D3D11_SRV_DIMENSION_TEXTURE2DARRAY for Texture2DArray. Additionally, the format
		/// of the underlying video resource restricts the formats that the view can use. The video resource format values on the
		/// DXGI_FORMAT reference page specify the format values that views are restricted to.
		/// </para>
		/// <para>
		/// The runtime read+write conflict prevention logic (which stops a resource from being bound as an SRV and RTV or UAV at the same
		/// time) treats views of different parts of the same video surface as conflicting for simplicity. Therefore, the runtime does not
		/// allow an application to read from luma while the application simultaneously renders to chroma in the same surface even though
		/// the hardware might allow these simultaneous operations.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createshaderresourceview HRESULT
		// CreateShaderResourceView( [in] ID3D11Resource *pResource, [in, optional] const D3D11_SHADER_RESOURCE_VIEW_DESC *pDesc, [out,
		// optional] ID3D11ShaderResourceView **ppSRView );
		[PreserveSig]
		new HRESULT CreateShaderResourceView([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_SHADER_RESOURCE_VIEW_DESC> pDesc,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11ShaderResourceView? ppSRView);

		/// <summary>Creates a view for accessing an unordered access resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Pointer to an ID3D11Resource that represents a resources that will serve as an input to a shader.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_UNORDERED_ACCESS_VIEW_DESC*</c></para>
		/// <para>
		/// Pointer to an D3D11_UNORDERED_ACCESS_VIEW_DESC that represents a shader-resource view description. Set this parameter to
		/// <c>NULL</c> to create a view that accesses the entire resource (using the format the resource was created with).
		/// </para>
		/// </param>
		/// <param name="ppUAView">
		/// <para>Type: <c>ID3D11UnorderedAccessView**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11UnorderedAccessView that represents an unordered-access view. Set this parameter to <c>NULL</c>
		/// to validate the other input parameters (the method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, allows you to use <c>CreateUnorderedAccessView</c> for
		/// the following new purpose.
		/// </para>
		/// <para>
		/// You can create unordered-access views of video resources so that Direct3D shaders can process those unordered-access views.
		/// These video resources are either Texture2D or Texture2DArray. The value in the <c>ViewDimension</c> member of the
		/// D3D11_UNORDERED_ACCESS_VIEW_DESC structure for a created unordered-access view must match the type of video resource,
		/// D3D11_UAV_DIMENSION_TEXTURE2D for Texture2D and D3D11_UAV_DIMENSION_TEXTURE2DARRAY for Texture2DArray. Additionally, the format
		/// of the underlying video resource restricts the formats that the view can use. The video resource format values on the
		/// DXGI_FORMAT reference page specify the format values that views are restricted to.
		/// </para>
		/// <para>
		/// The runtime read+write conflict prevention logic (which stops a resource from being bound as an SRV and RTV or UAV at the same
		/// time) treats views of different parts of the same video surface as conflicting for simplicity. Therefore, the runtime does not
		/// allow an application to read from luma while the application simultaneously renders to chroma in the same surface even though
		/// the hardware might allow these simultaneous operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createunorderedaccessview HRESULT
		// CreateUnorderedAccessView( [in] ID3D11Resource *pResource, [in, optional] const D3D11_UNORDERED_ACCESS_VIEW_DESC *pDesc, [out,
		// optional] ID3D11UnorderedAccessView **ppUAView );
		[PreserveSig]
		new HRESULT CreateUnorderedAccessView([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_UNORDERED_ACCESS_VIEW_DESC> pDesc,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11UnorderedAccessView? ppUAView);

		/// <summary>Creates a render-target view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// Pointer to a ID3D11Resource that represents a render target. This resource must have been created with the
		/// D3D11_BIND_RENDER_TARGET flag.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_RENDER_TARGET_VIEW_DESC*</c></para>
		/// <para>
		/// Pointer to a D3D11_RENDER_TARGET_VIEW_DESC that represents a render-target view description. Set this parameter to <c>NULL</c>
		/// to create a view that accesses all of the subresources in mipmap level 0.
		/// </para>
		/// </param>
		/// <param name="ppRTView">
		/// <para>Type: <c>ID3D11RenderTargetView**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11RenderTargetView. Set this parameter to <c>NULL</c> to validate the other input parameters (the
		/// method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>A render-target view can be bound to the output-merger stage by calling ID3D11DeviceContext::OMSetRenderTargets.</para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, allows you to use <c>CreateRenderTargetView</c> for the
		/// following new purpose.
		/// </para>
		/// <para>
		/// You can create render-target views of video resources so that Direct3D shaders can process those render-target views. These
		/// video resources are either Texture2D or Texture2DArray. The value in the <c>ViewDimension</c> member of the
		/// D3D11_RENDER_TARGET_VIEW_DESC structure for a created render-target view must match the type of video resource,
		/// D3D11_RTV_DIMENSION_TEXTURE2D for Texture2D and D3D11_RTV_DIMENSION_TEXTURE2DARRAY for Texture2DArray. Additionally, the format
		/// of the underlying video resource restricts the formats that the view can use. The video resource format values on the
		/// DXGI_FORMAT reference page specify the format values that views are restricted to.
		/// </para>
		/// <para>
		/// The runtime read+write conflict prevention logic (which stops a resource from being bound as an SRV and RTV or UAV at the same
		/// time) treats views of different parts of the same video surface as conflicting for simplicity. Therefore, the runtime does not
		/// allow an application to read from luma while the application simultaneously renders to chroma in the same surface even though
		/// the hardware might allow these simultaneous operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createrendertargetview HRESULT
		// CreateRenderTargetView( [in] ID3D11Resource *pResource, [in, optional] const D3D11_RENDER_TARGET_VIEW_DESC *pDesc, [out,
		// optional] ID3D11RenderTargetView **ppRTView );
		[PreserveSig]
		new HRESULT CreateRenderTargetView([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_RENDER_TARGET_VIEW_DESC> pDesc,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11RenderTargetView? ppRTView);

		/// <summary>Create a depth-stencil view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// Pointer to the resource that will serve as the depth-stencil surface. This resource must have been created with the
		/// D3D11_BIND_DEPTH_STENCIL flag.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_DEPTH_STENCIL_VIEW_DESC*</c></para>
		/// <para>
		/// Pointer to a depth-stencil-view description (see D3D11_DEPTH_STENCIL_VIEW_DESC). Set this parameter to <c>NULL</c> to create a
		/// view that accesses mipmap level 0 of the entire resource (using the format the resource was created with).
		/// </para>
		/// </param>
		/// <param name="ppDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11DepthStencilView. Set this parameter to <c>NULL</c> to validate the other input parameters (the
		/// method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>A depth-stencil view can be bound to the output-merger stage by calling ID3D11DeviceContext::OMSetRenderTargets.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdepthstencilview HRESULT
		// CreateDepthStencilView( [in] ID3D11Resource *pResource, [in, optional] const D3D11_DEPTH_STENCIL_VIEW_DESC *pDesc, [out,
		// optional] ID3D11DepthStencilView **ppDepthStencilView );
		[PreserveSig]
		new HRESULT CreateDepthStencilView([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_DEPTH_STENCIL_VIEW_DESC> pDesc,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11DepthStencilView? ppDepthStencilView);

		/// <summary>Create an input-layout object to describe the input-buffer data for the input-assembler stage.</summary>
		/// <param name="pInputElementDescs">
		/// <para>Type: <c>const D3D11_INPUT_ELEMENT_DESC*</c></para>
		/// <para>An array of the input-assembler stage input data types; each type is described by an element description (see D3D11_INPUT_ELEMENT_DESC).</para>
		/// </param>
		/// <param name="NumElements">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of input-data types in the array of input-elements.</para>
		/// </param>
		/// <param name="pShaderBytecodeWithInputSignature">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// A pointer to the compiled shader. The compiled shader code contains a input signature which is validated against the array of
		/// elements. See remarks.
		/// </para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled shader.</para>
		/// </param>
		/// <param name="ppInputLayout">
		/// <para>Type: <c>ID3D11InputLayout**</c></para>
		/// <para>
		/// A pointer to the input-layout object created (see ID3D11InputLayout). To validate the other input parameters, set this pointer
		/// to be <c>NULL</c> and verify that the method returns S_FALSE.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is S_OK. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>After creating an input layout object, it must be bound to the input-assembler stage before calling a draw API.</para>
		/// <para>
		/// Once an input-layout object is created from a shader signature, the input-layout object can be reused with any other shader that
		/// has an identical input signature (semantics included). This can simplify the creation of input-layout objects when you are
		/// working with many shaders with identical inputs.
		/// </para>
		/// <para>
		/// If a data type in the input-layout declaration does not match the data type in a shader-input signature, CreateInputLayout will
		/// generate a warning during compilation. The warning is simply to call attention to the fact that the data may be reinterpreted
		/// when read from a register. You may either disregard this warning (if reinterpretation is intentional) or make the data types
		/// match in both declarations to eliminate the warning.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createinputlayout HRESULT CreateInputLayout( [in]
		// const D3D11_INPUT_ELEMENT_DESC *pInputElementDescs, [in] uint NumElements, [in] const void *pShaderBytecodeWithInputSignature,
		// [in] SIZE_T BytecodeLength, [out, optional] ID3D11InputLayout **ppInputLayout );
		[PreserveSig]
		new HRESULT CreateInputLayout([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_INPUT_ELEMENT_DESC[] pInputElementDescs,
			int NumElements, [In] IntPtr pShaderBytecodeWithInputSignature, [In] IntPtr BytecodeLength,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11InputLayout? ppInputLayout);

		/// <summary>Create a vertex-shader object from a compiled shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled vertex shader.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppVertexShader">
		/// <para>Type: <c>ID3D11VertexShader**</c></para>
		/// <para>
		/// Address of a pointer to a ID3D11VertexShader interface. If this is <c>NULL</c>, all other parameters will be validated, and if
		/// all parameters pass validation this API will return <c>S_FALSE</c> instead of <c>S_OK</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <c>CreateVertexShader</c>.</para>
		/// <para>
		/// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0
		/// runtime. For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages, you can use
		/// these instructions in all shader stages.
		/// </para>
		/// <para>
		/// Therefore, if you use the following shader model 5.0 instructions in a vertex shader, you can successfully pass the compiled
		/// vertex shader to <c>pShaderBytecode</c>. That is, the call to <c>CreateVertexShader</c> succeeds.
		/// </para>
		/// <para>
		/// If you pass a compiled shader to <c>pShaderBytecode</c> that uses any of the following instructions on a device that doesn’t
		/// support UAVs at every shader stage (including existing drivers that are not implemented to support UAVs at every shader stage),
		/// <c>CreateVertexShader</c> fails. <c>CreateVertexShader</c> also fails if the shader tries to use a UAV slot beyond the set of
		/// UAV slots that the hardware supports.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>dcl_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_raw</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_raw</description>
		/// </item>
		/// <item>
		/// <description>ld_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>store_raw</description>
		/// </item>
		/// <item>
		/// <description>store_structured</description>
		/// </item>
		/// <item>
		/// <description>store_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>sync_uglobal</description>
		/// </item>
		/// <item>
		/// <description>All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createvertexshader HRESULT CreateVertexShader(
		// [in] const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional]
		// ID3D11VertexShader **ppVertexShader );
		[PreserveSig]
		new HRESULT CreateVertexShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, [In, Optional] ID3D11ClassLinkage? pClassLinkage,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11VertexShader? ppVertexShader);

		/// <summary>Create a geometry shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled geometry shader.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppGeometryShader">
		/// <para>Type: <c>ID3D11GeometryShader**</c></para>
		/// <para>
		/// Address of a pointer to a ID3D11GeometryShader interface. If this is <c>NULL</c>, all other parameters will be validated, and if
		/// all parameters pass validation this API will return S_FALSE instead of S_OK.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>After it is created, the shader can be set to the device by calling ID3D11DeviceContext::GSSetShader.</para>
		/// <para>The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <c>CreateGeometryShader</c>.</para>
		/// <para>
		/// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0
		/// runtime. For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages, you can use
		/// these instructions in all shader stages.
		/// </para>
		/// <para>
		/// Therefore, if you use the following shader model 5.0 instructions in a geometry shader, you can successfully pass the compiled
		/// geometry shader to <c>pShaderBytecode</c>. That is, the call to <c>CreateGeometryShader</c> succeeds.
		/// </para>
		/// <para>
		/// If you pass a compiled shader to <c>pShaderBytecode</c> that uses any of the following instructions on a device that doesn’t
		/// support UAVs at every shader stage (including existing drivers that are not implemented to support UAVs at every shader stage),
		/// <c>CreateGeometryShader</c> fails. <c>CreateGeometryShader</c> also fails if the shader tries to use a UAV slot beyond the set
		/// of UAV slots that the hardware supports.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>dcl_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_raw</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_raw</description>
		/// </item>
		/// <item>
		/// <description>ld_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>store_raw</description>
		/// </item>
		/// <item>
		/// <description>store_structured</description>
		/// </item>
		/// <item>
		/// <description>store_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>sync_uglobal</description>
		/// </item>
		/// <item>
		/// <description>All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)</description>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>Usage Example</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-creategeometryshader HRESULT
		// CreateGeometryShader( [in] const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage
		// *pClassLinkage, [out, optional] ID3D11GeometryShader **ppGeometryShader );
		[PreserveSig]
		new HRESULT CreateGeometryShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, [In, Optional] ID3D11ClassLinkage? pClassLinkage,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11GeometryShader? ppGeometryShader);

		/// <summary>Creates a geometry shader that can write to streaming output buffers.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// A pointer to the compiled geometry shader for a standard geometry shader plus stream output. For info on how to get this
		/// pointer, see Getting a Pointer to a Compiled Shader.
		/// </para>
		/// <para>
		/// To create the stream output without using a geometry shader, pass a pointer to the output signature for the prior stage. To
		/// obtain this output signature, call the D3DGetOutputSignatureBlob compiler function. You can also pass a pointer to the compiled
		/// shader for the prior stage (for example, the vertex-shader stage or domain-shader stage). This compiled shader provides the
		/// output signature for the data.
		/// </para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled geometry shader.</para>
		/// </param>
		/// <param name="pSODeclaration">
		/// <para>Type: <c>const D3D11_SO_DECLARATION_ENTRY*</c></para>
		/// <para>Pointer to a D3D11_SO_DECLARATION_ENTRY array. Cannot be <c>NULL</c> if NumEntries &gt; 0.</para>
		/// </param>
		/// <param name="NumEntries">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of entries in the stream output declaration ( ranges from 0 to D3D11_SO_STREAM_COUNT *
		/// D3D11_SO_OUTPUT_COMPONENT_COUNT ).
		/// </para>
		/// </param>
		/// <param name="pBufferStrides">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>An array of buffer strides; each stride is the size of an element for that buffer.</para>
		/// </param>
		/// <param name="NumStrides">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of strides (or buffers) in <c>pBufferStrides</c> (ranges from 0 to D3D11_SO_BUFFER_SLOT_COUNT).</para>
		/// </param>
		/// <param name="RasterizedStream">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The index number of the stream to be sent to the rasterizer stage (ranges from 0 to D3D11_SO_STREAM_COUNT - 1). Set to
		/// D3D11_SO_NO_RASTERIZED_STREAM if no stream is to be rasterized.
		/// </para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppGeometryShader">
		/// <para>Type: <c>ID3D11GeometryShader**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11GeometryShader interface, representing the geometry shader that was created. Set this to
		/// <c>NULL</c> to validate the other parameters; if validation passes, the method will return S_FALSE instead of S_OK.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For more info about using <c>CreateGeometryShaderWithStreamOutput</c>, see Create a Geometry-Shader Object with Stream Output.
		/// </para>
		/// <para>The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <c>CreateGeometryShaderWithStreamOutput</c>.</para>
		/// <para>
		/// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0
		/// runtime. For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages, you can use
		/// these instructions in all shader stages.
		/// </para>
		/// <para>
		/// Therefore, if you use the following shader model 5.0 instructions in a geometry shader, you can successfully pass the compiled
		/// geometry shader to <c>pShaderBytecode</c>. That is, the call to <c>CreateGeometryShaderWithStreamOutput</c> succeeds.
		/// </para>
		/// <para>
		/// If you pass a compiled shader to <c>pShaderBytecode</c> that uses any of the following instructions on a device that doesn’t
		/// support UAVs at every shader stage (including existing drivers that are not implemented to support UAVs at every shader stage),
		/// <c>CreateGeometryShaderWithStreamOutput</c> fails. <c>CreateGeometryShaderWithStreamOutput</c> also fails if the shader tries to
		/// use a UAV slot beyond the set of UAV slots that the hardware supports.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>dcl_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_raw</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_raw</description>
		/// </item>
		/// <item>
		/// <description>ld_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>store_raw</description>
		/// </item>
		/// <item>
		/// <description>store_structured</description>
		/// </item>
		/// <item>
		/// <description>store_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>sync_uglobal</description>
		/// </item>
		/// <item>
		/// <description>All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)</description>
		/// </item>
		/// </list>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-creategeometryshaderwithstreamoutput HRESULT
		// CreateGeometryShaderWithStreamOutput( [in] const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] const
		// D3D11_SO_DECLARATION_ENTRY *pSODeclaration, [in] uint NumEntries, [in, optional] const uint *pBufferStrides, [in] uint
		// NumStrides, [in] uint RasterizedStream, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional] ID3D11GeometryShader
		// **ppGeometryShader );
		[PreserveSig]
		new HRESULT CreateGeometryShaderWithStreamOutput([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D11_SO_DECLARATION_ENTRY[]? pSODeclaration,
			int NumEntries, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[]? pBufferStrides,
			int NumStrides, uint RasterizedStream, [In, Optional] ID3D11ClassLinkage? pClassLinkage, [MarshalAs(UnmanagedType.Interface)] out ID3D11GeometryShader? ppGeometryShader);

		/// <summary>Create a pixel shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled pixel shader.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppPixelShader">
		/// <para>Type: <c>ID3D11PixelShader**</c></para>
		/// <para>
		/// Address of a pointer to a ID3D11PixelShader interface. If this is <c>NULL</c>, all other parameters will be validated, and if
		/// all parameters pass validation this API will return S_FALSE instead of S_OK.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>After creating the pixel shader, you can set it to the device using ID3D11DeviceContext::PSSetShader.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createpixelshader HRESULT CreatePixelShader( [in]
		// const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional]
		// ID3D11PixelShader **ppPixelShader );
		[PreserveSig]
		new HRESULT CreatePixelShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, ID3D11ClassLinkage? pClassLinkage, [MarshalAs(UnmanagedType.Interface)] out ID3D11PixelShader? ppPixelShader);

		/// <summary>Create a hull shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to a compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled shader.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppHullShader">
		/// <para>Type: <c>ID3D11HullShader**</c></para>
		/// <para>Address of a pointer to a ID3D11HullShader interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <c>CreateHullShader</c>.</para>
		/// <para>
		/// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0
		/// runtime. For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages, you can use
		/// these instructions in all shader stages.
		/// </para>
		/// <para>
		/// Therefore, if you use the following shader model 5.0 instructions in a hull shader, you can successfully pass the compiled hull
		/// shader to <c>pShaderBytecode</c>. That is, the call to <c>CreateHullShader</c> succeeds.
		/// </para>
		/// <para>
		/// If you pass a compiled shader to <c>pShaderBytecode</c> that uses any of the following instructions on a device that doesn’t
		/// support UAVs at every shader stage (including existing drivers that are not implemented to support UAVs at every shader stage),
		/// <c>CreateHullShader</c> fails. <c>CreateHullShader</c> also fails if the shader tries to use a UAV slot beyond the set of UAV
		/// slots that the hardware supports.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>dcl_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_raw</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_raw</description>
		/// </item>
		/// <item>
		/// <description>ld_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>store_raw</description>
		/// </item>
		/// <item>
		/// <description>store_structured</description>
		/// </item>
		/// <item>
		/// <description>store_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>sync_uglobal</description>
		/// </item>
		/// <item>
		/// <description>All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createhullshader HRESULT CreateHullShader( [in]
		// const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional]
		// ID3D11HullShader **ppHullShader );
		[PreserveSig]
		new HRESULT CreateHullShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, ID3D11ClassLinkage? pClassLinkage, [MarshalAs(UnmanagedType.Interface)] out ID3D11HullShader? ppHullShader);

		/// <summary>Create a domain shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to a compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled shader.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppDomainShader">
		/// <para>Type: <c>ID3D11DomainShader**</c></para>
		/// <para>
		/// Address of a pointer to a ID3D11DomainShader interface. If this is <c>NULL</c>, all other parameters will be validated, and if
		/// all parameters pass validation this API will return <c>S_FALSE</c> instead of <c>S_OK</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <c>CreateDomainShader</c>.</para>
		/// <para>
		/// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0
		/// runtime. For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages, you can use
		/// these instructions in all shader stages.
		/// </para>
		/// <para>
		/// Therefore, if you use the following shader model 5.0 instructions in a domain shader, you can successfully pass the compiled
		/// domain shader to <c>pShaderBytecode</c>. That is, the call to <c>CreateDomainShader</c> succeeds.
		/// </para>
		/// <para>
		/// If you pass a compiled shader to <c>pShaderBytecode</c> that uses any of the following instructions on a device that doesn’t
		/// support UAVs at every shader stage (including existing drivers that are not implemented to support UAVs at every shader stage),
		/// <c>CreateDomainShader</c> fails. <c>CreateDomainShader</c> also fails if the shader tries to use a UAV slot beyond the set of
		/// UAV slots that the hardware supports.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>dcl_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_raw</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_raw</description>
		/// </item>
		/// <item>
		/// <description>ld_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>store_raw</description>
		/// </item>
		/// <item>
		/// <description>store_structured</description>
		/// </item>
		/// <item>
		/// <description>store_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>sync_uglobal</description>
		/// </item>
		/// <item>
		/// <description>All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdomainshader HRESULT CreateDomainShader(
		// [in] const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional]
		// ID3D11DomainShader **ppDomainShader );
		[PreserveSig]
		new HRESULT CreateDomainShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, ID3D11ClassLinkage? pClassLinkage, [MarshalAs(UnmanagedType.Interface)] out ID3D11DomainShader? ppDomainShader);

		/// <summary>Create a compute shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to a compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled shader in <c>pShaderBytecode</c>.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a ID3D11ClassLinkage, which represents class linkage interface; the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppComputeShader">
		/// <para>Type: <c>ID3D11ComputeShader**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11ComputeShader interface. If this is <c>NULL</c>, all other parameters will be validated; if
		/// validation passes, CreateComputeShader returns S_FALSE instead of S_OK.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the compute shader. See Direct3D 11 Return Codes for
		/// other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>For an example, see How To: Create a Compute Shader and HDRToneMappingCS11 Sample.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createcomputeshader HRESULT CreateComputeShader(
		// [in] const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional]
		// ID3D11ComputeShader **ppComputeShader );
		[PreserveSig]
		new HRESULT CreateComputeShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, ID3D11ClassLinkage? pClassLinkage, [MarshalAs(UnmanagedType.Interface)] out ID3D11ComputeShader? ppComputeShader);

		/// <summary>Creates class linkage libraries to enable dynamic shader linkage.</summary>
		/// <param name="ppLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage**</c></para>
		/// <para>A pointer to a class-linkage interface pointer (see ID3D11ClassLinkage).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The ID3D11ClassLinkage interface returned in <c>ppLinkage</c> is associated with a shader by passing it as a parameter to one of
		/// the ID3D11Device create shader methods such as ID3D11Device::CreatePixelShader.
		/// </para>
		/// <para>Examples</para>
		/// <para>Using CreateClassLinkage</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createclasslinkage HRESULT CreateClassLinkage(
		// [out] ID3D11ClassLinkage **ppLinkage );
		[PreserveSig]
		new HRESULT CreateClassLinkage([MarshalAs(UnmanagedType.Interface)] out ID3D11ClassLinkage ppLinkage);

		/// <summary>Create a blend-state object that encapsulates blend state for the output-merger stage.</summary>
		/// <param name="pBlendStateDesc">
		/// <para>Type: <c>const D3D11_BLEND_DESC*</c></para>
		/// <para>Pointer to a blend-state description (see D3D11_BLEND_DESC).</para>
		/// </param>
		/// <param name="ppBlendState">
		/// <para>Type: <c>ID3D11BlendState**</c></para>
		/// <para>Address of a pointer to the blend-state object created (see ID3D11BlendState).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the blend-state object. See Direct3D 11 Return Codes
		/// for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can create up to 4096 unique blend-state objects. For each object created, the runtime checks to see if a
		/// previous object has the same state. If such a previous object exists, the runtime will return a pointer to previous instance
		/// instead of creating a duplicate object.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createblendstate HRESULT CreateBlendState( [in]
		// const D3D11_BLEND_DESC *pBlendStateDesc, [out, optional] ID3D11BlendState **ppBlendState );
		[PreserveSig]
		new HRESULT CreateBlendState(in D3D11_BLEND_DESC pBlendStateDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11BlendState? ppBlendState);

		/// <summary>Create a depth-stencil state object that encapsulates depth-stencil test information for the output-merger stage.</summary>
		/// <param name="pDepthStencilDesc">
		/// <para>Type: <c>const D3D11_DEPTH_STENCIL_DESC*</c></para>
		/// <para>Pointer to a depth-stencil state description (see D3D11_DEPTH_STENCIL_DESC).</para>
		/// </param>
		/// <param name="ppDepthStencilState">
		/// <para>Type: <c>ID3D11DepthStencilState**</c></para>
		/// <para>Address of a pointer to the depth-stencil state object created (see ID3D11DepthStencilState).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>4096 unique depth-stencil state objects can be created on a device at a time.</para>
		/// <para>
		/// If an application attempts to create a depth-stencil-state interface with the same state as an existing interface, the same
		/// interface will be returned and the total number of unique depth-stencil state objects will stay the same.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdepthstencilstate HRESULT
		// CreateDepthStencilState( [in] const D3D11_DEPTH_STENCIL_DESC *pDepthStencilDesc, [out, optional] ID3D11DepthStencilState
		// **ppDepthStencilState );
		[PreserveSig]
		new HRESULT CreateDepthStencilState(in D3D11_DEPTH_STENCIL_DESC pDepthStencilDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11DepthStencilState? ppDepthStencilState);

		/// <summary>Create a rasterizer state object that tells the rasterizer stage how to behave.</summary>
		/// <param name="pRasterizerDesc">
		/// <para>Type: <c>const D3D11_RASTERIZER_DESC*</c></para>
		/// <para>Pointer to a rasterizer state description (see D3D11_RASTERIZER_DESC).</para>
		/// </param>
		/// <param name="ppRasterizerState">
		/// <para>Type: <c>ID3D11RasterizerState**</c></para>
		/// <para>Address of a pointer to the rasterizer state object created (see ID3D11RasterizerState).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the compute shader. See Direct3D 11 Return Codes for
		/// other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>4096 unique rasterizer state objects can be created on a device at a time.</para>
		/// <para>
		/// If an application attempts to create a rasterizer-state interface with the same state as an existing interface, the same
		/// interface will be returned and the total number of unique rasterizer state objects will stay the same.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createrasterizerstate HRESULT
		// CreateRasterizerState( [in] const D3D11_RASTERIZER_DESC *pRasterizerDesc, [out, optional] ID3D11RasterizerState
		// **ppRasterizerState );
		[PreserveSig]
		new HRESULT CreateRasterizerState(in D3D11_RASTERIZER_DESC pRasterizerDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11RasterizerState? ppRasterizerState);

		/// <summary>Create a sampler-state object that encapsulates sampling information for a texture.</summary>
		/// <param name="pSamplerDesc">
		/// <para>Type: <c>const D3D11_SAMPLER_DESC*</c></para>
		/// <para>Pointer to a sampler state description (see D3D11_SAMPLER_DESC).</para>
		/// </param>
		/// <param name="ppSamplerState">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Address of a pointer to the sampler state object created (see ID3D11SamplerState).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>4096 unique sampler state objects can be created on a device at a time.</para>
		/// <para>
		/// If an application attempts to create a sampler-state interface with the same state as an existing interface, the same interface
		/// will be returned and the total number of unique sampler state objects will stay the same.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createsamplerstate HRESULT CreateSamplerState(
		// [in] const D3D11_SAMPLER_DESC *pSamplerDesc, [out, optional] ID3D11SamplerState **ppSamplerState );
		[PreserveSig]
		new HRESULT CreateSamplerState(in D3D11_SAMPLER_DESC pSamplerDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11SamplerState? ppSamplerState);

		/// <summary>This interface encapsulates methods for querying information from the GPU.</summary>
		/// <param name="pQueryDesc">
		/// <para>Type: <c>const D3D11_QUERY_DESC*</c></para>
		/// <para>Pointer to a query description (see D3D11_QUERY_DESC).</para>
		/// </param>
		/// <param name="ppQuery">
		/// <para>Type: <c>ID3D11Query**</c></para>
		/// <para>Address of a pointer to the query object created (see ID3D11Query).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the query object. See Direct3D 11 Return Codes for
		/// other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createquery HRESULT CreateQuery( [in] const
		// D3D11_QUERY_DESC *pQueryDesc, [out, optional] ID3D11Query **ppQuery );
		[PreserveSig]
		new HRESULT CreateQuery(in D3D11_QUERY_DESC pQueryDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11Query? ppQuery);

		/// <summary>Creates a predicate.</summary>
		/// <param name="pPredicateDesc">
		/// <para>Type: <c>const D3D11_QUERY_DESC*</c></para>
		/// <para>
		/// Pointer to a query description where the type of query must be a D3D11_QUERY_SO_OVERFLOW_PREDICATE or
		/// D3D11_QUERY_OCCLUSION_PREDICATE (see D3D11_QUERY_DESC).
		/// </para>
		/// </param>
		/// <param name="ppPredicate">
		/// <para>Type: <c>ID3D11Predicate**</c></para>
		/// <para>Address of a pointer to a predicate (see ID3D11Predicate).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createpredicate HRESULT CreatePredicate( [in]
		// const D3D11_QUERY_DESC *pPredicateDesc, [out, optional] ID3D11Predicate **ppPredicate );
		[PreserveSig]
		new HRESULT CreatePredicate(in D3D11_QUERY_DESC pPredicateDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11Predicate? ppPredicate);

		/// <summary>Create a counter object for measuring GPU performance.</summary>
		/// <param name="pCounterDesc">
		/// <para>Type: <c>const D3D11_COUNTER_DESC*</c></para>
		/// <para>Pointer to a counter description (see D3D11_COUNTER_DESC).</para>
		/// </param>
		/// <param name="ppCounter">
		/// <para>Type: <c>ID3D11Counter**</c></para>
		/// <para>Address of a pointer to a counter (see ID3D11Counter).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If this function succeeds, it will return S_OK. If it fails, possible return values are: S_FALSE, E_OUTOFMEMORY,
		/// DXGI_ERROR_UNSUPPORTED, DXGI_ERROR_NONEXCLUSIVE, or E_INVALIDARG.
		/// </para>
		/// <para>
		/// DXGI_ERROR_UNSUPPORTED is returned whenever the application requests to create a well-known counter, but the current device does
		/// not support it.
		/// </para>
		/// <para>
		/// DXGI_ERROR_NONEXCLUSIVE indicates that another device object is currently using the counters, so they cannot be used by this
		/// device at the moment.
		/// </para>
		/// <para>
		/// E_INVALIDARG is returned whenever an out-of-range well-known or device-dependent counter is requested, or when the
		/// simulataneously active counters have been exhausted.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createcounter HRESULT CreateCounter( [in] const
		// D3D11_COUNTER_DESC *pCounterDesc, [out, optional] ID3D11Counter **ppCounter );
		[PreserveSig]
		new HRESULT CreateCounter(in D3D11_COUNTER_DESC pCounterDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11Counter? ppCounter);

		/// <summary>Creates a deferred context, which can record command lists.</summary>
		/// <param name="ContextFlags">
		/// <para>Type: <c>uint</c></para>
		/// <para>Reserved for future use. Pass 0.</para>
		/// </param>
		/// <param name="ppDeferredContext">
		/// <para>Type: <c>ID3D11DeviceContext**</c></para>
		/// <para>Upon completion of the method, the passed pointer to an ID3D11DeviceContext interface pointer is initialized.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Returns <c>DXGI_ERROR_DEVICE_REMOVED</c> if the video card has been physically removed from the system, or a driver upgrade for
		/// the video card has occurred. If this error occurs, you should destroy and recreate the device.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns <c>DXGI_ERROR_INVALID_CALL</c> if the <c>CreateDeferredContext</c> method cannot be called from the current context. For
		/// example, if the device was created with the D3D11_CREATE_DEVICE_SINGLETHREADED value, <c>CreateDeferredContext</c> returns <c>DXGI_ERROR_INVALID_CALL</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Returns <c>E_INVALIDARG</c> if the <c>ContextFlags</c> parameter is invalid.</description>
		/// </item>
		/// <item>
		/// <description>Returns <c>E_OUTOFMEMORY</c> if the application has exhausted available memory.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A deferred context is a thread-safe context that you can use to record graphics commands on a thread other than the main
		/// rendering thread. Using a deferred context, you can record graphics commands into a command list that is encapsulated by the
		/// ID3D11CommandList interface. After all scene items are recorded, you can then submit them to the main render thread for final
		/// rendering. In this manner, you can perform rendering tasks concurrently across multiple threads and potentially improve
		/// performance in multi-core CPU scenarios.
		/// </para>
		/// <para>You can create multiple deferred contexts.</para>
		/// <para>
		/// <c>Note</c>  If you use the D3D11_CREATE_DEVICE_SINGLETHREADED value to create the device that is represented by ID3D11Device,
		/// the <c>CreateDeferredContext</c> method will fail, and you will not be able to create a deferred context.
		/// </para>
		/// <para></para>
		/// <para>For more information about deferred contexts, see Immediate and Deferred Rendering.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdeferredcontext HRESULT
		// CreateDeferredContext( uint ContextFlags, [out, optional] ID3D11DeviceContext **ppDeferredContext );
		[PreserveSig]
		new HRESULT CreateDeferredContext([Optional] uint ContextFlags, [MarshalAs(UnmanagedType.Interface)] out ID3D11DeviceContext? ppDeferredContext);

		/// <summary>Give a device access to a shared resource created on a different device.</summary>
		/// <param name="hResource">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A resource handle. See remarks.</para>
		/// </param>
		/// <param name="ReturnedInterface">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>The globally unique identifier (GUID) for the resource interface. See remarks.</para>
		/// </param>
		/// <param name="ppResource">
		/// <para>Type: <c>void**</c></para>
		/// <para>Address of a pointer to the resource we are gaining access to.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The REFIID, or GUID, of the interface to the resource can be obtained by using the __uuidof() macro. For example,
		/// __uuidof(ID3D11Buffer) will get the GUID of the interface to a buffer resource.
		/// </para>
		/// <para>
		/// The unique handle of the resource is obtained differently depending on the type of device that originally created the resource.
		/// </para>
		/// <para>
		/// To share a resource between two Direct3D 11 devices the resource must have been created with the D3D11_RESOURCE_MISC_SHARED
		/// flag, if it was created using the ID3D11Device interface. If it was created using a DXGI device interface, then the resource is
		/// always shared.
		/// </para>
		/// <para>
		/// The REFIID, or GUID, of the interface to the resource can be obtained by using the __uuidof() macro. For example,
		/// __uuidof(ID3D11Buffer) will get the GUID of the interface to a buffer resource.
		/// </para>
		/// <para>
		/// When sharing a resource between two Direct3D 10/11 devices the unique handle of the resource can be obtained by querying the
		/// resource for the IDXGIResource interface and then calling GetSharedHandle.
		/// </para>
		/// <para>The only resources that can be shared are 2D non-mipmapped textures.</para>
		/// <para>
		/// To share a resource between a Direct3D 9 device and a Direct3D 11 device the texture must have been created using the
		/// <c>pSharedHandle</c> argument of CreateTexture. The shared Direct3D 9 handle is then passed to OpenSharedResource in the
		/// <c>hResource</c> argument.
		/// </para>
		/// <para>The following code illustrates the method calls involved.</para>
		/// <para>Textures being shared from D3D9 to D3D11 have the following restrictions.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Textures must be 2D</description>
		/// </item>
		/// <item>
		/// <description>Only 1 mip level is allowed</description>
		/// </item>
		/// <item>
		/// <description>Texture must have default usage</description>
		/// </item>
		/// <item>
		/// <description>Texture must be write only</description>
		/// </item>
		/// <item>
		/// <description>MSAA textures are not allowed</description>
		/// </item>
		/// <item>
		/// <description>Bind flags must have SHADER_RESOURCE and RENDER_TARGET set</description>
		/// </item>
		/// <item>
		/// <description>Only R10G10B10A2_UNORM, R16G16B16A16_FLOAT and R8G8B8A8_UNORM formats are allowed</description>
		/// </item>
		/// </list>
		/// <para>If a shared texture is updated on one device ID3D11DeviceContext::Flush must be called on that device.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-opensharedresource HRESULT OpenSharedResource(
		// [in] HANDLE hResource, [in] REFIID ReturnedInterface, [out, optional] void **ppResource );
		[PreserveSig]
		new HRESULT OpenSharedResource([In] IntPtr hResource, in Guid ReturnedInterface, [MarshalAs(UnmanagedType.Interface)] out object? ppResource);

		/// <summary>Get the support of a given format on the installed video device.</summary>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>A DXGI_FORMAT enumeration that describes a format for which to check for support.</para>
		/// </param>
		/// <param name="pFormatSupport">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A bitfield of D3D11_FORMAT_SUPPORT enumeration values describing how the specified format is supported on the installed device.
		/// The values are ORed together.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if successful; otherwise, returns E_INVALIDARG if the <c>Format</c> parameter is <c>NULL</c>, or returns E_FAIL if
		/// the described format does not exist.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkformatsupport HRESULT CheckFormatSupport(
		// [in] DXGI_FORMAT Format, [out] uint *pFormatSupport );
		[PreserveSig]
		new HRESULT CheckFormatSupport(DXGI_FORMAT Format, out D3D11_FORMAT_SUPPORT pFormatSupport);

		/// <summary>Get the number of quality levels available during multisampling.</summary>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The texture format. See DXGI_FORMAT.</para>
		/// </param>
		/// <param name="SampleCount">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of samples during multisampling.</para>
		/// </param>
		/// <param name="pNumQualityLevels">
		/// <para>Type: <c>uint*</c></para>
		/// <para>Number of quality levels supported by the adapter. See <c>Remarks</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When multisampling a texture, the number of quality levels available for an adapter is dependent on the texture format used and
		/// the number of samples requested. The maximum number of quality levels is defined by <c>D3D11_MAX_MULTISAMPLE_SAMPLE_COUNT</c> in
		/// . If this method returns 0 (S_OK), and the output parameter receives a positive value, then the format and sample count
		/// combination is supported for the device. When the combination is not supported, this method returns a failure <c>HRESULT</c>
		/// code (that is, a negative integer), or sets output parameter to zero, or both.
		/// </para>
		/// <para>
		/// Furthermore, the definition of a quality level is left to each hardware vendor to define; however no facility is provided by
		/// Direct3D to help discover this information.
		/// </para>
		/// <para>
		/// Note that FEATURE_LEVEL_10_1 devices are required to support 4x MSAA for all render targets except R32G32B32A32 and R32G32B32.
		/// FEATURE_LEVEL_11_0 devices are required to support 4x MSAA for all render target formats, and 8x MSAA for all render target
		/// formats except R32G32B32A32 formats.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkmultisamplequalitylevels HRESULT
		// CheckMultisampleQualityLevels( [in] DXGI_FORMAT Format, [in] uint SampleCount, [out] uint *pNumQualityLevels );
		[PreserveSig]
		new HRESULT CheckMultisampleQualityLevels(DXGI_FORMAT Format, uint SampleCount, out uint pNumQualityLevels);

		/// <summary>Get a counter's information.</summary>
		/// <param name="pCounterInfo">
		/// <para>Type: <c>D3D11_COUNTER_INFO*</c></para>
		/// <para>Pointer to counter information (see D3D11_COUNTER_INFO).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkcounterinfo void CheckCounterInfo( [out]
		// D3D11_COUNTER_INFO *pCounterInfo );
		[PreserveSig]
		new void CheckCounterInfo(out D3D11_COUNTER_INFO pCounterInfo);

		/// <summary>Get the type, name, units of measure, and a description of an existing counter.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_COUNTER_DESC*</c></para>
		/// <para>Pointer to a counter description (see D3D11_COUNTER_DESC). Specifies which counter information is to be retrieved about.</para>
		/// </param>
		/// <param name="pType">
		/// <para>Type: <c>D3D11_COUNTER_TYPE*</c></para>
		/// <para>Pointer to the data type of a counter (see D3D11_COUNTER_TYPE). Specifies the data type of the counter being retrieved.</para>
		/// </param>
		/// <param name="pActiveCounters">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// Pointer to the number of hardware counters that are needed for this counter type to be created. All instances of the same
		/// counter type use the same hardware counters.
		/// </para>
		/// </param>
		/// <param name="szName">
		/// <para>Type: <c>PSTR</c></para>
		/// <para>
		/// String to be filled with a brief name for the counter. May be <c>NULL</c> if the application is not interested in the name of
		/// the counter.
		/// </para>
		/// </param>
		/// <param name="pNameLength">
		/// <para>Type: <c>uint*</c></para>
		/// <para>Length of the string returned to szName. Can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="szUnits">
		/// <para>Type: <c>PSTR</c></para>
		/// <para>
		/// Name of the units a counter measures, provided the memory the pointer points to has enough room to hold the string. Can be
		/// <c>NULL</c>. The returned string will always be in English.
		/// </para>
		/// </param>
		/// <param name="pUnitsLength">
		/// <para>Type: <c>uint*</c></para>
		/// <para>Length of the string returned to szUnits. Can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="szDescription">
		/// <para>Type: <c>PSTR</c></para>
		/// <para>
		/// A description of the counter, provided the memory the pointer points to has enough room to hold the string. Can be <c>NULL</c>.
		/// The returned string will always be in English.
		/// </para>
		/// </param>
		/// <param name="pDescriptionLength">
		/// <para>Type: <c>uint*</c></para>
		/// <para>Length of the string returned to szDescription. Can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Length parameters can be <c>NULL</c>, which indicates the application is not interested in the length nor the corresponding
		/// string value. When a length parameter is non- <c>NULL</c> and the corresponding string is <c>NULL</c>, the input value of the
		/// length parameter is ignored, and the length of the corresponding string (including terminating <c>NULL</c>) will be returned
		/// through the length parameter. When length and the corresponding parameter are both non- <c>NULL</c>, the input value of length
		/// is checked to ensure there is enough room, and then the length of the string (including terminating <c>NULL</c> character) is
		/// passed out through the length parameter.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkcounter HRESULT CheckCounter( [in] const
		// D3D11_COUNTER_DESC *pDesc, [out] D3D11_COUNTER_TYPE *pType, [out] uint *pActiveCounters, [out, optional] PSTR szName, [in, out,
		// optional] uint *pNameLength, [out, optional] PSTR szUnits, [in, out, optional] uint *pUnitsLength, [out, optional] PSTR
		// szDescription, [in, out, optional] uint *pDescriptionLength );
		[PreserveSig]
		new HRESULT CheckCounter(in D3D11_COUNTER_DESC pDesc, out D3D11_COUNTER_TYPE pType, out uint pActiveCounters,
			[In, Out, Optional, MarshalAs(UnmanagedType.LPStr)] StringBuilder? szName, [Optional] in uint pNameLength,
			[In, Out, Optional, MarshalAs(UnmanagedType.LPStr)] StringBuilder? szUnits, [Optional] in uint pUnitsLength,
			[In, Out, Optional, MarshalAs(UnmanagedType.LPStr)] StringBuilder? szDescription, [Optional] in uint pDescriptionLength);

		/// <summary>Gets information about the features that are supported by the current graphics driver.</summary>
		/// <param name="Feature">
		/// <para>Type: <c>D3D11_FEATURE</c></para>
		/// <para>A member of the D3D11_FEATURE enumerated type that describes which feature to query for support.</para>
		/// </param>
		/// <param name="pFeatureSupportData">
		/// <para>Type: <c>void*</c></para>
		/// <para>Upon completion of the method, the passed structure is filled with data that describes the feature support.</para>
		/// </param>
		/// <param name="FeatureSupportDataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>The size of the structure passed to the <c>pFeatureSupportData</c> parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if successful; otherwise, returns E_INVALIDARG if an unsupported data type is passed to the
		/// <c>pFeatureSupportData</c> parameter or a size mismatch is detected for the <c>FeatureSupportDataSize</c> parameter.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To query for multi-threading support, pass the <c>D3D11_FEATURE_THREADING</c> value to the <c>Feature</c> parameter, pass the
		/// D3D11_FEATURE_DATA_THREADING structure to the <c>pFeatureSupportData</c> parameter, and pass the size of the
		/// <c>D3D11_FEATURE_DATA_THREADING</c> structure to the <c>FeatureSupportDataSize</c> parameter.
		/// </para>
		/// <para>
		/// Calling CheckFeatureSupport with <c>Feature</c> set to D3D11_FEATURE_FORMAT_SUPPORT causes the method to return the same
		/// information that would be returned by ID3D11Device::CheckFormatSupport.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkfeaturesupport HRESULT CheckFeatureSupport(
		// D3D11_FEATURE Feature, [out] void *pFeatureSupportData, uint FeatureSupportDataSize );
		[PreserveSig]
		new HRESULT CheckFeatureSupport(D3D11_FEATURE Feature, IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Get application-defined data from a device.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device if <c>pDataSize</c> points to a value that
		/// specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [In, Optional] IntPtr pData);

		/// <summary>Set data to a device and associate that data with a guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device. If pData is <c>NULL</c>, DataSize must also be 0, and any data previously
		/// associated with the guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device with this method can be retrieved with ID3D11Device::GetPrivateData.</para>
		/// <para>The data and guid set with this method will typically be application-defined.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the feature level of the hardware device.</summary>
		/// <returns>
		/// <para>Type: <c>D3D_FEATURE_LEVEL</c></para>
		/// <para>A member of the D3D_FEATURE_LEVEL enumerated type that describes the feature level of the hardware device.</para>
		/// </returns>
		/// <remarks>Feature levels determine the capabilities of your device.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getfeaturelevel D3D_FEATURE_LEVEL GetFeatureLevel();
		[PreserveSig]
		new D3D_FEATURE_LEVEL GetFeatureLevel();

		/// <summary>Get the flags used during the call to create the device with D3D11CreateDevice.</summary>
		/// <returns>
		/// <para>Type: <c>uint</c></para>
		/// <para>A bitfield containing the flags used to create the device. See D3D11_CREATE_DEVICE_FLAG.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getcreationflags uint GetCreationFlags();
		[PreserveSig]
		new D3D11_CREATE_DEVICE_FLAG GetCreationFlags();

		/// <summary>Get the reason why the device was removed.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Possible return values include:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_HUNG</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_RESET</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_DRIVER_INTERNAL_ERROR</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// </item>
		/// <item>
		/// <description>S_OK</description>
		/// </item>
		/// </list>
		/// <para>For more detail on these return codes, see DXGI_ERROR.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getdeviceremovedreason HRESULT GetDeviceRemovedReason();
		[PreserveSig]
		new HRESULT GetDeviceRemovedReason();

		/// <summary>Gets an immediate context, which can play back command lists.</summary>
		/// <param name="ppImmediateContext">
		/// <para>Type: <c>ID3D11DeviceContext**</c></para>
		/// <para>Upon completion of the method, the passed pointer to an ID3D11DeviceContext interface pointer is initialized.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The <c>GetImmediateContext</c> method returns an ID3D11DeviceContext object that represents an immediate context which is used
		/// to perform rendering that you want immediately submitted to a device. For most applications, an immediate context is the primary
		/// object that is used to draw your scene.
		/// </para>
		/// <para>
		/// The <c>GetImmediateContext</c> method increments the reference count of the immediate context by one. Therefore, you must call
		/// Release on the returned interface pointer when you are done with it to avoid a memory leak.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getimmediatecontext void GetImmediateContext(
		// [out] ID3D11DeviceContext **ppImmediateContext );
		[PreserveSig]
		new void GetImmediateContext(out ID3D11DeviceContext ppImmediateContext);

		/// <summary>Get the exception-mode flags.</summary>
		/// <param name="RaiseFlags">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// A value that contains one or more exception flags; each flag specifies a condition which will cause an exception to be raised.
		/// The flags are listed in D3D11_RAISE_FLAG. A default value of 0 means there are no flags.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>Set an exception-mode flag to elevate an error condition to a non-continuable exception.</para>
		/// <para>
		/// Whenever an error occurs, a Direct3D device enters the DEVICEREMOVED state and if the appropriate exception flag has been set,
		/// an exception is raised. A raised exception is designed to terminate an application. Before termination, the last chance an
		/// application has to persist data is by using an UnhandledExceptionFilter (see Structured Exception Handling). In general,
		/// UnhandledExceptionFilters are leveraged to try to persist data when an application is crashing (to disk, for example). Any code
		/// that executes during an UnhandledExceptionFilter is not guaranteed to reliably execute (due to possible process corruption). Any
		/// data that the UnhandledExceptionFilter manages to persist, before the UnhandledExceptionFilter crashes again, should be treated
		/// as suspect, and therefore inspected by a new, non-corrupted process to see if it is usable.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-setexceptionmode HRESULT SetExceptionMode( uint
		// RaiseFlags );
		[PreserveSig]
		new HRESULT SetExceptionMode(D3D11_RAISE_FLAG RaiseFlags);

		/// <summary>Get the exception-mode flags.</summary>
		/// <returns>
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// A value that contains one or more exception flags; each flag specifies a condition which will cause an exception to be raised.
		/// The flags are listed in D3D11_RAISE_FLAG. A default value of 0 means there are no flags.
		/// </para>
		/// </returns>
		/// <remarks>An exception-mode flag is used to elevate an error condition to a non-continuable exception.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getexceptionmode uint GetExceptionMode();
		[PreserveSig]
		new D3D11_RAISE_FLAG GetExceptionMode();

		/// <summary>Gets an immediate context, which can play back command lists.</summary>
		/// <param name="ppImmediateContext">
		/// Upon completion of the method, the passed pointer to an ID3D11DeviceContext1 interface pointer is initialized.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <c>GetImmediateContext1</c> returns an ID3D11DeviceContext1 object that represents an immediate context. You can use this
		/// immediate context to perform rendering that you want immediately submitted to a device. For most applications, an immediate
		/// context is the primary object that is used to draw your scene.
		/// </para>
		/// <para>
		/// <c>GetImmediateContext1</c> increments the reference count of the immediate context by one. So, call Release on the returned
		/// interface pointer when you are done with it to avoid a memory leak.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-getimmediatecontext1 void
		// GetImmediateContext1( [out] ID3D11DeviceContext1 **ppImmediateContext );
		[PreserveSig]
		new void GetImmediateContext1(out ID3D11DeviceContext1 ppImmediateContext);

		/// <summary>Creates a deferred context, which can record command lists.</summary>
		/// <param name="ContextFlags">Reserved for future use. Pass 0.</param>
		/// <param name="ppDeferredContext">
		/// Upon completion of the method, the passed pointer to an ID3D11DeviceContext1 interface pointer is initialized.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Returns <c>DXGI_ERROR_DEVICE_REMOVED</c> if the graphics adapter has been physically removed from the computer or a driver
		/// upgrade for the graphics adapter has occurred. If this error occurs, you should destroy and re-create the device.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns <c>DXGI_ERROR_INVALID_CALL</c> if the <c>CreateDeferredContext1</c> method cannot be called from the current context.
		/// For example, if the device was created with the D3D11_CREATE_DEVICE_SINGLETHREADED value, <c>CreateDeferredContext1</c> returns <c>DXGI_ERROR_INVALID_CALL</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Returns <c>E_INVALIDARG</c> if the <c>ContextFlags</c> parameter is invalid.</description>
		/// </item>
		/// <item>
		/// <description>Returns <c>E_OUTOFMEMORY</c> if the application has exhausted available memory.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A deferred context is a thread-safe context that you can use to record graphics commands on a thread other than the main
		/// rendering thread. By using a deferred context, you can record graphics commands into a command list that is encapsulated by the
		/// ID3D11CommandList interface. After you record all scene items, you can then submit them to the main render thread for final
		/// rendering. In this manner, you can perform rendering tasks concurrently across multiple threads and potentially improve
		/// performance in multi-core CPU scenarios.
		/// </para>
		/// <para>You can create multiple deferred contexts.</para>
		/// <para>
		/// <c>Note</c>  If you use the D3D11_CREATE_DEVICE_SINGLETHREADED value to create the device that is represented by ID3D11Device1,
		/// the <c>CreateDeferredContext1</c> method will fail, and you will not be able to create a deferred context.
		/// </para>
		/// <para></para>
		/// <para>For more information about deferred contexts, see Immediate and Deferred Rendering.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-createdeferredcontext1 HRESULT
		// CreateDeferredContext1( UINT ContextFlags, [out, optional] ID3D11DeviceContext1 **ppDeferredContext );
		[PreserveSig]
		new HRESULT CreateDeferredContext1([Optional] uint ContextFlags, out ID3D11DeviceContext1? ppDeferredContext);

		/// <summary>
		/// Creates a blend-state object that encapsulates blend state for the output-merger stage and allows the configuration of logic operations.
		/// </summary>
		/// <param name="pBlendStateDesc">A pointer to a D3D11_BLEND_DESC1 structure that describes blend state.</param>
		/// <param name="ppBlendState">Address of a pointer to the ID3D11BlendState1 interface for the blend-state object created.</param>
		/// <returns>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the blend-state object. See Direct3D 11 Return Codes
		/// for other possible return values.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The logical operations (those that enable bitwise logical operations between pixel shader output and render target contents,
		/// refer to D3D11_RENDER_TARGET_BLEND_DESC1 ) are only available on certain feature levels; call CheckFeatureSupport with
		/// D3D11_FEATURE_D3D11_OPTIONS set, to ensure support by checking the boolean field <c>OutputMergerLogicOp</c> of D3D11_FEATURE_DATA_D3D11_OPTIONS.
		/// </para>
		/// <para>
		/// An app can create up to 4096 unique blend-state objects. For each object created, the runtime checks to see if a previous object
		/// has the same state. If such a previous object exists, the runtime will return a pointer to previous instance instead of creating
		/// a duplicate object.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-createblendstate1 HRESULT CreateBlendState1(
		// [in] const D3D11_BLEND_DESC1 *pBlendStateDesc, [out, optional] ID3D11BlendState1 **ppBlendState );
		[PreserveSig]
		new HRESULT CreateBlendState1(in D3D11_BLEND_DESC1 pBlendStateDesc, out ID3D11BlendState1? ppBlendState);

		/// <summary>
		/// Creates a rasterizer state object that informs the rasterizer stage how to behave and forces the sample count while UAV
		/// rendering or rasterizing.
		/// </summary>
		/// <param name="pRasterizerDesc">A pointer to a D3D11_RASTERIZER_DESC1 structure that describes the rasterizer state.</param>
		/// <param name="ppRasterizerState">
		/// Address of a pointer to the ID3D11RasterizerState1 interface for the rasterizer state object created.
		/// </param>
		/// <returns>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the rasterizer state object. See Direct3D 11 Return
		/// Codes for other possible return values.
		/// </returns>
		/// <remarks>
		/// An app can create up to 4096 unique rasterizer state objects. For each object created, the runtime checks to see if a previous
		/// object has the same state. If such a previous object exists, the runtime will return a pointer to previous instance instead of
		/// creating a duplicate object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-createrasterizerstate1 HRESULT
		// CreateRasterizerState1( [in] const D3D11_RASTERIZER_DESC1 *pRasterizerDesc, [out, optional] ID3D11RasterizerState1
		// **ppRasterizerState );
		[PreserveSig]
		new HRESULT CreateRasterizerState1(in D3D11_RASTERIZER_DESC1 pRasterizerDesc, out ID3D11RasterizerState1? ppRasterizerState);

		/// <summary>Creates a context state object that holds all Microsoft Direct3D state and some Direct3D behavior.</summary>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A combination of D3D11_1_CREATE_DEVICE_CONTEXT_STATE_FLAG values that are combined by using a bitwise <c>OR</c> operation. The
		/// resulting value specifies how to create the context state object. The D3D11_1_CREATE_DEVICE_CONTEXT_STATE_SINGLETHREADED flag is
		/// currently the only defined flag. If the original device was created with D3D11_CREATE_DEVICE_SINGLETHREADED, you must create all
		/// context state objects from that device with the <c>D3D11_1_CREATE_DEVICE_CONTEXT_STATE_SINGLETHREADED</c> flag.
		/// </para>
		/// <para>
		/// If you set the single-threaded flag for both the context state object and the device, you guarantee that you will call the whole
		/// set of context methods and device methods only from one thread. You therefore do not need to use critical sections to
		/// synchronize access to the device context, and the runtime can avoid working with those processor-intensive critical sections.
		/// </para>
		/// </param>
		/// <param name="pFeatureLevels">
		/// <para>Type: <c>const D3D_FEATURE_LEVEL*</c></para>
		/// <para>
		/// A pointer to an array of D3D_FEATURE_LEVEL values. The array can contain elements from the following list and determines the
		/// order of feature levels for which creation is attempted. Unlike D3D11CreateDevice, you can't set <c>pFeatureLevels</c> to
		/// <c>NULL</c> because there is no default feature level array.
		/// </para>
		/// </param>
		/// <param name="FeatureLevels">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of elements in <c>pFeatureLevels</c>. Unlike D3D11CreateDevice, you must set <c>FeatureLevels</c> to greater than 0
		/// because you can't set <c>pFeatureLevels</c> to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="SDKVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The SDK version. You must set this parameter to <c>D3D11_SDK_VERSION</c>.</para>
		/// </param>
		/// <param name="EmulatedInterface">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// The globally unique identifier (GUID) for the emulated interface. This value specifies the behavior of the device when the
		/// context state object is active. Valid values are obtained by using the <c>__uuidof</c> operator on the ID3D10Device,
		/// ID3D10Device1, ID3D11Device, and ID3D11Device1 interfaces. See Remarks.
		/// </para>
		/// </param>
		/// <param name="pChosenFeatureLevel">
		/// <para>Type: <c>D3D_FEATURE_LEVEL*</c></para>
		/// <para>
		/// A pointer to a variable that receives a D3D_FEATURE_LEVEL value from the <c>pFeatureLevels</c> array. This is the first array
		/// value with which <c>CreateDeviceContextState</c> succeeded in creating the context state object. If the call to
		/// <c>CreateDeviceContextState</c> fails, the variable pointed to by <c>pChosenFeatureLevel</c> is set to zero.
		/// </para>
		/// </param>
		/// <param name="ppContextState">
		/// <para>Type: <c>ID3DDeviceContextState**</c></para>
		/// <para>The address of a pointer to an ID3DDeviceContextState object that represents the state of a Direct3D device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>REFIID</c> value of the emulated interface is a GUID obtained by use of the <c>__uuidof</c> operator. For example, gets
		/// the GUID of the interface to a Microsoft Direct3D 11 device.
		/// </para>
		/// <para>
		/// Call the ID3D11DeviceContext1::SwapDeviceContextState method to activate the context state object. When the context state object
		/// is active, the device behaviors that are associated with both the context state object's feature level and its compatible
		/// interface are activated on the Direct3D device until the next call to <c>SwapDeviceContextState</c>.
		/// </para>
		/// <para>
		/// When a context state object is active, the runtime disables certain methods on the device and context interfaces. For example, a
		/// context state object that is created with will cause the runtime to turn off most of the Microsoft Direct3D 10 device
		/// interfaces, and a context state object that is created with or will cause the runtime to turn off most of the
		/// ID3D11DeviceContext methods. This behavior ensures that a user of either emulated interface cannot set device state that the
		/// other emulated interface is unable to express. This restriction helps guarantee that the ID3D10Device1 emulated interface
		/// accurately reflects the full state of the pipeline and that the emulated interface will not operate contrary to its original
		/// interface definition.
		/// </para>
		/// <para>
		/// For example, suppose the tessellation stage is made active through the ID3D11DeviceContext interface when you create the device
		/// through D3D11CreateDevice or D3D11CreateDeviceAndSwapChain, instead of through the Direct3D 10 equivalents. Because the
		/// Direct3D 11 context is active, a Direct3D 10 interface is inactive when you first retrieve it via QueryInterface. This means
		/// that you cannot immediately pass a Direct3D 10 interface that you retrieved from a Direct3D 11 device to a function. You must
		/// first call SwapDeviceContextState to activate a Direct3D 10-compatible context state object.
		/// </para>
		/// <para>The following table shows the methods that are active and inactive for each emulated interface.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Emulated interface</description>
		/// <description>Active device or immediate context interfaces</description>
		/// <description>Inactive device or immediate context interfaces</description>
		/// </listheader>
		/// <item>
		/// <description>ID3D11Device or ID3D11Device1</description>
		/// <description>ID3D11Device IDXGIDevice + IDXGIDevice1 + IDXGIDevice2 ID3D10Multithread</description>
		/// <description>ID3D10Device</description>
		/// </item>
		/// <item>
		/// <description>ID3D10Device1 or ID3D10Device</description>
		/// <description>ID3D10Device ID3D10Device1 IDXGIDevice + IDXGIDevice1 ID3D10Multithread</description>
		/// <description>
		/// ID3D11Device ID3D11DeviceContext (As published by the immediate context. The Direct3D 10 or Microsoft Direct3D 10.1 emulated
		/// interface has no effect on deferred contexts.)
		/// </description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// The following table shows the immediate context methods that the runtime disables when the indicated context state objects are active.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Methods of ID3D11DeviceContext when
		/// <code>__uuidof(ID3D10Device1)</code>
		/// or
		/// <code>__uuidof(ID3D10Device)</code>
		/// is active
		/// </description>
		/// <description>Methods of ID3D10Device when
		/// <code>__uuidof(ID3D11Device)</code>
		/// is active
		/// </description>
		/// </listheader>
		/// <item>
		/// <description>ClearDepthStencilView</description>
		/// <description>ClearDepthStencilView</description>
		/// </item>
		/// <item>
		/// <description>ClearRenderTargetView</description>
		/// <description>ClearRenderTargetView</description>
		/// </item>
		/// <item>
		/// <description>ClearState</description>
		/// <description>ClearState</description>
		/// </item>
		/// <item>
		/// <description>ClearUnorderedAccessViewUint</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>ClearUnorderedAccessViewFloat</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CopyResource</description>
		/// <description>CopyResource</description>
		/// </item>
		/// <item>
		/// <description>CopyStructureCount</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CopySubresourceRegion</description>
		/// <description>CopySubresourceRegion</description>
		/// </item>
		/// <item>
		/// <description>CSGetConstantBuffers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CSGetSamplers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CSGetShader</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CSGetShaderResources</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CSGetUnorderedAccessViews</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CSSetConstantBuffers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CSSetSamplers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CSSetShader</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CSSetShaderResources</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>CSSetUnorderedAccessViews</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>Dispatch</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>DispatchIndirect</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description/>
		/// <description>CreateBlendState</description>
		/// </item>
		/// <item>
		/// <description>Draw</description>
		/// <description>Draw</description>
		/// </item>
		/// <item>
		/// <description>DrawAuto</description>
		/// <description>DrawAuto</description>
		/// </item>
		/// <item>
		/// <description>DrawIndexed</description>
		/// <description>DrawIndexed</description>
		/// </item>
		/// <item>
		/// <description>DrawIndexedInstanced</description>
		/// <description>DrawIndexedInstanced</description>
		/// </item>
		/// <item>
		/// <description>DrawIndexedInstancedIndirect</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>DrawInstanced</description>
		/// <description>DrawInstanced</description>
		/// </item>
		/// <item>
		/// <description>DrawInstancedIndirect</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>DSGetConstantBuffers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>DSGetSamplers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>DSGetShader</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>DSGetShaderResources</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>DSSetConstantBuffers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>DSSetSamplers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>DSSetShader</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>DSSetShaderResources</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>ExecuteCommandList</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>FinishCommandList</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>Flush</description>
		/// <description>Flush</description>
		/// </item>
		/// <item>
		/// <description>GenerateMips</description>
		/// <description>GenerateMips</description>
		/// </item>
		/// <item>
		/// <description>GetPredication</description>
		/// <description>GetPredication</description>
		/// </item>
		/// <item>
		/// <description>GetResourceMinLOD</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>GetType</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description/>
		/// <description>GetTextFilterSize</description>
		/// </item>
		/// <item>
		/// <description>GSGetConstantBuffers</description>
		/// <description>GSGetConstantBuffers</description>
		/// </item>
		/// <item>
		/// <description>GSGetSamplers</description>
		/// <description>GSGetSamplers</description>
		/// </item>
		/// <item>
		/// <description>GSGetShader</description>
		/// <description>GSGetShader</description>
		/// </item>
		/// <item>
		/// <description>GSGetShaderResources</description>
		/// <description>GSGetShaderResources</description>
		/// </item>
		/// <item>
		/// <description>GSSetConstantBuffers</description>
		/// <description>GSSetConstantBuffers</description>
		/// </item>
		/// <item>
		/// <description>GSSetSamplers</description>
		/// <description>GSSetSamplers</description>
		/// </item>
		/// <item>
		/// <description>GSSetShader</description>
		/// <description>GSSetShader</description>
		/// </item>
		/// <item>
		/// <description>GSSetShaderResources</description>
		/// <description>GSSetShaderResources</description>
		/// </item>
		/// <item>
		/// <description>HSGetConstantBuffers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>HSGetSamplers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>HSGetShader</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>HSGetShaderResources</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>HSSetConstantBuffers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>HSSetSamplers</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>HSSetShader</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>HSSetShaderResources</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>IAGetIndexBuffer</description>
		/// <description>IAGetIndexBuffer</description>
		/// </item>
		/// <item>
		/// <description>IAGetInputLayout</description>
		/// <description>IAGetInputLayout</description>
		/// </item>
		/// <item>
		/// <description>IAGetPrimitiveTopology</description>
		/// <description>IAGetPrimitiveTopology</description>
		/// </item>
		/// <item>
		/// <description>IAGetVertexBuffers</description>
		/// <description>IAGetVertexBuffers</description>
		/// </item>
		/// <item>
		/// <description>IASetIndexBuffer</description>
		/// <description>IASetIndexBuffer</description>
		/// </item>
		/// <item>
		/// <description>IASetInputLayout</description>
		/// <description>IASetInputLayout</description>
		/// </item>
		/// <item>
		/// <description>IASetPrimitiveTopology</description>
		/// <description>IASetPrimitiveTopology</description>
		/// </item>
		/// <item>
		/// <description>IASetVertexBuffers</description>
		/// <description>IASetVertexBuffers</description>
		/// </item>
		/// <item>
		/// <description>OMGetBlendState</description>
		/// <description>OMGetBlendState</description>
		/// </item>
		/// <item>
		/// <description>OMGetDepthStencilState</description>
		/// <description>OMGetDepthStencilState</description>
		/// </item>
		/// <item>
		/// <description>OMGetRenderTargets</description>
		/// <description>OMGetRenderTargets</description>
		/// </item>
		/// <item>
		/// <description>OMGetRenderTargetsAndUnorderedAccessViews</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>OMSetBlendState</description>
		/// <description>OMSetBlendState</description>
		/// </item>
		/// <item>
		/// <description>OMSetDepthStencilState</description>
		/// <description>OMSetDepthStencilState</description>
		/// </item>
		/// <item>
		/// <description>OMSetRenderTargets</description>
		/// <description>OMSetRenderTargets</description>
		/// </item>
		/// <item>
		/// <description>OMSetRenderTargetsAndUnorderedAccessViews</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>PSGetConstantBuffers</description>
		/// <description>PSGetConstantBuffers</description>
		/// </item>
		/// <item>
		/// <description>PSGetSamplers</description>
		/// <description>PSGetSamplers</description>
		/// </item>
		/// <item>
		/// <description>PSGetShader</description>
		/// <description>PSGetShader</description>
		/// </item>
		/// <item>
		/// <description>PSGetShaderResources</description>
		/// <description>PSGetShaderResources</description>
		/// </item>
		/// <item>
		/// <description>PSSetConstantBuffers</description>
		/// <description>PSSetConstantBuffers</description>
		/// </item>
		/// <item>
		/// <description>PSSetSamplers</description>
		/// <description>PSSetSamplers</description>
		/// </item>
		/// <item>
		/// <description>PSSetShader</description>
		/// <description>PSSetShader</description>
		/// </item>
		/// <item>
		/// <description>PSSetShaderResources</description>
		/// <description>PSSetShaderResources</description>
		/// </item>
		/// <item>
		/// <description>ResolveSubresource</description>
		/// <description>ResolveSubresource</description>
		/// </item>
		/// <item>
		/// <description>RSGetScissorRects</description>
		/// <description>RSGetScissorRects</description>
		/// </item>
		/// <item>
		/// <description>RSGetState</description>
		/// <description>RSGetState</description>
		/// </item>
		/// <item>
		/// <description>RSGetViewports</description>
		/// <description>RSGetViewports</description>
		/// </item>
		/// <item>
		/// <description>RSSetScissorRects</description>
		/// <description>RSSetScissorRects</description>
		/// </item>
		/// <item>
		/// <description>RSSetState</description>
		/// <description>RSSetState</description>
		/// </item>
		/// <item>
		/// <description>RSSetViewports</description>
		/// <description>RSSetViewports</description>
		/// </item>
		/// <item>
		/// <description>SetPredication</description>
		/// <description>SetPredication</description>
		/// </item>
		/// <item>
		/// <description>SetResourceMinLOD</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description/>
		/// <description>SetTextFilterSize</description>
		/// </item>
		/// <item>
		/// <description>SOGetTargets</description>
		/// <description>SOGetTargets</description>
		/// </item>
		/// <item>
		/// <description>SOSetTargets</description>
		/// <description>SOSetTargets</description>
		/// </item>
		/// <item>
		/// <description>UpdateSubresource</description>
		/// <description>UpdateSubresource</description>
		/// </item>
		/// <item>
		/// <description>VSGetConstantBuffers</description>
		/// <description>VSGetConstantBuffers</description>
		/// </item>
		/// <item>
		/// <description>VSGetSamplers</description>
		/// <description>VSGetSamplers</description>
		/// </item>
		/// <item>
		/// <description>VSGetShader</description>
		/// <description>VSGetShader</description>
		/// </item>
		/// <item>
		/// <description>VSGetShaderResources</description>
		/// <description>VSGetShaderResources</description>
		/// </item>
		/// <item>
		/// <description>VSSetConstantBuffers</description>
		/// <description>VSSetConstantBuffers</description>
		/// </item>
		/// <item>
		/// <description>VSSetSamplers</description>
		/// <description>VSSetSamplers</description>
		/// </item>
		/// <item>
		/// <description>VSSetShader</description>
		/// <description>VSSetShader</description>
		/// </item>
		/// <item>
		/// <description>VSSetShaderResources</description>
		/// <description>VSSetShaderResources</description>
		/// </item>
		/// </list>
		/// <para>
		/// The following table shows the immediate context methods that the runtime does not disable when the indicated context state
		/// objects are active.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Methods of ID3D11DeviceContext when
		/// <code>__uuidof(ID3D10Device1)</code>
		/// or
		/// <code>__uuidof(ID3D10Device)</code>
		/// is active
		/// </description>
		/// <description>Methods of ID3D10Device when
		/// <code>__uuidof(ID3D11Device)</code>
		/// is active
		/// </description>
		/// </listheader>
		/// <item>
		/// <description>Begin</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>End</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description/>
		/// <description>GetCreationFlags</description>
		/// </item>
		/// <item>
		/// <description/>
		/// <description>GetPrivateData</description>
		/// </item>
		/// <item>
		/// <description>GetContextFlags</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>GetData</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>Map</description>
		/// <description/>
		/// </item>
		/// <item>
		/// <description>Unmap</description>
		/// <description/>
		/// </item>
		/// </list>
		/// <para>
		/// The following table shows the ID3D10Device interface methods that the runtime does not disable because they are not immediate
		/// context methods.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Methods of ID3D10Device</description>
		/// </listheader>
		/// <item>
		/// <description>CheckCounter</description>
		/// </item>
		/// <item>
		/// <description>CheckCounterInfo</description>
		/// </item>
		/// <item>
		/// <description>Create*, like CreateQuery</description>
		/// </item>
		/// <item>
		/// <description>GetDeviceRemovedReason</description>
		/// </item>
		/// <item>
		/// <description>GetExceptionMode</description>
		/// </item>
		/// <item>
		/// <description>OpenSharedResource</description>
		/// </item>
		/// <item>
		/// <description>SetExceptionMode</description>
		/// </item>
		/// <item>
		/// <description>SetPrivateData</description>
		/// </item>
		/// <item>
		/// <description>SetPrivateDataInterface</description>
		/// </item>
		/// </list>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-createdevicecontextstate HRESULT
		// CreateDeviceContextState( UINT Flags, [in] const D3D_FEATURE_LEVEL *pFeatureLevels, UINT FeatureLevels, UINT SDKVersion, REFIID
		// EmulatedInterface, [out, optional] D3D_FEATURE_LEVEL *pChosenFeatureLevel, [out, optional] ID3DDeviceContextState
		// **ppContextState );
		[PreserveSig]
		new HRESULT CreateDeviceContextState(D3D11_1_CREATE_DEVICE_CONTEXT_STATE_FLAG Flags, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D_FEATURE_LEVEL[] pFeatureLevels,
			int FeatureLevels, uint SDKVersion, in Guid EmulatedInterface, out D3D_FEATURE_LEVEL pChosenFeatureLevel, out ID3DDeviceContextState? ppContextState);

		/// <summary>
		/// Gives a device access to a shared resource that is referenced by a handle and that was created on a different device. You must
		/// have previously created the resource as shared and specified that it uses NT handles (that is, you set the
		/// D3D11_RESOURCE_MISC_SHARED_NTHANDLE flag).
		/// </summary>
		/// <param name="hResource">A handle to the resource to open. For more info about this parameter, see Remarks.</param>
		/// <param name="returnedInterface">
		/// The globally unique identifier (GUID) for the resource interface. For more info about this parameter, see Remarks.
		/// </param>
		/// <param name="ppResource">
		/// A pointer to a variable that receives a pointer to the interface for the shared resource object to access.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns one of the Direct3D 11 return codes. This method also returns E_ACCESSDENIED if the permissions to access
		/// the resource aren't valid.
		/// </para>
		/// <para>
		/// <c>Platform Update for Windows 7:  </c> On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
		/// <c>OpenSharedResource1</c> fails with E_NOTIMPL because NTHANDLES are used. For more info about the Platform Update for
		/// Windows 7, see Platform Update for Windows 7.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The behavior of <c>OpenSharedResource1</c> is similar to the behavior of the ID3D11Device::OpenSharedResource method; each call
		/// to <c>OpenSharedResource1</c> to access a resource creates a new resource object. In other words, if you call
		/// <c>OpenSharedResource1</c> twice and pass the same resource handle to <c>hResource</c>, you receive two resource objects with
		/// different IUnknown pointers.
		/// </para>
		/// <para><c>To share a resource between two devices</c></para>
		/// <list type="number">
		/// <item>
		/// <description>
		/// Create the resource as shared and specify that it uses NT handles, by setting the D3D11_RESOURCE_MISC_SHARED_NTHANDLE flag.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Obtain the REFIID, or GUID, of the interface to the resource by using the __uuidof() macro. For example,
		/// __uuidof(ID3D11Texture2D) retrieves the GUID of the interface to a 2D texture.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Query the resource for the IDXGIResource1 interface.</description>
		/// </item>
		/// <item>
		/// <description>Call the IDXGIResource1::CreateSharedHandle method to obtain the unique handle to the resource.</description>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-opensharedresource1 HRESULT
		// OpenSharedResource1( [in] HANDLE hResource, [in] REFIID returnedInterface, [out] void **ppResource );
		[PreserveSig]
		new HRESULT OpenSharedResource1(HANDLE hResource, in Guid returnedInterface, [MarshalAs(UnmanagedType.Interface)] out object ppResource);

		/// <summary>
		/// Gives a device access to a shared resource that is referenced by name and that was created on a different device. You must have
		/// previously created the resource as shared and specified that it uses NT handles (that is, you set the
		/// D3D11_RESOURCE_MISC_SHARED_NTHANDLE flag).
		/// </summary>
		/// <param name="lpName">The name of the resource to open. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="dwDesiredAccess">
		/// <para>The requested access rights to the resource. In addition to the generic access rights, DXGI defines the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>DXGI_SHARED_RESOURCE_READ</c> ( 0x80000000L ) - specifies read access to the resource.</description>
		/// </item>
		/// <item>
		/// <description><c>DXGI_SHARED_RESOURCE_WRITE</c> ( 1 ) - specifies write access to the resource.</description>
		/// </item>
		/// </list>
		/// <para>You can combine values by using a bitwise OR operation.</para>
		/// </param>
		/// <param name="returnedInterface">The globally unique identifier (GUID) for the resource interface. For more info, see Remarks.</param>
		/// <param name="ppResource">
		/// A pointer to a variable that receives a pointer to the interface for the shared resource object to access.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns one of the Direct3D 11 return codes. This method also returns E_ACCESSDENIED if the permissions to access
		/// the resource aren't valid.
		/// </para>
		/// <para>
		/// <c>Platform Update for Windows 7:  </c> On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
		/// <c>OpenSharedResourceByName</c> fails with E_NOTIMPL because NTHANDLES are used. For more info about the Platform Update for
		/// Windows 7, see Platform Update for Windows 7.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The behavior of <c>OpenSharedResourceByName</c> is similar to the behavior of the ID3D11Device1::OpenSharedResource1 method;
		/// each call to <c>OpenSharedResourceByName</c> to access a resource creates a new resource object. In other words, if you call
		/// <c>OpenSharedResourceByName</c> twice and pass the same resource name to <c>lpName</c>, you receive two resource objects with
		/// different IUnknown pointers.
		/// </para>
		/// <para><c>To share a resource between two devices</c></para>
		/// <list type="number">
		/// <item>
		/// <description>
		/// Create the resource as shared and specify that it uses NT handles, by setting the D3D11_RESOURCE_MISC_SHARED_NTHANDLE flag.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Obtain the REFIID, or GUID, of the interface to the resource by using the __uuidof() macro. For example,
		/// __uuidof(ID3D11Texture2D) retrieves the GUID of the interface to a 2D texture.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Query the resource for the IDXGIResource1 interface.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Call the IDXGIResource1::CreateSharedHandle method to obtain the unique handle to the resource. In this
		/// <c>IDXGIResource1::CreateSharedHandle</c> call, you must pass a name for the resource if you want to subsequently call
		/// <c>OpenSharedResourceByName</c> to access the resource by name.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11device1-opensharedresourcebyname HRESULT
		// OpenSharedResourceByName( [in] LPCWSTR lpName, [in] DWORD dwDesiredAccess, [in] REFIID returnedInterface, [out] void **ppResource );
		[PreserveSig]
		new HRESULT OpenSharedResourceByName([MarshalAs(UnmanagedType.LPWStr)] string lpName, DXGI_SHARED_RESOURCE_RW dwDesiredAccess,
			in Guid returnedInterface, [MarshalAs(UnmanagedType.Interface)] out object ppResource);

		/// <summary>Gets an immediate context, which can play back command lists.</summary>
		/// <param name="ppImmediateContext">
		/// <para>Type: <c>ID3D11DeviceContext2**</c></para>
		/// <para>Upon completion of the method, the passed pointer to an ID3D11DeviceContext2 interface pointer is initialized.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The <c>GetImmediateContext2</c> method returns an ID3D11DeviceContext2 object that represents an immediate context, which is
		/// used to perform rendering that you want immediately submitted to a device. For most apps, an immediate context is the primary
		/// object that is used to draw your scene.
		/// </para>
		/// <para>
		/// The <c>GetImmediateContext2</c> method increments the reference count of the immediate context by one. Therefore, you must call
		/// Release on the returned interface pointer when you are done with it to avoid a memory leak.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11device2-getimmediatecontext2 void
		// GetImmediateContext2( [out] ID3D11DeviceContext2 **ppImmediateContext );
		[PreserveSig]
		void GetImmediateContext2(out ID3D11DeviceContext2 ppImmediateContext);

		/// <summary>Creates a deferred context, which can record command lists.</summary>
		/// <param name="ContextFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Reserved for future use. Pass 0.</para>
		/// </param>
		/// <param name="ppDeferredContext">
		/// <para>Type: <c>ID3D11DeviceContext2**</c></para>
		/// <para>Upon completion of the method, the passed pointer to an ID3D11DeviceContext2 interface pointer is initialized.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Returns <c>DXGI_ERROR_DEVICE_REMOVED</c> if the video card has been physically removed from the system, or a driver upgrade for
		/// the video card has occurred. If this error occurs, you should destroy and recreate the device.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns <c>DXGI_ERROR_INVALID_CALL</c> if the <c>CreateDeferredContext2</c> method can't be called from the current context. For
		/// example, if the device was created with the D3D11_CREATE_DEVICE_SINGLETHREADED value, <c>CreateDeferredContext2</c> returns <c>DXGI_ERROR_INVALID_CALL</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Returns <c>E_INVALIDARG</c> if the <c>ContextFlags</c> parameter is invalid.</description>
		/// </item>
		/// <item>
		/// <description>Returns <c>E_OUTOFMEMORY</c> if the app has exhausted available memory.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A deferred context is a thread-safe context that you can use to record graphics commands on a thread other than the main
		/// rendering thread. By using a deferred context, you can record graphics commands into a command list that is encapsulated by the
		/// ID3D11CommandList interface. After you record all scene items, you can then submit them to the main render thread for final
		/// rendering. In this manner, you can perform rendering tasks concurrently across multiple threads and potentially improve
		/// performance in multi-core CPU scenarios.
		/// </para>
		/// <para>You can create multiple deferred contexts.</para>
		/// <para>
		/// <c>Note</c>  If you use the D3D11_CREATE_DEVICE_SINGLETHREADED value to create the device, <c>CreateDeferredContext2</c> fails
		/// with <c>DXGI_ERROR_INVALID_CALL</c>, and you can't create a deferred context.
		/// </para>
		/// <para></para>
		/// <para>For more information about deferred contexts, see Immediate and Deferred Rendering.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11device2-createdeferredcontext2 HRESULT
		// CreateDeferredContext2( UINT ContextFlags, [out, optional] ID3D11DeviceContext2 **ppDeferredContext );
		[PreserveSig]
		HRESULT CreateDeferredContext2([Optional] uint ContextFlags, out ID3D11DeviceContext2? ppDeferredContext);

		/// <summary>Gets info about how a tiled resource is broken into tiles.</summary>
		/// <param name="pTiledResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the tiled resource to get info about.</para>
		/// </param>
		/// <param name="pNumTilesForEntireResource">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to a variable that receives the number of tiles needed to store the entire tiled resource.</para>
		/// </param>
		/// <param name="pPackedMipDesc">
		/// <para>Type: <c>D3D11_PACKED_MIP_DESC*</c></para>
		/// <para>
		/// A pointer to a D3D11_PACKED_MIP_DESC structure that <c>GetResourceTiling</c> fills with info about how the tiled resource's
		/// mipmaps are packed.
		/// </para>
		/// </param>
		/// <param name="pStandardTileShapeForNonPackedMips">
		/// <para>Type: <c>D3D11_TILE_SHAPE*</c></para>
		/// <para>
		/// A pointer to a D3D11_TILE_SHAPE structure that <c>GetResourceTiling</c> fills with info about the tile shape. This is info about
		/// how pixels fit in the tiles, independent of tiled resource's dimensions, not including packed mipmaps. If the entire tiled
		/// resource is packed, this parameter is meaningless because the tiled resource has no defined layout for packed mipmaps. In this
		/// situation, <c>GetResourceTiling</c> sets the members of <c>D3D11_TILE_SHAPE</c> to zeros.
		/// </para>
		/// </param>
		/// <param name="pNumSubresourceTilings">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer to a variable that contains the number of tiles in the subresource. On input, this is the number of subresources to
		/// query tilings for; on output, this is the number that was actually retrieved at <c>pSubresourceTilingsForNonPackedMips</c>
		/// (clamped to what's available).
		/// </para>
		/// </param>
		/// <param name="FirstSubresourceTilingToGet">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of the first subresource tile to get. <c>GetResourceTiling</c> ignores this parameter if the number that
		/// <c>pNumSubresourceTilings</c> points to is 0.
		/// </para>
		/// </param>
		/// <param name="pSubresourceTilingsForNonPackedMips">
		/// <para>Type: <c>D3D11_SUBRESOURCE_TILING*</c></para>
		/// <para>A pointer to a D3D11_SUBRESOURCE_TILING structure that <c>GetResourceTiling</c> fills with info about subresource tiles.</para>
		/// <para>
		/// If subresource tiles are part of packed mipmaps, <c>GetResourceTiling</c> sets the members of D3D11_SUBRESOURCE_TILING to zeros,
		/// except the <c>StartTileIndexInOverallResource</c> member, which <c>GetResourceTiling</c> sets to <c>D3D11_PACKED_TILE</c>
		/// (0xffffffff). The <c>D3D11_PACKED_TILE</c> constant indicates that the whole <c>D3D11_SUBRESOURCE_TILING</c> structure is
		/// meaningless for this situation, and the info that the <c>pPackedMipDesc</c> parameter points to applies.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>For more info about tiled resources, see Tiled resources.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11device2-getresourcetiling void GetResourceTiling(
		// [in] ID3D11Resource *pTiledResource, [out, optional] UINT *pNumTilesForEntireResource, [out, optional] D3D11_PACKED_MIP_DESC
		// *pPackedMipDesc, [out, optional] D3D11_TILE_SHAPE *pStandardTileShapeForNonPackedMips, [in, out, optional] UINT
		// *pNumSubresourceTilings, [in] UINT FirstSubresourceTilingToGet, [out] D3D11_SUBRESOURCE_TILING
		// *pSubresourceTilingsForNonPackedMips );
		[PreserveSig]
		void GetResourceTiling([In] ID3D11Resource pTiledResource, out uint pNumTilesForEntireResource, out D3D11_PACKED_MIP_DESC pPackedMipDesc,
			out D3D11_TILE_SHAPE pStandardTileShapeForNonPackedMips, out uint pNumSubresourceTilings, uint FirstSubresourceTilingToGet,
			out D3D11_SUBRESOURCE_TILING pSubresourceTilingsForNonPackedMips);

		/// <summary>Get the number of quality levels available during multisampling.</summary>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The texture format during multisampling.</para>
		/// </param>
		/// <param name="SampleCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of samples during multisampling.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A combination of D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAGS values that are combined by using a bitwise OR operation.
		/// Currently, only D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_TILED_RESOURCE is supported.
		/// </para>
		/// </param>
		/// <param name="pNumQualityLevels">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to a variable the receives the number of quality levels supported by the adapter. See Remarks.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you multisample a texture, the number of quality levels available for an adapter is dependent on the texture format that
		/// you use and the number of samples that you request. The maximum number of quality levels is defined by
		/// <c>D3D11_MAX_MULTISAMPLE_SAMPLE_COUNT</c> in D3D11.h. If this method returns 0, the format and sample count combination is not
		/// supported for the installed adapter.
		/// </para>
		/// <para>
		/// Furthermore, the definition of a quality level is up to each hardware vendor to define, however no facility is provided by
		/// Direct3D to help discover this information.
		/// </para>
		/// <para>
		/// Note that FEATURE_LEVEL_10_1 devices are required to support 4x MSAA for all render targets except R32G32B32A32 and R32G32B32.
		/// FEATURE_LEVEL_11_0 devices are required to support 4x MSAA for all render target formats, and 8x MSAA for all render target
		/// formats except R32G32B32A32 formats.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11device2-checkmultisamplequalitylevels1 HRESULT
		// CheckMultisampleQualityLevels1( [in] DXGI_FORMAT Format, [in] UINT SampleCount, [in] UINT Flags, [out] UINT *pNumQualityLevels );
		[PreserveSig]
		HRESULT CheckMultisampleQualityLevels1(DXGI_FORMAT Format, uint SampleCount, D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG Flags, out uint pNumQualityLevels);
	}

	/// <summary>
	/// The device context interface represents a device context; it is used to render commands. <c>ID3D11DeviceContext2</c> adds new
	/// methods to those in ID3D11DeviceContext1.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nn-d3d11_2-id3d11devicecontext2
	[PInvokeData("d3d11_2.h", MSDNShortId = "NN:d3d11_2.ID3D11DeviceContext2")]
	[ComImport, Guid("420d5b32-b90c-4da4-bef0-359f6a24a83a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11DeviceContext2 : ID3D11DeviceContext1, ID3D11DeviceContext, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Sets the constant buffers used by the vertex shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, can bind a larger number of ID3D11Buffer resources to the
		/// shader than the maximum constant buffer size that is supported by shaders (4096 constants – 4*32-bit components each). When you
		/// bind such a large buffer, the shader can access only the first 4096 4*32-bit component constants in the buffer, as if 4096
		/// constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// If the application wants the shader to access other parts of the buffer, it must call the VSSetConstantBuffers1 method instead.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vssetconstantbuffers void
		// VSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		new void VSSetConstantBuffers(uint StartSlot, int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Bind an array of shader resources to the pixel shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a rendertarget, then this API will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-pssetshaderresources void
		// PSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		new void PSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Sets a pixel shader to the device.</summary>
		/// <param name="pPixelShader">
		/// <para>Type: <c>ID3D11PixelShader*</c></para>
		/// <para>Pointer to a pixel shader (see ID3D11PixelShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// <para>
		/// Set ppClassInstances to <c>NULL</c> if no interfaces are used in the shader. If it is not <c>NULL</c>, the number of class
		/// instances must match the number of interfaces used in the shader. Furthermore, each interface pointer must have a corresponding
		/// class instance or the assigned shader will be disabled.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-pssetshader void PSSetShader( [in,
		// optional] ID3D11PixelShader *pPixelShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint NumClassInstances );
		[PreserveSig]
		new void PSSetShader([In] ID3D11PixelShader? pPixelShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Set an array of sampler states to the pixel shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>State</description>
		/// <description>Default Value</description>
		/// </listheader>
		/// <item>
		/// <description>Filter</description>
		/// <description>D3D11_FILTER_MIN_MAG_MIP_LINEAR</description>
		/// </item>
		/// <item>
		/// <description>AddressU</description>
		/// <description>D3D11_TEXTURE_ADDRESS_CLAMP</description>
		/// </item>
		/// <item>
		/// <description>AddressV</description>
		/// <description>D3D11_TEXTURE_ADDRESS_CLAMP</description>
		/// </item>
		/// <item>
		/// <description>AddressW</description>
		/// <description>D3D11_TEXTURE_ADDRESS_CLAMP</description>
		/// </item>
		/// <item>
		/// <description>MipLODBias</description>
		/// <description>0</description>
		/// </item>
		/// <item>
		/// <description>MaxAnisotropy</description>
		/// <description>1</description>
		/// </item>
		/// <item>
		/// <description>ComparisonFunc</description>
		/// <description>D3D11_COMPARISON_NEVER</description>
		/// </item>
		/// <item>
		/// <description>BorderColor[0]</description>
		/// <description>1.0f</description>
		/// </item>
		/// <item>
		/// <description>BorderColor[1]</description>
		/// <description>1.0f</description>
		/// </item>
		/// <item>
		/// <description>BorderColor[2]</description>
		/// <description>1.0f</description>
		/// </item>
		/// <item>
		/// <description>BorderColor[3]</description>
		/// <description>1.0f</description>
		/// </item>
		/// <item>
		/// <description>MinLOD</description>
		/// <description>-FLT_MAX</description>
		/// </item>
		/// <item>
		/// <description>MaxLOD</description>
		/// <description>FLT_MAX</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-pssetsamplers void PSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		new void PSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Set a vertex shader to the device.</summary>
		/// <param name="pVertexShader">
		/// <para>Type: <c>ID3D11VertexShader*</c></para>
		/// <para>Pointer to a vertex shader (see ID3D11VertexShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vssetshader void VSSetShader( [in,
		// optional] ID3D11VertexShader *pVertexShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint NumClassInstances );
		[PreserveSig]
		new void VSSetShader([In] ID3D11VertexShader? pVertexShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Draw indexed, non-instanced primitives.</summary>
		/// <param name="IndexCount">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of indices to draw.</para>
		/// </param>
		/// <param name="StartIndexLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>The location of the first index read by the GPU from the index buffer.</para>
		/// </param>
		/// <param name="BaseVertexLocation">
		/// <para>Type: <c>INT</c></para>
		/// <para>A value added to each index before reading a vertex from the vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>If the sum of both indices is negative, the result of the function call is undefined.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawindexed void DrawIndexed( [in] uint
		// IndexCount, [in] uint StartIndexLocation, [in] INT BaseVertexLocation );
		[PreserveSig]
		new void DrawIndexed(uint IndexCount, uint StartIndexLocation, int BaseVertexLocation);

		/// <summary>Draw non-indexed, non-instanced primitives.</summary>
		/// <param name="VertexCount">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of vertices to draw.</para>
		/// </param>
		/// <param name="StartVertexLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>Index of the first vertex, which is usually an offset in a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><c>Draw</c> submits work to the rendering pipeline.</para>
		/// <para>The vertex data for a draw call normally comes from a vertex buffer that is bound to the pipeline.</para>
		/// <para>
		/// Even without any vertex buffer bound to the pipeline, you can generate your own vertex data in your vertex shader by using the
		/// SV_VertexID system-value semantic to determine the current vertex that the runtime is processing.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-draw void Draw( [in] uint VertexCount,
		// [in] uint StartVertexLocation );
		[PreserveSig]
		new void Draw(uint VertexCount, uint StartVertexLocation);

		/// <summary>Gets a pointer to the data contained in a subresource, and denies the GPU access to that subresource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to a ID3D11Resource interface.</para>
		/// </param>
		/// <param name="Subresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>Index number of the subresource.</para>
		/// </param>
		/// <param name="MapType">
		/// <para>Type: <c>D3D11_MAP</c></para>
		/// <para>A D3D11_MAP-typed value that specifies the CPU's read and write permissions for a resource.</para>
		/// </param>
		/// <param name="MapFlags">
		/// <para>Type: <c>uint</c></para>
		/// <para>Flag that specifies what the CPU does when the GPU is busy. This flag is optional.</para>
		/// </param>
		/// <param name="pMappedResource">
		/// <para>Type: <c>D3D11_MAPPED_SUBRESOURCE*</c></para>
		/// <para>
		/// A pointer to the D3D11_MAPPED_SUBRESOURCE structure for the mapped subresource. See the Remarks section regarding NULL pointers.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// <para>
		/// This method also returns <c>DXGI_ERROR_WAS_STILL_DRAWING</c> if <c>MapFlags</c> specifies <c>D3D11_MAP_FLAG_DO_NOT_WAIT</c> and
		/// the GPU is not yet finished with the resource.
		/// </para>
		/// <para>
		/// This method also returns <c>DXGI_ERROR_DEVICE_REMOVED</c> if <c>MapType</c> allows any CPU read access and the video card has
		/// been removed.
		/// </para>
		/// <para>For more information about these error codes, see DXGI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call <c>Map</c> on a deferred context, you can only pass D3D11_MAP_WRITE_DISCARD, D3D11_MAP_WRITE_NO_OVERWRITE, or both
		/// to the <c>MapType</c> parameter. Other <c>D3D11_MAP</c>-typed values are not supported for a deferred context.
		/// </para>
		/// <note>The Direct3D 11.1 runtime, which is available starting with Windows 8, enables mapping dynamic constant buffers and shader
		/// resource views (SRVs) of dynamic buffers with D3D11_MAP_WRITE_NO_OVERWRITE. The Direct3D 11 and earlier runtimes limited mapping
		/// to vertex or index buffers. To determine if a Direct3D device supports these features, call ID3D11Device::CheckFeatureSupport
		/// with D3D11_FEATURE_D3D11_OPTIONS. <c>CheckFeatureSupport</c> fills members of a D3D11_FEATURE_DATA_D3D11_OPTIONS structure with
		/// the device's features. The relevant members here are <c>MapNoOverwriteOnDynamicConstantBuffer</c> and <c>MapNoOverwriteOnDynamicBufferSRV</c>.</note>
		/// <para>For info about how to use <c>Map</c>, see How to: Use dynamic resources.</para>
		/// <h2>NULL pointers for pMappedResource</h2>
		/// <para>
		/// The <c>pMappedResource</c> parameter may be NULL when a texture is provided that was created with D3D11_USAGE_DEFAULT, and the
		/// API is called on an immediate context. This allows a default texture to be mapped, even if it was created using
		/// D3D11_TEXTURE_LAYOUT_UNDEFINED. Following this API call, the texture may be accessed using
		/// ID3D11DeviceContext3::WriteToSubresource and/or ID3D11DeviceContext3::ReadFromSubresource.
		/// </para>
		/// <h2>Don't read from a subresource mapped for writing</h2>
		/// <para>
		/// When you pass D3D11_MAP_WRITE, D3D11_MAP_WRITE_DISCARD, or D3D11_MAP_WRITE_NO_OVERWRITE to the <c>MapType</c> parameter, you
		/// must ensure that your app does not read the subresource data to which the <c>pData</c> member of D3D11_MAPPED_SUBRESOURCE points
		/// because doing so can cause a significant performance penalty. The memory region to which <c>pData</c> points can be allocated
		/// with PAGE_WRITECOMBINE, and your app must honor all restrictions that are associated with such memory.
		/// </para>
		/// <note>  
		/// <para>
		/// Even the following C++ code can read from memory and trigger the performance penalty because the code can expand to the
		/// following x86 assembly code.
		/// </para>
		/// <code language="cpp">*((int*)MappedResource.pData) = 0;</code>
		/// <code language="none">AND DWORD PTR [EAX],0</code>
		/// </note>
		/// <para>
		/// Use the appropriate optimization settings and language constructs to help avoid this performance penalty. For example, you can
		/// avoid the xor optimization by using a <c>volatile</c> pointer or by optimizing for code speed instead of code size.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-map HRESULT Map( [in] ID3D11Resource
		// *pResource, [in] uint Subresource, [in] D3D11_MAP MapType, [in] uint MapFlags, [out, optional] D3D11_MAPPED_SUBRESOURCE
		// *pMappedResource );
		[PreserveSig]
		new HRESULT Map([In] ID3D11Resource pResource, uint Subresource, D3D11_MAP MapType, [Optional] D3D11_MAP_FLAG MapFlags, out D3D11_MAPPED_SUBRESOURCE pMappedResource);

		/// <summary>Invalidate the pointer to a resource and reenable the GPU's access to that resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to a ID3D11Resource interface.</para>
		/// </param>
		/// <param name="Subresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>A subresource to be unmapped.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>For info about how to use <c>Unmap</c>, see How to: Use dynamic resources.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-unmap void Unmap( [in] ID3D11Resource
		// *pResource, [in] uint Subresource );
		[PreserveSig]
		new void Unmap([In] ID3D11Resource pResource, uint Subresource);

		/// <summary>Sets the constant buffers used by the pixel shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems, can bind a larger number of ID3D11Buffer
		/// resources to the shader than the maximum constant buffer size that is supported by shaders (4096 constants – 432-bit components
		/// each). When you bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer,
		/// as if 4096 constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// To enable the shader to access other parts of the buffer, call PSSetConstantBuffers1 instead of <c>PSSetConstantBuffers</c>.
		/// <c>PSSetConstantBuffers1</c> has additional parameters <c>pFirstConstant</c> and <c>pNumConstants</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-pssetconstantbuffers void
		// PSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		new void PSSetConstantBuffers(uint StartSlot, int NumBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Bind an input-layout object to the input-assembler stage.</summary>
		/// <param name="pInputLayout">
		/// <para>Type: <c>ID3D11InputLayout*</c></para>
		/// <para>
		/// A pointer to the input-layout object (see ID3D11InputLayout), which describes the input buffers that will be read by the IA stage.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Input-layout objects describe how vertex buffer data is streamed into the IA pipeline stage. To create an input-layout object,
		/// call ID3D11Device::CreateInputLayout.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iasetinputlayout void IASetInputLayout(
		// [in, optional] ID3D11InputLayout *pInputLayout );
		[PreserveSig]
		new void IASetInputLayout([In] ID3D11InputLayout? pInputLayout);

		/// <summary>Bind an array of vertex buffers to the input-assembler stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The first input slot for binding. The first vertex buffer is explicitly bound to the start slot; this causes each additional
		/// vertex buffer in the array to be implicitly bound to each subsequent input slot. The maximum of 16 or 32 input slots (ranges
		/// from 0 to D3D11_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT - 1) are available; the maximum number of input slots depends on the feature level.
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of vertex buffers in the array. The number of buffers (plus the starting slot) can't exceed the total number of
		/// IA-stage input slots (ranges from 0 to D3D11_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppVertexBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>
		/// A pointer to an array of vertex buffers (see ID3D11Buffer). The vertex buffers must have been created with the
		/// D3D11_BIND_VERTEX_BUFFER flag.
		/// </para>
		/// </param>
		/// <param name="pStrides">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>
		/// Pointer to an array of stride values; one stride value for each buffer in the vertex-buffer array. Each stride is the size (in
		/// bytes) of the elements that are to be used from that vertex buffer.
		/// </para>
		/// </param>
		/// <param name="pOffsets">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>
		/// Pointer to an array of offset values; one offset value for each buffer in the vertex-buffer array. Each offset is the number of
		/// bytes between the first element of a vertex buffer and the first element that will be used.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>For info about creating vertex buffers, see How to: Create a Vertex Buffer.</para>
		/// <para>
		/// Calling this method using a buffer that is currently bound for writing (that is, bound to the stream output pipeline stage) will
		/// effectively bind <c>NULL</c> instead because a buffer can't be bound as both an input and an output at the same time.
		/// </para>
		/// <para>
		/// The debug layer will generate a warning whenever a resource is prevented from being bound simultaneously as an input and an
		/// output, but this will not prevent invalid data from being used by the runtime.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iasetvertexbuffers void
		// IASetVertexBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppVertexBuffers, [in,
		// optional] const uint *pStrides, [in, optional] const uint *pOffsets );
		[PreserveSig]
		new void IASetVertexBuffers(uint StartSlot, int NumBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppVertexBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pStrides,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pOffsets);

		/// <summary>Bind an index buffer to the input-assembler stage.</summary>
		/// <param name="pIndexBuffer">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>
		/// A pointer to an ID3D11Buffer object, that contains indices. The index buffer must have been created with the
		/// D3D11_BIND_INDEX_BUFFER flag.
		/// </para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>
		/// A DXGI_FORMAT that specifies the format of the data in the index buffer. The only formats allowed for index buffer data are
		/// 16-bit (DXGI_FORMAT_R16_UINT) and 32-bit (DXGI_FORMAT_R32_UINT) integers.
		/// </para>
		/// </param>
		/// <param name="Offset">
		/// <para>Type: <c>uint</c></para>
		/// <para>Offset (in bytes) from the start of the index buffer to the first index to use.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>For information about creating index buffers, see How to: Create an Index Buffer.</para>
		/// <para>
		/// Calling this method using a buffer that is currently bound for writing (i.e. bound to the stream output pipeline stage) will
		/// effectively bind <c>NULL</c> instead because a buffer cannot be bound as both an input and an output at the same time.
		/// </para>
		/// <para>
		/// The debug layer will generate a warning whenever a resource is prevented from being bound simultaneously as an input and an
		/// output, but this will not prevent invalid data from being used by the runtime.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iasetindexbuffer void IASetIndexBuffer(
		// [in, optional] ID3D11Buffer *pIndexBuffer, [in] DXGI_FORMAT Format, [in] uint Offset );
		[PreserveSig]
		new void IASetIndexBuffer([In] ID3D11Buffer? pIndexBuffer, DXGI_FORMAT Format, uint Offset);

		/// <summary>Draw indexed, instanced primitives.</summary>
		/// <param name="IndexCountPerInstance">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of indices read from the index buffer for each instance.</para>
		/// </param>
		/// <param name="InstanceCount">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of instances to draw.</para>
		/// </param>
		/// <param name="StartIndexLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>The location of the first index read by the GPU from the index buffer.</para>
		/// </param>
		/// <param name="BaseVertexLocation">
		/// <para>Type: <c>INT</c></para>
		/// <para>A value added to each index before reading a vertex from the vertex buffer.</para>
		/// </param>
		/// <param name="StartInstanceLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>A value added to each index before reading per-instance data from a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>
		/// Instancing may extend performance by reusing the same geometry to draw multiple objects in a scene. One example of instancing
		/// could be to draw the same object with different positions and colors. Instancing requires multiple vertex buffers: at least one
		/// for per-vertex data and a second buffer for per-instance data.
		/// </para>
		/// <para>
		/// The second buffer is needed only if the input layout that you use has elements that use D3D11_INPUT_PER_INSTANCE_DATA as the
		/// input element classification buffer for per-instance data.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawindexedinstanced void
		// DrawIndexedInstanced( [in] uint IndexCountPerInstance, [in] uint InstanceCount, [in] uint StartIndexLocation, [in] INT
		// BaseVertexLocation, [in] uint StartInstanceLocation );
		[PreserveSig]
		new void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, int BaseVertexLocation, uint StartInstanceLocation);

		/// <summary>Draw non-indexed, instanced primitives.</summary>
		/// <param name="VertexCountPerInstance">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of vertices to draw.</para>
		/// </param>
		/// <param name="InstanceCount">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of instances to draw.</para>
		/// </param>
		/// <param name="StartVertexLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>Index of the first vertex.</para>
		/// </param>
		/// <param name="StartInstanceLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>A value added to each index before reading per-instance data from a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>
		/// Instancing may extend performance by reusing the same geometry to draw multiple objects in a scene. One example of instancing
		/// could be to draw the same object with different positions and colors.
		/// </para>
		/// <para>
		/// The vertex data for an instanced draw call normally comes from a vertex buffer that is bound to the pipeline. However, you could
		/// also provide the vertex data from a shader that has instanced data identified with a system-value semantic (SV_InstanceID).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawinstanced void DrawInstanced( [in]
		// uint VertexCountPerInstance, [in] uint InstanceCount, [in] uint StartVertexLocation, [in] uint StartInstanceLocation );
		[PreserveSig]
		new void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);

		/// <summary>Sets the constant buffers used by the geometry shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// You can't use the ID3D11ShaderReflectionConstantBuffer interface to get information about what is currently bound to the
		/// pipeline in the device context. But you can use <c>ID3D11ShaderReflectionConstantBuffer</c> to get information from a compiled
		/// shader. For example, you can use <c>ID3D11ShaderReflectionConstantBuffer</c> and ID3D11ShaderReflectionVariable to determine the
		/// slot in which a geometry shader expects a constant buffer. You can then pass this slot number to <c>GSSetConstantBuffers</c> to
		/// set the constant buffer. You can call the D3D11Reflect function to retrieve the address of a pointer to the
		/// ID3D11ShaderReflection interface and then call ID3D11ShaderReflection::GetConstantBufferByName to get a pointer to <c>ID3D11ShaderReflectionConstantBuffer</c>.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, can bind a larger number of ID3D11Buffer resources to the
		/// shader than the maximum constant buffer size that is supported by shaders (4096 constants – 432-bit components each). When you
		/// bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer, as if 4096
		/// constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// If the application wants the shader to access other parts of the buffer, it must call the GSSetConstantBuffers1 method instead.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gssetconstantbuffers void
		// GSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		new void GSSetConstantBuffers(uint StartSlot, int NumBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Set a geometry shader to the device.</summary>
		/// <param name="pShader">
		/// <para>Type: <c>ID3D11GeometryShader*</c></para>
		/// <para>
		/// Pointer to a geometry shader (see ID3D11GeometryShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.
		/// </para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gssetshader void GSSetShader( [in,
		// optional] ID3D11GeometryShader *pShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint NumClassInstances );
		[PreserveSig]
		new void GSSetShader([In] ID3D11GeometryShader? pShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Bind information about the primitive type, and data order that describes input data for the input assembler stage.</summary>
		/// <param name="Topology">
		/// <para>Type: <c>D3D11_PRIMITIVE_TOPOLOGY</c></para>
		/// <para>The type of primitive and ordering of the primitive data (see D3D11_PRIMITIVE_TOPOLOGY).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iasetprimitivetopology void
		// IASetPrimitiveTopology( [in] D3D11_PRIMITIVE_TOPOLOGY Topology );
		[PreserveSig]
		new void IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY Topology);

		/// <summary>Bind an array of shader resources to the vertex-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (range is from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources (range is from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a rendertarget, then this API will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// In order to unbind resource slots, you must pass an array containing null values. For example, to clear the first 4 slots, use:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vssetshaderresources void
		// VSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		new void VSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Set an array of sampler states to the vertex shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vssetsamplers void VSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		new void VSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Mark the beginning of a series of commands.</summary>
		/// <param name="pAsync">
		/// <para>Type: <c>ID3D11Asynchronous*</c></para>
		/// <para>A pointer to an ID3D11Asynchronous interface.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Use ID3D11DeviceContext::End to mark the ending of the series of commands.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-begin void Begin( [in] ID3D11Asynchronous
		// *pAsync );
		[PreserveSig]
		new void Begin([In] ID3D11Asynchronous pAsync);

		/// <summary>Mark the end of a series of commands.</summary>
		/// <param name="pAsync">
		/// <para>Type: <c>ID3D11Asynchronous*</c></para>
		/// <para>A pointer to an ID3D11Asynchronous interface.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Use ID3D11DeviceContext::Begin to mark the beginning of the series of commands.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-end void End( [in] ID3D11Asynchronous
		// *pAsync );
		[PreserveSig]
		new void End([In] ID3D11Asynchronous pAsync);

		/// <summary>Get data from the graphics processing unit (GPU) asynchronously.</summary>
		/// <param name="pAsync">
		/// <para>Type: <c>ID3D11Asynchronous*</c></para>
		/// <para>A pointer to an ID3D11Asynchronous interface for the object about which <c>GetData</c> retrieves data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// Address of memory that will receive the data. If <c>NULL</c>, <c>GetData</c> will be used only to check status. The type of data
		/// output depends on the type of asynchronous interface.
		/// </para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data to retrieve or 0. Must be 0 when <c>pData</c> is <c>NULL</c>.</para>
		/// </param>
		/// <param name="GetDataFlags">
		/// <para>Type: <c>uint</c></para>
		/// <para>Optional flags. Can be 0 or any combination of the flags enumerated by D3D11_ASYNC_GETDATA_FLAG.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns one of the Direct3D 11 Return Codes. A return value of S_OK indicates that the data at <c>pData</c> is
		/// available for the calling application to access. A return value of S_FALSE indicates that the data is not yet available. If the
		/// data is not yet available, the application must call <c>GetData</c> until the data is available.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Queries in a deferred context are limited to predicated drawing. That is, you cannot call <c>ID3D11DeviceContext::GetData</c> on
		/// a deferred context to get data about a query; you can only call <c>GetData</c> on the immediate context to get data about a
		/// query. For predicated drawing, the results of a predication-type query are used by the GPU and not returned to an application.
		/// For more information about predication and predicated drawing, see D3D11DeviceContext::SetPredication.
		/// </para>
		/// <para>
		/// <c>GetData</c> retrieves the data that the runtime collected between calls to ID3D11DeviceContext::Begin and
		/// ID3D11DeviceContext::End. Certain queries only require a call to <c>ID3D11DeviceContext::End</c> in which case the data returned
		/// by <c>GetData</c> is accurate up to the last call to <c>ID3D11DeviceContext::End</c>. For information about the queries that
		/// only require a call to <c>ID3D11DeviceContext::End</c> and about the type of data that <c>GetData</c> retrieves for each query,
		/// see D3D11_QUERY.
		/// </para>
		/// <para>If <c>DataSize</c> is 0, <c>GetData</c> is only used to check status.</para>
		/// <para>
		/// An application gathers counter data by calling ID3D11DeviceContext::Begin, issuing some graphics commands, calling
		/// ID3D11DeviceContext::End, and then calling <c>ID3D11DeviceContext::GetData</c> to get data about what happened in between the
		/// <c>Begin</c> and <c>End</c> calls. For information about performance counter types, see D3D11_COUNTER.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-getdata HRESULT GetData( [in]
		// ID3D11Asynchronous *pAsync, [out, optional] void *pData, [in] uint DataSize, [in] uint GetDataFlags );
		[PreserveSig]
		new HRESULT GetData([In] ID3D11Asynchronous pAsync, [In, Optional] IntPtr pData, uint DataSize, D3D11_ASYNC_GETDATA_FLAG GetDataFlags);

		/// <summary>Set a rendering predicate.</summary>
		/// <param name="pPredicate">
		/// <para>Type: <c>ID3D11Predicate*</c></para>
		/// <para>
		/// A pointer to the ID3D11Predicate interface that represents the rendering predicate. A <c>NULL</c> value indicates "no"
		/// predication; in this case, the value of <c>PredicateValue</c> is irrelevant but will be preserved for ID3D11DeviceContext::GetPredication.
		/// </para>
		/// </param>
		/// <param name="PredicateValue">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If <c>TRUE</c>, rendering will be affected by when the predicate's conditions are met. If <c>FALSE</c>, rendering will be
		/// affected when the conditions are not met.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The predicate must be in the "issued" or "signaled" state to be used for predication. While the predicate is set for
		/// predication, calls to ID3D11DeviceContext::Begin and ID3D11DeviceContext::End are invalid.
		/// </para>
		/// <para>
		/// Use this method to denote that subsequent rendering and resource manipulation commands are not actually performed if the
		/// resulting predicate data of the predicate is equal to the <c>PredicateValue</c>. However, some predicates are only hints, so
		/// they may not actually prevent operations from being performed.
		/// </para>
		/// <para>
		/// The primary usefulness of predication is to allow an application to issue rendering and resource manipulation commands without
		/// taking the performance hit of spinning, waiting for ID3D11DeviceContext::GetData to return. So, predication can occur while
		/// <c>ID3D11DeviceContext::GetData</c> returns <c>S_FALSE</c>. Another way to think of it: an application can also use predication
		/// as a fallback, if it is possible that <c>ID3D11DeviceContext::GetData</c> returns <c>S_FALSE</c>. If
		/// <c>ID3D11DeviceContext::GetData</c> returns <c>S_OK</c>, the application can skip calling the rendering and resource
		/// manipulation commands manually with its own application logic.
		/// </para>
		/// <para>
		/// Rendering and resource manipulation commands for Direct3D 11 include these Draw, Dispatch, Copy, Update, Clear, Generate, and
		/// Resolve operations.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Draw</description>
		/// </item>
		/// <item>
		/// <description>DrawAuto</description>
		/// </item>
		/// <item>
		/// <description>DrawIndexed</description>
		/// </item>
		/// <item>
		/// <description>DrawIndexedInstanced</description>
		/// </item>
		/// <item>
		/// <description>DrawIndexedInstancedIndirect</description>
		/// </item>
		/// <item>
		/// <description>DrawInstanced</description>
		/// </item>
		/// <item>
		/// <description>DrawInstancedIndirect</description>
		/// </item>
		/// <item>
		/// <description>Dispatch</description>
		/// </item>
		/// <item>
		/// <description>DispatchIndirect</description>
		/// </item>
		/// <item>
		/// <description>CopyResource</description>
		/// </item>
		/// <item>
		/// <description>CopyStructureCount</description>
		/// </item>
		/// <item>
		/// <description>CopySubresourceRegion</description>
		/// </item>
		/// <item>
		/// <description>CopySubresourceRegion1</description>
		/// </item>
		/// <item>
		/// <description>CopyTiles</description>
		/// </item>
		/// <item>
		/// <description>CopyTileMappings</description>
		/// </item>
		/// <item>
		/// <description>UpdateSubresource</description>
		/// </item>
		/// <item>
		/// <description>UpdateSubresource1</description>
		/// </item>
		/// <item>
		/// <description>UpdateTiles</description>
		/// </item>
		/// <item>
		/// <description>UpdateTileMappings</description>
		/// </item>
		/// <item>
		/// <description>ClearRenderTargetView</description>
		/// </item>
		/// <item>
		/// <description>ClearUnorderedAccessViewFloat</description>
		/// </item>
		/// <item>
		/// <description>ClearUnorderedAccessViewUint</description>
		/// </item>
		/// <item>
		/// <description>ClearView</description>
		/// </item>
		/// <item>
		/// <description>ClearDepthStencilView</description>
		/// </item>
		/// <item>
		/// <description>GenerateMips</description>
		/// </item>
		/// <item>
		/// <description>ResolveSubresource</description>
		/// </item>
		/// </list>
		/// <para>
		/// You can set a rendering predicate on an immediate or a deferred context. For info about immediate and deferred contexts, see
		/// Immediate and Deferred Rendering.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-setpredication void SetPredication( [in,
		// optional] ID3D11Predicate *pPredicate, [in] BOOL PredicateValue );
		[PreserveSig]
		new void SetPredication([In, Optional] ID3D11Predicate? pPredicate, bool PredicateValue);

		/// <summary>Bind an array of shader resources to the geometry shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources(ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a render target, then the method will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gssetshaderresources void
		// GSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		new void GSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Set an array of sampler states to the geometry shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gssetsamplers void GSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		new void GSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Bind one or more render targets atomically and the depth-stencil buffer to the output-merger stage.</summary>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of render targets to bind (ranges between 0 and <c>D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT</c>). If this parameter is
		/// nonzero, the number of entries in the array to which <c>ppRenderTargetViews</c> points must equal the number in this parameter.
		/// </para>
		/// </param>
		/// <param name="ppRenderTargetViews">
		/// <para>Type: <c>ID3D11RenderTargetView*</c></para>
		/// <para>
		/// Pointer to an array of ID3D11RenderTargetView that represent the render targets to bind to the device. If this parameter is
		/// <c>NULL</c> and <c>NumViews</c> is 0, no render targets are bound.
		/// </para>
		/// </param>
		/// <param name="pDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView*</c></para>
		/// <para>
		/// Pointer to a ID3D11DepthStencilView that represents the depth-stencil view to bind to the device. If this parameter is
		/// <c>NULL</c>, the depth-stencil view is not bound.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The maximum number of active render targets a device can have active at any given time is set by a #define in D3D11.h called
		/// <c>D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT</c>. It is invalid to try to set the same subresource to multiple render target slots.
		/// Any render targets not defined by this call are set to <c>NULL</c>.
		/// </para>
		/// <para>
		/// If any subresources are also currently bound for reading in a different stage or writing (perhaps in a different part of the
		/// pipeline), those bind points will be set to <c>NULL</c>, in order to prevent the same subresource from being read and written
		/// simultaneously in a single rendering operation.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// If the render-target views were created from an array resource type, all of the render-target views must have the same array
		/// size. This restriction also applies to the depth-stencil view, its array size must match that of the render-target views being bound.
		/// </para>
		/// <para>
		/// The pixel shader must be able to simultaneously render to at least eight separate render targets. All of these render targets
		/// must access the same type of resource: Buffer, Texture1D, Texture1DArray, Texture2D, Texture2DArray, Texture3D, or TextureCube.
		/// All render targets must have the same size in all dimensions (width and height, and depth for 3D or array size for *Array
		/// types). If render targets use multisample anti-aliasing, all bound render targets and depth buffer must be the same form of
		/// multisample resource (that is, the sample counts must be the same). Each render target can have a different data format. These
		/// render target formats are not required to have identical bit-per-element counts.
		/// </para>
		/// <para>Any combination of the eight slots for render targets can have a render target set or not set.</para>
		/// <para>
		/// The same resource view cannot be bound to multiple render target slots simultaneously. However, you can set multiple
		/// non-overlapping resource views of a single resource as simultaneous multiple render targets.
		/// </para>
		/// <para>
		/// Note that unlike some other resource methods in Direct3D, all currently bound render targets will be unbound by calling .
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omsetrendertargets void
		// OMSetRenderTargets( [in] uint NumViews, [in, optional] ID3D11RenderTargetView * const *ppRenderTargetViews, [in, optional]
		// ID3D11DepthStencilView *pDepthStencilView );
		[PreserveSig]
		new void OMSetRenderTargets(int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11RenderTargetView[]? ppRenderTargetViews,
			[In, Optional] ID3D11DepthStencilView? pDepthStencilView);

		/// <summary>Binds resources to the output-merger stage.</summary>
		/// <param name="NumRTVs">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of render targets to bind (ranges between 0 and <c>D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT</c>). If this parameter is
		/// nonzero, the number of entries in the array to which <c>ppRenderTargetViews</c> points must equal the number in this parameter.
		/// If you set <c>NumRTVs</c> to D3D11_KEEP_RENDER_TARGETS_AND_DEPTH_STENCIL (0xffffffff), this method does not modify the currently
		/// bound render-target views (RTVs) and also does not modify depth-stencil view (DSV).
		/// </para>
		/// </param>
		/// <param name="ppRenderTargetViews">
		/// <para>Type: <c>ID3D11RenderTargetView*</c></para>
		/// <para>
		/// Pointer to an array of ID3D11RenderTargetViews that represent the render targets to bind to the device. If this parameter is
		/// <c>NULL</c> and <c>NumRTVs</c> is 0, no render targets are bound.
		/// </para>
		/// </param>
		/// <param name="pDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView*</c></para>
		/// <para>
		/// Pointer to a ID3D11DepthStencilView that represents the depth-stencil view to bind to the device. If this parameter is
		/// <c>NULL</c>, the depth-stencil view is not bound.
		/// </para>
		/// </param>
		/// <param name="UAVStartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into a zero-based array to begin setting unordered-access views (ranges from 0 to D3D11_PS_CS_UAV_REGISTER_COUNT - 1).
		/// </para>
		/// <para>
		/// For the Direct3D 11.1 runtime, which is available starting with Windows 8, this value can range from 0 to D3D11_1_UAV_SLOT_COUNT
		/// - 1. D3D11_1_UAV_SLOT_COUNT is defined as 64.
		/// </para>
		/// <para>For pixel shaders, <c>UAVStartSlot</c> should be equal to the number of render-target views being bound.</para>
		/// </param>
		/// <param name="NumUAVs">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of unordered-access views (UAVs) in <c>ppUnorderedAccessViews</c>. If you set <c>NumUAVs</c> to
		/// D3D11_KEEP_UNORDERED_ACCESS_VIEWS (0xffffffff), this method does not modify the currently bound unordered-access views.
		/// </para>
		/// <para>
		/// For the Direct3D 11.1 runtime, which is available starting with Windows 8, this value can range from 0 to D3D11_1_UAV_SLOT_COUNT
		/// - <c>UAVStartSlot</c>.
		/// </para>
		/// </param>
		/// <param name="ppUnorderedAccessViews">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>
		/// Pointer to an array of ID3D11UnorderedAccessViews that represent the unordered-access views to bind to the device. If this
		/// parameter is <c>NULL</c> and <c>NumUAVs</c> is 0, no unordered-access views are bound.
		/// </para>
		/// </param>
		/// <param name="pUAVInitialCounts">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>
		/// An array of append and consume buffer offsets. A value of -1 indicates to keep the current offset. Any other values set the
		/// hidden counter for that appendable and consumable UAV. <c>pUAVInitialCounts</c> is relevant only for UAVs that were created with
		/// either D3D11_BUFFER_UAV_FLAG_APPEND or <c>D3D11_BUFFER_UAV_FLAG_COUNTER</c> specified when the UAV was created; otherwise, the
		/// argument is ignored.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// For pixel shaders, the render targets and unordered-access views share the same resource slots when being written out. This
		/// means that UAVs must be given an offset so that they are placed in the slots after the render target views that are being bound.
		/// </para>
		/// <para><c>Note</c>  RTVs, DSV, and UAVs cannot be set independently; they all need to be set at the same time.</para>
		/// <para></para>
		/// <para>Two RTVs conflict if they share a subresource (and therefore share the same resource).</para>
		/// <para>Two UAVs conflict if they share a subresource (and therefore share the same resource).</para>
		/// <para>An RTV conflicts with a UAV if they share a subresource or share a bind point.</para>
		/// <para><c>OMSetRenderTargetsAndUnorderedAccessViews</c> operates properly in the following situations:</para>
		/// <list type="number">
		/// <item>
		/// <description><c>NumRTVs</c> != D3D11_KEEP_RENDER_TARGETS_AND_DEPTH_STENCIL and <c>NumUAVs</c> != D3D11_KEEP_UNORDERED_ACCESS_VIEWS
		/// <para>
		/// The following conditions must be true for <c>OMSetRenderTargetsAndUnorderedAccessViews</c> to succeed and for the runtime to
		/// pass the bind information to the driver:
		/// </para>
		/// <c>OMSetRenderTargetsAndUnorderedAccessViews</c> performs the following tasks:
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>NumRTVs</c> == D3D11_KEEP_RENDER_TARGETS_AND_DEPTH_STENCIL
		/// <para>In this situation, <c>OMSetRenderTargetsAndUnorderedAccessViews</c> binds only UAVs.</para>
		/// <para>
		/// The following conditions must be true for <c>OMSetRenderTargetsAndUnorderedAccessViews</c> to succeed and for the runtime to
		/// pass the bind information to the driver:
		/// </para>
		/// <c>OMSetRenderTargetsAndUnorderedAccessViews</c> unbinds the following items: <c>OMSetRenderTargetsAndUnorderedAccessViews</c>
		/// binds <c>ppUnorderedAccessViews</c>.
		/// <para>
		/// <c>OMSetRenderTargetsAndUnorderedAccessViews</c> ignores <c>ppDepthStencilView</c>, and the current depth-stencil view remains bound.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>NumUAVs</c> == D3D11_KEEP_UNORDERED_ACCESS_VIEWS
		/// <para>In this situation, <c>OMSetRenderTargetsAndUnorderedAccessViews</c> binds only RTVs and DSV.</para>
		/// <para>
		/// The following conditions must be true for <c>OMSetRenderTargetsAndUnorderedAccessViews</c> to succeed and for the runtime to
		/// pass the bind information to the driver:
		/// </para>
		/// <c>OMSetRenderTargetsAndUnorderedAccessViews</c> unbinds the following items: <c>OMSetRenderTargetsAndUnorderedAccessViews</c>
		/// binds <c>ppRenderTargetViews</c> and <c>ppDepthStencilView</c>.
		/// <para><c>OMSetRenderTargetsAndUnorderedAccessViews</c> ignores <c>UAVStartSlot</c>.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omsetrendertargetsandunorderedaccessviews
		// void OMSetRenderTargetsAndUnorderedAccessViews( [in] uint NumRTVs, [in, optional] ID3D11RenderTargetView * const
		// *ppRenderTargetViews, [in, optional] ID3D11DepthStencilView *pDepthStencilView, [in] uint UAVStartSlot, [in] uint NumUAVs, [in,
		// optional] ID3D11UnorderedAccessView * const *ppUnorderedAccessViews, [in, optional] const uint *pUAVInitialCounts );
		[PreserveSig]
		new void OMSetRenderTargetsAndUnorderedAccessViews(int NumRTVs, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11RenderTargetView[]? ppRenderTargetViews,
			[In, Optional] ID3D11DepthStencilView? pDepthStencilView, uint UAVStartSlot, int NumUAVs, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ID3D11UnorderedAccessView[]? ppUnorderedAccessViews,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[]? pUAVInitialCounts);

		/// <summary>Set the blend state of the output-merger stage.</summary>
		/// <param name="pBlendState">
		/// <para>Type: <c>ID3D11BlendState*</c></para>
		/// <para>
		/// Pointer to a blend-state interface (see ID3D11BlendState). Pass <c>NULL</c> for a default blend state. For more info about
		/// default blend state, see Remarks.
		/// </para>
		/// </param>
		/// <param name="BlendFactor">
		/// <para>Type: <c>const FLOAT[4]</c></para>
		/// <para>
		/// Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or
		/// both. If you created the blend-state object with D3D11_BLEND_BLEND_FACTOR or D3D11_BLEND_INV_BLEND_FACTOR, the blending stage
		/// uses the non-NULL array of blend factors. If you didn't create the blend-state object with <c>D3D11_BLEND_BLEND_FACTOR</c> or
		/// <c>D3D11_BLEND_INV_BLEND_FACTOR</c>, the blending stage does not use the non-NULL array of blend factors; the runtime stores the
		/// blend factors, and you can later call ID3D11DeviceContext::OMGetBlendState to retrieve the blend factors. If you pass
		/// <c>NULL</c>, the runtime uses or stores a blend factor equal to { 1, 1, 1, 1 }.
		/// </para>
		/// </param>
		/// <param name="SampleMask">
		/// <para>Type: <c>uint</c></para>
		/// <para>32-bit sample coverage. The default value is 0xffffffff. See remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Blend state is used by the output-merger stage to determine how to blend together two RGB pixel values and two alpha values. The
		/// two RGB pixel values and two alpha values are the RGB pixel value and alpha value that the pixel shader outputs and the RGB
		/// pixel value and alpha value already in the output render target. The blend option controls the data source that the blending
		/// stage uses to modulate values for the pixel shader, render target, or both. The blend operation controls how the blending stage
		/// mathematically combines these modulated values.
		/// </para>
		/// <para>To create a blend-state interface, call ID3D11Device::CreateBlendState.</para>
		/// <para>
		/// Passing in <c>NULL</c> for the blend-state interface indicates to the runtime to set a default blending state. The following
		/// table indicates the default blending parameters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>State</description>
		/// <description>Default Value</description>
		/// </listheader>
		/// <item>
		/// <description>AlphaToCoverageEnable</description>
		/// <description><c>FALSE</c></description>
		/// </item>
		/// <item>
		/// <description>IndependentBlendEnable</description>
		/// <description><c>FALSE</c></description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].BlendEnable</description>
		/// <description><c>FALSE</c></description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].SrcBlend</description>
		/// <description>D3D11_BLEND_ONE</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].DestBlend</description>
		/// <description>D3D11_BLEND_ZERO</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].BlendOp</description>
		/// <description>D3D11_BLEND_OP_ADD</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].SrcBlendAlpha</description>
		/// <description>D3D11_BLEND_ONE</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].DestBlendAlpha</description>
		/// <description>D3D11_BLEND_ZERO</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].BlendOpAlpha</description>
		/// <description>D3D11_BLEND_OP_ADD</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].RenderTargetWriteMask</description>
		/// <description>D3D11_COLOR_WRITE_ENABLE_ALL</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// A sample mask determines which samples get updated in all the active render targets. The mapping of bits in a sample mask to
		/// samples in a multisample render target is the responsibility of an individual application. A sample mask is always applied; it
		/// is independent of whether multisampling is enabled, and does not depend on whether an application uses multisample render targets.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omsetblendstate void OMSetBlendState( [in,
		// optional] ID3D11BlendState *pBlendState, [in, optional] const FLOAT [4] BlendFactor, [in] uint SampleMask );
		[PreserveSig]
		new void OMSetBlendState([In, Optional] ID3D11BlendState? pBlendState, [In, Optional, MarshalAs(UnmanagedType.LPArray)] float[]? BlendFactor, uint SampleMask = uint.MaxValue);

		/// <summary>Sets the depth-stencil state of the output-merger stage.</summary>
		/// <param name="pDepthStencilState">
		/// <para>Type: <c>ID3D11DepthStencilState*</c></para>
		/// <para>
		/// Pointer to a depth-stencil state interface (see ID3D11DepthStencilState) to bind to the device. Set this to <c>NULL</c> to use
		/// the default state listed in D3D11_DEPTH_STENCIL_DESC.
		/// </para>
		/// </param>
		/// <param name="StencilRef">
		/// <para>Type: <c>uint</c></para>
		/// <para>Reference value to perform against when doing a depth-stencil test. See remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>To create a depth-stencil state interface, call ID3D11Device::CreateDepthStencilState.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omsetdepthstencilstate void
		// OMSetDepthStencilState( [in, optional] ID3D11DepthStencilState *pDepthStencilState, [in] uint StencilRef );
		[PreserveSig]
		new void OMSetDepthStencilState([In, Optional] ID3D11DepthStencilState? pDepthStencilState, uint StencilRef);

		/// <summary>Set the target output buffers for the stream-output stage of the pipeline.</summary>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of buffer to bind to the device. A maximum of four output buffers can be set. If less than four are defined by the
		/// call, the remaining buffer slots are set to <c>NULL</c>. See Remarks.
		/// </para>
		/// </param>
		/// <param name="ppSOTargets">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>
		/// The array of output buffers (see ID3D11Buffer) to bind to the device. The buffers must have been created with the
		/// D3D11_BIND_STREAM_OUTPUT flag.
		/// </para>
		/// </param>
		/// <param name="pOffsets">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>
		/// Array of offsets to the output buffers from <c>ppSOTargets</c>, one offset for each buffer. The offset values must be in bytes.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// An offset of -1 will cause the stream output buffer to be appended, continuing after the last location written to the buffer in
		/// a previous stream output pass.
		/// </para>
		/// <para>
		/// Calling this method using a buffer that is currently bound for writing will effectively bind <c>NULL</c> instead because a
		/// buffer cannot be bound as both an input and an output at the same time.
		/// </para>
		/// <para>
		/// The debug layer will generate a warning whenever a resource is prevented from being bound simultaneously as an input and an
		/// output, but this will not prevent invalid data from being used by the runtime.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>Note that unlike some other resource methods in Direct3D, all currently bound targets will be unbound by calling .</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-sosettargets void SOSetTargets( [in] uint
		// NumBuffers, [in, optional] ID3D11Buffer * const *ppSOTargets, [in, optional] const uint *pOffsets );
		[PreserveSig]
		new void SOSetTargets([Optional] int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11Buffer[]? ppSOTargets,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[]? pOffsets);

		/// <summary>Draw geometry of an unknown size.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// A draw API submits work to the rendering pipeline. This API submits work of an unknown size that was processed by the input
		/// assembler, vertex shader, and stream-output stages; the work may or may not have gone through the geometry-shader stage.
		/// </para>
		/// <para>
		/// After data has been streamed out to stream-output stage buffers, those buffers can be again bound to the Input Assembler stage
		/// at input slot 0 and DrawAuto will draw them without the application needing to know the amount of data that was written to the
		/// buffers. A measurement of the amount of data written to the SO stage buffers is maintained internally when the data is streamed
		/// out. This means that the CPU does not need to fetch the measurement before re-binding the data that was streamed as input data.
		/// Although this amount is tracked internally, it is still the responsibility of applications to use input layouts to describe the
		/// format of the data in the SO stage buffers so that the layouts are available when the buffers are again bound to the input assembler.
		/// </para>
		/// <para>The following diagram shows the DrawAuto process.</para>
		/// <para>Calling DrawAuto does not change the state of the streaming-output buffers that were bound again as inputs.</para>
		/// <para>
		/// DrawAuto only works when drawing with one input buffer bound as an input to the IA stage at slot 0. Applications must create the
		/// SO buffer resource with both binding flags, D3D11_BIND_VERTEX_BUFFER and <c>D3D11_BIND_STREAM_OUTPUT</c>.
		/// </para>
		/// <para>This API does not support indexing or instancing.</para>
		/// <para>
		/// If an application needs to retrieve the size of the streaming-output buffer, it can query for statistics on streaming output by
		/// using D3D11_QUERY_SO_STATISTICS.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawauto void DrawAuto();
		[PreserveSig]
		new void DrawAuto();

		/// <summary>Draw indexed, instanced, GPU-generated primitives.</summary>
		/// <param name="pBufferForArgs">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>A pointer to an ID3D11Buffer, which is a buffer containing the GPU-generated primitives.</para>
		/// </param>
		/// <param name="AlignedByteOffsetForArgs">
		/// <para>Type: <c>uint</c></para>
		/// <para>A DWORD-aligned byte offset in <c>pBufferForArgs</c> to the start of the GPU generated primitives.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// When an application creates a buffer that is associated with the ID3D11Buffer interface that pBufferForArgs points to, your
		/// application must set the D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS flag in the MiscFlags member of the D3D11_BUFFER_DESC structure
		/// that describes the buffer. To create the buffer, your application should call the ID3D11Device::CreateBuffer method, and pass a
		/// pointer to a <c>D3D11_BUFFER_DESC</c> in the pDesc parameter.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawindexedinstancedindirect void
		// DrawIndexedInstancedIndirect( [in] ID3D11Buffer *pBufferForArgs, [in] uint AlignedByteOffsetForArgs );
		[PreserveSig]
		new void DrawIndexedInstancedIndirect([In] ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		/// <summary>Draw instanced, GPU-generated primitives.</summary>
		/// <param name="pBufferForArgs">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>A pointer to an ID3D11Buffer, which is a buffer containing the GPU generated primitives.</para>
		/// </param>
		/// <param name="AlignedByteOffsetForArgs">
		/// <para>Type: <c>uint</c></para>
		/// <para>Offset in <c>pBufferForArgs</c> to the start of the GPU generated primitives.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When an application creates a buffer that is associated with the ID3D11Buffer interface that <c>pBufferForArgs</c> points to,
		/// the application must set the D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS flag in the <c>MiscFlags</c> member of the D3D11_BUFFER_DESC
		/// structure that describes the buffer. To create the buffer, the application calls the ID3D11Device::CreateBuffer method and in
		/// this call passes a pointer to <c>D3D11_BUFFER_DESC</c> in the <c>pDesc</c> parameter.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawinstancedindirect void
		// DrawInstancedIndirect( [in] ID3D11Buffer *pBufferForArgs, [in] uint AlignedByteOffsetForArgs );
		[PreserveSig]
		new void DrawInstancedIndirect([In] ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		/// <summary>Execute a command list from a thread group.</summary>
		/// <param name="ThreadGroupCountX">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of groups dispatched in the x direction. <c>ThreadGroupCountX</c> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535).
		/// </para>
		/// </param>
		/// <param name="ThreadGroupCountY">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of groups dispatched in the y direction. <c>ThreadGroupCountY</c> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535).
		/// </para>
		/// </param>
		/// <param name="ThreadGroupCountZ">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of groups dispatched in the z direction. <c>ThreadGroupCountZ</c> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535). In feature level 10 the value for <c>ThreadGroupCountZ</c> must be 1.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// You call the <c>Dispatch</c> method to execute commands in a compute shader. A compute shader can be run on many threads in
		/// parallel, within a thread group. Index a particular thread, within a thread group using a 3D vector given by (x,y,z).
		/// </para>
		/// <para>
		/// In the following illustration, assume a thread group with 50 threads where the size of the group is given by (5,5,2). A single
		/// thread is identified from a thread group with 50 threads in it, using the vector (4,1,1).
		/// </para>
		/// <para>
		/// The following illustration shows the relationship between the parameters passed to <c>ID3D11DeviceContext::Dispatch</c>,
		/// Dispatch(5,3,2), the values specified in the numthreads attribute, numthreads(10,8,3), and values that will passed to the
		/// compute shader for the thread-related system values (SV_GroupIndex,SV_DispatchThreadID,SV_GroupThreadID,SV_GroupID).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dispatch void Dispatch( [in] uint
		// ThreadGroupCountX, [in] uint ThreadGroupCountY, [in] uint ThreadGroupCountZ );
		[PreserveSig]
		new void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);

		/// <summary>Execute a command list over one or more thread groups.</summary>
		/// <param name="pBufferForArgs">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>A pointer to an ID3D11Buffer, which must be loaded with data that matches the argument list for ID3D11DeviceContext::Dispatch.</para>
		/// </param>
		/// <param name="AlignedByteOffsetForArgs">
		/// <para>Type: <c>uint</c></para>
		/// <para>A byte-aligned offset between the start of the buffer and the arguments.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>You call the <c>DispatchIndirect</c> method to execute commands in a compute shader.</para>
		/// <para>
		/// When an application creates a buffer that is associated with the ID3D11Buffer interface that <c>pBufferForArgs</c> points to,
		/// the application must set the D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS flag in the <c>MiscFlags</c> member of the D3D11_BUFFER_DESC
		/// structure that describes the buffer. To create the buffer, the application calls the ID3D11Device::CreateBuffer method and in
		/// this call passes a pointer to <c>D3D11_BUFFER_DESC</c> in the <c>pDesc</c> parameter.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dispatchindirect void DispatchIndirect(
		// [in] ID3D11Buffer *pBufferForArgs, [in] uint AlignedByteOffsetForArgs );
		[PreserveSig]
		new void DispatchIndirect([In] ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		/// <summary>Set the rasterizer state for the rasterizer stage of the pipeline.</summary>
		/// <param name="pRasterizerState">
		/// <para>Type: <c>ID3D11RasterizerState*</c></para>
		/// <para>Pointer to a rasterizer-state interface (see ID3D11RasterizerState) to bind to the pipeline.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>To create a rasterizer state interface, call ID3D11Device::CreateRasterizerState.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rssetstate void RSSetState( [in, optional]
		// ID3D11RasterizerState *pRasterizerState );
		[PreserveSig]
		new void RSSetState([In, Optional] ID3D11RasterizerState? pRasterizerState);

		/// <summary>Bind an array of viewports to the rasterizer stage of the pipeline.</summary>
		/// <param name="NumViewports">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of viewports to bind.</para>
		/// </param>
		/// <param name="pViewports">
		/// <para>Type: <c>const D3D11_VIEWPORT*</c></para>
		/// <para>
		/// An array of D3D11_VIEWPORT structures to bind to the device. See the structure page for details about how the viewport size is
		/// dependent on the device feature level which has changed between Direct3D 11 and Direct3D 10.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>All viewports must be set atomically as one operation. Any viewports not defined by the call are disabled.</para>
		/// <para>
		/// Which viewport to use is determined by the SV_ViewportArrayIndex semantic output by a geometry shader; if a geometry shader does
		/// not specify the semantic, Direct3D will use the first viewport in the array.
		/// </para>
		/// <para>
		/// <c>Note</c>  Even though you specify float values to the members of the D3D11_VIEWPORT structure for the <c>pViewports</c> array
		/// in a call to <c>ID3D11DeviceContext::RSSetViewports</c> for feature levels 9_x, <c>RSSetViewports</c> uses DWORDs internally.
		/// Because of this behavior, when you use a negative top left corner for the viewport, the call to <c>RSSetViewports</c> for
		/// feature levels 9_x fails. This failure occurs because <c>RSSetViewports</c> for 9_x casts the floating point values into
		/// unsigned integers without validation, which results in integer overflow.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rssetviewports void RSSetViewports( [in]
		// uint NumViewports, [in, optional] const D3D11_VIEWPORT *pViewports );
		[PreserveSig]
		new void RSSetViewports([Optional] int NumViewports, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D11_VIEWPORT[]? pViewports);

		/// <summary>Bind an array of scissor rectangles to the rasterizer stage.</summary>
		/// <param name="NumRects">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of scissor rectangles to bind.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <c>const D3D11_RECT*</c></para>
		/// <para>An array of scissor rectangles (see D3D11_RECT).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>All scissor rects must be set atomically as one operation. Any scissor rects not defined by the call are disabled.</para>
		/// <para>The scissor rectangles will only be used if ScissorEnable is set to true in the rasterizer state (see D3D11_RASTERIZER_DESC).</para>
		/// <para>
		/// Which scissor rectangle to use is determined by the SV_ViewportArrayIndex semantic output by a geometry shader (see shader
		/// semantic syntax). If a geometry shader does not make use of the SV_ViewportArrayIndex semantic then Direct3D will use the first
		/// scissor rectangle in the array.
		/// </para>
		/// <para>Each scissor rectangle in the array corresponds to a viewport in an array of viewports (see ID3D11DeviceContext::RSSetViewports).</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rssetscissorrects void RSSetScissorRects(
		// [in] uint NumRects, [in, optional] const D3D11_RECT *pRects );
		[PreserveSig]
		new void RSSetScissorRects([Optional] int NumRects, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[]? pRects);

		/// <summary>Copy a region from a source resource to a destination resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the destination resource (see ID3D11Resource).</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>Destination subresource index.</para>
		/// </param>
		/// <param name="DstX">
		/// <para>Type: <c>uint</c></para>
		/// <para>The x-coordinate of the upper left corner of the destination region.</para>
		/// </param>
		/// <param name="DstY">
		/// <para>Type: <c>uint</c></para>
		/// <para>The y-coordinate of the upper left corner of the destination region. For a 1D subresource, this must be zero.</para>
		/// </param>
		/// <param name="DstZ">
		/// <para>Type: <c>uint</c></para>
		/// <para>The z-coordinate of the upper left corner of the destination region. For a 1D or 2D subresource, this must be zero.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the source resource (see ID3D11Resource).</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>Source subresource index.</para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <c>const D3D11_BOX*</c></para>
		/// <para>
		/// A pointer to a 3D box (see D3D11_BOX) that defines the source subresource that can be copied. If <c>NULL</c>, the entire source
		/// subresource is copied. The box must fit within the source resource.
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, <c>CopySubresourceRegion</c> doesn't perform a copy operation.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The source box must be within the size of the source resource. The destination offsets, (x, y, and z), allow the source box to
		/// be offset when writing into the destination resource; however, the dimensions of the source box and the offsets must be within
		/// the size of the resource. If you try and copy outside the destination resource or specify a source box that is larger than the
		/// source resource, the behavior of <c>CopySubresourceRegion</c> is undefined. If you created a device that supports the debug
		/// layer, the debug output reports an error on this invalid <c>CopySubresourceRegion</c> call. Invalid parameters to
		/// <c>CopySubresourceRegion</c> cause undefined behavior and might result in incorrect rendering, clipping, no copy, or even the
		/// removal of the rendering device.
		/// </para>
		/// <para>
		/// If the resources are buffers, all coordinates are in bytes; if the resources are textures, all coordinates are in texels.
		/// D3D11CalcSubresource is a helper function for calculating subresource indexes.
		/// </para>
		/// <para>
		/// <c>CopySubresourceRegion</c> performs the copy on the GPU (similar to a memcpy by the CPU). As a consequence, the source and
		/// destination resources:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Must be different subresources (although they can be from the same resource).</description>
		/// </item>
		/// <item>
		/// <description>Must be the same type.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Must have compatible DXGI formats (identical or from the same type group). For example, a DXGI_FORMAT_R32G32B32_FLOAT texture
		/// can be copied to a DXGI_FORMAT_R32G32B32_UINT texture since both of these formats are in the DXGI_FORMAT_R32G32B32_TYPELESS
		/// group. <c>CopySubresourceRegion</c> can copy between a few format types. For more info, see Format Conversion using Direct3D 10.1.
		/// </description>
		/// </item>
		/// <item>
		/// <description>May not be currently mapped.</description>
		/// </item>
		/// </list>
		/// <para>
		/// **CopySubresourceRegion** only supports copy; it doesn't support any stretch, color key, or blend. **CopySubresourceRegion** can
		/// reinterpret the resource data between a few format types. For more info, see [Format conversion using Direct3D 10.1](/windows/win32/direct3d10/d3d10-graphics-programming-guide-resources-block-compression#format-conversion-using-direct3d-101).
		/// </para>
		/// <para>If your app needs to copy an entire resource, we recommend to use ID3D11DeviceContext::CopyResource instead.</para>
		/// <para>
		/// <c>CopySubresourceRegion</c> is an asynchronous call, which may be added to the command-buffer queue, this attempts to remove
		/// pipeline stalls that may occur when copying data. For more information about pipeline stalls, see performance considerations.
		/// </para>
		/// <para>
		/// <c>Note</c>   <c>Applies only to feature level 9_x hardware</c> If you use ID3D11DeviceContext::UpdateSubresource or
		/// <c>CopySubresourceRegion</c> to copy from a staging resource to a default resource, you can corrupt the destination contents.
		/// This occurs if you pass a <c>NULL</c> source box and if the source resource has different dimensions from those of the
		/// destination resource or if you use destination offsets, (x, y, and z). In this situation, always pass a source box that is the
		/// full size of the source resource.
		/// </para>
		/// <para></para>
		/// <para>
		/// <c>Note</c>   <c>Applies only to feature level 9_x hardware</c> You can't use <c>CopySubresourceRegion</c> to copy mipmapped
		/// volume textures.
		/// </para>
		/// <para></para>
		/// <para>
		/// <c>Note</c>   <c>Applies only to feature levels 9_x</c> Subresources created with the D3D11_BIND_DEPTH_STENCIL flag can only be
		/// used as a source for <c>CopySubresourceRegion</c>.
		/// </para>
		/// <para></para>
		/// <para>
		/// <c>Note</c>  If you use <c>CopySubresourceRegion</c> with a depth-stencil buffer or a multisampled resource, you must copy the
		/// whole subresource. In this situation, you must pass 0 to the <c>DstX</c>, <c>DstY</c>, and <c>DstZ</c> parameters and
		/// <c>NULL</c> to the <c>pSrcBox</c> parameter. In addition, source and destination resources, which are represented by the
		/// <c>pSrcResource</c> and <c>pDstResource</c> parameters, should have identical sample count values.
		/// </para>
		/// <para></para>
		/// <para>Example</para>
		/// <para>
		/// The following code snippet copies a box (located at (120,100),(200,220)) from a source texture into a region (10,20),(90,140) in
		/// a destination texture.
		/// </para>
		/// <para>Notice, that for a 2D texture, front and back are set to 0 and 1 respectively.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-copysubresourceregion void
		// CopySubresourceRegion( [in] ID3D11Resource *pDstResource, [in] uint DstSubresource, [in] uint DstX, [in] uint DstY, [in] uint
		// DstZ, [in] ID3D11Resource *pSrcResource, [in] uint SrcSubresource, [in, optional] const D3D11_BOX *pSrcBox );
		[PreserveSig]
		new void CopySubresourceRegion([In] ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ,
			[In] ID3D11Resource pSrcResource, uint SrcSubresource, [In, Optional] StructPointer<D3D11_BOX> pSrcBox);

		/// <summary>Copy the entire contents of the source resource to the destination resource using the GPU.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the ID3D11Resource interface that represents the destination resource.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the ID3D11Resource interface that represents the source resource.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method is unusual in that it causes the GPU to perform the copy operation (similar to a memcpy by the CPU). As a result, it
		/// has a few restrictions designed for improving performance. For instance, the source and destination resources:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Must be different resources.</description>
		/// </item>
		/// <item>
		/// <description>Must be the same type.</description>
		/// </item>
		/// <item>
		/// <description>Must have identical dimensions (including width, height, depth, and size as appropriate).</description>
		/// </item>
		/// <item>
		/// <description>
		/// Must have compatible DXGI formats, which means the formats must be identical or at least from the same type group. For example,
		/// a DXGI_FORMAT_R32G32B32_FLOAT texture can be copied to a DXGI_FORMAT_R32G32B32_UINT texture since both of these formats are in
		/// the DXGI_FORMAT_R32G32B32_TYPELESS group. CopyResource can copy between a few format types. For more info, see Format Conversion
		/// using Direct3D 10.1.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Can't be currently mapped.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>CopyResource</c> only supports copy; it doesn't support any stretch, color key, or blend. CopyResource can reinterpret the
		/// resource data between a few format types. For more info, see Format Conversion using Direct3D 10.1.
		/// </para>
		/// <para>
		/// You can't use an Immutable resource as a destination. You can use a depth-stencil resource as either a source or a destination
		/// provided that the feature level is D3D_FEATURE_LEVEL_10_1 or greater. For feature levels 9_x, resources created with the
		/// D3D11_BIND_DEPTH_STENCIL flag can only be used as a source for CopyResource. Resources created with multisampling capability
		/// (see DXGI_SAMPLE_DESC) can be used as source and destination only if both source and destination have identical multisampled
		/// count and quality. If source and destination differ in multisampled count and quality or if one is multisampled and the other is
		/// not multisampled, the call to <c>ID3D11DeviceContext::CopyResource</c> fails. Use ID3D11DeviceContext::ResolveSubresource to
		/// resolve a multisampled resource to a resource that is not multisampled.
		/// </para>
		/// <para>
		/// The method is an asynchronous call, which may be added to the command-buffer queue. This attempts to remove pipeline stalls that
		/// may occur when copying data. For more info, see performance considerations.
		/// </para>
		/// <para>
		/// We recommend to use ID3D11DeviceContext::CopySubresourceRegion instead if you only need to copy a portion of the data in a resource.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-copyresource void CopyResource( [in]
		// ID3D11Resource *pDstResource, [in] ID3D11Resource *pSrcResource );
		[PreserveSig]
		new void CopyResource([In] ID3D11Resource pDstResource, [In] ID3D11Resource pSrcResource);

		/// <summary>
		/// <para>See the Basic hologram sample.</para>
		/// <para>The CPU copies data from memory to a subresource created in non-mappable memory.</para>
		/// </summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the destination resource (see ID3D11Resource).</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>A zero-based index, that identifies the destination subresource. See D3D11CalcSubresource for more details.</para>
		/// </param>
		/// <param name="pDstBox">
		/// <para>Type: <c>const D3D11_BOX*</c></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data into. Coordinates are in
		/// bytes for buffers and in texels for textures. If <c>NULL</c>, the data is written to the destination subresource with no offset.
		/// The dimensions of the source must fit the destination (see D3D11_BOX).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, <c>UpdateSubresource</c> doesn't perform an update operation.
		/// </para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the source data in memory.</para>
		/// </param>
		/// <param name="SrcRowPitch">
		/// <para>Type: <c>uint</c></para>
		/// <para>The size of one row of the source data.</para>
		/// </param>
		/// <param name="SrcDepthPitch">
		/// <para>Type: <c>uint</c></para>
		/// <para>The size of one depth slice of source data.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// For a shader-constant buffer; set <c>pDstBox</c> to <c>NULL</c>. It is not possible to use this method to partially update a
		/// shader-constant buffer.
		/// </para>
		/// <para>A resource cannot be used as a destination if:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>the resource is created with immutable or dynamic usage.</description>
		/// </item>
		/// <item>
		/// <description>the resource is created as a depth-stencil resource.</description>
		/// </item>
		/// <item>
		/// <description>the resource is created with multisampling capability (see DXGI_SAMPLE_DESC).</description>
		/// </item>
		/// </list>
		/// <para>
		/// When <c>UpdateSubresource</c> returns, the application is free to change or even free the data pointed to by <c>pSrcData</c>
		/// because the method has already copied/snapped away the original contents.
		/// </para>
		/// <para>
		/// The performance of <c>UpdateSubresource</c> depends on whether or not there is contention for the destination resource. For
		/// example, contention for a vertex buffer resource occurs when the application executes a <c>Draw</c> call and later calls
		/// <c>UpdateSubresource</c> on the same vertex buffer before the <c>Draw</c> call is actually executed by the GPU.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// When there is contention for the resource, <c>UpdateSubresource</c> will perform 2 copies of the source data. First, the data is
		/// copied by the CPU to a temporary storage space accessible by the command buffer. This copy happens before the method returns. A
		/// second copy is then performed by the GPU to copy the source data into non-mappable memory. This second copy happens
		/// asynchronously because it is executed by GPU when the command buffer is flushed.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// When there is no resource contention, the behavior of <c>UpdateSubresource</c> is dependent on which is faster (from the CPU's
		/// perspective): copying the data to the command buffer and then having a second copy execute when the command buffer is flushed,
		/// or having the CPU copy the data to the final resource location. This is dependent on the architecture of the underlying system.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c>   <c>Applies only to feature level 9_x hardware</c> If you use <c>UpdateSubresource</c> or
		/// ID3D11DeviceContext::CopySubresourceRegion to copy from a staging resource to a default resource, you can corrupt the
		/// destination contents. This occurs if you pass a <c>NULL</c> source box and if the source resource has different dimensions from
		/// those of the destination resource or if you use destination offsets, (x, y, and z). In this situation, always pass a source box
		/// that is the full size of the source resource.
		/// </para>
		/// <para></para>
		/// <para>
		/// To better understand the source row pitch and source depth pitch parameters, the following illustration shows a 3D volume texture.
		/// </para>
		/// <para>
		/// Each block in this visual represents an element of data, and the size of each element is dependent on the resource's format. For
		/// example, if the resource format is DXGI_FORMAT_R32G32B32A32_FLOAT, the size of each element would be 128 bits, or 16 bytes. This
		/// 3D volume texture has a width of two, a height of three, and a depth of four.
		/// </para>
		/// <para>To calculate the source row pitch and source depth pitch for a given resource, use the following formulas:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Source Row Pitch = [size of one element in bytes] * [number of elements in one row]</description>
		/// </item>
		/// <item>
		/// <description>Source Depth Pitch = [Source Row Pitch] * [number of rows (height)]</description>
		/// </item>
		/// </list>
		/// <para>In the case of this example 3D volume texture where the size of each element is 16 bytes, the formulas are as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Source Row Pitch = 16 * 2 = 32</description>
		/// </item>
		/// <item>
		/// <description>Source Depth Pitch = 16 * 2 * 3 = 96</description>
		/// </item>
		/// </list>
		/// <para>The following illustration shows the resource as it is laid out in memory.</para>
		/// <para>
		/// For example, the following code snippet shows how to specify a destination region in a 2D texture. Assume the destination
		/// texture is 512x512 and the operation will copy the data pointed to by <c>pData</c> to [(120,100)..(200,220)] in the destination
		/// texture. Also assume that <c>rowPitch</c> has been initialized with the proper value (as explained above). <c>front</c> and
		/// <c>back</c> are set to 0 and 1 respectively, because by having <c>front</c> equal to <c>back</c>, the box is technically empty.
		/// </para>
		/// <para>
		/// The 1D case is similar. The following snippet shows how to specify a destination region in a 1D texture. Use the same
		/// assumptions as above, except that the texture is 512 in length.
		/// </para>
		/// <para>
		/// For info about various resource types and how <c>UpdateSubresource</c> might work with each resource type, see Introduction to a
		/// Resource in Direct3D 11.
		/// </para>
		/// <para>Calling UpdateSubresource on a Deferred Context</para>
		/// <para>
		/// If your application calls <c>UpdateSubresource</c> on a deferred context with a destination box—to which <c>pDstBox</c>
		/// points—that has a non-(0,0,0) offset, and if the driver does not support command lists, <c>UpdateSubresource</c> inappropriately
		/// applies that destination-box offset to the <c>pSrcData</c> parameter. To work around this behavior, use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-updatesubresource void UpdateSubresource(
		// [in] ID3D11Resource *pDstResource, [in] uint DstSubresource, [in, optional] const D3D11_BOX *pDstBox, [in] const void *pSrcData,
		// [in] uint SrcRowPitch, [in] uint SrcDepthPitch );
		[PreserveSig]
		new void UpdateSubresource([In] ID3D11Resource pDstResource, uint DstSubresource, [In, Optional] StructPointer<D3D11_BOX> pDstBox,
			[In] IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);

		/// <summary>Copies data from a buffer holding variable length data.</summary>
		/// <param name="pDstBuffer">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>
		/// Pointer to ID3D11Buffer. This can be any buffer resource that other copy commands, such as ID3D11DeviceContext::CopyResource or
		/// ID3D11DeviceContext::CopySubresourceRegion, are able to write to.
		/// </para>
		/// </param>
		/// <param name="DstAlignedByteOffset">
		/// <para>Type: <c>uint</c></para>
		/// <para>Offset from the start of <c>pDstBuffer</c> to write 32-bit uint structure (vertex) count from <c>pSrcView</c>.</para>
		/// </param>
		/// <param name="pSrcView">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>
		/// Pointer to an ID3D11UnorderedAccessView of a Structured Buffer resource created with either D3D11_BUFFER_UAV_FLAG_APPEND or
		/// <c>D3D11_BUFFER_UAV_FLAG_COUNTER</c> specified when the UAV was created. These types of resources have hidden counters tracking
		/// "how many" records have been written.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-copystructurecount void
		// CopyStructureCount( [in] ID3D11Buffer *pDstBuffer, [in] uint DstAlignedByteOffset, [in] ID3D11UnorderedAccessView *pSrcView );
		[PreserveSig]
		new void CopyStructureCount([In] ID3D11Buffer pDstBuffer, uint DstAlignedByteOffset, [In] ID3D11UnorderedAccessView pSrcView);

		/// <summary>Set all the elements in a render target to one value.</summary>
		/// <param name="pRenderTargetView">
		/// <para>Type: <c>ID3D11RenderTargetView*</c></para>
		/// <para>Pointer to the render target.</para>
		/// </param>
		/// <param name="ColorRGBA">
		/// <para>Type: <c>const FLOAT[4]</c></para>
		/// <para>A 4-component array that represents the color to fill the render target with.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Applications that wish to clear a render target to a specific integer value bit pattern should render a screen-aligned quad
		/// instead of using this method. The reason for this is because this method accepts as input a floating point value, which may not
		/// have the same bit pattern as the original integer.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>
		/// Differences between Direct3D 9 and Direct3D 11/10: Unlike Direct3D 9, the full extent of the resource view is always cleared.
		/// Viewport and scissor settings are not applied.
		/// </description>
		/// </listheader>
		/// </list>
		/// <para></para>
		/// <para>
		/// When using D3D_FEATURE_LEVEL_9_x, ClearRenderTargetView only clears the first array slice in the render target view. This can
		/// impact (for example) cube map rendering scenarios. Applications should create a render target view for each face or array slice,
		/// then clear each view individually.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-clearrendertargetview void
		// ClearRenderTargetView( [in] ID3D11RenderTargetView *pRenderTargetView, [in] const FLOAT [4] ColorRGBA );
		[PreserveSig]
		new void ClearRenderTargetView([In] ID3D11RenderTargetView pRenderTargetView, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] ColorRGBA);

		/// <summary>Clears an unordered access resource with bit-precise values.</summary>
		/// <param name="pUnorderedAccessView">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>The ID3D11UnorderedAccessView to clear.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Type: <c>const uint[4]</c></para>
		/// <para>Values to copy to corresponding channels, see remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This API copies the lower n bits from each array element i to the corresponding channel, where n is the number of bits in the
		/// ith channel of the resource format (for example, R8G8B8_FLOAT has 8 bits for the first 3 channels). This works on any UAV with
		/// no format conversion. For a raw or structured buffer view, only the first array element value is used.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-clearunorderedaccessviewuint void
		// ClearUnorderedAccessViewUint( [in] ID3D11UnorderedAccessView *pUnorderedAccessView, [in] const uint [4] Values );
		[PreserveSig]
		new void ClearUnorderedAccessViewUint([In] ID3D11UnorderedAccessView pUnorderedAccessView, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] Values);

		/// <summary>Clears an unordered access resource with a float value.</summary>
		/// <param name="pUnorderedAccessView">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>The ID3D11UnorderedAccessView to clear.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Type: <c>const FLOAT[4]</c></para>
		/// <para>Values to copy to corresponding channels, see remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This API works on FLOAT, UNORM, and SNORM unordered access views (UAVs), with format conversion from FLOAT to *NORM where
		/// appropriate. On other UAVs, the operation is invalid and the call will not reach the driver.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-clearunorderedaccessviewfloat void
		// ClearUnorderedAccessViewFloat( [in] ID3D11UnorderedAccessView *pUnorderedAccessView, [in] const FLOAT [4] Values );
		[PreserveSig]
		new void ClearUnorderedAccessViewFloat([In] ID3D11UnorderedAccessView pUnorderedAccessView, [In, Out, MarshalAs(UnmanagedType.LPArray)] float[] Values);

		/// <summary>Clears the depth-stencil resource.</summary>
		/// <param name="pDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView*</c></para>
		/// <para>Pointer to the depth stencil to be cleared.</para>
		/// </param>
		/// <param name="ClearFlags">
		/// <para>Type: <c>uint</c></para>
		/// <para>Identify the type of data to clear (see D3D11_CLEAR_FLAG).</para>
		/// </param>
		/// <param name="Depth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Clear the depth buffer with this value. This value will be clamped between 0 and 1.</para>
		/// </param>
		/// <param name="Stencil">
		/// <para>Type: <c>UINT8</c></para>
		/// <para>Clear the stencil buffer with this value.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <list type="table">
		/// <listheader>
		/// <description>
		/// Differences between Direct3D 9 and Direct3D 11/10: Unlike Direct3D 9, the full extent of the resource view is always cleared.
		/// Viewport and scissor settings are not applied.
		/// </description>
		/// </listheader>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cleardepthstencilview void
		// ClearDepthStencilView( [in] ID3D11DepthStencilView *pDepthStencilView, [in] uint ClearFlags, [in] FLOAT Depth, [in] UINT8 Stencil );
		[PreserveSig]
		new void ClearDepthStencilView([In] ID3D11DepthStencilView pDepthStencilView, D3D11_CLEAR_FLAG ClearFlags, float Depth, byte Stencil);

		/// <summary>Generates mipmaps for the given shader resource.</summary>
		/// <param name="pShaderResourceView">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>A pointer to an ID3D11ShaderResourceView interface that represents the shader resource.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// You can call <c>GenerateMips</c> on any shader-resource view to generate the lower mipmap levels for the shader resource.
		/// <c>GenerateMips</c> uses the largest mipmap level of the view to recursively generate the lower levels of the mip and stops with
		/// the smallest level that is specified by the view. If the base resource wasn't created with D3D11_BIND_RENDER_TARGET,
		/// D3D11_BIND_SHADER_RESOURCE, and D3D11_RESOURCE_MISC_GENERATE_MIPS, the call to <c>GenerateMips</c> has no effect.
		/// </para>
		/// <para>Feature levels 9.1, 9.2, and 9.3 can't support automatic generation of mipmaps for 3D (volume) textures.</para>
		/// <para>Video adapters that support feature level 9.1 and higher support generating mipmaps if you use any of these formats:</para>
		/// <para>
		/// Video adapters that support feature level 9.2 and higher support generating mipmaps if you use any of these formats in addition
		/// to any of the formats for feature level 9.1:
		/// </para>
		/// <para>
		/// Video adapters that support feature level 9.3 and higher support generating mipmaps if you use any of these formats in addition
		/// to any of the formats for feature levels 9.1 and 9.2:
		/// </para>
		/// <para>
		/// Video adapters that support feature level 10 and higher support generating mipmaps if you use any of these formats in addition
		/// to any of the formats for feature levels 9.1, 9.2, and 9.3:
		/// </para>
		/// <para>For all other unsupported formats, <c>GenerateMips</c> will silently fail.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-generatemips void GenerateMips( [in]
		// ID3D11ShaderResourceView *pShaderResourceView );
		[PreserveSig]
		new void GenerateMips([In] ID3D11ShaderResourceView pShaderResourceView);

		/// <summary>Sets the minimum level-of-detail (LOD) for a resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to an ID3D11Resource that represents the resource.</para>
		/// </param>
		/// <param name="MinLOD">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The level-of-detail, which ranges between 0 and the maximum number of mipmap levels of the resource. For example, the maximum
		/// number of mipmap levels of a 1D texture is specified in the <c>MipLevels</c> member of the D3D11_TEXTURE1D_DESC structure.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To use a resource with <c>SetResourceMinLOD</c>, you must set the D3D11_RESOURCE_MISC_RESOURCE_CLAMP flag when you create that resource.
		/// </para>
		/// <para>
		/// For Direct3D 10 and Direct3D 10.1, when sampling from a texture resource in a shader, the sampler can define a minimum LOD clamp
		/// to force sampling from less detailed mip levels. For Direct3D 11, this functionality is extended from the sampler to the entire
		/// resource. Therefore, the application can specify the highest-resolution mip level of a resource that is available for access.
		/// This restricts the set of mip levels that are required to be resident in GPU memory, thereby saving memory.
		/// </para>
		/// <para>The set of mip levels resident per-resource in GPU memory can be specified by the user.</para>
		/// <para>Minimum LOD affects all of the resident mip levels. Therefore, only the resident mip levels can be updated and read from.</para>
		/// <para>All methods that access texture resources must adhere to minimum LOD clamps.</para>
		/// <para>Empty-set accesses are handled as out-of-bounds cases.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-setresourceminlod void SetResourceMinLOD(
		// [in] ID3D11Resource *pResource, FLOAT MinLOD );
		[PreserveSig]
		new void SetResourceMinLOD([In] ID3D11Resource pResource, float MinLOD);

		/// <summary>Gets the minimum level-of-detail (LOD).</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to an ID3D11Resource which represents the resource.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the minimum LOD.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-getresourceminlod FLOAT GetResourceMinLOD(
		// [in] ID3D11Resource *pResource );
		[PreserveSig]
		new float GetResourceMinLOD([In] ID3D11Resource pResource);

		/// <summary>Copy a multisampled resource into a non-multisampled resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Destination resource. Must be a created with the D3D11_USAGE_DEFAULT flag and be single-sampled. See ID3D11Resource.</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>A zero-based index, that identifies the destination subresource. Use D3D11CalcSubresource to calculate the index.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Source resource. Must be multisampled.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>The source subresource of the source resource.</para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>A DXGI_FORMAT that indicates how the multisampled resource will be resolved to a single-sampled resource. See remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This API is most useful when re-using the resulting rendertarget of one render pass as an input to a second render pass.</para>
		/// <para>
		/// The source and destination resources must be the same resource type and have the same dimensions. In addition, they must have
		/// compatible formats. There are three scenarios for this:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Scenario</description>
		/// <description>Requirements</description>
		/// </listheader>
		/// <item>
		/// <description>Source and destination are prestructured and typed</description>
		/// <description>
		/// Both the source and destination must have identical formats and that format must be specified in the Format parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description>One resource is prestructured and typed and the other is prestructured and typeless</description>
		/// <description>
		/// The typed resource must have a format that is compatible with the typeless resource (i.e. the typed resource is
		/// DXGI_FORMAT_R32_FLOAT and the typeless resource is DXGI_FORMAT_R32_TYPELESS). The format of the typed resource must be specified
		/// in the Format parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Source and destination are prestructured and typeless</description>
		/// <description>
		/// Both the source and destination must have the same typeless format (i.e. both must have DXGI_FORMAT_R32_TYPELESS), and the
		/// Format parameter must specify a format that is compatible with the source and destination (i.e. if both are
		/// DXGI_FORMAT_R32_TYPELESS then DXGI_FORMAT_R32_FLOAT could be specified in the Format parameter). For example, given the
		/// DXGI_FORMAT_R16G16B16A16_TYPELESS format:
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-resolvesubresource void
		// ResolveSubresource( [in] ID3D11Resource *pDstResource, [in] uint DstSubresource, [in] ID3D11Resource *pSrcResource, [in] uint
		// SrcSubresource, [in] DXGI_FORMAT Format );
		[PreserveSig]
		new void ResolveSubresource([In] ID3D11Resource pDstResource, uint DstSubresource, [In] ID3D11Resource pSrcResource,
			uint SrcSubresource, DXGI_FORMAT Format);

		/// <summary>Queues commands from a command list onto a device.</summary>
		/// <param name="pCommandList">
		/// <para>Type: <c>ID3D11CommandList*</c></para>
		/// <para>A pointer to an ID3D11CommandList interface that encapsulates a command list.</para>
		/// </param>
		/// <param name="RestoreContextState">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean flag that determines whether the target context state is saved prior to and restored after the execution of a command
		/// list. Use <c>TRUE</c> to indicate that the runtime needs to save and restore the state. Use <c>FALSE</c> to indicate that no
		/// state shall be saved or restored, which causes the target context to return to its default state after the command list
		/// executes. Applications should typically use <c>FALSE</c> unless they will restore the state to be nearly equivalent to the state
		/// that the runtime would restore if <c>TRUE</c> were passed. When applications use <c>FALSE</c>, they can avoid unnecessary and
		/// inefficient state transitions.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Use this method to play back a command list that was recorded by a deferred context on any thread.</para>
		/// <para>
		/// A call to <c>ExecuteCommandList</c> of a command list from a deferred context onto the immediate context is required for the
		/// recorded commands to be executed on the graphics processing unit (GPU). A call to <c>ExecuteCommandList</c> of a command list
		/// from a deferred context onto another deferred context can be used to merge recorded lists. But to run the commands from the
		/// merged deferred command list on the GPU, you need to execute them on the immediate context.
		/// </para>
		/// <para>
		/// This method performs some runtime validation related to queries. Queries that are begun in a device context cannot be
		/// manipulated indirectly by executing a command list (that is, Begin or End was invoked against the same query by the deferred
		/// context which generated the command list). If such a condition occurs, the ExecuteCommandList method does not execute the
		/// command list. However, the state of the device context is still maintained, as would be expected ([In]
		/// ID3D11DeviceContext::ClearState is performed, unless the application indicates to preserve the device context state).
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-executecommandlist void
		// ExecuteCommandList( [in] ID3D11CommandList *pCommandList, BOOL RestoreContextState );
		[PreserveSig]
		new void ExecuteCommandList([In] ID3D11CommandList pCommandList, bool RestoreContextState);

		/// <summary>Bind an array of shader resources to the hull-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources(ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a render target, then the method will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hssetshaderresources void
		// HSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		new void HSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Set a hull shader to the device.</summary>
		/// <param name="pHullShader">
		/// <para>Type: <c>ID3D11HullShader*</c></para>
		/// <para>Pointer to a hull shader (see ID3D11HullShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hssetshader void HSSetShader( [in,
		// optional] ID3D11HullShader *pHullShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint NumClassInstances );
		[PreserveSig]
		new void HSSetShader([In, Optional] ID3D11HullShader? pHullShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Set an array of sampler states to the hull-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hssetsamplers void HSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		new void HSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Set the constant buffers used by the hull-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, can bind a larger number of ID3D11Buffer resources to the
		/// shader than the maximum constant buffer size that is supported by shaders (4096 constants – 432-bit components each). When you
		/// bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer, as if 4096
		/// constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// If the application wants the shader to access other parts of the buffer, it must call the HSSetConstantBuffers1 method instead.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hssetconstantbuffers void
		// HSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		new void HSSetConstantBuffers(uint StartSlot, int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Bind an array of shader resources to the domain-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources(ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a render target, then the method will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dssetshaderresources void
		// DSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		new void DSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Set a domain shader to the device.</summary>
		/// <param name="pDomainShader">
		/// <para>Type: <c>ID3D11DomainShader*</c></para>
		/// <para>Pointer to a domain shader (see ID3D11DomainShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dssetshader void DSSetShader( [in,
		// optional] ID3D11DomainShader *pDomainShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint NumClassInstances );
		[PreserveSig]
		new void DSSetShader([In, Optional] ID3D11DomainShader? pDomainShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Set an array of sampler states to the domain-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dssetsamplers void DSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		new void DSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Sets the constant buffers used by the domain-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, can bind a larger number of ID3D11Buffer resources to the
		/// shader than the maximum constant buffer size that is supported by shaders (4096 constants – 432-bit components each). When you
		/// bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer, as if 4096
		/// constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// If the application wants the shader to access other parts of the buffer, it must call the DSSetConstantBuffers1 method instead.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dssetconstantbuffers void
		// DSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		new void DSSetConstantBuffers(uint StartSlot, int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Bind an array of shader resources to the compute-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources(ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a render target, then the method will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cssetshaderresources void
		// CSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		new void CSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Sets an array of views for an unordered resource.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index of the first element in the zero-based array to begin setting (ranges from 0 to D3D11_1_UAV_SLOT_COUNT - 1).
		/// D3D11_1_UAV_SLOT_COUNT is defined as 64.
		/// </para>
		/// </param>
		/// <param name="NumUAVs">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of views to set (ranges from 0 to D3D11_1_UAV_SLOT_COUNT - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppUnorderedAccessViews">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>A pointer to an array of ID3D11UnorderedAccessView pointers to be set by the method.</para>
		/// </param>
		/// <param name="pUAVInitialCounts">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>
		/// An array of append and consume buffer offsets. A value of -1 indicates to keep the current offset. Any other values set the
		/// hidden counter for that appendable and consumable UAV. <c>pUAVInitialCounts</c> is only relevant for UAVs that were created with
		/// either D3D11_BUFFER_UAV_FLAG_APPEND or <c>D3D11_BUFFER_UAV_FLAG_COUNTER</c> specified when the UAV was created; otherwise, the
		/// argument is ignored.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cssetunorderedaccessviews void
		// CSSetUnorderedAccessViews( [in] uint StartSlot, [in] uint NumUAVs, [in, optional] ID3D11UnorderedAccessView * const
		// *ppUnorderedAccessViews, [in, optional] const uint *pUAVInitialCounts );
		[PreserveSig]
		new void CSSetUnorderedAccessViews(uint StartSlot, int NumUAVs, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11UnorderedAccessView[]? ppUnorderedAccessViews,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pUAVInitialCounts);

		/// <summary>Set a compute shader to the device.</summary>
		/// <param name="pComputeShader">
		/// <para>Type: <c>ID3D11ComputeShader*</c></para>
		/// <para>Pointer to a compute shader (see ID3D11ComputeShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cssetshader void CSSetShader( [in,
		// optional] ID3D11ComputeShader *pComputeShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint
		// NumClassInstances );
		[PreserveSig]
		new void CSSetShader([In] ID3D11ComputeShader? pComputeShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Set an array of sampler states to the compute-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cssetsamplers void CSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		new void CSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Sets the constant buffers used by the compute-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, can bind a larger number of ID3D11Buffer resources to the
		/// shader than the maximum constant buffer size that is supported by shaders (4096 constants – 4*32-bit components each). When you
		/// bind such a large buffer, the shader can access only the first 4096 4*32-bit component constants in the buffer, as if 4096
		/// constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// If the application wants the shader to access other parts of the buffer, it must call the CSSetConstantBuffers1 method instead.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cssetconstantbuffers void
		// CSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		new void CSSetConstantBuffers(uint StartSlot, int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get the constant buffers used by the vertex shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vsgetconstantbuffers void
		// VSGetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		new void VSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get the pixel shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-psgetshaderresources void
		// PSGetShaderResources( [in] uint StartSlot, [in] uint NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		new void PSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Get the pixel shader currently set on the device.</summary>
		/// <param name="ppPixelShader">
		/// <para>Type: <c>ID3D11PixelShader**</c></para>
		/// <para>Address of a pointer to a pixel shader (see ID3D11PixelShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>uint*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed, to avoid memory leaks.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-psgetshader void PSGetShader( [out]
		// ID3D11PixelShader **ppPixelShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] uint
		// *pNumClassInstances );
		[PreserveSig]
		new void PSGetShader(out ID3D11PixelShader? ppPixelShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances,
			ref uint pNumClassInstances);

		/// <summary>Get an array of sampler states from the pixel shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Array of sampler-state interface pointers (see ID3D11SamplerState) to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-psgetsamplers void PSGetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		new void PSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get the vertex shader currently set on the device.</summary>
		/// <param name="ppVertexShader">
		/// <para>Type: <c>ID3D11VertexShader**</c></para>
		/// <para>Address of a pointer to a vertex shader (see ID3D11VertexShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>uint*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vsgetshader void VSGetShader( [out]
		// ID3D11VertexShader **ppVertexShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] uint
		// *pNumClassInstances );
		[PreserveSig]
		new void VSGetShader(out ID3D11VertexShader? ppVertexShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, ref uint pNumClassInstances);

		/// <summary>Get the constant buffers used by the pixel shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-psgetconstantbuffers void
		// PSGetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		new void PSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get a pointer to the input-layout object that is bound to the input-assembler stage.</summary>
		/// <param name="ppInputLayout">
		/// <para>Type: <c>ID3D11InputLayout**</c></para>
		/// <para>
		/// A pointer to the input-layout object (see ID3D11InputLayout), which describes the input buffers that will be read by the IA stage.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>For information about creating an input-layout object, see Creating the Input-Layout Object.</para>
		/// <para>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iagetinputlayout void IAGetInputLayout(
		// [out] ID3D11InputLayout **ppInputLayout );
		[PreserveSig]
		new void IAGetInputLayout(out ID3D11InputLayout? ppInputLayout);

		/// <summary>Get the vertex buffers bound to the input-assembler stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The input slot of the first vertex buffer to get. The first vertex buffer is explicitly bound to the start slot; this causes
		/// each additional vertex buffer in the array to be implicitly bound to each subsequent input slot. The maximum of 16 or 32 input
		/// slots (ranges from 0 to D3D11_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT - 1) are available; the maximum number of input slots depends
		/// on the feature level.
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of vertex buffers to get starting at the offset. The number of buffers (plus the starting slot) cannot exceed the
		/// total number of IA-stage input slots.
		/// </para>
		/// </param>
		/// <param name="ppVertexBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>A pointer to an array of vertex buffers returned by the method (see ID3D11Buffer).</para>
		/// </param>
		/// <param name="pStrides">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// Pointer to an array of stride values returned by the method; one stride value for each buffer in the vertex-buffer array. Each
		/// stride value is the size (in bytes) of the elements that are to be used from that vertex buffer.
		/// </para>
		/// </param>
		/// <param name="pOffsets">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// Pointer to an array of offset values returned by the method; one offset value for each buffer in the vertex-buffer array. Each
		/// offset is the number of bytes between the first element of a vertex buffer and the first element that will be used.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iagetvertexbuffers void
		// IAGetVertexBuffers( [in] uint StartSlot, [in] uint NumBuffers, [out, optional] ID3D11Buffer **ppVertexBuffers, [out, optional]
		// uint *pStrides, [out, optional] uint *pOffsets );
		[PreserveSig]
		new void IAGetVertexBuffers(uint StartSlot, int NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppVertexBuffers,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pStrides, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pOffsets);

		/// <summary>Get a pointer to the index buffer that is bound to the input-assembler stage.</summary>
		/// <param name="pIndexBuffer">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>A pointer to an index buffer returned by the method (see ID3D11Buffer).</para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT*</c></para>
		/// <para>
		/// Specifies format of the data in the index buffer (see DXGI_FORMAT). These formats provide the size and type of the data in the
		/// buffer. The only formats allowed for index buffer data are 16-bit (DXGI_FORMAT_R16_UINT) and 32-bit (DXGI_FORMAT_R32_UINT) integers.
		/// </para>
		/// </param>
		/// <param name="Offset">
		/// <para>Type: <c>uint*</c></para>
		/// <para>Offset (in bytes) from the start of the index buffer, to the first index to use.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iagetindexbuffer void IAGetIndexBuffer(
		// [out, optional] ID3D11Buffer **pIndexBuffer, [out, optional] DXGI_FORMAT *Format, [out, optional] uint *Offset );
		[PreserveSig]
		new void IAGetIndexBuffer(out ID3D11Buffer? pIndexBuffer, out DXGI_FORMAT Format, out uint Offset);

		/// <summary>Get the constant buffers used by the geometry shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gsgetconstantbuffers void
		// GSGetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		new void GSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get the geometry shader currently set on the device.</summary>
		/// <param name="ppGeometryShader">
		/// <para>Type: <c>ID3D11GeometryShader**</c></para>
		/// <para>Address of a pointer to a geometry shader (see ID3D11GeometryShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>uint*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gsgetshader void GSGetShader( [out]
		// ID3D11GeometryShader **ppGeometryShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] uint
		// *pNumClassInstances );
		[PreserveSig]
		new void GSGetShader(out ID3D11GeometryShader? ppGeometryShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ClassInstance[]? ppClassInstances,
			ref uint pNumClassInstances);

		/// <summary>Get information about the primitive type, and data order that describes input data for the input assembler stage.</summary>
		/// <param name="pTopology">
		/// <para>Type: <c>D3D11_PRIMITIVE_TOPOLOGY*</c></para>
		/// <para>A pointer to the type of primitive, and ordering of the primitive data (see D3D11_PRIMITIVE_TOPOLOGY).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iagetprimitivetopology void
		// IAGetPrimitiveTopology( [out] D3D11_PRIMITIVE_TOPOLOGY *pTopology );
		[PreserveSig]
		new void IAGetPrimitiveTopology(out D3D_PRIMITIVE_TOPOLOGY pTopology);

		/// <summary>Get the vertex shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vsgetshaderresources void
		// VSGetShaderResources( [in] uint StartSlot, [in] uint NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		new void VSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Get an array of sampler states from the vertex shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Array of sampler-state interface pointers (see ID3D11SamplerState) to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vsgetsamplers void VSGetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		new void VSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get the rendering predicate state.</summary>
		/// <param name="ppPredicate">
		/// <para>Type: <c>ID3D11Predicate**</c></para>
		/// <para>Address of a pointer to a predicate (see ID3D11Predicate). Value stored here will be <c>NULL</c> upon device creation.</para>
		/// </param>
		/// <param name="pPredicateValue">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Address of a boolean to fill with the predicate comparison value. <c>FALSE</c> upon device creation.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-getpredication void GetPredication( [out,
		// optional] ID3D11Predicate **ppPredicate, [out, optional] BOOL *pPredicateValue );
		[PreserveSig]
		new void GetPredication(out ID3D11Predicate? ppPredicate, [MarshalAs(UnmanagedType.Bool)] out bool pPredicateValue);

		/// <summary>Get the geometry shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gsgetshaderresources void
		// GSGetShaderResources( [in] uint StartSlot, [in] uint NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		new void GSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Get an array of sampler state interfaces from the geometry shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gsgetsamplers void GSGetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		new void GSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get pointers to the resources bound to the output-merger stage.</summary>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of render targets to retrieve.</para>
		/// </param>
		/// <param name="ppRenderTargetViews">
		/// <para>Type: <c>ID3D11RenderTargetView**</c></para>
		/// <para>
		/// Pointer to an array of ID3D11RenderTargetViews which represent render target views. Specify <c>NULL</c> for this parameter when
		/// retrieval of a render target is not needed.
		/// </para>
		/// </param>
		/// <param name="ppDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView**</c></para>
		/// <para>
		/// Pointer to a ID3D11DepthStencilView, which represents a depth-stencil view. Specify <c>NULL</c> for this parameter when
		/// retrieval of the depth-stencil view is not needed.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omgetrendertargets void
		// OMGetRenderTargets( [in] uint NumViews, [out, optional] ID3D11RenderTargetView **ppRenderTargetViews, [out, optional]
		// ID3D11DepthStencilView **ppDepthStencilView );
		[PreserveSig]
		new void OMGetRenderTargets(uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D11RenderTargetView[]? ppRenderTargetViews,
			out ID3D11DepthStencilView? ppDepthStencilView);

		/// <summary>Get pointers to the resources bound to the output-merger stage.</summary>
		/// <param name="NumRTVs">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of render-target views to retrieve.</para>
		/// </param>
		/// <param name="ppRenderTargetViews">
		/// <para>Type: <c>ID3D11RenderTargetView**</c></para>
		/// <para>
		/// Pointer to an array of ID3D11RenderTargetViews, which represent render-target views. Specify <c>NULL</c> for this parameter when
		/// retrieval of render-target views is not required.
		/// </para>
		/// </param>
		/// <param name="ppDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView**</c></para>
		/// <para>
		/// Pointer to a ID3D11DepthStencilView, which represents a depth-stencil view. Specify <c>NULL</c> for this parameter when
		/// retrieval of the depth-stencil view is not required.
		/// </para>
		/// </param>
		/// <param name="UAVStartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into a zero-based array to begin retrieving unordered-access views (ranges from 0 to D3D11_PS_CS_UAV_REGISTER_COUNT - 1).
		/// For pixel shaders <c>UAVStartSlot</c> should be equal to the number of render-target views that are bound.
		/// </para>
		/// </param>
		/// <param name="NumUAVs">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of unordered-access views to return in <c>ppUnorderedAccessViews</c>. This number ranges from 0 to
		/// D3D11_PS_CS_UAV_REGISTER_COUNT - <c>UAVStartSlot</c>.
		/// </para>
		/// </param>
		/// <param name="ppUnorderedAccessViews">
		/// <para>Type: <c>ID3D11UnorderedAccessView**</c></para>
		/// <para>
		/// Pointer to an array of ID3D11UnorderedAccessViews, which represent unordered-access views that are retrieved. Specify
		/// <c>NULL</c> for this parameter when retrieval of unordered-access views is not required.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omgetrendertargetsandunorderedaccessviews
		// void OMGetRenderTargetsAndUnorderedAccessViews( [in] UINT NumRTVs, [out, optional] ID3D11RenderTargetView **ppRenderTargetViews,
		// [out, optional] ID3D11DepthStencilView **ppDepthStencilView, [in] UINT UAVStartSlot, [in] UINT NumUAVs, [out, optional]
		// ID3D11UnorderedAccessView **ppUnorderedAccessViews );
		[PreserveSig]
		new void OMGetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D11RenderTargetView[]? ppRenderTargetViews,
			out ID3D11DepthStencilView? ppDepthStencilView, uint UAVStartSlot, uint NumUAVs,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 4)] ID3D11UnorderedAccessView[]? ppUnorderedAccessViews);

		/// <summary>Get the blend state of the output-merger stage.</summary>
		/// <param name="ppBlendState">
		/// <para>Type: <c>ID3D11BlendState**</c></para>
		/// <para>Address of a pointer to a blend-state interface (see ID3D11BlendState).</para>
		/// </param>
		/// <param name="BlendFactor">
		/// <para>Type: <c>FLOAT[4]</c></para>
		/// <para>Array of blend factors, one for each RGBA component.</para>
		/// </param>
		/// <param name="pSampleMask">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer to a sample mask.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The reference count of the returned interface will be incremented by one when the blend state is retrieved. Applications must
		/// release returned pointer(s) when they are no longer needed, or else there will be a memory leak.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omgetblendstate void OMGetBlendState(
		// [out, optional] ID3D11BlendState **ppBlendState, [out, optional] FLOAT [4] BlendFactor, [out, optional] UINT *pSampleMask );
		[PreserveSig]
		new void OMGetBlendState(out ID3D11BlendState? ppBlendState, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[]? BlendFactor,
			out uint pSampleMask);

		/// <summary>Gets the depth-stencil state of the output-merger stage.</summary>
		/// <param name="ppDepthStencilState">
		/// <para>Type: <c>ID3D11DepthStencilState**</c></para>
		/// <para>
		/// Address of a pointer to a depth-stencil state interface (see ID3D11DepthStencilState) to be filled with information from the device.
		/// </para>
		/// </param>
		/// <param name="pStencilRef">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer to the stencil reference value used in the depth-stencil test.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omgetdepthstencilstate void
		// OMGetDepthStencilState( [out, optional] ID3D11DepthStencilState **ppDepthStencilState, [out, optional] UINT *pStencilRef );
		[PreserveSig]
		new void OMGetDepthStencilState(out ID3D11DepthStencilState? ppDepthStencilState, out uint pStencilRef);

		/// <summary>Get the target output buffers for the stream-output stage of the pipeline.</summary>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers to get.</para>
		/// </param>
		/// <param name="ppSOTargets">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>An array of output buffers (see ID3D11Buffer) to be retrieved from the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A maximum of four output buffers can be retrieved.</para>
		/// <para>
		/// The offsets to the output buffers pointed to in the returned <c>ppSOTargets</c> array may be assumed to be -1 (append), as
		/// defined for use in ID3D11DeviceContext::SOSetTargets.
		/// </para>
		/// <para>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-sogettargets void SOGetTargets( [in] UINT
		// NumBuffers, [out, optional] ID3D11Buffer **ppSOTargets );
		[PreserveSig]
		new void SOGetTargets(uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D11Buffer[]? ppSOTargets);

		/// <summary>Get the rasterizer state from the rasterizer stage of the pipeline.</summary>
		/// <param name="ppRasterizerState">
		/// <para>Type: <c>ID3D11RasterizerState**</c></para>
		/// <para>Address of a pointer to a rasterizer-state interface (see ID3D11RasterizerState) to fill with information from the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rsgetstate void RSGetState( [out]
		// ID3D11RasterizerState **ppRasterizerState );
		[PreserveSig]
		new void RSGetState(out ID3D11RasterizerState? ppRasterizerState);

		/// <summary>Gets the array of viewports bound to the rasterizer stage.</summary>
		/// <param name="pNumViewports">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer to a variable that, on input, specifies the number of viewports (ranges from 0 to
		/// <c>D3D11_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE</c>) in the <c>pViewports</c> array; on output, the variable
		/// contains the actual number of viewports that are bound to the rasterizer stage. If <c>pViewports</c> is <c>NULL</c>,
		/// <c>RSGetViewports</c> fills the variable with the number of viewports currently bound.
		/// </para>
		/// <para>
		/// <c>Note</c>  In some versions of the Windows SDK, a debug device will raise an exception if the input value in the variable to
		/// which <c>pNumViewports</c> points is greater than <c>D3D11_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE</c> even if
		/// <c>pViewports</c> is <c>NULL</c>. The regular runtime ignores the value in the variable to which <c>pNumViewports</c> points
		/// when <c>pViewports</c> is <c>NULL</c>. This behavior of a debug device might be corrected in a future release of the Windows SDK.
		/// </para>
		/// <para></para>
		/// </param>
		/// <param name="pViewports">
		/// <para>Type: <c>D3D11_VIEWPORT*</c></para>
		/// <para>
		/// An array of D3D11_VIEWPORT structures for the viewports that are bound to the rasterizer stage. If the number of viewports (in
		/// the variable to which <c>pNumViewports</c> points) is greater than the actual number of viewports currently bound, unused
		/// elements of the array contain 0. For info about how the viewport size depends on the device feature level, which has changed
		/// between Direct3D 11 and Direct3D 10, see <c>D3D11_VIEWPORT</c>.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rsgetviewports void RSGetViewports( [in,
		// out] UINT *pNumViewports, [out, optional] D3D11_VIEWPORT *pViewports );
		[PreserveSig]
		new void RSGetViewports(ref int pNumViewports, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D11_VIEWPORT[]? pViewports);

		/// <summary>Get the array of scissor rectangles bound to the rasterizer stage.</summary>
		/// <param name="pNumRects">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// The number of scissor rectangles (ranges between 0 and D3D11_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE) bound; set
		/// <c>pRects</c> to <c>NULL</c> to use <c>pNumRects</c> to see how many rectangles would be returned.
		/// </para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <c>D3D11_RECT*</c></para>
		/// <para>
		/// An array of scissor rectangles (see D3D11_RECT). If NumRects is greater than the number of scissor rects currently bound, then
		/// unused members of the array will contain 0.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rsgetscissorrects void RSGetScissorRects(
		// [in, out] UINT *pNumRects, [out, optional] D3D11_RECT *pRects );
		[PreserveSig]
		new void RSGetScissorRects(ref int pNumRects, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[]? pRects);

		/// <summary>Get the hull-shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hsgetshaderresources void
		// HSGetShaderResources( [in] UINT StartSlot, [in] UINT NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		new void HSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Get the hull shader currently set on the device.</summary>
		/// <param name="ppHullShader">
		/// <para>Type: <c>ID3D11HullShader**</c></para>
		/// <para>Address of a pointer to a hull shader (see ID3D11HullShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hsgetshader void HSGetShader( [out]
		// ID3D11HullShader **ppHullShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] UINT
		// *pNumClassInstances );
		[PreserveSig]
		new void HSGetShader(out ID3D11HullShader? ppHullShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D11ClassInstance[]? ppClassInstances,
			ref uint pNumClassInstances);

		/// <summary>Get an array of sampler state interfaces from the hull-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hsgetsamplers void HSGetSamplers( [in]
		// UINT StartSlot, [in] UINT NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		new void HSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get the constant buffers used by the hull-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hsgetconstantbuffers void
		// HSGetConstantBuffers( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		new void HSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get the domain-shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dsgetshaderresources void
		// DSGetShaderResources( [in] UINT StartSlot, [in] UINT NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		new void DSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Get the domain shader currently set on the device.</summary>
		/// <param name="ppDomainShader">
		/// <para>Type: <c>ID3D11DomainShader**</c></para>
		/// <para>Address of a pointer to a domain shader (see ID3D11DomainShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dsgetshader void DSGetShader( [out]
		// ID3D11DomainShader **ppDomainShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] UINT
		// *pNumClassInstances );
		[PreserveSig]
		new void DSGetShader(out ID3D11DomainShader ppDomainShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances,
			[Optional] ref uint pNumClassInstances);

		/// <summary>Get an array of sampler state interfaces from the domain-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dsgetsamplers void DSGetSamplers( [in]
		// UINT StartSlot, [in] UINT NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		new void DSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get the constant buffers used by the domain-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dsgetconstantbuffers void
		// DSGetConstantBuffers( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		new void DSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get the compute-shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-csgetshaderresources void
		// CSGetShaderResources( [in] UINT StartSlot, [in] UINT NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		new void CSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Gets an array of views for an unordered resource.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Index of the first element in the zero-based array to return (ranges from 0 to D3D11_1_UAV_SLOT_COUNT - 1).</para>
		/// </param>
		/// <param name="NumUAVs">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of views to get (ranges from 0 to D3D11_1_UAV_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppUnorderedAccessViews">
		/// <para>Type: <c>ID3D11UnorderedAccessView**</c></para>
		/// <para>A pointer to an array of interface pointers (see ID3D11UnorderedAccessView) to get.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call <c>IUnknown::Release</c> on
		/// the returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-csgetunorderedaccessviews void
		// CSGetUnorderedAccessViews( [in] UINT StartSlot, [in] UINT NumUAVs, [out, optional] ID3D11UnorderedAccessView
		// **ppUnorderedAccessViews );
		[PreserveSig]
		new void CSGetUnorderedAccessViews(uint StartSlot, uint NumUAVs, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11UnorderedAccessView[]? ppUnorderedAccessViews);

		/// <summary>Get the compute shader currently set on the device.</summary>
		/// <param name="ppComputeShader">
		/// <para>Type: <c>ID3D11ComputeShader**</c></para>
		/// <para>Address of a pointer to a Compute shader (see ID3D11ComputeShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-csgetshader void CSGetShader( [out]
		// ID3D11ComputeShader **ppComputeShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] UINT
		// *pNumClassInstances );
		[PreserveSig]
		new void CSGetShader(out ID3D11ComputeShader? ppComputeShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances,
			[Optional] ref uint pNumClassInstances);

		/// <summary>Get an array of sampler state interfaces from the compute-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-csgetsamplers void CSGetSamplers( [in]
		// UINT StartSlot, [in] UINT NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		new void CSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get the constant buffers used by the compute-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-csgetconstantbuffers void
		// CSGetConstantBuffers( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		new void CSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Restore all default settings.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method resets any device context to the default settings. This sets all input/output resource slots, shaders, input
		/// layouts, predications, scissor rectangles, depth-stencil state, rasterizer state, blend state, sampler state, and viewports to
		/// <c>NULL</c>. The primitive topology is set to UNDEFINED.
		/// </para>
		/// <para>
		/// For a scenario where you would like to clear a list of commands recorded so far, call ID3D11DeviceContext::FinishCommandList and
		/// throw away the resulting ID3D11CommandList.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-clearstate void ClearState();
		[PreserveSig]
		new void ClearState();

		/// <summary>Sends queued-up commands in the command buffer to the graphics processing unit (GPU).</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Most applications don't need to call this method. If an application calls this method when not necessary, it incurs a
		/// performance penalty. Each call to <c>Flush</c> incurs a significant amount of overhead.
		/// </para>
		/// <para>
		/// When Microsoft Direct3D state-setting, present, or draw commands are called by an application, those commands are queued into an
		/// internal command buffer. <c>Flush</c> sends those commands to the GPU for processing. Typically, the Direct3D runtime sends
		/// these commands to the GPU automatically whenever the runtime determines that they need to be sent, such as when the command
		/// buffer is full or when an application maps a resource. <c>Flush</c> sends the commands manually.
		/// </para>
		/// <para>
		/// We recommend that you use <c>Flush</c> when the CPU waits for an arbitrary amount of time (such as when you call the Sleep function).
		/// </para>
		/// <para>
		/// Because <c>Flush</c> operates asynchronously, it can return either before or after the GPU finishes executing the queued
		/// graphics commands. However, the graphics commands eventually always complete. You can call the ID3D11Device::CreateQuery method
		/// with the D3D11_QUERY_EVENT value to create an event query; you can then use that event query in a call to the
		/// ID3D11DeviceContext::GetData method to determine when the GPU is finished processing the graphics commands.
		/// </para>
		/// <para>
		/// Microsoft Direct3D 11 defers the destruction of objects. Therefore, an application can't rely upon objects immediately being
		/// destroyed. By calling <c>Flush</c>, you destroy any objects whose destruction was deferred. If an application requires
		/// synchronous destruction of an object, we recommend that the application release all its references, call
		/// ID3D11DeviceContext::ClearState, and then call <c>Flush</c>.
		/// </para>
		/// <para>Deferred Destruction Issues with Flip Presentation Swap Chains</para>
		/// <para>
		/// Direct3D 11 defers the destruction of objects like views and resources until it can efficiently destroy them. This deferred
		/// destruction can cause problems with flip presentation model swap chains. Flip presentation model swap chains have the
		/// DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL flag set. When you create a flip presentation model swap chain, you can associate only one swap
		/// chain at a time with an HWND, <c>IWindow</c>, or composition surface. If an application attempts to destroy a flip presentation
		/// model swap chain and replace it with another swap chain, the original swap chain is not destroyed when the application
		/// immediately frees all of the original swap chain's references.
		/// </para>
		/// <para>
		/// Most applications typically use the IDXGISwapChain::ResizeBuffers method for the majority of scenarios where they replace new
		/// swap chain buffers for old swap chain buffers. However, if an application must actually destroy an old swap chain and create a
		/// new swap chain, the application must force the destruction of all objects that the application freed. To force the destruction,
		/// call ID3D11DeviceContext::ClearState (or otherwise ensure no views are bound to pipeline state), and then call <c>Flush</c> on
		/// the immediate context. You must force destruction before you call IDXGIFactory2::CreateSwapChainForHwnd,
		/// IDXGIFactory2::CreateSwapChainForCoreWindow, or IDXGIFactory2::CreateSwapChainForComposition again to create a new swap chain.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-flush void Flush();
		[PreserveSig]
		new void Flush();

		/// <summary>Gets the type of device context.</summary>
		/// <returns>
		/// <para>Type: <c>D3D11_DEVICE_CONTEXT_TYPE</c></para>
		/// <para>A member of D3D11_DEVICE_CONTEXT_TYPE that indicates the type of device context.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gettype D3D11_DEVICE_CONTEXT_TYPE GetType();
		[PreserveSig]
		new D3D11_DEVICE_CONTEXT_TYPE GetType();

		/// <summary>Gets the initialization flags associated with the current deferred context.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// The GetContextFlags method gets the flags that were supplied to the <c>ContextFlags</c> parameter of
		/// ID3D11Device::CreateDeferredContext; however, the context flag is reserved for future use.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-getcontextflags UINT GetContextFlags();
		[PreserveSig]
		new uint GetContextFlags();

		/// <summary>Create a command list and record graphics commands into it.</summary>
		/// <param name="RestoreDeferredContextState">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean flag that determines whether the runtime saves deferred context state before it executes <c>FinishCommandList</c> and
		/// restores it afterwards. Use <c>TRUE</c> to indicate that the runtime needs to save and restore the state. Use <c>FALSE</c> to
		/// indicate that the runtime will not save or restore any state. In this case, the deferred context will return to its default
		/// state after the call to <c>FinishCommandList</c> completes. For information about default state, see
		/// ID3D11DeviceContext::ClearState. Typically, use <c>FALSE</c> unless you restore the state to be nearly equivalent to the state
		/// that the runtime would restore if you passed <c>TRUE</c>. When you use <c>FALSE</c>, you can avoid unnecessary and inefficient
		/// state transitions.
		/// </para>
		/// <para>
		/// <c>Note</c>  This parameter does not affect the command list that the current call to <c>FinishCommandList</c> returns. However,
		/// this parameter affects the command list of the next call to <c>FinishCommandList</c> on the same deferred context.
		/// </para>
		/// <para></para>
		/// </param>
		/// <param name="ppCommandList">
		/// <para>Type: <c>ID3D11CommandList**</c></para>
		/// <para>
		/// Upon completion of the method, the passed pointer to an ID3D11CommandList interface pointer is initialized with the recorded
		/// command list information. The resulting <c>ID3D11CommandList</c> object is immutable and can only be used with ID3D11DeviceContext::ExecuteCommandList.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Returns DXGI_ERROR_DEVICE_REMOVED if the video card has been physically removed from the system, or a driver upgrade for the
		/// video card has occurred. If this error occurs, you should destroy and recreate the device.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns DXGI_ERROR_INVALID_CALL if <c>FinishCommandList</c> cannot be called from the current context. See remarks.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Returns E_OUTOFMEMORY if the application has exhausted available memory.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Create a command list from a deferred context and record commands into it by calling <c>FinishCommandList</c>. Play back a
		/// command list with an immediate context by calling ID3D11DeviceContext::ExecuteCommandList.
		/// </para>
		/// <para>
		/// Immediate context state is cleared before and after a command list is executed. A command list has no concept of inheritance.
		/// Each call to <c>FinishCommandList</c> will record only the state set since any previous call to <c>FinishCommandList</c>.
		/// </para>
		/// <para>
		/// For example, the state of a device context is its render state or pipeline state. To retrieve device context state, an
		/// application can call ID3D11DeviceContext::GetData or ID3D11DeviceContext::GetPredication.
		/// </para>
		/// <para>For more information about how to use <c>FinishCommandList</c>, see How to: Record a Command List.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-finishcommandlist HRESULT
		// FinishCommandList( BOOL RestoreDeferredContextState, [out, optional] ID3D11CommandList **ppCommandList );
		[PreserveSig]
		new HRESULT FinishCommandList([MarshalAs(UnmanagedType.Bool)] bool RestoreDeferredContextState,
			[Optional, MarshalAs(UnmanagedType.Interface)] out ID3D11CommandList? ppCommandList);

		/// <summary>Copies a region from a source resource to a destination resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the destination resource.</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Destination subresource index.</para>
		/// </param>
		/// <param name="DstX">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The x-coordinate of the upper-left corner of the destination region.</para>
		/// </param>
		/// <param name="DstY">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The y-coordinate of the upper-left corner of the destination region. For a 1D subresource, this must be zero.</para>
		/// </param>
		/// <param name="DstZ">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The z-coordinate of the upper-left corner of the destination region. For a 1D or 2D subresource, this must be zero.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the source resource.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Source subresource index.</para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <c>const D3D11_BOX*</c></para>
		/// <para>
		/// A pointer to a 3D box that defines the region of the source subresource that <c>CopySubresourceRegion1</c> can copy. If
		/// <c>NULL</c>, <c>CopySubresourceRegion1</c> copies the entire source subresource. The box must fit within the source resource.
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, <c>CopySubresourceRegion1</c> doesn't perform a copy operation.
		/// </para>
		/// </param>
		/// <param name="CopyFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A D3D11_COPY_FLAGS-typed value that specifies how to perform the copy operation. If you specify zero for no copy option,
		/// <c>CopySubresourceRegion1</c> behaves like ID3D11DeviceContext::CopySubresourceRegion. For existing display drivers that can't
		/// process these flags, the runtime doesn't use them.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If the display driver supports overlapping, the source and destination subresources can be identical, and the source and
		/// destination regions can overlap each other. For existing display drivers that don’t support overlapping, the runtime drops calls
		/// with identical source and destination subresources, regardless of whether the regions overlap. To determine whether the display
		/// driver supports overlapping, check the <c>CopyWithOverlap</c> member of D3D11_FEATURE_DATA_D3D11_OPTIONS. This overlapping
		/// support enables additional scroll functionality in a call to IDXGISwapChain::Present.
		/// </para>
		/// <para>
		/// <c>Note</c>   <c>Applies only to feature level 9_x hardware</c> If you use ID3D11DeviceContext1::UpdateSubresource1 or
		/// <c>CopySubresourceRegion1</c> to copy from a staging resource to a default resource, you can corrupt the destination contents.
		/// This occurs if you pass a <c>NULL</c> source box and if the source resource has different dimensions from those of the
		/// destination resource or if you use destination offsets, (x, y, and z). In this situation, always pass a source box that is the
		/// full size of the source resource.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-copysubresourceregion1 void
		// CopySubresourceRegion1( [in] ID3D11Resource *pDstResource, [in] UINT DstSubresource, [in] UINT DstX, [in] UINT DstY, [in] UINT
		// DstZ, [in] ID3D11Resource *pSrcResource, [in] UINT SrcSubresource, [in, optional] const D3D11_BOX *pSrcBox, [in] UINT CopyFlags );
		[PreserveSig]
		new void CopySubresourceRegion1([In] ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, [In] ID3D11Resource pSrcResource,
			uint SrcSubresource, [In, Optional] StructPointer<D3D11_BOX> pSrcBox, D3D11_COPY_FLAGS CopyFlags);

		/// <summary>The CPU copies data from memory to a subresource created in non-mappable memory.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the destination resource.</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A zero-based index that identifies the destination subresource. See D3D11CalcSubresource for more details.</para>
		/// </param>
		/// <param name="pDstBox">
		/// <para>Type: <c>const D3D11_BOX*</c></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data into. Coordinates are in
		/// bytes for buffers and in texels for textures. If <c>NULL</c>, <c>UpdateSubresource1</c> writes the data to the destination
		/// subresource with no offset. The dimensions of the source must fit the destination.
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, <c>UpdateSubresource1</c> doesn't perform an update operation.
		/// </para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the source data in memory.</para>
		/// </param>
		/// <param name="SrcRowPitch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of one row of the source data.</para>
		/// </param>
		/// <param name="SrcDepthPitch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of one depth slice of source data.</para>
		/// </param>
		/// <param name="CopyFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A D3D11_COPY_FLAGS-typed value that specifies how to perform the update operation. If you specify zero for no update option,
		/// <c>UpdateSubresource1</c> behaves like ID3D11DeviceContext::UpdateSubresource. For existing display drivers that can't process
		/// these flags, the runtime doesn't use them.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If you call <c>UpdateSubresource1</c> to update a constant buffer, pass any region, and the driver has not been implemented to
		/// Windows 8, the runtime drops the call (except feature level 9.1, 9.2, and 9.3 where the runtime emulates support). The runtime
		/// also drops the call if you update a constant buffer with a partial region whose extent is not aligned to 16-byte granularity (16
		/// bytes being a full constant). When the runtime drops the call, the runtime doesn't call the corresponding device driver
		/// interface (DDI).
		/// </para>
		/// <para>
		/// When you record a call to UpdateSubresource with an offset <c>pDstBox</c> in a software command list, the offset in
		/// <c>pDstBox</c> is incorrectly applied to <c>pSrcData</c> when you play back the command list. The new-for-Windows 8
		/// <c>UpdateSubresource1</c> fixes this issue. In a call to <c>UpdateSubresource1</c>, <c>pDstBox</c> does not affect <c>pSrcData</c>.
		/// </para>
		/// <para>
		/// For info about various resource types and how <c>UpdateSubresource1</c> might work with each resource type, see Introduction to
		/// a Resource in Direct3D 11.
		/// </para>
		/// <para>
		/// <c>Note</c>   <c>Applies only to feature level 9_x hardware</c> If you use <c>UpdateSubresource1</c> or
		/// ID3D11DeviceContext1::CopySubresourceRegion1 to copy from a staging resource to a default resource, you can corrupt the
		/// destination contents. This occurs if you pass a <c>NULL</c> source box and if the source resource has different dimensions from
		/// those of the destination resource or if you use destination offsets, (x, y, and z). In this situation, always pass a source box
		/// that is the full size of the source resource.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-updatesubresource1 void
		// UpdateSubresource1( [in] ID3D11Resource *pDstResource, [in] UINT DstSubresource, [in, optional] const D3D11_BOX *pDstBox, [in]
		// const void *pSrcData, [in] UINT SrcRowPitch, [in] UINT SrcDepthPitch, [in] UINT CopyFlags );
		[PreserveSig]
		new void UpdateSubresource1([In] ID3D11Resource pDstResource, uint DstSubresource, [In, Optional] StructPointer<D3D11_BOX> pDstBox,
			[In] IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch, D3D11_COPY_FLAGS CopyFlags);

		/// <summary>Discards a resource from the device context.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// A pointer to the ID3D11Resource interface for the resource to discard. The resource must have been created with usage
		/// D3D11_USAGE_DEFAULT or D3D11_USAGE_DYNAMIC, otherwise the runtime drops the call to <c>DiscardResource</c>; if the debug layer
		/// is enabled, the runtime returns an error message.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <c>DiscardResource</c> informs the graphics processing unit (GPU) that the existing content in the resource that
		/// <c>pResource</c> points to is no longer needed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-discardresource void DiscardResource(
		// [in] ID3D11Resource *pResource );
		[PreserveSig]
		new void DiscardResource([In] ID3D11Resource pResource);

		/// <summary>Discards a resource view from the device context.</summary>
		/// <param name="pResourceView">
		/// <para>Type: <c>ID3D11View*</c></para>
		/// <para>
		/// A pointer to the ID3D11View interface for the resource view to discard. The resource that underlies the view must have been
		/// created with usage D3D11_USAGE_DEFAULT or D3D11_USAGE_DYNAMIC, otherwise the runtime drops the call to <c>DiscardView</c>; if
		/// the debug layer is enabled, the runtime returns an error message.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <c>DiscardView</c> informs the graphics processing unit (GPU) that the existing content in the resource view that
		/// <c>pResourceView</c> points to is no longer needed. The view can be an SRV, RTV, UAV, or DSV. <c>DiscardView</c> is a variation
		/// on the DiscardResource method. <c>DiscardView</c> allows you to discard a subset of a resource that is in a view (such as a
		/// single miplevel). More importantly, <c>DiscardView</c> provides a convenience because often views are what are being bound and
		/// unbound at the pipeline. Some pipeline bindings do not have views, such as stream output. In that situation,
		/// <c>DiscardResource</c> can do the job for any resource.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-discardview void DiscardView( [in]
		// ID3D11View *pResourceView );
		[PreserveSig]
		new void DiscardView([In] ID3D11View pResourceView);

		/// <summary>Sets the constant buffers that the vertex shader pipeline stage uses.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers to set (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers being given to the device.</para>
		/// </param>
		/// <param name="pFirstConstant">
		/// <para>Type: <c>const UINT*</c></para>
		/// <para>
		/// An array that holds the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies where, from the
		/// shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16 bytes (4*32-bit
		/// components). Therefore, an offset of 16 indicates that the start of the associated constant buffer is 256 bytes into the
		/// constant buffer. Each offset must be a multiple of 16 constants.
		/// </para>
		/// </param>
		/// <param name="pNumConstants">
		/// <para>Type: <c>const UINT*</c></para>
		/// <para>
		/// An array that holds the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number specifies the
		/// number of constants that are contained in the constant buffer that the shader uses. Each number of constants starts from its
		/// respective offset that is specified in the <c>pFirstConstant</c> array. Each number of constants must be a multiple of 16
		/// constants, in the range [0..4096].
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The runtime drops the call to <c>VSSetConstantBuffers1</c> if the number of constants to which <c>pNumConstants</c> points is
		/// larger than the maximum constant buffer size that is supported by shaders (4096 constants). The values in the elements of the
		/// <c>pFirstConstant</c> and <c>pFirstConstant</c> + <c>pNumConstants</c> arrays can exceed the length of each buffer; from the
		/// shader's point of view, the constant buffer is the intersection of the actual memory allocation for the buffer and the window
		/// [value in an element of <c>pFirstConstant</c>, value in an element of <c>pFirstConstant</c> + value in an element of
		/// <c>pNumConstants</c>]. The runtime also drops the call to <c>VSSetConstantBuffers1</c> on existing drivers that don't support
		/// this offsetting.
		/// </para>
		/// <para>
		/// The runtime will emulate this feature for feature level 9.1, 9.2, and 9.3; therefore, this feature is supported for feature
		/// level 9.1, 9.2, and 9.3. This feature is always available on new drivers for feature level 10 and higher.
		/// </para>
		/// <para>From the shader’s point of view, element [0] in the constant buffers array is the constant at <c>pFirstConstant</c>.</para>
		/// <para>
		/// Out of bounds access to the constant buffers from the shader to the range that is defined by <c>pFirstConstant</c> and
		/// <c>pNumConstants</c> returns 0.
		/// </para>
		/// <para>
		/// If <c>pFirstConstant</c> and <c>pNumConstants</c> arrays are <c>NULL</c>, you get the same result as if you were binding the
		/// entire buffer into view. You get this same result if you call the VSSetConstantBuffers method. If the buffer is larger than the
		/// maximum constant buffer size that is supported by shaders (4096 elements), the shader can access only the first 4096 constants.
		/// </para>
		/// <para>If either <c>pFirstConstant</c> or <c>pNumConstants</c> is <c>NULL</c>, the other parameter must also be <c>NULL</c>.</para>
		/// <para>Calling VSSetConstantBuffers1 with command list emulation</para>
		/// <para>
		/// The runtime's command list emulation of <c>VSSetConstantBuffers1</c> sometimes doesn't actually change the offsets or sizes for
		/// the arrays of constant buffers. This behavior occurs when
		/// </para>
		/// <para>
		/// <c>VSSetConstantBuffers1</c> doesn't effectively change the constant buffers at the beginning and end of the range of slots that
		/// you set to update. This section shows how to work around this
		/// </para>
		/// <para>behavior.</para>
		/// <para>Here is the code to check whether either the runtime emulates command lists or the driver supports command lists:</para>
		/// <para>If the runtime emulates command lists, you need to use one of these code snippets:</para>
		/// <para>If you change the offset and size on only a single constant buffer, set the constant buffer to <c>NULL</c> first:</para>
		/// <para>If you change multiple constant buffers, set the first and last constant buffers of the range to <c>NULL</c> first:</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-vssetconstantbuffers1 void
		// VSSetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers, [in,
		// optional] const UINT *pFirstConstant, [in, optional] const UINT *pNumConstants );
		[PreserveSig]
		new void VSSetConstantBuffers1(uint StartSlot, [Optional] int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>Sets the constant buffers that the hull-shader stage of the pipeline uses.</summary>
		/// <param name="StartSlot">
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </param>
		/// <param name="NumBuffers">Number of buffers to set (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).</param>
		/// <param name="ppConstantBuffers">Array of constant buffers being given to the device.</param>
		/// <param name="pFirstConstant">
		/// An array that holds the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies where, from the
		/// shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16 bytes (4*32-bit
		/// components). Therefore, an offset of 16 indicates that the start of the associated constant buffer is 256 bytes into the
		/// constant buffer. Each offset must be a multiple of 16 constants.
		/// </param>
		/// <param name="pNumConstants">
		/// An array that holds the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number specifies the
		/// number of constants that are contained in the constant buffer that the shader uses. Each number of constants starts from its
		/// respective offset that is specified in the <c>pFirstConstant</c> array. Each number of constants must be a multiple of 16
		/// constants, in the range [0..4096].
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The runtime drops the call to <c>HSSetConstantBuffers1</c> if the number of constants to which <c>pNumConstants</c> points is
		/// larger than the maximum constant buffer size that is supported by shaders (4096 constants). The values in the elements of the
		/// <c>pFirstConstant</c> and <c>pFirstConstant</c> + <c>pNumConstants</c> arrays can exceed the length of each buffer; from the
		/// shader's point of view, the constant buffer is the intersection of the actual memory allocation for the buffer and the window
		/// [value in an element of <c>pFirstConstant</c>, value in an element of <c>pFirstConstant</c> + value in an element of
		/// <c>pNumConstants</c>]. The runtime also drops the call to <c>HSSetConstantBuffers1</c> on existing drivers that don't support
		/// this offsetting.
		/// </para>
		/// <para>
		/// The runtime will emulate this feature for feature level 9.1, 9.2, and 9.3; therefore, this feature is supported for feature
		/// level 9.1, 9.2, and 9.3. This feature is always available on new drivers for feature level 10 and higher.
		/// </para>
		/// <para>From the shader’s point of view, element [0] in the constant buffers array is the constant at <c>pFirstConstant</c>.</para>
		/// <para>
		/// Out of bounds access to the constant buffers from the shader to the range that is defined by <c>pFirstConstant</c> and
		/// <c>pNumConstants</c> returns 0.
		/// </para>
		/// <para>
		/// If the <c>pFirstConstant</c> and <c>pNumConstants</c> arrays are <c>NULL</c>, you get the same result as if you were binding the
		/// entire buffer into view. You get this same result if you call the HSSetConstantBuffers method. If the buffer is larger than the
		/// maximum constant buffer size that is supported by shaders (4096 elements), the shader can access only the first 4096 constants.
		/// </para>
		/// <para>If either <c>pFirstConstant</c> or <c>pNumConstants</c> is <c>NULL</c>, the other parameter must also be <c>NULL</c>.</para>
		/// <para>Calling HSSetConstantBuffers1 with command list emulation</para>
		/// <para>
		/// The runtime's command list emulation of <c>HSSetConstantBuffers1</c> sometimes doesn't actually change the offsets or sizes for
		/// the arrays of constant buffers. This behavior occurs when
		/// </para>
		/// <para>
		/// <c>HSSetConstantBuffers1</c> doesn't effectively change the constant buffers at the beginning and end of the range of slots that
		/// you set to update. This section shows how to work around this
		/// </para>
		/// <para>behavior.</para>
		/// <para>Here is the code to check whether either the runtime emulates command lists or the driver supports command lists:</para>
		/// <para>If the runtime emulates command lists, you need to use one of these code snippets:</para>
		/// <para>If you change the offset and size on only a single constant buffer, set the constant buffer to <c>NULL</c> first:</para>
		/// <para>If you change multiple constant buffers, set the first and last constant buffers of the range to <c>NULL</c> first:</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-hssetconstantbuffers1 void
		// HSSetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers, [in,
		// optional] const UINT *pFirstConstant, [in, optional] const UINT *pNumConstants );
		[PreserveSig]
		new void HSSetConstantBuffers1(uint StartSlot, [Optional] int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>Sets the constant buffers that the domain-shader stage uses.</summary>
		/// <param name="StartSlot">
		/// Index into the zero-based array to begin setting constant buffers to (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </param>
		/// <param name="NumBuffers">Number of buffers to set (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).</param>
		/// <param name="ppConstantBuffers">Array of constant buffers being given to the device.</param>
		/// <param name="pFirstConstant">
		/// An array that holds the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies where, from the
		/// shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16 bytes (4*32-bit
		/// components). Therefore, an offset of 16 indicates that the start of the associated constant buffer is 256 bytes into the
		/// constant buffer. Each offset must be a multiple of 16 constants.
		/// </param>
		/// <param name="pNumConstants">
		/// An array that holds the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number specifies the
		/// number of constants that are contained in the constant buffer that the shader uses. Each number of constants starts from its
		/// respective offset that is specified in the <c>pFirstConstant</c> array. Each number of constants must be a multiple of 16
		/// constants, in the range [0..4096].
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The runtime drops the call to <c>DSSetConstantBuffers1</c> if the number of constants to which <c>pNumConstants</c> points is
		/// larger than the maximum constant buffer size that is supported by shaders (4096 constants). The values in the elements of the
		/// <c>pFirstConstant</c> and <c>pFirstConstant</c> + <c>pNumConstants</c> arrays can exceed the length of each buffer; from the
		/// shader's point of view, the constant buffer is the intersection of the actual memory allocation for the buffer and the window
		/// [value in an element of <c>pFirstConstant</c>, value in an element of <c>pFirstConstant</c> + value in an element of
		/// <c>pNumConstants</c>]. The runtime also drops the call to <c>DSSetConstantBuffers1</c> on existing drivers that don't support
		/// this offsetting.
		/// </para>
		/// <para>
		/// The runtime will emulate this feature for feature level 9.1, 9.2, and 9.3; therefore, this feature is supported for feature
		/// level 9.1, 9.2, and 9.3. This feature is always available on new drivers for feature level 10 and higher.
		/// </para>
		/// <para>From the shader’s point of view, element [0] in the constant buffers array is the constant at <c>pFirstConstant</c>.</para>
		/// <para>
		/// Out of bounds access to the constant buffers from the shader to the range that is defined by <c>pFirstConstant</c> and
		/// <c>pNumConstants</c> returns 0.
		/// </para>
		/// <para>
		/// If <c>pFirstConstant</c> and <c>pNumConstants</c> arrays are <c>NULL</c>, you get the same result as if you were binding the
		/// entire buffer into view. You get this same result if you call the DSSetConstantBuffers method. If the buffer is larger than the
		/// maximum constant buffer size that is supported by shaders (4096 elements), the shader can access only the first 4096 constants.
		/// </para>
		/// <para>If either <c>pFirstConstant</c> or <c>pNumConstants</c> is <c>NULL</c>, the other parameter must also be <c>NULL</c>.</para>
		/// <para>Calling DSSetConstantBuffers1 with command list emulation</para>
		/// <para>
		/// The runtime's command list emulation of <c>DSSetConstantBuffers1</c> sometimes doesn't actually change the offsets or sizes for
		/// the arrays of constant buffers. This behavior occurs when
		/// </para>
		/// <para>
		/// <c>DSSetConstantBuffers1</c> doesn't effectively change the constant buffers at the beginning and end of the range of slots that
		/// you set to update. This section shows how to work around this
		/// </para>
		/// <para>behavior.</para>
		/// <para>Here is the code to check whether either the runtime emulates command lists or the driver supports command lists:</para>
		/// <para>If the runtime emulates command lists, you need to use one of these code snippets:</para>
		/// <para>If you change the offset and size on only a single constant buffer, set the constant buffer to <c>NULL</c> first:</para>
		/// <para>If you change multiple constant buffers, set the first and last constant buffers of the range to <c>NULL</c> first:</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-dssetconstantbuffers1 void
		// DSSetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers, [in,
		// optional] const UINT *pFirstConstant, [in, optional] const UINT *pNumConstants );
		[PreserveSig]
		new void DSSetConstantBuffers1(uint StartSlot, [Optional] int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>Sets the constant buffers that the geometry shader pipeline stage uses.</summary>
		/// <param name="StartSlot">
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </param>
		/// <param name="NumBuffers">Number of buffers to set (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).</param>
		/// <param name="ppConstantBuffers">Array of constant buffers (see ID3D11Buffer) being given to the device.</param>
		/// <param name="pFirstConstant">
		/// An array that holds the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies where, from the
		/// shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16 bytes (4*32-bit
		/// components). Therefore, an offset of 16 indicates that the start of the associated constant buffer is 256 bytes into the
		/// constant buffer. Each offset must be a multiple of 16 constants.
		/// </param>
		/// <param name="pNumConstants">
		/// An array that holds the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number specifies the
		/// number of constants that are contained in the constant buffer that the shader uses. Each number of constants starts from its
		/// respective offset that is specified in the <c>pFirstConstant</c> array. Each number of constants must be a multiple of 16
		/// constants, in the range [0..4096].
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The runtime drops the call to <c>GSSetConstantBuffers1</c> if the number of constants to which <c>pNumConstants</c> points is
		/// larger than the maximum constant buffer size that is supported by shaders (4096 constants). The values in the elements of the
		/// <c>pFirstConstant</c> and <c>pFirstConstant</c> + <c>pNumConstants</c> arrays can exceed the length of each buffer; from the
		/// shader's point of view, the constant buffer is the intersection of the actual memory allocation for the buffer and the window
		/// [value in an element of <c>pFirstConstant</c>, value in an element of <c>pFirstConstant</c> + value in an element of
		/// <c>pNumConstants</c>]. The runtime also drops the call to <c>GSSetConstantBuffers1</c> on existing drivers that don't support
		/// this offsetting.
		/// </para>
		/// <para>
		/// The runtime will emulate this feature for feature level 9.1, 9.2, and 9.3; therefore, this feature is supported for feature
		/// level 9.1, 9.2, and 9.3. This feature is always available on new drivers for feature level 10 and higher.
		/// </para>
		/// <para>From the shader’s point of view, element [0] in the constant buffers array is the constant at <c>pFirstConstant</c>.</para>
		/// <para>
		/// Out of bounds access to the constant buffers from the shader to the range that is defined by <c>pFirstConstant</c> and
		/// <c>pNumConstants</c> returns 0.
		/// </para>
		/// <para>
		/// If <c>pFirstConstant</c> and <c>pNumConstants</c> arrays are <c>NULL</c>, you get the same result as if you were binding the
		/// entire buffer into view. You get this same result if you call the GSSetConstantBuffers method. If the buffer is larger than the
		/// maximum constant buffer size that is supported by shaders (4096 elements), the shader can access only the first 4096 constants.
		/// </para>
		/// <para>If either <c>pFirstConstant</c> or <c>pNumConstants</c> is <c>NULL</c>, the other parameter must also be <c>NULL</c>.</para>
		/// <para>Calling GSSetConstantBuffers1 with command list emulation</para>
		/// <para>
		/// The runtime's command list emulation of <c>GSSetConstantBuffers1</c> sometimes doesn't actually change the offsets or sizes for
		/// the arrays of constant buffers. This behavior occurs when
		/// </para>
		/// <para>
		/// <c>GSSetConstantBuffers1</c> doesn't effectively change the constant buffers at the beginning and end of the range of slots that
		/// you set to update. This section shows how to work around this
		/// </para>
		/// <para>behavior.</para>
		/// <para>Here is the code to check whether either the runtime emulates command lists or the driver supports command lists:</para>
		/// <para>If the runtime emulates command lists, you need to use one of these code snippets:</para>
		/// <para>If you change the offset and size on only a single constant buffer, set the constant buffer to <c>NULL</c> first:</para>
		/// <para>If you change multiple constant buffers, set the first and last constant buffers of the range to <c>NULL</c> first:</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-gssetconstantbuffers1 void
		// GSSetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers, [in,
		// optional] const UINT *pFirstConstant, [in, optional] const UINT *pNumConstants );
		[PreserveSig]
		new void GSSetConstantBuffers1(uint StartSlot, [Optional] int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>
		/// Sets the constant buffers that the pixel shader pipeline stage uses, and enables the shader to access other parts of the buffer.
		/// </summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers to set (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers being given to the device.</para>
		/// </param>
		/// <param name="pFirstConstant">
		/// <para>Type: <c>const UINT*</c></para>
		/// <para>
		/// An array that holds the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies where, from the
		/// shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16 bytes (4*32-bit
		/// components). Therefore, an offset of 16 indicates that the start of the associated constant buffer is 256 bytes into the
		/// constant buffer. Each offset must be a multiple of 16 constants.
		/// </para>
		/// </param>
		/// <param name="pNumConstants">
		/// <para>Type: <c>const UINT*</c></para>
		/// <para>
		/// An array that holds the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number specifies the
		/// number of constants that are contained in the constant buffer that the shader uses. Each number of constants starts from its
		/// respective offset that is specified in the <c>pFirstConstant</c> array. Each number of constants must be a multiple of 16
		/// constants, in the range [0..4096].
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To enable the shader to access other parts of the buffer, call <c>PSSetConstantBuffers1</c> instead of PSSetConstantBuffers.
		/// <c>PSSetConstantBuffers1</c> has additional parameters <c>pFirstConstant</c> and <c>pNumConstants</c>.
		/// </para>
		/// <para>
		/// The runtime drops the call to <c>PSSetConstantBuffers1</c> if the numbers of constants to which <c>pNumConstants</c> points is
		/// larger than the maximum constant buffer size that is supported by shaders. The maximum constant buffer size that is supported by
		/// shaders holds 4096 constants, where each constant has four 32-bit components.
		/// </para>
		/// <para>
		/// The values in the elements of the <c>pFirstConstant</c> and <c>pFirstConstant</c> + <c>pNumConstants</c> arrays can exceed the
		/// length of each buffer; from the shader's point of view, the constant buffer is the intersection of the actual memory allocation
		/// for the buffer and the following window (range):
		/// </para>
		/// <para>[value in an element of <c>pFirstConstant</c>, value in an element of <c>pFirstConstant</c> + value in an element of <c>pNumConstants</c>]</para>
		/// <para>
		/// That is, the window is the range is from (value in an element of <c>pFirstConstant</c>) to (value in an element of
		/// <c>pFirstConstant</c> + value in an element of <c>pNumConstants</c>).
		/// </para>
		/// <para>The runtime also drops the call to <c>PSSetConstantBuffers1</c> on existing drivers that do not support this offsetting.</para>
		/// <para>
		/// The runtime will emulate this feature for feature level 9.1, 9.2, and 9.3; therefore, this feature is supported for feature
		/// level 9.1, 9.2, and 9.3. This feature is always available on new drivers for feature level 10 and higher.
		/// </para>
		/// <para>From the shader’s point of view, element [0] in the constant buffers array is the constant at <c>pFirstConstant</c>.</para>
		/// <para>
		/// Out of bounds access to the constant buffers from the shader to the range that is defined by <c>pFirstConstant</c> and
		/// <c>pNumConstants</c> returns 0.
		/// </para>
		/// <para>
		/// If <c>pFirstConstant</c> and <c>pNumConstants</c> arrays are <c>NULL</c>, you get the same result as if you were binding the
		/// entire buffer into view. You get this same result if you call the PSSetConstantBuffers method. If the buffer is larger than the
		/// maximum constant buffer size that is supported by shaders (4096 elements), the shader can access only the first 4096 constants.
		/// </para>
		/// <para>If either <c>pFirstConstant</c> or <c>pNumConstants</c> is <c>NULL</c>, the other parameter must also be <c>NULL</c>.</para>
		/// <para>Calling PSSetConstantBuffers1 with command list emulation</para>
		/// <para>
		/// The runtime's command list emulation of <c>PSSetConstantBuffers1</c> sometimes doesn't actually change the offsets or sizes for
		/// the arrays of constant buffers. This behavior occurs when <c>PSSetConstantBuffers1</c> doesn't effectively change the constant
		/// buffers at the beginning and end of the range of slots that you set to update. This section shows how to work around this behavior.
		/// </para>
		/// <para>Here is the code to check whether either the runtime emulates command lists or the driver supports command lists:</para>
		/// <para>If the runtime emulates command lists, you need to use one of these code snippets:</para>
		/// <para>If you change the offset and size on only a single constant buffer, set the constant buffer to <c>NULL</c> first:</para>
		/// <para>If you change multiple constant buffers, set the first and last constant buffers of the range to <c>NULL</c> first:</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-pssetconstantbuffers1 void
		// PSSetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers, [in,
		// optional] const UINT *pFirstConstant, [in, optional] const UINT *pNumConstants );
		[PreserveSig]
		new void PSSetConstantBuffers1(uint StartSlot, [Optional] int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>Sets the constant buffers that the compute-shader stage uses.</summary>
		/// <param name="StartSlot">
		/// Index into the zero-based array to begin setting constant buffers to (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </param>
		/// <param name="NumBuffers">Number of buffers to set (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).</param>
		/// <param name="ppConstantBuffers">Array of constant buffers (see ID3D11Buffer) being given to the device.</param>
		/// <param name="pFirstConstant">
		/// An array that holds the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies where, from the
		/// shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16 bytes (4*32-bit
		/// components). Therefore, an offset of 16 indicates that the start of the associated constant buffer is 256 bytes into the
		/// constant buffer. Each offset must be a multiple of 16 constants.
		/// </param>
		/// <param name="pNumConstants">
		/// An array that holds the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number specifies the
		/// number of constants that are contained in the constant buffer that the shader uses. Each number of constants starts from its
		/// respective offset that is specified in the <c>pFirstConstant</c> array. Each number of constants must be a multiple of 16
		/// constants, in the range [0..4096].
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The runtime drops the call to <c>CSSetConstantBuffers1</c> if the number of constants to which <c>pNumConstants</c> points is
		/// larger than the maximum constant buffer size that is supported by shaders (4096 constants). The values in the elements of the
		/// <c>pFirstConstant</c> and <c>pFirstConstant</c> + <c>pNumConstants</c> arrays can exceed the length of each buffer; from the
		/// shader's point of view, the constant buffer is the intersection of the actual memory allocation for the buffer and the window
		/// [value in an element of <c>pFirstConstant</c>, value in an element of <c>pFirstConstant</c> + value in an element of
		/// <c>pNumConstants</c>]. The runtime also drops the call to <c>CSSetConstantBuffers1</c> on existing drivers that don't support
		/// this offsetting.
		/// </para>
		/// <para>
		/// The runtime will emulate this feature for feature level 9.1, 9.2, and 9.3; therefore, this feature is supported for feature
		/// level 9.1, 9.2, and 9.3. This feature is always available on new drivers for feature level 10 and higher.
		/// </para>
		/// <para>From the shader’s point of view, element [0] in the constant buffers array is the constant at <c>pFirstConstant</c>.</para>
		/// <para>
		/// Out of bounds access to the constant buffers from the shader to the range that is defined by <c>pFirstConstant</c> and
		/// <c>pNumConstants</c> returns 0.
		/// </para>
		/// <para>
		/// If <c>pFirstConstant</c> and <c>pNumConstants</c> arrays are <c>NULL</c>, you get the same result as if you were binding the
		/// entire buffer into view. You get this same result if you call the CSSetConstantBuffers method. If the buffer is larger than the
		/// maximum constant buffer size that is supported by shaders (4096 elements), the shader can access only the first 4096 constants.
		/// </para>
		/// <para>If either <c>pFirstConstant</c> or <c>pNumConstants</c> is <c>NULL</c>, the other parameter must also be <c>NULL</c>.</para>
		/// <para>Calling CSSetConstantBuffers1 with command list emulation</para>
		/// <para>
		/// The runtime's command list emulation of <c>CSSetConstantBuffers1</c> sometimes doesn't actually change the offsets or sizes for
		/// the arrays of constant buffers. This behavior occurs when
		/// </para>
		/// <para>
		/// <c>CSSetConstantBuffers1</c> doesn't effectively change the constant buffers at the beginning and end of the range of slots that
		/// you set to update. This section shows how to work around this
		/// </para>
		/// <para>behavior.</para>
		/// <para>Here is the code to check whether either the runtime emulates command lists or the driver supports command lists:</para>
		/// <para>If the runtime emulates command lists, you need to use one of these code snippets:</para>
		/// <para>If you change the offset and size on only a single constant buffer, set the constant buffer to <c>NULL</c> first:</para>
		/// <para>If you change multiple constant buffers, set the first and last constant buffers of the range to <c>NULL</c> first:</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-cssetconstantbuffers1 void
		// CSSetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers, [in,
		// optional] const UINT *pFirstConstant, [in, optional] const UINT *pNumConstants );
		[PreserveSig]
		new void CSSetConstantBuffers1(uint StartSlot, [Optional] int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>Gets the constant buffers that the vertex shader pipeline stage uses.</summary>
		/// <param name="StartSlot">
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </param>
		/// <param name="NumBuffers">
		/// Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).
		/// </param>
		/// <param name="ppConstantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
		/// <param name="pFirstConstant">
		/// A pointer to an array that receives the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies
		/// where, from the shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16
		/// bytes (4*32-bit components). Therefore, an offset of 2 indicates that the start of the associated constant buffer is 32 bytes
		/// into the constant buffer. The runtime sets <c>pFirstConstant</c> to <c>NULL</c> if the buffers do not have offsets.
		/// </param>
		/// <param name="pNumConstants">
		/// A pointer to an array that receives the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number
		/// specifies the number of constants that are contained in the constant buffer that the shader uses. Each number of constants
		/// starts from its respective offset that is specified in the <c>pFirstConstant</c> array. The runtime sets <c>pNumConstants</c> to
		/// <c>NULL</c> if it doesn't specify the numbers of constants in each buffer.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If no buffer is bound at a slot, <c>pFirstConstant</c> and <c>pNumConstants</c> are <c>NULL</c> for that slot.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-vsgetconstantbuffers1 void
		// VSGetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers, [out,
		// optional] UINT *pFirstConstant, [out, optional] UINT *pNumConstants );
		[PreserveSig]
		new void VSGetConstantBuffers1(uint StartSlot, int NumBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>Gets the constant buffers that the hull-shader stage uses.</summary>
		/// <param name="StartSlot">
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </param>
		/// <param name="NumBuffers">
		/// Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).
		/// </param>
		/// <param name="ppConstantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
		/// <param name="pFirstConstant">
		/// A pointer to an array that receives the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies
		/// where, from the shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16
		/// bytes (4*32-bit components). Therefore, an offset of 2 indicates that the start of the associated constant buffer is 32 bytes
		/// into the constant buffer. The runtime sets <c>pFirstConstant</c> to <c>NULL</c> if the buffers do not have offsets.
		/// </param>
		/// <param name="pNumConstants">
		/// A pointer to an array that receives the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number
		/// specifies the number of constants that are contained in the constant buffer that the shader uses. Each number of constants
		/// starts from its respective offset that is specified in the <c>pFirstConstant</c> array. The runtime sets <c>pNumConstants</c> to
		/// <c>NULL</c> if it doesn't specify the numbers of constants in each buffer.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If no buffer is bound at a slot, <c>pFirstConstant</c> and <c>pNumConstants</c> are <c>NULL</c> for that slot.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-hsgetconstantbuffers1 void
		// HSGetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers, [out,
		// optional] UINT *pFirstConstant, [out, optional] UINT *pNumConstants );
		[PreserveSig]
		new void HSGetConstantBuffers1(uint StartSlot, int NumBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>Gets the constant buffers that the domain-shader stage uses.</summary>
		/// <param name="StartSlot">
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </param>
		/// <param name="NumBuffers">
		/// Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).
		/// </param>
		/// <param name="ppConstantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
		/// <param name="pFirstConstant">
		/// A pointer to an array that receives the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies
		/// where, from the shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16
		/// bytes (4*32-bit components). Therefore, an offset of 2 indicates that the start of the associated constant buffer is 32 bytes
		/// into the constant buffer. The runtime sets <c>pFirstConstant</c> to <c>NULL</c> if the buffers do not have offsets.
		/// </param>
		/// <param name="pNumConstants">
		/// A pointer to an array that receives the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number
		/// specifies the number of constants that are contained in the constant buffer that the shader uses. Each number of constants
		/// starts from its respective offset that is specified in the <c>pFirstConstant</c> array. The runtime sets <c>pNumConstants</c> to
		/// <c>NULL</c> if it doesn't specify the numbers of constants in each buffer.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If no buffer is bound at a slot, <c>pFirstConstant</c> and <c>pNumConstants</c> are <c>NULL</c> for that slot.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-dsgetconstantbuffers1 void
		// DSGetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers, [out,
		// optional] UINT *pFirstConstant, [out, optional] UINT *pNumConstants );
		[PreserveSig]
		new void DSGetConstantBuffers1(uint StartSlot, int NumBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>Gets the constant buffers that the geometry shader pipeline stage uses.</summary>
		/// <param name="StartSlot">
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </param>
		/// <param name="NumBuffers">
		/// Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).
		/// </param>
		/// <param name="ppConstantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
		/// <param name="pFirstConstant">
		/// A pointer to an array that receives the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies
		/// where, from the shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16
		/// bytes (4*32-bit components). Therefore, an offset of 2 indicates that the start of the associated constant buffer is 32 bytes
		/// into the constant buffer. The runtime sets <c>pFirstConstant</c> to <c>NULL</c> if the buffers do not have offsets.
		/// </param>
		/// <param name="pNumConstants">
		/// A pointer to an array that receives the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number
		/// specifies the number of constants that are contained in the constant buffer that the shader uses. Each number of constants
		/// starts from its respective offset that is specified in the <c>pFirstConstant</c> array. The runtime sets <c>pNumConstants</c> to
		/// <c>NULL</c> if it doesn't specify the numbers of constants in each buffer.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If no buffer is bound at a slot, <c>pFirstConstant</c> and <c>pNumConstants</c> are <c>NULL</c> for that slot.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-gsgetconstantbuffers1 void
		// GSGetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers, [out,
		// optional] UINT *pFirstConstant, [out, optional] UINT *pNumConstants );
		[PreserveSig]
		new void GSGetConstantBuffers1(uint StartSlot, int NumBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>Gets the constant buffers that the pixel shader pipeline stage uses.</summary>
		/// <param name="StartSlot">
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </param>
		/// <param name="NumBuffers">
		/// Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).
		/// </param>
		/// <param name="ppConstantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
		/// <param name="pFirstConstant">
		/// A pointer to an array that receives the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies
		/// where, from the shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16
		/// bytes (4*32-bit components). Therefore, an offset of 2 indicates that the start of the associated constant buffer is 32 bytes
		/// into the constant buffer. The runtime sets <c>pFirstConstant</c> to <c>NULL</c> if the buffers do not have offsets.
		/// </param>
		/// <param name="pNumConstants">
		/// A pointer to an array that receives the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number
		/// specifies the number of constants that are contained in the constant buffer that the shader uses. Each number of constants
		/// starts from its respective offset that is specified in the <c>pFirstConstant</c> array. The runtime sets <c>pNumConstants</c> to
		/// <c>NULL</c> if it doesn't specify the numbers of constants in each buffer.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If no buffer is bound at a slot, <c>pFirstConstant</c> and <c>pNumConstants</c> are <c>NULL</c> for that slot.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-psgetconstantbuffers1 void
		// PSGetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers, [out,
		// optional] UINT *pFirstConstant, [out, optional] UINT *pNumConstants );
		[PreserveSig]
		new void PSGetConstantBuffers1(uint StartSlot, int NumBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>Gets the constant buffers that the compute-shader stage uses.</summary>
		/// <param name="StartSlot">
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </param>
		/// <param name="NumBuffers">
		/// Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - <c>StartSlot</c>).
		/// </param>
		/// <param name="ppConstantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
		/// <param name="pFirstConstant">
		/// A pointer to an array that receives the offsets into the buffers that <c>ppConstantBuffers</c> specifies. Each offset specifies
		/// where, from the shader's point of view, each constant buffer starts. Each offset is measured in shader constants, which are 16
		/// bytes (4*32-bit components). Therefore, an offset of 2 indicates that the start of the associated constant buffer is 32 bytes
		/// into the constant buffer. The runtime sets <c>pFirstConstant</c> to <c>NULL</c> if the buffers do not have offsets.
		/// </param>
		/// <param name="pNumConstants">
		/// A pointer to an array that receives the numbers of constants in the buffers that <c>ppConstantBuffers</c> specifies. Each number
		/// specifies the number of constants that are contained in the constant buffer that the shader uses. Each number of constants
		/// starts from its respective offset that is specified in the <c>pFirstConstant</c> array. The runtime sets <c>pNumConstants</c> to
		/// <c>NULL</c> if it doesn't specify the numbers of constants in each buffer.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If no buffer is bound at a slot, <c>pFirstConstant</c> and <c>pNumConstants</c> are <c>NULL</c> for that slot.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-csgetconstantbuffers1 void
		// CSGetConstantBuffers1( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers, [out,
		// optional] UINT *pFirstConstant, [out, optional] UINT *pNumConstants );
		[PreserveSig]
		new void CSGetConstantBuffers1(uint StartSlot, int NumBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pFirstConstant,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pNumConstants);

		/// <summary>
		/// Activates the given context state object and changes the current device behavior to Direct3D 11, Direct3D 10.1, or Direct3D 10.
		/// </summary>
		/// <param name="pState">
		/// A pointer to the ID3DDeviceContextState interface for the context state object that was previously created through the
		/// ID3D11Device1::CreateDeviceContextState method. If <c>SwapDeviceContextState</c> is called with <c>pState</c> set to
		/// <c>NULL</c>, the call has no effect.
		/// </param>
		/// <param name="ppPreviousState">
		/// A pointer to a variable that receives a pointer to the ID3DDeviceContextState interface for the previously-activated context
		/// state object.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <c>SwapDeviceContextState</c> changes device behavior. This device behavior depends on the emulated interface that you passed to
		/// the <c>EmulatedInterface</c> parameter of the ID3D11Device1::CreateDeviceContextState method when you created the context state object.
		/// </para>
		/// <para><c>SwapDeviceContextState</c> is not supported on a deferred context.</para>
		/// <para>
		/// <c>SwapDeviceContextState</c> disables the incompatible device interfaces ID3D10Device, ID3D10Device1, ID3D11Device, and
		/// ID3D11Device1. When a context state object is active, the runtime disables certain methods on the device and context interfaces.
		/// A context state object that is created with or turns off most of the Direct3D 10 device interfaces. A context state object that
		/// is created with or turns off most of the ID3D11DeviceContext methods. For more information about this behavior, see ID3D11Device1::CreateDeviceContextState.
		/// </para>
		/// <para>
		/// <c>SwapDeviceContextState</c> activates the context state object specified by <c>pState</c>. This means that the device
		/// behaviors that are associated with the context state object's feature level and compatible interface are activated on the
		/// Direct3D device until the next call to <c>SwapDeviceContextState</c>. In addition, any state that was saved when this context
		/// state object was last active is now reactivated, so that the previous state is replaced.
		/// </para>
		/// <para>
		/// <c>SwapDeviceContextState</c> sets <c>ppPreviousState</c> to the most recently activated context state object. The object allows
		/// the caller to save and then later restore the previous device state. This behavior is useful in a plug-in architecture such as
		/// Direct2D that shares a Direct3D device with its plug-ins. A Direct2D interface can use context state objects to save and restore
		/// the application's state.
		/// </para>
		/// <para>
		/// If the caller did not previously call the ID3D11Device1::CreateDeviceContextState method to create a previous context state
		/// object, <c>SwapDeviceContextState</c> sets <c>ppPreviousState</c> to the default context state object. In either case, usage of
		/// <c>SwapDeviceContextState</c> is the same.
		/// </para>
		/// <para>
		/// The feature level that is specified by the application, and that is chosen by the context state object from the acceptable list
		/// that the application supplies to ID3D11Device1::CreateDeviceContextState, controls the feature level of the immediate context
		/// whenever the context state object is active. Because the Direct3D 11 device is free-threaded, the device methods cannot query
		/// the current immediate context feature level. Instead, the device runs at a feature level that is the maximum of all previously
		/// created context state objects' feature levels. This means that the device's feature level can increase dynamically.
		/// </para>
		/// <para>
		/// The feature level of the context state object controls the functionality available from the immediate context. However, to
		/// maintain the free-threaded contract of the Direct3D 11 device methods—the resource-creation methods in particular—the
		/// upper-bound feature level of all created context state objects controls the set of resources that the device creates.
		/// </para>
		/// <para>
		/// Because the context state object interface is published by the immediate context, the interface requires the same threading
		/// model as the immediate context. Specifically, <c>SwapDeviceContextState</c> is single-threaded with respect to the other
		/// immediate context methods and with respect to the equivalent methods of ID3D10Device.
		/// </para>
		/// <para>
		/// Crucially, because only one of the Direct3D 10 or Direct3D 11 ref-count behaviors can be available at a time, one of the
		/// Direct3D 10 and Direct3D 11 interfaces must break its ref-count contract. To avoid this situation, the activation of a context
		/// state object turns off the incompatible version interface. Also, if you call a method of an incompatible version interface, the
		/// call silently fails if the method has return type <c>void</c>, returns an <c>HRESULT</c> value of <c>E_INVALIDARG</c>, or sets
		/// any out parameter to <c>NULL</c>.
		/// </para>
		/// <para>
		/// When you switch from Direct3D 11 mode to either Direct3D 10 mode or Direct3D 10.1 mode, the binding behavior of the device
		/// changes. Specifically, the final release of a resource induces unbind in Direct3D 10 mode or Direct3D 10.1 mode. During final
		/// release an application releases all of the resource's references, including indirect references such as the linkage from view to
		/// resource, and the linkage from context state object to any of the context state object's bound resources. Any bound resource to
		/// which the application has no reference is unbound and destroyed, in order to maintain the Direct3D 10 behavior.
		/// </para>
		/// <para><c>SwapDeviceContextState</c> does not affect any state that ID3D11VideoContext sets.</para>
		/// <para>
		/// Command lists that are generated by deferred contexts do not hold a reference to context state objects and are not affected by
		/// future updates to context state objects.
		/// </para>
		/// <para>
		/// No asynchronous objects are affected by <c>SwapDeviceContextState</c>. For example, if a query is active before a call to
		/// <c>SwapDeviceContextState</c>, it is still active after the call.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-swapdevicecontextstate void
		// SwapDeviceContextState( [in] ID3DDeviceContextState *pState, [out, optional] ID3DDeviceContextState **ppPreviousState );
		[PreserveSig]
		new void SwapDeviceContextState([In] ID3DDeviceContextState pState, [Out, Optional] IntPtr ppPreviousState);

		/// <summary>Sets all the elements in a resource view to one value.</summary>
		/// <param name="pView">A pointer to the ID3D11View interface that represents the resource view to clear.</param>
		/// <param name="Color">A 4-component array that represents the color to use to clear the resource view.</param>
		/// <param name="pRect">
		/// An array of D3D11_RECT structures for the rectangles in the resource view to clear. If <c>NULL</c>, <c>ClearView</c> clears the
		/// entire surface.
		/// </param>
		/// <param name="NumRects">Number of rectangles in the array that the <c>pRect</c> parameter specifies.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <c>ClearView</c> works only on render-target views (RTVs), depth/stencil views (DSVs) on depth-only resources (resources with no
		/// stencil component), unordered-access views (UAVs), or any video view of a Texture2D surface. The runtime drops invalid calls.
		/// Empty rectangles in the <c>pRect</c> array are a no-op. A rectangle is empty if the top value equals the bottom value or the
		/// left value equals the right value.
		/// </para>
		/// <para><c>ClearView</c> doesn’t support 3D textures.</para>
		/// <para>
		/// <c>ClearView</c> applies the same color value to all array slices in a view; all rectangles in the <c>pRect</c> array correspond
		/// to each array slice. The <c>pRect</c> array of rectangles is a set of areas to clear on a single surface. If the view is an
		/// array, <c>ClearView</c> clears all the rectangles on each array slice individually.
		/// </para>
		/// <para>
		/// When you apply rectangles to buffers, set the top value to 0 and the bottom value to 1 and set the left value and right value to
		/// describe the extent within the buffer. When the top value equals the bottom value or the left value equals the right value, the
		/// rectangle is empty and a no-op is achieved.
		/// </para>
		/// <para>
		/// The driver converts and clamps color values to the destination format as appropriate per Direct3D conversion rules. For example,
		/// if the format of the view is DXGI_FORMAT_R8G8B8A8_UNORM, the driver clamps inputs to 0.0f to 1.0f (+INF -&gt; 1.0f (0XFF)/NaN
		/// -&gt; 0.0f).
		/// </para>
		/// <para>
		/// If the format is integer, such as DXGI_FORMAT_R8G8B8A8_UINT, the runtime interprets inputs as integral floats. Therefore, 235.0f
		/// maps to 235 (rounds to zero, out of range/INF values clamp to target range, and NaN to 0).
		/// </para>
		/// <para>Here are the color mappings:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Color[0]: R (or Y for video)</description>
		/// </item>
		/// <item>
		/// <description>Color[1]: G (or U/Cb for video)</description>
		/// </item>
		/// <item>
		/// <description>Color[2]: B (or V/Cr for video)</description>
		/// </item>
		/// <item>
		/// <description>Color[3]: A</description>
		/// </item>
		/// </list>
		/// <para>
		/// For video views with YUV or YCbBr formats, <c>ClearView</c> doesn't convert color values. In situations where the format name
		/// doesn’t indicate _UNORM, _UINT, and so on, <c>ClearView</c> assumes _UINT. Therefore, 235.0f maps to 235 (rounds to zero, out of
		/// range/INF values clamp to target range, and NaN to 0).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-clearview void ClearView( [in]
		// ID3D11View *pView, [in] const FLOAT [4] Color, [in, optional] const D3D11_RECT *pRect, UINT NumRects );
		[PreserveSig]
		new void ClearView([In] ID3D11View pView, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] Color,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] RECT[]? pRect, int NumRects);

		/// <summary>Discards the specified elements in a resource view from the device context.</summary>
		/// <param name="pResourceView">
		/// <para>Type: <c>ID3D11View*</c></para>
		/// <para>
		/// A pointer to the ID3D11View interface for the resource view to discard. The resource that underlies the view must have been
		/// created with usage D3D11_USAGE_DEFAULT or D3D11_USAGE_DYNAMIC, otherwise the runtime drops the call to <c>DiscardView1</c>; if
		/// the debug layer is enabled, the runtime returns an error message.
		/// </para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <c>const D3D11_RECT*</c></para>
		/// <para>
		/// An array of D3D11_RECT structures for the rectangles in the resource view to discard. If <c>NULL</c>, <c>DiscardView1</c>
		/// discards the entire view and behaves the same as DiscardView.
		/// </para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of rectangles in the array that the <c>pRects</c> parameter specifies.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <c>DiscardView1</c> informs the graphics processing unit (GPU) that the existing content in the specified elements in the
		/// resource view that <c>pResourceView</c> points to is no longer needed. The view can be an SRV, RTV, UAV, or DSV.
		/// <c>DiscardView1</c> is a variation on the DiscardResource method. <c>DiscardView1</c> allows you to discard elements of a subset
		/// of a resource that is in a view (such as elements of a single miplevel). More importantly, <c>DiscardView1</c> provides a
		/// convenience because often views are what are being bound and unbound at the pipeline. Some pipeline bindings do not have views,
		/// such as stream output. In that situation, <c>DiscardResource</c> can do the job for any resource.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11devicecontext1-discardview1 void DiscardView1( [in]
		// ID3D11View *pResourceView, [in, optional] const D3D11_RECT *pRects, UINT NumRects );
		[PreserveSig]
		new void DiscardView1([In] ID3D11View pResourceView, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[]? pRects, int NumRects);

		/// <summary>Updates mappings of tile locations in tiled resources to memory locations in a tile pool.</summary>
		/// <param name="pTiledResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the tiled resource.</para>
		/// </param>
		/// <param name="NumTiledResourceRegions">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of tiled resource regions.</para>
		/// </param>
		/// <param name="pTiledResourceRegionStartCoordinates">
		/// <para>Type: <c>const D3D11_TILED_RESOURCE_COORDINATE*</c></para>
		/// <para>
		/// An array of D3D11_TILED_RESOURCE_COORDINATE structures that describe the starting coordinates of the tiled resource regions. The
		/// <c>NumTiledResourceRegions</c> parameter specifies the number of <c>D3D11_TILED_RESOURCE_COORDINATE</c> structures in the array.
		/// </para>
		/// </param>
		/// <param name="pTiledResourceRegionSizes">
		/// <para>Type: <c>const D3D11_TILE_REGION_SIZE*</c></para>
		/// <para>
		/// An array of D3D11_TILE_REGION_SIZE structures that describe the sizes of the tiled resource regions. The
		/// <c>NumTiledResourceRegions</c> parameter specifies the number of <c>D3D11_TILE_REGION_SIZE</c> structures in the array.
		/// </para>
		/// </param>
		/// <param name="pTilePool">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>A pointer to the tile pool.</para>
		/// </param>
		/// <param name="NumRanges">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of tile-pool ranges.</para>
		/// </param>
		/// <param name="pRangeFlags">
		/// <para>Type: <c>const UINT*</c></para>
		/// <para>
		/// An array of D3D11_TILE_RANGE_FLAG values that describe each tile-pool range. The <c>NumRanges</c> parameter specifies the number
		/// of values in the array.
		/// </para>
		/// </param>
		/// <param name="pTilePoolStartOffsets">
		/// <para>Type: <c>const UINT*</c></para>
		/// <para>An array of offsets into the tile pool. These are 0-based tile offsets, counting in tiles (not bytes).</para>
		/// </param>
		/// <param name="pRangeTileCounts">
		/// <para>Type: <c>const UINT*</c></para>
		/// <para>An array of tiles.</para>
		/// <para>
		/// An array of values that specify the number of tiles in each tile-pool range. The <c>NumRanges</c> parameter specifies the number
		/// of values in the array.
		/// </para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A combination of D3D11_TILE_MAPPING_FLAGS values that are combined by using a bitwise OR operation.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Returns <c>E_INVALIDARG</c> if various conditions such as invalid flags result in the call being dropped.The debug layer will
		/// emit an error.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns <c>E_OUTOFMEMORY</c> if the call results in the driver having to allocate space for new page table mappings but running
		/// out of memory.If out of memory occurs when this is called in a commandlist and the commandlist is being executed, the device
		/// will be removed. Apps can avoid this situation by only doing update calls that change existing mappings from tiled resources
		/// within commandlists (so drivers will not have to allocate page table memory, only change the mapping).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns <c>DXGI_ERROR_DEVICE_REMOVED</c> if the video card has been physically removed from the system, or a driver upgrade for
		/// the video card has occurred.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In a single call to <c>UpdateTileMappings</c>, you can map one or more ranges of resource tiles to one or more ranges of
		/// tile-pool tiles.
		/// </para>
		/// <para>You can organize the parameters of <c>UpdateTileMappings</c> in these ways to perform an update:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <c>Tiled resource whose mappings are updated.</c> This is a resource that was created with the D3D11_RESOURCE_MISC_TILED flag.
		/// Mappings start off all NULL when a resource is initially created.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>Set of tile regions on the tiled resource whose mappings are updated.</c> You can make one <c>UpdateTileMappings</c> call to
		/// update many mappings or multiple calls with a bit more API call overhead as well if that is more convenient.
		/// <c>NumTiledResourceRegions</c> specifies how many regions there are, <c>pTiledResourceRegionStartCoordinates</c> and
		/// <c>pTiledResourceRegionSizes</c> are each arrays that identify the start location and extend of each region. If
		/// <c>NumTiledResourceRegions</c> is 1, for convenience either or both of the arrays that describe the regions can be NULL. NULL
		/// for <c>pTiledResourceRegionStartCoordinates</c> means the start coordinate is all 0s, and NULL for
		/// <c>pTiledResourceRegionSizes</c> identifies a default region that is the full set of tiles for the entire tiled resource,
		/// including all mipmaps, array slices, or both. If <c>pTiledResourceRegionStartCoordinates</c> isn't NULL and
		/// <c>pTiledResourceRegionSizes</c> is NULL, the region size defaults to 1 tile for all regions. This makes it easy to define
		/// mappings for a set of individual tiles each at disparate locations by providing an array of locations in
		/// <c>pTiledResourceRegionStartCoordinates</c> without having to send an array of <c>pTiledResourceRegionSizes</c> all set to 1.
		/// <para>
		/// The updates are applied from first region to last; so, if regions overlap in a single call, the updates later in the list
		/// overwrite the areas that overlap with previous updates.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>Tile pool that provides memory where tile mappings can go.</c> A tiled resource can point to a single tile pool at a time. If
		/// a new tile pool is specified (for the first time or different from the last time a tile pool was specified), all existing tile
		/// mappings for the tiled resource are cleared and the new set of mappings in the current <c>UpdateTileMappings</c> call are
		/// applied for the new tile pool. If no tile pool is specified (NULL) or the same tile pool as a previous <c>UpdateTileMappings</c>
		/// call is provided, the <c>UpdateTileMappings</c> call just adds the new mappings to existing ones (overwriting on overlap). If
		/// <c>UpdateTileMappings</c> only defines NULL mappings, you don't need to specify a tile pool because it is irrelevant. But if you
		/// specify a tile pool anyway, it takes the same behavior as previously described when providing a tile pool.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>Set of tile ranges where mappings are going.</c> Each given tile range can specify one of a few types of ranges: a range of
		/// tiles in a tile pool (default), a count of tiles in the tiled resource to map to a single tile in a tile pool (sharing the
		/// tile), a count of tile mappings in the tiled resource to skip and leave as they are, or a count of tiles in the tile pool to map
		/// to NULL. <c>NumRanges</c> specifies the number of tile ranges, where the total tiles identified across all ranges must match the
		/// total number of tiles in the tile regions from the previously described tiled resource. Mappings are defined by iterating
		/// through the tiles in the tile regions in sequential order - x then y then z order for box regions - while walking through the
		/// set of tile ranges in sequential order. The breakdown of tile regions doesn't have to line up with the breakdown of tile ranges,
		/// but the total number of tiles on both sides must be equal so that each tiled resource tile specified has a mapping specified.
		/// <para>
		/// <c>pRangeFlags</c>, <c>pTilePoolStartOffsets</c>, and <c>pRangeTileCounts</c> are all arrays, of size <c>NumRanges</c>, that
		/// describe the tile ranges. If <c>pRangeFlags</c> is NULL, all ranges are sequential tiles in the tile pool; otherwise, for each
		/// range i, pRangeFlags[i] identifies how the mappings in that range of tiles work:
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>Flags parameter for overall options.</c><c>D3D11_TILE_MAPPING_NO_OVERWRITE</c> means the caller promises that previously
		/// submitted commands to the device that may still be executing do not reference any of the tile region being updated. This allows
		/// the device to avoid having to flush previously submitted work in order to do the tile mapping update. If the app violates this
		/// promise by updating tile mappings for locations in tiled resources still being referenced by outstanding commands, undefined
		/// rendering behavior results, which includes the potential for significant slowdowns on some architectures. This is like the "no
		/// overwrite" concept that exists elsewhere in the Direct3D API, except applied to tile mapping data structure itself, which in
		/// hardware is a page table. The absence of this flag requires that tile mapping updates specified by this
		/// <c>UpdateTileMappings</c> call must be completed before any subsequent Direct3D command can proceed.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// If tile mappings have changed on a tiled resource that the app will render via RenderTargetView or DepthStencilView, the app
		/// must clear, by using the fixed function <c>Clear</c> APIs, the tiles that have changed within the area being rendered (mapped or
		/// not). If an app doesn't clear in these situations, the app receives undefined values when it reads from the tiled resource.
		/// </para>
		/// <para><c>Note</c>  In Direct3D 11.2, hardware can now support ClearView on depth-only formats. For more info, see D3D11_FEATURE_DATA_D3D11_OPTIONS1.</para>
		/// <para></para>
		/// <para>
		/// If an app needs to preserve existing memory contents of areas in a tiled resource where mappings have changed, the app can first
		/// save the contents where tile mappings have changed, by copying them to a temporary surface, for example using CopyTiles, issuing
		/// the required <c>Clear</c>, and then copying the contents back.
		/// </para>
		/// <para>
		/// Suppose a tile is mapped into multiple tiled resources at the same time and tile contents are manipulated by any means (render,
		/// copy, and so on) via one of the tiled resources. Then, if the same tile is to be rendered via any other tiled resource, the tile
		/// must be cleared first as previously described.
		/// </para>
		/// <para>For more info about tiled resources, see Tiled resources.</para>
		/// <para>Here are some examples of common <c>UpdateTileMappings</c> cases:</para>
		/// <para>Examples</para>
		/// <para>Clearing an entire surface's mappings to NULL:</para>
		/// <para>Mapping a region of tiles to a single tile:</para>
		/// <para>Defining mappings for a set of disjoint individual tiles:</para>
		/// <para>Complex example - defining mappings for regions with some skips, some NULL mappings:</para>
		/// <para>CopyTileMappings</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-updatetilemappings HRESULT
		// UpdateTileMappings( [in] ID3D11Resource *pTiledResource, [in] UINT NumTiledResourceRegions, [in, optional] const
		// D3D11_TILED_RESOURCE_COORDINATE *pTiledResourceRegionStartCoordinates, [in, optional] const D3D11_TILE_REGION_SIZE
		// *pTiledResourceRegionSizes, [in, optional] ID3D11Buffer *pTilePool, [in] UINT NumRanges, [in, optional] const UINT *pRangeFlags,
		// [in, optional] const UINT *pTilePoolStartOffsets, [in, optional] const UINT *pRangeTileCounts, [in] UINT Flags );
		[PreserveSig]
		HRESULT UpdateTileMappings([In] ID3D11Resource pTiledResource, int NumTiledResourceRegions,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_TILED_RESOURCE_COORDINATE[]? pTiledResourceRegionStartCoordinates,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_TILE_REGION_SIZE[]? pTiledResourceRegionSizes,
			[In, Optional] ID3D11Buffer? pTilePool, int NumRanges, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[]? pRangeFlags,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[]? pTilePoolStartOffsets,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[]? pRangeTileCounts, D3D11_TILE_MAPPING_FLAG Flags);

		/// <summary>Copies mappings from a source tiled resource to a destination tiled resource.</summary>
		/// <param name="pDestTiledResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the destination tiled resource.</para>
		/// </param>
		/// <param name="pDestRegionStartCoordinate">
		/// <para>Type: <c>const D3D11_TILED_RESOURCE_COORDINATE*</c></para>
		/// <para>
		/// A pointer to a D3D11_TILED_RESOURCE_COORDINATE structure that describes the starting coordinates of the destination tiled resource.
		/// </para>
		/// </param>
		/// <param name="pSourceTiledResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the source tiled resource.</para>
		/// </param>
		/// <param name="pSourceRegionStartCoordinate">
		/// <para>Type: <c>const D3D11_TILED_RESOURCE_COORDINATE*</c></para>
		/// <para>A pointer to a D3D11_TILED_RESOURCE_COORDINATE structure that describes the starting coordinates of the source tiled resource.</para>
		/// </param>
		/// <param name="pTileRegionSize">
		/// <para>Type: <c>const D3D11_TILE_REGION_SIZE*</c></para>
		/// <para>A pointer to a D3D11_TILE_REGION_SIZE structure that describes the size of the tiled region.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A combination of D3D11_TILE_MAPPING_FLAGS values that are combined by using a bitwise OR operation. The only valid value is
		/// <c>D3D11_TILE_MAPPING_NO_OVERWRITE</c>, which indicates that previously submitted commands to the device that may still be
		/// executing do not reference any of the tile region being updated. The device can then avoid having to flush previously submitted
		/// work to perform the tile mapping update. If the app violates this promise by updating tile mappings for locations in tiled
		/// resources that are still being referenced by outstanding commands, undefined rendering behavior results, including the potential
		/// for significant slowdowns on some architectures. This is like the "no overwrite" concept that exists elsewhere in the Direct3D
		/// API, except applied to the tile mapping data structure itself (which in hardware is a page table). The absence of the
		/// <c>D3D11_TILE_MAPPING_NO_OVERWRITE</c> value requires that tile mapping updates that <c>CopyTileMappings</c> specifies must be
		/// completed before any subsequent Direct3D command can proceed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Returns <c>E_INVALIDARG</c> if various conditions such as invalid flags or passing in non Tiled Resources result in the call
		/// being dropped. The dest and the source regions must each entirely fit in their resource or behavior is undefined (debug layer
		/// will emit an error).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns <c>E_OUTOFMEMORY</c> if the call results in the driver having to allocate space for new page table mappings but running
		/// out of memory. If out of memory occurs when this is called in a commandlist and the commandlist is being executed, the device
		/// will be removed. Applications can avoid this situation by only doing update calls that change existing mappings from Tiled
		/// Resources within commandlists (so drivers will not have to allocate page table memory, only change the mapping).
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CopyTileMappings</c> helps with tasks such as shifting mappings around within and across tiled resources, for example,
		/// scrolling tiles. The source and destination regions can overlap; the result of the copy in this situation is as if the source
		/// was saved to a temp location and then from there written to the destination.
		/// </para>
		/// <para>For more info about tiled resources, see Tiled resources.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-copytilemappings HRESULT
		// CopyTileMappings( [in] ID3D11Resource *pDestTiledResource, [in] const D3D11_TILED_RESOURCE_COORDINATE
		// *pDestRegionStartCoordinate, [in] ID3D11Resource *pSourceTiledResource, [in] const D3D11_TILED_RESOURCE_COORDINATE
		// *pSourceRegionStartCoordinate, [in] const D3D11_TILE_REGION_SIZE *pTileRegionSize, [in] UINT Flags );
		[PreserveSig]
		HRESULT CopyTileMappings([In] ID3D11Resource pDestTiledResource, in D3D11_TILED_RESOURCE_COORDINATE pDestRegionStartCoordinate,
			[In] ID3D11Resource pSourceTiledResource, in D3D11_TILED_RESOURCE_COORDINATE pSourceRegionStartCoordinate,
			in D3D11_TILE_REGION_SIZE pTileRegionSize, D3D11_TILE_MAPPING_FLAG Flags);

		/// <summary>Copies tiles from buffer to tiled resource or vice versa.</summary>
		/// <param name="pTiledResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to a tiled resource.</para>
		/// </param>
		/// <param name="pTileRegionStartCoordinate">
		/// <para>Type: <c>const D3D11_TILED_RESOURCE_COORDINATE*</c></para>
		/// <para>A pointer to a D3D11_TILED_RESOURCE_COORDINATE structure that describes the starting coordinates of the tiled resource.</para>
		/// </param>
		/// <param name="pTileRegionSize">
		/// <para>Type: <c>const D3D11_TILE_REGION_SIZE*</c></para>
		/// <para>A pointer to a D3D11_TILE_REGION_SIZE structure that describes the size of the tiled region.</para>
		/// </param>
		/// <param name="pBuffer">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>A pointer to an ID3D11Buffer that represents a default, dynamic, or staging buffer.</para>
		/// </param>
		/// <param name="BufferStartOffsetInBytes">
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The offset in bytes into the buffer at <c>pBuffer</c> to start the operation.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A combination of D3D11_TILE_COPY_FLAG-typed values that are combined by using a bitwise OR operation and that identifies how to
		/// copy tiles.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <c>CopyTiles</c> drops write operations to unmapped areas and handles read operations from unmapped areas (except on Tier_1
		/// tiled resources, where reading and writing unmapped areas is invalid).
		/// </para>
		/// <para>
		/// If a copy operation involves writing to the same memory location multiple times because multiple locations in the destination
		/// resource are mapped to the same tile memory, the resulting write operations to multi-mapped tiles are non-deterministic and
		/// non-repeatable; that is, accesses to the tile memory happen in whatever order the hardware happens to execute the copy operation.
		/// </para>
		/// <para>
		/// The tiles involved in the copy operation can't include tiles that contain packed mipmaps or results of the copy operation are
		/// undefined. To transfer data to and from mipmaps that the hardware packs into the one-or-more tiles that constitute the packed
		/// mips, you must use the standard (that is, non-tile specific) copy and update APIs (like
		/// ID3D11DeviceContext1::CopySubresourceRegion1 and ID3D11DeviceContext1::UpdateSubresource1) or ID3D11DeviceContext::GenerateMips
		/// for the whole mipmap chain.
		/// </para>
		/// <para>
		/// The memory layout of the tiles in the non-tiled buffer resource side of the copy operation is linear in memory within 64 KB
		/// tiles, which the hardware and driver swizzle and deswizzle per tile as appropriate when they transfer to and from a tiled
		/// resource. For multisample antialiasing (MSAA) surfaces, the hardware and driver traverse each pixel's samples in sample-index
		/// order before they move to the next pixel. For tiles that are partially filled on the right side (for a surface that has a width
		/// not a multiple of tile width in pixels), the pitch and stride to move down a row is the full size in bytes of the number pixels
		/// that would fit across the tile if the tile was full. So, there can be a gap between each row of pixels in memory. Mipmaps that
		/// are smaller than a tile are not packed together in the linear layout, which might seem to be a waste of memory space, but as
		/// mentioned you can't use <c>CopyTiles</c> or ID3D11DeviceContext2::UpdateTiles to copy to mipmaps that the hardware packs
		/// together. You can just use generic copy and update APIs (like ID3D11DeviceContext1::CopySubresourceRegion1 and
		/// ID3D11DeviceContext1::UpdateSubresource1) to copy small mipmaps individually. Although in the case of a generic copy API (like
		/// <c>ID3D11DeviceContext1::CopySubresourceRegion1</c>), the linear memory must be the same dimension as the tiled resource;
		/// <c>ID3D11DeviceContext1::CopySubresourceRegion1</c> can't copy from a buffer resource to a Texture2D for instance.
		/// </para>
		/// <para>For more info about tiled resources, see Tiled resources.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-copytiles void CopyTiles( [in]
		// ID3D11Resource *pTiledResource, [in] const D3D11_TILED_RESOURCE_COORDINATE *pTileRegionStartCoordinate, [in] const
		// D3D11_TILE_REGION_SIZE *pTileRegionSize, [in] ID3D11Buffer *pBuffer, [in] UINT64 BufferStartOffsetInBytes, [in] UINT Flags );
		[PreserveSig]
		void CopyTiles([In] ID3D11Resource pTiledResource, in D3D11_TILED_RESOURCE_COORDINATE pTileRegionStartCoordinate,
			in D3D11_TILE_REGION_SIZE pTileRegionSize, [In] ID3D11Buffer pBuffer, ulong BufferStartOffsetInBytes, D3D11_TILE_COPY_FLAG Flags);

		/// <summary>Updates tiles by copying from app memory to the tiled resource.</summary>
		/// <param name="pDestTiledResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to a tiled resource to update.</para>
		/// </param>
		/// <param name="pDestTileRegionStartCoordinate">
		/// <para>Type: <c>const D3D11_TILED_RESOURCE_COORDINATE*</c></para>
		/// <para>A pointer to a D3D11_TILED_RESOURCE_COORDINATE structure that describes the starting coordinates of the tiled resource.</para>
		/// </param>
		/// <param name="pDestTileRegionSize">
		/// <para>Type: <c>const D3D11_TILE_REGION_SIZE*</c></para>
		/// <para>A pointer to a D3D11_TILE_REGION_SIZE structure that describes the size of the tiled region.</para>
		/// </param>
		/// <param name="pSourceTileData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to memory that contains the source tile data that <c>UpdateTiles</c> uses to update the tiled resource.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A combination of D3D11_TILE_COPY_FLAG-typed values that are combined by using a bitwise OR operation. The only valid value is
		/// <c>D3D11_TILE_COPY_NO_OVERWRITE</c>. The other values aren't meaningful here, though by definition the
		/// <c>D3D11_TILE_COPY_LINEAR_BUFFER_TO_SWIZZLED_TILED_RESOURCE</c> value is basically what <c>UpdateTiles</c> does, but sources
		/// from app memory.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <c>UpdateTiles</c> drops write operations to unmapped areas (except on Tier_1 tiled resources, where writing to unmapped areas
		/// is invalid).
		/// </para>
		/// <para>
		/// If a copy operation involves writing to the same memory location multiple times because multiple locations in the destination
		/// resource are mapped to the same tile memory, the resulting write operations to multi-mapped tiles are non-deterministic and
		/// non-repeatable; that is, accesses to the tile memory happen in whatever order the hardware happens to execute the copy operation.
		/// </para>
		/// <para>
		/// The tiles involved in the copy operation can't include tiles that contain packed mipmaps or results of the copy operation are
		/// undefined. To transfer data to and from mipmaps that the hardware packs into one tile, you must use the standard (that is,
		/// non-tile specific) copy and update APIs (like ID3D11DeviceContext1::CopySubresourceRegion1 and
		/// ID3D11DeviceContext1::UpdateSubresource1) or ID3D11DeviceContext::GenerateMips for the whole mipmap chain.
		/// </para>
		/// <para>
		/// The memory layout of the data on the source side of the copy operation is linear in memory within 64 KB tiles, which the
		/// hardware and driver swizzle and deswizzle per tile as appropriate when they transfer to and from a tiled resource. For
		/// multisample antialiasing (MSAA) surfaces, the hardware and driver traverse each pixel's samples in sample-index order before
		/// they move to the next pixel. For tiles that are partially filled on the right side (for a surface that has a width not a
		/// multiple of tile width in pixels), the pitch and stride to move down a row is the full size in bytes of the number pixels that
		/// would fit across the tile if the tile was full. So, there can be a gap between each row of pixels in memory. Mipmaps that are
		/// smaller than a tile are not packed together in the linear layout, which might seem to be a waste of memory space, but as
		/// mentioned you can't use ID3D11DeviceContext2::CopyTiles or <c>UpdateTiles</c> to copy to mipmaps that the hardware packs
		/// together. You can just use generic copy and update APIs (like ID3D11DeviceContext1::CopySubresourceRegion1 and
		/// ID3D11DeviceContext1::UpdateSubresource1) to copy small mipmaps individually. Although in the case of a generic copy API (like
		/// <c>ID3D11DeviceContext1::CopySubresourceRegion1</c>), the linear memory must be the same dimension as the tiled resource;
		/// <c>ID3D11DeviceContext1::CopySubresourceRegion1</c> can't copy from a buffer resource to a Texture2D for instance.
		/// </para>
		/// <para>For more info about tiled resources, see Tiled resources.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-updatetiles void UpdateTiles( [in]
		// ID3D11Resource *pDestTiledResource, [in] const D3D11_TILED_RESOURCE_COORDINATE *pDestTileRegionStartCoordinate, [in] const
		// D3D11_TILE_REGION_SIZE *pDestTileRegionSize, [in] const void *pSourceTileData, [in] UINT Flags );
		[PreserveSig]
		void UpdateTiles([In] ID3D11Resource pDestTiledResource, in D3D11_TILED_RESOURCE_COORDINATE pDestTileRegionStartCoordinate,
			in D3D11_TILE_REGION_SIZE pDestTileRegionSize, [In] IntPtr pSourceTileData, D3D11_TILE_COPY_FLAG Flags);

		/// <summary>Resizes a tile pool.</summary>
		/// <param name="pTilePool">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>A pointer to an ID3D11Buffer for the tile pool to resize.</para>
		/// </param>
		/// <param name="NewSizeInBytes">
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The new size in bytes of the tile pool. The size must be a multiple of 64 KB or 0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Returns <c>E_INVALIDARG</c> if the new tile pool size isn't a multiple of 64 KB or 0.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns <c>E_OUTOFMEMORY</c> if the call results in the driver having to allocate space for new page table mappings but running
		/// out of memory.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns <c>DXGI_ERROR_DEVICE_REMOVED</c> if the video card has been physically removed from the system, or a driver upgrade for
		/// the video card has occurred.
		/// </description>
		/// </item>
		/// </list>
		/// <para>For <c>E_INVALIDARG</c> or <c>E_OUTOFMEMORY</c>, the existing tile pool remains unchanged, which includes existing mappings.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ResizeTilePool</c> increases or decreases the size of the tile pool depending on whether the app needs more or less working
		/// set for the tiled resources that are mapped into it. An app can allocate additional tile pools for new tiled resources, but if
		/// any single tiled resource needs more space than initially available in its tile pool, the app can increase the size of the
		/// resource's tile pool. A tiled resource can't have mappings into multiple tile pools simultaneously.
		/// </para>
		/// <para>
		/// When you increase the size of a tile pool, additional tiles are added to the end of the tile pool via one or more new
		/// allocations by the driver; your app can't detect the breakdown into the new allocations. Existing memory in the tile pool is
		/// left untouched, and existing tiled resource mappings into that memory remain intact.
		/// </para>
		/// <para>
		/// When you decrease the size of a tile pool, tiles are removed from the end (this is allowed even below the initial allocation
		/// size, down to 0). This means that new mappings can't be made past the new size. But, existing mappings past the end of the new
		/// size remain intact and useable. The memory is kept active as long as mappings to any part of the allocations that are being used
		/// for the tile pool memory remains. If after decreasing, some memory has been kept active because tile mappings are pointing to it
		/// and the tile pool is increased again (by any amount), the existing memory is reused first before any additional allocations
		/// occur to service the size of the increase.
		/// </para>
		/// <para>
		/// To be able to save memory, an app has to not only decrease a tile pool but also remove and remap existing mappings past the end
		/// of the new smaller tile pool size.
		/// </para>
		/// <para>
		/// The act of decreasing (and removing mappings) doesn't necessarily produce immediate memory savings. Freeing of memory depends on
		/// how granular the driver's underlying allocations for the tile pool are. When a decrease in the size of a tile pool happens to be
		/// enough to make a driver allocation unused, the driver can free the allocation. If a tile pool was increased and if you then
		/// decrease to previous sizes (and remove and remap tile mappings correspondingly), you will most likely yield memory savings. But,
		/// this scenario isn't guaranteed in the case that the sizes don't exactly align with the underlying allocation sizes chosen by the driver.
		/// </para>
		/// <para>For more info about tiled resources, see Tiled resources.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-resizetilepool HRESULT
		// ResizeTilePool( [in] ID3D11Buffer *pTilePool, [in] UINT64 NewSizeInBytes );
		[PreserveSig]
		HRESULT ResizeTilePool([In] ID3D11Buffer pTilePool, ulong NewSizeInBytes);

		/// <summary>
		/// Specifies a data access ordering constraint between multiple tiled resources. For more info about this constraint, see Remarks.
		/// </summary>
		/// <param name="pTiledResourceOrViewAccessBeforeBarrier">
		/// <para>Type: <c>ID3D11DeviceChild*</c></para>
		/// <para>
		/// A pointer to an ID3D11Resource or ID3D11View for a resource that was created with the D3D11_RESOURCE_MISC_TILED flag. Access
		/// operations on this object must complete before the access operations on the object that
		/// <c>pTiledResourceOrViewAccessAfterBarrier</c> specifies.
		/// </para>
		/// </param>
		/// <param name="pTiledResourceOrViewAccessAfterBarrier">
		/// <para>Type: <c>ID3D11DeviceChild*</c></para>
		/// <para>
		/// A pointer to an ID3D11Resource or ID3D11View for a resource that was created with the D3D11_RESOURCE_MISC_TILED flag. Access
		/// operations on this object must begin after the access operations on the object that
		/// <c>pTiledResourceOrViewAccessBeforeBarrier</c> specifies.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Apps can use tiled resources to reuse tiles in different resources. But, a device and driver might not be able to determine
		/// whether some memory in a tile pool that was just rendered to is now being used for reading.
		/// </para>
		/// <para>
		/// For example, an app can render to some tiles in a tile pool with one tiled resource but then read from the same tiles by using a
		/// different tiled resource. These tiled-resource operations are different from using one resource and then just switching from
		/// writing with ID3D11RenderTargetView to reading with ID3D11ShaderResourceView. The runtime already tracks and handles these one
		/// resource operations using <c>ID3D11RenderTargetView</c> and <c>ID3D11ShaderResourceView</c>.
		/// </para>
		/// <para>
		/// When an app transitions from accessing (reading or writing) some location in a tile pool with one resource to accessing the same
		/// memory (read or write) via another tiled resource (with mappings to the same memory), the app must call
		/// <c>TiledResourceBarrier</c> after the first use of the resource and before the second. The parameters are the
		/// <c>pTiledResourceOrViewAccessBeforeBarrier</c> for accesses before the barrier (via rendering, copying), and the
		/// <c>pTiledResourceOrViewAccessAfterBarrier</c> for accesses after the barrier by using the same tile pool memory. If the
		/// resources are identical, the app doesn't need to call <c>TiledResourceBarrier</c> because this kind of hazard is already tracked
		/// and handled.
		/// </para>
		/// <para>
		/// The barrier call informs the driver that operations issued to the resource before the call must complete before any accesses
		/// that occur after the call via a different tiled resource that shares the same memory.
		/// </para>
		/// <para>
		/// Either or both of the parameters (before or after the barrier) can be <c>NULL</c>. <c>NULL</c> before the barrier means all
		/// tiled resource accesses before the barrier must complete before the resource specified after the barrier can be referenced by
		/// the graphics processing unit (GPU). <c>NULL</c> after the barrier means that any tiled resources accessed after the barrier can
		/// only be executed by the GPU after accesses to the tiled resources before the barrier are finished. Both <c>NULL</c> means all
		/// previous tiled resource accesses are complete before any subsequent tiled resource access can proceed.
		/// </para>
		/// <para>
		/// An app can pass a view pointer, a resource, or <c>NULL</c> for each parameter. Views are allowed not only for convenience but
		/// also to allow the app to scope the barrier effect to a relevant portion of a resource.
		/// </para>
		/// <para>For more info about tiled resources, see Tiled resources.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-tiledresourcebarrier void
		// TiledResourceBarrier( [in, optional] ID3D11DeviceChild *pTiledResourceOrViewAccessBeforeBarrier, [in, optional] ID3D11DeviceChild
		// *pTiledResourceOrViewAccessAfterBarrier );
		[PreserveSig]
		void TiledResourceBarrier([In] ID3D11DeviceChild pTiledResourceOrViewAccessBeforeBarrier, [In] ID3D11DeviceChild pTiledResourceOrViewAccessAfterBarrier);

		/// <summary>Allows apps to determine when either a capture or profiling request is enabled.</summary>
		/// <returns>Returns <c>TRUE</c> if capture or profiling is enabled and <c>FALSE</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// Returns <c>TRUE</c> if the capture tool is present and capturing or the app is being profiled such that SetMarkerInt or
		/// BeginEventInt will be logged to ETW. Otherwise, it returns <c>FALSE</c>. Apps can use this to turn off self-throttling
		/// mechanisms in order to accurately capture what is currently being seen as app output. Apps can also avoid generating event
		/// markers and the associated overhead it may entail when there is no benefit to do so.
		/// </para>
		/// <para>
		/// If apps detect that capture is being performed, they can prevent the Direct3D debugging tools, such as Microsoft Visual
		/// Studio 2013, from capturing them. The purpose of the D3D11_CREATE_DEVICE_PREVENT_ALTERING_LAYER_SETTINGS_FROM_REGISTRY flag
		/// prior to Windows 8.1 was to allow the Direct3D runtime to prevent debugging tools from capturing apps.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-isannotationenabled BOOL IsAnnotationEnabled();
		[PreserveSig]
		bool IsAnnotationEnabled();

		/// <summary>Allows applications to annotate graphics commands.</summary>
		/// <param name="pLabel">
		/// An optional string that will be logged to ETW when ETW logging is active. If <c>‘#d’</c> appears in the string, it will be
		/// replaced by the value of the <c>Data</c> parameter similar to the way <c>printf</c> works.
		/// </param>
		/// <param name="Data">A signed data value that will be logged to ETW when ETW logging is active.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <c>SetMarkerInt</c> allows applications to annotate graphics commands, in order to provide more context to what the GPU is
		/// executing. When ETW logging or a support tool is enabled, an additional marker is correlated between the CPU and GPU timelines.
		/// The <c>pLabel</c> and <c>Data</c> value are logged to ETW. When the appropriate ETW logging is not enabled, this method does nothing.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-setmarkerint void SetMarkerInt( [in]
		// LPCWSTR pLabel, INT Data );
		[PreserveSig]
		void SetMarkerInt([MarshalAs(UnmanagedType.LPWStr)] string pLabel, int Data);

		/// <summary>Allows applications to annotate the beginning of a range of graphics commands.</summary>
		/// <param name="pLabel">
		/// An optional string that will be logged to ETW when ETW logging is active. If <c>‘#d’</c> appears in the string, it will be
		/// replaced by the value of the <c>Data</c> parameter similar to the way <c>printf</c> works.
		/// </param>
		/// <param name="Data">A signed data value that will be logged to ETW when ETW logging is active.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <c>BeginEventInt</c> allows applications to annotate the beginning of a range of graphics commands, in order to provide more
		/// context to what the GPU is executing. When ETW logging (or a supported tool) is enabled, an additional marker is correlated
		/// between the CPU and GPU timelines. The <c>pLabel</c> and <c>Data</c> value are logged to ETW. When the appropriate ETW logging
		/// is not enabled, this method does nothing.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-begineventint void BeginEventInt(
		// [in] LPCWSTR pLabel, INT Data );
		[PreserveSig]
		void BeginEventInt([MarshalAs(UnmanagedType.LPWStr)] string pLabel, int Data);

		/// <summary>Allows applications to annotate the end of a range of graphics commands.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <c>EndEvent</c> allows applications to annotate the end of a range of graphics commands, in order to provide more context to
		/// what the GPU is executing. When the appropriate ETW logging is not enabled, this method does nothing. When ETW logging is
		/// enabled, an additional marker is correlated between the CPU and GPU timelines.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/nf-d3d11_2-id3d11devicecontext2-endevent void EndEvent();
		[PreserveSig]
		void EndEvent();
	}

	/// <summary>Describes the tile structure of a tiled resource with mipmaps.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ns-d3d11_2-d3d11_packed_mip_desc typedef struct D3D11_PACKED_MIP_DESC {
	// UINT8 NumStandardMips; UINT8 NumPackedMips; UINT NumTilesForPackedMips; UINT StartTileIndexInOverallResource; } D3D11_PACKED_MIP_DESC;
	[PInvokeData("d3d11_2.h", MSDNShortId = "NS:d3d11_2.D3D11_PACKED_MIP_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_PACKED_MIP_DESC
	{
		/// <summary>Number of standard mipmaps in the tiled resource.</summary>
		public byte NumStandardMips;

		/// <summary>
		/// <para>Number of packed mipmaps in the tiled resource.</para>
		/// <para>
		/// This number starts from the least detailed mipmap (either sharing tiles or using non standard tile layout). This number is 0 if
		/// no such packing is in the resource. For array surfaces, this value is the number of mipmaps that are packed for a given array
		/// slice where each array slice repeats the same packing.
		/// </para>
		/// <para>
		/// On Tier_2 tiled resources hardware, mipmaps that fill at least one standard shaped tile in all dimensions are not allowed to be
		/// included in the set of packed mipmaps. On Tier_1 hardware, mipmaps that are an integer multiple of one standard shaped tile in
		/// all dimensions are not allowed to be included in the set of packed mipmaps. Mipmaps with at least one dimension less than the
		/// standard tile shape may or may not be packed. When a given mipmap needs to be packed, all coarser mipmaps for a given array
		/// slice are considered packed as well.
		/// </para>
		/// </summary>
		public byte NumPackedMips;

		/// <summary>
		/// <para>Number of tiles for the packed mipmaps in the tiled resource.</para>
		/// <para>
		/// If there is no packing, this value is meaningless and is set to 0. Otherwise, it is set to the number of tiles that are needed
		/// to represent the set of packed mipmaps. The pixel layout within the packed mipmaps is hardware specific. If apps define only
		/// partial mappings for the set of tiles in packed mipmaps, read and write behavior is vendor specific and undefined. For arrays,
		/// this value is only the count of packed mipmaps within the subresources for each array slice.
		/// </para>
		/// </summary>
		public uint NumTilesForPackedMips;

		/// <summary>
		/// <para>
		/// Offset of the first packed tile for the resource in the overall range of tiles. If <c>NumPackedMips</c> is 0, this value is
		/// meaningless and is 0. Otherwise, it is the offset of the first packed tile for the resource in the overall range of tiles for
		/// the resource. A value of 0 for <c>StartTileIndexInOverallResource</c> means the entire resource is packed. For array surfaces,
		/// this is the offset for the tiles that contain the packed mipmaps for the first array slice. Packed mipmaps for each array slice
		/// in arrayed surfaces are at this offset past the beginning of the tiles for each array slice.
		/// </para>
		/// <para>
		/// <c>Note</c>  The number of overall tiles, packed or not, for a given array slice is simply the total number of tiles for the
		/// resource divided by the resource's array size, so it is easy to locate the range of tiles for any given array slice, out of
		/// which <c>StartTileIndexInOverallResource</c> identifies which of those are packed.
		/// </para>
		/// <para></para>
		/// </summary>
		public uint StartTileIndexInOverallResource;
	}

	/// <summary>Describes a tiled subresource volume.</summary>
	/// <remarks>
	/// <para>Each packed mipmap is individually reported as 0 for <c>WidthInTiles</c>, <c>HeightInTiles</c> and <c>DepthInTiles</c>.</para>
	/// <para>The total number of tiles in subresources is <c>WidthInTiles</c><c>HeightInTiles</c><c>DepthInTiles</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ns-d3d11_2-d3d11_subresource_tiling typedef struct
	// D3D11_SUBRESOURCE_TILING { UINT WidthInTiles; UINT16 HeightInTiles; UINT16 DepthInTiles; UINT StartTileIndexInOverallResource; } D3D11_SUBRESOURCE_TILING;
	[PInvokeData("d3d11_2.h", MSDNShortId = "NS:d3d11_2.D3D11_SUBRESOURCE_TILING")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_SUBRESOURCE_TILING
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width in tiles of the subresource.</para>
		/// </summary>
		public uint WidthInTiles;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The height in tiles of the subresource.</para>
		/// </summary>
		public ushort HeightInTiles;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The depth in tiles of the subresource.</para>
		/// </summary>
		public ushort DepthInTiles;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the tile in the overall tiled subresource to start with.</para>
		/// <para>
		/// GetResourceTiling sets <c>StartTileIndexInOverallResource</c> to <c>D3D11_PACKED_TILE</c> (0xffffffff) to indicate that the
		/// whole <c>D3D11_SUBRESOURCE_TILING</c> structure is meaningless, and the info to which the <c>pPackedMipDesc</c> parameter of
		/// <c>GetResourceTiling</c> points applies. For packed tiles, the description of the packed mipmaps comes from a
		/// D3D11_PACKED_MIP_DESC structure instead.
		/// </para>
		/// </summary>
		public uint StartTileIndexInOverallResource;
	}

	/// <summary>Describes the size of a tiled region.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ns-d3d11_2-d3d11_tile_region_size typedef struct D3D11_TILE_REGION_SIZE {
	// UINT NumTiles; BOOL bUseBox; UINT Width; UINT16 Height; UINT16 Depth; } D3D11_TILE_REGION_SIZE;
	[PInvokeData("d3d11_2.h", MSDNShortId = "NS:d3d11_2.D3D11_TILE_REGION_SIZE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TILE_REGION_SIZE
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of tiles in the tiled region.</para>
		/// </summary>
		public uint NumTiles;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Specifies whether the runtime uses the <c>Width</c>, <c>Height</c>, and <c>Depth</c> members to define the region.</para>
		/// <para>If <c>TRUE</c>, the runtime uses the <c>Width</c>, <c>Height</c>, and <c>Depth</c> members to define the region.</para>
		/// <para>
		/// If <c>FALSE</c>, the runtime ignores the <c>Width</c>, <c>Height</c>, and <c>Depth</c> members and uses the <c>NumTiles</c>
		/// member to traverse tiles in the resource linearly across x, then y, then z (as applicable) and then spills over mipmaps/arrays
		/// in subresource order. For example, use this technique to map an entire resource at once.
		/// </para>
		/// <para>
		/// Regardless of whether you specify <c>TRUE</c> or <c>FALSE</c> for <c>bUseBox</c>, you use a D3D11_TILED_RESOURCE_COORDINATE
		/// structure to specify the starting location for the region within the resource as a separate parameter outside of this structure
		/// by using x, y, and z coordinates.
		/// </para>
		/// <para>
		/// When the region includes mipmaps that are packed with nonstandard tiling, <c>bUseBox</c> must be <c>FALSE</c> because tile
		/// dimensions are not standard and the app only knows a count of how many tiles are consumed by the packed area, which is per array
		/// slice. The corresponding (separate) starting location parameter uses x to offset into the flat range of tiles in this case, and
		/// y and z coordinates must each be 0.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bUseBox;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of the tiled region, in tiles. Used for buffer and 1D, 2D, and 3D textures.</para>
		/// </summary>
		public uint Width;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The height of the tiled region, in tiles. Used for 2D and 3D textures.</para>
		/// </summary>
		public ushort Height;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The depth of the tiled region, in tiles. Used for 3D textures or arrays. For arrays, used for advancing in depth jumps to next
		/// slice of same mipmap size, which isn't contiguous in the subresource counting space if there are multiple mipmaps.
		/// </para>
		/// </summary>
		public ushort Depth;
	}

	/// <summary>Describes the shape of a tile by specifying its dimensions.</summary>
	/// <remarks>
	/// Texels are equivalent to pixels. For untyped buffer resources, a texel is just a byte. For multisample antialiasing (MSAA) surfaces,
	/// the numbers are still in terms of pixels/texels. The values here are independent of the surface dimensions. Even if the surface is
	/// smaller than what would fit in a tile, the full tile dimensions are reported here.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ns-d3d11_2-d3d11_tile_shape typedef struct D3D11_TILE_SHAPE { UINT
	// WidthInTexels; UINT HeightInTexels; UINT DepthInTexels; } D3D11_TILE_SHAPE;
	[PInvokeData("d3d11_2.h", MSDNShortId = "NS:d3d11_2.D3D11_TILE_SHAPE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TILE_SHAPE
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width in texels of the tile.</para>
		/// </summary>
		public uint WidthInTexels;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height in texels of the tile.</para>
		/// </summary>
		public uint HeightInTexels;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The depth in texels of the tile.</para>
		/// </summary>
		public uint DepthInTexels;
	}

	/// <summary>Describes the coordinates of a tiled resource.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ns-d3d11_2-d3d11_tiled_resource_coordinate typedef struct
	// D3D11_TILED_RESOURCE_COORDINATE { UINT X; UINT Y; UINT Z; UINT Subresource; } D3D11_TILED_RESOURCE_COORDINATE;
	[PInvokeData("d3d11_2.h", MSDNShortId = "NS:d3d11_2.D3D11_TILED_RESOURCE_COORDINATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TILED_RESOURCE_COORDINATE
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The x position of a tiled resource. Used for buffer and 1D, 2D, and 3D textures.</para>
		/// </summary>
		public uint X;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The y position of a tiled resource. Used for 2D and 3D textures.</para>
		/// </summary>
		public uint Y;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The z position of a tiled resource. Used for 3D textures.</para>
		/// </summary>
		public uint Z;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>A subresource index value into mipmaps and arrays. Used for 1D, 2D, and 3D textures.</para>
		/// <para>
		/// For mipmaps that use nonstandard tiling, or are packed, or both use nonstandard tiling and are packed, any subresource value
		/// that indicates any of the packed mipmaps all refer to the same tile.
		/// </para>
		/// </summary>
		public uint Subresource;
	}
}