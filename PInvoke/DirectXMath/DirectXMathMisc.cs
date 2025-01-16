using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

public static partial class DirectXMath
{
	/// <summary>Adjusts the contrast value of a color.</summary>
	/// <param name="vColor"><b>XMVECTOR</b> describing the color. Each of the components of <i>C</i> should be in the range 0.0f to 1.0f.</param>
	/// <param name="fContrast">
	/// Contrast value. This parameter linearly interpolates between 50 percent gray and the color <i>C</i>. If this parameter is 0.0f, the
	/// returned color is 50 percent gray. If this parameter is 1.0f, the returned color is the original color.
	/// </param>
	/// <returns>Returns an <b>XMVECTOR</b> describing the color resulting from the contrast adjustment.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>XMVECTOR colorOut; colorOut.x = (C.x - 0.5f) * Contrast + 0.5f; colorOut.y = (C.y - 0.5f) * Contrast + 0.5f; colorOut.z = (C.z -
	/// 0.5f) * Contrast + 0.5f; colorOut.w = C.w; return colorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcoloradjustcontrast XMVECTOR XM_CALLCONV
	// XMColorAdjustContrast( [in] FXMVECTOR C, [in] float Contrast ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorAdjustContrast")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMColorAdjustContrast(in FXMVECTOR vColor, float fContrast) =>
		// Result = (vColor - 0.5f) * fContrast + 0.5f;

		new((vColor[0] - 0.5f) * fContrast + 0.5f, (vColor[1] - 0.5f) * fContrast + 0.5f, (vColor[2] - 0.5f) * fContrast + 0.5f, vColor[3]); // Leave W untouched

	/// <summary>Adjusts the saturation value of a color.</summary>
	/// <param name="vColor"><b>XMVECTOR</b> describing the color. Each of the components of <i>C</i> should be in the range 0.0f to 1.0f.</param>
	/// <param name="fSaturation">
	/// Saturation value. This parameter linearly interpolates between the color converted to gray-scale and the original color, <i>C</i>.
	/// If <i>Saturation</i> is 0.0f, the function returns the gray-scale color. If <i>Saturation</i> is 1.0f, the function returns the
	/// original color.
	/// </param>
	/// <returns>Returns an <b>XMVECTOR</b> describing the color resulting from the saturation adjustment.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>XMVector colorOut; // Approximate values for each component's contribution to luminance. // Based upon the NTSC standard
	/// described in ITU-R Recommendation BT.709. float Luminance = 0.2125f * C.x + 0.7154f * C.y + 0.0721f * C.z; colorOut.x = (C.x -
	/// Luminance) * Saturation + Luminance; colorOut.y = (C.y - Luminance) * Saturation + Luminance; colorOut.z = (C.z - Luminance) *
	/// Saturation + Luminance; colorOut.w = C.w; return colorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcoloradjustsaturation XMVECTOR XM_CALLCONV
	// XMColorAdjustSaturation( [in] FXMVECTOR C, [in] float Saturation ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorAdjustSaturation")]
	public static XMVECTOR XMColorAdjustSaturation(in FXMVECTOR vColor, float fSaturation)
	{
		// Luminance.ref[] 2125f = new[] ref = new[] new = new new[] C = new 2125f[0] + 0.ref 7154f C[1] + 0.ref 0721f C[2]; Result = (C -
		// Luminance) * Saturation + Luminance;

		XMVECTORF32 gvLuminance = new(0.2125f, 0.7154f, 0.0721f, 0.0f);
		float fLuminance = vColor[0] * gvLuminance[0] + vColor[1] * gvLuminance[1] + vColor[2] * gvLuminance[2];
		return new((vColor[0] - fLuminance) * fSaturation + fLuminance, (vColor[1] - fLuminance) * fSaturation + fLuminance,
			(vColor[2] - fLuminance) * fSaturation + fLuminance, vColor[3]);
	}

	/// <summary>Tests for the equality of two colors.</summary>
	/// <param name="C1"><b>XMVECTOR</b> describing the first color to compare.</param>
	/// <param name="C2"><b>XMVECTOR</b> describing the second color to compare.</param>
	/// <returns>Returns true if each of the components of the two colors are equal, or false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorequal bool XM_CALLCONV XMColorEqual( [in]
	// FXMVECTOR C1, [in] FXMVECTOR C2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMColorEqual(in FXMVECTOR C1, in FXMVECTOR C2) => XMVector4Equal(C1, C2);

	/// <summary>Tests whether all the components of the first color are greater than the corresponding components in the second color.</summary>
	/// <param name="C1"><b>XMVECTOR</b> describing the first color to compare.</param>
	/// <param name="C2"><b>XMVECTOR</b> describing the second color to compare.</param>
	/// <returns>
	/// Returns true if every component of <i>C1</i> is greater than the corresponding component in <i>C2</i>. Returns false otherwise.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorgreater bool XM_CALLCONV XMColorGreater( [in]
	// FXMVECTOR C1, [in] FXMVECTOR C2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorGreater")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMColorGreater(in FXMVECTOR C1, in FXMVECTOR C2) => XMVector4Greater(C1, C2);

	/// <summary>
	/// Tests whether all the components of the first color are greater than or equal to the corresponding components of the second color.
	/// </summary>
	/// <param name="C1"><b>XMVECTOR</b> describing the first color to compare.</param>
	/// <param name="C2"><b>XMVECTOR</b> describing the second color to compare.</param>
	/// <returns>
	/// Returns true if every component of <i>C1</i> is greater than or equal to the corresponding component in <i>C2</i>. Returns false otherwise.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorgreaterorequal bool XM_CALLCONV
	// XMColorGreaterOrEqual( [in] FXMVECTOR C1, [in] FXMVECTOR C2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorGreaterOrEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMColorGreaterOrEqual(in FXMVECTOR C1, in FXMVECTOR C2) => XMVector4GreaterOrEqual(C1, C2);

	/// <summary>Converts HSL color values to RGB color values.</summary>
	/// <param name="hsl">
	/// Color value to convert. The X element is Hue (H), the Y element is Saturation (S), the Z element is Luminance (L), and the W element
	/// is Alpha. Each has a range of 0.0 to 1.0.
	/// </param>
	/// <returns>
	/// Returns the converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of hsl.w)
	/// . Each has a range of 0.0 to 1.0.
	/// </returns>
	/// <remarks>
	/// <para><b>Note</b>   <c>XMColorHSLToRGB</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorhsltorgb XMVECTOR XM_CALLCONV XMColorHSLToRGB(
	// [in] FXMVECTOR hsl ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorHSLToRGB")]
	public static XMVECTOR XMColorHSLToRGB(in FXMVECTOR hsl)
	{
		XMVECTORF32 oneThird = new(1.0f / 3.0f, 1.0f / 3.0f, 1.0f / 3.0f, 1.0f / 3.0f);

		XMVECTOR s = XMVectorSplatY(hsl);
		XMVECTOR l = XMVectorSplatZ(hsl);

		if (XMVector3NearEqual(s, XMVECTOR.g_XMZero, XMVECTOR.g_XMEpsilon))
		{
			// Achromatic
			return XMVectorSelect(hsl, l, XMVECTOR.g_XMSelect1110);
		}
		else
		{
			XMVECTOR h = XMVectorSplatX(hsl);

			FXMVECTOR q = XMVector3Less(l, XMVECTOR.g_XMOneHalf)
				? XMVectorMultiply(l, XMVectorAdd(XMVECTOR.g_XMOne, s))
				: XMVectorSubtract(XMVectorAdd(l, s), XMVectorMultiply(l, s));
			XMVECTOR p = XMVectorSubtract(XMVectorMultiply(XMVECTOR.g_XMTwo, l), q);

			XMVECTOR r = XMColorHue2Clr(p, q, XMVectorAdd(h, oneThird));
			XMVECTOR g = XMColorHue2Clr(p, q, h);
			XMVECTOR b = XMColorHue2Clr(p, q, XMVectorSubtract(h, oneThird));

			XMVECTOR rg = XMVectorSelect(g, r, XMVECTOR.g_XMSelect1000);
			XMVECTOR ba = XMVectorSelect(hsl, b, XMVECTOR.g_XMSelect1110);

			return XMVectorSelect(ba, rg, XMVECTOR.g_XMSelect1100);
		}
	}

