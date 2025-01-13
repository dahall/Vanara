namespace Vanara.PInvoke;

public static partial class WindowsCodecs
{
	/// <summary>Defines methods that add the concept of writeability and static in-memory representations of bitmaps to IWICBitmapSource.</summary>
	/// <remarks>
	/// <para>
	/// <c>IWICBitmap</c> inherits from IWICBitmapSource and therefore also inherits the CopyPixels method. When pixels need to be moved
	/// to a new memory location, <c>CopyPixels</c> is often the most efficient.
	/// </para>
	/// <para>
	/// Because of to the internal memory representation implied by the <c>IWICBitmap</c>, in-place modification and processing using
	/// the Lock is more efficient than CopyPixels, usually reducing to a simple pointer access directly into the memory owned by the
	/// bitmap rather than a as a copy. This is contrasted to procedural bitmaps which implement only <c>CopyPixels</c> because there is
	/// no internal memory representation and one would need to be created on demand to satisfy a call to <c>Lock</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmap
	[PInvokeData("wincodec.h", MSDNShortId = "15dcc80d-ef58-453d-a57a-348ffc7ddc6b")]
	[ComImport, Guid("00000121-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmap : IWICBitmapSource
	{
		/// <summary>Retrieves the pixel width and height of the bitmap.</summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel width of the bitmap.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel height of the bitmap</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getsize HRESULT GetSize( UINT
		// *puiWidth, UINT *puiHeight );
		new void GetSize(out uint puiWidth, out uint puiHeight);

		/// <summary>Retrieves the pixel format of the bitmap source..</summary>
		/// <returns>
		/// Receives the pixel format GUID the bitmap is stored in. For a list of available pixel formats, see the Native Pixel Formats topic.
		/// </returns>
		/// <remarks>
		/// The pixel format returned by this method is not necessarily the pixel format the image is stored as. The codec may perform a
		/// format conversion from the storage pixel format to an output pixel format.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getpixelformat HRESULT
		// GetPixelFormat( Guid *pPixelFormat );
		new Guid GetPixelFormat();

		/// <summary>Retrieves the sampling rate between pixels and physical world measurements.</summary>
		/// <param name="pDpiX">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the x-axis dpi resolution.</para>
		/// </param>
		/// <param name="pDpiY">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the y-axis dpi resolution.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Some formats, such as GIF and ICO, do not have full DPI support. For GIF, this method calculates the DPI values from the
		/// aspect ratio, using a base DPI of (96.0, 96.0). The ICO format does not support DPI at all, and the method always returns
		/// (96.0,96.0) for ICO images.
		/// </para>
		/// <para>
		/// Additionally, WIC itself does not transform images based on the DPI values in an image. It is up to the caller to transform
		/// an image based on the resolution returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getresolution HRESULT GetResolution(
		// double *pDpiX, double *pDpiY );
		new void GetResolution(out double pDpiX, out double pDpiY);

		/// <summary>Retrieves the color table for indexed pixel formats.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>An IWICPalette. A palette can be created using the CreatePalette method.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WINCODEC_ERR_PALETTEUNAVAILABLE</term>
		/// <term>The palette was unavailable.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The palette was successfully copied.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the IWICBitmapSource is an IWICBitmapFrameDecode, the function may return the image's global palette if a frame-level
		/// palette is not available. The global palette may also be retrieved using the CopyPalette method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypalette HRESULT CopyPalette(
		// IWICPalette *pIPalette );
		[PreserveSig]
		new HRESULT CopyPalette(IWICPalette pIPalette);

		/// <summary>Instructs the object to produce pixels.</summary>
		/// <param name="prc">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle to copy. A <c>NULL</c> value specifies the entire bitmap.</para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride of the bitmap</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CopyPixels</c> is one of the two main image processing routines (the other being Lock) triggering the actual processing.
		/// It instructs the object to produce pixels according to its algorithm - this may involve decoding a portion of a JPEG stored
		/// on disk, copying a block of memory, or even analytically computing a complex gradient. The algorithm is completely dependent
		/// on the object implementing the interface.
		/// </para>
		/// <para>
		/// The caller can restrict the operation to a rectangle of interest (ROI) using the prc parameter. The ROI sub-rectangle must
		/// be fully contained in the bounds of the bitmap. Specifying a <c>NULL</c> ROI implies that the whole bitmap should be returned.
		/// </para>
		/// <para>
		/// The caller controls the memory management and must provide an output buffer (pbBuffer) for the results of the copy along
		/// with the buffer's bounds (cbBufferSize). The cbStride parameter defines the count of bytes between two vertically adjacent
		/// pixels in the output buffer. The caller must ensure that there is sufficient buffer to complete the call based on the width,
		/// height and pixel format of the bitmap and the sub-rectangle provided to the copy method.
		/// </para>
		/// <para>
		/// If the caller needs to perform numerous copies of an expensive IWICBitmapSource such as a JPEG, it is recommended to create
		/// an in-memory IWICBitmap first.
		/// </para>
		/// <para>Codec Developer Remarks</para>
		/// <para>
		/// The callee must only write to the first (prc-&gt;Width*bitsperpixel+7)/8 bytes of each line of the output buffer (in this
		/// case, a line is a consecutive string of cbStride bytes).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypixels HRESULT CopyPixels( const
		// WICRect *prc, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer );
		new void CopyPixels([In, Optional] PWICRect? prc, uint cbStride, uint cbBufferSize, [In, Out] IntPtr pbBuffer);

		/// <summary>Provides access to a rectangular area of the bitmap.</summary>
		/// <param name="prcLock">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle to be accessed.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The access mode you wish to obtain for the lock. This is a bitwise combination of WICBitmapLockFlags for read, write, or
		/// read and write access.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WICBitmapLockRead</term>
		/// <term>The read access lock.</term>
		/// </item>
		/// <item>
		/// <term>WICBitmapLockWrite</term>
		/// <term>The write access lock.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmapLock**</c></para>
		/// <para>A pointer that receives the locked memory location.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Locks are exclusive for writing but can be shared for reading. You cannot call CopyPixels while the IWICBitmap is locked for
		/// writing. Doing so will return an error, since locks are exclusive.
		/// </para>
		/// <para>Examples</para>
		/// <para>In the following example, an IWICBitmap is created and the image data is cleared using an IWICBitmapLock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmap-lock HRESULT Lock( const WICRect *prcLock,
		// DWORD flags, IWICBitmapLock **ppILock );
		IWICBitmapLock Lock([In, Optional] PWICRect? prcLock, WICBitmapLockFlags flags);

		/// <summary>Provides access for palette modifications.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>The palette to use for conversion.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmap-setpalette HRESULT SetPalette( IWICPalette
		// *pIPalette );
		void SetPalette(IWICPalette pIPalette);

		/// <summary>Changes the physical resolution of the image.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>double</c></para>
		/// <para>The horizontal resolution.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>double</c></para>
		/// <para>The vertical resolution.</para>
		/// </param>
		/// <remarks>
		/// This method has no effect on the actual pixels or samples stored in the bitmap. Instead the interpretation of the sampling
		/// rate is modified. This means that a 96 DPI image which is 96 pixels wide is one inch. If the physical resolution is modified
		/// to 48 DPI, then the bitmap is considered to be 2 inches wide but has the same number of pixels. If the resolution is less
		/// than <c>REAL_EPSILON</c> (1.192092896e-07F) the error code <c>WINCODEC_ERR_INVALIDPARAMETER</c> is returned.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmap-setresolution HRESULT SetResolution(
		// double dpiX, double dpiY );
		void SetResolution(double dpiX, double dpiY);
	}

	/// <summary>Exposes methods that produce a clipped version of the input bitmap for a specified rectangular region of interest.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapclipper
	[PInvokeData("wincodec.h", MSDNShortId = "a21fb11f-8622-46d6-8612-875ac59d3fbf")]
	[ComImport, Guid("E4FBCF03-223D-4e81-9333-D635556DD1B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapClipper : IWICBitmapSource
	{
		/// <summary>Retrieves the pixel width and height of the bitmap.</summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel width of the bitmap.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel height of the bitmap</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getsize HRESULT GetSize( UINT
		// *puiWidth, UINT *puiHeight );
		new void GetSize(out uint puiWidth, out uint puiHeight);

		/// <summary>Retrieves the pixel format of the bitmap source..</summary>
		/// <returns>
		/// Receives the pixel format GUID the bitmap is stored in. For a list of available pixel formats, see the Native Pixel Formats topic.
		/// </returns>
		/// <remarks>
		/// The pixel format returned by this method is not necessarily the pixel format the image is stored as. The codec may perform a
		/// format conversion from the storage pixel format to an output pixel format.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getpixelformat HRESULT
		// GetPixelFormat( Guid *pPixelFormat );
		new Guid GetPixelFormat();

		/// <summary>Retrieves the sampling rate between pixels and physical world measurements.</summary>
		/// <param name="pDpiX">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the x-axis dpi resolution.</para>
		/// </param>
		/// <param name="pDpiY">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the y-axis dpi resolution.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Some formats, such as GIF and ICO, do not have full DPI support. For GIF, this method calculates the DPI values from the
		/// aspect ratio, using a base DPI of (96.0, 96.0). The ICO format does not support DPI at all, and the method always returns
		/// (96.0,96.0) for ICO images.
		/// </para>
		/// <para>
		/// Additionally, WIC itself does not transform images based on the DPI values in an image. It is up to the caller to transform
		/// an image based on the resolution returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getresolution HRESULT GetResolution(
		// double *pDpiX, double *pDpiY );
		new void GetResolution(out double pDpiX, out double pDpiY);

		/// <summary>Retrieves the color table for indexed pixel formats.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>An IWICPalette. A palette can be created using the CreatePalette method.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WINCODEC_ERR_PALETTEUNAVAILABLE</term>
		/// <term>The palette was unavailable.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The palette was successfully copied.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the IWICBitmapSource is an IWICBitmapFrameDecode, the function may return the image's global palette if a frame-level
		/// palette is not available. The global palette may also be retrieved using the CopyPalette method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypalette HRESULT CopyPalette(
		// IWICPalette *pIPalette );
		[PreserveSig]
		new HRESULT CopyPalette(IWICPalette pIPalette);

		/// <summary>Instructs the object to produce pixels.</summary>
		/// <param name="prc">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle to copy. A <c>NULL</c> value specifies the entire bitmap.</para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride of the bitmap</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CopyPixels</c> is one of the two main image processing routines (the other being Lock) triggering the actual processing.
		/// It instructs the object to produce pixels according to its algorithm - this may involve decoding a portion of a JPEG stored
		/// on disk, copying a block of memory, or even analytically computing a complex gradient. The algorithm is completely dependent
		/// on the object implementing the interface.
		/// </para>
		/// <para>
		/// The caller can restrict the operation to a rectangle of interest (ROI) using the prc parameter. The ROI sub-rectangle must
		/// be fully contained in the bounds of the bitmap. Specifying a <c>NULL</c> ROI implies that the whole bitmap should be returned.
		/// </para>
		/// <para>
		/// The caller controls the memory management and must provide an output buffer (pbBuffer) for the results of the copy along
		/// with the buffer's bounds (cbBufferSize). The cbStride parameter defines the count of bytes between two vertically adjacent
		/// pixels in the output buffer. The caller must ensure that there is sufficient buffer to complete the call based on the width,
		/// height and pixel format of the bitmap and the sub-rectangle provided to the copy method.
		/// </para>
		/// <para>
		/// If the caller needs to perform numerous copies of an expensive IWICBitmapSource such as a JPEG, it is recommended to create
		/// an in-memory IWICBitmap first.
		/// </para>
		/// <para>Codec Developer Remarks</para>
		/// <para>
		/// The callee must only write to the first (prc-&gt;Width*bitsperpixel+7)/8 bytes of each line of the output buffer (in this
		/// case, a line is a consecutive string of cbStride bytes).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypixels HRESULT CopyPixels( const
		// WICRect *prc, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer );
		new void CopyPixels([In, Optional] PWICRect? prc, uint cbStride, uint cbBufferSize, [In, Out] IntPtr pbBuffer);

		/// <summary>Initializes the bitmap clipper with the provided parameters.</summary>
		/// <param name="pISource">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>he input bitmap source.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle of the bitmap source to clip.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapclipper-initialize HRESULT Initialize(
		// IWICBitmapSource *pISource, const WICRect *prc );
		void Initialize(IWICBitmapSource pISource, in WICRect prc);
	}

	/// <summary>Exposes methods that provide information about a particular codec.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapcodecinfo
	[PInvokeData("wincodec.h", MSDNShortId = "502a94bf-3ec4-44d2-b0de-9994f2f9861f")]
	[ComImport, Guid("E87A44C4-B76E-4c47-8B09-298EB12A2714"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapCodecInfo : IWICComponentInfo
	{
		/// <summary>Retrieves the component's WICComponentType.</summary>
		/// <returns>
		/// <para>Type: <c>WICComponentType*</c></para>
		/// <para>A pointer that receives the WICComponentType.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getcomponenttype HRESULT
		// GetComponentType( WICComponentType *pType );
		new WICComponentType GetComponentType();

		/// <summary>Retrieves the component's class identifier (CLSID)</summary>
		/// <returns>
		/// <para>Type: <c>CLSID*</c></para>
		/// <para>A pointer that receives the component's CLSID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getclsid HRESULT GetCLSID( CLSID
		// *pclsid );
		new Guid GetCLSID();

		/// <summary>Retrieves the signing status of the component.</summary>
		/// <returns>
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer that receives the WICComponentSigning status of the component.</para>
		/// </returns>
		/// <remarks>
		/// <para>Signing is unused by WIC. Therefore, all components WICComponentSigned.</para>
		/// <para>
		/// This function can be used to determine whether a component has no binary component or has been added to the disabled
		/// components list in the registry.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getsigningstatus HRESULT
		// GetSigningStatus( DWORD *pStatus );
		new WICComponentSigning GetSigningStatus();

		/// <summary>Retrieves the name of component's author.</summary>
		/// <param name="cchAuthor">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzAuthor buffer.</para>
		/// </param>
		/// <param name="wzAuthor">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// A pointer that receives the name of the component's author. The locale of the string depends on the value that the codec
		/// wrote to the registry at install time. For built-in components, these strings are always in English.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's authors name. The author name is optional; if an author name is
		/// not specified by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getauthor HRESULT GetAuthor( UINT
		// cchAuthor, WCHAR *wzAuthor, UINT *pcchActual );
		new void GetAuthor(uint cchAuthor, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzAuthor, out uint pcchActual);

		/// <summary>Retrieves the vendor GUID.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>A pointer that receives the component's vendor GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getvendorguid HRESULT
		// GetVendorGUID( GUID *pguidVendor );
		new Guid GetVendorGUID();

		/// <summary>Retrieves the component's version.</summary>
		/// <param name="cchVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzVersion buffer.</para>
		/// </param>
		/// <param name="wzVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>A pointer that receives a culture invariant string of the component's version.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's version. The version is optional; if a value is not specified
		/// by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>All built-in components return "1.0.0.0", except for pixel formats, which do not have a version.</para>
		/// <para>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getversion HRESULT GetVersion( UINT
		// cchVersion, WCHAR *wzVersion, UINT *pcchActual );
		new void GetVersion(uint cchVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzVersion, out uint pcchActual);

		/// <summary>Retrieves the component's specification version.</summary>
		/// <param name="cchSpecVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzSpecVersion buffer.</para>
		/// </param>
		/// <param name="wzSpecVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contain a culture invarient string of the component's specification version. The version form is NN.NN.NN.NN.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's specification version. The specification version is optional;
		/// if a value is not specified by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>All built-in components return "1.0.0.0", except for pixel formats, which do not have a spec version.</para>
		/// <para>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getspecversion HRESULT
		// GetSpecVersion( UINT cchSpecVersion, WCHAR *wzSpecVersion, UINT *pcchActual );
		new void GetSpecVersion(uint cchSpecVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzSpecVersion, out uint pcchActual);

		/// <summary>Retrieves the component's friendly name, which is a human-readable display name for the component.</summary>
		/// <param name="cchFriendlyName">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzFriendlyName buffer.</para>
		/// </param>
		/// <param name="wzFriendlyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// A pointer that receives the friendly name of the component. The locale of the string depends on the value that the codec
		/// wrote to the registry at install time. For built-in components, these strings are always in English.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the actual length of the component's friendly name.</para>
		/// </param>
		/// <remarks>If cchFriendlyName is 0 and wzFriendlyName is <c>NULL</c>, the required buffer size is returned in pccchActual.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getfriendlyname HRESULT
		// GetFriendlyName( UINT cchFriendlyName, WCHAR *wzFriendlyName, UINT *pcchActual );
		new void GetFriendlyName(uint cchFriendlyName, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzFriendlyName, out uint pcchActual);

		/// <summary>Retrieves the container GUID associated with the codec.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Receives the container GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getcontainerformat HRESULT
		// GetContainerFormat( GUID *pguidContainerFormat );
		Guid GetContainerFormat();

		/// <summary>Retrieves the pixel formats the codec supports.</summary>
		/// <param name="cFormats">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pguidPixelFormats array. Use 0 on first call to determine the needed array size.</para>
		/// </param>
		/// <param name="pguidPixelFormats">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Receives the supported pixel formats. Use <see langword="null"/> on first call to determine needed array size.</para>
		/// </param>
		/// <param name="pcActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The array size needed to retrieve all supported pixel formats.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the array size needed to retrieve all the
		/// supported pixel formats by calling it with cFormats set to 0 and pguidPixelFormats set to <see langword="null"/>. This call
		/// sets pcActual to the array size needed. Once the needed array size is determined, a second <c>GetPixelFormats</c> call with
		/// pguidPixelFormats set to an array of the appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getpixelformats HRESULT
		// GetPixelFormats( UINT cFormats, GUID *pguidPixelFormats, UINT *pcActual );
		void GetPixelFormats(uint cFormats, Guid[] pguidPixelFormats, out uint pcActual);

		/// <summary>Retrieves the color manangement version number the codec supports.</summary>
		/// <param name="cchColorManagementVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the version buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzColorManagementVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives the color management version number. Use <see langword="null"/> on first call to determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve the full color management version number.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchColorManagementVersion set to 0 and wzColorManagementVersion set
		/// to <see langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a
		/// second <c>GetColorManagementVersion</c> call with cchColorManagementVersion set to the buffer size and
		/// wzColorManagementVersion set to a buffer of the appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getcolormanagementversion HRESULT
		// GetColorManagementVersion( UINT cchColorManagementVersion, WCHAR *wzColorManagementVersion, UINT *pcchActual );
		void GetColorManagementVersion(uint cchColorManagementVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzColorManagementVersion, out uint pcchActual);

		/// <summary>Retrieves the name of the device manufacture associated with the codec.</summary>
		/// <param name="cchDeviceManufacturer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the device manufacture's name. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzDeviceManufacturer">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Receives the device manufacture's name. Use <see langword="null"/> on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve the device manufacture's name.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchDeviceManufacturer set to 0 and wzDeviceManufacturer set to <see
		/// langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second
		/// <c>GetDeviceManufacturer</c> call with cchDeviceManufacturer set to the buffer size and wzDeviceManufacturer set to a buffer
		/// of the appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getdevicemanufacturer HRESULT
		// GetDeviceManufacturer( UINT cchDeviceManufacturer, WCHAR *wzDeviceManufacturer, UINT *pcchActual );
		void GetDeviceManufacturer(uint cchDeviceManufacturer, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceManufacturer, out uint pcchActual);

		/// <summary>Retrieves a comma delimited list of device models associated with the codec.</summary>
		/// <param name="cchDeviceModels">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the device models buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzDeviceModels">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives a comma delimited list of device model names associated with the codec. Use <see langword="null"/> on first call to
		/// determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve all of the device model names.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchDeviceModels set to 0 and wzDeviceModels set to <see
		/// langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second
		/// <c>GetDeviceModels</c> call with cchDeviceModels set to the buffer size and wzDeviceModels set to a buffer of the
		/// appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getdevicemodels HRESULT
		// GetDeviceModels( UINT cchDeviceModels, WCHAR *wzDeviceModels, UINT *pcchActual );
		void GetDeviceModels(uint cchDeviceModels, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceModels, out uint pcchActual);

		/// <summary>Retrieves a comma delimited sequence of mime types associated with the codec.</summary>
		/// <param name="cchMimeTypes">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the mime types buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzMimeTypes">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives the mime types associated with the codec. Use <see langword="null"/> on first call to determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve all mime types associated with the codec.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchMimeTypes set to 0 and wzMimeTypes set to <see langword="null"/>.
		/// This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second <c>GetMimeTypes</c>
		/// call with cchMimeTypes set to the buffer size and wzMimeTypes set to a buffer of the appropriate size will retrieve the
		/// pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getmimetypes HRESULT
		// GetMimeTypes( UINT cchMimeTypes, WCHAR *wzMimeTypes, UINT *pcchActual );
		void GetMimeTypes(uint cchMimeTypes, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzMimeTypes, out uint pcchActual);

		/// <summary>Retrieves a comma delimited list of the file name extensions associated with the codec.</summary>
		/// <param name="cchFileExtensions">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the file name extension buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzFileExtensions">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives a comma delimited list of file name extensions associated with the codec. Use <see langword="null"/> on first call
		/// to determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve all file name extensions associated with the codec.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>The default extension for an image encoder is the first item in the list of returned extensions.</para>
		/// <para>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchFileExtensions set to 0 and wzFileExtensions set to <see
		/// langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second
		/// <c>GetFileExtensions</c> call with cchFileExtensions set to the buffer size and wzFileExtensions set to a buffer of the
		/// appropriate size will retrieve the pixel formats.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getfileextensions HRESULT
		// GetFileExtensions( UINT cchFileExtensions, WCHAR *wzFileExtensions, UINT *pcchActual );
		void GetFileExtensions(uint cchFileExtensions, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzFileExtensions, out uint pcchActual);

		/// <summary>Retrieves a value indicating whether the codec supports animation.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports images with timing information; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportanimation HRESULT
		// DoesSupportAnimation( BOOL *pfSupportAnimation );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesSupportAnimation();

		/// <summary>Retrieves a value indicating whether the codec supports chromakeys.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports chromakeys; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportchromakey HRESULT
		// DoesSupportChromakey( BOOL *pfSupportChromakey );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesSupportChromakey();

		/// <summary>Retrieves a value indicating whether the codec supports lossless formats.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports lossless formats; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportlossless HRESULT
		// DoesSupportLossless( BOOL *pfSupportLossless );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesSupportLossless();

		/// <summary>Retrieves a value indicating whether the codec supports multi frame images.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports multi frame images; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportmultiframe HRESULT
		// DoesSupportMultiframe( BOOL *pfSupportMultiframe );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesSupportMultiframe();

		/// <summary>Retrieves a value indicating whether the given mime type matches the mime type of the codec.</summary>
		/// <param name="wzMimeType">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The mime type to compare.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the mime types match; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks><c>Note</c> The Windows provided codecs do not implement this method and return E_NOTIMPL.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-matchesmimetype HRESULT
		// MatchesMimeType( LPCWSTR wzMimeType, BOOL *pfMatches );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool MatchesMimeType([MarshalAs(UnmanagedType.LPWStr)] string wzMimeType);
	}

	/// <summary>Exposes methods used for progress notification for encoders and decoders.</summary>
	/// <remarks>This interface is not supported by the Windows provided codecs.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapcodecprogressnotification
	[ComImport, Guid("64C1024E-C3CF-4462-8078-88C2B11C46D9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapCodecProgressNotification
	{
		/// <summary>Registers a progress notification callback function.</summary>
		/// <param name="pfnProgressNotification">
		/// <para>Type: <c>PFNProgressNotification</c></para>
		/// <para>
		/// A function pointer to the application defined progress notification callback function. See ProgressNotificationCallback for
		/// the callback signature.
		/// </para>
		/// </param>
		/// <param name="pvData">
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>A pointer to component data for the callback method.</para>
		/// </param>
		/// <param name="dwProgressFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The <see cref="WICProgressOperation"/> and <see cref="WICProgressNotification"/> flags to use for progress notification.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Applications can only register a single callback. Subsequent registration calls will replace the previously registered
		/// callback. To unregister a callback, pass in <c>NULL</c> or register a new callback function.
		/// </para>
		/// <para>
		/// Progress is reported in an increasing order between 0.0 and 1.0. If dwProgressFlags includes
		/// <c>WICProgressNotificationBegin</c>, the callback is guaranteed to be called with progress 0.0. If dwProgressFlags includes
		/// <c>WICProgressNotificationEnd</c>, the callback is guaranteed to be called with progress 1.0.
		/// </para>
		/// <para>
		/// <c>WICProgressNotificationFrequent</c> increases the frequency in which the callback is called. If an operation is expected
		/// to take more than 30 seconds, <c>WICProgressNotificationFrequent</c> should be added to dwProgressFlags.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecprogressnotification-registerprogressnotification
		// HRESULT RegisterProgressNotification( PFNProgressNotification pfnProgressNotification, LPVOID pvData, DWORD dwProgressFlags );
		void RegisterProgressNotification([In, Optional] PFNProgressNotification? pfnProgressNotification, [In, Optional] IntPtr pvData, uint dwProgressFlags);
	}

	/// <summary>
	/// <para>Exposes methods that represent a decoder.</para>
	/// <para>The interface provides access to the decoder's properties such as global thumbnails (if supported), frames, and palette.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// There are a number of concrete implemenations of this interface representing each of the standard decoders provided by the
	/// platform including bitmap (BMP), Portable Network Graphics (PNG), icon (ICO), Joint Photographic Experts Group (JPEG), Graphics
	/// Interchange Format (GIF), Tagged Image File Format (TIFF), and Microsoft Windows Digital Photo (WDP). The following table
	/// includes the class identifier (CLSID) for each native decoder.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>CLSID Name</term>
	/// <term>CLSID</term>
	/// </listheader>
	/// <item>
	/// <term>CLSID_WICBmpDecoder</term>
	/// <term>0x6b462062, 0x7cbf, 0x400d, 0x9f, 0xdb, 0x81, 0x3d, 0xd1, 0xf, 0x27, 0x78</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICGifDecoder</term>
	/// <term>0x381dda3c, 0x9ce9, 0x4834, 0xa2, 0x3e, 0x1f, 0x98, 0xf8, 0xfc, 0x52, 0xbe</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICHeifDecoder</term>
	/// <term>0xe9a4a80a, 0x44fe, 0x4de4, 0x89, 0x71, 0x71, 0x50, 0xb1, 0x0a, 0x51, 0x99</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICIcoDecoder</term>
	/// <term>0xc61bfcdf, 0x2e0f, 0x4aad, 0xa8, 0xd7, 0xe0, 0x6b, 0xaf, 0xeb, 0xcd, 0xfe</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICJpegDecoder</term>
	/// <term>0x9456a480, 0xe88b, 0x43ea, 0x9e, 0x73, 0xb, 0x2d, 0x9b, 0x71, 0xb1, 0xca</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICPngDecoder</term>
	/// <term>0x389ea17b, 0x5078, 0x4cde, 0xb6, 0xef, 0x25, 0xc1, 0x51, 0x75, 0xc7, 0x51</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICTiffDecoder</term>
	/// <term>0xb54e85d9, 0xfe23, 0x499f, 0x8b, 0x88, 0x6a, 0xce, 0xa7, 0x13, 0x75, 0x2b</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICWebpDecoder</term>
	/// <term>0x7693e886, 0x51c9, 0x4070, 0x84, 0x19, 0x9f, 0x70, 0X73, 0X8e, 0Xc8, 0Xfa</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICWmpDecoder</term>
	/// <term>0xa26cec36, 0x234c, 0x4950, 0xae, 0x16, 0xe3, 0x4a, 0xac, 0xe7, 0x1d, 0x0d</term>
	/// </item>
	/// </list>
	/// <para>
	/// This interface may be sub-classed to provide support for third party codecs as part of the extensibility model. See the AITCodec
	/// Sample CODEC.
	/// </para>
	/// <para>
	/// Codecs written as TIFF container formats that are not register will decode as a TIFF image. Client applications should check for
	/// a zero frame count to determine if the codec is valid.
	/// </para>
	/// <para>CLSID_WICHeifDecoder operates on HEIF (High Efficiency Image Format) images.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapdecoder
	[PInvokeData("wincodec.h", MSDNShortId = "91dafd5e-e4fb-4691-a3d0-ca8b6ff0aaf7")]
	[ComImport, Guid("9EDDE9E7-8DEE-47ea-99DF-E6FAF2ED44BF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapDecoder
	{
		/// <summary>Retrieves the capabilities of the decoder based on the specified stream.</summary>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>The stream to retrieve the decoder capabilities from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The WICBitmapDecoderCapabilities of the decoder.</para>
		/// </returns>
		/// <remarks>
		/// Custom decoder implementations should save the current position of the specified IStream, read whatever information is
		/// necessary in order to determine which capabilities it can provide for the supplied stream, and restore the stream position.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-querycapability HRESULT
		// QueryCapability( IStream *pIStream, DWORD *pdwCapability );
		WICBitmapDecoderCapabilities QueryCapability(IStream pIStream);

		/// <summary>Initializes the decoder with the provided stream.</summary>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>The stream to use for initialization.</para>
		/// <para>
		/// The stream contains the encoded pixels which are decoded each time the CopyPixels method on the IWICBitmapFrameDecode
		/// interface (see GetFrame) is invoked.
		/// </para>
		/// </param>
		/// <param name="cacheOptions">
		/// <para>Type: <c>WICDecodeOptions</c></para>
		/// <para>The WICDecodeOptions to use for initialization.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-initialize HRESULT Initialize(
		// IStream *pIStream, WICDecodeOptions cacheOptions );
		void Initialize(IStream pIStream, WICDecodeOptions cacheOptions);

		/// <summary>Retrieves the image's container format.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>A pointer that receives the image's container format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-getcontainerformat HRESULT
		// GetContainerFormat( GUID *pguidContainerFormat );
		Guid GetContainerFormat();

		/// <summary>Retrieves an IWICBitmapDecoderInfo for the image.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapDecoderInfo**</c></para>
		/// <para>A pointer that receives a pointer to an IWICBitmapDecoderInfo.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-getdecoderinfo HRESULT
		// GetDecoderInfo( IWICBitmapDecoderInfo **ppIDecoderInfo );
		IWICBitmapDecoderInfo GetDecoderInfo();

		/// <summary>Copies the decoder's IWICPalette .</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>
		/// AnIWICPalette to which the decoder's global palette is to be copied. Use CreatePalette to create the destination palette
		/// before calling <c>CopyPalette</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// <c>CopyPalette</c> returns a global palette (a palette that applies to all the frames in the image) if there is one;
		/// otherwise, it returns WINCODEC_ERR_PALETTEUNAVAILABLE. If an image doesn't have a global palette, it may still have a
		/// frame-level palette, which can be retrieved using IWICBitmapFrameDecode::CopyPalette.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-copypalette HRESULT CopyPalette(
		// IWICPalette *pIPalette );
		void CopyPalette(IWICPalette pIPalette);

		/// <summary>Retrieves the metadata query reader from the decoder.</summary>
		/// <returns>
		/// <para>Type: <c>IWICMetadataQueryReader**</c></para>
		/// <para>Receives a pointer to the decoder's IWICMetadataQueryReader.</para>
		/// </returns>
		/// <remarks>
		/// If an image format does not support container-level metadata, this will return WINCODEC_ERR_UNSUPPORTEDOPERATION. The only
		/// Windows provided image format that supports container-level metadata is GIF. Instead, use IWICBitmapFrameDecode::GetMetadataQueryReader.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-getmetadataqueryreader HRESULT
		// GetMetadataQueryReader( IWICMetadataQueryReader **ppIMetadataQueryReader );
		IWICMetadataQueryReader GetMetadataQueryReader();

		/// <summary>Retrieves a preview image, if supported.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapSource**</c></para>
		/// <para>Receives a pointer to the preview bitmap if supported.</para>
		/// </returns>
		/// <remarks>Not all formats support previews. Only the native Microsoft Windows Digital Photo (WDP) codec support previews.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-getpreview HRESULT GetPreview(
		// IWICBitmapSource **ppIBitmapSource );
		IWICBitmapSource GetPreview();

		/// <summary>Retrieves the IWICColorContext objects of the image.</summary>
		/// <param name="cCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of color contexts to retrieve.</para>
		/// <para>This value must be the size of, or smaller than, the size available to ppIColorContexts.</para>
		/// </param>
		/// <param name="ppIColorContexts">
		/// <para>Type: <c>IWICColorContext**</c></para>
		/// <para>A pointer that receives a pointer to the IWICColorContext.</para>
		/// </param>
		/// <param name="pcActualCount">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the number of color contexts contained in the image.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-getcolorcontexts HRESULT
		// GetColorContexts( UINT cCount, IWICColorContext **ppIColorContexts, UINT *pcActualCount );
		void GetColorContexts(uint cCount, [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IWICColorContext[] ppIColorContexts, out uint pcActualCount);

		/// <summary>Retrieves a bitmap thumbnail of the image, if one exists</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapSource**</c></para>
		/// <para>Receives a pointer to the IWICBitmapSource of the thumbnail.</para>
		/// </returns>
		/// <remarks>
		/// The returned thumbnail can be of any size, so the caller should scale the thumbnail to the desired size. The only Windows
		/// provided image formats that support thumbnails are JPEG, TIFF, and JPEG-XR. If the thumbnail is not available, this will
		/// return WINCODEC_ERR_CODECNOTHUMBNAIL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-getthumbnail HRESULT GetThumbnail(
		// IWICBitmapSource **ppIThumbnail );
		IWICBitmapSource GetThumbnail();

		/// <summary>Retrieves the total number of frames in the image.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the total number of frames in the image.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-getframecount HRESULT
		// GetFrameCount( UINT *pCount );
		uint GetFrameCount();

		/// <summary>Retrieves the specified frame of the image.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The particular frame to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmapFrameDecode**</c></para>
		/// <para>A pointer that receives a pointer to the IWICBitmapFrameDecode.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoder-getframe HRESULT GetFrame( UINT
		// index, IWICBitmapFrameDecode **ppIBitmapFrame );
		IWICBitmapFrameDecode GetFrame(uint index);
	}

	/// <summary>Exposes methods that provide information about a decoder.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapdecoderinfo
	[PInvokeData("wincodec.h", MSDNShortId = "7edc6d1a-7eda-45ef-bf1d-c5835b37a90f")]
	[ComImport, Guid("D8CD007F-D08F-4191-9BFC-236EA7F0E4B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapDecoderInfo : IWICBitmapCodecInfo
	{
		/// <summary>Retrieves the component's WICComponentType.</summary>
		/// <returns>
		/// <para>Type: <c>WICComponentType*</c></para>
		/// <para>A pointer that receives the WICComponentType.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getcomponenttype HRESULT
		// GetComponentType( WICComponentType *pType );
		new WICComponentType GetComponentType();

		/// <summary>Retrieves the component's class identifier (CLSID)</summary>
		/// <returns>
		/// <para>Type: <c>CLSID*</c></para>
		/// <para>A pointer that receives the component's CLSID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getclsid HRESULT GetCLSID( CLSID
		// *pclsid );
		new Guid GetCLSID();

		/// <summary>Retrieves the signing status of the component.</summary>
		/// <returns>
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer that receives the WICComponentSigning status of the component.</para>
		/// </returns>
		/// <remarks>
		/// <para>Signing is unused by WIC. Therefore, all components WICComponentSigned.</para>
		/// <para>
		/// This function can be used to determine whether a component has no binary component or has been added to the disabled
		/// components list in the registry.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getsigningstatus HRESULT
		// GetSigningStatus( DWORD *pStatus );
		new WICComponentSigning GetSigningStatus();

		/// <summary>Retrieves the name of component's author.</summary>
		/// <param name="cchAuthor">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzAuthor buffer.</para>
		/// </param>
		/// <param name="wzAuthor">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// A pointer that receives the name of the component's author. The locale of the string depends on the value that the codec
		/// wrote to the registry at install time. For built-in components, these strings are always in English.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's authors name. The author name is optional; if an author name is
		/// not specified by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getauthor HRESULT GetAuthor( UINT
		// cchAuthor, WCHAR *wzAuthor, UINT *pcchActual );
		new void GetAuthor(uint cchAuthor, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzAuthor, out uint pcchActual);

		/// <summary>Retrieves the vendor GUID.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>A pointer that receives the component's vendor GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getvendorguid HRESULT
		// GetVendorGUID( GUID *pguidVendor );
		new Guid GetVendorGUID();

		/// <summary>Retrieves the component's version.</summary>
		/// <param name="cchVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzVersion buffer.</para>
		/// </param>
		/// <param name="wzVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>A pointer that receives a culture invariant string of the component's version.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's version. The version is optional; if a value is not specified
		/// by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>All built-in components return "1.0.0.0", except for pixel formats, which do not have a version.</para>
		/// <para>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getversion HRESULT GetVersion( UINT
		// cchVersion, WCHAR *wzVersion, UINT *pcchActual );
		new void GetVersion(uint cchVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzVersion, out uint pcchActual);

		/// <summary>Retrieves the component's specification version.</summary>
		/// <param name="cchSpecVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzSpecVersion buffer.</para>
		/// </param>
		/// <param name="wzSpecVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contain a culture invarient string of the component's specification version. The version form is NN.NN.NN.NN.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's specification version. The specification version is optional;
		/// if a value is not specified by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>All built-in components return "1.0.0.0", except for pixel formats, which do not have a spec version.</para>
		/// <para>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getspecversion HRESULT
		// GetSpecVersion( UINT cchSpecVersion, WCHAR *wzSpecVersion, UINT *pcchActual );
		new void GetSpecVersion(uint cchSpecVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzSpecVersion, out uint pcchActual);

		/// <summary>Retrieves the component's friendly name, which is a human-readable display name for the component.</summary>
		/// <param name="cchFriendlyName">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzFriendlyName buffer.</para>
		/// </param>
		/// <param name="wzFriendlyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// A pointer that receives the friendly name of the component. The locale of the string depends on the value that the codec
		/// wrote to the registry at install time. For built-in components, these strings are always in English.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the actual length of the component's friendly name.</para>
		/// </param>
		/// <remarks>If cchFriendlyName is 0 and wzFriendlyName is <c>NULL</c>, the required buffer size is returned in pccchActual.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getfriendlyname HRESULT
		// GetFriendlyName( UINT cchFriendlyName, WCHAR *wzFriendlyName, UINT *pcchActual );
		new void GetFriendlyName(uint cchFriendlyName, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzFriendlyName, out uint pcchActual);

		/// <summary>Retrieves the container GUID associated with the codec.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Receives the container GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getcontainerformat HRESULT
		// GetContainerFormat( GUID *pguidContainerFormat );
		new Guid GetContainerFormat();

		/// <summary>Retrieves the pixel formats the codec supports.</summary>
		/// <param name="cFormats">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pguidPixelFormats array. Use 0 on first call to determine the needed array size.</para>
		/// </param>
		/// <param name="pguidPixelFormats">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Receives the supported pixel formats. Use <see langword="null"/> on first call to determine needed array size.</para>
		/// </param>
		/// <param name="pcActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The array size needed to retrieve all supported pixel formats.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the array size needed to retrieve all the
		/// supported pixel formats by calling it with cFormats set to 0 and pguidPixelFormats set to <see langword="null"/>. This call
		/// sets pcActual to the array size needed. Once the needed array size is determined, a second <c>GetPixelFormats</c> call with
		/// pguidPixelFormats set to an array of the appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getpixelformats HRESULT
		// GetPixelFormats( UINT cFormats, GUID *pguidPixelFormats, UINT *pcActual );
		new void GetPixelFormats(uint cFormats, Guid[] pguidPixelFormats, out uint pcActual);

		/// <summary>Retrieves the color manangement version number the codec supports.</summary>
		/// <param name="cchColorManagementVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the version buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzColorManagementVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives the color management version number. Use <see langword="null"/> on first call to determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve the full color management version number.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchColorManagementVersion set to 0 and wzColorManagementVersion set
		/// to <see langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a
		/// second <c>GetColorManagementVersion</c> call with cchColorManagementVersion set to the buffer size and
		/// wzColorManagementVersion set to a buffer of the appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getcolormanagementversion HRESULT
		// GetColorManagementVersion( UINT cchColorManagementVersion, WCHAR *wzColorManagementVersion, UINT *pcchActual );
		new void GetColorManagementVersion(uint cchColorManagementVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzColorManagementVersion, out uint pcchActual);

		/// <summary>Retrieves the name of the device manufacture associated with the codec.</summary>
		/// <param name="cchDeviceManufacturer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the device manufacture's name. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzDeviceManufacturer">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Receives the device manufacture's name. Use <see langword="null"/> on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve the device manufacture's name.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchDeviceManufacturer set to 0 and wzDeviceManufacturer set to <see
		/// langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second
		/// <c>GetDeviceManufacturer</c> call with cchDeviceManufacturer set to the buffer size and wzDeviceManufacturer set to a buffer
		/// of the appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getdevicemanufacturer HRESULT
		// GetDeviceManufacturer( UINT cchDeviceManufacturer, WCHAR *wzDeviceManufacturer, UINT *pcchActual );
		new void GetDeviceManufacturer(uint cchDeviceManufacturer, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceManufacturer, out uint pcchActual);

		/// <summary>Retrieves a comma delimited list of device models associated with the codec.</summary>
		/// <param name="cchDeviceModels">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the device models buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzDeviceModels">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives a comma delimited list of device model names associated with the codec. Use <see langword="null"/> on first call to
		/// determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve all of the device model names.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchDeviceModels set to 0 and wzDeviceModels set to <see
		/// langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second
		/// <c>GetDeviceModels</c> call with cchDeviceModels set to the buffer size and wzDeviceModels set to a buffer of the
		/// appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getdevicemodels HRESULT
		// GetDeviceModels( UINT cchDeviceModels, WCHAR *wzDeviceModels, UINT *pcchActual );
		new void GetDeviceModels(uint cchDeviceModels, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceModels, out uint pcchActual);

		/// <summary>Retrieves a comma delimited sequence of mime types associated with the codec.</summary>
		/// <param name="cchMimeTypes">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the mime types buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzMimeTypes">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives the mime types associated with the codec. Use <see langword="null"/> on first call to determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve all mime types associated with the codec.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchMimeTypes set to 0 and wzMimeTypes set to <see langword="null"/>.
		/// This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second <c>GetMimeTypes</c>
		/// call with cchMimeTypes set to the buffer size and wzMimeTypes set to a buffer of the appropriate size will retrieve the
		/// pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getmimetypes HRESULT
		// GetMimeTypes( UINT cchMimeTypes, WCHAR *wzMimeTypes, UINT *pcchActual );
		new void GetMimeTypes(uint cchMimeTypes, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzMimeTypes, out uint pcchActual);

		/// <summary>Retrieves a comma delimited list of the file name extensions associated with the codec.</summary>
		/// <param name="cchFileExtensions">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the file name extension buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzFileExtensions">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives a comma delimited list of file name extensions associated with the codec. Use <see langword="null"/> on first call
		/// to determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve all file name extensions associated with the codec.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>The default extension for an image encoder is the first item in the list of returned extensions.</para>
		/// <para>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchFileExtensions set to 0 and wzFileExtensions set to <see
		/// langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second
		/// <c>GetFileExtensions</c> call with cchFileExtensions set to the buffer size and wzFileExtensions set to a buffer of the
		/// appropriate size will retrieve the pixel formats.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getfileextensions HRESULT
		// GetFileExtensions( UINT cchFileExtensions, WCHAR *wzFileExtensions, UINT *pcchActual );
		new void GetFileExtensions(uint cchFileExtensions, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzFileExtensions, out uint pcchActual);

		/// <summary>Retrieves a value indicating whether the codec supports animation.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports images with timing information; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportanimation HRESULT
		// DoesSupportAnimation( BOOL *pfSupportAnimation );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesSupportAnimation();

		/// <summary>Retrieves a value indicating whether the codec supports chromakeys.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports chromakeys; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportchromakey HRESULT
		// DoesSupportChromakey( BOOL *pfSupportChromakey );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesSupportChromakey();

		/// <summary>Retrieves a value indicating whether the codec supports lossless formats.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports lossless formats; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportlossless HRESULT
		// DoesSupportLossless( BOOL *pfSupportLossless );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesSupportLossless();

		/// <summary>Retrieves a value indicating whether the codec supports multi frame images.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports multi frame images; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportmultiframe HRESULT
		// DoesSupportMultiframe( BOOL *pfSupportMultiframe );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesSupportMultiframe();

		/// <summary>Retrieves a value indicating whether the given mime type matches the mime type of the codec.</summary>
		/// <param name="wzMimeType">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The mime type to compare.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the mime types match; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks><c>Note</c> The Windows provided codecs do not implement this method and return E_NOTIMPL.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-matchesmimetype HRESULT
		// MatchesMimeType( LPCWSTR wzMimeType, BOOL *pfMatches );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool MatchesMimeType([MarshalAs(UnmanagedType.LPWStr)] string wzMimeType);

		/// <summary>Retrieves the file pattern signatures supported by the decoder.</summary>
		/// <param name="cbSizePatterns">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The array size of the pPatterns array.</para>
		/// </param>
		/// <param name="pPatterns">
		/// <para>Type: <c>WICBitmapPattern*</c></para>
		/// <para>Receives a list of <see cref="WICBitmapPattern"/> objects supported by the decoder.</para>
		/// </param>
		/// <param name="pcPatterns">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Receives the number of patterns the decoder supports.</para>
		/// </param>
		/// <param name="pcbPatternsActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Receives the actual buffer size needed to retrieve all pattern signatures supported by the decoder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// To retrieve all pattern signatures, this method should first be called with pPatterns set to to retrieve the actual buffer
		/// size needed through pcbPatternsActual. Once the needed buffer size is known, allocate a buffer of the needed size and call
		/// <c>GetPatterns</c> again with the allocated buffer.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoderinfo-getpatterns HRESULT
		// GetPatterns( UINT cbSizePatterns, WICBitmapPattern *pPatterns, UINT *pcPatterns, UINT *pcbPatternsActual );
		void GetPatterns(uint cbSizePatterns, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] WICBitmapPattern[] pPatterns, [Out, Optional] out uint pcPatterns, [Out] out uint pcbPatternsActual);

		/// <summary>Retrieves a value that indicates whether the codec recognizes the pattern within a specified stream.</summary>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>The stream to pattern match within.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A pointer that receives <c>TRUE</c> if the patterns match; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoderinfo-matchespattern HRESULT
		// MatchesPattern( IStream *pIStream, BOOL *pfMatches );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool MatchesPattern(IStream pIStream);

		/// <summary>Creates a new IWICBitmapDecoder instance.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapDecoder**</c></para>
		/// <para>A pointer that receives a pointer to a new instance of the IWICBitmapDecoder.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapdecoderinfo-createinstance HRESULT
		// CreateInstance( IWICBitmapDecoder **ppIBitmapDecoder );
		IWICBitmapDecoder CreateInstance();
	}

	/// <summary>Defines methods for setting an encoder's properties such as thumbnails, frames, and palettes.</summary>
	/// <remarks>
	/// <para>
	/// There are a number of concrete implemenations of this interface representing each of the standard encoders provided by the
	/// platform including bitmap (BMP), Portable Network Graphics (PNG), Joint Photographic Experts Group (JPEG), Graphics Interchange
	/// Format (GIF), Tagged Image File Format (TIFF), and Microsoft Windows Digital Photo (WDP). The following table includes the class
	/// identifier (CLSID) for each native encoder.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>CLSID Name</term>
	/// <term>CLSID</term>
	/// </listheader>
	/// <item>
	/// <term>CLSID_WICBmpEncoder</term>
	/// <term>0x69be8bb4, 0xd66d, 0x47c8, 0x86, 0x5a, 0xed, 0x15, 0x89, 0x43, 0x37, 0x82</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICGifEncoder</term>
	/// <term>0x114f5598, 0xb22, 0x40a0, 0x86, 0xa1, 0xc8, 0x3e, 0xa4, 0x95, 0xad, 0xbd</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICHeifEncoder</term>
	/// <term>0x0dbecec1, 0x9eb3, 0x4860, 0x9c, 0x6f, 0xdd, 0xbe, 0x86, 0x63, 0x45, 0x75</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICJpegEncoder</term>
	/// <term>0x1a34f5c1, 0x4a5a, 0x46dc, 0xb6, 0x44, 0x1f, 0x45, 0x67, 0xe7, 0xa6, 0x76</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICPngEncoder</term>
	/// <term>0x27949969, 0x876a, 0x41d7, 0x94, 0x47, 0x56, 0x8f, 0x6a, 0x35, 0xa4, 0xdc</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICTiffEncoder</term>
	/// <term>0x0131be10, 0x2001, 0x4c5f, 0xa9, 0xb0, 0xcc, 0x88, 0xfa, 0xb6, 0x4c, 0xe8</term>
	/// </item>
	/// <item>
	/// <term>CLSID_WICWmpEncoder</term>
	/// <term>0xac4ce3cb, 0xe1c1, 0x44cd, 0x82, 0x15, 0x5a, 0x16, 0x65, 0x50, 0x9e, 0xc2</term>
	/// </item>
	/// </list>
	/// <para>
	/// Additionally this interface may be sub-classed to provide support for third party codecs as part of the extensibility model. See
	/// the AITCodec Sample CODEC.
	/// </para>
	/// <para>CLSID_WICHeifDecoder operates on HEIF (High Efficiency Image Format) images.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapencoder
	[PInvokeData("wincodec.h", MSDNShortId = "fe87c9ae-dedf-4ec2-ac11-0ea5fc6aa3ad")]
	[ComImport, Guid("00000103-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapEncoder
	{
		/// <summary>Initializes the encoder with an IStream which tells the encoder where to encode the bits.</summary>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>The output stream.</para>
		/// </param>
		/// <param name="cacheOption">
		/// <para>Type: <c>WICBitmapEncoderCacheOption</c></para>
		/// <para>The WICBitmapEncoderCacheOption used on initialization.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoder-initialize HRESULT Initialize(
		// IStream *pIStream, WICBitmapEncoderCacheOption cacheOption );
		void Initialize(IStream pIStream, WICBitmapEncoderCacheOption cacheOption);

		/// <summary>Retrieves the encoder's container format.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>A pointer that receives the encoder's container format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoder-getcontainerformat HRESULT
		// GetContainerFormat( GUID *pguidContainerFormat );
		Guid GetContainerFormat();

		/// <summary>Retrieves an IWICBitmapEncoderInfo for the encoder.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapEncoderInfo**</c></para>
		/// <para>A pointer that receives a pointer to an IWICBitmapEncoderInfo.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoder-getencoderinfo HRESULT
		// GetEncoderInfo( IWICBitmapEncoderInfo **ppIEncoderInfo );
		IWICBitmapEncoderInfo GetEncoderInfo();

		/// <summary>Sets the IWICColorContext objects for the encoder.</summary>
		/// <param name="cCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of IWICColorContext to set.</para>
		/// </param>
		/// <param name="ppIColorContext">
		/// <para>Type: <c>IWICColorContext**</c></para>
		/// <para>A pointer an IWICColorContext pointer containing the color contexts to set for the encoder.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoder-setcolorcontexts HRESULT
		// SetColorContexts( UINT cCount, IWICColorContext **ppIColorContext );
		void SetColorContexts(uint cCount, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IWICColorContext[] ppIColorContext);

		/// <summary>Sets the global palette for the image.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>The IWICPalette to use as the global palette.</para>
		/// </param>
		/// <remarks>
		/// Only GIF images support an optional global palette, and you must set the global palette before adding any frames to the
		/// image. You only need to set the palette for indexed pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoder-setpalette HRESULT SetPalette(
		// IWICPalette *pIPalette );
		void SetPalette(IWICPalette pIPalette);

		/// <summary>Sets the global thumbnail for the image.</summary>
		/// <param name="pIThumbnail">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The IWICBitmapSource to set as the global thumbnail.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoder-setthumbnail HRESULT SetThumbnail(
		// IWICBitmapSource *pIThumbnail );
		void SetThumbnail(IWICBitmapSource pIThumbnail);

		/// <summary>Sets the global preview for the image.</summary>
		/// <param name="pIPreview">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The IWICBitmapSource to use as the global preview.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoder-setpreview HRESULT SetPreview(
		// IWICBitmapSource *pIPreview );
		void SetPreview(IWICBitmapSource pIPreview);

		/// <summary>Creates a new IWICBitmapFrameEncode instance.</summary>
		/// <param name="ppIFrameEncode">
		/// <para>Type: <c>IWICBitmapFrameEncode**</c></para>
		/// <para>A pointer that receives a pointer to the new instance of an IWICBitmapFrameEncode.</para>
		/// </param>
		/// <param name="ppIEncoderOptions">
		/// <para>Type: <c>IPropertyBag2**</c></para>
		/// <para>Optional. Receives the named properties to use for subsequent frame initialization. See Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The parameter ppIEncoderOptions can be used to receive an IPropertyBag2 that can then be used to specify encoder options.
		/// This is done by passing a pointer to a <c>NULL</c> IPropertyBag2 pointer in ppIEncoderOptions. The returned IPropertyBag2 is
		/// initialized with all encoder options that are available for the given format, at their default values. To specify
		/// non-default encoding behavior, set the needed encoder options on the IPropertyBag2 and pass it to IWICBitmapFrameEncode::Initialize.
		/// </para>
		/// <para>
		/// <c>Note</c> Do not pass in a pointer to an initialized IPropertyBag2. The pointer will be overwritten, and the original
		/// IPropertyBag2 will not be freed.
		/// </para>
		/// <para>Otherwise, you can pass <c>NULL</c> in ppIEncoderOptions if you do not intend to specify encoder options.</para>
		/// <para>See Encoding Overview for an example of how to set encoder options.</para>
		/// <para>
		/// For formats that support encoding multiple frames (for example, TIFF, JPEG-XR), you can work on only one frame at a time.
		/// This means that you must call IWICBitmapFrameEncode::Commit before you call <c>CreateNewFrame</c> again.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoder-createnewframe HRESULT
		// CreateNewFrame( IWICBitmapFrameEncode **ppIFrameEncode, IPropertyBag2 **ppIEncoderOptions );
		void CreateNewFrame(out IWICBitmapFrameEncode ppIFrameEncode, out IPropertyBag2 ppIEncoderOptions);

		/// <summary>Commits all changes for the image and closes the stream.</summary>
		/// <remarks>
		/// <para>
		/// To finalize an image, both the frame Commit and the encoder <c>Commit</c> must be called. However, only call the encoder
		/// <c>Commit</c> method after all frames have been committed.
		/// </para>
		/// <para>
		/// After the encoder has been committed, it can't be re-initialized or reused with another stream. A new encoder interface must
		/// be created, for example, with IWICImagingFactory::CreateEncoder.
		/// </para>
		/// <para>
		/// For the encoder <c>Commit</c> to succeed, you must at a minimum call IWICBitmapEncoder::Initialize and either
		/// IWICBitmapFrameEncode::WriteSource or IWICBitmapFrameEncode::WritePixels.
		/// </para>
		/// <para>
		/// IWICBitmapFrameEncode::WriteSource specifies all parameters needed to encode the image data.
		/// IWICBitmapFrameEncode::WritePixels requires that you also call IWICBitmapFrameEncode::SetSize,
		/// IWICBitmapFrameEncode::SetPixelFormat, and IWICBitmapFrameEncode::SetPalette (if the pixel format is indexed).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoder-commit HRESULT Commit();
		void Commit();

		/// <summary>Retrieves a metadata query writer for the encoder.</summary>
		/// <returns>
		/// <para>Type: <c>IWICMetadataQueryWriter**</c></para>
		/// <para>When this method returns, contains a pointer to the encoder's metadata query writer.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoder-getmetadataquerywriter HRESULT
		// GetMetadataQueryWriter( IWICMetadataQueryWriter **ppIMetadataQueryWriter );
		IWICMetadataQueryWriter GetMetadataQueryWriter();
	}

	/// <summary>Exposes methods that provide information about an encoder.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapencoderinfo
	[PInvokeData("wincodec.h", MSDNShortId = "152b0dd2-1e5e-47fc-b6eb-a4c042e65047")]
	[ComImport, Guid("94C9B4EE-A09F-4f92-8A1E-4A9BCE7E76FB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapEncoderInfo : IWICBitmapCodecInfo
	{
		/// <summary>Retrieves the component's WICComponentType.</summary>
		/// <returns>
		/// <para>Type: <c>WICComponentType*</c></para>
		/// <para>A pointer that receives the WICComponentType.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getcomponenttype HRESULT
		// GetComponentType( WICComponentType *pType );
		new WICComponentType GetComponentType();

		/// <summary>Retrieves the component's class identifier (CLSID)</summary>
		/// <returns>
		/// <para>Type: <c>CLSID*</c></para>
		/// <para>A pointer that receives the component's CLSID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getclsid HRESULT GetCLSID( CLSID
		// *pclsid );
		new Guid GetCLSID();

		/// <summary>Retrieves the signing status of the component.</summary>
		/// <returns>
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer that receives the WICComponentSigning status of the component.</para>
		/// </returns>
		/// <remarks>
		/// <para>Signing is unused by WIC. Therefore, all components WICComponentSigned.</para>
		/// <para>
		/// This function can be used to determine whether a component has no binary component or has been added to the disabled
		/// components list in the registry.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getsigningstatus HRESULT
		// GetSigningStatus( DWORD *pStatus );
		new WICComponentSigning GetSigningStatus();

		/// <summary>Retrieves the name of component's author.</summary>
		/// <param name="cchAuthor">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzAuthor buffer.</para>
		/// </param>
		/// <param name="wzAuthor">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// A pointer that receives the name of the component's author. The locale of the string depends on the value that the codec
		/// wrote to the registry at install time. For built-in components, these strings are always in English.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's authors name. The author name is optional; if an author name is
		/// not specified by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getauthor HRESULT GetAuthor( UINT
		// cchAuthor, WCHAR *wzAuthor, UINT *pcchActual );
		new void GetAuthor(uint cchAuthor, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzAuthor, out uint pcchActual);

		/// <summary>Retrieves the vendor GUID.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>A pointer that receives the component's vendor GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getvendorguid HRESULT
		// GetVendorGUID( GUID *pguidVendor );
		new Guid GetVendorGUID();

		/// <summary>Retrieves the component's version.</summary>
		/// <param name="cchVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzVersion buffer.</para>
		/// </param>
		/// <param name="wzVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>A pointer that receives a culture invariant string of the component's version.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's version. The version is optional; if a value is not specified
		/// by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>All built-in components return "1.0.0.0", except for pixel formats, which do not have a version.</para>
		/// <para>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getversion HRESULT GetVersion( UINT
		// cchVersion, WCHAR *wzVersion, UINT *pcchActual );
		new void GetVersion(uint cchVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzVersion, out uint pcchActual);

		/// <summary>Retrieves the component's specification version.</summary>
		/// <param name="cchSpecVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzSpecVersion buffer.</para>
		/// </param>
		/// <param name="wzSpecVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contain a culture invarient string of the component's specification version. The version form is NN.NN.NN.NN.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's specification version. The specification version is optional;
		/// if a value is not specified by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>All built-in components return "1.0.0.0", except for pixel formats, which do not have a spec version.</para>
		/// <para>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getspecversion HRESULT
		// GetSpecVersion( UINT cchSpecVersion, WCHAR *wzSpecVersion, UINT *pcchActual );
		new void GetSpecVersion(uint cchSpecVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzSpecVersion, out uint pcchActual);

		/// <summary>Retrieves the component's friendly name, which is a human-readable display name for the component.</summary>
		/// <param name="cchFriendlyName">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzFriendlyName buffer.</para>
		/// </param>
		/// <param name="wzFriendlyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// A pointer that receives the friendly name of the component. The locale of the string depends on the value that the codec
		/// wrote to the registry at install time. For built-in components, these strings are always in English.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the actual length of the component's friendly name.</para>
		/// </param>
		/// <remarks>If cchFriendlyName is 0 and wzFriendlyName is <c>NULL</c>, the required buffer size is returned in pccchActual.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getfriendlyname HRESULT
		// GetFriendlyName( UINT cchFriendlyName, WCHAR *wzFriendlyName, UINT *pcchActual );
		new void GetFriendlyName(uint cchFriendlyName, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzFriendlyName, out uint pcchActual);

		/// <summary>Retrieves the container GUID associated with the codec.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Receives the container GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getcontainerformat HRESULT
		// GetContainerFormat( GUID *pguidContainerFormat );
		new Guid GetContainerFormat();

		/// <summary>Retrieves the pixel formats the codec supports.</summary>
		/// <param name="cFormats">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pguidPixelFormats array. Use 0 on first call to determine the needed array size.</para>
		/// </param>
		/// <param name="pguidPixelFormats">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Receives the supported pixel formats. Use <see langword="null"/> on first call to determine needed array size.</para>
		/// </param>
		/// <param name="pcActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The array size needed to retrieve all supported pixel formats.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the array size needed to retrieve all the
		/// supported pixel formats by calling it with cFormats set to 0 and pguidPixelFormats set to <see langword="null"/>. This call
		/// sets pcActual to the array size needed. Once the needed array size is determined, a second <c>GetPixelFormats</c> call with
		/// pguidPixelFormats set to an array of the appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getpixelformats HRESULT
		// GetPixelFormats( UINT cFormats, GUID *pguidPixelFormats, UINT *pcActual );
		new void GetPixelFormats(uint cFormats, Guid[] pguidPixelFormats, out uint pcActual);

		/// <summary>Retrieves the color manangement version number the codec supports.</summary>
		/// <param name="cchColorManagementVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the version buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzColorManagementVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives the color management version number. Use <see langword="null"/> on first call to determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve the full color management version number.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchColorManagementVersion set to 0 and wzColorManagementVersion set
		/// to <see langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a
		/// second <c>GetColorManagementVersion</c> call with cchColorManagementVersion set to the buffer size and
		/// wzColorManagementVersion set to a buffer of the appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getcolormanagementversion HRESULT
		// GetColorManagementVersion( UINT cchColorManagementVersion, WCHAR *wzColorManagementVersion, UINT *pcchActual );
		new void GetColorManagementVersion(uint cchColorManagementVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzColorManagementVersion, out uint pcchActual);

		/// <summary>Retrieves the name of the device manufacture associated with the codec.</summary>
		/// <param name="cchDeviceManufacturer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the device manufacture's name. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzDeviceManufacturer">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Receives the device manufacture's name. Use <see langword="null"/> on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve the device manufacture's name.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchDeviceManufacturer set to 0 and wzDeviceManufacturer set to <see
		/// langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second
		/// <c>GetDeviceManufacturer</c> call with cchDeviceManufacturer set to the buffer size and wzDeviceManufacturer set to a buffer
		/// of the appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getdevicemanufacturer HRESULT
		// GetDeviceManufacturer( UINT cchDeviceManufacturer, WCHAR *wzDeviceManufacturer, UINT *pcchActual );
		new void GetDeviceManufacturer(uint cchDeviceManufacturer, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceManufacturer, out uint pcchActual);

		/// <summary>Retrieves a comma delimited list of device models associated with the codec.</summary>
		/// <param name="cchDeviceModels">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the device models buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzDeviceModels">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives a comma delimited list of device model names associated with the codec. Use <see langword="null"/> on first call to
		/// determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve all of the device model names.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchDeviceModels set to 0 and wzDeviceModels set to <see
		/// langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second
		/// <c>GetDeviceModels</c> call with cchDeviceModels set to the buffer size and wzDeviceModels set to a buffer of the
		/// appropriate size will retrieve the pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getdevicemodels HRESULT
		// GetDeviceModels( UINT cchDeviceModels, WCHAR *wzDeviceModels, UINT *pcchActual );
		new void GetDeviceModels(uint cchDeviceModels, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceModels, out uint pcchActual);

		/// <summary>Retrieves a comma delimited sequence of mime types associated with the codec.</summary>
		/// <param name="cchMimeTypes">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the mime types buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzMimeTypes">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives the mime types associated with the codec. Use <see langword="null"/> on first call to determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve all mime types associated with the codec.</para>
		/// </param>
		/// <remarks>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchMimeTypes set to 0 and wzMimeTypes set to <see langword="null"/>.
		/// This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second <c>GetMimeTypes</c>
		/// call with cchMimeTypes set to the buffer size and wzMimeTypes set to a buffer of the appropriate size will retrieve the
		/// pixel formats.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getmimetypes HRESULT
		// GetMimeTypes( UINT cchMimeTypes, WCHAR *wzMimeTypes, UINT *pcchActual );
		new void GetMimeTypes(uint cchMimeTypes, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzMimeTypes, out uint pcchActual);

		/// <summary>Retrieves a comma delimited list of the file name extensions associated with the codec.</summary>
		/// <param name="cchFileExtensions">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the file name extension buffer. Use 0 on first call to determine needed buffer size.</para>
		/// </param>
		/// <param name="wzFileExtensions">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// Receives a comma delimited list of file name extensions associated with the codec. Use <see langword="null"/> on first call
		/// to determine needed buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to retrieve all file name extensions associated with the codec.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>The default extension for an image encoder is the first item in the list of returned extensions.</para>
		/// <para>
		/// The usage pattern for this method is a two call process. The first call retrieves the buffer size needed to retrieve the
		/// full color management version number by calling it with cchFileExtensions set to 0 and wzFileExtensions set to <see
		/// langword="null"/>. This call sets pcchActual to the buffer size needed. Once the needed buffer size is determined, a second
		/// <c>GetFileExtensions</c> call with cchFileExtensions set to the buffer size and wzFileExtensions set to a buffer of the
		/// appropriate size will retrieve the pixel formats.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-getfileextensions HRESULT
		// GetFileExtensions( UINT cchFileExtensions, WCHAR *wzFileExtensions, UINT *pcchActual );
		new void GetFileExtensions(uint cchFileExtensions, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzFileExtensions, out uint pcchActual);

		/// <summary>Retrieves a value indicating whether the codec supports animation.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports images with timing information; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportanimation HRESULT
		// DoesSupportAnimation( BOOL *pfSupportAnimation );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesSupportAnimation();

		/// <summary>Retrieves a value indicating whether the codec supports chromakeys.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports chromakeys; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportchromakey HRESULT
		// DoesSupportChromakey( BOOL *pfSupportChromakey );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesSupportChromakey();

		/// <summary>Retrieves a value indicating whether the codec supports lossless formats.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports lossless formats; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportlossless HRESULT
		// DoesSupportLossless( BOOL *pfSupportLossless );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesSupportLossless();

		/// <summary>Retrieves a value indicating whether the codec supports multi frame images.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the codec supports multi frame images; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-doessupportmultiframe HRESULT
		// DoesSupportMultiframe( BOOL *pfSupportMultiframe );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesSupportMultiframe();

		/// <summary>Retrieves a value indicating whether the given mime type matches the mime type of the codec.</summary>
		/// <param name="wzMimeType">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The mime type to compare.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Receives <c>TRUE</c> if the mime types match; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks><c>Note</c> The Windows provided codecs do not implement this method and return E_NOTIMPL.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapcodecinfo-matchesmimetype HRESULT
		// MatchesMimeType( LPCWSTR wzMimeType, BOOL *pfMatches );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool MatchesMimeType([MarshalAs(UnmanagedType.LPWStr)] string wzMimeType);

		/// <summary>Creates a new IWICBitmapEncoder instance.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapEncoder**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapEncoder instance.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapencoderinfo-createinstance HRESULT
		// CreateInstance( IWICBitmapEncoder **ppIBitmapEncoder );
		IWICBitmapEncoder CreateInstance();
	}

	/// <summary>
	/// Exposes methods that produce a flipped (horizontal or vertical) and/or rotated (by 90 degree increments) bitmap source. The flip
	/// is done before the rotation.
	/// </summary>
	/// <remarks>
	/// IWICBitmapFipRotator requests data on a per-pixel basis, while WIC codecs provide data on a per-scanline basis. This causes the
	/// fliprotator object to exhibit n² behavior if there is no buffering. This occurs because each pixel in the transformed image
	/// requires an entire scanline to be decoded in the file. It is recommended that you buffer the image using IWICBitmap, or
	/// flip/rotate the image using Direct2D.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapfliprotator
	[PInvokeData("wincodec.h", MSDNShortId = "1fcb19ba-34bd-48c0-9964-0c973c31cacc")]
	[ComImport, Guid("5009834F-2D6A-41ce-9E1B-17C5AFF7A782"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapFlipRotator : IWICBitmapSource
	{
		/// <summary>Retrieves the pixel width and height of the bitmap.</summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel width of the bitmap.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel height of the bitmap</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getsize HRESULT GetSize( UINT
		// *puiWidth, UINT *puiHeight );
		new void GetSize(out uint puiWidth, out uint puiHeight);

		/// <summary>Retrieves the pixel format of the bitmap source..</summary>
		/// <returns>
		/// Receives the pixel format GUID the bitmap is stored in. For a list of available pixel formats, see the Native Pixel Formats topic.
		/// </returns>
		/// <remarks>
		/// The pixel format returned by this method is not necessarily the pixel format the image is stored as. The codec may perform a
		/// format conversion from the storage pixel format to an output pixel format.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getpixelformat HRESULT
		// GetPixelFormat( Guid *pPixelFormat );
		new Guid GetPixelFormat();

		/// <summary>Retrieves the sampling rate between pixels and physical world measurements.</summary>
		/// <param name="pDpiX">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the x-axis dpi resolution.</para>
		/// </param>
		/// <param name="pDpiY">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the y-axis dpi resolution.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Some formats, such as GIF and ICO, do not have full DPI support. For GIF, this method calculates the DPI values from the
		/// aspect ratio, using a base DPI of (96.0, 96.0). The ICO format does not support DPI at all, and the method always returns
		/// (96.0,96.0) for ICO images.
		/// </para>
		/// <para>
		/// Additionally, WIC itself does not transform images based on the DPI values in an image. It is up to the caller to transform
		/// an image based on the resolution returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getresolution HRESULT GetResolution(
		// double *pDpiX, double *pDpiY );
		new void GetResolution(out double pDpiX, out double pDpiY);

		/// <summary>Retrieves the color table for indexed pixel formats.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>An IWICPalette. A palette can be created using the CreatePalette method.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WINCODEC_ERR_PALETTEUNAVAILABLE</term>
		/// <term>The palette was unavailable.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The palette was successfully copied.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the IWICBitmapSource is an IWICBitmapFrameDecode, the function may return the image's global palette if a frame-level
		/// palette is not available. The global palette may also be retrieved using the CopyPalette method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypalette HRESULT CopyPalette(
		// IWICPalette *pIPalette );
		[PreserveSig]
		new HRESULT CopyPalette(IWICPalette pIPalette);

		/// <summary>Instructs the object to produce pixels.</summary>
		/// <param name="prc">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle to copy. A <c>NULL</c> value specifies the entire bitmap.</para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride of the bitmap</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CopyPixels</c> is one of the two main image processing routines (the other being Lock) triggering the actual processing.
		/// It instructs the object to produce pixels according to its algorithm - this may involve decoding a portion of a JPEG stored
		/// on disk, copying a block of memory, or even analytically computing a complex gradient. The algorithm is completely dependent
		/// on the object implementing the interface.
		/// </para>
		/// <para>
		/// The caller can restrict the operation to a rectangle of interest (ROI) using the prc parameter. The ROI sub-rectangle must
		/// be fully contained in the bounds of the bitmap. Specifying a <c>NULL</c> ROI implies that the whole bitmap should be returned.
		/// </para>
		/// <para>
		/// The caller controls the memory management and must provide an output buffer (pbBuffer) for the results of the copy along
		/// with the buffer's bounds (cbBufferSize). The cbStride parameter defines the count of bytes between two vertically adjacent
		/// pixels in the output buffer. The caller must ensure that there is sufficient buffer to complete the call based on the width,
		/// height and pixel format of the bitmap and the sub-rectangle provided to the copy method.
		/// </para>
		/// <para>
		/// If the caller needs to perform numerous copies of an expensive IWICBitmapSource such as a JPEG, it is recommended to create
		/// an in-memory IWICBitmap first.
		/// </para>
		/// <para>Codec Developer Remarks</para>
		/// <para>
		/// The callee must only write to the first (prc-&gt;Width*bitsperpixel+7)/8 bytes of each line of the output buffer (in this
		/// case, a line is a consecutive string of cbStride bytes).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypixels HRESULT CopyPixels( const
		// WICRect *prc, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer );
		new void CopyPixels([In, Optional] PWICRect? prc, uint cbStride, uint cbBufferSize, [In, Out] IntPtr pbBuffer);

		/// <summary>Initializes the bitmap flip rotator with the provided parameters.</summary>
		/// <param name="pISource">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The input bitmap source.</para>
		/// </param>
		/// <param name="options">
		/// <para>Type: <c>WICBitmapTransformOptions</c></para>
		/// <para>The WICBitmapTransformOptions to flip or rotate the image.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapfliprotator-initialize HRESULT Initialize(
		// IWICBitmapSource *pISource, WICBitmapTransformOptions options );
		void Initialize(IWICBitmapSource pISource, WICBitmapTransformOptions options);
	}

	/// <summary>Defines methods for decoding individual image frames of an encoded file.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapframedecode
	[PInvokeData("wincodec.h", MSDNShortId = "1498b800-6449-440f-bed7-85891637e559")]
	[ComImport, Guid("3B16811B-6A43-4ec9-A813-3D930C13B940"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapFrameDecode : IWICBitmapSource
	{
		/// <summary>Retrieves the pixel width and height of the bitmap.</summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel width of the bitmap.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel height of the bitmap</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getsize HRESULT GetSize( UINT
		// *puiWidth, UINT *puiHeight );
		new void GetSize(out uint puiWidth, out uint puiHeight);

		/// <summary>Retrieves the pixel format of the bitmap source..</summary>
		/// <returns>
		/// Receives the pixel format GUID the bitmap is stored in. For a list of available pixel formats, see the Native Pixel Formats topic.
		/// </returns>
		/// <remarks>
		/// The pixel format returned by this method is not necessarily the pixel format the image is stored as. The codec may perform a
		/// format conversion from the storage pixel format to an output pixel format.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getpixelformat HRESULT
		// GetPixelFormat( Guid *pPixelFormat );
		new Guid GetPixelFormat();

		/// <summary>Retrieves the sampling rate between pixels and physical world measurements.</summary>
		/// <param name="pDpiX">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the x-axis dpi resolution.</para>
		/// </param>
		/// <param name="pDpiY">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the y-axis dpi resolution.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Some formats, such as GIF and ICO, do not have full DPI support. For GIF, this method calculates the DPI values from the
		/// aspect ratio, using a base DPI of (96.0, 96.0). The ICO format does not support DPI at all, and the method always returns
		/// (96.0,96.0) for ICO images.
		/// </para>
		/// <para>
		/// Additionally, WIC itself does not transform images based on the DPI values in an image. It is up to the caller to transform
		/// an image based on the resolution returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getresolution HRESULT GetResolution(
		// double *pDpiX, double *pDpiY );
		new void GetResolution(out double pDpiX, out double pDpiY);

		/// <summary>Retrieves the color table for indexed pixel formats.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>An IWICPalette. A palette can be created using the CreatePalette method.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WINCODEC_ERR_PALETTEUNAVAILABLE</term>
		/// <term>The palette was unavailable.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The palette was successfully copied.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the IWICBitmapSource is an IWICBitmapFrameDecode, the function may return the image's global palette if a frame-level
		/// palette is not available. The global palette may also be retrieved using the CopyPalette method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypalette HRESULT CopyPalette(
		// IWICPalette *pIPalette );
		[PreserveSig]
		new HRESULT CopyPalette(IWICPalette pIPalette);

		/// <summary>Instructs the object to produce pixels.</summary>
		/// <param name="prc">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle to copy. A <c>NULL</c> value specifies the entire bitmap.</para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride of the bitmap</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CopyPixels</c> is one of the two main image processing routines (the other being Lock) triggering the actual processing.
		/// It instructs the object to produce pixels according to its algorithm - this may involve decoding a portion of a JPEG stored
		/// on disk, copying a block of memory, or even analytically computing a complex gradient. The algorithm is completely dependent
		/// on the object implementing the interface.
		/// </para>
		/// <para>
		/// The caller can restrict the operation to a rectangle of interest (ROI) using the prc parameter. The ROI sub-rectangle must
		/// be fully contained in the bounds of the bitmap. Specifying a <c>NULL</c> ROI implies that the whole bitmap should be returned.
		/// </para>
		/// <para>
		/// The caller controls the memory management and must provide an output buffer (pbBuffer) for the results of the copy along
		/// with the buffer's bounds (cbBufferSize). The cbStride parameter defines the count of bytes between two vertically adjacent
		/// pixels in the output buffer. The caller must ensure that there is sufficient buffer to complete the call based on the width,
		/// height and pixel format of the bitmap and the sub-rectangle provided to the copy method.
		/// </para>
		/// <para>
		/// If the caller needs to perform numerous copies of an expensive IWICBitmapSource such as a JPEG, it is recommended to create
		/// an in-memory IWICBitmap first.
		/// </para>
		/// <para>Codec Developer Remarks</para>
		/// <para>
		/// The callee must only write to the first (prc-&gt;Width*bitsperpixel+7)/8 bytes of each line of the output buffer (in this
		/// case, a line is a consecutive string of cbStride bytes).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypixels HRESULT CopyPixels( const
		// WICRect *prc, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer );
		new void CopyPixels([In, Optional] PWICRect? prc, uint cbStride, uint cbBufferSize, [In, Out] IntPtr pbBuffer);

		/// <summary>Retrieves a metadata query reader for the frame.</summary>
		/// <returns>
		/// <para>Type: <c>IWICMetadataQueryReader**</c></para>
		/// <para>When this method returns, contains a pointer to the frame's metadata query reader.</para>
		/// </returns>
		/// <remarks>
		/// For image formats with one frame (JPG, PNG, JPEG-XR), the frame-level query reader of the first frame is used to access all
		/// image metadata, and the decoder-level query reader isn’t used. For formats with more than one frame (GIF, TIFF), the
		/// frame-level query reader for a given frame is used to access metadata specific to that frame, and in the case of GIF a
		/// decoder-level metadata reader will be present. If the decoder doesn’t support metadata (BMP, ICO), this will return WINCODEC_ERR_UNSUPPORTEDOPERATION.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframedecode-getmetadataqueryreader HRESULT
		// GetMetadataQueryReader( IWICMetadataQueryReader **ppIMetadataQueryReader );
		IWICMetadataQueryReader GetMetadataQueryReader();

		/// <summary>Retrieves the IWICColorContext associated with the image frame.</summary>
		/// <param name="cCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of color contexts to retrieve.</para>
		/// <para>This value must be the size of, or smaller than, the size available to ppIColorContexts.</para>
		/// </param>
		/// <param name="ppIColorContexts">
		/// <para>Type: <c>IWICColorContext**</c></para>
		/// <para>A pointer that receives a pointer to the IWICColorContext objects.</para>
		/// </param>
		/// <param name="pcActualCount">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the number of color contexts contained in the image frame.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If NULL is passed for ppIColorContexts, and 0 is passed for cCount, this method will return the total number of color
		/// contexts in the image in pcActualCount.
		/// </para>
		/// <para>
		/// The ppIColorContexts array must be filled with valid data: each IWICColorContext* in the array must have been created using IWICImagingFactory::CreateColorContext.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframedecode-getcolorcontexts HRESULT
		// GetColorContexts( UINT cCount, IWICColorContext **ppIColorContexts, UINT *pcActualCount );
		void GetColorContexts(uint cCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IWICColorContext[] ppIColorContexts, out uint pcActualCount);

		/// <summary>Retrieves a small preview of the frame, if supported by the codec.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapSource**</c></para>
		/// <para>A pointer that receives a pointer to the IWICBitmapSource of the thumbnail.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Not all formats support thumbnails. Joint Photographic Experts Group (JPEG), Tagged Image File Format (TIFF), and Microsoft
		/// Windows Digital Photo (WDP) support thumbnails.
		/// </para>
		/// <para>Note to Implementers</para>
		/// <para>If the codec does not support thumbnails, return WINCODEC_ERROR_CODECNOTHUMBNAIL rather than E_NOTIMPL.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframedecode-getthumbnail HRESULT
		// GetThumbnail( IWICBitmapSource **ppIThumbnail );
		IWICBitmapSource GetThumbnail();
	}

	/// <summary>Represents an encoder's individual image frames.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapframeencode
	[PInvokeData("wincodec.h", MSDNShortId = "a8de774b-3783-46be-9a21-c9fec2f10ffd")]
	[ComImport, Guid("00000105-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapFrameEncode
	{
		/// <summary>Initializes the frame encoder using the given properties.</summary>
		/// <param name="pIEncoderOptions">
		/// <para>Type: <c>IPropertyBag2*</c></para>
		/// <para>The set of properties to use for IWICBitmapFrameEncode initialization.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you don't want any encoding options, pass <c>NULL</c> for pIEncoderOptions. Otherwise, pass the IPropertyBag2 that was
		/// provided by IWICBitmapEncoder::CreateNewFrame with updated values.
		/// </para>
		/// <para>For a complete list of encoding options supported by the Windows-provided codecs, see Native WIC Codecs.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-initialize HRESULT Initialize(
		// IPropertyBag2 *pIEncoderOptions );
		void Initialize(IPropertyBag2 pIEncoderOptions);

		/// <summary>Sets the output image dimensions for the frame.</summary>
		/// <param name="uiWidth">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of the output image.</para>
		/// </param>
		/// <param name="uiHeight">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height of the output image.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-setsize HRESULT SetSize( UINT
		// uiWidth, UINT uiHeight );
		void SetSize(uint uiWidth, uint uiHeight);

		/// <summary>Sets the physical resolution of the output image.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>double</c></para>
		/// <para>The horizontal resolution value.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>double</c></para>
		/// <para>The vertical resolution value.</para>
		/// </param>
		/// <remarks>
		/// Windows Imaging Component (WIC) doesn't perform any special processing as a result of DPI resolution values. For example,
		/// data returned from IWICBitmapSource::CopyPixels isn't scaled by the DPI. The app must handle DPI resolution.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-setresolution HRESULT
		// SetResolution( double dpiX, double dpiY );
		void SetResolution(double dpiX, double dpiY);

		/// <summary>Requests that the encoder use the specified pixel format.</summary>
		/// <param name="pPixelFormat">
		/// <para>Type: <c>WICPixelFormatGUID*</c></para>
		/// <para>
		/// On input, the requested pixel format GUID. On output, the closest pixel format GUID supported by the encoder; this may be
		/// different than the requested format. For a list of pixel format GUIDs, see Native Pixel Formats.
		/// </para>
		/// </param>
		/// <remarks>
		/// The encoder might not support the requested pixel format. If not, <c>SetPixelFormat</c> returns the closest match in the
		/// memory block that pPixelFormat points to. If the returned pixel format doesn't match the requested format, you must use an
		/// IWICFormatConverter object to convert the pixel data.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-setpixelformat HRESULT
		// SetPixelFormat( WICPixelFormatGUID *pPixelFormat );
		void SetPixelFormat(ref Guid pPixelFormat);

		/// <summary>Sets a given number IWICColorContext profiles to the frame.</summary>
		/// <param name="cCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of IWICColorContext profiles to set.</para>
		/// </param>
		/// <param name="ppIColorContext">
		/// <para>Type: <c>IWICColorContext**</c></para>
		/// <para>A pointer to an IWICColorContext pointer containing the color contexts profiles to set to the frame.</para>
		/// </param>
		/// <remarks>
		/// <list type="bullet">
		/// <item>
		/// <term><c>BMP</c> Setting color contexts is unsupported. This function will return <c>WINCODEC_ERR_UNSUPPORTEDOPERATION</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>PNG</c> Setting at most one color context is supported, and additional color contexts will be ignored. This context must
		/// be a WICColorContextProfile, and is used to encode the iCCP, gAMA, and cHRM chunks in the PNG file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>JPEG, TIFF, JPEG-XR</c> Setting up to one WICColorContextProfile and one WICColorContextExifColorSpace is supported.
		/// Users must not provide more than one of each type of color context, as all but the last context of each type will be
		/// ignored. In JPEG, the <c>WICColorContextProfile</c> is encoded to JPEG APP2 ICC metadata block.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-setcolorcontexts HRESULT
		// SetColorContexts( UINT cCount, IWICColorContext **ppIColorContext );
		void SetColorContexts(uint cCount, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IWICColorContext[] ppIColorContext);

		/// <summary>Sets the IWICPalette for indexed pixel formats.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>The IWICPalette to use for indexed pixel formats.</para>
		/// <para>The encoder may change the palette to reflect the pixel formats the encoder supports.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method doesn't fail if called on a frame whose pixel format is set to a non-indexed pixel format. If the target pixel
		/// format is a non-indexed format, the palette will be ignored.
		/// </para>
		/// <para>
		/// If you already called IWICBitmapEncoder::SetPalette to set a global palette, this method overrides that palette for the
		/// current frame.
		/// </para>
		/// <para>
		/// The palette must be specified before your first call to WritePixels/WriteSource. Doing so will cause <c>WriteSource</c> to
		/// use the specified palette when converting the source image to the encoder pixel format. If no palette is specified, a
		/// palette will be generated on the first call to <c>WriteSource</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-setpalette HRESULT SetPalette(
		// IWICPalette *pIPalette );
		void SetPalette([Optional] IWICPalette? pIPalette);

		/// <summary>Sets the frame thumbnail if supported by the codec.</summary>
		/// <param name="pIThumbnail">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The bitmap source to use as the thumbnail.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// We recommend that you call <c>SetThumbnail</c> before calling WritePixels or WriteSource. The thumbnail won't be added to
		/// the encoded file if <c>SetThumbnail</c> is called after a call to <c>WritePixels</c> or <c>WriteSource</c>.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>BMP, PNG</c> Setting thumbnails is unsupported. This function will return <c>WINCODEC_ERR_UNSUPPORTEDOPERATION</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>JPEG</c> Setting the thumbnail is supported. The source image will be re-encoded as either an 8bpp or 24bpp JPEG and will
		/// be written to the JPEG’s APP1 metadata block.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>TIFF</c> Setting the thumbnail is supported. The source image will be re-encoded as a TIFF and will be written to the
		/// frame’s SubIFD block.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>JPEG-XR</c> Setting the thumbnail is supported. The source image will be re-encoded as an additional 8bpp or 24bpp frame.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-setthumbnail HRESULT
		// SetThumbnail( IWICBitmapSource *pIThumbnail );
		void SetThumbnail([Optional] IWICBitmapSource? pIThumbnail);

		/// <summary>Copies scan-line data from a caller-supplied buffer to the IWICBitmapFrameEncode object.</summary>
		/// <param name="lineCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of lines to encode.</para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride of the image pixels.</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pixel buffer.</para>
		/// </param>
		/// <param name="pbPixels">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the pixel buffer.</para>
		/// </param>
		/// <remarks>Successive <c>WritePixels</c> calls are assumed to be sequential scan-line access in the output image.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-writepixels HRESULT
		// WritePixels( UINT lineCount, UINT cbStride, UINT cbBufferSize, BYTE *pbPixels );
		void WritePixels(uint lineCount, uint cbStride, uint cbBufferSize, [In] IntPtr pbPixels);

		/// <summary>Encodes a bitmap source.</summary>
		/// <param name="pIBitmapSource">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The bitmap source to encode.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>WICRect*</c></para>
		/// <para>The size rectangle of the bitmap source.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If SetSize is not called prior to calling <c>WriteSource</c>, the size given in prc is used if not <c>NULL</c>. Otherwise,
		/// the size of the IWICBitmapSource given in pIBitmapSource is used.
		/// </para>
		/// <para>
		/// If SetPixelFormat is not called prior to calling <c>WriteSource</c>, the pixel format of the IWICBitmapSource given in
		/// pIBitmapSource is used.
		/// </para>
		/// <para>If SetResolution is not called prior to calling <c>WriteSource</c>, the pixel format of pIBitmapSource is used.</para>
		/// <para>
		/// If SetPalette is not called prior to calling <c>WriteSource</c>, the target pixel format is indexed, and the pixel format of
		/// pIBitmapSource matches the encoder frame's pixel format, then the pIBitmapSource pixel format is used.
		/// </para>
		/// <para>
		/// When encoding a GIF image, if the global palette is set and the frame level palette is not set directly by the user or by a
		/// custom independent software vendor (ISV) GIF codec, <c>WriteSource</c> will use the global palette to encode the frame even
		/// when pIBitmapSource has a frame level palette.
		/// </para>
		/// <para>
		/// Starting with Windows Vista, repeated <c>WriteSource</c> calls can be made as long as the total accumulated source rect
		/// height is the same as set through SetSize.
		/// </para>
		/// <para>
		/// Starting with Windows 8.1, the source rect must be at least the dimensions set through SetSize. If the source rect width
		/// exceeds the <c>SetSize</c> width, extra pixels on the right side are ignored. If the source rect height exceeds the
		/// remaining unfilled height, extra scan lines on the bottom are ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-writesource HRESULT
		// WriteSource( IWICBitmapSource *pIBitmapSource, WICRect *prc );
		void WriteSource([Optional] IWICBitmapSource? pIBitmapSource, [In, Optional] PWICRect? prc);

		/// <summary>Commits the frame to the image.</summary>
		/// <remarks>
		/// <para>
		/// After the frame <c>Commit</c> has been called, you can't use or reinitialize the IWICBitmapFrameEncode object and any
		/// objects created from it.
		/// </para>
		/// <para>
		/// To finalize the image, both the frame <c>Commit</c> and the encoder Commit must be called. However, only call the encoder
		/// <c>Commit</c> method after all frames have been committed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-commit HRESULT Commit();
		void Commit();

		/// <summary>Gets the metadata query writer for the encoder frame.</summary>
		/// <returns>
		/// <para>Type: <c>IWICMetadataQueryWriter**</c></para>
		/// <para>When this method returns, contains a pointer to metadata query writer for the encoder frame.</para>
		/// </returns>
		/// <remarks>
		/// If you are setting metadata on the frame, you must do this before you use IWICBitmapFrameEncode::WritePixels or
		/// IWICBitmapFrameEncode::WriteSource to write any image pixels to the frame
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframeencode-getmetadataquerywriter HRESULT
		// GetMetadataQueryWriter( IWICMetadataQueryWriter **ppIMetadataQueryWriter );
		IWICMetadataQueryWriter GetMetadataQueryWriter();
	}

	/// <summary>Exposes methods that support the Lock method.</summary>
	/// <remarks>
	/// <para>
	/// The bitmap lock is simply an abstraction for a rectangular memory window into the bitmap. For the simplest case, a system memory
	/// bitmap, this is simply a pointer to the top left corner of the rectangle and a stride value.
	/// </para>
	/// <para>
	/// To release the exclusive lock set by Lock method and the associated <c>IWICBitmapLock</c> object, call IUnknown::Release on the
	/// <c>IWICBitmapLock</c> object.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmaplock
	[PInvokeData("wincodec.h", MSDNShortId = "c0ddbc25-6abe-484b-a545-3b9376c514df")]
	[ComImport, Guid("00000123-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapLock
	{
		/// <summary>Retrieves the width and height, in pixels, of the locked rectangle.</summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the width of the locked rectangle.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the height of the locked rectangle.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmaplock-getsize HRESULT GetSize( UINT
		// *puiWidth, UINT *puiHeight );
		void GetSize(out uint puiWidth, out uint puiHeight);

		/// <summary>Provides access to the stride value for the memory.</summary>
		/// <returns>The stride value.</returns>
		/// <remarks>
		/// Note the stride value is specific to the IWICBitmapLock, not the bitmap. For example, two consecutive locks on the same
		/// rectangle of a bitmap may return different pointers and stride values, depending on internal implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmaplock-getstride HRESULT GetStride( UINT
		// *pcbStride );
		uint GetStride();

		/// <summary>Gets the pointer to the top left pixel in the locked rectangle.</summary>
		/// <param name="pcbBufferSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the size of the buffer.</para>
		/// </param>
		/// <param name="ppbData">
		/// <para>Type: <c>BYTE**</c></para>
		/// <para>A pointer that receives a pointer to the top left pixel in the locked rectangle.</para>
		/// </param>
		/// <remarks>
		/// <para>The pointer provided by this method should not be used outside of the lifetime of the lock itself.</para>
		/// <para><c>GetDataPointer</c> is not available in multi-threaded apartment applications.</para>
		/// <para>Examples</para>
		/// <para>In the following example, the data pointed to by the IWICBitmapLock is zero'd.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmaplock-getdatapointer HRESULT GetDataPointer(
		// UINT *pcbBufferSize, WICInProcPointer *ppbData );
		void GetDataPointer(out uint pcbBufferSize, out IntPtr ppbData);

		/// <summary>
		/// Gets the pixel format of for the locked area of pixels. This can be used to compute the number of bytes-per-pixel in the
		/// locked area.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>WICPixelFormatGUID*</c></para>
		/// <para>A pointer that receives the pixel format GUID of the locked area.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmaplock-getpixelformat HRESULT GetPixelFormat(
		// WICPixelFormatGUID *pPixelFormat );
		Guid GetPixelFormat();
	}

	/// <summary>Represents a resized version of the input bitmap using a resampling or filtering algorithm.</summary>
	/// <remarks>
	/// <para>
	/// Images can be scaled to larger sizes; however, even with sophisticated scaling algorithms, there is only so much information in
	/// the image and artifacts tend to worsen the more you scale up.
	/// </para>
	/// <para>
	/// The scaler will reapply the resampling algorithm every time CopyPixels is called. If the scaled image is to be animated, the
	/// scaled image should be created once and cached in a new bitmap, after which the <c>IWICBitmapScaler</c> may be released. In this
	/// way the scaling algorithm - which may be computationally expensive relative to drawing - is performed only once and the result
	/// displayed many times.
	/// </para>
	/// <para>
	/// The scaler is optimized to use the minimum amount of memory required to scale the image correctly. The scaler may be used to
	/// produce parts of the image incrementally (banding) by calling CopyPixels with different rectangles representing the output bands
	/// of the image. Resampling typically requires overlapping rectangles from the source image and thus may need to request the same
	/// pixels from the source bitmap multiple times. Requesting scanlines out-of-order from some image decoders can have a significant
	/// performance penalty. Because of this reason, the scaler is optimized to handle consecutive horizontal bands of scanlines
	/// (rectangle width equal to the bitmap width). In this case the accumulator from the previous vertically adjacent rectangle is
	/// re-used to avoid duplicate scanline requests from the source. This implies that banded output from the scaler may have better
	/// performance if the bands are requested sequentially. Of course if the scaler is simply used to produce a single rectangle
	/// output, this concern is eliminated because the scaler will internally request scanlines in the correct order.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapscaler
	[PInvokeData("wincodec.h", MSDNShortId = "cc14be9d-d750-40db-a95f-309b392cefe8")]
	[ComImport, Guid("00000302-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapScaler : IWICBitmapSource
	{
		/// <summary>Retrieves the pixel width and height of the bitmap.</summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel width of the bitmap.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel height of the bitmap</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getsize HRESULT GetSize( UINT
		// *puiWidth, UINT *puiHeight );
		new void GetSize(out uint puiWidth, out uint puiHeight);

		/// <summary>Retrieves the pixel format of the bitmap source..</summary>
		/// <returns>
		/// Receives the pixel format GUID the bitmap is stored in. For a list of available pixel formats, see the Native Pixel Formats topic.
		/// </returns>
		/// <remarks>
		/// The pixel format returned by this method is not necessarily the pixel format the image is stored as. The codec may perform a
		/// format conversion from the storage pixel format to an output pixel format.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getpixelformat HRESULT
		// GetPixelFormat( Guid *pPixelFormat );
		new Guid GetPixelFormat();

		/// <summary>Retrieves the sampling rate between pixels and physical world measurements.</summary>
		/// <param name="pDpiX">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the x-axis dpi resolution.</para>
		/// </param>
		/// <param name="pDpiY">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the y-axis dpi resolution.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Some formats, such as GIF and ICO, do not have full DPI support. For GIF, this method calculates the DPI values from the
		/// aspect ratio, using a base DPI of (96.0, 96.0). The ICO format does not support DPI at all, and the method always returns
		/// (96.0,96.0) for ICO images.
		/// </para>
		/// <para>
		/// Additionally, WIC itself does not transform images based on the DPI values in an image. It is up to the caller to transform
		/// an image based on the resolution returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getresolution HRESULT GetResolution(
		// double *pDpiX, double *pDpiY );
		new void GetResolution(out double pDpiX, out double pDpiY);

		/// <summary>Retrieves the color table for indexed pixel formats.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>An IWICPalette. A palette can be created using the CreatePalette method.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WINCODEC_ERR_PALETTEUNAVAILABLE</term>
		/// <term>The palette was unavailable.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The palette was successfully copied.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the IWICBitmapSource is an IWICBitmapFrameDecode, the function may return the image's global palette if a frame-level
		/// palette is not available. The global palette may also be retrieved using the CopyPalette method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypalette HRESULT CopyPalette(
		// IWICPalette *pIPalette );
		[PreserveSig]
		new HRESULT CopyPalette(IWICPalette pIPalette);

		/// <summary>Instructs the object to produce pixels.</summary>
		/// <param name="prc">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle to copy. A <c>NULL</c> value specifies the entire bitmap.</para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride of the bitmap</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CopyPixels</c> is one of the two main image processing routines (the other being Lock) triggering the actual processing.
		/// It instructs the object to produce pixels according to its algorithm - this may involve decoding a portion of a JPEG stored
		/// on disk, copying a block of memory, or even analytically computing a complex gradient. The algorithm is completely dependent
		/// on the object implementing the interface.
		/// </para>
		/// <para>
		/// The caller can restrict the operation to a rectangle of interest (ROI) using the prc parameter. The ROI sub-rectangle must
		/// be fully contained in the bounds of the bitmap. Specifying a <c>NULL</c> ROI implies that the whole bitmap should be returned.
		/// </para>
		/// <para>
		/// The caller controls the memory management and must provide an output buffer (pbBuffer) for the results of the copy along
		/// with the buffer's bounds (cbBufferSize). The cbStride parameter defines the count of bytes between two vertically adjacent
		/// pixels in the output buffer. The caller must ensure that there is sufficient buffer to complete the call based on the width,
		/// height and pixel format of the bitmap and the sub-rectangle provided to the copy method.
		/// </para>
		/// <para>
		/// If the caller needs to perform numerous copies of an expensive IWICBitmapSource such as a JPEG, it is recommended to create
		/// an in-memory IWICBitmap first.
		/// </para>
		/// <para>Codec Developer Remarks</para>
		/// <para>
		/// The callee must only write to the first (prc-&gt;Width*bitsperpixel+7)/8 bytes of each line of the output buffer (in this
		/// case, a line is a consecutive string of cbStride bytes).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypixels HRESULT CopyPixels( const
		// WICRect *prc, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer );
		new void CopyPixels([In, Optional] PWICRect? prc, uint cbStride, uint cbBufferSize, [In, Out] IntPtr pbBuffer);

		/// <summary>Initializes the bitmap scaler with the provided parameters.</summary>
		/// <param name="pISource">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The input bitmap source.</para>
		/// </param>
		/// <param name="uiWidth">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The destination width.</para>
		/// </param>
		/// <param name="uiHeight">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The desination height.</para>
		/// </param>
		/// <param name="mode">
		/// <para>Type: <c>WICBitmapInterpolationMode</c></para>
		/// <para>The WICBitmapInterpolationMode to use when scaling.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// IWICBitmapScaler can't be initialized multiple times. For example, when scaling every frame in a multi-frame image, a new
		/// <c>IWICBitmapScaler</c> must be created and initialized for each frame.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example using an IWICBitmapScaler, see the How to Scale a Bitmap Source topic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapscaler-initialize HRESULT Initialize(
		// IWICBitmapSource *pISource, UINT uiWidth, UINT uiHeight, WICBitmapInterpolationMode mode );
		void Initialize(IWICBitmapSource pISource, uint uiWidth, uint uiHeight, WICBitmapInterpolationMode mode);
	}

	/// <summary>Exposes methods that refers to a source from which pixels are retrieved, but cannot be written back to.</summary>
	/// <remarks>
	/// <para>
	/// This interface provides a common way of accessing and linking together bitmaps, decoders, format converters, and scalers.
	/// Components that implement this interface can be connected together in a graph to pull imaging data through.
	/// </para>
	/// <para>
	/// This interface defines only the notion of readability or being able to produce pixels. Modifying or writing to a bitmap is
	/// considered to be a specialization specific to bitmaps which have storage and is defined in the descendant interface IWICBitmap.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapsource
	[PInvokeData("wincodec.h", MSDNShortId = "abcc84af-6067-4856-8618-fb66aff4255a")]
	[ComImport, Guid("00000120-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapSource
	{
		/// <summary>Retrieves the pixel width and height of the bitmap.</summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel width of the bitmap.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel height of the bitmap</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getsize HRESULT GetSize( UINT
		// *puiWidth, UINT *puiHeight );
		void GetSize(out uint puiWidth, out uint puiHeight);

		/// <summary>Retrieves the pixel format of the bitmap source..</summary>
		/// <returns>
		/// Receives the pixel format GUID the bitmap is stored in. For a list of available pixel formats, see the Native Pixel Formats topic.
		/// </returns>
		/// <remarks>
		/// The pixel format returned by this method is not necessarily the pixel format the image is stored as. The codec may perform a
		/// format conversion from the storage pixel format to an output pixel format.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getpixelformat HRESULT
		// GetPixelFormat( Guid *pPixelFormat );
		Guid GetPixelFormat();

		/// <summary>Retrieves the sampling rate between pixels and physical world measurements.</summary>
		/// <param name="pDpiX">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the x-axis dpi resolution.</para>
		/// </param>
		/// <param name="pDpiY">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the y-axis dpi resolution.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Some formats, such as GIF and ICO, do not have full DPI support. For GIF, this method calculates the DPI values from the
		/// aspect ratio, using a base DPI of (96.0, 96.0). The ICO format does not support DPI at all, and the method always returns
		/// (96.0,96.0) for ICO images.
		/// </para>
		/// <para>
		/// Additionally, WIC itself does not transform images based on the DPI values in an image. It is up to the caller to transform
		/// an image based on the resolution returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getresolution HRESULT GetResolution(
		// double *pDpiX, double *pDpiY );
		void GetResolution(out double pDpiX, out double pDpiY);

		/// <summary>Retrieves the color table for indexed pixel formats.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>An IWICPalette. A palette can be created using the CreatePalette method.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WINCODEC_ERR_PALETTEUNAVAILABLE</term>
		/// <term>The palette was unavailable.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The palette was successfully copied.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the IWICBitmapSource is an IWICBitmapFrameDecode, the function may return the image's global palette if a frame-level
		/// palette is not available. The global palette may also be retrieved using the CopyPalette method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypalette HRESULT CopyPalette(
		// IWICPalette *pIPalette );
		[PreserveSig]
		HRESULT CopyPalette(IWICPalette pIPalette);

		/// <summary>Instructs the object to produce pixels.</summary>
		/// <param name="prc">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle to copy. A <c>NULL</c> value specifies the entire bitmap.</para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride of the bitmap</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CopyPixels</c> is one of the two main image processing routines (the other being Lock) triggering the actual processing.
		/// It instructs the object to produce pixels according to its algorithm - this may involve decoding a portion of a JPEG stored
		/// on disk, copying a block of memory, or even analytically computing a complex gradient. The algorithm is completely dependent
		/// on the object implementing the interface.
		/// </para>
		/// <para>
		/// The caller can restrict the operation to a rectangle of interest (ROI) using the prc parameter. The ROI sub-rectangle must
		/// be fully contained in the bounds of the bitmap. Specifying a <c>NULL</c> ROI implies that the whole bitmap should be returned.
		/// </para>
		/// <para>
		/// The caller controls the memory management and must provide an output buffer (pbBuffer) for the results of the copy along
		/// with the buffer's bounds (cbBufferSize). The cbStride parameter defines the count of bytes between two vertically adjacent
		/// pixels in the output buffer. The caller must ensure that there is sufficient buffer to complete the call based on the width,
		/// height and pixel format of the bitmap and the sub-rectangle provided to the copy method.
		/// </para>
		/// <para>
		/// If the caller needs to perform numerous copies of an expensive IWICBitmapSource such as a JPEG, it is recommended to create
		/// an in-memory IWICBitmap first.
		/// </para>
		/// <para>Codec Developer Remarks</para>
		/// <para>
		/// The callee must only write to the first (prc-&gt;Width*bitsperpixel+7)/8 bytes of each line of the output buffer (in this
		/// case, a line is a consecutive string of cbStride bytes).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypixels HRESULT CopyPixels( const
		// WICRect *prc, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer );
		void CopyPixels([In, Optional] PWICRect? prc, uint cbStride, uint cbBufferSize, [In, Out] IntPtr pbBuffer);
	}

	/// <summary>Exposes methods for offloading certain operations to the underlying IWICBitmapSource implementation.</summary>
	/// <remarks>
	/// The <c>IWICBitmapSourceTransform</c> interface is implemented by codecs which can natively scale, flip, rotate, or format
	/// convert pixels during decoding. As the transformation is combined with the decoding process, native transformation will
	/// generally offer performance advantages over non-native transformations. The inbox IWICBitmapScaler, IWICBitmapFlipRotator, and
	/// IWICFormatConverter implementations all make use of the IWICBitmapSourceTransform interface when they are placed immediately
	/// after a supported IWICBitmapFrameDecode, so in the typical case an application will automatically receive this performance
	/// increase and does not need to directly use this interface. However, when chaining multiple transformations, or when implementing
	/// a custom transformation, there may be a performance advantage to using the IWICBitmapSourceTransform interface directly.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicbitmapsourcetransform
	[PInvokeData("wincodec.h", MSDNShortId = "f9cc348f-d4f0-4e77-90d6-9ff563a1799c")]
	[ComImport, Guid("3B16811B-6A43-4ec9-B713-3D5A0C13B940"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICBitmapSourceTransform
	{
		/// <summary>Copies pixel data using the supplied input parameters.</summary>
		/// <param name="prc">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle of pixels to copy.</para>
		/// </param>
		/// <param name="uiWidth">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width to scale the source bitmap. This parameter must equal the value obtainable through IWICBitmapSourceTransform::GetClosestSize.</para>
		/// </param>
		/// <param name="uiHeight">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height to scale the source bitmap. This parameter must equal the value obtainable through IWICBitmapSourceTransform::GetClosestSize.</para>
		/// </param>
		/// <param name="pguidDstFormat">
		/// <para>Type: <c>WICPixelFormatGUID*</c></para>
		/// <para>The GUID of desired pixel format in which the pixels should be returned.</para>
		/// <para>This GUID must be a format obtained through an GetClosestPixelFormat call.</para>
		/// </param>
		/// <param name="dstTransform">
		/// <para>Type: <c>WICBitmapTransformOptions</c></para>
		/// <para>The desired rotation or flip to perform prior to the pixel copy.</para>
		/// <para>The transform must be an operation supported by an DoesSupportTransform call.</para>
		/// <para>
		/// If a dstTransform is specified, nStride is the transformed stride and is based on the pguidDstFormat pixel format, not the
		/// original source's pixel format.
		/// </para>
		/// </param>
		/// <param name="nStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride of the destination buffer.</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the destination buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>The output buffer.</para>
		/// </param>
		/// <remarks>
		/// <para>Codec Developer Remarks</para>
		/// <para>If NULL is passed in for prc, the entire image is copied.</para>
		/// <para>For codec developer implementation details for this method, see Implementing IWICBitmapSourceTransform.</para>
		/// <para>
		/// When multiple transform operations are requested, the result is dependent on the order in which the operations are
		/// performed. To ensure predictability and consistency across CODECs, it's important that all CODECs perform these operations
		/// in the same order. The recommended order of these operations is:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Scale</term>
		/// </item>
		/// <item>
		/// <term>Crop</term>
		/// </item>
		/// <item>
		/// <term>Flip/Rotate</term>
		/// </item>
		/// </list>
		/// <para>Pixel format conversion can be performed at any time, since it has no effect on the other transforms.</para>
		/// <para>
		/// The first parameter, prc is used to specify the region of interest for clipping the image. By convention, scaling is
		/// performed before clipping so, if the image is to be scaled as well as clipped, the region of interest should be determined
		/// after the image has been scaled.
		/// </para>
		/// <para>
		/// If a dstTransform is specified, the stride is the transformed stride, and is based on the pixelFormat specified in the
		/// <c>CopyPixels</c> call, not the original frame's pixel format.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsourcetransform-copypixels HRESULT
		// CopyPixels( const WICRect *prc, UINT uiWidth, UINT uiHeight, WICPixelFormatGUID *pguidDstFormat, WICBitmapTransformOptions
		// dstTransform, UINT nStride, UINT cbBufferSize, BYTE *pbBuffer );
		void CopyPixels([In, Optional] PWICRect? prc, uint uiWidth, uint uiHeight, in Guid pguidDstFormat, WICBitmapTransformOptions dstTransform, uint nStride, uint cbBufferSize, [Out] IntPtr pbBuffer);

		/// <summary>Returns the closest dimensions the implementation can natively scale to given the desired dimensions.</summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The desired width. A pointer that receives the closest supported width.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The desired height. A pointer that receives the closest supported height.</para>
		/// </param>
		/// <remarks>
		/// <para>The Windows provided codecs provide the following support for native scaling:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>BMP, ICO, GIF, TIFF: No implementation of IWICBitmapSourceTransform.</term>
		/// </item>
		/// <item>
		/// <term>PNG: No scaling support.</term>
		/// </item>
		/// <item>
		/// <term>JPEG: Native down-scaling by a factor of 8, 4, or 2.</term>
		/// </item>
		/// <item>
		/// <term>JPEG-XR: Native scaling of the original image by powers of 2.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsourcetransform-getclosestsize HRESULT
		// GetClosestSize( UINT *puiWidth, UINT *puiHeight );
		void GetClosestSize(out uint puiWidth, out uint puiHeight);

		/// <summary>
		/// Retrieves the closest pixel format to which the implementation of IWICBitmapSourceTransform can natively copy pixels, given
		/// a desired format.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>WICPixelFormatGUID*</c></para>
		/// <para>A pointer that receives the GUID of the pixel format that is the closest supported pixel format of the desired format.</para>
		/// </returns>
		/// <remarks>
		/// <para>The Windows provided codecs provide the following support:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>BMP, ICO, GIF, TIFF: No implementation of IWICBitmapSourceTransform.</term>
		/// </item>
		/// <item>
		/// <term>JPEG, PNG, JPEG-XR: Trivial support (always returns the same value as IWICBitmapFrameDecode::GetPixelFormat).</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsourcetransform-getclosestpixelformat
		// HRESULT GetClosestPixelFormat( WICPixelFormatGUID *pguidDstFormat );
		Guid GetClosestPixelFormat();

		/// <summary>
		/// Determines whether a specific transform option is supported natively by the implementation of the IWICBitmapSourceTransform interface.
		/// </summary>
		/// <param name="dstTransform">
		/// <para>Type: <c>WICBitmapTransformOptions</c></para>
		/// <para>The WICBitmapTransformOptions to check if they are supported.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A pointer that receives a value specifying whether the transform option is supported.</para>
		/// </returns>
		/// <remarks>
		/// <para>The Windows provided codecs provide the following level of support:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>BMP, ICO, GIF, TIFF: No implementation of IWICBitmapSourceTransform.</term>
		/// </item>
		/// <item>
		/// <term>JPEG, PNG: Trivial support (WICBitmapTransformRotate0 only).</term>
		/// </item>
		/// <item>
		/// <term>JPEG-XR: Support for all transformation/rotations.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsourcetransform-doessupporttransform
		// HRESULT DoesSupportTransform( WICBitmapTransformOptions dstTransform, BOOL *pfIsSupported );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesSupportTransform(WICBitmapTransformOptions dstTransform);
	}

	/// <summary>Exposes methods for color management.</summary>
	/// <remarks>
	/// <para>A Color Context is an abstraction for a color profile. The profile can either be loaded from a file (like "sRGB Color Space Profile.icm"), read from a memory buffer, or can be defined by an EXIF color space. The system color profile directory can be obtained by calling GetColorDirectory.</para>
	/// <para>Once a color context has been initialized, it cannot be re-initialized.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwiccolorcontext
	[PInvokeData("wincodec.h", MSDNShortId = "b6817676-affb-4bb3-adba-e24e0b75ad10")]
	[ComImport, Guid("3C613A02-34B2-44ea-9A7C-45AEA9C6FD6D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICColorContext
	{
		/// <summary>Initializes the color context from the given file.</summary>
		/// <param name="wzFilename">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the file.</para>
		/// </param>
		/// <remarks>Once a color context has been initialized, it can't be re-initialized.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-initializefromfilename
		// HRESULT InitializeFromFilename( LPCWSTR wzFilename );
		void InitializeFromFilename([MarshalAs(UnmanagedType.LPWStr)] string wzFilename);

		/// <summary>Initializes the color context from a memory block.</summary>
		/// <param name="pbBuffer">
		/// <para>Type: <c>const BYTE*</c></para>
		/// <para>The buffer used to initialize the IWICColorContext.</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pbBuffer buffer.</para>
		/// </param>
		/// <remarks>Once a color context has been initialized, it can't be re-initialized.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-initializefrommemory
		// HRESULT InitializeFromMemory( const BYTE *pbBuffer, UINT cbBufferSize );
		void InitializeFromMemory([In] IntPtr pbBuffer, uint cbBufferSize);

		/// <summary>Initializes the color context using an Exchangeable Image File (EXIF) color space.</summary>
		/// <param name="value">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The value of the EXIF color space.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>A sRGB color space.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>An Adobe RGB color space.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>Once a color context has been initialized, it can't be re-initialized.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-initializefromexifcolorspace
		// HRESULT InitializeFromExifColorSpace( UINT value );
		void InitializeFromExifColorSpace(uint value);

		/// <summary>Retrieves the color context type.</summary>
		/// <returns>
		/// <para>Type: <c>WICColorContextType*</c></para>
		/// <para>A pointer that receives the WICColorContextType of the color context.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-gettype
		// HRESULT GetType( WICColorContextType *pType );
		WICColorContextType GetType();

		/// <summary>Retrieves the color context profile.</summary>
		/// <param name="cbBuffer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pbBuffer buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer that receives the color context profile.</para>
		/// </param>
		/// <param name="pcbActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the actual buffer size needed to retrieve the entire color context profile.</para>
		/// </param>
		/// <remarks>
		/// <para>Only use this method if the context type is WICColorContextProfile.</para>
		/// <para>Calling this method with pbBuffer set to <c>NULL</c> will cause it to return the required buffer size in pcbActual.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-getprofilebytes
		// HRESULT GetProfileBytes( UINT cbBuffer, BYTE *pbBuffer, UINT *pcbActual );
		void GetProfileBytes(uint cbBuffer, [Out] IntPtr pbBuffer, out uint pcbActual);

		/// <summary>Retrieves the Exchangeable Image File (EXIF) color space color context.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the EXIF color space color context.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>A sRGB color space.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>An Adobe RGB color space.</term>
		/// </item>
		/// <item>
		/// <term>3 through 65534</term>
		/// <term>Unused.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This method should only be used when IWICColorContext::GetType indicates WICColorContextExifColorSpace.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccolorcontext-getexifcolorspace
		// HRESULT GetExifColorSpace( UINT *pValue );
		uint GetExifColorSpace();
	}

	/// <summary>Exposes methods that transforms an IWICBitmapSource from one color context to another.</summary>
	/// <remarks>
	/// <para>A <c>IWICColorTransform</c> is an imaging pipeline component that knows how to pull pixels obtained from a given IWICBitmapSource through a color transform. The color transform is defined by mapping colors from the source color context to the destination color context in a given output pixel format.</para>
	/// <para>Once initialized, a color transform cannot be reinitialized. Because of this, a color transform cannot be used with multiple sources or varying parameters.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwiccolortransform
	[PInvokeData("wincodec.h", MSDNShortId = "6c8ae787-3175-4128-ae9f-e11cb0e4c317")]
	[ComImport, Guid("B66F034F-D0E2-40ab-B436-6DE39E321A94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICColorTransform : IWICBitmapSource
	{
		/// <summary>Retrieves the pixel width and height of the bitmap.</summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel width of the bitmap.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel height of the bitmap</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getsize HRESULT GetSize( UINT
		// *puiWidth, UINT *puiHeight );
		new void GetSize(out uint puiWidth, out uint puiHeight);

		/// <summary>Retrieves the pixel format of the bitmap source..</summary>
		/// <returns>
		/// Receives the pixel format GUID the bitmap is stored in. For a list of available pixel formats, see the Native Pixel Formats topic.
		/// </returns>
		/// <remarks>
		/// The pixel format returned by this method is not necessarily the pixel format the image is stored as. The codec may perform a
		/// format conversion from the storage pixel format to an output pixel format.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getpixelformat HRESULT
		// GetPixelFormat( Guid *pPixelFormat );
		new Guid GetPixelFormat();

		/// <summary>Retrieves the sampling rate between pixels and physical world measurements.</summary>
		/// <param name="pDpiX">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the x-axis dpi resolution.</para>
		/// </param>
		/// <param name="pDpiY">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the y-axis dpi resolution.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Some formats, such as GIF and ICO, do not have full DPI support. For GIF, this method calculates the DPI values from the
		/// aspect ratio, using a base DPI of (96.0, 96.0). The ICO format does not support DPI at all, and the method always returns
		/// (96.0,96.0) for ICO images.
		/// </para>
		/// <para>
		/// Additionally, WIC itself does not transform images based on the DPI values in an image. It is up to the caller to transform
		/// an image based on the resolution returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getresolution HRESULT GetResolution(
		// double *pDpiX, double *pDpiY );
		new void GetResolution(out double pDpiX, out double pDpiY);

		/// <summary>Retrieves the color table for indexed pixel formats.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>An IWICPalette. A palette can be created using the CreatePalette method.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WINCODEC_ERR_PALETTEUNAVAILABLE</term>
		/// <term>The palette was unavailable.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The palette was successfully copied.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the IWICBitmapSource is an IWICBitmapFrameDecode, the function may return the image's global palette if a frame-level
		/// palette is not available. The global palette may also be retrieved using the CopyPalette method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypalette HRESULT CopyPalette(
		// IWICPalette *pIPalette );
		[PreserveSig]
		new HRESULT CopyPalette(IWICPalette pIPalette);

		/// <summary>Instructs the object to produce pixels.</summary>
		/// <param name="prc">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle to copy. A <c>NULL</c> value specifies the entire bitmap.</para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride of the bitmap</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CopyPixels</c> is one of the two main image processing routines (the other being Lock) triggering the actual processing.
		/// It instructs the object to produce pixels according to its algorithm - this may involve decoding a portion of a JPEG stored
		/// on disk, copying a block of memory, or even analytically computing a complex gradient. The algorithm is completely dependent
		/// on the object implementing the interface.
		/// </para>
		/// <para>
		/// The caller can restrict the operation to a rectangle of interest (ROI) using the prc parameter. The ROI sub-rectangle must
		/// be fully contained in the bounds of the bitmap. Specifying a <c>NULL</c> ROI implies that the whole bitmap should be returned.
		/// </para>
		/// <para>
		/// The caller controls the memory management and must provide an output buffer (pbBuffer) for the results of the copy along
		/// with the buffer's bounds (cbBufferSize). The cbStride parameter defines the count of bytes between two vertically adjacent
		/// pixels in the output buffer. The caller must ensure that there is sufficient buffer to complete the call based on the width,
		/// height and pixel format of the bitmap and the sub-rectangle provided to the copy method.
		/// </para>
		/// <para>
		/// If the caller needs to perform numerous copies of an expensive IWICBitmapSource such as a JPEG, it is recommended to create
		/// an in-memory IWICBitmap first.
		/// </para>
		/// <para>Codec Developer Remarks</para>
		/// <para>
		/// The callee must only write to the first (prc-&gt;Width*bitsperpixel+7)/8 bytes of each line of the output buffer (in this
		/// case, a line is a consecutive string of cbStride bytes).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypixels HRESULT CopyPixels( const
		// WICRect *prc, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer );
		new void CopyPixels([In, Optional] PWICRect prc, uint cbStride, uint cbBufferSize, [In, Out] IntPtr pbBuffer);

		/// <summary>
		/// Initializes an IWICColorTransform with a IWICBitmapSource and transforms it from one IWICColorContext to another.
		/// </summary>
		/// <param name="pIBitmapSource"><para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The bitmap source used to initialize the color transform.</para></param>
		/// <param name="pIContextSource"><para>Type: <c>IWICColorContext*</c></para>
		/// <para>The color context source.</para></param>
		/// <param name="pIContextDest"><para>Type: <c>IWICColorContext*</c></para>
		/// <para>The color context destination.</para></param>
		/// <param name="pixelFmtDest"><para>Type: <c>in Guid</c></para>
		/// <para>The GUID of the desired pixel format.</para>
		/// <para>This parameter is limited to a subset of the native WIC pixel formats, see Remarks for a list.</para></param>
		/// <remarks>
		/// <para>The currently supported formats for the pIContextSource and pixelFmtDest parameters are:</para>
		/// <list type="bullet">
		///   <item>
		///     <term>GUID_WICPixelFormat8bppGray</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat16bppGray</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat16bppBGR555</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat16bppBGR565</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat24bppBGR</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat24bppRGB</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat32bppBGR</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat32bppBGRA</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat32bppPBGRA</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat32bppPRGBA (Windows 8 and later)</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat32bppRGBA</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat32bppBGR101010</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat32bppCMYK</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat48bppBGR</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat64bppBGRA (Windows 8 and later)</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat64bppPBGRA (Windows 8 and later)</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat64bppPRGBA (Windows 8 and later)</term>
		///   </item>
		///   <item>
		///     <term>GUID_WICPixelFormat64bppRGBA (Windows 8 and later)</term>
		///   </item>
		/// </list>
		/// <para>In order to get correct behavior from a color transform, the input and output pixel formats must be compatible with the source and destination color profiles. For example, an sRGB destination color profile will produce incorrect results when used with a CMYK destination pixel format.</para>
		/// <para>Examples</para>
		/// <para>The following example performs a color transform from one IWICColorContext to another.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccolortransform-initialize
		// HRESULT Initialize( IWICBitmapSource *pIBitmapSource, IWICColorContext *pIContextSource, IWICColorContext *pIContextDest, in Guid pixelFmtDest );
		void Initialize([Optional] IWICBitmapSource? pIBitmapSource, [Optional] IWICColorContext? pIContextSource, [Optional] IWICColorContext? pIContextDest, in Guid pixelFmtDest);
	}

	/// <summary>Exposes methods that create components used by component developers. This includes metadata readers, writers and other services for use by codec and metadata handler developers.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nn-wincodecsdk-iwiccomponentfactory
	[PInvokeData("wincodecsdk.h", MSDNShortId = "7aac7268-8f80-4169-9208-1002ca9703e5")]
	[ComImport, Guid("412D0C3A-9650-44FA-AF5B-DD2A06C8E8FB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICComponentFactory : IWICImagingFactory
	{
		/// <summary>Creates a new instance of the IWICBitmapDecoder class based on the given file.</summary>
		/// <param name="wzFilename">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated string that specifies the name of an object to create or open.</para>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>The GUID for the preferred decoder vendor. Use <c>default</c> if no preferred vendor.</para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The access to the object, which can be read, write, or both.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GENERIC_READ</term>
		/// <term>Read access.</term>
		/// </item>
		/// <item>
		/// <term>GENERIC_WRITE</term>
		/// <term>Write access.</term>
		/// </item>
		/// </list>
		/// <para>For more information, see Generic Access Rights.</para>
		/// </param>
		/// <param name="metadataOptions">
		/// <para>Type: <c>WICDecodeOptions</c></para>
		/// <para>The WICDecodeOptions to use when creating the decoder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmapDecoder**</c></para>
		/// <para>A pointer that receives a pointer to the new IWICBitmapDecoder.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createdecoderfromfilename
		// HRESULT CreateDecoderFromFilename( LPCWSTR wzFilename, const GUID *pguidVendor, DWORD dwDesiredAccess, WICDecodeOptions metadataOptions, IWICBitmapDecoder **ppIDecoder );
		new IWICBitmapDecoder CreateDecoderFromFilename([MarshalAs(UnmanagedType.LPWStr)] string wzFilename, [In] SafeGuidPtr pguidVendor, ACCESS_MASK dwDesiredAccess, WICDecodeOptions metadataOptions);

		/// <summary>Creates a new instance of the IWICBitmapDecoder class based on the given IStream.</summary>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>The stream to create the decoder from.</para>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>The GUID for the preferred decoder vendor. Use <c>default</c> if no preferred vendor.</para>
		/// </param>
		/// <param name="metadataOptions">
		/// <para>Type: <c>WICDecodeOptions</c></para>
		/// <para>The WICDecodeOptions to use when creating the decoder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmapDecoder**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapDecoder.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createdecoderfromstream
		// HRESULT CreateDecoderFromStream( IStream *pIStream, const GUID *pguidVendor, WICDecodeOptions metadataOptions, IWICBitmapDecoder **ppIDecoder );
		new IWICBitmapDecoder CreateDecoderFromStream(IStream pIStream, [In] SafeGuidPtr pguidVendor, WICDecodeOptions metadataOptions);

		/// <summary>Creates a new instance of the IWICBitmapDecoder based on the given file handle.</summary>
		/// <param name="hFile">
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>The file handle to create the decoder from.</para>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>The GUID for the preferred decoder vendor. Use <c>default</c> if no preferred vendor.</para>
		/// </param>
		/// <param name="metadataOptions">
		/// <para>Type: <c>WICDecodeOptions</c></para>
		/// <para>The WICDecodeOptions to use when creating the decoder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmapDecoder**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapDecoder.</para>
		/// </returns>
		/// <remarks>When a decoder is created using this method, the file handle must remain alive during the lifetime of the decoder.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createdecoderfromfilehandle
		// HRESULT CreateDecoderFromFileHandle( ULONG_PTR hFile, const GUID *pguidVendor, WICDecodeOptions metadataOptions, IWICBitmapDecoder **ppIDecoder );
		new IWICBitmapDecoder CreateDecoderFromFileHandle(HFILE hFile, [In] SafeGuidPtr pguidVendor, WICDecodeOptions metadataOptions);

		/// <summary>Creates a new instance of the IWICComponentInfo class for the given component class identifier (CLSID).</summary>
		/// <param name="clsidComponent">
		/// <para>Type: <c>REFCLSID</c></para>
		/// <para>The CLSID for the desired component.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICComponentInfo**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICComponentInfo.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcomponentinfo
		// HRESULT CreateComponentInfo( REFCLSID clsidComponent, IWICComponentInfo **ppIInfo );
		new IWICComponentInfo CreateComponentInfo(in Guid clsidComponent);

		/// <summary>Creates a new instance of IWICBitmapDecoder.</summary>
		/// <param name="guidContainerFormat">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>The GUID for the desired container format.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_ContainerFormatBmp</term>
		/// <term>The BMP container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatPng</term>
		/// <term>The PNG container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatIco</term>
		/// <term>The ICO container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatJpeg</term>
		/// <term>The JPEG container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatTiff</term>
		/// <term>The TIFF container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatGif</term>
		/// <term>The GIF container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatWmp</term>
		/// <term>The HD Photo container format GUID.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>The GUID for the preferred encoder vendor.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SafeGuidPtr.Null</term>
		/// <term>No preferred codec vendor.</term>
		/// </item>
		/// <item>
		/// <term>GUID_VendorMicrosoft</term>
		/// <term>Prefer to use Microsoft encoder.</term>
		/// </item>
		/// <item>
		/// <term>GUID_VendorMicrosoftBuiltIn</term>
		/// <term>Prefer to use the native Microsoft encoder.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmapDecoder**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapDecoder. You must initialize this <c>IWICBitmapDecoder</c> on a stream using the Initialize method later.</para>
		/// </returns>
		/// <remarks>Other values may be available for both guidContainerFormat and pguidVendor depending on the installed WIC-enabled encoders. The values listed are those that are natively supported by the operating system.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createdecoder
		// HRESULT CreateDecoder( REFGUID guidContainerFormat, const GUID *pguidVendor, IWICBitmapDecoder **ppIDecoder );
		new IWICBitmapDecoder CreateDecoder(in Guid guidContainerFormat, [In] SafeGuidPtr pguidVendor);

		/// <summary>Creates a new instance of the IWICBitmapEncoder class.</summary>
		/// <param name="guidContainerFormat">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>The GUID for the desired container format.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_ContainerFormatBmp</term>
		/// <term>The BMP container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatPng</term>
		/// <term>The PNG container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatIco</term>
		/// <term>The ICO container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatJpeg</term>
		/// <term>The JPEG container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatTiff</term>
		/// <term>The TIFF container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatGif</term>
		/// <term>The GIF container format GUID.</term>
		/// </item>
		/// <item>
		/// <term>GUID_ContainerFormatWmp</term>
		/// <term>The HD Photo container format GUID.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>The GUID for the preferred encoder vendor.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SafeGuidPtr.Null</term>
		/// <term>No preferred codec vendor.</term>
		/// </item>
		/// <item>
		/// <term>GUID_VendorMicrosoft</term>
		/// <term>Prefer to use Microsoft encoder.</term>
		/// </item>
		/// <item>
		/// <term>GUID_VendorMicrosoftBuiltIn</term>
		/// <term>Prefer to use the native Microsoft encoder.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmapEncoder**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapEncoder.</para>
		/// </returns>
		/// <remarks>Other values may be available for both guidContainerFormat and pguidVendor depending on the installed WIC-enabled encoders. The values listed are those that are natively supported by the operating system.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createencoder
		// HRESULT CreateEncoder( REFGUID guidContainerFormat, const GUID *pguidVendor, IWICBitmapEncoder **ppIEncoder );
		new IWICBitmapDecoder CreateEncoder(in Guid guidContainerFormat, [In] SafeGuidPtr pguidVendor);

		/// <summary>Creates a new instance of the IWICPalette class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICPalette**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICPalette.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createpalette
		// HRESULT CreatePalette( IWICPalette **ppIPalette );
		new IWICPalette CreatePalette();

		/// <summary>Creates a new instance of the IWICFormatConverter class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICFormatConverter**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICFormatConverter.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createformatconverter
		// HRESULT CreateFormatConverter( IWICFormatConverter **ppIFormatConverter );
		new IWICFormatConverter CreateFormatConverter();

		/// <summary>Creates a new instance of an IWICBitmapScaler.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapScaler**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapScaler.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapscaler
		// HRESULT CreateBitmapScaler( IWICBitmapScaler **ppIBitmapScaler );
		new IWICBitmapScaler CreateBitmapScaler();

		/// <summary>Creates a new instance of an IWICBitmapClipper object.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapClipper**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapClipper.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapclipper
		// HRESULT CreateBitmapClipper( IWICBitmapClipper **ppIBitmapClipper );
		new IWICBitmapClipper CreateBitmapClipper();

		/// <summary>Creates a new instance of an IWICBitmapFlipRotator object.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapFlipRotator**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapFlipRotator.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfliprotator
		// HRESULT CreateBitmapFlipRotator( IWICBitmapFlipRotator **ppIBitmapFlipRotator );
		new IWICBitmapFlipRotator CreateBitmapFlipRotator();

		/// <summary>Creates a new instance of the IWICStream class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICStream**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICStream.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createstream
		// HRESULT CreateStream( IWICStream **ppIWICStream );
		new IWICStream CreateStream();

		/// <summary>Creates a new instance of the IWICColorContext class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICColorContext**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICColorContext.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcolorcontext
		// HRESULT CreateColorContext( IWICColorContext **ppIWICColorContext );
		new IWICColorContext CreateColorContext();

		/// <summary>Creates a new instance of the IWICColorTransform class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICColorTransform**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICColorTransform.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcolortransformer
		// HRESULT CreateColorTransformer( IWICColorTransform **ppIWICColorTransform );
		new IWICColorTransform CreateColorTransformer();

		/// <summary>Creates an IWICBitmap object.</summary>
		/// <param name="uiWidth">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of the new bitmap .</para>
		/// </param>
		/// <param name="uiHeight">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height of the new bitmap.</para>
		/// </param>
		/// <param name="pixelFormat">
		/// <para>Type: <c>in Guid</c></para>
		/// <para>The pixel format of the new bitmap.</para>
		/// </param>
		/// <param name="option">
		/// <para>Type: <c>WICBitmapCreateCacheOption</c></para>
		/// <para>The cache creation options of the new bitmap. This can be one of the values in the WICBitmapCreateCacheOption enumeration.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WICBitmapCacheOnDemand</term>
		/// <term>Allocates system memory for the bitmap at initialization.</term>
		/// </item>
		/// <item>
		/// <term>WICBitmapCacheOnLoad</term>
		/// <term>Allocates system memory for the bitmap when the bitmap is first used.</term>
		/// </item>
		/// <item>
		/// <term>WICBitmapNoCache</term>
		/// <term>This option is not valid for this method and should not be used.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmap**</c></para>
		/// <para>A pointer that receives a pointer to the new bitmap.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmap
		// HRESULT CreateBitmap( UINT uiWidth, UINT uiHeight, in Guid pixelFormat, WICBitmapCreateCacheOption option, IWICBitmap **ppIBitmap );
		new IWICBitmap CreateBitmap(uint uiWidth, uint uiHeight, in Guid pixelFormat, WICBitmapCreateCacheOption option);

		/// <summary>Creates a IWICBitmap from a IWICBitmapSource.</summary>
		/// <param name="pIBitmapSource">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The IWICBitmapSource to create the bitmap from.</para>
		/// </param>
		/// <param name="option">
		/// <para>Type: <c>WICBitmapCreateCacheOption</c></para>
		/// <para>The cache options of the new bitmap. This can be one of the values in the WICBitmapCreateCacheOption enumeration.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WICBitmapNoCache</term>
		/// <term>Do not create a system memory copy. Share the bitmap with the source.</term>
		/// </item>
		/// <item>
		/// <term>WICBitmapCacheOnDemand</term>
		/// <term>Create a system memory copy when the bitmap is first used.</term>
		/// </item>
		/// <item>
		/// <term>WICBitmapCacheOnLoad</term>
		/// <term>Create a system memory copy when this method is called.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmap**</c></para>
		/// <para>A pointer that receives a pointer to the new bitmap.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromsource
		// HRESULT CreateBitmapFromSource( IWICBitmapSource *pIBitmapSource, WICBitmapCreateCacheOption option, IWICBitmap **ppIBitmap );
		new IWICBitmap CreateBitmapFromSource(IWICBitmapSource pIBitmapSource, WICBitmapCreateCacheOption option);

		/// <summary>Creates an IWICBitmap from a specified rectangle of an IWICBitmapSource.</summary>
		/// <param name="pIBitmapSource">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The IWICBitmapSource to create the bitmap from.</para>
		/// </param>
		/// <param name="x">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The horizontal coordinate of the upper-left corner of the rectangle.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The vertical coordinate of the upper-left corner of the rectangle.</para>
		/// </param>
		/// <param name="width">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of the rectangle and the new bitmap.</para>
		/// </param>
		/// <param name="height">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height of the rectangle and the new bitmap.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmap**</c></para>
		/// <para>A pointer that receives a pointer to the new bitmap.</para>
		/// </returns>
		/// <remarks>
		/// <para>Providing a rectangle that is larger than the source will produce undefined results.</para>
		/// <para>This method always creates a separate copy of the source image, similar to the cache option WICBitmapCacheOnLoad.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromsourcerect
		// HRESULT CreateBitmapFromSourceRect( IWICBitmapSource *pIBitmapSource, UINT x, UINT y, UINT width, UINT height, IWICBitmap **ppIBitmap );
		new IWICBitmap CreateBitmapFromSourceRect(IWICBitmapSource pIBitmapSource, uint x, uint y, uint width, uint height);

		/// <summary>Creates an IWICBitmap from a memory block.</summary>
		/// <param name="uiWidth">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of the new bitmap.</para>
		/// </param>
		/// <param name="uiHeight">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height of the new bitmap.</para>
		/// </param>
		/// <param name="pixelFormat">
		/// <para>Type: <c>in Guid</c></para>
		/// <para>The pixel format of the new bitmap. For valid pixel formats, see Native Pixel Formats.</para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of bytes between successive scanlines in pbBuffer.</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of pbBuffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>The buffer used to create the bitmap.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmap**</c></para>
		/// <para>A pointer that receives a pointer to the new bitmap.</para>
		/// </returns>
		/// <remarks>
		/// <para>The size of the IWICBitmap to be created must be smaller than or equal to the size of the image in pbBuffer.</para>
		/// <para>The stride of the destination bitmap will equal the stride of the source data, regardless of the width and height specified.</para>
		/// <para>The pixelFormat parameter defines the pixel format for both the input data and the output bitmap.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfrommemory
		// HRESULT CreateBitmapFromMemory( UINT uiWidth, UINT uiHeight, in Guid pixelFormat, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer, IWICBitmap **ppIBitmap );
		new IWICBitmap CreateBitmapFromMemory(uint uiWidth, uint uiHeight, in Guid pixelFormat, uint cbStride, uint cbBufferSize, [In] IntPtr pbBuffer);

		/// <summary>Creates an IWICBitmap from a bitmap handle.</summary>
		/// <param name="hBitmap">
		/// <para>Type: <c>HBITMAP</c></para>
		/// <para>A bitmap handle to create the bitmap from.</para>
		/// </param>
		/// <param name="hPalette">
		/// <para>Type: <c>HPALETTE</c></para>
		/// <para>A palette handle used to create the bitmap.</para>
		/// </param>
		/// <param name="options">
		/// <para>Type: <c>WICBitmapAlphaChannelOption</c></para>
		/// <para>The alpha channel options to create the bitmap.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmap**</c></para>
		/// <para>A pointer that receives a pointer to the new bitmap.</para>
		/// </returns>
		/// <remarks>For a non-palletized bitmap, set NULL for the hPalette parameter.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromhbitmap
		// HRESULT CreateBitmapFromHBITMAP( HBITMAP hBitmap, HPALETTE hPalette, WICBitmapAlphaChannelOption options, IWICBitmap **ppIBitmap );
		new IWICBitmap CreateBitmapFromHBITMAP(HBITMAP hBitmap, [Optional] HPALETTE hPalette, WICBitmapAlphaChannelOption options);

		/// <summary>Creates an IWICBitmap from an icon handle.</summary>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>The icon handle to create the new bitmap from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmap**</c></para>
		/// <para>A pointer that receives a pointer to the new bitmap.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromhicon
		// HRESULT CreateBitmapFromHICON( HICON hIcon, IWICBitmap **ppIBitmap );
		new IWICBitmap CreateBitmapFromHICON(HICON hIcon);

		/// <summary>Creates an IEnumUnknown object of the specified component types.</summary>
		/// <param name="componentTypes">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The types of WICComponentType to enumerate.</para>
		/// </param>
		/// <param name="options">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The WICComponentEnumerateOptions used to enumerate the given component types.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IEnumUnknown**</c></para>
		/// <para>A pointer that receives a pointer to a new component enumerator.</para>
		/// </returns>
		/// <remarks>Component types must be enumerated seperately. Combinations of component types and <c>WICAllComponents</c> are unsupported.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcomponentenumerator
		// HRESULT CreateComponentEnumerator( DWORD componentTypes, DWORD options, IEnumUnknown **ppIEnumUnknown );
		new IEnumUnknown CreateComponentEnumerator(WICComponentType componentTypes, WICComponentEnumerateOptions options);

		/// <summary>Creates a new instance of the fast metadata encoder based on the given IWICBitmapDecoder.</summary>
		/// <param name="pIDecoder">
		/// <para>Type: <c>IWICBitmapDecoder*</c></para>
		/// <para>The decoder to create the fast metadata encoder from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICFastMetadataEncoder**</c></para>
		/// <para>When this method returns, contains a pointer to the new IWICFastMetadataEncoder.</para>
		/// </returns>
		/// <remarks>The Windows provided codecs do not support fast metadata encoding at the decoder level, and only support fast metadata encoding at the frame level. To create a fast metadata encoder from a frame, see CreateFastMetadataEncoderFromFrameDecode.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createfastmetadataencoderfromdecoder
		// HRESULT CreateFastMetadataEncoderFromDecoder( IWICBitmapDecoder *pIDecoder, IWICFastMetadataEncoder **ppIFastEncoder );
		new IWICFastMetadataEncoder CreateFastMetadataEncoderFromDecoder(IWICBitmapDecoder pIDecoder);

		/// <summary>Creates a new instance of the fast metadata encoder based on the given image frame.</summary>
		/// <param name="pIFrameDecoder">
		/// <para>Type: <c>IWICBitmapFrameDecode*</c></para>
		/// <para>The IWICBitmapFrameDecode to create the IWICFastMetadataEncoder from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICFastMetadataEncoder**</c></para>
		/// <para>When this method returns, contains a pointer to a new fast metadata encoder.</para>
		/// </returns>
		/// <remarks>
		/// <para>For a list of support metadata formats for fast metadata encoding, see WIC Metadata Overview.</para>
		/// <para>Examples</para>
		/// <para>The following code demonstrates how to use the <c>CreateFastMetadataEncoderFromFrameDecode</c> method for fast metadata encoding.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createfastmetadataencoderfromframedecode
		// HRESULT CreateFastMetadataEncoderFromFrameDecode( IWICBitmapFrameDecode *pIFrameDecoder, IWICFastMetadataEncoder **ppIFastEncoder );
		new IWICFastMetadataEncoder CreateFastMetadataEncoderFromFrameDecode(IWICBitmapFrameDecode pIFrameDecoder);

		/// <summary>Creates a new instance of a query writer.</summary>
		/// <param name="guidMetadataFormat">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>The GUID for the desired metadata format.</para>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>The GUID for the preferred metadata writer vendor. Use <c>NULL</c> if no preferred vendor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataQueryWriter**</c></para>
		/// <para>When this method returns, contains a pointer to a new IWICMetadataQueryWriter.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createquerywriter
		// HRESULT CreateQueryWriter( REFGUID guidMetadataFormat, const GUID *pguidVendor, IWICMetadataQueryWriter **ppIQueryWriter );
		new IWICMetadataQueryWriter CreateQueryWriter(in Guid guidMetadataFormat, [In] SafeGuidPtr pguidVendor);

		/// <summary>Creates a new instance of a query writer based on the given query reader. The query writer will be pre-populated with metadata from the query reader.</summary>
		/// <param name="pIQueryReader">
		/// <para>Type: <c>IWICMetadataQueryReader*</c></para>
		/// <para>The IWICMetadataQueryReader to create the IWICMetadataQueryWriter from.</para>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>The GUID for the preferred metadata writer vendor. Use <c>NULL</c> if no preferred vendor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataQueryWriter**</c></para>
		/// <para>When this method returns, contains a pointer to a new metadata writer.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createquerywriterfromreader
		// HRESULT CreateQueryWriterFromReader( IWICMetadataQueryReader *pIQueryReader, const GUID *pguidVendor, IWICMetadataQueryWriter **ppIQueryWriter );
		new IWICMetadataQueryWriter CreateQueryWriterFromReader(IWICMetadataQueryReader pIQueryReader, [In] SafeGuidPtr pguidVendor);

		/// <summary>Creates an IWICMetadataReader based on the given parameters.</summary>
		/// <param name="guidMetadataFormat">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>The GUID of the desired metadata format.</para>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Pointer to the GUID of the desired metadata reader vendor.</para>
		/// </param>
		/// <param name="dwOptions">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The WICPersistOptions and WICMetadataCreationOptions options to use when creating the metadata reader.</para>
		/// </param>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>Pointer to a stream in which to initialize the reader with. If <c>NULL</c>, the metadata reader will be empty.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataReader**</c></para>
		/// <para>A pointer that receives a pointer to the new metadata reader.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwiccomponentfactory-createmetadatareader
		// HRESULT CreateMetadataReader( REFGUID guidMetadataFormat, const GUID *pguidVendor, DWORD dwOptions, IStream *pIStream, IWICMetadataReader **ppIReader );
		IWICMetadataReader CreateMetadataReader(in Guid guidMetadataFormat, [In] SafeGuidPtr pguidVendor, uint dwOptions, IStream pIStream);

		/// <summary>Creates an IWICMetadataReader based on the given parameters.</summary>
		/// <param name="guidContainerFormat">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>The container format GUID to base the reader on.</para>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Pointer to the vendor GUID of the metadata reader.</para>
		/// </param>
		/// <param name="dwOptions">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The WICPersistOptions and WICMetadataCreationOptions options to use when creating the metadata reader.</para>
		/// </param>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>Pointer to a stream in which to initialize the reader with. If <c>NULL</c>, the metadata reader will be empty.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataReader**</c></para>
		/// <para>A pointer that receives a pointer to the new metadata reader</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwiccomponentfactory-createmetadatareaderfromcontainer
		// HRESULT CreateMetadataReaderFromContainer( REFGUID guidContainerFormat, const GUID *pguidVendor, DWORD dwOptions, IStream *pIStream, IWICMetadataReader **ppIReader );
		IWICMetadataReader CreateMetadataReaderFromContainer(in Guid guidContainerFormat, [In] SafeGuidPtr pguidVendor, uint dwOptions, IStream pIStream);

		/// <summary>Creates an IWICMetadataWriter based on the given parameters.</summary>
		/// <param name="guidMetadataFormat">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>The GUID of the desired metadata format.</para>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Pointer to the GUID of the desired metadata reader vendor.</para>
		/// </param>
		/// <param name="dwMetadataOptions">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The WICPersistOptions and WICMetadataCreationOptions options to use when creating the metadata reader.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataWriter**</c></para>
		/// <para>A pointer that receives a pointer to the new metadata writer.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwiccomponentfactory-createmetadatawriter
		// HRESULT CreateMetadataWriter( REFGUID guidMetadataFormat, const GUID *pguidVendor, DWORD dwMetadataOptions, IWICMetadataWriter **ppIWriter );
		IWICMetadataWriter CreateMetadataWriter(in Guid guidMetadataFormat, [In] SafeGuidPtr pguidVendor, uint dwMetadataOptions);

		/// <summary>Creates an IWICMetadataWriter from the given IWICMetadataReader.</summary>
		/// <param name="pIReader">
		/// <para>Type: <c>IWICMetadataReader*</c></para>
		/// <para>Pointer to the metadata reader to base the metadata writer on.</para>
		/// </param>
		/// <param name="pguidVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Pointer to the GUID of the desired metadata reader vendor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataWriter**</c></para>
		/// <para>A pointer that receives a pointer to the new metadata writer.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwiccomponentfactory-createmetadatawriterfromreader
		// HRESULT CreateMetadataWriterFromReader( IWICMetadataReader *pIReader, const GUID *pguidVendor, IWICMetadataWriter **ppIWriter );
		IWICMetadataWriter CreateMetadataWriterFromReader(IWICMetadataReader pIReader, [In] SafeGuidPtr pguidVendor);

		/// <summary>Creates a IWICMetadataQueryReader from the given IWICMetadataBlockReader.</summary>
		/// <param name="pIBlockReader">
		/// <para>Type: <c>IWICMetadataBlockReader*</c></para>
		/// <para>Pointer to the block reader to base the query reader on.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataQueryReader**</c></para>
		/// <para>A pointer that receives a pointer to the new metadata query reader.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwiccomponentfactory-createqueryreaderfromblockreader
		// HRESULT CreateQueryReaderFromBlockReader( IWICMetadataBlockReader *pIBlockReader, IWICMetadataQueryReader **ppIQueryReader );
		IWICMetadataQueryReader CreateQueryReaderFromBlockReader(IWICMetadataBlockReader pIBlockReader);

		/// <summary>Creates a IWICMetadataQueryWriter from the given IWICMetadataBlockWriter.</summary>
		/// <param name="pIBlockWriter">
		/// <para>Type: <c>IWICMetadataBlockWriter*</c></para>
		/// <para>Pointer to the metadata block reader to base the metadata query writer on.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataQueryWriter**</c></para>
		/// <para>A pointer that receives a pointer to the new metadata query writer.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwiccomponentfactory-createquerywriterfromblockwriter
		// HRESULT CreateQueryWriterFromBlockWriter( IWICMetadataBlockWriter *pIBlockWriter, IWICMetadataQueryWriter **ppIQueryWriter );
		IWICMetadataQueryWriter CreateQueryWriterFromBlockWriter(IWICMetadataBlockWriter pIBlockWriter);

		/// <summary>Creates an encoder property bag.</summary>
		/// <param name="ppropOptions">
		/// <para>Type: <c>PROPBAG2*</c></para>
		/// <para>Pointer to an array of PROPBAG2 options used to create the encoder property bag.</para>
		/// </param>
		/// <param name="cCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of PROPBAG2 structures in the ppropOptions array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IPropertyBag2**</c></para>
		/// <para>A pointer that receives a pointer to an encoder IPropertyBag2.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwiccomponentfactory-createencoderpropertybag
		// HRESULT CreateEncoderPropertyBag( PROPBAG2 *ppropOptions, UINT cCount, IPropertyBag2 **ppIPropertyBag );
		IPropertyBag2 CreateEncoderPropertyBag([In] PROPBAG2[] ppropOptions, uint cCount);
	}

	/// <summary>Exposes methods that provide component information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwiccomponentinfo
	[PInvokeData("wincodec.h", MSDNShortId = "a31267ed-60cd-4de9-9fed-26bb390b29e6")]
	[ComImport, Guid("23BC3F0A-698B-4357-886B-F24D50671334"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICComponentInfo
	{
		/// <summary>Retrieves the component's WICComponentType.</summary>
		/// <returns>
		/// <para>Type: <c>WICComponentType*</c></para>
		/// <para>A pointer that receives the WICComponentType.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getcomponenttype HRESULT
		// GetComponentType( WICComponentType *pType );
		WICComponentType GetComponentType();

		/// <summary>Retrieves the component's class identifier (CLSID)</summary>
		/// <returns>
		/// <para>Type: <c>CLSID*</c></para>
		/// <para>A pointer that receives the component's CLSID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getclsid HRESULT GetCLSID( CLSID
		// *pclsid );
		Guid GetCLSID();

		/// <summary>Retrieves the signing status of the component.</summary>
		/// <returns>
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A pointer that receives the WICComponentSigning status of the component.</para>
		/// </returns>
		/// <remarks>
		/// <para>Signing is unused by WIC. Therefore, all components WICComponentSigned.</para>
		/// <para>
		/// This function can be used to determine whether a component has no binary component or has been added to the disabled
		/// components list in the registry.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getsigningstatus HRESULT
		// GetSigningStatus( DWORD *pStatus );
		WICComponentSigning GetSigningStatus();

		/// <summary>Retrieves the name of component's author.</summary>
		/// <param name="cchAuthor">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzAuthor buffer.</para>
		/// </param>
		/// <param name="wzAuthor">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// A pointer that receives the name of the component's author. The locale of the string depends on the value that the codec
		/// wrote to the registry at install time. For built-in components, these strings are always in English.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's authors name. The author name is optional; if an author name is
		/// not specified by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getauthor HRESULT GetAuthor( UINT
		// cchAuthor, WCHAR *wzAuthor, UINT *pcchActual );
		void GetAuthor(uint cchAuthor, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzAuthor, out uint pcchActual);

		/// <summary>Retrieves the vendor GUID.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>A pointer that receives the component's vendor GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getvendorguid HRESULT
		// GetVendorGUID( GUID *pguidVendor );
		Guid GetVendorGUID();

		/// <summary>Retrieves the component's version.</summary>
		/// <param name="cchVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzVersion buffer.</para>
		/// </param>
		/// <param name="wzVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>A pointer that receives a culture invariant string of the component's version.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's version. The version is optional; if a value is not specified
		/// by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>All built-in components return "1.0.0.0", except for pixel formats, which do not have a version.</para>
		/// <para>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getversion HRESULT GetVersion( UINT
		// cchVersion, WCHAR *wzVersion, UINT *pcchActual );
		void GetVersion(uint cchVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzVersion, out uint pcchActual);

		/// <summary>Retrieves the component's specification version.</summary>
		/// <param name="cchSpecVersion">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzSpecVersion buffer.</para>
		/// </param>
		/// <param name="wzSpecVersion">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contain a culture invarient string of the component's specification version. The version form is NN.NN.NN.NN.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the actual length of the component's specification version. The specification version is optional;
		/// if a value is not specified by the component, the length returned is 0.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>All built-in components return "1.0.0.0", except for pixel formats, which do not have a spec version.</para>
		/// <para>If cchAuthor is 0 and wzAuthor is <c>NULL</c>, the required buffer size is returned in pccchActual.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getspecversion HRESULT
		// GetSpecVersion( UINT cchSpecVersion, WCHAR *wzSpecVersion, UINT *pcchActual );
		void GetSpecVersion(uint cchSpecVersion, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzSpecVersion, out uint pcchActual);

		/// <summary>Retrieves the component's friendly name, which is a human-readable display name for the component.</summary>
		/// <param name="cchFriendlyName">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzFriendlyName buffer.</para>
		/// </param>
		/// <param name="wzFriendlyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// A pointer that receives the friendly name of the component. The locale of the string depends on the value that the codec
		/// wrote to the registry at install time. For built-in components, these strings are always in English.
		/// </para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the actual length of the component's friendly name.</para>
		/// </param>
		/// <remarks>If cchFriendlyName is 0 and wzFriendlyName is <c>NULL</c>, the required buffer size is returned in pccchActual.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwiccomponentinfo-getfriendlyname HRESULT
		// GetFriendlyName( UINT cchFriendlyName, WCHAR *wzFriendlyName, UINT *pcchActual );
		void GetFriendlyName(uint cchFriendlyName, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzFriendlyName, out uint pcchActual);
	}

	/// <summary>Provides information and functionality specific to the DDS image format.</summary>
	/// <remarks>This interface is implemented by the WIC DDS codec. To obtain this interface, create an IWICBitmapDecoder using the DDS codec and QueryInterface for <c>IWICDdsDecoder</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicddsdecoder
	[PInvokeData("wincodec.h", MSDNShortId = "632D1E7B-9C1D-48FB-95B5-1A295FE99577")]
	[ComImport, Guid("409cd537-8532-40cb-9774-e2feb2df4e9c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICDdsDecoder
	{
		/// <summary>Gets DDS-specific data.</summary>
		/// <returns>
		/// <para>Type: <c>WICDdsParameters*</c></para>
		/// <para>A pointer to the structure where the information is returned.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicddsdecoder-getparameters
		// HRESULT GetParameters( WICDdsParameters *pParameters );
		WICDdsParameters GetParameters();

		/// <summary>Retrieves the specified frame of the DDS image.</summary>
		/// <param name="arrayIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The requested index within the texture array.</para>
		/// </param>
		/// <param name="mipLevel">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The requested mip level.</para>
		/// </param>
		/// <param name="sliceIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The requested slice within the 3D texture.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmapFrameDecode**</c></para>
		/// <para>A pointer to a IWICBitmapFrameDecode object.</para>
		/// </returns>
		/// <remarks>
		/// <para>A DDS file can contain multiple images that are organized into a three level hierarchy. First, DDS file may contain multiple textures in a texture array. Second, each texture can have multiple mip levels. Finally, the texture may be a 3D (volume) texture and have multiple slices, each of which is a 2D texture. See the DDS documentation for more information.</para>
		/// <para>WIC maps this three level hierarchy into a linear array of IWICBitmapFrameDecode, accessible via IWICBitmapDecoder::GetFrame. However, determining which frame corresponds to a triad of arrayIndex, mipLevel, and sliceIndex value is not trivial because each mip level of a 3D texture has a different depth (number of slices). This method provides additional convenience over <c>IWICBitmapDecoder::GetFrame</c> for DDS images by calculating the correct frame given the three indices.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicddsdecoder-getframe
		// HRESULT GetFrame( UINT arrayIndex, UINT mipLevel, UINT sliceIndex, IWICBitmapFrameDecode **ppIBitmapFrame );
		IWICBitmapFrameDecode GetFrame(uint arrayIndex, uint mipLevel, uint sliceIndex);
	}

	/// <summary>Enables writing DDS format specific information to an encoder.</summary>
	/// <remarks>This interface is implemented by the WIC DDS codec. To obtain this interface, create an IWICBitmapEncoder using the DDS codec and QueryInterface for <c>IWICDdsEncoder</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicddsencoder
	[PInvokeData("wincodec.h", MSDNShortId = "DF14309F-7595-4ABE-BB6E-03D2914CC86D")]
	[ComImport, Guid("5cacdb4c-407e-41b3-b936-d0f010cd6732"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICDdsEncoder
	{
		/// <summary>Sets DDS-specific data.</summary>
		/// <param name="pParameters">
		/// <para>Type: <c>WICDdsParameters*</c></para>
		/// <para>Points to the structure where the information is described.</para>
		/// </param>
		/// <remarks>
		/// <para>You cannot call this method after you have started to write frame data, for example by calling IWICDdsEncoder::CreateNewFrame.</para>
		/// <para>Setting DDS parameters using this method provides the DDS encoder with information about the expected number of frames and the dimensions and other parameters of each frame. The DDS encoder will fail if you do not set frame data that matches these expectations. For example, if you set WICDdsParameters::Width and <c>Height</c> to 32, and <c>MipLevels</c> to 6, the DDS encoder will expect 6 frames with the following dimensions:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>32x32 pixels.</term>
		/// </item>
		/// <item>
		/// <term>16x16 pixels.</term>
		/// </item>
		/// <item>
		/// <term>8x8 pixels.</term>
		/// </item>
		/// <item>
		/// <term>4x4 pixels.</term>
		/// </item>
		/// <item>
		/// <term>2x2 pixels.</term>
		/// </item>
		/// <item>
		/// <term>1x1 pixels.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicddsencoder-setparameters
		// HRESULT SetParameters( WICDdsParameters *pParameters );
		void SetParameters(in WICDdsParameters pParameters);

		/// <summary>Gets DDS-specific data.</summary>
		/// <returns>
		/// <para>Type: <c>WICDdsParameters*</c></para>
		/// <para>Points to the structure where the information is returned.</para>
		/// </returns>
		/// <remarks>An application can call <c>GetParameters</c> to obtain the default DDS parameters, modify some or all of them, and then call SetParameters.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicddsencoder-getparameters
		// HRESULT GetParameters( WICDdsParameters *pParameters );
		WICDdsParameters GetParameters();

		/// <summary>Creates a new frame to encode.</summary>
		/// <param name="ppIFrameEncode">A pointer to the newly created frame object.</param>
		/// <param name="pArrayIndex">Points to the location where the array index is returned.</param>
		/// <param name="pMipLevel">Points to the location where the mip level index is returned.</param>
		/// <param name="pSliceIndex">Points to the location where the slice index is returned.</param>
		/// <remarks>This is equivalent to IWICBitmapEncoder::CreateNewFrame, but returns additional information about the array index, mip level and slice of the newly created frame. In contrast to <c>IWICBitmapEncoder::CreateNewFrame</c>, there is no IPropertyBag2* parameter because individual DDS frames do not have separate properties.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicddsencoder-createnewframe
		// HRESULT CreateNewFrame( IWICBitmapFrameEncode **ppIFrameEncode, UINT *pArrayIndex, UINT *pMipLevel, UINT *pSliceIndex );
		void CreateNewFrame(out IWICBitmapFrameEncode ppIFrameEncode, out uint pArrayIndex, out uint pMipLevel, out uint pSliceIndex);
	}

	/// <summary>Exposes methods that provide access to the capabilites of a raw codec format.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicdevelopraw
	[PInvokeData("wincodec.h", MSDNShortId = "d449f3f7-fd43-44b0-ab7f-2ae307a74191")]
	[ComImport, Guid("fbec5e44-f7be-4b65-b7f8-c0c81fef026d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICDevelopRaw : IWICBitmapFrameDecode
	{
		/// <summary>Retrieves the pixel width and height of the bitmap.</summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel width of the bitmap.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the pixel height of the bitmap</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getsize HRESULT GetSize( UINT
		// *puiWidth, UINT *puiHeight );
		new void GetSize(out uint puiWidth, out uint puiHeight);

		/// <summary>Retrieves the pixel format of the bitmap source..</summary>
		/// <returns>
		/// Receives the pixel format GUID the bitmap is stored in. For a list of available pixel formats, see the Native Pixel Formats topic.
		/// </returns>
		/// <remarks>
		/// The pixel format returned by this method is not necessarily the pixel format the image is stored as. The codec may perform a
		/// format conversion from the storage pixel format to an output pixel format.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getpixelformat HRESULT
		// GetPixelFormat( Guid *pPixelFormat );
		new Guid GetPixelFormat();

		/// <summary>Retrieves the sampling rate between pixels and physical world measurements.</summary>
		/// <param name="pDpiX">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the x-axis dpi resolution.</para>
		/// </param>
		/// <param name="pDpiY">
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the y-axis dpi resolution.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Some formats, such as GIF and ICO, do not have full DPI support. For GIF, this method calculates the DPI values from the
		/// aspect ratio, using a base DPI of (96.0, 96.0). The ICO format does not support DPI at all, and the method always returns
		/// (96.0,96.0) for ICO images.
		/// </para>
		/// <para>
		/// Additionally, WIC itself does not transform images based on the DPI values in an image. It is up to the caller to transform
		/// an image based on the resolution returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-getresolution HRESULT GetResolution(
		// double *pDpiX, double *pDpiY );
		new void GetResolution(out double pDpiX, out double pDpiY);

		/// <summary>Retrieves the color table for indexed pixel formats.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>An IWICPalette. A palette can be created using the CreatePalette method.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WINCODEC_ERR_PALETTEUNAVAILABLE</term>
		/// <term>The palette was unavailable.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The palette was successfully copied.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the IWICBitmapSource is an IWICBitmapFrameDecode, the function may return the image's global palette if a frame-level
		/// palette is not available. The global palette may also be retrieved using the CopyPalette method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypalette HRESULT CopyPalette(
		// IWICPalette *pIPalette );
		[PreserveSig]
		new HRESULT CopyPalette(IWICPalette pIPalette);

		/// <summary>Instructs the object to produce pixels.</summary>
		/// <param name="prc">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle to copy. A <c>NULL</c> value specifies the entire bitmap.</para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The stride of the bitmap</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CopyPixels</c> is one of the two main image processing routines (the other being Lock) triggering the actual processing.
		/// It instructs the object to produce pixels according to its algorithm - this may involve decoding a portion of a JPEG stored
		/// on disk, copying a block of memory, or even analytically computing a complex gradient. The algorithm is completely dependent
		/// on the object implementing the interface.
		/// </para>
		/// <para>
		/// The caller can restrict the operation to a rectangle of interest (ROI) using the prc parameter. The ROI sub-rectangle must
		/// be fully contained in the bounds of the bitmap. Specifying a <c>NULL</c> ROI implies that the whole bitmap should be returned.
		/// </para>
		/// <para>
		/// The caller controls the memory management and must provide an output buffer (pbBuffer) for the results of the copy along
		/// with the buffer's bounds (cbBufferSize). The cbStride parameter defines the count of bytes between two vertically adjacent
		/// pixels in the output buffer. The caller must ensure that there is sufficient buffer to complete the call based on the width,
		/// height and pixel format of the bitmap and the sub-rectangle provided to the copy method.
		/// </para>
		/// <para>
		/// If the caller needs to perform numerous copies of an expensive IWICBitmapSource such as a JPEG, it is recommended to create
		/// an in-memory IWICBitmap first.
		/// </para>
		/// <para>Codec Developer Remarks</para>
		/// <para>
		/// The callee must only write to the first (prc-&gt;Width*bitsperpixel+7)/8 bytes of each line of the output buffer (in this
		/// case, a line is a consecutive string of cbStride bytes).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapsource-copypixels HRESULT CopyPixels( const
		// WICRect *prc, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer );
		new void CopyPixels([In, Optional] PWICRect? prc, uint cbStride, uint cbBufferSize, [In, Out] IntPtr pbBuffer);

		/// <summary>Retrieves a metadata query reader for the frame.</summary>
		/// <returns>
		/// <para>Type: <c>IWICMetadataQueryReader**</c></para>
		/// <para>When this method returns, contains a pointer to the frame's metadata query reader.</para>
		/// </returns>
		/// <remarks>
		/// For image formats with one frame (JPG, PNG, JPEG-XR), the frame-level query reader of the first frame is used to access all
		/// image metadata, and the decoder-level query reader isn’t used. For formats with more than one frame (GIF, TIFF), the
		/// frame-level query reader for a given frame is used to access metadata specific to that frame, and in the case of GIF a
		/// decoder-level metadata reader will be present. If the decoder doesn’t support metadata (BMP, ICO), this will return WINCODEC_ERR_UNSUPPORTEDOPERATION.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframedecode-getmetadataqueryreader HRESULT
		// GetMetadataQueryReader( IWICMetadataQueryReader **ppIMetadataQueryReader );
		new IWICMetadataQueryReader GetMetadataQueryReader();

		/// <summary>Retrieves the IWICColorContext associated with the image frame.</summary>
		/// <param name="cCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of color contexts to retrieve.</para>
		/// <para>This value must be the size of, or smaller than, the size available to ppIColorContexts.</para>
		/// </param>
		/// <param name="ppIColorContexts">
		/// <para>Type: <c>IWICColorContext**</c></para>
		/// <para>A pointer that receives a pointer to the IWICColorContext objects.</para>
		/// </param>
		/// <param name="pcActualCount">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the number of color contexts contained in the image frame.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If NULL is passed for ppIColorContexts, and 0 is passed for cCount, this method will return the total number of color
		/// contexts in the image in pcActualCount.
		/// </para>
		/// <para>
		/// The ppIColorContexts array must be filled with valid data: each IWICColorContext* in the array must have been created using IWICImagingFactory::CreateColorContext.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframedecode-getcolorcontexts HRESULT
		// GetColorContexts( UINT cCount, IWICColorContext **ppIColorContexts, UINT *pcActualCount );
		new void GetColorContexts(uint cCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IWICColorContext[] ppIColorContexts, out uint pcActualCount);

		/// <summary>Retrieves a small preview of the frame, if supported by the codec.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapSource**</c></para>
		/// <para>A pointer that receives a pointer to the IWICBitmapSource of the thumbnail.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Not all formats support thumbnails. Joint Photographic Experts Group (JPEG), Tagged Image File Format (TIFF), and Microsoft
		/// Windows Digital Photo (WDP) support thumbnails.
		/// </para>
		/// <para>Note to Implementers</para>
		/// <para>If the codec does not support thumbnails, return WINCODEC_ERROR_CODECNOTHUMBNAIL rather than E_NOTIMPL.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicbitmapframedecode-getthumbnail HRESULT
		// GetThumbnail( IWICBitmapSource **ppIThumbnail );
		new IWICBitmapSource GetThumbnail();

		/// <summary>Retrieves information about which capabilities are supported for a raw image.</summary>
		/// <returns>
		/// <para>Type: <c>WICRawCapabilitiesInfo*</c></para>
		/// <para>A pointer that receives WICRawCapabilitiesInfo that provides the capabilities supported by the raw image.</para>
		/// </returns>
		/// <remarks>It is recommended that a codec report that a capability is supported even if the results at the outer range limits are not of perfect quality.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-queryrawcapabilitiesinfo
		// HRESULT QueryRawCapabilitiesInfo( WICRawCapabilitiesInfo *pInfo );
		WICRawCapabilitiesInfo QueryRawCapabilitiesInfo();

		/// <summary>Sets the desired WICRawParameterSet option.</summary>
		/// <param name="ParameterSet">
		/// <para>Type: <c>WICRawParameterSet</c></para>
		/// <para>The desired WICRawParameterSet option.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-loadparameterset
		// HRESULT LoadParameterSet( WICRawParameterSet ParameterSet );
		void LoadParameterSet(WICRawParameterSet ParameterSet);

		/// <summary>Gets the current set of parameters.</summary>
		/// <returns>
		/// <para>Type: <c>IPropertyBag2**</c></para>
		/// <para>A pointer that receives a pointer to the current set of parameters.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getcurrentparameterset
		// HRESULT GetCurrentParameterSet( IPropertyBag2 **ppCurrentParameterSet );
		IPropertyBag2 GetCurrentParameterSet();

		/// <summary>Sets the exposure compensation stop value.</summary>
		/// <param name="ev">
		/// <para>Type: <c>double</c></para>
		/// <para>The exposure compensation value. The value range for exposure compensation is -5.0 through +5.0, which equates to 10 full stops.</para>
		/// </param>
		/// <remarks>It is recommended that a codec report that this method is supported even if the results at the outer range limits are not of perfect quality.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setexposurecompensation
		// HRESULT SetExposureCompensation( double ev );
		void SetExposureCompensation(double ev);

		/// <summary>Gets the exposure compensation stop value of the raw image.</summary>
		/// <returns>
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the exposure compensation stop value. The default is the "as-shot" setting.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getexposurecompensation
		// HRESULT GetExposureCompensation( double *pEV );
		double GetExposureCompensation();

		/// <summary>Sets the white point RGB values.</summary>
		/// <param name="Red">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The red white point value.</para>
		/// </param>
		/// <param name="Green">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The green white point value.</para>
		/// </param>
		/// <param name="Blue">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The blue white point value.</para>
		/// </param>
		/// <remarks>Due to other white point setting methods (e.g. SetWhitePointKelvin), care must be taken by codec implementers to ensure proper interoperability. For instance, if the caller sets via a named white point then the codec implementer may whis to disable reading back the correspoinding Kelvin temperature. In specific cases where the codec implementer wishes to deny a given action because of previous calls, <c>WINCODEC_ERR_WRONGSTATE</c> should be returned.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setwhitepointrgb
		// HRESULT SetWhitePointRGB( UINT Red, UINT Green, UINT Blue );
		void SetWhitePointRGB(uint Red, uint Green, uint Blue);

		/// <summary>Gets the white point RGB values.</summary>
		/// <param name="pRed">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the red white point value.</para>
		/// </param>
		/// <param name="pGreen">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the green white point value.</para>
		/// </param>
		/// <param name="pBlue">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the blue white point value.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getwhitepointrgb
		// HRESULT GetWhitePointRGB( UINT *pRed, UINT *pGreen, UINT *pBlue );
		void GetWhitePointRGB(out uint pRed, out uint pGreen, out uint pBlue);

		/// <summary>Sets the named white point of the raw file.</summary>
		/// <param name="WhitePoint">
		/// <para>Type: <c>WICNamedWhitePoint</c></para>
		/// <para>A bitwise combination of the enumeration values.</para>
		/// </param>
		/// <remarks>
		/// <para>If the named white points are not supported by the raw image or the raw file contains named white points that are not supported by this API, the codec implementer should still mark this capability as supported.</para>
		/// <para>If the named white points are not supported by the raw image, a best effort should be made to adjust the image to the named white point even when it isn't a pre-defined white point of the raw file.</para>
		/// <para>If the raw file containes named white points not supported by this API, the codec implementer should support the named white points in the API.</para>
		/// <para>Due to other white point setting methods (e.g. SetWhitePointKelvin), care must be taken by codec implementers to ensure proper interoperability. For instance, if the caller sets via a named white point then the codec implementer may whis to disable reading back the correspoinding Kelvin temperature. In specific cases where the codec implementer wishes to deny a given action because of previous calls, <c>WINCODEC_ERR_WRONGSTATE</c> should be returned.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setnamedwhitepoint
		// HRESULT SetNamedWhitePoint( WICNamedWhitePoint WhitePoint );
		void SetNamedWhitePoint(WICNamedWhitePoint WhitePoint);

		/// <summary>Gets the named white point of the raw image.</summary>
		/// <returns>
		/// <para>Type: <c>WICNamedWhitePoint*</c></para>
		/// <para>A pointer that receives the bitwise combination of the enumeration values.</para>
		/// </returns>
		/// <remarks>
		/// <para>If the named white points are not supported by the raw image or the raw file contains named white points that are not supported by this API, the codec implementer should still mark this capability as supported.</para>
		/// <para>If the named white points are not supported by the raw image, a best effort should be made to adjust the image to the named white point even when it isn't a pre-defined white point of the raw file.</para>
		/// <para>If the raw file containes named white points not supported by this API, the codec implementer should support the named white points in WICNamedWhitePoint.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getnamedwhitepoint
		// HRESULT GetNamedWhitePoint( WICNamedWhitePoint *pWhitePoint );
		WICNamedWhitePoint GetNamedWhitePoint();

		/// <summary>Sets the white point Kelvin value.</summary>
		/// <param name="WhitePointKelvin">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The white point Kelvin value. Acceptable Kelvin values are 1,500 through 30,000.</para>
		/// </param>
		/// <remarks>
		/// <para>Codec implementers should faithfully adjust the color temperature within the range supported natively by the raw image. For values outside the native support range, the codec implementer should provide a best effort representation of the image at that color temperature.</para>
		/// <para>Codec implementers should return <c>WINCODEC_ERR_VALUEOUTOFRANGE</c> if the value is out of defined acceptable range.</para>
		/// <para>Codec implementers must ensure proper interoperability with other white point setting methods such as SetWhitePointRGB. For example, if the caller sets the white point via SetNamedWhitePoint then the codec implementer may want to disable reading back the correspoinding Kelvin temperature. In specific cases where the codec implementer wants to deny a given action because of previous calls, <c>WINCODEC_ERR_WRONGSTATE</c> should be returned.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setwhitepointkelvin
		// HRESULT SetWhitePointKelvin( UINT WhitePointKelvin );
		void SetWhitePointKelvin(uint WhitePointKelvin);

		/// <summary>Gets the white point Kelvin temperature of the raw image.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the white point Kelvin temperature of the raw image. The default is the "as-shot" setting value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getwhitepointkelvin
		// HRESULT GetWhitePointKelvin( UINT *pWhitePointKelvin );
		uint GetWhitePointKelvin();

		/// <summary>Gets the information about the current Kelvin range of the raw image.</summary>
		/// <param name="pMinKelvinTemp">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the minimum Kelvin temperature.</para>
		/// </param>
		/// <param name="pMaxKelvinTemp">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the maximum Kelvin temperature.</para>
		/// </param>
		/// <param name="pKelvinTempStepValue">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the Kelvin step value.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getkelvinrangeinfo
		// HRESULT GetKelvinRangeInfo( UINT *pMinKelvinTemp, UINT *pMaxKelvinTemp, UINT *pKelvinTempStepValue );
		void GetKelvinRangeInfo(out uint pMinKelvinTemp, out uint pMaxKelvinTemp, out uint pKelvinTempStepValue);

		/// <summary>Sets the contrast value of the raw image.</summary>
		/// <param name="Contrast">
		/// <para>Type: <c>double</c></para>
		/// <para>The contrast value of the raw image. The default value is the "as-shot" setting. The value range for contrast is 0.0 through 1.0. The 0.0 lower limit represents no contrast applied to the image, while the 1.0 upper limit represents the highest amount of contrast that can be applied.</para>
		/// </param>
		/// <remarks>The codec implementer must determine what the upper range value represents and must determine how to map the value to their image processing routines.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setcontrast
		// HRESULT SetContrast( double Contrast );
		void SetContrast(double Contrast);

		/// <summary>Gets the contrast value of the raw image.</summary>
		/// <returns>
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the contrast value of the raw image. The default value is the "as-shot" setting. The value range for contrast is 0.0 through 1.0. The 0.0 lower limit represents no contrast applied to the image, while the 1.0 upper limit represents the highest amount of contrast that can be applied.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getcontrast
		// HRESULT GetContrast( double *pContrast );
		double GetContrast();

		/// <summary>Sets the desired gamma value.</summary>
		/// <param name="Gamma">
		/// <para>Type: <c>double</c></para>
		/// <para>The desired gamma value.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setgamma
		// HRESULT SetGamma( double Gamma );
		void SetGamma(double Gamma);

		/// <summary>Gets the current gamma setting of the raw image.</summary>
		/// <returns>
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the current gamma setting.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getgamma
		// HRESULT GetGamma( double *pGamma );
		double GetGamma();

		/// <summary>Sets the sharpness value of the raw image.</summary>
		/// <param name="Sharpness">
		/// <para>Type: <c>double</c></para>
		/// <para>The sharpness value of the raw image. The default value is the "as-shot" setting. The value range for sharpness is 0.0 through 1.0. The 0.0 lower limit represents no sharpening applied to the image, while the 1.0 upper limit represents the highest amount of sharpness that can be applied.</para>
		/// </param>
		/// <remarks>The codec implementer must determine what the upper range value represents and must determine how to map the value to their image processing routines.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setsharpness
		// HRESULT SetSharpness( double Sharpness );
		void SetSharpness(double Sharpness);

		/// <summary>Gets the sharpness value of the raw image.</summary>
		/// <returns>
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the sharpness value of the raw image. The default value is the "as-shot" setting. The value range for sharpness is 0.0 through 1.0. The 0.0 lower limit represents no sharpening applied to the image, while the 1.0 upper limit represents the highest amount of sharpness that can be applied.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getsharpness
		// HRESULT GetSharpness( double *pSharpness );
		double GetSharpness();

		/// <summary>Sets the saturation value of the raw image.</summary>
		/// <param name="Saturation">
		/// <para>Type: <c>double</c></para>
		/// <para>The saturation value of the raw image. The value range for saturation is 0.0 through 1.0. A value of 0.0 represents an image with a fully de-saturated image, while a value of 1.0 represents the highest amount of saturation that can be applied.</para>
		/// </param>
		/// <remarks>The codec implementer must determine what the upper range value represents and must determine how to map the value to their image processing routines.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setsaturation
		// HRESULT SetSaturation( double Saturation );
		void SetSaturation(double Saturation);

		/// <summary>Gets the saturation value of the raw image.</summary>
		/// <returns>
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the saturation value of the raw image. The default value is the "as-shot" setting. The value range for saturation is 0.0 through 1.0. A value of 0.0 represents an image with a fully de-saturated image, while a value of 1.0 represents the highest amount of saturation that can be applied.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getsaturation
		// HRESULT GetSaturation( double *pSaturation );
		double GetSaturation();

		/// <summary>Sets the tint value of the raw image.</summary>
		/// <param name="Tint">
		/// <para>Type: <c>double</c></para>
		/// <para>The tint value of the raw image. The default value is the "as-shot" setting if it exists or 0.0. The value range for sharpness is -1.0 through +1.0. The -1.0 lower limit represents a full green bias to the image, while the 1.0 upper limit represents a full magenta bias.</para>
		/// </param>
		/// <remarks>The codec implementer must determine what the outer range values represent and must determine how to map the values to their image processing routines.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-settint
		// HRESULT SetTint( double Tint );
		void SetTint(double Tint);

		/// <summary>Gets the tint value of the raw image.</summary>
		/// <returns>
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the tint value of the raw image. The default value is the "as-shot" setting if it exists or 0.0. The value range for sharpness is -1.0 through +1.0. The -1.0 lower limit represents a full green bias to the image, while the 1.0 upper limit represents a full magenta bias.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-gettint
		// HRESULT GetTint( double *pTint );
		double GetTint();

		/// <summary>Sets the noise reduction value of the raw image.</summary>
		/// <param name="NoiseReduction">
		/// <para>Type: <c>double</c></para>
		/// <para>The noise reduction value of the raw image. The default value is the "as-shot" setting if it exists or 0.0. The value range for noise reduction is 0.0 through 1.0. The 0.0 lower limit represents no noise reduction applied to the image, while the 1.0 upper limit represents highest noise reduction amount that can be applied.</para>
		/// </param>
		/// <remarks>The codec implementer must determine what the upper range value represents and must determine how to map the value to their image processing routines.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setnoisereduction
		// HRESULT SetNoiseReduction( double NoiseReduction );
		void SetNoiseReduction(double NoiseReduction);

		/// <summary>Gets the noise reduction value of the raw image.</summary>
		/// <returns>
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the noise reduction value of the raw image. The default value is the "as-shot" setting if it exists or 0.0. The value range for noise reduction is 0.0 through 1.0. The 0.0 lower limit represents no noise reduction applied to the image, while the 1.0 upper limit represents full highest noise reduction amount that can be applied.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getnoisereduction
		// HRESULT GetNoiseReduction( double *pNoiseReduction );
		double GetNoiseReduction();

		/// <summary>Sets the destination color context.</summary>
		/// <param name="pColorContext">
		/// <para>Type: <c>const IWICColorContext*</c></para>
		/// <para>The destination color context.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setdestinationcolorcontext
		// HRESULT SetDestinationColorContext( IWICColorContext *pColorContext );
		void SetDestinationColorContext(IWICColorContext pColorContext);

		/// <summary>Sets the tone curve for the raw image.</summary>
		/// <param name="cbToneCurveSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pToneCurve structure.</para>
		/// </param>
		/// <param name="pToneCurve">
		/// <para>Type: <c>const WICRawToneCurve*</c></para>
		/// <para>The desired tone curve.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-settonecurve
		// HRESULT SetToneCurve( UINT cbToneCurveSize, const WICRawToneCurve *pToneCurve );
		void SetToneCurve(uint cbToneCurveSize, [In] ManagedStructPointer<WICRawToneCurve> pToneCurve);

		/// <summary>Gets the tone curve of the raw image.</summary>
		/// <param name="cbToneCurveBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pToneCurve buffer.</para>
		/// </param>
		/// <param name="pToneCurve">
		/// <para>Type: <c>WICRawToneCurve*</c></para>
		/// <para>A pointer that receives the WICRawToneCurve of the raw image.</para>
		/// </param>
		/// <param name="pcbActualToneCurveBufferSize">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>A pointer that receives the size needed to obtain the tone curve structure.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-gettonecurve
		// HRESULT GetToneCurve( UINT cbToneCurveBufferSize, WICRawToneCurve *pToneCurve, UINT *pcbActualToneCurveBufferSize );
		void GetToneCurve(uint cbToneCurveBufferSize, [Out] ManagedStructPointer<WICRawToneCurve> pToneCurve, out uint pcbActualToneCurveBufferSize);

		/// <summary>Sets the desired rotation angle.</summary>
		/// <param name="Rotation">
		/// <para>Type: <c>double</c></para>
		/// <para>The desired rotation angle.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setrotation
		// HRESULT SetRotation( double Rotation );
		void SetRotation(double Rotation);

		/// <summary>Gets the current rotation angle.</summary>
		/// <returns>
		/// <para>Type: <c>double*</c></para>
		/// <para>A pointer that receives the current rotation angle.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getrotation
		// HRESULT GetRotation( double *pRotation );
		double GetRotation();

		/// <summary>Sets the current WICRawRenderMode.</summary>
		/// <param name="RenderMode">
		/// <para>Type: <c>WICRawRenderMode</c></para>
		/// <para>The render mode to use.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setrendermode
		// HRESULT SetRenderMode( WICRawRenderMode RenderMode );
		void SetRenderMode(WICRawRenderMode RenderMode);

		/// <summary>Gets the current WICRawRenderMode.</summary>
		/// <returns>
		/// <para>Type: <c>WICRawRenderMode*</c></para>
		/// <para>A pointer that receives the current WICRawRenderMode.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-getrendermode
		// HRESULT GetRenderMode( WICRawRenderMode *pRenderMode );
		WICRawRenderMode GetRenderMode();

		/// <summary>Sets the notification callback method.</summary>
		/// <param name="pCallback">
		/// <para>Type: <c>IWICDevelopRawNotificationCallback*</c></para>
		/// <para>Pointer to the notification callback method.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdevelopraw-setnotificationcallback
		// HRESULT SetNotificationCallback( IWICDevelopRawNotificationCallback *pCallback );
		void SetNotificationCallback(IWICDevelopRawNotificationCallback pCallback);
	}

	/// <summary>Exposes a callback method for raw image change nofications.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicdeveloprawnotificationcallback
	[PInvokeData("wincodec.h", MSDNShortId = "ccd162e4-84be-4ed5-a583-c9bd195f503b")]
	[ComImport, Guid("95c75a6e-3e8c-4ec2-85a8-aebcc551e59b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICDevelopRawNotificationCallback
	{
		/// <summary>An application-defined callback method used for raw image parameter change notifications.</summary>
		/// <param name="NotificationMask">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A set of IWICDevelopRawNotificationCallback Constants parameter notification flags.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicdeveloprawnotificationcallback-notify
		// HRESULT Notify( UINT NotificationMask );
		[PreserveSig]
		HRESULT Notify(WICRawChangeNotification NotificationMask);
	}
}