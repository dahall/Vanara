using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>
		/// The BLENDFUNCTION structure controls blending by specifying the blending functions for source and destination bitmaps.
		/// </summary>
		/// <remarks>See information on how this function determines the resulting values on <a href="https://msdn.microsoft.com/en-us/library/dd183393(v=vs.85).aspx">MSDN</a>.</remarks>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Wingdi.h", MSDNShortId = "dd183393")]
		public struct BLENDFUNCTION
		{
			/// <summary>
			/// The source blend operation. Currently, the only source and destination blend operation that has been defined is AC_SRC_OVER. For details, see the
			/// following Remarks section.
			/// </summary>
			public byte BlendOp;

			/// <summary>Must be zero.</summary>
			public byte BlendFlags;

			/// <summary>
			/// Specifies an alpha transparency value to be used on the entire source bitmap. The SourceConstantAlpha value is combined with any per-pixel alpha
			/// values in the source bitmap. If you set SourceConstantAlpha to 0, it is assumed that your image is transparent. Set the SourceConstantAlpha value
			/// to 255 (opaque) when you only want to use per-pixel alpha values.
			/// </summary>
			public byte SourceConstantAlpha;

			/// <summary>
			/// This member controls the way the source and destination bitmaps are interpreted. AlphaFormat has the following value.
			/// <para>
			/// <c>AC_SRC_ALPHA</c> This flag is set when the bitmap has an Alpha channel (that is, per-pixel alpha). Note that the APIs use premultiplied alpha,
			/// which means that the red, green and blue channel values in the bitmap must be premultiplied with the alpha channel value. For example, if the
			/// alpha channel value is x, the red, green and blue channels must be multiplied by x and divided by 0xff prior to the call.
			/// </para>
			/// </summary>
			public byte AlphaFormat;

			/// <summary>Initializes a new instance of the <see cref="BLENDFUNCTION"/> struct and sets the alpha value.</summary>
			/// <param name="alpha">The alpha.</param>
			public BLENDFUNCTION(byte alpha)
			{
				// AC_SRC_OVER is the only possible value for BlendOp and it equals 0
				BlendOp = 0;
				BlendFlags = 0;
				SourceConstantAlpha = alpha;

				// AC_SRC_ALPHA is the only possible value for AlphaFormat and it equals 1
				AlphaFormat = 1;
			}

			public bool IsEmpty => BlendOp == 0 && BlendFlags == 0 && AlphaFormat == 0 && SourceConstantAlpha == 0;
		}
	}
}