	/// <summary>Converts HSV color values to RGB color values.</summary>
	/// <param name="hsv">
	/// Color value to convert. The X element is Hue (H), the Y element is Saturation (S), the Z element is Value (V), and the W element is
	/// Alpha. Each has a range of 0.0 to 1.0.
	/// </param>
	/// <returns>
	/// Returns the converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of hsv.w)
	/// . Each has a range of 0.0 to 1.0.
	/// </returns>
	/// <remarks>
	/// <para><b>Note</b>   <c>XMColorHSVToRGB</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorhsvtorgb XMVECTOR XM_CALLCONV XMColorHSVToRGB(
	// [in] FXMVECTOR hsv ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorHSVToRGB")]
	public static XMVECTOR XMColorHSVToRGB(in FXMVECTOR hsv)
	{
		XMVECTOR h = XMVectorSplatX(hsv);
		XMVECTOR s = XMVectorSplatY(hsv);
		XMVECTOR v = XMVectorSplatZ(hsv);

		XMVECTOR h6 = XMVectorMultiply(h, XMVECTOR.g_XMSix);

		XMVECTOR i = XMVectorFloor(h6);
		XMVECTOR f = XMVectorSubtract(h6, i);

		// p = ref v (1-s)
		XMVECTOR p = XMVectorMultiply(v, XMVectorSubtract(XMVECTOR.g_XMOne, s));

		// q = ref v (1-ref f s)
		XMVECTOR q = XMVectorMultiply(v, XMVectorSubtract(XMVECTOR.g_XMOne, XMVectorMultiply(f, s)));

		// t = ref v (1 - (1-f)*s)
		XMVECTOR t = XMVectorMultiply(v, XMVectorSubtract(XMVECTOR.g_XMOne, XMVectorMultiply(XMVectorSubtract(XMVECTOR.g_XMOne, f), s)));

		var ii = (int)XMVectorGetX(XMVectorMod(i, XMVECTOR.g_XMSix));
		var rgb = ii switch
		{
			// rgb = vtp
			0 => XMVectorSelect(p, XMVectorSelect(t, v, XMVECTOR.g_XMSelect1000), XMVECTOR.g_XMSelect1100),
			// rgb = qvp
			1 => XMVectorSelect(p, XMVectorSelect(v, q, XMVECTOR.g_XMSelect1000), XMVECTOR.g_XMSelect1100),
			// rgb = pvt
			2 => XMVectorSelect(t, XMVectorSelect(v, p, XMVECTOR.g_XMSelect1000), XMVECTOR.g_XMSelect1100),
			// rgb = pqv
			3 => XMVectorSelect(v, XMVectorSelect(q, p, XMVECTOR.g_XMSelect1000), XMVECTOR.g_XMSelect1100),
			// rgb = tpv
			4 => XMVectorSelect(v, XMVectorSelect(p, t, XMVECTOR.g_XMSelect1000), XMVECTOR.g_XMSelect1100),
			// rgb = vpq
			_ => XMVectorSelect(q, XMVectorSelect(p, v, XMVECTOR.g_XMSelect1000), XMVECTOR.g_XMSelect1100),
		};
		return XMVectorSelect(hsv, rgb, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Tests to see whether any of the components of a color are either positive or negative infinity.</summary>
	/// <param name="C"><b>XMVECTOR</b> describing the color.</param>
	/// <returns>Returns true if any components of <i>C</i> are either positive or negative infinity. Returns false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorisinfinite bool XM_CALLCONV XMColorIsInfinite(
	// [in] FXMVECTOR C ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorIsInfinite")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMColorIsInfinite(in FXMVECTOR C) => XMVector4IsInfinite(C);

	/// <summary>Tests to see whether any component of a color is not a number (NaN).</summary>
	/// <param name="C"><b>XMVECTOR</b> describing the color.</param>
	/// <returns>Returns true if any components of <i>C</i> are NaN, or false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorisnan bool XM_CALLCONV XMColorIsNaN( [in]
	// FXMVECTOR C ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorIsNaN")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMColorIsNaN(in FXMVECTOR C) => XMVector4IsNaN(C);

	/// <summary>Tests whether all the components of the first color are less than the corresponding components of the second color.</summary>
	/// <param name="C1"><b>XMVECTOR</b> describing the first color to compare.</param>
	/// <param name="C2"><b>XMVECTOR</b> describing the second color to compare.</param>
	/// <returns>Returns true if every component of <i>C1</i> is less than the corresponding component in <i>C2</i>. Returns false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorless bool XM_CALLCONV XMColorLess( [in]
	// FXMVECTOR C1, [in] FXMVECTOR C2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorLess")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMColorLess(in FXMVECTOR C1, in FXMVECTOR C2) => XMVector4Less(C1, C2);

	/// <summary>
	/// Tests whether all the components of the first color are less than or equal to the corresponding components of the second color.
	/// </summary>
	/// <param name="C1"><b>XMVECTOR</b> describing the first color to compare.</param>
	/// <param name="C2"><b>XMVECTOR</b> describing the second color to compare.</param>
	/// <returns>
	/// Returns true if every component of <i>C1</i> is less than or equal to the corresponding component in <i>C2</i>. Returns false otherwise.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorlessorequal bool XM_CALLCONV
	// XMColorLessOrEqual( [in] FXMVECTOR C1, [in] FXMVECTOR C2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorLessOrEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMColorLessOrEqual(in FXMVECTOR C1, in FXMVECTOR C2) => XMVector4LessOrEqual(C1, C2);

	/// <summary>Blends two colors by multiplying corresponding components together.</summary>
	/// <param name="C1"><b>XMVECTOR</b> describing the first color.</param>
	/// <param name="C2"><b>XMVECTOR</b> describing the second color.</param>
	/// <returns>Returns an <b>XMVECTOR</b> describing the color resulting from the modulation.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>XMVECTOR colorOut; colorOut.x = C1.x * C2.x; colorOut.y = C1.y * C2.y; colorOut.z = C1.z * C2.z; colorOut.w = C1.w * C2.w; return colorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolormodulate XMVECTOR XM_CALLCONV XMColorModulate(
	// [in] FXMVECTOR C1, [in] FXMVECTOR C2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorModulate")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMColorModulate(in FXMVECTOR C1, in FXMVECTOR C2) => XMVectorMultiply(C1, C2);

	/// <summary>Determines the negative RGB color value of a color.</summary>
	/// <param name="vColor"><b>XMVECTOR</b> describing the color. Each of the components of <i>C</i> should be in the range 0.0f to 1.0f.</param>
	/// <returns>
	/// Returns an <b>XMVECTOR</b> describing the negative color. The w-component (alpha) is copied unmodified from the input vector.
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode shows you the operation of the function.</para>
	/// <para>
	/// <c>XMVECTOR colorOut; colorOut.x = 1.0f - C.x; colorOut.y = 1.0f - C.y; colorOut.z = 1.0f - C.z; colorOut.w = C.w; return colorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolornegative XMVECTOR XM_CALLCONV XMColorNegative(
	// [in] FXMVECTOR C ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorNegative")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMColorNegative(in FXMVECTOR vColor) => new(1.0f - vColor[0], 1.0f - vColor[1], 1.0f - vColor[2], vColor[3]);

	/// <summary>Tests to see whether two colors are unequal.</summary>
	/// <param name="C1"><b>XMVECTOR</b> describing the first color to compare.</param>
	/// <param name="C2"><b>XMVECTOR</b> describing the second color to compare.</param>
	/// <returns>
	/// Returns true if any component of <i>C1</i> is different from the corresponding component of <i>C2</i>. Returns false otherwise.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolornotequal bool XM_CALLCONV XMColorNotEqual( [in]
	// FXMVECTOR C1, [in] FXMVECTOR C2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorNotEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMColorNotEqual(in FXMVECTOR C1, in FXMVECTOR C2) => XMVector4NotEqual(C1, C2);

	/// <summary>Converts RGB color values to HSL color values.</summary>
	/// <param name="rgb">
	/// Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.
	/// </param>
	/// <returns>
	/// Returns the converted color value. The X element is Hue (H), the Y element is Saturation (S), the Z element is Luminance (L), and
	/// the W element is Alpha (a copy of the input's Alpha value). Each has a range of 0.0 to 1.0.
	/// </returns>
	/// <remarks>
	/// <para><b>Note</b>   <c>XMColorRGBToHSL</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorrgbtohsl XMVECTOR XM_CALLCONV XMColorRGBToHSL(
	// [in] FXMVECTOR rgb ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorRGBToHSL")]
	public static XMVECTOR XMColorRGBToHSL(in FXMVECTOR rgb)
	{
		XMVECTOR r = XMVectorSplatX(rgb);
		XMVECTOR g = XMVectorSplatY(rgb);
		XMVECTOR b = XMVectorSplatZ(rgb);

		XMVECTOR min = XMVectorMin(r, XMVectorMin(g, b));
		XMVECTOR max = XMVectorMax(r, XMVectorMax(g, b));

		XMVECTOR l = XMVectorMultiply(XMVectorAdd(min, max), XMVECTOR.g_XMOneHalf);

		XMVECTOR d = XMVectorSubtract(max, min);

		XMVECTOR la = XMVectorSelect(rgb, l, XMVECTOR.g_XMSelect1110);

		if (XMVector3Less(d, XMVECTOR.g_XMEpsilon))
		{
			// Achromatic, assume H and S of 0
			return XMVectorSelect(la, XMVECTOR.g_XMZero, XMVECTOR.g_XMSelect1100);
		}
		else
		{
			XMVECTOR s, h;

			XMVECTOR d2 = XMVectorAdd(min, max);

			if (XMVector3Greater(l, XMVECTOR.g_XMOneHalf))
			{
				// d / (2-max-min)
				s = XMVectorDivide(d, XMVectorSubtract(XMVECTOR.g_XMTwo, d2));
			}
			else
			{
				// d / (max+min)
				s = XMVectorDivide(d, d2);
			}

			if (XMVector3Equal(r, max))
			{
				// Red is max
				h = XMVectorDivide(XMVectorSubtract(g, b), d);
			}
			else if (XMVector3Equal(g, max))
			{
				// Green is max
				h = XMVectorDivide(XMVectorSubtract(b, r), d);
				h = XMVectorAdd(h, XMVECTOR.g_XMTwo);
			}
			else
			{
				// Blue is max
				h = XMVectorDivide(XMVectorSubtract(r, g), d);
				h = XMVectorAdd(h, XMVECTOR.g_XMFour);
			}

			h = XMVectorDivide(h, XMVECTOR.g_XMSix);

			if (XMVector3Less(h, XMVECTOR.g_XMZero))
				h = XMVectorAdd(h, XMVECTOR.g_XMOne);

			XMVECTOR lha = XMVectorSelect(la, h, XMVECTOR.g_XMSelect1100);
			return XMVectorSelect(s, lha, XMVECTOR.g_XMSelect1011);
		}
	}

	/// <summary>Converts RGB color values to HSV color values.</summary>
	/// <param name="rgb">
	/// Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.
	/// </param>
	/// <returns>
	/// Returns the converted color value. The X element is Hue (H), the Y element is Saturation (S), the Z element is Value (V), and the W
	/// element is Alpha (a copy of rgb.w). Each has a range of 0.0 to 1.0.
	/// </returns>
	/// <remarks>
	/// <para><b>Note</b>   <c>XMColorRGBToHSV</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorrgbtohsv XMVECTOR XM_CALLCONV XMColorRGBToHSV(
	// [in] FXMVECTOR rgb ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorRGBToHSV")]
	public static XMVECTOR XMColorRGBToHSV(in FXMVECTOR rgb)
	{
		XMVECTOR r = XMVectorSplatX(rgb);
		XMVECTOR g = XMVectorSplatY(rgb);
		XMVECTOR b = XMVectorSplatZ(rgb);

		XMVECTOR min = XMVectorMin(r, XMVectorMin(g, b));
		XMVECTOR v = XMVectorMax(r, XMVectorMax(g, b));

		XMVECTOR d = XMVectorSubtract(v, min);

		XMVECTOR s = XMVector3NearEqual(v, XMVECTOR.g_XMZero, XMVECTOR.g_XMEpsilon) ? XMVECTOR.g_XMZero : XMVectorDivide(d, v);

		if (XMVector3Less(d, XMVECTOR.g_XMEpsilon))
		{
			// Achromatic, assume H of 0
			XMVECTOR hv = XMVectorSelect(v, XMVECTOR.g_XMZero, XMVECTOR.g_XMSelect1000);
			XMVECTOR hva = XMVectorSelect(rgb, hv, XMVECTOR.g_XMSelect1110);
			return XMVectorSelect(s, hva, XMVECTOR.g_XMSelect1011);
		}
		else
		{
			XMVECTOR h;

			if (XMVector3Equal(r, v))
			{
				// Red is max
				h = XMVectorDivide(XMVectorSubtract(g, b), d);

				if (XMVector3Less(g, b))
					h = XMVectorAdd(h, XMVECTOR.g_XMSix);
			}
			else if (XMVector3Equal(g, v))
			{
				// Green is max
				h = XMVectorDivide(XMVectorSubtract(b, r), d);
				h = XMVectorAdd(h, XMVECTOR.g_XMTwo);
			}
			else
			{
				// Blue is max
				h = XMVectorDivide(XMVectorSubtract(r, g), d);
				h = XMVectorAdd(h, XMVECTOR.g_XMFour);
			}

			h = XMVectorDivide(h, XMVECTOR.g_XMSix);

			XMVECTOR hv = XMVectorSelect(v, h, XMVECTOR.g_XMSelect1000);
			XMVECTOR hva = XMVectorSelect(rgb, hv, XMVECTOR.g_XMSelect1110);
			return XMVectorSelect(s, hva, XMVECTOR.g_XMSelect1011);
		}
	}

	/// <summary>Converts an RGB color vector to sRGB.</summary>
	/// <param name="rgb">The original RGB color vector.</param>
	/// <returns>
	/// Returns an <b>XMVECTOR</b> describing the converted sRGBA color vector. The x element is red, the y element is green, the z element
	/// is blue, and the w element is the alpha value (which is a copy of rgb.w). Each element value has a range of 0.0 to 1.0 in the sRGB colorspace.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorrgbtosrgb XMVECTOR XM_CALLCONV
	// XMColorRGBToSRGB( FXMVECTOR rgb ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorRGBToSRGB")]
	public static XMVECTOR XMColorRGBToSRGB(in FXMVECTOR rgb)
	{
		XMVECTORF32 Cutoff = new(0.0031308f, 0.0031308f, 0.0031308f, 1f);
		XMVECTORF32 Linear = new(12.92f, 12.92f, 12.92f, 1f);
		XMVECTORF32 Scale = new(1.055f, 1.055f, 1.055f, 1f);
		XMVECTORF32 Bias = new(0.055f, 0.055f, 0.055f, 0f);
		XMVECTORF32 InvGamma = new(1.0f / 2.4f, 1.0f / 2.4f, 1.0f / 2.4f, 1f);

		XMVECTOR V = XMVectorSaturate(rgb);
		XMVECTOR V0 = XMVectorMultiply(V, Linear);
		XMVECTOR V1 = XMVectorSubtract(XMVectorMultiply(Scale, XMVectorPow(V, InvGamma)), Bias);
		XMVECTOR select = XMVectorLess(V, Cutoff);
		V = XMVectorSelect(V1, V0, select);
		return XMVectorSelect(rgb, V, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts RGB color values to XYZ color values.</summary>
	/// <param name="rgb">
	/// Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.
	/// </param>
	/// <returns>
	/// Returns the converted color value with the tristimulus values of X, Y, and Z in the corresponding element, and the W element with
	/// Alpha (a copy of rgb.w). Each has a range of 0.0 to 1.0.
	/// </returns>
	/// <remarks>
	/// <para>Uses the CIE XYZ colorspace.</para>
	/// <para><b>Note</b>   <c>XMColorRGBToXYZ</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorrgbtoxyz XMVECTOR XM_CALLCONV XMColorRGBToXYZ(
	// [in] FXMVECTOR rgb ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorRGBToXYZ")]
	public static XMVECTOR XMColorRGBToXYZ(in FXMVECTOR rgb)
	{
		XMVECTORF32 Scale0 = new(0.4887180f, 0.1762044f, 0.0000000f, 0.0f);
		XMVECTORF32 Scale1 = new(0.3106803f, 0.8129847f, 0.0102048f, 0.0f);
		XMVECTORF32 Scale2 = new(0.2006017f, 0.0108109f, 0.9897952f, 0.0f);
		XMVECTORF32 Scale = new(1f / 0.17697f, 1f / 0.17697f, 1f / 0.17697f, 0.0f);

		XMMATRIX M = new(Scale0, Scale1, Scale2, XMVECTOR.g_XMZero);
		XMVECTOR clr = XMVectorMultiply(XMVector3Transform(rgb, M), Scale);

		return XMVectorSelect(rgb, clr, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts RGB color values to YUV color values.</summary>
	/// <param name="rgb">
	/// Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.
	/// </param>
	/// <returns>
	/// Returns the converted color value in Luma-Chrominance (YUV) aka YCbCr. The X element contains Luma (Y, 0.0 to 1.0), the Y element
	/// contains Blue-difference chroma (-0.5 to 0.5), the Z element contains the Red-difference chroma (-0.5 to 0.5), and the W element
	/// contains the Alpha (a copy of rgb.w).
	/// </returns>
	/// <remarks>
	/// <para>Converts using ITU-R BT.601/CCIR 601 W(r) = 0.299 W(b) = 0.114 U(max) = 0.436 V(max) = 0.615.</para>
	/// <para><b>Note</b>   <c>XMColorRGBToYUV</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorrgbtoyuv XMVECTOR XM_CALLCONV XMColorRGBToYUV(
	// [in] FXMVECTOR rgb ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorRGBToYUV")]
	public static XMVECTOR XMColorRGBToYUV(in FXMVECTOR rgb)
	{
		XMVECTORF32 Scale0 = new(0.299f, -0.147f, 0.615f, 0.0f);
		XMVECTORF32 Scale1 = new(0.587f, -0.289f, -0.515f, 0.0f);
		XMVECTORF32 Scale2 = new(0.114f, 0.436f, -0.100f, 0.0f);

		XMMATRIX M = new(Scale0, Scale1, Scale2, XMVECTOR.g_XMZero);
		XMVECTOR clr = XMVector3Transform(rgb, M);

		return XMVectorSelect(rgb, clr, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts RGB color values to YUV HD color values.</summary>
	/// <param name="rgb">
	/// Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.
	/// </param>
	/// <returns>
	/// Returns the converted color value in Luma-Chrominance (YUV) aka YCbCr. The X element contains Luma (Y, 0.0 to 1.0), the Y element
	/// contains Blue-difference chroma (-0.5 to 0.5), the Z element contains the Red-difference chroma (-0.5 to 0.5), and the W element
	/// contains the Alpha (a copy of rgb.w).
	/// </returns>
	/// <remarks>
	/// <para>Converts using ITU-R BT.709 W(r) = 0.2126 W(b) = 0.0722 U(max) = 0.436 V(max) = 0.615.</para>
	/// <para><b>Note</b>   <c>XMColorRGBToYUV_HD</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorrgbtoyuv_hd XMVECTOR XM_CALLCONV
	// XMColorRGBToYUV_HD( [in] FXMVECTOR rgb ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorRGBToYUV_HD")]
	public static XMVECTOR XMColorRGBToYUV_HD(in FXMVECTOR rgb)
	{
		XMVECTORF32 Scale0 = new(0.2126f, -0.0997f, 0.6150f, 0.0f);
		XMVECTORF32 Scale1 = new(0.7152f, -0.3354f, -0.5586f, 0.0f);
		XMVECTORF32 Scale2 = new(0.0722f, 0.4351f, -0.0564f, 0.0f);

		XMMATRIX M = new(Scale0, Scale1, Scale2, XMVECTOR.g_XMZero);
		XMVECTOR clr = XMVector3Transform(rgb, M);

		return XMVectorSelect(rgb, clr, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts RGB color values to YUV UHD color values.</summary>
	/// <param name="rgb">
	/// Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to 1.0.
	/// </param>
	/// <returns>
	/// Returns the converted color value in Luma-Chrominance (YUV) aka YCbCr. The X element contains Luma (Y, 0.0 to 1.0), the Y element
	/// contains Blue-difference chroma (-0.5 to 0.5), the Z element contains the Red-difference chroma (-0.5 to 0.5), and the W element
	/// contains the Alpha (a copy of rgb.w).
	/// </returns>
	/// <remarks>
	/// <para>Converts using ITU-R BT.2020 W(r) = 0.2627 W(b) = 0.0-593 U(max) = 0.4351 V(max) = 0.6150.</para>
	/// <para>
	/// <para>This function is new to DirectXMath 3.16</para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorrgbtoyuv_uhd XMVECTOR XM_CALLCONV
	// XMColorRGBToYUV_UHD( [in] FXMVECTOR rgb ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorRGBToYUV_UHD")]
	public static XMVECTOR XMColorRGBToYUV_UHD(in FXMVECTOR rgb)
	{
		XMVECTORF32 Scale0 = new(0.2627f, -0.1215f, 0.6150f, 0.0f);
		XMVECTORF32 Scale1 = new(0.6780f, -0.3136f, -0.5655f, 0.0f);
		XMVECTORF32 Scale2 = new(0.0593f, 0.4351f, -0.0495f, 0.0f);

		XMMATRIX M = new(Scale0, Scale1, Scale2, XMVECTOR.g_XMZero);
		XMVECTOR clr = XMVector3Transform(rgb, M);

		return XMVectorSelect(rgb, clr, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts an sRGB color vector to RGB.</summary>
	/// <param name="srgb">An sRGB color vector.</param>
	/// <returns>
	/// Returns an <b>XMVECTOR</b> describing the converted RGBA color vector. The x element is red, the y element is green, the z element
	/// is blue, and the w element is the alpha value (which is a copy of srgb.w). Each element value has a range of 0.0 to 1.0 in the RGB colorspace.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorsrgbtorgb XMVECTOR XM_CALLCONV
	// XMColorSRGBToRGB( FXMVECTOR srgb ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorSRGBToRGB")]
	public static XMVECTOR XMColorSRGBToRGB(in FXMVECTOR srgb)
	{
		XMVECTORF32 Cutoff = new(0.04045f, 0.04045f, 0.04045f, 1f);
		XMVECTORF32 ILinear = new(1f / 12.92f, 1f / 12.92f, 1f / 12.92f, 1f);
		XMVECTORF32 Scale = new(1f / 1.055f, 1f / 1.055f, 1f / 1.055f, 1f);
		XMVECTORF32 Bias = new(0.055f, 0.055f, 0.055f, 0f);
		XMVECTORF32 Gamma = new(2.4f, 2.4f, 2.4f, 1f);

		XMVECTOR V = XMVectorSaturate(srgb);
		XMVECTOR V0 = XMVectorMultiply(V, ILinear);
		XMVECTOR V1 = XMVectorPow(XMVectorMultiply(XMVectorAdd(V, Bias), Scale), Gamma);
		XMVECTOR select = XMVectorGreater(V, Cutoff);
		V = XMVectorSelect(V0, V1, select);
		return XMVectorSelect(srgb, V, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts SRGB color values to XYZ color values.</summary>
	/// <param name="srgb">
	/// Color value to convert. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha. Each has a range of 0.0 to
	/// 1.0 and is in the linear sRGB colorspace.
	/// </param>
	/// <returns>
	/// Returns the converted color value with the tristimulus values of X, Y, and Z in the corresponding element, and the W element with
	/// Alpha (a copy of rgb.w). Each has a range of 0.0 to 1.0.
	/// </returns>
	/// <remarks>
	/// <para>Uses the CIE XYZ colorspace.</para>
	/// <para>The sRGB linear color space is defined as IEC 61966-2-1:1999.</para>
	/// <para><b>Note</b>   <c>XMColorSRGBToXYZ</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorsrgbtoxyz XMVECTOR XM_CALLCONV
	// XMColorSRGBToXYZ( [in] FXMVECTOR srgb ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorSRGBToXYZ")]
	public static XMVECTOR XMColorSRGBToXYZ(in FXMVECTOR srgb)
	{
		XMVECTORF32 Scale0 = new(0.4124f, 0.2126f, 0.0193f, 0.0f);
		XMVECTORF32 Scale1 = new(0.3576f, 0.7152f, 0.1192f, 0.0f);
		XMVECTORF32 Scale2 = new(0.1805f, 0.0722f, 0.9505f, 0.0f);
		XMVECTORF32 Cutoff = new(0.04045f, 0.04045f, 0.04045f, 0.0f);
		XMVECTORF32 Exp = new(2.4f, 2.4f, 2.4f, 1.0f);

		XMVECTOR sel = XMVectorGreater(srgb, Cutoff);

		// lclr = clr / 12.92
		XMVECTOR smallC = XMVectorDivide(srgb, XMVECTOR.g_XMsrgbScale);

		// lclr = pow((clr + a) / (1+a), 2.4 )
		XMVECTOR largeC = XMVectorPow(XMVectorDivide(XMVectorAdd(srgb, XMVECTOR.g_XMsrgbA), XMVECTOR.g_XMsrgbA1), Exp);

		XMVECTOR lclr = XMVectorSelect(smallC, largeC, sel);

		XMMATRIX M = new(Scale0, Scale1, Scale2, XMVECTOR.g_XMZero);
		XMVECTOR clr = XMVector3Transform(lclr, M);

		return XMVectorSelect(srgb, clr, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts XYZ color values to RGB color values.</summary>
	/// <param name="xyz">
	/// Color value to convert with the tristimulus values of X, Y, and Z in the corresponding element, and the W element with Alpha. Each
	/// has a range of 0.0 to 1.0
	/// </param>
	/// <returns>
	/// Returns the converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of
	/// xyz.w). Each has a range of 0.0 to 1.0.
	/// </returns>
	/// <remarks>
	/// <para>Uses the CIE XYZ colorspace.</para>
	/// <para><b>Note</b>   <c>XMColorXYZToRGB</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorxyztorgb XMVECTOR XM_CALLCONV XMColorXYZToRGB(
	// [in] FXMVECTOR xyz ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorXYZToRGB")]
	public static XMVECTOR XMColorXYZToRGB(in FXMVECTOR xyz)
	{
		XMVECTORF32 Scale0 = new(2.3706743f, -0.5138850f, 0.0052982f, 0.0f);
		XMVECTORF32 Scale1 = new(-0.9000405f, 1.4253036f, -0.0146949f, 0.0f);
		XMVECTORF32 Scale2 = new(-0.4706338f, 0.0885814f, 1.0093968f, 0.0f);
		XMVECTORF32 Scale = new(0.17697f, 0.17697f, 0.17697f, 0.0f);

		XMMATRIX M = new(Scale0, Scale1, Scale2, XMVECTOR.g_XMZero);
		XMVECTOR clr = XMVector3Transform(XMVectorMultiply(xyz, Scale), M);

		return XMVectorSelect(xyz, clr, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts XYZ color values to SRGB color values.</summary>
	/// <param name="xyz">
	/// Color value to convert with the tristimulus values of X, Y, and Z in the corresponding element, and the W element with Alpha. Each
	/// has a range of 0.0 to 1.0.
	/// </param>
	/// <returns>
	/// Returns the converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of
	/// xyz.w). Each has a range of 0.0 to 1.0 in the linear sRGB colorspace.
	/// </returns>
	/// <remarks>
	/// <para>Uses the CIE XYZ colorspace.</para>
	/// <para>The sRGB linear color space is defined as IEC 61966-2-1:1999.</para>
	/// <para><b>Note</b>   <c>XMColorXYZToSRGB</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcolorxyztosrgb XMVECTOR XM_CALLCONV
	// XMColorXYZToSRGB( [in] FXMVECTOR xyz ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorXYZToSRGB")]
	public static XMVECTOR XMColorXYZToSRGB(in FXMVECTOR xyz)
	{
		XMVECTORF32 Scale0 = new(3.2406f, -0.9689f, 0.0557f, 0.0f);
		XMVECTORF32 Scale1 = new(-1.5372f, 1.8758f, -0.2040f, 0.0f);
		XMVECTORF32 Scale2 = new(-0.4986f, 0.0415f, 1.0570f, 0.0f);
		XMVECTORF32 Cutoff = new(0.0031308f, 0.0031308f, 0.0031308f, 0.0f);
		XMVECTORF32 Exp = new(1.0f / 2.4f, 1.0f / 2.4f, 1.0f / 2.4f, 1.0f);

		XMMATRIX M = new(Scale0, Scale1, Scale2, XMVECTOR.g_XMZero);
		XMVECTOR lclr = XMVector3Transform(xyz, M);

		XMVECTOR sel = XMVectorGreater(lclr, Cutoff);

		// clr = 12.ref 92 lclr for lclr <= 0.0031308f
		XMVECTOR smallC = XMVectorMultiply(lclr, XMVECTOR.g_XMsrgbScale);

		// clr = (1+a)*pow(lclr, 1/2.4) - a for lclr > 0.0031308 (where a.055)
		XMVECTOR largeC = XMVectorSubtract(XMVectorMultiply(XMVECTOR.g_XMsrgbA1, XMVectorPow(lclr, Exp)), XMVECTOR.g_XMsrgbA);

		XMVECTOR clr = XMVectorSelect(smallC, largeC, sel);

		return XMVectorSelect(xyz, clr, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts YUV color values to RGB color values.</summary>
	/// <param name="yuv">
	/// Color value to convert in Luma-Chrominance (YUV) aka YCbCr. The X element contains Luma (Y, 0.0 to 1.0), the Y element contains
	/// Blue-difference chroma (U, -0.5 to 0.5), the Z element contains the Red-difference chroma (V, -0.5 to 0.5), and the W element
	/// contains the Alpha (0.0 to 1.0).
	/// </param>
	/// <returns>
	/// The converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of yuv.w). Each
	/// has a range of 0.0 to 1.0.
	/// </returns>
	/// <remarks>
	/// <para>Converts using ITU-R BT.601/CCIR 601 W(r) = 0.299 W(b) = 0.114 U(max) = 0.436 V(max) = 0.615.</para>
	/// <para><b>Note</b>   <c>XMColorYUVToRGB</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcoloryuvtorgb XMVECTOR XM_CALLCONV XMColorYUVToRGB(
	// [in] FXMVECTOR yuv ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorYUVToRGB")]
	public static XMVECTOR XMColorYUVToRGB(in FXMVECTOR yuv)
	{
		XMVECTORF32 Scale1 = new(0.0f, -0.395f, 2.032f, 0.0f);
		XMVECTORF32 Scale2 = new(1.140f, -0.581f, 0.0f, 0.0f);

		XMMATRIX M = new(XMVECTOR.g_XMOne, Scale1, Scale2, XMVECTOR.g_XMZero);
		XMVECTOR clr = XMVector3Transform(yuv, M);

		return XMVectorSelect(yuv, clr, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts YUV color values to RGB HD color values.</summary>
	/// <param name="yuv">
	/// Color value to convert in Luma-Chrominance (YUV) aka YCbCr. The X element contains Luma (Y, 0.0 to 1.0), the Y element contains
	/// Blue-difference chroma (U, -0.5 to 0.5), the Z element contains the Red-difference chroma (V, -0.5 to 0.5), and the W element
	/// contains the Alpha (0.0 to 1.0).
	/// </param>
	/// <returns>
	/// The converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of yuv.w). Each
	/// has a range of 0.0 to 1.0.
	/// </returns>
	/// <remarks>
	/// <para>Converts using ITU-R BT.709 W(r) = 0.2126 W(b) = 0.0722 U(max) = 0.436 V(max) = 0.615.</para>
	/// <para><b>Note</b>   <c>XMColorYUVToRGB_HD</c> is new for DirectXMath and is not available for XNAMath 2.x.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcoloryuvtorgb_hd XMVECTOR XM_CALLCONV
	// XMColorYUVToRGB_HD( [in] FXMVECTOR yuv ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorYUVToRGB_HD")]
	public static XMVECTOR XMColorYUVToRGB_HD(in FXMVECTOR yuv)
	{
		XMVECTORF32 Scale1 = new(0.0f, -0.2153f, 2.1324f, 0.0f);
		XMVECTORF32 Scale2 = new(1.2803f, -0.3806f, 0.0f, 0.0f);

		XMMATRIX M = new(XMVECTOR.g_XMOne, Scale1, Scale2, XMVECTOR.g_XMZero);
		XMVECTOR clr = XMVector3Transform(yuv, M);

		return XMVectorSelect(yuv, clr, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Converts YUV color values to RGB UHD color values.</summary>
	/// <param name="yuv">
	/// Color value to convert in Luma-Chrominance (YUV) aka YCbCr. The X element contains Luma (Y, 0.0 to 1.0), the Y element contains
	/// Blue-difference chroma (U, -0.5 to 0.5), the Z element contains the Red-difference chroma (V, -0.5 to 0.5), and the W element
	/// contains the Alpha (0.0 to 1.0).
	/// </param>
	/// <returns>
	/// The converted color value. X element is Red, Y element is Green, Z element is Blue, and W element is Alpha (a copy of yuv.w). Each
	/// has a range of 0.0 to 1.0.
	/// </returns>
	/// <remarks>
	/// <para>Converts using ITU-R BT.2020 W(r) = 0.2627 W(b) = 0.0-593 U(max) = 0.4351 V(max) = 0.6150.</para>
	/// <para>
	/// <para>This function is new to DirectXMath 3.16</para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcoloryuvtorgb_uhd XMVECTOR XM_CALLCONV
	// XMColorYUVToRGB_UHD( [in] FXMVECTOR yuv ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMColorYUVToRGB_UHD")]
	public static XMVECTOR XMColorYUVToRGB_UHD(in FXMVECTOR yuv)
	{
		XMVECTORF32 Scale1 = new(0.0f, -0.1891f, 2.1620f, 0.0f);
		XMVECTORF32 Scale2 = new(1.1989f, -0.4645f, 0.0f, 0.0f);

		XMMATRIX M = new(XMVECTOR.g_XMOne, Scale1, Scale2, XMVECTOR.g_XMZero);
		XMVECTOR clr = XMVector3Transform(yuv, M);

		return XMVectorSelect(yuv, clr, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Calculates the Fresnel term for unpolarized light.</summary>
	/// <param name="CosIncidentAngle">Vector consisting of the cosines of the incident angles.</param>
	/// <param name="RefractionIndex">Vector consisting of the refraction indices of the materials corresponding to the incident angles.</param>
	/// <returns>Returns a vector containing the Fresnel term of each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmfresnelterm XMVECTOR XM_CALLCONV XMFresnelTerm( [in]
	// FXMVECTOR CosIncidentAngle, [in] FXMVECTOR RefractionIndex ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMFresnelTerm")]
	public static XMVECTOR XMFresnelTerm(in FXMVECTOR CosIncidentAngle, in FXMVECTOR RefractionIndex)
	{
		Debug.Assert(!XMVector4IsInfinite(CosIncidentAngle));

		// Result.ref 5f (g - c)^2 / (g + c)^ref 2 ((ref c (g + c) - 1)^2 / (ref c (g - c) + 1)^2 + 1) where c = CosIncidentAngle g =
		// sqrt(c^2 + RefractionIndex^2 - 1)

		XMVECTOR G = XMVectorMultiplyAdd(RefractionIndex, RefractionIndex, XMVECTOR.g_XMNegativeOne);
		G = XMVectorMultiplyAdd(CosIncidentAngle, CosIncidentAngle, G);
		G = XMVectorAbs(G);
		G = XMVectorSqrt(G);

		XMVECTOR S = XMVectorAdd(G, CosIncidentAngle);
		XMVECTOR D = XMVectorSubtract(G, CosIncidentAngle);

		XMVECTOR V0 = XMVectorMultiply(D, D);
		XMVECTOR V1 = XMVectorMultiply(S, S);
		V1 = XMVectorReciprocal(V1);
		V0 = XMVectorMultiply(XMVECTOR.g_XMOneHalf, V0);
		V0 = XMVectorMultiply(V0, V1);

		XMVECTOR V2 = XMVectorMultiplyAdd(CosIncidentAngle, S, XMVECTOR.g_XMNegativeOne);
		XMVECTOR V3 = XMVectorMultiplyAdd(CosIncidentAngle, D, XMVECTOR.g_XMOne);
		V2 = XMVectorMultiply(V2, V2);
		V3 = XMVectorMultiply(V3, V3);
		V3 = XMVectorReciprocal(V3);
		V2 = XMVectorMultiplyAdd(V2, V3, XMVECTOR.g_XMOne);

		XMVECTOR Result = XMVectorMultiply(V0, V2);

		Result = XMVectorSaturate(Result);

		return Result;
	}

	/// <summary>Calculates the dot product between an input plane and a 4D vector.</summary>
	/// <param name="P"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <param name="V">4D vector to use in the dot product.</param>
	/// <returns>Returns the dot product of <i>P</i> and <i>V</i> replicated into each of the four components of the returned <b>XMVECTOR</b>.</returns>
	/// <remarks>
	/// <para>
	/// The <b>XMPlaneDot</b> function is useful for determining the plane's relationship with a homogeneous coordinate. For example, this
	/// function can be used to determine if a particular coordinate is on a particular plane, or on which side of a particular plane a
	/// particular coordinate lies.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanedot XMVECTOR XM_CALLCONV XMPlaneDot( [in]
	// FXMVECTOR P, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneDot")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMPlaneDot(in FXMVECTOR P, in FXMVECTOR V) => XMVector4Dot(P, V);

	/// <summary>Calculates the dot product between an input plane and a 3D vector.</summary>
	/// <param name="P"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation</param>
	/// <param name="V">3D vector to use in the dot product. The w component of <i>V</i> is always treated as if is 1.0f.</param>
	/// <returns>Returns the dot product between <i>P</i> and <i>V</i> replicated into each of the four components of the returned <b>XMVECTOR</b>.</returns>
	/// <remarks>
	/// <para>
	/// This function can be useful in finding the signed distance from a point to a plane. The following pseudocode demonstrates the
	/// operation of the function.
	/// </para>
	/// <para><c>Ax+By+Cz+D=0</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanedotcoord XMVECTOR XM_CALLCONV XMPlaneDotCoord(
	// [in] FXMVECTOR P, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneDotCoord")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMPlaneDotCoord(in FXMVECTOR P, in FXMVECTOR V) =>
		// Result = P[0] * V[0] + P[1] * V[1] + P[2] * V[2] + P[3]
		XMVector4Dot(P, XMVectorSelect(XMVECTOR.g_XMOne, V, XMVECTOR.g_XMSelect1110));

	/// <summary>Calculates the dot product between the normal vector of a plane and a 3D vector.</summary>
	/// <param name="P"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation</param>
	/// <param name="V">3D vector to use in the dot product. The w component of <i>V</i> is always treated as if is 0.0f.</param>
	/// <returns>
	/// Returns the dot product between the normal vector of the plane and <i>V</i> replicated into each of the four components of the
	/// returned <b>XMVECTOR</b>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is useful for calculating the angle between the normal vector of the plane, and another normal vector. The following
	/// pseudocode demonstrates the operation of the function.
	/// </para>
	/// <para><c>Ax+By+Cz+D=0</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanedotnormal XMVECTOR XM_CALLCONV
	// XMPlaneDotNormal( [in] FXMVECTOR P, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneDotNormal")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMPlaneDotNormal(in FXMVECTOR P, in FXMVECTOR V) => XMVector3Dot(P, V);

	/// <summary>Determines if two planes are equal.</summary>
	/// <param name="P1"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation</param>
	/// <param name="P2"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <returns>Returns true if the two planes are equal and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para><c>Ax+By+Cz+D=0</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplaneequal bool XM_CALLCONV XMPlaneEqual( [in]
	// FXMVECTOR P1, [in] FXMVECTOR P2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMPlaneEqual(in FXMVECTOR P1, in FXMVECTOR P2) => XMVector4Equal(P1, P2);

	/// <summary>Computes the equation of a plane constructed from a point in the plane and a normal vector.</summary>
	/// <param name="Point">3D vector describing a point in the plane.</param>
	/// <param name="Normal">3D vector normal to the plane.</param>
	/// <returns>
	/// <para>Returns a vector whose components are the coefficients of the plane (A, B, C, D) for the plane equation</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = Normal.x; Result.y = Normal.y; Result.z = Normal.z; Result.w = -(Point.x * Normal.x + Point.y *
	/// Normal.y + Point.z * Normal.z); return Result;</c>
	/// </para>
	/// <para>.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>Ax+By+Cz+D=0</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanefrompointnormal XMVECTOR XM_CALLCONV
	// XMPlaneFromPointNormal( [in] FXMVECTOR Point, [in] FXMVECTOR Normal ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneFromPointNormal")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMPlaneFromPointNormal(in FXMVECTOR Point, in FXMVECTOR Normal)
	{
		XMVECTOR W = XMVector3Dot(Point, Normal);
		W = XMVectorNegate(W);
		return XMVectorSelect(W, Normal, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Computes the equation of a plane constructed from three points in the plane.</summary>
	/// <param name="Point1">3D vector describing a point in the plane.</param>
	/// <param name="Point2">3D vector describing a point in the plane.</param>
	/// <param name="Point3">3D vector describing a point in the plane.</param>
	/// <returns>
	/// <para>Returns a vector whose components are the coefficients of the plane (A, B, C, D) for the plane equation</para>
	/// <para>
	/// <c>XMVECTOR Result; XMVECTOR N; XMVECTOR D; XMVECTOR V21 = XMVectorSubtract(Point1, Point2); XMVECTOR V31 = XMVectorSubtract(Point1,
	/// Point3); N = XMVector3Cross(V21, V31); N = XMVector3Normalize(N); D = XMPlaneDotNormal(N, Point1); Result.x = N.x; Result.y = N.y;
	/// Result.z = N.z; Result.w = -D.w; return Result;</c>
	/// </para>
	/// <para>.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>Ax+By+Cz+D=0</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanefrompoints XMVECTOR XM_CALLCONV
	// XMPlaneFromPoints( [in] FXMVECTOR Point1, [in] FXMVECTOR Point2, [in] FXMVECTOR Point3 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneFromPoints")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMPlaneFromPoints(in FXMVECTOR Point1, in FXMVECTOR Point2, in FXMVECTOR Point3)
	{
		XMVECTOR V21 = XMVectorSubtract(Point1, Point2);
		XMVECTOR V31 = XMVectorSubtract(Point1, Point3);

		XMVECTOR N = XMVector3Cross(V21, V31);
		N = XMVector3Normalize(N);

		XMVECTOR D = XMPlaneDotNormal(N, Point1);
		D = XMVectorNegate(D);

		return XMVectorSelect(D, N, XMVECTOR.g_XMSelect1110);
	}

	/// <summary>Finds the intersection between a plane and a line.</summary>
	/// <param name="P"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <param name="LinePoint1">3D vector describing the first point on the line.</param>
	/// <param name="LinePoint2">3D vector describing the second point on the line.</param>
	/// <returns>
	/// Returns the intersection of the plane <i>P</i> and the line defined by <i>LinePoint1</i> and <i>LinePoint2</i>. If the line is
	/// parallel to the plane, all components of the returned vector are equal to QNaN.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplaneintersectline XMVECTOR XM_CALLCONV
	// XMPlaneIntersectLine( [in] FXMVECTOR P, [in] FXMVECTOR LinePoint1, [in] FXMVECTOR LinePoint2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneIntersectLine")]
	public static XMVECTOR XMPlaneIntersectLine(in FXMVECTOR P, in FXMVECTOR LinePoint1, in FXMVECTOR LinePoint2)
	{
		XMVECTOR V1 = XMVector3Dot(P, LinePoint1);
		XMVECTOR V2 = XMVector3Dot(P, LinePoint2);
		XMVECTOR D = XMVectorSubtract(V1, V2);

		XMVECTOR VT = XMPlaneDotCoord(P, LinePoint1);
		VT = XMVectorDivide(VT, D);

		XMVECTOR Point = XMVectorSubtract(LinePoint2, LinePoint1);
		Point = XMVectorMultiplyAdd(Point, VT, LinePoint1);

		XMVECTOR Zero = XMVectorZero();
		XMVECTOR Control = XMVectorNearEqual(D, Zero, XMVECTOR.g_XMEpsilon);

		return XMVectorSelect(Point, XMVECTOR.g_XMQNaN, Control);
	}

	/// <summary>Finds the intersection of two planes.</summary>
	/// <param name="pLinePoint1">Address of a 3D vector describing one point on the line of intersection. See remarks.</param>
	/// <param name="pLinePoint2">Address of a 3D vector describing a second point on the line of intersection. See remarks.</param>
	/// <param name="P1"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <param name="P2"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>If the planes are parallel to one another, all components of the returned point vectors are equal to QNaN.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplaneintersectplane void XM_CALLCONV
	// XMPlaneIntersectPlane( [out] XMVECTOR *pLinePoint1, [out] XMVECTOR *pLinePoint2, [in] FXMVECTOR P1, [in] FXMVECTOR P2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneIntersectPlane")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMPlaneIntersectPlane(out XMVECTOR pLinePoint1, out XMVECTOR pLinePoint2, in FXMVECTOR P1, in FXMVECTOR P2)
	{
		XMVECTOR V1 = XMVector3Cross(P2, P1);

		XMVECTOR LengthSq = XMVector3LengthSq(V1);

		XMVECTOR V2 = XMVector3Cross(P2, V1);

		XMVECTOR P1W = XMVectorSplatW(P1);
		XMVECTOR Point = XMVectorMultiply(V2, P1W);

		XMVECTOR V3 = XMVector3Cross(V1, P1);

		XMVECTOR P2W = XMVectorSplatW(P2);
		Point = XMVectorMultiplyAdd(V3, P2W, Point);

		XMVECTOR LinePoint1 = XMVectorDivide(Point, LengthSq);

		XMVECTOR LinePoint2 = XMVectorAdd(LinePoint1, V1);

		XMVECTOR Control = XMVectorLessOrEqual(LengthSq, XMVECTOR.g_XMEpsilon);
		pLinePoint1 = XMVectorSelect(LinePoint1, XMVECTOR.g_XMQNaN, Control);
		pLinePoint2 = XMVectorSelect(LinePoint2, XMVECTOR.g_XMQNaN, Control);
	}

	/// <summary>Tests whether any of the coefficients of a plane is positive or negative infinity.</summary>
	/// <param name="P"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <returns>Returns true if any of the coefficients of the plane is positive or negative infinity, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplaneisinfinite bool XM_CALLCONV XMPlaneIsInfinite(
	// [in] FXMVECTOR P ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneIsInfinite")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMPlaneIsInfinite(in FXMVECTOR P) => XMVector4IsInfinite(P);

	/// <summary>Tests whether any of the coefficients of a plane is a NaN.</summary>
	/// <param name="P"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <returns>Returns true if any of the coefficients of the plane is a NaN, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplaneisnan bool XM_CALLCONV XMPlaneIsNaN( [in]
	// FXMVECTOR P ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneIsNaN")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMPlaneIsNaN(in FXMVECTOR P) => XMVector4IsNaN(P);

	/// <summary>Determines whether two planes are nearly equal.</summary>
	/// <param name="P1"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <param name="P2"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <param name="Epsilon"><b>An XMVECTOR</b> that gives the component-wise tolerance to use when comparing <i>P1</i> and <i>P2</i>.</param>
	/// <returns>Returns <b>true</b> if <i>P1</i> is nearly equal to <i>P2</i> and <b>false</b> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The <c>XMPlaneNearEqual</c> function normalizes the <i>P1</i> and <i>P2</i> parameters before passing them, and the <i>Epsilon</i>
	/// parameter, to the <c>XMVector4NearEqual</c> function. For more information about how the calculation is performed, see the
	/// <b>XMVector4NearEqual</b> function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanenearequal bool XM_CALLCONV XMPlaneNearEqual(
	// [in] FXMVECTOR P1, [in] FXMVECTOR P2, [in] FXMVECTOR Epsilon ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneNearEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMPlaneNearEqual(in FXMVECTOR P1, in FXMVECTOR P2, in FXMVECTOR Epsilon) =>
		XMVector4NearEqual(XMPlaneNormalize(P1), XMPlaneNormalize(P2), Epsilon);

	/// <summary>Normalizes the coefficients of a plane so that coefficients of x, y, and z form a unit normal vector.</summary>
	/// <param name="P"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation</param>
	/// <returns>
	/// Returns the normalized plane as a 4D vector whose components are the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>Ax+By+Cz+D=0</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanenormalize XMVECTOR XM_CALLCONV
	// XMPlaneNormalize( [in] FXMVECTOR P ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneNormalize")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMPlaneNormalize(in FXMVECTOR P)
	{
		float fLengthSq = (float)Math.Sqrt(P[0] * P[0] + P[1] * P[1] + P[2] * P[2]);
		// Prevent divide by zero
		if (fLengthSq > 0)
		{
			fLengthSq = 1.0f / fLengthSq;
		}
		return new(P[0] * fLengthSq, P[1] * fLengthSq, P[2] * fLengthSq, P[3] * fLengthSq);
	}

	/// <summary>Estimates the coefficients of a plane so that coefficients of x, y, and z form a unit normal vector.</summary>
	/// <param name="P"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <returns>
	/// Returns an estimation of the normalized plane as a 4D vector whose components are the plane coefficients (A, B, C, D) for the plane
	/// equation <c>Ax+By+Cz+D=0</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanenormalizeest XMVECTOR XM_CALLCONV
	// XMPlaneNormalizeEst( [in] FXMVECTOR P ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneNormalizeEst")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMPlaneNormalizeEst(in FXMVECTOR P) => XMVectorMultiply(P, XMVector3ReciprocalLengthEst(P));

	/// <summary>Determines if two planes are unequal.</summary>
	/// <param name="P1"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation</param>
	/// <param name="P2"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <returns>Returns true if the two planes are unequal and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para><c>Ax+By+Cz+D=0</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanenotequal bool XM_CALLCONV XMPlaneNotEqual( [in]
	// FXMVECTOR P1, [in] FXMVECTOR P2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneNotEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMPlaneNotEqual(in FXMVECTOR P1, in FXMVECTOR P2) => XMVector4NotEqual(P1, P2);

	/// <summary>Transforms a plane by a given matrix.</summary>
	/// <param name="P"><b>XMVECTOR</b> describing the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.</param>
	/// <param name="ITM"/>
	/// <returns>
	/// Returns the transformed plane as a 4D vector whose components are the plane coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanetransform XMVECTOR XM_CALLCONV
	// XMPlaneTransform( [in] FXMVECTOR P, in FXMMATRIX ITM ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneTransform")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMPlaneTransform(in FXMVECTOR P, in FXMMATRIX ITM)
	{
		XMVECTOR W = XMVectorSplatW(P);
		XMVECTOR Z = XMVectorSplatZ(P);
		XMVECTOR Y = XMVectorSplatY(P);
		XMVECTOR X = XMVectorSplatX(P);

		XMVECTOR Result = XMVectorMultiply(W, ITM.r[3]);
		Result = XMVectorMultiplyAdd(Z, ITM.r[2], Result);
		Result = XMVectorMultiplyAdd(Y, ITM.r[1], Result);
		Result = XMVectorMultiplyAdd(X, ITM.r[0], Result);
		return Result;
	}

	/// <summary>Transforms a stream of planes by a given matrix.</summary>
	/// <param name="pOutputStream">
	/// Address of the first <c>XMFLOAT4</c> in the destination stream. The components of each <b>XMFLOAT4</b> are the plane coefficients
	/// (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.
	/// </param>
	/// <param name="OutputStride">Stride, in bytes, between planes in the destination stream.</param>
	/// <param name="pInputStream">
	/// Address of the first <c>XMFLOAT4</c> in the stream to be transformed. The components of each <b>XMFLOAT4</b> are the plane
	/// coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.
	/// </param>
	/// <param name="InputStride">Stride, in bytes, between planes in the input stream.</param>
	/// <param name="PlaneCount">Number of planes to transform.</param>
	/// <param name="ITM"/>
	/// <returns>
	/// Returns the address of the first <c>XMFLOAT4</c> in the destination stream. The components of each <b>XMFLOAT4</b> are the plane
	/// coefficients (A, B, C, D) for the plane equation <c>Ax+By+Cz+D=0</c>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmplanetransformstream XMFLOAT4 *XM_CALLCONV
	// XMPlaneTransformStream( [out] XMFLOAT4 *pOutputStream, [in] size_t OutputStride, [in] const XMFLOAT4 *pInputStream, [in] size_t
	// InputStride, [in] size_t PlaneCount, in FXMMATRIX ITM ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMPlaneTransformStream")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMFLOAT4* XMPlaneTransformStream([In] XMFLOAT4* pOutputStream, SizeT OutputStride, [In] XMFLOAT4* pInputStream,
		SizeT InputStride, SizeT PlaneCount, in FXMMATRIX ITM) => XMVector4TransformStream(pOutputStream, OutputStride, pInputStream, InputStride, PlaneCount, ITM);

	/// <summary>Returns a point in barycentric coordinates, using the specified quaternions.</summary>
	/// <param name="Q0">First quaternion in the triangle.</param>
	/// <param name="Q1">Second quaternion in the triangle.</param>
	/// <param name="Q2">Third quaternion in the triangle.</param>
	/// <param name="f">Weighting factor. See the remarks.</param>
	/// <param name="g">Weighting factor. See the remarks.</param>
	/// <returns>Returns a quaternion in barycentric coordinates.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>XMVECTOR Result; XMVECTOR QA, QB; float s = f + g; if (s != 0.0f) { QA = XMQuaternionSlerp(Q0, Q1, s); QB = XMQuaternionSlerp(Q0,
	/// Q2, s); Result = XMQuaternionSlerp(QA, QB, g / s); } else { Result.x = Q0.x; Result.y = Q0.y; Result.z = Q0.z; Result.w = Q0.w; }
	/// return Result;</c>
	/// </para>
	/// <para>
	/// Note that Barycentric coordinates work for 'flat' surfaces but not for 'curved' ones. This function is therefore a bit of a
	/// work-around. An alternative method for blending 3 quaternions is given by the following code:
	/// </para>
	/// <para>
	/// <c>inline XMVECTOR XMQuaternionBlend(in FXMVECTOR Q0, in FXMVECTOR Q1, in FXMVECTOR Q2, float w1, float w2) { // Note if you choose one of
	/// the three weights to be zero, you get a blend of two // quaternions. This does not give you slerp of those quaternions. float w0 =
	/// 1.0f - w1 - w2; XMVECTOR Result = XMVector4Normalize( XMVectorScale(Q0, w0) + XMVectorScale(Q1, w1) + XMVectorScale(Q2, w2)); return
	/// Result; }</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionbarycentric XMVECTOR XM_CALLCONV
	// XMQuaternionBaryCentric( [in] FXMVECTOR Q0, [in] FXMVECTOR Q1, [in] FXMVECTOR Q2, [in] float f, [in] float g ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionBaryCentric")]
	public static XMVECTOR XMQuaternionBaryCentric(in FXMVECTOR Q0, in FXMVECTOR Q1, in FXMVECTOR Q2, float f, float g)
	{
		float s = f + g;

		if (s is < 0.00001f and > (-0.00001f))
		{
			return Q0;
		}
		else
		{
			XMVECTOR Q01 = XMQuaternionSlerp(Q0, Q1, s);
			XMVECTOR Q02 = XMQuaternionSlerp(Q0, Q2, s);

			return XMQuaternionSlerp(Q01, Q02, g / s);
		}
	}

	/// <summary>Returns a point in barycentric coordinates, using the specified quaternions.</summary>
	/// <param name="Q0">First quaternion in the triangle.</param>
	/// <param name="Q1">Second quaternion in the triangle.</param>
	/// <param name="Q2">Third quaternion in the triangle.</param>
	/// <param name="F">Weighting factor. All components of this vector must be the same.</param>
	/// <param name="G">Weighting factor. All components of this vector must be the same.</param>
	/// <returns>Returns a quaternion in barycentric coordinates.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>
	/// This function is identical to <c>XMQuaternionBaryCentric</c> except that <i>F</i> and <i>G</i> are supplied using a 4D vector
	/// instead of a <b>float</b> value.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionbarycentricv XMVECTOR XM_CALLCONV
	// XMQuaternionBaryCentricV( [in] FXMVECTOR Q0, [in] FXMVECTOR Q1, [in] FXMVECTOR Q2, [in] GXMVECTOR F, [in] HXMVECTOR G ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionBaryCentricV")]
	public static XMVECTOR XMQuaternionBaryCentricV(in FXMVECTOR Q0, in FXMVECTOR Q1, in FXMVECTOR Q2, in GXMVECTOR F, in HXMVECTOR G)
	{
		if (!F.IsConstant) throw new ArgumentException("All components of F must be the same.");
		if (!G.IsConstant) throw new ArgumentException("All components of G must be the same.");

		XMVECTOR Epsilon = XMVectorSplatConstant(1, 16);

		XMVECTOR S = XMVectorAdd(F, G);

		if (XMVector4InBounds(S, Epsilon))
		{
			return Q0;
		}
		else
		{
			XMVECTOR Q01 = XMQuaternionSlerpV(Q0, Q1, S);
			XMVECTOR Q02 = XMQuaternionSlerpV(Q0, Q2, S);
			XMVECTOR GS = XMVectorReciprocal(S);
			GS = XMVectorMultiply(G, GS);

			return XMQuaternionSlerpV(Q01, Q02, GS);
		}
	}

	/// <summary>Computes the conjugate of a quaternion.</summary>
	/// <param name="Q">The quaternion to conjugate.</param>
	/// <returns>Returns the conjugate of <i>Q</i>.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>
	/// Given a quaternion ( <i>x</i>, <i>y</i>, <i>z</i>, <i>w</i>), the <c>XMQuaternionConjugate</c> function returns the quaternion (-
	/// <i>x</i>, - <i>y</i>, - <i>z</i>, <i>w</i>).
	/// </para>
	/// <para>Use the <c>XMQuaternionNormalize</c> function for any quaternion input that is not already normalized.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionconjugate XMVECTOR XMQuaternionConjugate(
	// [in] FXMVECTOR Q );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionConjugate")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionConjugate(in FXMVECTOR Q) => new(-Q.x, -Q.y, -Q.z, Q.w);

	/// <summary>Computes the dot product of two quaternions.</summary>
	/// <param name="Q1">First quaternion.</param>
	/// <param name="Q2">Second quaternion.</param>
	/// <returns>Returns a vector. The dot product between <i>Q1</i> and <i>Q2</i> is replicated into each component.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaterniondot XMVECTOR XM_CALLCONV XMQuaternionDot(
	// [in] FXMVECTOR Q1, [in] FXMVECTOR Q2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionDot")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionDot(in FXMVECTOR Q1, in FXMVECTOR Q2) => XMVector4Dot(Q1, Q2);

	/// <summary>Tests whether two quaternions are equal.</summary>
	/// <param name="Q1">First quaternion to test.</param>
	/// <param name="Q2">Second quaternion to test.</param>
	/// <returns>Returns true if the quaternions are equal and false otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionequal bool XM_CALLCONV XMQuaternionEqual(
	// [in] FXMVECTOR Q1, [in] FXMVECTOR Q2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMQuaternionEqual(in FXMVECTOR Q1, in FXMVECTOR Q2) => XMVector4Equal(Q1, Q2);

	/// <summary>Computes the exponential of a given pure quaternion.</summary>
	/// <param name="Q">
	/// Pure quaternion for which to compute the exponential. The w-component of the input quaternion is ignored in the calculation.
	/// </param>
	/// <returns>Returns the exponential of <i>Q</i>.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionexp XMVECTOR XM_CALLCONV XMQuaternionExp(
	// [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionExp")]
	public static XMVECTOR XMQuaternionExp(in FXMVECTOR Q)
	{
		XMVECTOR Theta = XMVector3Length(Q);

		XMVectorSinCos(out var SinTheta, out var CosTheta, Theta);

		XMVECTOR S = XMVectorDivide(SinTheta, Theta);

		XMVECTOR Result = XMVectorMultiply(Q, S);

		XMVECTOR Zero = XMVectorZero();
		XMVECTOR Control = XMVectorNearEqual(Theta, Zero, XMVECTOR.g_XMEpsilon);
		Result = XMVectorSelect(Result, Q, Control);

		Result = XMVectorSelect(CosTheta, Result, XMVECTOR.g_XMSelect1110);

		return Result;
	}

	/// <summary>Returns the identity quaternion.</summary>
	/// <returns>An <c>XMVECTOR</c> union that is the identity quaternion.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>Given a quaternion (x, y, z, w), the <c>XMQuaternionIdentity</c> function will return the quaternion (0, 0, 0, 1).</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionidentity XMVECTOR XM_CALLCONV
	// XMQuaternionIdentity() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionIdentity")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionIdentity() => XMVECTOR.g_XMIdentityR3;

	/// <summary>Computes the inverse of a quaternion.</summary>
	/// <param name="Q">Quaternion to invert.</param>
	/// <returns>Returns the inverse of <i>Q</i>.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; float LengthSq = Q.x * Q.x + Q.y * Q.y + Q.z * Q.z + Q.w * Q.w; Result.x = -Q.x / LengthSq; Result.y = -Q.y /
	/// LengthSq; Result.z = -Q.z / LengthSq; Result.w = Q.w / LengthSq; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternioninverse XMVECTOR XM_CALLCONV
	// XMQuaternionInverse( [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionInverse")]
	public static XMVECTOR XMQuaternionInverse(in FXMVECTOR Q)
	{
		XMVECTOR L = XMVector4LengthSq(Q);
		XMVECTOR Conjugate = XMQuaternionConjugate(Q);

		XMVECTOR Control = XMVectorLessOrEqual(L, XMVECTOR.g_XMEpsilon);

		XMVECTOR Result = XMVectorDivide(Conjugate, L);

		return XMVectorSelect(Result, XMVECTOR.g_XMZero, Control);
	}

	/// <summary>Tests whether a specific quaternion is the identity quaternion.</summary>
	/// <param name="Q">Quaternion to test.</param>
	/// <returns>Returns true if <i>Q</i> is the identity quaternion, or false otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionisidentity bool XM_CALLCONV
	// XMQuaternionIsIdentity( [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionIsIdentity")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMQuaternionIsIdentity(in FXMVECTOR Q) => XMVector4Equal(Q, XMVECTOR.g_XMIdentityR3);

	/// <summary>Test whether any component of a quaternion is either positive or negative infinity.</summary>
	/// <param name="Q">Quaternion to test.</param>
	/// <returns>Returns true if any component of <i>Q</i> is positive or negative infinity,and false otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionisinfinite bool XM_CALLCONV
	// XMQuaternionIsInfinite( [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionIsInfinite")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMQuaternionIsInfinite(in FXMVECTOR Q) => XMVector4IsInfinite(Q);

	/// <summary>Test whether any component of a quaternion is a NaN.</summary>
	/// <param name="Q">Quaternion to test.</param>
	/// <returns>Returns true if any component of <i>Q</i> is a NaN,and false otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionisnan bool XM_CALLCONV XMQuaternionIsNaN(
	// [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionIsNaN")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMQuaternionIsNaN(in FXMVECTOR Q) => XMVector4IsNaN(Q);

	/// <summary>Computes the magnitude of a quaternion.</summary>
	/// <param name="Q">Quaternion to measure.</param>
	/// <returns>Returns a vector. The magnitude of <i>Q</i> is replicated into each component.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionlength XMVECTOR XM_CALLCONV
	// XMQuaternionLength( [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionLength")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionLength(in FXMVECTOR Q) => XMVector4Length(Q);

	/// <summary>Computes the square of the magnitude of a quaternion.</summary>
	/// <param name="Q">Quaternion to measure.</param>
	/// <returns>Returns a vector. The square of the magnitude is replicated into each component.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionlengthsq XMVECTOR XM_CALLCONV
	// XMQuaternionLengthSq( [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionLengthSq")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionLengthSq(in FXMVECTOR Q) => XMVector4LengthSq(Q);

	/// <summary>Computes the natural logarithm of a given unit quaternion.</summary>
	/// <param name="Q">
	/// Unit quaternion for which to calculate the natural logarithm. If <i>Q</i> is not a unit quaternion, the returned value is undefined.
	/// </param>
	/// <returns>Returns the natural logarithm of <i>Q</i>.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionln XMVECTOR XM_CALLCONV XMQuaternionLn(
	// [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionLn")]
	public static XMVECTOR XMQuaternionLn(in FXMVECTOR Q)
	{
		XMVECTORF32 OneMinusEpsilon = new(1.0f - 0.00001f, 1.0f - 0.00001f, 1.0f - 0.00001f, 1.0f - 0.00001f);

		XMVECTOR QW = XMVectorSplatW(Q);
		XMVECTOR Q0 = XMVectorSelect(XMVECTOR.g_XMSelect1110, Q, XMVECTOR.g_XMSelect1110);

		XMVECTOR ControlW = XMVectorInBounds(QW, OneMinusEpsilon);

		XMVECTOR Theta = XMVectorACos(QW);
		XMVECTOR SinTheta = XMVectorSin(Theta);

		XMVECTOR S = XMVectorDivide(Theta, SinTheta);

		XMVECTOR Result = XMVectorMultiply(Q0, S);
		Result = XMVectorSelect(Q0, Result, ControlW);

		return Result;
	}

	/// <summary>Computes the product of two quaternions.</summary>
	/// <param name="Q1">First quaternion.</param>
	/// <param name="Q2">Second quaternion.</param>
	/// <returns>Returns the product of two quaternions as <i>Q2</i>* <i>Q1</i>.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>
	/// The result represents the rotation Q1 followed by the rotation Q2 to be consistent with XMMatrixMulplity concatenation since this
	/// function is typically used to concatenate quaternions that represent rotations (i.e. it returns Q2*Q1).
	/// </para>
	/// <para>This function computes the equivalent to the following pseudo-code:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (Q2.w * Q1.x) + (Q2.x * Q1.w) + (Q2.y * Q1.z) - (Q2.z * Q1.y); Result.y = (Q2.w * Q1.y) - (Q2.x *
	/// Q1.z) + (Q2.y * Q1.w) + (Q2.z * Q1.x); Result.z = (Q2.w * Q1.z) + (Q2.x * Q1.y) - (Q2.y * Q1.x) + (Q2.z * Q1.w); Result.w = (Q2.w *
	/// Q1.w) - (Q2.x * Q1.x) - (Q2.y * Q1.y) - (Q2.z * Q1.z); return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionmultiply XMVECTOR XMQuaternionMultiply(
	// [in] FXMVECTOR Q1, [in] FXMVECTOR Q2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionMultiply")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionMultiply(in FXMVECTOR Q1, in FXMVECTOR Q2) =>
		new(Q2.w * Q1.x + Q2.x * Q1.w + Q2.y * Q1.z - Q2.z * Q1.y,
			Q2.w * Q1.y - Q2.x * Q1.z + Q2.y * Q1.w + Q2.z * Q1.x,
			Q2.w * Q1.z + Q2.x * Q1.y - Q2.y * Q1.x + Q2.z * Q1.w,
			Q2.w * Q1.w - Q2.x * Q1.x - Q2.y * Q1.y - Q2.z * Q1.z);

	/// <summary>Normalizes a quaternion.</summary>
	/// <param name="Q">Quaternion to normalize.</param>
	/// <returns>Returns the normalized form of <i>Q</i>.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionnormalize XMVECTOR XM_CALLCONV
	// XMQuaternionNormalize( [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionNormalize")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionNormalize(in FXMVECTOR Q) => XMVector4Normalize(Q);

	/// <summary>Estimates the normalized version of a quaternion.</summary>
	/// <param name="Q">A quaternion for which to estimate the normalized version.</param>
	/// <returns>An <c>XMVECTOR</c> union that is the estimate of the normalized version of a quaternion.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>This function internally calls the <c>XMVector4NormalizeEst</c> function.</para>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionnormalizeest XMVECTOR XM_CALLCONV
	// XMQuaternionNormalizeEst( [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionNormalizeEst")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionNormalizeEst(in FXMVECTOR Q) => XMVector4NormalizeEst(Q);

	/// <summary>Tests whether two quaternions are not equal.</summary>
	/// <param name="Q1">First quaternion to test.</param>
	/// <param name="Q2">Second quaternion to test.</param>
	/// <returns>Returns true if the quaternions are unequal and false otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionnotequal bool XM_CALLCONV
	// XMQuaternionNotEqual( [in] FXMVECTOR Q1, [in] FXMVECTOR Q2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionNotEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMQuaternionNotEqual(in FXMVECTOR Q1, in FXMVECTOR Q2) => XMVector4NotEqual(Q1, Q2);

	/// <summary>Computes the reciprocal of the magnitude of a quaternion.</summary>
	/// <param name="Q">Quaternion to measure.</param>
	/// <returns>Returns the reciprocal of the magnitude of <i>Q</i>.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionreciprocallength XMVECTOR XM_CALLCONV
	// XMQuaternionReciprocalLength( [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionReciprocalLength")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionReciprocalLength(in FXMVECTOR Q) => XMVector4ReciprocalLength(Q);

	/// <summary>Computes a rotation quaternion about an axis.</summary>
	/// <param name="Axis">3D vector describing the axis of rotation.</param>
	/// <param name="Angle">
	/// Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.
	/// </param>
	/// <returns>Returns the rotation quaternion.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>If <i>Axis</i> is a normalized vector, it is faster to use <c>XMQuaternionRotationNormal</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionrotationaxis XMVECTOR XM_CALLCONV
	// XMQuaternionRotationAxis( [in] FXMVECTOR Axis, [in] float Angle ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionRotationAxis")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionRotationAxis(in FXMVECTOR Axis, float Angle)
	{
		if (XMVector3Equal(Axis, XMVectorZero())) throw new ArgumentException("Cannot be zero.", nameof(Axis));
		return XMVector3IsInfinite(Axis)
			? throw new ArgumentException("Cannot be infinite.", nameof(Axis))
			: XMQuaternionRotationNormal(XMVector3Normalize(Axis), Angle);
	}

	/// <summary>Computes a rotation quaternion from a rotation matrix.</summary>
	/// <param name="M">Rotation matrix.</param>
	/// <returns>Returns the rotation quaternion.</returns>
	/// <remarks>
	/// <para>
	/// This function only uses the upper 3x3 portion of the <c>XMMATRIX</c>. Note if the input matrix contains scales, shears, or other
	/// non-rotation transformations in the upper 3x3 matrix, then the output of this function is ill-defined.
	/// </para>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionrotationmatrix XMVECTOR XM_CALLCONV
	// XMQuaternionRotationMatrix( [in] FXMMATRIX M ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionRotationMatrix")]
	public static XMVECTOR XMQuaternionRotationMatrix(this FXMMATRIX M)
	{
		XMVECTORF32 q = new();
		unsafe
		{
			float r22 = M[2, 2];
			if (r22 <= 0f)  // x^2 + y^2 >= z^2 + w^2
			{
				float dif10 = M[1, 1] - M[0, 0];
				float omr22 = 1f - r22;
				if (dif10 <= 0f)  // x^2 >= y^2
				{
					float fourXSqr = omr22 - dif10;
					float inv4x = 0.5f / (float)Math.Sqrt(fourXSqr);
					q.f[0] = fourXSqr * inv4x;
					q.f[1] = (M[0, 1] + M[1, 0]) * inv4x;
					q.f[2] = (M[0, 2] + M[2, 0]) * inv4x;
					q.f[3] = (M[1, 2] - M[2, 1]) * inv4x;
				}
				else  // y^2 >= x^2
				{
					float fourYSqr = omr22 + dif10;
					float inv4y = 0.5f / (float)Math.Sqrt(fourYSqr);
					q.f[0] = (M[0, 1] + M[1, 0]) * inv4y;
					q.f[1] = fourYSqr * inv4y;
					q.f[2] = (M[1, 2] + M[2, 1]) * inv4y;
					q.f[3] = (M[2, 0] - M[0, 2]) * inv4y;
				}
			}
			else  // z^2 + w^2 >= x^2 + y^2
			{
				float sum10 = M[1, 1] + M[0, 0];
				float opr22 = 1f + r22;
				if (sum10 <= 0f)  // z^2 >= w^2
				{
					float fourZSqr = opr22 - sum10;
					float inv4z = 0.5f / (float)Math.Sqrt(fourZSqr);
					q.f[0] = (M[0, 2] + M[2, 0]) * inv4z;
					q.f[1] = (M[1, 2] + M[2, 1]) * inv4z;
					q.f[2] = fourZSqr * inv4z;
					q.f[3] = (M[0, 1] - M[1, 0]) * inv4z;
				}
				else  // w^2 >= z^2
				{
					float fourWSqr = opr22 + sum10;
					float inv4w = 0.5f / (float)Math.Sqrt(fourWSqr);
					q.f[0] = (M[1, 2] - M[2, 1]) * inv4w;
					q.f[1] = (M[2, 0] - M[0, 2]) * inv4w;
					q.f[2] = (M[0, 1] - M[1, 0]) * inv4w;
					q.f[3] = fourWSqr * inv4w;
				}
			}
		}
		return q;
	}

	/// <summary>Computes the rotation quaternion about a normal vector.</summary>
	/// <param name="NormalAxis">Normal vector describing the axis of rotation.</param>
	/// <param name="Angle">
	/// Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.
	/// </param>
	/// <returns>Returns the rotation quaternion.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionrotationnormal XMVECTOR XM_CALLCONV
	// XMQuaternionRotationNormal( [in] FXMVECTOR NormalAxis, [in] float Angle ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionRotationNormal")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionRotationNormal(in FXMVECTOR NormalAxis, float Angle)
	{
		XMScalarSinCos(out var SinV, out var CosV, 0.5f * Angle);
		XMVECTOR N = XMVectorSelect(XMVECTOR.g_XMOne, NormalAxis, XMVECTOR.g_XMSelect1110);
		return XMVectorMultiply(N, new(SinV, SinV, SinV, CosV));
	}

	/// <summary>Computes a rotation quaternion based on the pitch, yaw, and roll (Euler angles).</summary>
	/// <param name="Pitch">Angle of rotation around the x-axis, in radians.</param>
	/// <param name="Yaw">Angle of rotation around the y-axis, in radians.</param>
	/// <param name="Roll">Angle of rotation around the z-axis, in radians.</param>
	/// <returns>Returns the rotation quaternion.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>
	/// Angles are measured clockwise when looking along the rotation axis toward the origin. This is a left-handed coordinate system. To
	/// use right-handed coordinates, negate all three angles.
	/// </para>
	/// <para>The order of transformations is roll first, then pitch, then yaw. The rotations are all applied in the global coordinate frame.</para>
	/// <para>
	/// <para>
	/// This function takes x-axis, y-axis, z-axis angles as input parameters. The assignment of the labels pitch to the x-axis, yaw to the
	/// y-axis, and roll to the z-axis is a common one for computer graphics and games as it matches typical 'view' coordinate systems.
	/// There are of course other ways to assign those labels when using other coordinate systems (i.e. roll could be the x-axis, pitch the
	/// y-axis, and yaw the z-axis).
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionrotationrollpitchyaw XMVECTOR XM_CALLCONV
	// XMQuaternionRotationRollPitchYaw( [in] float Pitch, [in] float Yaw, [in] float Roll ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionRotationRollPitchYaw")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionRotationRollPitchYaw(float Pitch, float Yaw, float Roll) =>
		XMQuaternionRotationRollPitchYawFromVector(new(Pitch, Yaw, Roll, 0.0f));

	/// <summary>Computes a rotation quaternion based on a vector containing the Euler angles (pitch, yaw, and roll).</summary>
	/// <param name="Angles">
	/// 3D vector containing the Euler angles in the order x-axis (pitch), then y-axis (yaw), and then z-axis (roll). The W element is ignored.
	/// </param>
	/// <returns>Returns the rotation quaternion.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>
	/// Angles are measured clockwise when looking along the rotation axis toward the origin. This is a left-handed coordinate system. To
	/// use right-handed coordinates, negate all three angles.
	/// </para>
	/// <para>The order of transformations is roll first, then pitch, then yaw. The rotations are all applied in the global coordinate frame.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// This function takes x-axis, y-axis, and z-axis angles as input parameters. The assignment of the labels pitch to the x-axis, yaw to
	/// the y-axis, and roll to the z-axis is a common one for computer graphics and games, since it matches typical 'view' coordinate
	/// systems. There are of course other ways to assign those labels when using other coordinate systems (for example, roll could be the
	/// x-axis, pitch the y-axis, and yaw the z-axis).
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionrotationrollpitchyawfromvector XMVECTOR
	// XM_CALLCONV XMQuaternionRotationRollPitchYawFromVector( [in] FXMVECTOR Angles ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionRotationRollPitchYawFromVector")]
	public static XMVECTOR XMQuaternionRotationRollPitchYawFromVector(in FXMVECTOR Angles) // <Pitch, Yaw, Roll, 0>
	{
		float halfpitch = Angles[0] * 0.5f;
		float cp = (float)Math.Cos(halfpitch);
		float sp = (float)Math.Sin(halfpitch);

		float halfyaw = Angles[1] * 0.5f;
		float cy = (float)Math.Cos(halfyaw);
		float sy = (float)Math.Sin(halfyaw);

		float halfroll = Angles[2] * 0.5f;
		float cr = (float)Math.Cos(halfroll);
		float sr = (float)Math.Sin(halfroll);

		return new(cr * sp * cy + sr * cp * sy,
			cr * cp * sy - sr * sp * cy,
			sr * cp * cy - cr * sp * sy,
			cr * cp * cy + sr * sp * sy);
	}

	/// <summary>Interpolates between two unit quaternions, using spherical linear interpolation.</summary>
	/// <param name="Q0">Unit quaternion to interpolate from.</param>
	/// <param name="Q1">Unit quaternion to interpolate to.</param>
	/// <param name="t">Interpolation control factor.</param>
	/// <returns>
	/// Returns the interpolated quaternion. If <i>Q0</i> and <i>Q1</i> are not unit quaternions, the resulting interpolation is undefined.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>When <i>t</i> is 0.0f, the function returns <i>Q0</i>. When <i>t</i> is 1.0f, the function returns <i>Q1</i>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionslerp XMVECTOR XM_CALLCONV
	// XMQuaternionSlerp( [in] FXMVECTOR Q0, [in] FXMVECTOR Q1, [in] float t ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionSlerp")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionSlerp(in FXMVECTOR Q0, in FXMVECTOR Q1, float t)
	{
		XMVECTOR T = XMVectorReplicate(t);
		return XMQuaternionSlerpV(Q0, Q1, T);
	}

	/// <summary>Interpolates between two unit quaternions, using spherical linear interpolation.</summary>
	/// <param name="Q0">Unit quaternion to interpolate from.</param>
	/// <param name="Q1">Unit quaternion to interpolate to.</param>
	/// <param name="T">Interpolation control factor. All components of this vector must be the same.</param>
	/// <returns>
	/// Returns the interpolated quaternion. If <i>Q0</i> and <i>Q1</i> are not unit quaternions, the resulting interpolation is undefined.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>
	/// This function is identical to <c>XMQuaternionSlerp</c> except that <i>T</i> is supplied using a 4D vector instead of a <b>float</b> value.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionslerpv XMVECTOR XM_CALLCONV
	// XMQuaternionSlerpV( [in] FXMVECTOR Q0, [in] FXMVECTOR Q1, [in] FXMVECTOR T ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionSlerpV")]
	public static XMVECTOR XMQuaternionSlerpV(in FXMVECTOR Q0, in FXMVECTOR Q1, in FXMVECTOR T)
	{
		Debug.Assert(XMVectorGetY(T) == XMVectorGetX(T) && XMVectorGetZ(T) == XMVectorGetX(T) && XMVectorGetW(T) == XMVectorGetX(T));

		// Result = ref Q0 sin((1.0 - t) * Omega) / sin(Omega) + ref Q1 sin(ref t Omega) / sin(Omega)

		XMVECTORF32 OneMinusEpsilon = new(1.0f - 0.00001f, 1.0f - 0.00001f, 1.0f - 0.00001f, 1.0f - 0.00001f);

		XMVECTOR CosOmega = XMQuaternionDot(Q0, Q1);

		XMVECTOR Zero = XMVectorZero();
		XMVECTOR Control = XMVectorLess(CosOmega, Zero);
		XMVECTOR Sign = XMVectorSelect(XMVECTOR.g_XMOne, XMVECTOR.g_XMNegativeOne, Control);

		CosOmega = XMVectorMultiply(CosOmega, Sign);

		Control = XMVectorLess(CosOmega, OneMinusEpsilon);

		XMVECTOR SinOmega = XMVectorNegativeMultiplySubtract(CosOmega, CosOmega, XMVECTOR.g_XMOne);
		SinOmega = XMVectorSqrt(SinOmega);

		XMVECTOR Omega = XMVectorATan2(SinOmega, CosOmega);

		XMVECTOR SignMask = XMVectorSplatSignMask();
		XMVECTOR V01 = XMVectorShiftLeft(T, Zero, 2);
		SignMask = XMVectorShiftLeft(SignMask, Zero, 3);
		V01 = XMVectorXorInt(V01, SignMask);
		V01 = XMVectorAdd(XMVECTOR.g_XMIdentityR0, V01);

		XMVECTOR InvSinOmega = XMVectorReciprocal(SinOmega);

		XMVECTOR S0 = XMVectorMultiply(V01, Omega);
		S0 = XMVectorSin(S0);
		S0 = XMVectorMultiply(S0, InvSinOmega);

		S0 = XMVectorSelect(V01, S0, Control);

		XMVECTOR S1 = XMVectorSplatY(S0);
		S0 = XMVectorSplatX(S0);

		S1 = XMVectorMultiply(S1, Sign);

		XMVECTOR Result = XMVectorMultiply(Q0, S0);
		Result = XMVectorMultiplyAdd(Q1, S1, Result);

		return Result;
	}

	/// <summary>Interpolates between four unit quaternions, using spherical quadrangle interpolation.</summary>
	/// <param name="Q0">First unit quaternion.</param>
	/// <param name="Q1">Second unit quaternion.</param>
	/// <param name="Q2">Third unit quaternion.</param>
	/// <param name="Q3">Fourth unit quaternion.</param>
	/// <param name="t">Interpolation control factor.</param>
	/// <returns>
	/// Returns the interpolated quaternion. If <i>Q0</i>, <i>Q1</i>, <i>Q2</i>, and <i>Q3</i> are not all unit quaternions, the returned
	/// quaternion is undefined.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>The use of this method requires some setup before its use. See <c>XMQuaternionSquadSetup</c> for details.</para>
	/// <para>
	/// The following example shows how to use a set of quaternion keys (Q0, Q1, Q2, Q3) to compute the inner quadrangle points (A, B, C).
	/// This ensures that the tangents are continuous across adjacent segments.
	/// </para>
	/// <para>
	/// <c>// Rotation about the z-axis XMVECTOR Q0 = XMVectorSet(0, 0, 0.707f, -.707f); XMVECTOR Q1 = XMVectorSet(0, 0, 0.000f, 1.000f);
	/// XMVECTOR Q2 = XMVectorSet(0, 0, 0.707f, 0.707f); XMVECTOR Q3 = XMVectorSet(0, 0, 1.000f, 0.000f); XMVECTOR A, B, C;
	/// XMQuaternionSquadSetup(&amp;A, &amp;B, &amp;C, Q0, Q1, Q2, Q3); XMVECTOR result = XMQuaternionSquad(Q1, A, B, C, 0.5f); // result is
	/// a rotation of 45 degrees around the z-axis</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionsquad XMVECTOR XM_CALLCONV
	// XMQuaternionSquad( [in] FXMVECTOR Q0, [in] FXMVECTOR Q1, [in] FXMVECTOR Q2, [in] GXMVECTOR Q3, [in] float t ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionSquad")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMQuaternionSquad(in FXMVECTOR Q0, in FXMVECTOR Q1, in FXMVECTOR Q2, in GXMVECTOR Q3, float t)
	{
		XMVECTOR T = XMVectorReplicate(t);
		return XMQuaternionSquadV(Q0, Q1, Q2, Q3, T);
	}

	/// <summary>Provides addresses of setup control points for spherical quadrangle interpolation.</summary>
	/// <param name="pA">Address of first setup quaternion.</param>
	/// <param name="pB">Address of first setup quaternion.</param>
	/// <param name="pC">Address of first setup quaternion.</param>
	/// <param name="Q0">First quaternion.</param>
	/// <param name="Q1">Second quaternion.</param>
	/// <param name="Q2">Third quaternion.</param>
	/// <param name="Q3">Fourth quaternion.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>
	/// The results returned in <i>pA</i>, <i>pB</i>, and <i>pC</i> are used as the inputs to the <i>Q1</i>, <i>Q2</i>, and <i>Q3</i>
	/// parameters of <c>XMQuaternionSquad</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionsquadsetup void XM_CALLCONV
	// XMQuaternionSquadSetup( [out] XMVECTOR *pA, [out] XMVECTOR *pB, [out] XMVECTOR *pC, [in] FXMVECTOR Q0, [in] FXMVECTOR Q1, [in]
	// FXMVECTOR Q2, [in] GXMVECTOR Q3 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionSquadSetup")]
	public static void XMQuaternionSquadSetup(out XMVECTOR pA, out XMVECTOR pB, out XMVECTOR pC, in FXMVECTOR Q0, in FXMVECTOR Q1, in FXMVECTOR Q2, in GXMVECTOR Q3)
	{
		XMVECTOR LS12 = XMQuaternionLengthSq(XMVectorAdd(Q1, Q2));
		XMVECTOR LD12 = XMQuaternionLengthSq(XMVectorSubtract(Q1, Q2));
		XMVECTOR SQ2 = XMVectorNegate(Q2);

		XMVECTOR Control1 = XMVectorLess(LS12, LD12);
		SQ2 = XMVectorSelect(Q2, SQ2, Control1);

		XMVECTOR LS01 = XMQuaternionLengthSq(XMVectorAdd(Q0, Q1));
		XMVECTOR LD01 = XMQuaternionLengthSq(XMVectorSubtract(Q0, Q1));
		XMVECTOR SQ0 = XMVectorNegate(Q0);

		XMVECTOR LS23 = XMQuaternionLengthSq(XMVectorAdd(SQ2, Q3));
		XMVECTOR LD23 = XMQuaternionLengthSq(XMVectorSubtract(SQ2, Q3));
		XMVECTOR SQ3 = XMVectorNegate(Q3);

		XMVECTOR Control0 = XMVectorLess(LS01, LD01);
		XMVECTOR Control2 = XMVectorLess(LS23, LD23);

		SQ0 = XMVectorSelect(Q0, SQ0, Control0);
		SQ3 = XMVectorSelect(Q3, SQ3, Control2);

		XMVECTOR InvQ1 = XMQuaternionInverse(Q1);
		XMVECTOR InvQ2 = XMQuaternionInverse(SQ2);

		XMVECTOR LnQ0 = XMQuaternionLn(XMQuaternionMultiply(InvQ1, SQ0));
		XMVECTOR LnQ2 = XMQuaternionLn(XMQuaternionMultiply(InvQ1, SQ2));
		XMVECTOR LnQ1 = XMQuaternionLn(XMQuaternionMultiply(InvQ2, Q1));
		XMVECTOR LnQ3 = XMQuaternionLn(XMQuaternionMultiply(InvQ2, SQ3));

		XMVECTOR NegativeOneQuarter = XMVectorSplatConstant(-1, 2);

		XMVECTOR ExpQ02 = XMVectorMultiply(XMVectorAdd(LnQ0, LnQ2), NegativeOneQuarter);
		XMVECTOR ExpQ13 = XMVectorMultiply(XMVectorAdd(LnQ1, LnQ3), NegativeOneQuarter);
		ExpQ02 = XMQuaternionExp(ExpQ02);
		ExpQ13 = XMQuaternionExp(ExpQ13);

		pA = XMQuaternionMultiply(Q1, ExpQ02);
		pB = XMQuaternionMultiply(SQ2, ExpQ13);
		pC = SQ2;
	}

	/// <summary>Interpolates between four unit quaternions, using spherical quadrangle interpolation.</summary>
	/// <param name="Q0">First unit quaternion.</param>
	/// <param name="Q1">Second unit quaternion.</param>
	/// <param name="Q2">Third unit quaternion.</param>
	/// <param name="Q3">Fourth unit quaternion.</param>
	/// <param name="T">Interpolation control factor. All components of this vector must be the same.</param>
	/// <returns>
	/// Returns the interpolated quaternion. If <i>Q0</i>, <i>Q1</i>, <i>Q2</i>, and <i>Q3</i> are not unit quaternions, the resulting
	/// interpolation is undefined.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// <para>
	/// This function is identical to <c>XMQuaternionSquad</c> except that <i>T</i> is supplied using a 4D vector instead of a <b>float</b> value.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaternionsquadv XMVECTOR XM_CALLCONV
	// XMQuaternionSquadV( [in] FXMVECTOR Q0, [in] FXMVECTOR Q1, [in] FXMVECTOR Q2, [in] GXMVECTOR Q3, [in] HXMVECTOR T ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionSquadV")]
	public static XMVECTOR XMQuaternionSquadV(in FXMVECTOR Q0, in FXMVECTOR Q1, in FXMVECTOR Q2, in GXMVECTOR Q3, in HXMVECTOR T)
	{
		if (XMVectorGetY(T) != XMVectorGetX(T) || XMVectorGetZ(T) != XMVectorGetX(T) || XMVectorGetW(T) != XMVectorGetX(T))
			throw new ArgumentException("All components of T must be the same.");

		XMVECTOR TP = T;
		XMVECTOR Two = XMVectorSplatConstant(2, 0);

		XMVECTOR Q03 = XMQuaternionSlerpV(Q0, Q3, T);
		XMVECTOR Q12 = XMQuaternionSlerpV(Q1, Q2, T);

		TP = XMVectorNegativeMultiplySubtract(TP, TP, TP);
		TP = XMVectorMultiply(TP, Two);

		return XMQuaternionSlerpV(Q03, Q12, TP);
	}

	/// <summary>Computes an axis and angle of rotation about that axis for a given quaternion.</summary>
	/// <param name="pAxis">Address of a 3D vector describing the axis of rotation for the quaternion <i>Q</i>.</param>
	/// <param name="pAngle">Address of <b>float</b> describing the radian angle of rotation for the quaternion <i>Q</i>.</param>
	/// <param name="Q">Quaternion to measure.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// The DirectXMath quaternion functions use an XMVECTOR 4-vector to represent quaternions, where the X, Y, and Z components are the
	/// vector part and the W component is the scalar part.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmquaterniontoaxisangle void XM_CALLCONV
	// XMQuaternionToAxisAngle( [out] XMVECTOR *pAxis, [out] float *pAngle, [in] FXMVECTOR Q ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMQuaternionToAxisAngle")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMQuaternionToAxisAngle(out XMVECTOR pAxis, out float pAngle, in FXMVECTOR Q)
	{
		pAxis = Q;
		pAngle = 2.0f * XMScalarACos(XMVectorGetW(Q));
	}

	/// <summary>Computes the arccosine of a floating-point number.</summary>
	/// <param name="Value"><b>float</b> value between -1.0f and 1.0f.</param>
	/// <returns>Returns the inverse cosine of <i>Value</i>.</returns>
	/// <remarks>
	/// <para>This function uses a 7-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalaracos float XMScalarACos( [in] float Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarACos")]
	public static float XMScalarACos(float Value)
	{
		// Clamp input to [-1,1].
		bool nonnegative = Value >= 0.0f;
		float x = Math.Abs(Value);
		float omx = 1.0f - x;
		if (omx < 0.0f)
		{
			omx = 0.0f;
		}
		float root = (float)Math.Sqrt(omx);

		// 7-degree minimax approximation
		float result = ((((((-0.0012624911f * x + 0.0066700901f) * x - 0.0170881256f) * x + 0.0308918810f) * x - 0.0501743046f) * x + 0.0889789874f) * x - 0.2145988016f) * x + 1.5707963050f;
		result *= root;

		// acos(x) = pi - acos(-x) when x < 0
		return nonnegative ? result : XM_PI - result;
	}

	/// <summary>Estimates the arccosine of a floating-point number.</summary>
	/// <param name="Value"><b>float</b> value between -1.0f and 1.0f.</param>
	/// <returns>Returns the inverse cosine of <i>Value</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 3-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalaracosest float XMScalarACosEst( [in] float
	// Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarACosEst")]
	public static float XMScalarACosEst(float Value)
	{
		// Clamp input to [-1,1].
		bool nonnegative = Value >= 0.0f;
		float x = Math.Abs(Value);
		float omx = 1.0f - x;
		if (omx < 0.0f)
		{
			omx = 0.0f;
		}
		float root = (float)Math.Sqrt(omx);

		// 3-degree minimax approximation
		float result = ((-0.0187293f * x + 0.0742610f) * x - 0.2121144f) * x + 1.5707288f;
		result *= root;

		// acos(x) = pi - acos(-x) when x < 0
		return nonnegative ? result : XM_PI - result;
	}

	/// <summary>Computes the arcsine of a floating-point number.</summary>
	/// <param name="Value"><b>float</b> value between -1.0f and 1.0f.</param>
	/// <returns>Returns the inverse sine of <i>Value</i>.</returns>
	/// <remarks>
	/// <para>This function uses a 7-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalarasin float XMScalarASin( [in] float Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarASin")]
	public static float XMScalarASin(float Value)
	{
		// Clamp input to [-1,1].
		bool nonnegative = Value >= 0.0f;
		float x = Math.Abs(Value);
		float omx = 1.0f - x;
		if (omx < 0.0f)
		{
			omx = 0.0f;
		}
		float root = (float)Math.Sqrt(omx);

		// 7-degree minimax approximation
		float result = ((((((-0.0012624911f * x + 0.0066700901f) * x - 0.0170881256f) * x + 0.0308918810f) * x - 0.0501743046f) * x + 0.0889789874f) * x - 0.2145988016f) * x + 1.5707963050f;
		result *= root;  // acos(|x|)

		// acos(x) = pi - acos(-x) when x < 0, asin(x) = pi/2 - acos(x)
		return nonnegative ? XM_PIDIV2 - result : result - XM_PIDIV2;
	}

	/// <summary>Estimates the arcsine of a floating-point number.</summary>
	/// <param name="Value"><b>float</b> value between -1.0f and 1.0f.</param>
	/// <returns>Returns the inverse sine of <i>Value</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 3-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalarasinest float XMScalarASinEst( [in] float
	// Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarASinEst")]
	public static float XMScalarASinEst(float Value)
	{
		// Clamp input to [-1,1].
		bool nonnegative = Value >= 0.0f;
		float x = Math.Abs(Value);
		float omx = 1.0f - x;
		if (omx < 0.0f)
		{
			omx = 0.0f;
		}
		float root = (float)Math.Sqrt(omx);

		// 3-degree minimax approximation
		float result = ((-0.0187293f * x + 0.0742610f) * x - 0.2121144f) * x + 1.5707288f;
		result *= root;  // acos(|x|)

		// acos(x) = pi - acos(-x) when x < 0, asin(x) = pi/2 - acos(x)
		return nonnegative ? XM_PIDIV2 - result : result - XM_PIDIV2;
	}

	/// <summary>Computes the cosine of a radian angle.</summary>
	/// <param name="Value"><b>float</b> value describing the radian angle.</param>
	/// <returns>Returns the cosine of <i>Value</i>.</returns>
	/// <remarks>
	/// <para>This function uses a 10-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalarcos float XMScalarCos( [in] float Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarCos")]
	public static float XMScalarCos(float Value)
	{
		// Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
		float quotient = XM_1DIV2PI * Value;
		quotient = Value >= 0.0f ? (int)(quotient + 0.5f) : (int)(quotient - 0.5f);
		float y = Value - XM_2PI * quotient;

		// Map y to [-pi/2,pi/2] with cos(y) = sign*cos(x).
		float sign;
		if (y > XM_PIDIV2)
		{
			y = XM_PI - y;
			sign = -1.0f;
		}
		else if (y < -XM_PIDIV2)
		{
			y = -XM_PI - y;
			sign = -1.0f;
		}
		else
		{
			sign = +1.0f;
		}

		// 10-degree minimax approximation
		float y2 = y * y;
		float p = ((((-2.6051615e-07f * y2 + 2.4760495e-05f) * y2 - 0.0013888378f) * y2 + 0.041666638f) * y2 - 0.5f) * y2 + 1.0f;
		return sign * p;
	}

	/// <summary>Estimates the cosine of a radian angle.</summary>
	/// <param name="Value"><b>float</b> value describing the radian angle.</param>
	/// <returns>Returns the cosine of <i>Value</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 6-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalarcosest float XMScalarCosEst( [in] float Value
	// ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarCosEst")]
	public static float XMScalarCosEst(float Value)
	{
		// Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
		float quotient = XM_1DIV2PI * Value;
		quotient = Value >= 0.0f ? (int)(quotient + 0.5f) : (int)(quotient - 0.5f);
		float y = Value - XM_2PI * quotient;

		// Map y to [-pi/2,pi/2] with cos(y) = sign*cos(x).
		float sign;
		if (y > XM_PIDIV2)
		{
			y = XM_PI - y;
			sign = -1.0f;
		}
		else if (y < -XM_PIDIV2)
		{
			y = -XM_PI - y;
			sign = -1.0f;
		}
		else
		{
			sign = +1.0f;
		}

		// 6-degree minimax approximation
		float y2 = y * y;
		float p = ((-0.0012712436f * y2 + 0.041493919f) * y2 - 0.49992746f) * y2 + 1.0f;
		return sign * p;
	}

	/// <summary>Computes an angle between -XM_PI and XM_PI.</summary>
	/// <param name="Angle"><b>float</b> value describing the radian angle.</param>
	/// <returns>Returns an angle greater than or equal to -XM_PI and less than XM_PI that is congruent to <i>Value</i> modulo 2pi.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalarmodangle float XMScalarModAngle( [in] float
	// Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarModAngle")]
	public static float XMScalarModAngle(float Angle)
	{
		// Note: The modulo is performed with unsigned math only to work around a precision error on numbers that are close to PI

		// Normalize the range from 0.0f to XM_2PI
		Angle += XM_PI;
		// Perform the modulo, unsigned
		float fTemp = Math.Abs(Angle);
		fTemp -= XM_2PI * (int)(fTemp / XM_2PI);
		// Restore the number to the range of -XM_PI to XM_PI-epsilon
		fTemp -= XM_PI;
		// If the modulo'd value was negative, restore negation
		if (Angle < 0.0f)
		{
			fTemp = -fTemp;
		}
		return fTemp;
	}

	/// <summary>Determines if two floating-point values are nearly equal.</summary>
	/// <param name="S1">First floating-point value to compare.</param>
	/// <param name="S2">Second floating-point value to compare.</param>
	/// <param name="Epsilon">Tolerance to use when comparing <i>S1</i> and <i>S2</i>.</param>
	/// <returns>
	/// Returns true if the absolute value of the difference between <i>S1</i> and <i>S2</i> is less than or equal to <i>Epsilon</i>.
	/// Returns false otherwise.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalarnearequal bool XMScalarNearEqual( [in] float
	// S1, [in] float S2, [in] float Epsilon ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarNearEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMScalarNearEqual(float S1, float S2, float Epsilon) => Math.Abs((float)(S1 - S2)) <= Epsilon;

	/// <summary>Computes the sine of a radian angle.</summary>
	/// <param name="Value"><b>float</b> value describing the radian angle.</param>
	/// <returns>Returns the sine of <i>Value</i>.</returns>
	/// <remarks>
	/// <para>This function uses a 11-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalarsin float XMScalarSin( [in] float Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarSin")]
	public static float XMScalarSin(float Value)
	{
		// Map Value to y in [-pi,pi], x = ref 2 ref pi quotient + remainder.
		float quotient = XM_1DIV2PI * Value;
		quotient = Value >= 0.0f ? (int)(quotient + 0.5f) : (int)(quotient - 0.5f);
		float y = Value - XM_2PI * quotient;

		// Map y to [-pi/2,pi/2] with sin(y) = sin(Value).
		if (y > XM_PIDIV2)
		{
			y = XM_PI - y;
		}
		else if (y < -XM_PIDIV2)
		{
			y = -XM_PI - y;
		}

		// 11-degree minimax approximation
		float y2 = y * y;
		return (((((-2.3889859e-08f * y2 + 2.7525562e-06f) * y2 - 0.00019840874f) * y2 + 0.0083333310f) * y2 - 0.16666667f) * y2 + 1.0f) * y;
	}

	/// <summary>Computes both the sine and cosine of a radian angle.</summary>
	/// <param name="pSin">Address of a <b>float</b> that will contain the result of the sine of <i>Value</i>.</param>
	/// <param name="pCos">Address of a <b>float</b> that will contain the result of the cosine of <i>Value</i>.</param>
	/// <param name="Value"><b>float</b> value describing the radian angle.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>This function uses a 11-degree minimax approximation for sine; 10-degree for cosine.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalarsincos void XMScalarSinCos( [out] float *pSin,
	// [out] float *pCos, [in] float Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarSinCos")]
	public static void XMScalarSinCos(out float pSin, out float pCos, [In] float Value)
	{
		// Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
		float quotient = XM_1DIV2PI * Value;
		quotient = Value >= 0.0f ? (int)(quotient + 0.5f) : (int)(quotient - 0.5f);
		float y = Value - XM_2PI * quotient;

		// Map y to [-pi/2,pi/2] with sin(y) = sin(Value).
		float sign;
		if (y > XM_PIDIV2)
		{
			y = XM_PI - y;
			sign = -1.0f;
		}
		else if (y < -XM_PIDIV2)
		{
			y = -XM_PI - y;
			sign = -1.0f;
		}
		else
		{
			sign = +1.0f;
		}

		float y2 = y * y;

		// 11-degree minimax approximation
		pSin = (((((-2.3889859e-08f * y2 + 2.7525562e-06f) * y2 - 0.00019840874f) * y2 + 0.0083333310f) * y2 - 0.16666667f) * y2 + 1.0f) * y;

		// 10-degree minimax approximation
		float p = ((((-2.6051615e-07f * y2 + 2.4760495e-05f) * y2 - 0.0013888378f) * y2 + 0.041666638f) * y2 - 0.5f) * y2 + 1.0f;
		pCos = sign * p;
	}

	/// <summary>Estimates both the sine and cosine of a radian angle.</summary>
	/// <param name="pSin">Address of a <b>float</b> that will contain the result of the sine of <i>Value</i>.</param>
	/// <param name="pCos">Address of a <b>float</b> that will contain the result of the cosine of <i>Value</i>.</param>
	/// <param name="Value"><b>float</b> value describing the radian angle.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 7-degree minimax approximation for sine; 6-degree for cosine.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalarsincosest void XMScalarSinCosEst( [out] float
	// *pSin, [out] float *pCos, [in] float Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarSinCosEst")]
	public static void XMScalarSinCosEst(out float pSin, out float pCos, float Value)
	{
		// Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
		float quotient = XM_1DIV2PI * Value;
		quotient = Value >= 0.0f ? (int)(quotient + 0.5f) : (int)(quotient - 0.5f);
		float y = Value - XM_2PI * quotient;

		// Map y to [-pi/2,pi/2] with sin(y) = sin(Value).
		float sign;
		if (y > XM_PIDIV2)
		{
			y = XM_PI - y;
			sign = -1.0f;
		}
		else if (y < -XM_PIDIV2)
		{
			y = -XM_PI - y;
			sign = -1.0f;
		}
		else
		{
			sign = +1.0f;
		}

		float y2 = y * y;

		// 11-degree minimax approximation
		pSin = (((((-2.3889859e-08f * y2 + 2.7525562e-06f) * y2 - 0.00019840874f) * y2 + 0.0083333310f) * y2 - 0.16666667f) * y2 + 1.0f) * y;

		// 10-degree minimax approximation
		float p = ((((-2.6051615e-07f * y2 + 2.4760495e-05f) * y2 - 0.0013888378f) * y2 + 0.041666638f) * y2 - 0.5f) * y2 + 1.0f;
		pCos = sign * p;
	}

	/// <summary>Estimates the sine of a radian angle.</summary>
	/// <param name="Value"><b>float</b> value describing the radian angle.</param>
	/// <returns>Returns an estimate of the sine of <i>Value</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 7-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmscalarsinest float XMScalarSinEst( [in] float Value
	// ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMScalarSinEst")]
	public static float XMScalarSinEst(float Value)
	{
		// Map Value to y in [-pi,pi], x = 2*pi*quotient + remainder.
		float quotient = XM_1DIV2PI * Value;
		quotient = Value >= 0.0f ? (int)(quotient + 0.5f) : (int)(quotient - 0.5f);
		float y = Value - XM_2PI * quotient;

		// Map y to [-pi/2,pi/2] with sin(y) = sin(Value).
		if (y > XM_PIDIV2)
		{
			y = XM_PI - y;
		}
		else if (y < -XM_PIDIV2)
		{
			y = -XM_PI - y;
		}

		// 7-degree minimax approximation
		float y2 = y * y;
		return (((-0.00018524670f * y2 + 0.0083139502f) * y2 - 0.16665852f) * y2 + 1.0f) * y;
	}

	/// <summary>Indicates if the DirectXMath Library supports the current platform.</summary>
	/// <returns>Returns true if the DirectXMath Library supports a given platform; false if it does not.</returns>
	/// <remarks>
	/// <para>
	/// This is a run-time check of processor support and should be called at startup of the program before any DirectXMath functions or
	/// types are used.
	/// </para>
	/// <para>On Windows, this function is implemented using <c>IsProcessorFeaturePresent</c>.</para>
	/// <para>Therefore, when executed on windows, <c>XMVerifyCPUSupport</c> shares platform support requirements of <c>IsProcessorFeaturePresent</c>.</para>
	/// <para>
	/// <b>Note</b>  To avoid a hard dependency on windows.h, if <i>IsProcessorFeaturePresent</i> is not defined this function always
	/// returns <c>false</c>. Be sure to include "windows.h" before "directxmath.h" in any module where you are calling this function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmverifycpusupport bool XMVerifyCPUSupport() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVerifyCPUSupport")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool XMVerifyCPUSupport() => true;

	private static XMVECTOR XMColorHue2Clr(in FXMVECTOR p, in FXMVECTOR q, in FXMVECTOR h)
	{
		XMVECTORF32 oneSixth = new(1.0f / 6.0f, 1.0f / 6.0f, 1.0f / 6.0f, 1.0f / 6.0f);
		XMVECTORF32 twoThirds = new(2.0f / 3.0f, 2.0f / 3.0f, 2.0f / 3.0f, 2.0f / 3.0f);

		XMVECTOR t = h;

		if (XMVector3Less(t, XMVECTOR.g_XMZero))
			t = XMVectorAdd(t, XMVECTOR.g_XMOne);

		if (XMVector3Greater(t, XMVECTOR.g_XMOne))
			t = XMVectorSubtract(t, XMVECTOR.g_XMOne);

		if (XMVector3Less(t, oneSixth))
		{
			// p + (q - p) * ref 6 t
			XMVECTOR t1 = XMVectorSubtract(q, p);
			XMVECTOR t2 = XMVectorMultiply(XMVECTOR.g_XMSix, t);
			return XMVectorMultiplyAdd(t1, t2, p);
		}

		if (XMVector3Less(t, XMVECTOR.g_XMOneHalf))
			return q;

		if (XMVector3Less(t, twoThirds))
		{
			// p + (q - p) * ref 6 (2/3 - t)
			XMVECTOR t1 = XMVectorSubtract(q, p);
			XMVECTOR t2 = XMVectorMultiply(XMVECTOR.g_XMSix, XMVectorSubtract(twoThirds, t));
			return XMVectorMultiplyAdd(t1, t2, p);
		}

		return p;
	}
}