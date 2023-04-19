using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Gdi32
{
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

	/// <summary>Bounds information.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "139d4550-9adc-48b3-a15c-03ae1f1ef1ab")]
	[Flags]
	public enum DCB
	{
		/// <summary>The bounding rectangle is empty.</summary>
		DCB_RESET = 0x0001,

		/// <summary>
		/// Adds the rectangle specified by the lprcBounds parameter to the bounding rectangle (using a rectangle union operation). Using
		/// both DCB_RESET and DCB_ACCUMULATE sets the bounding rectangle to the rectangle specified by the lprcBounds parameter.
		/// </summary>
		DCB_ACCUMULATE = 0x0002,

		/// <summary>Same as DCB_ACCUMULATE.</summary>
		DCB_DIRTY = DCB_ACCUMULATE,

		/// <summary>The bounding rectangle is not empty.</summary>
		DCB_SET = DCB_RESET | DCB_ACCUMULATE,

		/// <summary>Boundary accumulation is on.</summary>
		DCB_ENABLE = 0x0004,

		/// <summary>Boundary accumulation is off.</summary>
		DCB_DISABLE = 0x0008,
	}

	/// <summary>Foreground mix mode.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "ca1930e0-f6f4-44c8-979c-f50881f3c225")]
	public enum R2
	{
		/// <summary>Pixel is always 0.</summary>
		R2_BLACK = 1,

		/// <summary>Pixel is the inverse of the R2_MERGEPEN color.</summary>
		R2_NOTMERGEPEN = 2,

		/// <summary>Pixel is a combination of the colors common to both the screen and the inverse of the pen.</summary>
		R2_MASKNOTPEN = 3,

		/// <summary>Pixel is the inverse of the pen color.</summary>
		R2_NOTCOPYPEN = 4,

		/// <summary>Pixel is a combination of the colors common to both the pen and the inverse of the screen.</summary>
		R2_MASKPENNOT = 5,

		/// <summary>Pixel is the inverse of the screen color.</summary>
		R2_NOT = 6,

		/// <summary>Pixel is a combination of the colors in the pen and in the screen, but not in both.</summary>
		R2_XORPEN = 7,

		/// <summary>Pixel is the inverse of the R2_MASKPEN color.</summary>
		R2_NOTMASKPEN = 8,

		/// <summary>Pixel is a combination of the colors common to both the pen and the screen.</summary>
		R2_MASKPEN = 9,

		/// <summary>Pixel is the inverse of the R2_XORPEN color.</summary>
		R2_NOTXORPEN = 10,

		/// <summary>Pixel remains unchanged.</summary>
		R2_NOP = 11,

		/// <summary>Pixel is a combination of the screen color and the inverse of the pen color.</summary>
		R2_MERGENOTPEN = 12,

		/// <summary>Pixel is the pen color.</summary>
		R2_COPYPEN = 13,

		/// <summary>Pixel is a combination of the pen color and the inverse of the screen color.</summary>
		R2_MERGEPENNOT = 14,

		/// <summary>Pixel is a combination of the pen color and the screen color.</summary>
		R2_MERGEPEN = 15,

		/// <summary>Pixel is always 1.</summary>
		R2_WHITE = 16
	}

	/// <summary>The <c>GdiFlush</c> function flushes the calling thread's current batch.</summary>
	/// <returns>
	/// <para>If all functions in the current batch succeed, the return value is nonzero.</para>
	/// <para>
	/// If not all functions in the current batch succeed, the return value is zero, indicating that at least one function returned an error.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Batching enhances drawing performance by minimizing the amount of time needed to call GDI drawing functions that return Boolean
	/// values. The system accumulates the parameters for calls to these functions in the current batch and then calls the functions when
	/// the batch is flushed by any of the following means:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Calling the <c>GdiFlush</c> function.</term>
	/// </item>
	/// <item>
	/// <term>Reaching or exceeding the batch limit set by the GdiSetBatchLimit function.</term>
	/// </item>
	/// <item>
	/// <term>Filling the batching buffers.</term>
	/// </item>
	/// <item>
	/// <term>Calling any GDI function that does not return a Boolean value.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The return value for <c>GdiFlush</c> applies only to the functions in the batch at the time <c>GdiFlush</c> is called. Errors
	/// that occur when the batch is flushed by any other means are never reported.
	/// </para>
	/// <para>The GdiGetBatchLimit function returns the batch limit.</para>
	/// <para>
	/// <c>Note</c> The batch limit is maintained for each thread separately. In order to completely disable batching, call
	/// GdiSetBatchLimit (1) during the initialization of each thread.
	/// </para>
	/// <para>
	/// An application should call <c>GdiFlush</c> before a thread goes away if there is a possibility that there are pending function
	/// calls in the graphics batch queue. The system does not execute such batched functions when a thread goes away.
	/// </para>
	/// <para>
	/// A multithreaded application that serializes access to GDI objects with a mutex must ensure flushing the GDI batch queue by
	/// calling <c>GdiFlush</c> as each thread releases ownership of the GDI object. This prevents collisions of the GDI objects (device
	/// contexts, metafiles, and so on).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdiflush BOOL GdiFlush( );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "6d2f398d-7a30-4b14-81de-23ab10e1749c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiFlush();

	/// <summary>
	/// The <c>GdiGetBatchLimit</c> function returns the maximum number of function calls that can be accumulated in the calling thread's
	/// current batch. The system flushes the current batch whenever this limit is exceeded.
	/// </summary>
	/// <returns>
	/// <para>If the function succeeds, the return value is the batch limit.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The batch limit is set by using the GdiSetBatchLimit function. Setting the limit to 1 effectively disables batching.</para>
	/// <para>
	/// Only GDI drawing functions that return Boolean values can be batched; calls to any other GDI functions immediately flush the
	/// current batch. Exceeding the batch limit or calling the GdiFlush function also flushes the current batch.
	/// </para>
	/// <para>
	/// When the system batches a function call, the function returns <c>TRUE</c>. The actual return value for the function is reported
	/// only if GdiFlush is used to flush the batch.
	/// </para>
	/// <para>
	/// <c>Note</c> The batch limit is maintained for each thread separately. In order to completely disable batching, call
	/// GdiSetBatchLimit (1) during the initialization of each thread.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdigetbatchlimit DWORD GdiGetBatchLimit( );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "aafe7635-1a71-42a9-90b7-11179e245af4")]
	public static extern uint GdiGetBatchLimit();

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
	/// The <c>GdiGradientFill</c> function uses a mesh method to specify the endpoints of the object to draw. All vertices are passed
	/// to <c>GdiGradientFill</c> in the pVertex array. The pMesh parameter specifies how these vertices are connected to form an
	/// object. When filling a rectangle, pMesh points to an array of GRADIENT_RECT structures. Each <c>GRADIENT_RECT</c> structure
	/// specifies the index of two vertices in the pVertex array. These two vertices form the upper-left and lower-right boundary of one rectangle.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdigradientfill
	// BOOL GdiGradientFill( HDC hdc, PTRIVERTEX pVertex, ULONG nVertex, PVOID pMesh, ULONG nCount, ULONG ulMode );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "c88c1137-5690-4139-9d10-90d036e8f31c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiGradientFill(HDC hdc, in TRIVERTEX pVertex, uint nVertex, IntPtr pMesh, uint nCount, GradientFillMode ulMode);

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
	/// The <c>GdiGradientFill</c> function uses a mesh method to specify the endpoints of the object to draw. All vertices are passed
	/// to <c>GdiGradientFill</c> in the pVertex array. The pMesh parameter specifies how these vertices are connected to form an
	/// object. When filling a rectangle, pMesh points to an array of GRADIENT_RECT structures. Each <c>GRADIENT_RECT</c> structure
	/// specifies the index of two vertices in the pVertex array. These two vertices form the upper-left and lower-right boundary of one rectangle.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdigradientfill
	// BOOL GdiGradientFill( HDC hdc, PTRIVERTEX pVertex, ULONG nVertex, PVOID pMesh, ULONG nCount, ULONG ulMode );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "c88c1137-5690-4139-9d10-90d036e8f31c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiGradientFill(HDC hdc, in TRIVERTEX pVertex, uint nVertex, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] GRADIENT_TRIANGLE[] pMesh, uint nCount, GradientFillMode ulMode);

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
	/// The <c>GdiGradientFill</c> function uses a mesh method to specify the endpoints of the object to draw. All vertices are passed
	/// to <c>GdiGradientFill</c> in the pVertex array. The pMesh parameter specifies how these vertices are connected to form an
	/// object. When filling a rectangle, pMesh points to an array of GRADIENT_RECT structures. Each <c>GRADIENT_RECT</c> structure
	/// specifies the index of two vertices in the pVertex array. These two vertices form the upper-left and lower-right boundary of one rectangle.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdigradientfill
	// BOOL GdiGradientFill( HDC hdc, PTRIVERTEX pVertex, ULONG nVertex, PVOID pMesh, ULONG nCount, ULONG ulMode );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "c88c1137-5690-4139-9d10-90d036e8f31c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiGradientFill(HDC hdc, in TRIVERTEX pVertex, uint nVertex, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] GRADIENT_RECT[] pMesh, uint nCount, GradientFillMode ulMode);

	/// <summary>
	/// The <c>GdiSetBatchLimit</c> function sets the maximum number of function calls that can be accumulated in the calling thread's
	/// current batch. The system flushes the current batch whenever this limit is exceeded.
	/// </summary>
	/// <param name="dw">Specifies the batch limit to be set. A value of 0 sets the default limit. A value of 1 disables batching.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the previous batch limit.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only GDI drawing functions that return Boolean values can be accumulated in the current batch; calls to any other GDI functions
	/// immediately flush the current batch. Exceeding the batch limit or calling the GdiFlush function also flushes the current batch.
	/// </para>
	/// <para>
	/// When the system accumulates a function call, the function returns <c>TRUE</c> to indicate it is in the batch. When the system
	/// flushes the current batch and executes the function for the second time, the return value is either <c>TRUE</c> or <c>FALSE</c>,
	/// depending on whether the function succeeds. This second return value is reported only if GdiFlush is used to flush the batch.
	/// </para>
	/// <para>
	/// <c>Note</c> The batch limit is maintained for each thread separately. In order to completely disable batching, call
	/// <c>GdiSetBatchLimit</c> (1) during the initialization of each thread.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdisetbatchlimit DWORD GdiSetBatchLimit( DWORD dw );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "53bf0dfe-e93c-401d-ac5d-6717bad2625e")]
	public static extern uint GdiSetBatchLimit(uint dw);

	/// <summary>The <c>GetBkColor</c> function returns the current background color for the specified device context.</summary>
	/// <param name="hdc">Handle to the device context whose background color is to be returned.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a COLORREF value for the current background color.</para>
	/// <para>If the function fails, the return value is CLR_INVALID.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getbkcolor COLORREF GetBkColor( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "1c6e8d05-4b8d-476d-852c-f06f316cb8b7")]
	public static extern COLORREF GetBkColor(HDC hdc);

	/// <summary>
	/// The <c>GetBkMode</c> function returns the current background mix mode for a specified device context. The background mix mode of
	/// a device context affects text, hatched brushes, and pen styles that are not solid lines.
	/// </summary>
	/// <param name="hdc">Handle to the device context whose background mode is to be returned.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the current background mix mode, either OPAQUE or TRANSPARENT.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getbkmode int GetBkMode( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3faedb48-3163-48fd-b26e-712de9c4bfaf")]
	public static extern BackgroundMode GetBkMode(HDC hdc);

	/// <summary>
	/// <para>The <c>GetBoundsRect</c> function obtains the current accumulated bounding rectangle for a specified device context.</para>
	/// <para>
	/// The system maintains an accumulated bounding rectangle for each application. An application can retrieve and set this rectangle.
	/// </para>
	/// </summary>
	/// <param name="hdc">A handle to the device context whose bounding rectangle the function will return.</param>
	/// <param name="lprect">
	/// A pointer to the RECT structure that will receive the current bounding rectangle. The application's rectangle is returned in
	/// logical coordinates, and the bounding rectangle is returned in screen coordinates.
	/// </param>
	/// <param name="flags">
	/// <para>Specifies how the <c>GetBoundsRect</c> function will behave. This parameter can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DCB_RESET</term>
	/// <term>Clears the bounding rectangle after returning it. If this flag is not set, the bounding rectangle will not be cleared.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>The return value specifies the state of the accumulated bounding rectangle; it can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>An error occurred. The specified device context handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>DCB_DISABLE</term>
	/// <term>Boundary accumulation is off.</term>
	/// </item>
	/// <item>
	/// <term>DCB_ENABLE</term>
	/// <term>Boundary accumulation is on.</term>
	/// </item>
	/// <item>
	/// <term>DCB_RESET</term>
	/// <term>The bounding rectangle is empty.</term>
	/// </item>
	/// <item>
	/// <term>DCB_SET</term>
	/// <term>The bounding rectangle is not empty.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The DCB_SET value is a combination of the bit values DCB_ACCUMULATE and DCB_RESET. Applications that check the DCB_RESET bit to
	/// determine whether the bounding rectangle is empty must also check the DCB_ACCUMULATE bit. The bounding rectangle is empty only if
	/// the DCB_RESET bit is 1 and the DCB_ACCUMULATE bit is 0.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getboundsrect UINT GetBoundsRect( HDC hdc, LPRECT lprect, UINT
	// flags );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "139d4550-9adc-48b3-a15c-03ae1f1ef1ab")]
	public static extern DCB GetBoundsRect(HDC hdc, out RECT lprect, [Optional] DCB flags);

	/// <summary>
	/// The <c>GetROP2</c> function retrieves the foreground mix mode of the specified device context. The mix mode specifies how the pen
	/// or interior color and the color already on the screen are combined to yield a new color.
	/// </summary>
	/// <param name="hdc">Handle to the device context.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the foreground mix mode.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>Following are the foreground mix modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mix mode</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>R2_BLACK</term>
	/// <term>Pixel is always 0.</term>
	/// </item>
	/// <item>
	/// <term>R2_COPYPEN</term>
	/// <term>Pixel is the pen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_MASKNOTPEN</term>
	/// <term>Pixel is a combination of the colors common to both the screen and the inverse of the pen.</term>
	/// </item>
	/// <item>
	/// <term>R2_MASKPEN</term>
	/// <term>Pixel is a combination of the colors common to both the pen and the screen.</term>
	/// </item>
	/// <item>
	/// <term>R2_MASKPENNOT</term>
	/// <term>Pixel is a combination of the colors common to both the pen and the inverse of the screen.</term>
	/// </item>
	/// <item>
	/// <term>R2_MERGENOTPEN</term>
	/// <term>Pixel is a combination of the screen color and the inverse of the pen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_MERGEPEN</term>
	/// <term>Pixel is a combination of the pen color and the screen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_MERGEPENNOT</term>
	/// <term>Pixel is a combination of the pen color and the inverse of the screen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOP</term>
	/// <term>Pixel remains unchanged.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOT</term>
	/// <term>Pixel is the inverse of the screen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOTCOPYPEN</term>
	/// <term>Pixel is the inverse of the pen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOTMASKPEN</term>
	/// <term>Pixel is the inverse of the R2_MASKPEN color.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOTMERGEPEN</term>
	/// <term>Pixel is the inverse of the R2_MERGEPEN color.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOTXORPEN</term>
	/// <term>Pixel is the inverse of the R2_XORPEN color.</term>
	/// </item>
	/// <item>
	/// <term>R2_WHITE</term>
	/// <term>Pixel is always 1.</term>
	/// </item>
	/// <item>
	/// <term>R2_XORPEN</term>
	/// <term>Pixel is a combination of the colors in the pen and in the screen, but not in both.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrop2 int GetROP2( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "ca1930e0-f6f4-44c8-979c-f50881f3c225")]
	public static extern R2 GetROP2(HDC hdc);

	/// <summary>
	/// The <c>SetBkColor</c> function sets the current background color to the specified color value, or to the nearest physical color
	/// if the device cannot represent the specified color value.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="color">The new background color. To make a COLORREF value, use the RGB macro.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the previous background color as a COLORREF value.</para>
	/// <para>If the function fails, the return value is CLR_INVALID.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function fills the gaps between styled lines drawn using a pen created by the CreatePen function; it does not fill the gaps
	/// between styled lines drawn using a pen created by the ExtCreatePen function. The <c>SetBkColor</c> function also sets the
	/// background colors for TextOut and ExtTextOut.
	/// </para>
	/// <para>
	/// If the background mode is OPAQUE, the background color is used to fill gaps between styled lines, gaps between hatched lines in
	/// brushes, and character cells. The background color is also used when converting bitmaps from color to monochrome and vice versa.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see "Example of Owner-Drawn Menu Items" in Using Menus.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setbkcolor COLORREF SetBkColor( HDC hdc, COLORREF color );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "9163370b-19c5-4c23-9197-793e4b8d50c4")]
	public static extern COLORREF SetBkColor(HDC hdc, COLORREF color);

	/// <summary>
	/// The <c>SetBkMode</c> function sets the background mix mode of the specified device context. The background mix mode is used with
	/// text, hatched brushes, and pen styles that are not solid lines.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="mode">
	/// <para>The background mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>OPAQUE</term>
	/// <term>Background is filled with the current background color before the text, hatched brush, or pen is drawn.</term>
	/// </item>
	/// <item>
	/// <term>TRANSPARENT</term>
	/// <term>Background remains untouched.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the previous background mode.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SetBkMode</c> function affects the line styles for lines drawn using a pen created by the CreatePen function.
	/// <c>SetBkMode</c> does not affect lines drawn using a pen created by the ExtCreatePen function.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// To see how to make the background of a hatch brush transparent or opaque, refer to the example shown in the CreateHatchBrush topic.
	/// </para>
	/// <para>
	/// The next example draws a string 36 times, rotating it 10 degrees counterclockwise each time. It also sets the background mode to
	/// transparent to make the text visible.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setbkmode int SetBkMode( HDC hdc, int mode );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "60e4467a-14ab-421e-b174-4b9c0134ce72")]
	public static extern BackgroundMode SetBkMode(HDC hdc, BackgroundMode mode);

	/// <summary>
	/// The <c>SetBoundsRect</c> function controls the accumulation of bounding rectangle information for the specified device context.
	/// The system can maintain a bounding rectangle for all drawing operations. An application can examine and set this rectangle. The
	/// drawing boundaries are useful for invalidating bitmap caches.
	/// </summary>
	/// <param name="hdc">A handle to the device context for which to accumulate bounding rectangles.</param>
	/// <param name="lprect">
	/// A pointer to a RECT structure used to set the bounding rectangle. Rectangle dimensions are in logical coordinates. This parameter
	/// can be <c>NULL</c>.
	/// </param>
	/// <param name="flags">
	/// <para>
	/// Specifies how the new rectangle will be combined with the accumulated rectangle. This parameter can be one of more of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DCB_ACCUMULATE</term>
	/// <term>
	/// Adds the rectangle specified by the lprcBounds parameter to the bounding rectangle (using a rectangle union operation). Using
	/// both DCB_RESET and DCB_ACCUMULATE sets the bounding rectangle to the rectangle specified by the lprcBounds parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DCB_DISABLE</term>
	/// <term>Turns off boundary accumulation.</term>
	/// </item>
	/// <item>
	/// <term>DCB_ENABLE</term>
	/// <term>Turns on boundary accumulation, which is disabled by default.</term>
	/// </item>
	/// <item>
	/// <term>DCB_RESET</term>
	/// <term>Clears the bounding rectangle.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value specifies the previous state of the bounding rectangle. This state can be a
	/// combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DCB_DISABLE</term>
	/// <term>Boundary accumulation is off.</term>
	/// </item>
	/// <item>
	/// <term>DCB_ENABLE</term>
	/// <term>Boundary accumulation is on. DCB_ENABLE and DCB_DISABLE are mutually exclusive.</term>
	/// </item>
	/// <item>
	/// <term>DCB_RESET</term>
	/// <term>Bounding rectangle is empty.</term>
	/// </item>
	/// <item>
	/// <term>DCB_SET</term>
	/// <term>Bounding rectangle is not empty. DCB_SET and DCB_RESET are mutually exclusive.</term>
	/// </item>
	/// </list>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The DCB_SET value is a combination of the bit values DCB_ACCUMULATE and DCB_RESET. Applications that check the DCB_RESET bit to
	/// determine whether the bounding rectangle is empty must also check the DCB_ACCUMULATE bit. The bounding rectangle is empty only if
	/// the DCB_RESET bit is 1 and the DCB_ACCUMULATE bit is 0.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setboundsrect UINT SetBoundsRect( HDC hdc, const RECT *lprect,
	// UINT flags );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "ad361e78-42e8-4945-9395-fab983e396df")]
	public static extern DCB SetBoundsRect(HDC hdc, in RECT lprect, DCB flags);

	/// <summary>
	/// The <c>SetBoundsRect</c> function controls the accumulation of bounding rectangle information for the specified device context.
	/// The system can maintain a bounding rectangle for all drawing operations. An application can examine and set this rectangle. The
	/// drawing boundaries are useful for invalidating bitmap caches.
	/// </summary>
	/// <param name="hdc">A handle to the device context for which to accumulate bounding rectangles.</param>
	/// <param name="lprect">
	/// A pointer to a RECT structure used to set the bounding rectangle. Rectangle dimensions are in logical coordinates. This parameter
	/// can be <c>NULL</c>.
	/// </param>
	/// <param name="flags">
	/// <para>
	/// Specifies how the new rectangle will be combined with the accumulated rectangle. This parameter can be one of more of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DCB_ACCUMULATE</term>
	/// <term>
	/// Adds the rectangle specified by the lprcBounds parameter to the bounding rectangle (using a rectangle union operation). Using
	/// both DCB_RESET and DCB_ACCUMULATE sets the bounding rectangle to the rectangle specified by the lprcBounds parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DCB_DISABLE</term>
	/// <term>Turns off boundary accumulation.</term>
	/// </item>
	/// <item>
	/// <term>DCB_ENABLE</term>
	/// <term>Turns on boundary accumulation, which is disabled by default.</term>
	/// </item>
	/// <item>
	/// <term>DCB_RESET</term>
	/// <term>Clears the bounding rectangle.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value specifies the previous state of the bounding rectangle. This state can be a
	/// combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DCB_DISABLE</term>
	/// <term>Boundary accumulation is off.</term>
	/// </item>
	/// <item>
	/// <term>DCB_ENABLE</term>
	/// <term>Boundary accumulation is on. DCB_ENABLE and DCB_DISABLE are mutually exclusive.</term>
	/// </item>
	/// <item>
	/// <term>DCB_RESET</term>
	/// <term>Bounding rectangle is empty.</term>
	/// </item>
	/// <item>
	/// <term>DCB_SET</term>
	/// <term>Bounding rectangle is not empty. DCB_SET and DCB_RESET are mutually exclusive.</term>
	/// </item>
	/// </list>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The DCB_SET value is a combination of the bit values DCB_ACCUMULATE and DCB_RESET. Applications that check the DCB_RESET bit to
	/// determine whether the bounding rectangle is empty must also check the DCB_ACCUMULATE bit. The bounding rectangle is empty only if
	/// the DCB_RESET bit is 1 and the DCB_ACCUMULATE bit is 0.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setboundsrect UINT SetBoundsRect( HDC hdc, const RECT *lprect,
	// UINT flags );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "ad361e78-42e8-4945-9395-fab983e396df")]
	public static extern DCB SetBoundsRect(HDC hdc, [Optional] IntPtr lprect, DCB flags);

	/// <summary>
	/// The <c>SetROP2</c> function sets the current foreground mix mode. GDI uses the foreground mix mode to combine pens and interiors
	/// of filled objects with the colors already on the screen. The foreground mix mode defines how colors from the brush or pen and the
	/// colors in the existing image are to be combined.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="rop2">
	/// <para>The mix mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mix mode</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>R2_BLACK</term>
	/// <term>Pixel is always 0.</term>
	/// </item>
	/// <item>
	/// <term>R2_COPYPEN</term>
	/// <term>Pixel is the pen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_MASKNOTPEN</term>
	/// <term>Pixel is a combination of the colors common to both the screen and the inverse of the pen.</term>
	/// </item>
	/// <item>
	/// <term>R2_MASKPEN</term>
	/// <term>Pixel is a combination of the colors common to both the pen and the screen.</term>
	/// </item>
	/// <item>
	/// <term>R2_MASKPENNOT</term>
	/// <term>Pixel is a combination of the colors common to both the pen and the inverse of the screen.</term>
	/// </item>
	/// <item>
	/// <term>R2_MERGENOTPEN</term>
	/// <term>Pixel is a combination of the screen color and the inverse of the pen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_MERGEPEN</term>
	/// <term>Pixel is a combination of the pen color and the screen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_MERGEPENNOT</term>
	/// <term>Pixel is a combination of the pen color and the inverse of the screen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOP</term>
	/// <term>Pixel remains unchanged.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOT</term>
	/// <term>Pixel is the inverse of the screen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOTCOPYPEN</term>
	/// <term>Pixel is the inverse of the pen color.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOTMASKPEN</term>
	/// <term>Pixel is the inverse of the R2_MASKPEN color.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOTMERGEPEN</term>
	/// <term>Pixel is the inverse of the R2_MERGEPEN color.</term>
	/// </item>
	/// <item>
	/// <term>R2_NOTXORPEN</term>
	/// <term>Pixel is the inverse of the R2_XORPEN color.</term>
	/// </item>
	/// <item>
	/// <term>R2_WHITE</term>
	/// <term>Pixel is always 1.</term>
	/// </item>
	/// <item>
	/// <term>R2_XORPEN</term>
	/// <term>Pixel is a combination of the colors in the pen and in the screen, but not in both.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the previous mix mode.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Mix modes define how GDI combines source and destination colors when drawing with the current pen. The mix modes are binary
	/// raster operation codes, representing all possible Boolean functions of two variables, using the binary operations AND, OR, and
	/// XOR (exclusive OR), and the unary operation NOT. The mix mode is for raster devices only; it is not available for vector devices.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Using Rectangles.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setrop2 int SetROP2( HDC hdc, int rop2 );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "a462a03d-e2c8-403e-aab4-ae03fb96f06f")]
	public static extern R2 SetROP2(HDC hdc, R2 rop2);
}