using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Functions and types from Gdi32.dll.</summary>
	public static partial class Gdi32
	{
		/// <summary>The type of compression for a compressed bottom-up bitmap (top-down DIBs cannot be compressed). Used in <see cref="BITMAPINFOHEADER"/>.</summary>
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183376")]
		public enum BitmapCompressionMode : uint
		{
			/// <summary>An uncompressed format.</summary>
			BI_RGB = 0,

			/// <summary>
			/// A run-length encoded (RLE) format for bitmaps with 8 bpp. The compression format is a 2-byte format consisting of a count
			/// byte followed by a byte containing a color index.
			/// </summary>
			BI_RLE8 = 1,

			/// <summary>
			/// An RLE format for bitmaps with 4 bpp. The compression format is a 2-byte format consisting of a count byte followed by two
			/// word-length color indexes.
			/// </summary>
			BI_RLE4 = 2,

			/// <summary>
			/// Specifies that the bitmap is not compressed and that the color table consists of three DWORD color masks that specify the
			/// red, green, and blue components, respectively, of each pixel. This is valid when used with 16- and 32-bpp bitmaps.
			/// </summary>
			BI_BITFIELDS = 3,

			/// <summary>Indicates that the image is a JPEG image.</summary>
			BI_JPEG = 4,

			/// <summary>Indicates that the image is a PNG image.</summary>
			BI_PNG = 5
		}

		/// <summary>The BITMAP structure defines the type, width, height, color format, and bit values of a bitmap.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183371")]
		public struct BITMAP
		{
			/// <summary>The bitmap type. This member must be zero.</summary>
			public int bmType;

			/// <summary>The width, in pixels, of the bitmap. The width must be greater than zero.</summary>
			public int bmWidth;

			/// <summary>The height, in pixels, of the bitmap. The height must be greater than zero.</summary>
			public int bmHeight;

			/// <summary>
			/// The number of bytes in each scan line. This value must be divisible by 2, because the system assumes that the bit values of
			/// a bitmap form an array that is word aligned.
			/// </summary>
			public int bmWidthBytes;

			/// <summary>The count of color planes.</summary>
			public ushort bmPlanes;

			/// <summary>The number of bits required to indicate the color of a pixel.</summary>
			public ushort bmBitsPixel;

			/// <summary>
			/// A pointer to the location of the bit values for the bitmap. The bmBits member must be a pointer to an array of character
			/// (1-byte) values.
			/// </summary>
			public IntPtr bmBits;
		}

		/// <summary>The <c>BITMAPCOREHEADER</c> structure contains information about the dimensions and color format of a DIB.</summary>
		/// <remarks>
		/// <para>
		/// The BITMAPCOREINFO structure combines the <c>BITMAPCOREHEADER</c> structure and a color table to provide a complete definition
		/// of the dimensions and colors of a DIB. For more information about specifying a DIB, see <c>BITMAPCOREINFO</c>.
		/// </para>
		/// <para>
		/// An application should use the information stored in the <c>bcSize</c> member to locate the color table in a BITMAPCOREINFO
		/// structure, using a method such as the following:
		/// </para>
		/// <para>
		/// <code> pColor = ((LPBYTE) pBitmapCoreInfo + (WORD) (pBitmapCoreInfo -&gt; bcSize))</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-bitmapcoreheader typedef struct tagBITMAPCOREHEADER { DWORD
		// bcSize; WORD bcWidth; WORD bcHeight; WORD bcPlanes; WORD bcBitCount; } BITMAPCOREHEADER, *LPBITMAPCOREHEADER, *PBITMAPCOREHEADER;
		[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.tagBITMAPCOREHEADER")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct BITMAPCOREHEADER
		{
			/// <summary>The number of bytes required by the structure.</summary>
			public uint bcSize;

			/// <summary>The width of the bitmap, in pixels.</summary>
			public ushort bcWidth;

			/// <summary>The height of the bitmap, in pixels.</summary>
			public ushort bcHeight;

			/// <summary>The number of planes for the target device. This value must be 1.</summary>
			public ushort bcPlanes;

			/// <summary>The number of bits-per-pixel. This value must be 1, 4, 8, or 24.</summary>
			public ushort bcBitCount;
		}

		/// <summary>The <c>BITMAPCOREINFO</c> structure defines the dimensions and color information for a DIB.</summary>
		/// <remarks>
		/// <para>
		/// A DIB consists of two parts: a <c>BITMAPCOREINFO</c> structure describing the dimensions and colors of the bitmap, and an array
		/// of bytes defining the pixels of the bitmap. The bits in the array are packed together, but each scan line must be padded with
		/// zeros to end on a <c>LONG</c> boundary. The origin of the bitmap is the lower-left corner.
		/// </para>
		/// <para>
		/// The <c>bcBitCount</c> member of the BITMAPCOREHEADER structure determines the number of bits that define each pixel and the
		/// maximum number of colors in the bitmap. This member can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// The bitmap is monochrome, and the bmciColors member contains two entries. Each bit in the bitmap array represents a pixel. If
		/// the bit is clear, the pixel is displayed with the color of the first entry in the bmciColors table; if the bit is set, the pixel
		/// has the color of the second entry in the table.
		/// </term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>
		/// The bitmap has a maximum of 16 colors, and the bmciColors member contains up to 16 entries. Each pixel in the bitmap is
		/// represented by a 4-bit index into the color table. For example, if the first byte in the bitmap is 0x1F, the byte represents two
		/// pixels. The first pixel contains the color in the second table entry, and the second pixel contains the color in the sixteenth
		/// table entry.
		/// </term>
		/// </item>
		/// <item>
		/// <term>8</term>
		/// <term>
		/// The bitmap has a maximum of 256 colors, and the bmciColors member contains up to 256 entries. In this case, each byte in the
		/// array represents a single pixel.
		/// </term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// The bitmap has a maximum of 2 (24) colors, and the bmciColors member is NULL. Each three-byte triplet in the bitmap array
		/// represents the relative intensities of blue, green, and red, respectively, for a pixel.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The colors in the <c>bmciColors</c> table should appear in order of importance.</para>
		/// <para>
		/// Alternatively, for functions that use DIBs, the <c>bmciColors</c> member can be an array of 16-bit unsigned integers that
		/// specify indexes into the currently realized logical palette, instead of explicit RGB values. In this case, an application using
		/// the bitmap must call the DIB functions ( CreateDIBitmap, CreateDIBPatternBrush, and CreateDIBSection ) with the iUsage parameter
		/// set to DIB_PAL_COLORS.
		/// </para>
		/// <para><c>Note</c>
		/// <para></para>
		/// The <c>bmciColors</c> member should not contain palette indexes if the bitmap is to be stored in a file or transferred to
		/// another application. Unless the application has exclusive use and control of the bitmap, the bitmap color table should contain
		/// explicit RGB values.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-bitmapcoreinfo typedef struct tagBITMAPCOREINFO {
		// BITMAPCOREHEADER bmciHeader; RGBTRIPLE bmciColors[1]; } BITMAPCOREINFO, *LPBITMAPCOREINFO, *PBITMAPCOREINFO;
		[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.tagBITMAPCOREINFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct BITMAPCOREINFO
		{
			/// <summary>A BITMAPCOREHEADER structure that contains information about the dimensions and color format of a DIB.</summary>
			public BITMAPCOREHEADER bmciHeader;

			/// <summary>Specifies an array of RGBTRIPLE structures that define the colors in the bitmap.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public RGBTRIPLE[] bmciColors;
		}

		/// <summary>
		/// The <c>BITMAPFILEHEADER</c> structure contains information about the type, size, and layout of a file that contains a DIB.
		/// </summary>
		/// <remarks>
		/// A BITMAPINFO or BITMAPCOREINFO structure immediately follows the <c>BITMAPFILEHEADER</c> structure in the DIB file. For more
		/// information, see Bitmap Storage.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-bitmapfileheader typedef struct tagBITMAPFILEHEADER { WORD
		// bfType; DWORD bfSize; WORD bfReserved1; WORD bfReserved2; DWORD bfOffBits; } BITMAPFILEHEADER, *LPBITMAPFILEHEADER, *PBITMAPFILEHEADER;
		[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.tagBITMAPFILEHEADER")]
		[StructLayout(LayoutKind.Sequential)]
		public struct BITMAPFILEHEADER
		{
			/// <summary>The file type; must be BM.</summary>
			public ushort bfType;

			/// <summary>The size, in bytes, of the bitmap file.</summary>
			public uint bfSize;

			/// <summary>Reserved; must be zero.</summary>
			public ushort bfReserved1;

			/// <summary>Reserved; must be zero.</summary>
			public ushort bfReserved2;

			/// <summary>The offset, in bytes, from the beginning of the <c>BITMAPFILEHEADER</c> structure to the bitmap bits.</summary>
			public uint bfOffBits;
		}

		/// <summary>The BITMAPINFO structure defines the dimensions and color information for a DIB.</summary>
		/// <remarks>
		/// A DIB consists of two distinct parts: a BITMAPINFO structure describing the dimensions and colors of the bitmap, and an array of
		/// bytes defining the pixels of the bitmap. The bits in the array are packed together, but each scan line must be padded with zeros
		/// to end on a LONG data-type boundary. If the height of the bitmap is positive, the bitmap is a bottom-up DIB and its origin is
		/// the lower-left corner. If the height is negative, the bitmap is a top-down DIB and its origin is the upper left corner.
		/// <para>
		/// A bitmap is packed when the bitmap array immediately follows the BITMAPINFO header. Packed bitmaps are referenced by a single
		/// pointer. For packed bitmaps, the biClrUsed member must be set to an even number when using the DIB_PAL_COLORS mode so that the
		/// DIB bitmap array starts on a DWORD boundary.
		/// </para>
		/// <para><c>Note</c></para>
		/// <para>
		/// The bmiColors member should not contain palette indexes if the bitmap is to be stored in a file or transferred to another application.
		/// </para>
		/// <para>
		/// Unless the application has exclusive use and control of the bitmap, the bitmap color table should contain explicit RGB values.
		/// </para>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183375")]
		public struct BITMAPINFO
		{
			/// <summary>A BITMAPINFOHEADER structure that contains information about the dimensions of color format.</summary>
			public BITMAPINFOHEADER bmiHeader;

			/// <summary>
			/// The bmiColors member contains one of the following:
			/// <list type="bullet">
			/// <item>
			/// <description>An array of RGBQUAD. The elements of the array that make up the color table.</description>
			/// </item>
			/// <item>
			/// <description>
			/// An array of 16-bit unsigned integers that specifies indexes into the currently realized logical palette. This use of
			/// bmiColors is allowed for functions that use DIBs. When bmiColors elements contain indexes to a realized logical palette,
			/// they must also call the following bitmap
			/// functions: CreateDIBitmap, CreateDIBPatternBrush, CreateDIBSection (The iUsage parameter of CreateDIBSection must be set to DIB_PAL_COLORS.)
			/// </description>
			/// </item>
			/// </list>
			/// <para>
			/// The number of entries in the array depends on the values of the biBitCount and biClrUsed members of the BITMAPINFOHEADER structure.
			/// </para>
			/// <para>The colors in the bmiColors table appear in order of importance. For more information, see the Remarks section.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public RGBQUAD[] bmiColors;

			/// <summary>Initializes a new instance of the <see cref="BITMAPINFO"/> structure.</summary>
			/// <param name="width">The width.</param>
			/// <param name="height">The height.</param>
			/// <param name="bitCount">The bit count.</param>
			public BITMAPINFO(int width, int height, ushort bitCount = 32)
				: this()
			{
				bmiHeader = new BITMAPINFOHEADER(width, height, bitCount);
			}

			/// <summary>Creates a <see cref="BITMAPINFO"/> structure from the information in a bitmap handle.</summary>
			/// <param name="hBmp">The handle to a bitmap.</param>
			/// <returns>
			/// A structure with all the information the bitmap handle. If the specified bitmap is less than 24bpp, this resulting structure
			/// must not be used without creating unmanaged memory to hold the structure and <c>BITMAPINFO.bmiHeader.biClrUsed *
			/// sizeof(RGBQUAD)</c> extra bytes.
			/// </returns>
			public static BITMAPINFO FromHBITMAP(in HBITMAP hBmp) => new() { bmiHeader = BITMAPINFOHEADER.FromHBITMAP(hBmp) };
		}

		/// <summary>
		/// <para>
		/// The <c>BITMAPINFOHEADER</c> structure contains information about the dimensions and color format of a device-independent bitmap (DIB).
		/// </para>
		/// <para>
		/// <c>Note</c> This structure is also described in the GDI documentation. However, the semantics for video data are slightly
		/// different than the semantics used for GDI. If you are using this structure to describe video data, use the information given here.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Color Tables</para>
		/// <para>
		/// The <c>BITMAPINFOHEADER</c> structure may be followed by an array of palette entries or color masks. The rules depend on the
		/// value of <c>biCompression</c>.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If <c>biCompression</c> equals <c>BI_RGB</c> and the bitmap uses 8 bpp or less, the bitmap has a color table immediatelly
		/// following the <c>BITMAPINFOHEADER</c> structure. The color table consists of an array of <c>RGBQUAD</c> values. The size of the
		/// array is given by the <c>biClrUsed</c> member. If <c>biClrUsed</c> is zero, the array contains the maximum number of colors for
		/// the given bitdepth; that is, 2^ <c>biBitCount</c> colors.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If <c>biCompression</c> equals <c>BI_BITFIELDS</c>, the bitmap uses three <c>DWORD</c> color masks (red, green, and blue,
		/// respectively), which specify the byte layout of the pixels. The 1 bits in each mask indicate the bits for that color within the pixel.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If <c>biCompression</c> is a video FOURCC, the presence of a color table is implied by the video format. You should not assume
		/// that a color table exists when the bit depth is 8 bpp or less. However, some legacy components might assume that a color table
		/// is present. Therefore, if you are allocating a <c>BITMAPINFOHEADER</c> structure, it is recommended to allocate space for a
		/// color table when the bit depth is 8 bpp or less, even if the color table is not used.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// When the <c>BITMAPINFOHEADER</c> is followed by a color table or a set of color masks, you can use the BITMAPINFO structure to
		/// reference the color table of the color masks. The <c>BITMAPINFO</c> structure is defined as follows:
		/// </para>
		/// <para>
		/// <code>typedef struct tagBITMAPINFO { BITMAPINFOHEADER bmiHeader; RGBQUAD bmiColors[1]; } BITMAPINFO;</code>
		/// </para>
		/// <para>
		/// If you cast the <c>BITMAPINFOHEADER</c> to a BITMAPINFO, the <c>bmiHeader</c> member refers to the <c>BITMAPINFOHEADER</c> and
		/// the <c>bmiColors</c> member refers to the first entry in the color table, or the first color mask.
		/// </para>
		/// <para>
		/// Be aware that if the bitmap uses a color table or color masks, then the size of the entire format structure (the
		/// <c>BITMAPINFOHEADER</c> plus the color information) is not equal to
		/// <code>sizeof(BITMAPINFOHEADER)</code>
		/// or
		/// <code>sizeof(BITMAPINFO)</code>
		/// . You must calculate the actual size for each instance.
		/// </para>
		/// <para>Calculating Surface Stride</para>
		/// <para>
		/// In an uncompressed bitmap, the stride is the number of bytes needed to go from the start of one row of pixels to the start of
		/// the next row. The image format defines a minimum stride for an image. In addition, the graphics hardware might require a larger
		/// stride for the surface that contains the image.
		/// </para>
		/// <para>
		/// For uncompressed RGB formats, the minimum stride is always the image width in bytes, rounded up to the nearest <c>DWORD</c>. You
		/// can use the following formula to calculate the stride:
		/// </para>
		/// <para>
		/// <code>stride = ((((biWidth * biBitCount) + 31) &amp; ~31) &gt;&gt; 3)</code>
		/// </para>
		/// <para>
		/// For YUV formats, there is no general rule for calculating the minimum stride. You must understand the rules for the particular
		/// YUV format. For a description of the most common YUV formats, see Recommended 8-Bit YUV Formats for Video Rendering.
		/// </para>
		/// <para>
		/// Decoders and video sources should propose formats where biWidth is the width of the image in pixels. If the video renderer
		/// requires a surface stride that is larger than the default image stride, it modifies the proposed media type by setting the
		/// following values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>It sets <c>biWidth</c> equal to the surface stride in pixels.</term>
		/// </item>
		/// <item>
		/// <term>It sets the <c>rcTarget</c> member of the VIDEOINFOHEADER or VIDEOINFOHEADER2 structure equal to the image width, in pixels.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Then the video renderer proposes the modified format by calling IPin::QueryAccept on the upstream pin. For more information
		/// about this mechanism, see Dynamic Format Changes.
		/// </para>
		/// <para>
		/// If there is padding in the image buffer, never dereference a pointer into the memory that has been reserved for the padding. If
		/// the image buffer has been allocated in video memory, the padding might not be readable memory.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-bitmapinfoheader typedef struct tagBITMAPINFOHEADER { DWORD
		// biSize; LONG biWidth; LONG biHeight; WORD biPlanes; WORD biBitCount; DWORD biCompression; DWORD biSizeImage; LONG
		// biXPelsPerMeter; LONG biYPelsPerMeter; DWORD biClrUsed; DWORD biClrImportant; } BITMAPINFOHEADER, *LPBITMAPINFOHEADER, *PBITMAPINFOHEADER;
		[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.tagBITMAPINFOHEADER")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct BITMAPINFOHEADER
		{
			/// <summary>
			/// Specifies the number of bytes required by the structure. This value does not include the size of the color table or the size
			/// of the color masks, if they are appended to the end of structure. See Remarks.
			/// </summary>
			public uint biSize;

			/// <summary>
			/// Specifies the width of the bitmap, in pixels. For information about calculating the stride of the bitmap, see Remarks.
			/// </summary>
			public int biWidth;

			/// <summary>
			/// <para>Specifies the height of the bitmap, in pixels.</para>
			/// <list type="bullet">
			/// <item>
			/// <term>
			/// For uncompressed RGB bitmaps, if <c>biHeight</c> is positive, the bitmap is a bottom-up DIB with the origin at the lower
			/// left corner. If <c>biHeight</c> is negative, the bitmap is a top-down DIB with the origin at the upper left corner.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// For YUV bitmaps, the bitmap is always top-down, regardless of the sign of <c>biHeight</c>. Decoders should offer YUV formats
			/// with postive <c>biHeight</c>, but for backward compatibility they should accept YUV formats with either positive or negative <c>biHeight</c>.
			/// </term>
			/// </item>
			/// <item>
			/// <term>For compressed formats, <c>biHeight</c> must be positive, regardless of image orientation.</term>
			/// </item>
			/// </list>
			/// </summary>
			public int biHeight;

			/// <summary>Specifies the number of planes for the target device. This value must be set to 1.</summary>
			public ushort biPlanes;

			/// <summary>
			/// Specifies the number of bits per pixel (bpp). For uncompressed formats, this value is the average number of bits per pixel.
			/// For compressed formats, this value is the implied bit depth of the uncompressed image, after the image has been decoded.
			/// </summary>
			public ushort biBitCount;

			/// <summary>
			/// <para>
			/// For compressed video and YUV formats, this member is a FOURCC code, specified as a <c>DWORD</c> in little-endian order. For
			/// example, YUYV video has the FOURCC 'VYUY' or 0x56595559. For more information, see FOURCC Codes.
			/// </para>
			/// <para>For uncompressed RGB formats, the following values are possible:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>BI_RGB</term>
			/// <term>Uncompressed RGB.</term>
			/// </item>
			/// <item>
			/// <term>BI_BITFIELDS</term>
			/// <term>Uncompressed RGB with color masks. Valid for 16-bpp and 32-bpp bitmaps.</term>
			/// </item>
			/// </list>
			/// <para>See Remarks for more information. Note that <c>BI_JPG</c> and <c>BI_PNG</c> are not valid video formats.</para>
			/// <para>
			/// For 16-bpp bitmaps, if <c>biCompression</c> equals <c>BI_RGB</c>, the format is always RGB 555. If <c>biCompression</c>
			/// equals <c>BI_BITFIELDS</c>, the format is either RGB 555 or RGB 565. Use the subtype GUID in the AM_MEDIA_TYPE structure to
			/// determine the specific RGB type.
			/// </para>
			/// </summary>
			public BitmapCompressionMode biCompression;

			/// <summary>Specifies the size, in bytes, of the image. This can be set to 0 for uncompressed RGB bitmaps.</summary>
			public uint biSizeImage;

			/// <summary>Specifies the horizontal resolution, in pixels per meter, of the target device for the bitmap.</summary>
			public int biXPelsPerMeter;

			/// <summary>Specifies the vertical resolution, in pixels per meter, of the target device for the bitmap.</summary>
			public int biYPelsPerMeter;

			/// <summary>
			/// Specifies the number of color indices in the color table that are actually used by the bitmap. See Remarks for more information.
			/// </summary>
			public uint biClrUsed;

			/// <summary>
			/// Specifies the number of color indices that are considered important for displaying the bitmap. If this value is zero, all
			/// colors are important.
			/// </summary>
			public uint biClrImportant;

			/// <summary>Initializes a new instance of the <see cref="BITMAPINFOHEADER"/> structure.</summary>
			/// <param name="width">The width.</param>
			/// <param name="height">The height.</param>
			/// <param name="bitCount">The bit count.</param>
			public BITMAPINFOHEADER(int width, int height, ushort bitCount = 32)
				: this()
			{
				biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFO));
				biWidth = width;
				biHeight = height;
				biPlanes = 1;
				biBitCount = bitCount;
				biCompression = BitmapCompressionMode.BI_RGB;
				biSizeImage = 0; // (uint)width * (uint)height * bitCount / 8;
			}

			/// <summary>Creates a <see cref="BITMAPINFOHEADER"/> structure from the information in a bitmap handle.</summary>
			/// <param name="hBmp">The handle to a bitmap.</param>
			/// <returns>
			/// A structure with all the information the bitmap handle. If the specified bitmap is less than 24bpp, the <see
			/// cref="biClrUsed"/> value is set to the number of <see cref="RGBQUAD"/> structures that must be allocated.
			/// </returns>
			public static BITMAPINFOHEADER FromHBITMAP(in HBITMAP hBmp)
			{
				// Retrieve the bitmap color format, width, and height.
				var bmp = GetObject<BITMAP>(hBmp);

				// Convert the color format to a count of bits.
				var cClrBits = (ushort)(bmp.bmPlanes * bmp.bmBitsPixel) switch
				{
					1 => 1,
					<= 4 => 4,
					<= 8 => 8,
					<= 16 => 16,
					<= 24 => 24,
					_ => 32,
				};

				// Initialize the fields in the BITMAPINFO structure.
				return new()
				{
					biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER)),
					biWidth = bmp.bmWidth,
					biHeight = bmp.bmHeight,
					biPlanes = bmp.bmPlanes,
					biBitCount = bmp.bmBitsPixel,
					// This value is correct, but there is no memory alllocated to hold these bits
					biClrUsed = cClrBits < 24 ? 1U << cClrBits : 0,
					// If the bitmap is not compressed, set the BI_RGB flag.
					biCompression = BitmapCompressionMode.BI_RGB,
					// Compute the number of bytes in the array of color indices and store the result in biSizeImage. The width must be uint
					// aligned unless the bitmap is RLE compressed.
					biSizeImage = (uint)(((bmp.bmWidth * cClrBits + 31) & ~31) / 8 * bmp.bmHeight),
					// Set biClrImportant to 0, indicating that all of the device colors are important.
					biClrImportant = 0
				};
			}

			/// <summary>Gets the default value for this structure with size fields set appropriately.</summary>
			public static readonly BITMAPINFOHEADER Default = new() { biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER)) };
		}

		/// <summary>
		/// <para>
		/// The <c>BITMAPV4HEADER</c> structure is the bitmap information header file. It is an extended version of the BITMAPINFOHEADER structure.
		/// </para>
		/// <para>Applications can use the BITMAPV5HEADER structure for added functionality.</para>
		/// </summary>
		/// <remarks>
		/// The <c>BITMAPV4HEADER</c> structure is extended to allow a JPEG or PNG image to be passed as the source image to StretchDIBits.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-bitmapv4header typedef struct { DWORD bV4Size; LONG bV4Width;
		// LONG bV4Height; WORD bV4Planes; WORD bV4BitCount; DWORD bV4V4Compression; DWORD bV4SizeImage; LONG bV4XPelsPerMeter; LONG
		// bV4YPelsPerMeter; DWORD bV4ClrUsed; DWORD bV4ClrImportant; DWORD bV4RedMask; DWORD bV4GreenMask; DWORD bV4BlueMask; DWORD
		// bV4AlphaMask; DWORD bV4CSType; CIEXYZTRIPLE bV4Endpoints; DWORD bV4GammaRed; DWORD bV4GammaGreen; DWORD bV4GammaBlue; }
		// BITMAPV4HEADER, *LPBITMAPV4HEADER, *PBITMAPV4HEADER;
		[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.__unnamed_struct_0")]
		[StructLayout(LayoutKind.Sequential)]
		public struct BITMAPV4HEADER
		{
			/// <summary>
			/// The number of bytes required by the structure. Applications should use this member to determine which bitmap information
			/// header structure is being used.
			/// </summary>
			public uint bV4Size;

			/// <summary>
			/// <para>The width of the bitmap, in pixels.</para>
			/// <para>If <c>bV4Compression</c> is BI_JPEG or BI_PNG, <c>bV4Width</c> specifies the width of the JPEG or PNG image in pixels.</para>
			/// </summary>
			public int bV4Width;

			/// <summary>
			/// <para>
			/// The height of the bitmap, in pixels. If <c>bV4Height</c> is positive, the bitmap is a bottom-up DIB and its origin is the
			/// lower-left corner. If <c>bV4Height</c> is negative, the bitmap is a top-down DIB and its origin is the upper-left corner.
			/// </para>
			/// <para>
			/// If <c>bV4Height</c> is negative, indicating a top-down DIB, <c>bV4Compression</c> must be either BI_RGB or BI_BITFIELDS.
			/// Top-down DIBs cannot be compressed.
			/// </para>
			/// <para>If <c>bV4Compression</c> is BI_JPEG or BI_PNG, <c>bV4Height</c> specifies the height of the JPEG or PNG image in pixels.</para>
			/// </summary>
			public int bV4Height;

			/// <summary>The number of planes for the target device. This value must be set to 1.</summary>
			public ushort bV4Planes;

			/// <summary>
			/// <para>
			/// The number of bits-per-pixel. The <c>bV4BitCount</c> member of the <c>BITMAPV4HEADER</c> structure determines the number of
			/// bits that define each pixel and the maximum number of colors in the bitmap. This member must be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>The number of bits-per-pixel is specified or is implied by the JPEG or PNG file format.</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>
			/// The bitmap is monochrome, and the bmiColors member of BITMAPINFO contains two entries. Each bit in the bitmap array
			/// represents a pixel. If the bit is clear, the pixel is displayed with the color of the first entry in the bmiColors table; if
			/// the bit is set, the pixel has the color of the second entry in the table.
			/// </term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>
			/// The bitmap has a maximum of 16 colors, and the bmiColors member of BITMAPINFO contains up to 16 entries. Each pixel in the
			/// bitmap is represented by a 4-bit index into the color table. For example, if the first byte in the bitmap is 0x1F, the byte
			/// represents two pixels. The first pixel contains the color in the second table entry, and the second pixel contains the color
			/// in the sixteenth table entry.
			/// </term>
			/// </item>
			/// <item>
			/// <term>8</term>
			/// <term>
			/// The bitmap has a maximum of 256 colors, and the bmiColors member of BITMAPINFO contains up to 256 entries. In this case,
			/// each byte in the array represents a single pixel.
			/// </term>
			/// </item>
			/// <item>
			/// <term>16</term>
			/// <term>
			/// The bitmap has a maximum of 2^16 colors. If the bV4Compression member of the BITMAPV4HEADER structure is BI_RGB, the
			/// bmiColors member of BITMAPINFO is NULL. Each WORD in the bitmap array represents a single pixel. The relative intensities of
			/// red, green, and blue are represented with five bits for each color component. The value for blue is in the least significant
			/// five bits, followed by five bits each for green and red, respectively. The most significant bit is not used. The bmiColors
			/// color table is used for optimizing colors used on palette-based devices, and must contain the number of entries specified by
			/// the bV4ClrUsed member of the BITMAPV4HEADER.If the bV4Compression member of the BITMAPV4HEADER is BI_BITFIELDS, the
			/// bmiColors member contains three DWORD color masks that specify the red, green, and blue components of each pixel. Each WORD
			/// in the bitmap array represents a single pixel.
			/// </term>
			/// </item>
			/// <item>
			/// <term>24</term>
			/// <term>
			/// The bitmap has a maximum of 2^24 colors, and the bmiColors member of BITMAPINFO is NULL. Each 3-byte triplet in the bitmap
			/// array represents the relative intensities of blue, green, and red for a pixel. The bmiColors color table is used for
			/// optimizing colors used on palette-based devices, and must contain the number of entries specified by the bV4ClrUsed member
			/// of the BITMAPV4HEADER.
			/// </term>
			/// </item>
			/// <item>
			/// <term>32</term>
			/// <term>
			/// The bitmap has a maximum of 2^32 colors. If the bV4Compression member of the BITMAPV4HEADER is BI_RGB, the bmiColors member
			/// of BITMAPINFO is NULL. Each DWORD in the bitmap array represents the relative intensities of blue, green, and red for a
			/// pixel. The value for blue is in the least significant 8 bits, followed by 8 bits each for green and red. The high byte in
			/// each DWORD is not used. The bmiColors color table is used for optimizing colors used on palette-based devices, and must
			/// contain the number of entries specified by the bV4ClrUsed member of the BITMAPV4HEADER.If the bV4Compression member of the
			/// BITMAPV4HEADER is BI_BITFIELDS, the bmiColors member contains three DWORD color masks that specify the red, green, and blue
			/// components of each pixel. Each DWORD in the bitmap array represents a single pixel.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort bV4BitCount;

			/// <summary>
			/// <para>
			/// The type of compression for a compressed bottom-up bitmap (top-down DIBs cannot be compressed). This member can be one of
			/// the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>BI_RGB</term>
			/// <term>An uncompressed format.</term>
			/// </item>
			/// <item>
			/// <term>BI_RLE8</term>
			/// <term>
			/// A run-length encoded (RLE) format for bitmaps with 8 bpp. The compression format is a 2-byte format consisting of a count
			/// byte followed by a byte containing a color index. For more information, see Bitmap Compression.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BI_RLE4</term>
			/// <term>
			/// An RLE format for bitmaps with 4 bpp. The compression format is a 2-byte format consisting of a count byte followed by two
			/// word-length color indexes. For more information, see Bitmap Compression.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BI_BITFIELDS</term>
			/// <term>
			/// Specifies that the bitmap is not compressed. The members bV4RedMask, bV4GreenMask, and bV4BlueMask specify the red, green,
			/// and blue components for each pixel. This is valid when used with 16- and 32-bpp bitmaps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BI_JPEG</term>
			/// <term>
			/// Specifies that the image is compressed using the JPEG file interchange format. JPEG compression trades off compression
			/// against loss; it can achieve a compression ratio of 20:1 with little noticeable loss.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BI_PNG</term>
			/// <term>Specifies that the image is compressed using the PNG file interchange format.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint bV4V4Compression;

			/// <summary>
			/// <para>The size, in bytes, of the image. This may be set to zero for BI_RGB bitmaps.</para>
			/// <para>If <c>bV4Compression</c> is BI_JPEG or BI_PNG, <c>bV4SizeImage</c> is the size of the JPEG or PNG image buffer.</para>
			/// </summary>
			public uint bV4SizeImage;

			/// <summary>
			/// The horizontal resolution, in pixels-per-meter, of the target device for the bitmap. An application can use this value to
			/// select a bitmap from a resource group that best matches the characteristics of the current device.
			/// </summary>
			public int bV4XPelsPerMeter;

			/// <summary>The vertical resolution, in pixels-per-meter, of the target device for the bitmap.</summary>
			public int bV4YPelsPerMeter;

			/// <summary>
			/// <para>
			/// The number of color indexes in the color table that are actually used by the bitmap. If this value is zero, the bitmap uses
			/// the maximum number of colors corresponding to the value of the <c>bV4BitCount</c> member for the compression mode specified
			/// by <c>bV4Compression</c>.
			/// </para>
			/// <para>
			/// If <c>bV4ClrUsed</c> is nonzero and the <c>bV4BitCount</c> member is less than 16, the <c>bV4ClrUsed</c> member specifies
			/// the actual number of colors the graphics engine or device driver accesses. If <c>bV4BitCount</c> is 16 or greater, the
			/// <c>bV4ClrUsed</c> member specifies the size of the color table used to optimize performance of the system color palettes. If
			/// <c>bV4BitCount</c> equals 16 or 32, the optimal color palette starts immediately following the <c>BITMAPV4HEADER</c>.
			/// </para>
			/// </summary>
			public uint bV4ClrUsed;

			/// <summary>
			/// The number of color indexes that are required for displaying the bitmap. If this value is zero, all colors are important.
			/// </summary>
			public uint bV4ClrImportant;

			/// <summary>Color mask that specifies the red component of each pixel, valid only if <c>bV4Compression</c> is set to BI_BITFIELDS.</summary>
			public uint bV4RedMask;

			/// <summary>Color mask that specifies the green component of each pixel, valid only if <c>bV4Compression</c> is set to BI_BITFIELDS.</summary>
			public uint bV4GreenMask;

			/// <summary>Color mask that specifies the blue component of each pixel, valid only if <c>bV4Compression</c> is set to BI_BITFIELDS.</summary>
			public uint bV4BlueMask;

			/// <summary>Color mask that specifies the alpha component of each pixel.</summary>
			public uint bV4AlphaMask;

			/// <summary>
			/// <para>The color space of the DIB. The following table lists the value for <c>bV4CSType</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>LCS_CALIBRATED_RGB</term>
			/// <term>This value indicates that endpoints and gamma values are given in the appropriate fields.</term>
			/// </item>
			/// </list>
			/// <para>See the LOGCOLORSPACE structure for information that defines a logical color space.</para>
			/// </summary>
			public uint bV4CSType;

			/// <summary>
			/// <para>
			/// A CIEXYZTRIPLE structure that specifies the x, y, and z coordinates of the three colors that correspond to the red, green,
			/// and blue endpoints for the logical color space associated with the bitmap. This member is ignored unless the
			/// <c>bV4CSType</c> member specifies LCS_CALIBRATED_RGB.
			/// </para>
			/// <para>
			/// <c>Note</c> A color space is a model for representing color numerically in terms of three or more coordinates. For example,
			/// the RGB color space represents colors in terms of the red, green, and blue coordinates.
			/// </para>
			/// </summary>
			public CIEXYZTRIPLE bV4Endpoints;

			/// <summary>
			/// Tone response curve for red. This member is ignored unless color values are calibrated RGB values and <c>bV4CSType</c> is
			/// set to LCS_CALIBRATED_RGB. Specify in unsigned fixed 16.16 format. The upper 16 bits are the unsigned integer value. The
			/// lower 16 bits are the fractional part.
			/// </summary>
			public uint bV4GammaRed;

			/// <summary>
			/// Tone response curve for green. Used if <c>bV4CSType</c> is set to LCS_CALIBRATED_RGB. Specify in unsigned fixed 16.16
			/// format. The upper 16 bits are the unsigned integer value. The lower 16 bits are the fractional part.
			/// </summary>
			public uint bV4GammaGreen;

			/// <summary>
			/// Tone response curve for blue. Used if <c>bV4CSType</c> is set to LCS_CALIBRATED_RGB. Specify in unsigned fixed 16.16 format.
			/// The upper 16 bits are the unsigned integer value. The lower 16 bits are the fractional part.
			/// </summary>
			public uint bV4GammaBlue;
		}

		/// <summary>
		/// The <c>BITMAPV5HEADER</c> structure is the bitmap information header file. It is an extended version of the BITMAPINFOHEADER structure.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If <c>bV5Height</c> is negative, indicating a top-down DIB, <c>bV5Compression</c> must be either BI_RGB or BI_BITFIELDS.
		/// Top-down DIBs cannot be compressed.
		/// </para>
		/// <para>
		/// The Independent Color Management interface (ICM) 2.0 allows International Color Consortium (ICC) color profiles to be linked or
		/// embedded in DIBs (DIBs). See Using Structures for more information.
		/// </para>
		/// <para>
		/// When a DIB is loaded into memory, the profile data (if present) should follow the color table, and the <c>bV5ProfileData</c>
		/// should provide the offset of the profile data from the beginning of the <c>BITMAPV5HEADER</c> structure. The value stored in
		/// <c>bV5ProfileData</c> will be different from the value returned by the <c>sizeof</c> operator given the <c>BITMAPV5HEADER</c>
		/// argument, because <c>bV5ProfileData</c> is the offset in bytes from the beginning of the <c>BITMAPV5HEADER</c> structure to the
		/// start of the profile data. (Bitmap bits do not follow the color table in memory). Applications should modify the
		/// <c>bV5ProfileData</c> member after loading the DIB into memory.
		/// </para>
		/// <para>
		/// For packed DIBs, the profile data should follow the bitmap bits similar to the file format. The <c>bV5ProfileData</c> member
		/// should still give the offset of the profile data from the beginning of the <c>BITMAPV5HEADER</c>.
		/// </para>
		/// <para>
		/// Applications should access the profile data only when <c>bV5Size</c> equals the size of the <c>BITMAPV5HEADER</c> and
		/// <c>bV5CSType</c> equals PROFILE_EMBEDDED or PROFILE_LINKED.
		/// </para>
		/// <para>
		/// If a profile is linked, the path of the profile can be any fully qualified name (including a network path) that can be opened
		/// using the CreateFile function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-bitmapv5header typedef struct { DWORD bV5Size; LONG bV5Width;
		// LONG bV5Height; WORD bV5Planes; WORD bV5BitCount; DWORD bV5Compression; DWORD bV5SizeImage; LONG bV5XPelsPerMeter; LONG
		// bV5YPelsPerMeter; DWORD bV5ClrUsed; DWORD bV5ClrImportant; DWORD bV5RedMask; DWORD bV5GreenMask; DWORD bV5BlueMask; DWORD
		// bV5AlphaMask; DWORD bV5CSType; CIEXYZTRIPLE bV5Endpoints; DWORD bV5GammaRed; DWORD bV5GammaGreen; DWORD bV5GammaBlue; DWORD
		// bV5Intent; DWORD bV5ProfileData; DWORD bV5ProfileSize; DWORD bV5Reserved; } BITMAPV5HEADER, *LPBITMAPV5HEADER, *PBITMAPV5HEADER;
		[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.__unnamed_struct_1")]
		[StructLayout(LayoutKind.Sequential)]
		public struct BITMAPV5HEADER
		{
			/// <summary>
			/// The number of bytes required by the structure. Applications should use this member to determine which bitmap information
			/// header structure is being used.
			/// </summary>
			public uint bV5Size;

			/// <summary>
			/// <para>The width of the bitmap, in pixels.</para>
			/// <para>
			/// If <c>bV5Compression</c> is BI_JPEG or BI_PNG, the <c>bV5Width</c> member specifies the width of the decompressed JPEG or
			/// PNG image in pixels.
			/// </para>
			/// </summary>
			public int bV5Width;

			/// <summary>
			/// <para>
			/// The height of the bitmap, in pixels. If the value of <c>bV5Height</c> is positive, the bitmap is a bottom-up DIB and its
			/// origin is the lower-left corner. If <c>bV5Height</c> value is negative, the bitmap is a top-down DIB and its origin is the
			/// upper-left corner.
			/// </para>
			/// <para>
			/// If <c>bV5Height</c> is negative, indicating a top-down DIB, <c>bV5Compression</c> must be either BI_RGB or BI_BITFIELDS.
			/// Top-down DIBs cannot be compressed.
			/// </para>
			/// <para>
			/// If <c>bV5Compression</c> is BI_JPEG or BI_PNG, the <c>bV5Height</c> member specifies the height of the decompressed JPEG or
			/// PNG image in pixels.
			/// </para>
			/// </summary>
			public int bV5Height;

			/// <summary>The number of planes for the target device. This value must be set to 1.</summary>
			public ushort bV5Planes;

			/// <summary>
			/// <para>The number of bits that define each pixel and the maximum number of colors in the bitmap.</para>
			/// <para>This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>The number of bits per pixel is specified or is implied by the JPEG or PNG file format.</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>
			/// The bitmap is monochrome, and the bmiColors member of BITMAPINFO contains two entries. Each bit in the bitmap array
			/// represents a pixel. If the bit is clear, the pixel is displayed with the color of the first entry in the bmiColors color
			/// table. If the bit is set, the pixel has the color of the second entry in the table.
			/// </term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>
			/// The bitmap has a maximum of 16 colors, and the bmiColors member of BITMAPINFO contains up to 16 entries. Each pixel in the
			/// bitmap is represented by a 4-bit index into the color table. For example, if the first byte in the bitmap is 0x1F, the byte
			/// represents two pixels. The first pixel contains the color in the second table entry, and the second pixel contains the color
			/// in the sixteenth table entry.
			/// </term>
			/// </item>
			/// <item>
			/// <term>8</term>
			/// <term>
			/// The bitmap has a maximum of 256 colors, and the bmiColors member of BITMAPINFO contains up to 256 entries. In this case,
			/// each byte in the array represents a single pixel.
			/// </term>
			/// </item>
			/// <item>
			/// <term>16</term>
			/// <term>
			/// The bitmap has a maximum of 2^16 colors. If the bV5Compression member of the BITMAPV5HEADER structure is BI_RGB, the
			/// bmiColors member of BITMAPINFO is NULL. Each WORD in the bitmap array represents a single pixel. The relative intensities of
			/// red, green, and blue are represented with five bits for each color component. The value for blue is in the least significant
			/// five bits, followed by five bits each for green and red. The most significant bit is not used. The bmiColors color table is
			/// used for optimizing colors used on palette-based devices, and must contain the number of entries specified by the bV5ClrUsed
			/// member of the BITMAPV5HEADER.If the bV5Compression member of the BITMAPV5HEADER is BI_BITFIELDS, the bmiColors member
			/// contains three DWORD color masks that specify the red, green, and blue components, respectively, of each pixel. Each WORD in
			/// the bitmap array represents a single pixel. When the bV5Compression member is BI_BITFIELDS, bits set in each DWORD mask must
			/// be contiguous and should not overlap the bits of another mask. All the bits in the pixel do not need to be used.
			/// </term>
			/// </item>
			/// <item>
			/// <term>24</term>
			/// <term>
			/// The bitmap has a maximum of 2^24 colors, and the bmiColors member of BITMAPINFO is NULL. Each 3-byte triplet in the bitmap
			/// array represents the relative intensities of blue, green, and red, respectively, for a pixel. The bmiColors color table is
			/// used for optimizing colors used on palette-based devices, and must contain the number of entries specified by the bV5ClrUsed
			/// member of the BITMAPV5HEADER structure.
			/// </term>
			/// </item>
			/// <item>
			/// <term>32</term>
			/// <term>
			/// The bitmap has a maximum of 2^32 colors. If the bV5Compression member of the BITMAPV5HEADER is BI_RGB, the bmiColors member
			/// of BITMAPINFO is NULL. Each DWORD in the bitmap array represents the relative intensities of blue, green, and red for a
			/// pixel. The value for blue is in the least significant 8 bits, followed by 8 bits each for green and red. The high byte in
			/// each DWORD is not used. The bmiColors color table is used for optimizing colors used on palette-based devices, and must
			/// contain the number of entries specified by the bV5ClrUsed member of the BITMAPV5HEADER.If the bV5Compression member of the
			/// BITMAPV5HEADER is BI_BITFIELDS, the bmiColors member contains three DWORD color masks that specify the red, green, and blue
			/// components of each pixel. Each DWORD in the bitmap array represents a single pixel.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort bV5BitCount;

			/// <summary>
			/// <para>
			/// Specifies that the bitmap is not compressed. The <c>bV5RedMask</c>, <c>bV5GreenMask</c>, and <c>bV5BlueMask</c> members
			/// specify the red, green, and blue components of each pixel. This is valid when used with 16- and 32-bpp bitmaps. This member
			/// can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>BI_RGB</term>
			/// <term>An uncompressed format.</term>
			/// </item>
			/// <item>
			/// <term>BI_RLE8</term>
			/// <term>
			/// A run-length encoded (RLE) format for bitmaps with 8 bpp. The compression format is a two-byte format consisting of a count
			/// byte followed by a byte containing a color index. If bV5Compression is BI_RGB and the bV5BitCount member is 16, 24, or 32,
			/// the bitmap array specifies the actual intensities of blue, green, and red rather than using color table indexes. For more
			/// information, see Bitmap Compression.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BI_RLE4</term>
			/// <term>
			/// An RLE format for bitmaps with 4 bpp. The compression format is a two-byte format consisting of a count byte followed by two
			/// word-length color indexes. For more information, see Bitmap Compression.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BI_BITFIELDS</term>
			/// <term>
			/// Specifies that the bitmap is not compressed and that the color masks for the red, green, and blue components of each pixel
			/// are specified in the bV5RedMask, bV5GreenMask, and bV5BlueMask members. This is valid when used with 16- and 32-bpp bitmaps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BI_JPEG</term>
			/// <term>
			/// Specifies that the image is compressed using the JPEG file Interchange Format. JPEG compression trades off compression
			/// against loss; it can achieve a compression ratio of 20:1 with little noticeable loss.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BI_PNG</term>
			/// <term>Specifies that the image is compressed using the PNG file Interchange Format.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint bV5Compression;

			/// <summary>
			/// <para>The size, in bytes, of the image. This may be set to zero for BI_RGB bitmaps.</para>
			/// <para>If <c>bV5Compression</c> is BI_JPEG or BI_PNG, <c>bV5SizeImage</c> is the size of the JPEG or PNG image buffer.</para>
			/// </summary>
			public uint bV5SizeImage;

			/// <summary>
			/// The horizontal resolution, in pixels-per-meter, of the target device for the bitmap. An application can use this value to
			/// select a bitmap from a resource group that best matches the characteristics of the current device.
			/// </summary>
			public int bV5XPelsPerMeter;

			/// <summary>The vertical resolution, in pixels-per-meter, of the target device for the bitmap.</summary>
			public int bV5YPelsPerMeter;

			/// <summary>
			/// <para>
			/// The number of color indexes in the color table that are actually used by the bitmap. If this value is zero, the bitmap uses
			/// the maximum number of colors corresponding to the value of the <c>bV5BitCount</c> member for the compression mode specified
			/// by <c>bV5Compression</c>.
			/// </para>
			/// <para>
			/// If <c>bV5ClrUsed</c> is nonzero and <c>bV5BitCount</c> is less than 16, the <c>bV5ClrUsed</c> member specifies the actual
			/// number of colors the graphics engine or device driver accesses. If <c>bV5BitCount</c> is 16 or greater, the
			/// <c>bV5ClrUsed</c> member specifies the size of the color table used to optimize performance of the system color palettes. If
			/// <c>bV5BitCount</c> equals 16 or 32, the optimal color palette starts immediately following the <c>BITMAPV5HEADER</c>. If
			/// <c>bV5ClrUsed</c> is nonzero, the color table is used on palettized devices, and <c>bV5ClrUsed</c> specifies the number of entries.
			/// </para>
			/// </summary>
			public uint bV5ClrUsed;

			/// <summary>
			/// The number of color indexes that are required for displaying the bitmap. If this value is zero, all colors are required.
			/// </summary>
			public uint bV5ClrImportant;

			/// <summary>Color mask that specifies the red component of each pixel, valid only if <c>bV5Compression</c> is set to BI_BITFIELDS.</summary>
			public uint bV5RedMask;

			/// <summary>Color mask that specifies the green component of each pixel, valid only if <c>bV5Compression</c> is set to BI_BITFIELDS.</summary>
			public uint bV5GreenMask;

			/// <summary>Color mask that specifies the blue component of each pixel, valid only if <c>bV5Compression</c> is set to BI_BITFIELDS.</summary>
			public uint bV5BlueMask;

			/// <summary>Color mask that specifies the alpha component of each pixel.</summary>
			public uint bV5AlphaMask;

			/// <summary>
			/// <para>The color space of the DIB.</para>
			/// <para>The following table specifies the values for <c>bV5CSType</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>LCS_CALIBRATED_RGB</term>
			/// <term>This value implies that endpoints and gamma values are given in the appropriate fields.</term>
			/// </item>
			/// <item>
			/// <term>LCS_sRGB</term>
			/// <term>Specifies that the bitmap is in sRGB color space.</term>
			/// </item>
			/// <item>
			/// <term>LCS_WINDOWS_COLOR_SPACE</term>
			/// <term>This value indicates that the bitmap is in the system default color space, sRGB.</term>
			/// </item>
			/// <item>
			/// <term>PROFILE_LINKED</term>
			/// <term>
			/// This value indicates that bV5ProfileData points to the file name of the profile to use (gamma and endpoints values are ignored).
			/// </term>
			/// </item>
			/// <item>
			/// <term>PROFILE_EMBEDDED</term>
			/// <term>
			/// This value indicates that bV5ProfileData points to a memory buffer that contains the profile to be used (gamma and endpoints
			/// values are ignored).
			/// </term>
			/// </item>
			/// </list>
			/// <para>See the LOGCOLORSPACE structure for information that defines a logical color space.</para>
			/// </summary>
			public uint bV5CSType;

			/// <summary>
			/// A CIEXYZTRIPLE structure that specifies the x, y, and z coordinates of the three colors that correspond to the red, green,
			/// and blue endpoints for the logical color space associated with the bitmap. This member is ignored unless the
			/// <c>bV5CSType</c> member specifies LCS_CALIBRATED_RGB.
			/// </summary>
			public CIEXYZTRIPLE bV5Endpoints;

			/// <summary>
			/// Toned response curve for red. Used if <c>bV5CSType</c> is set to LCS_CALIBRATED_RGB. Specify in unsigned fixed 16.16 format.
			/// The upper 16 bits are the unsigned integer value. The lower 16 bits are the fractional part.
			/// </summary>
			public uint bV5GammaRed;

			/// <summary>
			/// Toned response curve for green. Used if <c>bV5CSType</c> is set to LCS_CALIBRATED_RGB. Specify in unsigned fixed 16.16
			/// format. The upper 16 bits are the unsigned integer value. The lower 16 bits are the fractional part.
			/// </summary>
			public uint bV5GammaGreen;

			/// <summary>
			/// Toned response curve for blue. Used if <c>bV5CSType</c> is set to LCS_CALIBRATED_RGB. Specify in unsigned fixed 16.16
			/// format. The upper 16 bits are the unsigned integer value. The lower 16 bits are the fractional part.
			/// </summary>
			public uint bV5GammaBlue;

			/// <summary>
			/// <para>Rendering intent for bitmap. This can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Intent</term>
			/// <term>ICC name</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>LCS_GM_ABS_COLORIMETRIC</term>
			/// <term>Match</term>
			/// <term>Absolute Colorimetric</term>
			/// <term>Maintains the white point. Matches the colors to their nearest color in the destination gamut.</term>
			/// </item>
			/// <item>
			/// <term>LCS_GM_BUSINESS</term>
			/// <term>Graphic</term>
			/// <term>Saturation</term>
			/// <term>Maintains saturation. Used for business charts and other situations in which undithered colors are required.</term>
			/// </item>
			/// <item>
			/// <term>LCS_GM_GRAPHICS</term>
			/// <term>Proof</term>
			/// <term>Relative Colorimetric</term>
			/// <term>Maintains colorimetric match. Used for graphic designs and named colors.</term>
			/// </item>
			/// <item>
			/// <term>LCS_GM_IMAGES</term>
			/// <term>Picture</term>
			/// <term>Perceptual</term>
			/// <term>Maintains contrast. Used for photographs and natural images.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint bV5Intent;

			/// <summary>
			/// The offset, in bytes, from the beginning of the <c>BITMAPV5HEADER</c> structure to the start of the profile data. If the
			/// profile is embedded, profile data is the actual profile, and it is linked. (The profile data is the null-terminated file
			/// name of the profile.) This cannot be a Unicode string. It must be composed exclusively of characters from the Windows
			/// character set (code page 1252). These profile members are ignored unless the <c>bV5CSType</c> member specifies
			/// PROFILE_LINKED or PROFILE_EMBEDDED.
			/// </summary>
			public uint bV5ProfileData;

			/// <summary>Size, in bytes, of embedded profile data.</summary>
			public uint bV5ProfileSize;

			/// <summary>This member has been reserved. Its value should be set to zero.</summary>
			public uint bV5Reserved;
		}

		/// <summary>
		/// The DIBSECTION structure contains information about a DIB created by calling the CreateDIBSection function. A DIBSECTION
		/// structure includes information about the bitmap's dimensions, color format, color masks, optional file mapping object, and
		/// optional bit values storage offset. An application can obtain a filled-in DIBSECTION structure for a given DIB by calling the
		/// GetObject function.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183567")]
		public struct DIBSECTION
		{
			/// <summary>
			/// A BITMAP data structure that contains information about the DIB: its type, its dimensions, its color capacities, and a
			/// pointer to its bit values.
			/// </summary>
			public BITMAP dsBm;

			/// <summary>A BITMAPINFOHEADER structure that contains information about the color format of the DIB.</summary>
			public BITMAPINFOHEADER dsBmih;

			private uint dsBitField1;
			private uint dsBitField2;
			private uint dsBitField3;

			/// <summary>
			/// The DSH sectionContains a handle to the file mapping object that the CreateDIBSection function used to create the DIB. If
			/// CreateDIBSection was called with a NULL value for its hSection parameter, causing the system to allocate memory for the
			/// bitmap, the dshSection member will be NULL.
			/// </summary>
			public IntPtr dshSection;

			/// <summary>
			/// The offset to the bitmap's bit values within the file mapping object referenced by dshSection. If dshSection is NULL, the
			/// dsOffset value has no meaning.
			/// </summary>
			public uint dsOffset;

			/// <summary>
			/// Specifies three color masks for the DIB. This field is only valid when the BitCount member of the BITMAPINFOHEADER structure
			/// has a value greater than 8. Each color mask indicates the bits that are used to encode one of the three color channels (red,
			/// green, and blue).
			/// </summary>
#pragma warning disable IDE1006 // Naming Styles

			public uint[] dsBitFields
#pragma warning restore IDE1006 // Naming Styles
			{
				get => new[] { dsBitField1, dsBitField2, dsBitField3 };
				set { dsBitField1 = value[0]; dsBitField2 = value[1]; dsBitField3 = value[2]; }
			}

			/// <summary>Gets the default value for this structure with size fields set appropriately.</summary>
			public static readonly DIBSECTION Default = new() { dsBmih = BITMAPINFOHEADER.Default };
		}

		/// <summary>The RGBQUAD structure describes a color consisting of relative intensities of red, green, and blue.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd162938")]
		public struct RGBQUAD
		{
			/// <summary>The intensity of blue in the color.</summary>
			public byte rgbBlue;

			/// <summary>The intensity of green in the color.</summary>
			public byte rgbGreen;

			/// <summary>The intensity of red in the color.</summary>
			public byte rgbRed;

			/// <summary>This member is reserved and must be zero.</summary>
			public byte rgbReserved;

			/// <summary>Gets or sets the color associated with the <see cref="RGBQUAD"/> structure.</summary>
			/// <value>The color.</value>
			public System.Drawing.Color Color
			{
				get => System.Drawing.Color.FromArgb(rgbReserved, rgbRed, rgbGreen, rgbBlue);
				set { rgbReserved = value.A; rgbBlue = value.B; rgbGreen = value.G; rgbRed = value.R; }
			}

			/// <summary>Gets a value indicating whether any transparency is defined.</summary>
			/// <value><see langword="true"/> if this value is transparent; otherwise, <see langword="false"/>.</value>
			public bool IsTransparent => rgbReserved == 0;

			/// <summary>Performs an implicit conversion from <see cref="System.Drawing.Color"/> to <see cref="RGBQUAD"/>.</summary>
			/// <param name="c">The c.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator RGBQUAD(System.Drawing.Color c) => new() { Color = c };

			/// <summary>Performs an implicit conversion from <see cref="RGBQUAD"/> to <see cref="System.Drawing.Color"/>.</summary>
			/// <param name="c">The c.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator System.Drawing.Color(RGBQUAD c) => c.Color;
		}

		/// <summary>Provides a safe handle to a <see cref="BITMAPINFO"/> structure.</summary>
		public class SafeBITMAPINFO : SafeCoTaskMemStruct<BITMAPINFO>
		{
			private const int RGBQUADSZ = 4;

			/// <summary>Initializes a new instance of the <see cref="SafeBITMAPINFO"/> class.</summary>
			/// <param name="bmpInfo">The <see cref="SafeBITMAPINFO"/> value.</param>
			public SafeBITMAPINFO(in BITMAPINFO bmpInfo) : base(BaseStructSize + (bmpInfo.bmiColors?.Length ?? 0) * RGBQUADSZ)
			{
				handle.Write(bmpInfo.bmiHeader, 0, Size);
				bmiColors = bmpInfo.bmiColors;
			}

			/// <summary>Initializes a new instance of the <see cref="SafeBITMAPINFO"/> class.</summary>
			/// <param name="hdr">The HDR.</param>
			/// <param name="capacity">The capacity of the buffer, in bytes. If 0 or <see langword="default"/>, the capacity is calculated.</param>
			public SafeBITMAPINFO(in BITMAPINFOHEADER hdr, SizeT capacity = default) : base(Math.Max(capacity, BaseStructSize))
			{
				handle.Write(hdr, 0, Size);
			}

			/// <summary>Initializes a new instance of the <see cref="SafeBITMAPINFO"/> class.</summary>
			/// <param name="ptr">Existing handle.</param>
			/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
			protected SafeBITMAPINFO(IntPtr ptr, bool ownsHandle = true) : base(ptr, ownsHandle, 0)
			{
			}

#pragma warning disable IDE1006 // Naming Styles
			/// <summary>
			/// The bmiColors member contains one of the following:
			/// <list type="bullet">
			/// <item>
			/// <description>An array of RGBQUAD. The elements of the array that make up the color table.</description>
			/// </item>
			/// <item>
			/// <description>
			/// An array of 16-bit unsigned integers that specifies indexes into the currently realized logical palette. This use of
			/// bmiColors is allowed for functions that use DIBs. When bmiColors elements contain indexes to a realized logical palette,
			/// they must also call the following bitmap functions: CreateDIBitmap, CreateDIBPatternBrush, CreateDIBSection (The iUsage
			/// parameter of CreateDIBSection must be set to DIB_PAL_COLORS.)
			/// </description>
			/// </item>
			/// </list>
			/// <para>
			/// The number of entries in the array depends on the values of the biBitCount and biClrUsed members of the BITMAPINFOHEADER structure.
			/// </para>
			/// <para>The colors in the bmiColors table appear in order of importance. For more information, see the Remarks section.</para>
			/// </summary>
			public byte[] bmiColorBytes
			{
				get => handle.ToArray<byte>((Size - BaseStructSize), BaseStructSize, Size);
				set
				{
					var reqSize = BaseStructSize + (value?.Length ?? 0);
					if (Size < reqSize)
						Size = reqSize;
					else
						handle.Offset(BaseStructSize).FillMemory(0, Size - BaseStructSize);
					handle.Write(value, BaseStructSize, Size);
				}
			}

			/// <summary>
			/// The bmiColors member contains one of the following:
			/// <list type="bullet">
			/// <item>
			/// <description>An array of RGBQUAD. The elements of the array that make up the color table.</description>
			/// </item>
			/// <item>
			/// <description>
			/// An array of 16-bit unsigned integers that specifies indexes into the currently realized logical palette. This use of
			/// bmiColors is allowed for functions that use DIBs. When bmiColors elements contain indexes to a realized logical palette,
			/// they must also call the following bitmap functions: CreateDIBitmap, CreateDIBPatternBrush, CreateDIBSection (The iUsage
			/// parameter of CreateDIBSection must be set to DIB_PAL_COLORS.)
			/// </description>
			/// </item>
			/// </list>
			/// <para>
			/// The number of entries in the array depends on the values of the biBitCount and biClrUsed members of the BITMAPINFOHEADER structure.
			/// </para>
			/// <para>The colors in the bmiColors table appear in order of importance. For more information, see the Remarks section.</para>
			/// </summary>
			public RGBQUAD[] bmiColors
			{
				get => handle.ToArray<RGBQUAD>((Size - BaseStructSize) / RGBQUADSZ, BaseStructSize, Size);
				set
				{
					var reqSize = BaseStructSize + (value?.Length ?? 0) * RGBQUADSZ;
					if (Size < reqSize)
						Size = reqSize;
					else
						handle.Offset(BaseStructSize).FillMemory(0, Size - BaseStructSize);
					handle.Write(value, BaseStructSize, Size);
				}
			}

			/// <summary>A BITMAPINFOHEADER structure that contains information about the dimensions of color format.</summary>
			public BITMAPINFOHEADER bmiHeader { get => Value.bmiHeader; set => handle.Write(value, 0, Size); }

#if ALLOWSPAN
			/// <summary>A reference to the BITMAPINFOHEADER structure.</summary>
			public ref BITMAPINFOHEADER bmiHeaderAsRef => ref AsRef().bmiHeader;
#endif
#pragma warning restore IDE1006 // Naming Styles

			/// <summary>
			/// Specifies the number of bytes required by the structure. This value does not include the size of the color table or the size
			/// of the color masks, if they are appended to the end of structure. See Remarks.
			/// </summary>
			public SizeT HeaderSize { get => handle.ToStructure<uint>(); set => handle.Write((uint)value); }

			/// <summary>Represents the <see langword="null"/> equivalent of this class instances.</summary>
			public static new readonly SafeBITMAPINFO Null = new(IntPtr.Zero, false);

			/// <summary>Gets a header of the specified type <typeparamref name="T"/>.</summary>
			/// <typeparam name="T">The type of the header to get.</typeparam>
			/// <returns>The requested header structure.</returns>
			public T GetHeader<T>() where T : struct => handle.ToStructure<T>(Size);

			/// <summary>Zero out all allocated memory.</summary>
			public override void Zero() { base.Zero(); HeaderSize = BaseStructSize; }
		}
	}
}