using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke;

public static partial class UxTheme
{
	/// <summary>Used in the BP_ANIMATIONPARAMS structure to declare animation options.</summary>
	[PInvokeData("UxTheme.h")]
	[Flags]
	public enum BP_ANIMATIONSTYLE
	{
		/// <summary>No animation. Not implemented in Windows Vista.</summary>
		BPAS_NONE,

		/// <summary>Linear fade animation.</summary>
		BPAS_LINEAR,

		/// <summary>Cubic fade animation. Not implemented in Windows Vista.</summary>
		BPAS_CUBIC,

		/// <summary>Sinusoid fade animation. Not implemented in Windows Vista.</summary>
		BPAS_SINE
	}

	/// <summary>Specifies the format of the buffer. Used by BeginBufferedAnimation and BeginBufferedPaint.</summary>
	[PInvokeData("UxTheme.h")]
	public enum BP_BUFFERFORMAT
	{
		/// <summary>
		/// Compatible bitmap. The number of bits per pixel is based on the color format of the device associated with the HDC specified
		/// with BeginBufferedPaint or BeginBufferedAnimation—typically, this is the display device.
		/// </summary>
		BPBF_COMPATIBLEBITMAP,

		/// <summary>Bottom-up device-independent bitmap. The origin of the bitmap is the lower-left corner. Uses 32 bits per pixel.</summary>
		BPBF_DIB,

		/// <summary>Top-down device-independent bitmap. The origin of the bitmap is the upper-left corner. Uses 32 bits per pixel.</summary>
		BPBF_TOPDOWNDIB,

		/// <summary>Top-down, monochrome, device-independent bitmap. Uses 1 bit per pixel.</summary>
		BPBF_TOPDOWNMONODIB
	}

	/// <summary>Used in BP_PAINTPARAMS</summary>
	[PInvokeData("UxTheme.h")]
	[Flags]
	public enum BufferedPaintParamsFlags
	{
		/// <summary>No flag.</summary>
		BPPF_NONE = 0,

		/// <summary>
		/// Initialize the buffer to ARGB = {0, 0, 0, 0} during BeginBufferedPaint. This erases the previous contents of the buffer.
		/// </summary>
		BPPF_ERASE = 1,

		/// <summary>
		/// Do not apply the clip region of the target DC to the double buffer. If this flag is not set and if the target DC is a window
		/// DC, then clipping due to overlapping windows is applied to the double buffer.
		/// </summary>
		BPPF_NOCLIP = 2,

		/// <summary>A non-client DC is being used.</summary>
		BPPF_NONCLIENT = 4,
	}

	/// <summary>
	/// Begins a buffered animation operation. The animation consists of a cross-fade between the contents of two buffers over a
	/// specified period of time.
	/// </summary>
	/// <param name="hwnd">
	/// <para>Type: <c><c>HWND</c></c></para>
	/// <para>A handle to the window in which the animations play.</para>
	/// </param>
	/// <param name="hdcTarget">
	/// <para>Type: <c><c>HDC</c></c></para>
	/// <para>A handle of the target DC on which the buffer is animated.</para>
	/// </param>
	/// <param name="rcTarget">
	/// <para>Type: <c>const <c>RECT</c>*</c></para>
	/// <para>A pointer to a structure that specifies the area of the target DC in which to draw.</para>
	/// </param>
	/// <param name="dwFormat">
	/// <para>Type: <c><c>BP_BUFFERFORMAT</c></c></para>
	/// <para>The format of the buffer.</para>
	/// </param>
	/// <param name="pPaintParams">
	/// <para>Type: <c><c>BP_PAINTPARAMS</c>*</c></para>
	/// <para>A pointer to a structure that defines the paint operation parameters. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pAnimationParams">
	/// <para>Type: <c><c>BP_ANIMATIONPARAMS</c>*</c></para>
	/// <para>A pointer to a structure that defines the animation operation parameters.</para>
	/// </param>
	/// <param name="phdcFrom">
	/// <para>Type: <c><c>HDC</c>*</c></para>
	/// <para>
	/// When this function returns, this value points to the handle of the DC where the application should paint the initial state of the
	/// animation, if not <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="phdcTo">
	/// <para>Type: <c><c>HDC</c>*</c></para>
	/// <para>
	/// When this function returns, this value points to the handle of the DC where the application should paint the final state of the
	/// animation, if not <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HANIMATIONBUFFER</c></para>
	/// <para>A handle to the buffered paint animation.</para>
	/// </returns>
	// HANIMATIONBUFFER BeginBufferedAnimation( HWND hwnd, HDC hdcTarget, const RECT *rcTarget, BP_BUFFERFORMAT dwFormat, _In_
	// BP_PAINTPARAMS *pPaintParams, _In_ BP_ANIMATIONPARAMS *pAnimationParams, _Out_ HDC *phdcFrom, _Out_ HDC *phdcTo); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773252(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773252")]
	public static extern SafeHANIMATIONBUFFER BeginBufferedAnimation(HWND hwnd, HDC hdcTarget, in RECT rcTarget, BP_BUFFERFORMAT dwFormat,
		[In] BP_PAINTPARAMS pPaintParams, in BP_ANIMATIONPARAMS pAnimationParams, out HDC phdcFrom, out HDC phdcTo);

