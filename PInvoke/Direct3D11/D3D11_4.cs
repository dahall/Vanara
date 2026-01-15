namespace Vanara.PInvoke;

public static partial class D3D11
{
	/// <summary/>
	[Flags]
	public enum D3D11_CRYPTO_SESSION_KEY_EXCHANGE_FLAGS : uint
	{
		/// <summary/>
		D3D11_CRYPTO_SESSION_KEY_EXCHANGE_FLAG_NONE = 0
	}

	/// <summary>
	/// Specifies a Direct3D 11 video feature or feature set to query about. When you want to query for the level to which an adapter
	/// supports a feature, pass one of these values to ID3D11VideoDevice2::CheckFeatureSupport.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/ne-d3d11_4-d3d11_feature_video typedef enum D3D11_FEATURE_VIDEO {
	// D3D11_FEATURE_VIDEO_DECODER_HISTOGRAM = 0 } ;
	[PInvokeData("d3d11_4.h", MSDNShortId = "NE:d3d11_4.D3D11_FEATURE_VIDEO")]
	public enum D3D11_FEATURE_VIDEO
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Retrieves the supported components, bin count, and counter bit depth for the a decode histogram with the specified decode
		/// profile, resolution, and format. The associated data structure is
		/// </para>
		/// <para>D3D11_FEATURE_DATA_VIDEO_DECODER_HISTOGRAM</para>
		/// <para>.</para>
		/// </summary>
		D3D11_FEATURE_VIDEO_DECODER_HISTOGRAM,
	}

	/// <summary>Specifies indices for arrays of per component histogram information.</summary>
	/// <remarks>
	/// The D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAGS is the flags enumeration used by D3D11_FEATURE_DATA_VIDEO_DECODER_HISTOGRAM to
	/// allow you to specify one or more components for which histogram data is queried.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/ne-d3d11_4-d3d11_video_decoder_histogram_component typedef enum
	// D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT { D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_Y = 0, D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_U =
	// 1, D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_V = 2, D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_R = 0,
	// D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_G = 1, D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_B = 2,
	// D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_A = 3 } ;
	[PInvokeData("d3d11_4.h", MSDNShortId = "NE:d3d11_4.D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT")]
	public enum D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>If the format is a YUV format, indicates a histogram for the Y component.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_Y = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>If the format is a YUV format, indicates a histogram for the U component.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_U,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>If the format is a YUV format, indicates a histogram for the V component.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_V,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>If the format is an RGB/BGR format, indicates a histogram for the R component.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_R = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>If the format is an RGB/BGR format, indicates a histogram for the G component.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_G,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>If the format is an RGB/BGR format, indicates a histogram for the B component.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_B,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>If the format has an alpha channel, indicates a histogram for the A component.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_A,
	}

	/// <summary>
	/// Flags for indicating a subset of components used with video decode histogram. This enumeration is used by the
	/// D3D12_FEATURE_DATA_VIDEO_DECODE_HISTOGRAM structure.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/ne-d3d11_4-d3d11_video_decoder_histogram_component_flags typedef enum
	// D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAGS { D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_NONE = 0,
	// D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_Y, D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_U,
	// D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_V, D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_R,
	// D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_G, D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_B,
	// D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_A } ;
	[PInvokeData("d3d11_4.h", MSDNShortId = "NE:d3d11_4.D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAGS")]
	[Flags]
	public enum D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAGS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No associated component.</para>
		/// </summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_NONE = 0,

		/// <summary>If the format is a YUV format, indicates the Y component.</summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_Y = 1 << D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT.D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_Y,

		/// <summary>If the format is a YUV format, indicates the U component.</summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_U = 1 << D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT.D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_U,

		/// <summary>If the format is a YUV format, indicates the V component.</summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_V = 1 << D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT.D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_V,

		/// <summary>If the format is an RGB/BGR format, indicates the R component.</summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_R = 1 << D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT.D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_R,

		/// <summary>If the format is an RGB/BGR format, indicates the G component.</summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_G = 1 << D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT.D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_G,

		/// <summary>If the format is an RGB/BGR format, indicates the B component.</summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_B = 1 << D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT.D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_B,

		/// <summary>If the format is an RGB/BGR format, indicates the A component.</summary>
		D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAG_A = 1 << D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT.D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_A,
	}

	/// <summary>
	/// The device interface represents a virtual adapter; it is used to create resources. <c>ID3D11Device4</c> adds new methods to those in
	/// ID3D11Device3, such as <c>RegisterDeviceRemovedEvent</c> and <c>UnregisterDeviceRemoved</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11device4
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11Device4")]
	[ComImport, Guid("8992ab71-02e6-4b8d-ba48-b056dcda42c4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Device4 : ID3D11Device3, ID3D11Device2, ID3D11Device1, ID3D11Device
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
		new void GetImmediateContext2(out ID3D11DeviceContext2 ppImmediateContext);

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
		new HRESULT CreateDeferredContext2([Optional] uint ContextFlags, out ID3D11DeviceContext2? ppDeferredContext);

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
		new void GetResourceTiling([In] ID3D11Resource pTiledResource, out uint pNumTilesForEntireResource, out D3D11_PACKED_MIP_DESC pPackedMipDesc,
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
		new HRESULT CheckMultisampleQualityLevels1(DXGI_FORMAT Format, uint SampleCount, D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG Flags, out uint pNumQualityLevels);

		/// <summary>Creates a 2D texture.</summary>
		/// <param name="pDesc1">
		/// <para>Type: <c>const D3D11_TEXTURE2D_DESC1*</c></para>
		/// <para>
		/// A pointer to a D3D11_TEXTURE2D_DESC1 structure that describes a 2D texture resource. To create a typeless resource that can be
		/// interpreted at runtime into different, compatible formats, specify a typeless format in the texture description. To generate
		/// mipmap levels automatically, set the number of mipmap levels to 0.
		/// </para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_SUBRESOURCE_DATA structures that describe subresources for the 2D texture resource. Applications
		/// can't specify <c>NULL</c> for <c>pInitialData</c> when creating IMMUTABLE resources (see D3D11_USAGE). If the resource is
		/// multisampled, <c>pInitialData</c> must be <c>NULL</c> because multisampled resources can't be initialized with data when they're created.
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the resource is undefined. In this
		/// case, you need to write the resource content some other way before the resource is read.
		/// </para>
		/// <para>
		/// You can determine the size of this array from values in the <c>MipLevels</c> and <c>ArraySize</c> members of the
		/// <c>D3D11_TEXTURE2D_DESC1</c> structure to which <c>pDesc1</c> points by using the following calculation:
		/// </para>
		/// <para>MipLevels * ArraySize</para>
		/// <para>For more info about this array size, see Remarks.</para>
		/// </param>
		/// <param name="ppTexture2D">
		/// <para>Type: <c>ID3D11Texture2D1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11Texture2D1 interface for the created texture. Set this parameter
		/// to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is <c>S_OK</c>. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateTexture2D1</c> creates a 2D texture resource, which can contain a number of 2D subresources. The number of subresources
		/// is specified in the texture description. All textures in a resource must have the same format, size, and number of mipmap levels.
		/// </para>
		/// <para>
		/// All resources are made up of one or more subresources. To load data into the texture, applications can supply the data initially
		/// as an array of D3D11_SUBRESOURCE_DATA structures pointed to by <c>pInitialData</c>, or they can use one of the D3DX texture
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
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createtexture2d1 HRESULT CreateTexture2D1(
		// [in] const D3D11_TEXTURE2D_DESC1 *pDesc1, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional]
		// ID3D11Texture2D1 **ppTexture2D );
		[PreserveSig]
		new HRESULT CreateTexture2D1(in D3D11_TEXTURE2D_DESC1 pDesc1, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[]? pInitialData, out ID3D11Texture2D1 ppTexture2D);

		/// <summary>Creates a 3D texture.</summary>
		/// <param name="pDesc1">
		/// <para>Type: <c>const D3D11_TEXTURE3D_DESC1*</c></para>
		/// <para>
		/// A pointer to a D3D11_TEXTURE3D_DESC1 structure that describes a 3D texture resource. To create a typeless resource that can be
		/// interpreted at runtime into different, compatible formats, specify a typeless format in the texture description. To generate
		/// mipmap levels automatically, set the number of mipmap levels to 0.
		/// </para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_SUBRESOURCE_DATA structures that describe subresources for the 3D texture resource. Applications
		/// can't specify <c>NULL</c> for <c>pInitialData</c> when creating IMMUTABLE resources (see D3D11_USAGE). If the resource is
		/// multisampled, <c>pInitialData</c> must be <c>NULL</c> because multisampled resources can't be initialized with data when they
		/// are created.
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the resource is undefined. In this
		/// case, you need to write the resource content some other way before the resource is read.
		/// </para>
		/// <para>
		/// You can determine the size of this array from the value in the <c>MipLevels</c> member of the <c>D3D11_TEXTURE3D_DESC1</c>
		/// structure to which <c>pDesc1</c> points. Arrays of 3D volume textures aren't supported.
		/// </para>
		/// <para>For more information about this array size, see Remarks.</para>
		/// </param>
		/// <param name="ppTexture3D">
		/// <para>Type: <c>ID3D11Texture3D1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11Texture3D1 interface for the created texture. Set this parameter
		/// to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is <c>S_OK</c>. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateTexture3D1</c> creates a 3D texture resource, which can contain a number of 3D subresources. The number of textures is
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
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createtexture3d1 HRESULT CreateTexture3D1(
		// [in] const D3D11_TEXTURE3D_DESC1 *pDesc1, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional]
		// ID3D11Texture3D1 **ppTexture3D );
		[PreserveSig]
		new HRESULT CreateTexture3D1(in D3D11_TEXTURE3D_DESC1 pDesc1, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[]? pInitialData, out ID3D11Texture3D1 ppTexture3D);

		/// <summary>
		/// Creates a rasterizer state object that informs the rasterizer stage how to behave and forces the sample count while UAV
		/// rendering or rasterizing.
		/// </summary>
		/// <param name="pRasterizerDesc">
		/// <para>Type: <c>const D3D11_RASTERIZER_DESC2*</c></para>
		/// <para>A pointer to a D3D11_RASTERIZER_DESC2 structure that describes the rasterizer state.</para>
		/// </param>
		/// <param name="ppRasterizerState">
		/// <para>Type: <c>ID3D11RasterizerState2**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11RasterizerState2 interface for the created rasterizer state
		/// object. Set this parameter to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the
		/// other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the rasterizer state object. See Direct3D 11 Return
		/// Codes for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createrasterizerstate2 HRESULT
		// CreateRasterizerState2( [in] const D3D11_RASTERIZER_DESC2 *pRasterizerDesc, [out, optional] ID3D11RasterizerState2
		// **ppRasterizerState );
		[PreserveSig]
		new HRESULT CreateRasterizerState2(in D3D11_RASTERIZER_DESC2 pRasterizerDesc, out ID3D11RasterizerState2 ppRasterizerState);

		/// <summary>Creates a shader-resource view for accessing data in a resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// Pointer to the resource that will serve as input to a shader. This resource must have been created with the
		/// D3D11_BIND_SHADER_RESOURCE flag.
		/// </para>
		/// </param>
		/// <param name="pDesc1">
		/// <para>Type: <c>const D3D11_SHADER_RESOURCE_VIEW_DESC1*</c></para>
		/// <para>
		/// A pointer to a D3D11_SHADER_RESOURCE_VIEW_DESC1 structure that describes a shader-resource view. Set this parameter to
		/// <c>NULL</c> to create a view that accesses the entire resource (using the format the resource was created with).
		/// </para>
		/// </param>
		/// <param name="ppSRView1">
		/// <para>Type: <c>ID3D11ShaderResourceView1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11ShaderResourceView1 interface for the created shader-resource
		/// view. Set this parameter to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the
		/// other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the shader-resource view. See Direct3D 11 Return
		/// Codes for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createshaderresourceview1 HRESULT
		// CreateShaderResourceView1( [in] ID3D11Resource *pResource, [in, optional] const D3D11_SHADER_RESOURCE_VIEW_DESC1 *pDesc1, [out,
		// optional] ID3D11ShaderResourceView1 **ppSRView1 );
		[PreserveSig]
		new HRESULT CreateShaderResourceView1([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_SHADER_RESOURCE_VIEW_DESC1> pDesc1, [Out, Optional] IntPtr ppSRView1);

		/// <summary>Creates a view for accessing an unordered access resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Pointer to an ID3D11Resource that represents a resources that will serve as an input to a shader.</para>
		/// </param>
		/// <param name="pDesc1">
		/// <para>Type: <c>const D3D11_UNORDERED_ACCESS_VIEW_DESC1*</c></para>
		/// <para>
		/// Pointer to a D3D11_UNORDERED_ACCESS_VIEW_DESC1 structure that represents an unordered-access view description. Set this
		/// parameter to <c>NULL</c> to create a view that accesses the entire resource (using the format the resource was created with).
		/// </para>
		/// </param>
		/// <param name="ppUAView1">
		/// <para>Type: <c>ID3D11UnorderedAccessView1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11UnorderedAccessView1 interface for the created unordered-access
		/// view. Set this parameter to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the
		/// other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the unordered-access view. See Direct3D 11 Return
		/// Codes for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createunorderedaccessview1 HRESULT
		// CreateUnorderedAccessView1( [in] ID3D11Resource *pResource, [in, optional] const D3D11_UNORDERED_ACCESS_VIEW_DESC1 *pDesc1, [out,
		// optional] ID3D11UnorderedAccessView1 **ppUAView1 );
		[PreserveSig]
		new HRESULT CreateUnorderedAccessView1([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_UNORDERED_ACCESS_VIEW_DESC1> pDesc1, [Out, Optional] IntPtr ppUAView1);

		/// <summary>Creates a render-target view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// Pointer to a ID3D11Resource that represents a render target. This resource must have been created with the
		/// D3D11_BIND_RENDER_TARGET flag.
		/// </para>
		/// </param>
		/// <param name="pDesc1">
		/// <para>Type: <c>const D3D11_RENDER_TARGET_VIEW_DESC1*</c></para>
		/// <para>
		/// Pointer to a D3D11_RENDER_TARGET_VIEW_DESC1 that represents a render-target view description. Set this parameter to <c>NULL</c>
		/// to create a view that accesses all of the subresources in mipmap level 0.
		/// </para>
		/// </param>
		/// <param name="ppRTView1">
		/// <para>Type: <c>ID3D11RenderTargetView1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11RenderTargetView1 interface for the created render-target view.
		/// Set this parameter to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the other
		/// input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>A render-target view can be bound to the output-merger stage by calling ID3D11DeviceContext::OMSetRenderTargets.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createrendertargetview1 HRESULT
		// CreateRenderTargetView1( [in] ID3D11Resource *pResource, [in, optional] const D3D11_RENDER_TARGET_VIEW_DESC1 *pDesc1, [out,
		// optional] ID3D11RenderTargetView1 **ppRTView1 );
		[PreserveSig]
		new HRESULT CreateRenderTargetView1([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_RENDER_TARGET_VIEW_DESC1> pDesc1, [Out, Optional] IntPtr ppRTView1);

		/// <summary>Creates a query object for querying information from the graphics processing unit (GPU).</summary>
		/// <param name="pQueryDesc1">
		/// <para>Type: <c>const D3D11_QUERY_DESC1*</c></para>
		/// <para>Pointer to a D3D11_QUERY_DESC1 structure that represents a query description.</para>
		/// </param>
		/// <param name="ppQuery1">
		/// <para>Type: <c>ID3D11Query1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11Query1 interface for the created query object. Set this parameter
		/// to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the query object. See Direct3D 11 Return Codes for
		/// other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createquery1 HRESULT CreateQuery1( [in]
		// const D3D11_QUERY_DESC1 *pQueryDesc1, [out, optional] ID3D11Query1 **ppQuery1 );
		[PreserveSig]
		new HRESULT CreateQuery1(in D3D11_QUERY_DESC1 pQueryDesc1, out ID3D11Query1 ppQuery1);

		/// <summary>Gets an immediate context, which can play back command lists.</summary>
		/// <param name="ppImmediateContext">
		/// <para>Type: <c>ID3D11DeviceContext3**</c></para>
		/// <para>Upon completion of the method, the passed pointer to an ID3D11DeviceContext3 interface pointer is initialized.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The <c>GetImmediateContext3</c> method outputs an ID3D11DeviceContext3 object that represents an immediate context, which is
		/// used to perform rendering that you want immediately submitted to a device. For most apps, an immediate context is the primary
		/// object that is used to draw your scene.
		/// </para>
		/// <para>
		/// The <c>GetImmediateContext3</c> method increments the reference count of the immediate context by one. Therefore, you must call
		/// Release on the returned interface pointer when you are done with it to avoid a memory leak.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-getimmediatecontext3 void
		// GetImmediateContext3( [out] ID3D11DeviceContext3 **ppImmediateContext );
		[PreserveSig]
		new void GetImmediateContext3(out ID3D11DeviceContext3 ppImmediateContext);

		/// <summary>Creates a deferred context, which can record command lists.</summary>
		/// <param name="ContextFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Reserved for future use. Pass 0.</para>
		/// </param>
		/// <param name="ppDeferredContext">
		/// <para>Type: <c>ID3D11DeviceContext3**</c></para>
		/// <para>Upon completion of the method, the passed pointer to an ID3D11DeviceContext3 interface pointer is initialized.</para>
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
		/// Returns <c>DXGI_ERROR_INVALID_CALL</c> if the <c>CreateDeferredContext3</c> method can't be called from the current context. For
		/// example, if the device was created with the D3D11_CREATE_DEVICE_SINGLETHREADED value, <c>CreateDeferredContext3</c> returns <c>DXGI_ERROR_INVALID_CALL</c>.
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
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createdeferredcontext3 HRESULT
		// CreateDeferredContext3( UINT ContextFlags, [out, optional] ID3D11DeviceContext3 **ppDeferredContext );
		[PreserveSig]
		new HRESULT CreateDeferredContext3(uint ContextFlags, out ID3D11DeviceContext3 ppDeferredContext);

		/// <summary>
		/// Copies data into a D3D11_USAGE_DEFAULT texture which was mapped using ID3D11DeviceContext3::Map while providing a NULL
		/// D3D11_MAPPED_SUBRESOURCE parameter.
		/// </summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the destination resource (an ID3D11Resource).</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A zero-based index, that identifies the destination subresource. For more details, see D3D11CalcSubresource.</para>
		/// </param>
		/// <param name="pDstBox">
		/// <para>Type: <c>const D3D11_BOX*</c></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data into. If NULL, the data is
		/// written to the destination subresource with no offset. The dimensions of the source must fit the destination (see D3D11_BOX).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, this method doesn't perform any operation.
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
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The provided resource must be a D3D11_USAGE_DEFAULT texture which was mapped for writing by a previous call to
		/// ID3D11DeviceContext3::Map while providing a NULL D3D11_MAPPED_SUBRESOURCE parameter.
		/// </para>
		/// <para>
		/// This API is intended for calling at high frequency. Callers can reduce memory by making iterative calls that update progressive
		/// regions of the texture, while provide a small buffer during each call. It is most efficient to specify large enough regions,
		/// though, because this enables D3D to fill whole cache lines in the texture before returning.
		/// </para>
		/// <para>
		/// For efficiency, ensure the bounds and alignment of the extents within the box are ( 64 / [bytes per pixel] ) pixels
		/// horizontally. Vertical bounds and alignment should be 2 rows, except when 1-byte-per-pixel formats are used, in which case 4
		/// rows are recommended. Single depth slices per call are handled efficiently. It is recommended but not necessary to provide
		/// pointers and strides which are 128-byte aligned.
		/// </para>
		/// <para>
		/// When writing to sub mipmap levels, it is recommended to use larger width and heights than described above. This is because small
		/// mipmap levels may actually be stored within a larger block of memory, with an opaque amount of offsetting which can interfere
		/// with alignment to cache lines.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-writetosubresource void WriteToSubresource(
		// [in] ID3D11Resource *pDstResource, [in] UINT DstSubresource, [in, optional] const D3D11_BOX *pDstBox, [in] const void *pSrcData,
		// [in] UINT SrcRowPitch, [in] UINT SrcDepthPitch );
		[PreserveSig]
		new void WriteToSubresource([In] ID3D11Resource pDstResource, uint DstSubresource, [In, Optional] StructPointer<D3D11_BOX> pDstBox, [In] IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);

		/// <summary>
		/// Copies data from a D3D11_USAGE_DEFAULT texture which was mapped using ID3D11DeviceContext3::Map while providing a NULL
		/// D3D11_MAPPED_SUBRESOURCE parameter.
		/// </summary>
		/// <param name="pDstData">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the destination data in memory.</para>
		/// </param>
		/// <param name="DstRowPitch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of one row of the destination data.</para>
		/// </param>
		/// <param name="DstDepthPitch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of one depth slice of destination data.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the source resource (see ID3D11Resource).</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A zero-based index, that identifies the destination subresource. For more details, see D3D11CalcSubresource.</para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <c>const D3D11_BOX*</c></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data from. If NULL, the data is
		/// read from the destination subresource with no offset. The dimensions of the destination must fit the destination (see D3D11_BOX).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, this method doesn't perform any operation.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The provided resource must be a D3D11_USAGE_DEFAULT texture which was mapped for writing by a previous call to
		/// ID3D11DeviceContext3::Map while providing a NULL D3D11_MAPPED_SUBRESOURCE parameter.
		/// </para>
		/// <para>
		/// This API is intended for calling at high frequency. Callers can reduce memory by making iterative calls that update progressive
		/// regions of the texture, while provide a small buffer during each call. It is most efficient to specify large enough regions,
		/// though, because this enables D3D to fill whole cache lines in the texture before returning.
		/// </para>
		/// <para>
		/// For efficiency, ensure the bounds and alignment of the extents within the box are ( 64 / [Bytes per pixel] ) pixels
		/// horizontally. Vertical bounds and alignment should be 2 rows, except when 1-byte-per-pixel formats are used, in which case 4
		/// rows are recommended. Single depth slices per call are handled efficiently. It is recommended but not necessary to provide
		/// pointers and strides which are 128-byte aligned.
		/// </para>
		/// <para>
		/// When reading from sub mipmap levels, it is recommended to use larger width and heights than described above. This is because
		/// small mipmap levels may actually be stored within a larger block of memory, with an opaque amount of offsetting which can
		/// interfere with alignment to cache lines.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-readfromsubresource void
		// ReadFromSubresource( [out] void *pDstData, [in] UINT DstRowPitch, [in] UINT DstDepthPitch, [in] ID3D11Resource *pSrcResource,
		// [in] UINT SrcSubresource, [in, optional] const D3D11_BOX *pSrcBox );
		[PreserveSig]
		new void ReadFromSubresource(out IntPtr pDstData, uint DstRowPitch, uint DstDepthPitch, [In] ID3D11Resource pSrcResource, uint SrcSubresource, [In, Optional] StructPointer<D3D11_BOX> pSrcBox);

		/// <summary>
		/// Registers the "device removed" event and indicates when a Direct3D device has become removed for any reason, using an
		/// asynchronous notification mechanism.
		/// </summary>
		/// <param name="hEvent">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>The handle to the "device removed" event.</para>
		/// </param>
		/// <param name="pdwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to information about the "device removed" event, which can be used in UnregisterDeviceRemoved to unregister the event.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>See Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Indicates when a Direct3D device has become removed for any reason, using an asynchronous notification mechanism, rather than as
		/// an HRESULT from Present. The reason for device removal can be retrieved using ID3D11Device::GetDeviceRemovedReason after being
		/// notified of the occurrence.
		/// </para>
		/// <para>
		/// Applications register and un-register a Win32 event handle with a particular device. That event handle will be signaled when the
		/// device becomes removed. A poll into the device's <c>ID3D11Device::GetDeviceRemovedReason</c> method indicates that the device is removed.
		/// </para>
		/// <para>ISignalableNotifier or SetThreadpoolWait can be used by UWP apps.</para>
		/// <para>
		/// When the graphics device is lost, the app or title will receive the graphics event, so that the app or title knows that its
		/// graphics device is no longer valid and it is safe for the app or title to re-create its DirectX devices. In response to this
		/// event, the app or title needs to re-create its rendering device and pass it into a SetRenderingDevice call on the composition
		/// graphics device objects.
		/// </para>
		/// <para>
		/// After setting this new rendering device, the app or title needs to redraw content of all the pre-existing surfaces after the
		/// composition graphics device's <c>OnRenderingDeviceReplaced</c> event is fired.
		/// </para>
		/// <para>This method supports Composition for device loss.</para>
		/// <para>
		/// The event is not signaled when it is most ideal to re-create. So, instead, we recommend iterating through the adapter ordinals
		/// and creating the first ordinal that will succeed.
		/// </para>
		/// <para>The application can register an event with the device. The application will be signaled when the device becomes removed.</para>
		/// <para>
		/// If the device is already removed, calls to <c>RegisterDeviceRemovedEvent</c> will signal the event immediately. No
		/// device-removed error code will be returned from <c>RegisterDeviceRemovedEvent</c>.
		/// </para>
		/// <para>
		/// Each "device removed" event is never signaled, or is signaled only once. These events are not signaled during device
		/// destruction. These events are unregistered during destruction.
		/// </para>
		/// <para>The semantics of <c>RegisterDeviceRemovedEvent</c> are similar to IDXGIFactory2::RegisterOcclusionStatusEvent.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11device4-registerdeviceremovedevent HRESULT
		// RegisterDeviceRemovedEvent( [in] HANDLE hEvent, [out] DWORD *pdwCookie );
		[PreserveSig]
		HRESULT RegisterDeviceRemovedEvent([In] HEVENT hEvent, out uint pdwCookie);

		/// <summary>Unregisters the "device removed" event.</summary>
		/// <param name="dwCookie">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Information about the "device removed" event, retrieved during a successful RegisterDeviceRemovedEvent call.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>See RegisterDeviceRemovedEvent.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11device4-unregisterdeviceremoved void
		// UnregisterDeviceRemoved( [in] DWORD dwCookie );
		[PreserveSig]
		void UnregisterDeviceRemoved(uint dwCookie);
	}

	/// <summary>
	/// <para>
	/// The device interface represents a virtual adapter; it is used to create resources. <c>ID3D11Device5</c> adds new methods to those in ID3D11Device4.
	/// </para>
	/// <para>
	/// <c>Note</c>  This interface, introduced in the Windows 10 Creators Update, is the latest version of the ID3D11Device interface.
	/// Applications targetting Windows 10 Creators Update should use this interface instead of earlier versions.
	/// </para>
	/// <para></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11device5
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11Device5")]
	[ComImport, Guid("8ffde202-a0e7-45df-9e01-e837801b5ea0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Device5 : ID3D11Device4, ID3D11Device3, ID3D11Device2, ID3D11Device1, ID3D11Device
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
		new void GetImmediateContext2(out ID3D11DeviceContext2 ppImmediateContext);

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
		new HRESULT CreateDeferredContext2([Optional] uint ContextFlags, out ID3D11DeviceContext2? ppDeferredContext);

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
		new void GetResourceTiling([In] ID3D11Resource pTiledResource, out uint pNumTilesForEntireResource, out D3D11_PACKED_MIP_DESC pPackedMipDesc,
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
		new HRESULT CheckMultisampleQualityLevels1(DXGI_FORMAT Format, uint SampleCount, D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG Flags, out uint pNumQualityLevels);

		/// <summary>Creates a 2D texture.</summary>
		/// <param name="pDesc1">
		/// <para>Type: <c>const D3D11_TEXTURE2D_DESC1*</c></para>
		/// <para>
		/// A pointer to a D3D11_TEXTURE2D_DESC1 structure that describes a 2D texture resource. To create a typeless resource that can be
		/// interpreted at runtime into different, compatible formats, specify a typeless format in the texture description. To generate
		/// mipmap levels automatically, set the number of mipmap levels to 0.
		/// </para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_SUBRESOURCE_DATA structures that describe subresources for the 2D texture resource. Applications
		/// can't specify <c>NULL</c> for <c>pInitialData</c> when creating IMMUTABLE resources (see D3D11_USAGE). If the resource is
		/// multisampled, <c>pInitialData</c> must be <c>NULL</c> because multisampled resources can't be initialized with data when they're created.
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the resource is undefined. In this
		/// case, you need to write the resource content some other way before the resource is read.
		/// </para>
		/// <para>
		/// You can determine the size of this array from values in the <c>MipLevels</c> and <c>ArraySize</c> members of the
		/// <c>D3D11_TEXTURE2D_DESC1</c> structure to which <c>pDesc1</c> points by using the following calculation:
		/// </para>
		/// <para>MipLevels * ArraySize</para>
		/// <para>For more info about this array size, see Remarks.</para>
		/// </param>
		/// <param name="ppTexture2D">
		/// <para>Type: <c>ID3D11Texture2D1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11Texture2D1 interface for the created texture. Set this parameter
		/// to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is <c>S_OK</c>. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateTexture2D1</c> creates a 2D texture resource, which can contain a number of 2D subresources. The number of subresources
		/// is specified in the texture description. All textures in a resource must have the same format, size, and number of mipmap levels.
		/// </para>
		/// <para>
		/// All resources are made up of one or more subresources. To load data into the texture, applications can supply the data initially
		/// as an array of D3D11_SUBRESOURCE_DATA structures pointed to by <c>pInitialData</c>, or they can use one of the D3DX texture
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
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createtexture2d1 HRESULT CreateTexture2D1(
		// [in] const D3D11_TEXTURE2D_DESC1 *pDesc1, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional]
		// ID3D11Texture2D1 **ppTexture2D );
		[PreserveSig]
		new HRESULT CreateTexture2D1(in D3D11_TEXTURE2D_DESC1 pDesc1, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[]? pInitialData, out ID3D11Texture2D1 ppTexture2D);

		/// <summary>Creates a 3D texture.</summary>
		/// <param name="pDesc1">
		/// <para>Type: <c>const D3D11_TEXTURE3D_DESC1*</c></para>
		/// <para>
		/// A pointer to a D3D11_TEXTURE3D_DESC1 structure that describes a 3D texture resource. To create a typeless resource that can be
		/// interpreted at runtime into different, compatible formats, specify a typeless format in the texture description. To generate
		/// mipmap levels automatically, set the number of mipmap levels to 0.
		/// </para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_SUBRESOURCE_DATA structures that describe subresources for the 3D texture resource. Applications
		/// can't specify <c>NULL</c> for <c>pInitialData</c> when creating IMMUTABLE resources (see D3D11_USAGE). If the resource is
		/// multisampled, <c>pInitialData</c> must be <c>NULL</c> because multisampled resources can't be initialized with data when they
		/// are created.
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the resource is undefined. In this
		/// case, you need to write the resource content some other way before the resource is read.
		/// </para>
		/// <para>
		/// You can determine the size of this array from the value in the <c>MipLevels</c> member of the <c>D3D11_TEXTURE3D_DESC1</c>
		/// structure to which <c>pDesc1</c> points. Arrays of 3D volume textures aren't supported.
		/// </para>
		/// <para>For more information about this array size, see Remarks.</para>
		/// </param>
		/// <param name="ppTexture3D">
		/// <para>Type: <c>ID3D11Texture3D1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11Texture3D1 interface for the created texture. Set this parameter
		/// to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is <c>S_OK</c>. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateTexture3D1</c> creates a 3D texture resource, which can contain a number of 3D subresources. The number of textures is
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
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createtexture3d1 HRESULT CreateTexture3D1(
		// [in] const D3D11_TEXTURE3D_DESC1 *pDesc1, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional]
		// ID3D11Texture3D1 **ppTexture3D );
		[PreserveSig]
		new HRESULT CreateTexture3D1(in D3D11_TEXTURE3D_DESC1 pDesc1, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[]? pInitialData, out ID3D11Texture3D1 ppTexture3D);

		/// <summary>
		/// Creates a rasterizer state object that informs the rasterizer stage how to behave and forces the sample count while UAV
		/// rendering or rasterizing.
		/// </summary>
		/// <param name="pRasterizerDesc">
		/// <para>Type: <c>const D3D11_RASTERIZER_DESC2*</c></para>
		/// <para>A pointer to a D3D11_RASTERIZER_DESC2 structure that describes the rasterizer state.</para>
		/// </param>
		/// <param name="ppRasterizerState">
		/// <para>Type: <c>ID3D11RasterizerState2**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11RasterizerState2 interface for the created rasterizer state
		/// object. Set this parameter to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the
		/// other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the rasterizer state object. See Direct3D 11 Return
		/// Codes for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createrasterizerstate2 HRESULT
		// CreateRasterizerState2( [in] const D3D11_RASTERIZER_DESC2 *pRasterizerDesc, [out, optional] ID3D11RasterizerState2
		// **ppRasterizerState );
		[PreserveSig]
		new HRESULT CreateRasterizerState2(in D3D11_RASTERIZER_DESC2 pRasterizerDesc, out ID3D11RasterizerState2 ppRasterizerState);

		/// <summary>Creates a shader-resource view for accessing data in a resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// Pointer to the resource that will serve as input to a shader. This resource must have been created with the
		/// D3D11_BIND_SHADER_RESOURCE flag.
		/// </para>
		/// </param>
		/// <param name="pDesc1">
		/// <para>Type: <c>const D3D11_SHADER_RESOURCE_VIEW_DESC1*</c></para>
		/// <para>
		/// A pointer to a D3D11_SHADER_RESOURCE_VIEW_DESC1 structure that describes a shader-resource view. Set this parameter to
		/// <c>NULL</c> to create a view that accesses the entire resource (using the format the resource was created with).
		/// </para>
		/// </param>
		/// <param name="ppSRView1">
		/// <para>Type: <c>ID3D11ShaderResourceView1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11ShaderResourceView1 interface for the created shader-resource
		/// view. Set this parameter to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the
		/// other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the shader-resource view. See Direct3D 11 Return
		/// Codes for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createshaderresourceview1 HRESULT
		// CreateShaderResourceView1( [in] ID3D11Resource *pResource, [in, optional] const D3D11_SHADER_RESOURCE_VIEW_DESC1 *pDesc1, [out,
		// optional] ID3D11ShaderResourceView1 **ppSRView1 );
		[PreserveSig]
		new HRESULT CreateShaderResourceView1([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_SHADER_RESOURCE_VIEW_DESC1> pDesc1, [Out, Optional] IntPtr ppSRView1);

		/// <summary>Creates a view for accessing an unordered access resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Pointer to an ID3D11Resource that represents a resources that will serve as an input to a shader.</para>
		/// </param>
		/// <param name="pDesc1">
		/// <para>Type: <c>const D3D11_UNORDERED_ACCESS_VIEW_DESC1*</c></para>
		/// <para>
		/// Pointer to a D3D11_UNORDERED_ACCESS_VIEW_DESC1 structure that represents an unordered-access view description. Set this
		/// parameter to <c>NULL</c> to create a view that accesses the entire resource (using the format the resource was created with).
		/// </para>
		/// </param>
		/// <param name="ppUAView1">
		/// <para>Type: <c>ID3D11UnorderedAccessView1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11UnorderedAccessView1 interface for the created unordered-access
		/// view. Set this parameter to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the
		/// other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the unordered-access view. See Direct3D 11 Return
		/// Codes for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createunorderedaccessview1 HRESULT
		// CreateUnorderedAccessView1( [in] ID3D11Resource *pResource, [in, optional] const D3D11_UNORDERED_ACCESS_VIEW_DESC1 *pDesc1, [out,
		// optional] ID3D11UnorderedAccessView1 **ppUAView1 );
		[PreserveSig]
		new HRESULT CreateUnorderedAccessView1([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_UNORDERED_ACCESS_VIEW_DESC1> pDesc1, [Out, Optional] IntPtr ppUAView1);

		/// <summary>Creates a render-target view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// Pointer to a ID3D11Resource that represents a render target. This resource must have been created with the
		/// D3D11_BIND_RENDER_TARGET flag.
		/// </para>
		/// </param>
		/// <param name="pDesc1">
		/// <para>Type: <c>const D3D11_RENDER_TARGET_VIEW_DESC1*</c></para>
		/// <para>
		/// Pointer to a D3D11_RENDER_TARGET_VIEW_DESC1 that represents a render-target view description. Set this parameter to <c>NULL</c>
		/// to create a view that accesses all of the subresources in mipmap level 0.
		/// </para>
		/// </param>
		/// <param name="ppRTView1">
		/// <para>Type: <c>ID3D11RenderTargetView1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11RenderTargetView1 interface for the created render-target view.
		/// Set this parameter to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the other
		/// input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>A render-target view can be bound to the output-merger stage by calling ID3D11DeviceContext::OMSetRenderTargets.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createrendertargetview1 HRESULT
		// CreateRenderTargetView1( [in] ID3D11Resource *pResource, [in, optional] const D3D11_RENDER_TARGET_VIEW_DESC1 *pDesc1, [out,
		// optional] ID3D11RenderTargetView1 **ppRTView1 );
		[PreserveSig]
		new HRESULT CreateRenderTargetView1([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_RENDER_TARGET_VIEW_DESC1> pDesc1, [Out, Optional] IntPtr ppRTView1);

		/// <summary>Creates a query object for querying information from the graphics processing unit (GPU).</summary>
		/// <param name="pQueryDesc1">
		/// <para>Type: <c>const D3D11_QUERY_DESC1*</c></para>
		/// <para>Pointer to a D3D11_QUERY_DESC1 structure that represents a query description.</para>
		/// </param>
		/// <param name="ppQuery1">
		/// <para>Type: <c>ID3D11Query1**</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a ID3D11Query1 interface for the created query object. Set this parameter
		/// to <c>NULL</c> to validate the other input parameters (the method will return <c>S_FALSE</c> if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the query object. See Direct3D 11 Return Codes for
		/// other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createquery1 HRESULT CreateQuery1( [in]
		// const D3D11_QUERY_DESC1 *pQueryDesc1, [out, optional] ID3D11Query1 **ppQuery1 );
		[PreserveSig]
		new HRESULT CreateQuery1(in D3D11_QUERY_DESC1 pQueryDesc1, out ID3D11Query1 ppQuery1);

		/// <summary>Gets an immediate context, which can play back command lists.</summary>
		/// <param name="ppImmediateContext">
		/// <para>Type: <c>ID3D11DeviceContext3**</c></para>
		/// <para>Upon completion of the method, the passed pointer to an ID3D11DeviceContext3 interface pointer is initialized.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The <c>GetImmediateContext3</c> method outputs an ID3D11DeviceContext3 object that represents an immediate context, which is
		/// used to perform rendering that you want immediately submitted to a device. For most apps, an immediate context is the primary
		/// object that is used to draw your scene.
		/// </para>
		/// <para>
		/// The <c>GetImmediateContext3</c> method increments the reference count of the immediate context by one. Therefore, you must call
		/// Release on the returned interface pointer when you are done with it to avoid a memory leak.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-getimmediatecontext3 void
		// GetImmediateContext3( [out] ID3D11DeviceContext3 **ppImmediateContext );
		[PreserveSig]
		new void GetImmediateContext3(out ID3D11DeviceContext3 ppImmediateContext);

		/// <summary>Creates a deferred context, which can record command lists.</summary>
		/// <param name="ContextFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Reserved for future use. Pass 0.</para>
		/// </param>
		/// <param name="ppDeferredContext">
		/// <para>Type: <c>ID3D11DeviceContext3**</c></para>
		/// <para>Upon completion of the method, the passed pointer to an ID3D11DeviceContext3 interface pointer is initialized.</para>
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
		/// Returns <c>DXGI_ERROR_INVALID_CALL</c> if the <c>CreateDeferredContext3</c> method can't be called from the current context. For
		/// example, if the device was created with the D3D11_CREATE_DEVICE_SINGLETHREADED value, <c>CreateDeferredContext3</c> returns <c>DXGI_ERROR_INVALID_CALL</c>.
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
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-createdeferredcontext3 HRESULT
		// CreateDeferredContext3( UINT ContextFlags, [out, optional] ID3D11DeviceContext3 **ppDeferredContext );
		[PreserveSig]
		new HRESULT CreateDeferredContext3(uint ContextFlags, out ID3D11DeviceContext3 ppDeferredContext);

		/// <summary>
		/// Copies data into a D3D11_USAGE_DEFAULT texture which was mapped using ID3D11DeviceContext3::Map while providing a NULL
		/// D3D11_MAPPED_SUBRESOURCE parameter.
		/// </summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the destination resource (an ID3D11Resource).</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A zero-based index, that identifies the destination subresource. For more details, see D3D11CalcSubresource.</para>
		/// </param>
		/// <param name="pDstBox">
		/// <para>Type: <c>const D3D11_BOX*</c></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data into. If NULL, the data is
		/// written to the destination subresource with no offset. The dimensions of the source must fit the destination (see D3D11_BOX).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, this method doesn't perform any operation.
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
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The provided resource must be a D3D11_USAGE_DEFAULT texture which was mapped for writing by a previous call to
		/// ID3D11DeviceContext3::Map while providing a NULL D3D11_MAPPED_SUBRESOURCE parameter.
		/// </para>
		/// <para>
		/// This API is intended for calling at high frequency. Callers can reduce memory by making iterative calls that update progressive
		/// regions of the texture, while provide a small buffer during each call. It is most efficient to specify large enough regions,
		/// though, because this enables D3D to fill whole cache lines in the texture before returning.
		/// </para>
		/// <para>
		/// For efficiency, ensure the bounds and alignment of the extents within the box are ( 64 / [bytes per pixel] ) pixels
		/// horizontally. Vertical bounds and alignment should be 2 rows, except when 1-byte-per-pixel formats are used, in which case 4
		/// rows are recommended. Single depth slices per call are handled efficiently. It is recommended but not necessary to provide
		/// pointers and strides which are 128-byte aligned.
		/// </para>
		/// <para>
		/// When writing to sub mipmap levels, it is recommended to use larger width and heights than described above. This is because small
		/// mipmap levels may actually be stored within a larger block of memory, with an opaque amount of offsetting which can interfere
		/// with alignment to cache lines.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-writetosubresource void WriteToSubresource(
		// [in] ID3D11Resource *pDstResource, [in] UINT DstSubresource, [in, optional] const D3D11_BOX *pDstBox, [in] const void *pSrcData,
		// [in] UINT SrcRowPitch, [in] UINT SrcDepthPitch );
		[PreserveSig]
		new void WriteToSubresource([In] ID3D11Resource pDstResource, uint DstSubresource, [In, Optional] StructPointer<D3D11_BOX> pDstBox, [In] IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);

		/// <summary>
		/// Copies data from a D3D11_USAGE_DEFAULT texture which was mapped using ID3D11DeviceContext3::Map while providing a NULL
		/// D3D11_MAPPED_SUBRESOURCE parameter.
		/// </summary>
		/// <param name="pDstData">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the destination data in memory.</para>
		/// </param>
		/// <param name="DstRowPitch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of one row of the destination data.</para>
		/// </param>
		/// <param name="DstDepthPitch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of one depth slice of destination data.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the source resource (see ID3D11Resource).</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A zero-based index, that identifies the destination subresource. For more details, see D3D11CalcSubresource.</para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <c>const D3D11_BOX*</c></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data from. If NULL, the data is
		/// read from the destination subresource with no offset. The dimensions of the destination must fit the destination (see D3D11_BOX).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, this method doesn't perform any operation.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The provided resource must be a D3D11_USAGE_DEFAULT texture which was mapped for writing by a previous call to
		/// ID3D11DeviceContext3::Map while providing a NULL D3D11_MAPPED_SUBRESOURCE parameter.
		/// </para>
		/// <para>
		/// This API is intended for calling at high frequency. Callers can reduce memory by making iterative calls that update progressive
		/// regions of the texture, while provide a small buffer during each call. It is most efficient to specify large enough regions,
		/// though, because this enables D3D to fill whole cache lines in the texture before returning.
		/// </para>
		/// <para>
		/// For efficiency, ensure the bounds and alignment of the extents within the box are ( 64 / [Bytes per pixel] ) pixels
		/// horizontally. Vertical bounds and alignment should be 2 rows, except when 1-byte-per-pixel formats are used, in which case 4
		/// rows are recommended. Single depth slices per call are handled efficiently. It is recommended but not necessary to provide
		/// pointers and strides which are 128-byte aligned.
		/// </para>
		/// <para>
		/// When reading from sub mipmap levels, it is recommended to use larger width and heights than described above. This is because
		/// small mipmap levels may actually be stored within a larger block of memory, with an opaque amount of offsetting which can
		/// interfere with alignment to cache lines.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11device3-readfromsubresource void
		// ReadFromSubresource( [out] void *pDstData, [in] UINT DstRowPitch, [in] UINT DstDepthPitch, [in] ID3D11Resource *pSrcResource,
		// [in] UINT SrcSubresource, [in, optional] const D3D11_BOX *pSrcBox );
		[PreserveSig]
		new void ReadFromSubresource(out IntPtr pDstData, uint DstRowPitch, uint DstDepthPitch, [In] ID3D11Resource pSrcResource, uint SrcSubresource, [In, Optional] StructPointer<D3D11_BOX> pSrcBox);

		/// <summary>
		/// Registers the "device removed" event and indicates when a Direct3D device has become removed for any reason, using an
		/// asynchronous notification mechanism.
		/// </summary>
		/// <param name="hEvent">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>The handle to the "device removed" event.</para>
		/// </param>
		/// <param name="pdwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to information about the "device removed" event, which can be used in UnregisterDeviceRemoved to unregister the event.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>See Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Indicates when a Direct3D device has become removed for any reason, using an asynchronous notification mechanism, rather than as
		/// an HRESULT from Present. The reason for device removal can be retrieved using ID3D11Device::GetDeviceRemovedReason after being
		/// notified of the occurrence.
		/// </para>
		/// <para>
		/// Applications register and un-register a Win32 event handle with a particular device. That event handle will be signaled when the
		/// device becomes removed. A poll into the device's <c>ID3D11Device::GetDeviceRemovedReason</c> method indicates that the device is removed.
		/// </para>
		/// <para>ISignalableNotifier or SetThreadpoolWait can be used by UWP apps.</para>
		/// <para>
		/// When the graphics device is lost, the app or title will receive the graphics event, so that the app or title knows that its
		/// graphics device is no longer valid and it is safe for the app or title to re-create its DirectX devices. In response to this
		/// event, the app or title needs to re-create its rendering device and pass it into a SetRenderingDevice call on the composition
		/// graphics device objects.
		/// </para>
		/// <para>
		/// After setting this new rendering device, the app or title needs to redraw content of all the pre-existing surfaces after the
		/// composition graphics device's <c>OnRenderingDeviceReplaced</c> event is fired.
		/// </para>
		/// <para>This method supports Composition for device loss.</para>
		/// <para>
		/// The event is not signaled when it is most ideal to re-create. So, instead, we recommend iterating through the adapter ordinals
		/// and creating the first ordinal that will succeed.
		/// </para>
		/// <para>The application can register an event with the device. The application will be signaled when the device becomes removed.</para>
		/// <para>
		/// If the device is already removed, calls to <c>RegisterDeviceRemovedEvent</c> will signal the event immediately. No
		/// device-removed error code will be returned from <c>RegisterDeviceRemovedEvent</c>.
		/// </para>
		/// <para>
		/// Each "device removed" event is never signaled, or is signaled only once. These events are not signaled during device
		/// destruction. These events are unregistered during destruction.
		/// </para>
		/// <para>The semantics of <c>RegisterDeviceRemovedEvent</c> are similar to IDXGIFactory2::RegisterOcclusionStatusEvent.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11device4-registerdeviceremovedevent HRESULT
		// RegisterDeviceRemovedEvent( [in] HANDLE hEvent, [out] DWORD *pdwCookie );
		[PreserveSig]
		new HRESULT RegisterDeviceRemovedEvent([In] HEVENT hEvent, out uint pdwCookie);

		/// <summary>Unregisters the "device removed" event.</summary>
		/// <param name="dwCookie">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Information about the "device removed" event, retrieved during a successful RegisterDeviceRemovedEvent call.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>See RegisterDeviceRemovedEvent.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11device4-unregisterdeviceremoved void
		// UnregisterDeviceRemoved( [in] DWORD dwCookie );
		[PreserveSig]
		new void UnregisterDeviceRemoved(uint dwCookie);

		/// <summary>
		/// <para>Opens a handle for a shared fence by using HANDLE and REFIID.</para>
		/// <para>
		/// This member function is a limited version of the Direct3D 12 ID3D12Device::OpenSharedHandle member function, and applies between
		/// Direct3D 11 and Direct3D 12 in interop scenarios. Unlike <c>ID3D12Device::OpenSharedHandle</c> which operates on resources,
		/// heaps, and fences, the <c>ID3D11Device5::OpenSharedFence</c> function only operates on fences; in Direct3D 11, shared resources
		/// are opened with the ID3D11Device::OpenSharedResource1 member function.
		/// </para>
		/// </summary>
		/// <param name="hFence">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>The handle that was returned by a call to ID3D11Fence::CreateSharedHandle or ID3D12Device::CreateSharedHandle.</para>
		/// </param>
		/// <param name="ReturnedInterface">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// The globally unique identifier ( <c>GUID</c>) for the ID3D11Fence interface. The <c>REFIID</c>, or <c>GUID</c>, of the interface
		/// can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D11Fence) will get the <c>GUID</c> of the interface to
		/// the fence.
		/// </para>
		/// </param>
		/// <param name="ppFence">
		/// <para>Type: <c>void**</c></para>
		/// <para>A pointer to a memory block that receives a pointer to the ID3D11Fence interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11device5-opensharedfence HRESULT OpenSharedFence(
		// [in] HANDLE hFence, REFIID ReturnedInterface, [out, optional] void **ppFence );
		[PreserveSig]
		HRESULT OpenSharedFence([In] HANDLE hFence, in Guid ReturnedInterface, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object? ppFence);

		/// <summary>
		/// <para>Creates a fence object.</para>
		/// <para>
		/// This member function is equivalent to the Direct3D 12 ID3D12Device::CreateFence member function, and applies between Direct3D 11
		/// and Direct3D 12 in interop scenarios.
		/// </para>
		/// </summary>
		/// <param name="InitialValue">
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The initial value for the fence.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <c>D3D11_FENCE_FLAG</c></para>
		/// <para>
		/// A combination of D3D11_FENCE_FLAG-typed values that are combined by using a bitwise OR operation. The resulting value specifies
		/// options for the fence.
		/// </para>
		/// </param>
		/// <param name="ReturnedInterface">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// The globally unique identifier ( <c>GUID</c>) for the fence interface (ID3D11Fence). The <c>REFIID</c>, or <c>GUID</c>, of the
		/// interface to the fence can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D11Fence) will get the
		/// <c>GUID</c> of the interface to a fence.
		/// </para>
		/// </param>
		/// <param name="ppFence">
		/// <para>Type: <c>void**</c></para>
		/// <para>A pointer to a memory block that receives a pointer to the ID3D11Fence interface that is used to access the fence.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11device5-createfence HRESULT CreateFence( UINT64
		// InitialValue, D3D11_FENCE_FLAG Flags, REFIID ReturnedInterface, [out] void **ppFence );
		[PreserveSig]
		HRESULT CreateFence(ulong InitialValue, D3D11_FENCE_FLAG Flags, in Guid ReturnedInterface, [MarshalAs(UnmanagedType.Interface)] out object ppFence);
	}

	/// <summary>Provides threading protection for critical sections of a multi-threaded application.</summary>
	/// <remarks>
	/// <para>
	/// This interface is obtained by querying it from an immediate device context created with the ID3D11DeviceContext (or later versions
	/// of this) interface using IUnknown::QueryInterface.
	/// </para>
	/// <para>
	/// Unlike D3D10, there is no multithreaded layer in D3D11. By default, multithread protection is turned off. Use
	/// SetMultithreadProtected to turn it on, then Enter and Leave to encapsulate graphics commands that must be executed in a specific order.
	/// </para>
	/// <para>
	/// By default in D3D11, applications can only use one thread with the immediate context at a time. But, applications can use this
	/// interface to change that restriction. The interface can turn on threading protection for the immediate context, which will increase
	/// the overhead of each immediate context call in order to share one context with multiple threads.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11multithread
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11Multithread")]
	[ComImport, Guid("9b7e4e00-342c-4106-a19f-4f2704f689f0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Multithread
	{
		/// <summary>Enter a device's critical section.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If SetMultithreadProtected is set to true, then entering a device's critical section prevents other threads from simultaneously
		/// calling that device's methods, calling DXGI methods, and calling the methods of all resource, view, shader, state, and
		/// asynchronous interfaces.
		/// </para>
		/// <para>
		/// This function should be used in multithreaded applications when there is a series of graphics commands that must happen in
		/// order. This function is typically called at the beginning of the series of graphics commands, and Leave is typically called
		/// after those graphics commands.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11multithread-enter void Enter();
		[PreserveSig]
		void Enter();

		/// <summary>Leave a device's critical section.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// This function is typically used in multithreaded applications when there is a series of graphics commands that must happen in
		/// order. Enter is typically called at the beginning of a series of graphics commands, and this function is typically called after
		/// those graphics commands.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11multithread-leave void Leave();
		[PreserveSig]
		void Leave();

		/// <summary>Turns multithread protection on or off.</summary>
		/// <param name="bMTProtect">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Set to true to turn multithread protection on, false to turn it off.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if multithread protection was already turned on prior to calling this method, false otherwise.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11multithread-setmultithreadprotected BOOL
		// SetMultithreadProtected( [in] BOOL bMTProtect );
		[PreserveSig]
		bool SetMultithreadProtected([MarshalAs(UnmanagedType.Bool)] bool bMTProtect);

		/// <summary>Find out if multithread protection is turned on or not.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns true if multithread protection is turned on, false otherwise.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11multithread-getmultithreadprotected BOOL GetMultithreadProtected();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetMultithreadProtected();
	}

	/// <summary>Provides the video functionality of a Microsoft Direct3D 11 device.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11videocontext2
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11VideoContext2")]
	[ComImport, Guid("c4e7374c-6243-4d1b-ae87-52b4f740e261"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoContext2 : ID3D11VideoContext1, ID3D11VideoContext, ID3D11DeviceChild
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

		/// <summary>Gets a pointer to a decoder buffer.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="Type">The type of buffer to retrieve, specified as a member of the D3D11_VIDEO_DECODER_BUFFER_TYPE enumeration.</param>
		/// <param name="pBufferSize">Receives the size of the buffer, in bytes.</param>
		/// <param name="ppBuffer">Receives a pointer to the start of the memory buffer.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// The graphics driver allocates the buffers that are used for decoding. This method locks the Microsoft Direct3Dsurface that
		/// contains the buffer. When you are done using the buffer, call ID3D11VideoContext::ReleaseDecoderBuffer to unlock the surface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-getdecoderbuffer HRESULT GetDecoderBuffer(
		// [in] ID3D11VideoDecoder *pDecoder, [in] D3D11_VIDEO_DECODER_BUFFER_TYPE Type, [out] UINT *pBufferSize, [out] void **ppBuffer );
		[PreserveSig]
		new HRESULT GetDecoderBuffer([In] ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type, out uint pBufferSize, out IntPtr ppBuffer);

		/// <summary>Releases a buffer that was obtained by calling the ID3D11VideoContext::GetDecoderBuffer method.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="Type">
		/// The type of buffer to release. Specify the same value that was used in the <c>Type</c> parameter of the GetDecoderBuffer method.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-releasedecoderbuffer HRESULT
		// ReleaseDecoderBuffer( [in] ID3D11VideoDecoder *pDecoder, [in] D3D11_VIDEO_DECODER_BUFFER_TYPE Type );
		[PreserveSig]
		new HRESULT ReleaseDecoderBuffer([In] ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type);

		/// <summary>Starts a decoding operation to decode a video frame.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="pView">
		/// A pointer to the ID3D11VideoDecoderOutputView interface. This interface describes the resource that will receive the decoded
		/// frame. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoderOutputView.
		/// </param>
		/// <param name="ContentKeySize">
		/// The size of the content key that is specified in <c>pContentKey</c>. If <c>pContentKey</c> is NULL, set <c>ContentKeySize</c> to zero.
		/// </param>
		/// <param name="pContentKey">
		/// An optional pointer to a content key that was used to encrypt the frame data. If no content key was used, set this parameter to
		/// <c>NULL</c>. If the caller provides a content key, the caller must use the session key to encrypt the content key.
		/// </param>
		/// <returns>
		/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.
		/// <c>D3DERR_WASSTILLDRAWING</c> or <c>E_PENDING</c> is returned if the hardware is busy, in which case the decoder should try to
		/// make the call again.
		/// </returns>
		/// <remarks>
		/// <para>
		/// After this method is called, call ID3D11VideoContext::SubmitDecoderBuffers to perform decoding operations. When all decoding
		/// operations have been executed, call ID3D11VideoContext::DecoderEndFrame.
		/// </para>
		/// <para>
		/// Each call to <c>DecoderBeginFrame</c> must have a matching call to DecoderEndFrame. In most cases you cannot nest
		/// <c>DecoderBeginFrame</c> calls, but some codecs, such as like VC-1, can have nested <c>DecoderBeginFrame</c> calls for special
		/// operations like post processing.
		/// </para>
		/// <para>The following encryption scenarios are supported through the content key:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The decoder can choose to not encrypt every frame, for example it may only encrypt the I frames and not encrypt the P/B frames.
		/// In these scenario, the decoder will specify pContentKey = NULL and ContentKeySize = 0 for those frames that it does not encrypt.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The decoder can choose to encrypt the compressed buffers using the session key. In this scenario, the decoder will specify a
		/// content key containing all zeros.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The decoder can choose to encrypt the compressed buffers using a separate content key. In this scenario, the decoder will ECB
		/// encrypt the content key using the session key and pass the encrypted content key.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decoderbeginframe HRESULT
		// DecoderBeginFrame( [in] ID3D11VideoDecoder *pDecoder, [in] ID3D11VideoDecoderOutputView *pView, [in] UINT ContentKeySize, [in]
		// const void *pContentKey );
		[PreserveSig]
		new HRESULT DecoderBeginFrame([In] ID3D11VideoDecoder pDecoder, [In] ID3D11VideoDecoderOutputView pView, uint ContentKeySize, [In] IntPtr pContentKey);

		/// <summary>Signals the end of a decoding operation.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decoderendframe HRESULT DecoderEndFrame(
		// [in] ID3D11VideoDecoder *pDecoder );
		[PreserveSig]
		new HRESULT DecoderEndFrame([In] ID3D11VideoDecoder pDecoder);

		/// <summary>Submits one or more buffers for decoding.</summary>
		/// <param name="pDecoder">
		/// A pointer to the ID3D11VideoDecoder interface. To get this pointer, call the ID3D11VideoDevice::CreateVideoDecoder method.
		/// </param>
		/// <param name="NumBuffers">The number of buffers submitted for decoding.</param>
		/// <param name="pBufferDesc">
		/// A pointer to an array of D3D11_VIDEO_DECODER_BUFFER_DESC structures. The <c>NumBuffers</c> parameter specifies the number of
		/// elements in the array. Each element in the array describes a compressed buffer for decoding.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// <para>
		/// When using feature levels 9_x, all partially encrypted buffers must use the same EncryptedBlockInfo, and partial encryption
		/// cannot be turned off on a per frame basis.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-submitdecoderbuffers HRESULT
		// SubmitDecoderBuffers( [in] ID3D11VideoDecoder *pDecoder, [in] UINT NumBuffers, [in] const D3D11_VIDEO_DECODER_BUFFER_DESC
		// *pBufferDesc );
		[PreserveSig]
		new HRESULT SubmitDecoderBuffers([In] ID3D11VideoDecoder pDecoder, int NumBuffers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC[] pBufferDesc);

		/// <summary>Performs an extended function for decoding. This method enables extensions to the basic decoder functionality.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="pExtensionData">A pointer to a D3D11_VIDEO_DECODER_EXTENSION structure that contains data for the function.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decoderextension APP_DEPRECATED_HRESULT
		// DecoderExtension( [in] ID3D11VideoDecoder *pDecoder, [in] const D3D11_VIDEO_DECODER_EXTENSION *pExtensionData );
		[PreserveSig]
		new int DecoderExtension([In] ID3D11VideoDecoder pDecoder, in D3D11_VIDEO_DECODER_EXTENSION pExtensionData);

		/// <summary>Sets the target rectangle for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enable">Specifies whether to apply the target rectangle.</param>
		/// <param name="pRect">
		/// A pointer to a RECT structure that specifies the target rectangle. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The target rectangle is the area within the destination surface where the output will be drawn. The target rectangle is given in
		/// pixel coordinates, relative to the destination surface.
		/// </para>
		/// <para>
		/// If this method is never called, or if the <c>Enable</c> parameter is <c>FALSE</c>, the video processor writes to the entire
		/// destination surface.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputtargetrect void
		// VideoProcessorSetOutputTargetRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] BOOL Enable, [in] const RECT *pRect );
		[PreserveSig]
		new void VideoProcessorSetOutputTargetRect([In] ID3D11VideoProcessor pVideoProcessor, bool Enable, [In, Optional] PRECT? pRect);

		/// <summary>Sets the background color for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="YCbCr">If <c>TRUE</c>, the color is specified as a YCbCr value. Otherwise, the color is specified as an RGB value.</param>
		/// <param name="pColor">A pointer to a D3D11_VIDEO_COLOR structure that specifies the background color.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The video processor uses the background color to fill areas of the target rectangle that do not contain a video image. Areas
		/// outside the target rectangle are not affected.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputbackgroundcolor void
		// VideoProcessorSetOutputBackgroundColor( [in] ID3D11VideoProcessor *pVideoProcessor, [in] BOOL YCbCr, [in] const D3D11_VIDEO_COLOR
		// *pColor );
		[PreserveSig]
		new void VideoProcessorSetOutputBackgroundColor([In] ID3D11VideoProcessor pVideoProcessor, bool YCbCr, in D3D11_VIDEO_COLOR pColor);

		/// <summary>Sets the output color space for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pColorSpace">A pointer to a D3D11_VIDEO_PROCESSOR_COLOR_SPACE structure that specifies the color space.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputcolorspace void
		// VideoProcessorSetOutputColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, [in] const D3D11_VIDEO_PROCESSOR_COLOR_SPACE
		// *pColorSpace );
		[PreserveSig]
		new void VideoProcessorSetOutputColorSpace([In] ID3D11VideoProcessor pVideoProcessor, in D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Sets the alpha fill mode for data that the video processor writes to the render target.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="AlphaFillMode">The alpha fill mode, specified as a D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE value.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of an input stream. This parameter is used if <c>AlphaFillMode</c> is
		/// <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM</c>. Otherwise, the parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To find out which fill modes the device supports, call the ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps method. If the
		/// driver reports the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_FILL</c> capability, the driver supports all of the fill modes.
		/// Otherwise, the <c>AlphaFillMode</c> parameter must be <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE</c>.
		/// </para>
		/// <para>The default fill mode is <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputalphafillmode void
		// VideoProcessorSetOutputAlphaFillMode( [in] ID3D11VideoProcessor *pVideoProcessor, [in] D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE
		// AlphaFillMode, [in] UINT StreamIndex );
		[PreserveSig]
		new void VideoProcessorSetOutputAlphaFillMode([In] ID3D11VideoProcessor pVideoProcessor, D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE AlphaFillMode, uint StreamIndex);

		/// <summary>Sets the amount of downsampling to perform on the output.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enable">
		/// If <c>TRUE</c>, downsampling is enabled. Otherwise, downsampling is disabled and the <c>Size</c> member is ignored.
		/// </param>
		/// <param name="Size">The sampling size.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Downsampling is sometimes used to reduce the quality of premium content when other forms of content protection are not
		/// available. By default, downsampling is disabled.
		/// </para>
		/// <para>
		/// If the <c>Enable</c> parameter is <c>TRUE</c>, the driver downsamples the composed image to the specified size, and then scales
		/// it back to the size of the target rectangle.
		/// </para>
		/// <para>
		/// The width and height of <c>Size</c> must be greater than zero. If the size is larger than the target rectangle, downsampling
		/// does not occur.
		/// </para>
		/// <para>
		/// To use this feature, the driver must support downsampling, indicated by the
		/// <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_CONSTRICTION</c> capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputconstriction void
		// VideoProcessorSetOutputConstriction( [in] ID3D11VideoProcessor *pVideoProcessor, BOOL Enable, SIZE Size );
		[PreserveSig]
		new void VideoProcessorSetOutputConstriction([In] ID3D11VideoProcessor pVideoProcessor, bool Enable, SIZE Size);

		/// <summary>Specifies whether the video processor produces stereo video frames.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enable">If <c>TRUE</c>, stereo output is enabled. Otherwise, the video processor produces mono video frames.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>By default, the video processor produces mono video frames.</para>
		/// <para>
		/// To use this feature, the driver must support stereo video, indicated by the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_STEREO</c>
		/// capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputstereomode void
		// VideoProcessorSetOutputStereoMode( [in] ID3D11VideoProcessor *pVideoProcessor, BOOL Enable );
		[PreserveSig]
		new void VideoProcessorSetOutputStereoMode([In] ID3D11VideoProcessor pVideoProcessor, bool Enable);

		/// <summary>Sets a driver-specific video processing state.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the operation. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">
		/// A pointer to a buffer that contains private state data. The method passes this buffer directly to the driver without validation.
		/// It is the responsibility of the driver to validate the data.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputextension
		// APP_DEPRECATED_HRESULT VideoProcessorSetOutputExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] const GUID
		// *pExtensionGuid, [in] UINT DataSize, [in] void *pData );
		[PreserveSig]
		new int VideoProcessorSetOutputExtension([In] ID3D11VideoProcessor pVideoProcessor, in Guid pExtensionGuid, uint DataSize, [In] IntPtr pData);

		/// <summary>Gets the current target rectangle for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enabled">
		/// Receives the value <c>TRUE</c> if the target rectangle was explicitly set using the
		/// ID3D11VideoContext::VideoProcessorSetOutputTargetRect method. Receives the value FALSE if the target rectangle was disabled or
		/// was never set.
		/// </param>
		/// <param name="pRect">
		/// If <c>Enabled</c> receives the value <c>TRUE</c>, this parameter receives the target rectangle. Otherwise, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputtargetrect void
		// VideoProcessorGetOutputTargetRect( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *Enabled, [out] RECT *pRect );
		[PreserveSig]
		new void VideoProcessorGetOutputTargetRect([In] ID3D11VideoProcessor pVideoProcessor, out bool Enabled, out RECT pRect);

		/// <summary>Gets the current background color for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pYCbCr">
		/// Receives the value <c>TRUE</c> if the background color is a YCbCr color, or <c>FALSE</c> if the background color is an RGB color.
		/// </param>
		/// <param name="pColor">A pointer to a D3D11_VIDEO_COLOR structure. The method fills in the structure with the background color.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputbackgroundcolor void
		// VideoProcessorGetOutputBackgroundColor( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pYCbCr, [out] D3D11_VIDEO_COLOR
		// *pColor );
		[PreserveSig]
		new void VideoProcessorGetOutputBackgroundColor([In] ID3D11VideoProcessor pVideoProcessor, out bool pYCbCr, out D3D11_VIDEO_COLOR pColor);

		/// <summary>Gets the current output color space for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pColorSpace">
		/// A pointer to a D3D11_VIDEO_PROCESSOR_COLOR_SPACE structure. The method fills in the structure with the output color space.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputcolorspace void
		// VideoProcessorGetOutputColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, [out] D3D11_VIDEO_PROCESSOR_COLOR_SPACE
		// *pColorSpace );
		[PreserveSig]
		new void VideoProcessorGetOutputColorSpace([In] ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Gets the current alpha fill mode for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pAlphaFillMode">Receives the alpha fill mode, as a D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE value.</param>
		/// <param name="pStreamIndex">
		/// If the alpha fill mode is <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM</c>, this parameter receives the zero-based
		/// index of an input stream. The input stream provides the alpha values for the alpha fill.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputalphafillmode void
		// VideoProcessorGetOutputAlphaFillMode( [in] ID3D11VideoProcessor *pVideoProcessor, [out] D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE
		// *pAlphaFillMode, [out] UINT *pStreamIndex );
		[PreserveSig]
		new void VideoProcessorGetOutputAlphaFillMode([In] ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE pAlphaFillMode, out uint pStreamIndex);

		/// <summary>Gets the current level of downsampling that is performed by the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pEnabled">
		/// Receives the value <c>TRUE</c> if downsampling was explicitly enabled using the
		/// ID3D11VideoContext::VideoProcessorSetOutputConstriction method. Receives the value <c>FALSE</c> if the downsampling was disabled
		/// or was never set.
		/// </param>
		/// <param name="pSize">
		/// If <c>Enabled</c> receives the value <c>TRUE</c>, this parameter receives the downsampling size. Otherwise, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputconstriction void
		// VideoProcessorGetOutputConstriction( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pEnabled, [out] SIZE *pSize );
		[PreserveSig]
		new void VideoProcessorGetOutputConstriction([In] ID3D11VideoProcessor pVideoProcessor, out bool pEnabled, out SIZE pSize);

		/// <summary>Queries whether the video processor produces stereo video frames.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if stereo output is enabled, or <c>FALSE</c> otherwise.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputstereomode void
		// VideoProcessorGetOutputStereoMode( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pEnabled );
		[PreserveSig]
		new void VideoProcessorGetOutputStereoMode([In] ID3D11VideoProcessor pVideoProcessor, out bool pEnabled);

		/// <summary>Gets private state data from the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the state. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">A pointer to a buffer that receives the private state data.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputextension
		// APP_DEPRECATED_HRESULT VideoProcessorGetOutputExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] const GUID
		// *pExtensionGuid, [in] UINT DataSize, [out] void *pData );
		[PreserveSig]
		new int VideoProcessorGetOutputExtension([In] ID3D11VideoProcessor pVideoProcessor, in Guid pExtensionGuid, uint DataSize, [Out] IntPtr pData);

		/// <summary>Specifies whether an input stream on the video processor contains interlaced or progressive frames.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="FrameFormat">A D3D11_VIDEO_FRAME_FORMAT value that specifies the interlacing.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamframeformat void
		// VideoProcessorSetStreamFrameFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, D3D11_VIDEO_FRAME_FORMAT
		// FrameFormat );
		[PreserveSig]
		new void VideoProcessorSetStreamFrameFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_FRAME_FORMAT FrameFormat);

		/// <summary>Sets the color space for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pColorSpace">A pointer to a D3D11_VIDEO_PROCESSOR_COLOR_SPACE structure that specifies the color space.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamcolorspace void
		// VideoProcessorSetStreamColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] const
		// D3D11_VIDEO_PROCESSOR_COLOR_SPACE *pColorSpace );
		[PreserveSig]
		new void VideoProcessorSetStreamColorSpace([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, in D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Sets the rate at which the video processor produces output frames for an input stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="OutputRate">The output rate, specified as a D3D11_VIDEO_PROCESSOR_OUTPUT_RATE value.</param>
		/// <param name="RepeatFrame">
		/// <para>Specifies how the driver performs frame-rate conversion, if required.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Repeat frames.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Interpolate frames.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pCustomRate">
		/// A pointer to a DXGI_RATIONAL structure. If <c>OutputRate</c> is <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM</c>, this parameter
		/// specifies the exact output rate. Otherwise, this parameter is ignored and can be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The standard output rates are normal frame-rate ( <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_NORMAL</c>) and half frame-rate (
		/// <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_HALF</c>). In addition, the driver might support custom rates for rate conversion or
		/// inverse telecine. To get the list of custom rates, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCustomRate.
		/// </para>
		/// <para>
		/// Depending on the output rate, the driver might need to convert the frame rate. If so, the value of <c>RepeatFrame</c> controls
		/// whether the driver creates interpolated frames or simply repeats input frames.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamoutputrate void
		// VideoProcessorSetStreamOutputRate( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate, [in] BOOL RepeatFrame, [in] const DXGI_RATIONAL *pCustomRate );
		[PreserveSig]
		new void VideoProcessorSetStreamOutputRate([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate,
			bool RepeatFrame, [Optional] in DXGI_RATIONAL pCustomRate);

		/// <summary>Sets the source rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether to apply the source rectangle.</param>
		/// <param name="pRect">
		/// A pointer to a RECT structure that specifies the source rectangle. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The source rectangle is the portion of the input surface that is blitted to the destination surface. The source rectangle is
		/// given in pixel coordinates, relative to the input surface.
		/// </para>
		/// <para>
		/// If this method is never called, or if the <c>Enable</c> parameter is <c>FALSE</c>, the video processor reads from the entire
		/// input surface.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamsourcerect void
		// VideoProcessorSetStreamSourceRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in]
		// const RECT *pRect );
		[PreserveSig]
		new void VideoProcessorSetStreamSourceRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, [Optional] in RECT pRect);

		/// <summary>Sets the destination rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether to apply the destination rectangle.</param>
		/// <param name="pRect">
		/// A pointer to a RECT structure that specifies the destination rectangle. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The destination rectangle is the portion of the output surface that receives the blit for this stream. The destination rectangle
		/// is given in pixel coordinates, relative to the output surface.
		/// </para>
		/// <para>
		/// The default destination rectangle is an empty rectangle (0, 0, 0, 0). If this method is never called, or if the <c>Enable</c>
		/// parameter is <c>FALSE</c>, no data is written from this stream.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamdestrect void
		// VideoProcessorSetStreamDestRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] const
		// RECT *pRect );
		[PreserveSig]
		new void VideoProcessorSetStreamDestRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, [Optional] in RECT pRect);

		/// <summary>Sets the planar alpha for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether alpha blending is enabled.</param>
		/// <param name="Alpha">
		/// The planar alpha value. The value can range from 0.0 (transparent) to 1.0 (opaque). If <c>Enable</c> is <c>FALSE</c>, this
		/// parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To use this feature, the driver must support stereo video, indicated by the D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALHPA_STREAM
		/// capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// <para>Alpha blending is disabled by default.</para>
		/// <para>For each pixel, the destination color value is computed as follows:</para>
		/// <para>where:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>= The color value of the destination pixel</description>
		/// </item>
		/// <item>
		/// <description>= The color value of the source pixel</description>
		/// </item>
		/// <item>
		/// <description>= The per-pixel source alpha</description>
		/// </item>
		/// <item>
		/// <description>= The planar alpha value</description>
		/// </item>
		/// <item>
		/// <description>= The palette-entry alpha value, or 1.0 (see Note)</description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c>  Palette-entry alpha values apply only to palettized color formats, and only when the device supports the
		/// <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE</c> capability. Otherwise, this factor equals 1.0.
		/// </para>
		/// <para></para>
		/// <para>The destination alpha value is computed according to the alpha fill mode. For more information, see ID3D11VideoContext::VideoProcessorSetOutputAlphaFillMode.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamalpha void
		// VideoProcessorSetStreamAlpha( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] FLOAT
		// Alpha );
		[PreserveSig]
		new void VideoProcessorSetStreamAlpha([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Alpha);

		/// <summary>Sets the color-palette entries for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Count">The number of elements in the <c>pEntries</c> array.</param>
		/// <param name="pEntries">
		/// A pointer to an array of palette entries. For RGB streams, the palette entries use the <c>DXGI_FORMAT_B8G8R8A8</c>
		/// representation. For YCbCr streams, the palette entries use the <c>DXGI_FORMAT_AYUV</c> representation. The caller allocates the array.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method applies only to input streams that have a palettized color format. Palettized formats with 4 bits per pixel (bpp)
		/// use the first 16 entries in the list. Formats with 8 bpp use the first 256 entries.
		/// </para>
		/// <para>
		/// If a pixel has a palette index greater than the number of entries, the device treats the pixel as white with opaque alpha. For
		/// full-range RGB, this value is (255, 255, 255, 255); for YCbCr the value is (255, 235, 128, 128).
		/// </para>
		/// <para>
		/// If the driver does not report the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE</c> capability flag, every palette entry
		/// must have an alpha value of 0xFF (opaque). To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreampalette void
		// VideoProcessorSetStreamPalette( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] UINT Count, [in] const
		// UINT *pEntries );
		[PreserveSig]
		new void VideoProcessorSetStreamPalette([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);

		/// <summary>Sets the pixel aspect ratio for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">
		/// Specifies whether the <c>pSourceAspectRatio</c> and <c>pDestinationAspectRatio</c> parameters contain valid values. Otherwise,
		/// the pixel aspect ratios are unspecified.
		/// </param>
		/// <param name="pSourceAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure that contains the pixel aspect ratio of the source rectangle. If <c>Enable</c> is
		/// <c>FALSE</c>, this parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pDestinationAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure that contains the pixel aspect ratio of the destination rectangle. If <c>Enable</c> is
		/// <c>FALSE</c>, this parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This function can only be called if the driver reports the D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_PIXEL_ASPECT_RATIO capability. If
		/// this capability is not set, this function will have no effect.
		/// </para>
		/// <para>Pixel aspect ratios of the form 0/n and n/0 are not valid.</para>
		/// <para>The default pixel aspect ratio is 1:1 (square pixels).</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreampixelaspectratio
		// void VideoProcessorSetStreamPixelAspectRatio( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL
		// Enable, [in] const DXGI_RATIONAL *pSourceAspectRatio, [in] const DXGI_RATIONAL *pDestinationAspectRatio );
		[PreserveSig]
		new void VideoProcessorSetStreamPixelAspectRatio([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable,
			[Optional] in DXGI_RATIONAL pSourceAspectRatio, [Optional] in DXGI_RATIONAL pDestinationAspectRatio);

		/// <summary>Sets the luma key for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether luma keying is enabled.</param>
		/// <param name="Lower">
		/// The lower bound for the luma key. The valid range is [0…1]. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <param name="Upper">
		/// The upper bound for the luma key. The valid range is [0…1]. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To use this feature, the driver must support luma keying, indicated by the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LUMA_KEY</c>
		/// capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps. In addition, if the
		/// input format is RGB, the device must support the <c>D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_LUMA_KEY</c> capability.
		/// </para>
		/// <para>
		/// The values of <c>Lower</c> and <c>Upper</c> give the lower and upper bounds of the luma key, using a nominal range of [0...1].
		/// Given a format with <c>n</c> bits per channel, these values are converted to luma values as follows:
		/// </para>
		/// <para>Any pixel whose luma value falls within the upper and lower bounds (inclusive) is treated as transparent.</para>
		/// <para>For example, if the pixel format uses 8-bit luma, the upper bound is calculated as follows:</para>
		/// <para>Note that the value is clamped to the range [0...1] before multiplying by 255.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamlumakey void
		// VideoProcessorSetStreamLumaKey( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] FLOAT
		// Lower, [in] FLOAT Upper );
		[PreserveSig]
		new void VideoProcessorSetStreamLumaKey([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Lower, float Upper);

		/// <summary>
		/// Enables or disables stereo 3D video for an input stream on the video processor. In addition, this method specifies the layout of
		/// the video frames in memory.
		/// </summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">
		/// Specifies whether stereo 3D is enabled for this stream. If the value is <c>FALSE</c>, the remaining parameters of this method
		/// are ignored.
		/// </param>
		/// <param name="Format">Specifies the layout of the two stereo views in memory, as a D3D11_VIDEO_PROCESSOR_STEREO_FORMAT value.</param>
		/// <param name="LeftViewFrame0">
		/// <para>If <c>TRUE</c>, frame 0 contains the left view. Otherwise, frame 0 contains the right view.</para>
		/// <para>This parameter is ignored for the following stereo formats:</para>
		/// <list type="bullet">
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO</c></item>
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c></item>
		/// </list>
		/// </param>
		/// <param name="BaseViewFrame0">
		/// <para>If <c>TRUE</c>, frame 0 contains the base view. Otherwise, frame 1 contains the base view.</para>
		/// <para>This parameter is ignored for the following stereo formats:</para>
		/// <list type="bullet">
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO</c></item>
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c></item>
		/// <item>
		/// When <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE</c> is used and the application wants to convert the stereo data to mono,
		/// it can either:
		/// </item>
		/// </list>
		/// </param>
		/// <param name="FlipMode">
		/// A flag from the D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE enumeration, specifying whether one of the views is flipped.
		/// </param>
		/// <param name="MonoOffset">
		/// <para>
		/// For <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c> format, this parameter specifies how to generate the left and right views:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// If <c>MonoOffset</c> is positive, the right view is shifted to the right by that many pixels, and the left view is shifted to
		/// the left by the same amount.
		/// </item>
		/// <item>
		/// If <c>MonoOffset</c> is negative, the right view is shifted to the left by that many pixels, and the left view is shifted to
		/// right by the same amount.
		/// </item>
		/// </list>
		/// <para>If Format is not D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET, this parameter must be zero.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamstereoformat void
		// VideoProcessorSetStreamStereoFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in]
		// D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format, [in] BOOL LeftViewFrame0, [in] BOOL BaseViewFrame0, [in]
		// D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, [in] int MonoOffset );
		[PreserveSig]
		new void VideoProcessorSetStreamStereoFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format,
			bool LeftViewFrame0, bool BaseViewFrame0, D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, int MonoOffset);

		/// <summary>Enables or disables automatic processing features on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">
		/// If <c>TRUE</c>, automatic processing features are enabled. If <c>FALSE</c>, the driver disables any extra video processing that
		/// it might be performing.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// By default, the driver might perform certain processing tasks automatically during the video processor blit. This method enables
		/// the application to disable these extra video processing features. For example, if you provide your own pixel shader for the
		/// video processor, you might want to disable the driver's automatic processing.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamautoprocessingmode
		// void VideoProcessorSetStreamAutoProcessingMode( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL
		// Enable );
		[PreserveSig]
		new void VideoProcessorSetStreamAutoProcessingMode([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable);

		/// <summary>Enables or disables an image filter for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Filter">
		/// <para>The filter, specified as a D3D11_VIDEO_PROCESSOR_FILTER value.</para>
		/// <para>To query which filters the driver supports, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.</para>
		/// </param>
		/// <param name="Enable">Specifies whether to enable the filter.</param>
		/// <param name="Level">
		/// <para>The filter level. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.</para>
		/// <para>To find the valid range of levels for a specified filter, call ID3D11VideoProcessorEnumerator::GetVideoProcessorFilterRange.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamfilter void
		// VideoProcessorSetStreamFilter( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// D3D11_VIDEO_PROCESSOR_FILTER Filter, [in] BOOL Enable, [in] int Level );
		[PreserveSig]
		new void VideoProcessorSetStreamFilter([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, bool Enable, int Level);

		/// <summary>Sets a driver-specific state on a video processing stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the operation. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">
		/// A pointer to a buffer that contains private state data. The method passes this buffer directly to the driver without validation.
		/// It is the responsibility of the driver to validate the data.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamextension
		// APP_DEPRECATED_HRESULT VideoProcessorSetStreamExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// const GUID *pExtensionGuid, [in] UINT DataSize, [in] void *pData );
		[PreserveSig]
		new int VideoProcessorSetStreamExtension([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, in Guid pExtensionGuid, uint DataSize, [In] IntPtr pData);

		/// <summary>Gets the format of an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pFrameFormat">
		/// Receives a D3D11_VIDEO_FRAME_FORMAT value that specifies whether the stream contains interlaced or progressive frames.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamframeformat void
		// VideoProcessorGetStreamFrameFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out]
		// D3D11_VIDEO_FRAME_FORMAT *pFrameFormat );
		[PreserveSig]
		new void VideoProcessorGetStreamFrameFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_FRAME_FORMAT pFrameFormat);

		/// <summary>Gets the color space for an input stream of the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pColorSpace">Receives a D3D11_VIDEO_PROCESSOR_COLOR_SPACE value that specifies the color space.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamcolorspace void
		// VideoProcessorGetStreamColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, UINT StreamIndex, [out]
		// D3D11_VIDEO_PROCESSOR_COLOR_SPACE *pColorSpace );
		[PreserveSig]
		new void VideoProcessorGetStreamColorSpace([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Gets the rate at which the video processor produces output frames for an input stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pOutputRate">Receives a D3D11_VIDEO_PROCESSOR_OUTPUT_RATE value that specifies the output rate.</param>
		/// <param name="pRepeatFrame">
		/// <para>Receives a Boolean value that specifies how the driver performs frame-rate conversion, if required.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Repeat frames.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Interpolate frames.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pCustomRate">
		/// A pointer to a DXGI_RATIONAL structure. If the output rate is <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM</c>, the method fills
		/// in this structure with the exact output rate. Otherwise, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamoutputrate void
		// VideoProcessorGetStreamOutputRate( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out]
		// D3D11_VIDEO_PROCESSOR_OUTPUT_RATE *pOutputRate, [out] BOOL *pRepeatFrame, [out] DXGI_RATIONAL *pCustomRate );
		[PreserveSig]
		new void VideoProcessorGetStreamOutputRate([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_OUTPUT_RATE pOutputRate,
			out bool pRepeatFrame, out DXGI_RATIONAL pCustomRate);

		/// <summary>Gets the source rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if the source rectangle is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pRect">A pointer to a RECT structure that receives the source rectangle.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamsourcerect void
		// VideoProcessorGetStreamSourceRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// RECT *pRect );
		[PreserveSig]
		new void VideoProcessorGetStreamSourceRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);

		/// <summary>Gets the destination rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if the destination rectangle is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pRect">A pointer to a RECT structure that receives the destination rectangle.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamdestrect void
		// VideoProcessorGetStreamDestRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// RECT *pRect );
		[PreserveSig]
		new void VideoProcessorGetStreamDestRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);

		/// <summary>Gets the planar alpha for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if planar alpha is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pAlpha">Receives the planar alpha value. The value can range from 0.0 (transparent) to 1.0 (opaque).</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamalpha void
		// VideoProcessorGetStreamAlpha( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// FLOAT *pAlpha );
		[PreserveSig]
		new void VideoProcessorGetStreamAlpha([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pAlpha);

		/// <summary>Gets the color-palette entries for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Count">The number of entries in the <c>pEntries</c> array.</param>
		/// <param name="pEntries">
		/// A pointer to a <c>UINT</c> array allocated by the caller. The method fills the array with the palette entries. For RGB streams,
		/// the palette entries use the <c>DXGI_FORMAT_B8G8R8A8</c> representation. For YCbCr streams, the palette entries use the
		/// <c>DXGI_FORMAT_AYUV</c> representation.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method applies only to input streams that have a palettized color format. Palettized formats with 4 bits per pixel (bpp)
		/// use 16 palette entries. Formats with 8 bpp use 256 entries.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreampalette void
		// VideoProcessorGetStreamPalette( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] UINT Count, [out] UINT
		// *pEntries );
		[PreserveSig]
		new void VideoProcessorGetStreamPalette([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);

		/// <summary>Gets the pixel aspect ratio for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">
		/// Receives the value <c>TRUE</c> if the pixel aspect ratio is specified. Otherwise, receives the value <c>FALSE</c>.
		/// </param>
		/// <param name="pSourceAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure. If * <c>pEnabled</c> is <c>TRUE</c>, this parameter receives the pixel aspect ratio of
		/// the source rectangle.
		/// </param>
		/// <param name="pDestinationAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure. If * <c>pEnabled</c> is <c>TRUE</c>, this parameter receives the pixel aspect ratio of
		/// the destination rectangle.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When the method returns, if <c>*pEnabled</c> is <c>TRUE</c>, the <c>pSourceAspectRatio</c> and <c>pDestinationAspectRatio</c>
		/// parameters contain the pixel aspect ratios. Otherwise, the default pixel aspect ratio is 1:1 (square pixels).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreampixelaspectratio
		// void VideoProcessorGetStreamPixelAspectRatio( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL
		// *pEnabled, [out] DXGI_RATIONAL *pSourceAspectRatio, [out] DXGI_RATIONAL *pDestinationAspectRatio );
		[PreserveSig]
		new void VideoProcessorGetStreamPixelAspectRatio([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled,
			out DXGI_RATIONAL pSourceAspectRatio, out DXGI_RATIONAL pDestinationAspectRatio);

		/// <summary>Gets the luma key for an input stream of the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if luma keying is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pLower">Receives the lower bound for the luma key. The valid range is [0…1].</param>
		/// <param name="pUpper">Receives the upper bound for the luma key. The valid range is [0…1].</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamlumakey void
		// VideoProcessorGetStreamLumaKey( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// FLOAT *pLower, [out] FLOAT *pUpper );
		[PreserveSig]
		new void VideoProcessorGetStreamLumaKey([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pLower, out float pUpper);

		/// <summary>Gets the stereo 3D format for an input stream on the video processor</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnable">
		/// Receives the value <c>TRUE</c> if stereo 3D is enabled for this stream, or <c>FALSE</c> otherwise. If the value is <c>FALSE</c>,
		/// ignore the remaining parameters.
		/// </param>
		/// <param name="pFormat">
		/// Receives a D3D11_VIDEO_PROCESSOR_STEREO_FORMAT value that specifies the layout of the two stereo views in memory.
		/// </param>
		/// <param name="pLeftViewFrame0">
		/// <para>Receives a Boolean value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Frame 0 contains the left view.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Frame 0 contains the right view.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pBaseViewFrame0">
		/// <para>Receives a Boolean value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Frame 0 contains the base view.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Frame 1 contains the base view.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pFlipMode">
		/// Receives a D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE value. This value specifies whether one of the views is flipped.
		/// </param>
		/// <param name="MonoOffset">
		/// Receives the pixel offset used for <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c> format. This parameter is ignored for
		/// other stereo formats.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamstereoformat void
		// VideoProcessorGetStreamStereoFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnable,
		// [out] D3D11_VIDEO_PROCESSOR_STEREO_FORMAT *pFormat, [out] BOOL *pLeftViewFrame0, [out] BOOL *pBaseViewFrame0, [out]
		// D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE *pFlipMode, [out] int *MonoOffset );
		[PreserveSig]
		new void VideoProcessorGetStreamStereoFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable,
			out D3D11_VIDEO_PROCESSOR_STEREO_FORMAT pFormat, out bool pLeftViewFrame0, out bool pBaseViewFrame0,
			out D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE pFlipMode, out int MonoOffset);

		/// <summary>Queries whether automatic processing features of the video processor are enabled.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if automatic processing features are enabled, or <c>FALSE</c> otherwise.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Automatic processing refers to additional image processing that drivers might have performed on the image data prior to the
		/// application receiving the data.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamautoprocessingmode
		// void VideoProcessorGetStreamAutoProcessingMode( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL
		// *pEnabled );
		[PreserveSig]
		new void VideoProcessorGetStreamAutoProcessingMode([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled);

		/// <summary>Gets the image filter settings for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Filter">The filter to query, specified as a D3D11_VIDEO_PROCESSOR_FILTER value.</param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if the image filter is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pLevel">Receives the filter level.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamfilter void
		// VideoProcessorGetStreamFilter( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// D3D11_VIDEO_PROCESSOR_FILTER Filter, [out] BOOL *pEnabled, [out] int *pLevel );
		[PreserveSig]
		new void VideoProcessorGetStreamFilter([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, out bool pEnabled, out int pLevel);

		/// <summary>Gets a driver-specific state for a video processing stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the state. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">A pointer to a buffer that receives the private state data.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamextension
		// APP_DEPRECATED_HRESULT VideoProcessorGetStreamExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// const GUID *pExtensionGuid, [in] UINT DataSize, [out] void *pData );
		[PreserveSig]
		new int VideoProcessorGetStreamExtension([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, in Guid pExtensionGuid, uint DataSize, [Out] IntPtr pData);

		/// <summary>Performs a video processing operation on one or more input samples, and writes the result to a Direct3D surface.</summary>
		/// <param name="pVideoProcessor">
		/// A pointer to the ID3D11VideoProcessor interface. To get this pointer, call the ID3D11VideoDevice::CreateVideoProcessor method.
		/// </param>
		/// <param name="pView">
		/// A pointer to the ID3D11VideoProcessorOutputView interface for the output surface. The output of the video processing operation
		/// will be written to this surface.
		/// </param>
		/// <param name="OutputFrame">The frame number of the output video frame, indexed from zero.</param>
		/// <param name="StreamCount">The number of input streams to process.</param>
		/// <param name="pStreams">
		/// A pointer to an array of D3D11_VIDEO_PROCESSOR_STREAM structures that contain information about the input streams. The caller
		/// allocates the array and fills in each structure. The number of elements in the array is given in the StreamCount parameter.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// The maximum value of <c>StreamCount</c> is given in the <c>MaxStreamStates</c> member of the D3D11_VIDEO_PROCESSOR_CAPS
		/// structure. The maximum number of streams that can be enabled at one time is given in the <c>MaxInputStreams</c> member of that structure.
		/// </para>
		/// <para>If the output stereo mode is <c>TRUE</c>:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The output view must contain a texture array of two elements.</description>
		/// </item>
		/// <item>
		/// <description>At least one stereo stream must be specified.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If multiple input streams are enabled, it is possible that one or more of the input streams may contain mono data.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Otherwise:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The output view must contain a single element.</description>
		/// </item>
		/// <item>
		/// <description>The stereo format cannot be D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO .</description>
		/// </item>
		/// </list>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorblt HRESULT
		// VideoProcessorBlt( [in] ID3D11VideoProcessor *pVideoProcessor, [in] ID3D11VideoProcessorOutputView *pView, [in] UINT OutputFrame,
		// [in] UINT StreamCount, [in] const D3D11_VIDEO_PROCESSOR_STREAM *pStreams );
		[PreserveSig]
		new HRESULT VideoProcessorBlt([In] ID3D11VideoProcessor pVideoProcessor, [In] ID3D11VideoProcessorOutputView pView, uint OutputFrame,
			int StreamCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D11_VIDEO_PROCESSOR_STREAM[] pStreams);

		/// <summary>Establishes the session key for a cryptographic session.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface of the cryptographic session.</param>
		/// <param name="DataSize">The size of the <c>pData</c> byte array, in bytes.</param>
		/// <param name="pData">A pointer to a byte array that contains the encrypted session key.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>The key exchange mechanism depends on the type of cryptographic session.</para>
		/// <para>
		/// For RSA Encryption Scheme - Optimal Asymmetric Encryption Padding (RSAES-OAEP), the software decoder generates the secret key,
		/// encrypts the secret key by using the public key with RSAES-OAEP, and places the cipher text in the <c>pData</c> parameter. The
		/// actual size of the buffer for RSAES-OAEP is 256 bytes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-negotiatecryptosessionkeyexchange HRESULT
		// NegotiateCryptoSessionKeyExchange( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT DataSize, [in, out] void *pData );
		[PreserveSig]
		new HRESULT NegotiateCryptoSessionKeyExchange([In] ID3D11CryptoSession pCryptoSession, uint DataSize, [In, Out] IntPtr pData);

		/// <summary>Reads encrypted data from a protected surface.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface of the cryptographic session.</param>
		/// <param name="pSrcSurface">A pointer to the ID3D11Texture2D interface of the protected surface.</param>
		/// <param name="pDstSurface">A pointer to the ID3D11Texture2D interface of the surface that receives the encrypted data.</param>
		/// <param name="IVSize">The size of the <c>pIV</c> buffer, in bytes.</param>
		/// <param name="pIV">
		/// <para>
		/// A pointer to a buffer that receives the initialization vector (IV). The caller allocates this buffer, but the driver generates
		/// the IV.
		/// </para>
		/// <para>
		/// For 128-bit AES-CTR encryption, <c>pIV</c> points to a D3D11_AES_CTR_IV structure. When the driver generates the first IV, it
		/// initializes the structure to a random number. For each subsequent IV, the driver simply increments the <c>IV</c> member of the
		/// structure, ensuring that the value always increases. The application can validate that the same IV is never used more than once
		/// with the same key pair.
		/// </para>
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Not all drivers support this method. To query the driver capabilities, call ID3D11VideoDevice::GetContentProtectionCaps and
		/// check for the <c>D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK</c> flag in the <c>Caps</c> member of the
		/// D3D11_VIDEO_CONTENT_PROTECTION_CAPS structure.
		/// </para>
		/// <para>
		/// Some drivers might require a separate key to decrypt the data that is read back. To check for this requirement, call
		/// GetContentProtectionCaps and check for the <c>D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK_KEY</c> flag. If this flag is
		/// present, call ID3D11VideoContext::GetEncryptionBltKey to get the decryption key.
		/// </para>
		/// <para>This method has the following limitations:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Reading back sub-rectangles is not supported.</description>
		/// </item>
		/// <item>
		/// <description>Reading back partially encrypted surfaces is not supported.</description>
		/// </item>
		/// <item>
		/// <description>The protected surface must be either an off-screen plain surface or a render target.</description>
		/// </item>
		/// <item>
		/// <description>The destination surface must be a D3D11_USAGE_STAGING resource.</description>
		/// </item>
		/// <item>
		/// <description>The protected surface cannot be multisampled.</description>
		/// </item>
		/// <item>
		/// <description>Stretching and colorspace conversion are not supported.</description>
		/// </item>
		/// </list>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-encryptionblt void EncryptionBlt( [in]
		// ID3D11CryptoSession *pCryptoSession, [in] ID3D11Texture2D *pSrcSurface, [in] ID3D11Texture2D *pDstSurface, [in] UINT IVSize, [in]
		// void *pIV );
		[PreserveSig]
		new void EncryptionBlt([In] ID3D11CryptoSession pCryptoSession, [In] ID3D11Texture2D pSrcSurface, [In] ID3D11Texture2D pDstSurface, uint IVSize, [In] IntPtr pIV);

		/// <summary>Writes encrypted data to a protected surface.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <param name="pSrcSurface">A pointer to the surface that contains the source data.</param>
		/// <param name="pDstSurface">A pointer to the protected surface where the encrypted data is written.</param>
		/// <param name="pEncryptedBlockInfo">
		/// <para>A pointer to a D3D11_ENCRYPTED_BLOCK_INFO structure, or <c>NULL</c>.</para>
		/// <para>
		/// If the driver supports partially encrypted buffers, <c>pEncryptedBlockInfo</c> indicates which portions of the buffer are
		/// encrypted. If the entire surface is encrypted, set this parameter to <c>NULL</c>.
		/// </para>
		/// <para>
		/// To check whether the driver supports partially encrypted buffers, call ID3D11VideoDevice::GetContentProtectionCaps and check for
		/// the <c>D3D11_CONTENT_PROTECTION_CAPS_PARTIAL_DECRYPTION</c> capabilities flag. If the driver does not support partially
		/// encrypted buffers, set this parameter to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="ContentKeySize">The size of the encrypted content key, in bytes.</param>
		/// <param name="pContentKey">
		/// <para>
		/// A pointer to a buffer that contains a content encryption key, or <c>NULL</c>. To query whether the driver supports the use of
		/// content keys, call ID3D11VideoDevice::GetContentProtectionCaps and check for the
		/// <c>D3D11_CONTENT_PROTECTION_CAPS_CONTENT_KEY</c> capabilities flag.
		/// </para>
		/// <para>
		/// If the driver supports content keys, use the content key to encrypt the surface. Encrypt the content key using the session key,
		/// and place the resulting cipher text in <c>pContentKey</c>. If the driver does not support content keys, use the session key to
		/// encrypt the surface and set <c>pContentKey</c> to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="IVSize">The size of the <c>pIV</c> buffer, in bytes.</param>
		/// <param name="pIV">
		/// <para>A pointer to a buffer that contains the initialization vector (IV).</para>
		/// <para>
		/// For 128-bit AES-CTR encryption, <c>pIV</c> points to a D3D11_AES_CTR_IV structure. The caller allocates the structure and
		/// generates the IV. When you generate the first IV, initialize the structure to a random number. For each subsequent IV, simply
		/// increment the <c>IV</c> member of the structure, ensuring that the value always increases. This procedure enables the driver to
		/// validate that the same IV is never used more than once with the same key pair.
		/// </para>
		/// <para>For other encryption types, a different structure might be used, or the encryption might not use an IV.</para>
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Not all hardware or drivers support this functionality for all cryptographic types. This function can only be called when the
		/// D3D11_CONTENT_PROTECTION_CAPS_DECRYPTION_BLT cap is reported.
		/// </para>
		/// <para>This method does not support writing to sub-rectangles of the surface.</para>
		/// <para>If the hardware and driver support a content key:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The data is encrypted by the caller using the content key.</description>
		/// </item>
		/// <item>
		/// <description>The content key is encrypted by the caller using the session key.</description>
		/// </item>
		/// <item>
		/// <description>The encrypted content key is passed to the driver.</description>
		/// </item>
		/// </list>
		/// <para>Otherwise, the data is encrypted by the caller using the session key and NULL is passed as the content key.</para>
		/// <para>
		/// If the driver and hardware support partially encrypted buffers, <c>pEncryptedBlockInfo</c> indicates which portions of the
		/// buffer are encrypted and which is not. If the entire buffer is encrypted, <c>pEncryptedBlockinfo</c> should be <c>NULL</c>.
		/// </para>
		/// <para>
		/// The D3D11_ENCRYPTED_BLOCK_INFO allows the application to indicate which bytes in the buffer are encrypted. This is specified in
		/// bytes, so the application must ensure that the encrypted blocks match the GPU’s crypto block alignment.
		/// </para>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decryptionblt void DecryptionBlt( [in]
		// ID3D11CryptoSession *pCryptoSession, [in] ID3D11Texture2D *pSrcSurface, [in] ID3D11Texture2D *pDstSurface, [in]
		// D3D11_ENCRYPTED_BLOCK_INFO *pEncryptedBlockInfo, [in] UINT ContentKeySize, [in] const void *pContentKey, [in] UINT IVSize, [in]
		// void *pIV );
		[PreserveSig]
		new void DecryptionBlt([In] ID3D11CryptoSession pCryptoSession, [In] ID3D11Texture2D pSrcSurface, [In] ID3D11Texture2D pDstSurface,
			in D3D11_ENCRYPTED_BLOCK_INFO pEncryptedBlockInfo, uint ContentKeySize, [In] IntPtr pContentKey, uint IVSize, [In] IntPtr pIV);

		/// <summary>Gets a random number that can be used to refresh the session key.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <param name="RandomNumberSize">
		/// The size of the <c>pRandomNumber</c> array, in bytes. The size should match the size of the session key.
		/// </param>
		/// <param name="pRandomNumber">A pointer to a byte array that receives a random number.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// To generate a new session key, perform a bitwise <c>XOR</c> between the previous session key and the random number. The new
		/// session key does not take affect until the application calls ID3D11VideoContext::FinishSessionKeyRefresh.
		/// </para>
		/// <para>
		/// To query whether the driver supports this method, call ID3D11VideoDevice::GetContentProtectionCaps and check for the
		/// <c>D3D11_CONTENT_PROTECTION_CAPS_FRESHEN_SESSION_KEY</c> capabilities flag.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-startsessionkeyrefresh void
		// StartSessionKeyRefresh( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT RandomNumberSize, [out] void *pRandomNumber );
		[PreserveSig]
		new void StartSessionKeyRefresh([In] ID3D11CryptoSession pCryptoSession, uint RandomNumberSize, [Out] IntPtr pRandomNumber);

		/// <summary>Switches to a new session key.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>This function can only be called when the D3D11_CONTENT_PROTECTION_CAPS_FRESHEN_SESSION_KEY cap is reported.</para>
		/// <para>
		/// Before calling this method, call ID3D11VideoContext::StartSessionKeyRefresh. The <c>StartSessionKeyRefresh</c> method gets a
		/// random number from the driver, which is used to create a new session key. The new session key does not become active until the
		/// application calls <c>FinishSessionKeyRefresh</c>. After the application calls <c>FinishSessionKeyRefresh</c>, all protected
		/// surfaces are encrypted using the new session key.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-finishsessionkeyrefresh void
		// FinishSessionKeyRefresh( [in] ID3D11CryptoSession *pCryptoSession );
		[PreserveSig]
		new void FinishSessionKeyRefresh([In] ID3D11CryptoSession pCryptoSession);

		/// <summary>Gets the cryptographic key to decrypt the data returned by the ID3D11VideoContext::EncryptionBlt method.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <param name="KeySize">The size of the <c>pReadbackKey</c> array, in bytes. The size should match the size of the session key.</param>
		/// <param name="pReadbackKey">A pointer to a byte array that receives the key. The key is encrypted using the session key.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// This method applies only when the driver requires a separate content key for the EncryptionBlt method. For more information, see
		/// the Remarks for <c>EncryptionBlt</c>.
		/// </para>
		/// <para>Each time this method is called, the driver generates a new key.</para>
		/// <para>The <c>KeySize</c> should match the size of the session key.</para>
		/// <para>The read back key is encrypted by the driver/hardware using the session key.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-getencryptionbltkey HRESULT
		// GetEncryptionBltKey( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT KeySize, [out] void *pReadbackKey );
		[PreserveSig]
		new HRESULT GetEncryptionBltKey([In] ID3D11CryptoSession pCryptoSession, uint KeySize, [Out] IntPtr pReadbackKey);

		/// <summary>Establishes a session key for an authenticated channel.</summary>
		/// <param name="pChannel">
		/// A pointer to the ID3D11AuthenticatedChannel interface. This method will fail if the channel type is
		/// D3D11_AUTHENTICATED_CHANNEL_D3D11, because the Direct3D11 channel does not support authentication.
		/// </param>
		/// <param name="DataSize">The size of the data in the <c>pData</c> array, in bytes.</param>
		/// <param name="pData">
		/// A pointer to a byte array that contains the encrypted session key. The buffer must contain 256 bytes of data, encrypted using
		/// RSA Encryption Scheme - Optimal Asymmetric Encryption Padding (RSAES-OAEP).
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// This method will fail if the channel type is D3D11_AUTHENTICATED_CHANNEL_D3D11, because the Direct3D11 channel does not support authentication.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-negotiateauthenticatedchannelkeyexchange
		// HRESULT NegotiateAuthenticatedChannelKeyExchange( [in] ID3D11AuthenticatedChannel *pChannel, [in] UINT DataSize, [in, out] void
		// *pData );
		[PreserveSig]
		new HRESULT NegotiateAuthenticatedChannelKeyExchange([In] ID3D11AuthenticatedChannel pChannel, uint DataSize, [In, Out] IntPtr pData);

		/// <summary>Sends a query to an authenticated channel.</summary>
		/// <param name="pChannel">A pointer to the ID3D11AuthenticatedChannel interface.</param>
		/// <param name="InputSize">The size of the <c>pInput</c> array, in bytes.</param>
		/// <param name="pInput">
		/// A pointer to a byte array that contains input data for the query. This array always starts with a
		/// D3D11_AUTHENTICATED_QUERY_INPUT structure. The <c>QueryType</c> member of the structure specifies the query and defines the
		/// meaning of the rest of the array.
		/// </param>
		/// <param name="OutputSize">The size of the <c>pOutput</c> array, in bytes.</param>
		/// <param name="pOutput">
		/// A pointer to a byte array that receives the result of the query. This array always starts with a
		/// D3D11_AUTHENTICATED_QUERY_OUTPUT structure. The meaning of the rest of the array depends on the query.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-queryauthenticatedchannel HRESULT
		// QueryAuthenticatedChannel( [in] ID3D11AuthenticatedChannel *pChannel, [in] UINT InputSize, [in] const void *pInput, [in] UINT
		// OutputSize, [out] void *pOutput );
		[PreserveSig]
		new HRESULT QueryAuthenticatedChannel([In] ID3D11AuthenticatedChannel pChannel, uint InputSize, [In] IntPtr pInput, uint OutputSize, [Out] IntPtr pOutput);

		/// <summary>Sends a configuration command to an authenticated channel.</summary>
		/// <param name="pChannel">A pointer to the ID3D11AuthenticatedChannel interface.</param>
		/// <param name="InputSize">The size of the <c>pInput</c> array, in bytes.</param>
		/// <param name="pInput">
		/// A pointer to a byte array that contains input data for the command. This buffer always starts with a
		/// D3D11_AUTHENTICATED_CONFIGURE_INPUT structure. The <c>ConfigureType</c> member of the structure specifies the command and
		/// defines the meaning of the rest of the buffer.
		/// </param>
		/// <param name="pOutput">A pointer to a D3D11_AUTHENTICATED_CONFIGURE_OUTPUT structure that receives the response to the command.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-configureauthenticatedchannel HRESULT
		// ConfigureAuthenticatedChannel( [in] ID3D11AuthenticatedChannel *pChannel, [in] UINT InputSize, [in] const void *pInput, [out]
		// D3D11_AUTHENTICATED_CONFIGURE_OUTPUT *pOutput );
		[PreserveSig]
		new HRESULT ConfigureAuthenticatedChannel([In] ID3D11AuthenticatedChannel pChannel, uint InputSize, [In] IntPtr pInput, out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT pOutput);

		/// <summary>Sets the stream rotation for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies if the stream is to be rotated in a clockwise orientation.</param>
		/// <param name="Rotation">Specifies the rotation of the stream.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This is an optional state and the application should only use it if D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ROTATION is reported in D3D11_VIDEO_PROCESSOR_CAPS.FeatureCaps.
		/// </para>
		/// <para>
		/// The stream source rectangle will be specified in the pre-rotation coordinates (typically landscape) and the stream destination
		/// rectangle will be specified in the post-rotation coordinates (typically portrait). The application must update the stream
		/// destination rectangle correctly when using a rotation value other than 0° and 180°.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamrotation void
		// VideoProcessorSetStreamRotation( ID3D11VideoProcessor *pVideoProcessor, UINT StreamIndex, BOOL Enable,
		// D3D11_VIDEO_PROCESSOR_ROTATION Rotation );
		[PreserveSig]
		new void VideoProcessorSetStreamRotation([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_ROTATION Rotation);

		/// <summary>Gets the stream rotation for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnable">Specifies if the stream is rotated.</param>
		/// <param name="pRotation">Specifies the rotation of the stream in a clockwise orientation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamrotation void
		// VideoProcessorGetStreamRotation( ID3D11VideoProcessor *pVideoProcessor, UINT StreamIndex, BOOL *pEnable,
		// D3D11_VIDEO_PROCESSOR_ROTATION *pRotation );
		[PreserveSig]
		new void VideoProcessorGetStreamRotation([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_ROTATION pRotation);

		/// <summary>Submits one or more buffers for decoding.</summary>
		/// <param name="pDecoder">
		/// <para>Type: <c>ID3D11VideoDecoder*</c></para>
		/// <para>A pointer to the ID3D11VideoDecoder interface. To get this pointer, call the ID3D11VideoDevice::CreateVideoDecoder method.</para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of buffers submitted for decoding.</para>
		/// </param>
		/// <param name="pBufferDesc">
		/// <para>Type: <c>const D3D11_VIDEO_DECODER_BUFFER_DESC1*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_VIDEO_DECODER_BUFFER_DESC1 structures. The <c>NumBuffers</c> parameter specifies the number of
		/// elements in the array. Each element in the array describes a compressed buffer for decoding.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function does not honor any D3D11 predicate that may have been set.</para>
		/// <para>D3D11_QUERY_DATA_PIPELINE_STATISTICS will not include this function for any feature level.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-submitdecoderbuffers1 HRESULT
		// SubmitDecoderBuffers1( [in] ID3D11VideoDecoder *pDecoder, [in] UINT NumBuffers, [in] const D3D11_VIDEO_DECODER_BUFFER_DESC1
		// *pBufferDesc );
		[PreserveSig]
		new HRESULT SubmitDecoderBuffers1([In] ID3D11VideoDecoder pDecoder, int NumBuffers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC1[] pBufferDesc);

		/// <summary>Allows the driver to return IHV specific information used when initializing the new hardware key.</summary>
		/// <param name="pCryptoSession">
		/// <para>Type: <c>ID3D11CryptoSession*</c></para>
		/// <para>A pointer to the ID3D11CryptoSession interface. To get this pointer, call ID3D11VideoDevice1::CreateCryptoSession.</para>
		/// </param>
		/// <param name="PrivateInputSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the memory referenced by the <c>pPrivateInputData</c> parameter.</para>
		/// </param>
		/// <param name="pPrivatInputData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// The private input data. The contents of this parameter is defined by the implementation of the secure execution environment. It
		/// may contain data about the license or about the stream properties.
		/// </para>
		/// </param>
		/// <param name="pPrivateOutputData">
		/// <para>Type: <c>UINT64*</c></para>
		/// <para>
		/// A pointer to the private output data. The return data is defined by the implementation of the secure execution environment. It
		/// may contain graphics-specific data to be associated with the underlying hardware key.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to complete the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-getdatafornewhardwarekey HRESULT
		// GetDataForNewHardwareKey( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT PrivateInputSize, [in] const void
		// *pPrivatInputData, [out] UINT64 *pPrivateOutputData );
		[PreserveSig]
		new HRESULT GetDataForNewHardwareKey([In] ID3D11CryptoSession pCryptoSession, uint PrivateInputSize, [In] IntPtr pPrivatInputData, out ulong pPrivateOutputData);

		/// <summary>Checks the status of a crypto session.</summary>
		/// <param name="pCryptoSession">
		/// <para>Type: <c>ID3D11CryptoSession*</c></para>
		/// <para>Specifies a ID3D11CryptoSession for which status is checked.</para>
		/// </param>
		/// <param name="pStatus">
		/// <para>Type: <c>D3D11_CRYPTO_SESSION_STATUS*</c></para>
		/// <para>A D3D11_CRYPTO_SESSION_STATUS that is populated with the crypto session status upon completion.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to complete the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-checkcryptosessionstatus HRESULT
		// CheckCryptoSessionStatus( [in] ID3D11CryptoSession *pCryptoSession, [out] D3D11_CRYPTO_SESSION_STATUS *pStatus );
		[PreserveSig]
		new HRESULT CheckCryptoSessionStatus([In] ID3D11CryptoSession pCryptoSession, out D3D11_CRYPTO_SESSION_STATUS pStatus);

		/// <summary>Indicates that decoder downsampling will be used and that the driver should allocate the appropriate reference frames.</summary>
		/// <param name="pDecoder">
		/// <para>Type: <c>ID3D11VideoDecoder*</c></para>
		/// <para>A pointer to the ID3D11VideoDecoder interface.</para>
		/// </param>
		/// <param name="InputColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE</c></para>
		/// <para>The color space information of the reference frame data.</para>
		/// </param>
		/// <param name="pOutputDesc">
		/// <para>Type: <c>const D3D11_VIDEO_SAMPLE_DESC*</c></para>
		/// <para>
		/// The resolution, format, and colorspace of the output/display frames. This is the destination resolution and format of the
		/// downsample operation.
		/// </para>
		/// </param>
		/// <param name="ReferenceFrameCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of reference frames to be used in the operation.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to complete the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function can only be called once for a specific ID3D11VideoDecoder interface. This method must be called prior to the first
		/// call to DecoderBeginFrame. To update the downsampling parameters, use DecoderUpdateDownsampling.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-decoderenabledownsampling HRESULT
		// DecoderEnableDownsampling( [in] ID3D11VideoDecoder *pDecoder, [in] DXGI_COLOR_SPACE_TYPE InputColorSpace, [in] const
		// D3D11_VIDEO_SAMPLE_DESC *pOutputDesc, [in] UINT ReferenceFrameCount );
		[PreserveSig]
		new HRESULT DecoderEnableDownsampling([In] ID3D11VideoDecoder pDecoder, DXGI_COLOR_SPACE_TYPE InputColorSpace, in D3D11_VIDEO_SAMPLE_DESC pOutputDesc, uint ReferenceFrameCount);

		/// <summary>Updates the decoder downsampling parameters.</summary>
		/// <param name="pDecoder">
		/// <para>Type: <c>ID3D11VideoDecoder*</c></para>
		/// <para>A pointer to the ID3D11VideoDecoder interface.</para>
		/// </param>
		/// <param name="pOutputDesc">
		/// <para>Type: <c>const D3D11_VIDEO_SAMPLE_DESC*</c></para>
		/// <para>
		/// The resolution, format, and colorspace of the output/display frames. This is the destination resolution and format of the
		/// downsample operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to complete the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method can only be called after decode downsampling is enabled by calling DecoderEnableDownsampling. This method is only
		/// supported if the D3D11_VIDEO_DECODER_CAPS_DOWNSAMPLE_DYNAMIC capability is reported.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-decoderupdatedownsampling HRESULT
		// DecoderUpdateDownsampling( [in] ID3D11VideoDecoder *pDecoder, [in] const D3D11_VIDEO_SAMPLE_DESC *pOutputDesc );
		[PreserveSig]
		new HRESULT DecoderUpdateDownsampling([In] ID3D11VideoDecoder pDecoder, in D3D11_VIDEO_SAMPLE_DESC pOutputDesc);

		/// <summary>Sets the color space information for the video processor output surface.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="ColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE</c></para>
		/// <para>A DXGI_COLOR_SPACE_TYPE value that specifies the colorspace for the video processor output surface.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorsetoutputcolorspace1
		// void VideoProcessorSetOutputColorSpace1( [in] ID3D11VideoProcessor *pVideoProcessor, [in] DXGI_COLOR_SPACE_TYPE ColorSpace );
		[PreserveSig]
		new void VideoProcessorSetOutputColorSpace1([In] ID3D11VideoProcessor pVideoProcessor, DXGI_COLOR_SPACE_TYPE ColorSpace);

		/// <summary>
		/// Sets a value indicating whether the output surface from a call to ID3D11VideoContext::VideoProcessorBlt will be read by Direct3D shaders.
		/// </summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="ShaderUsage">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// True if the surface rendered using ID3D11VideoContext::VideoProcessorBlt will be read by Direct3D shaders; otherwise, false.
		/// This may be set to false when multi-plane overlay hardware is supported.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorsetoutputshaderusage
		// void VideoProcessorSetOutputShaderUsage( [in] ID3D11VideoProcessor *pVideoProcessor, [in] BOOL ShaderUsage );
		[PreserveSig]
		new void VideoProcessorSetOutputShaderUsage([In] ID3D11VideoProcessor pVideoProcessor, bool ShaderUsage);

		/// <summary>Gets the color space information for the video processor output surface.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="pColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE*</c></para>
		/// <para>A pointer to a DXGI_COLOR_SPACE_TYPE value that indicates the colorspace for the video processor output surface.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorgetoutputcolorspace1
		// void VideoProcessorGetOutputColorSpace1( [in] ID3D11VideoProcessor *pVideoProcessor, [out] DXGI_COLOR_SPACE_TYPE *pColorSpace );
		[PreserveSig]
		new void VideoProcessorGetOutputColorSpace1([In] ID3D11VideoProcessor pVideoProcessor, out DXGI_COLOR_SPACE_TYPE pColorSpace);

		/// <summary>
		/// Gets a value indicating whether the output surface from a call to ID3D11VideoContext::VideoProcessorBlt can be read by Direct3D shaders.
		/// </summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="pShaderUsage">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a boolean value indicating if the output surface can be read by Direct3D shaders. True if the surface rendered
		/// using ID3D11VideoContext::VideoProcessorBlt can be read by Direct3D shaders; otherwise, false.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorgetoutputshaderusage
		// void VideoProcessorGetOutputShaderUsage( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pShaderUsage );
		[PreserveSig]
		new void VideoProcessorGetOutputShaderUsage([In] ID3D11VideoProcessor pVideoProcessor, out bool pShaderUsage);

		/// <summary>Sets the color space information for the video processor input stream.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="StreamIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An index identifying the input stream.</para>
		/// </param>
		/// <param name="ColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE</c></para>
		/// <para>A DXGI_COLOR_SPACE_TYPE value that specifies the colorspace for the video processor input stream.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorsetstreamcolorspace1
		// void VideoProcessorSetStreamColorSpace1( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// DXGI_COLOR_SPACE_TYPE ColorSpace );
		[PreserveSig]
		new void VideoProcessorSetStreamColorSpace1([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, DXGI_COLOR_SPACE_TYPE ColorSpace);

		/// <summary>Specifies whether the video processor input stream should be flipped vertically or horizontally.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="StreamIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An index identifying the input stream.</para>
		/// </param>
		/// <param name="Enable">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if mirroring should be enabled; otherwise, false.</para>
		/// </param>
		/// <param name="FlipHorizontal">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the stream should be flipped horizontally; otherwise, false.</para>
		/// </param>
		/// <param name="FlipVertical">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the stream should be flipped vertically; otherwise, false.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>When used in combination, transformations on the processor input stream should be applied in the following order:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Rotation</description>
		/// </item>
		/// <item>
		/// <description>Mirroring</description>
		/// </item>
		/// <item>
		/// <description>Source clipping</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorsetstreammirror void
		// VideoProcessorSetStreamMirror( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] BOOL
		// FlipHorizontal, [in] BOOL FlipVertical );
		[PreserveSig]
		new void VideoProcessorSetStreamMirror([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, bool FlipHorizontal, bool FlipVertical);

		/// <summary>Gets the color space information for the video processor input stream.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="StreamIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An index identifying the input stream.</para>
		/// </param>
		/// <param name="pColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE*</c></para>
		/// <para>A pointer to a DXGI_COLOR_SPACE_TYPE value that specifies the colorspace for the video processor input stream.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorgetstreamcolorspace1
		// void VideoProcessorGetStreamColorSpace1( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out]
		// DXGI_COLOR_SPACE_TYPE *pColorSpace );
		[PreserveSig]
		new void VideoProcessorGetStreamColorSpace1([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out DXGI_COLOR_SPACE_TYPE pColorSpace);

		/// <summary>Gets values that indicate whether the video processor input stream is being flipped vertically or horizontally.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="StreamIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An index identifying the input stream.</para>
		/// </param>
		/// <param name="pEnable">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A pointer to a boolean value indicating whether mirroring is enabled. True if mirroring is enabled; otherwise, false.</para>
		/// </param>
		/// <param name="pFlipHorizontal">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a boolean value indicating whether the stream is being flipped horizontally. True if the stream is being flipped
		/// horizontally; otherwise, false.
		/// </para>
		/// </param>
		/// <param name="pFlipVertical">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a boolean value indicating whether the stream is being flipped vertically. True if the stream is being flipped
		/// vertically; otherwise, false.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorgetstreammirror void
		// VideoProcessorGetStreamMirror( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnable, [out] BOOL
		// *pFlipHorizontal, [out] BOOL *pFlipVertical );
		[PreserveSig]
		new void VideoProcessorGetStreamMirror([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out bool pFlipHorizontal, out bool pFlipVertical);

		/// <summary>
		/// Returns driver hints that indicate which of the video processor operations are best performed using multi-plane overlay hardware
		/// rather than ID3D11VideoContext::VideoProcessorBlt method.
		/// </summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="OutputWidth">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of the output stream.</para>
		/// </param>
		/// <param name="OutputHeight">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height of the output stream.</para>
		/// </param>
		/// <param name="OutputFormat">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The format of the output stream.</para>
		/// </param>
		/// <param name="StreamCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of input streams to process.</para>
		/// </param>
		/// <param name="pStreams">
		/// <para>Type: <c>const D3D11_VIDEO_PROCESSOR_STREAM_BEHAVIOR_HINT*</c></para>
		/// <para>
		/// An array of structures that specifies the format of each input stream and whether each stream should be used when computing
		/// behavior hints.
		/// </para>
		/// </param>
		/// <param name="pBehaviorHints">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer to a bitwise OR combination of D3D11_VIDEO_PROCESSOR_BEHAVIOR_HINTS values indicating which video processor operations
		/// would best be performed using multi-plane overlay hardware rather than the ID3D11VideoContext::VideoProcessorBlt method.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to complete the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method computes the behavior hints using the current state of the video processor as set by the "SetOutput" and "SetStream"
		/// methods of ID3D11VideoContext and ID3D11VideoContext1. You must set the proper state before calling this method to ensure that
		/// the returned hints contain useful data.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorgetbehaviorhints HRESULT
		// VideoProcessorGetBehaviorHints( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT OutputWidth, [in] UINT OutputHeight, [in]
		// DXGI_FORMAT OutputFormat, [in] UINT StreamCount, [in] const D3D11_VIDEO_PROCESSOR_STREAM_BEHAVIOR_HINT *pStreams, [out] UINT
		// *pBehaviorHints );
		[PreserveSig]
		new HRESULT VideoProcessorGetBehaviorHints([In] ID3D11VideoProcessor pVideoProcessor, uint OutputWidth, uint OutputHeight, DXGI_FORMAT OutputFormat,
			int StreamCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D11_VIDEO_PROCESSOR_STREAM_BEHAVIOR_HINT[] pStreams, out uint pBehaviorHints);

		/// <summary>Sets the HDR metadata describing the display on which the content will be presented.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface.</param>
		/// <param name="Type">The type of HDR metadata supplied.</param>
		/// <param name="Size">
		/// <para>The size of the HDR metadata supplied in <c>pHDRMetaData</c>.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_NONE</c>, the size should be 0.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_HDR10</c>, the size is .</para>
		/// </param>
		/// <param name="pHDRMetaData">
		/// <para>Pointer to the metadata information.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_NONE</c>, this should be NULL.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_HDR10</c>, this is a pointer to a DXGI_HDR_METADATA_HDR10 structure.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>When processing an HDR stream, the driver may use this metadata optimize the video for the output display.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11videocontext2-videoprocessorsetoutputhdrmetadata
		// void VideoProcessorSetOutputHDRMetaData( [in] ID3D11VideoProcessor *pVideoProcessor, [in] DXGI_HDR_METADATA_TYPE Type, [in] UINT
		// Size, [in] const void *pHDRMetaData );
		[PreserveSig]
		void VideoProcessorSetOutputHDRMetaData([In] ID3D11VideoProcessor pVideoProcessor, DXGI_HDR_METADATA_TYPE Type, uint Size, [In] IntPtr pHDRMetaData);

		/// <summary>Gets the HDR metadata describing the display on which the content will be presented.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface.</param>
		/// <param name="pType">The type of HDR metadata supplied.</param>
		/// <param name="Size">
		/// <para>The size of the memory referenced by <c>pHDRMetaData</c>.</para>
		/// <para>If <c>pHDRMetaData</c> is NULL, <c>Size</c> should be 0.</para>
		/// </param>
		/// <param name="pMetaData">
		/// <para>Pointer to a buffer that receives the HDR metadata.</para>
		/// <para>This parameter can be NULL.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This can be called multiple times, the first time to get the <c>Type</c> (in which case <c>Size</c> can be 0 and
		/// <c>pHDRMetaData</c> can be NULL) and then again to with non-NULL values to retrieve the actual metadata.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11videocontext2-videoprocessorgetoutputhdrmetadata
		// void VideoProcessorGetOutputHDRMetaData( [in] ID3D11VideoProcessor *pVideoProcessor, [out] DXGI_HDR_METADATA_TYPE *pType, [in]
		// UINT Size, [out] void *pMetaData );
		[PreserveSig]
		void VideoProcessorGetOutputHDRMetaData([In] ID3D11VideoProcessor pVideoProcessor, out DXGI_HDR_METADATA_TYPE pType, uint Size, [Out] IntPtr pMetaData);

		/// <summary>Sets the HDR metadata associated with the video stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface.</param>
		/// <param name="StreamIndex">Identifies the input stream.</param>
		/// <param name="Type">The type of HDR metadata supplied.</param>
		/// <param name="Size">
		/// <para>The size of the HDR metadata supplied in <c>pHDRMetaData</c>.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_NONE</c>, the size should be 0.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_HDR10</c>, the size is .</para>
		/// </param>
		/// <param name="pHDRMetaData">
		/// <para>Pointer to the metadata information.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_NONE</c>, this should be NULL.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_HDR10</c>, this is a pointer to a DXGI_HDR_METADATA_HDR10 structure.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When processing an HDR stream, the driver may use this information to tone map the video content to optimize it for the output display.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11videocontext2-videoprocessorsetstreamhdrmetadata
		// void VideoProcessorSetStreamHDRMetaData( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// DXGI_HDR_METADATA_TYPE Type, [in] UINT Size, [in] const void *pHDRMetaData );
		[PreserveSig]
		void VideoProcessorSetStreamHDRMetaData([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, DXGI_HDR_METADATA_TYPE Type, uint Size, [In] IntPtr pHDRMetaData);

		/// <summary>Gets the HDR metadata associated with the video stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface.</param>
		/// <param name="StreamIndex">Identifies the input stream.</param>
		/// <param name="pType">The type of the HDR metadata currently associated with the stream.</param>
		/// <param name="Size">
		/// <para>The size of the memory referenced by <c>pHDRMetaData</c>.</para>
		/// <para>If <c>pHDRMetaData</c> is NULL, <c>Size</c> should be 0.</para>
		/// </param>
		/// <param name="pMetaData">
		/// <para>Pointer to a buffer that receives the HDR metadata.</para>
		/// <para>This parameter can be NULL.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This can be called multiple times, the first time to get the <c>Type</c> (in which case <c>Size</c> can be 0 and
		/// <c>pHDRMetaData</c> can be NULL) and then again to with non-NULL values to retrieve the actual metadata.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11videocontext2-videoprocessorgetstreamhdrmetadata
		// void VideoProcessorGetStreamHDRMetaData( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out]
		// DXGI_HDR_METADATA_TYPE *pType, [in] UINT Size, [out] void *pMetaData );
		[PreserveSig]
		void VideoProcessorGetStreamHDRMetaData([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out DXGI_HDR_METADATA_TYPE pType, uint Size, [Out] IntPtr pMetaData);
	}

	/// <summary>
	/// Provides the video functionality of a Microsoft Direct3D 11 device. This interface provides the DecoderBeginFrame1 method, which
	/// provides support for decode histograms.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11videocontext3
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11VideoContext3")]
	[ComImport, Guid("a9e2faa0-cb39-418f-a0b7-d8aad4de672e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoContext3 : ID3D11VideoContext2, ID3D11VideoContext1, ID3D11VideoContext, ID3D11DeviceChild
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

		/// <summary>Gets a pointer to a decoder buffer.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="Type">The type of buffer to retrieve, specified as a member of the D3D11_VIDEO_DECODER_BUFFER_TYPE enumeration.</param>
		/// <param name="pBufferSize">Receives the size of the buffer, in bytes.</param>
		/// <param name="ppBuffer">Receives a pointer to the start of the memory buffer.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// The graphics driver allocates the buffers that are used for decoding. This method locks the Microsoft Direct3Dsurface that
		/// contains the buffer. When you are done using the buffer, call ID3D11VideoContext::ReleaseDecoderBuffer to unlock the surface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-getdecoderbuffer HRESULT GetDecoderBuffer(
		// [in] ID3D11VideoDecoder *pDecoder, [in] D3D11_VIDEO_DECODER_BUFFER_TYPE Type, [out] UINT *pBufferSize, [out] void **ppBuffer );
		[PreserveSig]
		new HRESULT GetDecoderBuffer([In] ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type, out uint pBufferSize, out IntPtr ppBuffer);

		/// <summary>Releases a buffer that was obtained by calling the ID3D11VideoContext::GetDecoderBuffer method.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="Type">
		/// The type of buffer to release. Specify the same value that was used in the <c>Type</c> parameter of the GetDecoderBuffer method.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-releasedecoderbuffer HRESULT
		// ReleaseDecoderBuffer( [in] ID3D11VideoDecoder *pDecoder, [in] D3D11_VIDEO_DECODER_BUFFER_TYPE Type );
		[PreserveSig]
		new HRESULT ReleaseDecoderBuffer([In] ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type);

		/// <summary>Starts a decoding operation to decode a video frame.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="pView">
		/// A pointer to the ID3D11VideoDecoderOutputView interface. This interface describes the resource that will receive the decoded
		/// frame. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoderOutputView.
		/// </param>
		/// <param name="ContentKeySize">
		/// The size of the content key that is specified in <c>pContentKey</c>. If <c>pContentKey</c> is NULL, set <c>ContentKeySize</c> to zero.
		/// </param>
		/// <param name="pContentKey">
		/// An optional pointer to a content key that was used to encrypt the frame data. If no content key was used, set this parameter to
		/// <c>NULL</c>. If the caller provides a content key, the caller must use the session key to encrypt the content key.
		/// </param>
		/// <returns>
		/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.
		/// <c>D3DERR_WASSTILLDRAWING</c> or <c>E_PENDING</c> is returned if the hardware is busy, in which case the decoder should try to
		/// make the call again.
		/// </returns>
		/// <remarks>
		/// <para>
		/// After this method is called, call ID3D11VideoContext::SubmitDecoderBuffers to perform decoding operations. When all decoding
		/// operations have been executed, call ID3D11VideoContext::DecoderEndFrame.
		/// </para>
		/// <para>
		/// Each call to <c>DecoderBeginFrame</c> must have a matching call to DecoderEndFrame. In most cases you cannot nest
		/// <c>DecoderBeginFrame</c> calls, but some codecs, such as like VC-1, can have nested <c>DecoderBeginFrame</c> calls for special
		/// operations like post processing.
		/// </para>
		/// <para>The following encryption scenarios are supported through the content key:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The decoder can choose to not encrypt every frame, for example it may only encrypt the I frames and not encrypt the P/B frames.
		/// In these scenario, the decoder will specify pContentKey = NULL and ContentKeySize = 0 for those frames that it does not encrypt.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The decoder can choose to encrypt the compressed buffers using the session key. In this scenario, the decoder will specify a
		/// content key containing all zeros.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The decoder can choose to encrypt the compressed buffers using a separate content key. In this scenario, the decoder will ECB
		/// encrypt the content key using the session key and pass the encrypted content key.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decoderbeginframe HRESULT
		// DecoderBeginFrame( [in] ID3D11VideoDecoder *pDecoder, [in] ID3D11VideoDecoderOutputView *pView, [in] UINT ContentKeySize, [in]
		// const void *pContentKey );
		[PreserveSig]
		new HRESULT DecoderBeginFrame([In] ID3D11VideoDecoder pDecoder, [In] ID3D11VideoDecoderOutputView pView, uint ContentKeySize, [In] IntPtr pContentKey);

		/// <summary>Signals the end of a decoding operation.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decoderendframe HRESULT DecoderEndFrame(
		// [in] ID3D11VideoDecoder *pDecoder );
		[PreserveSig]
		new HRESULT DecoderEndFrame([In] ID3D11VideoDecoder pDecoder);

		/// <summary>Submits one or more buffers for decoding.</summary>
		/// <param name="pDecoder">
		/// A pointer to the ID3D11VideoDecoder interface. To get this pointer, call the ID3D11VideoDevice::CreateVideoDecoder method.
		/// </param>
		/// <param name="NumBuffers">The number of buffers submitted for decoding.</param>
		/// <param name="pBufferDesc">
		/// A pointer to an array of D3D11_VIDEO_DECODER_BUFFER_DESC structures. The <c>NumBuffers</c> parameter specifies the number of
		/// elements in the array. Each element in the array describes a compressed buffer for decoding.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// <para>
		/// When using feature levels 9_x, all partially encrypted buffers must use the same EncryptedBlockInfo, and partial encryption
		/// cannot be turned off on a per frame basis.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-submitdecoderbuffers HRESULT
		// SubmitDecoderBuffers( [in] ID3D11VideoDecoder *pDecoder, [in] UINT NumBuffers, [in] const D3D11_VIDEO_DECODER_BUFFER_DESC
		// *pBufferDesc );
		[PreserveSig]
		new HRESULT SubmitDecoderBuffers([In] ID3D11VideoDecoder pDecoder, int NumBuffers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC[] pBufferDesc);

		/// <summary>Performs an extended function for decoding. This method enables extensions to the basic decoder functionality.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="pExtensionData">A pointer to a D3D11_VIDEO_DECODER_EXTENSION structure that contains data for the function.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decoderextension APP_DEPRECATED_HRESULT
		// DecoderExtension( [in] ID3D11VideoDecoder *pDecoder, [in] const D3D11_VIDEO_DECODER_EXTENSION *pExtensionData );
		[PreserveSig]
		new int DecoderExtension([In] ID3D11VideoDecoder pDecoder, in D3D11_VIDEO_DECODER_EXTENSION pExtensionData);

		/// <summary>Sets the target rectangle for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enable">Specifies whether to apply the target rectangle.</param>
		/// <param name="pRect">
		/// A pointer to a RECT structure that specifies the target rectangle. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The target rectangle is the area within the destination surface where the output will be drawn. The target rectangle is given in
		/// pixel coordinates, relative to the destination surface.
		/// </para>
		/// <para>
		/// If this method is never called, or if the <c>Enable</c> parameter is <c>FALSE</c>, the video processor writes to the entire
		/// destination surface.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputtargetrect void
		// VideoProcessorSetOutputTargetRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] BOOL Enable, [in] const RECT *pRect );
		[PreserveSig]
		new void VideoProcessorSetOutputTargetRect([In] ID3D11VideoProcessor pVideoProcessor, bool Enable, [In, Optional] PRECT? pRect);

		/// <summary>Sets the background color for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="YCbCr">If <c>TRUE</c>, the color is specified as a YCbCr value. Otherwise, the color is specified as an RGB value.</param>
		/// <param name="pColor">A pointer to a D3D11_VIDEO_COLOR structure that specifies the background color.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The video processor uses the background color to fill areas of the target rectangle that do not contain a video image. Areas
		/// outside the target rectangle are not affected.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputbackgroundcolor void
		// VideoProcessorSetOutputBackgroundColor( [in] ID3D11VideoProcessor *pVideoProcessor, [in] BOOL YCbCr, [in] const D3D11_VIDEO_COLOR
		// *pColor );
		[PreserveSig]
		new void VideoProcessorSetOutputBackgroundColor([In] ID3D11VideoProcessor pVideoProcessor, bool YCbCr, in D3D11_VIDEO_COLOR pColor);

		/// <summary>Sets the output color space for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pColorSpace">A pointer to a D3D11_VIDEO_PROCESSOR_COLOR_SPACE structure that specifies the color space.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputcolorspace void
		// VideoProcessorSetOutputColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, [in] const D3D11_VIDEO_PROCESSOR_COLOR_SPACE
		// *pColorSpace );
		[PreserveSig]
		new void VideoProcessorSetOutputColorSpace([In] ID3D11VideoProcessor pVideoProcessor, in D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Sets the alpha fill mode for data that the video processor writes to the render target.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="AlphaFillMode">The alpha fill mode, specified as a D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE value.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of an input stream. This parameter is used if <c>AlphaFillMode</c> is
		/// <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM</c>. Otherwise, the parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To find out which fill modes the device supports, call the ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps method. If the
		/// driver reports the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_FILL</c> capability, the driver supports all of the fill modes.
		/// Otherwise, the <c>AlphaFillMode</c> parameter must be <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE</c>.
		/// </para>
		/// <para>The default fill mode is <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputalphafillmode void
		// VideoProcessorSetOutputAlphaFillMode( [in] ID3D11VideoProcessor *pVideoProcessor, [in] D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE
		// AlphaFillMode, [in] UINT StreamIndex );
		[PreserveSig]
		new void VideoProcessorSetOutputAlphaFillMode([In] ID3D11VideoProcessor pVideoProcessor, D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE AlphaFillMode, uint StreamIndex);

		/// <summary>Sets the amount of downsampling to perform on the output.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enable">
		/// If <c>TRUE</c>, downsampling is enabled. Otherwise, downsampling is disabled and the <c>Size</c> member is ignored.
		/// </param>
		/// <param name="Size">The sampling size.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Downsampling is sometimes used to reduce the quality of premium content when other forms of content protection are not
		/// available. By default, downsampling is disabled.
		/// </para>
		/// <para>
		/// If the <c>Enable</c> parameter is <c>TRUE</c>, the driver downsamples the composed image to the specified size, and then scales
		/// it back to the size of the target rectangle.
		/// </para>
		/// <para>
		/// The width and height of <c>Size</c> must be greater than zero. If the size is larger than the target rectangle, downsampling
		/// does not occur.
		/// </para>
		/// <para>
		/// To use this feature, the driver must support downsampling, indicated by the
		/// <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_CONSTRICTION</c> capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputconstriction void
		// VideoProcessorSetOutputConstriction( [in] ID3D11VideoProcessor *pVideoProcessor, BOOL Enable, SIZE Size );
		[PreserveSig]
		new void VideoProcessorSetOutputConstriction([In] ID3D11VideoProcessor pVideoProcessor, bool Enable, SIZE Size);

		/// <summary>Specifies whether the video processor produces stereo video frames.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enable">If <c>TRUE</c>, stereo output is enabled. Otherwise, the video processor produces mono video frames.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>By default, the video processor produces mono video frames.</para>
		/// <para>
		/// To use this feature, the driver must support stereo video, indicated by the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_STEREO</c>
		/// capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputstereomode void
		// VideoProcessorSetOutputStereoMode( [in] ID3D11VideoProcessor *pVideoProcessor, BOOL Enable );
		[PreserveSig]
		new void VideoProcessorSetOutputStereoMode([In] ID3D11VideoProcessor pVideoProcessor, bool Enable);

		/// <summary>Sets a driver-specific video processing state.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the operation. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">
		/// A pointer to a buffer that contains private state data. The method passes this buffer directly to the driver without validation.
		/// It is the responsibility of the driver to validate the data.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputextension
		// APP_DEPRECATED_HRESULT VideoProcessorSetOutputExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] const GUID
		// *pExtensionGuid, [in] UINT DataSize, [in] void *pData );
		[PreserveSig]
		new int VideoProcessorSetOutputExtension([In] ID3D11VideoProcessor pVideoProcessor, in Guid pExtensionGuid, uint DataSize, [In] IntPtr pData);

		/// <summary>Gets the current target rectangle for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enabled">
		/// Receives the value <c>TRUE</c> if the target rectangle was explicitly set using the
		/// ID3D11VideoContext::VideoProcessorSetOutputTargetRect method. Receives the value FALSE if the target rectangle was disabled or
		/// was never set.
		/// </param>
		/// <param name="pRect">
		/// If <c>Enabled</c> receives the value <c>TRUE</c>, this parameter receives the target rectangle. Otherwise, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputtargetrect void
		// VideoProcessorGetOutputTargetRect( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *Enabled, [out] RECT *pRect );
		[PreserveSig]
		new void VideoProcessorGetOutputTargetRect([In] ID3D11VideoProcessor pVideoProcessor, out bool Enabled, out RECT pRect);

		/// <summary>Gets the current background color for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pYCbCr">
		/// Receives the value <c>TRUE</c> if the background color is a YCbCr color, or <c>FALSE</c> if the background color is an RGB color.
		/// </param>
		/// <param name="pColor">A pointer to a D3D11_VIDEO_COLOR structure. The method fills in the structure with the background color.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputbackgroundcolor void
		// VideoProcessorGetOutputBackgroundColor( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pYCbCr, [out] D3D11_VIDEO_COLOR
		// *pColor );
		[PreserveSig]
		new void VideoProcessorGetOutputBackgroundColor([In] ID3D11VideoProcessor pVideoProcessor, out bool pYCbCr, out D3D11_VIDEO_COLOR pColor);

		/// <summary>Gets the current output color space for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pColorSpace">
		/// A pointer to a D3D11_VIDEO_PROCESSOR_COLOR_SPACE structure. The method fills in the structure with the output color space.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputcolorspace void
		// VideoProcessorGetOutputColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, [out] D3D11_VIDEO_PROCESSOR_COLOR_SPACE
		// *pColorSpace );
		[PreserveSig]
		new void VideoProcessorGetOutputColorSpace([In] ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Gets the current alpha fill mode for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pAlphaFillMode">Receives the alpha fill mode, as a D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE value.</param>
		/// <param name="pStreamIndex">
		/// If the alpha fill mode is <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM</c>, this parameter receives the zero-based
		/// index of an input stream. The input stream provides the alpha values for the alpha fill.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputalphafillmode void
		// VideoProcessorGetOutputAlphaFillMode( [in] ID3D11VideoProcessor *pVideoProcessor, [out] D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE
		// *pAlphaFillMode, [out] UINT *pStreamIndex );
		[PreserveSig]
		new void VideoProcessorGetOutputAlphaFillMode([In] ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE pAlphaFillMode, out uint pStreamIndex);

		/// <summary>Gets the current level of downsampling that is performed by the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pEnabled">
		/// Receives the value <c>TRUE</c> if downsampling was explicitly enabled using the
		/// ID3D11VideoContext::VideoProcessorSetOutputConstriction method. Receives the value <c>FALSE</c> if the downsampling was disabled
		/// or was never set.
		/// </param>
		/// <param name="pSize">
		/// If <c>Enabled</c> receives the value <c>TRUE</c>, this parameter receives the downsampling size. Otherwise, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputconstriction void
		// VideoProcessorGetOutputConstriction( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pEnabled, [out] SIZE *pSize );
		[PreserveSig]
		new void VideoProcessorGetOutputConstriction([In] ID3D11VideoProcessor pVideoProcessor, out bool pEnabled, out SIZE pSize);

		/// <summary>Queries whether the video processor produces stereo video frames.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if stereo output is enabled, or <c>FALSE</c> otherwise.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputstereomode void
		// VideoProcessorGetOutputStereoMode( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pEnabled );
		[PreserveSig]
		new void VideoProcessorGetOutputStereoMode([In] ID3D11VideoProcessor pVideoProcessor, out bool pEnabled);

		/// <summary>Gets private state data from the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the state. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">A pointer to a buffer that receives the private state data.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputextension
		// APP_DEPRECATED_HRESULT VideoProcessorGetOutputExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] const GUID
		// *pExtensionGuid, [in] UINT DataSize, [out] void *pData );
		[PreserveSig]
		new int VideoProcessorGetOutputExtension([In] ID3D11VideoProcessor pVideoProcessor, in Guid pExtensionGuid, uint DataSize, [Out] IntPtr pData);

		/// <summary>Specifies whether an input stream on the video processor contains interlaced or progressive frames.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="FrameFormat">A D3D11_VIDEO_FRAME_FORMAT value that specifies the interlacing.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamframeformat void
		// VideoProcessorSetStreamFrameFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, D3D11_VIDEO_FRAME_FORMAT
		// FrameFormat );
		[PreserveSig]
		new void VideoProcessorSetStreamFrameFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_FRAME_FORMAT FrameFormat);

		/// <summary>Sets the color space for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pColorSpace">A pointer to a D3D11_VIDEO_PROCESSOR_COLOR_SPACE structure that specifies the color space.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamcolorspace void
		// VideoProcessorSetStreamColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] const
		// D3D11_VIDEO_PROCESSOR_COLOR_SPACE *pColorSpace );
		[PreserveSig]
		new void VideoProcessorSetStreamColorSpace([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, in D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Sets the rate at which the video processor produces output frames for an input stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="OutputRate">The output rate, specified as a D3D11_VIDEO_PROCESSOR_OUTPUT_RATE value.</param>
		/// <param name="RepeatFrame">
		/// <para>Specifies how the driver performs frame-rate conversion, if required.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Repeat frames.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Interpolate frames.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pCustomRate">
		/// A pointer to a DXGI_RATIONAL structure. If <c>OutputRate</c> is <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM</c>, this parameter
		/// specifies the exact output rate. Otherwise, this parameter is ignored and can be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The standard output rates are normal frame-rate ( <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_NORMAL</c>) and half frame-rate (
		/// <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_HALF</c>). In addition, the driver might support custom rates for rate conversion or
		/// inverse telecine. To get the list of custom rates, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCustomRate.
		/// </para>
		/// <para>
		/// Depending on the output rate, the driver might need to convert the frame rate. If so, the value of <c>RepeatFrame</c> controls
		/// whether the driver creates interpolated frames or simply repeats input frames.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamoutputrate void
		// VideoProcessorSetStreamOutputRate( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate, [in] BOOL RepeatFrame, [in] const DXGI_RATIONAL *pCustomRate );
		[PreserveSig]
		new void VideoProcessorSetStreamOutputRate([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate,
			bool RepeatFrame, [Optional] in DXGI_RATIONAL pCustomRate);

		/// <summary>Sets the source rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether to apply the source rectangle.</param>
		/// <param name="pRect">
		/// A pointer to a RECT structure that specifies the source rectangle. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The source rectangle is the portion of the input surface that is blitted to the destination surface. The source rectangle is
		/// given in pixel coordinates, relative to the input surface.
		/// </para>
		/// <para>
		/// If this method is never called, or if the <c>Enable</c> parameter is <c>FALSE</c>, the video processor reads from the entire
		/// input surface.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamsourcerect void
		// VideoProcessorSetStreamSourceRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in]
		// const RECT *pRect );
		[PreserveSig]
		new void VideoProcessorSetStreamSourceRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, [Optional] in RECT pRect);

		/// <summary>Sets the destination rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether to apply the destination rectangle.</param>
		/// <param name="pRect">
		/// A pointer to a RECT structure that specifies the destination rectangle. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The destination rectangle is the portion of the output surface that receives the blit for this stream. The destination rectangle
		/// is given in pixel coordinates, relative to the output surface.
		/// </para>
		/// <para>
		/// The default destination rectangle is an empty rectangle (0, 0, 0, 0). If this method is never called, or if the <c>Enable</c>
		/// parameter is <c>FALSE</c>, no data is written from this stream.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamdestrect void
		// VideoProcessorSetStreamDestRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] const
		// RECT *pRect );
		[PreserveSig]
		new void VideoProcessorSetStreamDestRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, [Optional] in RECT pRect);

		/// <summary>Sets the planar alpha for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether alpha blending is enabled.</param>
		/// <param name="Alpha">
		/// The planar alpha value. The value can range from 0.0 (transparent) to 1.0 (opaque). If <c>Enable</c> is <c>FALSE</c>, this
		/// parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To use this feature, the driver must support stereo video, indicated by the D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALHPA_STREAM
		/// capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// <para>Alpha blending is disabled by default.</para>
		/// <para>For each pixel, the destination color value is computed as follows:</para>
		/// <para>where:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>= The color value of the destination pixel</description>
		/// </item>
		/// <item>
		/// <description>= The color value of the source pixel</description>
		/// </item>
		/// <item>
		/// <description>= The per-pixel source alpha</description>
		/// </item>
		/// <item>
		/// <description>= The planar alpha value</description>
		/// </item>
		/// <item>
		/// <description>= The palette-entry alpha value, or 1.0 (see Note)</description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c>  Palette-entry alpha values apply only to palettized color formats, and only when the device supports the
		/// <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE</c> capability. Otherwise, this factor equals 1.0.
		/// </para>
		/// <para></para>
		/// <para>The destination alpha value is computed according to the alpha fill mode. For more information, see ID3D11VideoContext::VideoProcessorSetOutputAlphaFillMode.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamalpha void
		// VideoProcessorSetStreamAlpha( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] FLOAT
		// Alpha );
		[PreserveSig]
		new void VideoProcessorSetStreamAlpha([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Alpha);

		/// <summary>Sets the color-palette entries for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Count">The number of elements in the <c>pEntries</c> array.</param>
		/// <param name="pEntries">
		/// A pointer to an array of palette entries. For RGB streams, the palette entries use the <c>DXGI_FORMAT_B8G8R8A8</c>
		/// representation. For YCbCr streams, the palette entries use the <c>DXGI_FORMAT_AYUV</c> representation. The caller allocates the array.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method applies only to input streams that have a palettized color format. Palettized formats with 4 bits per pixel (bpp)
		/// use the first 16 entries in the list. Formats with 8 bpp use the first 256 entries.
		/// </para>
		/// <para>
		/// If a pixel has a palette index greater than the number of entries, the device treats the pixel as white with opaque alpha. For
		/// full-range RGB, this value is (255, 255, 255, 255); for YCbCr the value is (255, 235, 128, 128).
		/// </para>
		/// <para>
		/// If the driver does not report the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE</c> capability flag, every palette entry
		/// must have an alpha value of 0xFF (opaque). To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreampalette void
		// VideoProcessorSetStreamPalette( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] UINT Count, [in] const
		// UINT *pEntries );
		[PreserveSig]
		new void VideoProcessorSetStreamPalette([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);

		/// <summary>Sets the pixel aspect ratio for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">
		/// Specifies whether the <c>pSourceAspectRatio</c> and <c>pDestinationAspectRatio</c> parameters contain valid values. Otherwise,
		/// the pixel aspect ratios are unspecified.
		/// </param>
		/// <param name="pSourceAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure that contains the pixel aspect ratio of the source rectangle. If <c>Enable</c> is
		/// <c>FALSE</c>, this parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pDestinationAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure that contains the pixel aspect ratio of the destination rectangle. If <c>Enable</c> is
		/// <c>FALSE</c>, this parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This function can only be called if the driver reports the D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_PIXEL_ASPECT_RATIO capability. If
		/// this capability is not set, this function will have no effect.
		/// </para>
		/// <para>Pixel aspect ratios of the form 0/n and n/0 are not valid.</para>
		/// <para>The default pixel aspect ratio is 1:1 (square pixels).</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreampixelaspectratio
		// void VideoProcessorSetStreamPixelAspectRatio( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL
		// Enable, [in] const DXGI_RATIONAL *pSourceAspectRatio, [in] const DXGI_RATIONAL *pDestinationAspectRatio );
		[PreserveSig]
		new void VideoProcessorSetStreamPixelAspectRatio([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable,
			[Optional] in DXGI_RATIONAL pSourceAspectRatio, [Optional] in DXGI_RATIONAL pDestinationAspectRatio);

		/// <summary>Sets the luma key for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether luma keying is enabled.</param>
		/// <param name="Lower">
		/// The lower bound for the luma key. The valid range is [0…1]. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <param name="Upper">
		/// The upper bound for the luma key. The valid range is [0…1]. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To use this feature, the driver must support luma keying, indicated by the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LUMA_KEY</c>
		/// capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps. In addition, if the
		/// input format is RGB, the device must support the <c>D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_LUMA_KEY</c> capability.
		/// </para>
		/// <para>
		/// The values of <c>Lower</c> and <c>Upper</c> give the lower and upper bounds of the luma key, using a nominal range of [0...1].
		/// Given a format with <c>n</c> bits per channel, these values are converted to luma values as follows:
		/// </para>
		/// <para>Any pixel whose luma value falls within the upper and lower bounds (inclusive) is treated as transparent.</para>
		/// <para>For example, if the pixel format uses 8-bit luma, the upper bound is calculated as follows:</para>
		/// <para>Note that the value is clamped to the range [0...1] before multiplying by 255.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamlumakey void
		// VideoProcessorSetStreamLumaKey( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] FLOAT
		// Lower, [in] FLOAT Upper );
		[PreserveSig]
		new void VideoProcessorSetStreamLumaKey([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Lower, float Upper);

		/// <summary>
		/// Enables or disables stereo 3D video for an input stream on the video processor. In addition, this method specifies the layout of
		/// the video frames in memory.
		/// </summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">
		/// Specifies whether stereo 3D is enabled for this stream. If the value is <c>FALSE</c>, the remaining parameters of this method
		/// are ignored.
		/// </param>
		/// <param name="Format">Specifies the layout of the two stereo views in memory, as a D3D11_VIDEO_PROCESSOR_STEREO_FORMAT value.</param>
		/// <param name="LeftViewFrame0">
		/// <para>If <c>TRUE</c>, frame 0 contains the left view. Otherwise, frame 0 contains the right view.</para>
		/// <para>This parameter is ignored for the following stereo formats:</para>
		/// <list type="bullet">
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO</c></item>
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c></item>
		/// </list>
		/// </param>
		/// <param name="BaseViewFrame0">
		/// <para>If <c>TRUE</c>, frame 0 contains the base view. Otherwise, frame 1 contains the base view.</para>
		/// <para>This parameter is ignored for the following stereo formats:</para>
		/// <list type="bullet">
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO</c></item>
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c></item>
		/// <item>
		/// When <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE</c> is used and the application wants to convert the stereo data to mono,
		/// it can either:
		/// </item>
		/// </list>
		/// </param>
		/// <param name="FlipMode">
		/// A flag from the D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE enumeration, specifying whether one of the views is flipped.
		/// </param>
		/// <param name="MonoOffset">
		/// <para>
		/// For <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c> format, this parameter specifies how to generate the left and right views:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// If <c>MonoOffset</c> is positive, the right view is shifted to the right by that many pixels, and the left view is shifted to
		/// the left by the same amount.
		/// </item>
		/// <item>
		/// If <c>MonoOffset</c> is negative, the right view is shifted to the left by that many pixels, and the left view is shifted to
		/// right by the same amount.
		/// </item>
		/// </list>
		/// <para>If Format is not D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET, this parameter must be zero.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamstereoformat void
		// VideoProcessorSetStreamStereoFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in]
		// D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format, [in] BOOL LeftViewFrame0, [in] BOOL BaseViewFrame0, [in]
		// D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, [in] int MonoOffset );
		[PreserveSig]
		new void VideoProcessorSetStreamStereoFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format,
			bool LeftViewFrame0, bool BaseViewFrame0, D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, int MonoOffset);

		/// <summary>Enables or disables automatic processing features on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">
		/// If <c>TRUE</c>, automatic processing features are enabled. If <c>FALSE</c>, the driver disables any extra video processing that
		/// it might be performing.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// By default, the driver might perform certain processing tasks automatically during the video processor blit. This method enables
		/// the application to disable these extra video processing features. For example, if you provide your own pixel shader for the
		/// video processor, you might want to disable the driver's automatic processing.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamautoprocessingmode
		// void VideoProcessorSetStreamAutoProcessingMode( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL
		// Enable );
		[PreserveSig]
		new void VideoProcessorSetStreamAutoProcessingMode([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable);

		/// <summary>Enables or disables an image filter for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Filter">
		/// <para>The filter, specified as a D3D11_VIDEO_PROCESSOR_FILTER value.</para>
		/// <para>To query which filters the driver supports, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.</para>
		/// </param>
		/// <param name="Enable">Specifies whether to enable the filter.</param>
		/// <param name="Level">
		/// <para>The filter level. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.</para>
		/// <para>To find the valid range of levels for a specified filter, call ID3D11VideoProcessorEnumerator::GetVideoProcessorFilterRange.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamfilter void
		// VideoProcessorSetStreamFilter( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// D3D11_VIDEO_PROCESSOR_FILTER Filter, [in] BOOL Enable, [in] int Level );
		[PreserveSig]
		new void VideoProcessorSetStreamFilter([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, bool Enable, int Level);

		/// <summary>Sets a driver-specific state on a video processing stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the operation. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">
		/// A pointer to a buffer that contains private state data. The method passes this buffer directly to the driver without validation.
		/// It is the responsibility of the driver to validate the data.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamextension
		// APP_DEPRECATED_HRESULT VideoProcessorSetStreamExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// const GUID *pExtensionGuid, [in] UINT DataSize, [in] void *pData );
		[PreserveSig]
		new int VideoProcessorSetStreamExtension([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, in Guid pExtensionGuid, uint DataSize, [In] IntPtr pData);

		/// <summary>Gets the format of an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pFrameFormat">
		/// Receives a D3D11_VIDEO_FRAME_FORMAT value that specifies whether the stream contains interlaced or progressive frames.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamframeformat void
		// VideoProcessorGetStreamFrameFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out]
		// D3D11_VIDEO_FRAME_FORMAT *pFrameFormat );
		[PreserveSig]
		new void VideoProcessorGetStreamFrameFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_FRAME_FORMAT pFrameFormat);

		/// <summary>Gets the color space for an input stream of the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pColorSpace">Receives a D3D11_VIDEO_PROCESSOR_COLOR_SPACE value that specifies the color space.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamcolorspace void
		// VideoProcessorGetStreamColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, UINT StreamIndex, [out]
		// D3D11_VIDEO_PROCESSOR_COLOR_SPACE *pColorSpace );
		[PreserveSig]
		new void VideoProcessorGetStreamColorSpace([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Gets the rate at which the video processor produces output frames for an input stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pOutputRate">Receives a D3D11_VIDEO_PROCESSOR_OUTPUT_RATE value that specifies the output rate.</param>
		/// <param name="pRepeatFrame">
		/// <para>Receives a Boolean value that specifies how the driver performs frame-rate conversion, if required.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Repeat frames.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Interpolate frames.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pCustomRate">
		/// A pointer to a DXGI_RATIONAL structure. If the output rate is <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM</c>, the method fills
		/// in this structure with the exact output rate. Otherwise, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamoutputrate void
		// VideoProcessorGetStreamOutputRate( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out]
		// D3D11_VIDEO_PROCESSOR_OUTPUT_RATE *pOutputRate, [out] BOOL *pRepeatFrame, [out] DXGI_RATIONAL *pCustomRate );
		[PreserveSig]
		new void VideoProcessorGetStreamOutputRate([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_OUTPUT_RATE pOutputRate,
			out bool pRepeatFrame, out DXGI_RATIONAL pCustomRate);

		/// <summary>Gets the source rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if the source rectangle is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pRect">A pointer to a RECT structure that receives the source rectangle.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamsourcerect void
		// VideoProcessorGetStreamSourceRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// RECT *pRect );
		[PreserveSig]
		new void VideoProcessorGetStreamSourceRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);

		/// <summary>Gets the destination rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if the destination rectangle is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pRect">A pointer to a RECT structure that receives the destination rectangle.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamdestrect void
		// VideoProcessorGetStreamDestRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// RECT *pRect );
		[PreserveSig]
		new void VideoProcessorGetStreamDestRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);

		/// <summary>Gets the planar alpha for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if planar alpha is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pAlpha">Receives the planar alpha value. The value can range from 0.0 (transparent) to 1.0 (opaque).</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamalpha void
		// VideoProcessorGetStreamAlpha( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// FLOAT *pAlpha );
		[PreserveSig]
		new void VideoProcessorGetStreamAlpha([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pAlpha);

		/// <summary>Gets the color-palette entries for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Count">The number of entries in the <c>pEntries</c> array.</param>
		/// <param name="pEntries">
		/// A pointer to a <c>UINT</c> array allocated by the caller. The method fills the array with the palette entries. For RGB streams,
		/// the palette entries use the <c>DXGI_FORMAT_B8G8R8A8</c> representation. For YCbCr streams, the palette entries use the
		/// <c>DXGI_FORMAT_AYUV</c> representation.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method applies only to input streams that have a palettized color format. Palettized formats with 4 bits per pixel (bpp)
		/// use 16 palette entries. Formats with 8 bpp use 256 entries.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreampalette void
		// VideoProcessorGetStreamPalette( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] UINT Count, [out] UINT
		// *pEntries );
		[PreserveSig]
		new void VideoProcessorGetStreamPalette([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);

		/// <summary>Gets the pixel aspect ratio for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">
		/// Receives the value <c>TRUE</c> if the pixel aspect ratio is specified. Otherwise, receives the value <c>FALSE</c>.
		/// </param>
		/// <param name="pSourceAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure. If * <c>pEnabled</c> is <c>TRUE</c>, this parameter receives the pixel aspect ratio of
		/// the source rectangle.
		/// </param>
		/// <param name="pDestinationAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure. If * <c>pEnabled</c> is <c>TRUE</c>, this parameter receives the pixel aspect ratio of
		/// the destination rectangle.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When the method returns, if <c>*pEnabled</c> is <c>TRUE</c>, the <c>pSourceAspectRatio</c> and <c>pDestinationAspectRatio</c>
		/// parameters contain the pixel aspect ratios. Otherwise, the default pixel aspect ratio is 1:1 (square pixels).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreampixelaspectratio
		// void VideoProcessorGetStreamPixelAspectRatio( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL
		// *pEnabled, [out] DXGI_RATIONAL *pSourceAspectRatio, [out] DXGI_RATIONAL *pDestinationAspectRatio );
		[PreserveSig]
		new void VideoProcessorGetStreamPixelAspectRatio([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled,
			out DXGI_RATIONAL pSourceAspectRatio, out DXGI_RATIONAL pDestinationAspectRatio);

		/// <summary>Gets the luma key for an input stream of the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if luma keying is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pLower">Receives the lower bound for the luma key. The valid range is [0…1].</param>
		/// <param name="pUpper">Receives the upper bound for the luma key. The valid range is [0…1].</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamlumakey void
		// VideoProcessorGetStreamLumaKey( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// FLOAT *pLower, [out] FLOAT *pUpper );
		[PreserveSig]
		new void VideoProcessorGetStreamLumaKey([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pLower, out float pUpper);

		/// <summary>Gets the stereo 3D format for an input stream on the video processor</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnable">
		/// Receives the value <c>TRUE</c> if stereo 3D is enabled for this stream, or <c>FALSE</c> otherwise. If the value is <c>FALSE</c>,
		/// ignore the remaining parameters.
		/// </param>
		/// <param name="pFormat">
		/// Receives a D3D11_VIDEO_PROCESSOR_STEREO_FORMAT value that specifies the layout of the two stereo views in memory.
		/// </param>
		/// <param name="pLeftViewFrame0">
		/// <para>Receives a Boolean value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Frame 0 contains the left view.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Frame 0 contains the right view.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pBaseViewFrame0">
		/// <para>Receives a Boolean value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Frame 0 contains the base view.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Frame 1 contains the base view.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pFlipMode">
		/// Receives a D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE value. This value specifies whether one of the views is flipped.
		/// </param>
		/// <param name="MonoOffset">
		/// Receives the pixel offset used for <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c> format. This parameter is ignored for
		/// other stereo formats.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamstereoformat void
		// VideoProcessorGetStreamStereoFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnable,
		// [out] D3D11_VIDEO_PROCESSOR_STEREO_FORMAT *pFormat, [out] BOOL *pLeftViewFrame0, [out] BOOL *pBaseViewFrame0, [out]
		// D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE *pFlipMode, [out] int *MonoOffset );
		[PreserveSig]
		new void VideoProcessorGetStreamStereoFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable,
			out D3D11_VIDEO_PROCESSOR_STEREO_FORMAT pFormat, out bool pLeftViewFrame0, out bool pBaseViewFrame0,
			out D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE pFlipMode, out int MonoOffset);

		/// <summary>Queries whether automatic processing features of the video processor are enabled.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if automatic processing features are enabled, or <c>FALSE</c> otherwise.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Automatic processing refers to additional image processing that drivers might have performed on the image data prior to the
		/// application receiving the data.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamautoprocessingmode
		// void VideoProcessorGetStreamAutoProcessingMode( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL
		// *pEnabled );
		[PreserveSig]
		new void VideoProcessorGetStreamAutoProcessingMode([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled);

		/// <summary>Gets the image filter settings for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Filter">The filter to query, specified as a D3D11_VIDEO_PROCESSOR_FILTER value.</param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if the image filter is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pLevel">Receives the filter level.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamfilter void
		// VideoProcessorGetStreamFilter( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// D3D11_VIDEO_PROCESSOR_FILTER Filter, [out] BOOL *pEnabled, [out] int *pLevel );
		[PreserveSig]
		new void VideoProcessorGetStreamFilter([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, out bool pEnabled, out int pLevel);

		/// <summary>Gets a driver-specific state for a video processing stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the state. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">A pointer to a buffer that receives the private state data.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamextension
		// APP_DEPRECATED_HRESULT VideoProcessorGetStreamExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// const GUID *pExtensionGuid, [in] UINT DataSize, [out] void *pData );
		[PreserveSig]
		new int VideoProcessorGetStreamExtension([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, in Guid pExtensionGuid, uint DataSize, [Out] IntPtr pData);

		/// <summary>Performs a video processing operation on one or more input samples, and writes the result to a Direct3D surface.</summary>
		/// <param name="pVideoProcessor">
		/// A pointer to the ID3D11VideoProcessor interface. To get this pointer, call the ID3D11VideoDevice::CreateVideoProcessor method.
		/// </param>
		/// <param name="pView">
		/// A pointer to the ID3D11VideoProcessorOutputView interface for the output surface. The output of the video processing operation
		/// will be written to this surface.
		/// </param>
		/// <param name="OutputFrame">The frame number of the output video frame, indexed from zero.</param>
		/// <param name="StreamCount">The number of input streams to process.</param>
		/// <param name="pStreams">
		/// A pointer to an array of D3D11_VIDEO_PROCESSOR_STREAM structures that contain information about the input streams. The caller
		/// allocates the array and fills in each structure. The number of elements in the array is given in the StreamCount parameter.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// The maximum value of <c>StreamCount</c> is given in the <c>MaxStreamStates</c> member of the D3D11_VIDEO_PROCESSOR_CAPS
		/// structure. The maximum number of streams that can be enabled at one time is given in the <c>MaxInputStreams</c> member of that structure.
		/// </para>
		/// <para>If the output stereo mode is <c>TRUE</c>:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The output view must contain a texture array of two elements.</description>
		/// </item>
		/// <item>
		/// <description>At least one stereo stream must be specified.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If multiple input streams are enabled, it is possible that one or more of the input streams may contain mono data.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Otherwise:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The output view must contain a single element.</description>
		/// </item>
		/// <item>
		/// <description>The stereo format cannot be D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO .</description>
		/// </item>
		/// </list>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorblt HRESULT
		// VideoProcessorBlt( [in] ID3D11VideoProcessor *pVideoProcessor, [in] ID3D11VideoProcessorOutputView *pView, [in] UINT OutputFrame,
		// [in] UINT StreamCount, [in] const D3D11_VIDEO_PROCESSOR_STREAM *pStreams );
		[PreserveSig]
		new HRESULT VideoProcessorBlt([In] ID3D11VideoProcessor pVideoProcessor, [In] ID3D11VideoProcessorOutputView pView, uint OutputFrame,
			int StreamCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D11_VIDEO_PROCESSOR_STREAM[] pStreams);

		/// <summary>Establishes the session key for a cryptographic session.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface of the cryptographic session.</param>
		/// <param name="DataSize">The size of the <c>pData</c> byte array, in bytes.</param>
		/// <param name="pData">A pointer to a byte array that contains the encrypted session key.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>The key exchange mechanism depends on the type of cryptographic session.</para>
		/// <para>
		/// For RSA Encryption Scheme - Optimal Asymmetric Encryption Padding (RSAES-OAEP), the software decoder generates the secret key,
		/// encrypts the secret key by using the public key with RSAES-OAEP, and places the cipher text in the <c>pData</c> parameter. The
		/// actual size of the buffer for RSAES-OAEP is 256 bytes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-negotiatecryptosessionkeyexchange HRESULT
		// NegotiateCryptoSessionKeyExchange( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT DataSize, [in, out] void *pData );
		[PreserveSig]
		new HRESULT NegotiateCryptoSessionKeyExchange([In] ID3D11CryptoSession pCryptoSession, uint DataSize, [In, Out] IntPtr pData);

		/// <summary>Reads encrypted data from a protected surface.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface of the cryptographic session.</param>
		/// <param name="pSrcSurface">A pointer to the ID3D11Texture2D interface of the protected surface.</param>
		/// <param name="pDstSurface">A pointer to the ID3D11Texture2D interface of the surface that receives the encrypted data.</param>
		/// <param name="IVSize">The size of the <c>pIV</c> buffer, in bytes.</param>
		/// <param name="pIV">
		/// <para>
		/// A pointer to a buffer that receives the initialization vector (IV). The caller allocates this buffer, but the driver generates
		/// the IV.
		/// </para>
		/// <para>
		/// For 128-bit AES-CTR encryption, <c>pIV</c> points to a D3D11_AES_CTR_IV structure. When the driver generates the first IV, it
		/// initializes the structure to a random number. For each subsequent IV, the driver simply increments the <c>IV</c> member of the
		/// structure, ensuring that the value always increases. The application can validate that the same IV is never used more than once
		/// with the same key pair.
		/// </para>
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Not all drivers support this method. To query the driver capabilities, call ID3D11VideoDevice::GetContentProtectionCaps and
		/// check for the <c>D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK</c> flag in the <c>Caps</c> member of the
		/// D3D11_VIDEO_CONTENT_PROTECTION_CAPS structure.
		/// </para>
		/// <para>
		/// Some drivers might require a separate key to decrypt the data that is read back. To check for this requirement, call
		/// GetContentProtectionCaps and check for the <c>D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK_KEY</c> flag. If this flag is
		/// present, call ID3D11VideoContext::GetEncryptionBltKey to get the decryption key.
		/// </para>
		/// <para>This method has the following limitations:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Reading back sub-rectangles is not supported.</description>
		/// </item>
		/// <item>
		/// <description>Reading back partially encrypted surfaces is not supported.</description>
		/// </item>
		/// <item>
		/// <description>The protected surface must be either an off-screen plain surface or a render target.</description>
		/// </item>
		/// <item>
		/// <description>The destination surface must be a D3D11_USAGE_STAGING resource.</description>
		/// </item>
		/// <item>
		/// <description>The protected surface cannot be multisampled.</description>
		/// </item>
		/// <item>
		/// <description>Stretching and colorspace conversion are not supported.</description>
		/// </item>
		/// </list>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-encryptionblt void EncryptionBlt( [in]
		// ID3D11CryptoSession *pCryptoSession, [in] ID3D11Texture2D *pSrcSurface, [in] ID3D11Texture2D *pDstSurface, [in] UINT IVSize, [in]
		// void *pIV );
		[PreserveSig]
		new void EncryptionBlt([In] ID3D11CryptoSession pCryptoSession, [In] ID3D11Texture2D pSrcSurface, [In] ID3D11Texture2D pDstSurface, uint IVSize, [In] IntPtr pIV);

		/// <summary>Writes encrypted data to a protected surface.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <param name="pSrcSurface">A pointer to the surface that contains the source data.</param>
		/// <param name="pDstSurface">A pointer to the protected surface where the encrypted data is written.</param>
		/// <param name="pEncryptedBlockInfo">
		/// <para>A pointer to a D3D11_ENCRYPTED_BLOCK_INFO structure, or <c>NULL</c>.</para>
		/// <para>
		/// If the driver supports partially encrypted buffers, <c>pEncryptedBlockInfo</c> indicates which portions of the buffer are
		/// encrypted. If the entire surface is encrypted, set this parameter to <c>NULL</c>.
		/// </para>
		/// <para>
		/// To check whether the driver supports partially encrypted buffers, call ID3D11VideoDevice::GetContentProtectionCaps and check for
		/// the <c>D3D11_CONTENT_PROTECTION_CAPS_PARTIAL_DECRYPTION</c> capabilities flag. If the driver does not support partially
		/// encrypted buffers, set this parameter to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="ContentKeySize">The size of the encrypted content key, in bytes.</param>
		/// <param name="pContentKey">
		/// <para>
		/// A pointer to a buffer that contains a content encryption key, or <c>NULL</c>. To query whether the driver supports the use of
		/// content keys, call ID3D11VideoDevice::GetContentProtectionCaps and check for the
		/// <c>D3D11_CONTENT_PROTECTION_CAPS_CONTENT_KEY</c> capabilities flag.
		/// </para>
		/// <para>
		/// If the driver supports content keys, use the content key to encrypt the surface. Encrypt the content key using the session key,
		/// and place the resulting cipher text in <c>pContentKey</c>. If the driver does not support content keys, use the session key to
		/// encrypt the surface and set <c>pContentKey</c> to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="IVSize">The size of the <c>pIV</c> buffer, in bytes.</param>
		/// <param name="pIV">
		/// <para>A pointer to a buffer that contains the initialization vector (IV).</para>
		/// <para>
		/// For 128-bit AES-CTR encryption, <c>pIV</c> points to a D3D11_AES_CTR_IV structure. The caller allocates the structure and
		/// generates the IV. When you generate the first IV, initialize the structure to a random number. For each subsequent IV, simply
		/// increment the <c>IV</c> member of the structure, ensuring that the value always increases. This procedure enables the driver to
		/// validate that the same IV is never used more than once with the same key pair.
		/// </para>
		/// <para>For other encryption types, a different structure might be used, or the encryption might not use an IV.</para>
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Not all hardware or drivers support this functionality for all cryptographic types. This function can only be called when the
		/// D3D11_CONTENT_PROTECTION_CAPS_DECRYPTION_BLT cap is reported.
		/// </para>
		/// <para>This method does not support writing to sub-rectangles of the surface.</para>
		/// <para>If the hardware and driver support a content key:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The data is encrypted by the caller using the content key.</description>
		/// </item>
		/// <item>
		/// <description>The content key is encrypted by the caller using the session key.</description>
		/// </item>
		/// <item>
		/// <description>The encrypted content key is passed to the driver.</description>
		/// </item>
		/// </list>
		/// <para>Otherwise, the data is encrypted by the caller using the session key and NULL is passed as the content key.</para>
		/// <para>
		/// If the driver and hardware support partially encrypted buffers, <c>pEncryptedBlockInfo</c> indicates which portions of the
		/// buffer are encrypted and which is not. If the entire buffer is encrypted, <c>pEncryptedBlockinfo</c> should be <c>NULL</c>.
		/// </para>
		/// <para>
		/// The D3D11_ENCRYPTED_BLOCK_INFO allows the application to indicate which bytes in the buffer are encrypted. This is specified in
		/// bytes, so the application must ensure that the encrypted blocks match the GPU’s crypto block alignment.
		/// </para>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decryptionblt void DecryptionBlt( [in]
		// ID3D11CryptoSession *pCryptoSession, [in] ID3D11Texture2D *pSrcSurface, [in] ID3D11Texture2D *pDstSurface, [in]
		// D3D11_ENCRYPTED_BLOCK_INFO *pEncryptedBlockInfo, [in] UINT ContentKeySize, [in] const void *pContentKey, [in] UINT IVSize, [in]
		// void *pIV );
		[PreserveSig]
		new void DecryptionBlt([In] ID3D11CryptoSession pCryptoSession, [In] ID3D11Texture2D pSrcSurface, [In] ID3D11Texture2D pDstSurface,
			in D3D11_ENCRYPTED_BLOCK_INFO pEncryptedBlockInfo, uint ContentKeySize, [In] IntPtr pContentKey, uint IVSize, [In] IntPtr pIV);

		/// <summary>Gets a random number that can be used to refresh the session key.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <param name="RandomNumberSize">
		/// The size of the <c>pRandomNumber</c> array, in bytes. The size should match the size of the session key.
		/// </param>
		/// <param name="pRandomNumber">A pointer to a byte array that receives a random number.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// To generate a new session key, perform a bitwise <c>XOR</c> between the previous session key and the random number. The new
		/// session key does not take affect until the application calls ID3D11VideoContext::FinishSessionKeyRefresh.
		/// </para>
		/// <para>
		/// To query whether the driver supports this method, call ID3D11VideoDevice::GetContentProtectionCaps and check for the
		/// <c>D3D11_CONTENT_PROTECTION_CAPS_FRESHEN_SESSION_KEY</c> capabilities flag.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-startsessionkeyrefresh void
		// StartSessionKeyRefresh( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT RandomNumberSize, [out] void *pRandomNumber );
		[PreserveSig]
		new void StartSessionKeyRefresh([In] ID3D11CryptoSession pCryptoSession, uint RandomNumberSize, [Out] IntPtr pRandomNumber);

		/// <summary>Switches to a new session key.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>This function can only be called when the D3D11_CONTENT_PROTECTION_CAPS_FRESHEN_SESSION_KEY cap is reported.</para>
		/// <para>
		/// Before calling this method, call ID3D11VideoContext::StartSessionKeyRefresh. The <c>StartSessionKeyRefresh</c> method gets a
		/// random number from the driver, which is used to create a new session key. The new session key does not become active until the
		/// application calls <c>FinishSessionKeyRefresh</c>. After the application calls <c>FinishSessionKeyRefresh</c>, all protected
		/// surfaces are encrypted using the new session key.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-finishsessionkeyrefresh void
		// FinishSessionKeyRefresh( [in] ID3D11CryptoSession *pCryptoSession );
		[PreserveSig]
		new void FinishSessionKeyRefresh([In] ID3D11CryptoSession pCryptoSession);

		/// <summary>Gets the cryptographic key to decrypt the data returned by the ID3D11VideoContext::EncryptionBlt method.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <param name="KeySize">The size of the <c>pReadbackKey</c> array, in bytes. The size should match the size of the session key.</param>
		/// <param name="pReadbackKey">A pointer to a byte array that receives the key. The key is encrypted using the session key.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// This method applies only when the driver requires a separate content key for the EncryptionBlt method. For more information, see
		/// the Remarks for <c>EncryptionBlt</c>.
		/// </para>
		/// <para>Each time this method is called, the driver generates a new key.</para>
		/// <para>The <c>KeySize</c> should match the size of the session key.</para>
		/// <para>The read back key is encrypted by the driver/hardware using the session key.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-getencryptionbltkey HRESULT
		// GetEncryptionBltKey( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT KeySize, [out] void *pReadbackKey );
		[PreserveSig]
		new HRESULT GetEncryptionBltKey([In] ID3D11CryptoSession pCryptoSession, uint KeySize, [Out] IntPtr pReadbackKey);

		/// <summary>Establishes a session key for an authenticated channel.</summary>
		/// <param name="pChannel">
		/// A pointer to the ID3D11AuthenticatedChannel interface. This method will fail if the channel type is
		/// D3D11_AUTHENTICATED_CHANNEL_D3D11, because the Direct3D11 channel does not support authentication.
		/// </param>
		/// <param name="DataSize">The size of the data in the <c>pData</c> array, in bytes.</param>
		/// <param name="pData">
		/// A pointer to a byte array that contains the encrypted session key. The buffer must contain 256 bytes of data, encrypted using
		/// RSA Encryption Scheme - Optimal Asymmetric Encryption Padding (RSAES-OAEP).
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// This method will fail if the channel type is D3D11_AUTHENTICATED_CHANNEL_D3D11, because the Direct3D11 channel does not support authentication.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-negotiateauthenticatedchannelkeyexchange
		// HRESULT NegotiateAuthenticatedChannelKeyExchange( [in] ID3D11AuthenticatedChannel *pChannel, [in] UINT DataSize, [in, out] void
		// *pData );
		[PreserveSig]
		new HRESULT NegotiateAuthenticatedChannelKeyExchange([In] ID3D11AuthenticatedChannel pChannel, uint DataSize, [In, Out] IntPtr pData);

		/// <summary>Sends a query to an authenticated channel.</summary>
		/// <param name="pChannel">A pointer to the ID3D11AuthenticatedChannel interface.</param>
		/// <param name="InputSize">The size of the <c>pInput</c> array, in bytes.</param>
		/// <param name="pInput">
		/// A pointer to a byte array that contains input data for the query. This array always starts with a
		/// D3D11_AUTHENTICATED_QUERY_INPUT structure. The <c>QueryType</c> member of the structure specifies the query and defines the
		/// meaning of the rest of the array.
		/// </param>
		/// <param name="OutputSize">The size of the <c>pOutput</c> array, in bytes.</param>
		/// <param name="pOutput">
		/// A pointer to a byte array that receives the result of the query. This array always starts with a
		/// D3D11_AUTHENTICATED_QUERY_OUTPUT structure. The meaning of the rest of the array depends on the query.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-queryauthenticatedchannel HRESULT
		// QueryAuthenticatedChannel( [in] ID3D11AuthenticatedChannel *pChannel, [in] UINT InputSize, [in] const void *pInput, [in] UINT
		// OutputSize, [out] void *pOutput );
		[PreserveSig]
		new HRESULT QueryAuthenticatedChannel([In] ID3D11AuthenticatedChannel pChannel, uint InputSize, [In] IntPtr pInput, uint OutputSize, [Out] IntPtr pOutput);

		/// <summary>Sends a configuration command to an authenticated channel.</summary>
		/// <param name="pChannel">A pointer to the ID3D11AuthenticatedChannel interface.</param>
		/// <param name="InputSize">The size of the <c>pInput</c> array, in bytes.</param>
		/// <param name="pInput">
		/// A pointer to a byte array that contains input data for the command. This buffer always starts with a
		/// D3D11_AUTHENTICATED_CONFIGURE_INPUT structure. The <c>ConfigureType</c> member of the structure specifies the command and
		/// defines the meaning of the rest of the buffer.
		/// </param>
		/// <param name="pOutput">A pointer to a D3D11_AUTHENTICATED_CONFIGURE_OUTPUT structure that receives the response to the command.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-configureauthenticatedchannel HRESULT
		// ConfigureAuthenticatedChannel( [in] ID3D11AuthenticatedChannel *pChannel, [in] UINT InputSize, [in] const void *pInput, [out]
		// D3D11_AUTHENTICATED_CONFIGURE_OUTPUT *pOutput );
		[PreserveSig]
		new HRESULT ConfigureAuthenticatedChannel([In] ID3D11AuthenticatedChannel pChannel, uint InputSize, [In] IntPtr pInput, out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT pOutput);

		/// <summary>Sets the stream rotation for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies if the stream is to be rotated in a clockwise orientation.</param>
		/// <param name="Rotation">Specifies the rotation of the stream.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This is an optional state and the application should only use it if D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ROTATION is reported in D3D11_VIDEO_PROCESSOR_CAPS.FeatureCaps.
		/// </para>
		/// <para>
		/// The stream source rectangle will be specified in the pre-rotation coordinates (typically landscape) and the stream destination
		/// rectangle will be specified in the post-rotation coordinates (typically portrait). The application must update the stream
		/// destination rectangle correctly when using a rotation value other than 0° and 180°.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamrotation void
		// VideoProcessorSetStreamRotation( ID3D11VideoProcessor *pVideoProcessor, UINT StreamIndex, BOOL Enable,
		// D3D11_VIDEO_PROCESSOR_ROTATION Rotation );
		[PreserveSig]
		new void VideoProcessorSetStreamRotation([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_ROTATION Rotation);

		/// <summary>Gets the stream rotation for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnable">Specifies if the stream is rotated.</param>
		/// <param name="pRotation">Specifies the rotation of the stream in a clockwise orientation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamrotation void
		// VideoProcessorGetStreamRotation( ID3D11VideoProcessor *pVideoProcessor, UINT StreamIndex, BOOL *pEnable,
		// D3D11_VIDEO_PROCESSOR_ROTATION *pRotation );
		[PreserveSig]
		new void VideoProcessorGetStreamRotation([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_ROTATION pRotation);

		/// <summary>Submits one or more buffers for decoding.</summary>
		/// <param name="pDecoder">
		/// <para>Type: <c>ID3D11VideoDecoder*</c></para>
		/// <para>A pointer to the ID3D11VideoDecoder interface. To get this pointer, call the ID3D11VideoDevice::CreateVideoDecoder method.</para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of buffers submitted for decoding.</para>
		/// </param>
		/// <param name="pBufferDesc">
		/// <para>Type: <c>const D3D11_VIDEO_DECODER_BUFFER_DESC1*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_VIDEO_DECODER_BUFFER_DESC1 structures. The <c>NumBuffers</c> parameter specifies the number of
		/// elements in the array. Each element in the array describes a compressed buffer for decoding.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function does not honor any D3D11 predicate that may have been set.</para>
		/// <para>D3D11_QUERY_DATA_PIPELINE_STATISTICS will not include this function for any feature level.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-submitdecoderbuffers1 HRESULT
		// SubmitDecoderBuffers1( [in] ID3D11VideoDecoder *pDecoder, [in] UINT NumBuffers, [in] const D3D11_VIDEO_DECODER_BUFFER_DESC1
		// *pBufferDesc );
		[PreserveSig]
		new HRESULT SubmitDecoderBuffers1([In] ID3D11VideoDecoder pDecoder, int NumBuffers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC1[] pBufferDesc);

		/// <summary>Allows the driver to return IHV specific information used when initializing the new hardware key.</summary>
		/// <param name="pCryptoSession">
		/// <para>Type: <c>ID3D11CryptoSession*</c></para>
		/// <para>A pointer to the ID3D11CryptoSession interface. To get this pointer, call ID3D11VideoDevice1::CreateCryptoSession.</para>
		/// </param>
		/// <param name="PrivateInputSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the memory referenced by the <c>pPrivateInputData</c> parameter.</para>
		/// </param>
		/// <param name="pPrivatInputData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// The private input data. The contents of this parameter is defined by the implementation of the secure execution environment. It
		/// may contain data about the license or about the stream properties.
		/// </para>
		/// </param>
		/// <param name="pPrivateOutputData">
		/// <para>Type: <c>UINT64*</c></para>
		/// <para>
		/// A pointer to the private output data. The return data is defined by the implementation of the secure execution environment. It
		/// may contain graphics-specific data to be associated with the underlying hardware key.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to complete the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-getdatafornewhardwarekey HRESULT
		// GetDataForNewHardwareKey( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT PrivateInputSize, [in] const void
		// *pPrivatInputData, [out] UINT64 *pPrivateOutputData );
		[PreserveSig]
		new HRESULT GetDataForNewHardwareKey([In] ID3D11CryptoSession pCryptoSession, uint PrivateInputSize, [In] IntPtr pPrivatInputData, out ulong pPrivateOutputData);

		/// <summary>Checks the status of a crypto session.</summary>
		/// <param name="pCryptoSession">
		/// <para>Type: <c>ID3D11CryptoSession*</c></para>
		/// <para>Specifies a ID3D11CryptoSession for which status is checked.</para>
		/// </param>
		/// <param name="pStatus">
		/// <para>Type: <c>D3D11_CRYPTO_SESSION_STATUS*</c></para>
		/// <para>A D3D11_CRYPTO_SESSION_STATUS that is populated with the crypto session status upon completion.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to complete the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-checkcryptosessionstatus HRESULT
		// CheckCryptoSessionStatus( [in] ID3D11CryptoSession *pCryptoSession, [out] D3D11_CRYPTO_SESSION_STATUS *pStatus );
		[PreserveSig]
		new HRESULT CheckCryptoSessionStatus([In] ID3D11CryptoSession pCryptoSession, out D3D11_CRYPTO_SESSION_STATUS pStatus);

		/// <summary>Indicates that decoder downsampling will be used and that the driver should allocate the appropriate reference frames.</summary>
		/// <param name="pDecoder">
		/// <para>Type: <c>ID3D11VideoDecoder*</c></para>
		/// <para>A pointer to the ID3D11VideoDecoder interface.</para>
		/// </param>
		/// <param name="InputColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE</c></para>
		/// <para>The color space information of the reference frame data.</para>
		/// </param>
		/// <param name="pOutputDesc">
		/// <para>Type: <c>const D3D11_VIDEO_SAMPLE_DESC*</c></para>
		/// <para>
		/// The resolution, format, and colorspace of the output/display frames. This is the destination resolution and format of the
		/// downsample operation.
		/// </para>
		/// </param>
		/// <param name="ReferenceFrameCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of reference frames to be used in the operation.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to complete the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function can only be called once for a specific ID3D11VideoDecoder interface. This method must be called prior to the first
		/// call to DecoderBeginFrame. To update the downsampling parameters, use DecoderUpdateDownsampling.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-decoderenabledownsampling HRESULT
		// DecoderEnableDownsampling( [in] ID3D11VideoDecoder *pDecoder, [in] DXGI_COLOR_SPACE_TYPE InputColorSpace, [in] const
		// D3D11_VIDEO_SAMPLE_DESC *pOutputDesc, [in] UINT ReferenceFrameCount );
		[PreserveSig]
		new HRESULT DecoderEnableDownsampling([In] ID3D11VideoDecoder pDecoder, DXGI_COLOR_SPACE_TYPE InputColorSpace, in D3D11_VIDEO_SAMPLE_DESC pOutputDesc, uint ReferenceFrameCount);

		/// <summary>Updates the decoder downsampling parameters.</summary>
		/// <param name="pDecoder">
		/// <para>Type: <c>ID3D11VideoDecoder*</c></para>
		/// <para>A pointer to the ID3D11VideoDecoder interface.</para>
		/// </param>
		/// <param name="pOutputDesc">
		/// <para>Type: <c>const D3D11_VIDEO_SAMPLE_DESC*</c></para>
		/// <para>
		/// The resolution, format, and colorspace of the output/display frames. This is the destination resolution and format of the
		/// downsample operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to complete the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method can only be called after decode downsampling is enabled by calling DecoderEnableDownsampling. This method is only
		/// supported if the D3D11_VIDEO_DECODER_CAPS_DOWNSAMPLE_DYNAMIC capability is reported.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-decoderupdatedownsampling HRESULT
		// DecoderUpdateDownsampling( [in] ID3D11VideoDecoder *pDecoder, [in] const D3D11_VIDEO_SAMPLE_DESC *pOutputDesc );
		[PreserveSig]
		new HRESULT DecoderUpdateDownsampling([In] ID3D11VideoDecoder pDecoder, in D3D11_VIDEO_SAMPLE_DESC pOutputDesc);

		/// <summary>Sets the color space information for the video processor output surface.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="ColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE</c></para>
		/// <para>A DXGI_COLOR_SPACE_TYPE value that specifies the colorspace for the video processor output surface.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorsetoutputcolorspace1
		// void VideoProcessorSetOutputColorSpace1( [in] ID3D11VideoProcessor *pVideoProcessor, [in] DXGI_COLOR_SPACE_TYPE ColorSpace );
		[PreserveSig]
		new void VideoProcessorSetOutputColorSpace1([In] ID3D11VideoProcessor pVideoProcessor, DXGI_COLOR_SPACE_TYPE ColorSpace);

		/// <summary>
		/// Sets a value indicating whether the output surface from a call to ID3D11VideoContext::VideoProcessorBlt will be read by Direct3D shaders.
		/// </summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="ShaderUsage">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// True if the surface rendered using ID3D11VideoContext::VideoProcessorBlt will be read by Direct3D shaders; otherwise, false.
		/// This may be set to false when multi-plane overlay hardware is supported.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorsetoutputshaderusage
		// void VideoProcessorSetOutputShaderUsage( [in] ID3D11VideoProcessor *pVideoProcessor, [in] BOOL ShaderUsage );
		[PreserveSig]
		new void VideoProcessorSetOutputShaderUsage([In] ID3D11VideoProcessor pVideoProcessor, bool ShaderUsage);

		/// <summary>Gets the color space information for the video processor output surface.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="pColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE*</c></para>
		/// <para>A pointer to a DXGI_COLOR_SPACE_TYPE value that indicates the colorspace for the video processor output surface.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorgetoutputcolorspace1
		// void VideoProcessorGetOutputColorSpace1( [in] ID3D11VideoProcessor *pVideoProcessor, [out] DXGI_COLOR_SPACE_TYPE *pColorSpace );
		[PreserveSig]
		new void VideoProcessorGetOutputColorSpace1([In] ID3D11VideoProcessor pVideoProcessor, out DXGI_COLOR_SPACE_TYPE pColorSpace);

		/// <summary>
		/// Gets a value indicating whether the output surface from a call to ID3D11VideoContext::VideoProcessorBlt can be read by Direct3D shaders.
		/// </summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="pShaderUsage">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a boolean value indicating if the output surface can be read by Direct3D shaders. True if the surface rendered
		/// using ID3D11VideoContext::VideoProcessorBlt can be read by Direct3D shaders; otherwise, false.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorgetoutputshaderusage
		// void VideoProcessorGetOutputShaderUsage( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pShaderUsage );
		[PreserveSig]
		new void VideoProcessorGetOutputShaderUsage([In] ID3D11VideoProcessor pVideoProcessor, out bool pShaderUsage);

		/// <summary>Sets the color space information for the video processor input stream.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="StreamIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An index identifying the input stream.</para>
		/// </param>
		/// <param name="ColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE</c></para>
		/// <para>A DXGI_COLOR_SPACE_TYPE value that specifies the colorspace for the video processor input stream.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorsetstreamcolorspace1
		// void VideoProcessorSetStreamColorSpace1( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// DXGI_COLOR_SPACE_TYPE ColorSpace );
		[PreserveSig]
		new void VideoProcessorSetStreamColorSpace1([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, DXGI_COLOR_SPACE_TYPE ColorSpace);

		/// <summary>Specifies whether the video processor input stream should be flipped vertically or horizontally.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="StreamIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An index identifying the input stream.</para>
		/// </param>
		/// <param name="Enable">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if mirroring should be enabled; otherwise, false.</para>
		/// </param>
		/// <param name="FlipHorizontal">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the stream should be flipped horizontally; otherwise, false.</para>
		/// </param>
		/// <param name="FlipVertical">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the stream should be flipped vertically; otherwise, false.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>When used in combination, transformations on the processor input stream should be applied in the following order:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Rotation</description>
		/// </item>
		/// <item>
		/// <description>Mirroring</description>
		/// </item>
		/// <item>
		/// <description>Source clipping</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorsetstreammirror void
		// VideoProcessorSetStreamMirror( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] BOOL
		// FlipHorizontal, [in] BOOL FlipVertical );
		[PreserveSig]
		new void VideoProcessorSetStreamMirror([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, bool FlipHorizontal, bool FlipVertical);

		/// <summary>Gets the color space information for the video processor input stream.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="StreamIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An index identifying the input stream.</para>
		/// </param>
		/// <param name="pColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE*</c></para>
		/// <para>A pointer to a DXGI_COLOR_SPACE_TYPE value that specifies the colorspace for the video processor input stream.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorgetstreamcolorspace1
		// void VideoProcessorGetStreamColorSpace1( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out]
		// DXGI_COLOR_SPACE_TYPE *pColorSpace );
		[PreserveSig]
		new void VideoProcessorGetStreamColorSpace1([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out DXGI_COLOR_SPACE_TYPE pColorSpace);

		/// <summary>Gets values that indicate whether the video processor input stream is being flipped vertically or horizontally.</summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="StreamIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An index identifying the input stream.</para>
		/// </param>
		/// <param name="pEnable">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A pointer to a boolean value indicating whether mirroring is enabled. True if mirroring is enabled; otherwise, false.</para>
		/// </param>
		/// <param name="pFlipHorizontal">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a boolean value indicating whether the stream is being flipped horizontally. True if the stream is being flipped
		/// horizontally; otherwise, false.
		/// </para>
		/// </param>
		/// <param name="pFlipVertical">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a boolean value indicating whether the stream is being flipped vertically. True if the stream is being flipped
		/// vertically; otherwise, false.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorgetstreammirror void
		// VideoProcessorGetStreamMirror( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnable, [out] BOOL
		// *pFlipHorizontal, [out] BOOL *pFlipVertical );
		[PreserveSig]
		new void VideoProcessorGetStreamMirror([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out bool pFlipHorizontal, out bool pFlipVertical);

		/// <summary>
		/// Returns driver hints that indicate which of the video processor operations are best performed using multi-plane overlay hardware
		/// rather than ID3D11VideoContext::VideoProcessorBlt method.
		/// </summary>
		/// <param name="pVideoProcessor">
		/// <para>Type: <c>ID3D11VideoProcessor*</c></para>
		/// <para>A pointer to the ID3D11VideoProcessor interface.</para>
		/// </param>
		/// <param name="OutputWidth">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of the output stream.</para>
		/// </param>
		/// <param name="OutputHeight">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height of the output stream.</para>
		/// </param>
		/// <param name="OutputFormat">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The format of the output stream.</para>
		/// </param>
		/// <param name="StreamCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of input streams to process.</para>
		/// </param>
		/// <param name="pStreams">
		/// <para>Type: <c>const D3D11_VIDEO_PROCESSOR_STREAM_BEHAVIOR_HINT*</c></para>
		/// <para>
		/// An array of structures that specifies the format of each input stream and whether each stream should be used when computing
		/// behavior hints.
		/// </para>
		/// </param>
		/// <param name="pBehaviorHints">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer to a bitwise OR combination of D3D11_VIDEO_PROCESSOR_BEHAVIOR_HINTS values indicating which video processor operations
		/// would best be performed using multi-plane overlay hardware rather than the ID3D11VideoContext::VideoProcessorBlt method.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to complete the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method computes the behavior hints using the current state of the video processor as set by the "SetOutput" and "SetStream"
		/// methods of ID3D11VideoContext and ID3D11VideoContext1. You must set the proper state before calling this method to ensure that
		/// the returned hints contain useful data.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videocontext1-videoprocessorgetbehaviorhints HRESULT
		// VideoProcessorGetBehaviorHints( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT OutputWidth, [in] UINT OutputHeight, [in]
		// DXGI_FORMAT OutputFormat, [in] UINT StreamCount, [in] const D3D11_VIDEO_PROCESSOR_STREAM_BEHAVIOR_HINT *pStreams, [out] UINT
		// *pBehaviorHints );
		[PreserveSig]
		new HRESULT VideoProcessorGetBehaviorHints([In] ID3D11VideoProcessor pVideoProcessor, uint OutputWidth, uint OutputHeight, DXGI_FORMAT OutputFormat,
			int StreamCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D11_VIDEO_PROCESSOR_STREAM_BEHAVIOR_HINT[] pStreams, out uint pBehaviorHints);

		/// <summary>Sets the HDR metadata describing the display on which the content will be presented.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface.</param>
		/// <param name="Type">The type of HDR metadata supplied.</param>
		/// <param name="Size">
		/// <para>The size of the HDR metadata supplied in <c>pHDRMetaData</c>.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_NONE</c>, the size should be 0.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_HDR10</c>, the size is .</para>
		/// </param>
		/// <param name="pHDRMetaData">
		/// <para>Pointer to the metadata information.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_NONE</c>, this should be NULL.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_HDR10</c>, this is a pointer to a DXGI_HDR_METADATA_HDR10 structure.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>When processing an HDR stream, the driver may use this metadata optimize the video for the output display.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11videocontext2-videoprocessorsetoutputhdrmetadata
		// void VideoProcessorSetOutputHDRMetaData( [in] ID3D11VideoProcessor *pVideoProcessor, [in] DXGI_HDR_METADATA_TYPE Type, [in] UINT
		// Size, [in] const void *pHDRMetaData );
		[PreserveSig]
		new void VideoProcessorSetOutputHDRMetaData([In] ID3D11VideoProcessor pVideoProcessor, DXGI_HDR_METADATA_TYPE Type, uint Size, [In] IntPtr pHDRMetaData);

		/// <summary>Gets the HDR metadata describing the display on which the content will be presented.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface.</param>
		/// <param name="pType">The type of HDR metadata supplied.</param>
		/// <param name="Size">
		/// <para>The size of the memory referenced by <c>pHDRMetaData</c>.</para>
		/// <para>If <c>pHDRMetaData</c> is NULL, <c>Size</c> should be 0.</para>
		/// </param>
		/// <param name="pMetaData">
		/// <para>Pointer to a buffer that receives the HDR metadata.</para>
		/// <para>This parameter can be NULL.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This can be called multiple times, the first time to get the <c>Type</c> (in which case <c>Size</c> can be 0 and
		/// <c>pHDRMetaData</c> can be NULL) and then again to with non-NULL values to retrieve the actual metadata.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11videocontext2-videoprocessorgetoutputhdrmetadata
		// void VideoProcessorGetOutputHDRMetaData( [in] ID3D11VideoProcessor *pVideoProcessor, [out] DXGI_HDR_METADATA_TYPE *pType, [in]
		// UINT Size, [out] void *pMetaData );
		[PreserveSig]
		new void VideoProcessorGetOutputHDRMetaData([In] ID3D11VideoProcessor pVideoProcessor, out DXGI_HDR_METADATA_TYPE pType, uint Size, [Out] IntPtr pMetaData);

		/// <summary>Sets the HDR metadata associated with the video stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface.</param>
		/// <param name="StreamIndex">Identifies the input stream.</param>
		/// <param name="Type">The type of HDR metadata supplied.</param>
		/// <param name="Size">
		/// <para>The size of the HDR metadata supplied in <c>pHDRMetaData</c>.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_NONE</c>, the size should be 0.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_HDR10</c>, the size is .</para>
		/// </param>
		/// <param name="pHDRMetaData">
		/// <para>Pointer to the metadata information.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_NONE</c>, this should be NULL.</para>
		/// <para>For <c>DXGI_HDR_METADATA_TYPE_HDR10</c>, this is a pointer to a DXGI_HDR_METADATA_HDR10 structure.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When processing an HDR stream, the driver may use this information to tone map the video content to optimize it for the output display.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11videocontext2-videoprocessorsetstreamhdrmetadata
		// void VideoProcessorSetStreamHDRMetaData( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// DXGI_HDR_METADATA_TYPE Type, [in] UINT Size, [in] const void *pHDRMetaData );
		[PreserveSig]
		new void VideoProcessorSetStreamHDRMetaData([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, DXGI_HDR_METADATA_TYPE Type, uint Size, [In] IntPtr pHDRMetaData);

		/// <summary>Gets the HDR metadata associated with the video stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface.</param>
		/// <param name="StreamIndex">Identifies the input stream.</param>
		/// <param name="pType">The type of the HDR metadata currently associated with the stream.</param>
		/// <param name="Size">
		/// <para>The size of the memory referenced by <c>pHDRMetaData</c>.</para>
		/// <para>If <c>pHDRMetaData</c> is NULL, <c>Size</c> should be 0.</para>
		/// </param>
		/// <param name="pMetaData">
		/// <para>Pointer to a buffer that receives the HDR metadata.</para>
		/// <para>This parameter can be NULL.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This can be called multiple times, the first time to get the <c>Type</c> (in which case <c>Size</c> can be 0 and
		/// <c>pHDRMetaData</c> can be NULL) and then again to with non-NULL values to retrieve the actual metadata.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11videocontext2-videoprocessorgetstreamhdrmetadata
		// void VideoProcessorGetStreamHDRMetaData( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out]
		// DXGI_HDR_METADATA_TYPE *pType, [in] UINT Size, [out] void *pMetaData );
		[PreserveSig]
		new void VideoProcessorGetStreamHDRMetaData([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out DXGI_HDR_METADATA_TYPE pType, uint Size, [Out] IntPtr pMetaData);

		/// <summary>Starts a decoding operation to decode a video frame.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder</param>
		/// <param name="pView">
		/// A pointer to a ID3D11VideoDecoderOutputView interface. This interface describes the resource that will receive the decoded
		/// frame. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoderOutputView.
		/// </param>
		/// <param name="ContentKeySize">
		/// The size of the content key that is specified in pContentKey. If pContentKey is NULL, set ContentKeySize to zero.
		/// </param>
		/// <param name="pContentKey">
		/// An optional pointer to a content key that was used to encrypt the frame data. If no content key was used, set this parameter to
		/// NULL. If the caller provides a content key, the caller must use the session key to encrypt the content key.
		/// </param>
		/// <param name="NumComponentHistograms">
		/// The number of components to record a histograms for. Use D3D11_FEATURE_VIDEO_DECODE_HISTOGRAM to check for support. Use zero
		/// when not recording histograms or when the feature is not supported. Specifying fewer components than are in the format implies
		/// that those components do not have histogram recording enabled. The maximum number of components is defined as <c>D3D11_4_VIDEO_DECODER_MAX_HISTOGRAM_COMPONENTS</c>.
		/// </param>
		/// <param name="pHistogramOffsets">
		/// An array of starting buffer offset locations within the ppHistogramBuffers parallel array. Use
		/// D3D11_VIDEO_DECODE_HISTOGRAM_COMPONENT to index the array. If a component is not requested, specify an offset of zero. The
		/// offsets must be 256-byte aligned.
		/// </param>
		/// <param name="ppHistogramBuffers">
		/// An array of target buffers for hardware to write the components histogram. Use D3D11_VIDEO_DECODE_HISTOGRAM_COMPONENT to index
		/// the array. Set this parameter to <c>nullptr</c> when the component histogram is disabled or unsupported
		/// </param>
		/// <returns>Returns <c>S_OK</c> if successful.</returns>
		/// <remarks>
		/// <para>The following D3D11_RESOURCE_MISC flags are allowed when allocating resources for video decode histograms.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_SHARED</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_BUFFER_STRUCTURED</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_SHARED_NTHANDLE</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE</description>
		/// </item>
		/// <item>
		/// <description>D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE_DRIVER</description>
		/// </item>
		/// </list>
		/// <para>All other D3D11_RESOURCE_MISC flags are disallowed.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11videocontext3-decoderbeginframe1 HRESULT
		// DecoderBeginFrame1( ID3D11VideoDecoder *pDecoder, ID3D11VideoDecoderOutputView *pView, UINT ContentKeySize, const void
		// *pContentKey, UINT NumComponentHistograms, const UINT *pHistogramOffsets, ID3D11Buffer * const *ppHistogramBuffers );
		[PreserveSig]
		HRESULT DecoderBeginFrame1([In] ID3D11VideoDecoder pDecoder, [In] ID3D11VideoDecoderOutputView pView, uint ContentKeySize, [In, Optional] IntPtr pContentKey,
			int NumComponentHistograms, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] pHistogramOffsets,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 4)] ID3D11Buffer[]? ppHistogramBuffers);

		/// <summary>Submits one or more buffers for decoding.</summary>
		/// <param name="pDecoder">
		/// <para>Type: <c>ID3D11VideoDecoder*</c></para>
		/// <para>A pointer to the ID3D11VideoDecoder interface. To get this pointer, call the ID3D11VideoDevice::CreateVideoDecoder method.</para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of buffers submitted for decoding.</para>
		/// </param>
		/// <param name="pBufferDesc">
		/// <para>Type: <c>const D3D11_VIDEO_DECODER_BUFFER_DESC2*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_VIDEO_DECODER_BUFFER_DESC2 structures. The <c>NumBuffers</c> parameter specifies the number of
		/// elements in the array. Each element in the array describes a compressed buffer for decoding.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function does not honor any D3D11 predicate that may have been set.</para>
		/// <para>D3D11_QUERY_DATA_PIPELINE_STATISTICS will not include this function for any feature level.</para>
		/// </remarks>
		[PreserveSig]
		HRESULT SubmitDecoderBuffers2([In] ID3D11VideoDecoder pDecoder, int NumBuffers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC2[] pBufferDesc);
	}

	/// <summary>
	/// Provides the video decoding and video processing capabilities of a Microsoft Direct3D 11 device. Adds the CheckFeatureSupport method
	/// for querying for decoding capabilities.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11videodevice2
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11VideoDevice2")]
	[ComImport, Guid("59c0cb01-35f0-4a70-8f67-87905c906a53"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoDevice2 : ID3D11VideoDevice1, ID3D11VideoDevice
	{
		/// <summary>Creates a video decoder device for Microsoft Direct3D 11.</summary>
		/// <param name="pVideoDesc">
		/// A pointer to a D3D11_VIDEO_DECODER_DESC structure that describes the video stream and the decoder profile.
		/// </param>
		/// <param name="pConfig">A pointer to a D3D11_VIDEO_DECODER_CONFIG structure that specifies the decoder configuration.</param>
		/// <param name="ppDecoder">Receives a pointer to the ID3D11VideoDecoder interface. The caller must release the interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>This method allocates the necessary decoder buffers.</para>
		/// <para>The ID3D11DeviceContext::ClearState method does not affect the internal state of the video decoder.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideodecoder HRESULT
		// CreateVideoDecoder( [in] const D3D11_VIDEO_DECODER_DESC *pVideoDesc, [in] const D3D11_VIDEO_DECODER_CONFIG *pConfig, [out]
		// ID3D11VideoDecoder **ppDecoder );
		[PreserveSig]
		new HRESULT CreateVideoDecoder(in D3D11_VIDEO_DECODER_DESC pVideoDesc, in D3D11_VIDEO_DECODER_CONFIG pConfig, out ID3D11VideoDecoder ppDecoder);

		/// <summary>Creates a video processor device for Microsoft Direct3D 11.</summary>
		/// <param name="pEnum">A pointer to the ID3D11VideoProcessorEnumerator interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessorEnumerator.</param>
		/// <param name="RateConversionIndex">
		/// Specifies the frame-rate conversion capabilities for the video processor. The value is a zero-based index that corresponds to
		/// the <c>TypeIndex</c> parameter of the ID3D11VideoProcessorEnumerator::GetVideoProcessorRateConversionCaps method.
		/// </param>
		/// <param name="ppVideoProcessor">Receives a pointer to the ID3D11VideoProcessor interface. The caller must release the interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>The ID3D11DeviceContext::ClearState method does not affect the internal state of the video processor.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideoprocessor HRESULT
		// CreateVideoProcessor( [in] ID3D11VideoProcessorEnumerator *pEnum, [in] UINT RateConversionIndex, [out] ID3D11VideoProcessor
		// **ppVideoProcessor );
		[PreserveSig]
		new HRESULT CreateVideoProcessor([In] ID3D11VideoProcessorEnumerator pEnum, uint RateConversionIndex, out ID3D11VideoProcessor ppVideoProcessor);

		/// <summary>
		/// Creates a channel to communicate with the Microsoft Direct3D device or the graphics driver. The channel can be used to send
		/// commands and queries for content protection.
		/// </summary>
		/// <param name="ChannelType">Specifies the type of channel, as a member of the D3D11_AUTHENTICATED_CHANNEL_TYPE enumeration.</param>
		/// <param name="ppAuthenticatedChannel">
		/// Receives a pointer to the ID3D11AuthenticatedChannel interface. The caller must release the interface.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// If the <c>ChannelType</c> parameter is <c>D3D11_AUTHENTICATED_CHANNEL_D3D11</c>, the method creates a channel with the Direct3D
		/// device. This type of channel does not support authentication.
		/// </para>
		/// <para>
		/// If <c>ChannelType</c> is <c>D3D11_AUTHENTICATED_CHANNEL_DRIVER_SOFTWARE</c> or
		/// <c>D3D11_AUTHENTICATED_CHANNEL_DRIVER_HARDWARE</c>, the method creates an authenticated channel with the graphics driver.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createauthenticatedchannel HRESULT
		// CreateAuthenticatedChannel( [in] D3D11_AUTHENTICATED_CHANNEL_TYPE ChannelType, [out] ID3D11AuthenticatedChannel
		// **ppAuthenticatedChannel );
		[PreserveSig]
		new HRESULT CreateAuthenticatedChannel(D3D11_AUTHENTICATED_CHANNEL_TYPE ChannelType, out ID3D11AuthenticatedChannel ppAuthenticatedChannel);

		/// <summary>Creates a cryptographic session to encrypt video content that is sent to the graphics driver.</summary>
		/// <param name="pCryptoType">
		/// <para>A pointer to a GUID that specifies the type of encryption to use. The following GUIDs are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>D3D11_CRYPTO_TYPE_AES128_CTR</c></description>
		/// <description>128-bit Advanced Encryption Standard CTR mode (AES-CTR) block cipher.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pDecoderProfile">
		/// A pointer to a GUID that specifies the decoding profile. For a list of possible values, see
		/// ID3D11VideoDevice::GetVideoDecoderProfile. If decoding will not be used, set this parameter to <c>NULL</c>.
		/// </param>
		/// <param name="pKeyExchangeType">
		/// <para>A pointer to a GUID that specifies the type of key exchange.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>D3D11_KEY_EXCHANGE_RSAES_OAEP</c></description>
		/// <description>
		/// The caller will create the session key, encrypt it with RSA Encryption Scheme - Optimal Asymmetric Encryption Padding
		/// (RSAES-OAEP) by using the driver's public key, and pass the session key to the driver.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppCryptoSession">Receives a pointer to the ID3D11CryptoSession interface. The caller must release the interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>The ID3D11DeviceContext::ClearState method does not affect the internal state of the cryptographic session.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createcryptosession HRESULT
		// CreateCryptoSession( [in] const GUID *pCryptoType, [in] const GUID *pDecoderProfile, [in] const GUID *pKeyExchangeType, [out]
		// ID3D11CryptoSession **ppCryptoSession );
		[PreserveSig]
		new HRESULT CreateCryptoSession(in Guid pCryptoType, in Guid pDecoderProfile, in Guid pKeyExchangeType, out ID3D11CryptoSession ppCryptoSession);

		/// <summary>Creates a resource view for a video decoder, describing the output sample for the decoding operation.</summary>
		/// <param name="pResource">
		/// A pointer to the ID3D11Resource interface of the decoder surface. The resource must be created with the
		/// <c>D3D11_BIND_DECODER</c> flag. See D3D11_BIND_FLAG.
		/// </param>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC structure that describes the view.</param>
		/// <param name="ppVDOVView">
		/// Receives a pointer to the ID3D11VideoDecoderOutputView interface. The caller must release the interface. If this parameter is
		/// <c>NULL</c>, the method checks whether the view is supported, but does not create the view.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>Set the <c>ppVDOVView</c> parameter to <c>NULL</c> to test whether a view is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideodecoderoutputview HRESULT
		// CreateVideoDecoderOutputView( [in] ID3D11Resource *pResource, [in] const D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC *pDesc, [out]
		// ID3D11VideoDecoderOutputView **ppVDOVView );
		[PreserveSig]
		new HRESULT CreateVideoDecoderOutputView([In] ID3D11Resource pResource, in D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC pDesc, out ID3D11VideoDecoderOutputView ppVDOVView);

		/// <summary>Creates a resource view for a video processor, describing the input sample for the video processing operation.</summary>
		/// <param name="pResource">A pointer to the ID3D11Resource interface of the input surface.</param>
		/// <param name="pEnum">
		/// A pointer to the ID3D11VideoProcessorEnumerator interface that specifies the video processor. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessorEnumerator.
		/// </param>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC structure that describes the view.</param>
		/// <param name="ppVPIView">
		/// Receives a pointer to the ID3D11VideoProcessorInputView interface. The caller must release the resource. If this parameter is
		/// <c>NULL</c>, the method checks whether the view is supported, but does not create the view.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>Set the <c>ppVPIView</c> parameter to <c>NULL</c> to test whether a view is supported.</para>
		/// <para>
		/// The surface format is given in the <c>FourCC</c> member of the D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC structure. The method fails
		/// if the video processor does not support this format as an input sample. An app must specify 0 when using 9_1, 9_2, or 9_3
		/// feature levels.
		/// </para>
		/// <para>Resources used for video processor input views must use the following bind flag combinations:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Any combination of bind flags that includes D3D11_BIND_DECODER, <c>D3D11_BIND_VIDEO_ENCODER</c>,
		/// <c>D3D11_BIND_RENDER_TARGET</c>, and <c>D3D11_BIND_UNORDERED_ACCESS_VIEW</c> can be used as for video processor input views
		/// (regardless of what other bind flags may be set).
		/// </description>
		/// </item>
		/// <item>
		/// <description>Bind flags = 0 is also allowed for a video processor input view.</description>
		/// </item>
		/// <item>
		/// <description>Other restrictions will apply such as:</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideoprocessorinputview HRESULT
		// CreateVideoProcessorInputView( [in] ID3D11Resource *pResource, [in] ID3D11VideoProcessorEnumerator *pEnum, [in] const
		// D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC *pDesc, [out] ID3D11VideoProcessorInputView **ppVPIView );
		[PreserveSig]
		new HRESULT CreateVideoProcessorInputView([In] ID3D11Resource pResource, [In] ID3D11VideoProcessorEnumerator pEnum, in D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC pDesc, out ID3D11VideoProcessorInputView ppVPIView);

		/// <summary>Creates a resource view for a video processor, describing the output sample for the video processing operation.</summary>
		/// <param name="pResource">
		/// A pointer to the ID3D11Resource interface of the output surface. The resource must be created with the
		/// <c>D3D11_BIND_RENDER_TARGET</c> flag. See D3D11_BIND_FLAG.
		/// </param>
		/// <param name="pEnum">
		/// A pointer to the ID3D11VideoProcessorEnumerator interface that specifies the video processor. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessorEnumerator.
		/// </param>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC structure that describes the view.</param>
		/// <param name="ppVPOView">
		/// Receives a pointer to the ID3D11VideoProcessorOutputView interface. The caller must release the resource. If this parameter is
		/// <c>NULL</c>, the method checks whether the view is supported, but does not create the view.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>Set the <c>ppVPOView</c> parameter to <c>NULL</c> to test whether a view is supported.</para>
		/// <para>Resources used for video processor output views must use the following D3D11_BIND_FLAG combinations:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// D3D11_BIND_RENDER_TARGET indicates that it can be used for a video processor output view. The following bind flags are allowed
		/// to be set with <c>D3D11_BIND_RENDER_TARGET</c>:
		/// </description>
		/// </item>
		/// <item>
		/// <description>Other restrictions will apply such as:</description>
		/// </item>
		/// <item>
		/// <description>
		/// Some YUV formats can be supported as a video processor output view, but might not be supported as a 3D render target. D3D11 will
		/// allow the D3D11_BIND_RENDER_TARGET flag for these formats, but CreateRenderTargetView will not be allowed for these formats.
		/// </description>
		/// </item>
		/// </list>
		/// <para>If stereo output is enabled, the output view must have 2 array elements. Otherwise, it must only have a single array element.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideoprocessoroutputview HRESULT
		// CreateVideoProcessorOutputView( [in] ID3D11Resource *pResource, [in] ID3D11VideoProcessorEnumerator *pEnum, [in] const
		// D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC *pDesc, [out] ID3D11VideoProcessorOutputView **ppVPOView );
		[PreserveSig]
		new HRESULT CreateVideoProcessorOutputView([In] ID3D11Resource pResource, [In] ID3D11VideoProcessorEnumerator pEnum, in D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC pDesc, out ID3D11VideoProcessorOutputView ppVPOView);

		/// <summary>Enumerates the video processor capabilities of the driver.</summary>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_PROCESSOR_CONTENT_DESC structure that describes the video content.</param>
		/// <param name="ppEnum">Receives a pointer to the ID3D11VideoProcessorEnumerator interface. The caller must release the interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// To create the video processor device, pass the ID3D11VideoProcessorEnumerator pointer to the
		/// ID3D11VideoDevice::CreateVideoProcessor method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideoprocessorenumerator HRESULT
		// CreateVideoProcessorEnumerator( [in] const D3D11_VIDEO_PROCESSOR_CONTENT_DESC *pDesc, [out] ID3D11VideoProcessorEnumerator
		// **ppEnum );
		[PreserveSig]
		new HRESULT CreateVideoProcessorEnumerator(in D3D11_VIDEO_PROCESSOR_CONTENT_DESC pDesc, out ID3D11VideoProcessorEnumerator ppEnum);

		/// <summary>Gets the number of profiles that are supported by the driver.</summary>
		/// <returns>Returns the number of profiles.</returns>
		/// <remarks>To enumerate the profiles, call ID3D11VideoDevice::GetVideoDecoderProfile.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-getvideodecoderprofilecount UINT GetVideoDecoderProfileCount();
		[PreserveSig]
		new uint GetVideoDecoderProfileCount();

		/// <summary>Gets a profile that is supported by the driver.</summary>
		/// <param name="Index">The zero-based index of the profile. To get the number of profiles that the driver supports, call ID3D11VideoDevice::GetVideoDecoderProfileCount.</param>
		/// <param name="pDecoderProfile">Receives a GUID that identifies the profile.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-getvideodecoderprofile HRESULT
		// GetVideoDecoderProfile( [in] UINT Index, [out] GUID *pDecoderProfile );
		[PreserveSig]
		new HRESULT GetVideoDecoderProfile(uint Index, out Guid pDecoderProfile);

		/// <summary>Given aprofile, checks whether the driver supports a specified output format.</summary>
		/// <param name="pDecoderProfile">
		/// A pointer to a GUID that identifies the profile. To get the list of supported profiles, call ID3D11VideoDevice::GetVideoDecoderProfile.
		/// </param>
		/// <param name="Format">
		/// A DXGI_FORMAT value that specifies the output format. Typical values include <c>DXGI_FORMAT_NV12</c> and <c>DXGI_FORMAT_420_OPAQUE</c>.
		/// </param>
		/// <param name="pSupported">Receives the value <c>TRUE</c> if the format is supported, or <c>FALSE</c> otherwise.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// If the driver does not support the profile given in <c>pDecoderProfile</c>, the method returns <c>E_INVALIDARG</c>. If the
		/// driver supports the profile, but the DXGI format is not compatible with the profile, the method succeeds but returns the value
		/// <c>FALSE</c> in <c>pSupported</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-checkvideodecoderformat HRESULT
		// CheckVideoDecoderFormat( [in] const GUID *pDecoderProfile, [in] DXGI_FORMAT Format, [out] BOOL *pSupported );
		[PreserveSig]
		new HRESULT CheckVideoDecoderFormat(in Guid pDecoderProfile, DXGI_FORMAT Format, out bool pSupported);

		/// <summary>Gets the number of decoder configurations that the driver supports for a specified video description.</summary>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_DECODER_DESC structure that describes the video stream.</param>
		/// <param name="pCount">Receives the number of decoder configurations.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>To enumerate the decoder configurations, call ID3D11VideoDevice::GetVideoDecoderConfig.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-getvideodecoderconfigcount HRESULT
		// GetVideoDecoderConfigCount( [in] const D3D11_VIDEO_DECODER_DESC *pDesc, [out] UINT *pCount );
		[PreserveSig]
		new HRESULT GetVideoDecoderConfigCount(in D3D11_VIDEO_DECODER_DESC pDesc, out uint pCount);

		/// <summary>Gets a decoder configuration that is supported by the driver.</summary>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_DECODER_DESC structure that describes the video stream.</param>
		/// <param name="Index">
		/// The zero-based index of the decoder configuration. To get the number of configurations that the driver supports, call ID3D11VideoDevice::GetVideoDecoderConfigCount.
		/// </param>
		/// <param name="pConfig">
		/// A pointer to a D3D11_VIDEO_DECODER_CONFIG structure. The method fills in the structure with the decoder configuration.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-getvideodecoderconfig HRESULT
		// GetVideoDecoderConfig( [in] const D3D11_VIDEO_DECODER_DESC *pDesc, [in] UINT Index, [out] D3D11_VIDEO_DECODER_CONFIG *pConfig );
		[PreserveSig]
		new HRESULT GetVideoDecoderConfig(in D3D11_VIDEO_DECODER_DESC pDesc, uint Index, out D3D11_VIDEO_DECODER_CONFIG pConfig);

		/// <summary>Queries the driver for its content protection capabilities.</summary>
		/// <param name="pCryptoType">
		/// <para>A pointer to a GUID that specifies the type of encryption to be used. The following GUIDs are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>D3D11_CRYPTO_TYPE_AES128_CTR</c></description>
		/// <description>128-bit Advanced Encryption Standard CTR mode (AES-CTR) block cipher.</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>If no encryption will be used, set this parameter to <c>NULL</c>.</para>
		/// </param>
		/// <param name="pDecoderProfile">
		/// <para>
		/// A pointer to a GUID that specifies the decoding profile. To get profiles that the driver supports, call
		/// ID3D11VideoDevice::GetVideoDecoderProfile. If decoding will not be used, set this parameter to <c>NULL</c>.
		/// </para>
		/// <para>The driver might disallow some combinations of encryption type and profile.</para>
		/// </param>
		/// <param name="pCaps">
		/// A pointer to a D3D11_VIDEO_CONTENT_PROTECTION_CAPS structure. The method fills in this structure with the driver's content
		/// protection capabilities.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-getcontentprotectioncaps HRESULT
		// GetContentProtectionCaps( [in] const GUID *pCryptoType, [in] const GUID *pDecoderProfile, [out]
		// D3D11_VIDEO_CONTENT_PROTECTION_CAPS *pCaps );
		[PreserveSig]
		new HRESULT GetContentProtectionCaps(in Guid pCryptoType, in Guid pDecoderProfile, out D3D11_VIDEO_CONTENT_PROTECTION_CAPS pCaps);

		/// <summary>Gets a cryptographic key-exchange mechanism that is supported by the driver.</summary>
		/// <param name="pCryptoType">
		/// <para>A pointer to a GUID that specifies the type of encryption to be used. The following GUIDs are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>D3D11_CRYPTO_TYPE_AES128_CTR</c></description>
		/// <description>128-bit Advanced Encryption Standard CTR mode (AES-CTR) block cipher.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pDecoderProfile">
		/// A pointer to a GUID that specifies the decoding profile. To get profiles that the driver supports, call
		/// ID3D11VideoDevice::GetVideoDecoderProfile. If decoding will not be used, set this parameter to <c>NULL</c>.
		/// </param>
		/// <param name="Index">
		/// The zero-based index of the key-exchange type. The driver reports the number of types in the <c>KeyExchangeTypeCount</c> member
		/// of the D3D11_VIDEO_CONTENT_PROTECTION_CAPS structure.
		/// </param>
		/// <param name="pKeyExchangeType">Receives a GUID that identifies the type of key exchange.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-checkcryptokeyexchange HRESULT
		// CheckCryptoKeyExchange( [in] const GUID *pCryptoType, [in] const GUID *pDecoderProfile, [in] UINT Index, [out] GUID
		// *pKeyExchangeType );
		[PreserveSig]
		new HRESULT CheckCryptoKeyExchange(in Guid pCryptoType, in Guid pDecoderProfile, uint Index, out Guid pKeyExchangeType);

		/// <summary>Sets private data on the video device and associates that data with a GUID.</summary>
		/// <param name="guid">The GUID associated with the data.</param>
		/// <param name="DataSize">The size of the data, in bytes.</param>
		/// <param name="pData">A pointer to the data.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] UINT DataSize, [in] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In] IntPtr pData);

		/// <summary>Sets a private IUnknown pointer on the video device and associates that pointer with a GUID.</summary>
		/// <param name="guid">The GUID associated with the pointer.</param>
		/// <param name="pData">A pointer to the IUnknown interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, MarshalAs(UnmanagedType.Interface)] object pData);

		/// <summary>Retrieves optional sizes for private driver data.</summary>
		/// <param name="pCryptoType">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Indicates the crypto type for which the private input and output size is queried.</para>
		/// </param>
		/// <param name="pDecoderProfile">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Indicates the decoder profile for which the private input and output size is queried.</para>
		/// </param>
		/// <param name="pKeyExchangeType">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Indicates the key exchange type for which the private input and output size is queried.</para>
		/// </param>
		/// <param name="pPrivateInputSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Returns the size of private data that the driver needs for input commands.</para>
		/// </param>
		/// <param name="pPrivateOutputSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Returns the size of private data that the driver needs for output commands.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When <c>pKeyExchangeType</c> is <c>D3D11_KEY_EXCHANGE_HW_PROTECTION</c>, the following behavior is expected in the
		/// ID3D11VideoContext::NegotiateCryptoSessionKeyExchange method:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The <c>DataSize</c> parameter is set to the size of the D3D11_KEY_EXCHANGE_HW_PROTECTION_DATA structure.</description>
		/// </item>
		/// <item>
		/// <description><c>pData</c> points to a D3D11_KEY_EXCHANGE_HW_PROTECTION_DATA structure.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videodevice1-getcryptosessionprivatedatasize HRESULT
		// GetCryptoSessionPrivateDataSize( [in] const GUID *pCryptoType, [in, optional] const GUID *pDecoderProfile, [in] const GUID
		// *pKeyExchangeType, [out] UINT *pPrivateInputSize, [out] UINT *pPrivateOutputSize );
		[PreserveSig]
		new HRESULT GetCryptoSessionPrivateDataSize(in Guid pCryptoType, [In, Optional] GuidPtr pDecoderProfile, in Guid pKeyExchangeType, out uint pPrivateInputSize, out uint pPrivateOutputSize);

		/// <summary>Retrieves capabilities and limitations of the video decoder.</summary>
		/// <param name="pDecoderProfile">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>The decode profile for which the capabilities are queried.</para>
		/// </param>
		/// <param name="SampleWidth">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The video width for which the capabilities are queried.</para>
		/// </param>
		/// <param name="SampleHeight">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The video height for which the capabilities are queried.</para>
		/// </param>
		/// <param name="pFrameRate">
		/// <para>Type: <c>const DXGI_RATIONAL*</c></para>
		/// <para>
		/// The frame rate of the video content. This information is used by the driver to determine whether the video can be decoded in real-time.
		/// </para>
		/// </param>
		/// <param name="BitRate">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The bit rate of the video stream. A value of zero indicates that the bit rate can be ignored.</para>
		/// </param>
		/// <param name="pCryptoType">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>The type of cryptography used to encrypt the video stream. A value of NULL indicates that the video stream is not encrypted.</para>
		/// </param>
		/// <param name="pDecoderCaps">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer to a bitwise OR combination of D3D11_VIDEO_DECODER_CAPS values specifying the decoder capabilities.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videodevice1-getvideodecodercaps HRESULT
		// GetVideoDecoderCaps( [in] const GUID *pDecoderProfile, [in] UINT SampleWidth, [in] UINT SampleHeight, [in] const DXGI_RATIONAL
		// *pFrameRate, [in] UINT BitRate, [in] const GUID *pCryptoType, [out] UINT *pDecoderCaps );
		[PreserveSig]
		new HRESULT GetVideoDecoderCaps(in Guid pDecoderProfile, uint SampleWidth, uint SampleHeight, in DXGI_RATIONAL pFrameRate, uint BitRate, [In, Optional] GuidPtr pCryptoType, out D3D11_VIDEO_DECODER_CAPS pDecoderCaps);

		/// <summary>
		/// Indicates whether the video decoder supports downsampling with the specified input format, and whether real-time downsampling is supported.
		/// </summary>
		/// <param name="pInputDesc">
		/// <para>Type: <c>const D3D11_VIDEO_DECODER_DESC*</c></para>
		/// <para>
		/// An object describing the decoding profile, the resolution, and format of the input stream. This is the resolution and format to
		/// be downsampled.
		/// </para>
		/// </param>
		/// <param name="InputColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE</c></para>
		/// <para>A DXGI_COLOR_SPACE_TYPE value that specifies the colorspace of the reference frame data.</para>
		/// </param>
		/// <param name="pInputConfig">
		/// <para>Type: <c>const D3D11_VIDEO_DECODER_CONFIG*</c></para>
		/// <para>The configuration data associated with the decode profile.</para>
		/// </param>
		/// <param name="pFrameRate">
		/// <para>Type: <c>const DXGI_RATIONAL*</c></para>
		/// <para>The frame rate of the video content. This is used by the driver to determine whether the video can be decoded in real-time.</para>
		/// </param>
		/// <param name="pOutputDesc">
		/// <para>Type: <c>const D3D11_VIDEO_SAMPLE_DESC*</c></para>
		/// <para>
		/// An object describing the resolution, format, and colorspace of the output frames. This is the destination resolution and format
		/// of the downsample operation.
		/// </para>
		/// </param>
		/// <param name="pSupported">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// Pointer to a boolean value set by the driver that indicates if downsampling is supported with the specified input data. True if
		/// the driver supports the requested downsampling; otherwise, false.
		/// </para>
		/// </param>
		/// <param name="pRealTimeHint">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// Pointer to a boolean value set by the driver that indicates if real-time decoding is supported with the specified input data.
		/// True if the driver supports the requested real-time decoding; otherwise, false. Note that the returned value is based on the
		/// current configuration of the video decoder and does not guarantee that real-time decoding will be supported for future
		/// downsampling operations.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// You should call GetVideoDecoderCaps to determine whether decoder downsampling is supported before checking support for a
		/// specific configuration.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videodevice1-checkvideodecoderdownsampling HRESULT
		// CheckVideoDecoderDownsampling( [in] const D3D11_VIDEO_DECODER_DESC *pInputDesc, [in] DXGI_COLOR_SPACE_TYPE InputColorSpace, [in]
		// const D3D11_VIDEO_DECODER_CONFIG *pInputConfig, [in] const DXGI_RATIONAL *pFrameRate, [in] const D3D11_VIDEO_SAMPLE_DESC
		// *pOutputDesc, [out] BOOL *pSupported, [out] BOOL *pRealTimeHint );
		[PreserveSig]
		new HRESULT CheckVideoDecoderDownsampling(in D3D11_VIDEO_DECODER_DESC pInputDesc, DXGI_COLOR_SPACE_TYPE InputColorSpace, in D3D11_VIDEO_DECODER_CONFIG pInputConfig,
			in DXGI_RATIONAL pFrameRate, in D3D11_VIDEO_SAMPLE_DESC pOutputDesc, out bool pSupported, out bool pRealTimeHint);

		/// <summary>Allows the driver to recommend optimal output downsample parameters from the input parameters.</summary>
		/// <param name="pInputDesc">
		/// <para>Type: <c>const D3D11_VIDEO_DECODER_DESC*</c></para>
		/// <para>
		/// A D3D11_VIDEO_DECODER_DESC object describing the decoding profile, the resolution, and format of the input stream. This is the
		/// resolution and format to be downsampled.
		/// </para>
		/// </param>
		/// <param name="InputColorSpace">
		/// <para>Type: <c>DXGI_COLOR_SPACE_TYPE</c></para>
		/// <para>A DXGI_COLOR_SPACE_TYPE value that specifies the colorspace of the reference frame data.</para>
		/// </param>
		/// <param name="pInputConfig">
		/// <para>Type: <c>const D3D11_VIDEO_DECODER_CONFIG*</c></para>
		/// <para>The configuration data associated with the decode profile.</para>
		/// </param>
		/// <param name="pFrameRate">
		/// <para>Type: <c>const DXGI_RATIONAL*</c></para>
		/// <para>The frame rate of the video content. This is used by the driver to determine whether the video can be decoded in real-time.</para>
		/// </param>
		/// <param name="pRecommendedOutputDesc">
		/// <para>Type: <c>D3D11_VIDEO_SAMPLE_DESC*</c></para>
		/// <para>
		/// Pointer to a D3D11_VIDEO_SAMPLE_DESC structure that the driver populates with the recommended output buffer parameters for a
		/// downsample operation. The driver will attempt to recommend parameters that can support real-time decoding. If it is unable to do
		/// so, the driver will recommend values that are as close to the real-time solution as possible.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>S_OK</description>
		/// <description>The operation completed successfully.</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed or this function was called using an invalid calling pattern.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// You should call GetVideoDecoderCaps to determine whether decoder downsampling is supported before checking support for a
		/// specific configuration.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nf-d3d11_1-id3d11videodevice1-recommendvideodecoderdownsampleparameters
		// HRESULT RecommendVideoDecoderDownsampleParameters( [in] const D3D11_VIDEO_DECODER_DESC *pInputDesc, [in] DXGI_COLOR_SPACE_TYPE
		// InputColorSpace, [in] const D3D11_VIDEO_DECODER_CONFIG *pInputConfig, [in] const DXGI_RATIONAL *pFrameRate, [out]
		// D3D11_VIDEO_SAMPLE_DESC *pRecommendedOutputDesc );
		[PreserveSig]
		new HRESULT RecommendVideoDecoderDownsampleParameters(in D3D11_VIDEO_DECODER_DESC pInputDesc, DXGI_COLOR_SPACE_TYPE InputColorSpace, in D3D11_VIDEO_DECODER_CONFIG pInputConfig, in DXGI_RATIONAL pFrameRate, out D3D11_VIDEO_SAMPLE_DESC pRecommendedOutputDesc);

		/// <summary>Gets information about the features that are supported by the current video driver.</summary>
		/// <param name="Feature">A member of the D3D11_FEATURE_VIDEO enumeration that specifies the feature to query for support.</param>
		/// <param name="pFeatureSupportData">
		/// A structure that contains data that describes the configuration details of the feature for which support is requested and, upon
		/// the completion of the call, is populated with details about the level of support available. For information on the structure
		/// that is associated with each type of feature support request, see the field descriptions for D3D11_FEATURE_VIDEO.
		/// </param>
		/// <param name="FeatureSupportDataSize">The size of the structure passed to the pFeatureSupportData parameter.</param>
		/// <returns>
		/// Returns <c>S_OK</c> if successful; otherwise, returns <c>E_INVALIDARG</c> if an unsupported data type is passed to the
		/// pFeatureSupportData parameter or a size mismatch is detected for the FeatureSupportDataSize parameter.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11videodevice2-checkfeaturesupport HRESULT
		// CheckFeatureSupport( D3D11_FEATURE_VIDEO Feature, void *pFeatureSupportData, UINT FeatureSupportDataSize );
		[PreserveSig]
		HRESULT CheckFeatureSupport(D3D11_FEATURE_VIDEO Feature, [Out] IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary/>
		[PreserveSig]
		HRESULT NegotiateCryptoSessionKeyExchangeMT([In] ID3D11CryptoSession pCryptoSession, D3D11_CRYPTO_SESSION_KEY_EXCHANGE_FLAGS flags, uint DataSize, [In, Out] IntPtr pData);
	}

	/// <summary>Describes Direct3D 11.4 feature options in the current graphics driver.</summary>
	/// <remarks>
	/// <para>Use this structure with the D3D11_FEATURE_D3D11_OPTIONS4 member of D3D11_FEATURE.</para>
	/// <para>Refer to the section on NV12 in Direct3D 11.4 Features.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/ns-d3d11_4-d3d11_feature_data_d3d11_options4 typedef struct
	// D3D11_FEATURE_DATA_D3D11_OPTIONS4 { BOOL ExtendedNV12SharedTextureSupported; } D3D11_FEATURE_DATA_D3D11_OPTIONS4;
	[PInvokeData("d3d11_4.h", MSDNShortId = "NS:d3d11_4.D3D11_FEATURE_DATA_D3D11_OPTIONS4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D11_OPTIONS4
	{
		/// <summary>Specifies a BOOL that determines if NV12 textures can be shared across processes and D3D devices.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ExtendedNV12SharedTextureSupported;
	}

	/// <summary>
	/// Provides data for calls to ID3D11VideoDevice2::CheckFeatureSupport when the feature specified is
	/// D3D11_FEATURE_VIDEO_DECODER_HISTOGRAM. Retrieves the histogram capabilities for the specified decoder configuration.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/ns-d3d11_4-d3d11_feature_data_video_decoder_histogram typedef struct
	// D3D11_FEATURE_DATA_VIDEO_DECODER_HISTOGRAM { D3D11_VIDEO_DECODER_DESC DecoderDesc; D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAGS
	// Components; UINT BinCount; UINT CounterBitDepth; } D3D11_FEATURE_DATA_VIDEO_DECODER_HISTOGRAM;
	[PInvokeData("d3d11_4.h", MSDNShortId = "NS:d3d11_4.D3D11_FEATURE_DATA_VIDEO_DECODER_HISTOGRAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_VIDEO_DECODER_HISTOGRAM
	{
		/// <summary>A D3D11_VIDEO_DECODER_DESC structure containing the decoder description for the decoder to be used with decode histogram.</summary>
		public D3D11_VIDEO_DECODER_DESC DecoderDesc;

		/// <summary>
		/// A bitwise OR combination of values from the D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAGS enumeration specifying the components
		/// of a DXGI_FORMAT for which histogram support will be queried.
		/// </summary>
		public D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAGS Components;

		/// <summary>
		/// The number of per component bins supported. This value must be greater than or equal to 64 and must be a power of 2 (e.g. 64,
		/// 128, 256, 512...).
		/// </summary>
		public uint BinCount;

		/// <summary>
		/// The bit depth of the bin counter. The counter is always stored in a 32-bit value and therefore this value must specify 32 bits
		/// or less. The counter is stored in the lower bits of the 32-bit storage. The upper bits are set to zero. If the bin count exceeds
		/// this bit depth, the value is set to the maximum counter value. Valid values for CounterBitDepth are 16, 24, and 32.
		/// </summary>
		public uint CounterBitDepth;
	}

	/// <summary>Describes a compressed buffer for decoding.</summary>
	[PInvokeData("d3d11_4.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_DECODER_BUFFER_DESC2
	{
		/// <summary>The type of buffer.</summary>
		public D3D11_VIDEO_DECODER_BUFFER_TYPE BufferType;

		/// <summary>The offset of the relevant data from the beginning of the buffer, in bytes. This value must be zero.</summary>
		public uint DataOffset;

		/// <summary>Size of the relevant data.</summary>
		public uint DataSize;

		/// <summary>
		/// A pointer to a buffer that contains an initialization vector (IV) for encrypted data. If the decode buffer does not contain
		/// encrypted data, set this member to NULL.
		/// </summary>
		public IntPtr pIV;

		/// <summary>The size of the buffer specified in the <c>pIV</c> parameter. If <c>pIV</c> is NULL, set this member to zero.</summary>
		public uint IVSize;

		/// <summary>
		/// <para>
		/// A pointer to an array of D3D11_VIDEO_DECODER_SUB_SAMPLE_MAPPING_BLOCK structures, which indicates exactly which bytes in the
		/// decode buffer are encrypted and which are in the clear. If the decode buffer does not contain encrypted data, set this member to NULL.
		/// </para>
		/// <para>Values in the sub sample mapping blocks are relative to the start of the decode buffer.</para>
		/// </summary>
		public ArrayPointer<D3D11_VIDEO_DECODER_SUB_SAMPLE_MAPPING_BLOCK> pSubSampleMappingBlock;

		/// <summary>
		/// The number of D3D11_VIDEO_DECODER_SUB_SAMPLE_MAPPING_BLOCK structures specified in the <c>pSubSampleMappingBlocks</c> parameter.
		/// If <c>pSubSampleMappingBlocks</c> is NULL, set this member to zero.
		/// </summary>
		public uint SubSampleMappingCount;

		/// <summary/>
		public uint cBlocksStripeEncrypted;

		/// <summary/>
		public uint cBlocksStripeClear;
	}
}