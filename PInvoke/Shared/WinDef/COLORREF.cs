using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>The COLORREF value is used to specify an RGB color in the form <c>0x00bbggrr</c>.</summary>
	// typedef DWORD COLORREF;typedef DWORD* LPCOLORREF; https://msdn.microsoft.com/en-us/library/windows/desktop/dd183449(v=vs.85).aspx
	[PInvokeData("Windef.h", MSDNShortId = "dd183449")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	public struct COLORREF
	{
		/// <summary>The DWORD value</summary>
		[FieldOffset(0)]
		private uint Value;

		/// <summary>The intensity of the red color.</summary>
		[FieldOffset(0)]
		public byte R;

		/// <summary>The intensity of the green color.</summary>
		[FieldOffset(1)]
		public byte G;

		/// <summary>The intensity of the blue color.</summary>
		[FieldOffset(2)]
		public byte B;

		private const uint CLR_NONE = 0xFFFFFFFF;
		private const uint CLR_DEFAULT = 0xFF000000;

		/// <summary>Initializes a new instance of the <see cref="COLORREF"/> struct.</summary>
		/// <param name="r">The intensity of the red color.</param>
		/// <param name="g">The intensity of the green color.</param>
		/// <param name="b">The intensity of the blue color.</param>
		public COLORREF(byte r, byte g, byte b)
		{
			Value = 0;
			R = r;
			G = g;
			B = b;
		}

		/// <summary>Initializes a new instance of the <see cref="COLORREF"/> struct.</summary>
		/// <param name="value">The packed DWORD value.</param>
		public COLORREF(uint value)
		{
			R = 0;
			G = 0;
			B = 0;
			Value = value & 0x00FFFFFF;
		}

		/// <summary>Initializes a new instance of the <see cref="COLORREF"/> struct.</summary>
		/// <param name="color">The color.</param>
		public COLORREF(System.Drawing.Color color) : this(color.R, color.G, color.B)
		{
			if (color == System.Drawing.Color.Transparent)
				Value = CLR_NONE;
		}

		/// <summary>Performs an implicit conversion from <see cref="COLORREF"/> to <see cref="System.Drawing.Color"/>.</summary>
		/// <param name="cr">The <see cref="COLORREF"/> value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator System.Drawing.Color(COLORREF cr) => cr.Value == CLR_NONE ? System.Drawing.Color.Transparent : System.Drawing.Color.FromArgb(cr.R, cr.G, cr.B);

		/// <summary>Performs an implicit conversion from <see cref="System.Drawing.Color"/> to <see cref="COLORREF"/>.</summary>
		/// <param name="clr">The <see cref="System.Drawing.Color"/> value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator COLORREF(System.Drawing.Color clr) => new(clr);

		/// <summary>Performs an implicit conversion from <see cref="System.ValueTuple{R, G, B}"/> to <see cref="COLORREF"/>.</summary>
		/// <param name="clr">The tuple containing the R, G, and B values.</param>
		/// <returns>The resulting <see cref="COLORREF"/> instance from the conversion.</returns>
		public static implicit operator COLORREF((byte r, byte g, byte b) clr) => new(clr.r, clr.g, clr.b);

		/// <summary>Performs an implicit conversion from <see cref="COLORREF"/> to <see cref="System.UInt32"/>.</summary>
		/// <param name="cr">The <see cref="COLORREF"/> value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator uint(COLORREF cr) => cr.Value;

		/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="COLORREF"/>.</summary>
		/// <param name="value">The <see cref="uint"/> value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator COLORREF(uint value) => new(value);

		/// <summary>Static reference for CLR_NONE representing no color.</summary>
		public static COLORREF None = new(CLR_NONE);

		/// <summary>Static reference for CLR_DEFAULT representing the default color.</summary>
		public static COLORREF Default = new(0xFF000000);

		/// <inheritdoc />
		public override string ToString() => ((System.Drawing.Color)this).ToString();
	}
}