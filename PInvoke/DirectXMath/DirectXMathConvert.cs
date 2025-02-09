using System;
using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

public static partial class DirectXMath
{
	/// <summary>Tests the comparison value to determine if all of the compared components are false.</summary>
	/// <param name="CR">
	/// Comparison value to test. The comparison value is typically retrieved using a recording version of a DirectXMath function such as
	/// <c>XMVector4EqualR</c>. The names of the recording functions end with an "R".
	/// </param>
	/// <returns>Returns true if all of the compared components are false.</returns>
	/// <remarks>
	/// <para>The following code snippet highlights how this function might be used:</para>
	/// <para><c>uint32_t comparisonValue = XMVector4EqualR( V1, V2 ); if( XMComparisonAllFalse( comparisonValue ) ) { DoStuff(); }</c></para>
	/// <para>
	/// The <c>DoStuff</c> function will be called only if all four components of <i>V1</i> and <i>V2</i> are different (all compared
	/// components are false).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcomparisonallfalse bool XMComparisonAllFalse( [in]
	// uint32_t CR ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMComparisonAllFalse")]
	public static bool XMComparisonAllFalse(uint CR) => (CR & XM_CRMASK_CR6FALSE) == XM_CRMASK_CR6FALSE;

	/// <summary>Tests the comparison value to determine if all of the compared components are within set bounds.</summary>
	/// <param name="CR">
	/// Comparison value to test. The comparison value is typically retrieved using a recording version of a DirectXMath function such as
	/// <c>XMVectorInBoundsR</c>. The names of the recording functions end with an "R".
	/// </param>
	/// <returns>Returns true if all of the compared components within the set bounds.</returns>
	/// <remarks>
	/// <para>The following code snippet highlights how this function might be used:</para>
	/// <para>
	/// <c>uint32_t comparisonValue = XMVectorInBoundsR( V, Bounds ); if( XMComparisonAllInBounds( comparisonValue ) ) { DoStuff(); }</c>
	/// </para>
	/// <para>
	/// The <c>DoStuff</c> function will be called only if all four components of <i>V</i> are within the volume determined by <i>Bounds</i>
	/// and - <i>Bounds</i>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcomparisonallinbounds bool XMComparisonAllInBounds(
	// [in] uint32_t CR ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMComparisonAllInBounds")]
	public static bool XMComparisonAllInBounds(uint CR) => (CR & XM_CRMASK_CR6BOUNDS) == XM_CRMASK_CR6BOUNDS;

	/// <summary>Tests the comparison value to determine if all of the compared components are true.</summary>
	/// <param name="CR">
	/// Comparison value to test. The comparison value is typically retrieved using a recording version of a DirectXMath function such as
	/// <c>XMVector4EqualR</c>. The names of the recording functions end with an "R".
	/// </param>
	/// <returns>Returns true if all of the compared components are true.</returns>
	/// <remarks>
	/// <para>The following code snippet highlights how this function might be used:</para>
	/// <para><c>uint32_t comparisonValue = XMVector4EqualR( V1, V2 ); if( XMComparisonAllTrue( comparisonValue ) ) { DoStuff(); }</c></para>
	/// <para>
	/// The <c>DoStuff</c> function will be called only if all four components of <i>V1</i> and <i>V2</i> are equal (all compared components
	/// are true).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcomparisonalltrue bool XMComparisonAllTrue( [in]
	// uint32_t CR ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMComparisonAllTrue")]
	public static bool XMComparisonAllTrue(uint CR) => (CR & XM_CRMASK_CR6TRUE) == XM_CRMASK_CR6TRUE;

	/// <summary>Tests the comparison value to determine if any of the compared components are false.</summary>
	/// <param name="CR">
	/// Comparison value to test. The comparison value is typically retrieved using a recording version of a DirectXMath function such as
	/// <c>XMVector4EqualR</c>. The names of the recording functions end with an "R".
	/// </param>
	/// <returns>Returns true if any of the compared components are false.</returns>
	/// <remarks>
	/// <para>The following code snippet highlights how this function might be used:</para>
	/// <para><c>uint32_t comparisonValue = XMVector4EqualR( V1, V2 ); if( XMComparisonAnyFalse( comparisonValue ) ) { DoStuff(); }</c></para>
	/// <para>
	/// The <c>DoStuff</c> function will be called only if any of the four components of <i>V1</i> and <i>V2</i> are different (any of the
	/// compared components are false).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcomparisonanyfalse bool XMComparisonAnyFalse( [in]
	// uint32_t CR ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMComparisonAnyFalse")]
	public static bool XMComparisonAnyFalse(uint CR) => (CR & XM_CRMASK_CR6TRUE) != XM_CRMASK_CR6TRUE;

	/// <summary>Tests the comparison value to determine if any of the compared components are outside the set bounds.</summary>
	/// <param name="CR">
	/// Comparison value to test. The comparison value is typically retrieved using a recording version of a DirectXMath function such as
	/// <c>XMVectorInBoundsR</c>. The names of the recording functions end with an "R".
	/// </param>
	/// <returns>Returns true if any of the compared components are outside the set bounds.</returns>
	/// <remarks>
	/// <para>The following code snippet highlights how this function might be used:</para>
	/// <para>
	/// <c>uint32_t comparisonValue = XMVectorInBoundsR( V, Bounds ); if( XMComparisonAnyOutOfBounds( comparisonValue ) ) { DoStuff(); }</c>
	/// </para>
	/// <para>
	/// The <c>DoStuff</c> function will be called only if at least one of the four components of <i>V</i> are outside the volume determined
	/// by <i>Bounds</i> and - <i>Bounds</i>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcomparisonanyoutofbounds bool
	// XMComparisonAnyOutOfBounds( [in] uint32_t CR ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMComparisonAnyOutOfBounds")]
	public static bool XMComparisonAnyOutOfBounds(uint CR) => (CR & XM_CRMASK_CR6BOUNDS) != XM_CRMASK_CR6BOUNDS;

	/// <summary>Tests the comparison value to determine if any of the compared components are true.</summary>
	/// <param name="CR">
	/// Comparison value to test. The comparison value is typically retrieved using a recording version of a DirectXMath function such as
	/// <c>XMVector4EqualR</c>. The names of the recording functions end with an "R".
	/// </param>
	/// <returns>Returns true if any of the compared components are true.</returns>
	/// <remarks>
	/// <para>The following code snippet highlights how this function might be used:</para>
	/// <para><c>uint32_t comparisonValue = XMVector4EqualR( V1, V2 ); if( XMComparisonAnyTrue( comparisonValue ) ) { DoStuff(); }</c></para>
	/// <para>
	/// The <c>DoStuff</c> function will be called only if any of the four components of <i>V1</i> and <i>V2</i> are equal (any compared
	/// components are true).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcomparisonanytrue bool XMComparisonAnyTrue( [in]
	// uint32_t CR ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMComparisonAnyTrue")]
	public static bool XMComparisonAnyTrue(uint CR) => (CR & XM_CRMASK_CR6FALSE) != XM_CRMASK_CR6FALSE;

	/// <summary>Tests the comparison value to determine if the compared components had mixed results--some true and some false.</summary>
	/// <param name="CR">
	/// Comparison value to test. The comparison value is typically retrieved using a recording version of a DirectXMath function such as
	/// <c>XMVector4EqualR</c>. The names of the recording functions end with an "R".
	/// </param>
	/// <returns>Returns true if some of the compared components are true and some of the compared components are false.</returns>
	/// <remarks>
	/// <para>The following code snippet highlights how this function might be used:</para>
	/// <para><c>uint32_t comparisonValue = XMVector4EqualR( V1, V2 ); if( XMComparisonMixed( comparisonValue ) ) { DoStuff(); }</c></para>
	/// <para>
	/// The <c>DoStuff</c> function will be called only if some of the components of <i>V1</i> and <i>V2</i> are different and some of the
	/// components are the same. The <c>DoStuff</c> function will not be called if all of the components are equal, nor will it be called if
	/// all of the components are different.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmcomparisonmixed bool XMComparisonMixed( [in]
	// uint32_t CR ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMComparisonMixed")]
	public static bool XMComparisonMixed(uint CR) => (CR & XM_CRMASK_CR6) == 0;

	/// <summary>Converts an angle measured in radians into one measured in degrees.</summary>
	/// <param name="fRadians">Size of an angle in radians.</param>
	/// <returns>Size of the angle in degrees.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmconverttodegrees float XMConvertToDegrees( [in]
	// float fRadians ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMConvertToDegrees")]
	public static float XMConvertToDegrees(float fRadians) => fRadians * (180.0f / XM_PI);

	/// <summary>Converts an angle measured in degrees into one measured in radians.</summary>
	/// <param name="fDegrees">Size of an angle in degrees.</param>
	/// <returns>Size of the angle in radians.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmconverttoradians float XMConvertToRadians( [in]
	// float fDegrees ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMConvertToRadians")]
	public static float XMConvertToRadians(float fDegrees) => fDegrees * (XM_PI / 180.0f);

