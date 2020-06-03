using System;

namespace Vanara.PInvoke
{
	/// <summary>Items from the WindowsCodecs.dll</summary>
	public static partial class WindowsCodecs
	{
		/// <summary>
		/// The format of the quantization table indices. Use one of the following constants, described in IWICJpegFrameDecode Constants.
		/// </summary>
		[PInvokeData("wincodec.h", MSDNShortId = "87A36F9B-CD6B-4343-AAA7-9FDBAD41E38A")]
		public enum WIC_JPEG_HUFFMAN_BASELINE
		{
			/// <summary/>
			WIC_JPEG_HUFFMAN_BASELINE_ONE = 0,

			/// <summary/>
			WIC_JPEG_HUFFMAN_BASELINE_THREE = 0x111100
		}

		/// <summary>
		/// The format of the quantization table indices. Use one of the following constants, described in IWICJpegFrameDecode Constants.
		/// </summary>
		[PInvokeData("wincodec.h", MSDNShortId = "BB207D78-9E27-49A4-91E4-601CED109389")]
		public enum WIC_JPEG_QUANTIZATION_BASELINE
		{
			/// <summary/>
			WIC_JPEG_QUANTIZATION_BASELINE_ONE = 0,

			/// <summary/>
			WIC_JPEG_QUANTIZATION_BASELINE_THREE = 0x10100,
		}

		/// <summary>The sample factors. Use one of the following constants, described in IWICJpegFrameDecode Constants.</summary>
		[PInvokeData("wincodec.h", MSDNShortId = "BB207D78-9E27-49A4-91E4-601CED109389")]
		public enum WIC_JPEG_SAMPLE_FACTORS
		{
			/// <summary/>
			WIC_JPEG_SAMPLE_FACTORS_ONE = 0x11,

			/// <summary/>
			WIC_JPEG_SAMPLE_FACTORS_THREE_420 = 0x111122,

			/// <summary/>
			WIC_JPEG_SAMPLE_FACTORS_THREE_422 = 0x111121,

			/// <summary/>
			WIC_JPEG_SAMPLE_FACTORS_THREE_440 = 0x111112,

			/// <summary/>
			WIC_JPEG_SAMPLE_FACTORS_THREE_444 = 0x111111,
		}

		/// <summary>Specifies the identifiers of the metadata items in an 8BIM IPTC digest metadata block.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wic8bimiptcdigestproperties typedef enum
		// WIC8BIMIptcDigestProperties { WIC8BIMIptcDigestPString, WIC8BIMIptcDigestIptcDigest, WIC8BIMIptcDigestProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "b0dbd1fa-face-4f6f-a943-60d108388b97")]
		public enum WIC8BIMIptcDigestProperties
		{
			/// <summary>[VT_LPSTR] A name that identifies the 8BIM block.</summary>
			WIC8BIMIptcDigestPString = 1,

			/// <summary>[VT_BLOB] The embedded IPTC digest value.</summary>
			WIC8BIMIptcDigestIptcDigest,

			/// <summary/>
			WIC8BIMIptcDigestProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the identifiers of the metadata items in an 8BIM IPTC block.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wic8bimiptcproperties typedef enum WIC8BIMIptcProperties
		// { WIC8BIMIptcPString, WIC8BIMIptcEmbeddedIPTC, WIC8BIMIptcProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "c752790c-6392-4406-b006-8f5da9f4e23d")]
		public enum WIC8BIMIptcProperties
		{
			/// <summary>[VT_LPSTR] A name that identifies the 8BIM block.</summary>
			WIC8BIMIptcPString,

			/// <summary/>
			WIC8BIMIptcEmbeddedIPTC,

			/// <summary/>
			WIC8BIMIptcProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the identifiers of the metadata items in an 8BIMResolutionInfo block.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wic8bimresolutioninfoproperties typedef enum
		// WIC8BIMResolutionInfoProperties { WIC8BIMResolutionInfoPString, WIC8BIMResolutionInfoHResolution,
		// WIC8BIMResolutionInfoHResolutionUnit, WIC8BIMResolutionInfoWidthUnit, WIC8BIMResolutionInfoVResolution,
		// WIC8BIMResolutionInfoVResolutionUnit, WIC8BIMResolutionInfoHeightUnit, WIC8BIMResolutionInfoProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "a5bb984a-290c-4dd6-8b94-b8a221e78a6b")]
		public enum WIC8BIMResolutionInfoProperties
		{
			/// <summary>[VT_LPSTR] A name that identifies the 8BIM block.</summary>
			WIC8BIMResolutionInfoPString = 1,

			/// <summary>[VT_UI4] The horizontal resolution of the image.</summary>
			WIC8BIMResolutionInfoHResolution,

			/// <summary>
			/// [VT_UI2] The units that the horizontal resolution is specified in; a 1 indicates pixels per inch and a 2 indicates pixels
			/// per centimeter.
			/// </summary>
			WIC8BIMResolutionInfoHResolutionUnit,

			/// <summary>
			/// [VT_UI2] The units that the image width is specified in; a 1 indicates inches, a 2 indicates centimeters, a 3 indicates
			/// points, a 4 specifies picas, and a 5 specifies columns.
			/// </summary>
			WIC8BIMResolutionInfoWidthUnit,

			/// <summary>[VT_UI4] The vertical resolution of the image.</summary>
			WIC8BIMResolutionInfoVResolution,

			/// <summary>
			/// [VT_UI2] The units that the vertical resolution is specified in; a 1 indicates pixels per inch and a 2 indicates pixels per centimeter.
			/// </summary>
			WIC8BIMResolutionInfoVResolutionUnit,

			/// <summary>
			/// [VT_UI2] The units that the image height is specified in; a 1 indicates inches, a 2 indicates centimeters, a 3 indicates
			/// points, a 4 specifies picas, and a 5 specifies columns.
			/// </summary>
			WIC8BIMResolutionInfoHeightUnit,

			/// <summary/>
			WIC8BIMResolutionInfoProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the desired alpha channel usage.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicbitmapalphachanneloption typedef enum
		// WICBitmapAlphaChannelOption { WICBitmapUseAlpha, WICBitmapUsePremultipliedAlpha, WICBitmapIgnoreAlpha,
		// WICBITMAPALPHACHANNELOPTIONS_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "caa10c35-9af4-4310-b031-3347cf795087")]
		public enum WICBitmapAlphaChannelOption
		{
			/// <summary>Use alpha channel.</summary>
			WICBitmapUseAlpha,

			/// <summary>Use a pre-multiplied alpha channel.</summary>
			WICBitmapUsePremultipliedAlpha,

			/// <summary>Ignore alpha channel.</summary>
			WICBitmapIgnoreAlpha,

			/// <summary>Sentinel value.</summary>
			WICBITMAPALPHACHANNELOPTIONS_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the desired cache usage.</summary>
		/// <remarks>
		/// The <c>CreateBitmap</c> of the IWICImagingFactory interface does not support WICBitmapNoCache when the pixelFormat is a native
		/// pixel format provided by Windows Imaging Component (WIC).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicbitmapcreatecacheoption typedef enum
		// WICBitmapCreateCacheOption { WICBitmapNoCache, WICBitmapCacheOnDemand, WICBitmapCacheOnLoad,
		// WICBITMAPCREATECACHEOPTION_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "121d394d-e818-44c5-bf44-3b01df61c780")]
		[Flags]
		public enum WICBitmapCreateCacheOption
		{
			/// <summary>Do not cache the bitmap.</summary>
			WICBitmapNoCache = 0,

			/// <summary>Cache the bitmap when needed.</summary>
			WICBitmapCacheOnDemand = 0x01,

			/// <summary>Cache the bitmap at initialization.</summary>
			WICBitmapCacheOnLoad = 0x02,

			/// <summary/>
			WICBITMAPCREATECACHEOPTION_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the capabilities of the decoder.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicbitmapdecodercapabilities typedef enum
		// WICBitmapDecoderCapabilities { WICBitmapDecoderCapabilitySameEncoder, WICBitmapDecoderCapabilityCanDecodeAllImages,
		// WICBitmapDecoderCapabilityCanDecodeSomeImages, WICBitmapDecoderCapabilityCanEnumerateMetadata,
		// WICBitmapDecoderCapabilityCanDecodeThumbnail, WICBITMAPDECODERCAPABILITIES_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "e501b8f7-3c99-461d-be92-dca80f5657c5")]
		[Flags]
		public enum WICBitmapDecoderCapabilities
		{
			/// <summary>Decoder recognizes the image was encoded with an encoder produced by the same vendor.</summary>
			WICBitmapDecoderCapabilitySameEncoder = 0x1,

			/// <summary>Decoder can decode all the images within an image container.</summary>
			WICBitmapDecoderCapabilityCanDecodeAllImages = 0x2,

			/// <summary>Decoder can decode some of the images within an image container.</summary>
			WICBitmapDecoderCapabilityCanDecodeSomeImages = 0x4,

			/// <summary>Decoder can enumerate the metadata blocks within a container format.</summary>
			WICBitmapDecoderCapabilityCanEnumerateMetadata = 0x8,

			/// <summary>Decoder can find and decode a thumbnail.</summary>
			WICBitmapDecoderCapabilityCanDecodeThumbnail = 0x10,

