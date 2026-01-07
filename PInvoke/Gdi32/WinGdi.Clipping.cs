namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>Flags used with region functions.</summary>
	[PInvokeData("wingdi.h")]
	public enum RegionFlags
	{
		/// <summary>An error occurred.</summary>
		ERROR = 0,

		/// <summary>Region is empty.</summary>
		NULLREGION = 1,

		/// <summary>Region is a single rectangle.</summary>
		SIMPLEREGION = 2,

		/// <summary>Region consists of more than one rectangle.</summary>
		COMPLEXREGION = 3,
	}

	/// <summary>A region operation to perform.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "d222defe-2ef9-4622-b2e1-462a91cb1b0a")]
	public enum RegionOp
	{
		/// <summary>
		/// The new clipping region combines the overlapping areas of the current clipping region and the region identified by hrgn.
		/// </summary>
		RGN_AND = 1,

		/// <summary>The new clipping region combines the current clipping region and the region identified by hrgn.</summary>
		RGN_OR = 2,

		/// <summary>
		/// The new clipping region combines the current clipping region and the region identified by hrgn but excludes any overlapping areas.
		/// </summary>
		RGN_XOR = 3,

		/// <summary>
		/// The new clipping region combines the areas of the current clipping region with those areas excluded from the region
		/// identified by hrgn.
		/// </summary>
		RGN_DIFF = 4,

		/// <summary>
		/// The new clipping region is a copy of the region identified by hrgn. This is identical to SelectClipRgn. If the region
		/// identified by hrgn is NULL, the new clipping region is the default clipping region (the default clipping region is a null region).
		/// </summary>
		RGN_COPY = 5,
	}

	/// <summary>
	/// The <c>ExcludeClipRect</c> function creates a new clipping region that consists of the existing clipping region minus the
	/// specified rectangle.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="left">The x-coordinate, in logical units, of the upper-left corner of the rectangle.</param>
	/// <param name="top">The y-coordinate, in logical units, of the upper-left corner of the rectangle.</param>
	/// <param name="right">The x-coordinate, in logical units, of the lower-right corner of the rectangle.</param>
	/// <param name="bottom">The y-coordinate, in logical units, of the lower-right corner of the rectangle.</param>
	/// <returns>
	/// <para>The return value specifies the new clipping region's complexity; it can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
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
	/// <term>No region was created.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The lower and right edges of the specified rectangle are not excluded from the clipping region.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-excludecliprect int ExcludeClipRect( HDC hdc, int left, int
	// top, int right, int bottom );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "5b29c44a-3959-498e-8327-c42ef16a8609")]
	public static extern RegionFlags ExcludeClipRect([In, AddAsMember] HDC hdc, int left, int top, int right, int bottom);

	/// <summary>
	/// The <c>ExtSelectClipRgn</c> function combines the specified region with the current clipping region using the specified mode.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="hrgn">A handle to the region to be selected. This handle must not be <c>NULL</c> unless the RGN_COPY mode is specified.</param>
	/// <param name="mode">
	/// <para>The operation to be performed. It must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RGN_AND</term>
	/// <term>The new clipping region combines the overlapping areas of the current clipping region and the region identified by hrgn.</term>
	/// </item>
	/// <item>
	/// <term>RGN_COPY</term>
	/// <term>
	/// The new clipping region is a copy of the region identified by hrgn. This is identical to SelectClipRgn. If the region identified
	/// by hrgn is NULL, the new clipping region is the default clipping region (the default clipping region is a null region).
	/// </term>
	/// </item>
	/// <item>
	/// <term>RGN_DIFF</term>
	/// <term>
	/// The new clipping region combines the areas of the current clipping region with those areas excluded from the region identified by hrgn.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RGN_OR</term>
	/// <term>The new clipping region combines the current clipping region and the region identified by hrgn.</term>
	/// </item>
	/// <item>
	/// <term>RGN_XOR</term>
	/// <term>
	/// The new clipping region combines the current clipping region and the region identified by hrgn but excludes any overlapping areas.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>The return value specifies the new clipping region's complexity; it can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
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
	/// <term>An error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If an error occurs when this function is called, the previous clipping region for the specified device context is not affected.
	/// </para>
	/// <para>The <c>ExtSelectClipRgn</c> function assumes that the coordinates for the specified region are specified in device units.</para>
	/// <para>
	/// Only a copy of the region identified by the hrgn parameter is used. The region itself can be reused after this call or it can be deleted.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-extselectcliprgn int ExtSelectClipRgn( HDC hdc, HRGN hrgn, int
	// mode );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d222defe-2ef9-4622-b2e1-462a91cb1b0a")]
	public static extern RegionFlags ExtSelectClipRgn([In, AddAsMember] HDC hdc, [In, Optional] HRGN hrgn, RegionOp mode);

	/// <summary>
	/// The <c>GetClipBox</c> function retrieves the dimensions of the tightest bounding rectangle that can be drawn around the current
	/// visible area on the device. The visible area is defined by the current clipping region or clip path, as well as any overlapping windows.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lprect">A pointer to a RECT structure that is to receive the rectangle dimensions, in logical units.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the clipping box's complexity and can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
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
	/// <term>An error occurred.</term>
	/// </item>
	/// </list>
	/// <para><c>GetClipBox</c> returns logical coordinates based on the given device context.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getclipbox int GetClipBox( HDC hdc, LPRECT lprect );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "b4ee68ab-b99e-48b6-90ce-6d6c0ae144e2")]
	public static extern RegionFlags GetClipBox([In, AddAsMember] HDC hdc, out RECT lprect);

	/// <summary>
	/// The <c>GetClipRgn</c> function retrieves a handle identifying the current application-defined clipping region for the specified
	/// device context.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="hrgn">
	/// A handle to an existing region before the function is called. After the function returns, this parameter is a handle to a copy of
	/// the current clipping region.
	/// </param>
	/// <returns>
	/// If the function succeeds and there is no clipping region for the given device context, the return value is zero. If the function
	/// succeeds and there is a clipping region for the given device context, the return value is 1. If an error occurs, the return value
	/// is -1.
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application-defined clipping region is a clipping region identified by the SelectClipRgn function. It is not a clipping region
	/// created when the application calls the BeginPaint function.
	/// </para>
	/// <para>
	/// If the function succeeds, the hrgn parameter is a handle to a copy of the current clipping region. Subsequent changes to this
	/// copy will not affect the current clipping region.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcliprgn int GetClipRgn( HDC hdc, HRGN hrgn );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "66c807b8-129f-40f2-b8d8-995e0a5e22e4")]
	public static extern int GetClipRgn([In, AddAsMember] HDC hdc, [In, Out] HRGN hrgn);

	/// <summary>The <c>GetMetaRgn</c> function retrieves the current metaregion for the specified device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="hrgn">
	/// A handle to an existing region before the function is called. After the function returns, this parameter is a handle to a copy of
	/// the current metaregion.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the function succeeds, hrgn is a handle to a copy of the current metaregion. Subsequent changes to this copy will not affect
	/// the current metaregion.
	/// </para>
	/// <para>The current clipping region of a device context is defined by the intersection of its clipping region and its metaregion.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getmetargn int GetMetaRgn( HDC hdc, HRGN hrgn );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "9c2741cf-30e4-4100-bae9-ad99a7ae37f1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetMetaRgn([In, AddAsMember] HDC hdc, [In, Out] HRGN hrgn);

	/// <summary>The <c>GetRandomRgn</c> function copies the system clipping region of a specified device context to a specific region.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="hrgn">
	/// A handle to a region. Before the function is called, this identifies an existing region. After the function returns, this
	/// identifies a copy of the current system region. The old region identified by hrgn is overwritten.
	/// </param>
	/// <param name="i">This parameter must be SYSRGN.</param>
	/// <returns>
	/// If the function succeeds, the return value is 1. If the function fails, the return value is -1. If the region to be retrieved is
	/// <c>NULL</c>, the return value is 0. If the function fails or the region to be retrieved is <c>NULL</c>, hrgn is not initialized.
	/// </returns>
	/// <remarks>
	/// <para>
	/// When using the SYSRGN flag, note that the system clipping region might not be current because of window movements. Nonetheless,
	/// it is safe to retrieve and use the system clipping region within the BeginPaint-EndPaint block during WM_PAINT processing. In
	/// this case, the system region is the intersection of the update region and the current visible area of the window. Any window
	/// movement following the return of <c>GetRandomRgn</c> and before <c>EndPaint</c> will result in a new <c>WM_PAINT</c> message. Any
	/// other use of the SYSRGN flag may result in painting errors in your application.
	/// </para>
	/// <para>The region returned is in screen coordinates.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrandomrgn int GetRandomRgn( HDC hdc, HRGN hrgn, INT i );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "a7527d7a-7b5e-4dd5-9270-94bc92b5a4a0")]
	public static extern int GetRandomRgn([In, AddAsMember] HDC hdc, [In, Out, Optional] HRGN hrgn, int i = 4 /* SYSRGN */);

	/// <summary>
	/// The <c>IntersectClipRect</c> function creates a new clipping region from the intersection of the current clipping region and the
	/// specified rectangle.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="left">The x-coordinate, in logical units, of the upper-left corner of the rectangle.</param>
	/// <param name="top">The y-coordinate, in logical units, of the upper-left corner of the rectangle.</param>
	/// <param name="right">The x-coordinate, in logical units, of the lower-right corner of the rectangle.</param>
	/// <param name="bottom">The y-coordinate, in logical units, of the lower-right corner of the rectangle.</param>
	/// <returns>
	/// <para>The return value specifies the new clipping region's type and can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
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
	/// <term>An error occurred. (The current clipping region is unaffected.)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The lower and right-most edges of the given rectangle are excluded from the clipping region.</para>
	/// <para>
	/// If a clipping region does not already exist then the system may apply a default clipping region to the specified HDC. A clipping
	/// region is then created from the intersection of that default clipping region and the rectangle specified in the function parameters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-intersectcliprect int IntersectClipRect( HDC hdc, int left,
	// int top, int right, int bottom );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "9b3f9bfb-337b-45f0-b9ec-399e5f563638")]
	public static extern RegionFlags IntersectClipRect([In, AddAsMember] HDC hdc, int left, int top, int right, int bottom);

	/// <summary>The <c>OffsetClipRgn</c> function moves the clipping region of a device context by the specified offsets.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The number of logical units to move left or right.</param>
	/// <param name="y">The number of logical units to move up or down.</param>
	/// <returns>
	/// <para>The return value specifies the new region's complexity and can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
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
	/// <term>An error occurred. (The current clipping region is unaffected.)</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-offsetcliprgn int OffsetClipRgn( HDC hdc, int x, int y );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "332ab3f8-6ad3-4bbc-85a3-b0d2a4b07bc5")]
	public static extern RegionFlags OffsetClipRgn([In, AddAsMember] HDC hdc, int x, int y);

	/// <summary>The <c>PtVisible</c> function determines whether the specified point is within the clipping region of a device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The x-coordinate, in logical units, of the point.</param>
	/// <param name="y">The y-coordinate, in logical units, of the point.</param>
	/// <returns>
	/// <para>If the specified point is within the clipping region of the device context, the return value is <c>TRUE</c>(1).</para>
	/// <para>If the specified point is not within the clipping region of the device context, the return value is <c>FALSE</c>(0).</para>
	/// <para>If the <c>HDC</c> is not valid, the return value is (BOOL)-1.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-ptvisible BOOL PtVisible( HDC hdc, int x, int y );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "72ccbd0f-f85b-434d-b0fc-dbe26348a74d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PtVisible([In, AddAsMember] HDC hdc, int x, int y);

	/// <summary>
	/// The <c>RectVisible</c> function determines whether any part of the specified rectangle lies within the clipping region of a
	/// device context.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lprect">A pointer to a RECT structure that contains the logical coordinates of the specified rectangle.</param>
	/// <returns>
	/// <para>
	/// If the current transform does not have a rotation and the rectangle lies within the clipping region, the return value is
	/// <c>TRUE</c> (1).
	/// </para>
	/// <para>
	/// If the current transform does not have a rotation and the rectangle does not lie within the clipping region, the return value is
	/// <c>FALSE</c> (0).
	/// </para>
	/// <para>If the current transform has a rotation and the rectangle lies within the clipping region, the return value is 2.</para>
	/// <para>
	/// If the current transform has a rotation and the rectangle does not lie within the clipping region, the return value is 1.
	/// </para>
	/// <para>All other return values are considered error codes. If the any parameter is not valid, the return value is undefined.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-rectvisible BOOL RectVisible( HDC hdc, const RECT *lprect );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "990e9b22-0ce3-42b8-a87e-32fd2f2bc2fb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RectVisible([In, AddAsMember] HDC hdc, in RECT lprect);

	/// <summary>
	/// The <c>SelectClipPath</c> function selects the current path as a clipping region for a device context, combining the new region
	/// with any existing clipping region using the specified mode.
	/// </summary>
	/// <param name="hdc">A handle to the device context of the path.</param>
	/// <param name="mode">
	/// <para>The way to use the path. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RGN_AND</term>
	/// <term>The new clipping region includes the intersection (overlapping areas) of the current clipping region and the current path.</term>
	/// </item>
	/// <item>
	/// <term>RGN_COPY</term>
	/// <term>The new clipping region is the current path.</term>
	/// </item>
	/// <item>
	/// <term>RGN_DIFF</term>
	/// <term>The new clipping region includes the areas of the current clipping region with those of the current path excluded.</term>
	/// </item>
	/// <item>
	/// <term>RGN_OR</term>
	/// <term>The new clipping region includes the union (combined areas) of the current clipping region and the current path.</term>
	/// </item>
	/// <item>
	/// <term>RGN_XOR</term>
	/// <term>
	/// The new clipping region includes the union of the current clipping region and the current path but without the overlapping areas.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The device context identified by the hdc parameter must contain a closed path.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Using Clipping.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-selectclippath BOOL SelectClipPath( HDC hdc, int mode );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "c5102e1b-ba33-4cce-a4e5-93cf10c1c0bb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SelectClipPath([In, AddAsMember] HDC hdc, RegionOp mode);

	/// <summary>The <c>SelectClipRgn</c> function selects a region as the current clipping region for the specified device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="hrgn">A handle to the region to be selected.</param>
	/// <returns>
	/// <para>The return value specifies the region's complexity and can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
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
	/// <term>An error occurred. (The previous clipping region is unaffected.)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only a copy of the selected region is used. The region itself can be selected for any number of other device contexts or it can
	/// be deleted.
	/// </para>
	/// <para>The <c>SelectClipRgn</c> function assumes that the coordinates for a region are specified in device units.</para>
	/// <para>To remove a device-context's clipping region, specify a <c>NULL</c> region handle.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Clipping Output.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-selectcliprgn int SelectClipRgn( HDC hdc, HRGN hrgn );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "7a4f0b9c-8588-4da8-a030-ed9d8b4ee08d")]
	public static extern RegionFlags SelectClipRgn([In, AddAsMember] HDC hdc, [In, Optional] HRGN hrgn);

	/// <summary>
	/// The <c>SetMetaRgn</c> function intersects the current clipping region for the specified device context with the current
	/// metaregion and saves the combined region as the new metaregion for the specified device context. The clipping region is reset to
	/// a null region.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <returns>
	/// <para>The return value specifies the new clipping region's complexity and can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
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
	/// <term>An error occurred. (The previous clipping region is unaffected.)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The current clipping region of a device context is defined by the intersection of its clipping region and its metaregion.</para>
	/// <para>
	/// The <c>SetMetaRgn</c> function should only be called after an application's original device context was saved by calling the
	/// SaveDC function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setmetargn int SetMetaRgn( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "79f5dc01-bdec-4844-be94-1f9cf5bfd712")]
	public static extern RegionFlags SetMetaRgn([In, AddAsMember] HDC hdc);
}