	/// <summary>
	/// Converts an <c>XMVECTOR</c> with <b>float</b> components to an <b>XMVECTOR</b> with <b>int</b> components and applies a uniform bias.
	/// </summary>
	/// <param name="VFloat">Vector with <b>float</b> components that is to be converted.</param>
	/// <param name="MulExponent">
	/// Each component of <i>VFloat</i> will be converted to a <b>int</b> and then multiplied by two raised to the <i>DivExponent</i> power.
	/// This parameter must be a number (an immediate value) and not a variable.
	/// </param>
	/// <returns>Returns the converted vector, where each component has been multiplied by two raised to the <i>MulExponent</i> power.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmconvertvectorfloattoint XMVECTOR XM_CALLCONV
	// XMConvertVectorFloatToInt( [in] FXMVECTOR VFloat, [in] uint32_t MulExponent ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMConvertVectorFloatToInt")]
	public static XMVECTOR XMConvertVectorFloatToInt(this FXMVECTOR VFloat, uint MulExponent)
	{
		if (MulExponent >= 32)
			throw new ArgumentOutOfRangeException(nameof(MulExponent), "MulExponent must be less than 32.");
		float fScale = 1u << (int)MulExponent;
		return new(FloatToInt(VFloat.x * fScale), FloatToInt(VFloat.y * fScale), FloatToInt(VFloat.z * fScale), FloatToInt(VFloat.w * fScale));

		static uint FloatToInt(float f) => f switch
		{
			<= -(65536.0f * 32768.0f) => unchecked((uint)(-0x7FFFFFFF - 1)),
			> 65536.0f * 32768.0f - 128.0f => unchecked(0x7FFFFFFF),
			_ => unchecked((uint)(int)f)
		};
	}

	/// <summary>
	/// Converts an <c>XMVECTOR</c> with <b>float</b> components to an <b>XMVECTOR</b> with <b>uint32_t</b> components and applies a uniform bias.
	/// </summary>
	/// <param name="VFloat">Vector with <b>float</b> components that is to be converted.</param>
	/// <param name="MulExponent">
	/// Each component of <i>VFloat</i> will be converted to a <b>int</b> and then multiplied by two raised to the <i>DivExponent</i> power.
	/// This parameter must be a number (an immediate value) and not a variable.
	/// </param>
	/// <returns>Returns the converted vector, where each component has been multiplied by two raised to the <i>MulExponent</i> power.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmconvertvectorfloattouint XMVECTOR XM_CALLCONV
	// XMConvertVectorFloatToUInt( [in] FXMVECTOR VFloat, [in] uint32_t MulExponent ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMConvertVectorFloatToUInt")]
	public static XMVECTOR XMConvertVectorFloatToUInt(this FXMVECTOR VFloat, uint MulExponent)
	{
		if (MulExponent >= 32)
			throw new ArgumentOutOfRangeException(nameof(MulExponent), "MulExponent must be less than 32.");
		float fScale = 1u << (int)MulExponent;
		return new(FloatToUInt(VFloat.x * fScale), FloatToUInt(VFloat.y * fScale), FloatToUInt(VFloat.z * fScale), FloatToUInt(VFloat.w * fScale));
		static uint FloatToUInt(float f) => f switch
		{
			<= 0.0f => 0,
			> 4294967040.0f => 0xFFFFFFFF,
			_ => (uint)f
		};
	}

	/// <summary>
	/// Converts an <c>XMVECTOR</c> with <b>int</b> components to an <b>XMVECTOR</b> with <b>float</b> components and applies a uniform bias.
	/// </summary>
	/// <param name="VInt">Vector with <b>int</b> components that is to be converted.</param>
	/// <param name="DivExponent">
	/// Each component of <i>VInt</i> will be converted to a <b>float</b> and then divided by two raised to the <i>DivExponent</i> power.
	/// This parameter must be a number (an immediate value) and not a variable.
	/// </param>
	/// <returns>Returns the converted vector, where each component has been divided by two raised to the <i>DivExponent</i> power.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmconvertvectorinttofloat XMVECTOR XM_CALLCONV
	// XMConvertVectorIntToFloat( [in] FXMVECTOR VInt, [in] uint32_t DivExponent ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMConvertVectorIntToFloat")]
	public static XMVECTOR XMConvertVectorIntToFloat(this FXMVECTOR VInt, uint DivExponent)
	{
		if (DivExponent >= 32)
			throw new ArgumentOutOfRangeException(nameof(DivExponent), "DivExponent must be less than 32.");
		float fScale = 1.0f / (1u << (int)DivExponent);
		return new(unchecked((int)VInt.ux) * fScale, unchecked((int)VInt.uy) * fScale, unchecked((int)VInt.uz) * fScale, unchecked((int)VInt.uw) * fScale);
	}

	/// <summary>
	/// Converts an <c>XMVECTOR</c> with <b>uint32_t</b> components to an <b>XMVECTOR</b> with <b>float</b> components and applies a uniform bias.
	/// </summary>
	/// <param name="VUInt">Vector with <b>uint32_t</b> components that is to be converted.</param>
	/// <param name="DivExponent">
	/// Each component of <i>VUInt</i> will be converted to a <b>float</b> and then divided by two raised to the <i>DivExponent</i> power.
	/// This parameter must be a number (an immediate value) and not a variable.
	/// </param>
	/// <returns>Returns the converted vector, where each component has been divided by two raised to the <i>DivExponent</i> power.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmconvertvectoruinttofloat XMVECTOR XM_CALLCONV
	// XMConvertVectorUIntToFloat( [in] FXMVECTOR VUInt, [in] uint32_t DivExponent ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMConvertVectorUIntToFloat")]
	public static XMVECTOR XMConvertVectorUIntToFloat(this FXMVECTOR VUInt, uint DivExponent)
	{
		if (DivExponent >= 32)
			throw new ArgumentOutOfRangeException(nameof(DivExponent), "DivExponent must be less than 32.");
		float fScale = 1.0f / (1u << (int)DivExponent);
		return new(VUInt.ux * fScale, VUInt.uy * fScale, VUInt.uz * fScale, VUInt.uw * fScale);
	}

	/// <summary>Loads a floating-point scalar value into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">
	/// Address of the scalar data to load. The data pointed to by this parameter must be 4-byte aligned and reside in cached memory.
	/// </param>
	/// <returns>
	/// Returns an <c>XMVECTOR</c> whose <b>x</b> member is loaded with the data from the <i>pSource</i> parameter. The other components of
	/// the returned vector will be initialized to 0.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat XMVECTOR XM_CALLCONV XMLoadFloat( [in]
	// const float *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat")]
	public static XMVECTOR XMLoadFloat(float[] pSource) => pSource is null || pSource.Length == 0 ? throw new ArgumentNullException(nameof(pSource)) : new(pSource[0], 0, 0, 0);

	/// <summary>Loads an <c>XMFLOAT2</c> into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT2</c> structure to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>
	/// The <b>x</b> and <b>y</b> members of the <c>XMFLOAT2</c> are loaded into the corresponding members of the <c>XMVECTOR</c>. The
	/// <b>z</b> and <b>w</b> members of the returned <b>XMVECTOR</b> will be initialized to 0.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat2 XMVECTOR XM_CALLCONV XMLoadFloat2( [in]
	// const XMFLOAT2 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat2")]
	public static XMVECTOR XMLoadFloat2(in XMFLOAT2 pSource) => new(pSource.x, pSource.y, 0, 0);

	/// <summary>Loads an <c>XMFLOAT2A</c> into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT2A</c> structure to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>
	/// The <b>x</b> and <b>y</b> members of the <c>XMFLOAT2A</c> are loaded into the corresponding members of the <c>XMVECTOR</c>. The
	/// <b>z</b> and <b>w</b> members of the returned <b>XMVECTOR</b> will be initialized to 0.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat2a XMVECTOR XM_CALLCONV XMLoadFloat2A( [in]
	// const XMFLOAT2A *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat2A")]
	public static XMVECTOR XMLoadFloat2A(in XMFLOAT2A pSource) => new(pSource.x, pSource.y, 0, 0);

	/// <summary>Loads an <c>XMFLOAT3</c> into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT3</c> structure to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>
	/// The <b>x</b>, <b>y</b> and <b>z</b> members of the <c>XMFLOAT3</c> are loaded into the corresponding members of the <c>XMVECTOR</c>.
	/// The <b>w</b> member of the returned <b>XMVECTOR</b> is initialized to 0.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat3 XMVECTOR XM_CALLCONV XMLoadFloat3( [in]
	// const XMFLOAT3 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat3")]
	public static XMVECTOR XMLoadFloat3(in XMFLOAT3 pSource) => new(pSource.x, pSource.y, pSource.z, 0);

	/// <summary>Loads an <c>XMFLOAT3A</c> into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT3A</c> structure to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>
	/// The <b>x</b>, <b>y</b>, and <b>z</b> members of the <c>XMFLOAT3A</c> are loaded into the corresponding members of the returned
	/// <c>XMVECTOR</c>. The <b>w</b> member of the <b>XMVECTOR</b> is initialized to 0.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat3a XMVECTOR XM_CALLCONV XMLoadFloat3A( [in]
	// const XMFLOAT3A *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat3A")]
	public static XMVECTOR XMLoadFloat3A(in XMFLOAT3A pSource) => new(pSource.x, pSource.y, pSource.z, 0);

