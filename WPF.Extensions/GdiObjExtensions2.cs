using System.Windows.Media.Imaging;
using static System.Windows.Interop.Imaging;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	/// <summary>Extension methods to convert GdiObj handle variants to their .NET equivalents.</summary>
	public static class GdiObjExtensions2
	{
		/// <summary>Creates a <see cref="BitmapSource"/> from an <see cref="SafeHBITMAP"/> preserving transparency, if possible.</summary>
		/// <param name="hbmp">The SafeHBITMAP value.</param>
		/// <returns>The BitmapSource instance. If <paramref name="hbmp"/> is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
		public static BitmapSource ToBitmapSource(this SafeHBITMAP hbmp) => hbmp is null || hbmp.IsInvalid ? null : CreateBitmapSourceFromHBitmap(hbmp.DangerousGetHandle(), default, default, BitmapSizeOptions.FromEmptyOptions());

		/// <summary>Creates a <see cref="BitmapSource"/> from an <see cref="HBITMAP"/> preserving transparency, if possible.</summary>
		/// <param name="hbmp">The HBITMAP value.</param>
		/// <returns>The BitmapSource instance. If <paramref name="hbmp"/> is a <c>NULL</c> handle, <see langword="null"/> is returned.</returns>
		public static BitmapSource ToBitmapSource(this in HBITMAP hbmp) => hbmp.IsNull ? null : CreateBitmapSourceFromHBitmap(hbmp.DangerousGetHandle(), default, default, BitmapSizeOptions.FromEmptyOptions());

		/// <summary>Creates a managed <see cref="BitmapSource"/> from a HICON instance.</summary>
		/// <returns>A managed bitmap instance.</returns>
		public static BitmapSource ToBitmapSource(this in HICON hIcon) => hIcon.IsNull ? null : CreateBitmapSourceFromHIcon(hIcon.DangerousGetHandle(), default, BitmapSizeOptions.FromEmptyOptions());

		/// <summary>Creates a managed <see cref="BitmapSource"/> from a SafeHICON instance.</summary>
		/// <returns>A managed bitmap instance.</returns>
		public static BitmapSource ToBitmapSource(this SafeHICON hIcon) => hIcon is null || hIcon.IsInvalid ? null : CreateBitmapSourceFromHIcon(hIcon.DangerousGetHandle(), default, BitmapSizeOptions.FromEmptyOptions());
	}
}