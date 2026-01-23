using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

public static partial class DirectXMath
{
	/// <summary>Computes the radian angle between two normalized 2D vectors.</summary>
	/// <param name="N1">Normalized 2D vector.</param>
	/// <param name="N2">Normalized 2D vector.</param>
	/// <returns>Returns a vector. The radian angle between <i>N1</i> and <i>N2</i> is replicated to each of the components.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2anglebetweennormals XMVECTOR XM_CALLCONV
	// XMVector2AngleBetweenNormals( [in] FXMVECTOR N1, [in] FXMVECTOR N2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2AngleBetweenNormals")]
	public static XMVECTOR XMVector2AngleBetweenNormals(this FXMVECTOR N1, in FXMVECTOR N2) =>
		XMVectorACos(XMVectorClamp(XMVector2Dot(N1, N2), XMVECTOR.g_XMNegativeOne, XMVECTOR.g_XMOne));

	/// <summary>Estimates the radian angle between two normalized 2D vectors.</summary>
	/// <param name="N1">Normalized 2D vector.</param>
	/// <param name="N2">Normalized 2D vector.</param>
	/// <returns>Returns a vector. The estimate of the radian angle (between <i>N1</i> and <i>N2</i>) is replicated to each of the components.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2anglebetweennormalsest XMVECTOR XM_CALLCONV
	// XMVector2AngleBetweenNormalsEst( [in] FXMVECTOR N1, [in] FXMVECTOR N2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2AngleBetweenNormalsEst")]
	public static XMVECTOR XMVector2AngleBetweenNormalsEst(this FXMVECTOR N1, in FXMVECTOR N2) => XMVector2AngleBetweenNormals(N1, N2);

	/// <summary>Computes the radian angle between two 2D vectors.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns a vector. The radian angle between <i>V1</i> and <i>V2</i> is replicated to each of the components.</returns>
	/// <remarks>
	/// <para>If V1 and V2 are normalized 2D vectors, it is faster to use <c>XMVector2AngleBetweenNormals</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2anglebetweenvectors XMVECTOR XM_CALLCONV
	// XMVector2AngleBetweenVectors( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2AngleBetweenVectors")]
	public static XMVECTOR XMVector2AngleBetweenVectors(this FXMVECTOR V1, in FXMVECTOR V2)
	{
		XMVECTOR L1 = XMVector2ReciprocalLength(V1);
		XMVECTOR L2 = XMVector2ReciprocalLength(V2);

		XMVECTOR Dot = XMVector2Dot(V1, V2);

		L1 = XMVectorMultiply(L1, L2);

		XMVECTOR CosAngle = XMVectorMultiply(Dot, L1);
		CosAngle = XMVectorClamp(CosAngle, XMVECTOR.g_XMNegativeOne, XMVECTOR.g_XMOne);

		return XMVectorACos(CosAngle);
	}

	/// <summary>Clamps the length of a 2D vector to a given range.</summary>
	/// <param name="V">2D vector.</param>
	/// <param name="LengthMin">Minimum clamp length.</param>
	/// <param name="LengthMax">Maximum clamp length.</param>
	/// <returns>Returns a 2D vector whose length is clamped to the specified minimum and maximum.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2clamplength XMVECTOR XM_CALLCONV
	// XMVector2ClampLength( [in] FXMVECTOR V, [in] float LengthMin, [in] float LengthMax );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2ClampLength")]
	public static XMVECTOR XMVector2ClampLength(this FXMVECTOR V, float LengthMin, float LengthMax) =>
		XMVector2ClampLengthV(V, XMVectorReplicate(LengthMin), XMVectorReplicate(LengthMax));

	/// <summary>Clamps the length of a 2D vector to a given range.</summary>
	/// <param name="V">2D vector to clamp.</param>
	/// <param name="LengthMin">
	/// 2D vector whose x and y-components are both equal to the minimum clamp length. The x and y-components must be greater-than-or-equal
	/// to zero.
	/// </param>
	/// <param name="LengthMax">
	/// 2D vector whose x and y-components are both equal to the maximum clamp length. The x and y-components must be greater-than-or-equal
	/// to zero.
	/// </param>
	/// <returns>Returns a 2D vector whose length is clamped to the specified minimum and maximum.</returns>
	/// <remarks>
	/// <para>
	/// This function is identical to <c>XMVector2ClampLength</c> except that <i>LengthMin</i> and <i>LengthMax</i> are supplied using 2D
	/// vectors instead of <b>float</b> values.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2clamplengthv XMVECTOR XM_CALLCONV
	// XMVector2ClampLengthV( [in] FXMVECTOR V, [in] FXMVECTOR LengthMin, [in] FXMVECTOR LengthMax );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2ClampLengthV")]
	public static XMVECTOR XMVector2ClampLengthV(this FXMVECTOR V, in FXMVECTOR LengthMin, in FXMVECTOR LengthMax)
	{
		XMVECTOR Zero = XMVectorZero();

		if (XMVectorGetY(LengthMin) != XMVectorGetX(LengthMin)) throw new ArgumentException("Values must be equal.", nameof(LengthMin));
		if (XMVectorGetY(LengthMax) != XMVectorGetX(LengthMax)) throw new ArgumentException("Values must be equal.", nameof(LengthMax));
		if (XMVector2Less(LengthMin, Zero)) throw new ArgumentException("Values cannot be negative.", nameof(LengthMin));
		if (XMVector2Less(LengthMax, Zero)) throw new ArgumentException("Values cannot be negative.", nameof(LengthMax));
		if (XMVector2Less(LengthMax, LengthMin)) throw new ArgumentException("Max must be larger than Min.");

		XMVECTOR LengthSq = XMVector2LengthSq(V);
		XMVECTOR RcpLength = XMVectorReciprocalSqrt(LengthSq);
		XMVECTOR InfiniteLength = XMVectorEqualInt(LengthSq, XMVECTOR.g_XMInfinity);
		XMVECTOR ZeroLength = XMVectorEqual(LengthSq, Zero);
		XMVECTOR Length = XMVectorMultiply(LengthSq, RcpLength);
		XMVECTOR Normal = XMVectorMultiply(V, RcpLength);
		XMVECTOR Select = XMVectorEqualInt(InfiniteLength, ZeroLength);

		Length = XMVectorSelect(LengthSq, Length, Select);
		Normal = XMVectorSelect(LengthSq, Normal, Select);

		XMVECTOR ControlMax = XMVectorGreater(Length, LengthMax);
		XMVECTOR ControlMin = XMVectorLess(Length, LengthMin);
		XMVECTOR ClampLength = XMVectorSelect(Length, LengthMax, ControlMax);
		ClampLength = XMVectorSelect(ClampLength, LengthMin, ControlMin);

		XMVECTOR Result = XMVectorMultiply(Normal, ClampLength);

		// Preserve the original vector (with no precision loss) if the length falls within the given range
		XMVECTOR Control = XMVectorEqualInt(ControlMax, ControlMin);
		return XMVectorSelect(Result, V, Control);
	}

	/// <summary>Computes the 2D cross product.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns a vector. The 2D cross product is replicated into each component.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = V1.x * V2.y - v1.y * V2.x; Result.y = V1.x * V2.y - v1.y * V2.x; Result.z = V1.x * V2.y - v1.y *
	/// V2.x; Result.w = V1.x * V2.y - v1.y * V2.x; return Result;</c>
	/// </para>
	/// <para>
	/// Note that a 'cross-product' in 2D is not well-defined. This function computes a geometric cross-product often used in 2D graphics.
	/// <c>XMVector2Orthogonal</c> is another possible interpretation of a 'cross-product' in 2D.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2cross XMVECTOR XMVector2Cross( [in] FXMVECTOR
	// V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Cross")]
	public static XMVECTOR XMVector2Cross(this FXMVECTOR V1, in FXMVECTOR V2) => new(V1.x * V2.y - V1.y * V2.x);

	/// <summary>Computes the dot product between 2D vectors.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns a vector. The dot product between <i>V1</i> and <i>V2</i> is replicated into each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2dot XMVECTOR XMVector2Dot( [in] FXMVECTOR V1,
	// [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Dot")]
	public static XMVECTOR XMVector2Dot(this FXMVECTOR V1, in FXMVECTOR V2) => new(V1.x * V2.x + V1.y * V2.y);

