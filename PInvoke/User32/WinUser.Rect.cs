using System.Drawing;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>The <c>CopyRect</c> function copies the coordinates of one rectangle to another.</summary>
		/// <param name="lprcDst">Pointer to the RECT structure that receives the logical coordinates of the source rectangle.</param>
		/// <param name="lprcSrc">Pointer to the RECT structure whose coordinates are to be copied in logical units.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Rectangles.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-copyrect BOOL CopyRect( LPRECT lprcDst, const RECT
		// *lprcSrc );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "9349ba83-59d6-49d0-ac9d-a4d9589748dd")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CopyRect(out RECT lprcDst, in RECT lprcSrc);

		/// <summary>
		/// The <c>EqualRect</c> function determines whether the two specified rectangles are equal by comparing the coordinates of their
		/// upper-left and lower-right corners.
		/// </summary>
		/// <param name="lprc1">Pointer to a RECT structure that contains the logical coordinates of the first rectangle.</param>
		/// <param name="lprc2">Pointer to a RECT structure that contains the logical coordinates of the second rectangle.</param>
		/// <returns>
		/// <para>If the two rectangles are identical, the return value is nonzero.</para>
		/// <para>If the two rectangles are not identical, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>EqualRect</c> function does not treat empty rectangles as equal if their coordinates are different.</para>
		/// <para>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-equalrect BOOL EqualRect( const RECT *lprc1, const RECT
		// *lprc2 );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "00763184-6b60-4095-b71e-5a851c2643aa")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EqualRect(in RECT lprc1, in RECT lprc2);

		/// <summary>
		/// The <c>InflateRect</c> function increases or decreases the width and height of the specified rectangle. The <c>InflateRect</c>
		/// function adds dx units to the left and right ends of the rectangle and dy units to the top and bottom. The dx and dy parameters
		/// are signed values; positive values increase the width and height, and negative values decrease them.
		/// </summary>
		/// <param name="lprc">A pointer to the RECT structure that increases or decreases in size.</param>
		/// <param name="dx">The amount to increase or decrease the rectangle width. This parameter must be negative to decrease the width.</param>
		/// <param name="dy">The amount to increase or decrease the rectangle height. This parameter must be negative to decrease the height.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-inflaterect BOOL InflateRect( LPRECT lprc, int dx, int dy );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "9a52fb7f-cd35-4426-8753-c26cebef30d5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InflateRect(ref RECT lprc, int dx, int dy);

		/// <summary>
		/// The <c>IntersectRect</c> function calculates the intersection of two source rectangles and places the coordinates of the
		/// intersection rectangle into the destination rectangle. If the source rectangles do not intersect, an empty rectangle (in which
		/// all coordinates are set to zero) is placed into the destination rectangle.
		/// </summary>
		/// <param name="lprcDst">
		/// A pointer to the RECT structure that is to receive the intersection of the rectangles pointed to by the lprcSrc1 and lprcSrc2
		/// parameters. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="lprcSrc1">A pointer to the RECT structure that contains the first source rectangle.</param>
		/// <param name="lprcSrc2">A pointer to the RECT structure that contains the second source rectangle.</param>
		/// <returns>
		/// <para>If the rectangles intersect, the return value is nonzero.</para>
		/// <para>If the rectangles do not intersect, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Rectangles.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-intersectrect BOOL IntersectRect( LPRECT lprcDst, const
		// RECT *lprcSrc1, const RECT *lprcSrc2 );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "da686f78-e557-4ff2-9f24-b229f0c01563")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IntersectRect(out RECT lprcDst, in RECT lprcSrc1, in RECT lprcSrc2);

		/// <summary>
		/// The <c>InvertRect</c> function inverts a rectangle in a window by performing a logical NOT operation on the color values for each
		/// pixel in the rectangle's interior.
		/// </summary>
		/// <param name="hDC">A handle to the device context.</param>
		/// <param name="lprc">A pointer to a RECT structure that contains the logical coordinates of the rectangle to be inverted.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// On monochrome screens, <c>InvertRect</c> makes white pixels black and black pixels white. On color screens, the inversion depends
		/// on how colors are generated for the screen. Calling <c>InvertRect</c> twice for the same rectangle restores the display to its
		/// previous colors.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-invertrect BOOL InvertRect( HDC hDC, const RECT *lprc );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "a8c4dbf1-94ec-46e9-b365-7dfc89e4f176")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InvertRect(HDC hDC, ref RECT lprc);

		/// <summary>
		/// The <c>IsRectEmpty</c> function determines whether the specified rectangle is empty. An empty rectangle is one that has no area;
		/// that is, the coordinate of the right side is less than or equal to the coordinate of the left side, or the coordinate of the
		/// bottom side is less than or equal to the coordinate of the top side.
		/// </summary>
		/// <param name="lprc">Pointer to a RECT structure that contains the logical coordinates of the rectangle.</param>
		/// <returns>
		/// <para>If the rectangle is empty, the return value is nonzero.</para>
		/// <para>If the rectangle is not empty, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Rectangles.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-isrectempty BOOL IsRectEmpty( const RECT *lprc );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "9deeed4f-304e-47a3-8259-ed7bc3815fd7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsRectEmpty(in RECT lprc);

		/// <summary>The <c>OffsetRect</c> function moves the specified rectangle by the specified offsets.</summary>
		/// <param name="lprc">Pointer to a RECT structure that contains the logical coordinates of the rectangle to be moved.</param>
		/// <param name="dx">
		/// Specifies the amount to move the rectangle left or right. This parameter must be a negative value to move the rectangle to the left.
		/// </param>
		/// <param name="dy">
		/// Specifies the amount to move the rectangle up or down. This parameter must be a negative value to move the rectangle up.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Rectangles.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-offsetrect BOOL OffsetRect( LPRECT lprc, int dx, int dy );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "14101ad3-8c6e-459a-974a-1a8a4d8d7906")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool OffsetRect(ref RECT lprc, int dx, int dy);

		/// <summary>
		/// The <c>PtInRect</c> function determines whether the specified point lies within the specified rectangle. A point is within a
		/// rectangle if it lies on the left or top side or is within all four sides. A point on the right or bottom side is considered
		/// outside the rectangle.
		/// </summary>
		/// <param name="lprc">A pointer to a RECT structure that contains the specified rectangle.</param>
		/// <param name="pt">A POINT structure that contains the specified point.</param>
		/// <returns>
		/// <para>If the specified point lies within the rectangle, the return value is nonzero.</para>
		/// <para>If the specified point does not lie within the rectangle, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The rectangle must be normalized before <c>PtInRect</c> is called. That is, lprc.right must be greater than lprc.left and
		/// lprc.bottom must be greater than lprc.top. If the rectangle is not normalized, a point is never considered inside of the rectangle.
		/// </para>
		/// <para>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Rectangles.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-ptinrect BOOL PtInRect( const RECT *lprc, POINT pt );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "8a47a238-082c-44b8-a270-5ebb4d3d9fc8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PtInRect(in RECT lprc, Point pt);

		/// <summary>
		/// The <c>SetRect</c> function sets the coordinates of the specified rectangle. This is equivalent to assigning the left, top,
		/// right, and bottom arguments to the appropriate members of the <c>RECT</c> structure.
		/// </summary>
		/// <param name="lprc">Pointer to the RECT structure that contains the rectangle to be set.</param>
		/// <param name="xLeft">Specifies the x-coordinate of the rectangle's upper-left corner.</param>
		/// <param name="yTop">Specifies the y-coordinate of the rectangle's upper-left corner.</param>
		/// <param name="xRight">Specifies the x-coordinate of the rectangle's lower-right corner.</param>
		/// <param name="yBottom">Specifies the y-coordinate of the rectangle's lower-right corner.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Rectangles.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setrect BOOL SetRect( LPRECT lprc, int xLeft, int yTop,
		// int xRight, int yBottom );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "346c573b-eaf7-4ca6-bd36-18074f7eccf5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetRect(out RECT lprc, int xLeft, int yTop, int xRight, int yBottom);

		/// <summary>The <c>SetRectEmpty</c> function creates an empty rectangle in which all coordinates are set to zero.</summary>
		/// <param name="lprc">Pointer to the RECT structure that contains the coordinates of the rectangle.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Rectangles.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setrectempty BOOL SetRectEmpty( LPRECT lprc );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "d3c677ae-e45c-4d54-8521-75954a466a68")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetRectEmpty(ref RECT lprc);

		/// <summary>
		/// The <c>SubtractRect</c> function determines the coordinates of a rectangle formed by subtracting one rectangle from another.
		/// </summary>
		/// <param name="lprcDst">
		/// A pointer to a RECT structure that receives the coordinates of the rectangle determined by subtracting the rectangle pointed to
		/// by lprcSrc2 from the rectangle pointed to by lprcSrc1.
		/// </param>
		/// <param name="lprcSrc1">A pointer to a RECT structure from which the function subtracts the rectangle pointed to by lprcSrc2.</param>
		/// <param name="lprcSrc2">A pointer to a RECT structure that the function subtracts from the rectangle pointed to by lprcSrc1.</param>
		/// <returns>
		/// <para>If the resulting rectangle is empty, the return value is zero.</para>
		/// <para>If the resulting rectangle is not empty, the return value is nonzero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The function only subtracts the rectangle specified by lprcSrc2 from the rectangle specified by lprcSrc1 when the rectangles
		/// intersect completely in either the x- or y-direction. For example, if *lprcSrc1 has the coordinates (10,10,100,100) and *lprcSrc2
		/// has the coordinates (50,50,150,150), the function sets the coordinates of the rectangle pointed to by lprcDst to (10,10,100,100).
		/// If *lprcSrc1 has the coordinates (10,10,100,100) and *lprcSrc2 has the coordinates (50,10,150,150), however, the function sets
		/// the coordinates of the rectangle pointed to by lprcDst to (10,10,50,100). In other words, the resulting rectangle is the bounding
		/// box of the geometric difference.
		/// </para>
		/// <para>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-subtractrect BOOL SubtractRect( LPRECT lprcDst, const RECT
		// *lprcSrc1, const RECT *lprcSrc2 );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "85c8edae-af2b-4c6c-af37-2631e8b4edcd")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SubtractRect(out RECT lprcDst, in RECT lprcSrc1, in RECT lprcSrc2);

		/// <summary>
		/// The <c>UnionRect</c> function creates the union of two rectangles. The union is the smallest rectangle that contains both source rectangles.
		/// </summary>
		/// <param name="lprcDst">
		/// A pointer to the RECT structure that will receive a rectangle containing the rectangles pointed to by the lprcSrc1 and lprcSrc2 parameters.
		/// </param>
		/// <param name="lprcSrc1">A pointer to the RECT structure that contains the first source rectangle.</param>
		/// <param name="lprcSrc2">A pointer to the RECT structure that contains the second source rectangle.</param>
		/// <returns>
		/// <para>If the specified structure contains a nonempty rectangle, the return value is nonzero.</para>
		/// <para>If the specified structure does not contain a nonempty rectangle, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system ignores the dimensions of an empty rectangle that is, a rectangle in which all coordinates are set to zero, so that it
		/// has no height or no width.
		/// </para>
		/// <para>
		/// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
		/// Instead, all rectangle coordinates and dimensions are given in signed, logical values. The mapping mode and the function in which
		/// the rectangle is used determine the units of measure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-unionrect BOOL UnionRect( LPRECT lprcDst, const RECT
		// *lprcSrc1, const RECT *lprcSrc2 );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "f2da2df4-3f09-4c54-afd1-c728805f0f64")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnionRect(out RECT lprcDst, in RECT lprcSrc1, in RECT lprcSrc2);
	}
}