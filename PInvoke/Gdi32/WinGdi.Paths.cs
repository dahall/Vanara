using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>Vertex types.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "2dc7736a-03fc-4623-a566-6c3e368da174")]
	[Flags]
	public enum VertexType : byte
	{
		/// <summary>
		/// Specifies that the figure is automatically closed after the corresponding line or curve is drawn. The figure is closed by
		/// drawing a line from the line or curve endpoint to the point corresponding to the last PT_MOVETO.
		/// </summary>
		PT_CLOSEFIGURE = 0x01,

		/// <summary>Specifies that the previous point and the corresponding point in lpPoints are the endpoints of a line.</summary>
		PT_LINETO = 0x02,

		/// <summary>
		/// Specifies that the corresponding point in lpPoints is a control point or ending point for a Bézier curve. PT_BEZIERTO values
		/// always occur in sets of three. The point in the path immediately preceding them defines the starting point for the Bézier
		/// curve. The first two PT_BEZIERTO points are the control points, and the third PT_BEZIERTO point is the ending (if hard-coded) point.
		/// </summary>
		PT_BEZIERTO = 0x04,

		/// <summary>Specifies that the corresponding point in the lpPoints parameter starts a disjoint figure.</summary>
		PT_MOVETO = 0x06,
	}

	/// <summary>The <c>AbortPath</c> function closes and discards any paths in the specified device context.</summary>
	/// <param name="hdc">Handle to the device context from which a path will be discarded.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// If there is an open path bracket in the given device context, the path bracket is closed and the path is discarded. If there is a
	/// closed path in the device context, the path is discarded.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-abortpath BOOL AbortPath( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "49299a11-910b-40e0-b02e-80a244cfc978")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AbortPath(HDC hdc);

	/// <summary>The <c>BeginPath</c> function opens a path bracket in the specified device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After a path bracket is open, an application can begin calling GDI drawing functions to define the points that lie in the path.
	/// An application can close an open path bracket by calling the EndPath function.
	/// </para>
	/// <para>
	/// When an application calls <c>BeginPath</c> for a device context, any previous paths are discarded from that device context. The
	/// following list shows which drawing functions can be used.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>AngleArc</term>
	/// </item>
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
	/// <term>CloseFigure</term>
	/// </item>
	/// <item>
	/// <term>Ellipse</term>
	/// </item>
	/// <item>
	/// <term>ExtTextOut</term>
	/// </item>
	/// <item>
	/// <term>LineTo</term>
	/// </item>
	/// <item>
	/// <term>MoveToEx</term>
	/// </item>
	/// <item>
	/// <term>Pie</term>
	/// </item>
	/// <item>
	/// <term>PolyBezier</term>
	/// </item>
	/// <item>
	/// <term>PolyBezierTo</term>
	/// </item>
	/// <item>
	/// <term>PolyDraw</term>
	/// </item>
	/// <item>
	/// <term>Polygon</term>
	/// </item>
	/// <item>
	/// <term>Polyline</term>
	/// </item>
	/// <item>
	/// <term>PolylineTo</term>
	/// </item>
	/// <item>
	/// <term>PolyPolygon</term>
	/// </item>
	/// <item>
	/// <term>PolyPolyline</term>
	/// </item>
	/// <item>
	/// <term>Rectangle</term>
	/// </item>
	/// <item>
	/// <term>RoundRect</term>
	/// </item>
	/// <item>
	/// <term>TextOut</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Using Paths.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-beginpath BOOL BeginPath( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "88be3405-a420-4eb1-935b-099dc3067530")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BeginPath(HDC hdc);

	/// <summary>The <c>CloseFigure</c> function closes an open figure in a path.</summary>
	/// <param name="hdc">Handle to the device context in which the figure will be closed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CloseFigure</c> function closes the figure by drawing a line from the current position to the first point of the figure
	/// (usually, the point specified by the most recent call to the MoveToEx function) and then connects the lines by using the line
	/// join style. If a figure is closed by using the LineTo function instead of <c>CloseFigure</c>, end caps are used to create the
	/// corner instead of a join.
	/// </para>
	/// <para>The <c>CloseFigure</c> function should only be called if there is an open path bracket in the specified device context.</para>
	/// <para>
	/// A figure in a path is open unless it is explicitly closed by using this function. (A figure can be open even if the current point
	/// and the starting point of the figure are the same.)
	/// </para>
	/// <para>After a call to <c>CloseFigure</c>, adding a line or curve to the path starts a new figure.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-closefigure BOOL CloseFigure( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "2532227c-35c9-4a46-b4eb-4a156ef28219")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseFigure(HDC hdc);

	/// <summary>
	/// The <c>EndPath</c> function closes a path bracket and selects the path defined by the bracket into the specified device context.
	/// </summary>
	/// <param name="hdc">A handle to the device context into which the new path is selected.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-endpath BOOL EndPath( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "0b4daf81-d1d6-45c1-b081-855b7cd8527a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EndPath(HDC hdc);

	/// <summary>
	/// The <c>FillPath</c> function closes any open figures in the current path and fills the path's interior by using the current brush
	/// and polygon-filling mode.
	/// </summary>
	/// <param name="hdc">A handle to a device context that contains a valid path.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>After its interior is filled, the path is discarded from the DC identified by the hdc parameter.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-fillpath BOOL FillPath( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "a80b299a-c3f9-411b-9936-33d32fc71853")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FillPath(HDC hdc);

	/// <summary>
	/// The <c>FlattenPath</c> function transforms any curves in the path that is selected into the current device context (DC), turning
	/// each curve into a sequence of lines.
	/// </summary>
	/// <param name="hdc">A handle to a DC that contains a valid path.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-flattenpath BOOL FlattenPath( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "267b0c9a-25d4-4b04-95d3-6b0856bed022")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlattenPath(HDC hdc);

	/// <summary>The <c>GetMiterLimit</c> function retrieves the miter limit for the specified device context.</summary>
	/// <param name="hdc">Handle to the device context.</param>
	/// <param name="plimit">Pointer to a floating-point value that receives the current miter limit.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>The miter limit is used when drawing geometric lines that have miter joins.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getmiterlimit BOOL GetMiterLimit( HDC hdc, PFLOAT plimit );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "51b1fb95-dd44-47f8-9311-2c6dc9c57bbc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetMiterLimit(HDC hdc, out float plimit);

	/// <summary>
	/// The <c>GetPath</c> function retrieves the coordinates defining the endpoints of lines and the control points of curves found in
	/// the path that is selected into the specified device context.
	/// </summary>
	/// <param name="hdc">A handle to a device context that contains a closed path.</param>
	/// <param name="apt">
	/// A pointer to an array of POINT structures that receives the line endpoints and curve control points, in logical coordinates.
	/// </param>
	/// <param name="aj">
	/// <para>A pointer to an array of bytes that receives the vertex types. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PT_MOVETO</term>
	/// <term>Specifies that the corresponding point in the lpPoints parameter starts a disjoint figure.</term>
	/// </item>
	/// <item>
	/// <term>PT_LINETO</term>
	/// <term>Specifies that the previous point and the corresponding point in lpPoints are the endpoints of a line.</term>
	/// </item>
	/// <item>
	/// <term>PT_BEZIERTO</term>
	/// <term>
	/// Specifies that the corresponding point in lpPoints is a control point or ending point for a Bézier curve. PT_BEZIERTO values
	/// always occur in sets of three. The point in the path immediately preceding them defines the starting point for the Bézier curve.
	/// The first two PT_BEZIERTO points are the control points, and the third PT_BEZIERTO point is the ending (if hard-coded) point.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// A PT_LINETO or PT_BEZIERTO value may be combined with the following value (by using the bitwise operator OR) to indicate that the
	/// corresponding point is the last point in a figure and the figure should be closed.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PT_CLOSEFIGURE</term>
	/// <term>
	/// Specifies that the figure is automatically closed after the corresponding line or curve is drawn. The figure is closed by drawing
	/// a line from the line or curve endpoint to the point corresponding to the last PT_MOVETO.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="cpt">
	/// The total number of POINT structures that can be stored in the array pointed to by lpPoints. This value must be the same as the
	/// number of bytes that can be placed in the array pointed to by lpTypes.
	/// </param>
	/// <returns>
	/// If the nSize parameter is nonzero, the return value is the number of points enumerated. If nSize is 0, the return value is the
	/// total number of points in the path (and <c>GetPath</c> writes nothing to the buffers). If nSize is nonzero and is less than the
	/// number of points in the path, the return value is 1.
	/// </returns>
	/// <remarks>
	/// <para>The device context identified by the hdc parameter must contain a closed path.</para>
	/// <para>
	/// The points of the path are returned in logical coordinates. Points are stored in the path in device coordinates, so
	/// <c>GetPath</c> changes the points from device coordinates to logical coordinates by using the inverse of the current transformation.
	/// </para>
	/// <para>The FlattenPath function may be called before <c>GetPath</c> to convert all curves in the path into line segments.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getpath int GetPath( HDC hdc, LPPOINT apt, LPBYTE aj, int cpt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "2dc7736a-03fc-4623-a566-6c3e368da174")]
	public static extern int GetPath(HDC hdc, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] POINT[] apt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] VertexType[] aj, int cpt);

	/// <summary>
	/// The <c>PathToRegion</c> function creates a region from the path that is selected into the specified device context. The resulting
	/// region uses device coordinates.
	/// </summary>
	/// <param name="hdc">Handle to a device context that contains a closed path.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value identifies a valid region.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>When you no longer need the <c>HRGN</c> object call the DeleteObject function to delete it.</para>
	/// <para>The device context identified by the hdc parameter must contain a closed path.</para>
	/// <para>
	/// After <c>PathToRegion</c> converts a path into a region, the system discards the closed path from the specified device context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-pathtoregion HRGN PathToRegion( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "9fe31925-3d5d-42e5-aa9b-405610f13de4")]
	public static extern SafeHRGN PathToRegion(HDC hdc);

	/// <summary>The <c>SetMiterLimit</c> function sets the limit for the length of miter joins for the specified device context.</summary>
	/// <param name="hdc">Handle to the device context.</param>
	/// <param name="limit">Specifies the new miter limit for the device context.</param>
	/// <param name="old">
	/// Pointer to a floating-point value that receives the previous miter limit. If this parameter is <c>NULL</c>, the previous miter
	/// limit is not returned.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The miter length is defined as the distance from the intersection of the line walls on the inside of the join to the intersection
	/// of the line walls on the outside of the join. The miter limit is the maximum allowed ratio of the miter length to the line width.
	/// </para>
	/// <para>The default miter limit is 10.0.</para>
	/// <para><c>Note</c> Setting eNewLimit to a float value less than 1.0f will cause the function to fail.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setmiterlimit BOOL SetMiterLimit( HDC hdc, FLOAT limit, PFLOAT
	// old );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "4bed113b-9e3f-441f-96d7-71630bf9298e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetMiterLimit(HDC hdc, float limit, out float old);

	/// <summary>
	/// The <c>StrokeAndFillPath</c> function closes any open figures in a path, strokes the outline of the path by using the current
	/// pen, and fills its interior by using the current brush.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The device context identified by the hdc parameter must contain a closed path.</para>
	/// <para>
	/// The <c>StrokeAndFillPath</c> function has the same effect as closing all the open figures in the path, and stroking and filling
	/// the path separately, except that the filled region will not overlap the stroked region even if the pen is wide.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Drawing a Pie Chart.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-strokeandfillpath BOOL StrokeAndFillPath( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "936af9e5-707d-4d43-9035-e8239e3759a2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool StrokeAndFillPath(HDC hdc);

	/// <summary>The <c>StrokePath</c> function renders the specified path by using the current pen.</summary>
	/// <param name="hdc">Handle to a device context that contains the completed path.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The path, if it is to be drawn by <c>StrokePath</c>, must have been completed through a call to EndPath. Calling this function on
	/// a path for which <c>EndPath</c> has not been called will cause this function to fail and return zero. Unlike other path drawing
	/// functions such as StrokeAndFillPath, <c>StrokePath</c> will not attempt to close the path by drawing a straight line from the
	/// first point on the path to the last point on the path.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-strokepath BOOL StrokePath( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "5a9f1509-0a69-4db8-8d74-9bf360aca64d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool StrokePath(HDC hdc);

	/// <summary>
	/// The <c>WidenPath</c> function redefines the current path as the area that would be painted if the path were stroked using the pen
	/// currently selected into the given device context.
	/// </summary>
	/// <param name="hdc">A handle to a device context that contains a closed path.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WidenPath</c> function is successful only if the current pen is a geometric pen created by the ExtCreatePen function, or
	/// if the pen is created with the CreatePen function and has a width, in device units, of more than one.
	/// </para>
	/// <para>The device context identified by the hdc parameter must contain a closed path.</para>
	/// <para>
	/// Any Bézier curves in the path are converted to sequences of straight lines approximating the widened curves. As such, no Bézier
	/// curves remain in the path after <c>WidenPath</c> is called.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-widenpath BOOL WidenPath( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "c994bd1b-c5e8-46e6-a6a6-59e2d9106d75")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WidenPath(HDC hdc);
}