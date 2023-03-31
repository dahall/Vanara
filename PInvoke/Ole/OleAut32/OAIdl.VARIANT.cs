using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class OleAut32
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

	/// <summary>Flags used by <see cref="VariantChangeType"/>.</summary>
	[PInvokeData("oleauto.h", MSDNShortId = "48a51e32-95d7-4eeb-8106-f5043ffa2fd1")]
	[Flags]
	public enum VarChangeFlag : ushort
	{
		/// <summary>
		/// Prevents the function from attempting to coerce an object to a fundamental type by getting the Value property. Applications
		/// should set this flag only if necessary, because it makes their behavior inconsistent with other applications.
		/// </summary>
		VARIANT_NOVALUEPROP = 0x01,

		/// <summary>Converts a VT_BOOL value to a string containing either "True" or "False".</summary>
		VARIANT_ALPHABOOL = 0x02,

		/// <summary>For conversions to or from VT_BSTR, passes LOCALE_NOUSEROVERRIDE to the core coercion routines.</summary>
		VARIANT_NOUSEROVERRIDE = 0x04,

		VARIANT_CALENDAR_HIJRI = 0x08,

		/// <summary>
		/// For conversions from VT_BOOL to VT_BSTR and back, uses the language specified by the locale in use on the local computer.
		/// </summary>
		VARIANT_LOCALBOOL = 0x10,

		VARIANT_CALENDAR_THAI = 0x20,
		VARIANT_CALENDAR_GREGORIAN = 0x40,
		VARIANT_USE_NLS = 0x80,
	}

	[Flags]
	public enum VarFlags : uint
	{
		VAR_TIMEVALUEONLY = 0x00000001,
		VAR_DATEVALUEONLY = 0x00000002,
		VAR_VALIDDATE = 0x00000004,
		VAR_CALENDAR_HIJRI = 0x00000008,
		VAR_LOCALBOOL = 0x00000010,
		VAR_FORMAT_NOSUBSTITUTE = 0x00000020,
		VAR_FOURDIGITYEARS = 0x00000040,
		LOCALE_NOUSEROVERRIDE = 0x80000000,
	}

	/// <summary>Bits for numeric VARTYPE values.</summary>
	public enum VtBits
	{
		VTBIT_I1 = 1 << VARTYPE.VT_I1,
		VTBIT_UI1 = 1 << VARTYPE.VT_UI1,
		VTBIT_I2 = 1 << VARTYPE.VT_I2,
		VTBIT_UI2 = 1 << VARTYPE.VT_UI2,
		VTBIT_I4 = 1 << VARTYPE.VT_I4,
		VTBIT_UI4 = 1 << VARTYPE.VT_UI4,
		VTBIT_I8 = 1 << VARTYPE.VT_I8,
		VTBIT_UI8 = 1 << VARTYPE.VT_UI8,
		VTBIT_R4 = 1 << VARTYPE.VT_R4,
		VTBIT_R8 = 1 << VARTYPE.VT_R8,
		VTBIT_CY = 1 << VARTYPE.VT_CY,
		VTBIT_DECIMAL = 1 << VARTYPE.VT_DECIMAL,
	}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

	/// <summary>Returns the absolute value of a variant.</summary>
	/// <param name="pvarIn">The variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varabs HRESULT VarAbs( LPVARIANT pvarIn, LPVARIANT
	// pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "720f5b1b-1b89-4167-8d89-9da267ecb85e")]
	public static extern HRESULT VarAbs(in VARIANT pvarIn, out VARIANT pvarResult);

	/// <summary>Returns the sum of two variants.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Condition</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>Both expressions are strings</term>
	/// <term>Concatenated</term>
	/// </item>
	/// <item>
	/// <term>One expression is a string and the other a character</term>
	/// <term>Addition</term>
	/// </item>
	/// <item>
	/// <term>One expression is numeric and the other a string</term>
	/// <term>Addition</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are numeric</term>
	/// <term>Addition</term>
	/// </item>
	/// <item>
	/// <term>Either expression is null</term>
	/// <term>Null</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are empty</term>
	/// <term>Integer</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varadd HRESULT VarAdd( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "bdec33b1-cbdd-4ec3-83b2-4e5655ecf5bb")]
	public static extern HRESULT VarAdd(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Performs a bitwise And operation between two variants of any integral type.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>pvarLeft</term>
	/// <term>pvarRight</term>
	/// <term>pvarResult</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>TRUE</term>
	/// <term>FALSE</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>TRUE</term>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>TRUE</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>FALSE</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>NULL</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>TRUE</term>
	/// <term>NULL</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>FALSE</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varand HRESULT VarAnd( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "bcdda3e6-d599-4266-ba66-6634ab26f9d0")]
	public static extern HRESULT VarAnd(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Converts a currency value to a Boolean value.</summary>
	/// <param name="cyIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromcy HRESULT VarBoolFromCy( CY cyIn, VARIANT_BOOL
	// *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "4d13c480-26f6-49d3-aaaa-1804d56f8fe3")]
	public static extern HRESULT VarBoolFromCy(CY cyIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts a date value to a Boolean value.</summary>
	/// <param name="dateIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromdate HRESULT VarBoolFromDate( DATE dateIn,
	// VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "3ba9e701-56c6-471c-9c82-a31c893a3a1c")]
	public static extern HRESULT VarBoolFromDate(DATE dateIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts a decimal value to a Boolean value.</summary>
	/// <param name="pdecIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromdec HRESULT VarBoolFromDec( const DECIMAL
	// *pdecIn, VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "f7397feb-8ef4-4734-875a-0ef2bb818caa")]
	public static extern HRESULT VarBoolFromDec(in DECIMAL pdecIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts the default property of an IDispatch instance to a Boolean value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromdisp HRESULT VarBoolFromDisp( IDispatch
	// *pdispIn, LCID lcid, VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "72a20066-26ce-4f20-97d6-315e1f183d4b")]
	public static extern HRESULT VarBoolFromDisp(IDispatch pdispIn, LCID lcid, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts a char value to a Boolean value.</summary>
	/// <param name="cIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromi1 HRESULT VarBoolFromI1( CHAR cIn, VARIANT_BOOL
	// *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromI1")]
	public static extern HRESULT VarBoolFromI1(sbyte cIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts a short value to a Boolean value.</summary>
	/// <param name="sIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromi2 HRESULT VarBoolFromI2( SHORT sIn,
	// VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromI2")]
	public static extern HRESULT VarBoolFromI2(short sIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts a long value to a Boolean value.</summary>
	/// <param name="lIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromi4 HRESULT VarBoolFromI4( LONG lIn, VARIANT_BOOL
	// *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromI4")]
	public static extern HRESULT VarBoolFromI4(int lIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts an 8-byte integer value to a Boolean value.</summary>
	/// <param name="i64In">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromi8 HRESULT VarBoolFromI8( LONG64 i64In,
	// VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromI8")]
	public static extern HRESULT VarBoolFromI8(long i64In, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts a float value to a Boolean value.</summary>
	/// <param name="fltIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromr4 HRESULT VarBoolFromR4( FLOAT fltIn,
	// VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromR4")]
	public static extern HRESULT VarBoolFromR4(float fltIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts a double value to a Boolean value.</summary>
	/// <param name="dblIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromr8 HRESULT VarBoolFromR8( DOUBLE dblIn,
	// VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromR8")]
	public static extern HRESULT VarBoolFromR8(double dblIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts an OLECHAR string to a Boolean value.</summary>
	/// <param name="strIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><see cref="Kernel32.TIME_FORMAT.LOCALE_NOUSEROVERRIDE"/></term>
	/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
	/// </item>
	/// <item>
	/// <term><see cref="VarFlags .VAR_LOCALBOOL"/></term>
	/// <term>Uses localized Boolean names.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromstr HRESULT VarBoolFromStr( LPCOLESTR strIn,
	// LCID lcid, ULONG dwFlags, VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromStr")]
	public static extern HRESULT VarBoolFromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, uint dwFlags, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts an unsigned char value to a Boolean value.</summary>
	/// <param name="bIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromui1 HRESULT VarBoolFromUI1( BYTE bIn,
	// VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromUI1")]
	public static extern HRESULT VarBoolFromUI1(byte bIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts an unsigned short value to a Boolean value.</summary>
	/// <param name="uiIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromui2 HRESULT VarBoolFromUI2( USHORT uiIn,
	// VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromUI2")]
	public static extern HRESULT VarBoolFromUI2(ushort uiIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts an unsigned long value to a Boolean value.</summary>
	/// <param name="ulIn">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromui4 HRESULT VarBoolFromUI4( ULONG ulIn,
	// VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromUI4")]
	public static extern HRESULT VarBoolFromUI4(uint ulIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Converts an 8-byte unsigned integer value to a Boolean value.</summary>
	/// <param name="i64In">The value to convert.</param>
	/// <param name="pboolOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromui8 HRESULT VarBoolFromUI8( ULONG64 i64In,
	// VARIANT_BOOL *pboolOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBoolFromUI8")]
	public static extern HRESULT VarBoolFromUI8(ulong i64In, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

	/// <summary>Concatenates two variants of type BSTR and returns the resulting BSTR.</summary>
	/// <param name="bstrLeft">The first variant.</param>
	/// <param name="bstrRight">The second variant.</param>
	/// <param name="pbstrResult">The result.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrcat HRESULT VarBstrCat( BSTR bstrLeft, BSTR
	// bstrRight, LPBSTR pbstrResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrCat")]
	public static extern HRESULT VarBstrCat([In, MarshalAs(UnmanagedType.BStr)] string bstrLeft, [In, MarshalAs(UnmanagedType.BStr)] string bstrRight, [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrResult);

	/// <summary>Compares two variants of type BSTR.</summary>
	/// <param name="bstrLeft">The first variant.</param>
	/// <param name="bstrRight">The second variant.</param>
	/// <param name="lcid">The locale identifier of the program to determine whether UNICODE or ANSI strings are being used.</param>
	/// <param name="dwFlags">
	/// <para>The following are compare results flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NORM_IGNORECASE 0x00000001</term>
	/// <term>Ignore case.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNORENONSPACE 0x00000002</term>
	/// <term>Ignore nonspace characters.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNORESYMBOLS 0x00000004</term>
	/// <term>Ignore symbols.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNOREWIDTH 0x00000008</term>
	/// <term>Ignore string width.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNOREKANATYPE 0x00000040</term>
	/// <term>Ignore Kana type.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNOREKASHIDA 0x00040000</term>
	/// <term>Ignore Arabic kashida characters.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>VARCMP_LT 0</term>
	/// <term>bstrLeft is less than bstrRight.</term>
	/// </item>
	/// <item>
	/// <term>VARCMP_EQ 1</term>
	/// <term>The parameters are equal.</term>
	/// </item>
	/// <item>
	/// <term>VARCMP_GT 2</term>
	/// <term>bstrLeft is greater than bstrRight.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>This function will not compare arrays or records.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrcmp HRESULT VarBstrCmp( BSTR bstrLeft, BSTR
	// bstrRight, LCID lcid, ULONG dwFlags );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrCmp")]
	public static extern HRESULT VarBstrCmp([In, MarshalAs(UnmanagedType.BStr)] string bstrLeft, [In, MarshalAs(UnmanagedType.BStr)] string bstrRight, LCID lcid, Kernel32.COMPARE_STRING dwFlags);

	/// <summary>Converts a Boolean value to a BSTR value.</summary>
	/// <param name="boolIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><see cref="Kernel32.TIME_FORMAT.LOCALE_NOUSEROVERRIDE"/></term>
	/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
	/// </item>
	/// <item>
	/// <term><see cref="VarFlags.VAR_LOCALBOOL"/></term>
	/// <term>Uses localized Boolean names.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfrombool HRESULT VarBstrFromBool( VARIANT_BOOL
	// boolIn, LCID lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromBool")]
	public static extern HRESULT VarBstrFromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, LCID lcid, VarFlags dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts a currency value to a BSTR value.</summary>
	/// <param name="cyIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LOCALE_NOUSEROVERRIDE</term>
	/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_USE_NLS</term>
	/// <term>Uses NLS functions for currency conversions.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromcy HRESULT VarBstrFromCy( CY cyIn, LCID lcid,
	// ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromCy")]
	public static extern HRESULT VarBstrFromCy(CY cyIn, LCID lcid, Kernel32.TIME_FORMAT dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts a date value to a BSTR value.</summary>
	/// <param name="dateIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LOCALE_NOUSEROVERRIDE</term>
	/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
	/// </item>
	/// <item>
	/// <term>VAR_CALENDAR_HIJRI</term>
	/// <term>If set then the Hijri calendar is used. Otherwise the calendar set in the control panel is used.</term>
	/// </item>
	/// <item>
	/// <term>VAR_CALENDAR_THAI</term>
	/// <term>If set then the Buddhist year is used.</term>
	/// </item>
	/// <item>
	/// <term>VAR_CALENDAR_GREGORIAN</term>
	/// <term>If set the Gregorian year is used.</term>
	/// </item>
	/// <item>
	/// <term>VAR_FOURDIGITYEARS</term>
	/// <term>Use 4-digit years instead of 2-digit years.</term>
	/// </item>
	/// <item>
	/// <term>VAR_TIMEVALUEONLY</term>
	/// <term>Omits the date portion of a VT_DATE and returns only the time. Applies to conversions to or from dates.</term>
	/// </item>
	/// <item>
	/// <term>VAR_DATEVALUEONLY</term>
	/// <term>Omits the time portion of a VT_DATE and returns only the date. Applies to conversions to or from dates.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromdate HRESULT VarBstrFromDate( DATE dateIn, LCID
	// lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromDate")]
	public static extern HRESULT VarBstrFromDate(DATE dateIn, LCID lcid, VarFlags dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts a decimal value to a BSTR value.</summary>
	/// <param name="pdecIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LOCALE_NOUSEROVERRIDE</term>
	/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
	/// </item>
	/// <item>
	/// <term>VAR_TIMEVALUEONLY</term>
	/// <term>
	/// Omits the date portion of a VT_DATE and returns only the time. Applies to conversions to or from dates. Not used for
	/// VariantChangeType and VariantChangeTypeEx.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VAR_DATEVALUEONLY</term>
	/// <term>
	/// Omits the time portion of a VT_DATE and returns only the date. Applies to conversions to or from dates. Not used for
	/// VariantChangeType and VariantChangeTypeEx.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromdec HRESULT VarBstrFromDec( const DECIMAL
	// *pdecIn, LCID lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromDec")]
	public static extern HRESULT VarBstrFromDec(in DECIMAL pdecIn, LCID lcid, VarFlags dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts the default property of an IDispatch instance to a BSTR value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">Reserved. Set to zero.</param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromdisp HRESULT VarBstrFromDisp( IDispatch
	// *pdispIn, LCID lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromDisp")]
	public static extern HRESULT VarBstrFromDisp([In] IDispatch pdispIn, LCID lcid, [Optional] uint dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts the default property of an IDispatch instance to a BSTR value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">Reserved. Set to zero.</param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromdisp HRESULT VarBstrFromDisp( IDispatch
	// *pdispIn, LCID lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromDisp")]
	public static extern HRESULT VarBstrFromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, [Optional] uint dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts a char value to a BSTR value.</summary>
	/// <param name="cIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">Reserved. Set to zero.</param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromi1 HRESULT VarBstrFromI1( CHAR cIn, LCID lcid,
	// ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromI1")]
	public static extern HRESULT VarBstrFromI1(sbyte cIn, LCID lcid, [Optional] uint dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts a short value to a BSTR value.</summary>
	/// <param name="iVal">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">Reserved. Set to zero.</param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromi2 HRESULT VarBstrFromI2( SHORT iVal, LCID lcid,
	// ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromI2")]
	public static extern HRESULT VarBstrFromI2(short iVal, LCID lcid, [Optional] uint dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts a long value to a BSTR value.</summary>
	/// <param name="lIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">Reserved. Set to zero.</param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromi4 HRESULT VarBstrFromI4( LONG lIn, LCID lcid,
	// ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromI4")]
	public static extern HRESULT VarBstrFromI4(int lIn, LCID lcid, [Optional] uint dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts an 8-byte unsigned integer value to a BSTR value.</summary>
	/// <param name="i64In">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">Reserved. Set to zero.</param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromi8 HRESULT VarBstrFromI8( LONG64 i64In, LCID
	// lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromI8")]
	public static extern HRESULT VarBstrFromI8(long i64In, LCID lcid, [Optional] uint dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts a float value to a BSTR value.</summary>
	/// <param name="fltIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LOCALE_NOUSEROVERRIDE</term>
	/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromr4 HRESULT VarBstrFromR4( FLOAT fltIn, LCID
	// lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromR4")]
	public static extern HRESULT VarBstrFromR4(float fltIn, LCID lcid, Kernel32.TIME_FORMAT dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts a double value to a BSTR value.</summary>
	/// <param name="dblIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LOCALE_NOUSEROVERRIDE</term>
	/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromr8 HRESULT VarBstrFromR8( DOUBLE dblIn, LCID
	// lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromR8")]
	public static extern HRESULT VarBstrFromR8(double dblIn, LCID lcid, Kernel32.TIME_FORMAT dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts an unsigned char value to a BSTR value.</summary>
	/// <param name="bVal">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LOCALE_NOUSEROVERRIDE</term>
	/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromui1 HRESULT VarBstrFromUI1( BYTE bVal, LCID
	// lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromUI1")]
	public static extern HRESULT VarBstrFromUI1(byte bVal, LCID lcid, Kernel32.TIME_FORMAT dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts an unsigned short value to a BSTR value.</summary>
	/// <param name="uiIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// <para>One or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LOCALE_NOUSEROVERRIDE</term>
	/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromui2 HRESULT VarBstrFromUI2( USHORT uiIn, LCID
	// lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromUI2")]
	public static extern HRESULT VarBstrFromUI2(ushort uiIn, LCID lcid, Kernel32.TIME_FORMAT dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts an unsigned long value to a BSTR value.</summary>
	/// <param name="ulIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">Reserved. Set to zero.</param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromui4 HRESULT VarBstrFromUI4( ULONG ulIn, LCID
	// lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromUI4")]
	public static extern HRESULT VarBstrFromUI4(uint ulIn, LCID lcid, [Optional] uint dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts an 8-byte unsigned integer value to a BSTR value.</summary>
	/// <param name="ui64In">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">Reserved. Set to zero.</param>
	/// <param name="pbstrOut">The resulting value.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The input parameter is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by the output parameter does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varbstrfromui8 HRESULT VarBstrFromUI8( ULONG64 ui64In, LCID
	// lcid, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarBstrFromUI8")]
	public static extern HRESULT VarBstrFromUI8(ulong ui64In, LCID lcid, [Optional] uint dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Concatenates two variants and returns the result.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Condition</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>Both expressions are strings</term>
	/// <term>Concatenated</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are null</term>
	/// <term>Null</term>
	/// </item>
	/// <item>
	/// <term>One expression is null and the other is not null</term>
	/// <term>The non-null type</term>
	/// </item>
	/// <item>
	/// <term>Either expression is a Boolean</term>
	/// <term>FALSE equal to 1 or TRUE equal to -1</term>
	/// </item>
	/// <item>
	/// <term>Either expression is VT_ERROR</term>
	/// <term>Null</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are numeric</term>
	/// <term>Concatenated and returned as a string</term>
	/// </item>
	/// <item>
	/// <term>One expression is numeric and the other a string</term>
	/// <term>Concatenated</term>
	/// </item>
	/// <item>
	/// <term>Either expression is a date</term>
	/// <term>Date</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are empty</term>
	/// <term>Empty string</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcat HRESULT VarCat( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "2e94516e-de36-407a-a1fe-6a6e66641c17")]
	public static extern HRESULT VarCat(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Compares two variants.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// <para>The compare results option.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NORM_IGNORECASE 0x00000001</term>
	/// <term>Ignore case.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNORENONSPACE 0x00000002</term>
	/// <term>Ignore nonspace characters.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNORESYMBOLS 0x00000004</term>
	/// <term>Ignore symbols.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNOREWIDTH 0x00000008</term>
	/// <term>Ignore string width.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNOREKANATYPE 0x00000040</term>
	/// <term>Ignore Kana type.</term>
	/// </item>
	/// <item>
	/// <term>NORM_IGNOREKASHIDA 0x00040000</term>
	/// <term>Ignore Arabic kashida characters.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>VARCMP_LT 0</term>
	/// <term>pvarLeft is less than pvarRight.</term>
	/// </item>
	/// <item>
	/// <term>VARCMP_EQ 1</term>
	/// <term>The parameters are equal.</term>
	/// </item>
	/// <item>
	/// <term>VARCMP_GT 2</term>
	/// <term>pvarLeft is greater than pvarRight.</term>
	/// </item>
	/// <item>
	/// <term>VARCMP_NULL 3</term>
	/// <term>Either expression is NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The function only compares the value of the variant types. It compares strings, integers, and floating points, but not arrays or records.
	/// </para>
	/// <para>
	/// NORM_IGNOREWIDTH causes <c>VarCmp</c> to ignore the difference between half-width and full-width characters, as the following
	/// example demonstrates:
	/// </para>
	/// <para>"Ｃａｔ"== "cat"</para>
	/// <para>The full-width form is a formatting distinction used in Chinese and Japanese scripts.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcmp HRESULT VarCmp( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LCID lcid, ULONG dwFlags );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "00b96fa7-446c-450b-bd06-a966e1acb5ce")]
	public static extern HRESULT VarCmp(in VARIANT pvarLeft, in VARIANT pvarRight, LCID lcid, uint dwFlags);

	/// <summary>Returns the result from dividing two variants.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Condition</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>Both expressions are strings, dates, characters, or boolean values</term>
	/// <term>Double</term>
	/// </item>
	/// <item>
	/// <term>One expression is a string and the other a character</term>
	/// <term>Division and a double is returned</term>
	/// </item>
	/// <item>
	/// <term>One expression is numeric and the other a string</term>
	/// <term>Division and a double is returned</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are numeric</term>
	/// <term>Division and a double is returned</term>
	/// </item>
	/// <item>
	/// <term>Either expression is null</term>
	/// <term>Null</term>
	/// </item>
	/// <item>
	/// <term>pvarRight is empty and pvarLeft is not empty</term>
	/// <term>DISP_E_DIVBYZERO</term>
	/// </item>
	/// <item>
	/// <term>pvarLeft is empty and pvarRight is not empty</term>
	/// <term>0 as type double</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are empty</term>
	/// <term>DISP_E_OVERFLOW</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardiv HRESULT VarDiv( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "63cd466d-da23-4c61-ba7c-899f56f02245")]
	public static extern HRESULT VarDiv(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Performs a bitwise equivalence on two variants.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// If each bit in pvarLeft is equal to the corresponding bit in pvarRight then TRUE is returned. Otherwise FALSE is returned.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vareqv HRESULT VarEqv( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "34ddece6-87c8-469d-b275-443d1e99b1c9")]
	public static extern HRESULT VarEqv(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Returns the integer portion of a variant.</summary>
	/// <param name="pvarIn">The variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>If the variant is negative, then the first negative integer greater than or equal to the variant is returned.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varfix HRESULT VarFix( LPVARIANT pvarIn, LPVARIANT
	// pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "d90f37c7-87a8-4800-901c-d2aa3e5d838b")]
	public static extern HRESULT VarFix(in VARIANT pvarIn, out VARIANT pvarResult);

	/// <summary>Formats a variant into string form by parsing a format string.</summary>
	/// <param name="pvarIn">The variant.</param>
	/// <param name="pstrFormat">The format string. For example "mm-dd-yy".</param>
	/// <param name="iFirstDay">
	/// <para>First day of the week.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The system default</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Monday</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Tuesday</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Wednesday</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>Thursday</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>Friday</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>Saturday</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>Sunday</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="iFirstWeek">
	/// <para>First week of the year.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The system default.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>The first week contains January 1st.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>The larger half (four days) of the first week is in the current year.</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>The first week has seven days.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">Flags that control the formatting process. The only flags that can be set are VAR_CALENDAR_HIJRI or VAR_FORMAT_NOSUBSTITUTE.</param>
	/// <param name="pbstrOut">The formatted string that represents the variant.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>This function uses the user's default locale while calling VarTokenizeFormatString and VarFormatFromTokens.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varformat HRESULT VarFormat( LPVARIANT pvarIn, LPOLESTR
	// pstrFormat, int iFirstDay, int iFirstWeek, ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "2e1b4fd1-a86b-4933-8934-5d725168a2cd")]
	public static extern HRESULT VarFormat(in VARIANT pvarIn, [MarshalAs(UnmanagedType.LPWStr)] string pstrFormat, int iFirstDay, int iFirstWeek, VarFlags dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Converts a variant from one type to another.</summary>
	/// <param name="pvargDest">The destination variant. If this is the same as pvarSrc, the variant will be converted in place.</param>
	/// <param name="pvarSrc">The variant to convert.</param>
	/// <param name="wFlags">
	/// <para>Flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VARIANT_NOVALUEPROP</term>
	/// <term>
	/// Prevents the function from attempting to coerce an object to a fundamental type by getting the Value property. Applications
	/// should set this flag only if necessary, because it makes their behavior inconsistent with other applications.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VARIANT_ALPHABOOL</term>
	/// <term>Converts a VT_BOOL value to a string containing either "True" or "False".</term>
	/// </item>
	/// <item>
	/// <term>VARIANT_NOUSEROVERRIDE</term>
	/// <term>For conversions to or from VT_BSTR, passes LOCALE_NOUSEROVERRIDE to the core coercion routines.</term>
	/// </item>
	/// <item>
	/// <term>VARIANT_LOCALBOOL</term>
	/// <term>For conversions from VT_BOOL to VT_BSTR and back, uses the language specified by the locale in use on the local computer.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="vt">
	/// The type to convert to. If the return code is S_OK, the <c>vt</c> field of the *pvargDest is guaranteed to be equal to this value.
	/// </param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The variant type is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by pvarSrc does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>VariantChangeType</c> function handles coercions between the fundamental types (including numeric-to-string and
	/// string-to-numeric coercions). The pvarSrc argument is changed during the conversion process. For example, if the source variant
	/// is of type VT_BOOL and the destination is of type VT_UINT, the pvarSrc argument is first converted to VT_I2 and then the
	/// conversion proceeds. A variant that has VT_BYREF set is coerced to a value by obtaining the referenced value. An object is
	/// coerced to a value by invoking the object's <c>Value</c> property (DISPID_VALUE).
	/// </para>
	/// <para>
	/// Typically, the implementor of IDispatch::Invoke determines which member is being accessed, and then calls
	/// <c>VariantChangeType</c> to get the value of one or more arguments. For example, if the IDispatch call specifies a
	/// <c>SetTitle</c> member that takes one string argument, the implementor would call <c>VariantChangeType</c> to attempt to coerce
	/// the argument to VT_BSTR. If <c>VariantChangeType</c> does not return an error, the argument could then be obtained directly from
	/// the <c>bstrVal</c> field of the VARIANTARG. If <c>VariantChangeType</c> returns DISP_E_TYPEMISMATCH, the implementor would set
	/// *puArgErr to 0 (indicating the argument in error) and return DISP_E_TYPEMISMATCH from Invoke.
	/// </para>
	/// <para>Arrays of one type cannot be converted to arrays of another type with this function.</para>
	/// <para><c>Note</c> The type of a VARIANTARG should not be changed in the rgvarg array in place.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-variantchangetype HRESULT VariantChangeType( VARIANTARG
	// *pvargDest, const VARIANTARG *pvarSrc, USHORT wFlags, VARTYPE vt );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "48a51e32-95d7-4eeb-8106-f5043ffa2fd1")]
	public static extern HRESULT VariantChangeType(out VARIANT pvargDest, in VARIANT pvarSrc, VarChangeFlag wFlags, VARTYPE vt);

	/// <summary>Converts a variant from one type to another, using an LCID.</summary>
	/// <param name="pvargDest">The destination variant. If this is the same as pvarSrc, the variant will be converted in place.</param>
	/// <param name="pvarSrc">The variant to convert.</param>
	/// <param name="lcid">
	/// The locale identifier. The LCID is useful when the type of the source or destination VARIANTARG is VT_BSTR, VT_DISPATCH, or VT_DATE.
	/// </param>
	/// <param name="wFlags">
	/// <para>Flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VARIANT_NOVALUEPROP</term>
	/// <term>
	/// Prevents the function from attempting to coerce an object to a fundamental type by getting the Value property. Applications
	/// should set this flag only if necessary, because it makes their behavior inconsistent with other applications.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VARIANT_ALPHABOOL</term>
	/// <term>Converts a VT_BOOL value to a string containing either "True" or "False".</term>
	/// </item>
	/// <item>
	/// <term>VARIANT_NOUSEROVERRIDE</term>
	/// <term>For conversions to or from VT_BSTR, passes LOCALE_NOUSEROVERRIDE to the core coercion routines.</term>
	/// </item>
	/// <item>
	/// <term>VARIANT_LOCALBOOL</term>
	/// <term>For conversions from VT_BOOL to VT_BSTR and back, uses the language specified by the locale in use on the local computer.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="vt">
	/// The type to convert to. If the return code is S_OK, the <c>vt</c> field of the *pvargDest is guaranteed to be equal to this value.
	/// </param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The variant type is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The data pointed to by pvarSrc does not fit in the destination type.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>The argument could not be coerced to the specified type.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>VariantChangeTypeEx</c> function handles coercions between the fundamental types (including numeric-to-string and
	/// string-to-numeric coercions). A variant that has VT_BYREF set is coerced to a value by obtaining the referenced value. An object
	/// is coerced to a value by invoking the object's <c>Value</c> property (DISPID_VALUE).
	/// </para>
	/// <para>
	/// Typically, the implementor of IDispatch::Invoke determines which member is being accessed, and then calls VariantChangeType to
	/// get the value of one or more arguments. For example, if the IDispatch call specifies a SetTitle member that takes one string
	/// argument, the implementor would call <c>VariantChangeTypeEx</c> to attempt to coerce the argument to VT_BSTR.
	/// </para>
	/// <para>
	/// If <c>VariantChangeTypeEx</c> does not return an error, the argument could then be obtained directly from the <c>bstrVal</c>
	/// field of the VARIANTARG. If <c>VariantChangeTypeEx</c> returns DISP_E_TYPEMISMATCH, the implementor would set *puArgErr to 0
	/// (indicating the argument in error) and return DISP_E_TYPEMISMATCH from IDispatch::Invoke.
	/// </para>
	/// <para>Arrays of one type cannot be converted to arrays of another type with this function.</para>
	/// <para><c>Note</c> The type of a VARIANTARG should not be changed in the rgvarg array in place.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-variantchangetypeex HRESULT VariantChangeTypeEx( VARIANTARG
	// *pvargDest, const VARIANTARG *pvarSrc, LCID lcid, USHORT wFlags, VARTYPE vt );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "f2ef2e5f-e247-4abd-890f-f096d956cf4f")]
	public static extern HRESULT VariantChangeTypeEx(out VARIANT pvargDest, in VARIANT pvarSrc, LCID lcid, VarChangeFlag wFlags, VARTYPE vt);

	/// <summary>Frees the destination variant and makes a copy of the source variant.</summary>
	/// <param name="pvargDest">The destination variant.</param>
	/// <param name="pvargSrc">The source variant.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_ARRAYISLOCKED</term>
	/// <term>The variant contains an array that is locked.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The variant type is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// First, free any memory that is owned by pvargDest, such as VariantClear (pvargDest must point to a valid initialized variant,
	/// and not simply to an uninitialized memory location). Then pvargDest receives an exact copy of the contents of pvargSrc.
	/// </para>
	/// <para>
	/// If pvargSrc is a VT_BSTR, a copy of the string is made. If pvargSrcis a VT_ARRAY, the entire array is copied. If pvargSrc is a
	/// VT_DISPATCH or VT_UNKNOWN, <c>AddRef</c> is called to increment the object's reference count.
	/// </para>
	/// <para>
	/// If the variant to be copied is a COM object that is passed by reference, the vtfield of the pvargSrcparameter is VT_DISPATCH |
	/// VT_BYREF or VT_UNKNOWN | VT_BYREF. In this case, <c>VariantCopy</c> does not increment the reference count on the referenced
	/// object. Because the variant being copied is a pointer to a reference to an object, <c>VariantCopy</c> has no way to determine if
	/// it is necessary to increment the reference count of the object. It is therefore the responsibility of the caller to call
	/// <c>IUnknown::AddRef</c> on the object or not, as appropriate.
	/// </para>
	/// <para><c>Note</c> The <c>VariantCopy</c> method is not threadsafe.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-variantcopy HRESULT VariantCopy( VARIANTARG *pvargDest,
	// const VARIANTARG *pvargSrc );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "f6ddbe1f-37b0-44f1-a3f0-b7ef4df88f8a")]
	public static extern HRESULT VariantCopy(out VARIANT pvargDest, in VARIANT pvargSrc);

	/// <summary>
	/// Frees the destination variant and makes a copy of the source variant, performing the necessary indirection if the source is
	/// specified to be VT_BYREF.
	/// </summary>
	/// <param name="pvarDest">The destination variant.</param>
	/// <param name="pvargSrc">The source variant.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_ARRAYISLOCKED</term>
	/// <term>The variant contains an array that is locked.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADVARTYPE</term>
	/// <term>The variant type is not a valid type of variant.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is useful when a copy of a variant is needed, and to guarantee that it is not VT_BYREF, such as when handling
	/// arguments in an implementation of IDispatch::Invoke.
	/// </para>
	/// <para>
	/// For example, if the source is a (VT_BYREF | VT_I2), the destination will be a BYVAL | VT_I2. The same is true for all legal
	/// VT_BYREF combinations, including VT_VARIANT.
	/// </para>
	/// <para>If pvargSrc is (VT_BYREF | VT_VARIANT), and the contained variant is VT_BYREF, the contained variant is also dereferenced.</para>
	/// <para>This function frees any existing contents of pvarDest.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-variantcopyind HRESULT VariantCopyInd( VARIANT *pvarDest,
	// const VARIANTARG *pvargSrc );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "5d9be6cd-92e5-485c-ba0d-8630d3e414b8")]
	public static extern HRESULT VariantCopyInd(out VARIANT pvarDest, in VARIANT pvargSrc);

	/// <summary>Initializes a variant.</summary>
	/// <param name="pvarg">The variant to initialize.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// The <c>VariantInit</c> function initializes the VARIANTARG by setting the <c>vt</c> field to VT_EMPTY. Unlike VariantClear, this
	/// function does not interpret the current contents of the VARIANTARG. Use <c>VariantInit</c> to initialize new local variables of
	/// type VARIANTARG (or VARIANT).
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows how to initialize an array of variants, where is the number of elements in the array.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-variantinit void VariantInit( VARIANTARG *pvarg );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "96aeb671-5528-4d3c-8e70-313716550b42")]
	public static extern void VariantInit(ref VARIANT pvarg);

	/// <summary>Converts two variants of any type to integers then returns the result from dividing them.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Condition</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>Both expressions are strings, dates, characters, or boolean values</term>
	/// <term>Division and an integer is returned</term>
	/// </item>
	/// <item>
	/// <term>One expression is a string and the other a character</term>
	/// <term>Division</term>
	/// </item>
	/// <item>
	/// <term>One expression is numeric and the other a string</term>
	/// <term>Division</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are numeric</term>
	/// <term>Division</term>
	/// </item>
	/// <item>
	/// <term>Either expression is null</term>
	/// <term>Null</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are empty</term>
	/// <term>DISP_E_DIVBYZERO</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varidiv HRESULT VarIdiv( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "dd76b96f-b616-420f-9f26-d88004574411")]
	public static extern HRESULT VarIdiv(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Performs a bitwise implication on two variants.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>pvarLeft</term>
	/// <term>pvarRight</term>
	/// <term>pvarResult</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>TRUE</term>
	/// <term>FALSE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>TRUE</term>
	/// <term>NULL</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>FALSE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>NULL</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>FALSE</term>
	/// <term>NULL</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// </item>
	/// </list>
	/// <para>
	/// Because <c>VarImp</c> performs bitwise operations on pvarLeft and pvarRight instead of logical operations a pvarResult of TRUE
	/// is returned by this function call.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varimp HRESULT VarImp( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "c8d846dd-97c3-4e7d-af4f-632f04be75cf")]
	public static extern HRESULT VarImp(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Returns the integer portion of a variant.</summary>
	/// <param name="pvarIn">The variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>If the variant is negative, then the first negative integer less than or equal to the variant is returned.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varint HRESULT VarInt( LPVARIANT pvarIn, LPVARIANT
	// pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "96a9a158-d822-4cde-80c5-ea66f0fa4f1f")]
	public static extern HRESULT VarInt(in VARIANT pvarIn, out VARIANT pvarResult);

	/// <summary>Divides two variants and returns only the remainder.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varmod HRESULT VarMod( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "910d3f37-15f4-4a0e-8aa0-ab58be865c62")]
	public static extern HRESULT VarMod(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Returns a string containing the localized month name.</summary>
	/// <param name="iMonth">Represents the month, as a number from 1 to 12.</param>
	/// <param name="fAbbrev">
	/// If zero then the full (non-abbreviated) month name is used. If non-zero, then the abbreviation for the month name is used.
	/// </param>
	/// <param name="dwFlags">VAR_CALENDAR_HIJRI is the only flag that can be set.</param>
	/// <param name="pbstrOut">Receives the formatted string that represents the variant.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varmonthname HRESULT VarMonthName( int iMonth, int fAbbrev,
	// ULONG dwFlags, BSTR *pbstrOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "8bb760ae-2306-4c32-805d-58e5402e6d78")]
	public static extern HRESULT VarMonthName(int iMonth, [MarshalAs(UnmanagedType.Bool)] bool fAbbrev, VarFlags dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

	/// <summary>Returns the result from multiplying two variants.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Condition</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>Both expressions are strings, dates, characters, or boolean values</term>
	/// <term>Multiplication</term>
	/// </item>
	/// <item>
	/// <term>One expression is a string and the other a character</term>
	/// <term>Multiplication</term>
	/// </item>
	/// <item>
	/// <term>One expression is numeric and the other a string</term>
	/// <term>Multiplication</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are numeric</term>
	/// <term>Multiplication</term>
	/// </item>
	/// <item>
	/// <term>Either expression is null</term>
	/// <term>Null</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are empty</term>
	/// <term>Empty string</term>
	/// </item>
	/// </list>
	/// <para>Boolean values are converted to -1 for FALSE and 0 for TRUE.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varmul HRESULT VarMul( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "d804a23b-7d52-4f11-a93e-3eb02a079d2c")]
	public static extern HRESULT VarMul(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Performs logical negation on a variant.</summary>
	/// <param name="pvarIn">The variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varneg HRESULT VarNeg( LPVARIANT pvarIn, LPVARIANT
	// pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "95a8c1ee-6c8a-4eff-871b-63be3a616995")]
	public static extern HRESULT VarNeg(in VARIANT pvarIn, out VARIANT pvarResult);

	/// <summary>Performs the bitwise not negation operation on a variant.</summary>
	/// <param name="pvarIn">The variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>pvarIn</term>
	/// <term>pvarResult</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varnot HRESULT VarNot( LPVARIANT pvarIn, LPVARIANT
	// pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "e3825905-2a28-4283-bb65-0273572f3150")]
	public static extern HRESULT VarNot(in VARIANT pvarIn, out VARIANT pvarResult);

	/// <summary>Converts parsed results to a variant.</summary>
	/// <param name="pnumprs">
	/// The parsed results. The <c>cDig</c> member of this argument specifies the number of digits present in rgbDig.
	/// </param>
	/// <param name="rgbDig">The values of the digits. The <c>cDig</c> field of pnumprs contains the number of digits.</param>
	/// <param name="dwVtBits">
	/// <para>One bit set for each type that is acceptable as a return value (in many cases, just one bit).</para>
	/// <para>VTBIT_I1</para>
	/// <para>VTBIT_UI1</para>
	/// <para>VTBIT_I2</para>
	/// <para>VTBIT_UI2</para>
	/// <para>VTBIT_I4</para>
	/// <para>VTBIT_UI4</para>
	/// <para>VTBIT_R4</para>
	/// <para>VTBIT_R8</para>
	/// <para>VTBIT_CY</para>
	/// <para>VTBIT_DECIMAL</para>
	/// </param>
	/// <param name="pvar">The variant result.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Out of memory.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>The number is too large to be represented in an allowed type. There is no error if precision is lost in the conversion.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// For rounding decimal numbers, the digit array must be at least one digit longer than the maximum required for data types. The
	/// maximum number of digits required for the DECIMAL data type is 29, so the digit array must have room for 30 digits. There must
	/// also be enough digits to accept the number in octal, if that parsing options is selected. (Hexadecimal and octal numbers are
	/// limited by <c>VarNumFromParseNum</c> to the magnitude of an unsigned long [32 bits], so they need 11 octal digits.)
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varnumfromparsenum HRESULT VarNumFromParseNum( NUMPARSE
	// *pnumprs, BYTE *rgbDig, ULONG dwVtBits, VARIANT *pvar );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "6a01a779-ab1b-4fd5-a550-449b19358b7a")]
	public static extern HRESULT VarNumFromParseNum(in NUMPARSE pnumprs, [In] byte[] rgbDig, VtBits dwVtBits, out VARIANT pvar);

	/// <summary>Performs a logical disjunction on two variants.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>pvarLeft</term>
	/// <term>pvarRight</term>
	/// <term>pvarResult</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>TRUE</term>
	/// <term>FALSE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>TRUE</term>
	/// <term>NULL</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>FALSE</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>FALSE</term>
	/// <term>NULL</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varor HRESULT VarOr( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "8c161755-4fdd-48bd-9dc4-6510cc9ce8ab")]
	public static extern HRESULT VarOr(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Parses a string, and creates a type-independent description of the number it represents.</summary>
	/// <param name="strIn">The input string to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="dwFlags">
	/// Enables the caller to control parsing, therefore defining the acceptable syntax of a number. If this field is set to zero, the
	/// input string must contain nothing but decimal digits. Setting each defined flag bit enables parsing of that syntactic feature.
	/// Standard Automation parsing (for example, as used by VarI2FromStr) has all flags set (NUMPRS_STD).
	/// </param>
	/// <param name="pnumprs">The parsed results.</param>
	/// <param name="rgbDig">
	/// The values for the digits in the range 0–7, 0–9, or 0–15, depending on whether the number is octal, decimal, or hexadecimal. All
	/// leading zeros have been stripped off. For decimal numbers, trailing zeros are also stripped off, unless the number is zero, in
	/// which case a single zero digit will be present.
	/// </param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Internal memory allocation failed. (Used for DBCS only to create a copy with all wide characters mapped narrow.)</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_TYPEMISMATCH</term>
	/// <term>
	/// There is no valid number in the string, or there is no closing parenthesis to match an opening one. In the former case, cDig and
	/// cchUsed in the NUMPARSE structure will be zero. In the latter, the NUMPARSE structure and digit array are fully updated, as if
	/// the closing parenthesis was present.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DISP_E_OVERFLOW</term>
	/// <term>
	/// For hexadecimal and octal digits, there are more digits than will fit into the array. For decimal, the exponent exceeds the
	/// maximum possible. In both cases, the NUMPARSE structure and digit array are fully updated (for decimal, the cchUsed field
	/// excludes the entire exponent).
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varparsenumfromstr HRESULT VarParseNumFromStr( LPCOLESTR
	// strIn, LCID lcid, ULONG dwFlags, NUMPARSE *pnumprs, BYTE *rgbDig );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "b77ce0df-5635-4760-8b42-f3afec49482b")]
	public static extern HRESULT VarParseNumFromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, ref NUMPARSE pnumprs, [Out] byte[] rgbDig);

	/// <summary>Returns the result of performing the power function with two variants.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>Returns the result of pvarLeft to the power of pvarRight.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varpow HRESULT VarPow( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "80e19d25-94cf-49f8-b49f-9cda14d0ee4b")]
	public static extern HRESULT VarPow(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Rounds a variant to the specified number of decimal places.</summary>
	/// <param name="pvarIn">The variant.</param>
	/// <param name="cDecimals">The number of decimal places.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varround HRESULT VarRound( LPVARIANT pvarIn, int cDecimals,
	// LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "7713f477-f6a3-456d-a442-a78750542b03")]
	public static extern HRESULT VarRound(in VARIANT pvarIn, int cDecimals, out VARIANT pvarResult);

	/// <summary>Subtracts two variants.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Condition</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>Both expressions are strings</term>
	/// <term>Subtraction</term>
	/// </item>
	/// <item>
	/// <term>One expression is a string and the other a character</term>
	/// <term>Subtraction</term>
	/// </item>
	/// <item>
	/// <term>One expression is numeric and the other a string</term>
	/// <term>Subtraction</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are numeric</term>
	/// <term>Subtraction</term>
	/// </item>
	/// <item>
	/// <term>Either expression is null</term>
	/// <term>Null</term>
	/// </item>
	/// <item>
	/// <term>Both expressions are empty</term>
	/// <term>Empty string</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varsub HRESULT VarSub( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "395cc5fe-8694-47a9-8e92-1768c300ba7e")]
	public static extern HRESULT VarSub(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>Parses the actual format string into a series of tokens which can be used to format variants using VarFormatFromTokens.</summary>
	/// <param name="pstrFormat">The format string. For example "mm-dd-yy".</param>
	/// <param name="rgbTok">The destination token buffer.</param>
	/// <param name="cbTok">The size of the destination token buffer.</param>
	/// <param name="iFirstDay">
	/// <para>First day of the week.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The system default</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Monday</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Tuesday</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Wednesday</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>Thursday</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>Friday</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>Saturday</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>Sunday</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="iFirstWeek">
	/// <para>First week of the year.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The system default.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>The first week contains January 1st.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>The larger half (four days) of the first week is in the current year.</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>The first week has seven days.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lcid">The locale to interpret format string in.</param>
	/// <param name="pcbActual">Points to the integer which is set to the first generated token. This parameter can be NULL.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more of the arguments is not valid.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BUFFERTOOSMALL</term>
	/// <term>The destination token buffer is too small.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Parsing the format string once and then using it repeatedly is usually faster than calling VarFormat repeatedly, because the
	/// latter routine calls <c>VarTokenizeFormatString</c> for each call.
	/// </para>
	/// <para>
	/// The locale you pass in controls how the format string is interpreted, not how the actual output of VarFormatFromTokens looks.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vartokenizeformatstring HRESULT VarTokenizeFormatString(
	// LPOLESTR pstrFormat, LPBYTE rgbTok, int cbTok, int iFirstDay, int iFirstWeek, LCID lcid, int *pcbActual );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "7cec1bc5-39ea-4b47-880b-62584ff23536")]
	public static extern HRESULT VarTokenizeFormatString([MarshalAs(UnmanagedType.LPWStr), Optional] string? pstrFormat, byte[] rgbTok, int cbTok, int iFirstDay, int iFirstWeek, LCID lcid, IntPtr pcbActual);

	/// <summary>Performs a logical exclusion on two variants.</summary>
	/// <param name="pvarLeft">The first variant.</param>
	/// <param name="pvarRight">The second variant.</param>
	/// <param name="pvarResult">The result variant.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The function operates as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>pvarLeft</term>
	/// <term>pvarRight</term>
	/// <term>pvarResult</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>TRUE</term>
	/// <term>FALSE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>TRUE</term>
	/// <term>TRUE</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>FALSE</term>
	/// <term>FALSE</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varxor HRESULT VarXor( LPVARIANT pvarLeft, LPVARIANT
	// pvarRight, LPVARIANT pvarResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "5a9ebe42-07a0-4bb8-afb7-24d18ce32768")]
	public static extern HRESULT VarXor(in VARIANT pvarLeft, in VARIANT pvarRight, out VARIANT pvarResult);

	/// <summary>
	/// VARIANTARG describes arguments passed within DISPPARAMS, and VARIANT to specify variant data that cannot be passed by reference.
	/// <para>
	/// When a variant refers to another variant by using the VT_VARIANT | VT_BYREF vartype, the variant being referred to cannot also
	/// be of type VT_VARIANT | VT_BYREF.VARIANTs can be passed by value, even if VARIANTARGs cannot.
	/// </para>
	/// </summary>
	[PInvokeData("oaidl.h")]
	[StructLayout(LayoutKind.Explicit)]
	[System.Security.SecurityCritical]
	public struct VARIANT
	{
		/// <summary>The type of data in the union.</summary>
		[FieldOffset(0)] public VARTYPE vt;

		/// <summary>Reserved.</summary>
		[FieldOffset(2)] public ushort wReserved1;

		/// <summary>Reserved.</summary>
		[FieldOffset(4)] public ushort wReserved2;

		/// <summary>Reserved.</summary>
		[FieldOffset(6)] public ushort wReserved3;

		/// <summary>A generic value.</summary>
		[FieldOffset(8)] public IntPtr byref;

		// ensures correct size
		[FieldOffset(8)] private Record _rec;

		// use for easy primitive casts
		[FieldOffset(8)] internal ulong _ulong;

		/// <summary>A decimal value.</summary>
		[FieldOffset(0)] public decimal decVal;

		[StructLayout(LayoutKind.Sequential)]
		private struct Record
		{
			private readonly IntPtr _record;
			private readonly IntPtr _recordInfo;
		}
	}
}