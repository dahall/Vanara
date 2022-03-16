using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>The RGBQUAD structure describes a color consisting of relative intensities of red, green, and blue.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Wingdi.h", MSDNShortId = "dd162938")]
	public struct RGBQUAD
	{
		/// <summary>The intensity of blue in the color.</summary>
		public byte rgbBlue;

		/// <summary>The intensity of green in the color.</summary>
		public byte rgbGreen;

		/// <summary>The intensity of red in the color.</summary>
		public byte rgbRed;

		/// <summary>This member is reserved and must be zero.</summary>
		public byte rgbReserved;

		/// <summary>Gets a value indicating whether any transparency is defined.</summary>
		/// <value><see langword="true"/> if this value is transparent; otherwise, <see langword="false"/>.</value>
		public bool IsTransparent => rgbReserved == 0;

		/// <summary>Gets or sets the color associated with the <see cref="RGBQUAD"/> structure.</summary>
		/// <value>The color.</value>
		public COLORREF Color
		{
			get => new(rgbRed, rgbGreen, rgbBlue) { A = rgbReserved };
			set { rgbReserved = value.A; rgbBlue = value.B; rgbGreen = value.G; rgbRed = value.R; }
		}

		/// <summary>Performs an implicit conversion from <see cref="COLORREF"/> to <see cref="RGBQUAD"/>.</summary>
		/// <param name="c">The c.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator RGBQUAD(COLORREF c) => new() { Color = c };

		/// <summary>Performs an implicit conversion from <see cref="RGBQUAD"/> to <see cref="COLORREF"/>.</summary>
		/// <param name="c">The c.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator COLORREF(RGBQUAD c) => c.Color;

		/// <summary>Performs an implicit conversion from <see cref="System.Drawing.Color"/> to <see cref="RGBQUAD"/>.</summary>
		/// <param name="c">The c.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator RGBQUAD(System.Drawing.Color c) => new() { Color = c };

		/// <summary>Performs an implicit conversion from <see cref="RGBQUAD"/> to <see cref="System.Drawing.Color"/>.</summary>
		/// <param name="c">The c.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator System.Drawing.Color(RGBQUAD c) => c.Color;
	}
}