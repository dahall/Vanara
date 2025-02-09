namespace Vanara.PInvoke;

public static partial class Dwrite
{
	/// <summary>The <b>IDWriteAsyncResult</b> interface inherits from the IUnknown interface.</summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nn-dwrite_3-idwriteasyncresult
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteAsyncResult")]
	[ComImport, Guid("CE25F8FD-863B-4D13-9651-C1F88DC73FE2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteAsyncResult
	{
		/// <summary>
		/// Returns a handle that can be used to wait for the asynchronous operation to complete. The handle remains valid until the
		/// interface is released.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>HANDLE</b></para>
		/// <para>
		/// Returns a handle that can be used to wait for the asynchronous operation to complete. The handle remains valid until the
		/// interface is released.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwriteasyncresult-getwaithandle HANDLE GetWaitHandle();
		[PreserveSig]
		HANDLE GetWaitHandle();

		/// <summary/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwriteasyncresult-getresult HRESULT GetResult();
		void GetResult();
	}

	/// <summary>
	/// <para>Encapsulates a 32-bit device independent bitmap and device context, which can be used for rendering glyphs.</para>
	/// <para>
	/// <para>Important</para>
	/// <para>
	/// This API is available as part of the DWriteCore implementation of <c>DirectWrite</c>. For more info, and code examples, see
	/// <c>DWriteCore overview</c>.
	/// </para>
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nn-dwrite_3-idwritebitmaprendertarget2
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteBitmapRenderTarget2")]
	[ComImport, Guid("C553A742-FC01-44DA-A66E-B8B9ED6C3995"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteBitmapRenderTarget2 : IDWriteBitmapRenderTarget, IDWriteBitmapRenderTarget1
	{
		/// <summary>Draws a run of glyphs to a bitmap target at the specified position.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The vertical position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>The measuring method for glyphs in the run, used with the other properties to determine the rendering mode.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>The structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>The object that controls rendering behavior.</para>
		/// </param>
		/// <param name="textColor">
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>The foreground color of the text.</para>
		/// </param>
		/// <param name="blackBoxRect">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>
		/// The optional rectangle that receives the bounding box (in pixels not DIPs) of all the pixels affected by drawing the glyph run.
		/// The black box rectangle may extend beyond the dimensions of the bitmap.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// You can use the <c>IDWriteBitmapRenderTarget::DrawGlyphRun</c> to render to a bitmap from a custom text renderer that you
		/// implement. The custom text renderer should call this method from within the IDWriteTextRenderer::DrawGlyphRun callback method as
		/// shown in the following code.
		/// </para>
		/// <para>
		/// The baselineOriginX, baslineOriginY, measuringMethod, and glyphRun parameters are provided (as arguments) when the callback
		/// method is invoked. The renderingParams, textColor and blackBoxRect are not.
		/// </para>
		/// <para>Default rendering params can be retrieved by using the IDWriteFactory::CreateMonitorRenderingParams method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-drawglyphrun HRESULT DrawGlyphRun(
		// FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_MEASURING_MODE measuringMode, DWRITE_GLYPH_RUN const
		// *glyphRun, IDWriteRenderingParams *renderingParams, COLORREF textColor, RECT *blackBoxRect );
		new void DrawGlyphRun(float baselineOriginX, float baselineOriginY, DWRITE_MEASURING_MODE measuringMode, in DWRITE_GLYPH_RUN glyphRun, [In] IDWriteRenderingParams renderingParams, COLORREF textColor, out RECT blackBoxRect);

		/// <summary>Gets a handle to the memory device context.</summary>
		/// <returns>
		/// <para>Type: <c>HDC</c></para>
		/// <para>Returns a device context handle to the memory device context.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can use the device context to draw using GDI functions. An application can obtain the bitmap handle (HBITMAP) by
		/// calling GetCurrentObject. An application that wants information about the underlying bitmap, including a pointer to the pixel
		/// data, can call GetObject to fill in a DIBSECTION structure. The bitmap is always a 32-bit top-down DIB.
		/// </para>
		/// <para>Note that this method takes no parameters and returns an HDC variable, not an HRESULT.</para>
		/// <para>The HDC returned here is still owned by the bitmap render targer object and should not be released or deleted by the client.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getmemorydc HDC GetMemoryDC();
		[PreserveSig]
		new HDC GetMemoryDC();

		/// <summary>Gets the number of bitmap pixels per DIP.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of bitmap pixels per DIP.</para>
		/// </returns>
		/// <remarks>
		/// A DIP (device-independent pixel) is 1/96 inch. Therefore, this value is the number if pixels per inch divided by 96.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getpixelsperdip FLOAT GetPixelsPerDip();
		[PreserveSig]
		new float GetPixelsPerDip();

		/// <summary>
		/// Sets the number of bitmap pixels per DIP (device-independent pixel). A DIP is 1/96 inch, so this value is the number if pixels
		/// per inch divided by 96.
		/// </summary>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that specifies the number of pixels per DIP.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-setpixelsperdip HRESULT
		// SetPixelsPerDip( FLOAT pixelsPerDip );
		new void SetPixelsPerDip(float pixelsPerDip);

		/// <summary>
		/// Gets the transform that maps abstract coordinates to DIPs. By default this is the identity transform. Note that this is
		/// unrelated to the world transform of the underlying device context.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_MATRIX*</c></para>
		/// <para>When this method returns, contains a transform matrix.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getcurrenttransform HRESULT
		// GetCurrentTransform( DWRITE_MATRIX *transform );
		new DWRITE_MATRIX GetCurrentTransform();

		/// <summary>
		/// Sets the transform that maps abstract coordinate to DIPs (device-independent pixel). This does not affect the world transform of
		/// the underlying device context.
		/// </summary>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>Specifies the new transform. This parameter can be <c>NULL</c>, in which case the identity transform is implied.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-setcurrenttransform HRESULT
		// SetCurrentTransform( DWRITE_MATRIX const *transform );
		new void SetCurrentTransform([In, Optional] IntPtr transform);

		/// <summary>Gets the dimensions of the target bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>SIZE*</c></para>
		/// <para>Returns the width and height of the bitmap in pixels.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getsize HRESULT GetSize( SIZE
		// *size );
		new SIZE GetSize();

		/// <summary>Resizes the bitmap.</summary>
		/// <param name="width">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The new bitmap width, in pixels.</para>
		/// </param>
		/// <param name="height">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The new bitmap height, in pixels.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-resize HRESULT Resize( UINT32
		// width, UINT32 height );
		new void Resize(uint width, uint height);

		/// <summary>Gets the current text antialiasing mode of the bitmap render target.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>Returns a <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the antialiasing mode.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritebitmaprendertarget1-gettextantialiasmode
		// DWRITE_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();
		[PreserveSig]
		new DWRITE_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();

		/// <summary>Sets the current text antialiasing mode of the bitmap render target.</summary>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>A <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the antialiasing mode.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>Returns S_OK if successful, or E_INVALIDARG if the argument is not valid.</para>
		/// </returns>
		/// <remarks>
		/// The antialiasing mode of a newly-created bitmap render target defaults to <c>DWRITE_TEXT_ANTIALIAS_MODE_CLEARTYPE</c>. An app
		/// can change the antialiasing mode by calling <b>SetTextAntialiasMode</b>. For example, an app might specify
		/// <c>DWRITE_TEXT_ANTIALIAS_MODE_GRAYSCALE</c> for grayscale antialiasing when it renders text onto a transparent bitmap.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritebitmaprendertarget1-settextantialiasmode HRESULT
		// SetTextAntialiasMode( DWRITE_TEXT_ANTIALIAS_MODE antialiasMode );
		new void SetTextAntialiasMode(DWRITE_TEXT_ANTIALIAS_MODE antialiasMode);

		/// <summary>
		/// <para>Retrieves the pixel data from a bitmap render target.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This API is available as part of the DWriteCore implementation of <c>DirectWrite</c>. For more info, and code examples, see
		/// <c>DWriteCore overview</c>.
		/// </para>
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: _Out_ <b><c>DWRITE_BITMAP_DATA_BGRA32</c>*</b></para>
		/// <para>A pointer to the pixel data.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritebitmaprendertarget2-getbitmapdata
		// HRESULT GetBitmapData( DWRITE_BITMAP_DATA_BGRA32 *bitmapData );
		DWRITE_BITMAP_DATA_BGRA32 GetBitmapData();
	}

	/// <summary>
	/// <para>
	/// Encapsulates a 32-bit device independent bitmap and device context, which can be used for rendering glyphs.
	/// <b>IDWriteBitmapRenderTarget3</b> adds new methods to support advanced color fonts.
	/// </para>
	/// <para>The <b>IDWriteBitmapRenderTarget3</b> interface inherits from the <c>IDWriteBitmapRenderTarget2</c> interface.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nn-dwrite_3-idwritebitmaprendertarget3
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteBitmapRenderTarget3")]
	[ComImport, Guid("AEEC37DB-C337-40F1-8E2A-9A41B167B238"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteBitmapRenderTarget3 : IDWriteBitmapRenderTarget, IDWriteBitmapRenderTarget1, IDWriteBitmapRenderTarget2
	{
		/// <summary>Draws a run of glyphs to a bitmap target at the specified position.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The vertical position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>The measuring method for glyphs in the run, used with the other properties to determine the rendering mode.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>The structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>The object that controls rendering behavior.</para>
		/// </param>
		/// <param name="textColor">
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>The foreground color of the text.</para>
		/// </param>
		/// <param name="blackBoxRect">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>
		/// The optional rectangle that receives the bounding box (in pixels not DIPs) of all the pixels affected by drawing the glyph run.
		/// The black box rectangle may extend beyond the dimensions of the bitmap.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// You can use the <c>IDWriteBitmapRenderTarget::DrawGlyphRun</c> to render to a bitmap from a custom text renderer that you
		/// implement. The custom text renderer should call this method from within the IDWriteTextRenderer::DrawGlyphRun callback method as
		/// shown in the following code.
		/// </para>
		/// <para>
		/// The baselineOriginX, baslineOriginY, measuringMethod, and glyphRun parameters are provided (as arguments) when the callback
		/// method is invoked. The renderingParams, textColor and blackBoxRect are not.
		/// </para>
		/// <para>Default rendering params can be retrieved by using the IDWriteFactory::CreateMonitorRenderingParams method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-drawglyphrun HRESULT DrawGlyphRun(
		// FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_MEASURING_MODE measuringMode, DWRITE_GLYPH_RUN const
		// *glyphRun, IDWriteRenderingParams *renderingParams, COLORREF textColor, RECT *blackBoxRect );
		new void DrawGlyphRun(float baselineOriginX, float baselineOriginY, DWRITE_MEASURING_MODE measuringMode, in DWRITE_GLYPH_RUN glyphRun, [In] IDWriteRenderingParams renderingParams, COLORREF textColor, out RECT blackBoxRect);

		/// <summary>Gets a handle to the memory device context.</summary>
		/// <returns>
		/// <para>Type: <c>HDC</c></para>
		/// <para>Returns a device context handle to the memory device context.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can use the device context to draw using GDI functions. An application can obtain the bitmap handle (HBITMAP) by
		/// calling GetCurrentObject. An application that wants information about the underlying bitmap, including a pointer to the pixel
		/// data, can call GetObject to fill in a DIBSECTION structure. The bitmap is always a 32-bit top-down DIB.
		/// </para>
		/// <para>Note that this method takes no parameters and returns an HDC variable, not an HRESULT.</para>
		/// <para>The HDC returned here is still owned by the bitmap render targer object and should not be released or deleted by the client.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getmemorydc HDC GetMemoryDC();
		[PreserveSig]
		new HDC GetMemoryDC();

		/// <summary>Gets the number of bitmap pixels per DIP.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of bitmap pixels per DIP.</para>
		/// </returns>
		/// <remarks>
		/// A DIP (device-independent pixel) is 1/96 inch. Therefore, this value is the number if pixels per inch divided by 96.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getpixelsperdip FLOAT GetPixelsPerDip();
		[PreserveSig]
		new float GetPixelsPerDip();

		/// <summary>
		/// Sets the number of bitmap pixels per DIP (device-independent pixel). A DIP is 1/96 inch, so this value is the number if pixels
		/// per inch divided by 96.
		/// </summary>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that specifies the number of pixels per DIP.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-setpixelsperdip HRESULT
		// SetPixelsPerDip( FLOAT pixelsPerDip );
		new void SetPixelsPerDip(float pixelsPerDip);

		/// <summary>
		/// Gets the transform that maps abstract coordinates to DIPs. By default this is the identity transform. Note that this is
		/// unrelated to the world transform of the underlying device context.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_MATRIX*</c></para>
		/// <para>When this method returns, contains a transform matrix.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getcurrenttransform HRESULT
		// GetCurrentTransform( DWRITE_MATRIX *transform );
		new DWRITE_MATRIX GetCurrentTransform();

		/// <summary>
		/// Sets the transform that maps abstract coordinate to DIPs (device-independent pixel). This does not affect the world transform of
		/// the underlying device context.
		/// </summary>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>Specifies the new transform. This parameter can be <c>NULL</c>, in which case the identity transform is implied.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-setcurrenttransform HRESULT
		// SetCurrentTransform( DWRITE_MATRIX const *transform );
		new void SetCurrentTransform([In, Optional] IntPtr transform);

		/// <summary>Gets the dimensions of the target bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>SIZE*</c></para>
		/// <para>Returns the width and height of the bitmap in pixels.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getsize HRESULT GetSize( SIZE
		// *size );
		new SIZE GetSize();

		/// <summary>Resizes the bitmap.</summary>
		/// <param name="width">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The new bitmap width, in pixels.</para>
		/// </param>
		/// <param name="height">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The new bitmap height, in pixels.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-resize HRESULT Resize( UINT32
		// width, UINT32 height );
		new void Resize(uint width, uint height);

		/// <summary>Gets the current text antialiasing mode of the bitmap render target.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>Returns a <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the antialiasing mode.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritebitmaprendertarget1-gettextantialiasmode
		// DWRITE_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();
		[PreserveSig]
		new DWRITE_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();

		/// <summary>Sets the current text antialiasing mode of the bitmap render target.</summary>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>A <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the antialiasing mode.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>Returns S_OK if successful, or E_INVALIDARG if the argument is not valid.</para>
		/// </returns>
		/// <remarks>
		/// The antialiasing mode of a newly-created bitmap render target defaults to <c>DWRITE_TEXT_ANTIALIAS_MODE_CLEARTYPE</c>. An app
		/// can change the antialiasing mode by calling <b>SetTextAntialiasMode</b>. For example, an app might specify
		/// <c>DWRITE_TEXT_ANTIALIAS_MODE_GRAYSCALE</c> for grayscale antialiasing when it renders text onto a transparent bitmap.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritebitmaprendertarget1-settextantialiasmode HRESULT
		// SetTextAntialiasMode( DWRITE_TEXT_ANTIALIAS_MODE antialiasMode );
		new void SetTextAntialiasMode(DWRITE_TEXT_ANTIALIAS_MODE antialiasMode);

		/// <summary>
		/// <para>Retrieves the pixel data from a bitmap render target.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This API is available as part of the DWriteCore implementation of <c>DirectWrite</c>. For more info, and code examples, see
		/// <c>DWriteCore overview</c>.
		/// </para>
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: _Out_ <b><c>DWRITE_BITMAP_DATA_BGRA32</c>*</b></para>
		/// <para>A pointer to the pixel data.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritebitmaprendertarget2-getbitmapdata
		// HRESULT GetBitmapData( DWRITE_BITMAP_DATA_BGRA32 *bitmapData );
		new DWRITE_BITMAP_DATA_BGRA32 GetBitmapData();

		/// <summary>
		/// Retrieves the paint feature level supported by this render target. You can pass the return value of this method to
		/// <c>IDWriteFactory8::TranslateColorGlyphRun</c> in its paintFeatureLevel parameter.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_PAINT_FEATURE_LEVEL</c></b></para>
		/// <para>The paint feature level supported by this render target.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritebitmaprendertarget3-getpaintfeaturelevel
		// DWRITE_PAINT_FEATURE_LEVEL GetPaintFeatureLevel();
		[PreserveSig]
		DWRITE_PAINT_FEATURE_LEVEL GetPaintFeatureLevel();

		/// <summary>Draws a glyph run in a "paint" image format returned by <c>IDWriteColorGlyphRunEnumerator1</c>.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>X-coordinate of the baseline.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>Y-coordinate of the baseline.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Specifies measuring mode for positioning glyphs in the run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: _In_ <b><c>DWRITE_GLYPH_RUN</c> const*</b></para>
		/// <para>The glyph run to draw.</para>
		/// </param>
		/// <param name="glyphImageFormat">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>
		/// The image format of the color glyph run, as returned by <c>IDWriteColorGlyphRunEnumerator1</c>. This must be one of the "paint"
		/// image formats.
		/// </para>
		/// </param>
		/// <param name="textColor">
		/// <para>Type: <b><c>COLORREF</c></b></para>
		/// <para>Foreground color of the text, used in cases where a color glyph uses the text color.</para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font-defined color palette to use.</para>
		/// </param>
		/// <param name="blackBoxRect">
		/// <para>Type: _Out_opt_ <b><c>RECT</c> *</b></para>
		/// <para>
		/// Optional rectangle that receives the bounding box (in pixels, not DIPs) of all the pixels affected by drawing the glyph run. The
		/// black box rectangle might extend beyond the dimensions of the bitmap.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritebitmaprendertarget3-drawpaintglyphrun
		// HRESULT DrawPaintGlyphRun( FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_MEASURING_MODE measuringMode, DWRITE_GLYPH_RUN
		// const *glyphRun, DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, COLORREF textColor, UINT32 colorPaletteIndex, RECT *blackBoxRect );
		void DrawPaintGlyphRun(float baselineOriginX, float baselineOriginY, DWRITE_MEASURING_MODE measuringMode, in DWRITE_GLYPH_RUN glyphRun,
			DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, COLORREF textColor, uint colorPaletteIndex, [Out, Optional] PRECT? blackBoxRect);

		/// <summary>Draws a glyph run, using color representations of glyphs if available in the font.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>X-coordinate of the baseline.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>Y-coordinate of the baseline.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Specifies measuring mode for positioning glyphs in the run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: _In_ <b><c>DWRITE_GLYPH_RUN</c> const*</b></para>
		/// <para>The glyph run to draw.</para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: _In_ <b><c>IDWriteRenderingParams</c> *</b></para>
		/// <para>Object that controls rendering behavior.</para>
		/// </param>
		/// <param name="textColor">
		/// <para>Type: <b><c>COLORREF</c></b></para>
		/// <para>Foreground color of the text.</para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font-defined color palette to use.</para>
		/// </param>
		/// <param name="blackBoxRect">
		/// <para>Type: _Out_opt_ <b><c>RECT</c> *</b></para>
		/// <para>
		/// Optional rectangle that receives the bounding box (in pixels, not DIPs) of all the pixels affected by drawing the glyph run. The
		/// black box rectangle might extend beyond the dimensions of the bitmap.
		/// </para>
		/// </param>
		/// <remarks>
		/// This method internally calls <b>TranslateColorGlyphRun</b>, and then automatically calls the appropriate lower-level methods to
		/// render monochrome or color glyph runs.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritebitmaprendertarget3-drawglyphrunwithcolorsupport
		// HRESULT DrawGlyphRunWithColorSupport( FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_MEASURING_MODE measuringMode,
		// DWRITE_GLYPH_RUN const *glyphRun, IDWriteRenderingParams *renderingParams, COLORREF textColor, UINT32 colorPaletteIndex, RECT
		// *blackBoxRect );
		void DrawGlyphRunWithColorSupport(float baselineOriginX, float baselineOriginY, DWRITE_MEASURING_MODE measuringMode,
			in DWRITE_GLYPH_RUN glyphRun, [In] IDWriteRenderingParams renderingParams, COLORREF textColor, uint colorPaletteIndex,
			[Out, Optional] PRECT? blackBoxRect);
	}

	/// <summary>Enumerator for an ordered collection of color glyph runs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritecolorglyphrunenumerator1
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteColorGlyphRunEnumerator1")]
	[ComImport, Guid("7C5F86DA-C7A1-4F05-B8E1-55A179FE5A35"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteColorGlyphRunEnumerator1 : IDWriteColorGlyphRunEnumerator
	{
		/// <summary>Move to the next glyph run in the enumerator.</summary>
		/// <returns>
		/// <para>Type: <b>bool*</b></para>
		/// <para>Returns <b>TRUE</b> if there is a next glyph run.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritecolorglyphrunenumerator-movenext HRESULT
		// MoveNext( [out] bool *hasRun );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool MoveNext();

		/// <summary/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_2/nf-dwrite_2-idwritecolorglyphrunenumerator-getcurrentrun
		// HRESULT GetCurrentRun( DWRITE_COLOR_GLYPH_RUN const **colorGlyphRun );
		new DWRITE_COLOR_GLYPH_RUN GetCurrentRun();

		/// <summary>Gets the current color glyph run.</summary>
		/// <param name="colorGlyphRun">
		/// <para>Type: <b><c>DWRITE_COLOR_GLYPH_RUN1</c></b></para>
		/// <para>
		/// Receives a pointer to the color glyph run. The pointer remains valid until the next call to MoveNext or until the interface is released.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Standard HRESULT error code. An error is returned if there is no current glyph run, i.e., if MoveNext has not yet been called or
		/// if the end of the sequence has been reached.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritecolorglyphrunenumerator1-getcurrentrun HRESULT
		// GetCurrentRun( [out] DWRITE_COLOR_GLYPH_RUN1 const **colorGlyphRun );
		[PreserveSig]
		HRESULT GetCurrentRun(out DWRITE_COLOR_GLYPH_RUN1 colorGlyphRun);
	}

	/// <summary>The root factory interface for all <c>DirectWrite</c> objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefactory3
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFactory3")]
	[ComImport, Guid("9A1B41C3-D3BB-466A-87FC-FE67556A3B65"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFactory3 : IDWriteFactory, IDWriteFactory1, IDWriteFactory2
	{
		/// <summary>Gets an object which represents the set of installed fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the system font collection object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If this parameter is nonzero, the function performs an immediate check for changes to the set of installed fonts. If this
		/// parameter is <c>FALSE</c>, the function will still detect changes if the font cache service is running, but there may be some
		/// latency. For example, an application might specify <c>TRUE</c> if it has itself just installed a font and wants to be sure the
		/// font collection contains that font.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getsystemfontcollection HRESULT
		// GetSystemFontCollection( IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(out IDWriteFontCollection fontCollection, [MarshalAs(UnmanagedType.Bool)] bool checkForUpdates = false);

		/// <summary>Creates a font collection using a custom font collection loader.</summary>
		/// <param name="collectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>An application-defined font collection loader, which must have been previously registered using RegisterFontCollectionLoader.</para>
		/// </param>
		/// <param name="collectionKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// The key used by the loader to identify a collection of font files. The buffer allocated for this key should at least be the size
		/// of collectionKeySize.
		/// </para>
		/// </param>
		/// <param name="collectionKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size, in bytes, of the collection key.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// Contains an address of a pointer to the system font collection object if the method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontcollection HRESULT
		// CreateCustomFontCollection( IDWriteFontCollectionLoader *collectionLoader, void const *collectionKey, UINT32 collectionKeySize,
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection CreateCustomFontCollection([In] IDWriteFontCollectionLoader collectionLoader, [In] IntPtr collectionKey, uint collectionKeySize);

		/// <summary>Registers a custom font collection loader with the factory object.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be registered.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font collection loader with DirectWrite. The font collection loader interface, which should be
		/// implemented by a singleton object, handles enumerating font files in a font collection given a particular type of key. A given
		/// instance can only be registered once. Succeeding attempts will return an error, indicating that it has already been registered.
		/// Note that font file loader implementations must not register themselves with DirectWrite inside their constructors, and must not
		/// unregister themselves inside their destructors, because registration and unregistraton operations increment and decrement the
		/// object reference count respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be
		/// performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontcollectionloader HRESULT
		// RegisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void RegisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Unregisters a custom font collection loader that was previously registered using RegisterFontCollectionLoader.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be unregistered.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontcollectionloader HRESULT
		// UnregisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void UnregisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Creates a font file reference object from a local font file.</summary>
		/// <param name="filePath">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the absolute file path for the font file. Subsequent operations on the constructed object
		/// may fail if the user provided filePath doesn't correspond to a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>
		/// The last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time. You should specify this value to avoid extra disk access. Subsequent operations on the constructed object may
		/// fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font file reference object, or <c>NULL</c> in
		/// case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontfilereference HRESULT
		// CreateFontFileReference( WCHAR const *filePath, FILETIME const *lastWriteTime, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateFontFileReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] IntPtr lastWriteTime);

		/// <summary>Creates a reference to an application-specific font file resource.</summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A font file reference key that uniquely identifies the font file resource during the lifetime of fontFileLoader.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the font file reference key in bytes.</para>
		/// </param>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>The font file loader that will be used by the font system to load data from the file identified by fontFileReferenceKey.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// Contains an address of a pointer to the newly created font file object when this method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function is provided for cases when an application or a document needs to use a private font without having to install it
		/// on the system. fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontfilereference HRESULT
		// CreateCustomFontFileReference( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, IDWriteFontFileLoader
		// *fontFileLoader, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateCustomFontFileReference([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, [In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates an object that represents a font face.</summary>
		/// <param name="fontFaceType">
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of file format of the font face.</para>
		/// </param>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font files, in element count, required to represent the font face.</para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>const IDWriteFontFile*</c></para>
		/// <para>
		/// A font file object representing the font face. Because IDWriteFontFacemaintains its own references to the input font file
		/// objects, you may release them after this call.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face, in cases when the font files contain a collection of font faces. If the font files contain
		/// a single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontFaceSimulationFlags">
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>
		/// A value that indicates which, if any, font face simulation flags for algorithmic means of making text bold or italic are applied
		/// to the current font face.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font face object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontface HRESULT CreateFontFace(
		// DWRITE_FONT_FACE_TYPE fontFaceType, UINT32 numberOfFiles, IDWriteFontFile * const *fontFiles, UINT32 faceIndex,
		// DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags, IDWriteFontFace **fontFace );
		new IDWriteFontFace CreateFontFace(DWRITE_FONT_FACE_TYPE fontFaceType, uint numberOfFiles,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[] fontFiles,
			uint faceIndex, DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags);

		/// <summary>
		/// Creates a rendering parameters object with default settings for the primary monitor. Different monitors may have different
		/// rendering parameters, for more information see the How to Add Support for Multiple Monitors topic.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createrenderingparams HRESULT
		// CreateRenderingParams( IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateRenderingParams();

		/// <summary>
		/// Creates a rendering parameters object with default settings for the specified monitor. In most cases, this is the preferred way
		/// to create a rendering parameters object.
		/// </summary>
		/// <param name="monitor">
		/// <para>Type: <c>HMONITOR</c></para>
		/// <para>A handle for the specified monitor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the rendering parameters object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createmonitorrenderingparams HRESULT
		// CreateMonitorRenderingParams( HMONITOR monitor, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateMonitorRenderingParams(HMONITOR monitor);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color
		/// components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry,
		// DWRITE_RENDERING_MODE renderingMode, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Registers a font file loader with DirectWrite.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to a IDWriteFontFileLoader object for a particular file resource type.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font file loader with DirectWrite. The font file loader interface, which should be implemented by a
		/// singleton object, handles loading font file resources of a particular type from a key. A given instance can only be registered
		/// once. Succeeding attempts will return an error, indicating that it has already been registered. Note that font file loader
		/// implementations must not register themselves with DirectWrite inside their constructors, and must not unregister themselves
		/// inside their destructors, because registration and unregistraton operations increment and decrement the object reference count
		/// respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be performed outside of the
		/// font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontfileloader HRESULT
		// RegisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void RegisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Unregisters a font file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to the file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</para>
		/// </param>
		/// <remarks>
		/// This function unregisters font file loader callbacks with the DirectWrite font system. You should implement the font file loader
		/// interface by a singleton object. Note that font file loader implementations must not register themselves with DirectWrite inside
		/// their constructors and must not unregister themselves in their destructors, because registration and unregistraton operations
		/// increment and decrement the object reference count respectively. Instead, registration and unregistration of font file loaders
		/// with DirectWrite should be performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontfileloader HRESULT
		// UnregisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void UnregisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates a text format object used for text layout.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the name of the font family</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>A pointer to a font collection object. When this is <c>NULL</c>, indicates the system font collection.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the font weight for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that indicates the font style for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that indicates the font stretch for the text object created by this method.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP ("device-independent pixel") units. A DIP equals 1/96 inch.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the locale name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextFormat**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a newly created text format object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextformat HRESULT CreateTextFormat(
		// WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STYLE fontStyle,
		// DWRITE_FONT_STRETCH fontStretch, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat **textFormat );
		new IDWriteTextFormat CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection, DWRITE_FONT_WEIGHT fontWeight,
			DWRITE_FONT_STYLE fontStyle, DWRITE_FONT_STRETCH fontStretch, float fontSize, [MarshalAs(UnmanagedType.LPWStr)] string localeName);

		/// <summary>Creates a typography object for use in a text layout.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a newly created typography object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtypography HRESULT CreateTypography(
		// IDWriteTypography **typography );
		new IDWriteTypography CreateTypography();

		/// <summary>Creates an object that is used for interoperability with GDI.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteGdiInterop**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a GDI interop object if successful, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getgdiinterop HRESULT GetGdiInterop(
		// IDWriteGdiInterop **gdiInterop );
		new IDWriteGdiInterop GetGdiInterop();

		/// <summary>
		/// Takes a string, text format, and associated constraints, and produces an object that represents the fully analyzed and formatted result.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of characters in the string.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A pointer to an object that indicates the format to apply to the string.</para>
		/// </param>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the resultant text layout object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextlayout HRESULT CreateTextLayout(
		// WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT maxWidth, FLOAT maxHeight, IDWriteTextLayout
		// **textLayout );
		new IDWriteTextLayout CreateTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, float maxWidth, float maxHeight);

		/// <summary>
		/// Takes a string, format, and associated constraints, and produces an object representing the result, formatted for a particular
		/// display resolution and measuring mode.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length of the string, in character count.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>The text formatting object to apply to the string.</para>
		/// </param>
		/// <param name="layoutWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="layoutHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI device pixelsPerDipis
		/// 1. If rendering onto a 120 DPI device pixelsPerDip is 1.25 (120/96).
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specifies the font
		/// size and pixels per DIP.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Instructs the text layout to use the same metrics as GDI bi-level text when set to <c>FALSE</c>. When set to <c>TRUE</c>,
		/// instructs the text layout to use the same metrics as text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address to the pointer of the resultant text layout object.</para>
		/// </returns>
		/// <remarks>
		/// The resulting text layout should only be used for the intended resolution, and for cases where text scalability is desired
		/// CreateTextLayout should be used instead.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-creategdicompatibletextlayout HRESULT
		// CreateGdiCompatibleTextLayout( WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT layoutWidth, FLOAT
		// layoutHeight, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, IDWriteTextLayout **textLayout );
		new IDWriteTextLayout CreateGdiCompatibleTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat,
			float layoutWidth, float layoutHeight, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural);

		/// <summary>Creates an inline object for trimming, using an ellipsis as the omission sign.</summary>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A text format object, created with CreateTextFormat, used for text layout.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the omission (that is, ellipsis trimming) sign created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The ellipsis will be created using the current settings of the format, including base font, style, and any effects. Alternate
		/// omission signs can be created by the application by implementing IDWriteInlineObject.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createellipsistrimmingsign HRESULT
		// CreateEllipsisTrimmingSign( IDWriteTextFormat *textFormat, IDWriteInlineObject **trimmingSign );
		new IDWriteInlineObject CreateEllipsisTrimmingSign([In] IDWriteTextFormat textFormat);

		/// <summary>Returns an interface for performing text analysis.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTextAnalyzer**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created text analyzer object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextanalyzer HRESULT CreateTextAnalyzer(
		// IDWriteTextAnalyzer **textAnalyzer );
		new IDWriteTextAnalyzer CreateTextAnalyzer();

		/// <summary>
		/// Creates a number substitution object using a locale name, substitution method, and an indicator whether to ignore user overrides
		/// (use NLS defaults for the given culture instead).
		/// </summary>
		/// <param name="substitutionMethod">
		/// <para>Type: <c>DWRITE_NUMBER_SUBSTITUTION_METHOD</c></para>
		/// <para>A value that specifies how to apply number substitution on digits and related punctuation.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The name of the locale to be used in the numberSubstitution object.</para>
		/// </param>
		/// <param name="ignoreUserOverride">
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag that indicates whether to ignore user overrides.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteNumberSubstitution**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the number substitution object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createnumbersubstitution HRESULT
		// CreateNumberSubstitution( DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, WCHAR const *localeName, bool ignoreUserOverride,
		// IDWriteNumberSubstitution **numberSubstitution );
		new IDWriteNumberSubstitution CreateNumberSubstitution([In] DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, [MarshalAs(UnmanagedType.LPWStr)] string localeName, [In][MarshalAs(UnmanagedType.Bool)] bool ignoreUserOverride);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>A structure that contains the properties of the glyph run (font face, advances, and so on).</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI bitmap then pixelsPerDipis
		/// 1. If rendering onto a 120 DPI bitmap then pixelsPerDip is 1.25.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified the emSize
		/// and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>
		/// A value that specifies the rendering mode, which must be one of the raster rendering modes (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>Specifies the measuring mode to use with glyphs.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal position (X-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Vertical position (Y-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteGlyphRunAnalysis**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created glyph run analysis object.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The glyph run analysis object contains the results of analyzing the glyph run, including the positions of all the glyphs and
		/// references to all of the rasterized glyphs in the font cache.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to create a glyph run analysis object. In this example, an empty glyph run is being used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( DWRITE_GLYPH_RUN const *glyphRun, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, FLOAT baselineOriginX, FLOAT baselineOriginY,
		// IDWriteGlyphRunAnalysis **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, float pixelsPerDip, [In, Optional] IntPtr transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Gets a font collection representing the set of EUDC (end-user defined characters) fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>**</b></para>
		/// <para>The font collection to fill.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether to check for updates.</para>
		/// </param>
		/// <remarks>
		/// Note that if no EUDC is set on the system, the returned collection will be empty, meaning it will return success but
		/// GetFontFamilyCount will be zero.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-geteudcfontcollection HRESULT
		// GetEudcFontCollection( [out] IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetEudcFontCollection(out IDWriteFontCollection fontCollection, bool checkForUpdates = false);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrastGrayscale">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color components)
		/// that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams1</c>**</b></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT enhancedContrastGrayscale, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, [out] IDWriteRenderingParams1 **renderingParams );
		new IDWriteRenderingParams1 CreateCustomRenderingParams(float gamma, float enhancedContrast, float enhancedContrastGrayscale, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Creates a font fallback object from the system font fallback list.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallback</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-getsystemfontfallback HRESULT
		// GetSystemFontFallback( [out] IDWriteFontFallback **fontFallback );
		new IDWriteFontFallback GetSystemFontFallback();

		/// <summary>
		/// <para>Creates a font fallback builder object.</para>
		/// <para>
		/// A font fall back builder allows you to create Unicode font fallback mappings and create a font fall back object from those mappings.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallbackBuilder</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback builder object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createfontfallbackbuilder HRESULT
		// CreateFontFallbackBuilder( [out] IDWriteFontFallbackBuilder **fontFallbackBuilder );
		new IDWriteFontFallbackBuilder CreateFontFallbackBuilder();

		/// <summary>This method is called on a glyph run to translate it in to multiple color glyph runs.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Original glyph run containing monochrome glyph IDs.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN_DESCRIPTION</c>*</b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode used to compute glyph positions if the run contains color glyphs.</para>
		/// </param>
		/// <param name="worldToDeviceTransform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// World transform multiplied by any DPI scaling. This is needed to compute glyph positions if the run contains color glyphs and
		/// the measuring mode is not <c>DWRITE_MEASURING_MODE_NATURAL</c>. If this parameter is <b>NULL</b>, and identity transform is assumed.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator</c>**</b></para>
		/// <para>
		/// If the original glyph run contains color glyphs, this parameter receives a pointer to an <c>IDWriteColorGlyphRunEnumerator</c>
		/// interface. The client uses the returned interface to get information about glyph runs and associated colors to render instead of
		/// the original glyph run. If the original glyph run does not contain color glyphs, this method returns <b>DWRITE_E_NOCOLOR</b> and
		/// the output pointer is <b>NULL</b>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If the code calls this method with a glyph run that contains no color information, the method returns <b>DWRITE_E_NOCOLOR</b> to
		/// let the application know that it can just draw the original glyph run. If the glyph run contains color information, the function
		/// returns an object that can be enumerated through to expose runs and associated colors. The application then calls
		/// <c>DrawGlyphRun</c> with each of the returned glyph runs and foreground colors.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( FLOAT baselineOriginX, FLOAT baselineOriginY, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const
		// *worldToDeviceTransform, UINT32 colorPaletteIndex, [out] IDWriteColorGlyphRunEnumerator **colorLayers );
		new IDWriteColorGlyphRunEnumerator TranslateColorGlyphRun(float baselineOriginX, float baselineOriginY, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldToDeviceTransform, uint colorPaletteIndex);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>The geometry of a device pixel.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>
		/// Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// How to grid fit glyph outlines. In most cases, this should be DWRITE_GRID_FIT_DEFAULT to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams2</c>**</b></para>
		/// <para>Holds the newly created rendering parameters object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams2 **renderingParams );
		new IDWriteRenderingParams2 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Structure specifying the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// emSize and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b>DWRITE_RENDERING_MODE</b></para>
		/// <para>Specifies the rendering mode, which must be one of the raster rendering modes (i.e., not default and not outline).</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Specifies the method to measure glyphs.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>How to grid-fit glyph outlines. This must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>Specifies the antialias mode.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Horizontal position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Vertical position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>Receives a pointer to the newly created object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode, DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
			float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a glyph-run-analysis object that encapsulates info that <c>DirectWrite</c> uses to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>A <c>DWRITE_GLYPH_RUN</c> structure that contains the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the optional transform to be applied to glyphs and their positions.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the rendering mode, which must be one of the raster rendering modes
		/// (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the measuring method for glyphs in the run. This method uses this
		/// value with the other properties to determine the rendering mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. This value must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the type of antialiasing to use for text when the rendering mode
		/// calls for antialiasing.
		/// </para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteGlyphRunAnalysis</c> interface for the newly created
		/// glyph-run-analysis object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
			DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// A <c>DWRITE_PIXEL_GEOMETRY</c>-typed value that specifies the internal structure of a device pixel (that is, the physical
		/// arrangement of red, green, and blue color components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the method (for example, ClearType natural quality) for rendering
		/// glyphs. In most cases, specify <b>DWRITE_RENDERING_MODE1_DEFAULT</b> to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. In most cases, specify
		/// <b>DWRITE_GRID_FIT_DEFAULT</b> to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams3</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteRenderingParams3</c> interface for the newly created
		/// rendering parameters object, or <b>NULL</b> in case of failure.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams3 **renderingParams );
		IDWriteRenderingParams3 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a reference to a font given a full path.</summary>
		/// <param name="filePath">
		/// <para>Type: [in] <b>WCHAR</b></para>
		/// <para>
		/// Absolute file path. Subsequent operations on the constructed object may fail if the user provided filePath doesn't correspond to
		/// a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: [in, optional] <b>FILETIME</b></para>
		/// <para>
		/// Last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time, so the clients are encouraged to specify this value to avoid extra disk access. Subsequent operations on the
		/// constructed object may fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(wcharconst_filetimeconst_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( WCHAR const *filePath, FILETIME const *lastWriteTime, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS
		// fontSimulations, IDWriteFontFaceReference **fontFaceReference );
		IDWriteFontFaceReference CreateFontFaceReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] PFILETIME? lastWriteTime, uint faceIndex,
			DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Creates a reference to a font given an <b>IDWriteFontFile</b>.</summary>
		/// <param name="fontFile">An <b>IDWriteFontFile</b> representing the font face.</param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(idwritefontfile_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( IDWriteFontFile *fontFile, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations, [out]
		// IDWriteFontFaceReference **fontFaceReference );
		IDWriteFontFaceReference CreateFontFaceReference([In] IDWriteFontFile fontFile, uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Retrieves the list of system fonts.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Holds the newly created font set object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontset HRESULT
		// GetSystemFontSet( [out] IDWriteFontSet **fontSet );
		IDWriteFontSet GetSystemFontSet();

		/// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder</c>**</b></para>
		/// <para>Holds the newly created font set builder object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( [out] IDWriteFontSetBuilder **fontSetBuilder );
		IDWriteFontSetBuilder CreateFontSetBuilder();

		/// <summary>Create a weight/width/slope tree from a set of fonts.</summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>A set of fonts to use to build the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontcollectionfromfontset HRESULT
		// CreateFontCollectionFromFontSet( IDWriteFontSet *fontSet, [out] IDWriteFontCollection1 **fontCollection );
		IDWriteFontCollection1 CreateFontCollectionFromFontSet(IDWriteFontSet fontSet);

		/// <summary>Retrieves a weight/width/slope tree of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// <para>Type: <b>bool</b></para>
		/// <para>Indicates whether to include cloud fonts or only locally installed fonts.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// If this parameter is TRUE, the function performs an immediate check for changes to the set of system fonts. If this parameter is
		/// FALSE, the function will still detect changes if the font cache service is running, but there may be some latency. For example,
		/// an application might specify TRUE if it has just installed a font and wants to be sure the font collection contains that font.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontcollection HRESULT
		// GetSystemFontCollection( bool includeDownloadableFonts, IDWriteFontCollection1 **fontCollection, bool checkForUpdates );
		void GetSystemFontCollection(bool includeDownloadableFonts, out IDWriteFontCollection1 fontCollection, bool checkForUpdates = false);

		/// <summary>Gets the font download queue associated with this factory object.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontDownloadQueue</c>**</b></para>
		/// <para>Receives a pointer to the font download queue interface.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getfontdownloadqueue HRESULT
		// GetFontDownloadQueue( [out] IDWriteFontDownloadQueue **fontDownloadQueue );
		IDWriteFontDownloadQueue GetFontDownloadQueue();
	}

	/// <summary>The root factory interface for all DirectWrite objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefactory4
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFactory4")]
	[ComImport, Guid("4B0B5BD3-0797-4549-8AC5-FE915CC53856"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFactory4 : IDWriteFactory, IDWriteFactory1, IDWriteFactory2, IDWriteFactory3
	{
		/// <summary>Gets an object which represents the set of installed fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the system font collection object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If this parameter is nonzero, the function performs an immediate check for changes to the set of installed fonts. If this
		/// parameter is <c>FALSE</c>, the function will still detect changes if the font cache service is running, but there may be some
		/// latency. For example, an application might specify <c>TRUE</c> if it has itself just installed a font and wants to be sure the
		/// font collection contains that font.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getsystemfontcollection HRESULT
		// GetSystemFontCollection( IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(out IDWriteFontCollection fontCollection, [MarshalAs(UnmanagedType.Bool)] bool checkForUpdates = false);

		/// <summary>Creates a font collection using a custom font collection loader.</summary>
		/// <param name="collectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>An application-defined font collection loader, which must have been previously registered using RegisterFontCollectionLoader.</para>
		/// </param>
		/// <param name="collectionKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// The key used by the loader to identify a collection of font files. The buffer allocated for this key should at least be the size
		/// of collectionKeySize.
		/// </para>
		/// </param>
		/// <param name="collectionKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size, in bytes, of the collection key.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// Contains an address of a pointer to the system font collection object if the method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontcollection HRESULT
		// CreateCustomFontCollection( IDWriteFontCollectionLoader *collectionLoader, void const *collectionKey, UINT32 collectionKeySize,
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection CreateCustomFontCollection([In] IDWriteFontCollectionLoader collectionLoader, [In] IntPtr collectionKey, uint collectionKeySize);

		/// <summary>Registers a custom font collection loader with the factory object.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be registered.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font collection loader with DirectWrite. The font collection loader interface, which should be
		/// implemented by a singleton object, handles enumerating font files in a font collection given a particular type of key. A given
		/// instance can only be registered once. Succeeding attempts will return an error, indicating that it has already been registered.
		/// Note that font file loader implementations must not register themselves with DirectWrite inside their constructors, and must not
		/// unregister themselves inside their destructors, because registration and unregistraton operations increment and decrement the
		/// object reference count respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be
		/// performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontcollectionloader HRESULT
		// RegisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void RegisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Unregisters a custom font collection loader that was previously registered using RegisterFontCollectionLoader.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be unregistered.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontcollectionloader HRESULT
		// UnregisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void UnregisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Creates a font file reference object from a local font file.</summary>
		/// <param name="filePath">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the absolute file path for the font file. Subsequent operations on the constructed object
		/// may fail if the user provided filePath doesn't correspond to a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>
		/// The last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time. You should specify this value to avoid extra disk access. Subsequent operations on the constructed object may
		/// fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font file reference object, or <c>NULL</c> in
		/// case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontfilereference HRESULT
		// CreateFontFileReference( WCHAR const *filePath, FILETIME const *lastWriteTime, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateFontFileReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] IntPtr lastWriteTime);

		/// <summary>Creates a reference to an application-specific font file resource.</summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A font file reference key that uniquely identifies the font file resource during the lifetime of fontFileLoader.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the font file reference key in bytes.</para>
		/// </param>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>The font file loader that will be used by the font system to load data from the file identified by fontFileReferenceKey.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// Contains an address of a pointer to the newly created font file object when this method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function is provided for cases when an application or a document needs to use a private font without having to install it
		/// on the system. fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontfilereference HRESULT
		// CreateCustomFontFileReference( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, IDWriteFontFileLoader
		// *fontFileLoader, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateCustomFontFileReference([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, [In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates an object that represents a font face.</summary>
		/// <param name="fontFaceType">
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of file format of the font face.</para>
		/// </param>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font files, in element count, required to represent the font face.</para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>const IDWriteFontFile*</c></para>
		/// <para>
		/// A font file object representing the font face. Because IDWriteFontFacemaintains its own references to the input font file
		/// objects, you may release them after this call.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face, in cases when the font files contain a collection of font faces. If the font files contain
		/// a single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontFaceSimulationFlags">
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>
		/// A value that indicates which, if any, font face simulation flags for algorithmic means of making text bold or italic are applied
		/// to the current font face.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font face object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontface HRESULT CreateFontFace(
		// DWRITE_FONT_FACE_TYPE fontFaceType, UINT32 numberOfFiles, IDWriteFontFile * const *fontFiles, UINT32 faceIndex,
		// DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags, IDWriteFontFace **fontFace );
		new IDWriteFontFace CreateFontFace(DWRITE_FONT_FACE_TYPE fontFaceType, uint numberOfFiles,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[] fontFiles,
			uint faceIndex, DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags);

		/// <summary>
		/// Creates a rendering parameters object with default settings for the primary monitor. Different monitors may have different
		/// rendering parameters, for more information see the How to Add Support for Multiple Monitors topic.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createrenderingparams HRESULT
		// CreateRenderingParams( IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateRenderingParams();

		/// <summary>
		/// Creates a rendering parameters object with default settings for the specified monitor. In most cases, this is the preferred way
		/// to create a rendering parameters object.
		/// </summary>
		/// <param name="monitor">
		/// <para>Type: <c>HMONITOR</c></para>
		/// <para>A handle for the specified monitor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the rendering parameters object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createmonitorrenderingparams HRESULT
		// CreateMonitorRenderingParams( HMONITOR monitor, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateMonitorRenderingParams(HMONITOR monitor);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color
		/// components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry,
		// DWRITE_RENDERING_MODE renderingMode, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Registers a font file loader with DirectWrite.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to a IDWriteFontFileLoader object for a particular file resource type.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font file loader with DirectWrite. The font file loader interface, which should be implemented by a
		/// singleton object, handles loading font file resources of a particular type from a key. A given instance can only be registered
		/// once. Succeeding attempts will return an error, indicating that it has already been registered. Note that font file loader
		/// implementations must not register themselves with DirectWrite inside their constructors, and must not unregister themselves
		/// inside their destructors, because registration and unregistraton operations increment and decrement the object reference count
		/// respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be performed outside of the
		/// font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontfileloader HRESULT
		// RegisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void RegisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Unregisters a font file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to the file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</para>
		/// </param>
		/// <remarks>
		/// This function unregisters font file loader callbacks with the DirectWrite font system. You should implement the font file loader
		/// interface by a singleton object. Note that font file loader implementations must not register themselves with DirectWrite inside
		/// their constructors and must not unregister themselves in their destructors, because registration and unregistraton operations
		/// increment and decrement the object reference count respectively. Instead, registration and unregistration of font file loaders
		/// with DirectWrite should be performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontfileloader HRESULT
		// UnregisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void UnregisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates a text format object used for text layout.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the name of the font family</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>A pointer to a font collection object. When this is <c>NULL</c>, indicates the system font collection.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the font weight for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that indicates the font style for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that indicates the font stretch for the text object created by this method.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP ("device-independent pixel") units. A DIP equals 1/96 inch.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the locale name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextFormat**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a newly created text format object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextformat HRESULT CreateTextFormat(
		// WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STYLE fontStyle,
		// DWRITE_FONT_STRETCH fontStretch, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat **textFormat );
		new IDWriteTextFormat CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection, DWRITE_FONT_WEIGHT fontWeight,
			DWRITE_FONT_STYLE fontStyle, DWRITE_FONT_STRETCH fontStretch, float fontSize, [MarshalAs(UnmanagedType.LPWStr)] string localeName);

		/// <summary>Creates a typography object for use in a text layout.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a newly created typography object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtypography HRESULT CreateTypography(
		// IDWriteTypography **typography );
		new IDWriteTypography CreateTypography();

		/// <summary>Creates an object that is used for interoperability with GDI.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteGdiInterop**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a GDI interop object if successful, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getgdiinterop HRESULT GetGdiInterop(
		// IDWriteGdiInterop **gdiInterop );
		new IDWriteGdiInterop GetGdiInterop();

		/// <summary>
		/// Takes a string, text format, and associated constraints, and produces an object that represents the fully analyzed and formatted result.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of characters in the string.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A pointer to an object that indicates the format to apply to the string.</para>
		/// </param>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the resultant text layout object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextlayout HRESULT CreateTextLayout(
		// WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT maxWidth, FLOAT maxHeight, IDWriteTextLayout
		// **textLayout );
		new IDWriteTextLayout CreateTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, float maxWidth, float maxHeight);

		/// <summary>
		/// Takes a string, format, and associated constraints, and produces an object representing the result, formatted for a particular
		/// display resolution and measuring mode.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length of the string, in character count.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>The text formatting object to apply to the string.</para>
		/// </param>
		/// <param name="layoutWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="layoutHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI device pixelsPerDipis
		/// 1. If rendering onto a 120 DPI device pixelsPerDip is 1.25 (120/96).
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specifies the font
		/// size and pixels per DIP.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Instructs the text layout to use the same metrics as GDI bi-level text when set to <c>FALSE</c>. When set to <c>TRUE</c>,
		/// instructs the text layout to use the same metrics as text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address to the pointer of the resultant text layout object.</para>
		/// </returns>
		/// <remarks>
		/// The resulting text layout should only be used for the intended resolution, and for cases where text scalability is desired
		/// CreateTextLayout should be used instead.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-creategdicompatibletextlayout HRESULT
		// CreateGdiCompatibleTextLayout( WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT layoutWidth, FLOAT
		// layoutHeight, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, IDWriteTextLayout **textLayout );
		new IDWriteTextLayout CreateGdiCompatibleTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat,
			float layoutWidth, float layoutHeight, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural);

		/// <summary>Creates an inline object for trimming, using an ellipsis as the omission sign.</summary>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A text format object, created with CreateTextFormat, used for text layout.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the omission (that is, ellipsis trimming) sign created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The ellipsis will be created using the current settings of the format, including base font, style, and any effects. Alternate
		/// omission signs can be created by the application by implementing IDWriteInlineObject.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createellipsistrimmingsign HRESULT
		// CreateEllipsisTrimmingSign( IDWriteTextFormat *textFormat, IDWriteInlineObject **trimmingSign );
		new IDWriteInlineObject CreateEllipsisTrimmingSign([In] IDWriteTextFormat textFormat);

		/// <summary>Returns an interface for performing text analysis.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTextAnalyzer**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created text analyzer object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextanalyzer HRESULT CreateTextAnalyzer(
		// IDWriteTextAnalyzer **textAnalyzer );
		new IDWriteTextAnalyzer CreateTextAnalyzer();

		/// <summary>
		/// Creates a number substitution object using a locale name, substitution method, and an indicator whether to ignore user overrides
		/// (use NLS defaults for the given culture instead).
		/// </summary>
		/// <param name="substitutionMethod">
		/// <para>Type: <c>DWRITE_NUMBER_SUBSTITUTION_METHOD</c></para>
		/// <para>A value that specifies how to apply number substitution on digits and related punctuation.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The name of the locale to be used in the numberSubstitution object.</para>
		/// </param>
		/// <param name="ignoreUserOverride">
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag that indicates whether to ignore user overrides.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteNumberSubstitution**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the number substitution object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createnumbersubstitution HRESULT
		// CreateNumberSubstitution( DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, WCHAR const *localeName, bool ignoreUserOverride,
		// IDWriteNumberSubstitution **numberSubstitution );
		new IDWriteNumberSubstitution CreateNumberSubstitution([In] DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, [MarshalAs(UnmanagedType.LPWStr)] string localeName, [In][MarshalAs(UnmanagedType.Bool)] bool ignoreUserOverride);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>A structure that contains the properties of the glyph run (font face, advances, and so on).</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI bitmap then pixelsPerDipis
		/// 1. If rendering onto a 120 DPI bitmap then pixelsPerDip is 1.25.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified the emSize
		/// and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>
		/// A value that specifies the rendering mode, which must be one of the raster rendering modes (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>Specifies the measuring mode to use with glyphs.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal position (X-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Vertical position (Y-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteGlyphRunAnalysis**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created glyph run analysis object.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The glyph run analysis object contains the results of analyzing the glyph run, including the positions of all the glyphs and
		/// references to all of the rasterized glyphs in the font cache.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to create a glyph run analysis object. In this example, an empty glyph run is being used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( DWRITE_GLYPH_RUN const *glyphRun, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, FLOAT baselineOriginX, FLOAT baselineOriginY,
		// IDWriteGlyphRunAnalysis **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, float pixelsPerDip, [In, Optional] IntPtr transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Gets a font collection representing the set of EUDC (end-user defined characters) fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>**</b></para>
		/// <para>The font collection to fill.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether to check for updates.</para>
		/// </param>
		/// <remarks>
		/// Note that if no EUDC is set on the system, the returned collection will be empty, meaning it will return success but
		/// GetFontFamilyCount will be zero.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-geteudcfontcollection HRESULT
		// GetEudcFontCollection( [out] IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetEudcFontCollection(out IDWriteFontCollection fontCollection, bool checkForUpdates = false);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrastGrayscale">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color components)
		/// that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams1</c>**</b></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT enhancedContrastGrayscale, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, [out] IDWriteRenderingParams1 **renderingParams );
		new IDWriteRenderingParams1 CreateCustomRenderingParams(float gamma, float enhancedContrast, float enhancedContrastGrayscale, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Creates a font fallback object from the system font fallback list.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallback</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-getsystemfontfallback HRESULT
		// GetSystemFontFallback( [out] IDWriteFontFallback **fontFallback );
		new IDWriteFontFallback GetSystemFontFallback();

		/// <summary>
		/// <para>Creates a font fallback builder object.</para>
		/// <para>
		/// A font fall back builder allows you to create Unicode font fallback mappings and create a font fall back object from those mappings.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallbackBuilder</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback builder object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createfontfallbackbuilder HRESULT
		// CreateFontFallbackBuilder( [out] IDWriteFontFallbackBuilder **fontFallbackBuilder );
		new IDWriteFontFallbackBuilder CreateFontFallbackBuilder();

		/// <summary>This method is called on a glyph run to translate it in to multiple color glyph runs.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Original glyph run containing monochrome glyph IDs.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN_DESCRIPTION</c>*</b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode used to compute glyph positions if the run contains color glyphs.</para>
		/// </param>
		/// <param name="worldToDeviceTransform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// World transform multiplied by any DPI scaling. This is needed to compute glyph positions if the run contains color glyphs and
		/// the measuring mode is not <c>DWRITE_MEASURING_MODE_NATURAL</c>. If this parameter is <b>NULL</b>, and identity transform is assumed.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator</c>**</b></para>
		/// <para>
		/// If the original glyph run contains color glyphs, this parameter receives a pointer to an <c>IDWriteColorGlyphRunEnumerator</c>
		/// interface. The client uses the returned interface to get information about glyph runs and associated colors to render instead of
		/// the original glyph run. If the original glyph run does not contain color glyphs, this method returns <b>DWRITE_E_NOCOLOR</b> and
		/// the output pointer is <b>NULL</b>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If the code calls this method with a glyph run that contains no color information, the method returns <b>DWRITE_E_NOCOLOR</b> to
		/// let the application know that it can just draw the original glyph run. If the glyph run contains color information, the function
		/// returns an object that can be enumerated through to expose runs and associated colors. The application then calls
		/// <c>DrawGlyphRun</c> with each of the returned glyph runs and foreground colors.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( FLOAT baselineOriginX, FLOAT baselineOriginY, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const
		// *worldToDeviceTransform, UINT32 colorPaletteIndex, [out] IDWriteColorGlyphRunEnumerator **colorLayers );
		new IDWriteColorGlyphRunEnumerator TranslateColorGlyphRun(float baselineOriginX, float baselineOriginY, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldToDeviceTransform, uint colorPaletteIndex);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>The geometry of a device pixel.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>
		/// Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// How to grid fit glyph outlines. In most cases, this should be DWRITE_GRID_FIT_DEFAULT to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams2</c>**</b></para>
		/// <para>Holds the newly created rendering parameters object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams2 **renderingParams );
		new IDWriteRenderingParams2 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Structure specifying the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// emSize and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b>DWRITE_RENDERING_MODE</b></para>
		/// <para>Specifies the rendering mode, which must be one of the raster rendering modes (i.e., not default and not outline).</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Specifies the method to measure glyphs.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>How to grid-fit glyph outlines. This must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>Specifies the antialias mode.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Horizontal position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Vertical position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>Receives a pointer to the newly created object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode, DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
			float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a glyph-run-analysis object that encapsulates info that <c>DirectWrite</c> uses to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>A <c>DWRITE_GLYPH_RUN</c> structure that contains the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the optional transform to be applied to glyphs and their positions.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the rendering mode, which must be one of the raster rendering modes
		/// (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the measuring method for glyphs in the run. This method uses this
		/// value with the other properties to determine the rendering mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. This value must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the type of antialiasing to use for text when the rendering mode
		/// calls for antialiasing.
		/// </para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteGlyphRunAnalysis</c> interface for the newly created
		/// glyph-run-analysis object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
			DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// A <c>DWRITE_PIXEL_GEOMETRY</c>-typed value that specifies the internal structure of a device pixel (that is, the physical
		/// arrangement of red, green, and blue color components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the method (for example, ClearType natural quality) for rendering
		/// glyphs. In most cases, specify <b>DWRITE_RENDERING_MODE1_DEFAULT</b> to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. In most cases, specify
		/// <b>DWRITE_GRID_FIT_DEFAULT</b> to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams3</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteRenderingParams3</c> interface for the newly created
		/// rendering parameters object, or <b>NULL</b> in case of failure.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams3 **renderingParams );
		new IDWriteRenderingParams3 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a reference to a font given a full path.</summary>
		/// <param name="filePath">
		/// <para>Type: [in] <b>WCHAR</b></para>
		/// <para>
		/// Absolute file path. Subsequent operations on the constructed object may fail if the user provided filePath doesn't correspond to
		/// a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: [in, optional] <b>FILETIME</b></para>
		/// <para>
		/// Last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time, so the clients are encouraged to specify this value to avoid extra disk access. Subsequent operations on the
		/// constructed object may fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(wcharconst_filetimeconst_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( WCHAR const *filePath, FILETIME const *lastWriteTime, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS
		// fontSimulations, IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference CreateFontFaceReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] PFILETIME? lastWriteTime, uint faceIndex,
			DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Creates a reference to a font given an <b>IDWriteFontFile</b>.</summary>
		/// <param name="fontFile">An <b>IDWriteFontFile</b> representing the font face.</param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(idwritefontfile_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( IDWriteFontFile *fontFile, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations, [out]
		// IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference CreateFontFaceReference([In] IDWriteFontFile fontFile, uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Retrieves the list of system fonts.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Holds the newly created font set object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontset HRESULT
		// GetSystemFontSet( [out] IDWriteFontSet **fontSet );
		new IDWriteFontSet GetSystemFontSet();

		/// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder</c>**</b></para>
		/// <para>Holds the newly created font set builder object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( [out] IDWriteFontSetBuilder **fontSetBuilder );
		new IDWriteFontSetBuilder CreateFontSetBuilder();

		/// <summary>Create a weight/width/slope tree from a set of fonts.</summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>A set of fonts to use to build the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontcollectionfromfontset HRESULT
		// CreateFontCollectionFromFontSet( IDWriteFontSet *fontSet, [out] IDWriteFontCollection1 **fontCollection );
		new IDWriteFontCollection1 CreateFontCollectionFromFontSet(IDWriteFontSet fontSet);

		/// <summary>Retrieves a weight/width/slope tree of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// <para>Type: <b>bool</b></para>
		/// <para>Indicates whether to include cloud fonts or only locally installed fonts.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// If this parameter is TRUE, the function performs an immediate check for changes to the set of system fonts. If this parameter is
		/// FALSE, the function will still detect changes if the font cache service is running, but there may be some latency. For example,
		/// an application might specify TRUE if it has just installed a font and wants to be sure the font collection contains that font.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontcollection HRESULT
		// GetSystemFontCollection( bool includeDownloadableFonts, IDWriteFontCollection1 **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(bool includeDownloadableFonts, out IDWriteFontCollection1 fontCollection, bool checkForUpdates = false);

		/// <summary>Gets the font download queue associated with this factory object.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontDownloadQueue</c>**</b></para>
		/// <para>Receives a pointer to the font download queue interface.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getfontdownloadqueue HRESULT
		// GetFontDownloadQueue( [out] IDWriteFontDownloadQueue **fontDownloadQueue );
		new IDWriteFontDownloadQueue GetFontDownloadQueue();

		/// <summary>
		/// Translates a glyph run to a sequence of color glyph runs, which can be rendered to produce a color representation of the
		/// original "base" run.
		/// </summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>Horizontal and vertical origin of the base glyph run in pre-transform coordinates.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Pointer to the original "base" glyph run.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN_DESCRIPTION</c></b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="desiredGlyphImageFormats">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Which data formats the runs should be split into.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode, needed to compute the origins of each glyph.</para>
		/// </param>
		/// <param name="worldAndDpiTransform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>
		/// Matrix converting from the client's coordinate space to device coordinates (pixels), i.e., the world transform multiplied by any
		/// DPI scaling.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <param name="colorLayers">
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator1</c>**</b></para>
		/// <para>
		/// If the function succeeds, receives a pointer to an enumerator object that can be used to obtain the color glyph runs. If the
		/// base run has no color glyphs, then the output pointer is NULL and the method returns DWRITE_E_NOCOLOR.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns DWRITE_E_NOCOLOR if the font has no color information, the glyph run does not contain any color glyphs, or the specified
		/// color palette index is out of range. In this case, the client should render the original glyph run. Otherwise, returns a
		/// standard HRESULT error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Calling <c>IDWriteFactory2::TranslateColorGlyphRun</c> is equivalent to calling <b>IDWriteFactory4::TranslateColorGlyph</b> run
		/// with the following formats specified: DWRITE_GLYPH_IMAGE_FORMATS_TRUETYPE|DWRITE_GLYPH_IMAGE_FORMATS_CFF|DWRITE_GLYPH_IMAGE_FORMATS_COLR.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( D2D1_POINT_2F baselineOrigin, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
		// DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const *worldAndDpiTransform, UINT32 colorPaletteIndex, [out]
		// IDWriteColorGlyphRunEnumerator1 **colorLayers );
		[PreserveSig]
		HRESULT TranslateColorGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
			DWRITE_MEASURING_MODE measuringMode, [In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform, uint colorPaletteIndex,
			out IDWriteColorGlyphRunEnumerator1 colorLayers);

		/// <summary>Converts glyph run placements to glyph origins.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="glyphOrigins">
		/// <para>Type: [out] <b><c>D2D1_POINT_2F</c>*</b></para>
		/// <para>On return contains the glyph origins for the glyphrun.</para>
		/// </param>
		/// <remarks>
		/// The transform and DPI have no effect on the origin scaling. They are solely used to compute glyph advances when not supplied and
		/// align glyphs in pixel aligned measuring modes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-computeglyphorigins(dwrite_glyph_runconst_d2d1_point_2f_d2d1_point_2f)
		// HRESULT ComputeGlyphOrigins( DWRITE_GLYPH_RUN const *glyphRun, D2D1_POINT_2F baselineOrigin, D2D1_POINT_2F *glyphOrigins );
		void ComputeGlyphOrigins(in DWRITE_GLYPH_RUN glyphRun, D2D_POINT_2F baselineOrigin,
			[Out, MarshalAs(UnmanagedType.LPArray)] D2D_POINT_2F[] glyphOrigins);

		/// <summary>Converts glyph run placements to glyph origins.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="measuringMode"/>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="worldAndDpiTransform"/>
		/// <param name="glyphOrigins">
		/// <para>Type: [out] <b><c>D2D1_POINT_2F</c>*</b></para>
		/// <para>On return contains the glyph origins for the glyphrun.</para>
		/// </param>
		/// <remarks>
		/// The transform and DPI have no effect on the origin scaling. They are solely used to compute glyph advances when not supplied and
		/// align glyphs in pixel aligned measuring modes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-computeglyphorigins(dwrite_glyph_runconst_dwrite_measuring_mode_d2d1_point_2f_dwrite_matrixconst_d2d1_point_2f)
		// HRESULT ComputeGlyphOrigins( DWRITE_GLYPH_RUN const *glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D1_POINT_2F baselineOrigin,
		// DWRITE_MATRIX const *worldAndDpiTransform, D2D1_POINT_2F *glyphOrigins );
		void ComputeGlyphOrigins(in DWRITE_GLYPH_RUN glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D_POINT_2F baselineOrigin,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform, [Out, MarshalAs(UnmanagedType.LPArray)] D2D_POINT_2F[] glyphOrigins);
	}

	/// <summary>The root factory interface for all DirectWrite objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefactory5
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFactory5")]
	[ComImport, Guid("958DB99A-BE2A-4F09-AF7D-65189803D1D3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFactory5 : IDWriteFactory, IDWriteFactory1, IDWriteFactory2, IDWriteFactory3, IDWriteFactory4
	{
		/// <summary>Gets an object which represents the set of installed fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the system font collection object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If this parameter is nonzero, the function performs an immediate check for changes to the set of installed fonts. If this
		/// parameter is <c>FALSE</c>, the function will still detect changes if the font cache service is running, but there may be some
		/// latency. For example, an application might specify <c>TRUE</c> if it has itself just installed a font and wants to be sure the
		/// font collection contains that font.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getsystemfontcollection HRESULT
		// GetSystemFontCollection( IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(out IDWriteFontCollection fontCollection, [MarshalAs(UnmanagedType.Bool)] bool checkForUpdates = false);

		/// <summary>Creates a font collection using a custom font collection loader.</summary>
		/// <param name="collectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>An application-defined font collection loader, which must have been previously registered using RegisterFontCollectionLoader.</para>
		/// </param>
		/// <param name="collectionKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// The key used by the loader to identify a collection of font files. The buffer allocated for this key should at least be the size
		/// of collectionKeySize.
		/// </para>
		/// </param>
		/// <param name="collectionKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size, in bytes, of the collection key.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// Contains an address of a pointer to the system font collection object if the method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontcollection HRESULT
		// CreateCustomFontCollection( IDWriteFontCollectionLoader *collectionLoader, void const *collectionKey, UINT32 collectionKeySize,
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection CreateCustomFontCollection([In] IDWriteFontCollectionLoader collectionLoader, [In] IntPtr collectionKey, uint collectionKeySize);

		/// <summary>Registers a custom font collection loader with the factory object.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be registered.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font collection loader with DirectWrite. The font collection loader interface, which should be
		/// implemented by a singleton object, handles enumerating font files in a font collection given a particular type of key. A given
		/// instance can only be registered once. Succeeding attempts will return an error, indicating that it has already been registered.
		/// Note that font file loader implementations must not register themselves with DirectWrite inside their constructors, and must not
		/// unregister themselves inside their destructors, because registration and unregistraton operations increment and decrement the
		/// object reference count respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be
		/// performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontcollectionloader HRESULT
		// RegisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void RegisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Unregisters a custom font collection loader that was previously registered using RegisterFontCollectionLoader.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be unregistered.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontcollectionloader HRESULT
		// UnregisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void UnregisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Creates a font file reference object from a local font file.</summary>
		/// <param name="filePath">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the absolute file path for the font file. Subsequent operations on the constructed object
		/// may fail if the user provided filePath doesn't correspond to a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>
		/// The last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time. You should specify this value to avoid extra disk access. Subsequent operations on the constructed object may
		/// fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font file reference object, or <c>NULL</c> in
		/// case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontfilereference HRESULT
		// CreateFontFileReference( WCHAR const *filePath, FILETIME const *lastWriteTime, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateFontFileReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] IntPtr lastWriteTime);

		/// <summary>Creates a reference to an application-specific font file resource.</summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A font file reference key that uniquely identifies the font file resource during the lifetime of fontFileLoader.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the font file reference key in bytes.</para>
		/// </param>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>The font file loader that will be used by the font system to load data from the file identified by fontFileReferenceKey.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// Contains an address of a pointer to the newly created font file object when this method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function is provided for cases when an application or a document needs to use a private font without having to install it
		/// on the system. fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontfilereference HRESULT
		// CreateCustomFontFileReference( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, IDWriteFontFileLoader
		// *fontFileLoader, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateCustomFontFileReference([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, [In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates an object that represents a font face.</summary>
		/// <param name="fontFaceType">
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of file format of the font face.</para>
		/// </param>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font files, in element count, required to represent the font face.</para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>const IDWriteFontFile*</c></para>
		/// <para>
		/// A font file object representing the font face. Because IDWriteFontFacemaintains its own references to the input font file
		/// objects, you may release them after this call.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face, in cases when the font files contain a collection of font faces. If the font files contain
		/// a single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontFaceSimulationFlags">
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>
		/// A value that indicates which, if any, font face simulation flags for algorithmic means of making text bold or italic are applied
		/// to the current font face.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font face object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontface HRESULT CreateFontFace(
		// DWRITE_FONT_FACE_TYPE fontFaceType, UINT32 numberOfFiles, IDWriteFontFile * const *fontFiles, UINT32 faceIndex,
		// DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags, IDWriteFontFace **fontFace );
		new IDWriteFontFace CreateFontFace(DWRITE_FONT_FACE_TYPE fontFaceType, uint numberOfFiles,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[] fontFiles,
			uint faceIndex, DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags);

		/// <summary>
		/// Creates a rendering parameters object with default settings for the primary monitor. Different monitors may have different
		/// rendering parameters, for more information see the How to Add Support for Multiple Monitors topic.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createrenderingparams HRESULT
		// CreateRenderingParams( IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateRenderingParams();

		/// <summary>
		/// Creates a rendering parameters object with default settings for the specified monitor. In most cases, this is the preferred way
		/// to create a rendering parameters object.
		/// </summary>
		/// <param name="monitor">
		/// <para>Type: <c>HMONITOR</c></para>
		/// <para>A handle for the specified monitor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the rendering parameters object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createmonitorrenderingparams HRESULT
		// CreateMonitorRenderingParams( HMONITOR monitor, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateMonitorRenderingParams(HMONITOR monitor);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color
		/// components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry,
		// DWRITE_RENDERING_MODE renderingMode, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Registers a font file loader with DirectWrite.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to a IDWriteFontFileLoader object for a particular file resource type.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font file loader with DirectWrite. The font file loader interface, which should be implemented by a
		/// singleton object, handles loading font file resources of a particular type from a key. A given instance can only be registered
		/// once. Succeeding attempts will return an error, indicating that it has already been registered. Note that font file loader
		/// implementations must not register themselves with DirectWrite inside their constructors, and must not unregister themselves
		/// inside their destructors, because registration and unregistraton operations increment and decrement the object reference count
		/// respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be performed outside of the
		/// font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontfileloader HRESULT
		// RegisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void RegisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Unregisters a font file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to the file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</para>
		/// </param>
		/// <remarks>
		/// This function unregisters font file loader callbacks with the DirectWrite font system. You should implement the font file loader
		/// interface by a singleton object. Note that font file loader implementations must not register themselves with DirectWrite inside
		/// their constructors and must not unregister themselves in their destructors, because registration and unregistraton operations
		/// increment and decrement the object reference count respectively. Instead, registration and unregistration of font file loaders
		/// with DirectWrite should be performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontfileloader HRESULT
		// UnregisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void UnregisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates a text format object used for text layout.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the name of the font family</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>A pointer to a font collection object. When this is <c>NULL</c>, indicates the system font collection.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the font weight for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that indicates the font style for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that indicates the font stretch for the text object created by this method.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP ("device-independent pixel") units. A DIP equals 1/96 inch.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the locale name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextFormat**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a newly created text format object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextformat HRESULT CreateTextFormat(
		// WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STYLE fontStyle,
		// DWRITE_FONT_STRETCH fontStretch, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat **textFormat );
		new IDWriteTextFormat CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection, DWRITE_FONT_WEIGHT fontWeight,
			DWRITE_FONT_STYLE fontStyle, DWRITE_FONT_STRETCH fontStretch, float fontSize, [MarshalAs(UnmanagedType.LPWStr)] string localeName);

		/// <summary>Creates a typography object for use in a text layout.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a newly created typography object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtypography HRESULT CreateTypography(
		// IDWriteTypography **typography );
		new IDWriteTypography CreateTypography();

		/// <summary>Creates an object that is used for interoperability with GDI.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteGdiInterop**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a GDI interop object if successful, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getgdiinterop HRESULT GetGdiInterop(
		// IDWriteGdiInterop **gdiInterop );
		new IDWriteGdiInterop GetGdiInterop();

		/// <summary>
		/// Takes a string, text format, and associated constraints, and produces an object that represents the fully analyzed and formatted result.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of characters in the string.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A pointer to an object that indicates the format to apply to the string.</para>
		/// </param>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the resultant text layout object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextlayout HRESULT CreateTextLayout(
		// WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT maxWidth, FLOAT maxHeight, IDWriteTextLayout
		// **textLayout );
		new IDWriteTextLayout CreateTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, float maxWidth, float maxHeight);

		/// <summary>
		/// Takes a string, format, and associated constraints, and produces an object representing the result, formatted for a particular
		/// display resolution and measuring mode.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length of the string, in character count.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>The text formatting object to apply to the string.</para>
		/// </param>
		/// <param name="layoutWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="layoutHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI device pixelsPerDipis
		/// 1. If rendering onto a 120 DPI device pixelsPerDip is 1.25 (120/96).
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specifies the font
		/// size and pixels per DIP.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Instructs the text layout to use the same metrics as GDI bi-level text when set to <c>FALSE</c>. When set to <c>TRUE</c>,
		/// instructs the text layout to use the same metrics as text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address to the pointer of the resultant text layout object.</para>
		/// </returns>
		/// <remarks>
		/// The resulting text layout should only be used for the intended resolution, and for cases where text scalability is desired
		/// CreateTextLayout should be used instead.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-creategdicompatibletextlayout HRESULT
		// CreateGdiCompatibleTextLayout( WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT layoutWidth, FLOAT
		// layoutHeight, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, IDWriteTextLayout **textLayout );
		new IDWriteTextLayout CreateGdiCompatibleTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat,
			float layoutWidth, float layoutHeight, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural);

		/// <summary>Creates an inline object for trimming, using an ellipsis as the omission sign.</summary>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A text format object, created with CreateTextFormat, used for text layout.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the omission (that is, ellipsis trimming) sign created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The ellipsis will be created using the current settings of the format, including base font, style, and any effects. Alternate
		/// omission signs can be created by the application by implementing IDWriteInlineObject.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createellipsistrimmingsign HRESULT
		// CreateEllipsisTrimmingSign( IDWriteTextFormat *textFormat, IDWriteInlineObject **trimmingSign );
		new IDWriteInlineObject CreateEllipsisTrimmingSign([In] IDWriteTextFormat textFormat);

		/// <summary>Returns an interface for performing text analysis.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTextAnalyzer**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created text analyzer object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextanalyzer HRESULT CreateTextAnalyzer(
		// IDWriteTextAnalyzer **textAnalyzer );
		new IDWriteTextAnalyzer CreateTextAnalyzer();

		/// <summary>
		/// Creates a number substitution object using a locale name, substitution method, and an indicator whether to ignore user overrides
		/// (use NLS defaults for the given culture instead).
		/// </summary>
		/// <param name="substitutionMethod">
		/// <para>Type: <c>DWRITE_NUMBER_SUBSTITUTION_METHOD</c></para>
		/// <para>A value that specifies how to apply number substitution on digits and related punctuation.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The name of the locale to be used in the numberSubstitution object.</para>
		/// </param>
		/// <param name="ignoreUserOverride">
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag that indicates whether to ignore user overrides.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteNumberSubstitution**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the number substitution object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createnumbersubstitution HRESULT
		// CreateNumberSubstitution( DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, WCHAR const *localeName, bool ignoreUserOverride,
		// IDWriteNumberSubstitution **numberSubstitution );
		new IDWriteNumberSubstitution CreateNumberSubstitution([In] DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, [MarshalAs(UnmanagedType.LPWStr)] string localeName, [In][MarshalAs(UnmanagedType.Bool)] bool ignoreUserOverride);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>A structure that contains the properties of the glyph run (font face, advances, and so on).</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI bitmap then pixelsPerDipis
		/// 1. If rendering onto a 120 DPI bitmap then pixelsPerDip is 1.25.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified the emSize
		/// and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>
		/// A value that specifies the rendering mode, which must be one of the raster rendering modes (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>Specifies the measuring mode to use with glyphs.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal position (X-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Vertical position (Y-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteGlyphRunAnalysis**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created glyph run analysis object.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The glyph run analysis object contains the results of analyzing the glyph run, including the positions of all the glyphs and
		/// references to all of the rasterized glyphs in the font cache.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to create a glyph run analysis object. In this example, an empty glyph run is being used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( DWRITE_GLYPH_RUN const *glyphRun, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, FLOAT baselineOriginX, FLOAT baselineOriginY,
		// IDWriteGlyphRunAnalysis **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, float pixelsPerDip, [In, Optional] IntPtr transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Gets a font collection representing the set of EUDC (end-user defined characters) fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>**</b></para>
		/// <para>The font collection to fill.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether to check for updates.</para>
		/// </param>
		/// <remarks>
		/// Note that if no EUDC is set on the system, the returned collection will be empty, meaning it will return success but
		/// GetFontFamilyCount will be zero.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-geteudcfontcollection HRESULT
		// GetEudcFontCollection( [out] IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetEudcFontCollection(out IDWriteFontCollection fontCollection, bool checkForUpdates = false);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrastGrayscale">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color components)
		/// that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams1</c>**</b></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT enhancedContrastGrayscale, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, [out] IDWriteRenderingParams1 **renderingParams );
		new IDWriteRenderingParams1 CreateCustomRenderingParams(float gamma, float enhancedContrast, float enhancedContrastGrayscale, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Creates a font fallback object from the system font fallback list.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallback</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-getsystemfontfallback HRESULT
		// GetSystemFontFallback( [out] IDWriteFontFallback **fontFallback );
		new IDWriteFontFallback GetSystemFontFallback();

		/// <summary>
		/// <para>Creates a font fallback builder object.</para>
		/// <para>
		/// A font fall back builder allows you to create Unicode font fallback mappings and create a font fall back object from those mappings.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallbackBuilder</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback builder object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createfontfallbackbuilder HRESULT
		// CreateFontFallbackBuilder( [out] IDWriteFontFallbackBuilder **fontFallbackBuilder );
		new IDWriteFontFallbackBuilder CreateFontFallbackBuilder();

		/// <summary>This method is called on a glyph run to translate it in to multiple color glyph runs.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Original glyph run containing monochrome glyph IDs.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN_DESCRIPTION</c>*</b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode used to compute glyph positions if the run contains color glyphs.</para>
		/// </param>
		/// <param name="worldToDeviceTransform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// World transform multiplied by any DPI scaling. This is needed to compute glyph positions if the run contains color glyphs and
		/// the measuring mode is not <c>DWRITE_MEASURING_MODE_NATURAL</c>. If this parameter is <b>NULL</b>, and identity transform is assumed.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator</c>**</b></para>
		/// <para>
		/// If the original glyph run contains color glyphs, this parameter receives a pointer to an <c>IDWriteColorGlyphRunEnumerator</c>
		/// interface. The client uses the returned interface to get information about glyph runs and associated colors to render instead of
		/// the original glyph run. If the original glyph run does not contain color glyphs, this method returns <b>DWRITE_E_NOCOLOR</b> and
		/// the output pointer is <b>NULL</b>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If the code calls this method with a glyph run that contains no color information, the method returns <b>DWRITE_E_NOCOLOR</b> to
		/// let the application know that it can just draw the original glyph run. If the glyph run contains color information, the function
		/// returns an object that can be enumerated through to expose runs and associated colors. The application then calls
		/// <c>DrawGlyphRun</c> with each of the returned glyph runs and foreground colors.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( FLOAT baselineOriginX, FLOAT baselineOriginY, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const
		// *worldToDeviceTransform, UINT32 colorPaletteIndex, [out] IDWriteColorGlyphRunEnumerator **colorLayers );
		new IDWriteColorGlyphRunEnumerator TranslateColorGlyphRun(float baselineOriginX, float baselineOriginY, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldToDeviceTransform, uint colorPaletteIndex);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>The geometry of a device pixel.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>
		/// Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// How to grid fit glyph outlines. In most cases, this should be DWRITE_GRID_FIT_DEFAULT to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams2</c>**</b></para>
		/// <para>Holds the newly created rendering parameters object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams2 **renderingParams );
		new IDWriteRenderingParams2 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Structure specifying the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// emSize and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b>DWRITE_RENDERING_MODE</b></para>
		/// <para>Specifies the rendering mode, which must be one of the raster rendering modes (i.e., not default and not outline).</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Specifies the method to measure glyphs.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>How to grid-fit glyph outlines. This must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>Specifies the antialias mode.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Horizontal position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Vertical position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>Receives a pointer to the newly created object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode, DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
			float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a glyph-run-analysis object that encapsulates info that <c>DirectWrite</c> uses to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>A <c>DWRITE_GLYPH_RUN</c> structure that contains the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the optional transform to be applied to glyphs and their positions.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the rendering mode, which must be one of the raster rendering modes
		/// (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the measuring method for glyphs in the run. This method uses this
		/// value with the other properties to determine the rendering mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. This value must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the type of antialiasing to use for text when the rendering mode
		/// calls for antialiasing.
		/// </para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteGlyphRunAnalysis</c> interface for the newly created
		/// glyph-run-analysis object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
			DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// A <c>DWRITE_PIXEL_GEOMETRY</c>-typed value that specifies the internal structure of a device pixel (that is, the physical
		/// arrangement of red, green, and blue color components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the method (for example, ClearType natural quality) for rendering
		/// glyphs. In most cases, specify <b>DWRITE_RENDERING_MODE1_DEFAULT</b> to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. In most cases, specify
		/// <b>DWRITE_GRID_FIT_DEFAULT</b> to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams3</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteRenderingParams3</c> interface for the newly created
		/// rendering parameters object, or <b>NULL</b> in case of failure.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams3 **renderingParams );
		new IDWriteRenderingParams3 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a reference to a font given a full path.</summary>
		/// <param name="filePath">
		/// <para>Type: [in] <b>WCHAR</b></para>
		/// <para>
		/// Absolute file path. Subsequent operations on the constructed object may fail if the user provided filePath doesn't correspond to
		/// a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: [in, optional] <b>FILETIME</b></para>
		/// <para>
		/// Last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time, so the clients are encouraged to specify this value to avoid extra disk access. Subsequent operations on the
		/// constructed object may fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(wcharconst_filetimeconst_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( WCHAR const *filePath, FILETIME const *lastWriteTime, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS
		// fontSimulations, IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference CreateFontFaceReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] PFILETIME? lastWriteTime, uint faceIndex,
			DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Creates a reference to a font given an <b>IDWriteFontFile</b>.</summary>
		/// <param name="fontFile">An <b>IDWriteFontFile</b> representing the font face.</param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(idwritefontfile_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( IDWriteFontFile *fontFile, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations, [out]
		// IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference CreateFontFaceReference([In] IDWriteFontFile fontFile, uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Retrieves the list of system fonts.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Holds the newly created font set object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontset HRESULT
		// GetSystemFontSet( [out] IDWriteFontSet **fontSet );
		new IDWriteFontSet GetSystemFontSet();

		/// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder</c>**</b></para>
		/// <para>Holds the newly created font set builder object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( [out] IDWriteFontSetBuilder **fontSetBuilder );
		new IDWriteFontSetBuilder CreateFontSetBuilder();

		/// <summary>Create a weight/width/slope tree from a set of fonts.</summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>A set of fonts to use to build the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontcollectionfromfontset HRESULT
		// CreateFontCollectionFromFontSet( IDWriteFontSet *fontSet, [out] IDWriteFontCollection1 **fontCollection );
		new IDWriteFontCollection1 CreateFontCollectionFromFontSet(IDWriteFontSet fontSet);

		/// <summary>Retrieves a weight/width/slope tree of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// <para>Type: <b>bool</b></para>
		/// <para>Indicates whether to include cloud fonts or only locally installed fonts.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// If this parameter is TRUE, the function performs an immediate check for changes to the set of system fonts. If this parameter is
		/// FALSE, the function will still detect changes if the font cache service is running, but there may be some latency. For example,
		/// an application might specify TRUE if it has just installed a font and wants to be sure the font collection contains that font.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontcollection HRESULT
		// GetSystemFontCollection( bool includeDownloadableFonts, IDWriteFontCollection1 **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(bool includeDownloadableFonts, out IDWriteFontCollection1 fontCollection, bool checkForUpdates = false);

		/// <summary>Gets the font download queue associated with this factory object.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontDownloadQueue</c>**</b></para>
		/// <para>Receives a pointer to the font download queue interface.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getfontdownloadqueue HRESULT
		// GetFontDownloadQueue( [out] IDWriteFontDownloadQueue **fontDownloadQueue );
		new IDWriteFontDownloadQueue GetFontDownloadQueue();

		/// <summary>
		/// Translates a glyph run to a sequence of color glyph runs, which can be rendered to produce a color representation of the
		/// original "base" run.
		/// </summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>Horizontal and vertical origin of the base glyph run in pre-transform coordinates.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Pointer to the original "base" glyph run.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN_DESCRIPTION</c></b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="desiredGlyphImageFormats">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Which data formats the runs should be split into.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode, needed to compute the origins of each glyph.</para>
		/// </param>
		/// <param name="worldAndDpiTransform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>
		/// Matrix converting from the client's coordinate space to device coordinates (pixels), i.e., the world transform multiplied by any
		/// DPI scaling.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <param name="colorLayers">
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator1</c>**</b></para>
		/// <para>
		/// If the function succeeds, receives a pointer to an enumerator object that can be used to obtain the color glyph runs. If the
		/// base run has no color glyphs, then the output pointer is NULL and the method returns DWRITE_E_NOCOLOR.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns DWRITE_E_NOCOLOR if the font has no color information, the glyph run does not contain any color glyphs, or the specified
		/// color palette index is out of range. In this case, the client should render the original glyph run. Otherwise, returns a
		/// standard HRESULT error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Calling <c>IDWriteFactory2::TranslateColorGlyphRun</c> is equivalent to calling <b>IDWriteFactory4::TranslateColorGlyph</b> run
		/// with the following formats specified: DWRITE_GLYPH_IMAGE_FORMATS_TRUETYPE|DWRITE_GLYPH_IMAGE_FORMATS_CFF|DWRITE_GLYPH_IMAGE_FORMATS_COLR.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( D2D1_POINT_2F baselineOrigin, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
		// DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const *worldAndDpiTransform, UINT32 colorPaletteIndex, [out]
		// IDWriteColorGlyphRunEnumerator1 **colorLayers );
		[PreserveSig]
		new HRESULT TranslateColorGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
			DWRITE_MEASURING_MODE measuringMode, [In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform, uint colorPaletteIndex,
			out IDWriteColorGlyphRunEnumerator1 colorLayers);

		/// <summary>Converts glyph run placements to glyph origins.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="glyphOrigins">
		/// <para>Type: [out] <b><c>D2D1_POINT_2F</c>*</b></para>
		/// <para>On return contains the glyph origins for the glyphrun.</para>
		/// </param>
		/// <remarks>
		/// The transform and DPI have no effect on the origin scaling. They are solely used to compute glyph advances when not supplied and
		/// align glyphs in pixel aligned measuring modes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-computeglyphorigins(dwrite_glyph_runconst_d2d1_point_2f_d2d1_point_2f)
		// HRESULT ComputeGlyphOrigins( DWRITE_GLYPH_RUN const *glyphRun, D2D1_POINT_2F baselineOrigin, D2D1_POINT_2F *glyphOrigins );
		new void ComputeGlyphOrigins(in DWRITE_GLYPH_RUN glyphRun, D2D_POINT_2F baselineOrigin,
			[Out, MarshalAs(UnmanagedType.LPArray)] D2D_POINT_2F[] glyphOrigins);

		/// <summary>Converts glyph run placements to glyph origins.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="measuringMode"/>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="worldAndDpiTransform"/>
		/// <param name="glyphOrigins">
		/// <para>Type: [out] <b><c>D2D1_POINT_2F</c>*</b></para>
		/// <para>On return contains the glyph origins for the glyphrun.</para>
		/// </param>
		/// <remarks>
		/// The transform and DPI have no effect on the origin scaling. They are solely used to compute glyph advances when not supplied and
		/// align glyphs in pixel aligned measuring modes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-computeglyphorigins(dwrite_glyph_runconst_dwrite_measuring_mode_d2d1_point_2f_dwrite_matrixconst_d2d1_point_2f)
		// HRESULT ComputeGlyphOrigins( DWRITE_GLYPH_RUN const *glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D1_POINT_2F baselineOrigin,
		// DWRITE_MATRIX const *worldAndDpiTransform, D2D1_POINT_2F *glyphOrigins );
		new void ComputeGlyphOrigins(in DWRITE_GLYPH_RUN glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D_POINT_2F baselineOrigin,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform, [Out, MarshalAs(UnmanagedType.LPArray)] D2D_POINT_2F[] glyphOrigins);

		/// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder1</c>**</b></para>
		/// <para>Holds the newly created font set builder object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( [out] IDWriteFontSetBuilder1 **fontSetBuilder );
		IDWriteFontSetBuilder1 CreateFontSetBuilder1();

		/// <summary>
		/// Creates a loader object that can be used to create font file references to in-memory fonts. The caller is responsible for
		/// registering and unregistering the loader.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteInMemoryFontFileLoader</c>**</b></para>
		/// <para>Receives a pointer to the newly-created loader object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createinmemoryfontfileloader HRESULT
		// CreateInMemoryFontFileLoader( [out] IDWriteInMemoryFontFileLoader **newLoader );
		IDWriteInMemoryFontFileLoader CreateInMemoryFontFileLoader();

		/// <summary>
		/// Creates a remote font file loader that can create font file references from HTTP or HTTPS URLs. The caller is responsible for
		/// registering and unregistering the loader.
		/// </summary>
		/// <param name="referrerUrl">
		/// <para>Type: <b>wchar_t const*</b></para>
		/// <para>Optional referrer URL for HTTP requests.</para>
		/// </param>
		/// <param name="extraHeaders">
		/// <para>Type: <b>wchar_t const*</b></para>
		/// <para>
		/// Optional additional header fields to include in HTTP requests. Each header field consists of a name followed by a colon (":")
		/// and the field value, as specified by RFC 2616. Multiple header fields may be separated by newlines.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRemoteFontFileLoader</c>**</b></para>
		/// <para>Receives a pointer to the newly-created loader object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createhttpfontfileloader HRESULT
		// CreateHttpFontFileLoader( wchar_t const *referrerUrl, wchar_t const *extraHeaders, [out] IDWriteRemoteFontFileLoader **newLoader );
		IDWriteRemoteFontFileLoader CreateHttpFontFileLoader([Optional, MarshalAs(UnmanagedType.LPWStr)] string? referrerUrl, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? extraHeaders);

		/// <summary>
		/// The AnalyzeContainerType method analyzes the specified file data to determine whether it is a known font container format (e.g.,
		/// WOFF or WOFF2).
		/// </summary>
		/// <param name="fileData">
		/// <para>Type: <b>void</b></para>
		/// <para>Pointer to the file data to analyze.</para>
		/// </param>
		/// <param name="fileDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the buffer passed in fileData.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_CONTAINER_TYPE</c></b></para>
		/// <para>
		/// Returns the container type if recognized. DWRITE_CONTAINER_TYPE_UNKOWNN is returned for all other files, including uncompressed
		/// font files.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-analyzecontainertype
		// DWRITE_CONTAINER_TYPE AnalyzeContainerType( [in] void const *fileData, UINT32 fileDataSize );
		[PreserveSig]
		DWRITE_CONTAINER_TYPE AnalyzeContainerType([In] IntPtr fileData, uint fileDataSize);

		/// <summary>
		/// The UnpackFontFile method unpacks font data from a container file (WOFF or WOFF2) and returns the unpacked font data in the form
		/// of a font file stream.
		/// </summary>
		/// <param name="containerType">
		/// <para>Type: <b><c>DWRITE_CONTAINER_TYPE</c></b></para>
		/// <para>Container type returned by AnalyzeContainerType.</para>
		/// </param>
		/// <param name="fileData">
		/// <para>Type: <b>void</b></para>
		/// <para>Pointer to the compressed data.</para>
		/// </param>
		/// <param name="fileDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the compressed data, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFileStream</c>**</b></para>
		/// <para>Receives a pointer to a newly created font file stream containing the uncompressed data.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-unpackfontfile HRESULT UnpackFontFile(
		// DWRITE_CONTAINER_TYPE containerType, [in] void const *fileData, UINT32 fileDataSize, [out] IDWriteFontFileStream
		// **unpackedFontStream );
		IDWriteFontFileStream UnpackFontFile(DWRITE_CONTAINER_TYPE containerType, [In] IntPtr fileData, uint fileDataSize);
	}

	/// <summary>
	/// <para>
	/// This interface represents a factory object from which all DirectWrite objects are created. <b>IDWriteFactory6</b> adds new
	/// facilities for working with fonts and font resources.
	/// </para>
	/// <para>This interface extends <c>IDWriteFactory5</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefactory6
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFactory6")]
	[ComImport, Guid("F3744D80-21F7-42EB-B35D-995BC72FC223"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFactory6 : IDWriteFactory, IDWriteFactory1, IDWriteFactory2, IDWriteFactory3, IDWriteFactory4, IDWriteFactory5
	{
		/// <summary>Gets an object which represents the set of installed fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the system font collection object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If this parameter is nonzero, the function performs an immediate check for changes to the set of installed fonts. If this
		/// parameter is <c>FALSE</c>, the function will still detect changes if the font cache service is running, but there may be some
		/// latency. For example, an application might specify <c>TRUE</c> if it has itself just installed a font and wants to be sure the
		/// font collection contains that font.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getsystemfontcollection HRESULT
		// GetSystemFontCollection( IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(out IDWriteFontCollection fontCollection, [MarshalAs(UnmanagedType.Bool)] bool checkForUpdates = false);

		/// <summary>Creates a font collection using a custom font collection loader.</summary>
		/// <param name="collectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>An application-defined font collection loader, which must have been previously registered using RegisterFontCollectionLoader.</para>
		/// </param>
		/// <param name="collectionKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// The key used by the loader to identify a collection of font files. The buffer allocated for this key should at least be the size
		/// of collectionKeySize.
		/// </para>
		/// </param>
		/// <param name="collectionKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size, in bytes, of the collection key.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// Contains an address of a pointer to the system font collection object if the method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontcollection HRESULT
		// CreateCustomFontCollection( IDWriteFontCollectionLoader *collectionLoader, void const *collectionKey, UINT32 collectionKeySize,
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection CreateCustomFontCollection([In] IDWriteFontCollectionLoader collectionLoader, [In] IntPtr collectionKey, uint collectionKeySize);

		/// <summary>Registers a custom font collection loader with the factory object.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be registered.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font collection loader with DirectWrite. The font collection loader interface, which should be
		/// implemented by a singleton object, handles enumerating font files in a font collection given a particular type of key. A given
		/// instance can only be registered once. Succeeding attempts will return an error, indicating that it has already been registered.
		/// Note that font file loader implementations must not register themselves with DirectWrite inside their constructors, and must not
		/// unregister themselves inside their destructors, because registration and unregistraton operations increment and decrement the
		/// object reference count respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be
		/// performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontcollectionloader HRESULT
		// RegisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void RegisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Unregisters a custom font collection loader that was previously registered using RegisterFontCollectionLoader.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be unregistered.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontcollectionloader HRESULT
		// UnregisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void UnregisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Creates a font file reference object from a local font file.</summary>
		/// <param name="filePath">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the absolute file path for the font file. Subsequent operations on the constructed object
		/// may fail if the user provided filePath doesn't correspond to a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>
		/// The last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time. You should specify this value to avoid extra disk access. Subsequent operations on the constructed object may
		/// fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font file reference object, or <c>NULL</c> in
		/// case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontfilereference HRESULT
		// CreateFontFileReference( WCHAR const *filePath, FILETIME const *lastWriteTime, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateFontFileReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] IntPtr lastWriteTime);

		/// <summary>Creates a reference to an application-specific font file resource.</summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A font file reference key that uniquely identifies the font file resource during the lifetime of fontFileLoader.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the font file reference key in bytes.</para>
		/// </param>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>The font file loader that will be used by the font system to load data from the file identified by fontFileReferenceKey.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// Contains an address of a pointer to the newly created font file object when this method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function is provided for cases when an application or a document needs to use a private font without having to install it
		/// on the system. fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontfilereference HRESULT
		// CreateCustomFontFileReference( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, IDWriteFontFileLoader
		// *fontFileLoader, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateCustomFontFileReference([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, [In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates an object that represents a font face.</summary>
		/// <param name="fontFaceType">
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of file format of the font face.</para>
		/// </param>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font files, in element count, required to represent the font face.</para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>const IDWriteFontFile*</c></para>
		/// <para>
		/// A font file object representing the font face. Because IDWriteFontFacemaintains its own references to the input font file
		/// objects, you may release them after this call.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face, in cases when the font files contain a collection of font faces. If the font files contain
		/// a single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontFaceSimulationFlags">
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>
		/// A value that indicates which, if any, font face simulation flags for algorithmic means of making text bold or italic are applied
		/// to the current font face.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font face object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontface HRESULT CreateFontFace(
		// DWRITE_FONT_FACE_TYPE fontFaceType, UINT32 numberOfFiles, IDWriteFontFile * const *fontFiles, UINT32 faceIndex,
		// DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags, IDWriteFontFace **fontFace );
		new IDWriteFontFace CreateFontFace(DWRITE_FONT_FACE_TYPE fontFaceType, uint numberOfFiles,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[] fontFiles,
			uint faceIndex, DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags);

		/// <summary>
		/// Creates a rendering parameters object with default settings for the primary monitor. Different monitors may have different
		/// rendering parameters, for more information see the How to Add Support for Multiple Monitors topic.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createrenderingparams HRESULT
		// CreateRenderingParams( IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateRenderingParams();

		/// <summary>
		/// Creates a rendering parameters object with default settings for the specified monitor. In most cases, this is the preferred way
		/// to create a rendering parameters object.
		/// </summary>
		/// <param name="monitor">
		/// <para>Type: <c>HMONITOR</c></para>
		/// <para>A handle for the specified monitor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the rendering parameters object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createmonitorrenderingparams HRESULT
		// CreateMonitorRenderingParams( HMONITOR monitor, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateMonitorRenderingParams(HMONITOR monitor);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color
		/// components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry,
		// DWRITE_RENDERING_MODE renderingMode, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Registers a font file loader with DirectWrite.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to a IDWriteFontFileLoader object for a particular file resource type.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font file loader with DirectWrite. The font file loader interface, which should be implemented by a
		/// singleton object, handles loading font file resources of a particular type from a key. A given instance can only be registered
		/// once. Succeeding attempts will return an error, indicating that it has already been registered. Note that font file loader
		/// implementations must not register themselves with DirectWrite inside their constructors, and must not unregister themselves
		/// inside their destructors, because registration and unregistraton operations increment and decrement the object reference count
		/// respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be performed outside of the
		/// font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontfileloader HRESULT
		// RegisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void RegisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Unregisters a font file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to the file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</para>
		/// </param>
		/// <remarks>
		/// This function unregisters font file loader callbacks with the DirectWrite font system. You should implement the font file loader
		/// interface by a singleton object. Note that font file loader implementations must not register themselves with DirectWrite inside
		/// their constructors and must not unregister themselves in their destructors, because registration and unregistraton operations
		/// increment and decrement the object reference count respectively. Instead, registration and unregistration of font file loaders
		/// with DirectWrite should be performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontfileloader HRESULT
		// UnregisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void UnregisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates a text format object used for text layout.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the name of the font family</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>A pointer to a font collection object. When this is <c>NULL</c>, indicates the system font collection.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the font weight for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that indicates the font style for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that indicates the font stretch for the text object created by this method.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP ("device-independent pixel") units. A DIP equals 1/96 inch.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the locale name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextFormat**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a newly created text format object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextformat HRESULT CreateTextFormat(
		// WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STYLE fontStyle,
		// DWRITE_FONT_STRETCH fontStretch, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat **textFormat );
		new IDWriteTextFormat CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection, DWRITE_FONT_WEIGHT fontWeight,
			DWRITE_FONT_STYLE fontStyle, DWRITE_FONT_STRETCH fontStretch, float fontSize, [MarshalAs(UnmanagedType.LPWStr)] string localeName);

		/// <summary>Creates a typography object for use in a text layout.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a newly created typography object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtypography HRESULT CreateTypography(
		// IDWriteTypography **typography );
		new IDWriteTypography CreateTypography();

		/// <summary>Creates an object that is used for interoperability with GDI.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteGdiInterop**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a GDI interop object if successful, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getgdiinterop HRESULT GetGdiInterop(
		// IDWriteGdiInterop **gdiInterop );
		new IDWriteGdiInterop GetGdiInterop();

		/// <summary>
		/// Takes a string, text format, and associated constraints, and produces an object that represents the fully analyzed and formatted result.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of characters in the string.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A pointer to an object that indicates the format to apply to the string.</para>
		/// </param>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the resultant text layout object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextlayout HRESULT CreateTextLayout(
		// WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT maxWidth, FLOAT maxHeight, IDWriteTextLayout
		// **textLayout );
		new IDWriteTextLayout CreateTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, float maxWidth, float maxHeight);

		/// <summary>
		/// Takes a string, format, and associated constraints, and produces an object representing the result, formatted for a particular
		/// display resolution and measuring mode.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length of the string, in character count.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>The text formatting object to apply to the string.</para>
		/// </param>
		/// <param name="layoutWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="layoutHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI device pixelsPerDipis
		/// 1. If rendering onto a 120 DPI device pixelsPerDip is 1.25 (120/96).
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specifies the font
		/// size and pixels per DIP.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Instructs the text layout to use the same metrics as GDI bi-level text when set to <c>FALSE</c>. When set to <c>TRUE</c>,
		/// instructs the text layout to use the same metrics as text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address to the pointer of the resultant text layout object.</para>
		/// </returns>
		/// <remarks>
		/// The resulting text layout should only be used for the intended resolution, and for cases where text scalability is desired
		/// CreateTextLayout should be used instead.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-creategdicompatibletextlayout HRESULT
		// CreateGdiCompatibleTextLayout( WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT layoutWidth, FLOAT
		// layoutHeight, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, IDWriteTextLayout **textLayout );
		new IDWriteTextLayout CreateGdiCompatibleTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat,
			float layoutWidth, float layoutHeight, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural);

		/// <summary>Creates an inline object for trimming, using an ellipsis as the omission sign.</summary>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A text format object, created with CreateTextFormat, used for text layout.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the omission (that is, ellipsis trimming) sign created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The ellipsis will be created using the current settings of the format, including base font, style, and any effects. Alternate
		/// omission signs can be created by the application by implementing IDWriteInlineObject.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createellipsistrimmingsign HRESULT
		// CreateEllipsisTrimmingSign( IDWriteTextFormat *textFormat, IDWriteInlineObject **trimmingSign );
		new IDWriteInlineObject CreateEllipsisTrimmingSign([In] IDWriteTextFormat textFormat);

		/// <summary>Returns an interface for performing text analysis.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTextAnalyzer**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created text analyzer object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextanalyzer HRESULT CreateTextAnalyzer(
		// IDWriteTextAnalyzer **textAnalyzer );
		new IDWriteTextAnalyzer CreateTextAnalyzer();

		/// <summary>
		/// Creates a number substitution object using a locale name, substitution method, and an indicator whether to ignore user overrides
		/// (use NLS defaults for the given culture instead).
		/// </summary>
		/// <param name="substitutionMethod">
		/// <para>Type: <c>DWRITE_NUMBER_SUBSTITUTION_METHOD</c></para>
		/// <para>A value that specifies how to apply number substitution on digits and related punctuation.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The name of the locale to be used in the numberSubstitution object.</para>
		/// </param>
		/// <param name="ignoreUserOverride">
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag that indicates whether to ignore user overrides.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteNumberSubstitution**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the number substitution object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createnumbersubstitution HRESULT
		// CreateNumberSubstitution( DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, WCHAR const *localeName, bool ignoreUserOverride,
		// IDWriteNumberSubstitution **numberSubstitution );
		new IDWriteNumberSubstitution CreateNumberSubstitution([In] DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, [MarshalAs(UnmanagedType.LPWStr)] string localeName, [In][MarshalAs(UnmanagedType.Bool)] bool ignoreUserOverride);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>A structure that contains the properties of the glyph run (font face, advances, and so on).</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI bitmap then pixelsPerDipis
		/// 1. If rendering onto a 120 DPI bitmap then pixelsPerDip is 1.25.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified the emSize
		/// and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>
		/// A value that specifies the rendering mode, which must be one of the raster rendering modes (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>Specifies the measuring mode to use with glyphs.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal position (X-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Vertical position (Y-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteGlyphRunAnalysis**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created glyph run analysis object.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The glyph run analysis object contains the results of analyzing the glyph run, including the positions of all the glyphs and
		/// references to all of the rasterized glyphs in the font cache.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to create a glyph run analysis object. In this example, an empty glyph run is being used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( DWRITE_GLYPH_RUN const *glyphRun, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, FLOAT baselineOriginX, FLOAT baselineOriginY,
		// IDWriteGlyphRunAnalysis **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, float pixelsPerDip, [In, Optional] IntPtr transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Gets a font collection representing the set of EUDC (end-user defined characters) fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>**</b></para>
		/// <para>The font collection to fill.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether to check for updates.</para>
		/// </param>
		/// <remarks>
		/// Note that if no EUDC is set on the system, the returned collection will be empty, meaning it will return success but
		/// GetFontFamilyCount will be zero.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-geteudcfontcollection HRESULT
		// GetEudcFontCollection( [out] IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetEudcFontCollection(out IDWriteFontCollection fontCollection, bool checkForUpdates = false);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrastGrayscale">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color components)
		/// that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams1</c>**</b></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT enhancedContrastGrayscale, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, [out] IDWriteRenderingParams1 **renderingParams );
		new IDWriteRenderingParams1 CreateCustomRenderingParams(float gamma, float enhancedContrast, float enhancedContrastGrayscale, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Creates a font fallback object from the system font fallback list.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallback</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-getsystemfontfallback HRESULT
		// GetSystemFontFallback( [out] IDWriteFontFallback **fontFallback );
		new IDWriteFontFallback GetSystemFontFallback();

		/// <summary>
		/// <para>Creates a font fallback builder object.</para>
		/// <para>
		/// A font fall back builder allows you to create Unicode font fallback mappings and create a font fall back object from those mappings.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallbackBuilder</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback builder object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createfontfallbackbuilder HRESULT
		// CreateFontFallbackBuilder( [out] IDWriteFontFallbackBuilder **fontFallbackBuilder );
		new IDWriteFontFallbackBuilder CreateFontFallbackBuilder();

		/// <summary>This method is called on a glyph run to translate it in to multiple color glyph runs.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Original glyph run containing monochrome glyph IDs.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN_DESCRIPTION</c>*</b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode used to compute glyph positions if the run contains color glyphs.</para>
		/// </param>
		/// <param name="worldToDeviceTransform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// World transform multiplied by any DPI scaling. This is needed to compute glyph positions if the run contains color glyphs and
		/// the measuring mode is not <c>DWRITE_MEASURING_MODE_NATURAL</c>. If this parameter is <b>NULL</b>, and identity transform is assumed.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator</c>**</b></para>
		/// <para>
		/// If the original glyph run contains color glyphs, this parameter receives a pointer to an <c>IDWriteColorGlyphRunEnumerator</c>
		/// interface. The client uses the returned interface to get information about glyph runs and associated colors to render instead of
		/// the original glyph run. If the original glyph run does not contain color glyphs, this method returns <b>DWRITE_E_NOCOLOR</b> and
		/// the output pointer is <b>NULL</b>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If the code calls this method with a glyph run that contains no color information, the method returns <b>DWRITE_E_NOCOLOR</b> to
		/// let the application know that it can just draw the original glyph run. If the glyph run contains color information, the function
		/// returns an object that can be enumerated through to expose runs and associated colors. The application then calls
		/// <c>DrawGlyphRun</c> with each of the returned glyph runs and foreground colors.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( FLOAT baselineOriginX, FLOAT baselineOriginY, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const
		// *worldToDeviceTransform, UINT32 colorPaletteIndex, [out] IDWriteColorGlyphRunEnumerator **colorLayers );
		new IDWriteColorGlyphRunEnumerator TranslateColorGlyphRun(float baselineOriginX, float baselineOriginY, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldToDeviceTransform, uint colorPaletteIndex);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>The geometry of a device pixel.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>
		/// Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// How to grid fit glyph outlines. In most cases, this should be DWRITE_GRID_FIT_DEFAULT to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams2</c>**</b></para>
		/// <para>Holds the newly created rendering parameters object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams2 **renderingParams );
		new IDWriteRenderingParams2 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Structure specifying the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// emSize and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b>DWRITE_RENDERING_MODE</b></para>
		/// <para>Specifies the rendering mode, which must be one of the raster rendering modes (i.e., not default and not outline).</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Specifies the method to measure glyphs.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>How to grid-fit glyph outlines. This must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>Specifies the antialias mode.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Horizontal position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Vertical position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>Receives a pointer to the newly created object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode, DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
			float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a glyph-run-analysis object that encapsulates info that <c>DirectWrite</c> uses to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>A <c>DWRITE_GLYPH_RUN</c> structure that contains the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the optional transform to be applied to glyphs and their positions.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the rendering mode, which must be one of the raster rendering modes
		/// (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the measuring method for glyphs in the run. This method uses this
		/// value with the other properties to determine the rendering mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. This value must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the type of antialiasing to use for text when the rendering mode
		/// calls for antialiasing.
		/// </para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteGlyphRunAnalysis</c> interface for the newly created
		/// glyph-run-analysis object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
			DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// A <c>DWRITE_PIXEL_GEOMETRY</c>-typed value that specifies the internal structure of a device pixel (that is, the physical
		/// arrangement of red, green, and blue color components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the method (for example, ClearType natural quality) for rendering
		/// glyphs. In most cases, specify <b>DWRITE_RENDERING_MODE1_DEFAULT</b> to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. In most cases, specify
		/// <b>DWRITE_GRID_FIT_DEFAULT</b> to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams3</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteRenderingParams3</c> interface for the newly created
		/// rendering parameters object, or <b>NULL</b> in case of failure.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams3 **renderingParams );
		new IDWriteRenderingParams3 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a reference to a font given a full path.</summary>
		/// <param name="filePath">
		/// <para>Type: [in] <b>WCHAR</b></para>
		/// <para>
		/// Absolute file path. Subsequent operations on the constructed object may fail if the user provided filePath doesn't correspond to
		/// a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: [in, optional] <b>FILETIME</b></para>
		/// <para>
		/// Last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time, so the clients are encouraged to specify this value to avoid extra disk access. Subsequent operations on the
		/// constructed object may fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(wcharconst_filetimeconst_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( WCHAR const *filePath, FILETIME const *lastWriteTime, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS
		// fontSimulations, IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference CreateFontFaceReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] PFILETIME? lastWriteTime,
			uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Creates a reference to a font given an <b>IDWriteFontFile</b>.</summary>
		/// <param name="fontFile">An <b>IDWriteFontFile</b> representing the font face.</param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(idwritefontfile_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( IDWriteFontFile *fontFile, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations, [out]
		// IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference CreateFontFaceReference([In] IDWriteFontFile fontFile, uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Retrieves the list of system fonts.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Holds the newly created font set object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontset HRESULT
		// GetSystemFontSet( [out] IDWriteFontSet **fontSet );
		new IDWriteFontSet GetSystemFontSet();

		/// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder</c>**</b></para>
		/// <para>Holds the newly created font set builder object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( [out] IDWriteFontSetBuilder **fontSetBuilder );
		new IDWriteFontSetBuilder CreateFontSetBuilder();

		/// <summary>Create a weight/width/slope tree from a set of fonts.</summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>A set of fonts to use to build the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontcollectionfromfontset HRESULT
		// CreateFontCollectionFromFontSet( IDWriteFontSet *fontSet, [out] IDWriteFontCollection1 **fontCollection );
		new IDWriteFontCollection1 CreateFontCollectionFromFontSet(IDWriteFontSet fontSet);

		/// <summary>Retrieves a weight/width/slope tree of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// <para>Type: <b>bool</b></para>
		/// <para>Indicates whether to include cloud fonts or only locally installed fonts.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// If this parameter is TRUE, the function performs an immediate check for changes to the set of system fonts. If this parameter is
		/// FALSE, the function will still detect changes if the font cache service is running, but there may be some latency. For example,
		/// an application might specify TRUE if it has just installed a font and wants to be sure the font collection contains that font.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontcollection HRESULT
		// GetSystemFontCollection( bool includeDownloadableFonts, IDWriteFontCollection1 **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(bool includeDownloadableFonts, out IDWriteFontCollection1 fontCollection, bool checkForUpdates = false);

		/// <summary>Gets the font download queue associated with this factory object.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontDownloadQueue</c>**</b></para>
		/// <para>Receives a pointer to the font download queue interface.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getfontdownloadqueue HRESULT
		// GetFontDownloadQueue( [out] IDWriteFontDownloadQueue **fontDownloadQueue );
		new IDWriteFontDownloadQueue GetFontDownloadQueue();

		/// <summary>
		/// Translates a glyph run to a sequence of color glyph runs, which can be rendered to produce a color representation of the
		/// original "base" run.
		/// </summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>Horizontal and vertical origin of the base glyph run in pre-transform coordinates.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Pointer to the original "base" glyph run.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN_DESCRIPTION</c></b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="desiredGlyphImageFormats">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Which data formats the runs should be split into.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode, needed to compute the origins of each glyph.</para>
		/// </param>
		/// <param name="worldAndDpiTransform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>
		/// Matrix converting from the client's coordinate space to device coordinates (pixels), i.e., the world transform multiplied by any
		/// DPI scaling.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <param name="colorLayers">
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator1</c>**</b></para>
		/// <para>
		/// If the function succeeds, receives a pointer to an enumerator object that can be used to obtain the color glyph runs. If the
		/// base run has no color glyphs, then the output pointer is NULL and the method returns DWRITE_E_NOCOLOR.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns DWRITE_E_NOCOLOR if the font has no color information, the glyph run does not contain any color glyphs, or the specified
		/// color palette index is out of range. In this case, the client should render the original glyph run. Otherwise, returns a
		/// standard HRESULT error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Calling <c>IDWriteFactory2::TranslateColorGlyphRun</c> is equivalent to calling <b>IDWriteFactory4::TranslateColorGlyph</b> run
		/// with the following formats specified: DWRITE_GLYPH_IMAGE_FORMATS_TRUETYPE|DWRITE_GLYPH_IMAGE_FORMATS_CFF|DWRITE_GLYPH_IMAGE_FORMATS_COLR.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( D2D1_POINT_2F baselineOrigin, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
		// DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const *worldAndDpiTransform, UINT32 colorPaletteIndex, [out]
		// IDWriteColorGlyphRunEnumerator1 **colorLayers );
		[PreserveSig]
		new HRESULT TranslateColorGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
			DWRITE_MEASURING_MODE measuringMode, [In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform, uint colorPaletteIndex,
			out IDWriteColorGlyphRunEnumerator1 colorLayers);

		/// <summary>Converts glyph run placements to glyph origins.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="glyphOrigins">
		/// <para>Type: [out] <b><c>D2D1_POINT_2F</c>*</b></para>
		/// <para>On return contains the glyph origins for the glyphrun.</para>
		/// </param>
		/// <remarks>
		/// The transform and DPI have no effect on the origin scaling. They are solely used to compute glyph advances when not supplied and
		/// align glyphs in pixel aligned measuring modes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-computeglyphorigins(dwrite_glyph_runconst_d2d1_point_2f_d2d1_point_2f)
		// HRESULT ComputeGlyphOrigins( DWRITE_GLYPH_RUN const *glyphRun, D2D1_POINT_2F baselineOrigin, D2D1_POINT_2F *glyphOrigins );
		new void ComputeGlyphOrigins(in DWRITE_GLYPH_RUN glyphRun, D2D_POINT_2F baselineOrigin,
			[Out, MarshalAs(UnmanagedType.LPArray)] D2D_POINT_2F[] glyphOrigins);

		/// <summary>Converts glyph run placements to glyph origins.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="measuringMode"/>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="worldAndDpiTransform"/>
		/// <param name="glyphOrigins">
		/// <para>Type: [out] <b><c>D2D1_POINT_2F</c>*</b></para>
		/// <para>On return contains the glyph origins for the glyphrun.</para>
		/// </param>
		/// <remarks>
		/// The transform and DPI have no effect on the origin scaling. They are solely used to compute glyph advances when not supplied and
		/// align glyphs in pixel aligned measuring modes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-computeglyphorigins(dwrite_glyph_runconst_dwrite_measuring_mode_d2d1_point_2f_dwrite_matrixconst_d2d1_point_2f)
		// HRESULT ComputeGlyphOrigins( DWRITE_GLYPH_RUN const *glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D1_POINT_2F baselineOrigin,
		// DWRITE_MATRIX const *worldAndDpiTransform, D2D1_POINT_2F *glyphOrigins );
		new void ComputeGlyphOrigins(in DWRITE_GLYPH_RUN glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D_POINT_2F baselineOrigin,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform, [Out, MarshalAs(UnmanagedType.LPArray)] D2D_POINT_2F[] glyphOrigins);

		/// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder1</c>**</b></para>
		/// <para>Holds the newly created font set builder object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( [out] IDWriteFontSetBuilder1 **fontSetBuilder );
		new IDWriteFontSetBuilder1 CreateFontSetBuilder1();

		/// <summary>
		/// Creates a loader object that can be used to create font file references to in-memory fonts. The caller is responsible for
		/// registering and unregistering the loader.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteInMemoryFontFileLoader</c>**</b></para>
		/// <para>Receives a pointer to the newly-created loader object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createinmemoryfontfileloader HRESULT
		// CreateInMemoryFontFileLoader( [out] IDWriteInMemoryFontFileLoader **newLoader );
		new IDWriteInMemoryFontFileLoader CreateInMemoryFontFileLoader();

		/// <summary>
		/// Creates a remote font file loader that can create font file references from HTTP or HTTPS URLs. The caller is responsible for
		/// registering and unregistering the loader.
		/// </summary>
		/// <param name="referrerUrl">
		/// <para>Type: <b>wchar_t const*</b></para>
		/// <para>Optional referrer URL for HTTP requests.</para>
		/// </param>
		/// <param name="extraHeaders">
		/// <para>Type: <b>wchar_t const*</b></para>
		/// <para>
		/// Optional additional header fields to include in HTTP requests. Each header field consists of a name followed by a colon (":")
		/// and the field value, as specified by RFC 2616. Multiple header fields may be separated by newlines.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRemoteFontFileLoader</c>**</b></para>
		/// <para>Receives a pointer to the newly-created loader object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createhttpfontfileloader HRESULT
		// CreateHttpFontFileLoader( wchar_t const *referrerUrl, wchar_t const *extraHeaders, [out] IDWriteRemoteFontFileLoader **newLoader );
		new IDWriteRemoteFontFileLoader CreateHttpFontFileLoader([Optional, MarshalAs(UnmanagedType.LPWStr)] string? referrerUrl, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? extraHeaders);

		/// <summary>
		/// The AnalyzeContainerType method analyzes the specified file data to determine whether it is a known font container format (e.g.,
		/// WOFF or WOFF2).
		/// </summary>
		/// <param name="fileData">
		/// <para>Type: <b>void</b></para>
		/// <para>Pointer to the file data to analyze.</para>
		/// </param>
		/// <param name="fileDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the buffer passed in fileData.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_CONTAINER_TYPE</c></b></para>
		/// <para>
		/// Returns the container type if recognized. DWRITE_CONTAINER_TYPE_UNKOWNN is returned for all other files, including uncompressed
		/// font files.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-analyzecontainertype
		// DWRITE_CONTAINER_TYPE AnalyzeContainerType( [in] void const *fileData, UINT32 fileDataSize );
		[PreserveSig]
		new DWRITE_CONTAINER_TYPE AnalyzeContainerType([In] IntPtr fileData, uint fileDataSize);

		/// <summary>
		/// The UnpackFontFile method unpacks font data from a container file (WOFF or WOFF2) and returns the unpacked font data in the form
		/// of a font file stream.
		/// </summary>
		/// <param name="containerType">
		/// <para>Type: <b><c>DWRITE_CONTAINER_TYPE</c></b></para>
		/// <para>Container type returned by AnalyzeContainerType.</para>
		/// </param>
		/// <param name="fileData">
		/// <para>Type: <b>void</b></para>
		/// <para>Pointer to the compressed data.</para>
		/// </param>
		/// <param name="fileDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the compressed data, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFileStream</c>**</b></para>
		/// <para>Receives a pointer to a newly created font file stream containing the uncompressed data.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-unpackfontfile HRESULT UnpackFontFile(
		// DWRITE_CONTAINER_TYPE containerType, [in] void const *fileData, UINT32 fileDataSize, [out] IDWriteFontFileStream
		// **unpackedFontStream );
		new IDWriteFontFileStream UnpackFontFile(DWRITE_CONTAINER_TYPE containerType, [In] IntPtr fileData, uint fileDataSize);

		/// <summary>Creates a reference to a specific font instance within a file.</summary>
		/// <param name="fontFile">
		/// <para>Type: <b><c>IDWriteFontFile</c>*</b></para>
		/// <para>A user-provided font file representing the font face.</para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font file contains a collection of font faces. If the font file contains a
		/// single face, then set this value to zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFaceReference1</c> interface. On successful completion, the function sets the
		/// pointer to a newly created font face reference object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontfacereference HRESULT
		// CreateFontFaceReference( IDWriteFontFile *fontFile, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations,
		// DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount, [out] IDWriteFontFaceReference1 **fontFaceReference );
		IDWriteFontFaceReference1 CreateFontFaceReference([In] IDWriteFontFile fontFile, uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Creates a font resource, given a font file and a face index.</summary>
		/// <param name="fontFile">
		/// <para>Type: <b><c>IDWriteFontFile</c>*</b></para>
		/// <para>A user-provided font file representing the font face.</para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font file contains a collection of font faces. If the font file contains a
		/// single face, then set this value to zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontResource</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontResource</c> interface. On successful completion, the function sets the pointer to
		/// a newly created font resource object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontresource HRESULT
		// CreateFontResource( IDWriteFontFile *fontFile, UINT32 faceIndex, IDWriteFontResource **fontResource );
		IDWriteFontResource CreateFontResource([In] IDWriteFontFile fontFile, uint faceIndex);

		/// <summary>Retrieves the set of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// Type: <b><c>BOOL</c></b>
		/// <para><see langword="true"/> if you want to include downloadable fonts. <c>false</c> if you only want locally installed fonts.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to the
		/// font set object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-getsystemfontset HRESULT
		// GetSystemFontSet( BOOL includeDownloadableFonts, IDWriteFontSet1 **fontSet );
		IDWriteFontSet1 GetSystemFontSet(bool includeDownloadableFonts);

		/// <summary>Retrieves a collection of fonts, grouped into families.</summary>
		/// <param name="includeDownloadableFonts">
		/// Type: <b><c>BOOL</c></b>
		/// <para><see langword="true"/> if you want to include downloadable fonts. <c>false</c> if you only want locally installed fonts.</para>
		/// </param>
		/// <param name="fontFamilyModel">
		/// <para>Type: <b><c>DWRITE_FONT_FAMILY_MODEL</c></b></para>
		/// <para>How to group families in the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontCollection2</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font collection object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-getsystemfontcollection HRESULT
		// GetSystemFontCollection( BOOL includeDownloadableFonts, DWRITE_FONT_FAMILY_MODEL fontFamilyModel, [out] IDWriteFontCollection2
		// **fontCollection );
		IDWriteFontCollection2 GetSystemFontCollection(bool includeDownloadableFonts, DWRITE_FONT_FAMILY_MODEL fontFamilyModel);

		/// <summary>From a font set, create a collection of fonts grouped into families.</summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>A set of fonts to use to build the collection.</para>
		/// </param>
		/// <param name="fontFamilyModel">
		/// <para>Type: <b><c>DWRITE_FONT_FAMILY_MODEL</c></b></para>
		/// <para>How to group families in the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontCollection2</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font collection object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontcollectionfromfontset HRESULT
		// CreateFontCollectionFromFontSet( IDWriteFontSet *fontSet, DWRITE_FONT_FAMILY_MODEL fontFamilyModel, [out] IDWriteFontCollection2
		// **fontCollection );
		IDWriteFontCollection2 CreateFontCollectionFromFontSet([In] IDWriteFontSet fontSet, DWRITE_FONT_FAMILY_MODEL fontFamilyModel);

		/// <summary>Creates an empty font set builder, ready to add font instances to, and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSetBuilder2</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font set builder object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( IDWriteFontSetBuilder2 **fontSetBuilder );
		IDWriteFontSetBuilder2 CreateFontSetBuilder2();

		/// <summary>Creates a text format object used for text layout.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>Name of the font family from the collection.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>*</b></para>
		/// <para>Font collection. Use <see langword="null"/> to indicate the system font collection.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>Logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>Locale name (for example, "ja-JP", "en-US", "ar-EG").</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteTextFormat3</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteTextFormat3</c> interface. On successful completion, the function sets the pointer to a
		/// newly created text format object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If fontCollection is <see langword="null"/>, then the system font collection is used, grouped by typographic family name (
		/// <c>DWRITE_FONT_FAMILY_MODEL_TYPOGRAPHIC</c>) without downloadable fonts.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createtextformat HRESULT
		// CreateTextFormat( WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_AXIS_VALUE const
		// *fontAxisValues, UINT32 fontAxisValueCount, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat3 **textFormat );
		IDWriteTextFormat3 CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount,
			float fontSize, [MarshalAs(UnmanagedType.LPWStr)] string localeName);
	}

	/// <summary>
	/// <para>
	/// This interface represents a factory object from which all DirectWrite objects are created. <b>IDWriteFactory7</b> adds new
	/// facilities for working with system fonts.
	/// </para>
	/// <para>This interface extends <c>IDWriteFactory6</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefactory7
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFactory7")]
	[ComImport, Guid("35D0E0B3-9076-4D2E-A016-A91B568A06B4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFactory7 : IDWriteFactory, IDWriteFactory1, IDWriteFactory2, IDWriteFactory3, IDWriteFactory4, IDWriteFactory5, IDWriteFactory6
	{
		/// <summary>Gets an object which represents the set of installed fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the system font collection object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If this parameter is nonzero, the function performs an immediate check for changes to the set of installed fonts. If this
		/// parameter is <c>FALSE</c>, the function will still detect changes if the font cache service is running, but there may be some
		/// latency. For example, an application might specify <c>TRUE</c> if it has itself just installed a font and wants to be sure the
		/// font collection contains that font.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getsystemfontcollection HRESULT
		// GetSystemFontCollection( IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(out IDWriteFontCollection fontCollection, [MarshalAs(UnmanagedType.Bool)] bool checkForUpdates = false);

		/// <summary>Creates a font collection using a custom font collection loader.</summary>
		/// <param name="collectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>An application-defined font collection loader, which must have been previously registered using RegisterFontCollectionLoader.</para>
		/// </param>
		/// <param name="collectionKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// The key used by the loader to identify a collection of font files. The buffer allocated for this key should at least be the size
		/// of collectionKeySize.
		/// </para>
		/// </param>
		/// <param name="collectionKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size, in bytes, of the collection key.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// Contains an address of a pointer to the system font collection object if the method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontcollection HRESULT
		// CreateCustomFontCollection( IDWriteFontCollectionLoader *collectionLoader, void const *collectionKey, UINT32 collectionKeySize,
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection CreateCustomFontCollection([In] IDWriteFontCollectionLoader collectionLoader, [In] IntPtr collectionKey, uint collectionKeySize);

		/// <summary>Registers a custom font collection loader with the factory object.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be registered.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font collection loader with DirectWrite. The font collection loader interface, which should be
		/// implemented by a singleton object, handles enumerating font files in a font collection given a particular type of key. A given
		/// instance can only be registered once. Succeeding attempts will return an error, indicating that it has already been registered.
		/// Note that font file loader implementations must not register themselves with DirectWrite inside their constructors, and must not
		/// unregister themselves inside their destructors, because registration and unregistraton operations increment and decrement the
		/// object reference count respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be
		/// performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontcollectionloader HRESULT
		// RegisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void RegisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Unregisters a custom font collection loader that was previously registered using RegisterFontCollectionLoader.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be unregistered.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontcollectionloader HRESULT
		// UnregisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void UnregisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Creates a font file reference object from a local font file.</summary>
		/// <param name="filePath">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the absolute file path for the font file. Subsequent operations on the constructed object
		/// may fail if the user provided filePath doesn't correspond to a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>
		/// The last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time. You should specify this value to avoid extra disk access. Subsequent operations on the constructed object may
		/// fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font file reference object, or <c>NULL</c> in
		/// case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontfilereference HRESULT
		// CreateFontFileReference( WCHAR const *filePath, FILETIME const *lastWriteTime, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateFontFileReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] IntPtr lastWriteTime);

		/// <summary>Creates a reference to an application-specific font file resource.</summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A font file reference key that uniquely identifies the font file resource during the lifetime of fontFileLoader.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the font file reference key in bytes.</para>
		/// </param>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>The font file loader that will be used by the font system to load data from the file identified by fontFileReferenceKey.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// Contains an address of a pointer to the newly created font file object when this method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function is provided for cases when an application or a document needs to use a private font without having to install it
		/// on the system. fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontfilereference HRESULT
		// CreateCustomFontFileReference( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, IDWriteFontFileLoader
		// *fontFileLoader, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateCustomFontFileReference([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, [In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates an object that represents a font face.</summary>
		/// <param name="fontFaceType">
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of file format of the font face.</para>
		/// </param>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font files, in element count, required to represent the font face.</para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>const IDWriteFontFile*</c></para>
		/// <para>
		/// A font file object representing the font face. Because IDWriteFontFacemaintains its own references to the input font file
		/// objects, you may release them after this call.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face, in cases when the font files contain a collection of font faces. If the font files contain
		/// a single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontFaceSimulationFlags">
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>
		/// A value that indicates which, if any, font face simulation flags for algorithmic means of making text bold or italic are applied
		/// to the current font face.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font face object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontface HRESULT CreateFontFace(
		// DWRITE_FONT_FACE_TYPE fontFaceType, UINT32 numberOfFiles, IDWriteFontFile * const *fontFiles, UINT32 faceIndex,
		// DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags, IDWriteFontFace **fontFace );
		new IDWriteFontFace CreateFontFace(DWRITE_FONT_FACE_TYPE fontFaceType, uint numberOfFiles,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[] fontFiles,
			uint faceIndex, DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags);

		/// <summary>
		/// Creates a rendering parameters object with default settings for the primary monitor. Different monitors may have different
		/// rendering parameters, for more information see the How to Add Support for Multiple Monitors topic.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createrenderingparams HRESULT
		// CreateRenderingParams( IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateRenderingParams();

		/// <summary>
		/// Creates a rendering parameters object with default settings for the specified monitor. In most cases, this is the preferred way
		/// to create a rendering parameters object.
		/// </summary>
		/// <param name="monitor">
		/// <para>Type: <c>HMONITOR</c></para>
		/// <para>A handle for the specified monitor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the rendering parameters object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createmonitorrenderingparams HRESULT
		// CreateMonitorRenderingParams( HMONITOR monitor, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateMonitorRenderingParams(HMONITOR monitor);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color
		/// components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry,
		// DWRITE_RENDERING_MODE renderingMode, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Registers a font file loader with DirectWrite.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to a IDWriteFontFileLoader object for a particular file resource type.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font file loader with DirectWrite. The font file loader interface, which should be implemented by a
		/// singleton object, handles loading font file resources of a particular type from a key. A given instance can only be registered
		/// once. Succeeding attempts will return an error, indicating that it has already been registered. Note that font file loader
		/// implementations must not register themselves with DirectWrite inside their constructors, and must not unregister themselves
		/// inside their destructors, because registration and unregistraton operations increment and decrement the object reference count
		/// respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be performed outside of the
		/// font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontfileloader HRESULT
		// RegisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void RegisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Unregisters a font file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to the file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</para>
		/// </param>
		/// <remarks>
		/// This function unregisters font file loader callbacks with the DirectWrite font system. You should implement the font file loader
		/// interface by a singleton object. Note that font file loader implementations must not register themselves with DirectWrite inside
		/// their constructors and must not unregister themselves in their destructors, because registration and unregistraton operations
		/// increment and decrement the object reference count respectively. Instead, registration and unregistration of font file loaders
		/// with DirectWrite should be performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontfileloader HRESULT
		// UnregisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void UnregisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates a text format object used for text layout.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the name of the font family</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>A pointer to a font collection object. When this is <c>NULL</c>, indicates the system font collection.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the font weight for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that indicates the font style for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that indicates the font stretch for the text object created by this method.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP ("device-independent pixel") units. A DIP equals 1/96 inch.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the locale name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextFormat**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a newly created text format object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextformat HRESULT CreateTextFormat(
		// WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STYLE fontStyle,
		// DWRITE_FONT_STRETCH fontStretch, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat **textFormat );
		new IDWriteTextFormat CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection, DWRITE_FONT_WEIGHT fontWeight,
			DWRITE_FONT_STYLE fontStyle, DWRITE_FONT_STRETCH fontStretch, float fontSize, [MarshalAs(UnmanagedType.LPWStr)] string localeName);

		/// <summary>Creates a typography object for use in a text layout.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a newly created typography object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtypography HRESULT CreateTypography(
		// IDWriteTypography **typography );
		new IDWriteTypography CreateTypography();

		/// <summary>Creates an object that is used for interoperability with GDI.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteGdiInterop**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a GDI interop object if successful, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getgdiinterop HRESULT GetGdiInterop(
		// IDWriteGdiInterop **gdiInterop );
		new IDWriteGdiInterop GetGdiInterop();

		/// <summary>
		/// Takes a string, text format, and associated constraints, and produces an object that represents the fully analyzed and formatted result.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of characters in the string.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A pointer to an object that indicates the format to apply to the string.</para>
		/// </param>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the resultant text layout object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextlayout HRESULT CreateTextLayout(
		// WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT maxWidth, FLOAT maxHeight, IDWriteTextLayout
		// **textLayout );
		new IDWriteTextLayout CreateTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, float maxWidth, float maxHeight);

		/// <summary>
		/// Takes a string, format, and associated constraints, and produces an object representing the result, formatted for a particular
		/// display resolution and measuring mode.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length of the string, in character count.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>The text formatting object to apply to the string.</para>
		/// </param>
		/// <param name="layoutWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="layoutHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI device pixelsPerDipis
		/// 1. If rendering onto a 120 DPI device pixelsPerDip is 1.25 (120/96).
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specifies the font
		/// size and pixels per DIP.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Instructs the text layout to use the same metrics as GDI bi-level text when set to <c>FALSE</c>. When set to <c>TRUE</c>,
		/// instructs the text layout to use the same metrics as text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address to the pointer of the resultant text layout object.</para>
		/// </returns>
		/// <remarks>
		/// The resulting text layout should only be used for the intended resolution, and for cases where text scalability is desired
		/// CreateTextLayout should be used instead.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-creategdicompatibletextlayout HRESULT
		// CreateGdiCompatibleTextLayout( WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT layoutWidth, FLOAT
		// layoutHeight, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, IDWriteTextLayout **textLayout );
		new IDWriteTextLayout CreateGdiCompatibleTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat,
			float layoutWidth, float layoutHeight, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural);

		/// <summary>Creates an inline object for trimming, using an ellipsis as the omission sign.</summary>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A text format object, created with CreateTextFormat, used for text layout.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the omission (that is, ellipsis trimming) sign created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The ellipsis will be created using the current settings of the format, including base font, style, and any effects. Alternate
		/// omission signs can be created by the application by implementing IDWriteInlineObject.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createellipsistrimmingsign HRESULT
		// CreateEllipsisTrimmingSign( IDWriteTextFormat *textFormat, IDWriteInlineObject **trimmingSign );
		new IDWriteInlineObject CreateEllipsisTrimmingSign([In] IDWriteTextFormat textFormat);

		/// <summary>Returns an interface for performing text analysis.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTextAnalyzer**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created text analyzer object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextanalyzer HRESULT CreateTextAnalyzer(
		// IDWriteTextAnalyzer **textAnalyzer );
		new IDWriteTextAnalyzer CreateTextAnalyzer();

		/// <summary>
		/// Creates a number substitution object using a locale name, substitution method, and an indicator whether to ignore user overrides
		/// (use NLS defaults for the given culture instead).
		/// </summary>
		/// <param name="substitutionMethod">
		/// <para>Type: <c>DWRITE_NUMBER_SUBSTITUTION_METHOD</c></para>
		/// <para>A value that specifies how to apply number substitution on digits and related punctuation.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The name of the locale to be used in the numberSubstitution object.</para>
		/// </param>
		/// <param name="ignoreUserOverride">
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag that indicates whether to ignore user overrides.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteNumberSubstitution**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the number substitution object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createnumbersubstitution HRESULT
		// CreateNumberSubstitution( DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, WCHAR const *localeName, bool ignoreUserOverride,
		// IDWriteNumberSubstitution **numberSubstitution );
		new IDWriteNumberSubstitution CreateNumberSubstitution([In] DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, [MarshalAs(UnmanagedType.LPWStr)] string localeName, [In][MarshalAs(UnmanagedType.Bool)] bool ignoreUserOverride);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>A structure that contains the properties of the glyph run (font face, advances, and so on).</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI bitmap then pixelsPerDipis
		/// 1. If rendering onto a 120 DPI bitmap then pixelsPerDip is 1.25.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified the emSize
		/// and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>
		/// A value that specifies the rendering mode, which must be one of the raster rendering modes (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>Specifies the measuring mode to use with glyphs.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal position (X-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Vertical position (Y-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteGlyphRunAnalysis**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created glyph run analysis object.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The glyph run analysis object contains the results of analyzing the glyph run, including the positions of all the glyphs and
		/// references to all of the rasterized glyphs in the font cache.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to create a glyph run analysis object. In this example, an empty glyph run is being used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( DWRITE_GLYPH_RUN const *glyphRun, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, FLOAT baselineOriginX, FLOAT baselineOriginY,
		// IDWriteGlyphRunAnalysis **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, float pixelsPerDip, [In, Optional] IntPtr transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Gets a font collection representing the set of EUDC (end-user defined characters) fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>**</b></para>
		/// <para>The font collection to fill.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether to check for updates.</para>
		/// </param>
		/// <remarks>
		/// Note that if no EUDC is set on the system, the returned collection will be empty, meaning it will return success but
		/// GetFontFamilyCount will be zero.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-geteudcfontcollection HRESULT
		// GetEudcFontCollection( [out] IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetEudcFontCollection(out IDWriteFontCollection fontCollection, bool checkForUpdates = false);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrastGrayscale">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color components)
		/// that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams1</c>**</b></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT enhancedContrastGrayscale, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, [out] IDWriteRenderingParams1 **renderingParams );
		new IDWriteRenderingParams1 CreateCustomRenderingParams(float gamma, float enhancedContrast, float enhancedContrastGrayscale, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Creates a font fallback object from the system font fallback list.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallback</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-getsystemfontfallback HRESULT
		// GetSystemFontFallback( [out] IDWriteFontFallback **fontFallback );
		new IDWriteFontFallback GetSystemFontFallback();

		/// <summary>
		/// <para>Creates a font fallback builder object.</para>
		/// <para>
		/// A font fall back builder allows you to create Unicode font fallback mappings and create a font fall back object from those mappings.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallbackBuilder</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback builder object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createfontfallbackbuilder HRESULT
		// CreateFontFallbackBuilder( [out] IDWriteFontFallbackBuilder **fontFallbackBuilder );
		new IDWriteFontFallbackBuilder CreateFontFallbackBuilder();

		/// <summary>This method is called on a glyph run to translate it in to multiple color glyph runs.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Original glyph run containing monochrome glyph IDs.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN_DESCRIPTION</c>*</b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode used to compute glyph positions if the run contains color glyphs.</para>
		/// </param>
		/// <param name="worldToDeviceTransform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// World transform multiplied by any DPI scaling. This is needed to compute glyph positions if the run contains color glyphs and
		/// the measuring mode is not <c>DWRITE_MEASURING_MODE_NATURAL</c>. If this parameter is <b>NULL</b>, and identity transform is assumed.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator</c>**</b></para>
		/// <para>
		/// If the original glyph run contains color glyphs, this parameter receives a pointer to an <c>IDWriteColorGlyphRunEnumerator</c>
		/// interface. The client uses the returned interface to get information about glyph runs and associated colors to render instead of
		/// the original glyph run. If the original glyph run does not contain color glyphs, this method returns <b>DWRITE_E_NOCOLOR</b> and
		/// the output pointer is <b>NULL</b>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If the code calls this method with a glyph run that contains no color information, the method returns <b>DWRITE_E_NOCOLOR</b> to
		/// let the application know that it can just draw the original glyph run. If the glyph run contains color information, the function
		/// returns an object that can be enumerated through to expose runs and associated colors. The application then calls
		/// <c>DrawGlyphRun</c> with each of the returned glyph runs and foreground colors.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( FLOAT baselineOriginX, FLOAT baselineOriginY, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const
		// *worldToDeviceTransform, UINT32 colorPaletteIndex, [out] IDWriteColorGlyphRunEnumerator **colorLayers );
		new IDWriteColorGlyphRunEnumerator TranslateColorGlyphRun(float baselineOriginX, float baselineOriginY, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldToDeviceTransform, uint colorPaletteIndex);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>The geometry of a device pixel.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>
		/// Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// How to grid fit glyph outlines. In most cases, this should be DWRITE_GRID_FIT_DEFAULT to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams2</c>**</b></para>
		/// <para>Holds the newly created rendering parameters object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams2 **renderingParams );
		new IDWriteRenderingParams2 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Structure specifying the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// emSize and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b>DWRITE_RENDERING_MODE</b></para>
		/// <para>Specifies the rendering mode, which must be one of the raster rendering modes (i.e., not default and not outline).</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Specifies the method to measure glyphs.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>How to grid-fit glyph outlines. This must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>Specifies the antialias mode.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Horizontal position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Vertical position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>Receives a pointer to the newly created object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode, DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
			float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a glyph-run-analysis object that encapsulates info that <c>DirectWrite</c> uses to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>A <c>DWRITE_GLYPH_RUN</c> structure that contains the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the optional transform to be applied to glyphs and their positions.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the rendering mode, which must be one of the raster rendering modes
		/// (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the measuring method for glyphs in the run. This method uses this
		/// value with the other properties to determine the rendering mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. This value must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the type of antialiasing to use for text when the rendering mode
		/// calls for antialiasing.
		/// </para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteGlyphRunAnalysis</c> interface for the newly created
		/// glyph-run-analysis object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
			DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// A <c>DWRITE_PIXEL_GEOMETRY</c>-typed value that specifies the internal structure of a device pixel (that is, the physical
		/// arrangement of red, green, and blue color components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the method (for example, ClearType natural quality) for rendering
		/// glyphs. In most cases, specify <b>DWRITE_RENDERING_MODE1_DEFAULT</b> to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. In most cases, specify
		/// <b>DWRITE_GRID_FIT_DEFAULT</b> to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams3</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteRenderingParams3</c> interface for the newly created
		/// rendering parameters object, or <b>NULL</b> in case of failure.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams3 **renderingParams );
		new IDWriteRenderingParams3 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a reference to a font given a full path.</summary>
		/// <param name="filePath">
		/// <para>Type: [in] <b>WCHAR</b></para>
		/// <para>
		/// Absolute file path. Subsequent operations on the constructed object may fail if the user provided filePath doesn't correspond to
		/// a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: [in, optional] <b>FILETIME</b></para>
		/// <para>
		/// Last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time, so the clients are encouraged to specify this value to avoid extra disk access. Subsequent operations on the
		/// constructed object may fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(wcharconst_filetimeconst_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( WCHAR const *filePath, FILETIME const *lastWriteTime, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS
		// fontSimulations, IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference CreateFontFaceReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] PFILETIME? lastWriteTime,
			uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Creates a reference to a font given an <b>IDWriteFontFile</b>.</summary>
		/// <param name="fontFile">An <b>IDWriteFontFile</b> representing the font face.</param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(idwritefontfile_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( IDWriteFontFile *fontFile, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations, [out]
		// IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference CreateFontFaceReference([In] IDWriteFontFile fontFile, uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Retrieves the list of system fonts.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Holds the newly created font set object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontset HRESULT
		// GetSystemFontSet( [out] IDWriteFontSet **fontSet );
		new IDWriteFontSet GetSystemFontSet();

		/// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder</c>**</b></para>
		/// <para>Holds the newly created font set builder object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( [out] IDWriteFontSetBuilder **fontSetBuilder );
		new IDWriteFontSetBuilder CreateFontSetBuilder();

		/// <summary>Create a weight/width/slope tree from a set of fonts.</summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>A set of fonts to use to build the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontcollectionfromfontset HRESULT
		// CreateFontCollectionFromFontSet( IDWriteFontSet *fontSet, [out] IDWriteFontCollection1 **fontCollection );
		new IDWriteFontCollection1 CreateFontCollectionFromFontSet(IDWriteFontSet fontSet);

		/// <summary>Retrieves a weight/width/slope tree of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// <para>Type: <b>bool</b></para>
		/// <para>Indicates whether to include cloud fonts or only locally installed fonts.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// If this parameter is TRUE, the function performs an immediate check for changes to the set of system fonts. If this parameter is
		/// FALSE, the function will still detect changes if the font cache service is running, but there may be some latency. For example,
		/// an application might specify TRUE if it has just installed a font and wants to be sure the font collection contains that font.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontcollection HRESULT
		// GetSystemFontCollection( bool includeDownloadableFonts, IDWriteFontCollection1 **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(bool includeDownloadableFonts, out IDWriteFontCollection1 fontCollection, bool checkForUpdates = false);

		/// <summary>Gets the font download queue associated with this factory object.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontDownloadQueue</c>**</b></para>
		/// <para>Receives a pointer to the font download queue interface.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getfontdownloadqueue HRESULT
		// GetFontDownloadQueue( [out] IDWriteFontDownloadQueue **fontDownloadQueue );
		new IDWriteFontDownloadQueue GetFontDownloadQueue();

		/// <summary>
		/// Translates a glyph run to a sequence of color glyph runs, which can be rendered to produce a color representation of the
		/// original "base" run.
		/// </summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>Horizontal and vertical origin of the base glyph run in pre-transform coordinates.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Pointer to the original "base" glyph run.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN_DESCRIPTION</c></b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="desiredGlyphImageFormats">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Which data formats the runs should be split into.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode, needed to compute the origins of each glyph.</para>
		/// </param>
		/// <param name="worldAndDpiTransform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>
		/// Matrix converting from the client's coordinate space to device coordinates (pixels), i.e., the world transform multiplied by any
		/// DPI scaling.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <param name="colorLayers">
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator1</c>**</b></para>
		/// <para>
		/// If the function succeeds, receives a pointer to an enumerator object that can be used to obtain the color glyph runs. If the
		/// base run has no color glyphs, then the output pointer is NULL and the method returns DWRITE_E_NOCOLOR.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns DWRITE_E_NOCOLOR if the font has no color information, the glyph run does not contain any color glyphs, or the specified
		/// color palette index is out of range. In this case, the client should render the original glyph run. Otherwise, returns a
		/// standard HRESULT error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Calling <c>IDWriteFactory2::TranslateColorGlyphRun</c> is equivalent to calling <b>IDWriteFactory4::TranslateColorGlyph</b> run
		/// with the following formats specified: DWRITE_GLYPH_IMAGE_FORMATS_TRUETYPE|DWRITE_GLYPH_IMAGE_FORMATS_CFF|DWRITE_GLYPH_IMAGE_FORMATS_COLR.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( D2D1_POINT_2F baselineOrigin, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
		// DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const *worldAndDpiTransform, UINT32 colorPaletteIndex, [out]
		// IDWriteColorGlyphRunEnumerator1 **colorLayers );
		[PreserveSig]
		new HRESULT TranslateColorGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
			DWRITE_MEASURING_MODE measuringMode, [In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform, uint colorPaletteIndex,
			out IDWriteColorGlyphRunEnumerator1 colorLayers);

		/// <summary>Converts glyph run placements to glyph origins.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="glyphOrigins">
		/// <para>Type: [out] <b><c>D2D1_POINT_2F</c>*</b></para>
		/// <para>On return contains the glyph origins for the glyphrun.</para>
		/// </param>
		/// <remarks>
		/// The transform and DPI have no effect on the origin scaling. They are solely used to compute glyph advances when not supplied and
		/// align glyphs in pixel aligned measuring modes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-computeglyphorigins(dwrite_glyph_runconst_d2d1_point_2f_d2d1_point_2f)
		// HRESULT ComputeGlyphOrigins( DWRITE_GLYPH_RUN const *glyphRun, D2D1_POINT_2F baselineOrigin, D2D1_POINT_2F *glyphOrigins );
		new void ComputeGlyphOrigins(in DWRITE_GLYPH_RUN glyphRun, D2D_POINT_2F baselineOrigin,
			[Out, MarshalAs(UnmanagedType.LPArray)] D2D_POINT_2F[] glyphOrigins);

		/// <summary>Converts glyph run placements to glyph origins.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="measuringMode"/>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="worldAndDpiTransform"/>
		/// <param name="glyphOrigins">
		/// <para>Type: [out] <b><c>D2D1_POINT_2F</c>*</b></para>
		/// <para>On return contains the glyph origins for the glyphrun.</para>
		/// </param>
		/// <remarks>
		/// The transform and DPI have no effect on the origin scaling. They are solely used to compute glyph advances when not supplied and
		/// align glyphs in pixel aligned measuring modes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-computeglyphorigins(dwrite_glyph_runconst_dwrite_measuring_mode_d2d1_point_2f_dwrite_matrixconst_d2d1_point_2f)
		// HRESULT ComputeGlyphOrigins( DWRITE_GLYPH_RUN const *glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D1_POINT_2F baselineOrigin,
		// DWRITE_MATRIX const *worldAndDpiTransform, D2D1_POINT_2F *glyphOrigins );
		new void ComputeGlyphOrigins(in DWRITE_GLYPH_RUN glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D_POINT_2F baselineOrigin,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform, [Out, MarshalAs(UnmanagedType.LPArray)] D2D_POINT_2F[] glyphOrigins);

		/// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder1</c>**</b></para>
		/// <para>Holds the newly created font set builder object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( [out] IDWriteFontSetBuilder1 **fontSetBuilder );
		new IDWriteFontSetBuilder1 CreateFontSetBuilder1();

		/// <summary>
		/// Creates a loader object that can be used to create font file references to in-memory fonts. The caller is responsible for
		/// registering and unregistering the loader.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteInMemoryFontFileLoader</c>**</b></para>
		/// <para>Receives a pointer to the newly-created loader object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createinmemoryfontfileloader HRESULT
		// CreateInMemoryFontFileLoader( [out] IDWriteInMemoryFontFileLoader **newLoader );
		new IDWriteInMemoryFontFileLoader CreateInMemoryFontFileLoader();

		/// <summary>
		/// Creates a remote font file loader that can create font file references from HTTP or HTTPS URLs. The caller is responsible for
		/// registering and unregistering the loader.
		/// </summary>
		/// <param name="referrerUrl">
		/// <para>Type: <b>wchar_t const*</b></para>
		/// <para>Optional referrer URL for HTTP requests.</para>
		/// </param>
		/// <param name="extraHeaders">
		/// <para>Type: <b>wchar_t const*</b></para>
		/// <para>
		/// Optional additional header fields to include in HTTP requests. Each header field consists of a name followed by a colon (":")
		/// and the field value, as specified by RFC 2616. Multiple header fields may be separated by newlines.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRemoteFontFileLoader</c>**</b></para>
		/// <para>Receives a pointer to the newly-created loader object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createhttpfontfileloader HRESULT
		// CreateHttpFontFileLoader( wchar_t const *referrerUrl, wchar_t const *extraHeaders, [out] IDWriteRemoteFontFileLoader **newLoader );
		new IDWriteRemoteFontFileLoader CreateHttpFontFileLoader([Optional, MarshalAs(UnmanagedType.LPWStr)] string? referrerUrl, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? extraHeaders);

		/// <summary>
		/// The AnalyzeContainerType method analyzes the specified file data to determine whether it is a known font container format (e.g.,
		/// WOFF or WOFF2).
		/// </summary>
		/// <param name="fileData">
		/// <para>Type: <b>void</b></para>
		/// <para>Pointer to the file data to analyze.</para>
		/// </param>
		/// <param name="fileDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the buffer passed in fileData.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_CONTAINER_TYPE</c></b></para>
		/// <para>
		/// Returns the container type if recognized. DWRITE_CONTAINER_TYPE_UNKOWNN is returned for all other files, including uncompressed
		/// font files.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-analyzecontainertype
		// DWRITE_CONTAINER_TYPE AnalyzeContainerType( [in] void const *fileData, UINT32 fileDataSize );
		[PreserveSig]
		new DWRITE_CONTAINER_TYPE AnalyzeContainerType([In] IntPtr fileData, uint fileDataSize);

		/// <summary>
		/// The UnpackFontFile method unpacks font data from a container file (WOFF or WOFF2) and returns the unpacked font data in the form
		/// of a font file stream.
		/// </summary>
		/// <param name="containerType">
		/// <para>Type: <b><c>DWRITE_CONTAINER_TYPE</c></b></para>
		/// <para>Container type returned by AnalyzeContainerType.</para>
		/// </param>
		/// <param name="fileData">
		/// <para>Type: <b>void</b></para>
		/// <para>Pointer to the compressed data.</para>
		/// </param>
		/// <param name="fileDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the compressed data, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFileStream</c>**</b></para>
		/// <para>Receives a pointer to a newly created font file stream containing the uncompressed data.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-unpackfontfile HRESULT UnpackFontFile(
		// DWRITE_CONTAINER_TYPE containerType, [in] void const *fileData, UINT32 fileDataSize, [out] IDWriteFontFileStream
		// **unpackedFontStream );
		new IDWriteFontFileStream UnpackFontFile(DWRITE_CONTAINER_TYPE containerType, [In] IntPtr fileData, uint fileDataSize);

		/// <summary>Creates a reference to a specific font instance within a file.</summary>
		/// <param name="fontFile">
		/// <para>Type: <b><c>IDWriteFontFile</c>*</b></para>
		/// <para>A user-provided font file representing the font face.</para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font file contains a collection of font faces. If the font file contains a
		/// single face, then set this value to zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFaceReference1</c> interface. On successful completion, the function sets the
		/// pointer to a newly created font face reference object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontfacereference HRESULT
		// CreateFontFaceReference( IDWriteFontFile *fontFile, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations,
		// DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount, [out] IDWriteFontFaceReference1 **fontFaceReference );
		new IDWriteFontFaceReference1 CreateFontFaceReference([In] IDWriteFontFile fontFile, uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Creates a font resource, given a font file and a face index.</summary>
		/// <param name="fontFile">
		/// <para>Type: <b><c>IDWriteFontFile</c>*</b></para>
		/// <para>A user-provided font file representing the font face.</para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font file contains a collection of font faces. If the font file contains a
		/// single face, then set this value to zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontResource</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontResource</c> interface. On successful completion, the function sets the pointer to
		/// a newly created font resource object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontresource HRESULT
		// CreateFontResource( IDWriteFontFile *fontFile, UINT32 faceIndex, IDWriteFontResource **fontResource );
		new IDWriteFontResource CreateFontResource([In] IDWriteFontFile fontFile, uint faceIndex);

		/// <summary>Retrieves the set of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// Type: <b><c>BOOL</c></b>
		/// <para><see langword="true"/> if you want to include downloadable fonts. <c>false</c> if you only want locally installed fonts.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to the
		/// font set object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-getsystemfontset HRESULT
		// GetSystemFontSet( BOOL includeDownloadableFonts, IDWriteFontSet1 **fontSet );
		new IDWriteFontSet1 GetSystemFontSet(bool includeDownloadableFonts);

		/// <summary>Retrieves a collection of fonts, grouped into families.</summary>
		/// <param name="includeDownloadableFonts">
		/// Type: <b><c>BOOL</c></b>
		/// <para><see langword="true"/> if you want to include downloadable fonts. <c>false</c> if you only want locally installed fonts.</para>
		/// </param>
		/// <param name="fontFamilyModel">
		/// <para>Type: <b><c>DWRITE_FONT_FAMILY_MODEL</c></b></para>
		/// <para>How to group families in the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontCollection2</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font collection object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-getsystemfontcollection HRESULT
		// GetSystemFontCollection( BOOL includeDownloadableFonts, DWRITE_FONT_FAMILY_MODEL fontFamilyModel, [out] IDWriteFontCollection2
		// **fontCollection );
		new IDWriteFontCollection2 GetSystemFontCollection(bool includeDownloadableFonts, DWRITE_FONT_FAMILY_MODEL fontFamilyModel);

		/// <summary>From a font set, create a collection of fonts grouped into families.</summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>A set of fonts to use to build the collection.</para>
		/// </param>
		/// <param name="fontFamilyModel">
		/// <para>Type: <b><c>DWRITE_FONT_FAMILY_MODEL</c></b></para>
		/// <para>How to group families in the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontCollection2</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font collection object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontcollectionfromfontset HRESULT
		// CreateFontCollectionFromFontSet( IDWriteFontSet *fontSet, DWRITE_FONT_FAMILY_MODEL fontFamilyModel, [out] IDWriteFontCollection2
		// **fontCollection );
		new IDWriteFontCollection2 CreateFontCollectionFromFontSet([In] IDWriteFontSet fontSet, DWRITE_FONT_FAMILY_MODEL fontFamilyModel);

		/// <summary>Creates an empty font set builder, ready to add font instances to, and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSetBuilder2</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font set builder object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( IDWriteFontSetBuilder2 **fontSetBuilder );
		new IDWriteFontSetBuilder2 CreateFontSetBuilder2();

		/// <summary>Creates a text format object used for text layout.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>Name of the font family from the collection.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>*</b></para>
		/// <para>Font collection. Use <see langword="null"/> to indicate the system font collection.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>Logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>Locale name (for example, "ja-JP", "en-US", "ar-EG").</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteTextFormat3</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteTextFormat3</c> interface. On successful completion, the function sets the pointer to a
		/// newly created text format object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If fontCollection is <see langword="null"/>, then the system font collection is used, grouped by typographic family name (
		/// <c>DWRITE_FONT_FAMILY_MODEL_TYPOGRAPHIC</c>) without downloadable fonts.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createtextformat HRESULT
		// CreateTextFormat( WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_AXIS_VALUE const
		// *fontAxisValues, UINT32 fontAxisValueCount, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat3 **textFormat );
		new IDWriteTextFormat3 CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount,
			float fontSize, [MarshalAs(UnmanagedType.LPWStr)] string localeName);

		/// <summary>Retrieves the set of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// Type: <b><c>BOOL</c></b>
		/// <para><see langword="true"/> if you want to include downloadable fonts. <c>false</c> if you only want locally installed fonts.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet2</c> interface. On successful completion, the function sets the pointer to the
		/// font set object, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory7-getsystemfontset HRESULT
		// GetSystemFontSet( BOOL includeDownloadableFonts, IDWriteFontSet2 **fontSet );
		IDWriteFontSet2 GetSystemFontSet2(bool includeDownloadableFonts);

		/// <summary>Retrieves a collection of fonts, grouped into families.</summary>
		/// <param name="includeDownloadableFonts">
		/// Type: <b><c>BOOL</c></b>
		/// <para><see langword="true"/> if you want to include downloadable fonts. <c>false</c> if you only want locally installed fonts.</para>
		/// </param>
		/// <param name="fontFamilyModel">
		/// <para>Type: <b><c>DWRITE_FONT_FAMILY_MODEL</c></b></para>
		/// <para>How to group families in the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection3</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontCollection3</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font collection object, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory7-getsystemfontcollection HRESULT
		// GetSystemFontCollection( BOOL includeDownloadableFonts, DWRITE_FONT_FAMILY_MODEL fontFamilyModel, [out] IDWriteFontCollection3
		// **fontCollection );
		IDWriteFontCollection3 GetSystemFontCollection3(bool includeDownloadableFonts, DWRITE_FONT_FAMILY_MODEL fontFamilyModel);
	}

	/// <summary>
	/// <para>
	/// Represents a factory object from which all DirectWrite objects are created. <b>IDWriteFactory8</b> adds a new version of
	/// <c>TranslateColorGlyphRun</c>, which takes a <b>DWRITE_PAINT_FEATURE_LEVEL</b>.
	/// </para>
	/// <para>The <b>IDWriteFactory8</b> interface inherits from the <c>IDWriteFactory7</c> interface.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nn-dwrite_3-idwritefactory8
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFactory8")]
	[ComImport, Guid("EE0A7FB5-DEF4-4C23-A454-C9C7DC878398"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFactory8 : IDWriteFactory, IDWriteFactory1, IDWriteFactory2, IDWriteFactory3, IDWriteFactory4, IDWriteFactory5, IDWriteFactory6, IDWriteFactory7
	{
		/// <summary>Gets an object which represents the set of installed fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the system font collection object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If this parameter is nonzero, the function performs an immediate check for changes to the set of installed fonts. If this
		/// parameter is <c>FALSE</c>, the function will still detect changes if the font cache service is running, but there may be some
		/// latency. For example, an application might specify <c>TRUE</c> if it has itself just installed a font and wants to be sure the
		/// font collection contains that font.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getsystemfontcollection HRESULT
		// GetSystemFontCollection( IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(out IDWriteFontCollection fontCollection, [MarshalAs(UnmanagedType.Bool)] bool checkForUpdates = false);

		/// <summary>Creates a font collection using a custom font collection loader.</summary>
		/// <param name="collectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>An application-defined font collection loader, which must have been previously registered using RegisterFontCollectionLoader.</para>
		/// </param>
		/// <param name="collectionKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// The key used by the loader to identify a collection of font files. The buffer allocated for this key should at least be the size
		/// of collectionKeySize.
		/// </para>
		/// </param>
		/// <param name="collectionKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size, in bytes, of the collection key.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// Contains an address of a pointer to the system font collection object if the method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontcollection HRESULT
		// CreateCustomFontCollection( IDWriteFontCollectionLoader *collectionLoader, void const *collectionKey, UINT32 collectionKeySize,
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection CreateCustomFontCollection([In] IDWriteFontCollectionLoader collectionLoader, [In] IntPtr collectionKey, uint collectionKeySize);

		/// <summary>Registers a custom font collection loader with the factory object.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be registered.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font collection loader with DirectWrite. The font collection loader interface, which should be
		/// implemented by a singleton object, handles enumerating font files in a font collection given a particular type of key. A given
		/// instance can only be registered once. Succeeding attempts will return an error, indicating that it has already been registered.
		/// Note that font file loader implementations must not register themselves with DirectWrite inside their constructors, and must not
		/// unregister themselves inside their destructors, because registration and unregistraton operations increment and decrement the
		/// object reference count respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be
		/// performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontcollectionloader HRESULT
		// RegisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void RegisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Unregisters a custom font collection loader that was previously registered using RegisterFontCollectionLoader.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be unregistered.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontcollectionloader HRESULT
		// UnregisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void UnregisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Creates a font file reference object from a local font file.</summary>
		/// <param name="filePath">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the absolute file path for the font file. Subsequent operations on the constructed object
		/// may fail if the user provided filePath doesn't correspond to a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>
		/// The last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time. You should specify this value to avoid extra disk access. Subsequent operations on the constructed object may
		/// fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font file reference object, or <c>NULL</c> in
		/// case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontfilereference HRESULT
		// CreateFontFileReference( WCHAR const *filePath, FILETIME const *lastWriteTime, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateFontFileReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] IntPtr lastWriteTime);

		/// <summary>Creates a reference to an application-specific font file resource.</summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A font file reference key that uniquely identifies the font file resource during the lifetime of fontFileLoader.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the font file reference key in bytes.</para>
		/// </param>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>The font file loader that will be used by the font system to load data from the file identified by fontFileReferenceKey.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// Contains an address of a pointer to the newly created font file object when this method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function is provided for cases when an application or a document needs to use a private font without having to install it
		/// on the system. fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontfilereference HRESULT
		// CreateCustomFontFileReference( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, IDWriteFontFileLoader
		// *fontFileLoader, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateCustomFontFileReference([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, [In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates an object that represents a font face.</summary>
		/// <param name="fontFaceType">
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of file format of the font face.</para>
		/// </param>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font files, in element count, required to represent the font face.</para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>const IDWriteFontFile*</c></para>
		/// <para>
		/// A font file object representing the font face. Because IDWriteFontFacemaintains its own references to the input font file
		/// objects, you may release them after this call.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face, in cases when the font files contain a collection of font faces. If the font files contain
		/// a single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontFaceSimulationFlags">
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>
		/// A value that indicates which, if any, font face simulation flags for algorithmic means of making text bold or italic are applied
		/// to the current font face.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font face object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontface HRESULT CreateFontFace(
		// DWRITE_FONT_FACE_TYPE fontFaceType, UINT32 numberOfFiles, IDWriteFontFile * const *fontFiles, UINT32 faceIndex,
		// DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags, IDWriteFontFace **fontFace );
		new IDWriteFontFace CreateFontFace(DWRITE_FONT_FACE_TYPE fontFaceType, uint numberOfFiles,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[] fontFiles,
			uint faceIndex, DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags);

		/// <summary>
		/// Creates a rendering parameters object with default settings for the primary monitor. Different monitors may have different
		/// rendering parameters, for more information see the How to Add Support for Multiple Monitors topic.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createrenderingparams HRESULT
		// CreateRenderingParams( IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateRenderingParams();

		/// <summary>
		/// Creates a rendering parameters object with default settings for the specified monitor. In most cases, this is the preferred way
		/// to create a rendering parameters object.
		/// </summary>
		/// <param name="monitor">
		/// <para>Type: <c>HMONITOR</c></para>
		/// <para>A handle for the specified monitor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the rendering parameters object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createmonitorrenderingparams HRESULT
		// CreateMonitorRenderingParams( HMONITOR monitor, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateMonitorRenderingParams(HMONITOR monitor);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color
		/// components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry,
		// DWRITE_RENDERING_MODE renderingMode, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Registers a font file loader with DirectWrite.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to a IDWriteFontFileLoader object for a particular file resource type.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font file loader with DirectWrite. The font file loader interface, which should be implemented by a
		/// singleton object, handles loading font file resources of a particular type from a key. A given instance can only be registered
		/// once. Succeeding attempts will return an error, indicating that it has already been registered. Note that font file loader
		/// implementations must not register themselves with DirectWrite inside their constructors, and must not unregister themselves
		/// inside their destructors, because registration and unregistraton operations increment and decrement the object reference count
		/// respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be performed outside of the
		/// font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontfileloader HRESULT
		// RegisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void RegisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Unregisters a font file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to the file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</para>
		/// </param>
		/// <remarks>
		/// This function unregisters font file loader callbacks with the DirectWrite font system. You should implement the font file loader
		/// interface by a singleton object. Note that font file loader implementations must not register themselves with DirectWrite inside
		/// their constructors and must not unregister themselves in their destructors, because registration and unregistraton operations
		/// increment and decrement the object reference count respectively. Instead, registration and unregistration of font file loaders
		/// with DirectWrite should be performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontfileloader HRESULT
		// UnregisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void UnregisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates a text format object used for text layout.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the name of the font family</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>A pointer to a font collection object. When this is <c>NULL</c>, indicates the system font collection.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the font weight for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that indicates the font style for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that indicates the font stretch for the text object created by this method.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP ("device-independent pixel") units. A DIP equals 1/96 inch.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the locale name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextFormat**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a newly created text format object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextformat HRESULT CreateTextFormat(
		// WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STYLE fontStyle,
		// DWRITE_FONT_STRETCH fontStretch, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat **textFormat );
		new IDWriteTextFormat CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection, DWRITE_FONT_WEIGHT fontWeight,
			DWRITE_FONT_STYLE fontStyle, DWRITE_FONT_STRETCH fontStretch, float fontSize, [MarshalAs(UnmanagedType.LPWStr)] string localeName);

		/// <summary>Creates a typography object for use in a text layout.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a newly created typography object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtypography HRESULT CreateTypography(
		// IDWriteTypography **typography );
		new IDWriteTypography CreateTypography();

		/// <summary>Creates an object that is used for interoperability with GDI.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteGdiInterop**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a GDI interop object if successful, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getgdiinterop HRESULT GetGdiInterop(
		// IDWriteGdiInterop **gdiInterop );
		new IDWriteGdiInterop GetGdiInterop();

		/// <summary>
		/// Takes a string, text format, and associated constraints, and produces an object that represents the fully analyzed and formatted result.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of characters in the string.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A pointer to an object that indicates the format to apply to the string.</para>
		/// </param>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the resultant text layout object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextlayout HRESULT CreateTextLayout(
		// WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT maxWidth, FLOAT maxHeight, IDWriteTextLayout
		// **textLayout );
		new IDWriteTextLayout CreateTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, float maxWidth, float maxHeight);

		/// <summary>
		/// Takes a string, format, and associated constraints, and produces an object representing the result, formatted for a particular
		/// display resolution and measuring mode.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length of the string, in character count.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>The text formatting object to apply to the string.</para>
		/// </param>
		/// <param name="layoutWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="layoutHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI device pixelsPerDipis
		/// 1. If rendering onto a 120 DPI device pixelsPerDip is 1.25 (120/96).
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specifies the font
		/// size and pixels per DIP.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Instructs the text layout to use the same metrics as GDI bi-level text when set to <c>FALSE</c>. When set to <c>TRUE</c>,
		/// instructs the text layout to use the same metrics as text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address to the pointer of the resultant text layout object.</para>
		/// </returns>
		/// <remarks>
		/// The resulting text layout should only be used for the intended resolution, and for cases where text scalability is desired
		/// CreateTextLayout should be used instead.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-creategdicompatibletextlayout HRESULT
		// CreateGdiCompatibleTextLayout( WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT layoutWidth, FLOAT
		// layoutHeight, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, IDWriteTextLayout **textLayout );
		new IDWriteTextLayout CreateGdiCompatibleTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat,
			float layoutWidth, float layoutHeight, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural);

		/// <summary>Creates an inline object for trimming, using an ellipsis as the omission sign.</summary>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A text format object, created with CreateTextFormat, used for text layout.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the omission (that is, ellipsis trimming) sign created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The ellipsis will be created using the current settings of the format, including base font, style, and any effects. Alternate
		/// omission signs can be created by the application by implementing IDWriteInlineObject.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createellipsistrimmingsign HRESULT
		// CreateEllipsisTrimmingSign( IDWriteTextFormat *textFormat, IDWriteInlineObject **trimmingSign );
		new IDWriteInlineObject CreateEllipsisTrimmingSign([In] IDWriteTextFormat textFormat);

		/// <summary>Returns an interface for performing text analysis.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTextAnalyzer**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created text analyzer object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextanalyzer HRESULT CreateTextAnalyzer(
		// IDWriteTextAnalyzer **textAnalyzer );
		new IDWriteTextAnalyzer CreateTextAnalyzer();

		/// <summary>
		/// Creates a number substitution object using a locale name, substitution method, and an indicator whether to ignore user overrides
		/// (use NLS defaults for the given culture instead).
		/// </summary>
		/// <param name="substitutionMethod">
		/// <para>Type: <c>DWRITE_NUMBER_SUBSTITUTION_METHOD</c></para>
		/// <para>A value that specifies how to apply number substitution on digits and related punctuation.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The name of the locale to be used in the numberSubstitution object.</para>
		/// </param>
		/// <param name="ignoreUserOverride">
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag that indicates whether to ignore user overrides.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteNumberSubstitution**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the number substitution object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createnumbersubstitution HRESULT
		// CreateNumberSubstitution( DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, WCHAR const *localeName, bool ignoreUserOverride,
		// IDWriteNumberSubstitution **numberSubstitution );
		new IDWriteNumberSubstitution CreateNumberSubstitution([In] DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, [MarshalAs(UnmanagedType.LPWStr)] string localeName, [In][MarshalAs(UnmanagedType.Bool)] bool ignoreUserOverride);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>A structure that contains the properties of the glyph run (font face, advances, and so on).</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI bitmap then pixelsPerDipis
		/// 1. If rendering onto a 120 DPI bitmap then pixelsPerDip is 1.25.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified the emSize
		/// and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>
		/// A value that specifies the rendering mode, which must be one of the raster rendering modes (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>Specifies the measuring mode to use with glyphs.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal position (X-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Vertical position (Y-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteGlyphRunAnalysis**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created glyph run analysis object.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The glyph run analysis object contains the results of analyzing the glyph run, including the positions of all the glyphs and
		/// references to all of the rasterized glyphs in the font cache.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to create a glyph run analysis object. In this example, an empty glyph run is being used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( DWRITE_GLYPH_RUN const *glyphRun, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, FLOAT baselineOriginX, FLOAT baselineOriginY,
		// IDWriteGlyphRunAnalysis **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, float pixelsPerDip, [In, Optional] IntPtr transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Gets a font collection representing the set of EUDC (end-user defined characters) fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>**</b></para>
		/// <para>The font collection to fill.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether to check for updates.</para>
		/// </param>
		/// <remarks>
		/// Note that if no EUDC is set on the system, the returned collection will be empty, meaning it will return success but
		/// GetFontFamilyCount will be zero.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-geteudcfontcollection HRESULT
		// GetEudcFontCollection( [out] IDWriteFontCollection **fontCollection, bool checkForUpdates );
		new void GetEudcFontCollection(out IDWriteFontCollection fontCollection, bool checkForUpdates = false);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrastGrayscale">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color components)
		/// that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams1</c>**</b></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT enhancedContrastGrayscale, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, [out] IDWriteRenderingParams1 **renderingParams );
		new IDWriteRenderingParams1 CreateCustomRenderingParams(float gamma, float enhancedContrast, float enhancedContrastGrayscale, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Creates a font fallback object from the system font fallback list.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallback</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-getsystemfontfallback HRESULT
		// GetSystemFontFallback( [out] IDWriteFontFallback **fontFallback );
		new IDWriteFontFallback GetSystemFontFallback();

		/// <summary>
		/// <para>Creates a font fallback builder object.</para>
		/// <para>
		/// A font fall back builder allows you to create Unicode font fallback mappings and create a font fall back object from those mappings.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallbackBuilder</c>**</b></para>
		/// <para>Contains an address of a pointer to the newly created font fallback builder object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createfontfallbackbuilder HRESULT
		// CreateFontFallbackBuilder( [out] IDWriteFontFallbackBuilder **fontFallbackBuilder );
		new IDWriteFontFallbackBuilder CreateFontFallbackBuilder();

		/// <summary>This method is called on a glyph run to translate it in to multiple color glyph runs.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical baseline origin of the original glyph run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Original glyph run containing monochrome glyph IDs.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN_DESCRIPTION</c>*</b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode used to compute glyph positions if the run contains color glyphs.</para>
		/// </param>
		/// <param name="worldToDeviceTransform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// World transform multiplied by any DPI scaling. This is needed to compute glyph positions if the run contains color glyphs and
		/// the measuring mode is not <c>DWRITE_MEASURING_MODE_NATURAL</c>. If this parameter is <b>NULL</b>, and identity transform is assumed.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator</c>**</b></para>
		/// <para>
		/// If the original glyph run contains color glyphs, this parameter receives a pointer to an <c>IDWriteColorGlyphRunEnumerator</c>
		/// interface. The client uses the returned interface to get information about glyph runs and associated colors to render instead of
		/// the original glyph run. If the original glyph run does not contain color glyphs, this method returns <b>DWRITE_E_NOCOLOR</b> and
		/// the output pointer is <b>NULL</b>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If the code calls this method with a glyph run that contains no color information, the method returns <b>DWRITE_E_NOCOLOR</b> to
		/// let the application know that it can just draw the original glyph run. If the glyph run contains color information, the function
		/// returns an object that can be enumerated through to expose runs and associated colors. The application then calls
		/// <c>DrawGlyphRun</c> with each of the returned glyph runs and foreground colors.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( FLOAT baselineOriginX, FLOAT baselineOriginY, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const
		// *worldToDeviceTransform, UINT32 colorPaletteIndex, [out] IDWriteColorGlyphRunEnumerator **colorLayers );
		new IDWriteColorGlyphRunEnumerator TranslateColorGlyphRun(float baselineOriginX, float baselineOriginY, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldToDeviceTransform, uint colorPaletteIndex);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>The geometry of a device pixel.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>
		/// Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// How to grid fit glyph outlines. In most cases, this should be DWRITE_GRID_FIT_DEFAULT to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams2</c>**</b></para>
		/// <para>Holds the newly created rendering parameters object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams2 **renderingParams );
		new IDWriteRenderingParams2 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Structure specifying the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// emSize and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b>DWRITE_RENDERING_MODE</b></para>
		/// <para>Specifies the rendering mode, which must be one of the raster rendering modes (i.e., not default and not outline).</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Specifies the method to measure glyphs.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>How to grid-fit glyph outlines. This must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>Specifies the antialias mode.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Horizontal position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Vertical position of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>Receives a pointer to the newly created object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefactory2-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode, DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
			float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a glyph-run-analysis object that encapsulates info that <c>DirectWrite</c> uses to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>A <c>DWRITE_GLYPH_RUN</c> structure that contains the properties of the glyph run.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the optional transform to be applied to glyphs and their positions.</para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the rendering mode, which must be one of the raster rendering modes
		/// (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the measuring method for glyphs in the run. This method uses this
		/// value with the other properties to determine the rendering mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. This value must be non-default.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the type of antialiasing to use for text when the rendering mode
		/// calls for antialiasing.
		/// </para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The horizontal position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The vertical position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteGlyphRunAnalysis</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteGlyphRunAnalysis</c> interface for the newly created
		/// glyph-run-analysis object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional] DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
		// DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, FLOAT baselineOriginX, FLOAT baselineOriginY, [out] IDWriteGlyphRunAnalysis
		// **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE1 renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode,
			DWRITE_TEXT_ANTIALIAS_MODE antialiasMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma value used for gamma correction, which must be greater than zero and cannot exceed 256.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement, zero or greater.</para>
		/// </param>
		/// <param name="grayscaleEnhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// A <c>DWRITE_PIXEL_GEOMETRY</c>-typed value that specifies the internal structure of a device pixel (that is, the physical
		/// arrangement of red, green, and blue color components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>
		/// A <c>DWRITE_RENDERING_MODE1</c>-typed value that specifies the method (for example, ClearType natural quality) for rendering
		/// glyphs. In most cases, specify <b>DWRITE_RENDERING_MODE1_DEFAULT</b> to automatically use an appropriate mode.
		/// </para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_GRID_FIT_MODE</c>-typed value that specifies how to grid-fit glyph outlines. In most cases, specify
		/// <b>DWRITE_GRID_FIT_DEFAULT</b> to automatically choose an appropriate mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams3</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteRenderingParams3</c> interface for the newly created
		/// rendering parameters object, or <b>NULL</b> in case of failure.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT grayscaleEnhancedContrast, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode, [out]
		// IDWriteRenderingParams3 **renderingParams );
		new IDWriteRenderingParams3 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
			DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE1 renderingMode, DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Creates a reference to a font given a full path.</summary>
		/// <param name="filePath">
		/// <para>Type: [in] <b>WCHAR</b></para>
		/// <para>
		/// Absolute file path. Subsequent operations on the constructed object may fail if the user provided filePath doesn't correspond to
		/// a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: [in, optional] <b>FILETIME</b></para>
		/// <para>
		/// Last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time, so the clients are encouraged to specify this value to avoid extra disk access. Subsequent operations on the
		/// constructed object may fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(wcharconst_filetimeconst_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( WCHAR const *filePath, FILETIME const *lastWriteTime, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS
		// fontSimulations, IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference CreateFontFaceReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] PFILETIME? lastWriteTime,
			uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Creates a reference to a font given an <b>IDWriteFontFile</b>.</summary>
		/// <param name="fontFile">An <b>IDWriteFontFile</b> representing the font face.</param>
		/// <param name="faceIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// The zero based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Contains newly created font face reference object, or nullptr in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontfacereference(idwritefontfile_uint32_dwrite_font_simulations_idwritefontfacereference)
		// HRESULT CreateFontFaceReference( IDWriteFontFile *fontFile, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations, [out]
		// IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference CreateFontFaceReference([In] IDWriteFontFile fontFile, uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations);

		/// <summary>Retrieves the list of system fonts.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Holds the newly created font set object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontset HRESULT
		// GetSystemFontSet( [out] IDWriteFontSet **fontSet );
		new IDWriteFontSet GetSystemFontSet();

		/// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder</c>**</b></para>
		/// <para>Holds the newly created font set builder object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( [out] IDWriteFontSetBuilder **fontSetBuilder );
		new IDWriteFontSetBuilder CreateFontSetBuilder();

		/// <summary>Create a weight/width/slope tree from a set of fonts.</summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>A set of fonts to use to build the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-createfontcollectionfromfontset HRESULT
		// CreateFontCollectionFromFontSet( IDWriteFontSet *fontSet, [out] IDWriteFontCollection1 **fontCollection );
		new IDWriteFontCollection1 CreateFontCollectionFromFontSet(IDWriteFontSet fontSet);

		/// <summary>Retrieves a weight/width/slope tree of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// <para>Type: <b>bool</b></para>
		/// <para>Indicates whether to include cloud fonts or only locally installed fonts.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection1</c>**</b></para>
		/// <para>Holds the newly created font collection object, or NULL in case of failure.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// If this parameter is TRUE, the function performs an immediate check for changes to the set of system fonts. If this parameter is
		/// FALSE, the function will still detect changes if the font cache service is running, but there may be some latency. For example,
		/// an application might specify TRUE if it has just installed a font and wants to be sure the font collection contains that font.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getsystemfontcollection HRESULT
		// GetSystemFontCollection( bool includeDownloadableFonts, IDWriteFontCollection1 **fontCollection, bool checkForUpdates );
		new void GetSystemFontCollection(bool includeDownloadableFonts, out IDWriteFontCollection1 fontCollection, bool checkForUpdates = false);

		/// <summary>Gets the font download queue associated with this factory object.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontDownloadQueue</c>**</b></para>
		/// <para>Receives a pointer to the font download queue interface.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory3-getfontdownloadqueue HRESULT
		// GetFontDownloadQueue( [out] IDWriteFontDownloadQueue **fontDownloadQueue );
		new IDWriteFontDownloadQueue GetFontDownloadQueue();

		/// <summary>
		/// Translates a glyph run to a sequence of color glyph runs, which can be rendered to produce a color representation of the
		/// original "base" run.
		/// </summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>Horizontal and vertical origin of the base glyph run in pre-transform coordinates.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Pointer to the original "base" glyph run.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN_DESCRIPTION</c></b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="desiredGlyphImageFormats">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Which data formats the runs should be split into.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>Measuring mode, needed to compute the origins of each glyph.</para>
		/// </param>
		/// <param name="worldAndDpiTransform">
		/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
		/// <para>
		/// Matrix converting from the client's coordinate space to device coordinates (pixels), i.e., the world transform multiplied by any
		/// DPI scaling.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <param name="colorLayers">
		/// <para>Type: <b><c>IDWriteColorGlyphRunEnumerator1</c>**</b></para>
		/// <para>
		/// If the function succeeds, receives a pointer to an enumerator object that can be used to obtain the color glyph runs. If the
		/// base run has no color glyphs, then the output pointer is NULL and the method returns DWRITE_E_NOCOLOR.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns DWRITE_E_NOCOLOR if the font has no color information, the glyph run does not contain any color glyphs, or the specified
		/// color palette index is out of range. In this case, the client should render the original glyph run. Otherwise, returns a
		/// standard HRESULT error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Calling <c>IDWriteFactory2::TranslateColorGlyphRun</c> is equivalent to calling <b>IDWriteFactory4::TranslateColorGlyph</b> run
		/// with the following formats specified: DWRITE_GLYPH_IMAGE_FORMATS_TRUETYPE|DWRITE_GLYPH_IMAGE_FORMATS_CFF|DWRITE_GLYPH_IMAGE_FORMATS_COLR.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-translatecolorglyphrun HRESULT
		// TranslateColorGlyphRun( D2D1_POINT_2F baselineOrigin, [in] DWRITE_GLYPH_RUN const *glyphRun, [in, optional]
		// DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
		// DWRITE_MEASURING_MODE measuringMode, [in, optional] DWRITE_MATRIX const *worldAndDpiTransform, UINT32 colorPaletteIndex, [out]
		// IDWriteColorGlyphRunEnumerator1 **colorLayers );
		[PreserveSig]
		new HRESULT TranslateColorGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
			DWRITE_MEASURING_MODE measuringMode, [In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform, uint colorPaletteIndex,
			out IDWriteColorGlyphRunEnumerator1 colorLayers);

		/// <summary>Converts glyph run placements to glyph origins.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="glyphOrigins">
		/// <para>Type: [out] <b><c>D2D1_POINT_2F</c>*</b></para>
		/// <para>On return contains the glyph origins for the glyphrun.</para>
		/// </param>
		/// <remarks>
		/// The transform and DPI have no effect on the origin scaling. They are solely used to compute glyph advances when not supplied and
		/// align glyphs in pixel aligned measuring modes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-computeglyphorigins(dwrite_glyph_runconst_d2d1_point_2f_d2d1_point_2f)
		// HRESULT ComputeGlyphOrigins( DWRITE_GLYPH_RUN const *glyphRun, D2D1_POINT_2F baselineOrigin, D2D1_POINT_2F *glyphOrigins );
		new void ComputeGlyphOrigins(in DWRITE_GLYPH_RUN glyphRun, D2D_POINT_2F baselineOrigin,
			[Out, MarshalAs(UnmanagedType.LPArray)] D2D_POINT_2F[] glyphOrigins);

		/// <summary>Converts glyph run placements to glyph origins.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <b><c>DWRITE_GLYPH_RUN</c></b></para>
		/// <para>Structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="measuringMode"/>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="worldAndDpiTransform"/>
		/// <param name="glyphOrigins">
		/// <para>Type: [out] <b><c>D2D1_POINT_2F</c>*</b></para>
		/// <para>On return contains the glyph origins for the glyphrun.</para>
		/// </param>
		/// <remarks>
		/// The transform and DPI have no effect on the origin scaling. They are solely used to compute glyph advances when not supplied and
		/// align glyphs in pixel aligned measuring modes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory4-computeglyphorigins(dwrite_glyph_runconst_dwrite_measuring_mode_d2d1_point_2f_dwrite_matrixconst_d2d1_point_2f)
		// HRESULT ComputeGlyphOrigins( DWRITE_GLYPH_RUN const *glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D1_POINT_2F baselineOrigin,
		// DWRITE_MATRIX const *worldAndDpiTransform, D2D1_POINT_2F *glyphOrigins );
		new void ComputeGlyphOrigins(in DWRITE_GLYPH_RUN glyphRun, DWRITE_MEASURING_MODE measuringMode, D2D_POINT_2F baselineOrigin,
			[In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform, [Out, MarshalAs(UnmanagedType.LPArray)] D2D_POINT_2F[] glyphOrigins);

		/// <summary>Creates an empty font set builder to add font face references and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder1</c>**</b></para>
		/// <para>Holds the newly created font set builder object, or NULL in case of failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( [out] IDWriteFontSetBuilder1 **fontSetBuilder );
		new IDWriteFontSetBuilder1 CreateFontSetBuilder1();

		/// <summary>
		/// Creates a loader object that can be used to create font file references to in-memory fonts. The caller is responsible for
		/// registering and unregistering the loader.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteInMemoryFontFileLoader</c>**</b></para>
		/// <para>Receives a pointer to the newly-created loader object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createinmemoryfontfileloader HRESULT
		// CreateInMemoryFontFileLoader( [out] IDWriteInMemoryFontFileLoader **newLoader );
		new IDWriteInMemoryFontFileLoader CreateInMemoryFontFileLoader();

		/// <summary>
		/// Creates a remote font file loader that can create font file references from HTTP or HTTPS URLs. The caller is responsible for
		/// registering and unregistering the loader.
		/// </summary>
		/// <param name="referrerUrl">
		/// <para>Type: <b>wchar_t const*</b></para>
		/// <para>Optional referrer URL for HTTP requests.</para>
		/// </param>
		/// <param name="extraHeaders">
		/// <para>Type: <b>wchar_t const*</b></para>
		/// <para>
		/// Optional additional header fields to include in HTTP requests. Each header field consists of a name followed by a colon (":")
		/// and the field value, as specified by RFC 2616. Multiple header fields may be separated by newlines.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRemoteFontFileLoader</c>**</b></para>
		/// <para>Receives a pointer to the newly-created loader object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-createhttpfontfileloader HRESULT
		// CreateHttpFontFileLoader( wchar_t const *referrerUrl, wchar_t const *extraHeaders, [out] IDWriteRemoteFontFileLoader **newLoader );
		new IDWriteRemoteFontFileLoader CreateHttpFontFileLoader([Optional, MarshalAs(UnmanagedType.LPWStr)] string? referrerUrl, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? extraHeaders);

		/// <summary>
		/// The AnalyzeContainerType method analyzes the specified file data to determine whether it is a known font container format (e.g.,
		/// WOFF or WOFF2).
		/// </summary>
		/// <param name="fileData">
		/// <para>Type: <b>void</b></para>
		/// <para>Pointer to the file data to analyze.</para>
		/// </param>
		/// <param name="fileDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the buffer passed in fileData.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_CONTAINER_TYPE</c></b></para>
		/// <para>
		/// Returns the container type if recognized. DWRITE_CONTAINER_TYPE_UNKOWNN is returned for all other files, including uncompressed
		/// font files.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-analyzecontainertype
		// DWRITE_CONTAINER_TYPE AnalyzeContainerType( [in] void const *fileData, UINT32 fileDataSize );
		[PreserveSig]
		new DWRITE_CONTAINER_TYPE AnalyzeContainerType([In] IntPtr fileData, uint fileDataSize);

		/// <summary>
		/// The UnpackFontFile method unpacks font data from a container file (WOFF or WOFF2) and returns the unpacked font data in the form
		/// of a font file stream.
		/// </summary>
		/// <param name="containerType">
		/// <para>Type: <b><c>DWRITE_CONTAINER_TYPE</c></b></para>
		/// <para>Container type returned by AnalyzeContainerType.</para>
		/// </param>
		/// <param name="fileData">
		/// <para>Type: <b>void</b></para>
		/// <para>Pointer to the compressed data.</para>
		/// </param>
		/// <param name="fileDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the compressed data, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFileStream</c>**</b></para>
		/// <para>Receives a pointer to a newly created font file stream containing the uncompressed data.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory5-unpackfontfile HRESULT UnpackFontFile(
		// DWRITE_CONTAINER_TYPE containerType, [in] void const *fileData, UINT32 fileDataSize, [out] IDWriteFontFileStream
		// **unpackedFontStream );
		new IDWriteFontFileStream UnpackFontFile(DWRITE_CONTAINER_TYPE containerType, [In] IntPtr fileData, uint fileDataSize);

		/// <summary>Creates a reference to a specific font instance within a file.</summary>
		/// <param name="fontFile">
		/// <para>Type: <b><c>IDWriteFontFile</c>*</b></para>
		/// <para>A user-provided font file representing the font face.</para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font file contains a collection of font faces. If the font file contains a
		/// single face, then set this value to zero.
		/// </para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFaceReference1</c> interface. On successful completion, the function sets the
		/// pointer to a newly created font face reference object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontfacereference HRESULT
		// CreateFontFaceReference( IDWriteFontFile *fontFile, UINT32 faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations,
		// DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount, [out] IDWriteFontFaceReference1 **fontFaceReference );
		new IDWriteFontFaceReference1 CreateFontFaceReference([In] IDWriteFontFile fontFile, uint faceIndex, DWRITE_FONT_SIMULATIONS fontSimulations,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Creates a font resource, given a font file and a face index.</summary>
		/// <param name="fontFile">
		/// <para>Type: <b><c>IDWriteFontFile</c>*</b></para>
		/// <para>A user-provided font file representing the font face.</para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font file contains a collection of font faces. If the font file contains a
		/// single face, then set this value to zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontResource</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontResource</c> interface. On successful completion, the function sets the pointer to
		/// a newly created font resource object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontresource HRESULT
		// CreateFontResource( IDWriteFontFile *fontFile, UINT32 faceIndex, IDWriteFontResource **fontResource );
		new IDWriteFontResource CreateFontResource([In] IDWriteFontFile fontFile, uint faceIndex);

		/// <summary>Retrieves the set of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// Type: <b><c>BOOL</c></b>
		/// <para><see langword="true"/> if you want to include downloadable fonts. <c>false</c> if you only want locally installed fonts.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to the
		/// font set object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-getsystemfontset HRESULT
		// GetSystemFontSet( BOOL includeDownloadableFonts, IDWriteFontSet1 **fontSet );
		new IDWriteFontSet1 GetSystemFontSet(bool includeDownloadableFonts);

		/// <summary>Retrieves a collection of fonts, grouped into families.</summary>
		/// <param name="includeDownloadableFonts">
		/// Type: <b><c>BOOL</c></b>
		/// <para><see langword="true"/> if you want to include downloadable fonts. <c>false</c> if you only want locally installed fonts.</para>
		/// </param>
		/// <param name="fontFamilyModel">
		/// <para>Type: <b><c>DWRITE_FONT_FAMILY_MODEL</c></b></para>
		/// <para>How to group families in the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontCollection2</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font collection object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-getsystemfontcollection HRESULT
		// GetSystemFontCollection( BOOL includeDownloadableFonts, DWRITE_FONT_FAMILY_MODEL fontFamilyModel, [out] IDWriteFontCollection2
		// **fontCollection );
		new IDWriteFontCollection2 GetSystemFontCollection(bool includeDownloadableFonts, DWRITE_FONT_FAMILY_MODEL fontFamilyModel);

		/// <summary>From a font set, create a collection of fonts grouped into families.</summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>A set of fonts to use to build the collection.</para>
		/// </param>
		/// <param name="fontFamilyModel">
		/// <para>Type: <b><c>DWRITE_FONT_FAMILY_MODEL</c></b></para>
		/// <para>How to group families in the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontCollection2</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font collection object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontcollectionfromfontset HRESULT
		// CreateFontCollectionFromFontSet( IDWriteFontSet *fontSet, DWRITE_FONT_FAMILY_MODEL fontFamilyModel, [out] IDWriteFontCollection2
		// **fontCollection );
		new IDWriteFontCollection2 CreateFontCollectionFromFontSet([In] IDWriteFontSet fontSet, DWRITE_FONT_FAMILY_MODEL fontFamilyModel);

		/// <summary>Creates an empty font set builder, ready to add font instances to, and create a custom font set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSetBuilder2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSetBuilder2</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font set builder object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createfontsetbuilder HRESULT
		// CreateFontSetBuilder( IDWriteFontSetBuilder2 **fontSetBuilder );
		new IDWriteFontSetBuilder2 CreateFontSetBuilder2();

		/// <summary>Creates a text format object used for text layout.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>Name of the font family from the collection.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>*</b></para>
		/// <para>Font collection. Use <see langword="null"/> to indicate the system font collection.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>Logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>Locale name (for example, "ja-JP", "en-US", "ar-EG").</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteTextFormat3</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteTextFormat3</c> interface. On successful completion, the function sets the pointer to a
		/// newly created text format object, otherwise it sets the pointer to <see langword="null"/>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If fontCollection is <see langword="null"/>, then the system font collection is used, grouped by typographic family name (
		/// <c>DWRITE_FONT_FAMILY_MODEL_TYPOGRAPHIC</c>) without downloadable fonts.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory6-createtextformat HRESULT
		// CreateTextFormat( WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_AXIS_VALUE const
		// *fontAxisValues, UINT32 fontAxisValueCount, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat3 **textFormat );
		new IDWriteTextFormat3 CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount,
			float fontSize, [MarshalAs(UnmanagedType.LPWStr)] string localeName);

		/// <summary>Retrieves the set of system fonts.</summary>
		/// <param name="includeDownloadableFonts">
		/// Type: <b><c>BOOL</c></b>
		/// <para><see langword="true"/> if you want to include downloadable fonts. <c>false</c> if you only want locally installed fonts.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet2</c> interface. On successful completion, the function sets the pointer to the
		/// font set object, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory7-getsystemfontset HRESULT
		// GetSystemFontSet( BOOL includeDownloadableFonts, IDWriteFontSet2 **fontSet );
		new IDWriteFontSet2 GetSystemFontSet2(bool includeDownloadableFonts);

		/// <summary>Retrieves a collection of fonts, grouped into families.</summary>
		/// <param name="includeDownloadableFonts">
		/// Type: <b><c>BOOL</c></b>
		/// <para><see langword="true"/> if you want to include downloadable fonts. <c>false</c> if you only want locally installed fonts.</para>
		/// </param>
		/// <param name="fontFamilyModel">
		/// <para>Type: <b><c>DWRITE_FONT_FAMILY_MODEL</c></b></para>
		/// <para>How to group families in the collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontCollection3</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontCollection3</c> interface. On successful completion, the function sets the pointer
		/// to a newly created font collection object, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefactory7-getsystemfontcollection HRESULT
		// GetSystemFontCollection( BOOL includeDownloadableFonts, DWRITE_FONT_FAMILY_MODEL fontFamilyModel, [out] IDWriteFontCollection3
		// **fontCollection );
		new IDWriteFontCollection3 GetSystemFontCollection3(bool includeDownloadableFonts, DWRITE_FONT_FAMILY_MODEL fontFamilyModel);

		/// <summary>
		/// Translates a glyph run to a sequence of color glyph runs, which can be rendered to produce a color representation of the
		/// original "base" run. Adds a new paintFeatureLevel parameter, but is otherwise identical to <c>IDWriteFactory4::TranslateColorGlyphRun</c>.
		/// </summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>Horizontal and vertical origin of the base glyph run in pre-transform coordinates.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: _In_ <b><c>DWRITE_GLYPH_RUN</c> const*</b></para>
		/// <para>Pointer to the original "base" glyph run.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: _In_opt_ <b><c>DWRITE_GLYPH_RUN_DESCRIPTION</c> const*</b></para>
		/// <para>Optional glyph run description.</para>
		/// </param>
		/// <param name="desiredGlyphImageFormats">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>The data formats that the method should split the runs into.</para>
		/// </param>
		/// <param name="paintFeatureLevel">
		/// <para>Type: <b><c>DWRITE_PAINT_FEATURE_LEVEL</c></b></para>
		/// <para>
		/// The paint feature level supported by the caller. Used when desiredGlyphImageFormats includes
		/// <b>DWRITE_GLYPH_IMAGE_FORMATS_COLR_PAINT_TREE</b>. For more info, see <c>DWRITE_PAINT_FEATURE_LEVEL</c>.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>The measuring mode, which is needed to compute the origins of each glyph.</para>
		/// </param>
		/// <param name="worldAndDpiTransform">
		/// <para>Type: _In_opt_ <b><c>DWRITE_MATRIX</c> const*</b></para>
		/// <para>
		/// Matrix converting from the client's coordinate space to device coordinates (pixels)—that is, the world transform multiplied by
		/// any DPI scaling.
		/// </para>
		/// </param>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>
		/// Zero-based index of the color palette to use. Valid indices are less than the number of palettes in the font, as returned by <c>IDWriteFontFace2::GetColorPaletteCount</c>.
		/// </para>
		/// </param>
		/// <param name="colorEnumerator">
		/// <para>Type: _COM_Outptr_ <b><c>IDWriteColorGlyphRunEnumerator1</c> **</b></para>
		/// <para>
		/// If the function succeeds, receives a pointer to an enumerator object that can be used to obtain the color glyph runs. If the
		/// base run has no color glyphs, then the output pointer is NULL, and the method returns <b>DWRITE_E_NOCOLOR</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// Returns <b>DWRITE_E_NOCOLOR</b> if the font has no color information, or if the glyph run doesn't contain any color glyphs, or
		/// if the specified color palette index is out of range. In those cases, the client should render the original glyph run.
		/// Otherwise, returns a standard HRESULT error code.
		/// </returns>
		/// <remarks>
		/// Calling <c>IDWriteFactory2::TranslateColorGlyphRun</c> is equivalent to calling <b>IDWriteFactory2::TranslateColorGlyphRun</b>,
		/// and passing <b>DWRITE_GLYPH_IMAGE_FORMATS_TRUETYPE</b>| <b>CFF</b>| <b>COLR</b> in desiredGlyphImageFormats.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefactory8-translatecolorglyphrun
		// HRESULT TranslateColorGlyphRun( D2D1_POINT_2F baselineOrigin, DWRITE_GLYPH_RUN const *glyphRun, DWRITE_GLYPH_RUN_DESCRIPTION
		// const *glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats, DWRITE_PAINT_FEATURE_LEVEL paintFeatureLevel,
		// DWRITE_MEASURING_MODE measuringMode, DWRITE_MATRIX const *worldAndDpiTransform, UINT32 colorPaletteIndex,
		// IDWriteColorGlyphRunEnumerator1 **colorEnumerator );
		[PreserveSig]
		HRESULT TranslateColorGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun,
			[In, Optional] StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription, DWRITE_GLYPH_IMAGE_FORMATS desiredGlyphImageFormats,
			DWRITE_PAINT_FEATURE_LEVEL paintFeatureLevel, DWRITE_MEASURING_MODE measuringMode, [In, Optional] StructPointer<DWRITE_MATRIX> worldAndDpiTransform,
			uint colorPaletteIndex, out IDWriteColorGlyphRunEnumerator1 colorEnumerator);
	}

	/// <summary>Represents a font in a font collection.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefont3
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFont3")]
	[ComImport, Guid("29748ED6-8C9C-4A6A-BE0B-D912E8538944"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFont3 : IDWriteFont, IDWriteFont1, IDWriteFont2
	{
		/// <summary>Gets the font family to which the specified font belongs.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFamily**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the font family object to which the specified font belongs.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getfontfamily HRESULT GetFontFamily(
		// IDWriteFontFamily **fontFamily );
		new IDWriteFontFamily GetFontFamily();

		/// <summary>Gets the weight, or stroke thickness, of the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the weight for the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getweight DWRITE_FONT_WEIGHT GetWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetWeight();

		/// <summary>Gets the stretch, or width, of the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that indicates the type of stretch, or width, applied to the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getstretch DWRITE_FONT_STRETCH GetStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetStretch();

		/// <summary>Gets the style, or slope, of the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that indicates the type of style, or slope, of the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getstyle DWRITE_FONT_STYLE GetStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetStyle();

		/// <summary>Determines whether the font is a symbol font.</summary>
		/// <returns>
		/// <para>Type: <c>bool</c></para>
		/// <para><c>TRUE</c> if the font is a symbol font; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-issymbolfont bool IsSymbolFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsSymbolFont();

		/// <summary>
		/// Gets a localized strings collection containing the face names for the font (such as Regular or Bold), indexed by locale name.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDWriteLocalizedStrings**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the newly created localized strings object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getfacenames HRESULT GetFaceNames(
		// IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFaceNames();

		/// <summary>Gets a localized strings collection containing the specified informational strings, indexed by locale name.</summary>
		/// <param name="informationalStringID">
		/// <para>Type: <c>DWRITE_INFORMATIONAL_STRING_ID</c></para>
		/// <para>
		/// A value that identifies the informational string to get. For example, DWRITE_INFORMATIONAL_STRING_DESCRIPTION specifies a string
		/// that contains a description of the font.
		/// </para>
		/// </param>
		/// <param name="informationalStrings">
		/// <para>Type: <c>IDWriteLocalizedStrings**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created localized strings object.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>bool*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font contains the specified string ID; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <remarks>
		/// If the font does not contain the string specified by informationalStringID, the return value is <c>S_OK</c> but
		/// informationalStrings receives a <c>NULL</c> pointer and exists receives the value <c>FALSE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getinformationalstrings HRESULT
		// GetInformationalStrings( DWRITE_INFORMATIONAL_STRING_ID informationalStringID, IDWriteLocalizedStrings
		// **informationalStrings, bool *exists );
		new void GetInformationalStrings(DWRITE_INFORMATIONAL_STRING_ID informationalStringID, out IDWriteLocalizedStrings informationalStrings, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Gets a value that indicates what simulations are applied to the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>A value that indicates one or more of the types of simulations (none, bold, or oblique) applied to the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getsimulations DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		new DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontMetrics">
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a structure that has font metrics for the current font face. The metrics returned by this
		/// function are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getmetrics void GetMetrics( DWRITE_FONT_METRICS
		// *fontMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS fontMetrics);

		/// <summary>Determines whether the font supports a specified character.</summary>
		/// <param name="unicodeValue">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>A Unicode (UCS-4) character value for the method to inspect.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>When this method returns, <b>TRUE</b> if the font supports the specified character; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-hascharacter HRESULT HasCharacter( UINT32
		// unicodeValue, [out] BOOL *exists );
		[PreserveSig]
		new HRESULT HasCharacter(uint unicodeValue, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Creates a font face object for the font.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created font face object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-createfontface HRESULT CreateFontFace(
		// IDWriteFontFace **fontFace );
		new IDWriteFontFace CreateFontFace();

		/// <summary><c>fontMetrics</c></summary>
		/// <param name="fontMetrics"/>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_1/nf-dwrite_1-idwritefont1-getmetrics void GetMetrics(
		// DWRITE_FONT_METRICS1 *fontMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS1 fontMetrics);

		/// <summary>Gets the PANOSE values from the font and is used for font selection and matching.</summary>
		/// <param name="panose">
		/// <para>Type: <b><c>DWRITE_PANOSE</c>*</b></para>
		/// <para>A pointer to the <c>DWRITE_PANOSE</c> structure to fill in.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the font has no PANOSE values, they are set to 'any' (0) and <c>DirectWrite</c> doesn't simulate those values.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefont1-getpanose void GetPanose( [out]
		// DWRITE_PANOSE *panose );
		[PreserveSig]
		new void GetPanose(out DWRITE_PANOSE panose);

		/// <summary>Retrieves the list of character ranges supported by a font.</summary>
		/// <param name="maxRangeCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The maximum number of character ranges passed in from the client.</para>
		/// </param>
		/// <param name="unicodeRanges">
		/// <para>Type: <b><c>DWRITE_UNICODE_RANGE</c>*</b></para>
		/// <para>An array of <c>DWRITE_UNICODE_RANGE</c> structures that are filled with the character ranges.</para>
		/// </param>
		/// <param name="actualRangeCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>A pointer to the actual number of character ranges, regardless of the maximum count.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>The method executed successfully.</description>
		/// </item>
		/// <item>
		/// <description>E_NOT_SUFFICIENT_BUFFER</description>
		/// <description>The buffer is too small. The <i>actualRangeCount</i> was more than the <i>maxRangeCount</i>.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The list of character ranges supported by a font, is useful for scenarios like character picking, glyph display, and efficient
		/// font selection lookup. GetUnicodeRanges is similar to GDI's GetFontUnicodeRanges, except that it returns the full Unicode range,
		/// not just 16-bit UCS-2.
		/// </para>
		/// <para>These ranges are from the cmap, not the OS/2::ulCodePageRange1.</para>
		/// <para>
		/// If this method is unavailable, you can use the <c>IDWriteFontFace::GetGlyphIndices</c> method to check for missing glyphs. The
		/// method returns the 0 index for glyphs that aren't present in the font.
		/// </para>
		/// <para>
		/// The <c>IDWriteFont::HasCharacter</c> method is often simpler in cases where you need to check a single character or a series of
		/// single characters in succession, such as in font fallback.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefont1-getunicoderanges HRESULT GetUnicodeRanges(
		// UINT32 maxRangeCount, [out, optional] DWRITE_UNICODE_RANGE *unicodeRanges, [out] UINT32 *actualRangeCount );
		new void GetUnicodeRanges(int maxRangeCount, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DWRITE_UNICODE_RANGE[]? unicodeRanges,
			out uint actualRangeCount);

		/// <summary>Determines if the font is monospaced, that is, the characters are the same fixed-pitch width (non-proportional).</summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns true if the font is monospaced, else it returns false.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefont1-ismonospacedfont bool IsMonospacedFont();
		[PreserveSig]
		new bool IsMonospacedFont();

		/// <summary>Enables determining whether a color rendering path is potentially necessary.</summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns <b>TRUE</b> if the font has color information (COLR and CPAL tables); otherwise <b>FALSE</b>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefont2-iscolorfont bool IsColorFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsColorFont();

		/// <summary>Creates a font face object for the font.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace3</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFace3</c> interface for the newly created font face object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// <para>This method returns <b>DWRITE_E_REMOTEFONT</b> if it could not construct a remote font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefont3-createfontface HRESULT CreateFontFace(
		// [out] IDWriteFontFace3 **fontFace );
		[PreserveSig]
		HRESULT CreateFontFace(out IDWriteFontFace3 fontFace);

		/// <summary>Compares two instances of font references for equality.</summary>
		/// <param name="font">
		/// <para>Type: <b><c>IDWriteFont</c>*</b></para>
		/// <para>A pointer to a <c>IDWriteFont</c> interface for the other font instance to compare to this font instance.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// Returns whether the two instances of font references are equal. Returns <b>TRUE</b> if the two instances are equal; otherwise, <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefont3-equals BOOL Equals( [in] IDWriteFont *font );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool Equals(IDWriteFont font);

		/// <summary>Gets a font face reference that identifies this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFaceReference</c> interface for the newly created font
		/// face reference object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefont3-getfontfacereference HRESULT
		// GetFontFaceReference( [out] IDWriteFontFaceReference **fontFaceReference );
		IDWriteFontFaceReference GetFontFaceReference();

		/// <summary><c>unicodeValue</c></summary>
		/// <param name="unicodeValue"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefont3-hascharacter BOOL
		// HasCharacter( UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool HasCharacter(uint unicodeValue);

		/// <summary/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefont3-getlocality DWRITE_LOCALITY GetLocality();
		[PreserveSig]
		DWRITE_LOCALITY GetLocality();
	}

	/// <summary>
	/// An object that encapsulates a set of fonts, such as the set of fonts installed on the system, or the set of fonts in a particular
	/// directory. The font collection API can be used to discover what font families and fonts are available, and to obtain some metadata
	/// about the fonts.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontcollection1
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontCollection1")]
	[ComImport, Guid("53585141-D9F8-4095-8321-D73CF6BD116C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontCollection1 : IDWriteFontCollection
	{
		/// <summary>Gets the number of font families in the collection.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font families in the collection.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfamilycount UINT32 GetFontFamilyCount();
		[PreserveSig]
		new uint GetFontFamilyCount();

		/// <summary>Creates a font family object given a zero-based font family index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font family.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFamily**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created font family object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfamily HRESULT GetFontFamily(
		// UINT32 index, IDWriteFontFamily **fontFamily );
		new IDWriteFontFamily GetFontFamily(uint index);

		/// <summary>Finds the font family with the specified family name.</summary>
		/// <param name="familyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters, which is null-terminated, containing the name of the font family. The name is not case-sensitive but
		/// must otherwise exactly match a family name in the collection.
		/// </para>
		/// </param>
		/// <param name="index">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// When this method returns, contains the zero-based index of the matching font family if the family name was found; otherwise, <c>UINT_MAX</c>.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the family name exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-findfamilyname HRESULT FindFamilyName(
		// WCHAR const *familyName, UINT32 *index, BOOL *exists );
		new void FindFamilyName([MarshalAs(UnmanagedType.LPWStr)] string familyName, out uint index, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>
		/// Gets the font object that corresponds to the same physical font as the specified font face object. The specified physical font
		/// must belong to the font collection.
		/// </summary>
		/// <param name="fontFace">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>A font face object that specifies the physical font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the newly created font object if successful; otherwise, <c>NULL</c>.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfromfontface HRESULT
		// GetFontFromFontFace( IDWriteFontFace *fontFace, IDWriteFont **font );
		new IDWriteFont GetFontFromFontFace([In] IDWriteFontFace fontFace);

		/// <summary>Gets the underlying font set used by this collection.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Returns the font set used by the collection.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection1-getfontset HRESULT GetFontSet(
		// [out] IDWriteFontSet **fontSet );
		IDWriteFontSet GetFontSet();

		/// <summary>Creates a font family object given a zero-based font family index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font family.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFamily1**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created font family object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontcollection1-getfontfamily
		// HRESULT GetFontFamily( UINT32 index, IDWriteFontFamily1 **fontFamily );
		IDWriteFontFamily1 GetFontFamily1(uint index);
	}

	/// <summary>
	/// <para>
	/// This interface encapsulates a set of fonts, such as the set of fonts installed on the system, or the set of fonts in a particular
	/// directory. The font collection API can be used to discover what font families and fonts are available, and to obtain some metadata
	/// about the fonts. <b>IDWriteFontCollection2</b> adds new facilities, including support for <c>IDWriteFontSet1</c>.
	/// </para>
	/// <para>This interface extends <c>IDWriteFontCollection1</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontcollection2
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontCollection2")]
	[ComImport, Guid("514039C6-4617-4064-BF8B-92EA83E506E0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontCollection2 : IDWriteFontCollection, IDWriteFontCollection1
	{
		/// <summary>Gets the number of font families in the collection.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font families in the collection.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfamilycount UINT32 GetFontFamilyCount();
		[PreserveSig]
		new uint GetFontFamilyCount();

		/// <summary>Creates a font family object given a zero-based font family index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font family.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFamily**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created font family object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfamily HRESULT GetFontFamily(
		// UINT32 index, IDWriteFontFamily **fontFamily );
		new IDWriteFontFamily GetFontFamily(uint index);

		/// <summary>Finds the font family with the specified family name.</summary>
		/// <param name="familyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters, which is null-terminated, containing the name of the font family. The name is not case-sensitive but
		/// must otherwise exactly match a family name in the collection.
		/// </para>
		/// </param>
		/// <param name="index">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// When this method returns, contains the zero-based index of the matching font family if the family name was found; otherwise, <c>UINT_MAX</c>.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the family name exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-findfamilyname HRESULT FindFamilyName(
		// WCHAR const *familyName, UINT32 *index, BOOL *exists );
		new void FindFamilyName([MarshalAs(UnmanagedType.LPWStr)] string familyName, out uint index, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>
		/// Gets the font object that corresponds to the same physical font as the specified font face object. The specified physical font
		/// must belong to the font collection.
		/// </summary>
		/// <param name="fontFace">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>A font face object that specifies the physical font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the newly created font object if successful; otherwise, <c>NULL</c>.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfromfontface HRESULT
		// GetFontFromFontFace( IDWriteFontFace *fontFace, IDWriteFont **font );
		new IDWriteFont GetFontFromFontFace([In] IDWriteFontFace fontFace);

		/// <summary>Gets the underlying font set used by this collection.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Returns the font set used by the collection.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection1-getfontset HRESULT GetFontSet(
		// [out] IDWriteFontSet **fontSet );
		new IDWriteFontSet GetFontSet();

		/// <summary>Creates a font family object given a zero-based font family index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font family.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFamily1**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created font family object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontcollection1-getfontfamily
		// HRESULT GetFontFamily( UINT32 index, IDWriteFontFamily1 **fontFamily );
		new IDWriteFontFamily1 GetFontFamily1(uint index);

		/// <summary>Creates a font family object, given a zero-based font family index.</summary>
		/// <param name="index">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font family.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFamily2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFamily2</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font family object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection2-getfontfamily HRESULT
		// GetFontFamily( UINT32 index, [out] IDWriteFontFamily2 **fontFamily );
		IDWriteFontFamily2 GetFontFamily2(uint index);

		/// <summary>
		/// Retrieves a list of fonts in the specified font family, ranked in order of how well they match the specified axis values.
		/// </summary>
		/// <param name="familyName">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>Name of the font family. The name is not case-sensitive, but must otherwise exactly match a family name in the collection.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontList2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontList2</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font list object.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If no fonts match, an empty list object is returned (calling <c>IDWriteFontList::GetFontCount</c> on it returns 0), but the
		/// function doesn't return an error.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection2-getmatchingfonts HRESULT
		// GetMatchingFonts( WCHAR const *familyName, DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount, [out]
		// IDWriteFontList2 **fontList );
		IDWriteFontList2 GetMatchingFonts([MarshalAs(UnmanagedType.LPWStr)] string familyName,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Retrieves the font family model used by the font collection to group families.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_FAMILY_MODEL</c></b></para>
		/// <para>How families are grouped in the collection.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection2-getfontfamilymodel
		// DWRITE_FONT_FAMILY_MODEL GetFontFamilyModel();
		[PreserveSig]
		DWRITE_FONT_FAMILY_MODEL GetFontFamilyModel();

		/// <summary>Retrieves the underlying font set used by this collection.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to the
		/// font set used by the collection.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection2-getfontset HRESULT GetFontSet(
		// [out] IDWriteFontSet1 **fontSet );
		IDWriteFontSet1 GetFontSet1();
	}


	/// <summary>
	/// <para>
	/// This interface encapsulates a set of fonts, such as the set of fonts installed on the system, or the set of fonts in a particular
	/// directory. The font collection API can be used to discover what font families and fonts are available, and to obtain some metadata
	/// about the fonts. <b>IDWriteFontCollection3</b> adds the ability to retrieve the expiration event.
	/// </para>
	/// <para>This interface extends <c>IDWriteFontCollection2</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontcollection3
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontCollection3")]
	[ComImport, Guid("A4D055A6-F9E3-4E25-93B7-9E309F3AF8E9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontCollection3 : IDWriteFontCollection, IDWriteFontCollection1, IDWriteFontCollection2
	{
		/// <summary>Gets the number of font families in the collection.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font families in the collection.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfamilycount UINT32 GetFontFamilyCount();
		[PreserveSig]
		new uint GetFontFamilyCount();

		/// <summary>Creates a font family object given a zero-based font family index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font family.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFamily**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created font family object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfamily HRESULT GetFontFamily(
		// UINT32 index, IDWriteFontFamily **fontFamily );
		new IDWriteFontFamily GetFontFamily(uint index);

		/// <summary>Finds the font family with the specified family name.</summary>
		/// <param name="familyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters, which is null-terminated, containing the name of the font family. The name is not case-sensitive but
		/// must otherwise exactly match a family name in the collection.
		/// </para>
		/// </param>
		/// <param name="index">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// When this method returns, contains the zero-based index of the matching font family if the family name was found; otherwise, <c>UINT_MAX</c>.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the family name exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-findfamilyname HRESULT FindFamilyName(
		// WCHAR const *familyName, UINT32 *index, BOOL *exists );
		new void FindFamilyName([MarshalAs(UnmanagedType.LPWStr)] string familyName, out uint index, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>
		/// Gets the font object that corresponds to the same physical font as the specified font face object. The specified physical font
		/// must belong to the font collection.
		/// </summary>
		/// <param name="fontFace">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>A font face object that specifies the physical font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the newly created font object if successful; otherwise, <c>NULL</c>.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfromfontface HRESULT
		// GetFontFromFontFace( IDWriteFontFace *fontFace, IDWriteFont **font );
		new IDWriteFont GetFontFromFontFace([In] IDWriteFontFace fontFace);

		/// <summary>Gets the underlying font set used by this collection.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Returns the font set used by the collection.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection1-getfontset HRESULT GetFontSet(
		// [out] IDWriteFontSet **fontSet );
		new IDWriteFontSet GetFontSet();

		/// <summary>Creates a font family object given a zero-based font family index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font family.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFamily1**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created font family object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontcollection1-getfontfamily
		// HRESULT GetFontFamily( UINT32 index, IDWriteFontFamily1 **fontFamily );
		new IDWriteFontFamily1 GetFontFamily1(uint index);

		/// <summary>Creates a font family object, given a zero-based font family index.</summary>
		/// <param name="index">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font family.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFamily2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFamily2</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font family object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection2-getfontfamily HRESULT
		// GetFontFamily( UINT32 index, [out] IDWriteFontFamily2 **fontFamily );
		new IDWriteFontFamily2 GetFontFamily2(uint index);

		/// <summary>
		/// Retrieves a list of fonts in the specified font family, ranked in order of how well they match the specified axis values.
		/// </summary>
		/// <param name="familyName">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>Name of the font family. The name is not case-sensitive, but must otherwise exactly match a family name in the collection.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontList2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontList2</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font list object.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If no fonts match, an empty list object is returned (calling <c>IDWriteFontList::GetFontCount</c> on it returns 0), but the
		/// function doesn't return an error.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection2-getmatchingfonts HRESULT
		// GetMatchingFonts( WCHAR const *familyName, DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount, [out]
		// IDWriteFontList2 **fontList );
		new IDWriteFontList2 GetMatchingFonts([MarshalAs(UnmanagedType.LPWStr)] string familyName,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Retrieves the font family model used by the font collection to group families.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_FAMILY_MODEL</c></b></para>
		/// <para>How families are grouped in the collection.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection2-getfontfamilymodel
		// DWRITE_FONT_FAMILY_MODEL GetFontFamilyModel();
		[PreserveSig]
		new DWRITE_FONT_FAMILY_MODEL GetFontFamilyModel();

		/// <summary>Retrieves the underlying font set used by this collection.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to the
		/// font set used by the collection.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection2-getfontset HRESULT GetFontSet(
		// [out] IDWriteFontSet1 **fontSet );
		new IDWriteFontSet1 GetFontSet1();

		/// <summary>
		/// Retrieves the expiration event for the font set, if any. The expiration event is set on a system font set object if it is out of
		/// date due to fonts being installed, uninstalled, or updated. You should handle the event by getting a new system font set.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>An event handle, if called on the system font set, or <c>nullptr</c> if called on a custom font set.</para>
		/// </returns>
		/// <remarks>
		/// You mustn't call <b>CloseHandle</b> on the returned event handle. The handle is owned by the font set object, and it remains
		/// valid as long as you hold a reference to the font set. You can wait on the returned event, or use
		/// <c>RegisterWaitForSingleObject</c> to request a callback when the event is set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontcollection3-getexpirationevent HANDLE GetExpirationEvent();
		[PreserveSig]
		HEVENT GetExpirationEvent();
	}


	/// <summary>
	/// Application-defined callback interface that receives notifications from the font download queue ( <c>IDWriteFontDownloadQueue</c>
	/// interface). Callbacks will occur on the downloading thread, and objects must be prepared to handle calls on their methods from other
	/// threads at any time.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontdownloadlistener
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontDownloadListener")]
	[ComImport, Guid("B06FE5B9-43EC-4393-881B-DBE4DC72FDA7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontDownloadListener
	{
		/// <summary>The DownloadCompleted method is called back on an arbitrary thread when a download operation ends.</summary>
		/// <param name="downloadQueue">
		/// <para>Type: <b><c>IDWriteFontDownloadQueue</c>*</b></para>
		/// <para>Pointer to the download queue interface on which the BeginDownload method was called.</para>
		/// </param>
		/// <param name="context">
		/// <para>Type: <b>IUnknown*</b></para>
		/// <para>
		/// Optional context object that was passed to BeginDownload. AddRef is called on the context object by BeginDownload and Release is
		/// called after the DownloadCompleted method returns.
		/// </para>
		/// </param>
		/// <param name="downloadResult">
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>Result of the download operation.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontdownloadlistener-downloadcompleted void
		// DownloadCompleted( [in] IDWriteFontDownloadQueue *downloadQueue, [in, optional] IUnknown *context, HRESULT downloadResult );
		[PreserveSig]
		void DownloadCompleted([In] IDWriteFontDownloadQueue downloadQueue, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? context,
			HRESULT downloadResult);
	}


	/// <summary>
	/// Interface that enqueues download requests for remote fonts, characters, glyphs, and font fragments. Provides methods to
	/// asynchronously execute a download, cancel pending downloads, and be notified of download completion. Callbacks to listeners will
	/// occur on the downloading thread, and objects must be must be able to handle calls on their methods from other threads at any time.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontdownloadqueue
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontDownloadQueue")]
	[ComImport, Guid("B71E6052-5AEA-4FA3-832E-F60D431F7E91"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontDownloadQueue
	{
		/// <summary>
		/// Registers a client-defined listener object that receives download notifications. All registered listener's DownloadCompleted
		/// will be called after <c>BeginDownload</c> completes.
		/// </summary>
		/// <param name="listener">
		/// <para>Type: <b><c>IDWriteFontDownloadListener</c>*</b></para>
		/// <para>Listener object to add.</para>
		/// </param>
		/// <param name="token">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives a token value, which the caller must subsequently pass to <c>RemoveListener</c>.</para>
		/// </param>
		/// <remarks>
		/// An <c>IDWriteFontDownloadListener</c> can also be passed to <c>BeginDownload</c> using the context parameter, rather than
		/// globally registered to the queue.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontdownloadqueue-addlistener HRESULT
		// AddListener( IDWriteFontDownloadListener *listener, [out] UINT32 *token );
		void AddListener(IDWriteFontDownloadListener listener, out uint token);

		/// <summary>Unregisters a notification handler that was previously registered using <c>AddListener</c>.</summary>
		/// <param name="token">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Token value previously returned by <c>AddListener</c>.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontdownloadqueue-removelistener HRESULT
		// RemoveListener( UINT32 token );
		void RemoveListener(uint token);

		/// <summary/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontdownloadqueue-isempty BOOL IsEmpty();
		[PreserveSig]
		bool IsEmpty();

		/// <summary>
		/// Begins an asynchronous download operation. The download operation executes in the background until it completes or is cancelled
		/// by a <c>CancelDownload</c> call.
		/// </summary>
		/// <param name="context">
		/// <para>Type: <b>IUnknown*</b></para>
		/// <para>
		/// Optional context object that is passed back to the download notification handler's DownloadCompleted method. If the context
		/// object implements IDWriteFontDownloadListener, its DownloadCompleted will be called when done.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>Returns S_OK if a download was successfully begun, S_FALSE if the queue was empty, or a standard HRESULT error code.</para>
		/// </returns>
		/// <remarks>
		/// BeginDownload removes all download requests from the queue, transferring them to a background download operation. If any
		/// previous downloads are still ongoing when BeginDownload is called again, the new download does not complete until the previous
		/// downloads have finished.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontdownloadqueue-begindownload HRESULT
		// BeginDownload( [in, optional] IUnknown *context );
		[PreserveSig]
		HRESULT BeginDownload([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? context);

		/// <summary>Removes all download requests from the queue and cancels any active download operations.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontdownloadqueue-canceldownload HRESULT CancelDownload();
		void CancelDownload();

		/// <summary>
		/// Gets the current generation number of the download queue, which is incremented every time after a download completes, whether
		/// failed or successful. This cookie value can be compared against cached data to determine if it is stale.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The current generation number of the download queue.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontdownloadqueue-getgenerationcount UINT64 GetGenerationCount();
		[PreserveSig]
		ulong GetGenerationCount();
	}

	/// <summary>
	/// <para>
	/// Represents an absolute reference to a font face. This interface contains font face type, appropriate file references, and face
	/// identification data.
	/// </para>
	/// <para>
	/// This interface extends <c>IDWriteFontFace2</c>. Various font data such as metrics, names, and glyph outlines are obtained from <b>IDWriteFontFace</b>.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontface3
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontFace3")]
	[ComImport, Guid("D37D7598-09BE-4222-A236-2081341CC1F2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFace3 : IDWriteFontFace, IDWriteFontFace1, IDWriteFontFace2
	{
		/// <summary>Obtains the file format type of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of format for the font face (such as Type 1, TrueType, vector, or bitmap).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-gettype DWRITE_FONT_FACE_TYPE GetType();
		[PreserveSig]
		new DWRITE_FONT_FACE_TYPE GetType();

		/// <summary>Obtains the font files representing a font face.</summary>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// If fontFiles is <c>NULL</c>, receives the number of files representing the font face. Otherwise, the number of font files being
		/// requested should be passed. See the Remarks section below for more information.
		/// </para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a user-provided array that stores pointers to font files representing the font
		/// face. This parameter can be <c>NULL</c> if the user wants only the number of files representing the font face. This API
		/// increments reference count of the font file pointers returned according to COM conventions, and the client should release them
		/// when finished.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>IDWriteFontFace::GetFiles</c> method should be called twice. The first time you call <c>GetFiles</c> fontFiles should be
		/// <c>NULL</c>. When the method returns, numberOfFiles receives the number of font files that represent the font face.
		/// </para>
		/// <para>
		/// Then, call the method a second time, passing the numberOfFiles value that was output the first call, and a non-null buffer of
		/// the correct size to store the IDWriteFontFile pointers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getfiles HRESULT GetFiles( UINT32
		// *numberOfFiles, IDWriteFontFile **fontFiles );
		new void GetFiles(ref uint numberOfFiles, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[]? fontFiles);

		/// <summary>Obtains the index of a font face in the context of its font files.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value is zero.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getindex UINT32 GetIndex();
		[PreserveSig]
		new uint GetIndex();

		/// <summary>Obtains the algorithmic style simulation flags of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>Font face simulation flags for algorithmic means of making text bold or italic.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getsimulations DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		new DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>Determines whether the font is a symbol font.</summary>
		/// <returns>
		/// <para>Type: <c>bool</c></para>
		/// <para>Returns <c>TRUE</c> if the font is a symbol font, otherwise <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-issymbolfont bool IsSymbolFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsSymbolFont();

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontFaceMetrics">
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// When this method returns, a DWRITE_FONT_METRICS structure that holds metrics (such as ascent, descent, or cap height) for the
		/// current font face element. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getmetrics void GetMetrics(
		// DWRITE_FONT_METRICS *fontFaceMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS fontFaceMetrics);

		/// <summary>Obtains the number of glyphs in the font face.</summary>
		/// <returns>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The number of glyphs in the font face.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphcount UINT16 GetGlyphCount();
		[PreserveSig]
		new ushort GetGlyphCount();

		/// <summary>Obtains ideal (resolution-independent) glyph metrics in font design units.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices for which to compute metrics. The array must contain at least as many elements as specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains an array of DWRITE_GLYPH_METRICS structures. glyphMetrics must be initialized with an empty
		/// buffer that contains at least as many elements as glyphCount. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has oblique simulation
		/// because sideways oblique simulation differs from non-sideways oblique simulation
		/// </para>
		/// </param>
		/// <remarks>Design glyph metrics are used for glyph positioning.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getdesignglyphmetrics HRESULT
		// GetDesignGlyphMetrics( UINT16 const *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, bool isSideways );
		new void GetDesignGlyphMetrics([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>Returns the nominal mapping of UCS4 Unicode code points to glyph indices as defined by the font 'CMAP' table.</summary>
		/// <param name="codePoints">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>
		/// An array of USC4 code points from which to obtain nominal glyph indices. The array must be allocated and be able to contain the
		/// number of elements specified by codePointCount.
		/// </para>
		/// </param>
		/// <param name="codePointCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the codePoints array.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>UINT16*</c></para>
		/// <para>When this method returns, contains a pointer to an array of nominal glyph indices filled by this function.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Note that this mapping is primarily provided for line layout engines built on top of the physical font API. Because of OpenType
		/// glyph substitution and line layout character substitution, the nominal conversion does not always correspond to how a Unicode
		/// string will map to glyph indices when rendering using a particular font face. Also, note that Unicode variant selectors provide
		/// for alternate mappings for character to glyph. This call will always return the default variant.
		/// </para>
		/// <para>
		/// When characters are not present in the font this method returns the index 0, which is the undefined glyph or ".notdef" glyph. If
		/// a character isn't in a font, IDWriteFont::HasCharacter returns false and GetUnicodeRanges doesn't return it in the range.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphindices HRESULT GetGlyphIndices(
		// UINT32 const *codePoints, UINT32 codePointCount, UINT16 *glyphIndices );
		new void GetGlyphIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] codePoints, uint codePointCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices);

		/// <summary>
		/// Finds the specified OpenType font table if it exists and returns a pointer to it. The function accesses the underlying font data
		/// through the IDWriteFontFileStream interface implemented by the font file loader.
		/// </summary>
		/// <param name="openTypeTableTag">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The four-character tag of a OpenType font table to find. Use the <c>DWRITE_MAKE_OPENTYPE_TAG</c> macro to create it as an
		/// <c>UINT32</c>. Unlike GDI, it does not support the special TTCF and null tags to access the whole font.
		/// </para>
		/// </param>
		/// <param name="tableData">
		/// <para>Type: <c>const void**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the base of the table in memory. The pointer is valid only as
		/// long as the font face used to get the font table still exists; (not any other font face, even if it actually refers to the same
		/// physical font). This parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tableSize">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains a pointer to the size, in bytes, of the font table.</para>
		/// </param>
		/// <param name="tableContext">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, the address of a pointer to the opaque context, which must be freed by calling ReleaseFontTable. The
		/// context actually comes from the lower-level IDWriteFontFileStream, which may be implemented by the application or DWrite itself.
		/// It is possible for a <c>NULL</c> tableContext to be returned, especially if the implementation performs direct memory mapping on
		/// the whole file. Nevertheless, always release it later, and do not use it as a test for function success. The same table can be
		/// queried multiple times, but because each returned context can be different, you must release each context separately.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>bool*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font table exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The context for the same tag may be different for each call, so each one must be held and released separately.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-trygetfonttable HRESULT TryGetFontTable(
		// UINT32 openTypeTableTag, const void **tableData, UINT32 *tableSize, void **tableContext, bool *exists );
		new HRESULT TryGetFontTable([In] uint openTypeTableTag, out IntPtr tableData, out uint tableSize, out IntPtr tableContext, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Releases the table obtained earlier from TryGetFontTable.</summary>
		/// <param name="tableContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the opaque context from TryGetFontTable.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-releasefonttable void ReleaseFontTable( void
		// *tableContext );
		[PreserveSig]
		new void ReleaseFontTable([In] IntPtr tableContext);

		/// <summary>Computes the outline of a run of glyphs by calling back to the outline sink interface.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices. The glyphs are in logical order and the advance direction depends on the isRightToLeft parameter. The
		/// array must be allocated and be able to contain the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An optional array of glyph advances in DIPs. The advance of a glyph is the amount to advance the position (in the direction of
		/// the baseline) after drawing the glyph. glyphAdvances contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <c>const DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>
		/// An optional array of glyph offsets, each of which specifies the offset along the baseline and offset perpendicular to the
		/// baseline of a glyph relative to the current pen position. glyphOffsets contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs in the run.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If <c>TRUE</c>, the ascender of the glyph runs alongside the baseline. If <c>FALSE</c>, the glyph ascender runs perpendicular to
		/// the baseline. For example, an English alphabet on a vertical baseline would have isSideways set to <c>FALSE</c>.
		/// </para>
		/// <para>
		/// A client can render a vertical run by setting isSideways to <c>TRUE</c> and rotating the resulting geometry 90 degrees to the
		/// right using a transform. The isSideways and isRightToLeft parameters cannot both be true.
		/// </para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// The visual order of the glyphs. If this parameter is <c>FALSE</c>, then glyph advances are from left to right. If <c>TRUE</c>,
		/// the advance direction is right to left. By default, the advance direction is left to right.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: <c>IDWriteGeometrySink*</c></para>
		/// <para>A pointer to the interface that is called back to perform outline drawing operations.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphrunoutline HRESULT
		// GetGlyphRunOutline( FLOAT emSize, UINT16 const *glyphIndices, FLOAT const *glyphAdvances, DWRITE_GLYPH_OFFSET const
		// *glyphOffsets, UINT32 glyphCount, bool isSideways, bool isRightToLeft, IDWriteGeometrySink *geometrySink );
		new void GetGlyphRunOutline(float emSize, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] glyphIndices,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[]? glyphAdvances,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[]? glyphOffsets,
			uint glyphCount, [MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			[In, MarshalAs(UnmanagedType.Interface)] object geometrySink);

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96, this value is 1.0f. If the DPI is
		/// 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for DWRITE_MEASURING_MODE_NATURAL</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for DWRITE_MEASURING_MODE_GDI_CLASSIC</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for DWRITE_MEASURING_MODE_GDI_NATURAL</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>
		/// A pointer to an object that contains rendering settings such as gamma level, enhanced contrast, and ClearType level. This
		/// parameter is necessary in case the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_RENDERING_MODE*</c></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams
		// *renderingParams, DWRITE_RENDERING_MODE *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float emSize, float pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams renderingParams);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>A pointer to a DWRITE_FONT_METRICS structure to fill in. The metrics returned by this function are in font design units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, DWRITE_FONT_METRICS
		// *fontFaceMetrics );
		new DWRITE_FONT_METRICS GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform);

		/// <summary>Obtains glyph metrics in font design units with the return values compatible with what GDI would produce.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ogical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// When set to <c>FALSE</c>, the metrics are the same as the metrics of GDI aliased text. When set to <c>TRUE</c>, the metrics are
		/// the same as the metrics of text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of glyph indices for which to compute the metrics.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>An array of DWRITE_GLYPH_METRICS structures filled by this function. The metrics are in font design units.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// A bool value that indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has
		/// oblique simulation because sideways oblique simulation differs from non-sideways oblique simulation.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatibleglyphmetrics HRESULT
		// GetGdiCompatibleGlyphMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, UINT16 const
		// *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, bool isSideways );
		new void GetGdiCompatibleGlyphMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontMetrics">
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A filled <c>DWRITE_FONT_METRICS1</c> structure that holds metrics for the current font face element. The metrics returned by
		/// this method are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getmetrics void GetMetrics( [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS1 fontMetrics);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and <i>pixelsPerDip</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A pointer to a <c>DWRITE_FONT_METRICS1</c> structure to fill in. The metrics returned by this function are in font design units.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		new DWRITE_FONT_METRICS1 GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform);

		/// <summary>Gets caret metrics for the font in design units.</summary>
		/// <param name="caretMetrics">
		/// <para>Type: <b>DWRITE_CARET_METRICS*</b></para>
		/// <para>A pointer to the <c>DWRITE_CARET_METRICS</c> structure that is filled.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Caret metrics are used by text editors for drawing the correct caret placement and slant.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getcaretmetrics void GetCaretMetrics(
		// [out] DWRITE_CARET_METRICS *caretMetrics );
		[PreserveSig]
		new void GetCaretMetrics(out DWRITE_CARET_METRICS caretMetrics);

		/// <summary>Retrieves a list of character ranges supported by a font.</summary>
		/// <param name="maxRangeCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Maximum number of character ranges passed in from the client.</para>
		/// </param>
		/// <param name="unicodeRanges">
		/// <para>Type: <b><c>DWRITE_UNICODE_RANGE</c>*</b></para>
		/// <para>An array of <c>DWRITE_UNICODE_RANGE</c> structures that are filled with the character ranges.</para>
		/// </param>
		/// <param name="actualRangeCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>A pointer to the actual number of character ranges, regardless of the maximum count.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A list of character ranges supported by the font is useful for scenarios like character picking, glyph display, and efficient
		/// font selection lookup. This is similar to GDI's <c>GetFontUnicodeRanges</c>, except that it returns the full Unicode range, not
		/// just 16-bit UCS-2.
		/// </para>
		/// <para>These ranges are from the cmap, not the OS/2::ulCodePageRange1.</para>
		/// <para>
		/// If this method is unavailable, you can use the <c>IDWriteFontFace::GetGlyphIndices</c> method to check for missing glyphs. The
		/// method returns the 0 index for glyphs that aren't present in the font.
		/// </para>
		/// <para>
		/// The <c>IDWriteFont::HasCharacter</c> method is often simpler in cases where you need to check a single character or a series of
		/// single characters in succession, such as in font fallback.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getunicoderanges HRESULT
		// GetUnicodeRanges( UINT32 maxRangeCount, [out, optional] DWRITE_UNICODE_RANGE *unicodeRanges, [out] UINT32 *actualRangeCount );
		new void GetUnicodeRanges(int maxRangeCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DWRITE_UNICODE_RANGE[]? unicodeRanges, out uint actualRangeCount);

		/// <summary>
		/// Determines whether the font of a text range is monospaced, that is, the font characters are the same fixed-pitch width.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns TRUE if the font is monospaced, otherwise it returns FALSE.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-ismonospacedfont bool IsMonospacedFont();
		[PreserveSig]
		new bool IsMonospacedFont();

		/// <summary>Retrieves the advances in design units for a sequences of glyphs.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Retrieve the glyph's vertical advance height rather than horizontal advance widths.</para>
		/// </param>
		/// <remarks>This is equivalent to calling GetGlyphMetrics and using only the advance width and height.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getdesignglyphadvances HRESULT
		// GetDesignGlyphAdvances( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances, bool isSideways );
		new void GetDesignGlyphAdvances(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvances, bool isSideways = false);

		/// <summary>Returns the pixel-aligned advances for a sequences of glyphs.</summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// Number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this value is 1.0f. If the DPI is 120,
		/// this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the font
		/// size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// When FALSE, the metrics are the same as GDI aliased text (DWRITE_MEASURING_MODE_GDI_CLASSIC). When TRUE, the metrics are the
		/// same as those measured by GDI using a font using CLEARTYPE_NATURAL_QUALITY (DWRITE_MEASURING_MODE_GDI_NATURAL).
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Retrieve the glyph's vertical advances rather than horizontal advances.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Total glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>const INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <remarks>
		/// <para>This is equivalent to calling <c>GetGdiCompatibleGlyphMetrics</c> and using only the advance width and height.</para>
		/// <para>Like <c>GetGdiCompatibleGlyphMetrics</c>, these are in design units, meaning they must be scaled down by DWRITE_FONT_METRICS::designUnitsPerEm.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatibleglyphadvances HRESULT
		// GetGdiCompatibleGlyphAdvances( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, bool
		// useGdiNatural, bool isSideways, UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances );
		new void GetGdiCompatibleGlyphAdvances(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform, bool useGdiNatural,
			bool isSideways, int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] int[] glyphAdvances);

		/// <summary>Retrieves the kerning pair adjustments from the font's kern table.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphAdvanceAdjustments">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The advances, returned in font design units, for each glyph. The last glyph adjustment is zero.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <b>GetKerningPairAdjustments</b> isn't a direct replacement for GDI's character based <c>GetKerningPairs</c>, but it serves the
		/// same role, without the client needing to cache them locally. <b>GetKerningPairAdjustments</b> also uses glyph id's directly
		/// rather than UCS-2 characters (how the kern table actually stores them), which avoids glyph collapse and ambiguity, such as the
		/// dash and hyphen, or space and non-breaking space.
		/// </para>
		/// <para>
		/// Newer fonts may have only GPOS kerning instead of the legacy pair-table kerning. Such fonts, like Gabriola, will only return 0's
		/// for adjustments. <b>GetKerningPairAdjustments</b> doesn't virtualize and flatten these GPOS entries into kerning pairs.
		/// </para>
		/// <para>
		/// You can realize a performance benefit by calling <c>IDWriteFontFace1::HasKerningPairs</c> to determine whether you need to call
		/// <b>GetKerningPairAdjustments</b>. If you previously called <b>IDWriteFontFace1::HasKerningPairs</b> and it returned FALSE, you
		/// can avoid calling <b>GetKerningPairAdjustments</b> because the font has no kerning pair-table entries. That is, in this
		/// situation, a call to <b>GetKerningPairAdjustments</b> would be a no-op.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getkerningpairadjustments HRESULT
		// GetKerningPairAdjustments( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvanceAdjustments );
		new void GetKerningPairAdjustments(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvanceAdjustments);

		/// <summary>Determines whether the font supports pair-kerning.</summary>
		/// <returns>Returns TRUE if the font supports kerning pairs, otherwise FALSE.</returns>
		/// <remarks>
		/// If the font doesn't support pair table kerning, you don't need to call <c>IDWriteFontFace1::GetKerningPairAdjustments</c>
		/// because it would retrieve all zeroes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-haskerningpairs bool HasKerningPairs();
		[PreserveSig]
		new bool HasKerningPairs();

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a horizontal position. For example, if the DPI of the rendering surface is 96, this
		/// value is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a vertical position. For example, if the DPI of the rendering surface is 96, this value
		/// is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const DWRITE_MATRIX*</b></para>
		/// <para>Specifies the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether the glyphs in the run are sideways or not.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for <c>DWRITE_MEASURING_MODE_NATURAL</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for <c>DWRITE_MEASURING_MODE_GDI_CLASSIC</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for <c>DWRITE_MEASURING_MODE_GDI_NATURAL</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		/// <remarks>
		/// This method should be used to determine the actual rendering mode in cases where the rendering mode of the rendering params
		/// object is DWRITE_RENDERING_MODE_DEFAULT.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT fontEmSize, FLOAT dpiX, FLOAT dpiY, [in, optional] DWRITE_MATRIX const *transform, bool
		// isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [out] DWRITE_RENDERING_MODE
		// *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Retrieves the vertical forms of the nominal glyphs retrieved from GetGlyphIndices.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve.</para>
		/// </param>
		/// <param name="nominalGlyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Original glyph indices from cmap.</para>
		/// </param>
		/// <param name="verticalGlyphIndices">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>The vertical form of glyph indices.</para>
		/// </param>
		/// <remarks>
		/// <para>The retrieval uses the font's 'vert' table. This is used in CJK vertical layout so the correct characters are shown.</para>
		/// <para>
		/// Call <c>GetGlyphIndices</c> to get the nominal glyph indices, followed by calling this to remap the to the substituted forms,
		/// when the run is sideways, and the font has vertical glyph variants. See <c>HasVerticalGlyphVariants</c> for more info.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getverticalglyphvariants HRESULT
		// GetVerticalGlyphVariants( UINT32 glyphCount, [in] UINT16 const *nominalGlyphIndices, [out] UINT16 *verticalGlyphIndices );
		new void GetVerticalGlyphVariants(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] nominalGlyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] verticalGlyphIndices);

		/// <summary>Determines whether the font has any vertical glyph variants.</summary>
		/// <returns>Returns TRUE if the font contains vertical glyph variants, otherwise FALSE.</returns>
		/// <remarks>
		/// <para>For OpenType fonts, <b>HasVerticalGlyphVariants</b> returns TRUE if the font contains a "vert"feature.</para>
		/// <para>
		/// <c>IDWriteFontFace1::GetVerticalGlyphVariants</c> retrieves the vertical forms of the nominal glyphs that are retrieved from <c>IDWriteFontFace::GetGlyphIndices</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-hasverticalglyphvariants bool HasVerticalGlyphVariants();
		[PreserveSig]
		new bool HasVerticalGlyphVariants();

		/// <summary>Allows you to determine if a color rendering path is potentially necessary.</summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns <b>TRUE</b> if a color rendering path is potentially necessary.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-iscolorfont bool IsColorFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsColorFont();

		/// <summary>Gets the number of color palettes defined by the font.</summary>
		/// <returns>
		/// The return value is zero if the font has no color information. Color fonts are required to define at least one palette, with
		/// palette index zero reserved as the default palette.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getcolorpalettecount UINT32 GetColorPaletteCount();
		[PreserveSig]
		new uint GetColorPaletteCount();

		/// <summary>Get the number of entries in each color palette.</summary>
		/// <returns>
		/// The number of entries in each color palette. All color palettes in a font have the same number of palette entries. The return
		/// value is zero if the font has no color information.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentrycount UINT32 GetPaletteEntryCount();
		[PreserveSig]
		new uint GetPaletteEntryCount();

		/// <summary>Gets color values from the font's color palette.</summary>
		/// <param name="colorPaletteIndex">
		/// Zero-based index of the color palette. If the font does not have a palette with the specified index, the method returns <b>DWRITE_E_NOCOLOR</b>.
		/// </param>
		/// <param name="firstEntryIndex">Zero-based index of the first palette entry to read.</param>
		/// <param name="entryCount">Number of palette entries to read.</param>
		/// <param name="paletteEntries">Array that receives the color values.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// The sum of <i>firstEntryIndex</i> and <i>entryCount</i> is greater than the actual number of palette entries that's returned by
		/// the <c>GetPaletteEntryCount</c> method.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DWRITE_E_NOCOLOR</description>
		/// <description>The font doesn't have a palette with the specified palette index.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentries HRESULT
		// GetPaletteEntries( UINT32 colorPaletteIndex, UINT32 firstEntryIndex, UINT32 entryCount, [out] DWRITE_COLOR_F *paletteEntries );
		[PreserveSig]
		new HRESULT GetPaletteEntries(uint colorPaletteIndex, uint firstEntryIndex, uint entryCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_COLOR_F[] paletteEntries);

		/// <summary>
		/// Determines the recommended text rendering and grid-fit mode to be used based on the font, size, world transform, and measuring mode.
		/// </summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical font size in DIPs.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the horizontal direction.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the vertical direction.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Specifies whether the font is sideways. <b>TRUE</b> if the font is sideways; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the method used to measure during text layout. For proper glyph
		/// spacing, this method returns a rendering mode that is compatible with the specified measuring mode.
		/// </para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>
		/// A pointer to a <c>IDWriteRenderingParams</c> interface for the rendering parameters object. This parameter is necessary in case
		/// the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_RENDERING_MODE</c>-typed value for the recommended rendering mode.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the recommended grid-fit mode.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( [in] FLOAT fontEmSize, [in] FLOAT dpiX, [in] FLOAT dpiY, [in, optional] DWRITE_MATRIX const
		// *transform, [in] bool isSideways, [in] DWRITE_OUTLINE_THRESHOLD outlineThreshold, [in] DWRITE_MEASURING_MODE measuringMode, [in,
		// optional] IDWriteRenderingParams *renderingParams, [out] DWRITE_RENDERING_MODE *renderingMode, [out] DWRITE_GRID_FIT_MODE
		// *gridFitMode );
		new void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [In, Optional] IDWriteRenderingParams? renderingParams,
			out DWRITE_RENDERING_MODE renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Gets a font face reference that identifies this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFaceReference</c> interface for the newly created font
		/// face reference object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfontfacereference HRESULT
		// GetFontFaceReference( [out] IDWriteFontFaceReference **fontFaceReference );
		IDWriteFontFaceReference GetFontFaceReference();

		/// <summary>Gets the PANOSE values from the font, used for font selection and matching.</summary>
		/// <param name="panose">
		/// <para>Type: <b><c>DWRITE_PANOSE</c>*</b></para>
		/// <para>A pointer to a <c>DWRITE_PANOSE</c> structure that receives the PANOSE values from the font.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't simulate these values, such as substituting a weight or proportion inferred on other values. If the font
		/// doesn't specify them, they are all set to 'any' (0).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getpanose void GetPanose( [out]
		// DWRITE_PANOSE *panose );
		[PreserveSig]
		void GetPanose(out DWRITE_PANOSE panose);

		/// <summary>Gets the weight of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_WEIGHT</c></b></para>
		/// <para>
		/// Returns a <c>DWRITE_FONT_WEIGHT</c>-typed value that specifies the density of a typeface, in terms of the lightness or heaviness
		/// of the strokes.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getweight DWRITE_FONT_WEIGHT GetWeight();
		[PreserveSig]
		DWRITE_FONT_WEIGHT GetWeight();

		/// <summary>Gets the stretch (also known as width) of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_STRETCH</c></b></para>
		/// <para>
		/// Returns a <c>DWRITE_FONT_STRETCH</c>-typed value that specifies the degree to which a font has been stretched compared to a
		/// font's normal aspect ratio.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getstretch DWRITE_FONT_STRETCH GetStretch();
		[PreserveSig]
		DWRITE_FONT_STRETCH GetStretch();

		/// <summary>Gets the style (also known as slope) of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_STYLE</c></b></para>
		/// <para>Returns a <c>DWRITE_FONT_STYLE</c>-typed value that specifies the style of the font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getstyle DWRITE_FONT_STYLE GetStyle();
		[PreserveSig]
		DWRITE_FONT_STYLE GetStyle();

		/// <summary>Creates a localized strings object that contains the family names for the font family, indexed by locale name.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfamilynames HRESULT GetFamilyNames(
		// [out] IDWriteLocalizedStrings **names );
		IDWriteLocalizedStrings GetFamilyNames();

		/// <summary>
		/// Creates a localized strings object that contains the face names for the font (for example, Regular or Bold), indexed by locale name.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfacenames HRESULT GetFaceNames(
		// [out] IDWriteLocalizedStrings **names );
		IDWriteLocalizedStrings GetFaceNames();

		/// <summary>Gets a localized strings collection that contains the specified informational strings, indexed by locale name.</summary>
		/// <param name="informationalStringID">
		/// <para>Type: <b><c>DWRITE_INFORMATIONAL_STRING_ID</c></b></para>
		/// <para>A <c>DWRITE_INFORMATIONAL_STRING_ID</c>-typed value that identifies the strings to get.</para>
		/// </param>
		/// <param name="informationalStrings">
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>
		/// A pointer to a variable that receives whether the font contains the specified string ID. <b>TRUE</b> if the font contains the
		/// specified string ID; otherwise, <b>FALSE</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>
		/// If the font doesn't contain the specified string, the return value is S_OK, but <i>informationalStrings</i> receives a
		/// <b>NULL</b> pointer and <i>exists</i> receives the value <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getinformationalstrings HRESULT
		// GetInformationalStrings( [in] DWRITE_INFORMATIONAL_STRING_ID informationalStringID, [out] IDWriteLocalizedStrings
		// **informationalStrings, [out] BOOL *exists );
		void GetInformationalStrings(DWRITE_INFORMATIONAL_STRING_ID informationalStringID, out IDWriteLocalizedStrings? informationalStrings,
			[MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Determines whether the font supports the specified character.</summary>
		/// <param name="unicodeValue">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>A Unicode (UCS-4) character value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// Returns whether the font supports the specified character. Returns <b>TRUE</b> if the font has the specified character;
		/// otherwise, <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-hascharacter BOOL HasCharacter( [in]
		// UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool HasCharacter(uint unicodeValue);

		/// <summary>
		/// Determines the recommended text rendering and grid-fit mode to be used based on the font, size, world transform, and measuring mode.
		/// </summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical font size in DIPs.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the horizontal direction.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the vertical direction.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether the font is sideways. <b>TRUE</b> if the font is sideways; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the method used to measure during text layout. For proper glyph
		/// spacing, this method returns a rendering mode that is compatible with the specified measuring mode.
		/// </para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>
		/// A pointer to a <c>IDWriteRenderingParams</c> interface for the rendering parameters object. This parameter is necessary in case
		/// the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_RENDERING_MODE1</c>-typed value for the recommended rendering mode.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the recommended grid-fit mode.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( [in] FLOAT fontEmSize, [in] FLOAT dpiX, [in] FLOAT dpiY, [in, optional] DWRITE_MATRIX const
		// *transform, [in] BOOL isSideways, [in] DWRITE_OUTLINE_THRESHOLD outlineThreshold, [in] DWRITE_MEASURING_MODE measuringMode, [in,
		// optional] IDWriteRenderingParams *renderingParams, [out] DWRITE_RENDERING_MODE1 *renderingMode, [out] DWRITE_GRID_FIT_MODE
		// *gridFitMode );
		void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] IDWriteRenderingParams? renderingParams, out DWRITE_RENDERING_MODE1 renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary><c>unicodeValue</c></summary>
		/// <param name="unicodeValue"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface3-ischaracterlocal BOOL
		// IsCharacterLocal( UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsCharacterLocal(uint unicodeValue);

		/// <summary>Determines whether the glyph is locally downloaded from the font.</summary>
		/// <param name="glyphId">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Glyph identifier.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns TRUE if the font has the specified glyph locally available.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-isglyphlocal BOOL IsGlyphLocal( [in]
		// UINT16 glyphId );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsGlyphLocal(ushort glyphId);

		/// <summary>Determines whether the specified characters are local.</summary>
		/// <param name="characters">
		/// <para>Type: <b>WCHAR</b></para>
		/// <para>Array of characters.</para>
		/// </param>
		/// <param name="characterCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the character array.</para>
		/// </param>
		/// <param name="enqueueIfNotLocal">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether to enqueue a download request if any of the specified characters are not local.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if all of the specified characters are local, FALSE if any of the specified characters are remote.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-arecharacterslocal HRESULT
		// AreCharactersLocal( [in] WCHAR const *characters, UINT32 characterCount, BOOL enqueueIfNotLocal, [out] BOOL *isLocal );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreCharactersLocal([MarshalAs(UnmanagedType.LPWStr)] string characters, uint characterCount, bool enqueueIfNotLocal);

		/// <summary>Determines whether the specified glyphs are local.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Array of glyph indices.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the glyph index array.</para>
		/// </param>
		/// <param name="enqueueIfNotLocal">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether to enqueue a download request if any of the specified glyphs are not local.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if all of the specified glyphs are local, FALSE if any of the specified glyphs are remote.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-areglyphslocal HRESULT AreGlyphsLocal(
		// [in] UINT16 const *glyphIndices, UINT32 glyphCount, BOOL enqueueIfNotLocal, [out] BOOL *isLocal );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreGlyphsLocal([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount, bool enqueueIfNotLocal);
	}
}