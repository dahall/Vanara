using static Vanara.PInvoke.D2d1;
using static Vanara.PInvoke.DXGI;

namespace Vanara.PInvoke;

/// <summary>Items from the WindowsCodecs.dll</summary>
public static partial class WindowsCodecs
{
	/// <summary>Contains members that identify a pattern within an image file which can be used to identify a particular format.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicbitmappattern typedef struct WICBitmapPattern {
	// ULARGE_INTEGER Position; ULONG Length; BYTE *Pattern; BYTE *Mask; BOOL EndOfStream; } WICBitmapPattern;
	[PInvokeData("wincodec.h", MSDNShortId = "6f0cd639-c0db-46e4-b3a3-bc21222d97ee")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICBitmapPattern
	{
		/// <summary>
		/// <para>Type: <c>ULARGE_INTEGER</c></para>
		/// <para>The offset the pattern is located in the file.</para>
		/// </summary>
		public ulong Position;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The pattern length.</para>
		/// </summary>
		public uint Length;

		/// <summary>
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>The actual pattern.</para>
		/// </summary>
		public IntPtr Pattern;

		/// <summary>
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>The pattern mask.</para>
		/// </summary>
		public IntPtr Mask;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>The end of the stream.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool EndOfStream;
	}

	/// <summary>Specifies the pixel format, buffer, stride and size of a component plane for a planar pixel format.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicbitmapplane typedef struct WICBitmapPlane {
	// WICPixelFormatGUID Format; BYTE *pbBuffer; UINT cbStride; UINT cbBufferSize; } WICBitmapPlane;
	[PInvokeData("wincodec.h", MSDNShortId = "4E988284-DE71-48B2-BF77-D616FAA2A3B1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICBitmapPlane
	{
		/// <summary>
		/// <para>Type: <c>WICPixelFormatGUID</c></para>
		/// <para>Describes the pixel format of the plane.</para>
		/// </summary>
		public Guid Format;

		/// <summary>
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Pointer to the buffer that holds the plane’s pixel components.</para>
		/// </summary>
		public IntPtr pbBuffer;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The stride of the buffer ponted to by pbData. Stride indicates the total number of bytes to go from the beginning of one
		/// scanline to the beginning of the next scanline.
		/// </para>
		/// </summary>
		public uint cbStride;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The total size of the buffer pointed to by pbBuffer.</para>
		/// </summary>
		public uint cbBufferSize;
	}

	/// <summary>Specifies the pixel format and size of a component plane.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicbitmapplanedescription typedef struct
	// WICBitmapPlaneDescription { WICPixelFormatGUID Format; UINT Width; UINT Height; } WICBitmapPlaneDescription;
	[PInvokeData("wincodec.h", MSDNShortId = "A5685E9B-F2B9-4A1B-9CEA-044E5FA1CC6D")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICBitmapPlaneDescription
	{
		/// <summary>Describes the pixel format of the plane.</summary>
		public Guid Format;

		/// <summary>Component width of the plane.</summary>
		public uint Width;

		/// <summary>Component height of the plane.</summary>
		public uint Height;
	}

	/// <summary>Specifies the DXGI_FORMAT and block information of a DDS format.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicddsformatinfo typedef struct WICDdsFormatInfo {
	// DXGI_FORMAT DxgiFormat; UINT BytesPerBlock; UINT BlockWidth; UINT BlockHeight; } WICDdsFormatInfo;
	[PInvokeData("wincodec.h", MSDNShortId = "C5F1DA49-EC11-4068-9DC6-D721894371F9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICDdsFormatInfo
	{
		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The DXGI_FORMAT</para>
		/// </summary>
		public DXGI_FORMAT DxgiFormat;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The size of a single block in bytes. For DXGI_FORMAT values that are not block-based, the value is equal to the size of a
		/// single pixel in bytes.
		/// </para>
		/// </summary>
		public uint BytesPerBlock;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of a single block in pixels. For DXGI_FORMAT values that are not block-based, the value is 1.</para>
		/// </summary>
		public uint BlockWidth;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The height of a single block in pixels. For DXGI_FORMAT values that are not block-based, the value is 1.</para>
		/// </summary>
		public uint BlockHeight;
	}

	/// <summary>Specifies the DDS image dimension, DXGI_FORMAT and alpha mode of contained data.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicddsparameters typedef struct WICDdsParameters { UINT
	// Width; UINT Height; UINT Depth; UINT MipLevels; UINT ArraySize; DXGI_FORMAT DxgiFormat; WICDdsDimension Dimension;
	// WICDdsAlphaMode AlphaMode; } WICDdsParameters;
	[PInvokeData("wincodec.h", MSDNShortId = "2E5755B4-E8DC-40B2-8DA1-B053A261079B")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICDdsParameters
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width, in pixels, of the texture at the largest mip size (mip level 0).</para>
		/// </summary>
		public uint Width;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The height, in pixels, of the texture at the largest mip size (mip level 0). When the DDS image contains a 1-dimensional
		/// texture, this value is equal to 1.
		/// </para>
		/// </summary>
		public uint Height;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of slices in the 3D texture. This is equivalent to the depth, in pixels, of the 3D texture at the largest mip
		/// size (mip level 0). When the DDS image contains a 1- or 2-dimensional texture, this value is equal to 1.
		/// </para>
		/// </summary>
		public uint Depth;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of mip levels contained in the DDS image.</para>
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of textures in the array in the DDS image.</para>
		/// </summary>
		public uint ArraySize;

		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The DXGI_FORMAT of the DDS pixel data.</para>
		/// </summary>
		public DXGI_FORMAT DxgiFormat;

		/// <summary>
		/// <para>Type: <c>WICDdsDimension</c></para>
		/// <para>Specifies the dimension type of the data contained in DDS image (1D, 2D, 3D or cube texture).</para>
		/// </summary>
		public WICDdsDimension Dimension;

		/// <summary>
		/// <para>Type: <c>WICDdsAlphaMode</c></para>
		/// <para>Specifies the alpha behavior of the DDS image.</para>
		/// </summary>
		public WICDdsAlphaMode AlphaMode;
	}

	/// <summary>This defines parameters that you can use to override the default parameters normally used when encoding an image.</summary>
	/// <remarks>
	/// <para>If this parameter is not passed to the encoding API, the encoder uses these settings.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>A pixel format of (DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_PREMULTIPLIED).</term>
	/// </item>
	/// <item>
	/// <term>An x and y DPI of 96.</term>
	/// </item>
	/// <item>
	/// <term>The entire image bounds will be used for encoding.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The parameters as specified can't result in a scale. The encoder can use a larger portion of the input image based
	/// on the passed in DPI and the pixel width and height.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicimageparameters typedef struct WICImageParameters {
	// D2D1_PIXEL_FORMAT PixelFormat; FLOAT DpiX; FLOAT DpiY; FLOAT Top; FLOAT Left; UINT32 PixelWidth; UINT32 PixelHeight; } WICImageParameters;
	[PInvokeData("wincodec.h", MSDNShortId = "0B461697-C7ED-48C9-A880-1B5F4A26FCFC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICImageParameters
	{
		/// <summary>The pixel format to which the image is processed before it is written to the encoder.</summary>
		public D2D1_PIXEL_FORMAT PixelFormat;

		/// <summary>The DPI in the x dimension.</summary>
		public float DpiX;

		/// <summary>The DPI in the y dimension.</summary>
		public float DpiY;

		/// <summary>The top corner in pixels of the image space to be encoded to the destination.</summary>
		public float Top;

		/// <summary>The left corner in pixels of the image space to be encoded to the destination.</summary>
		public float Left;

		/// <summary>The width in pixels of the part of the image to write.</summary>
		public uint PixelWidth;

		/// <summary>The height in pixels of the part of the image to write.</summary>
		public uint PixelHeight;
	}

	/// <summary>Represents a JPEG frame header.</summary>
	/// <remarks>Get the frame header for an image by calling IWICJpegFrameDecode::GetFrameHeader.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicjpegframeheader typedef struct WICJpegFrameHeader {
	// UINT Width; UINT Height; WICJpegTransferMatrix TransferMatrix; WICJpegScanType ScanType; UINT cComponents; DWORD
	// ComponentIdentifiers; DWORD SampleFactors; DWORD QuantizationTableIndices; } WICJpegFrameHeader;
	[PInvokeData("wincodec.h", MSDNShortId = "BB207D78-9E27-49A4-91E4-601CED109389")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICJpegFrameHeader
	{
		/// <summary>The width of the JPEG frame.</summary>
		public uint Width;

		/// <summary>The height of the JPEG frame.</summary>
		public uint Height;

		/// <summary>The transfer matrix of the JPEG frame.</summary>
		public WICJpegTransferMatrix TransferMatrix;

		/// <summary>The scan type of the JPEG frame.</summary>
		public WICJpegScanType ScanType;

		/// <summary>The number of components in the frame.</summary>
		public uint cComponents;

		/// <summary>The component identifiers.</summary>
		public uint ComponentIdentifiers;

		/// <summary>
		/// <para>The sample factors. Use one of the following constants, described in IWICJpegFrameDecode Constants.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>WIC_JPEG_SAMPLE_FACTORS_ONE</term>
		/// </item>
		/// <item>
		/// <term>WIC_JPEG_SAMPLE_FACTORS_THREE_420</term>
		/// </item>
		/// <item>
		/// <term>WIC_JPEG_SAMPLE_FACTORS_THREE_422</term>
		/// </item>
		/// <item>
		/// <term>WIC_JPEG_SAMPLE_FACTORS_THREE_440</term>
		/// </item>
		/// <item>
		/// <term>WIC_JPEG_SAMPLE_FACTORS_THREE_444</term>
		/// </item>
		/// </list>
		/// </summary>
		public WIC_JPEG_SAMPLE_FACTORS SampleFactors;

		/// <summary>
		/// <para>
		/// The format of the quantization table indices. Use one of the following constants, described in IWICJpegFrameDecode Constants.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>WIC_JPEG_QUANTIZATION_BASELINE_ONE</term>
		/// </item>
		/// <item>
		/// <term>WIC_JPEG_QUANTIZATION_BASELINE_THREE</term>
		/// </item>
		/// </list>
		/// </summary>
		public WIC_JPEG_QUANTIZATION_BASELINE QuantizationTableIndices;
	}

	/// <summary>Represents a JPEG frame header.</summary>
	/// <remarks>Get the scan header for an image by calling IWICJpegFrameDecode::GetScanHeader.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicjpegscanheader typedef struct WICJpegScanHeader { UINT
	// cComponents; UINT RestartInterval; DWORD ComponentSelectors; DWORD HuffmanTableIndices; BYTE StartSpectralSelection; BYTE
	// EndSpectralSelection; BYTE SuccessiveApproximationHigh; BYTE SuccessiveApproximationLow; } WICJpegScanHeader;
	[PInvokeData("wincodec.h", MSDNShortId = "87A36F9B-CD6B-4343-AAA7-9FDBAD41E38A")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICJpegScanHeader
	{
		/// <summary>The number of components in the scan.</summary>
		public uint cComponents;

		/// <summary>The interval of reset markers within the scan.</summary>
		public uint RestartInterval;

		/// <summary>The component identifiers.</summary>
		public uint ComponentSelectors;

		/// <summary>
		/// <para>
		/// The format of the quantization table indices. Use one of the following constants, described in IWICJpegFrameDecode Constants.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>WIC_JPEG_HUFFMAN_BASELINE_ONE</term>
		/// </item>
		/// <item>
		/// <term>WIC_JPEG_HUFFMAN_BASELINE_THREE</term>
		/// </item>
		/// </list>
		/// </summary>
		public WIC_JPEG_HUFFMAN_BASELINE HuffmanTableIndices;

		/// <summary>The start of the spectral selection.</summary>
		public byte StartSpectralSelection;

		/// <summary>The end of the spectral selection.</summary>
		public byte EndSpectralSelection;

		/// <summary>The successive approximation high.</summary>
		public byte SuccessiveApproximationHigh;

		/// <summary>The successive approximation low.</summary>
		public byte SuccessiveApproximationLow;
	}

	/// <summary>Represents metadata header.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/ns-wincodecsdk-wicmetadataheader typedef struct WICMetadataHeader
	// { ULARGE_INTEGER Position; ULONG Length; BYTE *Header; ULARGE_INTEGER DataOffset; } WICMetadataHeader;
	[PInvokeData("wincodecsdk.h", MSDNShortId = "f643b163-55b2-4691-a4eb-fc162949e936")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICMetadataHeader
	{
		/// <summary>
		/// <para>Type: <c>ULARGE_INTEGER</c></para>
		/// <para>The position of the header.</para>
		/// </summary>
		public ulong Position;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The length of the header.</para>
		/// </summary>
		public uint Length;

		/// <summary>
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Pointer to the header.</para>
		/// </summary>
		public IntPtr Header;

		/// <summary>
		/// <para>Type: <c>ULARGE_INTEGER</c></para>
		/// <para>The offset of the header.</para>
		/// </summary>
		public ulong DataOffset;
	}

	/// <summary>Represents a metadata pattern.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodecsdk/ns-wincodecsdk-wicmetadatapattern typedef struct
	// WICMetadataPattern { ULARGE_INTEGER Position; ULONG Length; BYTE *Pattern; BYTE *Mask; ULARGE_INTEGER DataOffset; } WICMetadataPattern;
	[PInvokeData("wincodecsdk.h", MSDNShortId = "cea9e07d-5e55-4320-9744-b5864b58cfd6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICMetadataPattern
	{
		/// <summary>
		/// <para>Type: <c>ULARGE_INTEGER</c></para>
		/// <para>The position of the pattern.</para>
		/// </summary>
		public ulong Position;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The length of the pattern.</para>
		/// </summary>
		public uint Length;

		/// <summary>
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Pointer to the pattern.</para>
		/// </summary>
		public IntPtr Pattern;

		/// <summary>
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Pointer to the pattern mask.</para>
		/// </summary>
		public IntPtr Mask;

		/// <summary>
		/// <para>Type: <c>ULARGE_INTEGER</c></para>
		/// <para>The offset location of the pattern.</para>
		/// </summary>
		public ulong DataOffset;
	}

	/// <summary>Defines raw codec capabilites.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicrawcapabilitiesinfo typedef struct
	// WICRawCapabilitiesInfo { UINT cbSize; UINT CodecMajorVersion; UINT CodecMinorVersion; WICRawCapabilities
	// ExposureCompensationSupport; WICRawCapabilities ContrastSupport; WICRawCapabilities RGBWhitePointSupport; WICRawCapabilities
	// NamedWhitePointSupport; UINT NamedWhitePointSupportMask; WICRawCapabilities KelvinWhitePointSupport; WICRawCapabilities
	// GammaSupport; WICRawCapabilities TintSupport; WICRawCapabilities SaturationSupport; WICRawCapabilities SharpnessSupport;
	// WICRawCapabilities NoiseReductionSupport; WICRawCapabilities DestinationColorProfileSupport; WICRawCapabilities ToneCurveSupport;
	// WICRawRotationCapabilities RotationSupport; WICRawCapabilities RenderModeSupport; } WICRawCapabilitiesInfo;
	[PInvokeData("wincodec.h", MSDNShortId = "1466cd90-8eab-4c5c-bb77-c75d35fe586b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICRawCapabilitiesInfo
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of the <c>WICRawCapabilitiesInfo</c> structure.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The codec's major version.</para>
		/// </summary>
		public uint CodecMajorVersion;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The codec's minor version.</para>
		/// </summary>
		public uint CodecMinorVersion;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of exposure compensation support.</para>
		/// </summary>
		public WICRawCapabilities ExposureCompensationSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of contrast support.</para>
		/// </summary>
		public WICRawCapabilities ContrastSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of RGB white point support.</para>
		/// </summary>
		public WICRawCapabilities RGBWhitePointSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of WICNamedWhitePoint support.</para>
		/// </summary>
		public WICRawCapabilities NamedWhitePointSupport;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The WICNamedWhitePoint mask.</para>
		/// </summary>
		public uint NamedWhitePointSupportMask;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of kelvin white point support.</para>
		/// </summary>
		public WICRawCapabilities KelvinWhitePointSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of gamma support.</para>
		/// </summary>
		public WICRawCapabilities GammaSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of tint support.</para>
		/// </summary>
		public WICRawCapabilities TintSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of saturation support.</para>
		/// </summary>
		public WICRawCapabilities SaturationSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of sharpness support.</para>
		/// </summary>
		public WICRawCapabilities SharpnessSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of noise reduction support.</para>
		/// </summary>
		public WICRawCapabilities NoiseReductionSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of destination color profile support.</para>
		/// </summary>
		public WICRawCapabilities DestinationColorProfileSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of tone curve support.</para>
		/// </summary>
		public WICRawCapabilities ToneCurveSupport;

		/// <summary>
		/// <para>Type: <c>WICRawRotationCapabilities</c></para>
		/// <para>The WICRawRotationCapabilities of rotation support.</para>
		/// </summary>
		public WICRawRotationCapabilities RotationSupport;

		/// <summary>
		/// <para>Type: <c>WICRawCapabilities</c></para>
		/// <para>The WICRawCapabilities of WICRawRenderMode support.</para>
		/// </summary>
		public WICRawCapabilities RenderModeSupport;
	}

	/// <summary>Represents a raw image tone curve.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicrawtonecurve typedef struct WICRawToneCurve { UINT
	// cPoints; WICRawToneCurvePoint aPoints[1]; } WICRawToneCurve;
	[PInvokeData("wincodec.h", MSDNShortId = "45eedc32-a642-4ef6-a02a-63eaeacf0012")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WICRawToneCurve>), nameof(cPoints))]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICRawToneCurve
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of tone curve points.</para>
		/// </summary>
		public uint cPoints;

		/// <summary>
		/// <para>Type: <c>WICRawToneCurvePoint[1]</c></para>
		/// <para>The array of tone curve points.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public WICRawToneCurvePoint[] aPoints;
	}

	/// <summary>Represents a raw image tone curve point.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicrawtonecurvepoint typedef struct WICRawToneCurvePoint
	// { double Input; double Output; } WICRawToneCurvePoint;
	[PInvokeData("wincodec.h", MSDNShortId = "c5fbcd25-2884-4313-93d5-c1f290de4a77")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICRawToneCurvePoint
	{
		/// <summary>
		/// <para>Type: <c>double</c></para>
		/// <para>The tone curve input.</para>
		/// </summary>
		public double Input;

		/// <summary>
		/// <para>Type: <c>double</c></para>
		/// <para>The tone curve output.</para>
		/// </summary>
		public double Output;
	}

	/// <summary>Represents a rectangle for Windows Imaging Component (WIC) API.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicrect typedef struct WICRect { INT X; INT Y; INT Width;
	// INT Height; } WICRect;
	[PInvokeData("wincodec.h", MSDNShortId = "e07c26bf-b645-4382-bb93-8472ba397026")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WICRect
	{
		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>The horizontal coordinate of the rectangle.</para>
		/// </summary>
		public int X;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>The vertical coordinate of the rectangle.</para>
		/// </summary>
		public int Y;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>The width of the rectangle.</para>
		/// </summary>
		public int Width;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>The height of the rectangle.</para>
		/// </summary>
		public int Height;
	}

	/// <summary>Represents a rectangle for Windows Imaging Component (WIC) API.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/ns-wincodec-wicrect typedef struct WICRect { INT X; INT Y; INT Width;
	// INT Height; } WICRect;
	[PInvokeData("wincodec.h", MSDNShortId = "e07c26bf-b645-4382-bb93-8472ba397026")]
	[StructLayout(LayoutKind.Sequential)]
	public class PWICRect
	{
		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>The horizontal coordinate of the rectangle.</para>
		/// </summary>
		public int X;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>The vertical coordinate of the rectangle.</para>
		/// </summary>
		public int Y;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>The width of the rectangle.</para>
		/// </summary>
		public int Width;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>The height of the rectangle.</para>
		/// </summary>
		public int Height;

		/// <summary>Initializes a new instance of the <see cref="PWICRect"/> class.</summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		public PWICRect(int x, int y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		/// <summary>Performs an implicit conversion from <see cref="WICRect"/> to <see cref="PWICRect"/>.</summary>
		/// <param name="rect">The rect.</param>
		/// <returns>The resulting <see cref="PWICRect"/> instance from the conversion.</returns>
		public static implicit operator PWICRect(in WICRect rect) => new(rect.X, rect.Y, rect.Width, rect.Height);
	}
}