	/// <summary>Loads an <c>XMFLOAT3X3</c> into an <c>XMMATRIX</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT3X3</c> structure to load. This parameter must point to cached memory.</param>
	/// <returns>
	/// <para>Returns an <c>XMMATRIX</c> loaded with the data from the <i>pSource</i> parameter.</para>
	/// <para>This function performs a partial load of the returned <c>XMMATRIX</c>. See <c>Getting Started</c> for more information.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>XMFLOAT3X3</c> is a row-major form of the matrix. This function could be used to read column-major data, but would then need to
	/// be transposed with <c>XMMatrixTranpose</c> before use in other XMMATRIX functions.
	/// </para>
	/// <para>
	/// The members of the <c>XMFLOAT3X3</c> structures ( <b>_11</b>, <b>_12</b>, <b>_13</b>, and so on) are loaded into the corresponding
	/// members of the <c>XMMATRIX</c>. The remaining members of the returned <b>XMMATRIX</b> are 0.0f, except for <b>_44</b>, which is 1.0f.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat3x3 XMMATRIX XM_CALLCONV XMLoadFloat3x3(
	// [in] const XMFLOAT3X3 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat3x3")]
	public static XMMATRIX XMLoadFloat3x3(in XMFLOAT3X3 pSource) =>
		new(pSource._11, pSource._12, pSource._13, 0, pSource._21, pSource._22, pSource._23, 0, pSource._31, pSource._32, pSource._33, 0, 0, 0, 0, 1);

	/// <summary>Loads an <c><b>XMFLOAT3X4</b></c> into an <c><b>XMMATRIX</b></c>.</summary>
	/// <param name="pSource">
	/// <para>Type: <b>const <c>XMFLOAT3X4</c> *</b></para>
	/// <para>Pointer to the constant <c><b>XMFLOAT3X4</b></c> structure to load. This argument must point to cached memory.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>XMMATRIX</c></b></para>
	/// <para>An <c><b>XMMATRIX</b></c> loaded with the data from the pSource argument.</para>
	/// <para>This function performs a partial load of the returned <b>XMMATRIX</b>. For more info, see <c>Getting started (DirectXMath)</c>.</para>
	/// </returns>
	/// <remarks>
	/// <c><b>XMFLOAT3X4</b></c> is a row-major form of the matrix. <b>XMLoadFloat3x4</b> could be used to read column-major data, but that
	/// would then need to be transposed with <c>XMMatrixTranspose</c> before use in other <c><b>XMMATRIX</b></c> functions.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat3x4 XMMATRIX XM_CALLCONV XMLoadFloat3x4(
	// const XMFLOAT3X4 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat3x4")]
	public static XMMATRIX XMLoadFloat3x4(in XMFLOAT3X4 pSource) =>
		new(pSource._11, pSource._21, pSource._31, 0, pSource._12, pSource._22, pSource._32, 0, pSource._13, pSource._23, pSource._33, 0, pSource._14, pSource._24, pSource._34, 1);

	/// <summary>Loads an <c><b>XMFLOAT3X4A</b></c> into an <c><b>XMMATRIX</b></c>.</summary>
	/// <param name="pSource">
	/// <para>Type: <b>const <c>XMFLOAT3X4A</c> *</b></para>
	/// <para>Pointer to the constant <c><b>XMFLOAT3X4A</b></c> structure to load. This argument must point to cached memory.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>XMMATRIX</c></b></para>
	/// <para>An <c><b>XMMATRIX</b></c> loaded with the data from the pSource argument.</para>
	/// <para>This function performs a partial load of the returned <b>XMMATRIX</b>. For more info, see <c>Getting started (DirectXMath)</c>.</para>
	/// </returns>
	/// <remarks>
	/// <c><b>XMFLOAT3X4A</b></c> is a row-major form of the matrix. <b>XMLoadFloat3x4A</b> could be used to read column-major data, but
	/// that would then need to be transposed with <c>XMMatrixTranspose</c> before use in other <c><b>XMMATRIX</b></c> functions.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat3x4a XMMATRIX XM_CALLCONV XMLoadFloat3x4A(
	// const XMFLOAT3X4A *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat3x4A")]
	public static XMMATRIX XMLoadFloat3x4A(in XMFLOAT3X4A pSource) => XMLoadFloat3x4(pSource);

	/// <summary>Loads an <c>XMFLOAT4</c> into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT4</c> structure to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>
	/// The <b>x</b>, <b>y</b>, <b>z</b>, and <b>w</b> members of the <c>XMFLOAT4</c> are loaded into the corresponding members of the <c>XMVECTOR</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat4 XMVECTOR XM_CALLCONV XMLoadFloat4( [in]
	// const XMFLOAT4 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat4")]
	public static XMVECTOR XMLoadFloat4(in XMFLOAT4 pSource) => new(pSource.x, pSource.y, pSource.z, pSource.w);

	/// <summary>Loads an <c>XMFLOAT4A</c> into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT4A</c> structure to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>The members of the <c>XMFLOAT4A</c> are loaded into the corresponding members of the returned <c>XMVECTOR</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat4a XMVECTOR XM_CALLCONV XMLoadFloat4A( [in]
	// const XMFLOAT4A *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat4A")]
	public static XMVECTOR XMLoadFloat4A(in XMFLOAT4A pSource) => XMLoadFloat4(pSource);

	/// <summary>Loads an <c>XMFLOAT4X3</c> into an <c>XMMATRIX</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT4X3</c> structure to load. This parameter must point to cached memory.</param>
	/// <returns>
	/// <para>Returns an <c>XMMATRIX</c> loaded with the data from the <i>pSource</i> parameter.</para>
	/// <para>This function performs a partial load of the returned <c>XMMATRIX</c>. See <c>Getting Started</c> for more information.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>XMFLOAT4X3</c> is a row-major form of the matrix. This function cannot be used to read column-major data since it assumes the
	/// last column is 0 0 0 1.
	/// </para>
	/// <para>
	/// The members of the <c>XMFLOAT4X3</c> structure ( <b>_11</b>, <b>_12</b>, <b>_13</b>, and so on) are loaded into the corresponding
	/// members of the <c>XMMATRIX</c>. The remaining members of the returned <b>XMMATRIX</b> are 0.0f, except for <b>_44</b>, which is 1.0f.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat4x3 XMMATRIX XM_CALLCONV XMLoadFloat4x3(
	// [in] const XMFLOAT4X3 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat4x3")]
	public static XMMATRIX XMLoadFloat4x3(in XMFLOAT4X3 pSource) =>
		new(pSource._11, pSource._12, pSource._13, 0, pSource._21, pSource._22, pSource._23, 0, pSource._31, pSource._32, pSource._33, 0, pSource._41, pSource._42, pSource._43, 1);

	/// <summary>Loads an <c>XMFLOAT4X3A</c> into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT4X3A</c> structure to load.</param>
	/// <returns>
	/// <para>Returns an <c>XMMATRIX</c> loaded with the data from the <i>pSource</i> parameter.</para>
	/// <para>This function performs a partial load of the returned <c>XMMATRIX</c>. See <c>Getting Started</c> for more information.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>XMFLOAT4X3A</c> is a row-major form of the matrix. This function cannot be used to read column-major data since it assumes the
	/// last column is 0 0 0 1.
	/// </para>
	/// <para>
	/// The members of the <c>XMFLOAT4X4A</c> structure ( <b>_11</b>, <b>_12</b>, <b>_13</b>, and so on) are loaded into the corresponding
	/// members of the <c>XMMATRIX</c>. The remaining members of the returned <b>XMMATRIX</b> are 0.0f, except for <b>_44</b>, which is 1.0f.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat4x3a XMMATRIX XM_CALLCONV XMLoadFloat4x3A(
	// [in] const XMFLOAT4X3A *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat4x3A")]
	public static XMMATRIX XMLoadFloat4x3A(in XMFLOAT4X3A pSource) => XMLoadFloat4x3(pSource);

	/// <summary>Loads an <c>XMFLOAT4X4</c> into an <c>XMMATRIX</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT4X4</c> structure to load.</param>
	/// <returns>Returns an <c>XMMATRIX</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMFLOAT4X4</c> is a row-major form of the matrix. This function could be used to read column-major data, but would then need to
	/// be transposed with <c>XMMatrixTranpose</c> before use in other XMMATRIX functions.
	/// </para>
	/// <para>
	/// The members of the <c>XMFLOAT4X4</c> structure ( <b>_11</b>, <b>_12</b>, <b>_13</b>, and so on) are loaded into the corresponding
	/// members of the <c>XMMATRIX</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat4x4 XMMATRIX XM_CALLCONV XMLoadFloat4x4(
	// [in] const XMFLOAT4X4 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat4x4")]
	public static XMMATRIX XMLoadFloat4x4(in XMFLOAT4X4 pSource) =>
		new(pSource._11, pSource._12, pSource._13, pSource._14, pSource._21, pSource._22, pSource._23, pSource._24, pSource._31, pSource._32, pSource._33, pSource._34, pSource._41, pSource._42, pSource._43, pSource._44);

