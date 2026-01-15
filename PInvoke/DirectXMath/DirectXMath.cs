global using CXMVECTOR = Vanara.PInvoke.DirectXMath.XMVECTOR;
global using D3DCOLOR = Vanara.PInvoke.COLORREF;
global using D3DRECT = Vanara.PInvoke.RECT;
global using FXMVECTOR = Vanara.PInvoke.DirectXMath.XMVECTOR;
global using GXMVECTOR = Vanara.PInvoke.DirectXMath.XMVECTOR;
global using HXMVECTOR = Vanara.PInvoke.DirectXMath.XMVECTOR;
global using XMVECTORF32 = Vanara.PInvoke.DirectXMath.XMVECTOR;
global using XMFLOAT2A = Vanara.PInvoke.DirectXMath.XMFLOAT2;
global using XMFLOAT3A = Vanara.PInvoke.DirectXMath.XMFLOAT3;
global using XMFLOAT4A = Vanara.PInvoke.DirectXMath.XMFLOAT4;
global using XMFLOAT3X4A = Vanara.PInvoke.DirectXMath.XMFLOAT3X4;
global using XMFLOAT4X3A = Vanara.PInvoke.DirectXMath.XMFLOAT4X3;
global using CXMMATRIX = Vanara.PInvoke.DirectXMath.XMMATRIX;
global using FXMMATRIX = Vanara.PInvoke.DirectXMath.XMMATRIX;
global using XMFLOAT4X4 = Vanara.PInvoke.DirectXMath.XMMATRIX;
global using XMFLOAT4X4A = Vanara.PInvoke.DirectXMath.XMMATRIX;

namespace Vanara.PInvoke;

/// <summary>
/// <para>The DirectXMath API provides SIMD-friendly C++ types and functions for common linear algebra and graphics math operations common to DirectX applications. The library provides optimized versions for Windows 32-bit (x86), Windows 64-bit (x64), and Windows on ARM/ARM64 through SSE, AVX, and ARM-NEON intrinsics support in the Visual C++ compiler.</para>
/// <para>For developers new to DirectXMath, you may want to consider using the SimpleMath wrapper in the DirectX Tool Kit for <c>DirectX 11</c> / <c>DirectX12</c> as a starting point.</para>
/// </summary>
public static partial class DirectXMath
{
	/// <summary>An optimal representation of 1/2π.</summary>
	public const float XM_1DIV2PI = 0.159154943f;

	/// <summary>TAn optimal representation of 1/π.</summary>
	public const float XM_1DIVPI = 0.318309886f;

	/// <summary>An optimal representation of 2*π.</summary>
	public const float XM_2PI = 6.283185307f;

	/// <summary>
	/// Mask to get a comparison result, which is typically retrieved using a recording version of an DirectXMath function such
	/// XMVector4EqualR. The following example gets the comparison result from the variable CR:
	/// <code language="cpp">uint32_t val = ((CR) &amp; XM_CRMASK_CR6);</code>
	/// </summary>
	public const uint XM_CRMASK_CR6 = 0x000000F0;

	/// <summary>
	/// Mask to get a comparison result, and verify if the result indicates that some of the inputs were out of bounds. The value is
	/// typically retrieved using a recording version of a DirectXMath function such as XMVector4EqualR. The example checks if the variable
	/// CR indicates and out of bounds state.
	/// <code language="cpp">bool val = (((CR) &amp; XM_CRMASK_CR6BOUNDS) == XM_CRMASK_CR6BOUNDS);</code>
	/// <para>See also XMComparisonAllInBounds and XMComparisonAnyOutOfBounds</para>
	/// </summary>
	public const uint XM_CRMASK_CR6BOUNDS = XM_CRMASK_CR6FALSE;

	/// <summary>
	/// Mask to get a comparison result, and verify if it is a logical false. The value is typically retrieved using a recording version of
	/// a DirectXMath function such as XMVector4EqualR. The example checks if the variableq CR is false:
	/// <code language="cpp">bool val = (((CR) &amp; XM_CRMASK_CR6FALSE) == XM_CRMASK_CR6FALSE);</code>
	/// <para>See also XMComparisonAnyFalse, XMComparisonAllFalse, and XMComparisonMixed</para>
	/// </summary>
	public const uint XM_CRMASK_CR6FALSE = 0x00000020;

	/// <summary>
	/// Mask to get a comparison result, and verify if it is a logical true. The value is typically retrieved using a recording version of a
	/// DirectXMath function such as XMVector4EqualR. The example checks if the variableq CR is true:
	/// <code language="cpp">bool val = (((CR) &amp; XM_CRMASK_CR6TRUE) == XM_CRMASK_CR6TRUE);</code>
	/// <para>See also XMComparisonAnyTrue, XMComparisonAllTrue, and XMComparisonMixed</para>
	/// </summary>
	public const uint XM_CRMASK_CR6TRUE = 0x00000080;

	/// <summary>
	/// A constant used as an element index with XMVectorPermute. This indicates that the W component of the first of the vector arguments
	/// to XMVectorPermute is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_PERMUTE_0W = 3;

	/// <summary>
	/// A constant used as an element index with XMVectorPermute. This indicates that the X component of the first of the vector arguments
	/// to XMVectorPermute is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_PERMUTE_0X = 0;

	/// <summary>
	/// A constant used as an element index with XMVectorPermute. This indicates that the Y component of the first of the vector arguments
	/// to XMVectorPermute is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_PERMUTE_0Y = 1;

	/// <summary>
	/// A constant used as an element index with XMVectorPermute. This indicates that the Z component of the first of the vector arguments
	/// to XMVectorPermute is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_PERMUTE_0Z = 2;

	/// <summary>
	/// A constant used as an element index with XMVectorPermute. This indicates that the W component of the second of the vector arguments
	/// to XMVectorPermute is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_PERMUTE_1W = 7;

	/// <summary>
	/// A constant used as an element index with XMVectorPermute. This indicates that the X component of the second of the vector arguments
	/// to XMVectorPermute is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_PERMUTE_1X = 4;

	/// <summary>
	/// A constant used as an element index with XMVectorPermute. This indicates that the Y component of the second of the vector arguments
	/// to XMVectorPermute is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_PERMUTE_1Y = 5;

	/// <summary>
	/// A constant used as an element index with XMVectorPermute. This indicates that the Z component of the second of the vector arguments
	/// to XMVectorPermute is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_PERMUTE_1Z = 6;

	/// <summary>An optimal representation of π.</summary>
	public const float XM_PI = 3.141592654f;

	/// <summary>An optimal representation of π/2.</summary>
	public const float XM_PIDIV2 = 1.570796327f;

	/// <summary>An optimal representation of π/4.</summary>
	public const float XM_PIDIV4 = 0.785398163f;

	/// <summary>
	/// A constant used to construct a control vector used with XMVectorSelect. Indicates that the component of the first of the vector
	/// arguments to XMVectorSelect is to be copied to the index location in a result vector corresponding to its index in the control vector.
	/// <para>
	/// For example, a control vector with XM_SELECT_0 as its second component copies the second component of the first vector to the second
	/// component of the result vector.
	/// </para>
	/// </summary>
	public const uint XM_SELECT_0 = 0x00000000;

	/// <summary>
	/// A constant used to construct a control vector used with XMVectorSelect. Indicates that the component of the second of the vector
	/// arguments to XMVectorSelect is to be copied to the index location in a result vector corresponding to its index in the control vector.
	/// <para>
	/// For example, a control vector with XM_SELECT_1 as its second component copies the second component of the second vector to the
	/// second component of the result vector.
	/// </para>
	/// </summary>
	public const uint XM_SELECT_1 = 0xFFFFFFFF;

	/// <summary>
	/// A constant used as an element index with XMVectorSwizzle. This indicates that the W component of the vector argument to
	/// XMVectorSwizzle is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_SWIZZLE_W = 3;

	/// <summary>
	/// A constant used as an element index with XMVectorSwizzle. This indicates that the X component of the vector argument to
	/// XMVectorSwizzle is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_SWIZZLE_X = 0;

	/// <summary>
	/// A constant used as an element index with XMVectorSwizzle. This indicates that the Y component of the vector argument to
	/// XMVectorSwizzle is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_SWIZZLE_Y = 1;

	/// <summary>
	/// A constant used as an element index with XMVectorSwizzle. This indicates that the Z component of the vector argument to
	/// XMVectorSwizzle is to be copied to the index location in a result vector corresponding to the specified element.
	/// </summary>
	public const uint XM_SWIZZLE_Z = 2;

	/// <summary/>
	public static readonly SIZE_T XM_CACHE_LINE_SIZE = IntPtr.Size * 16;