	/// <summary>Begins a buffered paint operation.</summary>
	/// <param name="hdcTarget">
	/// <para>Type: <c><c>HDC</c></c></para>
	/// <para>The handle of the target DC on which the buffer will be painted.</para>
	/// </param>
	/// <param name="prcTarget">
	/// <para>Type: <c>const <c>RECT</c>*</c></para>
	/// <para>A pointer to a <c>RECT</c> structure that specifies the area of the target DC in which to paint.</para>
	/// </param>
	/// <param name="dwFormat">
	/// <para>Type: <c><c>BP_BUFFERFORMAT</c></c></para>
	/// <para>A member of the <c>BP_BUFFERFORMAT</c> enumeration that specifies the format of the buffer.</para>
	/// </param>
	/// <param name="pPaintParams">
	/// <para>Type: <c><c>BP_PAINTPARAMS</c>*</c></para>
	/// <para>A pointer to a <c>BP_PAINTPARAMS</c> structure that defines the paint operation parameters. This value can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="phdc">
	/// <para>Type: <c><c>HDC</c>*</c></para>
	/// <para>When this function returns, points to the handle of the new device context.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HPAINTBUFFER</c></para>
	/// <para>
	/// A handle to the buffered paint context. If this function fails, the return value is <c>NULL</c>, and phdc is <c>NULL</c>. To get
	/// extended error information, call <c>GetLastError</c>.
	/// </para>
	/// <para>The returned handle is freed when <c>EndBufferedPaint</c> is called.</para>
	/// <para>
	/// An application should call <c>BufferedPaintInit</c> on the calling thread before calling <c>BeginBufferedPaint</c>, and
	/// <c>BufferedPaintUnInit</c> before the thread is terminated. Failure to call <c>BufferedPaintInit</c> may result in degraded
	/// performance due to internal data being initialized and destroyed for each buffered paint operation.
	/// </para>
	/// </returns>
	// HPAINTBUFFER BeginBufferedPaint( HDC hdcTarget, const RECT *prcTarget, BP_BUFFERFORMAT dwFormat, _In_ BP_PAINTPARAMS
	// *pPaintParams, _Out_ HDC *phdc); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773257(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773257")]
	public static extern SafeHPAINTBUFFER BeginBufferedPaint(HDC hdcTarget, in RECT prcTarget, BP_BUFFERFORMAT dwFormat, [In] BP_PAINTPARAMS pPaintParams, out HDC phdc);

	/// <summary>Clears a specified rectangle in the buffer to ARGB = {0,0,0,0}.</summary>
	/// <param name="hBufferedPaint">
	/// <para>Type: <c>HPAINTBUFFER</c></para>
	/// <para>The handle of the buffered paint context, obtained through <c>BeginBufferedPaint</c>.</para>
	/// </param>
	/// <param name="prc">
	/// <para>Type: <c>const <c>RECT</c>*</c></para>
	/// <para>
	/// A pointer to a <c>RECT</c> structure that specifies the rectangle to clear. Set this parameter to <c>NULL</c> to specify the
	/// entire buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// HRESULT BufferedPaintClear( HPAINTBUFFER hBufferedPaint, _In_ const RECT *prc); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773262(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773262")]
	public static extern HRESULT BufferedPaintClear(HPAINTBUFFER hBufferedPaint, in RECT prc);

	/// <summary>Initialize buffered painting for the current thread.</summary>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// HRESULT BufferedPaintInit(void); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773266(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773266")]
	public static extern HRESULT BufferedPaintInit();