	/// <summary>Loads an <c>XMFLOAT4X4A</c> into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of the <c>XMFLOAT4X4A</c> structure to load.</param>
	/// <returns>Returns an <c>XMMATRIX</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMFLOAT4X4A</c> is a row-major form of the matrix. This function could be used to read column-major data, but would then need to
	/// be transposed with <c>XMMatrixTranpose</c> before use in other XMMATRIX functions.
	/// </para>
	/// <para>
	/// The members of the <c>XMFLOAT4X4A</c> structure ( <b>_11</b>, <b>_12</b>, <b>_13</b>, and so on) are loaded into the corresponding
	/// members of the <c>XMMATRIX</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadfloat4x4a XMMATRIX XM_CALLCONV XMLoadFloat4x4A(
	// [in] const XMFLOAT4X4A *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadFloat4x4A")]
	public static XMMATRIX XMLoadFloat4x4A(in XMFLOAT4X4A pSource) => XMLoadFloat4x4(pSource);

	/// <summary>Loads a scalar value into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of the scalar data to load.</param>
	/// <returns>
	/// Returns an <c>XMVECTORI</c> whose <b>x</b> member is loaded with the data from the <i>pSource</i> parameter. The other components of
	/// the returned vector will be initialized to 0.
	/// </returns>
	/// <remarks>
	/// <para>To convert the loaded <c>XMVECTOR</c> into float values, use <c>XMConvertVectorUIntToFloat</c> or <c>XMConvertVectorIntToFloat</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadint XMVECTOR XM_CALLCONV XMLoadInt( [in] const
	// uint32_t *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadInt")]
	public static XMVECTOR XMLoadInt(uint[] pSource) => pSource is null || pSource.Length == 0 ? throw new ArgumentNullException(nameof(pSource)) : new(pSource[0], 0, 0, 0);

	/// <summary>Loads data into the x and y components of an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of the data to load.</param>
	/// <returns>Returns an <c>XMVECTORI</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>The z and w components of the returned <c>XMVECTOR</c> will be initialized to 0.</para>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMLoadInt2A</c> with a casting operator.</para>
	/// <para>To convert the loaded <c>XMVECTOR</c> into float values, use <c>XMConvertVectorUIntToFloat</c> or <c>XMConvertVectorIntToFloat</c>.</para>
	/// <para>The following pseudocode shows you the operation of the function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; uint32_t* pElement = (uint32_t*)pSource; V.u[0] = pElement[0]; V.u[1] = pElement[1]; V.u[2] = 0; V.u[3] = 0;
	/// return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadint2 XMVECTOR XM_CALLCONV XMLoadInt2( [in] const
	// uint32_t *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadInt2")]
	public static XMVECTOR XMLoadInt2(uint[] pSource) => pSource is null || pSource.Length < 2 ? throw new ArgumentNullException(nameof(pSource)) : new(pSource[0], pSource[1], 0, 0);

	/// <summary>Loads 16-byte aligned data into the <b>x</b> and <b>y</b> components of an <c>XMVECTOR</c>.</summary>
	/// <param name="PSource">Address of the 16-byte aligned data to load.</param>
	/// <returns>Returns an <c>XMVECTORI</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>The z and w components of the returned <c>XMVECTOR</c> will be initialized to 0.</para>
	/// <para>To convert the loaded <c>XMVECTOR</c> into float values, use <c>XMConvertVectorUIntToFloat</c> or <c>XMConvertVectorIntToFloat</c>.</para>
	/// <para>The following pseudocode shows you the operation of the function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; uint32_t* pElement = (uint32_t*)pSource; assert(((uint32_t_PTR)pSource &amp; 0xF) == 0); V.u[0] =
	/// pElement[0]; V.u[1] = pElement[1]; V.u[2] = 0; V.u[3] = 0; return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadint2a XMVECTOR XM_CALLCONV XMLoadInt2A( [in]
	// const uint32_t *PSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadInt2A")]
	public static XMVECTOR XMLoadInt2A(uint[] PSource) => XMLoadInt2(PSource);

	/// <summary>
	/// <para>Loads data into the x, y, and z components of an <c>XMVECTOR</c>, without type checking.</para>
	/// <para>
	/// <b>Note</b>  This function is provided for backward compatibility with the Xbox Math library. You should use <b>XMLoadInt3</b> when
	/// you load integer data, and use <c>XMLoadFloat3</c> when you load floating point data.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="pSource">Address of the data to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>The w component of the returned <c>XMVECTOR</c> is initialized to 0.</para>
	/// <para>To convert the loaded <c>XMVECTOR</c> into float values, use <c>XMConvertVectorUIntToFloat</c> or <c>XMConvertVectorIntToFloat</c>.</para>
	/// <para>The following pseudocode shows you the operation of the function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; uint32_t* pElement = (uint32_t*)pSource; V.u[0] = pElement[0]; V.u[1] = pElement[1]; V.u[2] = pElement[2];
	/// V.u[3] = 0; return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadint3 XMVECTOR XM_CALLCONV XMLoadInt3( [in] const
	// uint32_t *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadInt3")]
	public static XMVECTOR XMLoadInt3(uint[] pSource) => pSource is null || pSource.Length < 3
			? throw new ArgumentNullException(nameof(pSource))
			: new(pSource[0], pSource[1], pSource[2], 0);

	/// <summary>
	/// <para>Loads 16-byte aligned data into the <b>x</b>, <b>y</b>, and <b>z</b> components of an <c>XMVECTOR</c>, without type checking.</para>
	/// <para>
	/// <b>Note</b>  This function is provided for backward compatibility with the Xbox Math library. You should use <b>XMLoadInt3A</b> when
	/// you load integer data, and <c>XMLoadFloat3A</c> when you load floating point data.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="pSource">Address of the 16-byte aligned data to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>The w component of the returned <c>XMVECTOR</c> is initialized to 0.</para>
	/// <para>To convert the loaded <c>XMVECTOR</c> into float values, use <c>XMConvertVectorUIntToFloat</c> or <c>XMConvertVectorIntToFloat</c>.</para>
	/// <para>The following pseudocode shows you the operation of the function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; uint32_t* pElement = (uint32_t*)pSource; assert(((uint32_t_PTR)pSource &amp; 0xF) == 0); V.u[0] =
	/// pElement[0]; V.u[1] = pElement[1]; V.u[2] = pElement[2]; V.u[3] = 0; return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadint3a XMVECTOR XM_CALLCONV XMLoadInt3A( [in]
	// const uint32_t *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadInt3A")]
	public static XMVECTOR XMLoadInt3A(uint[] pSource) => XMLoadInt3(pSource);

	/// <summary>
	/// <para>Loads data into an <c>XMVECTOR</c>, without type checking.</para>
	/// <para>
	/// <b>Note</b>  This function is provided for backward compatibility with the Xbox Math library. You should use <b>XMLoadInt4</b> when
	/// you load integer data, and <c>XMLoadFloat4</c> when you load floating point data.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="pSource">Address of the data to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>To convert the loaded <c>XMVECTOR</c> into float values, use <c>XMConvertVectorUIntToFloat</c> or <c>XMConvertVectorIntToFloat</c>.</para>
	/// <para>The following pseudocode shows you the operation of the function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; uint32_t* pElement = (uint32_t*)pSource; V.u[0] = pElement[0]; V.u[1] = pElement[1]; V.u[2] = pElement[2];
	/// V.u[3] = pElement[3]; return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadint4 XMVECTOR XM_CALLCONV XMLoadInt4( [in] const
	// uint32_t *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadInt4")]
	public static XMVECTOR XMLoadInt4(uint[] pSource) => pSource is null || pSource.Length < 4
			? throw new ArgumentNullException(nameof(pSource))
			: new(pSource[0], pSource[1], pSource[2], pSource[3]);

	/// <summary>
	/// <para>Loads 16-byte aligned data into an <c>XMVECTOR</c>, without type checking.</para>
	/// <para>
	/// <b>Note</b>  This function is provided for backward compatibility with the Xbox Math library. It is recommended that
	/// <b>XMLoadInt4A</b> be used when loading integer data and <c>XMLoadFloat4A</c> be used when loading floating point data.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="pSource">Address of the 16-byte aligned data to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>To convert the loaded <c>XMVECTOR</c> into float values, use <c>XMConvertVectorUIntToFloat</c> or <c>XMConvertVectorIntToFloat</c>.</para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; uint32_t* pElement = (uint32_t*)pSource; assert(((uint32_t_PTR)pSource &amp; 0xF) == 0); V.u[0] =
	/// pElement[0]; V.u[1] = pElement[1]; V.u[2] = pElement[2]; V.u[3] = pElement[3]; return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadint4a XMVECTOR XM_CALLCONV XMLoadInt4A( [in]
	// const uint32_t *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadInt4A")]
	public static XMVECTOR XMLoadInt4A(uint[] pSource) => XMLoadInt4(pSource);

	/// <summary>Loads signed integer data into the x and y components of an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of an <c>XMINT2</c> structure containing the data to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMLoadInt2A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; vectorOut.x = (float)pSource-&gt;x; vectorOut.y = (float)pSource-&gt;y; vectorOut.z = 0; vectorOut.w = 0;
	/// return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadsint2 XMVECTOR XM_CALLCONV XMLoadSInt2( [in]
	// const XMINT2 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadSInt2")]
	public static XMVECTOR XMLoadSInt2(in XMINT2 pSource) => new(pSource.x, pSource.y, 0, 0);

