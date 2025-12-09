namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>Flags for CreateDIBitmap.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "e9a5b525-a6b6-4309-9e53-69d274b85783")]
	[Flags]
	public enum CBM
	{
		/// <summary>
		/// If this flag is set, the system uses the data pointed to by the lpbInit and lpbmi parameters to initialize the bitmap bits.
		/// </summary>
		CBM_INIT = 4
	}

	/// <summary>Specifies the type of color values in DIB functions.</summary>
	[PInvokeData("Wingdi.h", MSDNShortId = "dd183494")]
	public enum DIBColorMode : int
	{
		/// <summary>The BITMAPINFO structure contains an array of literal RGB values.</summary>
		DIB_RGB_COLORS = 0,

		/// <summary>
		/// The bmiColors member of the BITMAPINFO structure is an array of 16-bit indexes into the logical palette of the device context
		/// specified by hdc.
		/// </summary>
		DIB_PAL_COLORS = 1
	}

	/// <summary>The type of fill operation to be performed.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "b996d47d-5aaf-4b13-8643-209744e5a04b")]
	public enum FloodFillType : uint
	{
		/// <summary>
		/// The fill area is bounded by the color specified by the crColor parameter. This style is identical to the filling performed by
		/// the FloodFill function.
		/// </summary>
		FLOODFILLBORDER,

		/// <summary>
		/// The fill area is defined by the color that is specified by crColor. Filling continues outward in all directions as long as
		/// the color is encountered. This style is useful for filling areas with multicolored boundaries.
		/// </summary>
		FLOODFILLSURFACE
	}

	/// <summary>Flags for <see cref="GradientFill"/>.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "c88c1137-5690-4139-9d10-90d036e8f31c")]
	public enum GradientFillMode : uint
	{
		/// <summary>
		/// In this mode, two endpoints describe a rectangle. The rectangle is defined to have a constant color (specified by the
		/// TRIVERTEX structure) for the left and right edges. GDI interpolates the color from the left to right edge and fills the interior.
		/// </summary>
		GRADIENT_FILL_RECT_H = 0x00000000,

		/// <summary>
		/// In this mode, two endpoints describe a rectangle. The rectangle is defined to have a constant color (specified by the
		/// TRIVERTEX structure) for the top and bottom edges. GDI interpolates the color from the top to bottom edge and fills the interior.
		/// </summary>
		GRADIENT_FILL_RECT_V = 0x00000001,

		/// <summary>
		/// In this mode, an array of TRIVERTEX structures is passed to GDI along with a list of array indexes that describe separate
		/// triangles. GDI performs linear interpolation between triangle vertices and fills the interior. Drawing is done directly in
		/// 24- and 32-bpp modes. Dithering is performed in 16-, 8-, 4-, and 1-bpp mode.
		/// </summary>
		GRADIENT_FILL_TRIANGLE = 0x00000002,

		/// <summary>Undocumented.</summary>
		GRADIENT_FILL_OP_FLAG = 0x000000ff,
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

	/// <summary>Stretching mode.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "a4408e28-d7ac-44e9-905d-efa75c60e503")]
	public enum StretchMode : uint
	{
		/// <summary>
		/// Performs a Boolean AND operation using the color values for the eliminated and existing pixels. If the bitmap is a monochrome
		/// bitmap, this mode preserves black pixels at the expense of white pixels.
		/// </summary>
		BLACKONWHITE = 1,

		/// <summary>
		/// Performs a Boolean OR operation using the color values for the eliminated and existing pixels. If the bitmap is a monochrome
		/// bitmap, this mode preserves white pixels at the expense of black pixels.
		/// </summary>
		WHITEONBLACK = 2,

		/// <summary>Deletes the pixels. This mode deletes all eliminated lines of pixels without trying to preserve their information.</summary>
		COLORONCOLOR = 3,

		/// <summary>
		/// Maps pixels from the source rectangle into blocks of pixels in the destination rectangle. The average color over the
		/// destination block of pixels approximates the color of the source pixels.
		/// </summary>
		HALFTONE = 4,

		/// <summary>Same as BLACKONWHITE.</summary>
		STRETCH_ANDSCANS = BLACKONWHITE,

		/// <summary>Same as WHITEONBLACK.</summary>
		STRETCH_ORSCANS = WHITEONBLACK,

		/// <summary>Same as COLORONCOLOR.</summary>
		STRETCH_DELETESCANS = COLORONCOLOR,

		/// <summary>Same as HALFTONE.</summary>
		STRETCH_HALFTONE = HALFTONE,
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
	/// The <c>CreateBitmap</c> function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
	/// </summary>
	/// <param name="nWidth">The bitmap width, in pixels.</param>
	/// <param name="nHeight">The bitmap height, in pixels.</param>
	/// <param name="nPlanes">The number of color planes used by the device.</param>
	/// <param name="nBitCount">The number of bits required to identify the color of a single pixel.</param>
	/// <param name="lpBits">
	/// A pointer to an array of color data used to set the colors in a rectangle of pixels. Each scan line in the rectangle must be word
	/// aligned (scan lines that are not word aligned must be padded with zeros). If this parameter is <c>NULL</c>, the contents of the
	/// new bitmap is undefined.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to a bitmap.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// <para>This function can return the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_BITMAP</term>
	/// <term>The calculated size of the bitmap is less than zero.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>CreateBitmap</c> function creates a device-dependent bitmap.</para>
	/// <para>
	/// After a bitmap is created, it can be selected into a device context by calling the SelectObject function. However, the bitmap can
	/// only be selected into a device context if the bitmap and the DC have the same format.
	/// </para>
	/// <para>
	/// The <c>CreateBitmap</c> function can be used to create color bitmaps. However, for performance reasons applications should use
	/// <c>CreateBitmap</c> to create monochrome bitmaps and CreateCompatibleBitmap to create color bitmaps. Whenever a color bitmap
	/// returned from <c>CreateBitmap</c> is selected into a device context, the system checks that the bitmap matches the format of the
	/// device context it is being selected into. Because <c>CreateCompatibleBitmap</c> takes a device context, it returns a bitmap that
	/// has the same format as the specified device context. Thus, subsequent calls to SelectObject are faster with a color bitmap from
	/// <c>CreateCompatibleBitmap</c> than with a color bitmap returned from <c>CreateBitmap</c>.
	/// </para>
	/// <para>
	/// If the bitmap is monochrome, zeros represent the foreground color and ones represent the background color for the destination
	/// device context.
	/// </para>
	/// <para>
	/// If an application sets the nWidth or nHeight parameters to zero, <c>CreateBitmap</c> returns the handle to a 1-by-1 pixel,
	/// monochrome bitmap.
	/// </para>
	/// <para>When you no longer need the bitmap, call the DeleteObject function to delete it.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createbitmap HBITMAP CreateBitmap( int nWidth, int nHeight,
	// UINT nPlanes, UINT nBitCount, const VOID *lpBits );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "b52e1baf-6a81-44bc-a061-4d42e6f4ed64")]
	public static extern SafeHBITMAP CreateBitmap(int nWidth, int nHeight, uint nPlanes, uint nBitCount, [In, Optional] IntPtr lpBits);

	/// <summary>
	/// The <c>CreateBitmap</c> function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
	/// </summary>
	/// <param name="nWidth">The bitmap width, in pixels.</param>
	/// <param name="nHeight">The bitmap height, in pixels.</param>
	/// <param name="nPlanes">The number of color planes used by the device.</param>
	/// <param name="nBitCount">The number of bits required to identify the color of a single pixel.</param>
	/// <param name="lpBits">
	/// A pointer to an array of color data used to set the colors in a rectangle of pixels. Each scan line in the rectangle must be word
	/// aligned (scan lines that are not word aligned must be padded with zeros). If this parameter is <c>NULL</c>, the contents of the
	/// new bitmap is undefined.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to a bitmap.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// <para>This function can return the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_BITMAP</term>
	/// <term>The calculated size of the bitmap is less than zero.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>CreateBitmap</c> function creates a device-dependent bitmap.</para>
	/// <para>
	/// After a bitmap is created, it can be selected into a device context by calling the SelectObject function. However, the bitmap can
	/// only be selected into a device context if the bitmap and the DC have the same format.
	/// </para>
	/// <para>
	/// The <c>CreateBitmap</c> function can be used to create color bitmaps. However, for performance reasons applications should use
	/// <c>CreateBitmap</c> to create monochrome bitmaps and CreateCompatibleBitmap to create color bitmaps. Whenever a color bitmap
	/// returned from <c>CreateBitmap</c> is selected into a device context, the system checks that the bitmap matches the format of the
	/// device context it is being selected into. Because <c>CreateCompatibleBitmap</c> takes a device context, it returns a bitmap that
	/// has the same format as the specified device context. Thus, subsequent calls to SelectObject are faster with a color bitmap from
	/// <c>CreateCompatibleBitmap</c> than with a color bitmap returned from <c>CreateBitmap</c>.
	/// </para>
	/// <para>
	/// If the bitmap is monochrome, zeros represent the foreground color and ones represent the background color for the destination
	/// device context.
	/// </para>
	/// <para>
	/// If an application sets the nWidth or nHeight parameters to zero, <c>CreateBitmap</c> returns the handle to a 1-by-1 pixel,
	/// monochrome bitmap.
	/// </para>
	/// <para>When you no longer need the bitmap, call the DeleteObject function to delete it.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createbitmap HBITMAP CreateBitmap( int nWidth, int nHeight,
	// UINT nPlanes, UINT nBitCount, const VOID *lpBits );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "b52e1baf-6a81-44bc-a061-4d42e6f4ed64")]
	public static extern SafeHBITMAP CreateBitmap(int nWidth, int nHeight, uint nPlanes, uint nBitCount, [In, Optional] byte[]? lpBits);

	/// <summary>
	/// The <c>CreateBitmapIndirect</c> function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
	/// </summary>
	/// <param name="pbm">
	/// A pointer to a BITMAP structure that contains information about the bitmap. If an application sets the <c>bmWidth</c> or
	/// <c>bmHeight</c> members to zero, <c>CreateBitmapIndirect</c> returns the handle to a 1-by-1 pixel, monochrome bitmap.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the bitmap.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// <para>This function can return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the input parameters is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The bitmap is too big for memory to be allocated.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>CreateBitmapIndirect</c> function creates a device-dependent bitmap.</para>
	/// <para>
	/// After a bitmap is created, it can be selected into a device context by calling the SelectObject function. However, the bitmap can
	/// only be selected into a device context if the bitmap and the DC have the same format.
	/// </para>
	/// <para>
	/// While the <c>CreateBitmapIndirect</c> function can be used to create color bitmaps, for performance reasons applications should
	/// use <c>CreateBitmapIndirect</c> to create monochrome bitmaps and CreateCompatibleBitmap to create color bitmaps. Whenever a color
	/// bitmap from <c>CreateBitmapIndirect</c> is selected into a device context, the system must ensure that the bitmap matches the
	/// format of the device context it is being selected into. Because <c>CreateCompatibleBitmap</c> takes a device context, it returns
	/// a bitmap that has the same format as the specified device context. Thus, subsequent calls to SelectObject are faster with a color
	/// bitmap from <c>CreateCompatibleBitmap</c> than with a color bitmap returned from <c>CreateBitmapIndirect</c>.
	/// </para>
	/// <para>
	/// If the bitmap is monochrome, zeros represent the foreground color and ones represent the background color for the destination
	/// device context.
	/// </para>
	/// <para>When you no longer need the bitmap, call the DeleteObject function to delete it.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createbitmapindirect HBITMAP CreateBitmapIndirect( const
	// BITMAP *pbm );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "79f73e28-4ee3-472d-9a20-3ffe7cf2a6b5")]
	public static extern SafeHBITMAP CreateBitmapIndirect(in BITMAP pbm);

	/// <summary>
	/// The <c>CreateCompatibleBitmap</c> function creates a bitmap compatible with the device that is associated with the specified
	/// device context.
	/// </summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="cx">The bitmap width, in pixels.</param>
	/// <param name="cy">The bitmap height, in pixels.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the compatible bitmap (DDB).</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The color format of the bitmap created by the <c>CreateCompatibleBitmap</c> function matches the color format of the device
	/// identified by the hdc parameter. This bitmap can be selected into any memory device context that is compatible with the original device.
	/// </para>
	/// <para>
	/// Because memory device contexts allow both color and monochrome bitmaps, the format of the bitmap returned by the
	/// <c>CreateCompatibleBitmap</c> function differs when the specified device context is a memory device context. However, a
	/// compatible bitmap that was created for a nonmemory device context always possesses the same color format and uses the same color
	/// palette as the specified device context.
	/// </para>
	/// <para>
	/// Note: When a memory device context is created, it initially has a 1-by-1 monochrome bitmap selected into it. If this memory
	/// device context is used in <c>CreateCompatibleBitmap</c>, the bitmap that is created is a monochrome bitmap. To create a color
	/// bitmap, use the <c>HDC</c> that was used to create the memory device context, as shown in the following code:
	/// </para>
	/// <para>
	/// If an application sets the nWidth or nHeight parameters to zero, <c>CreateCompatibleBitmap</c> returns the handle to a 1-by-1
	/// pixel, monochrome bitmap.
	/// </para>
	/// <para>
	/// If a DIB section, which is a bitmap created by the CreateDIBSection function, is selected into the device context identified by
	/// the hdc parameter, <c>CreateCompatibleBitmap</c> creates a DIB section.
	/// </para>
	/// <para>When you no longer need the bitmap, call the DeleteObject function to delete it.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Scaling an Image.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createcompatiblebitmap HBITMAP CreateCompatibleBitmap( HDC
	// hdc, int cx, int cy );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d2866beb-ff7a-4390-8651-e7bf458ddf88")]
	public static extern SafeHBITMAP CreateCompatibleBitmap(HDC hdc, int cx, int cy);

	/// <summary>
	/// The <c>CreateDIBitmap</c> function creates a compatible bitmap (DDB) from a DIB and, optionally, sets the bitmap bits.
	/// </summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="pbmih">
	/// <para>A pointer to a bitmap information header structure, BITMAPV5HEADER.</para>
	/// <para>
	/// If fdwInit is CBM_INIT, the function uses the bitmap information header structure to obtain the desired width and height of the
	/// bitmap as well as other information. Note that a positive value for the height indicates a bottom-up DIB while a negative value
	/// for the height indicates a top-down DIB. Calling <c>CreateDIBitmap</c> with fdwInit as CBM_INIT is equivalent to calling the
	/// CreateCompatibleBitmap function to create a DDB in the format of the device and then calling the SetDIBits function to translate
	/// the DIB bits to the DDB.
	/// </para>
	/// </param>
	/// <param name="flInit">
	/// <para>Specifies how the system initializes the bitmap bits. The following value is defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CBM_INIT</term>
	/// <term>
	/// If this flag is set, the system uses the data pointed to by the lpbInit and lpbmi parameters to initialize the bitmap bits. If
	/// this flag is clear, the data pointed to by those parameters is not used.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If fdwInit is zero, the system does not initialize the bitmap bits.</para>
	/// </param>
	/// <param name="pjBits">
	/// A pointer to an array of bytes containing the initial bitmap data. The format of the data depends on the <c>biBitCount</c> member
	/// of the BITMAPINFO structure to which the lpbmi parameter points.
	/// </param>
	/// <param name="pbmi">
	/// A pointer to a BITMAPINFO structure that describes the dimensions and color format of the array pointed to by the lpbInit parameter.
	/// </param>
	/// <param name="iUsage">
	/// <para>
	/// Specifies whether the <c>bmiColors</c> member of the BITMAPINFO structure was initialized and, if so, whether <c>bmiColors</c>
	/// contains explicit red, green, blue (RGB) values or palette indexes. The fuUsage parameter must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>
	/// A color table is provided and consists of an array of 16-bit indexes into the logical palette of the device context into which
	/// the bitmap is to be selected.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>A color table is provided and contains literal RGB values.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the compatible bitmap.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The DDB that is created will be whatever bit depth your reference DC is. To create a bitmap that is of different bit depth, use CreateDIBSection.
	/// </para>
	/// <para>
	/// For a device to reach optimal bitmap-drawing speed, specify fdwInit as CBM_INIT. Then, use the same color depth DIB as the video
	/// mode. When the video is running 4- or 8-bpp, use DIB_PAL_COLORS.
	/// </para>
	/// <para>The CBM_CREATDIB flag for the fdwInit parameter is no longer supported.</para>
	/// <para>When you no longer need the bitmap, call the DeleteObject function to delete it.</para>
	/// <para>
	/// <c>ICM:</c> No color management is performed. The contents of the resulting bitmap are not color matched after the bitmap has
	/// been created.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdibitmap HBITMAP CreateDIBitmap( HDC hdc, const
	// BITMAPINFOHEADER *pbmih, DWORD flInit, const VOID *pjBits, const BITMAPINFO *pbmi, UINT iUsage );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "e9a5b525-a6b6-4309-9e53-69d274b85783")]
	public static extern SafeHBITMAP CreateDIBitmap(HDC hdc, in BITMAPINFOHEADER pbmih, CBM flInit, [In, Optional] byte[]? pjBits, [In, Optional] SafeBITMAPINFO pbmi, DIBColorMode iUsage);

	/// <summary>
	/// The <c>CreateDIBitmap</c> function creates a compatible bitmap (DDB) from a DIB and, optionally, sets the bitmap bits.
	/// </summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="pbmih">
	/// <para>A pointer to a bitmap information header structure, BITMAPV5HEADER.</para>
	/// <para>
	/// If fdwInit is CBM_INIT, the function uses the bitmap information header structure to obtain the desired width and height of the
	/// bitmap as well as other information. Note that a positive value for the height indicates a bottom-up DIB while a negative value
	/// for the height indicates a top-down DIB. Calling <c>CreateDIBitmap</c> with fdwInit as CBM_INIT is equivalent to calling the
	/// CreateCompatibleBitmap function to create a DDB in the format of the device and then calling the SetDIBits function to translate
	/// the DIB bits to the DDB.
	/// </para>
	/// </param>
	/// <param name="flInit">
	/// <para>Specifies how the system initializes the bitmap bits. The following value is defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CBM_INIT</term>
	/// <term>
	/// If this flag is set, the system uses the data pointed to by the lpbInit and lpbmi parameters to initialize the bitmap bits. If
	/// this flag is clear, the data pointed to by those parameters is not used.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If fdwInit is zero, the system does not initialize the bitmap bits.</para>
	/// </param>
	/// <param name="pjBits">
	/// A pointer to an array of bytes containing the initial bitmap data. The format of the data depends on the <c>biBitCount</c> member
	/// of the BITMAPINFO structure to which the lpbmi parameter points.
	/// </param>
	/// <param name="pbmi">
	/// A pointer to a BITMAPINFO structure that describes the dimensions and color format of the array pointed to by the lpbInit parameter.
	/// </param>
	/// <param name="iUsage">
	/// <para>
	/// Specifies whether the <c>bmiColors</c> member of the BITMAPINFO structure was initialized and, if so, whether <c>bmiColors</c>
	/// contains explicit red, green, blue (RGB) values or palette indexes. The fuUsage parameter must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>
	/// A color table is provided and consists of an array of 16-bit indexes into the logical palette of the device context into which
	/// the bitmap is to be selected.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>A color table is provided and contains literal RGB values.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the compatible bitmap.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The DDB that is created will be whatever bit depth your reference DC is. To create a bitmap that is of different bit depth, use CreateDIBSection.
	/// </para>
	/// <para>
	/// For a device to reach optimal bitmap-drawing speed, specify fdwInit as CBM_INIT. Then, use the same color depth DIB as the video
	/// mode. When the video is running 4- or 8-bpp, use DIB_PAL_COLORS.
	/// </para>
	/// <para>The CBM_CREATDIB flag for the fdwInit parameter is no longer supported.</para>
	/// <para>When you no longer need the bitmap, call the DeleteObject function to delete it.</para>
	/// <para>
	/// <c>ICM:</c> No color management is performed. The contents of the resulting bitmap are not color matched after the bitmap has
	/// been created.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdibitmap HBITMAP CreateDIBitmap( HDC hdc, const
	// BITMAPINFOHEADER *pbmih, DWORD flInit, const VOID *pjBits, const BITMAPINFO *pbmi, UINT iUsage );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "e9a5b525-a6b6-4309-9e53-69d274b85783")]
	public static extern SafeHBITMAP CreateDIBitmap(HDC hdc, [In, Optional] IntPtr pbmih, CBM flInit, [In, Optional] byte[]? pjBits, [In, Optional] SafeBITMAPINFO pbmi, DIBColorMode iUsage);

	/// <summary>The <c>CreateDIBitmap</c> function creates a compatible bitmap (DDB) from a DIB and, optionally, sets the bitmap bits.</summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="pbmih">
	/// <para>A pointer to a bitmap information header structure, BITMAPV5HEADER.</para>
	/// <para>
	/// If <c>fdwInit</c> is CBM_INIT, the function uses the bitmap information header structure to obtain the desired width and height of
	/// the bitmap as well as other information. Note that a positive value for the height indicates a bottom-up DIB while a negative value
	/// for the height indicates a top-down DIB. Calling <c>CreateDIBitmap</c> with <c>fdwInit</c> as CBM_INIT is equivalent to calling the
	/// CreateCompatibleBitmap function to create a DDB in the format of the device and then calling the SetDIBits function to translate the
	/// DIB bits to the DDB.
	/// </para>
	/// </param>
	/// <param name="flInit">
	/// <para>Specifies how the system initializes the bitmap bits. The following value is defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>CBM_INIT</c></description>
	/// <description>
	/// If this flag is set, the system uses the data pointed to by the <c>lpbInit</c> and <c>lpbmi</c> parameters to initialize the bitmap
	/// bits. If this flag is clear, the data pointed to by those parameters is not used.
	/// </description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>If <c>fdwInit</c> is zero, the system does not initialize the bitmap bits.</para>
	/// </param>
	/// <param name="pjBits">
	/// A pointer to an array of bytes containing the initial bitmap data. The format of the data depends on the <c>biBitCount</c> member of
	/// the BITMAPINFO structure to which the <c>lpbmi</c> parameter points.
	/// </param>
	/// <param name="pbmi">
	/// A pointer to a BITMAPINFO structure that describes the dimensions and color format of the array pointed to by the <c>lpbInit</c> parameter.
	/// </param>
	/// <param name="iUsage">
	/// <para>
	/// Specifies whether the <c>bmiColors</c> member of the BITMAPINFO structure was initialized and, if so, whether <c>bmiColors</c>
	/// contains explicit red, green, blue (RGB) values or palette indexes. The <c>fuUsage</c> parameter must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>DIB_PAL_COLORS</c></description>
	/// <description>
	/// A color table is provided and consists of an array of 16-bit indexes into the logical palette of the device context into which the
	/// bitmap is to be selected.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>DIB_RGB_COLORS</c></description>
	/// <description>A color table is provided and contains literal RGB values.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the compatible bitmap.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The DDB that is created will be whatever bit depth your reference DC is. To create a bitmap that is of different bit depth, use CreateDIBSection.
	/// </para>
	/// <para>
	/// For a device to reach optimal bitmap-drawing speed, specify <c>fdwInit</c> as CBM_INIT. Then, use the same color depth DIB as the
	/// video mode. When the video is running 4- or 8-bpp, use DIB_PAL_COLORS.
	/// </para>
	/// <para>The CBM_CREATDIB flag for the <c>fdwInit</c> parameter is no longer supported.</para>
	/// <para>When you no longer need the bitmap, call the DeleteObject function to delete it.</para>
	/// <para>
	/// <c>ICM:</c> No color management is performed. The contents of the resulting bitmap are not color matched after the bitmap has been created.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdibitmap HBITMAP CreateDIBitmap( [in] HDC hdc, [in] const
	// BITMAPINFOHEADER *pbmih, [in] DWORD flInit, [in] const VOID *pjBits, [in] const BITMAPINFO *pbmi, [in] UINT iUsage );
	[PInvokeData("wingdi.h", MSDNShortId = "NF:wingdi.CreateDIBitmap")]
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	public static extern unsafe SafeHBITMAP CreateDIBitmap([In] HDC hdc, [In] BITMAPINFOHEADER* pbmih, CBM flInit, [In] void* pjBits, [In] BITMAPINFO_UNMGD* pbmi, DIBColorMode iUsage);

	/// <summary>
	/// The <c>CreateDIBSection</c> function creates a DIB that applications can write to directly. The function gives you a pointer to
	/// the location of the bitmap bit values. You can supply a handle to a file-mapping object that the function will use to create the
	/// bitmap, or you can let the system allocate the memory for the bitmap.
	/// </summary>
	/// <param name="hdc">
	/// A handle to a device context. If the value of iUsage is DIB_PAL_COLORS, the function uses this device context's logical palette
	/// to initialize the DIB colors.
	/// </param>
	/// <param name="pbmi">
	/// A pointer to a BITMAPINFO structure that specifies various attributes of the DIB, including the bitmap dimensions and colors.
	/// </param>
	/// <param name="usage">
	/// <para>
	/// The type of data contained in the <c>bmiColors</c> array member of the BITMAPINFO structure pointed to by pbmi (either logical
	/// palette indexes or literal RGB values). The following values are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>The bmiColors member is an array of 16-bit indexes into the logical palette of the device context specified by hdc.</term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>The BITMAPINFO structure contains an array of literal RGB values.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppvBits">A pointer to a variable that receives a pointer to the location of the DIB bit values.</param>
	/// <param name="hSection">
	/// <para>A handle to a file-mapping object that the function will use to create the DIB. This parameter can be <c>NULL</c>.</para>
	/// <para>
	/// If hSection is not <c>NULL</c>, it must be a handle to a file-mapping object created by calling the CreateFileMapping function
	/// with the PAGE_READWRITE or PAGE_WRITECOPY flag. Read-only DIB sections are not supported. Handles created by other means will
	/// cause <c>CreateDIBSection</c> to fail.
	/// </para>
	/// <para>
	/// If hSection is not <c>NULL</c>, the <c>CreateDIBSection</c> function locates the bitmap bit values at offset dwOffset in the
	/// file-mapping object referred to by hSection. An application can later retrieve the hSection handle by calling the GetObject
	/// function with the <c>HBITMAP</c> returned by <c>CreateDIBSection</c>.
	/// </para>
	/// <para>
	/// If hSection is <c>NULL</c>, the system allocates memory for the DIB. In this case, the <c>CreateDIBSection</c> function ignores
	/// the dwOffset parameter. An application cannot later obtain a handle to this memory. The <c>dshSection</c> member of the
	/// DIBSECTION structure filled in by calling the GetObject function will be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="offset">
	/// The offset from the beginning of the file-mapping object referenced by hSection where storage for the bitmap bit values is to
	/// begin. This value is ignored if hSection is <c>NULL</c>. The bitmap bit values are aligned on doubleword boundaries, so dwOffset
	/// must be a multiple of the size of a <c>DWORD</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the newly created DIB, and *ppvBits points to the bitmap bit values.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>, and *ppvBits is <c>NULL</c>.</para>
	/// <para>This function can return the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the input parameters is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// As noted above, if hSection is <c>NULL</c>, the system allocates memory for the DIB. The system closes the handle to that memory
	/// when you later delete the DIB by calling the DeleteObject function. If hSection is not <c>NULL</c>, you must close the hSection
	/// memory handle yourself after calling <c>DeleteObject</c> to delete the bitmap.
	/// </para>
	/// <para>You cannot paste a DIB section from one application into another application.</para>
	/// <para>
	/// <c>CreateDIBSection</c> does not use the BITMAPINFOHEADER parameters biXPelsPerMeter or biYPelsPerMeter and will not provide
	/// resolution information in the BITMAPINFO structure.
	/// </para>
	/// <para>
	/// You need to guarantee that the GDI subsystem has completed any drawing to a bitmap created by <c>CreateDIBSection</c> before you
	/// draw to the bitmap yourself. Access to the bitmap must be synchronized. Do this by calling the GdiFlush function. This applies to
	/// any use of the pointer to the bitmap bit values, including passing the pointer in calls to functions such as SetDIBits.
	/// </para>
	/// <para><c>ICM:</c> No color management is done.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdibsection HBITMAP CreateDIBSection( HDC hdc, const
	// BITMAPINFO *pbmi, UINT usage, VOID **ppvBits, HANDLE hSection, DWORD offset );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "9276ec84-2860-42be-a9f8-d4efb8d25eec")]
	public static extern SafeHBITMAP CreateDIBSection([In, Optional] HDC hdc, in BITMAPINFO pbmi, DIBColorMode usage, out IntPtr ppvBits, [In, Optional] HSECTION hSection, [In, Optional] uint offset);

	/// <summary>
	/// The <c>CreateDIBSection</c> function creates a DIB that applications can write to directly. The function gives you a pointer to
	/// the location of the bitmap bit values. You can supply a handle to a file-mapping object that the function will use to create the
	/// bitmap, or you can let the system allocate the memory for the bitmap.
	/// </summary>
	/// <param name="hdc">
	/// A handle to a device context. If the value of iUsage is DIB_PAL_COLORS, the function uses this device context's logical palette
	/// to initialize the DIB colors.
	/// </param>
	/// <param name="pbmi">
	/// A pointer to a BITMAPINFO structure that specifies various attributes of the DIB, including the bitmap dimensions and colors.
	/// </param>
	/// <param name="usage">
	/// <para>
	/// The type of data contained in the <c>bmiColors</c> array member of the BITMAPINFO structure pointed to by pbmi (either logical
	/// palette indexes or literal RGB values). The following values are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>The bmiColors member is an array of 16-bit indexes into the logical palette of the device context specified by hdc.</term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>The BITMAPINFO structure contains an array of literal RGB values.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppvBits">A pointer to a variable that receives a pointer to the location of the DIB bit values.</param>
	/// <param name="hSection">
	/// <para>A handle to a file-mapping object that the function will use to create the DIB. This parameter can be <c>NULL</c>.</para>
	/// <para>
	/// If hSection is not <c>NULL</c>, it must be a handle to a file-mapping object created by calling the CreateFileMapping function
	/// with the PAGE_READWRITE or PAGE_WRITECOPY flag. Read-only DIB sections are not supported. Handles created by other means will
	/// cause <c>CreateDIBSection</c> to fail.
	/// </para>
	/// <para>
	/// If hSection is not <c>NULL</c>, the <c>CreateDIBSection</c> function locates the bitmap bit values at offset dwOffset in the
	/// file-mapping object referred to by hSection. An application can later retrieve the hSection handle by calling the GetObject
	/// function with the <c>HBITMAP</c> returned by <c>CreateDIBSection</c>.
	/// </para>
	/// <para>
	/// If hSection is <c>NULL</c>, the system allocates memory for the DIB. In this case, the <c>CreateDIBSection</c> function ignores
	/// the dwOffset parameter. An application cannot later obtain a handle to this memory. The <c>dshSection</c> member of the
	/// DIBSECTION structure filled in by calling the GetObject function will be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="offset">
	/// The offset from the beginning of the file-mapping object referenced by hSection where storage for the bitmap bit values is to
	/// begin. This value is ignored if hSection is <c>NULL</c>. The bitmap bit values are aligned on doubleword boundaries, so dwOffset
	/// must be a multiple of the size of a <c>DWORD</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the newly created DIB, and *ppvBits points to the bitmap bit values.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>, and *ppvBits is <c>NULL</c>.</para>
	/// <para>This function can return the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the input parameters is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// As noted above, if hSection is <c>NULL</c>, the system allocates memory for the DIB. The system closes the handle to that memory
	/// when you later delete the DIB by calling the DeleteObject function. If hSection is not <c>NULL</c>, you must close the hSection
	/// memory handle yourself after calling <c>DeleteObject</c> to delete the bitmap.
	/// </para>
	/// <para>You cannot paste a DIB section from one application into another application.</para>
	/// <para>
	/// <c>CreateDIBSection</c> does not use the BITMAPINFOHEADER parameters biXPelsPerMeter or biYPelsPerMeter and will not provide
	/// resolution information in the BITMAPINFO structure.
	/// </para>
	/// <para>
	/// You need to guarantee that the GDI subsystem has completed any drawing to a bitmap created by <c>CreateDIBSection</c> before you
	/// draw to the bitmap yourself. Access to the bitmap must be synchronized. Do this by calling the GdiFlush function. This applies to
	/// any use of the pointer to the bitmap bit values, including passing the pointer in calls to functions such as SetDIBits.
	/// </para>
	/// <para><c>ICM:</c> No color management is done.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdibsection HBITMAP CreateDIBSection( HDC hdc, const
	// BITMAPINFO *pbmi, UINT usage, VOID **ppvBits, HANDLE hSection, DWORD offset );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "9276ec84-2860-42be-a9f8-d4efb8d25eec")]
	public static extern SafeHBITMAP CreateDIBSection([In, Optional] HDC hdc, [In] SafeBITMAPINFO pbmi, DIBColorMode usage, out IntPtr ppvBits, [In, Optional] HSECTION hSection, [In, Optional] uint offset);

	/// <summary>
	/// <para>
	/// The <c>CreateDiscardableBitmap</c> function creates a discardable bitmap that is compatible with the specified device. The bitmap
	/// has the same bits-per-pixel format and the same color palette as the device. An application can select this bitmap as the current
	/// bitmap for a memory device that is compatible with the specified device.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// CreateCompatibleBitmap function.
	/// </para>
	/// </summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="cx">The width, in pixels, of the bitmap.</param>
	/// <param name="cy">The height, in pixels, of the bitmap.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the compatible bitmap (DDB).</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>When you no longer need the bitmap, call the DeleteObject function to delete it.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-creatediscardablebitmap HBITMAP CreateDiscardableBitmap( HDC
	// hdc, int cx, int cy );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "79168baf-26ea-4d24-b75c-d0658a56892c")]
	public static extern SafeHBITMAP CreateDiscardableBitmap(HDC hdc, int cx, int cy);

	/// <summary>The <c>ExtFloodFill</c> function fills an area of the display surface with the current brush.</summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="x">The x-coordinate, in logical units, of the point where filling is to start.</param>
	/// <param name="y">The y-coordinate, in logical units, of the point where filling is to start.</param>
	/// <param name="color">
	/// The color of the boundary or of the area to be filled. The interpretation of crColor depends on the value of the fuFillType
	/// parameter. To create a COLORREF color value, use the RGB macro.
	/// </param>
	/// <param name="type">
	/// <para>The type of fill operation to be performed. This parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FLOODFILLBORDER</term>
	/// <term>
	/// The fill area is bounded by the color specified by the crColor parameter. This style is identical to the filling performed by the
	/// FloodFill function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FLOODFILLSURFACE</term>
	/// <term>
	/// The fill area is defined by the color that is specified by crColor. Filling continues outward in all directions as long as the
	/// color is encountered. This style is useful for filling areas with multicolored boundaries.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following are some of the reasons this function might fail:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The filling could not be completed.</term>
	/// </item>
	/// <item>
	/// <term>The specified point has the boundary color specified by the crColor parameter (if FLOODFILLBORDER was requested).</term>
	/// </item>
	/// <item>
	/// <term>The specified point does not have the color specified by crColor (if FLOODFILLSURFACE was requested).</term>
	/// </item>
	/// <item>
	/// <term>The point is outside the clipping regionthat is, it is not visible on the device.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the fuFillType parameter is FLOODFILLBORDER, the system assumes that the area to be filled is completely bounded by the color
	/// specified by the crColor parameter. The function begins filling at the point specified by the nXStart and nYStart parameters and
	/// continues in all directions until it reaches the boundary.
	/// </para>
	/// <para>
	/// If fuFillType is FLOODFILLSURFACE, the system assumes that the area to be filled is a single color. The function begins to fill
	/// the area at the point specified by nXStart and nYStart and continues in all directions, filling all adjacent regions containing
	/// the color specified by crColor.
	/// </para>
	/// <para>
	/// Only memory device contexts and devices that support raster-display operations support the <c>ExtFloodFill</c> function. To
	/// determine whether a device supports this technology, use the GetDeviceCaps function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see "Adding Lines and Graphs to a Menu" in Using Menus.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-extfloodfill BOOL ExtFloodFill( HDC hdc, int x, int y,
	// COLORREF color, UINT type );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "b996d47d-5aaf-4b13-8643-209744e5a04b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ExtFloodFill(HDC hdc, int x, int y, COLORREF color, FloodFillType type);

	/// <summary>
	/// <para>
	/// The <c>FloodFill</c> function fills an area of the display surface with the current brush. The area is assumed to be bounded as
	/// specified by the crFill parameter.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>FloodFill</c> function is included only for compatibility with 16-bit versions of Windows. Applications should
	/// use the ExtFloodFill function with FLOODFILLBORDER specified.
	/// </para>
	/// </summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="x">The x-coordinate, in logical units, of the point where filling is to start.</param>
	/// <param name="y">The y-coordinate, in logical units, of the point where filling is to start.</param>
	/// <param name="color">The color of the boundary or the area to be filled. To create a COLORREF color value, use the RGB macro.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following are reasons this function might fail:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The fill could not be completed.</term>
	/// </item>
	/// <item>
	/// <term>The given point has the boundary color specified by the crFill parameter.</term>
	/// </item>
	/// <item>
	/// <term>The given point lies outside the current clipping regionthat is, it is not visible on the device.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-floodfill
	// BOOL FloodFill( HDC hdc, int x, int y, COLORREF color );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "e53bebb5-4e46-4ea4-8d41-c12f4c6645ef")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FloodFill(HDC hdc, int x, int y, COLORREF color);

	/// <summary>
	/// <para>The <c>GetBitmapBits</c> function copies the bitmap bits of a specified device-dependent bitmap into a buffer.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// GetDIBits function.
	/// </para>
	/// </summary>
	/// <param name="hbit">A handle to the device-dependent bitmap.</param>
	/// <param name="cb">The number of bytes to copy from the bitmap into the buffer.</param>
	/// <param name="lpvBits">A pointer to a buffer to receive the bitmap bits. The bits are stored as an array of byte values.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of bytes copied to the buffer.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getbitmapbits LONG GetBitmapBits( HBITMAP hbit, LONG cb,
	// LPVOID lpvBits );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "72e8cc6b-d282-451e-b6ec-0473d2daea7c")]
	public static extern int GetBitmapBits(HBITMAP hbit, int cb, byte[] lpvBits);

	/// <summary>
	/// The <c>GetBitmapDimensionEx</c> function retrieves the dimensions of a compatible bitmap. The retrieved dimensions must have been
	/// set by the SetBitmapDimensionEx function.
	/// </summary>
	/// <param name="hbit">A handle to a compatible bitmap (DDB).</param>
	/// <param name="lpsize">A pointer to a SIZE structure to receive the bitmap dimensions. For more information, see Remarks.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The function returns a data structure that contains fields for the height and width of the bitmap, in .01-mm units. If those
	/// dimensions have not yet been set, the structure that is returned will have zeros in those fields.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getbitmapdimensionex BOOL GetBitmapDimensionEx( HBITMAP hbit,
	// LPSIZE lpsize );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3e4f5afc-26d3-4fb2-8d00-183165fdf471")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetBitmapDimensionEx(HBITMAP hbit, out SIZE lpsize);

	/// <summary>
	/// The <c>GetDIBColorTable</c> function retrieves RGB (red, green, blue) color values from a range of entries in the color table of
	/// the DIB section bitmap that is currently selected into a specified device context.
	/// </summary>
	/// <param name="hdc">A handle to a device context. A DIB section bitmap must be selected into this device context.</param>
	/// <param name="iStart">A zero-based color table index that specifies the first color table entry to retrieve.</param>
	/// <param name="cEntries">The number of color table entries to retrieve.</param>
	/// <param name="prgbq">
	/// A pointer to a buffer that receives an array of RGBQUAD data structures containing color information from the DIB color table.
	/// The buffer must be large enough to contain as many <c>RGBQUAD</c> data structures as the value of cEntries.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of color table entries that the function retrieves.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The <c>GetDIBColorTable</c> function should be called to retrieve the color table for DIB section bitmaps that use 1, 4, or 8
	/// bpp. The <c>biBitCount</c> member of a bitmap associated BITMAPINFOHEADER structure specifies the number of bits-per-pixel. DIB
	/// section bitmaps with a <c>biBitCount</c> value greater than eight do not have a color table, but they do have associated color
	/// masks. Call the GetObject function to retrieve those color masks.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdibcolortable UINT GetDIBColorTable( HDC hdc, UINT iStart,
	// UINT cEntries, RGBQUAD *prgbq );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3e3319be-8a3d-4ac2-ba36-9dbf18243472")]
	public static extern uint GetDIBColorTable(HDC hdc, uint iStart, uint cEntries, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RGBQUAD[] prgbq);

	/// <summary>
	/// The <c>GetDIBits</c> function retrieves the bits of the specified compatible bitmap and copies them into a buffer as a DIB using
	/// the specified format.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="hbm">A handle to the bitmap. This must be a compatible bitmap (DDB).</param>
	/// <param name="start">The first scan line to retrieve.</param>
	/// <param name="cLines">The number of scan lines to retrieve.</param>
	/// <param name="lpvBits">
	/// A pointer to a buffer to receive the bitmap data. If this parameter is <c>NULL</c>, the function passes the dimensions and format
	/// of the bitmap to the BITMAPINFO structure pointed to by the lpbi parameter.
	/// </param>
	/// <param name="lpbmi">A pointer to a BITMAPINFO structure that specifies the desired format for the DIB data.</param>
	/// <param name="usage">
	/// <para>The format of the <c>bmiColors</c> member of the BITMAPINFO structure. It must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>The color table should consist of an array of 16-bit indexes into the current logical palette.</term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>The color table should consist of literal red, green, blue (RGB) values.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the lpvBits parameter is non- <c>NULL</c> and the function succeeds, the return value is the number of scan lines copied from
	/// the bitmap.
	/// </para>
	/// <para>
	/// If the lpvBits parameter is <c>NULL</c> and <c>GetDIBits</c> successfully fills the BITMAPINFO structure, the return value is nonzero.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>This function can return the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the input parameters is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the requested format for the DIB matches its internal format, the RGB values for the bitmap are copied. If the requested
	/// format doesn't match the internal format, a color table is synthesized. The following table describes the color table synthesized
	/// for each format.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1_BPP</term>
	/// <term>The color table consists of a black and a white entry.</term>
	/// </item>
	/// <item>
	/// <term>4_BPP</term>
	/// <term>The color table consists of a mix of colors identical to the standard VGA palette.</term>
	/// </item>
	/// <item>
	/// <term>8_BPP</term>
	/// <term>
	/// The color table consists of a general mix of 256 colors defined by GDI. (Included in these 256 colors are the 20 colors found in
	/// the default logical palette.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>24_BPP</term>
	/// <term>No color table is returned.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the lpvBits parameter is a valid pointer, the first six members of the BITMAPINFOHEADER structure must be initialized to
	/// specify the size and format of the DIB. The scan lines must be aligned on a <c>DWORD</c> except for RLE compressed bitmaps.
	/// </para>
	/// <para>
	/// A bottom-up DIB is specified by setting the height to a positive number, while a top-down DIB is specified by setting the height
	/// to a negative number. The bitmap color table will be appended to the BITMAPINFO structure.
	/// </para>
	/// <para>
	/// If lpvBits is <c>NULL</c>, <c>GetDIBits</c> examines the first member of the first structure pointed to by lpbi. This member must
	/// specify the size, in bytes, of a BITMAPCOREHEADER or a BITMAPINFOHEADER structure. The function uses the specified size to
	/// determine how the remaining members should be initialized.
	/// </para>
	/// <para>
	/// If lpvBits is <c>NULL</c> and the bit count member of BITMAPINFO is initialized to zero, <c>GetDIBits</c> fills in a
	/// BITMAPINFOHEADER structure or BITMAPCOREHEADER without the color table. This technique can be used to query bitmap attributes.
	/// </para>
	/// <para>
	/// The bitmap identified by the hbmp parameter must not be selected into a device context when the application calls this function.
	/// </para>
	/// <para>
	/// The origin for a bottom-up DIB is the lower-left corner of the bitmap; the origin for a top-down DIB is the upper-left corner.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Capturing an Image.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdibits int GetDIBits( HDC hdc, HBITMAP hbm, UINT start,
	// UINT cLines, LPVOID lpvBits, LPBITMAPINFO lpbmi, UINT usage );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "be3ffa3f-b343-4e38-8b1e-aeccf35d92b8")]
	public static extern int GetDIBits([In] HDC hdc, [In] HBITMAP hbm, uint start, uint cLines, [Out, Optional] byte[]? lpvBits, ref BITMAPINFO lpbmi, DIBColorMode usage);

	/// <summary>
	/// The <c>GetDIBits</c> function retrieves the bits of the specified compatible bitmap and copies them into a buffer as a DIB using
	/// the specified format.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="hbm">A handle to the bitmap. This must be a compatible bitmap (DDB).</param>
	/// <param name="start">The first scan line to retrieve.</param>
	/// <param name="cLines">The number of scan lines to retrieve.</param>
	/// <param name="lpvBits">
	/// A pointer to a buffer to receive the bitmap data. If this parameter is <c>NULL</c>, the function passes the dimensions and format
	/// of the bitmap to the BITMAPINFO structure pointed to by the lpbi parameter.
	/// </param>
	/// <param name="lpbmi">A pointer to a BITMAPINFO structure that specifies the desired format for the DIB data.</param>
	/// <param name="usage">
	/// <para>The format of the <c>bmiColors</c> member of the BITMAPINFO structure. It must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>The color table should consist of an array of 16-bit indexes into the current logical palette.</term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>The color table should consist of literal red, green, blue (RGB) values.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the lpvBits parameter is non- <c>NULL</c> and the function succeeds, the return value is the number of scan lines copied from
	/// the bitmap.
	/// </para>
	/// <para>
	/// If the lpvBits parameter is <c>NULL</c> and <c>GetDIBits</c> successfully fills the BITMAPINFO structure, the return value is nonzero.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>This function can return the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the input parameters is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the requested format for the DIB matches its internal format, the RGB values for the bitmap are copied. If the requested
	/// format doesn't match the internal format, a color table is synthesized. The following table describes the color table synthesized
	/// for each format.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1_BPP</term>
	/// <term>The color table consists of a black and a white entry.</term>
	/// </item>
	/// <item>
	/// <term>4_BPP</term>
	/// <term>The color table consists of a mix of colors identical to the standard VGA palette.</term>
	/// </item>
	/// <item>
	/// <term>8_BPP</term>
	/// <term>
	/// The color table consists of a general mix of 256 colors defined by GDI. (Included in these 256 colors are the 20 colors found in
	/// the default logical palette.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>24_BPP</term>
	/// <term>No color table is returned.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the lpvBits parameter is a valid pointer, the first six members of the BITMAPINFOHEADER structure must be initialized to
	/// specify the size and format of the DIB. The scan lines must be aligned on a <c>DWORD</c> except for RLE compressed bitmaps.
	/// </para>
	/// <para>
	/// A bottom-up DIB is specified by setting the height to a positive number, while a top-down DIB is specified by setting the height
	/// to a negative number. The bitmap color table will be appended to the BITMAPINFO structure.
	/// </para>
	/// <para>
	/// If lpvBits is <c>NULL</c>, <c>GetDIBits</c> examines the first member of the first structure pointed to by lpbi. This member must
	/// specify the size, in bytes, of a BITMAPCOREHEADER or a BITMAPINFOHEADER structure. The function uses the specified size to
	/// determine how the remaining members should be initialized.
	/// </para>
	/// <para>
	/// If lpvBits is <c>NULL</c> and the bit count member of BITMAPINFO is initialized to zero, <c>GetDIBits</c> fills in a
	/// BITMAPINFOHEADER structure or BITMAPCOREHEADER without the color table. This technique can be used to query bitmap attributes.
	/// </para>
	/// <para>
	/// The bitmap identified by the hbmp parameter must not be selected into a device context when the application calls this function.
	/// </para>
	/// <para>
	/// The origin for a bottom-up DIB is the lower-left corner of the bitmap; the origin for a top-down DIB is the upper-left corner.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Capturing an Image.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdibits int GetDIBits( HDC hdc, HBITMAP hbm, UINT start,
	// UINT cLines, LPVOID lpvBits, LPBITMAPINFO lpbmi, UINT usage );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "be3ffa3f-b343-4e38-8b1e-aeccf35d92b8")]
	public static extern int GetDIBits([In] HDC hdc, [In] HBITMAP hbm, uint start, uint cLines, [Out, Optional] IntPtr lpvBits, [In, Out] SafeBITMAPINFO lpbmi, DIBColorMode usage);

	/// <summary>The <c>GetPixel</c> function retrieves the red, green, blue (RGB) color value of the pixel at the specified coordinates.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The x-coordinate, in logical units, of the pixel to be examined.</param>
	/// <param name="y">The y-coordinate, in logical units, of the pixel to be examined.</param>
	/// <returns>
	/// The return value is the COLORREF value that specifies the RGB of the pixel. If the pixel is outside of the current clipping
	/// region, the return value is CLR_INVALID (0xFFFFFFFF defined in Wingdi.h).
	/// </returns>
	/// <remarks>
	/// <para>The pixel must be within the boundaries of the current clipping region.</para>
	/// <para>
	/// Not all devices support <c>GetPixel</c>. An application should call GetDeviceCaps to determine whether a specified device
	/// supports this function.
	/// </para>
	/// <para>A bitmap must be selected within the device context, otherwise, CLR_INVALID is returned on all pixels.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getpixel COLORREF GetPixel( HDC hdc, int x, int y );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "46d17e95-93ce-4a43-b86c-489d6e3afe12")]
	public static extern COLORREF GetPixel(HDC hdc, int x, int y);

	/// <summary>
	/// The <c>GetStretchBltMode</c> function retrieves the current stretching mode. The stretching mode defines how color data is added
	/// to or removed from bitmaps that are stretched or compressed when the StretchBlt function is called.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the current stretching mode. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>BLACKONWHITE</term>
	/// <term>
	/// Performs a Boolean AND operation using the color values for the eliminated and existing pixels. If the bitmap is a monochrome
	/// bitmap, this mode preserves black pixels at the expense of white pixels.
	/// </term>
	/// </item>
	/// <item>
	/// <term>COLORONCOLOR</term>
	/// <term>Deletes the pixels. This mode deletes all eliminated lines of pixels without trying to preserve their information.</term>
	/// </item>
	/// <item>
	/// <term>HALFTONE</term>
	/// <term>
	/// Maps pixels from the source rectangle into blocks of pixels in the destination rectangle. The average color over the destination
	/// block of pixels approximates the color of the source pixels.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STRETCH_ANDSCANS</term>
	/// <term>Same as BLACKONWHITE.</term>
	/// </item>
	/// <item>
	/// <term>STRETCH_DELETESCANS</term>
	/// <term>Same as COLORONCOLOR.</term>
	/// </item>
	/// <item>
	/// <term>STRETCH_HALFTONE</term>
	/// <term>Same as HALFTONE.</term>
	/// </item>
	/// <item>
	/// <term>STRETCH_ORSCANS</term>
	/// <term>Same as WHITEONBLACK.</term>
	/// </item>
	/// <item>
	/// <term>WHITEONBLACK</term>
	/// <term>
	/// Performs a Boolean OR operation using the color values for the eliminated and existing pixels. If the bitmap is a monochrome
	/// bitmap, this mode preserves white pixels at the expense of black pixels.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getstretchbltmode int GetStretchBltMode( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "a4408e28-d7ac-44e9-905d-efa75c60e503")]
	public static extern StretchMode GetStretchBltMode(HDC hdc);

	/// <summary>The <c>GdiGradientFill</c> function fills rectangle and triangle structures.</summary>
	/// <param name="hdc">A handle to the destination device context.</param>
	/// <param name="pVertex">A pointer to an array of TRIVERTEX structures that each define a triangle vertex.</param>
	/// <param name="nVertex">The number of vertices in pVertex.</param>
	/// <param name="pMesh">
	/// An array of GRADIENT_TRIANGLE structures in triangle mode, or an array of GRADIENT_RECT structures in rectangle mode.
	/// </param>
	/// <param name="nCount">The number of elements (triangles or rectangles) in pMesh.</param>
	/// <param name="ulMode">
	/// <para>The gradient fill mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GRADIENT_FILL_RECT_H</term>
	/// <term>
	/// In this mode, two endpoints describe a rectangle. The rectangle is defined to have a constant color (specified by the TRIVERTEX
	/// structure) for the left and right edges. GDI interpolates the color from the left to right edge and fills the interior.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GRADIENT_FILL_RECT_V</term>
	/// <term>
	/// In this mode, two endpoints describe a rectangle. The rectangle is defined to have a constant color (specified by the TRIVERTEX
	/// structure) for the top and bottom edges. GDI interpolates the color from the top to bottom edge and fills the interior.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GRADIENT_FILL_TRIANGLE</term>
	/// <term>
	/// In this mode, an array of TRIVERTEX structures is passed to GDI along with a list of array indexes that describe separate
	/// triangles. GDI performs linear interpolation between triangle vertices and fills the interior. Drawing is done directly in 24-
	/// and 32-bpp modes. Dithering is performed in 16-, 8-, 4-, and 1-bpp mode.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para><c>Note</c> This function is the same as GradientFill.</para>
	/// <para>
	/// To add smooth shading to a triangle, call the <c>GdiGradientFill</c> function with the three triangle endpoints. GDI will
	/// linearly interpolate and fill the triangle. Here is the drawing output of a shaded triangle.
	/// </para>
	/// <para>
	/// To add smooth shading to a rectangle, call <c>GdiGradientFill</c> with the upper-left and lower-right coordinates of the
	/// rectangle. There are two shading modes used when drawing a rectangle. In horizontal mode, the rectangle is shaded from
	/// left-to-right. In vertical mode, the rectangle is shaded from top-to-bottom. Here is the drawing output of two shaded rectangles
	/// - one in horizontal mode, the other in vertical mode.
	/// </para>
	/// <para>
	/// The <c>GdiGradientFill</c> function uses a mesh method to specify the endpoints of the object to draw. All vertices are passed to
	/// <c>GdiGradientFill</c> in the pVertex array. The pMesh parameter specifies how these vertices are connected to form an object.
	/// When filling a rectangle, pMesh points to an array of GRADIENT_RECT structures. Each <c>GRADIENT_RECT</c> structure specifies the
	/// index of two vertices in the pVertex array. These two vertices form the upper-left and lower-right boundary of one rectangle.
	/// </para>
	/// <para>
	/// In the case of filling a triangle, pMesh points to an array of GRADIENT_TRIANGLE structures. Each <c>GRADIENT_TRIANGLE</c>
	/// structure specifies the index of three vertices in the pVertex array. These three vertices form one triangle.
	/// </para>
	/// <para>To simplify hardware acceleration, this routine is not required to be pixel-perfect in the triangle interior.</para>
	/// <para>
	/// Note that <c>GdiGradientFill</c> does not use the Alpha member of the TRIVERTEX structure. To use <c>GdiGradientFill</c> with
	/// transparency, call <c>GdiGradientFill</c> and then call GdiAlphaBlend with the desired values for the alpha channel of each vertex.
	/// </para>
	/// <para>For more information, see Smooth Shading, Drawing a Shaded Triangle, and Drawing a Shaded Rectangle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdigradientfill BOOL GdiGradientFill( HDC hdc, PTRIVERTEX
	// pVertex, ULONG nVertex, PVOID pMesh, ULONG nCount, ULONG ulMode );
	[DllImport(Lib.Gdi32, SetLastError = false, EntryPoint = "GradientFill")]
	[PInvokeData("wingdi.h", MSDNShortId = "c88c1137-5690-4139-9d10-90d036e8f31c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GradientFill(HDC hdc, TRIVERTEX[] pVertex, uint nVertex, GRADIENT_TRIANGLE[] pMesh, uint nCount, GradientFillMode ulMode);

	/// <summary>
	/// The <c>MaskBlt</c> function combines the color data for the source and destination bitmaps using the specified mask and raster operation.
	/// </summary>
	/// <param name="hdcDest">A handle to the destination device context.</param>
	/// <param name="xDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="yDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="width">The width, in logical units, of the destination rectangle and source bitmap.</param>
	/// <param name="height">The height, in logical units, of the destination rectangle and source bitmap.</param>
	/// <param name="hdcSrc">
	/// A handle to the device context from which the bitmap is to be copied. It must be zero if the dwRop parameter specifies a raster
	/// operation that does not include a source.
	/// </param>
	/// <param name="xSrc">The x-coordinate, in logical units, of the upper-left corner of the source bitmap.</param>
	/// <param name="ySrc">The y-coordinate, in logical units, of the upper-left corner of the source bitmap.</param>
	/// <param name="hbmMask">A handle to the monochrome mask bitmap combined with the color bitmap in the source device context.</param>
	/// <param name="xMask">The horizontal pixel offset for the mask bitmap specified by the hbmMask parameter.</param>
	/// <param name="yMask">The vertical pixel offset for the mask bitmap specified by the hbmMask parameter.</param>
	/// <param name="rop">
	/// <para>
	/// The foreground and background ternary raster operation codes (ROPs) that the function uses to control the combination of source
	/// and destination data. The background raster operation code is stored in the high-order byte of the high-order word of this value;
	/// the foreground raster operation code is stored in the low-order byte of the high-order word of this value; the low-order word of
	/// this value is ignored, and should be zero. The macro MAKEROP4 creates such combinations of foreground and background raster
	/// operation codes.
	/// </para>
	/// <para>For a discussion of foreground and background in the context of this function, see the following Remarks section.</para>
	/// <para>
	/// For a list of common raster operation codes (ROPs), see the BitBlt function. Note that the CAPTUREBLT ROP generally cannot be
	/// used for printing device contexts.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>MaskBlt</c> function uses device-dependent bitmaps.</para>
	/// <para>
	/// A value of 1 in the mask specified by hbmMask indicates that the foreground raster operation code specified by dwRop should be
	/// applied at that location. A value of 0 in the mask indicates that the background raster operation code specified by dwRop should
	/// be applied at that location.
	/// </para>
	/// <para>
	/// If the raster operations require a source, the mask rectangle must cover the source rectangle. If it does not, the function will
	/// fail. If the raster operations do not require a source, the mask rectangle must cover the destination rectangle. If it does not,
	/// the function will fail.
	/// </para>
	/// <para>
	/// If a rotation or shear transformation is in effect for the source device context when this function is called, an error occurs.
	/// However, other types of transformation are allowed.
	/// </para>
	/// <para>
	/// If the color formats of the source, pattern, and destination bitmaps differ, this function converts the pattern or source format,
	/// or both, to match the destination format.
	/// </para>
	/// <para>If the mask bitmap is not a monochrome bitmap, an error occurs.</para>
	/// <para>
	/// When an enhanced metafile is being recorded, an error occurs (and the function returns <c>FALSE</c>) if the source device context
	/// identifies an enhanced-metafile device context.
	/// </para>
	/// <para>
	/// Not all devices support the <c>MaskBlt</c> function. An application should call the GetDeviceCaps function with the nIndex
	/// parameter as RC_BITBLT to determine whether a device supports this function.
	/// </para>
	/// <para>If no mask bitmap is supplied, this function behaves exactly like BitBlt, using the foreground raster operation code.</para>
	/// <para><c>ICM:</c> No color management is performed when blits occur.</para>
	/// <para>
	/// When used in a multiple monitor system, both hdcSrc and hdcDest must refer to the same device or the function will fail. To
	/// transfer data between DCs for different devices, convert the memory bitmap (compatible bitmap, or DDB) to a DIB by calling
	/// GetDIBits. To display the DIB to the second device, call SetDIBits or StretchDIBits.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-maskblt BOOL MaskBlt( HDC hdcDest, int xDest, int yDest, int
	// width, int height, HDC hdcSrc, int xSrc, int ySrc, HBITMAP hbmMask, int xMask, int yMask, DWORD rop );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "9fd6f0ce-a802-428d-9be5-a66afe39e9b7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool MaskBlt(HDC hdcDest, int xDest, int yDest, int width, int height, HDC hdcSrc, int xSrc, int ySrc,
		HBITMAP hbmMask, int xMask, int yMask, RasterOperationMode rop);

	/// <summary>
	/// The <c>PlgBlt</c> function performs a bit-block transfer of the bits of color data from the specified rectangle in the source
	/// device context to the specified parallelogram in the destination device context. If the given bitmask handle identifies a valid
	/// monochrome bitmap, the function uses this bitmap to mask the bits of color data from the source rectangle.
	/// </summary>
	/// <param name="hdcDest">A handle to the destination device context.</param>
	/// <param name="lpPoint">
	/// A pointer to an array of three points in logical space that identify three corners of the destination parallelogram. The
	/// upper-left corner of the source rectangle is mapped to the first point in this array, the upper-right corner to the second point
	/// in this array, and the lower-left corner to the third point. The lower-right corner of the source rectangle is mapped to the
	/// implicit fourth point in the parallelogram.
	/// </param>
	/// <param name="hdcSrc">A handle to the source device context.</param>
	/// <param name="xSrc">The x-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
	/// <param name="ySrc">The y-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
	/// <param name="width">The width, in logical units, of the source rectangle.</param>
	/// <param name="height">The height, in logical units, of the source rectangle.</param>
	/// <param name="hbmMask">A handle to an optional monochrome bitmap that is used to mask the colors of the source rectangle.</param>
	/// <param name="xMask">The x-coordinate, in logical units, of the upper-left corner of the monochrome bitmap.</param>
	/// <param name="yMask">The y-coordinate, in logical units, of the upper-left corner of the monochrome bitmap.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>PlgBlt</c> function works with device-dependent bitmaps.</para>
	/// <para>
	/// The fourth vertex of the parallelogram (D) is defined by treating the first three points (A, B, and C ) as vectors and computing
	/// D = B +CA.
	/// </para>
	/// <para>
	/// If the bitmask exists, a value of one in the mask indicates that the source pixel color should be copied to the destination. A
	/// value of zero in the mask indicates that the destination pixel color is not to be changed. If the mask rectangle is smaller than
	/// the source and destination rectangles, the function replicates the mask pattern.
	/// </para>
	/// <para>
	/// Scaling, translation, and reflection transformations are allowed in the source device context; however, rotation and shear
	/// transformations are not. If the mask bitmap is not a monochrome bitmap, an error occurs. The stretching mode for the destination
	/// device context is used to determine how to stretch or compress the pixels, if that is necessary.
	/// </para>
	/// <para>
	/// When an enhanced metafile is being recorded, an error occurs if the source device context identifies an enhanced-metafile device context.
	/// </para>
	/// <para>
	/// The destination coordinates are transformed according to the destination device context; the source coordinates are transformed
	/// according to the source device context. If the source transformation has a rotation or shear, an error is returned.
	/// </para>
	/// <para>
	/// If the destination and source rectangles do not have the same color format, <c>PlgBlt</c> converts the source rectangle to match
	/// the destination rectangle.
	/// </para>
	/// <para>
	/// Not all devices support the <c>PlgBlt</c> function. For more information, see the description of the RC_BITBLT raster capability
	/// in the GetDeviceCaps function.
	/// </para>
	/// <para>If the source and destination device contexts represent incompatible devices, <c>PlgBlt</c> returns an error.</para>
	/// <para>
	/// When used in a multiple monitor system, both hdcSrc and hdcDest must refer to the same device or the function will fail. To
	/// transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling GetDIBits. To display the DIB to
	/// the second device, call SetDIBits or StretchDIBits.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-plgblt BOOL PlgBlt( HDC hdcDest, const POINT *lpPoint, HDC
	// hdcSrc, int xSrc, int ySrc, int width, int height, HBITMAP hbmMask, int xMask, int yMask );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "2a56c71b-2e96-418b-8625-a808d76e0c85")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PlgBlt(HDC hdcDest, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] POINT[] lpPoint,
		HDC hdcSrc, int xSrc, int ySrc, int width, int height, HBITMAP hbmMask, int xMask, int yMask);

	/// <summary>
	/// <para>The <c>SetBitmapBits</c> function sets the bits of color data for a bitmap to the specified values.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// SetDIBits function.
	/// </para>
	/// </summary>
	/// <param name="hbm">A handle to the bitmap to be set. This must be a compatible bitmap (DDB).</param>
	/// <param name="cb">The number of bytes pointed to by the lpBits parameter.</param>
	/// <param name="pvBits">A pointer to an array of bytes that contain color data for the specified bitmap.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of bytes used in setting the bitmap bits.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>The array identified by lpBits must be WORD aligned.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setbitmapbits LONG SetBitmapBits( HBITMAP hbm, DWORD cb, const
	// VOID *pvBits );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3cab12a6-c408-4552-bec0-5ecfd8374757")]
	public static extern int SetBitmapBits(HBITMAP hbm, uint cb, byte[] pvBits);

	/// <summary>
	/// The <c>SetBitmapDimensionEx</c> function assigns preferred dimensions to a bitmap. These dimensions can be used by applications;
	/// however, they are not used by the system.
	/// </summary>
	/// <param name="hbm">A handle to the bitmap. The bitmap cannot be a DIB-section bitmap.</param>
	/// <param name="w">The width, in 0.1-millimeter units, of the bitmap.</param>
	/// <param name="h">The height, in 0.1-millimeter units, of the bitmap.</param>
	/// <param name="lpsz">A pointer to a SIZE structure to receive the previous dimensions of the bitmap. This pointer can be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application can retrieve the dimensions assigned to a bitmap with the <c>SetBitmapDimensionEx</c> function by calling the
	/// GetBitmapDimensionEx function.
	/// </para>
	/// <para>
	/// The bitmap identified by hBitmap cannot be a DIB section, which is a bitmap created by the CreateDIBSection function. If the
	/// bitmap is a DIB section, the <c>SetBitmapDimensionEx</c> function fails.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setbitmapdimensionex BOOL SetBitmapDimensionEx( HBITMAP hbm,
	// int w, int h, LPSIZE lpsz );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "23960533-de71-4bff-a43f-75e5fe38fbec")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetBitmapDimensionEx([In] HBITMAP hbm, int w, int h, out SIZE lpsz);

	/// <summary>
	/// The <c>SetDIBColorTable</c> function sets RGB (red, green, blue) color values in a range of entries in the color table of the DIB
	/// that is currently selected into a specified device context.
	/// </summary>
	/// <param name="hdc">A device context. A DIB must be selected into this device context.</param>
	/// <param name="iStart">A zero-based color table index that specifies the first color table entry to set.</param>
	/// <param name="cEntries">The number of color table entries to set.</param>
	/// <param name="prgbq">A pointer to an array of RGBQUAD structures containing new color information for the DIB's color table.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of color table entries that the function sets.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function should be called to set the color table for DIBs that use 1, 4, or 8 bpp. The <c>BitCount</c> member of a bitmap's
	/// associated bitmap information header structure.
	/// </para>
	/// <para>
	/// BITMAPINFOHEADER structure specifies the number of bits-per-pixel. Device-independent bitmaps with a <c>biBitCount</c> value
	/// greater than 8 do not have a color table.
	/// </para>
	/// <para>
	/// The <c>bV5BitCount</c> member of a bitmap's associated BITMAPV5HEADER structure specifies the number of bits-per-pixel.
	/// Device-independent bitmaps with a <c>bV5BitCount</c> value greater than 8 do not have a color table.
	/// </para>
	/// <para><c>ICM:</c> No color management is performed.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdibcolortable UINT SetDIBColorTable( HDC hdc, UINT iStart,
	// UINT cEntries, const RGBQUAD *prgbq );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "f301c34d-6e8e-4dc8-b3f3-0fdc658d09e3")]
	public static extern uint SetDIBColorTable(HDC hdc, uint iStart, uint cEntries, [In] RGBQUAD[] prgbq);

	/// <summary>
	/// The <c>SetDIBits</c> function sets the pixels in a compatible bitmap (DDB) using the color data found in the specified DIB.
	/// </summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="hbm">A handle to the compatible bitmap (DDB) that is to be altered using the color data from the specified DIB.</param>
	/// <param name="start">The starting scan line for the device-independent color data in the array pointed to by the lpvBits parameter.</param>
	/// <param name="cLines">The number of scan lines found in the array containing device-independent color data.</param>
	/// <param name="lpBits">
	/// A pointer to the DIB color data, stored as an array of bytes. The format of the bitmap values depends on the <c>biBitCount</c>
	/// member of the BITMAPINFO structure pointed to by the lpbmi parameter.
	/// </param>
	/// <param name="lpbmi">A pointer to a BITMAPINFO structure that contains information about the DIB.</param>
	/// <param name="ColorUse">
	/// <para>
	/// Indicates whether the <c>bmiColors</c> member of the BITMAPINFO structure was provided and, if so, whether <c>bmiColors</c>
	/// contains explicit red, green, blue (RGB) values or palette indexes. The fuColorUse parameter must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>
	/// The color table consists of an array of 16-bit indexes into the logical palette of the device context identified by the hdc parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>The color table is provided and contains literal RGB values.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of scan lines copied.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>This can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the input parameters is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Optimal bitmap drawing speed is obtained when the bitmap bits are indexes into the system palette.</para>
	/// <para>
	/// Applications can retrieve the system palette colors and indexes by calling the GetSystemPaletteEntries function. After the colors
	/// and indexes are retrieved, the application can create the DIB. For more information, see System Palette.
	/// </para>
	/// <para>
	/// The device context identified by the hdc parameter is used only if the DIB_PAL_COLORS constant is set for the fuColorUse
	/// parameter; otherwise it is ignored.
	/// </para>
	/// <para>
	/// The bitmap identified by the hbmp parameter must not be selected into a device context when the application calls this function.
	/// </para>
	/// <para>The scan lines must be aligned on a <c>DWORD</c> except for RLE-compressed bitmaps.</para>
	/// <para>
	/// The origin for bottom-up DIBs is the lower-left corner of the bitmap; the origin for top-down DIBs is the upper-left corner of
	/// the bitmap.
	/// </para>
	/// <para>
	/// <c>ICM:</c> Color management is performed if color management has been enabled with a call to SetICMMode with the iEnableICM
	/// parameter set to ICM_ON. If the bitmap specified by lpbmi has a BITMAPV4HEADER that specifies the gamma and endpoints members, or
	/// a BITMAPV5HEADER that specifies either the gamma and endpoints members or the profileData and profileSize members, then the call
	/// treats the bitmap's pixels as being expressed in the color space described by those members, rather than in the device context's
	/// source color space.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdibits int SetDIBits( HDC hdc, HBITMAP hbm, UINT start,
	// UINT cLines, const VOID *lpBits, const BITMAPINFO *lpbmi, UINT ColorUse );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "706f4532-4073-4d5c-ae2d-e33aea9163e9")]
	public static extern int SetDIBits([In, Optional] HDC hdc, [In] HBITMAP hbm, uint start, uint cLines, [In] byte[] lpBits, in BITMAPINFO lpbmi, DIBColorMode ColorUse);

	/// <summary>
	/// The <c>SetDIBits</c> function sets the pixels in a compatible bitmap (DDB) using the color data found in the specified DIB.
	/// </summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="hbm">A handle to the compatible bitmap (DDB) that is to be altered using the color data from the specified DIB.</param>
	/// <param name="start">The starting scan line for the device-independent color data in the array pointed to by the lpvBits parameter.</param>
	/// <param name="cLines">The number of scan lines found in the array containing device-independent color data.</param>
	/// <param name="lpBits">
	/// A pointer to the DIB color data, stored as an array of bytes. The format of the bitmap values depends on the <c>biBitCount</c>
	/// member of the BITMAPINFO structure pointed to by the lpbmi parameter.
	/// </param>
	/// <param name="lpbmi">A pointer to a BITMAPINFO structure that contains information about the DIB.</param>
	/// <param name="ColorUse">
	/// <para>
	/// Indicates whether the <c>bmiColors</c> member of the BITMAPINFO structure was provided and, if so, whether <c>bmiColors</c>
	/// contains explicit red, green, blue (RGB) values or palette indexes. The fuColorUse parameter must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>
	/// The color table consists of an array of 16-bit indexes into the logical palette of the device context identified by the hdc parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>The color table is provided and contains literal RGB values.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of scan lines copied.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>This can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the input parameters is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Optimal bitmap drawing speed is obtained when the bitmap bits are indexes into the system palette.</para>
	/// <para>
	/// Applications can retrieve the system palette colors and indexes by calling the GetSystemPaletteEntries function. After the colors
	/// and indexes are retrieved, the application can create the DIB. For more information, see System Palette.
	/// </para>
	/// <para>
	/// The device context identified by the hdc parameter is used only if the DIB_PAL_COLORS constant is set for the fuColorUse
	/// parameter; otherwise it is ignored.
	/// </para>
	/// <para>
	/// The bitmap identified by the hbmp parameter must not be selected into a device context when the application calls this function.
	/// </para>
	/// <para>The scan lines must be aligned on a <c>DWORD</c> except for RLE-compressed bitmaps.</para>
	/// <para>
	/// The origin for bottom-up DIBs is the lower-left corner of the bitmap; the origin for top-down DIBs is the upper-left corner of
	/// the bitmap.
	/// </para>
	/// <para>
	/// <c>ICM:</c> Color management is performed if color management has been enabled with a call to SetICMMode with the iEnableICM
	/// parameter set to ICM_ON. If the bitmap specified by lpbmi has a BITMAPV4HEADER that specifies the gamma and endpoints members, or
	/// a BITMAPV5HEADER that specifies either the gamma and endpoints members or the profileData and profileSize members, then the call
	/// treats the bitmap's pixels as being expressed in the color space described by those members, rather than in the device context's
	/// source color space.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdibits int SetDIBits( HDC hdc, HBITMAP hbm, UINT start,
	// UINT cLines, const VOID *lpBits, const BITMAPINFO *lpbmi, UINT ColorUse );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "706f4532-4073-4d5c-ae2d-e33aea9163e9")]
	public static extern int SetDIBits([In, Optional] HDC hdc, [In] HBITMAP hbm, uint start, uint cLines, [In] IntPtr lpBits, [In] SafeBITMAPINFO lpbmi, DIBColorMode ColorUse);

	/// <summary>
	/// The <c>SetDIBitsToDevice</c> function sets the pixels in the specified rectangle on the device that is associated with the
	/// destination device context using color data from a DIB, JPEG, or PNG image.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="xDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="yDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="w">The width, in logical units, of the image.</param>
	/// <param name="h">The height, in logical units, of the image.</param>
	/// <param name="xSrc">The x-coordinate, in logical units, of the lower-left corner of the image.</param>
	/// <param name="ySrc">The y-coordinate, in logical units, of the lower-left corner of the image.</param>
	/// <param name="StartScan">The starting scan line in the image.</param>
	/// <param name="cLines">The number of DIB scan lines contained in the array pointed to by the lpvBits parameter.</param>
	/// <param name="lpvBits">
	/// A pointer to the color data stored as an array of bytes. For more information, see the following Remarks section.
	/// </param>
	/// <param name="lpbmi">A pointer to a BITMAPINFO structure that contains information about the DIB.</param>
	/// <param name="ColorUse">
	/// <para>
	/// Indicates whether the <c>bmiColors</c> member of the BITMAPINFO structure contains explicit red, green, blue (RGB) values or
	/// indexes into a palette. For more information, see the following Remarks section.
	/// </para>
	/// <para>The fuColorUse parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>The color table consists of an array of 16-bit indexes into the currently selected logical palette.</term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>The color table contains literal RGB values.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of scan lines set.</para>
	/// <para>If zero scan lines are set (such as when dwHeight is 0) or the function fails, the function returns zero.</para>
	/// <para>
	/// If the driver cannot support the JPEG or PNG file image passed to <c>SetDIBitsToDevice</c>, the function will fail and return
	/// GDI_ERROR. If failure does occur, the application must fall back on its own JPEG or PNG support to decompress the image into a
	/// bitmap, and then pass the bitmap to <c>SetDIBitsToDevice</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Optimal bitmap drawing speed is obtained when the bitmap bits are indexes into the system palette.</para>
	/// <para>
	/// Applications can retrieve the system palette colors and indexes by calling the GetSystemPaletteEntries function. After the colors
	/// and indexes are retrieved, the application can create the DIB. For more information about the system palette, see Colors.
	/// </para>
	/// <para>The scan lines must be aligned on a <c>DWORD</c> except for RLE-compressed bitmaps.</para>
	/// <para>The origin of a bottom-up DIB is the lower-left corner of the bitmap; the origin of a top-down DIB is the upper-left corner.</para>
	/// <para>
	/// To reduce the amount of memory required to set bits from a large DIB on a device surface, an application can band the output by
	/// repeatedly calling <c>SetDIBitsToDevice</c>, placing a different portion of the bitmap into the lpvBits array each time. The
	/// values of the uStartScan and cScanLines parameters identify the portion of the bitmap contained in the lpvBits array.
	/// </para>
	/// <para>
	/// The <c>SetDIBitsToDevice</c> function returns an error if it is called by a process that is running in the background while a
	/// full-screen MS-DOS session runs in the foreground.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the <c>biCompression</c> member of BITMAPINFOHEADER is BI_JPEG or BI_PNG, lpvBits points to a buffer containing a JPEG or PNG
	/// image. The <c>biSizeImage</c> member of specifies the size of the buffer. The fuColorUse parameter must be set to DIB_RGB_COLORS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To ensure proper metafile spooling while printing, applications must call the CHECKJPEGFORMAT or CHECKPNGFORMAT escape to verify
	/// that the printer recognizes the JPEG or PNG image, respectively, before calling <c>SetDIBitsToDevice</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>ICM:</c> Color management is performed if color management has been enabled with a call to SetICMMode with the iEnableICM
	/// parameter set to ICM_ON. If the bitmap specified by lpbmi has a BITMAPV4HEADER that specifies the gamma and endpoints members, or
	/// a BITMAPV5HEADER that specifies either the gamma and endpoints members or the profileData and profileSize members, then the call
	/// treats the bitmap's pixels as being expressed in the color space described by those members, rather than in the device context's
	/// source color space.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Testing a Printer for JPEG or PNG Support.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdibitstodevice int SetDIBitsToDevice( HDC hdc, int xDest,
	// int yDest, DWORD w, DWORD h, int xSrc, int ySrc, UINT StartScan, UINT cLines, const VOID *lpvBits, const BITMAPINFO *lpbmi, UINT
	// ColorUse );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "41225400-12e3-47ba-8b88-ac1d5b0fa90f")]
	public static extern int SetDIBitsToDevice([In] HDC hdc, int xDest, int yDest, uint w, uint h, int xSrc, int ySrc, uint StartScan,
		uint cLines, [In] byte[] lpvBits, in BITMAPINFO lpbmi, DIBColorMode ColorUse);

	/// <summary>
	/// The <c>SetDIBitsToDevice</c> function sets the pixels in the specified rectangle on the device that is associated with the
	/// destination device context using color data from a DIB, JPEG, or PNG image.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="xDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="yDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="w">The width, in logical units, of the image.</param>
	/// <param name="h">The height, in logical units, of the image.</param>
	/// <param name="xSrc">The x-coordinate, in logical units, of the lower-left corner of the image.</param>
	/// <param name="ySrc">The y-coordinate, in logical units, of the lower-left corner of the image.</param>
	/// <param name="StartScan">The starting scan line in the image.</param>
	/// <param name="cLines">The number of DIB scan lines contained in the array pointed to by the lpvBits parameter.</param>
	/// <param name="lpvBits">
	/// A pointer to the color data stored as an array of bytes. For more information, see the following Remarks section.
	/// </param>
	/// <param name="lpbmi">A pointer to a BITMAPINFO structure that contains information about the DIB.</param>
	/// <param name="ColorUse">
	/// <para>
	/// Indicates whether the <c>bmiColors</c> member of the BITMAPINFO structure contains explicit red, green, blue (RGB) values or
	/// indexes into a palette. For more information, see the following Remarks section.
	/// </para>
	/// <para>The fuColorUse parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>The color table consists of an array of 16-bit indexes into the currently selected logical palette.</term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>The color table contains literal RGB values.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of scan lines set.</para>
	/// <para>If zero scan lines are set (such as when dwHeight is 0) or the function fails, the function returns zero.</para>
	/// <para>
	/// If the driver cannot support the JPEG or PNG file image passed to <c>SetDIBitsToDevice</c>, the function will fail and return
	/// GDI_ERROR. If failure does occur, the application must fall back on its own JPEG or PNG support to decompress the image into a
	/// bitmap, and then pass the bitmap to <c>SetDIBitsToDevice</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Optimal bitmap drawing speed is obtained when the bitmap bits are indexes into the system palette.</para>
	/// <para>
	/// Applications can retrieve the system palette colors and indexes by calling the GetSystemPaletteEntries function. After the colors
	/// and indexes are retrieved, the application can create the DIB. For more information about the system palette, see Colors.
	/// </para>
	/// <para>The scan lines must be aligned on a <c>DWORD</c> except for RLE-compressed bitmaps.</para>
	/// <para>The origin of a bottom-up DIB is the lower-left corner of the bitmap; the origin of a top-down DIB is the upper-left corner.</para>
	/// <para>
	/// To reduce the amount of memory required to set bits from a large DIB on a device surface, an application can band the output by
	/// repeatedly calling <c>SetDIBitsToDevice</c>, placing a different portion of the bitmap into the lpvBits array each time. The
	/// values of the uStartScan and cScanLines parameters identify the portion of the bitmap contained in the lpvBits array.
	/// </para>
	/// <para>
	/// The <c>SetDIBitsToDevice</c> function returns an error if it is called by a process that is running in the background while a
	/// full-screen MS-DOS session runs in the foreground.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the <c>biCompression</c> member of BITMAPINFOHEADER is BI_JPEG or BI_PNG, lpvBits points to a buffer containing a JPEG or PNG
	/// image. The <c>biSizeImage</c> member of specifies the size of the buffer. The fuColorUse parameter must be set to DIB_RGB_COLORS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To ensure proper metafile spooling while printing, applications must call the CHECKJPEGFORMAT or CHECKPNGFORMAT escape to verify
	/// that the printer recognizes the JPEG or PNG image, respectively, before calling <c>SetDIBitsToDevice</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>ICM:</c> Color management is performed if color management has been enabled with a call to SetICMMode with the iEnableICM
	/// parameter set to ICM_ON. If the bitmap specified by lpbmi has a BITMAPV4HEADER that specifies the gamma and endpoints members, or
	/// a BITMAPV5HEADER that specifies either the gamma and endpoints members or the profileData and profileSize members, then the call
	/// treats the bitmap's pixels as being expressed in the color space described by those members, rather than in the device context's
	/// source color space.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Testing a Printer for JPEG or PNG Support.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdibitstodevice int SetDIBitsToDevice( HDC hdc, int xDest,
	// int yDest, DWORD w, DWORD h, int xSrc, int ySrc, UINT StartScan, UINT cLines, const VOID *lpvBits, const BITMAPINFO *lpbmi, UINT
	// ColorUse );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "41225400-12e3-47ba-8b88-ac1d5b0fa90f")]
	public static extern int SetDIBitsToDevice([In] HDC hdc, int xDest, int yDest, uint w, uint h, int xSrc, int ySrc, uint StartScan,
		uint cLines, [In] IntPtr lpvBits, [In] SafeBITMAPINFO lpbmi, DIBColorMode ColorUse);

	/// <summary>The <c>SetPixel</c> function sets the pixel at the specified coordinates to the specified color.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The x-coordinate, in logical units, of the point to be set.</param>
	/// <param name="y">The y-coordinate, in logical units, of the point to be set.</param>
	/// <param name="color">The color to be used to paint the point. To create a COLORREF color value, use the RGB macro.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the RGB value that the function sets the pixel to. This value may differ from the
	/// color specified by crColor; that occurs when an exact match for the specified color cannot be found.
	/// </para>
	/// <para>If the function fails, the return value is -1.</para>
	/// <para>This can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the input parameters is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The function fails if the pixel coordinates lie outside of the current clipping region.</para>
	/// <para>Not all devices support the <c>SetPixel</c> function. For more information, see GetDeviceCaps.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setpixel COLORREF SetPixel( HDC hdc, int x, int y, COLORREF
	// color );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "652e2e7a-79ae-4668-b269-153ee08a5de9")]
	public static extern COLORREF SetPixel(HDC hdc, int x, int y, COLORREF color);

	/// <summary>
	/// The <c>SetPixelV</c> function sets the pixel at the specified coordinates to the closest approximation of the specified color.
	/// The point must be in the clipping region and the visible part of the device surface.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The x-coordinate, in logical units, of the point to be set.</param>
	/// <param name="y">The y-coordinate, in logical units, of the point to be set.</param>
	/// <param name="color">The color to be used to paint the point. To create a COLORREF color value, use the RGB macro.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Not all devices support the <c>SetPixelV</c> function. For more information, see the description of the RC_BITBLT capability in
	/// the GetDeviceCaps function.
	/// </para>
	/// <para><c>SetPixelV</c> is faster than SetPixel because it does not need to return the color value of the point actually painted.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setpixelv BOOL SetPixelV( HDC hdc, int x, int y, COLORREF
	// color );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "638f0ffd-3771-4390-b335-0517be5312fd")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetPixelV(HDC hdc, int x, int y, COLORREF color);

	/// <summary>The <c>SetStretchBltMode</c> function sets the bitmap stretching mode in the specified device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="mode">
	/// <para>The stretching mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BLACKONWHITE</term>
	/// <term>
	/// Performs a Boolean AND operation using the color values for the eliminated and existing pixels. If the bitmap is a monochrome
	/// bitmap, this mode preserves black pixels at the expense of white pixels.
	/// </term>
	/// </item>
	/// <item>
	/// <term>COLORONCOLOR</term>
	/// <term>Deletes the pixels. This mode deletes all eliminated lines of pixels without trying to preserve their information.</term>
	/// </item>
	/// <item>
	/// <term>HALFTONE</term>
	/// <term>
	/// Maps pixels from the source rectangle into blocks of pixels in the destination rectangle. The average color over the destination
	/// block of pixels approximates the color of the source pixels. After setting the HALFTONE stretching mode, an application must call
	/// the SetBrushOrgEx function to set the brush origin. If it fails to do so, brush misalignment occurs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STRETCH_ANDSCANS</term>
	/// <term>Same as BLACKONWHITE.</term>
	/// </item>
	/// <item>
	/// <term>STRETCH_DELETESCANS</term>
	/// <term>Same as COLORONCOLOR.</term>
	/// </item>
	/// <item>
	/// <term>STRETCH_HALFTONE</term>
	/// <term>Same as HALFTONE.</term>
	/// </item>
	/// <item>
	/// <term>STRETCH_ORSCANS</term>
	/// <term>Same as WHITEONBLACK.</term>
	/// </item>
	/// <item>
	/// <term>WHITEONBLACK</term>
	/// <term>
	/// Performs a Boolean OR operation using the color values for the eliminated and existing pixels. If the bitmap is a monochrome
	/// bitmap, this mode preserves white pixels at the expense of black pixels.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the previous stretching mode.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>This function can return the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the input parameters is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The stretching mode defines how the system combines rows or columns of a bitmap with existing pixels on a display device when an
	/// application calls the StretchBlt function.
	/// </para>
	/// <para>
	/// The BLACKONWHITE (STRETCH_ANDSCANS) and WHITEONBLACK (STRETCH_ORSCANS) modes are typically used to preserve foreground pixels in
	/// monochrome bitmaps. The COLORONCOLOR (STRETCH_DELETESCANS) mode is typically used to preserve color in color bitmaps.
	/// </para>
	/// <para>
	/// The HALFTONE mode is slower and requires more processing of the source image than the other three modes; but produces higher
	/// quality images. Also note that SetBrushOrgEx must be called after setting the HALFTONE mode to avoid brush misalignment.
	/// </para>
	/// <para>Additional stretching modes might also be available depending on the capabilities of the device driver.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setstretchbltmode
	// int SetStretchBltMode( HDC hdc, int mode );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3e5a48dc-ccd5-41ea-a24b-5c40213abf38")]
	public static extern StretchMode SetStretchBltMode(HDC hdc, StretchMode mode);

	/// <summary>
	/// The <c>StretchBlt</c> function copies a bitmap from a source rectangle into a destination rectangle, stretching or compressing
	/// the bitmap to fit the dimensions of the destination rectangle, if necessary. The system stretches or compresses the bitmap
	/// according to the stretching mode currently set in the destination device context.
	/// </summary>
	/// <param name="hdcDest">A handle to the destination device context.</param>
	/// <param name="xDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="yDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="wDest">The width, in logical units, of the destination rectangle.</param>
	/// <param name="hDest">The height, in logical units, of the destination rectangle.</param>
	/// <param name="hdcSrc">A handle to the source device context.</param>
	/// <param name="xSrc">The x-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
	/// <param name="ySrc">The y-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
	/// <param name="wSrc">The width, in logical units, of the source rectangle.</param>
	/// <param name="hSrc">The height, in logical units, of the source rectangle.</param>
	/// <param name="rop">
	/// <para>
	/// The raster operation to be performed. Raster operation codes define how the system combines colors in output operations that
	/// involve a brush, a source bitmap, and a destination bitmap.
	/// </para>
	/// <para>
	/// See BitBlt for a list of common raster operation codes (ROPs). Note that the CAPTUREBLT ROP generally cannot be used for printing
	/// device contexts.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>StretchBlt</c> stretches or compresses the source bitmap in memory and then copies the result to the destination rectangle.
	/// This bitmap can be either a compatible bitmap (DDB) or the output from CreateDIBSection. The color data for pattern or
	/// destination pixels is merged after the stretching or compression occurs.
	/// </para>
	/// <para>
	/// When an enhanced metafile is being recorded, an error occurs (and the function returns <c>FALSE</c>) if the source device context
	/// identifies an enhanced-metafile device context.
	/// </para>
	/// <para>
	/// If the specified raster operation requires a brush, the system uses the brush currently selected into the destination device context.
	/// </para>
	/// <para>
	/// The destination coordinates are transformed by using the transformation currently specified for the destination device context;
	/// the source coordinates are transformed by using the transformation currently specified for the source device context.
	/// </para>
	/// <para>If the source transformation has a rotation or shear, an error occurs.</para>
	/// <para>
	/// If destination, source, and pattern bitmaps do not have the same color format, <c>StretchBlt</c> converts the source and pattern
	/// bitmaps to match the destination bitmap.
	/// </para>
	/// <para>
	/// If <c>StretchBlt</c> must convert a monochrome bitmap to a color bitmap, it sets white bits (1) to the background color and black
	/// bits (0) to the foreground color. To convert a color bitmap to a monochrome bitmap, it sets pixels that match the background
	/// color to white (1) and sets all other pixels to black (0). The foreground and background colors of the device context with color
	/// are used.
	/// </para>
	/// <para>
	/// <c>StretchBlt</c> creates a mirror image of a bitmap if the signs of the nWidthSrc and nWidthDest parameters or if the nHeightSrc
	/// and nHeightDest parameters differ. If nWidthSrc and nWidthDest have different signs, the function creates a mirror image of the
	/// bitmap along the x-axis. If nHeightSrc and nHeightDest have different signs, the function creates a mirror image of the bitmap
	/// along the y-axis.
	/// </para>
	/// <para>Not all devices support the <c>StretchBlt</c> function. For more information, see the GetDeviceCaps.</para>
	/// <para><c>ICM:</c> No color management is performed when a blit operation occurs.</para>
	/// <para>
	/// When used in a multiple monitor system, both hdcSrc and hdcDest must refer to the same device or the function will fail. To
	/// transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling GetDIBits. To display the DIB to
	/// the second device, call SetDIBits or StretchDIBits.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Scaling an Image.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-stretchblt BOOL StretchBlt( HDC hdcDest, int xDest, int yDest,
	// int wDest, int hDest, HDC hdcSrc, int xSrc, int ySrc, int wSrc, int hSrc, DWORD rop );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "5130c88e-08e8-4faa-a1cb-a8106c86cea0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool StretchBlt(HDC hdcDest, int xDest, int yDest, int wDest, int hDest, HDC hdcSrc, int xSrc, int ySrc,
		int wSrc, int hSrc, RasterOperationMode rop);

	/// <summary>
	/// The <c>StretchDIBits</c> function copies the color data for a rectangle of pixels in a DIB, JPEG, or PNG image to the specified
	/// destination rectangle. If the destination rectangle is larger than the source rectangle, this function stretches the rows and
	/// columns of color data to fit the destination rectangle. If the destination rectangle is smaller than the source rectangle, this
	/// function compresses the rows and columns by using the specified raster operation.
	/// </summary>
	/// <param name="hdc">A handle to the destination device context.</param>
	/// <param name="xDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="yDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="DestWidth">The width, in logical units, of the destination rectangle.</param>
	/// <param name="DestHeight">The height, in logical units, of the destination rectangle.</param>
	/// <param name="xSrc">The x-coordinate, in pixels, of the source rectangle in the image.</param>
	/// <param name="ySrc">The y-coordinate, in pixels, of the source rectangle in the image.</param>
	/// <param name="SrcWidth">The width, in pixels, of the source rectangle in the image.</param>
	/// <param name="SrcHeight">The height, in pixels, of the source rectangle in the image.</param>
	/// <param name="lpBits">
	/// A pointer to the image bits, which are stored as an array of bytes. For more information, see the Remarks section.
	/// </param>
	/// <param name="lpbmi">A pointer to a BITMAPINFO structure that contains information about the DIB.</param>
	/// <param name="iUsage">
	/// <para>
	/// Specifies whether the <c>bmiColors</c> member of the BITMAPINFO structure was provided and, if so, whether <c>bmiColors</c>
	/// contains explicit red, green, blue (RGB) values or indexes. The iUsage parameter must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>The array contains 16-bit indexes into the logical palette of the source device context.</term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>The color table contains literal RGB values.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see the Remarks section.</para>
	/// </param>
	/// <param name="rop">
	/// A raster-operation code that specifies how the source pixels, the destination device context's current brush, and the destination
	/// pixels are to be combined to form the new image. For a list of some common raster operation codes, see BitBlt.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the number of scan lines copied. Note that this value can be negative for mirrored content.
	/// </para>
	/// <para>If the function fails, or no scan lines are copied, the return value is 0.</para>
	/// <para>
	/// If the driver cannot support the JPEG or PNG file image passed to <c>StretchDIBits</c>, the function will fail and return
	/// GDI_ERROR. If failure does occur, the application must fall back on its own JPEG or PNG support to decompress the image into a
	/// bitmap, and then pass the bitmap to <c>StretchDIBits</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The origin of a bottom-up DIB is the lower-left corner; the origin of a top-down DIB is the upper-left corner.</para>
	/// <para>
	/// <c>StretchDIBits</c> creates a mirror image of a bitmap if the signs of the nSrcWidth and nDestWidth parameters, or if the
	/// nSrcHeight and nDestHeight parameters differ. If nSrcWidth and nDestWidth have different signs, the function creates a mirror
	/// image of the bitmap along the x-axis. If nSrcHeight and nDestHeight have different signs, the function creates a mirror image of
	/// the bitmap along the y-axis.
	/// </para>
	/// <para>
	/// <c>StretchDIBits</c> creates a top-down image if the sign of the <c>biHeight</c> member of the BITMAPINFOHEADER structure for the
	/// DIB is negative. For a code example, see Sizing a JPEG or PNG Image.
	/// </para>
	/// <para>
	/// This function allows a JPEG or PNG image to be passed as the source image. How each parameter is used remains the same, except:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the <c>biCompression</c> member of BITMAPINFOHEADER is BI_JPEG or BI_PNG, lpBits points to a buffer containing a JPEG or PNG
	/// image, respectively. The <c>biSizeImage</c> member of the <c>BITMAPINFOHEADER</c> structure specifies the size of the buffer. The
	/// iUsage parameter must be set to DIB_RGB_COLORS. The dwRop parameter must be set to SRCCOPY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To ensure proper metafile spooling while printing, applications must call the CHECKJPEGFORMAT or CHECKPNGFORMAT escape to verify
	/// that the printer recognizes the JPEG or PNG image, respectively, before calling <c>StretchDIBits</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>ICM:</c> Color management is performed if color management has been enabled with a call to SetICMMode with the iEnableICM
	/// parameter set to ICM_ON. If the bitmap specified by lpBitsInfo has a BITMAPV4HEADER that specifies the gamma and endpoints
	/// members, or a BITMAPV5HEADER that specifies either the gamma and endpoints members or the profileData and profileSize members,
	/// then the call treats the bitmap's pixels as being expressed in the color space described by those members, rather than in the
	/// device context's source color space.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Sizing a JPEG or PNG Image.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-stretchdibits int StretchDIBits( HDC hdc, int xDest, int
	// yDest, int DestWidth, int DestHeight, int xSrc, int ySrc, int SrcWidth, int SrcHeight, const VOID *lpBits, const BITMAPINFO
	// *lpbmi, UINT iUsage, DWORD rop );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3d57a79a-338d-48ab-8161-3ce17739bf20")]
	public static extern int StretchDIBits([In] HDC hdc, int xDest, int yDest, int DestWidth, int DestHeight, int xSrc, int ySrc, int SrcWidth,
		int SrcHeight, [In, Optional] byte[]? lpBits, in BITMAPINFO lpbmi, DIBColorMode iUsage, RasterOperationMode rop);

	/// <summary>
	/// The <c>StretchDIBits</c> function copies the color data for a rectangle of pixels in a DIB, JPEG, or PNG image to the specified
	/// destination rectangle. If the destination rectangle is larger than the source rectangle, this function stretches the rows and
	/// columns of color data to fit the destination rectangle. If the destination rectangle is smaller than the source rectangle, this
	/// function compresses the rows and columns by using the specified raster operation.
	/// </summary>
	/// <param name="hdc">A handle to the destination device context.</param>
	/// <param name="xDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="yDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="DestWidth">The width, in logical units, of the destination rectangle.</param>
	/// <param name="DestHeight">The height, in logical units, of the destination rectangle.</param>
	/// <param name="xSrc">The x-coordinate, in pixels, of the source rectangle in the image.</param>
	/// <param name="ySrc">The y-coordinate, in pixels, of the source rectangle in the image.</param>
	/// <param name="SrcWidth">The width, in pixels, of the source rectangle in the image.</param>
	/// <param name="SrcHeight">The height, in pixels, of the source rectangle in the image.</param>
	/// <param name="lpBits">
	/// A pointer to the image bits, which are stored as an array of bytes. For more information, see the Remarks section.
	/// </param>
	/// <param name="lpbmi">A pointer to a BITMAPINFO structure that contains information about the DIB.</param>
	/// <param name="iUsage">
	/// <para>
	/// Specifies whether the <c>bmiColors</c> member of the BITMAPINFO structure was provided and, if so, whether <c>bmiColors</c>
	/// contains explicit red, green, blue (RGB) values or indexes. The iUsage parameter must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIB_PAL_COLORS</term>
	/// <term>The array contains 16-bit indexes into the logical palette of the source device context.</term>
	/// </item>
	/// <item>
	/// <term>DIB_RGB_COLORS</term>
	/// <term>The color table contains literal RGB values.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see the Remarks section.</para>
	/// </param>
	/// <param name="rop">
	/// A raster-operation code that specifies how the source pixels, the destination device context's current brush, and the destination
	/// pixels are to be combined to form the new image. For a list of some common raster operation codes, see BitBlt.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the number of scan lines copied. Note that this value can be negative for mirrored content.
	/// </para>
	/// <para>If the function fails, or no scan lines are copied, the return value is 0.</para>
	/// <para>
	/// If the driver cannot support the JPEG or PNG file image passed to <c>StretchDIBits</c>, the function will fail and return
	/// GDI_ERROR. If failure does occur, the application must fall back on its own JPEG or PNG support to decompress the image into a
	/// bitmap, and then pass the bitmap to <c>StretchDIBits</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The origin of a bottom-up DIB is the lower-left corner; the origin of a top-down DIB is the upper-left corner.</para>
	/// <para>
	/// <c>StretchDIBits</c> creates a mirror image of a bitmap if the signs of the nSrcWidth and nDestWidth parameters, or if the
	/// nSrcHeight and nDestHeight parameters differ. If nSrcWidth and nDestWidth have different signs, the function creates a mirror
	/// image of the bitmap along the x-axis. If nSrcHeight and nDestHeight have different signs, the function creates a mirror image of
	/// the bitmap along the y-axis.
	/// </para>
	/// <para>
	/// <c>StretchDIBits</c> creates a top-down image if the sign of the <c>biHeight</c> member of the BITMAPINFOHEADER structure for the
	/// DIB is negative. For a code example, see Sizing a JPEG or PNG Image.
	/// </para>
	/// <para>
	/// This function allows a JPEG or PNG image to be passed as the source image. How each parameter is used remains the same, except:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the <c>biCompression</c> member of BITMAPINFOHEADER is BI_JPEG or BI_PNG, lpBits points to a buffer containing a JPEG or PNG
	/// image, respectively. The <c>biSizeImage</c> member of the <c>BITMAPINFOHEADER</c> structure specifies the size of the buffer. The
	/// iUsage parameter must be set to DIB_RGB_COLORS. The dwRop parameter must be set to SRCCOPY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To ensure proper metafile spooling while printing, applications must call the CHECKJPEGFORMAT or CHECKPNGFORMAT escape to verify
	/// that the printer recognizes the JPEG or PNG image, respectively, before calling <c>StretchDIBits</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>ICM:</c> Color management is performed if color management has been enabled with a call to SetICMMode with the iEnableICM
	/// parameter set to ICM_ON. If the bitmap specified by lpBitsInfo has a BITMAPV4HEADER that specifies the gamma and endpoints
	/// members, or a BITMAPV5HEADER that specifies either the gamma and endpoints members or the profileData and profileSize members,
	/// then the call treats the bitmap's pixels as being expressed in the color space described by those members, rather than in the
	/// device context's source color space.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Sizing a JPEG or PNG Image.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-stretchdibits int StretchDIBits( HDC hdc, int xDest, int
	// yDest, int DestWidth, int DestHeight, int xSrc, int ySrc, int SrcWidth, int SrcHeight, const VOID *lpBits, const BITMAPINFO
	// *lpbmi, UINT iUsage, DWORD rop );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3d57a79a-338d-48ab-8161-3ce17739bf20")]
	public static extern int StretchDIBits([In] HDC hdc, int xDest, int yDest, int DestWidth, int DestHeight, int xSrc, int ySrc, int SrcWidth,
		int SrcHeight, [In, Optional] IntPtr lpBits, [In] SafeBITMAPINFO lpbmi, DIBColorMode iUsage, RasterOperationMode rop);

	/// <summary>
	/// <para>
	/// The <c>GdiTransparentBlt</c> function performs a bit-block transfer of the color data corresponding to a rectangle of pixels from
	/// the specified source device context into a destination device context.
	/// </para>
	/// <para><c>Note</c> This function is the same as TransparentBlt.</para>
	/// </summary>
	/// <param name="hdcDest">A handle to the destination device context.</param>
	/// <param name="xoriginDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="yoriginDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
	/// <param name="wDest">The width, in logical units, of the destination rectangle.</param>
	/// <param name="hDest">The height, in logical units, of the destination rectangle.</param>
	/// <param name="hdcSrc">A handle to the source device context.</param>
	/// <param name="xoriginSrc">The x-coordinate, in logical units, of the source rectangle.</param>
	/// <param name="yoriginSrc">The y-coordinate, in logical units, of the source rectangle.</param>
	/// <param name="wSrc">The width, in logical units, of the source rectangle.</param>
	/// <param name="hSrc">The height, in logical units, of the source rectangle.</param>
	/// <param name="crTransparent">The RGB color in the source bitmap to treat as transparent.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>GdiTransparentBlt</c> function works with compatible bitmaps (DDBs).</para>
	/// <para>
	/// The GdiTransparentBlt function supports all formats of source bitmaps. However, for 32 bpp bitmaps, it just copies the alpha
	/// value over. Use AlphaBlend to specify 32 bits-per-pixel bitmaps with transparency.
	/// </para>
	/// <para>
	/// If the source and destination rectangles are not the same size, the source bitmap is stretched to match the destination
	/// rectangle. When the SetStretchBltMode function is used, the iStretchMode modes of BLACKONWHITE and WHITEONBLACK are converted to
	/// COLORONCOLOR for the <c>GdiTransparentBlt</c> function.
	/// </para>
	/// <para>
	/// The destination device context specifies the transformation type for the destination coordinates. The source device context
	/// specifies the transformation type for the source coordinates.
	/// </para>
	/// <para>
	/// <c>GdiTransparentBlt</c> does not mirror a bitmap if either the width or height, of either the source or destination, is negative.
	/// </para>
	/// <para>
	/// When used in a multiple monitor system, both hdcSrc and hdcDest must refer to the same device or the function will fail. To
	/// transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling GetDIBits. To display the DIB to
	/// the second device, call SetDIBits or StretchDIBits.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gditransparentblt BOOL GdiTransparentBlt( HDC hdcDest, int
	// xoriginDest, int yoriginDest, int wDest, int hDest, HDC hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, UINT
	// crTransparent );
	[PInvokeData("wingdi.h", MSDNShortId = "82f6db79-f364-480a-ad9d-acf2ad94a295")]
	[DllImport(Lib.Gdi32, SetLastError = true, EntryPoint = "GdiTransparentBlt")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TransparentBlt(HDC hdcDest, int xoriginDest, int yoriginDest, int wDest, int hDest, HDC hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, uint crTransparent);

	/// <summary>
	/// The <c>GRADIENT_RECT</c> structure specifies the index of two vertices in the pVertex array in the <c>GradientFill</c> function.
	/// These two vertices form the upper-left and lower-right boundaries of a rectangle.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>GRADIENT_RECT</c> structure specifies the values of the pVertex array that are used when the dwMode parameter of the
	/// GradientFill function is GRADIENT_FILL_RECT_H or GRADIENT_FILL_RECT_V. For related <c>GradientFill</c> structures, see
	/// GRADIENT_TRIANGLE and TRIVERTEX.
	/// </para>
	/// <para>
	/// The following images shows examples of a rectangle with a gradient fill - one in horizontal mode, the other in vertical mode.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Drawing a Shaded Rectangle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-gradient_rect
	// typedef struct _GRADIENT_RECT { ULONG UpperLeft; ULONG LowerRight; } GRADIENT_RECT, *PGRADIENT_RECT, *LPGRADIENT_RECT;
	[PInvokeData("wingdi.h", MSDNShortId = "8660114a-423f-40a8-b113-e0304bb0f383")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GRADIENT_RECT
	{
		/// <summary>The upper-left corner of a rectangle.</summary>
		public uint UpperLeft;

		/// <summary>The lower-right corner of a rectangle.</summary>
		public uint LowerRight;
	}

	/// <summary>
	/// The <c>GRADIENT_TRIANGLE</c> structure specifies the index of three vertices in the pVertex array in the <c>GradientFill</c>
	/// function. These three vertices form one triangle.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>GRADIENT_TRIANGLE</c> structure specifies the values in the pVertex array that are used when the dwMode parameter of the
	/// GradientFill function is GRADIENT_FILL_TRIANGLE. For related <c>GradientFill</c> structures, see GRADIENT_RECT and TRIVERTEX.
	/// </para>
	/// <para>The following image shows an example of a triangle with a gradient fill.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Drawing a Shaded Triangle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-gradient_triangle typedef struct _GRADIENT_TRIANGLE { ULONG
	// Vertex1; ULONG Vertex2; ULONG Vertex3; } GRADIENT_TRIANGLE, *PGRADIENT_TRIANGLE, *LPGRADIENT_TRIANGLE;
	[PInvokeData("wingdi.h", MSDNShortId = "71f3a4bd-5823-47ae-aa7a-f3058f18c591")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GRADIENT_TRIANGLE
	{
		/// <summary>The first point of the triangle where sides intersect.</summary>
		public uint Vertex1;

		/// <summary>The second point of the triangle where sides intersect.</summary>
		public uint Vertex2;

		/// <summary>The third point of the triangle where sides intersect.</summary>
		public uint Vertex3;
	}

	/// <summary>The <c>TRIVERTEX</c> structure contains color information and position information.</summary>
	/// <remarks>
	/// <para>
	/// In the <c>TRIVERTEX</c> structure, x and y indicate position in the same manner as in the POINTL structure contained in the
	/// wtypes.h header file. <c>Red</c>, <c>Green</c>, <c>Blue</c>, and <c>Alpha</c> members indicate color information at the point x,
	/// y. The color information of each channel is specified as a value from 0x0000 to 0xff00. This allows higher color resolution for
	/// an object that has been split into small triangles for display. The <c>TRIVERTEX</c> structure contains information needed by the
	/// pVertex parameter of GradientFill.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example of the use of this structure, see Drawing a Shaded Triangle or Drawing a Shaded Rectangle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-trivertex typedef struct _TRIVERTEX { LONG x; LONG y; COLOR16
	// Red; COLOR16 Green; COLOR16 Blue; COLOR16 Alpha; } TRIVERTEX, *PTRIVERTEX, *LPTRIVERTEX;
	[PInvokeData("wingdi.h", MSDNShortId = "47b700aa-3410-4610-ba06-dab2b2662f5e")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TRIVERTEX
	{
		/// <summary>The x-coordinate, in logical units, of the upper-left corner of the rectangle.</summary>
		public int x;

		/// <summary>The y-coordinate, in logical units, of the upper-left corner of the rectangle.</summary>
		public int y;

		/// <summary>The color information at the point of x, y.</summary>
		public ushort Red;

		/// <summary>The color information at the point of x, y.</summary>
		public ushort Green;

		/// <summary>The color information at the point of x, y.</summary>
		public ushort Blue;

		/// <summary>The color information at the point of x, y.</summary>
		public ushort Alpha;
	}
}