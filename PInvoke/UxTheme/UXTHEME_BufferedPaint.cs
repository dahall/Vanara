using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using static Vanara.PInvoke.Gdi32;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
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
			/// <summary>Compatible bitmap. The number of bits per pixel is based on the color format of the device associated with the HDC specified with BeginBufferedPaint or BeginBufferedAnimation—typically, this is the display device.</summary>
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
			/// <summary>Initialize the buffer to ARGB = {0, 0, 0, 0} during BeginBufferedPaint. This erases the previous contents of the buffer.</summary>
			BPPF_ERASE = 1,
			/// <summary>Do not apply the clip region of the target DC to the double buffer. If this flag is not set and if the target DC is a window DC, then clipping due to overlapping windows is applied to the double buffer.</summary>
			BPPF_NOCLIP = 2,
			/// <summary>A non-client DC is being used.</summary>
			BPPF_NONCLIENT = 4,
		}

		/// <summary>Begins a buffered animation operation. The animation consists of a cross-fade between the contents of two buffers over a specified period of time.</summary>
		/// <param name="hwnd">A handle to the window in which the animations play.</param>
		/// <param name="hdcTarget">A handle of the target DC on which the buffer is animated.</param>
		/// <param name="rcTarget">A pointer to a structure that specifies the area of the target DC in which to draw.</param>
		/// <param name="dwFormat">The format of the buffer.</param>
		/// <param name="pPaintParams">A pointer to a structure that defines the paint operation parameters. This value can be NULL.</param>
		/// <param name="pAnimationParams">A pointer to a structure that defines the animation operation parameters.</param>
		/// <param name="phdcFrom">When this function returns, this value points to the handle of the DC where the application should paint the initial state of the animation, if not NULL.</param>
		/// <param name="phdcTo">When this function returns, this value points to the handle of the DC where the application should paint the final state of the animation, if not NULL.</param>
		/// <returns>A handle to the buffered paint animation.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr BeginBufferedAnimation(HandleRef hwnd, SafeDCHandle hdcTarget, [In] ref RECT rcTarget, BP_BUFFERFORMAT dwFormat,
			[In] BP_PAINTPARAMS pPaintParams, [In] ref BP_ANIMATIONPARAMS pAnimationParams, out IntPtr phdcFrom, out IntPtr phdcTo);

		/// <summary>Begins a buffered paint operation.</summary>
		/// <param name="hdcTarget">The handle of the target DC on which the buffer will be painted.</param>
		/// <param name="prcTarget">A pointer to a RECT structure that specifies the area of the target DC in which to paint.</param>
		/// <param name="dwFormat">A member of the BP_BUFFERFORMAT enumeration that specifies the format of the buffer.</param>
		/// <param name="pPaintParams">A pointer to a BP_PAINTPARAMS structure that defines the paint operation parameters. This value can be NULL.</param>
		/// <param name="phdc">When this function returns, points to the handle of the new device context.</param>
		/// <returns>A handle to the buffered paint context. If this function fails, the return value is NULL, and phdc is NULL. To get extended error information, call GetLastError.
		/// <para>The returned handle is freed when EndBufferedPaint is called.</para>
		/// <para>An application should call BufferedPaintInit on the calling thread before calling BeginBufferedPaint, and BufferedPaintUnInit before the thread is terminated.Failure to call BufferedPaintInit may result in degraded performance due to internal data being initialized and destroyed for each buffered paint operation.</para></returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr BeginBufferedPaint(SafeDCHandle hdcTarget, [In] ref RECT prcTarget, BP_BUFFERFORMAT dwFormat, [In] BP_PAINTPARAMS pPaintParams, out IntPtr phdc);

		/// <summary>Clears a specified rectangle in the buffer to ARGB = {0,0,0,0}.</summary>
		/// <param name="hBufferedPaint">The handle of the buffered paint context, obtained through BeginBufferedPaint.</param>
		/// <param name="prc">A pointer to a RECT structure that specifies the rectangle to clear. Set this parameter to NULL to specify the entire buffer.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT BufferedPaintClear(IntPtr hBufferedPaint, ref RECT prc);

		/// <summary>Initialize buffered painting for the current thread.</summary>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT BufferedPaintInit();

		/// <summary>Paints the next frame of a buffered paint animation.</summary>
		/// <param name="hwnd">Handle to the window in which the animations play.</param>
		/// <param name="hdcTarget">Handle of the target DC on which the buffer is animated.</param>
		/// <returns>Returns TRUE if the frame has been painted, or FALSE otherwise.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BufferedPaintRenderAnimation(HandleRef hwnd, SafeDCHandle hdcTarget);

		/// <summary>Sets the alpha to a specified value in a given rectangle. The alpha controls the amount of transparency applied when blending with the buffer onto the destination target device context (DC).</summary>
		/// <param name="hBufferedPaint">The handle of the buffered paint context, obtained through BeginBufferedPaint.</param>
		/// <param name="prc">A pointer to a RECT structure that specifies the rectangle in which to set the alpha. Set this parameter to NULL to specify the entire buffer.</param>
		/// <param name="alpha">The alpha value to set. The alpha value can range from zero (fully transparent) to 255 (fully opaque).</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT BufferedPaintSetAlpha(IntPtr hBufferedPaint, ref RECT prc, byte alpha);

		/// <summary>Stops all buffered animations for the given window.</summary>
		/// <param name="hwnd">The handle of the window in which to stop all animations.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT BufferedPaintStopAllAnimations(HandleRef hwnd);

		/// <summary>Closes down buffered painting for the current thread. Called once for each call to BufferedPaintInit after calls to BeginBufferedPaint are no longer needed.</summary>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT BufferedPaintUnInit();

		/// <summary>Renders the first frame of a buffered animation operation and starts the animation timer.</summary>
		/// <param name="hbpAnimation">The handle to the buffered animation context that was returned by BeginBufferedAnimation.</param>
		/// <param name="fUpdateTarget">If TRUE, updates the target DC with the animation. If FALSE, the animation is not started, the target DC is not updated, and the hbpAnimation parameter is freed.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT EndBufferedAnimation(IntPtr hbpAnimation, [MarshalAs(UnmanagedType.Bool)] bool fUpdateTarget);

		/// <summary>Completes a buffered paint operation and frees the associated buffered paint handle.</summary>
		/// <param name="hbp">The handle of the buffered paint context, obtained through BeginBufferedPaint.</param>
		/// <param name="fUpdateTarget">TRUE to copy the buffer to the target DC.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT EndBufferedPaint(IntPtr hbp, [MarshalAs(UnmanagedType.Bool)] bool fUpdateTarget);

		/// <summary>Retrieves a pointer to the buffer bitmap if the buffer is a device-independent bitmap (DIB).</summary>
		/// <param name="hBufferedPaint">The handle of the buffered paint context, obtained through BeginBufferedPaint.</param>
		/// <param name="ppbBuffer">When this function returns, contains a pointer to the address of the buffer bitmap pixels.</param>
		/// <param name="pcxRow">When this function returns, contains a pointer to the width, in pixels, of the buffer bitmap. This value is not necessarily equal to the buffer width. It may be larger.</param>
		/// <returns>Returns S_OK if successful, or an error value otherwise. If an error occurs, ppbBuffer is set to NULL and pcxRow is set to zero.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetBufferedPaintBits(IntPtr hBufferedPaint, out IntPtr ppbBuffer, out int pcxRow);

		/// <summary>Gets the paint device context (DC). This is the same value retrieved by BeginBufferedPaint.</summary>
		/// <param name="hBufferedPaint">Handle of the buffered paint context, obtained through BeginBufferedPaint.</param>
		/// <returns>Handle of the requested DC. This is the same DC that is returned by BeginBufferedPaint. Returns NULL upon failure.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern IntPtr GetBufferedPaintDC(IntPtr hBufferedPaint);

		/// <summary>Retrieves the target device context (DC).</summary>
		/// <param name="hBufferedPaint">A handle to the buffered paint context obtained through BeginBufferedPaint.</param>
		/// <returns>A handle to the requested DC, or NULL otherwise.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern IntPtr GetBufferedPaintTargetDC(IntPtr hBufferedPaint);

		/// <summary>Retrieves the target rectangle specified by BeginBufferedPaint.</summary>
		/// <param name="hBufferedPaint">Handle to the buffered paint context obtained through BeginBufferedPaint.</param>
		/// <param name="prc">When this function returns, contains the requested rectangle.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetBufferedPaintTargetRect(IntPtr hBufferedPaint, out RECT prc);

		/// <summary>Defines animation parameters for the BP_PAINTPARAMS structure used by BeginBufferedPaint.</summary>
		[PInvokeData("UxTheme.h")]
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

		/// <summary>Defines paint operation parameters for BeginBufferedPaint.</summary>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("UxTheme.h")]
		[StructLayout(LayoutKind.Sequential)]
		public class BP_PAINTPARAMS : IDisposable
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public int cbSize;
			/// <summary>One or more of the following values.</summary>
			public BufferedPaintParamsFlags Flags;
			/// <summary>A pointer to exclusion RECT structure. This rectangle is excluded from the clipping region. May be NULL for no exclusion rectangle.</summary>
			public IntPtr prcExclude;
			/// <summary>A pointer to BLENDFUNCTION structure, which controls blending by specifying the blending functions for source and destination bitmaps. If NULL, the source buffer is copied to the destination with no blending.</summary>
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
			public Rectangle? Exclude
			{
				get => prcExclude.ToNullableStructure<Rectangle>();
				set
				{
					if (prcExclude != IntPtr.Zero) Marshal.FreeCoTaskMem(prcExclude);
					if (value.HasValue && !value.Value.IsEmpty)
						prcExclude = value.StructureToPtr(Marshal.AllocCoTaskMem, out int _);
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
						pBlendFunction = value.StructureToPtr(Marshal.AllocCoTaskMem, out int _);
				}
			}

			/// <summary>
			/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
			/// </summary>
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
	}
}