	/// <summary>Loads signed integer data into the x, y, and z components of an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of an <c>XMINT3</c> structure containing the data to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMLoadInt3A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; vectorOut.x = (float)pSource-&gt;x; vectorOut.y = (float)pSource-&gt;y; vectorOut.z = (float)pSource-&gt;z;
	/// vectorOut.w = 0; return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadsint3 XMVECTOR XM_CALLCONV XMLoadSInt3( [in]
	// const XMINT3 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadSInt3")]
	public static XMVECTOR XMLoadSInt3(in XMINT3 pSource) => new(pSource.x, pSource.y, pSource.z, 0);

	/// <summary>Loads signed integer data into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of an <c>XMINT4</c> structure containing the data to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMLoadInt4A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; vectorOut.x = (float)pSource-&gt;x; vectorOut.y = (float)pSource-&gt;y; vectorOut.z = (float)pSource-&gt;z;
	/// vectorOut.w = (float)pSource-&gt;w; return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloadsint4 XMVECTOR XM_CALLCONV XMLoadSInt4( [in]
	// const XMINT4 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadSInt4")]
	public static XMVECTOR XMLoadSInt4(in XMINT4 pSource) =>
		new(unchecked((uint)pSource.x), unchecked((uint)pSource.y), unchecked((uint)pSource.z), unchecked((uint)pSource.w));

	/// <summary>Loads unsigned integer data into the x and y components of an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of an <c>XMUINT2</c> structure containing the data to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMLoadInt2A</c> with a casting operator.</para>
	/// <para>The following pseudocode show the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; vectorOut.x = (float)pSource-&gt;x; vectorOut.y = (float)pSource-&gt;y; vectorOut.z = 0; vectorOut.w = 0;
	/// return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloaduint2 XMVECTOR XM_CALLCONV XMLoadUInt2( [in]
	// const XMUINT2 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadUInt2")]
	public static XMVECTOR XMLoadUInt2(in XMUINT2 pSource) => new(pSource.x, pSource.y, 0, 0);

	/// <summary>Loads unsigned integer data into the x, y, and z components of an <c>XMVECTOR</c>, without type checking.</summary>
	/// <param name="pSource">Address of an <c>XMUINT3</c> structure containing the data to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMLoadInt3A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; vectorOut.x = (float)pSource-&gt;x; vectorOut.y = (float)pSource-&gt;y; vectorOut.z = (float)pSource-&gt;z;
	/// vectorOut.w = 0; return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloaduint3 XMVECTOR XM_CALLCONV XMLoadUInt3( [in]
	// const XMUINT3 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadUInt3")]
	public static XMVECTOR XMLoadUInt3(in XMUINT3 pSource) => new(pSource.x, pSource.y, pSource.z, 0);

	/// <summary>Loads unsigned integer data into an <c>XMVECTOR</c>.</summary>
	/// <param name="pSource">Address of an <c>XMUINT4</c> structure containing the data to load.</param>
	/// <returns>Returns an <c>XMVECTOR</c> loaded with the data from the <i>pSource</i> parameter.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMLoadInt4A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR vectorOut; vectorOut.x = (float)pSource-&gt;x; vectorOut.y = (float)pSource-&gt;y; vectorOut.z = (float)pSource-&gt;z;
	/// vectorOut.w = (float)pSource-&gt;w; return vectorOut;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmloaduint4 XMVECTOR XM_CALLCONV XMLoadUInt4( [in]
	// const XMUINT4 *pSource ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMLoadUInt4")]
	public static XMVECTOR XMLoadUInt4(in XMUINT4 pSource) => new(pSource.x, pSource.y, pSource.z, pSource.w);

	/// <summary>Stores an <c>XMVECTOR</c> in a <b>float</b>.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>uint32_t* pElement = (uint32_t*)pDestination; assert(pDestination); assert(((uint32_t_PTR)pDestination &amp; 3) == 0); *pElement
	/// = V.u[0];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat void XM_CALLCONV XMStoreFloat( [out]
	// float *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat")]
	public static void XMStoreFloat([Out] float[] pDestination, in FXMVECTOR V)
	{
		if (pDestination is null || pDestination.Length == 0)
			throw new ArgumentNullException(nameof(pDestination));
		pDestination[0] = XMVectorGetX(V);
	}

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT2</c>.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// This function takes a vector and writes the two most significant components out to two single-precision floating-point values at the
	/// given address. The most significant component is written to the first four bytes of the address, and the next most significant
	/// component is written to the next four bytes of the address.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>pDestination-&gt;x = V.x; // 4 bytes to address pDestination pDestination-&gt;y = V.y; // 4 bytes to address
	/// (uint8_t*)pDestination + 4</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat2 void XM_CALLCONV XMStoreFloat2( [out]
	// XMFLOAT2 *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat2")]
	public static void XMStoreFloat2(out XMFLOAT2 pDestination, in FXMVECTOR V) => pDestination = new(XMVectorGetX(V), XMVectorGetY(V));

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT2</c>.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// This function takes a vector and writes the two most significant components out to two single-precision floating-point values at the
	/// given address. The most significant component is written to the first four bytes of the address, and the next most significant
	/// component is written to the next four bytes of the address.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>pDestination-&gt;x = V.x; // 4 bytes to address pDestination pDestination-&gt;y = V.y; // 4 bytes to address
	/// (uint8_t*)pDestination + 4</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat2 void XM_CALLCONV XMStoreFloat2( [out]
	// XMFLOAT2 *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat2")]
	public static unsafe void XMStoreFloat2([Out] XMFLOAT2* pDestination, in FXMVECTOR V)
	{
		if (pDestination == null)
			throw new ArgumentNullException(nameof(pDestination));
		*pDestination = new(XMVectorGetX(V), XMVectorGetY(V));
	}

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT2A</c>.</summary>
	/// <param name="pDestination">Address at which to store the data. The given address must be aligned on a 16-byte boundary.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para><c>return (XMFLOAT2A*)XMStoreVector2A(pDestination, V);</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat2a void XM_CALLCONV XMStoreFloat2A( [out]
	// XMFLOAT2A *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat2A")]
	public static void XMStoreFloat2A(out XMFLOAT2A pDestination, in FXMVECTOR V) => pDestination = new(XMVectorGetX(V), XMVectorGetY(V));

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT3</c>.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// This function takes a vector and writes the three most significant components out to three single-precision floating-point values at
	/// the given address. The most significant component is written to the first four bytes of the address, the next most significant
	/// component is written to the next four bytes, and the third most significant component is written to the final four bytes.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>pDestination-&gt;x = V.x; // 4 bytes to address pDestination pDestination-&gt;y = V.y; // 4 bytes to address
	/// (uint8_t*)pDestination + 4 pDestination-&gt;z = V.z; // 4 bytes to address (uint8_t*)pDestination + 8</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat3 void XM_CALLCONV XMStoreFloat3( [out]
	// XMFLOAT3 *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat3")]
	public static void XMStoreFloat3(out XMFLOAT3 pDestination, in FXMVECTOR V) => pDestination = new(V.x, V.y, V.z);

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT3</c>.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// This function takes a vector and writes the three most significant components out to three single-precision floating-point values at
	/// the given address. The most significant component is written to the first four bytes of the address, the next most significant
	/// component is written to the next four bytes, and the third most significant component is written to the final four bytes.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>pDestination-&gt;x = V.x; // 4 bytes to address pDestination pDestination-&gt;y = V.y; // 4 bytes to address
	/// (uint8_t*)pDestination + 4 pDestination-&gt;z = V.z; // 4 bytes to address (uint8_t*)pDestination + 8</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat3 void XM_CALLCONV XMStoreFloat3( [out]
	// XMFLOAT3 *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat3")]
	public static unsafe void XMStoreFloat3([Out] XMFLOAT3* pDestination, in FXMVECTOR V)
	{
		if (pDestination == null)
			throw new ArgumentNullException(nameof(pDestination));
		*pDestination = new(V.x, V.y, V.z);
	}

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT3A</c>.</summary>
	/// <param name="pDestination">Address at which to store the data. This address must be 16-byte aligned.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para><c>return (XMFLOAT3A*)XMStoreVector3A(pDestination, V);</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat3a void XM_CALLCONV XMStoreFloat3A( [out]
	// XMFLOAT3A *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat3A")]
	public static void XMStoreFloat3A(out XMFLOAT3A pDestination, in FXMVECTOR V) => pDestination = new(V.x, V.y, V.z);

