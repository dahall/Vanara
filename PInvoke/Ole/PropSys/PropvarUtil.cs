using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from propsys.h</summary>
	public static partial class PropSys
	{
		/// <summary>Values used by the <see cref="PropVariantChangeType"/> function.</summary>
		[PInvokeData("Propvarutil.h")]
		[Flags]
		public enum PROPVAR_CHANGE_FLAGS
		{
			/// <summary>The PVCHF default</summary>
			PVCHF_DEFAULT = 0x00000000,
			/// <summary>Maps to VARIANT_NOVALUEPROP for VariantChangeType</summary>
			PVCHF_NOVALUEPROP = 0x00000001,
			/// <summary>Maps to VARIANT_ALPHABOOL for VariantChangeType</summary>
			PVCHF_ALPHABOOL = 0x00000002,
			/// <summary>Maps to VARIANT_NOUSEROVERRIDE for VariantChangeType</summary>
			PVCHF_NOUSEROVERRIDE = 0x00000004,
			/// <summary>Maps to VARIANT_LOCALBOOL for VariantChangeType</summary>
			PVCHF_LOCALBOOL = 0x00000008,
			/// <summary>Don't convert a string that looks like hexadecimal (0xABCD) to the numerical equivalent.</summary>
			PVCHF_NOHEXSTRING = 0x00000010
		}

		/// <summary>Values used by the <see cref="PropVariantCompareEx"/> function.</summary>
		[Flags]
		[PInvokeData("Propvarutil.h")]
		public enum PROPVAR_COMPARE_FLAGS
		{
			/// <summary>When comparing strings, use StrCmpLogical</summary>
			PVCF_DEFAULT = 0x00000000,
			/// <summary>Empty/null values are greater-than non-empty values</summary>
			PVCF_TREATEMPTYASGREATERTHAN = 0x00000001,
			/// <summary>When comparing strings, use StrCmp</summary>
			PVCF_USESTRCMP = 0x00000002,
			/// <summary>When comparing strings, use StrCmpC</summary>
			PVCF_USESTRCMPC = 0x00000004,
			/// <summary>When comparing strings, use StrCmpI</summary>
			PVCF_USESTRCMPI = 0x00000008,
			/// <summary>When comparing strings, use StrCmpIC</summary>
			PVCF_USESTRCMPIC = 0x00000010,
			/// <summary>When comparing strings, use CompareStringEx with LOCALE_NAME_USER_DEFAULT and SORT_DIGITSASNUMBERS.  This corresponds to the linguistically correct order for UI lists.</summary>
			PVCF_DIGITSASNUMBERS_CASESENSITIVE = 0x00000020,
		}

		/// <summary>Values used by the <see cref="PropVariantCompareEx"/> function.</summary>
		[PInvokeData("Propvarutil.h")]
		public enum PROPVAR_COMPARE_UNIT
		{
			/// <summary>The default unit.</summary>
			PVCU_DEFAULT = 0,
			/// <summary>The second comparison unit.</summary>
			PVCU_SECOND = 1,
			/// <summary>The minute comparison unit.</summary>
			PVCU_MINUTE = 2,
			/// <summary>The hour comparison unit.</summary>
			PVCU_HOUR = 3,
			/// <summary>The day comparison unit.</summary>
			PVCU_DAY = 4,
			/// <summary>The month comparison unit.</summary>
			PVCU_MONTH = 5,
			/// <summary>The year comparison unit.</summary>
			PVCU_YEAR = 6
		}

		/// <summary>Values used by the <see cref="PropVariantToFileTime"/> function.</summary>
		[PInvokeData("Propvarutil.h")]
		public enum PSTIME_FLAGS
		{
			/// <summary>Indicates the output will use coordinated universal time.</summary>
			PSTF_UTC = 0x00000000,
			/// <summary>Indicates the output will use local time.</summary>
			PSTF_LOCAL = 0x00000001
		}

		/// <summary>
		/// Initializes a <see cref="PROPVARIANT"/> structure from a specified Boolean vector.
		/// </summary>
		/// <param name="prgf">Pointer to the Boolean vector used to initialize the structure. If this parameter is NULL, the elements pointed to by the cabool.pElems structure member are initialized with VARIANT_FALSE.</param>
		/// <param name="cElems">The number of vector elements.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762288")]
		public static extern HRESULT InitPropVariantFromBooleanVector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Bool)] bool[] prgf, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// Initializes a <see cref="PROPVARIANT"/> structure using the contents of a buffer.
		/// </summary>
		/// <param name="pv">Pointer to the buffer.</param>
		/// <param name="cb">The length of the buffer, in bytes.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762289")]
		public static extern HRESULT InitPropVariantFromBuffer([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.U1)] byte[] pv, uint cb, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// Initializes a <see cref="PROPVARIANT"/> structure based on a class identifier (CLSID).
		/// </summary>
		/// <param name="clsid">Reference to the CLSID.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762290")]
		public static extern HRESULT InitPropVariantFromCLSID([In] ref Guid clsid, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// Initializes a <see cref="PROPVARIANT"/> structure based on a specified vector of double values.
		/// </summary>
		/// <param name="prgn">Pointer to a double vector. If this value is NULL, the elements pointed to by the cadbl.pElems structure member are initialized with 0.0.</param>
		/// <param name="cElems">The number of vector elements.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762292")]
		public static extern HRESULT InitPropVariantFromDoubleVector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.R8)] double[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// Initializes a <see cref="PROPVARIANT"/> structure based on information stored in a <see cref="FILETIME" /> structure.
		/// </summary>
		/// <param name="pftIn">Pointer to the date and time as a <see cref="FILETIME" /> structure.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762293")]
		public static extern HRESULT InitPropVariantFromFileTime([In] ref FILETIME pftIn, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// Initializes a <see cref="PROPVARIANT"/> structure from a specified vector of <see cref="FILETIME"/> values.
		/// </summary>
		/// <param name="prgft">Pointer to the date and time as a <see cref="FILETIME"/> vector. If this value is NULL, the elements pointed to by the cafiletime.pElems structure member is initialized with (FILETIME)0.</param>
		/// <param name="cElems">The number of vector elements.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762294")]
		public static extern HRESULT InitPropVariantFromFileTimeVector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] FILETIME[] prgft, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// Initializes a <see cref="PROPVARIANT"/> structure based on a specified vector of 16-bit integer values.
		/// </summary>
		/// <param name="prgn">Pointer to a source vector of SHORT values. If this parameter is NULL, the vector is initialized with zeros.</param>
		/// <param name="cElems">The number of elements in the vector.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762298")]
		public static extern HRESULT InitPropVariantFromInt16Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I2)] short[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// Initializes a <see cref="PROPVARIANT"/> structure based on a specified vector of 32-bit integer values.
		/// </summary>
		/// <param name="prgn">Pointer to a source vector of LONG values. If this parameter is NULL, the vector is initialized with zeros.</param>
		/// <param name="cElems">The number of elements in the vector.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762300")]
		public static extern HRESULT InitPropVariantFromInt32Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I4)] int[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// Initializes a <see cref="PROPVARIANT"/> structure based on a specified vector of 64-bit integer values.
		/// </summary>
		/// <param name="prgn">Pointer to a source vector of LONGLONG values. If this parameter is NULL, the vector is initialized with zeros.</param>
		/// <param name="cElems">The number of elements in the vector.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762302")]
		public static extern HRESULT InitPropVariantFromInt64Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I8)] long[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// Initializes a <see cref="PROPVARIANT"/> structure based on a specified <see cref="PROPVARIANT" /> vector element.
		/// </summary>
		/// <remarks>This function extracts a single value from the source <see cref="PROPVARIANT"/> structure and uses that value to initialize the output <c>PROPVARIANT</c> structure. The calling application must use <see cref="PropVariantClear"/> to free the <c>PROPVARIANT</c> referred to by ppropvar when it is no longer needed.
		/// <para>If the source <c>PROPVARIANT</c> is a vector or array, iElem must be less than the number of elements in the vector or array.</para>
		/// <para>If the source <c>PROPVARIANT</c> has a single value, iElem must be 0.</para>
		/// <para>If the source <c>PROPVARIANT</c> is empty, this function always returns an error code.</para>
		/// <para>You can use <see cref="PropVariantGetElementCount"/> to obtain the number of elements in the vector or array.</para>
		/// </remarks>
		/// <param name="propvarIn">The source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="iElem">The index of the source <see cref="PROPVARIANT"/> structure element.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762303")]
		public static extern HRESULT InitPropVariantFromPropVariantVectorElem([In] PROPVARIANT propvarIn, uint iElem, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a specified string vector.</summary>
		/// <param name="prgsz">Pointer to a buffer that contains the source string vector.</param>
		/// <param name="cElems">The number of vector elements in <paramref name="prgsz"/>.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762307")]
		public static extern HRESULT InitPropVariantFromStringVector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.LPWStr)] string[] prgsz, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a specified string vector.</summary>
		/// <param name="prgn">The PRGN.</param>
		/// <param name="cElems">The number of vector elements in <paramref name="prgn"/>.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762310")]
		public static extern HRESULT InitPropVariantFromUInt16Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.U2)] ushort[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a vector of 32-bit unsigned integer values.</summary>
		/// <param name="prgn">Pointer to a source vector of ULONG values. If this parameter is NULL, the <see cref="PROPVARIANT" /> is initialized with zeros.</param>
		/// <param name="cElems">The number of vector elements in <paramref name="prgn"/>.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762312")]
		public static extern HRESULT InitPropVariantFromUInt32Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.U4)] uint[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a vector of 64-bit unsigned integer values.</summary>
		/// <param name="prgn">Pointer to a source vector of ULONGLONG values. If this parameter is NULL, the <see cref="PROPVARIANT" /> is initialized with zeros.</param>
		/// <param name="cElems">The number of vector elements in <paramref name="prgn"/>.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762314")]
		public static extern HRESULT InitPropVariantFromUInt64Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.U8)] ulong[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a vector element in a <see cref="PROPVARIANT"/> structure with a value stored in another PROPVARIANT.</summary>
		/// <param name="propvarSingle">Reference to the source <see cref="PROPVARIANT"/> structure that contains a single value.</param>
		/// <param name="ppropvarVector">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>Returns S_OK if successful, or a standard COM error value otherwise. If the requested coercion is not possible, an error is returned.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762315")]
		public static extern HRESULT InitPropVariantVectorFromPropVariant([In] PROPVARIANT propvarSingle, [Out] PROPVARIANT ppropvarVector);

		/// <summary>Coerces a value stored as a <see cref="PROPVARIANT"/> structure to an equivalent value of a different variant type.</summary>
		/// <param name="ppropvarDest">A pointer to a <see cref="PROPVARIANT"/> structure that, when this function returns successfully, receives the coerced value and its new type.</param>
		/// <param name="propvarSrc">A reference to the source <see cref="PROPVARIANT"/> structure that contains the value expressed as its original type.</param>
		/// <param name="flags">Reserved, must be 0.</param>
		/// <param name="vt">Specifies the new type for the value. See the tables below for recognized type names.</param>
		/// <returns>Returns S_OK if successful, or a standard COM error value otherwise. If the requested coercion is not possible, an error is returned.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776514")]
		public static extern HRESULT PropVariantChangeType([Out] PROPVARIANT ppropvarDest, [In] PROPVARIANT propvarSrc, PROPVAR_CHANGE_FLAGS flags, VARTYPE vt);

		/// <summary>Compares two <see cref="PROPVARIANT"/> structures, based on default comparison units and settings.</summary>
		/// <param name="propvar1">Reference to the first <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="propvar2">Reference to the second <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item><description>Returns 1 if propvar1 is greater than propvar2</description></item>
		/// <item><description>Returns 0 if propvar1 equals propvar2</description></item>
		/// <item><description>Returns -1 if propvar1 is less than propvar2</description></item>
		/// </list>
		/// </returns>
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776516")]
		public static int PropVariantCompare(PROPVARIANT propvar1, PROPVARIANT propvar2) =>
			PropVariantCompareEx(propvar1, propvar2, PROPVAR_COMPARE_UNIT.PVCU_DEFAULT, PROPVAR_COMPARE_FLAGS.PVCF_DEFAULT);

		/// <summary>
		/// Compares two <see cref="PROPVARIANT" /> structures, based on specified comparison units and flags.
		/// </summary>
		/// <param name="propvar1">Reference to the first <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="propvar2">Reference to the second <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="unit">Specifies, where appropriate, one of the comparison units defined in PROPVAR_COMPARE_UNIT.</param>
		/// <param name="flags">Specifies one of the following:</param>
		/// <returns>
		/// <list type="bullet">
		/// <item><description>Returns 1 if propvar1 is greater than propvar2</description></item>
		/// <item><description>Returns 0 if propvar1 equals propvar2</description></item>
		/// <item><description>Returns -1 if propvar1 is less than propvar2</description></item>
		/// </list>
		/// </returns>
		[DllImport(Lib.PropSys, ExactSpelling = true, PreserveSig = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776517")]
		public static extern int PropVariantCompareEx(PROPVARIANT propvar1, PROPVARIANT propvar2, PROPVAR_COMPARE_UNIT unit, PROPVAR_COMPARE_FLAGS flags);

		/// <summary>Retrieves the element count of a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>Returns the element count of a VT_VECTOR or VT_ARRAY value: for single values, returns 1; for empty structures, returns 0.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true, PreserveSig = true)]
		[return: MarshalAs(UnmanagedType.I4)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776522")]
		public static extern int PropVariantGetElementCount([In] PROPVARIANT propVar);

		/// <summary>Extracts a Boolean property value of a <see cref="PROPVARIANT" /> structure. If no value can be extracted, then a default value is assigned.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pfRet">When this function returns, contains the extracted property value if one exists; otherwise, contains FALSE.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776531")]
		public static extern HRESULT PropVariantToBoolean([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.Bool)] out bool pfRet);

		/// <summary>Extracts data from a <see cref="PROPVARIANT" /> structure into a newly allocated Boolean vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pprgf">When this function returns, contains a pointer to a vector of Boolean values extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pcElem">When this function returns, contains the count of Boolean elements extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>Returns S_OK if successful, or an error value otherwise. E_INVALIDARG indicates that the <see cref="PROPVARIANT" /> was not of the appropriate type.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776533")]
		public static extern HRESULT PropVariantToBooleanVectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts the BSTR property value of a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pbstrOut">Pointer to the extracted property value if one exists; otherwise, contains an empty string.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776535")]
		public static extern HRESULT PropVariantToBSTR([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

		/// <summary>Extracts the buffer value from a <see cref="PROPVARIANT" /> structure of type VT_VECTOR | VT_UI1 or VT_ARRRAY | VT_UI1.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pv">Pointer to a buffer of length cb bytes. When this function returns, contains the first cb bytes of the extracted buffer value.</param>
		/// <param name="cb">The buffer length, in bytes.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776536")]
		public static extern HRESULT PropVariantToBuffer([In] PROPVARIANT propVar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pv, uint cb);

		/// <summary>Extracts double value from a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pdblRet">When this function returns, contains the extracted property value if one exists; otherwise, contains 0.0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776538")]
		public static extern HRESULT PropVariantToDouble([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.R8)] out double pdblRet);

		/// <summary>Extracts data from a <see cref="PROPVARIANT" /> structure into a newly-allocated double vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pprgf">When this function returns, contains a pointer to a vector of double values extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pcElem">When this function returns, contains the count of double elements extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776540")]
		public static extern HRESULT PropVariantToDoubleVectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts the <see cref="FILETIME" /> structure from a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pstfOut">Specifies one of the time flags.</param>
		/// <param name="pftOut">When this function returns, contains the extracted <see cref="FILETIME" /> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776542")]
		public static extern HRESULT PropVariantToFileTime([In] PROPVARIANT propVar, PSTIME_FLAGS pstfOut, out FILETIME pftOut);

		/// <summary>Extracts data from a <see cref="PROPVARIANT" /> structure into a newly-allocated <see cref="FILETIME" /> vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pprgf">When this function returns, contains a pointer to a vector of <see cref="FILETIME" /> values extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pcElem">When this function returns, contains the count of <see cref="FILETIME" /> elements extracted from source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776544")]
		public static extern HRESULT PropVariantToFileTimeVectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts a GUID value from a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pguid">When this function returns, contains the extracted property value if one exists.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776545")]
		public static extern HRESULT PropVariantToGUID([In] PROPVARIANT propVar, out Guid pguid);

		/// <summary>Extracts an Int16 property value of a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="piRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776546")]
		public static extern HRESULT PropVariantToInt16([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.I2)] out short piRet);

		/// <summary>Extracts data from a <see cref="PROPVARIANT" /> structure into a newly allocated Int16 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pprgf">When this function returns, contains a pointer to a vector of Int16 values extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pcElem">When this function returns, contains the count of Int16 elements extracted from source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776548")]
		public static extern HRESULT PropVariantToInt16VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts an Int32 property value of a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="plRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776550")]
		public static extern HRESULT PropVariantToInt32([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.I4)] out int plRet);

		/// <summary>Extracts data from a <see cref="PROPVARIANT" /> structure into a newly allocated Int32 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pprgf">When this function returns, contains a pointer to a vector of Int32 values extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pcElem">When this function returns, contains the count of Int32 elements extracted from source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776552")]
		public static extern HRESULT PropVariantToInt32VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts an Int64 property value of a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pllRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776554")]
		public static extern HRESULT PropVariantToInt64([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.I8)] out long pllRet);

		/// <summary>Extracts data from a <see cref="PROPVARIANT" /> structure into a newly allocated Int64 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pprgf">When this function returns, contains a pointer to a vector of Int64 values extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pcElem">When this function returns, contains the count of Int64 elements extracted from source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776557")]
		public static extern HRESULT PropVariantToInt64VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts a string property value from a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="ppszOut">When this function returns, contains a pointer to the extracted property value if one exists.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776560")]
		public static extern HRESULT PropVariantToStringAlloc([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszOut);

		/// <summary>Extracts data from a <see cref="PROPVARIANT" /> structure into a newly allocated strings in a newly allocated vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pprgf">When this function returns, contains a pointer to a vector of strings extracted from source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pcElem">When this function returns, contains the count of string elements extracted from source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776562")]
		public static extern HRESULT PropVariantToStringVectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts the string property value of a <see cref="PROPVARIANT" /> structure. If no value exists, then the specified default value is returned.</summary>
		/// <param name="propvarIn">Reference to a source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pszDefault">Pointer to a default Unicode string value, for use where no value currently exists. May be NULL.</param>
		/// <returns>Returns string value or the default.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776563")]
		public static extern string PropVariantToStringWithDefault([In] PROPVARIANT propvarIn, [In, MarshalAs(UnmanagedType.LPWStr)] string pszDefault);

		/// <summary>Extracts a UInt16 property value of a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="puiRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776565")]
		public static extern HRESULT PropVariantToUInt16([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.U2)] out ushort puiRet);

		/// <summary>Extracts data from a <see cref="PROPVARIANT" /> structure into a newly allocated UInt16 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pprgf">When this function returns, contains a pointer to a vector of UInt16 values extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pcElem">When this function returns, contains the count of UInt16 elements extracted from source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776567")]
		public static extern HRESULT PropVariantToUInt16VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts a UInt32 property value of a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pulRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776569")]
		public static extern HRESULT PropVariantToUInt32([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.U4)] out uint pulRet);

		/// <summary>Extracts data from a <see cref="PROPVARIANT" /> structure into a newly allocated UInt32 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pprgf">When this function returns, contains a pointer to a vector of UInt32 values extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pcElem">When this function returns, contains the count of UInt32 elements extracted from source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776571")]
		public static extern HRESULT PropVariantToUInt32VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts a UInt64 property value of a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pullRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776573")]
		public static extern HRESULT PropVariantToUInt64([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.U8)] out ulong pullRet);

		/// <summary>Extracts data from a <see cref="PROPVARIANT" /> structure into a newly allocated UInt64 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pprgf">When this function returns, contains a pointer to a vector of UInt64 values extracted from the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pcElem">When this function returns, contains the count of UInt64 elements extracted from source <see cref="PROPVARIANT" /> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776575")]
		public static extern HRESULT PropVariantToUInt64VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Converts the contents of a <see cref="PROPVARIANT" /> structure to a VARIANT structure.</summary>
		/// <param name="pPropVar">Reference to the source <see cref="PROPVARIANT" /> structure.</param>
		/// <param name="pVar">Pointer to a VARIANT structure. When this function returns, the VARIANT contains the converted information.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776577")]
		public static extern HRESULT PropVariantToVariant([In] PROPVARIANT pPropVar, IntPtr pVar);

		/// <summary>Copies the contents of a VARIANT structure to a <see cref="PROPVARIANT" /> structure.</summary>
		/// <param name="pVar">Pointer to a source VARIANT structure.</param>
		/// <param name="pPropVar">Pointer to a <see cref="PROPVARIANT" /> structure. When this function returns, the <see cref="PROPVARIANT" /> contains the converted information.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776616")]
		public static extern HRESULT VariantToPropVariant([In] IntPtr pVar, [In, Out] PROPVARIANT pPropVar);
	}
}