	/// <summary>Paints the next frame of a buffered paint animation.</summary>
	/// <param name="hwnd">
	/// <para>Type: <c><c>HWND</c></c></para>
	/// <para>Handle to the window in which the animations play.</para>
	/// </param>
	/// <param name="hdcTarget">
	/// <para>Type: <c><c>HDC</c></c></para>
	/// <para>Handle of the target DC on which the buffer is animated.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> if the frame has been painted, or <c>FALSE</c> otherwise.</para>
	/// </returns>
	// BOOL BufferedPaintRenderAnimation( HWND hwnd, HDC hdcTarget); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773271(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773271")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BufferedPaintRenderAnimation(HWND hwnd, HDC hdcTarget);

	/// <summary>
	/// Sets the alpha to a specified value in a given rectangle. The alpha controls the amount of transparency applied when blending
	/// with the buffer onto the destination target device context (DC).
	/// </summary>
	/// <param name="hBufferedPaint">
	/// <para>Type: <c>HPAINTBUFFER</c></para>
	/// <para>The handle of the buffered paint context, obtained through <c>BeginBufferedPaint</c>.</para>
	/// </param>
	/// <param name="prc">
	/// <para>Type: <c>const <c>RECT</c>*</c></para>
	/// <para>
	/// A pointer to a <c>RECT</c> structure that specifies the rectangle in which to set the alpha. Set this parameter to <c>NULL</c> to
	/// specify the entire buffer.
	/// </para>
	/// </param>
	/// <param name="alpha">
	/// <para>Type: <c><c>BYTE</c></c></para>
	/// <para>The alpha value to set. The alpha value can range from zero (fully transparent) to 255 (fully opaque).</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// HRESULT BufferedPaintSetAlpha( HPAINTBUFFER hBufferedPaint, _In_ const RECT *prc, BYTE alpha); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773276(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773276")]
	public static extern HRESULT BufferedPaintSetAlpha(HPAINTBUFFER hBufferedPaint, in RECT prc, byte alpha);

	/// <summary>Stops all buffered animations for the given window.</summary>
	/// <param name="hwnd">
	/// <para>Type: <c><c>HWND</c></c></para>
	/// <para>The handle of the window in which to stop all animations.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// HRESULT BufferedPaintStopAllAnimations( HWND hwnd); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773280(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773280")]
	public static extern HRESULT BufferedPaintStopAllAnimations(HWND hwnd);

	/// <summary>
	/// Closes down buffered painting for the current thread. Called once for each call to <c>BufferedPaintInit</c> after calls to
	/// <c>BeginBufferedPaint</c> are no longer needed.
	/// </summary>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// HRESULT BufferedPaintUnInit(void); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773284(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773284")]
	public static extern HRESULT BufferedPaintUnInit();

	/// <summary>Renders the first frame of a buffered animation operation and starts the animation timer.</summary>
	/// <param name="hbpAnimation">
	/// <para>Type: <c>HANIMATIONBUFFER</c></para>
	/// <para>The handle to the buffered animation context that was returned by <c>BeginBufferedAnimation</c>.</para>
	/// </param>
	/// <param name="fUpdateTarget">
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>
	/// If <c>TRUE</c>, updates the target DC with the animation. If <c>FALSE</c>, the animation is not started, the target DC is not
	/// updated, and the hbpAnimation parameter is freed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// HRESULT EndBufferedAnimation( HANIMATIONBUFFER hbpAnimation, BOOL fUpdateTarget); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773328(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773328")]
	public static extern HRESULT EndBufferedAnimation(HANIMATIONBUFFER hbpAnimation, [MarshalAs(UnmanagedType.Bool)] bool fUpdateTarget);

	/// <summary>Completes a buffered paint operation and frees the associated buffered paint handle.</summary>
	/// <param name="hBufferedPaint">
	/// <para>Type: <c>HPAINTBUFFER</c></para>
	/// <para>The handle of the buffered paint context, obtained through <c>BeginBufferedPaint</c>.</para>
	/// </param>
	/// <param name="fUpdateTarget">
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para><c>TRUE</c> to copy the buffer to the target DC.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// HRESULT EndBufferedPaint( HPAINTBUFFER hBufferedPaint, BOOL fUpdateTarget); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773343(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773343")]
	public static extern HRESULT EndBufferedPaint(HPAINTBUFFER hBufferedPaint, [MarshalAs(UnmanagedType.Bool)] bool fUpdateTarget);

