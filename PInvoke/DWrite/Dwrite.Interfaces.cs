namespace Vanara.PInvoke;

/// <summary>Items from the Dwrite.dll</summary>
public static partial class Dwrite
{
	/// <summary>Encapsulates a 32-bit device independent bitmap and device context, which can be used for rendering glyphs.</summary>
	/// <remarks>
	/// <para>
	/// You create an <c>IDWriteBitmapRenderTarget</c> by using the IDWriteGdiInterop::CreateBitmapRenderTarget method, as shown in the
	/// following code.
	/// </para>
	/// <para>
	/// IDWriteGdiInterop::CreateBitmapRenderTarget takes a handle to a DC and the desired width and height. In the above example, the
	/// width and height given are the size of the window rect.
	/// </para>
	/// <para>Rendering</para>
	/// <para>
	/// One way to use a <c>IDWriteBitmapRenderTarget</c>, for rendering to a bitmap, is to implement a custom renderer interface
	/// derived from the IDWriteTextRenderer interface. In your implementation of the DrawGlyphRun method of your custom renderer, call
	/// the IDWriteBitmapRenderTarget::DrawGlyphRun method to draw the glyphs as shown in the following code.
	/// </para>
	/// <para>
	/// The <c>IDWriteBitmapRenderTarget</c> encapsulates and renders to a bitmap in memory. The GetMemoryDC function returns a handle
	/// to the device context of this bitmap.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritebitmaprendertarget
	[PInvokeData("dwrite.h", MSDNShortId = "9953a9e9-7772-41a3-9cd9-2340a9dd4b6f")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5e5a32a3-8dff-4773-9ff6-0696eab77267")]
	public interface IDWriteBitmapRenderTarget
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
		/// The optional rectangle that receives the bounding box (in pixels not DIPs) of all the pixels affected by drawing the glyph
		/// run. The black box rectangle may extend beyond the dimensions of the bitmap.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// You can use the <c>IDWriteBitmapRenderTarget::DrawGlyphRun</c> to render to a bitmap from a custom text renderer that you
		/// implement. The custom text renderer should call this method from within the IDWriteTextRenderer::DrawGlyphRun callback
		/// method as shown in the following code.
		/// </para>
		/// <para>
		/// The baselineOriginX, baslineOriginY, measuringMethod, and glyphRun parameters are provided (as arguments) when the callback
		/// method is invoked. The renderingParams, textColor and blackBoxRect are not.
		/// </para>
		/// <para>Default rendering params can be retrieved by using the IDWriteFactory::CreateMonitorRenderingParams method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-drawglyphrun HRESULT
		// DrawGlyphRun( FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_MEASURING_MODE measuringMode, DWRITE_GLYPH_RUN const
		// *glyphRun, IDWriteRenderingParams *renderingParams, COLORREF textColor, RECT *blackBoxRect );
		void DrawGlyphRun(float baselineOriginX, float baselineOriginY, DWRITE_MEASURING_MODE measuringMode, in DWRITE_GLYPH_RUN glyphRun, [In] IDWriteRenderingParams renderingParams, COLORREF textColor, out RECT blackBoxRect);

		/// <summary>Gets a handle to the memory device context.</summary>
		/// <returns>
		/// <para>Type: <c>HDC</c></para>
		/// <para>Returns a device context handle to the memory device context.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can use the device context to draw using GDI functions. An application can obtain the bitmap handle (HBITMAP)
		/// by calling GetCurrentObject. An application that wants information about the underlying bitmap, including a pointer to the
		/// pixel data, can call GetObject to fill in a DIBSECTION structure. The bitmap is always a 32-bit top-down DIB.
		/// </para>
		/// <para>Note that this method takes no parameters and returns an HDC variable, not an HRESULT.</para>
		/// <para>
		/// The HDC returned here is still owned by the bitmap render targer object and should not be released or deleted by the client.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getmemorydc HDC GetMemoryDC();
		[PreserveSig]
		HDC GetMemoryDC();

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
		float GetPixelsPerDip();

		/// <summary>
		/// Sets the number of bitmap pixels per DIP (device-independent pixel). A DIP is 1/96 inch, so this value is the number if
		/// pixels per inch divided by 96.
		/// </summary>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that specifies the number of pixels per DIP.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-setpixelsperdip HRESULT
		// SetPixelsPerDip( FLOAT pixelsPerDip );
		void SetPixelsPerDip(float pixelsPerDip);

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
		DWRITE_MATRIX GetCurrentTransform();

		/// <summary>
		/// Sets the transform that maps abstract coordinate to DIPs (device-independent pixel). This does not affect the world
		/// transform of the underlying device context.
		/// </summary>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>Specifies the new transform. This parameter can be <c>NULL</c>, in which case the identity transform is implied.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-setcurrenttransform HRESULT
		// SetCurrentTransform( DWRITE_MATRIX const *transform );
		void SetCurrentTransform([In, Optional] IntPtr transform);

		/// <summary>Gets the dimensions of the target bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>SIZE*</c></para>
		/// <para>Returns the width and height of the bitmap in pixels.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getsize HRESULT GetSize( SIZE
		// *size );
		SIZE GetSize();

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
		void Resize(uint width, uint height);
	}

