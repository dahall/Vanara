using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class OleAut32
	{
		/// <summary>Retrieves the absolute value of a variant of type currency.</summary>
		/// <param name="cyIn">The currency variant.</param>
		/// <param name="pcyResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyabs HRESULT VarCyAbs( CY cyIn, LPCY pcyResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyAbs")]
		public static extern HRESULT VarCyAbs(CY cyIn, out CY pcyResult);

		/// <summary>Adds two variants of type currency.</summary>
		/// <param name="cyLeft">The first variant.</param>
		/// <param name="cyRight">The second variant.</param>
		/// <param name="pcyResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyadd HRESULT VarCyAdd( CY cyLeft, CY cyRight, LPCY
		// pcyResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyAdd")]
		public static extern HRESULT VarCyAdd(CY cyLeft, CY cyRight, out CY pcyResult);

		/// <summary>Compares two variants of type currency.</summary>
		/// <param name="cyLeft">The first variant.</param>
		/// <param name="cyRight">The second variant.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>VARCMP_LT 0</term>
		/// <term>cyLeft is less than cyRight.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_EQ 1</term>
		/// <term>The two parameters are equal.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_GT 2</term>
		/// <term>cyLeft is greater than cyRight.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_NULL 3</term>
		/// <term>Either expression is null.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcycmp HRESULT VarCyCmp( CY cyLeft, CY cyRight );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyCmp")]
		public static extern HRESULT VarCyCmp(CY cyLeft, CY cyRight);

		/// <summary>Compares a variant of type currency with a value of type double.</summary>
		/// <param name="cyLeft">The first variant.</param>
		/// <param name="dblRight">The second variant.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>VARCMP_LT 0</term>
		/// <term>cyLeft is less than dblRight.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_EQ 1</term>
		/// <term>The two parameters are equal.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_GT 2</term>
		/// <term>cyLeft is greater than dblRight.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_NULL 3</term>
		/// <term>Either expression is null.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcycmpr8 HRESULT VarCyCmpR8( CY cyLeft, double dblRight );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyCmpR8")]
		public static extern HRESULT VarCyCmpR8(CY cyLeft, double dblRight);

		/// <summary>Retrieves the integer portion of a variant of type currency.</summary>
		/// <param name="cyIn">The currency variant.</param>
		/// <param name="pcyResult">
		/// The resulting variant. If the variant is negative, then the first negative integer greater than or equal to the variant is returned.
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfix HRESULT VarCyFix( CY cyIn, LPCY pcyResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFix")]
		public static extern HRESULT VarCyFix(CY cyIn, out CY pcyResult);

		/// <summary>Converts a Boolean value to a currency value.</summary>
		/// <param name="boolIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfrombool HRESULT VarCyFromBool( VARIANT_BOOL boolIn,
		// CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromBool")]
		public static extern HRESULT VarCyFromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out CY pcyOut);

		/// <summary>Converts a date value to a currency value.</summary>
		/// <param name="dateIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromdate HRESULT VarCyFromDate( DATE dateIn, CY
		// *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromDate")]
		public static extern HRESULT VarCyFromDate(DATE dateIn, out CY pcyOut);

		/// <summary>Converts a decimal value to a currency value.</summary>
		/// <param name="pdecIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromdec HRESULT VarCyFromDec( const DECIMAL *pdecIn,
		// CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromDec")]
		public static extern HRESULT VarCyFromDec(in DECIMAL pdecIn, out CY pcyOut);

		/// <summary>Converts the default property of an IDispatch instance to a currency value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromdisp HRESULT VarCyFromDisp( IDispatch *pdispIn,
		// LCID lcid, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromDisp")]
		public static extern HRESULT VarCyFromDisp(IDispatch pdispIn, LCID lcid, out CY pcyOut);

		/// <summary>Converts the default property of an IDispatch instance to a currency value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromdisp HRESULT VarCyFromDisp( IDispatch *pdispIn,
		// LCID lcid, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromDisp")]
		public static extern HRESULT VarCyFromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out CY pcyOut);

		/// <summary>Converts a char value to a currency value.</summary>
		/// <param name="cIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromi1 HRESULT VarCyFromI1( CHAR cIn, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromI1")]
		public static extern HRESULT VarCyFromI1(sbyte cIn, out CY pcyOut);

		/// <summary>Converts a short value to a currency value.</summary>
		/// <param name="sIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromi2 HRESULT VarCyFromI2( SHORT sIn, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromI2")]
		public static extern HRESULT VarCyFromI2(short sIn, out CY pcyOut);

		/// <summary>Converts a long value to a currency value.</summary>
		/// <param name="lIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromi4 HRESULT VarCyFromI4( LONG lIn, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromI4")]
		public static extern HRESULT VarCyFromI4(int lIn, out CY pcyOut);

		/// <summary>Converts an 8-byte integer value to a currency value.</summary>
		/// <param name="i64In">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromi8 HRESULT VarCyFromI8( LONG64 i64In, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromI8")]
		public static extern HRESULT VarCyFromI8(CY i64In, out CY pcyOut);

		/// <summary>Converts a float value to a currency value.</summary>
		/// <param name="fltIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromr4 HRESULT VarCyFromR4( FLOAT fltIn, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromR4")]
		public static extern HRESULT VarCyFromR4(float fltIn, out CY pcyOut);

		/// <summary>Converts a double value to a currency value.</summary>
		/// <param name="dblIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromr8 HRESULT VarCyFromR8( DOUBLE dblIn, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromR8")]
		public static extern HRESULT VarCyFromR8(double dblIn, out CY pcyOut);

		/// <summary>Converts an OLECHAR string to a currency value.</summary>
		/// <param name="strIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="dwFlags">
		/// <para>One of more of the following flags.</para>
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
		/// <term>Omits the date portion of a VT_DATE and returns only the time. Applies to conversions to or from dates.</term>
		/// </item>
		/// <item>
		/// <term>VAR_DATEVALUEONLY</term>
		/// <term>Omits the time portion of a VT_DATE and returns only the date. Applies to conversions to or from dates.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromstr HRESULT VarCyFromStr( LPCOLESTR strIn, LCID
		// lcid, ULONG dwFlags, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromStr")]
		public static extern HRESULT VarCyFromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out CY pcyOut);

		/// <summary>Converts an unsigned char value to a currency value.</summary>
		/// <param name="bIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromui1 HRESULT VarCyFromUI1( BYTE bIn, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromUI1")]
		public static extern HRESULT VarCyFromUI1(byte bIn, out CY pcyOut);

		/// <summary>Converts an unsigned short value to a currency value.</summary>
		/// <param name="uiIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromui2 HRESULT VarCyFromUI2( USHORT uiIn, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromUI2")]
		public static extern HRESULT VarCyFromUI2(ushort uiIn, out CY pcyOut);

		/// <summary>Converts an unsigned long value to a currency value.</summary>
		/// <param name="ulIn">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromui4 HRESULT VarCyFromUI4( ULONG ulIn, CY *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromUI4")]
		public static extern HRESULT VarCyFromUI4(uint ulIn, out CY pcyOut);

		/// <summary>Converts an 8-byte unsigned integer value to a currency value.</summary>
		/// <param name="ui64In">The value to convert.</param>
		/// <param name="pcyOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyfromui8 HRESULT VarCyFromUI8( ULONG64 ui64In, CY
		// *pcyOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyFromUI8")]
		public static extern HRESULT VarCyFromUI8(ulong ui64In, out CY pcyOut);

		/// <summary>Retrieves the integer portion of a variant of type currency.</summary>
		/// <param name="cyIn">The currency variant.</param>
		/// <param name="pcyResult">
		/// The resulting variant. If the variant is negative then the first negative integer less than or equal to the variant is returned.
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyint HRESULT VarCyInt( CY cyIn, LPCY pcyResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyInt")]
		public static extern HRESULT VarCyInt(CY cyIn, out CY pcyResult);

		/// <summary>Multiplies two variants of type currency.</summary>
		/// <param name="cyLeft">The first variant</param>
		/// <param name="cyRight">The second variant.</param>
		/// <param name="pcyResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>If any of the fields of cyLeft or cyRight is left uninitialized, it may default to a large value causing DISP_E_OVERFLOW.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcymul HRESULT VarCyMul( CY cyLeft, CY cyRight, LPCY
		// pcyResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyMul")]
		public static extern HRESULT VarCyMul(CY cyLeft, CY cyRight, out CY pcyResult);

		/// <summary>Multiplies a currency value by a 32-bit integer.</summary>
		/// <param name="cyLeft">The first variant.</param>
		/// <param name="lRight">The second variant.</param>
		/// <param name="pcyResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcymuli4 HRESULT VarCyMulI4( CY cyLeft, LONG lRight, LPCY
		// pcyResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyMulI4")]
		public static extern HRESULT VarCyMulI4(CY cyLeft, int lRight, out CY pcyResult);

		/// <summary>Multiplies a currency value by a 64-bit integer.</summary>
		/// <param name="cyLeft">The first variant.</param>
		/// <param name="lRight">The second variant.</param>
		/// <param name="pcyResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcymuli8 HRESULT VarCyMulI8( CY cyLeft, LONG64 lRight,
		// LPCY pcyResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyMulI8")]
		public static extern HRESULT VarCyMulI8(CY cyLeft, long lRight, out CY pcyResult);

		/// <summary>Performs a logical negation on a variant of type currency.</summary>
		/// <param name="cyIn">The variant to negate.</param>
		/// <param name="pcyResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyneg HRESULT VarCyNeg( CY cyIn, LPCY pcyResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyNeg")]
		public static extern HRESULT VarCyNeg(CY cyIn, out CY pcyResult);

		/// <summary>Rounds a variant of type currency to the specified number of decimal places.</summary>
		/// <param name="cyIn">The variant to round.</param>
		/// <param name="cDecimals">The number of currency decimals.</param>
		/// <param name="pcyResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcyround HRESULT VarCyRound( CY cyIn, int cDecimals, LPCY
		// pcyResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCyRound")]
		public static extern HRESULT VarCyRound(CY cyIn, int cDecimals, out CY pcyResult);

		/// <summary>Subtracts two variants of type currency.</summary>
		/// <param name="cyLeft">The first variant.</param>
		/// <param name="cyRight">The second variant.</param>
		/// <param name="pcyResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varcysub HRESULT VarCySub( CY cyLeft, CY cyRight, LPCY
		// pcyResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarCySub")]
		public static extern HRESULT VarCySub(CY cyLeft, CY cyRight, out CY pcyResult);

		/// <summary>Converts a Boolean value to a date value.</summary>
		/// <param name="boolIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefrombool HRESULT VarDateFromBool( VARIANT_BOOL
		// boolIn, DATE *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromBool")]
		public static extern HRESULT VarDateFromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out DATE pdateOut);

		/// <summary>Converts a currency value to a date value.</summary>
		/// <param name="cyIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromcy HRESULT VarDateFromCy( CY cyIn, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromCy")]
		public static extern HRESULT VarDateFromCy(CY cyIn, out DATE pdateOut);

		/// <summary>Converts a decimal value to a date value.</summary>
		/// <param name="pdecIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromdec HRESULT VarDateFromDec( const DECIMAL
		// *pdecIn, DATE *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromDec")]
		public static extern HRESULT VarDateFromDec(in DECIMAL pdecIn, out DATE pdateOut);

		/// <summary>Converts the default property of an IDispatch instance to a date value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromdisp HRESULT VarDateFromDisp( IDispatch
		// *pdispIn, LCID lcid, DATE *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromDisp")]
		public static extern HRESULT VarDateFromDisp([In] IDispatch pdispIn, LCID lcid, out DATE pdateOut);

		/// <summary>Converts the default property of an IDispatch instance to a date value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromdisp HRESULT VarDateFromDisp( IDispatch
		// *pdispIn, LCID lcid, DATE *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromDisp")]
		public static extern HRESULT VarDateFromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out DATE pdateOut);

		/// <summary>Converts a char value to a date value.</summary>
		/// <param name="cIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromi1 HRESULT VarDateFromI1( CHAR cIn, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromI1")]
		public static extern HRESULT VarDateFromI1(sbyte cIn, out DATE pdateOut);

		/// <summary>Converts a short value to a date value.</summary>
		/// <param name="sIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromi2 HRESULT VarDateFromI2( SHORT sIn, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromI2")]
		public static extern HRESULT VarDateFromI2(short sIn, out DATE pdateOut);

		/// <summary>Converts a long value to a date value.</summary>
		/// <param name="lIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromi4 HRESULT VarDateFromI4( LONG lIn, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromI4")]
		public static extern HRESULT VarDateFromI4(int lIn, out DATE pdateOut);

		/// <summary>Converts an 8-byte unsigned integer value to a date value.</summary>
		/// <param name="i64In">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromi8 HRESULT VarDateFromI8( LONG64 i64In, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromI8")]
		public static extern HRESULT VarDateFromI8(long i64In, out DATE pdateOut);

		/// <summary>Converts a float value to a date value.</summary>
		/// <param name="fltIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromr4 HRESULT VarDateFromR4( FLOAT fltIn, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromR4")]
		public static extern HRESULT VarDateFromR4(float fltIn, out DATE pdateOut);

		/// <summary>Converts a double value to a date value.</summary>
		/// <param name="dblIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromr8 HRESULT VarDateFromR8( DOUBLE dblIn, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromR8")]
		public static extern HRESULT VarDateFromR8(double dblIn, out DATE pdateOut);

		/// <summary>Converts an OLECHAR string to a date value.</summary>
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
		/// <term>LOCALE_NOUSEROVERRIDE</term>
		/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
		/// </item>
		/// <item>
		/// <term>VAR_CALENDAR_HIJRI</term>
		/// <term>If set then the Hijri calendar is used. Otherwise the calendar set in the control panel is used.</term>
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
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromstr HRESULT VarDateFromStr( LPCOLESTR strIn,
		// LCID lcid, ULONG dwFlags, DATE *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromStr")]
		public static extern HRESULT VarDateFromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out DATE pdateOut);

		/// <summary>Converts a time and date converted from MS-DOS format to variant format.</summary>
		/// <param name="pudateIn">The unpacked date.</param>
		/// <param name="dwFlags">VAR_VALIDDATE if the date is valid.</param>
		/// <param name="pdateOut">The packed date.</param>
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
		/// The UDATE structure is used with <c>VarDateFromUdate</c>, VarDateFromUdateEx, and VarUdateFromDate. It represents an unpacked date.
		/// </para>
		/// <para>
		/// <code>typedef struct { SYSTEMTIME st; USHORT wDayOfYear; } UDATE;</code>
		/// </para>
		/// <para>
		/// The <c>VarDateFromUdate</c> function will accept invalid dates and try to fix them when resolving to a VARIANT time. For
		/// example, an invalid date such as 2/29/2001 will resolve to 3/1/2001. Only days are fixed, so invalid month values result in an
		/// error being returned. Days are checked to be between 1 and 31. Negative days and days greater than 31 results in an error. A day
		/// less than 31 but greater than the maximum day in that month has the day promoted to the appropriate day of the next month. A day
		/// equal to zero resolves as the last day of the previous month. For example, an invalid dates such as 2/0/2001 will resolve to 1/31/2001.
		/// </para>
		/// <para>Calling <c>VarDateFromUdate</c> has the same effect as calling VarDateFromUdateEx with the LCID 0x0409.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromudate HRESULT VarDateFromUdate( UDATE *pudateIn,
		// ULONG dwFlags, DATE *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromUdate")]
		public static extern HRESULT VarDateFromUdate(in UDATE pudateIn, VarFlags dwFlags, out DATE pdateOut);

		/// <summary>Converts a time and date converted from MS-DOS format to variant format.</summary>
		/// <param name="pudateIn">The unpacked date.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="dwFlags">VAR_VALIDDATE if the date is valid.</param>
		/// <param name="pdateOut">The packed date.</param>
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
		/// The UDATE structure is used with <c>VarDateFromUdateEx</c>, VarDateFromUdate, and VarUdateFromDate. It represents an unpacked date.
		/// </para>
		/// <para>
		/// <code>typedef struct { SYSTEMTIME st; USHORT wDayOfYear; } UDATE;</code>
		/// </para>
		/// <para>
		/// The VarDateFromUdate function accepts invalid dates and tries to fix them when resolving to a VARIANT time. Only days are fixed,
		/// so invalid month values result in an error being returned. Days are checked to verify that they are in the range of 1 through
		/// 31. Negative days and days greater than 31 result in an error. A day less than 31 but greater than the maximum day in that month
		/// has the day promoted to the appropriate day of the next month. For example, an invalid date such as 2/29/2001 resolves to
		/// 3/1/2001. A day equal to zero resolves as the last day of the previous month. For example, an invalid date such as 2/0/2001
		/// resolves to 1/31/2001.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromudateex HRESULT VarDateFromUdateEx( UDATE
		// *pudateIn, LCID lcid, ULONG dwFlags, DATE *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromUdateEx")]
		public static extern HRESULT VarDateFromUdateEx(in UDATE pudateIn, LCID lcid, VarFlags dwFlags, out DATE pdateOut);

		/// <summary>Converts an unsigned char value to a date value.</summary>
		/// <param name="bIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromui1 HRESULT VarDateFromUI1( BYTE bIn, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromUI1")]
		public static extern HRESULT VarDateFromUI1(byte bIn, out DATE pdateOut);

		/// <summary>Converts an unsigned short value to a date value.</summary>
		/// <param name="uiIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromui2 HRESULT VarDateFromUI2( USHORT uiIn, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromUI2")]
		public static extern HRESULT VarDateFromUI2(ushort uiIn, out DATE pdateOut);

		/// <summary>Converts an unsigned long value to a date value.</summary>
		/// <param name="ulIn">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromui4 HRESULT VarDateFromUI4( ULONG ulIn, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromUI4")]
		public static extern HRESULT VarDateFromUI4(uint ulIn, out DATE pdateOut);

		/// <summary>Converts an 8-byte unsigned value to a date value.</summary>
		/// <param name="ui64In">The value to convert.</param>
		/// <param name="pdateOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardatefromui8 HRESULT VarDateFromUI8( ULONG64 ui64In, DATE
		// *pdateOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDateFromUI8")]
		public static extern HRESULT VarDateFromUI8(ulong ui64In, out DATE pdateOut);

		/// <summary>Retrieves the absolute value of a variant of type decimal.</summary>
		/// <param name="pdecIn">The first variant.</param>
		/// <param name="pdecResult">The second variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecabs HRESULT VarDecAbs( LPDECIMAL pdecIn, LPDECIMAL
		// pdecResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecAbs")]
		public static extern HRESULT VarDecAbs(in DECIMAL pdecIn, out DECIMAL pdecResult);

		/// <summary>Adds two variants of type decimal.</summary>
		/// <param name="pdecLeft">The first variant.</param>
		/// <param name="pdecRight">The second variant.</param>
		/// <param name="pdecResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecadd HRESULT VarDecAdd( LPDECIMAL pdecLeft, LPDECIMAL
		// pdecRight, LPDECIMAL pdecResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecAdd")]
		public static extern HRESULT VarDecAdd(in DECIMAL pdecLeft, in DECIMAL pdecRight, out DECIMAL pdecResult);

		/// <summary>Compares two variants of type decimal.</summary>
		/// <param name="pdecLeft">The first variant.</param>
		/// <param name="pdecRight">The second variant.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>VARCMP_LT 0</term>
		/// <term>pdecLeft is less than dblRight.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_EQ 1</term>
		/// <term>The two parameters are equal.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_GT 2</term>
		/// <term>pdecLeft is greater than dblRight.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_NULL 3</term>
		/// <term>Either expression is null.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardeccmp HRESULT VarDecCmp( LPDECIMAL pdecLeft, LPDECIMAL
		// pdecRight );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecCmp")]
		public static extern HRESULT VarDecCmp(in DECIMAL pdecLeft, in DECIMAL pdecRight);

		/// <summary>Compares a variant of type decimal with the a value of type double.</summary>
		/// <param name="pdecLeft">The first variant.</param>
		/// <param name="dblRight">The second variant.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>VARCMP_LT 0</term>
		/// <term>pdecLeft is less than dblRight.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_EQ 1</term>
		/// <term>The two parameters are equal.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_GT 2</term>
		/// <term>pdecLeft is greater than dblRight.</term>
		/// </item>
		/// <item>
		/// <term>VARCMP_NULL 3</term>
		/// <term>Either expression is null.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardeccmpr8 HRESULT VarDecCmpR8( LPDECIMAL pdecLeft, double
		// dblRight );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecCmpR8")]
		public static extern HRESULT VarDecCmpR8(in DECIMAL pdecLeft, double dblRight);

		/// <summary>Divides two variants of type decimal.</summary>
		/// <param name="pdecLeft">The first decimal variant.</param>
		/// <param name="pdecRight">The second decimal variant.</param>
		/// <param name="pdecResult">The resulting decimal variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecdiv HRESULT VarDecDiv( LPDECIMAL pdecLeft, LPDECIMAL
		// pdecRight, LPDECIMAL pdecResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecDiv")]
		public static extern HRESULT VarDecDiv(in DECIMAL pdecLeft, in DECIMAL pdecRight, out DECIMAL pdecResult);

		/// <summary>Retrieves the integer portion of a variant of type decimal.</summary>
		/// <param name="pdecIn">The decimal variant.</param>
		/// <param name="pdecResult">
		/// The resulting variant. If the variant is negative, then the first negative integer greater than or equal to the variant is returned.
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfix HRESULT VarDecFix( LPDECIMAL pdecIn, LPDECIMAL
		// pdecResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFix")]
		public static extern HRESULT VarDecFix(in DECIMAL pdecIn, out DECIMAL pdecResult);

		/// <summary>Converts a Boolean value to a decimal value.</summary>
		/// <param name="boolIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfrombool HRESULT VarDecFromBool( VARIANT_BOOL boolIn,
		// DECIMAL *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromBool")]
		public static extern HRESULT VarDecFromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out DECIMAL pdecOut);

		/// <summary>Converts a currency value to a decimal value.</summary>
		/// <param name="cyIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromcy HRESULT VarDecFromCy( CY cyIn, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromCy")]
		public static extern HRESULT VarDecFromCy(CY cyIn, out DECIMAL pdecOut);

		/// <summary>Converts a date value to a decimal value.</summary>
		/// <param name="dateIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromdate HRESULT VarDecFromDate( DATE dateIn, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromDate")]
		public static extern HRESULT VarDecFromDate(DATE dateIn, out DECIMAL pdecOut);

		/// <summary>Converts the default property of an IDispatch instance to a decimal value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromdisp HRESULT VarDecFromDisp( IDispatch *pdispIn,
		// LCID lcid, DECIMAL *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromDisp")]
		public static extern HRESULT VarDecFromDisp(IDispatch pdispIn, LCID lcid, out DECIMAL pdecOut);

		/// <summary>Converts the default property of an IDispatch instance to a decimal value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromdisp HRESULT VarDecFromDisp( IDispatch *pdispIn,
		// LCID lcid, DECIMAL *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromDisp")]
		public static extern HRESULT VarDecFromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out DECIMAL pdecOut);

		/// <summary>Converts a char value to a decimal value.</summary>
		/// <param name="cIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromi1 HRESULT VarDecFromI1( CHAR cIn, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromI1")]
		public static extern HRESULT VarDecFromI1(sbyte cIn, out DECIMAL pdecOut);

		/// <summary>Converts a short value to a decimal value.</summary>
		/// <param name="uiIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromi2 HRESULT VarDecFromI2( SHORT uiIn, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromI2")]
		public static extern HRESULT VarDecFromI2(short uiIn, out DECIMAL pdecOut);

		/// <summary>Converts a long value to a decimal value.</summary>
		/// <param name="lIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromi4 HRESULT VarDecFromI4( LONG lIn, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromI4")]
		public static extern HRESULT VarDecFromI4(int lIn, out DECIMAL pdecOut);

		/// <summary>Converts an 8-byte integer value to a decimal value.</summary>
		/// <param name="i64In">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromi8 HRESULT VarDecFromI8( LONG64 i64In, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromI8")]
		public static extern HRESULT VarDecFromI8(long i64In, out DECIMAL pdecOut);

		/// <summary>Converts a float value to a decimal value.</summary>
		/// <param name="fltIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromr4 HRESULT VarDecFromR4( FLOAT fltIn, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromR4")]
		public static extern HRESULT VarDecFromR4(float fltIn, out DECIMAL pdecOut);

		/// <summary>Converts a double value to a decimal value.</summary>
		/// <param name="dblIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromr8 HRESULT VarDecFromR8( DOUBLE dblIn, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromR8")]
		public static extern HRESULT VarDecFromR8(double dblIn, out DECIMAL pdecOut);

		/// <summary>Converts an OLECHAR string to a decimal value.</summary>
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
		/// <term>LOCALE_NOUSEROVERRIDE</term>
		/// <term>Uses the system default locale settings, rather than custom locale settings.</term>
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
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromstr HRESULT VarDecFromStr( LPCOLESTR strIn, LCID
		// lcid, ULONG dwFlags, DECIMAL *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromStr")]
		public static extern HRESULT VarDecFromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out DECIMAL pdecOut);

		/// <summary>Converts an unsigned char value to a decimal value.</summary>
		/// <param name="bIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromui1 HRESULT VarDecFromUI1( BYTE bIn, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromUI1")]
		public static extern HRESULT VarDecFromUI1(byte bIn, out DECIMAL pdecOut);

		/// <summary>Converts an unsigned short value to a decimal value.</summary>
		/// <param name="uiIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromui2 HRESULT VarDecFromUI2( USHORT uiIn, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromUI2")]
		public static extern HRESULT VarDecFromUI2(ushort uiIn, out DECIMAL pdecOut);

		/// <summary>Converts an unsigned long value to a decimal value.</summary>
		/// <param name="ulIn">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromui4 HRESULT VarDecFromUI4( ULONG ulIn, DECIMAL
		// *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromUI4")]
		public static extern HRESULT VarDecFromUI4(uint ulIn, out DECIMAL pdecOut);

		/// <summary>Converts an 8-byte unsigned integer value to a decimal value.</summary>
		/// <param name="ui64In">The value to convert.</param>
		/// <param name="pdecOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecfromui8 HRESULT VarDecFromUI8( ULONG64 ui64In,
		// DECIMAL *pdecOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecFromUI8")]
		public static extern HRESULT VarDecFromUI8(ulong ui64In, out DECIMAL pdecOut);

		/// <summary>Retrieves the integer portion of a variant of type decimal.</summary>
		/// <param name="pdecIn">The decimal variant.</param>
		/// <param name="pdecResult">
		/// The resulting variant. If the variant is negative, then the first negative integer less than or equal to the variant is returned.
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecint HRESULT VarDecInt( LPDECIMAL pdecIn, LPDECIMAL
		// pdecResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecInt")]
		public static extern HRESULT VarDecInt(in DECIMAL pdecIn, out DECIMAL pdecResult);

		/// <summary>Multiplies two variants of type decimal.</summary>
		/// <param name="pdecLeft">The first variant.</param>
		/// <param name="pdecRight">The second variant.</param>
		/// <param name="pdecResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecmul HRESULT VarDecMul( LPDECIMAL pdecLeft, LPDECIMAL
		// pdecRight, LPDECIMAL pdecResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecMul")]
		public static extern HRESULT VarDecMul(in DECIMAL pdecLeft, in DECIMAL pdecRight, out DECIMAL pdecResult);

		/// <summary>Performs logical negation on a variant of type decimal.</summary>
		/// <param name="pdecIn">The variant to negate.</param>
		/// <param name="pdecResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecneg HRESULT VarDecNeg( LPDECIMAL pdecIn, LPDECIMAL
		// pdecResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecNeg")]
		public static extern HRESULT VarDecNeg(in DECIMAL pdecIn, out DECIMAL pdecResult);

		/// <summary>Rounds a variant of type decimal to the specified number of decimal places.</summary>
		/// <param name="pdecIn">The variant to round.</param>
		/// <param name="cDecimals">The number of decimal places.</param>
		/// <param name="pdecResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecround HRESULT VarDecRound( LPDECIMAL pdecIn, int
		// cDecimals, LPDECIMAL pdecResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecRound")]
		public static extern HRESULT VarDecRound(in DECIMAL pdecIn, int cDecimals, out DECIMAL pdecResult);

		/// <summary>Subtracts two variants of type decimal.</summary>
		/// <param name="pdecLeft">The first variant.</param>
		/// <param name="pdecRight">The second variant.</param>
		/// <param name="pdecResult">The resulting variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vardecsub HRESULT VarDecSub( LPDECIMAL pdecLeft, LPDECIMAL
		// pdecRight, LPDECIMAL pdecResult );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarDecSub")]
		public static extern HRESULT VarDecSub(in DECIMAL pdecLeft, in DECIMAL pdecRight, out DECIMAL pdecResult);

		/// <summary>Formats a variant containing currency values into a string form.</summary>
		/// <param name="pvarIn">The variant.</param>
		/// <param name="iNumDig">The number of digits to pad to after the decimal point. Specify -1 to use the system default value.</param>
		/// <param name="iIncLead">
		/// <para>Specifies whether to include the leading digit on numbers.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-2</term>
		/// <term>Use the system default.</term>
		/// </item>
		/// <item>
		/// <term>-1</term>
		/// <term>Include the leading digit.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>Do not include the leading digit.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="iUseParens">
		/// <para>Specifies whether negative numbers should use parentheses.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-2</term>
		/// <term>Use the system default.</term>
		/// </item>
		/// <item>
		/// <term>-1</term>
		/// <term>Use parentheses.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>Do not use parentheses.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="iGroup">
		/// <para>Specifies whether thousands should be grouped. For example 10,000 versus 10000.</para>
		/// <para><c>Note</c> Regular numbers and currencies have separate system defaults for all the above options.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-2</term>
		/// <term>Use the system default.</term>
		/// </item>
		/// <item>
		/// <term>-1</term>
		/// <term>Group thousands.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>Do not group thousands.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlags">VAR_CALENDAR_HIJRI is the only flag that can be set.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varformatcurrency HRESULT VarFormatCurrency( LPVARIANT
		// pvarIn, int iNumDig, int iIncLead, int iUseParens, int iGroup, ULONG dwFlags, BSTR *pbstrOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarFormatCurrency")]
		public static extern HRESULT VarFormatCurrency(in VARIANT pvarIn, int iNumDig, int iIncLead, int iUseParens, int iGroup, VarFlags dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

		/// <summary>Formats a variant containing named date and time information into a string.</summary>
		/// <param name="pvarIn">The variant containing the value to format.</param>
		/// <param name="iNamedFormat">
		/// <para>The named date formats are as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>General date</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Long date</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Short date</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Long time</term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>Short time</term>
		/// </item>
		/// </list>
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
		/// <remarks>This function uses the user's default locale while calling VarTokenizeFormatString and VarFormatFromTokens.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varformatdatetime HRESULT VarFormatDateTime( LPVARIANT
		// pvarIn, int iNamedFormat, ULONG dwFlags, BSTR *pbstrOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarFormatDateTime")]
		public static extern HRESULT VarFormatDateTime(in VARIANT pvarIn, int iNamedFormat, VarFlags dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

		/// <summary>Takes a tokenized format string and applies it to a variant to produce a formatted output string.</summary>
		/// <param name="pvarIn">The variant containing the value to format.</param>
		/// <param name="pstrFormat">The original format string.</param>
		/// <param name="pbTokCur">The tokenized format string from VarTokenizeFormatString.</param>
		/// <param name="dwFlags">The only flags that can be set are VAR_CALENDAR_HIJRI or VAR_FORMAT_NOSUBSTITUTE.</param>
		/// <param name="pbstrOut">The formatted output string.</param>
		/// <param name="lcid">The locale to use for the formatted output string.</param>
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
		/// <term>E_INVALIDARG</term>
		/// <term>One or more of the arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_TYPEMISMATCH</term>
		/// <term>The argument could not be coerced to the specified type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The locale lcid controls the formatted output string.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varformatfromtokens HRESULT VarFormatFromTokens( LPVARIANT
		// pvarIn, LPOLESTR pstrFormat, LPBYTE pbTokCur, ULONG dwFlags, BSTR *pbstrOut, LCID lcid );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarFormatFromTokens")]
		public static extern HRESULT VarFormatFromTokens(in VARIANT pvarIn, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pstrFormat,
			[In] IntPtr pbTokCur, VarFlags dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut, LCID lcid);

		/// <summary>Formats a variant containing numbers into a string form.</summary>
		/// <param name="pvarIn">The variant containing the value to format.</param>
		/// <param name="iNumDig">The number of digits to pad to after the decimal point. Specify -1 to use the system default value.</param>
		/// <param name="iIncLead">
		/// <para>Specifies whether to include the leading digit on numbers.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-2</term>
		/// <term>Use the system default.</term>
		/// </item>
		/// <item>
		/// <term>-1</term>
		/// <term>Include the leading digit.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>Do not include the leading digit.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="iUseParens">
		/// <para>Specifies whether negative numbers should use parentheses.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-2</term>
		/// <term>Use the system default.</term>
		/// </item>
		/// <item>
		/// <term>-1</term>
		/// <term>Use parentheses.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>Do not use parentheses.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="iGroup">
		/// <para>Specifies whether thousands should be grouped. For example 10,000 versus 10000.</para>
		/// <para><c>Note</c> Regular numbers and currencies have separate system defaults for all the above options.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-2</term>
		/// <term>Use the system default.</term>
		/// </item>
		/// <item>
		/// <term>-1</term>
		/// <term>Group thousands.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>Do not group thousands.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlags">VAR_CALENDAR_HIJRI is the only flag that can be set.</param>
		/// <param name="pbstrOut">Points to the formatted string that represents the variant.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varformatnumber HRESULT VarFormatNumber( LPVARIANT pvarIn,
		// int iNumDig, int iIncLead, int iUseParens, int iGroup, ULONG dwFlags, BSTR *pbstrOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarFormatNumber")]
		public static extern HRESULT VarFormatNumber(in VARIANT pvarIn, int iNumDig, int iIncLead, int iUseParens, int iGroup, VarFlags dwFlags,
			[MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

		/// <summary>Formats a variant containing percentages into a string form.</summary>
		/// <param name="pvarIn">The variant containing the value to format.</param>
		/// <param name="iNumDig">The number of digits to pad to after the decimal point. Specify -1 to use the system default value.</param>
		/// <param name="iIncLead">
		/// <para>Specifies whether to include the leading digit on numbers.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-2</term>
		/// <term>Use the system default.</term>
		/// </item>
		/// <item>
		/// <term>-1</term>
		/// <term>Include the leading digit.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>Do not include the leading digit.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="iUseParens">
		/// <para>Specifies whether negative numbers should use parentheses.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-2</term>
		/// <term>Use the system default.</term>
		/// </item>
		/// <item>
		/// <term>-1</term>
		/// <term>Use parentheses.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>Do not use parentheses.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="iGroup">
		/// <para>Specifies whether thousands should be grouped. For example 10,000 versus 10000.</para>
		/// <para><c>Note</c> Regular numbers and currencies have separate system defaults for all the above options.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-2</term>
		/// <term>Use the system default.</term>
		/// </item>
		/// <item>
		/// <term>-1</term>
		/// <term>Group thousands.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>Do not group thousands.</term>
		/// </item>
		/// </list>
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
		/// <remarks>This function uses the user's default locale while calling VarTokenizeFormatString and VarFormatFromTokens.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varformatpercent HRESULT VarFormatPercent( LPVARIANT
		// pvarIn, int iNumDig, int iIncLead, int iUseParens, int iGroup, ULONG dwFlags, BSTR *pbstrOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarFormatPercent")]
		public static extern HRESULT VarFormatPercent(in VARIANT pvarIn, int iNumDig, int iIncLead, int iUseParens, int iGroup,
			VarFlags dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);
	}
}