	/// <summary>Stores an <c>XMMATRIX</c> in an <c>XMFLOAT3X3</c>.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="M">Matrix containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMFLOAT3X3</c> is a row-major matrix form. To write out column-major data requires the XMMATRIX be transposed via
	/// <c>XMMatrixTranpose</c> before calling the store function.
	/// </para>
	/// <para>
	/// This function takes a matrix and writes the components out to nine single-precision floating-point values at the given address. The
	/// most significant component of the first row vector is written to the first four bytes of the address, followed by the second most
	/// significant component of the first row, followed by the third most significant component of the first row. The most significant
	/// three components of the second row are then written out in a like manner to memory beginning at byte 12, followed by the third row
	/// to memory beginning at byte 24.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>pDestination-&gt;_11 = M[0].x; // 4 bytes to address (uint8_t*)pDestination pDestination-&gt;_12 = M[0].y; // 4 bytes to address
	/// (uint8_t*)pDestination + 4 pDestination-&gt;_13 = M[0].z; // 4 bytes to address (uint8_t*)pDestination + 8 pDestination-&gt;_21 =
	/// M[1].x; // 4 bytes to address (uint8_t*)pDestination + 12 pDestination-&gt;_22 = M[1].y; // 4 bytes to address
	/// (uint8_t*)pDestination + 16 pDestination-&gt;_23 = M[1].z; // 4 bytes to address (uint8_t*)pDestination + 20 pDestination-&gt;_31 =
	/// M[2].x; // 4 bytes to address (uint8_t*)pDestination + 24 pDestination-&gt;_32 = M[2].y; // 4 bytes to address
	/// (uint8_t*)pDestination + 28 pDestination-&gt;_33 = M[2].z; // 4 bytes to address (uint8_t*)pDestination + 32</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat3x3 void XM_CALLCONV XMStoreFloat3x3(
	// [out] XMFLOAT3X3 *pDestination, [in] FXMMATRIX M ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat3x3")]
	public static void XMStoreFloat3x3(out XMFLOAT3X3 pDestination, in FXMMATRIX M) =>
		pDestination = new(M[0,0], M[0,1], M[0,2], M[1,0], M[1,1], M[1,2], M[2, 0], M[2, 1], M[2, 2]);

	/// <summary>Stores an <c><b>XMMATRIX</b></c> in an <c><b>XMFLOAT3X4</b></c>.</summary>
	/// <param name="pDestination">
	/// <para>Type: <b>XMFLOAT3X4 *</b></para>
	/// <para>Pointer to the <c><b>XMFLOAT3X4</b></c> structure in which to store the data.</para>
	/// </param>
	/// <param name="M">
	/// <para>Type: <b><c>XMMATRIX</c></b></para>
	/// <para>Matrix containing the data to store.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para><c><b>XMFLOAT3X4</b></c> is a row-major form of the matrix.</para>
	/// <para>
	/// To write out column-major data requires that the <c><b>XMMATRIX</b></c> be transposed via <c>XMMatrixTranspose</c> before calling
	/// the store function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat3x4 void XM_CALLCONV XMStoreFloat3x4(
	// [out] XMFLOAT3X4 *pDestination, [in] FXMMATRIX M ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat3x4")]
	public static void XMStoreFloat3x4(out XMFLOAT3X4 pDestination, in FXMMATRIX M) =>
		pDestination = new(M[0, 0], M[1, 0], M[2, 0], M[3, 0], M[0, 1], M[1, 1], M[2, 1], M[3, 1], M[0, 2], M[1, 2], M[2, 2], M[3, 2]);

	/// <summary>Stores an <c><b>XMMATRIX</b></c> in an <c><b>XMFLOAT3X4A</b></c>.</summary>
	/// <param name="pDestination">
	/// <para>Type: <b>XMFLOAT3X4A *</b></para>
	/// <para>Pointer to the <c><b>XMFLOAT3X4A</b></c> structure in which to store the data.</para>
	/// </param>
	/// <param name="M">
	/// <para>Type: <b><c>XMMATRIX</c></b></para>
	/// <para>Matrix containing the data to store.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para><c><b>XMFLOAT3X4A</b></c> is a row-major form of the matrix.</para>
	/// <para>
	/// To write out column-major data requires that the <c><b>XMMATRIX</b></c> be transposed via <c>XMMatrixTranspose</c> before calling
	/// the store function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat3x4a void XM_CALLCONV XMStoreFloat3x4A(
	// [out] XMFLOAT3X4A *pDestination, [in] FXMMATRIX M ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat3x4A")]
	public static void XMStoreFloat3x4A(out XMFLOAT3X4A pDestination, in FXMMATRIX M) => XMStoreFloat3x4(out pDestination, M);

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT4</c>.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// This function takes a vector and writes the components out to four single-precision floating-point values at the given address. The
	/// most significant component is written to the first four bytes of the address, the next most significant component is written to the
	/// next four bytes, and so on.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>pDestination-&gt;x = V.x; // 4 bytes to address pDestination pDestination-&gt;y = V.y; // 4 bytes to address
	/// (uint8_t*)pDestination + 4 pDestination-&gt;z = V.z; // 4 bytes to address (uint8_t*)pDestination + 8 pDestination-&gt;w = V.w; // 4
	/// bytes to address (uint8_t*)pDestination + 12</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat4 void XM_CALLCONV XMStoreFloat4( [out]
	// XMFLOAT4 *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat4")]
	public static void XMStoreFloat4(out XMFLOAT4 pDestination, in FXMVECTOR V) => pDestination = new(V.x, V.y, V.z, V.w);

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT4</c>.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// This function takes a vector and writes the components out to four single-precision floating-point values at the given address. The
	/// most significant component is written to the first four bytes of the address, the next most significant component is written to the
	/// next four bytes, and so on.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>pDestination-&gt;x = V.x; // 4 bytes to address pDestination pDestination-&gt;y = V.y; // 4 bytes to address
	/// (uint8_t*)pDestination + 4 pDestination-&gt;z = V.z; // 4 bytes to address (uint8_t*)pDestination + 8 pDestination-&gt;w = V.w; // 4
	/// bytes to address (uint8_t*)pDestination + 12</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat4 void XM_CALLCONV XMStoreFloat4( [out]
	// XMFLOAT4 *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat4")]
	public static unsafe void XMStoreFloat4([Out] XMFLOAT4* pDestination, in FXMVECTOR V)
	{
		if (pDestination == null)
			throw new ArgumentNullException(nameof(pDestination));
		*pDestination = new(V.x, V.y, V.z, V.w);
	}

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT4A</c>.</summary>
	/// <param name="pDestination">Address at which to store the data. This address must be 16-byte aligned.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para><c>return (XMFLOAT4A*)XMStoreVector4A(pDestination, V);</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat4a void XM_CALLCONV XMStoreFloat4A( [out]
	// XMFLOAT4A *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat4A")]
	public static void XMStoreFloat4A(out XMFLOAT4A pDestination, in FXMVECTOR V) => pDestination = new(V.x, V.y, V.z, V.w);

	/// <summary>Stores an <c>XMMATRIX</c> in an <c>XMFLOAT4X3</c>.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="M">Matrix containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMFLOAT4X3</c> is a row-major matrix form. This function cannot be used to write out column-major data since it assumes the last
	/// column is 0 0 0 1.
	/// </para>
	/// <para>
	/// This function takes a matrix and writes the components out to twelve single-precision floating-point values at the given address.
	/// The most significant component of the first row vector is written to the first four bytes of the address, followed by the second
	/// most significant component of the first row, followed by the third most significant component of the first row. The most significant
	/// three components of the second row are then written out in a like manner to memory beginning at byte 12, followed by the third row
	/// to memory beginning at byte 24, and finally the fourth row to memory beginning at byte 36.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>pDestination-&gt;_11 = M[0].x; // 4 bytes to address (uint8_t*)pDestination pDestination-&gt;_12 = M[0].y; // 4 bytes to address
	/// (uint8_t*)pDestination + 4 pDestination-&gt;_13 = M[0].z; // 4 bytes to address (uint8_t*)pDestination + 8 pDestination-&gt;_21 =
	/// M[1].x; // 4 bytes to address (uint8_t*)pDestination + 12 pDestination-&gt;_22 = M[1].y; // 4 bytes to address
	/// (uint8_t*)pDestination + 16 pDestination-&gt;_23 = M[1].z; // 4 bytes to address (uint8_t*)pDestination + 20 pDestination-&gt;_31 =
	/// M[2].x; // 4 bytes to address (uint8_t*)pDestination + 24 pDestination-&gt;_32 = M[2].y; // 4 bytes to address
	/// (uint8_t*)pDestination + 28 pDestination-&gt;_33 = M[2].z; // 4 bytes to address (uint8_t*)pDestination + 32 pDestination-&gt;_41 =
	/// M[3].x; // 4 bytes to address (uint8_t*)pDestination + 36 pDestination-&gt;_42 = M[3].y; // 4 bytes to address
	/// (uint8_t*)pDestination + 40 pDestination-&gt;_43 = M[3].z; // 4 bytes to address (uint8_t*)pDestination + 44</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat4x3 void XM_CALLCONV XMStoreFloat4x3(
	// [out] XMFLOAT4X3 *pDestination, [in] FXMMATRIX M ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat4x3")]
	public static void XMStoreFloat4x3(out XMFLOAT4X3 pDestination, in FXMMATRIX M) =>
		pDestination = new(M[0, 0], M[0, 1], M[0, 2], M[1, 0], M[1, 1], M[1, 2], M[2, 0], M[2, 1], M[2, 2], M[3, 0], M[3, 1], M[3, 2]);

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT4X3A</c>.</summary>
	/// <param name="pDestination">Address at which to store the data. This address must be 16-byte aligned.</param>
	/// <param name="M">Matrix containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMFLOAT4X3A</c> is a row-major matrix form. This function cannot be used to write out column-major data since it assumes the last
	/// column is
	/// </para>
	/// <para>
	/// <c>assert(pDestination); assert(((uint32_t_PTR)pDestination &amp; 0xF) == 0); pDestination-&gt;m[0][0] = M.r[0].v[0];
	/// pDestination-&gt;m[0][1] = M.r[0].v[1]; pDestination-&gt;m[0][2] = M.r[0].v[2]; pDestination-&gt;m[1][0] = M.r[1].v[0];
	/// pDestination-&gt;m[1][1] = M.r[1].v[1]; pDestination-&gt;m[1][2] = M.r[1].v[2]; pDestination-&gt;m[2][0] = M.r[2].v[0];
	/// pDestination-&gt;m[2][1] = M.r[2].v[1]; pDestination-&gt;m[2][2] = M.r[2].v[2]; pDestination-&gt;m[3][0] = M.r[3].v[0];
	/// pDestination-&gt;m[3][1] = M.r[3].v[1]; pDestination-&gt;m[3][2] = M.r[3].v[2];</c>
	/// </para>
	/// <para>.</para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para><c>0 0 0 1</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat4x3a void XM_CALLCONV XMStoreFloat4x3A(
	// [out] XMFLOAT4X3A *pDestination, [in] FXMMATRIX M ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat4x3A")]
	public static void XMStoreFloat4x3A(out XMFLOAT4X3A pDestination, in FXMMATRIX M) => XMStoreFloat4x3(out pDestination, M);

