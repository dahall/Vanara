using System.Drawing;
using static Vanara.PInvoke.DXGI;

namespace Vanara.PInvoke;

/// <summary>Items from the D2d1.dll</summary>
public static partial class D2d1
{
	/// <summary>Specifies how the alpha value of a bitmap or render target should be treated.</summary>
	/// <remarks>
	/// <para>
	/// The <c>D2D1_ALPHA_MODE</c> enumeration is used with the D2D1_PIXEL_FORMAT enumeration to specify the alpha mode of a render
	/// target or bitmap. Different render targets and bitmaps support different alpha modes. For a list, see Supported Pixel Formats
	/// and Alpha Modes.
	/// </para>
	/// <para>The Differences Between Straight and Premultiplied Alpha</para>
	/// <para>
	/// When describing an RGBA color using straight alpha, the alpha value of the color is stored in the alpha channel. For example, to
	/// describe a red color that is 60% opaque, you'd use the following values: (255, 0, 0, 255 * 0.6) = (255, 0, 0, 153). The 255
	/// value indicates full red, and 153 (which is 60 percent of 255) indicates that the color should have an opacity of 60 percent.
	/// </para>
	/// <para>
	/// When describing an RGBA color using premultiplied alpha, each color is multiplied by the alpha value: (255 * 0.6, 0 * 0.6, 0 *
	/// 0.6, 255 * 0.6) = (153, 0, 0, 153).
	/// </para>
	/// <para>
	/// Regardless of the alpha mode of the render target, D2D1_COLOR_F values are always interpreted as straight alpha. For example,
	/// when specifying the color of an ID2D1SolidColorBrush for use with a bitmap that uses the premultiplied alpha mode, you'd specify
	/// the color just as you would if the bitmap used straight alpha. When you paint with the brush, Direct2D translates the color to
	/// the destination format for you.
	/// </para>
	/// <para>Alpha Mode for Render Targets</para>
	/// <para>
	/// Regardless of the alpha mode setting, a render target's contents support transparency. For example, if you draw a partially
	/// transparent red rectangle with a render target with an alpha mode of <c>D2D1_ALPHA_MODE_IGNORE</c>, the rectangle will appear
	/// pink (if the background is white), as you might expect.
	/// </para>
	/// <para>
	/// If you draw a partially transparent red rectangle when the alpha mode is CreateCompatibleRenderTarget method) to create a bitmap
	/// that supports transparency.
	/// </para>
	/// <para>ClearType and Alpha Modes</para>
	/// <para>
	/// If you specify an alpha mode other than <c>D2D1_ALPHA_MODE_IGNORE</c> for a render target, the text antialiasing mode
	/// automatically changes from D2D1_TEXT_ANTIALIAS_MODE CLEARTYPE to <c>D2D1_TEXT_ANTIALIAS_MODE GRAYSCALE</c>. (When you specify an
	/// alpha mode of <c>D2D1_ALPHA_MODE_UNKNOWN</c>, Direct2D sets the alpha for you depending on the type of render target. For a list
	/// of what the <c>D2D1_ALPHA_MODE_UNKNOWN</c> setting resolves to for each render target, see the Supported Pixel Formats and Alpha
	/// Modes overview.)
	/// </para>
	/// <para>
	/// You can use the SetTextAntialiasMode method to change the text antialias mode back to D2D1_TEXT_ANTIALIAS_MODE CLEARTYPE, but
	/// rendering ClearType text to a transparent surface can create unpredictable results. If you want to render ClearType text to an
	/// transparent render target, we recommend that you use one of the following two techniques.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Use the PushAxisAlignedClip method to clip the render target to the area where the text will be rendered, then call the Clear
	/// method and specify an opaque color, then render your text.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Use DrawRectangle to draw an opaque rectangle behind the area where the text will be rendered.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ne-dcommon-d2d1_alpha_mode typedef enum D2D1_ALPHA_MODE {
	// D2D1_ALPHA_MODE_UNKNOWN, D2D1_ALPHA_MODE_PREMULTIPLIED, D2D1_ALPHA_MODE_STRAIGHT, D2D1_ALPHA_MODE_IGNORE,
	// D2D1_ALPHA_MODE_FORCE_DWORD } ;
	[PInvokeData("dcommon.h", MSDNShortId = "f1b1e735-2e89-4dc1-9fee-dfb4626ef453")]
	public enum D2D1_ALPHA_MODE : uint
	{
		/// <summary>The alpha value might not be meaningful.</summary>
		D2D1_ALPHA_MODE_UNKNOWN,

