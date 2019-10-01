using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
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
		public static extern SafeHBRUSH CreateBrushIndirect(in LOGBRUSH plbrush);

		/// <summary>
		/// <para>
		/// The <c>CreateDIBPatternBrush</c> function creates a logical brush that has the pattern specified by the specified
		/// device-independent bitmap (DIB). The brush can subsequently be selected into any device context that is associated with a device
		/// that supports raster operations.
		/// </para>
		/// <para>
		/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
		/// CreateDIBPatternBrushPt function.
		/// </para>
		/// </summary>
		/// <param name="h">
		/// <para>
		/// A handle to a global memory object containing a packed DIB, which consists of a BITMAPINFO structure immediately followed by an
		/// array of bytes defining the pixels of the bitmap.
		/// </para>
		/// </param>
		/// <param name="iUsage">
		/// <para>
		/// Specifies whether the <c>bmiColors</c> member of the BITMAPINFO structure is initialized and, if so, whether this member contains
		/// explicit red, green, blue (RGB) values or indexes into a logical palette. The fuColorSpec parameter must be one of the following values.
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
		/// the brush is to be selected.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DIB_RGB_COLORS</term>
		/// <term>A color table is provided and contains literal RGB values.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value identifies a logical brush.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When an application selects a two-color DIB pattern brush into a monochrome device context, the system does not acknowledge the
		/// colors specified in the DIB; instead, it displays the pattern brush using the current background and foreground colors of the
		/// device context. Pixels mapped to the first color of the DIB (offset 0 in the DIB color table) are displayed using the foreground
		/// color; pixels mapped to the second color (offset 1 in the color table) are displayed using the background color.
		/// </para>
		/// <para>When you no longer need the brush, call the DeleteObject function to delete it.</para>
		/// <para>
		/// <c>ICM:</c> No color is done at brush creation. However, color management is performed when the brush is selected into an
		/// ICM-enabled device context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createdibpatternbrush HBRUSH CreateDIBPatternBrush( HGLOBAL
		// h, UINT iUsage );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "d123ef44-e047-4188-a2bc-20e479869dc3")]
		[Obsolete("This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the CreateDIBPatternBrushPt function.")]
		public static extern SafeHBRUSH CreateDIBPatternBrush(IntPtr h, DIBColorMode iUsage);

		/// <summary>
		/// <para>
		/// The <c>CreateDIBPatternBrushPt</c> function creates a logical brush that has the pattern specified by the device-independent
		/// bitmap (DIB).
		/// </para>
		/// </summary>
		/// <param name="lpPackedDIB">
		/// <para>
		/// A pointer to a packed DIB consisting of a BITMAPINFO structure immediately followed by an array of bytes defining the pixels of
		/// the bitmap.
		/// </para>
		/// </param>
		/// <param name="iUsage">
		/// <para>
		/// Specifies whether the <c>bmiColors</c> member of the BITMAPINFO structure contains a valid color table and, if so, whether the
		/// entries in this color table contain explicit red, green, blue (RGB) values or palette indexes. The iUsage parameter must be one
		/// of the following values.
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
		/// the brush is to be selected.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DIB_RGB_COLORS</term>
		/// <term>A color table is provided and contains literal RGB values.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value identifies a logical brush.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>A brush is a bitmap that the system uses to paint the interiors of filled shapes.</para>
		/// <para>
		/// After an application creates a brush by calling <c>CreateDIBPatternBrushPt</c>, it can select that brush into any device context
		/// by calling the SelectObject function.
		/// </para>
		/// <para>When you no longer need the brush, call the DeleteObject function to delete it.</para>
		/// <para>
		/// <c>ICM:</c> No color is done at brush creation. However, color management is performed when the brush is selected into an
		/// ICM-enabled device context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createdibpatternbrushpt HBRUSH CreateDIBPatternBrushPt(
		// const VOID *lpPackedDIB, UINT iUsage );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "0e34d108-fd35-4512-9eb3-c7710af36e95")]
		public static extern SafeHBRUSH CreateDIBPatternBrushPt(IntPtr lpPackedDIB, DIBColorMode iUsage);

		/// <summary>
		/// <para>The <c>CreateHatchBrush</c> function creates a logical brush that has the specified hatch pattern and color.</para>
		/// </summary>
		/// <param name="iHatch">
		/// <para>The hatch style of the brush. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HS_BDIAGONAL</term>
		/// <term>45-degree upward left-to-right hatch</term>
		/// </item>
		/// <item>
		/// <term>HS_CROSS</term>
		/// <term>Horizontal and vertical crosshatch</term>
		/// </item>
		/// <item>
		/// <term>HS_DIAGCROSS</term>
		/// <term>45-degree crosshatch</term>
		/// </item>
		/// <item>
		/// <term>HS_FDIAGONAL</term>
		/// <term>45-degree downward left-to-right hatch</term>
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
		/// </param>
		/// <param name="color">
		/// <para>The foreground color of the brush that is used for the hatches. To create a COLORREF color value, use the RGB macro.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value identifies a logical brush.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>A brush is a bitmap that the system uses to paint the interiors of filled shapes.</para>
		/// <para>
		/// After an application creates a brush by calling <c>CreateHatchBrush</c>, it can select that brush into any device context by
		/// calling the SelectObject function. It can also call SetBkMode to affect the rendering of the brush.
		/// </para>
		/// <para>
		/// If an application uses a hatch brush to fill the backgrounds of both a parent and a child window with matching color, you must
		/// set the brush origin before painting the background of the child window. You can do this by calling the SetBrushOrgEx function.
		/// Your application can retrieve the current brush origin by calling the GetBrushOrgEx function.
		/// </para>
		/// <para>When you no longer need the brush, call the DeleteObject function to delete it.</para>
		/// <para>
		/// <c>ICM:</c> No color is defined at brush creation. However, color management is performed when the brush is selected into an
		/// ICM-enabled device context.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example creates a logical brush that has the specified hatch pattern and color. You can also set a hatch brush
		/// background to transparent or to opaque.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createhatchbrush HBRUSH CreateHatchBrush( int iHatch,
		// COLORREF color );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "0b5849d6-1e22-4ac5-980c-2f2a73b16adb")]
		public static extern SafeHBRUSH CreateHatchBrush(HatchStyle iHatch, COLORREF color);

		/// <summary>
		/// <para>
		/// The <c>CreatePatternBrush</c> function creates a logical brush with the specified bitmap pattern. The bitmap can be a DIB section
		/// bitmap, which is created by the <c>CreateDIBSection</c> function, or it can be a device-dependent bitmap.
		/// </para>
		/// </summary>
		/// <param name="hbm">
		/// <para>A handle to the bitmap to be used to create the logical brush.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value identifies a logical brush.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>A pattern brush is a bitmap that the system uses to paint the interiors of filled shapes.</para>
		/// <para>
		/// After an application creates a brush by calling <c>CreatePatternBrush</c>, it can select that brush into any device context by
		/// calling the SelectObject function.
		/// </para>
		/// <para>
		/// You can delete a pattern brush without affecting the associated bitmap by using the DeleteObject function. Therefore, you can
		/// then use this bitmap to create any number of pattern brushes.
		/// </para>
		/// <para>
		/// A brush created by using a monochrome (1 bit per pixel) bitmap has the text and background colors of the device context to which
		/// it is drawn. Pixels represented by a 0 bit are drawn with the current text color; pixels represented by a 1 bit are drawn with
		/// the current background color.
		/// </para>
		/// <para>
		/// <c>ICM:</c> No color is done at brush creation. However, color management is performed when the brush is selected into an
		/// ICM-enabled device context.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Brushes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createpatternbrush HBRUSH CreatePatternBrush( HBITMAP hbm );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "a3cf347e-9803-4bb0-bdb3-98929ef859ab")]
		public static extern SafeHBRUSH CreatePatternBrush(HBITMAP hbm);

		/// <summary>
		/// <para>The <c>CreateSolidBrush</c> function creates a logical brush that has the specified solid color.</para>
		/// </summary>
		/// <param name="color">
		/// <para>The color of the brush. To create a COLORREF color value, use the RGB macro.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value identifies a logical brush.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>When you no longer need the <c>HBRUSH</c> object, call the DeleteObject function to delete it.</para>
		/// <para>A solid brush is a bitmap that the system uses to paint the interiors of filled shapes.</para>
		/// <para>
		/// After an application creates a brush by calling <c>CreateSolidBrush</c>, it can select that brush into any device context by
		/// calling the SelectObject function.
		/// </para>
		/// <para>
		/// To paint with a system color brush, an application should use instead of , because GetSysColorBrush returns a cached brush
		/// instead of allocating a new one.
		/// </para>
		/// <para>
		/// <c>ICM:</c> No color management is done at brush creation. However, color management is performed when the brush is selected into
		/// an ICM-enabled device context.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating Colored Pens and Brushes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createsolidbrush HBRUSH CreateSolidBrush( COLORREF color );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "e39b5f77-97d8-4ea6-8277-7da12b3367f3")]
		public static extern SafeHBRUSH CreateSolidBrush(COLORREF color);

		/// <summary>
		/// <para>
		/// The <c>GetBrushOrgEx</c> function retrieves the current brush origin for the specified device context. This function replaces the
		/// <c>GetBrushOrg</c> function.
		/// </para>
		/// </summary>
		/// <param name="hdc">
		/// <para>A handle to the device context.</para>
		/// </param>
		/// <param name="lppt">
		/// <para>A pointer to a POINT structure that receives the brush origin, in device coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>A brush is a bitmap that the system uses to paint the interiors of filled shapes.</para>
		/// <para>
		/// The brush origin is a set of coordinates with values between 0 and 7, specifying the location of one pixel in the bitmap. The
		/// default brush origin coordinates are (0,0). For horizontal coordinates, the value 0 corresponds to the leftmost column of pixels;
		/// the value 7 corresponds to the rightmost column. For vertical coordinates, the value 0 corresponds to the uppermost row of
		/// pixels; the value 7 corresponds to the lowermost row. When the system positions the brush at the start of any painting operation,
		/// it maps the origin of the brush to the location in the window's client area specified by the brush origin. For example, if the
		/// origin is set to (2,3), the system maps the origin of the brush (0,0) to the location (2,3) on the window's client area.
		/// </para>
		/// <para>
		/// If an application uses a brush to fill the backgrounds of both a parent and a child window with matching colors, it may be
		/// necessary to set the brush origin after painting the parent window but before painting the child window.
		/// </para>
		/// <para>
		/// The system automatically tracks the origin of all window-managed device contexts and adjusts their brushes as necessary to
		/// maintain an alignment of patterns on the surface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getbrushorgex BOOL GetBrushOrgEx( HDC hdc, LPPOINT lppt );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "0b938237-cb06-4776-86f8-14478abcee00")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetBrushOrgEx(HDC hdc, out Point lppt);

		/// <summary>
		/// <para>
		/// The <c>PatBlt</c> function paints the specified rectangle using the brush that is currently selected into the specified device
		/// context. The brush color and the surface color or colors are combined by using the specified raster operation.
		/// </para>
		/// </summary>
		/// <param name="hdc">
		/// <para>A handle to the device context.</para>
		/// </param>
		/// <param name="x">
		/// <para>The x-coordinate, in logical units, of the upper-left corner of the rectangle to be filled.</para>
		/// </param>
		/// <param name="y">
		/// <para>The y-coordinate, in logical units, of the upper-left corner of the rectangle to be filled.</para>
		/// </param>
		/// <param name="w">
		/// <para>The width, in logical units, of the rectangle.</para>
		/// </param>
		/// <param name="h">
		/// <para>The height, in logical units, of the rectangle.</para>
		/// </param>
		/// <param name="rop">
		/// <para>The raster operation code. This code can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PATCOPY</term>
		/// <term>Copies the specified pattern into the destination bitmap.</term>
		/// </item>
		/// <item>
		/// <term>PATINVERT</term>
		/// <term>Combines the colors of the specified pattern with the colors of the destination rectangle by using the Boolean XOR operator.</term>
		/// </item>
		/// <item>
		/// <term>DSTINVERT</term>
		/// <term>Inverts the destination rectangle.</term>
		/// </item>
		/// <item>
		/// <term>BLACKNESS</term>
		/// <term>
		/// Fills the destination rectangle using the color associated with index 0 in the physical palette. (This color is black for the
		/// default physical palette.)
		/// </term>
		/// </item>
		/// <item>
		/// <term>WHITENESS</term>
		/// <term>
		/// Fills the destination rectangle using the color associated with index 1 in the physical palette. (This color is white for the
		/// default physical palette.)
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The values of the dwRop parameter for this function are a limited subset of the full 256 ternary raster-operation codes; in
		/// particular, an operation code that refers to a source rectangle cannot be used.
		/// </para>
		/// <para>
		/// Not all devices support the <c>PatBlt</c> function. For more information, see the description of the RC_BITBLT capability in the
		/// GetDeviceCaps function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see "Example of Menu-Item Bitmaps" in Using Menus.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-patblt BOOL PatBlt( HDC hdc, int x, int y, int w, int h,
		// DWORD rop );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "6deea8ef-b55d-4086-a54e-3f89bb17c6cd")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PatBlt(HDC hdc, int x, int y, int w, int h, RasterOperationMode rop);

		/// <summary>
		/// <para>
		/// The <c>SetBrushOrgEx</c> function sets the brush origin that GDI assigns to the next brush an application selects into the
		/// specified device context.
		/// </para>
		/// </summary>
		/// <param name="hdc">
		/// <para>A handle to the device context.</para>
		/// </param>
		/// <param name="x">
		/// <para>
		/// The x-coordinate, in device units, of the new brush origin. If this value is greater than the brush width, its value is reduced
		/// using the modulus operator (nXOrg <c>mod</c> brush width).
		/// </para>
		/// </param>
		/// <param name="y">
		/// <para>
		/// The y-coordinate, in device units, of the new brush origin. If this value is greater than the brush height, its value is reduced
		/// using the modulus operator (nYOrg <c>mod</c> brush height).
		/// </para>
		/// </param>
		/// <param name="lppt">
		/// <para>A pointer to a POINT structure that receives the previous brush origin.</para>
		/// <para>This parameter can be <c>NULL</c> if the previous brush origin is not required.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>A brush is a bitmap that the system uses to paint the interiors of filled shapes.</para>
		/// <para>
		/// The brush origin is a pair of coordinates specifying the location of one pixel in the bitmap. The default brush origin
		/// coordinates are (0,0). For horizontal coordinates, the value 0 corresponds to the leftmost column of pixels; the width
		/// corresponds to the rightmost column. For vertical coordinates, the value 0 corresponds to the uppermost row of pixels; the height
		/// corresponds to the lowermost row.
		/// </para>
		/// <para>
		/// The system automatically tracks the origin of all window-managed device contexts and adjusts their brushes as necessary to
		/// maintain an alignment of patterns on the surface. The brush origin that is set with this call is relative to the upper-left
		/// corner of the client area.
		/// </para>
		/// <para>
		/// An application should call <c>SetBrushOrgEx</c> after setting the bitmap stretching mode to HALFTONE by using SetStretchBltMode.
		/// This must be done to avoid brush misalignment.
		/// </para>
		/// <para>
		/// The system automatically tracks the origin of all window-managed device contexts and adjusts their brushes as necessary to
		/// maintain an alignment of patterns on the surface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-setbrushorgex BOOL SetBrushOrgEx( HDC hdc, int x, int y,
		// LPPOINT lppt );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "dcc7575a-49fd-4306-8baa-57e9e0d5ed1f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetBrushOrgEx(HDC hdc, int x, int y, in Point lppt);

		/// <summary>
		/// <c>SetDCBrushColor</c> function sets the current device context (DC) brush color to the specified color value. If the device
		/// cannot represent the specified color value, the color is set to the nearest physical color.
		/// </summary>
		/// <param name="hdc">A handle to the DC.</param>
		/// <param name="color">The new brush color.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value specifies the previous DC brush color as a COLORREF value.</para>
		/// <para>If the function fails, the return value is CLR_INVALID.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When the stock DC_BRUSH is selected in a DC, all the subsequent drawings will be done using the DC brush color until the stock
		/// brush is deselected. The default DC_BRUSH color is WHITE.
		/// </para>
		/// <para>
		/// The function returns the previous DC_BRUSH color, even if the stock brush DC_BRUSH is not selected in the DC: however, this will
		/// not be used in drawing operations until the stock DC_BRUSH is selected in the DC.
		/// </para>
		/// <para>
		/// The GetStockObject function with an argument of DC_BRUSH or DC_PEN can be used interchangeably with the SetDCPenColor and
		/// <c>SetDCBrushColor</c> functions.
		/// </para>
		/// <para><c>ICM:</c> Color management is performed if ICM is enabled.</para>
		/// <para>Examples</para>
		/// <para>For an example of setting colors, see Setting the Pen or Brush Color.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdcbrushcolor
		// COLORREF SetDCBrushColor( HDC hdc, COLORREF color );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "4feed536-2f1d-4a25-8311-7cae303167ca")]
		public static extern COLORREF SetDCBrushColor(HDC hdc, COLORREF color);

		/// <summary>
		/// The <c>LOGBRUSH</c> structure defines the style, color, and pattern of a physical brush. It is used by the CreateBrushIndirect
		/// and ExtCreatePen functions.
		/// </summary>
		/// <remarks>
		/// Although <c>lbColor</c> controls the foreground color of a hatch brush, the SetBkMode and SetBkColor functions control the
		/// background color.
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