	/// <summary>Stores an <c>XMMATRIX</c> in an <c>XMFLOAT4X4</c>.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="M">Matrix containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMFLOAT4X4</c> is a row-major matrix form. To write out column-major data requires the XMMATRIX be transposed via
	/// <c>XMMatrixTranpose</c> before calling the store function.
	/// </para>
	/// <para>
	/// This function takes a matrix and writes the components out to sixteen single-precision floating-point values at the given address.
	/// The most significant component of the first row vector is written to the first four bytes of the address, followed by the second
	/// most significant component of the first row, and so on. The second row is then written out in a like manner to memory beginning at
	/// byte 16, followed by the third row to memory beginning at byte 32, and finally the fourth row to memory beginning at byte 48.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>pDestination-&gt;_11 = M[0].x; // 4 bytes to address (uint8_t*)pDestination pDestination-&gt;_12 = M[0].y; // 4 bytes to address
	/// (uint8_t*)pDestination + 4 pDestination-&gt;_13 = M[0].z; // 4 bytes to address (uint8_t*)pDestination + 8 pDestination-&gt;_14 =
	/// M[0].w; // 4 bytes to address (uint8_t*)pDestination + 12 pDestination-&gt;_21 = M[1].x; // 4 bytes to address
	/// (uint8_t*)pDestination + 16 pDestination-&gt;_22 = M[1].y; // 4 bytes to address (uint8_t*)pDestination + 20 pDestination-&gt;_23 =
	/// M[1].z; // 4 bytes to address (uint8_t*)pDestination + 24 pDestination-&gt;_24 = M[1].w; // 4 bytes to address
	/// (uint8_t*)pDestination + 28 pDestination-&gt;_31 = M[2].x; // 4 bytes to address (uint8_t*)pDestination + 32 pDestination-&gt;_32 =
	/// M[2].y; // 4 bytes to address (uint8_t*)pDestination + 36 pDestination-&gt;_33 = M[2].z; // 4 bytes to address
	/// (uint8_t*)pDestination + 40 pDestination-&gt;_34 = M[2].w; // 4 bytes to address (uint8_t*)pDestination + 44 pDestination-&gt;_41 =
	/// M[3].x; // 4 bytes to address (uint8_t*)pDestination + 48 pDestination-&gt;_42 = M[3].y; // 4 bytes to address
	/// (uint8_t*)pDestination + 52 pDestination-&gt;_43 = M[3].z; // 4 bytes to address (uint8_t*)pDestination + 56 pDestination-&gt;_44 =
	/// M[3].w; // 4 bytes to address (uint8_t*)pDestination + 60</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat4x4 void XM_CALLCONV XMStoreFloat4x4(
	// [out] XMFLOAT4X4 *pDestination, [in] FXMMATRIX M ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat4x4")]
	public static void XMStoreFloat4x4(out XMFLOAT4X4 pDestination, in FXMMATRIX M) => pDestination = M;

	/// <summary>Stores an <c>XMVECTOR</c> in an <c>XMFLOAT4X4A</c>.</summary>
	/// <param name="pDestination">Address at which to store the data. This address must be 16-byte aligned.</param>
	/// <param name="M">Matrix containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>
	/// <c>XMFLOAT4X4A</c> is a row-major matrix form. To write out column-major data requires the XMMATRIX be transposed via
	/// <c>XMMatrixTranpose</c> before calling the store function.
	/// </para>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>assert(pDestination); assert(((uint32_t_PTR)pDestination &amp; 0xF) == 0); pDestination-&gt;m[0][0] = M.r[0].v[0];
	/// pDestination-&gt;m[0][1] = M.r[0].v[1]; pDestination-&gt;m[0][2] = M.r[0].v[2]; pDestination-&gt;m[0][3] = M.r[0].v[3];
	/// pDestination-&gt;m[1][0] = M.r[1].v[0]; pDestination-&gt;m[1][1] = M.r[1].v[1]; pDestination-&gt;m[1][2] = M.r[1].v[2];
	/// pDestination-&gt;m[1][3] = M.r[1].v[3]; pDestination-&gt;m[2][0] = M.r[2].v[0]; pDestination-&gt;m[2][1] = M.r[2].v[1];
	/// pDestination-&gt;m[2][2] = M.r[2].v[2]; pDestination-&gt;m[2][3] = M.r[2].v[3]; pDestination-&gt;m[3][0] = M.r[3].v[0];
	/// pDestination-&gt;m[3][1] = M.r[3].v[1]; pDestination-&gt;m[3][2] = M.r[3].v[2]; pDestination-&gt;m[3][3] = M.r[3].v[3];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstorefloat4x4a void XM_CALLCONV XMStoreFloat4x4A(
	// [out] XMFLOAT4X4A *pDestination, [in] FXMMATRIX M ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreFloat4x4A")]
	public static void XMStoreFloat4x4A(out XMFLOAT4X4A pDestination, in FXMMATRIX M) => XMStoreFloat4x4(out pDestination, M);

	/// <summary>Stores an <c>XMVECTOR</c> in a <b>uint32_t</b>.</summary>
	/// <param name="pDestination">
	/// Address at which to store the data. The data pointed to by this parameter must be 4-byte aligned and reside in cached memory.
	/// </param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>uint32_t* pElement = (uint32_t*)pDestination; assert(pDestination); assert(((uint32_t_PTR)pDestination &amp; 3) == 0); *pElement
	/// = V.u[0];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoreint void XM_CALLCONV XMStoreInt( [out] uint32_t
	// *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreInt")]
	public static void XMStoreInt([Out] uint[] pDestination, in FXMVECTOR V)
	{
		if (pDestination is null || pDestination.Length == 0)
			throw new ArgumentNullException(nameof(pDestination));
		pDestination[0] = XMVectorGetIntX(V);
	}

	/// <summary>Stores an <c>XMVECTOR</c> in a 2-element <b>uint32_t</b> array.</summary>
	/// <param name="pDestination">Address at which to store the data. This pointer must be 4-byte aligned.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode shows you the operation of the function.</para>
	/// <para>
	/// <c>uint32_t* pElement = (uint32_t*)pDestination; assert(pDestination); assert(((uint32_t_PTR)pDestination &amp; 3) == 0);
	/// pElement[0] = V.u[0]; pElement[1] = V.u[1];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoreint2 void XM_CALLCONV XMStoreInt2( [out]
	// uint32_t *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreInt2")]
	public static void XMStoreInt2([Out] uint[] pDestination, in FXMVECTOR V)
	{
		if (pDestination is null || pDestination.Length < 2)
			throw new ArgumentNullException(nameof(pDestination));
		pDestination[0] = XMVectorGetIntX(V);
		pDestination[1] = XMVectorGetIntY(V);
	}

	/// <summary>Stores an <c>XMVECTOR</c> in a 16-byte aligned 2 element <b>uint32_t</b> array.</summary>
	/// <param name="pDestination">Address at which to store the data. This address must be 16-byte aligned.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>uint32_t* pElement = (uint32_t*)pDestination; assert(pDestination); assert(((uint32_t_PTR)pDestination &amp; 0xF) == 0);
	/// pElement[0] = V.u[0]; pElement[1] = V.u[1];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoreint2a void XM_CALLCONV XMStoreInt2A( [out]
	// uint32_t *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreInt2A")]
	public static void XMStoreInt2A([Out] uint[] pDestination, in FXMVECTOR V)
	{
		if (pDestination is null || pDestination.Length < 2)
			throw new ArgumentNullException(nameof(pDestination));
		pDestination[0] = XMVectorGetIntX(V);
		pDestination[1] = XMVectorGetIntY(V);
	}