	/// <summary>Tests whether two 2D vectors are equal.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns true if the 2D vectors are equal and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x == V2.x &amp;&amp; V1.y == V2.y );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2equal bool XMVector2Equal( [in] FXMVECTOR V1,
	// [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Equal")]
	public static bool XMVector2Equal(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All2True(V2, (a, b) => a == b);

	/// <summary>Tests whether two 2D vectors are equal, treating each component as an unsigned integer.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns true if the 2D vectors are equal and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2equalint bool XMVector2EqualInt( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2EqualInt")]
	public static bool XMVector2EqualInt(this FXMVECTOR V1, in FXMVECTOR V2)
	{ unsafe { return V1.u[0] == V2.u[0] && V1.u[1] == V2.u[1]; } }

	/// <summary>
	/// Tests whether two 2D vectors are equal, treating each component as an unsigned integer. In addition, this function returns a
	/// comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x == V2.x V1.y == V2.y</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2equalintr uint32_t XM_CALLCONV
	// XMVector2EqualIntR( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2EqualIntR")]
	public static uint XMVector2EqualIntR(this FXMVECTOR V1, in FXMVECTOR V2)
	{
		unsafe
		{
			if (V1.u[0] == V2.u[0] && V1.u[1] == V2.u[1])
				return XM_CRMASK_CR6TRUE;
			if (V1.u[0] != V2.u[0] && V1.u[1] != V2.u[1])
				return XM_CRMASK_CR6FALSE;
			return 0;
		}
	}

	/// <summary>
	/// Tests whether two 2D vectors are equal. In addition, this function returns a comparison value that can be examined using functions
	/// such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x == V2.x V1.y == V2.y</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2equalr uint32_t XMVector2EqualR( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2EqualR")]
	public static uint XMVector2EqualR(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All2True(V2, (a, b) => a == b) ? XM_CRMASK_CR6TRUE : V1.All2True(V2, (a, b) => a != b) ? XM_CRMASK_CR6FALSE : 0;

	/// <summary>Tests whether one 2D vector is greater than another 2D vector.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns true if <i>V1</i> is greater than <i>V2</i>, and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &gt; V2.x &amp;&amp; V1.y &gt; V2.y );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2greater bool XMVector2Greater( [in] FXMVECTOR
	// V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Greater")]
	public static bool XMVector2Greater(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All2True(V2, (a, b) => a > b);

	/// <summary>Tests whether one 2D vector is greater-than-or-equal-to another 2D vector.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns true if <i>V1</i> is greater-than-or-equal-to <i>V2</i>, and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &gt;= V2.x &amp;&amp; V1.y &gt;= V2.y );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2greaterorequal bool XM_CALLCONV
	// XMVector2GreaterOrEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2GreaterOrEqual")]
	public static bool XMVector2GreaterOrEqual(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All2True(V2, (a, b) => a >= b);

	/// <summary>
	/// Tests whether one 2D vector is greater-than-or-equal-to another 2D vector and returns a comparison value that can be examined using
	/// functions such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x &gt;= V2.x V1.y &gt;= V2.y</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2greaterorequalr uint32_t XM_CALLCONV
	// XMVector2GreaterOrEqualR( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2GreaterOrEqualR")]
	public static uint XMVector2GreaterOrEqualR(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All2True(V2, (a, b) => a > b) ? XM_CRMASK_CR6TRUE : V1.All2True(V2, (a, b) => a <= b) ? XM_CRMASK_CR6FALSE : 0;

	/// <summary>
	/// Tests whether one 2D vector is greater than another 2D vector and returns a comparison value that can be examined using functions
	/// such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x &gt; V2.x V1.y &gt; V2.y</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2greaterr uint32_t XM_CALLCONV
	// XMVector2GreaterR( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2GreaterR")]
	public static uint XMVector2GreaterR(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All2True(V2, (a, b) => a >= b) ? XM_CRMASK_CR6TRUE : V1.All2True(V2, (a, b) => a < b) ? XM_CRMASK_CR6FALSE : 0;

	/// <summary>Tests whether the components of a 2D vector are within set bounds.</summary>
	/// <param name="V">2D vector to test.</param>
	/// <param name="Bounds">2D vector that determines the bounds.</param>
	/// <returns>Returns true if both the x and y-components of <i>V</i> are within the set bounds, and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return (V.x &lt;= Bounds.x &amp;&amp; V.x &gt;= -Bounds.x) &amp;&amp; (V.y &lt;= Bounds.y &amp;&amp; V.y &gt;= -Bounds.y);</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2inbounds bool XMVector2InBounds( [in]
	// FXMVECTOR V, [in] FXMVECTOR Bounds );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2InBounds")]
	public static bool XMVector2InBounds(this FXMVECTOR V, in FXMVECTOR Bounds) =>
		V.All2True(Bounds, (a, b) => a <= b && a >= -b);

	/// <summary>Finds the intersection of two lines.</summary>
	/// <param name="Line1Point1">2D vector describing the first point on the first line.</param>
	/// <param name="Line1Point2">2D vector describing a second point on the first line.</param>
	/// <param name="Line2Point1">2D vector describing the first point on the second line.</param>
	/// <param name="Line2Point2">2D vector describing a second point on the second line.</param>
	/// <returns>
	/// Returns the intersection point. If the lines are parallel, the returned vector will be a NaN. If the two lines are coincident, the
	/// returned vector will be positive infinity.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2intersectline XMVECTOR XM_CALLCONV
	// XMVector2IntersectLine( [in] FXMVECTOR Line1Point1, [in] FXMVECTOR Line1Point2, [in] FXMVECTOR Line2Point1, [in] GXMVECTOR
	// Line2Point2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2IntersectLine")]
	public static XMVECTOR XMVector2IntersectLine(this FXMVECTOR Line1Point1, in FXMVECTOR Line1Point2, in FXMVECTOR Line2Point1, in GXMVECTOR Line2Point2)
	{
		XMVECTOR V1 = XMVectorSubtract(Line1Point2, Line1Point1);
		XMVECTOR V2 = XMVectorSubtract(Line2Point2, Line2Point1);
		XMVECTOR V3 = XMVectorSubtract(Line1Point1, Line2Point1);

		XMVECTOR C1 = XMVector2Cross(V1, V2);
		XMVECTOR C2 = XMVector2Cross(V2, V3);

		XMVECTOR Zero = XMVectorZero();
		if (XMVector2NearEqual(C1, Zero, XMVECTOR.g_XMEpsilon))
		{
			if (XMVector2NearEqual(C2, Zero, XMVECTOR.g_XMEpsilon))
			{
				// Coincident
				return XMVECTOR.g_XMInfinity;
			}
			else
			{
				// Parallel
				return XMVECTOR.g_XMQNaN;
			}
		}
		else
		{
			// Intersection point = Line1Point1 + V1 * (C2 / C1)
			XMVECTOR Scale = XMVectorReciprocal(C1);
			Scale = XMVectorMultiply(C2, Scale);
			return XMVectorMultiplyAdd(V1, Scale, Line1Point1);
		}
	}

	/// <summary>Tests whether any component of a 2D vector is positive or negative infinity.</summary>
	/// <param name="V">2D vector.</param>
	/// <returns>Returns true if any component of <i>V</i> is positive or negative infinity, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2isinfinite bool XM_CALLCONV
	// XMVector2IsInfinite( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2IsInfinite")]
	public static bool XMVector2IsInfinite(this FXMVECTOR V) => V.Any2True(XMISINF);

	/// <summary>Tests whether any component of a 2D vector is a NaN.</summary>
	/// <param name="V">2D vector.</param>
	/// <returns>Returns true if any component of <i>V</i> is a NaN, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2isnan bool XMVector2IsNaN( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2IsNaN")]
	public static bool XMVector2IsNaN(this FXMVECTOR V) => V.Any2True(XMISNAN);

	/// <summary>Computes the length of a 2D vector.</summary>
	/// <param name="V">2D vector.</param>
	/// <returns>Returns a vector. The length of <i>V</i> is replicated into each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2length XMVECTOR XMVector2Length( [in]
	// FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Length")]
	public static XMVECTOR XMVector2Length(this FXMVECTOR V) => XMVectorSqrt(XMVector2LengthSq(V));

	/// <summary>Estimates the length of a 2D vector.</summary>
	/// <param name="V">2D vector.</param>
	/// <returns>Returns a vector, each of whose components are estimates of the length of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2lengthest XMVECTOR XM_CALLCONV
	// XMVector2LengthEst( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2LengthEst")]
	public static XMVECTOR XMVector2LengthEst(this FXMVECTOR V) => XMVector2Length(V);

	/// <summary>Computes the square of the length of a 2D vector.</summary>
	/// <param name="V">2D vector.</param>
	/// <returns>Returns a vector. The square of the length of <i>V</i> is replicated into each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2lengthsq XMVECTOR XM_CALLCONV
	// XMVector2LengthSq( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2LengthSq")]
	public static XMVECTOR XMVector2LengthSq(this FXMVECTOR V) => XMVector2Dot(V, V);

	/// <summary>Tests whether one 2D vector is less than another 2D vector.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns true if <i>V1</i> is less than <i>V2</i> and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &lt; V2.x &amp;&amp; V1.y &lt; V2.y );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2less bool XMVector2Less( [in] FXMVECTOR V1,
	// [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Less")]
	public static bool XMVector2Less(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All2True(V2, (a, b) => a < b);

	/// <summary>Tests whether one 2D vector is less-than-or-equal-to another 2D vector.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns true if <i>V1</i> is less-than-or-equal to <i>V2</i>, and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &lt;= V2.x &amp;&amp; V1.y &lt;= V2.y );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2lessorequal bool XM_CALLCONV
	// XMVector2LessOrEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2LessOrEqual")]
	public static bool XMVector2LessOrEqual(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All2True(V2, (a, b) => a <= b);

	/// <summary>Computes the minimum distance between a line and a point.</summary>
	/// <param name="LinePoint1">2D vector describing a point on the line.</param>
	/// <param name="LinePoint2">2D vector describing a point on the line.</param>
	/// <param name="Point">2D vector describing the reference point.</param>
	/// <returns>Returns a vector. The minimum distance between the line and the point is replicated to each of the components.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2linepointdistance XMVECTOR XM_CALLCONV
	// XMVector2LinePointDistance( [in] FXMVECTOR LinePoint1, [in] FXMVECTOR LinePoint2, [in] FXMVECTOR Point );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2LinePointDistance")]
	public static XMVECTOR XMVector2LinePointDistance(this FXMVECTOR LinePoint1, in FXMVECTOR LinePoint2, in FXMVECTOR Point)
	{
		// Given a vector PointVector from LinePoint1 to Point and a vector LineVector from LinePoint1 to LinePoint2, the scaled distance
		// PointProjectionScale from LinePoint1 to the perpendicular projection of PointVector onto the line is defined as:
		//
		// PointProjectionScale = dot(PointVector, LineVector) / LengthSq(LineVector)

		XMVECTOR PointVector = XMVectorSubtract(Point, LinePoint1);
		XMVECTOR LineVector = XMVectorSubtract(LinePoint2, LinePoint1);

		XMVECTOR LengthSq = XMVector2LengthSq(LineVector);

		XMVECTOR PointProjectionScale = XMVector2Dot(PointVector, LineVector);
		PointProjectionScale = XMVectorDivide(PointProjectionScale, LengthSq);

		XMVECTOR DistanceVector = XMVectorMultiply(LineVector, PointProjectionScale);
		DistanceVector = XMVectorSubtract(PointVector, DistanceVector);

		return XMVector2Length(DistanceVector);
	}

	/// <summary>Tests whether one 2D vector is near another 2D vector.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <param name="Epsilon">Tolerance value used for judging equality.</param>
	/// <returns>Returns true if the difference between components is less than <i>Epsilon</i>; returns false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( ( abs( V1.x - V2.x ) &lt;= Epsilon ) &amp;&amp; ( abs( V1.y - V2.y ) &lt;= Epsilon ) );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2nearequal bool XM_CALLCONV
	// XMVector2NearEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2, [in] FXMVECTOR Epsilon );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2NearEqual")]
	public static bool XMVector2NearEqual(this FXMVECTOR V1, in FXMVECTOR V2, in FXMVECTOR Epsilon)
	{
		float dx = Math.Abs(V1.x - V2.x);
		float dy = Math.Abs(V1.y - V2.y);
		return dx <= Epsilon.x &&
			dy <= Epsilon.y;
	}

	/// <summary>Returns the normalized version of a 2D vector.</summary>
	/// <param name="V">2D vector.</param>
	/// <returns>Returns the normalized version of <i>V</i>.</returns>
	/// <remarks>
	/// <para>For a vector of length 0, this function returns a zero vector. For a vector with infinite length, it returns a vector of QNaN.</para>
	/// <para>
	/// Note that for most graphics applications, ensuring the vectors have well-defined lengths that don't cause problems for normalization
	/// is common practice. However, if you need a robust normalization that works for all floating-point inputs, you can use the following
	/// code instead:
	/// </para>
	/// <para>
	/// <c>inline XMVECTOR XMVector2NormalizeRobust( FXMVECTOR V ) { // Compute the maximum absolute value component. XMVECTOR vAbs =
	/// XMVectorAbs(V); XMVECTOR max0 = XMVectorSplatX(vAbs); XMVECTOR max1 = XMVectorSplatY(vAbs); max0 = XMVectorMax(max0, max1); //
	/// Divide by the maximum absolute component. XMVECTOR normalized = XMVectorDivide(V, max0); // Set to zero when the original length is
	/// zero. XMVECTOR mask = XMVectorNotEqual(XMVECTOR.g_XMZero, max0); normalized = XMVectorAndInt(normalized, mask); XMVECTOR t0 =
	/// XMVector2LengthSq(normalized); XMVECTOR length = XMVectorSqrt(t0); // Divide by the length to normalize. normalized =
	/// XMVectorDivide(normalized, length); // Set to zero when the original length is zero or infinity. In the // latter case, this is
	/// considered to be an unexpected condition. normalized = XMVectorAndInt(normalized, mask); return normalized; }</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2normalize XMVECTOR XM_CALLCONV
	// XMVector2Normalize( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Normalize")]
	public static XMVECTOR XMVector2Normalize(this FXMVECTOR V)
	{
		XMVECTOR vResult = XMVector2Length(V);
		float fLength = vResult.x;

		// Prevent divide by zero
		if (fLength > 0)
			fLength = 1.0f / fLength;

		return V.UnaryOp(f => f * fLength);
	}

	/// <summary>Estimates the normalized version of a 2D vector.</summary>
	/// <param name="V">2D vector.</param>
	/// <returns>Returns an estimate of the normalized version of <i>V</i>.</returns>
	/// <remarks>
	/// <para>For a vector with 0 length or infinite length, this function returns a vector of QNaN.</para>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2normalizeest XMVECTOR XM_CALLCONV
	// XMVector2NormalizeEst( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2NormalizeEst")]
	public static XMVECTOR XMVector2NormalizeEst(this FXMVECTOR V) => XMVector2Normalize(V);

	/// <summary>Tests whether two 2D vectors are not equal.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns true if the 2D vectors are not equal and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x != V2.x || V1.y != V2.y );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2notequal bool XMVector2NotEqual( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2NotEqual")]
	public static bool XMVector2NotEqual(this FXMVECTOR V1, in FXMVECTOR V2) => !V1.All2True(V2, (a, b) => a == b);

	/// <summary>Test whether two vectors are not equal, treating each component as an unsigned integer.</summary>
	/// <param name="V1">2D vector.</param>
	/// <param name="V2">2D vector.</param>
	/// <returns>Returns true if the 2D vectors are not equal and false otherwise.</returns>
	/// <remarks></remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2notequalint bool XM_CALLCONV
	// XMVector2NotEqualInt( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2NotEqualInt")]
	public static bool XMVector2NotEqualInt(this FXMVECTOR V1, in FXMVECTOR V2)
	{ unsafe { return V1.u[0] != V2.u[0] || V1.u[1] != V2.u[1]; } }

	/// <summary>Computes a vector perpendicular to a 2D vector.</summary>
	/// <param name="V">2D vector.</param>
	/// <returns>Returns the 2D vector orthogonal to <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// Note that a 'cross-product' in 2D is not well-defined. This function computes a generalized cross-product in 2D.
	/// <c>XMVector2Cross</c> is another possible interpretation of a 'cross-product' in 2D.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>XMVECTOR Result; Result.x = -V.y; Result.y = V.x; Result.z = 0; Result.w = 0; return Result;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2orthogonal XMVECTOR XM_CALLCONV
	// XMVector2Orthogonal( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Orthogonal")]
	public static XMVECTOR XMVector2Orthogonal(this FXMVECTOR V) => new(-V.y, V.x);

	/// <summary>Computes the reciprocal of the length of a 2D vector.</summary>
	/// <param name="V">2D vector.</param>
	/// <returns>Returns the reciprocal of the length of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2reciprocallength XMVECTOR XM_CALLCONV
	// XMVector2ReciprocalLength( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2ReciprocalLength")]
	public static XMVECTOR XMVector2ReciprocalLength(this FXMVECTOR V) => XMVectorReciprocalSqrtEst(XMVector2LengthSq(V));

	/// <summary>Estimates the reciprocal of the length of a 2D vector.</summary>
	/// <param name="V">2D vector.</param>
	/// <returns>Returns a vector, each of whose components are estimates of the reciprocal of the length of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2reciprocallengthest XMVECTOR XM_CALLCONV
	// XMVector2ReciprocalLengthEst( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2ReciprocalLengthEst")]
	public static XMVECTOR XMVector2ReciprocalLengthEst(this FXMVECTOR V) => XMVector2ReciprocalLength(V);

	/// <summary>Reflects an incident 2D vector across a 2D normal vector.</summary>
	/// <param name="Incident">2D incident vector to reflect.</param>
	/// <param name="Normal">2D normal vector to reflect the incident vector across.</param>
	/// <returns>Returns the reflected incident angle.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; float s = 2.0f * (Incident.x * Normal.x + Incident.y * Normal.y); // 2.0 * dot(Incident, Normal); Result.x =
	/// Incident.x - s * Normal.x; Result.y = Incident.y - s * Normal.y; Result.z = undefined; Result.w = undefined; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2reflect XMVECTOR XM_CALLCONV
	// XMVector2Reflect( [in] FXMVECTOR Incident, [in] FXMVECTOR Normal );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Reflect")]
	public static XMVECTOR XMVector2Reflect(this FXMVECTOR Incident, in FXMVECTOR Normal) => Incident - 2f * Incident.XMVector2Dot(Normal) * Normal;

	/// <summary>Refracts an incident 2D vector across a 2D normal vector.</summary>
	/// <param name="Incident">2D incident vector to refract.</param>
	/// <param name="Normal">2D normal vector to refract the incident vector through.</param>
	/// <param name="RefractionIndex">Index of refraction. See remarks.</param>
	/// <returns>
	/// Returns the refracted incident vector. If the refraction index and the angle between the incident vector and the normal are such
	/// that the result is a total internal reflection, the function will return a vector of the form &lt; 0.0f, 0.0f, undefined, undefined &gt;.
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; float t = (Incident.x * Normal.x + Incident.y * Normal.y); // dot(Incident, Normal); float r = 1.0f -
	/// RefractionIndex * RefractionIndex * (1.0f - t * t); if (r &lt; 0.0f) // Total internal reflection { Result.x = 0.0f; Result.y =
	/// 0.0f; } else { float s = RefractionIndex * t + sqrt(r); Result.x = RefractionIndex * Incident.x - s * Normal.x; Result.y =
	/// RefractionIndex * Incident.y - s * Normal.y; } Result.z = undefined; Result.w = undefined; return Result;</c>
	/// </para>
	/// <para>
	/// The index of refraction is the ratio of the index of refraction of the medium containing the incident vector to the index of
	/// refraction of the medium being entered (where the index of refraction of a medium is itself the ratio of the speed of light in a
	/// vacuum to the speed of light in the medium).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2refract XMVECTOR XM_CALLCONV
	// XMVector2Refract( [in] FXMVECTOR Incident, [in] FXMVECTOR Normal, [in] float RefractionIndex );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Refract")]
	public static XMVECTOR XMVector2Refract(this FXMVECTOR Incident, in FXMVECTOR Normal, float RefractionIndex) =>
	XMVector2RefractV(Incident, Normal, XMVectorReplicate(RefractionIndex));

	/// <summary>Refracts an incident 2D vector across a 2D normal vector.</summary>
	/// <param name="Incident">2D incident vector to refract.</param>
	/// <param name="Normal">2D normal vector to refract the incident vector through.</param>
	/// <param name="RefractionIndex">2D vector whose x and y-components are both equal to the index of refraction.</param>
	/// <returns>
	/// Returns the refracted incident vector. If the refraction index and the angle between the incident vector and the normal are such
	/// that the result is a total internal reflection, the function will return a vector of the form &lt; 0.0f, 0.0f, undefined, undefined &gt;.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is identical to <c>XMVector2Refract</c> except that the <i>RefractionIndex</i> is supplied using a 2D vector instead
	/// of a <b>float</b> value.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2refractv XMVECTOR XM_CALLCONV
	// XMVector2RefractV( [in] FXMVECTOR Incident, [in] FXMVECTOR Normal, [in] FXMVECTOR RefractionIndex );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2RefractV")]
	public static XMVECTOR XMVector2RefractV(this FXMVECTOR Incident, in FXMVECTOR Normal, in FXMVECTOR RefractionIndex)
	{
		float IDotN = Incident.x * Normal.x + Incident.y * Normal.y;
		// R = 1.0f - RefractionIndex * RefractionIndex * (1.0f - IDotN * IDotN)
		float RY = 1.0f - IDotN * IDotN;
		float RX = 1.0f - RY * RefractionIndex.x * RefractionIndex.x;
		RY = 1.0f - RY * RefractionIndex.y * RefractionIndex.y;
		RX = RX >= 0.0f ? RefractionIndex.x * Incident.x - Normal.x * (RefractionIndex.x * IDotN + (float)Math.Sqrt(RX)) : 0.0f;
		RY = RY >= 0.0f ? RefractionIndex.y * Incident.y - Normal.y * (RefractionIndex.y * IDotN + (float)Math.Sqrt(RY)) : 0.0f;

		return new(RX, RY);
	}

	/// <summary>Transforms a 2D vector by a matrix.</summary>
	/// <param name="V">2D vector.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the transformed vector.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMVector2Transform</c> performs transformations by using the input matrix rows 0 and 1 for rotation and scaling, and row 3 for
	/// translation (effectively assuming row 2 is 0). The w component of the input vector is assumed to be 0. The z component of the output
	/// vector should be ignored and its w component may be non-homogeneous (!= 1.0).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2transform XMVECTOR XM_CALLCONV
	// XMVector2Transform( [in] FXMVECTOR V, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2Transform")]
	public static XMVECTOR XMVector2Transform(this FXMVECTOR V, in FXMMATRIX M) =>
		XMVectorMultiplyAdd(XMVectorSplatX(V), M.r[0], XMVectorMultiplyAdd(XMVectorSplatY(V), M.r[1], M.r[3]));

	/// <summary>Transforms a 2D vector by a given matrix, projecting the result back into w = 1.</summary>
	/// <param name="V">2D vector.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the transformed vector.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMVector2TransformCoord</c> performs transformations by using the input matrix row 0 and row 1 for rotation and scaling, and row
	/// 3 for translation (effectively assuming row 2 is 0). The w component of the input vector is assumed to be 1.0. The z component of
	/// the returned vector should be ignored and its w component will have a value of 1.0.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2transformcoord XMVECTOR XM_CALLCONV
	// XMVector2TransformCoord( [in] FXMVECTOR V, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2TransformCoord")]
	public static XMVECTOR XMVector2TransformCoord(this FXMVECTOR V, in FXMMATRIX M)
	{
		XMVECTOR Y = XMVectorSplatY(V);
		XMVECTOR X = XMVectorSplatX(V);

		XMVECTOR Result = XMVectorMultiplyAdd(Y, M.r[1], M.r[3]);
		Result = XMVectorMultiplyAdd(X, M.r[0], Result);

		XMVECTOR W = XMVectorSplatW(Result);
		return XMVectorDivide(Result, W);
	}

	/// <summary>
	/// Transforms a stream of 2D vectors by a given matrix, projecting the resulting vectors such that their w coordinates are equal to 1.0.
	/// </summary>
	/// <param name="pOutputStream">Address of the first <c>XMFLOAT2</c> in the destination stream.</param>
	/// <param name="OutputStride">Stride, in bytes, between vectors in the destination stream.</param>
	/// <param name="pInputStream">Address of the first <c>XMFLOAT2</c> in the stream to be transformed.</param>
	/// <param name="InputStride">Stride, in bytes, between vectors in the input stream.</param>
	/// <param name="VectorCount">Number of vectors to transform.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the address of the first <c>XMFLOAT2</c> in the destination stream.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMVector2TransformCoordStream</c> performs transformations by using the input matrix row 0 and row 1 for rotation and scaling,
	/// and row 3 for translation (effectively assuming row 2 is 0). The w component of the input vector is assumed to be 1.0. The z
	/// component of the returned vector should be ignored and its w component will have a value of 1.0.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2transformcoordstream XMFLOAT2 *XM_CALLCONV
	// XMVector2TransformCoordStream( [out] XMFLOAT2 *pOutputStream, [in] SizeT OutputStride, [in] const XMFLOAT2 *pInputStream, [in] SizeT
	// InputStride, [in] SizeT VectorCount, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2TransformCoordStream")]
	public static unsafe XMFLOAT2* XMVector2TransformCoordStream([Out] XMFLOAT2* pOutputStream, [In] SizeT OutputStride, [In] XMFLOAT2* pInputStream, [In] SizeT InputStride, [In] SizeT VectorCount, [In] FXMMATRIX M)
	{
		if (pOutputStream is null) throw new ArgumentNullException(nameof(pOutputStream));
		if (pInputStream is null) throw new ArgumentNullException(nameof(pInputStream));

		if (InputStride < sizeof(XMFLOAT2)) throw new ArgumentException("Must be at least 8 bytes.", nameof(InputStride));
		if (OutputStride < sizeof(XMFLOAT2)) throw new ArgumentException("Must be at least 8 bytes.", nameof(OutputStride));

		var pInputVector = (byte*)pInputStream;
		var pOutputVector = (byte*)pOutputStream;

		XMVECTOR row0 = M.r[0];
		XMVECTOR row1 = M.r[1];
		XMVECTOR row3 = M.r[3];

		for (SizeT i = 0; i < VectorCount; i++)
		{
			XMVECTOR V = XMLoadFloat2(*(XMFLOAT2*)pInputVector);
			XMVECTOR Y = XMVectorSplatY(V);
			XMVECTOR X = XMVectorSplatX(V);

			XMVECTOR Result = XMVectorMultiplyAdd(Y, row1, row3);
			Result = XMVectorMultiplyAdd(X, row0, Result);

			XMVECTOR W = XMVectorSplatW(Result);

			Result = XMVectorDivide(Result, W);

			XMStoreFloat2((XMFLOAT2*)pOutputVector, Result);

			pInputVector += InputStride;
			pOutputVector += OutputStride;
		}

		return pOutputStream;
	}

	/// <summary>Transforms the 2D vector normal by the given matrix.</summary>
	/// <param name="V">2D normal vector.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the transformed vector.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMVector2TransformNormal</c> uses row 0 and 1 of the input transformation matrix for rotation and scaling. Rows 2 and 3 are ignored.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2transformnormal XMVECTOR XM_CALLCONV
	// XMVector2TransformNormal( [in] FXMVECTOR V, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2TransformNormal")]
	public static XMVECTOR XMVector2TransformNormal(this FXMVECTOR V, in FXMMATRIX M)
	{
		XMVECTOR Y = XMVectorSplatY(V);
		XMVECTOR X = XMVectorSplatX(V);

		XMVECTOR Result = XMVectorMultiply(Y, M.r[1]);
		return XMVectorMultiplyAdd(X, M.r[0], Result);
	}

	/// <summary>Transforms a stream of 2D normal vectors by a given matrix.</summary>
	/// <param name="pOutputStream">Address of the first <c>XMFLOAT2</c> in the destination stream.</param>
	/// <param name="OutputStride">Stride, in bytes, between vectors in the destination stream.</param>
	/// <param name="pInputStream">Address of the first <c>XMFLOAT2</c> in the stream to be transformed.</param>
	/// <param name="InputStride">Stride, in bytes, between vectors in the input stream.</param>
	/// <param name="VectorCount">Number of vectors to transform.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the address of the first <c>XMFLOAT2</c> in the destination stream.</returns>
	/// <remarks>
	/// <para>Each vector in the input stream must be normalized.</para>
	/// <para>
	/// <c>XMVector2TransformNormalStream</c> uses row 0 and 1 of the input transformation matrix for rotation and scaling. Rows 2 and 3 are ignored.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2transformnormalstream XMFLOAT2 *XM_CALLCONV
	// XMVector2TransformNormalStream( [out] XMFLOAT2 *pOutputStream, [in] SizeT OutputStride, [in] const XMFLOAT2 *pInputStream, [in] SizeT
	// InputStride, [in] SizeT VectorCount, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2TransformNormalStream")]
	public static unsafe XMFLOAT2* XMVector2TransformNormalStream([Out] XMFLOAT2* pOutputStream, [In] SizeT OutputStride, [In] XMFLOAT2* pInputStream, [In] SizeT InputStride, [In] SizeT VectorCount, [In] FXMMATRIX M)
	{
		if (pOutputStream is null) throw new ArgumentNullException(nameof(pOutputStream));
		if (pInputStream is null) throw new ArgumentNullException(nameof(pInputStream));

		if (InputStride < sizeof(XMFLOAT2)) throw new ArgumentException("Must be at least 8 bytes.", nameof(InputStride));
		if (OutputStride < sizeof(XMFLOAT2)) throw new ArgumentException("Must be at least 8 bytes.", nameof(OutputStride));

		var pInputVector = (byte*)pInputStream;
		var pOutputVector = (byte*)pOutputStream;

		XMVECTOR row0 = M.r[0];
		XMVECTOR row1 = M.r[1];

		for (SizeT i = 0; i < VectorCount; i++)
		{
			XMVECTOR V = XMLoadFloat2(*(XMFLOAT2*)pInputVector);
			XMVECTOR Y = XMVectorSplatY(V);
			XMVECTOR X = XMVectorSplatX(V);

			XMVECTOR Result = XMVectorMultiply(Y, row1);
			Result = XMVectorMultiplyAdd(X, row0, Result);

			XMStoreFloat2((XMFLOAT2*)pOutputVector, Result);

			pInputVector += InputStride;
			pOutputVector += OutputStride;
		}

		return pOutputStream;
	}

	/// <summary>Transforms a stream of 2D vectors by a given matrix.</summary>
	/// <param name="pOutputStream">Address of the first <c>XMFLOAT4</c> in the destination stream.</param>
	/// <param name="OutputStride">Stride, in bytes, between vectors in the destination stream.</param>
	/// <param name="pInputStream">Address of the first <c>XMFLOAT2</c> in the stream to be transformed.</param>
	/// <param name="InputStride">Stride, in bytes, between vectors in the input stream.</param>
	/// <param name="VectorCount">Number of vectors to transform.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the address of the first <c>XMFLOAT4</c> in the destination stream.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMVector2TransformStream</c> performs transformations by using the input matrix rows 0 and 1 for rotation and scaling, and row 3
	/// for translation (effectively assuming row 2 is 0). The w component of the input vector is assumed to be 0. The z component of the
	/// output vector should be ignored and its w component may be non-homogeneous (!= 1.0).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector2transformstream XMFLOAT4 *XM_CALLCONV
	// XMVector2TransformStream( [out] XMFLOAT4 *pOutputStream, [in] SizeT OutputStride, [in] const XMFLOAT2 *pInputStream, [in] SizeT
	// InputStride, [in] SizeT VectorCount, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector2TransformStream")]
	public static unsafe XMFLOAT4* XMVector2TransformStream([Out] XMFLOAT4* pOutputStream, [In] SizeT OutputStride, [In] XMFLOAT2* pInputStream, [In] SizeT InputStride, [In] SizeT VectorCount, [In] FXMMATRIX M)
	{
		var pInputVector = (byte*)pInputStream;
		var pOutputVector = (byte*)pOutputStream;

		XMVECTOR row0 = M.r[0];
		XMVECTOR row1 = M.r[1];
		XMVECTOR row3 = M.r[3];

		for (SizeT i = 0; i < VectorCount; i++)
		{
			XMVECTOR V = XMLoadFloat2(*(XMFLOAT2*)pInputVector);
			XMVECTOR Y = XMVectorSplatY(V);
			XMVECTOR X = XMVectorSplatX(V);

			XMVECTOR Result = XMVectorMultiplyAdd(Y, row1, row3);
			Result = XMVectorMultiplyAdd(X, row0, Result);

			XMStoreFloat4((XMFLOAT4*)pOutputVector, Result);

			pInputVector += InputStride;
			pOutputVector += OutputStride;
		}

		return pOutputStream;
	}

	/// <summary>Computes the radian angle between two normalized 3D vectors.</summary>
	/// <param name="N1">Normalized 3D vector.</param>
	/// <param name="N2">Normalized 3D vector.</param>
	/// <returns>Returns a vector. The radian angle between <i>N1</i> and <i>N2</i> is replicated to each of the components.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3anglebetweennormals XMVECTOR XM_CALLCONV
	// XMVector3AngleBetweenNormals( [in] FXMVECTOR N1, [in] FXMVECTOR N2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3AngleBetweenNormals")]
	public static XMVECTOR XMVector3AngleBetweenNormals(this FXMVECTOR N1, in FXMVECTOR N2)
	{
		XMVECTOR Result = XMVector3Dot(N1, N2);
		Result = XMVectorClamp(Result, XMVECTOR.g_XMNegativeOne, XMVECTOR.g_XMOne);
		return XMVectorACos(Result);
	}

	/// <summary>Estimates the radian angle between two normalized 3D vectors.</summary>
	/// <param name="N1">Normalized 3D vector.</param>
	/// <param name="N2">Normalized 3D vector.</param>
	/// <returns>Returns a vector. The estimate of the radian angle (between <i>N1</i> and <i>N2</i>) is replicated to each of the components.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3anglebetweennormalsest XMVECTOR XM_CALLCONV
	// XMVector3AngleBetweenNormalsEst( [in] FXMVECTOR N1, [in] FXMVECTOR N2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3AngleBetweenNormalsEst")]
	public static XMVECTOR XMVector3AngleBetweenNormalsEst(this FXMVECTOR N1, in FXMVECTOR N2)
	{
		XMVECTOR Result = XMVector3Dot(N1, N2);
		Result = XMVectorClamp(Result, XMVECTOR.g_XMNegativeOne, XMVECTOR.g_XMOne);
		return XMVectorACosEst(Result);
	}

	/// <summary>Computes the radian angle between two 3D vectors.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns a vector. The radian angle between <i>V1</i> and <i>V2</i> is replicated to each of the components.</returns>
	/// <remarks>
	/// <para>If V1 and V2 are normalized 3D vectors, it is faster to use <c>XMVector3AngleBetweenNormals</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3anglebetweenvectors XMVECTOR XM_CALLCONV
	// XMVector3AngleBetweenVectors( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3AngleBetweenVectors")]
	public static XMVECTOR XMVector3AngleBetweenVectors(this FXMVECTOR V1, in FXMVECTOR V2)
	{
		XMVECTOR L1 = XMVector3ReciprocalLength(V1);
		XMVECTOR L2 = XMVector3ReciprocalLength(V2);

		XMVECTOR Dot = XMVector3Dot(V1, V2);

		L1 = XMVectorMultiply(L1, L2);

		XMVECTOR CosAngle = XMVectorMultiply(Dot, L1);
		CosAngle = XMVectorClamp(CosAngle, XMVECTOR.g_XMNegativeOne, XMVECTOR.g_XMOne);

		return XMVectorACos(CosAngle);
	}

	/// <summary>Clamps the length of a 3D vector to a given range.</summary>
	/// <param name="V">3D vector.</param>
	/// <param name="LengthMin">Minimum clamp length.</param>
	/// <param name="LengthMax">Maximum clamp length.</param>
	/// <returns>Returns a 3D vector whose length is clamped to the specified minimum and maximum.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3clamplength XMVECTOR XM_CALLCONV
	// XMVector3ClampLength( [in] FXMVECTOR V, [in] float LengthMin, [in] float LengthMax );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3ClampLength")]
	public static XMVECTOR XMVector3ClampLength(this FXMVECTOR V, float LengthMin, float LengthMax) =>
		XMVector3ClampLengthV(V, XMVectorReplicate(LengthMin), XMVectorReplicate(LengthMax));

	/// <summary>Clamps the length of a 3D vector to a given range.</summary>
	/// <param name="V">3D vector to clamp.</param>
	/// <param name="LengthMin">
	/// 3D vector whose x, y, and z-components are equal to the minimum clamp length. The x, y, and z-components must be
	/// greater-than-or-equal to zero.
	/// </param>
	/// <param name="LengthMax">
	/// 3D vector whose x, y, and z-components are equal to the minimum clamp length. The x, y, and z-components must be
	/// greater-than-or-equal to zero.
	/// </param>
	/// <returns>Returns a 3D vector whose length is clamped to the specified minimum and maximum.</returns>
	/// <remarks>
	/// <para>
	/// This function is identical to <c>XMVector3ClampLength</c> except that <i>LengthMin</i> and <i>LengthMax</i> are supplied using 3D
	/// vectors instead of <b>float</b> values.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3clamplengthv XMVECTOR XM_CALLCONV
	// XMVector3ClampLengthV( [in] FXMVECTOR V, [in] FXMVECTOR LengthMin, [in] FXMVECTOR LengthMax );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3ClampLengthV")]
	public static XMVECTOR XMVector3ClampLengthV(this FXMVECTOR V, in FXMVECTOR LengthMin, in FXMVECTOR LengthMax)
	{
		if (XMVectorGetY(LengthMin) != XMVectorGetX(LengthMin) || XMVectorGetZ(LengthMin) == XMVectorGetX(LengthMin)) throw new ArgumentException("Values must be equal.", nameof(LengthMin));
		if (XMVectorGetY(LengthMax) != XMVectorGetX(LengthMax) || XMVectorGetZ(LengthMax) == XMVectorGetX(LengthMax)) throw new ArgumentException("Values must be equal.", nameof(LengthMax));
		if (XMVector2Less(LengthMin, XMVECTOR.g_XMZero)) throw new ArgumentException("Values cannot be negative.", nameof(LengthMin));
		if (XMVector2Less(LengthMax, XMVECTOR.g_XMZero)) throw new ArgumentException("Values cannot be negative.", nameof(LengthMax));
		if (XMVector2Less(LengthMax, LengthMin)) throw new ArgumentException("Max must be larger than Min.");

		XMVECTOR LengthSq = XMVector3LengthSq(V);
		XMVECTOR RcpLength = XMVectorReciprocalSqrt(LengthSq);
		XMVECTOR InfiniteLength = XMVectorEqualInt(LengthSq, XMVECTOR.g_XMInfinity);
		XMVECTOR ZeroLength = XMVectorEqual(LengthSq, XMVECTOR.g_XMZero);

		XMVECTOR Normal = XMVectorMultiply(V, RcpLength);

		XMVECTOR Length = XMVectorMultiply(LengthSq, RcpLength);

		XMVECTOR Select = XMVectorEqualInt(InfiniteLength, ZeroLength);
		Length = XMVectorSelect(LengthSq, Length, Select);
		Normal = XMVectorSelect(LengthSq, Normal, Select);

		XMVECTOR ControlMax = XMVectorGreater(Length, LengthMax);
		XMVECTOR ControlMin = XMVectorLess(Length, LengthMin);

		XMVECTOR ClampLength = XMVectorSelect(Length, LengthMax, ControlMax);
		ClampLength = XMVectorSelect(ClampLength, LengthMin, ControlMin);

		XMVECTOR Result = XMVectorMultiply(Normal, ClampLength);

		// Preserve the original vector (with no precision loss) if the length falls within the given range
		XMVECTOR Control = XMVectorEqualInt(ControlMax, ControlMin);
		return XMVectorSelect(Result, V, Control);
	}

	/// <summary>Using a reference normal vector, splits a 3D vector into components that are parallel and perpendicular to the normal.</summary>
	/// <param name="pParallel">Address of the component of <i>V</i> that is parallel to <i>Normal</i>.</param>
	/// <param name="pPerpendicular">Address of the component of <i>V</i> that is perpendicular to <i>Normal</i>.</param>
	/// <param name="V">3D vector to break into components.</param>
	/// <param name="Normal">3D reference normal vector.</param>
	/// <returns>None.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3componentsfromnormal void XM_CALLCONV
	// XMVector3ComponentsFromNormal( [out] XMVECTOR *pParallel, [out] XMVECTOR *pPerpendicular, [in] FXMVECTOR V, [in] FXMVECTOR Normal );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3ComponentsFromNormal")]
	public static void XMVector3ComponentsFromNormal(out XMVECTOR pParallel, out XMVECTOR pPerpendicular, in FXMVECTOR V, in FXMVECTOR Normal)
	{
		pParallel = XMVectorMultiply(Normal, XMVector3Dot(V, Normal));
		pPerpendicular = XMVectorSubtract(V, pParallel);
	}

	/// <summary>Computes the cross product between two 3D vectors.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns the cross product of <i>V1</i> and <i>V2</i>.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V1.y * V2.z) - (V1.z * V2.y); Result.y = (V1.z * V2.x) - (V1.x * V2.z); Result.z = (V1.x * V2.y) -
	/// (V1.y * V2.x); Result.w = 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3cross XMVECTOR XMVector3Cross( [in] FXMVECTOR
	// V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Cross")]
	public static XMVECTOR XMVector3Cross(this FXMVECTOR V1, in FXMVECTOR V2) => new(V1.y * V2.z - V1.z * V2.y, V1.z * V2.x - V1.x * V2.z, V1.x * V2.y - V1.y * V2.x);

	/// <summary>Computes the dot product between 3D vectors.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns a vector. The dot product between <i>V1</i> and <i>V2</i> is replicated into each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3dot XMVECTOR XMVector3Dot( [in] FXMVECTOR V1,
	// [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Dot")]
	public static XMVECTOR XMVector3Dot(this FXMVECTOR V1, in FXMVECTOR V2) => new((float)(V1.x * V2.x + V1.y * V2.y + V1.z * V2.z));

	/// <summary>Tests whether two 3D vectors are equal.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns true if the 3D vectors are equal and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x == V2.x &amp;&amp; V1.y == V2.y &amp;&amp; V1.z == V2.z );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3equal bool XMVector3Equal( [in] FXMVECTOR V1,
	// [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Equal")]
	public static bool XMVector3Equal(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All3True(V2, (a, b) => a == b);

	/// <summary>Tests whether two 3D vectors are equal, treating each component as an unsigned integer.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns true if the 3D vectors are equal and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3equalint bool XMVector3EqualInt( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3EqualInt")]
	public static bool XMVector3EqualInt(this FXMVECTOR V1, in FXMVECTOR V2)
	{ unsafe { return V1.u[0] == V2.u[0] && V1.u[1] == V2.u[1] && V1.u[2] == V2.u[2]; } }

	/// <summary>
	/// Tests whether two 3D vectors are equal, treating each component as an unsigned integer. In addition, this function returns a
	/// comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x == V2.x V1.y == V2.y V1.z == V2.z</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3equalintr uint32_t XM_CALLCONV
	// XMVector3EqualIntR( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3EqualIntR")]
	public static uint XMVector3EqualIntR(this FXMVECTOR V1, in FXMVECTOR V2)
	{
		unsafe
		{
			if (V1.u[0] == V2.u[0] && V1.u[1] == V2.u[1] && V1.u[2] == V2.u[2])
				return XM_CRMASK_CR6TRUE;
			if (V1.u[0] != V2.u[0] && V1.u[1] != V2.u[1] && V1.u[2] != V2.u[2])
				return XM_CRMASK_CR6FALSE;
			return 0;
		}
	}

	/// <summary>
	/// Tests whether two 3D vectors are equal. In addition, this function returns a comparison value that can be examined using functions
	/// such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x == V2.x V1.y == V2.y V1.z == V2.z</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3equalr uint32_t XMVector3EqualR( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3EqualR")]
	public static uint XMVector3EqualR(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All3True(V2, (a, b) => a == b) ? XM_CRMASK_CR6TRUE : V1.All3True(V2, (a, b) => a != b) ? XM_CRMASK_CR6FALSE : 0;

	/// <summary>Tests whether one 3D vector is greater than another 3D vector.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns true if <i>V1</i> is greater than <i>V2</i> and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &gt; V2.x &amp;&amp; V1.y &gt; V2.y &amp;&amp; V1.z &gt; V2.z );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3greater bool XMVector3Greater( [in] FXMVECTOR
	// V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Greater")]
	public static bool XMVector3Greater(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All3True(V2, (a, b) => a > b);

	/// <summary>Tests whether one 3D vector is greater-than-or-equal-to another 3D vector.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns true if <i>V1</i> is greater-than-or-equal-to <i>V2</i> and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &gt;= V2.x &amp;&amp; V1.y &gt;= V2.y &amp;&amp; V1.z &gt;= V2.z );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3greaterorequal bool XM_CALLCONV
	// XMVector3GreaterOrEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3GreaterOrEqual")]
	public static bool XMVector3GreaterOrEqual(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All3True(V2, (a, b) => a >= b);

	/// <summary>
	/// Tests whether one 3D vector is greater-than-or-equal-to another 3D vector and returns a comparison value that can be examined using
	/// functions such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x &gt;= V2.x V1.y &gt;= V2.y V1.z &gt;= V2.z</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3greaterorequalr uint32_t XM_CALLCONV
	// XMVector3GreaterOrEqualR( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3GreaterOrEqualR")]
	public static uint XMVector3GreaterOrEqualR(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All3True(V2, (a, b) => a > b) ? XM_CRMASK_CR6TRUE : V1.All3True(V2, (a, b) => a <= b) ? XM_CRMASK_CR6FALSE : 0;

	/// <summary>
	/// Tests whether one 3D vector is greater than another 3D vector and returns a comparison value that can be examined using functions
	/// such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x &gt; V2.x V1.y &gt; V2.y V1.z &gt; V2.z</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3greaterr uint32_t XM_CALLCONV
	// XMVector3GreaterR( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3GreaterR")]
	public static uint XMVector3GreaterR(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All3True(V2, (a, b) => a >= b) ? XM_CRMASK_CR6TRUE : V1.All3True(V2, (a, b) => a < b) ? XM_CRMASK_CR6FALSE : 0;

	/// <summary>Tests whether the components of a 3D vector are within set bounds.</summary>
	/// <param name="V">3D vector to test.</param>
	/// <param name="Bounds">3D vector that determines the bounds.</param>
	/// <returns>Returns true if both the x, y, and z-components of <i>V</i> are within the set bounds, and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>return (V.x &lt;= Bounds.x &amp;&amp; V.x &gt;= -Bounds.x) &amp;&amp; (V.y &lt;= Bounds.y &amp;&amp; V.y &gt;= -Bounds.y)
	/// &amp;&amp; (V.z &lt;= Bounds.z &amp;&amp; V.z &gt;= -Bounds.z);</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3inbounds bool XMVector3InBounds( [in]
	// FXMVECTOR V, [in] FXMVECTOR Bounds );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3InBounds")]
	public static bool XMVector3InBounds(this FXMVECTOR V, in FXMVECTOR Bounds) => V.All3True(Bounds, (a, b) => a <= b && a >= -b);

	/// <summary>Rotates a 3D vector using the inverse of a quaternion.</summary>
	/// <param name="V">3D vector to rotate.</param>
	/// <param name="RotationQuaternion">Quaternion that describes the inverse of the rotation to apply to the vector.</param>
	/// <returns>Returns the rotated 3D vector.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3inverserotate XMVECTOR XM_CALLCONV
	// XMVector3InverseRotate( [in] FXMVECTOR V, [in] FXMVECTOR RotationQuaternion );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3InverseRotate")]
	public static XMVECTOR XMVector3InverseRotate(this FXMVECTOR V, in FXMVECTOR RotationQuaternion)
	{
		XMVECTOR A = XMVectorSelect(XMVECTOR.g_XMSelect1110, V, XMVECTOR.g_XMSelect1110);
		XMVECTOR Result = XMQuaternionMultiply(RotationQuaternion, A);
		XMVECTOR Q = XMQuaternionConjugate(RotationQuaternion);
		return XMQuaternionMultiply(Result, Q);
	}

	/// <summary>Tests whether any component of a 3D vector is positive or negative infinity.</summary>
	/// <param name="V">3D vector.</param>
	/// <returns>Returns true if any component of <i>V</i> is positive or negative infinity, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3isinfinite bool XM_CALLCONV
	// XMVector3IsInfinite( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3IsInfinite")]
	public static bool XMVector3IsInfinite(this FXMVECTOR V) => V.Any3True(XMISINF);

	/// <summary>Tests whether any component of a 3D vector is a NaN.</summary>
	/// <param name="V">3D vector.</param>
	/// <returns>Returns true if any component of <i>V</i> is a NaN, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3isnan bool XMVector3IsNaN( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3IsNaN")]
	public static bool XMVector3IsNaN(this FXMVECTOR V) => V.Any3True(XMISNAN);

	/// <summary>Computes the length of a 3D vector.</summary>
	/// <param name="V">3D vector.</param>
	/// <returns>Returns a vector. The length of <i>V</i> is replicated into each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3length XMVECTOR XMVector3Length( [in]
	// FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Length")]
	public static XMVECTOR XMVector3Length(this FXMVECTOR V) => XMVectorSqrt(XMVector3LengthSq(V));

	/// <summary>Estimates the length of a 3D vector.</summary>
	/// <param name="V">3D vector.</param>
	/// <returns>Returns a vector, each of whose components are estimates of the length of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3lengthest XMVECTOR XM_CALLCONV
	// XMVector3LengthEst( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3LengthEst")]
	public static XMVECTOR XMVector3LengthEst(this FXMVECTOR V) => XMVectorSqrtEst(XMVector3LengthSq(V));

	/// <summary>Computes the square of the length of a 3D vector.</summary>
	/// <param name="V">3D vector.</param>
	/// <returns>Returns a vector. The square of the length of <i>V</i> is replicated into each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3lengthsq XMVECTOR XM_CALLCONV
	// XMVector3LengthSq( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3LengthSq")]
	public static XMVECTOR XMVector3LengthSq(this FXMVECTOR V) => XMVector3Dot(V, V);

	/// <summary>Tests whether one 3D vector is less than another 3D vector.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns true if <i>V1</i> is less than <i>V2</i> and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &lt; V2.x &amp;&amp; V1.y &lt; V2.y &amp;&amp; V1.z &lt; V2.z );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3less bool XMVector3Less( [in] FXMVECTOR V1,
	// [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Less")]
	public static bool XMVector3Less(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All3True(V2, (a, b) => a < b);

	/// <summary>Tests whether one 3D vector is less-than-or-equal-to another 3D vector.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns true if <i>V1</i> is less-than-or-equal-to <i>V2</i> and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &lt;= V2.x &amp;&amp; V1.y &lt;= V2.y &amp;&amp; V1.z &lt;= V2.z );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3lessorequal bool XM_CALLCONV
	// XMVector3LessOrEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3LessOrEqual")]
	public static bool XMVector3LessOrEqual(this FXMVECTOR V1, in FXMVECTOR V2) => V1.All3True(V2, (a, b) => a <= b);

	/// <summary>Computes the minimum distance between a line and a point.</summary>
	/// <param name="LinePoint1">3D vector describing a point on the line.</param>
	/// <param name="LinePoint2">3D vector describing a point on the line.</param>
	/// <param name="Point">3D vector describing the reference point.</param>
	/// <returns>Returns a vector. The minimum distance between the line and the point is replicated to each of the components.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3linepointdistance XMVECTOR XM_CALLCONV
	// XMVector3LinePointDistance( [in] FXMVECTOR LinePoint1, [in] FXMVECTOR LinePoint2, [in] FXMVECTOR Point );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3LinePointDistance")]
	public static XMVECTOR XMVector3LinePointDistance(this FXMVECTOR LinePoint1, in FXMVECTOR LinePoint2, in FXMVECTOR Point)
	{
		// Given a vector PointVector from LinePoint1 to Point and a vector LineVector from LinePoint1 to LinePoint2, the scaled distance
		// PointProjectionScale from LinePoint1 to the perpendicular projection of PointVector onto the line is defined as:
		//
		// PointProjectionScale = dot(PointVector, LineVector) / LengthSq(LineVector)

		XMVECTOR PointVector = XMVectorSubtract(Point, LinePoint1);
		XMVECTOR LineVector = XMVectorSubtract(LinePoint2, LinePoint1);

		XMVECTOR LengthSq = XMVector3LengthSq(LineVector);

		XMVECTOR PointProjectionScale = XMVector3Dot(PointVector, LineVector);
		PointProjectionScale = XMVectorDivide(PointProjectionScale, LengthSq);

		XMVECTOR DistanceVector = XMVectorMultiply(LineVector, PointProjectionScale);
		DistanceVector = XMVectorSubtract(PointVector, DistanceVector);

		return XMVector3Length(DistanceVector);
	}

	/// <summary>Tests whether one 3D vector is near another 3D vector.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <param name="Epsilon">Tolerance value used for judging equality.</param>
	/// <returns>Returns true if <i>V1</i> is near <i>V2</i> and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>return ( ( abs( V1.x - V2.x ) &lt;= Epsilon ) &amp;&amp; ( abs( V1.y - V2.y ) &lt;= Epsilon ) &amp;&amp; ( abs( V1.z - V2.z )
	/// &lt;= Epsilon ));</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3nearequal bool XM_CALLCONV
	// XMVector3NearEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2, [in] FXMVECTOR Epsilon );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3NearEqual")]
	public static bool XMVector3NearEqual(this FXMVECTOR V1, in FXMVECTOR V2, in FXMVECTOR Epsilon)
	{
		float dx = Math.Abs(V1.x - V2.x);
		float dy = Math.Abs(V1.y - V2.y);
		float dz = Math.Abs(V1.z - V2.z);
		return dx <= Epsilon.x && dy <= Epsilon.y && dz <= Epsilon.z;
	}

	/// <summary>Returns the normalized version of a 3D vector.</summary>
	/// <param name="V">3D vector.</param>
	/// <returns>Returns the normalized version of <i>V</i>.</returns>
	/// <remarks>
	/// <para>For a vector of length 0, this function returns a zero vector. For a vector with infinite length, it returns a vector of QNaN.</para>
	/// <para>
	/// Note that for most graphics applications, ensuring the vectors have well-defined lengths that don't cause problems for normalization
	/// is common practice. However, if you need a robust normalization that works for all floating-point inputs, you can use the following
	/// code instead:
	/// </para>
	/// <para>
	/// <c>inline XMVECTOR XMVector3NormalizeRobust( FXMVECTOR V ) { // Compute the maximum absolute value component. XMVECTOR vAbs =
	/// XMVectorAbs(V); XMVECTOR max0 = XMVectorSplatX(vAbs); XMVECTOR max1 = XMVectorSplatY(vAbs); XMVECTOR max2 = XMVectorSplatZ(vAbs);
	/// max0 = XMVectorMax(max0, max1); max0 = XMVectorMax(max0, max2); // Divide by the maximum absolute component. XMVECTOR normalized =
	/// XMVectorDivide(V, max0); // Set to zero when the original length is zero. XMVECTOR mask = XMVectorNotEqual(XMVECTOR.g_XMZero, max0);
	/// normalized = XMVectorAndInt(normalized, mask); XMVECTOR t0 = XMVector3LengthSq(normalized); XMVECTOR length = XMVectorSqrt(t0); //
	/// Divide by the length to normalize. normalized = XMVectorDivide(normalized, length); // Set to zero when the original length is zero
	/// or infinity. In the // latter case, this is considered to be an unexpected condition. normalized = XMVectorAndInt(normalized, mask);
	/// return normalized; }</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3normalize XMVECTOR XM_CALLCONV
	// XMVector3Normalize( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Normalize")]
	public static XMVECTOR XMVector3Normalize(this FXMVECTOR V)
	{
		var vResult = XMVector3Length(V);
		var fLength = vResult.x;

		// Prevent divide by zero
		if (fLength > 0)
			fLength = 1.0f / fLength;

		return V * fLength;
	}

	/// <summary>Estimates the normalized version of a 3D vector.</summary>
	/// <param name="V">3D vector.</param>
	/// <returns>Returns an estimate of the normalized version of <i>V</i>.</returns>
	/// <remarks>
	/// <para>For a vector with 0 length or infinite length, this function returns a vector of QNaN.</para>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3normalizeest XMVECTOR XM_CALLCONV
	// XMVector3NormalizeEst( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3NormalizeEst")]
	public static XMVECTOR XMVector3NormalizeEst(this FXMVECTOR V) => XMVectorMultiply(V, XMVector3ReciprocalLength(V));

	/// <summary>Tests whether two 3D vectors are not equal.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns true if the 3D vectors are not equal and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x != V2.x || V1.y != V2.y || V1.z != V2.z;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3notequal bool XMVector3NotEqual( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3NotEqual")]
	public static bool XMVector3NotEqual(this FXMVECTOR V1, in FXMVECTOR V2) => !V1.All3True(V2, (a, b) => a == b);

	/// <summary>Test whether two 3D vectors are not equal, treating each component as an unsigned integer.</summary>
	/// <param name="V1">3D vector.</param>
	/// <param name="V2">3D vector.</param>
	/// <returns>Returns true if the 3D vectors are not equal and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3notequalint bool XM_CALLCONV
	// XMVector3NotEqualInt( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3NotEqualInt")]
	public static bool XMVector3NotEqualInt(this FXMVECTOR V1, in FXMVECTOR V2)
	{ unsafe { return V1.u[0] != V2.u[0] || V1.u[1] != V2.u[1] || V1.u[2] != V2.u[2]; } }

	/// <summary>Computes a vector perpendicular to a 3D vector.</summary>
	/// <param name="V">3D vector.</param>
	/// <returns>Returns a 3D vector orthogonal to <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3orthogonal XMVECTOR XM_CALLCONV
	// XMVector3Orthogonal( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Orthogonal")]
	public static XMVECTOR XMVector3Orthogonal(this FXMVECTOR V)
	{
		XMVECTOR Z = XMVectorSplatZ(V);
		XMVECTOR YZYY = XMVectorSwizzle(V, XM_SWIZZLE_Y, XM_SWIZZLE_Z, XM_SWIZZLE_Y, XM_SWIZZLE_Y);

		XMVECTOR NegativeV = XMVectorSubtract(XMVECTOR.g_XMZero, V);

		XMVECTOR ZIsNegative = XMVectorLess(Z, XMVECTOR.g_XMZero);
		XMVECTOR YZYYIsNegative = XMVectorLess(YZYY, XMVECTOR.g_XMZero);

		XMVECTOR S = XMVectorAdd(YZYY, Z);
		XMVECTOR D = XMVectorSubtract(YZYY, Z);

		XMVECTOR Select = XMVectorEqualInt(ZIsNegative, YZYYIsNegative);

		XMVECTOR R0 = XMVectorPermute(NegativeV, S, XM_PERMUTE_1X, XM_PERMUTE_0X, XM_PERMUTE_0X, XM_PERMUTE_0X);
		XMVECTOR R1 = XMVectorPermute(V, D, XM_PERMUTE_1X, XM_PERMUTE_0X, XM_PERMUTE_0X, XM_PERMUTE_0X);

		return XMVectorSelect(R1, R0, Select);
	}

	/// <summary>Project a 3D vector from object space into screen space.</summary>
	/// <param name="V">3D vector in object space that will be projected into screen space.</param>
	/// <param name="ViewportX">
	/// Pixel coordinate of the upper-left corner of the viewport. Unless you want to render to a subset of the surface, this parameter can
	/// be set to 0.
	/// </param>
	/// <param name="ViewportY">
	/// Pixel coordinate of the upper-left corner of the viewport on the render-target surface. Unless you want to render to a subset of the
	/// surface, this parameter can be set to 0.
	/// </param>
	/// <param name="ViewportWidth">
	/// Width dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be
	/// set to the width dimension of the render-target surface.
	/// </param>
	/// <param name="ViewportHeight">
	/// Height dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be
	/// set to the height dimension of the render-target surface.
	/// </param>
	/// <param name="ViewportMinZ">
	/// Together with <i>ViewportMaxZ</i>, value describing the range of depth values into which a scene is to be rendered, the minimum and
	/// maximum values of the clip volume. Most applications set this value to 0.0f. Clipping is performed after applying the projection matrix.
	/// </param>
	/// <param name="ViewportMaxZ">
	/// Together with <i>MinZ</i>, value describing the range of depth values into which a scene is to be rendered, the minimum and maximum
	/// values of the clip volume. Most applications set this value to 1.0f. Clipping is performed after applying the projection matrix.
	/// </param>
	/// <param name="Projection">Projection matrix.</param>
	/// <param name="View">View matrix.</param>
	/// <param name="World">World matrix.</param>
	/// <returns>Returns a vector in screen space.</returns>
	/// <remarks>
	/// <para>
	/// The <i>ViewportX</i>, <i>ViewportY</i>, <i>ViewportWidth</i>, and <i>ViewportHeight</i> parameters describe the position and
	/// dimensions of the viewport on the render-target surface. Usually, applications render to the entire target surface; when rendering
	/// on a 640*480 surface, these parameters should be 0, 0, 640, and 480, respectively. The <i>ViewportMinZ</i> and <i>ViewportMaxZ</i>
	/// are typically set to 0.0f and 1.0f but can be set to other values to achieve specific effects.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3project XMVECTOR XM_CALLCONV
	// XMVector3Project( [in] FXMVECTOR V, [in] float ViewportX, [in] float ViewportY, [in] float ViewportWidth, [in] float ViewportHeight,
	// [in] float ViewportMinZ, [in] float ViewportMaxZ, [in] FXMMATRIX Projection, [in] CXMMATRIX View, [in] CXMMATRIX World );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Project")]
	public static XMVECTOR XMVector3Project(this FXMVECTOR V, float ViewportX, float ViewportY, float ViewportWidth, float ViewportHeight,
		float ViewportMinZ, float ViewportMaxZ, in FXMMATRIX Projection, in CXMMATRIX View, in CXMMATRIX World)
	{
		float HalfViewportWidth = ViewportWidth * 0.5f;
		float HalfViewportHeight = ViewportHeight * 0.5f;

		XMVECTOR Scale = XMVectorSet(HalfViewportWidth, -HalfViewportHeight, ViewportMaxZ - ViewportMinZ, 0.0f);
		XMVECTOR Offset = XMVectorSet(ViewportX + HalfViewportWidth, ViewportY + HalfViewportHeight, ViewportMinZ, 0.0f);

		XMMATRIX Transform = XMMatrixMultiply(World, View);
		Transform = XMMatrixMultiply(Transform, Projection);

		XMVECTOR Result = XMVector3TransformCoord(V, Transform);

		return XMVectorMultiplyAdd(Result, Scale, Offset);
	}

	/// <summary>Projects a stream of 3D vectors from object space into screen space.</summary>
	/// <param name="pOutputStream">Address of the first <c>XMFLOAT3</c> in the destination stream.</param>
	/// <param name="OutputStride">Stride, in bytes, between vectors in the destination stream.</param>
	/// <param name="pInputStream">Address of the first <c>XMFLOAT3</c> in the stream to be transformed.</param>
	/// <param name="InputStride">Stride, in bytes, between vectors in the input stream.</param>
	/// <param name="VectorCount">Number of vectors to transform.</param>
	/// <param name="ViewportX">
	/// Pixel coordinate of the upper-left corner of the viewport. Unless you want to render to a subset of the surface, this parameter can
	/// be set to 0.
	/// </param>
	/// <param name="ViewportY">
	/// Pixel coordinate of the upper-left corner of the viewport on the render-target surface. Unless you want to render to a subset of the
	/// surface, this parameter can be set to 0.
	/// </param>
	/// <param name="ViewportWidth">
	/// Width dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be
	/// set to the width dimension of the render-target surface.
	/// </param>
	/// <param name="ViewportHeight">
	/// Height dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be
	/// set to the height dimension of the render-target surface.
	/// </param>
	/// <param name="ViewportMinZ">
	/// Together with <i>ViewportMaxZ</i>, value describing the range of depth values into which a scene is to be rendered, the minimum and
	/// maximum values of the clip volume. Most applications set this value to 0.0f. Clipping is performed after applying the projection matrix.
	/// </param>
	/// <param name="ViewportMaxZ">
	/// Together with <i>MinZ</i>, value describing the range of depth values into which a scene is to be rendered, the minimum and maximum
	/// values of the clip volume. Most applications set this value to 1.0f. Clipping is performed after applying the projection matrix.
	/// </param>
	/// <param name="Projection">Projection matrix.</param>
	/// <param name="View">View matrix.</param>
	/// <param name="World">World matrix.</param>
	/// <returns>Returns the address of the first <c>XMFLOAT3</c> in the destination stream.</returns>
	/// <remarks>
	/// <para>
	/// The <i>ViewportX</i>, <i>ViewportY</i>, <i>ViewportWidth</i>, and <i>ViewportHeight</i> parameters describe the position and
	/// dimensions of the viewport on the render-target surface. Usually, applications render to the entire target surface; when rendering
	/// on a 640*480 surface, these parameters should be 0, 0, 640, and 480, respectively. The <i>ViewportMinZ</i> and <i>ViewportMaxZ</i>
	/// are typically set to 0.0f and 1.0f but can be set to other values to achieve specific effects.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3projectstream XMFLOAT3 *XM_CALLCONV
	// XMVector3ProjectStream( [out] XMFLOAT3 *pOutputStream, [in] SizeT OutputStride, [in] const XMFLOAT3 *pInputStream, [in] SizeT
	// InputStride, [in] SizeT VectorCount, [in] float ViewportX, [in] float ViewportY, [in] float ViewportWidth, [in] float ViewportHeight,
	// [in] float ViewportMinZ, [in] float ViewportMaxZ, [in] FXMMATRIX Projection, [in] CXMMATRIX View, [in] CXMMATRIX World );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3ProjectStream")]
	public static unsafe XMFLOAT3* XMVector3ProjectStream([Out] XMFLOAT3* pOutputStream, [In] SizeT OutputStride,
		[In] XMFLOAT3* pInputStream, [In] SizeT InputStride, [In] SizeT VectorCount, [In] float ViewportX,
		[In] float ViewportY, [In] float ViewportWidth, [In] float ViewportHeight, [In] float ViewportMinZ,
		[In] float ViewportMaxZ, in FXMMATRIX Projection, in CXMMATRIX View, in CXMMATRIX World)
	{
		if (pOutputStream is null) throw new ArgumentNullException(nameof(pOutputStream));
		if (pInputStream is null) throw new ArgumentNullException(nameof(pInputStream));
		if (InputStride < sizeof(XMFLOAT3)) throw new ArgumentException("Must be at least 12 bytes.", nameof(InputStride));
		if (OutputStride < sizeof(XMFLOAT3)) throw new ArgumentException("Must be at least 12 bytes.", nameof(OutputStride));

		float HalfViewportWidth = ViewportWidth * 0.5f;
		float HalfViewportHeight = ViewportHeight * 0.5f;

		XMVECTOR Scale = XMVectorSet(HalfViewportWidth, -HalfViewportHeight, ViewportMaxZ - ViewportMinZ, 0.0f);
		XMVECTOR Offset = XMVectorSet(ViewportX + HalfViewportWidth, ViewportY + HalfViewportHeight, ViewportMinZ, 0.0f);

		XMMATRIX Transform = XMMatrixMultiply(World, View);
		Transform = XMMatrixMultiply(Transform, Projection);

		var pInputVector = (byte*)pInputStream;
		var pOutputVector = (byte*)pOutputStream;

		for (SizeT i = 0; i < VectorCount; i++)
		{
			XMVECTOR V = XMLoadFloat3(*(XMFLOAT3*)pInputVector);

			XMVECTOR Result = XMVector3TransformCoord(V, Transform);
			Result = XMVectorMultiplyAdd(Result, Scale, Offset);

			XMStoreFloat3((XMFLOAT3*)pOutputVector, Result);

			pInputVector += InputStride;
			pOutputVector += OutputStride;
		}
		return pOutputStream;
	}

	/// <summary>Computes the reciprocal of the length of a 3D vector.</summary>
	/// <param name="V">3D vector.</param>
	/// <returns>Returns a vector. The reciprocal of the length of <i>V</i> is replicated into each of the returned vector's components.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3reciprocallength XMVECTOR XM_CALLCONV
	// XMVector3ReciprocalLength( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3ReciprocalLength")]
	public static XMVECTOR XMVector3ReciprocalLength(this FXMVECTOR V) => XMVectorReciprocalSqrt(XMVector3LengthSq(V));

	/// <summary>Estimates the reciprocal of the length of a 3D vector.</summary>
	/// <param name="V">3D vector.</param>
	/// <returns>Returns a vector, each of whose components are estimates of the reciprocal of the length of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3reciprocallengthest XMVECTOR XM_CALLCONV
	// XMVector3ReciprocalLengthEst( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3ReciprocalLengthEst")]
	public static XMVECTOR XMVector3ReciprocalLengthEst(this FXMVECTOR V) => XMVectorReciprocalSqrtEst(XMVector3LengthSq(V));

	/// <summary>Reflects an incident 3D vector across a 3D normal vector.</summary>
	/// <param name="Incident">3D incident vector to reflect.</param>
	/// <param name="Normal">3D normal vector to reflect the incident vector across.</param>
	/// <returns>Returns the reflected incident angle.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; float s = 2.0f * ( Incident.x * Normal.x + Incident.y * Normal.y + Incident.z * Normal.z ); Result.x =
	/// Incident.x - s * Normal.x; Result.y = Incident.y - s * Normal.y; Result.z = Incident.z - s * Normal.z; Result.w = undefined; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3reflect XMVECTOR XM_CALLCONV
	// XMVector3Reflect( [in] FXMVECTOR Incident, [in] FXMVECTOR Normal );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Reflect")]
	public static XMVECTOR XMVector3Reflect(this FXMVECTOR Incident, in FXMVECTOR Normal) => Incident - 2f * Incident.XMVector3Dot(Normal) * Normal;

	/// <summary>Refracts an incident 3D vector across a 3D normal vector.</summary>
	/// <param name="Incident">3D incident vector to refract.</param>
	/// <param name="Normal">3D normal vector to refract the incident vector through.</param>
	/// <param name="RefractionIndex">Index of refraction. See remarks.</param>
	/// <returns>
	/// Returns the refracted incident vector. If the refraction index and the angle between the incident vector and the normal are such
	/// that the result is a total internal reflection, the function will return a vector of the form &lt; 0.0f, 0.0f, 0.0f, undefined &gt;.
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; float t = ( Incident.x * Normal.x + Incident.y * Normal.y + Incident.z * Normal.z ); float r = 1.0f -
	/// RefractionIndex * RefractionIndex * (1.0f - t * t); if (r &lt; 0.0f) // Total internal reflection { Result.x = 0.0f; Result.y =
	/// 0.0f; Result.z = 0.0f; } else { float s = RefractionIndex * t + sqrt(r); Result.x = RefractionIndex * Incident.x - s * Normal.x;
	/// Result.y = RefractionIndex * Incident.y - s * Normal.y; Result.z = RefractionIndex * Incident.z - s * Normal.z; } Result.w =
	/// undefined; return Result;</c>
	/// </para>
	/// <para>
	/// The index of refraction is the ratio of the index of refraction of the medium containing the incident vector to the index of
	/// refraction of the medium being entered (where the index of refraction of a medium is itself the ratio of the speed of light in a
	/// vacuum to the speed of light in the medium).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3refract XMVECTOR XM_CALLCONV
	// XMVector3Refract( [in] FXMVECTOR Incident, [in] FXMVECTOR Normal, [in] float RefractionIndex );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Refract")]
	public static XMVECTOR XMVector3Refract(this FXMVECTOR Incident, in FXMVECTOR Normal, float RefractionIndex) =>
		XMVector3RefractV(Incident, Normal, XMVectorReplicate(RefractionIndex));

	/// <summary>Refracts an incident 3D vector across a 3D normal vector.</summary>
	/// <param name="Incident">3D incident vector to refract.</param>
	/// <param name="Normal">3D normal vector to refract the incident vector through.</param>
	/// <param name="RefractionIndex">3D vector whose x, y, and z-components are equal to the index of refraction.</param>
	/// <returns>
	/// Returns the refracted incident vector. If the refraction index and the angle between the incident vector and the normal are such
	/// that the result is a total internal reflection, the function will return a vector of the form &lt; 0.0f, 0.0f, 0.0f, undefined &gt;.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is identical to <c>XMVector3Refract</c> except that the <i>RefractionIndex</i> is supplied using a 3D vector instead
	/// of a <b>float</b> value.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3refractv XMVECTOR XM_CALLCONV
	// XMVector3RefractV( [in] FXMVECTOR Incident, [in] FXMVECTOR Normal, [in] FXMVECTOR RefractionIndex );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3RefractV")]
	public static XMVECTOR XMVector3RefractV(this FXMVECTOR Incident, in FXMVECTOR Normal, in FXMVECTOR RefractionIndex)
	{
		XMVECTOR IDotN = XMVector3Dot(Incident, Normal);

		// R = 1.0f - RefractionIndex * RefractionIndex * (1.0f - IDotN * IDotN)
		XMVECTOR R = XMVectorNegativeMultiplySubtract(IDotN, IDotN, XMVECTOR.g_XMOne);
		R = XMVectorMultiply(R, RefractionIndex);
		R = XMVectorNegativeMultiplySubtract(R, RefractionIndex, XMVECTOR.g_XMOne);

		if (XMVector4LessOrEqual(R, XMVECTOR.g_XMZero))
		{
			// Total internal reflection
			return XMVECTOR.g_XMZero;
		}
		else
		{
			// R = RefractionIndex * IDotN + sqrt(R)
			R = XMVectorSqrt(R);
			R = XMVectorMultiplyAdd(RefractionIndex, IDotN, R);

			// Result = RefractionIndex * Incident - Normal * R
			XMVECTOR Result = XMVectorMultiply(RefractionIndex, Incident);
			return XMVectorNegativeMultiplySubtract(Normal, R, Result);
		}
	}

	/// <summary>Rotates a 3D vector using a quaternion.</summary>
	/// <param name="V">3D vector to rotate.</param>
	/// <param name="RotationQuaternion">Quaternion that describes the rotation to apply to the vector.</param>
	/// <returns>Returns the rotated 3D vector.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3rotate XMVECTOR XMVector3Rotate( [in]
	// FXMVECTOR V, [in] FXMVECTOR RotationQuaternion );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Rotate")]
	public static XMVECTOR XMVector3Rotate(this FXMVECTOR V, in FXMVECTOR RotationQuaternion)
	{
		XMVECTOR A = XMVectorSelect(XMVECTOR.g_XMSelect1110, V, XMVECTOR.g_XMSelect1110);
		XMVECTOR Q = XMQuaternionConjugate(RotationQuaternion);
		XMVECTOR Result = XMQuaternionMultiply(Q, A);
		return XMQuaternionMultiply(Result, RotationQuaternion);
	}

	/// <summary>Transforms a 3D vector by a matrix.</summary>
	/// <param name="V">3D vector.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the transformed vector.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMVector3Transform</c> ignores the w component of the input vector, and uses a value of 1 instead. The w component of the
	/// returned vector may be non-homogeneous (!= 1.0).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3transform XMVECTOR XM_CALLCONV
	// XMVector3Transform( [in] FXMVECTOR V, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Transform")]
	public static XMVECTOR XMVector3Transform(this FXMVECTOR V, in FXMMATRIX M)
	{
		XMVECTOR Result = XMVectorMultiplyAdd(XMVectorSplatZ(V), M.r[2], M.r[3]);
		Result = XMVectorMultiplyAdd(XMVectorSplatY(V), M.r[1], Result);
		return XMVectorMultiplyAdd(XMVectorSplatX(V), M.r[0], Result);
	}

	/// <summary>Transforms a 3D vector by a given matrix, projecting the result back into w = 1.</summary>
	/// <param name="V">3D vector.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the transformed vector.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMVector3TransformCoord</c> ignores the w component of the input vector, and uses a value of 1.0 instead. The w component of the
	/// returned vector will always be 1.0.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3transformcoord XMVECTOR XM_CALLCONV
	// XMVector3TransformCoord( [in] FXMVECTOR V, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3TransformCoord")]
	public static XMVECTOR XMVector3TransformCoord(this FXMVECTOR V, in FXMMATRIX M)
	{
		XMVECTOR Z = XMVectorSplatZ(V);
		XMVECTOR Y = XMVectorSplatY(V);
		XMVECTOR X = XMVectorSplatX(V);

		XMVECTOR Result = XMVectorMultiplyAdd(Z, M.r[2], M.r[3]);
		Result = XMVectorMultiplyAdd(Y, M.r[1], Result);
		Result = XMVectorMultiplyAdd(X, M.r[0], Result);

		XMVECTOR W = XMVectorSplatW(Result);
		return XMVectorDivide(Result, W);
	}

	/// <summary>
	/// Transforms a stream of 3D vectors by a given matrix, projecting the resulting vectors such that their w coordinates are equal to 1.0.
	/// </summary>
	/// <param name="pOutputStream">Address of the first <c>XMFLOAT3</c> in the destination stream.</param>
	/// <param name="OutputStride">Stride, in bytes, between vectors in the destination stream.</param>
	/// <param name="pInputStream">Address of the first <c>XMFLOAT3</c> in the stream to be transformed.</param>
	/// <param name="InputStride">Stride, in bytes, between vectors in the input stream.</param>
	/// <param name="VectorCount">Number of vectors to transform.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the address of the first <c>XMFLOAT3</c> in the destination stream.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMVector3TransformCoordStream</c> ignores the w component of the input vector, and uses a value of 1.0 instead. The w component
	/// of the returned vectors will always be 1.0.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3transformcoordstream XMFLOAT3 *XM_CALLCONV
	// XMVector3TransformCoordStream( [out] XMFLOAT3 *pOutputStream, [in] SizeT OutputStride, [in] const XMFLOAT3 *pInputStream, [in] SizeT
	// InputStride, [in] SizeT VectorCount, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3TransformCoordStream")]
	public static unsafe XMFLOAT3* XMVector3TransformCoordStream([Out] XMFLOAT3* pOutputStream, [In] SizeT OutputStride,
		[In] XMFLOAT3* pInputStream, [In] SizeT InputStride, [In] SizeT VectorCount, in FXMMATRIX M)
	{
		if (pOutputStream is null) throw new ArgumentNullException(nameof(pOutputStream));
		if (pInputStream is null) throw new ArgumentNullException(nameof(pInputStream));
		if (InputStride < sizeof(XMFLOAT3)) throw new ArgumentException("Must be at least 12 bytes.", nameof(InputStride));
		if (OutputStride < sizeof(XMFLOAT3)) throw new ArgumentException("Must be at least 12 bytes.", nameof(OutputStride));

		var pInputVector = (byte*)pInputStream;
		var pOutputVector = (byte*)pOutputStream;

		XMVECTOR row0 = M.r[0];
		XMVECTOR row1 = M.r[1];
		XMVECTOR row2 = M.r[2];
		XMVECTOR row3 = M.r[3];

		for (SizeT i = 0; i < VectorCount; i++)
		{
			XMVECTOR V = XMLoadFloat3(*(XMFLOAT3*)pInputVector);
			XMVECTOR Z = XMVectorSplatZ(V);
			XMVECTOR Y = XMVectorSplatY(V);
			XMVECTOR X = XMVectorSplatX(V);

			XMVECTOR Result = XMVectorMultiplyAdd(Z, row2, row3);
			Result = XMVectorMultiplyAdd(Y, row1, Result);
			Result = XMVectorMultiplyAdd(X, row0, Result);

			XMVECTOR W = XMVectorSplatW(Result);

			Result = XMVectorDivide(Result, W);

			XMStoreFloat3((XMFLOAT3*)pOutputVector, Result);

			pInputVector += InputStride;
			pOutputVector += OutputStride;
		}
		return pOutputStream;
	}

	/// <summary>Transforms the 3D vector normal by the given matrix.</summary>
	/// <param name="V">3D normal vector.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the transformed vector.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMVector3TransformNormal</c> performs transformations using the input matrix rows 0, 1, and 2 for rotation and scaling, and
	/// ignores row 3.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3transformnormal XMVECTOR XM_CALLCONV
	// XMVector3TransformNormal( [in] FXMVECTOR V, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3TransformNormal")]
	public static XMVECTOR XMVector3TransformNormal(this FXMVECTOR V, in FXMMATRIX M)
	{
		XMVECTOR Result = XMVectorMultiply(XMVectorSplatZ(V), M.r[2]);
		Result = XMVectorMultiplyAdd(XMVectorSplatY(V), M.r[1], Result);
		return XMVectorMultiplyAdd(XMVectorSplatX(V), M.r[0], Result);
	}

	/// <summary>Transforms a stream of 3D normal vectors by a given matrix.</summary>
	/// <param name="pOutputStream">Address of the first <c>XMFLOAT3</c> in the destination stream.</param>
	/// <param name="OutputStride">Stride, in bytes, between vectors in the destination stream.</param>
	/// <param name="pInputStream">Address of the first <c>XMFLOAT3</c> in the stream to be transformed.</param>
	/// <param name="InputStride">Stride, in bytes, between vectors in the input stream.</param>
	/// <param name="VectorCount">Number of vectors to transform.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the address of the first <c>XMFLOAT3</c> in the destination stream.</returns>
	/// <remarks>
	/// <para>Each vector in the input stream must be normalized.</para>
	/// <para>
	/// <c>XMVector3TransformNormalStream</c> performs transformations using the input matrix rows 0, 1, and 2 for rotation and scaling, and
	/// ignores row 3.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3transformnormalstream XMFLOAT3 *XM_CALLCONV
	// XMVector3TransformNormalStream( [out] XMFLOAT3 *pOutputStream, [in] SizeT OutputStride, [in] const XMFLOAT3 *pInputStream, [in] SizeT
	// InputStride, [in] SizeT VectorCount, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3TransformNormalStream")]
	public static unsafe XMFLOAT3* XMVector3TransformNormalStream([Out] XMFLOAT3* pOutputStream, [In] SizeT OutputStride,
		[In] XMFLOAT3* pInputStream, [In] SizeT InputStride, [In] SizeT VectorCount, in FXMMATRIX M)
	{
		if (pOutputStream is null) throw new ArgumentNullException(nameof(pOutputStream));
		if (pInputStream is null) throw new ArgumentNullException(nameof(pInputStream));
		if (InputStride < sizeof(XMFLOAT3)) throw new ArgumentException("Must be at least 12 bytes.", nameof(InputStride));
		if (OutputStride < sizeof(XMFLOAT3)) throw new ArgumentException("Must be at least 12 bytes.", nameof(OutputStride));

		var pInputVector = (byte*)pInputStream;
		var pOutputVector = (byte*)pOutputStream;

		XMVECTOR row0 = M.r[0];
		XMVECTOR row1 = M.r[1];
		XMVECTOR row2 = M.r[2];

		for (SizeT i = 0; i < VectorCount; i++)
		{
			XMVECTOR V = XMLoadFloat3(*(XMFLOAT3*)pInputVector);
			XMVECTOR Z = XMVectorSplatZ(V);
			XMVECTOR Y = XMVectorSplatY(V);
			XMVECTOR X = XMVectorSplatX(V);

			XMVECTOR Result = XMVectorMultiply(Z, row2);
			Result = XMVectorMultiplyAdd(Y, row1, Result);
			Result = XMVectorMultiplyAdd(X, row0, Result);

			XMStoreFloat3((XMFLOAT3*)pOutputVector, Result);

			pInputVector += InputStride;
			pOutputVector += OutputStride;
		}
		return pOutputStream;
	}

	/// <summary>Transforms a stream of 3D vectors by a given matrix.</summary>
	/// <param name="pOutputStream">Address of the first <c>XMFLOAT4</c> in the destination stream.</param>
	/// <param name="OutputStride">Stride, in bytes, between vectors in the destination stream.</param>
	/// <param name="pInputStream">Address of the first <c>XMFLOAT3</c> in the stream to be transformed.</param>
	/// <param name="InputStride">Stride, in bytes, between vectors in the input stream.</param>
	/// <param name="VectorCount">Number of vectors to transform.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the address of the first <c>XMFLOAT4</c> in the destination stream.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMVector3TransformStream</c> ignores the w component of the input vector, and uses a value of 1.0 instead. The w component of the
	/// returned vectors may be non-homogeneous (!= 1.0).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3transformstream XMFLOAT4 *XM_CALLCONV
	// XMVector3TransformStream( [out] XMFLOAT4 *pOutputStream, [in] SizeT OutputStride, [in] const XMFLOAT3 *pInputStream, [in] SizeT
	// InputStride, [in] SizeT VectorCount, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3TransformStream")]
	public static unsafe XMFLOAT4* XMVector3TransformStream([Out] XMFLOAT4* pOutputStream, [In] SizeT OutputStride,
		[In] XMFLOAT3* pInputStream, [In] SizeT InputStride, [In] SizeT VectorCount, in FXMMATRIX M)
	{
		if (pOutputStream is null) throw new ArgumentNullException(nameof(pOutputStream));
		if (pInputStream is null) throw new ArgumentNullException(nameof(pInputStream));

		if (InputStride < sizeof(XMFLOAT3)) throw new ArgumentException("Must be at least 12 bytes.", nameof(InputStride));
		if (OutputStride < sizeof(XMFLOAT4)) throw new ArgumentException("Must be at least 16 bytes.", nameof(OutputStride));

		var pInputVector = (byte*)pInputStream;
		var pOutputVector = (byte*)pOutputStream;

		XMVECTOR row0 = M.r[0];
		XMVECTOR row1 = M.r[1];
		XMVECTOR row2 = M.r[2];
		XMVECTOR row3 = M.r[3];

		for (SizeT i = 0; i < VectorCount; i++)
		{
			XMVECTOR V = XMLoadFloat3(*(XMFLOAT3*)pInputVector);
			XMVECTOR Z = XMVectorSplatZ(V);
			XMVECTOR Y = XMVectorSplatY(V);
			XMVECTOR X = XMVectorSplatX(V);

			XMVECTOR Result = XMVectorMultiplyAdd(Z, row2, row3);
			Result = XMVectorMultiplyAdd(Y, row1, Result);
			Result = XMVectorMultiplyAdd(X, row0, Result);

			XMStoreFloat4((XMFLOAT4*)pOutputVector, Result);

			pInputVector += InputStride;
			pOutputVector += OutputStride;
		}

		return pOutputStream;
	}

	/// <summary>Projects a 3D vector from screen space into object space.</summary>
	/// <param name="V">
	/// 3D vector in screen space that will be projected into object space. X and Y are in pixels, while Z is 0.0 (at <i>ViewportMinZ</i>)
	/// to 1.0 (at <i>ViewportMaxZ</i>).
	/// </param>
	/// <param name="ViewportX">
	/// Pixel coordinate of the upper-left corner of the viewport. Unless you want to render to a subset of the surface, this parameter can
	/// be set to 0.
	/// </param>
	/// <param name="ViewportY">
	/// Pixel coordinate of the upper-left corner of the viewport on the render-target surface. Unless you want to render to a subset of the
	/// surface, this parameter can be set to 0.
	/// </param>
	/// <param name="ViewportWidth">
	/// Width dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be
	/// set to the width dimension of the render-target surface.
	/// </param>
	/// <param name="ViewportHeight">
	/// Height dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be
	/// set to the height dimension of the render-target surface.
	/// </param>
	/// <param name="ViewportMinZ">
	/// Together with <i>ViewportMaxZ</i>, value describing the range of depth values into which a scene is to be rendered, the minimum and
	/// maximum values of the clip volume. Most applications set this value to 0.0f. Clipping is performed after applying the projection matrix.
	/// </param>
	/// <param name="ViewportMaxZ">
	/// Together with <i>MinZ</i>, value describing the range of depth values into which a scene is to be rendered, the minimum and maximum
	/// values of the clip volume. Most applications set this value to 1.0f. Clipping is performed after applying the projection matrix.
	/// </param>
	/// <param name="Projection">Projection matrix.</param>
	/// <param name="View">View matrix.</param>
	/// <param name="World">World matrix.</param>
	/// <returns>Returns a vector in object space.</returns>
	/// <remarks>
	/// <para>
	/// The <i>ViewportX</i>, <i>ViewportY</i>, <i>ViewportWidth</i>, and <i>ViewportHeight</i> parameters describe the position and
	/// dimensions of the viewport on the render-target surface. Usually, applications render to the entire target surface; when rendering
	/// on a 640*480 surface, these parameters should be 0, 0, 640, and 480, respectively. The <i>ViewportMinZ</i> and <i>ViewportMaxZ</i>
	/// are typically set to 0.0f and 1.0f but can be set to other values to achieve specific effects.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3unproject XMVECTOR XM_CALLCONV
	// XMVector3Unproject( [in] FXMVECTOR V, [in] float ViewportX, [in] float ViewportY, [in] float ViewportWidth, [in] float
	// ViewportHeight, [in] float ViewportMinZ, [in] float ViewportMaxZ, [in] FXMMATRIX Projection, [in] CXMMATRIX View, [in] CXMMATRIX
	// World );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3Unproject")]
	public static XMVECTOR XMVector3Unproject(this FXMVECTOR V, float ViewportX, float ViewportY, float ViewportWidth, float ViewportHeight,
		float ViewportMinZ, float ViewportMaxZ, in FXMMATRIX Projection, in CXMMATRIX View, in CXMMATRIX World)
	{
		XMVECTOR Scale = XMVectorSet(ViewportWidth * 0.5f, -ViewportHeight * 0.5f, ViewportMaxZ - ViewportMinZ, 1.0f);
		Scale = XMVectorReciprocal(Scale);

		XMVECTOR Offset = XMVectorSet(-ViewportX, -ViewportY, -ViewportMinZ, 0.0f);
		Offset = XMVectorMultiplyAdd(Scale, Offset, new(-1.0f, 1.0f, 0.0f, 0.0f));

		XMMATRIX Transform = XMMatrixMultiply(World, View);
		Transform = XMMatrixMultiply(Transform, Projection);
		Transform = XMMatrixInverse(Transform, out _);

		XMVECTOR Result = XMVectorMultiplyAdd(V, Scale, Offset);

		return XMVector3TransformCoord(Result, Transform);
	}

	/// <summary>Transforms a stream of 3D vectors from screen space to object space.</summary>
	/// <param name="pOutputStream">Address of the first <c>XMFLOAT3</c> in the destination stream.</param>
	/// <param name="OutputStride">Stride, in bytes, between vectors in the destination stream.</param>
	/// <param name="pInputStream">
	/// Address of the first <c>XMFLOAT3</c> in the stream to be transformed. X,Y are in pixels, while Z is 0.0 (at <i>ViewportMinZ</i>) to
	/// 1.0 (at <i>ViewportMaxZ</i>).
	/// </param>
	/// <param name="InputStride">Stride, in bytes, between vectors in the input stream.</param>
	/// <param name="VectorCount">Number of vectors to transform.</param>
	/// <param name="ViewportX">
	/// Pixel coordinate of the upper-left corner of the viewport. Unless you want to render to a subset of the surface, this parameter can
	/// be set to 0.
	/// </param>
	/// <param name="ViewportY">
	/// Pixel coordinate of the upper-left corner of the viewport on the render-target surface. Unless you want to render to a subset of the
	/// surface, this parameter can be set to 0.
	/// </param>
	/// <param name="ViewportWidth">
	/// Width dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be
	/// set to the width dimension of the render-target surface.
	/// </param>
	/// <param name="ViewportHeight">
	/// Height dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be
	/// set to the height dimension of the render-target surface.
	/// </param>
	/// <param name="ViewportMinZ">
	/// Together with <i>ViewportMaxZ</i>, value describing the range of depth values into which a scene is to be rendered, the minimum and
	/// maximum values of the clip volume. Most applications set this value to 0.0f. Clipping is performed after applying the projection matrix.
	/// </param>
	/// <param name="ViewportMaxZ">
	/// Together with <i>MinZ</i>, value describing the range of depth values into which a scene is to be rendered, the minimum and maximum
	/// values of the clip volume. Most applications set this value to 1.0f. Clipping is performed after applying the projection matrix.
	/// </param>
	/// <param name="Projection">Projection matrix.</param>
	/// <param name="View">View matrix.</param>
	/// <param name="World">World matrix.</param>
	/// <returns>Returns the address of the first <c>XMFLOAT3</c> in the destination stream.</returns>
	/// <remarks>
	/// <para>
	/// The <i>ViewportX</i>, <i>ViewportY</i>, <i>ViewportWidth</i>, and <i>ViewportHeight</i> parameters describe the position and
	/// dimensions of the viewport on the render-target surface. Usually, applications render to the entire target surface; when rendering
	/// on a 640*480 surface, these parameters should be 0, 0, 640, and 480, respectively. The <i>ViewportMinZ</i> and <i>ViewportMaxZ</i>
	/// are typically set to 0.0f and 1.0f but can be set to other values to achieve specific effects.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector3unprojectstream XMFLOAT3 *XM_CALLCONV
	// XMVector3UnprojectStream( [out] XMFLOAT3 *pOutputStream, [in] SizeT OutputStride, [in] const XMFLOAT3 *pInputStream, [in] SizeT
	// InputStride, [in] SizeT VectorCount, [in] float ViewportX, [in] float ViewportY, [in] float ViewportWidth, [in] float ViewportHeight,
	// [in] float ViewportMinZ, [in] float ViewportMaxZ, [in] FXMMATRIX Projection, [in] CXMMATRIX View, [in] CXMMATRIX World );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector3UnprojectStream")]
	public static unsafe XMFLOAT3* XMVector3UnprojectStream([Out] XMFLOAT3* pOutputStream, [In] SizeT OutputStride,
		[In] XMFLOAT3* pInputStream, [In] SizeT InputStride, [In] SizeT VectorCount, [In] float ViewportX,
		[In] float ViewportY, [In] float ViewportWidth, [In] float ViewportHeight, [In] float ViewportMinZ,
		[In] float ViewportMaxZ, in FXMMATRIX Projection, in CXMMATRIX View, in CXMMATRIX World)
	{
		if (pOutputStream is null) throw new ArgumentNullException(nameof(pOutputStream));
		if (pInputStream is null) throw new ArgumentNullException(nameof(pInputStream));
		if (InputStride < sizeof(XMFLOAT3)) throw new ArgumentException("Must be at least 12 bytes.", nameof(InputStride));
		if (OutputStride < sizeof(XMFLOAT3)) throw new ArgumentException("Must be at least 12 bytes.", nameof(OutputStride));

		XMVECTOR Scale = XMVectorSet(ViewportWidth * 0.5f, -ViewportHeight * 0.5f, ViewportMaxZ - ViewportMinZ, 1.0f);
		Scale = XMVectorReciprocal(Scale);

		XMVECTOR Offset = XMVectorSet(-ViewportX, -ViewportY, -ViewportMinZ, 0.0f);
		Offset = XMVectorMultiplyAdd(Scale, Offset, new(-1.0f, 1.0f, 0.0f, 0.0f));

		XMMATRIX Transform = XMMatrixMultiply(World, View);
		Transform = XMMatrixMultiply(Transform, Projection);
		Transform = XMMatrixInverse(Transform, out _);

		var pInputVector = (byte*)pInputStream;
		var pOutputVector = (byte*)pOutputStream;

		for (SizeT i = 0; i < VectorCount; i++)
		{
			XMVECTOR V = XMLoadFloat3(*(XMFLOAT3*)pInputVector);

			XMVECTOR Result = XMVectorMultiplyAdd(V, Scale, Offset);
			Result = XMVector3TransformCoord(Result, Transform);

			XMStoreFloat3((XMFLOAT3*)pOutputVector, Result);

			pInputVector += InputStride;
			pOutputVector += OutputStride;
		}
		return pOutputStream;
	}

	/// <summary>Compute the radian angle between two normalized 4D vectors.</summary>
	/// <param name="N1">Normalized 4D vector.</param>
	/// <param name="N2">Normalized 4D vector.</param>
	/// <returns>Returns a vector. The radian angle between <i>N1</i> and <i>N2</i> is replicated to each of the components.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4anglebetweennormals XMVECTOR XM_CALLCONV
	// XMVector4AngleBetweenNormals( [in] FXMVECTOR N1, [in] FXMVECTOR N2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4AngleBetweenNormals")]
	public static XMVECTOR XMVector4AngleBetweenNormals(this FXMVECTOR N1, in FXMVECTOR N2)
	{
		XMVECTOR Result = XMVector4Dot(N1, N2);
		Result = XMVectorClamp(Result, XMVECTOR.g_XMNegativeOne, XMVECTOR.g_XMOne);
		return XMVectorACos(Result);
	}

	/// <summary>Estimates the radian angle between two normalized 4D vectors.</summary>
	/// <param name="N1">Normalized 4D vector.</param>
	/// <param name="N2">Normalized 4D vector.</param>
	/// <returns>Returns a vector. The estimate of the radian angle (between <i>N1</i> and <i>N2</i>) is replicated to each of the components.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4anglebetweennormalsest XMVECTOR XM_CALLCONV
	// XMVector4AngleBetweenNormalsEst( [in] FXMVECTOR N1, [in] FXMVECTOR N2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4AngleBetweenNormalsEst")]
	public static XMVECTOR XMVector4AngleBetweenNormalsEst(this FXMVECTOR N1, in FXMVECTOR N2)
	{
		XMVECTOR Result = XMVector4Dot(N1, N2);
		Result = XMVectorClamp(Result, XMVECTOR.g_XMNegativeOne, XMVECTOR.g_XMOne);
		return XMVectorACosEst(Result);
	}

	/// <summary>Compute the radian angle between two 4D vectors.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns a vector. The radian angle between <i>V1</i> and <i>V2</i> is replicated to each of the components.</returns>
	/// <remarks>
	/// <para>If V1 and V2 are normalized 4D vectors, it is faster to use <c>XMVector4AngleBetweenNormals</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4anglebetweenvectors XMVECTOR XM_CALLCONV
	// XMVector4AngleBetweenVectors( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4AngleBetweenVectors")]
	public static XMVECTOR XMVector4AngleBetweenVectors(this FXMVECTOR V1, in FXMVECTOR V2)
	{
		XMVECTOR L1 = XMVector4ReciprocalLength(V1);
		XMVECTOR L2 = XMVector4ReciprocalLength(V2);

		XMVECTOR Dot = XMVector4Dot(V1, V2);

		L1 = XMVectorMultiply(L1, L2);

		XMVECTOR CosAngle = XMVectorMultiply(Dot, L1);
		CosAngle = XMVectorClamp(CosAngle, XMVECTOR.g_XMNegativeOne, XMVECTOR.g_XMOne);

		return XMVectorACos(CosAngle);
	}

	/// <summary>Clamps the length of a 4D vector to a given range.</summary>
	/// <param name="V">4D vector.</param>
	/// <param name="LengthMin">Minimum clamp length.</param>
	/// <param name="LengthMax">Maximum clamp length.</param>
	/// <returns>Returns a 4D vector whose length is clamped to the specified minimum and maximum.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4clamplength XMVECTOR XM_CALLCONV
	// XMVector4ClampLength( [in] FXMVECTOR V, [in] float LengthMin, [in] float LengthMax );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4ClampLength")]
	public static XMVECTOR XMVector4ClampLength(this FXMVECTOR V, float LengthMin, float LengthMax) =>
		XMVector4ClampLengthV(V, XMVectorReplicate(LengthMin), XMVectorReplicate(LengthMax));

	/// <summary>Clamps the length of a 4D vector to a given range.</summary>
	/// <param name="V">4D vector to clamp.</param>
	/// <param name="LengthMin">
	/// 4D vector, all of whose components are equal to the minimum clamp length. The components must be greater-than-or-equal to zero.
	/// </param>
	/// <param name="LengthMax">
	/// 4D vector, all of whose components are equal to the maximum clamp length. The components must be greater-than-or-equal to zero.
	/// </param>
	/// <returns>Returns a 4D vector whose length is clamped to the specified minimum and maximum.</returns>
	/// <remarks>
	/// <para>
	/// This function is identical to <c>XMVector4ClampLength</c> except that <i>LengthMin</i> and <i>LengthMax</i> are supplied using 4D
	/// vectors instead of <b>float</b> values.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4clamplengthv XMVECTOR XM_CALLCONV
	// XMVector4ClampLengthV( [in] FXMVECTOR V, [in] FXMVECTOR LengthMin, [in] FXMVECTOR LengthMax );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4ClampLengthV")]
	public static XMVECTOR XMVector4ClampLengthV(this FXMVECTOR V, in FXMVECTOR LengthMin, in FXMVECTOR LengthMax)
	{
		if (XMVectorGetY(LengthMin) != XMVectorGetX(LengthMin) || XMVectorGetZ(LengthMin) != XMVectorGetX(LengthMin) || XMVectorGetW(LengthMin) != XMVectorGetX(LengthMin)) throw new ArgumentException("Values must be equal.", nameof(LengthMin));
		if (XMVectorGetY(LengthMax) != XMVectorGetX(LengthMax) || XMVectorGetZ(LengthMax) != XMVectorGetX(LengthMax) || XMVectorGetW(LengthMax) != XMVectorGetX(LengthMax)) throw new ArgumentException("Values must be equal.", nameof(LengthMax));
		if (XMVector2Less(LengthMin, XMVECTOR.g_XMZero)) throw new ArgumentException("Values cannot be negative.", nameof(LengthMin));
		if (XMVector2Less(LengthMax, XMVECTOR.g_XMZero)) throw new ArgumentException("Values cannot be negative.", nameof(LengthMax));
		if (XMVector2Less(LengthMax, LengthMin)) throw new ArgumentException("Max must be larger than Min.");

		XMVECTOR LengthSq = XMVector4LengthSq(V);

		XMVECTOR RcpLength = XMVectorReciprocalSqrt(LengthSq);

		XMVECTOR InfiniteLength = XMVectorEqualInt(LengthSq, XMVECTOR.g_XMInfinity);
		XMVECTOR ZeroLength = XMVectorEqual(LengthSq, XMVECTOR.g_XMZero);

		XMVECTOR Normal = XMVectorMultiply(V, RcpLength);

		XMVECTOR Length = XMVectorMultiply(LengthSq, RcpLength);

		XMVECTOR Select = XMVectorEqualInt(InfiniteLength, ZeroLength);
		Length = XMVectorSelect(LengthSq, Length, Select);
		Normal = XMVectorSelect(LengthSq, Normal, Select);

		XMVECTOR ControlMax = XMVectorGreater(Length, LengthMax);
		XMVECTOR ControlMin = XMVectorLess(Length, LengthMin);

		XMVECTOR ClampLength = XMVectorSelect(Length, LengthMax, ControlMax);
		ClampLength = XMVectorSelect(ClampLength, LengthMin, ControlMin);

		XMVECTOR Result = XMVectorMultiply(Normal, ClampLength);

		// Preserve the original vector (with no precision loss) if the length falls within the given range
		XMVECTOR Control = XMVectorEqualInt(ControlMax, ControlMin);
		return XMVectorSelect(Result, V, Control);
	}

	/// <summary>Computes the 4D cross product.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <param name="V3">4D vector.</param>
	/// <returns>Returns the 4D cross product of <i>V1</i>, <i>V2</i>, and <i>V3</i>.</returns>
	/// <remarks>
	/// <para>
	/// A 4D cross-product is not well-defined. This function computes a geometric analog to the 3D cross product.
	/// <c>XMVector4Orthogonal</c> is another generalized 'cross-product' for 4D vectors.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = V1.y * (V2.z * V3.w - V3.z * V2.w) - V1.z * (V2.y * V3.w - V3.y * V2.w ) + V1.w * (V2.y * V3.z - V3.y
	/// * V2.z); Result.y = V1.x * (V3.z * V2.w - V2.z * V3.w) - V1.z * (V3.x * V2.w - V2.x * V3.w) + V1.w * (V3.x * V2.z - V2.x * V3.z);
	/// Result.z = V1.x * (V2.y * V3.w - V3.y * V2.w) - V1.y * (V2.x * V3.w - V3.x * V2.w) + V1.w * (V2.x * V3.y - V3.x * V2.y); Result.w =
	/// V1.x * (V3.y * V2.z - V2.y * V3.z) - V1.y * (V3.x * V2.z - V2.x * V3.z) + V1.z * (V3.x * V2.y - V2.x * V3.y); return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4cross XMVECTOR XMVector4Cross( [in] FXMVECTOR
	// V1, [in] FXMVECTOR V2, [in] FXMVECTOR V3 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Cross")]
	public static XMVECTOR XMVector4Cross(this FXMVECTOR V1, in FXMVECTOR V2, in FXMVECTOR V3) =>
		new((V2.z * V3.w - V2.w * V3.z) * V1.y - (V2.y * V3.w - V2.w * V3.y) * V1.z + (V2.y * V3.z - V2.z * V3.y) * V1.w,
		   (V2.w * V3.z - V2.z * V3.w) * V1.x - (V2.w * V3.x - V2.x * V3.w) * V1.z + (V2.z * V3.x - V2.x * V3.z) * V1.w,
		   (V2.y * V3.w - V2.w * V3.y) * V1.x - (V2.x * V3.w - V2.w * V3.x) * V1.y + (V2.x * V3.y - V2.y * V3.x) * V1.w,
		   (V2.z * V3.y - V2.y * V3.z) * V1.x - (V2.z * V3.x - V2.x * V3.z) * V1.y + (V2.y * V3.x - V2.x * V3.y) * V1.z);

	/// <summary>Computes the dot product between 4D vectors.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns a vector. The dot product between <i>V1</i> and <i>V2</i> is replicated into each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4dot XMVECTOR XMVector4Dot( [in] FXMVECTOR V1,
	// [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Dot")]
	public static XMVECTOR XMVector4Dot(this FXMVECTOR V1, in FXMVECTOR V2) => new((float)(V1.x * V2.x + V1.y * V2.y + V1.z * V2.z + V1.w * V2.w));

	/// <summary>Tests whether two 4D vectors are equal.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns true if the 4D vectors are equal and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x == V2.x &amp;&amp; V1.y == V2.y &amp;&amp; V1.z == V2.z &amp;&amp; V1.w == V2.w );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4equal bool XMVector4Equal( [in] FXMVECTOR V1,
	// [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Equal")]
	public static bool XMVector4Equal(this FXMVECTOR V1, in FXMVECTOR V2) => V1.AllTrue(V2, (a, b) => a == b);

	/// <summary>Tests whether two 4D vectors are equal, treating each component as an unsigned integer.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns true if the 4D vectors are equal and false otherwise.</returns>
	/// <remarks>
	/// <para><c></c><c></c><c></c> Platform Requirements</para>
	/// <para>
	/// Microsoft Visual Studio 2010 or Microsoft Visual Studio 2012 with the Windows SDK for Windows 8. Supported for Win32 desktop apps,
	/// Windows Store apps, and Windows Phone 8 apps.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4equalint bool XMVector4EqualInt( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4EqualInt")]
	public static bool XMVector4EqualInt(in FXMVECTOR V1, in FXMVECTOR V2)
	{ unsafe { return V1.u[0] == V2.u[0] && V1.u[1] == V2.u[1] && V1.u[2] == V2.u[2] && V1.u[3] == V2.u[3]; } }

	/// <summary>
	/// Tests whether two 4D vectors are equal, treating each component as an unsigned integer. In addition, this function returns a
	/// comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x == V2.x V1.y == V2.y V1.z == V2.z V1.w == V2.w</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4equalintr uint32_t XM_CALLCONV
	// XMVector4EqualIntR( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4EqualIntR")]
	public static uint XMVector4EqualIntR(this FXMVECTOR V1, in FXMVECTOR V2)
	{
		unsafe
		{
			if (V1.u[0] == V2.u[0] && V1.u[1] == V2.u[1] && V1.u[2] == V2.u[2] && V1.u[3] == V2.u[3])
				return XM_CRMASK_CR6TRUE;
			if (V1.u[0] != V2.u[0] && V1.u[1] != V2.u[1] && V1.u[2] != V2.u[2] && V1.u[3] != V2.u[3])
				return XM_CRMASK_CR6FALSE;
			return 0;
		}
	}

	/// <summary>
	/// Tests whether two 4D vectors are equal. In addition, this function returns a comparison value that can be examined using functions
	/// such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x == V2.x V1.y == V2.y V1.z == V2.z V1.w == V2.w</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4equalr uint32_t XMVector4EqualR( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4EqualR")]
	public static uint XMVector4EqualR(this FXMVECTOR V1, in FXMVECTOR V2) => V1.AllTrue(V2, (a, b) => a == b) ? XM_CRMASK_CR6TRUE : V1.All3True(V2, (a, b) => a != b) ? XM_CRMASK_CR6FALSE : 0;

	/// <summary>Tests whether one 4D vector is greater than another 4D vector.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns true if <i>V1</i> is greater than <i>V2</i> and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &gt; V2.x &amp;&amp; V1.y &gt; V2.y &amp;&amp; V1.z &gt; V2.z &amp;&amp; V1.w &gt; V2.w );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4greater bool XMVector4Greater( [in] FXMVECTOR
	// V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Greater")]
	public static bool XMVector4Greater(this FXMVECTOR V1, in FXMVECTOR V2) => V1.AllTrue(V2, (a, b) => a > b);

	/// <summary>Tests whether one 4D vector is greater-than-or-equal-to another 4D vector.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns true if <i>V1</i> is greater-than-or-equal-to <i>V2</i> and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &gt;= V2.x &amp;&amp; V1.y &gt;= V2.y &amp;&amp; V1.z &gt;= V2.z &amp;&amp; V1.w &gt;= V2.w );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4greaterorequal bool XM_CALLCONV
	// XMVector4GreaterOrEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4GreaterOrEqual")]
	public static bool XMVector4GreaterOrEqual(this FXMVECTOR V1, in FXMVECTOR V2) => V1.AllTrue(V2, (a, b) => a >= b);

	/// <summary>
	/// Tests whether one 4D vector is greater-than-or-equal-to another 4D vector and returns a comparison value that can be examined using
	/// functions such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x &gt;= V2.x V1.y &gt;= V2.y V1.z &gt;= V2.z V1.w &gt;= V2.w</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4greaterorequalr uint32_t XM_CALLCONV
	// XMVector4GreaterOrEqualR( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4GreaterOrEqualR")]
	public static uint XMVector4GreaterOrEqualR(this FXMVECTOR V1, in FXMVECTOR V2) => V1.AllTrue(V2, (a, b) => a > b) ? XM_CRMASK_CR6TRUE : V1.AllTrue(V2, (a, b) => a <= b) ? XM_CRMASK_CR6FALSE : 0;

	/// <summary>
	/// Tests whether one 4D vector is greater than another 4D vector and returns a comparison value that can be examined using functions
	/// such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.</returns>
	/// <remarks>
	/// <para>This function does the following test:</para>
	/// <para><c>V1.x &gt; V2.x V1.y &gt; V2.y V1.z &gt; V2.z V1.w &gt; V2.w</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4greaterr uint32_t XM_CALLCONV
	// XMVector4GreaterR( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4GreaterR")]
	public static uint XMVector4GreaterR(this FXMVECTOR V1, in FXMVECTOR V2) => V1.AllTrue(V2, (a, b) => a >= b) ? XM_CRMASK_CR6TRUE : V1.AllTrue(V2, (a, b) => a < b) ? XM_CRMASK_CR6FALSE : 0;

	/// <summary>Tests whether the components of a 4D vector are within set bounds.</summary>
	/// <param name="V">4D vector to test.</param>
	/// <param name="Bounds">4D vector that determines the bounds.</param>
	/// <returns>Returns true if all of the components of <i>V</i> are within the set bounds, and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>return (V.x &lt;= Bounds.x &amp;&amp; V.x &gt;= -Bounds.x) &amp;&amp; (V.y &lt;= Bounds.y &amp;&amp; V.y &gt;= -Bounds.y)
	/// &amp;&amp; (V.z &lt;= Bounds.z &amp;&amp; V.z &gt;= -Bounds.z) &amp;&amp; (V.w &lt;= Bounds.w &amp;&amp; V.w &gt;= -Bounds.w);</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4inbounds bool XMVector4InBounds( [in]
	// FXMVECTOR V, [in] FXMVECTOR Bounds );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4InBounds")]
	public static bool XMVector4InBounds(this FXMVECTOR V, in FXMVECTOR Bounds) => V.AllTrue(Bounds, (a, b) => a <= b && a >= -b);

	/// <summary>Tests whether any component of a 4D vector is positive or negative infinity.</summary>
	/// <param name="V">4D vector.</param>
	/// <returns>Returns true if any component of <i>V</i> is positive or negative infinity, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4isinfinite bool XM_CALLCONV
	// XMVector4IsInfinite( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4IsInfinite")]
	public static bool XMVector4IsInfinite(this FXMVECTOR V) => V.Any3True(XMISINF);

	/// <summary>Tests whether any component of a 4D vector is a NaN.</summary>
	/// <param name="V">4D vector.</param>
	/// <returns>Returns true if any component of <i>V</i> is a NaN, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4isnan bool XMVector4IsNaN( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4IsNaN")]
	public static bool XMVector4IsNaN(this FXMVECTOR V) => V.Any3True(XMISNAN);

	/// <summary>Computes the length of a 4D vector.</summary>
	/// <param name="V">4D vector.</param>
	/// <returns>Returns a vector. The length of <i>V</i> is replicated into each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4length XMVECTOR XMVector4Length( [in]
	// FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Length")]
	public static XMVECTOR XMVector4Length(this FXMVECTOR V) => XMVectorSqrt(XMVector4LengthSq(V));

	/// <summary>Estimates the length of a 4D vector.</summary>
	/// <param name="V">4D vector.</param>
	/// <returns>Returns a vector, each of whose components are estimates of the length of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4lengthest XMVECTOR XM_CALLCONV
	// XMVector4LengthEst( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4LengthEst")]
	public static XMVECTOR XMVector4LengthEst(this FXMVECTOR V) => XMVectorSqrtEst(XMVector4LengthSq(V));

	/// <summary>Computes the square of the length of a 4D vector.</summary>
	/// <param name="V">4D vector.</param>
	/// <returns>Returns a vector. The square of the length of <i>V</i> is replicated into each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4lengthsq XMVECTOR XM_CALLCONV
	// XMVector4LengthSq( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4LengthSq")]
	public static XMVECTOR XMVector4LengthSq(this FXMVECTOR V) => XMVector4Dot(V, V);

	/// <summary>Tests whether one 4D vector is less than another 4D vector.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns true if <i>V1</i> is less than <i>V2</i> and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &lt; V2.x &amp;&amp; V1.y &lt; V2.y &amp;&amp; V1.z &lt; V2.z &amp;&amp; V1.w &lt; V2.w );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4less bool XMVector4Less( [in] FXMVECTOR V1,
	// [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Less")]
	public static bool XMVector4Less(this FXMVECTOR V1, in FXMVECTOR V2) => V1.AllTrue(V2, (a, b) => a < b);

	/// <summary>Tests whether one 4D vector is less-than-or-equal-to another 4D vector.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns true if <i>V1</i> is less-than-or-equal-to <i>V2</i>, and false otherwise. See the remarks section.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x &lt;= V2.x &amp;&amp; V1.y &lt;= V2.y &amp;&amp; V1.z &lt;= V2.z &amp;&amp; V1.w &lt;= V2.w );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4lessorequal bool XM_CALLCONV
	// XMVector4LessOrEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4LessOrEqual")]
	public static bool XMVector4LessOrEqual(this FXMVECTOR V1, in FXMVECTOR V2) => V1.AllTrue(V2, (a, b) => a <= b);

	/// <summary>Tests whether one 4D vector is near another 4D vector.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <param name="Epsilon">Tolerance value used for judging equality.</param>
	/// <returns>Returns true if <i>V1</i> is near <i>V2</i> and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>return ( ( abs( V1.x - V2.x ) &lt;= Epsilon ) &amp;&amp; ( abs( V1.y - V2.y ) &lt;= Epsilon ) &amp;&amp; ( abs( V1.z - V2.z )
	/// &lt;= Epsilon ) &amp;&amp; ( abs( V1.w - V2.w ) &lt;= Epsilon ));</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4nearequal bool XM_CALLCONV
	// XMVector4NearEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2, [in] FXMVECTOR Epsilon );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4NearEqual")]
	public static bool XMVector4NearEqual(this FXMVECTOR V1, in FXMVECTOR V2, in FXMVECTOR Epsilon)
	{
		float dx = Math.Abs(V1.x - V2.x);
		float dy = Math.Abs(V1.y - V2.y);
		float dz = Math.Abs(V1.z - V2.z);
		float dw = Math.Abs(V1.w - V2.w);
		return dx <= Epsilon.x && dy <= Epsilon.y && dz <= Epsilon.z && dw <= Epsilon.w;
	}

	/// <summary>Returns the normalized version of a 4D vector.</summary>
	/// <param name="V">4D vector.</param>
	/// <returns>Returns the normalized version of <i>V</i>.</returns>
	/// <remarks>
	/// <para>For a vector of length 0, this function returns a zero vector. For a vector with infinite length, it returns a vector of QNaN.</para>
	/// <para>
	/// Note that for most graphics applications, ensuring the vectors have well-defined lengths that don't cause problems for normalization
	/// is common practice. However, if you need a robust normalization that works for all floating-point inputs, you can use the following
	/// code instead:
	/// </para>
	/// <para>
	/// <c>inline XMVECTOR XMVector4NormalizeRobust( FXMVECTOR V ) { // Compute the maximum absolute value component. XMVECTOR vAbs =
	/// XMVectorAbs(V); XMVECTOR max0 = XMVectorSplatX(vAbs); XMVECTOR max1 = XMVectorSplatY(vAbs); XMVECTOR max2 = XMVectorSplatZ(vAbs);
	/// XMVECTOR max3 = XMVectorSplatW(vAbs); max0 = XMVectorMax(max0, max1); max2 = XMVectorMax(max2, max3); max0 = XMVectorMax(max0,
	/// max2); // Divide by the maximum absolute component. XMVECTOR normalized = XMVectorDivide(V, max0); // Set to zero when the original
	/// length is zero. XMVECTOR mask = XMVectorNotEqual(XMVECTOR.g_XMZero, max0); normalized = XMVectorAndInt(normalized, mask); //
	/// (sqrLength, sqrLength, sqrLength, sqrLength) XMVECTOR t0 = XMVector4Dot(normalized, normalized); // (length, length, length, length)
	/// XMVECTOR length = XMVectorSqrt(t0); // Divide by the length to normalize. normalized = XMVectorDivide(normalized, length); // Set to
	/// zero when the original length is zero or infinity. In the // latter case, this is considered to be an unexpected condition.
	/// normalized = XMVectorAndInt(normalized, mask); return normalized; }</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4normalize XMVECTOR XM_CALLCONV
	// XMVector4Normalize( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Normalize")]
	public static XMVECTOR XMVector4Normalize(this FXMVECTOR V)
	{
		var vResult = XMVector4Length(V);
		var fLength = vResult.x;

		// Prevent divide by zero
		if (fLength > 0)
			fLength = 1.0f / fLength;

		return V * fLength;
	}

	/// <summary>Estimates the normalized version of a 4D vector.</summary>
	/// <param name="V">4D vector.</param>
	/// <returns>Returns an estimate of the normalized version of <i>V</i>.</returns>
	/// <remarks>
	/// <para>For a vector with 0 length or infinite length, this function returns a vector of QNaN.</para>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4normalizeest XMVECTOR XM_CALLCONV
	// XMVector4NormalizeEst( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4NormalizeEst")]
	public static XMVECTOR XMVector4NormalizeEst(this FXMVECTOR V) => XMVectorMultiply(V, XMVector4ReciprocalLength(V));

	/// <summary>Tests whether two 4D vectors are not equal.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns true if the 4D vectors are not equal and false otherwise.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>return ( V1.x != V2.x || V1.y != V2.y || V1.z != V2.z || V1.w != V2.w );</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4notequal bool XMVector4NotEqual( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4NotEqual")]
	public static bool XMVector4NotEqual(this FXMVECTOR V1, in FXMVECTOR V2) => !V1.AllTrue(V2, (a, b) => a == b);

	/// <summary>Test whether two 4D vectors are not equal, treating each component as an unsigned integer.</summary>
	/// <param name="V1">4D vector.</param>
	/// <param name="V2">4D vector.</param>
	/// <returns>Returns true if the 4D vectors are not equal and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4notequalint bool XM_CALLCONV
	// XMVector4NotEqualInt( [in] FXMVECTOR V1, [in] FXMVECTOR V2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4NotEqualInt")]
	public static bool XMVector4NotEqualInt(this FXMVECTOR V1, in FXMVECTOR V2)
	{ unsafe { return V1.u[0] != V2.u[0] || V1.u[1] != V2.u[1] || V1.u[2] != V2.u[2] || V1.u[3] != V2.u[3]; } }

	/// <summary>Computes a vector perpendicular to a 4D vector.</summary>
	/// <param name="V">4D vector.</param>
	/// <returns>Returns the 4D vector orthogonal to <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// A 4D cross-product is not well-defined. This function computes a generalized 'cross-product' for 4D vectors. <c>XMVector4Cross</c>
	/// is another geometric 'cross-product' for 4D vectors.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>XMVECTOR Result; Result.x = V.z; Result.y = V.w; Result.z = -V.x; Result.w = -V.y; return Result;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4orthogonal XMVECTOR XM_CALLCONV
	// XMVector4Orthogonal( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Orthogonal")]
	public static XMVECTOR XMVector4Orthogonal(this FXMVECTOR V) => new(V.z, V.w, -V.x, -V.y);

	/// <summary>Computes the reciprocal of the length of a 4D vector.</summary>
	/// <param name="V">4D vector.</param>
	/// <returns>Returns the reciprocal of the length of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4reciprocallength XMVECTOR XM_CALLCONV
	// XMVector4ReciprocalLength( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4ReciprocalLength")]
	public static XMVECTOR XMVector4ReciprocalLength(this FXMVECTOR V) => XMVectorReciprocalSqrt(XMVector4LengthSq(V));

	/// <summary>Estimates the reciprocal of the length of a 4D vector.</summary>
	/// <param name="V">4D vector.</param>
	/// <returns>Returns a vector, each of whose components are estimates of the reciprocal of the length of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4reciprocallengthest XMVECTOR XM_CALLCONV
	// XMVector4ReciprocalLengthEst( [in] FXMVECTOR V );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4ReciprocalLengthEst")]
	public static XMVECTOR XMVector4ReciprocalLengthEst(this FXMVECTOR V) => XMVectorReciprocalSqrtEst(XMVector4LengthSq(V));

	/// <summary>Reflects an incident 4D vector across a 4D normal vector.</summary>
	/// <param name="Incident">4D incident vector to reflect.</param>
	/// <param name="Normal">4D normal vector to reflect the incident vector across.</param>
	/// <returns>Returns the reflected incident angle.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; float s = 2.0f * dot(Incident, Normal); Result.x = Incident.x - s * Normal.x; Result.y = Incident.y - s *
	/// Normal.y; Result.z = Incident.z - s * Normal.z; Result.w = Incident.w - s * Normal.w; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4reflect XMVECTOR XM_CALLCONV
	// XMVector4Reflect( [in] FXMVECTOR Incident, [in] FXMVECTOR Normal );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Reflect")]
	public static XMVECTOR XMVector4Reflect(this FXMVECTOR Incident, in FXMVECTOR Normal) => Incident - 2f * Incident.XMVector4Dot(Normal) * Normal;

	/// <summary>Refracts an incident 4D vector across a 4D normal vector.</summary>
	/// <param name="Incident">4D incident vector to refract.</param>
	/// <param name="Normal">4D normal vector to refract the incident vector through.</param>
	/// <param name="RefractionIndex">Index of refraction. See remarks.</param>
	/// <returns>
	/// Returns the refracted incident vector. If the refraction index and the angle between the incident vector and the normal are such
	/// that the result is a total internal reflection, the function will return a vector of the form &lt; 0.0f, 0.0f, 0.0f, 0.0f &gt;.
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; float t = dot(Incident, Normal); float r = 1.0f - RefractionIndex * RefractionIndex * (1.0f - t * t); if (r &lt;
	/// 0.0f) // Total internal reflection { Result.x = 0.0f; Result.y = 0.0f; Result.z = 0.0f; Result.w = 0.0f; } else { float s =
	/// RefractionIndex * t + sqrt(r); Result.x = RefractionIndex * Incident.x - s * Normal.x; Result.y = RefractionIndex * Incident.y - s *
	/// Normal.y; Result.z = RefractionIndex * Incident.z - s * Normal.z; Result.w = RefractionIndex * Incident.w - s * Normal.w; } return Result;</c>
	/// </para>
	/// <para>
	/// The index of refraction is the ratio of the index of refraction of the medium containing the incident vector to the index of
	/// refraction of the medium being entered (where the index of refraction of a medium is itself the ratio of the speed of light in a
	/// vacuum to the speed of light in the medium).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4refract XMVECTOR XM_CALLCONV
	// XMVector4Refract( [in] FXMVECTOR Incident, [in] FXMVECTOR Normal, [in] float RefractionIndex );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Refract")]
	public static XMVECTOR XMVector4Refract(this FXMVECTOR Incident, in FXMVECTOR Normal, float RefractionIndex) =>
		 XMVector4RefractV(Incident, Normal, XMVectorReplicate(RefractionIndex));

	/// <summary>Refracts an incident 4D vector across a 4D normal vector.</summary>
	/// <param name="Incident">4D incident vector to refract.</param>
	/// <param name="Normal">4D normal vector to refract the incident vector through.</param>
	/// <param name="RefractionIndex">4D vector, all of whose components are equal to the index of refraction.</param>
	/// <returns>
	/// Returns the refracted incident vector. If the refraction index and the angle between the incident vector and the normal are such
	/// that the result is a total internal reflection, the function will return a vector of the form &lt; 0.0f, 0.0f, 0.0f, 0.0f &gt;.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is identical to <c>XMVector4Refract</c> except that the <i>RefractionIndex</i> is supplied using a 4D vector instead
	/// of a <b>float</b> value.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4refractv XMVECTOR XM_CALLCONV
	// XMVector4RefractV( [in] FXMVECTOR Incident, [in] FXMVECTOR Normal, [in] FXMVECTOR RefractionIndex );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4RefractV")]
	public static XMVECTOR XMVector4RefractV(this FXMVECTOR Incident, in FXMVECTOR Normal, in FXMVECTOR RefractionIndex)
	{
		// Result = RefractionIndex * Incident - Normal * (RefractionIndex * dot(Incident, Normal) + sqrt(1 - RefractionIndex *
		// RefractionIndex * (1 - dot(Incident, Normal) * dot(Incident, Normal))))

		var IDotN = XMVector4Dot(Incident, Normal);

		// R = 1.0f - RefractionIndex * RefractionIndex * (1.0f - IDotN * IDotN)
		var R = XMVectorNegativeMultiplySubtract(IDotN, IDotN, XMVECTOR.g_XMOne);
		R = XMVectorMultiply(R, RefractionIndex);
		R = XMVectorNegativeMultiplySubtract(R, RefractionIndex, XMVECTOR.g_XMOne);

		if (XMVector4LessOrEqual(R, XMVECTOR.g_XMZero))
			// Total internal reflection
			return XMVECTOR.g_XMZero;

		// R = RefractionIndex * IDotN + sqrt(R)
		R = XMVectorSqrt(R);
		R = XMVectorMultiplyAdd(RefractionIndex, IDotN, R);

		// Result = RefractionIndex * Incident - Normal * R
		var Result = XMVectorMultiply(RefractionIndex, Incident);
		return XMVectorNegativeMultiplySubtract(Normal, R, Result);
	}

	/// <summary>Transforms a 4D vector by a matrix.</summary>
	/// <param name="V">4D vector.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the transformed vector.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4transform XMVECTOR XM_CALLCONV
	// XMVector4Transform( [in] FXMVECTOR V, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4Transform")]
	public static XMVECTOR XMVector4Transform(this FXMVECTOR V, in FXMMATRIX M)
	{
		float fX = M[0, 0] * V.x + M[1, 0] * V.y + M[2, 0] * V.z + M[3, 0] * V.w;
		float fY = M[0, 1] * V.x + M[1, 1] * V.y + M[2, 1] * V.z + M[3, 1] * V.w;
		float fZ = M[0, 2] * V.x + M[1, 2] * V.y + M[2, 2] * V.z + M[3, 2] * V.w;
		float fW = M[0, 3] * V.x + M[1, 3] * V.y + M[2, 3] * V.z + M[3, 3] * V.w;
		return new(fX, fY, fZ, fW);
	}

	/// <summary>Transforms a stream of 4D vectors by a given matrix.</summary>
	/// <param name="pOutputStream">Address of the first <c>XMFLOAT4</c> in the destination stream.</param>
	/// <param name="OutputStride">Stride, in bytes, between vectors in the destination stream.</param>
	/// <param name="pInputStream">Address of the first <c>XMFLOAT4</c> in the stream to be transformed.</param>
	/// <param name="InputStride">Stride, in bytes, between vectors in the input stream.</param>
	/// <param name="VectorCount">Number of vectors to transform.</param>
	/// <param name="M">Transformation matrix.</param>
	/// <returns>Returns the address of the first <c>XMFLOAT4</c> in the destination stream.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvector4transformstream XMFLOAT4 *XM_CALLCONV
	// XMVector4TransformStream( [out] XMFLOAT4 *pOutputStream, [in] SizeT OutputStride, [in] const XMFLOAT4 *pInputStream, [in] SizeT
	// InputStride, [in] SizeT VectorCount, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVector4TransformStream")]
	public static unsafe XMFLOAT4* XMVector4TransformStream([Out] XMFLOAT4* pOutputStream, [In] SizeT OutputStride,
		[In] XMFLOAT4* pInputStream, [In] SizeT InputStride, [In] SizeT VectorCount, in FXMMATRIX M)
	{
		if (pOutputStream == null) throw new ArgumentNullException(nameof(pOutputStream));
		if (pInputStream == null) throw new ArgumentNullException(nameof(pInputStream));
		if (InputStride < sizeof(XMFLOAT4)) throw new ArgumentException("Must be at least 16 bytes.", nameof(InputStride));
		if (OutputStride < sizeof(XMFLOAT4)) throw new ArgumentException("Must be at least 16 bytes.", nameof(OutputStride));

		var pInputVector = (byte*)pInputStream;
		var pOutputVector = (byte*)pOutputStream;

		XMVECTOR row0 = M.r[0];
		XMVECTOR row1 = M.r[1];
		XMVECTOR row2 = M.r[2];
		XMVECTOR row3 = M.r[3];

		for (SizeT i = 0; i < VectorCount; i++)
		{
			XMVECTOR V = XMLoadFloat4(*(XMFLOAT4*)pInputVector);
			XMVECTOR W = XMVectorSplatW(V);
			XMVECTOR Z = XMVectorSplatZ(V);
			XMVECTOR Y = XMVectorSplatY(V);
			XMVECTOR X = XMVectorSplatX(V);

			XMVECTOR Result = XMVectorMultiply(W, row3);
			Result = XMVectorMultiplyAdd(Z, row2, Result);
			Result = XMVectorMultiplyAdd(Y, row1, Result);
			Result = XMVectorMultiplyAdd(X, row0, Result);

			XMStoreFloat4((XMFLOAT4*)pOutputVector, Result);

			pInputVector += InputStride;
			pOutputVector += OutputStride;
		}

		return pOutputStream;
	}

	/// <summary>Computes the absolute value of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the absolute value.</param>
	/// <returns>Returns a vector whose components are the absolute value of the corresponding components of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorabs XMVECTOR XM_CALLCONV XMVectorAbs( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorAbs")]
	public static XMVECTOR XMVectorAbs(this FXMVECTOR V) => V.UnaryOp(Math.Abs);

	/// <summary>Computes the arccosine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the arccosine. Each component should be between -1.0f and 1.0f.</param>
	/// <returns>Returns a vector whose components are the arccosine of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para>This function uses a 7-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectoracos XMVECTOR XM_CALLCONV XMVectorACos( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorACos")]
	public static XMVECTOR XMVectorACos(this FXMVECTOR V) => V.UnaryOp(Math.Acos);

	/// <summary>Estimates the arccosine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the arccosine. Each component should be between -1.0f and 1.0f.</param>
	/// <returns>Returns a vector whose components are estimates of the arccosine of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 3-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectoracosest XMVECTOR XM_CALLCONV XMVectorACosEst(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorACosEst")]
	public static XMVECTOR XMVectorACosEst(this FXMVECTOR V) => XMVectorACos(V);

	/// <summary>Computes the sum of two vectors.</summary>
	/// <param name="V1">First vector to add.</param>
	/// <param name="V2">Second vector to add.</param>
	/// <returns>Returns a vector that is the sum of <i>V1</i> and <i>V2</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectoradd XMVECTOR XM_CALLCONV XMVectorAdd( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorAdd")]
	public static XMVECTOR XMVectorAdd(this FXMVECTOR V1, in FXMVECTOR V2) => V2.BinaryOp(V2, (a, b) => a + b);

	/// <summary>Adds two vectors representing angles.</summary>
	/// <param name="V1">First vector of angles. Each angle must satisfy -XM_PI &lt;= <i>V1</i> &lt; XM_PI.</param>
	/// <param name="V2">Second vector of angles. Each angle must satisfy -XM_2PI &lt;= <i>V1</i> &lt; XM_2PI.</param>
	/// <returns>
	/// Returns a vector whose components are the sums of the angles of the corresponding components. Each component of the returned vector
	/// will be an angle less than XM_PI and greater than or equal to -XM_PI.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectoraddangles XMVECTOR XM_CALLCONV
	// XMVectorAddAngles( [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorAddAngles")]
	public static XMVECTOR XMVectorAddAngles(this FXMVECTOR V1, in FXMVECTOR V2)
	{
		// Add the given angles together. If the range of V1 is such that -Pi <= V1 < Pi and the range of V2 is such that
		// -2Pi <= V2 <= 2Pi, then the range of the resulting angle will be -Pi <= Result < Pi.
		XMVECTOR Result = XMVectorAdd(V1, V2);

		XMVECTOR Mask = XMVectorLess(Result, XMVECTOR.g_XMNegativePi);
		XMVECTOR Offset = XMVectorSelect(XMVECTOR.g_XMZero, XMVECTOR.g_XMTwoPi, Mask);

		Mask = XMVectorGreaterOrEqual(Result, XMVECTOR.g_XMPi);
		Offset = XMVectorSelect(Offset, XMVECTOR.g_XMNegativeTwoPi, Mask);

		return XMVectorAdd(Result, Offset);
	}

	/// <summary>
	/// Computes the logical AND of one vector with the negation of a second vector, treating each component as an unsigned integer.
	/// </summary>
	/// <param name="V1">First vector.</param>
	/// <param name="V2">Second vector.</param>
	/// <returns>
	/// Returns a vector whose components are the logical AND of each of the components of <i>V1</i> with the negation of the corresponding
	/// components of <i>V2</i>.
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = V1.x &amp; ~V2.x; Result.y = V1.y &amp; ~V2.y; Result.z = V1.z &amp; ~V2.z; Result.w = V1.w &amp;
	/// ~V2.w; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorandcint XMVECTOR XM_CALLCONV XMVectorAndCInt(
	// [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorAndCInt")]
	public static XMVECTOR XMVectorAndCInt(this FXMVECTOR V1, in FXMVECTOR V2) => V1.BinaryIntOp(V2, (u1, u2) => u1 & ~u2);

	/// <summary>Computes the logical AND of two vectors, treating each component as an unsigned integer.</summary>
	/// <param name="V1">First vector.</param>
	/// <param name="V2">Second vector.</param>
	/// <returns>Returns a vector each of whose components are the logical AND of the corresponding components of <i>V1</i> and <i>V2</i>.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = V1.x &amp; V2.x; Result.y = V1.y &amp; V2.y; Result.z = V1.z &amp; V2.z; Result.w = V1.w &amp; V2.w;
	/// return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorandint XMVECTOR XM_CALLCONV XMVectorAndInt(
	// [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorAndInt")]
	public static XMVECTOR XMVectorAndInt(this FXMVECTOR V1, in FXMVECTOR V2) => V1.BinaryIntOp(V2, (u1, u2) => u1 & u2);

	/// <summary>Computes the arcsine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the arcsine. Each component should be between -1.0f and 1.0f.</param>
	/// <returns>Returns a vector whose components are the arcsine of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para>This function uses a 7-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorasin XMVECTOR XM_CALLCONV XMVectorASin( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorASin")]
	public static XMVECTOR XMVectorASin(this FXMVECTOR V) => V.UnaryOp(Math.Asin);

	/// <summary>Estimates the arcsine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the arcsine. Each component should be between -1.0f and 1.0f.</param>
	/// <returns>Returns a vector whose components are estimates of the arcsine of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 3-term minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorasinest XMVECTOR XM_CALLCONV XMVectorASinEst(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorASinEst")]
	public static XMVECTOR XMVectorASinEst(this FXMVECTOR V) => XMVectorASin(V);

	/// <summary>Computes the arctangent of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the arctangent.</param>
	/// <returns>Returns a vector whose components are the arctangent of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para>This function uses a 17-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectoratan XMVECTOR XM_CALLCONV XMVectorATan( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorATan")]
	public static XMVECTOR XMVectorATan(this FXMVECTOR V) => V.UnaryOp(Math.Atan);

	/// <summary>Computes the arctangent of <i>Y</i>/ <i>X</i>.</summary>
	/// <param name="Y">First vector.</param>
	/// <param name="X">Second vector.</param>
	/// <returns>
	/// <para>
	/// Returns a vector. Each component is the arctangent of the corresponding <i>Y</i> component divided by the corresponding <i>X</i>
	/// component. Each component is in the range (-PI/2, PI/2).
	/// </para>
	/// <para><c>XMVectorATan2</c> returns the following values for the specified special input values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Input Value</description>
	/// <description>Return Value</description>
	/// </listheader>
	/// <item>
	/// <description>Y == 0 and X &lt; 0</description>
	/// <description>Pi with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>Y == 0 and X &gt; 0</description>
	/// <description>0 with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>Y != 0 and X == 0</description>
	/// <description>Pi / 2 with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>X == -Infinity and Y is finite</description>
	/// <description>Pi with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>X == +Infinity and Y is finite</description>
	/// <description>0 with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>Y == Infinity and X is finite</description>
	/// <description>Pi / 2 with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>Y == Infinity and X == -Infinity</description>
	/// <description>3Pi / 4 with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>Y == Infinity and X == +Infinity</description>
	/// <description>Pi / 4 with the same sign as Y</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function uses a 17-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectoratan2 XMVECTOR XM_CALLCONV XMVectorATan2( [in]
	// FXMVECTOR Y, [in] FXMVECTOR X ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorATan2")]
	public static XMVECTOR XMVectorATan2(this FXMVECTOR Y, in FXMVECTOR X) => Y.BinaryOp(X, (a, b) => (float)Math.Atan2(a, b));

	/// <summary>Estimates the arctangent of <i>Y</i>/ <i>X</i>.</summary>
	/// <param name="Y">First vector.</param>
	/// <param name="X">Second vector.</param>
	/// <returns>
	/// <para>
	/// Returns a vector. Each component is an estimate of the arctangent of the corresponding <i>Y</i> component divided by the
	/// corresponding <i>X</i> component. Each component is in the range (-PI/2, PI/2).
	/// </para>
	/// <para><c>XMVectorATan2Est</c> returns the following values for the specified special input values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Input Value</description>
	/// <description>Return Value</description>
	/// </listheader>
	/// <item>
	/// <description>Y == 0 and X &lt; 0</description>
	/// <description>Pi with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>Y == 0 and X &gt; 0</description>
	/// <description>0 with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>Y != 0 and X == 0</description>
	/// <description>Pi / 2 with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>X == -Infinity and Y is finite</description>
	/// <description>Pi with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>X == +Infinity and Y is finite</description>
	/// <description>0 with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>Y == Infinity and X is finite</description>
	/// <description>Pi / 2 with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>Y == Infinity and X == -Infinity</description>
	/// <description>3Pi / 4 with the same sign as Y</description>
	/// </item>
	/// <item>
	/// <description>Y == Infinity and X == +Infinity</description>
	/// <description>Pi / 4 with the same sign as Y</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 9-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectoratan2est XMVECTOR XM_CALLCONV
	// XMVectorATan2Est( [in] FXMVECTOR Y, [in] FXMVECTOR X ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorATan2Est")]
	public static XMVECTOR XMVectorATan2Est(this FXMVECTOR Y, in FXMVECTOR X) => XMVectorATan2(Y, X);

	/// <summary>Estimates the arctangent of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the arctangent.</param>
	/// <returns>Returns a vector whose components are estimates of the arctangent of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 9-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectoratanest XMVECTOR XM_CALLCONV XMVectorATanEst(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorATanEst")]
	public static XMVECTOR XMVectorATanEst(this FXMVECTOR V) => XMVectorATan(V);

	/// <summary>Returns a point in Barycentric coordinates, using the specified position vectors.</summary>
	/// <param name="Position0">First position.</param>
	/// <param name="Position1">Second position.</param>
	/// <param name="Position2">Third position.</param>
	/// <param name="f">Weighting factor. See the remarks.</param>
	/// <param name="g">Weighting factor. See the remarks.</param>
	/// <returns>Returns the Barycentric coordinates.</returns>
	/// <remarks>
	/// <para>
	/// This function provides a way to understand points in and around a triangle, independent of where the triangle is located. This
	/// function returns the resulting point by using the following equation: <i>Position0</i>&gt; + <i>f</i>&gt;( <i>Position1</i>-
	/// <i>Position0</i>&gt;) + <i>g</i>&gt;( <i>Position2</i>- <i>Position0</i>&gt;).
	/// </para>
	/// <para>
	/// Any point in the plane <i>Position0</i>&gt; <i>Position1</i>&gt; <i>Position2</i>&gt; can be represented by the Barycentric
	/// coordinate ( <i>f</i>&gt;, <i>g</i>&gt;), where <i>f</i>&gt; controls how much <i>Position1</i>&gt; gets weighted into the result,
	/// and <i>g</i>&gt; controls how much <i>Position2</i>&gt; gets weighted into the result. Lastly, 1- <i>f</i>&gt;- <i>g</i>&gt;
	/// controls how much <i>Position0</i>&gt; gets weighted into the result.
	/// </para>
	/// <para>Note the following relations.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If ( <i>f</i>&gt;=0 &amp;&amp; <i>g</i>&gt;=0 &amp;&amp; 1- <i>f</i>- <i>g</i>&gt;=0), the point is inside the triangle
	/// <i>Position0</i>&gt; <i>Position1</i>&gt; <i>Position2</i>&gt;.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If ( <i>f</i>==0 &amp;&amp; <i>g</i>&gt;=0 &amp;&amp; 1- <i>f</i>- <i>g</i>&gt;=0), the point is on the line <i>Position0</i>&gt; <i>Position2</i>&gt;.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If ( <i>f</i>&gt;=0 &amp;&amp; <i>g</i>==0 &amp;&amp; 1- <i>f</i>-g&gt;=0), the point is on the line <i>Position0</i>&gt; <i>Position1</i>&gt;.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If ( <i>f</i>&gt;=0 &amp;&amp; <i>g</i>&gt;=0 &amp;&amp; 1- <i>f</i>- <i>g</i>==0), the point is on the line <i>Position1</i>&gt; <i>Position2</i>&gt;.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// Barycentric coordinates are a form of general coordinates. In this context, using Barycentric coordinates represents a change in
	/// coordinate systems. What holds true for Cartesian coordinates holds true for Barycentric coordinates.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorbarycentric XMVECTOR XM_CALLCONV
	// XMVectorBaryCentric( [in] FXMVECTOR Position0, [in] FXMVECTOR Position1, [in] FXMVECTOR Position2, [in] float f, [in] float g ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorBaryCentric")]
	public static XMVECTOR XMVectorBaryCentric(this FXMVECTOR Position0, in FXMVECTOR Position1, in FXMVECTOR Position2, float f, float g)
	{
		XMVECTOR P10 = XMVectorSubtract(Position1, Position0);
		XMVECTOR ScaleF = XMVectorReplicate(f);

		XMVECTOR P20 = XMVectorSubtract(Position2, Position0);
		XMVECTOR ScaleG = XMVectorReplicate(g);

		XMVECTOR Result = XMVectorMultiplyAdd(P10, ScaleF, Position0);
		return XMVectorMultiplyAdd(P20, ScaleG, Result);
	}

	/// <summary>Returns a point in Barycentric coordinates, using the specified position vectors.</summary>
	/// <param name="Position0">First position.</param>
	/// <param name="Position1">Second position.</param>
	/// <param name="Position2">Third position.</param>
	/// <param name="F">Weighting factors for the corresponding components of the position.</param>
	/// <param name="G">Weighting factors for the corresponding components of the position.</param>
	/// <returns>Returns the Barycentric coordinates.</returns>
	/// <remarks>
	/// <para>
	/// This function is identical to <c>XMVectorBaryCentric</c> except that independent weighting factors may supplied in <i>F</i> and
	/// <i>G</i>. As an example, you might want to calculate two sets of 2D Barycentric coordinates, using the x and y-components of the
	/// position vectors for one set of 2D positions and the z and w-components of the position vectors for the other set of 2D positions.
	/// The x and y-components of <i>F</i> and <i>G</i> would determine the weighting factors for the first set of Barycentric coordinates.
	/// Similarly, the z and w-components of <i>F</i> and <i>G</i> would determine the weighting factors for the second set of Barycentric coordinates.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorbarycentricv XMVECTOR XM_CALLCONV
	// XMVectorBaryCentricV( [in] FXMVECTOR Position0, [in] FXMVECTOR Position1, [in] FXMVECTOR Position2, [in] GXMVECTOR F, [in] HXMVECTOR
	// G ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorBaryCentricV")]
	public static XMVECTOR XMVectorBaryCentricV(this FXMVECTOR Position0, in FXMVECTOR Position1, in FXMVECTOR Position2, GXMVECTOR F, HXMVECTOR G)
	{
		XMVECTOR P10 = XMVectorSubtract(Position1, Position0);
		XMVECTOR P20 = XMVectorSubtract(Position2, Position0);

		XMVECTOR Result = XMVectorMultiplyAdd(P10, F, Position0);
		return XMVectorMultiplyAdd(P20, G, Result);
	}

	/// <summary>Performs a Catmull-Rom interpolation, using the specified position vectors.</summary>
	/// <param name="Position0">First position.</param>
	/// <param name="Position1">Second position.</param>
	/// <param name="Position2">Third position.</param>
	/// <param name="Position3">Fourth position.</param>
	/// <param name="t">Interpolating control factor.</param>
	/// <returns>Returns the results of the Catmull-Rom interpolation.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; float t2 = t * t; float t3 = t2* t; float P0 = -t3 + 2.0f * t2 - t; float P1 = 3.0f * t3 - 5.0f * t2 + 2.0f;
	/// float P2 = -3.0f * t3 + 4.0f * t2 + t; float P3 = t3 - t2; Result.x = (P0 * Position0.x + P1 * Position1.x + P2 * Position2.x + P3 *
	/// Position3.x) * 0.5f; Result.y = (P0 * Position0.y + P1 * Position1.y + P2 * Position2.y + P3 * Position3.y) * 0.5f; Result.z = (P0 *
	/// Position0.z + P1 * Position1.z + P2 * Position2.z + P3 * Position3.z) * 0.5f; Result.w = (P0 * Position0.w + P1 * Position1.w + P2 *
	/// Position2.w + P3 * Position3.w) * 0.5f; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorcatmullrom XMVECTOR XM_CALLCONV
	// XMVectorCatmullRom( [in] FXMVECTOR Position0, [in] FXMVECTOR Position1, [in] FXMVECTOR Position2, [in] GXMVECTOR Position3, [in]
	// float t ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorCatmullRom")]
	public static XMVECTOR XMVectorCatmullRom(this FXMVECTOR Position0, in FXMVECTOR Position1, in FXMVECTOR Position2, in GXMVECTOR Position3, float t)
	{
		float t2 = t * t;
		float t3 = t2 * t;

		XMVECTOR P0 = XMVectorReplicate((-t3 + 2.0f * t2 - t) * 0.5f);
		XMVECTOR P1 = XMVectorReplicate((3.0f * t3 - 5.0f * t2 + 2.0f) * 0.5f);
		XMVECTOR P2 = XMVectorReplicate((-3.0f * t3 + 4.0f * t2 + t) * 0.5f);
		XMVECTOR P3 = XMVectorReplicate((t3 - t2) * 0.5f);

		XMVECTOR Result = XMVectorMultiply(P0, Position0);
		Result = XMVectorMultiplyAdd(P1, Position1, Result);
		Result = XMVectorMultiplyAdd(P2, Position2, Result);
		return XMVectorMultiplyAdd(P3, Position3, Result);
	}

	/// <summary>Performs a Catmull-Rom interpolation, using the specified position vectors.</summary>
	/// <param name="Position0">First position.</param>
	/// <param name="Position1">Second position.</param>
	/// <param name="Position2">Third position.</param>
	/// <param name="Position3">Fourth position.</param>
	/// <param name="T">Interpolating control factor for the corresponding components of the position.</param>
	/// <returns>Returns the results of the Catmull-Rom interpolation.</returns>
	/// <remarks>
	/// <para>
	/// This function is identical to <c>XMVectorCatmullRom</c> except that independent weighting factors may supplied in <i>T</i>. As an
	/// example, you might want to calculate two sets of Catmull-Rom interpolation, using the x and y-components of the position vectors for
	/// one set of 2D positions and the z and w-components of the position vectors for the other set of 2D positions. The x and y-components
	/// of <i>T</i> would determine the interpolation factors for the first Catmull-Rom interpolation. Similarly, the z and w-components of
	/// <i>T</i> would determine the interpolation factors for the second Catmull-Rom interpolation.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorcatmullromv XMVECTOR XM_CALLCONV
	// XMVectorCatmullRomV( [in] FXMVECTOR Position0, [in] FXMVECTOR Position1, [in] FXMVECTOR Position2, [in] GXMVECTOR Position3, [in]
	// HXMVECTOR T ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorCatmullRomV")]
	public static XMVECTOR XMVectorCatmullRomV(this FXMVECTOR Position0, in FXMVECTOR Position1, in FXMVECTOR Position2, GXMVECTOR Position3, HXMVECTOR T)
	{
		float fx = T.x;
		float fy = T.y;
		float fz = T.z;
		float fw = T.w;
		return new(
			0.5f * ((-fx * fx * fx + 2 * fx * fx - fx) * Position0.x
			+ (3 * fx * fx * fx - 5 * fx * fx + 2) * Position1.x
			+ (-3 * fx * fx * fx + 4 * fx * fx + fx) * Position2.x
			+ (fx * fx * fx - fx * fx) * Position3.x),

			0.5f * ((-fy * fy * fy + 2 * fy * fy - fy) * Position0.y
			+ (3 * fy * fy * fy - 5 * fy * fy + 2) * Position1.y
			+ (-3 * fy * fy * fy + 4 * fy * fy + fy) * Position2.y
			+ (fy * fy * fy - fy * fy) * Position3.y),

			0.5f * ((-fz * fz * fz + 2 * fz * fz - fz) * Position0.z
			+ (3 * fz * fz * fz - 5 * fz * fz + 2) * Position1.z
			+ (-3 * fz * fz * fz + 4 * fz * fz + fz) * Position2.z
			+ (fz * fz * fz - fz * fz) * Position3.z),

			0.5f * ((-fw * fw * fw + 2 * fw * fw - fw) * Position0.w
			+ (3 * fw * fw * fw - 5 * fw * fw + 2) * Position1.w
			+ (-3 * fw * fw * fw + 4 * fw * fw + fw) * Position2.w
			+ (fw * fw * fw - fw * fw) * Position3.w));
	}

	/// <summary>Computes the ceiling of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the ceiling.</param>
	/// <returns>Returns a vector whose components are the ceiling of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para><b>XMVectorCeiling</b> is implemented like this:</para>
	/// <para><c>XMVECTOR Result; Result.x = ceilf(V.x); Result.y = ceilf(V.y); Result.z = ceilf(V.z); Result.w = ceilf(V.w); return Result;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorceiling XMVECTOR XM_CALLCONV XMVectorCeiling(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorCeiling")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorCeiling(this FXMVECTOR V) => V.UnaryOp(Math.Ceiling);

	/// <summary>Clamps the components of a vector to a specified minimum and maximum range.</summary>
	/// <param name="V">Vector whose components are to be clamped.</param>
	/// <param name="Min">Minimum range vector.</param>
	/// <param name="Max">Maximum range vector.</param>
	/// <returns>Returns a vector whose components are clamped to the specified minimum and maximum values.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = min( max( V.x, Min.x ), Max.x ); Result.y = min( max( V.y, Min.y ), Max.y ); Result.z = min( max(
	/// V.z, Min.z ), Max.z ); Result.w = min( max( V.w, Min.w ), Max.w ); return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorclamp XMVECTOR XM_CALLCONV XMVectorClamp( [in]
	// FXMVECTOR V, [in] FXMVECTOR Min, [in] FXMVECTOR Max ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorClamp")]
	public static XMVECTOR XMVectorClamp(this FXMVECTOR V, in FXMVECTOR Min, in FXMVECTOR Max) =>
		XMVectorMin(Max, XMVectorMax(Min, V));

	/// <summary>Computes the cosine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the cosine.</param>
	/// <returns>Returns a vector. Each component is the cosine of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>This function uses a 10-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorcos XMVECTOR XM_CALLCONV XMVectorCos( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorCos")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorCos(this FXMVECTOR V) => V.UnaryOp(Math.Cos);

	/// <summary>Estimates the cosine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the cosine.</param>
	/// <returns>Returns a vector. Each component is an estimate of the cosine of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 7-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorcosest XMVECTOR XM_CALLCONV XMVectorCosEst(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorCosEst")]
	public static XMVECTOR XMVectorCosEst(this FXMVECTOR V) => XMVectorCos(V);

	/// <summary>Computes the hyperbolic cosine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the hyperbolic cosine.</param>
	/// <returns>Returns a vector. Each component is the hyperbolic cosine of the corresponding component of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorcosh XMVECTOR XM_CALLCONV XMVectorCosH( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorCosH")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorCosH(this FXMVECTOR V) => V.UnaryOp(Math.Cosh);

	/// <summary>
	/// <para>Divides one instance of <c>XMVECTOR</c> by a second instance, returning the result in a third instance.</para>
	/// <para>
	/// The <c>XMVectorDivide</c> divides each component of an instance of <c>XMVECTOR Data Type</c> by the corresponding component in a
	/// second instance of <c>XMVECTOR</c>, returning a new <c>XMVECTOR</c> instance containing the result.
	/// </para>
	/// </summary>
	/// <param name="V1">XMVECTOR instance whose components are the <i>dividends</i> of the division operation.</param>
	/// <param name="V2">XMVECTOR instance whose components are the <i>divisors</i> of the division operation.</param>
	/// <returns>
	/// <c>XMVECTOR</c> instance whose components are the <i>quotient</i> of the division of each component of <b>V1</b> by each
	/// corresponding component of <b>V2</b>.
	/// </returns>
	/// <remarks>
	/// <para>The following code is generally faster than calling <c>XMVectorDivide</c> if the loss of precision is tolerable.</para>
	/// <para><c>XMVECTOR R = XMVectorReciprocalEst(V2) XMVectorMultiply(V1,R)</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectordivide XMVECTOR XM_CALLCONV XMVectorDivide(
	// [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorDivide")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorDivide(this FXMVECTOR V1, in FXMVECTOR V2) => V2.BinaryOp(V2, (a, b) => a / b);

	/// <summary>Performs a per-component test for equality of two vectors.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V1.x == V2.x) ? 0xFFFFFFFF : 0; Result.y = (V1.y == V2.y) ? 0xFFFFFFFF : 0; Result.z = (V1.z ==
	/// V2.z) ? 0xFFFFFFFF : 0; Result.w = (V1.w == V2.w) ? 0xFFFFFFFF : 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorequal XMVECTOR XM_CALLCONV XMVectorEqual( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorEqual(this FXMVECTOR V1, in FXMVECTOR V2) => Compare(V1, V2, (a, b) => a == b);

	/// <summary>Performs a per-component test for the equality of two vectors, treating each component as an unsigned integer.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V1.x == V2.x) ? 0xFFFFFFFF : 0; Result.y = (V1.y == V2.y) ? 0xFFFFFFFF : 0; Result.z = (V1.z ==
	/// V2.z) ? 0xFFFFFFFF : 0; Result.w = (V1.w == V2.w) ? 0xFFFFFFFF : 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorequalint XMVECTOR XM_CALLCONV
	// XMVectorEqualInt( [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorEqualInt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorEqualInt(this FXMVECTOR V1, in FXMVECTOR V2) => CompareU(V1, V2, (a, b) => a == b);

	/// <summary>
	/// Performs a per-component test for equality of two vectors, treating each component as an unsigned integer. In addition, this
	/// function sets a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="pCR">
	/// Pointer to a <b>uint32_t</b> comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>. The
	/// <c>XMComparisonXXXX</c> functions may be used to further test the number of components that passed the comparison.
	/// </param>
	/// <param name="V">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorequalintr XMVECTOR XM_CALLCONV
	// XMVectorEqualIntR( [out] uint32_t *pCR, FXMVECTOR V, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorEqualIntR")]
	public static XMVECTOR XMVectorEqualIntR(out uint pCR, in FXMVECTOR V, in FXMVECTOR V2)
	{
		var Control = XMVectorEqualInt(V, V2);
		if (XMVector4EqualInt(Control, XMVectorTrueInt()))
			pCR = XM_CRMASK_CR6TRUE;
		else pCR = XMVector4EqualInt(Control, XMVectorFalseInt()) ? XM_CRMASK_CR6FALSE : 0;
		return Control;
	}

	/// <summary>
	/// Performs a per-component test for equality of two vectors and sets a comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="pCR">
	/// Pointer to a <b>uint32_t</b> comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>. The
	/// <c>XMComparisonXXXX</c> functions may be used to further test the number of components that passed the comparison.
	/// </param>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks></remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorequalr XMVECTOR XM_CALLCONV XMVectorEqualR(
	// [out] uint32_t *pCR, [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorEqualR")]
	public static XMVECTOR XMVectorEqualR(out uint pCR, in FXMVECTOR V1, in FXMVECTOR V2)
	{
		var u = XMVectorEqual(V1, V2);
		if ((u.ux & u.uy & u.uz & u.uw) != 0)
			pCR = XM_CRMASK_CR6TRUE;
		else pCR = (u.ux | u.uy | u.uz | u.uw) == 0 ? XM_CRMASK_CR6FALSE : 0;
		return u;
	}

	/// <summary>
	/// <para>Computes two raised to the power for each component.</para>
	/// <para>
	/// <b>Note</b>  This function is a compatibility alias for <c>XMVectorExp2</c> for existing Windows 8 code. This function is deprecated
	/// for Windows 8.1. Don't use it and instead use <b>XMVectorExp2</b> or <c>XMVectorExpE</c>.
	/// <para></para>
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="V">Vector used for the exponents of base two.</param>
	/// <returns>Returns a vector whose components are two raised to the power of the corresponding component of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorexp XMVECTOR XM_CALLCONV XMVectorExp( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorExp")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorExp(this FXMVECTOR V) => XMVectorExp2(V);

	/// <summary>Computes ten raised to the power for each component.</summary>
	/// <param name="V">Vector used for the exponents of base ten.</param>
	/// <returns>Returns a vector whose components are ten raised to the power of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <para>This function was added in DirectXMath 3.16</para>
	/// </para>
	/// <para><b>XMVectorExp10</b> is implemented like this:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = powf(10.0f, V.x); Result.y = powf(10.0f, V.y); Result.z = powf(10.0f, V.z); Result.w = powf(10.0f,
	/// V.w); return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorexp10 XMVECTOR XM_CALLCONV XMVectorExp10( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorExp10")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorExp10(this FXMVECTOR V) => V.UnaryOp(f => Math.Pow(f, 10f));

	/// <summary>Computes two raised to the power for each component.</summary>
	/// <param name="V">Vector used for the exponents of base two.</param>
	/// <returns>Returns a vector whose components are two raised to the power of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <b>XMVectorExp2</b> is new for DirectXMath version 3.05, but it's just a renamed version of the existing <c>XMVectorExp</c> function
	/// for Windows 8.
	/// </para>
	/// <para><b>XMVectorExp2</b> is implemented like this:</para>
	/// <para><c>XMVECTOR Result; Result.x = exp2f(V.x); Result.y = exp2f(V.y); Result.z = exp2f(V.z); Result.w = exp2f(V.w); return Result;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorexp2 XMVECTOR XM_CALLCONV XMVectorExp2( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorExp2")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorExp2(this FXMVECTOR V) => V.UnaryOp(f => Math.Pow(f, 2f));

	/// <summary>Computes e (~2.71828) raised to the power for each component.</summary>
	/// <param name="V">Vector used for the exponents of base e.</param>
	/// <returns>Returns a vector whose components are e raised to the power of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para><b>XMVectorExpE</b> is new for DirectXMath version 3.05.</para>
	/// <para>It's similar to the existing <c>XMVectorExp</c> function for Windows 8, but computes base e instead of base 2.</para>
	/// <para><b>XMVectorExpE</b> is implemented like this:</para>
	/// <para><c>XMVECTOR Result; Result.x = expf(V.x); Result.y = expf(V.y); Result.z = expf(V.z); Result.w = expf(V.w); return Result;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorexpe XMVECTOR XM_CALLCONV XMVectorExpE( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorExpE")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorExpE(this FXMVECTOR V) => V.UnaryOp(Math.Exp);

	/// <summary>Returns the zero (false) vector.</summary>
	/// <returns>Returns the zero (false) vector.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorfalseint XMVECTOR XM_CALLCONV
	// XMVectorFalseInt() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorFalseInt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorFalseInt() => new(0U);

	/// <summary>Computes the floor of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the floor.</param>
	/// <returns>Returns a vector whose components are the floor of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para><b>XMVectorFloor</b> is implemented like this:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = floorf(V.x); Result.y = floorf(V.y); Result.z = floorf(V.z); Result.w = floorf(V.w); return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorfloor XMVECTOR XM_CALLCONV XMVectorFloor( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorFloor")]
	public static XMVECTOR XMVectorFloor(this FXMVECTOR V) => V.UnaryOp(Math.Floor);

	/// <summary>Retrieve the value of one of the four components of an <c>XMVECTOR Data Type</c> containing floating-point data by index.</summary>
	/// <param name="V">A <c>XMVECTOR Data Type</c> containing integer data.</param>
	/// <param name="i">The index of the component to be retrieved.</param>
	/// <returns>The floating-point value of the selected component.</returns>
	/// <remarks>
	/// <para>The value of <i>i</i> must be positive and less than or equal to three ( <i>0</i> &lt;= <i>i</i> &lt;= <i>3</i> ).</para>
	/// <para>The indexes have the following correspondence with <c>XMVECTOR Data Type</c> vector components:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Index</description>
	/// <description>Component</description>
	/// </listheader>
	/// <item>
	/// <description>
	/// <code>0</code>
	/// </description>
	/// <description>
	/// <code>x</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>1</code>
	/// </description>
	/// <description>
	/// <code>y</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>2</code>
	/// </description>
	/// <description>
	/// <code>z</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>3</code>
	/// </description>
	/// <description>
	/// <code>w</code>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetbyindex float XM_CALLCONV
	// XMVectorGetByIndex( FXMVECTOR V, size_t i ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetByIndex")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float XMVectorGetByIndex(this FXMVECTOR V, SizeT i) => V[i];

	/// <summary>
	/// Retrieve, into an instance of a floating-point referenced by pointer, the value of one of the four components of an <c>XMVECTOR Data
	/// Type</c> containing floating-point data, referenced by index.
	/// </summary>
	/// <param name="f">
	/// Pointer to an instance of a floating-point object that will receive the value of the <i>i</i> component of the <c>XMVECTOR Data
	/// Type</c> object <c>V</c>.
	/// </param>
	/// <param name="V">A <c>XMVECTOR Data Type</c> containing floating-point data.</param>
	/// <param name="i">The index of the component to be retrieved.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The value of <i>i</i> must be positive and less than or equal to three ( <i>0</i> &lt;= <i>i</i> &lt;= <i>3</i> ).</para>
	/// <para>The indexes have the following correspondence with <c>XMVECTOR Data Type</c> vector components:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Index</description>
	/// <description>Component</description>
	/// </listheader>
	/// <item>
	/// <description>
	/// <code>0</code>
	/// </description>
	/// <description>
	/// <code>x</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>1</code>
	/// </description>
	/// <description>
	/// <code>y</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>2</code>
	/// </description>
	/// <description>
	/// <code>z</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>3</code>
	/// </description>
	/// <description>
	/// <code>w</code>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetbyindexptr void XM_CALLCONV
	// XMVectorGetByIndexPtr( [out] float *f, FXMVECTOR V, size_t i ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetByIndexPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorGetByIndexPtr(ref float f, in FXMVECTOR V, SizeT i) => f = XMVectorGetByIndex(V, i);

	/// <summary>Retrieve the value of one of the four components of an <c>XMVECTOR Data Type</c> containing integer data by index.</summary>
	/// <param name="V">A <c>XMVECTOR Data Type</c> containing integer data.</param>
	/// <param name="i">The index of the component to be retrieved.</param>
	/// <returns>The integer value of the selected component.</returns>
	/// <remarks>
	/// <para>The value of <i>i</i> must be positive and less than or equal to three ( <i>0</i> &lt;= <i>i</i> &lt;= <i>3</i> ).</para>
	/// <para>The indexes have the following correspondence with <c>XMVECTOR Data Type</c> vector components:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Index</description>
	/// <description>Component</description>
	/// </listheader>
	/// <item>
	/// <description>
	/// <code>0</code>
	/// </description>
	/// <description>
	/// <code>x</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>1</code>
	/// </description>
	/// <description>
	/// <code>y</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>2</code>
	/// </description>
	/// <description>
	/// <code>z</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>3</code>
	/// </description>
	/// <description>
	/// <code>w</code>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetintbyindex uint32_t XM_CALLCONV
	// XMVectorGetIntByIndex( FXMVECTOR V, size_t i ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetIntByIndex")]
	public static uint XMVectorGetIntByIndex(this FXMVECTOR V, SizeT i)
	{
		if (i < 0 || i > 3)
			throw new ArgumentOutOfRangeException(nameof(i), "Index must be value between 0 and 3.");
		unsafe { return V.u[i]; }
	}

	/// <summary>
	/// Retrieve, into an instance of an integer referenced by pointer, the value of one of the four components of an <c>XMVECTOR Data
	/// Type</c> containing integer data by index.
	/// </summary>
	/// <param name="x">
	/// Pointer to an instance of an integer object that will receive the value of the <i>i</i> component of the <c>XMVECTOR Data Type</c>
	/// object <c>V</c>.
	/// </param>
	/// <param name="V">A <c>XMVECTOR Data Type</c> containing integer data.</param>
	/// <param name="i">The index of the component to be retrieved.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The value of <i>i</i> must be positive and less than or equal to three ( <i>0</i> &lt;= <i>i</i> &lt;= <i>3</i> ).</para>
	/// <para>The indexes have the following correspondence with <c>XMVECTOR Data Type</c> vector components:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Index</description>
	/// <description>Component</description>
	/// </listheader>
	/// <item>
	/// <description>
	/// <code>0</code>
	/// </description>
	/// <description>
	/// <code>x</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>1</code>
	/// </description>
	/// <description>
	/// <code>y</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>2</code>
	/// </description>
	/// <description>
	/// <code>z</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>3</code>
	/// </description>
	/// <description>
	/// <code>w</code>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetintbyindexptr void XM_CALLCONV
	// XMVectorGetIntByIndexPtr( [out] uint32_t *x, FXMVECTOR V, size_t i ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetIntByIndexPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorGetIntByIndexPtr(ref uint x, in FXMVECTOR V, SizeT i) => x = XMVectorGetIntByIndex(V, i);

	/// <summary>Retrieve the <c>w</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <returns>The value in the <c>w</c> component of the 4D vector storing integer data <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetintw uint32_t XM_CALLCONV XMVectorGetIntW(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetIntW")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint XMVectorGetIntW(this FXMVECTOR V) => V.uw;

	/// <summary>
	/// Retrieves the <c>w</c> component of an <c>XMVECTOR Data Type</c> containing integer data, and stores that component's value in an
	/// instance of uint32_t referred to by a pointer.
	/// </summary>
	/// <param name="w">
	/// Pointer to a uint32_t that will receive the value of the <c>w</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <returns>None.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetintwptr void XM_CALLCONV
	// XMVectorGetIntWPtr( [out] uint32_t *w, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetIntWPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorGetIntWPtr(ref uint w, in FXMVECTOR V) => w = V.uw;

	/// <summary>Retrieve the <c>x</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <returns>The value in the <c>x</c> component of the 4D vector storing integer data <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetintx uint32_t XM_CALLCONV XMVectorGetIntX(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetIntX")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint XMVectorGetIntX(this FXMVECTOR V) => V.ux;

	/// <summary>
	/// Retrieves the <c>x</c> component of an <c>XMVECTOR Data Type</c> containing integer data, and stores that component's value in an
	/// instance of uint32_t referred to by a pointer.
	/// </summary>
	/// <param name="x">
	/// Pointer to a uint32_t that will receive the value of the <c>x</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <returns>None.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetintxptr void XM_CALLCONV
	// XMVectorGetIntXPtr( [out] uint32_t *x, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetIntXPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorGetIntXPtr(ref uint x, in FXMVECTOR V) => x = V.ux;

	/// <summary>Retrieve the <c>y</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <returns>The value in the <c>y</c> component of the 4D vector storing integer data <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetinty uint32_t XM_CALLCONV XMVectorGetIntY(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetIntY")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint XMVectorGetIntY(this FXMVECTOR V) => V.uy;

	/// <summary>
	/// Retrieves the <c>y</c> component of an <c>XMVECTOR Data Type</c> containing integer data, and stores that component's value in an
	/// instance of uint32_t referred to by a pointer.
	/// </summary>
	/// <param name="y">
	/// Pointer to a uint32_t that will receive the value of the <c>y</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <returns>None.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetintyptr void XM_CALLCONV
	// XMVectorGetIntYPtr( [out] uint32_t *y, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetIntYPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorGetIntYPtr(ref uint y, in FXMVECTOR V) => y = V.uy;

	/// <summary>Retrieve the <c>z</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <returns>The value in the <c>z</c> component of the 4D vector storing integer data <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetintz uint32_t XM_CALLCONV XMVectorGetIntZ(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetIntZ")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint XMVectorGetIntZ(this FXMVECTOR V) => V.uz;

	/// <summary>
	/// Retrieves the <c>z</c> component of an <c>XMVECTOR Data Type</c> containing integer data, and stores that component's value in an
	/// instance of uint32_t referred to by a pointer.
	/// </summary>
	/// <param name="z">
	/// Pointer to a uint32_t that will receive the value of the <c>z</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <returns>None.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetintzptr void XM_CALLCONV
	// XMVectorGetIntZPtr( [out] uint32_t *z, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetIntZPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorGetIntZPtr(ref uint z, in FXMVECTOR V) => z = V.uz;

	/// <summary>Retrieve the <c>w</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D floating-point vector</param>
	/// <returns>The value in the <c>w</c> component of the 4D floating point vector <i>V</i></returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetw float XM_CALLCONV XMVectorGetW( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetW")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float XMVectorGetW(this FXMVECTOR V) => V.w;

	/// <summary>
	/// Retrieve the <c>w</c> component of an <c>XMVECTOR Data Type</c> containing floating-point data, and storing that component's value
	/// in an instance of float referred to by a pointer.
	/// </summary>
	/// <param name="w">
	/// Pointer to a float that will receive the value of the <c>w</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <returns>None.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetwptr void XM_CALLCONV XMVectorGetWPtr(
	// [out] float *w, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetWPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorGetWPtr(ref float w, in FXMVECTOR V) => w = V.w;

	/// <summary>Retrieve the <c>x</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing floating-point data</param>
	/// <returns>The value in the <c>x</c> component of the 4D vector storing floating-point data <i>V</i></returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetx float XM_CALLCONV XMVectorGetX( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetX")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float XMVectorGetX(this FXMVECTOR V) => V.x;

	/// <summary>
	/// Retrieve the <c>x</c> component of an <c>XMVECTOR Data Type</c> containing floating-point data, and storing that component's value
	/// in an instance of float referred to by a pointer.
	/// </summary>
	/// <param name="x">
	/// Pointer to a float that will receive the value of the <c>x</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <returns>None.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetxptr void XM_CALLCONV XMVectorGetXPtr(
	// [out] float *x, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetXPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorGetXPtr(ref float x, in FXMVECTOR V) => x = V.x;

	/// <summary>Retrieve the <c>y</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing floating-point data</param>
	/// <returns>The value in the <c>y</c> component of the 4D vector storing floating-point data <i>V</i></returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgety float XM_CALLCONV XMVectorGetY( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetY")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float XMVectorGetY(this FXMVECTOR V) => V.y;

	/// <summary>
	/// Retrieve the <c>y</c> component of an <c>XMVECTOR Data Type</c> containing floating-point data, and storing that component's value
	/// in an instance of float referred to by a pointer.
	/// </summary>
	/// <param name="y">
	/// Pointer to a float that will receive the value of the <c>y</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <returns>None.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetyptr void XM_CALLCONV XMVectorGetYPtr(
	// [out] float *y, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetYPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorGetYPtr(ref float y, in FXMVECTOR V) => y = V.y;

	/// <summary>Retrieve the <c>z</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing floating-point data</param>
	/// <returns>The value in the <c>z</c> component of the 4D vector storing floating-point data <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetz float XM_CALLCONV XMVectorGetZ( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetZ")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float XMVectorGetZ(this FXMVECTOR V) => V.z;

	/// <summary>
	/// Retrieve the <c>z</c> component of an <c>XMVECTOR Data Type</c> containing floating-point data, and storing that component's value
	/// in an instance of float referred to by a pointer.
	/// </summary>
	/// <param name="z">
	/// Pointer to a float that will receive the value of the <c>z</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <returns>None.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgetzptr void XM_CALLCONV XMVectorGetZPtr(
	// [out] float *z, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGetZPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorGetZPtr(ref float z, in FXMVECTOR V) => z = V.z;

	/// <summary>Performs a per-component test for greater-than between two vectors.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V1.x &gt; V2.x) ? 0xFFFFFFFF : 0; Result.y = (V1.y &gt; V2.y) ? 0xFFFFFFFF : 0; Result.z = (V1.z
	/// &gt; V2.z) ? 0xFFFFFFFF : 0; Result.w = (V1.w &gt; V2.w) ? 0xFFFFFFFF : 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgreater XMVECTOR XM_CALLCONV XMVectorGreater(
	// [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGreater")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorGreater(this FXMVECTOR V1, in FXMVECTOR V2) => Compare(V1, V2, (a, b) => a > b);

	/// <summary>Performs a per-component test for greater-than-or-equal between two vectors.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V1.x &gt;= V2.x) ? 0xFFFFFFFF : 0; Result.y = (V1.y &gt;= V2.y) ? 0xFFFFFFFF : 0; Result.z = (V1.z
	/// &gt;= V2.z) ? 0xFFFFFFFF : 0; Result.w = (V1.w &gt;= V2.w) ? 0xFFFFFFFF : 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgreaterorequal XMVECTOR XM_CALLCONV
	// XMVectorGreaterOrEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGreaterOrEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorGreaterOrEqual(this FXMVECTOR V1, in FXMVECTOR V2) => Compare(V1, V2, (a, b) => a >= b);

	/// <summary>
	/// Performs a per-component test for greater-than-or-equal between two vectors and sets a comparison value that can be examined using
	/// functions such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="pCR">
	/// Pointer to a <b>uint32_t</b> comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>. The
	/// <c>XMComparisonXXXX</c> functions may be used to further test the number of components that passed the comparison.
	/// </param>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks></remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgreaterorequalr XMVECTOR XM_CALLCONV
	// XMVectorGreaterOrEqualR( [out] uint32_t *pCR, [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGreaterOrEqualR")]
	public static XMVECTOR XMVectorGreaterOrEqualR(out uint pCR, in FXMVECTOR V1, in FXMVECTOR V2)
	{
		var u = XMVectorGreaterOrEqual(V1, V2);
		if ((u.ux & u.uy & u.uz & u.uw) != 0)
			pCR = XM_CRMASK_CR6TRUE;
		else pCR = (u.ux | u.uy | u.uz | u.uw) == 0 ? XM_CRMASK_CR6FALSE : 0;
		return u;
	}

	/// <summary>
	/// Performs a per-component test for greater-than between two vectors and sets a comparison value that can be examined using functions
	/// such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="pCR">
	/// Pointer to a <b>uint32_t</b> comparison value that can be examined using functions such as <c>XMComparisonAllTrue</c>. The
	/// <c>XMComparisonXXXX</c> functions may be used to further test the number of components that passed the comparison.
	/// </param>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorgreaterr XMVECTOR XM_CALLCONV
	// XMVectorGreaterR( [out] uint32_t *pCR, [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorGreaterR")]
	public static XMVECTOR XMVectorGreaterR(out uint pCR, in FXMVECTOR V1, in FXMVECTOR V2)
	{
		var u = XMVectorGreater(V1, V2);
		if ((u.ux & u.uy & u.uz & u.uw) != 0)
			pCR = XM_CRMASK_CR6TRUE;
		else pCR = (u.ux | u.uy | u.uz | u.uw) == 0 ? XM_CRMASK_CR6FALSE : 0;
		return u;
	}

	/// <summary>Performs a Hermite spline interpolation, using the specified vectors.</summary>
	/// <param name="Position0">First position to interpolate from.</param>
	/// <param name="Tangent0">Tangent vector for the first position.</param>
	/// <param name="Position1">Second position to interpolate from.</param>
	/// <param name="Tangent1">Tangent vector for the second position.</param>
	/// <param name="t">Interpolation control factor.</param>
	/// <returns>Returns a vector containing the interpolation.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; float t2 = t * t; float t3 = t2* t; float P0 = 2.0f * t3 - 3.0f * t2 + 1.0f; float T0 = t3 - 2.0f * t2 + t;
	/// float P1 = -2.0f * t3 + 3.0f * t2; float T1 = t3 - t2; Result.x = P0 * Position0.x + T0 * Tangent0.x + P1 * Position1.x + T1 *
	/// Tangent1.x; Result.y = P0 * Position0.y + T0 * Tangent0.y + P1 * Position1.y + T1 * Tangent1.y; Result.z = P0 * Position0.z + T0 *
	/// Tangent0.z + P1 * Position1.z + T1 * Tangent1.z; Result.w = P0 * Position0.w + T0 * Tangent0.w + P1 * Position1.w + T1 * Tangent1.w;
	/// return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorhermite XMVECTOR XM_CALLCONV XMVectorHermite(
	// [in] FXMVECTOR Position0, [in] FXMVECTOR Tangent0, [in] FXMVECTOR Position1, [in] GXMVECTOR Tangent1, [in] float t ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorHermite")]
	public static XMVECTOR XMVectorHermite(this FXMVECTOR Position0, in FXMVECTOR Tangent0, in FXMVECTOR Position1, GXMVECTOR Tangent1, float t)
	{
		float t2 = t * t;
		float t3 = t * t2;

		XMVECTOR P0 = XMVectorReplicate(2.0f * t3 - 3.0f * t2 + 1.0f);
		XMVECTOR T0 = XMVectorReplicate(t3 - 2.0f * t2 + t);
		XMVECTOR P1 = XMVectorReplicate(-2.0f * t3 + 3.0f * t2);
		XMVECTOR T1 = XMVectorReplicate(t3 - t2);

		XMVECTOR Result = XMVectorMultiply(P0, Position0);
		Result = XMVectorMultiplyAdd(T0, Tangent0, Result);
		Result = XMVectorMultiplyAdd(P1, Position1, Result);
		return XMVectorMultiplyAdd(T1, Tangent1, Result);
	}

	/// <summary>Performs a Hermite spline interpolation, using the specified vectors.</summary>
	/// <param name="Position0">First position to interpolate from.</param>
	/// <param name="Tangent0">Tangent vector for the first position.</param>
	/// <param name="Position1">Second position to interpolate from.</param>
	/// <param name="Tangent1">Tangent vector for the second position.</param>
	/// <param name="T">Interpolating control factor with each component corresponding to a term of the Hermite equation.</param>
	/// <returns>Returns a vector containing the interpolation.</returns>
	/// <remarks>
	/// <para>
	/// This function is identical to <c>XMVectorHermite</c> except that independent weighting factors may be supplied in <i>T</i>. As an
	/// example, you might want to calculate two sets of Hermite spline interpolation, using the x and y-components of the position vectors
	/// for one set of 2D positions and the z and w-components of the position vectors for the other set of 2D positions. The x and
	/// y-components of <i>T</i> would determine the interpolation factors for the first Hermite spline interpolation. Similarly, the z and
	/// w-components of <i>T</i> would determine the interpolation factors for the second Hermite spline interpolation.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>Result[i] = (2*(T.x)^3 - 3*(T.x)^2 + 1) * Position0.[i] + ((T.y)^3 - 2*(T.y)^2 + (T.y)) * Tangent0.[i] + (-2*(T.z)^3 + 3*(T.z)^2)
	/// * Position1.[i] + ((T.w)^3 - *(T.w)^2) * Tangent1.[i]</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorhermitev XMVECTOR XM_CALLCONV
	// XMVectorHermiteV( [in] FXMVECTOR Position0, [in] FXMVECTOR Tangent0, [in] FXMVECTOR Position1, [in] GXMVECTOR Tangent1, [in]
	// HXMVECTOR T ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorHermiteV")]
	public static XMVECTOR XMVectorHermiteV(this FXMVECTOR Position0, in FXMVECTOR Tangent0, in FXMVECTOR Position1, GXMVECTOR Tangent1, HXMVECTOR T)
	{
		XMVECTOR T2 = XMVectorMultiply(T, T);
		XMVECTOR T3 = XMVectorMultiply(T, T2);

		XMVECTOR P0 = XMVectorReplicate(2.0f * T3.x - 3.0f * T2.x + 1.0f);
		XMVECTOR T0 = XMVectorReplicate(T3.y - 2.0f * T2.y + T.y);
		XMVECTOR P1 = XMVectorReplicate(-2.0f * T3.z + 3.0f * T2.z);
		XMVECTOR T1 = XMVectorReplicate(T3.w - T2.w);

		XMVECTOR Result = XMVectorMultiply(P0, Position0);
		Result = XMVectorMultiplyAdd(T0, Tangent0, Result);
		Result = XMVectorMultiplyAdd(P1, Position1, Result);
		return XMVectorMultiplyAdd(T1, Tangent1, Result);
	}

	/// <summary>Tests whether the components of a given vector are within set bounds.</summary>
	/// <param name="V">Vector to test.</param>
	/// <param name="Bounds">Vector that determines the bounds.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Control; Control.x = (V.x &lt;= Bounds.x &amp;&amp; V.x &gt;= -Bounds.x) ? 0xFFFFFFFF : 0; Control.y = (V.y &lt;=
	/// Bounds.y &amp;&amp; V.y &gt;= -Bounds.y) ? 0xFFFFFFFF : 0; Control.z = (V.z &lt;= Bounds.z &amp;&amp; V.z &gt;= -Bounds.z) ?
	/// 0xFFFFFFFF : 0; Control.w = (V.w &lt;= Bounds.w &amp;&amp; V.w &gt;= -Bounds.w) ? 0xFFFFFFFF : 0; return Control;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorinbounds XMVECTOR XM_CALLCONV
	// XMVectorInBounds( [in] FXMVECTOR V, [in] FXMVECTOR Bounds ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorInBounds")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorInBounds(this FXMVECTOR V, in FXMVECTOR Bounds) =>
		Compare(V, Bounds, (a, b) => a <= b && a >= -b);

	/// <summary>
	/// Tests whether the components of a given vector are within certain bounds and sets a comparison value that can be examined using
	/// functions such as <c>XMComparisonAllTrue</c>.
	/// </summary>
	/// <param name="pCR">
	/// Pointer to a <b>uint32_t</b> comparison value that can be examined using functions such as <c>XMComparisonAllInBounds</c>. The
	/// <c>XMComparisonXXXX</c> functions may be used to further test the number of components that passed the comparison.
	/// </param>
	/// <param name="V">Vector to test.</param>
	/// <param name="Bounds">Vector that determines the bounds.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the comparison operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Control; Control.x = (V.x &lt;= Bounds.x &amp;&amp; V.x &gt;= -Bounds.x) ? 0xFFFFFFFF : 0; Control.y = (V.y &lt;=
	/// Bounds.y &amp;&amp; V.y &gt;= -Bounds.y) ? 0xFFFFFFFF : 0; Control.z = (V.z &lt;= Bounds.z &amp;&amp; V.z &gt;= -Bounds.z) ?
	/// 0xFFFFFFFF : 0; Control.w = (V.w &lt;= Bounds.w &amp;&amp; V.w &gt;= -Bounds.w) ? 0xFFFFFFFF : 0; return Control;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorinboundsr XMVECTOR XM_CALLCONV
	// XMVectorInBoundsR( [out] uint32_t *pCR, [in] FXMVECTOR V, [in] FXMVECTOR Bounds ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorInBoundsR")]
	public static XMVECTOR XMVectorInBoundsR(out uint pCR, in FXMVECTOR V, in FXMVECTOR Bounds)
	{
		var u = XMVectorInBounds(V, Bounds);
		if ((u.ux & u.uy & u.uz & u.uw) != 0)
			pCR = XM_CRMASK_CR6TRUE;
		else pCR = (u.ux | u.uy | u.uz | u.uw) == 0 ? XM_CRMASK_CR6FALSE : 0;
		return u;
	}

	/// <summary>
	/// Rotates a vector left by a given number of 32-bit components and insert selected elements of that result into another vector.
	/// </summary>
	/// <param name="VD">Vector to insert into.</param>
	/// <param name="VS">Vector to rotate left.</param>
	/// <param name="VSLeftRotateElements">Number of 32-bit components by which to rotate <i>VS</i> left.</param>
	/// <param name="Select0">
	/// Either 0 or 1. If one, the x-component of the rotated vector will be inserted into the corresponding component of <i>VD</i>.
	/// Otherwise, the x-component of <i>VD</i> is left alone.
	/// </param>
	/// <param name="Select1">
	/// Either 0 or 1. If one, the y-component of the rotated vector will be inserted into the corresponding component of <i>VD</i>.
	/// Otherwise, the y-component of <i>VD</i> is left alone.
	/// </param>
	/// <param name="Select2">
	/// Either 0 or 1. If one, the z-component of the rotated vector will be inserted into the corresponding component of <i>VD</i>.
	/// Otherwise, the z-component of <i>VD</i> is left alone.
	/// </param>
	/// <param name="Select3">
	/// Either 0 or 1. If one, the w-component of the rotated vector will be inserted into the corresponding component of <i>VD</i>.
	/// Otherwise, the w-component of <i>VD</i> is left alone.
	/// </param>
	/// <returns>Returns the <c>XMVECTOR</c> that results from the rotation and insertion.</returns>
	/// <remarks>
	/// <para>For best performance, the result of <b>XMVectorInsert</b> should be assigned back to <i>VD</i>.</para>
	/// <para>For cases with constant uint32_t parameters, it is more efficient to use the template form of <c>XMVectorInsert</c>:</para>
	/// <para>
	/// <c>template&lt;uint32_t VSLeftRotateElements, uint32_t Select0, uint32_t Select1, uint32_t Select2, uint32_t Select3&gt; XMVECTOR
	/// XMVectorInsert(this FXMVECTOR VD, FXMVECTOR VS)</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorinsert XMVECTOR XM_CALLCONV XMVectorInsert(
	// [in] FXMVECTOR VD, [in] FXMVECTOR VS, [in] uint32_t VSLeftRotateElements, [in] uint32_t Select0, [in] uint32_t Select1, [in] uint32_t
	// Select2, [in] uint32_t Select3 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorInsert")]
	public static XMVECTOR XMVectorInsert(this FXMVECTOR VD, in FXMVECTOR VS, uint VSLeftRotateElements, uint Select0, uint Select1, uint Select2, uint Select3)
	{
		XMVECTOR Control = XMVectorSelectControl(Select0 & 1, Select1 & 1, Select2 & 1, Select3 & 1);
		return XMVectorSelect(VD, XMVectorRotateLeft(VS, VSLeftRotateElements), Control);
	}

	/// <summary>Performs a per-component test for +/- infinity on a vector.</summary>
	/// <param name="V">Vector to test.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V.x == +infinity || V.x == -infinity) ? 0xFFFFFFFF : 0; Result.y = (V.y == +infinity || V.y ==
	/// -infinity) ? 0xFFFFFFFF : 0; Result.z = (V.z == +infinity || V.z == -infinity) ? 0xFFFFFFFF : 0; Result.w = (V.w == +infinity || V.w
	/// == -infinity) ? 0xFFFFFFFF : 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorisinfinite XMVECTOR XM_CALLCONV
	// XMVectorIsInfinite( [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorIsInfinite")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorIsInfinite(this FXMVECTOR V) => Compare(V, default, (a, b) => XMISINF(a));

	/// <summary>Performs a per-component NaN test on a vector.</summary>
	/// <param name="V">Vector to test.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V.x == SNaN || V.x == QNaN) ? 0xFFFFFFFF : 0; Result.y = (V.y == SNaN || V.y == QNaN) ? 0xFFFFFFFF :
	/// 0; Result.z = (V.z == SNaN || V.z == QNaN) ? 0xFFFFFFFF : 0; Result.w = (V.w == SNaN || V.w == QNaN) ? 0xFFFFFFFF : 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorisnan XMVECTOR XM_CALLCONV XMVectorIsNaN( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorIsNaN")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorIsNaN(this FXMVECTOR V) => Compare(V, default, (a, b) => XMISNAN(a));

	/// <summary>Performs a linear interpolation between two vectors.</summary>
	/// <param name="V0">First vector to interpolate from.</param>
	/// <param name="V1">Second vector to interpolate from.</param>
	/// <param name="t">Interpolation control factor.</param>
	/// <returns>Returns a vector containing the interpolation.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = V0.x + t * (V1.x - V0.x); Result.y = V0.y + t * (V1.y - V0.y); Result.z = V0.z + t * (V1.z - V0.z);
	/// Result.w = V0.w + t * (V1.w - V0.w); return Result;</c>
	/// </para>
	/// <para>Note it is fairly simple to use this function for doing a cubic interpolation instead of a linear interpolation as follows:</para>
	/// <para>
	/// <c>XMVECTOR SmoothStep( XMVECTOR V0, XMVECTOR V1, float t ) { t = (t &gt; 1.0f) ? 1.0f : ((t &lt; 0.0f) ? 0.0f : t); // Clamp value
	/// to 0 to 1 t = t*t*(3.f - 2.f*t); return XMVectorLerp( V0, V1, t ); }</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorlerp XMVECTOR XM_CALLCONV XMVectorLerp( [in]
	// FXMVECTOR V0, [in] FXMVECTOR V1, [in] float t ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorLerp")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorLerp(this FXMVECTOR V0, in FXMVECTOR V1, float t) => V0.BinaryOp(V1, (a, b) => a + t * (b - a));

	/// <summary>Performs a linear interpolation between two vectors.</summary>
	/// <param name="V0">First vector to interpolate from.</param>
	/// <param name="V1">Second vector to interpolate from.</param>
	/// <param name="T">Interpolating control factor for the corresponding components of the position.</param>
	/// <returns>Returns a vector containing the interpolation.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = V0.x + T.x * (V1.x - V0.x); Result.y = V0.y + T.y * (V1.y - V0.y); Result.z = V0.z + T.z * (V1.z -
	/// V0.z); Result.w = V0.w + T.w * (V1.w - V0.w); return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorlerpv XMVECTOR XM_CALLCONV XMVectorLerpV( [in]
	// FXMVECTOR V0, [in] FXMVECTOR V1, [in] FXMVECTOR T ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorLerpV")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorLerpV(this FXMVECTOR V0, in FXMVECTOR V1, in FXMVECTOR T) => V0 + T * (V1 - V0);

	/// <summary>Performs a per-component test for less-than between two vectors.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V1.x &lt; V2.x) ? 0xFFFFFFFF : 0; Result.y = (V1.y &lt; V2.y) ? 0xFFFFFFFF : 0; Result.z = (V1.z
	/// &lt; V2.z) ? 0xFFFFFFFF : 0; Result.w = (V1.w &lt; V2.w) ? 0xFFFFFFFF : 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorless XMVECTOR XM_CALLCONV XMVectorLess( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorLess")]
	public static XMVECTOR XMVectorLess(this FXMVECTOR V1, in FXMVECTOR V2) =>
		Compare(V1, V2, (a, b) => a < b);

	/// <summary>Performs a per-component test for less-than-or-equal between two vectors.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V1.x &lt;= V2.x) ? 0xFFFFFFFF : 0; Result.y = (V1.y &lt;= V2.y) ? 0xFFFFFFFF : 0; Result.z = (V1.z
	/// &lt;= V2.z) ? 0xFFFFFFFF : 0; Result.w = (V1.w &lt;= V2.w) ? 0xFFFFFFFF : 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorlessorequal XMVECTOR XM_CALLCONV
	// XMVectorLessOrEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorLessOrEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorLessOrEqual(this FXMVECTOR V1, in FXMVECTOR V2) => Compare(V1, V2, (a, b) => a <= b);

	/// <summary>
	/// <para>Computes the base two logarithm of each component of a vector.</para>
	/// <para>
	/// <b>Note</b>  This function is a compatibility alias for <c>XMVectorLog2</c> for existing Windows 8 code. This function is deprecated
	/// for Windows 8.1. Don't use it and instead use <b>XMVectorLog2</b> or <c>XMVectorLogE</c>.
	/// <para></para>
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="V">Vector for which to compute the base two logarithm.</param>
	/// <returns>Returns a vector whose components are base two logarithm of the corresponding components of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorlog XMVECTOR XM_CALLCONV XMVectorLog( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorLog")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorLog(this FXMVECTOR V) => XMVectorLog2(V);

	/// <summary>Computes the base ten logarithm of each component of a vector.</summary>
	/// <param name="V">Vector for which to compute the base ten logarithm.</param>
	/// <returns>Returns a vector whose components are base ten logarithm of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <para>This function was added in DirectXMath 3.16</para>
	/// </para>
	/// <para><b>XMVectorLog10</b> is implemented like this:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = log10f(V.x); Result.y = log10f(V.y); Result.z = log10f(V.z); Result.w = log10f(V.w); return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorlog10 XMVECTOR XM_CALLCONV XMVectorLog10( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorLog10")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorLog10(this FXMVECTOR V) => V.UnaryOp(Math.Log10);

	/// <summary>Computes the base two logarithm of each component of a vector.</summary>
	/// <param name="V">Vector for which to compute the base two logarithm.</param>
	/// <returns>Returns a vector whose components are base two logarithm of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <b>XMVectorLog2</b> is new for DirectXMath version 3.05, but it's just a renamed version of the existing <c>XMVectorLog</c> function
	/// for Windows 8.
	/// </para>
	/// <para><b>XMVectorLog2</b> is implemented like this:</para>
	/// <para><c>XMVECTOR Result; Result.x = log2f(V.x); Result.y = log2f(V.y); Result.z = log2f(V.z); Result.w = log2f(V.w); return Result;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorlog2 XMVECTOR XM_CALLCONV XMVectorLog2( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorLog2")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorLog2(this FXMVECTOR V) => V.UnaryOp(f => (float)Math.Log(f) * 1.4426950f /*(1.0f / logf(2.0f))*/);

	/// <summary>Computes the base e logarithm of each component of a vector.The base e logarithm is also known as the natural logarithm.</summary>
	/// <param name="V">Vector for which to compute the base e logarithm.</param>
	/// <returns>Returns a vector whose components are base e logarithm of the corresponding components of <i>V</i>.</returns>
	/// <remarks>
	/// <para><b>XMVectorLogE</b> is new for DirectXMath version 3.05.</para>
	/// <para>It's similar to the existing <c>XMVectorLog</c> function for Windows 8, but computes base e instead of base 2.</para>
	/// <para><b>XMVectorLogE</b> is implemented like this:</para>
	/// <para><c>XMVECTOR Result; Result.x = logf(V.x); Result.y = logf(V.y); Result.z = logf(V.z); Result.w = logf(V.w); return Result;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorloge XMVECTOR XM_CALLCONV XMVectorLogE( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorLogE")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorLogE(this FXMVECTOR V) => V.UnaryOp(Math.Log);

	/// <summary>Makes a per-component comparison between two vectors, and returns a vector containing the largest components.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the largest components between the two vectors.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V1.x &gt; V2.x) ? V1.x : V2.x; Result.y = (V1.y &gt; V2.y) ? V1.y : V2.y; Result.z = (V1.z &gt;
	/// V2.z) ? V1.z : V2.z; Result.w = (V1.w &gt; V2.w) ? V1.w : V2.w; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectormax XMVECTOR XM_CALLCONV XMVectorMax( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorMax")]
	public static XMVECTOR XMVectorMax(this FXMVECTOR V1, in FXMVECTOR V2) =>
		V1.BinaryOp(V2, Math.Max);

	/// <summary>Creates a new vector by combining the x and y-components of two vectors.</summary>
	/// <param name="V1">First vector.</param>
	/// <param name="V2">Second vector.</param>
	/// <returns>Returns the merged vector.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>XMVECTOR Result; Result.x = V1.x; Result.y = V2.x; Result.z = V1.y; Result.w = V2.y; return Result;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectormergexy XMVECTOR XM_CALLCONV XMVectorMergeXY(
	// [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorMergeXY")]
	public static XMVECTOR XMVectorMergeXY(this FXMVECTOR V1, in FXMVECTOR V2)
	{ unsafe { return new(V1.x, V2.x, V1.y, V2.y); } }

	/// <summary>Creates a new vector by combining the z and w-components of two vectors.</summary>
	/// <param name="V1">First vector.</param>
	/// <param name="V2">Second vector.</param>
	/// <returns>Returns the merged vector.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>XMVECTOR Result; Result.x = V1.z; Result.y = V2.z; Result.z = V1.w; Result.w = V2.w; return Result;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectormergezw XMVECTOR XM_CALLCONV XMVectorMergeZW(
	// [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorMergeZW")]
	public static XMVECTOR XMVectorMergeZW(this FXMVECTOR V1, in FXMVECTOR V2)
	{ unsafe { return new(V1.z, V2.z, V1.w, V2.w); } }

	/// <summary>Makes a per-component comparison between two vectors, and returns a vector containing the smallest components.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the smallest components between the two vectors.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V1.x &lt; V2.x) ? V1.x : V2.x; Result.y = (V1.y &lt; V2.y) ? V1.y : V2.y; Result.z = (V1.z &lt;
	/// V2.z) ? V1.z : V2.z; Result.w = (V1.w &lt; V2.w) ? V1.w : V2.w; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectormin XMVECTOR XM_CALLCONV XMVectorMin( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorMin")]
	public static XMVECTOR XMVectorMin(this FXMVECTOR V1, in FXMVECTOR V2) =>
		V1.BinaryOp(V2, Math.Min);

	/// <summary>Computes the per-component floating-point remainder of the quotient of two vectors.</summary>
	/// <param name="V1">Vector dividend.</param>
	/// <param name="V2">Vector divisor.</param>
	/// <returns>Returns a vector whose components are the floating-point remainders of the divisions.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = fmod(V1.x, V2.x); Result.y = fmod(V1.y, V2.y); Result.z = fmod(V1.z, V2.z); Result.w = fmod(V1.w,
	/// V2.w); return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectormod XMVECTOR XM_CALLCONV XMVectorMod( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorMod")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorMod(this FXMVECTOR V1, in FXMVECTOR V2) => V1.BinaryOp(V2, (a, b) => a % b);

	/// <summary>Computes the per-component angle modulo 2PI.</summary>
	/// <param name="Angles">Vector of angle components.</param>
	/// <returns>Returns a vector whose components are the corresponding components of <i>Angles</i> modulo 2PI.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR result; result.x = Angles.x - XM_2PI * round( Angles.x / XM_2PI ); result.y = Angles.y - XM_2PI * round( Angles.y /
	/// XM_2PI ); result.z = Angles.z - XM_2PI * round( Angles.z / XM_2PI ); result.w = Angles.w - XM_2PI * round( Angles.w / XM_2PI );
	/// return result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectormodangles XMVECTOR XM_CALLCONV
	// XMVectorModAngles( [in] FXMVECTOR Angles ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorModAngles")]
	public static XMVECTOR XMVectorModAngles(this FXMVECTOR Angles) =>
		Angles - XMVECTOR.g_XMTwoPi * XMVectorRound(Angles * XMVECTOR.g_XMReciprocalTwoPi);

	/// <summary>Computes the per-component product of two vectors.</summary>
	/// <param name="V1">First vector to multiply.</param>
	/// <param name="V2">Second vector to multiply.</param>
	/// <returns>Returns a vector, each of whose components is the product of the corresponding components of <i>V1</i> and <i>V2</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectormultiply XMVECTOR XM_CALLCONV
	// XMVectorMultiply( [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorMultiply")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorMultiply(this FXMVECTOR V1, in FXMVECTOR V2) => V2.BinaryOp(V2, (a, b) => a * b);

	/// <summary>Computes the product of the first two vectors added to the third vector.</summary>
	/// <param name="V1">Vector multiplier.</param>
	/// <param name="V2">Vector multiplicand.</param>
	/// <param name="V3">Vector addend.</param>
	/// <returns>Returns the product-sum of the vectors.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = V1.x * V2.x + V3.x; Result.y = V1.y * V2.y+ V3.y; Result.z = V1.z * V2.z+ V3.z; Result.w = V1.w *
	/// V2.w+ V3.w; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectormultiplyadd XMVECTOR XM_CALLCONV
	// XMVectorMultiplyAdd( [in] FXMVECTOR V1, [in] FXMVECTOR V2, [in] FXMVECTOR V3 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorMultiplyAdd")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorMultiplyAdd(this FXMVECTOR V1, in FXMVECTOR V2, in FXMVECTOR V3) => XMVectorAdd(XMVectorMultiply(V1, V2), V3);

	/// <summary>Performs a per-component test for equality of two vectors within a given threshold.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector compare.</param>
	/// <param name="Epsilon">Tolerance value used for judging equality.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (abs(V1.x - V2.x) &lt;= Epsilon) ? 0xFFFFFFFF : 0; Result.y = (abs(V1.y - V2.y) &lt;= Epsilon) ?
	/// 0xFFFFFFFF : 0; Result.z = (abs(V1.z - V2.z) &lt;= Epsilon) ? 0xFFFFFFFF : 0; Result.w = (abs(V1.w - V2.w) &lt;= Epsilon) ?
	/// 0xFFFFFFFF : 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectornearequal XMVECTOR XM_CALLCONV
	// XMVectorNearEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2, [in] FXMVECTOR Epsilon ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorNearEqual")]
	public static XMVECTOR XMVectorNearEqual(this FXMVECTOR V1, in FXMVECTOR V2, in FXMVECTOR Epsilon)
	{
		XMVECTOR fDelta = new(Math.Abs(V1.x - V2.x), Math.Abs(V1.y - V2.y),
			Math.Abs(V1.z - V2.z), Math.Abs(V1.w - V2.w));

		return XMVectorLessOrEqual(fDelta, Epsilon);
	}

	/// <summary>Computes the negation of a vector.</summary>
	/// <param name="V">Vector to negate.</param>
	/// <returns>Returns the negation of the vector.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>XMVECTOR result; result.x = -V.x; result.y = -V.y; result.z = -V.z; result.w = -V.w; return result;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectornegate XMVECTOR XM_CALLCONV XMVectorNegate(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorNegate")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorNegate(this FXMVECTOR V) => V.UnaryOp(f => -f);

	/// <summary>Computes the difference of a third vector and the product of the first two vectors.</summary>
	/// <param name="V1">Vector multiplier.</param>
	/// <param name="V2">Vector multiplicand.</param>
	/// <param name="V3">Vector subtrahend.</param>
	/// <returns>Returns the resulting vector. See the remarks.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR result; result.x = V3.x - V1.x * V2.x; result.y = V3.y - V1.y * V2.y; result.z = V3.z - V1.z * V2.z; result.w = V3.w -
	/// V1.w * V2.w; return result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectornegativemultiplysubtract XMVECTOR XM_CALLCONV
	// XMVectorNegativeMultiplySubtract( [in] FXMVECTOR V1, [in] FXMVECTOR V2, [in] FXMVECTOR V3 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorNegativeMultiplySubtract")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorNegativeMultiplySubtract(this FXMVECTOR V1, in FXMVECTOR V2, in FXMVECTOR V3) => XMVectorSubtract(V3, XMVectorMultiply(V1, V2));

	/// <summary>Computes the logical NOR of two vectors, treating each component as an unsigned integer.</summary>
	/// <param name="V1">First vector.</param>
	/// <param name="V2">Second vector.</param>
	/// <returns>Returns a vector, each of whose components are the logical NOR of the corresponding components of <i>V1</i> and <i>V2</i>.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = ~(V1.x | V2.x); Result.y = ~(V1.y | V2.y); Result.z = ~(V1.z | V2.z); Result.w = ~(V1.w | V2.w);
	/// return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectornorint XMVECTOR XM_CALLCONV XMVectorNorInt(
	// [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorNorInt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorNorInt(this FXMVECTOR V1, in FXMVECTOR V2) => V1.BinaryIntOp(V2, (u1, u2) => ~(u1 | u2));

	/// <summary>Performs a per-component test for the inequality of two vectors.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = (V1.x != V2.x) ? 0xFFFFFFFF : 0; Result.y = (V1.y != V2.y) ? 0xFFFFFFFF : 0; Result.z = (V1.z !=
	/// V2.z) ? 0xFFFFFFFF : 0; Result.w = (V1.w != V2.w) ? 0xFFFFFFFF : 0; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectornotequal XMVECTOR XM_CALLCONV
	// XMVectorNotEqual( [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorNotEqual")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorNotEqual(this FXMVECTOR V1, in FXMVECTOR V2) => Compare(V1, V2, (a, b) => a != b);

	/// <summary>Performs a per-component test for the inequality of two vectors, treating each component as an unsigned integer.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <returns>Returns a vector containing the results of each component test.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Control; Control.x = (V1.x != V2.x) ? 0xFFFFFFFF : 0; Control.y = (V1.y != V2.y) ? 0xFFFFFFFF : 0; Control.z = (V1.z !=
	/// V2.z) ? 0xFFFFFFFF : 0; Control.w = (V1.w != V2.w) ? 0xFFFFFFFF : 0; return Control;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectornotequalint XMVECTOR XM_CALLCONV
	// XMVectorNotEqualInt( [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorNotEqualInt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorNotEqualInt(this FXMVECTOR V1, in FXMVECTOR V2) => CompareU(V1, V2, (a, b) => a != b);

	/// <summary>Computes the logical OR of two vectors, treating each component as an unsigned integer.</summary>
	/// <param name="V1">First vector.</param>
	/// <param name="V2">Second vector.</param>
	/// <returns>Returns a vector, each of whose components are the logical OR of the corresponding components of <i>V1</i> and <i>V2</i>.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = V1.x | V2.x; Result.y = V1.y | V2.y; Result.z = V1.z | V2.z; Result.w = V1.w | V2.w; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectororint XMVECTOR XM_CALLCONV XMVectorOrInt( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorOrInt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorOrInt(this FXMVECTOR V1, in FXMVECTOR V2) => V1.BinaryIntOp(V2, (u1, u2) => u1 | u2);

	/// <summary>Permutes the components of two vectors to create a new vector.</summary>
	/// <param name="V1">First vector.</param>
	/// <param name="V2">Second vector.</param>
	/// <param name="PermuteX">Index form 0-7 indicating where the X component of the new vector should be copied from.</param>
	/// <param name="PermuteY">Index form 0-7 indicating where the Y component of the new vector should be copied from.</param>
	/// <param name="PermuteZ">Index form 0-7 indicating where the Z component of the new vector should be copied from.</param>
	/// <param name="PermuteW">Index form 0-7 indicating where the W component of the new vector should be copied from.</param>
	/// <returns>Returns the permuted vector that resulted from combining the source vectors.</returns>
	/// <remarks>
	/// <para>
	/// If all 4 indices reference only a single vector (i.e. they are all in the range 0-3 or all in the range 4-7), use
	/// <c>XMVectorSwizzle</c> instead for better performance.
	/// </para>
	/// <para>
	/// The <c>XM_PERMUTE_</c> constants are provided to use as input values for <i>PermuteX</i>, <i>PermuteY</i>, <i>PermuteZ</i>, and <i>PermuteW</i>.
	/// </para>
	/// <para>For constant PermuteX/Y/Z/W parameters, it is much more efficient to use the template form of <c>XMVectorPermute</c>:</para>
	/// <para>
	/// <c>template&lt;uint32_t PermuteX, uint32_t PermuteY, uint32_t PermuteZ, uint32_t PermuteW&gt; XMVECTOR XMVectorPermute(FXMVECTOR V1,
	/// FXMVECTOR V2) Example: XMVectorPermute&lt;XM_PERMUTE_0Z, XM_PERMUTE_1X, XM_PERMUTE_0W, XM_PERMUTE_1Y&gt;( V1, V2 );</c>
	/// </para>
	/// <para>
	/// <b>Note</b>  This version of <c>XMVectorPermute</c> is new for DirectXMath. The XNAMath v2.x library made use of
	/// <c>XMVectorPermuteControl</c>, a control <c>XMVECTOR</c> instead of 4 indices for <c>XMVectorPermute</c>, and used different values
	/// for the XM_PERMUTE_x constants.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorpermute XMVECTOR XM_CALLCONV XMVectorPermute(
	// [in] FXMVECTOR V1, [in] FXMVECTOR V2, uint32_t PermuteX, uint32_t PermuteY, uint32_t PermuteZ, uint32_t PermuteW ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorPermute")]
	public static XMVECTOR XMVectorPermute(this FXMVECTOR V1, in FXMVECTOR V2, uint PermuteX, uint PermuteY, uint PermuteZ, uint PermuteW)
	{
		if (PermuteX > 7 || PermuteY > 7 || PermuteZ > 7 || PermuteW > 7)
			throw new ArgumentOutOfRangeException("PermuteX-W", "Permute element must be between 0 and 7.");

		XMVECTOR Result = new();
		unsafe
		{
			uint i0 = PermuteX & 3;
			uint vi0 = PermuteX >> 2;
			Result.ux = vi0 == 0 ? V1.u[i0] : V2.u[i0];

			uint i1 = PermuteY & 3;
			uint vi1 = PermuteY >> 2;
			Result.uy = vi1 == 0 ? V1.u[i1] : V2.u[i1];

			uint i2 = PermuteZ & 3;
			uint vi2 = PermuteZ >> 2;
			Result.uz = vi2 == 0 ? V1.u[i2] : V2.u[i2];

			uint i3 = PermuteW & 3;
			uint vi3 = PermuteW >> 2;
			Result.uw = vi3 == 0 ? V1.u[i3] : V2.u[i3];
		}
		return Result;
	}

	/// <summary>Computes <i>V1</i> raised to the power of <i>V2</i>.</summary>
	/// <param name="V1">First vector.</param>
	/// <param name="V2">Second vector.</param>
	/// <returns>
	/// Returns a vector. Each component is the corresponding component of <i>V1</i> raised to the power of the corresponding component in <i>V2</i>.
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = pow(V1.x, V2.x); Result.y = pow(V1.y, V2.y); Result.z = pow(V1.z, V2.z); Result.w = pow(V1.w, V2.w);
	/// return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorpow XMVECTOR XM_CALLCONV XMVectorPow( [in]
	// FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorPow")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorPow(this FXMVECTOR V1, in FXMVECTOR V2) => V1.BinaryOp(V2, (a, b) => (float)Math.Pow(a, b));

	/// <summary>Computes the per-component reciprocal of a vector.</summary>
	/// <param name="V">Vector whose reciprocal is computed.</param>
	/// <returns>Returns a vector. Each component is the reciprocal of the corresponding component of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorreciprocal XMVECTOR XM_CALLCONV
	// XMVectorReciprocal( [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorReciprocal")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorReciprocal(this FXMVECTOR V) => V.UnaryOp(f => 1f / f);

	/// <summary>Estimates the per-component reciprocal of a vector.</summary>
	/// <param name="V">Vector whose reciprocal is estimated.</param>
	/// <returns>Returns a vector. Each component is an estimate of the reciprocal of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorreciprocalest XMVECTOR XM_CALLCONV
	// XMVectorReciprocalEst( [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorReciprocalEst")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorReciprocalEst(this FXMVECTOR V) => V.UnaryOp(f => 1f / f);

	/// <summary>Computes the per-component reciprocal square root of a vector.</summary>
	/// <param name="V">Vector whose reciprocal square root is computed.</param>
	/// <returns>Returns a vector. Each component is the reciprocal square-root of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>The reciprocal square-root operation handles special input values as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Input Value</description>
	/// <description>Return Value</description>
	/// </listheader>
	/// <item>
	/// <description>+Infinity</description>
	/// <description>0*</description>
	/// </item>
	/// <item>
	/// <description>+0.0f</description>
	/// <description>+Infinity*</description>
	/// </item>
	/// <item>
	/// <description>-0.0f</description>
	/// <description>-Infinity*</description>
	/// </item>
	/// <item>
	/// <description>&lt; 0.0f</description>
	/// <description>QNaN</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <list type="bullet">
	/// <item>
	/// <description>Note that due to implementation details, VMX128 returns QNaN in all special cases.</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorreciprocalsqrt XMVECTOR XM_CALLCONV
	// XMVectorReciprocalSqrt( [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorReciprocalSqrt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorReciprocalSqrt(this FXMVECTOR V) => V.UnaryOp(f => 1f / (float)Math.Sqrt(f));

	/// <summary>Estimates the per-component reciprocal square root of a vector.</summary>
	/// <param name="V">Vector whose reciprocal square root is estimated.</param>
	/// <returns>Returns a vector. Each component is an estimate of the reciprocal square-root of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>The reciprocal square-root operation handles special input values as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Input Value</description>
	/// <description>Return Value</description>
	/// </listheader>
	/// <item>
	/// <description>+Infinity</description>
	/// <description>0</description>
	/// </item>
	/// <item>
	/// <description>+0.0f</description>
	/// <description>+Infinity</description>
	/// </item>
	/// <item>
	/// <description>-0.0f</description>
	/// <description>-Infinity</description>
	/// </item>
	/// <item>
	/// <description>&lt; 0.0f</description>
	/// <description>QNaN</description>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorreciprocalsqrtest XMVECTOR XM_CALLCONV
	// XMVectorReciprocalSqrtEst( [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorReciprocalSqrtEst")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorReciprocalSqrtEst(this FXMVECTOR V) => V.UnaryOp(f => 1f / (float)Math.Sqrt(f));

	/// <summary>Replicates a floating-point value into all four components of a vector.</summary>
	/// <param name="Value">Value to replicate.</param>
	/// <returns>Returns a vector, all of whose components are equal to <i>Value</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorreplicate XMVECTOR XM_CALLCONV
	// XMVectorReplicate( [in] float Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorReplicate")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorReplicate(float Value) => new(Value);

	/// <summary>Replicates an integer value into all four components of a vector.</summary>
	/// <param name="Value">Value to replicate.</param>
	/// <returns>Returns a vector, all of whose components are equal to <i>Value</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorreplicateint XMVECTOR XM_CALLCONV
	// XMVectorReplicateInt( [in] uint32_t Value ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorReplicateInt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorReplicateInt(uint Value) => new(Value);

	/// <summary>Replicates an integer value referenced by a pointer, into all four components of a vector.</summary>
	/// <param name="pValue">Value to replicate.</param>
	/// <returns>Returns a vector, all of whose components are equal to <i>Value</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorreplicateintptr XMVECTOR XM_CALLCONV
	// XMVectorReplicateIntPtr( [in] const uint32_t *pValue ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorReplicateIntPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorReplicateIntPtr([In] uint* pValue) => new(*pValue);

	/// <summary>Replicates a floating-point value referenced by pointer into all four components of a vector.</summary>
	/// <param name="pValue">Value to replicate.</param>
	/// <returns>Returns a vector, all of whose components are equal to <i>Value</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorreplicateptr XMVECTOR XM_CALLCONV
	// XMVectorReplicatePtr( [in] const float *pValue ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorReplicatePtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorReplicatePtr([In] float* pValue) => new(*pValue);

	/// <summary>Rotates the vector left by a given number of 32-bit elements.</summary>
	/// <param name="V">Vector to rotate left.</param>
	/// <param name="Elements">Number of 32-bit elements by which to rotate <i>V</i> left. This parameter must be 0, 1, 2, or 3.</param>
	/// <returns>Returns the rotated <c>XMVECTOR</c>.</returns>
	/// <remarks>
	/// <para>The following code demonstrates how this function may be used.</para>
	/// <para><c>XMVECTOR v = XMVectorSet( 10.0f, 20.0f, 30.0f, 40.0f ); XMVECTOR result = XMVectorRotateLeft( v, 1 );</c></para>
	/// <para>The rotated vector ( <i>result</i>) will be &lt;20.0f, 30.0f, 40.0f, 10.0f&gt;.</para>
	/// <para>In the case of a constant rotate value, it is more efficient to use the template form of <c>XMVectorRotateLeft</c>:</para>
	/// <para><c>template&lt;uint32_t Elements&gt; XMVECTOR XMVectorRotateLeft(FXMVECTOR V)</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorrotateleft XMVECTOR XM_CALLCONV
	// XMVectorRotateLeft( [in] FXMVECTOR V, [in] uint32_t Elements ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorRotateLeft")]
	public static XMVECTOR XMVectorRotateLeft(this FXMVECTOR V, uint Elements) => Elements > 3
			? throw new ArgumentOutOfRangeException(nameof(Elements), "Elements must be 0, 1, 2, or 3.")
			: XMVectorSwizzle(V, Elements & 3, (Elements + 1) & 3, (Elements + 2) & 3, (Elements + 3) & 3);

	/// <summary>Rotates the vector right by a given number of 32-bit elements.</summary>
	/// <param name="V">Vector to rotate right.</param>
	/// <param name="Elements">Number of 32-bit elements by which to rotate <i>V</i> right. This parameter must be 0, 1, 2, or 3.</param>
	/// <returns>Returns the rotated <c>XMVECTOR</c>.</returns>
	/// <remarks>
	/// <para>The following code demonstrates how this function may be used.</para>
	/// <para><c>XMVECTOR v = XMVectorSet( 10.0f, 20.0f, 30.0f, 40.0f ); XMVECTOR result = XMVectorRotateRight( v, 1 );</c></para>
	/// <para>The rotated vector ( <i>result</i>) will be &lt;40.0f, 10.0f, 20.0f, 30.0f&gt;.</para>
	/// <para>In the case of a constant rotate value, it is more efficient to use the template form of <c>XMVectorRotateRight</c>:</para>
	/// <para><c>template&lt;uint32_t Elements&gt; XMVECTOR XMVectorRotateRight(FXMVECTOR V)</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorrotateright XMVECTOR XM_CALLCONV
	// XMVectorRotateRight( [in] FXMVECTOR V, [in] uint32_t Elements ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorRotateRight")]
	public static XMVECTOR XMVectorRotateRight(this FXMVECTOR V, uint Elements) => Elements > 3
			? throw new ArgumentOutOfRangeException(nameof(Elements), "Elements must be 0, 1, 2, or 3.")
			: XMVectorSwizzle(V, (4 - Elements) & 3, (5 - Elements) & 3, (6 - Elements) & 3, (7 - Elements) & 3);

	/// <summary>Rounds each component of a vector to the nearest even integer (known as "Bankers Rounding").</summary>
	/// <param name="V">Vector whose components should be rounded.</param>
	/// <returns>Returns a vector, each of whose components are rounded to the nearest integer.</returns>
	/// <remarks>
	/// <para>Banker's Rounding is used because it is the native vector rounding intrinsic method for both SSE4 and ARMv8 NEON.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorround XMVECTOR XM_CALLCONV XMVectorRound( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorRound")]
	public static XMVECTOR XMVectorRound(this FXMVECTOR V) =>
		V.UnaryOp(f => (float)Math.Round(f, MidpointRounding.ToEven));

	/// <summary>Saturates each component of a vector to the range 0.0f to 1.0f.</summary>
	/// <param name="V">Vector to saturate.</param>
	/// <returns>Returns a vector, each of whose components are saturated.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = min(max(V1.x, 0.0f), 1.0f); Result.y = min(max(V1.y, 0.0f), 1.0f); Result.z = min(max(V1.z, 0.0f),
	/// 1.0f); Result.w = min(max(V1.w, 0.0f), 1.0f); return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsaturate XMVECTOR XM_CALLCONV
	// XMVectorSaturate( [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSaturate")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSaturate(this FXMVECTOR V) => XMVectorClamp(V, XMVectorZero(), XMVectorSplatOne());

	/// <summary>Scalar multiplies a vector by a floating-point value.</summary>
	/// <param name="V">Vector to scale.</param>
	/// <param name="ScaleFactor">Scalar value.</param>
	/// <returns>Returns the scaled vector.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorscale XMVECTOR XM_CALLCONV XMVectorScale( [in]
	// FXMVECTOR V, [in] float ScaleFactor ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorScale")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorScale(this FXMVECTOR V, float ScaleFactor) => V.UnaryOp(f => f * ScaleFactor);

	/// <summary>Performs a per-component selection between two input vectors and returns the resulting vector.</summary>
	/// <param name="V1">First vector to compare.</param>
	/// <param name="V2">Second vector to compare.</param>
	/// <param name="Control">
	/// <para>
	/// Vector mask used to select a vector component from either <i>V1</i> or <i>V2</i>. If a component of <i>Control</i> is zero, the
	/// returned vector's corresponding component will be the first vector's component. If a component of <i>Control</i> is 0xFF, the
	/// returned vector's corresponding component will be the second vector's component. For full details on how the vector mask works, see
	/// the "Remarks".
	/// </para>
	/// <para>
	/// Typically, the vector used for <i>Control</i> will be either the output of a vector comparison function (such as
	/// <c>XMVectorEqual</c>, <c>XMVectorLess</c>, or <c>XMVectorGreater</c>) or it will be the output of <c>XMVectorSelectControl</c>.
	/// </para>
	/// </param>
	/// <returns>Returns the result of the per-component selection.</returns>
	/// <remarks>
	/// <para>
	/// If any given bit of <i>Control</i> is set, the corresponding bit from <i>V2</i> is used, otherwise, the corresponding bit from
	/// <i>V1</i> is used. The following pseudocode demonstrates the operation of the function:
	/// </para>
	/// <para>
	/// <c>XMVECTOR Result; Result.u[0] = (V1.u[0] &amp; ~Control.u[0]) | (V2.u[0] &amp; Control.u[0]); Result.u[1] = (V1.u[1] &amp;
	/// ~Control.u[1]) | (V2.u[1] &amp; Control.u[1]); Result.u[2] = (V1.u[2] &amp; ~Control.u[2]) | (V2.u[2] &amp; Control.u[2]);
	/// Result.u[3] = (V1.u[3] &amp; ~Control.u[3]) | (V2.u[3] &amp; Control.u[3]); return Result;</c>
	/// </para>
	/// <para>
	/// Manual construction of a control vector is not necessary. There are two simple ways of constructing an appropriate control vector:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>Using the <c>XMVectorSelectControl</c> function to construct a control vector.
	/// <para>See <c>Using XMVectorSelect and XMVectorSelectControl</c> for a demonstration of how this function can be used.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// The control vector can be constructed using the XM_SELECT_[0,1] constant (see <c>DirectXMath Library Constants</c>). As an example,
	/// in pseudo-code, an instance of <i>Control</i> with the elements:
	/// <para>would return a vector <i>Result</i> with the following components of <i>V1</i> and <i>V2</i></para>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorselect XMVECTOR XM_CALLCONV XMVectorSelect(
	// [in] FXMVECTOR V1, [in] FXMVECTOR V2, [in] FXMVECTOR Control ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSelect")]
	public static XMVECTOR XMVectorSelect(this FXMVECTOR V1, in FXMVECTOR V2, in FXMVECTOR Control) => new((V1.ux & ~Control.ux) | (V2.ux & Control.ux),
		(V1.uy & ~Control.uy) | (V2.uy & Control.uy), (V1.uz & ~Control.uz) | (V2.uz & Control.uz), (V1.uw & ~Control.uw) | (V2.uw & Control.uw));

	/// <summary>Defines a control vector for use in <c>XMVectorSelect</c>.</summary>
	/// <param name="VectorIndex0">
	/// Index that determines which vector in <c>XMVectorSelect</c> will be selected. If zero, the first vector's first component will be
	/// selected. Otherwise, the second vector's component will be selected.
	/// </param>
	/// <param name="VectorIndex1">
	/// Index that determines which vector in <c>XMVectorSelect</c> will be selected. If zero, the first vector's second component will be
	/// selected. Otherwise, the second vector's component will be selected.
	/// </param>
	/// <param name="VectorIndex2">
	/// Index that determines which vector in <c>XMVectorSelect</c> will be selected. If zero, the first vector's third component will be
	/// selected. Otherwise, the second vector's component will be selected.
	/// </param>
	/// <param name="VectorIndex3">
	/// Index that determines which vector in <c>XMVectorSelect</c> will be selected. If zero, the first vector's fourth component will be
	/// selected. Otherwise, the second vector's component will be selected.
	/// </param>
	/// <returns>Returns the control vector.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR ControlVector; const uint32_t ControlElement[] = { XM_SELECT_0, XM_SELECT_1 }; assert(VectorIndex0 &lt; 2);
	/// assert(VectorIndex1 &lt; 2); assert(VectorIndex2 &lt; 2); assert(VectorIndex3 &lt; 2); ControlVector.u[0] =
	/// ControlElement[VectorIndex0]; ControlVector.u[1] = ControlElement[VectorIndex1]; ControlVector.u[2] = ControlElement[VectorIndex2];
	/// ControlVector.u[3] = ControlElement[VectorIndex3]; return ControlVector;</c>
	/// </para>
	/// <para>Examples</para>
	/// <para>Using XMVectorSelectControl</para>
	/// <para>
	/// In this example, <b>XMVectorSelectControl</b> is used to generate a control mask that will select the x and w components from the
	/// first vector and the y and z components from the second.
	/// </para>
	/// <para>The vector result will be ( 3.0f, 5.0f, 5.0f, 3.0f ).</para>
	/// <para>
	/// <c>XMVECTOR three = XMVectorReplicate( 3.0f ); XMVECTOR five = XMVectorReplicate( 5.0f ); XMVECTOR control = XMVectorSelectControl(
	/// 0, 1, 1, 0 ); XMVECTOR result = XMVectorSelect( three, five, control );</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorselectcontrol XMVECTOR XM_CALLCONV
	// XMVectorSelectControl( [in] uint32_t VectorIndex0, [in] uint32_t VectorIndex1, [in] uint32_t VectorIndex2, [in] uint32_t VectorIndex3
	// ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSelectControl")]
	public static XMVECTOR XMVectorSelectControl(uint VectorIndex0, uint VectorIndex1, uint VectorIndex2, uint VectorIndex3)
	{
		if (VectorIndex0 > 1 || VectorIndex1 > 1 || VectorIndex2 > 1 || VectorIndex3 > 1)
			throw new ArgumentOutOfRangeException("VectorIndex0-3", "Vector index must be 0 or 1.");
		uint[] ControlElement = [XM_SELECT_0, XM_SELECT_1];
		return new(ControlElement[VectorIndex0], ControlElement[VectorIndex1], ControlElement[VectorIndex2], ControlElement[VectorIndex3]);
	}

	/// <summary>Creates a vector using four floating-point values.</summary>
	/// <param name="x">The x component of the vector to return.</param>
	/// <param name="y">The y component of the vector to return.</param>
	/// <param name="z">The z component of the vector to return.</param>
	/// <param name="w">The w component of the vector to return.</param>
	/// <returns>
	/// An instance <c>XMVECTOR</c> each of whose four components ( <i>x</i>, <i>y</i>, <i>z</i>, and <i>w</i>) is a floating-point number
	/// with the same value as the corresponding input argument to <c>XMVectorSet</c>.
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>XMVECTOR V; float x,y,z,w; V.x = x; V.y = y; V.z = z; V.w = w; return V;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorset XMVECTOR XM_CALLCONV XMVectorSet( [in]
	// float x, [in] float y, [in] float z, [in] float w ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSet")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSet(float x, float y, float z, float w) => new(x, y, z, w);

	/// <summary>Creates a vector, each of whose components is either 0.0f or 1.0f.</summary>
	/// <param name="C0">
	/// This parameter must be a number (an immediate value, either 0 or 1) and not a variable. If <i>C0</i> is 0, the x-component of the
	/// returned vector will be 0.0f. Otherwise, the x-component will be 1.0f.
	/// </param>
	/// <param name="C1">
	/// This parameter must be a number (an immediate value, either 0 or 1) and not a variable. If <i>C1</i> is 0, the y-component of the
	/// returned vector will be 0.0f. Otherwise, the y-component will be 1.0f.
	/// </param>
	/// <param name="C2">
	/// This parameter must be a number (an immediate value, either 0 or 1) and not a variable. If <i>C2</i> is 0, the z-component of the
	/// returned vector will be 0.0f. Otherwise, the z-component will be 1.0f.
	/// </param>
	/// <param name="C3">
	/// This parameter must be a number (an immediate value, either 0 or 1) and not a variable. If <i>C3</i> is 0, the w-component of the
	/// returned vector will be 0.0f. Otherwise, the w-component will be 1.0f.
	/// </param>
	/// <returns>Returns an <c>XMVECTOR</c>, each of whose components is either 0.0f or 1.0f.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetbinaryconstant XMVECTOR XM_CALLCONV
	// XMVectorSetBinaryConstant( [in] uint32_t C0, [in] uint32_t C1, [in] uint32_t C2, [in] uint32_t C3 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetBinaryConstant")]
	public static XMVECTOR XMVectorSetBinaryConstant(uint C0, uint C1, uint C2, uint C3) =>
		new((0 - (C0 & 1)) & 0x3F800000, (0 - (C1 & 1)) & 0x3F800000, (0 - (C2 & 1)) & 0x3F800000, (0 - (C3 & 1)) & 0x3F800000);

	/// <summary>
	/// Use a floating-point object to set the value of one of the four components of an <c>XMVECTOR Data Type</c> containing integer data
	/// referenced by an index.
	/// </summary>
	/// <param name="V">A <c>XMVECTOR Data Type</c> containing integer data.</param>
	/// <param name="f">The floating point value used to set the <i>i</i> component of the returned <c>XMVECTOR Data Type</c>.</param>
	/// <param name="i">The index of the component to be retrieved.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>i</i> component has been set to the floating-point value provided by the argument
	/// <i>f</i>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as those of the input vector <i>V</i>.
	/// </returns>
	/// <remarks>
	/// <para>The value of <i>i</i> must be positive and less than or equal to three ( <i>0</i> &lt;= <i>i</i> &lt;= <i>3</i> ).</para>
	/// <para>The indexes have the following correspondence with <c>XMVECTOR Data Type</c> vector components:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Index</description>
	/// <description>Component</description>
	/// </listheader>
	/// <item>
	/// <description>
	/// <code>0</code>
	/// </description>
	/// <description>
	/// <code>x</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>1</code>
	/// </description>
	/// <description>
	/// <code>y</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>2</code>
	/// </description>
	/// <description>
	/// <code>z</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>3</code>
	/// </description>
	/// <description>
	/// <code>w</code>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetbyindex XMVECTOR XM_CALLCONV
	// XMVectorSetByIndex( FXMVECTOR V, float f, size_t i ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetByIndex")]
	public static XMVECTOR XMVectorSetByIndex(this FXMVECTOR V, float f, SizeT i)
	{
		if (i < 0 || i > 3)
			throw new ArgumentOutOfRangeException(nameof(i), "Index must be value between 0 and 3.");
		var U = V;
		unsafe { U.f[i] = f; }
		return U;
	}

	/// <summary>
	/// Use a pointer to a floating-point instance to set the value of one of the four components of an <c>XMVECTOR Data Type</c> containing
	/// floating-point data referenced by an index.
	/// </summary>
	/// <param name="V">A <c>XMVECTOR Data Type</c> containing floating-point data.</param>
	/// <param name="f">A pointer to a floating-point instance used to set the <i>i</i> component of the returned <c>XMVECTOR Data Type</c>.</param>
	/// <param name="i">The index of the component to be set.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>i</i> component has been set to the floating-point value provided by the argument
	/// <i>f</i>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as those of the input vector <i>V</i>.
	/// </returns>
	/// <remarks>
	/// <para>The value of <i>i</i> must be positive and less than or equal to three ( <i>0</i> &lt;= <i>i</i> &lt;= <i>3</i> ).</para>
	/// <para>The indexes have the following correspondence with <c>XMVECTOR Data Type</c> vector components:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Index</description>
	/// <description>Component</description>
	/// </listheader>
	/// <item>
	/// <description>
	/// <code>0</code>
	/// </description>
	/// <description>
	/// <code>x</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>1</code>
	/// </description>
	/// <description>
	/// <code>y</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>2</code>
	/// </description>
	/// <description>
	/// <code>z</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>3</code>
	/// </description>
	/// <description>
	/// <code>w</code>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetbyindexptr XMVECTOR XM_CALLCONV
	// XMVectorSetByIndexPtr( FXMVECTOR V, [in] const float *f, size_t i ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetByIndexPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorSetByIndexPtr(this FXMVECTOR V, [In] float* f, SizeT i) => f is not null ? XMVectorSetByIndex(V, *f, i) : throw new ArgumentNullException(nameof(f));

	/// <summary>Creates a vector with unsigned integer components.</summary>
	/// <param name="x"><b>uint32_t</b> value to assign to the x-component of the returned vector.</param>
	/// <param name="y"><b>uint32_t</b> value to assign to the y-component of the returned vector.</param>
	/// <param name="z"><b>uint32_t</b> value to assign to the z-component of the returned vector.</param>
	/// <param name="w"><b>uint32_t</b> value to assign to the w-component of the returned vector.</param>
	/// <returns>
	/// An instance <c>XMVECTOR</c> each of whose four components ( <i>x</i>, <i>y</i>, <i>z</i>, and <i>w</i>) is an integer with the same
	/// value as the corresponding input argument to <c>XMVectorSetInt</c>.
	/// </returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para><c>XMVECTOR V; uint32_t x,y,z,w; V.x = x; V.y = y; V.z = z; V.w = w; return V;</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetint XMVECTOR XM_CALLCONV XMVectorSetInt(
	// [in] uint32_t x, [in] uint32_t y, [in] uint32_t z, [in] uint32_t w ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetInt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSetInt(uint x, uint y, uint z, uint w) => new(x, y, z, w);

	/// <summary>
	/// Use an integer instance to set the value of one of the four components of an <c>XMVECTOR Data Type</c> containing integer data
	/// referenced by an index.
	/// </summary>
	/// <param name="V">A <c>XMVECTOR Data Type</c> containing integer data.</param>
	/// <param name="x">The integer value used to set the <i>i</i> component of the returned <c>XMVECTOR Data Type</c>.</param>
	/// <param name="i">The index of the component to be retrieved.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>i</i> component has been set to the integer value provided by the argument
	/// <i>x</i>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as those of the input vector <i>V</i>.
	/// </returns>
	/// <remarks>
	/// <para>The value of <i>i</i> must be positive and less than or equal to three ( <i>0</i> &lt;= <i>i</i> &lt;= <i>3</i> ).</para>
	/// <para>The indexes have the following correspondence with <c>XMVECTOR Data Type</c> vector components:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Index</description>
	/// <description>Component</description>
	/// </listheader>
	/// <item>
	/// <description>
	/// <code>0</code>
	/// </description>
	/// <description>
	/// <code>x</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>1</code>
	/// </description>
	/// <description>
	/// <code>y</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>2</code>
	/// </description>
	/// <description>
	/// <code>z</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>3</code>
	/// </description>
	/// <description>
	/// <code>w</code>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetintbyindex XMVECTOR XM_CALLCONV
	// XMVectorSetIntByIndex( FXMVECTOR V, uint32_t x, size_t i ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetIntByIndex")]
	public static XMVECTOR XMVectorSetIntByIndex(this FXMVECTOR V, uint x, SizeT i)
	{
		if (i < 0 || i > 3)
			throw new ArgumentOutOfRangeException(nameof(i), "Index must be value between 0 and 3.");
		var U = V;
		unsafe { U.u[i] = x; }
		return U;
	}

	/// <summary>
	/// Use a pointer to an integer instance to set the value of one of the four components of an <c>XMVECTOR Data Type</c> containing
	/// integer data referenced by an index.
	/// </summary>
	/// <param name="V">A <c>XMVECTOR Data Type</c> containing integer data.</param>
	/// <param name="x">A pointer to an integer instance used to set the <i>i</i> component of the returned <c>XMVECTOR Data Type</c>.</param>
	/// <param name="i">The index of the component to be set.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>i</i> component has been set to the integer value provided by the argument
	/// <i>f</i>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as those of the input vector <i>V</i>.
	/// </returns>
	/// <remarks>
	/// <para>The value of <i>i</i> must be positive and less than or equal to three ( <i>0</i> &lt;= <i>i</i> &lt;= <i>3</i> ).</para>
	/// <para>The indexes have the following correspondence with <c>XMVECTOR Data Type</c> vector components:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Index</description>
	/// <description>Component</description>
	/// </listheader>
	/// <item>
	/// <description>
	/// <code>0</code>
	/// </description>
	/// <description>
	/// <code>x</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>1</code>
	/// </description>
	/// <description>
	/// <code>y</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>2</code>
	/// </description>
	/// <description>
	/// <code>z</code>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <code>3</code>
	/// </description>
	/// <description>
	/// <code>w</code>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetintbyindexptr XMVECTOR XM_CALLCONV
	// XMVectorSetIntByIndexPtr( FXMVECTOR V, [in] const uint32_t *x, size_t i ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetIntByIndexPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorSetIntByIndexPtr(this FXMVECTOR V, [In] uint* x, SizeT i) => x is not null ? XMVectorSetIntByIndex(V, *x, i) : throw new ArgumentNullException(nameof(x));

	/// <summary>Set the value of the <c>w</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D unsigned integer vector.</param>
	/// <param name="w">A unsigned integer value to be assigned to <c>w</c> of <i>V</i>.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>x</i> component has been set to the integer value provided by the argument
	/// <i>x</i> to <c>XMVectorSetIntW</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetintw XMVECTOR XM_CALLCONV XMVectorSetIntW(
	// [in] FXMVECTOR V, [in] uint32_t w ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetIntW")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSetIntW(this FXMVECTOR V, uint w) => new(V.x, V.y, V.z, w);

	/// <summary>
	/// Sets the <c>w</c> component of an <c>XMVECTOR</c> containing integer data, with a value contained in an instance of uint32_t
	/// referred to by a pointer.
	/// </summary>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <param name="w">
	/// Pointer to a uint32_t containing the value to be stored in the <c>w</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>w</i> component has been set to the integer value pointed to by the argument
	/// <i>w</i> of <c>XMVectorSetIntWPtr</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value
	/// as those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetintwptr XMVECTOR XM_CALLCONV
	// XMVectorSetIntWPtr( FXMVECTOR V, [in] const uint32_t *w ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetIntWPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorSetIntWPtr(this FXMVECTOR V, [In] uint* w) => w is not null ? XMVectorSetIntW(V, *w) : throw new ArgumentNullException(nameof(w));

	/// <summary>Set the value of the <c>x</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <param name="x">An integer value to be assigned to <c>x</c> of <i>V</i>.</param>
	/// <returns>None.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetintx XMVECTOR XM_CALLCONV XMVectorSetIntX(
	// [in] FXMVECTOR V, [in] uint32_t x ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetIntX")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSetIntX(this FXMVECTOR V, uint x) => new(x, V.y, V.z, V.w);

	/// <summary>
	/// Sets the <c>x</c> component of an <c>XMVECTOR</c> containing integer data, with a value contained in an instance of uint32_t
	/// referred to by a pointer.
	/// </summary>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <param name="x">
	/// Pointer to a uint32_t containing the value to be stored in the <c>x</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>x</i> component has been set to the integer value pointed to by the argument
	/// <i>x</i> of <c>XMVectorSetIntXPtr</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value
	/// as those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetintxptr XMVECTOR XM_CALLCONV
	// XMVectorSetIntXPtr( FXMVECTOR V, [in] const uint32_t *x ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetIntXPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorSetIntXPtr(this FXMVECTOR V, [In] uint* x) => x is not null ? XMVectorSetIntW(V, *x) : throw new ArgumentNullException(nameof(x));

	/// <summary>Set the value of the <c>y</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <param name="y">An integer value to be assigned to <c>y</c> of <i>V</i>.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>y</i> component has been set to the integer value provided by the argument
	/// <i>y</i> to <c>XMVectorSetIntY</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetinty XMVECTOR XM_CALLCONV XMVectorSetIntY(
	// [in] FXMVECTOR V, [in] uint32_t y ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetIntY")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSetIntY(this FXMVECTOR V, uint y) => new(V.x, y, V.z, V.w);

	/// <summary>
	/// Sets the <c>y</c> component of an <c>XMVECTOR</c> containing integer data, with a value contained in an instance of uint32_t
	/// referred to by a pointer.
	/// </summary>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <param name="y">
	/// Pointer to a uint32_t containing the value to be stored in the <c>y</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>y</i> component has been set to the integer value pointed to by the argument
	/// <i>y</i> of <c>XMVectorSetIntYPtr</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value
	/// as those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetintyptr XMVECTOR XM_CALLCONV
	// XMVectorSetIntYPtr( FXMVECTOR V, [in] const uint32_t *y ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetIntYPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorSetIntYPtr(this FXMVECTOR V, [In] uint* y) => y is not null ? XMVectorSetIntW(V, *y) : throw new ArgumentNullException(nameof(y));

	/// <summary>Set the value of the <c>z</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D unsigned integer vector.</param>
	/// <param name="z">A unsigned integer value to be assigned to <c>z</c> of <i>V</i>.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>z</i> component has been set to the integer value provided by the argument
	/// <i>z</i> to <c>XMVectorSetIntZ</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetintz XMVECTOR XM_CALLCONV XMVectorSetIntZ(
	// [in] FXMVECTOR V, [in] uint32_t z ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetIntZ")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSetIntZ(this FXMVECTOR V, uint z) => new(V.x, V.y, z, V.w);

	/// <summary>
	/// Sets the <c>z</c> component of an <c>XMVECTOR</c> containing integer data, with a value contained in an instance of uint32_t
	/// referred to by a pointer.
	/// </summary>
	/// <param name="V">A valid 4D vector storing integer data.</param>
	/// <param name="z">
	/// Pointer to a uint32_t containing the value to be stored in the <c>z</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>z</i> component has been set to the integer value pointed to by the argument
	/// <i>z</i> of <c>XMVectorSetIntZPtr</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value
	/// as those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetintzptr XMVECTOR XM_CALLCONV
	// XMVectorSetIntZPtr( FXMVECTOR V, [in] const uint32_t *z ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetIntZPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorSetIntZPtr(this FXMVECTOR V, [In] uint* z) => z is not null ? XMVectorSetIntW(V, *z) : throw new ArgumentNullException(nameof(z));

	/// <summary>Set the value of the <c>w</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D floating-point vector.</param>
	/// <param name="w">A floating-point value to be assigned to <c>w</c> of <i>V</i>.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>w</i> component has been set to the floating-point value provided by the argument
	/// <i>w</i> to <c>XMVectorSetW</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetw XMVECTOR XM_CALLCONV XMVectorSetW( [in]
	// FXMVECTOR V, [in] float w ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetW")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSetW(this FXMVECTOR V, float w) => new(V.x, V.y, V.z, w);

	/// <summary>
	/// Sets the <c>w</c> component of an <c>XMVECTOR</c> containing floating-point data, with a value contained in an instance of float
	/// referred to by a pointer.
	/// </summary>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <param name="w">
	/// Pointer to a float containing the value to be stored in the <c>w</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>w</i> component has been set to the floating-point value provided by the argument
	/// <i>w</i> to <c>XMVectorSetWPtr</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetwptr XMVECTOR XM_CALLCONV XMVectorSetWPtr(
	// FXMVECTOR V, [in] const float *w ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetWPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorSetWPtr(this FXMVECTOR V, [In] float* w) => w is not null ? XMVectorSetW(V, *w) : throw new ArgumentNullException(nameof(w));

	/// <summary>Set the value of the <c>x</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <param name="x">A floating-point value to be assigned to <c>x</c> of <i>V</i>.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>x</i> component has been set to the floating-point value provided by the argument
	/// <i>x</i> to <c>XMVectorSetX</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetx XMVECTOR XM_CALLCONV XMVectorSetX( [in]
	// FXMVECTOR V, [in] float x ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetX")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSetX(this FXMVECTOR V, float x) => new(x, V.y, V.z, V.w);

	/// <summary>
	/// Sets the <c>x</c> component of an <c>XMVECTOR</c> containing floating-point data, with a value contained in an instance of float
	/// referred to by a pointer.
	/// </summary>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <param name="x">
	/// Pointer to a float containing the value to be stored in the <c>x</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>x</i> component has been set to the floating-point value provided by the argument
	/// <i>x</i> to <c>XMVectorSetXPtr</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetxptr XMVECTOR XM_CALLCONV XMVectorSetXPtr(
	// FXMVECTOR V, [in] const float *x ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetXPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorSetXPtr(this FXMVECTOR V, [In] float* x) => x is not null ? XMVectorSetX(V, *x) : throw new ArgumentNullException(nameof(x));

	/// <summary>Set the value of the <c>y</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <param name="y">A floating-point value to be assigned to <c>y</c> of <i>V</i>.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>y</i> component has been set to the floating-point value provided by the argument
	/// <i>y</i> to <c>XMVectorSetY</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsety XMVECTOR XM_CALLCONV XMVectorSetY( [in]
	// FXMVECTOR V, [in] float y ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetY")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSetY(this FXMVECTOR V, float y) => new(V.x, y, V.z, V.w);

	/// <summary>
	/// Sets the <c>y</c> component of an <c>XMVECTOR</c> containing floating-point data, with a value contained in an instance of float
	/// referred to by a pointer.
	/// </summary>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <param name="y">
	/// Pointer to a float containing the value to be stored in the <c>y</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>y</i> component has been set to the floating-point value provided by the argument
	/// <i>y</i> to <c>XMVectorSetYPtr</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetyptr XMVECTOR XM_CALLCONV XMVectorSetYPtr(
	// FXMVECTOR V, [in] const float *y ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetYPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorSetYPtr(this FXMVECTOR V, [In] float* y) => y is not null ? XMVectorSetY(V, *y) : throw new ArgumentNullException(nameof(y));

	/// <summary>Set the value of the <c>z</c> component of an <c>XMVECTOR Data Type</c>.</summary>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <param name="z">A floating-point value to be assigned to <c>z</c> of <i>V</i>.</param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>z</i> component has been set to the floating-point value provided by the argument
	/// <i>z</i> to <c>XMVectorSetZ</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetz XMVECTOR XM_CALLCONV XMVectorSetZ( [in]
	// FXMVECTOR V, [in] float z ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetZ")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSetZ(this FXMVECTOR V, float z) => new(V.x, V.y, z, V.w);

	/// <summary>
	/// Sets the <c>z</c> component of an <c>XMVECTOR</c> containing floating-point data, with a value contained in an instance of float
	/// referred to by a pointer.
	/// </summary>
	/// <param name="V">A valid 4D vector storing floating-point data.</param>
	/// <param name="z">
	/// Pointer to a float containing the value to be stored in the <c>z</c> element of the <c>XMVECTOR Data Type</c> object <c>V</c>.
	/// </param>
	/// <returns>
	/// An instance of <c>XMVECTOR Data Type</c> whose <i>z</i> component has been set to the floating-point value provided by the argument
	/// <i>z</i> to <c>XMVectorSetZPtr</c>. All other components of the returned <b>XMVECTOR Data Type</b> instance have the same value as
	/// those of the input vector <i>V</i>.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsetzptr XMVECTOR XM_CALLCONV XMVectorSetZPtr(
	// FXMVECTOR V, [in] const float *z ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSetZPtr")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static unsafe XMVECTOR XMVectorSetZPtr(this FXMVECTOR V, [In] float* z) => z is not null ? XMVectorSetZ(V, *z) : throw new ArgumentNullException(nameof(z));

	/// <summary>
	/// Shifts a vector left by a given number of 32-bit elements, filling the vacated elements with elements from a second vector.
	/// </summary>
	/// <param name="V1">Vector to shift left.</param>
	/// <param name="V2">Vector used to fill in the vacated components of <i>V1</i> after it is shifted left.</param>
	/// <param name="Elements">Number of 32-bit elements by which to shift <i>V</i> left. This parameter must be 0, 1, 2, or 3.</param>
	/// <returns>Returns the shifted and filled in <c>XMVECTOR</c>.</returns>
	/// <remarks>
	/// <para>The following code demonstrates how this function might be used.</para>
	/// <para>
	/// <c>XMVECTOR v1 = XMVectorSet( 10.0f, 20.0f, 30.0f, 40.0f ); XMVECTOR v2 = XMVectorSet( 50.0f, 60.0f, 70.0f, 80.0f ); XMVECTOR result
	/// = XMVectorShiftLeft( v1, v2, 1 );</c>
	/// </para>
	/// <para>The shifted vector ( <i>result</i>) will be &lt;20.0f, 30.0f, 40.0f, 50.0f&gt;.</para>
	/// <para>In the case of a constant shift value, it is more efficient to use the template form of <c>XMVectorShiftLeft</c>:</para>
	/// <para>
	/// <c>template&lt;uint32_t Elements&gt; XMVECTOR XMVectorShiftLeft(FXMVECTOR V1, FXMVECTOR V2) Example: XMVectorShiftLeft&lt;1&gt;( v1,
	/// v2 );</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorshiftleft XMVECTOR XM_CALLCONV
	// XMVectorShiftLeft( [in] FXMVECTOR V1, [in] FXMVECTOR V2, [in] uint32_t Elements ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorShiftLeft")]
	public static XMVECTOR XMVectorShiftLeft(this FXMVECTOR V1, in FXMVECTOR V2, uint Elements) => Elements > 3
			? throw new ArgumentOutOfRangeException(nameof(Elements), "Elements must be 0, 1, 2, or 3.")
			: XMVectorPermute(V1, V2, Elements, Elements + 1, Elements + 2, Elements + 3);

	/// <summary>Computes the sine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the sine.</param>
	/// <returns>Returns a vector. Each component is the sine of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>This function uses a 11-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsin XMVECTOR XM_CALLCONV XMVectorSin( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSin")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSin(this FXMVECTOR V) => V.UnaryOp(Math.Sin);

	/// <summary>Computes the sine and cosine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="pSin">Address of a vector, each of whose components is the sine of the corresponding component of <i>V</i>.</param>
	/// <param name="pCos">Address of a vector, each of whose components is the cosine of the corresponding component of <i>V</i>.</param>
	/// <param name="V">Vector for which to compute the sine and cosine.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>This function uses an 11-degree minimax approximation for sine, 10-degree for cosine.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsincos void XM_CALLCONV XMVectorSinCos( [out]
	// XMVECTOR *pSin, [out] XMVECTOR *pCos, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSinCos")]
	public static void XMVectorSinCos(out XMVECTOR pSin, out XMVECTOR pCos, in FXMVECTOR V)
	{
		pSin = XMVectorSin(V);
		pCos = XMVectorCos(V);
	}

	/// <summary>Estimates the sine and cosine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="pSin">Address of a vector, each of whose components is an estimate of the sine of the corresponding component of <i>V</i>.</param>
	/// <param name="pCos">
	/// Address of a vector, each of whose components is an estimate of the cosine of the corresponding component of <i>V</i>.
	/// </param>
	/// <param name="V">Vector for which to compute the sine and cosine.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 7-degree minimax approximation for sine, 6-degree for cosine.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsincosest void XM_CALLCONV XMVectorSinCosEst(
	// [out] XMVECTOR *pSin, [out] XMVECTOR *pCos, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSinCosEst")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void XMVectorSinCosEst(out XMVECTOR pSin, out XMVECTOR pCos, in FXMVECTOR V) => XMVectorSinCos(out pSin, out pCos, V);

	/// <summary>Estimates the sine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the sine.</param>
	/// <returns>Returns a vector. Each component is an estimate of the sine of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// <para>This function uses a 7-degree minimax approximation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsinest XMVECTOR XM_CALLCONV XMVectorSinEst(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSinEst")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSinEst(this FXMVECTOR V) => XMVectorSin(V);

	/// <summary>Computes the hyperbolic sine of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the hyperbolic sine.</param>
	/// <returns>Returns a vector. Each component is the hyperbolic sine of the corresponding component of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsinh XMVECTOR XM_CALLCONV XMVectorSinH( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSinH")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSinH(this FXMVECTOR V) => V.UnaryOp(Math.Sinh);

	/// <summary>
	/// Creates a vector with identical floating-point components. Each component is a constant divided by two raised to an integer exponent.
	/// </summary>
	/// <param name="IntConstant">
	/// <para>
	/// This value will be converted to a floating-point number and divided by two raised to the <i>DivExponent</i> power. The result is
	/// replicated to each component of the returned vector.
	/// </para>
	/// <para>The value of <i>IntConstant</i> must satisfy: -16 &lt;=  <i>IntConstant</i> &lt;=15.</para>
	/// <para><b>Note</b>  This parameter must be a number (an immediate value) and not a variable.</para>
	/// <para></para>
	/// </param>
	/// <param name="DivExponent">
	/// Describes the exponent applied to the quotient. This parameter must be a number (an immediate value) and not a variable.
	/// </param>
	/// <returns>
	/// Returns an <c>XMVECTOR</c> with identical floating-point components. Each component is a constant divided by two raised to an
	/// integer exponent.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplatconstant XMVECTOR XM_CALLCONV
	// XMVectorSplatConstant( [in] int32_t IntConstant, [in] uint32_t DivExponent ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatConstant")]
	public static XMVECTOR XMVectorSplatConstant(int IntConstant, uint DivExponent) => DivExponent >= 32
			? throw new ArgumentOutOfRangeException(nameof(DivExponent), "DivExponent must be less than 32.")
			: XMVectorSplatConstantInt(IntConstant).XMConvertVectorIntToFloat(DivExponent);

	/// <summary>Creates a vector with identical integer components.</summary>
	/// <param name="IntConstant">
	/// <para>Value to replicate to each component of the returned vector.</para>
	/// <para>The value of <i>IntConstant</i> must satisfy: -16 &lt;=  <i>IntConstant</i> &lt;=15.</para>
	/// <para><b>Note</b>  This parameter must be a number (an immediate value) and not a variable.</para>
	/// <para></para>
	/// </param>
	/// <returns>Returns an <c>XMVECTOR</c>, each of whose components is <i>IntConstant</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplatconstantint XMVECTOR XM_CALLCONV
	// XMVectorSplatConstantInt( [in] int32_t IntConstant ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatConstantInt")]
	public static XMVECTOR XMVectorSplatConstantInt(int IntConstant) => IntConstant is < (-16) or > 15
			? throw new ArgumentOutOfRangeException(nameof(IntConstant), "IntConstant must be between -16 and 15.")
			: new(unchecked((uint)IntConstant));

	/// <summary>Returns a vector, each of whose components are epsilon (1.192092896e-7).</summary>
	/// <returns>Returns a vector, each of whose components is (1.192092896e-7).</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplatepsilon XMVECTOR XM_CALLCONV
	// XMVectorSplatEpsilon() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatEpsilon")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSplatEpsilon() => new(0x34000000u);

	/// <summary>Returns a vector, each of whose components are infinity (0x7F800000).</summary>
	/// <returns>Returns a vector, each of whose components are infinity (0x7F800000).</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplatinfinity XMVECTOR XM_CALLCONV
	// XMVectorSplatInfinity() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatInfinity")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSplatInfinity() => new(0x7F800000u);

	/// <summary>Returns a vector, each of whose components are one.</summary>
	/// <returns>Returns a vector, each of whose components is 1.0 (float).</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplatone XMVECTOR XM_CALLCONV
	// XMVectorSplatOne() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatOne")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSplatOne() => new(1f);

	/// <summary>Returns a vector, each of whose components are QNaN (0x7CF00000).</summary>
	/// <returns>Returns a vector, each of whose components are QNaN (0x7CF00000)</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplatqnan XMVECTOR XM_CALLCONV
	// XMVectorSplatQNaN() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatQNaN")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSplatQNaN() => new(0x7FC00000u);

	/// <summary>Returns a vector, each of whose components are the sign mask (0x80000000).</summary>
	/// <returns>Returns a vector, each of whose components are the sign mask (0x80000000).</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplatsignmask XMVECTOR XM_CALLCONV
	// XMVectorSplatSignMask() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatSignMask")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSplatSignMask() => new(0x80000000U);

	/// <summary>Replicates the w component of a vector to all of the components.</summary>
	/// <param name="V">Vector from which to select the w component.</param>
	/// <returns>Returns a vector, all of whose components are equal to the w component of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplatw XMVECTOR XM_CALLCONV XMVectorSplatW(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatW")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSplatW(this FXMVECTOR V) => new(V.w);

	/// <summary>Replicates the x component of a vector to all of the components.</summary>
	/// <param name="V">Vector from which to select the x component.</param>
	/// <returns>Returns a vector, all of whose components are equal to the x component of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplatx XMVECTOR XM_CALLCONV XMVectorSplatX(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatX")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSplatX(this FXMVECTOR V) => new(V.x);

	/// <summary>Replicates the y component of a vector to all of the components.</summary>
	/// <param name="V">Vector from which to select the y component.</param>
	/// <returns>Returns a vector, all of whose components are equal to the y component of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplaty XMVECTOR XM_CALLCONV XMVectorSplatY(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatY")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSplatY(this FXMVECTOR V) => new(V.y);

	/// <summary>Replicates the z component of a vector to all of the components.</summary>
	/// <param name="V">Vector from which to select the z component.</param>
	/// <returns>Returns a vector, all of whose components are equal to the z component of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsplatz XMVECTOR XM_CALLCONV XMVectorSplatZ(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSplatZ")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSplatZ(this FXMVECTOR V) => new(V.z);

	/// <summary>Computes the per-component square root of a vector.</summary>
	/// <param name="V">Vector whose square root is computed.</param>
	/// <returns>Returns a vector. Each component is the square-root of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>The square-root operation handles special input values as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Input Value</description>
	/// <description>Return Value</description>
	/// </listheader>
	/// <item>
	/// <description>+Infinity</description>
	/// <description>+Infinity</description>
	/// </item>
	/// <item>
	/// <description>+0.0f</description>
	/// <description>+0.0f</description>
	/// </item>
	/// <item>
	/// <description>-0.0f</description>
	/// <description>-0.0f</description>
	/// </item>
	/// <item>
	/// <description>&lt; 0.0f</description>
	/// <description>QNaN</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsqrt XMVECTOR XM_CALLCONV XMVectorSqrt( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSqrt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSqrt(this FXMVECTOR V) => V.UnaryOp(Math.Sqrt);

	/// <summary>Estimates the per-component square root of a vector.</summary>
	/// <param name="V">Vector whose square root is estimated.</param>
	/// <returns>Returns a vector. Each component is an estimate of the square-root of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>The square-root operation handles special input values as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Input Value</description>
	/// <description>Return Value</description>
	/// </listheader>
	/// <item>
	/// <description>+Infinity</description>
	/// <description>+Infinity</description>
	/// </item>
	/// <item>
	/// <description>+0.0f</description>
	/// <description>+0.0f</description>
	/// </item>
	/// <item>
	/// <description>-0.0f</description>
	/// <description>-0.0f</description>
	/// </item>
	/// <item>
	/// <description>&lt; 0.0f</description>
	/// <description>QNaN*</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <list type="bullet">
	/// <item>
	/// <description>Note that due to implementation details, VMX128 returns -Infinity in this case instead of the standard QNaN.</description>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsqrtest XMVECTOR XM_CALLCONV XMVectorSqrtEst(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSqrtEst")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSqrtEst(this FXMVECTOR V) => V.UnaryOp(Math.Sqrt);

	/// <summary>Computes the difference of two vectors.</summary>
	/// <param name="V1">First vector.</param>
	/// <param name="V2">Vector to subtract from <i>V1</i></param>
	/// <returns>Returns a vector that is the difference of <i>V1</i> and <i>V2</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsubtract XMVECTOR XM_CALLCONV
	// XMVectorSubtract( [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSubtract")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSubtract(this FXMVECTOR V1, in FXMVECTOR V2) => V2.BinaryOp(V2, (a, b) => a - b);

	/// <summary>Subtracts two vectors representing angles.</summary>
	/// <param name="V1">First vector of angles. Each angle must satisfy -XM_PI &lt;= <i>V1</i> &lt; XM_PI.</param>
	/// <param name="V2">Second vector of angles. Each angle must satisfy -XM_2PI &lt;= <i>V1</i> &lt; XM_2PI.</param>
	/// <returns>
	/// Returns a vector whose components are the differences of the angles of the corresponding components. Each component of the returned
	/// vector will be an angle less than XM_PI and greater than or equal to -XM_PI.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsubtractangles XMVECTOR XM_CALLCONV
	// XMVectorSubtractAngles( [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSubtractAngles")]
	public static XMVECTOR XMVectorSubtractAngles(this FXMVECTOR V1, in FXMVECTOR V2)
	{
		// Subtract the given angles. If the range of V1 is such that -Pi <= V1 < Pi and the range of V2 is such that
		// -2Pi <= V2 <= 2Pi, then the range of the resulting angle will be -Pi <= Result < Pi.
		XMVECTOR Result = XMVectorSubtract(V1, V2);

		XMVECTOR Mask = XMVectorLess(Result, XMVECTOR.g_XMNegativePi);
		XMVECTOR Offset = XMVectorSelect(XMVECTOR.g_XMZero, XMVECTOR.g_XMTwoPi, Mask);

		Mask = XMVectorGreaterOrEqual(Result, XMVECTOR.g_XMPi);
		Offset = XMVectorSelect(Offset, XMVECTOR.g_XMNegativeTwoPi, Mask);

		return XMVectorAdd(Result, Offset);
	}

	/// <summary>
	/// Computes the horizontal sum of the components of an <c>XMVECTOR</c>. The horizontal sum is the result of adding each component in
	/// the vector together.
	/// </summary>
	/// <param name="V">Vector for which to compute the horizontal sum.</param>
	/// <returns>Returns a vector whose components are the horizontal sum of the components of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// Note that for SSE/SSE2, horizonal sums require a number of math and shuffle operations. If you enable SSE3 (via defining
	/// <c>_XM_SSE3_INTRINSICS_</c>, <c>/arch:AVX</c>, or <c>/arch:AVX2</c>) -or- if using Windows on ARM/ARM64, this function can make use
	/// of horizonal sum intrinsics.
	/// </para>
	/// <para>
	/// <para>This is new to DirectXMath 3.10</para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorsum XMVECTOR XM_CALLCONV XMVectorSum( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSum")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorSum(this FXMVECTOR V) => new(V.x + V.y + V.z + V.w);

	/// <summary>Swizzles a vector.</summary>
	/// <param name="V">Vector to swizzle.</param>
	/// <param name="E0">
	/// Index that describes which component of <i>V</i> to place in the x-component of the swizzled vector. A value of 0 selects the
	/// x-component, 1 selects the y-component, 2 selects the z-component, and 3 selects the w-component.
	/// </param>
	/// <param name="E1">
	/// Index that describes which component of <i>V</i> to place in the y-component of the swizzled vector. A value of 0 selects the
	/// x-component, 1 selects the y-component, 2 selects the z-component, and 3 selects the w-component.
	/// </param>
	/// <param name="E2">
	/// Index that describes which component of <i>V</i> to place in the z-component of the swizzled vector. A value of 0 selects the
	/// x-component, 1 selects the y-component, 2 selects the z-component, and 3 selects the w-component.
	/// </param>
	/// <param name="E3">
	/// Index that describes which component of <i>V</i> to place in the w-component of the swizzled vector. A value of 0 selects the
	/// x-component, 1 selects the y-component, 2 selects the z-component, and 3 selects the w-component.
	/// </param>
	/// <returns>Returns the swizzled <c>XMVECTOR</c>.</returns>
	/// <remarks>
	/// <para>The following code demonstrates how this function might be used.</para>
	/// <para><c>XMVECTOR v = XMVectorSet( 10.0f, 20.0f, 30.0f, 40.0f ); XMVECTOR result = XMVectorSwizzle(v, 3, 3, 0, 2 );</c></para>
	/// <para>The swizzled vector ( <i>result</i>) will be &lt;40.0f, 40.0f, 10.0f, 30.0f&gt;.</para>
	/// <para>
	/// <c>XM_SWIZZLE_X</c>, <c>XM_SWIZZLE_Y</c>, <c>XM_SWIZZLE_Z</c>, and <c>XM_SWIZZLE_W</c> are constants which evaluate to 0, 1, 2, and
	/// 3 respectively for use with <b>XMVectorSwizzle</b>. This is identical to <c>XM_PERMUTE_0X</c>, <c>XM_PERMUTE_0Y</c>,
	/// <c>XM_PERMUTE_0Z</c>, and <c>XM_PERMUTE_0W</c>.
	/// </para>
	/// <para>For the case of constant indices (E0, E1, E2, E3), it is much more efficient to use the template form of <c>XMVectorSwizzle</c>:</para>
	/// <para>
	/// <c>template&lt;uint32_t SwizzleX, uint32_t SwizzleY, uint32_t SwizzleZ, uint32_t SwizzleW&gt; XMVECTOR XMVectorSwizzle(FXMVECTOR V)
	/// Example: XMVectorSwizzle&lt; 3, 3, 0, 2&gt;(v);</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorswizzle XMVECTOR XM_CALLCONV XMVectorSwizzle(
	// [in] FXMVECTOR V, [in] uint32_t E0, [in] uint32_t E1, [in] uint32_t E2, [in] uint32_t E3 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorSwizzle")]
	public static XMVECTOR XMVectorSwizzle(this FXMVECTOR V, uint E0, uint E1, uint E2, uint E3)
	{
		if (E0 > 3 || E1 > 3 || E2 > 3 || E3 > 3)
			throw new ArgumentOutOfRangeException("E0-E3", "Swizzle element must be between 0 and 3.");
		unsafe { return new(V.u[E0], V.u[E1], V.u[E2], V.u[E3]); }
	}

	/// <summary>Computes the tangent of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the tangent.</param>
	/// <returns>Returns a vector. Each component is the tangent of the corresponding component of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectortan XMVECTOR XM_CALLCONV XMVectorTan( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorTan")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorTan(this FXMVECTOR V) => V.UnaryOp(Math.Tan);

	/// <summary>Estimates the tangent of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the tangent.</param>
	/// <returns>Returns a vector. Each component is an estimate of the tangent of the corresponding component of <i>V</i>.</returns>
	/// <remarks>
	/// <para>
	/// <c>Est</c> functions offer increased performance at the expense of reduced accuracy. <c>Est</c> functions are appropriate for
	/// non-critical calculations where accuracy can be sacrificed for speed. The exact amount of lost accuracy and speed increase are
	/// platform dependent.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectortanest XMVECTOR XM_CALLCONV XMVectorTanEst(
	// [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorTanEst")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorTanEst(this FXMVECTOR V) => XMVectorTan(V);

	/// <summary>Computes the hyperbolic tangent of each component of an <c>XMVECTOR</c>.</summary>
	/// <param name="V">Vector for which to compute the hyperbolic tangent.</param>
	/// <returns>Returns a vector. Each component is the hyperbolic tangent of the corresponding component of <i>V</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectortanh XMVECTOR XM_CALLCONV XMVectorTanH( [in]
	// FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorTanH")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorTanH(this FXMVECTOR V) => V.UnaryOp(Math.Tanh);

	/// <summary>Returns a vector, each of whose components represents true (0xFFFFFFFF).</summary>
	/// <returns>Returns a vector, each of whose components represents true (0xFFFFFFFF).</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectortrueint XMVECTOR XM_CALLCONV XMVectorTrueInt() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorTrueInt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorTrueInt() => new(uint.MaxValue);

	/// <summary>Rounds each component of a vector to the nearest integer value in the direction of zero.</summary>
	/// <param name="V">Vector whose components are to be truncated.</param>
	/// <returns>Returns a vector whose components are rounded to the nearest integer value in the direction of zero.</returns>
	/// <remarks>
	/// <para>The return value is computed based on the following logic, which preserves special values (INF,+INF,NaN,-NaN).</para>
	/// <para>
	/// <c>Result[0] = (fabsf(V[0]) &lt; 8388608.0f) ? ((float)((int32_t)V[0])) : V[0]; Result[1] = (fabsf(V[1]) &lt; 8388608.0f) ?
	/// ((float)((int32_t)V[1])) : V[1]; Result[2] = (fabsf(V[2]) &lt; 8388608.0f) ? ((float)((int32_t)V[2])) : V[2]; Result[3] =
	/// (fabsf(V[3]) &lt; 8388608.0f) ? ((float)((int32_t)V[3])) : V[3];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectortruncate XMVECTOR XM_CALLCONV
	// XMVectorTruncate( [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorTruncate")]
	public static XMVECTOR XMVectorTruncate(this FXMVECTOR V)
	{
		unsafe
		{
			var res = new XMVECTOR();
			for (var i = 0; i < 4; i++)
			{
				if (XMISNAN(V.f[i]))
					res.u[i] = 0x7FC00000;
				else res.f[i] = Math.Abs(V.f[i]) < 8388608.0f ? (int)V.f[i] : V.f[i];
			}
			return res;
		}
	}

	/// <summary>Computes the logical XOR of two vectors, treating each component as an unsigned integer.</summary>
	/// <param name="V1">First vector.</param>
	/// <param name="V2">Second vector.</param>
	/// <returns>Returns a vector, each of whose components are the logical XOR of the corresponding components of <i>V1</i> and <i>V2</i>.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function:</para>
	/// <para>
	/// <c>XMVECTOR Result; Result.x = V1.x ^ V2.x; Result.y = V1.y ^ V2.y; Result.z = V1.z ^ V2.z; Result.w = V1.w ^ V2.w; return Result;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorxorint XMVECTOR XM_CALLCONV XMVectorXorInt(
	// [in] FXMVECTOR V1, [in] FXMVECTOR V2 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorXorInt")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorXorInt(this FXMVECTOR V1, in FXMVECTOR V2) => V1.BinaryIntOp(V2, (u1, u2) => u1 ^ u2);

	/// <summary>Creates the zero vector.</summary>
	/// <returns>Returns the zero vector.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmvectorzero XMVECTOR XM_CALLCONV XMVectorZero() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMVectorZero")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static XMVECTOR XMVectorZero() => XMVECTOR.g_XMZero;

	private static XMVECTOR Compare(in XMVECTOR v1, in XMVECTOR v2, Func<float, float, bool> predicate) =>
		v1.BinaryOp(v2, (a, b) => predicate(a, b) ? uint.MaxValue : 0);

	private static XMVECTOR CompareU(in XMVECTOR v1, in XMVECTOR v2, Func<uint, uint, bool> predicate) =>
		v1.BinaryIntOp(v2, (a, b) => predicate(a, b) ? uint.MaxValue : 0);

}