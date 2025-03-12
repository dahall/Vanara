using static Vanara.PInvoke.D2d1;

namespace Vanara.PInvoke;

public static partial class WindowsCodecs
{
	private delegate void GetArrayAction<T>(uint cbSize, T[]? value, out uint actualSize);

	private delegate void GetStringAction(uint cbSize, StringBuilder? value, out uint actualSize);

	/// <summary>
	/// Provides access to a single frame of DDS image data in its native DXGI_FORMAT form, as well as information about the image data.
	/// </summary>
	/// <remarks>
	/// This interface is implemented by the WIC DDS codec. To obtain this interface, create an IWICBitmapFrameDecode using the DDS
	/// codec and QueryInterface for IID_IWICDdsFrameDecode.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicddsframedecode
	[PInvokeData("wincodec.h", MSDNShortId = "52E76A8D-E7E2-46F5-BBCC-B7C74F1B1122")]
	[ComImport, Guid("3d4c0c61-18a4-41e4-bd80-481a4fc9f464"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICDdsFrameDecode
	{
		/// <summary>Gets the width and height, in blocks, of the DDS image.</summary>
		/// <param name="pWidthInBlocks">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The width of the DDS image in blocks.</para>
		/// </param>
		/// <param name="pHeightInBlocks">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The height of the DDS image in blocks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// For block compressed textures, the returned width and height values do not completely define the texture size because the
		/// image is padded to fit the closest whole block size. For example, three BC1 textures with pixel dimensions of 1x1, 2x2 and
		/// 4x4 will all report pWidthInBlocks = 1 and pHeightInBlocks = 1.
		/// </para>
		/// <para>
		/// If the texture does not use a block-compressed DXGI_FORMAT, this method returns the texture size in pixels; for these
		/// formats the block size returned by IWICDdsFrameDecoder::GetFormatInfo is 1x1.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicddsframedecode-getsizeinblocks HRESULT
		// GetSizeInBlocks( UINT *pWidthInBlocks, UINT *pHeightInBlocks );
		void GetSizeInBlocks(out uint pWidthInBlocks, out uint pHeightInBlocks);

		/// <summary>Gets information about the format in which the DDS image is stored.</summary>
		/// <returns>
		/// <para>Type: <c>WICDdsFormatInfo*</c></para>
		/// <para>Information about the DDS format.</para>
		/// </returns>
		/// <remarks>
		/// This information can be used for allocating memory or constructing Direct3D or Direct2D resources, for example by using
		/// ID3D11Device::CreateTexture2D or ID2D1DeviceContext::CreateBitmap.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicddsframedecode-getformatinfo HRESULT
		// GetFormatInfo( WICDdsFormatInfo *pFormatInfo );
		WICDdsFormatInfo GetFormatInfo();

		/// <summary>Requests pixel data as it is natively stored within the DDS file.</summary>
		/// <param name="prcBoundsInBlocks">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The rectangle to copy from the source. A NULL value specifies the entire texture.</para>
		/// <para>
		/// If the texture uses a block-compressed DXGI_FORMAT, all values of the rectangle are expressed in number of blocks, not pixels.
		/// </para>
		/// </param>
		/// <param name="cbStride">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The stride, in bytes, of the destination buffer. This represents the number of bytes from the buffer pointer to the next row
		/// of data. If the texture uses a block-compressed DXGI_FORMAT, a "row of data" is defined as a row of blocks which contains
		/// multiple pixel scanlines.
		/// </para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size, in bytes, of the destination buffer.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the destination buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the texture does not use a block-compressed DXGI_FORMAT, this method behaves similarly to IWICBitmapSource::CopyPixels.
		/// However, it does not perform any pixel format conversion, and instead produces the raw data from the DDS file.
		/// </para>
		/// <para>
		/// If the texture uses a block-compressed DXGI_FORMAT, this method copies the block data directly into the provided buffer. In
		/// this case, the prcBoundsInBlocks parameter is defined in blocks, not pixels. To determine if this is the case, call
		/// GetFormatInfo and read the <c>DxgiFormat</c> member of the returned WICDdsFormatInfo structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicddsframedecode-copyblocks HRESULT CopyBlocks(
		// const WICRect *prcBoundsInBlocks, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer );
		void CopyBlocks([In, Optional] PWICRect? prcBoundsInBlocks, uint cbStride, uint cbBufferSize, [Out] IntPtr pbBuffer);
	}

	/// <summary>Exposes methods that provide enumeration services for individual metadata items.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicenummetadataitem
	[PInvokeData("wincodec.h", MSDNShortId = "4fe0e47f-9ef4-4aa1-a3ae-578b3759f9ef")]
	[ComImport, Guid("DC2BB46D-3F07-481E-8625-220C4AEDBB33"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICEnumMetadataItem
	{
		/// <summary>Advanced the current position in the enumeration.</summary>
		/// <param name="celt">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of items to be retrieved.</para>
		/// </param>
		/// <param name="rgeltSchema">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>An array of enumerated items. This parameter is optional.</para>
		/// </param>
		/// <param name="rgeltId">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>An array of enumerated items.</para>
		/// </param>
		/// <param name="rgeltValue">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>An array of enumerated items. This parameter is optional.</para>
		/// </param>
		/// <param name="pceltFetched">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>The number of items that were retrieved. This value is always less than or equal to the number of items requested.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicenummetadataitem-next HRESULT Next( ULONG celt,
		// PROPVARIANT *rgeltSchema, PROPVARIANT *rgeltId, PROPVARIANT *rgeltValue, ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Optional] PROPVARIANT_IMMUTABLE[]? rgeltSchema,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPVARIANT_IMMUTABLE[] rgeltId,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Optional] PROPVARIANT_IMMUTABLE[]? rgeltValue, out uint pceltFetched);

		/// <summary>Skips to given number of objects.</summary>
		/// <param name="celt">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of objects to skip.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicenummetadataitem-skip HRESULT Skip( ULONG celt );
		[PreserveSig]
		HRESULT Skip(uint celt);

		/// <summary>Resets the current position to the beginning of the enumeration.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicenummetadataitem-reset HRESULT Reset();
		void Reset();

		/// <summary>Creates a copy of the current IWICEnumMetadataItem.</summary>
		/// <returns>
		/// <para>Type: <c>IWICEnumMetadataItem**</c></para>
		/// <para>A pointer that receives a pointer to the IWICEnumMetadataItem copy.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicenummetadataitem-clone HRESULT Clone(
		// IWICEnumMetadataItem **ppIEnumMetadataItem );
		IWICEnumMetadataItem Clone();
	}

	/// <summary>
	/// Exposes methods used for in-place metadata editing. A fast metadata encoder enables you to add and remove metadata to an image
	/// without having to fully re-encode the image.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A decoder must be created using the WICDecodeOptions value <c>WICDecodeMetadataCacheOnDemand</c> to perform in-place metadata
	/// updates. Using the <c>WICDecodeMetadataCacheOnLoad</c> option causes the decoder to release the file stream necessary to perform
	/// the metadata updates.
	/// </para>
	/// <para>
	/// Not all metadata formats support fast metadata encoding. The native metadata handlers that support metadata are IFD, Exif, XMP,
	/// and GPS.
	/// </para>
	/// <para>If a fast metadata encoder fails, the image will need to be fully re-encoded to add the metadata.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following demonstrates how to obtain a fast metadata encoder from an image frame and use its query writer to write a
	/// metadata item.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicfastmetadataencoder
	[PInvokeData("wincodec.h", MSDNShortId = "c7b57a71-f1fe-4e30-a52e-72ab6ce021f7")]
	[ComImport, Guid("B84E2C09-78C9-4AC4-8BD3-524AE1663A2F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICFastMetadataEncoder
	{
		/// <summary>Finalizes metadata changes to the image stream.</summary>
		/// <remarks>
		/// <para>
		/// If the commit fails and returns <c>WINCODEC_ERR_STREAMNOTAVAILABLE</c>, ensure that the image decoder was loaded using the
		/// <c>WICDecodeMetadataCacheOnDemand</c> option. A fast metadata encoder is not supported when the decoder is created using the
		/// <c>WICDecodeMetadataCacheOnLoad</c> option.
		/// </para>
		/// <para>
		/// If the commit fails for any reason, you will need to re-encode the image to ensure the new metadata is added to the image.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicfastmetadataencoder-commit HRESULT Commit();
		void Commit();

		/// <summary>Retrieves a metadata query writer for fast metadata encoding.</summary>
		/// <returns>
		/// <para>Type: <c>IWICMetadataQueryWriter**</c></para>
		/// <para>When this method returns, contains a pointer to the fast metadata encoder's metadata query writer.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicfastmetadataencoder-getmetadataquerywriter
		// HRESULT GetMetadataQueryWriter( IWICMetadataQueryWriter **ppIMetadataQueryWriter );
		IWICMetadataQueryWriter GetMetadataQueryWriter();
	}

	/// <summary>
	/// Represents an IWICBitmapSource that converts the image data from one pixel format to another, handling dithering and halftoning
	/// to indexed formats, palette translation and alpha thresholding.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicformatconverter
	[PInvokeData("wincodec.h", MSDNShortId = "d558aaa7-5962-424c-9e83-363fba09ad50")]
	[ComImport, Guid("00000301-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICFormatConverter : IWICBitmapSource
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

		/// <summary>Initializes the format converter.</summary>
		/// <param name="pISource">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The input bitmap to convert</para>
		/// </param>
		/// <param name="dstFormat">
		/// <para>Type: <c>REFWICPixelFormatGUID</c></para>
		/// <para>The destination pixel format GUID.</para>
		/// </param>
		/// <param name="dither">
		/// <para>Type: <c>WICBitmapDitherType</c></para>
		/// <para>The WICBitmapDitherType used for conversion.</para>
		/// </param>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>The palette to use for conversion.</para>
		/// </param>
		/// <param name="alphaThresholdPercent">
		/// <para>Type: <c>double</c></para>
		/// <para>The alpha threshold to use for conversion.</para>
		/// </param>
		/// <param name="paletteTranslate">
		/// <para>Type: <c>WICBitmapPaletteType</c></para>
		/// <para>The palette translation type to use for conversion.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you do not have a predefined palette, you must first create one. Use InitializeFromBitmap to create the palette object,
		/// then pass it in along with your other parameters.
		/// </para>
		/// <para>
		/// dither, pIPalette, alphaThresholdPercent, and paletteTranslate are used to mitigate color loss when converting to a reduced
		/// bit-depth format. For conversions that do not need these settings, the following parameters values should be used: dither
		/// set to <c>WICBitmapDitherTypeNone</c>, pIPalette set to <c>NULL</c>, alphaThresholdPercent set to <c>0.0f</c>, and
		/// paletteTranslate set to <c>WICBitmapPaletteTypeCustom</c>.
		/// </para>
		/// <para>
		/// The basic algorithm involved when using an ordered dither requires a fixed palette, found in the WICBitmapPaletteType
		/// enumeration, in a specific order. Often, the actual palette provided for the output may have a different ordering or some
		/// slight variation in the actual colors. This is the case when using the Microsoft Windows palette which has slight
		/// differences among versions of Windows. To provide for this, a palette and a palette translation are given to the format
		/// converter. The pIPalette is the actual destination palette to be used and the paletteTranslate is a fixed palette. Once the
		/// conversion is complete, the colors are mapped from the fixed palette to the actual colors in pIPalette using a nearest color
		/// matching algorithm.
		/// </para>
		/// <para>
		/// <c>WICBitmapDitherTypeOrdered4x4</c> can be useful in format conversions from 8-bit formats to 5- or 6-bit formats as there
		/// is no way to accurately convert color data.
		/// </para>
		/// <para>
		/// <c>WICBitmapDitherTypeErrorDiffusion</c> selects the error diffusion algorithm and may be used with any palette. If an
		/// arbitrary palette is provided, <c>WICBitmapPaletteCustom</c> should be passed in as the paletteTranslate. Error diffusion
		/// often provides superior results compared to the ordered dithering algorithms especially when combined with the optimized
		/// palette generation functionality on the IWICPalette.
		/// </para>
		/// <para>
		/// Some 8bpp content can contains an alpha color; for instance, the Graphics Interchange Format (GIF) format allows for a
		/// single palette entry to be used as a transparent color. For this type of content, alphaThresholdPercent specifies what
		/// percentage of transparency should map to the transparent color. Because the alpha value is directly proportional to the
		/// opacity (not transparency) of a pixel, the alphaThresholdPercent indicates what level of opacity is mapped to the fully
		/// transparent color. For instance, 9.8% implies that any pixel with an alpha value of less than 25 will be mapped to the
		/// transparent color. A value of 100% maps all pixels which are not fully opaque to the transparent color. Note that the
		/// palette should provide a transparent color. If it does not, the 'transparent' color will be the one closest to zero - often black.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example converts an image frame to a 32bppPBGRA format with no dithering or alpha threshold. Direct2D requires
		/// bitmap sources to be in the a 32bppPBGRA format for rendering. For a full sample demonstrating the use of the
		/// IWICFormatConverter, see the WIC Image Viewer Using Direct2D Sample.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicformatconverter-initialize HRESULT Initialize(
		// IWICBitmapSource *pISource, REFWICPixelFormatGUID dstFormat, WICBitmapDitherType dither, IWICPalette *pIPalette, double
		// alphaThresholdPercent, WICBitmapPaletteType paletteTranslate );
		void Initialize(IWICBitmapSource pISource, in Guid dstFormat, WICBitmapDitherType dither, [Optional] IWICPalette? pIPalette, double alphaThresholdPercent, WICBitmapPaletteType paletteTranslate);

		/// <summary>Determines if the source pixel format can be converted to the destination pixel format.</summary>
		/// <param name="srcPixelFormat">
		/// <para>Type: <c>REFWICPixelFormatGUID</c></para>
		/// <para>The source pixel format.</para>
		/// </param>
		/// <param name="dstPixelFormat">
		/// <para>Type: <c>REFWICPixelFormatGUID</c></para>
		/// <para>The destionation pixel format.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer that receives a value indicating whether the source pixel format can be converted to the destination pixel format.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicformatconverter-canconvert HRESULT CanConvert(
		// REFWICPixelFormatGUID srcPixelFormat, REFWICPixelFormatGUID dstPixelFormat, BOOL *pfCanConvert );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool CanConvert(in Guid srcPixelFormat, in Guid dstPixelFormat);
	}

	/// <summary>Exposes methods that provide information about a pixel format converter.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicformatconverterinfo
	[PInvokeData("wincodec.h", MSDNShortId = "e6e2bade-66c1-4994-89b9-68aa038bdc8c")]
	[ComImport, Guid("9F34FB65-13F4-4f15-BC57-3726B5E53D9F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICFormatConverterInfo : IWICComponentInfo
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

		/// <summary>Retrieves a list of GUIDs that signify which pixel formats the converter supports.</summary>
		/// <param name="cFormats">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pPixelFormatGUIDs array.</para>
		/// </param>
		/// <param name="pPixelFormatGUIDs">
		/// <para>Type: <c>WICPixelFormatGUID*</c></para>
		/// <para>Pointer to a GUID array that receives the pixel formats the converter supports.</para>
		/// </param>
		/// <param name="pcActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual array size needed to retrieve all pixel formats supported by the converter.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The format converter does not necessarily guarantee symmetricality with respect to conversion; that is, a converter may be
		/// able to convert FROM a particular format without actually being able to convert TO a particular format. In order to test
		/// symmetricality, use CanConvert.
		/// </para>
		/// <para>
		/// To determine the number of pixel formats a coverter can handle, set cFormats to and pPixelFormatGUIDs to . The converter
		/// will fill pcActual with the number of formats supported by that converter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicformatconverterinfo-getpixelformats HRESULT
		// GetPixelFormats( UINT cFormats, WICPixelFormatGUID *pPixelFormatGUIDs, UINT *pcActual );
		void GetPixelFormats(uint cFormats, [In] Guid[] pPixelFormatGUIDs, out uint pcActual);

		/// <summary>Creates a new IWICFormatConverter instance.</summary>
		/// <returns>
		/// <para>Type: <c>IWICFormatConverter**</c></para>
		/// <para>A pointer that receives a new IWICFormatConverter instance.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicformatconverterinfo-createinstance HRESULT
		// CreateInstance( IWICFormatConverter **ppIConverter );
		IWICFormatConverter CreateInstance();
	}

	/// <summary>
	/// Encodes ID2D1Image interfaces to an IWICBitmapEncoder. The input images can be larger than the maximum device texture size.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicimageencoder
	[PInvokeData("wincodec.h", MSDNShortId = "D9854D82-0226-4DD8-AE54-93E5B6544B46")]
	[ComImport, Guid("04C75BF8-3CE1-473B-ACC5-3CC4F5E94999"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICImageEncoder
	{
		/// <summary>Encodes the image to the frame given by the IWICBitmapFrameEncode.</summary>
		/// <param name="pImage">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The Direct2D image that will be encoded.</para>
		/// </param>
		/// <param name="pFrameEncode">
		/// <para>Type: <c>IWICBitmapFrameEncode*</c></para>
		/// <para>The frame encoder to which the image is written.</para>
		/// </param>
		/// <param name="pImageParameters">
		/// <para>Type: <c>const WICImageParameters*</c></para>
		/// <para>Additional parameters to control encoding.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The image passed in must be created on the same device as in IWICImagingFactory2::CreateImageEncoder. If the
		/// pImageParameters are not specified, a set of useful defaults will be assumed, see WICImageParameters for more info.
		/// </para>
		/// <para>You must correctly and independently have set up the IWICBitmapFrameEncode before calling this API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimageencoder-writeframe HRESULT WriteFrame(
		// ID2D1Image *pImage, IWICBitmapFrameEncode *pFrameEncode, const WICImageParameters *pImageParameters );
		void WriteFrame(ID2D1Image pImage, IWICBitmapFrameEncode pFrameEncode, in WICImageParameters pImageParameters);

		/// <summary>Encodes the image as a thumbnail to the frame given by the IWICBitmapFrameEncode.</summary>
		/// <param name="pImage">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The Direct2D image that will be encoded.</para>
		/// </param>
		/// <param name="pFrameEncode">
		/// <para>Type: <c>IWICBitmapFrameEncode*</c></para>
		/// <para>The frame encoder on which the thumbnail is set.</para>
		/// </param>
		/// <param name="pImageParameters">
		/// <para>Type: <c>const WICImageParameters*</c></para>
		/// <para>Additional parameters to control encoding.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The image passed in must be created on the same device as in IWICImagingFactory2::CreateImageEncoder. If the
		/// pImageParameters are not specified, a set of useful defaults will be assumed, see WICImageParameters for more info.
		/// </para>
		/// <para>You must correctly and independently have set up the IWICBitmapFrameEncode before calling this API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimageencoder-writeframethumbnail HRESULT
		// WriteFrameThumbnail( ID2D1Image *pImage, IWICBitmapFrameEncode *pFrameEncode, const WICImageParameters *pImageParameters );
		void WriteFrameThumbnail(ID2D1Image pImage, IWICBitmapFrameEncode pFrameEncode, in WICImageParameters pImageParameters);

		/// <summary>Encodes the given image as the thumbnail to the given WIC bitmap encoder.</summary>
		/// <param name="pImage">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The Direct2D image that will be encoded.</para>
		/// </param>
		/// <param name="pEncoder">
		/// <para>Type: <c>IWICBitmapEncoder*</c></para>
		/// <para>The encoder on which the thumbnail is set.</para>
		/// </param>
		/// <param name="pImageParameters">
		/// <para>Type: <c>const WICImageParameters*</c></para>
		/// <para>Additional parameters to control encoding.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// You must create the image that you pass in on the same device as in IWICImagingFactory2::CreateImageEncoder. If you don't
		/// specify additional parameters in the variable that pImageParameters points to, the encoder uses a set of useful defaults.
		/// For info about these defaults, see WICImageParameters.
		/// </para>
		/// <para>
		/// Before you call <c>WriteThumbnail</c>, you must set up the IWICBitmapEncoder interface for the encoder on which you want to
		/// set the thumbnail.
		/// </para>
		/// <para>
		/// If <c>WriteThumbnail</c> fails, it might return E_OUTOFMEMORY, D2DERR_WRONG_RESOURCE_DOMAIN, or other error codes from the encoder.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimageencoder-writethumbnail HRESULT
		// WriteThumbnail( ID2D1Image *pImage, IWICBitmapEncoder *pEncoder, const WICImageParameters *pImageParameters );
		void WriteThumbnail(ID2D1Image pImage, IWICBitmapEncoder pEncoder, in WICImageParameters pImageParameters);
	}

	/// <summary>
	/// Exposes methods used to create components for the Windows Imaging Component (WIC) such as decoders, encoders and pixel format converters.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicimagingfactory
	[PInvokeData("wincodec.h", MSDNShortId = "30d155b1-a46c-46c4-9f8f-fb56dc6bf0a9")]
	[ComImport, Guid("ec5ec8a9-c395-4314-9c77-54d7a935ff70"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(WICImagingFactory))]
	public interface IWICImagingFactory
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createdecoderfromfilename HRESULT
		// CreateDecoderFromFilename( LPCWSTR wzFilename, const GUID *pguidVendor, DWORD dwDesiredAccess, WICDecodeOptions
		// metadataOptions, IWICBitmapDecoder **ppIDecoder );
		IWICBitmapDecoder CreateDecoderFromFilename([MarshalAs(UnmanagedType.LPWStr)] string wzFilename, [In] SafeGuidPtr pguidVendor, ACCESS_MASK dwDesiredAccess, WICDecodeOptions metadataOptions);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createdecoderfromstream HRESULT
		// CreateDecoderFromStream( IStream *pIStream, const GUID *pguidVendor, WICDecodeOptions metadataOptions, IWICBitmapDecoder
		// **ppIDecoder );
		IWICBitmapDecoder CreateDecoderFromStream(IStream pIStream, [In] SafeGuidPtr pguidVendor, WICDecodeOptions metadataOptions);

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
		// HRESULT CreateDecoderFromFileHandle( ULONG_PTR hFile, const GUID *pguidVendor, WICDecodeOptions metadataOptions,
		// IWICBitmapDecoder **ppIDecoder );
		IWICBitmapDecoder CreateDecoderFromFileHandle(HFILE hFile, [In] SafeGuidPtr pguidVendor, WICDecodeOptions metadataOptions);

		/// <summary>Creates a new instance of the IWICComponentInfo class for the given component class identifier (CLSID).</summary>
		/// <param name="clsidComponent">
		/// <para>Type: <c>REFCLSID</c></para>
		/// <para>The CLSID for the desired component.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICComponentInfo**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICComponentInfo.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcomponentinfo HRESULT
		// CreateComponentInfo( REFCLSID clsidComponent, IWICComponentInfo **ppIInfo );
		IWICComponentInfo CreateComponentInfo(in Guid clsidComponent);

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
		/// <para>
		/// A pointer that receives a pointer to a new IWICBitmapDecoder. You must initialize this <c>IWICBitmapDecoder</c> on a stream
		/// using the Initialize method later.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Other values may be available for both guidContainerFormat and pguidVendor depending on the installed WIC-enabled encoders.
		/// The values listed are those that are natively supported by the operating system.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createdecoder HRESULT
		// CreateDecoder( REFGUID guidContainerFormat, const GUID *pguidVendor, IWICBitmapDecoder **ppIDecoder );
		IWICBitmapDecoder CreateDecoder(in Guid guidContainerFormat, [In] SafeGuidPtr pguidVendor);

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
		/// <remarks>
		/// Other values may be available for both guidContainerFormat and pguidVendor depending on the installed WIC-enabled encoders.
		/// The values listed are those that are natively supported by the operating system.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createencoder HRESULT
		// CreateEncoder( REFGUID guidContainerFormat, const GUID *pguidVendor, IWICBitmapEncoder **ppIEncoder );
		IWICBitmapDecoder CreateEncoder(in Guid guidContainerFormat, [In] SafeGuidPtr pguidVendor);

		/// <summary>Creates a new instance of the IWICPalette class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICPalette**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICPalette.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createpalette HRESULT
		// CreatePalette( IWICPalette **ppIPalette );
		IWICPalette CreatePalette();

		/// <summary>Creates a new instance of the IWICFormatConverter class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICFormatConverter**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICFormatConverter.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createformatconverter HRESULT
		// CreateFormatConverter( IWICFormatConverter **ppIFormatConverter );
		IWICFormatConverter CreateFormatConverter();

		/// <summary>Creates a new instance of an IWICBitmapScaler.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapScaler**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapScaler.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapscaler HRESULT
		// CreateBitmapScaler( IWICBitmapScaler **ppIBitmapScaler );
		IWICBitmapScaler CreateBitmapScaler();

		/// <summary>Creates a new instance of an IWICBitmapClipper object.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapClipper**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapClipper.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapclipper HRESULT
		// CreateBitmapClipper( IWICBitmapClipper **ppIBitmapClipper );
		IWICBitmapClipper CreateBitmapClipper();

		/// <summary>Creates a new instance of an IWICBitmapFlipRotator object.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapFlipRotator**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapFlipRotator.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfliprotator HRESULT
		// CreateBitmapFlipRotator( IWICBitmapFlipRotator **ppIBitmapFlipRotator );
		IWICBitmapFlipRotator CreateBitmapFlipRotator();

		/// <summary>Creates a new instance of the IWICStream class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICStream**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICStream.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createstream HRESULT CreateStream(
		// IWICStream **ppIWICStream );
		IWICStream CreateStream();

		/// <summary>Creates a new instance of the IWICColorContext class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICColorContext**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICColorContext.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcolorcontext HRESULT
		// CreateColorContext( IWICColorContext **ppIWICColorContext );
		IWICColorContext CreateColorContext();

		/// <summary>Creates a new instance of the IWICColorTransform class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICColorTransform**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICColorTransform.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcolortransformer HRESULT
		// CreateColorTransformer( IWICColorTransform **ppIWICColorTransform );
		IWICColorTransform CreateColorTransformer();

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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmap HRESULT CreateBitmap(
		// UINT uiWidth, UINT uiHeight, in Guid pixelFormat, WICBitmapCreateCacheOption option, IWICBitmap **ppIBitmap );
		IWICBitmap CreateBitmap(uint uiWidth, uint uiHeight, in Guid pixelFormat, WICBitmapCreateCacheOption option);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromsource HRESULT
		// CreateBitmapFromSource( IWICBitmapSource *pIBitmapSource, WICBitmapCreateCacheOption option, IWICBitmap **ppIBitmap );
		IWICBitmap CreateBitmapFromSource(IWICBitmapSource pIBitmapSource, WICBitmapCreateCacheOption option);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromsourcerect HRESULT
		// CreateBitmapFromSourceRect( IWICBitmapSource *pIBitmapSource, UINT x, UINT y, UINT width, UINT height, IWICBitmap **ppIBitmap );
		IWICBitmap CreateBitmapFromSourceRect(IWICBitmapSource pIBitmapSource, uint x, uint y, uint width, uint height);

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
		/// <para>
		/// The stride of the destination bitmap will equal the stride of the source data, regardless of the width and height specified.
		/// </para>
		/// <para>The pixelFormat parameter defines the pixel format for both the input data and the output bitmap.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfrommemory HRESULT
		// CreateBitmapFromMemory( UINT uiWidth, UINT uiHeight, in Guid pixelFormat, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer,
		// IWICBitmap **ppIBitmap );
		IWICBitmap CreateBitmapFromMemory(uint uiWidth, uint uiHeight, in Guid pixelFormat, uint cbStride, uint cbBufferSize, [In] IntPtr pbBuffer);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromhbitmap HRESULT
		// CreateBitmapFromHBITMAP( HBITMAP hBitmap, HPALETTE hPalette, WICBitmapAlphaChannelOption options, IWICBitmap **ppIBitmap );
		IWICBitmap CreateBitmapFromHBITMAP(HBITMAP hBitmap, [Optional] HPALETTE hPalette, WICBitmapAlphaChannelOption options);

		/// <summary>Creates an IWICBitmap from an icon handle.</summary>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>The icon handle to create the new bitmap from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICBitmap**</c></para>
		/// <para>A pointer that receives a pointer to the new bitmap.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromhicon HRESULT
		// CreateBitmapFromHICON( HICON hIcon, IWICBitmap **ppIBitmap );
		IWICBitmap CreateBitmapFromHICON(HICON hIcon);

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
		/// <remarks>
		/// Component types must be enumerated seperately. Combinations of component types and <c>WICAllComponents</c> are unsupported.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcomponentenumerator HRESULT
		// CreateComponentEnumerator( DWORD componentTypes, DWORD options, IEnumUnknown **ppIEnumUnknown );
		IEnumUnknown CreateComponentEnumerator(WICComponentType componentTypes, WICComponentEnumerateOptions options);

		/// <summary>Creates a new instance of the fast metadata encoder based on the given IWICBitmapDecoder.</summary>
		/// <param name="pIDecoder">
		/// <para>Type: <c>IWICBitmapDecoder*</c></para>
		/// <para>The decoder to create the fast metadata encoder from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICFastMetadataEncoder**</c></para>
		/// <para>When this method returns, contains a pointer to the new IWICFastMetadataEncoder.</para>
		/// </returns>
		/// <remarks>
		/// The Windows provided codecs do not support fast metadata encoding at the decoder level, and only support fast metadata
		/// encoding at the frame level. To create a fast metadata encoder from a frame, see CreateFastMetadataEncoderFromFrameDecode.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createfastmetadataencoderfromdecoder
		// HRESULT CreateFastMetadataEncoderFromDecoder( IWICBitmapDecoder *pIDecoder, IWICFastMetadataEncoder **ppIFastEncoder );
		IWICFastMetadataEncoder CreateFastMetadataEncoderFromDecoder(IWICBitmapDecoder pIDecoder);

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
		/// <para>
		/// The following code demonstrates how to use the <c>CreateFastMetadataEncoderFromFrameDecode</c> method for fast metadata encoding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createfastmetadataencoderfromframedecode
		// HRESULT CreateFastMetadataEncoderFromFrameDecode( IWICBitmapFrameDecode *pIFrameDecoder, IWICFastMetadataEncoder
		// **ppIFastEncoder );
		IWICFastMetadataEncoder CreateFastMetadataEncoderFromFrameDecode(IWICBitmapFrameDecode pIFrameDecoder);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createquerywriter HRESULT
		// CreateQueryWriter( REFGUID guidMetadataFormat, const GUID *pguidVendor, IWICMetadataQueryWriter **ppIQueryWriter );
		IWICMetadataQueryWriter CreateQueryWriter(in Guid guidMetadataFormat, [In] SafeGuidPtr pguidVendor);

		/// <summary>
		/// Creates a new instance of a query writer based on the given query reader. The query writer will be pre-populated with
		/// metadata from the query reader.
		/// </summary>
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
		// HRESULT CreateQueryWriterFromReader( IWICMetadataQueryReader *pIQueryReader, const GUID *pguidVendor, IWICMetadataQueryWriter
		// **ppIQueryWriter );
		IWICMetadataQueryWriter CreateQueryWriterFromReader(IWICMetadataQueryReader pIQueryReader, [In] SafeGuidPtr pguidVendor);
	}

	/// <summary>
	/// An extension of the WIC factory interface that includes the ability to create an IWICImageEncoder. This interface uses a
	/// Direct2D device and an input image to encode to a destination IWICBitmapEncoder.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicimagingfactory2
	[PInvokeData("wincodec.h", MSDNShortId = "95F64E01-6174-4C1C-B0BE-331380E583C2")]
	[ComImport, Guid("7B816B45-1996-4476-B132-DE9E247C8AF0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(WICImagingFactory2))]
	public interface IWICImagingFactory2 : IWICImagingFactory
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createdecoderfromfilename HRESULT
		// CreateDecoderFromFilename( LPCWSTR wzFilename, const GUID *pguidVendor, DWORD dwDesiredAccess, WICDecodeOptions
		// metadataOptions, IWICBitmapDecoder **ppIDecoder );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createdecoderfromstream HRESULT
		// CreateDecoderFromStream( IStream *pIStream, const GUID *pguidVendor, WICDecodeOptions metadataOptions, IWICBitmapDecoder
		// **ppIDecoder );
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
		// HRESULT CreateDecoderFromFileHandle( ULONG_PTR hFile, const GUID *pguidVendor, WICDecodeOptions metadataOptions,
		// IWICBitmapDecoder **ppIDecoder );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcomponentinfo HRESULT
		// CreateComponentInfo( REFCLSID clsidComponent, IWICComponentInfo **ppIInfo );
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
		/// <para>
		/// A pointer that receives a pointer to a new IWICBitmapDecoder. You must initialize this <c>IWICBitmapDecoder</c> on a stream
		/// using the Initialize method later.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Other values may be available for both guidContainerFormat and pguidVendor depending on the installed WIC-enabled encoders.
		/// The values listed are those that are natively supported by the operating system.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createdecoder HRESULT
		// CreateDecoder( REFGUID guidContainerFormat, const GUID *pguidVendor, IWICBitmapDecoder **ppIDecoder );
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
		/// <remarks>
		/// Other values may be available for both guidContainerFormat and pguidVendor depending on the installed WIC-enabled encoders.
		/// The values listed are those that are natively supported by the operating system.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createencoder HRESULT
		// CreateEncoder( REFGUID guidContainerFormat, const GUID *pguidVendor, IWICBitmapEncoder **ppIEncoder );
		new IWICBitmapDecoder CreateEncoder(in Guid guidContainerFormat, [In] SafeGuidPtr pguidVendor);

		/// <summary>Creates a new instance of the IWICPalette class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICPalette**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICPalette.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createpalette HRESULT
		// CreatePalette( IWICPalette **ppIPalette );
		new IWICPalette CreatePalette();

		/// <summary>Creates a new instance of the IWICFormatConverter class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICFormatConverter**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICFormatConverter.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createformatconverter HRESULT
		// CreateFormatConverter( IWICFormatConverter **ppIFormatConverter );
		new IWICFormatConverter CreateFormatConverter();

		/// <summary>Creates a new instance of an IWICBitmapScaler.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapScaler**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapScaler.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapscaler HRESULT
		// CreateBitmapScaler( IWICBitmapScaler **ppIBitmapScaler );
		new IWICBitmapScaler CreateBitmapScaler();

		/// <summary>Creates a new instance of an IWICBitmapClipper object.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapClipper**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapClipper.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapclipper HRESULT
		// CreateBitmapClipper( IWICBitmapClipper **ppIBitmapClipper );
		new IWICBitmapClipper CreateBitmapClipper();

		/// <summary>Creates a new instance of an IWICBitmapFlipRotator object.</summary>
		/// <returns>
		/// <para>Type: <c>IWICBitmapFlipRotator**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICBitmapFlipRotator.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfliprotator HRESULT
		// CreateBitmapFlipRotator( IWICBitmapFlipRotator **ppIBitmapFlipRotator );
		new IWICBitmapFlipRotator CreateBitmapFlipRotator();

		/// <summary>Creates a new instance of the IWICStream class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICStream**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICStream.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createstream HRESULT CreateStream(
		// IWICStream **ppIWICStream );
		new IWICStream CreateStream();

		/// <summary>Creates a new instance of the IWICColorContext class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICColorContext**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICColorContext.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcolorcontext HRESULT
		// CreateColorContext( IWICColorContext **ppIWICColorContext );
		new IWICColorContext CreateColorContext();

		/// <summary>Creates a new instance of the IWICColorTransform class.</summary>
		/// <returns>
		/// <para>Type: <c>IWICColorTransform**</c></para>
		/// <para>A pointer that receives a pointer to a new IWICColorTransform.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcolortransformer HRESULT
		// CreateColorTransformer( IWICColorTransform **ppIWICColorTransform );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmap HRESULT CreateBitmap(
		// UINT uiWidth, UINT uiHeight, in Guid pixelFormat, WICBitmapCreateCacheOption option, IWICBitmap **ppIBitmap );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromsource HRESULT
		// CreateBitmapFromSource( IWICBitmapSource *pIBitmapSource, WICBitmapCreateCacheOption option, IWICBitmap **ppIBitmap );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromsourcerect HRESULT
		// CreateBitmapFromSourceRect( IWICBitmapSource *pIBitmapSource, UINT x, UINT y, UINT width, UINT height, IWICBitmap **ppIBitmap );
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
		/// <para>
		/// The stride of the destination bitmap will equal the stride of the source data, regardless of the width and height specified.
		/// </para>
		/// <para>The pixelFormat parameter defines the pixel format for both the input data and the output bitmap.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfrommemory HRESULT
		// CreateBitmapFromMemory( UINT uiWidth, UINT uiHeight, in Guid pixelFormat, UINT cbStride, UINT cbBufferSize, BYTE *pbBuffer,
		// IWICBitmap **ppIBitmap );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromhbitmap HRESULT
		// CreateBitmapFromHBITMAP( HBITMAP hBitmap, HPALETTE hPalette, WICBitmapAlphaChannelOption options, IWICBitmap **ppIBitmap );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createbitmapfromhicon HRESULT
		// CreateBitmapFromHICON( HICON hIcon, IWICBitmap **ppIBitmap );
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
		/// <remarks>
		/// Component types must be enumerated seperately. Combinations of component types and <c>WICAllComponents</c> are unsupported.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createcomponentenumerator HRESULT
		// CreateComponentEnumerator( DWORD componentTypes, DWORD options, IEnumUnknown **ppIEnumUnknown );
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
		/// <remarks>
		/// The Windows provided codecs do not support fast metadata encoding at the decoder level, and only support fast metadata
		/// encoding at the frame level. To create a fast metadata encoder from a frame, see CreateFastMetadataEncoderFromFrameDecode.
		/// </remarks>
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
		/// <para>
		/// The following code demonstrates how to use the <c>CreateFastMetadataEncoderFromFrameDecode</c> method for fast metadata encoding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createfastmetadataencoderfromframedecode
		// HRESULT CreateFastMetadataEncoderFromFrameDecode( IWICBitmapFrameDecode *pIFrameDecoder, IWICFastMetadataEncoder
		// **ppIFastEncoder );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory-createquerywriter HRESULT
		// CreateQueryWriter( REFGUID guidMetadataFormat, const GUID *pguidVendor, IWICMetadataQueryWriter **ppIQueryWriter );
		new IWICMetadataQueryWriter CreateQueryWriter(in Guid guidMetadataFormat, [In] SafeGuidPtr pguidVendor);

		/// <summary>
		/// Creates a new instance of a query writer based on the given query reader. The query writer will be pre-populated with
		/// metadata from the query reader.
		/// </summary>
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
		// HRESULT CreateQueryWriterFromReader( IWICMetadataQueryReader *pIQueryReader, const GUID *pguidVendor, IWICMetadataQueryWriter
		// **ppIQueryWriter );
		new IWICMetadataQueryWriter CreateQueryWriterFromReader(IWICMetadataQueryReader pIQueryReader, [In] SafeGuidPtr pguidVendor);

		/// <summary>Creates a new image encoder object.</summary>
		/// <param name="pD2DDevice">The ID2D1Device object on which the corresponding image encoder is created.</param>
		/// <returns>
		/// A pointer to a variable that receives a pointer to the IWICImageEncoder interface for the encoder object that you can use to
		/// encode Direct2D images.
		/// </returns>
		/// <remarks>
		/// <para>You must create images to pass to the image encoder on the same Direct2D device that you pass to this method.</para>
		/// <para>
		/// You are responsible for setting up the bitmap encoder itself through the existing IWICBitmapEncoder APIs. The
		/// <c>IWICBitmapEncoder</c> or the IWICBitmapFrameEncode object is passed to each of the IWICImageEncoder methods:
		/// WriteThumbnail, WriteFrame, and WriteFrameThumbnail.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicimagingfactory2-createimageencoder HRESULT
		// CreateImageEncoder( ID2D1Device *pD2DDevice, IWICImageEncoder **ppWICImageEncoder );
		IWICImageEncoder CreateImageEncoder(ID2D1Device pD2DDevice);
	}

	/// <summary>
	/// Exposes methods for decoding JPEG images. Provides access to the Start Of Frame (SOF) header, Start of Scan (SOS) header, the
	/// Huffman and Quantization tables, and the compressed JPEG JPEG data. Also enables indexing for efficient random access.
	/// </summary>
	/// <remarks>
	/// Obtain this interface by calling IUnknown::QueryInterface on the Windows-provided IWICBitmapFrameDecoder interface for the JPEG decoder.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicjpegframedecode
	[PInvokeData("wincodec.h", MSDNShortId = "E6310320-53A8-40F1-8964-D21D8054E1B8")]
	[ComImport, Guid("8939F66E-C46A-4c21-A9D1-98B327CE1679"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICJpegFrameDecode
	{
		/// <summary>Retrieves a value indicating whether this decoder supports indexing for efficient random access.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>True if indexing is supported; otherwise, false.</para>
		/// </returns>
		/// <remarks>Indexing is only supported for some JPEG types. Call this method</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframedecode-doessupportindexing HRESULT
		// DoesSupportIndexing( BOOL *pfIndexingSupported );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesSupportIndexing();

		/// <summary>Enables indexing of the JPEG for efficient random access.</summary>
		/// <param name="options">
		/// <para>Type: <c>WICJpegIndexingOptions</c></para>
		/// <para>A value specifying whether indexes should be generated immediately or deferred until a future call to IWICBitmapSource::CopyPixels.</para>
		/// </param>
		/// <param name="horizontalIntervalSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The granularity of the indexing, in pixels.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method enables efficient random-access to the image pixels at the expense of memory usage. The amount of memory
		/// required for indexing depends on the requested index granularity. Unless <c>SetIndexing</c> is called, it is much more
		/// efficient to access a JPEG by progressing through its pixels top-down during calls to IWICBitmapSource::CopyPixels.
		/// </para>
		/// <para>
		/// This method will fail if indexing is unsupported on the file. IWICJpegFrameDecode::DoesSupportIndexing should be called to
		/// first determine whether indexing is supported. If this method is called multiple times, the final call changes the index
		/// granularity to the requested size.
		/// </para>
		/// <para>
		/// The provided interval size controls horizontal spacing of index entries. This value is internally rounded up according to
		/// the JPEG’s MCU (minimum coded unit) size, which is typically either 8 or 16 unscaled pixels. The vertical size of the index
		/// interval is always equal to one MCU size.
		/// </para>
		/// <para>
		/// Indexes can be generated immediately, or during future calls to IWICBitmapSource::CopyPixels to reduce redundant
		/// decompression work.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframedecode-setindexing HRESULT SetIndexing(
		// WICJpegIndexingOptions options, UINT horizontalIntervalSize );
		void SetIndexing(WICJpegIndexingOptions options, uint horizontalIntervalSize);

		/// <summary>Removes the indexing from a JPEG that has been indexed using IWICJpegFrameDecode::SetIndexing.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframedecode-clearindexing HRESULT ClearIndexing();
		void ClearIndexing();

		/// <summary>Retrieves a copy of the AC Huffman table for the specified scan and table.</summary>
		/// <param name="scanIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The zero-based index of the scan for which data is retrieved.</para>
		/// </param>
		/// <param name="tableIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The index of the AC Huffman table to retrieve. Valid indices for a given scan can be determined by retrieving the scan
		/// header with IWICJpegFrameDecode::GetScanHeader.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DXGI_JPEG_AC_HUFFMAN_TABLE*</c></para>
		/// <para>A pointer that receives the table data. This parameter must not be NULL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframedecode-getachuffmantable HRESULT
		// GetAcHuffmanTable( UINT scanIndex, UINT tableIndex, DXGI_JPEG_AC_HUFFMAN_TABLE *pAcHuffmanTable );
		DXGI_JPEG_AC_HUFFMAN_TABLE GetAcHuffmanTable(uint scanIndex, uint tableIndex);

		/// <summary>Retrieves a copy of the DC Huffman table for the specified scan and table.</summary>
		/// <param name="scanIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The zero-based index of the scan for which data is retrieved.</para>
		/// </param>
		/// <param name="tableIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The index of the DC Huffman table to retrieve. Valid indices for a given scan can be determined by retrieving the scan
		/// header with IWICJpegFrameDecode::GetScanHeader.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DXGI_JPEG_AC_HUFFMAN_TABLE*</c></para>
		/// <para>A pointer that receives the table data. This parameter must not be NULL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframedecode-getdchuffmantable HRESULT
		// GetDcHuffmanTable( UINT scanIndex, UINT tableIndex, DXGI_JPEG_DC_HUFFMAN_TABLE *pDcHuffmanTable );
		DXGI_JPEG_DC_HUFFMAN_TABLE GetDcHuffmanTable(uint scanIndex, uint tableIndex);

		/// <summary>Retrieves a copy of the quantization table.</summary>
		/// <param name="scanIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The zero-based index of the scan for which data is retrieved.</para>
		/// </param>
		/// <param name="tableIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The index of the quantization table to retrieve. Valid indices for a given scan can be determined by retrieving the scan
		/// header with IWICJpegFrameDecode::GetScanHeader.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DXGI_JPEG_QUANTIZATION_TABLE*</c></para>
		/// <para>A pointer that receives the table data. This parameter must not be NULL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframedecode-getquantizationtable HRESULT
		// GetQuantizationTable( UINT scanIndex, UINT tableIndex, DXGI_JPEG_QUANTIZATION_TABLE *pQuantizationTable );
		DXGI_JPEG_QUANTIZATION_TABLE GetQuantizationTable(uint scanIndex, uint tableIndex);

		/// <summary>
		/// Retrieves header data from the entire frame. The result includes parameters from the Start Of Frame (SOF) marker for the
		/// scan as well as parameters derived from other metadata such as the color model of the compressed data.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>WICJpegFrameHeader*</c></para>
		/// <para>A pointer that receives the frame header data.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframedecode-getframeheader HRESULT
		// GetFrameHeader( WICJpegFrameHeader *pFrameHeader );
		WICJpegFrameHeader GetFrameHeader();

		/// <summary>Retrieves parameters from the Start Of Scan (SOS) marker for the scan with the specified index.</summary>
		/// <param name="scanIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the scan for which header data is retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>WICJpegScanHeader*</c></para>
		/// <para>A pointer that receives the frame header data.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframedecode-getscanheader HRESULT
		// GetScanHeader( UINT scanIndex, WICJpegScanHeader *pScanHeader );
		WICJpegScanHeader GetScanHeader(uint scanIndex);

		/// <summary>Retrieves a copy of the compressed JPEG scan directly from the WIC decoder frame's output stream.</summary>
		/// <param name="scanIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The zero-based index of the scan for which data is retrieved.</para>
		/// </param>
		/// <param name="scanOffset">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The byte position in the scan data to begin copying. Use 0 on the first call. If the output buffer size is insufficient to
		/// store the entire scan, this offset allows you to resume copying from the end of the previous copy operation.
		/// </para>
		/// </param>
		/// <param name="cbScanData">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size, in bytes, of the pbScanData array.</para>
		/// </param>
		/// <param name="pbScanData">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer that receives the table data. This parameter must not be NULL.</para>
		/// </param>
		/// <param name="pcbScanDataActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer that receives the size of the scan data actually copied into pbScanData. The size returned may be smaller that the
		/// size of cbScanData. This parameter may be NULL.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframedecode-copyscan HRESULT CopyScan( UINT
		// scanIndex, UINT scanOffset, UINT cbScanData, BYTE *pbScanData, UINT *pcbScanDataActual );
		void CopyScan(uint scanIndex, uint scanOffset, uint cbScanData, [Out] IntPtr pbScanData, out uint pcbScanDataActual);

		/// <summary>Undocumented</summary>
		/// <param name="streamOffset">
		/// The byte position in the stream data to begin copying. Use 0 on the first call. If the output buffer size is insufficient to
		/// store the entire stream, this offset allows you to resume copying from the end of the previous copy operation.
		/// </param>
		/// <param name="cbStreamData">The size, in bytes, of the pbStreamData array..</param>
		/// <param name="pbStreamData">A pointer that receives the stream data. This parameter must not be NULL.</param>
		/// <param name="pcbStreamDataActual">
		/// A pointer that receives the size of the stream data actually copied into pbStreamData. The size returned may be smaller that
		/// the size of cbStreamData. This parameter may be NULL.
		/// </param>
		void CopyMinimalStream(uint streamOffset, uint cbStreamData, [Out] IntPtr pbStreamData, out uint pcbStreamDataActual);
	}

	/// <summary>
	/// Exposes methods for writing compressed JPEG scan data directly to the WIC encoder's output stream. Also provides access to the
	/// Huffman and quantization tables.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Obtain this interface by calling IUnknown::QueryInterface on the Windows-provided IWICBitmapFrameEncoder interface for the JPEG encoder.
	/// </para>
	/// <para>The WIC JPEG encoder supports a smaller subset of JPEG features than the decoder does.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The encoder is limited to a single scan. It does not support encoding images that are multi-scan, either for progressive
	/// encoding or planar component data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The encoder supports two quantization tables, two AC Huffman tables, and two DC Huffman tables. The luma tables are used for the
	/// Y channel and, in the case of YCCK, the black channel. The chroma tables are used for the CbCr channels.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The encoder supports encoding gray, YCbCr (RGB), and YCCK (CMYK).</term>
	/// </item>
	/// <item>
	/// <term>The encoder supports 4 fixed compontent subsampling, 4:2:0, 4:2:2, 4:4:0, and 4:4:4. This subsamples chroma only.</term>
	/// </item>
	/// <item>
	/// <term>The encoder does not support restart markers.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicjpegframeencode
	[PInvokeData("wincodec.h", MSDNShortId = "631571A2-AA15-4A4B-B705-6CCC81392A6A")]
	[ComImport, Guid("2F0C601F-D2C6-468C-ABFA-49495D983ED1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICJpegFrameEncode
	{
		/// <summary>Retrieves a copy of the AC Huffman table for the specified scan and table.</summary>
		/// <param name="scanIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The zero-based index of the scan for which data is retrieved.</para>
		/// </param>
		/// <param name="tableIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the AC Huffman table to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DXGI_JPEG_AC_HUFFMAN_TABLE*</c></para>
		/// <para>A pointer that receives the table data. This parameter must not be NULL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframeencode-getachuffmantable HRESULT
		// GetAcHuffmanTable( UINT scanIndex, UINT tableIndex, DXGI_JPEG_AC_HUFFMAN_TABLE *pAcHuffmanTable );
		DXGI_JPEG_AC_HUFFMAN_TABLE GetAcHuffmanTable(uint scanIndex, uint tableIndex);

		/// <summary>Retrieves a copy of the DC Huffman table for the specified scan and table.</summary>
		/// <param name="scanIndex">The zero-based index of the scan for which data is retrieved.</param>
		/// <param name="tableIndex">The index of the DC Huffman table to retrieve.</param>
		/// <returns>A pointer that receives the table data. This parameter must not be NULL.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframeencode-getdchuffmantable HRESULT
		// GetDcHuffmanTable( UINT scanIndex, UINT tableIndex, DXGI_JPEG_DC_HUFFMAN_TABLE *pDcHuffmanTable );
		DXGI_JPEG_DC_HUFFMAN_TABLE GetDcHuffmanTable(uint scanIndex, uint tableIndex);

		/// <summary>Retrieves a copy of the quantization table.</summary>
		/// <param name="scanIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The zero-based index of the scan for which data is retrieved.</para>
		/// </param>
		/// <param name="tableIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the quantization table to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DXGI_JPEG_QUANTIZATION_TABLE*</c></para>
		/// <para>A pointer that receives the table data. This parameter must not be NULL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframeencode-getquantizationtable HRESULT
		// GetQuantizationTable( UINT scanIndex, UINT tableIndex, DXGI_JPEG_QUANTIZATION_TABLE *pQuantizationTable );
		DXGI_JPEG_QUANTIZATION_TABLE GetQuantizationTable(uint scanIndex, uint tableIndex);

		/// <summary>Writes scan data to a JPEG frame.</summary>
		/// <param name="cbScanData">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the data in the pbScanData parameter.</para>
		/// </param>
		/// <param name="pbScanData">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>The scan data to write.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>WriteScan</c> may be called multiple times. Each call appends the scan data specified to any previous scan data. Complete
		/// the scan by calling IWICBitmapFrameEncode::Commit.
		/// </para>
		/// <para>
		/// Any calls to set encoder parameters or image metadata that will appear before the scan data in the resulting JPEG file must
		/// be completed before the first call to this method. This includes calls to IWICBitmapFrameEncode::SetColorContexts ,
		/// IWICBitmapFrameEncode::SetPalette, IWICBitmapFrameEncode::SetPixelFormat, IWICBitmapFrameEncode::SetResolution, and
		/// IWICBitmapFrameEncode::SetThumbnail. IWICBitmapFrameEncode::SetSize is required as it has no default value for encoded image size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicjpegframeencode-writescan HRESULT WriteScan( UINT
		// cbScanData, const BYTE *pbScanData );
		void WriteScan(uint cbScanData, [In] IntPtr pbScanData);
	}

	/// <summary>Exposes methods that provide access to all of the codec's top level metadata blocks.</summary>
	/// <remarks>
	/// <para>
	/// <c>IWICMetadataBlockReader</c> and IWICMetadataBlockWriter operate at the root level only; that is, they provide read and write
	/// access, respectively, to the top level metadata blocks. They are implemented by IWICBitmapFrameDecode and IWICBitmapFrameEncode,
	/// respectively. To handle any metadata blocks that are not at the top level of the hierarchy, use IWICMetadataReader or IWICMetadataWriter.
	/// </para>
	/// <para>
	/// <c>Note</c> The codec's decoder and encoder implement this interface to expose the enumeration of all top level metadata blocks.
	/// While the codec parses the image stream, it calls services like CreateMetadataReaderFromContainer to instantiate metadata
	/// readers for any block that is recognized as being able to be embedded in the decoder's container format. The collection of
	/// metadata readers is exposed through this interface. For more info, see How to Write a WIC-Enabled CODEC.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nn-wincodecsdk-iwicmetadatablockreader
	[PInvokeData("wincodecsdk.h", MSDNShortId = "09614b44-ebc2-44f4-9755-9df62f1b2178")]
	[ComImport, Guid("FEAA2A8D-B3F3-43E4-B25C-D1DE990A1AE1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICMetadataBlockReader
	{
		/// <summary>Retrieves the container format of the decoder.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>The container format of the decoder. The native container format GUIDs are listed in WIC GUIDs and CLSIDs.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockreader-getcontainerformat
		// HRESULT GetContainerFormat( GUID *pguidContainerFormat );
		Guid GetContainerFormat();

		/// <summary>Retrieves the number of top level metadata blocks.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>When this method returns, contains the number of top level metadata blocks.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockreader-getcount HRESULT
		// GetCount( UINT *pcCount );
		uint GetCount();

		/// <summary>Retrieves an IWICMetadataReader for a specified top level metadata block.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the desired top level metadata block to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataReader**</c></para>
		/// <para>When this method returns, contains a pointer to the IWICMetadataReader specified by nIndex.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockreader-getreaderbyindex
		// HRESULT GetReaderByIndex( UINT nIndex, IWICMetadataReader **ppIMetadataReader );
		IWICMetadataReader GetReaderByIndex(uint nIndex);

		/// <summary>Retrieves an enumeration of IWICMetadataReader objects representing each of the top level metadata blocks.</summary>
		/// <returns>
		/// <para>Type: <c>IEnumUnknown**</c></para>
		/// <para>When this method returns, contains a pointer to an enumeration of IWICMetadataReader objects.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockreader-getenumerator HRESULT
		// GetEnumerator( IEnumUnknown **ppIEnumMetadata );
		IEnumUnknown GetEnumerator();
	}

	/// <summary>
	/// Exposes methods that enable the encoding of metadata. This interface is implemented by the decoder and its image frames.
	/// </summary>
	/// <remarks>
	/// When the encoder is told to commit, it goes through each metadata writer and serializes the metadata content into the encoding
	/// stream. If the metadata block contains metadata important to the integrity of the file, such as the image width or height or
	/// other intrinsic information about the image, the encoder must set the critical metadata items prior to serializing the metadata.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nn-wincodecsdk-iwicmetadatablockwriter
	[PInvokeData("wincodecsdk.h", MSDNShortId = "d8e44c64-dd58-4d36-8add-0a0b2e2af5a4")]
	[ComImport, Guid("08FB9676-B444-41E8-8DBE-6A53A542BFF1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICMetadataBlockWriter : IWICMetadataBlockReader
	{
		/// <summary>Retrieves the container format of the decoder.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>The container format of the decoder. The native container format GUIDs are listed in WIC GUIDs and CLSIDs.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockreader-getcontainerformat
		// HRESULT GetContainerFormat( GUID *pguidContainerFormat );
		new Guid GetContainerFormat();

		/// <summary>Retrieves the number of top level metadata blocks.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>When this method returns, contains the number of top level metadata blocks.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockreader-getcount HRESULT
		// GetCount( UINT *pcCount );
		new uint GetCount();

		/// <summary>Retrieves an IWICMetadataReader for a specified top level metadata block.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the desired top level metadata block to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataReader**</c></para>
		/// <para>When this method returns, contains a pointer to the IWICMetadataReader specified by nIndex.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockreader-getreaderbyindex
		// HRESULT GetReaderByIndex( UINT nIndex, IWICMetadataReader **ppIMetadataReader );
		new IWICMetadataReader GetReaderByIndex(uint nIndex);

		/// <summary>Retrieves an enumeration of IWICMetadataReader objects representing each of the top level metadata blocks.</summary>
		/// <returns>
		/// <para>Type: <c>IEnumUnknown**</c></para>
		/// <para>When this method returns, contains a pointer to an enumeration of IWICMetadataReader objects.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockreader-getenumerator HRESULT
		// GetEnumerator( IEnumUnknown **ppIEnumMetadata );
		new IEnumUnknown GetEnumerator();

		/// <summary>
		/// Initializes an IWICMetadataBlockWriter from the given IWICMetadataBlockReader. This will prepopulate the metadata block
		/// writer with all the metadata in the metadata block reader.
		/// </summary>
		/// <param name="pIMDBlockReader">
		/// <para>Type: <c>IWICMetadataBlockReader*</c></para>
		/// <para>Pointer to the IWICMetadataBlockReader used to initialize the block writer.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockwriter-initializefromblockreader
		// HRESULT InitializeFromBlockReader( IWICMetadataBlockReader *pIMDBlockReader );
		void InitializeFromBlockReader(IWICMetadataBlockReader pIMDBlockReader);

		/// <summary>Retrieves the IWICMetadataWriter that resides at the specified index.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the metadata writer to be retrieved. This index is zero-based.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWICMetadataWriter**</c></para>
		/// <para>When this method returns, contains a pointer to the metadata writer that resides at the specified index.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockwriter-getwriterbyindex
		// HRESULT GetWriterByIndex( UINT nIndex, IWICMetadataWriter **ppIMetadataWriter );
		IWICMetadataWriter GetWriterByIndex(uint nIndex);

		/// <summary>Adds a top-level metadata block by adding a IWICMetadataWriter for it.</summary>
		/// <param name="pIMetadataWriter">
		/// <para>Type: <c>IWICMetadataWriter*</c></para>
		/// <para>A pointer to the metadata writer to add to the image.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockwriter-addwriter HRESULT
		// AddWriter( IWICMetadataWriter *pIMetadataWriter );
		void AddWriter(IWICMetadataWriter pIMetadataWriter);

		/// <summary>Replaces the metadata writer at the specified index location.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index position at which to place the metadata writer. This index is zero-based.</para>
		/// </param>
		/// <param name="pIMetadataWriter">
		/// <para>Type: <c>IWICMetadataWriter*</c></para>
		/// <para>A pointer to the IWICMetadataWriter.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Typically, the current metadata writer at the specified index will be replaced with the new writer. However, the App0
		/// metadata writer cannot be replaced within a JPEG stream.
		/// </para>
		/// <para>
		/// This function cannot be used to add metadata writers. If no metadata writer exists at the specified index, the function will fail.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockwriter-setwriterbyindex
		// HRESULT SetWriterByIndex( UINT nIndex, IWICMetadataWriter *pIMetadataWriter );
		void SetWriterByIndex(uint nIndex, IWICMetadataWriter pIMetadataWriter);

		/// <summary>Removes the metadata writer from the specified index location.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the metadata writer to remove.</para>
		/// </param>
		/// <remarks>
		/// After removing a metadata writer, remaining metadata writers can be expected to move up to occupy the vacated location.
		/// Indexes for remaining metadata items as well as the count will change.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatablockwriter-removewriterbyindex
		// HRESULT RemoveWriterByIndex( UINT nIndex );
		void RemoveWriterByIndex(uint nIndex);
	}

	/// <summary>Exposes methods that provide basic information about the registered metadata handler.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nn-wincodecsdk-iwicmetadatahandlerinfo
	[ComImport, Guid("ABA958BF-C672-44D1-8D61-CE6DF2E682C2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICMetadataHandlerInfo : IWICComponentInfo
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

		/// <summary>Retrieves the metadata format of the metadata handler.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer that receives the metadata format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getmetadataformat
		// HRESULT GetMetadataFormat( GUID *pguidMetadataFormat );
		Guid GetMetadataFormat();

		/// <summary>Retrieves the container formats supported by the metadata handler.</summary>
		/// <param name="cContainerFormats">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pguidContainerFormats array.</para>
		/// </param>
		/// <param name="pguidContainerFormats">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer to an array that receives the container formats supported by the metadata handler.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual number of GUIDs added to the array.</para>
		/// <para>To obtain the number of supported container formats, pass to pguidContainerFormats.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getcontainerformats
		// HRESULT GetContainerFormats( UINT cContainerFormats, GUID *pguidContainerFormats, UINT *pcchActual );
		void GetContainerFormats(uint cContainerFormats, [Out] Guid[] pguidContainerFormats, out uint pcchActual);

		/// <summary>Retrieves the device manufacturer of the metadata handler.</summary>
		/// <param name="cchDeviceManufacturer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzDeviceManufacturer buffer.</para>
		/// </param>
		/// <param name="wzDeviceManufacturer">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Pointer to the buffer that receives the name of the device manufacturer.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual string buffer length needed to obtain the entire name of the device manufacturer.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getdevicemanufacturer
		// HRESULT GetDeviceManufacturer( UINT cchDeviceManufacturer, WCHAR *wzDeviceManufacturer, UINT *pcchActual );
		void GetDeviceManufacturer(uint cchDeviceManufacturer, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceManufacturer, out uint pcchActual);

		/// <summary>Retrieves the device models that support the metadata handler.</summary>
		/// <param name="cchDeviceModels">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The length of the wzDeviceModels buffer.</para>
		/// </param>
		/// <param name="wzDeviceModels">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Pointer that receives the device models supported by the metadata handler.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual length needed to retrieve the device models.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getdevicemodels HRESULT
		// GetDeviceModels( UINT cchDeviceModels, WCHAR *wzDeviceModels, UINT *pcchActual );
		void GetDeviceModels(uint cchDeviceModels, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceModels, out uint pcchActual);

		/// <summary>Determines if the handler requires a full stream.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives <c>TRUE</c> if a full stream is required; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-doesrequirefullstream
		// HRESULT DoesRequireFullStream( BOOL *pfRequiresFullStream );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesRequireFullStream();

		/// <summary>Determines if the metadata handler supports padding.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives <c>TRUE</c> if padding is supported; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-doessupportpadding
		// HRESULT DoesSupportPadding( BOOL *pfSupportsPadding );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesSupportPadding();

		/// <summary>Determines if the metadata handler requires a fixed size.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives <c>TRUE</c> if a fixed size is required; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-doesrequirefixedsize
		// HRESULT DoesRequireFixedSize( BOOL *pfFixedSize );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesRequireFixedSize();
	}

	/// <summary>
	/// Exposes methods for retrieving metadata blocks and items from a decoder or its image frames using a metadata query expression.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A metadata query reader uses metadata query expressions to access embedded metadata. For more information on the metadata query
	/// language, see the Metadata Query Language Overview.
	/// </para>
	/// <para>The benefit of the query reader is the ability to access a metadata item in a single step.</para>
	/// <para>
	/// The query reader also provides the way to traverse the whole set of metadata hierarchy with the help of the GetEnumerator
	/// method. However, it is not recommended to use this method since IWICMetadataBlockReader and IWICMetadataReader provide a more
	/// convenient and cheaper way.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code demonstrates how to obtain a query reader and use it to retrieve a metadata item.</para>
	/// <para>The following code demonstrates how to obtain query reader and use it to retrieve a nested metadata block.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicmetadataqueryreader
	[PInvokeData("wincodec.h", MSDNShortId = "588e00d2-e166-4ce5-bd8a-50ad0d5a3db9")]
	[ComImport, Guid("30989668-E1C9-4597-B395-458EEDB808DF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICMetadataQueryReader
	{
		/// <summary>Gets the metadata query readers container format.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer that receives the cointainer format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicmetadataqueryreader-getcontainerformat HRESULT
		// GetContainerFormat( GUID *pguidContainerFormat );
		Guid GetContainerFormat();

		/// <summary>Retrieves the current path relative to the root metadata block.</summary>
		/// <param name="cchMaxLength">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The length of the wzNamespace buffer.</para>
		/// </param>
		/// <param name="wzNamespace">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Pointer that receives the current namespace location.</para>
		/// </param>
		/// <param name="pcchActualLength">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer length that was needed to retrieve the current namespace location.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you pass <c>NULL</c> to wzNamespace, <c>GetLocation</c> ignores cchMaxLength and returns the required buffer length to
		/// store the path in the variable that pcchActualLength points to.
		/// </para>
		/// <para>If the query reader is relative to the top of the metadata hierarchy, it will return a single-char string.</para>
		/// <para>
		/// If the query reader is relative to a nested metadata block, this method will return the path to the current query reader.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicmetadataqueryreader-getlocation HRESULT
		// GetLocation( UINT cchMaxLength, WCHAR *wzNamespace, UINT *pcchActualLength );
		void GetLocation(uint cchMaxLength, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzNamespace, out uint pcchActualLength);

		/// <summary>Retrieves the metadata block or item identified by a metadata query expression.</summary>
		/// <param name="wzName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The query expression to the requested metadata block or item.</para>
		/// </param>
		/// <param name="pvarValue">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>When this method returns, contains the metadata block or item requested.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>GetMetadataByName</c> uses metadata query expressions to access embedded metadata. For more information on the metadata
		/// query language, see the Metadata Query Language Overview.
		/// </para>
		/// <para>
		/// If multiple blocks or items exist that are expressed by the same query expression, the first metadata block or item found
		/// will be returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicmetadataqueryreader-getmetadatabyname HRESULT
		// GetMetadataByName( LPCWSTR wzName, PROPVARIANT *pvarValue );
		void GetMetadataByName([MarshalAs(UnmanagedType.LPWStr)] string wzName, [Out] PROPVARIANT pvarValue);

		/// <summary>Gets an enumerator of all metadata items at the current relative location within the metadata hierarchy.</summary>
		/// <returns>
		/// <para>Type: <c>IEnumString**</c></para>
		/// <para>
		/// A pointer to a variable that receives a pointer to the IEnumString interface for the enumerator that contains query strings
		/// that can be used in the current IWICMetadataQueryReader.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The retrieved enumerator only contains query strings for the metadata blocks and items in the current level of the hierarchy.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicmetadataqueryreader-getenumerator HRESULT
		// GetEnumerator( IEnumString **ppIEnumString );
		IEnumString GetEnumerator();
	}

	/// <summary>
	/// Exposes methods for setting or removing metadata blocks and items to an encoder or its image frames using a metadata query expression.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A metadata query writer uses metadata query expressions to set or remove metadata. For more information on the metadata query
	/// language, see the Metadata Query Language Overview.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code demonstrates how to create an XMP query writer and add a new metadata item to it.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicmetadataquerywriter
	[PInvokeData("wincodec.h", MSDNShortId = "065cccc3-778f-42c4-823a-354b08bbd1f1")]
	[ComImport, Guid("A721791A-0DEF-4d06-BD91-2118BF1DB10B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICMetadataQueryWriter : IWICMetadataQueryReader
	{
		/// <summary>Gets the metadata query readers container format.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer that receives the cointainer format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicmetadataqueryreader-getcontainerformat HRESULT
		// GetContainerFormat( GUID *pguidContainerFormat );
		new Guid GetContainerFormat();

		/// <summary>Retrieves the current path relative to the root metadata block.</summary>
		/// <param name="cchMaxLength">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The length of the wzNamespace buffer.</para>
		/// </param>
		/// <param name="wzNamespace">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Pointer that receives the current namespace location.</para>
		/// </param>
		/// <param name="pcchActualLength">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer length that was needed to retrieve the current namespace location.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you pass <c>NULL</c> to wzNamespace, <c>GetLocation</c> ignores cchMaxLength and returns the required buffer length to
		/// store the path in the variable that pcchActualLength points to.
		/// </para>
		/// <para>If the query reader is relative to the top of the metadata hierarchy, it will return a single-char string.</para>
		/// <para>
		/// If the query reader is relative to a nested metadata block, this method will return the path to the current query reader.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicmetadataqueryreader-getlocation HRESULT
		// GetLocation( UINT cchMaxLength, WCHAR *wzNamespace, UINT *pcchActualLength );
		new void GetLocation(uint cchMaxLength, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzNamespace, out uint pcchActualLength);

		/// <summary>Retrieves the metadata block or item identified by a metadata query expression.</summary>
		/// <param name="wzName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The query expression to the requested metadata block or item.</para>
		/// </param>
		/// <param name="pvarValue">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>When this method returns, contains the metadata block or item requested.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>GetMetadataByName</c> uses metadata query expressions to access embedded metadata. For more information on the metadata
		/// query language, see the Metadata Query Language Overview.
		/// </para>
		/// <para>
		/// If multiple blocks or items exist that are expressed by the same query expression, the first metadata block or item found
		/// will be returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicmetadataqueryreader-getmetadatabyname HRESULT
		// GetMetadataByName( LPCWSTR wzName, PROPVARIANT *pvarValue );
		new void GetMetadataByName([MarshalAs(UnmanagedType.LPWStr)] string wzName, [Out] PROPVARIANT pvarValue);

		/// <summary>Gets an enumerator of all metadata items at the current relative location within the metadata hierarchy.</summary>
		/// <returns>
		/// <para>Type: <c>IEnumString**</c></para>
		/// <para>
		/// A pointer to a variable that receives a pointer to the IEnumString interface for the enumerator that contains query strings
		/// that can be used in the current IWICMetadataQueryReader.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The retrieved enumerator only contains query strings for the metadata blocks and items in the current level of the hierarchy.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicmetadataqueryreader-getenumerator HRESULT
		// GetEnumerator( IEnumString **ppIEnumString );
		new IEnumString GetEnumerator();

		/// <summary>Sets a metadata item to a specific location.</summary>
		/// <param name="wzName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the metadata item.</para>
		/// </param>
		/// <param name="pvarValue">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>The metadata to set.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>SetMetadataByName</c> uses metadata query expressions to remove metadata. For more information on the metadata query
		/// language, see the Metadata Query Language Overview.
		/// </para>
		/// <para>
		/// If the value set is a nested metadata block then use variant type and pvarValue pointing to the IWICMetadataQueryWriter of
		/// the new metadata block. The ordering of metadata items is at the discretion of the query writer since relative locations are
		/// not specified.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicmetadataquerywriter-setmetadatabyname HRESULT
		// SetMetadataByName( LPCWSTR wzName, const PROPVARIANT *pvarValue );
		void SetMetadataByName([MarshalAs(UnmanagedType.LPWStr)] string wzName, [In] PROPVARIANT pvarValue);

		/// <summary>Removes a metadata item from a specific location using a metadata query expression.</summary>
		/// <param name="wzName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the metadata item to remove.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>RemoveMetadataByName</c> uses metadata query expressions to remove metadata. For more information on the metadata query
		/// language, see the Metadata Query Language Overview.
		/// </para>
		/// <para>If the metadata item is a metadata block, it is removed from the metadata hierarchy.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicmetadataquerywriter-removemetadatabyname HRESULT
		// RemoveMetadataByName( LPCWSTR wzName );
		void RemoveMetadataByName([MarshalAs(UnmanagedType.LPWStr)] string wzName);
	}

	/// <summary>
	/// Exposes methods that provide access to underlining metadata content. This interface is implemented by independent software
	/// vendors (ISVs) to create new metadata readers.
	/// </summary>
	/// <remarks>
	/// A metadata reader can be used to access metadata blocks and items within a metadata block instead of using a query reader. To
	/// directly access the metadata reader, query a decoder or its frames for the IWICMetadataBlockReader interface to enumerate each
	/// metadata reader.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nn-wincodecsdk-iwicmetadatareader
	[PInvokeData("wincodecsdk.h", MSDNShortId = "0495ecf1-128a-4576-8420-0e79f1454015")]
	[ComImport, Guid("9204FE99-D8FC-4FD5-A001-9536B067A899"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICMetadataReader
	{
		/// <summary>Gets the metadata format associated with the reader.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer that receives the metadata format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getmetadataformat HRESULT
		// GetMetadataFormat( GUID *pguidMetadataFormat );
		Guid GetMetadataFormat();

		/// <summary>Gets the metadata handler info associated with the reader.</summary>
		/// <returns>
		/// <para>Type: <c>IWICMetadataHandlerInfo**</c></para>
		/// <para>Pointer that receives a pointer to the IWICMetadataHandlerInfo.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getmetadatahandlerinfo
		// HRESULT GetMetadataHandlerInfo( IWICMetadataHandlerInfo **ppIHandler );
		IWICMetadataHandlerInfo GetMetadataHandlerInfo();

		/// <summary>Gets the number of metadata items within the reader.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer that receives the number of metadata items within the reader.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getcount HRESULT GetCount(
		// UINT *pcCount );
		uint GetCount();

		/// <summary>Gets the metadata item at the given index.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the metadata item to retrieve.</para>
		/// </param>
		/// <param name="pvarSchema">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Pointer that receives the schema property.</para>
		/// </param>
		/// <param name="pvarId">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Pointer that receives the id property.</para>
		/// </param>
		/// <param name="pvarValue">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Pointer that receives the metadata value.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getvaluebyindex HRESULT
		// GetValueByIndex( UINT nIndex, PROPVARIANT *pvarSchema, PROPVARIANT *pvarId, PROPVARIANT *pvarValue );
		void GetValueByIndex(uint nIndex, [In, Out] PROPVARIANT pvarSchema, [In, Out] PROPVARIANT pvarId, [In, Out] PROPVARIANT pvarValue);

		/// <summary>Gets the metadata item value.</summary>
		/// <param name="pvarSchema">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the metadata item's schema property.</para>
		/// </param>
		/// <param name="pvarId">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the metadata item's id.</para>
		/// </param>
		/// <param name="pvarValue">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Pointer that receives the metadata value.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getvalue HRESULT GetValue(
		// const PROPVARIANT *pvarSchema, const PROPVARIANT *pvarId, PROPVARIANT *pvarValue );
		void GetValue([In, Optional] PROPVARIANT? pvarSchema, [In] PROPVARIANT pvarId, [In, Out, Optional] PROPVARIANT? pvarValue);

		/// <summary>Gets an enumerator of all the metadata items.</summary>
		/// <returns>
		/// <para>Type: <c>IWICEnumMetadataItem**</c></para>
		/// <para>Pointer that receives a pointer to the metadata enumerator.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getenumerator HRESULT
		// GetEnumerator( IWICEnumMetadataItem **ppIEnumMetadata );
		IWICEnumMetadataItem GetEnumerator();
	}

	/// <summary>Exposes methods that provide basic information about the registered metadata reader.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nn-wincodecsdk-iwicmetadatareaderinfo
	[PInvokeData("wincodecsdk.h", MSDNShortId = "f72d9a06-0568-4e46-a904-202aad2f8859")]
	[ComImport, Guid("EEBF1F5B-07C1-4447-A3AB-22ACAF78A804"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICMetadataReaderInfo : IWICMetadataHandlerInfo
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

		/// <summary>Retrieves the metadata format of the metadata handler.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer that receives the metadata format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getmetadataformat
		// HRESULT GetMetadataFormat( GUID *pguidMetadataFormat );
		new Guid GetMetadataFormat();

		/// <summary>Retrieves the container formats supported by the metadata handler.</summary>
		/// <param name="cContainerFormats">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pguidContainerFormats array.</para>
		/// </param>
		/// <param name="pguidContainerFormats">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer to an array that receives the container formats supported by the metadata handler.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual number of GUIDs added to the array.</para>
		/// <para>To obtain the number of supported container formats, pass to pguidContainerFormats.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getcontainerformats
		// HRESULT GetContainerFormats( UINT cContainerFormats, GUID *pguidContainerFormats, UINT *pcchActual );
		new void GetContainerFormats(uint cContainerFormats, [Out] Guid[] pguidContainerFormats, out uint pcchActual);

		/// <summary>Retrieves the device manufacturer of the metadata handler.</summary>
		/// <param name="cchDeviceManufacturer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzDeviceManufacturer buffer.</para>
		/// </param>
		/// <param name="wzDeviceManufacturer">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Pointer to the buffer that receives the name of the device manufacturer.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual string buffer length needed to obtain the entire name of the device manufacturer.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getdevicemanufacturer
		// HRESULT GetDeviceManufacturer( UINT cchDeviceManufacturer, WCHAR *wzDeviceManufacturer, UINT *pcchActual );
		new void GetDeviceManufacturer(uint cchDeviceManufacturer, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceManufacturer, out uint pcchActual);

		/// <summary>Retrieves the device models that support the metadata handler.</summary>
		/// <param name="cchDeviceModels">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The length of the wzDeviceModels buffer.</para>
		/// </param>
		/// <param name="wzDeviceModels">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Pointer that receives the device models supported by the metadata handler.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual length needed to retrieve the device models.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getdevicemodels HRESULT
		// GetDeviceModels( UINT cchDeviceModels, WCHAR *wzDeviceModels, UINT *pcchActual );
		new void GetDeviceModels(uint cchDeviceModels, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceModels, out uint pcchActual);

		/// <summary>Determines if the handler requires a full stream.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives <c>TRUE</c> if a full stream is required; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-doesrequirefullstream
		// HRESULT DoesRequireFullStream( BOOL *pfRequiresFullStream );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesRequireFullStream();

		/// <summary>Determines if the metadata handler supports padding.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives <c>TRUE</c> if padding is supported; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-doessupportpadding
		// HRESULT DoesSupportPadding( BOOL *pfSupportsPadding );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesSupportPadding();

		/// <summary>Determines if the metadata handler requires a fixed size.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives <c>TRUE</c> if a fixed size is required; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-doesrequirefixedsize
		// HRESULT DoesRequireFixedSize( BOOL *pfFixedSize );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesRequireFixedSize();

		/// <summary>Gets the metadata patterns associated with the metadata reader.</summary>
		/// <param name="guidContainerFormat">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>The cointainer format GUID.</para>
		/// </param>
		/// <param name="cbSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size, in bytes, of the pPattern buffer.</para>
		/// </param>
		/// <param name="pPattern">
		/// <para>Type: <c>WICMetadataPattern*</c></para>
		/// <para>Pointer that receives the metadata patterns.</para>
		/// </param>
		/// <param name="pcCount">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer that receives the number of metadata patterns.</para>
		/// </param>
		/// <param name="pcbActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer that receives the size, in bytes, needed to obtain the metadata patterns.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareaderinfo-getpatterns HRESULT
		// GetPatterns( REFGUID guidContainerFormat, UINT cbSize, WICMetadataPattern *pPattern, UINT *pcCount, UINT *pcbActual );
		void GetPatterns(in Guid guidContainerFormat, uint cbSize, [Out, Optional] ManagedStructPointer<WICMetadataPattern> pPattern, out uint pcCount, out uint pcbActual);

		/// <summary>Determines if a stream contains a metadata item pattern.</summary>
		/// <param name="guidContainerFormat">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>The container format of the metadata item.</para>
		/// </param>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>The stream to search for the metadata pattern.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives if the stream contains the pattern; otherwise, .</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareaderinfo-matchespattern HRESULT
		// MatchesPattern( REFGUID guidContainerFormat, IStream *pIStream, BOOL *pfMatches );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool MatchesPattern(in Guid guidContainerFormat, IStream pIStream);

		/// <summary>Creates an instance of an IWICMetadataReader.</summary>
		/// <returns>
		/// <para>Type: <c>IWICMetadataReader**</c></para>
		/// <para>Pointer that receives a pointer to a metadata reader.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareaderinfo-createinstance HRESULT
		// CreateInstance( IWICMetadataReader **ppIReader );
		IWICMetadataReader CreateInstance();
	}

	/// <summary>
	/// Exposes methods that provide access to writing metadata content. This is implemented by independent software vendors (ISVs) to
	/// create new metadata writers.
	/// </summary>
	/// <remarks>
	/// A metadata writer can be used to write metadata blocks and items within a metadata block instead of using a query writer. To
	/// directly access the metadata writer, query an encoder or its frames for the IWICMetadataBlockWriter interface to enumerate each
	/// metadata writer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nn-wincodecsdk-iwicmetadatawriter
	[PInvokeData("wincodecsdk.h", MSDNShortId = "7e742a96-f9d0-49e1-80e4-31ec90680e60")]
	[ComImport, Guid("F7836E16-3BE0-470B-86BB-160D0AECD7DE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICMetadataWriter : IWICMetadataReader
	{
		/// <summary>Gets the metadata format associated with the reader.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer that receives the metadata format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getmetadataformat HRESULT
		// GetMetadataFormat( GUID *pguidMetadataFormat );
		new Guid GetMetadataFormat();

		/// <summary>Gets the metadata handler info associated with the reader.</summary>
		/// <returns>
		/// <para>Type: <c>IWICMetadataHandlerInfo**</c></para>
		/// <para>Pointer that receives a pointer to the IWICMetadataHandlerInfo.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getmetadatahandlerinfo
		// HRESULT GetMetadataHandlerInfo( IWICMetadataHandlerInfo **ppIHandler );
		new IWICMetadataHandlerInfo GetMetadataHandlerInfo();

		/// <summary>Gets the number of metadata items within the reader.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer that receives the number of metadata items within the reader.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getcount HRESULT GetCount(
		// UINT *pcCount );
		new uint GetCount();

		/// <summary>Gets the metadata item at the given index.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the metadata item to retrieve.</para>
		/// </param>
		/// <param name="pvarSchema">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Pointer that receives the schema property.</para>
		/// </param>
		/// <param name="pvarId">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Pointer that receives the id property.</para>
		/// </param>
		/// <param name="pvarValue">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Pointer that receives the metadata value.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getvaluebyindex HRESULT
		// GetValueByIndex( UINT nIndex, PROPVARIANT *pvarSchema, PROPVARIANT *pvarId, PROPVARIANT *pvarValue );
		new void GetValueByIndex(uint nIndex, [In, Out] PROPVARIANT pvarSchema, [In, Out] PROPVARIANT pvarId, [In, Out] PROPVARIANT pvarValue);

		/// <summary>Gets the metadata item value.</summary>
		/// <param name="pvarSchema">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the metadata item's schema property.</para>
		/// </param>
		/// <param name="pvarId">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the metadata item's id.</para>
		/// </param>
		/// <param name="pvarValue">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Pointer that receives the metadata value.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getvalue HRESULT GetValue(
		// const PROPVARIANT *pvarSchema, const PROPVARIANT *pvarId, PROPVARIANT *pvarValue );
		new void GetValue([In, Optional] PROPVARIANT? pvarSchema, [In] PROPVARIANT pvarId, [In, Out, Optional] PROPVARIANT? pvarValue);

		/// <summary>Gets an enumerator of all the metadata items.</summary>
		/// <returns>
		/// <para>Type: <c>IWICEnumMetadataItem**</c></para>
		/// <para>Pointer that receives a pointer to the metadata enumerator.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatareader-getenumerator HRESULT
		// GetEnumerator( IWICEnumMetadataItem **ppIEnumMetadata );
		new IWICEnumMetadataItem GetEnumerator();

		/// <summary>Sets the given metadata item.</summary>
		/// <param name="pvarSchema">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the schema property of the metadata item.</para>
		/// </param>
		/// <param name="pvarId">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the id property of the metadata item.</para>
		/// </param>
		/// <param name="pvarValue">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the metadata value to set</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatawriter-setvalue HRESULT SetValue(
		// const PROPVARIANT *pvarSchema, const PROPVARIANT *pvarId, const PROPVARIANT *pvarValue );
		void SetValue([In, Optional] PROPVARIANT? pvarSchema, [In] PROPVARIANT pvarId, [In] PROPVARIANT pvarValue);

		/// <summary>Sets the metadata item to the specified index.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index to place the metadata item.</para>
		/// </param>
		/// <param name="pvarSchema">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the schema property of the metadata item.</para>
		/// </param>
		/// <param name="pvarId">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the id property of the metadata item.</para>
		/// </param>
		/// <param name="pvarValue">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the metadata value to set at the given index.</para>
		/// </param>
		/// <remarks>
		/// After removing an item, expect the remaining metadata items to move up to occupy the vacated metadata item location.
		/// Therefore indices for remaining metadata items as well as the count will change.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatawriter-setvaluebyindex HRESULT
		// SetValueByIndex( UINT nIndex, const PROPVARIANT *pvarSchema, const PROPVARIANT *pvarId, const PROPVARIANT *pvarValue );
		void SetValueByIndex(uint nIndex, [In, Optional] PROPVARIANT? pvarSchema, [In] PROPVARIANT pvarId, [In] PROPVARIANT pvarValue);

		/// <summary>Removes the metadata item that matches the given parameters.</summary>
		/// <param name="pvarSchema">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the metadata schema property.</para>
		/// </param>
		/// <param name="pvarId">
		/// <para>Type: <c>const PROPVARIANT*</c></para>
		/// <para>Pointer to the metadata id property.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatawriter-removevalue HRESULT
		// RemoveValue( const PROPVARIANT *pvarSchema, const PROPVARIANT *pvarId );
		void RemoveValue([In, Optional] PROPVARIANT? pvarSchema, [In] PROPVARIANT pvarId);

		/// <summary>Removes the metadata item at the specified index.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the metadata item to remove.</para>
		/// </param>
		/// <remarks>
		/// After removing an item, expect the remaining metadata items to move up to occupy the vacated metadata item location.
		/// Therefore indices for remaining metadata items as well as the count will change.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatawriter-removevaluebyindex HRESULT
		// RemoveValueByIndex( UINT nIndex );
		void RemoveValueByIndex(uint nIndex);
	}

	/// <summary>Exposes methods that provide basic information about the registered metadata writer.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nn-wincodecsdk-iwicmetadatawriterinfo
	[PInvokeData("wincodecsdk.h", MSDNShortId = "467200e7-9b08-4372-9a01-660e56a15bfe")]
	[ComImport, Guid("B22E3FBA-3925-4323-B5C1-9EBFC430F236"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICMetadataWriterInfo : IWICMetadataHandlerInfo
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

		/// <summary>Retrieves the metadata format of the metadata handler.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer that receives the metadata format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getmetadataformat
		// HRESULT GetMetadataFormat( GUID *pguidMetadataFormat );
		new Guid GetMetadataFormat();

		/// <summary>Retrieves the container formats supported by the metadata handler.</summary>
		/// <param name="cContainerFormats">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pguidContainerFormats array.</para>
		/// </param>
		/// <param name="pguidContainerFormats">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer to an array that receives the container formats supported by the metadata handler.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual number of GUIDs added to the array.</para>
		/// <para>To obtain the number of supported container formats, pass to pguidContainerFormats.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getcontainerformats
		// HRESULT GetContainerFormats( UINT cContainerFormats, GUID *pguidContainerFormats, UINT *pcchActual );
		new void GetContainerFormats(uint cContainerFormats, [Out] Guid[] pguidContainerFormats, out uint pcchActual);

		/// <summary>Retrieves the device manufacturer of the metadata handler.</summary>
		/// <param name="cchDeviceManufacturer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the wzDeviceManufacturer buffer.</para>
		/// </param>
		/// <param name="wzDeviceManufacturer">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Pointer to the buffer that receives the name of the device manufacturer.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual string buffer length needed to obtain the entire name of the device manufacturer.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getdevicemanufacturer
		// HRESULT GetDeviceManufacturer( UINT cchDeviceManufacturer, WCHAR *wzDeviceManufacturer, UINT *pcchActual );
		new void GetDeviceManufacturer(uint cchDeviceManufacturer, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceManufacturer, out uint pcchActual);

		/// <summary>Retrieves the device models that support the metadata handler.</summary>
		/// <param name="cchDeviceModels">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The length of the wzDeviceModels buffer.</para>
		/// </param>
		/// <param name="wzDeviceModels">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Pointer that receives the device models supported by the metadata handler.</para>
		/// </param>
		/// <param name="pcchActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual length needed to retrieve the device models.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-getdevicemodels HRESULT
		// GetDeviceModels( UINT cchDeviceModels, WCHAR *wzDeviceModels, UINT *pcchActual );
		new void GetDeviceModels(uint cchDeviceModels, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceModels, out uint pcchActual);

		/// <summary>Determines if the handler requires a full stream.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives <c>TRUE</c> if a full stream is required; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-doesrequirefullstream
		// HRESULT DoesRequireFullStream( BOOL *pfRequiresFullStream );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesRequireFullStream();

		/// <summary>Determines if the metadata handler supports padding.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives <c>TRUE</c> if padding is supported; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-doessupportpadding
		// HRESULT DoesSupportPadding( BOOL *pfSupportsPadding );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesSupportPadding();

		/// <summary>Determines if the metadata handler requires a fixed size.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives <c>TRUE</c> if a fixed size is required; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatahandlerinfo-doesrequirefixedsize
		// HRESULT DoesRequireFixedSize( BOOL *pfFixedSize );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool DoesRequireFixedSize();

		/// <summary>Gets the metadata header for the metadata writer.</summary>
		/// <param name="guidContainerFormat">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>The format container GUID to obtain the header for.</para>
		/// </param>
		/// <param name="cbSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pHeader buffer.</para>
		/// </param>
		/// <param name="pHeader">
		/// <para>Type: <c>WICMetadataHeader*</c></para>
		/// <para>Pointer that receives the WICMetadataHeader.</para>
		/// </param>
		/// <param name="pcbActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual size of the header.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatawriterinfo-getheader HRESULT
		// GetHeader( REFGUID guidContainerFormat, UINT cbSize, WICMetadataHeader *pHeader, UINT *pcbActual );
		void GetHeader(in Guid guidContainerFormat, uint cbSize, [Out] ManagedStructPointer<WICMetadataHeader> pHeader, out uint pcbActual);

		/// <summary>Creates an instance of an IWICMetadataWriter.</summary>
		/// <returns>
		/// <para>Type: <c>IWICMetadataWriter**</c></para>
		/// <para>Pointer that receives a pointer to a metadata writer.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicmetadatawriterinfo-createinstance HRESULT
		// CreateInstance( IWICMetadataWriter **ppIWriter );
		IWICMetadataWriter CreateInstance();
	}

	/// <summary>Exposes methods for accessing and building a color table, primarily for indexed pixel formats.</summary>
	/// <remarks>
	/// <para>
	/// If the WICBitmapPaletteType is not <c>WICBitmapPaletteCustom</c>, then the colors are automatically generated based on the table
	/// above. If the user subsequently changes a color palette entry the WICBitmapPalette is set to Custom by that action.
	/// </para>
	/// <para>
	/// InitializeFromBitmap's fAddTransparentColor parameter will add a transparent color to the end of the color collection if its
	/// size if less than 256, otherwise index 255 will be replaced with the transparent color. If a pre-defined palette type is used,
	/// it will change to BitmapPaletteTypeCustom since it no longer matches the predefined palette.
	/// </para>
	/// <para>
	/// The palette interface is an auxiliary imaging interface in that it does not directly concern bitmaps and pixels; rather it
	/// provides indexed color translation for indexed bitmaps. For an indexed pixel format with M bits per pixels: (The number of
	/// colors in the palette) greater than 2^M.
	/// </para>
	/// <para>
	/// Traditionally the basic operation of the palette is to provide a translation from a byte (or smaller) index into a 32bpp color
	/// value. This is often accomplished by a 256 entry table of color values.
	/// </para>
	/// <para>Examples</para>
	/// <para>In this example code, <c>WICColor</c> is defined as a <c>UINT32</c> value with this layout:</para>
	/// <para>The wincodec.h header type-defines <c>WICColor</c> as <c>UINT32</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicpalette
	[PInvokeData("wincodec.h", MSDNShortId = "cb0e4f92-4aff-48c7-af62-5f7154539289")]
	[ComImport, Guid("00000040-a8f2-4877-ba0a-fd2b6645fb94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICPalette
	{
		/// <summary>
		/// Initializes the palette to one of the pre-defined palettes specified by WICBitmapPaletteType and optionally adds a
		/// transparent color.
		/// </summary>
		/// <param name="ePaletteType">
		/// <para>Type: <c>WICBitmapPaletteType</c></para>
		/// <para>The desired pre-defined palette type.</para>
		/// </param>
		/// <param name="fAddTransparentColor">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// The optional transparent color to add to the palette. If no transparent color is needed, use 0. When initializing to a
		/// grayscale or black and white palette, set this parameter to <c>FALSE</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// If a transparent color is added to a palette, the palette is no longer predefined and is returned as
		/// WICBitmapPaletteTypeCustom. For palettes with less than 256 entries, the transparent entry is added to the end of the
		/// palette (that is, a 16-color palette becomes a 17-color palette). For palettes with 256 colors, the transparent palette
		/// entry will replace the last entry in the pre-defined palette.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpalette-initializepredefined HRESULT
		// InitializePredefined( WICBitmapPaletteType ePaletteType, BOOL fAddTransparentColor );
		void InitializePredefined(WICBitmapPaletteType ePaletteType, [MarshalAs(UnmanagedType.Bool)] bool fAddTransparentColor);

		/// <summary>Initializes a palette to the custom color entries provided.</summary>
		/// <param name="pColors">
		/// <para>Type: <c>WICColor*</c></para>
		/// <para>Pointer to the color array.</para>
		/// </param>
		/// <param name="cCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of colors in pColors.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// If a transparent color is required, provide it as part of the custom entries. To add a transparent value to the palette, its
		/// alpha value must be 0 (0x00RRGGBB).
		/// </para>
		/// <para>The entry count is limited to 256.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpalette-initializecustom HRESULT
		// InitializeCustom( WICColor *pColors, UINT cCount );
		void InitializeCustom([In] uint[] pColors, uint cCount);

		/// <summary>Initializes a palette using a computed optimized values based on the reference bitmap.</summary>
		/// <param name="pISurface">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>Pointer to the source bitmap.</para>
		/// </param>
		/// <param name="cCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of colors to initialize the palette with.</para>
		/// </param>
		/// <param name="fAddTransparentColor">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A value to indicate whether to add a transparent color.</para>
		/// </param>
		/// <remarks>
		/// The resulting palette contains the specified number of colors which best represent the colors present in the bitmap. The
		/// algorithm operates on the opaque RGB color value of each pixel in the reference bitmap and hence ignores any alpha values.
		/// If a transparent color is required, set the fAddTransparentColor parameter to <c>TRUE</c> and one fewer optimized color will
		/// be computed, reducing the colorCount, and a fully transparent color entry will be added.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpalette-initializefrombitmap HRESULT
		// InitializeFromBitmap( IWICBitmapSource *pISurface, UINT cCount, BOOL fAddTransparentColor );
		void InitializeFromBitmap([Optional] IWICBitmapSource? pISurface, uint cCount, [MarshalAs(UnmanagedType.Bool)] bool fAddTransparentColor);

		/// <summary>Initialize the palette based on a given palette.</summary>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>Pointer to the source palette.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpalette-initializefrompalette HRESULT
		// InitializeFromPalette( IWICPalette *pIPalette );
		void InitializeFromPalette(IWICPalette pIPalette);

		/// <summary>Retrieves the WICBitmapPaletteType that describes the palette.</summary>
		/// <returns>
		/// <para>Type: <c>WICBitmapPaletteType*</c></para>
		/// <para>Pointer that receives the palette type of the bimtap.</para>
		/// </returns>
		/// <remarks>
		/// <c>WICBitmapPaletteCustom</c> is used for palettes initialized from both InitializeCustom and InitializeFromBitmap. There is
		/// no distinction is made between optimized and custom palettes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpalette-gettype HRESULT GetType(
		// WICBitmapPaletteType *pePaletteType );
		WICBitmapPaletteType GetType();

		/// <summary>Retrieves the number of colors in the color table.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer that receives the number of colors in the color table.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpalette-getcolorcount HRESULT GetColorCount( UINT
		// *pcCount );
		uint GetColorCount();

		/// <summary>
		/// Fills out the supplied color array with the colors from the internal color table. The color array should be sized according
		/// to the return results from GetColorCount.
		/// </summary>
		/// <param name="cCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pColors array.</para>
		/// </param>
		/// <param name="pColors">
		/// <para>Type: <c>WICColor*</c></para>
		/// <para>Pointer that receives the colors of the palette.</para>
		/// </param>
		/// <param name="pcActualColors">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual size needed to obtain the palette colors.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpalette-getcolors HRESULT GetColors( UINT cCount,
		// WICColor *pColors, UINT *pcActualColors );
		void GetColors(uint cCount, [In] uint[] pColors, out uint pcActualColors);

		/// <summary>Retrieves a value that describes whether the palette is black and white.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a variable that receives a boolean value that indicates whether the palette is black and white. <c>TRUE</c>
		/// indicates that the palette is black and white; otherwise, <c>FALSE</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// A palette is considered to be black and white only if it contains exactly two entries, one full black (0xFF000000) and one
		/// full white (0xFFFFFFF).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpalette-isblackwhite HRESULT IsBlackWhite( BOOL
		// *pfIsBlackWhite );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsBlackWhite();

		/// <summary>Retrieves a value that describes whether a palette is grayscale.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a variable that receives a boolean value that indicates whether the palette is grayscale. <c>TRUE</c> indicates
		/// that the palette is grayscale; otherwise <c>FALSE</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// A palette is considered grayscale only if, for every entry, the alpha value is 0xFF and the red, green and blue values match.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpalette-isgrayscale HRESULT IsGrayscale( BOOL
		// *pfIsGrayscale );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsGrayscale();

		/// <summary>
		/// Indicates whether the palette contains an entry that is non-opaque (that is, an entry with an alpha that is less than 1).
		/// </summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer that receives if the palette contains a transparent color; otherwise, .</para>
		/// </returns>
		/// <remarks>
		/// Various image formats support alpha in different ways. PNG has full alpha support by supporting partially transparent
		/// palette entries. GIF stores colors as 24bpp, without alpha, but allows one palette entry to be specified as fully
		/// transparent. If a palette has multiple fully transparent entries (0x00RRGGBB), GIF will use the last one as its transparent index.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpalette-hasalpha HRESULT HasAlpha( BOOL
		// *pfHasAlpha );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool HasAlpha();
	}

	/// <summary>Exposes methods that provide additional load and save methods that take WICPersistOptions.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nn-wincodecsdk-iwicpersiststream
	[PInvokeData("wincodecsdk.h", MSDNShortId = "9381cc2c-9554-4071-b9b5-3464d857c02d")]
	[ComImport, Guid("00675040-6908-45F8-86A3-49C7DFD6D9AD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICPersistStream : IPersistStream
	{
		/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
		/// represents an object class that defines the code that can manipulate the object's data.
		/// </para>
		/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
		/// object-specific code into the caller's context.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a
		/// different class. Such a call would be necessary if a user performed an editing operation that required the object to be
		/// saved. If the container were to save it using the treat-as CLSID, the original application would no longer be able to edit
		/// the object. Typically, in this case, the container calls the OleSave helper function, which performs all the necessary
		/// steps. For this reason, most container applications have no need to call this method directly.
		/// </para>
		/// <para>
		/// The exception would be a container that provides an object handler for certain objects. In particular, a container
		/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
		/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
		/// from the object.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
		/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of
		/// a different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more
		/// information on emulation, see CoTreatAsClass.
		/// </para>
		/// <para>
		/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
		/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
		/// function to read the CLSID that is saved in the object's storage.
		/// </para>
		/// <para>
		/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
		/// handler implementation (see OleCreateDefaultHandler).
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>This method returns CLSID_StdURLMoniker.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
		new Guid GetClassID();

		/// <summary>Determines whether an object has changed since it was last saved to its stream.</summary>
		/// <returns>This method returns S_OK to indicate that the object has changed. Otherwise, it returns S_FALSE.</returns>
		/// <remarks>
		/// <para>
		/// Use this method to determine whether an object should be saved before closing it. The dirty flag for an object is
		/// conditionally cleared in the IPersistStream::Save method.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// You should treat any error return codes as an indication that the object has changed. Unless this method explicitly returns
		/// S_FALSE, assume that the object must be saved.
		/// </para>
		/// <para>
		/// Note that the OLE-provided implementations of the <c>IPersistStream::IsDirty</c> method in the OLE-provided moniker
		/// interfaces always return S_FALSE because their internal state never changes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-isdirty HRESULT IsDirty( );
		[PreserveSig]
		new HRESULT IsDirty();

		/// <summary>Initializes an object from the stream where it was saved previously.</summary>
		/// <param name="pstm">The PSTM.</param>
		/// <remarks>
		/// <para>
		/// This method loads an object from its associated stream. The seek pointer is set as it was in the most recent
		/// IPersistStream::Save method. This method can seek and read from the stream, but cannot write to it.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStream::Load</c> directly, you typically call the OleLoadFromStream function does the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Calls the ReadClassStm function to get the class identifier from the stream.</term>
		/// </item>
		/// <item>
		/// <term>Calls the CoCreateInstance function to create an instance of the object.</term>
		/// </item>
		/// <item>
		/// <term>Queries the instance for IPersistStream.</term>
		/// </item>
		/// <item>
		/// <term>Calls <c>IPersistStream::Load</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The OleLoadFromStream function assumes that objects are stored in the stream with a class identifier followed by the object
		/// data. This storage pattern is used by the generic, composite-moniker implementation provided by OLE.
		/// </para>
		/// <para>If the objects are not stored using this pattern, you must call the methods separately yourself.</para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// Initializes an URL moniker from data within a stream, usually stored there previously using its IPersistStream::Save (using
		/// OleSaveToStream). The binary format of the URL moniker is its URL string in Unicode (may be a full or partial URL string,
		/// see CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that many Unicode characters.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-load HRESULT Load( IStream *pStm );
		new void Load([In, MarshalAs(UnmanagedType.Interface)] IStream pstm);

		/// <summary>Saves an object to the specified stream.</summary>
		/// <param name="pstm">The PSTM.</param>
		/// <param name="fClearDirty">
		/// Indicates whether to clear the dirty flag after the save is complete. If <c>TRUE</c>, the flag should be cleared. If
		/// <c>FALSE</c>, the flag should be left unchanged.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>IPersistStream::Save</c> saves an object into the specified stream and indicates whether the object should reset its
		/// dirty flag.
		/// </para>
		/// <para>
		/// The seek pointer is positioned at the location in the stream at which the object should begin writing its data. The object
		/// calls the ISequentialStream::Write method to write its data.
		/// </para>
		/// <para>
		/// On exit, the seek pointer must be positioned immediately past the object data. The position of the seek pointer is undefined
		/// if an error returns.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStream::Save</c> directly, you typically call the OleSaveToStream helper function which does
		/// the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Calls GetClassID to get the object's CLSID.</term>
		/// </item>
		/// <item>
		/// <term>Calls the WriteClassStm function to write the object's CLSID to the stream.</term>
		/// </item>
		/// <item>
		/// <term>Calls <c>IPersistStream::Save</c>.</term>
		/// </item>
		/// </list>
		/// <para>If you call these methods directly, you can write other data into the stream after the CLSID before calling <c>IPersistStream::Save</c>.</para>
		/// <para>The OLE-provided implementation of IPersistStream follows this same pattern.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The <c>IPersistStream::Save</c> method does not write the CLSID to the stream. The caller is responsible for writing the CLSID.
		/// </para>
		/// <para>
		/// The <c>IPersistStream::Save</c> method can read from, write to, and seek in the stream; but it must not seek to a location
		/// in the stream before that of the seek pointer on entry.
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// Saves an URL moniker to a stream. The binary format of URL moniker is its URL string in Unicode (may be a full or partial
		/// URL string, see CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that
		/// many Unicode characters.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-save HRESULT Save( IStream *pStm, BOOL
		// fClearDirty );
		new void Save([In, MarshalAs(UnmanagedType.Interface)] IStream pstm, [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

		/// <summary>Retrieves the size of the stream needed to save the object.</summary>
		/// <returns>The size in bytes of the stream needed to save this object, in bytes.</returns>
		/// <remarks>
		/// <para>
		/// This method returns the size needed to save an object. You can call this method to determine the size and set the necessary
		/// buffers before calling the IPersistStream::Save method.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The <c>GetSizeMax</c> implementation should return a conservative estimate of the necessary size because the caller might
		/// call the IPersistStream::Save method with a non-growable stream.
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// This method retrieves the maximum number of bytes in the stream that will be required by a subsequent call to
		/// IPersistStream::Save. This value is sizeof(ULONG)==4 plus sizeof(WCHAR)*n where n is the length of the full or partial URL
		/// string, including the NULL terminator.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-getsizemax HRESULT GetSizeMax(
		// ULARGE_INTEGER *pcbSize );
		new ulong GetSizeMax();

		/// <summary>Loads data from an input stream using the given parameters.</summary>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>Pointer to the input stream.</para>
		/// </param>
		/// <param name="pguidPreferredVendor">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Pointer to the GUID of the preferred vendor .</para>
		/// </param>
		/// <param name="dwPersistOptions">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The WICPersistOptions used to load the stream.</para>
		/// </param>
		/// <remarks>NULL can be passed in for pguidPreferredVendor to indicate no preference.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicpersiststream-loadex HRESULT LoadEx(
		// IStream *pIStream, const GUID *pguidPreferredVendor, DWORD dwPersistOptions );
		void LoadEx([In, Optional] IStream? pIStream, [In] SafeGuidPtr pguidPreferredVendor, WICPersistOptions dwPersistOptions);

		/// <summary>Saves the IWICPersistStream to the given input IStream using the given parameters.</summary>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>The stream to save to.</para>
		/// </param>
		/// <param name="dwPersistOptions">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The WICPersistOptions to use when saving.</para>
		/// </param>
		/// <param name="fClearDirty">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Indicates whether the "dirty" value will be cleared from all metadata after saving.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicpersiststream-saveex HRESULT SaveEx(
		// IStream *pIStream, DWORD dwPersistOptions, BOOL fClearDirty );
		void SaveEx([In, Optional] IStream? pIStream, WICPersistOptions dwPersistOptions, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty);
	}

	/// <summary>Exposes methods that provide information about a pixel format.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicpixelformatinfo
	[PInvokeData("wincodec.h", MSDNShortId = "d5853b27-4329-40d8-bfd0-b4b0f39ba6d5")]
	[ComImport, Guid("E8EDA601-3D48-431a-AB44-69059BE88BBE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICPixelFormatInfo : IWICComponentInfo
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

		/// <summary>Gets the pixel format GUID.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer that receives the pixel format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo-getformatguid HRESULT
		// GetFormatGUID( GUID *pFormat );
		Guid GetFormatGUID();

		/// <summary>Gets the pixel format's IWICColorContext.</summary>
		/// <returns>
		/// <para>Type: <c>IWICColorContext**</c></para>
		/// <para>Pointer that receives the pixel format's color context.</para>
		/// </returns>
		/// <remarks>
		/// The returned color context is the default color space for the pixel format. However, if an IWICBitmapSource specifies its
		/// own color context, the source's context should be preferred over the pixel format's default.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo-getcolorcontext HRESULT
		// GetColorContext( IWICColorContext **ppIColorContext );
		IWICColorContext GetColorContext();

		/// <summary>Gets the bits per pixel (BPP) of the pixel format.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer that receives the BPP of the pixel format.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo-getbitsperpixel HRESULT
		// GetBitsPerPixel( UINT *puiBitsPerPixel );
		uint GetBitsPerPixel();

		/// <summary>Gets the number of channels the pixel format contains.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer that receives the channel count.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo-getchannelcount HRESULT
		// GetChannelCount( UINT *puiChannelCount );
		uint GetChannelCount();

		/// <summary>Gets the pixel format's channel mask.</summary>
		/// <param name="uiChannelIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index to the channel mask to retrieve.</para>
		/// </param>
		/// <param name="cbMaskBuffer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pbMaskBuffer buffer.</para>
		/// </param>
		/// <param name="pbMaskBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Pointer to the mask buffer.</para>
		/// </param>
		/// <param name="pcbActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to obtain the channel mask.</para>
		/// </param>
		/// <remarks>
		/// If 0 and NULL are passed in for cbMaskBuffer and pbMaskBuffer, respectively, the required buffer size will be returned
		/// through pcbActual.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo-getchannelmask HRESULT
		// GetChannelMask( UINT uiChannelIndex, UINT cbMaskBuffer, BYTE *pbMaskBuffer, UINT *pcbActual );
		void GetChannelMask(uint uiChannelIndex, uint cbMaskBuffer, [Out] IntPtr pbMaskBuffer, out uint pcbActual);
	}

	/// <summary>Extends IWICPixelFormatInfo by providing additional information about a pixel format.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicpixelformatinfo2
	[PInvokeData("wincodec.h", MSDNShortId = "6c36fb08-f0c7-4654-bd8e-ef8ef737bc41")]
	[ComImport, Guid("A9DB33A2-AF5F-43C7-B679-74F5984B5AA4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICPixelFormatInfo2 : IWICPixelFormatInfo
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

		/// <summary>Gets the pixel format GUID.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer that receives the pixel format GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo-getformatguid HRESULT
		// GetFormatGUID( GUID *pFormat );
		new Guid GetFormatGUID();

		/// <summary>Gets the pixel format's IWICColorContext.</summary>
		/// <returns>
		/// <para>Type: <c>IWICColorContext**</c></para>
		/// <para>Pointer that receives the pixel format's color context.</para>
		/// </returns>
		/// <remarks>
		/// The returned color context is the default color space for the pixel format. However, if an IWICBitmapSource specifies its
		/// own color context, the source's context should be preferred over the pixel format's default.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo-getcolorcontext HRESULT
		// GetColorContext( IWICColorContext **ppIColorContext );
		new IWICColorContext GetColorContext();

		/// <summary>Gets the bits per pixel (BPP) of the pixel format.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer that receives the BPP of the pixel format.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo-getbitsperpixel HRESULT
		// GetBitsPerPixel( UINT *puiBitsPerPixel );
		new uint GetBitsPerPixel();

		/// <summary>Gets the number of channels the pixel format contains.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer that receives the channel count.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo-getchannelcount HRESULT
		// GetChannelCount( UINT *puiChannelCount );
		new uint GetChannelCount();

		/// <summary>Gets the pixel format's channel mask.</summary>
		/// <param name="uiChannelIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index to the channel mask to retrieve.</para>
		/// </param>
		/// <param name="cbMaskBuffer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pbMaskBuffer buffer.</para>
		/// </param>
		/// <param name="pbMaskBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Pointer to the mask buffer.</para>
		/// </param>
		/// <param name="pcbActual">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual buffer size needed to obtain the channel mask.</para>
		/// </param>
		/// <remarks>
		/// If 0 and NULL are passed in for cbMaskBuffer and pbMaskBuffer, respectively, the required buffer size will be returned
		/// through pcbActual.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo-getchannelmask HRESULT
		// GetChannelMask( UINT uiChannelIndex, UINT cbMaskBuffer, BYTE *pbMaskBuffer, UINT *pcbActual );
		new void GetChannelMask(uint uiChannelIndex, uint cbMaskBuffer, [Out] IntPtr pbMaskBuffer, out uint pcbActual);

		/// <summary>Returns whether the format supports transparent pixels.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Returns <c>TRUE</c> if the pixel format supports transparency; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>An indexed pixel format will not return <c>TRUE</c> even though it may have some transparency support.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo2-supportstransparency HRESULT
		// SupportsTransparency( BOOL *pfSupportsTransparency );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool SupportsTransparency();

		/// <summary>Retrieves the WICPixelFormatNumericRepresentation of the pixel format.</summary>
		/// <returns>
		/// <para>Type: <c>WICPixelFormatNumericRepresentation*</c></para>
		/// <para>
		/// The address of a WICPixelFormatNumericRepresentation variable that you've defined. On successful completion, the function
		/// sets your variable to the <c>WICPixelFormatNumericRepresentation</c> of the pixel format.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicpixelformatinfo2-getnumericrepresentation HRESULT
		// GetNumericRepresentation( WICPixelFormatNumericRepresentation *pNumericRepresentation );
		WICPixelFormatNumericRepresentation GetNumericRepresentation();
	}

	/// <summary>
	/// <para>
	/// Allows planar component image pixels to be written to an encoder. When supported by the encoder, this allows an application to
	/// encode planar component image data without first converting to an interleaved pixel format.
	/// </para>
	/// <para>You can use</para>
	/// <para>
	/// QueryInterface to obtain this interface from the Windows provided implementation of IWICBitmapFrameEncode for the JPEG encoder.
	/// </para>
	/// </summary>
	/// <remarks>
	/// Encoding YCbCr data using <c>IWICPlanarBitmapFrameEncode</c> is similar but not identical to encoding interleaved data using
	/// IWICBitmapFrameEncode. The planar interface only exposes the ability to write planar frame image data, and you should continue
	/// to use the frame encode interface to set metadata or a thumbnail and to commit at the end of the operation.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicplanarbitmapframeencode
	[PInvokeData("wincodec.h", MSDNShortId = "7ACA58CC-E132-4836-B955-322375ADDAA1")]
	[ComImport, Guid("F928B7B8-2221-40C1-B72E-7E82F1974D1A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICPlanarBitmapFrameEncode
	{
		/// <summary>Writes lines from the source planes to the encoded format.</summary>
		/// <param name="lineCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of lines to encode. See the Remarks section for WIC Jpeg specific line count restrictions.</para>
		/// </param>
		/// <param name="pPlanes">
		/// <para>Type: <c>WICBitmapPlane*</c></para>
		/// <para>Specifies the source buffers for each component plane encoded.</para>
		/// </param>
		/// <param name="cPlanes">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of component planes specified by the pPlanes parameter.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Successive <c>WritePixels</c> calls are assumed sequentially add scanlines to the output image.
		/// IWICBitmapFrameEncode::Initialize, IWICBitmapFrameEncode::SetSize and IWICBitmapFrameEncode::SetPixelFormat must be called
		/// before this method or it will fail.
		/// </para>
		/// <para>
		/// The interleaved pixel format set via IWICBitmapFrameEncode::SetPixelFormat and the codec specific encode parameters
		/// determine the supported planar formats.
		/// </para>
		/// <para>
		/// WIC JPEG Encoder: QueryInterface can be used to obtain this interface from the WIC JPEG IWICBitmapFrameEncode
		/// implementation. When using this method to encode Y’CbCr data with the WIC JPEG encoder, chroma subsampling can be configured
		/// with encoder options during frame creation. See the Encoding Overview and IWICBitmapEncoder::CreateNewFrame for more details.
		/// </para>
		/// <para>Depending upon the configured chroma subsampling, the lineCount parameter has the following restrictions:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Chroma Subsampling</term>
		/// <term>Line Count Restriction</term>
		/// <term>Chroma Plane Width</term>
		/// <term>Chroma Plane Height</term>
		/// </listheader>
		/// <item>
		/// <term>4:2:0</term>
		/// <term>Multiple of 2, unless the call covers the last scanline of the image</term>
		/// <term>lumaWidth / 2 Rounded up to the nearest integer.</term>
		/// <term>lumaHeight / 2 Rounded up to the nearest integer.</term>
		/// </item>
		/// <item>
		/// <term>4:2:2</term>
		/// <term>Any</term>
		/// <term>lumaWidth / 2 Rounded up to the nearest integer.</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>4:4:4</term>
		/// <term>Any</term>
		/// <term>Any</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>4:4:0</term>
		/// <term>Multiple of 2, unless the call covers the last scanline of the image</term>
		/// <term>Any</term>
		/// <term>llumaHeight / 2 Rounded up to the nearest integer.</term>
		/// </item>
		/// </list>
		/// <para>The full scanline width must be encoded, and the width of the bitmap sources must match their planar configuration.</para>
		/// <para>Additionally, if a pixel format is set via IWICBitmapFrameEncode::SetPixelFormat, it must be GUID_WICPixelFormat24bppBGR.</para>
		/// <para>The supported pixel formats of the bitmap sources passed into this method are as follows:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Plane Count</term>
		/// <term>Plane 1</term>
		/// <term>Plane 2</term>
		/// <term>Plane 3</term>
		/// </listheader>
		/// <item>
		/// <term>3</term>
		/// <term>GUID_WICPixelFormat8bppY</term>
		/// <term>GUID_WICPixelFormat8bppCb</term>
		/// <term>GUID_WICPixelFormat8bppCr</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>GUID_WICPixelFormat8bppY</term>
		/// <term>GUID_WICPixelFormat16bppCbCr</term>
		/// <term>N/A</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicplanarbitmapframeencode-writepixels HRESULT
		// WritePixels( UINT lineCount, WICBitmapPlane *pPlanes, UINT cPlanes );
		void WritePixels(uint lineCount, [In] WICBitmapPlane[] pPlanes, uint cPlanes);

		/// <summary>Writes lines from the source planes to the encoded format.</summary>
		/// <param name="ppPlanes">
		/// <para>Type: <c>IWICBitmapSource**</c></para>
		/// <para>Specifies an array of IWICBitmapSource that represent image planes.</para>
		/// </param>
		/// <param name="cPlanes">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of component planes specified by the planes parameter.</para>
		/// </param>
		/// <param name="prcSource">
		/// <para>Type: <c>WICRect*</c></para>
		/// <para>
		/// The source rectangle of pixels to encode from the IWICBitmapSource planes. Null indicates the entire source. The source rect
		/// width must match the width set through SetSize. Repeated <c>WriteSource</c> calls can be made as long as the total
		/// accumulated source rect height is the same as set through <c>SetSize</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Successive <c>WriteSource</c> calls are assumed sequentially add scanlines to the output image.
		/// IWICBitmapFrameEncode::Initialize, IWICBitmapFrameEncode::SetSize and IWICBitmapFrameEncode::SetPixelFormat must be called
		/// before this method or it will fail.
		/// </para>
		/// <para>
		/// The interleaved pixel format set via IWICBitmapFrameEncode::SetPixelFormat and the codec specific encode parameters
		/// determine the supported planar formats.
		/// </para>
		/// <para>
		/// WIC JPEG Encoder: QueryInterface can be used to obtain this interface from the WIC JPEG IWICBitmapFrameEncode
		/// implementation. When using this method to encode Y’CbCr data with the WIC JPEG encoder, chroma subsampling can be configured
		/// with encoder options during frame creation. See the Encoding Overview and IWICBitmapEncoder::CreateNewFrame for more details.
		/// </para>
		/// <para>Depending upon the configured chroma subsampling, the lineCount parameter has the following restrictions:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Chroma Subsampling</term>
		/// <term>X Coordinate</term>
		/// <term>Y Coordinate</term>
		/// <term>Chroma Width</term>
		/// <term>Chroma Height</term>
		/// </listheader>
		/// <item>
		/// <term>4:2:0</term>
		/// <term>Multiple of 2</term>
		/// <term>Multiple of 2</term>
		/// <term>lumaWidth / 2 Rounded up to the nearest integer.</term>
		/// <term>lumaHeight / 2 Rounded up to the nearest integer.</term>
		/// </item>
		/// <item>
		/// <term>4:2:2</term>
		/// <term>Multiple of 2</term>
		/// <term>Any</term>
		/// <term>lumaWidth / 2 Rounded up to the nearest integer.</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>4:4:4</term>
		/// <term>Any</term>
		/// <term>Any</term>
		/// <term>Any</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>4:4:0</term>
		/// <term>Any</term>
		/// <term>Multiple of 2</term>
		/// <term>lumaWidth</term>
		/// <term>llumaHeight / 2 Rounded up to the nearest integer.</term>
		/// </item>
		/// </list>
		/// <para>The full scanline width must be encoded, and the width of the bitmap sources must match their planar configuration.</para>
		/// <para>Additionally, if a pixel format is set via IWICBitmapFrameEncode::SetPixelFormat, it must be GUID_WICPixelFormat24bppBGR.</para>
		/// <para>The supported pixel formats of the bitmap sources passed into this method are as follows:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Plane Count</term>
		/// <term>Plane 1</term>
		/// <term>Plane 2</term>
		/// <term>Plane 3</term>
		/// </listheader>
		/// <item>
		/// <term>3</term>
		/// <term>GUID_WICPixelFormat8bppY</term>
		/// <term>GUID_WICPixelFormat8bppCb</term>
		/// <term>GUID_WICPixelFormat8bppCr</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>GUID_WICPixelFormat8bppY</term>
		/// <term>GUID_WICPixelFormat16bppCbCr</term>
		/// <term>N/A</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicplanarbitmapframeencode-writesource HRESULT
		// WriteSource( IWICBitmapSource **ppPlanes, UINT cPlanes, WICRect *prcSource );
		void WriteSource([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IWICBitmapSource[] ppPlanes, uint cPlanes, [In] PWICRect prcSource);
	}

	/// <summary>
	/// <para>
	/// Provides access to planar Y’CbCr pixel formats where pixel components are stored in separate component planes. This interface
	/// also allows access to other codec optimizations for flip/rotate, scale, and format conversion to other Y’CbCr planar formats;
	/// this is similar to the pre-existing IWICBitmapSourceTransform interface.
	/// </para>
	/// <para>
	/// QueryInterface can be used to obtain this interface from the Windows provided implementations of IWICBitmapFrameDecode for the
	/// JPEG decoder, IWICBitmapScaler, IWICBitmapFlipRotator, and IWICColorTransform.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicplanarbitmapsourcetransform
	[ComImport, Guid("3AFF9CCE-BE95-4303-B927-E7D16FF4A613"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICPlanarBitmapSourceTransform
	{
		/// <summary>
		/// <para>
		/// Use this method to determine if a desired planar output is supported and allow the caller to choose an optimized code path
		/// if it is. Otherwise, callers should fall back to IWICBitmapSourceTransform or IWICBitmapSource and retrieve interleaved pixels.
		/// </para>
		/// <para>The following transforms can be checked:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Determine if the flip/rotate option specified via WICBitmapTransformOptions is supported.</term>
		/// </item>
		/// <item>
		/// <term>Determine if the requested planar pixel format configuration is supported.</term>
		/// </item>
		/// <item>
		/// <term>Determine the closest dimensions the implementation can natively scale to given the desired dimensions.</term>
		/// </item>
		/// </list>
		/// <para>
		/// When a transform is supported, this method returns the description of the resulting planes in the pPlaneDescriptions parameter.
		/// </para>
		/// </summary>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// On input, the desired width. On output, the closest supported width to the desired width; this is the same size or larger
		/// than the desired width.
		/// </para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// On input, the desired height. On output, the closest supported height to the desired height; this is the same size or larger
		/// than the desired width.
		/// </para>
		/// </param>
		/// <param name="dstTransform">
		/// <para>Type: <c>WICBitmapTransformOptions</c></para>
		/// <para>
		/// The desired rotation or flip operation. Multiple WICBitmapTransformOptions can be combined in this flag parameter, see <c>WICBitmapTransformOptions</c>.
		/// </para>
		/// </param>
		/// <param name="dstPlanarOptions">
		/// <para>Type: <c>WICPlanarOptions</c></para>
		/// <para>Used to specify additional configuration options for the transform. See WICPlanarOptions for more detail.</para>
		/// <para>WIC JPEG Decoder:</para>
		/// <para>
		/// WICPlanarOptionsPreserveSubsampling can be specified to retain the subsampling ratios when downscaling. By default, the JPEG
		/// decoder attempts to preserve quality by downscaling only the Y plane in some cases, changing the image to 4:4:4 chroma subsampling.
		/// </para>
		/// </param>
		/// <param name="pguidDstFormats">
		/// <para>Type: <c>const WICPixelFormatGUID*</c></para>
		/// <para>The requested pixel formats of the respective planes.</para>
		/// </param>
		/// <param name="pPlaneDescriptions">
		/// <para>Type: <c>WICBitmapPlaneDescription*</c></para>
		/// <para>When *pfIsSupported == TRUE, the array of plane descriptions contains the size and format of each of the planes.</para>
		/// <para>
		/// WIC JPEG Decoder: The Cb and Cr planes can be a different size from the values returned by puiWidth and puiHeight due to
		/// chroma subsampling.
		/// </para>
		/// </param>
		/// <param name="cPlanes">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of component planes requested.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Set to TRUE if the requested transforms are natively supported.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicplanarbitmapsourcetransform-doessupporttransform
		// HRESULT DoesSupportTransform( UINT *puiWidth, UINT *puiHeight, WICBitmapTransformOptions dstTransform, WICPlanarOptions
		// dstPlanarOptions, const WICPixelFormatGUID *pguidDstFormats, WICBitmapPlaneDescription *pPlaneDescriptions, UINT cPlanes,
		// BOOL *pfIsSupported );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool DoesSupportTransform(ref uint puiWidth, ref uint puiHeight, WICBitmapTransformOptions dstTransform, WICPlanarOptions dstPlanarOptions, [In] Guid[] pguidDstFormats, [Out] WICBitmapPlaneDescription[] pPlaneDescriptions, uint cPlanes);

		/// <summary>
		/// <para>Copies pixels into the destination planes. Configured by the supplied input parameters.</para>
		/// <para>
		/// If a dstTransform, scale, or format conversion is specified, cbStride is the transformed stride and is based on the
		/// destination pixel format of the pDstPlanes parameter, not the original source's pixel format.
		/// </para>
		/// </summary>
		/// <param name="prcSource">
		/// <para>Type: <c>const WICRect*</c></para>
		/// <para>The source rectangle of pixels to copy.</para>
		/// </param>
		/// <param name="uiWidth">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The width to scale the source bitmap. This parameter must be equal to a value obtainable through
		/// IWICPlanarBitmapSourceTransform:: DoesSupportTransform.
		/// </para>
		/// </param>
		/// <param name="uiHeight">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The height to scale the source bitmap. This parameter must be equal to a value obtainable through
		/// IWICPlanarBitmapSourceTransform:: DoesSupportTransform.
		/// </para>
		/// </param>
		/// <param name="dstTransform">
		/// <para>Type: <c>WICBitmapTransformOptions</c></para>
		/// <para>
		/// The desired rotation or flip to perform prior to the pixel copy. A rotate can be combined with a flip horizontal or a flip
		/// vertical, see WICBitmapTransformOptions.
		/// </para>
		/// </param>
		/// <param name="dstPlanarOptions">
		/// <para>Type: <c>const WICPlanarOptions</c></para>
		/// <para>Used to specify additional configuration options for the transform. See WICPlanarOptions for more detail.</para>
		/// <para>
		/// WIC JPEG Decoder: WICPlanarOptionsPreserveSubsampling can be specified to retain the subsampling ratios when downscaling. By
		/// default, the JPEG decoder attempts to preserve quality by downscaling only the Y plane in some cases, changing the image to
		/// 4:4:4 chroma subsampling.
		/// </para>
		/// </param>
		/// <param name="pDstPlanes">
		/// <para>Type: <c>WICBitmapPlane</c></para>
		/// <para>
		/// Specifies the pixel format and output buffer for each component plane. The number of planes and pixel format of each plane
		/// must match values obtainable through IWICPlanarBitmapSourceTransform::DoesSupportTransform.
		/// </para>
		/// </param>
		/// <param name="cPlanes">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of component planes specified by the pDstPlanes parameter.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// WIC JPEG Decoder: Depending on the configured chroma subsampling of the image, the source rectangle has the following restrictions:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Chroma Subsampling</term>
		/// <term>X Coordinate</term>
		/// <term>Y Coordinate</term>
		/// <term>Chroma Width</term>
		/// <term>Chroma Height</term>
		/// </listheader>
		/// <item>
		/// <term>4:2:0</term>
		/// <term>Multiple of 2</term>
		/// <term>Multiple of 2</term>
		/// <term>lumaWidth / 2 Rounded up to the nearest integer.</term>
		/// <term>lumaHeight / 2 Rounded up to the nearest integer.</term>
		/// </item>
		/// <item>
		/// <term>4:2:2</term>
		/// <term>Multiple of 2</term>
		/// <term>Any</term>
		/// <term>lumaWidth / 2 Rounded up to the nearest integer.</term>
		/// <term>lumaHeight</term>
		/// </item>
		/// <item>
		/// <term>4:4:4</term>
		/// <term>Any</term>
		/// <term>Any</term>
		/// <term>llumaWidth</term>
		/// <term>llumaHeight</term>
		/// </item>
		/// <item>
		/// <term>4:4:0</term>
		/// <term>Any</term>
		/// <term>Multiple of 2</term>
		/// <term>lumaWidth</term>
		/// <term>llumaHeight / 2 Rounded up to the nearest integer.</term>
		/// </item>
		/// </list>
		/// <para>The pDstPlanes parameter supports the following pixel formats.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Plane Count</term>
		/// <term>Plane 1</term>
		/// <term>Plane 2</term>
		/// <term>Plane 3</term>
		/// </listheader>
		/// <item>
		/// <term>3</term>
		/// <term>GUID_WICPixelFormat8bppY</term>
		/// <term>GUID_WICPixelFormat8bppCb</term>
		/// <term>GUID_WICPixelFormat8bppCr</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>GUID_WICPixelFormat8bppY</term>
		/// <term>GUID_WICPixelFormat16bppCbCr</term>
		/// <term>N/A</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicplanarbitmapsourcetransform-copypixels HRESULT
		// CopyPixels( const WICRect *prcSource, UINT uiWidth, UINT uiHeight, WICBitmapTransformOptions dstTransform, WICPlanarOptions
		// dstPlanarOptions, const WICBitmapPlane *pDstPlanes, UINT cPlanes );
		void CopyPixels([In] PWICRect prcSource, uint uiWidth, uint uiHeight, WICBitmapTransformOptions dstTransform, WICPlanarOptions dstPlanarOptions, [In] WICBitmapPlane[] pDstPlanes, uint cPlanes);
	}

	/// <summary>
	/// Allows a format converter to be initialized with a planar source. You can use QueryInterface to obtain this interface from the
	/// Windows provided implementation of IWICFormatConverter.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicplanarformatconverter
	[PInvokeData("wincodec.h", MSDNShortId = "07258A07-84AA-4DC2-B2E3-14A43AED5617")]
	[ComImport, Guid("BEBEE9CB-83B0-4DCC-8132-B0AAA55EAC96"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(WICPlanarFormatConverter))]
	public interface IWICPlanarFormatConverter : IWICBitmapSource
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

		/// <summary>Initializes a format converter with a planar source, and specifies the interleaved output pixel format.</summary>
		/// <param name="ppPlanes">
		/// <para>Type: <c>IWICBitmapSource**</c></para>
		/// <para>An array of IWICBitmapSource that represents image planes.</para>
		/// </param>
		/// <param name="cPlanes">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of component planes specified by the planes parameter.</para>
		/// </param>
		/// <param name="dstFormat">
		/// <para>Type: <c>REFWICPixelFormatGUID</c></para>
		/// <para>The destination interleaved pixel format.</para>
		/// </param>
		/// <param name="dither">
		/// <para>Type: <c>WICBitmapDitherType</c></para>
		/// <para>The WICBitmapDitherType used for conversion.</para>
		/// </param>
		/// <param name="pIPalette">
		/// <para>Type: <c>IWICPalette*</c></para>
		/// <para>The palette to use for conversion.</para>
		/// </param>
		/// <param name="alphaThresholdPercent">
		/// <para>Type: <c>double</c></para>
		/// <para>The alpha threshold to use for conversion.</para>
		/// </param>
		/// <param name="paletteTranslate">
		/// <para>Type: <c>WICBitmapPaletteType</c></para>
		/// <para>The palette translation type to use for conversion.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicplanarformatconverter-initialize HRESULT
		// Initialize( IWICBitmapSource **ppPlanes, UINT cPlanes, REFWICPixelFormatGUID dstFormat, WICBitmapDitherType dither,
		// IWICPalette *pIPalette, double alphaThresholdPercent, WICBitmapPaletteType paletteTranslate );
		void Initialize([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IWICBitmapSource[] ppPlanes, uint cPlanes,
			in Guid dstFormat, WICBitmapDitherType dither, [Optional] IWICPalette? pIPalette, double alphaThresholdPercent, WICBitmapPaletteType paletteTranslate);

		/// <summary>Query if the format converter can convert from one format to another.</summary>
		/// <param name="pSrcPixelFormats">An array of WIC pixel formats that represents source image planes.</param>
		/// <param name="cSrcPlanes">The number of source pixel formats specified by the pSrcFormats parameter.</param>
		/// <param name="dstPixelFormat">The destination interleaved pixel format.</param>
		/// <returns>True if the conversion is supported.</returns>
		/// <remarks>To specify an interleaved input pixel format, provide a length 1 array to pSrcPixelFormats.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicplanarformatconverter-canconvert HRESULT
		// CanConvert( const WICPixelFormatGUID *pSrcPixelFormats, UINT cSrcPlanes, REFWICPixelFormatGUID dstPixelFormat, BOOL
		// *pfCanConvert );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool CanConvert([In] Guid[] pSrcPixelFormats, uint cSrcPlanes, in Guid dstPixelFormat);
	}

	/// <summary>
	/// <c>IWICProgressCallback</c> interface is documented only for compliance; its use is not recommended and may be altered or
	/// unavailable in the future. Instead, and use RegisterProgressNotification.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicprogresscallback
	[PInvokeData("wincodec.h", MSDNShortId = "cd94e0a1-c275-458e-ae7f-85b703fc660e")]
	[ComImport, Guid("4776F9CD-9517-45FA-BF24-E89C5EC5C60C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICProgressCallback
	{
		/// <summary>
		/// <c>Notify</c> method is documented only for compliance; its use is not recommended and may be altered or unavailable in the
		/// future. Instead, and use RegisterProgressNotification.
		/// </summary>
		/// <param name="uFrameNum">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The current frame number.</para>
		/// </param>
		/// <param name="operation">
		/// <para>Type: <c>WICProgressOperation</c></para>
		/// <para>The operation on which progress is being reported.</para>
		/// </param>
		/// <param name="dblProgress">
		/// <para>Type: <c>double</c></para>
		/// <para>
		/// The progress value ranging from is 0.0 to 1.0. 0.0 indicates the beginning of the operation. 1.0 indicates the end of the operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicprogresscallback-notify HRESULT Notify( ULONG
		// uFrameNum, WICProgressOperation operation, double dblProgress );
		[PreserveSig]
		HRESULT Notify(uint uFrameNum, WICProgressOperation operation, double dblProgress);
	}

	/// <summary>Exposes methods for obtaining information about and controlling progressive decoding.</summary>
	/// <remarks>
	/// <para>
	/// Images can only be progressively decoded if they were progressively encoded. Progressive images automatically start at the
	/// highest (best quality) progressive level. The caller must manually set the decoder to a lower progressive level.
	/// </para>
	/// <para>E_NOTIMPL is returned if the codec does not support progressive level decoding.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicprogressivelevelcontrol
	[PInvokeData("wincodec.h", MSDNShortId = "d77244bc-b9d4-4b7d-b718-4ee38de46614")]
	[ComImport, Guid("DAAC296F-7AA5-4dbf-8D15-225C5976F891"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICProgressiveLevelControl
	{
		/// <summary>Gets the number of levels of progressive decoding supported by the CODEC.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Indicates the number of levels supported by the CODEC.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Users should not use this function to iterate through the progressive levels of a progressive JPEG image. JPEG progressive
		/// levels are determined by the image and do not have a fixed level count. Using this method will force the application to wait
		/// for all progressive levels to be downloaded before it can return. Instead, applications should use the following code to
		/// iterate through the progressive levels of a progressive JPEG image.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicprogressivelevelcontrol-getlevelcount HRESULT
		// GetLevelCount( UINT *pcLevels );
		uint GetLevelCount();

		/// <summary>Gets the decoder's current progressive level.</summary>
		/// <returns>
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Indicates the current level specified.</para>
		/// </returns>
		/// <remarks>
		/// The level always defaults to the highest progressive level. In order to decode a lower progressive level, SetCurrentLevel
		/// must first be called.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicprogressivelevelcontrol-getcurrentlevel HRESULT
		// GetCurrentLevel( UINT *pnLevel );
		uint GetCurrentLevel();

		/// <summary>Specifies the level to retrieve on the next call to CopyPixels.</summary>
		/// <param name="nLevel">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Specifies which level to return next. If greater than the total number of levels supported, an error will be returned.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A call does not have to request every level supported. If a caller requests level 1, without having previously requested
		/// level 0, the bits returned by the next call to CopyPixels will include both levels.
		/// </para>
		/// <para>If the requested level is invalid, the error returned is WINCODEC_ERR_INVALIDPROGRESSIVELEVEL.</para>
		/// <para>Examples</para>
		/// <para>
		/// Users should use this method to iterate through the progressive levels of a progressive JPEG image rather than the
		/// GetCurrentLevel method. JPEG progressive levels are determined by the image and do not have a fixed level count. Using
		/// <c>GetCurrentLevel</c> method will force the application to wait for all progressive levels to be downloaded before it can
		/// return. Instead, applications should use the following code to iterate through the progressive levels of a progressive JPEG image.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicprogressivelevelcontrol-setcurrentlevel HRESULT
		// SetCurrentLevel( UINT nLevel );
		void SetCurrentLevel(uint nLevel);
	}

	/// <summary>Represents a Windows Imaging Component (WIC) stream for referencing imaging and metadata content.</summary>
	/// <remarks>
	/// <para>
	/// Decoders and metadata handlers are expected to create sub streams of whatever stream they hold when handing off control for
	/// embedded metadata to another metadata handler. If the stream is not restricted then use MAXLONGLONG as the max size and offset 0.
	/// </para>
	/// <para>
	/// The <c>IWICStream</c> interface methods do not enable you to provide a file sharing option. To create a file stream for an
	/// image, use the SHCreateStreamOnFileEx function. This stream can then be used to create an IWICBitmapDecoder using the
	/// CreateDecoderFromStream method.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nn-wincodec-iwicstream
	[PInvokeData("wincodec.h", MSDNShortId = "bc398732-037d-4f48-940f-c70975447972")]
	[ComImport, Guid("135FF860-22B7-4ddf-B0F6-218F4F299A43"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICStream : IStream, ISequentialStream
	{
		/// <inheritdoc/>
		new void Read(byte[] pv, int cb, IntPtr pcbRead);

		/// <inheritdoc/>
		new void Write(byte[] pv, int cb, IntPtr pcbWritten);

		/// <inheritdoc/>
		new void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);

		/// <inheritdoc/>
		new void SetSize(long libNewSize);

		/// <inheritdoc/>
		new void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);

		/// <inheritdoc/>
		new void Commit(int grfCommitFlags);

		/// <inheritdoc/>
		new void Revert();

		/// <inheritdoc/>
		new void LockRegion(long libOffset, long cb, int dwLockType);

		/// <inheritdoc/>
		new void UnlockRegion(long libOffset, long cb, int dwLockType);

		/// <inheritdoc/>
		new void Stat(out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, int grfStatFlag);

		/// <inheritdoc/>
		new void Clone(out IStream ppstm);

		/// <summary>Initializes a stream from another stream. Access rights are inherited from the underlying stream.</summary>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>The initialize stream.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicstream-initializefromistream HRESULT
		// InitializeFromIStream( IStream *pIStream );
		void InitializeFromIStream(IStream pIStream);

		/// <summary>Initializes a stream from a particular file.</summary>
		/// <param name="wzFileName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The file used to initialize the stream.</para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The desired file access mode.</para>
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
		/// </param>
		/// <remarks>
		/// <para>
		/// The IWICStream interface methods do not enable you to provide a file sharing option. To create a shared file stream for an
		/// image, use the SHCreateStreamOnFileEx function. This stream can then be used to create an IWICBitmapDecoder using the
		/// CreateDecoderFromStream method.
		/// </para>
		/// <para>Examples</para>
		/// <para>This example demonstrates the use of the <c>InitializeFromFilename</c> to create an image decoder.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicstream-initializefromfilename HRESULT
		// InitializeFromFilename( LPCWSTR wzFileName, DWORD dwDesiredAccess );
		void InitializeFromFilename([MarshalAs(UnmanagedType.LPWStr)] string wzFileName, ACCESS_MASK dwDesiredAccess);

		/// <summary>Initializes a stream to treat a block of memory as a stream. The stream cannot grow beyond the buffer size.</summary>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Pointer to the buffer used to initialize the stream.</para>
		/// </param>
		/// <param name="cbBufferSize">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size of buffer.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method should be avoided whenever possible. The caller is responsible for ensuring the memory block is valid for the
		/// lifetime of the stream when using <c>InitializeFromMemory</c>. A workaround for this behavior is to create an IStream and
		/// use InitializeFromIStream to create the IWICStream.
		/// </para>
		/// <para>If you require a growable memory stream, use CreateStreamOnHGlobal.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicstream-initializefrommemory HRESULT
		// InitializeFromMemory( WICInProcPointer pbBuffer, DWORD cbBufferSize );
		void InitializeFromMemory([In] IntPtr pbBuffer, uint cbBufferSize);

		/// <summary>Initializes the stream as a substream of another stream.</summary>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>Pointer to the input stream.</para>
		/// </param>
		/// <param name="ulOffset">
		/// <para>Type: <c>ULARGE_INTEGER</c></para>
		/// <para>The stream offset used to create the new stream.</para>
		/// </param>
		/// <param name="ulMaxSize">
		/// <para>Type: <c>ULARGE_INTEGER</c></para>
		/// <para>The maximum size of the stream.</para>
		/// </param>
		/// <remarks>
		/// The stream functions with its own stream position, independent of the underlying stream but restricted to a region. All seek
		/// positions are relative to the sub region. It is allowed, though not recommended, to have multiple writable sub streams
		/// overlapping the same range.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-iwicstream-initializefromistreamregion HRESULT
		// InitializeFromIStreamRegion( IStream *pIStream, ULARGE_INTEGER ulOffset, ULARGE_INTEGER ulMaxSize );
		void InitializeFromIStreamRegion(IStream pIStream, ulong ulOffset, ulong ulMaxSize);
	}

	/// <summary>Exposes methods for a stream provider.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nn-wincodecsdk-iwicstreamprovider
	[PInvokeData("wincodecsdk.h", MSDNShortId = "fdcaf668-a5c3-4852-8bc9-5535f0756592")]
	[ComImport, Guid("449494BC-B468-4927-96D7-BA90D31AB505"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWICStreamProvider
	{
		/// <summary>Gets the stream held by the component.</summary>
		/// <returns>
		/// <para>Type: <c>IStream**</c></para>
		/// <para>Pointer that receives a pointer to the stream held by the component.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicstreamprovider-getstream HRESULT GetStream(
		// IStream **ppIStream );
		IStream GetStream();

		/// <summary>Gets the persist options used when initializing the component with a stream.</summary>
		/// <returns>
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// Pointer that receives the persist options used when initializing the component with a stream. If none were provided,
		/// <c>WICPersistOptionDefault</c> is returned.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicstreamprovider-getpersistoptions HRESULT
		// GetPersistOptions( DWORD *pdwPersistOptions );
		WICPersistOptions GetPersistOptions();

		/// <summary>Gets the preferred vendor GUID.</summary>
		/// <returns>
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer that receives the preferred vendor GUID.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicstreamprovider-getpreferredvendorguid
		// HRESULT GetPreferredVendorGUID( GUID *pguidPreferredVendor );
		Guid GetPreferredVendorGUID();

		/// <summary>
		/// Informs the component that the content of the stream it's holding onto may have changed. The component should respond by
		/// dirtying any cached information from the stream.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/nf-wincodecsdk-iwicstreamprovider-refreshstream HRESULT RefreshStream();
		void RefreshStream();
	}

	private static T[] GetArray<T>(GetArrayAction<T> action)
	{
		action(0, null, out var sz);
		var a = new T[(int)sz];
		action(sz, a, out _);
		return a;
	}

	private static string GetString(GetStringAction action)
	{
		action(0, null, out var sz);
		var sb = new StringBuilder((int)sz);
		action(sz, sb, out _);
		return sb.ToString();
	}

	/// <summary>CLSID_WICAdngDecoder</summary>
	[ComImport, Guid("981d9411-909e-42a7-8f5d-a747ff052edb"), ClassInterface(ClassInterfaceType.None)]
	public class WICAdngDecoder { }

	/// <summary>CLSID_WICBmpDecoder</summary>
	[ComImport, Guid("6b462062-7cbf-400d-9fdb-813dd10f2778"), ClassInterface(ClassInterfaceType.None)]
	public class WICBmpDecoder { }

	/// <summary>CLSID_WICBmpEncoder</summary>
	[ComImport, Guid("69be8bb4-d66d-47c8-865a-ed1589433782"), ClassInterface(ClassInterfaceType.None)]
	public class WICBmpEncoder { }

	/// <summary>CLSID_WICDdsDecoder</summary>
	[ComImport, Guid("9053699f-a341-429d-9e90-ee437cf80c73"), ClassInterface(ClassInterfaceType.None)]
	public class WICDdsDecoder { }

	/// <summary>CLSID_WICDdsEncoder</summary>
	[ComImport, Guid("a61dde94-66ce-4ac1-881b-71680588895e"), ClassInterface(ClassInterfaceType.None)]
	public class WICDdsEncoder { }

	/// <summary>CLSID_WICDefaultFormatConverter</summary>
	[ComImport, Guid("1a3f11dc-b514-4b17-8c5f-2154513852f1"), ClassInterface(ClassInterfaceType.None)]
	public class WICDefaultFormatConverter { }

	/// <summary>CLSID_WICFormatConverterHighColor</summary>
	[ComImport, Guid("ac75d454-9f37-48f8-b972-4e19bc856011"), ClassInterface(ClassInterfaceType.None)]
	public class WICFormatConverterHighColor { }

	/// <summary>CLSID_WICFormatConverterNChannel</summary>
	[ComImport, Guid("c17cabb2-d4a3-47d7-a557-339b2efbd4f1"), ClassInterface(ClassInterfaceType.None)]
	public class WICFormatConverterNChannel { }

	/// <summary>CLSID_WICFormatConverterWMPhoto</summary>
	[ComImport, Guid("9cb5172b-d600-46ba-ab77-77bb7e3a00d9"), ClassInterface(ClassInterfaceType.None)]
	public class WICFormatConverterWMPhoto { }

	/// <summary>CLSID_WICGifDecoder</summary>
	[ComImport, Guid("381dda3c-9ce9-4834-a23e-1f98f8fc52be"), ClassInterface(ClassInterfaceType.None)]
	public class WICGifDecoder { }

	/// <summary>CLSID_WICGifEncoder</summary>
	[ComImport, Guid("114f5598-0b22-40a0-86a1-c83ea495adbd"), ClassInterface(ClassInterfaceType.None)]
	public class WICGifEncoder { }

	/// <summary>CLSID_WICHeifDecoder</summary>
	[ComImport, Guid("e9A4A80a-44fe-4DE4-8971-7150B10a5199"), ClassInterface(ClassInterfaceType.None)]
	public class WICHeifDecoder { }

	/// <summary>CLSID_WICHeifEncoder</summary>
	[ComImport, Guid("0dbecec1-9eb3-4860-9c6f-ddbe86634575"), ClassInterface(ClassInterfaceType.None)]
	public class WICHeifEncoder { }

	/// <summary>CLSID_WICIcoDecoder</summary>
	[ComImport, Guid("c61bfcdf-2e0f-4aad-a8d7-e06bafebcdfe"), ClassInterface(ClassInterfaceType.None)]
	public class WICIcoDecoder { }

	/// <summary>CLSID_WICImagingCategories</summary>
	[ComImport, Guid("fae3d380-fea4-4623-8c75-c6b61110b681"), ClassInterface(ClassInterfaceType.None)]
	public class WICImagingCategories { }

	/// <summary>CLSID_WICImagingFactory</summary>
	[ComImport, Guid("cacaf262-9370-4615-a13b-9f5539da4c0a"), ClassInterface(ClassInterfaceType.None)]
	public class WICImagingFactory { }

	/// <summary>CLSID_WICImagingFactory2</summary>
	[ComImport, Guid("317d06e8-5f24-433d-bdf7-79ce68d8abc2"), ClassInterface(ClassInterfaceType.None)]
	public class WICImagingFactory2 { }

	/// <summary>CLSID_WICJpegDecoder</summary>
	[ComImport, Guid("9456a480-e88b-43ea-9e73-0b2d9b71b1ca"), ClassInterface(ClassInterfaceType.None)]
	public class WICJpegDecoder { }

	/// <summary>CLSID_WICJpegEncoder</summary>
	[ComImport, Guid("1a34f5c1-4a5a-46dc-b644-1f4567e7a676"), ClassInterface(ClassInterfaceType.None)]
	public class WICJpegEncoder { }

	/// <summary>CLSID_WICJpegQualcommPhoneEncoder</summary>
	[ComImport, Guid("68ed5c62-f534-4979-b2b3-686a12b2b34c"), ClassInterface(ClassInterfaceType.None)]
	public class WICJpegQualcommPhoneEncoder { }

	/// <summary>CLSID_WICPlanarFormatConverter</summary>
	[ComImport, Guid("184132b8-32f8-4784-9131-dd7224b23438"), ClassInterface(ClassInterfaceType.None)]
	public class WICPlanarFormatConverter { }

	/// <summary>CLSID_WICPngDecoder</summary>
	[ComImport, Guid("389ea17b-5078-4cde-b6ef-25c15175c751"), ClassInterface(ClassInterfaceType.None)]
	public class WICPngDecoder { }

	/// <summary>CLSID_WICPngDecoder1</summary>
	[ComImport, Guid("389ea17b-5078-4cde-b6ef-25c15175c751"), ClassInterface(ClassInterfaceType.None)]
	public class WICPngDecoder1 { }

	/// <summary>CLSID_WICPngDecoder2</summary>
	[ComImport, Guid("e018945b-aa86-4008-9bd4-6777a1e40c11"), ClassInterface(ClassInterfaceType.None)]
	public class WICPngDecoder2 { }

	/// <summary>CLSID_WICPngEncoder</summary>
	[ComImport, Guid("27949969-876a-41d7-9447-568f6a35a4dc"), ClassInterface(ClassInterfaceType.None)]
	public class WICPngEncoder { }

	/// <summary>CLSID_WICRAWDecoder</summary>
	[ComImport, Guid("41945702-8302-44A6-9445-AC98E8AFA086"), ClassInterface(ClassInterfaceType.None)]
	public class WICRAWDecoder { }

	/// <summary>CLSID_WICTiffDecoder</summary>
	[ComImport, Guid("b54e85d9-fe23-499f-8b88-6acea713752b"), ClassInterface(ClassInterfaceType.None)]
	public class WICTiffDecoder { }

	/// <summary>CLSID_WICTiffEncoder</summary>
	[ComImport, Guid("0131be10-2001-4c5f-a9b0-cc88fab64ce8"), ClassInterface(ClassInterfaceType.None)]
	public class WICTiffEncoder { }

	/// <summary>CLSID_WICWebpDecoder</summary>
	[ComImport, Guid("7693E886-51C9-4070-8419-9F70738EC8FA"), ClassInterface(ClassInterfaceType.None)]
	public class WICWebpDecoder { }

	/// <summary>CLSID_WICWmpDecoder</summary>
	[ComImport, Guid("a26cec36-234c-4950-ae16-e34aace71d0d"), ClassInterface(ClassInterfaceType.None)]
	public class WICWmpDecoder { }

	/// <summary>CLSID_WICWmpEncoder</summary>
	[ComImport, Guid("ac4ce3cb-e1c1-44cd-8215-5a1665509ec2"), ClassInterface(ClassInterfaceType.None)]
	public class WICWmpEncoder { }
}