	/// <summary>Stores an <c>XMVECTOR</c> in a 3-element <b>uint32_t</b> array.</summary>
	/// <param name="pDestination">Address at which to store the data. This pointer must be 4-byte aligned.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode shows you the operation of the function.</para>
	/// <para>
	/// <c>uint32_t* pElement = (uint32_t*)pDestination; assert(pDestination); assert(((uint32_t_PTR)pDestination &amp; 3) == 0);
	/// pElement[0] = V.u[0]; pElement[1] = V.u[1]; pElement[2] = V.u[2];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoreint3 void XM_CALLCONV XMStoreInt3( [out]
	// uint32_t *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreInt3")]
	public static void XMStoreInt3([Out] uint[] pDestination, in FXMVECTOR V)
	{
		if (pDestination is null || pDestination.Length < 3)
			throw new ArgumentNullException(nameof(pDestination));
		pDestination[0] = XMVectorGetIntX(V);
		pDestination[1] = XMVectorGetIntY(V);
		pDestination[2] = XMVectorGetIntZ(V);
	}

	/// <summary>Stores an <c>XMVECTOR</c> in a 16-byte aligned 3 element <b>uint32_t</b> array.</summary>
	/// <param name="pDestination">Address at which to store the data. This address must be 16-byte aligned.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>uint32_t* pElement = (uint32_t*)pDestination; assert(pDestination); assert(((uint32_t_PTR)pDestination &amp; 0xF) == 0);
	/// pElement[0] = V.u[0]; pElement[1] = V.u[1]; pElement[2] = V.u[2];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoreint3a void XM_CALLCONV XMStoreInt3A( [out]
	// uint32_t *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreInt3A")]
	public static void XMStoreInt3A([Out] uint[] pDestination, in FXMVECTOR V) => XMStoreInt3(pDestination, V);

	/// <summary>Stores an <c>XMVECTOR</c> in a 4-element <b>uint32_t</b> array.</summary>
	/// <param name="pDestination">Address at which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode shows you the operation of the function.</para>
	/// <para>
	/// <c>uint32_t* pElement = (uint32_t*)pDestination; assert(pDestination); pElement[0] = V.u[0]; pElement[1] = V.u[1]; pElement[2] =
	/// V.u[2]; pElement[3] = V.u[3];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoreint4 void XM_CALLCONV XMStoreInt4( [out]
	// uint32_t *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreInt4")]
	public static void XMStoreInt4([Out] uint[] pDestination, in FXMVECTOR V)
	{
		if (pDestination is null || pDestination.Length < 4)
			throw new ArgumentNullException(nameof(pDestination));
		pDestination[0] = XMVectorGetIntX(V);
		pDestination[1] = XMVectorGetIntY(V);
		pDestination[2] = XMVectorGetIntZ(V);
		pDestination[3] = XMVectorGetIntW(V);
	}

	/// <summary>Stores an <c>XMVECTOR</c> in a 16-byte aligned 4 element <b>uint32_t</b> array.</summary>
	/// <param name="pDestination">Address at which to store the data. This address must be 16-byte aligned.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>The following pseudocode demonstrates the operation of the function.</para>
	/// <para>
	/// <c>uint32_t* pElement = (uint32_t*)pDestination; assert(pDestination); assert(((uint32_t_PTR)pDestination &amp; 0xF) == 0);
	/// pElement[0] = V.u[0]; pElement[1] = V.u[1]; pElement[2] = V.u[2]; pElement[3] = V.u[3];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoreint4a void XM_CALLCONV XMStoreInt4A( [out]
	// uint32_t *pDestination, [in] FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreInt4A")]
	public static void XMStoreInt4A([Out] uint[] pDestination, in FXMVECTOR V) => XMStoreInt4(pDestination, V);

	/// <summary>Stores signed integer data from an <c>XMVECTOR</c> in an <b>XMINT2</b> structure.</summary>
	/// <param name="pDestination">Address of an <c>XMINT2</c> structure in which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMStoreInt2A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR N; assert(pDestination); N = XMVectorClamp(V, MinInt, MaxInt ); N = XMVectorRound(N); pDestination-&gt;x =
	/// (int32_t)N.v[0]; pDestination-&gt;y = (int32_t)N.v[1];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoresint2 void XM_CALLCONV XMStoreSInt2( [out]
	// XMINT2 *pDestination, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreSInt2")]
	public static void XMStoreSInt2(out XMINT2 pDestination, in FXMVECTOR V) => pDestination = new(unchecked((int)XMVectorGetIntX(V)), unchecked((int)XMVectorGetIntY(V)));

	/// <summary>Stores signed integer data from an <c>XMVECTOR</c> in an <b>XMINT3</b> structure.</summary>
	/// <param name="pDestination">Address of an <c>XMINT3</c> structure in which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMStoreInt3A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR N; assert(pDestination); N = XMVectorClamp(V, MinInt, MaxInt ); N = XMVectorRound(N); pDestination-&gt;x =
	/// (int32_t)N.v[0]; pDestination-&gt;y = (int32_t)N.v[1]; pDestination-&gt;z = (int32_t)N.v[2];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoresint3 void XM_CALLCONV XMStoreSInt3( [out]
	// XMINT3 *pDestination, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreSInt3")]
	public static void XMStoreSInt3(out XMINT3 pDestination, in FXMVECTOR V) => pDestination = new(unchecked((int)V.ux), unchecked((int)V.uy), unchecked((int)V.uz));

	/// <summary>Stores signed integer data from an <c>XMVECTOR</c> in an <b>XMINT4</b> structure.</summary>
	/// <param name="pDestination">Address of an <c>XMINT4</c> structure in which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMStoreInt4A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR N; assert(pDestination); N = XMVectorClamp(V, MinInt, MaxInt ); N = XMVectorRound(N); pDestination-&gt;x =
	/// (int32_t)N.v[0]; pDestination-&gt;y = (int32_t)N.v[1]; pDestination-&gt;z = (int32_t)N.v[2]; pDestination-&gt;w = (int32_t)N.v[3];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoresint4 void XM_CALLCONV XMStoreSInt4( [out]
	// XMINT4 *pDestination, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreSInt4")]
	public static void XMStoreSInt4(out XMINT4 pDestination, in FXMVECTOR V) => pDestination = new(unchecked((int)V.ux), unchecked((int)V.uy), unchecked((int)V.uz), unchecked((int)V.uw));

	/// <summary>Stores unsigned integer data from an <c>XMVECTOR</c> in an <b>XMUINT2</b> structure.</summary>
	/// <param name="pDestination">Address of an <c>XMUINT2</c> structure in which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMStoreInt2A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR N; assert(pDestination); N = XMVectorClamp(V, XMVectorZero(), MaxUInt ); N = XMVectorRound(N); pDestination-&gt;x =
	/// (uint32_t)N.v[0]; pDestination-&gt;y = (uint32_t)N.v[1];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoreuint2 void XM_CALLCONV XMStoreUInt2( [out]
	// XMUINT2 *pDestination, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreUInt2")]
	public static void XMStoreUInt2(out XMUINT2 pDestination, in FXMVECTOR V) => pDestination = new(XMVectorGetIntX(V), XMVectorGetIntY(V));

	/// <summary>Stores unsigned integer data from an <c>XMVECTOR</c> in an <b>XMUINT3</b> structure.</summary>
	/// <param name="pDestination">Address of an <c>XMUINT3</c> structure in which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMStoreInt3A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR N; assert(pDestination); N = XMVectorClamp(V, XMVectorZero(), MaxUInt ); N = XMVectorRound(N); pDestination-&gt;x =
	/// (uint32_t)N.v[0]; pDestination-&gt;y = (uint32_t)N.v[1]; pDestination-&gt;z = (uint32_t)N.v[2];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoreuint3 void XM_CALLCONV XMStoreUInt3( [out]
	// XMUINT3 *pDestination, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreUInt3")]
	public static void XMStoreUInt3(out XMUINT3 pDestination, in FXMVECTOR V) => pDestination = new(V.ux, V.uy, V.uz);

	/// <summary>Stores unsigned integer data from an <c>XMVECTOR</c> in an <b>XMUINT4</b> structure.</summary>
	/// <param name="pDestination">Address of an <c>XMUINT4</c> structure in which to store the data.</param>
	/// <param name="V">Vector containing the data to store.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>For 16-byte aligned memory, it may be faster to use <c>XMStoreInt4A</c> with a casting operator.</para>
	/// <para>The following pseudocode shows the operation of this function.</para>
	/// <para>
	/// <c>XMVECTOR N; assert(pDestination); N = XMVectorClamp(V, XMVectorZero(), MaxUInt ); N = XMVectorRound(N); pDestination-&gt;x =
	/// (uint32_t)N.v[0]; pDestination-&gt;y = (uint32_t)N.v[1]; pDestination-&gt;z = (uint32_t)N.v[2]; pDestination-&gt;w = (uint32_t)N.v[3];</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmstoreuint4 void XM_CALLCONV XMStoreUInt4( [out]
	// XMUINT4 *pDestination, FXMVECTOR V ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMStoreUInt4")]
	public static void XMStoreUInt4(out XMUINT4 pDestination, in FXMVECTOR V) => pDestination = new(V.ux, V.uy, V.uz, V.uw);

	private static uint F2U(float f) => BitConverter.ToUInt32(BitConverter.GetBytes(f), 0);

	private static bool XMISINF(float x) => (F2U(x) & 0x7FFFFFFF) == 0x7F800000;

	private static bool XMISNAN(float x) => (F2U(x) & 0x7F800000) == 0x7F800000 && (F2U(x) & 0x7FFFFF) != 0;
}