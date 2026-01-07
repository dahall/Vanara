namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>The graphics mode.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "62e2960b-d414-4e84-a94f-60b192071402")]
	public enum GraphicsMode
	{
		/// <summary>
		/// The current graphics mode is the compatible graphics mode, a mode that is compatible with 16-bit Windows. In this graphics
		/// mode, an application cannot set or modify the world transformation for the specified device context. The compatible graphics
		/// mode is the default graphics mode.
		/// </summary>
		GM_COMPATIBLE = 1,

		/// <summary>
		/// The current graphics mode is the advanced graphics mode, a mode that allows world transformations. In this graphics mode, an
		/// application can set or modify the world transformation for the specified device context.
		/// </summary>
		GM_ADVANCED = 2
	}

	/// <summary>A mapping mode.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "bc446b86-3dde-4460-bc54-1eaa4ad19941")]
	public enum MapMode
	{
		/// <summary>
		/// Logical units are mapped to arbitrary units with arbitrarily scaled axes. Use the SetWindowExtEx and SetViewportExtEx
		/// functions to specify the units, orientation, and scaling required.
		/// </summary>
		MM_ANISOTROPIC = 8,

		/// <summary>Each logical unit is mapped to 0.001 inch. Positive x is to the right; positive y is up.</summary>
		MM_HIENGLISH = 5,

		/// <summary>Each logical unit is mapped to 0.01 millimeter. Positive x is to the right; positive y is up.</summary>
		MM_HIMETRIC = 3,

		/// <summary>
		/// Logical units are mapped to arbitrary units with equally scaled axes; that is, one unit along the x-axis is equal to one unit
		/// along the y-axis. Use the SetWindowExtEx and SetViewportExtEx functions to specify the units and the orientation of the axes.
		/// Graphics device interface makes adjustments as necessary to ensure the x and y units remain the same size. (When the windows
		/// extent is set, the viewport will be adjusted to keep the units isotropic).
		/// </summary>
		MM_ISOTROPIC = 7,

		/// <summary>Each logical unit is mapped to 0.01 inch. Positive x is to the right; positive y is up.</summary>
		MM_LOENGLISH = 4,

		/// <summary>Each logical unit is mapped to 0.1 millimeter. Positive x is to the right; positive y is up.</summary>
		MM_LOMETRIC = 2,

		/// <summary>Each logical unit is mapped to one device pixel. Positive x is to the right; positive y is down.</summary>
		MM_TEXT = 1,

		/// <summary>
		/// Each logical unit is mapped to one twentieth of a printer's point (1/1440 inch, also called a "twip"). Positive x is to the
		/// right; positive y is up.
		/// </summary>
		MM_TWIPS = 6,
	}

	/// <summary>Specifies how the transformation data modifies the current world transformation.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "2ce070e8-dd6d-4f28-8214-37e825b44273")]
	public enum MWT
	{
		/// <summary>
		/// Resets the current world transformation by using the identity matrix. If this mode is specified, the XFORM structure pointed
		/// to by lpXform is ignored.
		/// </summary>
		MWT_IDENTITY = 1,

		/// <summary>
		/// Multiplies the current transformation by the data in the XFORM structure. (The data in the XFORM structure becomes the left
		/// multiplicand, and the data for the current transformation becomes the right multiplicand.)
		/// </summary>
		MWT_LEFTMULTIPLY = 2,

		/// <summary>
		/// Multiplies the current transformation by the data in the XFORM structure. (The data in the XFORM structure becomes the right
		/// multiplicand, and the data for the current transformation becomes the left multiplicand.)
		/// </summary>
		MWT_RIGHTMULTIPLY = 3,
	}

	/// <summary>The <c>CombineTransform</c> function concatenates two world-space to page-space transformations.</summary>
	/// <param name="lpxfOut">A pointer to an XFORM structure that receives the combined transformation.</param>
	/// <param name="lpxf1">A pointer to an XFORM structure that specifies the first transformation.</param>
	/// <param name="lpxf2">A pointer to an XFORM structure that specifies the second transformation.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Applying the combined transformation has the same effect as applying the first transformation and then applying the second transformation.
	/// </para>
	/// <para>The three transformations need not be distinct. For example, lpxform1 can point to the same XFORM structure as lpxformResult.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-combinetransform BOOL CombineTransform( LPXFORM lpxfOut, const
	// XFORM *lpxf1, const XFORM *lpxf2 );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "6ccd7828-7aa6-4c86-a340-b93e50cf3a2a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CombineTransform(out XFORM lpxfOut, in XFORM lpxf1, in XFORM lpxf2);

	/// <summary>
	/// The <c>DPtoLP</c> function converts device coordinates into logical coordinates. The conversion depends on the mapping mode of
	/// the device context, the settings of the origins and extents for the window and viewport, and the world transformation.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lppt">
	/// A pointer to an array of POINT structures. The x- and y-coordinates contained in each <c>POINT</c> structure will be transformed.
	/// </param>
	/// <param name="c">The number of points in the array.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DPtoLP</c> function fails if the device coordinates exceed 27 bits, or if the converted logical coordinates exceed 32
	/// bits. In the case of such an overflow, the results for all the points are undefined.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Using Coordinate Spaces and Transformations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-dptolp BOOL DPtoLP( HDC hdc, LPPOINT lppt, int c );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "0106867c-e8c5-4826-8cba-60c29e1d021a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DPtoLP([In, AddAsMember] HDC hdc, [In, Out] POINT[] lppt, int c);

	/// <summary>The <c>GetCurrentPositionEx</c> function retrieves the current position in logical coordinates.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lppt">A pointer to a POINT structure that receives the logical coordinates of the current position.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcurrentpositionex BOOL GetCurrentPositionEx( HDC hdc,
	// LPPOINT lppt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "23a5ac58-2b88-42d3-ab02-8edb8ef187cc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCurrentPositionEx([In, AddAsMember] HDC hdc, out POINT lppt);

	/// <summary>The <c>GetGraphicsMode</c> function retrieves the current graphics mode for the specified device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the current graphics mode. It can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GM_COMPATIBLE</term>
	/// <term>
	/// The current graphics mode is the compatible graphics mode, a mode that is compatible with 16-bit Windows. In this graphics mode,
	/// an application cannot set or modify the world transformation for the specified device context. The compatible graphics mode is
	/// the default graphics mode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GM_ADVANCED</term>
	/// <term>
	/// The current graphics mode is the advanced graphics mode, a mode that allows world transformations. In this graphics mode, an
	/// application can set or modify the world transformation for the specified device context.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Otherwise, the return value is zero.</para>
	/// </returns>
	/// <remarks>An application can set the graphics mode for a device context by calling the SetGraphicsMode function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getgraphicsmode int GetGraphicsMode( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "62e2960b-d414-4e84-a94f-60b192071402")]
	public static extern GraphicsMode GetGraphicsMode([In, AddAsMember] HDC hdc);

	/// <summary>The <c>GetMapMode</c> function retrieves the current mapping mode.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the mapping mode.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following are the various mapping modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mode</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MM_ANISOTROPIC</term>
	/// <term>
	/// Logical units are mapped to arbitrary units with arbitrarily scaled axes. Use the SetWindowExtEx and SetViewportExtEx functions
	/// to specify the units, orientation, and scaling required.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MM_HIENGLISH</term>
	/// <term>Each logical unit is mapped to 0.001 inch. Positive x is to the right; positive y is up.</term>
	/// </item>
	/// <item>
	/// <term>MM_HIMETRIC</term>
	/// <term>Each logical unit is mapped to 0.01 millimeter. Positive x is to the right; positive y is up.</term>
	/// </item>
	/// <item>
	/// <term>MM_ISOTROPIC</term>
	/// <term>
	/// Logical units are mapped to arbitrary units with equally scaled axes; that is, one unit along the x-axis is equal to one unit
	/// along the y-axis. Use the SetWindowExtEx and SetViewportExtEx functions to specify the units and the orientation of the axes.
	/// Graphics device interface makes adjustments as necessary to ensure the x and y units remain the same size. (When the windows
	/// extent is set, the viewport will be adjusted to keep the units isotropic).
	/// </term>
	/// </item>
	/// <item>
	/// <term>MM_LOENGLISH</term>
	/// <term>Each logical unit is mapped to 0.01 inch. Positive x is to the right; positive y is up.</term>
	/// </item>
	/// <item>
	/// <term>MM_LOMETRIC</term>
	/// <term>Each logical unit is mapped to 0.1 millimeter. Positive x is to the right; positive y is up.</term>
	/// </item>
	/// <item>
	/// <term>MM_TEXT</term>
	/// <term>Each logical unit is mapped to one device pixel. Positive x is to the right; positive y is down.</term>
	/// </item>
	/// <item>
	/// <term>MM_TWIPS</term>
	/// <term>
	/// Each logical unit is mapped to one twentieth of a printer's point (1/1440 inch, also called a "twip"). Positive x is to the
	/// right; positive y is up.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getmapmode int GetMapMode( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "bc446b86-3dde-4460-bc54-1eaa4ad19941")]
	public static extern MapMode GetMapMode([In, AddAsMember] HDC hdc);

	/// <summary>
	/// The <c>GetViewportExtEx</c> function retrieves the x-extent and y-extent of the current viewport for the specified device context.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpsize">A pointer to a SIZE structure that receives the x- and y-extents, in device units.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getviewportextex BOOL GetViewportExtEx( HDC hdc, LPSIZE lpsize );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "e3fc188a-3796-497d-9d86-f116e9e48e30")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetViewportExtEx([In, AddAsMember] HDC hdc, out SIZE lpsize);

	/// <summary>
	/// The <c>GetViewportOrgEx</c> function retrieves the x-coordinates and y-coordinates of the viewport origin for the specified
	/// device context.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lppoint">A pointer to a POINT structure that receives the coordinates of the origin, in device units.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getviewportorgex BOOL GetViewportOrgEx( HDC hdc, LPPOINT
	// lppoint );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "6e6c7090-edf4-46a3-8bcd-10a00c0cf847")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetViewportOrgEx([In, AddAsMember] HDC hdc, out POINT lppoint);

	/// <summary>This function retrieves the x-extent and y-extent of the window for the specified device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpsize">
	/// A pointer to a SIZE structure that receives the x- and y-extents in page-space units, that is, logical units.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getwindowextex BOOL GetWindowExtEx( HDC hdc, LPSIZE lpsize );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "17f41fcb-c9a4-4b7e-acde-73450044413e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowExtEx([In, AddAsMember] HDC hdc, out SIZE lpsize);

	/// <summary>
	/// The <c>GetWindowOrgEx</c> function retrieves the x-coordinates and y-coordinates of the window origin for the specified device context.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lppoint">A pointer to a POINT structure that receives the coordinates, in logical units, of the window origin.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getwindoworgex BOOL GetWindowOrgEx( HDC hdc, LPPOINT lppoint );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "9579ed10-6d4c-4724-af8b-22cab5b6ff5e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowOrgEx([In, AddAsMember] HDC hdc, out POINT lppoint);

	/// <summary>The <c>GetWorldTransform</c> function retrieves the current world-space to page-space transformation.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpxf">A pointer to an XFORM structure that receives the current world-space to page-space transformation.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The precision of the transformation may be altered if an application calls the ModifyWorldTransform function prior to calling
	/// <c>GetWorldTransform</c>. (This is because the internal format for storing transformation values uses a higher precision than a
	/// <c>FLOAT</c> value.)
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getworldtransform BOOL GetWorldTransform( HDC hdc, LPXFORM
	// lpxf );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "72945b1e-144e-4724-bf08-6f971f8adb43")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWorldTransform([In, AddAsMember] HDC hdc, out XFORM lpxf);

	/// <summary>Converts a height in logical units to pixels.</summary>
	/// <param name="height">The height in logical units.</param>
	/// <param name="hdc">The device context handle.</param>
	/// <returns>The height in pixels.</returns>
	public static int LogicalHeightToDeviceWidth(int height, HDC hdc = default)
	{
		var pts = new[] { new POINT(0, height) };
		LPtoDP(hdc.IsNull ? SafeHDC.ScreenCompatibleDCHandle : hdc, pts, 1);
		return pts[0].Y;
	}

	/// <summary>Converts a width in logical units to pixels.</summary>
	/// <param name="width">The width in logical units.</param>
	/// <param name="hdc">The device context handle.</param>
	/// <returns>The width in pixels.</returns>
	public static int LogicalWidthToDeviceWidth(int width, HDC hdc = default)
	{
		var pts = new[] { new POINT(width, 0) };
		LPtoDP(hdc.IsNull ? SafeHDC.ScreenCompatibleDCHandle : hdc, pts, 1);
		return pts[0].X;
	}

	/// <summary>
	/// <para>
	/// The <c>LPtoDP</c> function converts logical coordinates into device coordinates. The conversion depends on the mapping mode of
	/// the device context, the settings of the origins and extents for the window and viewport, and the world transformation.
	/// </para>
	/// </summary>
	/// <param name="hdc">
	/// <para>A handle to the device context.</para>
	/// </param>
	/// <param name="lppt">
	/// <para>
	/// A pointer to an array of POINT structures. The x-coordinates and y-coordinates contained in each of the <c>POINT</c> structures
	/// will be transformed.
	/// </para>
	/// </param>
	/// <param name="c">
	/// <para>The number of points in the array.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>LPtoDP</c> function fails if the logical coordinates exceed 32 bits, or if the converted device coordinates exceed 27
	/// bits. In the case of such an overflow, the results for all the points are undefined.
	/// </para>
	/// <para>
	/// <c>LPtoDP</c> calculates complex floating-point arithmetic, and it has a caching system for efficiency. Therefore, the conversion
	/// result of an initial call to <c>LPtoDP</c> might not exactly match the conversion result of a later call to <c>LPtoDP</c>. We
	/// recommend not to write code that relies on the exact match of the conversion results from multiple calls to <c>LPtoDP</c> even if
	/// the parameters that are passed to each call are identical.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-lptodp BOOL LPtoDP( HDC hdc, LPPOINT lppt, int c );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "670a16fb-842e-4250-9ad7-dc08e849c2ba")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LPtoDP([In, AddAsMember] HDC hdc, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] POINT[] lppt, int c);

	/// <summary>
	/// <para>
	/// The <c>LPtoDP</c> function converts logical coordinates into device coordinates. The conversion depends on the mapping mode of
	/// the device context, the settings of the origins and extents for the window and viewport, and the world transformation.
	/// </para>
	/// </summary>
	/// <param name="hdc">
	/// <para>A handle to the device context.</para>
	/// </param>
	/// <param name="lppt">
	/// <para>
	/// A pointer to an array of POINT structures. The x-coordinates and y-coordinates contained in each of the <c>POINT</c> structures
	/// will be transformed.
	/// </para>
	/// </param>
	/// <param name="c">
	/// <para>The number of points in the array.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>LPtoDP</c> function fails if the logical coordinates exceed 32 bits, or if the converted device coordinates exceed 27
	/// bits. In the case of such an overflow, the results for all the points are undefined.
	/// </para>
	/// <para>
	/// <c>LPtoDP</c> calculates complex floating-point arithmetic, and it has a caching system for efficiency. Therefore, the conversion
	/// result of an initial call to <c>LPtoDP</c> might not exactly match the conversion result of a later call to <c>LPtoDP</c>. We
	/// recommend not to write code that relies on the exact match of the conversion results from multiple calls to <c>LPtoDP</c> even if
	/// the parameters that are passed to each call are identical.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-lptodp BOOL LPtoDP( HDC hdc, LPPOINT lppt, int c );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "670a16fb-842e-4250-9ad7-dc08e849c2ba")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LPtoDP([In, AddAsMember] HDC hdc, ref POINT lppt, int c = 1);

	/// <summary>
	/// The <c>ModifyWorldTransform</c> function changes the world transformation for a device context using the specified mode.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpxf">A pointer to an XFORM structure used to modify the world transformation for the given device context.</param>
	/// <param name="mode">
	/// <para>
	/// Specifies how the transformation data modifies the current world transformation. This parameter must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MWT_IDENTITY</term>
	/// <term>
	/// Resets the current world transformation by using the identity matrix. If this mode is specified, the XFORM structure pointed to
	/// by lpXform is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MWT_LEFTMULTIPLY</term>
	/// <term>
	/// Multiplies the current transformation by the data in the XFORM structure. (The data in the XFORM structure becomes the left
	/// multiplicand, and the data for the current transformation becomes the right multiplicand.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>MWT_RIGHTMULTIPLY</term>
	/// <term>
	/// Multiplies the current transformation by the data in the XFORM structure. (The data in the XFORM structure becomes the right
	/// multiplicand, and the data for the current transformation becomes the left multiplicand.)
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The <c>ModifyWorldTransform</c> function will fail unless graphics mode for the specified device context has been set to
	/// GM_ADVANCED by previously calling the SetGraphicsMode function. Likewise, it will not be possible to reset the graphics mode for
	/// the device context to the default GM_COMPATIBLE mode, unless world transform has first been reset to the default identity
	/// transform by calling SetWorldTransform or <c>ModifyWorldTransform</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-modifyworldtransform BOOL ModifyWorldTransform( HDC hdc, const
	// XFORM *lpxf, DWORD mode );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "2ce070e8-dd6d-4f28-8214-37e825b44273")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ModifyWorldTransform([In, AddAsMember] HDC hdc, in XFORM lpxf, MWT mode);

	/// <summary>
	/// The <c>OffsetViewportOrgEx</c> function modifies the viewport origin for a device context using the specified horizontal and
	/// vertical offsets.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The horizontal offset, in device units.</param>
	/// <param name="y">The vertical offset, in device units.</param>
	/// <param name="lppt">
	/// A pointer to a POINT structure. The previous viewport origin, in device units, is placed in this structure. If lpPoint is
	/// <c>NULL</c>, the previous viewport origin is not returned.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>The new origin is the sum of the current origin and the horizontal and vertical offsets.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-offsetviewportorgex BOOL OffsetViewportOrgEx( HDC hdc, int x,
	// int y, LPPOINT lppt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "54311cbe-1c54-4193-8991-891dbd0856bf")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OffsetViewportOrgEx([In, AddAsMember] HDC hdc, int x, int y, out POINT lppt);

	/// <summary>
	/// The <c>OffsetWindowOrgEx</c> function modifies the window origin for a device context using the specified horizontal and vertical offsets.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The horizontal offset, in logical units.</param>
	/// <param name="y">The vertical offset, in logical units.</param>
	/// <param name="lppt">
	/// A pointer to a POINT structure. The logical coordinates of the previous window origin are placed in this structure. If lpPoint is
	/// <c>NULL</c>, the previous origin is not returned.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-offsetwindoworgex BOOL OffsetWindowOrgEx( HDC hdc, int x, int
	// y, LPPOINT lppt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "085f40ac-d91f-4853-8ad1-1fc5da08b981")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OffsetWindowOrgEx([In, AddAsMember] HDC hdc, int x, int y, out POINT lppt);

	/// <summary>
	/// The <c>ScaleViewportExtEx</c> function modifies the viewport for a device context using the ratios formed by the specified
	/// multiplicands and divisors.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="xn">The amount by which to multiply the current horizontal extent.</param>
	/// <param name="dx">The amount by which to divide the current horizontal extent.</param>
	/// <param name="yn">The amount by which to multiply the current vertical extent.</param>
	/// <param name="yd">The amount by which to divide the current vertical extent.</param>
	/// <param name="lpsz">
	/// A pointer to a SIZE structure that receives the previous viewport extents, in device units. If lpSize is <c>NULL</c>, this
	/// parameter is not used.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>The viewport extents are modified as follows:</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-scaleviewportextex BOOL ScaleViewportExtEx( HDC hdc, int xn,
	// int dx, int yn, int yd, LPSIZE lpsz );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "8dde1322-82d7-4069-9655-a7bd3a324cb0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ScaleViewportExtEx([In, AddAsMember] HDC hdc, int xn, int dx, int yn, int yd, out SIZE lpsz);

	/// <summary>
	/// The <c>ScaleWindowExtEx</c> function modifies the window for a device context using the ratios formed by the specified
	/// multiplicands and divisors.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="xn">The amount by which to multiply the current horizontal extent.</param>
	/// <param name="xd">The amount by which to divide the current horizontal extent.</param>
	/// <param name="yn">The amount by which to multiply the current vertical extent.</param>
	/// <param name="yd">The amount by which to divide the current vertical extent.</param>
	/// <param name="lpsz">
	/// A pointer to a SIZE structure that receives the previous window extents, in logical units. If lpSize is <c>NULL</c>, this
	/// parameter is not used.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>The window extents are modified as follows:</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-scalewindowextex BOOL ScaleWindowExtEx( HDC hdc, int xn, int
	// xd, int yn, int yd, LPSIZE lpsz );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "c34f0978-74dd-4839-99f2-a106f3d2c0f9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ScaleWindowExtEx([In, AddAsMember] HDC hdc, int xn, int xd, int yn, int yd, out SIZE lpsz);

	/// <summary>The <c>SetGraphicsMode</c> function sets the graphics mode for the specified device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="iMode">
	/// <para>The graphics mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GM_COMPATIBLE</term>
	/// <term>
	/// Sets the graphics mode that is compatible with 16-bit Windows. This is the default mode. If this value is specified, the
	/// application can only modify the world-to-device transform by calling functions that set window and viewport extents and origins,
	/// but not by using SetWorldTransform or ModifyWorldTransform; calls to those functions will fail. Examples of functions that set
	/// window and viewport extents and origins are SetViewportExtEx and SetWindowExtEx.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GM_ADVANCED</term>
	/// <term>
	/// Sets the advanced graphics mode that allows world transformations. This value must be specified if the application will set or
	/// modify the world transformation for the specified device context. In this mode all graphics, including text output, fully conform
	/// to the world-to-device transformation specified in the device context.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the old graphics mode.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>There are three areas in which graphics output differs according to the graphics mode:</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Text Output: In the GM_COMPATIBLE mode, TrueType (or vector font) text output behaves much the same way as raster font text
	/// output with respect to the world-to-device transformations in the DC. The TrueType text is always written from left to right and
	/// right side up, even if the rest of the graphics will be flipped on the x or y axis. Only the height of the TrueType (or vector
	/// font) text is scaled. The only way to write text that is not horizontal in the GM_COMPATIBLE mode is to specify nonzero
	/// escapement and orientation for the logical font selected in this device context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Rectangle Exclusion: If the default GM_COMPATIBLE graphics mode is set, the system excludes bottom and rightmost edges when it
	/// draws rectangles.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Arc Drawing: If the default GM_COMPATIBLE graphics mode is set, GDI draws arcs using the current arc direction in the device
	/// space. With this convention, arcs do not respect page-to-device transforms that require a flip along the x or y axis.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Using Coordinate Spaces and Transformations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setgraphicsmode int SetGraphicsMode( HDC hdc, int iMode );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "73824a14-2951-45a2-98cd-156418c59a2d")]
	public static extern GraphicsMode SetGraphicsMode([In, AddAsMember] HDC hdc, GraphicsMode iMode);

	/// <summary>
	/// The <c>SetMapMode</c> function sets the mapping mode of the specified device context. The mapping mode defines the unit of
	/// measure used to transform page-space units into device-space units, and also defines the orientation of the device's x and y axes.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="iMode">
	/// <para>The new mapping mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MM_ANISOTROPIC</term>
	/// <term>
	/// Logical units are mapped to arbitrary units with arbitrarily scaled axes. Use the SetWindowExtEx and SetViewportExtEx functions
	/// to specify the units, orientation, and scaling.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MM_HIENGLISH</term>
	/// <term>Each logical unit is mapped to 0.001 inch. Positive x is to the right; positive y is up.</term>
	/// </item>
	/// <item>
	/// <term>MM_HIMETRIC</term>
	/// <term>Each logical unit is mapped to 0.01 millimeter. Positive x is to the right; positive y is up.</term>
	/// </item>
	/// <item>
	/// <term>MM_ISOTROPIC</term>
	/// <term>
	/// Logical units are mapped to arbitrary units with equally scaled axes; that is, one unit along the x-axis is equal to one unit
	/// along the y-axis. Use the SetWindowExtEx and SetViewportExtEx functions to specify the units and the orientation of the axes.
	/// Graphics device interface (GDI) makes adjustments as necessary to ensure the x and y units remain the same size (When the window
	/// extent is set, the viewport will be adjusted to keep the units isotropic).
	/// </term>
	/// </item>
	/// <item>
	/// <term>MM_LOENGLISH</term>
	/// <term>Each logical unit is mapped to 0.01 inch. Positive x is to the right; positive y is up.</term>
	/// </item>
	/// <item>
	/// <term>MM_LOMETRIC</term>
	/// <term>Each logical unit is mapped to 0.1 millimeter. Positive x is to the right; positive y is up.</term>
	/// </item>
	/// <item>
	/// <term>MM_TEXT</term>
	/// <term>Each logical unit is mapped to one device pixel. Positive x is to the right; positive y is down.</term>
	/// </item>
	/// <item>
	/// <term>MM_TWIPS</term>
	/// <term>
	/// Each logical unit is mapped to one twentieth of a printer's point (1/1440 inch, also called a twip). Positive x is to the right;
	/// positive y is up.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value identifies the previous mapping mode.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The MM_TEXT mode allows applications to work in device pixels, whose size varies from device to device.</para>
	/// <para>
	/// The MM_HIENGLISH, MM_HIMETRIC, MM_LOENGLISH, MM_LOMETRIC, and MM_TWIPS modes are useful for applications drawing in physically
	/// meaningful units (such as inches or millimeters).
	/// </para>
	/// <para>The MM_ISOTROPIC mode ensures a 1:1 aspect ratio.</para>
	/// <para>The MM_ANISOTROPIC mode allows the x-coordinates and y-coordinates to be adjusted independently.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Using Coordinate Spaces and Transformations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setmapmode int SetMapMode( HDC hdc, int iMode );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "a4d6a63a-6d2d-4bd9-9e71-4cd1b5f145a4")]
	public static extern MapMode SetMapMode([In, AddAsMember] HDC hdc, MapMode iMode);

	/// <summary>
	/// The <c>SetViewportExtEx</c> function sets the horizontal and vertical extents of the viewport for a device context by using the
	/// specified values.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The horizontal extent, in device units, of the viewport.</param>
	/// <param name="y">The vertical extent, in device units, of the viewport.</param>
	/// <param name="lpsz">
	/// A pointer to a SIZE structure that receives the previous viewport extents, in device units. If lpSize is <c>NULL</c>, this
	/// parameter is not used.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The viewport refers to the device coordinate system of the device space. The extent is the maximum value of an axis. This
	/// function sets the maximum values for the horizontal and vertical axes of the viewport in device coordinates (or pixels). When
	/// mapping between page space and device space, SetWindowExtEx and <c>SetViewportExtEx</c> determine the scaling factor between the
	/// window and the viewport. For more information, see Transformation of Coordinate Spaces.
	/// </para>
	/// <para>When the following mapping modes are set, calls to the SetWindowExtEx and <c>SetViewportExtEx</c> functions are ignored.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>MM_HIENGLISH</term>
	/// </item>
	/// <item>
	/// <term>MM_HIMETRIC</term>
	/// </item>
	/// <item>
	/// <term>MM_LOENGLISH</term>
	/// </item>
	/// <item>
	/// <term>MM_LOMETRIC</term>
	/// </item>
	/// <item>
	/// <term>MM_TEXT</term>
	/// </item>
	/// <item>
	/// <term>MM_TWIPS</term>
	/// </item>
	/// </list>
	/// <para>
	/// When MM_ISOTROPIC mode is set, an application must call the SetWindowExtEx function before it calls <c>SetViewportExtEx</c>. Note
	/// that for the MM_ISOTROPIC mode certain portions of a nonsquare screen may not be available for display because the logical units
	/// on both axes represent equal physical distances.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Invalidating the Client Area.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setviewportextex BOOL SetViewportExtEx( HDC hdc, int x, int y,
	// LPSIZE lpsz );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "36bf82e0-f3e7-43cf-943f-eed783ad24a4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetViewportExtEx([In, AddAsMember] HDC hdc, int x, int y, out SIZE lpsz);

	/// <summary>The <c>SetViewportOrgEx</c> function specifies which device point maps to the window origin (0,0).</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The x-coordinate, in device units, of the new viewport origin.</param>
	/// <param name="y">The y-coordinate, in device units, of the new viewport origin.</param>
	/// <param name="lppt">
	/// A pointer to a POINT structure that receives the previous viewport origin, in device coordinates. If lpPoint is <c>NULL</c>, this
	/// parameter is not used.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function (along with SetViewportExtEx and SetWindowExtEx) helps define the mapping from the logical coordinate space (also
	/// known as a window) to the device coordinate space (the viewport). <c>SetViewportOrgEx</c> specifies which device point maps to
	/// the logical point (0,0). It has the effect of shifting the axes so that the logical point (0,0) no longer refers to the
	/// upper-left corner.
	/// </para>
	/// <para>
	/// This is related to the SetWindowOrgEx function. Generally, you will use one function or the other, but not both. Regardless of
	/// your use of <c>SetWindowOrgEx</c> and <c>SetViewportOrgEx</c>, the device point (0,0) is always the upper-left corner.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Redrawing in the Update Region.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setviewportorgex BOOL SetViewportOrgEx( HDC hdc, int x, int y,
	// LPPOINT lppt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d3b6326e-9fec-42a1-8d2e-d1ad4fcc79a4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetViewportOrgEx([In, AddAsMember] HDC hdc, int x, int y, out POINT lppt);

	/// <summary>
	/// The <c>SetWindowExtEx</c> function sets the horizontal and vertical extents of the window for a device context by using the
	/// specified values.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The window's horizontal extent in logical units.</param>
	/// <param name="y">The window's vertical extent in logical units.</param>
	/// <param name="lpsz">
	/// A pointer to a SIZE structure that receives the previous window extents, in logical units. If lpSize is <c>NULL</c>, this
	/// parameter is not used.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The window refers to the logical coordinate system of the page space. The extent is the maximum value of an axis. This function
	/// sets the maximum values for the horizontal and vertical axes of the window (in logical coordinates). When mapping between page
	/// space and device space, SetViewportExtEx and <c>SetWindowExtEx</c> determine the scaling factor between the window and the
	/// viewport. For more information, see Transformation of Coordinate Spaces.
	/// </para>
	/// <para>When the following mapping modes are set, calls to the <c>SetWindowExtEx</c> and SetViewportExtEx functions are ignored:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>MM_HIENGLISH</term>
	/// </item>
	/// <item>
	/// <term>MM_HIMETRIC</term>
	/// </item>
	/// <item>
	/// <term>MM_LOENGLISH</term>
	/// </item>
	/// <item>
	/// <term>MM_LOMETRIC</term>
	/// </item>
	/// <item>
	/// <term>MM_TEXT</term>
	/// </item>
	/// <item>
	/// <term>MM_TWIPS</term>
	/// </item>
	/// </list>
	/// <para>
	/// When MM_ISOTROPIC mode is set, an application must call the <c>SetWindowExtEx</c> function before calling SetViewportExtEx. Note
	/// that for the MM_ISOTROPIC mode, certain portions of a nonsquare screen may not be available for display because the logical units
	/// on both axes represent equal physical distances.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Invalidating the Client Area.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setwindowextex BOOL SetWindowExtEx( HDC hdc, int x, int y,
	// LPSIZE lpsz );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "8fd13d56-f6fa-4aea-a7e5-535caf22a840")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowExtEx([In, AddAsMember] HDC hdc, int x, int y, out SIZE lpsz);

	/// <summary>The <c>SetWindowOrgEx</c> function specifies which window point maps to the viewport origin (0,0).</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The x-coordinate, in logical units, of the new window origin.</param>
	/// <param name="y">The y-coordinate, in logical units, of the new window origin.</param>
	/// <param name="lppt">
	/// A pointer to a POINT structure that receives the previous origin of the window, in logical units. If lpPoint is <c>NULL</c>, this
	/// parameter is not used.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This helps define the mapping from the logical coordinate space (also known as a window) to the device coordinate space (the
	/// viewport). <c>SetWindowOrgEx</c> specifies which logical point maps to the device point (0,0). It has the effect of shifting the
	/// axes so that the logical point (0,0) no longer refers to the upper-left corner.
	/// </para>
	/// <para>
	/// This is related to the SetViewportOrgEx function. Generally, you will use one function or the other, but not both. Regardless of
	/// your use of <c>SetWindowOrgEx</c> and <c>SetViewportOrgEx</c>, the device point (0,0) is always the upper-left corner.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setwindoworgex BOOL SetWindowOrgEx( HDC hdc, int x, int y,
	// LPPOINT lppt );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "75409b5a-c003-49f2-aceb-a28330b92b0a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowOrgEx([In, AddAsMember] HDC hdc, int x, int y, out POINT lppt);

	/// <summary>
	/// The <c>SetWorldTransform</c> function sets a two-dimensional linear transformation between world space and page space for the
	/// specified device context. This transformation can be used to scale, rotate, shear, or translate graphics output.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpxf">A pointer to an XFORM structure that contains the transformation data.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For any coordinates (x, y) in world space, the transformed coordinates in page space (x', y') can be determined by the following algorithm:
	/// </para>
	/// <para>where the transformation matrix is represented by the following:</para>
	/// <para>This function uses logical units.</para>
	/// <para>The world transformation is usually used to scale or rotate logical images in a device-independent way.</para>
	/// <para>The default world transformation is the identity matrix with zero offset.</para>
	/// <para>
	/// The <c>SetWorldTransform</c> function will fail unless the graphics mode for the given device context has been set to GM_ADVANCED
	/// by previously calling the SetGraphicsMode function. Likewise, it will not be possible to reset the graphics mode for the device
	/// context to the default GM_COMPATIBLE mode, unless the world transformation has first been reset to the default identity
	/// transformation by calling <c>SetWorldTransform</c> or ModifyWorldTransform.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Using Coordinate Spaces and Transformations.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setworldtransform BOOL SetWorldTransform( HDC hdc, const XFORM
	// *lpxf );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d103a4dd-949e-4f18-ac90-bb0e51011233")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWorldTransform([In, AddAsMember] HDC hdc, in XFORM lpxf);

	/// <summary>The <c>XFORM</c> structure specifies a world-space to page-space transformation.</summary>
	/// <remarks>
	/// <para>The following list describes how the members are used for each operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Operation</term>
	/// <term>eM11</term>
	/// <term>eM12</term>
	/// <term>eM21</term>
	/// <term>eM22</term>
	/// </listheader>
	/// <item>
	/// <term>Rotation</term>
	/// <term>Cosine</term>
	/// <term>Sine</term>
	/// <term>Negative sine</term>
	/// <term>Cosine</term>
	/// </item>
	/// <item>
	/// <term>Scaling</term>
	/// <term>Horizontal scaling component</term>
	/// <term>Not used</term>
	/// <term>Not used</term>
	/// <term>Vertical Scaling Component</term>
	/// </item>
	/// <item>
	/// <term>Shear</term>
	/// <term>Not used</term>
	/// <term>Horizontal Proportionality Constant</term>
	/// <term>Vertical Proportionality Constant</term>
	/// <term>Not used</term>
	/// </item>
	/// <item>
	/// <term>Reflection</term>
	/// <term>Horizontal Reflection Component</term>
	/// <term>Not used</term>
	/// <term>Not used</term>
	/// <term>Vertical Reflection Component</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-xform typedef struct tagXFORM { FLOAT eM11; FLOAT eM12;
	// FLOAT eM21; FLOAT eM22; FLOAT eDx; FLOAT eDy; } XFORM, *PXFORM, *LPXFORM;
	[PInvokeData("wingdi.h", MSDNShortId = "49f0d7ee-77fa-415e-af00-b8930253a3a9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XFORM
	{
		/// <summary>
		/// <para>The following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Operation</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Scaling</term>
		/// <term>Horizontal scaling component</term>
		/// </item>
		/// <item>
		/// <term>Rotation</term>
		/// <term>Cosine of rotation angle</term>
		/// </item>
		/// <item>
		/// <term>Reflection</term>
		/// <term>Horizontal component</term>
		/// </item>
		/// </list>
		/// </summary>
		public float eM11;

		/// <summary>
		/// <para>The following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Operation</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Shear</term>
		/// <term>Horizontal proportionality constant</term>
		/// </item>
		/// <item>
		/// <term>Rotation</term>
		/// <term>Sine of the rotation angle</term>
		/// </item>
		/// </list>
		/// </summary>
		public float eM12;

		/// <summary>
		/// <para>The following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Operation</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Shear</term>
		/// <term>Vertical proportionality constant</term>
		/// </item>
		/// <item>
		/// <term>Rotation</term>
		/// <term>Negative sine of the rotation angle</term>
		/// </item>
		/// </list>
		/// </summary>
		public float eM21;

		/// <summary>
		/// <para>The following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Operation</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Scaling</term>
		/// <term>Vertical scaling component</term>
		/// </item>
		/// <item>
		/// <term>Rotation</term>
		/// <term>Cosine of rotation angle</term>
		/// </item>
		/// <item>
		/// <term>Reflection</term>
		/// <term>Vertical reflection component</term>
		/// </item>
		/// </list>
		/// </summary>
		public float eM22;

		/// <summary>The horizontal translation component, in logical units.</summary>
		public float eDx;

		/// <summary>The vertical translation component, in logical units.</summary>
		public float eDy;
	}
}