using System.Drawing;
using System.Drawing.Drawing2D;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Extension methods to convert GdiObj handle variants to their .NET equivalents.</summary>
public static class GdiObjExtensions2
{
	/// <summary>
	/// Draws on a device context ( <see cref="SafeHDC"/>) via a DIB section. This is useful when you need to draw on a transparent background.
	/// </summary>
	/// <param name="hdc">The device context.</param>
	/// <param name="bounds">The bounds of the device context to paint.</param>
	/// <param name="drawMethod">The draw method.</param>
	public static void DrawViaDIB(this IDeviceContext hdc, in RECT bounds, Action<SafeHDC, RECT> drawMethod)
	{
		IntPtr h = hdc.GetHdc();
		try { GdiObjExtensions.DrawViaDIB(h, bounds, drawMethod); }
		finally { hdc.ReleaseHdc(); }
	}

	/// <summary>Gets the copy of the device handle in an IDeviceContext supporting GDI+.</summary>
	/// <param name="dc">The <see cref="IDeviceContext"/> instance.</param>
	/// <returns>A <see cref="SafeHDC"/> instance that contains a copy of the context.</returns>
	public static SafeHDC GetCompatibleSafeHDC(this IDeviceContext? dc)
	{
		if (dc is null)
		{
			return new(default, false);
		}

		SafeHDC hdc = CreateCompatibleDC(dc.GetHdc());
		dc.ReleaseHdc();
		return hdc;
	}

	/// <summary>Creates a <see cref="Bitmap"/> from an <see cref="SafeHBITMAP"/> preserving transparency, if possible.</summary>
	/// <param name="hbmp">The SafeHBITMAP value.</param>
	/// <returns>The Bitmap instance. If <paramref name="hbmp"/> is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
	public static Bitmap ToBitmap(this SafeHBITMAP hbmp) => ToBitmap((HBITMAP)hbmp);

	/// <summary>Creates a <see cref="Bitmap"/> from an <see cref="HBITMAP"/> preserving transparency, if possible.</summary>
	/// <param name="hbmp">The HBITMAP value.</param>
	/// <returns>The Bitmap instance. If <paramref name="hbmp"/> is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
	public static Bitmap ToBitmap(this in HBITMAP hbmp) => Image.FromHbitmap((IntPtr)hbmp);

	/// <summary>Creates a managed <see cref="Bitmap"/> from a HICON instance.</summary>
	/// <returns>A managed bitmap instance.</returns>
	public static Bitmap? ToBitmap(this in HICON hIcon) => hIcon.IsNull ? null : (Bitmap)Bitmap.FromHicon((IntPtr)hIcon).Clone();

	/// <summary>Creates a managed <see cref="Bitmap"/> from a SafeHICON instance.</summary>
	/// <returns>A managed bitmap instance.</returns>
	public static Bitmap? ToBitmap(this SafeHICON hIcon) => ToBitmap((HICON)hIcon);

	/// <summary>Creates a managed <see cref="Brush"/> from this HBRUSH instance.</summary>
	/// <param name="hbr">The HBRUSH value.</param>
	/// <returns>A managed brush instance.</returns>
	public static Brush? ToBrush(this in HBRUSH hbr) => hbr.IsNull ? null : new NativeBrush(hbr);

	/// <summary>Creates a managed <see cref="Brush"/> from this HBRUSH instance.</summary>
	/// <param name="hbr">The HBRUSH value.</param>
	/// <returns>A managed brush instance.</returns>
	public static Brush? ToBrush(this SafeHBRUSH hbr) => ((HBRUSH)hbr).ToBrush();

	/// <summary>Creates a <see cref="Font"/> from an <see cref="HFONT"/>.</summary>
	/// <param name="hf">The HFONT value.</param>
	/// <returns>The Font instance.</returns>
	public static Font? ToFont(this in HFONT hf) => hf.IsNull ? null : Font.FromHfont((IntPtr)hf);

	/// <summary>Creates a <see cref="Font"/> from an <see cref="HFONT"/>.</summary>
	/// <param name="hf">The HFONT value.</param>
	/// <returns>The Font instance.</returns>
	public static Font? ToFont(this SafeHFONT hf) => ((HFONT)hf).ToFont();

	/// <summary>Creates a managed <see cref="Icon"/> from an HICON instance.</summary>
	/// <returns>A managed icon instance.</returns>
	public static Icon? ToIcon(this in HICON hIcon) => hIcon.IsNull ? null : (Icon)Icon.FromHandle((IntPtr)hIcon).Clone();

	/// <summary>Creates a managed <see cref="Icon"/> from a SafeHICON instance.</summary>
	/// <returns>A managed icon instance.</returns>
	public static Icon? ToIcon(this SafeHICON hIcon) => ToIcon((HICON)hIcon);