	/// <summary>
	/// <para>A 2D vector consisting of two single-precision floating-point values.</para>
	/// <para>
	/// For a list of additional functionality such as constructors and operators that are available using <c>XMFLOAT2</c> when you are
	/// programming in C++, see <c>XMFLOAT2 Extensions</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  See <c>DirectXMath Library Type Equivalences</c> for information about equivalent <c>D3DDECLTYPE</c>, <c>D3DFORMAT</c>,
	/// and <c>DXGI_FORMAT</c> objects.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para><c>XMFLOAT2</c> can be loaded into instances of <c>XMVECTOR</c> by using <c>XMLoadFloat2</c>.</para>
	/// <para>Instances of <c>XMVECTOR</c> can be stored into an instance of <c>XMFLOAT2</c> with <c>XMStoreFloat2</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmfloat2 struct XMFLOAT2 { float x; float y; void
	// XMFLOAT2(); void XMFLOAT2( const XMFLOAT2 &amp; unnamedParam1 ); XMFLOAT2 &amp; operator=( const XMFLOAT2 &amp; unnamedParam1 ); void
	// XMFLOAT2( XMFLOAT2 &amp;&amp; unnamedParam1 ); XMFLOAT2 &amp; operator=( XMFLOAT2 &amp;&amp; unnamedParam1 ); void XMFLOAT2( float
	// _x, float _y ) noexcept; void XMFLOAT2( const float *pArray ) noexcept; bool operator==( const XMFLOAT2 &amp; unnamedParam1 ); auto
	// operator&lt;=&gt;( const XMFLOAT2 &amp; unnamedParam1 ); };
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMFLOAT2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMFLOAT2(float x = 0f, float y = 0f) : IEquatable<XMFLOAT2>
	{
		/// <summary><b>float</b> value describing the x-coordinate of the vector.</summary>
		public float x = x;

		/// <summary><b>float</b> value describing the y-coordinate of the vector.</summary>
		public float y = y;

		/// <summary>Initializes a new instance of the <see cref="XMFLOAT2"/> struct.</summary>
		/// <param name="pArray">An array for four values consecutively applied to x and y.</param>
		/// <exception cref="ArgumentException">Array must have 2 elements. - pArray</exception>
		public XMFLOAT2(float[] pArray) :
			this(pArray?.Length == 2 ? pArray[0] : throw new ArgumentException("Array must have 2 elements.", nameof(pArray)), pArray[1])
		{ }

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMFLOAT2 xMFLOAT && Equals(xMFLOAT);

		/// <inheritdoc/>
		public bool Equals(XMFLOAT2 other) => x == other.x && y == other.y;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y).GetHashCode();

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMFLOAT2 left, XMFLOAT2 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMFLOAT2 left, XMFLOAT2 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="float"/>[] to <see cref="XMFLOAT2"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMFLOAT2(float[] v) => new(v);
	}

	/// <summary>
	/// <para>Describes a 3D vector consisting of three single-precision floating-point values.</para>
	/// <para>
	/// For a list of additional functionality such as constructors and operators that are available using <c>XMFLOAT3</c> when you are
	/// programming in C++, see <c>XMFLOAT3 Extensions</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  See <c>DirectXMath Library Type Equivalences</c> for information about equivalent <c>D3DDECLTYPE</c>, <c>D3DFORMAT</c>,
	/// and <c>DXGI_FORMAT</c> objects.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para><c>XMFLOAT3</c> can be loaded into instances of <c>XMVECTOR</c> by using <c>XMLoadFloat3</c>.</para>
	/// <para>Instances of <c>XMVECTOR</c> can be stored into an instance of <c>XMFLOAT3</c> with <c>XMStoreFloat3</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmfloat3 struct XMFLOAT3 { float x; float y; float z;
	// void XMFLOAT3(); void XMFLOAT3( const XMFLOAT3 &amp; unnamedParam1 ); XMFLOAT3 &amp; operator=( const XMFLOAT3 &amp; unnamedParam1 );
	// void XMFLOAT3( XMFLOAT3 &amp;&amp; unnamedParam1 ); XMFLOAT3 &amp; operator=( XMFLOAT3 &amp;&amp; unnamedParam1 ); void XMFLOAT3(
	// float _x, float _y, float _z ) noexcept; void XMFLOAT3( const float *pArray ) noexcept; };
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMFLOAT3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMFLOAT3(float x = 0f, float y = 0f, float z = 0f) : IEquatable<XMFLOAT3>
	{
		/// <summary><b>float</b> value describing the x-coordinate of the vector.</summary>
		public float x = x;

		/// <summary><b>float</b> value describing the y-coordinate of the vector.</summary>
		public float y = y;

		/// <summary><b>float</b> value describing the z-coordinate of the vector.</summary>
		public float z = z;

		/// <summary>Initializes a new instance of the <see cref="XMFLOAT3"/> struct.</summary>
		/// <param name="pArray">An array for four values consecutively applied to x, y, and z.</param>
		/// <exception cref="ArgumentException">Array must have 3 elements. - pArray</exception>
		public XMFLOAT3(float[] pArray) :
			this(pArray?.Length == 3 ? pArray[0] : throw new ArgumentException("Array must have 3 elements.", nameof(pArray)), pArray[1], pArray[2])
		{ }

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMFLOAT3 xMFLOAT && Equals(xMFLOAT);

		/// <inheritdoc/>
		public bool Equals(XMFLOAT3 other) => x == other.x && y == other.y && z == other.z;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y, z).GetHashCode();

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMFLOAT3 left, XMFLOAT3 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMFLOAT3 left, XMFLOAT3 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="float"/>[] to <see cref="XMFLOAT3"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMFLOAT3(float[] v) => new(v);
	}

	/// <summary>A 3x3 floating-point matrix.</summary>
	/// <remarks>
	/// <para>
	/// The scalar members of <b>XMFLOAT3X3</b> have names that follow the form _&lt;row_number&gt;&lt;column_number&gt; (for example, _11).
	/// They provide 1-based indexing, where row_number specifies the 1-based matrix row (ranging from 1 to 3), and column_number specifies
	/// the 1-based matrix column (ranging from 1 to 3).
	/// </para>
	/// <para>You can load an <c>XMMATRIX</c> from an <b>XMFLOAT3X3</b> by using <c>XMLoadFloat3x3</c>.</para>
	/// <para>You can store an <c>XMMATRIX</c> into an <b>XMFLOAT3X3</b> by using <c>XMStoreFloat3x3</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmfloat3x3
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMFLOAT3X3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMFLOAT3X3 : IEquatable<XMFLOAT3X3>
	{
		const int ccol = 3, crow = 3;

		/// <summary>An element of the matrix.</summary>
		public float _11;

		/// <summary>An element of the matrix.</summary>
		public float _12;

		/// <summary>An element of the matrix.</summary>
		public float _13;

		/// <summary>An element of the matrix.</summary>
		public float _21;

		/// <summary>An element of the matrix.</summary>
		public float _22;

		/// <summary>An element of the matrix.</summary>
		public float _23;

		/// <summary>An element of the matrix.</summary>
		public float _31;

		/// <summary>An element of the matrix.</summary>
		public float _32;

		/// <summary>An element of the matrix.</summary>
		public float _33;

		/// <summary>Initializes a new instance of the <see cref="XMFLOAT3X3"/> struct.</summary>
		/// <param name="pArray">A 3x3 element float array, specifying the value of each member of a new instance of XMFLOAT3X3.</param>
		public XMFLOAT3X3(float[,] pArray)
		{
			if (pArray.GetLength(0) != crow || pArray.GetLength(1) != ccol)
				throw new ArgumentException($"Array must have {crow}x{ccol} elements.", nameof(pArray));
			unsafe
			{
				fixed (float* p = &_11)
					for (var i = 0; i < crow; i++)
						for (var j = 0; j < ccol; j++)
							p[ccol * i + j] = pArray[i, j];
			}
		}

		/// <summary>Initializes a new instance of the <see cref="XMFLOAT3X3"/> struct.</summary>
		/// <param name="m00">Value used to initialize the _11 member (equivalently the m[0,0] member) of the XMFLOAT3X3 structure.</param>
		/// <param name="m01">Value used to initialize the _12 member (equivalently the m[0,1] member) of the XMFLOAT3X3 structure.</param>
		/// <param name="m02">Value used to initialize the _13 member (equivalently the m[0,2] member) of the XMFLOAT3X3 structure.</param>
		/// <param name="m10">Value used to initialize the _21 member (equivalently the m[1,0] member) of the XMFLOAT3X3 structure.</param>
		/// <param name="m11">Value used to initialize the _22 member (equivalently the m[1,1] member) of the XMFLOAT3X3 structure.</param>
		/// <param name="m12">Value used to initialize the _23 member (equivalently the m[1,2] member) of the XMFLOAT3X3 structure.</param>
		/// <param name="m20">Value used to initialize the _31 member (equivalently the m[2,0] member) of the XMFLOAT3X3 structure.</param>
		/// <param name="m21">Value used to initialize the _32 member (equivalently the m[2,1] member) of the XMFLOAT3X3 structure.</param>
		/// <param name="m22">Value used to initialize the _33 member (equivalently the m[2,2] member) of the XMFLOAT3X3 structure.</param>
		public XMFLOAT3X3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22) =>
			(_11, _12, _13, _21, _22, _23, _31, _32, _33) = (m00, m01, m02, m10, m11, m12, m20, m21, m22);

		/// <summary>Gets or sets the <see cref="float"/> with the specified row and column.</summary>
		/// <value>The <see cref="float"/> value.</value>
		/// <param name="row">The row index.</param>
		/// <param name="column">The column index.</param>
		/// <returns>The value.</returns>
		public float this[int row, int column]
		{
			get
			{
				if (row is < 0 or >= crow)
					throw new ArgumentOutOfRangeException(nameof(row), $"Row must be a value between 0 and {crow-1}.");
				if (column is < 0 or >= ccol)
					throw new ArgumentOutOfRangeException(nameof(column), $"Column must be a value between 0 and {ccol-1}.");
				unsafe { fixed (float* p = &_11) return p[ccol * row + column]; }
			}
			set
			{
				if (row is < 0 or >= crow)
					throw new ArgumentOutOfRangeException(nameof(row), $"Row must be a value between 0 and {crow - 1}.");
				if (column is < 0 or >= ccol)
					throw new ArgumentOutOfRangeException(nameof(column), $"Column must be a value between 0 and {ccol - 1}.");
				unsafe { fixed (float* p = &_11) p[ccol * row + column] = value; }
			}
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMFLOAT3X3 m && Equals(m);

		/// <inheritdoc/>
		public bool Equals(XMFLOAT3X3 other)
		{
			unsafe
			{
				fixed (float* f = &_11)
					for (var i = 0; i < crow * ccol; i++)
						if (f[i] != (&other._11)[i])
							return false;
			}
			return true;
		}

		/// <inheritdoc/>
		public override int GetHashCode() => ToArray().GetHashCode();

		/// <summary>Exposes the matrix as a 3x3 array.</summary>
		/// <returns>A 3x3 array.</returns>
		public float[,] ToArray()
		{
			float[,] ret = new float[crow, ccol];
			unsafe
			{
				fixed (float* f = &_11)
					for (var i = 0; i < crow; i++)
						for (var j = 0; j < ccol; j++)
							ret[i, j] = f[ccol * i + j];
			}
			return ret;
		}

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMFLOAT3X3 left, XMFLOAT3X3 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMFLOAT3X3 left, XMFLOAT3X3 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="float"/>[] to <see cref="XMFLOAT3X3"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMFLOAT3X3(float[,] v) => new(v);
	}

	/// <summary>A 3x4 floating-point matrix.</summary>
	/// <remarks>
	/// <para>
	/// The scalar members of <b>XMFLOAT3X4</b> have names that follow the form _&lt;row_number&gt;&lt;column_number&gt; (for example, _11).
	/// They provide 1-based indexing, where row_number specifies the 1-based matrix row (ranging from 1 to 3), and column_number specifies
	/// the 1-based matrix column (ranging from 1 to 4).
	/// </para>
	/// <para>You can load an <c>XMMATRIX</c> from an <b>XMFLOAT3X4</b> by using <c>XMLoadFloat3x4</c>.</para>
	/// <para>You can store an <c>XMMATRIX</c> into an <b>XMFLOAT3X4</b> by using <c>XMStoreFloat3x4</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmfloat3x4
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMFLOAT3X4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMFLOAT3X4 : IEquatable<XMFLOAT3X4>
	{
		const int crow = 3, ccol = 4;

		/// <summary>An element of the matrix.</summary>
		public float _11;

		/// <summary>An element of the matrix.</summary>
		public float _12;

		/// <summary>An element of the matrix.</summary>
		public float _13;

		/// <summary>An element of the matrix.</summary>
		public float _14;

		/// <summary>An element of the matrix.</summary>
		public float _21;

		/// <summary>An element of the matrix.</summary>
		public float _22;

		/// <summary>An element of the matrix.</summary>
		public float _23;

		/// <summary>An element of the matrix.</summary>
		public float _24;

		/// <summary>An element of the matrix.</summary>
		public float _31;

		/// <summary>An element of the matrix.</summary>
		public float _32;

		/// <summary>An element of the matrix.</summary>
		public float _33;

		/// <summary>An element of the matrix.</summary>
		public float _34;

		/// <summary>Initializes a new instance of the <see cref="XMFLOAT3X4"/> struct.</summary>
		/// <param name="pArray">A 3x4 element float array, specifying the value of each member of a new instance of XMFLOAT3X4.</param>
		public XMFLOAT3X4(float[,] pArray)
		{
			if (pArray.GetLength(0) != crow || pArray.GetLength(1) != ccol)
				throw new ArgumentException($"Array must have {crow}x{ccol} elements.", nameof(pArray));
			unsafe
			{
				fixed (float* p = &_11)
					for (var i = 0; i < crow; i++)
						for (var j = 0; j < ccol; j++)
							p[ccol * i + j] = pArray[i, j];
			}
		}

		/// <summary>Initializes a new instance of the <see cref="XMFLOAT3X4"/> struct.</summary>
		/// <param name="m00">Value used to initialize the _11 member (equivalently the m[0,0] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m01">Value used to initialize the _12 member (equivalently the m[0,1] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m02">Value used to initialize the _13 member (equivalently the m[0,2] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m03">Value used to initialize the _14 member (equivalently the m[0,3] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m10">Value used to initialize the _21 member (equivalently the m[1,0] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m11">Value used to initialize the _22 member (equivalently the m[1,1] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m12">Value used to initialize the _23 member (equivalently the m[1,2] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m13">Value used to initialize the _24 member (equivalently the m[1,3] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m20">Value used to initialize the _31 member (equivalently the m[2,0] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m21">Value used to initialize the _32 member (equivalently the m[2,1] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m22">Value used to initialize the _33 member (equivalently the m[2,2] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m23">Value used to initialize the _34 member (equivalently the m[2,3] member) of the XMFLOAT3X4 structure.</param>
		public XMFLOAT3X4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23) =>
			(_11, _12, _13, _14, _21, _22, _23, _24, _31, _32, _33, _34) = (m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23);

		/// <summary>Gets or sets the <see cref="float"/> with the specified row and column.</summary>
		/// <value>The <see cref="float"/> value.</value>
		/// <param name="row">The row index.</param>
		/// <param name="column">The column index.</param>
		/// <returns>The value.</returns>
		public float this[int row, int column]
		{
			get
			{
				if (row is < 0 or >= crow)
					throw new ArgumentOutOfRangeException(nameof(row), $"Row must be a value between 0 and {crow-1}.");
				if (column is < 0 or >= ccol)
					throw new ArgumentOutOfRangeException(nameof(column), $"Column must be a value between 0 and {ccol-1}.");
				unsafe { fixed (float* p = &_11) return p[ccol * row + column]; }
			}
			set
			{
				if (row is < 0 or >= crow)
					throw new ArgumentOutOfRangeException(nameof(row), $"Row must be a value between 0 and {crow - 1}.");
				if (column is < 0 or >= ccol)
					throw new ArgumentOutOfRangeException(nameof(column), $"Column must be a value between 0 and {ccol - 1}.");
				unsafe { fixed (float* p = &_11) p[ccol * row + column] = value; }
			}
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMFLOAT3X4 m && Equals(m);

		/// <inheritdoc/>
		public bool Equals(XMFLOAT3X4 other)
		{
			unsafe
			{
				fixed (float* f = &_11)
					for (var i = 0; i < crow * ccol; i++)
						if (f[i] != (&other._11)[i])
							return false;
			}
			return true;
		}

		/// <inheritdoc/>
		public override int GetHashCode() => ToArray().GetHashCode();

		/// <summary>Exposes the matrix as a 3x4 array.</summary>
		/// <returns>A 3x4 array.</returns>
		public float[,] ToArray()
		{
			float[,] ret = new float[crow, ccol];
			unsafe
			{
				fixed (float* f = &_11)
					for (var i = 0; i < crow; i++)
						for (var j = 0; j < ccol; j++)
							ret[i, j] = f[ccol * i + j];
			}
			return ret;
		}

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMFLOAT3X4 left, XMFLOAT3X4 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMFLOAT3X4 left, XMFLOAT3X4 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="float"/>[] to <see cref="XMFLOAT3X4"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMFLOAT3X4(float[,] v) => new(v);
	}

	/// <summary>A 4x3 floating-point matrix.</summary>
	/// <remarks>
	/// <para>
	/// The scalar members of <b>XMFLOAT4X3</b> have names that follow the form _&lt;row_number&gt;&lt;column_number&gt; (for example, _11).
	/// They provide 1-based indexing, where row_number specifies the 1-based matrix row (ranging from 1 to 4), and column_number specifies
	/// the 1-based matrix column (ranging from 1 to 3).
	/// </para>
	/// <para>You can load an <c>XMMATRIX</c> from an <b>XMFLOAT4X3</b> by using <c>XMLoadFloat4x3</c>.</para>
	/// <para>You can store an <c>XMMATRIX</c> into an <b>XMFLOAT4X3</b> by using <c>XMStoreFloat4x3</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmfloat4x3
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMFLOAT4X3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMFLOAT4X3 : IEquatable<XMFLOAT4X3>
	{
		const int crow = 4, ccol = 3;

		/// <summary>An element of the matrix.</summary>
		public float _11;

		/// <summary>An element of the matrix.</summary>
		public float _12;

		/// <summary>An element of the matrix.</summary>
		public float _13;

		/// <summary>An element of the matrix.</summary>
		public float _21;

		/// <summary>An element of the matrix.</summary>
		public float _22;

		/// <summary>An element of the matrix.</summary>
		public float _23;

		/// <summary>An element of the matrix.</summary>
		public float _31;

		/// <summary>An element of the matrix.</summary>
		public float _32;

		/// <summary>An element of the matrix.</summary>
		public float _33;

		/// <summary>An element of the matrix.</summary>
		public float _41;

		/// <summary>An element of the matrix.</summary>
		public float _42;

		/// <summary>An element of the matrix.</summary>
		public float _43;

		/// <summary>Initializes a new instance of the <see cref="XMFLOAT4X3"/> struct.</summary>
		/// <param name="pArray">A 4x3 element float array, specifying the value of each member of a new instance of XMFLOAT4X3.</param>
		public XMFLOAT4X3(float[,] pArray)
		{
			if (pArray.GetLength(0) != crow || pArray.GetLength(1) != ccol)
				throw new ArgumentException($"Array must have {crow}x{ccol} elements.", nameof(pArray));
			unsafe
			{
				fixed (float* p = &_11)
					for (var i = 0; i < crow; i++)
						for (var j = 0; j < ccol; j++)
							p[ccol * i + j] = pArray[i, j];
			}
		}

		/// <summary>Initializes a new instance of the <see cref="XMFLOAT4X3"/> struct.</summary>
		/// <param name="m00">Value used to initialize the _11 member (equivalently the m[0,0] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m01">Value used to initialize the _12 member (equivalently the m[0,1] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m02">Value used to initialize the _13 member (equivalently the m[0,2] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m10">Value used to initialize the _21 member (equivalently the m[1,0] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m11">Value used to initialize the _22 member (equivalently the m[1,1] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m12">Value used to initialize the _23 member (equivalently the m[1,2] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m20">Value used to initialize the _31 member (equivalently the m[2,0] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m21">Value used to initialize the _32 member (equivalently the m[2,1] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m22">Value used to initialize the _33 member (equivalently the m[2,2] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m30">Value used to initialize the _41 member (equivalently the m[3,0] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m31">Value used to initialize the _42 member (equivalently the m[3,1] member) of the XMFLOAT3X4 structure.</param>
		/// <param name="m32">Value used to initialize the _43 member (equivalently the m[3,2] member) of the XMFLOAT3X4 structure.</param>
		public XMFLOAT4X3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22, float m30, float m31, float m32) =>
			(_11, _12, _13, _21, _22, _23, _31, _32, _33, _41, _42, _43) = (m00, m01, m02, m10, m11, m12, m20, m21, m22, m30, m31, m32);

		/// <summary>Gets or sets the <see cref="float"/> with the specified row and column.</summary>
		/// <value>The <see cref="float"/> value.</value>
		/// <param name="row">The row index.</param>
		/// <param name="column">The column index.</param>
		/// <returns>The value.</returns>
		public float this[int row, int column]
		{
			get
			{
				if (row is < 0 or >= crow)
					throw new ArgumentOutOfRangeException(nameof(row), $"Row must be a value between 0 and {crow-1}.");
				if (column is < 0 or >= ccol)
					throw new ArgumentOutOfRangeException(nameof(column), $"Column must be a value between 0 and {ccol-1}.");
				unsafe { fixed (float* p = &_11) return p[ccol * row + column]; }
			}
			set
			{
				if (row is < 0 or >= crow)
					throw new ArgumentOutOfRangeException(nameof(row), $"Row must be a value between 0 and {crow - 1}.");
				if (column is < 0 or >= ccol)
					throw new ArgumentOutOfRangeException(nameof(column), $"Column must be a value between 0 and {ccol - 1}.");
				unsafe { fixed (float* p = &_11) p[ccol * row + column] = value; }
			}
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMFLOAT4X3 m && Equals(m);

		/// <inheritdoc/>
		public bool Equals(XMFLOAT4X3 other)
		{
			unsafe
			{
				fixed (float* f = &_11)
					for (var i = 0; i < crow * ccol; i++)
						if (f[i] != (&other._11)[i])
							return false;
			}
			return true;
		}

		/// <inheritdoc/>
		public override int GetHashCode() => ToArray().GetHashCode();

		/// <summary>Exposes the matrix as a 4x3 array.</summary>
		/// <returns>A 4x3 array.</returns>
		public float[,] ToArray()
		{
			float[,] ret = new float[crow, ccol];
			unsafe
			{
				fixed (float* f = &_11)
					for (var i = 0; i < crow; i++)
						for (var j = 0; j < ccol; j++)
							ret[i, j] = f[ccol * i + j];
			}
			return ret;
		}

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMFLOAT4X3 left, XMFLOAT4X3 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMFLOAT4X3 left, XMFLOAT4X3 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="float"/>[] to <see cref="XMFLOAT4X3"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMFLOAT4X3(float[,] v) => new(v);
	}

	/// <summary>
	/// <para>Describes a 4D vector consisting of four single-precision floating-point values.</para>
	/// <para>
	/// For a list of additional functionality such as constructors and operators that are available using <c>XMFLOAT4</c> when you are
	/// programming in C++, see <c>XMFLOAT4 Extensions</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  See <c>DirectXMath Library Type Equivalences</c> for information about equivalent <c>D3DDECLTYPE</c>, <c>D3DFORMAT</c>,
	/// and <c>DXGI_FORMAT</c> objects.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para><c>XMFLOAT4</c> can be loaded into instances of <c>XMVECTOR</c> by using <c>XMLoadFloat4</c>.</para>
	/// <para>Instances of <c>XMVECTOR</c> can be stored into an instance of <c>XMFLOAT4</c> with <c>XMStoreFloat4</c>.</para>
	/// <para><b>Namespace:</b> Use DirectX</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmfloat4 struct XMFLOAT4 { float x; float y; float z;
	// float w; void XMFLOAT4(); void XMFLOAT4( const XMFLOAT4 &amp; unnamedParam1 ); XMFLOAT4 &amp; operator=( const XMFLOAT4 &amp;
	// unnamedParam1 ); void XMFLOAT4( XMFLOAT4 &amp;&amp; unnamedParam1 ); XMFLOAT4 &amp; operator=( XMFLOAT4 &amp;&amp; unnamedParam1 );
	// void XMFLOAT4( float _x, float _y, float _z, float _w ) noexcept; void XMFLOAT4( const float *pArray ) noexcept; bool operator==(
	// const XMFLOAT4 &amp; unnamedParam1 ); auto operator&lt;=&gt;( const XMFLOAT4 &amp; unnamedParam1 ); };
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMFLOAT4")]
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	public struct XMFLOAT4 : IEquatable<XMFLOAT4>
	{
		/// <summary><b>float</b> value describing the x-coordinate of the vector.</summary>
		public float x;

		/// <summary><b>float</b> value describing the y-coordinate of the vector.</summary>
		public float y;

		/// <summary><b>float</b> value describing the z-coordinate of the vector.</summary>
		public float z;

		/// <summary><b>float</b> value describing the w-coordinate of the vector.</summary>
		public float w;

		/// <summary>Initializes a new instance of the <see cref="XMFLOAT4"/> struct.</summary>
		/// <param name="x">The x-coordinate of the vector.</param>
		/// <param name="y">The y-coordinate of the vector.</param>
		/// <param name="z">The z-coordinate of the vector.</param>
		/// <param name="w">The w-coordinate of the vector.</param>
		public XMFLOAT4(float x, float y, float z, float w) : this() => (this.x, this.y, this.z, this.w) = (x, y, z, w);

		/// <summary>Initializes a new instance of the <see cref="XMFLOAT4"/> struct.</summary>
		/// <param name="pArray">An array for four values consecutively applied to x, y, z, and w.</param>
		/// <exception cref="ArgumentException">Array must have 4 elements. - pArray</exception>
		public XMFLOAT4(float[] pArray) : this()
		{
			if (pArray is null || pArray.Length != 4)
				throw new ArgumentException("Array must have 4 elements.", nameof(pArray));
			(x, y, z, w) = (pArray[0], pArray[1], pArray[2], pArray[3]);
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMFLOAT4 xMFLOAT && Equals(xMFLOAT);

		/// <inheritdoc/>
		public bool Equals(XMFLOAT4 other) => x == other.x && y == other.y && z == other.z && w == other.w;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y, z, w).GetHashCode();

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMFLOAT4 left, XMFLOAT4 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMFLOAT4 left, XMFLOAT4 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="float"/>[] to <see cref="XMFLOAT4"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator XMFLOAT4(float[] v) => new(v);

		/// <summary>Performs an implicit conversion from <see cref="XMFLOAT4"/> to <see cref="float"/>[].</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[](XMFLOAT4 v) => [v.x, v.y, v.z, v.w];

		/// <summary>Implements the operator +.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMFLOAT4 operator +(XMFLOAT4 left, XMFLOAT4 right) => new(left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);

		/// <summary>Implements the operator -.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMFLOAT4 operator -(XMFLOAT4 left, XMFLOAT4 right) => new(left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);

		/// <summary>Implements the operator *.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMFLOAT4 operator *(XMFLOAT4 left, XMFLOAT4 right) => new(left.x * right.x, left.y * right.y, left.z * right.z, left.w * right.w);

		/// <summary>Implements the operator /.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMFLOAT4 operator /(XMFLOAT4 left, XMFLOAT4 right) => new(left.x / right.x, left.y / right.y, left.z / right.z, left.w / right.w);

		/// <summary>Implements the operator *.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMFLOAT4 operator *(XMFLOAT4 left, float right) => new(left.x * right, left.y * right, left.z * right, left.w * right);

		/// <summary>Implements the operator /.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMFLOAT4 operator /(XMFLOAT4 left, float right) => new(left.x / right, left.y / right, left.z / right, left.w / right);

		/// <summary>Implements the operator *.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMFLOAT4 operator *(float left, XMFLOAT4 right) => new(left * right.x, left * right.y, left * right.z, left * right.w);
	}

	/// <summary>
	/// <para>A 2D vector where each component is a signed integer.</para>
	/// <para>
	/// For a list of more functionality such as constructors and operators that are available using <c>XMINT2</c> when you are programming
	/// in C++, see <c>XMINT2 Extensions</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  See <c>DirectXMath Library Type Equivalences</c> for information about equivalent <c>D3DDECLTYPE</c>, <c>D3DFORMAT</c>,
	/// and <c>DXGI_FORMAT</c> objects.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>You can use <c>XMLoadSInt2</c> to load <c>XMINT2</c> into instances of <c>XMVECTOR</c>.</para>
	/// <para>You can use <c>XMStoreSInt2</c> to store instances of <c>XMVECTOR</c> into an instance of <c>XMINT2</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmint2 struct XMINT2 { int32_t x; int32_t y; void
	// XMINT2(); void XMINT2( const XMINT2 &amp; unnamedParam1 ); XMINT2 &amp; operator=( const XMINT2 &amp; unnamedParam1 ); void XMINT2(
	// XMINT2 &amp;&amp; unnamedParam1 ); XMINT2 &amp; operator=( XMINT2 &amp;&amp; unnamedParam1 ); void XMINT2( int32_t _x, int32_t _y )
	// noexcept; void XMINT2( const int32_t *pArray ) noexcept; bool operator==( const XMINT2 &amp; unnamedParam1 ); auto operator&lt;=&gt;(
	// const XMINT2 &amp; unnamedParam1 ); };
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMINT2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMINT2(int x = 0, int y = 0) : IEquatable<XMINT2>
	{
		/// <summary>Signed integer value describing the x coordinate of the vector.</summary>
		public int x = x;

		/// <summary>Signed integer value describing the y coordinate of the vector.</summary>
		public int y = y;

		/// <summary>Initializes a new instance of the <see cref="XMINT2"/> struct.</summary>
		/// <param name="pArray">An array for values consecutively applied to x and y.</param>
		/// <exception cref="ArgumentException">Array must have 2 elements. - pArray</exception>
		public XMINT2(int[] pArray) :
			this(pArray?.Length == 2 ? pArray[0] : throw new ArgumentException("Array must have 2 elements.", nameof(pArray)), pArray[1])
		{ }

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMINT2 v && Equals(v);

		/// <inheritdoc/>
		public bool Equals(XMINT2 other) => x == other.x && y == other.y;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y).GetHashCode();

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMINT2 left, XMINT2 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMINT2 left, XMINT2 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="int"/>[] to <see cref="XMINT2"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMINT2(int[] v) => new(v);
	}

	/// <summary>
	/// <para>A 3D vector where each component is a signed integer.</para>
	/// <para>
	/// For a list of more functionality such as constructors and operators that are available using <c>XMINT3</c> when you are programming
	/// in C++, see <c>XMINT3 Extensions</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  See <c>DirectXMath Library Type Equivalences</c> for information about equivalent <c>D3DDECLTYPE</c>, <c>D3DFORMAT</c>,
	/// and <c>DXGI_FORMAT</c> objects.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>You can use <c>XMLoadSInt3</c> to load <c>XMINT3</c> into instances of <c>XMVECTOR</c>.</para>
	/// <para>You can use <c>XMStoreSInt3</c> to store instances of <c>XMVECTOR</c> into an instance of <c>XMINT3</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmint3 struct XMINT3 { int32_t x; int32_t y; int32_t
	// z; void XMINT3(); void XMINT3( const XMINT3 &amp; unnamedParam1 ); XMINT3 &amp; operator=( const XMINT3 &amp; unnamedParam1 ); void
	// XMINT3( XMINT3 &amp;&amp; unnamedParam1 ); XMINT3 &amp; operator=( XMINT3 &amp;&amp; unnamedParam1 ); void XMINT3( int32_t _x,
	// int32_t _y, int32_t _z ) noexcept; void XMINT3( const int32_t *pArray ) noexcept; bool operator==( const XMINT3 &amp; unnamedParam1
	// ); auto operator&lt;=&gt;( const XMINT3 &amp; unnamedParam1 ); };
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMINT3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMINT3(int x = 0, int y = 0, int z = 0) : IEquatable<XMINT3>
	{
		/// <summary>Signed integer value describing the x coordinate of the vector.</summary>
		public int x = x;

		/// <summary>Signed integer value describing the y coordinate of the vector.</summary>
		public int y = y;

		/// <summary>Signed integer value describing the z coordinate of the vector.</summary>
		public int z = z;

		/// <summary>Initializes a new instance of the <see cref="XMINT3"/> struct.</summary>
		/// <param name="pArray">An array for four values consecutively applied to x, y, and z.</param>
		/// <exception cref="ArgumentException">Array must have 3 elements. - pArray</exception>
		public XMINT3(int[] pArray) :
			this(pArray?.Length == 3 ? pArray[0] : throw new ArgumentException("Array must have 3 elements.", nameof(pArray)), pArray[1], pArray[2])
		{ }

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMINT3 xMFLOAT && Equals(xMFLOAT);

		/// <inheritdoc/>
		public bool Equals(XMINT3 other) => x == other.x && y == other.y && z == other.z;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y, z).GetHashCode();

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMINT3 left, XMINT3 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMINT3 left, XMINT3 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="int"/>[] to <see cref="XMINT3"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMINT3(int[] v) => new(v);
	}

	/// <summary>
	/// <para>A 4D vector where each component is a signed integer.</para>
	/// <para>
	/// For a list of more functionality such as constructors and operators that are available using <c>XMINT4</c> when you are programming
	/// in C++, see <c>XMINT4 Extensions</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  See <c>DirectXMath Library Type Equivalences</c> for information about equivalent <c>D3DDECLTYPE</c>, <c>D3DFORMAT</c>,
	/// and <c>DXGI_FORMAT</c> objects.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>You can use <c>XMLoadSInt4</c> to load <c>XMINT4</c> into instances of <c>XMVECTOR</c>.</para>
	/// <para>You can use <c>XMStoreSInt4</c> to store instances of <c>XMVECTOR</c> into an instance of <c>XMINT4</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmint4 struct XMINT4 { int32_t x; int32_t y; int32_t
	// z; int32_t w; void XMINT4(); void XMINT4( const XMINT4 &amp; unnamedParam1 ); XMINT4 &amp; operator=( const XMINT4 &amp;
	// unnamedParam1 ); void XMINT4( XMINT4 &amp;&amp; unnamedParam1 ); XMINT4 &amp; operator=( XMINT4 &amp;&amp; unnamedParam1 ); void
	// XMINT4( int32_t _x, int32_t _y, int32_t _z, int32_t _w ) noexcept; void XMINT4( const int32_t *pArray ) noexcept; bool operator==(
	// const XMINT4 &amp; unnamedParam1 ); auto operator&lt;=&gt;( const XMINT4 &amp; unnamedParam1 ); };
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMINT4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMINT4(int x = 0, int y = 0, int z = 0, int w = 0) : IEquatable<XMINT4>
	{
		/// <summary>Signed integer value describing the x coordinate of the vector.</summary>
		public int x = x;

		/// <summary>Signed integer value describing the y coordinate of the vector.</summary>
		public int y = y;

		/// <summary>Signed integer value describing the z coordinate of the vector.</summary>
		public int z = z;

		/// <summary>Signed integer value describing the w coordinate of the vector.</summary>
		public int w = w;

		/// <summary>Initializes a new instance of the <see cref="XMINT4"/> struct.</summary>
		/// <param name="pArray">An array for four values consecutively applied to x, y, z, and w.</param>
		/// <exception cref="ArgumentException">Array must have 4 elements. - pArray</exception>
		public XMINT4(int[] pArray) :
			this(pArray?.Length == 4 ? pArray[0] : throw new ArgumentException("Array must have 4 elements.", nameof(pArray)), pArray[1], pArray[2], pArray[3])
		{ }

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMINT4 xMFLOAT && Equals(xMFLOAT);

		/// <inheritdoc/>
		public bool Equals(XMINT4 other) => x == other.x && y == other.y && z == other.z;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y, z, w).GetHashCode();

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMINT4 left, XMINT4 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMINT4 left, XMINT4 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="int"/>[] to <see cref="XMINT4"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMINT4(int[] v) => new(v);
	}

	/// <summary>
	/// <para>Describes a 4*4 matrix aligned on a 16-byte boundary that maps to four hardware vector registers.</para>
	/// <para>
	/// DirectXMath uses row-major matrices, row vectors, and pre-multiplication. Handedness is determined by which function version is used
	/// (RH vs. LH).
	/// </para>
	/// <para>
	/// For a list of additional functionality such as constructors and operators that are available using <c>XMMATRIX</c> when you are
	/// programming in C++, see <c>XMMATRIX Extensions</c>.
	/// </para>
	/// <para>
	/// <note>See <c>DirectXMath Library Type Equivalences</c> for information about equivalent <c>D3DDECLTYPE</c>, <c>D3DFORMAT</c>, and
	/// <c>DXGI_FORMAT</c> objects.</note>
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// In the DirectXMath.h header file, the system uses an alias to the <c>XMMATRIX</c> object, specifically <b>CXMMATRIX</b>. The header
	/// uses the alias to comply with the optimal in-line calling conventions of different compilers. For most projects using DirectXMath it
	/// is sufficient to simply treat this as an exact alias to <c>XMMATRIX</c>.
	/// </para>
	/// <para>Effectively:</para>
	/// <para><c>typedef const XMMATRIX CXMMATRIX;</c></para>
	/// <para>
	/// For projects that need detailed information about how different platform's calling conventions are handled, see <c>Library Internals</c>.
	/// </para>
	/// <para>
	/// <c>XMMATRIX</c> is row-major and all DirectXMath functions that accept an <c>XMMATRIX</c> as a parameter expect data to be organized
	/// as row-major.
	/// </para>
	/// <para>Data in an <c>XMMATRIX</c> has the following layout.</para>
	/// <para><c>_11 _12 _13 _14<br/>_21 _22 _23 _24<br/>_31 _32 _33 _34<br/>_41 _42 _43 _44</c></para>
	/// <para>
	/// DirectXMath defines <b>XMMATRIX</b> as a fully opaque type. To access individual elements of <b>XMMATRIX</b>, use equivalent types
	/// such as <c>XMFLOAT4</c> for a given row or <c>XMFLOAT4X4</c> for the whole matrix.
	/// </para>
	/// <para>
	/// <note>XNAMath 2.x defines <c>XMMATRIX</c> as a union with <b>_11</b> to <b>_44</b> members and an <b>m</b> array member. When you
	/// use these members of the union, poor performance results. DirectXMath.h still defines these <c>XMMATRIX</c> union members for when
	/// you build an app with <c>_XM_NO_INTRINSICS_</c>. XNAMath version 2.05 provides an opt-in XM_STRICT_XMMATRIX to enforce the
	/// DirectXMath behavior.</note>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmmatrix
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMMATRIX")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMMATRIX : IEquatable<XMMATRIX>
	{
		const int crow = 4, ccol = 4;

		/// <summary>An element of the matrix.</summary>
		public float _11;

		/// <summary>An element of the matrix.</summary>
		public float _12;

		/// <summary>An element of the matrix.</summary>
		public float _13;

		/// <summary>An element of the matrix.</summary>
		public float _14;

		/// <summary>An element of the matrix.</summary>
		public float _21;

		/// <summary>An element of the matrix.</summary>
		public float _22;

		/// <summary>An element of the matrix.</summary>
		public float _23;

		/// <summary>An element of the matrix.</summary>
		public float _24;

		/// <summary>An element of the matrix.</summary>
		public float _31;

		/// <summary>An element of the matrix.</summary>
		public float _32;

		/// <summary>An element of the matrix.</summary>
		public float _33;

		/// <summary>An element of the matrix.</summary>
		public float _34;

		/// <summary>An element of the matrix.</summary>
		public float _41;

		/// <summary>An element of the matrix.</summary>
		public float _42;

		/// <summary>An element of the matrix.</summary>
		public float _43;

		/// <summary>An element of the matrix.</summary>
		public float _44;

		/// <summary>Gets or sets the <see cref="float"/> with the specified row and column.</summary>
		/// <value>The <see cref="float"/> value.</value>
		/// <param name="row">The row index.</param>
		/// <param name="column">The column index.</param>
		/// <returns>The value.</returns>
		public float this[int row, int column]
		{
			get
			{
				if (row is < 0 or >= crow)
					throw new ArgumentOutOfRangeException(nameof(row), $"Row must be a value between 0 and {crow - 1}.");
				if (column is < 0 or >= ccol)
					throw new ArgumentOutOfRangeException(nameof(column), $"Column must be a value between 0 and {ccol - 1}.");
				unsafe { fixed (float* p = &_11) return p[ccol * row + column]; }
			}
			set
			{
				if (row is < 0 or >= crow)
					throw new ArgumentOutOfRangeException(nameof(row), $"Row must be a value between 0 and {crow - 1}.");
				if (column is < 0 or >= ccol)
					throw new ArgumentOutOfRangeException(nameof(column), $"Column must be a value between 0 and {ccol - 1}.");
				unsafe { fixed (float* p = &_11) p[ccol * row + column] = value; }
			}
		}

		/// <summary>Gets a reference to the rows of the matrix.</summary>
		public Span<XMVECTOR> r => GetSpan<XMVECTOR>(4);

		/// <summary>Initializes a new instance of the <see cref="XMMATRIX"/> struct.</summary>
		/// <param name="m00">Value used to initialize the _11 member of the XMMATRIX structure.</param>
		/// <param name="m01">Value used to initialize the _12 member of the XMMATRIX structure.</param>
		/// <param name="m02">Value used to initialize the _13 member of the XMMATRIX structure.</param>
		/// <param name="m03">Value used to initialize the _14 member of the XMMATRIX structure.</param>
		/// <param name="m10">Value used to initialize the _21 member of the XMMATRIX structure.</param>
		/// <param name="m11">Value used to initialize the _22 member of the XMMATRIX structure.</param>
		/// <param name="m12">Value used to initialize the _23 member of the XMMATRIX structure.</param>
		/// <param name="m13">Value used to initialize the _24 member of the XMMATRIX structure.</param>
		/// <param name="m20">Value used to initialize the _31 member of the XMMATRIX structure.</param>
		/// <param name="m21">Value used to initialize the _32 member of the XMMATRIX structure.</param>
		/// <param name="m22">Value used to initialize the _33 member of the XMMATRIX structure.</param>
		/// <param name="m23">Value used to initialize the _34 member of the XMMATRIX structure.</param>
		/// <param name="m30">Value used to initialize the _41 member of the XMMATRIX structure.</param>
		/// <param name="m31">Value used to initialize the _42 member of the XMMATRIX structure.</param>
		/// <param name="m32">Value used to initialize the _43 member of the XMMATRIX structure.</param>
		/// <param name="m33">Value used to initialize the _44 member of the XMMATRIX structure.</param>
		public XMMATRIX(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33) =>
			(_11, _12, _13, _14, _21, _22, _23, _24, _31, _32, _33, _34, _41, _42, _43, _44) = (m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);

		/// <summary>Initializes a new instance of the <see cref="XMMATRIX"/> struct from a 16 element <see cref="float"/> array.</summary>
		/// <param name="pArray">A 16 element <see cref="float"/> array, specifying the value of each member of a new instance of XMMATRIX.</param>
		public XMMATRIX(float[] pArray)
		{
			if (pArray?.Length != 16)
				throw new ArgumentException("Array must have 16 elements.", nameof(pArray));
			unsafe
			{
				fixed (float* f = &_11)
				{
					for (var i = 0; i < 16; i++)
						f[i] = pArray[i];
				}
			}
		}

		/// <summary>Initializes a new instance of the <see cref="XMMATRIX"/> struct from a 16 element <see cref="float"/> array.</summary>
		/// <param name="pArray">A 16 element <see cref="float"/> array, specifying the value of each member of a new instance of XMMATRIX.</param>
		public XMMATRIX(float[,] pArray)
		{
			if (pArray.GetLength(0) != 4 && pArray.GetLength(1) != 4)
				throw new ArgumentException("Array must have 4 rows of 4 columns.", nameof(pArray));
			unsafe
			{
				fixed (float* f = &_11)
					for (var i = 0; i < 4; i++)
						for (var j = 0; j < 4; j++)
							f[4 * i + j] = pArray[i, j];
			}
		}

		/// <summary>Initializes a new instance of the <see cref="XMMATRIX"/> struct from four instances of XMVECTOR.</summary>
		/// <param name="R0">Instance of XMMATRIX used to initialize the first row of a new instance of XMMATRIX.</param>
		/// <param name="R1">Instance of XMMATRIX used to initialize the second row of a new instance of XMMATRIX.</param>
		/// <param name="R2">Instance of XMMATRIX used to initialize the third row of a new instance of XMMATRIX.</param>
		/// <param name="R3">Instance of XMMATRIX used to initialize the fourth row of a new instance of XMMATRIX.</param>
		public XMMATRIX(in XMVECTOR R0, in XMVECTOR R1, in XMVECTOR R2, in XMVECTOR R3)
		{
			unsafe
			{
				fixed (float* f = &_11)
				{
					Span<XMVECTOR> rows = new(f, 4);
					rows[0] = R0;
					rows[1] = R1;
					rows[2] = R2;
					rows[3] = R3;
					
				}
			}
		}

		/// <summary>
		/// Executes an operation on each <see cref="float"/> element of the vector against it same element in a second vector and returns a
		/// resulting vector.
		/// </summary>
		/// <param name="other">The second vector.</param>
		/// <param name="op">The operation.</param>
		/// <returns>A vector with the results of the operations.</returns>
		public readonly XMMATRIX BinaryOp(in XMMATRIX other, Func<float, float, float> op)
		{
			unsafe
			{
				XMMATRIX R = new();
				fixed (float* f = &_11, of = &other._11)
					for (var i = 0; i < 16; i++)
						(&R._11)[i] = op(f[i], of[i]);
				return R;
			}
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMMATRIX xMMATRIX && Equals(xMMATRIX);

		/// <inheritdoc/>
		public bool Equals(XMMATRIX other)
		{
			unsafe
			{
				fixed (float* f = &_11)
					for (var i = 0; i < 16; i++)
					{
						if (f[i] != (&other._11)[i])
							return false;
					}
				return true;
			}
		}

		/// <inheritdoc/>
		public override int GetHashCode() => ToArray().GetHashCode();

		/// <summary>Gets a typed Span against the data of the matrix.</summary>
		public Span<T> GetSpan<T>(int len) where T : unmanaged
		{
			unsafe
			{
				fixed (float* p = &_11)
				{
					return new((T*)p, len);
				}
			}
		}

		/// <summary>Exposes the matrix as a 4x4 jagged array.</summary>
		/// <returns>A 4x4 jagged array.</returns>
		public float[,] ToArray()
		{
			float[,] ret = new float[4,4];
			unsafe
			{
				fixed (float* f = &_11)
					for (var i = 0; i < 4; i++)
						for (var j = 0; j < 4; j++)
							ret[i, j] = f[4 * i + j];
			}
			return ret;
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			StringBuilder sb = new();
			sb.AppendLine("{");
			foreach (var row in this.r)
				sb.AppendFormat(null, " {{ {0} }}\n", row);
			sb.Append('}');
			return sb.ToString();
		}

		/// <summary>Executes an operation on each <see cref="float"/> element of the vector and returns a resulting vector.</summary>
		/// <param name="op">The operation.</param>
		/// <returns>A vector with the results of the operations.</returns>
		public readonly XMMATRIX UnaryOp(Func<float, float> op)
		{
			XMMATRIX R = new();
			unsafe
			{
				fixed (float* f = &_11)
					for (var i = 0; i < 16; i++)
						(&R._11)[i] = op(f[i]);
			}
			return R;
		}

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMMATRIX left, XMMATRIX right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMMATRIX left, XMMATRIX right) => !(left == right);

		/// <summary>Implements the negation operator.</summary>
		/// <param name="m">The value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMMATRIX operator -(XMMATRIX m) => m.UnaryOp(f => -f);

		/// <summary>Implements the operator +.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMMATRIX operator +(XMMATRIX left, XMMATRIX right) => left.BinaryOp(right, (a, b) => a + b);

		/// <summary>Implements the operator -.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMMATRIX operator -(XMMATRIX left, XMMATRIX right) => left.BinaryOp(right, (a, b) => a - b);

		/// <summary>Implements the operator *.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMMATRIX operator *(XMMATRIX left, XMMATRIX right) => XMMatrixMultiply(left, right);

		///// <summary>Implements the operator /.</summary>
		///// <param name="left">The left value.</param>
		///// <param name="right">The right value.</param>
		///// <returns>The result of the operator.</returns>
		//public static XMMATRIX operator /(XMMATRIX left, XMMATRIX right) => left.BinaryOp(right, (a, b) => a / b);

		/// <summary>Implements the operator *.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMMATRIX operator *(XMMATRIX left, float right) => left.UnaryOp(f => f * right);

		/// <summary>Implements the operator /.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMMATRIX operator /(XMMATRIX left, float right) => left.UnaryOp(f => f / right);

		/// <summary>Implements the operator *.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMMATRIX operator *(float left, XMMATRIX right) => right.UnaryOp(f => f * left);

		/// <summary>Performs an explicit conversion from <see cref="Vanara.PInvoke.DirectXMath.XMMATRIX"/> to <see cref="float"/>[].</summary>
		/// <param name="m">The matrix.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator float[,](XMMATRIX m) => m.ToArray();

		/// <summary>Performs an explicit conversion from <see cref="float"/>[] to <see cref="Vanara.PInvoke.DirectXMath.XMMATRIX"/>.</summary>
		/// <param name="a">The 4x4 array.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator XMMATRIX(float[,] a) => new(a);

		/// <summary>Performs an implicit conversion from <see cref="Matrix"/> to <see cref="XMMATRIX"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator XMMATRIX(Matrix value) => value.Rows == 4 && value.Columns == 4 ? new(value.ToArray()) : throw new InvalidCastException("Value must be a 4x4 matrix.");

		/// <summary>Performs an implicit conversion from <see cref="XMMATRIX"/> to <see cref="Matrix"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Matrix(XMMATRIX value) => new(value.ToArray());

#if !NET45
		/// <summary>Performs an implicit conversion from <see cref="System.Numerics.Matrix4x4"/> to <see cref="XMMATRIX"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator XMMATRIX(System.Numerics.Matrix4x4 value) =>
			new(value.M11, value.M12, value.M13, value.M14, value.M21, value.M22, value.M23, value.M24, value.M31, value.M32, value.M33, value.M34, value.M41, value.M42, value.M43, value.M44);

		/// <summary>Performs an implicit conversion from <see cref="XMMATRIX"/> to <see cref="System.Numerics.Matrix4x4"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator System.Numerics.Matrix4x4(XMMATRIX value) =>
			new(value._11, value._12, value._13, value._14, value._21, value._22, value._23, value._24, value._31, value._32, value._33, value._34, value._41, value._42, value._43, value._44);
#endif
	}

	/// <summary>
	/// <para>A 2D vector where each component is an unsigned integer.</para>
	/// <para>
	/// For a list of additional functionality such as constructors and operators that are available using <c>XMUINT2</c> when you are
	/// programming in C++, see <c>XMUINT2 Extensions</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  See <c>DirectXMath Library Type Equivalences</c> for information about equivalent <c>D3DDECLTYPE</c>, <c>D3DFORMAT</c>,
	/// and <c>DXGI_FORMAT</c> objects.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>You can use <c>XMLoadUInt2</c> to load <c>XMUINT2</c> into instances of <c>XMVECTOR</c>.</para>
	/// <para>You can use <c>XMStoreUInt2</c> to store instances of <c>XMVECTOR</c> into an instance of <c>XMUINT2</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmuint2 struct XMUINT2 { uint32_t x; uint32_t y; void
	// XMUINT2(); void XMUINT2( const XMUINT2 &amp; unnamedParam1 ); XMUINT2 &amp; operator=( const XMUINT2 &amp; unnamedParam1 ); void
	// XMUINT2( XMUINT2 &amp;&amp; unnamedParam1 ); XMUINT2 &amp; operator=( XMUINT2 &amp;&amp; unnamedParam1 ); void XMUINT2( uint32_t _x,
	// uint32_t _y ) noexcept; void XMUINT2( const uint32_t *pArray ) noexcept; bool operator==( const XMUINT2 &amp; unnamedParam1 ); auto
	// operator&lt;=&gt;( const XMUINT2 &amp; unnamedParam1 ); };
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMUINT2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMUINT2(uint x = 0, uint y = 0) : IEquatable<XMUINT2>
	{
		/// <summary>Unsigned integer value describing the x coordinate of the vector.</summary>
		public uint x = x;

		/// <summary>Unsigned integer value describing the y coordinate of the vector.</summary>
		public uint y = y;

		/// <summary>Initializes a new instance of the <see cref="XMUINT2"/> struct.</summary>
		/// <param name="pArray">An array for values consecutively applied to x and y.</param>
		/// <exception cref="ArgumentException">Array must have 2 elements. - pArray</exception>
		public XMUINT2(uint[] pArray) :
			this(pArray?.Length == 2 ? pArray[0] : throw new ArgumentException("Array must have 2 elements.", nameof(pArray)), pArray[1])
		{ }

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMUINT2 v && Equals(v);

		/// <inheritdoc/>
		public bool Equals(XMUINT2 other) => x == other.x && y == other.y;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y).GetHashCode();

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMUINT2 left, XMUINT2 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMUINT2 left, XMUINT2 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="uint"/>[] to <see cref="XMUINT2"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMUINT2(uint[] v) => new(v);
	}

	/// <summary>
	/// <para>A 3D vector where each component is an unsigned integer.</para>
	/// <para>
	/// For a list of additional functionality such as constructors and operators that are available using <c>XMUINT3</c> when you are
	/// programming in C++, see <c>XMUINT3 Extensions</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  See <c>DirectXMath Library Type Equivalences</c> for information about equivalent <c>D3DDECLTYPE</c>, <c>D3DFORMAT</c>,
	/// and <c>DXGI_FORMAT</c> objects.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>You can use <c>XMLoadUInt3</c> to load <c>XMUINT3</c> into instances of <c>XMVECTOR</c>.</para>
	/// <para>You can use <c>XMStoreUInt3</c> to store instances of <c>XMVECTOR</c> into an instance of <c>XMUINT3</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmuint3 struct XMUINT3 { uint32_t x; uint32_t y;
	// uint32_t z; void XMUINT3(); void XMUINT3( const XMUINT3 &amp; unnamedParam1 ); XMUINT3 &amp; operator=( const XMUINT3 &amp;
	// unnamedParam1 ); void XMUINT3( XMUINT3 &amp;&amp; unnamedParam1 ); XMUINT3 &amp; operator=( XMUINT3 &amp;&amp; unnamedParam1 ); void
	// XMUINT3( uint32_t _x, uint32_t _y, uint32_t _z ) noexcept; void XMUINT3( const uint32_t *pArray ) noexcept; bool operator==( const
	// XMUINT3 &amp; unnamedParam1 ); auto operator&lt;=&gt;( const XMUINT3 &amp; unnamedParam1 ); };
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMUINT3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMUINT3(uint x = 0, uint y = 0, uint z = 0) : IEquatable<XMUINT3>
	{
		/// <summary>Unsigned integer value describing the x coordinate of the vector.</summary>
		public uint x = x;

		/// <summary>Unsigned integer value describing the y coordinate of the vector.</summary>
		public uint y = y;

		/// <summary>Unsigned integer value describing the z coordinate of the vector.</summary>
		public uint z = z;

		/// <summary>Initializes a new instance of the <see cref="XMUINT3"/> struct.</summary>
		/// <param name="pArray">An array for four values consecutively applied to x, y, and z.</param>
		/// <exception cref="ArgumentException">Array must have 3 elements. - pArray</exception>
		public XMUINT3(uint[] pArray) :
			this(pArray?.Length == 3 ? pArray[0] : throw new ArgumentException("Array must have 3 elements.", nameof(pArray)), pArray[1], pArray[2])
		{ }

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMUINT3 xMFLOAT && Equals(xMFLOAT);

		/// <inheritdoc/>
		public bool Equals(XMUINT3 other) => x == other.x && y == other.y && z == other.z;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y, z).GetHashCode();

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMUINT3 left, XMUINT3 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMUINT3 left, XMUINT3 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="uint"/>[] to <see cref="XMUINT3"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMUINT3(uint[] v) => new(v);
	}

	/// <summary>
	/// <para>A 4D vector where each component is an unsigned integer.</para>
	/// <para>
	/// For a list of additional functionality such as constructors and operators that are available using <c>XMUINT4</c> when you are
	/// programming in C++, see <c>XMUINT4 Extensions</c>.
	/// </para>
	/// <para>
	/// <b>Note</b>  See <c>DirectXMath Library Type Equivalences</c> for information about equivalent <c>D3DDECLTYPE</c>, <c>D3DFORMAT</c>,
	/// and <c>DXGI_FORMAT</c> objects.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>You can use <c>XMLoadUInt4</c> to load <c>XMUINT4</c> into instances of <c>XMVECTOR</c>.</para>
	/// <para>You can use <c>XMStoreUInt4</c> to store instances of <c>XMVECTOR</c> into an instance of <c>XMUINT4</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/ns-directxmath-xmuint4 struct XMUINT4 { uint32_t x; uint32_t y;
	// uint32_t z; uint32_t w; void XMUINT4(); void XMUINT4( const XMUINT4 &amp; unnamedParam1 ); XMUINT4 &amp; operator=( const XMUINT4
	// &amp; unnamedParam1 ); void XMUINT4( XMUINT4 &amp;&amp; unnamedParam1 ); XMUINT4 &amp; operator=( XMUINT4 &amp;&amp; unnamedParam1 );
	// void XMUINT4( uint32_t _x, uint32_t _y, uint32_t _z, uint32_t _w ) noexcept; void XMUINT4( const uint32_t *pArray ) noexcept; bool
	// operator==( const XMUINT4 &amp; unnamedParam1 ); auto operator&lt;=&gt;( const XMUINT4 &amp; unnamedParam1 ); };
	[PInvokeData("directxmath.h", MSDNShortId = "NS:directxmath.XMUINT4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XMUINT4(uint x = 0, uint y = 0, uint z = 0, uint w = 0) : IEquatable<XMUINT4>
	{
		/// <summary>Unsigned integer value describing the x coordinate of the vector.</summary>
		public uint x = x;

		/// <summary>Unsigned integer value describing the y coordinate of the vector.</summary>
		public uint y = y;

		/// <summary>Unsigned integer value describing the z coordinate of the vector.</summary>
		public uint z = z;

		/// <summary>Unsigned integer value describing the w coordinate of the vector.</summary>
		public uint w = w;

		/// <summary>Initializes a new instance of the <see cref="XMUINT4"/> struct.</summary>
		/// <param name="pArray">An array for four values consecutively applied to x, y, z, and w.</param>
		/// <exception cref="ArgumentException">Array must have 4 elements. - pArray</exception>
		public XMUINT4(uint[] pArray) :
			this(pArray?.Length == 4 ? pArray[0] : throw new ArgumentException("Array must have 4 elements.", nameof(pArray)), pArray[1], pArray[2], pArray[3])
		{ }

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMUINT4 xMFLOAT && Equals(xMFLOAT);

		/// <inheritdoc/>
		public bool Equals(XMUINT4 other) => x == other.x && y == other.y && z == other.z;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y, z, w).GetHashCode();

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMUINT4 left, XMUINT4 right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMUINT4 left, XMUINT4 right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="uint"/>[] to <see cref="XMUINT4"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator XMUINT4(uint[] v) => new(v);
	}

	/// <summary>
	/// A portable type used to represent a vector of four 32-bit floating-point or integer components, each aligned optimally and mapped to
	/// a hardware vector register.
	/// </summary>
	/// <remarks>
	/// <para>
	/// For a list of additional functionality, such as constructors and operators, available using <c>XMVECTOR</c> when programming in C++,
	/// see <c>XMVECTOR Extensions</c>.
	/// </para>
	/// <para>
	/// In the DirectXMath Library, to fully support portability and optimization, <c>XMVECTOR</c> is, by design, an opaque type. The actual
	/// implementation of <c>XMVECTOR</c> is platform dependent.
	/// </para>
	/// <para>
	/// In general, code should not rely on the specifics of any given platform specific implementation of <c>XMVECTOR</c>.
	/// Platform-specific implementations have these characteristics:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>They are not portable.</description>
	/// </item>
	/// <item>
	/// <description>They may change between releases.</description>
	/// </item>
	/// <item>
	/// <description>Injudicious use of implementation details may be suboptimal.</description>
	/// </item>
	/// </list>
	/// <para>
	/// Developers should use DirectXMath Library's <c>accessor</c>, <c>load</c>, and <c>store</c> functions to get and set the vectors, and
	/// the <c>DirectXMath Library 4D Vector Functions</c> to manipulate them.
	/// </para>
	/// <para>
	/// For projects that need detailed information about how to implement <c>XMVECTOR</c> on different platforms, see <c>Library Internals</c>.
	/// </para>
	/// <para>Compiler Aliases</para>
	/// <para>
	/// The DirectXMath.h header file uses aliases to the <c>XMVECTOR</c> object, specifically <b>CXMVECTOR</b> and <b>FXMVECTOR</b>. The
	/// header uses these aliases to comply with the optimal in-line calling conventions of different compilers. For most projects that use
	/// DirectXMath it is sufficient to treat these types as an exact alias to <c>XMVECTOR</c>.
	/// </para>
	/// <para>For example:</para>
	/// <para><c>[CDATA[ typedef const XMVECTOR FXMVECTOR; typedef const XMVECTOR CXMVECTOR; ]]</c></para>
	/// <para>
	/// For projects that need detailed information about how different platforms handle their calling conventions, see <c>Library Internals</c>.
	/// </para>
	/// <para>
	/// For XNAMATH 2.x, the <c>XMVECTOR</c> data type has .x, .y, .z, .and .w element members, which generally cause poor performance. The
	/// use of the XM_STRICT_VECTOR4 type provides an opt-in of the DirectXMath definition of an opaque data type.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/dxmath/xmvector-data-type
	[PInvokeData("DirectXMath.h")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct XMVECTOR : IEquatable<XMVECTOR>
	{
		/// <summary>The x component.</summary>
		[FieldOffset(0)]
		public float x;

		/// <summary>The y component.</summary>
		[FieldOffset(4)]
		public float y;

		/// <summary>The z component.</summary>
		[FieldOffset(8)]
		public float z;

		/// <summary>The w component.</summary>
		[FieldOffset(12)]
		public float w;

		/// <summary>The x component <see cref="uint"/> value.</summary>
		[FieldOffset(0)]
		public uint ux;

		/// <summary>The y component <see cref="uint"/> value.</summary>
		[FieldOffset(4)]
		public uint uy;

		/// <summary>The z component <see cref="uint"/> value.</summary>
		[FieldOffset(8)]
		public uint uz;

		/// <summary>The w component <see cref="uint"/> value.</summary>
		[FieldOffset(12)]
		public uint uw;

		/// <summary>The float[4] array.</summary>
		[FieldOffset(0)]
		public unsafe fixed float vector4_f32[4];

		/// <summary>The float[4] array.</summary>
		[FieldOffset(0)]
		internal unsafe fixed float f[4];

		/// <summary>The uint[4] array.</summary>
		[FieldOffset(0)]
		internal unsafe fixed uint u[4];

		[FieldOffset(0)]
		internal unsafe fixed byte bytes[16];

#if NET7_0_OR_GREATER
		/// <summary>The 128-bit value</summary>
		[FieldOffset(0)]
		public System.UInt128 __m128;
#endif

		/// <summary>Initializes a new instance of the <see cref="XMVECTOR"/> struct.</summary>
		/// <param name="x">The x-coordinate of the vector.</param>
		/// <param name="y">The y-coordinate of the vector.</param>
		/// <param name="z">The z-coordinate of the vector.</param>
		/// <param name="w">The w-coordinate of the vector.</param>
		public XMVECTOR(float x, float y, float z = 0f, float w = 0f) : this() => (this.x, this.y, this.z, this.w) = (x, y, z, w);

		/// <summary>Initializes a new instance of the <see cref="XMVECTOR"/> struct.</summary>
		/// <param name="value">The value to apply to all elements.</param>
		public XMVECTOR(float value) : this(value, value, value, value) { }

		/// <summary>Initializes a new instance of the <see cref="XMVECTOR"/> struct.</summary>
		/// <param name="value">The value to apply to all elements.</param>
		public XMVECTOR(uint value) : this(value, value, value, value) { }

		/// <summary>Initializes a new instance of the <see cref="XMVECTOR"/> struct.</summary>
		/// <param name="x">The x-coordinate of the vector.</param>
		/// <param name="y">The y-coordinate of the vector.</param>
		/// <param name="z">The z-coordinate of the vector.</param>
		/// <param name="w">The w-coordinate of the vector.</param>
		public XMVECTOR(uint x, uint y, uint z = 0, uint w = 0) : this() => (ux, uy, uz, uw) = (x, y, z, w);

		/// <summary>Initializes a new instance of the <see cref="XMVECTOR"/> struct.</summary>
		/// <param name="pArray">An array for four values consecutively applied to x, y, z, and w.</param>
		/// <exception cref="ArgumentException">Array must have 4 elements. - pArray</exception>
		public XMVECTOR(float[] pArray) : this()
		{
			if (pArray is null || pArray.Length != 4)
				throw new ArgumentException("Array must have 4 elements.", nameof(pArray));
			(x, y, z, w) = (pArray[0], pArray[1], pArray[2], pArray[3]);
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is XMVECTOR xMFLOAT && Equals(xMFLOAT);

		/// <inheritdoc/>
		public bool Equals(XMVECTOR other) => x == other.x && y == other.y && z == other.z && w == other.w;

		/// <inheritdoc/>
		public override int GetHashCode() => (x, y, z, w).GetHashCode();

		/// <summary>Gets or sets the <see cref="float"/> at the specified index.</summary>
		/// <value>The <see cref="float"/>.</value>
		/// <param name="index">The index. This value must be between 0 and 3.</param>
		/// <returns>The value at the index.</returns>
		public float this[int index]
		{
			get { unsafe { return index is >= 0 and < 4 ? f[index] : throw new ArgumentOutOfRangeException(nameof(index), "Index must be value between 0 and 3."); } }
			set { unsafe { f[index] = index is >= 0 and < 4 ? value : throw new ArgumentOutOfRangeException(nameof(index), "Index must be value between 0 and 3."); } }
		}

		/// <summary>Gets a value indicating whether this instance has all components equal.</summary>
		/// <value><see langword="true" /> if this instance has all components equal; otherwise, <see langword="false" />.</value>
		public readonly bool IsConstant => ux == uy && uy == uz && uz == uw;

		/// <summary>Gets a value indicating whether this instance has all components equal to zero.</summary>
		/// <value><see langword="true" /> if this instance is all zeroes; otherwise, <see langword="false" />.</value>
		public readonly bool IsZero => ux == 0 && uy == 0 && uz == 0 && uw == 0;

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(XMVECTOR left, XMVECTOR right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(XMVECTOR left, XMVECTOR right) => !(left == right);

		/// <summary>Performs an implicit conversion from <see cref="float"/>[] to <see cref="XMVECTOR"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator XMVECTOR(float[] v) => new(v);

		/// <summary>Performs an implicit conversion from <see cref="XMVECTOR"/> to <see cref="float"/>[].</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator float[](XMVECTOR v) => [v.x, v.y, v.z, v.w];

		/// <summary>Performs an implicit conversion from <see cref="Matrix"/> to <see cref="XMVECTOR"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator XMVECTOR(Matrix value) =>
			value.Rows == 1 && value.Columns == 4 ? new(value[0,0], value[0, 1], value[0, 2], value[0, 3]) : throw new InvalidCastException("Value must be a 1x4 matrix.");

		/// <summary>Performs an implicit conversion from <see cref="XMVECTOR"/> to <see cref="Matrix"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Matrix(XMVECTOR value) => new(new float[,] { { value.x, value.y, value.z, value.w } });

#if !NET45
		/// <summary>Performs an implicit conversion from <see cref="System.Numerics.Vector4 "/> to <see cref="XMVECTOR"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator XMVECTOR(System.Numerics.Vector4 value) =>
			new(value.X, value.Y, value.Z, value.W);

		/// <summary>Performs an implicit conversion from <see cref="XMVECTOR"/> to <see cref="System.Numerics.Vector4 "/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator System.Numerics.Vector4(XMVECTOR value) =>
			new(value.x, value.y, value.z, value.w);
#endif

		/// <summary>Implements the operator +.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator +(XMVECTOR left, XMVECTOR right) => left.XMVectorAdd(right);

		/// <summary>Implements the operator -.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator -(XMVECTOR left, XMVECTOR right) => left.XMVectorSubtract(right);

		/// <summary>Implements the negation operator.</summary>
		/// <param name="left">The left value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator -(XMVECTOR left) => left.XMVectorNegate();

		/// <summary>Implements the operator *.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator *(XMVECTOR left, XMVECTOR right) => left.XMVectorMultiply(right);

		/// <summary>Implements the operator /.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator /(XMVECTOR left, XMVECTOR right) => left.XMVectorDivide(right);

		/// <summary>Implements the operator *.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator *(XMVECTOR left, float right) => left.XMVectorScale(right);

		/// <summary>Implements the operator /.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator /(XMVECTOR left, float right) => new(left.x / right, left.y / right, left.z / right, left.w / right);

		/// <summary>Implements the operator *.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator *(float left, XMVECTOR right) => right.XMVectorScale(left);

		/// <summary>Implements the operator &amp;.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator &(XMVECTOR left, XMVECTOR right) => left.XMVectorAndInt(right);

		/// <summary>Implements the operator |.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator |(XMVECTOR left, XMVECTOR right) => left.XMVectorOrInt(right);

		/// <summary>Implements the operator ^.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator ^(XMVECTOR left, XMVECTOR right) => left.XMVectorXorInt(right);

		/// <summary>Implements the operator %.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static XMVECTOR operator %(XMVECTOR left, XMVECTOR right) => left.XMVectorMod(right);

		/// <summary>
		/// Executes an operation on each <see cref="float"/> element of the vector against it same element in a second vector and returns a
		/// resulting vector.
		/// </summary>
		/// <param name="other">The second vector.</param>
		/// <param name="op">The operation.</param>
		/// <returns>A vector with the results of the operations.</returns>
		public readonly XMVECTOR BinaryOp(in XMVECTOR other, Func<float, float, float> op) =>
			new(op(x, other.x), op(y, other.y), op(z, other.z), op(w, other.w));

		/// <summary>
		/// Executes an operation on each <see cref="float"/> element of the vector against it same element in a second vector and returns a
		/// resulting vector.
		/// </summary>
		/// <param name="other">The second vector.</param>
		/// <param name="op">The operation.</param>
		/// <returns>A vector with the results of the operations.</returns>
		public readonly XMVECTOR BinaryIntOp(in XMVECTOR other, Func<uint, uint, uint> op) =>
			new(op(ux, other.ux), op(uy, other.uy), op(uz, other.uz), op(uw, other.uw));

		/// <inheritdoc/>
		public override string ToString() => string.Format(null, "{0},{1},{2},{3}", x, y, z, w);

		/// <summary>Executes an operation on each <see cref="float"/> element of the vector and returns a resulting vector.</summary>
		/// <param name="op">The operation.</param>
		/// <returns>A vector with the results of the operations.</returns>
		public readonly XMVECTOR UnaryOp(Func<float, float> op) => new(op(x), op(y), op(z), op(w));

		/// <summary>Executes an operation on each <see cref="float"/> element of the vector and returns a resulting vector.</summary>
		/// <param name="op">The operation.</param>
		/// <returns>A vector with the results of the operations.</returns>
		public readonly XMVECTOR UnaryOp(Func<double, double> op) => new((float)op(x), (float)op(y), (float)op(z), (float)op(w));

		internal readonly bool AllTrue(Func<float, bool> predicate) =>
			predicate(x) && predicate(y) && predicate(z) && predicate(w);
		internal readonly bool All1True(Func<float, bool> predicate) =>
			predicate(x);
		internal readonly bool All2True(Func<float, bool> predicate) =>
			predicate(x) && predicate(y);
		internal readonly bool All3True(Func<float, bool> predicate) =>
			predicate(x) && predicate(y) && predicate(z);

		internal readonly bool AnyTrue(Func<float, bool> predicate) =>
			predicate(x) || predicate(y) || predicate(z) || predicate(w);
		internal readonly bool Any1True(Func<float, bool> predicate) =>
			predicate(x);
		internal readonly bool Any2True(Func<float, bool> predicate) =>
			predicate(x) || predicate(y);
		internal readonly bool Any3True(Func<float, bool> predicate) =>
			predicate(x) || predicate(y) || predicate(z);

		internal readonly bool AllTrue(in XMVECTOR other, Func<float, float, bool> predicate) =>
			predicate(x, other.x) && predicate(y, other.y) && predicate(z, other.z) && predicate(w, other.w);
		internal readonly bool All3True(in XMVECTOR other, Func<float, float, bool> predicate) =>
			predicate(x, other.x) && predicate(y, other.y) && predicate(z, other.z);
		internal readonly bool All2True(in XMVECTOR other, Func<float, float, bool> predicate) =>
			predicate(x, other.x) && predicate(y, other.y);
		internal readonly bool All1True(in XMVECTOR other, Func<float, float, bool> predicate) =>
			predicate(x, other.x);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public static XMVECTOR g_XMSinCoefficients0 => new(-0.16666667f, +0.0083333310f, -0.00019840874f, +2.7525562e-06f);
		public static XMVECTOR g_XMSinCoefficients1 => new(-2.3889859e-08f, -0.16665852f /*Est1*/, +0.0083139502f /*Est2*/, -0.00018524670f /*Est3*/);
		public static XMVECTOR g_XMCosCoefficients0 => new(-0.5f, +0.041666638f, -0.0013888378f, +2.4760495e-05f);
		public static XMVECTOR g_XMCosCoefficients1 => new(-2.6051615e-07f, -0.49992746f /*Est1*/, +0.041493919f /*Est2*/, -0.0012712436f /*Est3*/);
		public static XMVECTOR g_XMTanCoefficients0 => new(1.0f, 0.333333333f, 0.133333333f, 5.396825397e-2f);
		public static XMVECTOR g_XMTanCoefficients1 => new(2.186948854e-2f, 8.863235530e-3f, 3.592128167e-3f, 1.455834485e-3f);
		public static XMVECTOR g_XMTanCoefficients2 => new(5.900274264e-4f, 2.391290764e-4f, 9.691537707e-5f, 3.927832950e-5f);
		public static XMVECTOR g_XMArcCoefficients0 => new(+1.5707963050f, -0.2145988016f, +0.0889789874f, -0.0501743046f);
		public static XMVECTOR g_XMArcCoefficients1 => new(+0.0308918810f, -0.0170881256f, +0.0066700901f, -0.0012624911f);
		public static XMVECTOR g_XMATanCoefficients0 => new(-0.3333314528f, +0.1999355085f, -0.1420889944f, +0.1065626393f);
		public static XMVECTOR g_XMATanCoefficients1 => new(-0.0752896400f, +0.0429096138f, -0.0161657367f, +0.0028662257f);
		public static XMVECTOR g_XMATanEstCoefficients0 => new(+0.999866f, +0.999866f, +0.999866f, +0.999866f);
		public static XMVECTOR g_XMATanEstCoefficients1 => new(-0.3302995f, +0.180141f, -0.085133f, +0.0208351f);
		public static XMVECTOR g_XMTanEstCoefficients => new(2.484f, -1.954923183e-1f, 2.467401101f, XM_1DIVPI);
		public static XMVECTOR g_XMArcEstCoefficients => new(+1.5707288f, -0.2121144f, +0.0742610f, -0.0187293f);
		public static XMVECTOR g_XMPiConstants0 => new(XM_PI, XM_2PI, XM_1DIVPI, XM_1DIV2PI);
		public static XMVECTOR g_XMIdentityR0 => new(1.0f, 0.0f, 0.0f, 0.0f);
		public static XMVECTOR g_XMIdentityR1 => new(0.0f, 1.0f, 0.0f, 0.0f);
		public static XMVECTOR g_XMIdentityR2 => new(0.0f, 0.0f, 1.0f, 0.0f);
		public static XMVECTOR g_XMIdentityR3 => new(0.0f, 0.0f, 0.0f, 1.0f);
		public static XMVECTOR g_XMNegIdentityR0 => new(-1.0f, 0.0f, 0.0f, 0.0f);
		public static XMVECTOR g_XMNegIdentityR1 => new(0.0f, -1.0f, 0.0f, 0.0f);
		public static XMVECTOR g_XMNegIdentityR2 => new(0.0f, 0.0f, -1.0f, 0.0f);
		public static XMVECTOR g_XMNegIdentityR3 => new(0.0f, 0.0f, 0.0f, -1.0f);
		public static XMVECTOR g_XMNegativeZero => new(0x80000000, 0x80000000, 0x80000000, 0x80000000);
		public static XMVECTOR g_XMNegate3 => new(0x80000000, 0x80000000, 0x80000000, 0x00000000);
		public static XMVECTOR g_XMMaskXY => new(0xFFFFFFFF, 0xFFFFFFFF, 0x00000000, 0x00000000);
		public static XMVECTOR g_XMMask3 => new(0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0x00000000);
		public static XMVECTOR g_XMMaskX => new(0xFFFFFFFF, 0x00000000, 0x00000000, 0x00000000);
		public static XMVECTOR g_XMMaskY => new(0x00000000, 0xFFFFFFFF, 0x00000000, 0x00000000);
		public static XMVECTOR g_XMMaskZ => new(0x00000000, 0x00000000, 0xFFFFFFFF, 0x00000000);
		public static XMVECTOR g_XMMaskW => new(0x00000000, 0x00000000, 0x00000000, 0xFFFFFFFF);
		public static XMVECTOR g_XMOne => new(1.0f, 1.0f, 1.0f, 1.0f);
		public static XMVECTOR g_XMOne3 => new(1.0f, 1.0f, 1.0f, 0.0f);
		public static readonly XMVECTOR g_XMZero = new(0.0f, 0.0f, 0.0f, 0.0f);
		public static XMVECTOR g_XMTwo => new(2f, 2f, 2f, 2f);
		public static XMVECTOR g_XMFour => new(4f, 4f, 4f, 4f);
		public static XMVECTOR g_XMSix => new(6f, 6f, 6f, 6f);
		public static XMVECTOR g_XMNegativeOne => new(-1.0f, -1.0f, -1.0f, -1.0f);
		public static XMVECTOR g_XMOneHalf => new(0.5f, 0.5f, 0.5f, 0.5f);
		public static XMVECTOR g_XMNegativeOneHalf => new(-0.5f, -0.5f, -0.5f, -0.5f);
		public static XMVECTOR g_XMNegativeTwoPi => new(-XM_2PI, -XM_2PI, -XM_2PI, -XM_2PI);
		public static XMVECTOR g_XMNegativePi => new(-XM_PI, -XM_PI, -XM_PI, -XM_PI);
		public static XMVECTOR g_XMHalfPi => new(XM_PIDIV2, XM_PIDIV2, XM_PIDIV2, XM_PIDIV2);
		public static XMVECTOR g_XMPi => new(XM_PI, XM_PI, XM_PI, XM_PI);
		public static XMVECTOR g_XMReciprocalPi => new(XM_1DIVPI, XM_1DIVPI, XM_1DIVPI, XM_1DIVPI);
		public static XMVECTOR g_XMTwoPi => new(XM_2PI, XM_2PI, XM_2PI, XM_2PI);
		public static XMVECTOR g_XMReciprocalTwoPi => new(XM_1DIV2PI, XM_1DIV2PI, XM_1DIV2PI, XM_1DIV2PI);
		public static XMVECTOR g_XMEpsilon => new(1.192092896e-7f, 1.192092896e-7f, 1.192092896e-7f, 1.192092896e-7f);
		public static XMVECTOR g_XMInfinity => new(0x7F800000, 0x7F800000, 0x7F800000, 0x7F800000);
		public static XMVECTOR g_XMQNaN => new(0x7FC00000, 0x7FC00000, 0x7FC00000, 0x7FC00000);
		public static XMVECTOR g_XMQNaNTest => new(0x007FFFFF, 0x007FFFFF, 0x007FFFFF, 0x007FFFFF);
		public static XMVECTOR g_XMAbsMask => new(0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF);
		public static XMVECTOR g_XMFltMin => new(0x00800000, 0x00800000, 0x00800000, 0x00800000);
		public static XMVECTOR g_XMFltMax => new(0x7F7FFFFF, 0x7F7FFFFF, 0x7F7FFFFF, 0x7F7FFFFF);
		public static XMVECTOR g_XMNegOneMask => new(0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF, 0xFFFFFFFF);
		public static XMVECTOR g_XMMaskA8R8G8B8 => new(0x00FF0000, 0x0000FF00, 0x000000FF, 0xFF000000);
		public static XMVECTOR g_XMFlipA8R8G8B8 => new(0x00000000, 0x00000000, 0x00000000, 0x80000000);
		public static XMVECTOR g_XMFixAA8R8G8B8 => new(0.0f, 0.0f, 0.0f, 0x80000000U);
		public static XMVECTOR g_XMNormalizeA8R8G8B8 => new(1.0f / (255.0f * 0x10000), 1.0f / (255.0f * 0x100), 1.0f / 255.0f, 1.0f / (255.0f * 0x1000000));
		public static XMVECTOR g_XMMaskA2B10G10R10 => new(0x000003FF, 0x000FFC00, 0x3FF00000, 0xC0000000);
		public static XMVECTOR g_XMFlipA2B10G10R10 => new(0x00000200, 0x00080000, 0x20000000, 0x80000000);
		public static XMVECTOR g_XMFixAA2B10G10R10 => new(-512.0f, -512.0f * 0x400, -512.0f * 0x100000, 0x80000000U);
		public static XMVECTOR g_XMNormalizeA2B10G10R10 => new(1.0f / 511.0f, 1.0f / (511.0f * 0x400), 1.0f / (511.0f * 0x100000), 1.0f / (3.0f * 0x40000000));
		public static XMVECTOR g_XMMaskX16Y16 => new(0x0000FFFF, 0xFFFF0000, 0x00000000, 0x00000000);
		public static XMVECTOR g_XMFlipX16Y16 => new(0x00008000, 0x00000000, 0x00000000, 0x00000000);
		public static XMVECTOR g_XMFixX16Y16 => new(-32768.0f, 0.0f, 0.0f, 0.0f);
		public static XMVECTOR g_XMNormalizeX16Y16 => new(1.0f / 32767.0f, 1.0f / (32767.0f * 65536.0f), 0.0f, 0.0f);
		public static XMVECTOR g_XMMaskX16Y16Z16W16 => new(0x0000FFFF, 0x0000FFFF, 0xFFFF0000, 0xFFFF0000);
		public static XMVECTOR g_XMFlipX16Y16Z16W16 => new(0x00008000, 0x00008000, 0x00000000, 0x00000000);
		public static XMVECTOR g_XMFixX16Y16Z16W16 => new(-32768.0f, -32768.0f, 0.0f, 0.0f);
		public static XMVECTOR g_XMNormalizeX16Y16Z16W16 => new(1.0f / 32767.0f, 1.0f / 32767.0f, 1.0f / (32767.0f * 65536.0f), 1.0f / (32767.0f * 65536.0f));
		public static XMVECTOR g_XMNoFraction => new(8388608.0f, 8388608.0f, 8388608.0f, 8388608.0f);
		public static XMVECTOR g_XMMaskByte => new(0x000000FF, 0x000000FF, 0x000000FF, 0x000000FF);
		public static XMVECTOR g_XMNegateX => new(-1.0f, 1.0f, 1.0f, 1.0f);
		public static XMVECTOR g_XMNegateY => new(1.0f, -1.0f, 1.0f, 1.0f);
		public static XMVECTOR g_XMNegateZ => new(1.0f, 1.0f, -1.0f, 1.0f);
		public static XMVECTOR g_XMNegateW => new(1.0f, 1.0f, 1.0f, -1.0f);
		public static XMVECTOR g_XMSelect0101 => new(XM_SELECT_0, XM_SELECT_1, XM_SELECT_0, XM_SELECT_1);
		public static XMVECTOR g_XMSelect1010 => new(XM_SELECT_1, XM_SELECT_0, XM_SELECT_1, XM_SELECT_0);
		public static XMVECTOR g_XMOneHalfMinusEpsilon => new(0x3EFFFFFD, 0x3EFFFFFD, 0x3EFFFFFD, 0x3EFFFFFD);
		public static XMVECTOR g_XMSelect1000 => new(XM_SELECT_1, XM_SELECT_0, XM_SELECT_0, XM_SELECT_0);
		public static XMVECTOR g_XMSelect1100 => new(XM_SELECT_1, XM_SELECT_1, XM_SELECT_0, XM_SELECT_0);
		public static XMVECTOR g_XMSelect1110 => new(XM_SELECT_1, XM_SELECT_1, XM_SELECT_1, XM_SELECT_0);
		public static XMVECTOR g_XMSelect1011 => new(XM_SELECT_1, XM_SELECT_0, XM_SELECT_1, XM_SELECT_1);
		public static XMVECTOR g_XMFixupY16 => new(1.0f, 1.0f / 65536.0f, 0.0f, 0.0f);
		public static XMVECTOR g_XMFixupY16W16 => new(1.0f, 1.0f, 1.0f / 65536.0f, 1.0f / 65536.0f);
		public static XMVECTOR g_XMFlipY => new(0, 0x80000000, 0, 0);
		public static XMVECTOR g_XMFlipZ => new(0, 0, 0x80000000, 0);
		public static XMVECTOR g_XMFlipW => new(0, 0, 0, 0x80000000);
		public static XMVECTOR g_XMFlipYZ => new(0, 0x80000000, 0x80000000, 0);
		public static XMVECTOR g_XMFlipZW => new(0, 0, 0x80000000, 0x80000000);
		public static XMVECTOR g_XMFlipYW => new(0, 0x80000000, 0, 0x80000000);
		public static XMVECTOR g_XMMaskDec4 => new(0x3FF, 0x3FF << 10, 0x3FF << 20, unchecked((int)0xC0000000));
		public static XMVECTOR g_XMXorDec4 => new(0x200, 0x200 << 10, 0x200 << 20, 0);
		public static XMVECTOR g_XMAddUDec4 => new(0, 0, 0, 32768.0f * 65536.0f);
		public static XMVECTOR g_XMAddDec4 => new(-512.0f, -512.0f * 1024.0f, -512.0f * 1024.0f * 1024.0f, 0);
		public static XMVECTOR g_XMMulDec4 => new(1.0f, 1.0f / 1024.0f, 1.0f / (1024.0f * 1024.0f), 1.0f / (1024.0f * 1024.0f * 1024.0f));
		public static XMVECTOR g_XMMaskByte4 => new(0xFF, 0xFF00, 0xFF0000, 0xFF000000);
		public static XMVECTOR g_XMXorByte4 => new(0x80, 0x8000, 0x800000, 0x00000000);
		public static XMVECTOR g_XMAddByte4 => new(-128.0f, -128.0f * 256.0f, -128.0f * 65536.0f, 0);
		public static XMVECTOR g_XMFixUnsigned => new(32768.0f * 65536.0f, 32768.0f * 65536.0f, 32768.0f * 65536.0f, 32768.0f * 65536.0f);
		public static XMVECTOR g_XMMaxInt => new(65536.0f * 32768.0f - 128.0f, 65536.0f * 32768.0f - 128.0f, 65536.0f * 32768.0f - 128.0f, 65536.0f * 32768.0f - 128.0f);
		public static XMVECTOR g_XMMaxUInt => new(65536.0f * 65536.0f - 256.0f, 65536.0f * 65536.0f - 256.0f, 65536.0f * 65536.0f - 256.0f, 65536.0f * 65536.0f - 256.0f);
		public static XMVECTOR g_XMUnsignedFix => new(32768.0f * 65536.0f, 32768.0f * 65536.0f, 32768.0f * 65536.0f, 32768.0f * 65536.0f);
		public static XMVECTOR g_XMsrgbScale => new(12.92f, 12.92f, 12.92f, 1.0f);
		public static XMVECTOR g_XMsrgbA => new(0.055f, 0.055f, 0.055f, 0.0f);
		public static XMVECTOR g_XMsrgbA1 => new(1.055f, 1.055f, 1.055f, 1.0f);
		public static XMVECTOR g_XMExponentBias => new(127, 127, 127, 127);
		public static XMVECTOR g_XMSubnormalExponent => new(-126, -126, -126, -126);
		public static XMVECTOR g_XMNumTrailing => new(23, 23, 23, 23);
		public static XMVECTOR g_XMMinNormal => new(0x00800000, 0x00800000, 0x00800000, 0x00800000);
		public static XMVECTOR g_XMNegInfinity => new(0xFF800000, 0xFF800000, 0xFF800000, 0xFF800000);
		public static XMVECTOR g_XMNegQNaN => new(0xFFC00000, 0xFFC00000, 0xFFC00000, 0xFFC00000);
		public static XMVECTOR g_XMBin128 => new(0x43000000, 0x43000000, 0x43000000, 0x43000000);
		public static XMVECTOR g_XMBinNeg150 => new(0xC3160000, 0xC3160000, 0xC3160000, 0xC3160000);
		public static XMVECTOR g_XM253 => new(253, 253, 253, 253);
		public static XMVECTOR g_XMExpEst1 => new(-6.93147182e-1f, -6.93147182e-1f, -6.93147182e-1f, -6.93147182e-1f);
		public static XMVECTOR g_XMExpEst2 => new(+2.40226462e-1f, +2.40226462e-1f, +2.40226462e-1f, +2.40226462e-1f);
		public static XMVECTOR g_XMExpEst3 => new(-5.55036440e-2f, -5.55036440e-2f, -5.55036440e-2f, -5.55036440e-2f);
		public static XMVECTOR g_XMExpEst4 => new(+9.61597636e-3f, +9.61597636e-3f, +9.61597636e-3f, +9.61597636e-3f);
		public static XMVECTOR g_XMExpEst5 => new(-1.32823968e-3f, -1.32823968e-3f, -1.32823968e-3f, -1.32823968e-3f);
		public static XMVECTOR g_XMExpEst6 => new(+1.47491097e-4f, +1.47491097e-4f, +1.47491097e-4f, +1.47491097e-4f);
		public static XMVECTOR g_XMExpEst7 => new(-1.08635004e-5f, -1.08635004e-5f, -1.08635004e-5f, -1.08635004e-5f);
		public static XMVECTOR g_XMLogEst0 => new(+1.442693f, +1.442693f, +1.442693f, +1.442693f);
		public static XMVECTOR g_XMLogEst1 => new(-0.721242f, -0.721242f, -0.721242f, -0.721242f);
		public static XMVECTOR g_XMLogEst2 => new(+0.479384f, +0.479384f, +0.479384f, +0.479384f);
		public static XMVECTOR g_XMLogEst3 => new(-0.350295f, -0.350295f, -0.350295f, -0.350295f);
		public static XMVECTOR g_XMLogEst4 => new(+0.248590f, +0.248590f, +0.248590f, +0.248590f);
		public static XMVECTOR g_XMLogEst5 => new(-0.145700f, -0.145700f, -0.145700f, -0.145700f);
		public static XMVECTOR g_XMLogEst6 => new(+0.057148f, +0.057148f, +0.057148f, +0.057148f);
		public static XMVECTOR g_XMLogEst7 => new(-0.010578f, -0.010578f, -0.010578f, -0.010578f);
		public static XMVECTOR g_XMLgE => new(+1.442695f, +1.442695f, +1.442695f, +1.442695f);
		public static XMVECTOR g_XMInvLgE => new(+6.93147182e-1f, +6.93147182e-1f, +6.93147182e-1f, +6.93147182e-1f);
		public static XMVECTOR g_XMLg10 => new(+3.321928f, +3.321928f, +3.321928f, +3.321928f);
		public static XMVECTOR g_XMInvLg10 => new(+3.010299956e-1f, +3.010299956e-1f, +3.010299956e-1f, +3.010299956e-1f);
		public static XMVECTOR g_UByteMax => new(255.0f, 255.0f, 255.0f, 255.0f);
		public static XMVECTOR g_ByteMin => new(-127.0f, -127.0f, -127.0f, -127.0f);
		public static XMVECTOR g_ByteMax => new(127.0f, 127.0f, 127.0f, 127.0f);
		public static XMVECTOR g_ShortMin => new(-32767.0f, -32767.0f, -32767.0f, -32767.0f);
		public static XMVECTOR g_ShortMax => new(32767.0f, 32767.0f, 32767.0f, 32767.0f);
		public static XMVECTOR g_UShortMax => new(65535.0f, 65535.0f, 65535.0f, 65535.0f);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>
	/// <para>
	/// The <c><b>XMVECTORI32</b></c> type supports the use of C/C++ initializer syntax to load floating-point values into an instance of
	/// <c><b>XMVECTOR</b></c> type.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>The features listed here are only available when developing with C++.</para>
	/// </para>
	/// <para></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/dxmath/ovw-xmvectori32-extensions
	[PInvokeData("directxmath.h")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct XMVECTORI32
	{
		/// <summary>The XMVECTOR.</summary>
		[FieldOffset(0)]
		public XMVECTOR v;

		/// <summary>The int[4] array.</summary>
		[FieldOffset(0)]
		public unsafe fixed int i[4];

		/// <summary>Initializes a new instance of the <see cref="XMVECTORI32"/> struct.</summary>
		/// <param name="x">The x-coordinate.</param>
		/// <param name="y">The y-coordinate.</param>
		/// <param name="z">The z-coordinate.</param>
		/// <param name="w">The w-coordinate.</param>
		public XMVECTORI32(int x, int y, int z, int w)
		{ unsafe { i[0] = x; i[1] = y; i[2] = z; i[3] = w; } }

		/// <summary>Performs an implicit conversion from <see cref="Vanara.PInvoke.DirectXMath.XMVECTORI32"/> to <see cref="Vanara.PInvoke.DirectXMath.XMVECTOR"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator XMVECTOR(XMVECTORI32 v) => v.v;
	}

	/// <summary>
	/// <para>
	/// An opaque, portable type to support the use of C/C++ initializer syntax to load uint8_t values into an instance of
	/// <c><b>XMVECTOR</b></c> type.
	/// </para>
	/// <para><c>typedef XMVECTORU8 vectoru8;</c></para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// For a list of additional functionality, such as constructors and operators, available using XMVECTORU8 when programming in C++, see
	/// <c>XMVECTORU8 Extensions</c>.
	/// </para>
	/// <para>
	/// The <c><b>XMVECTORF32</b></c>, <c><b>XMVECTORU32</b></c>, <c><b>XMVECTORI32</b></c>, and <b>XMVECTORU8</b> structures are provided
	/// as a mechanism for creating <c><b>XMVECTOR</b></c> from different constant data types (floating point, unsigned integer, integer,
	/// and byte) using initializers.
	/// </para>
	/// <para>
	/// This is necessary to support <c><b>XMVECTOR</b></c>, as it does not itself support initializers, for portability and optimization reasons.
	/// </para>
	/// <para>For example:</para>
	/// <para>
	/// <c>XMVECTOR data; XMVECTORU8 byteVector = { (uint8_t) 1,(uint8_t) 16,(uint8_t)101,(uint8_t) 62, (uint8_t) 4,(uint8_t) 0,(uint8_t)
	/// 2,(uint8_t) 99, (uint8_t) 9,(uint8_t) 18,(uint8_t) 0,(uint8_t) 0, (uint8_t)100,(uint8_t) 51,(uint8_t) 23,(uint8_t)117}; data = floatingVector;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/dxmath/xmvectoru8-data-type
	[PInvokeData("directxmath.h")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct XMVECTORU8
	{
		/// <summary>The XMVECTOR.</summary>
		[FieldOffset(0)]
		public XMVECTOR v;

		/// <summary>The byte[16] array.</summary>
		[FieldOffset(0)]
		public unsafe fixed byte u[16];

		/// <summary>Initializes a new instance of the <see cref="XMVECTORU8"/> struct.</summary>
		/// <param name="bytes">The bytes.</param>
		public XMVECTORU8(byte[] bytes)
		{
			if (bytes is null || bytes.Length != 16)
				throw new ArgumentException("Array must have 16 elements.", nameof(bytes));
			unsafe
			{
				for (var i = 0; i < 16; i++)
					u[i] = bytes[i];
			}
		}

		/// <summary>Performs an implicit conversion from <see cref="Vanara.PInvoke.DirectXMath.XMVECTORU8"/> to <see cref="Vanara.PInvoke.DirectXMath.XMVECTOR"/>.</summary>
		/// <param name="v">The vector.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator XMVECTOR(XMVECTORU8 v) => v.v;
	}
}