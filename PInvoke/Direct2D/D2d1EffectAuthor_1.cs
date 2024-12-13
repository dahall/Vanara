namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>Provides factory methods and other state management for effect and transform authors.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor_1/nn-d2d1effectauthor_1-id2d1effectcontext1
	[PInvokeData("d2d1effectauthor_1.h", MSDNShortId = "NN:d2d1effectauthor_1.ID2D1EffectContext1")]
	[ComImport, Guid("84ab595a-fc81-4546-bacd-e8ef4d8abe7a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1EffectContext1 : ID2D1EffectContext
	{
		/// <summary>Gets the unit mapping that an effect will use for properties that could be in either dots per inch (dpi) or pixels.</summary>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The dpi on the x-axis.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The dpi on the y-axis.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the <c>D2D1_UNIT_MODE</c> is <b>D2D1_UNIT_MODE_PIXELS</b>, both <i>dpiX</i> and <i>dpiY</i> will be set to 96.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-getdpi void GetDpi(
		// [out] FLOAT *dpiX, [out] FLOAT *dpiY );
		[PreserveSig]
		new void GetDpi(out float dpiX, out float dpiY);

		/// <summary>
		/// Creates a Direct2D effect for the specified class ID. This is the same as <c>ID2D1DeviceContext::CreateEffect</c> so custom
		/// effects can create other effects and wrap them in a transform.
		/// </summary>
		/// <param name="effectId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The built-in or registered effect ID to create the effect. See <c>Built-in Effects</c> for a list of effect IDs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1Effect</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the effect.</para>
		/// </returns>
		/// <remarks>
		/// The created effect does not reference count the DLL from which the effect was created. If the caller unregisters an effect while
		/// this effect is loaded, the resulting behavior is unpredictable.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createeffect HRESULT
		// CreateEffect( REFCLSID effectId, [out] ID2D1Effect **effect );
		new ID2D1Effect CreateEffect(in Guid effectId);

		/// <summary>
		/// This indicates the maximum feature level from the provided list which is supported by the device. If none of the provided levels
		/// are supported, then this API fails with D2DERR_INSUFFICIENT_DEVICE_CAPABILITIES.
		/// </summary>
		/// <param name="featureLevels">
		/// <para>Type: <b>const <c>D3D_FEATURE_LEVEL</c>*</b></para>
		/// <para>The feature levels provided by the application.</para>
		/// </param>
		/// <param name="featureLevelsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The count of feature levels provided by the application</para>
		/// </param>
		/// <param name="maximumSupportedFeatureLevel">
		/// <para>Type: <b><c>D3D_FEATURE_LEVEL</c>*</b></para>
		/// <para>The maximum feature level from the <i>featureLevels</i> list which is supported by the D2D device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>The method returns an <b>HRESULT</b>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>Direct2D could not allocate sufficient memory to complete the call.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed to the returning function.</description>
		/// </item>
		/// <item>
		/// <description>D2DERR_INSUFFICIENT_DEVICE_CAPABILITIES</description>
		/// <description>None of the provided levels are supported.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-getmaximumsupportedfeaturelevel
		// HRESULT GetMaximumSupportedFeatureLevel( [in] const D3D_FEATURE_LEVEL *featureLevels, UINT32 featureLevelsCount, [out]
		// D3D_FEATURE_LEVEL *maximumSupportedFeatureLevel );
		[PreserveSig]
		new HRESULT GetMaximumSupportedFeatureLevel([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D_FEATURE_LEVEL[] featureLevels,
			int featureLevelsCount, out D3D_FEATURE_LEVEL maximumSupportedFeatureLevel);

		/// <summary>
		/// Wraps an effect graph into a single transform node and then inserted into a transform graph. This allows an effect to aggregate
		/// other effects. This will typically be done in order to allow the effect properties to be re-expressed with a different contract,
		/// or to allow different components to integrate each-other’s effects.
		/// </summary>
		/// <param name="effect">
		/// <para>Type: <b><c>ID2D1Effect</c>*</b></para>
		/// <para>The effect to be wrapped in a transform node.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1TransformNode</c>**</b></para>
		/// <para>The returned transform node that encapsulates the effect graph.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createtransformnodefromeffect
		// HRESULT CreateTransformNodeFromEffect( [in] ID2D1Effect *effect, [out] ID2D1TransformNode **transformNode );
		new ID2D1TransformNode CreateTransformNodeFromEffect([In] ID2D1Effect effect);

		/// <summary>This creates a blend transform that can be inserted into a transform graph.</summary>
		/// <param name="numInputs">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of inputs to the blend transform.</para>
		/// </param>
		/// <param name="blendDescription">
		/// <para>Type: <b>const <c>D2D1_BLEND_DESCRIPTION</c>*</b></para>
		/// <para>Describes the blend transform that is to be created.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1BlendTransform</c>**</b></para>
		/// <para>The returned blend transform.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createblendtransform
		// HRESULT CreateBlendTransform( UINT32 numInputs, [in] const D2D1_BLEND_DESCRIPTION *blendDescription, [out] ID2D1BlendTransform
		// **transform );
		new ID2D1BlendTransform CreateBlendTransform(uint numInputs, in D2D1_BLEND_DESCRIPTION blendDescription);

		/// <summary>Creates a transform that extends its input infinitely in every direction based on the passed in extend mode.</summary>
		/// <param name="extendModeX">
		/// <para>Type: <b><c>D2D1_EXTEND_MODE</c></b></para>
		/// <para>The extend mode in the X-axis direction.</para>
		/// </param>
		/// <param name="extendModeY">
		/// <para>Type: <b><c>D2D1_EXTEND_MODE</c></b></para>
		/// <para>The extend mode in the Y-axis direction.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1BorderTransform</c>**</b></para>
		/// <para>The returned transform.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createbordertransform
		// HRESULT CreateBorderTransform( D2D1_EXTEND_MODE extendModeX, D2D1_EXTEND_MODE extendModeY, [out] ID2D1BorderTransform **transform );
		new ID2D1BorderTransform CreateBorderTransform(D2D1_EXTEND_MODE extendModeX, D2D1_EXTEND_MODE extendModeY);

		/// <summary>Creates and returns an offset transform.</summary>
		/// <param name="offset">
		/// <para>Type: <b><c>D2D1_POINT_2L</c></b></para>
		/// <para>The offset amount.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1OffsetTransform</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to an offset transform object.</para>
		/// </returns>
		/// <remarks>
		/// An offset transform is used to offset an input bitmap without having to insert a rendering pass. An offset transform is
		/// automatically inserted by an Affine transform if the transform evaluates to a pixel-aligned transform.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createoffsettransform
		// HRESULT CreateOffsetTransform( D2D1_POINT_2L offset, [out] ID2D1OffsetTransform **transform );
		new ID2D1OffsetTransform CreateOffsetTransform(POINT offset);

		/// <summary>Creates and returns a bounds adjustment transform.</summary>
		/// <param name="outputRectangle">
		/// <para>Type: <b>const <c>D2D1_RECT_L</c>*</b></para>
		/// <para>The initial output rectangle for the bounds adjustment transform.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1BoundsAdjustmentTransform</c>**</b></para>
		/// <para>The returned bounds adjustment transform.</para>
		/// </returns>
		/// <remarks>
		/// <para>A support transform can be used for two different reasons.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// To indicate that a region of its input image is already transparent black. This can increase efficiency for rendering bitmaps.
		/// </description>
		/// </item>
		/// <item>
		/// <description>To increase the size of the input image. The expanded area will be treated as transparent black</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createboundsadjustmenttransform
		// HRESULT CreateBoundsAdjustmentTransform( [in] const D2D1_RECT_L *outputRectangle, [out] ID2D1BoundsAdjustmentTransform
		// **transform );
		new ID2D1BoundsAdjustmentTransform CreateBoundsAdjustmentTransform(in RECT outputRectangle);

		/// <summary>
		/// Loads the given shader by its unique ID. Loading the shader multiple times is ignored. When the shader is loaded it is also
		/// handed to the driver to JIT, if it hasn’t been already.
		/// </summary>
		/// <param name="shaderId">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>The unique id that identifies the shader.</para>
		/// </param>
		/// <param name="shaderBuffer">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>The buffer that contains the shader to register.</para>
		/// </param>
		/// <param name="shaderBufferCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the shader buffer in bytes.</para>
		/// </param>
		/// <remarks>The shader you specify must be compiled, not in raw HLSL code.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-loadpixelshader
		// HRESULT LoadPixelShader( [in] REFGUID shaderId, [in] const BYTE *shaderBuffer, UINT32 shaderBufferCount );
		new void LoadPixelShader(in Guid shaderId, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] shaderBuffer, int shaderBufferCount);

		/// <summary>
		/// Loads the given shader by its unique ID. Loading the shader multiple times is ignored. When the shader is loaded it is also
		/// handed to the driver to JIT, if it hasn’t been already.
		/// </summary>
		/// <param name="resourceId">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>The unique id that identifies the shader.</para>
		/// </param>
		/// <param name="shaderBuffer">
		/// <para>Type: <b>BYTE*</b></para>
		/// <para>The buffer that contains the shader to register.</para>
		/// </param>
		/// <param name="shaderBufferCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the shader buffer in bytes.</para>
		/// </param>
		/// <remarks>The shader you specify must be compiled, not in raw HLSL code.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-loadvertexshader
		// HRESULT LoadVertexShader( REFGUID resourceId, const BYTE *shaderBuffer, UINT32 shaderBufferCount );
		new void LoadVertexShader(in Guid resourceId, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] shaderBuffer, int shaderBufferCount);

		/// <summary>
		/// Loads the given shader by its unique ID. Loading the shader multiple times is ignored. When the shader is loaded it is also
		/// handed to the driver to JIT, if it hasn’t been already.
		/// </summary>
		/// <param name="resourceId">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>The unique id that identifies the shader.</para>
		/// </param>
		/// <param name="shaderBuffer">
		/// <para>Type: <b>BYTE*</b></para>
		/// <para>The buffer that contains the shader to register.</para>
		/// </param>
		/// <param name="shaderBufferCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the shader buffer in bytes.</para>
		/// </param>
		/// <remarks>The shader you specify must be compiled, not in raw HLSL code.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-loadcomputeshader
		// HRESULT LoadComputeShader( REFGUID resourceId, const BYTE *shaderBuffer, UINT32 shaderBufferCount );
		new void LoadComputeShader(in Guid resourceId, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] shaderBuffer, int shaderBufferCount);

		/// <summary>This tests to see if the given shader is loaded.</summary>
		/// <param name="shaderId">
		/// <para>Type: <b>REFGUID</b></para>
		/// <para>The unique id that identifies the shader.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Whether the shader is loaded.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-isshaderloaded BOOL
		// IsShaderLoaded( REFGUID shaderId );
		[PreserveSig]
		new bool IsShaderLoaded(in Guid shaderId);

		/// <summary>
		/// Creates or finds the given resource texture, depending on whether a resource id is specified. It also optionally initializes the
		/// texture with the specified data.
		/// </summary>
		/// <param name="resourceId">
		/// <para>Type: <b>const GUID*</b></para>
		/// <para>An optional pointer to the unique id that identifies the lookup table.</para>
		/// </param>
		/// <param name="resourceTextureProperties">
		/// <para>Type: <b>const <c>D2D1_RESOURCE_TEXTURE_PROPERTIES</c>*</b></para>
		/// <para>The properties used to create the resource texture.</para>
		/// </param>
		/// <param name="data">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>The optional data to be loaded into the resource texture.</para>
		/// </param>
		/// <param name="strides">
		/// <para>Type: <b>const UINT32*</b></para>
		/// <para>An optional pointer to the stride to advance through the resource texture, according to dimension.</para>
		/// </param>
		/// <param name="dataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size, in bytes, of the data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1ResourceTexture</c>**</b></para>
		/// <para>The returned texture that can be used as a resource in a Direct2D effect.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createresourcetexture
		// HRESULT CreateResourceTexture( [in, optional] const GUID *resourceId, [in] const D2D1_RESOURCE_TEXTURE_PROPERTIES
		// *resourceTextureProperties, [in, optional] const BYTE *data, [in, optional] const UINT32 *strides, UINT32 dataSize, [out]
		// ID2D1ResourceTexture **resourceTexture );
		new ID2D1ResourceTexture CreateResourceTexture([In, Optional] GuidPtr resourceId, in D2D1_RESOURCE_TEXTURE_PROPERTIES resourceTextureProperties,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[]? data,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[]? strides, [Optional] int dataSize);

		/// <summary>
		/// Finds the given resource texture if it has already been created with <c>ID2D1EffectContext::CreateResourceTexture</c> with the
		/// same GUID.
		/// </summary>
		/// <param name="resourceId">
		/// <para>Type: <b>const GUID*</b></para>
		/// <para>The unique id that identifies the resource texture.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1ResourceTexture</c>**</b></para>
		/// <para>The returned texture that can be used as a resource in a Direct2D effect.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-findresourcetexture
		// HRESULT FindResourceTexture( [in] const GUID *resourceId, [out] ID2D1ResourceTexture **resourceTexture );
		new ID2D1ResourceTexture FindResourceTexture(in Guid resourceId);

		/// <summary>
		/// Creates a vertex buffer or finds a standard vertex buffer and optionally initializes it with vertices. The returned buffer can
		/// be specified in the render info to specify both a vertex shader and or to pass custom vertices to the standard vertex shader
		/// used by <c>Direct2D</c>.
		/// </summary>
		/// <param name="vertexBufferProperties">
		/// <para>Type: <b>const <c>D2D1_VERTEX_BUFFER_PROPERTIES</c>*</b></para>
		/// <para>The properties used to describe the vertex buffer and vertex shader.</para>
		/// </param>
		/// <param name="resourceId">
		/// <para>Type: <b>const GUID*</b></para>
		/// <para>The unique id that identifies the vertex buffer.</para>
		/// </param>
		/// <param name="customVertexBufferProperties">
		/// <para>Type: <b>const <c>D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES</c>*</b></para>
		/// <para>
		/// The properties used to define a custom vertex buffer. If you use a built-in vertex shader, you don't have to specify this property.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1VertexBuffer</c>**</b></para>
		/// <para>The returned vertex buffer.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createvertexbuffer
		// HRESULT CreateVertexBuffer( [in] const D2D1_VERTEX_BUFFER_PROPERTIES *vertexBufferProperties, [in, optional] const GUID
		// *resourceId, [in, optional] const D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES *customVertexBufferProperties, [out] ID2D1VertexBuffer
		// **buffer );
		new ID2D1VertexBuffer CreateVertexBuffer(in D2D1_VERTEX_BUFFER_PROPERTIES vertexBufferProperties, [In, Optional] GuidPtr resourceId,
			[In, Optional] StructPointer<D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES> customVertexBufferProperties);

		/// <summary>
		/// This finds the given vertex buffer if it has already been created with <c>ID2D1EffectContext::CreateVertexBuffer</c> with the
		/// same GUID.
		/// </summary>
		/// <param name="resourceId">
		/// <para>Type: <b>const GUID*</b></para>
		/// <para>The unique id that identifies the vertex buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1VertexBuffer</c>**</b></para>
		/// <para>The returned vertex buffer that can be used as a resource in a <c>Direct2D</c> effect.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-findvertexbuffer
		// HRESULT FindVertexBuffer( [in] const GUID *resourceId, [out] ID2D1VertexBuffer **buffer );
		new ID2D1VertexBuffer FindVertexBuffer(in Guid resourceId);

		/// <summary>
		/// <para>Creates a color context from a color space.</para>
		/// <para>If the color space is Custom, the context is initialized from the <i>profile</i> and <i>profileSize</i> parameters.</para>
		/// <para>
		/// If the color space is not Custom, the context is initialized with the profile bytes associated with the color space. The
		/// <i>profile</i> and <i>profileSize</i> parameters are ignored.
		/// </para>
		/// </summary>
		/// <param name="space">
		/// <para>Type: <b><c>D2D1_COLOR_SPACE</c></b></para>
		/// <para>The space of color context to create.</para>
		/// </param>
		/// <param name="profile">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>
		/// A buffer containing the ICC profile bytes used to initialize the color context when <i>space</i> is
		/// <c>D2D1_COLOR_SPACE_CUSTOM</c>. For other types, the parameter is ignored and should be set to <b>NULL</b>.
		/// </para>
		/// </param>
		/// <param name="profileSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size in bytes of <i>Profile</i>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1ColorContext</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createcolorcontext
		// HRESULT CreateColorContext( D2D1_COLOR_SPACE space, [in, optional] const BYTE *profile, UINT32 profileSize, [out]
		// ID2D1ColorContext **colorContext );
		new ID2D1ColorContext CreateColorContext(D2D1_COLOR_SPACE space, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[]? profile,
			[Optional] int profileSize);

		/// <summary>
		/// Creates a color context by loading it from the specified filename. The profile bytes are the contents of the file specified by <i>filename</i>.
		/// </summary>
		/// <param name="filename">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The path to the file containing the profile bytes to initialize the color context with.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1ColorContext</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createcolorcontextfromfilename
		// HRESULT CreateColorContextFromFilename( PCWSTR filename, [out] ID2D1ColorContext **colorContext );
		new ID2D1ColorContext CreateColorContextFromFilename([MarshalAs(UnmanagedType.LPWStr)] string filename);

		/// <summary>
		/// Creates a color context from an <c>IWICColorContext</c>. The <c>D2D1ColorContext</c> space of the resulting context varies, see
		/// Remarks for more info.
		/// </summary>
		/// <param name="wicColorContext">
		/// <para>Type: <b><c>IWICColorContext</c>*</b></para>
		/// <para>The <c>IWICColorContext</c> used to initialize the color context.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>ID2D1ColorContext</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context.</para>
		/// </returns>
		/// <remarks>
		/// The new color context can be used in <c>D2D1_BITMAP_PROPERTIES1</c> to initialize the color context of a created bitmap. The
		/// model field of the profile header is inspected to determine whether this profile is sRGB or scRGB and the color space is updated
		/// respectively. Otherwise the space is custom.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-createcolorcontextfromwiccolorcontext
		// HRESULT CreateColorContextFromWicColorContext( [in] IWICColorContext *wicColorContext, [out] ID2D1ColorContext **colorContext );
		new ID2D1ColorContext CreateColorContextFromWicColorContext([In] IWICColorContext wicColorContext);

		/// <summary>This indicates whether an optional capability is supported by the D3D device.</summary>
		/// <param name="feature">
		/// <para>Type: <b><c>D2D1_FEATURE</c></b></para>
		/// <para>The feature to query support for.</para>
		/// </param>
		/// <param name="featureSupportData">
		/// <para>Type: <b>void*</b></para>
		/// <para>A structure indicating information about how or if the feature is supported.</para>
		/// </param>
		/// <param name="featureSupportDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the <i>featureSupportData</i> parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>The method returns an <b>HRESULT</b>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>HRESULT</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>No error occurred.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>Direct2D could not allocate sufficient memory to complete the call.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>An invalid parameter was passed to the returning function.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-checkfeaturesupport
		// HRESULT CheckFeatureSupport( D2D1_FEATURE feature, [out] void *featureSupportData, [out] UINT32 featureSupportDataSize );
		[PreserveSig]
		new HRESULT CheckFeatureSupport(D2D1_FEATURE feature, IntPtr featureSupportData, uint featureSupportDataSize);

		/// <summary>Indicates whether the buffer precision is supported by the underlying Direct2D <c>device.</c></summary>
		/// <param name="bufferPrecision">
		/// <para>Type: <b><c>D2D1_BUFFER_PRECISION</c></b></para>
		/// <para>The buffer precision to check.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns TRUE if the buffer precision is supported. Returns FALSE if the buffer precision is not supported.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nf-d2d1effectauthor-id2d1effectcontext-isbufferprecisionsupported
		// BOOL IsBufferPrecisionSupported( D2D1_BUFFER_PRECISION bufferPrecision );
		[PreserveSig]
		new bool IsBufferPrecisionSupported(D2D1_BUFFER_PRECISION bufferPrecision);

		/// <summary>Creates a 3D lookup table for mapping a 3-channel input to a 3-channel output. The table data must be provided in 4-channel format.</summary>
		/// <param name="precision">
		///   <para>Type: <b><c>D2D1_BUFFER_PRECISION</c></b></para>
		///   <para>Precision of the input lookup table data.</para>
		/// </param>
		/// <param name="extents">
		///   <para>Type: <b>const UINT32*</b></para>
		///   <para>Number of lookup table elements per dimension (X, Y, Z).</para>
		/// </param>
		/// <param name="data">
		///   <para>Type: <b>const BYTE*</b></para>
		///   <para>Buffer holding the lookup table data.</para>
		/// </param>
		/// <param name="dataCount">
		///   <para>Type: <b>UINT32</b></para>
		///   <para>Size of the lookup table data buffer.</para>
		/// </param>
		/// <param name="strides">
		///   <para>Type: <b>const UINT32*</b></para>
		///   <para>An array containing two values. The first value is the size in bytes from one row (X dimension) of LUT data to the next. The second value is the size in bytes from one LUT data plane (X and Y dimensions) to the next.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>ID2D1LookupTable3D</c>**</b></para>
		///   <para>Receives the new lookup table instance.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor_1/nf-d2d1effectauthor_1-id2d1effectcontext1-createlookuptable3d
		// HRESULT CreateLookupTable3D( D2D1_BUFFER_PRECISION precision, [in] const UINT32 *extents, [in] const BYTE *data, UINT32 dataCount, [in] const UINT32 *strides, [out] ID2D1LookupTable3D **lookupTable );
		ID2D1LookupTable3D CreateLookupTable3D(D2D1_BUFFER_PRECISION precision, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] uint[] extents,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] data, int dataCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] uint[] strides);
	}
}