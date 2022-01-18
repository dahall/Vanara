using System.Windows;
using System.Windows.Media;

namespace Vanara.PInvoke
{
	/// <summary>Conversion extension methods for WinUI/UWP and Vanara types.</summary>
	public static class SystemWindowsExtensions
	{
		/// <summary>Converts <see cref="COLORREF"/> to <see cref="Color"/>.</summary>
		/// <param name="c">The color to convert.</param>
		/// <returns>The converted value.</returns>
		public static Color ToColor(this in COLORREF c) => new() { A = c.A, R = c.R, G = c.G, B = c.B };

		/// <summary>Converts <see cref="Color"/> to <see cref="COLORREF"/>.</summary>
		/// <param name="c">The color to convert.</param>
		/// <returns>The converted value.</returns>
		public static COLORREF ToCOLORREF(this in Color c) => new(c.R, c.G, c.B) { A = c.A };

		/// <summary>Converts <see cref="POINT"/> to <see cref="Point"/>.</summary>
		/// <param name="pt">The point to convert.</param>
		/// <returns>The converted value.</returns>
		public static Point ToPoint(this in POINT pt) => new(pt.X, pt.Y);

		/// <summary>Converts <see cref="RECT"/> to <see cref="Int32Rect"/>.</summary>
		/// <param name="r">The rectangle to convert.</param>
		/// <returns>The converted value.</returns>
		public static Int32Rect ToRect(this in RECT r) => new(r.X, r.Y, r.Width, r.Height);

		/// <summary>Converts <see cref="RECT"/> to <see cref="Int32Rect"/>.</summary>
		/// <param name="r">The rectangle to convert.</param>
		/// <returns>The converted value.</returns>
		public static RECT ToRECT(this in Int32Rect r) => new(r.X, r.Y, r.X + r.Width, r.Y + r.Height);

		/// <summary>Converts <see cref="SIZE"/> to <see cref="Size"/>.</summary>
		/// <param name="sz">The size to convert.</param>
		/// <returns>The converted value.</returns>
		public static Size ToSize(this in SIZE sz) => new(sz.cx, sz.cy);
	}
}