	/// <summary>Retrieves a pointer to the buffer bitmap if the buffer is a device-independent bitmap (DIB).</summary>
	/// <param name="hBufferedPaint">
	/// <para>Type: <c>HPAINTBUFFER</c></para>
	/// <para>The handle of the buffered paint context, obtained through <c>BeginBufferedPaint</c>.</para>
	/// </param>
	/// <param name="ppbBuffer">
	/// <para>Type: <c><c>RGBQUAD</c>**</c></para>
	/// <para>When this function returns, contains a pointer to the address of the buffer bitmap pixels.</para>
	/// </param>
	/// <param name="pcxRow">
	/// <para>Type: <c>int*</c></para>
	/// <para>
	/// When this function returns, contains a pointer to the width, in pixels, of the buffer bitmap. This value is not necessarily equal
	/// to the buffer width. It may be larger.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>
	/// Returns S_OK if successful, or an error value otherwise. If an error occurs, ppbBuffer is set to <c>NULL</c> and pcxRow is set to zero.
	/// </para>
	/// </returns>
	// HRESULT GetBufferedPaintBits( HPAINTBUFFER hBufferedPaint, _Out_ RGBQUAD **ppbBuffer, _Out_ int *pcxRow); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773348(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773348")]
	public static extern HRESULT GetBufferedPaintBits(HPAINTBUFFER hBufferedPaint, out IntPtr ppbBuffer, out int pcxRow);

	/// <summary>Gets the paint device context (DC). This is the same value retrieved by <c>BeginBufferedPaint</c>.</summary>
	/// <param name="hBufferedPaint">
	/// <para>Type: <c>HPAINTBUFFER</c></para>
	/// <para>Handle of the buffered paint context, obtained through <c>BeginBufferedPaint</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HDC</c></c></para>
	/// <para>
	/// Handle of the requested DC. This is the same DC that is returned by <c>BeginBufferedPaint</c>. Returns <c>NULL</c> upon failure.
	/// </para>
	/// </returns>
	// HDC GetBufferedPaintDC( HPAINTBUFFER hBufferedPaint); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773351(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773351")]
	public static extern HDC GetBufferedPaintDC(HPAINTBUFFER hBufferedPaint);

	/// <summary>Retrieves the target device context (DC).</summary>
	/// <param name="hBufferedPaint">
	/// <para>Type: <c>HPAINTBUFFER</c></para>
	/// <para>A handle to the buffered paint context obtained through <c>BeginBufferedPaint</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HDC</c></c></para>
	/// <para>A handle to the requested DC, or <c>NULL</c> otherwise.</para>
	/// </returns>
	// HDC GetBufferedPaintTargetDC( HPAINTBUFFER hBufferedPaint); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773356(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773356")]
	public static extern HDC GetBufferedPaintTargetDC(HPAINTBUFFER hBufferedPaint);

	/// <summary>Retrieves the target rectangle specified by BeginBufferedPaint.</summary>
	/// <param name="hBufferedPaint">
	/// <para>Type: <c>HPAINTBUFFER</c></para>
	/// <para>Handle to the buffered paint context obtained through <c>BeginBufferedPaint</c>.</para>
	/// </param>
	/// <param name="prc">
	/// <para>Type: <c><c>RECT</c>*</c></para>
	/// <para>When this function returns, contains the requested rectangle.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// HRESULT GetBufferedPaintTargetRect( HPAINTBUFFER hBufferedPaint, _Out_ RECT *prc); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773361(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773361")]
	public static extern HRESULT GetBufferedPaintTargetRect(HPAINTBUFFER hBufferedPaint, out RECT prc);

	/// <summary>Defines animation parameters for the <c>BP_PAINTPARAMS</c> structure used by <c>BeginBufferedPaint</c>.</summary>
	// typedef struct _BP_ANIMATIONPARAMS { DWORD cbSize; DWORD dwFlags; BP_ANIMATIONSTYLE style; DWORD dwDuration;} BP_ANIMATIONPARAMS,
	// *PBP_ANIMATIONPARAMS; https://msdn.microsoft.com/en-us/library/windows/desktop/bb773224(v=vs.85).aspx
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773224")]
	[StructLayout(LayoutKind.Sequential)]
	public struct BP_ANIMATIONPARAMS
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>Reserved.</summary>
		public uint dwFlags;

