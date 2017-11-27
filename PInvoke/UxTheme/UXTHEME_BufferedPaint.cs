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
		[Flags]
		public enum BP_ANIMATIONSTYLE
		{
			BPAS_NONE,
			BPAS_LINEAR,
			BPAS_CUBIC,
			BPAS_SINE
		}

		public enum BP_BUFFERFORMAT
		{
			BPBF_COMPATIBLEBITMAP,
			BPBF_DIB,
			BPBF_TOPDOWNDIB,
			BPBF_TOPDOWNMONODIB
		}

		[Flags]
		public enum BufferedPaintParamsFlags
		{
			BPPF_NONE = 0,
			BPPF_ERASE = 1,
			BPPF_NOCLIP = 2,
			BPPF_NONCLIENT = 4,
		}

		[DllImport(Lib.UxTheme, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr BeginBufferedAnimation(HandleRef hwnd, SafeDCHandle hdcTarget, [In] ref RECT rcTarget, BP_BUFFERFORMAT dwFormat,
			[In] BP_PAINTPARAMS pPaintParams, [In] ref BP_ANIMATIONPARAMS pAnimationParams, out IntPtr phdcFrom, out IntPtr phdcTo);

		[DllImport(Lib.UxTheme, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr BeginBufferedPaint(SafeDCHandle hdcTarget, [In] ref RECT prcTarget, BP_BUFFERFORMAT dwFormat, [In] BP_PAINTPARAMS pPaintParams, out IntPtr phdc);

		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT BufferedPaintInit();

		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BufferedPaintRenderAnimation(HandleRef hwnd, SafeDCHandle hdcTarget);

		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT BufferedPaintStopAllAnimations(HandleRef hwnd);

		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT BufferedPaintUnInit();

		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT EndBufferedAnimation(IntPtr hbpAnimation, [MarshalAs(UnmanagedType.Bool)] bool fUpdateTarget);

		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT EndBufferedPaint(IntPtr hbp, [MarshalAs(UnmanagedType.Bool)] bool fUpdateTarget);

		[StructLayout(LayoutKind.Sequential)]
		public struct BP_ANIMATIONPARAMS
		{
			public int cbSize, dwFlags;
			public BP_ANIMATIONSTYLE style;
			public int dwDuration;

			public BP_ANIMATIONPARAMS(BP_ANIMATIONSTYLE animStyle, int dur = 0)
			{
				cbSize = Marshal.SizeOf(typeof(BP_ANIMATIONPARAMS));
				dwFlags = 0;
				dwDuration = dur;
				style = animStyle;
			}

			public BP_ANIMATIONSTYLE AnimationStyle
			{
				get => style; set => style = value;
			}

			public int Duration
			{
				get => dwDuration; set => dwDuration = value;
			}

			public static BP_ANIMATIONPARAMS Empty => new BP_ANIMATIONPARAMS { cbSize = Marshal.SizeOf(typeof(BP_ANIMATIONPARAMS)) };
		}

		[StructLayout(LayoutKind.Sequential)]
		public class BP_PAINTPARAMS : IDisposable
		{
			public int cbSize;
			public BufferedPaintParamsFlags Flags;
			public IntPtr prcExclude;
			public IntPtr pBlendFunction;

			public BP_PAINTPARAMS(BufferedPaintParamsFlags flags = BufferedPaintParamsFlags.BPPF_NONE)
			{
				cbSize = Marshal.SizeOf(typeof(BP_PAINTPARAMS));
				Flags = flags;
				prcExclude = pBlendFunction = IntPtr.Zero;
			}

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

			public void Dispose()
			{
				if (prcExclude != IntPtr.Zero) Marshal.FreeCoTaskMem(prcExclude);
				if (pBlendFunction != IntPtr.Zero) Marshal.FreeCoTaskMem(pBlendFunction);
			}

			public static BP_PAINTPARAMS NoClip => new BP_PAINTPARAMS(BufferedPaintParamsFlags.BPPF_NOCLIP);

			public static BP_PAINTPARAMS ClearBg => new BP_PAINTPARAMS(BufferedPaintParamsFlags.BPPF_ERASE);
		}
	}
}
