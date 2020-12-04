using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke
{
	/// <summary>Extension methods to convert GdiObj handle variants to their .NET equivalents.</summary>
	public static class GdiObjExtensions
	{
		/// <summary>Converts the generic GDI object handle to a specific handle.</summary>
		/// <typeparam name="T">The handle type to which to convert.</typeparam>
		/// <param name="hObj">The generic GDI object handle.</param>
		/// <returns>The converted handle of type <typeparamref name="T"/>.</returns>
		/// <exception cref="ArgumentException">The conversion type specified is not valid for the supplied GDI object.</exception>
		public static T ConvertTo<T>(this IGraphicsObjectHandle hObj) where T : IGraphicsObjectHandle
		{
			var ot = GetObjectType(hObj.DangerousGetHandle());
			if (ot == 0) Win32Error.ThrowLastError();
			if (!CorrespondingTypeAttribute.CanGet(ot, typeof(T)))
				throw new ArgumentException($"The conversion type specified is not valid for the supplied GDI object.");
			return (T)(object)hObj.DangerousGetHandle();
		}

		/// <summary>Draws on a device context (<see cref="Graphics"/>) via a DIB section. This is useful when you need to draw on a transparent background.</summary>
		/// <param name="dc">The device context.</param>
		/// <param name="bounds">The bounds of the device context to paint.</param>
		/// <param name="drawMethod">The draw method.</param>
		public static void DrawViaDIB(this IDeviceContext dc, in Rectangle bounds, Action<SafeHDC, Rectangle> drawMethod)
		{
			using var sdc = new SafeHDC(dc);
			DrawViaDIB(sdc, bounds, drawMethod);
		}

		/// <summary>Draws on a device context (<see cref="SafeHDC"/>) via a DIB section. This is useful when you need to draw on a transparent background.</summary>
		/// <param name="hdc">The device context.</param>
		/// <param name="bounds">The bounds of the device context to paint.</param>
		/// <param name="drawMethod">The draw method.</param>
		public static void DrawViaDIB(this SafeHDC hdc, in Rectangle bounds, Action<SafeHDC, Rectangle> drawMethod)
		{
			// Create a memory DC so we can work off screen
			using var memoryHdc = hdc.GetCompatibleDCHandle();
			// Create a device-independent bitmap and select it into our DC
			var info = new BITMAPINFO(bounds.Width, -bounds.Height);
			using (memoryHdc.SelectObject(CreateDIBSection(hdc, ref info, 0, out var pBits, IntPtr.Zero, 0)))
			{
				// Call method
				drawMethod(memoryHdc, bounds);

				// Copy to foreground
				BitBlt(hdc, bounds.Left, bounds.Top, bounds.Width, bounds.Height, memoryHdc, 0, 0, RasterOperationMode.SRCCOPY);
			}
		}

		/// <summary>Creates a <see cref="Bitmap"/> from an <see cref="HBITMAP"/> preserving transparency, if possible.</summary>
		/// <param name="hbmp">The HBITMAP value.</param>
		/// <returns>The Bitmap instance. If <paramref name="hbmp"/> is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
		public static Bitmap ToBitmap(this in HBITMAP hbmp)
		{
			// If hbmp is NULL handle, return null
			if (hbmp.IsNull) return null;
			try
			{
				var dibsection = GetObject<DIBSECTION>(hbmp);
				// If hbmp doesn't have ARGB, then just use Gdi+
				if (dibsection.dsBm.bmBitsPixel != 32) return Image.FromHbitmap((IntPtr)hbmp);
				// Create resulting bitmap of same size with transparency and lock in memory
				var bitmap = new Bitmap(dibsection.dsBm.bmWidth, dibsection.dsBm.bmHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				var bmpData = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				// Grab arrays to both DIB and result
				using var mstr = new SafeNativeArray<RGBQUAD>(dibsection.dsBm.bmBits, (int)dibsection.dsBmih.biSizeImage, false);
				using var bstr = new SafeNativeArray<RGBQUAD>(bmpData.Scan0, (int)dibsection.dsBmih.biSizeImage, false);
				// Copy all semi-transparent bits
				for (int i = 0; i < mstr.Count; i++)
				{
					var rgbquad = mstr[i];
					// If pixel is 100% transparent, skip pixel
					if (rgbquad.rgbReserved != 0)
						bstr[i] = rgbquad;
				}
				bitmap.UnlockBits(bmpData);
				return bitmap;
			}
			catch
			{
				return Image.FromHbitmap((IntPtr)hbmp);
			}
		}

		/// <summary>Creates a <see cref="Bitmap"/> from an <see cref="SafeHBITMAP"/> preserving transparency, if possible.</summary>
		/// <param name="hbmp">The SafeHBITMAP value.</param>
		/// <returns>The Bitmap instance. If <paramref name="hbmp"/> is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
		public static Bitmap ToBitmap(this SafeHBITMAP hbmp) => ((HBITMAP)hbmp).ToBitmap();

#if !NET20 && !NETSTANDARD2_0 && !NETCOREAPP2_0 && !NETCOREAPP2_1
		/// <summary>Creates a <see cref="System.Windows.Media.Imaging.BitmapSource"/> from an <see cref="HBITMAP"/> preserving transparency, if possible.</summary>
		/// <param name="hbmp">The HBITMAP value.</param>
		/// <returns>The BitmapSource instance. If <paramref name="hbmp"/> is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
		public static System.Windows.Media.Imaging.BitmapSource ToBitmapSource(this in HBITMAP hbmp)
		{
			// If hbmp is NULL handle, return null
			if (hbmp.IsNull) return null;
			try
			{
				return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap((IntPtr)hbmp, IntPtr.Zero,
					System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
			}
			catch (System.ComponentModel.Win32Exception)
			{
				return null;
			}
		}

		/// <summary>Creates a <see cref="System.Windows.Media.Imaging.BitmapSource"/> from an <see cref="SafeHBITMAP"/> preserving transparency, if possible.</summary>
		/// <param name="hbmp">The SafeHBITMAP value.</param>
		/// <returns>The BitmapSource instance. If <paramref name="hbmp"/> is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
		public static System.Windows.Media.Imaging.BitmapSource ToBitmapSource(this SafeHBITMAP hbmp) => ((HBITMAP)hbmp).ToBitmapSource();
#endif

		/// <summary>Creates a managed <see cref="System.Drawing.Brush"/> from this HBRUSH instance.</summary>
		/// <param name="hbr">The HBRUSH value.</param>
		/// <returns>A managed brush instance.</returns>
		public static Brush ToBrush(this in HBRUSH hbr) => hbr.IsNull ? null : new NativeBrush(hbr);

		/// <summary>Creates a managed <see cref="System.Drawing.Brush"/> from this HBRUSH instance.</summary>
		/// <param name="hbr">The HBRUSH value.</param>
		/// <returns>A managed brush instance.</returns>
		public static Brush ToBrush(this SafeHBRUSH hbr) => ((HBRUSH)hbr).ToBrush();

		/// <summary>Creates a <see cref="Font"/> from an <see cref="HFONT"/>.</summary>
		/// <param name="hf">The HFONT value.</param>
		/// <returns>The Font instance.</returns>
		public static Font ToFont(this in HFONT hf) => hf.IsNull ? null : Font.FromHfont((IntPtr)hf);

		/// <summary>Creates a <see cref="Font"/> from an <see cref="HFONT"/>.</summary>
		/// <param name="hf">The HFONT value.</param>
		/// <returns>The Font instance.</returns>
		public static Font ToFont(this SafeHFONT hf) => ((HFONT)hf).ToFont();

		/// <summary>Creates a <see cref="Pen"/> from an <see cref="HPEN"/>.</summary>
		/// <param name="hpen">The HPEN value.</param>
		/// <returns>The Pen instance.</returns>
		public static Pen ToPen(this in HPEN hpen)
		{
			using var ptr = GetObject(hpen);
			var lpen = ptr.ToStructure<EXTLOGPEN>();
			Pen pen = null;
			switch (lpen.elpBrushStyle)
			{
				case BrushStyle.BS_DIBPATTERN:
				case BrushStyle.BS_DIBPATTERNPT:
					var lw = (DIBColorMode)(uint)lpen.elpColor;
					var hb = CreateDIBPatternBrushPt(lpen.elpHatch, lw);
					pen = new Pen(((HBRUSH)hb).ToBrush());
					break;

				case BrushStyle.BS_HATCHED:
					var hbr = new HatchBrush((System.Drawing.Drawing2D.HatchStyle)lpen.elpHatch.ToInt32(), lpen.elpColor);
					pen = new Pen(hbr);
					break;

				case BrushStyle.BS_PATTERN:
					var pbr = new TextureBrush(Image.FromHbitmap(lpen.elpHatch));
					pen = new Pen(pbr);
					break;

				case BrushStyle.BS_HOLLOW:
				case BrushStyle.BS_SOLID:
				default:
					pen = new Pen(lpen.elpColor) { DashStyle = (DashStyle)lpen.Style };
					if (pen.DashStyle == DashStyle.Custom && lpen.elpNumEntries > 0)
					{
						var styleArray = lpen.elpStyleEntry.ToArray<uint>((int)lpen.elpNumEntries);
						pen.DashPattern = Array.ConvertAll(styleArray, i => (float)i);
					}
					break;
			}
			if (lpen.Type == Gdi32.PenType.PS_GEOMETRIC)
			{
				pen.LineJoin = lpen.Join == PenJoin.PS_JOIN_MITER ? LineJoin.Miter : (lpen.Join == PenJoin.PS_JOIN_BEVEL ? LineJoin.Bevel : LineJoin.Round);
				pen.EndCap = pen.StartCap = lpen.EndCap == PenEndCap.PS_ENDCAP_FLAT ? LineCap.Flat : (lpen.EndCap == PenEndCap.PS_ENDCAP_SQUARE ? LineCap.Square : LineCap.Round);
				pen.Width = LogicalWidthToDeviceWidth((int)lpen.elpWidth);
			}
			else
			{
				pen.Width = lpen.elpWidth;
			}
			return pen;
		}

		/// <summary>Creates a <see cref="Pen"/> from an <see cref="HPEN"/>.</summary>
		/// <param name="hpen">The HPEN value.</param>
		/// <returns>The Pen instance.</returns>
		public static Pen ToPen(this SafeHPEN hpen) => ((HPEN)hpen).ToPen();

		/// <summary>Creates a <see cref="Region"/> from an <see cref="HRGN"/>.</summary>
		/// <param name="hrgn">The HRGN value.</param>
		/// <returns>The Region instance.</returns>
		public static Region ToRegion(this in HRGN hrgn) => hrgn.IsNull ? null : Region.FromHrgn((IntPtr)hrgn);

		/// <summary>Creates a <see cref="Region"/> from an <see cref="HRGN"/>.</summary>
		/// <param name="hrgn">The HRGN value.</param>
		/// <returns>The Region instance.</returns>
		public static Region ToRegion(this SafeHRGN hrgn) => ((HRGN)hrgn).ToRegion();

		private class NativeBrush : Brush
		{
			public NativeBrush(HBRUSH hBrush)
			{
				var lb = GetObject<LOGBRUSH>(hBrush);
				using var b2 = CreateBrushIndirect(lb);
				SetNativeBrush(b2.DangerousGetHandle());
				b2.SetHandleAsInvalid();
			}

			public override object Clone() => this;
		}
	}
}