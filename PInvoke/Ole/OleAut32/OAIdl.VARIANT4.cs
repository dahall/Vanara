using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class OleAut32
{
	/// <summary>Converts a Boolean value to an 8-byte integer value.</summary>
	/// <param name="boolIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8frombool HRESULT VarI8FromBool( VARIANT_BOOL boolIn,
	// LONG64 *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromBool")]
	public static extern HRESULT VarI8FromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out long pi64Out);

	/// <summary>Converts a currency value to an 8-byte integer value.</summary>
	/// <param name="cyIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromcy HRESULT VarI8FromCy( CY cyIn, LONG64 *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromCy")]
	public static extern HRESULT VarI8FromCy(CY cyIn, out long pi64Out);

	/// <summary>Converts a date value to an 8-byte integer value.</summary>
	/// <param name="dateIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromdate HRESULT VarI8FromDate( DATE dateIn, LONG64
	// *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromDate")]
	public static extern HRESULT VarI8FromDate(DATE dateIn, out long pi64Out);

	/// <summary>Converts a decimal value to an 8-byte integer value.</summary>
	/// <param name="pdecIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromdec HRESULT VarI8FromDec( const DECIMAL *pdecIn,
	// LONG64 *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromDec")]
	public static extern HRESULT VarI8FromDec(in DECIMAL pdecIn, out long pi64Out);

	/// <summary>Converts the default property of an IDispatch instance to an 8-byte integer value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromdisp HRESULT VarI8FromDisp( IDispatch *pdispIn,
	// LCID lcid, LONG64 *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromDisp")]
	public static extern HRESULT VarI8FromDisp([In] IDispatch pdispIn, LCID lcid, out long pi64Out);

	/// <summary>Converts the default property of an IDispatch instance to an 8-byte integer value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromdisp HRESULT VarI8FromDisp( IDispatch *pdispIn,
	// LCID lcid, LONG64 *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromDisp")]
	public static extern HRESULT VarI8FromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out long pi64Out);

	/// <summary>Converts a char value to an 8-byte integer value.</summary>
	/// <param name="cIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromi1 HRESULT VarI8FromI1( CHAR cIn, LONG64 *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromI1")]
	public static extern HRESULT VarI8FromI1(sbyte cIn, out long pi64Out);

	/// <summary>Converts a short value to an 8-byte integer value.</summary>
	/// <param name="sIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromi2 HRESULT VarI8FromI2( SHORT sIn, LONG64 *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromI2")]
	public static extern HRESULT VarI8FromI2(short sIn, out long pi64Out);

	/// <summary>Converts a float value to an 8-byte integer value.</summary>
	/// <param name="fltIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromr4 HRESULT VarI8FromR4( FLOAT fltIn, LONG64
	// *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromR4")]
	public static extern HRESULT VarI8FromR4(float fltIn, out long pi64Out);

	/// <summary>Converts a double value to an 8-byte integer value.</summary>
	/// <param name="dblIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromr8 HRESULT VarI8FromR8( DOUBLE dblIn, LONG64
	// *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromR8")]
	public static extern HRESULT VarI8FromR8(double dblIn, out long pi64Out);

	/// <summary>Converts an OLECHAR string to an 8-byte integer value.</summary>
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
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromstr HRESULT VarI8FromStr( LPCOLESTR strIn, LCID
	// lcid, ULONG dwFlags, LONG64 *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromStr")]
	public static extern HRESULT VarI8FromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out long pi64Out);

	/// <summary>Converts an unsigned byte value to an 8-byte integer value.</summary>
	/// <param name="bIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromui1 HRESULT VarI8FromUI1( BYTE bIn, LONG64
	// *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromUI1")]
	public static extern HRESULT VarI8FromUI1(byte bIn, out long pi64Out);

	/// <summary>Converts an unsigned short value to an 8-byte integer value.</summary>
	/// <param name="uiIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromui2 HRESULT VarI8FromUI2( USHORT uiIn, LONG64
	// *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromUI2")]
	public static extern HRESULT VarI8FromUI2(ushort uiIn, out long pi64Out);

	/// <summary>Converts an unsigned long value to an 8-byte integer value.</summary>
	/// <param name="ulIn">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromui4 HRESULT VarI8FromUI4( ULONG ulIn, LONG64
	// *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromUI4")]
	public static extern HRESULT VarI8FromUI4(uint ulIn, out long pi64Out);

	/// <summary>Converts an unsigned 8-byte integer value to an 8-byte integer value.</summary>
	/// <param name="ui64In">The value to convert.</param>
	/// <param name="pi64Out">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-vari8fromui8 HRESULT VarI8FromUI8( ULONG64 ui64In, LONG64
	// *pi64Out );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarI8FromUI8")]
	public static extern HRESULT VarI8FromUI8(ulong ui64In, out long pi64Out);

	/// <summary>Compares two variants of types float and double.</summary>
	/// <param name="fltLeft">The first variant.</param>
	/// <param name="dblRight">The second variant.</param>
	/// <returns>
	/// <para>The function returns the following as a SUCCESS HRESULT.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>fltLeft is less than dblRight.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>The two parameters are equal.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>fltLeft is greater than dblRight.</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Either expression is NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4cmpr8 HRESULT VarR4CmpR8( float fltLeft, double
	// dblRight );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4CmpR8")]
	public static extern HRESULT VarR4CmpR8(float fltLeft, double dblRight);

	/// <summary>Converts a Boolean value to a float value.</summary>
	/// <param name="boolIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4frombool HRESULT VarR4FromBool( VARIANT_BOOL boolIn,
	// FLOAT *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromBool")]
	public static extern HRESULT VarR4FromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out float pfltOut);

	/// <summary>Converts a currency value to a float value.</summary>
	/// <param name="cyIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromcy HRESULT VarR4FromCy( CY cyIn, FLOAT *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromCy")]
	public static extern HRESULT VarR4FromCy(CY cyIn, out float pfltOut);

	/// <summary>Converts a date value to a float value.</summary>
	/// <param name="dateIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromdate HRESULT VarR4FromDate( DATE dateIn, FLOAT
	// *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromDate")]
	public static extern HRESULT VarR4FromDate(DATE dateIn, out float pfltOut);

	/// <summary>Converts a decimal value to a float value.</summary>
	/// <param name="pdecIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromdec HRESULT VarR4FromDec( const DECIMAL *pdecIn,
	// FLOAT *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromDec")]
	public static extern HRESULT VarR4FromDec(in DECIMAL pdecIn, out float pfltOut);

	/// <summary>Converts the default property of an IDispatch instance to a float value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromdisp HRESULT VarR4FromDisp( IDispatch *pdispIn,
	// LCID lcid, FLOAT *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromDisp")]
	public static extern HRESULT VarR4FromDisp([In] IDispatch pdispIn, LCID lcid, out float pfltOut);

	/// <summary>Converts the default property of an IDispatch instance to a float value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromdisp HRESULT VarR4FromDisp( IDispatch *pdispIn,
	// LCID lcid, FLOAT *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromDisp")]
	public static extern HRESULT VarR4FromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out float pfltOut);

	/// <summary>Converts a char value to a float value.</summary>
	/// <param name="cIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromi1 HRESULT VarR4FromI1( CHAR cIn, FLOAT *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromI1")]
	public static extern HRESULT VarR4FromI1(sbyte cIn, out float pfltOut);

	/// <summary>Converts a short value to a float value.</summary>
	/// <param name="sIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromi2 HRESULT VarR4FromI2( SHORT sIn, FLOAT *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromI2")]
	public static extern HRESULT VarR4FromI2(short sIn, out float pfltOut);

	/// <summary>Converts a long value to a float value.</summary>
	/// <param name="lIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromi4 HRESULT VarR4FromI4( LONG lIn, FLOAT *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromI4")]
	public static extern HRESULT VarR4FromI4(int lIn, out float pfltOut);

	/// <summary>Converts an 8-byte integer value to a float value.</summary>
	/// <param name="i64In">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromi8 HRESULT VarR4FromI8( LONG64 i64In, FLOAT
	// *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromI8")]
	public static extern HRESULT VarR4FromI8(long i64In, out float pfltOut);

	/// <summary>Converts a double value to a float value.</summary>
	/// <param name="dblIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromr8 HRESULT VarR4FromR8( DOUBLE dblIn, FLOAT
	// *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromR8")]
	public static extern HRESULT VarR4FromR8(double dblIn, out float pfltOut);

	/// <summary>Converts an OLECHAR string to a float value.</summary>
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
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromstr HRESULT VarR4FromStr( LPCOLESTR strIn, LCID
	// lcid, ULONG dwFlags, FLOAT *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromStr")]
	public static extern HRESULT VarR4FromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out float pfltOut);

	/// <summary>Converts an unsigned char value to a float value.</summary>
	/// <param name="bIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromui1 HRESULT VarR4FromUI1( BYTE bIn, FLOAT *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromUI1")]
	public static extern HRESULT VarR4FromUI1(byte bIn, out float pfltOut);

	/// <summary>Converts an unsigned short value to a float value.</summary>
	/// <param name="uiIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromui2 HRESULT VarR4FromUI2( USHORT uiIn, FLOAT
	// *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromUI2")]
	public static extern HRESULT VarR4FromUI2(ushort uiIn, out float pfltOut);

	/// <summary>Converts an unsigned long value to a float value.</summary>
	/// <param name="ulIn">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromui4 HRESULT VarR4FromUI4( ULONG ulIn, FLOAT
	// *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromUI4")]
	public static extern HRESULT VarR4FromUI4(uint ulIn, out float pfltOut);

	/// <summary>Converts an unsigned 8-byte integer value to a float value.</summary>
	/// <param name="ui64In">The value to convert.</param>
	/// <param name="pfltOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr4fromui8 HRESULT VarR4FromUI8( ULONG64 ui64In, FLOAT
	// *pfltOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR4FromUI8")]
	public static extern HRESULT VarR4FromUI8(ulong ui64In, out float pfltOut);

	/// <summary>Converts a Boolean value to a double value.</summary>
	/// <param name="boolIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8frombool HRESULT VarR8FromBool( VARIANT_BOOL boolIn,
	// DOUBLE *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromBool")]
	public static extern HRESULT VarR8FromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out double pdblOut);

	/// <summary>Converts a currency value to a double value.</summary>
	/// <param name="cyIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromcy HRESULT VarR8FromCy( CY cyIn, DOUBLE *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromCy")]
	public static extern HRESULT VarR8FromCy(CY cyIn, out double pdblOut);

	/// <summary>Converts a date value to a double value.</summary>
	/// <param name="dateIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromdate HRESULT VarR8FromDate( DATE dateIn, DOUBLE
	// *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromDate")]
	public static extern HRESULT VarR8FromDate(DATE dateIn, out double pdblOut);

	/// <summary>Converts a decimal value to a double value.</summary>
	/// <param name="pdecIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromdec HRESULT VarR8FromDec( const DECIMAL *pdecIn,
	// DOUBLE *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromDec")]
	public static extern HRESULT VarR8FromDec(in DECIMAL pdecIn, out double pdblOut);

	/// <summary>Converts the default property of an IDispatch instance to a double value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromdisp HRESULT VarR8FromDisp( IDispatch *pdispIn,
	// LCID lcid, DOUBLE *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromDisp")]
	public static extern HRESULT VarR8FromDisp([In] IDispatch pdispIn, LCID lcid, out double pdblOut);

	/// <summary>Converts the default property of an IDispatch instance to a double value.</summary>
	/// <param name="pdispIn">The value to convert.</param>
	/// <param name="lcid">The locale identifier.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromdisp HRESULT VarR8FromDisp( IDispatch *pdispIn,
	// LCID lcid, DOUBLE *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromDisp")]
	public static extern HRESULT VarR8FromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out double pdblOut);

	/// <summary>Converts a char value to a double value.</summary>
	/// <param name="cIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromi1 HRESULT VarR8FromI1( CHAR cIn, DOUBLE *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromI1")]
	public static extern HRESULT VarR8FromI1(sbyte cIn, out double pdblOut);

	/// <summary>Converts a short value to a double value.</summary>
	/// <param name="sIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromi2 HRESULT VarR8FromI2( SHORT sIn, DOUBLE *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromI2")]
	public static extern HRESULT VarR8FromI2(short sIn, out double pdblOut);

	/// <summary>Converts a long value to a double value.</summary>
	/// <param name="lIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromi4 HRESULT VarR8FromI4( LONG lIn, DOUBLE *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromI4")]
	public static extern HRESULT VarR8FromI4(int lIn, out double pdblOut);

	/// <summary>Converts an 8-byte integer value to a double value.</summary>
	/// <param name="i64In">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromi8 HRESULT VarR8FromI8( LONG64 i64In, DOUBLE
	// *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromI8")]
	public static extern HRESULT VarR8FromI8(long i64In, out double pdblOut);

	/// <summary>Converts a float value to a double value.</summary>
	/// <param name="fltIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromr4 HRESULT VarR8FromR4( FLOAT fltIn, DOUBLE
	// *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromR4")]
	public static extern HRESULT VarR8FromR4(float fltIn, out double pdblOut);

	/// <summary>Converts an OLECHAR string to a double value.</summary>
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
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromstr HRESULT VarR8FromStr( LPCOLESTR strIn, LCID
	// lcid, ULONG dwFlags, DOUBLE *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromStr")]
	public static extern HRESULT VarR8FromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out double pdblOut);

	/// <summary>Converts an unsigned char value to a double value.</summary>
	/// <param name="bIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromui1 HRESULT VarR8FromUI1( BYTE bIn, DOUBLE
	// *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromUI1")]
	public static extern HRESULT VarR8FromUI1(byte bIn, out double pdblOut);

	/// <summary>Converts an unsigned short value to a double value.</summary>
	/// <param name="uiIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromui2 HRESULT VarR8FromUI2( USHORT uiIn, DOUBLE
	// *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromUI2")]
	public static extern HRESULT VarR8FromUI2(ushort uiIn, out double pdblOut);

	/// <summary>Converts an unsigned long value to a double value.</summary>
	/// <param name="ulIn">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromui4 HRESULT VarR8FromUI4( ULONG ulIn, DOUBLE
	// *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromUI4")]
	public static extern HRESULT VarR8FromUI4(uint ulIn, out double pdblOut);

	/// <summary>Converts an 8-byte unsigned integer value to a double value.</summary>
	/// <param name="ui64In">The value to convert.</param>
	/// <param name="pdblOut">The resulting value.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8fromui8 HRESULT VarR8FromUI8( ULONG64 ui64In, DOUBLE
	// *pdblOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8FromUI8")]
	public static extern HRESULT VarR8FromUI8(ulong ui64In, out double pdblOut);

	/// <summary>Performs the power function for variants of type double.</summary>
	/// <param name="dblLeft">The first variant.</param>
	/// <param name="dblRight">The second variant.</param>
	/// <param name="pdblResult">The result.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8pow HRESULT VarR8Pow( double dblLeft, double dblRight,
	// double *pdblResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8Pow")]
	public static extern HRESULT VarR8Pow(double dblLeft, double dblRight, out double pdblResult);

	/// <summary>Rounds a variant of type double to the specified number of decimal places.</summary>
	/// <param name="dblIn">The variant.</param>
	/// <param name="cDecimals">The number of decimal places.</param>
	/// <param name="pdblResult">The result.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varr8round HRESULT VarR8Round( double dblIn, int cDecimals,
	// double *pdblResult );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarR8Round")]
	public static extern HRESULT VarR8Round(double dblIn, int cDecimals, out double pdblResult);

	/// <summary>Converts a time and date converted from variant format to MS-DOS format.</summary>
	/// <param name="dateIn">The packed date.</param>
	/// <param name="dwFlags">Set for alternative calendars such as Hijri, Polish and Russian.</param>
	/// <param name="pudateOut">The unpacked date.</param>
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
	/// <para>The UDATE structure is used with VarDateFromUdate and <c>VarUdateFromDate</c>. It represents an "unpacked" date.</para>
	/// <para>
	/// <code>typedef struct { SYSTEMTIME st; USHORT wDayOfYear; } UDATE;</code>
	/// </para>
	/// <para>
	/// The <c>VarUdateFromDate</c> function will accept invalid dates and try to fix them when resolving to a VARIANT time. For
	/// example, an invalid date such as 2/29/2001 will resolve to 3/1/2001. Only days are fixed, so invalid month values result in an
	/// error being returned. Days are checked to be between 1 and 31. Negative days and days greater than 31 results in an error. A day
	/// less than 31 but greater than the maximum day in that month has the day promoted to the appropriate day of the next month. A day
	/// equal to zero resolves as the last day of the previous month. For example, an invalid dates such as 2/0/2001 will resolve to 1/31/2001.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varudatefromdate HRESULT VarUdateFromDate( DATE dateIn,
	// ULONG dwFlags, UDATE *pudateOut );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUdateFromDate")]
	public static extern HRESULT VarUdateFromDate(DATE dateIn, VarFlags dwFlags, out UDATE pudateOut);
}