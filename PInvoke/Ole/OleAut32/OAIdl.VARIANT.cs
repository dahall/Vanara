using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class OleAut32
	{
		/// <summary>
		/// VARIANTARG describes arguments passed within DISPPARAMS, and VARIANT to specify variant data that cannot be passed by reference.
		/// <para>
		/// When a variant refers to another variant by using the VT_VARIANT | VT_BYREF vartype, the variant being referred to cannot also be
		/// of type VT_VARIANT | VT_BYREF.VARIANTs can be passed by value, even if VARIANTARGs cannot.
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
				private IntPtr _record;
				private IntPtr _recordInfo;
			}
		}

		/// <summary>Returns the absolute value of a variant.</summary>
		/// <param name="pvarIn">The variant.</param>
		/// <param name="pvarResult">The result variant.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varabs
		// HRESULT VarAbs( LPVARIANT pvarIn, LPVARIANT pvarResult );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varadd
		// HRESULT VarAdd( LPVARIANT pvarLeft, LPVARIANT pvarRight, LPVARIANT pvarResult );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varand
		// HRESULT VarAnd( LPVARIANT pvarLeft, LPVARIANT pvarRight, LPVARIANT pvarResult );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromcy
		// HRESULT VarBoolFromCy( CY cyIn, VARIANT_BOOL *pboolOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "4d13c480-26f6-49d3-aaaa-1804d56f8fe3")]
		public static extern HRESULT VarBoolFromCy(long cyIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/oleauto/nf-oleauto-varboolfromdate
		// HRESULT VarBoolFromDate( DATE dateIn, VARIANT_BOOL *pboolOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "3ba9e701-56c6-471c-9c82-a31c893a3a1c")]
		public static extern HRESULT VarBoolFromDate(double dateIn, [MarshalAs(UnmanagedType.VariantBool)] out bool pboolOut);
		
		/*
		VarBoolFromDec
		VarBoolFromDisp
		VarBoolFromI1
		VarBoolFromI2
		VarBoolFromI4
		VarBoolFromI8
		VarBoolFromR4
		VarBoolFromR8
		VarBoolFromStr
		VarBoolFromUI1
		VarBoolFromUI2
		VarBoolFromUI4
		VarBoolFromUI8
		VarBstrCat
		VarBstrCmp
		VarBstrFromBool
		VarBstrFromCy
		VarBstrFromDate
		VarBstrFromDec
		VarBstrFromDisp
		VarBstrFromI1
		VarBstrFromI2
		VarBstrFromI4
		VarBstrFromI8
		VarBstrFromR4
		VarBstrFromR8
		VarBstrFromUI1
		VarBstrFromUI2
		VarBstrFromUI4
		VarBstrFromUI8
		VarCat
		VarCmp
		VarCyAbs
		VarCyAdd
		VarCyCmp
		VarCyCmpR8
		VarCyFix
		VarCyFromBool
		VarCyFromDate
		VarCyFromDec
		VarCyFromDisp
		VarCyFromI1
		VarCyFromI2
		VarCyFromI4
		VarCyFromI8
		VarCyFromR4
		VarCyFromR8
		VarCyFromStr
		VarCyFromUI1
		VarCyFromUI2
		VarCyFromUI4
		VarCyFromUI8
		VarCyInt
		VarCyMul
		VarCyMulI4
		VarCyMulI8
		VarCyNeg
		VarCyRound
		VarCySub
		VarDateFromBool
		VarDateFromCy
		VarDateFromDec
		VarDateFromDisp
		VarDateFromI1
		VarDateFromI2
		VarDateFromI4
		VarDateFromI8
		VarDateFromR4
		VarDateFromR8
		VarDateFromStr
		VarDateFromUdate
		VarDateFromUdateEx
		VarDateFromUI1
		VarDateFromUI2
		VarDateFromUI4
		VarDateFromUI8
		VarDecAbs
		VarDecAdd
		VarDecCmp
		VarDecCmpR8
		VarDecDiv
		VarDecFix
		VarDecFromBool
		VarDecFromCy
		VarDecFromDate
		VarDecFromDisp
		VarDecFromI1
		VarDecFromI2
		VarDecFromI4
		VarDecFromI8
		VarDecFromR4
		VarDecFromR8
		VarDecFromStr
		VarDecFromUI1
		VarDecFromUI2
		VarDecFromUI4
		VarDecFromUI8
		VarDecInt
		VarDecMul
		VarDecNeg
		VarDecRound
		VarDecSub
		VarDiv
		VarEqv
		VarFix
		VarFormat
		VarFormatCurrency
		VarFormatDateTime
		VarFormatFromTokens
		VarFormatNumber
		VarFormatPercent
		VarI1FromBool
		VarI1FromCy
		VarI1FromDate
		VarI1FromDec
		VarI1FromDisp
		VarI1FromI2
		VarI1FromI4
		VarI1FromI8
		VarI1FromR4
		VarI1FromR8
		VarI1FromStr
		VarI1FromUI1
		VarI1FromUI2
		VarI1FromUI4
		VarI1FromUI8
		VarI2FromBool
		VarI2FromCy
		VarI2FromDate
		VarI2FromDec
		VarI2FromDisp
		VarI2FromI1
		VarI2FromI4
		VarI2FromI8
		VarI2FromR4
		VarI2FromR8
		VarI2FromStr
		VarI2FromUI1
		VarI2FromUI2
		VarI2FromUI4
		VarI2FromUI8
		VarI4FromBool
		VarI4FromCy
		VarI4FromDate
		VarI4FromDec
		VarI4FromDisp
		VarI4FromI1
		VarI4FromI2
		VarI4FromI4
		VarI4FromI8
		VarI4FromR4
		VarI4FromR8
		VarI4FromStr
		VarI4FromUI1
		VarI4FromUI2
		VarI4FromUI4
		VarI4FromUI8
		VarI8FromBool
		VarI8FromCy
		VarI8FromDate
		VarI8FromDec
		VarI8FromDisp
		VarI8FromI1
		VarI8FromI2
		VarI8FromR4
		VarI8FromR8
		VarI8FromStr
		VarI8FromUI1
		VarI8FromUI2
		VarI8FromUI4
		VarI8FromUI8
		VariantChangeType
		VariantChangeTypeEx
		VariantCopy
		VariantCopyInd
		VariantInit
		VarIdiv
		VarImp
		VarInt
		VarMod
		VarMonthName
		VarMul
		VarNeg
		VarNot
		VarNumFromParseNum
		VarOr
		VarParseNumFromStr
		VarPow
		VarR4CmpR8
		VarR4FromBool
		VarR4FromCy
		VarR4FromDate
		VarR4FromDec
		VarR4FromDisp
		VarR4FromI1
		VarR4FromI2
		VarR4FromI4
		VarR4FromI8
		VarR4FromR8
		VarR4FromStr
		VarR4FromUI1
		VarR4FromUI2
		VarR4FromUI4
		VarR4FromUI8
		VarR8FromBool
		VarR8FromCy
		VarR8FromDate
		VarR8FromDec
		VarR8FromDisp
		VarR8FromI1
		VarR8FromI2
		VarR8FromI4
		VarR8FromI8
		VarR8FromR4
		VarR8FromStr
		VarR8FromUI1
		VarR8FromUI2
		VarR8FromUI4
		VarR8FromUI8
		VarR8Pow
		VarR8Round
		VarRound
		VarSub
		VarTokenizeFormatString
		VarUdateFromDate
		VarUI1FromBool
		VarUI1FromCy
		VarUI1FromDate
		VarUI1FromDec
		VarUI1FromDisp
		VarUI1FromI1
		VarUI1FromI2
		VarUI1FromI4
		VarUI1FromI8
		VarUI1FromR4
		VarUI1FromR8
		VarUI1FromStr
		VarUI1FromUI2
		VarUI1FromUI4
		VarUI1FromUI8
		VarUI2FromBool
		VarUI2FromCy
		VarUI2FromDate
		VarUI2FromDec
		VarUI2FromDisp
		VarUI2FromI1
		VarUI2FromI2
		VarUI2FromI4
		VarUI2FromI8
		VarUI2FromR4
		VarUI2FromR8
		VarUI2FromStr
		VarUI2FromUI1
		VarUI2FromUI4
		VarUI2FromUI8
		VarUI4FromBool
		VarUI4FromCy
		VarUI4FromDate
		VarUI4FromDec
		VarUI4FromDisp
		VarUI4FromI1
		VarUI4FromI2
		VarUI4FromI4
		VarUI4FromI8
		VarUI4FromR4
		VarUI4FromR8
		VarUI4FromStr
		VarUI4FromUI1
		VarUI4FromUI2
		VarUI4FromUI8
		VarUI8FromBool
		VarUI8FromCy
		VarUI8FromDate
		VarUI8FromDec
		VarUI8FromDisp
		VarUI8FromI1
		VarUI8FromI2
		VarUI8FromI8
		VarUI8FromR4
		VarUI8FromR8
		VarUI8FromStr
		VarUI8FromUI1
		VarUI8FromUI2
		VarUI8FromUI4
		VarWeekdayName
		VarXor
		*/
	}
}