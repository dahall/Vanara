using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		[PInvokeData("Wingdi.h")]
		public const int LF_FACESIZE = 32;

		/// <summary>The background mode used by the <see cref="SetBkMode"/> function.</summary>
		[PInvokeData("Wingdi.h", MSDNShortId = "dd162965")]
		public enum BackgroundMode
		{
			/// <summary>Indicates that on return, the <see cref="SetBkMode"/> has failed.</summary>
			ERROR = 0,

			/// <summary>Background remains untouched.</summary>
			TRANSPARENT = 1,

			/// <summary>Background is filled with the current background color before the text, hatched brush, or pen is drawn.</summary>
			OPAQUE = 2,
		}

		/// <summary>Brush style used by <see cref="LOGBRUSH.lbStyle"/>.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "ded2c7a4-2248-4d01-95c6-ab4050719094")]
		public enum BrushStyle : uint
		{
			/// <summary>
			/// A pattern brush defined by a device-independent bitmap (DIB) specification. If lbStyle is BS_DIBPATTERN, the lbHatch member
			/// contains a handle to a packed DIB. For more information, see discussion in lbHatch.
			/// </summary>
			BS_DIBPATTERN = 5,

			/// <summary>See BS_DIBPATTERN.</summary>
			BS_DIBPATTERN8X8 = 8,

			/// <summary>
			/// A pattern brush defined by a device-independent bitmap (DIB) specification. If lbStyle is BS_DIBPATTERNPT, the lbHatch member
			/// contains a pointer to a packed DIB. For more information, see discussion in lbHatch.
			/// </summary>
			BS_DIBPATTERNPT = 6,

			/// <summary>Hatched brush.</summary>
			BS_HATCHED = 2,

			/// <summary>Hollow brush.</summary>
			BS_HOLLOW = 1,

			/// <summary>Not supported.</summary>
			BS_INDEXED = 4,

			/// <summary>Not supported.</summary>
			BS_MONOPATTERN = 9,

			/// <summary>Same as BS_HOLLOW.</summary>
			BS_NULL = 1,

			/// <summary>Pattern brush defined by a memory bitmap.</summary>
			BS_PATTERN = 3,

			/// <summary>See BS_PATTERN.</summary>
			BS_PATTERN8X8 = 7,

			/// <summary>Solid brush.</summary>
			BS_SOLID = 0
		}

		/// <summary>The DC layout used by the <see cref="SetLayout"/> function.</summary>
		[PInvokeData("Wingdi.h", MSDNShortId = "dd162979")]
		public enum DCLayout
		{
			/// <summary>Indicates that on return, the <see cref="SetLayout"/> has failed.</summary>
			GDI_ERROR = -1,

			/// <summary>Sets the default horizontal layout to be right to left.</summary>
			LAYOUT_RTL = 1,

			/// <summary>Sets the default horizontal layout to be bottom to top.</summary>
			LAYOUT_BTT = 2,

			/// <summary>Sets the default horizontal layout to be vertical before horizontal.</summary>
			LAYOUT_VBH = 4,

			/// <summary>Disables any reflection during BitBlt and StretchBlt operations.</summary>
			LAYOUT_BITMAPORIENTATIONPRESERVED = 8,
		}

		/// <summary>Values used by the <see cref="GetDeviceCaps"/> function.</summary>
		public enum DeviceCap
		{
			/// <summary>Device driver version</summary>
			DRIVERVERSION = 0,

			/// <summary>Device classification</summary>
			TECHNOLOGY = 2,

			/// <summary>Horizontal size in millimeters</summary>
			HORZSIZE = 4,

			/// <summary>Vertical size in millimeters</summary>
			VERTSIZE = 6,

			/// <summary>Horizontal width in pixels</summary>
			HORZRES = 8,

			/// <summary>Vertical height in pixels</summary>
			VERTRES = 10,

			/// <summary>Number of bits per pixel</summary>
			BITSPIXEL = 12,

			/// <summary>Number of planes</summary>
			PLANES = 14,

			/// <summary>Number of brushes the device has</summary>
			NUMBRUSHES = 16,

			/// <summary>Number of pens the device has</summary>
			NUMPENS = 18,

			/// <summary>Number of markers the device has</summary>
			NUMMARKERS = 20,

			/// <summary>Number of fonts the device has</summary>
			NUMFONTS = 22,

			/// <summary>Number of colors the device supports</summary>
			NUMCOLORS = 24,

			/// <summary>Size required for device descriptor</summary>
			PDEVICESIZE = 26,

			/// <summary>Curve capabilities</summary>
			CURVECAPS = 28,

			/// <summary>Line capabilities</summary>
			LINECAPS = 30,

			/// <summary>Polygonal capabilities</summary>
			POLYGONALCAPS = 32,

			/// <summary>Text capabilities</summary>
			TEXTCAPS = 34,

			/// <summary>Clipping capabilities</summary>
			CLIPCAPS = 36,

			/// <summary>Bitblt capabilities</summary>
			RASTERCAPS = 38,

			/// <summary>Length of the X leg</summary>
			ASPECTX = 40,

			/// <summary>Length of the Y leg</summary>
			ASPECTY = 42,

			/// <summary>Length of the hypotenuse</summary>
			ASPECTXY = 44,

			/// <summary>Shading and Blending caps</summary>
			SHADEBLENDCAPS = 45,

			/// <summary>Logical pixels inch in X</summary>
			LOGPIXELSX = 88,

			/// <summary>Logical pixels inch in Y</summary>
			LOGPIXELSY = 90,

			/// <summary>Number of entries in physical palette</summary>
			SIZEPALETTE = 104,

			/// <summary>Number of reserved entries in palette</summary>
			NUMRESERVED = 106,

			/// <summary>Actual color resolution</summary>
			COLORRES = 108,

			// Printing related DeviceCaps. These replace the appropriate Escapes
			/// <summary>Physical Width in device units</summary>
			PHYSICALWIDTH = 110,

			/// <summary>Physical Height in device units</summary>
			PHYSICALHEIGHT = 111,

			/// <summary>Physical Printable Area x margin</summary>
			PHYSICALOFFSETX = 112,

			/// <summary>Physical Printable Area y margin</summary>
			PHYSICALOFFSETY = 113,

			/// <summary>Scaling factor x</summary>
			SCALINGFACTORX = 114,

			/// <summary>Scaling factor y</summary>
			SCALINGFACTORY = 115,

			/// <summary>Current vertical refresh rate of the display device (for displays only) in Hz</summary>
			VREFRESH = 116,

			/// <summary>Vertical height of entire desktop in pixels</summary>
			DESKTOPVERTRES = 117,

			/// <summary>Horizontal width of entire desktop in pixels</summary>
			DESKTOPHORZRES = 118,

			/// <summary>Preferred blt alignment</summary>
			BLTALIGNMENT = 119
		}

		/// <summary>Hatch style used by <see cref="LOGBRUSH.lbHatchStyle"/>.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "ded2c7a4-2248-4d01-95c6-ab4050719094")]
		public enum HatchStyle : uint
		{
			/// <summary>A 45-degree upward, left-to-right hatch</summary>
			HS_BDIAGONAL = 3,

			/// <summary>Horizontal and vertical cross-hatch</summary>
			HS_CROSS = 4,

			/// <summary>45-degree crosshatch</summary>
			HS_DIAGCROSS = 5,

			/// <summary>A 45-degree downward, left-to-right hatch</summary>
			HS_FDIAGONAL = 2,

			/// <summary>Horizontal hatch</summary>
			HS_HORIZONTAL = 0,

			/// <summary>Vertical hatch</summary>
			HS_VERTICAL = 1
		}

		/// <summary>
		/// Defines how the color data for the source rectangle is to be combined with the color data for the destination rectangle to
		/// achieve the final color when using the <see cref="BitBlt"/> function.
		/// </summary>
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183370")]
		public enum RasterOperationMode
		{
			/// <summary>Copies the source rectangle directly to the destination rectangle.</summary>
			SRCCOPY = 0x00CC0020,

			/// <summary>Combines the colors of the source and destination rectangles by using the Boolean OR operator.</summary>
			SRCPAINT = 0x00EE0086,

			/// <summary>Combines the colors of the source and destination rectangles by using the Boolean AND operator.</summary>
			SRCAND = 0x008800C6,

			/// <summary>Combines the colors of the source and destination rectangles by using the Boolean XOR operator.</summary>
			SRCINVERT = 0x00660046,

			/// <summary>
			/// Combines the inverted colors of the destination rectangle with the colors of the source rectangle by using the Boolean AND operator.
			/// </summary>
			SRCERASE = 0x00440328,

			/// <summary></summary>
			NOTSRCCOPY = 0x00330008,

			/// <summary>Copies the inverted source rectangle to the destination.</summary>
			NOTSRCERASE = 0x001100A6,

			/// <summary>
			/// Merges the colors of the source rectangle with the brush currently selected in hdcDest, by using the Boolean AND operator.
			/// </summary>
			MERGECOPY = 0x00C000CA,

			/// <summary>
			/// Merges the colors of the inverted source rectangle with the colors of the destination rectangle by using the Boolean OR operator.
			/// </summary>
			MERGEPAINT = 0x00BB0226,

			/// <summary>Copies the brush currently selected in hdcDest, into the destination bitmap.</summary>
			PATCOPY = 0x00F00021,

			/// <summary>
			/// Combines the colors of the brush currently selected in hdcDest, with the colors of the inverted source rectangle by using the
			/// Boolean OR operator. The result of this operation is combined with the colors of the destination rectangle by using the
			/// Boolean OR operator.
			/// </summary>
			PATPAINT = 0x00FB0A09,

			/// <summary>
			/// Combines the colors of the brush currently selected in hdcDest, with the colors of the destination rectangle by using the
			/// Boolean XOR operator.
			/// </summary>
			PATINVERT = 0x005A0049,

			/// <summary>Inverts the destination rectangle.</summary>
			DSTINVERT = 0x00550009,

			/// <summary>
			/// Fills the destination rectangle using the color associated with index 0 in the physical palette. (This color is black for the
			/// default physical palette.)
			/// </summary>
			BLACKNESS = 0x00000042,

			/// <summary>
			/// Fills the destination rectangle using the color associated with index 1 in the physical palette. (This color is white for the
			/// default physical palette.)
			/// </summary>
			WHITENESS = 0x00FF0062,

			/// <summary>Prevents the bitmap from being mirrored.</summary>
			NOMIRRORBITMAP = -2147483648,

			/// <summary>
			/// Includes any windows that are layered on top of your window in the resulting image.By default, the image only contains your
			/// window.Note that this generally cannot be used for printing device contexts.
			/// </summary>
			CAPTUREBLT = 0x40000000
		}

		/// <summary>The AlphaBlend function displays bitmaps that have transparent or semitransparent pixels.</summary>
		/// <param name="hdcDest">A handle to the destination device context.</param>
		/// <param name="nXOriginDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
		/// <param name="nYOriginDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
		/// <param name="nWidthDest">The width, in logical units, of the destination rectangle.</param>
		/// <param name="nHeightDest">The height, in logical units, of the destination rectangle.</param>
		/// <param name="hdcSrc">A handle to the source device context.</param>
		/// <param name="nXOriginSrc">The x-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
		/// <param name="nYOriginSrc">The y-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
		/// <param name="nWidthSrc">The width, in logical units, of the source rectangle.</param>
		/// <param name="nHeightSrc">The height, in logical units, of the source rectangle.</param>
		/// <param name="blendFunction">
		/// The alpha-blending function for source and destination bitmaps, a global alpha value to be applied to the entire source bitmap,
		/// and format information for the source bitmap. The source and destination blend functions are currently limited to AC_SRC_OVER.
		/// </param>
		/// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE.</returns>
		/// <remarks>
		/// If the source rectangle and destination rectangle are not the same size, the source bitmap is stretched to match the destination
		/// rectangle. If the SetStretchBltMode function is used, the iStretchMode value is automatically converted to COLORONCOLOR for this
		/// function (that is, BLACKONWHITE, WHITEONBLACK, and HALFTONE are changed to COLORONCOLOR).
		/// <para>
		/// The destination coordinates are transformed by using the transformation currently specified for the destination device context.
		/// The source coordinates are transformed by using the transformation currently specified for the source device context.
		/// </para>
		/// <para>An error occurs (and the function returns FALSE) if the source device context identifies an enhanced metafile device context.</para>
		/// <para>
		/// If destination and source bitmaps do not have the same color format, AlphaBlend converts the source bitmap to match the
		/// destination bitmap.
		/// </para>
		/// <para>
		/// AlphaBlend does not support mirroring. If either the width or height of the source or destination is negative, this call will fail.
		/// </para>
		/// <para>
		/// When rendering to a printer, first call GetDeviceCaps with SHADEBLENDCAPS to determine if the printer supports blending with
		/// AlphaBlend. Note that, for a display DC, all blending operations are supported and these flags represent whether the operations
		/// are accelerated.
		/// </para>
		/// <para>
		/// If the source and destination are the same surface that is, they are both the screen or the same memory bitmap and the source and
		/// destination rectangles overlap, an error occurs and the function returns FALSE.
		/// </para>
		/// <para>
		/// The source rectangle must lie completely within the source surface, otherwise an error occurs and the function returns FALSE.
		/// </para>
		/// <para>AlphaBlend fails if the width or height of the source or destination is negative.</para>
		/// <para>
		/// The SourceConstantAlpha member of BLENDFUNCTION specifies an alpha transparency value to be used on the entire source bitmap. The
		/// SourceConstantAlpha value is combined with any per-pixel alpha values. If SourceConstantAlpha is 0, it is assumed that the image
		/// is transparent. Set the SourceConstantAlpha value to 255 (which indicates that the image is opaque) when you only want to use
		/// per-pixel alpha values.
		/// </para>
		/// </remarks>
		[DllImport(Lib.Gdi32, SetLastError = true, EntryPoint = "GdiAlphaBlend")]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183351")]
		public static extern bool AlphaBlend(HDC hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, HDC hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, BLENDFUNCTION blendFunction);

		/// <summary>
		/// The BitBlt function performs a bit-block transfer of the color data corresponding to a rectangle of pixels from the specified
		/// source device context into a destination device context.
		/// </summary>
		/// <param name="hdc">A handle to the destination device context.</param>
		/// <param name="nXDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
		/// <param name="nYDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
		/// <param name="nWidth">The width, in logical units, of the destination rectangle.</param>
		/// <param name="nHeight">The height, in logical units, of the destination rectangle.</param>
		/// <param name="hdcSrc">A handle to the source device context.</param>
		/// <param name="nXSrc">The x-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
		/// <param name="nYSrc">The y-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
		/// <param name="dwRop">
		/// A raster-operation code. These codes define how the color data for the source rectangle is to be combined with the color data for
		/// the destination rectangle to achieve the final color.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero.
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// BitBlt only does clipping on the destination DC.
		/// <para>
		/// If a rotation or shear transformation is in effect in the source device context, BitBlt returns an error. If other
		/// transformations exist in the source device context (and a matching transformation is not in effect in the destination device
		/// context), the rectangle in the destination device context is stretched, compressed, or rotated, as necessary.
		/// </para>
		/// <para>
		/// If the color formats of the source and destination device contexts do not match, the BitBlt function converts the source color
		/// format to match the destination format.
		/// </para>
		/// <para>
		/// When an enhanced metafile is being recorded, an error occurs if the source device context identifies an enhanced-metafile device context.
		/// </para>
		/// <para>
		/// Not all devices support the BitBlt function. For more information, see the RC_BITBLT raster capability entry in the GetDeviceCaps
		/// function as well as the following functions: MaskBlt, PlgBlt, and StretchBlt.
		/// </para>
		/// <para>
		/// BitBlt returns an error if the source and destination device contexts represent different devices. To transfer data between DCs
		/// for different devices, convert the memory bitmap to a DIB by calling GetDIBits. To display the DIB to the second device, call
		/// SetDIBits or StretchDIBits.
		/// </para>
		/// <para>ICM: No color management is performed when blits occur.</para>
		/// </remarks>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183370")]
		public static extern bool BitBlt(HDC hdc, int nXDest, int nYDest, int nWidth, int nHeight, HDC hdcSrc, int nXSrc, int nYSrc, RasterOperationMode dwRop);

		/// <summary>
		/// <para>The <c>CreateBrushIndirect</c> function creates a logical brush that has the specified style, color, and pattern.</para>
		/// </summary>
		/// <param name="plbrush">
		/// <para>A pointer to a LOGBRUSH structure that contains information about the brush.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value identifies a logical brush.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>A brush is a bitmap that the system uses to paint the interiors of filled shapes.</para>
		/// <para>
		/// After an application creates a brush by calling <c>CreateBrushIndirect</c>, it can select it into any device context by calling
		/// the SelectObject function.
		/// </para>
		/// <para>
		/// A brush created by using a monochrome bitmap (one color plane, one bit per pixel) is drawn using the current text and background
		/// colors. Pixels represented by a bit set to 0 are drawn with the current text color; pixels represented by a bit set to 1 are
		/// drawn with the current background color.
		/// </para>
		/// <para>When you no longer need the brush, call the DeleteObject function to delete it.</para>
		/// <para>
		/// <c>ICM:</c> No color is done at brush creation. However, color management is performed when the brush is selected into an
		/// ICM-enabled device context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createbrushindirect HBRUSH CreateBrushIndirect( CONST
		// LOGBRUSH *plbrush );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "75f94ad1-ca25-4ad1-9e8c-ad1a4b8475a7")]
		public static extern SafeHBRUSH CreateBrushIndirect(ref LOGBRUSH plbrush);

		/// <summary>The CreateCompatibleDC function creates a memory device context (DC) compatible with the specified device.</summary>
		/// <param name="hDC">
		/// A handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with the application's current screen.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the handle to a memory DC.
		/// <para>If the function fails, the return value is NULL.</para>
		/// </returns>
		/// <remarks>
		/// A memory DC exists only in memory. When the memory DC is created, its display surface is exactly one monochrome pixel wide and
		/// one monochrome pixel high. Before an application can use a memory DC for drawing operations, it must select a bitmap of the
		/// correct width and height into the DC. To select a bitmap into a DC, use the CreateCompatibleBitmap function, specifying the
		/// height, width, and color organization required.
		/// <para>
		/// When a memory DC is created, all attributes are set to normal default values. The memory DC can be used as a normal DC. You can
		/// set the attributes; obtain the current settings of its attributes; and select pens, brushes, and regions.
		/// </para>
		/// <para>
		/// The CreateCompatibleDC function can only be used with devices that support raster operations. An application can determine
		/// whether a device supports these operations by calling the GetDeviceCaps function.
		/// </para>
		/// <para>
		/// When you no longer need the memory DC, call the DeleteDC function. We recommend that you call DeleteDC to delete the DC. However,
		/// you can also call DeleteObject with the HDC to delete the DC.
		/// </para>
		/// <para>
		/// If hdc is NULL, the thread that calls CreateCompatibleDC owns the HDC that is created. When this thread is destroyed, the HDC is
		/// no longer valid. Thus, if you create the HDC and pass it to another thread, then exit the first thread, the second thread will
		/// not be able to use the HDC.
		/// </para>
		/// <para>
		/// ICM: If the DC that is passed to this function is enabled for Image Color Management (ICM), the DC created by the function is
		///      ICM-enabled. The source and destination color spaces are specified in the DC.
		/// </para>
		/// </remarks>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183489")]
		public static extern SafeHDC CreateCompatibleDC(HDC hDC);

		/// <summary>The DeleteDC function deletes the specified device context (DC).</summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
		/// <remarks>
		/// An application must not delete a DC whose handle was obtained by calling the GetDC function. Instead, it must call the ReleaseDC
		/// function to free the DC.
		/// </remarks>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183533")]
		public static extern bool DeleteDC(HDC hdc);

		/// <summary>
		/// The DeleteObject function deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated
		/// with the object. After the object is deleted, the specified handle is no longer valid.
		/// </summary>
		/// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the specified handle is not valid or is currently selected into a DC,
		/// the return value is zero.
		/// </returns>
		/// <remarks>
		/// Do not delete a drawing object (pen or brush) while it is still selected into a DC.
		/// <para>When a pattern brush is deleted, the bitmap associated with the brush is not deleted. The bitmap must be deleted independently.</para>
		/// </remarks>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183539")]
		public static extern bool DeleteObject(HGDIOBJ hObject);

		/// <summary>The GdiFlush function flushes the calling thread's current batch.</summary>
		/// <returns>
		/// If all functions in the current batch succeed, the return value is nonzero.
		/// <para>
		/// If not all functions in the current batch succeed, the return value is zero, indicating that at least one function returned an error.
		/// </para>
		/// </returns>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd144844")]
		public static extern bool GdiFlush();

		/// <summary>The GetDeviceCaps function retrieves device-specific information for the specified device.</summary>
		/// <param name="hdc">A handle to the DC.</param>
		/// <param name="index">The item to be returned.</param>
		/// <returns>
		/// The return value specifies the value of the desired item. When nIndex is BITSPIXEL and the device has 15bpp or 16bpp, the return
		/// value is 16.
		/// </returns>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/dd144877(v=vs.85).aspx
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd144877")]
		public static extern int GetDeviceCaps(HDC hdc, DeviceCap index);

		/// <summary>The GetObject function retrieves information for the specified graphics object.</summary>
		/// <param name="hgdiobj">
		/// A handle to the graphics object of interest. This can be a handle to one of the following: a logical bitmap, a brush, a font, a
		/// palette, a pen, or a device independent bitmap created by calling the CreateDIBSection function.
		/// </param>
		/// <param name="cbBuffer">The number of bytes of information to be written to the buffer.</param>
		/// <param name="lpvObject">
		/// A pointer to a buffer that receives the information about the specified graphics object. If the <paramref name="lpvObject"/>
		/// parameter is NULL, the function return value is the number of bytes required to store the information it writes to the buffer for
		/// the specified graphics object.
		/// </param>
		/// <returns>
		/// If the function succeeds, and <paramref name="lpvObject"/> is a valid pointer, the return value is the number of bytes stored
		/// into the buffer.
		/// <para>
		/// If the function succeeds, and <paramref name="lpvObject"/> is NULL, the return value is the number of bytes required to hold the
		/// information the function would store into the buffer.
		/// </para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// The buffer pointed to by the <paramref name="lpvObject"/> parameter must be sufficiently large to receive the information about
		/// the graphics object. Depending on the graphics object, the function uses a BITMAP, DIBSECTION, EXTLOGPEN, LOGBRUSH, LOGFONT, or
		/// LOGPEN structure, or a count of table entries (for a logical palette).
		/// <para>
		/// If <paramref name="hgdiobj"/> is a handle to a bitmap created by calling CreateDIBSection, and the specified buffer is large
		/// enough, the GetObject function returns a DIBSECTION structure. In addition, the bmBits member of the BITMAP structure contained
		/// within the DIBSECTION will contain a pointer to the bitmap's bit values.
		/// </para>
		/// <para>
		/// If <paramref name="hgdiobj"/> is a handle to a bitmap created by any other means, GetObject returns only the width, height, and
		/// color format information of the bitmap. You can obtain the bitmap's bit values by calling the GetDIBits or GetBitmapBits function.
		/// </para>
		/// <para>
		/// If <paramref name="hgdiobj"/> is a handle to a logical palette, GetObject retrieves a 2-byte integer that specifies the number of
		/// entries in the palette. The function does not retrieve the LOGPALETTE structure defining the palette. To retrieve information
		/// about palette entries, an application can call the GetPaletteEntries function.
		/// </para>
		/// <para>
		/// If <paramref name="hgdiobj"/> is a handle to a font, the LOGFONT that is returned is the LOGFONT used to create the font. If
		/// Windows had to make some interpolation of the font because the precise LOGFONT could not be represented, the interpolation will
		/// not be reflected in the LOGFONT. For example, if you ask for a vertical version of a font that doesn't support vertical painting,
		/// the LOGFONT indicates the font is vertical, but Windows will paint it horizontally.
		/// </para>
		/// </remarks>
		[DllImport(Lib.Gdi32, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd144904")]
		public static extern int GetObject(HGDIOBJ hgdiobj, int cbBuffer, IntPtr lpvObject);

		/// <summary>The GetObject function retrieves information for the specified graphics object.</summary>
		/// <typeparam name="T">The output structure type.</typeparam>
		/// <param name="hgdiobj">
		/// A handle to the graphics object of interest. This can be a handle to one of the following: a logical bitmap, a brush, a font, a
		/// palette, a pen, or a device independent bitmap created by calling the CreateDIBSection function.
		/// </param>
		/// <returns>The output structure holding the information for the graphics object.</returns>
		[PInvokeData("Wingdi.h", MSDNShortId = "dd144904")]
		public static T GetObject<T>(HGDIOBJ hgdiobj) where T : struct
		{
			var result = default(T);
			using (var ptr = SafeHGlobalHandle.CreateFromStructure(result))
			{
				var ret = GetObject(hgdiobj, ptr.Size, (IntPtr)ptr);
				if (ret == 0)
					throw new System.ComponentModel.Win32Exception();
				return ptr.ToStructure<T>();
			}
		}

		/// <summary>
		/// The SelectObject function selects an object into the specified device context (DC). The new object replaces the previous object
		/// of the same type.
		/// </summary>
		/// <param name="hDC">A handle to the DC.</param>
		/// <param name="hObject">
		/// A handle to the object to be selected. The specified object must have been created by using one of the following functions.
		/// </param>
		/// <returns>
		/// If the selected object is not a region and the function succeeds, the return value is a handle to the object being replaced. If
		/// the selected object is a region and the function succeeds, the return value is one of the following values.
		/// </returns>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd162957")]
		public static extern HGDIOBJ SelectObject(HDC hDC, HGDIOBJ hObject);

		/// <summary>
		/// The SetBkMode function sets the background mix mode of the specified device context. The background mix mode is used with text,
		/// hatched brushes, and pen styles that are not solid lines.
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="mode">The background mode.</param>
		/// <returns>
		/// If the function succeeds, the return value specifies the previous background mode. If the function fails, the return value is zero.
		/// </returns>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd162965")]
		public static extern BackgroundMode SetBkMode(HDC hdc, BackgroundMode mode);

		/// <summary>The SetLayout function changes the layout of a device context (DC).</summary>
		/// <param name="hdc">A handle to the DC.</param>
		/// <param name="dwLayout">The DC layout.</param>
		/// <returns>If the function succeeds, it returns the previous layout of the DC. If the function fails, it returns GDI_ERROR.</returns>
		/// <remarks>
		/// The layout specifies the order in which text and graphics are revealed in a window or a device context. The default is left to
		/// right. The SetLayout function changes this to be right to left, which is the standard in Arabic and Hebrew cultures.
		/// </remarks>
		[DllImport(Lib.Gdi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd162979")]
		public static extern DCLayout SetLayout(HDC hdc, DCLayout dwLayout);

		/// <summary>
		/// The TransparentBlt function performs a bit-block transfer of the color data corresponding to a rectangle of pixels from the
		/// specified source device context into a destination device context.
		/// </summary>
		/// <param name="hdcDest">A handle to the destination device context.</param>
		/// <param name="xOriginDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
		/// <param name="yOriginDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
		/// <param name="wDest">The width, in logical units, of the destination rectangle.</param>
		/// <param name="hDest">The height, in logical units, of the destination rectangle.</param>
		/// <param name="hdcSrc">A handle to the source device context.</param>
		/// <param name="xOriginSrc">The x-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
		/// <param name="yOriginSrc">The y-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
		/// <param name="wSrc">The width, in logical units, of the source rectangle.</param>
		/// <param name="hSrc">The height, in logical units, of the source rectangle.</param>
		/// <param name="crTransparent">The RGB color in the source bitmap to treat as transparent.</param>
		/// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE.</returns>
		/// <remarks>
		/// The TransparentBlt function works with compatible bitmaps (DDBs).
		/// <para>
		/// The TransparentBlt function supports all formats of source bitmaps. However, for 32 bpp bitmaps, it just copies the alpha value
		/// over. Use AlphaBlend to specify 32 bits-per-pixel bitmaps with transparency.
		/// </para>
		/// <para>
		/// If the source and destination rectangles are not the same size, the source bitmap is stretched to match the destination
		/// rectangle. When the SetStretchBltMode function is used, the iStretchMode modes of BLACKONWHITE and WHITEONBLACK are converted to
		/// COLORONCOLOR for the TransparentBlt function.
		/// </para>
		/// <para>
		/// The destination device context specifies the transformation type for the destination coordinates. The source device context
		/// specifies the transformation type for the source coordinates.
		/// </para>
		/// <para>TransparentBlt does not mirror a bitmap if either the width or height, of either the source or destination, is negative.</para>
		/// <para>
		/// When used in a multiple monitor system, both hdcSrc and hdcDest must refer to the same device or the function will fail. To
		/// transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling GetDIBits. To display the DIB to
		/// the second device, call SetDIBits or StretchDIBits.
		/// </para>
		/// </remarks>
		[DllImport(Lib.Gdi32, SetLastError = true, EntryPoint = "GdiTransparentBlt")]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd145141")]
		public static extern bool TransparentBlt(HDC hdcDest, int xOriginDest, int yOriginDest, int wDest, int hDest, HDC hdcSrc, int xOriginSrc, int yOriginSrc, int wSrc, int hSrc, int crTransparent);

		/// <summary>
		/// <para>
		/// The <c>LOGBRUSH</c> structure defines the style, color, and pattern of a physical brush. It is used by the CreateBrushIndirect
		/// and ExtCreatePen functions.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Although <c>lbColor</c> controls the foreground color of a hatch brush, the SetBkMode and SetBkColor functions control the
		/// background color.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-taglogbrush typedef struct tagLOGBRUSH { UINT lbStyle;
		// COLORREF lbColor; ULONG_PTR lbHatch; } LOGBRUSH, *PLOGBRUSH, *NPLOGBRUSH, *LPLOGBRUSH;
		[PInvokeData("wingdi.h", MSDNShortId = "ded2c7a4-2248-4d01-95c6-ab4050719094")]
		[StructLayout(LayoutKind.Explicit)]
		public struct LOGBRUSH
		{
			/// <summary>
			/// <para>The brush style. The <c>lbStyle</c> member must be one of the following styles.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>BS_DIBPATTERN</term>
			/// <term>
			/// A pattern brush defined by a device-independent bitmap (DIB) specification. If lbStyle is BS_DIBPATTERN, the lbHatch member
			/// contains a handle to a packed DIB. For more information, see discussion in lbHatch.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BS_DIBPATTERN8X8</term>
			/// <term>See BS_DIBPATTERN.</term>
			/// </item>
			/// <item>
			/// <term>BS_DIBPATTERNPT</term>
			/// <term>
			/// A pattern brush defined by a device-independent bitmap (DIB) specification. If lbStyle is BS_DIBPATTERNPT, the lbHatch member
			/// contains a pointer to a packed DIB. For more information, see discussion in lbHatch.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BS_HATCHED</term>
			/// <term>Hatched brush.</term>
			/// </item>
			/// <item>
			/// <term>BS_HOLLOW</term>
			/// <term>Hollow brush.</term>
			/// </item>
			/// <item>
			/// <term>BS_NULL</term>
			/// <term>Same as BS_HOLLOW.</term>
			/// </item>
			/// <item>
			/// <term>BS_PATTERN</term>
			/// <term>Pattern brush defined by a memory bitmap.</term>
			/// </item>
			/// <item>
			/// <term>BS_PATTERN8X8</term>
			/// <term>See BS_PATTERN.</term>
			/// </item>
			/// <item>
			/// <term>BS_SOLID</term>
			/// <term>Solid brush.</term>
			/// </item>
			/// </list>
			/// </summary>
			[FieldOffset(0)]
			public BrushStyle lbStyle;

			/// <summary>
			/// <para>
			/// The color in which the brush is to be drawn. If <c>lbStyle</c> is the BS_HOLLOW or BS_PATTERN style, <c>lbColor</c> is ignored.
			/// </para>
			/// <para>
			/// If <c>lbStyle</c> is BS_DIBPATTERN or BS_DIBPATTERNPT, the low-order word of <c>lbColor</c> specifies whether the
			/// <c>bmiColors</c> members of the BITMAPINFO structure contain explicit red, green, blue (RGB) values or indexes into the
			/// currently realized logical palette. The <c>lbColor</c> member must be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DIB_PAL_COLORS</term>
			/// <term>The color table consists of an array of 16-bit indexes into the currently realized logical palette.</term>
			/// </item>
			/// <item>
			/// <term>DIB_RGB_COLORS</term>
			/// <term>The color table contains literal RGB values.</term>
			/// </item>
			/// </list>
			/// <para>
			/// If <c>lbStyle</c> is BS_HATCHED or BS_SOLID, <c>lbColor</c> is a COLORREF color value. To create a <c>COLORREF</c> color
			/// value, use the RGB macro.
			/// </para>
			/// </summary>
			[FieldOffset(4)]
			public COLORREF lbColor;

			/// <summary>
			/// <para>A hatch style. The meaning depends on the brush style defined by <c>lbStyle</c>.</para>
			/// <para>
			/// If <c>lbStyle</c> is BS_DIBPATTERN, the <c>lbHatch</c> member contains a handle to a packed DIB. To obtain this handle, an
			/// application calls the GlobalAlloc function with GMEM_MOVEABLE (or LocalAlloc with LMEM_MOVEABLE) to allocate a block of
			/// memory and then fills the memory with the packed DIB. A packed DIB consists of a BITMAPINFO structure immediately followed by
			/// the array of bytes that define the pixels of the bitmap.
			/// </para>
			/// <para>
			/// If <c>lbStyle</c> is BS_DIBPATTERNPT, the <c>lbHatch</c> member contains a pointer to a packed DIB. The pointer derives from
			/// the memory block created by LocalAlloc with LMEM_FIXED set or by GlobalAlloc with GMEM_FIXED set, or it is the pointer
			/// returned by a call like LocalLock (handle_to_the_dib). A packed DIB consists of a BITMAPINFO structure immediately followed
			/// by the array of bytes that define the pixels of the bitmap.
			/// </para>
			/// <para>
			/// If <c>lbStyle</c> is BS_HATCHED, the <c>lbHatch</c> member specifies the orientation of the lines used to create the hatch.
			/// It can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>HS_BDIAGONAL</term>
			/// <term>A 45-degree upward, left-to-right hatch</term>
			/// </item>
			/// <item>
			/// <term>HS_CROSS</term>
			/// <term>Horizontal and vertical cross-hatch</term>
			/// </item>
			/// <item>
			/// <term>HS_DIAGCROSS</term>
			/// <term>45-degree crosshatch</term>
			/// </item>
			/// <item>
			/// <term>HS_FDIAGONAL</term>
			/// <term>A 45-degree downward, left-to-right hatch</term>
			/// </item>
			/// <item>
			/// <term>HS_HORIZONTAL</term>
			/// <term>Horizontal hatch</term>
			/// </item>
			/// <item>
			/// <term>HS_VERTICAL</term>
			/// <term>Vertical hatch</term>
			/// </item>
			/// </list>
			/// <para>
			/// If <c>lbStyle</c> is BS_PATTERN, <c>lbHatch</c> is a handle to the bitmap that defines the pattern. The bitmap cannot be a
			/// DIB section bitmap, which is created by the CreateDIBSection function.
			/// </para>
			/// <para>If <c>lbStyle</c> is BS_SOLID or BS_HOLLOW, <c>lbHatch</c> is ignored.</para>
			/// </summary>
			[FieldOffset(8)]
			public HatchStyle lbHatchStyle;

			/// <summary>
			/// <para>A hatch style. The meaning depends on the brush style defined by <c>lbStyle</c>.</para>
			/// <para>
			/// If <c>lbStyle</c> is BS_DIBPATTERN, the <c>lbHatch</c> member contains a handle to a packed DIB. To obtain this handle, an
			/// application calls the GlobalAlloc function with GMEM_MOVEABLE (or LocalAlloc with LMEM_MOVEABLE) to allocate a block of
			/// memory and then fills the memory with the packed DIB. A packed DIB consists of a BITMAPINFO structure immediately followed by
			/// the array of bytes that define the pixels of the bitmap.
			/// </para>
			/// <para>
			/// If <c>lbStyle</c> is BS_DIBPATTERNPT, the <c>lbHatch</c> member contains a pointer to a packed DIB. The pointer derives from
			/// the memory block created by LocalAlloc with LMEM_FIXED set or by GlobalAlloc with GMEM_FIXED set, or it is the pointer
			/// returned by a call like LocalLock (handle_to_the_dib). A packed DIB consists of a BITMAPINFO structure immediately followed
			/// by the array of bytes that define the pixels of the bitmap.
			/// </para>
			/// <para>
			/// If <c>lbStyle</c> is BS_HATCHED, the <c>lbHatch</c> member specifies the orientation of the lines used to create the hatch.
			/// It can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>HS_BDIAGONAL</term>
			/// <term>A 45-degree upward, left-to-right hatch</term>
			/// </item>
			/// <item>
			/// <term>HS_CROSS</term>
			/// <term>Horizontal and vertical cross-hatch</term>
			/// </item>
			/// <item>
			/// <term>HS_DIAGCROSS</term>
			/// <term>45-degree crosshatch</term>
			/// </item>
			/// <item>
			/// <term>HS_FDIAGONAL</term>
			/// <term>A 45-degree downward, left-to-right hatch</term>
			/// </item>
			/// <item>
			/// <term>HS_HORIZONTAL</term>
			/// <term>Horizontal hatch</term>
			/// </item>
			/// <item>
			/// <term>HS_VERTICAL</term>
			/// <term>Vertical hatch</term>
			/// </item>
			/// </list>
			/// <para>
			/// If <c>lbStyle</c> is BS_PATTERN, <c>lbHatch</c> is a handle to the bitmap that defines the pattern. The bitmap cannot be a
			/// DIB section bitmap, which is created by the CreateDIBSection function.
			/// </para>
			/// <para>If <c>lbStyle</c> is BS_SOLID or BS_HOLLOW, <c>lbHatch</c> is ignored.</para>
			/// </summary>
			[FieldOffset(8)]
			public IntPtr lbHatch;
		}
	}
}