			/// <summary/>
			WICBITMAPDECODERCAPABILITIES_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the type of dither algorithm to apply when converting between image formats.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicbitmapdithertype typedef enum WICBitmapDitherType {
		// WICBitmapDitherTypeNone, WICBitmapDitherTypeSolid, WICBitmapDitherTypeOrdered4x4, WICBitmapDitherTypeOrdered8x8,
		// WICBitmapDitherTypeOrdered16x16, WICBitmapDitherTypeSpiral4x4, WICBitmapDitherTypeSpiral8x8, WICBitmapDitherTypeDualSpiral4x4,
		// WICBitmapDitherTypeDualSpiral8x8, WICBitmapDitherTypeErrorDiffusion, WICBITMAPDITHERTYPE_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "e3fd8f37-8ea9-4cdb-853b-d5119b7afdc9")]
		public enum WICBitmapDitherType
		{
			/// <summary>A solid color algorithm without dither.</summary>
			WICBitmapDitherTypeNone = 0,

			/// <summary>A solid color algorithm without dither.</summary>
			WICBitmapDitherTypeSolid = WICBitmapDitherTypeNone,

			/// <summary>A 4x4 ordered dither algorithm.</summary>
			WICBitmapDitherTypeOrdered4x4,

			/// <summary>An 8x8 ordered dither algorithm.</summary>
			WICBitmapDitherTypeOrdered8x8,

			/// <summary>A 16x16 ordered dither algorithm.</summary>
			WICBitmapDitherTypeOrdered16x16,

			/// <summary>A 4x4 spiral dither algorithm.</summary>
			WICBitmapDitherTypeSpiral4x4,

			/// <summary>An 8x8 spiral dither algorithm.</summary>
			WICBitmapDitherTypeSpiral8x8,

			/// <summary>A 4x4 dual spiral dither algorithm.</summary>
			WICBitmapDitherTypeDualSpiral4x4,

			/// <summary>An 8x8 dual spiral dither algorithm.</summary>
			WICBitmapDitherTypeDualSpiral8x8,

			/// <summary>An error diffusion algorithm.</summary>
			WICBitmapDitherTypeErrorDiffusion,

			/// <summary/>
			WICBITMAPDITHERTYPE_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the cache options available for an encoder.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicbitmapencodercacheoption typedef enum
		// WICBitmapEncoderCacheOption { WICBitmapEncoderCacheInMemory, WICBitmapEncoderCacheTempFile, WICBitmapEncoderNoCache,
		// WICBITMAPENCODERCACHEOPTION_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "cc23cd53-f29b-4e4e-a3d9-038c6f0c5629")]
		[Flags]
		public enum WICBitmapEncoderCacheOption
		{
			/// <summary>The encoder is cached in memory. This option is not supported.</summary>
			WICBitmapEncoderCacheInMemory = 0,

			/// <summary>The encoder is cached to a temporary file. This option is not supported.</summary>
			WICBitmapEncoderCacheTempFile = 0x1,

			/// <summary>The encoder is not cached.</summary>
			WICBitmapEncoderNoCache = 0x2,

			/// <summary/>
			WICBITMAPENCODERCACHEOPTION_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the sampling or filtering mode to use when scaling an image.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicbitmapinterpolationmode typedef enum
		// WICBitmapInterpolationMode { WICBitmapInterpolationModeNearestNeighbor, WICBitmapInterpolationModeLinear,
		// WICBitmapInterpolationModeCubic, WICBitmapInterpolationModeFant, WICBitmapInterpolationModeHighQualityCubic,
		// WICBITMAPINTERPOLATIONMODE_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "7c707ab7-7cd5-418f-921c-e9114da92f2a")]
		public enum WICBitmapInterpolationMode
		{
			/// <summary>
			/// A nearest neighbor interpolation algorithm. Also known as nearest pixel or point interpolation. The output pixel is assigned
			/// the value of the pixel that the point falls within. No other pixels are considered.
			/// </summary>
			WICBitmapInterpolationModeNearestNeighbor,

			/// <summary>
			/// A bilinear interpolation algorithm. The output pixel values are computed as a weighted average of the nearest four pixels in
			/// a 2x2 grid.
			/// </summary>
			WICBitmapInterpolationModeLinear,

			/// <summary>
			/// A bicubic interpolation algorithm. Destination pixel values are computed as a weighted average of the nearest sixteen pixels
			/// in a 4x4 grid.
			/// </summary>
			WICBitmapInterpolationModeCubic,

			/// <summary>
			/// A Fant resampling algorithm. Destination pixel values are computed as a weighted average of the all the pixels that map to
			/// the new pixel.
			/// </summary>
			WICBitmapInterpolationModeFant,

			/// <summary>
			/// A high quality bicubic interpolation algorithm. Destination pixel values are computed using a much denser sampling kernel
			/// than regular cubic. The kernel is resized in response to the scale factor, making it suitable for downscaling by factors
			/// greater than 2.
			/// </summary>
			WICBitmapInterpolationModeHighQualityCubic,

			/// <summary/>
			WICBITMAPINTERPOLATIONMODE_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies access to an IWICBitmap.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicbitmaplockflags typedef enum WICBitmapLockFlags {
		// WICBitmapLockRead, WICBitmapLockWrite, WICBITMAPLOCKFLAGS_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "d4d1bb38-3d1a-4e1e-a889-0491f3c01822")]
		[Flags]
		public enum WICBitmapLockFlags
		{
			/// <summary>A read access lock.</summary>
			WICBitmapLockRead = 1,

			/// <summary>A write access lock.</summary>
			WICBitmapLockWrite = 2,

			/// <summary/>
			WICBITMAPLOCKFLAGS_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the type of palette used for an indexed image format.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicbitmappalettetype typedef enum WICBitmapPaletteType {
		// WICBitmapPaletteTypeCustom, WICBitmapPaletteTypeMedianCut, WICBitmapPaletteTypeFixedBW, WICBitmapPaletteTypeFixedHalftone8,
		// WICBitmapPaletteTypeFixedHalftone27, WICBitmapPaletteTypeFixedHalftone64, WICBitmapPaletteTypeFixedHalftone125,
		// WICBitmapPaletteTypeFixedHalftone216, WICBitmapPaletteTypeFixedWebPalette, WICBitmapPaletteTypeFixedHalftone252,
		// WICBitmapPaletteTypeFixedHalftone256, WICBitmapPaletteTypeFixedGray4, WICBitmapPaletteTypeFixedGray16,
		// WICBitmapPaletteTypeFixedGray256, WICBITMAPPALETTETYPE_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "a8192905-2bae-4760-bf2d-64640c46e168")]
		public enum WICBitmapPaletteType
		{
			/// <summary>An arbitrary custom palette provided by caller.</summary>
			WICBitmapPaletteTypeCustom,

			/// <summary>An optimal palette generated using a median-cut algorithm. Derived from the colors in an image.</summary>
			WICBitmapPaletteTypeMedianCut,

			/// <summary>A black and white palette.</summary>
			WICBitmapPaletteTypeFixedBW,

			/// <summary>
			/// A palette that has its 8-color on-off primaries and the 16 system colors added. With duplicates removed, 16 colors are available.
			/// </summary>
			WICBitmapPaletteTypeFixedHalftone8,

			/// <summary>
			/// A palette that has 3 intensity levels of each primary: 27-color on-off primaries and the 16 system colors added. With
			/// duplicates removed, 35 colors are available.
			/// </summary>
			WICBitmapPaletteTypeFixedHalftone27,

			/// <summary>
			/// A palette that has 4 intensity levels of each primary: 64-color on-off primaries and the 16 system colors added. With
			/// duplicates removed, 72 colors are available.
			/// </summary>
			WICBitmapPaletteTypeFixedHalftone64,

			/// <summary>
			/// A palette that has 5 intensity levels of each primary: 125-color on-off primaries and the 16 system colors added. With
			/// duplicates removed, 133 colors are available.
			/// </summary>
			WICBitmapPaletteTypeFixedHalftone125,

			/// <summary>
			/// A palette that has 6 intensity levels of each primary: 216-color on-off primaries and the 16 system colors added. With
			/// duplicates removed, 224 colors are available. This is the same as WICBitmapPaletteFixedHalftoneWeb.
			/// </summary>
			WICBitmapPaletteTypeFixedHalftone216,

			/// <summary>
			/// A palette that has 6 intensity levels of each primary: 216-color on-off primaries and the 16 system colors added. With
			/// duplicates removed, 224 colors are available. This is the same as WICBitmapPaletteTypeFixedHalftone216.
			/// </summary>
			WICBitmapPaletteTypeFixedWebPalette = WICBitmapPaletteTypeFixedHalftone216,

			/// <summary>
			/// A palette that has its 252-color on-off primaries and the 16 system colors added. With duplicates removed, 256 colors are available.
			/// </summary>
			WICBitmapPaletteTypeFixedHalftone252,

			/// <summary>
			/// A palette that has its 256-color on-off primaries and the 16 system colors added. With duplicates removed, 256 colors are available.
			/// </summary>
			WICBitmapPaletteTypeFixedHalftone256,

			/// <summary>A palette that has 4 shades of gray.</summary>
			WICBitmapPaletteTypeFixedGray4,

			/// <summary>A palette that has 16 shades of gray.</summary>
			WICBitmapPaletteTypeFixedGray16,

			/// <summary>A palette that has 256 shades of gray.</summary>
			WICBitmapPaletteTypeFixedGray256,

			/// <summary/>
			WICBITMAPPALETTETYPE_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the flip and rotation transforms.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicbitmaptransformoptions typedef enum
		// WICBitmapTransformOptions { WICBitmapTransformRotate0, WICBitmapTransformRotate90, WICBitmapTransformRotate180,
		// WICBitmapTransformRotate270, WICBitmapTransformFlipHorizontal, WICBitmapTransformFlipVertical,
		// WICBITMAPTRANSFORMOPTIONS_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "e123bb4d-bc75-4f3f-98f1-bea9b008498b")]
		[Flags]
		public enum WICBitmapTransformOptions
		{
			/// <summary>A rotation of 0 degrees.</summary>
			WICBitmapTransformRotate0,

			/// <summary>A clockwise rotation of 90 degrees.</summary>
			WICBitmapTransformRotate90,

			/// <summary>A clockwise rotation of 180 degrees.</summary>
			WICBitmapTransformRotate180,

			/// <summary>A clockwise rotation of 270 degrees.</summary>
			WICBitmapTransformRotate270,

			/// <summary>A horizontal flip. Pixels are flipped around the vertical y-axis.</summary>
			WICBitmapTransformFlipHorizontal = 0x8,

			/// <summary>A vertical flip. Pixels are flipped around the horizontal x-axis.</summary>
			WICBitmapTransformFlipVertical = 0x10,

			/// <summary/>
			WICBITMAPTRANSFORMOPTIONS_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the color context types.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wiccolorcontexttype typedef enum WICColorContextType {
		// WICColorContextUninitialized, WICColorContextProfile, WICColorContextExifColorSpace } ;
		[PInvokeData("wincodec.h", MSDNShortId = "30fab53b-8edf-488c-a6f2-5224b94e0500")]
		public enum WICColorContextType
		{
			/// <summary>An uninitialized color context.</summary>
			WICColorContextUninitialized,

			/// <summary>A color context that is a full ICC color profile.</summary>
			WICColorContextProfile,

			/// <summary>A color context that is one of a number of set color spaces (sRGB, AdobeRGB) that are defined in the EXIF specification.</summary>
			WICColorContextExifColorSpace,
		}

		/// <summary>Specifies component enumeration options.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wiccomponentenumerateoptions typedef enum
		// WICComponentEnumerateOptions { WICComponentEnumerateDefault, WICComponentEnumerateRefresh, WICComponentEnumerateDisabled,
		// WICComponentEnumerateUnsigned, WICComponentEnumerateBuiltInOnly, WICCOMPONENTENUMERATEOPTIONS_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "52cc0860-6164-4400-8e81-03eb0c44904e")]
		[Flags]
		public enum WICComponentEnumerateOptions : uint
		{
			/// <summary>
			/// Enumerate any components that are not disabled. Because this value is 0x0, it is always included with the other options.
			/// </summary>
			WICComponentEnumerateDefault = 0x0,

			/// <summary>Force a read of the registry before enumerating components.</summary>
			WICComponentEnumerateRefresh = 0x1,

			/// <summary>
			/// Include disabled components in the enumeration. The set of disabled components is disjoint with the set of default
			/// enumerated components
			/// </summary>
			WICComponentEnumerateDisabled = 0x80000000,

			/// <summary>Include unsigned components in the enumeration. This option has no effect.</summary>
			WICComponentEnumerateUnsigned = 0x40000000,

			/// <summary>At the end of component enumeration, filter out any components that are not Windows provided.</summary>
			WICComponentEnumerateBuiltInOnly = 0x20000000,

			/// <summary/>
			WICCOMPONENTENUMERATEOPTIONS_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the component signing status.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wiccomponentsigning typedef enum WICComponentSigning {
		// WICComponentSigned, WICComponentUnsigned, WICComponentSafe, WICComponentDisabled, WICCOMPONENTSIGNING_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "64f3de6d-15da-4cc8-ad74-57759bcd4d07")]
		[Flags]
		public enum WICComponentSigning : uint
		{
			/// <summary>A signed component.</summary>
			WICComponentSigned = 0x1,

			/// <summary>An unsigned component</summary>
			WICComponentUnsigned = 0x2,

			/// <summary>
			/// A component is safe. Components that do not have a binary component to sign, such as a pixel format, should return this value.
			/// </summary>
			WICComponentSafe = 0x4,

			/// <summary>A component has been disabled.</summary>
			WICComponentDisabled = 0x80000000,

			/// <summary/>
			WICCOMPONENTSIGNING_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the type of Windows Imaging Component (WIC) component.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wiccomponenttype typedef enum WICComponentType {
		// WICDecoder, WICEncoder, WICPixelFormatConverter, WICMetadataReader, WICMetadataWriter, WICPixelFormat, WICAllComponents,
		// WICCOMPONENTTYPE_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "eff6b77c-ea4b-4476-8d75-dec5bb2e1745")]
		[Flags]
		public enum WICComponentType
		{
			/// <summary>A WIC decoder.</summary>
			WICDecoder = 0x1,

			/// <summary>A WIC encoder.</summary>
			WICEncoder = 0x2,

			/// <summary>A WIC pixel converter.</summary>
			WICPixelFormatConverter = 0x4,

			/// <summary>A WIC metadata reader.</summary>
			WICMetadataReader = 0x8,

			/// <summary>A WIC metadata writer.</summary>
			WICMetadataWriter = 0x10,

			/// <summary>A WIC pixel format.</summary>
			WICPixelFormat = 0x20,

			/// <summary>All WIC components.</summary>
			WICAllComponents = 0x3f,

			/// <summary/>
			WICCOMPONENTTYPE_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the the meaning of pixel color component values contained in the DDS image.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicddsalphamode typedef enum WICDdsAlphaMode {
		// WICDdsAlphaModeUnknown, WICDdsAlphaModeStraight, WICDdsAlphaModePremultiplied, WICDdsAlphaModeOpaque, WICDdsAlphaModeCustom,
		// WICDDSALPHAMODE_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "67C9B07F-5259-4032-9EBF-CBC3B8637343")]
		public enum WICDdsAlphaMode
		{
			/// <summary>Alpha behavior is unspecified and must be determined by the reader.</summary>
			WICDdsAlphaModeUnknown,

			/// <summary>The alpha data is straight.</summary>
			WICDdsAlphaModeStraight,

			/// <summary>The alpha data is premultiplied.</summary>
			WICDdsAlphaModePremultiplied,

			/// <summary>
			/// The alpha data is opaque (UNORM value of 1). This can be used by a compliant reader as a performance optimization. For
			/// example, blending operations can be converted to copies.
			/// </summary>
			WICDdsAlphaModeOpaque,

			/// <summary>The alpha channel contains custom data that is not alpha.</summary>
			WICDdsAlphaModeCustom,

			/// <summary/>
			WICDDSALPHAMODE_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the dimension type of the data contained in DDS image.</summary>
		/// <remarks>
		/// Both <c>WICDdsTexture2d</c> and <c>WICDdsTextureCube</c> correspond to D3D11_RESOURCE_DIMENSION_TEXTURE2D. When using
		/// ID3D11Device::CreateTexture2D, they are distinguished by the flag D3D11_RESOURCE_MISC_TEXTURECUBE in the structure D3D11_TEXTURE2D_DESC.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicddsdimension typedef enum WICDdsDimension {
		// WICDdsTexture1D, WICDdsTexture2D, WICDdsTexture3D, WICDdsTextureCube, WICDDSTEXTURE_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "76CEBFD7-EE7D-48C4-9F88-9AD82C9FED55")]
		public enum WICDdsDimension
		{
			/// <summary>DDS image contains a 1-dimensional texture .</summary>
			WICDdsTexture1D,

			/// <summary>DDS image contains a 2-dimensional texture .</summary>
			WICDdsTexture2D,

			/// <summary>DDS image contains a 3-dimensional texture .</summary>
			WICDdsTexture3D,

			/// <summary>The DDS image contains a cube texture represented as an array of 6 faces.</summary>
			WICDdsTextureCube,

			/// <summary/>
			WICDDSTEXTURE_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies decode options.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicdecodeoptions typedef enum WICDecodeOptions {
		// WICDecodeMetadataCacheOnDemand, WICDecodeMetadataCacheOnLoad, WICMETADATACACHEOPTION_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "27b9d6e1-e171-4c7f-8f96-fa5a93923e35")]
		[Flags]
		public enum WICDecodeOptions
		{
			/// <summary>Cache metadata when needed.</summary>
			WICDecodeMetadataCacheOnDemand = 0,

			/// <summary>Cache metadata when decoder is loaded.</summary>
			WICDecodeMetadataCacheOnLoad = 0x1,

			/// <summary/>
			WICMETADATACACHEOPTION_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the application extension metadata properties for a Graphics Interchange Format (GIF) image.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicgifapplicationextensionproperties typedef enum
		// WICGifApplicationExtensionProperties { WICGifApplicationExtensionApplication, WICGifApplicationExtensionData,
		// WICGifApplicationExtensionProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "e60da197-2510-4a13-91e3-896d6027ee57")]
		public enum WICGifApplicationExtensionProperties
		{
			/// <summary>[VT_UI1|VT_VECTOR] Indicates a string that identifies the application.</summary>
			WICGifApplicationExtensionApplication = 1,

			/// <summary>[VT_UI1|VT_VECTOR] Indicates data that is exposed by the application.</summary>
			WICGifApplicationExtensionData,

			/// <summary/>
			WICGifApplicationExtensionProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the comment extension metadata properties for a Graphics Interchange Format (GIF) image.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicgifcommentextensionproperties typedef enum
		// WICGifCommentExtensionProperties { WICGifCommentExtensionText, WICGifCommentExtensionProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "900f1c1e-e8d2-4cee-acba-c9c2a45e9bcb")]
		public enum WICGifCommentExtensionProperties
		{
			/// <summary>[VT_LPSTR] Indicates the comment text.</summary>
			WICGifCommentExtensionText = 1,

			/// <summary/>
			WICGifCommentExtensionProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>
		/// Specifies the graphic control extension metadata properties that define the transitions between each frame animation for
		/// Graphics Interchange Format (GIF) images.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicgifgraphiccontrolextensionproperties typedef enum
		// WICGifGraphicControlExtensionProperties { WICGifGraphicControlExtensionDisposal, WICGifGraphicControlExtensionUserInputFlag,
		// WICGifGraphicControlExtensionTransparencyFlag, WICGifGraphicControlExtensionDelay,
		// WICGifGraphicControlExtensionTransparentColorIndex, WICGifGraphicControlExtensionProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "32fbf62d-0479-4ead-8246-6c757467ccaa")]
		public enum WICGifGraphicControlExtensionProperties
		{
			/// <summary>
			/// [VT_UI1] Indicates the disposal requirements. 0 - no disposal, 1 - do not dispose, 2 - restore to background color, 3 -
			/// restore to previous.
			/// </summary>
			WICGifGraphicControlExtensionDisposal = 1,

			/// <summary>[VT_BOOL] Indicates the user input flag. TRUE if user input should advance to the next frame; otherwise, FALSE.</summary>
			WICGifGraphicControlExtensionUserInputFlag,

			/// <summary>
			/// [VT_BOOL] Indicates the transparency flag. TRUE if a transparent color in is in the color table for this frame; otherwise, FALSE.
			/// </summary>
			WICGifGraphicControlExtensionTransparencyFlag,

			/// <summary>
			/// [VT_UI2] Indicates how long to display the next frame before advancing to the next frame, in units of 1/100th of a second.
			/// </summary>
			WICGifGraphicControlExtensionDelay,

			/// <summary>[VT_UI1] Indicates which color in the palette should be treated as transparent.</summary>
			WICGifGraphicControlExtensionTransparentColorIndex,

			/// <summary/>
			WICGifGraphicControlExtensionProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the image descriptor metadata properties for Graphics Interchange Format (GIF) frames.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicgifimagedescriptorproperties typedef enum
		// WICGifImageDescriptorProperties { WICGifImageDescriptorLeft, WICGifImageDescriptorTop, WICGifImageDescriptorWidth,
		// WICGifImageDescriptorHeight, WICGifImageDescriptorLocalColorTableFlag, WICGifImageDescriptorInterlaceFlag,
		// WICGifImageDescriptorSortFlag, WICGifImageDescriptorLocalColorTableSize, WICGifImageDescriptorProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "5488e63b-503b-47cd-99f3-5d359c7e0070")]
		public enum WICGifImageDescriptorProperties
		{
			/// <summary>[VT_UI2] Indicates the X offset at which to locate this frame within the logical screen.</summary>
			WICGifImageDescriptorLeft = 1,

			/// <summary>[VT_UI2] Indicates the Y offset at which to locate this frame within the logical screen.</summary>
			WICGifImageDescriptorTop,

			/// <summary>[VT_UI2] Indicates width of this frame, in pixels.</summary>
			WICGifImageDescriptorWidth,

			/// <summary>[VT_UI2] Indicates height of this frame, in pixels.</summary>
			WICGifImageDescriptorHeight,

			/// <summary>[VT_BOOL] Indicates the local color table flag. TRUE if global color table is present; otherwise, FALSE.</summary>
			WICGifImageDescriptorLocalColorTableFlag,

			/// <summary>[VT_BOOL] Indicates the interlace flag. TRUE if image is interlaced; otherwise, FALSE.</summary>
			WICGifImageDescriptorInterlaceFlag,

			/// <summary>
			/// [VT_BOOL] Indicates the sorted color table flag. TRUE if the color table is sorted from most frequently to least frequently
			/// used color; otherwise, FALSE.
			/// </summary>
			WICGifImageDescriptorSortFlag,

			/// <summary>
			/// [VT_UI1] Indicates the value used to calculate the number of bytes contained in the global color table. To calculate the
			/// actual size of the color table, raise 2 to the value of the field + 1.
			/// </summary>
			WICGifImageDescriptorLocalColorTableSize,

			/// <summary/>
			WICGifImageDescriptorProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the logical screen descriptor properties for Graphics Interchange Format (GIF) metadata.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicgiflogicalscreendescriptorproperties typedef enum
		// WICGifLogicalScreenDescriptorProperties { WICGifLogicalScreenSignature, WICGifLogicalScreenDescriptorWidth,
		// WICGifLogicalScreenDescriptorHeight, WICGifLogicalScreenDescriptorGlobalColorTableFlag,
		// WICGifLogicalScreenDescriptorColorResolution, WICGifLogicalScreenDescriptorSortFlag,
		// WICGifLogicalScreenDescriptorGlobalColorTableSize, WICGifLogicalScreenDescriptorBackgroundColorIndex,
		// WICGifLogicalScreenDescriptorPixelAspectRatio, WICGifLogicalScreenDescriptorProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "edeaae2d-ba4a-4d03-b1ce-37bb5cd67e03")]
		public enum WICGifLogicalScreenDescriptorProperties
		{
			/// <summary>[VT_UI1</summary>
			WICGifLogicalScreenSignature = 1,

			/// <summary>[VT_UI2] Indicates the width in pixels.</summary>
			WICGifLogicalScreenDescriptorWidth,

			/// <summary>[VT_UI2] Indicates the height in pixels.</summary>
			WICGifLogicalScreenDescriptorHeight,

			/// <summary>[VT_BOOL] Indicates the global color table flag. TRUE if a global color table is present; otherwise, FALSE.</summary>
			WICGifLogicalScreenDescriptorGlobalColorTableFlag,

			/// <summary>[VT_UI1] Indicates the color resolution in bits per pixel.</summary>
			WICGifLogicalScreenDescriptorColorResolution,

			/// <summary>[VT_BOOL] Indicates the sorted color table flag. TRUE if the table is sorted; otherwise, FALSE.</summary>
			WICGifLogicalScreenDescriptorSortFlag,

			/// <summary>
			/// [VT_UI1] Indicates the value used to calculate the number of bytes contained in the global color table. To calculate the
			/// actual size of the color table, raise 2 to the value of the field + 1.
			/// </summary>
			WICGifLogicalScreenDescriptorGlobalColorTableSize,

			/// <summary>[VT_UI1] Indicates the index within the color table to use for the background (pixels not defined in the image).</summary>
			WICGifLogicalScreenDescriptorBackgroundColorIndex,

			/// <summary>[VT_UI1] Indicates the factor used to compute an approximation of the aspect ratio.</summary>
			WICGifLogicalScreenDescriptorPixelAspectRatio,

			/// <summary/>
			WICGifLogicalScreenDescriptorProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the HDR properties of a High Efficiency Image Format (HEIF) image.</summary>
		/// <remarks>
		/// <para>
		/// Use IWicMetadataReader::GetValue to retrieve the value of the properties specified with this enumeration. Instantiate the
		/// <c>IWicMetadataReader</c> instance using the GUID <c>CLSID_WICMetadataReader</c>. Call IWicMetadataReader::GetMetadataFormat and
		/// confirm that the value is <c>GUID_MetadataFormatHeifHDR</c> to verify that the metadata format is HEIF HDR metadata.
		/// </para>
		/// <para>
		/// Not all HEIF HDR images will have all of these properties present in the file, so only those properties that are available will
		/// be exposed by the metadata reader.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicheifhdrproperties typedef enum WICHeifHdrProperties {
		// WICHeifHdrMaximumLuminanceLevel, WICHeifHdrMaximumFrameAverageLuminanceLevel, WICHeifHdrMinimumMasteringDisplayLuminanceLevel,
		// WICHeifHdrMaximumMasteringDisplayLuminanceLevel, WICHeifHdrCustomVideoPrimaries, WICHeifHdrProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h")]
		public enum WICHeifHdrProperties
		{
			/// <summary>[VT_UI2] Specifies the maximum luminance level of the content in Nits.</summary>
			WICHeifHdrMaximumLuminanceLevel = 1,

			/// <summary>[VT_UI2] Specifies the maximum average per-frame luminance level of the content in Nits.</summary>
			WICHeifHdrMaximumFrameAverageLuminanceLevel,

			/// <summary>[VT_UI2] Specifies the maximum luminance of the display on which the content was authored, in Nits.</summary>
			WICHeifHdrMinimumMasteringDisplayLuminanceLevel,

			/// <summary>[VT_UI2] Specifies the maximum luminance of the display on which the content was authored, in Nits.</summary>
			WICHeifHdrMaximumMasteringDisplayLuminanceLevel,

			/// <summary>
			/// [VT_BLOB] Specifies custom color primaries for a video media type. The value of this property is a
			/// MT_CUSTOM_VIDEO_PRIMARIESstructure, returned as an array of bytes (VT_BLOB).
			/// </summary>
			WICHeifHdrCustomVideoPrimaries,

			/// <summary/>
			WICHeifHdrProperties_FORCE_DWORD,
		}

		/// <summary>Specifies the JPEG chrominance table property.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicjpegchrominanceproperties typedef enum
		// WICJpegChrominanceProperties { WICJpegChrominanceTable, WICJpegChrominanceProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "edfa5f86-4c8b-4ba7-a017-d3ff9525b659")]
		public enum WICJpegChrominanceProperties
		{
			/// <summary>[VT_UI2|VT_VECTOR] Indicates the metadata property is a chrominance table.</summary>
			WICJpegChrominanceTable = 1,

			/// <summary/>
			WICJpegChrominanceProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the JPEG comment properties.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicjpegcommentproperties typedef enum
		// WICJpegCommentProperties { WICJpegCommentText, WICJpegCommentProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "aacf1f1a-49c6-4caf-acd5-8bba0415d41a")]
		public enum WICJpegCommentProperties
		{
			/// <summary>Indicates the metadata property is comment text.</summary>
			WICJpegCommentText = 1,

			/// <summary/>
			WICJpegCommentProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Flags used by the <c>WICJpegScanHeader</c> and <c>WICJpegFrameHeader</c>.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/wic/iwicjpegframedecode-constants
		[PInvokeData("wincodec.h", MSDNShortId = "6C0139F3-DA3E-4D7C-80D5-BC8C2D76C6A9")]
		public enum WICJpegFrameDecode
		{
			/// <summary>The maximum number of components supported by WIC.</summary>
			WIC_JPEG_MAX_COMPONENT_COUNT = 4,

			/// <summary>The maximum number of tables supported by WIC.</summary>
			WIC_JPEG_MAX_TABLE_INDEX = 3,

			/// <summary>Sample factor 1.</summary>
			WIC_JPEG_SAMPLE_FACTORS_ONE = 0x11,

			/// <summary>Sample factor 4:2:0.</summary>
			WIC_JPEG_SAMPLE_FACTORS_THREE_420 = 0x111122,

			/// <summary>Sample factor 4:2:2.</summary>
			WIC_JPEG_SAMPLE_FACTORS_THREE_422 = 0x111121,

			/// <summary>Sample factor 4:4:0.</summary>
			WIC_JPEG_SAMPLE_FACTORS_THREE_440 = 0x111112,

			/// <summary>Sample factor 4:4:4.</summary>
			WIC_JPEG_SAMPLE_FACTORS_THREE_444 = 0x111111,

			/// <summary>Quantization indices use baseline 1.</summary>
			WIC_JPEG_QUANTIZATION_BASELINE_ONE = 0,

			/// <summary>Quantization indices use baseline 3.</summary>
			WIC_JPEG_QUANTIZATION_BASELINE_THREE = 0x10100,

			/// <summary>Huffman indices use baseline 1.</summary>
			WIC_JPEG_HUFFMAN_BASELINE_ONE = 0,

			/// <summary>Huffman indices use baseline 3.</summary>
			WIC_JPEG_HUFFMAN_BASELINE_THREE = 0x111100,
		}

		/// <summary>Specifies the options for indexing a JPEG image.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicjpegindexingoptions typedef enum
		// WICJpegIndexingOptions { WICJpegIndexingOptionsGenerateOnDemand, WICJpegIndexingOptionsGenerateOnLoad,
		// WICJpegIndexingOptions_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "AFA9CC1B-847A-4237-9942-EC721FA86E4E")]
		public enum WICJpegIndexingOptions
		{
			/// <summary>Index generation is deferred until IWICBitmapSource::CopyPixels is called on the image.</summary>
			WICJpegIndexingOptionsGenerateOnDemand,

			/// <summary>Index generation is performed when the when the image is initially loaded.</summary>
			WICJpegIndexingOptionsGenerateOnLoad,

			/// <summary>
			/// Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this enumeration to
			/// compile to a size other than 32 bits. This value is not used.
			/// </summary>
			WICJpegIndexingOptions_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the JPEG luminance table property.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicjpegluminanceproperties typedef enum
		// WICJpegLuminanceProperties { WICJpegLuminanceTable, WICJpegLuminanceProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "391e96a3-372e-43b9-a752-0234d0fd37e1")]
		public enum WICJpegLuminanceProperties
		{
			/// <summary>[VT_UI2|VT_VECTOR] Indicates the metadata property is a luminance table.</summary>
			WICJpegLuminanceTable = 1,

			/// <summary/>
			WICJpegLuminanceProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the memory layout of pixel data in a JPEG image scan.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicjpegscantype typedef enum WICJpegScanType {
		// WICJpegScanTypeInterleaved, WICJpegScanTypePlanarComponents, WICJpegScanTypeProgressive, WICJpegScanType_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "DC8B42F0-66D3-4425-9AA8-6B8F0D9B8568")]
		public enum WICJpegScanType
		{
			/// <summary>The pixel data is stored in an interleaved memory layout.</summary>
			WICJpegScanTypeInterleaved,

			/// <summary>The pixel data is stored in a planar memory layout.</summary>
			WICJpegScanTypePlanarComponents,

			/// <summary>The pixel data is stored in a progressive layout.</summary>
			WICJpegScanTypeProgressive,

			/// <summary>
			/// Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this enumeration to
			/// compile to a size other than 32 bits. This value is not used.
			/// </summary>
			WICJpegScanType_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies conversion matrix from Y'Cb'Cr' to R'G'B'.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicjpegtransfermatrix typedef enum WICJpegTransferMatrix
		// { WICJpegTransferMatrixIdentity, WICJpegTransferMatrixBT601, WICJpegTransferMatrix_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "393342C4-A906-4427-BEAA-842FF77C9E9D")]
		public enum WICJpegTransferMatrix
		{
			/// <summary>Specifies the identity transfer matrix.</summary>
			WICJpegTransferMatrixIdentity,

			/// <summary>Specifies the BT601 transfer matrix.</summary>
			WICJpegTransferMatrixBT601,

			/// <summary>
			/// Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this enumeration to
			/// compile to a size other than 32 bits. This value is not used.
			/// </summary>
			WICJpegTransferMatrix_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the JPEG YCrCB subsampling options.</summary>
		/// <remarks>The native JPEG encoder uses <c>WICJpegYCrCbSubsampling420</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicjpegycrcbsubsamplingoption typedef enum
		// WICJpegYCrCbSubsamplingOption { WICJpegYCrCbSubsamplingDefault, WICJpegYCrCbSubsampling420, WICJpegYCrCbSubsampling422,
		// WICJpegYCrCbSubsampling444, WICJpegYCrCbSubsampling440, WICJPEGYCRCBSUBSAMPLING_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "6ff16a79-35c9-4230-8f1c-a5c40aecc09e")]
		public enum WICJpegYCrCbSubsamplingOption
		{
			/// <summary>The default subsampling option.</summary>
			WICJpegYCrCbSubsamplingDefault,

			/// <summary>Subsampling option that uses both horizontal and vertical decimation.</summary>
			WICJpegYCrCbSubsampling420,

			/// <summary>Subsampling option that uses horizontal decimation .</summary>
			WICJpegYCrCbSubsampling422,

			/// <summary>Subsampling option that uses no decimation.</summary>
			WICJpegYCrCbSubsampling444,

			/// <summary>
			/// Subsampling option that uses 2x vertical downsampling only. This option is only available in Windows 8.1 and later.
			/// </summary>
			WICJpegYCrCbSubsampling440,

			/// <summary/>
			WICJPEGYCRCBSUBSAMPLING_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies metadata creation options.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/ne-wincodecsdk-wicmetadatacreationoptions typedef enum
		// WICMetadataCreationOptions { WICMetadataCreationDefault, WICMetadataCreationAllowUnknown, WICMetadataCreationFailUnknown,
		// WICMetadataCreationMask } ;
		[PInvokeData("wincodecsdk.h", MSDNShortId = "41fece55-1ce4-455a-99b5-5ff0ecd27e07")]
		public enum WICMetadataCreationOptions
		{
			/// <summary>The default metadata creation options. The default value is WICMetadataCreationAllowUnknown.</summary>
			WICMetadataCreationDefault,

			/// <summary>Allow unknown metadata creation.</summary>
			WICMetadataCreationAllowUnknown,

			/// <summary>Fail on unknown metadata creation.</summary>
			WICMetadataCreationFailUnknown,

			/// <summary>The WICMetadataCreationOptions mask.</summary>
			WICMetadataCreationMask,
		}

		/// <summary>Specifies named white balances for raw images.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicnamedwhitepoint typedef enum WICNamedWhitePoint {
		// WICWhitePointDefault, WICWhitePointDaylight, WICWhitePointCloudy, WICWhitePointShade, WICWhitePointTungsten,
		// WICWhitePointFluorescent, WICWhitePointFlash, WICWhitePointUnderwater, WICWhitePointCustom, WICWhitePointAutoWhiteBalance,
		// WICWhitePointAsShot, WICNAMEDWHITEPOINT_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "e256a6d6-a035-47c3-a82c-d9aec284de17")]
		[Flags]
		public enum WICNamedWhitePoint
		{
			/// <summary>The default white balance.</summary>
			WICWhitePointDefault = 0x1,

			/// <summary>A daylight white balance.</summary>
			WICWhitePointDaylight = 0x2,

			/// <summary>A cloudy white balance.</summary>
			WICWhitePointCloudy = 0x4,

			/// <summary>A shade white balance.</summary>
			WICWhitePointShade = 0x8,

			/// <summary>A tungsten white balance.</summary>
			WICWhitePointTungsten = 0x10,

			/// <summary>A fluorescent white balance.</summary>
			WICWhitePointFluorescent = 0x20,

			/// <summary>Daylight white balance.</summary>
			WICWhitePointFlash = 0x40,

			/// <summary>A flash white balance.</summary>
			WICWhitePointUnderwater = 0x80,

			/// <summary>A custom white balance. This is typically used when using a picture (grey-card) as white balance.</summary>
			WICWhitePointCustom = 0x100,

			/// <summary>An automatic balance.</summary>
			WICWhitePointAutoWhiteBalance = 0x200,

			/// <summary>An "as shot" white balance.</summary>
			WICWhitePointAsShot = WICWhitePointDefault,

			/// <summary/>
			WICNAMEDWHITEPOINT_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies Windows Imaging Component (WIC) options that are used when initializing a component with a stream.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/ne-wincodecsdk-wicpersistoptions typedef enum WICPersistOptions {
		// WICPersistOptionDefault, WICPersistOptionLittleEndian, WICPersistOptionBigEndian, WICPersistOptionStrictFormat,
		// WICPersistOptionNoCacheStream, WICPersistOptionPreferUTF8, WICPersistOptionMask } ;
		[PInvokeData("wincodecsdk.h", MSDNShortId = "8c17cfcc-4f09-4cb5-a3fa-4eb865123ad6")]
		public enum WICPersistOptions
		{
			/// <summary>The default persist options. The default is WICPersistOptionLittleEndian.</summary>
			WICPersistOptionDefault,

			/// <summary>The data byte order is little endian.</summary>
			WICPersistOptionLittleEndian,

			/// <summary>The data byte order is big endian.</summary>
			WICPersistOptionBigEndian,

			/// <summary>The data format must strictly conform to the specification.</summary>
			WICPersistOptionStrictFormat,

			/// <summary>
			/// No cache for the metadata stream.Certain operations, such as IWICComponentFactory::CreateMetadataWriterFromReader require
			/// that the reader have a stream. Therefore, these operations will be unavailable if the reader is initialized with WICPersistOptionNoCacheStream.
			/// </summary>
			WICPersistOptionNoCacheStream,

			/// <summary>Use UTF8 instead of the default UTF16.</summary>
			WICPersistOptionPreferUTF8,

			/// <summary>The WICPersistOptions mask.</summary>
			WICPersistOptionMask,
		}

		/// <summary>Defines constants that specify a primitive type for numeric representation of a WIC pixel format.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicpixelformatnumericrepresentation typedef enum
		// WICPixelFormatNumericRepresentation { WICPixelFormatNumericRepresentationUnspecified, WICPixelFormatNumericRepresentationIndexed,
		// WICPixelFormatNumericRepresentationUnsignedInteger, WICPixelFormatNumericRepresentationSignedInteger,
		// WICPixelFormatNumericRepresentationFixed, WICPixelFormatNumericRepresentationFloat,
		// WICPixelFormatNumericRepresentation_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "10f32ac9-4b0d-4d21-b54a-657513fbd142")]
		public enum WICPixelFormatNumericRepresentation
		{
			/// <summary>The format is not specified.</summary>
			WICPixelFormatNumericRepresentationUnspecified,

			/// <summary>Specifies that the format is indexed.</summary>
			WICPixelFormatNumericRepresentationIndexed,

			/// <summary>Specifies that the format is represented as an unsigned integer.</summary>
			WICPixelFormatNumericRepresentationUnsignedInteger,

			/// <summary>Specifies that the format is represented as a signed integer.</summary>
			WICPixelFormatNumericRepresentationSignedInteger,

			/// <summary>Specifies that the format is represented as a fixed-point number.</summary>
			WICPixelFormatNumericRepresentationFixed,

			/// <summary>Specifies that the format is represented as a floating-point number.</summary>
			WICPixelFormatNumericRepresentationFloat,

			/// <summary>This constant contains the maximum DWORD value.</summary>
			WICPixelFormatNumericRepresentation_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies additional options to an IWICPlanarBitmapSourceTransform implementation.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicplanaroptions typedef enum WICPlanarOptions {
		// WICPlanarOptionsDefault, WICPlanarOptionsPreserveSubsampling, WICPLANAROPTIONS_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "8B7F34AA-77A0-428D-800E-31AB43067102")]
		public enum WICPlanarOptions
		{
			/// <summary>
			/// No options specified. WIC JPEG Decoder: The default behavior for iDCT scaling is to preserve quality when downscaling by
			/// downscaling only the Y plane in some cases, and the image may change to 4:4:4 chroma subsampling.
			/// </summary>
			WICPlanarOptionsDefault,

			/// <summary>
			/// Asks the source to preserve the size ratio between planes when scaling.WIC JPEG Decoder: Specifying this option causes the
			/// JPEG decoder to scale luma and chroma planes by the same amount, so a 4:2:0 chroma subsampled image outputs 4:2:0 data when
			/// downscaling by 2x, 4x, or 8x.
			/// </summary>
			WICPlanarOptionsPreserveSubsampling,

			/// <summary/>
			WICPLANAROPTIONS_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the Portable Network Graphics (PNG) background (bKGD) chunk metadata properties.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicpngbkgdproperties typedef enum WICPngBkgdProperties {
		// WICPngBkgdBackgroundColor, WICPngBkgdProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "979f6a91-79a2-4eba-8957-e2908636cdc5")]
		public enum WICPngBkgdProperties
		{
			/// <summary>
			/// Indicates the background color. There are three possible types, depending on the image's pixel format.#### VT_UI1Specifies
			/// the index of the background color in an image with an indexed pixel format.#### VT_UI2Specifies the background color in a
			/// grayscale image.#### VT_VECTOR
			/// </summary>
			WICPngBkgdBackgroundColor = 1,

			/// <summary/>
			WICPngBkgdProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the Portable Network Graphics (PNG) cHRM chunk metadata properties for CIE XYZ chromaticity.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicpngchrmproperties typedef enum WICPngChrmProperties {
		// WICPngChrmWhitePointX, WICPngChrmWhitePointY, WICPngChrmRedX, WICPngChrmRedY, WICPngChrmGreenX, WICPngChrmGreenY,
		// WICPngChrmBlueX, WICPngChrmBlueY, WICPngChrmProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "e4dede53-4c34-4e37-addf-28f51164717f")]
		public enum WICPngChrmProperties
		{
			/// <summary>[VT_UI4] Indicates the whitepoint x value ratio.</summary>
			WICPngChrmWhitePointX = 1,

			/// <summary>[VT_UI4] Indicates the whitepoint y value ratio.</summary>
			WICPngChrmWhitePointY,

			/// <summary>[VT_UI4] Indicates the red x value ratio.</summary>
			WICPngChrmRedX,

			/// <summary>[VT_UI4] Indicates the red y value ratio.</summary>
			WICPngChrmRedY,

			/// <summary>[VT_UI4] Indicates the green x value ratio.</summary>
			WICPngChrmGreenX,

			/// <summary>[VT_UI4] Indicates the green y value ratio.</summary>
			WICPngChrmGreenY,

			/// <summary>[VT_UI4] Indicates the blue x value ratio.</summary>
			WICPngChrmBlueX,

			/// <summary>[VT_UI4] Indicates the blue y value ratio.</summary>
			WICPngChrmBlueY,

			/// <summary/>
			WICPngChrmProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the Portable Network Graphics (PNG) filters available for compression optimization.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicpngfilteroption typedef enum WICPngFilterOption {
		// WICPngFilterUnspecified, WICPngFilterNone, WICPngFilterSub, WICPngFilterUp, WICPngFilterAverage, WICPngFilterPaeth,
		// WICPngFilterAdaptive, WICPNGFILTEROPTION_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "468033cf-62e8-4aef-b34f-c833df048115")]
		public enum WICPngFilterOption
		{
			/// <summary>
			/// Indicates an unspecified PNG filter. This enables WIC to algorithmically choose the best filtering option for the image.
			/// </summary>
			WICPngFilterUnspecified,

			/// <summary>Indicates no PNG filter.</summary>
			WICPngFilterNone,

			/// <summary>Indicates a PNG sub filter.</summary>
			WICPngFilterSub,

			/// <summary>Indicates a PNG up filter.</summary>
			WICPngFilterUp,

			/// <summary>Indicates a PNG average filter.</summary>
			WICPngFilterAverage,

			/// <summary>Indicates a PNG paeth filter.</summary>
			WICPngFilterPaeth,

			/// <summary>Indicates a PNG adaptive filter. This enables WIC to choose the best filtering mode on a per-scanline basis.</summary>
			WICPngFilterAdaptive,

			/// <summary/>
			WICPNGFILTEROPTION_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the Portable Network Graphics (PNG) gAMA chunk metadata properties.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicpnggamaproperties typedef enum WICPngGamaProperties {
		// WICPngGamaGamma, WICPngGamaProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "c70a3507-d598-4e33-872b-353389b19351")]
		public enum WICPngGamaProperties
		{
			/// <summary>[VT_UI4] Indicates the gamma value.</summary>
			WICPngGamaGamma = 1,

			/// <summary/>
			WICPngGamaProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the Portable Network Graphics (PNG) hIST chunk metadata properties.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicpnghistproperties typedef enum WICPngHistProperties {
		// WICPngHistFrequencies, WICPngHistProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "ab3ddddb-5916-43b8-8688-5361cee05902")]
		public enum WICPngHistProperties
		{
			/// <summary>[VT_VECTOR</summary>
			WICPngHistFrequencies = 1,

			/// <summary/>
			WICPngHistProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the Portable Network Graphics (PNG) iCCP chunk metadata properties.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicpngiccpproperties typedef enum WICPngIccpProperties {
		// WICPngIccpProfileName, WICPngIccpProfileData, WICPngIccpProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "2c28a4f1-40c2-4886-be5f-0a2e6feb487a")]
		public enum WICPngIccpProperties
		{
			/// <summary>[VT_LPSTR] Indicates the International Color Consortium (ICC) profile name.</summary>
			WICPngIccpProfileName = 1,

			/// <summary>[VT_VECTOR</summary>
			WICPngIccpProfileData,

			/// <summary/>
			WICPngIccpProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the Portable Network Graphics (PNG) iTXT chunk metadata properties.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicpngitxtproperties typedef enum WICPngItxtProperties {
		// WICPngItxtKeyword, WICPngItxtCompressionFlag, WICPngItxtLanguageTag, WICPngItxtTranslatedKeyword, WICPngItxtText,
		// WICPngItxtProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "905d37e2-39f3-4990-b737-f9194f798d83")]
		public enum WICPngItxtProperties
		{
			/// <summary>[VT_LPSTR] Indicates the keywords in the iTXT metadata chunk.</summary>
			WICPngItxtKeyword = 1,

			/// <summary>
			/// [VT_UI1] Indicates whether the text in the iTXT chunk is compressed. 1 if the text is compressed; otherwise, 0.
			/// </summary>
			WICPngItxtCompressionFlag,

			/// <summary>[VT_LPSTR] Indicates the human language used by the translated keyword and the text.</summary>
			WICPngItxtLanguageTag,

			/// <summary>[VT_LPWSTR] Indicates a translation of the keyword into the language indicated by the language tag.</summary>
			WICPngItxtTranslatedKeyword,

			/// <summary>[VT_LPWSTR] Indicates additional text in the iTXT metadata chunk.</summary>
			WICPngItxtText,

			/// <summary/>
			WICPngItxtProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the Portable Network Graphics (PNG) sRGB chunk metadata properties.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicpngsrgbproperties typedef enum WICPngSrgbProperties {
		// WICPngSrgbRenderingIntent, WICPngSrgbProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "ec9bbdb7-9ce2-44bd-bd84-842394ce4c5f")]
		public enum WICPngSrgbProperties
		{
			/// <summary>
			/// [VT_UI1] Indicates the rendering intent for an sRGB color space image. The rendering intents have the following meaning.
			/// </summary>
			WICPngSrgbRenderingIntent = 1,

			/// <summary/>
			WICPngSrgbProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the Portable Network Graphics (PNG) tIME chunk metadata properties.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicpngtimeproperties typedef enum WICPngTimeProperties {
		// WICPngTimeYear, WICPngTimeMonth, WICPngTimeDay, WICPngTimeHour, WICPngTimeMinute, WICPngTimeSecond,
		// WICPngTimeProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "202dc399-0173-4995-af74-09ee71e1dcf1")]
		public enum WICPngTimeProperties
		{
			/// <summary>[VT_UI2] Indicates the year of the last modification.</summary>
			WICPngTimeYear = 1,

			/// <summary>[VT_UI1] Indicates the month of the last modification.</summary>
			WICPngTimeMonth,

			/// <summary>[VT_UI1] Indicates day of the last modification.</summary>
			WICPngTimeDay,

			/// <summary>[VT_UI1] Indicates the hour of the last modification.</summary>
			WICPngTimeHour,

			/// <summary>[VT_UI1] Indicates the minute of the last modification.</summary>
			WICPngTimeMinute,

			/// <summary>[VT_UI1] Indicates the second of the last modification.</summary>
			WICPngTimeSecond,

			/// <summary/>
			WICPngTimeProperties_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies when the progress notification callback should be called.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicprogressnotification typedef enum
		// WICProgressNotification { WICProgressNotificationBegin, WICProgressNotificationEnd, WICProgressNotificationFrequent,
		// WICProgressNotificationAll, WICPROGRESSNOTIFICATION_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "6d7ef6f1-2024-4de5-9c2e-8edc6359f79b")]
		[Flags]
		public enum WICProgressNotification : uint
		{
			/// <summary>The callback should be called when codec operations begin.</summary>
			WICProgressNotificationBegin = 0x10000,

			/// <summary>The callback should be called when codec operations end.</summary>
			WICProgressNotificationEnd = 0x20000,

			/// <summary>The callback should be called frequently to report status.</summary>
			WICProgressNotificationFrequent = 0x40000,

			/// <summary>The callback should be called on all available progress notifications.</summary>
			WICProgressNotificationAll = 0xffff0000,

			/// <summary/>
			WICPROGRESSNOTIFICATION_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the progress operations to receive notifications for.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicprogressoperation typedef enum WICProgressOperation {
		// WICProgressOperationCopyPixels, WICProgressOperationWritePixels, WICProgressOperationAll, WICPROGRESSOPERATION_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "407b982d-7232-42ce-9ff5-7029b7d922a4")]
		[Flags]
		public enum WICProgressOperation
		{
			/// <summary>Receive copy pixel operation.</summary>
			WICProgressOperationCopyPixels = 0x1,

			/// <summary>Receive write pixel operation.</summary>
			WICProgressOperationWritePixels = 0x2,

			/// <summary>Receive all progress operations available.</summary>
			WICProgressOperationAll = 0xffff,

			/// <summary/>
			WICPROGRESSOPERATION_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the capability support of a raw image.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicrawcapabilities typedef enum WICRawCapabilities {
		// WICRawCapabilityNotSupported, WICRawCapabilityGetSupported, WICRawCapabilityFullySupported, WICRAWCAPABILITIES_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "a82edbbe-a069-4ba8-ba15-524830cdf330")]
		public enum WICRawCapabilities
		{
			/// <summary>The capability is not supported.</summary>
			WICRawCapabilityNotSupported,

			/// <summary>The capability supports only get operations.</summary>
			WICRawCapabilityGetSupported,

			/// <summary>The capability supports get and set operations.</summary>
			WICRawCapabilityFullySupported,

			/// <summary/>
			WICRAWCAPABILITIES_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Flags used to by <c>IWICDevelopRawNotificationCallback</c> to indicate which members have changed.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/wic/-wic-codec-iwicdeveloprawnotification-constants
		[PInvokeData("wincodec.h", MSDNShortId = "4e94b4f4-abd9-4395-87ec-a08e49a2cf88")]
		[Flags]
		public enum WICRawChangeNotification
		{
			/// <summary>Mask used to report a exposure compensation change.</summary>
			WICRawChangeNotification_ExposureCompensation = 0x00000001,

			/// <summary>Mask used to report a WICNamedWhitePoint change.</summary>
			WICRawChangeNotification_NamedWhitePoint = 0x00000002,

			/// <summary>Mask used to report a kelvin white point change.</summary>
			WICRawChangeNotification_KelvinWhitePoint = 0x00000004,

			/// <summary>Mask used to report a RGB white point change.</summary>
			WICRawChangeNotification_RGBWhitePoint = 0x00000008,

			/// <summary>Mask used to report a contrast change.</summary>
			WICRawChangeNotification_Contrast = 0x00000010,

			/// <summary>Mask used to report a gamma change.</summary>
			WICRawChangeNotification_Gamma = 0x00000020,

			/// <summary>Mask used to report a sharpness change.</summary>
			WICRawChangeNotification_Sharpness = 0x00000040,

			/// <summary>Mask used to report a saturation change.</summary>
			WICRawChangeNotification_Saturation = 0x00000080,

			/// <summary>Mask used to report a tint change.</summary>
			WICRawChangeNotification_Tint = 0x00000100,

			/// <summary>Mask used to report a noise reduction change.</summary>
			WICRawChangeNotification_NoiseReduction = 0x00000200,

			/// <summary>Mask used to report a destination color context change.</summary>
			WICRawChangeNotification_DestinationColorContext = 0x00000400,

			/// <summary>Mask used to report a tone curve change.</summary>
			WICRawChangeNotification_ToneCurve = 0x00000800,

			/// <summary>Mask used to report a WICRawRotationCapabilities change.</summary>
			WICRawChangeNotification_Rotation = 0x00001000,

			/// <summary>Mask used to report a WICRawRenderMode change.</summary>
			WICRawChangeNotification_RenderMode = 0x00002000,
		}

		/// <summary>Specifies the parameter set used by a raw codec.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicrawparameterset typedef enum WICRawParameterSet {
		// WICAsShotParameterSet, WICUserAdjustedParameterSet, WICAutoAdjustedParameterSet, WICRAWPARAMETERSET_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "0c39b769-9523-42ce-942f-761e6d39ec5b")]
		public enum WICRawParameterSet
		{
			/// <summary>An as shot parameter set.</summary>
			WICAsShotParameterSet = 1,

			/// <summary>A user adjusted parameter set.</summary>
			WICUserAdjustedParameterSet,

			/// <summary>A codec adjusted parameter set.</summary>
			WICAutoAdjustedParameterSet,

			/// <summary/>
			WICRAWPARAMETERSET_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the render intent of the next CopyPixels call.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicrawrendermode typedef enum WICRawRenderMode {
		// WICRawRenderModeDraft, WICRawRenderModeNormal, WICRawRenderModeBestQuality, WICRAWRENDERMODE_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "dc020c78-a018-42ee-a500-65a743b96107")]
		public enum WICRawRenderMode
		{
			/// <summary>Use speed priority mode.</summary>
			WICRawRenderModeDraft = 1,

			/// <summary>Use normal priority mode. Balance of speed and quality.</summary>
			WICRawRenderModeNormal,

			/// <summary>Use best quality mode.</summary>
			WICRawRenderModeBestQuality,

			/// <summary/>
			WICRAWRENDERMODE_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the rotation capabilities of the codec.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicrawrotationcapabilities typedef enum
		// WICRawRotationCapabilities { WICRawRotationCapabilityNotSupported, WICRawRotationCapabilityGetSupported,
		// WICRawRotationCapabilityNinetyDegreesSupported, WICRawRotationCapabilityFullySupported, WICRAWROTATIONCAPABILITIES_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "f6713652-7d38-4ac6-80d8-fd53095c50a2")]
		public enum WICRawRotationCapabilities
		{
			/// <summary>Rotation is not supported.</summary>
			WICRawRotationCapabilityNotSupported,

			/// <summary>Set operations for rotation is not supported.</summary>
			WICRawRotationCapabilityGetSupported,

			/// <summary>90 degree rotations are supported.</summary>
			WICRawRotationCapabilityNinetyDegreesSupported,

			/// <summary>All rotation angles are supported.</summary>
			WICRawRotationCapabilityFullySupported,

			/// <summary/>
			WICRAWROTATIONCAPABILITIES_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the access level of a Windows Graphics Device Interface (GDI) section.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicsectionaccesslevel typedef enum WICSectionAccessLevel
		// { WICSectionAccessLevelRead, WICSectionAccessLevelReadWrite, WICSectionAccessLevel_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "4b08bc8c-d67c-4bc4-a701-2903a971a478")]
		public enum WICSectionAccessLevel
		{
			/// <summary>Indicates a read only access level.</summary>
			WICSectionAccessLevelRead = 1,

			/// <summary>Indicates a read/write access level.</summary>
			WICSectionAccessLevelReadWrite = 3,

			/// <summary/>
			WICSectionAccessLevel_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>Specifies the Tagged Image File Format (TIFF) compression options.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wictiffcompressionoption typedef enum
		// WICTiffCompressionOption { WICTiffCompressionDontCare, WICTiffCompressionNone, WICTiffCompressionCCITT3,
		// WICTiffCompressionCCITT4, WICTiffCompressionLZW, WICTiffCompressionRLE, WICTiffCompressionZIP,
		// WICTiffCompressionLZWHDifferencing, WICTIFFCOMPRESSIONOPTION_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "787f6d71-6481-4236-8c3f-1b18bfb7ee88")]
		public enum WICTiffCompressionOption
		{
			/// <summary>Indicates a suitable compression algorithm based on the image and pixel format.</summary>
			WICTiffCompressionDontCare,

			/// <summary>Indicates no compression.</summary>
			WICTiffCompressionNone,

			/// <summary>Indicates a CCITT3 compression algorithm. This algorithm is only valid for 1bpp pixel formats.</summary>
			WICTiffCompressionCCITT3,

			/// <summary>Indicates a CCITT4 compression algorithm. This algorithm is only valid for 1bpp pixel formats.</summary>
			WICTiffCompressionCCITT4,

			/// <summary>Indicates a LZW compression algorithm.</summary>
			WICTiffCompressionLZW,

			/// <summary>Indicates a RLE compression algorithm. This algorithm is only valid for 1bpp pixel formats.</summary>
			WICTiffCompressionRLE,

			/// <summary>Indicates a ZIP compression algorithm.</summary>
			WICTiffCompressionZIP,

			/// <summary>Indicates an LZWH differencing algorithm.</summary>
			WICTiffCompressionLZWHDifferencing,

			/// <summary/>
			WICTIFFCOMPRESSIONOPTION_FORCE_DWORD = 0x7fffffff,
		}

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Specifies the animation properties of a WebP image.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicwebpanimproperties typedef enum WICWebpAnimProperties
		// { WICWebpAnimLoopCount, WICWebpAnimProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "BECCBE42-5546-4243-A0B4-1240992D42DC")]
		public enum WICWebpAnimProperties
		{
			/// <summary>The number of times the animation loops. A value of 0 indicates that the animation will loop infinitely.</summary>
			WICWebpAnimLoopCount = 1,

			/// <summary/>
			WICWebpAnimProperties_FORCE_DWORD,
		}

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Specifies the animation frame properties of a WebP image.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ne-wincodec-wicwebpanmfproperties typedef enum WICWebpAnmfProperties
		// { WICWebpAnmfFrameDuration, WICWebpAnmfProperties_FORCE_DWORD } ;
		[PInvokeData("wincodec.h", MSDNShortId = "41C771FD-29FB-431B-B905-37C6A59C0677")]
		public enum WICWebpAnmfProperties
		{
			/// <summary>The time to wait before displaying the next frame, in milliseconds.</summary>
			WICWebpAnmfFrameDuration = 1,

			/// <summary/>
			WICWebpAnmfProperties_FORCE_DWORD,
		}

		/// <summary>This document includes GUIDs and class identifiers (CLSIDs) tables of Windows Imaging Component (WIC).</summary>
		// https://docs.microsoft.com/en-us/windows/win32/wic/-wic-guids-clsids
		[PInvokeData("wincodec.h", MSDNShortId = "2be5cfeb-2dd3-4486-b639-35ee28a7dd7b")]
		public static class WICGuids
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static readonly Guid CATID_WICBitmapDecoders = new Guid(0x7ed96837, 0x96f0, 0x4812, 0xb2, 0x11, 0xf1, 0x3c, 0x24, 0x11, 0x7e, 0xd3);
			public static readonly Guid CATID_WICBitmapEncoders = new Guid(0xac757296, 0x3522, 0x4e11, 0x98, 0x62, 0xc1, 0x7b, 0xe5, 0xa1, 0x76, 0x7e);
			public static readonly Guid CATID_WICFormatConverters = new Guid(0x7835eae8, 0xbf14, 0x49d1, 0x93, 0xce, 0x53, 0x3a, 0x40, 0x7b, 0x22, 0x48);
			public static readonly Guid CATID_WICMetadataReader = new Guid(0x05af94d8, 0x7174, 0x4cd2, 0xbe, 0x4a, 0x41, 0x24, 0xb8, 0x0e, 0xe4, 0xb8);
			public static readonly Guid CATID_WICMetadataWriter = new Guid(0xabe3b9a4, 0x257d, 0x4b97, 0xbd, 0x1a, 0x29, 0x4a, 0xf4, 0x96, 0x22, 0x2e);
			public static readonly Guid CATID_WICPixelFormats = new Guid(0x2b46e70f, 0xcda7, 0x473e, 0x89, 0xf6, 0xdc, 0x96, 0x30, 0xa2, 0x39, 0x0b);
			public static readonly Guid CLSID_WICAdngDecoder = new Guid(0x981d9411, 0x909e, 0x42a7, 0x8f, 0x5d, 0xa7, 0x47, 0xff, 0x05, 0x2e, 0xdb);
			public static readonly Guid CLSID_WICBmpDecoder = new Guid(0x6b462062, 0x7cbf, 0x400d, 0x9f, 0xdb, 0x81, 0x3d, 0xd1, 0x0f, 0x27, 0x78);
			public static readonly Guid CLSID_WICBmpEncoder = new Guid(0x69be8bb4, 0xd66d, 0x47c8, 0x86, 0x5a, 0xed, 0x15, 0x89, 0x43, 0x37, 0x82);
			public static readonly Guid CLSID_WICDdsDecoder = new Guid(0x9053699f, 0xa341, 0x429d, 0x9e, 0x90, 0xee, 0x43, 0x7c, 0xf8, 0x0c, 0x73);
			public static readonly Guid CLSID_WICDdsEncoder = new Guid(0xa61dde94, 0x66ce, 0x4ac1, 0x88, 0x1b, 0x71, 0x68, 0x05, 0x88, 0x89, 0x5e);
			public static readonly Guid CLSID_WICDefaultFormatConverter = new Guid(0x1a3f11dc, 0xb514, 0x4b17, 0x8c, 0x5f, 0x21, 0x54, 0x51, 0x38, 0x52, 0xf1);
			public static readonly Guid CLSID_WICFormatConverterHighColor = new Guid(0xac75d454, 0x9f37, 0x48f8, 0xb9, 0x72, 0x4e, 0x19, 0xbc, 0x85, 0x60, 0x11);
			public static readonly Guid CLSID_WICFormatConverterNChannel = new Guid(0xc17cabb2, 0xd4a3, 0x47d7, 0xa5, 0x57, 0x33, 0x9b, 0x2e, 0xfb, 0xd4, 0xf1);
			public static readonly Guid CLSID_WICFormatConverterWMPhoto = new Guid(0x9cb5172b, 0xd600, 0x46ba, 0xab, 0x77, 0x77, 0xbb, 0x7e, 0x3a, 0x00, 0xd9);
			public static readonly Guid CLSID_WICGifDecoder = new Guid(0x381dda3c, 0x9ce9, 0x4834, 0xa2, 0x3e, 0x1f, 0x98, 0xf8, 0xfc, 0x52, 0xbe);
			public static readonly Guid CLSID_WICGifEncoder = new Guid(0x114f5598, 0x0b22, 0x40a0, 0x86, 0xa1, 0xc8, 0x3e, 0xa4, 0x95, 0xad, 0xbd);
			public static readonly Guid CLSID_WICHeifDecoder = new Guid(0xe9A4A80a, 0x44fe, 0x4DE4, 0x89, 0x71, 0x71, 0x50, 0XB1, 0X0a, 0X51, 0X99);
			public static readonly Guid CLSID_WICHeifEncoder = new Guid(0x0dbecec1, 0x9eb3, 0x4860, 0x9c, 0x6f, 0xdd, 0xbe, 0x86, 0x63, 0x45, 0x75);
			public static readonly Guid CLSID_WICIcoDecoder = new Guid(0xc61bfcdf, 0x2e0f, 0x4aad, 0xa8, 0xd7, 0xe0, 0x6b, 0xaf, 0xeb, 0xcd, 0xfe);
			public static readonly Guid CLSID_WICImagingCategories = new Guid(0xfae3d380, 0xfea4, 0x4623, 0x8c, 0x75, 0xc6, 0xb6, 0x11, 0x10, 0xb6, 0x81);
			public static readonly Guid CLSID_WICImagingFactory = new Guid(0xcacaf262, 0x9370, 0x4615, 0xa1, 0x3b, 0x9f, 0x55, 0x39, 0xda, 0x4c, 0xa);
			public static readonly Guid CLSID_WICImagingFactory1 = new Guid(0xcacaf262, 0x9370, 0x4615, 0xa1, 0x3b, 0x9f, 0x55, 0x39, 0xda, 0x4c, 0xa);
			public static readonly Guid CLSID_WICImagingFactory2 = new Guid(0x317d06e8, 0x5f24, 0x433d, 0xbd, 0xf7, 0x79, 0xce, 0x68, 0xd8, 0xab, 0xc2);
			public static readonly Guid CLSID_WICJpegDecoder = new Guid(0x9456a480, 0xe88b, 0x43ea, 0x9e, 0x73, 0x0b, 0x2d, 0x9b, 0x71, 0xb1, 0xca);
			public static readonly Guid CLSID_WICJpegEncoder = new Guid(0x1a34f5c1, 0x4a5a, 0x46dc, 0xb6, 0x44, 0x1f, 0x45, 0x67, 0xe7, 0xa6, 0x76);
			public static readonly Guid CLSID_WICJpegQualcommPhoneEncoder = new Guid(0x68ed5c62, 0xf534, 0x4979, 0xb2, 0xb3, 0x68, 0x6a, 0x12, 0xb2, 0xb3, 0x4c);
			public static readonly Guid CLSID_WICPlanarFormatConverter = new Guid(0x184132b8, 0x32f8, 0x4784, 0x91, 0x31, 0xdd, 0x72, 0x24, 0xb2, 0x34, 0x38);
			public static readonly Guid CLSID_WICPngDecoder = new Guid(0x389ea17b, 0x5078, 0x4cde, 0xb6, 0xef, 0x25, 0xc1, 0x51, 0x75, 0xc7, 0x51);
			public static readonly Guid CLSID_WICPngDecoder1 = new Guid(0x389ea17b, 0x5078, 0x4cde, 0xb6, 0xef, 0x25, 0xc1, 0x51, 0x75, 0xc7, 0x51);
			public static readonly Guid CLSID_WICPngDecoder2 = new Guid(0xe018945b, 0xaa86, 0x4008, 0x9b, 0xd4, 0x67, 0x77, 0xa1, 0xe4, 0x0c, 0x11);
			public static readonly Guid CLSID_WICPngEncoder = new Guid(0x27949969, 0x876a, 0x41d7, 0x94, 0x47, 0x56, 0x8f, 0x6a, 0x35, 0xa4, 0xdc);
			public static readonly Guid CLSID_WICRAWDecoder = new Guid(0x41945702, 0x8302, 0x44A6, 0x94, 0x45, 0xAC, 0x98, 0xE8, 0xAF, 0xA0, 0x86);
			public static readonly Guid CLSID_WICTiffDecoder = new Guid(0xb54e85d9, 0xfe23, 0x499f, 0x8b, 0x88, 0x6a, 0xce, 0xa7, 0x13, 0x75, 0x2b);
			public static readonly Guid CLSID_WICTiffEncoder = new Guid(0x0131be10, 0x2001, 0x4c5f, 0xa9, 0xb0, 0xcc, 0x88, 0xfa, 0xb6, 0x4c, 0xe8);
			public static readonly Guid CLSID_WICWebpDecoder = new Guid(0x7693E886, 0x51C9, 0x4070, 0x84, 0x19, 0x9F, 0x70, 0X73, 0X8E, 0XC8, 0XFA);
			public static readonly Guid CLSID_WICWmpDecoder = new Guid(0xa26cec36, 0x234c, 0x4950, 0xae, 0x16, 0xe3, 0x4a, 0xac, 0xe7, 0x1d, 0x0d);
			public static readonly Guid CLSID_WICWmpEncoder = new Guid(0xac4ce3cb, 0xe1c1, 0x44cd, 0x82, 0x15, 0x5a, 0x16, 0x65, 0x50, 0x9e, 0xc2);
			public static readonly Guid GUID_ContainerFormatAdng = new Guid(0xf3ff6d0d, 0x38c0, 0x41c4, 0xb1, 0xfe, 0x1f, 0x38, 0x24, 0xf1, 0x7b, 0x84);
			public static readonly Guid GUID_ContainerFormatBmp = new Guid(0x0af1d87e, 0xfcfe, 0x4188, 0xbd, 0xeb, 0xa7, 0x90, 0x64, 0x71, 0xcb, 0xe3);
			public static readonly Guid GUID_ContainerFormatDds = new Guid(0x9967cb95, 0x2e85, 0x4ac8, 0x8c, 0xa2, 0x83, 0xd7, 0xcc, 0xd4, 0x25, 0xc9);
			public static readonly Guid GUID_ContainerFormatGif = new Guid(0x1f8a5601, 0x7d4d, 0x4cbd, 0x9c, 0x82, 0x1b, 0xc8, 0xd4, 0xee, 0xb9, 0xa5);
			public static readonly Guid GUID_ContainerFormatHeif = new Guid(0xe1e62521, 0x6787, 0x405b, 0xa3, 0x39, 0x50, 0x07, 0x15, 0xb5, 0x76, 0x3f);
			public static readonly Guid GUID_ContainerFormatIco = new Guid(0xa3a860c4, 0x338f, 0x4c17, 0x91, 0x9a, 0xfb, 0xa4, 0xb5, 0x62, 0x8f, 0x21);
			public static readonly Guid GUID_ContainerFormatJpeg = new Guid(0x19e4a5aa, 0x5662, 0x4fc5, 0xa0, 0xc0, 0x17, 0x58, 0x02, 0x8e, 0x10, 0x57);
			public static readonly Guid GUID_ContainerFormatPng = new Guid(0x1b7cfaf4, 0x713f, 0x473c, 0xbb, 0xcd, 0x61, 0x37, 0x42, 0x5f, 0xae, 0xaf);
			public static readonly Guid GUID_ContainerFormatRaw = new Guid(0xfe99ce60, 0xf19c, 0x433c, 0xa3, 0xae, 0x00, 0xac, 0xef, 0xa9, 0xca, 0x21);
			public static readonly Guid GUID_ContainerFormatTiff = new Guid(0x163bcc30, 0xe2e9, 0x4f0b, 0x96, 0x1d, 0xa3, 0xe9, 0xfd, 0xb7, 0x88, 0xa3);
			public static readonly Guid GUID_ContainerFormatWebp = new Guid(0xe094b0e2, 0x67f2, 0x45b3, 0xb0, 0xea, 0x11, 0x53, 0x37, 0xca, 0x7c, 0xf3);
			public static readonly Guid GUID_ContainerFormatWmp = new Guid(0x57a37caa, 0x367a, 0x4540, 0x91, 0x6b, 0xf1, 0x83, 0xc5, 0x09, 0x3a, 0x4b);
			public static readonly Guid GUID_VendorMicrosoft = new Guid(0xf0e749ca, 0xedef, 0x4589, 0xa7, 0x3a, 0xee, 0xe, 0x62, 0x6a, 0x2a, 0x2b);
			public static readonly Guid GUID_VendorMicrosoftBuiltIn = new Guid(0x257a30fd, 0x6b6, 0x462b, 0xae, 0xa4, 0x63, 0xf7, 0xb, 0x86, 0xe5, 0x33);
			public static readonly Guid GUID_WICPixelFormat112bpp6ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x37);
			public static readonly Guid GUID_WICPixelFormat112bpp7Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2a);
			public static readonly Guid GUID_WICPixelFormat128bpp7ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x38);
			public static readonly Guid GUID_WICPixelFormat128bpp8Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2b);
			public static readonly Guid GUID_WICPixelFormat128bppPRGBAFloat = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1a);
			public static readonly Guid GUID_WICPixelFormat128bppRGBAFixedPoint = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1e);
			public static readonly Guid GUID_WICPixelFormat128bppRGBAFloat = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x19);
			public static readonly Guid GUID_WICPixelFormat128bppRGBFixedPoint = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x41);
			public static readonly Guid GUID_WICPixelFormat128bppRGBFloat = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1b);
			public static readonly Guid GUID_WICPixelFormat144bpp8ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x39);
			public static readonly Guid GUID_WICPixelFormat16bppBGR555 = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x09);
			public static readonly Guid GUID_WICPixelFormat16bppBGR565 = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0a);
			public static readonly Guid GUID_WICPixelFormat16bppBGRA5551 = new Guid(0x05ec7c2b, 0xf1e6, 0x4961, 0xad, 0x46, 0xe1, 0xcc, 0x81, 0x0a, 0x87, 0xd2);
			public static readonly Guid GUID_WICPixelFormat16bppCbCr = new Guid(0xFF95BA6E, 0x11E0, 0x4263, 0xBB, 0x45, 0x01, 0x72, 0x1F, 0x34, 0x60, 0xA4);
			public static readonly Guid GUID_WICPixelFormat16bppCbQuantizedDctCoefficients = new Guid(0xD2C4FF61, 0x56A5, 0x49C2, 0x8B, 0x5C, 0x4C, 0x19, 0x25, 0x96, 0x48, 0x37);
			public static readonly Guid GUID_WICPixelFormat16bppCrQuantizedDctCoefficients = new Guid(0x2FE354F0, 0x1680, 0x42D8, 0x92, 0x31, 0xE7, 0x3C, 0x05, 0x65, 0xBF, 0xC1);
			public static readonly Guid GUID_WICPixelFormat16bppGray = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0b);
			public static readonly Guid GUID_WICPixelFormat16bppGrayFixedPoint = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x13);
			public static readonly Guid GUID_WICPixelFormat16bppGrayHalf = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x3e);
			public static readonly Guid GUID_WICPixelFormat16bppYQuantizedDctCoefficients = new Guid(0xA355F433, 0x48E8, 0x4A42, 0x84, 0xD8, 0xE2, 0xAA, 0x26, 0xCA, 0x80, 0xA4);
			public static readonly Guid GUID_WICPixelFormat1bppIndexed = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x01);
			public static readonly Guid GUID_WICPixelFormat24bpp3Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x20);
			public static readonly Guid GUID_WICPixelFormat24bppBGR = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0c);
			public static readonly Guid GUID_WICPixelFormat24bppRGB = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0d);
			public static readonly Guid GUID_WICPixelFormat2bppGray = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x06);
			public static readonly Guid GUID_WICPixelFormat2bppIndexed = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x02);
			public static readonly Guid GUID_WICPixelFormat32bpp3ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2e);
			public static readonly Guid GUID_WICPixelFormat32bpp4Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x21);
			public static readonly Guid GUID_WICPixelFormat32bppBGR = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0e);
			public static readonly Guid GUID_WICPixelFormat32bppBGR101010 = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x14);
			public static readonly Guid GUID_WICPixelFormat32bppBGRA = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x0f);
			public static readonly Guid GUID_WICPixelFormat32bppCMYK = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1c);
			public static readonly Guid GUID_WICPixelFormat32bppGrayFixedPoint = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x3f);
			public static readonly Guid GUID_WICPixelFormat32bppGrayFloat = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x11);
			public static readonly Guid GUID_WICPixelFormat32bppPBGRA = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x10);
			public static readonly Guid GUID_WICPixelFormat32bppPRGBA = new Guid(0x3cc4a650, 0xa527, 0x4d37, 0xa9, 0x16, 0x31, 0x42, 0xc7, 0xeb, 0xed, 0xba);
			public static readonly Guid GUID_WICPixelFormat32bppR10G10B10A2 = new Guid(0x604e1bb5, 0x8a3c, 0x4b65, 0xb1, 0x1c, 0xbc, 0x0b, 0x8d, 0xd7, 0x5b, 0x7f);
			public static readonly Guid GUID_WICPixelFormat32bppR10G10B10A2HDR10 = new Guid(0x9c215c5d, 0x1acc, 0x4f0e, 0xa4, 0xbc, 0x70, 0xfb, 0x3a, 0xe8, 0xfd, 0x28);
			public static readonly Guid GUID_WICPixelFormat32bppRGB = new Guid(0xd98c6b95, 0x3efe, 0x47d6, 0xbb, 0x25, 0xeb, 0x17, 0x48, 0xab, 0x0c, 0xf1);
			public static readonly Guid GUID_WICPixelFormat32bppRGBA = new Guid(0xf5c7ad2d, 0x6a8d, 0x43dd, 0xa7, 0xa8, 0xa2, 0x99, 0x35, 0x26, 0x1a, 0xe9);
			public static readonly Guid GUID_WICPixelFormat32bppRGBA1010102 = new Guid(0x25238D72, 0xFCF9, 0x4522, 0xb5, 0x14, 0x55, 0x78, 0xe5, 0xad, 0x55, 0xe0);
			public static readonly Guid GUID_WICPixelFormat32bppRGBA1010102XR = new Guid(0x00DE6B9A, 0xC101, 0x434b, 0xb5, 0x02, 0xd0, 0x16, 0x5e, 0xe1, 0x12, 0x2c);
			public static readonly Guid GUID_WICPixelFormat32bppRGBE = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x3d);
			public static readonly Guid GUID_WICPixelFormat40bpp4ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2f);
			public static readonly Guid GUID_WICPixelFormat40bpp5Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x22);
			public static readonly Guid GUID_WICPixelFormat40bppCMYKAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2c);
			public static readonly Guid GUID_WICPixelFormat48bpp3Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x26);
			public static readonly Guid GUID_WICPixelFormat48bpp5ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x30);
			public static readonly Guid GUID_WICPixelFormat48bpp6Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x23);
			public static readonly Guid GUID_WICPixelFormat48bppBGR = new Guid(0xe605a384, 0xb468, 0x46ce, 0xbb, 0x2e, 0x36, 0xf1, 0x80, 0xe6, 0x43, 0x13);
			public static readonly Guid GUID_WICPixelFormat48bppBGRFixedPoint = new Guid(0x49ca140e, 0xcab6, 0x493b, 0x9d, 0xdf, 0x60, 0x18, 0x7c, 0x37, 0x53, 0x2a);
			public static readonly Guid GUID_WICPixelFormat48bppRGB = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x15);
			public static readonly Guid GUID_WICPixelFormat48bppRGBFixedPoint = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x12);
			public static readonly Guid GUID_WICPixelFormat48bppRGBHalf = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x3b);
			public static readonly Guid GUID_WICPixelFormat4bppGray = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x07);
			public static readonly Guid GUID_WICPixelFormat4bppIndexed = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x03);
			public static readonly Guid GUID_WICPixelFormat56bpp6ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x31);
			public static readonly Guid GUID_WICPixelFormat56bpp7Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x24);
			public static readonly Guid GUID_WICPixelFormat64bpp3ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x34);
			public static readonly Guid GUID_WICPixelFormat64bpp4Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x27);
			public static readonly Guid GUID_WICPixelFormat64bpp7ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x32);
			public static readonly Guid GUID_WICPixelFormat64bpp8Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x25);
			public static readonly Guid GUID_WICPixelFormat64bppBGRA = new Guid(0x1562ff7c, 0xd352, 0x46f9, 0x97, 0x9e, 0x42, 0x97, 0x6b, 0x79, 0x22, 0x46);
			public static readonly Guid GUID_WICPixelFormat64bppBGRAFixedPoint = new Guid(0x356de33c, 0x54d2, 0x4a23, 0xbb, 0x4, 0x9b, 0x7b, 0xf9, 0xb1, 0xd4, 0x2d);
			public static readonly Guid GUID_WICPixelFormat64bppCMYK = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1f);
			public static readonly Guid GUID_WICPixelFormat64bppPBGRA = new Guid(0x8c518e8e, 0xa4ec, 0x468b, 0xae, 0x70, 0xc9, 0xa3, 0x5a, 0x9c, 0x55, 0x30);
			public static readonly Guid GUID_WICPixelFormat64bppPRGBA = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x17);
			public static readonly Guid GUID_WICPixelFormat64bppPRGBAHalf = new Guid(0x58ad26c2, 0xc623, 0x4d9d, 0xb3, 0x20, 0x38, 0x7e, 0x49, 0xf8, 0xc4, 0x42);
			public static readonly Guid GUID_WICPixelFormat64bppRGB = new Guid(0xa1182111, 0x186d, 0x4d42, 0xbc, 0x6a, 0x9c, 0x83, 0x03, 0xa8, 0xdf, 0xf9);
			public static readonly Guid GUID_WICPixelFormat64bppRGBA = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x16);
			public static readonly Guid GUID_WICPixelFormat64bppRGBAFixedPoint = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x1d);
			public static readonly Guid GUID_WICPixelFormat64bppRGBAHalf = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x3a);
			public static readonly Guid GUID_WICPixelFormat64bppRGBFixedPoint = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x40);
			public static readonly Guid GUID_WICPixelFormat64bppRGBHalf = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x42);
			public static readonly Guid GUID_WICPixelFormat72bpp8ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x33);
			public static readonly Guid GUID_WICPixelFormat80bpp4ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x35);
			public static readonly Guid GUID_WICPixelFormat80bpp5Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x28);
			public static readonly Guid GUID_WICPixelFormat80bppCMYKAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x2d);
			public static readonly Guid GUID_WICPixelFormat8bppAlpha = new Guid(0xe6cd0116, 0xeeba, 0x4161, 0xaa, 0x85, 0x27, 0xdd, 0x9f, 0xb3, 0xa8, 0x95);
			public static readonly Guid GUID_WICPixelFormat8bppCb = new Guid(0x1339F224, 0x6BFE, 0x4C3E, 0x93, 0x02, 0xE4, 0xF3, 0xA6, 0xD0, 0xCA, 0x2A);
			public static readonly Guid GUID_WICPixelFormat8bppCr = new Guid(0xB8145053, 0x2116, 0x49F0, 0x88, 0x35, 0xED, 0x84, 0x4B, 0x20, 0x5C, 0x51);
			public static readonly Guid GUID_WICPixelFormat8bppGray = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x08);
			public static readonly Guid GUID_WICPixelFormat8bppIndexed = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x04);
			public static readonly Guid GUID_WICPixelFormat8bppY = new Guid(0x91B4DB54, 0x2DF9, 0x42F0, 0xB4, 0x49, 0x29, 0x09, 0xBB, 0x3D, 0xF8, 0x8E);
			public static readonly Guid GUID_WICPixelFormat96bpp5ChannelsAlpha = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x36);
			public static readonly Guid GUID_WICPixelFormat96bpp6Channels = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x29);
			public static readonly Guid GUID_WICPixelFormat96bppRGBFixedPoint = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x18);
			public static readonly Guid GUID_WICPixelFormat96bppRGBFloat = new Guid(0xe3fed78f, 0xe8db, 0x4acf, 0x84, 0xc1, 0xe9, 0x7f, 0x61, 0x36, 0xb3, 0x27);
			public static readonly Guid GUID_WICPixelFormatBlackWhite = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x05);
			public static readonly Guid GUID_WICPixelFormatDontCare = new Guid(0x6fddc324, 0x4e03, 0x4bfe, 0xb1, 0x85, 0x3d, 0x77, 0x76, 0x8d, 0xc9, 0x00);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		}
	}
}