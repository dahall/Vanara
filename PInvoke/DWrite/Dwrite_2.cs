namespace Vanara.PInvoke;

public static partial class Dwrite
{
	/// <summary>Specifies whether to enable grid-fitting of glyph outlines (also known as hinting).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/ne-dwrite_2-dwrite_grid_fit_mode typedef enum DWRITE_GRID_FIT_MODE {
	// DWRITE_GRID_FIT_MODE_DEFAULT, DWRITE_GRID_FIT_MODE_DISABLED, DWRITE_GRID_FIT_MODE_ENABLED } ;
	[PInvokeData("dwrite_2.h", MSDNShortId = "NE:dwrite_2.DWRITE_GRID_FIT_MODE")]
	public enum DWRITE_GRID_FIT_MODE
	{
		/// <summary>Choose grid fitting based on the font's table information.</summary>
		DWRITE_GRID_FIT_MODE_DEFAULT,

		/// <summary>Always disable grid fitting, using the ideal glyph outlines.</summary>
		DWRITE_GRID_FIT_MODE_DISABLED,

		/// <summary>Enable grid fitting, adjusting glyph outlines for device pixel display.</summary>
		DWRITE_GRID_FIT_MODE_ENABLED,
	}

	/// <summary>
	/// <para>The optical margin alignment mode.</para>
	/// <para>
	/// By default, glyphs are aligned to the margin by the default origin and side-bearings of the glyph. If you specify
	/// <b>DWRITE_OPTICAL_ALIGNMENT_NO_SIDE_BEARINGS</b>, then the alignment uses the side bearings to offset the glyph from the aligned
	/// edge to ensure the ink of the glyphs are aligned.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/ne-dwrite_2-dwrite_optical_alignment typedef enum
	// DWRITE_OPTICAL_ALIGNMENT { DWRITE_OPTICAL_ALIGNMENT_NONE, DWRITE_OPTICAL_ALIGNMENT_NO_SIDE_BEARINGS } ;
	[PInvokeData("dwrite_2.h", MSDNShortId = "NE:dwrite_2.DWRITE_OPTICAL_ALIGNMENT")]
	public enum DWRITE_OPTICAL_ALIGNMENT
	{
		/// <summary>Align to the default origin and side-bearings of the glyph.</summary>
		DWRITE_OPTICAL_ALIGNMENT_NONE,

		/// <summary>Align to the ink of the glyphs, such that the black box abuts the margins.</summary>
		DWRITE_OPTICAL_ALIGNMENT_NO_SIDE_BEARINGS,
	}