	/// <summary>
	/// Used to create all subsequent DirectWrite objects. This interface is the root factory interface for all DirectWrite objects.
	/// </summary>
	/// <remarks>
	/// <para>Create an <c>IDWriteFactory</c> object by using the DWriteCreateFactory function.</para>
	/// <para>
	/// An <c>IDWriteFactory</c> object holds state information, such as font loader registration and cached font data. This state can
	/// be shared or isolated. Shared is recommended for most applications because it saves memory. However, isolated can be useful in
	/// situations where you want to have a separate state for some objects.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefactory
	[PInvokeData("dwrite.h", MSDNShortId = "73a85977-5c24-4abc-ad8c-1d0d6474bd7e")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b859ee5a-d838-4b5b-a2e8-1adc7d93db48")]
	public interface IDWriteFactory
	{
		/// <summary>Gets an object which represents the set of installed fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the system font collection object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If this parameter is nonzero, the function performs an immediate check for changes to the set of installed fonts. If this
		/// parameter is <c>FALSE</c>, the function will still detect changes if the font cache service is running, but there may be
		/// some latency. For example, an application might specify <c>TRUE</c> if it has itself just installed a font and wants to be
		/// sure the font collection contains that font.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getsystemfontcollection HRESULT
		// GetSystemFontCollection( IDWriteFontCollection **fontCollection, BOOL checkForUpdates );
		void GetSystemFontCollection(out IDWriteFontCollection fontCollection, [MarshalAs(UnmanagedType.Bool)] bool checkForUpdates = false);

		/// <summary>Creates a font collection using a custom font collection loader.</summary>
		/// <param name="collectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>An application-defined font collection loader, which must have been previously registered using RegisterFontCollectionLoader.</para>
		/// </param>
		/// <param name="collectionKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// The key used by the loader to identify a collection of font files. The buffer allocated for this key should at least be the
		/// size of collectionKeySize.
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
		// CreateCustomFontCollection( IDWriteFontCollectionLoader *collectionLoader, void const *collectionKey, UINT32
		// collectionKeySize, IDWriteFontCollection **fontCollection );
		IDWriteFontCollection CreateCustomFontCollection([In] IDWriteFontCollectionLoader collectionLoader, [In] IntPtr collectionKey, uint collectionKeySize);

		/// <summary>Registers a custom font collection loader with the factory object.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be registered.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font collection loader with DirectWrite. The font collection loader interface, which should be
		/// implemented by a singleton object, handles enumerating font files in a font collection given a particular type of key. A
		/// given instance can only be registered once. Succeeding attempts will return an error, indicating that it has already been
		/// registered. Note that font file loader implementations must not register themselves with DirectWrite inside their
		/// constructors, and must not unregister themselves inside their destructors, because registration and unregistraton operations
		/// increment and decrement the object reference count respectively. Instead, registration and unregistration with DirectWrite
		/// of font file loaders should be performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontcollectionloader HRESULT
		// RegisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		void RegisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Unregisters a custom font collection loader that was previously registered using RegisterFontCollectionLoader.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be unregistered.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontcollectionloader HRESULT
		// UnregisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		void UnregisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Creates a font file reference object from a local font file.</summary>
		/// <param name="filePath">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the absolute file path for the font file. Subsequent operations on the constructed
		/// object may fail if the user provided filePath doesn't correspond to a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>
		/// The last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain
		/// its last write time. You should specify this value to avoid extra disk access. Subsequent operations on the constructed
		/// object may fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font file reference object, or <c>NULL</c>
		/// in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontfilereference HRESULT
		// CreateFontFileReference( WCHAR const *filePath, FILETIME const *lastWriteTime, IDWriteFontFile **fontFile );
		IDWriteFontFile CreateFontFileReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] IntPtr lastWriteTime);

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
		/// This function is provided for cases when an application or a document needs to use a private font without having to install
		/// it on the system. fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontfilereference HRESULT
		// CreateCustomFontFileReference( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, IDWriteFontFileLoader
		// *fontFileLoader, IDWriteFontFile **fontFile );
		IDWriteFontFile CreateCustomFontFileReference([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, [In] IDWriteFontFileLoader fontFileLoader);

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
		/// The zero-based index of a font face, in cases when the font files contain a collection of font faces. If the font files
		/// contain a single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontFaceSimulationFlags">
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>
		/// A value that indicates which, if any, font face simulation flags for algorithmic means of making text bold or italic are
		/// applied to the current font face.
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
		IDWriteFontFace CreateFontFace(DWRITE_FONT_FACE_TYPE fontFaceType, uint numberOfFiles,
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
		IDWriteRenderingParams CreateRenderingParams();

		/// <summary>
		/// Creates a rendering parameters object with default settings for the specified monitor. In most cases, this is the preferred
		/// way to create a rendering parameters object.
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
		IDWriteRenderingParams CreateMonitorRenderingParams(HMONITOR monitor);

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
		IDWriteRenderingParams CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Registers a font file loader with DirectWrite.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to a IDWriteFontFileLoader object for a particular file resource type.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font file loader with DirectWrite. The font file loader interface, which should be implemented by
		/// a singleton object, handles loading font file resources of a particular type from a key. A given instance can only be
		/// registered once. Succeeding attempts will return an error, indicating that it has already been registered. Note that font
		/// file loader implementations must not register themselves with DirectWrite inside their constructors, and must not unregister
		/// themselves inside their destructors, because registration and unregistraton operations increment and decrement the object
		/// reference count respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be
		/// performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontfileloader HRESULT
		// RegisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		void RegisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Unregisters a font file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to the file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</para>
		/// </param>
		/// <remarks>
		/// This function unregisters font file loader callbacks with the DirectWrite font system. You should implement the font file
		/// loader interface by a singleton object. Note that font file loader implementations must not register themselves with
		/// DirectWrite inside their constructors and must not unregister themselves in their destructors, because registration and
		/// unregistraton operations increment and decrement the object reference count respectively. Instead, registration and
		/// unregistration of font file loaders with DirectWrite should be performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontfileloader HRESULT
		// UnregisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		void UnregisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

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
		// WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STYLE
		// fontStyle, DWRITE_FONT_STRETCH fontStretch, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat **textFormat );
		IDWriteTextFormat CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection, DWRITE_FONT_WEIGHT fontWeight,
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
		IDWriteTypography CreateTypography();

		/// <summary>Creates an object that is used for interoperability with GDI.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteGdiInterop**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a GDI interop object if successful, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getgdiinterop HRESULT GetGdiInterop(
		// IDWriteGdiInterop **gdiInterop );
		IDWriteGdiInterop GetGdiInterop();

		/// <summary>
		/// Takes a string, text format, and associated constraints, and produces an object that represents the fully analyzed and
		/// formatted result.
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
		IDWriteTextLayout CreateTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, float maxWidth, float maxHeight);

		/// <summary>
		/// Takes a string, format, and associated constraints, and produces an object representing the result, formatted for a
		/// particular display resolution and measuring mode.
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
		/// The number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI device
		/// pixelsPerDipis 1. If rendering onto a 120 DPI device pixelsPerDip is 1.25 (120/96).
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specifies the
		/// font size and pixels per DIP.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>BOOL</c></para>
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
		// CreateGdiCompatibleTextLayout( WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT layoutWidth,
		// FLOAT layoutHeight, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, BOOL useGdiNatural, IDWriteTextLayout **textLayout );
		IDWriteTextLayout CreateGdiCompatibleTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat,
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
		/// The ellipsis will be created using the current settings of the format, including base font, style, and any effects.
		/// Alternate omission signs can be created by the application by implementing IDWriteInlineObject.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createellipsistrimmingsign HRESULT
		// CreateEllipsisTrimmingSign( IDWriteTextFormat *textFormat, IDWriteInlineObject **trimmingSign );
		IDWriteInlineObject CreateEllipsisTrimmingSign([In] IDWriteTextFormat textFormat);

		/// <summary>Returns an interface for performing text analysis.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTextAnalyzer**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created text analyzer object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextanalyzer HRESULT
		// CreateTextAnalyzer( IDWriteTextAnalyzer **textAnalyzer );
		IDWriteTextAnalyzer CreateTextAnalyzer();

		/// <summary>
		/// Creates a number substitution object using a locale name, substitution method, and an indicator whether to ignore user
		/// overrides (use NLS defaults for the given culture instead).
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
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether to ignore user overrides.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteNumberSubstitution**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the number substitution object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createnumbersubstitution HRESULT
		// CreateNumberSubstitution( DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, WCHAR const *localeName, BOOL
		// ignoreUserOverride, IDWriteNumberSubstitution **numberSubstitution );
		IDWriteNumberSubstitution CreateNumberSubstitution([In] DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, [MarshalAs(UnmanagedType.LPWStr)] string localeName, [In] [MarshalAs(UnmanagedType.Bool)] bool ignoreUserOverride);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>A structure that contains the properties of the glyph run (font face, advances, and so on).</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI bitmap then
		/// pixelsPerDipis 1. If rendering onto a 120 DPI bitmap then pixelsPerDip is 1.25.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified the
		/// emSize and pixelsPerDip.
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
		IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, float pixelsPerDip, [In, Optional] IntPtr transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, float baselineOriginX, float baselineOriginY);
	}

	/// <summary>
	/// Represents a physical font in a font collection. This interface is used to create font faces from physical fonts, or to retrieve
	/// information such as font face metrics or face names from existing font faces.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefont
	[PInvokeData("dwrite.h", MSDNShortId = "e29e626f-3e63-4c27-934b-64be51dcf3db")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("acd16696-8c14-4f5d-877e-fe3fc1d32737")]
	public interface IDWriteFont
	{
		/// <summary>Gets the font family to which the specified font belongs.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFamily**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the font family object to which the specified font belongs.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getfontfamily HRESULT GetFontFamily(
		// IDWriteFontFamily **fontFamily );
		IDWriteFontFamily GetFontFamily();

		/// <summary>Gets the weight, or stroke thickness, of the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the weight for the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getweight DWRITE_FONT_WEIGHT GetWeight();
		[PreserveSig]
		DWRITE_FONT_WEIGHT GetWeight();

		/// <summary>Gets the stretch, or width, of the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that indicates the type of stretch, or width, applied to the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getstretch DWRITE_FONT_STRETCH GetStretch();
		[PreserveSig]
		DWRITE_FONT_STRETCH GetStretch();

		/// <summary>Gets the style, or slope, of the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that indicates the type of style, or slope, of the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getstyle DWRITE_FONT_STYLE GetStyle();
		[PreserveSig]
		DWRITE_FONT_STYLE GetStyle();

		/// <summary>Determines whether the font is a symbol font.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the font is a symbol font; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-issymbolfont BOOL IsSymbolFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsSymbolFont();

		/// <summary>
		/// Gets a localized strings collection containing the face names for the font (such as Regular or Bold), indexed by locale name.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDWriteLocalizedStrings**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the newly created localized strings object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getfacenames HRESULT GetFaceNames(
		// IDWriteLocalizedStrings **names );
		IDWriteLocalizedStrings GetFaceNames();

		/// <summary>Gets a localized strings collection containing the specified informational strings, indexed by locale name.</summary>
		/// <param name="informationalStringID">
		/// <para>Type: <c>DWRITE_INFORMATIONAL_STRING_ID</c></para>
		/// <para>
		/// A value that identifies the informational string to get. For example, DWRITE_INFORMATIONAL_STRING_DESCRIPTION specifies a
		/// string that contains a description of the font.
		/// </para>
		/// </param>
		/// <param name="informationalStrings">
		/// <para>Type: <c>IDWriteLocalizedStrings**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created localized strings object.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font contains the specified string ID; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <remarks>
		/// If the font does not contain the string specified by informationalStringID, the return value is <c>S_OK</c> but
		/// informationalStrings receives a <c>NULL</c> pointer and exists receives the value <c>FALSE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getinformationalstrings HRESULT
		// GetInformationalStrings( DWRITE_INFORMATIONAL_STRING_ID informationalStringID, IDWriteLocalizedStrings
		// **informationalStrings, BOOL *exists );
		void GetInformationalStrings(DWRITE_INFORMATIONAL_STRING_ID informationalStringID, out IDWriteLocalizedStrings informationalStrings, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Gets a value that indicates what simulations are applied to the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>A value that indicates one or more of the types of simulations (none, bold, or oblique) applied to the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getsimulations DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face
		/// and are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontMetrics">
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a structure that has font metrics for the current font face. The metrics returned by this
		/// function are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getmetrics void GetMetrics(
		// DWRITE_FONT_METRICS *fontMetrics );
		[PreserveSig]
		void GetMetrics(out DWRITE_FONT_METRICS fontMetrics);

		/// <summary>Determines whether the font supports a specified character.</summary>
		/// <param name="unicodeValue">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>A Unicode (UCS-4) character value for the method to inspect.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font supports the specified character; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-hascharacter HRESULT HasCharacter( UINT32
		// unicodeValue, BOOL *exists );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool HasCharacter(uint unicodeValue);

		/// <summary>Creates a font face object for the font.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created font face object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-createfontface HRESULT CreateFontFace(
		// IDWriteFontFace **fontFace );
		IDWriteFontFace CreateFontFace();
	}

	/// <summary>
	/// An object that encapsulates a set of fonts, such as the set of fonts installed on the system, or the set of fonts in a
	/// particular directory. The font collection API can be used to discover what font families and fonts are available, and to obtain
	/// some metadata about the fonts.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The IDWriteFactory::GetSystemFontCollection method will give you an <c>IDWriteFontCollection</c> object, which encapsulates the
	/// set of fonts installed on the system, as shown in the following code example.
	/// </para>
	/// <para>
	/// IDWriteTextFormat and IDWriteTextLayout both have a GetFontCollection method that returns the font collection being used by the
	/// object. These interfaces use the system font collection by default, but can use a custom font collection instead.
	/// </para>
	/// <para>
	/// To determine what fonts are available on the system, get a reference to the system font collection. You can then use the
	/// IDWriteFontCollection::GetFontFamilyCount method to determine the number of fonts and loop through the list. The following
	/// example enumerates the fonts in the system font collection, and prints the font family names to the console.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefontcollection
	[PInvokeData("dwrite.h", MSDNShortId = "2ca7e2d3-d66a-4c57-8fbe-15a5232c3506")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("a84cee02-3eea-4eee-a827-87c1a02a0fcc")]
	public interface IDWriteFontCollection
	{
		/// <summary>Gets the number of font families in the collection.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font families in the collection.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfamilycount UINT32 GetFontFamilyCount();
		[PreserveSig]
		uint GetFontFamilyCount();

		/// <summary>Creates a font family object given a zero-based font family index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font family.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFamily**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created font family object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-getfontfamily HRESULT
		// GetFontFamily( UINT32 index, IDWriteFontFamily **fontFamily );
		IDWriteFontFamily GetFontFamily(uint index);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollection-findfamilyname HRESULT
		// FindFamilyName( WCHAR const *familyName, UINT32 *index, BOOL *exists );
		void FindFamilyName([MarshalAs(UnmanagedType.LPWStr)] string familyName, out uint index, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>
		/// Gets the font object that corresponds to the same physical font as the specified font face object. The specified physical
		/// font must belong to the font collection.
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
		IDWriteFont GetFontFromFontFace([In] IDWriteFontFace fontFace);
	}

	/// <summary>Used to construct a collection of fonts given a particular type of key.</summary>
	/// <remarks>
	/// The font collection loader interface is recommended to be implemented by a singleton object. Note that font collection loader
	/// implementations must not register themselves with DirectWrite factory inside their constructors and must not unregister
	/// themselves in their destructors, because registration and unregistraton operations increment and decrement the object reference
	/// count respectively. Instead, registration and unregistration of font file loaders with DirectWrite factory should be performed
	/// outside of the font file loader implementation as a separate step.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefontcollectionloader
	[PInvokeData("dwrite.h", MSDNShortId = "898645ce-4bd5-4491-a31c-f60a17578872")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("cca920e4-52f0-492b-bfa8-29c72ee0a468")]
	public interface IDWriteFontCollectionLoader
	{
		/// <summary>
		/// Creates a font file enumerator object that encapsulates a collection of font files. The font system calls back to this
		/// interface to create a font collection.
		/// </summary>
		/// <param name="factory">
		///   <para>Type: <c>IDWriteFactory*</c></para>
		///   <para>Pointer to the IDWriteFactory object that was used to create the current font collection.</para>
		/// </param>
		/// <param name="collectionKey">
		///   <para>Type: <c>const void*</c></para>
		///   <para>
		/// A font collection key that uniquely identifies the collection of font files within the scope of the font collection loader
		/// being used. The buffer allocated for this key must be at least the size, in bytes, specified by collectionKeySize.
		/// </para>
		/// </param>
		/// <param name="collectionKeySize">
		///   <para>Type: <c>UINT32</c></para>
		///   <para>The size of the font collection key, in bytes.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>IDWriteFontFileEnumerator**</c></para>
		///   <para>When this method returns, contains the address of a pointer to the newly created font file enumerator.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontcollectionloader-createenumeratorfromkey
		// HRESULT CreateEnumeratorFromKey( IDWriteFactory *factory, void const *collectionKey, UINT32 collectionKeySize,
		// IDWriteFontFileEnumerator **fontFileEnumerator );
		IDWriteFontFileEnumerator? CreateEnumeratorFromKey([In] IDWriteFactory factory, [In] IntPtr collectionKey, uint collectionKeySize);
	}

	/// <summary>
	/// <para>
	/// This interface exposes various font data such as metrics, names, and glyph outlines. It contains font face type, appropriate
	/// file references, and face identification data.
	/// </para>
	/// <para>This interface extends IUnknown.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefontface
	[PInvokeData("dwrite.h", MSDNShortId = "1b6bb9e2-cf01-413c-9ee8-42bb0f703ce8")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5f49804d-7024-4d43-bfa9-d25984f53849")]
	public interface IDWriteFontFace
	{
		/// <summary>Obtains the file format type of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of format for the font face (such as Type 1, TrueType, vector, or bitmap).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-gettype DWRITE_FONT_FACE_TYPE GetType();
		[PreserveSig]
		DWRITE_FONT_FACE_TYPE GetType();

		/// <summary>Obtains the font files representing a font face.</summary>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// If fontFiles is <c>NULL</c>, receives the number of files representing the font face. Otherwise, the number of font files
		/// being requested should be passed. See the Remarks section below for more information.
		/// </para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a user-provided array that stores pointers to font files representing the
		/// font face. This parameter can be <c>NULL</c> if the user wants only the number of files representing the font face. This API
		/// increments reference count of the font file pointers returned according to COM conventions, and the client should release
		/// them when finished.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>IDWriteFontFace::GetFiles</c> method should be called twice. The first time you call <c>GetFiles</c> fontFiles should
		/// be <c>NULL</c>. When the method returns, numberOfFiles receives the number of font files that represent the font face.
		/// </para>
		/// <para>
		/// Then, call the method a second time, passing the numberOfFiles value that was output the first call, and a non-null buffer
		/// of the correct size to store the IDWriteFontFile pointers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getfiles HRESULT GetFiles( UINT32
		// *numberOfFiles, IDWriteFontFile **fontFiles );
		void GetFiles(ref uint numberOfFiles, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[]? fontFiles);

		/// <summary>Obtains the index of a font face in the context of its font files.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font files contain a collection of font faces. If the font files
		/// contain a single face, this value is zero.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getindex UINT32 GetIndex();
		[PreserveSig]
		uint GetIndex();

		/// <summary>Obtains the algorithmic style simulation flags of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>Font face simulation flags for algorithmic means of making text bold or italic.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getsimulations DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>Determines whether the font is a symbol font.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the font is a symbol font, otherwise <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-issymbolfont BOOL IsSymbolFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsSymbolFont();

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face
		/// and are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontFaceMetrics">
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// When this method returns, a DWRITE_FONT_METRICS structure that holds metrics (such as ascent, descent, or cap height) for
		/// the current font face element. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getmetrics void GetMetrics(
		// DWRITE_FONT_METRICS *fontFaceMetrics );
		[PreserveSig]
		void GetMetrics(out DWRITE_FONT_METRICS fontFaceMetrics);

		/// <summary>Obtains the number of glyphs in the font face.</summary>
		/// <returns>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The number of glyphs in the font face.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphcount UINT16 GetGlyphCount();
		[PreserveSig]
		ushort GetGlyphCount();

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
		/// When this method returns, contains an array of DWRITE_GLYPH_METRICS structures. glyphMetrics must be initialized with an
		/// empty buffer that contains at least as many elements as glyphCount. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has oblique
		/// simulation because sideways oblique simulation differs from non-sideways oblique simulation
		/// </para>
		/// </param>
		/// <remarks>Design glyph metrics are used for glyph positioning.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getdesignglyphmetrics HRESULT
		// GetDesignGlyphMetrics( UINT16 const *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, BOOL isSideways );
		void GetDesignGlyphMetrics([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>Returns the nominal mapping of UCS4 Unicode code points to glyph indices as defined by the font 'CMAP' table.</summary>
		/// <param name="codePoints">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>
		/// An array of USC4 code points from which to obtain nominal glyph indices. The array must be allocated and be able to contain
		/// the number of elements specified by codePointCount.
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
		/// Note that this mapping is primarily provided for line layout engines built on top of the physical font API. Because of
		/// OpenType glyph substitution and line layout character substitution, the nominal conversion does not always correspond to how
		/// a Unicode string will map to glyph indices when rendering using a particular font face. Also, note that Unicode variant
		/// selectors provide for alternate mappings for character to glyph. This call will always return the default variant.
		/// </para>
		/// <para>
		/// When characters are not present in the font this method returns the index 0, which is the undefined glyph or ".notdef"
		/// glyph. If a character isn't in a font, IDWriteFont::HasCharacter returns false and GetUnicodeRanges doesn't return it in the range.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphindices HRESULT GetGlyphIndices(
		// UINT32 const *codePoints, UINT32 codePointCount, UINT16 *glyphIndices );
		void GetGlyphIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] codePoints, uint codePointCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices);

		/// <summary>
		/// Finds the specified OpenType font table if it exists and returns a pointer to it. The function accesses the underlying font
		/// data through the IDWriteFontFileStream interface implemented by the font file loader.
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
		/// long as the font face used to get the font table still exists; (not any other font face, even if it actually refers to the
		/// same physical font). This parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tableSize">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains a pointer to the size, in bytes, of the font table.</para>
		/// </param>
		/// <param name="tableContext">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, the address of a pointer to the opaque context, which must be freed by calling ReleaseFontTable.
		/// The context actually comes from the lower-level IDWriteFontFileStream, which may be implemented by the application or DWrite
		/// itself. It is possible for a <c>NULL</c> tableContext to be returned, especially if the implementation performs direct
		/// memory mapping on the whole file. Nevertheless, always release it later, and do not use it as a test for function success.
		/// The same table can be queried multiple times, but because each returned context can be different, you must release each
		/// context separately.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font table exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The context for the same tag may be different for each call, so each one must be held and released separately.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-trygetfonttable HRESULT TryGetFontTable(
		// UINT32 openTypeTableTag, const void **tableData, UINT32 *tableSize, void **tableContext, BOOL *exists );
		HRESULT TryGetFontTable([In] uint openTypeTableTag, out IntPtr tableData, out uint tableSize, out IntPtr tableContext, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Releases the table obtained earlier from TryGetFontTable.</summary>
		/// <param name="tableContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the opaque context from TryGetFontTable.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-releasefonttable void ReleaseFontTable(
		// void *tableContext );
		[PreserveSig]
		void ReleaseFontTable([In] IntPtr tableContext);

		/// <summary>Computes the outline of a run of glyphs by calling back to the outline sink interface.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices. The glyphs are in logical order and the advance direction depends on the isRightToLeft parameter.
		/// The array must be allocated and be able to contain the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An optional array of glyph advances in DIPs. The advance of a glyph is the amount to advance the position (in the direction
		/// of the baseline) after drawing the glyph. glyphAdvances contains the number of elements specified by glyphCount.
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
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If <c>TRUE</c>, the ascender of the glyph runs alongside the baseline. If <c>FALSE</c>, the glyph ascender runs
		/// perpendicular to the baseline. For example, an English alphabet on a vertical baseline would have isSideways set to <c>FALSE</c>.
		/// </para>
		/// <para>
		/// A client can render a vertical run by setting isSideways to <c>TRUE</c> and rotating the resulting geometry 90 degrees to
		/// the right using a transform. The isSideways and isRightToLeft parameters cannot both be true.
		/// </para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// The visual order of the glyphs. If this parameter is <c>FALSE</c>, then glyph advances are from left to right. If
		/// <c>TRUE</c>, the advance direction is right to left. By default, the advance direction is left to right.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: <c>IDWriteGeometrySink*</c></para>
		/// <para>A pointer to the interface that is called back to perform outline drawing operations.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphrunoutline HRESULT
		// GetGlyphRunOutline( FLOAT emSize, UINT16 const *glyphIndices, FLOAT const *glyphAdvances, DWRITE_GLYPH_OFFSET const
		// *glyphOffsets, UINT32 glyphCount, BOOL isSideways, BOOL isRightToLeft, IDWriteGeometrySink *geometrySink );
		void GetGlyphRunOutline(float emSize, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] glyphIndices,
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
		/// The number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96, this value is 1.0f. If the
		/// DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes
		/// for different measuring methods, for example:
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
		DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float emSize, float pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams renderingParams);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface
		/// and are used by applications for layout calculations.
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
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by
		/// the font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// A pointer to a DWRITE_FONT_METRICS structure to fill in. The metrics returned by this function are in font design units.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, DWRITE_FONT_METRICS
		// *fontFaceMetrics );
		DWRITE_FONT_METRICS GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform);

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
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by
		/// the font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// When set to <c>FALSE</c>, the metrics are the same as the metrics of GDI aliased text. When set to <c>TRUE</c>, the metrics
		/// are the same as the metrics of text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
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
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A BOOL value that indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font
		/// has oblique simulation because sideways oblique simulation differs from non-sideways oblique simulation.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatibleglyphmetrics HRESULT
		// GetGdiCompatibleGlyphMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, BOOL useGdiNatural, UINT16
		// const *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, BOOL isSideways );
		void GetGdiCompatibleGlyphMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);
	}

	/// <summary>Represents a family of related fonts.</summary>
	/// <remarks>
	/// <para>
	/// A font family is a set of fonts that share the same family name, such as "Times New Roman", but that differ in features. These
	/// feature differences include style, such as italic, and weight, such as bold.
	/// </para>
	/// <para>The following illustration shows examples of fonts that are members of the "Times New Roman" font family.</para>
	/// <para>
	/// An <c>IDWriteFontFamily</c> object can be retrieved from a font collection using the IDWriteFontCollection::GetFontFamily method
	/// shown in the following example. GetFontFamily takes a <c>UINT32</c> index and returns the font family for the font at that index.
	/// </para>
	/// <para>
	/// The font family name is used to specify the font family for text layout and text format objects. You can get a list of localized
	/// font family names from an <c>IDWriteFontFamily</c> object in the form of an IDWriteLocalizedStrings object by using the
	/// IDWriteFontFamily::GetFamilyNames method, as shown in the following code.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefontfamily
	[PInvokeData("dwrite.h", MSDNShortId = "1fce3d62-af4e-4d2b-a3fd-e534b5fcdb13")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("da20d8ef-812a-4c43-9802-62ec4abd7add")]
	public interface IDWriteFontFamily : IDWriteFontList
	{
		/// <summary>Gets the font collection that contains the fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the current IDWriteFontCollection object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcollection HRESULT
		// GetFontCollection( IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the number of fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of fonts in the font list.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		new uint GetFontCount();

		/// <summary>Gets a font given its zero-based index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created IDWriteFont object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfont HRESULT GetFont( UINT32 index,
		// IDWriteFont **font );
		new IDWriteFont GetFont(uint index);

		/// <summary>Creates a localized strings object that contains the family names for the font family, indexed by locale name.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteLocalizedStrings**</c></para>
		/// <para>The address of a pointer to the newly created IDWriteLocalizedStrings object.</para>
		/// </returns>
		/// <remarks>The following code example shows how to get the font family name from a IDWriteFontFamily object.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getfamilynames HRESULT GetFamilyNames(
		// IDWriteLocalizedStrings **names );
		IDWriteLocalizedStrings GetFamilyNames();

		/// <summary>Gets the font that best matches the specified properties.</summary>
		/// <param name="weight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that is used to match a requested font weight.</para>
		/// </param>
		/// <param name="stretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that is used to match a requested font stretch.</para>
		/// </param>
		/// <param name="style">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that is used to match a requested font style.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created IDWriteFont object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getfirstmatchingfont HRESULT
		// GetFirstMatchingFont( DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style, IDWriteFont
		// **matchingFont );
		IDWriteFont GetFirstMatchingFont(DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style);

		/// <summary>Gets a list of fonts in the font family ranked in order of how well they match the specified properties.</summary>
		/// <param name="weight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that is used to match a requested font weight.</para>
		/// </param>
		/// <param name="stretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that is used to match a requested font stretch.</para>
		/// </param>
		/// <param name="style">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that is used to match a requested font style.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontList**</c></para>
		/// <para>An address of a pointer to the newly created IDWriteFontList object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getmatchingfonts HRESULT
		// GetMatchingFonts( DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style, IDWriteFontList
		// **matchingFonts );
		IDWriteFontList GetMatchingFonts(DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style);
	}

	/// <summary>
	/// Represents a font file. Applications such as font managers or font viewers can call IDWriteFontFile::Analyze to find out if a
	/// particular file is a font file, and whether it is a font type that is supported by the font system.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefontfile
	[PInvokeData("dwrite.h", MSDNShortId = "d4be5466-0b6c-4cc5-9f16-aa00c6037eb9")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("739d886a-cef5-47dc-8769-1a8b41bebbb0")]
	public interface IDWriteFontFile
	{
		/// <summary>
		/// Obtains the pointer to the reference key of a font file. The returned pointer is valid until the font file object is released.
		/// </summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <c>const void**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the font file reference key. Note that the pointer value is
		/// only valid until the font file object it is obtained from is released. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the size of the font file reference key in bytes. This parameter is passed uninitialized.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfile-getreferencekey HRESULT GetReferenceKey(
		// void const **fontFileReferenceKey, UINT32 *fontFileReferenceKeySize );
		void GetReferenceKey(out IntPtr fontFileReferenceKey, out uint fontFileReferenceKeySize);

		/// <summary>Obtains the file loader associated with a font file object.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFileLoader**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the font file loader associated with the font file object.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfile-getloader HRESULT GetLoader(
		// IDWriteFontFileLoader **fontFileLoader );
		IDWriteFontFileLoader GetLoader();

		/// <summary>
		/// Analyzes a file and returns whether it represents a font, and whether the font type is supported by the font system.
		/// </summary>
		/// <param name="isSupportedFontType">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para><c>TRUE</c> if the font type is supported by the font system; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <param name="fontFileType">
		/// <para>Type: <c>DWRITE_FONT_FILE_TYPE*</c></para>
		/// <para>
		/// When this method returns, contains a value that indicates the type of the font file. Note that even if isSupportedFontType
		/// is <c>FALSE</c>, the fontFileType value may be different from <c>DWRITE_FONT_FILE_TYPE_UNKNOWN</c>.
		/// </para>
		/// </param>
		/// <param name="fontFaceType">
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE*</c></para>
		/// <para>
		/// When this method returns, contains a value that indicates the type of the font face. If fontFileType is not equal to
		/// <c>DWRITE_FONT_FILE_TYPE_UNKNOWN</c>, then that can be constructed from the font file.
		/// </para>
		/// </param>
		/// <param name="numberOfFaces">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the number of font faces contained in the font file.</para>
		/// </param>
		/// <remarks>
		/// <c>Important</c> Certain font file types are recognized, but not supported by the font system. For example, the font system
		/// will recognize a file as a Type 1 font file but will not be able to construct a font face object from it. In such
		/// situations, <c>Analyze</c> will set isSupportedFontType output parameter to <c>FALSE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfile-analyze HRESULT Analyze( BOOL
		// *isSupportedFontType, DWRITE_FONT_FILE_TYPE *fontFileType, DWRITE_FONT_FACE_TYPE *fontFaceType, UINT32 *numberOfFaces );
		void Analyze([MarshalAs(UnmanagedType.Bool)] out bool isSupportedFontType, out DWRITE_FONT_FILE_TYPE fontFileType, out DWRITE_FONT_FACE_TYPE fontFaceType, out uint numberOfFaces);
	}

	/// <summary>
	/// Encapsulates a collection of font files. The font system uses this interface to enumerate font files when building a font collection.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefontfileenumerator
	[PInvokeData("dwrite.h", MSDNShortId = "d89efffd-ccda-4d55-8419-de142b0f9652")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("72755049-5ff7-435d-8348-4be97cfa6c7c")]
	public interface IDWriteFontFileEnumerator
	{
		/// <summary>
		/// Advances to the next font file in the collection. When it is first created, the enumerator is positioned before the first
		/// element of the collection and the first call to <c>MoveNext</c> advances to the first file.
		/// </summary>
		/// <returns>
		///   <para>Type: <c>BOOL*</c></para>
		///   <para>
		/// When the method returns, contains the value <c>TRUE</c> if the enumerator advances to a file; otherwise, <c>FALSE</c> if the
		/// enumerator advances past the last file in the collection.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfileenumerator-movenext HRESULT MoveNext( BOOL
		// *hasCurrentFile );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool MoveNext();

		/// <summary>Gets a reference to the current font file.</summary>
		/// <returns>
		///   <para>Type: <c>IDWriteFontFile**</c></para>
		///   <para>When this method returns, the address of a pointer to the newly created IDWriteFontFile object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfileenumerator-getcurrentfontfile HRESULT
		// GetCurrentFontFile( IDWriteFontFile **fontFile );
		IDWriteFontFile? GetCurrentFontFile();
	}

	/// <summary>
	/// Handles loading font file resources of a particular type from a font file reference key into a font file stream object.
	/// </summary>
	/// <remarks>
	/// The font file loader interface is recommended to be implemented by a singleton object. Note that font file loader
	/// implementations must not register themselves with DirectWrite factory inside their constructors and must not unregister
	/// themselves in their destructors, because registration and unregistraton operations increment and decrement the object reference
	/// count respectively. Instead, registration and unregistration of font file loaders with DirectWrite factory should be performed
	/// outside of the font file loader implementation as a separate step.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefontfileloader
	[PInvokeData("dwrite.h", MSDNShortId = "855e281e-3855-4c11-af87-68f8e0dadbf8")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("727cad4e-d6af-4c9e-8a08-d695b11caa49")]
	public interface IDWriteFontFileLoader
	{
		/// <summary>Creates a font file stream object that encapsulates an open file resource.</summary>
		/// <param name="fontFileReferenceKey">
		///   <para>Type: <c>const void*</c></para>
		///   <para>A pointer to a font file reference key that uniquely identifies the font file resource within the scope of the font loader being used. The buffer allocated for this key must at least be the size, in bytes, specified by fontFileReferenceKeySize.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		///   <para>Type: <c>UINT32</c></para>
		///   <para>The size of font file reference key, in bytes.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>IDWriteFontFileStream**</c></para>
		///   <para>When this method returns, contains the address of a pointer to the newly created IDWriteFontFileStream object.</para>
		/// </returns>
		/// <remarks>The resource is closed when the last reference to fontFileStream is released.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfileloader-createstreamfromkey
		// HRESULT CreateStreamFromKey( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, IDWriteFontFileStream **fontFileStream );
		IDWriteFontFileStream? CreateStreamFromKey([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize);
	}

	/// <summary>Loads font file data from a custom font file loader.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefontfilestream
	[PInvokeData("dwrite.h", MSDNShortId = "792ab9be-853f-427d-a762-2da8e81423f8")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6d4865fe-0ab8-4d91-8f62-5dd6be34a3e0")]
	public interface IDWriteFontFileStream
	{
		/// <summary>Reads a fragment from a font file.</summary>
		/// <param name="fragmentStart">
		///   <para>Type: <c>const void**</c></para>
		///   <para>When this method returns, contains an address of a pointer to the start of the font file fragment. This parameter is passed uninitialized.</para>
		/// </param>
		/// <param name="fileOffset">
		///   <para>Type: <c>UINT64</c></para>
		///   <para>The offset of the fragment, in bytes, from the beginning of the font file.</para>
		/// </param>
		/// <param name="fragmentSize">
		///   <para>Type: <c>UINT64</c></para>
		///   <para>The size of the file fragment, in bytes.</para>
		/// </param>
		/// <param name="fragmentContext">
		///   <para>Type: <c>void**</c></para>
		///   <para>When this method returns, contains the address of a pointer to a pointer to the client-defined context to be passed to ReleaseFileFragment.</para>
		/// </param>
		/// <remarks>
		///   <para>Note that <c>ReadFileFragment</c> implementations must check whether the requested font file fragment is within the file bounds. Otherwise, an error should be returned from <c>ReadFileFragment</c>.</para>
		///   <para>DirectWrite may invoke IDWriteFontFileStream methods on the same object from multiple threads simultaneously. Therefore, <c>ReadFileFragment</c> implementations that rely on internal mutable state must serialize access to such state across multiple threads. For example, an implementation that uses separate Seek and Read operations to read a file fragment must place the code block containing Seek and Read calls under a lock or a critical section.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfilestream-readfilefragment
		// HRESULT ReadFileFragment( void const **fragmentStart, UINT64 fileOffset, UINT64 fragmentSize, void **fragmentContext );
		void ReadFileFragment(out IntPtr fragmentStart, ulong fileOffset, ulong fragmentSize, [Out] out IntPtr fragmentContext);

		/// <summary>Releases a fragment from a file.</summary>
		/// <param name="fragmentContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the client-defined context of a font fragment returned from ReadFileFragment.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfilestream-releasefilefragment void
		// ReleaseFileFragment( void *fragmentContext );
		[PreserveSig]
		void ReleaseFileFragment([In] IntPtr fragmentContext);

		/// <summary>Obtains the total size of a file.</summary>
		/// <returns>
		///   <para>Type: <c>UINT64*</c></para>
		///   <para>When this method returns, contains the total size of the file.</para>
		/// </returns>
		/// <remarks>Implementing <c>GetFileSize</c>() for asynchronously loaded font files may require downloading the complete file contents. Therefore, this method should be used only for operations that either require a complete font file to be loaded (for example, copying a font file) or that need to make decisions based on the value of the file size (for example, validation against a persisted file size).</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfilestream-getfilesize
		// HRESULT GetFileSize( UINT64 *fileSize );
		ulong GetFileSize();

		/// <summary>Obtains the last modified time of the file.</summary>
		/// <returns>
		///   <para>Type: <c>UINT64*</c></para>
		///   <para>When this method returns, contains the last modified time of the file in the format that represents the number of 100-nanosecond intervals since January 1, 1601 (UTC).</para>
		/// </returns>
		/// <remarks>The "last modified time" is used by DirectWrite font selection algorithms to determine whether one font resource is more up to date than another one.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfilestream-getlastwritetime
		// HRESULT GetLastWriteTime( UINT64 *lastWriteTime );
		FILETIME GetLastWriteTime();
	}

	/// <summary>Represents a list of fonts.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefontlist
	[PInvokeData("dwrite.h", MSDNShortId = "00c41c5f-4405-45ff-98e5-03858dc3056f")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1a0d8438-1d97-4ec1-aef9-a2fb86ed6acb")]
	public interface IDWriteFontList
	{
		/// <summary>Gets the font collection that contains the fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the current IDWriteFontCollection object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcollection HRESULT
		// GetFontCollection( IDWriteFontCollection **fontCollection );
		IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the number of fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of fonts in the font list.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		uint GetFontCount();

		/// <summary>Gets a font given its zero-based index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created IDWriteFont object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfont HRESULT GetFont( UINT32 index,
		// IDWriteFont **font );
		IDWriteFont GetFont(uint index);
	}

	/// <summary>
	/// Provides interoperability with GDI, such as methods to convert a font face to a LOGFONT structure, or to convert a GDI font
	/// description into a font face. It is also used to create bitmap render target objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritegdiinterop
	[PInvokeData("dwrite.h", MSDNShortId = "79472021-ee12-45dd-a943-3908c9e06cde")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1edd9491-9853-4299-898f-6432983b6f3a")]
	public interface IDWriteGdiInterop
	{
		/// <summary>Creates a font object that matches the properties specified by the <c>LOGFONT</c> structure.</summary>
		/// <param name="logFont">
		/// <para>Type: <c>const LOGFONTW*</c></para>
		/// <para>A structure containing a GDI-compatible font description.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a newly created IDWriteFont object if successful; otherwise, <c>NULL</c>.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritegdiinterop-createfontfromlogfont HRESULT
		// CreateFontFromLOGFONT( LOGFONTW const *logFont, IDWriteFont **font );
		IDWriteFont CreateFontFromLOGFONT(in LOGFONT logFont);

		/// <summary>Initializes a <c>LOGFONT</c> structure based on the GDI-compatible properties of the specified font.</summary>
		/// <param name="font">
		/// <para>Type: <c>IDWriteFont*</c></para>
		/// <para>An IDWriteFont object to be converted into a GDI-compatible <c>LOGFONT</c> structure.</para>
		/// </param>
		/// <param name="logFont">
		/// <para>Type: <c>LOGFONTW*</c></para>
		/// <para>When this method returns, contains a structure that receives a GDI-compatible font description.</para>
		/// </param>
		/// <param name="isSystemFont">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// When this method returns, contains <c>TRUE</c> if the specified font object is part of the system font collection;
		/// otherwise, <c>FALSE</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// The conversion to a <c>LOGFONT</c> by using <c>ConvertFontToLOGFONT</c> operates at the logical font level and does not
		/// guarantee that it will map to a specific physical font. It is not guaranteed that GDI will select the same physical font for
		/// displaying text formatted by a <c>LOGFONT</c> as the IDWriteFont object that was converted.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritegdiinterop-convertfonttologfont HRESULT
		// ConvertFontToLOGFONT( IDWriteFont *font, LOGFONTW *logFont, BOOL *isSystemFont );
		void ConvertFontToLOGFONT([In] IDWriteFont font, out LOGFONT logFont, [MarshalAs(UnmanagedType.Bool)] out bool isSystemFont);

		/// <summary>Initializes a LOGFONT structure based on the GDI-compatible properties of the specified font.</summary>
		/// <param name="font">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>An IDWriteFontFace object to be converted into a GDI-compatible LOGFONT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LOGFONTW*</c></para>
		/// <para>When this method returns, contains a pointer to a structure that receives a GDI-compatible font description.</para>
		/// </returns>
		/// <remarks>
		/// The conversion to a LOGFONT by using <c>ConvertFontFaceToLOGFONT</c> operates at the logical font level and does not
		/// guarantee that it will map to a specific physical font. It is not guaranteed that GDI will select the same physical font for
		/// displaying text formatted by a LOGFONT as the IDWriteFont object that was converted.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritegdiinterop-convertfontfacetologfont HRESULT
		// ConvertFontFaceToLOGFONT( IDWriteFontFace *font, LOGFONTW *logFont );
		LOGFONT ConvertFontFaceToLOGFONT([In] IDWriteFontFace font);

		/// <summary>
		/// Creates an <c>IDWriteFontFace</c> object that corresponds to the currently selected <c>HFONT</c> of the specified <c>HDC</c>.
		/// </summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>
		/// A handle to a device context into which a font has been selected. It is assumed that the client has already performed font
		/// mapping and that the font selected into the device context is the actual font to be used for rendering glyphs.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>
		/// Contains an address of a pointer to the newly created font face object, or <c>NULL</c> in case of failure. The font face
		/// returned is guaranteed to reference the same physical typeface that would be used for drawing glyphs (but not necessarily
		/// characters) using ExtTextOut.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function is intended for scenarios in which an application wants to use GDI and Uniscribe 1.x for text layout and
		/// shaping, but DirectWrite for final rendering. This function assumes the client is performing text output using glyph indexes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritegdiinterop-createfontfacefromhdc HRESULT
		// CreateFontFaceFromHdc( HDC hdc, IDWriteFontFace **fontFace );
		IDWriteFontFace CreateFontFaceFromHdc(HDC hdc);

		/// <summary>
		/// Creates an object that encapsulates a bitmap and memory DC (device context) which can be used for rendering glyphs.
		/// </summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>A handle to the optional device context used to create a compatible memory DC (device context).</para>
		/// </param>
		/// <param name="width">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The width of the bitmap render target.</para>
		/// </param>
		/// <param name="height">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The height of the bitmap render target.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteBitmapRenderTarget**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created IDWriteBitmapRenderTarget object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritegdiinterop-createbitmaprendertarget HRESULT
		// CreateBitmapRenderTarget( HDC hdc, UINT32 width, UINT32 height, IDWriteBitmapRenderTarget **renderTarget );
		IDWriteBitmapRenderTarget CreateBitmapRenderTarget([In, Optional] HDC hdc, uint width, uint height);
	}

	/// <summary>Contains low-level information used to render a glyph run.</summary>
	/// <remarks>
	/// <para>The alpha texture can be a bi-level alpha texture or a ClearType alpha texture.</para>
	/// <para>
	/// A bi-level alpha texture contains one byte per pixel, therefore the size of the buffer for a bi-level texture will be the area
	/// of the texture bounds, in bytes. Each byte in a bi-level alpha texture created by CreateAlphaTexture is either set to
	/// DWRITE_ALPHA_MAX (that is, 255) or zero.
	/// </para>
	/// <para>
	/// A ClearType alpha texture contains three bytes per pixel, therefore the size of the buffer for a ClearType alpha texture is
	/// three times the area of the texture bounds, in bytes.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows how to create a glyph run analysis object. In this example, an empty glyph run is being used.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwriteglyphrunanalysis
	[PInvokeData("dwrite.h", MSDNShortId = "d4739b55-1a9b-4346-9b47-d8adb98df163")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7d97dbf7-e085-42d4-81e3-6a883bded118")]
	public interface IDWriteGlyphRunAnalysis
	{
		/// <summary>Gets the bounding rectangle of the physical pixels affected by the glyph run.</summary>
		/// <param name="textureType">
		/// <para>Type: <c>DWRITE_TEXTURE_TYPE</c></para>
		/// <para>
		/// Specifies the type of texture requested. If a bi-level texture is requested, the bounding rectangle includes only bi-level
		/// glyphs. Otherwise, the bounding rectangle includes only antialiased glyphs.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>RECT*</c></para>
		/// <para>
		/// When this method returns, contains the bounding rectangle of the physical pixels affected by the glyph run, or an empty
		/// rectangle if there are no glyphs of the specified texture type.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriteglyphrunanalysis-getalphatexturebounds HRESULT
		// GetAlphaTextureBounds( DWRITE_TEXTURE_TYPE textureType, RECT *textureBounds );
		RECT GetAlphaTextureBounds(DWRITE_TEXTURE_TYPE textureType);

		/// <summary>Creates an alpha texture of the specified type for glyphs within a specified bounding rectangle.</summary>
		/// <param name="textureType">
		/// <para>Type: <c>DWRITE_TEXTURE_TYPE</c></para>
		/// <para>
		/// A value that specifies the type of texture requested. This can be DWRITE_TEXTURE_BILEVEL_1x1 or
		/// <c>DWRITE_TEXTURE_CLEARTYPE_3x1</c>. If a bi-level texture is requested, the texture contains only bi-level glyphs.
		/// Otherwise, the texture contains only antialiased glyphs.
		/// </para>
		/// </param>
		/// <param name="textureBounds">
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>The bounding rectangle of the texture, which can be different than the bounding rectangle returned by GetAlphaTextureBounds.</para>
		/// </param>
		/// <param name="alphaValues">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>
		/// When this method returns, contains the array of alpha values from the texture. The buffer allocated for this array must be
		/// at least the size of bufferSize.
		/// </para>
		/// </param>
		/// <param name="bufferSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the alphaValues array, in bytes. The minimum size depends on the dimensions of the rectangle and the type of
		/// texture requested.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriteglyphrunanalysis-createalphatexture HRESULT
		// CreateAlphaTexture( DWRITE_TEXTURE_TYPE textureType, RECT const *textureBounds, BYTE *alphaValues, UINT32 bufferSize );
		void CreateAlphaTexture(DWRITE_TEXTURE_TYPE textureType, in RECT textureBounds, [Out] IntPtr alphaValues, uint bufferSize);

		/// <summary>Gets alpha blending properties required for ClearType blending.</summary>
		/// <param name="renderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>
		/// An object that specifies the ClearType level and enhanced contrast, gamma, pixel geometry, and rendering mode. In most
		/// cases, the values returned by the output parameters of this method are based on the properties of this object, unless a
		/// GDI-compatible rendering mode was specified.
		/// </para>
		/// </param>
		/// <param name="blendGamma">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the gamma value to use for gamma correction.</para>
		/// </param>
		/// <param name="blendEnhancedContrast">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the enhanced contrast value to be used for blending.</para>
		/// </param>
		/// <param name="blendClearTypeLevel">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the ClearType level used in the alpha blending.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriteglyphrunanalysis-getalphablendparams HRESULT
		// GetAlphaBlendParams( IDWriteRenderingParams *renderingParams, FLOAT *blendGamma, FLOAT *blendEnhancedContrast, FLOAT
		// *blendClearTypeLevel );
		void GetAlphaBlendParams([In] IDWriteRenderingParams renderingParams, out float blendGamma, out float blendEnhancedContrast, out float blendClearTypeLevel);
	}

	/// <summary>
	/// Wraps an application-defined inline graphic, allowing DWrite to query metrics as if the graphic were a glyph inline with the text.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwriteinlineobject
	[PInvokeData("dwrite.h", MSDNShortId = "cf915458-acbc-4a37-be5c-b1337153f386")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("8339FDE3-106F-47ab-8373-1C6295EB10B3")]
	public interface IDWriteInlineObject
	{
		/// <summary>
		/// The application implemented rendering callback (IDWriteTextRenderer::DrawInlineObject) can use this to draw the inline
		/// object without needing to cast or query the object type. The text layout does not call this method directly.
		/// </summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The drawing context passed to IDWriteTextLayout::Draw. This parameter may be <c>NULL</c>.</para>
		/// </param>
		/// <param name="renderer">
		/// <para>Type: <c>IDWriteTextRenderer*</c></para>
		/// <para>
		/// The same renderer passed to IDWriteTextLayout::Draw as the object's containing parent. This is useful if the inline object
		/// is recursive such as a nested layout.
		/// </para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate at the upper-left corner of the inline object.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate at the upper-left corner of the inline object.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether the object's baseline runs alongside the baseline axis of the line.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether the object is in a right-to-left context and should be drawn flipped.</para>
		/// </param>
		/// <param name="clientDrawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// The drawing effect set in IDWriteTextLayout::SetDrawingEffect. Usually this effect is a foreground brush that is used in
		/// glyph drawing.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriteinlineobject-draw HRESULT Draw( void
		// *clientDrawingContext, IDWriteTextRenderer *renderer, FLOAT originX, FLOAT originY, BOOL isSideways, BOOL isRightToLeft,
		// IUnknown *clientDrawingEffect );
		void Draw([In, Optional] IntPtr clientDrawingContext, [In] IDWriteTextRenderer renderer, float originX, float originY,
			[MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft, [In, Optional, MarshalAs(UnmanagedType.Interface)] object clientDrawingEffect);

		/// <summary>IDWriteTextLayout calls this callback function to get the measurement of the inline object.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_INLINE_OBJECT_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a structure describing the geometric measurement of an application-defined inline object.
		/// These metrics are in relation to the baseline of the adjacent text.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriteinlineobject-getmetrics HRESULT GetMetrics(
		// DWRITE_INLINE_OBJECT_METRICS *metrics );
		DWRITE_INLINE_OBJECT_METRICS GetMetrics();

		/// <summary>
		/// <para>
		/// IDWriteTextLayout calls this callback function to get the visible extents (in DIPs) of the inline object. In the case of a
		/// simple bitmap, with no padding and no overhang, all the overhangs will simply be zeroes.
		/// </para>
		/// <para>
		/// The overhangs should be returned relative to the reported size of the object (see DWRITE_INLINE_OBJECT_METRICS), and should
		/// not be baseline adjusted.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_OVERHANG_METRICS*</c></para>
		/// <para>Overshoot of visible extents (in DIPs) outside the object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriteinlineobject-getoverhangmetrics HRESULT
		// GetOverhangMetrics( DWRITE_OVERHANG_METRICS *overhangs );
		DWRITE_OVERHANG_METRICS GetOverhangMetrics();

		/// <summary>Layout uses this to determine the line-breaking behavior of the inline object among the text.</summary>
		/// <param name="breakConditionBefore">
		/// <para>Type: <c>DWRITE_BREAK_CONDITION*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the line-breaking condition between the object and the content
		/// immediately preceding it.
		/// </para>
		/// </param>
		/// <param name="breakConditionAfter">
		/// <para>Type: <c>DWRITE_BREAK_CONDITION*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the line-breaking condition between the object and the content
		/// immediately following it.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriteinlineobject-getbreakconditions HRESULT
		// GetBreakConditions( DWRITE_BREAK_CONDITION *breakConditionBefore, DWRITE_BREAK_CONDITION *breakConditionAfter );
		void GetBreakConditions(out DWRITE_BREAK_CONDITION breakConditionBefore, out DWRITE_BREAK_CONDITION breakConditionAfter);
	}

	/// <summary>
	/// A built-in implementation of the <c>IDWriteFontFileLoader</c> interface, that operates on local font files and exposes local
	/// font file information from the font file reference key. Font file references created using <c>CreateFontFileReference</c> use
	/// this font file loader.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/directwrite/idwritelocalfontfileloader
	[PInvokeData("dwrite.h", MSDNShortId = "acb777c8-24c6-452e-8f58-8fb2ad8c0b6c")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b2d9f3ec-c9fe-4a11-a2ec-d86208f7c0a2")]
	public interface IDWriteLocalFontFileLoader : IDWriteFontFileLoader
	{
		/// <summary>Creates a font file stream object that encapsulates an open file resource.</summary>
		/// <param name="fontFileReferenceKey">
		///   <para>Type: <c>const void*</c></para>
		///   <para>A pointer to a font file reference key that uniquely identifies the font file resource within the scope of the font loader being used. The buffer allocated for this key must at least be the size, in bytes, specified by fontFileReferenceKeySize.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		///   <para>Type: <c>UINT32</c></para>
		///   <para>The size of font file reference key, in bytes.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>IDWriteFontFileStream**</c></para>
		///   <para>When this method returns, contains the address of a pointer to the newly created IDWriteFontFileStream object.</para>
		/// </returns>
		/// <remarks>The resource is closed when the last reference to fontFileStream is released.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfileloader-createstreamfromkey
		// HRESULT CreateStreamFromKey( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, IDWriteFontFileStream **fontFileStream );
		new IDWriteFontFileStream? CreateStreamFromKey([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize);

		/// <summary>Obtains the length of the absolute file path from the font file reference key.</summary>
		/// <param name="fontFileReferenceKey">
		///   <para>Type: <c>const void*</c></para>
		///   <para>Font file reference key that uniquely identifies the local font file within the scope of the font loader being used.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		///   <para>Type: <c>UINT32</c></para>
		///   <para>Size of font file reference key in bytes.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>UINT32*</c></para>
		///   <para>Length of the file path string, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritelocalfontfileloader-getfilepathlengthfromkey
		// HRESULT GetFilePathLengthFromKey( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, UINT32 *filePathLength );
		uint GetFilePathLengthFromKey(IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize);

		/// <summary>Obtains the absolute font file path from the font file reference key.</summary>
		/// <param name="fontFileReferenceKey">
		///   <para>Type: <c>const void*</c></para>
		///   <para>The font file reference key that uniquely identifies the local font file within the scope of the font loader being used.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		///   <para>Type: <c>UINT32</c></para>
		///   <para>The size of font file reference key in bytes.</para>
		/// </param>
		/// <param name="filePath">
		///   <para>Type: <c>WCHAR*</c></para>
		///   <para>The character array that receives the local file path.</para>
		/// </param>
		/// <param name="filePathSize">
		///   <para>Type: <c>UINT32</c></para>
		///   <para>The length of the file path character array.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritelocalfontfileloader-getfilepathfromkey
		// HRESULT GetFilePathFromKey( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, WCHAR *filePath, UINT32 filePathSize );
		void GetFilePathFromKey(IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder filePath, uint filePathSize);

		/// <summary>Obtains the last write time of the file from the font file reference key.</summary>
		/// <param name="fontFileReferenceKey">
		///   <para>Type: <c>const void*</c></para>
		///   <para>The font file reference key that uniquely identifies the local font file within the scope of the font loader being used.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		///   <para>Type: <c>UINT32</c></para>
		///   <para>The size of font file reference key in bytes.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>FILETIME*</c></para>
		///   <para>The time of the last font file modification.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritelocalfontfileloader-getlastwritetimefromkey
		// HRESULT GetLastWriteTimeFromKey( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, FILETIME *lastWriteTime );
		FILETIME GetLastWriteTimeFromKey(IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize);
	}

	/// <summary>Represents a collection of strings indexed by locale name.</summary>
	/// <remarks>
	/// <para>
	/// The set of strings represented by an <c>IDWriteLocalizedStrings</c> are indexed by a zero based UINT32 number that maps to a
	/// locale. The numeric index for a specific locale is retreived by using the FindLocaleName method.
	/// </para>
	/// <para>
	/// A common use for the <c>IDWriteLocalizedStrings</c> interface is to hold a list of localized font family names created by using
	/// the IDWriteFontFamily::GetFamilyNames method. The following example shows how to get the family name for the "en-us" locale.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritelocalizedstrings
	[PInvokeData("dwrite.h", MSDNShortId = "37bfc613-4128-45aa-b6b2-6163d44378e4")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("08256209-099a-4b34-b86d-c22b110e7771")]
	public interface IDWriteLocalizedStrings
	{
		/// <summary>Gets the number of language/string pairs.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of language/string pairs.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-getcount UINT32 GetCount();
		[PreserveSig]
		uint GetCount();

		/// <summary>Gets the zero-based index of the locale name/string pair with the specified locale name.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>A null-terminated array of characters containing the locale name to look for.</para>
		/// </param>
		/// <param name="index">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>The zero-based index of the locale name/string pair. This method initializes index to <c>UINT_MAX</c>.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// When this method returns, contains <c>TRUE</c> if the locale name exists; otherwise, <c>FALSE</c>. This method initializes
		/// exists to <c>FALSE</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// Note that if the locale name does not exist, the return value is a success and the exists parameter is <c>FALSE</c>. If you
		/// are getting the font family name for a font and the specified locale name does not exist, one option is to set the index to
		/// 0 as shown below. There is always at least one locale for a font family.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-findlocalename HRESULT
		// FindLocaleName( WCHAR const *localeName, UINT32 *index, BOOL *exists );
		void FindLocaleName([MarshalAs(UnmanagedType.LPWStr)] string localeName, out uint index, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Gets the length in characters (not including the null terminator) of the locale name with the specified index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the locale name to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the length in characters of the locale name, not including the null terminator.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-getlocalenamelength HRESULT
		// GetLocaleNameLength( UINT32 index, UINT32 *length );
		uint GetLocaleNameLength(uint index);

		/// <summary>Copies the locale name with the specified index to the specified array.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the locale name to be retrieved.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains a character array, which is null-terminated, that receives the locale name from the
		/// language/string pair. The buffer allocated for this array must be at least the size of size, in element count.
		/// </para>
		/// </param>
		/// <param name="size">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the array in characters. The size must include space for the terminating null character.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-getlocalename HRESULT
		// GetLocaleName( UINT32 index, WCHAR *localeName, UINT32 size );
		void GetLocaleName(uint index, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint size);

		/// <summary>Gets the length in characters (not including the null terminator) of the string with the specified index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>A zero-based index of the language/string pair.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>The length in characters of the string, not including the null terminator, from the language/string pair.</para>
		/// </returns>
		/// <remarks>
		/// Use <c>GetStringLength</c> to get the string length before calling the IDWriteLocalizedStrings::GetString method, as shown
		/// in the following code.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-getstringlength HRESULT
		// GetStringLength( UINT32 index, UINT32 *length );
		uint GetStringLength(uint index);

		/// <summary>Copies the string with the specified index to the specified array.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The zero-based index of the language/string pair to be examined.</para>
		/// </param>
		/// <param name="stringBuffer">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// The null terminated array of characters that receives the string from the language/string pair. The buffer allocated for
		/// this array should be at least the size of size. GetStringLength can be used to get the size of the array before using this method.
		/// </para>
		/// </param>
		/// <param name="size">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the array in characters. The size must include space for the terminating null character. GetStringLength can be
		/// used to get the size of the array before using this method.
		/// </para>
		/// </param>
		/// <remarks>
		/// The string returned must be allocated by the caller. You can get the size of the string by using the GetStringLength method
		/// prior to calling <c>GetString</c>, as shown in the following example.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritelocalizedstrings-getstring HRESULT GetString(
		// UINT32 index, WCHAR *stringBuffer, UINT32 size );
		void GetString(uint index, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder stringBuffer, uint size);
	}

	/// <summary>Holds the appropriate digits and numeric punctuation for a specified locale.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/directwrite/idwritenumbersubstitution
	[PInvokeData("", MSDNShortId = "bf8caeea-6ede-4cd3-84f7-2e8314af50db")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("14885CC9-BAB0-4f90-B6ED-5C366A2CD03D")]
	public interface IDWriteNumberSubstitution
	{
	}

	/// <summary>
	/// Defines the pixel snapping properties such as pixels per DIP(device-independent pixel) and the current transform matrix of a
	/// text renderer.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritepixelsnapping
	[PInvokeData("dwrite.h", MSDNShortId = "b1b1eeb7-934f-42f4-ac01-50973a94996e")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("eaf3a2da-ecf4-4d24-b644-b34f6842024b")]
	public interface IDWritePixelSnapping
	{
		/// <summary>
		/// Determines whether pixel snapping is disabled. The recommended default is <c>FALSE</c>, unless doing animation that requires
		/// subpixel vertical placement.
		/// </summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The context passed to <c>IDWriteTextLayout::Draw</c>.</para>
		/// </param>
		/// <returns>
		/// <para>[out] Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if pixel snapping is disabled; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd371281(v%3Dvs.85) virtual HRESULT
		// IsPixelSnappingEnabled( void * clientDrawingContext, [out] BOOL * isDisabled ) = 0;
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsPixelSnappingDisabled([In, Optional] IntPtr clientDrawingContext);

		/// <summary>Gets a transform that maps abstract coordinates to DIPs.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The drawing context passed to IDWriteTextLayout::Draw.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_MATRIX*</c></para>
		/// <para>When this method returns, contains a structure which has transform information for pixel snapping.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritepixelsnapping-getcurrenttransform HRESULT
		// GetCurrentTransform( void *clientDrawingContext, DWRITE_MATRIX *transform );
		DWRITE_MATRIX GetCurrentTransform([In, Optional] IntPtr clientDrawingContext);

		/// <summary>Gets the number of physical pixels per DIP.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The drawing context passed to IDWriteTextLayout::Draw.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the number of physical pixels per DIP.</para>
		/// </returns>
		/// <remarks>
		/// Because a DIP (device-independent pixel) is 1/96 inch, the pixelsPerDip value is the number of logical pixels per inch
		/// divided by 96.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritepixelsnapping-getpixelsperdip HRESULT
		// GetPixelsPerDip( void *clientDrawingContext, FLOAT *pixelsPerDip );
		float GetPixelsPerDip([In, Optional] IntPtr clientDrawingContext);
	}

	/// <summary>
	/// <para>
	/// Represents text rendering settings such as ClearType level, enhanced contrast, and gamma correction for glyph rasterization and filtering.
	/// </para>
	/// <para>
	/// An application typically obtains a rendering parameters object by calling the IDWriteFactory::CreateMonitorRenderingParams method.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwriterenderingparams
	[PInvokeData("dwrite.h", MSDNShortId = "28b118e4-9a63-46cf-8ab7-e1039126405b")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2f0da53a-2add-47cd-82ee-d9ec34688e75")]
	public interface IDWriteRenderingParams
	{
		/// <summary>Gets the gamma value used for gamma correction. Valid values must be greater than zero and cannot exceed 256.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the gamma value used for gamma correction. Valid values must be greater than zero and cannot exceed 256.</para>
		/// </returns>
		/// <remarks>
		/// The gamma value is used for gamma correction, which compensates for the non-linear luminosity response of most monitors.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getgamma FLOAT GetGamma();
		[PreserveSig]
		float GetGamma();

		/// <summary>
		/// Gets the enhanced contrast property of the rendering parameters object. Valid values are greater than or equal to zero.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the amount of contrast enhancement. Valid values are greater than or equal to zero.</para>
		/// </returns>
		/// <remarks>
		/// Enhanced contrast is the amount to increase the darkness of text, and typically ranges from 0 to 1. Zero means no contrast enhancement.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getenhancedcontrast FLOAT GetEnhancedContrast();
		[PreserveSig]
		float GetEnhancedContrast();

		/// <summary>Gets the ClearType level of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level of the rendering parameters object.</para>
		/// </returns>
		/// <remarks>
		/// The ClearType level represents the amount of ClearType – that is, the degree to which the red, green, and blue subpixels of
		/// each pixel are treated differently. Valid values range from zero (meaning no ClearType, which is equivalent to grayscale
		/// anti-aliasing) to one (meaning full ClearType)
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getcleartypelevel FLOAT GetClearTypeLevel();
		[PreserveSig]
		float GetClearTypeLevel();

		/// <summary>Gets the pixel geometry of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>A value that indicates the type of pixel geometry used in the rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getpixelgeometry
		// DWRITE_PIXEL_GEOMETRY GetPixelGeometry();
		[PreserveSig]
		DWRITE_PIXEL_GEOMETRY GetPixelGeometry();

		/// <summary>Gets the rendering mode of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>A value that indicates the rendering mode of the rendering parameters object.</para>
		/// </returns>
		/// <remarks>
		/// By default, the rendering mode is initialized to DWRITE_RENDERING_MODE_DEFAULT, which means the rendering mode is determined
		/// automatically based on the font and size. To determine the recommended rendering mode to use for a given font and size and
		/// rendering parameters object, use the IDWriteFontFace::GetRecommendedRenderingMode method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getrenderingmode
		// DWRITE_RENDERING_MODE GetRenderingMode();
		[PreserveSig]
		DWRITE_RENDERING_MODE GetRenderingMode();
	}

	/// <summary>This interface is implemented by the text analyzer's client to receive the output of a given text analysis.</summary>
	/// <remarks>
	/// The text analyzer disregards any current state of the analysis sink, therefore, a Set method call on a range overwrites the
	/// previously set analysis result of the same range.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritetextanalysissink
	[PInvokeData("dwrite.h", MSDNShortId = "1fd2ca46-006c-4b01-8258-6c24f4be1641")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5810cd44-0ca0-4701-b3fa-bec5182ae4f6")]
	public interface IDWriteTextAnalysisSink
	{
		/// <summary>Reports script analysis for the specified text range.</summary>
		/// <param name="textPosition">
		///   <para>Type: <c>UINT32</c></para>
		///   <para>The starting position from which to report.</para>
		/// </param>
		/// <param name="textLength">
		///   <para>Type: <c>UINT32</c></para>
		///   <para>The number of UTF16 units of the reported range.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		///   <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		///   <para>
		/// A pointer to a structure that contains a zero-based index representation of a writing system script and a value indicating
		/// whether additional shaping of text is required.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissink-setscriptanalysis HRESULT
		// SetScriptAnalysis( UINT32 textPosition, UINT32 textLength, DWRITE_SCRIPT_ANALYSIS const *scriptAnalysis );
		[PreserveSig]
		HRESULT SetScriptAnalysis(uint textPosition, uint textLength, in DWRITE_SCRIPT_ANALYSIS scriptAnalysis);

		/// <summary>Sets line-break opportunities for each character, starting from the specified position.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting text position from which to report.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of UTF16 units of the reported range.</para>
		/// </param>
		/// <param name="lineBreakpoints">
		/// <para>Type: <c>DWRITE_LINE_BREAKPOINT*</c></para>
		/// <para>
		/// A pointer to a structure that contains breaking conditions set for each character from the starting position to the end of
		/// the specified range.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>A successful code or error code to stop analysis.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissink-setlinebreakpoints HRESULT
		// SetLineBreakpoints( UINT32 textPosition, UINT32 textLength, DWRITE_LINE_BREAKPOINT const *lineBreakpoints );
		[PreserveSig]
		HRESULT SetLineBreakpoints(uint textPosition, uint textLength, [In] DWRITE_LINE_BREAKPOINT[] lineBreakpoints);

		/// <summary>Sets a bidirectional level on the range, which is called once per run change (either explicit or resolved implicit).</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting position from which to report.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of UTF16 units of the reported range.</para>
		/// </param>
		/// <param name="explicitLevel">
		/// <para>Type: <c>UINT8</c></para>
		/// <para>
		/// The explicit level from the paragraph reading direction and any embedded control codes RLE/RLO/LRE/LRO/PDF, which is
		/// determined before any additional rules.
		/// </para>
		/// </param>
		/// <param name="resolvedLevel">
		/// <para>Type: <c>UINT8</c></para>
		/// <para>
		/// The final implicit level considering the explicit level and characters' natural directionality, after all Bidi rules have
		/// been applied.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>A successful code or error code to stop analysis.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissink-setbidilevel HRESULT
		// SetBidiLevel( UINT32 textPosition, UINT32 textLength, UINT8 explicitLevel, UINT8 resolvedLevel );
		[PreserveSig]
		HRESULT SetBidiLevel(uint textPosition, uint textLength, byte explicitLevel, byte resolvedLevel);

		/// <summary>Sets the number substitution on the text range affected by the text analysis.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting position from which to report.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of UTF16 units of the reported range.</para>
		/// </param>
		/// <param name="numberSubstitution">
		/// <para>Type: <c>IDWriteNumberSubstitution*</c></para>
		/// <para>
		/// An object that holds the appropriate digits and numeric punctuation for a given locale. Use
		/// IDWriteFactory::CreateNumberSubstitution to create this object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>A successful code or error code to stop analysis.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissink-setnumbersubstitution HRESULT
		// SetNumberSubstitution( UINT32 textPosition, UINT32 textLength, IDWriteNumberSubstitution *numberSubstitution );
		[PreserveSig]
		HRESULT SetNumberSubstitution(uint textPosition, uint textLength, [In] IDWriteNumberSubstitution numberSubstitution);
	}

	/// <summary>
	/// Implemented by the text analyzer's client to provide text to the analyzer. It allows the separation between the logical view of
	/// text as a continuous stream of characters identifiable by unique text positions, and the actual memory layout of potentially
	/// discrete blocks of text in the client's backing store.
	/// </summary>
	/// <remarks>
	/// If any of these callbacks returns an error, then the analysis functions will stop prematurely and return a callback error. Note
	/// that rather than return E_NOTIMPL, an application should stub the method and return a constant/null and S_OK.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritetextanalysissource
	[PInvokeData("dwrite.h", MSDNShortId = "7e2a523d-9191-4f99-9e73-a7955c432126")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("688e1a58-5094-47c8-adc8-fbcea60ae92b")]
	public interface IDWriteTextAnalysisSource
	{
		/// <summary>Gets a block of text starting at the specified text position.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The first position of the piece to obtain. All positions are in <c>UTF16</c> code units, not whole characters, which matters
		/// when supplementary characters are used.
		/// </para>
		/// </param>
		/// <param name="textString">
		/// <para>Type: <c>const WCHAR**</c></para>
		/// <para>
		/// When this method returns, contains an address of the block of text as an array of characters to be retrieved from the text analysis.
		/// </para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// When this method returns, contains the number of <c>UTF16</c> units of the retrieved chunk. The returned length is not the
		/// length of the block, but the length remaining in the block, from the specified position until its end. For example, querying
		/// for a position that is 75 positions into a 100-position block would return 25.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Returning <c>NULL</c> indicates the end of text, which is the position after the last character. This function is called
		/// iteratively for each consecutive block, tying together several fragmented blocks in the backing store into a virtual
		/// contiguous string.
		/// </para>
		/// <para>
		/// Although applications can implement sparse textual content that maps only part of the backing store, the application must
		/// map any text that is in the range passed to any analysis functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissource-gettextatposition HRESULT
		// GetTextAtPosition( UINT32 textPosition, WCHAR const **textString, UINT32 *textLength );
		void GetTextAtPosition(uint textPosition, out StrPtrUni textString, out uint textLength);

		/// <summary>Gets a block of text immediately preceding the specified position.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position immediately after the last position of the block of text to obtain.</para>
		/// </param>
		/// <param name="textString">
		/// <para>Type: <c>const WCHAR**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the block of text, as an array of characters from the
		/// specified range. The text range will be from textPosition to the front of the block.
		/// </para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// Number of UTF16 units of the retrieved block. The length returned is from the specified position to the front of the block.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// NULL indicates no chunk available at the specified position, either because textPosition equals 0, textPosition is greater
		/// than the entire text content length, or the queried position is not mapped into the application's backing store.
		/// </para>
		/// <para>
		/// Although applications can implement sparse textual content that maps only part of the backing store, the application must
		/// map any text that is in the range passed to any analysis functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissource-gettextbeforeposition HRESULT
		// GetTextBeforePosition( UINT32 textPosition, WCHAR const **textString, UINT32 *textLength );
		void GetTextBeforePosition(uint textPosition, out StrPtrUni textString, out uint textLength);

		/// <summary>Gets the paragraph reading direction.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>The reading direction of the current paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissource-getparagraphreadingdirection
		// DWRITE_READING_DIRECTION GetParagraphReadingDirection();
		[PreserveSig]
		DWRITE_READING_DIRECTION GetParagraphReadingDirection();

		/// <summary>Gets the locale name on the range affected by the text analysis.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text position to examine.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Contains the length of the text being affected by the text analysis up to the next differing locale.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR**</c></para>
		/// <para>
		/// Contains an address of a pointer to an array of characters which receives the locale name from the text affected by the text
		/// analysis. The array of characters is null-terminated.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The localeName pointer must remain valid until the next call or until the analysis returns.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissource-getlocalename HRESULT
		// GetLocaleName( UINT32 textPosition, UINT32 *textLength, WCHAR const **localeName );
		void GetLocaleName(uint textPosition, out uint textLength, out StrPtrUni localeName);

		/// <summary>Gets the number substitution from the text range affected by the text analysis.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting position from which to report.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Contains the length of the text, in characters, remaining in the text range up to the next differing number substitution.</para>
		/// </param>
		/// <param name="numberSubstitution">
		/// <para>Type: <c>IDWriteNumberSubstitution**</c></para>
		/// <para>
		/// Contains an address of a pointer to an object, which was created with IDWriteFactory::CreateNumberSubstitution, that holds
		/// the appropriate digits and numeric punctuation for a given locale.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Any implementation should return the number substitution with an incremented reference count, and the analysis will release
		/// when finished with it (either before the next call or before it returns). However, the sink callback may hold onto it after that.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissource-getnumbersubstitution HRESULT
		// GetNumberSubstitution( UINT32 textPosition, UINT32 *textLength, IDWriteNumberSubstitution **numberSubstitution );
		void GetNumberSubstitution(uint textPosition, out uint textLength, out IDWriteNumberSubstitution? numberSubstitution);
	}

	/// <summary>
	/// Analyzes various text properties for complex script processing such as bidirectional (bidi) support for languages like Arabic,
	/// determination of line break opportunities, glyph placement, and number substitution.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritetextanalyzer
	[PInvokeData("dwrite.h", MSDNShortId = "e832ffc4-31db-41b1-a008-04696d9a975e")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b7e6163e-7f46-43b4-84b3-e4e6249c365d")]
	public interface IDWriteTextAnalyzer
	{
		/// <summary>
		/// Analyzes a text range for script boundaries, reading text attributes from the source and reporting the Unicode script ID to
		/// the sink callback SetScript.
		/// </summary>
		/// <param name="analysisSource">
		/// <para>Type: <c>IDWriteTextAnalysisSource*</c></para>
		/// <para>A pointer to the source object to analyze.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting text position within the source object.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text length to analyze.</para>
		/// </param>
		/// <param name="analysisSink">
		/// <para>Type: <c>IDWriteTextAnalysisSink*</c></para>
		/// <para>A pointer to the sink callback object that receives the text analysis.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-analyzescript HRESULT AnalyzeScript(
		// IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength, IDWriteTextAnalysisSink *analysisSink );
		void AnalyzeScript([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

		/// <summary>
		/// Analyzes a text range for script directionality, reading attributes from the source and reporting levels to the sink
		/// callback SetBidiLevel.
		/// </summary>
		/// <param name="analysisSource">
		/// <para>Type: <c>IDWriteTextAnalysisSource*</c></para>
		/// <para>A pointer to a source object to analyze.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting text position within the source object.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text length to analyze.</para>
		/// </param>
		/// <param name="analysisSink">
		/// <para>Type: <c>IDWriteTextAnalysisSink*</c></para>
		/// <para>A pointer to the sink callback object that receives the text analysis.</para>
		/// </param>
		/// <remarks>
		/// While the function can handle multiple paragraphs, the text range should not arbitrarily split the middle of paragraphs.
		/// Otherwise, the returned levels may be wrong, because the Bidi algorithm is meant to apply to the paragraph as a whole.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-analyzebidi HRESULT AnalyzeBidi(
		// IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength, IDWriteTextAnalysisSink *analysisSink );
		void AnalyzeBidi([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

		/// <summary>
		/// Analyzes a text range for spans where number substitution is applicable, reading attributes from the source and reporting
		/// substitutable ranges to the sink callback SetNumberSubstitution.
		/// </summary>
		/// <param name="analysisSource">
		/// <para>Type: <c>IDWriteTextAnalysisSource*</c></para>
		/// <para>The source object to analyze.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting position within the source object.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length to analyze.</para>
		/// </param>
		/// <param name="analysisSink">
		/// <para>Type: <c>IDWriteTextAnalysisSink*</c></para>
		/// <para>A pointer to the sink callback object that receives the text analysis.</para>
		/// </param>
		/// <remarks>
		/// Although the function can handle multiple ranges of differing number substitutions, the text ranges should not arbitrarily
		/// split the middle of numbers. Otherwise, it will treat the numbers separately and will not translate any intervening punctuation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-analyzenumbersubstitution HRESULT
		// AnalyzeNumberSubstitution( IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength,
		// IDWriteTextAnalysisSink *analysisSink );
		void AnalyzeNumberSubstitution([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

		/// <summary>
		/// Analyzes a text range for potential breakpoint opportunities, reading attributes from the source and reporting breakpoint
		/// opportunities to the sink callback SetLineBreakpoints.
		/// </summary>
		/// <param name="analysisSource">
		/// <para>Type: <c>IDWriteTextAnalysisSource*</c></para>
		/// <para>A pointer to the source object to analyze.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting text position within the source object.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text length to analyze.</para>
		/// </param>
		/// <param name="analysisSink">
		/// <para>Type: <c>IDWriteTextAnalysisSink*</c></para>
		/// <para>A pointer to the sink callback object that receives the text analysis.</para>
		/// </param>
		/// <remarks>
		/// Although the function can handle multiple paragraphs, the text range should not arbitrarily split the middle of paragraphs,
		/// unless the specified text span is considered a whole unit. Otherwise, the returned properties for the first and last
		/// characters will inappropriately allow breaks.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-analyzelinebreakpoints HRESULT
		// AnalyzeLineBreakpoints( IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength,
		// IDWriteTextAnalysisSink *analysisSink );
		void AnalyzeLineBreakpoints([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

		/// <summary>
		/// Parses the input text string and maps it to the set of glyphs and associated glyph data according to the font and the
		/// writing system's rendering rules.
		/// </summary>
		/// <param name="textString">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters to convert to glyphs.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length of textString.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>The font face that is the source of the output glyphs.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> if the text is intended to be drawn vertically.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> for right-to-left text.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		/// <para>A pointer to a Script analysis result from an AnalyzeScript call.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// The locale to use when selecting glyphs. For example the same character may map to different glyphs for ja-jp versus zh-chs.
		/// If this is <c>NULL</c>, then the default mapping based on the script is used.
		/// </para>
		/// </param>
		/// <param name="numberSubstitution">
		/// <para>Type: <c>IDWriteNumberSubstitution*</c></para>
		/// <para>
		/// A pointer to an optional number substitution which selects the appropriate glyphs for digits and related numeric characters,
		/// depending on the results obtained from AnalyzeNumberSubstitution. Passing <c>NULL</c> indicates that no substitution is
		/// needed and that the digits should receive nominal glyphs.
		/// </para>
		/// </param>
		/// <param name="features">
		/// <para>Type: <c>const DWRITE_TYPOGRAPHIC_FEATURES**</c></para>
		/// <para>An array of pointers to the sets of typographic features to use in each feature range.</para>
		/// </param>
		/// <param name="featureRangeLengths">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>The length of each feature range, in characters. The sum of all lengths should be equal to textLength.</para>
		/// </param>
		/// <param name="featureRanges">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of feature ranges.</para>
		/// </param>
		/// <param name="maxGlyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum number of glyphs that can be returned.</para>
		/// </param>
		/// <param name="clusterMap">
		/// <para>Type: <c>UINT16*</c></para>
		/// <para>When this method returns, contains the mapping from character ranges to glyph ranges.</para>
		/// </param>
		/// <param name="textProps">
		/// <para>Type: <c>DWRITE_SHAPING_TEXT_PROPERTIES*</c></para>
		/// <para>When this method returns, contains a pointer to an array of structures that contains shaping properties for each character.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>UINT16*</c></para>
		/// <para>The output glyph indices.</para>
		/// </param>
		/// <param name="glyphProps">
		/// <para>Type: <c>DWRITE_SHAPING_GLYPH_PROPERTIES*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to an array of structures that contain shaping properties for each output glyph.
		/// </para>
		/// </param>
		/// <param name="actualGlyphCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the actual number of glyphs returned if the call succeeds.</para>
		/// </param>
		/// <remarks>
		/// Note that the mapping from characters to glyphs is, in general, many-to-many. The recommended estimate for the per-glyph
		/// output buffers is (3 * textLength / 2 + 16). This is not guaranteed to be sufficient.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-getglyphs HRESULT GetGlyphs( WCHAR
		// const *textString, UINT32 textLength, IDWriteFontFace *fontFace, BOOL isSideways, BOOL isRightToLeft, DWRITE_SCRIPT_ANALYSIS
		// const *scriptAnalysis, WCHAR const *localeName, IDWriteNumberSubstitution *numberSubstitution, DWRITE_TYPOGRAPHIC_FEATURES
		// const **features, UINT32 const *featureRangeLengths, UINT32 featureRanges, UINT32 maxGlyphCount, UINT16 *clusterMap,
		// DWRITE_SHAPING_TEXT_PROPERTIES *textProps, UINT16 *glyphIndices, DWRITE_SHAPING_GLYPH_PROPERTIES *glyphProps, UINT32
		// *actualGlyphCount );
		void GetGlyphs([MarshalAs(UnmanagedType.LPWStr)] string textString, uint textLength, [In] IDWriteFontFace fontFace,
			[MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			in DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [MarshalAs(UnmanagedType.LPWStr)] string localeName,
			[In, Optional] IDWriteNumberSubstitution? numberSubstitution, [In, Optional, MarshalAs(UnmanagedType.LPArray)] DWRITE_TYPOGRAPHIC_FEATURES[]? features,
			[In, Optional] uint[]? featureRangeLengths, uint featureRanges, uint maxGlyphCount, [Out, MarshalAs(UnmanagedType.LPArray)] ushort[] clusterMap,
			[Out, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_TEXT_PROPERTIES[] textProps, [Out, MarshalAs(UnmanagedType.LPArray)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProps, out uint actualGlyphCount);

		/// <summary>Places glyphs output from the GetGlyphs method according to the font and the writing system's rendering rules.</summary>
		/// <param name="textString">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters containing the original string from which the glyphs came.</para>
		/// </param>
		/// <param name="clusterMap">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>A pointer to the mapping from character ranges to glyph ranges. This is returned by GetGlyphs.</para>
		/// </param>
		/// <param name="textProps">
		/// <para>Type: <c>DWRITE_SHAPING_TEXT_PROPERTIES*</c></para>
		/// <para>
		/// A pointer to an array of structures that contains shaping properties for each character. This structure is returned by GetGlyphs.
		/// </para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text length of textString.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of glyph indices returned by GetGlyphs.</para>
		/// </param>
		/// <param name="glyphProps">
		/// <para>Type: <c>const DWRITE_SHAPING_GLYPH_PROPERTIES*</c></para>
		/// <para>A pointer to an array of structures that contain shaping properties for each glyph returned by GetGlyphs.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs returned from GetGlyphs.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>A pointer to the font face that is the source for the output glyphs.</para>
		/// </param>
		/// <param name="fontEmSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical font size in DIPs.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> if the text is intended to be drawn vertically.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> for right-to-left text.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		/// <para>A pointer to a Script analysis result from an AnalyzeScript call.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters containing the locale to use when selecting glyphs. For example, the same character may map to
		/// different glyphs for ja-jp versus zh-chs. If this is <c>NULL</c>, the default mapping based on the script is used.
		/// </para>
		/// </param>
		/// <param name="features">
		/// <para>Type: <c>const DWRITE_TYPOGRAPHIC_FEATURES**</c></para>
		/// <para>An array of pointers to the sets of typographic features to use in each feature range.</para>
		/// </param>
		/// <param name="featureRangeLengths">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>The length of each feature range, in characters. The sum of all lengths should be equal to textLength.</para>
		/// </param>
		/// <param name="featureRanges">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of feature ranges.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the advance width of each glyph.</para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <c>DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>When this method returns, contains the offset of the origin of each glyph.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-getglyphplacements HRESULT
		// GetGlyphPlacements( WCHAR const *textString, UINT16 const *clusterMap, DWRITE_SHAPING_TEXT_PROPERTIES *textProps, UINT32
		// textLength, UINT16 const *glyphIndices, DWRITE_SHAPING_GLYPH_PROPERTIES const *glyphProps, UINT32 glyphCount, IDWriteFontFace
		// *fontFace, FLOAT fontEmSize, BOOL isSideways, BOOL isRightToLeft, DWRITE_SCRIPT_ANALYSIS const *scriptAnalysis, WCHAR const
		// *localeName, DWRITE_TYPOGRAPHIC_FEATURES const **features, UINT32 const *featureRangeLengths, UINT32 featureRanges, FLOAT
		// *glyphAdvances, DWRITE_GLYPH_OFFSET *glyphOffsets );
		void GetGlyphPlacements([MarshalAs(UnmanagedType.LPWStr)] string textString, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_TEXT_PROPERTIES[] textProps, uint textLength, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] glyphIndices,
			[In, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProps, uint glyphCount, [In] IDWriteFontFace fontFace, float fontEmSize,
			[MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			in DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [MarshalAs(UnmanagedType.LPWStr)] string localeName,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct)] DWRITE_TYPOGRAPHIC_FEATURES[]? features,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] uint[]? featureRangeLengths, uint featureRanges, [Out, MarshalAs(UnmanagedType.LPArray)] float[] glyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray)] DWRITE_GLYPH_OFFSET[] glyphOffsets);

		/// <summary>Place glyphs output from the GetGlyphs method according to the font and the writing system's rendering rules.</summary>
		/// <param name="textString">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters containing the original string from which the glyphs came.</para>
		/// </param>
		/// <param name="clusterMap">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>A pointer to the mapping from character ranges to glyph ranges. This is returned by GetGlyphs.</para>
		/// </param>
		/// <param name="textProps">
		/// <para>Type: <c>DWRITE_SHAPING_TEXT_PROPERTIES*</c></para>
		/// <para>
		/// A pointer to an array of structures that contains shaping properties for each character. This structure is returned by GetGlyphs.
		/// </para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text length of textString.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of glyph indices returned by GetGlyphs.</para>
		/// </param>
		/// <param name="glyphProps">
		/// <para>Type: <c>const DWRITE_SHAPING_GLYPH_PROPERTIES*</c></para>
		/// <para>A pointer to an array of structures that contain shaping properties for each glyph returned by GetGlyphs.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs returned from GetGlyphs.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>A pointer to the font face that is the source for the output glyphs.</para>
		/// </param>
		/// <param name="fontEmSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical font size in DIPs.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by
		/// the font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// When set to <c>FALSE</c>, the metrics are the same as the metrics of GDI aliased text. When set to <c>TRUE</c>, the metrics
		/// are the same as the metrics of text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> if the text is intended to be drawn vertically.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> for right-to-left text.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		/// <para>A pointer to a Script analysis result from anAnalyzeScript call.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters containing the locale to use when selecting glyphs. For example, the same character may map to
		/// different glyphs for ja-jp versus zh-chs. If this is <c>NULL</c>, then the default mapping based on the script is used.
		/// </para>
		/// </param>
		/// <param name="features">
		/// <para>Type: <c>const DWRITE_TYPOGRAPHIC_FEATURES**</c></para>
		/// <para>An array of pointers to the sets of typographic features to use in each feature range.</para>
		/// </param>
		/// <param name="featureRangeLengths">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>The length of each feature range, in characters. The sum of all lengths should be equal to textLength.</para>
		/// </param>
		/// <param name="featureRanges">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of feature ranges.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the advance width of each glyph.</para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <c>DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>When this method returns, contains the offset of the origin of each glyph.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-getgdicompatibleglyphplacements
		// HRESULT GetGdiCompatibleGlyphPlacements( WCHAR const *textString, UINT16 const *clusterMap, DWRITE_SHAPING_TEXT_PROPERTIES
		// *textProps, UINT32 textLength, UINT16 const *glyphIndices, DWRITE_SHAPING_GLYPH_PROPERTIES const *glyphProps, UINT32
		// glyphCount, IDWriteFontFace *fontFace, FLOAT fontEmSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, BOOL
		// useGdiNatural, BOOL isSideways, BOOL isRightToLeft, DWRITE_SCRIPT_ANALYSIS const *scriptAnalysis, WCHAR const *localeName,
		// DWRITE_TYPOGRAPHIC_FEATURES const **features, UINT32 const *featureRangeLengths, UINT32 featureRanges, FLOAT *glyphAdvances,
		// DWRITE_GLYPH_OFFSET *glyphOffsets );
		void GetGdiCompatibleGlyphPlacements([MarshalAs(UnmanagedType.LPWStr)] string textString, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_TEXT_PROPERTIES[] textProps, uint textLength, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] glyphIndices,
			[In, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProps, uint glyphCount, [In] IDWriteFontFace fontFace, float fontEmSize,
			float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
			[MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			in DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [MarshalAs(UnmanagedType.LPWStr)] string localeName,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct)] DWRITE_TYPOGRAPHIC_FEATURES[]? features,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] uint[]? featureRangeLengths, uint featureRanges, [Out, MarshalAs(UnmanagedType.LPArray)] float[] glyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray)] DWRITE_GLYPH_OFFSET[] glyphOffsets);
	}

	/// <summary>
	/// The <c>IDWriteTextFormat</c> interface describes the font and paragraph properties used to format text, and it describes locale information.
	/// </summary>
	/// <remarks>
	/// <para>
	/// To get a reference to the <c>IDWriteTextFormat</c> interface, the application must call the IDWriteFactory::CreateTextFormat
	/// method as shown in the following code.
	/// </para>
	/// <para>
	/// When creating an <c>IDWriteTextFormat</c> object using the CreateTextFormat function, the application specifies the font family,
	/// font collection, font weight, font size, and locale name for the text format.
	/// </para>
	/// <para>
	/// These properties cannot be changed after the <c>IDWriteTextFormat</c> object is created. To change these properties, a new
	/// <c>IDWriteTextFormat</c> object must be created with the desired properties.
	/// </para>
	/// <para>The <c>IDWriteTextFormat</c> interface is used to draw text with a single format</para>
	/// <para>
	/// To draw text with multiple formats, or to use a custom text renderer, use the IDWriteTextLayout interface.
	/// <c>IDWriteTextLayout</c> enables the application to change the format for ranges of text within the string. The
	/// IDWriteFactory::CreateTextLayout takes an <c>IDWriteTextFormat</c> object as a parameter and initially applies the format
	/// information to the entire string.
	/// </para>
	/// <para>This object may not be thread-safe, and it may carry the state of text format change.</para>
	/// <para>DirectWrite and Direct2D</para>
	/// <para>
	/// To draw simple text with a single format, Direct2D provides the ID2D1RenderTarget::DrawText method, which draws a string using
	/// the format information provided by an <c>IDWriteTextFormat</c> object.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritetextformat
	[PInvokeData("dwrite.h", MSDNShortId = "64b2cac3-c4cb-4213-b808-7b279d296939")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9c906818-31d7-4fd3-a151-7c5e225db55a")]
	public interface IDWriteTextFormat
	{
		/// <summary>
		/// Sets the alignment of text in a paragraph, relative to the leading and trailing edge of a layout box for a IDWriteTextFormat interface.
		/// </summary>
		/// <param name="textAlignment">
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>The text alignment option being set for the paragraph of type DWRITE_TEXT_ALIGNMENT. For more information, see Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The text can be aligned to the leading or trailing edge of the layout box, or it can be centered. The following illustration
		/// shows text with the alignment set to DWRITE_TEXT_ALIGNMENT_LEADING, <c>DWRITE_TEXT_ALIGNMENT_CENTER</c>, and
		/// <c>DWRITE_TEXT_ALIGNMENT_TRAILING</c>, respectively.
		/// </para>
		/// <para>
		/// <c>Note</c> The alignment is dependent on reading direction, the above is for left-to-right reading direction. For
		/// right-to-left reading direction it would be the opposite.
		/// </para>
		/// <para>See DWRITE_TEXT_ALIGNMENT for more information.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settextalignment HRESULT
		// SetTextAlignment( DWRITE_TEXT_ALIGNMENT textAlignment );
		void SetTextAlignment(DWRITE_TEXT_ALIGNMENT textAlignment);

		/// <summary>Sets the alignment option of a paragraph relative to the layout box's top and bottom edge.</summary>
		/// <param name="paragraphAlignment">
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>The paragraph alignment option being set for a paragraph; see DWRITE_PARAGRAPH_ALIGNMENT for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setparagraphalignment HRESULT
		// SetParagraphAlignment( DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment );
		void SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment);

		/// <summary>Sets the word wrapping option.</summary>
		/// <param name="wordWrapping">
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>The word wrapping option being set for a paragraph; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setwordwrapping HRESULT
		// SetWordWrapping( DWRITE_WORD_WRAPPING wordWrapping );
		void SetWordWrapping(DWRITE_WORD_WRAPPING wordWrapping);

		/// <summary>Sets the paragraph reading direction.</summary>
		/// <param name="readingDirection">
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// The text reading direction (for example, DWRITE_READING_DIRECTION_RIGHT_TO_LEFT for languages, such as Arabic, that read
		/// from right to left) for a paragraph.
		/// </para>
		/// </param>
		/// <remarks>
		/// The reading direction and flow direction must always be set 90 degrees orthogonal to each other, or else you will get the
		/// error DWRITE_E_FLOWDIRECTIONCONFLICTS when you use layout functions like Draw or GetMetrics. So if you set a vertical
		/// reading direction (for example, to DWRITE_READING_DIRECTION_TOP_TO_BOTTOM), then you must also use SetFlowDirection to set
		/// the flow direction appropriately (for example, to DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setreadingdirection HRESULT
		// SetReadingDirection( DWRITE_READING_DIRECTION readingDirection );
		void SetReadingDirection(DWRITE_READING_DIRECTION readingDirection);

		/// <summary>Sets the paragraph flow direction.</summary>
		/// <param name="flowDirection">
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>The paragraph flow direction; see DWRITE_FLOW_DIRECTION for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setflowdirection HRESULT
		// SetFlowDirection( DWRITE_FLOW_DIRECTION flowDirection );
		void SetFlowDirection(DWRITE_FLOW_DIRECTION flowDirection);

		/// <summary>Sets a fixed distance between two adjacent tab stops.</summary>
		/// <param name="incrementalTabStop">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The fixed distance between two adjacent tab stops.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setincrementaltabstop HRESULT
		// SetIncrementalTabStop( FLOAT incrementalTabStop );
		void SetIncrementalTabStop(float incrementalTabStop);

		/// <summary>Sets trimming options for text overflowing the layout width.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>const DWRITE_TRIMMING*</c></para>
		/// <para>Text trimming options.</para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>Application-defined omission sign. This parameter may be <c>NULL</c>. See IDWriteInlineObject for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settrimming HRESULT SetTrimming(
		// DWRITE_TRIMMING const *trimmingOptions, IDWriteInlineObject *trimmingSign );
		void SetTrimming(in DWRITE_TRIMMING trimmingOptions, [In, Optional] IDWriteInlineObject? trimmingSign);

		/// <summary>Sets the line spacing.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD</c></para>
		/// <para>Specifies how line height is being determined; see DWRITE_LINE_SPACING_METHOD for more information.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.</para>
		/// </param>
		/// <remarks>
		/// For the default method, spacing depends solely on the content. For uniform spacing, the specified line height overrides the content.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setlinespacing HRESULT SetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD lineSpacingMethod, FLOAT lineSpacing, FLOAT baseline );
		void SetLineSpacing(DWRITE_LINE_SPACING_METHOD lineSpacingMethod, float lineSpacing, float baseline);

		/// <summary>Gets the alignment option of text relative to the layout box's leading and trailing edge.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>Returns the text alignment option of the current paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettextalignment DWRITE_TEXT_ALIGNMENT GetTextAlignment();
		[PreserveSig]
		DWRITE_TEXT_ALIGNMENT GetTextAlignment();

		/// <summary>Gets the alignment option of a paragraph which is relative to the top and bottom edges of a layout box.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>A value that indicates the current paragraph alignment option.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getparagraphalignment
		// DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();
		[PreserveSig]
		DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();

		/// <summary>Gets the word wrapping option.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>Returns the word wrapping option; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getwordwrapping DWRITE_WORD_WRAPPING GetWordWrapping();
		[PreserveSig]
		DWRITE_WORD_WRAPPING GetWordWrapping();

		/// <summary>Gets the current reading direction for text in a paragraph.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>A value that indicates the current reading direction for text in a paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getreadingdirection
		// DWRITE_READING_DIRECTION GetReadingDirection();
		[PreserveSig]
		DWRITE_READING_DIRECTION GetReadingDirection();

		/// <summary>Gets the direction that text lines flow.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>
		/// The direction that text lines flow within their parent container. For example, DWRITE_FLOW_DIRECTION_TOP_TO_BOTTOM indicates
		/// that text lines are placed from top to bottom.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getflowdirection DWRITE_FLOW_DIRECTION GetFlowDirection();
		[PreserveSig]
		DWRITE_FLOW_DIRECTION GetFlowDirection();

		/// <summary>Gets the incremental tab stop position.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The incremental tab stop value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getincrementaltabstop FLOAT GetIncrementalTabStop();
		[PreserveSig]
		float GetIncrementalTabStop();

		/// <summary>Gets the trimming options for text that overflows the layout box.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>DWRITE_TRIMMING*</c></para>
		/// <para>
		/// When this method returns, it contains a pointer to a DWRITE_TRIMMING structure that holds the text trimming options for the
		/// overflowing text.
		/// </para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>When this method returns, contains an address of a pointer to a trimming omission sign. This parameter may be <c>NULL</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettrimming HRESULT GetTrimming(
		// DWRITE_TRIMMING *trimmingOptions, IDWriteInlineObject **trimmingSign );
		void GetTrimming(out DWRITE_TRIMMING trimmingOptions, out IDWriteInlineObject? trimmingSign);

		/// <summary>Gets the line spacing adjustment set for a multiline text paragraph.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD*</c></para>
		/// <para>A value that indicates how line height is determined.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>
		/// When this method returns, contains the distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlinespacing HRESULT GetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD *lineSpacingMethod, FLOAT *lineSpacing, FLOAT *baseline );
		void GetLineSpacing(out DWRITE_LINE_SPACING_METHOD lineSpacingMethod, out float lineSpacing, out float baseline);

		/// <summary>Gets the current font collection.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the font collection being used for the current text.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontcollection HRESULT
		// GetFontCollection( IDWriteFontCollection **fontCollection );
		IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the length of the font family name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilynamelength UINT32 GetFontFamilyNameLength();
		[PreserveSig]
		uint GetFontFamilyNameLength();

		/// <summary>Gets a copy of the font family name.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a character array, which is null-terminated, that receives the current font
		/// family name. The buffer allocated for this array should be at least the size, in elements, of nameSize.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the fontFamilyName character array, in character count, including the terminated <c>NULL</c> character. To find
		/// the size of fontFamilyName, use GetFontFamilyNameLength.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilyname HRESULT
		// GetFontFamilyName( WCHAR *fontFamilyName, UINT32 nameSize );
		void GetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize);

		/// <summary>Gets the font weight of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the type of weight (such as normal, bold, or black).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontweight DWRITE_FONT_WEIGHT GetFontWeight();
		[PreserveSig]
		DWRITE_FONT_WEIGHT GetFontWeight();

		/// <summary>Gets the font style of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value which indicates the type of font style (such as slope or incline).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstyle DWRITE_FONT_STYLE GetFontStyle();
		[PreserveSig]
		DWRITE_FONT_STYLE GetFontStyle();

		/// <summary>Gets the font stretch of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch (such as normal or condensed).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstretch DWRITE_FONT_STRETCH GetFontStretch();
		[PreserveSig]
		DWRITE_FONT_STRETCH GetFontStretch();

		/// <summary>Gets the font size in DIP unites.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The current font size in DIP units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontsize FLOAT GetFontSize();
		[PreserveSig]
		float GetFontSize();

		/// <summary>Gets the length of the locale name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalenamelength UINT32 GetLocaleNameLength();
		[PreserveSig]
		uint GetLocaleNameLength();

		/// <summary>Gets a copy of the locale name.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Contains a character array that receives the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the character array, in character count, including the terminated <c>NULL</c> character. Use GetLocaleNameLength
		/// to get the size of the locale name character array.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalename HRESULT GetLocaleName(
		// WCHAR *localeName, UINT32 nameSize );
		void GetLocaleName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize);
	}

	/// <summary>The <c>IDWriteTextLayout</c> interface represents a block of text after it has been fully analyzed and formatted.</summary>
	/// <remarks>
	/// <para>
	/// To get a reference to the <c>IDWriteTextLayout</c> interface, the application must call the IDWriteFactory::CreateTextLayout
	/// method, as shown in the following code.
	/// </para>
	/// <para>
	/// The <c>IDWriteTextLayout</c> interface allows the application to change the format for ranges of the text it represents,
	/// specified by a DWRITE_TEXT_RANGE structure. The following example shows how to set the font weight for a text range.
	/// </para>
	/// <para><c>IDWriteTextLayout</c> also provides methods for adding strikethrough, underline, and inline objects to the text.</para>
	/// <para>
	/// To draw the block of text represented by an <c>IDWriteTextLayout</c> object, Direct2D provides the
	/// ID2D1RenderTarget::DrawTextLayout method. To draw using a custom renderer implement an IDWriteTextRenderer interface and call
	/// the IDWriteTextLayout::Draw method
	/// </para>
	/// <para>DirectWrite and Direct2D</para>
	/// <para>
	/// To draw a formatted string represented by an <c>IDWriteTextLayout</c> object, Direct2D provides the
	/// ID2D1RenderTarget::DrawTextLayout method.
	/// </para>
	/// <para>Other Rendering Options</para>
	/// <para>
	/// To render using a custom renderer, use the IDWriteTextLayout::Draw method, which takes a callback interface derived from
	/// IDWriteTextRenderer as an argument, as shown in the following code.
	/// </para>
	/// <para>
	/// IDWriteTextRenderer declares methods for drawing a glyph run, underline, strikethrough and inline objects. It is up to the
	/// application to implement these methods. Creating a custom text renderer allows the application to apply additional effects when
	/// rendering text, such as a custom fill or outline.
	/// </para>
	/// <para>Using a custom text renderer also enables you to render using another technology, such as GDI.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritetextlayout
	[PInvokeData("dwrite.h", MSDNShortId = "0d687337-8623-4014-967c-f533072e31cc")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("53737037-6d14-410b-9bfe-0b182bb70961")]
	public interface IDWriteTextLayout : IDWriteTextFormat
	{
		/// <summary>
		/// Sets the alignment of text in a paragraph, relative to the leading and trailing edge of a layout box for a IDWriteTextFormat interface.
		/// </summary>
		/// <param name="textAlignment">
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>The text alignment option being set for the paragraph of type DWRITE_TEXT_ALIGNMENT. For more information, see Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The text can be aligned to the leading or trailing edge of the layout box, or it can be centered. The following illustration
		/// shows text with the alignment set to DWRITE_TEXT_ALIGNMENT_LEADING, <c>DWRITE_TEXT_ALIGNMENT_CENTER</c>, and
		/// <c>DWRITE_TEXT_ALIGNMENT_TRAILING</c>, respectively.
		/// </para>
		/// <para>
		/// <c>Note</c> The alignment is dependent on reading direction, the above is for left-to-right reading direction. For
		/// right-to-left reading direction it would be the opposite.
		/// </para>
		/// <para>See DWRITE_TEXT_ALIGNMENT for more information.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settextalignment HRESULT
		// SetTextAlignment( DWRITE_TEXT_ALIGNMENT textAlignment );
		new void SetTextAlignment(DWRITE_TEXT_ALIGNMENT textAlignment);

		/// <summary>Sets the alignment option of a paragraph relative to the layout box's top and bottom edge.</summary>
		/// <param name="paragraphAlignment">
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>The paragraph alignment option being set for a paragraph; see DWRITE_PARAGRAPH_ALIGNMENT for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setparagraphalignment HRESULT
		// SetParagraphAlignment( DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment );
		new void SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment);

		/// <summary>Sets the word wrapping option.</summary>
		/// <param name="wordWrapping">
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>The word wrapping option being set for a paragraph; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setwordwrapping HRESULT
		// SetWordWrapping( DWRITE_WORD_WRAPPING wordWrapping );
		new void SetWordWrapping(DWRITE_WORD_WRAPPING wordWrapping);

		/// <summary>Sets the paragraph reading direction.</summary>
		/// <param name="readingDirection">
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// The text reading direction (for example, DWRITE_READING_DIRECTION_RIGHT_TO_LEFT for languages, such as Arabic, that read
		/// from right to left) for a paragraph.
		/// </para>
		/// </param>
		/// <remarks>
		/// The reading direction and flow direction must always be set 90 degrees orthogonal to each other, or else you will get the
		/// error DWRITE_E_FLOWDIRECTIONCONFLICTS when you use layout functions like Draw or GetMetrics. So if you set a vertical
		/// reading direction (for example, to DWRITE_READING_DIRECTION_TOP_TO_BOTTOM), then you must also use SetFlowDirection to set
		/// the flow direction appropriately (for example, to DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setreadingdirection HRESULT
		// SetReadingDirection( DWRITE_READING_DIRECTION readingDirection );
		new void SetReadingDirection(DWRITE_READING_DIRECTION readingDirection);

		/// <summary>Sets the paragraph flow direction.</summary>
		/// <param name="flowDirection">
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>The paragraph flow direction; see DWRITE_FLOW_DIRECTION for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setflowdirection HRESULT
		// SetFlowDirection( DWRITE_FLOW_DIRECTION flowDirection );
		new void SetFlowDirection(DWRITE_FLOW_DIRECTION flowDirection);

		/// <summary>Sets a fixed distance between two adjacent tab stops.</summary>
		/// <param name="incrementalTabStop">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The fixed distance between two adjacent tab stops.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setincrementaltabstop HRESULT
		// SetIncrementalTabStop( FLOAT incrementalTabStop );
		new void SetIncrementalTabStop(float incrementalTabStop);

		/// <summary>Sets trimming options for text overflowing the layout width.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>const DWRITE_TRIMMING*</c></para>
		/// <para>Text trimming options.</para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>Application-defined omission sign. This parameter may be <c>NULL</c>. See IDWriteInlineObject for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settrimming HRESULT SetTrimming(
		// DWRITE_TRIMMING const *trimmingOptions, IDWriteInlineObject *trimmingSign );
		new void SetTrimming(in DWRITE_TRIMMING trimmingOptions, [In, Optional] IDWriteInlineObject? trimmingSign);

		/// <summary>Sets the line spacing.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD</c></para>
		/// <para>Specifies how line height is being determined; see DWRITE_LINE_SPACING_METHOD for more information.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.</para>
		/// </param>
		/// <remarks>
		/// For the default method, spacing depends solely on the content. For uniform spacing, the specified line height overrides the content.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setlinespacing HRESULT SetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD lineSpacingMethod, FLOAT lineSpacing, FLOAT baseline );
		new void SetLineSpacing(DWRITE_LINE_SPACING_METHOD lineSpacingMethod, float lineSpacing, float baseline);

		/// <summary>Gets the alignment option of text relative to the layout box's leading and trailing edge.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>Returns the text alignment option of the current paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettextalignment DWRITE_TEXT_ALIGNMENT GetTextAlignment();
		[PreserveSig]
		new DWRITE_TEXT_ALIGNMENT GetTextAlignment();

		/// <summary>Gets the alignment option of a paragraph which is relative to the top and bottom edges of a layout box.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>A value that indicates the current paragraph alignment option.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getparagraphalignment
		// DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();
		[PreserveSig]
		new DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();

		/// <summary>Gets the word wrapping option.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>Returns the word wrapping option; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getwordwrapping DWRITE_WORD_WRAPPING GetWordWrapping();
		[PreserveSig]
		new DWRITE_WORD_WRAPPING GetWordWrapping();

		/// <summary>Gets the current reading direction for text in a paragraph.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>A value that indicates the current reading direction for text in a paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getreadingdirection
		// DWRITE_READING_DIRECTION GetReadingDirection();
		[PreserveSig]
		new DWRITE_READING_DIRECTION GetReadingDirection();

		/// <summary>Gets the direction that text lines flow.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>
		/// The direction that text lines flow within their parent container. For example, DWRITE_FLOW_DIRECTION_TOP_TO_BOTTOM indicates
		/// that text lines are placed from top to bottom.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getflowdirection DWRITE_FLOW_DIRECTION GetFlowDirection();
		[PreserveSig]
		new DWRITE_FLOW_DIRECTION GetFlowDirection();

		/// <summary>Gets the incremental tab stop position.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The incremental tab stop value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getincrementaltabstop FLOAT GetIncrementalTabStop();
		[PreserveSig]
		new float GetIncrementalTabStop();

		/// <summary>Gets the trimming options for text that overflows the layout box.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>DWRITE_TRIMMING*</c></para>
		/// <para>
		/// When this method returns, it contains a pointer to a DWRITE_TRIMMING structure that holds the text trimming options for the
		/// overflowing text.
		/// </para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>When this method returns, contains an address of a pointer to a trimming omission sign. This parameter may be <c>NULL</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettrimming HRESULT GetTrimming(
		// DWRITE_TRIMMING *trimmingOptions, IDWriteInlineObject **trimmingSign );
		new void GetTrimming(out DWRITE_TRIMMING trimmingOptions, out IDWriteInlineObject trimmingSign);

		/// <summary>Gets the line spacing adjustment set for a multiline text paragraph.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD*</c></para>
		/// <para>A value that indicates how line height is determined.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>
		/// When this method returns, contains the distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlinespacing HRESULT GetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD *lineSpacingMethod, FLOAT *lineSpacing, FLOAT *baseline );
		new void GetLineSpacing(out DWRITE_LINE_SPACING_METHOD lineSpacingMethod, out float lineSpacing, out float baseline);

		/// <summary>Gets the current font collection.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the font collection being used for the current text.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontcollection HRESULT
		// GetFontCollection( IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the length of the font family name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilynamelength UINT32 GetFontFamilyNameLength();
		[PreserveSig]
		new uint GetFontFamilyNameLength();

		/// <summary>Gets a copy of the font family name.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a character array, which is null-terminated, that receives the current font
		/// family name. The buffer allocated for this array should be at least the size, in elements, of nameSize.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the fontFamilyName character array, in character count, including the terminated <c>NULL</c> character. To find
		/// the size of fontFamilyName, use GetFontFamilyNameLength.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilyname HRESULT
		// GetFontFamilyName( WCHAR *fontFamilyName, UINT32 nameSize );
		new void GetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize);

		/// <summary>Gets the font weight of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the type of weight (such as normal, bold, or black).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontweight DWRITE_FONT_WEIGHT GetFontWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetFontWeight();

		/// <summary>Gets the font style of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value which indicates the type of font style (such as slope or incline).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstyle DWRITE_FONT_STYLE GetFontStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetFontStyle();

		/// <summary>Gets the font stretch of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch (such as normal or condensed).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstretch DWRITE_FONT_STRETCH GetFontStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetFontStretch();

		/// <summary>Gets the font size in DIP unites.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The current font size in DIP units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontsize FLOAT GetFontSize();
		[PreserveSig]
		new float GetFontSize();

		/// <summary>Gets the length of the locale name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalenamelength UINT32 GetLocaleNameLength();
		[PreserveSig]
		new uint GetLocaleNameLength();

		/// <summary>Gets a copy of the locale name.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Contains a character array that receives the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the character array, in character count, including the terminated <c>NULL</c> character. Use GetLocaleNameLength
		/// to get the size of the locale name character array.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalename HRESULT GetLocaleName(
		// WCHAR *localeName, UINT32 nameSize );
		new void GetLocaleName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize);

		/// <summary>Sets the layout maximum width.</summary>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the maximum width of the layout box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxwidth HRESULT SetMaxWidth( FLOAT
		// maxWidth );
		void SetMaxWidth(float maxWidth);

		/// <summary>Sets the layout maximum height.</summary>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the maximum height of the layout box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxheight HRESULT SetMaxHeight(
		// FLOAT maxHeight );
		void SetMaxHeight(float maxHeight);

		/// <summary>Sets the font collection.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>The font collection to set.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontcollection HRESULT
		// SetFontCollection( IDWriteFontCollection *fontCollection, DWRITE_TEXT_RANGE textRange );
		void SetFontCollection([In] IDWriteFontCollection fontCollection, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets null-terminated font family name for text within a specified text range.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The font family name that applies to the entire text string within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontfamilyname HRESULT
		// SetFontFamilyName( WCHAR const *fontFamilyName, DWRITE_TEXT_RANGE textRange );
		void SetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font weight for text within a text range specified by a DWRITE_TEXT_RANGE structure.</summary>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>The font weight to be set for text within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The font weight can be set to one of the predefined font weight values provided in the DWRITE_FONT_WEIGHT enumeration or an
		/// integer from 1 to 999. Values outside this range will cause the method to fail with an <c>E_INVALIDARG</c> return value.
		/// </para>
		/// <para>The following illustration shows an example of Normal and UltraBold weights for the Palatino Linotype typeface.</para>
		/// <para>Examples</para>
		/// <para>The following code illustrates how to set the font weight to bold.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontweight HRESULT SetFontWeight(
		// DWRITE_FONT_WEIGHT fontWeight, DWRITE_TEXT_RANGE textRange );
		void SetFontWeight(DWRITE_FONT_WEIGHT fontWeight, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font style for text within a text range specified by a DWRITE_TEXT_RANGE structure.</summary>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>The font style to be set for text within a range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>The text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The font style can be set to Normal, Italic or Oblique. The following illustration shows three styles for the Palatino font.
		/// For more information, see DWRITE_FONT_STYLE.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code illustrates how to set the font style to italic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstyle HRESULT SetFontStyle(
		// DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange );
		void SetFontStyle(DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font stretch for text within a specified text range.</summary>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch for text within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstretch HRESULT SetFontStretch(
		// DWRITE_FONT_STRETCH fontStretch, DWRITE_TEXT_RANGE textRange );
		void SetFontStretch(DWRITE_FONT_STRETCH fontStretch, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font size in DIP units for text within a specified text range.</summary>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The font size in DIP units to be set for text in the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontsize HRESULT SetFontSize( FLOAT
		// fontSize, DWRITE_TEXT_RANGE textRange );
		void SetFontSize(float fontSize, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets underlining for text within a specified text range.</summary>
		/// <param name="hasUnderline">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether underline takes place within a specified text range.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setunderline HRESULT SetUnderline( BOOL
		// hasUnderline, DWRITE_TEXT_RANGE textRange );
		void SetUnderline([MarshalAs(UnmanagedType.Bool)] bool hasUnderline, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets strikethrough for text within a specified text range.</summary>
		/// <param name="hasStrikethrough">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether strikethrough takes place in the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setstrikethrough HRESULT
		// SetStrikethrough( BOOL hasStrikethrough, DWRITE_TEXT_RANGE textRange );
		void SetStrikethrough([MarshalAs(UnmanagedType.Bool)] bool hasStrikethrough, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the application-defined drawing effect.</summary>
		/// <param name="drawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Application-defined drawing effects that apply to the range. This data object will be passed back to the application's
		/// drawing callbacks for final rendering.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>The text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// An ID2D1Brush, such as a color or gradient brush, can be set as a drawing effect if you are using the
		/// ID2D1RenderTarget::DrawTextLayout to draw text and that brush will be used to draw the specified range of text.
		/// </para>
		/// <para>
		/// This drawing effect is associated with the specified range and will be passed back to the application by way of the callback
		/// when the range is drawn at drawing time.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setdrawingeffect HRESULT
		// SetDrawingEffect( IUnknown *drawingEffect, DWRITE_TEXT_RANGE textRange );
		void SetDrawingEffect([MarshalAs(UnmanagedType.Interface)] object drawingEffect, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the inline object.</summary>
		/// <param name="inlineObject">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>An application-defined inline object.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The application may call this function to specify the set of properties describing an application-defined inline object for
		/// specific range.
		/// </para>
		/// <para>
		/// This inline object applies to the specified range and will be passed back to the application by way of the DrawInlineObject
		/// callback when the range is drawn. Any text in that range will be suppressed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setinlineobject HRESULT
		// SetInlineObject( IDWriteInlineObject *inlineObject, DWRITE_TEXT_RANGE textRange );
		void SetInlineObject([In] IDWriteInlineObject inlineObject, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets font typography features for text within a specified text range.</summary>
		/// <param name="typography">
		/// <para>Type: <c>IDWriteTypography*</c></para>
		/// <para>Pointer to font typography settings.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-settypography HRESULT SetTypography(
		// IDWriteTypography *typography, DWRITE_TEXT_RANGE textRange );
		void SetTypography([In] IDWriteTypography typography, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the locale name for text within a specified text range.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>A null-terminated locale name string.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setlocalename HRESULT SetLocaleName(
		// WCHAR const *localeName, DWRITE_TEXT_RANGE textRange );
		void SetLocaleName([MarshalAs(UnmanagedType.LPWStr)] string localeName, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the layout maximum width.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the layout maximum width.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxwidth FLOAT GetMaxWidth();
		[PreserveSig]
		float GetMaxWidth();

		/// <summary>Gets the layout maximum height.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The layout maximum height.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxheight FLOAT GetMaxHeight();
		[PreserveSig]
		float GetMaxHeight();

		/// <summary>Gets the font collection associated with the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>Contains an address of a pointer to the current font collection.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the underline.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontcollection HRESULT
		// GetFontCollection( UINT32 currentPosition, IDWriteFontCollection **fontCollection, DWRITE_TEXT_RANGE *textRange );
		void GetFontCollection(uint currentPosition, out IDWriteFontCollection fontCollection, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Get the length of the font family name at the current position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="nameLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// When this method returns, contains the size of the character array containing the font family name, in character count, not
		/// including the terminated <c>NULL</c> character.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the font family.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilynamelength HRESULT
		// GetFontFamilyNameLength( UINT32 currentPosition, UINT32 *nameLength, DWRITE_TEXT_RANGE *textRange );
		void GetFontFamilyNameLength(uint currentPosition, out uint nameLength, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Copies the font family name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to examine.</para>
		/// </param>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains an array of characters that receives the current font family name. You must allocate
		/// storage for this parameter.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the font family name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilyname HRESULT
		// GetFontFamilyName( UINT32 currentPosition, WCHAR *fontFamilyName, UINT32 nameSize, DWRITE_TEXT_RANGE *textRange );
		void GetFontFamilyName(uint currentPosition, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font weight of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font weight being applied at the specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the font weight.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontweight HRESULT GetFontWeight(
		// UINT32 currentPosition, DWRITE_FONT_WEIGHT *fontWeight, DWRITE_TEXT_RANGE *textRange );
		void GetFontWeight(uint currentPosition, out DWRITE_FONT_WEIGHT fontWeight, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font style (also known as slope) of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font style (also known as slope or incline) being
		/// applied at the specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the font style.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstyle HRESULT GetFontStyle(
		// UINT32 currentPosition, DWRITE_FONT_STYLE *fontStyle, DWRITE_TEXT_RANGE *textRange );
		void GetFontStyle(uint currentPosition, out DWRITE_FONT_STYLE fontStyle, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font stretch of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font stretch (also known as width) being applied at
		/// the specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the font stretch.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstretch HRESULT GetFontStretch(
		// UINT32 currentPosition, DWRITE_FONT_STRETCH *fontStretch, DWRITE_TEXT_RANGE *textRange );
		void GetFontStretch(uint currentPosition, out DWRITE_FONT_STRETCH fontStretch, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font em height of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the size of the font in ems of the text at the specified position.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the font size.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontsize HRESULT GetFontSize( UINT32
		// currentPosition, FLOAT *fontSize, DWRITE_TEXT_RANGE *textRange );
		void GetFontSize(uint currentPosition, out float fontSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the underline presence of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="hasUnderline">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A Boolean flag that indicates whether underline is present at the position indicated by currentPosition.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the underline.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getunderline HRESULT GetUnderline(
		// UINT32 currentPosition, BOOL *hasUnderline, DWRITE_TEXT_RANGE *textRange );
		void GetUnderline(uint currentPosition, [MarshalAs(UnmanagedType.Bool)] out bool hasUnderline, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Get the strikethrough presence of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="hasStrikethrough">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A Boolean flag that indicates whether strikethrough is present at the position indicated by currentPosition.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// Contains the range of text that has the same formatting as the text at the position specified by currentPosition. This means
		/// the run has the exact formatting as the position specified, including but not limited to strikethrough.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getstrikethrough HRESULT
		// GetStrikethrough( UINT32 currentPosition, BOOL *hasStrikethrough, DWRITE_TEXT_RANGE *textRange );
		void GetStrikethrough(uint currentPosition, [MarshalAs(UnmanagedType.Bool)] out bool hasStrikethrough, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the application-defined drawing effect at the specified text position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text whose drawing effect is to be retrieved.</para>
		/// </param>
		/// <param name="drawingEffect">
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the current application-defined drawing effect. Usually this
		/// effect is a foreground brush that is used in glyph drawing.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// Contains the range of text that has the same formatting as the text at the position specified by currentPosition. This means
		/// the run has the exact formatting as the position specified, including but not limited to the drawing effect.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getdrawingeffect HRESULT
		// GetDrawingEffect( UINT32 currentPosition, IUnknown **drawingEffect, DWRITE_TEXT_RANGE *textRange );
		void GetDrawingEffect(uint currentPosition, [MarshalAs(UnmanagedType.Interface)] out object drawingEffect, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the inline object at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The specified text position.</para>
		/// </param>
		/// <param name="inlineObject">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>Contains the application-defined inline object.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the inline object.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getinlineobject HRESULT
		// GetInlineObject( UINT32 currentPosition, IDWriteInlineObject **inlineObject, DWRITE_TEXT_RANGE *textRange );
		void GetInlineObject(uint currentPosition, out IDWriteInlineObject inlineObject, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the typography setting of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="typography">
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the current typography setting.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the typography.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-gettypography HRESULT GetTypography(
		// UINT32 currentPosition, IDWriteTypography **typography, DWRITE_TEXT_RANGE *textRange );
		void GetTypography(uint currentPosition, out IDWriteTypography typography, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the length of the locale name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="nameLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the locale name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalenamelength HRESULT
		// GetLocaleNameLength( UINT32 currentPosition, UINT32 *nameLength, DWRITE_TEXT_RANGE *textRange );
		void GetLocaleNameLength(uint currentPosition, out uint nameLength, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the locale name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>When this method returns, contains the character array receiving the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Size of the character array, in character count, including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run
		/// has the exact formatting as the position specified, including but not limited to the locale name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalename HRESULT GetLocaleName(
		// UINT32 currentPosition, WCHAR *localeName, UINT32 nameSize, DWRITE_TEXT_RANGE *textRange );
		void GetLocaleName(uint currentPosition, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Draws text using the specified client drawing context.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>An application-defined drawing context.</para>
		/// </param>
		/// <param name="renderer">
		/// <para>Type: <c>IDWriteTextRenderer*</c></para>
		/// <para>Pointer to the set of callback functions used to draw parts of a text string.</para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the layout's left side.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the layout's top side.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>To draw text with this method, a textLayout object needs to be created by the application using IDWriteFactory::CreateTextLayout.</para>
		/// <para>
		/// After the textLayout object is obtained, the application calls the <c>IDWriteTextLayout::Draw</c> method to draw the text,
		/// decorations, and inline objects. The actual drawing is done through the callback interface passed in as the textRenderer
		/// argument; there, the corresponding DrawGlyphRun API is called.
		/// </para>
		/// <para>
		/// If you set a vertical text reading direction on IDWriteTextLayout via SetReadingDirection with
		/// DWRITE_READING_DIRECTION_TOP_TO_BOTTOM (or bottom to top), then you must pass an interface that implements
		/// IDWriteTextRenderer1. Otherwise you get the error DWRITE_E_TEXTRENDERERINCOMPATIBLE because the original IDWriteTextRenderer
		/// interface only supported horizontal text.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-draw HRESULT Draw( void
		// *clientDrawingContext, IDWriteTextRenderer *renderer, FLOAT originX, FLOAT originY );
		void Draw([In, Optional] IntPtr clientDrawingContext, [In] IDWriteTextRenderer renderer, float originX, float originY);

		/// <summary>Retrieves the information about each individual text line of the text string.</summary>
		/// <param name="lineMetrics">
		/// <para>Type: <c>DWRITE_LINE_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to an array of structures containing various calculated length values of
		/// individual text lines.
		/// </para>
		/// </param>
		/// <param name="maxLineCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum size of the lineMetrics array.</para>
		/// </param>
		/// <param name="actualLineCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the actual size of the lineMetricsarray that is needed.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If maxLineCount is not large enough E_NOT_SUFFICIENT_BUFFER, which is equivalent to
		/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), is returned and *actualLineCount is set to the number of lines needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlinemetrics HRESULT GetLineMetrics(
		// DWRITE_LINE_METRICS *lineMetrics, UINT32 maxLineCount, UINT32 *actualLineCount );
		void GetLineMetrics([Out, Optional, MarshalAs(UnmanagedType.LPArray)] DWRITE_LINE_METRICS[]? lineMetrics, uint maxLineCount, out uint actualLineCount);

		/// <summary>Retrieves overall metrics for the formatted string.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_METRICS*</c></para>
		/// <para>When this method returns, contains the measured distances of text and associated content after being formatted.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmetrics HRESULT GetMetrics(
		// DWRITE_TEXT_METRICS *textMetrics );
		DWRITE_TEXT_METRICS GetMetrics();

		/// <summary>
		/// Returns the overhangs (in DIPs) of the layout and all objects contained in it, including text glyphs and inline objects.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_OVERHANG_METRICS*</c></para>
		/// <para>Overshoots of visible extents (in DIPs) outside the layout.</para>
		/// </returns>
		/// <remarks>
		/// Underlines and strikethroughs do not contribute to the black box determination, since these are actually drawn by the
		/// renderer, which is allowed to draw them in any variety of styles.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getoverhangmetrics HRESULT
		// GetOverhangMetrics( DWRITE_OVERHANG_METRICS *overhangs );
		DWRITE_OVERHANG_METRICS GetOverhangMetrics();

		/// <summary>Retrieves logical properties and measurements of each glyph cluster.</summary>
		/// <param name="clusterMetrics">
		/// <para>Type: <c>DWRITE_CLUSTER_METRICS*</c></para>
		/// <para>When this method returns, contains metrics, such as line-break or total advance width, for a glyph cluster.</para>
		/// </param>
		/// <param name="maxClusterCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum size of the clusterMetrics array.</para>
		/// </param>
		/// <param name="actualClusterCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the actual size of the clusterMetrics array that is needed.</para>
		/// </param>
		/// <remarks>
		/// If maxClusterCount is not large enough, then E_NOT_SUFFICIENT_BUFFER, which is equivalent to
		/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), is returned and actualClusterCount is set to the number of clusters needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getclustermetrics HRESULT
		// GetClusterMetrics( DWRITE_CLUSTER_METRICS *clusterMetrics, UINT32 maxClusterCount, UINT32 *actualClusterCount );
		void GetClusterMetrics([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_CLUSTER_METRICS[]? clusterMetrics, uint maxClusterCount, out uint actualClusterCount);

		/// <summary>
		/// Determines the minimum possible width the layout can be set to without emergency breaking between the characters of whole
		/// words occurring.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>Minimum width.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-determineminwidth HRESULT
		// DetermineMinWidth( FLOAT *minWidth );
		float DetermineMinWidth();

		/// <summary>
		/// The application calls this function passing in a specific pixel location relative to the top-left location of the layout box
		/// and obtains the information about the correspondent hit-test metrics of the text string where the hit-test has occurred.
		/// When the specified pixel location is outside the text string, the function sets the output value *isInside to <c>FALSE</c>.
		/// </summary>
		/// <param name="pointX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location X to hit-test, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="pointY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location Y to hit-test, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="isTrailingHit">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// An output flag that indicates whether the hit-test location is at the leading or the trailing side of the character. When
		/// the output *isInside value is set to <c>FALSE</c>, this value is set according to the output hitTestMetrics-&gt;textPosition
		/// value to represent the edge closest to the hit-test location.
		/// </para>
		/// </param>
		/// <param name="isInside">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// An output flag that indicates whether the hit-test location is inside the text string. When <c>FALSE</c>, the position
		/// nearest the text's edge is returned.
		/// </para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>
		/// The output geometry fully enclosing the hit-test location. When the output *isInside value is set to <c>FALSE</c>, this
		/// structure represents the geometry enclosing the edge closest to the hit-test location.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittestpoint HRESULT HitTestPoint(
		// FLOAT pointX, FLOAT pointY, BOOL *isTrailingHit, BOOL *isInside, DWRITE_HIT_TEST_METRICS *hitTestMetrics );
		void HitTestPoint(float pointX, float pointY, [MarshalAs(UnmanagedType.Bool)] out bool isTrailingHit,
			[MarshalAs(UnmanagedType.Bool)] out bool isInside, out DWRITE_HIT_TEST_METRICS hitTestMetrics);

		/// <summary>
		/// The application calls this function to get the pixel location relative to the top-left of the layout box given the text
		/// position and the logical side of the position. This function is normally used as part of caret positioning of text where the
		/// caret is drawn at the location corresponding to the current text editing position. It may also be used as a way to
		/// programmatically obtain the geometry of a particular text position in UI automation.
		/// </summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text position used to get the pixel location.</para>
		/// </param>
		/// <param name="isTrailingHit">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean flag that indicates whether the pixel location is of the leading or the trailing side of the specified text position.
		/// </para>
		/// </param>
		/// <param name="pointX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the output pixel location X, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="pointY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the output pixel location Y, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>When this method returns, contains the output geometry fully enclosing the specified text position.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextposition HRESULT
		// HitTestTextPosition( UINT32 textPosition, BOOL isTrailingHit, FLOAT *pointX, FLOAT *pointY, DWRITE_HIT_TEST_METRICS
		// *hitTestMetrics );
		void HitTestTextPosition(uint textPosition, [MarshalAs(UnmanagedType.Bool)] bool isTrailingHit, out float pointX, out float pointY,
			out DWRITE_HIT_TEST_METRICS hitTestMetrics);

		/// <summary>
		/// <para>
		/// The application calls this function to get a set of hit-test metrics corresponding to a range of text positions. One of the
		/// main usages is to implement highlight selection of the text string.
		/// </para>
		/// <para>
		/// The function returns E_NOT_SUFFICIENT_BUFFER, which is equivalent to HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), when the
		/// buffer size of hitTestMetrics is too small to hold all the regions calculated by the function. In this situation, the
		/// function sets the output value *actualHitTestMetricsCount to the number of geometries calculated.
		/// </para>
		/// <para>The application is responsible for allocating a new buffer of greater size and calling the function again.</para>
		/// <para>A good value to use as an initial value for maxHitTestMetricsCount may be calculated from the following equation:</para>
		/// <para>
		/// where lineCount is obtained from the value of the output argument *actualLineCount (from the function
		/// IDWriteTextLayout::GetLineLengths), and the maxBidiReorderingDepth value from the DWRITE_TEXT_METRICSstructure of the output
		/// argument *textMetrics (from the function IDWriteFactory::CreateTextLayout).
		/// </para>
		/// </summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The first text position of the specified range.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of positions of the specified range.</para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The origin pixel location X at the left of the layout box. This offset is added to the hit-test metrics returned.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The origin pixel location Y at the top of the layout box. This offset is added to the hit-test metrics returned.</para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a buffer of the output geometry fully enclosing the specified position
		/// range. The buffer must be at least as large as maxHitTestMetricsCount.
		/// </para>
		/// </param>
		/// <param name="maxHitTestMetricsCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Maximum number of boxes hitTestMetrics could hold in its buffer memory.</para>
		/// </param>
		/// <param name="actualHitTestMetricsCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Actual number of geometries hitTestMetrics holds in its buffer memory.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextrange HRESULT
		// HitTestTextRange( UINT32 textPosition, UINT32 textLength, FLOAT originX, FLOAT originY, DWRITE_HIT_TEST_METRICS
		// *hitTestMetrics, UINT32 maxHitTestMetricsCount, UINT32 *actualHitTestMetricsCount );
		void HitTestTextRange(uint textPosition, uint textLength, float originX, float originY,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_HIT_TEST_METRICS[]? hitTestMetrics,
			uint maxHitTestMetricsCount, out uint actualHitTestMetricsCount);
	}

	/// <summary>
	/// Represents a set of application-defined callbacks that perform rendering of text, inline objects, and decorations such as underlines.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritetextrenderer
	[PInvokeData("dwrite.h", MSDNShortId = "a2ac70c8-e33b-46f1-b53b-1ab07555f109")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ef8a8135-5cc6-45fe-8825-c5a0724eb819")]
	public interface IDWriteTextRenderer : IDWritePixelSnapping
	{
		/// <summary>
		/// Determines whether pixel snapping is disabled. The recommended default is <c>FALSE</c>, unless doing animation that requires
		/// subpixel vertical placement.
		/// </summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The context passed to <c>IDWriteTextLayout::Draw</c>.</para>
		/// </param>
		/// <returns>
		/// <para>[out] Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if pixel snapping is disabled; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd371281(v%3Dvs.85) virtual HRESULT
		// IsPixelSnappingEnabled( void * clientDrawingContext, [out] BOOL * isDisabled ) = 0;
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsPixelSnappingDisabled([In, Optional] IntPtr clientDrawingContext);

		/// <summary>Gets a transform that maps abstract coordinates to DIPs.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The drawing context passed to IDWriteTextLayout::Draw.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_MATRIX*</c></para>
		/// <para>When this method returns, contains a structure which has transform information for pixel snapping.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritepixelsnapping-getcurrenttransform HRESULT
		// GetCurrentTransform( void *clientDrawingContext, DWRITE_MATRIX *transform );
		new DWRITE_MATRIX GetCurrentTransform([In, Optional] IntPtr clientDrawingContext);

		/// <summary>Gets the number of physical pixels per DIP.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The drawing context passed to IDWriteTextLayout::Draw.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the number of physical pixels per DIP.</para>
		/// </returns>
		/// <remarks>
		/// Because a DIP (device-independent pixel) is 1/96 inch, the pixelsPerDip value is the number of logical pixels per inch
		/// divided by 96.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritepixelsnapping-getpixelsperdip HRESULT
		// GetPixelsPerDip( void *clientDrawingContext, FLOAT *pixelsPerDip );
		new float GetPixelsPerDip([In, Optional] IntPtr clientDrawingContext);

		/// <summary>IDWriteTextLayout::Draw calls this function to instruct the client to render a run of glyphs.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The application-defined drawing context passed to IDWriteTextLayout::Draw.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location (X-coordinate) at the baseline origin of the glyph run.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location (Y-coordinate) at the baseline origin of the glyph run.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>The measuring method for glyphs in the run, used with the other properties to determine the rendering mode.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>Pointer to the glyph run instance to render.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN_DESCRIPTION*</c></para>
		/// <para>A pointer to the glyph run description instance which contains properties of the characters associated with this run.</para>
		/// </param>
		/// <param name="clientDrawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Application-defined drawing effects for the glyphs to render. Usually this argument represents effects such as the
		/// foreground brush filling the interior of text.
		/// </para>
		/// </param>
		/// <remarks>
		/// The IDWriteTextLayout::Draw function calls this callback function with all the information about glyphs to render. The
		/// application implements this callback by mostly delegating the call to the underlying platform's graphics API such as
		/// Direct2D to draw glyphs on the drawing context. An application that uses GDI can implement this callback in terms of the
		/// IDWriteBitmapRenderTarget::DrawGlyphRun method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawglyphrun HRESULT DrawGlyphRun(
		// void *clientDrawingContext, FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_MEASURING_MODE measuringMode,
		// DWRITE_GLYPH_RUN const *glyphRun, DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, IUnknown *clientDrawingEffect );
		void DrawGlyphRun([In, Optional] IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY, DWRITE_MEASURING_MODE measuringMode,
			in DWRITE_GLYPH_RUN glyphRun, in DWRITE_GLYPH_RUN_DESCRIPTION glyphRunDescription, [In, Optional, MarshalAs(UnmanagedType.Interface)] object clientDrawingEffect);

		/// <summary>IDWriteTextLayout::Draw calls this function to instruct the client to draw an underline.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The application-defined drawing context passed to IDWriteTextLayout::Draw.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location (X-coordinate) at the baseline origin of the run where underline applies.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location (Y-coordinate) at the baseline origin of the run where underline applies.</para>
		/// </param>
		/// <param name="underline">
		/// <para>Type: <c>const DWRITE_UNDERLINE*</c></para>
		/// <para>Pointer to a structure containing underline logical information.</para>
		/// </param>
		/// <param name="clientDrawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Application-defined effect to apply to the underline. Usually this argument represents effects such as the foreground brush
		/// filling the interior of a line.
		/// </para>
		/// </param>
		/// <remarks>
		/// A single underline can be broken into multiple calls, depending on how the formatting changes attributes. If font
		/// sizes/styles change within an underline, the thickness and offset will be averaged weighted according to characters. To get
		/// an appropriate starting pixel position, add underline::offset to the baseline. Otherwise there will be no spacing between
		/// the text. The x coordinate will always be passed as the left side, regardless of text directionality. This simplifies
		/// drawing and reduces the problem of round-off that could potentially cause gaps or a double stamped alpha blend. To avoid
		/// alpha overlap, round the end points to the nearest device pixel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawunderline HRESULT DrawUnderline(
		// void *clientDrawingContext, FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_UNDERLINE const *underline, IUnknown
		// *clientDrawingEffect );
		void DrawUnderline([In, Optional] IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY,
			in DWRITE_UNDERLINE underline, [In, Optional] [MarshalAs(UnmanagedType.Interface)] object clientDrawingEffect);

		/// <summary>IDWriteTextLayout::Draw calls this function to instruct the client to draw a strikethrough.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The application-defined drawing context passed to IDWriteTextLayout::Draw.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location (X-coordinate) at the baseline origin of the run where strikethrough applies.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location (Y-coordinate) at the baseline origin of the run where strikethrough applies.</para>
		/// </param>
		/// <param name="strikethrough">
		/// <para>Type: <c>const DWRITE_STRIKETHROUGH*</c></para>
		/// <para>Pointer to a structure containing strikethrough logical information.</para>
		/// </param>
		/// <param name="clientDrawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Application-defined effect to apply to the strikethrough. Usually this argument represents effects such as the foreground
		/// brush filling the interior of a line.
		/// </para>
		/// </param>
		/// <remarks>
		/// A single strikethrough can be broken into multiple calls, depending on how the formatting changes attributes. Strikethrough
		/// is not averaged across font sizes/styles changes. To get an appropriate starting pixel position, add strikethrough::offset
		/// to the baseline. Like underlines, the x coordinate will always be passed as the left side, regardless of text directionality.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawstrikethrough HRESULT
		// DrawStrikethrough( void *clientDrawingContext, FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_STRIKETHROUGH const
		// *strikethrough, IUnknown *clientDrawingEffect );
		void DrawStrikethrough([In, Optional] IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY,
			in DWRITE_STRIKETHROUGH strikethrough, [In, Optional, MarshalAs(UnmanagedType.Interface)] object clientDrawingEffect);

		/// <summary>IDWriteTextLayout::Draw calls this application callback when it needs to draw an inline object.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>The application-defined drawing context passed to IDWriteTextLayout::Draw.</para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>X-coordinate at the top-left corner of the inline object.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Y-coordinate at the top-left corner of the inline object.</para>
		/// </param>
		/// <param name="inlineObject">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>The application-defined inline object set using IDWriteTextFormat::SetInlineObject.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether the object's baseline runs alongside the baseline axis of the line.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean flag that indicates whether the object is in a right-to-left context, hinting that the drawing may want to mirror
		/// the normal image.
		/// </para>
		/// </param>
		/// <param name="clientDrawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Application-defined drawing effects for the glyphs to render. Usually this argument represents effects such as the
		/// foreground brush filling the interior of a line.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawinlineobject HRESULT
		// DrawInlineObject( void *clientDrawingContext, FLOAT originX, FLOAT originY, IDWriteInlineObject *inlineObject, BOOL
		// isSideways, BOOL isRightToLeft, IUnknown *clientDrawingEffect );
		void DrawInlineObject([In, Optional] IntPtr clientDrawingContext, float originX, float originY, [In] IDWriteInlineObject inlineObject,
			[MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			[In, Optional] [MarshalAs(UnmanagedType.Interface)] object clientDrawingEffect);
	}

	/// <summary>Represents a font typography setting.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritetypography
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("55f1112b-1dc2-4b3c-9541-f46894ed85b6")]
	public interface IDWriteTypography
	{
		/// <summary>Adds an OpenType font feature.</summary>
		/// <param name="fontFeature">
		/// <para>Type: <c>DWRITE_FONT_FEATURE</c></para>
		/// <para>A structure that contains the OpenType name identifier and the execution parameter for the font feature being added.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetypography-addfontfeature HRESULT AddFontFeature(
		// DWRITE_FONT_FEATURE fontFeature );
		void AddFontFeature(DWRITE_FONT_FEATURE fontFeature);

		/// <summary>Gets the number of OpenType font features for the current font.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font features for the current text format.</para>
		/// </returns>
		/// <remarks>
		/// A single run of text can be associated with more than one typographic feature. The IDWriteTypography object holds a list of
		/// these font features.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetypography-getfontfeaturecount UINT32 GetFontFeatureCount();
		[PreserveSig]
		uint GetFontFeatureCount();

		/// <summary>Gets the font feature at the specified index.</summary>
		/// <param name="fontFeatureIndex">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The zero-based index of the font feature to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_FEATURE*</c></para>
		/// <para>When this method returns, contains the font feature which is at the specified index.</para>
		/// </returns>
		/// <remarks>
		/// A single run of text can be associated with more than one typographic feature. The IDWriteTypography object holds a list of
		/// these font features.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetypography-getfontfeature HRESULT GetFontFeature(
		// UINT32 fontFeatureIndex, DWRITE_FONT_FEATURE *fontFeature );
		DWRITE_FONT_FEATURE GetFontFeature(uint fontFeatureIndex);
	}

	/// <summary>Creates a DirectWrite factory object that is used for subsequent creation of individual DirectWrite objects.</summary>
	/// <param name="factoryType">
	/// <para>Type: <c>DWRITE_FACTORY_TYPE</c></para>
	/// <para>A value that specifies whether the factory object will be shared or isolated.</para>
	/// </param>
	/// <param name="iid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>A GUID value that identifies the DirectWrite factory interface, such as __uuidof(IDWriteFactory).</para>
	/// </param>
	/// <param name="factory">
	/// <para>Type: <c>IUnknown**</c></para>
	/// <para>An address of a pointer to the newly created DirectWrite factory object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function creates a DirectWrite factory object that is used for subsequent creation of individual DirectWrite objects.
	/// DirectWrite factory contains internal state data such as font loader registration and cached font data. In most cases it is
	/// recommended you use the shared factory object, because it allows multiple components that use DirectWrite to share internal
	/// DirectWrite state data, and thereby reduce memory usage. However, there are cases when it is desirable to reduce the impact of a
	/// component, such as a plug-in from an untrusted source, on the rest of the process, by sandboxing and isolating it from the rest
	/// of the process components. In such cases, it is recommended you use an isolated factory for the sandboxed component.
	/// </para>
	/// <para>The following example shows how to create a shared DirectWrite factory.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-dwritecreatefactory HRESULT DWriteCreateFactory(
	// DWRITE_FACTORY_TYPE factoryType, REFIID iid, IUnknown **factory );
	[DllImport("dwrite.dll", SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dwrite.h", MSDNShortId = "c74c0906-0a5c-4ab8-87cf-a195566e1d9e")]
	public static extern HRESULT DWriteCreateFactory(DWRITE_FACTORY_TYPE factoryType, in Guid iid, [MarshalAs(UnmanagedType.Interface)] out object factory);

	/// <summary>Creates a DirectWrite factory object that is used for subsequent creation of individual DirectWrite objects.</summary>
	/// <typeparam name="T">Identifies the DirectWrite factory interface, such as IDWriteFactory.</typeparam>
	/// <param name="factoryType">
	/// <para>Type: <c>DWRITE_FACTORY_TYPE</c></para>
	/// <para>A value that specifies whether the factory object will be shared or isolated.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>IUnknown**</c></para>
	/// <para>An address of a pointer to the newly created DirectWrite factory object.</para>
	/// </returns>
	/// <remarks>
	/// This function creates a DirectWrite factory object that is used for subsequent creation of individual DirectWrite objects.
	/// DirectWrite factory contains internal state data such as font loader registration and cached font data. In most cases it is
	/// recommended you use the shared factory object, because it allows multiple components that use DirectWrite to share internal
	/// DirectWrite state data, and thereby reduce memory usage. However, there are cases when it is desirable to reduce the impact of a
	/// component, such as a plug-in from an untrusted source, on the rest of the process, by sandboxing and isolating it from the rest
	/// of the process components. In such cases, it is recommended you use an isolated factory for the sandboxed component.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-dwritecreatefactory HRESULT DWriteCreateFactory(
	// DWRITE_FACTORY_TYPE factoryType, REFIID iid, IUnknown **factory );
	[PInvokeData("dwrite.h", MSDNShortId = "c74c0906-0a5c-4ab8-87cf-a195566e1d9e")]
	public static T DWriteCreateFactory<T>(DWRITE_FACTORY_TYPE factoryType = DWRITE_FACTORY_TYPE.DWRITE_FACTORY_TYPE_SHARED) where T : class
	{
#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		DWriteCreateFactory(factoryType, typeof(T).GUID, out var factory).ThrowIfFailed();
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		return (T)factory;
	}
}