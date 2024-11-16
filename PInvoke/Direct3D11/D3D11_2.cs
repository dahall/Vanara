namespace Vanara.PInvoke;

public static partial class D3D11
{
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
		new HRESULT OpenSharedResource([In] IntPtr hResource, in Guid ReturnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object? ppResource);

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
		/// <para>Type: <c>LPSTR</c></para>
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
		/// <para>Type: <c>LPSTR</c></para>
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
		/// <para>Type: <c>LPSTR</c></para>
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
		// D3D11_COUNTER_DESC *pDesc, [out] D3D11_COUNTER_TYPE *pType, [out] uint *pActiveCounters, [out, optional] LPSTR szName, [in, out,
		// optional] uint *pNameLength, [out, optional] LPSTR szUnits, [in, out, optional] uint *pUnitsLength, [out, optional] LPSTR
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pData);

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
		/// <param name="{D3D_FEATURE_LEVEL_11_1,D3D_FEATURE_LEVEL_11_0,D3D_FEATURE_LEVEL_10_1,D3D_FEATURE_LEVEL_10_0,D3D_FEATURE_LEVEL_9_3,D3D_FEATURE_LEVEL_9_2,D3D_FEATURE_LEVEL_9_1,&#xA;};"/>
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
		new HRESULT OpenSharedResource1(HANDLE hResource, in Guid returnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource);

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
			in Guid returnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource);

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

		[PreserveSig]
		HRESULT CheckMultisampleQualityLevels1(DXGI_FORMAT Format, uint SampleCount, uint Flags, out uint pNumQualityLevels);
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
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		[PreserveSig]
		new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);

		[PreserveSig]
		new void VSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void PSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void PSSetShader(ID3D11PixelShader pPixelShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void PSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void VSSetShader(ID3D11VertexShader pVertexShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void DrawIndexed(uint IndexCount, uint StartIndexLocation, int BaseVertexLocation);

		[PreserveSig]
		new void Draw(uint VertexCount, uint StartVertexLocation);

		[PreserveSig]
		new HRESULT Map(ID3D11Resource pResource, uint Subresource, D3D11_MAP MapType, uint MapFlags, IntPtr pMappedResource);

		[PreserveSig]
		new void Unmap(ID3D11Resource pResource, uint Subresource);

		[PreserveSig]
		new void PSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void IASetInputLayout(ID3D11InputLayout pInputLayout);

		[PreserveSig]
		new void IASetVertexBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppVertexBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pStrides, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pOffsets);

		[PreserveSig]
		new void IASetIndexBuffer(ID3D11Buffer pIndexBuffer, DXGI_FORMAT Format, uint Offset);

		[PreserveSig]
		new void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, int BaseVertexLocation, uint StartInstanceLocation);

		[PreserveSig]
		new void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);

		[PreserveSig]
		new void GSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void GSSetShader(ID3D11GeometryShader pShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY Topology);

		[PreserveSig]
		new void VSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void VSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void Begin(ID3D11Asynchronous pAsync);

		[PreserveSig]
		new void End(ID3D11Asynchronous pAsync);

		[PreserveSig]
		new HRESULT GetData(ID3D11Asynchronous pAsync, IntPtr pData, uint DataSize, uint GetDataFlags);

		[PreserveSig]
		new void SetPredication(ID3D11Predicate pPredicate, bool PredicateValue);

		[PreserveSig]
		new void GSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void GSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void OMSetRenderTargets(int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11RenderTargetView[] ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView);

		[PreserveSig]
		new void OMSetRenderTargetsAndUnorderedAccessViews(int NumRTVs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11RenderTargetView[] ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView, uint UAVStartSlot, int NumUAVs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ID3D11UnorderedAccessView[] ppUnorderedAccessViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] pUAVInitialCounts);

		[PreserveSig]
		new void OMSetBlendState(ID3D11BlendState pBlendState, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] BlendFactor, uint SampleMask);

		[PreserveSig]
		new void OMSetDepthStencilState(ID3D11DepthStencilState pDepthStencilState, uint StencilRef);

		[PreserveSig]
		new void SOSetTargets(int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11Buffer[] ppSOTargets, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] pOffsets);

		[PreserveSig]
		new void DrawAuto();

		[PreserveSig]
		new void DrawIndexedInstancedIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		[PreserveSig]
		new void DrawInstancedIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		[PreserveSig]
		new void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);

		[PreserveSig]
		new void DispatchIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		[PreserveSig]
		new void RSSetState(ID3D11RasterizerState pRasterizerState);

		[PreserveSig]
		new void RSSetViewports(int NumViewports, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D11_VIEWPORT[] pViewports);

		[PreserveSig]
		new void RSSetScissorRects(int NumRects, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[] pRects);

		[PreserveSig]
		new void CopySubresourceRegion(ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, ID3D11Resource pSrcResource, uint SrcSubresource, IntPtr pSrcBox);

		[PreserveSig]
		new void CopyResource(ID3D11Resource pDstResource, ID3D11Resource pSrcResource);

		[PreserveSig]
		new void UpdateSubresource(ID3D11Resource pDstResource, uint DstSubresource, IntPtr pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);

		[PreserveSig]
		new void CopyStructureCount(ID3D11Buffer pDstBuffer, uint DstAlignedByteOffset, ID3D11UnorderedAccessView pSrcView);

		[PreserveSig]
		new void ClearRenderTargetView(ID3D11RenderTargetView pRenderTargetView, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] ColorRGBA);

		[PreserveSig]
		new void ClearUnorderedAccessViewUint(ID3D11UnorderedAccessView pUnorderedAccessView, [In][Out][MarshalAs(UnmanagedType.LPArray)] uint[] Values);

		[PreserveSig]
		new void ClearUnorderedAccessViewFloat(ID3D11UnorderedAccessView pUnorderedAccessView, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] Values);

		[PreserveSig]
		new void ClearDepthStencilView(ID3D11DepthStencilView pDepthStencilView, uint ClearFlags, float Depth, byte Stencil);

		[PreserveSig]
		new void GenerateMips(ID3D11ShaderResourceView pShaderResourceView);

		[PreserveSig]
		new void SetResourceMinLOD(ID3D11Resource pResource, float MinLOD);

		[PreserveSig]
		new float GetResourceMinLOD(ID3D11Resource pResource);

		[PreserveSig]
		new void ResolveSubresource(ID3D11Resource pDstResource, uint DstSubresource, ID3D11Resource pSrcResource, uint SrcSubresource, DXGI_FORMAT Format);

		[PreserveSig]
		new void ExecuteCommandList(ID3D11CommandList pCommandList, bool RestoreContextState);

		[PreserveSig]
		new void HSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void HSSetShader(ID3D11HullShader pHullShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void HSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void HSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void DSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void DSSetShader(ID3D11DomainShader pDomainShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void DSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void DSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void CSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void CSSetUnorderedAccessViews(uint StartSlot, int NumUAVs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11UnorderedAccessView[] ppUnorderedAccessViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pUAVInitialCounts);

		[PreserveSig]
		new void CSSetShader(ID3D11ComputeShader pComputeShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void CSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void CSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void VSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void PSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void PSGetShader(out ID3D11PixelShader ppPixelShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void PSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void VSGetShader(out ID3D11VertexShader ppVertexShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void PSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void IAGetInputLayout(out ID3D11InputLayout ppInputLayout);

		[PreserveSig]
		new void IAGetVertexBuffers(uint StartSlot, int NumBuffers, IntPtr ppVertexBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pStrides, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pOffsets);

		[PreserveSig]
		new void IAGetIndexBuffer(out ID3D11Buffer pIndexBuffer, IntPtr Format, IntPtr Offset);

		[PreserveSig]
		new void GSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void GSGetShader(out ID3D11GeometryShader ppGeometryShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void IAGetPrimitiveTopology(out D3D_PRIMITIVE_TOPOLOGY pTopology);

		[PreserveSig]
		new void VSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void VSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void GetPredication(out ID3D11Predicate ppPredicate, IntPtr pPredicateValue);

		[PreserveSig]
		new void GSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void GSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void OMGetRenderTargets(uint NumViews, IntPtr ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView);

		[PreserveSig]
		new void OMGetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, IntPtr ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView, uint UAVStartSlot, uint NumUAVs, IntPtr ppUnorderedAccessViews);

		[PreserveSig]
		new void OMGetBlendState(out ID3D11BlendState ppBlendState, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] BlendFactor, IntPtr pSampleMask);

		[PreserveSig]
		new void OMGetDepthStencilState(out ID3D11DepthStencilState ppDepthStencilState, IntPtr pStencilRef);

		[PreserveSig]
		new void SOGetTargets(uint NumBuffers, IntPtr ppSOTargets);

		[PreserveSig]
		new void RSGetState(out ID3D11RasterizerState ppRasterizerState);

		[PreserveSig]
		new void RSGetViewports(ref int pNumViewports, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D11_VIEWPORT[] pViewports);

		[PreserveSig]
		new void RSGetScissorRects(ref int pNumRects, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[] pRects);

		[PreserveSig]
		new void HSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void HSGetShader(out ID3D11HullShader ppHullShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void HSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void HSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void DSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void DSGetShader(out ID3D11DomainShader ppDomainShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void DSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void DSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void CSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void CSGetUnorderedAccessViews(uint StartSlot, uint NumUAVs, IntPtr ppUnorderedAccessViews);

		[PreserveSig]
		new void CSGetShader(out ID3D11ComputeShader ppComputeShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void CSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void CSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void ClearState();

		[PreserveSig]
		new void Flush();

		[PreserveSig]
		new D3D11_DEVICE_CONTEXT_TYPE GetType();

		[PreserveSig]
		new uint GetContextFlags();

		[PreserveSig]
		new HRESULT FinishCommandList(bool RestoreDeferredContextState, out ID3D11CommandList ppCommandList);

		[PreserveSig]
		new void CopySubresourceRegion1(ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, ID3D11Resource pSrcResource, uint SrcSubresource, IntPtr pSrcBox, uint CopyFlags);

		[PreserveSig]
		new void UpdateSubresource1(ID3D11Resource pDstResource, uint DstSubresource, IntPtr pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch, uint CopyFlags);

		[PreserveSig]
		new void DiscardResource(ID3D11Resource pResource);

		[PreserveSig]
		new void DiscardView(ID3D11View pResourceView);

		[PreserveSig]
		new void VSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void HSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void DSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void GSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void PSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void CSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void VSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void HSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void DSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void GSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void PSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void CSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void SwapDeviceContextState(ID3DDeviceContextState pState, out ID3DDeviceContextState ppPreviousState);

		[PreserveSig]
		new void ClearView(ID3D11View pView, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] Color, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] RECT[] pRect, int NumRects);

		[PreserveSig]
		new void DiscardView1(ID3D11View pResourceView, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] pRects, int NumRects);

		[PreserveSig]
		HRESULT UpdateTileMappings(ID3D11Resource pTiledResource, int NumTiledResourceRegions, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_TILED_RESOURCE_COORDINATE[] pTiledResourceRegionStartCoordinates, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_TILE_REGION_SIZE[] pTiledResourceRegionSizes, ID3D11Buffer pTilePool, int NumRanges, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pRangeFlags, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pTilePoolStartOffsets, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pRangeTileCounts, uint Flags);

		[PreserveSig]
		HRESULT CopyTileMappings(ID3D11Resource pDestTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pDestRegionStartCoordinate, ID3D11Resource pSourceTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pSourceRegionStartCoordinate, ref D3D11_TILE_REGION_SIZE pTileRegionSize, uint Flags);

		[PreserveSig]
		void CopyTiles(ID3D11Resource pTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pTileRegionStartCoordinate, ref D3D11_TILE_REGION_SIZE pTileRegionSize, ID3D11Buffer pBuffer, ulong BufferStartOffsetInBytes, uint Flags);

		[PreserveSig]
		void UpdateTiles(ID3D11Resource pDestTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pDestTileRegionStartCoordinate, ref D3D11_TILE_REGION_SIZE pDestTileRegionSize, IntPtr pSourceTileData, uint Flags);

		[PreserveSig]
		HRESULT ResizeTilePool(ID3D11Buffer pTilePool, ulong NewSizeInBytes);

		[PreserveSig]
		void TiledResourceBarrier(ID3D11DeviceChild pTiledResourceOrViewAccessBeforeBarrier, ID3D11DeviceChild pTiledResourceOrViewAccessAfterBarrier);

		[PreserveSig]
		bool IsAnnotationEnabled();

		[PreserveSig]
		void SetMarkerInt([MarshalAs(UnmanagedType.LPWStr)] string pLabel, int Data);

		[PreserveSig]
		void BeginEventInt([MarshalAs(UnmanagedType.LPWStr)] string pLabel, int Data);

		[PreserveSig]
		void EndEvent();
	}

	/*
	D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG
	D3D11_TILE_COPY_FLAG
	D3D11_TILE_MAPPING_FLAG
	D3D11_TILE_RANGE_FLAG
	
	D3D11_PACKED_MIP_DESC
	D3D11_SUBRESOURCE_TILING
	D3D11_TILE_REGION_SIZE
	D3D11_TILE_SHAPE
	D3D11_TILED_RESOURCE_COORDINATE
	*/
}