	/// <summary>
	/// This interface allows the application to enumerate through the color glyph runs. The enumerator enumerates the layers in a back to
	/// front order for appropriate layering.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nn-dwrite_2-idwritecolorglyphrunenumerator
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteColorGlyphRunEnumerator")]
	[ComImport, Guid("D31FBE17-F157-41A2-8D24-CB779E0560E8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteColorGlyphRunEnumerator
	{
		/// <summary>Move to the next glyph run in the enumerator.</summary>
		/// <returns>
		/// <para>Type: <b>bool*</b></para>
		/// <para>Returns <b>TRUE</b> if there is a next glyph run.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritecolorglyphrunenumerator-movenext HRESULT
		// MoveNext( [out] bool *hasRun );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool MoveNext();

		/// <summary/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_2/nf-dwrite_2-idwritecolorglyphrunenumerator-getcurrentrun
		// HRESULT GetCurrentRun( DWRITE_COLOR_GLYPH_RUN const **colorGlyphRun );
		DWRITE_COLOR_GLYPH_RUN GetCurrentRun();
	}

	/// <summary>The root factory interface for all <c>DirectWrite</c> objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nn-dwrite_2-idwritefactory2
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteFactory2")]
	[ComImport, Guid("0439FC60-CA44-4994-8DEE-3A9AF7B732EC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFactory2 : IDWriteFactory, IDWriteFactory1
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
		IDWriteFontFallback GetSystemFontFallback();

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
		IDWriteFontFallbackBuilder CreateFontFallbackBuilder();

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
		IDWriteColorGlyphRunEnumerator TranslateColorGlyphRun(float baselineOriginX, float baselineOriginY, in DWRITE_GLYPH_RUN glyphRun,
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
		IDWriteRenderingParams2 CreateCustomRenderingParams(float gamma, float enhancedContrast, float grayscaleEnhancedContrast, float clearTypeLevel,
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
		IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, DWRITE_GRID_FIT_MODE gridFitMode, DWRITE_TEXT_ANTIALIAS_MODE antialiasMode,
			float baselineOriginX, float baselineOriginY);
	}

	/// <summary>
	/// <para>Represents a physical font in a font collection.</para>
	/// <para>This interface adds the ability to check if a color rendering path is potentially necessary.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nn-dwrite_2-idwritefont2
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteFont2")]
	[ComImport, Guid("29748ED6-8C9C-4A6A-BE0B-D912E8538944"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFont2 : IDWriteFont, IDWriteFont1
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
		/// <para>Type: <c>UINT32</c></para>
		/// <para>A Unicode (UCS-4) character value for the method to inspect.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>bool*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font supports the specified character; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-hascharacter HRESULT HasCharacter( UINT32
		// unicodeValue, bool *exists );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool HasCharacter(uint unicodeValue);

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
		bool IsColorFont();
	}

	/// <summary>
	/// <para>
	/// Represents an absolute reference to a font face. This interface contains font face type, appropriate file references, and face
	/// identification data. It adds the ability to check whether a color rendering path is potentially necessary.
	/// </para>
	/// <para>
	/// This interface extends <c>IDWriteFontFace1</c>. Various font data such as metrics, names, and glyph outlines are obtained from <b>IDWriteFontFace</b>.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nn-dwrite_2-idwritefontface2
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteFontFace2")]
	[ComImport, Guid("D8B768FF-64BC-4E66-982B-EC8E87F693F7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFace2 : IDWriteFontFace, IDWriteFontFace1
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
		bool IsColorFont();

		/// <summary>Gets the number of color palettes defined by the font.</summary>
		/// <returns>
		/// The return value is zero if the font has no color information. Color fonts are required to define at least one palette, with
		/// palette index zero reserved as the default palette.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getcolorpalettecount UINT32 GetColorPaletteCount();
		[PreserveSig]
		uint GetColorPaletteCount();

		/// <summary>Get the number of entries in each color palette.</summary>
		/// <returns>
		/// The number of entries in each color palette. All color palettes in a font have the same number of palette entries. The return
		/// value is zero if the font has no color information.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentrycount UINT32 GetPaletteEntryCount();
		[PreserveSig]
		uint GetPaletteEntryCount();

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
		HRESULT GetPaletteEntries(uint colorPaletteIndex, uint firstEntryIndex, uint entryCount,
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
		void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [In, Optional] IDWriteRenderingParams? renderingParams,
			out DWRITE_RENDERING_MODE renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);
	}

	/// <summary>
	/// <para>Allows you to access fallback fonts from the font list.</para>
	/// <para>
	/// The <b>IDWriteFontFallback</b> interface defines a fallback sequence to map character ranges to fonts, which is either created via
	/// <c>IDWriteFontFallbackBuilder</c> or retrieved from <c>IDWriteFactory2::GetSystemFontFallback</c>.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nn-dwrite_2-idwritefontfallback
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteFontFallback")]
	[ComImport, Guid("EFA008F9-F7A1-48BF-B05C-F224713CC0FF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFallback
	{
		/// <summary>Determines an appropriate font to use to render the beginning range of text.</summary>
		/// <param name="analysisSource">
		/// <para>Type: <b><c>IDWriteTextAnalysisSource</c>*</b></para>
		/// <para>The text source implementation holds the text and locale.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Starting position to analyze.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length of the text to analyze.</para>
		/// </param>
		/// <param name="baseFontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>*</b></para>
		/// <para>Default font collection to use.</para>
		/// </param>
		/// <param name="baseFamilyName">
		/// <para>Type: <b>const wchar_t*</b></para>
		/// <para>Family name of the base font. If you pass null, no matching will be done against the family.</para>
		/// </param>
		/// <param name="baseWeight">
		/// <para>Type: <b><c>DWRITE_FONT_WEIGHT</c></b></para>
		/// <para>The desired weight.</para>
		/// </param>
		/// <param name="baseStyle">
		/// <para>Type: <b><c>DWRITE_FONT_STYLE</c></b></para>
		/// <para>The desired style.</para>
		/// </param>
		/// <param name="baseStretch">
		/// <para>Type: <b><c>DWRITE_FONT_STRETCH</c></b></para>
		/// <para>The desired stretch.</para>
		/// </param>
		/// <param name="mappedLength">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>
		/// Length of text mapped to the mapped font. This will always be less than or equal to the text length and greater than zero (if
		/// the text length is non-zero) so the caller advances at least one character.
		/// </para>
		/// </param>
		/// <param name="mappedFont">
		/// <para>Type: <b><c>IDWriteFont</c>**</b></para>
		/// <para>
		/// The font that should be used to render the first <i>mappedLength</i> characters of the text. If it returns NULL, that means that
		/// no font can render the text, and <i>mappedLength</i> is the number of characters to skip (rendered with a missing glyph).
		/// </para>
		/// </param>
		/// <param name="scale">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>Scale factor to multiply the em size of the returned font by.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontfallback-mapcharacters HRESULT MapCharacters(
		// IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength, [in, optional] IDWriteFontCollection
		// *baseFontCollection, [in, optional] wchar_t const *baseFamilyName, DWRITE_FONT_WEIGHT baseWeight, DWRITE_FONT_STYLE baseStyle,
		// DWRITE_FONT_STRETCH baseStretch, [out] UINT32 *mappedLength, [out] IDWriteFont **mappedFont, [out] FLOAT *scale );
		[PreserveSig]
		HRESULT MapCharacters([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In, Optional] IDWriteFontCollection? baseFontCollection,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? baseFamilyName, DWRITE_FONT_WEIGHT baseWeight, DWRITE_FONT_STYLE baseStyle,
			DWRITE_FONT_STRETCH baseStretch, out uint mappedLength, out IDWriteFont? mappedFont, out float scale);
	}

	/// <summary>Allows you to create Unicode font fallback mappings and create a font fall back object from those mappings.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nn-dwrite_2-idwritefontfallbackbuilder
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteFontFallbackBuilder")]
	[ComImport, Guid("FD882D06-8ABA-4FB8-B849-8BE8B73E14DE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFallbackBuilder
	{
		/// <summary>Appends a single mapping to the list. Call this once for each additional mapping.</summary>
		/// <param name="ranges">
		/// <para>Type: <b><c>DWRITE_UNICODE_RANGE</c>*</b></para>
		/// <para>Unicode ranges that apply to this mapping.</para>
		/// </param>
		/// <param name="rangesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of Unicode ranges.</para>
		/// </param>
		/// <param name="targetFamilyNames">
		/// <para>Type: <b>const WCHAR**</b></para>
		/// <para>List of target family name strings.</para>
		/// </param>
		/// <param name="targetFamilyNamesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of target family names.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c></b></para>
		/// <para>Optional explicit font collection for this mapping.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>Locale of the context.</para>
		/// </param>
		/// <param name="baseFamilyName">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>Base family name to match against, if applicable.</para>
		/// </param>
		/// <param name="scale">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Scale factor to multiply the result target font by.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontfallbackbuilder-addmapping HRESULT
		// AddMapping( DWRITE_UNICODE_RANGE const *ranges, UINT32 rangesCount, [in] WCHAR const **targetFamilyNames, UINT32
		// targetFamilyNamesCount, [in, optional] IDWriteFontCollection *fontCollection, [in, optional] WCHAR const *localeName, [in,
		// optional] WCHAR const *baseFamilyName, FLOAT scale );
		void AddMapping([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_UNICODE_RANGE[] ranges, uint rangesCount,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 3)] string[] targetFamilyNames, uint targetFamilyNamesCount,
			[In, Optional] IDWriteFontCollection? fontCollection, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? localeName,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? baseFamilyName, float scale = 1.0f);

		/// <summary>
		/// Adds all the mappings from an existing font fallback object, which can be used to compose larger fallback definitions. A common
		/// scenario is to start with the system fallback from <c>IDWriteFactory2::GetSystemFontFallback</c> to cover the majority of
		/// Unicode characters, but then customize a few ranges with additional application-specific entries, either appending them first
		/// (to have priority over the system default) before calling <b>AddMappings</b>; or calling <b>AddMappings</b> first, and then
		/// appending custom ranges to fill in any custom gaps.
		/// </summary>
		/// <param name="fontFallback">
		/// <para>Type: <b><c>IDWriteFontFallback</c>*</b></para>
		/// <para>An existing font fallback object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontfallbackbuilder-addmappings HRESULT
		// AddMappings( IDWriteFontFallback *fontFallback );
		void AddMappings([In] IDWriteFontFallback fontFallback);

		/// <summary>Creates the finalized fallback object from the mappings added.</summary>
		/// <returns>Contains an address of a pointer to the created fallback list.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontfallbackbuilder-createfontfallback HRESULT
		// CreateFontFallback( [out] IDWriteFontFallback **fontFallback );
		IDWriteFontFallback CreateFontFallback();
	}

	/// <summary>Represents text rendering settings for glyph rasterization and filtering.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nn-dwrite_2-idwriterenderingparams2
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteRenderingParams2")]
	[ComImport, Guid("F9D711C3-9777-40AE-87E8-3E5AF9BF0948"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteRenderingParams2 : IDWriteRenderingParams, IDWriteRenderingParams1
	{
		/// <summary>Gets the gamma value used for gamma correction. Valid values must be greater than zero and cannot exceed 256.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the gamma value used for gamma correction. Valid values must be greater than zero and cannot exceed 256.</para>
		/// </returns>
		/// <remarks>The gamma value is used for gamma correction, which compensates for the non-linear luminosity response of most monitors.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getgamma FLOAT GetGamma();
		[PreserveSig]
		new float GetGamma();

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
		new float GetEnhancedContrast();

		/// <summary>Gets the ClearType level of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level of the rendering parameters object.</para>
		/// </returns>
		/// <remarks>
		/// The ClearType level represents the amount of ClearType – that is, the degree to which the red, green, and blue subpixels of each
		/// pixel are treated differently. Valid values range from zero (meaning no ClearType, which is equivalent to grayscale
		/// anti-aliasing) to one (meaning full ClearType)
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getcleartypelevel FLOAT GetClearTypeLevel();
		[PreserveSig]
		new float GetClearTypeLevel();

		/// <summary>Gets the pixel geometry of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>A value that indicates the type of pixel geometry used in the rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getpixelgeometry DWRITE_PIXEL_GEOMETRY GetPixelGeometry();
		[PreserveSig]
		new DWRITE_PIXEL_GEOMETRY GetPixelGeometry();

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
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getrenderingmode DWRITE_RENDERING_MODE GetRenderingMode();
		[PreserveSig]
		new DWRITE_RENDERING_MODE GetRenderingMode();

		/// <summary>Gets the amount of contrast enhancement to use for grayscale antialiasing.</summary>
		/// <returns>
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The contrast enhancement value. Valid values are greater than or equal to zero.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwriterenderingparams1-getgrayscaleenhancedcontrast
		// FLOAT GetGrayscaleEnhancedContrast();
		[PreserveSig]
		new float GetGrayscaleEnhancedContrast();

		/// <summary>Gets the grid fitting mode.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>Returns a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the grid fitting mode.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwriterenderingparams2-getgridfitmode
		// DWRITE_GRID_FIT_MODE GetGridFitMode();
		[PreserveSig]
		DWRITE_GRID_FIT_MODE GetGridFitMode();
	}

	/// <summary>Analyzes various text properties for complex script processing.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nn-dwrite_2-idwritetextanalyzer2
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteTextAnalyzer2")]
	[ComImport, Guid("553A9FF3-5693-4DF7-B52B-74806F7F2EB9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextAnalyzer2 : IDWriteTextAnalyzer, IDWriteTextAnalyzer1
	{
		/// <summary>
		/// Analyzes a text range for script boundaries, reading text attributes from the source and reporting the Unicode script ID to the
		/// sink callback SetScript.
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
		new void AnalyzeScript([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

		/// <summary>
		/// Analyzes a text range for script directionality, reading attributes from the source and reporting levels to the sink callback SetBidiLevel.
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
		new void AnalyzeBidi([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

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
		/// Although the function can handle multiple ranges of differing number substitutions, the text ranges should not arbitrarily split
		/// the middle of numbers. Otherwise, it will treat the numbers separately and will not translate any intervening punctuation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-analyzenumbersubstitution HRESULT
		// AnalyzeNumberSubstitution( IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength,
		// IDWriteTextAnalysisSink *analysisSink );
		new void AnalyzeNumberSubstitution([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

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
		/// unless the specified text span is considered a whole unit. Otherwise, the returned properties for the first and last characters
		/// will inappropriately allow breaks.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-analyzelinebreakpoints HRESULT
		// AnalyzeLineBreakpoints( IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength,
		// IDWriteTextAnalysisSink *analysisSink );
		new void AnalyzeLineBreakpoints([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

		/// <summary>
		/// Parses the input text string and maps it to the set of glyphs and associated glyph data according to the font and the writing
		/// system's rendering rules.
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
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> if the text is intended to be drawn vertically.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> for right-to-left text.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		/// <para>A pointer to a Script analysis result from an AnalyzeScript call.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// The locale to use when selecting glyphs. For example the same character may map to different glyphs for ja-jp versus zh-chs. If
		/// this is <c>NULL</c>, then the default mapping based on the script is used.
		/// </para>
		/// </param>
		/// <param name="numberSubstitution">
		/// <para>Type: <c>IDWriteNumberSubstitution*</c></para>
		/// <para>
		/// A pointer to an optional number substitution which selects the appropriate glyphs for digits and related numeric characters,
		/// depending on the results obtained from AnalyzeNumberSubstitution. Passing <c>NULL</c> indicates that no substitution is needed
		/// and that the digits should receive nominal glyphs.
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
		/// Note that the mapping from characters to glyphs is, in general, many-to-many. The recommended estimate for the per-glyph output
		/// buffers is (3 * textLength / 2 + 16). This is not guaranteed to be sufficient.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-getglyphs HRESULT GetGlyphs( WCHAR const
		// *textString, UINT32 textLength, IDWriteFontFace *fontFace, bool isSideways, bool isRightToLeft, DWRITE_SCRIPT_ANALYSIS const
		// *scriptAnalysis, WCHAR const *localeName, IDWriteNumberSubstitution *numberSubstitution, DWRITE_TYPOGRAPHIC_FEATURES const
		// **features, UINT32 const *featureRangeLengths, UINT32 featureRanges, UINT32 maxGlyphCount, UINT16 *clusterMap,
		// DWRITE_SHAPING_TEXT_PROPERTIES *textProps, UINT16 *glyphIndices, DWRITE_SHAPING_GLYPH_PROPERTIES *glyphProps, UINT32
		// *actualGlyphCount );
		new void GetGlyphs([MarshalAs(UnmanagedType.LPWStr)] string textString, uint textLength, [In] IDWriteFontFace fontFace,
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
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> if the text is intended to be drawn vertically.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> for right-to-left text.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		/// <para>A pointer to a Script analysis result from an AnalyzeScript call.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters containing the locale to use when selecting glyphs. For example, the same character may map to different
		/// glyphs for ja-jp versus zh-chs. If this is <c>NULL</c>, the default mapping based on the script is used.
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
		// *fontFace, FLOAT fontEmSize, bool isSideways, bool isRightToLeft, DWRITE_SCRIPT_ANALYSIS const *scriptAnalysis, WCHAR const
		// *localeName, DWRITE_TYPOGRAPHIC_FEATURES const **features, UINT32 const *featureRangeLengths, UINT32 featureRanges, FLOAT
		// *glyphAdvances, DWRITE_GLYPH_OFFSET *glyphOffsets );
		new void GetGlyphPlacements([MarshalAs(UnmanagedType.LPWStr)] string textString, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] clusterMap,
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
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> if the text is intended to be drawn vertically.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>bool</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> for right-to-left text.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		/// <para>A pointer to a Script analysis result from anAnalyzeScript call.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters containing the locale to use when selecting glyphs. For example, the same character may map to different
		/// glyphs for ja-jp versus zh-chs. If this is <c>NULL</c>, then the default mapping based on the script is used.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-getgdicompatibleglyphplacements HRESULT
		// GetGdiCompatibleGlyphPlacements( WCHAR const *textString, UINT16 const *clusterMap, DWRITE_SHAPING_TEXT_PROPERTIES
		// *textProps, UINT32 textLength, UINT16 const *glyphIndices, DWRITE_SHAPING_GLYPH_PROPERTIES const *glyphProps, UINT32 glyphCount,
		// IDWriteFontFace *fontFace, FLOAT fontEmSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, bool
		// isSideways, bool isRightToLeft, DWRITE_SCRIPT_ANALYSIS const *scriptAnalysis, WCHAR const *localeName,
		// DWRITE_TYPOGRAPHIC_FEATURES const **features, UINT32 const *featureRangeLengths, UINT32 featureRanges, FLOAT *glyphAdvances,
		// DWRITE_GLYPH_OFFSET *glyphOffsets );
		new void GetGdiCompatibleGlyphPlacements([MarshalAs(UnmanagedType.LPWStr)] string textString, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_TEXT_PROPERTIES[] textProps, uint textLength, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] glyphIndices,
			[In, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProps, uint glyphCount, [In] IDWriteFontFace fontFace, float fontEmSize,
			float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
			[MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			in DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [MarshalAs(UnmanagedType.LPWStr)] string localeName,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct)] DWRITE_TYPOGRAPHIC_FEATURES[]? features,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] uint[]? featureRangeLengths, uint featureRanges, [Out, MarshalAs(UnmanagedType.LPArray)] float[] glyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray)] DWRITE_GLYPH_OFFSET[] glyphOffsets);

		/// <summary>Applies spacing between characters, properly adjusting glyph clusters and diacritics.</summary>
		/// <param name="leadingSpacing">The spacing before each character, in reading order.</param>
		/// <param name="trailingSpacing">The spacing after each character, in reading order.</param>
		/// <param name="minimumAdvanceWidth">
		/// The minimum advance of each character, to prevent characters from becoming too thin or zero-width. This must be zero or greater.
		/// </param>
		/// <param name="textLength">The length of the clustermap and original text.</param>
		/// <param name="glyphCount">The number of glyphs.</param>
		/// <param name="clusterMap">Mapping from character ranges to glyph ranges.</param>
		/// <param name="glyphAdvances">The advance width of each glyph.</param>
		/// <param name="glyphOffsets">The offset of the origin of each glyph.</param>
		/// <param name="glyphProperties">Properties of each glyph, from GetGlyphs.</param>
		/// <param name="modifiedGlyphAdvances">The new advance width of each glyph.</param>
		/// <param name="modifiedGlyphOffsets">The new offset of the origin of each glyph.</param>
		/// <remarks>The input and output advances/offsets are allowed to alias the same array.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-applycharacterspacing HRESULT
		// ApplyCharacterSpacing( FLOAT leadingSpacing, FLOAT trailingSpacing, FLOAT minimumAdvanceWidth, UINT32 textLength, UINT32
		// glyphCount, [in] UINT16 const *clusterMap, [in] FLOAT const *glyphAdvances, [in] DWRITE_GLYPH_OFFSET const *glyphOffsets, [in]
		// DWRITE_SHAPING_GLYPH_PROPERTIES const *glyphProperties, [out] FLOAT *modifiedGlyphAdvances, [out] DWRITE_GLYPH_OFFSET
		// *modifiedGlyphOffsets );
		new void ApplyCharacterSpacing(float leadingSpacing, float trailingSpacing, float minimumAdvanceWidth, int textLength, int glyphCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[] clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] glyphAdvances,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[] glyphOffsets,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProperties,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] modifiedGlyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[] modifiedGlyphOffsets);

		/// <summary>Retrieves the given baseline from the font.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>The font face to read.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <b><c>DWRITE_BASELINE</c></b></para>
		/// <para>A <c>DWRITE_BASELINE</c>-typed value that specifies the baseline of interest.</para>
		/// </param>
		/// <param name="isVertical">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether the baseline is vertical or horizontal.</para>
		/// </param>
		/// <param name="isSimulationAllowed">
		/// <para>Type: <b>bool</b></para>
		/// <para>Simulate the baseline if it is missing in the font.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <b><c>DWRITE_SCRIPT_ANALYSIS</c></b></para>
		/// <para>Script analysis result from AnalyzeScript.</para>
		/// <para>
		/// <b>Note</b>  You can pass an empty script analysis structure, like this <c>DWRITE_SCRIPT_ANALYSIS scriptAnalysis = {};</c>, and
		/// this method will return the default baseline.
		/// </para>
		/// <para></para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>The language of the run.</para>
		/// </param>
		/// <param name="baselineCoordinate">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The baseline coordinate value in design units.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>bool*</b></para>
		/// <para>Whether the returned baseline exists in the font.</para>
		/// </param>
		/// <remarks>
		/// If the baseline does not exist in the font, it is not considered an error, but the function will return exists = false. You may
		/// then use heuristics to calculate the missing base, or, if the flag simulationAllowed is true, the function will compute a
		/// reasonable approximation for you.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-getbaseline HRESULT GetBaseline(
		// IDWriteFontFace *fontFace, DWRITE_BASELINE baseline, bool isVertical, bool isSimulationAllowed, DWRITE_SCRIPT_ANALYSIS
		// scriptAnalysis, [in, optional] WCHAR const *localeName, [out] INT32 *baselineCoordinate, [out] bool *exists );
		new void GetBaseline([In] IDWriteFontFace fontFace, DWRITE_BASELINE baseline, bool isVertical, bool isSimulationAllowed,
			DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? localeName, out int baselineCoordinate,
			out bool exists);

		/// <summary>
		/// Analyzes a text range for script orientation, reading text and attributes from the source and reporting results to the sink
		/// callback <c>SetGlyphOrientation</c>.
		/// </summary>
		/// <param name="analysisSource">
		/// <para>Type: <b><c>IDWriteTextAnalysisSource1</c>*</b></para>
		/// <para>Source object to analyze.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Starting position within the source object.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length to analyze.</para>
		/// </param>
		/// <param name="analysisSink">
		/// <para>Type: <b><c>IDWriteTextAnalysisSink1</c>*</b></para>
		/// <para>Length to analyze.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-analyzeverticalglyphorientation
		// HRESULT AnalyzeVerticalGlyphOrientation( IDWriteTextAnalysisSource1 *analysisSource, UINT32 textPosition, UINT32 textLength,
		// IDWriteTextAnalysisSink1 *analysisSink );
		new void AnalyzeVerticalGlyphOrientation([In] IDWriteTextAnalysisSource1 analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink1 analysisSink);

		/// <summary>Returns 2x3 transform matrix for the respective angle to draw the glyph run.</summary>
		/// <param name="glyphOrientationAngle">
		/// <para>Type: <b><c>DWRITE_GLYPH_ORIENTATION_ANGLE</c></b></para>
		/// <para>A <c>DWRITE_GLYPH_ORIENTATION_ANGLE</c>-typed value that specifies the angle that was reported into <c>IDWriteTextAnalysisSink1::SetGlyphOrientation</c>.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether the run's glyphs are sideways or not.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_MATRIX</c>*</b></para>
		/// <para>Returned transform.</para>
		/// </returns>
		/// <remarks>The translation component of the transform returned is zero.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-getglyphorientationtransform
		// HRESULT GetGlyphOrientationTransform( DWRITE_GLYPH_ORIENTATION_ANGLE glyphOrientationAngle, bool isSideways, [out] DWRITE_MATRIX
		// *transform );
		new DWRITE_MATRIX GetGlyphOrientationTransform(DWRITE_GLYPH_ORIENTATION_ANGLE glyphOrientationAngle, bool isSideways = false);

		/// <summary>Retrieves the properties for a given script.</summary>
		/// <param name="scriptAnalysis">
		/// <para>Type: <b><c>DWRITE_SCRIPT_ANALYSIS</c></b></para>
		/// <para>The script for a run of text returned from <c>IDWriteTextAnalyzer::AnalyzeScript</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_SCRIPT_PROPERTIES</c>*</b></para>
		/// <para>A pointer to a <c>DWRITE_SCRIPT_PROPERTIES</c> structure that describes info for the script.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-getscriptproperties HRESULT
		// GetScriptProperties( DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [out] DWRITE_SCRIPT_PROPERTIES *scriptProperties );
		new DWRITE_SCRIPT_PROPERTIES GetScriptProperties(DWRITE_SCRIPT_ANALYSIS scriptAnalysis);

		/// <summary>
		/// Determines the complexity of text, and whether you need to call <c>IDWriteTextAnalyzer::GetGlyphs</c> for full script shaping.
		/// </summary>
		/// <param name="textString">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>The text to check for complexity. This string may be UTF-16, but any supplementary characters will be considered complex.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length of the text to check.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>The font face to read.</para>
		/// </param>
		/// <param name="isTextSimple">
		/// <para>Type: <b>bool*</b></para>
		/// <para>
		/// If true, the text is simple, and the <i>glyphIndices</i> array will already have the nominal glyphs for you. Otherwise, you need
		/// to call <c>IDWriteTextAnalyzer::GetGlyphs</c> to properly shape complex scripts and OpenType features.
		/// </para>
		/// </param>
		/// <param name="textLengthRead">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>The length read of the text run with the same complexity, simple or complex. You may call again from that point onward.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>
		/// Optional glyph indices for the text. If the function returned that the text was simple, you already have the glyphs you need.
		/// Otherwise the glyph indices are not meaningful, and you need to call <c>IDWriteTextAnalyzer::GetGlyphs</c> for shaping instead.
		/// </para>
		/// </param>
		/// <remarks>
		/// Text is not simple if the characters are part of a script that has complex shaping requirements, require bidi analysis, combine
		/// with other characters, reside in the supplementary planes, or have glyphs that participate in standard OpenType features. The
		/// length returned will not split combining marks from their base characters.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-gettextcomplexity HRESULT
		// GetTextComplexity( [in] WCHAR const *textString, UINT32 textLength, IDWriteFontFace *fontFace, [out] bool *isTextSimple, [out]
		// UINT32 *textLengthRead, [out, optional] UINT16 *glyphIndices );
		new void GetTextComplexity([MarshalAs(UnmanagedType.LPWStr)] string textString, int textLength, [In] IDWriteFontFace fontFace, out bool isTextSimple,
			out uint textLengthRead, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[]? glyphIndices);

		/// <summary>Retrieves justification opportunity information for each of the glyphs given the text and shaping glyph properties.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>Font face that was used for shaping. This is mainly important for returning correct results of the kashida width.</para>
		/// <para>May be NULL.</para>
		/// </param>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Font em size used for the glyph run.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <b><c>DWRITE_SCRIPT_ANALYSIS</c></b></para>
		/// <para>Script of the text from the itemizer.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length of the text.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of glyphs.</para>
		/// </param>
		/// <param name="textString">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>Characters used to produce the glyphs.</para>
		/// </param>
		/// <param name="clusterMap">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Clustermap produced from shaping.</para>
		/// </param>
		/// <param name="glyphProperties">
		/// <para>Type: <b>const <c>DWRITE_SHAPING_GLYPH_PROPERTIES</c>*</b></para>
		/// <para>Glyph properties produced from shaping.</para>
		/// </param>
		/// <param name="justificationOpportunities">
		/// <para>Type: <b><c>DWRITE_JUSTIFICATION_OPPORTUNITY</c>*</b></para>
		/// <para>
		/// A pointer to a <c>DWRITE_JUSTIFICATION_OPPORTUNITY</c> structure that receives info for the allowed justification
		/// expansion/compression for each glyph.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>This function is called per-run, after shaping is done via the <c>IDWriteTextAnalyzer::GetGlyphs</c> method.</para>
		/// <para><b>Note</b>  this function only supports natural metrics ( <c>DWRITE_MEASURING_MODE_NATURAL</c>).</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-getjustificationopportunities
		// HRESULT GetJustificationOpportunities( IDWriteFontFace *fontFace, FLOAT fontEmSize, DWRITE_SCRIPT_ANALYSIS scriptAnalysis, UINT32
		// textLength, UINT32 glyphCount, [in] WCHAR const *textString, [in] UINT16 const *clusterMap, [in] DWRITE_SHAPING_GLYPH_PROPERTIES
		// const *glyphProperties, [out] DWRITE_JUSTIFICATION_OPPORTUNITY *justificationOpportunities );
		new void GetJustificationOpportunities([In, Optional] IDWriteFontFace? fontFace, float fontEmSize, DWRITE_SCRIPT_ANALYSIS scriptAnalysis,
			int textLength, int glyphCount, [MarshalAs(UnmanagedType.LPWStr)] string textString,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[] clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProperties,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_JUSTIFICATION_OPPORTUNITY[] justificationOpportunities);

		/// <summary>Justifies an array of glyph advances to fit the line width.</summary>
		/// <param name="lineWidth">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The line width.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The glyph count.</para>
		/// </param>
		/// <param name="justificationOpportunities">
		/// <para>Type: <b>const <c>DWRITE_JUSTIFICATION_OPPORTUNITY</c>*</b></para>
		/// <para>
		/// A pointer to a <c>DWRITE_JUSTIFICATION_OPPORTUNITY</c> structure that contains info for the allowed justification
		/// expansion/compression for each glyph. Get this info from <c>IDWriteTextAnalyzer1::GetJustificationOpportunities</c>.
		/// </para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>An array of glyph advances.</para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_OFFSET</c>*</b></para>
		/// <para>An array of glyph offsets.</para>
		/// </param>
		/// <param name="justifiedGlyphAdvances">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The returned array of justified glyph advances.</para>
		/// </param>
		/// <param name="justifiedGlyphOffsets">
		/// <para>Type: <b><c>DWRITE_GLYPH_OFFSET</c>*</b></para>
		/// <para>The returned array of justified glyph offsets.</para>
		/// </param>
		/// <remarks>
		/// You call <b>JustifyGlyphAdvances</b> after you call <c>IDWriteTextAnalyzer1::GetJustificationOpportunities</c> to collect all
		/// the opportunities, and <b>JustifyGlyphAdvances</b> spans across the entire line. The input and output arrays are allowed to
		/// alias each other, permitting in-place update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-justifyglyphadvances HRESULT
		// JustifyGlyphAdvances( FLOAT lineWidth, UINT32 glyphCount, [in] DWRITE_JUSTIFICATION_OPPORTUNITY const
		// *justificationOpportunities, [in] FLOAT const *glyphAdvances, [in] DWRITE_GLYPH_OFFSET const *glyphOffsets, [out] FLOAT
		// *justifiedGlyphAdvances, [out, optional] DWRITE_GLYPH_OFFSET *justifiedGlyphOffsets );
		new void JustifyGlyphAdvances(float lineWidth, int glyphCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_JUSTIFICATION_OPPORTUNITY[] justificationOpportunities,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] glyphAdvances,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_OFFSET[] glyphOffsets,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] justifiedGlyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_OFFSET[] justifiedGlyphOffsets);

		/// <summary>
		/// Fills in new glyphs for complex scripts where justification increased the advances of glyphs, such as Arabic with kashida.
		/// </summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>Font face used for shaping.</para>
		/// <para>May be NULL.</para>
		/// </param>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Font em size used for the glyph run.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <b><c>DWRITE_SCRIPT_ANALYSIS</c></b></para>
		/// <para>Script of the text from the itemizer.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length of the text.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of glyphs.</para>
		/// </param>
		/// <param name="maxGlyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Maximum number of output glyphs allocated by caller.</para>
		/// </param>
		/// <param name="clusterMap">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Clustermap produced from shaping.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Original glyphs produced from shaping.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>Original glyph advances produced from shaping.</para>
		/// </param>
		/// <param name="justifiedGlyphAdvances">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>Justified glyph advances from <c>IDWriteTextAnalyzer1::JustifyGlyphAdvances</c>.</para>
		/// </param>
		/// <param name="justifiedGlyphOffsets">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_OFFSET</c>*</b></para>
		/// <para>Justified glyph offsets from <c>IDWriteTextAnalyzer1::JustifyGlyphAdvances</c>.</para>
		/// </param>
		/// <param name="glyphProperties">
		/// <para>Type: <b>const <c>DWRITE_SHAPING_GLYPH_PROPERTIES</c>*</b></para>
		/// <para>Properties of each glyph, from <c>IDWriteTextAnalyzer::GetGlyphs</c>.</para>
		/// </param>
		/// <param name="actualGlyphCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>The new glyph count written to the modified arrays, or the needed glyph count if the size is not large enough.</para>
		/// </param>
		/// <param name="modifiedClusterMap">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>Updated clustermap.</para>
		/// </param>
		/// <param name="modifiedGlyphIndices">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>Updated glyphs with new glyphs inserted where needed.</para>
		/// </param>
		/// <param name="modifiedGlyphAdvances">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>Updated glyph advances.</para>
		/// </param>
		/// <param name="modifiedGlyphOffsets">
		/// <para>Type: <b><c>DWRITE_GLYPH_OFFSET</c>*</b></para>
		/// <para>Updated glyph offsets.</para>
		/// </param>
		/// <remarks>
		/// <para>You call <b>GetJustifiedGlyphs</b> after the line has been justified, and it is per-run.</para>
		/// <para>
		/// You should call <b>GetJustifiedGlyphs</b> if <c>IDWriteTextAnalyzer1::GetScriptProperties</c> returns a non-null
		/// <c>DWRITE_SCRIPT_PROPERTIES.justificationCharacter</c> for that script.
		/// </para>
		/// <para>
		/// Use <b>GetJustifiedGlyphs</b> mainly for cursive scripts like Arabic. If <i>maxGlyphCount</i> is not large enough,
		/// <b>GetJustifiedGlyphs</b> returns the error E_NOT_SUFFICIENT_BUFFER and fills the variable to which <i>actualGlyphCount</i>
		/// points with the needed glyph count.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-getjustifiedglyphs HRESULT
		// GetJustifiedGlyphs( IDWriteFontFace *fontFace, FLOAT fontEmSize, DWRITE_SCRIPT_ANALYSIS scriptAnalysis, UINT32 textLength, UINT32
		// glyphCount, UINT32 maxGlyphCount, [in, optional] UINT16 const *clusterMap, [in] UINT16 const *glyphIndices, [in] FLOAT const
		// *glyphAdvances, [in] FLOAT const *justifiedGlyphAdvances, [in] DWRITE_GLYPH_OFFSET const *justifiedGlyphOffsets, [in]
		// DWRITE_SHAPING_GLYPH_PROPERTIES const *glyphProperties, [out] UINT32 *actualGlyphCount, [out, optional] UINT16
		// *modifiedClusterMap, [out] UINT16 *modifiedGlyphIndices, [out] FLOAT *modifiedGlyphAdvances, [out] DWRITE_GLYPH_OFFSET
		// *modifiedGlyphOffsets );
		new void GetJustifiedGlyphs([In, Optional] IDWriteFontFace? fontFace, float fontEmSize, DWRITE_SCRIPT_ANALYSIS scriptAnalysis, int textLength,
			int glyphCount, int maxGlyphCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[]? clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] glyphIndices, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] glyphAdvances,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] justifiedGlyphAdvances,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[] justifiedGlyphOffsets,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProperties,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] actualGlyphCount,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[]? modifiedClusterMap,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] modifiedGlyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] float[] modifiedGlyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_GLYPH_OFFSET[] modifiedGlyphOffsets);

		/// <summary>
		/// <para>Returns 2x3 transform matrix for the respective angle to draw the glyph run.</para>
		/// <para>
		/// Extends <c>IDWriteTextAnalyzer1::GetGlyphOrientationTransform</c> to pass valid values for the baseline origin rather than zeroes.
		/// </para>
		/// </summary>
		/// <param name="glyphOrientationAngle">
		/// <para>Type: <b><c>DWRITE_GLYPH_ORIENTATION_ANGLE</c></b></para>
		/// <para>A <c>DWRITE_GLYPH_ORIENTATION_ANGLE</c>-typed value that specifies the angle that was reported into <c>IDWriteTextAnalysisSink1::SetGlyphOrientation</c>.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether the run's glyphs are sideways or not.</para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The X value of the baseline origin.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The Y value of the baseline origin.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_MATRIX</c>*</b></para>
		/// <para>Returned transform.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextanalyzer2-getglyphorientationtransform
		// HRESULT GetGlyphOrientationTransform( DWRITE_GLYPH_ORIENTATION_ANGLE glyphOrientationAngle, bool isSideways, FLOAT originX, FLOAT
		// originY, [out] DWRITE_MATRIX *transform );
		DWRITE_MATRIX GetGlyphOrientationTransform(DWRITE_GLYPH_ORIENTATION_ANGLE glyphOrientationAngle, bool isSideways, float originX, float originY);

		/// <summary>
		/// Returns a complete list of OpenType features available for a script or font. If a feature is partially supported, then this
		/// method indicates that it is supported.
		/// </summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>The font face to get features from.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <b><c>DWRITE_SCRIPT_ANALYSIS</c></b></para>
		/// <para>The script analysis for the script or font to check.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>The locale name to check.</para>
		/// </param>
		/// <param name="maxTagCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The maximum number of tags to return.</para>
		/// </param>
		/// <param name="actualTagCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>The actual number of tags returned.</para>
		/// </param>
		/// <param name="tags">
		/// <para>Type: <b><c>DWRITE_FONT_FEATURE_TAG</c>*</b></para>
		/// <para>An array of OpenType font feature tags.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextanalyzer2-gettypographicfeatures HRESULT
		// GetTypographicFeatures( IDWriteFontFace *fontFace, DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [in, optional] WCHAR const *localeName,
		// UINT32 maxTagCount, [out] UINT32 *actualTagCount, [out] DWRITE_FONT_FEATURE_TAG *tags );
		void GetTypographicFeatures([In] IDWriteFontFace fontFace, DWRITE_SCRIPT_ANALYSIS scriptAnalysis,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? localeName, uint maxTagCount, out uint actualTagCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DWRITE_FONT_FEATURE_TAG[] tags);

		/// <summary>Checks if a typographic feature is available for a glyph or a set of glyphs.</summary>
		/// <param name="fontFace">The font face to read glyph information from.</param>
		/// <param name="scriptAnalysis">The script analysis for the script or font to check.</param>
		/// <param name="localeName">The locale name to check.</param>
		/// <param name="featureTag">The font feature tag to check.</param>
		/// <param name="glyphCount">The number of glyphs to check.</param>
		/// <param name="glyphIndices">An array of glyph indices to check.</param>
		/// <param name="featureApplies">An array of integers that indicate whether or not the font feature applies to each glyph specified.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextanalyzer2-checktypographicfeature HRESULT
		// CheckTypographicFeature( IDWriteFontFace *fontFace, DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [in, optional] WCHAR const
		// *localeName, DWRITE_FONT_FEATURE_TAG featureTag, UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] UINT8 *featureApplies );
		void CheckTypographicFeature([In] IDWriteFontFace fontFace, DWRITE_SCRIPT_ANALYSIS scriptAnalysis,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? localeName, DWRITE_FONT_FEATURE_TAG featureTag, uint glyphCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] featureApplies);
	}

	/// <summary>
	/// Describes the font and paragraph properties used to format text, and it describes locale information. This interface has all the
	/// same methods as <c>IDWriteTextFormat</c> and adds the ability for you to apply an explicit orientation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nn-dwrite_2-idwritetextformat1
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteTextFormat1")]
	[ComImport, Guid("5F174B49-0D8B-4CFB-8BCA-F1CCE9D06C67"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextFormat1 : IDWriteTextFormat
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
		/// <c>Note</c> The alignment is dependent on reading direction, the above is for left-to-right reading direction. For right-to-left
		/// reading direction it would be the opposite.
		/// </para>
		/// <para>See DWRITE_TEXT_ALIGNMENT for more information.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settextalignment HRESULT SetTextAlignment(
		// DWRITE_TEXT_ALIGNMENT textAlignment );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setwordwrapping HRESULT SetWordWrapping(
		// DWRITE_WORD_WRAPPING wordWrapping );
		new void SetWordWrapping(DWRITE_WORD_WRAPPING wordWrapping);

		/// <summary>Sets the paragraph reading direction.</summary>
		/// <param name="readingDirection">
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// The text reading direction (for example, DWRITE_READING_DIRECTION_RIGHT_TO_LEFT for languages, such as Arabic, that read from
		/// right to left) for a paragraph.
		/// </para>
		/// </param>
		/// <remarks>
		/// The reading direction and flow direction must always be set 90 degrees orthogonal to each other, or else you will get the error
		/// DWRITE_E_FLOWDIRECTIONCONFLICTS when you use layout functions like Draw or GetMetrics. So if you set a vertical reading
		/// direction (for example, to DWRITE_READING_DIRECTION_TOP_TO_BOTTOM), then you must also use SetFlowDirection to set the flow
		/// direction appropriately (for example, to DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setreadingdirection HRESULT
		// SetReadingDirection( DWRITE_READING_DIRECTION readingDirection );
		new void SetReadingDirection(DWRITE_READING_DIRECTION readingDirection);

		/// <summary>Sets the paragraph flow direction.</summary>
		/// <param name="flowDirection">
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>The paragraph flow direction; see DWRITE_FLOW_DIRECTION for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setflowdirection HRESULT SetFlowDirection(
		// DWRITE_FLOW_DIRECTION flowDirection );
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
		new void GetTrimming(out DWRITE_TRIMMING trimmingOptions, out IDWriteInlineObject? trimmingSign);

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
		/// The size of the fontFamilyName character array, in character count, including the terminated <c>NULL</c> character. To find the
		/// size of fontFamilyName, use GetFontFamilyNameLength.
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
		/// The size of the character array, in character count, including the terminated <c>NULL</c> character. Use GetLocaleNameLength to
		/// get the size of the locale name character array.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalename HRESULT GetLocaleName( WCHAR
		// *localeName, UINT32 nameSize );
		new void GetLocaleName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize);

		/// <summary>Sets the orientation of a text format.</summary>
		/// <param name="glyphOrientation">
		/// <para>Type: <b><c>DWRITE_VERTICAL_GLYPH_ORIENTATION</c></b></para>
		/// <para>The orientation to apply to the text format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setverticalglyphorientation HRESULT
		// SetVerticalGlyphOrientation( DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation );
		void SetVerticalGlyphOrientation(DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation);

		/// <summary>Get the preferred orientation of glyphs when using a vertical reading direction.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_VERTICAL_GLYPH_ORIENTATION</c></b></para>
		/// <para>The preferred orientation of glyphs when using a vertical reading direction.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getverticalglyphorientation
		// DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();
		[PreserveSig]
		DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();

		/// <summary>Sets the wrapping mode of the last line.</summary>
		/// <param name="isLastLineWrappingEnabled">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>If set to FALSE, the last line is not wrapped. If set to TRUE, the last line is wrapped.</para>
		/// <para>The last line is wrapped by default.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setlastlinewrapping HRESULT
		// SetLastLineWrapping( BOOL isLastLineWrappingEnabled );
		void SetLastLineWrapping(bool isLastLineWrappingEnabled);

		/// <summary>Gets the wrapping mode of the last line.</summary>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns FALSE if the last line is not wrapped; TRUE if the last line is wrapped.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getlastlinewrapping BOOL GetLastLineWrapping();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetLastLineWrapping();

		/// <summary>
		/// <para>Sets the optical margin alignment for the text format.</para>
		/// <para>
		/// By default, glyphs are aligned to the margin by the default origin and side-bearings of the glyph. If you specify
		/// <b>DWRITE_OPTICAL_ALIGNMENT_USING_SIDE_BEARINGS</b>, then the alignment Suses the side bearings to offset the glyph from the
		/// aligned edge to ensure the ink of the glyphs are aligned.
		/// </para>
		/// </summary>
		/// <param name="opticalAlignment">The optical alignment to set.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setopticalalignment HRESULT
		// SetOpticalAlignment( DWRITE_OPTICAL_ALIGNMENT opticalAlignment );
		void SetOpticalAlignment(DWRITE_OPTICAL_ALIGNMENT opticalAlignment);

		/// <summary>Gets the optical margin alignment for the text format.</summary>
		/// <returns>The optical alignment.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getopticalalignment
		// DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();
		[PreserveSig]
		DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();

		/// <summary>Applies the custom font fallback onto the layout. If none is set, it uses the default system fallback list.</summary>
		/// <param name="fontFallback">
		/// <para>Type: <b><c>IDWriteFontFallback</c>*</b></para>
		/// <para>The font fallback to apply to the layout.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setfontfallback HRESULT
		// SetFontFallback( IDWriteFontFallback *fontFallback );
		void SetFontFallback([In] IDWriteFontFallback fontFallback);

		/// <summary>Gets the current fallback. If none was ever set since creating the layout, it will be nullptr.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallback</c>**</b></para>
		/// <para>Contains an address of a pointer to the current font fallback object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getfontfallback HRESULT
		// GetFontFallback( [out] IDWriteFontFallback **fontFallback );
		IDWriteFontFallback GetFontFallback();
	}

	/// <summary>The <b>IDWriteTextLayout2</b> interface inherits from the IDWriteTextLayout1 interface.</summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_2/nn-dwrite_2-idwritetextlayout2
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteTextLayout2")]
	[ComImport, Guid("1093C18F-8D5E-43F0-B064-0917311B525E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextLayout2 : IDWriteTextFormat, IDWriteTextLayout, IDWriteTextLayout1
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
		/// <c>Note</c> The alignment is dependent on reading direction, the above is for left-to-right reading direction. For right-to-left
		/// reading direction it would be the opposite.
		/// </para>
		/// <para>See DWRITE_TEXT_ALIGNMENT for more information.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settextalignment HRESULT SetTextAlignment(
		// DWRITE_TEXT_ALIGNMENT textAlignment );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setwordwrapping HRESULT SetWordWrapping(
		// DWRITE_WORD_WRAPPING wordWrapping );
		new void SetWordWrapping(DWRITE_WORD_WRAPPING wordWrapping);

		/// <summary>Sets the paragraph reading direction.</summary>
		/// <param name="readingDirection">
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// The text reading direction (for example, DWRITE_READING_DIRECTION_RIGHT_TO_LEFT for languages, such as Arabic, that read from
		/// right to left) for a paragraph.
		/// </para>
		/// </param>
		/// <remarks>
		/// The reading direction and flow direction must always be set 90 degrees orthogonal to each other, or else you will get the error
		/// DWRITE_E_FLOWDIRECTIONCONFLICTS when you use layout functions like Draw or GetMetrics. So if you set a vertical reading
		/// direction (for example, to DWRITE_READING_DIRECTION_TOP_TO_BOTTOM), then you must also use SetFlowDirection to set the flow
		/// direction appropriately (for example, to DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setreadingdirection HRESULT
		// SetReadingDirection( DWRITE_READING_DIRECTION readingDirection );
		new void SetReadingDirection(DWRITE_READING_DIRECTION readingDirection);

		/// <summary>Sets the paragraph flow direction.</summary>
		/// <param name="flowDirection">
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>The paragraph flow direction; see DWRITE_FLOW_DIRECTION for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setflowdirection HRESULT SetFlowDirection(
		// DWRITE_FLOW_DIRECTION flowDirection );
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
		/// The size of the fontFamilyName character array, in character count, including the terminated <c>NULL</c> character. To find the
		/// size of fontFamilyName, use GetFontFamilyNameLength.
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
		/// The size of the character array, in character count, including the terminated <c>NULL</c> character. Use GetLocaleNameLength to
		/// get the size of the locale name character array.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalename HRESULT GetLocaleName( WCHAR
		// *localeName, UINT32 nameSize );
		new void GetLocaleName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize);

		/// <summary>Sets the layout maximum width.</summary>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the maximum width of the layout box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxwidth HRESULT SetMaxWidth( FLOAT
		// maxWidth );
		new void SetMaxWidth(float maxWidth);

		/// <summary>Sets the layout maximum height.</summary>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the maximum height of the layout box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxheight HRESULT SetMaxHeight( FLOAT
		// maxHeight );
		new void SetMaxHeight(float maxHeight);

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
		new void SetFontCollection([In] IDWriteFontCollection fontCollection, DWRITE_TEXT_RANGE textRange);

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
		new void SetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, DWRITE_TEXT_RANGE textRange);

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
		new void SetFontWeight(DWRITE_FONT_WEIGHT fontWeight, DWRITE_TEXT_RANGE textRange);

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
		/// The font style can be set to Normal, Italic or Oblique. The following illustration shows three styles for the Palatino font. For
		/// more information, see DWRITE_FONT_STYLE.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code illustrates how to set the font style to italic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstyle HRESULT SetFontStyle(
		// DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange );
		new void SetFontStyle(DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange);

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
		new void SetFontStretch(DWRITE_FONT_STRETCH fontStretch, DWRITE_TEXT_RANGE textRange);

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
		new void SetFontSize(float fontSize, DWRITE_TEXT_RANGE textRange);

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
		new void SetUnderline([MarshalAs(UnmanagedType.Bool)] bool hasUnderline, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets strikethrough for text within a specified text range.</summary>
		/// <param name="hasStrikethrough">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether strikethrough takes place in the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setstrikethrough HRESULT SetStrikethrough(
		// BOOL hasStrikethrough, DWRITE_TEXT_RANGE textRange );
		new void SetStrikethrough([MarshalAs(UnmanagedType.Bool)] bool hasStrikethrough, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the application-defined drawing effect.</summary>
		/// <param name="drawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Application-defined drawing effects that apply to the range. This data object will be passed back to the application's drawing
		/// callbacks for final rendering.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setdrawingeffect HRESULT SetDrawingEffect(
		// IUnknown *drawingEffect, DWRITE_TEXT_RANGE textRange );
		new void SetDrawingEffect([MarshalAs(UnmanagedType.Interface)] object drawingEffect, DWRITE_TEXT_RANGE textRange);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setinlineobject HRESULT SetInlineObject(
		// IDWriteInlineObject *inlineObject, DWRITE_TEXT_RANGE textRange );
		new void SetInlineObject([In] IDWriteInlineObject inlineObject, DWRITE_TEXT_RANGE textRange);

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
		new void SetTypography([In] IDWriteTypography typography, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the locale name for text within a specified text range.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>A null-terminated locale name string.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setlocalename HRESULT SetLocaleName( WCHAR
		// const *localeName, DWRITE_TEXT_RANGE textRange );
		new void SetLocaleName([MarshalAs(UnmanagedType.LPWStr)] string localeName, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the layout maximum width.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the layout maximum width.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxwidth FLOAT GetMaxWidth();
		[PreserveSig]
		new float GetMaxWidth();

		/// <summary>Gets the layout maximum height.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The layout maximum height.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxheight FLOAT GetMaxHeight();
		[PreserveSig]
		new float GetMaxHeight();

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
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the underline.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontcollection HRESULT
		// GetFontCollection( UINT32 currentPosition, IDWriteFontCollection **fontCollection, DWRITE_TEXT_RANGE *textRange );
		new void GetFontCollection(uint currentPosition, out IDWriteFontCollection fontCollection, out DWRITE_TEXT_RANGE textRange);

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
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font family.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilynamelength HRESULT
		// GetFontFamilyNameLength( UINT32 currentPosition, UINT32 *nameLength, DWRITE_TEXT_RANGE *textRange );
		new void GetFontFamilyNameLength(uint currentPosition, out uint nameLength, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Copies the font family name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to examine.</para>
		/// </param>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains an array of characters that receives the current font family name. You must allocate storage
		/// for this parameter.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font family name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilyname HRESULT
		// GetFontFamilyName( UINT32 currentPosition, WCHAR *fontFamilyName, UINT32 nameSize, DWRITE_TEXT_RANGE *textRange );
		new void GetFontFamilyName(uint currentPosition, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font weight of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT*</c></para>
		/// <para>When this method returns, contains a value which indicates the type of font weight being applied at the specified position.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font weight.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontweight HRESULT GetFontWeight( UINT32
		// currentPosition, DWRITE_FONT_WEIGHT *fontWeight, DWRITE_TEXT_RANGE *textRange );
		new void GetFontWeight(uint currentPosition, out DWRITE_FONT_WEIGHT fontWeight, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font style (also known as slope) of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font style (also known as slope or incline) being applied
		/// at the specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font style.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstyle HRESULT GetFontStyle( UINT32
		// currentPosition, DWRITE_FONT_STYLE *fontStyle, DWRITE_TEXT_RANGE *textRange );
		new void GetFontStyle(uint currentPosition, out DWRITE_FONT_STYLE fontStyle, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font stretch of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font stretch (also known as width) being applied at the
		/// specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font stretch.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstretch HRESULT GetFontStretch(
		// UINT32 currentPosition, DWRITE_FONT_STRETCH *fontStretch, DWRITE_TEXT_RANGE *textRange );
		new void GetFontStretch(uint currentPosition, out DWRITE_FONT_STRETCH fontStretch, out DWRITE_TEXT_RANGE textRange);

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
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font size.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontsize HRESULT GetFontSize( UINT32
		// currentPosition, FLOAT *fontSize, DWRITE_TEXT_RANGE *textRange );
		new void GetFontSize(uint currentPosition, out float fontSize, out DWRITE_TEXT_RANGE textRange);

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
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the underline.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getunderline HRESULT GetUnderline( UINT32
		// currentPosition, BOOL *hasUnderline, DWRITE_TEXT_RANGE *textRange );
		new void GetUnderline(uint currentPosition, [MarshalAs(UnmanagedType.Bool)] out bool hasUnderline, out DWRITE_TEXT_RANGE textRange);

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
		/// Contains the range of text that has the same formatting as the text at the position specified by currentPosition. This means the
		/// run has the exact formatting as the position specified, including but not limited to strikethrough.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getstrikethrough HRESULT GetStrikethrough(
		// UINT32 currentPosition, BOOL *hasStrikethrough, DWRITE_TEXT_RANGE *textRange );
		new void GetStrikethrough(uint currentPosition, [MarshalAs(UnmanagedType.Bool)] out bool hasStrikethrough, out DWRITE_TEXT_RANGE textRange);

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
		/// Contains the range of text that has the same formatting as the text at the position specified by currentPosition. This means the
		/// run has the exact formatting as the position specified, including but not limited to the drawing effect.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getdrawingeffect HRESULT GetDrawingEffect(
		// UINT32 currentPosition, IUnknown **drawingEffect, DWRITE_TEXT_RANGE *textRange );
		new void GetDrawingEffect(uint currentPosition, [MarshalAs(UnmanagedType.Interface)] out object drawingEffect, out DWRITE_TEXT_RANGE textRange);

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
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the inline object.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getinlineobject HRESULT GetInlineObject(
		// UINT32 currentPosition, IDWriteInlineObject **inlineObject, DWRITE_TEXT_RANGE *textRange );
		new void GetInlineObject(uint currentPosition, out IDWriteInlineObject inlineObject, out DWRITE_TEXT_RANGE textRange);

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
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the typography.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-gettypography HRESULT GetTypography( UINT32
		// currentPosition, IDWriteTypography **typography, DWRITE_TEXT_RANGE *textRange );
		new void GetTypography(uint currentPosition, out IDWriteTypography typography, out DWRITE_TEXT_RANGE textRange);

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
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the locale name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalenamelength HRESULT
		// GetLocaleNameLength( UINT32 currentPosition, UINT32 *nameLength, DWRITE_TEXT_RANGE *textRange );
		new void GetLocaleNameLength(uint currentPosition, out uint nameLength, out DWRITE_TEXT_RANGE textRange);

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
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the locale name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalename HRESULT GetLocaleName( UINT32
		// currentPosition, WCHAR *localeName, UINT32 nameSize, DWRITE_TEXT_RANGE *textRange );
		new void GetLocaleName(uint currentPosition, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize, out DWRITE_TEXT_RANGE textRange);

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
		/// DWRITE_READING_DIRECTION_TOP_TO_BOTTOM (or bottom to top), then you must pass an interface that implements IDWriteTextRenderer1.
		/// Otherwise you get the error DWRITE_E_TEXTRENDERERINCOMPATIBLE because the original IDWriteTextRenderer interface only supported
		/// horizontal text.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-draw HRESULT Draw( void
		// *clientDrawingContext, IDWriteTextRenderer *renderer, FLOAT originX, FLOAT originY );
		new void Draw([In, Optional] IntPtr clientDrawingContext, [In] IDWriteTextRenderer renderer, float originX, float originY);

		/// <summary>Retrieves the information about each individual text line of the text string.</summary>
		/// <param name="lineMetrics">
		/// <para>Type: <c>DWRITE_LINE_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to an array of structures containing various calculated length values of individual
		/// text lines.
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
		new void GetLineMetrics([Out, Optional, MarshalAs(UnmanagedType.LPArray)] DWRITE_LINE_METRICS[]? lineMetrics, uint maxLineCount, out uint actualLineCount);

		/// <summary>Retrieves overall metrics for the formatted string.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_METRICS*</c></para>
		/// <para>When this method returns, contains the measured distances of text and associated content after being formatted.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmetrics HRESULT GetMetrics(
		// DWRITE_TEXT_METRICS *textMetrics );
		new DWRITE_TEXT_METRICS GetMetrics();

		/// <summary>
		/// Returns the overhangs (in DIPs) of the layout and all objects contained in it, including text glyphs and inline objects.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_OVERHANG_METRICS*</c></para>
		/// <para>Overshoots of visible extents (in DIPs) outside the layout.</para>
		/// </returns>
		/// <remarks>
		/// Underlines and strikethroughs do not contribute to the black box determination, since these are actually drawn by the renderer,
		/// which is allowed to draw them in any variety of styles.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getoverhangmetrics HRESULT
		// GetOverhangMetrics( DWRITE_OVERHANG_METRICS *overhangs );
		new DWRITE_OVERHANG_METRICS GetOverhangMetrics();

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
		new void GetClusterMetrics([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_CLUSTER_METRICS[]? clusterMetrics, uint maxClusterCount, out uint actualClusterCount);

		/// <summary>
		/// Determines the minimum possible width the layout can be set to without emergency breaking between the characters of whole words occurring.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>Minimum width.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-determineminwidth HRESULT
		// DetermineMinWidth( FLOAT *minWidth );
		new float DetermineMinWidth();

		/// <summary>
		/// The application calls this function passing in a specific pixel location relative to the top-left location of the layout box and
		/// obtains the information about the correspondent hit-test metrics of the text string where the hit-test has occurred. When the
		/// specified pixel location is outside the text string, the function sets the output value *isInside to <c>FALSE</c>.
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
		/// An output flag that indicates whether the hit-test location is at the leading or the trailing side of the character. When the
		/// output *isInside value is set to <c>FALSE</c>, this value is set according to the output hitTestMetrics-&gt;textPosition value
		/// to represent the edge closest to the hit-test location.
		/// </para>
		/// </param>
		/// <param name="isInside">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// An output flag that indicates whether the hit-test location is inside the text string. When <c>FALSE</c>, the position nearest
		/// the text's edge is returned.
		/// </para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>
		/// The output geometry fully enclosing the hit-test location. When the output *isInside value is set to <c>FALSE</c>, this
		/// structure represents the geometry enclosing the edge closest to the hit-test location.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittestpoint HRESULT HitTestPoint( FLOAT
		// pointX, FLOAT pointY, BOOL *isTrailingHit, BOOL *isInside, DWRITE_HIT_TEST_METRICS *hitTestMetrics );
		new void HitTestPoint(float pointX, float pointY, [MarshalAs(UnmanagedType.Bool)] out bool isTrailingHit,
			[MarshalAs(UnmanagedType.Bool)] out bool isInside, out DWRITE_HIT_TEST_METRICS hitTestMetrics);

		/// <summary>
		/// The application calls this function to get the pixel location relative to the top-left of the layout box given the text position
		/// and the logical side of the position. This function is normally used as part of caret positioning of text where the caret is
		/// drawn at the location corresponding to the current text editing position. It may also be used as a way to programmatically
		/// obtain the geometry of a particular text position in UI automation.
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
		new void HitTestTextPosition(uint textPosition, [MarshalAs(UnmanagedType.Bool)] bool isTrailingHit, out float pointX, out float pointY,
			out DWRITE_HIT_TEST_METRICS hitTestMetrics);

		/// <summary>
		/// <para>
		/// The application calls this function to get a set of hit-test metrics corresponding to a range of text positions. One of the main
		/// usages is to implement highlight selection of the text string.
		/// </para>
		/// <para>
		/// The function returns E_NOT_SUFFICIENT_BUFFER, which is equivalent to HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), when the
		/// buffer size of hitTestMetrics is too small to hold all the regions calculated by the function. In this situation, the function
		/// sets the output value *actualHitTestMetricsCount to the number of geometries calculated.
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
		/// When this method returns, contains a pointer to a buffer of the output geometry fully enclosing the specified position range.
		/// The buffer must be at least as large as maxHitTestMetricsCount.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextrange HRESULT HitTestTextRange(
		// UINT32 textPosition, UINT32 textLength, FLOAT originX, FLOAT originY, DWRITE_HIT_TEST_METRICS
		// *hitTestMetrics, UINT32 maxHitTestMetricsCount, UINT32 *actualHitTestMetricsCount );
		new void HitTestTextRange(uint textPosition, uint textLength, float originX, float originY,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_HIT_TEST_METRICS[]? hitTestMetrics,
			uint maxHitTestMetricsCount, out uint actualHitTestMetricsCount);

		/// <summary>Enables or disables pair-kerning on a given text range.</summary>
		/// <param name="isPairKerningEnabled">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>The flag that indicates whether text is pair-kerned.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c></b></para>
		/// <para>The text range to which the change applies.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-setpairkerning HRESULT
		// SetPairKerning( BOOL isPairKerningEnabled, DWRITE_TEXT_RANGE textRange );
		new void SetPairKerning(bool isPairKerningEnabled, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets whether or not pair-kerning is enabled at given position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="isPairKerningEnabled">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>The flag that indicates whether text is pair-kerned.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c>*</b></para>
		/// <para>The position range of the current format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-getpairkerning HRESULT
		// GetPairKerning( UINT32 currentPosition, [out] BOOL *isPairKerningEnabled, [out, optional] DWRITE_TEXT_RANGE *textRange );
		new void GetPairKerning(uint currentPosition, out bool isPairKerningEnabled, [Out, Optional] StructPointer<DWRITE_TEXT_RANGE> textRange);

		/// <summary>Sets the spacing between characters.</summary>
		/// <param name="leadingSpacing">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The spacing before each character, in reading order.</para>
		/// </param>
		/// <param name="trailingSpacing">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The spacing after each character, in reading order.</para>
		/// </param>
		/// <param name="minimumAdvanceWidth">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The minimum advance of each character, to prevent characters from becoming too thin or zero-width. This must be zero or greater.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c></b></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-setcharacterspacing HRESULT
		// SetCharacterSpacing( FLOAT leadingSpacing, FLOAT trailingSpacing, FLOAT minimumAdvanceWidth, DWRITE_TEXT_RANGE textRange );
		new void SetCharacterSpacing(float leadingSpacing, float trailingSpacing, float minimumAdvanceWidth, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the spacing between characters.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="leadingSpacing">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The spacing before each character, in reading order.</para>
		/// </param>
		/// <param name="trailingSpacing">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The spacing after each character, in reading order.</para>
		/// </param>
		/// <param name="minimumAdvanceWidth">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>
		/// The minimum advance of each character, to prevent characters from becoming too thin or zero-width. This must be zero or greater.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c>*</b></para>
		/// <para>The position range of the current format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-getcharacterspacing HRESULT
		// GetCharacterSpacing( UINT32 currentPosition, [out] FLOAT *leadingSpacing, [out] FLOAT *trailingSpacing, [out] FLOAT
		// *minimumAdvanceWidth, [out, optional] DWRITE_TEXT_RANGE *textRange );
		new void GetCharacterSpacing(uint currentPosition, out float leadingSpacing, out float trailingSpacing, out float minimumAdvanceWidth,
			[Out, Optional] StructPointer<DWRITE_TEXT_RANGE> textRange);

		/// <summary><c>textMetrics</c></summary>
		/// <param name="textMetrics"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_2/nf-dwrite_2-idwritetextlayout2-getmetrics HRESULT
		// GetMetrics( DWRITE_TEXT_METRICS1 *textMetrics );
		void GetMetrics(out DWRITE_TEXT_METRICS1 textMetrics);

		/// <summary>Set the preferred orientation of glyphs when using a vertical reading direction.</summary>
		/// <param name="glyphOrientation">Preferred glyph orientation.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setverticalglyphorientation HRESULT
		// SetVerticalGlyphOrientation( DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation );
		void SetVerticalGlyphOrientation(DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation);

		/// <summary>Get the preferred orientation of glyphs when using a vertical reading direction.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getverticalglyphorientation
		// DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();
		[PreserveSig]
		DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();

		/// <summary>Set whether or not the last word on the last line is wrapped.</summary>
		/// <param name="isLastLineWrappingEnabled">Line wrapping option.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setlastlinewrapping HRESULT
		// SetLastLineWrapping( BOOL isLastLineWrappingEnabled );
		void SetLastLineWrapping(bool isLastLineWrappingEnabled);

		/// <summary>Get whether or not the last word on the last line is wrapped.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getlastlinewrapping BOOL GetLastLineWrapping();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetLastLineWrapping();

		/// <summary>
		/// Set how the glyphs align to the edges the margin. Default behavior is to align glyphs using their default glyphs metrics, which
		/// include side bearings.
		/// </summary>
		/// <param name="opticalAlignment">Optical alignment option.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setopticalalignment HRESULT
		// SetOpticalAlignment( DWRITE_OPTICAL_ALIGNMENT opticalAlignment );
		void SetOpticalAlignment(DWRITE_OPTICAL_ALIGNMENT opticalAlignment);

		/// <summary>Get how the glyphs align to the edges the margin.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getopticalalignment
		// DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();
		[PreserveSig]
		DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();

		/// <summary>Apply a custom font fallback onto layout. If none is specified, the layout uses the system fallback list.</summary>
		/// <param name="fontFallback">Custom font fallback created from <c>IDWriteFontFallbackBuilder::CreateFontFallback</c> or <c>IDWriteFactory2::GetSystemFontFallback</c>.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setfontfallback HRESULT
		// SetFontFallback( IDWriteFontFallback *fontFallback );
		void SetFontFallback([In] IDWriteFontFallback fontFallback);

		/// <summary>Get the current font fallback object.</summary>
		/// <returns>The current font fallback object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getfontfallback HRESULT
		// GetFontFallback( [out] IDWriteFontFallback **fontFallback );
		IDWriteFontFallback GetFontFallback();
	}

	/// <summary>
	/// Represents a set of application-defined callbacks that perform rendering of text, inline objects, and decorations such as underlines.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nn-dwrite_2-idwritetextrenderer1
	[PInvokeData("dwrite_2.h", MSDNShortId = "NN:dwrite_2.IDWriteTextRenderer1")]
	[ComImport, Guid("D3E0E934-22A0-427E-AAE4-7D9574B59DB1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextRenderer1 : IDWritePixelSnapping, IDWriteTextRenderer
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
		/// Because a DIP (device-independent pixel) is 1/96 inch, the pixelsPerDip value is the number of logical pixels per inch divided
		/// by 96.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritepixelsnapping-getpixelsperdip HRESULT GetPixelsPerDip(
		// void *clientDrawingContext, FLOAT *pixelsPerDip );
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
		/// Application-defined drawing effects for the glyphs to render. Usually this argument represents effects such as the foreground
		/// brush filling the interior of text.
		/// </para>
		/// </param>
		/// <remarks>
		/// The IDWriteTextLayout::Draw function calls this callback function with all the information about glyphs to render. The
		/// application implements this callback by mostly delegating the call to the underlying platform's graphics API such as Direct2D to
		/// draw glyphs on the drawing context. An application that uses GDI can implement this callback in terms of the
		/// IDWriteBitmapRenderTarget::DrawGlyphRun method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawglyphrun HRESULT DrawGlyphRun( void
		// *clientDrawingContext, FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_MEASURING_MODE measuringMode, DWRITE_GLYPH_RUN const
		// *glyphRun, DWRITE_GLYPH_RUN_DESCRIPTION const *glyphRunDescription, IUnknown *clientDrawingEffect );
		new void DrawGlyphRun([In, Optional] IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY, DWRITE_MEASURING_MODE measuringMode,
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
		/// A single underline can be broken into multiple calls, depending on how the formatting changes attributes. If font sizes/styles
		/// change within an underline, the thickness and offset will be averaged weighted according to characters. To get an appropriate
		/// starting pixel position, add underline::offset to the baseline. Otherwise there will be no spacing between the text. The x
		/// coordinate will always be passed as the left side, regardless of text directionality. This simplifies drawing and reduces the
		/// problem of round-off that could potentially cause gaps or a double stamped alpha blend. To avoid alpha overlap, round the end
		/// points to the nearest device pixel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawunderline HRESULT DrawUnderline( void
		// *clientDrawingContext, FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_UNDERLINE const *underline, IUnknown
		// *clientDrawingEffect );
		new void DrawUnderline([In, Optional] IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY,
			in DWRITE_UNDERLINE underline, [In, Optional][MarshalAs(UnmanagedType.Interface)] object clientDrawingEffect);

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
		/// Application-defined effect to apply to the strikethrough. Usually this argument represents effects such as the foreground brush
		/// filling the interior of a line.
		/// </para>
		/// </param>
		/// <remarks>
		/// A single strikethrough can be broken into multiple calls, depending on how the formatting changes attributes. Strikethrough is
		/// not averaged across font sizes/styles changes. To get an appropriate starting pixel position, add strikethrough::offset to the
		/// baseline. Like underlines, the x coordinate will always be passed as the left side, regardless of text directionality.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawstrikethrough HRESULT
		// DrawStrikethrough( void *clientDrawingContext, FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_STRIKETHROUGH const
		// *strikethrough, IUnknown *clientDrawingEffect );
		new void DrawStrikethrough([In, Optional] IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY,
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
		/// A Boolean flag that indicates whether the object is in a right-to-left context, hinting that the drawing may want to mirror the
		/// normal image.
		/// </para>
		/// </param>
		/// <param name="clientDrawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Application-defined drawing effects for the glyphs to render. Usually this argument represents effects such as the foreground
		/// brush filling the interior of a line.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextrenderer-drawinlineobject HRESULT
		// DrawInlineObject( void *clientDrawingContext, FLOAT originX, FLOAT originY, IDWriteInlineObject *inlineObject, BOOL isSideways,
		// BOOL isRightToLeft, IUnknown *clientDrawingEffect );
		new void DrawInlineObject([In, Optional] IntPtr clientDrawingContext, float originX, float originY, [In] IDWriteInlineObject inlineObject,
			[MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			[In, Optional][MarshalAs(UnmanagedType.Interface)] object clientDrawingEffect);

		/// <summary>IDWriteTextLayout:: <c>Draw</c> calls this function to instruct the client to render a run of glyphs.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <b>void*</b></para>
		/// <para>The application-defined drawing context passed to <c>IDWriteTextLayout::Draw</c>.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The pixel location (X-coordinate) at the baseline origin of the glyph run.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The pixel location (Y-coordinate) at the baseline origin of the glyph run.</para>
		/// </param>
		/// <param name="orientationAngle">
		/// <para>Type: <b><c>DWRITE_GLYPH_ORIENTATION_ANGLE</c></b></para>
		/// <para>Orientation of the glyph run.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>The measuring method for glyphs in the run, used with the other properties to determine the rendering mode.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN</c>*</b></para>
		/// <para>Pointer to the glyph run instance to render.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_RUN_DESCRIPTION</c>*</b></para>
		/// <para>A pointer to the glyph run description instance which contains properties of the characters associated with this run.</para>
		/// </param>
		/// <param name="clientDrawingEffect">
		/// <para>Type: <b>IUnknown*</b></para>
		/// <para>
		/// Application-defined drawing effects for the glyphs to render. Usually this argument represents effects such as the foreground
		/// brush filling the interior of text.
		/// </para>
		/// </param>
		/// <remarks>
		/// The <c>IDWriteTextLayout::Draw</c> function calls this callback function with all the information about glyphs to render. The
		/// application implements this callback by mostly delegating the call to the underlying platform's graphics API such as
		/// <c>Direct2D</c> to draw glyphs on the drawing context. An application that uses GDI can implement this callback in terms of the
		/// <c>IDWriteBitmapRenderTarget::DrawGlyphRun</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextrenderer1-drawglyphrun HRESULT DrawGlyphRun(
		// void *clientDrawingContext, FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_GLYPH_ORIENTATION_ANGLE orientationAngle,
		// DWRITE_MEASURING_MODE measuringMode, [in] DWRITE_GLYPH_RUN const *glyphRun, [in] DWRITE_GLYPH_RUN_DESCRIPTION const
		// *glyphRunDescription, IUnknown *clientDrawingEffect );
		void DrawGlyphRun([In, Optional] IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY,
			DWRITE_GLYPH_ORIENTATION_ANGLE orientationAngle, DWRITE_MEASURING_MODE measuringMode, in DWRITE_GLYPH_RUN glyphRun,
			in DWRITE_GLYPH_RUN_DESCRIPTION glyphRunDescription, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? clientDrawingEffect);

		/// <summary>IDWriteTextLayout::Draw calls this function to instruct the client to draw an underline.</summary>
		/// <param name="clientDrawingContext">The context passed to IDWriteTextLayout::Draw.</param>
		/// <param name="baselineOriginX">X-coordinate of the baseline.</param>
		/// <param name="baselineOriginY">Y-coordinate of the baseline.</param>
		/// <param name="orientationAngle">Orientation of the underline.</param>
		/// <param name="underline">Underline logical information.</param>
		/// <param name="clientDrawingEffect">The drawing effect set in IDWriteTextLayout::SetDrawingEffect.</param>
		/// <remarks>
		/// A single underline can be broken into multiple calls, depending on how the formatting changes attributes. If font sizes/styles
		/// change within an underline, the thickness and offset will be averaged weighted according to characters. To get the correct top
		/// coordinate of the underline rect, add underline::offset to the baseline's Y. Otherwise the underline will be immediately under
		/// the text. The x coordinate will always be passed as the left side, regardless of text directionality. This simplifies drawing
		/// and reduces the problem of round-off that could potentially cause gaps or a double stamped alpha blend. To avoid alpha overlap,
		/// round the end points to the nearest device pixel.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_2/nf-dwrite_2-idwritetextrenderer1-drawunderline
		// HRESULT DrawUnderline( void *clientDrawingContext, FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_GLYPH_ORIENTATION_ANGLE
		// orientationAngle, DWRITE_UNDERLINE const *underline, IUnknown *clientDrawingEffect );
		void DrawUnderline([In, Optional] IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY,
			DWRITE_GLYPH_ORIENTATION_ANGLE orientationAngle, in DWRITE_UNDERLINE underline,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? clientDrawingEffect);

		/// <summary>IDWriteTextLayout::Draw calls this function to instruct the client to draw a strikethrough.</summary>
		/// <param name="clientDrawingContext">The context passed to IDWriteTextLayout::Draw.</param>
		/// <param name="baselineOriginX">X-coordinate of the baseline.</param>
		/// <param name="baselineOriginY">Y-coordinate of the baseline.</param>
		/// <param name="orientationAngle">Orientation of the strikethrough.</param>
		/// <param name="strikethrough">Strikethrough logical information.</param>
		/// <param name="clientDrawingEffect">The drawing effect set in IDWriteTextLayout::SetDrawingEffect.</param>
		/// <remarks>
		/// A single strikethrough can be broken into multiple calls, depending on how the formatting changes attributes. Strikethrough is
		/// not averaged across font sizes/styles changes. To get the correct top coordinate of the strikethrough rect, add
		/// strikethrough::offset to the baseline's Y. Like underlines, the x coordinate will always be passed as the left side, regardless
		/// of text directionality.
		/// </remarks>
		void DrawStrikethrough([In, Optional] IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY,
			DWRITE_GLYPH_ORIENTATION_ANGLE orientationAngle, in DWRITE_STRIKETHROUGH strikethrough,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? clientDrawingEffect);

		/// <summary>IDWriteTextLayout::Draw calls this application callback when it needs to draw an inline object.</summary>
		/// <param name="clientDrawingContext">The context passed to IDWriteTextLayout::Draw.</param>
		/// <param name="originX">X-coordinate at the top-left corner of the inline object.</param>
		/// <param name="originY">Y-coordinate at the top-left corner of the inline object.</param>
		/// <param name="orientationAngle">Orientation of the inline object.</param>
		/// <param name="inlineObject">The object set using IDWriteTextLayout::SetInlineObject.</param>
		/// <param name="isSideways">The object should be drawn on its side.</param>
		/// <param name="isRightToLeft">The object is in an right-to-left context and should be drawn flipped.</param>
		/// <param name="clientDrawingEffect">The drawing effect set in IDWriteTextLayout::SetDrawingEffect.</param>
		/// <remarks>
		/// The right-to-left flag is a hint to draw the appropriate visual for that reading direction. For example, it would look strange
		/// to draw an arrow pointing to the right to indicate a submenu. The sideways flag similarly hints that the object is drawn in a
		/// different orientation. If a non-identity orientation is passed, the top left of the inline object should be rotated around the
		/// given x and y coordinates. IDWriteAnalyzer2::GetGlyphOrientationTransform returns the necessary transform for this.
		/// </remarks>
		void DrawInlineObject([In, Optional] IntPtr clientDrawingContext, float originX, float originY, DWRITE_GLYPH_ORIENTATION_ANGLE orientationAngle,
			[In] IDWriteInlineObject inlineObject, bool isSideways, bool isRightToLeft, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? clientDrawingEffect);
	}

	/// <summary>
	/// Contains the information needed by renderers to draw glyph runs with glyph color information. All coordinates are in device
	/// independent pixels (DIPs).
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/ns-dwrite_2-dwrite_color_glyph_run struct DWRITE_COLOR_GLYPH_RUN {
	// DWRITE_GLYPH_RUN glyphRun; DWRITE_GLYPH_RUN_DESCRIPTION *glyphRunDescription; FLOAT baselineOriginX; FLOAT baselineOriginY;
	// DWRITE_COLOR_F runColor; UINT16 paletteIndex; };
	[PInvokeData("dwrite_2.h", MSDNShortId = "NS:dwrite_2.DWRITE_COLOR_GLYPH_RUN")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_COLOR_GLYPH_RUN
	{
		/// <summary>Glyph run to draw for this layer.</summary>
		public DWRITE_GLYPH_RUN glyphRun;

		/// <summary>
		/// Pointer to the glyph run description for this layer. This may be <b>NULL</b>. For example, when the original glyph run is split
		/// into multiple layers, one layer might have a description and the others have none.
		/// </summary>
		public StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription;

		/// <summary>X coordinate of the baseline origin for the layer.</summary>
		public float baselineOriginX;

		/// <summary>Y coordinate of the baseline origin for the layer.</summary>
		public float baselineOriginY;

		/// <summary>Color value of the run; if all members are zero, the run should be drawn using the current brush.</summary>
		public D3DCOLORVALUE runColor;

		/// <summary>
		/// Zero-based index into the font’s color palette; if this is <b>0xFFFF</b>, the run should be drawn using the current brush.
		/// </summary>
		public ushort paletteIndex;
	}

	/// <summary>
	/// <para>Contains the metrics associated with text after layout.All coordinates are in device independent pixels (DIPs).</para>
	/// <para><b>DWRITE_TEXT_METRICS1</b> extends <c>DWRITE_TEXT_METRICS</c> to include the height of the formatted text.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/ns-dwrite_2-dwrite_text_metrics1 struct DWRITE_TEXT_METRICS1 :
	// DWRITE_TEXT_METRICS { FLOAT heightIncludingTrailingWhitespace; };
	[PInvokeData("dwrite_2.h", MSDNShortId = "NS:dwrite_2.DWRITE_TEXT_METRICS1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_TEXT_METRICS1
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the left-most point of formatted text relative to the layout box, while excluding any glyph overhang.</para>
		/// </summary>
		public float left;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the top-most point of formatted text relative to the layout box, while excluding any glyph overhang.</para>
		/// </summary>
		public float top;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the width of the formatted text, while ignoring trailing whitespace at the end of each line.</para>
		/// </summary>
		public float width;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the formatted text, taking into account the trailing whitespace at the end of each line.</para>
		/// </summary>
		public float widthIncludingTrailingWhitespace;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the formatted text. The height of an empty string is set to the same value as that of the default font.</para>
		/// </summary>
		public float height;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The initial width given to the layout. It can be either larger or smaller than the text content width, depending on whether the
		/// text was wrapped.
		/// </para>
		/// </summary>
		public float layoutWidth;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Initial height given to the layout. Depending on the length of the text, it may be larger or smaller than the text content height.
		/// </para>
		/// </summary>
		public float layoutHeight;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The maximum reordering count of any line of text, used to calculate the most number of hit-testing boxes needed. If the layout
		/// has no bidirectional text, or no text at all, the minimum level is 1.
		/// </para>
		/// </summary>
		public uint maxBidiReorderingDepth;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Total number of lines.</para>
		/// </summary>
		public uint lineCount;

		/// <summary>
		/// The height of the formatted text taking into account the trailing whitespace at the end of each line. This is pertinent for
		/// vertical text.
		/// </summary>
		public float heightIncludingTrailingWhitespace;
	}
}