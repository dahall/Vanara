using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class OleAut32
	{
		/// <summary>Converts a Boolean value to an unsigned char value.</summary>
		/// <param name="boolIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1frombool HRESULT VarUI1FromBool( VARIANT_BOOL boolIn,
		// BYTE *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromBool")]
		public static extern HRESULT VarUI1FromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out byte pbOut);

		/// <summary>Converts a currency value to an unsigned char value.</summary>
		/// <param name="cyIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromcy HRESULT VarUI1FromCy( CY cyIn, BYTE *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromCy")]
		public static extern HRESULT VarUI1FromCy(CY cyIn, out byte pbOut);

		/// <summary>Converts a date value to an unsigned char value.</summary>
		/// <param name="dateIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromdate HRESULT VarUI1FromDate( DATE dateIn, BYTE
		// *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromDate")]
		public static extern HRESULT VarUI1FromDate(DATE dateIn, out byte pbOut);

		/// <summary>Converts a decimal value to an unsigned char value.</summary>
		/// <param name="pdecIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromdec HRESULT VarUI1FromDec( const DECIMAL *pdecIn,
		// BYTE *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromDec")]
		public static extern HRESULT VarUI1FromDec(in DECIMAL pdecIn, out byte pbOut);

		/// <summary>Converts the default property of an IDispatch instance to an unsigned char value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromdisp HRESULT VarUI1FromDisp( IDispatch *pdispIn,
		// LCID lcid, BYTE *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromDisp")]
		public static extern HRESULT VarUI1FromDisp([In] IDispatch pdispIn, LCID lcid, out byte pbOut);

		/// <summary>Converts the default property of an IDispatch instance to an unsigned char value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromdisp HRESULT VarUI1FromDisp( IDispatch *pdispIn,
		// LCID lcid, BYTE *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromDisp")]
		public static extern HRESULT VarUI1FromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out byte pbOut);

		/// <summary>Converts a char value to an unsigned char value.</summary>
		/// <param name="cIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromi1 HRESULT VarUI1FromI1( CHAR cIn, BYTE *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromI1")]
		public static extern HRESULT VarUI1FromI1(sbyte cIn, out byte pbOut);

		/// <summary>Converts a short value to an unsigned char value.</summary>
		/// <param name="sIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromi2 HRESULT VarUI1FromI2( SHORT sIn, BYTE *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromI2")]
		public static extern HRESULT VarUI1FromI2(short sIn, out byte pbOut);

		/// <summary>Converts a long value to an unsigned char value.</summary>
		/// <param name="lIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromi4 HRESULT VarUI1FromI4( LONG lIn, BYTE *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromI4")]
		public static extern HRESULT VarUI1FromI4(int lIn, out byte pbOut);

		/// <summary>Converts an 8-byte integer value to a byte value.</summary>
		/// <param name="i64In">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromi8 HRESULT VarUI1FromI8( LONG64 i64In, BYTE
		// *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromI8")]
		public static extern HRESULT VarUI1FromI8(long i64In, out byte pbOut);

		/// <summary>Converts a float value to an unsigned char value.</summary>
		/// <param name="fltIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromr4 HRESULT VarUI1FromR4( FLOAT fltIn, BYTE *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromR4")]
		public static extern HRESULT VarUI1FromR4(float fltIn, out byte pbOut);

		/// <summary>Converts a double value to an unsigned char value.</summary>
		/// <param name="dblIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromr8 HRESULT VarUI1FromR8( DOUBLE dblIn, BYTE
		// *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromR8")]
		public static extern HRESULT VarUI1FromR8(double dblIn, out byte pbOut);

		/// <summary>Converts an OLECHAR string to an unsigned char string.</summary>
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
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromstr HRESULT VarUI1FromStr( LPCOLESTR strIn, LCID
		// lcid, ULONG dwFlags, BYTE *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromStr")]
		public static extern HRESULT VarUI1FromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out byte pbOut);

		/// <summary>Converts an unsigned short value to an unsigned char value.</summary>
		/// <param name="uiIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromui2 HRESULT VarUI1FromUI2( USHORT uiIn, BYTE
		// *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromUI2")]
		public static extern HRESULT VarUI1FromUI2(ushort uiIn, out byte pbOut);

		/// <summary>Converts an unsigned long value to an unsigned char value.</summary>
		/// <param name="ulIn">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromui4 HRESULT VarUI1FromUI4( ULONG ulIn, BYTE
		// *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromUI4")]
		public static extern HRESULT VarUI1FromUI4(uint ulIn, out byte pbOut);

		/// <summary>Converts an 8-byte unsigned integer value to a byte value.</summary>
		/// <param name="ui64In">The value to convert.</param>
		/// <param name="pbOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui1fromui8 HRESULT VarUI1FromUI8( ULONG64 ui64In, BYTE
		// *pbOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI1FromUI8")]
		public static extern HRESULT VarUI1FromUI8(ulong ui64In, out byte pbOut);

		/// <summary>Converts a Boolean value to an unsigned short value.</summary>
		/// <param name="boolIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2frombool HRESULT VarUI2FromBool( VARIANT_BOOL boolIn,
		// USHORT *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromBool")]
		public static extern HRESULT VarUI2FromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out ushort puiOut);

		/// <summary>Converts a currency value to an unsigned short value.</summary>
		/// <param name="cyIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromcy HRESULT VarUI2FromCy( CY cyIn, USHORT *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromCy")]
		public static extern HRESULT VarUI2FromCy(CY cyIn, out ushort puiOut);

		/// <summary>Converts a date value to an unsigned short value.</summary>
		/// <param name="dateIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromdate HRESULT VarUI2FromDate( DATE dateIn, USHORT
		// *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromDate")]
		public static extern HRESULT VarUI2FromDate(DATE dateIn, out ushort puiOut);

		/// <summary>Converts a decimal value to an unsigned short value.</summary>
		/// <param name="pdecIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromdec HRESULT VarUI2FromDec( const DECIMAL *pdecIn,
		// USHORT *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromDec")]
		public static extern HRESULT VarUI2FromDec(in DECIMAL pdecIn, out ushort puiOut);

		/// <summary>Converts the default property of an IDispatch instance to an unsigned short value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromdisp HRESULT VarUI2FromDisp( IDispatch *pdispIn,
		// LCID lcid, USHORT *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromDisp")]
		public static extern HRESULT VarUI2FromDisp([In] IDispatch pdispIn, LCID lcid, out ushort puiOut);

		/// <summary>Converts the default property of an IDispatch instance to an unsigned short value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromdisp HRESULT VarUI2FromDisp( IDispatch *pdispIn,
		// LCID lcid, USHORT *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromDisp")]
		public static extern HRESULT VarUI2FromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out ushort puiOut);

		/// <summary>Converts a char value to an unsigned short value.</summary>
		/// <param name="cIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromi1 HRESULT VarUI2FromI1( CHAR cIn, USHORT *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromI1")]
		public static extern HRESULT VarUI2FromI1(sbyte cIn, out ushort puiOut);

		/// <summary>Converts a short value to an unsigned short value.</summary>
		/// <param name="uiIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromi2 HRESULT VarUI2FromI2( SHORT uiIn, USHORT
		// *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromI2")]
		public static extern HRESULT VarUI2FromI2(short uiIn, out ushort puiOut);

		/// <summary>Converts a long value to an unsigned short value.</summary>
		/// <param name="lIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromi4 HRESULT VarUI2FromI4( LONG lIn, USHORT *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromI4")]
		public static extern HRESULT VarUI2FromI4(int lIn, out ushort puiOut);

		/// <summary>Converts an 8-byte integer value to an unsigned short value.</summary>
		/// <param name="i64In">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromi8 HRESULT VarUI2FromI8( LONG64 i64In, USHORT
		// *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromI8")]
		public static extern HRESULT VarUI2FromI8(long i64In, out ushort puiOut);

		/// <summary>Converts a float value to an unsigned short value.</summary>
		/// <param name="fltIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromr4 HRESULT VarUI2FromR4( FLOAT fltIn, USHORT
		// *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromR4")]
		public static extern HRESULT VarUI2FromR4(float fltIn, out ushort puiOut);

		/// <summary>Converts a double value to an unsigned short value.</summary>
		/// <param name="dblIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromr8 HRESULT VarUI2FromR8( DOUBLE dblIn, USHORT
		// *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromR8")]
		public static extern HRESULT VarUI2FromR8(double dblIn, out ushort puiOut);

		/// <summary>Converts an OLECHAR string to an unsigned short value.</summary>
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
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromstr HRESULT VarUI2FromStr( LPCOLESTR strIn, LCID
		// lcid, ULONG dwFlags, USHORT *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromStr")]
		public static extern HRESULT VarUI2FromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out ushort puiOut);

		/// <summary>Converts an unsigned char value to an unsigned short value.</summary>
		/// <param name="bIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromui1 HRESULT VarUI2FromUI1( BYTE bIn, USHORT
		// *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromUI1")]
		public static extern HRESULT VarUI2FromUI1(byte bIn, out ushort puiOut);

		/// <summary>Converts an unsigned long value to an unsigned short value.</summary>
		/// <param name="ulIn">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromui4 HRESULT VarUI2FromUI4( ULONG ulIn, USHORT
		// *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromUI4")]
		public static extern HRESULT VarUI2FromUI4(uint ulIn, out ushort puiOut);

		/// <summary>Converts an 8-byte unsigned integer value to an unsigned short value.</summary>
		/// <param name="i64In">The value to convert.</param>
		/// <param name="puiOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui2fromui8 HRESULT VarUI2FromUI8( ULONG64 i64In, USHORT
		// *puiOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI2FromUI8")]
		public static extern HRESULT VarUI2FromUI8(ulong i64In, out ushort puiOut);

		/// <summary>Converts a Boolean value to an unsigned long value.</summary>
		/// <param name="boolIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4frombool HRESULT VarUI4FromBool( VARIANT_BOOL boolIn,
		// ULONG *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromBool")]
		public static extern HRESULT VarUI4FromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out uint pulOut);

		/// <summary>Converts a currency value to an unsigned long value.</summary>
		/// <param name="cyIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromcy HRESULT VarUI4FromCy( CY cyIn, ULONG *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromCy")]
		public static extern HRESULT VarUI4FromCy(CY cyIn, out uint pulOut);

		/// <summary>Converts a date value to an unsigned long value.</summary>
		/// <param name="dateIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromdate HRESULT VarUI4FromDate( DATE dateIn, ULONG
		// *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromDate")]
		public static extern HRESULT VarUI4FromDate(DATE dateIn, out uint pulOut);

		/// <summary>Converts a decimal value to an unsigned long value.</summary>
		/// <param name="pdecIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromdec HRESULT VarUI4FromDec( const DECIMAL *pdecIn,
		// ULONG *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromDec")]
		public static extern HRESULT VarUI4FromDec(in DECIMAL pdecIn, out uint pulOut);

		/// <summary>Converts the default property of an IDispatch instance to an unsigned long value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromdisp HRESULT VarUI4FromDisp( IDispatch *pdispIn,
		// LCID lcid, ULONG *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromDisp")]
		public static extern HRESULT VarUI4FromDisp([In] IDispatch pdispIn, LCID lcid, out uint pulOut);

		/// <summary>Converts the default property of an IDispatch instance to an unsigned long value.</summary>
		/// <param name="pdispIn">The value to convert.</param>
		/// <param name="lcid">The locale identifier.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromdisp HRESULT VarUI4FromDisp( IDispatch *pdispIn,
		// LCID lcid, ULONG *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromDisp")]
		public static extern HRESULT VarUI4FromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out uint pulOut);

		/// <summary>Converts a char value to an unsigned long value.</summary>
		/// <param name="cIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromi1 HRESULT VarUI4FromI1( CHAR cIn, ULONG *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromI1")]
		public static extern HRESULT VarUI4FromI1(sbyte cIn, out uint pulOut);

		/// <summary>Converts a short value to an unsigned long value.</summary>
		/// <param name="uiIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromi2 HRESULT VarUI4FromI2( SHORT uiIn, ULONG
		// *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromI2")]
		public static extern HRESULT VarUI4FromI2(short uiIn, out uint pulOut);

		/// <summary>Converts a long value to an unsigned long value.</summary>
		/// <param name="lIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromi4 HRESULT VarUI4FromI4( LONG lIn, ULONG *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromI4")]
		public static extern HRESULT VarUI4FromI4(int lIn, out uint pulOut);

		/// <summary>Converts an 8-byte integer value to an unsigned long value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromi8 HRESULT VarUI4FromI8( LONG64 i64In, ULONG
		// *plOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromI8")]
		public static extern HRESULT VarUI4FromI8(long i64In, out uint plOut);

		/// <summary>Converts a float value to an unsigned long value.</summary>
		/// <param name="fltIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromr4 HRESULT VarUI4FromR4( FLOAT fltIn, ULONG
		// *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromR4")]
		public static extern HRESULT VarUI4FromR4(float fltIn, out uint pulOut);

		/// <summary>Converts a double value to an unsigned long value.</summary>
		/// <param name="dblIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromr8 HRESULT VarUI4FromR8( DOUBLE dblIn, ULONG
		// *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromR8")]
		public static extern HRESULT VarUI4FromR8(double dblIn, out uint pulOut);

		/// <summary>Converts an OLECHAR string to an unsigned long value.</summary>
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
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromstr HRESULT VarUI4FromStr( LPCOLESTR strIn, LCID
		// lcid, ULONG dwFlags, ULONG *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromStr")]
		public static extern HRESULT VarUI4FromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out uint pulOut);

		/// <summary>Converts an unsigned char value to an unsigned long value.</summary>
		/// <param name="bIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromui1 HRESULT VarUI4FromUI1( BYTE bIn, ULONG
		// *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromUI1")]
		public static extern HRESULT VarUI4FromUI1(byte bIn, out uint pulOut);

		/// <summary>Converts an unsigned short value to an unsigned long value.</summary>
		/// <param name="uiIn">The value to convert.</param>
		/// <param name="pulOut">The resulting value.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromui2 HRESULT VarUI4FromUI2( USHORT uiIn, ULONG
		// *pulOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromUI2")]
		public static extern HRESULT VarUI4FromUI2(ushort uiIn, out uint pulOut);

		/// <summary>Converts an 8-byte unsigned integer value to an unsigned long value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui4fromui8 HRESULT VarUI4FromUI8( ULONG64 ui64In, ULONG
		// *plOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI4FromUI8")]
		public static extern HRESULT VarUI4FromUI8(ulong ui64In, out uint plOut);

		/// <summary>Converts a VARIANT_BOOL value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8frombool HRESULT VarUI8FromBool( VARIANT_BOOL boolIn,
		// ULONG64 *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromBool")]
		public static extern HRESULT VarUI8FromBool([MarshalAs(UnmanagedType.VariantBool)] bool boolIn, out ulong pi64Out);

		/// <summary>Converts a currency value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromcy HRESULT VarUI8FromCy( CY cyIn, ULONG64
		// *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromCy")]
		public static extern HRESULT VarUI8FromCy(CY cyIn, out ulong pi64Out);

		/// <summary>Converts a date value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromdate HRESULT VarUI8FromDate( DATE dateIn, ULONG64
		// *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromDate")]
		public static extern HRESULT VarUI8FromDate(DATE dateIn, out ulong pi64Out);

		/// <summary>Converts a decimal value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromdec HRESULT VarUI8FromDec( const DECIMAL *pdecIn,
		// ULONG64 *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromDec")]
		public static extern HRESULT VarUI8FromDec(in DECIMAL pdecIn, out ulong pi64Out);

		/// <summary>Converts the default property of an IDispatch instance to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromdisp HRESULT VarUI8FromDisp( IDispatch *pdispIn,
		// LCID lcid, ULONG64 *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromDisp")]
		public static extern HRESULT VarUI8FromDisp([In] IDispatch pdispIn, LCID lcid, out ulong pi64Out);

		/// <summary>Converts the default property of an IDispatch instance to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromdisp HRESULT VarUI8FromDisp( IDispatch *pdispIn,
		// LCID lcid, ULONG64 *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromDisp")]
		public static extern HRESULT VarUI8FromDisp([In, MarshalAs(UnmanagedType.IDispatch)] object pdispIn, LCID lcid, out ulong pi64Out);

		/// <summary>Converts a char value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromi1 HRESULT VarUI8FromI1( CHAR cIn, ULONG64
		// *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromI1")]
		public static extern HRESULT VarUI8FromI1(sbyte cIn, out ulong pi64Out);

		/// <summary>Converts a short value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromi2 HRESULT VarUI8FromI2( SHORT sIn, ULONG64
		// *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromI2")]
		public static extern HRESULT VarUI8FromI2(short sIn, out ulong pi64Out);

		/// <summary>Converts an 8-byte integer value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromi8 HRESULT VarUI8FromI8( LONG64 ui64In, ULONG64
		// *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromI8")]
		public static extern HRESULT VarUI8FromI8(long ui64In, out ulong pi64Out);

		/// <summary>Converts a float value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromr4 HRESULT VarUI8FromR4( FLOAT fltIn, ULONG64
		// *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromR4")]
		public static extern HRESULT VarUI8FromR4(float fltIn, out ulong pi64Out);

		/// <summary>Converts a double value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromr8 HRESULT VarUI8FromR8( DOUBLE dblIn, ULONG64
		// *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromR8")]
		public static extern HRESULT VarUI8FromR8(double dblIn, out ulong pi64Out);

		/// <summary>Converts an OLECHAR string to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromstr HRESULT VarUI8FromStr( LPCOLESTR strIn, LCID
		// lcid, ULONG dwFlags, ULONG64 *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromStr")]
		public static extern HRESULT VarUI8FromStr([MarshalAs(UnmanagedType.LPWStr)] string strIn, LCID lcid, VarFlags dwFlags, out ulong pi64Out);

		/// <summary>Converts a byte value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromui1 HRESULT VarUI8FromUI1( BYTE bIn, ULONG64
		// *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromUI1")]
		public static extern HRESULT VarUI8FromUI1(byte bIn, out ulong pi64Out);

		/// <summary>Converts an unsigned short value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromui2 HRESULT VarUI8FromUI2( USHORT uiIn, ULONG64
		// *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromUI2")]
		public static extern HRESULT VarUI8FromUI2(ushort uiIn, out ulong pi64Out);

		/// <summary>Converts an unsigned long value to an 8-byte unsigned integer value.</summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varui8fromui4 HRESULT VarUI8FromUI4( ULONG ulIn, ULONG64
		// *pi64Out );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarUI8FromUI4")]
		public static extern HRESULT VarUI8FromUI4(uint ulIn, out ulong pi64Out);

		/// <summary>Returns a string containing the localized name of the weekday.</summary>
		/// <param name="iWeekday">
		/// <para>The day of the week.</para>
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
		/// <param name="fAbbrev">
		/// If zero then the full (non-abbreviated) weekday name is used. If non-zero, then the abbreviation for the weekday name is used.
		/// </param>
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
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more of the arguments is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varweekdayname HRESULT VarWeekdayName( int iWeekday, int
		// fAbbrev, int iFirstDay, ULONG dwFlags, BSTR *pbstrOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "NF:oleauto.VarWeekdayName")]
		public static extern HRESULT VarWeekdayName(int iWeekday, int fAbbrev, int iFirstDay, VarFlags dwFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);
	}
}