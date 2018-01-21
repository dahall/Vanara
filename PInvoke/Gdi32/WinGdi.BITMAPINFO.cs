using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>The type of compression for a compressed bottom-up bitmap (top-down DIBs cannot be compressed). Used in <see cref="BITMAPINFOHEADER"/>.</summary>
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183376")]
		public enum BitmapCompressionMode : uint
		{
			/// <summary>An uncompressed format.</summary>
			BI_RGB = 0,

			/// <summary>
			/// A run-length encoded (RLE) format for bitmaps with 8 bpp. The compression format is a 2-byte format consisting of a count byte followed by a byte
			/// containing a color index.
			/// </summary>
			BI_RLE8 = 1,

			/// <summary>
			/// An RLE format for bitmaps with 4 bpp. The compression format is a 2-byte format consisting of a count byte followed by two word-length color indexes.
			/// </summary>
			BI_RLE4 = 2,

			/// <summary>
			/// Specifies that the bitmap is not compressed and that the color table consists of three DWORD color masks that specify the red, green, and blue
			/// components, respectively, of each pixel. This is valid when used with 16- and 32-bpp bitmaps.
			/// </summary>
			BI_BITFIELDS = 3,

			/// <summary>Indicates that the image is a JPEG image.</summary>
			BI_JPEG = 4,

			/// <summary>Indicates that the image is a PNG image.</summary>
			BI_PNG = 5
		}

		[PInvokeData("Wingdi.h", MSDNShortId = "dd183494")]
		public enum DIBColorMode : int
		{
			/// <summary>The BITMAPINFO structure contains an array of literal RGB values.</summary>
			DIB_RGB_COLORS = 0,

			/// <summary>
			/// The bmiColors member of the BITMAPINFO structure is an array of 16-bit indexes into the logical palette of the device context specified by hdc.
			/// </summary>
			DIB_PAL_COLORS = 1
		}

		/// <summary>
		/// The CreateDIBSection function creates a DIB that applications can write to directly. The function gives you a pointer to the location of the bitmap
		/// bit values. You can supply a handle to a file-mapping object that the function will use to create the bitmap, or you can let the system allocate the
		/// memory for the bitmap.
		/// </summary>
		/// <param name="hdc">
		/// A handle to a device context. If the value of iUsage is DIB_PAL_COLORS, the function uses this device context's logical palette to initialize the DIB colors.
		/// </param>
		/// <param name="pbmi">A pointer to a BITMAPINFO structure that specifies various attributes of the DIB, including the bitmap dimensions and colors.</param>
		/// <param name="iUsage">
		/// The type of data contained in the bmiColors array member of the BITMAPINFO structure pointed to by pbmi (either logical palette indexes or literal
		/// RGB values).
		/// </param>
		/// <param name="ppvBits">A pointer to a variable that receives a pointer to the location of the DIB bit values.</param>
		/// <param name="hSection">
		/// A handle to a file-mapping object that the function will use to create the DIB. This parameter can be NULL.
		/// <para>
		/// If hSection is not NULL, it must be a handle to a file-mapping object created by calling the CreateFileMapping function with the PAGE_READWRITE or
		/// PAGE_WRITECOPY flag. Read-only DIB sections are not supported. Handles created by other means will cause CreateDIBSection to fail.
		/// </para>
		/// <para>
		/// If hSection is not NULL, the CreateDIBSection function locates the bitmap bit values at offset dwOffset in the file-mapping object referred to by
		/// hSection. An application can later retrieve the hSection handle by calling the GetObject function with the HBITMAP returned by CreateDIBSection.
		/// </para>
		/// <para>
		/// If hSection is NULL, the system allocates memory for the DIB. In this case, the CreateDIBSection function ignores the dwOffset parameter. An
		/// application cannot later obtain a handle to this memory. The dshSection member of the DIBSECTION structure filled in by calling the GetObject
		/// function will be NULL.
		/// </para>
		/// </param>
		/// <param name="dwOffset">
		/// The offset from the beginning of the file-mapping object referenced by hSection where storage for the bitmap bit values is to begin. This value is
		/// ignored if hSection is NULL. The bitmap bit values are aligned on doubleword boundaries, so dwOffset must be a multiple of the size of a DWORD.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the newly created DIB, and *ppvBits points to the bitmap bit values.
		/// <para>If the function fails, the return value is NULL, and *ppvBits is NULL.</para>
		/// </returns>
		/// <remarks>
		/// As noted above, if hSection is NULL, the system allocates memory for the DIB. The system closes the handle to that memory when you later delete the
		/// DIB by calling the DeleteObject function. If hSection is not NULL, you must close the hSection memory handle yourself after calling DeleteObject to
		/// delete the bitmap.
		/// <para>You cannot paste a DIB section from one application into another application.</para>
		/// <para>
		/// CreateDIBSection does not use the BITMAPINFOHEADER parameters biXPelsPerMeter or biYPelsPerMeter and will not provide resolution information in the
		/// BITMAPINFO structure.
		/// </para>
		/// <para>
		/// You need to guarantee that the GDI subsystem has completed any drawing to a bitmap created by CreateDIBSection before you draw to the bitmap
		/// yourself. Access to the bitmap must be synchronized. Do this by calling the GdiFlush function. This applies to any use of the pointer to the bitmap
		/// bit values, including passing the pointer in calls to functions such as SetDIBits.
		/// </para>
		/// <para>ICM: No color management is done.</para>
		/// </remarks>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183494")]
		public static extern IntPtr CreateDIBSection(SafeDCHandle hdc, ref BITMAPINFO pbmi, DIBColorMode iUsage, out IntPtr ppvBits, IntPtr hSection, int dwOffset);

		/// <summary>
		/// The GetDIBits function retrieves the bits of the specified compatible bitmap and copies them into a buffer as a DIB using the specified format.
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="hbmp">A handle to the bitmap. This must be a compatible bitmap (DDB).</param>
		/// <param name="uStartScan">The first scan line to retrieve.</param>
		/// <param name="cScanLines">The number of scan lines to retrieve.</param>
		/// <param name="lpvBits">
		/// A pointer to a buffer to receive the bitmap data. If this parameter is NULL, the function passes the dimensions and format of the bitmap to the
		/// BITMAPINFO structure pointed to by the lpbi parameter.
		/// </param>
		/// <param name="lpbi">A pointer to a BITMAPINFO structure that specifies the desired format for the DIB data.</param>
		/// <param name="uUsage">The format of the bmiColors member of the BITMAPINFO structure.</param>
		/// <returns>
		/// If the lpvBits parameter is non-NULL and the function succeeds, the return value is the number of scan lines copied from the bitmap.
		/// <para>If the lpvBits parameter is NULL and GetDIBits successfully fills the BITMAPINFO structure, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// If the requested format for the DIB matches its internal format, the RGB values for the bitmap are copied. If the requested format doesn't match the
		/// internal format, a color table is synthesized. The following table describes the color table synthesized for each format.
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <term>1_BPP</term>
		/// <description>The color table consists of a black and a white entry.</description>
		/// </item>
		/// <item>
		/// <term>4_BPP</term>
		/// <description>The color table consists of a mix of colors identical to the standard VGA palette.</description>
		/// </item>
		/// <item>
		/// <term>8_BPP</term>
		/// <description>
		/// The color table consists of a general mix of 256 colors defined by GDI. (Included in these 256 colors are the 20 colors found in the default logical palette.)
		/// </description>
		/// </item>
		/// <item>
		/// <term>24_BPP</term>
		/// <description>No color table is returned.</description>
		/// </item>
		/// </list>
		/// <para>
		/// If the lpvBits parameter is a valid pointer, the first six members of the BITMAPINFOHEADER structure must be initialized to specify the size and
		/// format of the DIB. The scan lines must be aligned on a DWORD except for RLE compressed bitmaps.
		/// </para>
		/// <para>
		/// A bottom-up DIB is specified by setting the height to a positive number, while a top-down DIB is specified by setting the height to a negative
		/// number. The bitmap color table will be appended to the BITMAPINFO structure.
		/// </para>
		/// <para>
		/// If lpvBits is NULL, GetDIBits examines the first member of the first structure pointed to by lpbi. This member must specify the size, in bytes, of a
		/// BITMAPCOREHEADER or a BITMAPINFOHEADER structure. The function uses the specified size to determine how the remaining members should be initialized.
		/// </para>
		/// <para>
		/// If lpvBits is NULL and the bit count member of BITMAPINFO is initialized to zero, GetDIBits fills in a BITMAPINFOHEADER structure or BITMAPCOREHEADER
		/// without the color table. This technique can be used to query bitmap attributes.
		/// </para>
		/// <para>The bitmap identified by the hbmp parameter must not be selected into a device context when the application calls this function.</para>
		/// <para>The origin for a bottom-up DIB is the lower-left corner of the bitmap; the origin for a top-down DIB is the upper-left corner.</para>
		/// </remarks>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd144879")]
		public static extern int GetDIBits(SafeDCHandle hdc, IntPtr hbmp, int uStartScan, int cScanLines, ref byte[] lpvBits, ref BITMAPINFO lpbi, DIBColorMode uUsage);

		/// <summary>
		/// The GetDIBits function retrieves the bits of the specified compatible bitmap and copies them into a buffer as a DIB using the specified format.
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="hbmp">A handle to the bitmap. This must be a compatible bitmap (DDB).</param>
		/// <param name="uStartScan">The first scan line to retrieve.</param>
		/// <param name="cScanLines">The number of scan lines to retrieve.</param>
		/// <param name="lpvBits">
		/// A pointer to a buffer to receive the bitmap data. If this parameter is NULL, the function passes the dimensions and format of the bitmap to the
		/// BITMAPINFO structure pointed to by the lpbi parameter.
		/// </param>
		/// <param name="lpbi">A pointer to a BITMAPINFO structure that specifies the desired format for the DIB data.</param>
		/// <param name="uUsage">The format of the bmiColors member of the BITMAPINFO structure.</param>
		/// <returns>
		/// If the lpvBits parameter is non-NULL and the function succeeds, the return value is the number of scan lines copied from the bitmap.
		/// <para>If the lpvBits parameter is NULL and GetDIBits successfully fills the BITMAPINFO structure, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// If the requested format for the DIB matches its internal format, the RGB values for the bitmap are copied. If the requested format doesn't match the
		/// internal format, a color table is synthesized. The following table describes the color table synthesized for each format.
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <term>1_BPP</term>
		/// <description>The color table consists of a black and a white entry.</description>
		/// </item>
		/// <item>
		/// <term>4_BPP</term>
		/// <description>The color table consists of a mix of colors identical to the standard VGA palette.</description>
		/// </item>
		/// <item>
		/// <term>8_BPP</term>
		/// <description>
		/// The color table consists of a general mix of 256 colors defined by GDI. (Included in these 256 colors are the 20 colors found in the default logical palette.)
		/// </description>
		/// </item>
		/// <item>
		/// <term>24_BPP</term>
		/// <description>No color table is returned.</description>
		/// </item>
		/// </list>
		/// <para>
		/// If the lpvBits parameter is a valid pointer, the first six members of the BITMAPINFOHEADER structure must be initialized to specify the size and
		/// format of the DIB. The scan lines must be aligned on a DWORD except for RLE compressed bitmaps.
		/// </para>
		/// <para>
		/// A bottom-up DIB is specified by setting the height to a positive number, while a top-down DIB is specified by setting the height to a negative
		/// number. The bitmap color table will be appended to the BITMAPINFO structure.
		/// </para>
		/// <para>
		/// If lpvBits is NULL, GetDIBits examines the first member of the first structure pointed to by lpbi. This member must specify the size, in bytes, of a
		/// BITMAPCOREHEADER or a BITMAPINFOHEADER structure. The function uses the specified size to determine how the remaining members should be initialized.
		/// </para>
		/// <para>
		/// If lpvBits is NULL and the bit count member of BITMAPINFO is initialized to zero, GetDIBits fills in a BITMAPINFOHEADER structure or BITMAPCOREHEADER
		/// without the color table. This technique can be used to query bitmap attributes.
		/// </para>
		/// <para>The bitmap identified by the hbmp parameter must not be selected into a device context when the application calls this function.</para>
		/// <para>The origin for a bottom-up DIB is the lower-left corner of the bitmap; the origin for a top-down DIB is the upper-left corner.</para>
		/// </remarks>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd144879")]
		public static extern int GetDIBits(SafeDCHandle hdc, IntPtr hbmp, int uStartScan, int cScanLines, IntPtr lpvBits, ref BITMAPINFO lpbi, DIBColorMode uUsage);

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
			/// The number of bytes in each scan line. This value must be divisible by 2, because the system assumes that the bit values of a bitmap form an
			/// array that is word aligned.
			/// </summary>
			public int bmWidthBytes;
			/// <summary>The count of color planes.</summary>
			public ushort bmPlanes;
			/// <summary>The number of bits required to indicate the color of a pixel.</summary>
			public ushort bmBitsPixel;
			/// <summary>
			/// A pointer to the location of the bit values for the bitmap. The bmBits member must be a pointer to an array of character (1-byte) values.
			/// </summary>
			public IntPtr bmBits;
		}

		/// <summary>The BITMAPINFO structure defines the dimensions and color information for a DIB.</summary>
		/// <remarks>
		/// A DIB consists of two distinct parts: a BITMAPINFO structure describing the dimensions and colors of the bitmap, and an array of bytes defining the
		/// pixels of the bitmap. The bits in the array are packed together, but each scan line must be padded with zeros to end on a LONG data-type boundary. If
		/// the height of the bitmap is positive, the bitmap is a bottom-up DIB and its origin is the lower-left corner. If the height is negative, the bitmap is
		/// a top-down DIB and its origin is the upper left corner.
		/// <para>
		/// A bitmap is packed when the bitmap array immediately follows the BITMAPINFO header. Packed bitmaps are referenced by a single pointer. For packed
		/// bitmaps, the biClrUsed member must be set to an even number when using the DIB_PAL_COLORS mode so that the DIB bitmap array starts on a DWORD boundary.
		/// </para>
		/// <para><c>Note</c></para>
		/// <para>The bmiColors member should not contain palette indexes if the bitmap is to be stored in a file or transferred to another application.</para>
		/// <para>Unless the application has exclusive use and control of the bitmap, the bitmap color table should contain explicit RGB values.</para>
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
			/// An array of 16-bit unsigned integers that specifies indexes into the currently realized logical palette. This use of bmiColors is allowed for
			/// functions that use DIBs. When bmiColors elements contain indexes to a realized logical palette, they must also call the following bitmap
			/// functions: CreateDIBitmap, CreateDIBPatternBrush, CreateDIBSection (The iUsage parameter of CreateDIBSection must be set to DIB_PAL_COLORS.)
			/// </description>
			/// </item>
			/// </list>
			/// <para>The number of entries in the array depends on the values of the biBitCount and biClrUsed members of the BITMAPINFOHEADER structure.</para>
			/// <para>The colors in the bmiColors table appear in order of importance. For more information, see the Remarks section.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
			public RGBQUAD[] bmiColors;

			/// <summary>Initializes a new instance of the <see cref="BITMAPINFO"/> structure.</summary>
			/// <param name="width">The width.</param>
			/// <param name="height">The height.</param>
			/// <param name="bitCount">The bit count.</param>
			public BITMAPINFO(int width, int height, ushort bitCount = 32)
				: this()
			{
				bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFO));
				bmiHeader.biWidth = width;
				bmiHeader.biHeight = height;
				bmiHeader.biPlanes = 1;
				bmiHeader.biBitCount = bitCount;
				bmiHeader.biCompression = BitmapCompressionMode.BI_RGB;
				bmiHeader.biSizeImage = 0; // (uint)width * (uint)height * bitCount / 8;
			}
		}

		/// <summary>The BITMAPINFOHEADER structure contains information about the dimensions and color format of a DIB.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183376")]
		public struct BITMAPINFOHEADER
		{
			/// <summary>The number of bytes required by the structure.</summary>
			public int biSize;

			/// <summary>
			/// The width of the bitmap, in pixels. If biCompression is BI_JPEG or BI_PNG, the biWidth member specifies the width of the decompressed JPEG or PNG
			/// image file, respectively.
			/// </summary>
			public int biWidth;

			/// <summary>
			/// The height of the bitmap, in pixels. If biHeight is positive, the bitmap is a bottom-up DIB and its origin is the lower-left corner. If biHeight
			/// is negative, the bitmap is a top-down DIB and its origin is the upper-left corner.
			/// <para>If biHeight is negative, indicating a top-down DIB, biCompression must be either BI_RGB or BI_BITFIELDS. Top-down DIBs cannot be compressed.</para>
			/// <para>If biCompression is BI_JPEG or BI_PNG, the biHeight member specifies the height of the decompressed JPEG or PNG image file, respectively.</para>
			/// </summary>
			public int biHeight;

			/// <summary>The number of planes for the target device. This value must be set to 1.</summary>
			public ushort biPlanes;

			/// <summary>
			/// The number of bits-per-pixel. The biBitCount member of the BITMAPINFOHEADER structure determines the number of bits that define each pixel and
			/// the maximum number of colors in the bitmap. This member must be one of the following values.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <description>Meaning</description>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <description>The number of bits-per-pixel is specified or is implied by the JPEG or PNG format.</description>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <description>
			/// The bitmap is monochrome, and the bmiColors member of BITMAPINFO contains two entries. Each bit in the bitmap array represents a pixel. If the
			/// bit is clear, the pixel is displayed with the color of the first entry in the bmiColors table; if the bit is set, the pixel has the color of the
			/// second entry in the table.
			/// </description>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <description>
			/// The bitmap has a maximum of 16 colors, and the bmiColors member of BITMAPINFO contains up to 16 entries. Each pixel in the bitmap is represented
			/// by a 4-bit index into the color table. For example, if the first byte in the bitmap is 0x1F, the byte represents two pixels. The first pixel
			/// contains the color in the second table entry, and the second pixel contains the color in the sixteenth table entry.
			/// </description>
			/// </item>
			/// <item>
			/// <term>8</term>
			/// <description>
			/// The bitmap has a maximum of 256 colors, and the bmiColors member of BITMAPINFO contains up to 256 entries. In this case, each byte in the array
			/// represents a single pixel.
			/// </description>
			/// </item>
			/// <item>
			/// <term>16</term>
			/// <description>
			/// The bitmap has a maximum of 2^16 colors. If the biCompression member of the BITMAPINFOHEADER is BI_RGB, the bmiColors member of BITMAPINFO is
			/// NULL. Each WORD in the bitmap array represents a single pixel. The relative intensities of red, green, and blue are represented with five bits
			/// for each color component. The value for blue is in the least significant five bits, followed by five bits each for green and red. The most
			/// significant bit is not used. The bmiColors color table is used for optimizing colors used on palette-based devices, and must contain the number
			/// of entries specified by the biClrUsed member of the BITMAPINFOHEADER.
			/// <para>
			/// If the biCompression member of the BITMAPINFOHEADER is BI_BITFIELDS, the bmiColors member contains three DWORD color masks that specify the red,
			/// green, and blue components, respectively, of each pixel. Each WORD in the bitmap array represents a single pixel.
			/// </para>
			/// <para>
			/// When the biCompression member is BI_BITFIELDS, bits set in each DWORD mask must be contiguous and should not overlap the bits of another mask.
			/// All the bits in the pixel do not have to be used.
			/// </para>
			/// </description>
			/// </item>
			/// <item>
			/// <term>24</term>
			/// <description>
			/// The bitmap has a maximum of 2^24 colors, and the bmiColors member of BITMAPINFO is NULL. Each 3-byte triplet in the bitmap array represents the
			/// relative intensities of blue, green, and red, respectively, for a pixel. The bmiColors color table is used for optimizing colors used on
			/// palette-based devices, and must contain the number of entries specified by the biClrUsed member of the BITMAPINFOHEADER.
			/// </description>
			/// </item>
			/// <item>
			/// <term>32</term>
			/// <description>
			/// The bitmap has a maximum of 2^32 colors. If the biCompression member of the BITMAPINFOHEADER is BI_RGB, the bmiColors member of BITMAPINFO is
			/// NULL. Each DWORD in the bitmap array represents the relative intensities of blue, green, and red for a pixel. The value for blue is in the least
			/// significant 8 bits, followed by 8 bits each for green and red. The high byte in each DWORD is not used. The bmiColors color table is used for
			/// optimizing colors used on palette-based devices, and must contain the number of entries specified by the biClrUsed member of the BITMAPINFOHEADER.
			/// <para>
			/// If the biCompression member of the BITMAPINFOHEADER is BI_BITFIELDS, the bmiColors member contains three DWORD color masks that specify the red,
			/// green, and blue components, respectively, of each pixel. Each DWORD in the bitmap array represents a single pixel.
			/// </para>
			/// <para>
			/// When the biCompression member is BI_BITFIELDS, bits set in each DWORD mask must be contiguous and should not overlap the bits of another mask.
			/// All the bits in the pixel do not need to be used.
			/// </para>
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			public ushort biBitCount;

			/// <summary>The type of compression for a compressed bottom-up bitmap (top-down DIBs cannot be compressed).</summary>
			public BitmapCompressionMode biCompression;

			/// <summary>
			/// The size, in bytes, of the image. This may be set to zero for BI_RGB bitmaps. If biCompression is BI_JPEG or BI_PNG, biSizeImage indicates the
			/// size of the JPEG or PNG image buffer, respectively.
			/// </summary>
			public uint biSizeImage;

			/// <summary>
			/// The horizontal resolution, in pixels-per-meter, of the target device for the bitmap. An application can use this value to select a bitmap from a
			/// resource group that best matches the characteristics of the current device.
			/// </summary>
			public int biXPelsPerMeter;

			/// <summary>The vertical resolution, in pixels-per-meter, of the target device for the bitmap.</summary>
			public int biYPelsPerMeter;

			/// <summary>
			/// The number of color indexes in the color table that are actually used by the bitmap. If this value is zero, the bitmap uses the maximum number of
			/// colors corresponding to the value of the biBitCount member for the compression mode specified by biCompression.
			/// <para>
			/// If biClrUsed is nonzero and the biBitCount member is less than 16, the biClrUsed member specifies the actual number of colors the graphics engine
			/// or device driver accesses. If biBitCount is 16 or greater, the biClrUsed member specifies the size of the color table used to optimize
			/// performance of the system color palettes. If biBitCount equals 16 or 32, the optimal color palette starts immediately following the three DWORD masks.
			/// </para>
			/// <para>
			/// When the bitmap array immediately follows the BITMAPINFO structure, it is a packed bitmap. Packed bitmaps are referenced by a single pointer.
			/// Packed bitmaps require that the biClrUsed member must be either zero or the actual size of the color table.
			/// </para>
			/// </summary>
			public uint biClrUsed;

			/// <summary>The number of color indexes that are required for displaying the bitmap. If this value is zero, all colors are required.</summary>
			public uint biClrImportant;
		}

		/// <summary>
		/// The DIBSECTION structure contains information about a DIB created by calling the CreateDIBSection function. A DIBSECTION structure includes
		/// information about the bitmap's dimensions, color format, color masks, optional file mapping object, and optional bit values storage offset. An
		/// application can obtain a filled-in DIBSECTION structure for a given DIB by calling the GetObject function.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183567")]
		public struct DIBSECTION
		{
			/// <summary>
			/// A BITMAP data structure that contains information about the DIB: its type, its dimensions, its color capacities, and a pointer to its bit values.
			/// </summary>
			public BITMAP dsBm;
			/// <summary>A BITMAPINFOHEADER structure that contains information about the color format of the DIB.</summary>
			public BITMAPINFOHEADER dsBmih;
			private uint dsBitField1;
			private uint dsBitField2;
			private uint dsBitField3;
			/// <summary>
			/// The DSH sectionContains a handle to the file mapping object that the CreateDIBSection function used to create the DIB. If CreateDIBSection was
			/// called with a NULL value for its hSection parameter, causing the system to allocate memory for the bitmap, the dshSection member will be NULL.
			/// </summary>
			public IntPtr dshSection;
			/// <summary>
			/// The offset to the bitmap's bit values within the file mapping object referenced by dshSection. If dshSection is NULL, the dsOffset value has no meaning.
			/// </summary>
			public uint dsOffset;

			/// <summary>
			/// Specifies three color masks for the DIB. This field is only valid when the BitCount member of the BITMAPINFOHEADER structure has a value greater
			/// than 8. Each color mask indicates the bits that are used to encode one of the three color channels (red, green, and blue).
			/// </summary>
			public uint[] dsBitFields
			{
				get => new[] { dsBitField1, dsBitField2, dsBitField3 };
				set { dsBitField1 = value[0]; dsBitField2 = value[1]; dsBitField3 = value[2]; }
			}
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
				get => System.Drawing.Color.FromArgb(rgbReserved, rgbRed, rgbGreen, rgbBlue); set { rgbReserved = value.A; rgbBlue = value.B; rgbGreen = value.G; rgbRed = value.R; }
			}
		}
	}
}