using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>The RGBQUAD structure describes a color consisting of relative intensities of red, green, and blue.</summary>
[PInvokeData("Wingdi.h", MSDNShortId = "dd162938")]
[StructLayout(LayoutKind.Sequential, Size = 4)]
public struct RGBQUAD : IEquatable<RGBQUAD>
{
	/// <summary>The intensity of blue in the color.</summary>
	public byte rgbBlue;

	/// <summary>The intensity of green in the color.</summary>
	public byte rgbGreen;

	/// <summary>The intensity of red in the color.</summary>
	public byte rgbRed;

	/// <summary>This member is reserved and must be zero.</summary>
	public byte rgbReserved;

	/// <summary>Initializes a new instance of the <see cref="RGBQUAD"/> struct.</summary>
	/// <param name="r">The intensity of the red color.</param>
	/// <param name="g">The intensity of the green color.</param>
	/// <param name="b">The intensity of the blue color.</param>
	public RGBQUAD(byte r, byte g, byte b)
	{
		rgbRed = r;
		rgbGreen = g;
		rgbBlue = b;
		rgbReserved = 0;
	}

	/// <summary>Initializes a new instance of the <see cref="RGBQUAD"/> struct from a DWORD (<see cref="uint"/>) value.</summary>
	/// <param name="dword">The 32-bit value with R, G and B values packed in the first 3 bytes.</param>
	public RGBQUAD(uint dword)
	{
		unsafe { this = *(RGBQUAD*)&dword; }
	}

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

	/// <inheritdoc/>
	public override bool Equals(object? obj) => obj is RGBQUAD q && Equals(q);

	/// <summary>Determines whether the specified object is equal to the current object.</summary>
	/// <param name="q">The object to compare with the current object.</param>
	/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
	public bool Equals(RGBQUAD q) => q.rgbBlue == rgbBlue && q.rgbGreen == rgbGreen && q.rgbRed == rgbRed && q.rgbReserved == rgbReserved;

	/// <inheritdoc/>
	public override int GetHashCode() => unchecked((int)(uint)this);

	/// <inheritdoc/>
	public override string ToString() => $"{{R={rgbRed},G={rgbGreen},B={rgbBlue}}}";

	/// <summary>Performs an implicit conversion from <see cref="RGBQUAD"/> to <see cref="uint"/>.</summary>
	/// <param name="c">The <see cref="RGBQUAD"/> value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator uint(RGBQUAD c) { unsafe { return *(uint*)&c; } }

	/// <summary>Performs an implicit conversion from <see cref="COLORREF"/> to <see cref="RGBQUAD"/>.</summary>
	/// <param name="c">The <see cref="COLORREF"/> value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator RGBQUAD(COLORREF c) => new() { Color = c };

	/// <summary>Performs an implicit conversion from <see cref="RGBQUAD"/> to <see cref="COLORREF"/>.</summary>
	/// <param name="c">The <see cref="RGBQUAD"/> value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator COLORREF(RGBQUAD c) => c.Color;

	/// <summary>Performs an implicit conversion from <see cref="System.Drawing.Color"/> to <see cref="RGBQUAD"/>.</summary>
	/// <param name="c">The <see cref="System.Drawing.Color"/> value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator RGBQUAD(System.Drawing.Color c) => new() { Color = c };

	/// <summary>Performs an implicit conversion from <see cref="RGBQUAD"/> to <see cref="System.Drawing.Color"/>.</summary>
	/// <param name="c">The <see cref="RGBQUAD"/> value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator System.Drawing.Color(RGBQUAD c) => c.Color;
}