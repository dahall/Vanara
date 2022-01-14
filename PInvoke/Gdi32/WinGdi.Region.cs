using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>The type of region.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "15990903-8a48-4c47-b527-269d775255a5")]
		public enum RDH
		{
			/// <summary>Rectangle region type.</summary>
			RDH_RECTANGLES = 1
		}

		/// <summary>A mode indicating how the two regions will be combined.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "ef9fc4f3-737e-4c10-a80b-8ae2097c17d1")]
		public enum RGN_COMB
		{
			/// <summary>Creates the intersection of the two combined regions.</summary>
			RGN_AND = 1,

			/// <summary>Creates the union of two combined regions.</summary>
			RGN_OR = 2,

			/// <summary>Creates the union of two combined regions except for any overlapping areas.</summary>
			RGN_XOR = 3,

			/// <summary>Combines the parts of hrgnSrc1 that are not part of hrgnSrc2.</summary>
			RGN_DIFF = 4,

			/// <summary>Creates a copy of the region identified by hrgnSrc1.</summary>
			RGN_COPY = 5,
		}

		/// <summary>The fill mode used to determine which pixels are in the region.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "ef9fc4f3-737e-4c10-a80b-8ae2097c17d1")]
		public enum RGN_FILLMODE
		{
			/// <summary>Selects alternate mode (fills area between odd-numbered and even-numbered polygon sides on each scan line).</summary>
			ALTERNATE,

			/// <summary>Selects winding mode (fills any region with a nonzero winding value).</summary>
			WINDING
		}

		/// <summary>The type of the resulting region.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "ef9fc4f3-737e-4c10-a80b-8ae2097c17d1")]
		public enum RGN_TYPE
		{
			/// <summary>No region is created.</summary>
			ERROR = 0,

			/// <summary>The region is empty.</summary>
			NULLREGION = 1,

			/// <summary>The region is a single rectangle.</summary>
			SIMPLEREGION = 2,

			/// <summary>The region is more than a single rectangle.</summary>
			COMPLEXREGION = 3,
		}

		/// <summary>
		/// The <c>CombineRgn</c> function combines two regions and stores the result in a third region. The two regions are combined
		/// according to the specified mode.
		/// </summary>
		/// <param name="hrgnDst">
		/// A handle to a new region with dimensions defined by combining two other regions. (This region must exist before <c>CombineRgn</c>
		/// is called.)
		/// </param>
		/// <param name="hrgnSrc1">A handle to the first of two regions to be combined.</param>
		/// <param name="hrgnSrc2">A handle to the second of two regions to be combined.</param>
		/// <param name="iMode">
		/// <para>A mode indicating how the two regions will be combined. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RGN_AND</term>
		/// <term>Creates the intersection of the two combined regions.</term>
		/// </item>
		/// <item>
		/// <term>RGN_COPY</term>
		/// <term>Creates a copy of the region identified by hrgnSrc1.</term>
		/// </item>
		/// <item>
		/// <term>RGN_DIFF</term>
		/// <term>Combines the parts of hrgnSrc1 that are not part of hrgnSrc2.</term>
		/// </item>
		/// <item>
		/// <term>RGN_OR</term>
		/// <term>Creates the union of two combined regions.</term>
		/// </item>
		/// <item>
		/// <term>RGN_XOR</term>
		/// <term>Creates the union of two combined regions except for any overlapping areas.</term>
		/// </item>
		/// </list>
		/// </param>
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-combinergn int CombineRgn( HRGN hrgnDst, HRGN hrgnSrc1, HRGN
		// hrgnSrc2, int iMode );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "ef9fc4f3-737e-4c10-a80b-8ae2097c17d1")]
		public static extern RGN_TYPE CombineRgn(HRGN hrgnDst, HRGN hrgnSrc1, HRGN hrgnSrc2, RGN_COMB iMode);

		/// <summary>The <c>CreateEllipticRgn</c> function creates an elliptical region.</summary>
		/// <param name="x1">Specifies the x-coordinate in logical units, of the upper-left corner of the bounding rectangle of the ellipse.</param>
		/// <param name="y1">Specifies the y-coordinate in logical units, of the upper-left corner of the bounding rectangle of the ellipse.</param>
		/// <param name="x2">Specifies the x-coordinate in logical units, of the lower-right corner of the bounding rectangle of the ellipse.</param>
		/// <param name="y2">Specifies the y-coordinate in logical units, of the lower-right corner of the bounding rectangle of the ellipse.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to the region.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>When you no longer need the HRGN object, call the DeleteObject function to delete it.</para>
		/// <para>
		/// A bounding rectangle defines the size, shape, and orientation of the region: The long sides of the rectangle define the length of
		/// the ellipse's major axis; the short sides define the length of the ellipse's minor axis; and the center of the rectangle defines
		/// the intersection of the major and minor axes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createellipticrgn HRGN CreateEllipticRgn( int x1, int y1,
		// int x2, int y2 );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "b4e9b210-8e22-42db-bb6e-65f1fb870eff")]
		public static extern SafeHRGN CreateEllipticRgn(int x1, int y1, int x2, int y2);

		/// <summary>The <c>CreateEllipticRgnIndirect</c> function creates an elliptical region.</summary>
		/// <param name="lprect">
		/// Pointer to a RECT structure that contains the coordinates of the upper-left and lower-right corners of the bounding rectangle of
		/// the ellipse in logical units.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to the region.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>When you no longer need the <c>HRGN</c> object, call the DeleteObject function to delete it.</para>
		/// <para>
		/// A bounding rectangle defines the size, shape, and orientation of the region: The long sides of the rectangle define the length of
		/// the ellipse's major axis; the short sides define the length of the ellipse's minor axis; and the center of the rectangle defines
		/// the intersection of the major and minor axes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createellipticrgnindirect HRGN CreateEllipticRgnIndirect(
		// const RECT *lprect );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "bd30516e-1e05-4b7d-a6bf-7512cf3ef30f")]
		public static extern SafeHRGN CreateEllipticRgnIndirect(in RECT lprect);

		/// <summary>The <c>CreatePolygonRgn</c> function creates a polygonal region.</summary>
		/// <param name="pptl">
		/// A pointer to an array of POINT structures that define the vertices of the polygon in logical units. The polygon is presumed
		/// closed. Each vertex can be specified only once.
		/// </param>
		/// <param name="cPoint">The number of points in the array.</param>
		/// <param name="iMode">
		/// <para>The fill mode used to determine which pixels are in the region. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ALTERNATE</term>
		/// <term>Selects alternate mode (fills area between odd-numbered and even-numbered polygon sides on each scan line).</term>
		/// </item>
		/// <item>
		/// <term>WINDING</term>
		/// <term>Selects winding mode (fills any region with a nonzero winding value).</term>
		/// </item>
		/// </list>
		/// <para>For more information about these modes, see the SetPolyFillMode function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to the region.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>When you no longer need the <c>HRGN</c> object, call the DeleteObject function to delete it.</para>
		/// <para>Region coordinates are represented as 27-bit signed integers.</para>
		/// <para>
		/// Regions created by the Create&lt;shape&gt;Rgn methods (such as CreateRectRgn and <c>CreatePolygonRgn</c>) only include the
		/// interior of the shape; the shape's outline is excluded from the region. This means that any point on a line between two
		/// sequential vertices is not included in the region. If you were to call PtInRegion for such a point, it would return zero as the result.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createpolygonrgn HRGN CreatePolygonRgn( const POINT *pptl,
		// int cPoint, int iMode );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "dd7ad6de-c5f2-46e4-8d28-24caaa48ba3a")]
		public static extern SafeHRGN CreatePolygonRgn(POINT pptl, int cPoint, RGN_FILLMODE iMode);

		/// <summary>The <c>CreatePolyPolygonRgn</c> function creates a region consisting of a series of polygons. The polygons can overlap.</summary>
		/// <param name="pptl">
		/// A pointer to an array of POINT structures that define the vertices of the polygons in logical units. The polygons are specified
		/// consecutively. Each polygon is presumed closed and each vertex is specified only once.
		/// </param>
		/// <param name="pc">
		/// A pointer to an array of integers, each of which specifies the number of points in one of the polygons in the array pointed to by lppt.
		/// </param>
		/// <param name="cPoly">The total number of integers in the array pointed to by lpPolyCounts.</param>
		/// <param name="iMode">
		/// <para>The fill mode used to determine which pixels are in the region. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ALTERNATE</term>
		/// <term>Selects alternate mode (fills area between odd-numbered and even-numbered polygon sides on each scan line).</term>
		/// </item>
		/// <item>
		/// <term>WINDING</term>
		/// <term>Selects winding mode (fills any region with a nonzero winding value).</term>
		/// </item>
		/// </list>
		/// <para>For more information about these modes, see the SetPolyFillMode function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to the region.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>When you no longer need the <c>HRGN</c> object, call the DeleteObject function to delete it.</para>
		/// <para>Region coordinates are represented as 27-bit signed integers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createpolypolygonrgn HRGN CreatePolyPolygonRgn( const POINT
		// *pptl, const INT *pc, int cPoly, int iMode );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "1113d3dc-8e3f-436c-a5a8-191785bc7fcc")]
		public static extern SafeHRGN CreatePolyPolygonRgn([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] POINT[] pptl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] pc, int cPoly, RGN_FILLMODE iMode);

		/// <summary>The <c>CreateRectRgn</c> function creates a rectangular region.</summary>
		/// <param name="x1">Specifies the x-coordinate of the upper-left corner of the region in logical units.</param>
		/// <param name="y1">Specifies the y-coordinate of the upper-left corner of the region in logical units.</param>
		/// <param name="x2">Specifies the x-coordinate of the lower-right corner of the region in logical units.</param>
		/// <param name="y2">Specifies the y-coordinate of the lower-right corner of the region in logical units.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to the region.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>When you no longer need the <c>HRGN</c> object, call the DeleteObject function to delete it.</para>
		/// <para>Region coordinates are represented as 27-bit signed integers.</para>
		/// <para>
		/// Regions created by the Create&lt;shape&gt;Rgn methods (such as <c>CreateRectRgn</c> and CreatePolygonRgn) only include the
		/// interior of the shape; the shape's outline is excluded from the region. This means that any point on a line between two
		/// sequential vertices is not included in the region. If you were to call PtInRegion for such a point, it would return zero as the result.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Drawing Markers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createrectrgn HRGN CreateRectRgn( int x1, int y1, int x2,
		// int y2 );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "17456440-c655-48ab-8d1e-ee770330f164")]
		public static extern SafeHRGN CreateRectRgn(int x1, int y1, int x2, int y2);

		/// <summary>The <c>CreateRectRgnIndirect</c> function creates a rectangular region.</summary>
		/// <param name="lprect">
		/// Pointer to a RECT structure that contains the coordinates of the upper-left and lower-right corners of the rectangle that defines
		/// the region in logical units.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to the region.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>When you no longer need the <c>HRGN</c> object, call the DeleteObject function to delete it.</para>
		/// <para>Region coordinates are represented as 27-bit signed integers.</para>
		/// <para>The region will be exclusive of the bottom and right edges.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createrectrgnindirect HRGN CreateRectRgnIndirect( const RECT
		// *lprect );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "f32e0b94-ce9c-4098-81fe-b239a9544621")]
		public static extern SafeHRGN CreateRectRgnIndirect(in RECT lprect);

		/// <summary>The <c>CreateRoundRectRgn</c> function creates a rectangular region with rounded corners.</summary>
		/// <param name="x1">Specifies the x-coordinate of the upper-left corner of the region in device units.</param>
		/// <param name="y1">Specifies the y-coordinate of the upper-left corner of the region in device units.</param>
		/// <param name="x2">Specifies the x-coordinate of the lower-right corner of the region in device units.</param>
		/// <param name="y2">Specifies the y-coordinate of the lower-right corner of the region in device units.</param>
		/// <param name="w">Specifies the width of the ellipse used to create the rounded corners in device units.</param>
		/// <param name="h">Specifies the height of the ellipse used to create the rounded corners in device units.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to the region.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>When you no longer need the <c>HRGN</c> object call the DeleteObject function to delete it.</para>
		/// <para>Region coordinates are represented as 27-bit signed integers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createroundrectrgn HRGN CreateRoundRectRgn( int x1, int y1,
		// int x2, int y2, int w, int h );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "16f387e1-b00c-4755-8b21-1ee0f25bc46b")]
		public static extern SafeHRGN CreateRoundRectRgn(int x1, int y1, int x2, int y2, int w, int h);

		/// <summary>
		/// The <c>EqualRgn</c> function checks the two specified regions to determine whether they are identical. The function considers two
		/// regions identical if they are equal in size and shape.
		/// </summary>
		/// <param name="hrgn1">Handle to a region.</param>
		/// <param name="hrgn2">Handle to a region.</param>
		/// <returns>
		/// <para>If the two regions are equal, the return value is nonzero.</para>
		/// <para>
		/// If the two regions are not equal, the return value is zero. A return value of ERROR means at least one of the region handles is invalid.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-equalrgn BOOL EqualRgn( HRGN hrgn1, HRGN hrgn2 );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "c7829998-78f4-4334-bf34-92aad12555f5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EqualRgn(HRGN hrgn1, HRGN hrgn2);

		/// <summary>The <c>ExtCreateRegion</c> function creates a region from the specified region and transformation data.</summary>
		/// <param name="lpx">
		/// A pointer to an XFORM structure that defines the transformation to be performed on the region. If this pointer is <c>NULL</c>,
		/// the identity transformation is used.
		/// </param>
		/// <param name="nCount">The number of bytes pointed to by lpRgnData.</param>
		/// <param name="lpData">A pointer to a RGNDATA structure that contains the region data in logical units.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the value of the region.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>Region coordinates are represented as 27-bit signed integers.</para>
		/// <para>An application can retrieve data for a region by calling the GetRegionData function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-extcreateregion HRGN ExtCreateRegion( const XFORM *lpx,
		// DWORD nCount, const RGNDATA *lpData );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "4dcff824-eb1d-425c-b246-db4ace2c6518")]
		public static extern SafeHRGN ExtCreateRegion(in XFORM lpx, uint nCount, [In] RGNDATA lpData);

		/// <summary>The <c>FillRgn</c> function fills a region by using the specified brush.</summary>
		/// <param name="hdc">Handle to the device context.</param>
		/// <param name="hrgn">Handle to the region to be filled. The region's coordinates are presumed to be in logical units.</param>
		/// <param name="hbr">Handle to the brush to be used to fill the region.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-fillrgn BOOL FillRgn( HDC hdc, HRGN hrgn, HBRUSH hbr );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "c4e0eca5-442b-462b-a4f2-0c628b6d3d38")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FillRgn(HDC hdc, HRGN hrgn, HBRUSH hbr);

		/// <summary>The <c>FrameRgn</c> function draws a border around the specified region by using the specified brush.</summary>
		/// <param name="hdc">Handle to the device context.</param>
		/// <param name="hrgn">
		/// Handle to the region to be enclosed in a border. The region's coordinates are presumed to be in logical units.
		/// </param>
		/// <param name="hbr">Handle to the brush to be used to draw the border.</param>
		/// <param name="w">Specifies the width, in logical units, of vertical brush strokes.</param>
		/// <param name="h">Specifies the height, in logical units, of horizontal brush strokes.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-framergn BOOL FrameRgn( HDC hdc, HRGN hrgn, HBRUSH hbr, int
		// w, int h );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "d2c95392-7950-4963-8f10-2387daf23e93")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FrameRgn(HDC hdc, HRGN hrgn, HBRUSH hbr, int w, int h);

		/// <summary>The <c>GetPolyFillMode</c> function retrieves the current polygon fill mode.</summary>
		/// <param name="hdc">Handle to the device context.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value specifies the polygon fill mode, which can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ALTERNATE</term>
		/// <term>Selects alternate mode (fills area between odd-numbered and even-numbered polygon sides on each scan line).</term>
		/// </item>
		/// <item>
		/// <term>WINDING</term>
		/// <term>Selects winding mode (fills any region with a nonzero winding value).</term>
		/// </item>
		/// </list>
		/// <para>If an error occurs, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getpolyfillmode int GetPolyFillMode( HDC hdc );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "febf96fb-bf2e-4eb2-ab5f-89741a1decad")]
		public static extern RGN_FILLMODE GetPolyFillMode(HDC hdc);

		/// <summary>
		/// The <c>GetRegionData</c> function fills the specified buffer with data describing a region. This data includes the dimensions of
		/// the rectangles that make up the region.
		/// </summary>
		/// <param name="hrgn">A handle to the region.</param>
		/// <param name="nCount">The size, in bytes, of the lpRgnData buffer.</param>
		/// <param name="lpRgnData">
		/// A pointer to a RGNDATA structure that receives the information. The dimensions of the region are in logical units. If this
		/// parameter is <c>NULL</c>, the return value contains the number of bytes needed for the region data.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds and dwCount specifies an adequate number of bytes, the return value is always dwCount. If dwCount is too
		/// small or the function fails, the return value is 0. If lpRgnData is <c>NULL</c>, the return value is the required number of bytes.
		/// </para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>The <c>GetRegionData</c> function is used in conjunction with the ExtCreateRegion function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getregiondata DWORD GetRegionData( HRGN hrgn, DWORD nCount,
		// LPRGNDATA lpRgnData );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "e0d4862d-a405-4c00-b7b0-af4dd60407c0")]
		public static extern uint GetRegionData(HRGN hrgn, uint nCount, [In, Out] RGNDATA lpRgnData);

		/// <summary>The <c>GetRgnBox</c> function retrieves the bounding rectangle of the specified region.</summary>
		/// <param name="hrgn">A handle to the region.</param>
		/// <param name="lprc">A pointer to a RECT structure that receives the bounding rectangle in logical units.</param>
		/// <returns>
		/// <para>The return value specifies the region's complexity. It can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NULLREGION</term>
		/// <term>Region is empty.</term>
		/// </item>
		/// <item>
		/// <term>SIMPLEREGION</term>
		/// <term>Region is a single rectangle.</term>
		/// </item>
		/// <item>
		/// <term>COMPLEXREGION</term>
		/// <term>Region is more than a single rectangle.</term>
		/// </item>
		/// </list>
		/// <para>If the hrgn parameter does not identify a valid region, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getrgnbox int GetRgnBox( HRGN hrgn, LPRECT lprc );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "42d06f7f-1bf3-418f-a3b9-c009cf2de10b")]
		public static extern RGN_TYPE GetRgnBox(HRGN hrgn, out RECT lprc);

		/// <summary>The <c>InvertRgn</c> function inverts the colors in the specified region.</summary>
		/// <param name="hdc">Handle to the device context.</param>
		/// <param name="hrgn">
		/// Handle to the region for which colors are inverted. The region's coordinates are presumed to be logical coordinates.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// On monochrome screens, the <c>InvertRgn</c> function makes white pixels black and black pixels white. On color screens, this
		/// inversion is dependent on the type of technology used to generate the colors for the screen.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Brushes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-invertrgn BOOL InvertRgn( HDC hdc, HRGN hrgn );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "94704c44-796a-4ca7-97f3-6676d7f94078")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InvertRgn(HDC hdc, HRGN hrgn);

		/// <summary>The <c>OffsetRgn</c> function moves a region by the specified offsets.</summary>
		/// <param name="hrgn">Handle to the region to be moved.</param>
		/// <param name="x">Specifies the number of logical units to move left or right.</param>
		/// <param name="y">Specifies the number of logical units to move up or down.</param>
		/// <returns>
		/// <para>The return value specifies the new region's complexity. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NULLREGION</term>
		/// <term>Region is empty.</term>
		/// </item>
		/// <item>
		/// <term>SIMPLEREGION</term>
		/// <term>Region is a single rectangle.</term>
		/// </item>
		/// <item>
		/// <term>COMPLEXREGION</term>
		/// <term>Region is more than one rectangle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR</term>
		/// <term>An error occurred; region is unaffected.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-offsetrgn int OffsetRgn( HRGN hrgn, int x, int y );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "5228c614-3278-4852-a867-7eed57359aef")]
		public static extern RGN_TYPE OffsetRgn(HRGN hrgn, int x, int y);

		/// <summary>The <c>PaintRgn</c> function paints the specified region by using the brush currently selected into the device context.</summary>
		/// <param name="hdc">Handle to the device context.</param>
		/// <param name="hrgn">Handle to the region to be filled. The region's coordinates are presumed to be logical coordinates.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-paintrgn BOOL PaintRgn( HDC hdc, HRGN hrgn );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "7656fb67-d865-459e-b379-4f2e44c76fd0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PaintRgn(HDC hdc, HRGN hrgn);

		/// <summary>The <c>PtInRegion</c> function determines whether the specified point is inside the specified region.</summary>
		/// <param name="hrgn">Handle to the region to be examined.</param>
		/// <param name="x">Specifies the x-coordinate of the point in logical units.</param>
		/// <param name="y">Specifies the y-coordinate of the point in logical units.</param>
		/// <returns>
		/// <para>If the specified point is in the region, the return value is nonzero.</para>
		/// <para>If the specified point is not in the region, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-ptinregion BOOL PtInRegion( HRGN hrgn, int x, int y );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "6fab6126-4672-49d6-825b-66a7927a7e99")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PtInRegion(HRGN hrgn, int x, int y);

		/// <summary>
		/// The <c>RectInRegion</c> function determines whether any part of the specified rectangle is within the boundaries of a region.
		/// </summary>
		/// <param name="hrgn">Handle to the region.</param>
		/// <param name="lprect">
		/// Pointer to a RECT structure containing the coordinates of the rectangle in logical units. The lower and right edges of the
		/// rectangle are not included.
		/// </param>
		/// <returns>
		/// <para>If any part of the specified rectangle lies within the boundaries of the region, the return value is nonzero.</para>
		/// <para>If no part of the specified rectangle lies within the boundaries of the region, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-rectinregion BOOL RectInRegion( HRGN hrgn, const RECT
		// *lprect );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "198a02f1-120c-4f65-aa7c-a41f2e5e81a9")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RectInRegion(HRGN hrgn, in RECT lprect);

		/// <summary>The <c>SetPolyFillMode</c> function sets the polygon fill mode for functions that fill polygons.</summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="mode">
		/// <para>The new fill mode. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ALTERNATE</term>
		/// <term>Selects alternate mode (fills the area between odd-numbered and even-numbered polygon sides on each scan line).</term>
		/// </item>
		/// <item>
		/// <term>WINDING</term>
		/// <term>Selects winding mode (fills any region with a nonzero winding value).</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The return value specifies the previous filling mode. If an error occurs, the return value is zero.</returns>
		/// <remarks>
		/// <para>
		/// In general, the modes differ only in cases where a complex, overlapping polygon must be filled (for example, a five-sided polygon
		/// that forms a five-pointed star with a pentagon in the center). In such cases, ALTERNATE mode fills every other enclosed region
		/// within the polygon (that is, the points of the star), but WINDING mode fills all regions (that is, the points and the pentagon).
		/// </para>
		/// <para>
		/// When the fill mode is ALTERNATE, GDI fills the area between odd-numbered and even-numbered polygon sides on each scan line. That
		/// is, GDI fills the area between the first and second side, between the third and fourth side, and so on.
		/// </para>
		/// <para>
		/// When the fill mode is WINDING, GDI fills any region that has a nonzero winding value. This value is defined as the number of
		/// times a pen used to draw the polygon would go around the region. The direction of each edge of the polygon is important.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-setpolyfillmode int SetPolyFillMode( HDC hdc, int mode );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "233926c4-2658-405d-89b6-05ece844623d")]
		public static extern RGN_FILLMODE SetPolyFillMode(HDC hdc, RGN_FILLMODE mode);

		/// <summary>The <c>SetRectRgn</c> function converts a region into a rectangular region with the specified coordinates.</summary>
		/// <param name="hrgn">Handle to the region.</param>
		/// <param name="left">Specifies the x-coordinate of the upper-left corner of the rectangular region in logical units.</param>
		/// <param name="top">Specifies the y-coordinate of the upper-left corner of the rectangular region in logical units.</param>
		/// <param name="right">Specifies the x-coordinate of the lower-right corner of the rectangular region in logical units.</param>
		/// <param name="bottom">Specifies the y-coordinate of the lower-right corner of the rectangular region in logical units.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>The region does not include the lower and right boundaries of the rectangle.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setrectrgn
		// BOOL SetRectRgn( HRGN hrgn, int left, int top, int right, int bottom );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "9a024d61-f397-43d8-a48e-edb8102a6f55")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetRectRgn(HRGN hrgn, int left, int top, int right, int bottom);

		/// <summary>The <c>RGNDATAHEADER</c> structure describes the data returned by the GetRegionData function.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-_rgndataheader typedef struct _RGNDATAHEADER { DWORD dwSize;
		// DWORD iType; DWORD nCount; DWORD nRgnSize; RECT rcBound; } RGNDATAHEADER, *PRGNDATAHEADER;
		[PInvokeData("wingdi.h", MSDNShortId = "15990903-8a48-4c47-b527-269d775255a5")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RGNDATAHEADER
		{
			/// <summary>The size, in bytes, of the header.</summary>
			public uint dwSize;

			/// <summary>The type of region. This value must be RDH_RECTANGLES.</summary>
			public RDH iType;

			/// <summary>The number of rectangles that make up the region.</summary>
			public uint nCount;

			/// <summary>
			/// The size of the RGNDATA buffer required to receive the RECT structures that make up the region. If the size is not known,
			/// this member can be zero.
			/// </summary>
			public int nRgnSize;

			/// <summary>A bounding rectangle for the region in logical units.</summary>
			public RECT rcBound;
		}

		/// <summary>
		/// The <c>RGNDATA</c> structure contains a header and an array of rectangles that compose a region. The rectangles are sorted top to
		/// bottom, left to right. They do not overlap.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-_rgndata typedef struct _RGNDATA { RGNDATAHEADER rdh; char
		// Buffer[1]; } RGNDATA, *PRGNDATA, *NPRGNDATA, *LPRGNDATA;
		[PInvokeData("wingdi.h", MSDNShortId = "3eac0b23-3138-4b34-9c16-6cc185e4de22")]
		[StructLayout(LayoutKind.Sequential)]
		public class RGNDATA : IDisposable
		{
			/// <summary>
			/// A RGNDATAHEADER structure. The members of this structure specify the type of region (whether it is rectangular or
			/// trapezoidal), the number of rectangles that make up the region, the size of the buffer that contains the rectangle
			/// structures, and so on.
			/// </summary>
			public RGNDATAHEADER rdh;

			private IntPtr _Buffer;

			/// <summary>Specifies an arbitrary-size buffer that contains the RECT structures that make up the region.</summary>
			public RECT[] Buffer
			{
				get => _Buffer.ToArray<RECT>((int)rdh.nCount);
				set
				{
					((IDisposable)this).Dispose();
					value = value ?? new RECT[0];
					_Buffer = value.MarshalToPtr<RECT>(Marshal.AllocHGlobal, out rdh.nRgnSize);
					rdh.nCount = (uint)value.Length;
				}
			}

			/// <summary>Gets the size, in bytes, of the structure with allocated memory for <see cref="Buffer"/>.</summary>
			public uint Size => rdh.dwSize + (uint)rdh.nRgnSize;

			/// <summary>Initializes a new instance of the <see cref="RGNDATA"/> class.</summary>
			/// <param name="bounds">A bounding rectangle for the region in logical units.</param>
			/// <param name="count">The number of rectangles that make up the region.</param>
			public RGNDATA(in RECT bounds, int count)
			{
				rdh.dwSize = (uint)Marshal.SizeOf(typeof(RGNDATAHEADER));
				rdh.iType = RDH.RDH_RECTANGLES;
				Buffer = new RECT[count];
				rdh.rcBound = bounds;
			}

			/// <summary>Initializes a new instance of the <see cref="RGNDATA"/> class.</summary>
			/// <param name="bounds">A bounding rectangle for the region in logical units.</param>
			/// <param name="rects">The RECT structures that make up the region.</param>
			public RGNDATA(in RECT bounds, RECT[] rects)
			{
				rdh.dwSize = (uint)Marshal.SizeOf(typeof(RGNDATAHEADER));
				rdh.iType = RDH.RDH_RECTANGLES;
				Buffer = rects;
				rdh.rcBound = bounds;
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose() { Marshal.FreeHGlobal(_Buffer); _Buffer = IntPtr.Zero; }
		}
	}
}