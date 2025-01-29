using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>Copies a region from one region to another. The regions are assumed to be in the same coordinate system.</summary>
	/// <param name="hrgnDst">
	/// A handle to a new region with dimensions equal to <paramref name="hrgnSrc"/>. (This region must exist before <c>CombineRgn</c> is called.)
	/// </param>
	/// <param name="hrgnSrc">A handle to the region to be copied.</param>
	/// <returns>
	/// <para>The return value specifies the type of the resulting region. It can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>NULLREGION</term>
	/// <term>The region is empty.</term>
	/// </item>
	/// <item>
	/// <term>SIMPLEREGION</term>
	/// <term>The region is a single rectangle.</term>
	/// </item>
	/// <item>
	/// <term>COMPLEXREGION</term>
	/// <term>The region is more than a single rectangle.</term>
	/// </item>
	/// <item>
	/// <term>ERROR</term>
	/// <term>No region is created.</term>
	/// </item>
	/// </list>
	/// </returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static RGN_TYPE CopyRgn(HRGN hrgnDst, HRGN hrgnSrc) => CombineRgn(hrgnDst, hrgnSrc, HRGN.NULL, 0);

	/// <summary>
	/// Deletes a logical bitmap, freeing all system resources associated with the object. After the object is deleted, the specified handle
	/// is no longer valid.
	/// </summary>
	/// <param name="hbm">A handle to a logical bitmap.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the specified handle is not valid or is currently selected into a DC, the
	/// return value is zero.
	/// </returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DeleteBitmap(HBITMAP hbm) => DeleteObject(hbm);

	/// <summary>
	/// Deletes a logical brush, freeing all system resources associated with the object. After the object is deleted, the specified handle
	/// is no longer valid.
	/// </summary>
	/// <param name="hbr">A handle to a logical brush.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the specified handle is not valid or is currently selected into a DC, the
	/// return value is zero.
	/// </returns>
	/// <remarks>
	/// Do not delete a drawing object (pen or brush) while it is still selected into a DC.
	/// <para>When a pattern brush is deleted, the bitmap associated with the brush is not deleted. The bitmap must be deleted independently.</para>
	/// </remarks>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DeleteBrush(HBRUSH hbr) => DeleteObject(hbr);

	/// <summary>
	/// Deletes a logical font, freeing all system resources associated with the object. After the object is deleted, the specified handle
	/// is no longer valid.
	/// </summary>
	/// <param name="hfont">A handle to a logical font.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the specified handle is not valid or is currently selected into a DC, the
	/// return value is zero.
	/// </returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DeleteFont(HFONT hfont) => DeleteObject(hfont);

	/// <summary>
	/// Deletes a logical palette, freeing all system resources associated with the object. After the object is deleted, the specified
	/// handle is no longer valid.
	/// </summary>
	/// <param name="hpal">A handle to a logical palette.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the specified handle is not valid or is currently selected into a DC, the
	/// return value is zero.
	/// </returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DeletePalette(HPALETTE hpal) => DeleteObject(hpal);

	/// <summary>
	/// Deletes a logical pen, freeing all system resources associated with the object. After the object is deleted, the specified handle is
	/// no longer valid.
	/// </summary>
	/// <param name="hpen">A handle to a logical pen.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the specified handle is not valid or is currently selected into a DC, the
	/// return value is zero.
	/// </returns>
	/// <remarks>Do not delete a drawing object (pen or brush) while it is still selected into a DC.</remarks>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool DeletePen(HPEN hpen) => DeleteObject(hpen);

	/// <summary>
	/// Deletes a logical region, freeing all system resources associated with the object. After the object is deleted, the specified handle
	/// is no longer valid.
	/// </summary>
	/// <param name="hrgn">A handle to a logical region.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the specified handle is not valid or is currently selected into a DC, the
	/// return value is zero.
	/// </returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void DeleteRgn(HRGN hrgn) => DeleteObject(hrgn);

	/// <summary>The <c>GetStockObject</c> function retrieves a handle to one of the stock brushes.</summary>
	/// <param name="i">
	/// <para>The type of stock object. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BLACK_BRUSH</term>
	/// <term>Black brush.</term>
	/// </item>
	/// <item>
	/// <term>DKGRAY_BRUSH</term>
	/// <term>Dark gray brush.</term>
	/// </item>
	/// <item>
	/// <term>DC_BRUSH</term>
	/// <term>
	/// Solid color brush. The default color is white. The color can be changed by using the SetDCBrushColor function. For more information,
	/// see the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GRAY_BRUSH</term>
	/// <term>Gray brush.</term>
	/// </item>
	/// <item>
	/// <term>HOLLOW_BRUSH</term>
	/// <term>Hollow brush (equivalent to NULL_BRUSH).</term>
	/// </item>
	/// <item>
	/// <term>LTGRAY_BRUSH</term>
	/// <term>Light gray brush.</term>
	/// </item>
	/// <item>
	/// <term>NULL_BRUSH</term>
	/// <term>Null brush (equivalent to HOLLOW_BRUSH).</term>
	/// </item>
	/// <item>
	/// <term>WHITE_BRUSH</term>
	/// <term>White brush.</term>
	/// </item>
	/// <item>
	/// <term>BLACK_PEN</term>
	/// <term>Black pen.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the requested logical object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use the DKGRAY_BRUSH, GRAY_BRUSH, and LTGRAY_BRUSH stock objects only in windows with the CS_HREDRAW and CS_VREDRAW styles. Using a
	/// gray stock brush in any other style of window can lead to misalignment of brush patterns after a window is moved or sized. The
	/// origins of stock brushes cannot be adjusted.
	/// </para>
	/// <para>The HOLLOW_BRUSH and NULL_BRUSH stock objects are equivalent.</para>
	/// <para>It is not necessary (but it is not harmful) to delete stock objects by calling DeleteObject.</para>
	/// <para>
	/// Both DC_BRUSH and DC_PEN can be used interchangeably with other stock objects like BLACK_BRUSH and BLACK_PEN. For information on
	/// retrieving the current pen or brush color, see GetDCBrushColor and GetDCPenColor. See Setting the Pen or Brush Color for an example
	/// of setting colors. The <c>GetStockObject</c> function with an argument of DC_BRUSH or DC_PEN can be used interchangeably with the
	/// SetDCPenColor and SetDCBrushColor functions.
	/// </para>
	/// </remarks>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBRUSH GetStockBrush(StockObjectType i) => GetStockObject(i);

	/// <summary>Retrieves a handle to one of the stock fonts.</summary>
	/// <param name="i">
	/// <para>The type of stock object. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ANSI_FIXED_FONT</term>
	/// <term>Windows fixed-pitch (monospace) system font.</term>
	/// </item>
	/// <item>
	/// <term>ANSI_VAR_FONT</term>
	/// <term>Windows variable-pitch (proportional space) system font.</term>
	/// </item>
	/// <item>
	/// <term>DEVICE_DEFAULT_FONT</term>
	/// <term>Device-dependent font.</term>
	/// </item>
	/// <item>
	/// <term>DEFAULT_GUI_FONT</term>
	/// <term>
	/// Default font for user interface objects such as menus and dialog boxes. It is not recommended that you use DEFAULT_GUI_FONT or
	/// SYSTEM_FONT to obtain the font used by dialogs and windows; for more information, see the remarks section. The default font is Tahoma.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OEM_FIXED_FONT</term>
	/// <term>Original equipment manufacturer (OEM) dependent fixed-pitch (monospace) font.</term>
	/// </item>
	/// <item>
	/// <term>SYSTEM_FONT</term>
	/// <term>
	/// System font. By default, the system uses the system font to draw menus, dialog box controls, and text. It is not recommended that
	/// you use DEFAULT_GUI_FONT or SYSTEM_FONT to obtain the font used by dialogs and windows; for more information, see the remarks
	/// section. The default system font is Tahoma.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SYSTEM_FIXED_FONT</term>
	/// <term>
	/// Fixed-pitch (monospace) system font. This stock object is provided only for compatibility with 16-bit Windows versions earlier than 3.0.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the requested logical object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>It is not necessary (but it is not harmful) to delete stock objects by calling DeleteObject.</para>
	/// </remarks>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFONT GetStockFont(StockObjectType i) => GetStockObject(i);

	/// <summary>Retrieves a handle to one of the stock pens.</summary>
	/// <param name="i">
	/// <para>The type of stock object. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DC_PEN</term>
	/// <term>
	/// Solid pen color. The default color is white. The color can be changed by using the SetDCPenColor function. For more information, see
	/// the Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NULL_PEN</term>
	/// <term>Null pen. The null pen draws nothing.</term>
	/// </item>
	/// <item>
	/// <term>WHITE_PEN</term>
	/// <term>White pen.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the requested logical object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>It is not necessary (but it is not harmful) to delete stock objects by calling DeleteObject.</para>
	/// <para>
	/// Both DC_BRUSH and DC_PEN can be used interchangeably with other stock objects like BLACK_BRUSH and BLACK_PEN. For information on
	/// retrieving the current pen or brush color, see GetDCBrushColor and GetDCPenColor. See Setting the Pen or Brush Color for an example
	/// of setting colors. The <c>GetStockObject</c> function with an argument of DC_BRUSH or DC_PEN can be used interchangeably with the
	/// SetDCPenColor and SetDCBrushColor functions.
	/// </para>
	/// </remarks>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPEN GetStockPen(StockObjectType i) => GetStockObject(i);

	/// <summary>Insets a rectangle by the specified amount.</summary>
	/// <param name="lprc">A pointer to a <see cref="RECT"/> structure that specifies the rectangle to be inset.</param>
	/// <param name="dx">The amount to inset the rectangle horizontally.</param>
	/// <param name="dy">The amount to inset the rectangle vertically.</param>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void InsetRect(ref RECT lprc, int dx, int dy)
	{ lprc.left += dx; lprc.top += dy; lprc.right -= dx; lprc.bottom -= dy; }

	/// <summary>Intersects two regions and stores the result in a third region.</summary>
	/// <param name="hrgnResult">
	/// A handle to a new region with dimensions defined by combining two other regions. (This region must exist before <c>CombineRgn</c> is called.)
	/// </param>
	/// <param name="hrgnA">A handle to the first of two regions to be combined.</param>
	/// <param name="hrgnB">A handle to the second of two regions to be combined.</param>
	/// <returns>
	/// <para>The return value specifies the type of the resulting region. It can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>NULLREGION</term>
	/// <term>The region is empty.</term>
	/// </item>
	/// <item>
	/// <term>SIMPLEREGION</term>
	/// <term>The region is a single rectangle.</term>
	/// </item>
	/// <item>
	/// <term>COMPLEXREGION</term>
	/// <term>The region is more than a single rectangle.</term>
	/// </item>
	/// <item>
	/// <term>ERROR</term>
	/// <term>No region is created.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The three regions need not be distinct. For example, the hrgnSrc1 parameter can equal the hrgnDest parameter.</remarks>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static RGN_TYPE IntersectRgn(HRGN hrgnResult, HRGN hrgnA, HRGN hrgnB) => CombineRgn(hrgnResult, hrgnA, hrgnB, RGN_COMB.RGN_AND);

	/// <summary>Selects an object into the specified device context (DC). The new object replaces the previous object of the same type.</summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="hbm">A handle to the object to be selected.</param>
	/// <returns>A handle to the object being replaced.</returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBITMAP SelectBitmap(HDC hdc, HBITMAP hbm) => SelectObject(hdc, hbm);

	/// <summary>Selects an object into the specified device context (DC). The new object replaces the previous object of the same type.</summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="hbr">A handle to the object to be selected.</param>
	/// <returns>A handle to the object being replaced.</returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HBRUSH SelectBrush(HDC hdc, HBRUSH hbr) => SelectObject(hdc, hbr);

	/// <summary>Selects an object into the specified device context (DC). The new object replaces the previous object of the same type.</summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="hfont">A handle to the object to be selected.</param>
	/// <returns>A handle to the object being replaced.</returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HFONT SelectFont(HDC hdc, HFONT hfont) => SelectObject(hdc, hfont);

	/// <summary>Selects an object into the specified device context (DC). The new object replaces the previous object of the same type.</summary>
	/// <param name="hdc">A handle to the DC.</param>
	/// <param name="hpen">A handle to the object to be selected.</param>
	/// <returns>A handle to the object being replaced.</returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HPEN SelectPen(HDC hdc, HPEN hpen) => SelectObject(hdc, hpen);

	/// <summary>Subtracts two regions and stores the result in a third region.</summary>
	/// <param name="hrgnResult">
	/// A handle to a new region with dimensions defined by combining two other regions. (This region must exist before <c>CombineRgn</c> is called.)
	/// </param>
	/// <param name="hrgnA">A handle to the first of two regions to be combined.</param>
	/// <param name="hrgnB">A handle to the second of two regions to be combined.</param>
	/// <returns>
	/// <para>The return value specifies the type of the resulting region. It can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>NULLREGION</term>
	/// <term>The region is empty.</term>
	/// </item>
	/// <item>
	/// <term>SIMPLEREGION</term>
	/// <term>The region is a single rectangle.</term>
	/// </item>
	/// <item>
	/// <term>COMPLEXREGION</term>
	/// <term>The region is more than a single rectangle.</term>
	/// </item>
	/// <item>
	/// <term>ERROR</term>
	/// <term>No region is created.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The three regions need not be distinct. For example, the hrgnSrc1 parameter can equal the hrgnDest parameter.</remarks>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static RGN_TYPE SubtractRgn(HRGN hrgnResult, HRGN hrgnA, HRGN hrgnB) => CombineRgn(hrgnResult, hrgnA, hrgnB, RGN_COMB.RGN_OR);

	/// <summary>Unions two regions and stores the result in a third region.</summary>
	/// <param name="hrgnResult">
	/// A handle to a new region with dimensions defined by combining two other regions. (This region must exist before <c>CombineRgn</c> is called.)
	/// </param>
	/// <param name="hrgnA">A handle to the first of two regions to be combined.</param>
	/// <param name="hrgnB">A handle to the second of two regions to be combined.</param>
	/// <returns>
	/// <para>The return value specifies the type of the resulting region. It can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>NULLREGION</term>
	/// <term>The region is empty.</term>
	/// </item>
	/// <item>
	/// <term>SIMPLEREGION</term>
	/// <term>The region is a single rectangle.</term>
	/// </item>
	/// <item>
	/// <term>COMPLEXREGION</term>
	/// <term>The region is more than a single rectangle.</term>
	/// </item>
	/// <item>
	/// <term>ERROR</term>
	/// <term>No region is created.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The three regions need not be distinct. For example, the hrgnSrc1 parameter can equal the hrgnDest parameter.</remarks>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static RGN_TYPE UnionRgn(HRGN hrgnResult, HRGN hrgnA, HRGN hrgnB) => CombineRgn(hrgnResult, hrgnA, hrgnB, RGN_COMB.RGN_XOR);

	/// <summary>XORs two regions and stores the result in a third region.</summary>
	/// <param name="hrgnResult">
	/// A handle to a new region with dimensions defined by combining two other regions. (This region must exist before <c>CombineRgn</c> is called.)
	/// </param>
	/// <param name="hrgnA">A handle to the first of two regions to be combined.</param>
	/// <param name="hrgnB">A handle to the second of two regions to be combined.</param>
	/// <returns>
	/// <para>The return value specifies the type of the resulting region. It can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>NULLREGION</term>
	/// <term>The region is empty.</term>
	/// </item>
	/// <item>
	/// <term>SIMPLEREGION</term>
	/// <term>The region is a single rectangle.</term>
	/// </item>
	/// <item>
	/// <term>COMPLEXREGION</term>
	/// <term>The region is more than a single rectangle.</term>
	/// </item>
	/// <item>
	/// <term>ERROR</term>
	/// <term>No region is created.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The three regions need not be distinct. For example, the hrgnSrc1 parameter can equal the hrgnDest parameter.</remarks>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static RGN_TYPE XorRgn(HRGN hrgnResult, HRGN hrgnA, HRGN hrgnB) => CombineRgn(hrgnResult, hrgnA, hrgnB, RGN_COMB.RGN_DIFF);
}