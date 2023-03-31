using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class OleAut32
{
	/// <summary>Converts a Boolean value to a char value.</summary>
	/// <param name="boolIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1frombool HRESULT VarI1FromBool( VARIANT_BOOL boolIn,
	// CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromBool")]
	public static extern HRESULT VarI1FromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out sbyte pcOut);

	/// <summary>Converts a currency value to a char value.</summary>
	/// <param name="cyIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromcy HRESULT VarI1FromCy( CY cyIn, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromCy")]
	public static extern HRESULT VarI1FromCy(CY cyIn, out sbyte pcOut);

	/// <summary>Converts a date value to a char value.</summary>
	/// <param name="dateIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromdate HRESULT VarI1FromDate( DATE dateIn, CHAR
	// *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromDate")]
	public static extern HRESULT VarI1FromDate(DATE dateIn, out sbyte pcOut);

	/// <summary>Converts a decimal value to a char value.</summary>
	/// <param name="pdecIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromdec HRESULT VarI1FromDec( const DECIMAL *pdecIn,
	// CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromDec")]
	public static extern HRESULT VarI1FromDec(in DECIMAL pdecIn, out sbyte pcOut);

	/// <summary>Converts the default property of an IDispatch instance to a char value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromdisp HRESULT VarI1FromDisp( IDispatch *pdispIn,
	// LCID lcid, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromDisp")]
	public static extern HRESULT VarI1FromDisp([In] IDispatch pdispIn, LCID lcid, out sbyte pcOut);

	/// <summary>Converts the default property of an IDispatch instance to a char value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromdisp HRESULT VarI1FromDisp( IDispatch *pdispIn,
	// LCID lcid, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromDisp")]
	public static extern HRESULT VarI1FromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out sbyte pcOut);

	/// <summary>Converts a short value to a char value.</summary>
	/// <param name="uiIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromi2 HRESULT VarI1FromI2( SHORT uiIn, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromI2")]
	public static extern HRESULT VarI1FromI2(short uiIn, out sbyte pcOut);

	/// <summary>Converts a long value to a char value.</summary>
	/// <param name="lIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromi4 HRESULT VarI1FromI4( LONG lIn, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromI4")]
	public static extern HRESULT VarI1FromI4(int lIn, out sbyte pcOut);

	/// <summary>Converts an 8-byte integer value to a char value.</summary>
	/// <param name="i64In">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromi8 HRESULT VarI1FromI8( LONG64 i64In, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromI8")]
	public static extern HRESULT VarI1FromI8(long i64In, out sbyte pcOut);

	/// <summary>Converts a float value to a char value.</summary>
	/// <param name="fltIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromr4 HRESULT VarI1FromR4( FLOAT fltIn, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromR4")]
	public static extern HRESULT VarI1FromR4(float fltIn, out sbyte pcOut);

	/// <summary>Converts a double value to a char value.</summary>
	/// <param name="dblIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromr8 HRESULT VarI1FromR8( DOUBLE dblIn, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromR8")]
	public static extern HRESULT VarI1FromR8(double dblIn, out sbyte pcOut);

	/// <summary>Converts an OLECHAR string to a char value.</summary>
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
	/// </list>
	/// </param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromstr HRESULT VarI1FromStr( LPCOLESTR strIn, LCID
	// lcid, ULONG dwFlags, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromStr")]
	public static extern HRESULT VarI1FromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out sbyte pcOut);

	/// <summary>Converts an unsigned char value to a char value.</summary>
	/// <param name="bIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromui1 HRESULT VarI1FromUI1( BYTE bIn, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromUI1")]
	public static extern HRESULT VarI1FromUI1(byte bIn, out sbyte pcOut);

	/// <summary>Converts an unsigned short value to a char value.</summary>
	/// <param name="uiIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromui2 HRESULT VarI1FromUI2( USHORT uiIn, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromUI2")]
	public static extern HRESULT VarI1FromUI2(ushort uiIn, out sbyte pcOut);

	/// <summary>Converts an unsigned long value to a char value.</summary>
	/// <param name="ulIn">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromui4 HRESULT VarI1FromUI4( ULONG ulIn, CHAR *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromUI4")]
	public static extern HRESULT VarI1FromUI4(uint ulIn, out sbyte pcOut);

	/// <summary>Converts an 8-byte unsigned integer value to a char value.</summary>
	/// <param name="i64In">The value to convert.</param>
	/// <param name="pcOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari1fromui8 HRESULT VarI1FromUI8( ULONG64 i64In, CHAR
	// *pcOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI1FromUI8")]
	public static extern HRESULT VarI1FromUI8(ulong i64In, out sbyte pcOut);

	/// <summary>Converts a Boolean value to a short value.</summary>
	/// <param name="boolIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2frombool HRESULT VarI2FromBool( VARIANT_BOOL boolIn,
	// SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromBool")]
	public static extern HRESULT VarI2FromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out short psOut);

	/// <summary>Converts a currency value to a short value.</summary>
	/// <param name="cyIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromcy HRESULT VarI2FromCy( CY cyIn, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromCy")]
	public static extern HRESULT VarI2FromCy(CY cyIn, out short psOut);

	/// <summary>Converts a date value to a short value.</summary>
	/// <param name="dateIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromdate HRESULT VarI2FromDate( DATE dateIn, SHORT
	// *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromDate")]
	public static extern HRESULT VarI2FromDate(DATE dateIn, out short psOut);

	/// <summary>Converts a decimal value to a short value.</summary>
	/// <param name="pdecIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromdec HRESULT VarI2FromDec( const DECIMAL *pdecIn,
	// SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromDec")]
	public static extern HRESULT VarI2FromDec(in DECIMAL pdecIn, out short psOut);

	/// <summary>Converts the default property of an IDispatch instance to a short value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromdisp HRESULT VarI2FromDisp( IDispatch *pdispIn,
	// LCID lcid, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromDisp")]
	public static extern HRESULT VarI2FromDisp([In] IDispatch pdispIn, LCID lcid, out short psOut);

	/// <summary>Converts the default property of an IDispatch instance to a short value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromdisp HRESULT VarI2FromDisp( IDispatch *pdispIn,
	// LCID lcid, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromDisp")]
	public static extern HRESULT VarI2FromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out short psOut);

	/// <summary>Converts a char value to a short value.</summary>
	/// <param name="cIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromi1 HRESULT VarI2FromI1( CHAR cIn, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromI1")]
	public static extern HRESULT VarI2FromI1(sbyte cIn, out short psOut);

	/// <summary>Converts a long value to a short value.</summary>
	/// <param name="lIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromi4 HRESULT VarI2FromI4( LONG lIn, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromI4")]
	public static extern HRESULT VarI2FromI4(int lIn, out short psOut);

	/// <summary>Converts an 8-byte integer value to a short value.</summary>
	/// <param name="i64In">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromi8 HRESULT VarI2FromI8( LONG64 i64In, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromI8")]
	public static extern HRESULT VarI2FromI8(long i64In, out short psOut);

	/// <summary>Converts a float value to a short value.</summary>
	/// <param name="fltIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromr4 HRESULT VarI2FromR4( FLOAT fltIn, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromR4")]
	public static extern HRESULT VarI2FromR4(float fltIn, out short psOut);

	/// <summary>Converts a double value to a short value.</summary>
	/// <param name="dblIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromr8 HRESULT VarI2FromR8( DOUBLE dblIn, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromR8")]
	public static extern HRESULT VarI2FromR8(double dblIn, out short psOut);

	/// <summary>Converts an OLECHAR string to a short value.</summary>
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
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromstr HRESULT VarI2FromStr( LPCOLESTR strIn, LCID
	// lcid, ULONG dwFlags, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromStr")]
	public static extern HRESULT VarI2FromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out short psOut);

	/// <summary>Converts an unsigned char value to a short value.</summary>
	/// <param name="bIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromui1 HRESULT VarI2FromUI1( BYTE bIn, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromUI1")]
	public static extern HRESULT VarI2FromUI1(byte bIn, out short psOut);

	/// <summary>Converts an unsigned short value to a short value.</summary>
	/// <param name="uiIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromui2 HRESULT VarI2FromUI2( USHORT uiIn, SHORT
	// *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromUI2")]
	public static extern HRESULT VarI2FromUI2(ushort uiIn, out short psOut);

	/// <summary>Converts an unsigned long value to a short value.</summary>
	/// <param name="ulIn">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromui4 HRESULT VarI2FromUI4( ULONG ulIn, SHORT *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromUI4")]
	public static extern HRESULT VarI2FromUI4(uint ulIn, out short psOut);

	/// <summary>Converts an 8-byte unsigned integer value to a short value.</summary>
	/// <param name="ui64In">The value to convert.</param>
	/// <param name="psOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari2fromui8 HRESULT VarI2FromUI8( ULONG64 ui64In, SHORT
	// *psOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI2FromUI8")]
	public static extern HRESULT VarI2FromUI8(ulong ui64In, out short psOut);

	/// <summary>Converts a Boolean value to a long value.</summary>
	/// <param name="boolIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4frombool HRESULT VarI4FromBool( VARIANT_BOOL boolIn,
	// LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromBool")]
	public static extern HRESULT VarI4FromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out int plOut);

	/// <summary>Converts a currency value to a long value.</summary>
	/// <param name="cyIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromcy HRESULT VarI4FromCy( CY cyIn, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromCy")]
	public static extern HRESULT VarI4FromCy(CY cyIn, out int plOut);

	/// <summary>Converts a date value to a long value.</summary>
	/// <param name="dateIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromdate HRESULT VarI4FromDate( DATE dateIn, LONG
	// *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromDate")]
	public static extern HRESULT VarI4FromDate(DATE dateIn, out int plOut);

	/// <summary>Converts a decimal value to a long value.</summary>
	/// <param name="pdecIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromdec HRESULT VarI4FromDec( const DECIMAL *pdecIn,
	// LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromDec")]
	public static extern HRESULT VarI4FromDec(in DECIMAL pdecIn, out int plOut);

	/// <summary>Converts the default property of an IDispatch instance to a long value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromdisp HRESULT VarI4FromDisp( IDispatch *pdispIn,
	// LCID lcid, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromDisp")]
	public static extern HRESULT VarI4FromDisp([In] IDispatch pdispIn, LCID lcid, out int plOut);

	/// <summary>Converts the default property of an IDispatch instance to a long value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromdisp HRESULT VarI4FromDisp( IDispatch *pdispIn,
	// LCID lcid, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromDisp")]
	public static extern HRESULT VarI4FromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out int plOut);

	/// <summary>Converts a char value to a long value.</summary>
	/// <param name="cIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromi1 HRESULT VarI4FromI1( CHAR cIn, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromI1")]
	public static extern HRESULT VarI4FromI1(sbyte cIn, out int plOut);

	/// <summary>Converts a short value to a long value.</summary>
	/// <param name="sIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromi2 HRESULT VarI4FromI2( SHORT sIn, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromI2")]
	public static extern HRESULT VarI4FromI2(short sIn, out int plOut);

	/// <summary>Converts an int value to a long value.</summary>
	/// <param name="lIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromi4 void VarI4FromI4( in, pOut );
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromI4")]
	public static void VarI4FromI4(int lIn, out int plOut) => plOut = lIn;

	/// <summary>Converts an 8-byte integer value to a long value.</summary>
	/// <param name="i64In">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromi8 HRESULT VarI4FromI8( LONG64 i64In, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromI8")]
	public static extern HRESULT VarI4FromI8(long i64In, out int plOut);

	/// <summary>Converts a float value to a long value.</summary>
	/// <param name="fltIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromr4 HRESULT VarI4FromR4( FLOAT fltIn, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromR4")]
	public static extern HRESULT VarI4FromR4(float fltIn, out int plOut);

	/// <summary>Converts a double value to a long value.</summary>
	/// <param name="dblIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromr8 HRESULT VarI4FromR8( DOUBLE dblIn, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromR8")]
	public static extern HRESULT VarI4FromR8(double dblIn, out int plOut);

	/// <summary>Converts an OLECHAR string to a long value.</summary>
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
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromstr HRESULT VarI4FromStr( LPCOLESTR strIn, LCID
	// lcid, ULONG dwFlags, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromStr")]
	public static extern HRESULT VarI4FromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out int plOut);

	/// <summary>Converts an unsigned char value to a long value.</summary>
	/// <param name="bIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromui1 HRESULT VarI4FromUI1( BYTE bIn, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromUI1")]
	public static extern HRESULT VarI4FromUI1(byte bIn, out int plOut);

	/// <summary>Converts an unsigned short value to a long value.</summary>
	/// <param name="uiIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromui2 HRESULT VarI4FromUI2( USHORT uiIn, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromUI2")]
	public static extern HRESULT VarI4FromUI2(ushort uiIn, out int plOut);

	/// <summary>Converts an unsigned long value to a long value.</summary>
	/// <param name="ulIn">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromui4 HRESULT VarI4FromUI4( ULONG ulIn, LONG *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromUI4")]
	public static extern HRESULT VarI4FromUI4(uint ulIn, out int plOut);

	/// <summary>Converts an 8-byte unsigned integer value to a long.</summary>
	/// <param name="ui64In">The value to convert.</param>
	/// <param name="plOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari4fromui8 HRESULT VarI4FromUI8( ULONG64 ui64In, LONG
	// *plOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI4FromUI8")]
	public static extern HRESULT VarI4FromUI8(ulong ui64In, out int plOut);
}