		/// <summary>
		/// The alpha value has been premultiplied. Each color is first scaled by the alpha value. The alpha value itself is the same in
		/// both straight and premultiplied alpha. Typically, no color channel value is greater than the alpha channel value. If a color
		/// channel value in a premultiplied format is greater than the alpha channel, the standard source-over blending math results in
		/// an additive blend.
		/// </summary>
		D2D1_ALPHA_MODE_PREMULTIPLIED,

		/// <summary>The alpha value has not been premultiplied. The alpha channel indicates the transparency of the color.</summary>
		D2D1_ALPHA_MODE_STRAIGHT,

		/// <summary>The alpha value is ignored.</summary>
		D2D1_ALPHA_MODE_IGNORE,

		/// <summary/>
		D2D1_ALPHA_MODE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Represents a 3-by-2 matrix.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_matrix_3x2_f typedef struct D2D_MATRIX_3X2_F { union {
	// struct { FLOAT m11; FLOAT m12; FLOAT m21; FLOAT m22; FLOAT dx; FLOAT dy; }; struct { FLOAT _11; FLOAT _12; FLOAT _21; FLOAT _22;
	// FLOAT _31; FLOAT _32; }; FLOAT m[3][2]; }; } D2D_MATRIX_3X2_F;
	[PInvokeData("dcommon.h", MSDNShortId = "c8a54bad-4376-479b-8529-1e407623e473")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_MATRIX_3X2_F
	{
		/// <summary>Horizontal scaling / cosine of rotation</summary>
		public float m11;

		/// <summary>Vertical shear / sine of rotation</summary>
		public float m12;

		/// <summary>Horizontal shear / negative sine of rotation</summary>
		public float m21;

		/// <summary>Vertical scaling / cosine of rotation</summary>
		public float m22;

		/// <summary>Horizontal shift (always orthogonal regardless of rotation)</summary>
		public float dx;

		/// <summary>Vertical shift (always orthogonal regardless of rotation)</summary>
		public float dy;

		/// <summary>Gets or sets the values as a multidimensional (3x2) array.</summary>
		/// <value>The array value.</value>
		/// <exception cref="ArgumentOutOfRangeException">m - Value must a 3x2 array.</exception>
		public float[,] m
		{
			get => new[,] { { m11, m12 }, { m21, m22 }, { dx, dy } };
			set
			{
				if (value.GetLength(0) != 3 || value.GetLength(1) != 2)
					throw new ArgumentOutOfRangeException(nameof(m), "Value must a 3x2 array.");
				m11 = value[0, 0];
				m12 = value[0, 1];
				m21 = value[1, 0];
				m22 = value[1, 1];
				dx = value[2, 0];
				dy = value[2, 1];
			}
		}

		/// <summary>Performs an implicit conversion from <see cref="float"/>[,] to <see cref="D2D_MATRIX_3X2_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_3X2_F(float[,] value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_3X2_F"/> to <see cref="float"/>[,].</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[,](D2D_MATRIX_3X2_F value) => value.m;

		/// <summary>Performs an implicit conversion from <see cref="Matrix"/> to <see cref="D2D_MATRIX_3X2_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_3X2_F(Matrix value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_3X2_F"/> to <see cref="Matrix"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Matrix(D2D_MATRIX_3X2_F value) => new(value.m);
	}

	/// <summary>Describes a 4-by-3 floating point matrix.</summary>
	/// <remarks>The <c>D2D1_MATRIX_4X3_F</c> structure is type defined from a <c>D2D_MATRIX_4X3_F</c> structure in D2d1_1.h.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_matrix_4x3_f
	// typedef struct D2D_MATRIX_4X3_F { union { struct { FLOAT _11; FLOAT _12; FLOAT _13; FLOAT _21; FLOAT _22; FLOAT _23; FLOAT _31; FLOAT _32; FLOAT _33; FLOAT _41; FLOAT _42; FLOAT _43; } DUMMYSTRUCTNAME; FLOAT m[4][3]; } DUMMYUNIONNAME; } D2D_MATRIX_4X3_F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_MATRIX_4X3_F")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_MATRIX_4X3_F
	{
		/// <summary/>
		public float _11;

		/// <summary/>	;
		public float _12;

		/// <summary/>	;
		public float _13;

		/// <summary/>	;
		public float _21;

		/// <summary/>	;
		public float _22;

		/// <summary/>	;
		public float _23;

		/// <summary/>	;
		public float _31;

		/// <summary/>	;
		public float _32;

		/// <summary/>	;
		public float _33;

		/// <summary/>	;
		public float _41;

		/// <summary/>	;
		public float _42;

		/// <summary/>	;
		public float _43;

		/// <summary/>
		public float[,] m
		{
			get => new[,] { { _11, _12, _13 }, { _21, _22, _23 }, { _31, _32, _33 }, { _41, _42, _43 } };
			set
			{
				unsafe
				{
					if (value.GetLength(0) != 4 || value.GetLength(1) != 3)
						throw new ArgumentOutOfRangeException(nameof(m), "Value must a 4x3 array.");
					_11 = value[0, 0];
					_12 = value[0, 1];
					_13 = value[0, 2];
					_21 = value[1, 0];
					_22 = value[1, 1];
					_23 = value[1, 2];
					_31 = value[2, 0];
					_32 = value[2, 1];
					_33 = value[2, 2];
					_41 = value[3, 0];
					_42 = value[3, 1];
					_43 = value[3, 2];
				}
			}
		}

		/// <summary>Performs an implicit conversion from <see cref="float"/>[,] to <see cref="D2D_MATRIX_4X3_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_4X3_F(float[,] value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_4X3_F"/> to <see cref="float"/>[,].</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[,](D2D_MATRIX_4X3_F value) => value.m;

		/// <summary>Performs an implicit conversion from <see cref="Matrix"/> to <see cref="D2D_MATRIX_4X3_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_4X3_F(Matrix value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_4X3_F"/> to <see cref="Matrix"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Matrix(D2D_MATRIX_4X3_F value) => new(value.m);
	}

	/// <summary>Describes a 4-by-4 floating point matrix.</summary>
	/// <remarks>The <c>D2D1_MATRIX_4X4_F</c> structure is type defined from a <c>D2D_MATRIX_4X4_F</c> structure in D2d1_1.h.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_matrix_4x4_f
	// typedef struct D2D_MATRIX_4X4_F { union { struct { FLOAT _11; FLOAT _12; FLOAT _13; FLOAT _14; FLOAT _21; FLOAT _22; FLOAT _23; FLOAT _24; FLOAT _31; FLOAT _32; FLOAT _33; FLOAT _34; FLOAT _41; FLOAT _42; FLOAT _43; FLOAT _44; } DUMMYSTRUCTNAME; FLOAT m[4][4]; } DUMMYUNIONNAME; } D2D_MATRIX_4X4_F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_MATRIX_4X4_F")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_MATRIX_4X4_F
	{
		/// <summary/>
		public float _11;

		/// <summary/>	;
		public float _12;

		/// <summary/>	;
		public float _13;

		/// <summary/>	;
		public float _14;

		/// <summary/>	;
		public float _21;

		/// <summary/>	;
		public float _22;

		/// <summary/>	;
		public float _23;

		/// <summary/>	;
		public float _24;

		/// <summary/>	;
		public float _31;

		/// <summary/>	;
		public float _32;

		/// <summary/>	;
		public float _33;

		/// <summary/>	;
		public float _34;

		/// <summary/>	;
		public float _41;

		/// <summary/>	;
		public float _42;

		/// <summary/>	;
		public float _43;

		/// <summary/>	;
		public float _44;

		/// <summary/>
		public float[,] m
		{
			get => new[,] { { _11, _12, _13, _14 }, { _21, _22, _23, _24 }, { _31, _32, _33, _34 }, { _41, _42, _43, _44 } };
			set
			{
				if (value.GetLength(0) != 4 || value.GetLength(1) != 4)
					throw new ArgumentOutOfRangeException(nameof(m), "Value must a 4x4 array.");
				_11 = value[0, 0];
				_12 = value[0, 1];
				_13 = value[0, 2];
				_14 = value[0, 3];
				_21 = value[1, 0];
				_22 = value[1, 1];
				_23 = value[1, 2];
				_24 = value[1, 3];
				_31 = value[2, 0];
				_32 = value[2, 1];
				_33 = value[2, 2];
				_34 = value[2, 3];
				_41 = value[3, 0];
				_42 = value[3, 1];
				_43 = value[3, 2];
				_44 = value[3, 3];
			}
		}

		/// <summary>Performs an implicit conversion from <see cref="float"/>[,] to <see cref="D2D_MATRIX_4X4_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_4X4_F(float[,] value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_4X4_F"/> to <see cref="float"/>[,].</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[,](D2D_MATRIX_4X4_F value) => value.m;

		/// <summary>Performs an implicit conversion from <see cref="Matrix"/> to <see cref="D2D_MATRIX_4X4_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_4X4_F(Matrix value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_4X4_F"/> to <see cref="Matrix"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Matrix(D2D_MATRIX_4X4_F value) => new(value.m);
	}

	/// <summary>Describes a 5-by-4 floating point matrix.</summary>
	/// <remarks>The <c>D2D1_MATRIX_5X4_F</c> structure is type defined from a <c>D2D_MATRIX_5X4_F</c> structure in D2d1_1.h.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_matrix_5x4_f typedef struct D2D_MATRIX_5X4_F { union {
	// struct { FLOAT _11; FLOAT _12; FLOAT _13; FLOAT _14; FLOAT _21; FLOAT _22; FLOAT _23; FLOAT _24; FLOAT _31; FLOAT _32; FLOAT _33;
	// FLOAT _34; FLOAT _41; FLOAT _42; FLOAT _43; FLOAT _44; FLOAT _51; FLOAT _52; FLOAT _53; FLOAT _54; } DUMMYSTRUCTNAME; FLOAT m[5][4];
	// } DUMMYUNIONNAME; } D2D_MATRIX_5X4_F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_MATRIX_5X4_F")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_MATRIX_5X4_F
	{
		/// <summary/>
		public float _11;

		/// <summary/>	;
		public float _12;

		/// <summary/>	;
		public float _13;

		/// <summary/>	;
		public float _14;

		/// <summary/>	;
		public float _21;

		/// <summary/>	;
		public float _22;

		/// <summary/>	;
		public float _23;

		/// <summary/>	;
		public float _24;

		/// <summary/>	;
		public float _31;

		/// <summary/>	;
		public float _32;

		/// <summary/>	;
		public float _33;

		/// <summary/>	;
		public float _34;

		/// <summary/>	;
		public float _41;

		/// <summary/>	;
		public float _42;

		/// <summary/>	;
		public float _43;

		/// <summary/>	;
		public float _44;

		/// <summary/>	;
		public float _51;

		/// <summary/>	;
		public float _52;

		/// <summary/>	;
		public float _53;

		/// <summary/>	;
		public float _54;

		/// <summary/>
		public float[,] m
		{
			get => new[,] { { _11, _12, _13, _14 }, { _21, _22, _23, _24 }, { _31, _32, _33, _34 }, { _41, _42, _43, _44 }, { _51, _52, _53, _54 } };
			set
			{
				if (value.GetLength(0) != 5 || value.GetLength(1) != 4)
					throw new ArgumentOutOfRangeException(nameof(m), "Value must a 5x4 array.");
				_11 = value[0, 0];
				_12 = value[0, 1];
				_13 = value[0, 2];
				_14 = value[0, 3];
				_21 = value[1, 0];
				_22 = value[1, 1];
				_23 = value[1, 2];
				_24 = value[1, 3];
				_31 = value[2, 0];
				_32 = value[2, 1];
				_33 = value[2, 2];
				_34 = value[2, 3];
				_41 = value[3, 0];
				_42 = value[3, 1];
				_43 = value[3, 2];
				_44 = value[3, 3];
				_51 = value[4, 0];
				_52 = value[4, 1];
				_53 = value[4, 2];
				_54 = value[4, 3];
			}
		}

		/// <summary>Performs an implicit conversion from <see cref="float"/>[,] to <see cref="D2D_MATRIX_5X4_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_5X4_F(float[,] value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_5X4_F"/> to <see cref="float"/>[,].</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[,](D2D_MATRIX_5X4_F value) => value.m;

		/// <summary>Performs an implicit conversion from <see cref="Matrix"/> to <see cref="D2D_MATRIX_5X4_F"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_MATRIX_5X4_F(Matrix value) => new() { m = value };

		/// <summary>Performs an implicit conversion from <see cref="D2D_MATRIX_5X4_F"/> to <see cref="Matrix"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Matrix(D2D_MATRIX_5X4_F value) => new(value.m);
	}

	/// <summary>Represents an x-coordinate and y-coordinate pair, expressed as floating-point values, in two-dimensional space.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_point_2f typedef struct D2D_POINT_2F { FLOAT x; FLOAT
	// y; } D2D_POINT_2F;
	[PInvokeData("dcommon.h", MSDNShortId = "2ee55d63-594b-482d-9e31-2378369c6c30")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_POINT_2F(float x, float y)
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the point.</para>
		/// </summary>
		public float x = x;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the point.</para>
		/// </summary>
		public float y = y;

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.Drawing.PointF"/> to <see cref="Vanara.PInvoke.D2d1.D2D_POINT_2F"/>.
		/// </summary>
		/// <param name="pointF">The point f.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_POINT_2F(PointF pointF) => new(pointF.X, pointF.Y);

		/// <summary>
		/// Performs an implicit conversion from <see cref="Vanara.PInvoke.D2d1.D2D_POINT_2F"/> to <see cref="System.Drawing.PointF"/>.
		/// </summary>
		/// <param name="pointF">The point f.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PointF(D2D_POINT_2F pointF) => new(pointF.x, pointF.y);
	}

	/// <summary>
	/// Represents a rectangle defined by the coordinates of the upper-left corner (left, top) and the coordinates of the lower-right
	/// corner (right, bottom).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_rect_f typedef struct D2D_RECT_F { FLOAT left; FLOAT
	// top; FLOAT right; FLOAT bottom; } D2D_RECT_F;
	[PInvokeData("dcommon.h", MSDNShortId = "84bd7ab0-f273-46f8-b261-86cd1d7f3868")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_RECT_F(float left, float top, float right, float bottom)
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the upper-left corner of the rectangle.</para>
		/// </summary>
		public float left = left;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the upper-left corner of the rectangle.</para>
		/// </summary>
		public float top = top;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the lower-right corner of the rectangle.</para>
		/// </summary>
		public float right = right;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the lower-right corner of the rectangle.</para>
		/// </summary>
		public float bottom = bottom;

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.Drawing.RectangleF"/> to <see cref="Vanara.PInvoke.D2d1.D2D_RECT_F"/>.
		/// </summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_RECT_F(RectangleF r) => new(r.Left, r.Top, r.Right, r.Bottom);

		/// <summary>
		/// Performs an implicit conversion from <see cref="Vanara.PInvoke.D2d1.D2D_RECT_F"/> to <see cref="System.Drawing.RectangleF"/>.
		/// </summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator RectangleF(D2D_RECT_F r) => RectangleF.FromLTRB(r.left, r.top, r.right, r.bottom);
	}

	/// <summary>Stores an ordered pair of floating-point values, typically the width and height of a rectangle.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_size_f typedef struct D2D_SIZE_F { FLOAT width; FLOAT
	// height; } D2D_SIZE_F;
	[PInvokeData("dcommon.h", MSDNShortId = "9d519bb9-3eb8-4d7e-ba00-b6cf5a428a04")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_SIZE_F(float width, float height)
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal component of this size.</para>
		/// </summary>
		public float width = width;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The vertical component of this size.</para>
		/// </summary>
		public float height = height;

		/// <summary>Performs an implicit conversion from <see cref="System.Drawing.SizeF"/> to <see cref="Vanara.PInvoke.D2d1.D2D_SIZE_F"/>.</summary>
		/// <param name="sz">The sz.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D_SIZE_F(SizeF sz) => new(sz.Width, sz.Height);

		/// <summary>Performs an implicit conversion from <see cref="Vanara.PInvoke.D2d1.D2D_SIZE_F"/> to <see cref="System.Drawing.SizeF"/>.</summary>
		/// <param name="sz">The sz.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeF(D2D_SIZE_F sz) => new(sz.width, sz.height);
	}

	/// <summary>Stores an ordered pair of integers, typically the width and height of a rectangle.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_size_u typedef struct D2D_SIZE_U { UINT32 width; UINT32
	// height; } D2D_SIZE_U;
	[PInvokeData("dcommon.h", MSDNShortId = "d9ea9df5-7c5f-4afa-9859-14d77b017904")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_SIZE_U(uint width, uint height)
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The horizontal component of this size.</para>
		/// </summary>
		public uint width = width;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The vertical component of this size.</para>
		/// </summary>
		public uint height = height;

		/// <summary>Performs an explicit conversion from <see cref="System.Drawing.Size"/> to <see cref="Vanara.PInvoke.D2d1.D2D_SIZE_U"/>.</summary>
		/// <param name="sz">The sz.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator D2D_SIZE_U(Size sz) => new((uint)sz.Width, (uint)sz.Height);
	}

	/// <summary>A vector of 2 FLOAT values (x, y).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_vector_2f
	// typedef struct D2D_VECTOR_2F { FLOAT x; FLOAT y; } D2D_VECTOR_2F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_VECTOR_2F")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_VECTOR_2F
	{
		/// <summary>The x value of the vector.</summary>
		public float x;

		/// <summary>The y value of the vector.</summary>
		public float y;
	}

	/// <summary>A vector of 3 FLOAT values (x, y, z).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_vector_3f
	// typedef struct D2D_VECTOR_3F { FLOAT x; FLOAT y; FLOAT z; } D2D_VECTOR_3F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_VECTOR_3F")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_VECTOR_3F
	{
		/// <summary>The x value of the vector.</summary>
		public float x;

		/// <summary>The y value of the vector.</summary>
		public float y;

		/// <summary>The z value of the vector.</summary>
		public float z;
	}

	/// <summary>A vector of 4 FLOAT values (x, y, z, w).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_vector_4f
	// typedef struct D2D_VECTOR_4F { FLOAT x; FLOAT y; FLOAT z; FLOAT w; } D2D_VECTOR_4F;
	[PInvokeData("dcommon.h", MSDNShortId = "NS:dcommon.D2D_VECTOR_4F")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_VECTOR_4F
	{
		/// <summary>The x value of the vector.</summary>
		public float x;

		/// <summary>The y value of the vector.</summary>
		public float y;

		/// <summary>The z value of the vector.</summary>
		public float z;

		/// <summary>The w value of the vector.</summary>
		public float w;
	}

	/// <summary>Contains the data format and alpha mode for a bitmap or render target.</summary>
	/// <remarks>
	/// <para>
	/// For more information about the pixel formats and alpha modes supported by each render target, see Supported Pixel Formats and
	/// Alpha Modes.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example creates a <c>D2D1_PIXEL_FORMAT</c> structure and uses it to specify the pixel format and alpha mode of an ID2D1HwndRenderTarget.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d1_pixel_format typedef struct D2D1_PIXEL_FORMAT {
	// DXGI_FORMAT format; D2D1_ALPHA_MODE alphaMode; } D2D1_PIXEL_FORMAT;
	[PInvokeData("dcommon.h", MSDNShortId = "e95afd9c-5793-4cb7-bcb8-aae4d28b6532")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_PIXEL_FORMAT
	{
		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>A value that specifies the size and arrangement of channels in each pixel.</para>
		/// </summary>
		public DXGI_FORMAT format;

		/// <summary>
		/// <para>Type: <c>D2D1_ALPHA_MODE</c></para>
		/// <para>
		/// A value that specifies whether the alpha channel is using pre-multiplied alpha, straight alpha, whether it should be ignored
		/// and considered opaque, or whether it is unkown.
		/// </para>
		/// </summary>
		public D2D1_ALPHA_MODE alphaMode;
	}
}