		/// <summary>Animation style.</summary>
		public BP_ANIMATIONSTYLE style;

		/// <summary>Length of the animation, in milliseconds.</summary>
		public uint dwDuration;

		/// <summary>Initializes a new instance of the <see cref="BP_ANIMATIONPARAMS"/> struct.</summary>
		/// <param name="animStyle">The animation style.</param>
		/// <param name="dur">The duration.</param>
		public BP_ANIMATIONPARAMS(BP_ANIMATIONSTYLE animStyle, int dur = 0)
		{
			cbSize = (uint)Marshal.SizeOf(typeof(BP_ANIMATIONPARAMS));
			dwFlags = 0;
			dwDuration = (uint)dur;
			style = animStyle;
		}

		/// <summary>Gets an instance of an empty structure with cbSize set.</summary>
		public static BP_ANIMATIONPARAMS Empty => new BP_ANIMATIONPARAMS { cbSize = (uint)Marshal.SizeOf(typeof(BP_ANIMATIONPARAMS)) };
	}

	/// <summary>Provides a handle to an animation buffer.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HANIMATIONBUFFER : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HANIMATIONBUFFER"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HANIMATIONBUFFER(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HANIMATIONBUFFER"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HANIMATIONBUFFER NULL => new HANIMATIONBUFFER(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HANIMATIONBUFFER"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HANIMATIONBUFFER h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HANIMATIONBUFFER"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HANIMATIONBUFFER(IntPtr h) => new HANIMATIONBUFFER(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HANIMATIONBUFFER h1, HANIMATIONBUFFER h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HANIMATIONBUFFER h1, HANIMATIONBUFFER h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HANIMATIONBUFFER h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a paint buffer.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HPAINTBUFFER : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HPAINTBUFFER"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPAINTBUFFER(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPAINTBUFFER"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPAINTBUFFER NULL => new HPAINTBUFFER(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HPAINTBUFFER"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HPAINTBUFFER h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPAINTBUFFER"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPAINTBUFFER(IntPtr h) => new HPAINTBUFFER(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HPAINTBUFFER h1, HPAINTBUFFER h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HPAINTBUFFER h1, HPAINTBUFFER h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HPAINTBUFFER h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Defines paint operation parameters for <c>BeginBufferedPaint</c>.</summary>
	// typedef struct _BP_PAINTPARAMS { DWORD cbSize; DWORD dwFlags; const RECT *prcExclude; const BLENDFUNCTION *pBlendFunction;}
	// BP_PAINTPARAMS, *PBP_PAINTPARAMS; https://msdn.microsoft.com/en-us/library/windows/desktop/bb773228(v=vs.85).aspx
	[PInvokeData("Uxtheme.h", MSDNShortId = "bb773228")]
	[StructLayout(LayoutKind.Sequential)]
	public class BP_PAINTPARAMS : IDisposable
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public int cbSize;

		/// <summary>One or more of the following values.</summary>
		public BufferedPaintParamsFlags Flags;

		/// <summary>
		/// A pointer to exclusion RECT structure. This rectangle is excluded from the clipping region. May be NULL for no exclusion rectangle.
		/// </summary>
		public IntPtr prcExclude;

		/// <summary>
		/// A pointer to BLENDFUNCTION structure, which controls blending by specifying the blending functions for source and destination
		/// bitmaps. If NULL, the source buffer is copied to the destination with no blending.
		/// </summary>
		public IntPtr pBlendFunction;

		/// <summary>Initializes a new instance of the <see cref="BP_PAINTPARAMS"/> class.</summary>
		/// <param name="flags">The flags.</param>
		public BP_PAINTPARAMS(BufferedPaintParamsFlags flags = BufferedPaintParamsFlags.BPPF_NONE)
		{
			cbSize = Marshal.SizeOf(typeof(BP_PAINTPARAMS));
			Flags = flags;
			prcExclude = pBlendFunction = IntPtr.Zero;
		}

		/// <summary>Gets or sets the rectangle that is excluded from the clipping region.</summary>
		/// <value>The rectangle.</value>
		public RECT? Exclude
		{
			get => prcExclude.ToNullableStructure<RECT>();
			set
			{
				if (prcExclude != IntPtr.Zero) Marshal.FreeCoTaskMem(prcExclude);
				if (value.HasValue && !value.Value.IsEmpty)
					prcExclude = value.MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
			}
		}

		/// <summary>Gets or sets the blend function.</summary>
		/// <value>The blend function.</value>
		public BLENDFUNCTION? BlendFunction
		{
			get => pBlendFunction.ToNullableStructure<BLENDFUNCTION>();
			set
			{
				if (pBlendFunction != IntPtr.Zero) Marshal.FreeCoTaskMem(pBlendFunction);
				if (value.HasValue && !value.Value.IsEmpty)
					pBlendFunction = value.MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
			}
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			if (prcExclude != IntPtr.Zero) Marshal.FreeCoTaskMem(prcExclude);
			if (pBlendFunction != IntPtr.Zero) Marshal.FreeCoTaskMem(pBlendFunction);
		}

		/// <summary>Gets an instance of this structure set to define no clipping.</summary>
		public static BP_PAINTPARAMS NoClip => new BP_PAINTPARAMS(BufferedPaintParamsFlags.BPPF_NOCLIP);

		/// <summary>Gets an instance of this structure set to define clearing the background.</summary>
		public static BP_PAINTPARAMS ClearBg => new BP_PAINTPARAMS(BufferedPaintParamsFlags.BPPF_ERASE);
	}

	/// <summary>
	/// Automated initialization and uninitialization of buffered painting for the current thread. Automatically calls <see
	/// cref="BufferedPaintInit"/> on construction and <see cref="BufferedPaintUnInit"/> on disposal.
	/// </summary>
	/// <example>
	/// Best used by declaring a static field within the class that calls buffered paint methods. This will ensure that the
	/// initialization only happens once per thread and then is uninitialized when all methods are complete.
	/// <code lang="cs">
	/// private static BufferedPaintBlock buffPaintBlock = new BufferedPaintBlock();
	/// </code>
	/// </example>
	/// <seealso cref="System.IDisposable"/>
	public class BufferedPaintBlock : IDisposable
	{
		/// <summary>Initializes a new instance of the <see cref="BufferedPaintBlock"/> class calling <see cref="BufferedPaintInit"/>.</summary>
		public BufferedPaintBlock() => BufferedPaintInit().ThrowIfFailed();

		/// <summary>Automatically calls <see cref="BufferedPaintUnInit"/>.</summary>
		public void Dispose() => BufferedPaintUnInit();
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HANIMATIONBUFFER"/> that is disposed using <see cref="EndBufferedAnimation"/>.</summary>
	public class SafeHANIMATIONBUFFER : SafeHANDLE
	{
		private readonly bool fUpdateTarget = true;

		/// <summary>Initializes a new instance of the <see cref="SafeHANIMATIONBUFFER"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="updateTargetDC">The value to pass <see cref="EndBufferedAnimation"/> when closing this handle.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHANIMATIONBUFFER(IntPtr preexistingHandle, bool updateTargetDC = true, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) => fUpdateTarget = updateTargetDC;

		/// <summary>Initializes a new instance of the <see cref="SafeHANIMATIONBUFFER"/> class.</summary>
		private SafeHANIMATIONBUFFER() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHANIMATIONBUFFER"/> to <see cref="HANIMATIONBUFFER"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HANIMATIONBUFFER(SafeHANIMATIONBUFFER h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => EndBufferedAnimation(this, fUpdateTarget).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HPAINTBUFFER"/> that is disposed using <see cref="EndBufferedPaint"/>.</summary>
	public class SafeHPAINTBUFFER : SafeHANDLE
	{
		private readonly bool fUpdateTarget = true;

		/// <summary>Initializes a new instance of the <see cref="SafeHPAINTBUFFER"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="updateTargetDC">The value to pass <see cref="EndBufferedPaint"/> when closing this handle.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHPAINTBUFFER(IntPtr preexistingHandle, bool updateTargetDC = true, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) => fUpdateTarget = updateTargetDC;

		/// <summary>Initializes a new instance of the <see cref="SafeHPAINTBUFFER"/> class.</summary>
		private SafeHPAINTBUFFER() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHPAINTBUFFER"/> to <see cref="HPAINTBUFFER"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPAINTBUFFER(SafeHPAINTBUFFER h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => EndBufferedPaint(this, fUpdateTarget).Succeeded;
	}
}