	/// <summary>Creates a <see cref="Pen"/> from an <see cref="HPEN"/>.</summary>
	/// <param name="hpen">The HPEN value.</param>
	/// <returns>The Pen instance.</returns>
	public static Pen? ToPen(this in HPEN hpen)
	{
		using ISafeMemoryHandle ptr = GetObject(hpen);
		EXTLOGPEN lpen = ptr.ToStructure<EXTLOGPEN>();
		Pen? pen = null;
		switch (lpen.elpBrushStyle)
		{
			case BrushStyle.BS_DIBPATTERN:
			case BrushStyle.BS_DIBPATTERNPT:
				DIBColorMode lw = (DIBColorMode)(uint)lpen.elpColor;
				SafeHBRUSH hb = CreateDIBPatternBrushPt(lpen.elpHatch, lw);
				pen = new Pen(((HBRUSH)hb).ToBrush()!);
				break;

			case BrushStyle.BS_HATCHED:
				HatchBrush hbr = new((System.Drawing.Drawing2D.HatchStyle)lpen.elpHatch.ToInt32(), lpen.elpColor);
				pen = new Pen(hbr);
				break;

			case BrushStyle.BS_PATTERN:
				TextureBrush pbr = new(Image.FromHbitmap(lpen.elpHatch));
				pen = new Pen(pbr);
				break;

			case BrushStyle.BS_HOLLOW:
			case BrushStyle.BS_SOLID:
			default:
				pen = new Pen(lpen.elpColor) { DashStyle = (DashStyle)lpen.Style };
				if (pen.DashStyle == DashStyle.Custom && lpen.elpNumEntries > 0)
				{
					uint[] styleArray = lpen.elpStyleEntry.ToArray<uint>((int)lpen.elpNumEntries) ?? [];
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
	public static Pen? ToPen(this SafeHPEN hpen) => ((HPEN)hpen).ToPen();

	/// <summary>Creates a <see cref="Region"/> from an <see cref="HRGN"/>.</summary>
	/// <param name="hrgn">The HRGN value.</param>
	/// <returns>The Region instance.</returns>
	public static Region? ToRegion(this in HRGN hrgn) => hrgn.IsNull ? null : Region.FromHrgn((IntPtr)hrgn);

	/// <summary>Creates a <see cref="Region"/> from an <see cref="HRGN"/>.</summary>
	/// <param name="hrgn">The HRGN value.</param>
	/// <returns>The Region instance.</returns>
	public static Region? ToRegion(this SafeHRGN hrgn) => ((HRGN)hrgn).ToRegion();

	// TODO: Fix code below to process different bpp bitmaps w/o flipping
	//{
	//	const Imaging.PixelFormat fmt = Imaging.PixelFormat.Format32bppArgb;

	// // If hbmp is NULL handle, return null if (hbmp.IsNull) return null;

	// // Get detail and bail if not 32bit, empty or an old style BMP var (bpp, width, height, scanBytes, bits, isdib) = GetInfo(hbmp);
	// if (bpp != Image.GetPixelFormatSize(fmt) || height == 0 || !isdib) return Image.FromHbitmap((IntPtr)hbmp);

	// // Create bitmap from detail and flip if upside-down var bmp = new Bitmap(width, height, scanBytes, fmt, bits); if (height < 0)
	// bmp.RotateFlip(RotateFlipType.Rotate180FlipNone); return bmp;

	// static (ushort bpp, int width, int height, int scanBytes, IntPtr bits, bool isdib) GetInfo(in HBITMAP hbmp) { var dibSz =
	// Marshal.SizeOf(typeof(DIBSECTION)); using var mem = GetObject(hbmp, dibSz); if (mem.Size == dibSz) { var dib =
	// mem.ToStructure<DIBSECTION>(); return (dib.dsBm.bmBitsPixel, dib.dsBmih.biWidth, dib.dsBmih.biHeight, dib.dsBm.bmWidthBytes,
	// dib.dsBm.bmBits, true); } else { var bmp = mem.ToStructure<BITMAP>(); return (bmp.bmBitsPixel, bmp.bmWidth, bmp.bmHeight,
	// bmp.bmWidthBytes, bmp.bmBits, false); } }

	//}

#if WPF && !NETSTANDARD2_0
	/// <summary>
	/// Creates a <see cref="System.Windows.Media.Imaging.BitmapSource"/> from an <see cref="HBITMAP"/> preserving transparency, if possible.
	/// </summary>
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

	/// <summary>
	/// Creates a <see cref="System.Windows.Media.Imaging.BitmapSource"/> from an <see cref="SafeHBITMAP"/> preserving transparency, if possible.
	/// </summary>
	/// <param name="hbmp">The SafeHBITMAP value.</param>
	/// <returns>The BitmapSource instance. If <paramref name="hbmp"/> is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
	public static System.Windows.Media.Imaging.BitmapSource ToBitmapSource(this SafeHBITMAP hbmp) => ((HBITMAP)hbmp).ToBitmapSource();
#endif

	private class NativeBrush : Brush
	{
		public NativeBrush(HBRUSH hBrush)
		{
			LOGBRUSH lb = GetObject<LOGBRUSH>(hBrush);
			using SafeHBRUSH b2 = CreateBrushIndirect(lb);
			SetNativeBrush(b2.DangerousGetHandle());
			b2.SetHandleAsInvalid();
		}

		public override object Clone() => this;
	}
}

/// <summary>A self-releasing pattern for IDeviceContext.GetHdc and ReleaseHdc.</summary>
/// <seealso cref="System.IDisposable"/>
/// <remarks>Initializes a new instance of the <see cref="SafeTempHDC"/> class with an <see cref="IDeviceContext"/>.</remarks>
/// <param name="dc">The <see cref="IDeviceContext"/> instance.</param>
public class SafeTempHDC(IDeviceContext? dc) : IDisposable, IGraphicsObjectHandle
{
	private readonly IntPtr hdc = dc?.GetHdc() ?? default;

	/// <summary>Gets a value indicating whether this instance has a NULL handle.</summary>
	/// <value><see langword="true"/> if this has a NULL handle; otherwise, <see langword="false"/>.</value>
	public bool IsNull => hdc == default;

	/// <summary>Performs an implicit conversion from <see cref="SafeTempHDC"/> to <see cref="HDC"/>.</summary>
	/// <param name="o">The <see cref="SafeTempHDC"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HDC(SafeTempHDC o) => o.hdc;

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => hdc;

	/// <summary>Releases claimed HDC.</summary>
	public void Dispose()
	{
		dc?.ReleaseHdc();
		GC.SuppressFinalize(this);
	}
}