using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>
	/// The <c>LineDDAProc</c> function is an application-defined callback function used with the LineDDA function. It is used to process
	/// coordinates. The <c>LINEDDAPROC</c> type defines a pointer to this callback function. <c>LineDDAProc</c> is a placeholder for the
	/// application-defined function name.
	/// </summary>
	/// <param name="X">Specifies the x-coordinate of the current point.</param>
	/// <param name="Y">Specifies the y-coordinate of the current point.</param>
	/// <param name="lpData">Points to the application-defined data.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>An application registers a <c>LineDDAProc</c> function by passing its address to the LineDDA function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nc-wingdi-lineddaproc LINEDDAPROC Lineddaproc; void Lineddaproc( int
	// Arg1, int Arg2, LPARAM Arg3 ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("wingdi.h", MSDNShortId = "4a8b1120-4b0b-4029-8b49-4371c0627bba")]
	public delegate void LineDDAProc(int X, int Y, IntPtr lpData);

	/// <summary>
	/// <para>The <c>ArcDirection</c> enumeration is used in setting the drawing direction for arcs and rectangles.</para>
	/// <para><c>AD_COUNTERCLOCKWISE:</c> Figures drawn counterclockwise.</para>
	/// <para><c>AD_CLOCKWISE:</c> Figures drawn clockwise.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-emf/9886c62f-1788-4118-894a-76d5a8733685
	[PInvokeData("wingdi.h")]
	public enum ArcDirection
	{
		/// <summary>Figures drawn counterclockwise.</summary>
		AD_COUNTERCLOCKWISE = 1,

		/// <summary>Figures drawn clockwise.</summary>
		AD_CLOCKWISE = 2
	}

	/// <summary>
	/// The <c>AngleArc</c> function draws a line segment and an arc. The line segment is drawn from the current position to the
	/// beginning of the arc. The arc is drawn along the perimeter of a circle with the given radius and center. The length of the arc is
	/// defined by the given start and sweep angles.
	/// </summary>
	/// <param name="hdc">Handle to a device context.</param>
	/// <param name="x">Specifies the x-coordinate, in logical units, of the center of the circle.</param>
	/// <param name="y">Specifies the y-coordinate, in logical units, of the center of the circle.</param>
	/// <param name="r">Specifies the radius, in logical units, of the circle. This value must be positive.</param>
	/// <param name="StartAngle">Specifies the start angle, in degrees, relative to the x-axis.</param>
	/// <param name="SweepAngle">Specifies the sweep angle, in degrees, relative to the starting angle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>AngleArc</c> function moves the current position to the ending point of the arc.</para>
	/// <para>
	/// The arc drawn by this function may appear to be elliptical, depending on the current transformation and mapping mode. Before
	/// drawing the arc, <c>AngleArc</c> draws the line segment from the current position to the beginning of the arc.
	/// </para>
	/// <para>
	/// The arc is drawn by constructing an imaginary circle around the specified center point with the specified radius. The starting
	/// point of the arc is determined by measuring counterclockwise from the x-axis of the circle by the number of degrees in the start
	/// angle. The ending point is similarly located by measuring counterclockwise from the starting point by the number of degrees in
	/// the sweep angle.
	/// </para>
	/// <para>If the sweep angle is greater than 360 degrees, the arc is swept multiple times.</para>
	/// <para>This function draws lines by using the current pen. The figure is not filled.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Drawing a Pie Chart.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-anglearc BOOL AngleArc( HDC hdc, int x, int y, DWORD r, FLOAT
	// StartAngle, FLOAT SweepAngle );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "65c38da1-ab7d-4e80-83e3-ba1db66f8fd9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AngleArc(HDC hdc, int x, int y, uint r, float StartAngle, float SweepAngle);

	/// <summary>The <c>Arc</c> function draws an elliptical arc.</summary>
	/// <param name="hdc">A handle to the device context where drawing takes place.</param>
	/// <param name="x1">The x-coordinate, in logical units, of the upper-left corner of the bounding rectangle.</param>
	/// <param name="y1">The y-coordinate, in logical units, of the upper-left corner of the bounding rectangle.</param>
	/// <param name="x2">The x-coordinate, in logical units, of the lower-right corner of the bounding rectangle.</param>
	/// <param name="y2">The y-coordinate, in logical units, of the lower-right corner of the bounding rectangle.</param>
	/// <param name="x3">
	/// The x-coordinate, in logical units, of the ending point of the radial line defining the starting point of the arc.
	/// </param>
	/// <param name="y3">
	/// The y-coordinate, in logical units, of the ending point of the radial line defining the starting point of the arc.
	/// </param>
	/// <param name="x4">
	/// The x-coordinate, in logical units, of the ending point of the radial line defining the ending point of the arc.
	/// </param>
	/// <param name="y4">
	/// The y-coordinate, in logical units, of the ending point of the radial line defining the ending point of the arc.
	/// </param>
	/// <returns>
	/// <para>If the arc is drawn, the return value is nonzero.</para>
	/// <para>If the arc is not drawn, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The points (nLeftRect, nTopRect) and (nRightRect, nBottomRect) specify the bounding rectangle. An ellipse formed by the specified
	/// bounding rectangle defines the curve of the arc. The arc extends in the current drawing direction from the point where it
	/// intersects the radial from the center of the bounding rectangle to the (nXStartArc, nYStartArc) point. The arc ends where it
	/// intersects the radial from the center of the bounding rectangle to the (nXEndArc, nYEndArc) point. If the starting point and
	/// ending point are the same, a complete ellipse is drawn.
	/// </para>
	/// <para>The arc is drawn using the current pen; it is not filled.</para>
	/// <para>The current position is neither used nor updated by <c>Arc</c>.</para>
	/// <para>
	/// Use the GetArcDirection and SetArcDirection functions to get and set the current drawing direction for a device context. The
	/// default drawing direction is counterclockwise.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-arc BOOL Arc( HDC hdc, int x1, int y1, int x2, int y2, int x3,
	// int y3, int x4, int y4 );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "c15a2173-0fad-4a8a-b0f9-cd39fe4e7bac")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool Arc(HDC hdc, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4);

	/// <summary>The <c>ArcTo</c> function draws an elliptical arc.</summary>
	/// <param name="hdc">A handle to the device context where drawing takes place.</param>
	/// <param name="left">The x-coordinate, in logical units, of the upper-left corner of the bounding rectangle.</param>
	/// <param name="top">The y-coordinate, in logical units, of the upper-left corner of the bounding rectangle.</param>
	/// <param name="right">The x-coordinate, in logical units, of the lower-right corner of the bounding rectangle.</param>
	/// <param name="bottom">The y-coordinate, in logical units, of the lower-right corner of the bounding rectangle.</param>
	/// <param name="xr1">The x-coordinate, in logical units, of the endpoint of the radial defining the starting point of the arc.</param>
	/// <param name="yr1">The y-coordinate, in logical units, of the endpoint of the radial defining the starting point of the arc.</param>
	/// <param name="xr2">The x-coordinate, in logical units, of the endpoint of the radial defining the ending point of the arc.</param>
	/// <param name="yr2">The y-coordinate, in logical units, of the endpoint of the radial defining the ending point of the arc.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para><c>ArcTo</c> is similar to the Arc function, except that the current position is updated.</para>
	/// <para>
	/// The points (nLeftRect, nTopRect) and (nRightRect, nBottomRect) specify the bounding rectangle. An ellipse formed by the specified
	/// bounding rectangle defines the curve of the arc. The arc extends counterclockwise from the point where it intersects the radial
	/// line from the center of the bounding rectangle to the (nXRadial1, nYRadial1) point. The arc ends where it intersects the radial
	/// line from the center of the bounding rectangle to the (nXRadial2, nYRadial2) point. If the starting point and ending point are
	/// the same, a complete ellipse is drawn.
	/// </para>
	/// <para>
	/// A line is drawn from the current position to the starting point of the arc. If no error occurs, the current position is set to
	/// the ending point of the arc.
	/// </para>
	/// <para>The arc is drawn using the current pen; it is not filled.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-arcto BOOL ArcTo( HDC hdc, int left, int top, int right, int
	// bottom, int xr1, int yr1, int xr2, int yr2 );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "5e358a14-9f39-4267-9a44-c8bf05b5dfbb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ArcTo(HDC hdc, int left, int top, int right, int bottom, int xr1, int yr1, int xr2, int yr2);

	/// <summary>
	/// The <c>Chord</c> function draws a chord (a region bounded by the intersection of an ellipse and a line segment, called a secant).
	/// The chord is outlined by using the current pen and filled by using the current brush.
	/// </summary>
	/// <param name="hdc">A handle to the device context in which the chord appears.</param>
	/// <param name="x1">The x-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.</param>
	/// <param name="y1">The y-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.</param>
	/// <param name="x2">The x-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.</param>
	/// <param name="y2">The y-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.</param>
	/// <param name="x3">The x-coordinate, in logical coordinates, of the endpoint of the radial defining the beginning of the chord.</param>
	/// <param name="y3">The y-coordinate, in logical coordinates, of the endpoint of the radial defining the beginning of the chord.</param>
	/// <param name="x4">The x-coordinate, in logical coordinates, of the endpoint of the radial defining the end of the chord.</param>
	/// <param name="y4">The y-coordinate, in logical coordinates, of the endpoint of the radial defining the end of the chord.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The curve of the chord is defined by an ellipse that fits the specified bounding rectangle. The curve begins at the point where
	/// the ellipse intersects the first radial and extends counterclockwise to the point where the ellipse intersects the second radial.
	/// The chord is closed by drawing a line from the intersection of the first radial and the curve to the intersection of the second
	/// radial and the curve.
	/// </para>
	/// <para>If the starting point and ending point of the curve are the same, a complete ellipse is drawn.</para>
	/// <para>The current position is neither used nor updated by <c>Chord</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-chord BOOL Chord( HDC hdc, int x1, int y1, int x2, int y2, int
	// x3, int y3, int x4, int y4 );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d6752c47-96a5-4fac-a1bb-0611a91f03f9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool Chord(HDC hdc, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4);

	/// <summary>
	/// The <c>Ellipse</c> function draws an ellipse. The center of the ellipse is the center of the specified bounding rectangle. The
	/// ellipse is outlined by using the current pen and is filled by using the current brush.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="left">The x-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.</param>
	/// <param name="top">The y-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.</param>
	/// <param name="right">The x-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.</param>
	/// <param name="bottom">The y-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The current position is neither used nor updated by <c>Ellipse</c>.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Using Filled Shapes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-ellipse BOOL Ellipse( HDC hdc, int left, int top, int right,
	// int bottom );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "9bec59dd-6bcb-498e-9ed2-ac641ecd7fa5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool Ellipse(HDC hdc, int left, int top, int right, int bottom);

	/// <summary>
	/// The <c>GetArcDirection</c> function retrieves the current arc direction for the specified device context. Arc and rectangle
	/// functions use the arc direction.
	/// </summary>
	/// <param name="hdc">Handle to the device context.</param>
	/// <returns>
	/// <para>The return value specifies the current arc direction; it can be any one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AD_COUNTERCLOCKWISE</term>
	/// <term>Arcs and rectangles are drawn counterclockwise.</term>
	/// </item>
	/// <item>
	/// <term>AD_CLOCKWISE</term>
	/// <term>Arcs and rectangles are drawn clockwise.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getarcdirection int GetArcDirection( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "6bf426cd-e028-4568-9e9a-aca58dd69732")]
	public static extern ArcDirection GetArcDirection(HDC hdc);

	/// <summary>
	/// The <c>LineDDA</c> function determines which pixels should be highlighted for a line defined by the specified starting and ending points.
	/// </summary>
	/// <param name="xStart">Specifies the x-coordinate, in logical units, of the line's starting point.</param>
	/// <param name="yStart">Specifies the y-coordinate, in logical units, of the line's starting point.</param>
	/// <param name="xEnd">Specifies the x-coordinate, in logical units, of the line's ending point.</param>
	/// <param name="yEnd">Specifies the y-coordinate, in logical units, of the line's ending point.</param>
	/// <param name="lpProc">
	/// Pointer to an application-defined callback function. For more information, see the LineDDAProc callback function.
	/// </param>
	/// <param name="data">Pointer to the application-defined data.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>LineDDA</c> function passes the coordinates for each point along the line, except for the line's ending point, to the
	/// application-defined callback function. In addition to passing the coordinates of a point, this function passes any existing
	/// application-defined data.
	/// </para>
	/// <para>
	/// The coordinates passed to the callback function match pixels on a video display only if the default transformations and mapping
	/// modes are used.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-linedda BOOL LineDDA( int xStart, int yStart, int xEnd, int
	// yEnd, LINEDDAPROC lpProc, LPARAM data );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "1400d947-324a-4921-9f65-f5d3a11005da")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LineDDA(int xStart, int yStart, int xEnd, int yEnd, LineDDAProc lpProc, [Optional] IntPtr data);

	/// <summary>The <c>LineTo</c> function draws a line from the current position up to, but not including, the specified point.</summary>
	/// <param name="hdc">Handle to a device context.</param>
	/// <param name="x">Specifies the x-coordinate, in logical units, of the line's ending point.</param>
	/// <param name="y">Specifies the y-coordinate, in logical units, of the line's ending point.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The line is drawn by using the current pen and, if the pen is a geometric pen, the current brush.</para>
	/// <para>If <c>LineTo</c> succeeds, the current position is set to the specified ending point.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Drawing Markers.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-lineto BOOL LineTo( HDC hdc, int x, int y );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "a31b3a9a-110f-4cdf-89d9-19937a2e40b4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LineTo(HDC hdc, int x, int y);

	/// <summary>
	/// The <c>MoveToEx</c> function updates the current position to the specified point and optionally returns the previous position.
	/// </summary>
	/// <param name="hdc">Handle to a device context.</param>
	/// <param name="x">Specifies the x-coordinate, in logical units, of the new position, in logical units.</param>
	/// <param name="y">Specifies the y-coordinate, in logical units, of the new position, in logical units.</param>
	/// <param name="lppt">
	/// Pointer to a POINT structure that receives the previous current position. If this parameter is a <c>NULL</c> pointer, the
	/// previous position is not returned.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>MoveToEx</c> function affects all drawing functions.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Drawing Markers.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-movetoex BOOL MoveToEx( HDC hdc, int x, int y, LPPOINT lppt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "af11eeb7-4036-4a90-8685-9b5719f79e01")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool MoveToEx(HDC hdc, int x, int y, out POINT lppt);

	/// <summary>
	/// The <c>Pie</c> function draws a pie-shaped wedge bounded by the intersection of an ellipse and two radials. The pie is outlined
	/// by using the current pen and filled by using the current brush.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="left">The x-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.</param>
	/// <param name="top">The y-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.</param>
	/// <param name="right">The x-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.</param>
	/// <param name="bottom">The y-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.</param>
	/// <param name="xr1">The x-coordinate, in logical coordinates, of the endpoint of the first radial.</param>
	/// <param name="yr1">The y-coordinate, in logical coordinates, of the endpoint of the first radial.</param>
	/// <param name="xr2">The x-coordinate, in logical coordinates, of the endpoint of the second radial.</param>
	/// <param name="yr2">The y-coordinate, in logical coordinates, of the endpoint of the second radial.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The curve of the pie is defined by an ellipse that fits the specified bounding rectangle. The curve begins at the point where the
	/// ellipse intersects the first radial and extends counterclockwise to the point where the ellipse intersects the second radial.
	/// </para>
	/// <para>The current position is neither used nor updated by the <c>Pie</c> function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-pie BOOL Pie( HDC hdc, int left, int top, int right, int
	// bottom, int xr1, int yr1, int xr2, int yr2 );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "86daa936-b483-4432-aa32-0b9328ff76f9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool Pie(HDC hdc, int left, int top, int right, int bottom, int xr1, int yr1, int xr2, int yr2);

	/// <summary>The <c>PolyBezier</c> function draws one or more Bézier curves.</summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="apt">
	/// A pointer to an array of POINT structures that contain the endpoints and control points of the curve(s), in logical units.
	/// </param>
	/// <param name="cpt">
	/// The number of points in the lppt array. This value must be one more than three times the number of curves to be drawn, because
	/// each Bézier curve requires two control points and an endpoint, and the initial curve requires an additional starting point.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>PolyBezier</c> function draws cubic Bézier curves by using the endpoints and control points specified by the lppt
	/// parameter. The first curve is drawn from the first point to the fourth point by using the second and third points as control
	/// points. Each subsequent curve in the sequence needs exactly three more points: the ending point of the previous curve is used as
	/// the starting point, the next two points in the sequence are control points, and the third is the ending point.
	/// </para>
	/// <para>The current position is neither used nor updated by the <c>PolyBezier</c> function. The figure is not filled.</para>
	/// <para>This function draws lines by using the current pen.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Redrawing in the Update Region.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-polybezier BOOL PolyBezier( HDC hdc, const POINT *apt, DWORD
	// cpt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d1622574-c65e-4265-9a17-22bb4d2cae0e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PolyBezier(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] POINT[] apt, uint cpt);

	/// <summary>The <c>PolyBezierTo</c> function draws one or more Bézier curves.</summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="apt">A pointer to an array of POINT structures that contains the endpoints and control points, in logical units.</param>
	/// <param name="cpt">
	/// The number of points in the lppt array. This value must be three times the number of curves to be drawn because each Bézier curve
	/// requires two control points and an ending point.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function draws cubic Bézier curves by using the control points specified by the lppt parameter. The first curve is drawn
	/// from the current position to the third point by using the first two points as control points. For each subsequent curve, the
	/// function needs exactly three more points, and uses the ending point of the previous curve as the starting point for the next.
	/// </para>
	/// <para><c>PolyBezierTo</c> moves the current position to the ending point of the last Bézier curve. The figure is not filled.</para>
	/// <para>This function draws lines by using the current pen.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-polybezierto BOOL PolyBezierTo( HDC hdc, const POINT *apt,
	// DWORD cpt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "0c8d6d6d-d0a3-4188-91ad-934e6f054862")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PolyBezierTo(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] POINT[] apt, uint cpt);

	/// <summary>The <c>PolyDraw</c> function draws a set of line segments and Bézier curves.</summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="apt">
	/// A pointer to an array of POINT structures that contains the endpoints for each line segment and the endpoints and control points
	/// for each Bézier curve, in logical units.
	/// </param>
	/// <param name="aj">
	/// <para>
	/// A pointer to an array that specifies how each point in the lppt array is used. This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PT_MOVETO</term>
	/// <term>Specifies that this point starts a disjoint figure. This point becomes the new current position.</term>
	/// </item>
	/// <item>
	/// <term>PT_LINETO</term>
	/// <term>Specifies that a line is to be drawn from the current position to this point, which then becomes the new current position.</term>
	/// </item>
	/// <item>
	/// <term>PT_BEZIERTO</term>
	/// <term>
	/// Specifies that this point is a control point or ending point for a Bézier curve. PT_BEZIERTO types always occur in sets of three.
	/// The current position defines the starting point for the Bézier curve. The first two PT_BEZIERTO points are the control points,
	/// and the third PT_BEZIERTO point is the ending point. The ending point becomes the new current position. If there are not three
	/// consecutive PT_BEZIERTO points, an error results.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// A PT_LINETO or PT_BEZIERTO type can be combined with the following value by using the bitwise operator OR to indicate that the
	/// corresponding point is the last point in a figure and the figure is closed.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PT_CLOSEFIGURE</term>
	/// <term>
	/// Specifies that the figure is automatically closed after the PT_LINETO or PT_BEZIERTO type for this point is done. A line is drawn
	/// from this point to the most recent PT_MOVETO or MoveToEx point. This value is combined with the PT_LINETO type for a line, or
	/// with the PT_BEZIERTO type of the ending point for a Bézier curve, by using the bitwise operator OR. The current position is set
	/// to the ending point of the closing line.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="cpt">The total number of points in the lppt array, the same as the number of bytes in the lpbTypes array.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>PolyDraw</c> function can be used in place of consecutive calls to MoveToEx, LineTo, and PolyBezierTo functions to draw
	/// disjoint figures. The lines and curves are drawn using the current pen and figures are not filled. If there is an active path
	/// started by calling BeginPath, <c>PolyDraw</c> adds to the path.
	/// </para>
	/// <para>
	/// The points contained in the lppt array and in the lpbTypes array indicate whether each point is part of a MoveTo, LineTo, or
	/// PolyBezierTo operation. It is also possible to close figures.
	/// </para>
	/// <para>This function updates the current position.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-polydraw BOOL PolyDraw( HDC hdc, const POINT *apt, const BYTE
	// *aj, int cpt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "5fd3f285-dcf3-4cd0-915a-236ba7902353")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PolyDraw(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] POINT[] apt,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] VertexType[] aj, int cpt);

	/// <summary>
	/// The <c>Polygon</c> function draws a polygon consisting of two or more vertices connected by straight lines. The polygon is
	/// outlined by using the current pen and filled by using the current brush and polygon fill mode.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="apt">A pointer to an array of POINT structures that specify the vertices of the polygon, in logical coordinates.</param>
	/// <param name="cpt">The number of vertices in the array. This value must be greater than or equal to 2.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The polygon is closed automatically by drawing a line from the last vertex to the first.</para>
	/// <para>The current position is neither used nor updated by the <c>Polygon</c> function.</para>
	/// <para>
	/// Any extra points are ignored. To draw a line with more points, divide your data into groups, each of which have less than the
	/// maximum number of points, and call the function for each group of points. Remember to connect the line segments.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-polygon BOOL Polygon( HDC hdc, const POINT *apt, int cpt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "2f958b91-039a-4e02-b727-be142bb18b06")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool Polygon(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] POINT[] apt, int cpt);

	/// <summary>The <c>Polyline</c> function draws a series of line segments by connecting the points in the specified array.</summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="apt">A pointer to an array of POINT structures, in logical units.</param>
	/// <param name="cpt">The number of points in the array. This number must be greater than or equal to two.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The lines are drawn from the first point through subsequent points by using the current pen. Unlike the LineTo or PolylineTo
	/// functions, the <c>Polyline</c> function neither uses nor updates the current position.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-polyline BOOL Polyline( HDC hdc, const POINT *apt, int cpt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "55481dd0-3db7-4131-b383-4d0036943e60")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool Polyline(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] POINT[] apt, int cpt);

	/// <summary>The <c>PolylineTo</c> function draws one or more straight lines.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="apt">A pointer to an array of POINT structures that contains the vertices of the line, in logical units.</param>
	/// <param name="cpt">The number of points in the array.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>Unlike the Polyline function, the <c>PolylineTo</c> function uses and updates the current position.</para>
	/// <para>
	/// A line is drawn from the current position to the first point specified by the lppt parameter by using the current pen. For each
	/// additional line, the function draws from the ending point of the previous line to the next point specified by lppt.
	/// </para>
	/// <para><c>PolylineTo</c> moves the current position to the ending point of the last line.</para>
	/// <para>If the line segments drawn by this function form a closed figure, the figure is not filled.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-polylineto BOOL PolylineTo( HDC hdc, const POINT *apt, DWORD
	// cpt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "76020742-b651-4244-82c3-13034573c306")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PolylineTo(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] POINT[] apt, uint cpt);

	/// <summary>
	/// The <c>PolyPolygon</c> function draws a series of closed polygons. Each polygon is outlined by using the current pen and filled
	/// by using the current brush and polygon fill mode. The polygons drawn by this function can overlap.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="apt">
	/// A pointer to an array of POINT structures that define the vertices of the polygons, in logical coordinates. The polygons are
	/// specified consecutively. Each polygon is closed automatically by drawing a line from the last vertex to the first. Each vertex
	/// should be specified once.
	/// </param>
	/// <param name="asz">
	/// A pointer to an array of integers, each of which specifies the number of points in the corresponding polygon. Each integer must
	/// be greater than or equal to 2.
	/// </param>
	/// <param name="csz">The total number of polygons.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The current position is neither used nor updated by this function.</para>
	/// <para>
	/// Any extra points are ignored. To draw the polygons with more points, divide your data into groups, each of which have less than
	/// the maximum number of points, and call the function for each group of points. Note, it is best to have a polygon in only one of
	/// the groups.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-polypolygon BOOL PolyPolygon( HDC hdc, const POINT *apt, const
	// INT *asz, int csz );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "ac0a2802-c8b0-4cd7-9521-5b179f2c70b9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PolyPolygon(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] POINT[] apt,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] asz, int csz);

	/// <summary>The <c>PolyPolyline</c> function draws multiple series of connected line segments.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="apt">
	/// A pointer to an array of POINT structures that contains the vertices of the polylines, in logical units. The polylines are
	/// specified consecutively.
	/// </param>
	/// <param name="asz">
	/// A pointer to an array of variables specifying the number of points in the lppt array for the corresponding polyline. Each entry
	/// must be greater than or equal to two.
	/// </param>
	/// <param name="csz">The total number of entries in the lpdwPolyPoints array.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The line segments are drawn by using the current pen. The figures formed by the segments are not filled.</para>
	/// <para>The current position is neither used nor updated by this function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-polypolyline BOOL PolyPolyline( HDC hdc, const POINT *apt,
	// const DWORD *asz, DWORD csz );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "71a9273f-321b-4efb-ac73-5979f8151d05")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PolyPolyline(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] POINT[] apt,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] uint[] asz, uint csz);

	/// <summary>
	/// The <c>Rectangle</c> function draws a rectangle. The rectangle is outlined by using the current pen and filled by using the
	/// current brush.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="left">The x-coordinate, in logical coordinates, of the upper-left corner of the rectangle.</param>
	/// <param name="top">The y-coordinate, in logical coordinates, of the upper-left corner of the rectangle.</param>
	/// <param name="right">The x-coordinate, in logical coordinates, of the lower-right corner of the rectangle.</param>
	/// <param name="bottom">The y-coordinate, in logical coordinates, of the lower-right corner of the rectangle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The current position is neither used nor updated by <c>Rectangle</c>.</para>
	/// <para>The rectangle that is drawn excludes the bottom and right edges.</para>
	/// <para>If a PS_NULL pen is used, the dimensions of the rectangle are 1 pixel less in height and 1 pixel less in width.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Using Filled Shapes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-rectangle BOOL Rectangle( HDC hdc, int left, int top, int
	// right, int bottom );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "ed6b9824-1edc-4510-b9da-a4287845aa83")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool Rectangle(HDC hdc, int left, int top, int right, int bottom);

	/// <summary>
	/// The <c>RoundRect</c> function draws a rectangle with rounded corners. The rectangle is outlined by using the current pen and
	/// filled by using the current brush.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="left">The x-coordinate, in logical coordinates, of the upper-left corner of the rectangle.</param>
	/// <param name="top">The y-coordinate, in logical coordinates, of the upper-left corner of the rectangle.</param>
	/// <param name="right">The x-coordinate, in logical coordinates, of the lower-right corner of the rectangle.</param>
	/// <param name="bottom">The y-coordinate, in logical coordinates, of the lower-right corner of the rectangle.</param>
	/// <param name="width">The width, in logical coordinates, of the ellipse used to draw the rounded corners.</param>
	/// <param name="height">The height, in logical coordinates, of the ellipse used to draw the rounded corners.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The current position is neither used nor updated by this function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Using Filled Shapes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-roundrect BOOL RoundRect( HDC hdc, int left, int top, int
	// right, int bottom, int width, int height );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "17808a6a-7bd0-4fd6-81ab-00d5db764b93")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RoundRect(HDC hdc, int left, int top, int right, int bottom, int width, int height);

	/// <summary>The <c>SetArcDirection</c> sets the drawing direction to be used for arc and rectangle functions.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="dir">
	/// <para>The new arc direction. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AD_COUNTERCLOCKWISE</term>
	/// <term>Figures drawn counterclockwise.</term>
	/// </item>
	/// <item>
	/// <term>AD_CLOCKWISE</term>
	/// <term>Figures drawn clockwise.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the old arc direction.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The default direction is counterclockwise.</para>
	/// <para>The <c>SetArcDirection</c> function specifies the direction in which the following functions draw:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Arc</term>
	/// </item>
	/// <item>
	/// <term>ArcTo</term>
	/// </item>
	/// <item>
	/// <term>Chord</term>
	/// </item>
	/// <item>
	/// <term>Ellipse</term>
	/// </item>
	/// <item>
	/// <term>Pie</term>
	/// </item>
	/// <item>
	/// <term>Rectangle</term>
	/// </item>
	/// <item>
	/// <term>RoundRect</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setarcdirection int SetArcDirection( HDC hdc, int dir );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "cec31eb2-cc9d-4384-b973-dd4339b96ed0")]
	public static extern ArcDirection SetArcDirection(HDC hdc, ArcDirection dir);
}