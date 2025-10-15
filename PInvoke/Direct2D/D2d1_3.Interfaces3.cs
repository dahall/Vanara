namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>
	/// <para>Important</para>
	/// <para>
	/// Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft
	/// makes no warranties, express or implied, with respect to the information provided here.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1devicecontext7
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1DeviceContext7")]
	[ComImport, Guid("EC891CF7-9B69-4851-9DEF-4E0915771E62"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1DeviceContext7 : ID2D1DeviceContext6
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Creates a Direct2D bitmap from a pointer to in-memory source data.</summary>
		/// <param name="size">
		/// <para>Type: [in] <c>D2D1_SIZE_U</c></para>
		/// <para>The dimensions of the bitmap to create in pixels.</para>
		/// </param>
		/// <param name="srcData">
		/// <para>Type: [in, optional] <c>const void*</c></para>
		/// <para>A pointer to the memory location of the image data, or <c>NULL</c> to create an uninitialized bitmap.</para>
		/// </param>
		/// <param name="pitch">
		/// <para>Type: [in] <c>UINT32</c></para>
		/// <para>
		/// The byte count of each scanline, which is equal to (the image width in pixels × the number of bytes per pixel) + memory padding.
		/// If srcData is <c>NULL</c>, this value is ignored. (Note that pitch is also sometimes called stride.)
		/// </para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: [in] <c>const D2D1_BITMAP_PROPERTIES &amp;</c></para>
		/// <para>The pixel format and dots per inch (DPI) of the bitmap to create.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1Bitmap**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to the new bitmap. This parameter is passed uninitialized.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmap(d2d1_size_u_constvoid_uint32_constd2d1_bitmap_properties__id2d1bitmap)
		// HRESULT CreateBitmap( D2D1_SIZE_U size, const void *srcData, UINT32 pitch, const D2D1_BITMAP_PROPERTIES &amp; bitmapProperties,
		// ID2D1Bitmap **bitmap );
		new ID2D1Bitmap CreateBitmap(D2D_SIZE_U size, [In, Optional] IntPtr srcData, uint pitch, in D2D1_BITMAP_PROPERTIES bitmapProperties);

		/// <summary>Creates an ID2D1Bitmap by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="wicBitmapSource">
		/// <para>Type: [in] <c>IWICBitmapSource*</c></para>
		/// <para>The WIC bitmap to copy.</para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: [in, optional] <c>const D2D1_BITMAP_PROPERTIES*</c></para>
		/// <para>
		/// The pixel format and DPI of the bitmap to create. The pixel format must match the pixel format of wicBitmapSource, or the method
		/// will fail. To prevent a mismatch, you can pass <c>NULL</c> or pass the value obtained from calling the D2D1::PixelFormat helper
		/// function without specifying any parameter values. If both dpiX and dpiY are 0.0f, the default DPI, 96, is used. DPI information
		/// embedded in wicBitmapSource is ignored.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Bitmap**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new bitmap. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// Before Direct2D can load a WIC bitmap, that bitmap must be converted to a supported pixel format and alpha mode. For a list of
		/// supported pixel formats and alpha modes, see Supported Pixel Formats and Alpha Modes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmapfromwicbitmap(iwicbitmapsource_constd2d1_bitmap_properties_id2d1bitmap)
		// HRESULT CreateBitmapFromWicBitmap( IWICBitmapSource *wicBitmapSource, const D2D1_BITMAP_PROPERTIES *bitmapProperties, ID2D1Bitmap
		// **bitmap );
		new ID2D1Bitmap CreateBitmapFromWicBitmap(IWICBitmapSource wicBitmapSource, [In, Optional] StructPointer<D2D1_BITMAP_PROPERTIES> bitmapProperties);

		/// <summary>Creates an ID2D1Bitmap whose data is shared with another resource.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>The interface ID of the object supplying the source data.</para>
		/// </param>
		/// <param name="data">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// An ID2D1Bitmap, IDXGISurface, or an IWICBitmapLock that contains the data to share with the new <c>ID2D1Bitmap</c>. For more
		/// information, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: <c>D2D1_BITMAP_PROPERTIES*</c></para>
		/// <para>
		/// The pixel format and DPI of the bitmap to create . The DXGI_FORMAT portion of the pixel format must match the DXGI_FORMAT of
		/// data or the method will fail, but the alpha modes don't have to match. To prevent a mismatch, you can pass <c>NULL</c> or the
		/// value obtained from the D2D1::PixelFormat helper function. The DPI settings do not have to match those of data. If both dpiX and
		/// dpiY are 0.0f, the DPI of the render target is used.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Bitmap**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new bitmap. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CreateSharedBitmap</c> method is useful for efficiently reusing bitmap data and can also be used to provide
		/// interoperability with Direct3D.
		/// </para>
		/// <para>Sharing an ID2D1Bitmap</para>
		/// <para>
		/// By passing an ID2D1Bitmap created by a render target that is resource-compatible, you can share a bitmap with that render
		/// target; both the original <c>ID2D1Bitmap</c> and the new <c>ID2D1Bitmap</c> created by this method will point to the same bitmap
		/// data. For more information about when render target resources can be shared, see the Sharing Render Target Resources section of
		/// the Resources Overview.
		/// </para>
		/// <para>
		/// You may also use this method to reinterpret the data of an existing bitmap and specify a new DPI or alpha mode. For example, in
		/// the case of a bitmap atlas, an ID2D1Bitmap may contain multiple sub-images, each of which should be rendered with a different
		/// D2D1_ALPHA_MODE ( <c>D2D1_ALPHA_MODE_PREMULTIPLIED</c> or <c>D2D1_ALPHA_MODE_IGNORE</c>). You could use the
		/// <c>CreateSharedBitmap</c> method to reinterpret the bitmap using the desired alpha mode without having to load a separate copy
		/// of the bitmap into memory.
		/// </para>
		/// <para>Sharing an IDXGISurface</para>
		/// <para>
		/// When using a DXGI surface render target (an ID2D1RenderTarget object created by the CreateDxgiSurfaceRenderTarget method), you
		/// can pass an IDXGISurface surface to the <c>CreateSharedBitmap</c> method to share video memory with Direct3D and manipulate
		/// Direct3D content as an ID2D1Bitmap. As described in the Resources Overview, the render target and the IDXGISurface must be using
		/// the same Direct3D device.
		/// </para>
		/// <para>
		/// Note also that the IDXGISurface must use one of the supported pixel formats and alpha modes described in Supported Pixel Formats
		/// and Alpha Modes.
		/// </para>
		/// <para>For more information about interoperability with Direct3D, see the Direct2D and Direct3D Interoperability Overview.</para>
		/// <para>Sharing an IWICBitmapLock</para>
		/// <para>
		/// An IWICBitmapLock stores the content of a WIC bitmap and shields it from simultaneous accesses. By passing an
		/// <c>IWICBitmapLock</c> to the <c>CreateSharedBitmap</c> method, you can create an ID2D1Bitmap that points to the bitmap data
		/// already stored in the <c>IWICBitmapLock</c>.
		/// </para>
		/// <para>
		/// To use an IWICBitmapLock with the <c>CreateSharedBitmap</c> method, the render target must use software rendering. To force a
		/// render target to use software rendering, set to D2D1_RENDER_TARGET_TYPE_SOFTWARE the <c>type</c> field of the
		/// D2D1_RENDER_TARGET_PROPERTIES structure that you use to create the render target. To check whether an existing render target
		/// uses software rendering, use the IsSupported method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createsharedbitmap HRESULT CreateSharedBitmap(
		// REFIID riid, void *data, const D2D1_BITMAP_PROPERTIES *bitmapProperties, ID2D1Bitmap **bitmap );
		new ID2D1Bitmap CreateSharedBitmap(in Guid riid, [In, Out, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] object data, [In, Optional] StructPointer<D2D1_BITMAP_PROPERTIES> bitmapProperties);

		/// <summary>Creates an ID2D1BitmapBrush from the specified bitmap.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap contents of the new brush.</para>
		/// </param>
		/// <param name="bitmapBrushProperties">
		/// <para>Type: <c>D2D1_BITMAP_BRUSH_PROPERTIES*</c></para>
		/// <para>
		/// The extend modes and interpolation mode of the new brush, or <c>NULL</c>. If you set this parameter to <c>NULL</c>, the brush
		/// defaults to the D2D1_EXTEND_MODE_CLAMP horizontal and vertical extend modes and the D2D1_BITMAP_INTERPOLATION_MODE_LINEAR
		/// interpolation mode.
		/// </para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: <c>D2D1_BRUSH_PROPERTIES*</c></para>
		/// <para>
		/// A structure that contains the opacity and transform of the new brush, or <c>NULL</c>. If you set this parameter to <c>NULL</c>,
		/// the brush sets the opacity member to 1.0F and the transform member to the identity matrix.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1BitmapBrush**</c></para>
		/// <para>
		/// When this method returns, this output parameter contains a pointer to a pointer to the new brush. Pass this parameter uninitialized.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmapbrush(id2d1bitmap_constd2d1_bitmap_brush_properties_constd2d1_brush_properties_id2d1bitmapbrush)
		// HRESULT CreateBitmapBrush( ID2D1Bitmap *bitmap, const D2D1_BITMAP_BRUSH_PROPERTIES *bitmapBrushProperties, const
		// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1BitmapBrush **bitmapBrush );
		new ID2D1BitmapBrush CreateBitmapBrush([In, Optional] ID2D1Bitmap? bitmap, [In, Optional] StructPointer<D2D1_BITMAP_BRUSH_PROPERTIES> bitmapBrushProperties, [In, Optional] StructPointer<D2D1_BRUSH_PROPERTIES> brushProperties);

		/// <summary>Creates a new ID2D1SolidColorBrush that has the specified color and opacity.</summary>
		/// <param name="color">
		/// <para>Type: [in] <c>const D2D1_COLOR_F &amp;</c></para>
		/// <para>The red, green, blue, and alpha values of the brush's color.</para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES &amp;</c></para>
		/// <para>The base opacity of the brush.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1SolidColorBrush**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new brush. This parameter is passed uninitialized.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createsolidcolorbrush(constd2d1_color_f__constd2d1_brush_properties__id2d1solidcolorbrush)
		// HRESULT CreateSolidColorBrush( const D2D1_COLOR_F &amp; color, const D2D1_BRUSH_PROPERTIES &amp; brushProperties,
		// ID2D1SolidColorBrush **solidColorBrush );
		new ID2D1SolidColorBrush CreateSolidColorBrush(in D3DCOLORVALUE color, [In, Optional] StructPointer<D2D1_BRUSH_PROPERTIES> brushProperties);

		/// <summary>Creates an ID2D1GradientStopCollection from the specified array of D2D1_GRADIENT_STOP structures.</summary>
		/// <param name="gradientStops">
		/// <para>Type: [in] <c>D2D1_GRADIENT_STOP*</c></para>
		/// <para>A pointer to an array of D2D1_GRADIENT_STOP structures.</para>
		/// </param>
		/// <param name="gradientStopsCount">
		/// <para>Type: [in] <c>UINT</c></para>
		/// <para>A value greater than or equal to 1 that specifies the number of gradient stops in the gradientStops array.</para>
		/// </param>
		/// <param name="colorInterpolationGamma">
		/// <para>Type: [in] <c>D2D1_GAMMA</c></para>
		/// <para>The space in which color interpolation between the gradient stops is performed.</para>
		/// </param>
		/// <param name="extendMode">
		/// <para>Type: [in] <c>D2D1_EXTEND_MODE</c></para>
		/// <para>The behavior of the gradient outside the [0,1] normalized range.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1GradientStopCollection**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to the new gradient stop collection.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-creategradientstopcollection%28constd2d1_gradient_stop_uint32_d2d1_gamma_d2d1_extend_mode_id2d1gradientstopcollection%29
		// HRESULT CreateGradientStopCollection( const D2D1_GRADIENT_STOP *gradientStops, UINT32 gradientStopsCount, D2D1_GAMMA
		// colorInterpolationGamma, D2D1_EXTEND_MODE extendMode, ID2D1GradientStopCollection **gradientStopCollection );
		new ID2D1GradientStopCollection CreateGradientStopCollection([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_GRADIENT_STOP[] gradientStops, uint gradientStopsCount, [Optional] D2D1_GAMMA colorInterpolationGamma, [Optional] D2D1_EXTEND_MODE extendMode);

		/// <summary>Creates an ID2D1LinearGradientBrush object for painting areas with a linear gradient.</summary>
		/// <param name="linearGradientBrushProperties">
		/// <para>Type: [in] <c>const D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES*</c></para>
		/// <para>The start and end points of the gradient.</para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES*</c></para>
		/// <para>The transform and base opacity of the new brush.</para>
		/// </param>
		/// <param name="gradientStopCollection">
		/// <para>Type: [in] <c>ID2D1GradientStopCollection*</c></para>
		/// <para>
		/// A collection of D2D1_GRADIENT_STOP structures that describe the colors in the brush's gradient and their locations along the
		/// gradient line.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1LinearGradientBrush**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new brush. This parameter is passed uninitialized.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createlineargradientbrush%28constd2d1_linear_gradient_brush_properties_constd2d1_brush_properties_id2d1gradientstopcollection_id2d1lineargradientbrush%29
		// HRESULT CreateLinearGradientBrush( const D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES *linearGradientBrushProperties, const
		// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1GradientStopCollection *gradientStopCollection, ID2D1LinearGradientBrush
		// **linearGradientBrush );
		new ID2D1LinearGradientBrush CreateLinearGradientBrush(in D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES linearGradientBrushProperties, [In, Optional] StructPointer<D2D1_BRUSH_PROPERTIES> brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection);

		/// <summary>Creates an ID2D1RadialGradientBrush object that can be used to paint areas with a radial gradient.</summary>
		/// <param name="radialGradientBrushProperties">
		/// <para>Type: <c>const D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES*</c></para>
		/// <para>The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.</para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES*</c></para>
		/// <para>The transform and base opacity of the new brush.</para>
		/// </param>
		/// <param name="gradientStopCollection">
		/// <para>Type: [in] <c>ID2D1GradientStopCollection*</c></para>
		/// <para>
		/// A collection of D2D1_GRADIENT_STOP structures that describe the colors in the brush's gradient and their locations along the gradient.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RadialGradientBrush**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to the new brush. This parameter is passed uninitialized.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createradialgradientbrush%28constd2d1_radial_gradient_brush_properties_constd2d1_brush_properties_id2d1gradientstopcollection_id2d1radialgradientbrush%29
		// HRESULT CreateRadialGradientBrush( const D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES *radialGradientBrushProperties, const
		// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1GradientStopCollection *gradientStopCollection, ID2D1RadialGradientBrush
		// **radialGradientBrush );
		new ID2D1RadialGradientBrush CreateRadialGradientBrush(in D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES radialGradientBrushProperties, [In, Optional] StructPointer<D2D1_BRUSH_PROPERTIES> brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection);

		/// <summary>
		/// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
		/// </summary>
		/// <param name="desiredSize">
		/// <para>Type: [in] <c>const D2D1_SIZE_F*</c></para>
		/// <para>
		/// The desired size of the new render target (in device-independent pixels), if it should be different from the original render
		/// target. For more info, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="desiredPixelSize">
		/// <para>Type: [in] <c>const D2D1_SIZE_U*</c></para>
		/// <para>
		/// The desired size of the new render target in pixels if it should be different from the original render target. For more
		/// information, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="desiredFormat">
		/// <para>Type: [in] <c>const D2D1_PIXEL_FORMAT*</c></para>
		/// <para>
		/// The desired pixel format and alpha mode of the new render target. If the pixel format is set to DXGI_FORMAT_UNKNOWN, the new
		/// render target uses the same pixel format as the original render target. If the alpha mode is D2D1_ALPHA_MODE_UNKNOWN, the alpha
		/// mode of the new render target defaults to <c>D2D1_ALPHA_MODE_PREMULTIPLIED</c>. For information about supported pixel formats,
		/// see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <param name="options">
		/// <para>Type: [in] <c>D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS</c></para>
		/// <para>A value that specifies whether the new render target must be compatible with GDI.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1BitmapRenderTarget**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to a new bitmap render target. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>The pixel size and DPI of the new render target can be altered by specifying values for desiredSize or desiredPixelSize:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If desiredSize is specified but desiredPixelSize is not, the pixel size is computed from the desired size using the parent
		/// target DPI. If the desiredSize maps to a integer-pixel size, the DPI of the compatible render target is the same as the DPI of
		/// the parent target. If desiredSize maps to a fractional-pixel size, the pixel size is rounded up to the nearest integer and the
		/// DPI for the compatible render target is slightly higher than the DPI of the parent render target. In all cases, the coordinate
		/// (desiredSize.width, desiredSize.height) maps to the lower-right corner of the compatible render target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the desiredPixelSize is specified and desiredSize is not, the DPI of the new render target is the same as the original render target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If both desiredSize and desiredPixelSize are specified, the DPI of the new render target is computed to account for the
		/// difference in scale.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If neither desiredSize nor desiredPixelSize is specified, the new render target size and DPI match the original render target.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createcompatiblerendertarget(constd2d1_size_f_constd2d1_size_u_constd2d1_pixel_format_d2d1_compatible_render_target_options_id2d1bitmaprendertarget)
		// HRESULT CreateCompatibleRenderTarget( const D2D1_SIZE_F *desiredSize, const D2D1_SIZE_U *desiredPixelSize, const
		// D2D1_PIXEL_FORMAT *desiredFormat, D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options, ID2D1BitmapRenderTarget **bitmapRenderTarget );
		new ID2D1BitmapRenderTarget CreateCompatibleRenderTarget([In, Optional] StructPointer<D2D_SIZE_F> desiredSize, [In, Optional] StructPointer<D2D_SIZE_U> desiredPixelSize, [In, Optional] StructPointer<D2D1_PIXEL_FORMAT> desiredFormat, [In, Optional] D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options);

		/// <summary>Creates a layer resource that can be used with this render target and its compatible render targets.</summary>
		/// <param name="size">
		/// <para>Type: [in] <c>const D2D1_SIZE_F*</c></para>
		/// <para>
		/// If (0, 0) is specified, no backing store is created behind the layer resource. The layer resource is allocated to the minimum
		/// size when PushLayer is called.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1Layer**</c></para>
		/// <para>When the method returns, contains a pointer to a pointer to the new layer. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>The layer automatically resizes itself, as needed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createlayer(constd2d1_size_f_id2d1layer)
		// HRESULT CreateLayer( const D2D1_SIZE_F *size, ID2D1Layer **layer );
		new ID2D1Layer CreateLayer([In, Optional] StructPointer<D2D_SIZE_F> size);

		/// <summary>Create a mesh that uses triangles to describe a shape.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1Mesh**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to the new mesh.</para>
		/// </returns>
		/// <remarks>
		/// To populate a mesh, use its Open method to obtain an ID2D1TessellationSink. To draw the mesh, use the render target's FillMesh method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createmesh HRESULT CreateMesh( ID2D1Mesh
		// **mesh );
		new ID2D1Mesh CreateMesh();

		/// <summary>Draws a line between the specified points using the specified stroke style.</summary>
		/// <param name="point0">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The start point of the line, in device-independent pixels.</para>
		/// </param>
		/// <param name="point1">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The end point of the line, in device-independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the line's stroke.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't
		/// specified, it defaults to 1.0f. The stroke is centered on the line.
		/// </para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of stroke to paint, or <c>NULL</c> to paint a solid line.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawLine</c>) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawline void DrawLine( D2D1_POINT_2F point0,
		// D2D1_POINT_2F point1, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		new void DrawLine(D2D_POINT_2F point0, D2D_POINT_2F point1, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

		/// <summary>Draws the outline of a rectangle that has the specified dimensions and stroke style.</summary>
		/// <param name="rect">
		/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
		/// <para>The dimensions of the rectangle to draw, in device-independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the rectangle's stroke.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't
		/// specified, it defaults to 1.0f. The stroke is centered on the line.
		/// </para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of stroke to paint, or <c>NULL</c> to paint a solid stroke.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When this method fails, it does not return an error code. To determine whether a drawing method (such as DrawRectangle) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawrectangle(constd2d1_rect_f__id2d1brush_float_id2d1strokestyle)
		// void DrawRectangle( const D2D1_RECT_F &amp; rect, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		new void DrawRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

		/// <summary>Paints the interior of the specified rectangle.</summary>
		/// <param name="rect">
		/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
		/// <para>The dimension of the rectangle to paint, in device-independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the rectangle's interior.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillRectangle) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillrectangle(constd2d1_rect_f__id2d1brush)
		// void FillRectangle( const D2D1_RECT_F &amp; rect, ID2D1Brush *brush );
		[PreserveSig]
		new void FillRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush);

		/// <summary>Draws the outline of the specified rounded rectangle using the specified stroke style.</summary>
		/// <param name="roundedRect">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT &amp;</c></para>
		/// <para>The dimensions of the rounded rectangle to draw, in device-independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the rounded rectangle's outline.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't
		/// specified, it defaults to 1.0f. The stroke is centered on the line.
		/// </para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of the rounded rectangle's stroke, or <c>NULL</c> to paint a solid stroke. The default value is <c>NULL</c>.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
		/// DrawRoundedRectangle) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawroundedrectangle(constd2d1_rounded_rect__id2d1brush_float_id2d1strokestyle)
		// void DrawRoundedRectangle( const D2D1_ROUNDED_RECT &amp; roundedRect, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle
		// *strokeStyle );
		[PreserveSig]
		new void DrawRoundedRectangle(in D2D1_ROUNDED_RECT roundedRect, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

		/// <summary>Paints the interior of the specified rounded rectangle.</summary>
		/// <param name="roundedRect">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT &amp;</c></para>
		/// <para>The dimensions of the rounded rectangle to paint, in device independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the interior of the rounded rectangle.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
		/// FillRoundedRectangle) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillroundedrectangle(constd2d1_rounded_rect__id2d1brush)
		// void FillRoundedRectangle( const D2D1_ROUNDED_RECT &amp; roundedRect, ID2D1Brush *brush );
		[PreserveSig]
		new void FillRoundedRectangle(in D2D1_ROUNDED_RECT roundedRect, [In] ID2D1Brush brush);

		/// <summary>Draws the outline of the specified ellipse using the specified stroke style.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>The position and radius of the ellipse to draw, in device-independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the ellipse's outline.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't
		/// specified, it defaults to 1.0f. The stroke is centered on the line.
		/// </para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of stroke to apply to the ellipse's outline, or <c>NULL</c> to paint a solid stroke.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The DrawEllipse method doesn't return an error code if it fails. To determine whether a drawing operation (such as
		/// <c>DrawEllipse</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawellipse(constd2d1_ellipse__id2d1brush_float_id2d1strokestyle)
		// void DrawEllipse( const D2D1_ELLIPSE &amp; ellipse, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		new void DrawEllipse(in D2D1_ELLIPSE ellipse, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

		/// <summary>Paints the interior of the specified ellipse.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>The position and radius, in device-independent pixels, of the ellipse to paint.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the interior of the ellipse.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillEllipse) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillellipse(constd2d1_ellipse__id2d1brush) void
		// FillEllipse( const D2D1_ELLIPSE &amp; ellipse, ID2D1Brush *brush );
		[PreserveSig]
		new void FillEllipse(in D2D1_ELLIPSE ellipse, [In] ID2D1Brush brush);

		/// <summary>Draws the outline of the specified geometry using the specified stroke style.</summary>
		/// <param name="geometry">
		/// <para>Type: <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to draw.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the geometry's stroke.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't
		/// specified, it defaults to 1.0f. The stroke is centered on the line.
		/// </para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of stroke to apply to the geometry's outline, or <c>NULL</c> to paint a solid stroke.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawGeometry</c>)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawgeometry void DrawGeometry( ID2D1Geometry
		// *geometry, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		new void DrawGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

		/// <summary>Paints the interior of the specified geometry.</summary>
		/// <param name="geometry">
		/// <para>Type: <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to paint.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the geometry's interior.</para>
		/// </param>
		/// <param name="opacityBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>
		/// The opacity mask to apply to the geometry, or <c>NULL</c> for no opacity mask. If an opacity mask (the opacityBrush
		/// parameter) is specified, brush must be an ID2D1BitmapBrush that has its x- and y-extend modes set to D2D1_EXTEND_MODE_CLAMP. For
		/// more information, see the Remarks section.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If the opacityBrush parameter is not <c>NULL</c>, the alpha value of each pixel of the mapped opacityBrush is used to determine
		/// the resulting opacity of each corresponding pixel of the geometry. Only the alpha value of each color in the brush is used for
		/// this processing; all other color information is ignored.
		/// </para>
		/// <para>
		/// The alpha value specified by the brush is multiplied by the alpha value of the geometry after the geometry has been painted by brush.
		/// </para>
		/// <para>
		/// When this method fails, it does not return an error code. To determine whether a drawing operation (such as <c>FillGeometry</c>)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillgeometry void FillGeometry( ID2D1Geometry
		// *geometry, ID2D1Brush *brush, ID2D1Brush *opacityBrush );
		[PreserveSig]
		new void FillGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, [In] ID2D1Brush? opacityBrush = null);

		/// <summary>Paints the interior of the specified mesh.</summary>
		/// <param name="mesh">
		/// <para>Type: <c>ID2D1Mesh*</c></para>
		/// <para>The mesh to paint.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the mesh.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The current antialias mode of the render target must be D2D1_ANTIALIAS_MODE_ALIASED when <c>FillMesh</c> is called. To change
		/// the render target's antialias mode, use the SetAntialiasMode method.
		/// </para>
		/// <para>
		/// <c>FillMesh</c> does not expect a particular winding order for the triangles in the ID2D1Mesh; both clockwise and
		/// counter-clockwise will work.
		/// </para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>FillMesh</c>) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillmesh void FillMesh( ID2D1Mesh *mesh,
		// ID2D1Brush *brush );
		[PreserveSig]
		new void FillMesh([In] ID2D1Mesh mesh, [In] ID2D1Brush brush);

		/// <summary>
		/// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
		/// </summary>
		/// <param name="opacityMask">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>
		/// The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is multiplied
		/// with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.
		/// </para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the region of the render target specified by destinationRectangle.</para>
		/// </param>
		/// <param name="content">
		/// <para>Type: <c>D2D1_OPACITY_MASK_CONTENT</c></para>
		/// <para>
		/// The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.
		/// </para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, the D2D1_OPACITY_MASK_CONTENT is not required. See the ID2D1DeviceContext::FillOpacityMask
		/// method, which has no <c>D2D1_OPACITY_MASK_CONTENT</c> parameter.
		/// </para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>The region of the render target to paint, in device-independent pixels.</para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>The region of the bitmap to use as the opacity mask, in device-independent pixels.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// For this method to work properly, the render target must be using the D2D1_ANTIALIAS_MODE_ALIASED antialiasing mode. You can set
		/// the antialiasing mode by calling the ID2D1RenderTarget::SetAntialiasMode method.
		/// </para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillOpacityMask) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillopacitymask(id2d1bitmap_id2d1brush_d2d1_opacity_mask_content_constd2d1_rect_f__constd2d1_rect_f_)
		// void FillOpacityMask( ID2D1Bitmap *opacityMask, ID2D1Brush *brush, D2D1_OPACITY_MASK_CONTENT content, const D2D1_RECT_F &amp;
		// destinationRectangle, const D2D1_RECT_F &amp; sourceRectangle );
		[PreserveSig]
		new void FillOpacityMask([In] ID2D1Bitmap opacityMask, [In] ID2D1Brush brush, D2D1_OPACITY_MASK_CONTENT content, [In, Optional] PD2D_RECT_F? destinationRectangle, [In, Optional] PD2D_RECT_F? sourceRectangle);

		/// <summary>Draws the specified bitmap after scaling it to the size of the specified rectangle.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap to render.</para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>
		/// The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is
		/// drawn. If the rectangle is not well-ordered, nothing is drawn, but the render target does not enter an error state.
		/// </para>
		/// </param>
		/// <param name="opacity">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied
		/// against the alpha values of the bitmap's contents.
		/// </para>
		/// </param>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_BITMAP_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.</para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>
		/// The size and position, in device-independent pixels in the bitmap's coordinate space, of the area within the bitmap to draw.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawBitmap) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawbitmap(id2d1bitmap_constd2d1_rect_f__float_d2d1_bitmap_interpolation_mode_constd2d1_rect_f_)
		// void DrawBitmap( ID2D1Bitmap *bitmap, const D2D1_RECT_F &amp; destinationRectangle, FLOAT opacity, D2D1_BITMAP_INTERPOLATION_MODE
		// interpolationMode, const D2D1_RECT_F &amp; sourceRectangle );
		[PreserveSig]
		new void DrawBitmap([In] ID2D1Bitmap bitmap, [In, Optional] PD2D_RECT_F? destinationRectangle, float opacity = 1.0f,
			D2D1_BITMAP_INTERPOLATION_MODE interpolationMode = D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR, [In] PD2D_RECT_F? sourceRectangle = default);

		/// <summary>Draws the specified text using the format information provided by an IDWriteTextFormat object.</summary>
		/// <param name="string">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>A pointer to an array of Unicode characters to draw.</para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of characters in string.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</para>
		/// </param>
		/// <param name="layoutRect">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>The size and position of the area in which the text is drawn.</para>
		/// </param>
		/// <param name="defaultFillBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the text.</para>
		/// </param>
		/// <param name="options">
		/// <para>Type: <c>D2D1_DRAW_TEXT_OPTIONS</c></para>
		/// <para>
		/// A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the
		/// layout rectangle. The default value is D2D1_DRAW_TEXT_OPTIONS_NONE, which indicates that text should be snapped to pixel
		/// boundaries and it should not be clipped to the layout rectangle.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>A value that indicates how glyph metrics are used to measure text when it is formatted. The default value is DWRITE_MEASURING_MODE_NATURAL.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>To create an IDWriteTextFormat object, create an IDWriteFactory and call its CreateTextFormat method.</para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawText) failed, check
		/// the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawtext(constwchar_uint32_idwritetextformat_constd2d1_rect_f__id2d1brush_d2d1_draw_text_options_dwrite_measuring_mode)
		// void DrawText( const WCHAR *string, UINT32 stringLength, IDWriteTextFormat *textFormat, const D2D1_RECT_F &amp; layoutRect,
		// ID2D1Brush *defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options, DWRITE_MEASURING_MODE measuringMode );
		[PreserveSig]
		new void DrawText([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, in D2D_RECT_F layoutRect,
			[In] ID2D1Brush defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE,
			DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL);

		/// <summary>Draws the formatted text described by the specified IDWriteTextLayout object.</summary>
		/// <param name="origin">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>
		/// The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.
		/// </para>
		/// </param>
		/// <param name="textLayout">
		/// <para>Type: <c>IDWriteTextLayout*</c></para>
		/// <para>
		/// The formatted text to draw. Any drawing effects that do not inherit from ID2D1Resource are ignored. If there are drawing effects
		/// that inherit from <c>ID2D1Resource</c> that are not brushes, this method fails and the render target is put in an error state.
		/// </para>
		/// </param>
		/// <param name="defaultFillBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>
		/// The brush used to paint any text in textLayout that does not already have a brush associated with it as a drawing effect
		/// (specified by the IDWriteTextLayout::SetDrawingEffect method).
		/// </para>
		/// </param>
		/// <param name="options">
		/// <para>Type: <c>D2D1_DRAW_TEXT_OPTIONS</c></para>
		/// <para>
		/// A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the
		/// layout rectangle. The default value is D2D1_DRAW_TEXT_OPTIONS_NONE, which indicates that text should be snapped to pixel
		/// boundaries and it should not be clipped to the layout rectangle.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// When drawing the same text repeatedly, using the <c>DrawTextLayout</c> method is more efficient than using the DrawText method
		/// because the text doesn't need to be formatted and the layout processed with each call.
		/// </para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawTextLayout</c>)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawtextlayout void DrawTextLayout(
		// D2D1_POINT_2F origin, IDWriteTextLayout *textLayout, ID2D1Brush *defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options );
		[PreserveSig]
		new void DrawTextLayout(D2D_POINT_2F origin, [In] IDWriteTextLayout textLayout, [In] ID2D1Brush defaultFillBrush,
			D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);

		/// <summary>Draws the specified glyphs.</summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The origin, in device-independent pixels, of the glyphs' baseline.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>The glyphs to render.</para>
		/// </param>
		/// <param name="foregroundBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the specified glyphs.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>A value that indicates how glyph metrics are used to measure text when it is formatted. The default value is DWRITE_MEASURING_MODE_NATURAL.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawGlyphRun</c>)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawglyphrun void DrawGlyphRun( D2D1_POINT_2F
		// baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, ID2D1Brush *foregroundBrush, DWRITE_MEASURING_MODE measuringMode );
		[PreserveSig]
		new void DrawGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, [In] ID2D1Brush foregroundBrush,
			DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL);

		/// <summary>
		/// Applies the specified transform to the render target, replacing the existing transformation. All subsequent drawing operations
		/// occur in the transformed space.
		/// </summary>
		/// <param name="transform">
		/// <para>Type: <c>const D2D1_MATRIX_3X2_F</c></para>
		/// <para>The transform to apply to the render target.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settransform(constd2d1_matrix_3x2_f_) void
		// SetTransform( const D2D1_MATRIX_3X2_F &amp; transform );
		[PreserveSig]
		new void SetTransform(in D2D_MATRIX_3X2_F transform);

		/// <summary>Gets the current transform of the render target.</summary>
		/// <param name="transform">
		/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
		/// <para>When this returns, contains the current transform of the render target. This parameter is passed uninitialized.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettransform void GetTransform(
		// D2D1_MATRIX_3X2_F *transform );
		[PreserveSig]
		new void GetTransform(out D2D_MATRIX_3X2_F transform);

		/// <summary>
		/// Sets the antialiasing mode of the render target. The antialiasing mode applies to all subsequent drawing operations, excluding
		/// text and glyph drawing operations.
		/// </summary>
		/// <param name="antialiasMode">
		/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>The antialiasing mode for future drawing operations.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>To specify the antialiasing mode for text and glyph operations, use the SetTextAntialiasMode method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-setantialiasmode void SetAntialiasMode(
		// D2D1_ANTIALIAS_MODE antialiasMode );
		[PreserveSig]
		new void SetAntialiasMode(D2D1_ANTIALIAS_MODE antialiasMode);

		/// <summary>Retrieves the current antialiasing mode for nontext drawing operations.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>The current antialiasing mode for nontext drawing operations.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getantialiasmode D2D1_ANTIALIAS_MODE GetAntialiasMode();
		[PreserveSig]
		new D2D1_ANTIALIAS_MODE GetAntialiasMode();

		/// <summary>Specifies the antialiasing mode to use for subsequent text and glyph drawing operations.</summary>
		/// <param name="textAntialiasMode">
		/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
		/// <para>The antialiasing mode to use for subsequent text and glyph drawing operations.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settextantialiasmode void SetTextAntialiasMode(
		// D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode );
		[PreserveSig]
		new void SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode);

		/// <summary>Gets the current antialiasing mode for text and glyph drawing operations.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
		/// <para>The current antialiasing mode for text and glyph drawing operations.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettextantialiasmode D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();
		[PreserveSig]
		new D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();

		/// <summary>Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.</summary>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>
		/// The text rendering options to be applied to all subsequent text and glyph drawing operations; <c>NULL</c> to clear current text
		/// rendering options.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// If the settings specified by textRenderingParams are incompatible with the render target's text antialiasing mode (specified by
		/// SetTextAntialiasMode), subsequent text and glyph drawing operations will fail and put the render target into an error state.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settextrenderingparams void
		// SetTextRenderingParams( IDWriteRenderingParams *textRenderingParams );
		[PreserveSig]
		new void SetTextRenderingParams([In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Retrieves the render target's current text rendering options.</summary>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>
		/// When this method returns, textRenderingParamscontains the address of a pointer to the render target's current text rendering options.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// If the settings specified by textRenderingParams are incompatible with the render target's text antialiasing mode (specified by
		/// SetTextAntialiasMode), subsequent text and glyph drawing operations will fail and put the render target into an error state.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettextrenderingparams void
		// GetTextRenderingParams( IDWriteRenderingParams **textRenderingParams );
		[PreserveSig]
		new void GetTextRenderingParams(out IDWriteRenderingParams textRenderingParams);

		/// <summary>Specifies a label for subsequent drawing operations.</summary>
		/// <param name="tag1">
		/// <para>Type: <c>ulong</c></para>
		/// <para>A label to apply to subsequent drawing operations.</para>
		/// </param>
		/// <param name="tag2">
		/// <para>Type: <c>ulong</c></para>
		/// <para>A label to apply to subsequent drawing operations.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The labels specified by this method are printed by debug error messages. If no tag is set, the default value for each tag is 0.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settags void SetTags( ulong tag1, ulong tag2 );
		[PreserveSig]
		new void SetTags(ulong tag1, ulong tag2);

		/// <summary>Gets the label for subsequent drawing operations.</summary>
		/// <param name="tag1">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the first label for subsequent drawing operations. This parameter is passed uninitialized. If
		/// <c>NULL</c> is specified, no value is retrieved for this parameter.
		/// </para>
		/// </param>
		/// <param name="tag2">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the second label for subsequent drawing operations. This parameter is passed uninitialized.
		/// If <c>NULL</c> is specified, no value is retrieved for this parameter.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the same address is passed for both parameters, both parameters receive the value of the second tag.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettags void GetTags( D2D1_TAG *tag1, D2D1_TAG
		// *tag2 );
		[PreserveSig]
		new void GetTags(out ulong tag1, out ulong tag2);

		/// <summary>
		/// Adds the specified layer to the render target so that it receives all subsequent drawing operations until PopLayer is called.
		/// </summary>
		/// <param name="layerParameters">
		/// <para>Type: <c>const D2D1_LAYER_PARAMETERS</c></para>
		/// <para>The content bounds, geometric mask, opacity, opacity mask, and antialiasing options for the layer.</para>
		/// </param>
		/// <param name="layer">
		/// <para>Type: <c>ID2D1Layer*</c></para>
		/// <para>The layer that receives subsequent drawing operations.</para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, this parameter is optional. If a layer is not specified, Direct2D manages the layer
		/// resource automatically.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The <c>PushLayer</c> method allows a caller to begin redirecting rendering to a layer. All rendering operations are valid in a
		/// layer. The location of the layer is affected by the world transform set on the render target.
		/// </para>
		/// <para>
		/// Each PushLayer must have a matching PopLayer call. If there are more <c>PopLayer</c> calls than <c>PushLayer</c> calls, the
		/// render target is placed into an error state. If Flush is called before all outstanding layers are popped, the render target is
		/// placed into an error state, and an error is returned. The error state can be cleared by a call to EndDraw.
		/// </para>
		/// <para>
		/// A particular ID2D1Layer resource can be active only at one time. In other words, you cannot call a <c>PushLayer</c> method, and
		/// then immediately follow with another <c>PushLayer</c> method with the same layer resource. Instead, you must call the second
		/// <c>PushLayer</c> method with different layer resources.
		/// </para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as PushLayer) failed, check
		/// the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-pushlayer(constd2d1_layer_parameters__id2d1layer)
		// void PushLayer( const D2D1_LAYER_PARAMETERS &amp; layerParameters, ID2D1Layer *layer );
		[PreserveSig]
		new void PushLayer(in D2D1_LAYER_PARAMETERS layerParameters, [In, Optional] ID2D1Layer? layer);

		/// <summary>Stops redirecting drawing operations to the layer that is specified by the last PushLayer call.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A <c>PopLayer</c> must match a previous PushLayer call.</para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>PopLayer</c>) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-poplayer void PopLayer();
		[PreserveSig]
		new void PopLayer();

		/// <summary>Executes all pending drawing commands.</summary>
		/// <param name="tag1">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tag2">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code and sets tag1 and tag2 to the
		/// tags that were active when the error occurred. If no error occurred, this method sets the error tag state to be (0,0).
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This command does not flush the Direct3D device context that is associated with the render target.</para>
		/// <para>Calling this method resets the error state of the render target.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-flush HRESULT Flush( D2D1_TAG *tag1, D2D1_TAG
		// *tag2 );
		new void Flush(out ulong tag1, out ulong tag2);

		/// <summary>Saves the current drawing state to the specified ID2D1DrawingStateBlock.</summary>
		/// <param name="drawingStateBlock">
		/// <para>Type: <c>ID2D1DrawingStateBlock*</c></para>
		/// <para>
		/// When this method returns, contains the current drawing state of the render target. This parameter must be initialized before
		/// passing it to the method.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-savedrawingstate void SaveDrawingState(
		// ID2D1DrawingStateBlock *drawingStateBlock );
		[PreserveSig]
		new void SaveDrawingState([In, Out] ID2D1DrawingStateBlock drawingStateBlock);

		/// <summary>Sets the render target's drawing state to that of the specified ID2D1DrawingStateBlock.</summary>
		/// <param name="drawingStateBlock">
		/// <para>Type: <c>ID2D1DrawingStateBlock*</c></para>
		/// <para>The new drawing state of the render target.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-restoredrawingstate void RestoreDrawingState(
		// ID2D1DrawingStateBlock *drawingStateBlock );
		[PreserveSig]
		new void RestoreDrawingState([In] ID2D1DrawingStateBlock drawingStateBlock);

		/// <summary>Specifies a rectangle to which all subsequent drawing operations are clipped.</summary>
		/// <param name="clipRect">
		/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
		/// <para>The size and position of the clipping area, in device-independent pixels.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: [in] <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>
		/// The antialiasing mode that is used to draw the edges of clip rects that have subpixel boundaries, and to blend the clip with the
		/// scene contents. The blending is performed once when the PopAxisAlignedClip method is called, and does not apply to each
		/// primitive within the layer.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The clipRect is transformed by the current world transform set on the render target. After the transform is applied to the
		/// clipRect that is passed in, the axis-aligned bounding box for the clipRect is computed. For efficiency, the contents are clipped
		/// to this axis-aligned bounding box and not to the original clipRect that is passed in.
		/// </para>
		/// <para>
		/// The following diagrams show how a rotation transform is applied to the render target, the resulting clipRect, and a calculated
		/// axis-aligned bounding box.
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Assume the rectangle in the following illustration is a render target that is aligned to the screen pixels.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Apply a rotation transform to the render target. In the following illustration, the black rectangle represents the original
		/// render target and the red dashed rectangle represents the transformed render target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// After calling <c>PushAxisAlignedClip</c>, the rotation transform is applied to the clipRect. In the following illustration, the
		/// blue rectangle represents the transformed clipRect.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The axis-aligned bounding box is calculated. The green dashed rectangle represents the bounding box in the following
		/// illustration. All contents are clipped to this axis-aligned bounding box.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> If rendering operations fail or if PopAxisAlignedClip is not called, clip rects may cause some artifacts on the
		/// render target. <c>PopAxisAlignedClip</c> can be considered a drawing operation that is designed to fix the borders of a clipping
		/// region. Without this call, the borders of a clipped area may be not antialiased or otherwise corrected.
		/// </para>
		/// <para>
		/// The <c>PushAxisAlignedClip</c> and PopAxisAlignedClip must match. Otherwise, the error state is set. For the render target to
		/// continue receiving new commands, you can call Flush to clear the error.
		/// </para>
		/// <para>
		/// A <c>PushAxisAlignedClip</c> and PopAxisAlignedClip pair can occur around or within a PushLayer and PopLayer, but cannot
		/// overlap. For example, the sequence of <c>PushAxisAlignedClip</c>, PushLayer, PopLayer, <c>PopAxisAlignedClip</c> is valid, but
		/// the sequence of <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopAxisAlignedClip</c>, <c>PopLayer</c> is invalid.
		/// </para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as PushAxisAlignedClip)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-pushaxisalignedclip(constd2d1_rect_f__d2d1_antialias_mode)
		// void PushAxisAlignedClip( const D2D1_RECT_F &amp; clipRect, D2D1_ANTIALIAS_MODE antialiasMode );
		[PreserveSig]
		new void PushAxisAlignedClip(in D2D_RECT_F clipRect, D2D1_ANTIALIAS_MODE antialiasMode);

		/// <summary>
		/// Removes the last axis-aligned clip from the render target. After this method is called, the clip is no longer applied to
		/// subsequent drawing operations.
		/// </summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// A PushAxisAlignedClip/ <c>PopAxisAlignedClip</c> pair can occur around or within a PushLayer/PopLayer pair, but may not overlap.
		/// For example, a <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopLayer</c>, <c>PopAxisAlignedClip</c> sequence is valid, but a
		/// <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopAxisAlignedClip</c>, <c>PopLayer</c> sequence is not.
		/// </para>
		/// <para><c>PopAxisAlignedClip</c> must be called once for every call to PushAxisAlignedClip.</para>
		/// <para>For an example, see How to Clip with an Axis-Aligned Clip Rectangle.</para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
		/// <c>PopAxisAlignedClip</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-popaxisalignedclip void PopAxisAlignedClip();
		[PreserveSig]
		new void PopAxisAlignedClip();

		/// <summary>Clears the drawing area to the specified color.</summary>
		/// <param name="clearColor">
		/// <para>Type: [in] <c>const D2D1_COLOR_F &amp;</c></para>
		/// <para>The color to which the drawing area is cleared.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Direct2D interprets the clearColor as straight alpha (not premultiplied). If the render target's alpha mode is
		/// D2D1_ALPHA_MODE_IGNORE, the alpha channel of clearColor is ignored and replaced with 1.0f (fully opaque).
		/// </para>
		/// <para>
		/// If the render target has an active clip (specified by PushAxisAlignedClip), the clear command is applied only to the area within
		/// the clip region.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-clear(constd2d1_color_f_) void Clear( const
		// D2D1_COLOR_F &amp; clearColor );
		[PreserveSig]
		new void Clear([In, Optional] StructPointer<D2D1_COLOR_F> clearColor);

		/// <summary>Initiates drawing on this render target.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Drawing operations can only be issued between a <c>BeginDraw</c> and EndDraw call.</para>
		/// <para>
		/// BeginDraw and EndDraw are used to indicate that a render target is in use by the Direct2D system. Different implementations of
		/// ID2D1RenderTarget might behave differently when <c>BeginDraw</c> is called. An ID2D1BitmapRenderTarget may be locked between
		/// <c>BeginDraw</c>/EndDraw calls, a DXGI surface render target might be acquired on <c>BeginDraw</c> and released on
		/// <c>EndDraw</c>, while an ID2D1HwndRenderTarget may begin batching at <c>BeginDraw</c> and may present on <c>EndDraw</c>, for example.
		/// </para>
		/// <para>
		/// The BeginDraw method must be called before rendering operations can be called, though state-setting and state-retrieval
		/// operations can be performed even outside of <c>BeginDraw</c>/EndDraw.
		/// </para>
		/// <para>
		/// After <c>BeginDraw</c> is called, a render target will normally build up a batch of rendering commands, but defer processing of
		/// these commands until either an internal buffer is full, the Flush method is called, or until EndDraw is called. The
		/// <c>EndDraw</c> method causes any batched drawing operations to complete, and then returns an HRESULT indicating the success of
		/// the operations and, optionally, the tag state of the render target at the time the error occurred. The <c>EndDraw</c> method
		/// always succeeds: it should not be called twice even if a previous <c>EndDraw</c> resulted in a failing HRESULT.
		/// </para>
		/// <para>
		/// If EndDraw is called without a matched call to <c>BeginDraw</c>, it returns an error indicating that <c>BeginDraw</c> must be
		/// called before <c>EndDraw</c>.
		/// </para>
		/// <para>
		/// Calling <c>BeginDraw</c> twice on a render target puts the target into an error state where nothing further is drawn, and
		/// returns an appropriate HRESULT and error information when <c>EndDraw</c> is called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-begindraw void BeginDraw();
		[PreserveSig]
		new void BeginDraw();

		/// <summary>Ends drawing operations on the render target and indicates the current error state and associated tags.</summary>
		/// <param name="tag1">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tag2">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code and sets tag1 and tag2 to the
		/// tags that were active when the error occurred.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>Drawing operations can only be issued between a BeginDraw and <c>EndDraw</c> call.</para>
		/// <para>
		/// BeginDraw and <c>EndDraw</c> are use to indicate that a render target is in use by the Direct2D system. Different
		/// implementations of ID2D1RenderTarget might behave differently when <c>BeginDraw</c> is called. An ID2D1BitmapRenderTarget may be
		/// locked between <c>BeginDraw</c>/ <c>EndDraw</c> calls, a DXGI surface render target might be acquired on <c>BeginDraw</c> and
		/// released on <c>EndDraw</c>, while an ID2D1HwndRenderTarget may begin batching at <c>BeginDraw</c> and may present on
		/// <c>EndDraw</c>, for example.
		/// </para>
		/// <para>
		/// The BeginDraw method must be called before rendering operations can be called, though state-setting and state-retrieval
		/// operations can be performed even outside of <c>BeginDraw</c>/ <c>EndDraw</c>.
		/// </para>
		/// <para>
		/// After BeginDraw is called, a render target will normally build up a batch of rendering commands, but defer processing of these
		/// commands until either an internal buffer is full, the Flush method is called, or until <c>EndDraw</c> is called. The
		/// <c>EndDraw</c> method causes any batched drawing operations to complete, and then returns an <c>HRESULT</c> indicating the
		/// success of the operations and, optionally, the tag state of the render target at the time the error occurred. The <c>EndDraw</c>
		/// method always succeeds: it should not be called twice even if a previous <c>EndDraw</c> resulted in a failing <c>HRESULT</c>.
		/// </para>
		/// <para>
		/// If <c>EndDraw</c> is called without a matched call to BeginDraw, it returns an error indicating that <c>BeginDraw</c> must be
		/// called before <c>EndDraw</c>.
		/// </para>
		/// <para>
		/// Calling <c>BeginDraw</c> twice on a render target puts the target into an error state where nothing further is drawn, and
		/// returns an appropriate <c>HRESULT</c> and error information when <c>EndDraw</c> is called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-enddraw HRESULT EndDraw( D2D1_TAG *tag1,
		// D2D1_TAG *tag2 );
		[PreserveSig]
		new HRESULT EndDraw(out ulong tag1, out ulong tag2);

		/// <summary>Retrieves the pixel format and alpha mode of the render target.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_PIXEL_FORMAT</c></para>
		/// <para>The pixel format and alpha mode of the render target.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelformat D2D1_PIXEL_FORMAT GetPixelFormat();
		[PreserveSig]
		new void GetPixelFormat(out D2D1_PIXEL_FORMAT format);

		/// <summary>Sets the dots per inch (DPI) of the render target.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value greater than or equal to zero that specifies the horizontal DPI of the render target.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value greater than or equal to zero that specifies the vertical DPI of the render target.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method specifies the mapping from pixel space to device-independent space for the render target. If both dpiX and dpiY are
		/// 0, the factory-read system DPI is chosen. If one parameter is zero and the other unspecified, the DPI is not changed.
		/// </para>
		/// <para>
		/// For ID2D1HwndRenderTarget, the DPI defaults to the most recently factory-read system DPI. The default value for all other render
		/// targets is 96 DPI.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-setdpi void SetDpi( FLOAT dpiX, FLOAT dpiY );
		[PreserveSig]
		new void SetDpi(float dpiX, float dpiY);

		/// <summary>Return the render target's dots per inch (DPI).</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the horizontal DPI of the render target. This parameter is passed uninitialized.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the vertical DPI of the render target. This parameter is passed uninitialized.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This method indicates the mapping from pixel space to device-independent space for the render target.</para>
		/// <para>
		/// For ID2D1HwndRenderTarget, the DPI defaults to the most recently factory-read system DPI. The default value for all other render
		/// targets is 96 DPI.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getdpi void GetDpi( FLOAT *dpiX, FLOAT
		// *dpiY );
		[PreserveSig]
		new void GetDpi(out float dpiX, out float dpiY);

		/// <summary>Returns the size of the render target in device-independent pixels.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_SIZE_F</c></b></para>
		/// <para>The current size of the render target in device-independent pixels.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getsize D2D1_SIZE_F GetSize();
		[PreserveSig]
		new void GetSize(out D2D_SIZE_F size);

		/// <summary>Returns the size of the render target in device pixels.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_SIZE_U</c></para>
		/// <para>The size of the render target in device pixels.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelsize D2D1_SIZE_U GetPixelSize();
		[PreserveSig]
		new void GetPixelSize(out D2D_SIZE_U size);

		/// <summary>Gets the maximum size, in device-dependent units (pixels), of any one bitmap dimension supported by the render target.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum size, in pixels, of any one bitmap dimension supported by the render target.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method returns the maximum texture size of the Direct3D device.</para>
		/// <para>
		/// <c>Note</c> The software renderer and WARP devices return the value of 16 megapixels (16*1024*1024). You can create a Direct2D
		/// texture that is this size, but not a Direct3D texture that is this size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getmaximumbitmapsize UINT32 GetMaximumBitmapSize();
		[PreserveSig]
		new uint GetMaximumBitmapSize();

		/// <summary>Indicates whether the render target supports the specified properties.</summary>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>The render target properties to test.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the specified render target properties are supported by this render target; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>This method does not evaluate the DPI settings specified by the renderTargetProperties parameter.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-issupported(constd2d1_render_target_properties_)
		// BOOL IsSupported( const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsSupported(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>
		/// Creates a bitmap that can be used as a target surface, for reading back to the CPU, or as a source for the DrawBitmap and
		/// ID2D1BitmapBrush APIs. In addition, color context information can be passed to the bitmap.
		/// </summary>
		/// <param name="size">
		/// <para>Type: <c>D2D1_SIZE_U</c></para>
		/// <para>The pixel size of the bitmap to be created.</para>
		/// </param>
		/// <param name="sourceData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>The initial data that will be loaded into the bitmap.</para>
		/// </param>
		/// <param name="pitch">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The pitch of the source data, if specified.</para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: <c>const D2D1_BITMAP_PROPERTIES1</c></para>
		/// <para>The properties of the bitmap to be created.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Bitmap1**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new bitmap object.</para>
		/// </returns>
		/// <remarks>The new bitmap can be used as a target for SetTarget if it is created with D2D1_BITMAP_OPTIONS_TARGET.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createbitmap(d2d1_size_u_constvoid_uint32_constd2d1_bitmap_properties1_id2d1bitmap1)
		// HRESULT CreateBitmap( D2D1_SIZE_U size, const void *sourceData, UINT32 pitch, const D2D1_BITMAP_PROPERTIES1
		// *bitmapProperties, ID2D1Bitmap1 **bitmap );
		new ID2D1Bitmap1 CreateBitmap(D2D_SIZE_U size, [In, Optional] IntPtr sourceData, uint pitch, in D2D1_BITMAP_PROPERTIES1 bitmapProperties);

		/// <summary>Creates an ID2D1Bitmap by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="wicBitmapSource">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The WIC bitmap to copy.</para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: <c>const D2D1_BITMAP_PROPERTIES1</c></para>
		/// <para>The properties of the bitmap to be created.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Bitmap1**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to the new bitmap. This parameter is passed uninitialized.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createbitmapfromwicbitmap(iwicbitmapsource_id2d1bitmap1)
		// HRESULT CreateBitmapFromWicBitmap( IWICBitmapSource *wicBitmapSource, ID2D1Bitmap1 **bitmap );
		new ID2D1Bitmap1 CreateBitmap1FromWicBitmap(IWICBitmapSource wicBitmapSource, [In, Optional] StructPointer<D2D1_BITMAP_PROPERTIES> bitmapProperties);

		/// <summary>Creates a color context.</summary>
		/// <param name="space">
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>The space of color context to create.</para>
		/// </param>
		/// <param name="profile">
		/// <para>Type: <c>const BYTE*</c></para>
		/// <para>
		/// A buffer containing the ICC profile bytes used to initialize the color context when space is D2D1_COLOR_SPACE_CUSTOM. For other
		/// types, the parameter is ignored and should be set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="profileSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size in bytes of Profile.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1ColorContext**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context object.</para>
		/// </returns>
		/// <remarks>
		/// <para>The new color context can be used in D2D1_BITMAP_PROPERTIES1 to initialize the color context of a created bitmap.</para>
		/// <para>
		/// When space is D2D1_COLOR_SPACE_CUSTOM, profile and profileSize must be specified. Otherwise, these parameters should be set to
		/// <c>NULL</c> and zero respectively. When the space is D2D1_COLOR_SPACE_CUSTOM, the model field of the profile header is inspected
		/// to determine if this profile is sRGB or scRGB and the color space is updated respectively. Otherwise the space remains custom.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createcolorcontext HRESULT
		// CreateColorContext( D2D1_COLOR_SPACE space, const BYTE *profile, UINT32 profileSize, ID2D1ColorContext **colorContext );
		new ID2D1ColorContext CreateColorContext(D2D1_COLOR_SPACE space, [In, Optional] IntPtr profile, int profileSize);

		/// <summary>
		/// Creates a color context by loading it from the specified filename. The profile bytes are the contents of the file specified by Filename.
		/// </summary>
		/// <param name="filename">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>The path to the file containing the profile bytes to initialize the color context with.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1ColorContext**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context.</para>
		/// </returns>
		/// <remarks>
		/// The new color context can be used in D2D1_BITMAP_PROPERTIES1 to initialize the color context of a created bitmap. The model
		/// field of the profile header is inspected to determine whether this profile is sRGB or scRGB and the color space is updated
		/// respectively. Otherwise the space is custom.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createcolorcontextfromfilename HRESULT
		// CreateColorContextFromFilename( PCWSTR filename, ID2D1ColorContext **colorContext );
		new ID2D1ColorContext CreateColorContextFromFilename([MarshalAs(UnmanagedType.LPWStr)] string filename);

		/// <summary>
		/// Creates a color context from an IWICColorContext. The D2D1ColorContext space of the resulting context varies, see Remarks for
		/// more info.
		/// </summary>
		/// <param name="wicColorContext">
		/// <para>Type: <c>IWICColorContext*</c></para>
		/// <para>The IWICColorContext used to initialize the color context.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1ColorContext**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context.</para>
		/// </returns>
		/// <remarks>
		/// The new color context can be used in D2D1_BITMAP_PROPERTIES1 to initialize the color context of a created bitmap. The model
		/// field of the profile header is inspected to determine whether this profile is sRGB or scRGB and the color space is updated
		/// respectively. Otherwise the space is custom.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createcolorcontextfromwiccolorcontext
		// HRESULT CreateColorContextFromWicColorContext( IWICColorContext *wicColorContext, ID2D1ColorContext **colorContext );
		new ID2D1ColorContext CreateColorContextFromWicColorContext(IWICColorContext wicColorContext);

		/// <summary>
		/// Creates a bitmap from a DXGI surface that can be set as a target surface or have additional color context information specified.
		/// </summary>
		/// <param name="surface">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>The DXGI surface from which the bitmap can be created.</para>
		/// <para>
		/// <c>Note</c> The DXGI surface must have been created from the same Direct3D device that the Direct2D device context is associated with.
		/// </para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: <c>const D2D1_BITMAP_PROPERTIES1*</c></para>
		/// <para>The bitmap properties specified in addition to the surface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Bitmap1**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new bitmap object.</para>
		/// </returns>
		/// <remarks>
		/// <para>If the bitmap properties are not specified, the following information is assumed:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The bitmap DPI is 96.</term>
		/// </item>
		/// <item>
		/// <term>The pixel format matches that of the surface.</term>
		/// </item>
		/// <item>
		/// <term>The returned bitmap will inherit the bind flags of the DXGI surface.</term>
		/// </item>
		/// <item>
		/// <term>The color context is unknown.</term>
		/// </item>
		/// <item>
		/// <term>The alpha mode of the bitmap will be premultiplied (common case) or straight (A8).</term>
		/// </item>
		/// </list>
		/// <para>If the bitmap properties are specified, the bitmap properties will be used as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The bitmap DPI will be specified by the bitmap properties.</term>
		/// </item>
		/// <item>
		/// <term>If both dpiX and dpiY are 0, the bitmap DPI will be 96.</term>
		/// </item>
		/// <item>
		/// <term>The pixel format must be compatible with the shader resource view or render target view of the surface.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The bitmap options must be compatible with the bind flags of the DXGI surface. However, they may be a subset. This will
		/// influence what resource views are created by the bitmap.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The color context information will be used from the bitmap properties, if specified.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createbitmapfromdxgisurface(idxgisurface_constd2d1_bitmap_properties1__id2d1bitmap1)
		// HRESULT CreateBitmapFromDxgiSurface( IDXGISurface *surface, const D2D1_BITMAP_PROPERTIES1 &amp; bitmapProperties, ID2D1Bitmap1
		// **bitmap );
		new ID2D1Bitmap1 CreateBitmapFromDxgiSurface(IDXGISurface surface, [In, Optional] StructPointer<D2D1_BITMAP_PROPERTIES> bitmapProperties);

		/// <summary>Creates an effect for the specified class ID.</summary>
		/// <param name="effectId">
		/// <para>Type: <c>REFCLSID</c></para>
		/// <para>The class ID of the effect to create. See Built-in Effects for a list of effect IDs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Effect**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new effect.</para>
		/// </returns>
		/// <remarks>
		/// If the created effect is a custom effect that is implemented in a DLL, this doesn't increment the reference count for that DLL.
		/// If the application deletes an effect while that effect is loaded, the resulting behavior is unpredictable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createeffect HRESULT CreateEffect(
		// REFCLSID effectId, ID2D1Effect **effect );
		new ID2D1Effect CreateEffect(in Guid effectId);

		/// <summary>
		/// Creates a gradient stop collection, enabling the gradient to contain color channels with values outside of [0,1] and also
		/// enabling rendering to a high-color render target with interpolation in sRGB space.
		/// </summary>
		/// <param name="straightAlphaGradientStops">
		/// <para>Type: <c>const D2D1_GRADIENT_STOP*</c></para>
		/// <para>An array of color values and offsets.</para>
		/// </param>
		/// <param name="straightAlphaGradientStopsCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the gradientStops array.</para>
		/// </param>
		/// <param name="preInterpolationSpace">
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>Specifies both the input color space and the space in which the color interpolation occurs.</para>
		/// </param>
		/// <param name="postInterpolationSpace">
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>The color space that colors will be converted to after interpolation occurs.</para>
		/// </param>
		/// <param name="bufferPrecision">
		/// <para>Type: <c>D2D1_BUFFER_PRECISION</c></para>
		/// <para>The precision of the texture used to hold interpolated values.</para>
		/// <para>
		/// <c>Note</c> This method will fail if the underlying Direct3D device does not support the requested buffer precision. Use
		/// ID2D1DeviceContext::IsBufferPrecisionSupported to determine what is supported.
		/// </para>
		/// </param>
		/// <param name="extendMode">
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>Defines how colors outside of the range defined by the stop collection are determined.</para>
		/// </param>
		/// <param name="colorInterpolationMode">
		/// <para>Type: <c>D2D1_COLOR_INTERPOLATION_MODE</c></para>
		/// <para>
		/// Defines how colors are interpolated. D2D1_COLOR_INTERPOLATION_MODE_PREMULTIPLIED is the default, see Remarks for more info.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1GradientStopCollection1**</c></para>
		/// <para>The new gradient stop collection.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method linearly interpolates between the color stops. An optional color space conversion is applied post-interpolation.
		/// Whether and how this gamma conversion is applied is determined by the pre- and post-interpolation. This method will fail if the
		/// device context does not support the requested buffer precision.
		/// </para>
		/// <para>In order to get the desired result, you need to ensure that the inputs are specified in the correct color space.</para>
		/// <para>
		/// You must always specify colors in straight alpha, regardless of interpolation mode being premultiplied or straight. The
		/// interpolation mode only affects the interpolated values. Likewise, the stops returned by
		/// ID2D1GradientStopCollection::GetGradientStops will always have straight alpha.
		/// </para>
		/// <para>
		/// If you specify D2D1_COLOR_INTERPOLATION_MODE_PREMULTIPLIED, then all stops are premultiplied before interpolation, and then
		/// un-premultiplied before color conversion.
		/// </para>
		/// <para>Starting with Windows 8, the interpolation behavior of this method has changed.</para>
		/// <para>The table here shows the behavior in Windows 7 and earlier.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Gamma</term>
		/// <term>Before Interpolation Behavior</term>
		/// <term>After Interpolation Behavior</term>
		/// <term>GetColorInteroplationGamma (output color space)</term>
		/// </listheader>
		/// <item>
		/// <term>1.0</term>
		/// <term>Clamps the inputs and then converts from sRGB to scRGB.</term>
		/// <term>Converts from scRGB to sRGB post-interpolation.</term>
		/// <term>1.0</term>
		/// </item>
		/// <item>
		/// <term>2.2</term>
		/// <term>Clamps the inputs.</term>
		/// <term>No Operation</term>
		/// <term>2.2</term>
		/// </item>
		/// </list>
		/// <para>The table here shows the behavior in Windows 8 and later.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Gamma</term>
		/// <term>Before Interpolation Behavior</term>
		/// <term>After Interpolation Behavior</term>
		/// <term>GetColorInteroplationGamma (output color space)</term>
		/// </listheader>
		/// <item>
		/// <term>sRGB to scRGB</term>
		/// <term>No Operation</term>
		/// <term>Clamps the outputs and then converts from sRGB to scRGB.</term>
		/// <term>1.0</term>
		/// </item>
		/// <item>
		/// <term>scRGB to sRGB</term>
		/// <term>No Operation</term>
		/// <term>Clamps the outputs and then converts from sRGB to scRGB.</term>
		/// <term>2.2</term>
		/// </item>
		/// <item>
		/// <term>sRGB to sRGB</term>
		/// <term>No Operation</term>
		/// <term>No Operation</term>
		/// <term>2.2</term>
		/// </item>
		/// <item>
		/// <term>scRGB to scRGB</term>
		/// <term>No Operation</term>
		/// <term>No Operation</term>
		/// <term>1.0</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-creategradientstopcollection HRESULT
		// CreateGradientStopCollection( const D2D1_GRADIENT_STOP *straightAlphaGradientStops, UINT32 straightAlphaGradientStopsCount,
		// D2D1_COLOR_SPACE preInterpolationSpace, D2D1_COLOR_SPACE postInterpolationSpace, D2D1_BUFFER_PRECISION bufferPrecision,
		// D2D1_EXTEND_MODE extendMode, D2D1_COLOR_INTERPOLATION_MODE colorInterpolationMode, ID2D1GradientStopCollection1
		// **gradientStopCollection1 );
		new ID2D1GradientStopCollection1 CreateGradientStopCollection([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_GRADIENT_STOP[] straightAlphaGradientStops, uint straightAlphaGradientStopsCount,
			D2D1_COLOR_SPACE preInterpolationSpace, D2D1_COLOR_SPACE postInterpolationSpace, D2D1_BUFFER_PRECISION bufferPrecision, D2D1_EXTEND_MODE extendMode, D2D1_COLOR_INTERPOLATION_MODE colorInterpolationMode);

		/// <summary>Creates an image brush. The input image can be any type of image, including a bitmap, effect, or a command list.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The image to be used as a source for the image brush.</para>
		/// </param>
		/// <param name="imageBrushProperties">
		/// <para>Type: <c>const D2D1_IMAGE_BRUSH_PROPERTIES</c></para>
		/// <para>The properties specific to an image brush.</para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: <c>const D2D1_BRUSH_PROPERTIES</c></para>
		/// <para>Properties common to all brushes.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1ImageBrush**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the input rectangles.</para>
		/// </returns>
		/// <remarks>
		/// <para>The image brush can be used to fill an arbitrary geometry, an opacity mask or text.</para>
		/// <para>This sample illustrates drawing a rectangle with an image brush.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createimagebrush(id2d1image_constd2d1_image_brush_properties__constd2d1_brush_properties__id2d1imagebrush)
		// HRESULT CreateImageBrush( ID2D1Image *image, const D2D1_IMAGE_BRUSH_PROPERTIES &amp; imageBrushProperties, const
		// D2D1_BRUSH_PROPERTIES &amp; brushProperties, ID2D1ImageBrush **imageBrush );
		new ID2D1ImageBrush CreateImageBrush([Optional] ID2D1Image? image, in D2D1_IMAGE_BRUSH_PROPERTIES imageBrushProperties, [In, Optional] StructPointer<D2D1_BRUSH_PROPERTIES> brushProperties);

		/// <summary>Creates a bitmap brush, the input image is a Direct2D bitmap object.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap to use as the brush.</para>
		/// </param>
		/// <param name="bitmapBrushProperties">
		/// <para>Type: <c>D2D1_BITMAP_BRUSH_PROPERTIES1*</c></para>
		/// <para>A bitmap brush properties structure.</para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: <c>D2D1_BRUSH_PROPERTIES*</c></para>
		/// <para>A brush properties structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1BitmapBrush1**</c></para>
		/// <para>The address of the newly created bitmap brush object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createbitmapbrush%28id2d1bitmap_constd2d1_bitmap_brush_properties1_constd2d1_brush_properties_id2d1bitmapbrush1%29
		// HRESULT CreateBitmapBrush( ID2D1Bitmap *bitmap, const D2D1_BITMAP_BRUSH_PROPERTIES1 *bitmapBrushProperties, const
		// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1BitmapBrush1 **bitmapBrush );
		new ID2D1BitmapBrush1 CreateBitmapBrush1([Optional] ID2D1Bitmap? bitmap, [In, Optional] StructPointer<D2D1_BITMAP_BRUSH_PROPERTIES> bitmapBrushProperties, [In, Optional] StructPointer<D2D1_BRUSH_PROPERTIES> brushProperties);

		/// <summary>Creates a ID2D1CommandList object.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1CommandList**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a command list.</para>
		/// </returns>
		/// <remarks>
		/// A ID2D1CommandList can store Direct2D commands to be displayed later through ID2D1DeviceContext::DrawImage or through an image brush.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createcommandlist HRESULT
		// CreateCommandList( ID2D1CommandList **commandList );
		new ID2D1CommandList CreateCommandList();

		/// <summary>
		/// Indicates whether the format is supported by the device context. The formats supported are usually determined by the underlying hardware.
		/// </summary>
		/// <param name="format">
		/// <para>Type: <c>format</c></para>
		/// <para>The DXGI format to check.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if the format is supported. Returns FALSE if the format is not supported.</para>
		/// </returns>
		/// <remarks>
		/// <para>You can use supported formats in the D2D1_PIXEL_FORMAT structure to create bitmaps and render targets.</para>
		/// <para>Direct2D doesn't support all DXGI formats, even though they may have some level of Direct3D support by the hardware.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-isdxgiformatsupported BOOL
		// IsDxgiFormatSupported( DXGI_FORMAT format );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsDxgiFormatSupported(DXGI_FORMAT format);

		/// <summary>Indicates whether the buffer precision is supported by the underlying Direct3D device.</summary>
		/// <param name="bufferPrecision">
		/// <para>Type: <c>D2D1_BUFFER_PRECISION</c></para>
		/// <para>The buffer precision to check.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if the buffer precision is supported. Returns FALSE if the buffer precision is not supported.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-isbufferprecisionsupported BOOL
		// IsBufferPrecisionSupported( D2D1_BUFFER_PRECISION bufferPrecision );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsBufferPrecisionSupported(D2D1_BUFFER_PRECISION bufferPrecision);

		/// <summary>Gets the bounds of an image without the world transform of the context applied.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The image whose bounds will be calculated.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_RECT_F[1]</c></para>
		/// <para>
		/// When this method returns, contains a pointer to the bounds of the image in device independent pixels (DIPs) and in local space.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The image bounds don't include multiplication by the world transform. They do reflect the current DPI, unit mode, and
		/// interpolation mode of the context. To get the bounds that include the world transform, use ID2D1DeviceContext::GetImageWorldBounds.
		/// </para>
		/// <para>
		/// The returned bounds reflect which pixels would be impacted by calling DrawImage with a target offset of (0,0) and an identity
		/// world transform matrix. They do not reflect the current clip rectangle set on the device context or the extent of the context's
		/// current target image.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getimagelocalbounds HRESULT
		// GetImageLocalBounds( ID2D1Image *image, D2D1_RECT_F *localBounds );
		new D2D_RECT_F GetImageLocalBounds(ID2D1Image image);

		/// <summary>Gets the bounds of an image with the world transform of the context applied.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The image whose bounds will be calculated.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_RECT_F[1]</c></para>
		/// <para>When this method returns, contains a pointer to the bounds of the image in device independent pixels (DIPs).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The image bounds reflect the current DPI, unit mode, and world transform of the context. To get bounds which don't include the
		/// world transform, use ID2D1DeviceContext::GetImageLocalBounds.
		/// </para>
		/// <para>
		/// The returned bounds reflect which pixels would be impacted by calling DrawImage with the same image and a target offset of
		/// (0,0). They do not reflect the current clip rectangle set on the device context or the extent of the context’s current target image.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getimageworldbounds HRESULT
		// GetImageWorldBounds( ID2D1Image *image, D2D1_RECT_F *worldBounds );
		new D2D_RECT_F GetImageWorldBounds(ID2D1Image image);

		/// <summary>Gets the world-space bounds in DIPs of the glyph run using the device context DPI.</summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The origin of the baseline for the glyph run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>The glyph run to render.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>The DirectWrite measuring mode that indicates how glyph metrics are used to measure text when it is formatted.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>The bounds of the glyph run in DIPs and in world space.</para>
		/// </returns>
		/// <remarks>The image bounds reflect the current DPI, unit mode, and world transform of the context.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getglyphrunworldbounds HRESULT
		// GetGlyphRunWorldBounds( D2D1_POINT_2F baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, DWRITE_MEASURING_MODE measuringMode,
		// D2D1_RECT_F *bounds );
		new D2D_RECT_F GetGlyphRunWorldBounds(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Gets the device associated with a device context.</summary>
		/// <param name="device">
		/// <para>Type: <c>ID2D1Device**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a Direct2D device associated with this device context.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The application can retrieve the device even if it is created from an earlier render target code-path. The application must use
		/// an ID2D1DeviceContext interface and then call <c>GetDevice</c>. Some functionality for controlling all of the resources for a
		/// set of device contexts is maintained only on an ID2D1Device object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getdevice void GetDevice( ID2D1Device
		// **device );
		[PreserveSig]
		new void GetDevice(out ID2D1Device device);

		/// <summary>The bitmap or command list to which the Direct2D device context will now render.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The surface or command list to which the Direct2D device context will render.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>The target can be changed at any time, including while the context is drawing.</para>
		/// <para>
		/// The target can be either a bitmap created with the D2D1_BITMAP_OPTIONS_TARGET flag, or it can be a command list. Other kinds of
		/// images cannot be set as a target. For example, you cannot set the output of an effect as target. If the target is not valid the
		/// context will enter the <c>D2DERR_INVALID_TARGET</c> error state.
		/// </para>
		/// <para>
		/// You cannot use <c>SetTarget</c> to render to a bitmap/command list from multiple device contexts simultaneously. An image is
		/// considered “being rendered to” if it has ever been set on a device context within a BeginDraw/EndDraw timespan. If an attempt is
		/// made to render to an image through multiple device contexts, all subsequent device contexts after the first will enter an error state.
		/// </para>
		/// <para>Callers wishing to attach an image to a second device context should first call EndDraw on the first device context.</para>
		/// <para>Here is an example of the correct calling order.</para>
		/// <para>Here is an example of the incorrect calling order.</para>
		/// <para>
		/// <c>Note</c> Changing the target does not change the bitmap that an HWND render target presents from, nor does it change the
		/// bitmap that a DC render target blts to/from.
		/// </para>
		/// <para>
		/// This API makes it easy for an application to use a bitmap as a source (like in DrawBitmap) and as a destination at the same
		/// time. Attempting to use a bitmap as a source on the same device context to which it is bound as a target will put the device
		/// context into the D2DERR_BITMAP_BOUND_AS_TARGET error state.
		/// </para>
		/// <para>
		/// It is acceptable to have a bitmap bound as a target bitmap on multiple render targets at once. Applications that do this must
		/// properly synchronize rendering with Flush or EndDraw.
		/// </para>
		/// <para>You can change the target at any time, including while the context is drawing.</para>
		/// <para>
		/// You can set the target to NULL, in which case drawing calls will put the device context into an error state with
		/// D2DERR_WRONG_STATE. Calling <c>SetTarget</c> with a NULL target does not restore the original target bitmap to the device context.
		/// </para>
		/// <para>
		/// If the device context has an outstanding HDC, the context will enter the <c>D2DERR_WRONG_STATE</c> error state. The target will
		/// not be changed.
		/// </para>
		/// <para>
		/// If the bitmap and the device context are not in the same resource domain, the context will enter <c>&lt;/b&gt; error state. The
		/// target will not be changed.</c>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-settarget void SetTarget( ID2D1Image
		// *image );
		[PreserveSig]
		new void SetTarget(ID2D1Image? image);

		/// <summary>Gets the target currently associated with the device context.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the target currently associated with the device context.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>If a target is not associated with the device context, target will contain <c>NULL</c> when the methods returns.</para>
		/// <para>
		/// If the currently selected target is a bitmap rather than a command list, the application can gain access to the initial bitmaps
		/// created by using one of the following methods:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>CreateHwndRenderTarget</term>
		/// </item>
		/// <item>
		/// <term>CreateDxgiSurfaceRenderTarget</term>
		/// </item>
		/// <item>
		/// <term>CreateWicBitmapRenderTarget</term>
		/// </item>
		/// <item>
		/// <term>CreateDCRenderTarget</term>
		/// </item>
		/// <item>
		/// <term>CreateCompatibleRenderTarget</term>
		/// </item>
		/// </list>
		/// <para>
		/// It is not possible for an application to destroy these bitmaps. All of these bitmaps are bindable as bitmap targets. However not
		/// all of these bitmaps can be used as bitmap sources for ID2D1RenderTarget methods.
		/// </para>
		/// <para>
		/// CreateDxgiSurfaceRenderTarget will create a bitmap that is usable as a bitmap source if the DXGI surface is bindable as a shader
		/// resource view.
		/// </para>
		/// <para>CreateCompatibleRenderTarget will always create bitmaps that are usable as a bitmap source.</para>
		/// <para>
		/// ID2D1RenderTarget::BeginDraw will copy from the HDC to the original bitmap associated with it. ID2D1RenderTarget::EndDraw will
		/// copy from the original bitmap to the HDC.
		/// </para>
		/// <para>IWICBitmap objects will be locked in the following circumstances:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>BeginDraw has been called and the currently selected target bitmap is a WIC bitmap.</term>
		/// </item>
		/// <item>
		/// <term>A WIC bitmap is set as the target of a device context after BeginDraw has been called and before EndDraw has been called.</term>
		/// </item>
		/// <item>
		/// <term>Any of the ID2D1Bitmap::Copy* methods are called with a WIC bitmap as either the source or destination.</term>
		/// </item>
		/// </list>
		/// <para>IWICBitmap objects will be unlocked in the following circumstances:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>EndDraw is called and the currently selected target bitmap is a WIC bitmap.</term>
		/// </item>
		/// <item>
		/// <term>A WIC bitmap is removed as the target of a device context between the calls to BeginDraw and EndDraw.</term>
		/// </item>
		/// <item>
		/// <term>Any of the ID2D1Bitmap::Copy* methods are called with a WIC bitmap as either the source or destination.</term>
		/// </item>
		/// </list>
		/// <para>Direct2D will only lock bitmaps that are not currently locked.</para>
		/// <para>
		/// Calling QueryInterface for ID2D1GdiInteropRenderTarget will always succeed. ID2D1GdiInteropRenderTarget::GetDC will return a
		/// device context corresponding to the currently bound target bitmap. GetDC will fail if the target bitmap was not created with the
		/// GDI_COMPATIBLE flag set.
		/// </para>
		/// <para>
		/// ID2D1HwndRenderTarget::Resize will return <c>DXGI_ERROR_INVALID_CALL</c> if there are any outstanding references to the original
		/// target bitmap associated with the render target.
		/// </para>
		/// <para>Although the target can be a command list, it cannot be any other type of image. It cannot be the output image of an effect.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-gettarget void GetTarget( ID2D1Image
		// **image );
		[PreserveSig]
		new void GetTarget(out ID2D1Image? image);

		/// <summary>Sets the rendering controls for the given device context.</summary>
		/// <param name="renderingControls">
		/// <para>Type: <c>const D2D1_RENDERING_CONTROLS*</c></para>
		/// <para>The rendering controls to be applied.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The rendering controls allow the application to tune the precision, performance, and resource usage of rendering operations.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-setrenderingcontrols(constd2d1_rendering_controls_)
		// void SetRenderingControls( const D2D1_RENDERING_CONTROLS &amp; renderingControls );
		[PreserveSig]
		new void SetRenderingControls(in D2D1_RENDERING_CONTROLS renderingControls);

		/// <summary>Gets the rendering controls that have been applied to the context.</summary>
		/// <param name="renderingControls">
		/// <para>Type: <c>D2D1_RENDERING_CONTROLS*</c></para>
		/// <para>When this method returns, contains a pointer to the rendering controls for this context.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getrenderingcontrols void
		// GetRenderingControls( D2D1_RENDERING_CONTROLS *renderingControls );
		[PreserveSig]
		new void GetRenderingControls(out D2D1_RENDERING_CONTROLS renderingControls);

		/// <summary>Changes the primitive blend mode that is used for all rendering operations in the device context.</summary>
		/// <param name="primitiveBlend">
		/// <para>Type: <c>D2D1_PRIMITIVE_BLEND</c></para>
		/// <para>The primitive blend to use.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The primitive blend will apply to all of the primitive drawn on the context, unless this is overridden with the compositeMode
		/// parameter on the DrawImage API.
		/// </para>
		/// <para>
		/// The primitive blend applies to the interior of any primitives drawn on the context. In the case of DrawImage, this will be
		/// implied by the image rectangle, offset and world transform.
		/// </para>
		/// <para>
		/// If the primitive blend is anything other than <c>D2D1_PRIMITIVE_BLEND_SOURCE_OVER</c> then ClearType rendering will be turned
		/// off. If the application explicitly forces ClearType rendering in these modes, the drawing context will be placed in an error
		/// state. D2DERR_WRONG_STATE will be returned from either EndDraw or Flush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-setprimitiveblend void SetPrimitiveBlend(
		// D2D1_PRIMITIVE_BLEND primitiveBlend );
		[PreserveSig]
		new void SetPrimitiveBlend(D2D1_PRIMITIVE_BLEND primitiveBlend);

		/// <summary>Returns the currently set primitive blend used by the device context.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_PRIMITIVE_BLEND</c></para>
		/// <para>The current primitive blend. The default value is <c>D2D1_PRIMITIVE_BLEND_SOURCE_OVER</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getprimitiveblend D2D1_PRIMITIVE_BLEND GetPrimitiveBlend();
		[PreserveSig]
		new D2D1_PRIMITIVE_BLEND GetPrimitiveBlend();

		/// <summary>Sets what units will be used to interpret values passed into the device context.</summary>
		/// <param name="unitMode">
		/// <para>Type: <c>D2D1_UNIT_MODE</c></para>
		/// <para>An enumeration defining how passed-in units will be interpreted by the device context.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method will affect all properties and parameters affected by SetDpi and GetDpi. This affects all coordinates, lengths, and
		/// other properties that are not explicitly defined as being in another unit. For example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>SetUnitMode</c> will affect a coordinate passed into ID2D1DeviceContext::DrawLine, and the scaling of a geometry passed into ID2D1DeviceContext::FillGeometry.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SetUnitMode</c> will not affect the value returned by ID2D1Bitmap::GetPixelSize.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-setunitmode void SetUnitMode(
		// D2D1_UNIT_MODE unitMode );
		[PreserveSig]
		new void SetUnitMode(D2D1_UNIT_MODE unitMode);

		/// <summary>Gets the mode that is being used to interpret values by the device context.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_UNIT_MODE</c></para>
		/// <para>The unit mode.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getunitmode D2D1_UNIT_MODE GetUnitMode();
		[PreserveSig]
		new D2D1_UNIT_MODE GetUnitMode();

		/// <summary>Draws a series of glyphs to the device context.</summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>Origin of first glyph in the series.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>The glyphs to render.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN_DESCRIPTION*</c></para>
		/// <para>Supplementary glyph series information.</para>
		/// </param>
		/// <param name="foregroundBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush that defines the text color.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>The measuring mode of the glyph series, used to determine the advances and offsets. The default value is DWRITE_MEASURING_MODE_NATURAL.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The glyphRunDescription is ignored when rendering, but can be useful for printing and serialization of rendering commands, such
		/// as to an XPS or SVG file. This extends ID2D1RenderTarget::DrawGlyphRun, which lacked the glyph run description.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-drawglyphrun void DrawGlyphRun(
		// D2D1_POINT_2F baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, const DWRITE_GLYPH_RUN_DESCRIPTION *glyphRunDescription,
		// ID2D1Brush *foregroundBrush, DWRITE_MEASURING_MODE measuringMode );
		[PreserveSig]
		new void DrawGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, ID2D1Brush foregroundBrush, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Draws an image to the device context.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The image to be drawn to the device context.</para>
		/// </param>
		/// <param name="targetOffset">
		/// <para>Type: <c>const D2D1_POINT_2F*</c></para>
		/// <para>
		/// The offset in the destination space that the image will be rendered to. The entire logical extent of the image will be rendered
		/// to the corresponding destination. If not specified, the destination origin will be (0, 0). The top-left corner of the image will
		/// be mapped to the target offset. This will not necessarily be the origin. This default value is NULL.
		/// </para>
		/// </param>
		/// <param name="imageRectangle">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>
		/// The corresponding rectangle in the image space will be mapped to the given origins when processing the image. This default value
		/// is NULL.
		/// </para>
		/// </param>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation mode that will be used to scale the image if necessary.</para>
		/// </param>
		/// <param name="compositeMode">
		/// <para>Type: <c>D2D1_COMPOSITE_MODE</c></para>
		/// <para>The composite mode that will be applied to the limits of the currently selected clip. The default value is <c>D2D1_COMPOSITE_MODE_SOURCE_OVER</c></para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If interpolationMode is <c>D2D1_INTERPOLATION_MODE_HIGH_QUALITY</c>, different scalers will be used depending on the scale
		/// factor implied by the world transform.
		/// </para>
		/// <para>
		/// Any invalid rectangles accumulated on any effect that is drawn by this call will be discarded regardless of which portion of the
		/// image rectangle is drawn.
		/// </para>
		/// <para>
		/// If compositeMode is <c>D2D1_COMPOSITE_MODE_SOURCE_OVER</c>, DrawImage will use the currently selected primitive blend specified
		/// by ID2D1DeviceContext::SetPrimitiveBlend. If compositeMode is not <c>D2D1_COMPOSITE_MODE_SOURCE_OVER</c>, the image will be
		/// extended to transparent up to the current axis-aligned clip.
		/// </para>
		/// <para>
		/// If there is an image rectangle and a world transform, this is equivalent to inserting a clip effect to represent the image
		/// rectangle and a 2D affine transform to take into account the world transform.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-drawimage(id2d1effect_constd2d1_point_2f_constd2d1_rect_f_d2d1_interpolation_mode_d2d1_composite_mode)
		// void DrawImage( ID2D1Effect *effect, const D2D1_POINT_2F *targetOffset, const D2D1_RECT_F *imageRectangle,
		// D2D1_INTERPOLATION_MODE interpolationMode, D2D1_COMPOSITE_MODE compositeMode );
		[PreserveSig]
		new void DrawImage(ID2D1Image image, [In, Optional] StructPointer<D2D1_POINT_2F> targetOffset, [In, Optional] PD2D_RECT_F? imageRectangle, D2D1_INTERPOLATION_MODE interpolationMode, D2D1_COMPOSITE_MODE compositeMode);

		/// <summary>Draw a metafile to the device context.</summary>
		/// <param name="gdiMetafile">
		/// <para>Type: <c>ID2D1GdiMetafile*</c></para>
		/// <para>The metafile to draw.</para>
		/// </param>
		/// <param name="targetOffset">
		/// <para>Type: <c>const D2D1_POINT_2F*</c></para>
		/// <para>The offset from the upper left corner of the render target.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-drawgdimetafile(id2d1gdimetafile_d2d1_point_2f)
		// void DrawGdiMetafile( ID2D1GdiMetafile *gdiMetafile, D2D1_POINT_2F targetOffset );
		[PreserveSig]
		new void DrawGdiMetafile(ID2D1GdiMetafile gdiMetafile, [In, Optional] StructPointer<D2D1_POINT_2F> targetOffset);

		/// <summary>Draws a bitmap to the render target.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap to draw.</para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>
		/// The destination rectangle. The default is the size of the bitmap and the location is the upper left corner of the render target.
		/// </para>
		/// </param>
		/// <param name="opacity">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The opacity of the bitmap.</para>
		/// </param>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation mode to use.</para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>An optional source rectangle.</para>
		/// </param>
		/// <param name="perspectiveTransform">
		/// <para>Type: <c>const D2D1_MATRIX_4X4_F</c></para>
		/// <para>An optional perspective transform.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The destinationRectangle parameter defines the rectangle in the target where the bitmap will appear (in device-independent
		/// pixels (DIPs)). This is affected by the currently set transform and the perspective transform, if set. If NULL is specified,
		/// then the destination rectangle is (left=0, top=0, right = width(sourceRectangle), bottom = height(sourceRectangle)).
		/// </para>
		/// <para>
		/// The sourceRectangle parameter defines the sub-rectangle of the source bitmap (in DIPs). <c>DrawBitmap</c> will clip this
		/// rectangle to the size of the source bitmap, thus making it impossible to sample outside of the bitmap. If NULL is specified,
		/// then the source rectangle is taken to be the size of the source bitmap.
		/// </para>
		/// <para>If you specify perspectiveTransform it is applied to the rect in addition to the transform set on the render target.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-drawbitmap(id2d1bitmap_constd2d1_rect_f__float_d2d1_interpolation_mode_constd2d1_rect_f_constd2d1_matrix_4x4_f)
		// void DrawBitmap( ID2D1Bitmap *bitmap, const D2D1_RECT_F &amp; destinationRectangle, FLOAT opacity, D2D1_INTERPOLATION_MODE
		// interpolationMode, const D2D1_RECT_F *sourceRectangle, const D2D1_MATRIX_4X4_F *perspectiveTransform );
		[PreserveSig]
		new void DrawBitmap(ID2D1Bitmap bitmap, [In, Optional] PD2D_RECT_F? destinationRectangle, float opacity, D2D1_INTERPOLATION_MODE interpolationMode, [In, Optional] PD2D_RECT_F? sourceRectangle, [In, Optional] StructPointer<D2D_MATRIX_4X4_F> perspectiveTransform);

		/// <summary>Push a layer onto the clip and layer stack of the device context.</summary>
		/// <param name="layerParameters">
		/// <para>Type: <c>const D2D1_LAYER_PARAMETERS1*</c></para>
		/// <para>The parameters that defines the layer.</para>
		/// </param>
		/// <param name="layer">
		/// <para>Type: <c>ID2D1Layer*</c></para>
		/// <para>The layer resource to push on the device context that receives subsequent drawing operations.</para>
		/// <para><c>Note</c> If a layer is not specified, Direct2D manages the layer resource automatically.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-pushlayer(constd2d1_layer_parameters1__id2d1layer)
		// void PushLayer( const D2D1_LAYER_PARAMETERS1 &amp; layerParameters, ID2D1Layer *layer );
		[PreserveSig]
		new void PushLayer(in D2D1_LAYER_PARAMETERS1 layerParameters, [In, Optional] ID2D1Layer? layer);

		/// <summary>
		/// <para>This indicates that a portion of an effect's input is invalid. This method can be called many times.</para>
		/// <para>
		/// You can use this method to propagate invalid rectangles through an effect graph. You can query Direct2D using the
		/// GetEffectInvalidRectangles method.
		/// </para>
		/// <para><c>Note</c> Direct2D does not automatically use these invalid rectangles to reduce the region of an effect that is rendered.</para>
		/// <para>
		/// You can also use this method to invalidate caches that have accumulated while rendering effects that have the
		/// <c>D2D1_PROPERTY_CACHED</c> property set to true.
		/// </para>
		/// </summary>
		/// <param name="effect">
		/// <para>Type: <c>ID2D1Effect*</c></para>
		/// <para>The effect to invalidate.</para>
		/// </param>
		/// <param name="input">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The input index.</para>
		/// </param>
		/// <param name="inputRectangle">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The rect to invalidate.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-invalidateeffectinputrectangle HRESULT
		// InvalidateEffectInputRectangle( ID2D1Effect *effect, UINT32 input, const D2D1_RECT_F *inputRectangle );
		new void InvalidateEffectInputRectangle(ID2D1Effect effect, uint input, in D2D_RECT_F inputRectangle);

		/// <summary>Gets the number of invalid output rectangles that have accumulated on the effect.</summary>
		/// <param name="effect">
		/// <para>Type: <c>ID2D1Effect*</c></para>
		/// <para>The effect to count the invalid rectangles on.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>The returned rectangle count.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-geteffectinvalidrectanglecount HRESULT
		// GetEffectInvalidRectangleCount( ID2D1Effect *effect, UINT32 *rectangleCount );
		new uint GetEffectInvalidRectangleCount(ID2D1Effect effect);

		/// <summary>
		/// Gets the invalid rectangles that have accumulated since the last time the effect was drawn and EndDraw was then called on the
		/// device context.
		/// </summary>
		/// <param name="effect">
		/// <para>Type: <c>ID2D1Effect*</c></para>
		/// <para>The effect to get the invalid rectangles from.</para>
		/// </param>
		/// <param name="rectangles">
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>
		/// An array of D2D1_RECT_F structures. You must allocate this to the correct size. You can get the count of the invalid rectangles
		/// using the GetEffectInvalidRectangleCount method.
		/// </para>
		/// </param>
		/// <param name="rectanglesCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of rectangles to get.</para>
		/// </param>
		/// <remarks>
		/// <para><c>Note</c> Direct2D does not automatically use these invalid rectangles to reduce the region of an effect that is rendered.</para>
		/// <para>
		/// You can use the InvalidateEffectInputRectangle method to specify invalidated rectangles for Direct2D to propagate through an
		/// effect graph.
		/// </para>
		/// <para>
		/// If multiple invalid rectangles are requested, the rectangles that this method returns may overlap. When this is the case, the
		/// rectangle count might be lower than the count that GetEffectInvalidRectangleCount.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-geteffectinvalidrectangles HRESULT
		// GetEffectInvalidRectangles( ID2D1Effect *effect, D2D1_RECT_F *rectangles, UINT32 rectanglesCount );
		new void GetEffectInvalidRectangles(ID2D1Effect effect, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D2D_RECT_F[] rectangles, int rectanglesCount);

		/// <summary>Returns the input rectangles that are required to be supplied by the caller to produce the given output rectangle.</summary>
		/// <param name="renderEffect">
		/// <para>Type: <c>ID2D1Effect*</c></para>
		/// <para>The image whose output is being rendered.</para>
		/// </param>
		/// <param name="renderImageRectangle">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The portion of the output image whose inputs are being inspected.</para>
		/// </param>
		/// <param name="inputDescriptions">
		/// <para>Type: <c>const D2D1_EFFECT_INPUT_DESCRIPTION*</c></para>
		/// <para>A list of the inputs whos rectangles are being queried.</para>
		/// </param>
		/// <param name="requiredInputRects">
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>The input rectangles returned to the caller.</para>
		/// </param>
		/// <param name="inputCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of inputs.</para>
		/// </param>
		/// <remarks>
		/// The caller should be very careful not to place a reliance on the required input rectangles returned. Small changes for
		/// correctness to an effect's behavior can result in different rectangles being returned. In addition, different kinds of
		/// optimization applied inside the render can also influence the result.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-geteffectrequiredinputrectangles HRESULT
		// GetEffectRequiredInputRectangles( ID2D1Effect *renderEffect, const D2D1_RECT_F *renderImageRectangle, const
		// D2D1_EFFECT_INPUT_DESCRIPTION *inputDescriptions, D2D1_RECT_F *requiredInputRects, UINT32 inputCount );
		new void GetEffectRequiredInputRectangles(ID2D1Effect renderEffect, [In, Optional] PD2D_RECT_F? renderImageRectangle,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D2D1_EFFECT_INPUT_DESCRIPTION[] inputDescriptions,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D2D_RECT_F[] requiredInputRects, int inputCount);

		/// <summary>
		/// Fill using the alpha channel of the supplied opacity mask bitmap. The brush opacity will be modulated by the mask. The render
		/// target antialiasing mode must be set to aliased.
		/// </summary>
		/// <param name="opacityMask">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap that acts as the opacity mask</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush to use for filling the primitive.</para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>The destination rectangle to output to in the render target</para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>The source rectangle from the opacity mask bitmap.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-fillopacitymask(id2d1bitmap_id2d1brush_constd2d1_rect_f__constd2d1_rect_f_)
		// void FillOpacityMask( ID2D1Bitmap *opacityMask, ID2D1Brush *brush, const D2D1_RECT_F &amp; destinationRectangle, const
		// D2D1_RECT_F &amp; sourceRectangle );
		[PreserveSig]
		new void FillOpacityMask(ID2D1Bitmap opacityMask, ID2D1Brush brush, [In, Optional] PD2D_RECT_F? destinationRectangle,
			[In, Optional] PD2D_RECT_F? sourceRectangle);

		/// <summary>Creates a device-dependent representation of the fill of the geometry that can be subsequently rendered.</summary>
		/// <param name="geometry">
		/// <para>Type: <b><c>ID2D1Geometry</c>*</b></para>
		/// <para>The geometry to realize.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The flattening tolerance to use when converting Beziers to line segments. This parameter shares the same units as the
		/// coordinates of the geometry.
		/// </para>
		/// </param>
		/// <param name="geometryRealization">
		/// <para>Type: <b><c>ID2D1GeometryRealization</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to a new geometry realization object.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method is used in conjunction with <c>ID2D1DeviceContext1::DrawGeometryRealization</c>. The
		/// <c>D2D1::ComputeFlatteningTolerance</c> helper API may be used to determine the proper flattening tolerance.
		/// </para>
		/// <para>
		/// If the provided stroke style specifies a stroke transform type other than <c>D2D1_STROKE_TRANSFORM_TYPE_NORMAL</c>, then the
		/// stroke will be realized assuming the identity transform and a DPI of 96.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1devicecontext1-createfilledgeometryrealization HRESULT
		// CreateFilledGeometryRealization( [in] ID2D1Geometry *geometry, FLOAT flatteningTolerance, ID2D1GeometryRealization
		// **geometryRealization );
		new void CreateFilledGeometryRealization([In] ID2D1Geometry geometry, float flatteningTolerance, out ID2D1GeometryRealization geometryRealization);

		/// <summary>Creates a device-dependent representation of the stroke of a geometry that can be subsequently rendered.</summary>
		/// <param name="geometry">
		/// <para>Type: <b><c>ID2D1Geometry</c>*</b></para>
		/// <para>The geometry to realize.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The flattening tolerance to use when converting Beziers to line segments. This parameter shares the same units as the
		/// coordinates of the geometry.
		/// </para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The width of the stroke. This parameter shares the same units as the coordinates of the geometry.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <b><c>ID2D1StrokeStyle</c>*</b></para>
		/// <para>The stroke style (optional).</para>
		/// </param>
		/// <param name="geometryRealization">
		/// <para>Type: <b><c>ID2D1GeometryRealization</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to a new geometry realization object.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method is used in conjunction with <c>ID2D1DeviceContext1::DrawGeometryRealization</c>. The
		/// <c>D2D1::ComputeFlatteningTolerance</c> helper API may be used to determine the proper flattening tolerance.
		/// </para>
		/// <para>
		/// If the provided stroke style specifies a stroke transform type other than <c>D2D1_STROKE_TRANSFORM_TYPE_NORMAL</c>, then the
		/// stroke will be realized assuming the identity transform and a DPI of 96.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1devicecontext1-createstrokedgeometryrealization HRESULT
		// CreateStrokedGeometryRealization( [in] ID2D1Geometry *geometry, FLOAT flatteningTolerance, FLOAT strokeWidth, [in, optional]
		// ID2D1StrokeStyle *strokeStyle, [out] ID2D1GeometryRealization **geometryRealization );
		new void CreateStrokedGeometryRealization([In] ID2D1Geometry geometry, float flatteningTolerance, float strokeWidth,
			[In, Optional] ID2D1StrokeStyle? strokeStyle, out ID2D1GeometryRealization geometryRealization);

		/// <summary>Renders a given geometry realization to the target with the specified brush.</summary>
		/// <param name="geometryRealization">
		/// <para>Type: <b><c>ID2D1GeometryRealization</c>*</b></para>
		/// <para>The geometry realization to be rendered.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <b><c>ID2D1Brush</c>*</b></para>
		/// <para>The brush to render the realization with.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method respects all currently set state (transform, DPI, unit mode, target image, clips, layers); however, artifacts such
		/// as faceting may appear when rendering the realizations with a large effective scale (either via the transform or the DPI).
		/// Callers should create their realizations with an appropriate flattening tolerance using either
		/// <c>D2D1_DEFAULT_FLATTENING_TOLERANCE</c> or <c>ComputeFlatteningTolerance</c> to compensate for this.
		/// </para>
		/// <para>
		/// Additionally, callers should be aware of the safe render bounds when creating geometry realizations. If a geometry extends
		/// outside of [-524,287, 524,287] DIPs in either the X- or the Y- direction in its original (pre-transform) coordinate space, then
		/// it may be clipped to those bounds when it is realized. This clipping will be visible even if the realization is subsequently
		/// transformed to fit within the safe render bounds.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1devicecontext1-drawgeometryrealization void
		// DrawGeometryRealization( [in] ID2D1GeometryRealization *geometryRealization, [in] ID2D1Brush *brush );
		[PreserveSig]
		new void DrawGeometryRealization([In] ID2D1GeometryRealization geometryRealization, [In] ID2D1Brush brush);

		/// <summary>Creates a new <c>ID2D1Ink</c> object that starts at the given point.</summary>
		/// <param name="startPoint">
		/// <para>Type: <b>const <c>D2D1_INK_POINT</c></b></para>
		/// <para>The starting point of the first segment of the first stroke in the new ink object.</para>
		/// </param>
		/// <param name="ink">
		/// <para>Type: <b><c>ID2D1Ink</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to a new ink object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-createink(constd2d1_ink_point__id2d1ink)
		// HRESULT CreateInk( [ref] const D2D1_INK_POINT &amp; startPoint, [out] ID2D1Ink **ink );
		new void CreateInk(in D2D1_INK_POINT startPoint, out ID2D1Ink ink);

		/// <summary>Creates a new <c>ID2D1InkStyle</c> object, for use with ink rendering methods such as <c>DrawInk</c>.</summary>
		/// <param name="inkStyleProperties">
		/// <para>Type: <b>const <c>D2D1_INK_STYLE_PROPERTIES</c></b></para>
		/// <para>The properties of the ink style to be created.</para>
		/// </param>
		/// <param name="inkStyle">
		/// <para>Type: <b><c>ID2D1InkStyle</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to a new ink style object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-createinkstyle(constd2d1_ink_style_properties_id2d1inkstyle)
		// HRESULT CreateInkStyle( [ref] const D2D1_INK_STYLE_PROPERTIES *inkStyleProperties, [out] ID2D1InkStyle **inkStyle );
		new void CreateInkStyle([In, Optional] StructPointer<D2D1_INK_STYLE_PROPERTIES> inkStyleProperties, out ID2D1InkStyle inkStyle);

		/// <summary>Creates a new <c>ID2D1GradientMesh</c> instance using the given array of patches.</summary>
		/// <param name="patches">
		/// <para>Type: <b>const <c>D2D1_GRADIENT_MESH_PATCH</c>*</b></para>
		/// <para>A pointer to the array containing the patches to be used in this mesh.</para>
		/// </param>
		/// <param name="patchesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of patches in the patches argument to read.</para>
		/// </param>
		/// <param name="gradientMesh">
		/// <para>Type: <b><c>ID2D1GradientMesh</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the new gradient mesh.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-creategradientmesh HRESULT
		// CreateGradientMesh( [in] const D2D1_GRADIENT_MESH_PATCH *patches, UINT32 patchesCount, [out] ID2D1GradientMesh **gradientMesh );
		new void CreateGradientMesh([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_GRADIENT_MESH_PATCH[] patches,
			uint patchesCount, out ID2D1GradientMesh gradientMesh);

		/// <summary>
		/// Creates an image source object from a WIC bitmap source, while populating all pixel memory within the image source. The image is
		/// loaded and stored while using a minimal amount of memory.
		/// </summary>
		/// <param name="wicBitmapSource">
		/// <para>Type: <b><c>IWICBitmapSource</c>*</b></para>
		/// <para>The WIC bitmap source to create the image source from.</para>
		/// </param>
		/// <param name="loadingOptions">
		/// <para>Type: <b><c>D2D1_IMAGE_SOURCE_LOADING_OPTIONS</c></b></para>
		/// <para>Options for creating the image source. Default options are used if NULL.</para>
		/// </param>
		/// <param name="alphaMode">The alpha mode.</param>
		/// <param name="imageSource">
		/// <para>Type: <b><c>ID2D1ImageSourceFromWic</c>**</b></para>
		/// <para>Receives the new image source instance.</para>
		/// </param>
		/// <remarks>
		/// <para>This method creates an image source which can be used to draw the image.</para>
		/// <para>
		/// This method supports images that exceed the maximum texture size. Large images are internally stored within a sparse tile cache.
		/// </para>
		/// <para>
		/// This API supports the same set of pixel formats and alpha modes supported by <c>CreateBitmapFromWicBitmap</c>. If the GPU does
		/// not support a given pixel format, this method will return D2DERR_UNSUPPORTED_PIXEL_FORMAT. This method does not apply
		/// adjustments such as gamma or alpha premultiplication which affect the appearance of the image.
		/// </para>
		/// <para>
		/// This method automatically selects an appropriate storage format to minimize GPU memory usage., such as using separate luminance
		/// and chrominance textures for JPEG images.
		/// </para>
		/// <para>If the loadingOptions argument is NULL, D2D uses D2D1_IMAGE_SOURCE_LOADING_OPTIONS_NONE.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-createimagesourcefromwic(iwicbitmapsource_d2d1_image_source_loading_options_id2d1imagesourcefromwic)
		// HRESULT CreateImageSourceFromWic( [in] IWICBitmapSource *wicBitmapSource, D2D1_IMAGE_SOURCE_LOADING_OPTIONS loadingOptions, [out]
		// ID2D1ImageSourceFromWic **imageSource );
		new void CreateImageSourceFromWic([In] IWICBitmapSource wicBitmapSource, D2D1_IMAGE_SOURCE_LOADING_OPTIONS loadingOptions, D2D1_ALPHA_MODE alphaMode, out ID2D1ImageSourceFromWic imageSource);

		/// <summary>
		/// Creates a 3D lookup table for mapping a 3-channel input to a 3-channel output. The table data must be provided in 4-channel format.
		/// </summary>
		/// <param name="precision">
		/// <para>Type: <b><c>D2D1_BUFFER_PRECISION</c></b></para>
		/// <para>Precision of the input lookup table data.</para>
		/// </param>
		/// <param name="extents">
		/// <para>Type: <b>const UINT32*</b></para>
		/// <para>Number of lookup table elements per dimension (X, Y, Z).</para>
		/// </param>
		/// <param name="data">
		/// <para>Type: <b>const BYTE*</b></para>
		/// <para>Buffer holding the lookup table data.</para>
		/// </param>
		/// <param name="dataCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the lookup table data buffer.</para>
		/// </param>
		/// <param name="strides">
		/// <para>Type: <b>const UINT32*</b></para>
		/// <para>
		/// An array containing two values. The first value is the size in bytes from one row (X dimension) of LUT data to the next. The
		/// second value is the size in bytes from one LUT data plane (X and Y dimensions) to the next.
		/// </para>
		/// </param>
		/// <param name="lookupTable">
		/// <para>Type: <b><c>ID2D1LookupTable3D</c>**</b></para>
		/// <para>Receives the new lookup table instance.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-createlookuptable3d HRESULT
		// CreateLookupTable3D( D2D1_BUFFER_PRECISION precision, [in] const UINT32 *extents, [in] const BYTE *data, UINT32 dataCount, [in]
		// const UINT32 *strides, [out] ID2D1LookupTable3D **lookupTable );
		new void CreateLookupTable3D(D2D1_BUFFER_PRECISION precision, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] uint[] extents,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] data, uint dataCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 2)] uint[] strides, out ID2D1LookupTable3D lookupTable);

		/// <summary>
		/// Creates an image source from a set of DXGI surface(s). The YCbCr surface(s) are converted to RGBA automatically during
		/// subsequent drawing.
		/// </summary>
		/// <param name="surfaces">
		/// <para>Type: [in] <b><c>IDXGISurface</c>**</b></para>
		/// <para>The DXGI surfaces to create the image source from.</para>
		/// </param>
		/// <param name="surfaceCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of surfaces provided; must be between one and three.</para>
		/// </param>
		/// <param name="colorSpace">
		/// <para>Type: <b><c>DXGI_COLOR_SPACE_TYPE</c></b></para>
		/// <para>The color space of the input.</para>
		/// </param>
		/// <param name="options">
		/// <para>Type: <b><c>D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS</c></b></para>
		/// <para>Options controlling color space conversions.</para>
		/// </param>
		/// <param name="imageSource">
		/// <para>Type: [out] <b><c>ID2D1ImageSource</c>**</b></para>
		/// <para>Receives the new image source instance.</para>
		/// </param>
		/// <remarks>
		/// <para>This method creates an image source, which can be used to draw the image.</para>
		/// <para>
		/// This method supports surfaces that use a limited set of DXGI formats and DXGI color space types. Only the below set of
		/// combinations of color space types, surface formats, and surface counts are supported:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Color Space Type</description>
		/// <description>Surface Count(s)</description>
		/// <description>Surface Format(s)</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P709</description>
		/// <description>1</description>
		/// <description>Standard D2D-supported pixel formats:</description>
		/// </item>
		/// <item>
		/// <description>DXGI_COLOR_SPACE_YCBCR_FULL_G22_NONE_P709_X601</description>
		/// <description>1, 2, 3</description>
		/// <description>When Surface count is 1: When Surface Count is 2: When Surface Count is 3:</description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P601 DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P601
		/// DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P709 DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P709
		/// DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P2020 DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P2020
		/// </description>
		/// <description>1,2,3</description>
		/// <description>When Surface count is 1: When Surface Count is 2: When Surface Count is 3:</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// The GPU must also have sufficient support for a pixel format to be supported by D2D. To determine whether D2D supports a format,
		/// call IsDxgiFormatSupported.
		/// </para>
		/// <para>
		/// This API converts YCbCr formats to sRGB using the provided color space type and options. RGBA data is assumed to be in the
		/// desired space, and D2D does not apply any conversion.
		/// </para>
		/// <para>
		/// If multiple surfaces are provided, this method infers whether chroma planes are subsampled (by 2x) from the relative sizes of
		/// each corresponding source rectangle (or if the source rectangles parameter is NULL, the bounds of each surface). The second and
		/// third rectangle must each be equal in size to the first rectangle, or to the first rectangle with one or both dimensions scaled
		/// by 0.5 (while rounding up).
		/// </para>
		/// <para>
		/// If provided, the source rectangles must be within the bounds of the corresponding surface. The source rectangles may have
		/// different origins. In this case, this method shifts the data from each plane to align with one another.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-createimagesourcefromdxgi HRESULT
		// CreateImageSourceFromDxgi( IDXGISurface **surfaces, UINT32 surfaceCount, DXGI_COLOR_SPACE_TYPE colorSpace,
		// D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS options, ID2D1ImageSource **imageSource );
		new void CreateImageSourceFromDxgi([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] IDXGISurface[] surfaces,
			uint surfaceCount, DXGI_COLOR_SPACE_TYPE colorSpace, D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS options, out ID2D1ImageSource imageSource);

		/// <summary>Returns the world bounds of a given gradient mesh.</summary>
		/// <param name="gradientMesh">
		/// <para>Type: <b><c>ID2D1GradientMesh</c>*</b></para>
		/// <para>The gradient mesh whose world bounds will be calculated.</para>
		/// </param>
		/// <param name="pBounds">
		/// <para>Type: <b><c>D2D1_RECT_F</c>*</b></para>
		/// <para>When this method returns, contains a pointer to the bounds of the gradient mesh, in device independent pixels (DIPs).</para>
		/// </param>
		/// <remarks>
		/// The world bounds reflect the current DPI, unit mode, and world transform of the context. They indicate which pixels would be
		/// impacted by calling DrawGradientMesh with the given gradient mesh. They do not reflect the current clip rectangle set on the
		/// device context or the extent of the context’s current target.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-getgradientmeshworldbounds HRESULT
		// GetGradientMeshWorldBounds( [in] ID2D1GradientMesh *gradientMesh, [out] D2D1_RECT_F *pBounds );
		new void GetGradientMeshWorldBounds([In] ID2D1GradientMesh gradientMesh, out D2D_RECT_F pBounds);

		/// <summary>Renders the given ink object using the given brush and ink style.</summary>
		/// <param name="ink">
		/// <para>Type: <b><c>ID2D1Ink</c>*</b></para>
		/// <para>The ink object to be rendered.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <b><c>ID2D1Brush</c>*</b></para>
		/// <para>The brush with which to render the ink object.</para>
		/// </param>
		/// <param name="inkStyle">
		/// <para>Type: <b><c>ID2D1InkStyle</c>*</b></para>
		/// <para>The ink style to use when rendering the ink object.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-drawink void DrawInk( [in] ID2D1Ink
		// *ink, [in] ID2D1Brush *brush, [in, optional] ID2D1InkStyle *inkStyle );
		[PreserveSig]
		new void DrawInk([In] ID2D1Ink ink, [In] ID2D1Brush brush, [In, Optional] ID2D1InkStyle? inkStyle);

		/// <summary>Renders a given gradient mesh to the target.</summary>
		/// <param name="gradientMesh">
		/// <para>Type: <b><c>ID2D1GradientMesh</c>*</b></para>
		/// <para>The gradient mesh to be rendered.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-drawgradientmesh void DrawGradientMesh(
		// [in] ID2D1GradientMesh *gradientMesh );
		[PreserveSig]
		new void DrawGradientMesh([In] ID2D1GradientMesh gradientMesh);

		/// <summary>Draws a metafile to the device context using the given source and destination rectangles.</summary>
		/// <param name="gdiMetafile">
		/// <para>Type: <b><c>ID2D1GdiMetafile</c>*</b></para>
		/// <para>The metafile to draw.</para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <b>const <c>D2D1_RECT_F</c></b></para>
		/// <para>
		/// The rectangle in the target where the metafile will be drawn, relative to the upper left corner (defined in DIPs) of the render
		/// target. If NULL is specified, the destination rectangle is {0, 0, w, h}, where w and h are the width and height of the metafile
		/// as reported by <c>ID2D1GdiMetafile::GetBounds</c>.
		/// </para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <b>const <c>D2D1_RECT_F</c></b></para>
		/// <para>
		/// The rectangle of the source metafile that will be drawn, relative to the upper left corner (defined in DIPs) of the metafile. If
		/// NULL is specified, the source rectangle is the value returned by <c>ID2D1GdiMetafile1::GetSourceBounds</c>.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-drawgdimetafile(id2d1gdimetafile_constd2d1_rect_f_constd2d1_rect_f)
		// void DrawGdiMetafile( [in] ID2D1GdiMetafile *gdiMetafile, [ref] const D2D1_RECT_F *destinationRectangle, [ref] const D2D1_RECT_F
		// *sourceRectangle );
		[PreserveSig]
		new void DrawGdiMetafile([In] ID2D1GdiMetafile gdiMetafile, [In, Optional] PD2D_RECT_F? destinationRectangle,
			[In, Optional] D2D_RECT_F? sourceRectangle);

		/// <summary>Creates an image source which shares resources with an original.</summary>
		/// <param name="imageSource">
		/// <para>Type: <b><c>ID2D1ImageSource</c>*</b></para>
		/// <para>The original image.</para>
		/// </param>
		/// <param name="properties">
		/// <para>Type: <b>const <c>D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES</c>*</b></para>
		/// <para>Properties for the source image.</para>
		/// </param>
		/// <param name="transformedImageSource">
		/// <para>Type: <b><c>ID2D1TransformedImageSource</c>**</b></para>
		/// <para>Receives the new image source.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext2-createtransformedimagesource HRESULT
		// CreateTransformedImageSource( [in] ID2D1ImageSource *imageSource, [in] const D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES
		// *properties, [out] ID2D1TransformedImageSource **transformedImageSource );
		new void CreateTransformedImageSource([In] ID2D1ImageSource imageSource, in D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES properties,
			out ID2D1TransformedImageSource transformedImageSource);

		/// <summary>
		/// Creates a new, empty sprite batch. After creating a sprite batch, use <c>ID2D1SpriteBatch::AddSprites</c> to add sprites to it,
		/// then use <c>ID2D1DeviceContext3::DrawSpriteBatch</c> to draw it.
		/// </summary>
		/// <param name="spriteBatch">
		/// <para>Type: <b><c>ID2D1SpriteBatch</c>**</b></para>
		/// <para>When this method returns, contains a pointer to a new, empty sprite batch to be populated by the app.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext3-createspritebatch HRESULT
		// CreateSpriteBatch( [out] ID2D1SpriteBatch **spriteBatch );
		new void CreateSpriteBatch(out ID2D1SpriteBatch spriteBatch);

		/// <summary>Renders part or all of the given sprite batch to the device context using the specified drawing options.</summary>
		/// <param name="spriteBatch">
		/// <para>Type: <b><c>ID2D1SpriteBatch</c>*</b></para>
		/// <para>The sprite batch to draw.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the first sprite in the sprite batch to draw.</para>
		/// </param>
		/// <param name="spriteCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of sprites to draw.</para>
		/// </param>
		/// <param name="bitmap">
		/// <para>Type: <b><c>ID2D1Bitmap</c>*</b></para>
		/// <para>The bitmap from which the sprites are to be sourced. Each sprite's source rectangle refers to a portion of this bitmap.</para>
		/// </param>
		/// <param name="interpolationMode">
		/// <para>Type: <b><c>D2D1_BITMAP_INTERPOLATION_MODE</c></b></para>
		/// <para>
		/// The interpolation mode to use when drawing this sprite batch. This determines how Direct2D interpolates pixels within the drawn
		/// sprites if scaling is performed.
		/// </para>
		/// </param>
		/// <param name="spriteOptions">
		/// <para>Type: <b><c>D2D1_SPRITE_OPTIONS</c></b></para>
		/// <para>The additional drawing options, if any, to be used for this sprite batch.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext3-drawspritebatch(id2d1spritebatch_uint32_uint32_id2d1bitmap_d2d1_bitmap_interpolation_mode_d2d1_sprite_options)
		// void DrawSpriteBatch( [in] ID2D1SpriteBatch *spriteBatch, UINT32 startIndex, UINT32 spriteCount, [in] ID2D1Bitmap *bitmap,
		// D2D1_BITMAP_INTERPOLATION_MODE interpolationMode, D2D1_SPRITE_OPTIONS spriteOptions );
		[PreserveSig]
		new void DrawSpriteBatch([In] ID2D1SpriteBatch spriteBatch, uint startIndex, uint spriteCount, [In] ID2D1Bitmap bitmap,
			D2D1_BITMAP_INTERPOLATION_MODE interpolationMode, D2D1_SPRITE_OPTIONS spriteOptions);

		/// <summary>Creates an SVG glyph style object.</summary>
		/// <param name="svgGlyphStyle">
		/// <para>Type: <b><c>ID2D1SvgGlyphStyle</c>**</b></para>
		/// <para>On completion points to the created <c>ID2D1SvgGlyphStyle</c> object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext4-createsvgglyphstyle HRESULT
		// CreateSvgGlyphStyle( [out] ID2D1SvgGlyphStyle **svgGlyphStyle );
		new void CreateSvgGlyphStyle(out ID2D1SvgGlyphStyle svgGlyphStyle);

		/// <summary>
		/// <para>Draws the text within the given layout rectangle.</para>
		/// <para>By default, this method performs baseline snapping and renders color versions of glyphs in color fonts.</para>
		/// </summary>
		/// <param name="string">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>A pointer to an array of Unicode characters to draw.</para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of characters in string.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <b><c>IDWriteTextFormat</c>*</b></para>
		/// <para>An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</para>
		/// </param>
		/// <param name="layoutRect">
		/// <para>Type: <b>const <c>D2D1_RECT_F</c>*</b></para>
		/// <para>The size and position of the area in which the text is drawn.</para>
		/// </param>
		/// <param name="defaultFillBrush">
		/// <para>Type: <b><c>ID2D1Brush</c>*</b></para>
		/// <para>The brush used to paint the text.</para>
		/// </param>
		/// <param name="svgGlyphStyle">
		/// <para>Type: <b><c>ID2D1SvgGlyphStyle</c>*</b></para>
		/// <para>Values for context-fill, context-stroke, and context-value that are used when rendering SVG glyphs.</para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index used to select a color palette within a color font.</para>
		/// </param>
		/// <param name="options">
		/// <para>Type: <b><c>D2D1_DRAW_TEXT_OPTIONS</c></b></para>
		/// <para>
		/// A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the
		/// layout rectangle. The default value is <c>D2D1_DRAW_TEXT_OPTIONS_NONE</c>, which indicates that text should be snapped to pixel
		/// boundaries and it should not be clipped to the layout rectangle.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>A value that indicates how glyph metrics are used to measure text when it is formatted. The default value is <c>DWRITE_MEASURING_MODE_NATURAL</c>.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext4-drawtext(constwchar_uint32_idwritetextformat_constd2d1_rect_f_id2d1brush_id2d1svgglyphstyle_uint32_d2d1_draw_text_options_dwrite_measuring_mode)
		// void DrawText( [in] const WCHAR *string, UINT32 stringLength, [in] IDWriteTextFormat *textFormat, [in] const D2D1_RECT_F
		// *layoutRect, [in, optional] ID2D1Brush *defaultFillBrush, [in, optional] ID2D1SvgGlyphStyle *svgGlyphStyle, UINT32
		// colorPaletteIndex, D2D1_DRAW_TEXT_OPTIONS options, DWRITE_MEASURING_MODE measuringMode );
		[PreserveSig]
		new void DrawText([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat,
			in D2D_RECT_F layoutRect, [In, Optional] ID2D1Brush? defaultFillBrush, [In, Optional] ID2D1SvgGlyphStyle? svgGlyphStyle,
			uint colorPaletteIndex = 0, D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_ENABLE_COLOR_FONT,
			DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL);

		/// <summary>
		/// Draws a text layout object. If the layout is not subsequently changed, this can be more efficient than DrawText when drawing the
		/// same layout repeatedly.
		/// </summary>
		/// <param name="origin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>
		/// The point, described in device-independent pixels, at which the upper-left corner of the text described by <i>textLayout</i> is drawn.
		/// </para>
		/// </param>
		/// <param name="textLayout">
		/// <para>Type: <b><c>IDWriteTextLayout</c>*</b></para>
		/// <para>
		/// The formatted text to draw. Any drawing effects that do not inherit from <c>ID2D1Resource</c> are ignored. If there are drawing
		/// effects that inherit from <b>ID2D1Resource</b> that are not brushes, this method fails and the render target is put in an error state.
		/// </para>
		/// </param>
		/// <param name="defaultFillBrush">
		/// <para>Type: <b><c>ID2D1Brush</c>*</b></para>
		/// <para>The brush used to paint the text.</para>
		/// </param>
		/// <param name="svgGlyphStyle">
		/// <para>Type: <b><c>ID2D1SvgGlyphStyle</c>*</b></para>
		/// <para>The values for context-fill, context-stroke, and context-value that are used when rendering SVG glyphs.</para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index used to select a color palette within a color font.</para>
		/// </param>
		/// <param name="options">
		/// <para>Type: <b><c>D2D1_DRAW_TEXT_OPTIONS</c></b></para>
		/// <para>
		/// A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the
		/// layout rectangle. The default value is <c>D2D1_DRAW_TEXT_OPTIONS_NONE</c>, which indicates that text should be snapped to pixel
		/// boundaries and it should not be clipped to the layout rectangle.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext4-drawtextlayout void DrawTextLayout(
		// D2D1_POINT_2F origin, [in] IDWriteTextLayout *textLayout, [in, optional] ID2D1Brush *defaultFillBrush, [in, optional]
		// ID2D1SvgGlyphStyle *svgGlyphStyle, UINT32 colorPaletteIndex, D2D1_DRAW_TEXT_OPTIONS options );
		[PreserveSig]
		new void DrawTextLayout(D2D_POINT_2F origin, [In] IDWriteTextLayout textLayout, [In, Optional] ID2D1Brush? defaultFillBrush,
			[In, Optional] ID2D1SvgGlyphStyle? svgGlyphStyle, uint colorPaletteIndex = 0,
			D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_ENABLE_COLOR_FONT);

		/// <summary>Draws a color bitmap glyph run using one of the bitmap formats.</summary>
		/// <param name="glyphImageFormat">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>
		/// Specifies the format of the glyph image. Supported formats are DWRITE_GLYPH_IMAGE_FORMATS_PNG, DWRITE_GLYPH_IMAGE_FORMATS_JPEG,
		/// DWRITE_GLYPH_IMAGE_FORMATS_TIFF, or DWRITE_GLYPH_IMAGE_FORMATS_PREMULTIPLIED_B8G8R8A8. This method will result in an error if
		/// the color glyph run does not contain the requested format.
		/// </para>
		/// <para>Only one format can be specified at a time, combinations of flags are not valid input.</para>
		/// </param>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The origin of the baseline for the glyph run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>The glyphs to render.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Indicates the measuring method.</para>
		/// </param>
		/// <param name="bitmapSnapOption">
		/// <para>Type: <b><c>D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION</c></b></para>
		/// <para>Specifies the pixel snapping policy when rendering color bitmap glyphs.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext4-drawcolorbitmapglyphrun void
		// DrawColorBitmapGlyphRun( DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, D2D1_POINT_2F baselineOrigin, [in] const DWRITE_GLYPH_RUN
		// *glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION bitmapSnapOption );
		[PreserveSig]
		new void DrawColorBitmapGlyphRun(DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun,
			DWRITE_MEASURING_MODE measuringMode = 0, D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION bitmapSnapOption = 0);

		/// <summary>Draws a color glyph run that has the format of DWRITE_GLYPH_IMAGE_FORMATS_SVG.</summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The origin of the baseline for the glyph run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>The glyphs to render.</para>
		/// </param>
		/// <param name="defaultFillBrush">
		/// <para>Type: <b><c>ID2D1Brush</c>*</b></para>
		/// <para>The brush used to paint the specified glyphs.</para>
		/// </param>
		/// <param name="svgGlyphStyle">
		/// <para>Type: <b><c>ID2D1SvgGlyphStyle</c>*</b></para>
		/// <para>Values for context-fill, context-stroke, and context-value that are used when rendering SVG glyphs.</para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The index used to select a color palette within a color font. Note that this not the same as the paletteIndex in the
		/// DWRITE_COLOR_GLYPH_RUN struct, which is not relevant for SVG glyphs.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Indicates the measuring method used for text layout.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext4-drawsvgglyphrun void DrawSvgGlyphRun(
		// D2D1_POINT_2F baselineOrigin, [in] const DWRITE_GLYPH_RUN *glyphRun, [in, optional] ID2D1Brush *defaultFillBrush, [in, optional]
		// ID2D1SvgGlyphStyle *svgGlyphStyle, UINT32 colorPaletteIndex, DWRITE_MEASURING_MODE measuringMode );
		[PreserveSig]
		new void DrawSvgGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, [In, Optional] ID2D1Brush? defaultFillBrush,
			[In, Optional] ID2D1SvgGlyphStyle? svgGlyphStyle, uint colorPaletteIndex = 0, DWRITE_MEASURING_MODE measuringMode = 0);

		/// <summary>
		/// Retrieves an image of the color bitmap glyph from the color glyph cache. If the cache does not already contain the requested
		/// resource, it will be created. This method may be used to extend the lifetime of a glyph image even after it is evicted from the
		/// color glyph cache.
		/// </summary>
		/// <param name="glyphImageFormat">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>
		/// The format for the glyph image. If there is no image data in the requested format for the requested glyph, this method will
		/// return an error.
		/// </para>
		/// </param>
		/// <param name="glyphOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The origin for the glyph.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>
		/// Reference to a font face which contains font face type, appropriate file references, face identification data and various font
		/// data such as metrics, names and glyph outlines.
		/// </para>
		/// </param>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The specified font size affects the choice of which bitmap to use from the font. It also affects the output glyphTransform,
		/// causing it to properly scale the glyph.
		/// </para>
		/// </param>
		/// <param name="glyphIndex">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Index of the glyph.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// If true, specifies that glyphs are rotated 90 degrees to the left and vertical metrics are used. Vertical writing is achieved by
		/// specifying isSideways as true and rotating the entire run 90 degrees to the right via a rotate transform.
		/// </para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>
		/// The transform to apply to the image. This input transform affects the choice of which bitmap to use from the font. It is also
		/// factored into the output glyphTransform.
		/// </para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Dots per inch along the x-axis.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Dots per inch along the y-axis.</para>
		/// </param>
		/// <param name="glyphTransform">
		/// <para>Type: <b><c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>
		/// Output transform, which transforms from the glyph's space to the same output space as the worldTransform. This includes the
		/// input glyphOrigin, the glyph's offset from the glyphOrigin, and any other required transformations.
		/// </para>
		/// </param>
		/// <param name="glyphImage">
		/// <para>Type: <b><c>ID2D1Image</c>**</b></para>
		/// <para>On completion contains the retrieved glyph image.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext4-getcolorbitmapglyphimage HRESULT
		// GetColorBitmapGlyphImage( DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, D2D1_POINT_2F glyphOrigin, [in] IDWriteFontFace *fontFace,
		// FLOAT fontEmSize, UINT16 glyphIndex, BOOL isSideways, [in, optional] const D2D1_MATRIX_3X2_F *worldTransform, FLOAT dpiX, FLOAT
		// dpiY, [out] D2D1_MATRIX_3X2_F *glyphTransform, [out] ID2D1Image **glyphImage );
		new void GetColorBitmapGlyphImage(DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, D2D_POINT_2F glyphOrigin, [In] IDWriteFontFace fontFace, float fontEmSize,
			ushort glyphIndex, bool isSideways, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float dpiX, float dpiY,
			out D2D_MATRIX_3X2_F glyphTransform, out ID2D1Image glyphImage);

		/// <summary>
		/// Retrieves an image of the SVG glyph from the color glyph cache. If the cache does not already contain the requested resource, it
		/// will be created. This method may be used to extend the lifetime of a glyph image even after it is evicted from the color glyph cache.
		/// </summary>
		/// <param name="glyphOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>Origin of the glyph.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>
		/// Reference to a font face which contains font face type, appropriate file references, face identification data and various font
		/// data such as metrics, names and glyph outlines.
		/// </para>
		/// </param>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The specified font size affects the output glyphTransform, causing it to properly scale the glyph.</para>
		/// </param>
		/// <param name="glyphIndex">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Index of the glyph to retrieve.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// If true, specifies that glyphs are rotated 90 degrees to the left and vertical metrics are used. Vertical writing is achieved by
		/// specifying isSideways as true and rotating the entire run 90 degrees to the right via a rotate transform.
		/// </para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>The transform to apply to the image.</para>
		/// </param>
		/// <param name="defaultFillBrush">
		/// <para>Type: <b><c>ID2D1Brush</c>*</b></para>
		/// <para>Describes how the area is painted.</para>
		/// </param>
		/// <param name="svgGlyphStyle">
		/// <para>Type: <b><c>ID2D1SvgGlyphStyle</c>*</b></para>
		/// <para>The values for context-fill, context-stroke, and context-value that are used when rendering SVG glyphs.</para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The index used to select a color palette within a color font. Note that this not the same as the paletteIndex in the
		/// DWRITE_COLOR_GLYPH_RUN struct, which is not relevant for SVG glyphs.
		/// </para>
		/// </param>
		/// <param name="glyphTransform">
		/// <para>Type: <b><c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>
		/// Output transform, which transforms from the glyph's space to the same output space as the worldTransform. This includes the
		/// input glyphOrigin, the glyph's offset from the glyphOrigin, and any other required transformations.
		/// </para>
		/// </param>
		/// <param name="glyphImage">
		/// <para>Type: <b><c>ID2D1CommandList</c>**</b></para>
		/// <para>On completion, contains the retrieved glyph image.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext4-getsvgglyphimage HRESULT
		// GetSvgGlyphImage( D2D1_POINT_2F glyphOrigin, [in] IDWriteFontFace *fontFace, FLOAT fontEmSize, UINT16 glyphIndex, BOOL
		// isSideways, [in, optional] const D2D1_MATRIX_3X2_F *worldTransform, [in, optional] ID2D1Brush *defaultFillBrush, [in, optional]
		// ID2D1SvgGlyphStyle *svgGlyphStyle, UINT32 colorPaletteIndex, [out] D2D1_MATRIX_3X2_F *glyphTransform, [out] ID2D1CommandList
		// **glyphImage );
		new void GetSvgGlyphImage(D2D_POINT_2F glyphOrigin, [In] IDWriteFontFace fontFace, float fontEmSize, ushort glyphIndex, bool isSideways,
			[In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, [In, Optional] ID2D1Brush? defaultFillBrush,
			[In, Optional] ID2D1SvgGlyphStyle? svgGlyphStyle, uint colorPaletteIndex, out D2D_MATRIX_3X2_F glyphTransform, out ID2D1CommandList glyphImage);

		/// <summary>Creates an SVG document from a stream.</summary>
		/// <param name="inputXmlStream">
		/// <para>Type: <b>IStream*</b></para>
		/// <para>An input stream containing the SVG XML document. If null, an empty document is created.</para>
		/// </param>
		/// <param name="viewportSize">
		/// <para>Type: <b>D2D1_SIZE_F</b></para>
		/// <para>Size of the initial viewport of the document.</para>
		/// </param>
		/// <param name="svgDocument">
		/// <para>Type: <b>ID2D1SvgDocument**</b></para>
		/// <para>When this method returns, contains a pointer to the created SVG document.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext5-createsvgdocument HRESULT
		// CreateSvgDocument( [in, optional] IStream *inputXmlStream, D2D1_SIZE_F viewportSize, [out] ID2D1SvgDocument **svgDocument );
		new void CreateSvgDocument([In, Optional] IStream? inputXmlStream, D2D_SIZE_F viewportSize, out ID2D1SvgDocument svgDocument);

		/// <summary>Draws an SVG document.</summary>
		/// <param name="svgDocument">
		/// <para>Type: <b>ID2D1SvgDocument*</b></para>
		/// <para>The SVG document to draw.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext5-drawsvgdocument void DrawSvgDocument(
		// [in] ID2D1SvgDocument *svgDocument );
		[PreserveSig]
		new void DrawSvgDocument([In] ID2D1SvgDocument svgDocument);

		/// <summary>
		/// Creates a color context from a DXGI color space type. It is only valid to use this with the Color Management Effect in 'Best' mode.
		/// </summary>
		/// <param name="colorSpace">
		/// <para>Type: <b>DXGI_COLOR_SPACE_TYPE</b></para>
		/// <para>The color space to create the color context from.</para>
		/// </param>
		/// <param name="colorContext">
		/// <para>Type: <b>ID2D1ColorContext1**</b></para>
		/// <para>The created color context.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext5-createcolorcontextfromdxgicolorspace
		// HRESULT CreateColorContextFromDxgiColorSpace( DXGI_COLOR_SPACE_TYPE colorSpace, [out] ID2D1ColorContext1 **colorContext );
		new void CreateColorContextFromDxgiColorSpace(DXGI_COLOR_SPACE_TYPE colorSpace, out ID2D1ColorContext1 colorContext);

		/// <summary>
		/// Creates a color context from a simple color profile. It is only valid to use this with the Color Management Effect in 'Best' mode.
		/// </summary>
		/// <param name="simpleProfile">
		/// <para>Type: <b>const <c>D2D1_SIMPLE_COLOR_PROFILE</c></b></para>
		/// <para>The simple color profile to create the color context from.</para>
		/// </param>
		/// <param name="colorContext">
		/// <para>Type: <b>ID2D1ColorContext1**</b></para>
		/// <para>The created color context.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext5-createcolorcontextfromsimplecolorprofile(constd2d1_simple_color_profile__id2d1colorcontext1)
		// HRESULT CreateColorContextFromSimpleColorProfile( [ref] const D2D1_SIMPLE_COLOR_PROFILE &amp; simpleProfile, [out]
		// ID2D1ColorContext1 **colorContext );
		new void CreateColorContextFromSimpleColorProfile(in D2D1_SIMPLE_COLOR_PROFILE simpleProfile, out ID2D1ColorContext1 colorContext);

		/// <summary>
		/// Draws an image to the device context using the specified blend mode. Results are equivalent to using Direct2D's built-in
		/// <c>Blend effect</c>.
		/// </summary>
		/// <param name="image">
		/// <para>Type: <b>ID2D1Image*</b></para>
		/// <para>The image to be drawn to the device context.</para>
		/// </param>
		/// <param name="blendMode">
		/// <para>Type: <b>D2D1_BLEND_MODE</b></para>
		/// <para>The blend mode to be used. See <c>Blend modes</c> for more info.</para>
		/// </param>
		/// <param name="targetOffset">
		/// <para>Type: <b>const D2D1_POINT_2F*</b></para>
		/// <para>
		/// The offset in the destination space that the image will be rendered to. The entire logical extent of the image will be rendered
		/// to the corresponding destination. If not specified, the destination origin will be (0, 0). The top-left corner of the image will
		/// be mapped to the target offset. This will not necessarily be the origin. The default value is NULL.
		/// </para>
		/// </param>
		/// <param name="imageRectangle">
		/// <para>Type: <b>const D2D1_RECT_F*</b></para>
		/// <para>
		/// The corresponding rectangle in the image space will be mapped to the given origins when processing the image. The default value
		/// is NULL.
		/// </para>
		/// </param>
		/// <param name="interpolationMode">
		/// <para>Type: <b>D2D1_INTERPOLATION_MODE</b></para>
		/// <para>The interpolation mode that will be used to scale the image if necessary. The default value is D2D1_INTERPOLATION_MODE_LINEAR.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext6-blendimage void BlendImage( [in]
		// ID2D1Image *image, D2D1_BLEND_MODE blendMode, [in, optional] const D2D1_POINT_2F *targetOffset, [in, optional] const D2D1_RECT_F
		// *imageRectangle, D2D1_INTERPOLATION_MODE interpolationMode );
		[PreserveSig]
		new void BlendImage([In] ID2D1Image image, D2D1_BLEND_MODE blendMode, [In, Optional] PD2D_POINT_2F? targetOffset,
			[In, Optional] PD2D_RECT_F? imageRectangle, D2D1_INTERPOLATION_MODE interpolationMode = D2D1_INTERPOLATION_MODE.D2D1_INTERPOLATION_MODE_LINEAR);

		/// <summary>
		/// <para>Important</para>
		/// <para>
		/// Some information relates to a prerelease product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_PAINT_FEATURE_LEVEL</c></b></para>
		/// <para>The paint feature level supported by <c>DrawPaintGlyphRun</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext7-getpaintfeaturelevel
		// DWRITE_PAINT_FEATURE_LEVEL GetPaintFeatureLevel();
		[PreserveSig]
		DWRITE_PAINT_FEATURE_LEVEL GetPaintFeatureLevel();

		/// <summary>
		/// <para>Important</para>
		/// <para>
		/// Some information relates to a prerelease product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.
		/// </para>
		/// </summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The baseline.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: _In_ <b>CONST <c>DWRITE_GLYPH_RUN</c> *</b></para>
		/// <para>The glyph run to draw.</para>
		/// </param>
		/// <param name="defaultFillBrush">
		/// <para>Type: _In_opt_ <b><c>ID2D1Brush</c> *</b></para>
		/// <para>Default fill brush.</para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>
		/// The index used to select a color palette within a color font. Note that this not the same as the paletteIndex in the
		/// <c>DWRITE_COLOR_GLYPH_RUN</c> struct, which is not relevant for paint glyphs.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c> = DWRITE_MEASURING_MODE_NATURAL</b></para>
		/// <para>Specifies measuring mode for positioning glyphs in the run.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext7-drawpaintglyphrun void
		// DrawPaintGlyphRun( D2D1_POINT_2F baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, ID2D1Brush *defaultFillBrush, UINT32
		// colorPaletteIndex, DWRITE_MEASURING_MODE measuringMode );
		[PreserveSig]
		void DrawPaintGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, [In, Optional] ID2D1Brush? defaultFillBrush,
			uint colorPaletteIndex = 0, DWRITE_MEASURING_MODE measuringMode = 0);

		/// <summary>
		/// <para>Important</para>
		/// <para>
		/// Some information relates to a prerelease product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.
		/// </para>
		/// </summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The baseline.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: _In_ <b>CONST <c>DWRITE_GLYPH_RUN</c> *</b></para>
		/// <para>The glyph run to draw.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: _In_opt_ <b>CONST <c>DWRITE_GLYPH_RUN_DESCRIPTION</c> *</b></para>
		/// <para>A description of the glyph run to draw.</para>
		/// </param>
		/// <param name="foregroundBrush">
		/// <para>Type: _In_opt_ <b><c>ID2D1Brush</c> *</b></para>
		/// <para>Foreground brush for the text.</para>
		/// </param>
		/// <param name="svgGlyphStyle">
		/// <para>Type: _In_opt_ <b><c>ID2D1SvgGlyphStyle</c> *</b></para>
		/// <para>The glyph style.</para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font-defined color palette to use.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c> = DWRITE_MEASURING_MODE_NATURAL</b></para>
		/// <para>Specifies measuring mode for positioning glyphs in the run.</para>
		/// </param>
		/// <param name="bitmapSnapOption">
		/// <para>Type: <b><c>D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION</c> = D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION_DEFAULT</b></para>
		/// <para>Snap options.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1devicecontext7-drawglyphrunwithcolorsupport void
		// DrawGlyphRunWithColorSupport( D2D1_POINT_2F baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, const DWRITE_GLYPH_RUN_DESCRIPTION
		// *glyphRunDescription, ID2D1Brush *foregroundBrush, ID2D1SvgGlyphStyle *svgGlyphStyle, UINT32 colorPaletteIndex,
		// DWRITE_MEASURING_MODE measuringMode, D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION bitmapSnapOption );
		[PreserveSig]
		void DrawGlyphRunWithColorSupport(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, [In, Optional] ID2D1Brush? foregroundBrush,
			[In, Optional] ID2D1SvgGlyphStyle? svgGlyphStyle, uint colorPaletteIndex = 0, DWRITE_MEASURING_MODE measuringMode = 0,
			D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION bitmapSnapOption = 0);
	}

	/// <summary>Creates Direct2D resources. This interface also enables the creation of <c>ID2D1Device2</c> objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1factory3
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1Factory3")]
	[ComImport, Guid("0869759F-4F00-413F-B03E-2BDA45404D0F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Factory3 : ID2D1Factory2
	{
		/// <summary>Forces the factory to refresh any system defaults that it might have changed since factory creation.</summary>
		/// <remarks>You should call this method before calling the GetDesktopDpi method, to ensure that the system DPI is current.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-reloadsystemmetrics HRESULT ReloadSystemMetrics();
		new void ReloadSystemMetrics();

		/// <summary>Retrieves the current desktop dots per inch (DPI). To refresh this value, call ReloadSystemMetrics.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the horizontal DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the vertical DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Use this method to obtain the system DPI when setting physical pixel values, such as when you specify the size of a window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-getdesktopdpi void GetDesktopDpi( FLOAT *dpiX, FLOAT
		// *dpiY );
		[PreserveSig, Obsolete("ID2D1Factory::GetDesktopDpi is deprecated. For a desktop app, instead use GetDpiForWindow. For a Universal Windows Platform (UWP) app, instead use DisplayInformation::LogicalDpi.")]
		new void GetDesktopDpi(out float dpiX, out float dpiY);

		/// <summary>Creates an ID2D1RectangleGeometry.</summary>
		/// <param name="rectangle">
		/// <para>Type: [in] <c>const D2D1_RECT_F*</c></para>
		/// <para>The coordinates of the rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createrectanglegeometry%28constd2d1_rect_f_id2d1rectanglegeometry%29
		// HRESULT CreateRectangleGeometry( const D2D1_RECT_F *rectangle, ID2D1RectangleGeometry **rectangleGeometry );
		new ID2D1RectangleGeometry CreateRectangleGeometry(in D2D_RECT_F rectangle);

		/// <summary>Creates an ID2D1RoundedRectangleGeometry.</summary>
		/// <param name="roundedRectangle">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT*</c></para>
		/// <para>The coordinates and corner radii of the rounded rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RoundedRectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rounded rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createroundedrectanglegeometry%28constd2d1_rounded_rect_id2d1roundedrectanglegeometry%29
		// HRESULT CreateRoundedRectangleGeometry( const D2D1_ROUNDED_RECT *roundedRectangle, ID2D1RoundedRectangleGeometry
		// **roundedRectangleGeometry );
		new ID2D1RoundedRectangleGeometry CreateRoundedRectangleGeometry(in D2D1_ROUNDED_RECT roundedRectangle);

		/// <summary>Creates an ID2D1EllipseGeometry.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>A value that describes the center point, x-radius, and y-radius of the ellipse geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1EllipseGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ellipse geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createellipsegeometry%28constd2d1_ellipse__id2d1ellipsegeometry%29
		// HRESULT CreateEllipseGeometry( const D2D1_ELLIPSE &amp; ellipse, ID2D1EllipseGeometry **ellipseGeometry );
		new ID2D1EllipseGeometry CreateEllipseGeometry(in D2D1_ELLIPSE ellipse);

		/// <summary>Creates an ID2D1GeometryGroup, which is an object that holds other geometries.</summary>
		/// <param name="fillMode">
		/// <para>Type: <c>D2D1_FILL_MODE</c></para>
		/// <para>A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</para>
		/// </param>
		/// <param name="geometries">
		/// <para>Type: <c>ID2D1Geometry**</c></para>
		/// <para>
		/// An array containing the geometry objects to add to the geometry group. The number of elements in this array is indicated by the
		/// geometriesCount parameter.
		/// </para>
		/// </param>
		/// <param name="geometriesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in geometries.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1GeometryGroup**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the geometry group created by this method.</para>
		/// </returns>
		/// <remarks>
		/// Geometry groups are a convenient way to group several geometries simultaneously so all figures of several distinct geometries
		/// are concatenated into one. To create a ID2D1GeometryGroup object, call the <c>CreateGeometryGroup</c> method on the ID2D1Factory
		/// object, passing in the fillMode with possible values of D2D1_FILL_MODE_ALTERNATE (alternate) and <c>D2D1_FILL_MODE_WINDING</c>,
		/// an array of geometry objects to add to the geometry group, and the number of elements in this array.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-creategeometrygroup HRESULT CreateGeometryGroup(
		// D2D1_FILL_MODE fillMode, ID2D1Geometry **geometries, UINT32 geometriesCount, ID2D1GeometryGroup **geometryGroup );
		new ID2D1GeometryGroup CreateGeometryGroup(D2D1_FILL_MODE fillMode, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] ID2D1Geometry[] geometries, uint geometriesCount);

		/// <summary>Transforms the specified geometry and stores the result as an ID2D1TransformedGeometry object.</summary>
		/// <param name="sourceGeometry">
		/// <para>Type: [in] <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to transform.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transformation to apply.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1TransformedGeometry**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the new transformed geometry object. The transformed geometry
		/// stores the result of transforming sourceGeometry by transform.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Like other resources, a transformed geometry inherits the resource space and threading policy of the factory that created it.
		/// This object is immutable.
		/// </para>
		/// <para>
		/// When stroking a transformed geometry with the DrawGeometry method, the stroke width is not affected by the transform applied to
		/// the geometry. The stroke width is only affected by the world transform.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createtransformedgeometry%28id2d1geometry_constd2d1_matrix_3x2_f_id2d1transformedgeometry%29
		// HRESULT CreateTransformedGeometry( ID2D1Geometry *sourceGeometry, const D2D1_MATRIX_3X2_F *transform, ID2D1TransformedGeometry
		// **transformedGeometry );
		new ID2D1TransformedGeometry CreateTransformedGeometry([In] ID2D1Geometry sourceGeometry, in D2D_MATRIX_3X2_F transform);

		/// <summary>Creates an empty ID2D1PathGeometry.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1PathGeometry**</c></para>
		/// <para>When this method returns, contains the address to a pointer to the path geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createpathgeometry HRESULT CreatePathGeometry(
		// ID2D1PathGeometry **pathGeometry );
		new ID2D1PathGeometry CreatePathGeometry();

		/// <summary>Creates an ID2D1StrokeStyle that describes start cap, dash pattern, and other features of a stroke.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <c>const D2D1_STROKE_STYLE_PROPERTIES</c></para>
		/// <para>A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length of a
		/// dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length of each
		/// dash and space in the dash pattern is the product of the element value in the array and the stroke width.
		/// </para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the dashes array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1StrokeStyle**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the stroke style created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createstrokestyle%28constd2d1_stroke_style_properties__constfloat_uint32_id2d1strokestyle%29
		// HRESULT CreateStrokeStyle( const D2D1_STROKE_STYLE_PROPERTIES &amp; strokeStyleProperties, const FLOAT *dashes, UINT32
		// dashesCount, ID2D1StrokeStyle **strokeStyle );
		new ID2D1StrokeStyle CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES strokeStyleProperties, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] dashes, uint dashesCount);

		/// <summary>
		/// Creates an ID2D1DrawingStateBlock that can be used with the SaveDrawingState and RestoreDrawingState methods of a render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <c>const D2D1_DRAWING_STATE_DESCRIPTION*</c></para>
		/// <para>A structure that contains antialiasing, transform, and tags information.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>Optional text parameters that indicate how text should be rendered.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DrawingStateBlock**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new drawing state block created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdrawingstateblock%28constd2d1_drawing_state_description_idwriterenderingparams_id2d1drawingstateblock%29
		// HRESULT CreateDrawingStateBlock( const D2D1_DRAWING_STATE_DESCRIPTION *drawingStateDescription, IDWriteRenderingParams
		// *textRenderingParams, ID2D1DrawingStateBlock **drawingStateBlock );
		new ID2D1DrawingStateBlock CreateDrawingStateBlock([In, Optional] StructPointer<D2D1_DRAWING_STATE_DESCRIPTION> drawingStateDescription, [In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="target">
		/// <para>Type: <c>IWICBitmap*</c></para>
		/// <para>The bitmap that receives the rendering output of the render target.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must use D2D1_FEATURE_LEVEL_DEFAULT for the <c>minLevel</c> member of the renderTargetProperties parameter with this method.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold onto them for the life of the application or until the
		/// D2DERR_RECREATE_TARGET error is received. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createwicbitmaprendertarget%28iwicbitmap_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateWicBitmapRenderTarget( IWICBitmap *target, const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties,
		// ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateWicBitmapRenderTarget([In] IWICBitmap target, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates an <c>ID2D1HwndRenderTarget</c>, a render target that renders to a window.</summary>
		/// <param name="renderTargetProperties">
		/// <para>[in] Type: <c>D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <param name="hwndRenderTargetProperties">
		/// <para>[in] Type: <c>D2D1_HWND_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>The window handle, initial size (in pixels), and present options.</para>
		/// </param>
		/// <returns>
		/// <para>[out] Type: <c>ID2D1HwndRenderTarget**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the <c>ID2D1HwndRenderTarget</c> object created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the <c>D2DERR_RECREATE_TARGET</c> error
		/// is received. When you receive this error, you need to recreate the render target (and any resources it created).
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd371275(v=vs.85) virtual HRESULT
		// CreateHwndRenderTarget( [in] D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, [in] D2D1_HWND_RENDER_TARGET_PROPERTIES
		// *hwndRenderTargetProperties, [out] ID2D1HwndRenderTarget **hwndRenderTarget ) = 0;
		new ID2D1HwndRenderTarget CreateHwndRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, in D2D1_HWND_RENDER_TARGET_PROPERTIES hwndRenderTargetProperties);

		/// <summary>Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.</summary>
		/// <param name="dxgiSurface">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>The IDXGISurface to which the render target will draw.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES &amp;</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To write to a Direct3D surface, you obtain an IDXGISurface and pass it to the CreateDxgiSurfaceRenderTarget method to create a
		/// DXGI surface render target; you can then use the DXGI surface render target to draw 2-D content to the DXGI surface.
		/// </para>
		/// <para>
		/// A DXGI surface render target is a type of ID2D1RenderTarget. Like other Direct2D render targets, you can use it to create
		/// resources and issue drawing commands.
		/// </para>
		/// <para>
		/// The DXGI surface render target and the DXGI surface must use the same DXGI format. If you specify the DXGI_FORMAT_UNKOWN format
		/// when you create the render target, it will automatically use the surface's format.
		/// </para>
		/// <para>The DXGI surface render target does not perform DXGI surface synchronization.</para>
		/// <para>
		/// For more information about creating and using DXGI surface render targets, see the Direct2D and Direct3D Interoperability Overview.
		/// </para>
		/// <para>
		/// To work with Direct2D, the Direct3D device that provides the IDXGISurface must be created with the
		/// <c>D3D10_CREATE_DEVICE_BGRA_SUPPORT</c> flag.
		/// </para>
		/// <para>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the render target's EndDraw method
		/// returns the D2DERR_RECREATE_TARGET error. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdxgisurfacerendertarget%28idxgisurface_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateDxgiSurfaceRenderTarget( IDXGISurface *dxgiSurface, const D2D1_RENDER_TARGET_PROPERTIES &amp;
		// renderTargetProperties, ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateDxgiSurfaceRenderTarget([In] IDXGISurface dxgiSurface, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.</summary>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. To enable the device context (DC) render target to work with GDI, set the DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM
		/// and the alpha mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>. For more information about pixel formats,
		/// see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DCRenderTarget**</c></para>
		/// <para>
		/// When this method returns, dcRenderTarget contains the address of the pointer to the ID2D1DCRenderTarget created by the method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before you can render with a DC render target, you must use the render target's BindDC method to associate it with a GDI DC. Do
		/// this for each different DC and whenever there is a change in the size of the area you want to draw to.
		/// </para>
		/// <para>
		/// To enable the DC render target to work with GDI, set the render target's DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM and alpha
		/// mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold on to them for the life of the application or until the render
		/// target's EndDraw method returns the D2DERR_RECREATE_TARGET error. When you receive this error, recreate the render target (and
		/// any resources it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdcrendertarget HRESULT CreateDCRenderTarget(
		// const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, ID2D1DCRenderTarget **dcRenderTarget );
		new ID2D1DCRenderTarget CreateDCRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a <c>ID2D1Device</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device</c>.</para>
		/// </param>
		/// <param name="d2dDevice">
		/// <para>Type: <b><c>ID2D1Device</c>**</b></para>
		/// <para>The requested <c>ID2D1Device</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device **d2dDevice );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device d2dDevice);

		/// <summary>Creates a <c>ID2D1StrokeStyle1</c> object.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <b>const <c>D2D1_STROKE_STYLE_PROPERTIES1</c>*</b></para>
		/// <para>The stroke style properties to apply.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <b>const <c>FLOAT</c>*</b></para>
		/// <para>An array of widths for the dashes and gaps.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the dash array.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <b>const <c>ID2D1StrokeStyle1</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created stroke style.</para>
		/// </param>
		/// <remarks>It is valid to specify a dash array only if D2D1_DASH_STYLE_CUSTOM is also specified.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createstrokestyle(constd2d1_stroke_style_properties1_constfloat_uint32_id2d1strokestyle1)
		// HRESULT CreateStrokeStyle( [in] const D2D1_STROKE_STYLE_PROPERTIES1 *strokeStyleProperties, [in] const FLOAT *dashes, UINT32
		// dashesCount, [out] ID2D1StrokeStyle1 **strokeStyle );
		new void CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES1 strokeStyleProperties,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[]? dashes, [Optional] uint dashesCount, out ID2D1StrokeStyle1 strokeStyle);

		/// <summary>Creates an <c>ID2D1PathGeometry1</c> object.</summary>
		/// <param name="pathGeometry">
		/// <para>Type: <b>const **</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created path geometry.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createpathgeometry HRESULT CreatePathGeometry(
		// [out] ID2D1PathGeometry1 **pathGeometry );
		new void CreatePathGeometry(out ID2D1PathGeometry1 pathGeometry);

		/// <summary>
		/// Creates a new drawing state block, this can be used in subsequent SaveDrawingState and RestoreDrawingState operations on the
		/// render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <b>const <c>D2D1_DRAWING_STATE_DESCRIPTION1</c>*</b></para>
		/// <para>The drawing state description structure.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>The DirectWrite rendering params interface.</para>
		/// </param>
		/// <param name="drawingStateBlock">
		/// <para>Type: <b><c>ID2D1DrawingStateBlock1</c>**</b></para>
		/// <para>The address of the newly created drawing state block.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdrawingstateblock(constd2d1_drawing_state_description1_idwriterenderingparams_id2d1drawingstateblock1)
		// HRESULT CreateDrawingStateBlock( [in, optional] const D2D1_DRAWING_STATE_DESCRIPTION1 *drawingStateDescription, [in, optional]
		// IDWriteRenderingParams *textRenderingParams, [out] ID2D1DrawingStateBlock1 **drawingStateBlock );
		new void CreateDrawingStateBlock([In, Optional] ManagedStructPointer<D2D1_DRAWING_STATE_DESCRIPTION1> drawingStateDescription,
			[In, Optional] IDWriteRenderingParams? textRenderingParams, out ID2D1DrawingStateBlock1 drawingStateBlock);

		/// <summary>Creates a new <c>ID2D1GdiMetafile</c> object that you can use to replay metafile content.</summary>
		/// <param name="metafileStream">
		/// <para>Type: <b>IStream*</b></para>
		/// <para>A stream object that has the metafile data.</para>
		/// </param>
		/// <param name="metafile">
		/// <para>Type: <b><c>ID2D1GdiMetafile</c>**</b></para>
		/// <para>The address of the newly created GDI metafile object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-creategdimetafile HRESULT CreateGdiMetafile(
		// [in] IStream *metafileStream, [out] ID2D1GdiMetafile **metafile );
		new void CreateGdiMetafile([In] IStream metafileStream, out ID2D1GdiMetafile metafile);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a stream.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b>IStream</b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <c>RegisterEffect</c> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <c>RegisterEffect</c> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory, derived
		/// device, and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstream HRESULT
		// RegisterEffectFromStream( [in] REFCLSID classId, [in] IStream *propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromStream(in Guid classId, [In] IStream propertyXml, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[] bindings, uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a string.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b><c>PCWSTR</c></b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <b>RegisterEffect</b> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <b>RegisterEffect</b> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory and
		/// derived device and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstring HRESULT
		// RegisterEffectFromString( [in] REFCLSID classId, [in] PCWSTR propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromString(in Guid classId, [MarshalAs(UnmanagedType.LPWStr)] string propertyXml,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[]? bindings, [Optional] uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Unregisters an effect within the factory instance that corresponds to the <i>classId</i> provided.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be unregistered.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// In order for the effect to be fully unloaded, you must call <b>UnregisterEffect</b> the same number of times that you have
		/// registered the effect.
		/// </para>
		/// <para>
		/// The <b>UnregisterEffect</b> method unregisters only those effects that are registered on the same factory. It cannot be used to
		/// unregister a built-in effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-unregistereffect HRESULT UnregisterEffect(
		// [in] REFCLSID classId );
		new void UnregisterEffect(in Guid classId);

		/// <summary>Returns the class IDs of the currently registered effects and global effects on this factory.</summary>
		/// <param name="effects">
		/// <para>Type: <b><c>CLSID</c>*</b></para>
		/// <para>When this method returns, contains an array of effects. <b>NULL</b> if no effects are retrieved.</para>
		/// </param>
		/// <param name="effectsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The capacity of the <i>effects</i> array.</para>
		/// </param>
		/// <param name="effectsReturned">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects copied into <i>effects</i>.</para>
		/// </param>
		/// <param name="effectsRegistered">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects currently registered in the system.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The set of class IDs will be atomically returned by the API. The set will not be interrupted by other threads registering or
		/// unregistering effects.
		/// </para>
		/// <para>
		/// If <i>effectsRegistered</i> is larger than <i>effectCount</i>, the supplied array will still be filled to capacity with the
		/// current set of registered effects. This method returns the CLSIDs for all global effects and all effects registered to this factory.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-getregisteredeffects HRESULT
		// GetRegisteredEffects( [out] CLSID *effects, UINT32 effectsCount, [out] UINT32 *effectsReturned, [out, optional] UINT32
		// *effectsRegistered );
		new void GetRegisteredEffects([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[]? effects, uint effectsCount,
			out uint effectsReturned, out uint effectsRegistered);

		/// <summary>Retrieves the properties of an effect.</summary>
		/// <param name="effectId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The ID of the effect to retrieve properties from.</para>
		/// </param>
		/// <param name="properties">
		/// <para>Type: <b><c>ID2D1Properties</c>**</b></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the property interface that can be used to query the metadata of
		/// the effect.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The returned effect properties will have all the mutable properties for the effect set to a default of <b>NULL</b>, or an empty value.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Value types will be zero-filled.</description>
		/// </item>
		/// <item>
		/// <description>Blob and string types will be zero-length.</description>
		/// </item>
		/// <item>
		/// <description>Array types will have length 1 and the element of the array will conform to the previous rules.</description>
		/// </item>
		/// </list>
		/// <para>This method cannot be used to return the properties for any effect not visible to <c>ID2D1DeviceContext::CreateEffect</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-geteffectproperties HRESULT
		// GetEffectProperties( [in] REFCLSID effectId, [out] ID2D1Properties **properties );
		new void GetEffectProperties(in Guid effectId, out ID2D1Properties properties);

		/// <summary>Creates an <c>ID2D1Device1</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device1</c>.</para>
		/// </param>
		/// <param name="d2dDevice1">
		/// <para>Type: <b><c>ID2D1Device1</c>**</b></para>
		/// <para>The requested <c>ID2D1Device1</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device1</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1factory2-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device1 **d2dDevice1 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device1 d2dDevice1);

		/// <summary>Creates an <c>ID2D1Device2</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device2</c>.</para>
		/// </param>
		/// <param name="d2dDevice2">
		/// <para>Type: <b><c>ID2D1Device2</c>**</b></para>
		/// <para>The requested <c>ID2D1Device2</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory3-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device2 **d2dDevice2 );
		void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device2 d2dDevice2);
	}

	/// <summary>Creates Direct2D resources. This interface also enables the creation of <c>ID2D1Device3</c> objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1factory4
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1Factory4")]
	[ComImport, Guid("BD4EC2D2-0662-4BEE-BA8E-6F29F032E096"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Factory4 : ID2D1Factory3
	{
		/// <summary>Forces the factory to refresh any system defaults that it might have changed since factory creation.</summary>
		/// <remarks>You should call this method before calling the GetDesktopDpi method, to ensure that the system DPI is current.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-reloadsystemmetrics HRESULT ReloadSystemMetrics();
		new void ReloadSystemMetrics();

		/// <summary>Retrieves the current desktop dots per inch (DPI). To refresh this value, call ReloadSystemMetrics.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the horizontal DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the vertical DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Use this method to obtain the system DPI when setting physical pixel values, such as when you specify the size of a window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-getdesktopdpi void GetDesktopDpi( FLOAT *dpiX, FLOAT
		// *dpiY );
		[PreserveSig, Obsolete("ID2D1Factory::GetDesktopDpi is deprecated. For a desktop app, instead use GetDpiForWindow. For a Universal Windows Platform (UWP) app, instead use DisplayInformation::LogicalDpi.")]
		new void GetDesktopDpi(out float dpiX, out float dpiY);

		/// <summary>Creates an ID2D1RectangleGeometry.</summary>
		/// <param name="rectangle">
		/// <para>Type: [in] <c>const D2D1_RECT_F*</c></para>
		/// <para>The coordinates of the rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createrectanglegeometry%28constd2d1_rect_f_id2d1rectanglegeometry%29
		// HRESULT CreateRectangleGeometry( const D2D1_RECT_F *rectangle, ID2D1RectangleGeometry **rectangleGeometry );
		new ID2D1RectangleGeometry CreateRectangleGeometry(in D2D_RECT_F rectangle);

		/// <summary>Creates an ID2D1RoundedRectangleGeometry.</summary>
		/// <param name="roundedRectangle">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT*</c></para>
		/// <para>The coordinates and corner radii of the rounded rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RoundedRectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rounded rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createroundedrectanglegeometry%28constd2d1_rounded_rect_id2d1roundedrectanglegeometry%29
		// HRESULT CreateRoundedRectangleGeometry( const D2D1_ROUNDED_RECT *roundedRectangle, ID2D1RoundedRectangleGeometry
		// **roundedRectangleGeometry );
		new ID2D1RoundedRectangleGeometry CreateRoundedRectangleGeometry(in D2D1_ROUNDED_RECT roundedRectangle);

		/// <summary>Creates an ID2D1EllipseGeometry.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>A value that describes the center point, x-radius, and y-radius of the ellipse geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1EllipseGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ellipse geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createellipsegeometry%28constd2d1_ellipse__id2d1ellipsegeometry%29
		// HRESULT CreateEllipseGeometry( const D2D1_ELLIPSE &amp; ellipse, ID2D1EllipseGeometry **ellipseGeometry );
		new ID2D1EllipseGeometry CreateEllipseGeometry(in D2D1_ELLIPSE ellipse);

		/// <summary>Creates an ID2D1GeometryGroup, which is an object that holds other geometries.</summary>
		/// <param name="fillMode">
		/// <para>Type: <c>D2D1_FILL_MODE</c></para>
		/// <para>A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</para>
		/// </param>
		/// <param name="geometries">
		/// <para>Type: <c>ID2D1Geometry**</c></para>
		/// <para>
		/// An array containing the geometry objects to add to the geometry group. The number of elements in this array is indicated by the
		/// geometriesCount parameter.
		/// </para>
		/// </param>
		/// <param name="geometriesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in geometries.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1GeometryGroup**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the geometry group created by this method.</para>
		/// </returns>
		/// <remarks>
		/// Geometry groups are a convenient way to group several geometries simultaneously so all figures of several distinct geometries
		/// are concatenated into one. To create a ID2D1GeometryGroup object, call the <c>CreateGeometryGroup</c> method on the ID2D1Factory
		/// object, passing in the fillMode with possible values of D2D1_FILL_MODE_ALTERNATE (alternate) and <c>D2D1_FILL_MODE_WINDING</c>,
		/// an array of geometry objects to add to the geometry group, and the number of elements in this array.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-creategeometrygroup HRESULT CreateGeometryGroup(
		// D2D1_FILL_MODE fillMode, ID2D1Geometry **geometries, UINT32 geometriesCount, ID2D1GeometryGroup **geometryGroup );
		new ID2D1GeometryGroup CreateGeometryGroup(D2D1_FILL_MODE fillMode, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] ID2D1Geometry[] geometries, uint geometriesCount);

		/// <summary>Transforms the specified geometry and stores the result as an ID2D1TransformedGeometry object.</summary>
		/// <param name="sourceGeometry">
		/// <para>Type: [in] <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to transform.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transformation to apply.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1TransformedGeometry**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the new transformed geometry object. The transformed geometry
		/// stores the result of transforming sourceGeometry by transform.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Like other resources, a transformed geometry inherits the resource space and threading policy of the factory that created it.
		/// This object is immutable.
		/// </para>
		/// <para>
		/// When stroking a transformed geometry with the DrawGeometry method, the stroke width is not affected by the transform applied to
		/// the geometry. The stroke width is only affected by the world transform.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createtransformedgeometry%28id2d1geometry_constd2d1_matrix_3x2_f_id2d1transformedgeometry%29
		// HRESULT CreateTransformedGeometry( ID2D1Geometry *sourceGeometry, const D2D1_MATRIX_3X2_F *transform, ID2D1TransformedGeometry
		// **transformedGeometry );
		new ID2D1TransformedGeometry CreateTransformedGeometry([In] ID2D1Geometry sourceGeometry, in D2D_MATRIX_3X2_F transform);

		/// <summary>Creates an empty ID2D1PathGeometry.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1PathGeometry**</c></para>
		/// <para>When this method returns, contains the address to a pointer to the path geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createpathgeometry HRESULT CreatePathGeometry(
		// ID2D1PathGeometry **pathGeometry );
		new ID2D1PathGeometry CreatePathGeometry();

		/// <summary>Creates an ID2D1StrokeStyle that describes start cap, dash pattern, and other features of a stroke.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <c>const D2D1_STROKE_STYLE_PROPERTIES</c></para>
		/// <para>A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length of a
		/// dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length of each
		/// dash and space in the dash pattern is the product of the element value in the array and the stroke width.
		/// </para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the dashes array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1StrokeStyle**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the stroke style created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createstrokestyle%28constd2d1_stroke_style_properties__constfloat_uint32_id2d1strokestyle%29
		// HRESULT CreateStrokeStyle( const D2D1_STROKE_STYLE_PROPERTIES &amp; strokeStyleProperties, const FLOAT *dashes, UINT32
		// dashesCount, ID2D1StrokeStyle **strokeStyle );
		new ID2D1StrokeStyle CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES strokeStyleProperties, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] dashes, uint dashesCount);

		/// <summary>
		/// Creates an ID2D1DrawingStateBlock that can be used with the SaveDrawingState and RestoreDrawingState methods of a render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <c>const D2D1_DRAWING_STATE_DESCRIPTION*</c></para>
		/// <para>A structure that contains antialiasing, transform, and tags information.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>Optional text parameters that indicate how text should be rendered.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DrawingStateBlock**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new drawing state block created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdrawingstateblock%28constd2d1_drawing_state_description_idwriterenderingparams_id2d1drawingstateblock%29
		// HRESULT CreateDrawingStateBlock( const D2D1_DRAWING_STATE_DESCRIPTION *drawingStateDescription, IDWriteRenderingParams
		// *textRenderingParams, ID2D1DrawingStateBlock **drawingStateBlock );
		new ID2D1DrawingStateBlock CreateDrawingStateBlock([In, Optional] StructPointer<D2D1_DRAWING_STATE_DESCRIPTION> drawingStateDescription, [In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="target">
		/// <para>Type: <c>IWICBitmap*</c></para>
		/// <para>The bitmap that receives the rendering output of the render target.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must use D2D1_FEATURE_LEVEL_DEFAULT for the <c>minLevel</c> member of the renderTargetProperties parameter with this method.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold onto them for the life of the application or until the
		/// D2DERR_RECREATE_TARGET error is received. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createwicbitmaprendertarget%28iwicbitmap_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateWicBitmapRenderTarget( IWICBitmap *target, const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties,
		// ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateWicBitmapRenderTarget([In] IWICBitmap target, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates an <c>ID2D1HwndRenderTarget</c>, a render target that renders to a window.</summary>
		/// <param name="renderTargetProperties">
		/// <para>[in] Type: <c>D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <param name="hwndRenderTargetProperties">
		/// <para>[in] Type: <c>D2D1_HWND_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>The window handle, initial size (in pixels), and present options.</para>
		/// </param>
		/// <returns>
		/// <para>[out] Type: <c>ID2D1HwndRenderTarget**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the <c>ID2D1HwndRenderTarget</c> object created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the <c>D2DERR_RECREATE_TARGET</c> error
		/// is received. When you receive this error, you need to recreate the render target (and any resources it created).
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd371275(v=vs.85) virtual HRESULT
		// CreateHwndRenderTarget( [in] D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, [in] D2D1_HWND_RENDER_TARGET_PROPERTIES
		// *hwndRenderTargetProperties, [out] ID2D1HwndRenderTarget **hwndRenderTarget ) = 0;
		new ID2D1HwndRenderTarget CreateHwndRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, in D2D1_HWND_RENDER_TARGET_PROPERTIES hwndRenderTargetProperties);

		/// <summary>Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.</summary>
		/// <param name="dxgiSurface">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>The IDXGISurface to which the render target will draw.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES &amp;</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To write to a Direct3D surface, you obtain an IDXGISurface and pass it to the CreateDxgiSurfaceRenderTarget method to create a
		/// DXGI surface render target; you can then use the DXGI surface render target to draw 2-D content to the DXGI surface.
		/// </para>
		/// <para>
		/// A DXGI surface render target is a type of ID2D1RenderTarget. Like other Direct2D render targets, you can use it to create
		/// resources and issue drawing commands.
		/// </para>
		/// <para>
		/// The DXGI surface render target and the DXGI surface must use the same DXGI format. If you specify the DXGI_FORMAT_UNKOWN format
		/// when you create the render target, it will automatically use the surface's format.
		/// </para>
		/// <para>The DXGI surface render target does not perform DXGI surface synchronization.</para>
		/// <para>
		/// For more information about creating and using DXGI surface render targets, see the Direct2D and Direct3D Interoperability Overview.
		/// </para>
		/// <para>
		/// To work with Direct2D, the Direct3D device that provides the IDXGISurface must be created with the
		/// <c>D3D10_CREATE_DEVICE_BGRA_SUPPORT</c> flag.
		/// </para>
		/// <para>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the render target's EndDraw method
		/// returns the D2DERR_RECREATE_TARGET error. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdxgisurfacerendertarget%28idxgisurface_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateDxgiSurfaceRenderTarget( IDXGISurface *dxgiSurface, const D2D1_RENDER_TARGET_PROPERTIES &amp;
		// renderTargetProperties, ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateDxgiSurfaceRenderTarget([In] IDXGISurface dxgiSurface, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.</summary>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. To enable the device context (DC) render target to work with GDI, set the DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM
		/// and the alpha mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>. For more information about pixel formats,
		/// see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DCRenderTarget**</c></para>
		/// <para>
		/// When this method returns, dcRenderTarget contains the address of the pointer to the ID2D1DCRenderTarget created by the method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before you can render with a DC render target, you must use the render target's BindDC method to associate it with a GDI DC. Do
		/// this for each different DC and whenever there is a change in the size of the area you want to draw to.
		/// </para>
		/// <para>
		/// To enable the DC render target to work with GDI, set the render target's DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM and alpha
		/// mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold on to them for the life of the application or until the render
		/// target's EndDraw method returns the D2DERR_RECREATE_TARGET error. When you receive this error, recreate the render target (and
		/// any resources it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdcrendertarget HRESULT CreateDCRenderTarget(
		// const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, ID2D1DCRenderTarget **dcRenderTarget );
		new ID2D1DCRenderTarget CreateDCRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a <c>ID2D1Device</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device</c>.</para>
		/// </param>
		/// <param name="d2dDevice">
		/// <para>Type: <b><c>ID2D1Device</c>**</b></para>
		/// <para>The requested <c>ID2D1Device</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device **d2dDevice );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device d2dDevice);

		/// <summary>Creates a <c>ID2D1StrokeStyle1</c> object.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <b>const <c>D2D1_STROKE_STYLE_PROPERTIES1</c>*</b></para>
		/// <para>The stroke style properties to apply.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <b>const <c>FLOAT</c>*</b></para>
		/// <para>An array of widths for the dashes and gaps.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the dash array.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <b>const <c>ID2D1StrokeStyle1</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created stroke style.</para>
		/// </param>
		/// <remarks>It is valid to specify a dash array only if D2D1_DASH_STYLE_CUSTOM is also specified.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createstrokestyle(constd2d1_stroke_style_properties1_constfloat_uint32_id2d1strokestyle1)
		// HRESULT CreateStrokeStyle( [in] const D2D1_STROKE_STYLE_PROPERTIES1 *strokeStyleProperties, [in] const FLOAT *dashes, UINT32
		// dashesCount, [out] ID2D1StrokeStyle1 **strokeStyle );
		new void CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES1 strokeStyleProperties,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[]? dashes, [Optional] uint dashesCount, out ID2D1StrokeStyle1 strokeStyle);

		/// <summary>Creates an <c>ID2D1PathGeometry1</c> object.</summary>
		/// <param name="pathGeometry">
		/// <para>Type: <b>const **</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created path geometry.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createpathgeometry HRESULT CreatePathGeometry(
		// [out] ID2D1PathGeometry1 **pathGeometry );
		new void CreatePathGeometry(out ID2D1PathGeometry1 pathGeometry);

		/// <summary>
		/// Creates a new drawing state block, this can be used in subsequent SaveDrawingState and RestoreDrawingState operations on the
		/// render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <b>const <c>D2D1_DRAWING_STATE_DESCRIPTION1</c>*</b></para>
		/// <para>The drawing state description structure.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>The DirectWrite rendering params interface.</para>
		/// </param>
		/// <param name="drawingStateBlock">
		/// <para>Type: <b><c>ID2D1DrawingStateBlock1</c>**</b></para>
		/// <para>The address of the newly created drawing state block.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdrawingstateblock(constd2d1_drawing_state_description1_idwriterenderingparams_id2d1drawingstateblock1)
		// HRESULT CreateDrawingStateBlock( [in, optional] const D2D1_DRAWING_STATE_DESCRIPTION1 *drawingStateDescription, [in, optional]
		// IDWriteRenderingParams *textRenderingParams, [out] ID2D1DrawingStateBlock1 **drawingStateBlock );
		new void CreateDrawingStateBlock([In, Optional] ManagedStructPointer<D2D1_DRAWING_STATE_DESCRIPTION1> drawingStateDescription,
			[In, Optional] IDWriteRenderingParams? textRenderingParams, out ID2D1DrawingStateBlock1 drawingStateBlock);

		/// <summary>Creates a new <c>ID2D1GdiMetafile</c> object that you can use to replay metafile content.</summary>
		/// <param name="metafileStream">
		/// <para>Type: <b>IStream*</b></para>
		/// <para>A stream object that has the metafile data.</para>
		/// </param>
		/// <param name="metafile">
		/// <para>Type: <b><c>ID2D1GdiMetafile</c>**</b></para>
		/// <para>The address of the newly created GDI metafile object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-creategdimetafile HRESULT CreateGdiMetafile(
		// [in] IStream *metafileStream, [out] ID2D1GdiMetafile **metafile );
		new void CreateGdiMetafile([In] IStream metafileStream, out ID2D1GdiMetafile metafile);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a stream.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b>IStream</b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <c>RegisterEffect</c> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <c>RegisterEffect</c> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory, derived
		/// device, and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstream HRESULT
		// RegisterEffectFromStream( [in] REFCLSID classId, [in] IStream *propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromStream(in Guid classId, [In] IStream propertyXml, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[] bindings, uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a string.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b><c>PCWSTR</c></b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <b>RegisterEffect</b> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <b>RegisterEffect</b> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory and
		/// derived device and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstring HRESULT
		// RegisterEffectFromString( [in] REFCLSID classId, [in] PCWSTR propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromString(in Guid classId, [MarshalAs(UnmanagedType.LPWStr)] string propertyXml,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[]? bindings, [Optional] uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Unregisters an effect within the factory instance that corresponds to the <i>classId</i> provided.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be unregistered.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// In order for the effect to be fully unloaded, you must call <b>UnregisterEffect</b> the same number of times that you have
		/// registered the effect.
		/// </para>
		/// <para>
		/// The <b>UnregisterEffect</b> method unregisters only those effects that are registered on the same factory. It cannot be used to
		/// unregister a built-in effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-unregistereffect HRESULT UnregisterEffect(
		// [in] REFCLSID classId );
		new void UnregisterEffect(in Guid classId);

		/// <summary>Returns the class IDs of the currently registered effects and global effects on this factory.</summary>
		/// <param name="effects">
		/// <para>Type: <b><c>CLSID</c>*</b></para>
		/// <para>When this method returns, contains an array of effects. <b>NULL</b> if no effects are retrieved.</para>
		/// </param>
		/// <param name="effectsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The capacity of the <i>effects</i> array.</para>
		/// </param>
		/// <param name="effectsReturned">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects copied into <i>effects</i>.</para>
		/// </param>
		/// <param name="effectsRegistered">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects currently registered in the system.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The set of class IDs will be atomically returned by the API. The set will not be interrupted by other threads registering or
		/// unregistering effects.
		/// </para>
		/// <para>
		/// If <i>effectsRegistered</i> is larger than <i>effectCount</i>, the supplied array will still be filled to capacity with the
		/// current set of registered effects. This method returns the CLSIDs for all global effects and all effects registered to this factory.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-getregisteredeffects HRESULT
		// GetRegisteredEffects( [out] CLSID *effects, UINT32 effectsCount, [out] UINT32 *effectsReturned, [out, optional] UINT32
		// *effectsRegistered );
		new void GetRegisteredEffects([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[]? effects, uint effectsCount,
			out uint effectsReturned, out uint effectsRegistered);

		/// <summary>Retrieves the properties of an effect.</summary>
		/// <param name="effectId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The ID of the effect to retrieve properties from.</para>
		/// </param>
		/// <param name="properties">
		/// <para>Type: <b><c>ID2D1Properties</c>**</b></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the property interface that can be used to query the metadata of
		/// the effect.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The returned effect properties will have all the mutable properties for the effect set to a default of <b>NULL</b>, or an empty value.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Value types will be zero-filled.</description>
		/// </item>
		/// <item>
		/// <description>Blob and string types will be zero-length.</description>
		/// </item>
		/// <item>
		/// <description>Array types will have length 1 and the element of the array will conform to the previous rules.</description>
		/// </item>
		/// </list>
		/// <para>This method cannot be used to return the properties for any effect not visible to <c>ID2D1DeviceContext::CreateEffect</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-geteffectproperties HRESULT
		// GetEffectProperties( [in] REFCLSID effectId, [out] ID2D1Properties **properties );
		new void GetEffectProperties(in Guid effectId, out ID2D1Properties properties);

		/// <summary>Creates an <c>ID2D1Device1</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device1</c>.</para>
		/// </param>
		/// <param name="d2dDevice1">
		/// <para>Type: <b><c>ID2D1Device1</c>**</b></para>
		/// <para>The requested <c>ID2D1Device1</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device1</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1factory2-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device1 **d2dDevice1 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device1 d2dDevice1);

		/// <summary>Creates an <c>ID2D1Device2</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device2</c>.</para>
		/// </param>
		/// <param name="d2dDevice2">
		/// <para>Type: <b><c>ID2D1Device2</c>**</b></para>
		/// <para>The requested <c>ID2D1Device2</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory3-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device2 **d2dDevice2 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device2 d2dDevice2);

		/// <summary>Creates an <c>ID2D1Device3</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The IDXGIDevice object used when creating the <c>ID2D1Device3</c>.</para>
		/// </param>
		/// <param name="d2dDevice3">
		/// <para>Type: <b><c>ID2D1Device3</c>**</b></para>
		/// <para>The requested <c>ID2D1Device3</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory4-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device3 **d2dDevice3 );
		void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device3 d2dDevice3);
	}

	/// <summary>Creates Direct2D resources. This interface also enables the creation of <c>ID2D1Device4</c> objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1factory5
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1Factory5")]
	[ComImport, Guid("C4349994-838E-4B0F-8CAB-44997D9EEACC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Factory5 : ID2D1Factory4
	{
		/// <summary>Forces the factory to refresh any system defaults that it might have changed since factory creation.</summary>
		/// <remarks>You should call this method before calling the GetDesktopDpi method, to ensure that the system DPI is current.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-reloadsystemmetrics HRESULT ReloadSystemMetrics();
		new void ReloadSystemMetrics();

		/// <summary>Retrieves the current desktop dots per inch (DPI). To refresh this value, call ReloadSystemMetrics.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the horizontal DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the vertical DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Use this method to obtain the system DPI when setting physical pixel values, such as when you specify the size of a window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-getdesktopdpi void GetDesktopDpi( FLOAT *dpiX, FLOAT
		// *dpiY );
		[PreserveSig, Obsolete("ID2D1Factory::GetDesktopDpi is deprecated. For a desktop app, instead use GetDpiForWindow. For a Universal Windows Platform (UWP) app, instead use DisplayInformation::LogicalDpi.")]
		new void GetDesktopDpi(out float dpiX, out float dpiY);

		/// <summary>Creates an ID2D1RectangleGeometry.</summary>
		/// <param name="rectangle">
		/// <para>Type: [in] <c>const D2D1_RECT_F*</c></para>
		/// <para>The coordinates of the rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createrectanglegeometry%28constd2d1_rect_f_id2d1rectanglegeometry%29
		// HRESULT CreateRectangleGeometry( const D2D1_RECT_F *rectangle, ID2D1RectangleGeometry **rectangleGeometry );
		new ID2D1RectangleGeometry CreateRectangleGeometry(in D2D_RECT_F rectangle);

		/// <summary>Creates an ID2D1RoundedRectangleGeometry.</summary>
		/// <param name="roundedRectangle">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT*</c></para>
		/// <para>The coordinates and corner radii of the rounded rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RoundedRectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rounded rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createroundedrectanglegeometry%28constd2d1_rounded_rect_id2d1roundedrectanglegeometry%29
		// HRESULT CreateRoundedRectangleGeometry( const D2D1_ROUNDED_RECT *roundedRectangle, ID2D1RoundedRectangleGeometry
		// **roundedRectangleGeometry );
		new ID2D1RoundedRectangleGeometry CreateRoundedRectangleGeometry(in D2D1_ROUNDED_RECT roundedRectangle);

		/// <summary>Creates an ID2D1EllipseGeometry.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>A value that describes the center point, x-radius, and y-radius of the ellipse geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1EllipseGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ellipse geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createellipsegeometry%28constd2d1_ellipse__id2d1ellipsegeometry%29
		// HRESULT CreateEllipseGeometry( const D2D1_ELLIPSE &amp; ellipse, ID2D1EllipseGeometry **ellipseGeometry );
		new ID2D1EllipseGeometry CreateEllipseGeometry(in D2D1_ELLIPSE ellipse);

		/// <summary>Creates an ID2D1GeometryGroup, which is an object that holds other geometries.</summary>
		/// <param name="fillMode">
		/// <para>Type: <c>D2D1_FILL_MODE</c></para>
		/// <para>A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</para>
		/// </param>
		/// <param name="geometries">
		/// <para>Type: <c>ID2D1Geometry**</c></para>
		/// <para>
		/// An array containing the geometry objects to add to the geometry group. The number of elements in this array is indicated by the
		/// geometriesCount parameter.
		/// </para>
		/// </param>
		/// <param name="geometriesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in geometries.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1GeometryGroup**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the geometry group created by this method.</para>
		/// </returns>
		/// <remarks>
		/// Geometry groups are a convenient way to group several geometries simultaneously so all figures of several distinct geometries
		/// are concatenated into one. To create a ID2D1GeometryGroup object, call the <c>CreateGeometryGroup</c> method on the ID2D1Factory
		/// object, passing in the fillMode with possible values of D2D1_FILL_MODE_ALTERNATE (alternate) and <c>D2D1_FILL_MODE_WINDING</c>,
		/// an array of geometry objects to add to the geometry group, and the number of elements in this array.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-creategeometrygroup HRESULT CreateGeometryGroup(
		// D2D1_FILL_MODE fillMode, ID2D1Geometry **geometries, UINT32 geometriesCount, ID2D1GeometryGroup **geometryGroup );
		new ID2D1GeometryGroup CreateGeometryGroup(D2D1_FILL_MODE fillMode, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] ID2D1Geometry[] geometries, uint geometriesCount);

		/// <summary>Transforms the specified geometry and stores the result as an ID2D1TransformedGeometry object.</summary>
		/// <param name="sourceGeometry">
		/// <para>Type: [in] <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to transform.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transformation to apply.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1TransformedGeometry**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the new transformed geometry object. The transformed geometry
		/// stores the result of transforming sourceGeometry by transform.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Like other resources, a transformed geometry inherits the resource space and threading policy of the factory that created it.
		/// This object is immutable.
		/// </para>
		/// <para>
		/// When stroking a transformed geometry with the DrawGeometry method, the stroke width is not affected by the transform applied to
		/// the geometry. The stroke width is only affected by the world transform.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createtransformedgeometry%28id2d1geometry_constd2d1_matrix_3x2_f_id2d1transformedgeometry%29
		// HRESULT CreateTransformedGeometry( ID2D1Geometry *sourceGeometry, const D2D1_MATRIX_3X2_F *transform, ID2D1TransformedGeometry
		// **transformedGeometry );
		new ID2D1TransformedGeometry CreateTransformedGeometry([In] ID2D1Geometry sourceGeometry, in D2D_MATRIX_3X2_F transform);

		/// <summary>Creates an empty ID2D1PathGeometry.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1PathGeometry**</c></para>
		/// <para>When this method returns, contains the address to a pointer to the path geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createpathgeometry HRESULT CreatePathGeometry(
		// ID2D1PathGeometry **pathGeometry );
		new ID2D1PathGeometry CreatePathGeometry();

		/// <summary>Creates an ID2D1StrokeStyle that describes start cap, dash pattern, and other features of a stroke.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <c>const D2D1_STROKE_STYLE_PROPERTIES</c></para>
		/// <para>A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length of a
		/// dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length of each
		/// dash and space in the dash pattern is the product of the element value in the array and the stroke width.
		/// </para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the dashes array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1StrokeStyle**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the stroke style created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createstrokestyle%28constd2d1_stroke_style_properties__constfloat_uint32_id2d1strokestyle%29
		// HRESULT CreateStrokeStyle( const D2D1_STROKE_STYLE_PROPERTIES &amp; strokeStyleProperties, const FLOAT *dashes, UINT32
		// dashesCount, ID2D1StrokeStyle **strokeStyle );
		new ID2D1StrokeStyle CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES strokeStyleProperties, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] dashes, uint dashesCount);

		/// <summary>
		/// Creates an ID2D1DrawingStateBlock that can be used with the SaveDrawingState and RestoreDrawingState methods of a render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <c>const D2D1_DRAWING_STATE_DESCRIPTION*</c></para>
		/// <para>A structure that contains antialiasing, transform, and tags information.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>Optional text parameters that indicate how text should be rendered.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DrawingStateBlock**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new drawing state block created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdrawingstateblock%28constd2d1_drawing_state_description_idwriterenderingparams_id2d1drawingstateblock%29
		// HRESULT CreateDrawingStateBlock( const D2D1_DRAWING_STATE_DESCRIPTION *drawingStateDescription, IDWriteRenderingParams
		// *textRenderingParams, ID2D1DrawingStateBlock **drawingStateBlock );
		new ID2D1DrawingStateBlock CreateDrawingStateBlock([In, Optional] StructPointer<D2D1_DRAWING_STATE_DESCRIPTION> drawingStateDescription, [In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="target">
		/// <para>Type: <c>IWICBitmap*</c></para>
		/// <para>The bitmap that receives the rendering output of the render target.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must use D2D1_FEATURE_LEVEL_DEFAULT for the <c>minLevel</c> member of the renderTargetProperties parameter with this method.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold onto them for the life of the application or until the
		/// D2DERR_RECREATE_TARGET error is received. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createwicbitmaprendertarget%28iwicbitmap_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateWicBitmapRenderTarget( IWICBitmap *target, const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties,
		// ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateWicBitmapRenderTarget([In] IWICBitmap target, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates an <c>ID2D1HwndRenderTarget</c>, a render target that renders to a window.</summary>
		/// <param name="renderTargetProperties">
		/// <para>[in] Type: <c>D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <param name="hwndRenderTargetProperties">
		/// <para>[in] Type: <c>D2D1_HWND_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>The window handle, initial size (in pixels), and present options.</para>
		/// </param>
		/// <returns>
		/// <para>[out] Type: <c>ID2D1HwndRenderTarget**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the <c>ID2D1HwndRenderTarget</c> object created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the <c>D2DERR_RECREATE_TARGET</c> error
		/// is received. When you receive this error, you need to recreate the render target (and any resources it created).
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd371275(v=vs.85) virtual HRESULT
		// CreateHwndRenderTarget( [in] D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, [in] D2D1_HWND_RENDER_TARGET_PROPERTIES
		// *hwndRenderTargetProperties, [out] ID2D1HwndRenderTarget **hwndRenderTarget ) = 0;
		new ID2D1HwndRenderTarget CreateHwndRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, in D2D1_HWND_RENDER_TARGET_PROPERTIES hwndRenderTargetProperties);

		/// <summary>Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.</summary>
		/// <param name="dxgiSurface">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>The IDXGISurface to which the render target will draw.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES &amp;</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To write to a Direct3D surface, you obtain an IDXGISurface and pass it to the CreateDxgiSurfaceRenderTarget method to create a
		/// DXGI surface render target; you can then use the DXGI surface render target to draw 2-D content to the DXGI surface.
		/// </para>
		/// <para>
		/// A DXGI surface render target is a type of ID2D1RenderTarget. Like other Direct2D render targets, you can use it to create
		/// resources and issue drawing commands.
		/// </para>
		/// <para>
		/// The DXGI surface render target and the DXGI surface must use the same DXGI format. If you specify the DXGI_FORMAT_UNKOWN format
		/// when you create the render target, it will automatically use the surface's format.
		/// </para>
		/// <para>The DXGI surface render target does not perform DXGI surface synchronization.</para>
		/// <para>
		/// For more information about creating and using DXGI surface render targets, see the Direct2D and Direct3D Interoperability Overview.
		/// </para>
		/// <para>
		/// To work with Direct2D, the Direct3D device that provides the IDXGISurface must be created with the
		/// <c>D3D10_CREATE_DEVICE_BGRA_SUPPORT</c> flag.
		/// </para>
		/// <para>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the render target's EndDraw method
		/// returns the D2DERR_RECREATE_TARGET error. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdxgisurfacerendertarget%28idxgisurface_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateDxgiSurfaceRenderTarget( IDXGISurface *dxgiSurface, const D2D1_RENDER_TARGET_PROPERTIES &amp;
		// renderTargetProperties, ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateDxgiSurfaceRenderTarget([In] IDXGISurface dxgiSurface, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.</summary>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. To enable the device context (DC) render target to work with GDI, set the DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM
		/// and the alpha mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>. For more information about pixel formats,
		/// see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DCRenderTarget**</c></para>
		/// <para>
		/// When this method returns, dcRenderTarget contains the address of the pointer to the ID2D1DCRenderTarget created by the method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before you can render with a DC render target, you must use the render target's BindDC method to associate it with a GDI DC. Do
		/// this for each different DC and whenever there is a change in the size of the area you want to draw to.
		/// </para>
		/// <para>
		/// To enable the DC render target to work with GDI, set the render target's DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM and alpha
		/// mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold on to them for the life of the application or until the render
		/// target's EndDraw method returns the D2DERR_RECREATE_TARGET error. When you receive this error, recreate the render target (and
		/// any resources it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdcrendertarget HRESULT CreateDCRenderTarget(
		// const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, ID2D1DCRenderTarget **dcRenderTarget );
		new ID2D1DCRenderTarget CreateDCRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a <c>ID2D1Device</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device</c>.</para>
		/// </param>
		/// <param name="d2dDevice">
		/// <para>Type: <b><c>ID2D1Device</c>**</b></para>
		/// <para>The requested <c>ID2D1Device</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device **d2dDevice );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device d2dDevice);

		/// <summary>Creates a <c>ID2D1StrokeStyle1</c> object.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <b>const <c>D2D1_STROKE_STYLE_PROPERTIES1</c>*</b></para>
		/// <para>The stroke style properties to apply.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <b>const <c>FLOAT</c>*</b></para>
		/// <para>An array of widths for the dashes and gaps.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the dash array.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <b>const <c>ID2D1StrokeStyle1</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created stroke style.</para>
		/// </param>
		/// <remarks>It is valid to specify a dash array only if D2D1_DASH_STYLE_CUSTOM is also specified.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createstrokestyle(constd2d1_stroke_style_properties1_constfloat_uint32_id2d1strokestyle1)
		// HRESULT CreateStrokeStyle( [in] const D2D1_STROKE_STYLE_PROPERTIES1 *strokeStyleProperties, [in] const FLOAT *dashes, UINT32
		// dashesCount, [out] ID2D1StrokeStyle1 **strokeStyle );
		new void CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES1 strokeStyleProperties,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[]? dashes, [Optional] uint dashesCount, out ID2D1StrokeStyle1 strokeStyle);

		/// <summary>Creates an <c>ID2D1PathGeometry1</c> object.</summary>
		/// <param name="pathGeometry">
		/// <para>Type: <b>const **</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created path geometry.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createpathgeometry HRESULT CreatePathGeometry(
		// [out] ID2D1PathGeometry1 **pathGeometry );
		new void CreatePathGeometry(out ID2D1PathGeometry1 pathGeometry);

		/// <summary>
		/// Creates a new drawing state block, this can be used in subsequent SaveDrawingState and RestoreDrawingState operations on the
		/// render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <b>const <c>D2D1_DRAWING_STATE_DESCRIPTION1</c>*</b></para>
		/// <para>The drawing state description structure.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>The DirectWrite rendering params interface.</para>
		/// </param>
		/// <param name="drawingStateBlock">
		/// <para>Type: <b><c>ID2D1DrawingStateBlock1</c>**</b></para>
		/// <para>The address of the newly created drawing state block.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdrawingstateblock(constd2d1_drawing_state_description1_idwriterenderingparams_id2d1drawingstateblock1)
		// HRESULT CreateDrawingStateBlock( [in, optional] const D2D1_DRAWING_STATE_DESCRIPTION1 *drawingStateDescription, [in, optional]
		// IDWriteRenderingParams *textRenderingParams, [out] ID2D1DrawingStateBlock1 **drawingStateBlock );
		new void CreateDrawingStateBlock([In, Optional] ManagedStructPointer<D2D1_DRAWING_STATE_DESCRIPTION1> drawingStateDescription,
			[In, Optional] IDWriteRenderingParams? textRenderingParams, out ID2D1DrawingStateBlock1 drawingStateBlock);

		/// <summary>Creates a new <c>ID2D1GdiMetafile</c> object that you can use to replay metafile content.</summary>
		/// <param name="metafileStream">
		/// <para>Type: <b>IStream*</b></para>
		/// <para>A stream object that has the metafile data.</para>
		/// </param>
		/// <param name="metafile">
		/// <para>Type: <b><c>ID2D1GdiMetafile</c>**</b></para>
		/// <para>The address of the newly created GDI metafile object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-creategdimetafile HRESULT CreateGdiMetafile(
		// [in] IStream *metafileStream, [out] ID2D1GdiMetafile **metafile );
		new void CreateGdiMetafile([In] IStream metafileStream, out ID2D1GdiMetafile metafile);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a stream.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b>IStream</b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <c>RegisterEffect</c> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <c>RegisterEffect</c> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory, derived
		/// device, and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstream HRESULT
		// RegisterEffectFromStream( [in] REFCLSID classId, [in] IStream *propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromStream(in Guid classId, [In] IStream propertyXml, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[] bindings, uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a string.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b><c>PCWSTR</c></b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <b>RegisterEffect</b> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <b>RegisterEffect</b> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory and
		/// derived device and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstring HRESULT
		// RegisterEffectFromString( [in] REFCLSID classId, [in] PCWSTR propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromString(in Guid classId, [MarshalAs(UnmanagedType.LPWStr)] string propertyXml,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[]? bindings, [Optional] uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Unregisters an effect within the factory instance that corresponds to the <i>classId</i> provided.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be unregistered.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// In order for the effect to be fully unloaded, you must call <b>UnregisterEffect</b> the same number of times that you have
		/// registered the effect.
		/// </para>
		/// <para>
		/// The <b>UnregisterEffect</b> method unregisters only those effects that are registered on the same factory. It cannot be used to
		/// unregister a built-in effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-unregistereffect HRESULT UnregisterEffect(
		// [in] REFCLSID classId );
		new void UnregisterEffect(in Guid classId);

		/// <summary>Returns the class IDs of the currently registered effects and global effects on this factory.</summary>
		/// <param name="effects">
		/// <para>Type: <b><c>CLSID</c>*</b></para>
		/// <para>When this method returns, contains an array of effects. <b>NULL</b> if no effects are retrieved.</para>
		/// </param>
		/// <param name="effectsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The capacity of the <i>effects</i> array.</para>
		/// </param>
		/// <param name="effectsReturned">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects copied into <i>effects</i>.</para>
		/// </param>
		/// <param name="effectsRegistered">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects currently registered in the system.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The set of class IDs will be atomically returned by the API. The set will not be interrupted by other threads registering or
		/// unregistering effects.
		/// </para>
		/// <para>
		/// If <i>effectsRegistered</i> is larger than <i>effectCount</i>, the supplied array will still be filled to capacity with the
		/// current set of registered effects. This method returns the CLSIDs for all global effects and all effects registered to this factory.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-getregisteredeffects HRESULT
		// GetRegisteredEffects( [out] CLSID *effects, UINT32 effectsCount, [out] UINT32 *effectsReturned, [out, optional] UINT32
		// *effectsRegistered );
		new void GetRegisteredEffects([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[]? effects, uint effectsCount,
			out uint effectsReturned, out uint effectsRegistered);

		/// <summary>Retrieves the properties of an effect.</summary>
		/// <param name="effectId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The ID of the effect to retrieve properties from.</para>
		/// </param>
		/// <param name="properties">
		/// <para>Type: <b><c>ID2D1Properties</c>**</b></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the property interface that can be used to query the metadata of
		/// the effect.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The returned effect properties will have all the mutable properties for the effect set to a default of <b>NULL</b>, or an empty value.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Value types will be zero-filled.</description>
		/// </item>
		/// <item>
		/// <description>Blob and string types will be zero-length.</description>
		/// </item>
		/// <item>
		/// <description>Array types will have length 1 and the element of the array will conform to the previous rules.</description>
		/// </item>
		/// </list>
		/// <para>This method cannot be used to return the properties for any effect not visible to <c>ID2D1DeviceContext::CreateEffect</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-geteffectproperties HRESULT
		// GetEffectProperties( [in] REFCLSID effectId, [out] ID2D1Properties **properties );
		new void GetEffectProperties(in Guid effectId, out ID2D1Properties properties);

		/// <summary>Creates an <c>ID2D1Device1</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device1</c>.</para>
		/// </param>
		/// <param name="d2dDevice1">
		/// <para>Type: <b><c>ID2D1Device1</c>**</b></para>
		/// <para>The requested <c>ID2D1Device1</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device1</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1factory2-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device1 **d2dDevice1 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device1 d2dDevice1);

		/// <summary>Creates an <c>ID2D1Device2</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device2</c>.</para>
		/// </param>
		/// <param name="d2dDevice2">
		/// <para>Type: <b><c>ID2D1Device2</c>**</b></para>
		/// <para>The requested <c>ID2D1Device2</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory3-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device2 **d2dDevice2 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device2 d2dDevice2);

		/// <summary>Creates an <c>ID2D1Device3</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The IDXGIDevice object used when creating the <c>ID2D1Device3</c>.</para>
		/// </param>
		/// <param name="d2dDevice3">
		/// <para>Type: <b><c>ID2D1Device3</c>**</b></para>
		/// <para>The requested <c>ID2D1Device3</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory4-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device3 **d2dDevice3 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device3 d2dDevice3);

		/// <summary>Creates an <c>ID2D1Device4</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The IDXGIDevice object used when creating the <c>ID2D1Device4</c>.</para>
		/// </param>
		/// <param name="d2dDevice4">
		/// <para>Type: <b><c>ID2D1Device4</c>**</b></para>
		/// <para>The requested <c>ID2D1Device4</c> object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory5-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device4 **d2dDevice4 );
		void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device4 d2dDevice4);
	}

	/// <summary>Creates Direct2D resources. This interface also enables the creation of ID2D1Device5 objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1factory6
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1Factory6")]
	[ComImport, Guid("F9976F46-F642-44C1-97CA-DA32EA2A2635"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Factory6 : ID2D1Factory5
	{
		/// <summary>Forces the factory to refresh any system defaults that it might have changed since factory creation.</summary>
		/// <remarks>You should call this method before calling the GetDesktopDpi method, to ensure that the system DPI is current.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-reloadsystemmetrics HRESULT ReloadSystemMetrics();
		new void ReloadSystemMetrics();

		/// <summary>Retrieves the current desktop dots per inch (DPI). To refresh this value, call ReloadSystemMetrics.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the horizontal DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the vertical DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Use this method to obtain the system DPI when setting physical pixel values, such as when you specify the size of a window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-getdesktopdpi void GetDesktopDpi( FLOAT *dpiX, FLOAT
		// *dpiY );
		[PreserveSig, Obsolete("ID2D1Factory::GetDesktopDpi is deprecated. For a desktop app, instead use GetDpiForWindow. For a Universal Windows Platform (UWP) app, instead use DisplayInformation::LogicalDpi.")]
		new void GetDesktopDpi(out float dpiX, out float dpiY);

		/// <summary>Creates an ID2D1RectangleGeometry.</summary>
		/// <param name="rectangle">
		/// <para>Type: [in] <c>const D2D1_RECT_F*</c></para>
		/// <para>The coordinates of the rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createrectanglegeometry%28constd2d1_rect_f_id2d1rectanglegeometry%29
		// HRESULT CreateRectangleGeometry( const D2D1_RECT_F *rectangle, ID2D1RectangleGeometry **rectangleGeometry );
		new ID2D1RectangleGeometry CreateRectangleGeometry(in D2D_RECT_F rectangle);

		/// <summary>Creates an ID2D1RoundedRectangleGeometry.</summary>
		/// <param name="roundedRectangle">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT*</c></para>
		/// <para>The coordinates and corner radii of the rounded rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RoundedRectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rounded rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createroundedrectanglegeometry%28constd2d1_rounded_rect_id2d1roundedrectanglegeometry%29
		// HRESULT CreateRoundedRectangleGeometry( const D2D1_ROUNDED_RECT *roundedRectangle, ID2D1RoundedRectangleGeometry
		// **roundedRectangleGeometry );
		new ID2D1RoundedRectangleGeometry CreateRoundedRectangleGeometry(in D2D1_ROUNDED_RECT roundedRectangle);

		/// <summary>Creates an ID2D1EllipseGeometry.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>A value that describes the center point, x-radius, and y-radius of the ellipse geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1EllipseGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ellipse geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createellipsegeometry%28constd2d1_ellipse__id2d1ellipsegeometry%29
		// HRESULT CreateEllipseGeometry( const D2D1_ELLIPSE &amp; ellipse, ID2D1EllipseGeometry **ellipseGeometry );
		new ID2D1EllipseGeometry CreateEllipseGeometry(in D2D1_ELLIPSE ellipse);

		/// <summary>Creates an ID2D1GeometryGroup, which is an object that holds other geometries.</summary>
		/// <param name="fillMode">
		/// <para>Type: <c>D2D1_FILL_MODE</c></para>
		/// <para>A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</para>
		/// </param>
		/// <param name="geometries">
		/// <para>Type: <c>ID2D1Geometry**</c></para>
		/// <para>
		/// An array containing the geometry objects to add to the geometry group. The number of elements in this array is indicated by the
		/// geometriesCount parameter.
		/// </para>
		/// </param>
		/// <param name="geometriesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in geometries.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1GeometryGroup**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the geometry group created by this method.</para>
		/// </returns>
		/// <remarks>
		/// Geometry groups are a convenient way to group several geometries simultaneously so all figures of several distinct geometries
		/// are concatenated into one. To create a ID2D1GeometryGroup object, call the <c>CreateGeometryGroup</c> method on the ID2D1Factory
		/// object, passing in the fillMode with possible values of D2D1_FILL_MODE_ALTERNATE (alternate) and <c>D2D1_FILL_MODE_WINDING</c>,
		/// an array of geometry objects to add to the geometry group, and the number of elements in this array.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-creategeometrygroup HRESULT CreateGeometryGroup(
		// D2D1_FILL_MODE fillMode, ID2D1Geometry **geometries, UINT32 geometriesCount, ID2D1GeometryGroup **geometryGroup );
		new ID2D1GeometryGroup CreateGeometryGroup(D2D1_FILL_MODE fillMode, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] ID2D1Geometry[] geometries, uint geometriesCount);

		/// <summary>Transforms the specified geometry and stores the result as an ID2D1TransformedGeometry object.</summary>
		/// <param name="sourceGeometry">
		/// <para>Type: [in] <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to transform.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transformation to apply.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1TransformedGeometry**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the new transformed geometry object. The transformed geometry
		/// stores the result of transforming sourceGeometry by transform.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Like other resources, a transformed geometry inherits the resource space and threading policy of the factory that created it.
		/// This object is immutable.
		/// </para>
		/// <para>
		/// When stroking a transformed geometry with the DrawGeometry method, the stroke width is not affected by the transform applied to
		/// the geometry. The stroke width is only affected by the world transform.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createtransformedgeometry%28id2d1geometry_constd2d1_matrix_3x2_f_id2d1transformedgeometry%29
		// HRESULT CreateTransformedGeometry( ID2D1Geometry *sourceGeometry, const D2D1_MATRIX_3X2_F *transform, ID2D1TransformedGeometry
		// **transformedGeometry );
		new ID2D1TransformedGeometry CreateTransformedGeometry([In] ID2D1Geometry sourceGeometry, in D2D_MATRIX_3X2_F transform);

		/// <summary>Creates an empty ID2D1PathGeometry.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1PathGeometry**</c></para>
		/// <para>When this method returns, contains the address to a pointer to the path geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createpathgeometry HRESULT CreatePathGeometry(
		// ID2D1PathGeometry **pathGeometry );
		new ID2D1PathGeometry CreatePathGeometry();

		/// <summary>Creates an ID2D1StrokeStyle that describes start cap, dash pattern, and other features of a stroke.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <c>const D2D1_STROKE_STYLE_PROPERTIES</c></para>
		/// <para>A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length of a
		/// dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length of each
		/// dash and space in the dash pattern is the product of the element value in the array and the stroke width.
		/// </para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the dashes array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1StrokeStyle**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the stroke style created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createstrokestyle%28constd2d1_stroke_style_properties__constfloat_uint32_id2d1strokestyle%29
		// HRESULT CreateStrokeStyle( const D2D1_STROKE_STYLE_PROPERTIES &amp; strokeStyleProperties, const FLOAT *dashes, UINT32
		// dashesCount, ID2D1StrokeStyle **strokeStyle );
		new ID2D1StrokeStyle CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES strokeStyleProperties, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] dashes, uint dashesCount);

		/// <summary>
		/// Creates an ID2D1DrawingStateBlock that can be used with the SaveDrawingState and RestoreDrawingState methods of a render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <c>const D2D1_DRAWING_STATE_DESCRIPTION*</c></para>
		/// <para>A structure that contains antialiasing, transform, and tags information.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>Optional text parameters that indicate how text should be rendered.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DrawingStateBlock**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new drawing state block created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdrawingstateblock%28constd2d1_drawing_state_description_idwriterenderingparams_id2d1drawingstateblock%29
		// HRESULT CreateDrawingStateBlock( const D2D1_DRAWING_STATE_DESCRIPTION *drawingStateDescription, IDWriteRenderingParams
		// *textRenderingParams, ID2D1DrawingStateBlock **drawingStateBlock );
		new ID2D1DrawingStateBlock CreateDrawingStateBlock([In, Optional] StructPointer<D2D1_DRAWING_STATE_DESCRIPTION> drawingStateDescription, [In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="target">
		/// <para>Type: <c>IWICBitmap*</c></para>
		/// <para>The bitmap that receives the rendering output of the render target.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must use D2D1_FEATURE_LEVEL_DEFAULT for the <c>minLevel</c> member of the renderTargetProperties parameter with this method.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold onto them for the life of the application or until the
		/// D2DERR_RECREATE_TARGET error is received. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createwicbitmaprendertarget%28iwicbitmap_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateWicBitmapRenderTarget( IWICBitmap *target, const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties,
		// ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateWicBitmapRenderTarget([In] IWICBitmap target, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates an <c>ID2D1HwndRenderTarget</c>, a render target that renders to a window.</summary>
		/// <param name="renderTargetProperties">
		/// <para>[in] Type: <c>D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <param name="hwndRenderTargetProperties">
		/// <para>[in] Type: <c>D2D1_HWND_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>The window handle, initial size (in pixels), and present options.</para>
		/// </param>
		/// <returns>
		/// <para>[out] Type: <c>ID2D1HwndRenderTarget**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the <c>ID2D1HwndRenderTarget</c> object created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the <c>D2DERR_RECREATE_TARGET</c> error
		/// is received. When you receive this error, you need to recreate the render target (and any resources it created).
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd371275(v=vs.85) virtual HRESULT
		// CreateHwndRenderTarget( [in] D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, [in] D2D1_HWND_RENDER_TARGET_PROPERTIES
		// *hwndRenderTargetProperties, [out] ID2D1HwndRenderTarget **hwndRenderTarget ) = 0;
		new ID2D1HwndRenderTarget CreateHwndRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, in D2D1_HWND_RENDER_TARGET_PROPERTIES hwndRenderTargetProperties);

		/// <summary>Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.</summary>
		/// <param name="dxgiSurface">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>The IDXGISurface to which the render target will draw.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES &amp;</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To write to a Direct3D surface, you obtain an IDXGISurface and pass it to the CreateDxgiSurfaceRenderTarget method to create a
		/// DXGI surface render target; you can then use the DXGI surface render target to draw 2-D content to the DXGI surface.
		/// </para>
		/// <para>
		/// A DXGI surface render target is a type of ID2D1RenderTarget. Like other Direct2D render targets, you can use it to create
		/// resources and issue drawing commands.
		/// </para>
		/// <para>
		/// The DXGI surface render target and the DXGI surface must use the same DXGI format. If you specify the DXGI_FORMAT_UNKOWN format
		/// when you create the render target, it will automatically use the surface's format.
		/// </para>
		/// <para>The DXGI surface render target does not perform DXGI surface synchronization.</para>
		/// <para>
		/// For more information about creating and using DXGI surface render targets, see the Direct2D and Direct3D Interoperability Overview.
		/// </para>
		/// <para>
		/// To work with Direct2D, the Direct3D device that provides the IDXGISurface must be created with the
		/// <c>D3D10_CREATE_DEVICE_BGRA_SUPPORT</c> flag.
		/// </para>
		/// <para>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the render target's EndDraw method
		/// returns the D2DERR_RECREATE_TARGET error. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdxgisurfacerendertarget%28idxgisurface_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateDxgiSurfaceRenderTarget( IDXGISurface *dxgiSurface, const D2D1_RENDER_TARGET_PROPERTIES &amp;
		// renderTargetProperties, ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateDxgiSurfaceRenderTarget([In] IDXGISurface dxgiSurface, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.</summary>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. To enable the device context (DC) render target to work with GDI, set the DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM
		/// and the alpha mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>. For more information about pixel formats,
		/// see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DCRenderTarget**</c></para>
		/// <para>
		/// When this method returns, dcRenderTarget contains the address of the pointer to the ID2D1DCRenderTarget created by the method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before you can render with a DC render target, you must use the render target's BindDC method to associate it with a GDI DC. Do
		/// this for each different DC and whenever there is a change in the size of the area you want to draw to.
		/// </para>
		/// <para>
		/// To enable the DC render target to work with GDI, set the render target's DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM and alpha
		/// mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold on to them for the life of the application or until the render
		/// target's EndDraw method returns the D2DERR_RECREATE_TARGET error. When you receive this error, recreate the render target (and
		/// any resources it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdcrendertarget HRESULT CreateDCRenderTarget(
		// const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, ID2D1DCRenderTarget **dcRenderTarget );
		new ID2D1DCRenderTarget CreateDCRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a <c>ID2D1Device</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device</c>.</para>
		/// </param>
		/// <param name="d2dDevice">
		/// <para>Type: <b><c>ID2D1Device</c>**</b></para>
		/// <para>The requested <c>ID2D1Device</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device **d2dDevice );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device d2dDevice);

		/// <summary>Creates a <c>ID2D1StrokeStyle1</c> object.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <b>const <c>D2D1_STROKE_STYLE_PROPERTIES1</c>*</b></para>
		/// <para>The stroke style properties to apply.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <b>const <c>FLOAT</c>*</b></para>
		/// <para>An array of widths for the dashes and gaps.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the dash array.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <b>const <c>ID2D1StrokeStyle1</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created stroke style.</para>
		/// </param>
		/// <remarks>It is valid to specify a dash array only if D2D1_DASH_STYLE_CUSTOM is also specified.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createstrokestyle(constd2d1_stroke_style_properties1_constfloat_uint32_id2d1strokestyle1)
		// HRESULT CreateStrokeStyle( [in] const D2D1_STROKE_STYLE_PROPERTIES1 *strokeStyleProperties, [in] const FLOAT *dashes, UINT32
		// dashesCount, [out] ID2D1StrokeStyle1 **strokeStyle );
		new void CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES1 strokeStyleProperties,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[]? dashes, [Optional] uint dashesCount, out ID2D1StrokeStyle1 strokeStyle);

		/// <summary>Creates an <c>ID2D1PathGeometry1</c> object.</summary>
		/// <param name="pathGeometry">
		/// <para>Type: <b>const **</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created path geometry.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createpathgeometry HRESULT CreatePathGeometry(
		// [out] ID2D1PathGeometry1 **pathGeometry );
		new void CreatePathGeometry(out ID2D1PathGeometry1 pathGeometry);

		/// <summary>
		/// Creates a new drawing state block, this can be used in subsequent SaveDrawingState and RestoreDrawingState operations on the
		/// render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <b>const <c>D2D1_DRAWING_STATE_DESCRIPTION1</c>*</b></para>
		/// <para>The drawing state description structure.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>The DirectWrite rendering params interface.</para>
		/// </param>
		/// <param name="drawingStateBlock">
		/// <para>Type: <b><c>ID2D1DrawingStateBlock1</c>**</b></para>
		/// <para>The address of the newly created drawing state block.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdrawingstateblock(constd2d1_drawing_state_description1_idwriterenderingparams_id2d1drawingstateblock1)
		// HRESULT CreateDrawingStateBlock( [in, optional] const D2D1_DRAWING_STATE_DESCRIPTION1 *drawingStateDescription, [in, optional]
		// IDWriteRenderingParams *textRenderingParams, [out] ID2D1DrawingStateBlock1 **drawingStateBlock );
		new void CreateDrawingStateBlock([In, Optional] ManagedStructPointer<D2D1_DRAWING_STATE_DESCRIPTION1> drawingStateDescription,
			[In, Optional] IDWriteRenderingParams? textRenderingParams, out ID2D1DrawingStateBlock1 drawingStateBlock);

		/// <summary>Creates a new <c>ID2D1GdiMetafile</c> object that you can use to replay metafile content.</summary>
		/// <param name="metafileStream">
		/// <para>Type: <b>IStream*</b></para>
		/// <para>A stream object that has the metafile data.</para>
		/// </param>
		/// <param name="metafile">
		/// <para>Type: <b><c>ID2D1GdiMetafile</c>**</b></para>
		/// <para>The address of the newly created GDI metafile object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-creategdimetafile HRESULT CreateGdiMetafile(
		// [in] IStream *metafileStream, [out] ID2D1GdiMetafile **metafile );
		new void CreateGdiMetafile([In] IStream metafileStream, out ID2D1GdiMetafile metafile);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a stream.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b>IStream</b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <c>RegisterEffect</c> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <c>RegisterEffect</c> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory, derived
		/// device, and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstream HRESULT
		// RegisterEffectFromStream( [in] REFCLSID classId, [in] IStream *propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromStream(in Guid classId, [In] IStream propertyXml, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[] bindings, uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a string.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b><c>PCWSTR</c></b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <b>RegisterEffect</b> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <b>RegisterEffect</b> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory and
		/// derived device and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstring HRESULT
		// RegisterEffectFromString( [in] REFCLSID classId, [in] PCWSTR propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromString(in Guid classId, [MarshalAs(UnmanagedType.LPWStr)] string propertyXml,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[]? bindings, [Optional] uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Unregisters an effect within the factory instance that corresponds to the <i>classId</i> provided.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be unregistered.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// In order for the effect to be fully unloaded, you must call <b>UnregisterEffect</b> the same number of times that you have
		/// registered the effect.
		/// </para>
		/// <para>
		/// The <b>UnregisterEffect</b> method unregisters only those effects that are registered on the same factory. It cannot be used to
		/// unregister a built-in effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-unregistereffect HRESULT UnregisterEffect(
		// [in] REFCLSID classId );
		new void UnregisterEffect(in Guid classId);

		/// <summary>Returns the class IDs of the currently registered effects and global effects on this factory.</summary>
		/// <param name="effects">
		/// <para>Type: <b><c>CLSID</c>*</b></para>
		/// <para>When this method returns, contains an array of effects. <b>NULL</b> if no effects are retrieved.</para>
		/// </param>
		/// <param name="effectsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The capacity of the <i>effects</i> array.</para>
		/// </param>
		/// <param name="effectsReturned">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects copied into <i>effects</i>.</para>
		/// </param>
		/// <param name="effectsRegistered">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects currently registered in the system.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The set of class IDs will be atomically returned by the API. The set will not be interrupted by other threads registering or
		/// unregistering effects.
		/// </para>
		/// <para>
		/// If <i>effectsRegistered</i> is larger than <i>effectCount</i>, the supplied array will still be filled to capacity with the
		/// current set of registered effects. This method returns the CLSIDs for all global effects and all effects registered to this factory.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-getregisteredeffects HRESULT
		// GetRegisteredEffects( [out] CLSID *effects, UINT32 effectsCount, [out] UINT32 *effectsReturned, [out, optional] UINT32
		// *effectsRegistered );
		new void GetRegisteredEffects([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[]? effects, uint effectsCount,
			out uint effectsReturned, out uint effectsRegistered);

		/// <summary>Retrieves the properties of an effect.</summary>
		/// <param name="effectId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The ID of the effect to retrieve properties from.</para>
		/// </param>
		/// <param name="properties">
		/// <para>Type: <b><c>ID2D1Properties</c>**</b></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the property interface that can be used to query the metadata of
		/// the effect.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The returned effect properties will have all the mutable properties for the effect set to a default of <b>NULL</b>, or an empty value.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Value types will be zero-filled.</description>
		/// </item>
		/// <item>
		/// <description>Blob and string types will be zero-length.</description>
		/// </item>
		/// <item>
		/// <description>Array types will have length 1 and the element of the array will conform to the previous rules.</description>
		/// </item>
		/// </list>
		/// <para>This method cannot be used to return the properties for any effect not visible to <c>ID2D1DeviceContext::CreateEffect</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-geteffectproperties HRESULT
		// GetEffectProperties( [in] REFCLSID effectId, [out] ID2D1Properties **properties );
		new void GetEffectProperties(in Guid effectId, out ID2D1Properties properties);

		/// <summary>Creates an <c>ID2D1Device1</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device1</c>.</para>
		/// </param>
		/// <param name="d2dDevice1">
		/// <para>Type: <b><c>ID2D1Device1</c>**</b></para>
		/// <para>The requested <c>ID2D1Device1</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device1</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1factory2-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device1 **d2dDevice1 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device1 d2dDevice1);

		/// <summary>Creates an <c>ID2D1Device2</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device2</c>.</para>
		/// </param>
		/// <param name="d2dDevice2">
		/// <para>Type: <b><c>ID2D1Device2</c>**</b></para>
		/// <para>The requested <c>ID2D1Device2</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory3-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device2 **d2dDevice2 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device2 d2dDevice2);

		/// <summary>Creates an <c>ID2D1Device3</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The IDXGIDevice object used when creating the <c>ID2D1Device3</c>.</para>
		/// </param>
		/// <param name="d2dDevice3">
		/// <para>Type: <b><c>ID2D1Device3</c>**</b></para>
		/// <para>The requested <c>ID2D1Device3</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory4-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device3 **d2dDevice3 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device3 d2dDevice3);

		/// <summary>Creates an <c>ID2D1Device4</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The IDXGIDevice object used when creating the <c>ID2D1Device4</c>.</para>
		/// </param>
		/// <param name="d2dDevice4">
		/// <para>Type: <b><c>ID2D1Device4</c>**</b></para>
		/// <para>The requested <c>ID2D1Device4</c> object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory5-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device4 **d2dDevice4 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device4 d2dDevice4);

		/// <summary>Creates a new Direct2D device from the given IDXGIDevice.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b>IDXGIDevice*</b></para>
		/// <para>The IDXGIDevice to create the Direct2D device from.</para>
		/// </param>
		/// <param name="d2dDevice5">
		/// <para>Type: <b>ID2D1Device5**</b></para>
		/// <para>The created device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory6-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device5 **d2dDevice5 );
		void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device5 d2dDevice5);
	}

	/// <summary>
	/// Creates Direct2D resources. This interface performs all the same functions as the <c>ID2D1Factory6</c> interface, plus it enables
	/// the creation of <c>ID2D1Device6</c> objects.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1factory7
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1Factory7")]
	[ComImport, Guid("BDC2BDD3-B96C-4DE6-BDF7-99D4745454DE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Factory7 : ID2D1Factory6
	{
		/// <summary>Forces the factory to refresh any system defaults that it might have changed since factory creation.</summary>
		/// <remarks>You should call this method before calling the GetDesktopDpi method, to ensure that the system DPI is current.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-reloadsystemmetrics HRESULT ReloadSystemMetrics();
		new void ReloadSystemMetrics();

		/// <summary>Retrieves the current desktop dots per inch (DPI). To refresh this value, call ReloadSystemMetrics.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the horizontal DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the vertical DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Use this method to obtain the system DPI when setting physical pixel values, such as when you specify the size of a window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-getdesktopdpi void GetDesktopDpi( FLOAT *dpiX, FLOAT
		// *dpiY );
		[PreserveSig, Obsolete("ID2D1Factory::GetDesktopDpi is deprecated. For a desktop app, instead use GetDpiForWindow. For a Universal Windows Platform (UWP) app, instead use DisplayInformation::LogicalDpi.")]
		new void GetDesktopDpi(out float dpiX, out float dpiY);

		/// <summary>Creates an ID2D1RectangleGeometry.</summary>
		/// <param name="rectangle">
		/// <para>Type: [in] <c>const D2D1_RECT_F*</c></para>
		/// <para>The coordinates of the rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createrectanglegeometry%28constd2d1_rect_f_id2d1rectanglegeometry%29
		// HRESULT CreateRectangleGeometry( const D2D1_RECT_F *rectangle, ID2D1RectangleGeometry **rectangleGeometry );
		new ID2D1RectangleGeometry CreateRectangleGeometry(in D2D_RECT_F rectangle);

		/// <summary>Creates an ID2D1RoundedRectangleGeometry.</summary>
		/// <param name="roundedRectangle">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT*</c></para>
		/// <para>The coordinates and corner radii of the rounded rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RoundedRectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rounded rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createroundedrectanglegeometry%28constd2d1_rounded_rect_id2d1roundedrectanglegeometry%29
		// HRESULT CreateRoundedRectangleGeometry( const D2D1_ROUNDED_RECT *roundedRectangle, ID2D1RoundedRectangleGeometry
		// **roundedRectangleGeometry );
		new ID2D1RoundedRectangleGeometry CreateRoundedRectangleGeometry(in D2D1_ROUNDED_RECT roundedRectangle);

		/// <summary>Creates an ID2D1EllipseGeometry.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>A value that describes the center point, x-radius, and y-radius of the ellipse geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1EllipseGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ellipse geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createellipsegeometry%28constd2d1_ellipse__id2d1ellipsegeometry%29
		// HRESULT CreateEllipseGeometry( const D2D1_ELLIPSE &amp; ellipse, ID2D1EllipseGeometry **ellipseGeometry );
		new ID2D1EllipseGeometry CreateEllipseGeometry(in D2D1_ELLIPSE ellipse);

		/// <summary>Creates an ID2D1GeometryGroup, which is an object that holds other geometries.</summary>
		/// <param name="fillMode">
		/// <para>Type: <c>D2D1_FILL_MODE</c></para>
		/// <para>A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</para>
		/// </param>
		/// <param name="geometries">
		/// <para>Type: <c>ID2D1Geometry**</c></para>
		/// <para>
		/// An array containing the geometry objects to add to the geometry group. The number of elements in this array is indicated by the
		/// geometriesCount parameter.
		/// </para>
		/// </param>
		/// <param name="geometriesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in geometries.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1GeometryGroup**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the geometry group created by this method.</para>
		/// </returns>
		/// <remarks>
		/// Geometry groups are a convenient way to group several geometries simultaneously so all figures of several distinct geometries
		/// are concatenated into one. To create a ID2D1GeometryGroup object, call the <c>CreateGeometryGroup</c> method on the ID2D1Factory
		/// object, passing in the fillMode with possible values of D2D1_FILL_MODE_ALTERNATE (alternate) and <c>D2D1_FILL_MODE_WINDING</c>,
		/// an array of geometry objects to add to the geometry group, and the number of elements in this array.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-creategeometrygroup HRESULT CreateGeometryGroup(
		// D2D1_FILL_MODE fillMode, ID2D1Geometry **geometries, UINT32 geometriesCount, ID2D1GeometryGroup **geometryGroup );
		new ID2D1GeometryGroup CreateGeometryGroup(D2D1_FILL_MODE fillMode, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] ID2D1Geometry[] geometries, uint geometriesCount);

		/// <summary>Transforms the specified geometry and stores the result as an ID2D1TransformedGeometry object.</summary>
		/// <param name="sourceGeometry">
		/// <para>Type: [in] <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to transform.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transformation to apply.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1TransformedGeometry**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the new transformed geometry object. The transformed geometry
		/// stores the result of transforming sourceGeometry by transform.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Like other resources, a transformed geometry inherits the resource space and threading policy of the factory that created it.
		/// This object is immutable.
		/// </para>
		/// <para>
		/// When stroking a transformed geometry with the DrawGeometry method, the stroke width is not affected by the transform applied to
		/// the geometry. The stroke width is only affected by the world transform.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createtransformedgeometry%28id2d1geometry_constd2d1_matrix_3x2_f_id2d1transformedgeometry%29
		// HRESULT CreateTransformedGeometry( ID2D1Geometry *sourceGeometry, const D2D1_MATRIX_3X2_F *transform, ID2D1TransformedGeometry
		// **transformedGeometry );
		new ID2D1TransformedGeometry CreateTransformedGeometry([In] ID2D1Geometry sourceGeometry, in D2D_MATRIX_3X2_F transform);

		/// <summary>Creates an empty ID2D1PathGeometry.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1PathGeometry**</c></para>
		/// <para>When this method returns, contains the address to a pointer to the path geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createpathgeometry HRESULT CreatePathGeometry(
		// ID2D1PathGeometry **pathGeometry );
		new ID2D1PathGeometry CreatePathGeometry();

		/// <summary>Creates an ID2D1StrokeStyle that describes start cap, dash pattern, and other features of a stroke.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <c>const D2D1_STROKE_STYLE_PROPERTIES</c></para>
		/// <para>A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length of a
		/// dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length of each
		/// dash and space in the dash pattern is the product of the element value in the array and the stroke width.
		/// </para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the dashes array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1StrokeStyle**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the stroke style created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createstrokestyle%28constd2d1_stroke_style_properties__constfloat_uint32_id2d1strokestyle%29
		// HRESULT CreateStrokeStyle( const D2D1_STROKE_STYLE_PROPERTIES &amp; strokeStyleProperties, const FLOAT *dashes, UINT32
		// dashesCount, ID2D1StrokeStyle **strokeStyle );
		new ID2D1StrokeStyle CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES strokeStyleProperties, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] dashes, uint dashesCount);

		/// <summary>
		/// Creates an ID2D1DrawingStateBlock that can be used with the SaveDrawingState and RestoreDrawingState methods of a render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <c>const D2D1_DRAWING_STATE_DESCRIPTION*</c></para>
		/// <para>A structure that contains antialiasing, transform, and tags information.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>Optional text parameters that indicate how text should be rendered.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DrawingStateBlock**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new drawing state block created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdrawingstateblock%28constd2d1_drawing_state_description_idwriterenderingparams_id2d1drawingstateblock%29
		// HRESULT CreateDrawingStateBlock( const D2D1_DRAWING_STATE_DESCRIPTION *drawingStateDescription, IDWriteRenderingParams
		// *textRenderingParams, ID2D1DrawingStateBlock **drawingStateBlock );
		new ID2D1DrawingStateBlock CreateDrawingStateBlock([In, Optional] StructPointer<D2D1_DRAWING_STATE_DESCRIPTION> drawingStateDescription, [In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="target">
		/// <para>Type: <c>IWICBitmap*</c></para>
		/// <para>The bitmap that receives the rendering output of the render target.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must use D2D1_FEATURE_LEVEL_DEFAULT for the <c>minLevel</c> member of the renderTargetProperties parameter with this method.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold onto them for the life of the application or until the
		/// D2DERR_RECREATE_TARGET error is received. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createwicbitmaprendertarget%28iwicbitmap_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateWicBitmapRenderTarget( IWICBitmap *target, const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties,
		// ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateWicBitmapRenderTarget([In] IWICBitmap target, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates an <c>ID2D1HwndRenderTarget</c>, a render target that renders to a window.</summary>
		/// <param name="renderTargetProperties">
		/// <para>[in] Type: <c>D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <param name="hwndRenderTargetProperties">
		/// <para>[in] Type: <c>D2D1_HWND_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>The window handle, initial size (in pixels), and present options.</para>
		/// </param>
		/// <returns>
		/// <para>[out] Type: <c>ID2D1HwndRenderTarget**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the <c>ID2D1HwndRenderTarget</c> object created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the <c>D2DERR_RECREATE_TARGET</c> error
		/// is received. When you receive this error, you need to recreate the render target (and any resources it created).
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd371275(v=vs.85) virtual HRESULT
		// CreateHwndRenderTarget( [in] D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, [in] D2D1_HWND_RENDER_TARGET_PROPERTIES
		// *hwndRenderTargetProperties, [out] ID2D1HwndRenderTarget **hwndRenderTarget ) = 0;
		new ID2D1HwndRenderTarget CreateHwndRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, in D2D1_HWND_RENDER_TARGET_PROPERTIES hwndRenderTargetProperties);

		/// <summary>Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.</summary>
		/// <param name="dxgiSurface">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>The IDXGISurface to which the render target will draw.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES &amp;</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To write to a Direct3D surface, you obtain an IDXGISurface and pass it to the CreateDxgiSurfaceRenderTarget method to create a
		/// DXGI surface render target; you can then use the DXGI surface render target to draw 2-D content to the DXGI surface.
		/// </para>
		/// <para>
		/// A DXGI surface render target is a type of ID2D1RenderTarget. Like other Direct2D render targets, you can use it to create
		/// resources and issue drawing commands.
		/// </para>
		/// <para>
		/// The DXGI surface render target and the DXGI surface must use the same DXGI format. If you specify the DXGI_FORMAT_UNKOWN format
		/// when you create the render target, it will automatically use the surface's format.
		/// </para>
		/// <para>The DXGI surface render target does not perform DXGI surface synchronization.</para>
		/// <para>
		/// For more information about creating and using DXGI surface render targets, see the Direct2D and Direct3D Interoperability Overview.
		/// </para>
		/// <para>
		/// To work with Direct2D, the Direct3D device that provides the IDXGISurface must be created with the
		/// <c>D3D10_CREATE_DEVICE_BGRA_SUPPORT</c> flag.
		/// </para>
		/// <para>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the render target's EndDraw method
		/// returns the D2DERR_RECREATE_TARGET error. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdxgisurfacerendertarget%28idxgisurface_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateDxgiSurfaceRenderTarget( IDXGISurface *dxgiSurface, const D2D1_RENDER_TARGET_PROPERTIES &amp;
		// renderTargetProperties, ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateDxgiSurfaceRenderTarget([In] IDXGISurface dxgiSurface, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.</summary>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. To enable the device context (DC) render target to work with GDI, set the DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM
		/// and the alpha mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>. For more information about pixel formats,
		/// see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DCRenderTarget**</c></para>
		/// <para>
		/// When this method returns, dcRenderTarget contains the address of the pointer to the ID2D1DCRenderTarget created by the method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before you can render with a DC render target, you must use the render target's BindDC method to associate it with a GDI DC. Do
		/// this for each different DC and whenever there is a change in the size of the area you want to draw to.
		/// </para>
		/// <para>
		/// To enable the DC render target to work with GDI, set the render target's DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM and alpha
		/// mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold on to them for the life of the application or until the render
		/// target's EndDraw method returns the D2DERR_RECREATE_TARGET error. When you receive this error, recreate the render target (and
		/// any resources it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdcrendertarget HRESULT CreateDCRenderTarget(
		// const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, ID2D1DCRenderTarget **dcRenderTarget );
		new ID2D1DCRenderTarget CreateDCRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a <c>ID2D1Device</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device</c>.</para>
		/// </param>
		/// <param name="d2dDevice">
		/// <para>Type: <b><c>ID2D1Device</c>**</b></para>
		/// <para>The requested <c>ID2D1Device</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device **d2dDevice );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device d2dDevice);

		/// <summary>Creates a <c>ID2D1StrokeStyle1</c> object.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <b>const <c>D2D1_STROKE_STYLE_PROPERTIES1</c>*</b></para>
		/// <para>The stroke style properties to apply.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <b>const <c>FLOAT</c>*</b></para>
		/// <para>An array of widths for the dashes and gaps.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the dash array.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <b>const <c>ID2D1StrokeStyle1</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created stroke style.</para>
		/// </param>
		/// <remarks>It is valid to specify a dash array only if D2D1_DASH_STYLE_CUSTOM is also specified.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createstrokestyle(constd2d1_stroke_style_properties1_constfloat_uint32_id2d1strokestyle1)
		// HRESULT CreateStrokeStyle( [in] const D2D1_STROKE_STYLE_PROPERTIES1 *strokeStyleProperties, [in] const FLOAT *dashes, UINT32
		// dashesCount, [out] ID2D1StrokeStyle1 **strokeStyle );
		new void CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES1 strokeStyleProperties,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[]? dashes, [Optional] uint dashesCount, out ID2D1StrokeStyle1 strokeStyle);

		/// <summary>Creates an <c>ID2D1PathGeometry1</c> object.</summary>
		/// <param name="pathGeometry">
		/// <para>Type: <b>const **</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created path geometry.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createpathgeometry HRESULT CreatePathGeometry(
		// [out] ID2D1PathGeometry1 **pathGeometry );
		new void CreatePathGeometry(out ID2D1PathGeometry1 pathGeometry);

		/// <summary>
		/// Creates a new drawing state block, this can be used in subsequent SaveDrawingState and RestoreDrawingState operations on the
		/// render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <b>const <c>D2D1_DRAWING_STATE_DESCRIPTION1</c>*</b></para>
		/// <para>The drawing state description structure.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>The DirectWrite rendering params interface.</para>
		/// </param>
		/// <param name="drawingStateBlock">
		/// <para>Type: <b><c>ID2D1DrawingStateBlock1</c>**</b></para>
		/// <para>The address of the newly created drawing state block.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdrawingstateblock(constd2d1_drawing_state_description1_idwriterenderingparams_id2d1drawingstateblock1)
		// HRESULT CreateDrawingStateBlock( [in, optional] const D2D1_DRAWING_STATE_DESCRIPTION1 *drawingStateDescription, [in, optional]
		// IDWriteRenderingParams *textRenderingParams, [out] ID2D1DrawingStateBlock1 **drawingStateBlock );
		new void CreateDrawingStateBlock([In, Optional] ManagedStructPointer<D2D1_DRAWING_STATE_DESCRIPTION1> drawingStateDescription,
			[In, Optional] IDWriteRenderingParams? textRenderingParams, out ID2D1DrawingStateBlock1 drawingStateBlock);

		/// <summary>Creates a new <c>ID2D1GdiMetafile</c> object that you can use to replay metafile content.</summary>
		/// <param name="metafileStream">
		/// <para>Type: <b>IStream*</b></para>
		/// <para>A stream object that has the metafile data.</para>
		/// </param>
		/// <param name="metafile">
		/// <para>Type: <b><c>ID2D1GdiMetafile</c>**</b></para>
		/// <para>The address of the newly created GDI metafile object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-creategdimetafile HRESULT CreateGdiMetafile(
		// [in] IStream *metafileStream, [out] ID2D1GdiMetafile **metafile );
		new void CreateGdiMetafile([In] IStream metafileStream, out ID2D1GdiMetafile metafile);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a stream.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b>IStream</b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <c>RegisterEffect</c> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <c>RegisterEffect</c> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory, derived
		/// device, and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstream HRESULT
		// RegisterEffectFromStream( [in] REFCLSID classId, [in] IStream *propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromStream(in Guid classId, [In] IStream propertyXml, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[] bindings, uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a string.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b><c>PCWSTR</c></b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <b>RegisterEffect</b> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <b>RegisterEffect</b> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory and
		/// derived device and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstring HRESULT
		// RegisterEffectFromString( [in] REFCLSID classId, [in] PCWSTR propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromString(in Guid classId, [MarshalAs(UnmanagedType.LPWStr)] string propertyXml,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[]? bindings, [Optional] uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Unregisters an effect within the factory instance that corresponds to the <i>classId</i> provided.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be unregistered.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// In order for the effect to be fully unloaded, you must call <b>UnregisterEffect</b> the same number of times that you have
		/// registered the effect.
		/// </para>
		/// <para>
		/// The <b>UnregisterEffect</b> method unregisters only those effects that are registered on the same factory. It cannot be used to
		/// unregister a built-in effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-unregistereffect HRESULT UnregisterEffect(
		// [in] REFCLSID classId );
		new void UnregisterEffect(in Guid classId);

		/// <summary>Returns the class IDs of the currently registered effects and global effects on this factory.</summary>
		/// <param name="effects">
		/// <para>Type: <b><c>CLSID</c>*</b></para>
		/// <para>When this method returns, contains an array of effects. <b>NULL</b> if no effects are retrieved.</para>
		/// </param>
		/// <param name="effectsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The capacity of the <i>effects</i> array.</para>
		/// </param>
		/// <param name="effectsReturned">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects copied into <i>effects</i>.</para>
		/// </param>
		/// <param name="effectsRegistered">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects currently registered in the system.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The set of class IDs will be atomically returned by the API. The set will not be interrupted by other threads registering or
		/// unregistering effects.
		/// </para>
		/// <para>
		/// If <i>effectsRegistered</i> is larger than <i>effectCount</i>, the supplied array will still be filled to capacity with the
		/// current set of registered effects. This method returns the CLSIDs for all global effects and all effects registered to this factory.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-getregisteredeffects HRESULT
		// GetRegisteredEffects( [out] CLSID *effects, UINT32 effectsCount, [out] UINT32 *effectsReturned, [out, optional] UINT32
		// *effectsRegistered );
		new void GetRegisteredEffects([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[]? effects, uint effectsCount,
			out uint effectsReturned, out uint effectsRegistered);

		/// <summary>Retrieves the properties of an effect.</summary>
		/// <param name="effectId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The ID of the effect to retrieve properties from.</para>
		/// </param>
		/// <param name="properties">
		/// <para>Type: <b><c>ID2D1Properties</c>**</b></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the property interface that can be used to query the metadata of
		/// the effect.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The returned effect properties will have all the mutable properties for the effect set to a default of <b>NULL</b>, or an empty value.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Value types will be zero-filled.</description>
		/// </item>
		/// <item>
		/// <description>Blob and string types will be zero-length.</description>
		/// </item>
		/// <item>
		/// <description>Array types will have length 1 and the element of the array will conform to the previous rules.</description>
		/// </item>
		/// </list>
		/// <para>This method cannot be used to return the properties for any effect not visible to <c>ID2D1DeviceContext::CreateEffect</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-geteffectproperties HRESULT
		// GetEffectProperties( [in] REFCLSID effectId, [out] ID2D1Properties **properties );
		new void GetEffectProperties(in Guid effectId, out ID2D1Properties properties);

		/// <summary>Creates an <c>ID2D1Device1</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device1</c>.</para>
		/// </param>
		/// <param name="d2dDevice1">
		/// <para>Type: <b><c>ID2D1Device1</c>**</b></para>
		/// <para>The requested <c>ID2D1Device1</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device1</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1factory2-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device1 **d2dDevice1 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device1 d2dDevice1);

		/// <summary>Creates an <c>ID2D1Device2</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device2</c>.</para>
		/// </param>
		/// <param name="d2dDevice2">
		/// <para>Type: <b><c>ID2D1Device2</c>**</b></para>
		/// <para>The requested <c>ID2D1Device2</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory3-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device2 **d2dDevice2 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device2 d2dDevice2);

		/// <summary>Creates an <c>ID2D1Device3</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The IDXGIDevice object used when creating the <c>ID2D1Device3</c>.</para>
		/// </param>
		/// <param name="d2dDevice3">
		/// <para>Type: <b><c>ID2D1Device3</c>**</b></para>
		/// <para>The requested <c>ID2D1Device3</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory4-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device3 **d2dDevice3 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device3 d2dDevice3);

		/// <summary>Creates an <c>ID2D1Device4</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The IDXGIDevice object used when creating the <c>ID2D1Device4</c>.</para>
		/// </param>
		/// <param name="d2dDevice4">
		/// <para>Type: <b><c>ID2D1Device4</c>**</b></para>
		/// <para>The requested <c>ID2D1Device4</c> object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory5-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device4 **d2dDevice4 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device4 d2dDevice4);

		/// <summary>Creates a new Direct2D device from the given IDXGIDevice.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b>IDXGIDevice*</b></para>
		/// <para>The IDXGIDevice to create the Direct2D device from.</para>
		/// </param>
		/// <param name="d2dDevice5">
		/// <para>Type: <b>ID2D1Device5**</b></para>
		/// <para>The created device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory6-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device5 **d2dDevice5 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device5 d2dDevice5);

		/// <summary>Creates a new Direct2D device from the given IDXGIDevice.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b>IDXGIDevice*</b></para>
		/// <para>The IDXGIDevice from which to create the Direct2D device.</para>
		/// </param>
		/// <param name="d2dDevice6">
		/// <para>Type: <b>ID2D1Device6**</b></para>
		/// <para>The created device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory7-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device6 **d2dDevice6 );
		void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device6 d2dDevice6);
	}

	/// <summary>
	/// <para>Important</para>
	/// <para>
	/// Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft
	/// makes no warranties, express or implied, with respect to the information provided here.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1factory8
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1Factory8")]
	[ComImport, Guid("677C9311-F36D-4B1F-AE86-86D1223FFD3A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Factory8 : ID2D1Factory7
	{
		/// <summary>Forces the factory to refresh any system defaults that it might have changed since factory creation.</summary>
		/// <remarks>You should call this method before calling the GetDesktopDpi method, to ensure that the system DPI is current.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-reloadsystemmetrics HRESULT ReloadSystemMetrics();
		new void ReloadSystemMetrics();

		/// <summary>Retrieves the current desktop dots per inch (DPI). To refresh this value, call ReloadSystemMetrics.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the horizontal DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the vertical DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Use this method to obtain the system DPI when setting physical pixel values, such as when you specify the size of a window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-getdesktopdpi void GetDesktopDpi( FLOAT *dpiX, FLOAT
		// *dpiY );
		[PreserveSig, Obsolete("ID2D1Factory::GetDesktopDpi is deprecated. For a desktop app, instead use GetDpiForWindow. For a Universal Windows Platform (UWP) app, instead use DisplayInformation::LogicalDpi.")]
		new void GetDesktopDpi(out float dpiX, out float dpiY);

		/// <summary>Creates an ID2D1RectangleGeometry.</summary>
		/// <param name="rectangle">
		/// <para>Type: [in] <c>const D2D1_RECT_F*</c></para>
		/// <para>The coordinates of the rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createrectanglegeometry%28constd2d1_rect_f_id2d1rectanglegeometry%29
		// HRESULT CreateRectangleGeometry( const D2D1_RECT_F *rectangle, ID2D1RectangleGeometry **rectangleGeometry );
		new ID2D1RectangleGeometry CreateRectangleGeometry(in D2D_RECT_F rectangle);

		/// <summary>Creates an ID2D1RoundedRectangleGeometry.</summary>
		/// <param name="roundedRectangle">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT*</c></para>
		/// <para>The coordinates and corner radii of the rounded rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RoundedRectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rounded rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createroundedrectanglegeometry%28constd2d1_rounded_rect_id2d1roundedrectanglegeometry%29
		// HRESULT CreateRoundedRectangleGeometry( const D2D1_ROUNDED_RECT *roundedRectangle, ID2D1RoundedRectangleGeometry
		// **roundedRectangleGeometry );
		new ID2D1RoundedRectangleGeometry CreateRoundedRectangleGeometry(in D2D1_ROUNDED_RECT roundedRectangle);

		/// <summary>Creates an ID2D1EllipseGeometry.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>A value that describes the center point, x-radius, and y-radius of the ellipse geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1EllipseGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ellipse geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createellipsegeometry%28constd2d1_ellipse__id2d1ellipsegeometry%29
		// HRESULT CreateEllipseGeometry( const D2D1_ELLIPSE &amp; ellipse, ID2D1EllipseGeometry **ellipseGeometry );
		new ID2D1EllipseGeometry CreateEllipseGeometry(in D2D1_ELLIPSE ellipse);

		/// <summary>Creates an ID2D1GeometryGroup, which is an object that holds other geometries.</summary>
		/// <param name="fillMode">
		/// <para>Type: <c>D2D1_FILL_MODE</c></para>
		/// <para>A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</para>
		/// </param>
		/// <param name="geometries">
		/// <para>Type: <c>ID2D1Geometry**</c></para>
		/// <para>
		/// An array containing the geometry objects to add to the geometry group. The number of elements in this array is indicated by the
		/// geometriesCount parameter.
		/// </para>
		/// </param>
		/// <param name="geometriesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in geometries.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1GeometryGroup**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the geometry group created by this method.</para>
		/// </returns>
		/// <remarks>
		/// Geometry groups are a convenient way to group several geometries simultaneously so all figures of several distinct geometries
		/// are concatenated into one. To create a ID2D1GeometryGroup object, call the <c>CreateGeometryGroup</c> method on the ID2D1Factory
		/// object, passing in the fillMode with possible values of D2D1_FILL_MODE_ALTERNATE (alternate) and <c>D2D1_FILL_MODE_WINDING</c>,
		/// an array of geometry objects to add to the geometry group, and the number of elements in this array.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-creategeometrygroup HRESULT CreateGeometryGroup(
		// D2D1_FILL_MODE fillMode, ID2D1Geometry **geometries, UINT32 geometriesCount, ID2D1GeometryGroup **geometryGroup );
		new ID2D1GeometryGroup CreateGeometryGroup(D2D1_FILL_MODE fillMode, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] ID2D1Geometry[] geometries, uint geometriesCount);

		/// <summary>Transforms the specified geometry and stores the result as an ID2D1TransformedGeometry object.</summary>
		/// <param name="sourceGeometry">
		/// <para>Type: [in] <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to transform.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transformation to apply.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1TransformedGeometry**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the new transformed geometry object. The transformed geometry
		/// stores the result of transforming sourceGeometry by transform.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Like other resources, a transformed geometry inherits the resource space and threading policy of the factory that created it.
		/// This object is immutable.
		/// </para>
		/// <para>
		/// When stroking a transformed geometry with the DrawGeometry method, the stroke width is not affected by the transform applied to
		/// the geometry. The stroke width is only affected by the world transform.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createtransformedgeometry%28id2d1geometry_constd2d1_matrix_3x2_f_id2d1transformedgeometry%29
		// HRESULT CreateTransformedGeometry( ID2D1Geometry *sourceGeometry, const D2D1_MATRIX_3X2_F *transform, ID2D1TransformedGeometry
		// **transformedGeometry );
		new ID2D1TransformedGeometry CreateTransformedGeometry([In] ID2D1Geometry sourceGeometry, in D2D_MATRIX_3X2_F transform);

		/// <summary>Creates an empty ID2D1PathGeometry.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1PathGeometry**</c></para>
		/// <para>When this method returns, contains the address to a pointer to the path geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createpathgeometry HRESULT CreatePathGeometry(
		// ID2D1PathGeometry **pathGeometry );
		new ID2D1PathGeometry CreatePathGeometry();

		/// <summary>Creates an ID2D1StrokeStyle that describes start cap, dash pattern, and other features of a stroke.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <c>const D2D1_STROKE_STYLE_PROPERTIES</c></para>
		/// <para>A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length of a
		/// dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length of each
		/// dash and space in the dash pattern is the product of the element value in the array and the stroke width.
		/// </para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the dashes array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1StrokeStyle**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the stroke style created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createstrokestyle%28constd2d1_stroke_style_properties__constfloat_uint32_id2d1strokestyle%29
		// HRESULT CreateStrokeStyle( const D2D1_STROKE_STYLE_PROPERTIES &amp; strokeStyleProperties, const FLOAT *dashes, UINT32
		// dashesCount, ID2D1StrokeStyle **strokeStyle );
		new ID2D1StrokeStyle CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES strokeStyleProperties, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] dashes, uint dashesCount);

		/// <summary>
		/// Creates an ID2D1DrawingStateBlock that can be used with the SaveDrawingState and RestoreDrawingState methods of a render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <c>const D2D1_DRAWING_STATE_DESCRIPTION*</c></para>
		/// <para>A structure that contains antialiasing, transform, and tags information.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>Optional text parameters that indicate how text should be rendered.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DrawingStateBlock**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new drawing state block created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdrawingstateblock%28constd2d1_drawing_state_description_idwriterenderingparams_id2d1drawingstateblock%29
		// HRESULT CreateDrawingStateBlock( const D2D1_DRAWING_STATE_DESCRIPTION *drawingStateDescription, IDWriteRenderingParams
		// *textRenderingParams, ID2D1DrawingStateBlock **drawingStateBlock );
		new ID2D1DrawingStateBlock CreateDrawingStateBlock([In, Optional] StructPointer<D2D1_DRAWING_STATE_DESCRIPTION> drawingStateDescription, [In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="target">
		/// <para>Type: <c>IWICBitmap*</c></para>
		/// <para>The bitmap that receives the rendering output of the render target.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must use D2D1_FEATURE_LEVEL_DEFAULT for the <c>minLevel</c> member of the renderTargetProperties parameter with this method.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold onto them for the life of the application or until the
		/// D2DERR_RECREATE_TARGET error is received. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createwicbitmaprendertarget%28iwicbitmap_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateWicBitmapRenderTarget( IWICBitmap *target, const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties,
		// ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateWicBitmapRenderTarget([In] IWICBitmap target, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates an <c>ID2D1HwndRenderTarget</c>, a render target that renders to a window.</summary>
		/// <param name="renderTargetProperties">
		/// <para>[in] Type: <c>D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <param name="hwndRenderTargetProperties">
		/// <para>[in] Type: <c>D2D1_HWND_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>The window handle, initial size (in pixels), and present options.</para>
		/// </param>
		/// <returns>
		/// <para>[out] Type: <c>ID2D1HwndRenderTarget**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the <c>ID2D1HwndRenderTarget</c> object created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the <c>D2DERR_RECREATE_TARGET</c> error
		/// is received. When you receive this error, you need to recreate the render target (and any resources it created).
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd371275(v=vs.85) virtual HRESULT
		// CreateHwndRenderTarget( [in] D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, [in] D2D1_HWND_RENDER_TARGET_PROPERTIES
		// *hwndRenderTargetProperties, [out] ID2D1HwndRenderTarget **hwndRenderTarget ) = 0;
		new ID2D1HwndRenderTarget CreateHwndRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, in D2D1_HWND_RENDER_TARGET_PROPERTIES hwndRenderTargetProperties);

		/// <summary>Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.</summary>
		/// <param name="dxgiSurface">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>The IDXGISurface to which the render target will draw.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES &amp;</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To write to a Direct3D surface, you obtain an IDXGISurface and pass it to the CreateDxgiSurfaceRenderTarget method to create a
		/// DXGI surface render target; you can then use the DXGI surface render target to draw 2-D content to the DXGI surface.
		/// </para>
		/// <para>
		/// A DXGI surface render target is a type of ID2D1RenderTarget. Like other Direct2D render targets, you can use it to create
		/// resources and issue drawing commands.
		/// </para>
		/// <para>
		/// The DXGI surface render target and the DXGI surface must use the same DXGI format. If you specify the DXGI_FORMAT_UNKOWN format
		/// when you create the render target, it will automatically use the surface's format.
		/// </para>
		/// <para>The DXGI surface render target does not perform DXGI surface synchronization.</para>
		/// <para>
		/// For more information about creating and using DXGI surface render targets, see the Direct2D and Direct3D Interoperability Overview.
		/// </para>
		/// <para>
		/// To work with Direct2D, the Direct3D device that provides the IDXGISurface must be created with the
		/// <c>D3D10_CREATE_DEVICE_BGRA_SUPPORT</c> flag.
		/// </para>
		/// <para>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the render target's EndDraw method
		/// returns the D2DERR_RECREATE_TARGET error. When you receive this error, you need to recreate the render target (and any resources
		/// it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdxgisurfacerendertarget%28idxgisurface_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateDxgiSurfaceRenderTarget( IDXGISurface *dxgiSurface, const D2D1_RENDER_TARGET_PROPERTIES &amp;
		// renderTargetProperties, ID2D1RenderTarget **renderTarget );
		new ID2D1RenderTarget CreateDxgiSurfaceRenderTarget([In] IDXGISurface dxgiSurface, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.</summary>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. To enable the device context (DC) render target to work with GDI, set the DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM
		/// and the alpha mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>. For more information about pixel formats,
		/// see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DCRenderTarget**</c></para>
		/// <para>
		/// When this method returns, dcRenderTarget contains the address of the pointer to the ID2D1DCRenderTarget created by the method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before you can render with a DC render target, you must use the render target's BindDC method to associate it with a GDI DC. Do
		/// this for each different DC and whenever there is a change in the size of the area you want to draw to.
		/// </para>
		/// <para>
		/// To enable the DC render target to work with GDI, set the render target's DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM and alpha
		/// mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold on to them for the life of the application or until the render
		/// target's EndDraw method returns the D2DERR_RECREATE_TARGET error. When you receive this error, recreate the render target (and
		/// any resources it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdcrendertarget HRESULT CreateDCRenderTarget(
		// const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, ID2D1DCRenderTarget **dcRenderTarget );
		new ID2D1DCRenderTarget CreateDCRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a <c>ID2D1Device</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device</c>.</para>
		/// </param>
		/// <param name="d2dDevice">
		/// <para>Type: <b><c>ID2D1Device</c>**</b></para>
		/// <para>The requested <c>ID2D1Device</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device **d2dDevice );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device d2dDevice);

		/// <summary>Creates a <c>ID2D1StrokeStyle1</c> object.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <b>const <c>D2D1_STROKE_STYLE_PROPERTIES1</c>*</b></para>
		/// <para>The stroke style properties to apply.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <b>const <c>FLOAT</c>*</b></para>
		/// <para>An array of widths for the dashes and gaps.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the dash array.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <b>const <c>ID2D1StrokeStyle1</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created stroke style.</para>
		/// </param>
		/// <remarks>It is valid to specify a dash array only if D2D1_DASH_STYLE_CUSTOM is also specified.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createstrokestyle(constd2d1_stroke_style_properties1_constfloat_uint32_id2d1strokestyle1)
		// HRESULT CreateStrokeStyle( [in] const D2D1_STROKE_STYLE_PROPERTIES1 *strokeStyleProperties, [in] const FLOAT *dashes, UINT32
		// dashesCount, [out] ID2D1StrokeStyle1 **strokeStyle );
		new void CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES1 strokeStyleProperties,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[]? dashes, [Optional] uint dashesCount, out ID2D1StrokeStyle1 strokeStyle);

		/// <summary>Creates an <c>ID2D1PathGeometry1</c> object.</summary>
		/// <param name="pathGeometry">
		/// <para>Type: <b>const **</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created path geometry.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createpathgeometry HRESULT CreatePathGeometry(
		// [out] ID2D1PathGeometry1 **pathGeometry );
		new void CreatePathGeometry(out ID2D1PathGeometry1 pathGeometry);

		/// <summary>
		/// Creates a new drawing state block, this can be used in subsequent SaveDrawingState and RestoreDrawingState operations on the
		/// render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <b>const <c>D2D1_DRAWING_STATE_DESCRIPTION1</c>*</b></para>
		/// <para>The drawing state description structure.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>The DirectWrite rendering params interface.</para>
		/// </param>
		/// <param name="drawingStateBlock">
		/// <para>Type: <b><c>ID2D1DrawingStateBlock1</c>**</b></para>
		/// <para>The address of the newly created drawing state block.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-createdrawingstateblock(constd2d1_drawing_state_description1_idwriterenderingparams_id2d1drawingstateblock1)
		// HRESULT CreateDrawingStateBlock( [in, optional] const D2D1_DRAWING_STATE_DESCRIPTION1 *drawingStateDescription, [in, optional]
		// IDWriteRenderingParams *textRenderingParams, [out] ID2D1DrawingStateBlock1 **drawingStateBlock );
		new void CreateDrawingStateBlock([In, Optional] ManagedStructPointer<D2D1_DRAWING_STATE_DESCRIPTION1> drawingStateDescription,
			[In, Optional] IDWriteRenderingParams? textRenderingParams, out ID2D1DrawingStateBlock1 drawingStateBlock);

		/// <summary>Creates a new <c>ID2D1GdiMetafile</c> object that you can use to replay metafile content.</summary>
		/// <param name="metafileStream">
		/// <para>Type: <b>IStream*</b></para>
		/// <para>A stream object that has the metafile data.</para>
		/// </param>
		/// <param name="metafile">
		/// <para>Type: <b><c>ID2D1GdiMetafile</c>**</b></para>
		/// <para>The address of the newly created GDI metafile object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-creategdimetafile HRESULT CreateGdiMetafile(
		// [in] IStream *metafileStream, [out] ID2D1GdiMetafile **metafile );
		new void CreateGdiMetafile([In] IStream metafileStream, out ID2D1GdiMetafile metafile);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a stream.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b>IStream</b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <c>RegisterEffect</c> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <c>RegisterEffect</c> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory, derived
		/// device, and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstream HRESULT
		// RegisterEffectFromStream( [in] REFCLSID classId, [in] IStream *propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromStream(in Guid classId, [In] IStream propertyXml, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[] bindings, uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Registers an effect within the factory instance with the property XML specified as a string.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be registered.</para>
		/// </param>
		/// <param name="propertyXml">
		/// <para>Type: <b><c>PCWSTR</c></b></para>
		/// <para>A list of the effect properties, types, and metadata.</para>
		/// </param>
		/// <param name="bindings">
		/// <para>Type: <b>const <c>D2D1_PROPERTY_BINDING</c>*</b></para>
		/// <para>An array of properties and methods.</para>
		/// <para>
		/// This binds a property by name to a particular method implemented by the effect author to handle the property. The name must be
		/// found in the corresponding <i>propertyXml</i>.
		/// </para>
		/// </param>
		/// <param name="bindingsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of bindings in the binding array.</para>
		/// </param>
		/// <param name="effectFactory">
		/// <para>Type: <b><c>PD2D1_EFFECT_FACTORY</c></b></para>
		/// <para>The static factory that is used to create the corresponding effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Direct2D effects must define their properties at registration time via registration XML. An effect declares several required
		/// system properties, and can also declare custom properties. See <c>Custom effects</c> for more information about formatting the
		/// <i>propertyXml</i> parameter.
		/// </para>
		/// <para>
		/// <b>RegisterEffect</b> is both atomic and reference counted. To unregister an effect, call <c>UnregisterEffect</c> with the
		/// <i>classId</i> of the effect.
		/// </para>
		/// <para>
		/// <b>Important</b>   <b>RegisterEffect</b> does not hold a reference to the DLL or executable file in which the effect is
		/// contained. The application must independently make sure that the lifetime of the DLL or executable file completely contains all
		/// instances of each registered and created effect.
		/// </para>
		/// <para></para>
		/// <para>
		/// Aside from the <c>built-in effects</c> that are globally registered, this API registers effects only for this factory and
		/// derived device and device context interfaces.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-registereffectfromstring HRESULT
		// RegisterEffectFromString( [in] REFCLSID classId, [in] PCWSTR propertyXml, [in, optional] const D2D1_PROPERTY_BINDING *bindings,
		// UINT32 bindingsCount, const PD2D1_EFFECT_FACTORY effectFactory );
		new void RegisterEffectFromString(in Guid classId, [MarshalAs(UnmanagedType.LPWStr)] string propertyXml,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_PROPERTY_BINDING[]? bindings, [Optional] uint bindingsCount,
			[In, MarshalAs(UnmanagedType.FunctionPtr)] PD2D1_EFFECT_FACTORY effectFactory);

		/// <summary>Unregisters an effect within the factory instance that corresponds to the <i>classId</i> provided.</summary>
		/// <param name="classId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The identifier of the effect to be unregistered.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// In order for the effect to be fully unloaded, you must call <b>UnregisterEffect</b> the same number of times that you have
		/// registered the effect.
		/// </para>
		/// <para>
		/// The <b>UnregisterEffect</b> method unregisters only those effects that are registered on the same factory. It cannot be used to
		/// unregister a built-in effect.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-unregistereffect HRESULT UnregisterEffect(
		// [in] REFCLSID classId );
		new void UnregisterEffect(in Guid classId);

		/// <summary>Returns the class IDs of the currently registered effects and global effects on this factory.</summary>
		/// <param name="effects">
		/// <para>Type: <b><c>CLSID</c>*</b></para>
		/// <para>When this method returns, contains an array of effects. <b>NULL</b> if no effects are retrieved.</para>
		/// </param>
		/// <param name="effectsCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The capacity of the <i>effects</i> array.</para>
		/// </param>
		/// <param name="effectsReturned">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects copied into <i>effects</i>.</para>
		/// </param>
		/// <param name="effectsRegistered">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>When this method returns, contains the number of effects currently registered in the system.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The set of class IDs will be atomically returned by the API. The set will not be interrupted by other threads registering or
		/// unregistering effects.
		/// </para>
		/// <para>
		/// If <i>effectsRegistered</i> is larger than <i>effectCount</i>, the supplied array will still be filled to capacity with the
		/// current set of registered effects. This method returns the CLSIDs for all global effects and all effects registered to this factory.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-getregisteredeffects HRESULT
		// GetRegisteredEffects( [out] CLSID *effects, UINT32 effectsCount, [out] UINT32 *effectsReturned, [out, optional] UINT32
		// *effectsRegistered );
		new void GetRegisteredEffects([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[]? effects, uint effectsCount,
			out uint effectsReturned, out uint effectsRegistered);

		/// <summary>Retrieves the properties of an effect.</summary>
		/// <param name="effectId">
		/// <para>Type: <b>REFCLSID</b></para>
		/// <para>The ID of the effect to retrieve properties from.</para>
		/// </param>
		/// <param name="properties">
		/// <para>Type: <b><c>ID2D1Properties</c>**</b></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the property interface that can be used to query the metadata of
		/// the effect.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The returned effect properties will have all the mutable properties for the effect set to a default of <b>NULL</b>, or an empty value.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Value types will be zero-filled.</description>
		/// </item>
		/// <item>
		/// <description>Blob and string types will be zero-length.</description>
		/// </item>
		/// <item>
		/// <description>Array types will have length 1 and the element of the array will conform to the previous rules.</description>
		/// </item>
		/// </list>
		/// <para>This method cannot be used to return the properties for any effect not visible to <c>ID2D1DeviceContext::CreateEffect</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1factory1-geteffectproperties HRESULT
		// GetEffectProperties( [in] REFCLSID effectId, [out] ID2D1Properties **properties );
		new void GetEffectProperties(in Guid effectId, out ID2D1Properties properties);

		/// <summary>Creates an <c>ID2D1Device1</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device1</c>.</para>
		/// </param>
		/// <param name="d2dDevice1">
		/// <para>Type: <b><c>ID2D1Device1</c>**</b></para>
		/// <para>The requested <c>ID2D1Device1</c> object.</para>
		/// </param>
		/// <remarks>
		/// The <c>Direct2D</c> device defines a resource domain in which a set of Direct2D objects and Direct2D device contexts can be used
		/// together. Each call to <c>CreateDevice</c> returns a unique <c>ID2D1Device1</c> object, even if you pass the same
		/// <c>IDXGIDevice</c> multiple times.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-id2d1factory2-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device1 **d2dDevice1 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device1 d2dDevice1);

		/// <summary>Creates an <c>ID2D1Device2</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The <c>IDXGIDevice</c> object used when creating the <c>ID2D1Device2</c>.</para>
		/// </param>
		/// <param name="d2dDevice2">
		/// <para>Type: <b><c>ID2D1Device2</c>**</b></para>
		/// <para>The requested <c>ID2D1Device2</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory3-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device2 **d2dDevice2 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device2 d2dDevice2);

		/// <summary>Creates an <c>ID2D1Device3</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The IDXGIDevice object used when creating the <c>ID2D1Device3</c>.</para>
		/// </param>
		/// <param name="d2dDevice3">
		/// <para>Type: <b><c>ID2D1Device3</c>**</b></para>
		/// <para>The requested <c>ID2D1Device3</c> object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory4-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device3 **d2dDevice3 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device3 d2dDevice3);

		/// <summary>Creates an <c>ID2D1Device4</c> object.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
		/// <para>The IDXGIDevice object used when creating the <c>ID2D1Device4</c>.</para>
		/// </param>
		/// <param name="d2dDevice4">
		/// <para>Type: <b><c>ID2D1Device4</c>**</b></para>
		/// <para>The requested <c>ID2D1Device4</c> object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory5-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device4 **d2dDevice4 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device4 d2dDevice4);

		/// <summary>Creates a new Direct2D device from the given IDXGIDevice.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b>IDXGIDevice*</b></para>
		/// <para>The IDXGIDevice to create the Direct2D device from.</para>
		/// </param>
		/// <param name="d2dDevice5">
		/// <para>Type: <b>ID2D1Device5**</b></para>
		/// <para>The created device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory6-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device5 **d2dDevice5 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device5 d2dDevice5);

		/// <summary>Creates a new Direct2D device from the given IDXGIDevice.</summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b>IDXGIDevice*</b></para>
		/// <para>The IDXGIDevice from which to create the Direct2D device.</para>
		/// </param>
		/// <param name="d2dDevice6">
		/// <para>Type: <b>ID2D1Device6**</b></para>
		/// <para>The created device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory7-createdevice HRESULT CreateDevice( [in]
		// IDXGIDevice *dxgiDevice, [out] ID2D1Device6 **d2dDevice6 );
		new void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device6 d2dDevice6);

		/// <summary>
		/// <para>Important</para>
		/// <para>
		/// Some information relates to a prerelease product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.
		/// </para>
		/// </summary>
		/// <param name="dxgiDevice">
		/// <para>Type: <b>IDXGIDevice*</b></para>
		/// <para>The IDXGIDevice from which to create the Direct2D device.</para>
		/// </param>
		/// <param name="d2dDevice6">
		/// <para>Type: <b><c>ID2D1Device7</c> **</b></para>
		/// <para>The created device.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1factory8-createdevice HRESULT CreateDevice( IDXGIDevice
		// *dxgiDevice, ID2D1Device7 **d2dDevice6 );
		void CreateDevice([In] IDXGIDevice dxgiDevice, out ID2D1Device7 d2dDevice6);
	}

	/// <summary>
	/// This interface performs all the same functions as the existing ID2D1GdiMetafile interface. It also enables accessing the metafile
	/// DPI and bounds.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1gdimetafile1
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1GdiMetafile1")]
	[ComImport, Guid("2E69F9E8-DD3F-4BF9-95BA-C04F49D788DF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1GdiMetafile1 : ID2D1GdiMetafile
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>This method streams the contents of the command to the given metafile sink.</summary>
		/// <param name="sink">
		/// <para>Type: <c>ID2D1GdiMetafileSink</c></para>
		/// <para>The sink into which Direct2D will call back.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>HRESULT</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>No error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Direct2D could not allocate sufficient memory to complete the call.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>An invalid value was passed to the method.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gdimetafile-stream HRESULT Stream( ID2D1GdiMetafileSink
		// *sink );
		new void Stream([In] ID2D1GdiMetafileSink sink);

		/// <summary>Gets the bounds of the metafile, in device-independent pixels (DIPs), as reported in the metafile’s header.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>The bounds, in DIPs, of the metafile.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gdimetafile-getbounds HRESULT GetBounds( D2D1_RECT_F
		// *bounds );
		new D2D_RECT_F GetBounds();

		/// <summary>Gets the DPI reported by the metafile.</summary>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>Receives the horizontal DPI reported by the metafile.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>Receives the vertical DPI reported by the metafile.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1gdimetafile1-getdpi HRESULT GetDpi( [out] FLOAT *dpiX,
		// [out] FLOAT *dpiY );
		void GetDpi(out float dpiX, out float dpiY);

		/// <summary>Gets the bounds of the metafile in source space in DIPs. This corresponds to the frame rect in an EMF/EMF+.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_RECT_F</c>*</b></para>
		/// <para>The bounds, in DIPs, of the metafile.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1gdimetafile1-getsourcebounds HRESULT GetSourceBounds(
		// [out] D2D1_RECT_F *bounds );
		D2D_RECT_F GetSourceBounds();
	}

	/// <summary>
	/// This interface performs all the same functions as the existing ID2D1GdiMetafileSink interface. It also enables access to metafile records.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1gdimetafilesink1
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1GdiMetafileSink1")]
	[ComImport, Guid("FD0ECB6B-91E6-411E-8655-395E760F91B4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1GdiMetafileSink1 : ID2D1GdiMetafileSink
	{
		/// <summary>This method is called once for each record stored in a metafile.</summary>
		/// <param name="recordType">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of the record.</para>
		/// </param>
		/// <param name="recordData">
		/// <para>Type: <c>void*</c></para>
		/// <para>The data for the record.</para>
		/// </param>
		/// <param name="recordDataSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The byte size of the record data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return true if the record is successfully.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gdimetafilesink-processrecord HRESULT ProcessRecord(
		// DWORD recordType, const void *recordData, DWORD recordDataSize );
		[PreserveSig]
		new HRESULT ProcessRecord(uint recordType, [In, Optional] IntPtr recordData, uint recordDataSize);

		/// <summary>Provides access to metafile records, including their type, data, and flags.</summary>
		/// <param name="recordType">
		/// <para>Type: <b>DWORD</b></para>
		/// <para>The type of metafile record being processed. Please see <c>MS-EMF</c> and <c>MS-EMFPLUS</c> for a list of record types.</para>
		/// </param>
		/// <param name="recordData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The data contained in this record. Please see <c>MS-EMF</c> and <c>MS-EMFPLUS</c> for information on record data layouts.</para>
		/// </param>
		/// <param name="recordDataSize">
		/// <para>Type: <b>UINT</b></para>
		/// <para>TThe size of the data pointed to by recordData.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The set of flags set for this record. Please see <c>MS-EMF</c> and <c>MS-EMFPLUS</c> for information on record flags.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>S_OK if successful, otherwise a failure HRESULT.</para>
		/// </returns>
		/// <remarks>For details on the EMF and EMF+ formats, please see Microsoft technical documents <c>MS-EMF</c> and <c>MS-EMFPLUS</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1gdimetafilesink1-processrecord HRESULT ProcessRecord(
		// DWORD recordType, [in, optional] const void *recordData, DWORD recordDataSize, UINT32 flags );
		[PreserveSig]
		HRESULT ProcessRecord(uint recordType, [In, Optional] IntPtr recordData, uint recordDataSize, uint flags);
	}

	/// <summary>
	/// Represents a device-dependent representation of a gradient mesh composed of patches. Use the
	/// <c>ID2D1DeviceContext2::CreateGradientMesh method</c> to create an instance of ID2D1GradientMesh.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1gradientmesh
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1GradientMesh")]
	[ComImport, Guid("F292E401-C050-4CDE-83D7-04962D3B23C2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1GradientMesh : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Returns the number of patches that make up this gradient mesh.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of patches that make up this gradient mesh.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1gradientmesh-getpatchcount UINT32 GetPatchCount();
		[PreserveSig]
		uint GetPatchCount();

		/// <summary>Returns a subset of the patches that make up this gradient mesh.</summary>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Index of the first patch to return.</para>
		/// </param>
		/// <param name="patches">
		/// <para>Type: <b><c>D2D1_GRADIENT_MESH_PATCH</c>*</b></para>
		/// <para>A pointer to the array to be filled with the patch data.</para>
		/// </param>
		/// <param name="patchesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of patches to be returned.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1gradientmesh-getpatches HRESULT GetPatches( UINT32
		// startIndex, D2D1_GRADIENT_MESH_PATCH *patches, UINT32 patchesCount );
		void GetPatches(uint startIndex, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D2D1_GRADIENT_MESH_PATCH[] patches, uint patchesCount);
	}

	/// <summary>Represents a producer of pixels that can fill an arbitrary 2D plane.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1imagesource
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1ImageSource")]
	[ComImport, Guid("C9B664E5-74A1-4378-9AC2-EEFC37A3F4D8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1ImageSource : ID2D1Image
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Allows the operating system to free the video memory of resources by discarding their content.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para><b>OfferResources</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>S_OK</b> if resources were successfully offered</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if a resource in the array or the priority is invalid</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1imagesource-offerresources HRESULT OfferResources();
		[PreserveSig]
		HRESULT OfferResources();

		/// <summary>Restores access to resources that were previously offered by calling <c>OfferResources</c>.</summary>
		/// <param name="resourcesDiscarded">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>
		/// Returns with TRUE if the corresponding resource’s content was discarded and is now undefined, or FALSE if the corresponding
		/// resource’s old content is still intact. The caller can pass in NULL, if the caller intends to fill the resources with new
		/// content regardless of whether the old content was discarded.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para><b>ReclaimResources</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>S_OK</b> if resources were successfully reclaimed</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if the resources are invalid</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// After you call <c>OfferResources</c> to offer one or more resources, you must call <b>TryReclaimResources</b> before you can use
		/// those resources again. You must check the value in the <b>resourcesDiscarded</b> to determine whether the resource’s content was
		/// discarded. If a resource’s content was discarded while it was offered, its current content is undefined. Therefore, you must
		/// overwrite the resource’s content before you use the resource.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1imagesource-tryreclaimresources HRESULT
		// TryReclaimResources( [out] BOOL *resourcesDiscarded );
		[PreserveSig]
		HRESULT TryReclaimResources(out bool resourcesDiscarded);
	}

	/// <summary>Produces 2D pixel data that has been sourced from WIC.</summary>
	/// <remarks>Create an an instance of ID2D1ImageSourceFromWic using <c>ID2D1DeviceContext2::CreateImageSourceFromWic</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1imagesourcefromwic
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1ImageSourceFromWic")]
	[ComImport, Guid("77395441-1C8F-4555-8683-F50DAB0FE792"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1ImageSourceFromWic : ID2D1Resource, ID2D1Image, ID2D1ImageSource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Allows the operating system to free the video memory of resources by discarding their content.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para><b>OfferResources</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>S_OK</b> if resources were successfully offered</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if a resource in the array or the priority is invalid</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1imagesource-offerresources HRESULT OfferResources();
		[PreserveSig]
		new HRESULT OfferResources();

		/// <summary>Restores access to resources that were previously offered by calling <c>OfferResources</c>.</summary>
		/// <param name="resourcesDiscarded">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>
		/// Returns with TRUE if the corresponding resource’s content was discarded and is now undefined, or FALSE if the corresponding
		/// resource’s old content is still intact. The caller can pass in NULL, if the caller intends to fill the resources with new
		/// content regardless of whether the old content was discarded.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para><b>ReclaimResources</b> returns:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>S_OK</b> if resources were successfully reclaimed</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if the resources are invalid</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// After you call <c>OfferResources</c> to offer one or more resources, you must call <b>TryReclaimResources</b> before you can use
		/// those resources again. You must check the value in the <b>resourcesDiscarded</b> to determine whether the resource’s content was
		/// discarded. If a resource’s content was discarded while it was offered, its current content is undefined. Therefore, you must
		/// overwrite the resource’s content before you use the resource.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1imagesource-tryreclaimresources HRESULT
		// TryReclaimResources( [out] BOOL *resourcesDiscarded );
		[PreserveSig]
		new HRESULT TryReclaimResources(out bool resourcesDiscarded);

		/// <summary>
		/// Ensures that a specified region of the image source cache is populated. This method can be used to minimize glitches by
		/// performing expensive work to populate caches outside of a rendering loop. This method can also be used to speculatively load
		/// image data before it is needed by drawing routines.
		/// </summary>
		/// <param name="rectangleToFill">
		/// <para>Type: <b>const <c>D2D1_RECT_U</c></b></para>
		/// <para>
		/// Specifies the region of the image, in pixels, that should be populated in the cache. By default, this is the entire extent of
		/// the image.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This API loads image data into caches of image sources, if that data was not already cached. It does not trim pre-existing
		/// caches, if any. More areas within the cache can be populated than actually requested.
		/// </para>
		/// <para>
		/// The provided region must be constructed to include the scale with which the image source will subsequently be drawn. These
		/// coordinates must be provided in local coordinates. This means that they must be adjusted prior to calling the API according to
		/// the DPI and other relevant transforms, which can include the world transform and brush transforms.
		/// </para>
		/// <para>
		/// This operation is only supported when the image source has been initialized using the
		/// D2D1_IMAGE_SOURCE_LOADING_OPTIONS_CACHE_ON_DEMAND option.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1imagesourcefromwic-ensurecached(constd2d1_rect_u_)
		// HRESULT EnsureCached( [ref] const D2D1_RECT_U &amp; rectangleToFill );
		void EnsureCached([In, Optional] StructPointer<D2D_RECT_U> rectangleToFill);

		/// <summary>This method trims the populated regions of the image source cache to just the specified rectangle.</summary>
		/// <param name="rectangleToPreserve">
		/// <para>Type: <b>const <c>D2D1_RECT_U</c>*</b></para>
		/// <para>
		/// Specifies the region of the image, in pixels, which should be preserved in the image source cache. Regions which are outside of
		/// the rectangle are evicted from the cache. By default, this is an empty rectangle, meaning that the entire image is evicted from
		/// the cache.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The provided region must be constructed to include the scale at which the image source will be drawn at. These coordinates must
		/// be provided in local coordinates. This means that they must be adjusted prior to calling the API according to the DPI and other
		/// relevant transforms, which can include the world transform and brush transforms.
		/// </para>
		/// <para>This method will fail if on-demand caching was not requested when the image source was created.</para>
		/// <para>
		/// As with <c>ID2D1Device::ClearResources</c>, the caller can need to subsequently issue a D3D flush before memory usage is reduced.
		/// </para>
		/// <para>
		/// This operation is only supported when the image source has been initialized using the
		/// D2D1_IMAGE_SOURCE_LOADING_OPTIONS_CACHE_ON_DEMAND option.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1imagesourcefromwic-trimcache(constd2d1_rect_u) HRESULT
		// TrimCache( [in, optional] const D2D1_RECT_U *rectangleToPreserve );
		void TrimCache([In, Optional] StructPointer<D2D_RECT_U> rectangleToPreserve);

		/// <summary>Retrieves the underlying bitmap image source from the Windows Imaging Component (WIC).</summary>
		/// <param name="wicBitmapSource">
		/// <para>Type: <b><c>IWICBitmapSource</c>**</b></para>
		/// <para>On return contains the bitmap image source.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1imagesourcefromwic-getsource void GetSource(
		// IWICBitmapSource **wicBitmapSource );
		[PreserveSig]
		void GetSource(out IWICBitmapSource wicBitmapSource);
	}

	/// <summary>Represents a single continuous stroke of variable-width ink, as defined by a series of Bezier segments and widths.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1ink
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1Ink")]
	[ComImport, Guid("B499923B-7029-478F-A8B3-432C7C5F5312"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Ink : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Sets the starting point for this ink object. This determines where this ink object will start rendering.</summary>
		/// <param name="startPoint">
		/// <para>Type: <b>const <c>D2D1_INK_POINT</c>*</b></para>
		/// <para>The new starting point for this ink object.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-setstartpoint(constd2d1_ink_point) void
		// SetStartPoint( [in] const D2D1_INK_POINT *startPoint );
		[PreserveSig]
		void SetStartPoint(in D2D1_INK_POINT startPoint);

		/// <summary>Retrieves the starting point for this ink object.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_INK_POINT</c></b></para>
		/// <para>The starting point for this ink object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-getstartpoint D2D1_INK_POINT GetStartPoint();
		D2D1_INK_POINT GetStartPoint();

		/// <summary>Adds the given segments to the end of this ink object.</summary>
		/// <param name="segments">
		/// <para>Type: <b>const <c>D2D1_INK_BEZIER_SEGMENT</c>*</b></para>
		/// <para>A pointer to an array of segments to be added to this ink object.</para>
		/// </param>
		/// <param name="segmentsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of segments to be added to this ink object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-addsegments HRESULT AddSegments( [in] const
		// D2D1_INK_BEZIER_SEGMENT *segments, UINT32 segmentsCount );
		void AddSegments([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_INK_BEZIER_SEGMENT[] segments, int segmentsCount);

		/// <summary>Removes the given number of segments from the end of this ink object.</summary>
		/// <param name="segmentsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of segments to be removed from the end of this ink object. Note that segmentsCount must be less or equal to the
		/// number of segments in the ink object.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-removesegmentsatend HRESULT RemoveSegmentsAtEnd(
		// UINT32 segmentsCount );
		void RemoveSegmentsAtEnd(uint segmentsCount);

		/// <summary>Updates the specified segments in this ink object with new control points.</summary>
		/// <param name="startSegment">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the first segment in this ink object to update.</para>
		/// </param>
		/// <param name="segments">
		/// <para>Type: <b>const <c>D2D1_INK_BEZIER_SEGMENT</c>*</b></para>
		/// <para>A pointer to the array of segment data to be used in the update.</para>
		/// </param>
		/// <param name="segmentsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of segments in this ink object that will be updated with new data. Note that segmentsCount must be less than or equal
		/// to the number of segments in the ink object minus startSegment.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-setsegments HRESULT SetSegments( UINT32
		// startSegment, [in] const D2D1_INK_BEZIER_SEGMENT *segments, UINT32 segmentsCount );
		void SetSegments(uint startSegment, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D2D1_INK_BEZIER_SEGMENT[] segments, int segmentsCount);

		/// <summary>Updates the last segment in this ink object with new control points.</summary>
		/// <param name="segment">
		/// <para>Type: <b>const <c>D2D1_INK_BEZIER_SEGMENT</c>*</b></para>
		/// <para>
		/// A pointer to the segment data with which to overwrite this ink object's last segment. Note that if there are currently no
		/// segments in the ink object, SetSegmentsAtEnd will return an error.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-setsegmentatend(constd2d1_ink_bezier_segment)
		// HRESULT SetSegmentAtEnd( [in] const D2D1_INK_BEZIER_SEGMENT *segment );
		void SetSegmentAtEnd(in D2D1_INK_BEZIER_SEGMENT segment);

		/// <summary>Returns the number of segments in this ink object.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of segments in this ink object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-getsegmentcount UINT32 GetSegmentCount();
		[PreserveSig]
		uint GetSegmentCount();

		/// <summary>Retrieves the specified subset of segments stored in this ink object.</summary>
		/// <param name="startSegment">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the first segment in this ink object to retrieve.</para>
		/// </param>
		/// <param name="segments">
		/// <para>Type: <b><c>D2D1_INK_BEZIER_SEGMENT</c>*</b></para>
		/// <para>When this method returns, contains a pointer to an array of retrieved segments.</para>
		/// </param>
		/// <param name="segmentsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of segments to retrieve. Note that segmentsCount must be less than or equal to the number of segments in the ink
		/// object minus startSegment.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-getsegments HRESULT GetSegments( UINT32
		// startSegment, [out] D2D1_INK_BEZIER_SEGMENT *segments, UINT32 segmentsCount );
		void GetSegments(uint startSegment, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D2D1_INK_BEZIER_SEGMENT[] segments, int segmentsCount);

		/// <summary>Retrieves a geometric representation of this ink object.</summary>
		/// <param name="inkStyle">
		/// <para>Type: <b><c>ID2D1InkStyle</c>*</b></para>
		/// <para>The ink style to be used in determining the geometric representation.</para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>The world transform to be used in determining the geometric representation.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The flattening tolerance to be used in determining the geometric representation.</para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: <b><c>ID2D1SimplifiedGeometrySink</c>*</b></para>
		/// <para>The geometry sink to which the geometry representation will be streamed.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-streamasgeometry(id2d1inkstyle_constd2d1_matrix_3x2_f_float_id2d1simplifiedgeometrysink)
		// HRESULT StreamAsGeometry( [in, optional] ID2D1InkStyle *inkStyle, [in, optional] const D2D1_MATRIX_3X2_F *worldTransform, FLOAT
		// flatteningTolerance, [in] ID2D1SimplifiedGeometrySink *geometrySink );
		void StreamAsGeometry([In, Optional] ID2D1InkStyle? inkStyle, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform,
			float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE, [In] ID2D1SimplifiedGeometrySink? geometrySink = null);

		/// <summary>Retrieve the bounds of the geometry, with an optional applied transform.</summary>
		/// <param name="inkStyle">
		/// <para>Type: <b><c>ID2D1InkStyle</c>*</b></para>
		/// <para>The ink style to be used in determining the bounds of this ink object.</para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>The world transform to be used in determining the bounds of this ink object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D2D1_RECT_F</c>*</b></para>
		/// <para>When this method returns, contains the bounds of this ink object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-getbounds HRESULT GetBounds( [in, optional]
		// ID2D1InkStyle *inkStyle, [in, optional] const D2D1_MATRIX_3X2_F *worldTransform, [out] D2D1_RECT_F *bounds );
		D2D_RECT_F GetBounds([In, Optional] ID2D1InkStyle? inkStyle, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform);
	}

	/// <summary>
	/// Represents a collection of style properties to be used by methods like <c>ID2D1DeviceContext2::DrawInk</c> when rendering ink. The
	/// ink style defines the nib (pen tip) shape and transform.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1inkstyle
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1InkStyle")]
	[ComImport, Guid("BAE8B344-23FC-4071-8CB5-D05D6F073848"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1InkStyle : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Sets the transform to apply to this style's nib shape.</summary>
		/// <param name="transform">
		/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>
		/// The transform to apply to this style’s nib shape. Note that the translation components of the transform matrix are ignored for
		/// the purposes of rendering.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1inkstyle-setnibtransform(constd2d1_matrix_3x2_f) void
		// SetNibTransform( [in] const D2D1_MATRIX_3X2_F *transform );
		[PreserveSig]
		void SetNibTransform(in D2D_MATRIX_3X2_F transform);

		/// <summary>Retrieves the transform to be applied to this style's nib shape.</summary>
		/// <param name="transform">
		/// <para>Type: <b><c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>When this method returns, contains a pointer to the transform to be applied to this style's nib shape.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1inkstyle-getnibtransform void GetNibTransform( [out]
		// D2D1_MATRIX_3X2_F *transform );
		[PreserveSig]
		void GetNibTransform(out D2D_MATRIX_3X2_F transform);

		/// <summary>Sets the pre-transform nib shape for this style.</summary>
		/// <param name="nibShape">
		/// <para>Type: <b><c>D2D1_INK_NIB_SHAPE</c></b></para>
		/// <para>The pre-transform nib shape to use in this style.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1inkstyle-setnibshape void SetNibShape(
		// D2D1_INK_NIB_SHAPE nibShape );
		[PreserveSig]
		void SetNibShape(D2D1_INK_NIB_SHAPE nibShape);

		/// <summary>Retrieves the pre-transform nib shape for this style.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_INK_NIB_SHAPE</c></b></para>
		/// <para>Returns the pre-transform nib shape for this style.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1inkstyle-getnibshape D2D1_INK_NIB_SHAPE GetNibShape();
		[PreserveSig]
		D2D1_INK_NIB_SHAPE GetNibShape();
	}

	/// <summary>
	/// <para>A container for 3D lookup table data that can be passed to the LookupTable3D effect.</para>
	/// <para>An ID2DLookupTable3D instance is created using <c>ID2D1DeviceContext2::CreateLookupTable3D</c> or ID2D1EffectContext1::CreateLookupTable3D.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1lookuptable3d
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1LookupTable3D")]
	[ComImport, Guid("53DD9855-A3B0-4D5B-82E1-26E25C5E5797"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1LookupTable3D : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);
	}

	/// <summary>Represents a single group of sprites with their associated drawing properties.</summary>
	/// <remarks>
	/// <para>
	/// Create a new sprite batch using <c>ID2D1DeviceContext3::CreateSpriteBatch</c>. Use <c>ID2D1DeviceContext3::DrawSpriteBatch</c> to
	/// draw them.
	/// </para>
	/// <para>
	/// Sprites are a way for apps to draw a large number of images very efficiently. They are commonly used to render characters and
	/// backgrounds in 2D games, or to render particle systems such as smoke and flames. If your app has performance demands and needs to
	/// draw hundreds or thousands of images every frame, then consider taking advantage of sprite batches and the fine-grained control they
	/// offer, instead of the general-purpose DrawImage method.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1spritebatch
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1SpriteBatch")]
	[ComImport, Guid("4DC583BF-3A10-438A-8722-E9765224F1F1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SpriteBatch : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Adds the given sprites to the end of this sprite batch.</summary>
		/// <param name="spriteCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of sprites to be added. This determines how many strides into each given array Direct2D will read.</para>
		/// </param>
		/// <param name="destinationRectangles">
		/// <para>Type: <b>const <c>D2D1_RECT_F</c>*</b></para>
		/// <para>
		/// A pointer to an array containing the destination rectangles specifying where to draw the sprites on the destination device context.
		/// </para>
		/// </param>
		/// <param name="sourceRectangles">
		/// <para>Type: <b>const <c>D2D1_RECT_U</c>*</b></para>
		/// <para>
		/// A pointer to an array containing the source rectangles specifying the regions of the source bitmap to draw as sprites. Direct2D
		/// will use the entire source bitmap for sprites that are assigned a null value or the InfiniteRectU. If this parameter is omitted
		/// entirely or set to a null value, then Direct2D will use the entire source bitmap for all the added sprites.
		/// </para>
		/// </param>
		/// <param name="colors">
		/// <para>Type: <b>const <c>D2D1_COLOR_F</c>*</b></para>
		/// <para>
		/// A pointer to an array containing the colors to apply to each sprite. The output color is the result of component-wise
		/// multiplication of the source bitmap color and the provided color. The output color is not clamped.
		/// </para>
		/// <para>
		/// Direct2D will not change the color of sprites that are assigned a null value. If this parameter is omitted entirely or set to a
		/// null value, then Direct2D will not change the color of any of the added sprites.
		/// </para>
		/// </param>
		/// <param name="transforms">
		/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>A pointer to an array containing the transforms to apply to each sprite’s destination rectangle.</para>
		/// <para>
		/// Direct2D will not transform the destination rectangle of any sprites that are assigned a null value. If this parameter is
		/// omitted entirely or set to a null value, then Direct2D will not transform the destination rectangle of any of the added sprites.
		/// </para>
		/// </param>
		/// <param name="destinationRectanglesStride">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Specifies the distance, in bytes, between each rectangle in the destinationRectangles array. If you provide a stride of 0, then
		/// the same destination rectangle will be used for each added sprite.
		/// </para>
		/// </param>
		/// <param name="sourceRectanglesStride">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Specifies the distance, in bytes, between each rectangle in the sourceRectangles array (if that array is given). If you provide
		/// a stride of 0, then the same source rectangle will be used for each added sprite.
		/// </para>
		/// </param>
		/// <param name="colorsStride">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Specifies the distance, in bytes, between each color in the colors array (if that array is given). If you provide a stride of 0,
		/// then the same color will be used for each added sprite.
		/// </para>
		/// </param>
		/// <param name="transformsStride">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Specifies the distance, in bytes, between each transform in the transforms array (if that array is given). If you provide a
		/// stride of 0, then the same transform will be used for each added sprite.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// In Direct2D, a sprite is defined by four properties: a destination rectangle, a source rectangle, a color, and a transform.
		/// Destination rectangles are mandatory, but the remaining properties are optional.
		/// </para>
		/// <para>
		/// <b>Note</b>  Always omit or pass a null value for properties you do not wish to use. This allows Direct2D to avoid storing
		/// values for those properties and to skip their handling entirely, which improves drawing speed. For example, suppose you have a
		/// batch of 500 sprites, and you do not wish to transform any of their destination rectangles. Rather than passing an array of
		/// identity matrices, simply omit the transforms parameter. This allows Direct2D to avoid storing any transforms and will yield the
		/// fastest drawing performance. On the other hand, if any sprite in the batch has any value set for a property, then internally
		/// Direct2D must allocate space for that property array and assign every sprite a value for that property (even if it’s just the
		/// default value).
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1spritebatch-addsprites HRESULT AddSprites( UINT32
		// spriteCount, [in] const D2D1_RECT_F *destinationRectangles, [in, optional] const D2D1_RECT_U *sourceRectangles, [in, optional]
		// const D2D1_COLOR_F *colors, [in, optional] const D2D1_MATRIX_3X2_F *transforms, UINT32 destinationRectanglesStride, UINT32
		// sourceRectanglesStride, UINT32 colorsStride, UINT32 transformsStride );
		void AddSprites(uint spriteCount,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D2D_RECT_F[]? destinationRectangles,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D2D_RECT_U[]? sourceRectangles,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D2D1_COLOR_F[]? colors,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D2D1_MATRIX_3X2_F[]? transforms,
			uint destinationRectanglesStride, uint sourceRectanglesStride, uint colorsStride, uint transformsStride);

		/// <summary>
		/// Updates the properties of the specified sprites in this sprite batch.Providing a null value for any property will leave that
		/// property unmodified for that sprite.
		/// </summary>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the first sprite in this sprite batch to update.</para>
		/// </param>
		/// <param name="spriteCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The number of sprites to update with new properties. This determines how many strides into each given array Direct2D will read.
		/// </para>
		/// </param>
		/// <param name="destinationRectangles">
		/// <para>Type: <b>const <c>D2D1_RECT_F</c>*</b></para>
		/// <para>
		/// A pointer to an array containing the destination rectangles specifying where to draw the sprites on the destination device context.
		/// </para>
		/// </param>
		/// <param name="sourceRectangles">
		/// <para>Type: <b>const <c>D2D1_RECT_U</c>*</b></para>
		/// <para>A pointer to an array containing the source rectangles specifying the regions of the source bitmap to draw as sprites.</para>
		/// <para>
		/// Direct2D will use the entire source bitmap for sprites that are assigned a null value or the InfiniteRectU. If this parameter is
		/// omitted entirely or set to a null value, then Direct2D will use the entire source bitmap for all the updated sprites.
		/// </para>
		/// </param>
		/// <param name="colors">
		/// <para>Type: <b>const <c>D2D1_COLOR_F</c>*</b></para>
		/// <para>
		/// A pointer to an array containing the colors to apply to each sprite. The output color is the result of component-wise
		/// multiplication of the source bitmap color and the provided color. The output color is not clamped.
		/// </para>
		/// <para>
		/// Direct2D will not change the color of sprites that are assigned a null value. If this parameter is omitted entirely or set to a
		/// null value, then Direct2D will not change the color of any of the updated sprites.
		/// </para>
		/// </param>
		/// <param name="transforms">
		/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>A pointer to an array containing the transforms to apply to each sprite’s destination rectangle.</para>
		/// <para>
		/// Direct2D will not transform the destination rectangle of any sprites that are assigned a null value. If this parameter is
		/// omitted entirely or set to a null value, then Direct2D will not transform the destination rectangle of any of the updated sprites.
		/// </para>
		/// </param>
		/// <param name="destinationRectanglesStride">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Specifies the distance, in bytes, between each rectangle in the destinationRectangles array. If you provide a stride of 0, then
		/// the same destination rectangle will be used for each updated sprite.
		/// </para>
		/// </param>
		/// <param name="sourceRectanglesStride">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Specifies the distance, in bytes, between each rectangle in the sourceRectangles array (if that array is given). If you provide
		/// a stride of 0, then the same source rectangle will be used for each updated sprite.
		/// </para>
		/// </param>
		/// <param name="colorsStride">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Specifies the distance, in bytes, between each color in the colors array (if that array is given). If you provide a stride of 0,
		/// then the same color will be used for each updated sprite.
		/// </para>
		/// </param>
		/// <param name="transformsStride">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Specifies the distance, in bytes, between each transform in the transforms array (if that array is given). If you provide a
		/// stride of 0, then the same transform will be used for each updated sprite.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1spritebatch-setsprites HRESULT SetSprites( UINT32
		// startIndex, UINT32 spriteCount, [in, optional] const D2D1_RECT_F *destinationRectangles, [in, optional] const D2D1_RECT_U
		// *sourceRectangles, [in, optional] const D2D1_COLOR_F *colors, [in, optional] const D2D1_MATRIX_3X2_F *transforms, UINT32
		// destinationRectanglesStride, UINT32 sourceRectanglesStride, UINT32 colorsStride, UINT32 transformsStride );
		void SetSprites(uint startIndex, uint spriteCount,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] D2D_RECT_F[]? destinationRectangles,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] D2D_RECT_U[]? sourceRectangles,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] D2D1_COLOR_F[]? colors,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] D2D1_MATRIX_3X2_F[]? transforms,
			uint destinationRectanglesStride, uint sourceRectanglesStride, uint colorsStride, uint transformsStride);

		/// <summary>
		/// Retrieves the specified subset of sprites from this sprite batch. For the best performance, use nullptr for properties that you
		/// do not need to retrieve.
		/// </summary>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the first sprite in this sprite batch to retrieve.</para>
		/// </param>
		/// <param name="spriteCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of sprites to retrieve.</para>
		/// </param>
		/// <param name="destinationRectangles">
		/// <para>Type: <b><c>D2D1_RECT_F</c>*</b></para>
		/// <para>When this method returns, contains a pointer to an array containing the destination rectangles for the retrieved sprites.</para>
		/// </param>
		/// <param name="sourceRectangles">
		/// <para>Type: <b><c>D2D1_RECT_U</c>*</b></para>
		/// <para>When this method returns, contains a pointer to an array containing the source rectangles for the retrieved sprites.</para>
		/// <para>The <see cref="D2D_RECT_U.Infinite"/> is returned for any sprites that were not assigned a source rectangle.</para>
		/// </param>
		/// <param name="colors">
		/// <para>Type: <b><c>D2D1_COLOR_F</c>*</b></para>
		/// <para>When this method returns, contains a pointer to an array containing the colors to be applied to the retrieved sprites.</para>
		/// <para>The color {1.0f, 1.0f, 1.0f, 1.0f} is returned for any sprites that were not assigned a color.</para>
		/// </param>
		/// <param name="transforms">
		/// <para>Type: <b><c>D2D1_MATRIX_3X2_F</c>*</b></para>
		/// <para>When this method returns, contains a pointer to an array containing the transforms to be applied to the retrieved sprites.</para>
		/// <para>The identity matrix is returned for any sprites that were not assigned a transform.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1spritebatch-getsprites HRESULT GetSprites( UINT32
		// startIndex, UINT32 spriteCount, [out, optional] D2D1_RECT_F *destinationRectangles, [out, optional] D2D1_RECT_U
		// *sourceRectangles, [out, optional] D2D1_COLOR_F *colors, [out, optional] D2D1_MATRIX_3X2_F *transforms );
		void GetSprites(uint startIndex, int spriteCount,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D_RECT_F[]? destinationRectangles,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D_RECT_U[]? sourceRectangles,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_COLOR_F[]? colors,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_MATRIX_3X2_F[]? transforms);

		/// <summary>Retrieves the number of sprites in this sprite batch.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of sprites in this sprite batch</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1spritebatch-getspritecount UINT32 GetSpriteCount();
		[PreserveSig]
		uint GetSpriteCount();

		/// <summary>Removes all sprites from this sprite batch.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1spritebatch-clear void Clear();
		[PreserveSig]
		void Clear();
	}

	/// <summary>
	/// This object supplies the values for context-fill, context-stroke, and context-value that are used when rendering SVG glyphs.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1svgglyphstyle
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1SvgGlyphStyle")]
	[ComImport, Guid("AF671749-D241-4DB8-8E41-DCC2E5C1A438"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SvgGlyphStyle : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Provides values to an SVG glyph for fill.</summary>
		/// <param name="brush">
		/// <para>Type: <b><c>ID2D1Brush</c>*</b></para>
		/// <para>
		/// Describes how the area is painted. A null brush will cause the context-fill value to come from the <c>defaultFillBrush</c>. If
		/// the defaultFillBrush is also null, the context-fill value will be 'none'. To set the ‘context-fill’ value, this method uses the
		/// provided brush with its opacity set to 1. To set the ‘context-fill-opacity’ value, this method uses the opacity of the provided brush.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1svgglyphstyle-setfill HRESULT SetFill( [in, optional]
		// ID2D1Brush *brush );
		void SetFill([In, Optional] ID2D1Brush? brush);

		/// <summary>Returns the requested fill parameters.</summary>
		/// <param name="brush">
		/// <para>Type: <b><c>ID2D1Brush</c>**</b></para>
		/// <para>Describes how the area is painted.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1svgglyphstyle-getfill void GetFill( [out] ID2D1Brush
		// **brush );
		[PreserveSig]
		void GetFill(out ID2D1Brush? brush);

		/// <summary>
		/// Provides values to an SVG glyph for stroke properties. The brush with opacity set to 1 is used as the 'context-stroke'. The
		/// opacity of the brush is used as the 'context-stroke-opacity' value.
		/// </summary>
		/// <param name="brush">
		/// <para>Type: <b><c>ID2D1Brush</c>*</b></para>
		/// <para>Describes how the stroke is painted. A null brush will cause the context-stroke value to be none.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Specifies the 'context-value' for the 'stroke-width' property.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>
		/// Specifies the 'context-value' for the 'stroke-dasharray' property. A null value will cause the stroke-dasharray to be set to 'none'.
		/// </para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of dashes in the dash array.</para>
		/// </param>
		/// <param name="dashOffset">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Specifies the 'context-value' for the 'stroke-dashoffset' property.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1svgglyphstyle-setstroke HRESULT SetStroke( [in,
		// optional] ID2D1Brush *brush, FLOAT strokeWidth, [in, optional] const FLOAT *dashes, UINT32 dashesCount, FLOAT dashOffset );
		void SetStroke([In, Optional] ID2D1Brush? brush, float strokeWidth = 1f,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] float[]? dashes = null, uint dashesCount = 0, float dashOffset = 1f);

		/// <summary>Returns the number of dashes in the dash array.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of dashes in the dash array.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1svgglyphstyle-getstrokedashescount UINT32 GetStrokeDashesCount();
		[PreserveSig]
		uint GetStrokeDashesCount();

		/// <summary>
		/// Returns the requested stroke parameters. Any parameters that are non-null will receive the value of the requested parameter.
		/// </summary>
		/// <param name="brush">
		/// <para>Type: <b><c>ID2D1Brush</c>**</b></para>
		/// <para>Describes how the stroke is painted.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The 'context-value' for the 'stroke-width' property.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The 'context-value' for the 'stroke-dasharray' property.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of dashes in the dash array.</para>
		/// </param>
		/// <param name="dashOffset">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The 'context-value' for the 'stroke-dashoffset' property.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1svgglyphstyle-getstroke void GetStroke( [out, optional]
		// ID2D1Brush **brush, [out, optional] FLOAT *strokeWidth, [out, optional] FLOAT *dashes, UINT32 dashesCount, [out, optional] FLOAT
		// *dashOffset );
		[PreserveSig]
		void GetStroke([Out, Optional] IUnknownPointer<ID2D1Brush> brush, [Out, Optional] StructPointer<float> strokeWidth,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] float[]? dashes, uint dashesCount,
			[Out, Optional] StructPointer<float> dashOffset);
	}

	/// <summary>Represents an image source which shares resources with an original image source.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nn-d2d1_3-id2d1transformedimagesource
	[PInvokeData("d2d1_3.h", MSDNShortId = "NN:d2d1_3.ID2D1TransformedImageSource")]
	[ComImport, Guid("7F1F79E5-2796-416C-8F55-700F911445E5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1TransformedImageSource : ID2D1Resource, ID2D1Image
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>
		/// Retrieves the source image used to create the transformed image source. This value corresponds to the value passed to <c>CreateTransformedImageSource</c>.
		/// </summary>
		/// <param name="imageSource">
		/// <para>Type: <b>Outptr_result_maybenull**</b></para>
		/// <para>Retrieves the source image used to create the transformed image source.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1transformedimagesource-getsource void GetSource(
		// ID2D1ImageSource **imageSource );
		[PreserveSig]
		void GetSource(out ID2D1ImageSource? imageSource);

		/// <summary>
		/// Retrieves the properties specified when the transformed image source was created. This value corresponds to the value passed to <c>CreateTransformedImageSource</c>.
		/// </summary>
		/// <param name="properties">
		/// <para>Type: <b><c>D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES</c>*</b></para>
		/// <para>the properties specified when the transformed image source was created.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1transformedimagesource-getproperties void
		// GetProperties( [out] D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES *properties );
		[PreserveSig]
		void GetProperties(out D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES properties);
	}

	/// <summary>Retrieve the bounds of the geometry, with an optional applied transform.</summary>
	/// <param name="ink">The <see cref="ID2D1Ink"/> instance.</param>
	/// <param name="inkStyle">
	/// <para>Type: <b><c>ID2D1InkStyle</c>*</b></para>
	/// <para>The ink style to be used in determining the bounds of this ink object.</para>
	/// </param>
	/// <param name="worldTransform">
	/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c>*</b></para>
	/// <para>The world transform to be used in determining the bounds of this ink object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_RECT_F</c>*</b></para>
	/// <para>When this method returns, contains the bounds of this ink object.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-getbounds HRESULT GetBounds( [in, optional]
	// ID2D1InkStyle *inkStyle, [in, optional] const D2D1_MATRIX_3X2_F *worldTransform, [out] D2D1_RECT_F *bounds );
	public static D2D_RECT_F GetBounds(this ID2D1Ink ink, [In, Optional] ID2D1InkStyle? inkStyle, [In, Optional] D2D1_MATRIX_3X2_F? worldTransform)
	{
		SafeCoTaskMemStruct<D2D1_MATRIX_3X2_F> m = worldTransform;
		return ink.GetBounds(inkStyle, m);
	}

	/// <summary>Retrieves the specified subset of segments stored in this ink object.</summary>
	/// <param name="ink">The <see cref="ID2D1Ink"/> instance.</param>
	/// <param name="startSegment">The index of the first segment in this ink object to retrieve.</param>
	/// <returns>An array of retrieved segments.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-getsegments HRESULT GetSegments( UINT32 startSegment,
	// [out] D2D1_INK_BEZIER_SEGMENT *segments, UINT32 segmentsCount );
	public static D2D1_INK_BEZIER_SEGMENT[] GetSegments(this ID2D1Ink ink, uint startSegment = 0)
	{
		var c = ink.GetSegmentCount();
		var segs = new D2D1_INK_BEZIER_SEGMENT[c - startSegment];
		ink.GetSegments(startSegment, segs, segs.Length);
		return segs;
	}

	/// <summary>Returns the requested stroke parameters. Any parameters that are non-null will receive the value of the requested parameter.</summary>
	/// <param name="style">The <see cref="ID2D1SvgGlyphStyle"/> instance.</param>
	/// <param name="brush">Describes how the stroke is painted.</param>
	/// <param name="strokeWidth">The 'context-value' for the 'stroke-width' property.</param>
	/// <param name="dashes">The 'context-value' for the 'stroke-dasharray' property.</param>
	/// <param name="dashOffset">The 'context-value' for the 'stroke-dashoffset' property.</param>
	public static void GetStroke(this ID2D1SvgGlyphStyle style, out ID2D1Brush? brush, out float strokeWidth,
		out float[] dashes, out float dashOffset)
	{
		var dc = style.GetStrokeDashesCount();
		unsafe
		{
			IntPtr pb = default;
			float s = 0f, o = 0f;
			var d = new float[dc];
			style.GetStroke((IntPtr)(void*)&pb, &s, d, dc, &o);
			brush = pb == IntPtr.Zero ? null : (ID2D1Brush)Marshal.GetObjectForIUnknown(pb);
			strokeWidth = s;
			dashes = d;
			dashOffset = o;
		}
	}

	/// <summary>Retrieves a geometric representation of this ink object.</summary>
	/// <param name="ink">The <see cref="ID2D1Ink"/> instance.</param>
	/// <param name="inkStyle">
	/// <para>Type: <b><c>ID2D1InkStyle</c>*</b></para>
	/// <para>The ink style to be used in determining the geometric representation.</para>
	/// </param>
	/// <param name="worldTransform">
	/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c>*</b></para>
	/// <para>The world transform to be used in determining the geometric representation.</para>
	/// </param>
	/// <param name="flatteningTolerance">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The flattening tolerance to be used in determining the geometric representation.</para>
	/// </param>
	/// <param name="geometrySink">
	/// <para>Type: <b><c>ID2D1SimplifiedGeometrySink</c>*</b></para>
	/// <para>The geometry sink to which the geometry representation will be streamed.</para>
	/// </param>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-id2d1ink-streamasgeometry(id2d1inkstyle_constd2d1_matrix_3x2_f_float_id2d1simplifiedgeometrysink)
	// HRESULT StreamAsGeometry( [in, optional] ID2D1InkStyle *inkStyle, [in, optional] const D2D1_MATRIX_3X2_F *worldTransform, FLOAT
	// flatteningTolerance, [in] ID2D1SimplifiedGeometrySink *geometrySink );
	public static void StreamAsGeometry(this ID2D1Ink ink, [In] ID2D1SimplifiedGeometrySink geometrySink, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE,
		[In] ID2D1InkStyle? inkStyle = null, [In] D2D1_MATRIX_3X2_F? worldTransform = null)
	{
		SafeCoTaskMemStruct<D2D1_MATRIX_3X2_F> m = worldTransform;
		ink.StreamAsGeometry(inkStyle, m, flatteningTolerance, geometrySink);
	}
}